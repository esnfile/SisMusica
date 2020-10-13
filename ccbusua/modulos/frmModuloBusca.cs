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
using BLL.Funcoes;
using BLL.validacoes;
using BLL.validacoes.Controles;
using BLL.validacoes.Exceptions;
using BLL.validacoes.Formularios;

namespace ccbusua
{
    public partial class frmModuloBusca : Form
    {

        public frmModuloBusca(Form forms)
        {
            InitializeComponent();
            //indica que esse formulario pertence a outro
            formulario = forms;
        }

        #region declarações

        //variaveis
        string Codigo;
        string Descricao;

        BLL_modulos objBLL = null;
        List<MOD_modulos> lista;
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
        private void gridModulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
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
        private void gridModulo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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
        private void gridModulo_SelectionChanged(object sender, EventArgs e)
        {
            Codigo = this.gridModulo[0, this.gridModulo.CurrentRow.Index].Value.ToString();
            Descricao = this.gridModulo[1, this.gridModulo.CurrentRow.Index].Value.ToString();
        }
        private void frmModuloBusca_Load(object sender, EventArgs e)
        {
            //chama a funcão montar grid
            funcoes.gridCidade(this.gridModulo);
            
            //funcão que carrega o grid modulo.
            this.carregaGrid(string.Empty);
        }
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmModuloBusca_FormClosed(object sender, FormClosedEventArgs e)
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
                objBLL = new BLL_modulos();
                lista = objBLL.buscarDescricao(Campo1);
                funcoes.gridModulo(this.gridModulo);
                this.gridModulo.DataSource = lista;
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
        /// <param name="vCodModulo"></param>
        private void preencher(string vCodModulo)
        {
            try
            {
                if (formulario.Name.Equals("frmSubModulo"))
                {
                    ((frmSubModulo)formulario).carregaMod(vCodModulo);
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
