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
using BLL.validacoes.Exceptions;
using BLL.validacoes.Formularios;
using ENT.Erros;
using BLL.Funcoes;

namespace ccbusua
{
    public partial class frmPrograma : Form
    {

        public frmPrograma(Form forms, DataGridView gridPesquisa, List<MOD_programas> lista)
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

        BLL_programas objBLL = null;
        MOD_programas objEnt = null;

        BLL_subModulos objBLL_Sub = null;
        List<MOD_subModulos> listaSub = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formSubModulo;

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
        private void frmPrograma_Load(object sender, EventArgs e)
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
        private void frmPrograma_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.Enabled = true;
        }
        private void frmPrograma_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtSubMod_Leave(object sender, EventArgs e)
        {
            if (!this.txtSubMod.Text.Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    this.carregaSubMod(this.txtSubMod.Text);
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
        private void btnSubMod_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.abrirForm("frmSub");
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
                    objBLL = new BLL_programas();

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

                    this.FormClosing -= new FormClosingEventHandler(frmPrograma_FormClosing);

                    //conversor para retorno ao formulario principal
                    ((frmModProg)formulario).carregaGrid("Programa", objEnt.CodSubModulo, dataGrid);
                    this.Close();

                    this.FormClosing += new FormClosingEventHandler(frmPrograma_FormClosing);

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

                if (this.lblSubMod.Text.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Sub-Módulo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (this.txtDesc.Text.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Programa! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (this.txtNivel.Value.Equals(0) || this.txtNivel.TextAlign.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nível! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                //chama o formulário para gerar os erros
                if (this.blnValida.Equals(false))
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
        /// Função que abre os formulários de pesquisa
        /// </summary>
        /// <param name="form"></param>
        private void abrirForm(string form)
        {
            if (form.Equals("frmSub"))
            {
                try
                {
                    this.txtSubMod.Text = string.Empty;
                    this.lblDescSubMod.Text = string.Empty;
                    this.txtNivelSubMod.Text = string.Empty;
                    this.txtModulo.Text = string.Empty;
                    this.lblDescModulo.Text = string.Empty;
                    this.txtNivelMod.Text = string.Empty;

                    if (((frmSubModulo)formSubModulo) == null || ((frmSubModulo)formSubModulo).IsDisposed)
                    {
                        formSubModulo = new frmSubModuloBusca(this);
                        ((frmSubModuloBusca)formSubModulo).MdiParent = MdiParent;
                        ((frmSubModuloBusca)formSubModulo).Show();
                        this.Enabled = false;
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
        }
        /// <summary>
        /// Função que carrega os dados do Sub Módulo pesquisado
        /// </summary>
        /// <param name="vCodSubMod"></param>
        internal void carregaSubMod(string CodSubMod)
        {
            try
            {
                objBLL_Sub = new BLL_subModulos();
                listaSub = objBLL_Sub.buscarCod(CodSubMod);

                if (listaSub != null && listaSub.Count > 0)
                {
                    this.txtSubMod.Text = listaSub[0].CodSubModulo;
                    this.lblDescSubMod.Text = listaSub[0].DescSubModulo;
                    this.txtNivelSubMod.Text = listaSub[0].NivelSub;
                    this.txtModulo.Text = listaSub[0].CodModulo;
                    this.lblDescModulo.Text = listaSub[0].DescModulo;
                    this.txtNivelMod.Text = listaSub[0].NivelMod;
                }
                else
                {
                    this.abrirForm("frmSub");
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
        private MOD_programas criarTabela()
        {
            try
            {
                objEnt = new MOD_programas();
                objEnt.CodPrograma = this.txtCodigo.Text;
                objEnt.DescPrograma = this.txtDesc.Text;
                objEnt.NivelProg = Convert.ToString(this.txtNivel.Value);
                objEnt.CodSubModulo = this.txtSubMod.Text;

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
        /// <param name="listaProg"></param>
        internal void preencher(List<MOD_programas> listaProg)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                this.txtCodigo.Text = listaProg[0].CodPrograma;
                this.txtSubMod.Text = listaProg[0].CodSubModulo;
                this.lblDescSubMod.Text = listaProg[0].DescSubModulo;
                this.txtNivelSubMod.Text = listaProg[0].NivelSub;
                this.txtModulo.Text = listaProg[0].CodModulo;
                this.lblDescModulo.Text = listaProg[0].DescModulo;
                this.txtNivelMod.Text = listaProg[0].NivelMod;
                this.txtDesc.Text = listaProg[0].DescPrograma;
                this.txtNivel.Value = Convert.ToDecimal(listaProg[0].NivelProg);

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
            this.txtDesc.Focus();
        }
        /// <summary>
        /// Função que desabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            this.pnlPrograma.Enabled = false;
            this.btnSalvar.Enabled = false;
        }
        /// <summary>
        /// Função que habilita os controles
        /// </summary>
        internal void enabledForm()
        {
            this.pnlPrograma.Enabled = true;
            this.btnSalvar.Enabled = true;
        }

        #endregion

    }
}