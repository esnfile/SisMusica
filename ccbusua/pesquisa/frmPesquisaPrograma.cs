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
    public partial class frmPesquisaPrograma : Form
    {

        public frmPesquisaPrograma(Form forms)
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
        public frmPesquisaPrograma(Form forms, DataGridView grid)
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
        string CodSubMod;
        string CodMod;

        BLL_programas objBLL = null;
        List<MOD_programas> lista;

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
                if (string.IsNullOrEmpty(CodSubMod))
                    throw new Exception("Selecione o Sub-módulo para pesquisar!");
                apoio.Aguarde();
                this.carregaGrid(CodSubMod, this.txtDesc.Text);
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

        private void cboModulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboModulo.SelectedIndex.Equals(-1) || cboModulo.SelectedIndex.Equals(null))
            {
                CodMod = string.Empty;
                cboSubModulo.DataSource = null;
            }
            else
            {
                CodMod = Convert.ToString(cboModulo.SelectedValue);
                apoio.carregaComboSubModulo(cboSubModulo, CodMod);
            }
        }
        private void cboSubModulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboSubModulo.SelectedIndex.Equals(-1) || cboSubModulo.SelectedIndex.Equals(null))
            {
                CodSubMod = string.Empty;
            }
            else
            {
                CodSubMod = Convert.ToString(cboSubModulo.SelectedValue);
            }
        }

        private void gridDesc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        private void gridDesc_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (this.gridDesc.RowCount > 0)
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
        private void gridDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = this.gridDesc[0, this.gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = this.gridDesc[1, this.gridDesc.CurrentRow.Index].Value.ToString();
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
        private void frmPesquisaPrograma_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridPrograma(this.gridDesc);
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
        private void frmPesquisaPrograma_Activated(object sender, EventArgs e)
        {
            this.defineFoco();
        }
        private void frmPesquisaPrograma_FormClosed(object sender, FormClosedEventArgs e)
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
                objBLL = new BLL_programas();
                lista = objBLL.buscarDescricao(Campo);
                funcoes.gridPrograma(this.gridDesc);
                this.gridDesc.DataSource = lista;
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
        internal void carregaGrid(string CodSubModulo, string Campo)
        {
            try
            {
                //chama a classe de negócios
                objBLL = new BLL_programas();
                lista = objBLL.buscarDescricao(CodSubModulo, Campo);
                funcoes.gridPrograma(this.gridDesc);
                this.gridDesc.DataSource = lista;
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
        /// <param name="CodPrograma"></param>
        private void preencher(string CodPrograma)
        {
            try
            {
                if (this.formChama.Name.Equals("frmModProg"))
                {
                    //conversor para retorno ao formulario que chamou
                    ((frmModProg)formChama).carregaGrid("Programa", CodPrograma, dataGrid);
                }
                else if (this.formChama.Name.Equals("frmRotina"))
                {
                    //conversor para retorno ao formulario que chamou
                    ((frmRotina)formChama).carregaProg(CodPrograma);
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