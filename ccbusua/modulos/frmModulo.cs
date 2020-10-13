using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

//using de projetos
using BLL.acessos;
using ENT.acessos;
using ENT.Log;
using BLL.validacoes;
using BLL.validacoes.Controles;
using BLL.validacoes.Exceptions;
using BLL.validacoes.Formularios;
using ENT.Erros;
using BLL.Funcoes;

namespace ccbusua
{
    public partial class frmModulo : Form
    {

        public frmModulo(Form forms, DataGridView gridPesquisa, List<MOD_modulos> lista)
        {
            try
            {
                InitializeComponent();
                //indica que esse formulario foi aberto por outro
                formulario = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                if (lista != null && lista.Count > 0)
                {
                    this.preencher(lista);
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

        clsException excp;

        BLL_modulos objBLL = null;
        MOD_modulos objEnt = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        DataGridView dataGrid;

        #endregion

        #region eventos do formulario

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                this.salvar();
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
        private void frmModulo_Load(object sender, EventArgs e)
        {
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
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
        private void frmModulo_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.Enabled = true;
        }
        private void frmModulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult sair;
                sair = MessageBox.Show(modulos.msgSalvar, "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (sair.Equals(DialogResult.Yes))
                {
                    this.salvar();
                }
                else if (sair.Equals(DialogResult.No))
                {
                    e.Cancel = false;
                }
                else if (sair.Equals(DialogResult.Cancel))
                {
                    e.Cancel = true;
                    this.txtDesc.Focus();
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

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                if (this.ValidarControles().Equals(true))
                {
                    objBLL = new BLL_modulos();

                    if (Convert.ToInt32(this.txtCodigo.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.inserir(criarTabela());
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.salvar(criarTabela());
                    }

                    this.FormClosing -= new FormClosingEventHandler(frmModulo_FormClosing);

                    //conversor para retorno ao formulario principal
                    ((frmModProg)formulario).carregaGrid("Modulo", objEnt.CodModulo, dataGrid);
                    this.Close();

                    this.FormClosing += new FormClosingEventHandler(frmModulo_FormClosing);
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
                this.blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();

                if (this.txtDesc.Text.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (this.txtNivel.Value.Equals(0) || this.txtNivel.Text.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nivel! Campo não pode ser Nulo ou Zero.";
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
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_modulos criarTabela()
        {
            objEnt = new MOD_modulos();
            objEnt.CodModulo = this.txtCodigo.Text;
            objEnt.DescModulo = this.txtDesc.Text;
            objEnt.NivelMod = Convert.ToString(this.txtNivel.Value);

            //retorna a classe de propriedades preenchida com os textbox
            return objEnt;

        }
        /// <summary>
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaMod"></param>
        internal void preencher(List<MOD_modulos> listaMod)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                this.txtCodigo.Text = listaMod[0].CodModulo;
                this.txtDesc.Text = listaMod[0].DescModulo;
                this.txtNivel.Value = Convert.ToDecimal(listaMod[0].NivelMod);

            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        /// <summary>
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            this.txtDesc.Focus();
        }
        /// <summary>
        /// Função que desabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            this.pnlModulo.Enabled = false;
            this.btnSalvar.Enabled = false;
        }
        /// <summary>
        /// Função que habilita os controles
        /// </summary>
        internal void enabledForm()
        {
            this.pnlModulo.Enabled = true;
            this.btnSalvar.Enabled = true;
        }

        #endregion

    }
}