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
using ENT.uteis;

namespace ccbimp
{
    public partial class frmPesquisaCidade : Form
    {
        public frmPesquisaCidade(Form forms, string retorno)
        {
            InitializeComponent();
            try
            {
                ///preenche o comboEstado
                apoio.carregaComboEstado(cboEstado);

                formChama = forms;
                campoRetorno = retorno;
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

        //variaveis
        string Codigo;
        string Descricao;
        string Cep;

        BLL_cidade objBLL = null;
        List<MOD_cidade> lista;

        //instancias de validacoes
        clsException excp;

        Form formChama;
        string campoRetorno;

        #endregion

        #region eventos

        private void txtCidade_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPesq;
        }
        private void txtCidade_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnSel;
        }
        private void btnPesq_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();

                if (string.IsNullOrEmpty(txtCidade.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        carregaGrid(txtCidade.Text, cboEstado.Text);
                    }
                }
                else
                {
                    carregaGrid(txtCidade.Text, cboEstado.Text);
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
        private void btnSel_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                //chama a rotina para preencher dados
                preencher(Cep);
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
        private void gridCidade_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    //chama a rotina para preencher dados
                    preencher(Cep);
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
        private void gridCidade_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (gridCidade.RowCount > 0)
                {
                    btnSel.Enabled = true;
                }
                else
                {
                    btnSel.Enabled = false;
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
        private void frmCidadePesquisa_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridCidade(gridCidade);
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
        private void frmCidadePesquisa_Activated(object sender, EventArgs e)
        {
            defineFoco();
        }
        private void frmCidadeBusca_FormClosed(object sender, FormClosedEventArgs e)
        {
                formChama.Enabled = true;
        }

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo1"></param>
        /// <param name="Campo2"></param>
        internal void carregaGrid(string Cidade, string Estado)
        {
            try
            {
                if (string.IsNullOrEmpty(Estado))
                {
                    throw new Exception("É necessário informar o Estado!");
                }
                else
                {
                    //chama a classe de negócios
                    objBLL = new BLL_cidade();
                    lista = objBLL.buscarCidade(Cidade, Estado);
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
        /// Função que preenche o formulário para seleção
        /// </summary>
        /// <param name="Cep"></param>
        private void preencher(string vCep)
        {
            try
            {
                if (formChama.Name.Equals("frmPessoaErros"))
                {
                    ((frmPessoaErros)formChama).carregaCep(vCep, campoRetorno);
                    Close();
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
        /// Função que define o Foco do cursor
        /// </summary>
        private void defineFoco()
        {
            txtCidade.Focus();
        }

        #endregion

    }
}
