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
    public partial class frmRotina : Form
    {

        public frmRotina(Form forms, DataGridView gridPesquisa, List<MOD_rotinas> lista)
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

        BLL_rotinas objBLL = null;
        MOD_rotinas objEnt = null;

        BLL_programas objBLL_Prog = null;
        List<MOD_programas> listaProg = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formPrograma;
        DataGridView dataGrid;

        #endregion

        #region eventos do formulario

        private void btnPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.abrirForm("frmProg");
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
        private void txtPrograma_Leave(object sender, EventArgs e)
        {
            if (!this.txtPrograma.Text.Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    this.carregaProg(this.txtPrograma.Text);
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

        private void optIns_Click(object sender, EventArgs e)
        {
            this.txtAcao.Text = "Inserir";
            this.txtAcao.Enabled = false;
        }
        private void optEditar_Click(object sender, EventArgs e)
        {
            this.txtAcao.Text = "Editar";
            this.txtAcao.Enabled = false;
        }
        private void optExc_Click(object sender, EventArgs e)
        {
            this.txtAcao.Text = "Excluir";
            this.txtAcao.Enabled = false;
        }
        private void optCancelar_Click(object sender, EventArgs e)
        {
            this.txtAcao.Text = "Cancelar";
            this.txtAcao.Enabled = false;
        }
        private void optVisual_Click(object sender, EventArgs e)
        {
            this.txtAcao.Text = "Visualizar";
            this.txtAcao.Enabled = false;
        }
        private void optImp_Click(object sender, EventArgs e)
        {
            this.txtAcao.Text = "Imprimir";
            this.txtAcao.Enabled = false;
        }
        private void optOutra_Click(object sender, EventArgs e)
        {
            this.txtAcao.Text = string.Empty;
            this.txtAcao.Enabled = true;
            this.txtAcao.Focus();
        }

        private void optSegBai_Click(object sender, EventArgs e)
        {
            this.lblDescSeg.Text = "Baixa";
        }
        private void optSegMed_Click(object sender, EventArgs e)
        {
            this.lblDescSeg.Text = "Média";
        }
        private void optSegAlta_Click(object sender, EventArgs e)
        {
            this.lblDescSeg.Text = "Alta";
        }

        private void optIndBai_Click(object sender, EventArgs e)
        {
            this.lblDescInd.Text = "Baixa";
        }
        private void optIndMed_Click(object sender, EventArgs e)
        {
            this.lblDescInd.Text = "Média";
        }
        private void optIndAlta_Click(object sender, EventArgs e)
        {
            this.lblDescInd.Text = "Alta";
        }

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
        private void frmRotina_Load(object sender, EventArgs e)
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
        private void frmRotina_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.Enabled = true;
        }
        private void frmRotina_FormClosing(object sender, FormClosingEventArgs e)
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
                    objBLL = new BLL_rotinas();

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

                    this.FormClosing -= new FormClosingEventHandler(frmRotina_FormClosing);

                    //conversor para retorno ao formulario principal
                    ((frmModProg)formulario).carregaGrid("Rotina", objEnt.CodPrograma, dataGrid);

                    this.Close();

                    this.FormClosing += new FormClosingEventHandler(frmRotina_FormClosing);

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

                if (this.lblPrograma.Text.Equals(string.Empty))
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
                if (this.txtAcao.Text.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Acão! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (this.lblDescSeg.Text.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Segurança! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (this.lblDescInd.Text.Equals(string.Empty))
                {
                    this.blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Indicada! Campo obrigatório.";
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
        /// Função que abre os formulários de pesquisa
        /// </summary>
        /// <param name="form"></param>
        private void abrirForm(string form)
        {
            if (form.Equals("frmProg"))
            {
                this.txtPrograma.Text = string.Empty;
                this.lblPrograma.Text = string.Empty;
                this.txtNivelProg.Text = string.Empty;
                this.txtSubMod.Text = string.Empty;
                this.lblDescSub.Text = string.Empty;
                this.txtNivelSub.Text = string.Empty;
                this.txtModulo.Text = string.Empty;
                this.lblDescMod.Text = string.Empty;
                this.txtNivelMod.Text = string.Empty;

                if (((frmProgramaBusca)formPrograma) == null || ((frmProgramaBusca)formPrograma).IsDisposed)
                {
                    formPrograma = new frmProgramaBusca(this);
                    ((frmProgramaBusca)formPrograma).MdiParent = MdiParent;
                    ((frmProgramaBusca)formPrograma).Show();
                    this.Enabled = false;
                }
            }
        }
        /// <summary>
        /// Função que carrega os dados do Sub Módulo pesquisado
        /// </summary>
        /// <param name="CodProg"></param>
        internal void carregaProg(string CodProg)
        {
            try
            {
                objBLL_Prog = new BLL_programas();
                listaProg = objBLL_Prog.buscarCod(CodProg);

                if (listaProg != null && listaProg.Count > 0)
                {
                    this.txtPrograma.Text = listaProg[0].CodPrograma;
                    this.lblPrograma.Text = listaProg[0].DescPrograma;
                    this.txtNivelProg.Text = listaProg[0].NivelProg;
                    this.txtSubMod.Text = listaProg[0].CodSubModulo;
                    this.lblDescSub.Text = listaProg[0].DescSubModulo;
                    this.txtNivelSub.Text = listaProg[0].NivelSub;
                    this.txtModulo.Text = listaProg[0].CodModulo;
                    this.lblDescMod.Text = listaProg[0].DescModulo;
                    this.txtNivelMod.Text = listaProg[0].NivelMod;
                }
                else
                {
                    this.abrirForm("frmProg");
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
        private MOD_rotinas criarTabela()
        {
            try
            {
                objEnt = new MOD_rotinas();
                objEnt.CodRotina = this.txtCodigo.Text;
                objEnt.CodPrograma = this.txtPrograma.Text;
                objEnt.NivelRotina = Convert.ToString(this.txtNivel.Value);
                objEnt.DescRotina = this.txtAcao.Text;
                objEnt.DescSeg = this.lblDescSeg.Text;
                objEnt.DescInd = this.lblDescInd.Text;

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
        /// <param name="listaRot"></param>
        internal void preencher(List<MOD_rotinas> listaRot)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                this.txtCodigo.Text = listaRot[0].CodRotina;
                this.txtPrograma.Text = listaRot[0].CodPrograma;
                this.lblPrograma.Text = listaRot[0].DescPrograma;
                this.txtNivelProg.Text = listaRot[0].NivelProg;
                this.txtSubMod.Text = listaRot[0].CodSubModulo;
                this.lblDescSub.Text = listaRot[0].DescSubModulo;
                this.txtNivelSub.Text = listaRot[0].NivelSub;
                this.txtModulo.Text = listaRot[0].CodModulo;
                this.lblDescMod.Text = listaRot[0].DescModulo;
                this.txtNivelMod.Text = listaRot[0].NivelMod;
                this.txtAcao.Text = listaRot[0].DescRotina;
                this.txtNivel.Value = Convert.ToDecimal(listaRot[0].NivelRotina);
                this.lblDescSeg.Text = listaRot[0].DescSeg;
                this.lblDescInd.Text = listaRot[0].DescInd;

                //verifica os dados para marcar as opções
                this.verifica();
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
            this.txtNivel.Focus();
        }
        /// <summary>
        /// Função que desabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            this.pnlProg.Enabled = false;
            this.btnSalvar.Enabled = false;
        }
        /// <summary>
        /// Função que habilita os controles
        /// </summary>
        internal void enabledForm()
        {
            this.pnlProg.Enabled = true;
            this.btnSalvar.Enabled = true;
        }
        /// <summary>
        /// Verifica os dados inseridos e marca as opções
        /// </summary>
        private void verifica()
        {
            try
            {
                ///marca a opção referente a Acao
                if (this.txtAcao.Text.Equals("Inserir"))
                {
                    this.optIns.Checked = true;
                }
                else if (this.txtAcao.Text.Equals("Editar"))
                {
                    this.optEditar.Checked = true;
                }
                else if (this.txtAcao.Text.Equals("Excluir"))
                {
                    this.optExc.Checked = true;
                }
                else if (this.txtAcao.Text.Equals("Cancelar"))
                {
                    this.optCancelar.Checked = true;
                }
                else if (this.txtAcao.Text.Equals("Visualizar"))
                {
                    this.optVisual.Checked = true;
                }
                else if (this.txtAcao.Text.Equals("Imprimir"))
                {
                    this.optImp.Checked = true;
                }
                else
                {
                    this.optOutra.Checked = true;
                }

                //marca a opção referente a Segurança
                if (this.lblDescSeg.Text.Equals("Baixa"))
                {
                    this.optSegBai.Checked = true;
                }
                else if (this.lblDescSeg.Text.Equals("Média"))
                {
                    this.optSegMed.Checked = true;
                }
                else if (this.lblDescSeg.Text.Equals("Alta"))
                {
                    this.optSegAlta.Checked = true;
                }

                //marca a opção referente a Indicada
                if (this.lblDescInd.Text.Equals("Baixa"))
                {
                    this.optIndBai.Checked = true;
                }
                else if (this.lblDescInd.Text.Equals("Média"))
                {
                    this.optIndMed.Checked = true;
                }
                else if (this.lblDescInd.Text.Equals("Alta"))
                {
                    this.optIndAlta.Checked = true;
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

    }
}