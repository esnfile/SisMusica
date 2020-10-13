using BLL.Funcoes;
using BLL.pessoa;
using BLL.Usuario;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using ENT.pessoa;
using ENT.relatorio;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccbrepess
{
    public partial class frmAnalisePessoa : Form
    {
        public frmAnalisePessoa()
        {
            InitializeComponent();

            try
            {

                /////preenche o comboRegional
                //apoio.carregaComboRegional(cboRegional);
                ////Carrega as Regiões e Comuns
                //preencherGrid("Regiao", Convert.ToString(cboRegional.SelectedValue), gridRegiao);
                //preencherGrid("Comum", string.Empty, gridComum);

                //Carrega os cargos
                //preencherGrid("Cargo", string.Empty, gridCargo);
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region declarações

        TreeNode nodeRegional;
        TreeNode nodeRegiao;
        TreeNode nodeMinisterioRegiao;
        TreeNode nodePessoaMinisterioRegiao;
        TreeNode nodeComum;
        TreeNode nodeMinisterioComum;
        TreeNode nodePessoaMinisterioComum;

        //variaveis
        string CodComum;
        string CodRegiao;
        string CodRegional;
        string CodCargo;

        bool blnValida;
        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;

        BLL_pessoa objBLL_Pessoa;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        List<MOD_ccb> listaCCB = new List<MOD_ccb>();

        BLL_usuario objBLL_Usuario;
        BindingList<MOD_usuarioCCB> listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();
        List<MOD_usuarioCargo> listaUsuarioCargo = new List<MOD_usuarioCargo>();

        BLL_regiaoAtuacao objBLL_Regiao;
        List<MOD_regiaoAtuacao> listaRegiao = new List<MOD_regiaoAtuacao>();
        BindingList<MOD_usuarioRegiao> listaUsuarioReg = new BindingList<MOD_usuarioRegiao>();

        BLL_regional objBLL_Regional;
        List<MOD_regional> listaRegional = new List<MOD_regional>();

        List<MOD_cargo> listaCargo = new List<MOD_cargo>();

        Form formulario;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region Eventos do Formulario

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmAnalisePessoa_Load(object sender, EventArgs e)
        {
            try
            {

                //funcoes.gridRegiao(gridRegiao, "VisaoOrquestral");
                //funcoes.gridCCB(gridComComum, "VisaoOrquestral");

                //verificar permissão de acesso
                //verPermVisao();
                carregarDados();
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void cboCargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(List<MOD_pessoa> lista, string NomeRelatorio)
        {
            try
            {
                MOD_paramRelatorio Parametro = new MOD_paramRelatorio();
                Parametro.NomeRelatorio = NomeRelatorio;
                Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                formulario = new frmListaPessoa(this, lista, Parametro);
                ((frmListaPessoa)formulario).ShowDialog();
                ((frmListaPessoa)formulario).Dispose();
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #region Gerar dados

        /// <summary>
        /// Função que carrega os módulos, submódulos, programas e rotinas para controle de acesso
        /// </summary>
        internal void carregarDados()
        {
            try
            {
                apoio.Aguarde("Buscando registros...");

                tvwDados.Nodes.Clear();

                TreeNode nodeRegiao = null;
                TreeNode node1 = null;
                TreeNode node2 = null;
                TreeNode node3 = null;
                TreeNode node4 = null;
                TreeNode node5 = null;
                TreeNode node6 = null;

                //Primeiro Node Adicionado - Cargos/Ministério
                #region Adiciona o Primeiro Node - Cargos

                try
                {
                            BLL_cargo objBLL_Cargo = new BLL_cargo();
                            List<MOD_cargo> listaCargoRegiao = new List<MOD_cargo>();

                            //busca as pessoas de acordo com os dados do usuario
                            listaCargo = objBLL_Cargo.buscarDescricao(string.Empty);
                            listaCargoRegiao = listaCargo.Where(c => Convert.ToInt32(c.CodDepartamento).Equals(2) && c.AtendeRegiao.Equals("Sim")).OrderBy(c => c.Ordem).ToList();
                            //listaCargoRegiao = listaCargoRegiao.OrderBy(c => c.Ordem).ToList();

                            //faz um loop na lista PessoaCargo para inserir o Node1
                            foreach (MOD_cargo entNode1 in listaCargoRegiao)
                            {
                                //aqui é criado um novo node para receber a descrição
                                //das Pessoas
                                node1 = new TreeNode();
                                //é preenchido o propriedade tag com o código do módulo
                                node1.Tag = entNode1.CodCargo;
                                //é preenchido a propriedade Text com a descrição do módulo;
                                node1.Text = entNode1.DescCargo;
                                //Altera a cor do Nod
                                node1.ForeColor = Color.DarkGreen;

                                //aqui é adicionado o node ao TreeView.
                                tvwDados.Nodes.Add(node1);

                        #endregion

                        //Segundo Nó Segundo é a Microrregião
                        #region Adiciona o Segundo Node - Microrregião

                        try
                        {
                    objBLL_Usuario = new BLL_usuario();
                    listaUsuarioReg = new BindingList<MOD_usuarioRegiao>();
                    //busca as regiões de acordo com as permissões de usuarios
                    listaUsuarioReg = objBLL_Usuario.buscarUsuarioRegiao(modulos.CodUsuario);

                    //faz um loop na lista PessoaCargo para inserir o Node1
                    foreach (MOD_usuarioRegiao entNodeRegiao in listaUsuarioReg)
                    {
                        //aqui é criado um novo node para receber as regiões
                        nodeRegiao = new TreeNode();
                        //é preenchido o propriedade tag com o código da região
                        nodeRegiao.Tag = entNodeRegiao.CodRegiao;
                        //é preenchido a propriedade Text com a descrição
                        nodeRegiao.Text = entNodeRegiao.CodigoRegiao + " - " + entNodeRegiao.DescRegiao;
                        //Altera a cor do Nod
                        nodeRegiao.ForeColor = Color.DarkRed;

                        //aqui é adicionado o node ao TreeView.
                        tvwDados.Nodes[node1.Index].Nodes.Add(nodeRegiao);

                        #endregion

                                //Terceiro node adicionado - Irmãos de Acordo com o Cargo
                                #region Adiciona o terceiro node - Irmãos de Acordo com o Cargo

                                try
                                {
                                    objBLL_Pessoa = new BLL_pessoa();
                                    listaPessoa = new List<MOD_pessoa>();

                                    List<MOD_pessoa> listaRegiaoPessoa = new List<MOD_pessoa>();
                                    List<MOD_pessoa> listaPessoaCargo = new List<MOD_pessoa>();
                                    //busca as pessoas de acordo com os dados do usuario
                                    //listaPessoaCargo = objBLL_Pessoa.buscarCargo(entNode1.CodCargo, modulos.CodUsuarioCCB, modulos.CodUsuarioCargo, true);
                                    listaRegiaoPessoa = objBLL_Pessoa.buscarPesRegiao(entNodeRegiao.CodRegiao, modulos.CodUsuarioCCB, modulos.CodUsuarioCargo, true);
                                    listaPessoaCargo = listaRegiaoPessoa.Where(p => p.CodCargo.Equals(entNode1.CodCargo)).ToList();

                                    //faz um loop na lista PessoaCargo para inserir o Node1
                                    foreach (MOD_pessoa entNode2 in listaPessoaCargo)
                                    {
                                        //aqui é criado um novo node para receber a descrição
                                        //das Pessoas
                                        node2 = new TreeNode();
                                        //é preenchido o propriedade tag com o código do módulo
                                        node2.Tag = entNode2.CodPessoa;
                                        //é preenchido a propriedade Text com a descrição do módulo;
                                        node2.Text = entNode2.Nome;
                                        //aqui é adicionado o node ao TreeView.
                                        tvwDados.Nodes[node1.Index].Nodes[nodeRegiao.Index].Nodes.Add(node2);

                                        #endregion

                                        //Quarto Node Adicionado - Comum Congregação
                                        #region Adiciona o quarto node - Comum Congregação

                                        try
                                        {
                                            BindingList<MOD_ccbPessoa> listaCcbPessoa = new BindingList<MOD_ccbPessoa>();
                                            //busca as comuns que essa pessoa atende
                                            listaCcbPessoa = objBLL_Pessoa.buscarCCBPessoa(entNode2.CodPessoa, entNodeRegiao.CodRegiao);

                                            //é feito um loop para adicionar as comuns ao nod2
                                            foreach (MOD_ccbPessoa entNode3 in listaCcbPessoa)
                                            {
                                                //aqui é criado um novo node para receber a descrição
                                                //dos SubModulo recebidos do banco de dados
                                                node3 = new TreeNode();
                                                //é preenchido o propriedade tag com o código do SubModulo
                                                node3.Tag = entNode3.CodCCB;
                                                //é preenchido a propriedade Text com a descrição do SubModulo;
                                                node3.Text = entNode3.Codigo + " - " + entNode3.Descricao;

                                                //aqui é adicionado o node ao TreeView.
                                                this.tvwDados.Nodes[node1.Index].Nodes[nodeRegiao.Index].Nodes[node2.Index].Nodes.Add(node3);

                                                #endregion

                                                //Quinto Node Adicionado - Cargos por Sexo (Masculino e Feminino)
                                                #region Adiciona o quinto node - Filtra Cargos por Sexo (Masculino e Feminino)

                                                try
                                                {
                                                    ////aqui é feito uma busca no banco para preencher todas as pessoas 
                                                    ////que fazem parte dessa comum congregação.
                                                    //objBLL_Pessoa = new BLL_pessoa();
                                                    //listaPessoa = objBLL_Pessoa.buscarComum(entNode2.CodCCB);

                                                    if (entNode2.Sexo.Equals("Masculino"))
                                                    {
                                                        List<MOD_cargo> listaNode4 = new List<MOD_cargo>();
                                                        listaNode4 = listaCargo.Where(c => c.Masculino.Equals("Sim") && Convert.ToInt32(c.CodDepartamento).Equals(2)).OrderBy(c => c.Ordem).ToList();

                                                        //é feito um loop para adicionar os Irmãos
                                                        foreach (MOD_cargo entNode4 in listaNode4)
                                                        {
                                                            //Caso seja o mesmo cargo informado acima, não insere e pula para o proximo registro
                                                            if (!entNode4.CodCargo.Equals(entNode1.CodCargo))
                                                            {
                                                                //aqui é criado um novo node para receber a descrição
                                                                //dos SubModulo recebidos do banco de dados
                                                                node4 = new TreeNode();
                                                                //é preenchido o propriedade tag com o código do SubModulo
                                                                node4.Tag = entNode4.CodCargo;
                                                                //é preenchido a propriedade Text com a descrição do SubModulo;
                                                                node4.Text = entNode4.DescCargo;

                                                                //aqui é adicionado o node ao TreeView.
                                                                this.tvwDados.Nodes[node1.Index].Nodes[nodeRegiao.Index].Nodes[node2.Index].Nodes[node3.Index].Nodes.Add(node4);

                                                                #endregion

                                                                //Sexto Node Adicionado - Pessoas adicionados de acordo com as comuns congregações e aos cargos
                                                                #region Adiciona o sexto node - Pessoas adicionados de acordo com as comuns congregações e aos cargos
                                                                try
                                                                {
                                                                    objBLL_Pessoa = new BLL_pessoa();
                                                                    List<MOD_pessoa> listaNode5 = new List<MOD_pessoa>();
                                                                    listaNode5 = objBLL_Pessoa.buscarComum(entNode3.CodCCB);
                                                                    listaNode5 = listaNode5.Where(p => p.CodCargo.Equals(entNode4.CodCargo)).ToList();

                                                                    listaNode5 = listaNode5.Where(c => c.Sexo.Equals("Masculino")).OrderBy(c => c.Nome).ToList();

                                                                    //é feito um loop para adicionar os Irmãos
                                                                    foreach (MOD_pessoa entNode5 in listaNode5)
                                                                    {
                                                                        //aqui é criado um novo node para receber a descrição
                                                                        //dos SubModulo recebidos do banco de dados
                                                                        node5 = new TreeNode();
                                                                        //é preenchido o propriedade tag com o código do SubModulo
                                                                        node5.Tag = entNode5.CodPessoa;
                                                                        //é preenchido a propriedade Text com a descrição do SubModulo;
                                                                        node5.Text = entNode5.Nome;

                                                                        //aqui é adicionado o node ao TreeView.
                                                                        this.tvwDados.Nodes[node1.Index].Nodes[nodeRegiao.Index].Nodes[node2.Index].Nodes[node3.Index].Nodes[node4.Index].Nodes.Add(node5);

                                                                        #endregion
                                                                    }
                                                                }
                                                                //tratamento de erro dos cargos
                                                                catch (SqlException exl)
                                                                {
                                                                    throw exl;
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    throw ex;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
#warning Preenchimento das Irmãs
                                                        List<MOD_cargo> listaNode4 = new List<MOD_cargo>();
                                                        listaNode4 = listaCargo.Where(c => c.Feminino.Equals("Sim") && Convert.ToInt32(c.CodDepartamento).Equals(2)).OrderBy(c => c.Ordem).ToList();

                                                        //é feito um loop para adicionar os Irmãos
                                                        foreach (MOD_cargo entNode4 in listaNode4)
                                                        {
                                                            //Caso seja o mesmo cargo informado acima, não insere e pula para o proximo registro
                                                            if (!entNode4.CodCargo.Equals(entNode1.CodCargo))
                                                            {
                                                                //aqui é criado um novo node para receber a descrição
                                                                //dos SubModulo recebidos do banco de dados
                                                                node4 = new TreeNode();
                                                                //é preenchido o propriedade tag com o código do SubModulo
                                                                node4.Tag = entNode4.CodCargo;
                                                                //é preenchido a propriedade Text com a descrição do SubModulo;
                                                                node4.Text = entNode4.DescCargo;

                                                                //aqui é adicionado o node ao TreeView.
                                                                this.tvwDados.Nodes[node1.Index].Nodes[nodeRegiao.Index].Nodes[node2.Index].Nodes[node3.Index].Nodes.Add(node4);

                                                                #endregion

                                                                #region Adiciona o quinto nó

                                                                try
                                                                {
                                                                    objBLL_Pessoa = new BLL_pessoa();
                                                                    List<MOD_pessoa> listaNode5 = new List<MOD_pessoa>();
                                                                    listaNode5 = objBLL_Pessoa.buscarComum(entNode3.CodCCB);
                                                                    listaNode5 = listaNode5.Where(p => p.CodCargo.Equals(entNode4.CodCargo)).ToList();

                                                                    listaNode5 = listaNode5.Where(c => c.Sexo.Equals("Feminino")).OrderBy(c => c.Nome).ToList();

                                                                    //é feito um loop para adicionar os Irmãos
                                                                    foreach (MOD_pessoa entNode5 in listaNode5)
                                                                    {
                                                                        //aqui é criado um novo node para receber a descrição
                                                                        //dos SubModulo recebidos do banco de dados
                                                                        node5 = new TreeNode();
                                                                        //é preenchido o propriedade tag com o código do SubModulo
                                                                        node5.Tag = entNode5.CodPessoa;
                                                                        //é preenchido a propriedade Text com a descrição do SubModulo;
                                                                        node5.Text = entNode5.Nome;

                                                                        //aqui é adicionado o node ao TreeView.
                                                                        this.tvwDados.Nodes[node1.Index].Nodes[nodeRegiao.Index].Nodes[node2.Index].Nodes[node3.Index].Nodes[node4.Index].Nodes.Add(node5);

                                                                        #endregion
                                                                    }
                                                                }
                                                                //tratamento de erro dos cargos
                                                                catch (SqlException exl)
                                                                {
                                                                    throw exl;
                                                                }
                                                                catch (Exception ex)
                                                                {
                                                                    throw ex;
                                                                }
                                                            }
                                                        }

                                                    }
                                                }
                                                //tratamento de erro dos cargos
                                                catch (SqlException exl)
                                                {
                                                    throw exl;
                                                }
                                                catch (Exception ex)
                                                {
                                                    throw ex;
                                                }
                                            }
                                        }
                                        //tratamento de erro dos programas
                                        catch (SqlException exl)
                                        {
                                            throw exl;
                                        }
                                        catch (Exception ex)
                                        {
                                            throw ex;
                                        }
                                    }
                                }
                                //tratamento de erro dos sub-módulos
                                catch (SqlException exl)
                                {
                                    throw exl;
                                }
                                catch (Exception ex)
                                {
                                    throw ex;
                                }
                            }
                        }
                        //tratamento de erro dos módulos
                        catch (SqlException exl)
                        {
                            throw exl;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
                //tratamento de erro dos módulos
                catch (SqlException exl)
                {
                    throw exl;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }

        #endregion


    }
}
