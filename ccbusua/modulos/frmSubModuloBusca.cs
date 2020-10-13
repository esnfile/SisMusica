using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

//using de projetos
using ENT.acessos;
using BLL.acessos;
using BLL.validacoes;
using BLL.Funcoes;
using BLL.validacoes.Exceptions;
using BLL.validacoes.Formularios;

namespace ccbusua
{
    public partial class frmSubModuloBusca : Form
    {
        public frmSubModuloBusca(Form forms)
        {
            InitializeComponent();
            //indica que esse formulario pertence a outro
            formulario = forms;
        }

        #region declarações

        //variaveis
        string Codigo;
        string Descricao;

        BLL_subModulos objBLL = null;
        List<MOD_subModulos> lista;
        Form formulario;

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
            this.carregaGrid(this.txtDesc.Text);
        }
        private void btnDescSel_Click(object sender, EventArgs e)
        {
            try
            {
                //chama a rotina para preencher dados
                this.preencher(Codigo);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void gridSubModulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnDescSel.Enabled.Equals(false))
            {
                try
                {
                    //chama a rotina para preencher dados
                    this.preencher(Codigo);
                }
                catch (Exception ex)
                {
                    excp = new clsException(ex);
                }
            }
        }
        private void gridSubModulo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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
        private void gridSubModulo_SelectionChanged(object sender, EventArgs e)
        {
            Codigo = this.gridSubMod[0, this.gridSubMod.CurrentRow.Index].Value.ToString();
            Descricao = this.gridSubMod[1, this.gridSubMod.CurrentRow.Index].Value.ToString();
        }
        private void frmSubModuloBusca_Load(object sender, EventArgs e)
        {
            ///chama a funcão montar grid
            funcoes.gridSubModulo(this.gridSubMod);
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSubModuloBusca_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.Enabled = true;
        }

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo1"></param>
        internal void carregaGrid(string Campo1)
        {
            try
            {
                apoio.Aguarde();
                //chama a classe de negócios
                objBLL = new BLL_subModulos();
                lista = objBLL.buscarDescricao(Campo1);
                funcoes.gridSubModulo(this.gridSubMod);
                this.gridSubMod.DataSource = lista;
            }
            catch (InvalidCastException)
            {
                this.txtDesc.SelectAll();
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
        /// <summary>
        /// Função que preenche o formulário para seleção
        /// </summary>
        /// <param name="vCodSub"></param>
        private void preencher(string vCodSub)
        {
            try
            {
                if (formulario.Name.Equals("frmPrograma"))
                {
                    ((frmPrograma)formulario).carregaSubMod(vCodSub);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        #endregion
    }
}
