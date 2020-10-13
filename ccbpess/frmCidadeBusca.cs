using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.uteis;

namespace ccbpess
{
    public partial class frmCidadeBusca : Form
    {
        public frmCidadeBusca(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;

                ///preenche o comboEstado
                apoio.carregaComboEstado(cboEstado);
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
        
        #region declarações

        //variaveis
        string Codigo;
        string Descricao;
        string Cep;

        BLL_cidade objBLL = null;
        MOD_cidade objEnt = null;
        List<MOD_cidade> lista;

        List<MOD_acessos> listaAcesso = null;

        Form formulario;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPesq;
        }
        private void txtCep_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPesq;
        }
        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCep.Text.Length > 0)
                {
                    lblUf.Enabled = false;
                    cboEstado.Enabled = false;
                    lblCidade.Enabled = false;
                    txtCidade.Enabled = false;
                }
                else
                {
                    lblUf.Enabled = true;
                    cboEstado.Enabled = true;
                    lblCidade.Enabled = true;
                    txtCidade.Enabled = true;
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
        private void cboEstado_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPesq;
        }
        private void btnPesq_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();

                if (string.IsNullOrEmpty(txtCep.Text))
                {
                    if (string.IsNullOrEmpty(cboEstado.Text))
                    {
                        throw new Exception("Selecione o Estado para efetuar a busca!");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txtCidade.Text))
                        {
                            if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                carregaGrid(string.Empty, txtCidade.Text, cboEstado.Text, string.Empty, txtEndereco.Text, txtBairro.Text);
                            }
                        }
                        else
                        {
                            carregaGrid(string.Empty, txtCidade.Text, cboEstado.Text, string.Empty, txtEndereco.Text, txtBairro.Text);
                        }
                    }
                }
                else
                {
                    carregaGrid("Cep", string.Empty, string.Empty, txtCep.Text, string.Empty, string.Empty);
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void btnVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCidade[0, gridCidade.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCidade);
                ((frmCidade)formulario).Text = "Visualizando Cidade";
                ((frmCidade)formulario).disabledForm();
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
        private void btnIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridCidade);
                ((frmCidade)formulario).Text = "Inserindo Cidade";
                ((frmCidade)formulario).enabledForm();
                ((frmCidade)formulario).defineFoco();
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCidade[0, gridCidade.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCidade);
                ((frmCidade)formulario).Text = "Editando Cidade";
                ((frmCidade)formulario).enabledForm();
                ((frmCidade)formulario).defineFoco();
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
        private void btnExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridCidade[0, gridCidade.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.excluir(criarTabela());

                    gridCidade.DataSource = null;
                    funcoes.gridCidade(gridCidade);
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
                    apoio.FecharAguardeExcluir();
                }
            }
            else
            {
                txtCidade.Focus();
            }
        }
        private void gridCidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridCidade[0, gridCidade.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCidade);
                    ((frmCidade)formulario).Text = "Editando Cidade";
                    ((frmCidade)formulario).enabledForm();
                    ((frmCidade)formulario).defineFoco();
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
        private void gridCidade_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridCidade[0, gridCidade.CurrentRow.Index].Value.ToString();
                Descricao = gridCidade[1, gridCidade.CurrentRow.Index].Value.ToString();
                Cep = gridCidade[3, gridCidade.CurrentRow.Index].Value.ToString();
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
        private void gridCidade_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                verPermCidade(gridCidade);
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

        private void frmCidadePesquisa_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridCidade(gridCidade);

                //verificar permissão de acesso
                verPermCidade(gridCidade);
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
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        /// <param name="Cep"></param>
        /// <param name="Endereco"></param>
        /// <param name="Bairro"></param>
        internal void carregaGrid(string Campo, string Cidade, string Estado, string Cep, string Endereco, string Bairro)
        {
            try
            {
                if (Campo.Equals("Cidade"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_cidade();
                    lista = objBLL.buscarCod(Cidade);
                    funcoes.gridCidade(gridCidade);
                    gridCidade.DataSource = lista;
                }
                else if (Campo.Equals("Cep"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_cidade();
                    lista = objBLL.buscarCep(Cep);
                    funcoes.gridCidade(gridCidade);
                    gridCidade.DataSource = lista;
                }
                else 
                {
                    //chama a classe de negócios
                    objBLL = new BLL_cidade();
                    lista = objBLL.buscarCidade(Cidade, Estado, Endereco, Bairro);
                    funcoes.gridCidade(gridCidade);
                    gridCidade.DataSource = lista;
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
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(string form, DataGridView dataGrid)
        {
            try
            {
                preencher(Codigo);
                formulario = new frmCidade(this, dataGrid, lista);
                ((frmCidade)formulario).MdiParent = MdiParent;
                ((frmCidade)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmCidade)formulario));
                ((frmCidade)formulario).Show();
                ((frmCidade)formulario).BringToFront();
                Enabled = false;
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="vCodCidade"></param>
        internal void preencher(string vCodCidade)
        {
            try
            {
                objBLL = new BLL_cidade();
                lista = objBLL.buscarCod(vCodCidade);
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_cidade criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_cidade();
                objEnt.CodCidade = Codigo;
                objEnt.Cidade = Descricao;
                objEnt.Cep = Cep;

                //retorna o objeto preenchido
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
        /// Função que define o Foco do cursor
        /// </summary>
        public void defineFoco()
        {
            txtCep.Focus();
        }
        
        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermCidade(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoCidade entAcesso = new MOD_acessoCidade();
                btnIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsCidade);
                btnEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditCidade, dataGrid);
                btnExc.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcCidade, dataGrid);
                btnVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisCidade, dataGrid);
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

    }
}
