using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

//using de projetos
using ENT.acessos;
using BLL.acessos;
using BLL.validacoes;
using BLL.validacoes.Controles;
using BLL.validacoes.Exceptions;
using BLL.validacoes.Formularios;
using BLL.Funcoes;

namespace ccbusua
{
    public partial class frmPesquisaModulo : Form
    {

        public frmPesquisaModulo(Form forms)
        {
            try
            {
                InitializeComponent();
                formChama = forms;
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
        public frmPesquisaModulo(Form forms, DataGridView grid)
        {
            try
            {
                InitializeComponent();
                formChama = forms;
                dataGrid = grid;
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
        public string Codigo;
        string Descricao;

        BLL_modulos objBLL = null;
        List<MOD_modulos> lista;

        Form formChama;
        DataGridView dataGrid;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        private void txtDesc_Enter(object sender, EventArgs e)
        {
            AcceptButton = this.btnDesc;
        }
        private void txtDesc_Leave(object sender, EventArgs e)
        {
            AcceptButton = this.btnDescSel;
        }
        private void btnDesc_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.carregaGrid(this.txtDesc.Text);
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
        private void btnDescSel_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                //chama a rotina para preencher dados
                this.preencher(Codigo);
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
        private void gridModulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnDescSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    //chama a rotina para preencher dados
                    this.preencher(Codigo);
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
        private void gridModulo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (this.gridModulo.RowCount > 0)
                {
                    this.btnDescSel.Enabled = true;
                }
                else
                {
                    this.btnDescSel.Enabled = false;
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
        private void gridModulo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = this.gridModulo[0, this.gridModulo.CurrentRow.Index].Value.ToString();
                Descricao = this.gridModulo[1, this.gridModulo.CurrentRow.Index].Value.ToString();
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
        private void frmPesquisaModulo_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridModulo(this.gridModulo);

                //funcão que carrega o grid modulo.
                this.carregaGrid(string.Empty);
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
            this.Close();
        }
        private void frmPesquisaModulo_Activated(object sender, EventArgs e)
        {
            this.defineFoco();
        }
        private void frmPesquisaModulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo"></param>
        internal void carregaGrid(string Campo)
        {
            try
            {
                //chama a classe de negócios
                objBLL = new BLL_modulos();
                lista = objBLL.buscarDescricao(Campo);
                funcoes.gridModulo(this.gridModulo);
                this.gridModulo.DataSource = lista;
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
        /// <param name="CodModulo"></param>
        private void preencher(string CodModulo)
        {
            try
            {
                if (this.formChama.Name.Equals("frmModProg"))
                {
                    //conversor para retorno ao formulario que chamou
                    ((frmModProg)formChama).carregaGrid("Modulo", CodModulo, dataGrid);
                }
                else if (this.formChama.Name.Equals("frmSubModulo"))
                {
                    //conversor para retorno ao formulario que chamou
                    ((frmSubModulo)formChama).carregaMod(CodModulo);
                }
                this.Close();
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
        private void defineFoco()
        {
            this.txtDesc.Focus();
        }

        #endregion

    }
}