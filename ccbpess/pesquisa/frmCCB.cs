using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ENT.uteis;
using BLL.uteis;
using BLL.Funcoes;
using System.Data.SqlClient;
using ENT.Erros;
using BLL.pessoa;
using ENT.pessoa;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using Microsoft.VisualBasic;

namespace ccbpess.pesquisa
{
    public partial class frmCCB : Form
    {
        public frmCCB(Form forms, DataGridView gridPesquisa, List<MOD_ccb> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                //carregando a lista de permissões de acesso.
                listaAcesso = modulos.listaLibAcesso;

                ///Recebe a lista e armazena
                listaCCB = lista;

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
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
        }

        #region declaracoes

        string CodCCBPessoa;
        int IndiceCCB;

        clsException excp;

        List<MOD_acessos> listaAcesso = null;

        BLL_pessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaMinisterio = null;

        BLL_ccb objBLL = null;
        MOD_ccb objEnt = null;
        List<MOD_ccb> listaCCB = null;

        BLL_regiaoAtuacao objBLL_Regiao = null;
        List<MOD_regiaoAtuacao> listaRegiao = null;

        BLL_cidade objBLL_Cid = null;
        List<MOD_cidade> listaCidade = null;

        BindingList<MOD_ccbPessoa> listaCCBPessoa = new BindingList<MOD_ccbPessoa>();
        List<MOD_ccbPessoa> listaDeleteCCBPessoa = new List<MOD_ccbPessoa>();

        BindingSource objBinding_CCB = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        #endregion

        #region eventos do formulario

        #region Aba Geral

