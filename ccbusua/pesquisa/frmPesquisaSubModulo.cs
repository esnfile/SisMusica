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
    public partial class frmPesquisaSubModulo : Form
    {
        public frmPesquisaSubModulo(Form forms)
        {
            try
            {
                InitializeComponent();
                formChama = forms;

                //Carrega o Combo Módulo
                apoio.carregaComboModulo(cboModulo);
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
        public frmPesquisaSubModulo(Form forms, DataGridView grid)
        {
            try
            {
                InitializeComponent();
                formChama = forms;
                dataGrid = grid;

                //Carrega o Combo Módulo
                apoio.carregaComboModulo(cboModulo);
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
        string CodMod;

        BLL_subModulos objBLL = null;
        List<MOD_subModulos> lista;

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
                if (string.IsNullOrEmpty(CodMod))
                    throw new Exception("Selecione o módulo para pesquisar!");
                    apoio.Aguarde();
                    this.carregaGrid(CodMod, this.txtDesc.Text);
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
        private void cboModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModulo.SelectedIndex.Equals(-1))
            {
                CodMod = string.Empty;
            }
            else
            {
                CodMod = Convert.ToString(cboModulo.SelectedValue);
            }
        }

        private void gridSubModulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        private void gridSubModulo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (this.gridSubMod.RowCount > 0)
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
        private void gridSubModulo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = this.gridSubMod[0, this.gridSubMod.CurrentRow.Index].Value.ToString();
                Descricao = this.gridSubMod[1, this.gridSubMod.CurrentRow.Index].Value.ToString();
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
        private void frmPesquisaSubModulo_Load(object sender, EventArgs e)
        {
            try
            {
                ///chama a funcão montar grid
                funcoes.gridSubModulo(this.gridSubMod);
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
        private void frmPesquisaSubModulo_Activated(object sender, EventArgs e)
        {
            this.defineFoco();
        }
        private void frmPesquisaSubModulo_FormClosed(object sender, FormClosedEventArgs e)
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
                objBLL = new BLL_subModulos();
                lista = objBLL.buscarDescricao(Campo);
                funcoes.gridSubModulo(this.gridSubMod);
                this.gridSubMod.DataSource = lista;
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
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo"></param>
        internal void carregaGrid(string CodModulo, string Campo)
        {
            try
            {
                //chama a classe de negócios
                objBLL = new BLL_subModulos();
                lista = objBLL.buscarDescricao(CodModulo, Campo);
                funcoes.gridSubModulo(this.gridSubMod);
                this.gridSubMod.DataSource = lista;
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
        /// <param name="CodSubModulo"></param>
        private void preencher(string CodSubModulo)
        {
            try
            {
                if (this.formChama.Name.Equals("frmModProg"))
                {
                    //conversor para retorno ao formulario que chamou
                    ((frmModProg)formChama).carregaGrid("SubModulo", CodSubModulo, dataGrid);
                }
                else if (this.formChama.Name.Equals("frmPrograma"))
                {
                    //conversor para retorno ao formulario que chamou
                    ((frmPrograma)formChama).carregaSubMod(CodSubModulo);
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