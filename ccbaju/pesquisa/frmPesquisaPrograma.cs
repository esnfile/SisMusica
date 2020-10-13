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
using BLL.acessos;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.uteis;

namespace ccbaju
{
    public partial class frmPesquisaPrograma : Form
    {
        public frmPesquisaPrograma(Form forms)
        {
            InitializeComponent();
            try
            {

                formChama = forms;

                #region Carrega Combo Boxes

                ///carrega os combos boxes
                //combo Modulo
                apoio.carregaComboModulo(cboModulo);

                #endregion

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

        BLL_programas objBLL = null;
        MOD_programas objEnt = null;
        List<MOD_programas> lista;

        //instancias de validacoes
        clsException excp;

        Form formChama;

        #endregion

        #region eventos

        #region Aba Descrição

        private void btnSel_Click(object sender, EventArgs e)
        {
            if (!btnSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    //chama a rotina para preencher dados
                    preencher(Codigo);
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
        private void gridDesc_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (gridDesc.RowCount > 0)
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
        private void gridDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
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
        private void gridDesc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    //chama a rotina para preencher dados
                    preencher(Codigo);
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

        #endregion

        #region Eventos do Formulario

        private void frmPesquisaPrograma_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridPrograma(gridDesc);
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
        private void frmPesquisaPrograma_Activated(object sender, EventArgs e)
        {
            defineFoco();
        }
        private void frmPesquisaPrograma_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void cboModulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            apoio.carregaComboSubModulo(cboSubModulo, Convert.ToInt16(cboModulo.SelectedValue).ToString());
        }
        private void cboSubModulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregaGrid(Convert.ToInt16(cboSubModulo.SelectedValue).ToString());
        }

        #endregion

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo1"></param>
        internal void carregaGrid(string CodSub)
        {
            try
            {
                //chama a classe de negócios
                objBLL = new BLL_programas();
                lista = objBLL.buscarSubModulo(CodSub);
                funcoes.gridPrograma(gridDesc);
                gridDesc.DataSource = lista;
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
        /// <param name="vCodigo"></param>
        private void preencher(string vCodigo)
        {
            try
            {
                if (formChama.Name.Equals("frmNovidadeBusca"))
                {
                    //((frmNovidadeBusca)formChama).carregaRegiao(vCodigo);
                    //Close();
                }
                else if (formChama.Name.Equals("frmNovidade"))
                {
                    ((frmNovidade)formChama).carregaProg(vCodigo);
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
            cboModulo.Focus();
        }

        #endregion

    }
}