        private void txtCodRegiao_Leave(object sender, EventArgs e)
        {
            if (!txtCodRegiao.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaRegiao(txtCodRegiao.Text);
                }
                catch (SqlException exl)
                {
                    excp = new clsException(exl);
                }
                catch (Exception ex)
                {
                    excp = new clsException(ex);
                }
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmReg");
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void btnCep_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCid");
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void txtCep_Leave(object sender, EventArgs e)
        {
            if (!txtCep.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaCep(txtCep.Text);
                }
                catch (SqlException exl)
                {
                    excp = new clsException(exl);
                }
                catch (Exception ex)
                {
                    excp = new clsException(ex);
                }
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }

        private void optSitAberta_Click(object sender, EventArgs e)
        {
            try
            {
                if (optSitAberta.Checked.Equals(true))
                {
                    lblSituacao.Text = "Aberta";
                }
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
        private void optSitConstrucao_Click(object sender, EventArgs e)
        {
            try
            {
                if (optSitConstrucao.Checked.Equals(true))
                {
                    lblSituacao.Text = "Em Construção";
                }
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
        private void optSitReforma_Click(object sender, EventArgs e)
        {
            try
            {
                if (optSitReforma.Checked.Equals(true))
                {
                    lblSituacao.Text = "Em Reforma";
                }
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
        private void optSitFechada_Click(object sender, EventArgs e)
        {
            try
            {
                if (optSitFechada.Checked.Equals(true))
                {
                    lblSituacao.Text = "Fechada";
                }
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

        #endregion

        #region Aba Ministerio

        private void gridMinisterio_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermAlteraMinist();
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
        private void gridMinisterio_SelectionChanged(object sender, EventArgs e)
        {
            if (gridMinisterio != null && gridMinisterio.RowCount > 0)
            {
                CodCCBPessoa = Convert.ToString(gridMinisterio[1, gridMinisterio.CurrentRow.Index].Value);
            }
        }

        private void txtPessoa_Leave(object sender, EventArgs e)
        {
            if (!txtPessoa.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaCCBPessoa(txtPessoa.Text);
                }
                catch (SqlException exl)
                {
                    excp = new clsException(exl);
                }
                catch (Exception ex)
                {
                    excp = new clsException(ex);
                }
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes");
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }

        private void btnSalvarItem_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                InserirCCBPessoa();
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguardeGravar();
            }
        }
        private void btnCancelarItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Limpa os controle e desabilita
                LimparCCBPessoa();
                disabledCCBPessoa();
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
        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                LimparCCBPessoa();
                enabledCCBPessoa();
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
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteCCBPessoa(gridMinisterio.CurrentRow.Index);
                disabledCCBPessoa();
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

        #endregion

        #region Eventos do Formulario

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvar();
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguardeGravar();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
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
        private void frmCCB_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                tabGeral.Enabled = true;
                tabMinisterio.Enabled = false;
                verPermMinisterio();
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
        private void frmCCB_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Comum"))
                {
                    e.Cancel = false;
                }
                else
                {
                    DialogResult sair;
                    sair = MessageBox.Show(modulos.msgSalvar, "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (sair.Equals(DialogResult.Yes))
                    {
                        salvar();
                    }
                    else if (sair.Equals(DialogResult.Cancel))
                    {
                        e.Cancel = true;
                    }
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
        }
        private void frmCCB_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void tabCCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabCCB.SelectedIndex.Equals(1))
            {
                if (listaMinisterio == null || listaMinisterio.Count < 1)
                {
                    try
                    {
                        apoio.Aguarde();
                        carregaCCBPessoa(txtCodigo.Text);
                    }
                    catch (SqlException exl)
                    {
                        excp = new clsException(exl);
                    }
                    catch (Exception ex)
                    {
                        excp = new clsException(ex);
                    }
                    finally
                    {
                        apoio.FecharAguarde();
                    }
                }
            }
        }

        #endregion

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    objBLL = new BLL_ccb();

                    if (Convert.ToInt32(txtCodigo.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.inserir(criarTabela());
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.salvar(criarTabela());
                    }

                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmCCBBusca"))
                    {
                        ((frmCCBBusca)formChama).carregaGrid("CCB", objEnt.CodCCB, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmCCB_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmCCB_FormClosing);

                }
            }
            catch (ArgumentException ae)
            {
                throw new Exception(ae.Message);
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
        /// <summary>
        /// Função que valida os campos
        /// </summary>
        private bool ValidarControles()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (txtCodigoCCB.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Identificador! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtComum.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nome da Comum! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblDescricaoRegiao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Região! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblCidade.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Cep! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtEndereco.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Endereço! Campo importante, para remessa de documentos.";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtNum.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Número! Campo importante, para remessa de documentos.";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtBairro.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Bairro! Campo importante, para remessa de documentos.";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtTel.Text.Equals(string.Empty) && txtCel.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Telefone ou Celular! Campo importante para contato.";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtEmail.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É aconselhável informar o e-mail, é uma ótima forma de contato.";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }

                //chama o formulário para gerar os erros
                if (blnValida.Equals(false))
                {
                    blnRetorno = apoio.AbrirErros(listaErros, this);
                }
                return blnRetorno;
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
        /// <summary>
        /// Funcão que valida o CNPJ digitado, caso tenha outra Comum
        /// cadastrado com esse CNPJ retorna o cadastro para edição
        /// </summary>
        private void ValidarCnpj()
        {
            try
            {
                objBLL = new BLL_ccb();
                List<MOD_ccb> listaValidaCnpj = new List<MOD_ccb>();
                listaValidaCnpj = objBLL.buscarCnpj(txtCnpj.Text);

                if (listaValidaCnpj.Count > 0)
                {
                    if (!Convert.ToInt64(listaValidaCnpj[0].CodCCB).Equals(Convert.ToInt64(this.txtCodigo.Text)))
                    {
                        if (MessageBox.Show("Pessoa já cadastrada!" + "\n" +
                                            "Código: " + listaValidaCnpj[0].CodCCB + Constants.vbCrLf +
                                            "Identificador: " + listaValidaCnpj[0].Codigo + Constants.vbCrLf +
                                            "Nome Comum: " + listaValidaCnpj[0].Descricao + Constants.vbCrLf + Constants.vbCrLf +
                                            "Deseja editar essa Comum?",
                                            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            preencher(listaValidaCnpj);
                            enabledForm();
                        }
                        else
                        {
                            txtCnpj.Focus();
                            txtCnpj.SelectAll();
                        }
                    }
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
        }
        /// <summary>
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_ccb criarTabela()
        {
            try
            {
                objEnt = new MOD_ccb();
                objEnt.CodCCB = txtCodigo.Text;
                objEnt.Codigo = txtCodigoCCB.Text;
                objEnt.Descricao = txtComum.Text;
                objEnt.Endereco = txtEndereco.Text;
                objEnt.Numero = txtNum.Text;
                objEnt.Bairro = txtBairro.Text;
                objEnt.Complemento = txtComp.Text;
                objEnt.CodCidade = txtCodCidade.Text;
                objEnt.Telefone = txtTel.Text;
                objEnt.Celular = txtCel.Text;
                objEnt.Email = txtEmail.Text;
                objEnt.CNPJ = txtCnpj.Text;
                objEnt.DataAbertura = txtDataAbertura.Text;
                objEnt.Skype = txtSkype.Text;
                //objEnt.CaminhoBD = txtCaminhoBD.Text;
                objEnt.Situacao = lblSituacao.Text;
                objEnt.CodRegiao = txtCodRegiao.Text;

                //retorna o objeto CCB Pessoa
                if (listaCCBPessoa != null)
                {
                    objEnt.listaCCBPessoa = listaCCBPessoa;
                }

                //retorna o objeto CCBPessoa
                if (listaCCBPessoa != null || listaDeleteCCBPessoa != null)
                {
                    objEnt.listaCCBPessoa = listaCCBPessoa;
                    objEnt.listaDeleteCCBPessoa = listaDeleteCCBPessoa;
                }

                //retorna a classe de propriedades preenchida com os textbox
                return objEnt;
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

        /// <summary>
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaPessoa"></param>
        internal void preencher(List<MOD_ccb> listaCom)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaCom[0].CodCCB;
                txtCodigoCCB.Text = listaCom[0].Codigo;
                txtComum.Text = listaCom[0].Descricao;
                txtEndereco.Text = listaCom[0].Endereco;
                txtNum.Text = listaCom[0].Numero;
                txtBairro.Text = listaCom[0].Bairro;
                txtComp.Text = listaCom[0].Complemento;
                txtCep.Text = listaCom[0].Cep;
                txtEstado.Text = listaCom[0].Estado;
                txtCodCidade.Text = listaCom[0].CodCidade;
                lblCidade.Text = listaCom[0].Cidade;
                txtTel.Text = listaCom[0].Telefone;
                txtCel.Text = listaCom[0].Celular;
                txtEmail.Text = listaCom[0].Email;
                txtCnpj.Text = listaCom[0].CNPJ;
                txtDataAbertura.Text = listaCom[0].DataAbertura;
                txtSkype.Text = listaCom[0].Skype;
                lblSituacao.Text = listaCom[0].Situacao;
                txtCodRegiao.Text = listaCom[0].CodRegiao;
                lblDescricaoRegiao.Text = listaCom[0].CodigoRegiao + " - " + listaCom[0].DescricaoRegiao;
                lblDescricaoRegional.Text = listaCom[0].DescricaoRegional;

                ///verificações para preenchimento de radiobuttons
                verificacoes();

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

        /// <summary>
        /// Função que carrega os dados do Cep pesquisado
        /// </summary>
        /// <param name="vCep"></param>
        internal void carregaCep(string vCep)
        {
            try
            {
                objBLL_Cid = new BLL_cidade();
                listaCidade = objBLL_Cid.buscarCep(vCep);

                if (listaCidade.Count > 0)
                {
                    txtCep.Text = listaCidade[0].Cep;
                    txtEstado.Text = listaCidade[0].Estado;
                    txtCodCidade.Text = listaCidade[0].CodCidade;
                    lblCidade.Text = listaCidade[0].Cidade;
                    txtEndereco.Text = string.IsNullOrEmpty(listaCidade[0].Endereco) ? null : listaCidade[0].Tipo + " " + listaCidade[0].Endereco;
                    txtBairro.Text = listaCidade[0].Bairro;
                }
                else
                {
                    abrirForm("frmCid");
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
        }
        /// <summary>
        /// Função que carrega a Região pesquisado pelo Código
        /// </summary>
        /// <param name="vCodRegiao"></param>
        internal void carregaRegiao(string vCodRegiao)
        {
            try
            {
                objBLL_Regiao = new BLL_regiaoAtuacao();
                listaRegiao = objBLL_Regiao.buscarCod(vCodRegiao);

                if (listaRegiao != null && listaRegiao.Count > 0)
                {
                    txtCodRegiao.Text = listaRegiao[0].CodRegiao;
                    lblDescricaoRegiao.Text = listaRegiao[0].Codigo + " - " + listaRegiao[0].DescRegiao;
                    lblDescricaoRegional.Text = listaRegiao[0].DescricaoRegional;
                }
                else
                {
                    abrirForm("frmReg");
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
        }

        /// <summary>
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa"></param>
        internal void carregaPessoa(string vCodPessoa, string Campo)
        {
            try
            {
                BLL_pessoa objBLL_Pessoa = new BLL_pessoa();
                List<MOD_pessoa> listaPes = new List<MOD_pessoa>();
                List<MOD_pessoa> listaPesFiltro = new List<MOD_pessoa>();

                listaPes = objBLL_Pessoa.buscarCod(vCodPessoa, modulos.CodUsuarioCCB, modulos.CodUsuarioCargo);
                listaPesFiltro = listaPes.Where(x => Convert.ToInt16(x.CodCargo).Equals(8)).ToList();

                if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                {
                    if (listaPesFiltro[0].Ativo.Equals("Sim"))
                    {
                        txtPessoa.Text = listaPesFiltro[0].CodPessoa;
                        lblPessoa.Text = listaPesFiltro[0].Nome;
                        txtMinisterio.Text = listaPesFiltro[0].DescCargo;
                        txtDataApresentacao.Text = listaPesFiltro[0].DataApresentacao;
                    }
                    else
                    {
                        txtPessoa.Text = string.Empty;
                        lblPessoa.Text = string.Empty;
                        txtMinisterio.Text = string.Empty;
                        txtDataApresentacao.Text = string.Empty;
                        txtPessoa.Focus();
                        throw new Exception("Essa pessoa está inativa!" + "\n" + "Para utilizar deverá ativar o cadastro." +
                                            "\n" + "\n" + "Pessoas >> Aba Adicionais >> Pessoa Ativa.");
                    }
                }
                else
                {
                    abrirForm("frmPes");
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
        }

        /// <summary>
        /// Função que abre os formulários de pesquisa
        /// </summary>
        /// <param name="form"></param>
        private void abrirForm(string form)
        {
            try
            {
                if (form.Equals("frmCid"))
                {
                    txtCep.Text = string.Empty;
                    txtEstado.Text = string.Empty;
                    txtCodCidade.Text = string.Empty;
                    lblCidade.Text = string.Empty;
                    txtEndereco.Text = string.Empty;
                    txtBairro.Text = string.Empty;

                    formulario = new frmPesquisaCidade(this, string.Empty);
                    ((frmPesquisaCidade)formulario).MdiParent = MdiParent;
                    ((frmPesquisaCidade)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaCidade)formulario));
                    ((frmPesquisaCidade)formulario).Show();
                    ((frmPesquisaCidade)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmReg"))
                {
                    txtCodRegiao.Text = string.Empty;
                    lblDescricaoRegiao.Text = string.Empty;
                    lblDescricaoRegional.Text = string.Empty;

                    formulario = new frmPesquisaRegiao(this);
                    ((frmPesquisaRegiao)formulario).MdiParent = MdiParent;
                    ((frmPesquisaRegiao)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaRegiao)formulario));
                    ((frmPesquisaRegiao)formulario).Show();
                    ((frmPesquisaRegiao)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmPes"))
                {
                    txtCodRegiao.Text = string.Empty;
                    lblDescricaoRegiao.Text = string.Empty;
                    lblDescricaoRegional.Text = string.Empty;

                    formulario = new frmPesquisaPessoa(this, string.Empty);
                    ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                    ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                    ((frmPesquisaPessoa)formulario).Show();
                    ((frmPesquisaPessoa)formulario).BringToFront();
                    Enabled = false;
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
        }

        /// <summary>
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                tabGeral.Enabled = false;
                tabMinisterio.Enabled = false;
                btnSalvar.Enabled = false;
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
        /// <summary>
        /// Função que habilita os controles
        /// </summary>
        internal void enabledForm()
        {
            try
            {
                tabGeral.Enabled = true;
                tabMinisterio.Enabled = true;
                btnSalvar.Enabled = true;
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
        /// <summary>
        /// Função que verifica os valores e marca as Opções
        /// </summary>
        internal void verificacoes()
        {
            try
            {
                ///verifica o sexo
                if (lblSituacao.Text.Equals("Aberta"))
                {
                    optSitAberta.Checked = true;
                }
                else if (lblSituacao.Text.Equals("Fechada"))
                {
                    optSitFechada.Checked = true;
                }
                else if (lblSituacao.Text.Equals("Em Construção"))
                {
                    optSitConstrucao.Checked = true;
                }
                else if (lblSituacao.Text.Equals("Em Reforma"))
                {
                    optSitReforma.Checked = true;
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
        }

        /// <summary>
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            txtCodigoCCB.Focus();
        }


        #region Grid CCBPessoa

        /// <summary>
        /// Função que monta o GridView do Ministério - Aba Ministério
        /// </summary>
        private void montaGridCCBPessoa()
        {
            try
            {
                gridMinisterio.AutoGenerateColumns = false;
                gridMinisterio.DataSource = null;
                gridMinisterio.Columns.Clear();
                gridMinisterio.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodPessoa = new DataGridViewTextBoxColumn();
                colCodPessoa.DataPropertyName = "CodPessoa";
                colCodPessoa.HeaderText = "Código";
                colCodPessoa.Name = "CodPessoa";
                colCodPessoa.Width = 100;
                colCodPessoa.Frozen = false;
                colCodPessoa.MinimumWidth = 100;
                colCodPessoa.ReadOnly = true;
                colCodPessoa.FillWeight = 100;
                colCodPessoa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodPessoa.MaxInputLength = 20;
                colCodPessoa.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Nome";
                colDescricao.HeaderText = "Nome do Irmão ou Irmã";
                colDescricao.Name = "Nome";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 170;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 255;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colMinist = new DataGridViewTextBoxColumn();
                colMinist.DataPropertyName = "DescCargo";
                colMinist.HeaderText = "Ministério/Cargo";
                colMinist.Name = "DescCargo";
                colMinist.Width = 150;
                colMinist.Frozen = false;
                colMinist.MinimumWidth = 80;
                colMinist.ReadOnly = true;
                colMinist.FillWeight = 170;
                colMinist.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colMinist.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMinist.MaxInputLength = 255;
                colMinist.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colApres = new DataGridViewTextBoxColumn();
                colApres.DataPropertyName = "DataApresentacao";
                colApres.HeaderText = "Data Apresentação";
                colApres.Name = "DataApresentacao";
                colApres.Width = 150;
                colApres.Frozen = false;
                colApres.MinimumWidth = 80;
                colApres.ReadOnly = true;
                colApres.FillWeight = 170;
                colApres.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colApres.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colApres.MaxInputLength = 255;
                colApres.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                gridMinisterio.Columns.Add(colMinist);
                gridMinisterio.Columns.Add(colCodPessoa);
                gridMinisterio.Columns.Add(colDescricao);
                gridMinisterio.Columns.Add(colApres);
                ///feito um refresh para fazer a atualização do datagridview
                gridMinisterio.Refresh();
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
        /// <summary>
        /// Função que carrega o Ministerio da Comum
        /// </summary>
        /// <param name="CodCCB"></param>
        private void carregaCCBPessoa(string CodCCB)
        {
            try
            {
                objBLL_Pessoa = new BLL_pessoa();
                objBinding_CCB = new BindingSource();
                listaCCBPessoa = objBLL_Pessoa.buscarPesCCB(CodCCB);

                objBinding_CCB.DataSource = listaCCBPessoa;

                montaGridCCBPessoa();
                ///vincula a lista ao DataSource do DataGriView
                gridMinisterio.DataSource = objBinding_CCB;
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

        /// <summary>
        /// Função que valida os campos
        /// </summary>
        private bool ValidarControlesMinist()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (lblPessoa.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Irmão ou Irmã! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                //chama o formulário para gerar os erros
                if (blnValida.Equals(false))
                {
                    blnRetorno = apoio.AbrirErros(listaErros, this);
                }
                return blnRetorno;
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

        /// <summary>
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void InserirCCBPessoa()
        {
            try
            {
                if (ValidarControlesMinist().Equals(true))
                {
                    MOD_ccbPessoa ent = new MOD_ccbPessoa();
                    ent.CodCCBPessoa = "0";
                    ent.CodPessoa = txtPessoa.Text;
                    ent.CodCCB = txtCodigo.Text;
                    ent.Nome = lblPessoa.Text;
                    ent.DescCargo = txtMinisterio.Text;
                    ent.DataApresentacao = txtDataApresentacao.Text;

                    listaCCBPessoa = ((BindingList<MOD_ccbPessoa>)objBinding_CCB.DataSource);
                    //adiciona um novo item a lista
                    listaCCBPessoa.Add(ent);
                    //atualiza o datagridview
                    listaCCBPessoa.ResetItem(gridMinisterio.RowCount - 1);

                    //Limpa os controle e desabilita
                    LimparCCBPessoa();
                    disabledCCBPessoa();
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
        }
        /// <summary>
        /// Função que Deleta a linha selecionada no GridMinisterio
        /// </summary>
        private void DeleteCCBPessoa(int Indice)
        {
            try
            {
                MOD_ccbPessoa ent = new MOD_ccbPessoa();
                ent.CodCCBPessoa = CodCCBPessoa;

                //Insere a linha na Lista Delete
                listaDeleteCCBPessoa.Add(ent);
                //Exclui a linha da lista
                listaCCBPessoa.RemoveAt(Indice);

                //Seleciona a linha anterior a excluida
                if (gridMinisterio.RowCount > 0)
                {
                    if (!gridMinisterio.Rows[0].Selected.Equals(true))
                    {
                        gridMinisterio.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridMinisterio.Rows[gridMinisterio.RowCount - 1].Selected = true;
                    }
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
        }
        /// <summary>
        /// Função que limpa os controle para Inserir nova CCBPessoa
        /// </summary>
        private void LimparCCBPessoa()
        {
            try
            {
                txtPessoa.Text = string.Empty;
                lblPessoa.Text = string.Empty;
                txtMinisterio.Text = string.Empty;
                txtDataApresentacao.Text = string.Empty;
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
        /// <summary>
        /// Função que habilita os controles da Foto
        /// </summary>
        internal void enabledCCBPessoa()
        {
            try
            {
                gpoMinisterio.Enabled = true;
                btnSalvarItem.Enabled = true;
                lblPessoa.Enabled = true;
                lbPessoa.Enabled = true;
                txtPessoa.Enabled = true;
                btnPessoa.Enabled = true;
                btnInserir.Enabled = false;
                btnExcluir.Enabled = false;
                gridMinisterio.Enabled = false;
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
        /// <summary>
        /// Função que habilita os controles da Foto
        /// </summary>
        internal void disabledCCBPessoa()
        {
            try
            {
                gpoMinisterio.Enabled = false;
                //btnFotoSalvar.Enabled = false;
                //btnTeoria.Enabled = false;
                gridMinisterio.Enabled = true;
                verPermAlteraMinist();
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

        #endregion

        #region verificação e liberação de acesso

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermMinisterio()
        {
            try
            {
                MOD_acessoCcb entAcesso = new MOD_acessoCcb();
                tabMinisterio.Enabled = funcoes.liberacoes(entAcesso.rotCCBAbaMinist);
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

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermAlteraMinist()
        {
            try
            {
                MOD_acessoCcb entAcesso = new MOD_acessoCcb();
                btnInserir.Enabled = funcoes.liberacoes(entAcesso.rotInsCCBMinist);
                btnExcluir.Enabled = funcoes.liberacoes(entAcesso.rotExcCCBMinist, dataGrid);
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
        #endregion

        #endregion

    }
}
