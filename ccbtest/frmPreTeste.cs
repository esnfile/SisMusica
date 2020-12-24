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
using BLL.instrumentos;
using BLL.pessoa;
using BLL.preTeste;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using ENT.instrumentos;
using ENT.pessoa;
using ENT.preTeste;
using ENT.uteis;
using ENT.relatorio;
using ccbretest;

namespace ccbtest
{
    public partial class frmPreTeste : Form
    {
        public frmPreTeste(Form forms, DataGridView gridPesquisa, List<MOD_preTeste> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaPreTeste = lista;

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
                }
                else
                {
                    txtDataAbertura.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtHoraAbertura.Text = DateTime.Now.ToString("HH:mm");
                    lblCodUsuAbertura.Text = modulos.CodUsuario;
                    funcoes.gridFichaPreTeste(gridFicha);
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

        BLL_preTeste objBLL = null;
        MOD_preTeste objEnt = null;
        List<MOD_preTeste> listaPreTeste = null;

        BLL_preTesteFicha objBLL_Ficha = null;
        MOD_preTesteFicha objEnt_Ficha = null;
        List<MOD_preTesteFicha> listaFicha = null;
        List<MOD_preTesteFicha> listaDeleteFicha = null;

        IBLL_buscaPessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa = null;

        BLL_ccb objBLL_CCB = null;
        List<MOD_ccb> listaCCB = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        string Codigo;
        string CodFicha;
        string NomeCandidato;
        string CodSolicita;
        string NomeRelatorio;

        #endregion

        #region eventos do formulario

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
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
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvar();
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
        private void frmPreTeste_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                verPermFicha(gridFicha);

                pctRjm.Image = imgPreTeste.Images[0];
                pctMeiaHora.Image = imgPreTeste.Images[1];
                pctCulto.Image = imgPreTeste.Images[2];
                pctOficial.Image = imgPreTeste.Images[3];
                pctTroca.Image = imgPreTeste.Images[4];
                definirImagens(gridFicha);
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
        private void frmPreTeste_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void frmPreTeste_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Pré-Teste"))
                {
                    e.Cancel = false;
                }
                else
                {
                    DialogResult sair;
                    sair = MessageBox.Show(modulos.msgSalvar, "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (sair.Equals(DialogResult.Yes))
                    {
                        salvar();
                    }
                    else if (sair.Equals(DialogResult.Cancel))
                    {
                        e.Cancel = true;
                    }
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

        private void txtComum_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnComum;
        }
        private void txtComum_Leave(object sender, EventArgs e)
        {
            if (!txtComum.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaComum(txtComum.Text);
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCCB", string.Empty);
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

        private void chkAnciao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAnciao.Checked.Equals(true))
                {
                    txtAnciao.Enabled = true;
                    btnAnciao.Enabled = true;
                    lblAnciao.Enabled = true;
                    chkAnciao.ForeColor = Color.Black;
                }
                else
                {
                    txtAnciao.Enabled = false;
                    txtAnciao.Text = string.Empty;
                    btnAnciao.Enabled = false;
                    lblAnciao.Enabled = false;
                    lblAnciao.Text = string.Empty;
                    chkAnciao.ForeColor = Color.DarkGray;
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
        private void chkCoop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCoop.Checked.Equals(true))
            {
                txtCoop.Enabled = true;
                btnCoop.Enabled = true;
                lblCoop.Enabled = true;
                chkCoop.ForeColor = Color.Black;
            }
            else
            {
                txtCoop.Enabled = false;
                txtCoop.Text = string.Empty;
                btnCoop.Enabled = false;
                lblCoop.Enabled = false;
                lblCoop.Text = string.Empty;
                chkCoop.ForeColor = Color.DarkGray;
            }
        }
        private void chkEncReg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEncReg.Checked.Equals(true))
            {
                txtEncReg.Enabled = true;
                btnEncReg.Enabled = true;
                lblEncReg.Enabled = true;
                chkEncReg.ForeColor = Color.Black;
            }
            else
            {
                txtEncReg.Enabled = false;
                txtEncReg.Text = string.Empty;
                btnEncReg.Enabled = false;
                lblEncReg.Enabled = false;
                lblEncReg.Text = string.Empty;
                chkEncReg.ForeColor = Color.DarkGray;
            }
        }
        private void chkExamina_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExamina.Checked.Equals(true))
            {
                txtExamina.Enabled = true;
                btnExamina.Enabled = true;
                lblExamina.Enabled = true;
                chkExamina.ForeColor = Color.Black;
            }
            else
            {
                txtExamina.Enabled = false;
                txtExamina.Text = string.Empty;
                btnExamina.Enabled = false;
                lblExamina.Enabled = false;
                lblExamina.Text = string.Empty;
                chkExamina.ForeColor = Color.DarkGray;
            }
        }
        private void chkEncLoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEncLoc.Checked.Equals(true))
            {
                txtEncLocal.Enabled = true;
                btnEncLocal.Enabled = true;
                lblEncLocal.Enabled = true;
                chkEncLoc.ForeColor = Color.Black;
            }
            else
            {
                txtEncLocal.Enabled = false;
                txtEncLocal.Text = string.Empty;
                btnEncLocal.Enabled = false;
                lblEncLocal.Enabled = false;
                lblEncLocal.Text = string.Empty;
                chkEncLoc.ForeColor = Color.DarkGray;
            }
        }
        private void chkInstrutor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInstrutor.Checked.Equals(true))
            {
                txtInstrutor.Enabled = true;
                btnInstrutor.Enabled = true;
                lblInstrutor.Enabled = true;
                chkInstrutor.ForeColor = Color.Black;
            }
            else
            {
                txtInstrutor.Enabled = false;
                txtInstrutor.Text = string.Empty;
                btnInstrutor.Enabled = false;
                lblInstrutor.Enabled = false;
                lblInstrutor.Text = string.Empty;
                chkInstrutor.ForeColor = Color.DarkGray;
            }
        }
        private void txtAnciao_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnAnciao;
        }
        private void txtAnciao_Leave(object sender, EventArgs e)
        {
            if (!txtAnciao.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtAnciao.Text, "Anciao");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnAnciao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "Anciao");
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
        private void txtCoop_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnCoop;
        }
        private void txtCoop_Leave(object sender, EventArgs e)
        {
            if (!txtCoop.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtCoop.Text, "Coop");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnCoop_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "Coop");
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
        private void txtEncReg_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnEncReg;
        }
        private void txtEncReg_Leave(object sender, EventArgs e)
        {
            if (!txtEncReg.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtEncReg.Text, "EncReg");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnEncReg_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "EncReg");
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
        private void txtExamina_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnExamina;
        }
        private void txtExamina_Leave(object sender, EventArgs e)
        {
            if (!txtExamina.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtExamina.Text, "Examina");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnExamina_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "Examina");
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
        private void txtEncLocal_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnEncLocal;
        }
        private void txtEncLocal_Leave(object sender, EventArgs e)
        {
            if (!txtEncLocal.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtEncLocal.Text, "EncLocal");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnEncLocal_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "EncLocal");
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
        private void txtInstrutor_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnInstrutor;
        }
        private void txtInstrutor_Leave(object sender, EventArgs e)
        {
            if (!txtInstrutor.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtInstrutor.Text, "Instrutor");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
        }
        private void btnInstrutor_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "Instrutor");
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

        private void btnInsFicha_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    apoio.Aguarde();
                    CodFicha = "0";
                    //chama a rotina para abrir o formulario
                    abrirForm("frmFicha", string.Empty);
                    ((frmFichaPreTeste)formulario).Text = "Inserindo Ficha Pré-Teste";
                    ((frmFichaPreTeste)formulario).enabledForm();
                    ((frmFichaPreTeste)formulario).disabledMetodo();
                    ((frmFichaPreTeste)formulario).defineFoco();
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
        private void btnEditarFicha_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                CodFicha = gridFicha["CodFichaPreTeste", gridFicha.CurrentRow.Index].Value.ToString();
                abrirForm("frmFicha", string.Empty);
                ((frmFichaPreTeste)formulario).Text = "Editando Ficha Pré-Teste";
                ((frmFichaPreTeste)formulario).enabledForm();
                ((frmFichaPreTeste)formulario).disabledMetodo();
                ((frmFichaPreTeste)formulario).defineFoco();
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
        private void btnExcluirFicha_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    CodFicha = gridFicha["CodFichaPreTeste", gridFicha.CurrentRow.Index].Value.ToString();
                    NomeCandidato = gridFicha["NomeCandidato", gridFicha.CurrentRow.Index].Value.ToString();
                    CodSolicita = gridFicha["CodSolicitaTeste", gridFicha.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL_Ficha = new BLL_preTesteFicha();
                    objBLL_Ficha.excluir(criarTabelaFicha());

                    funcoes.gridFichaPreTeste(gridFicha);
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
                    apoio.FecharAguardeExcluir();
                }
            }
        }
        private void btnImpFicha_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                CodFicha = gridFicha["CodFichaPreTeste", gridFicha.CurrentRow.Index].Value.ToString();
                NomeRelatorio = "ccbretest.relatorios.rptFichaPreTeste.rdlc";
                abrirForm("frmImpressao", string.Empty);
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
        private void gridFicha_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnEditarFicha.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    CodFicha = gridFicha["CodFichaPreTeste", gridFicha.CurrentRow.Index].Value.ToString();
                    abrirForm("frmFicha", string.Empty);
                    ((frmFichaPreTeste)formulario).Text = "Editando Ficha Pré-Teste";
                    ((frmFichaPreTeste)formulario).enabledForm();
                    ((frmFichaPreTeste)formulario).disabledMetodo();
                    ((frmFichaPreTeste)formulario).defineFoco();
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
        private void gridFicha_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermFicha(gridFicha);
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
        private void gridFicha_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CodFicha = gridFicha["CodFichaPreTeste", gridFicha.CurrentRow.Index].Value.ToString();
                NomeCandidato = gridFicha["NomeCandidato", gridFicha.CurrentRow.Index].Value.ToString();
                CodSolicita = gridFicha["CodSolicitaTeste", gridFicha.CurrentRow.Index].Value.ToString();
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

        #endregion

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    objBLL = new BLL_preTeste();

                    if (Convert.ToInt64(txtCodigo.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.inserir(criarTabela());
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.salvar(criarTabela(), "Update");
                    }

                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmPreTesteBusca"))
                    {
                        ((frmPreTesteBusca)formChama).carregaGrid("PreTeste", objEnt.CodPreTeste, string.Empty, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmPreTeste_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmPreTeste_FormClosing);
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
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (string.IsNullOrEmpty(txtDataExame.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Data do Exame! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblComum.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Comum - Local do Pré-teste! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (chkAnciao.Checked.Equals(false) && chkCoop.Checked.Equals(false) &&
                    chkEncReg.Checked.Equals(false) && chkEncLoc.Checked.Equals(false) &&
                    chkExamina.Checked.Equals(false) && chkInstrutor.Checked.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Necessário informar pelo menos um irmão(ã) para atendimento!";
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
        private MOD_preTeste criarTabela()
        {
            try
            {
                objEnt = new MOD_preTeste();
                objEnt.CodPreTeste = txtCodigo.Text;
                objEnt.Status = lblStatus.Text;
                objEnt.CodCCB = txtComum.Text;
                objEnt.CodigoCCB = lblCodigoCCB.Text;
                objEnt.DescricaoCCB = lblComum.Text;
                //objEnt.Obs = txtObs.Text;
                objEnt.DataExame = txtDataExame.Text;
                objEnt.HoraExame = txtHoraExame.Text;
                objEnt.DataAbertura = txtDataAbertura.Text;
                objEnt.HoraAbertura = txtHoraAbertura.Text;
                objEnt.CodUsuarioAbertura = lblCodUsuAbertura.Text;
                objEnt.CodAnciao = txtAnciao.Text;
                objEnt.NomeAnciao = lblAnciao.Text;
                objEnt.CodCooperador = txtCoop.Text;
                objEnt.NomeCooperador = lblCoop.Text;
                objEnt.CodEncReg = txtEncReg.Text;
                objEnt.NomeEncReg = lblEncReg.Text;
                objEnt.CodEncLocal = txtEncLocal.Text;
                objEnt.NomeEncLocal = lblEncLocal.Text;
                objEnt.CodExamina = txtExamina.Text;
                objEnt.NomeExamina = lblExamina.Text;
                objEnt.CodInstrutor = txtInstrutor.Text;
                objEnt.NomeInstrutor = lblInstrutor.Text;

                //retorna o objeto FichaPreTeste
                if (listaFicha != null && listaFicha.Count > 0 || listaDeleteFicha != null && listaDeleteFicha.Count > 0)
                {
                    objEnt.listaPreTesteFicha = new List<MOD_preTesteFicha>();
                    objEnt.listaDeletePreTesteFicha = new List<MOD_preTesteFicha>();
                    objEnt.listaPreTesteFicha = listaFicha;
                    objEnt.listaDeletePreTesteFicha = listaDeleteFicha;
                }

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
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                pnlPreTeste.Enabled = false;
                btnSalvar.Enabled = false;
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledForm()
        {
            try
            {
                pnlPreTeste.Enabled = true;
                btnSalvar.Enabled = true;
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
            pnlPreTeste.Focus();
        }

        /// <summary>
        /// Função que carrega a Pessoa pesquisado pelo Código
        ///<para>Campo= 'Anciao', 'Coop', 'EncReg', 'EncLocal', 'Examina', 'Instrutor'</para>
        /// </summary>
        /// <param name="vCodPessoa">Código da Pessoa</param>
        /// <param name="Campo">Campo a ser pesquisado</param>
        internal void carregaPessoa(string vCodPessoa, string Campo)
        {
            try
            {
                List<MOD_pessoa> listaPesFiltro = new List<MOD_pessoa>();

                objBLL_Pessoa = new BLL_buscaPessoaPorCodPessoa();
                listaPessoa = objBLL_Pessoa.Buscar(vCodPessoa, true);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    if (Campo.Equals("Anciao"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(1)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtAnciao.Text = listaPessoa[0].CodPessoa;
                            lblAnciao.Text = listaPessoa[0].Nome;
                        }
                        else
                        {
                            abrirForm("frmPes", Campo);
                        }
                    }
                    else if (Campo.Equals("Coop"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(2)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtCoop.Text = listaPessoa[0].CodPessoa;
                            lblCoop.Text = listaPessoa[0].Nome;
                        }
                        else
                        {
                            abrirForm("frmPes", Campo);
                        }
                    }
                    else if (Campo.Equals("EncReg"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(5)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtEncReg.Text = listaPessoa[0].CodPessoa;
                            lblEncReg.Text = listaPessoa[0].Nome;
                        }
                        else
                        {
                            abrirForm("frmPes", Campo);
                        }
                    }
                    else if (Campo.Equals("EncLocal"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(6)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtEncLocal.Text = listaPessoa[0].CodPessoa;
                            lblEncLocal.Text = listaPessoa[0].Nome;
                        }
                        else
                        {
                            abrirForm("frmPes", Campo);
                        }
                    }
                    else if (Campo.Equals("Examina"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(7)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtExamina.Text = listaPessoa[0].CodPessoa;
                            lblExamina.Text = listaPessoa[0].Nome;
                        }
                        else
                        {
                            abrirForm("frmPes", Campo);
                        }
                    }
                    else if (Campo.Equals("Instrutor"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(8)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtInstrutor.Text = listaPessoa[0].CodPessoa;
                            lblInstrutor.Text = listaPessoa[0].Nome;
                        }
                        else
                        {
                            abrirForm("frmPes", Campo);
                        }
                    }

                    //ValidarPessoa();
                }
                else
                {
                    abrirForm("frmPes", Campo);
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
        /// Função que carrega a Comum pesquisado pelo Código
        /// </summary>
        /// <param name="vCodCCB"></param>
        internal void carregaComum(string vCodCCB)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarCod(vCodCCB);

                if (listaCCB != null && listaCCB.Count > 0)
                {
                    txtComum.Text = listaCCB[0].CodCCB;
                    lblComum.Text = listaCCB[0].Codigo + " - " + listaCCB[0].Descricao + " - " + listaCCB[0].DescricaoRegiao;
                }
                else
                {
                    abrirForm("frmCCB", string.Empty);
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
        /// Função que abre os formulários de pesquisa
        /// </summary>
        /// <param name="form"></param>
        private void abrirForm(string form, string Campo)
        {
            try
            {
                if (form.Equals("frmPes"))
                {
                    if (Campo.Equals("Anciao"))
                    {
                        txtAnciao.Text = string.Empty;
                        lblAnciao.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, "Anciao");
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
                    }
                    else if (Campo.Equals("Coop"))
                    {
                        txtCoop.Text = string.Empty;
                        lblCoop.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, "Coop");
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
                    }
                    else if (Campo.Equals("EncReg"))
                    {
                        txtEncReg.Text = string.Empty;
                        lblEncReg.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, "EncReg");
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
                    }
                    else if (Campo.Equals("EncLocal"))
                    {
                        txtEncLocal.Text = string.Empty;
                        lblEncLocal.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, "EncLocal");
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
                    }
                    else if (Campo.Equals("Examina"))
                    {
                        txtExamina.Text = string.Empty;
                        lblExamina.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, "Examina");
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
                    }
                    else if (Campo.Equals("Instrutor"))
                    {
                        txtInstrutor.Text = string.Empty;
                        lblInstrutor.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, "Instrutor");
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
                    }
                }
                else if (form.Equals("frmCCB"))
                {
                    txtComum.Text = string.Empty;
                    lblComum.Text = string.Empty;

                    formulario = new frmPesquisaComum(this, Campo);
                    ((frmPesquisaComum)formulario).MdiParent = MdiParent;
                    ((frmPesquisaComum)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaComum)formulario));
                    ((frmPesquisaComum)formulario).Show();
                    ((frmPesquisaComum)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmFicha"))
                {
                    preencherFicha(CodFicha);
                    formulario = new frmFichaPreTeste(this, dataGrid, listaFicha, criarTabela());
                    ((frmFichaPreTeste)formulario).MdiParent = MdiParent;
                    ((frmFichaPreTeste)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmFichaPreTeste)formulario));
                    ((frmFichaPreTeste)formulario).Show();
                    ((frmFichaPreTeste)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmImpressao"))
                {
                    preencherFicha(CodFicha);
                    MOD_paramRelatorio Parametro = new MOD_paramRelatorio();
                    Parametro.NomeRelatorio = NomeRelatorio;
                    Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                    Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                    Parametro.RodapeRelatorio = modulos.listaParametros[0].RodapeRelatorio;

                    List<MOD_preTesteMts> listaQtdeSolfejo = new List<MOD_preTesteMts>();
                    List<MOD_preTesteMts> listaQtdeRitmo = new List<MOD_preTesteMts>();
                    listaQtdeSolfejo = listaFicha[0].listaPreTesteMts.Where(x=>x.TipoMts.Equals("Solfejo")).ToList();
                    listaQtdeRitmo = listaFicha[0].listaPreTesteMts.Where(x => x.TipoMts.Equals("Ritmo")).ToList();

                    Parametro.QtdeSolfejo = Convert.ToString(listaQtdeSolfejo.Count());
                    Parametro.QtdeRitmo = Convert.ToString(listaQtdeRitmo.Count());
                    Parametro.QtdeMetodo = Convert.ToString(listaFicha[0].listaPreTesteMet.Count());
                    Parametro.QtdeHino = Convert.ToString(listaFicha[0].listaPreTesteHino.Count());
                    Parametro.QtdeEscala = Convert.ToString(listaFicha[0].listaPreTesteEscala.Count());
                    Parametro.QtdeTeoria = Convert.ToString(listaFicha[0].listaPreTesteTeoria.Count());

                    formulario = new frmListaTeste(this, listaFicha, listaFicha[0].listaPreTesteMet, listaFicha[0].listaPreTesteMts,
                                                    listaFicha[0].listaPreTesteHino, listaFicha[0].listaPreTesteTeoria,
                                                    listaFicha[0].listaPreTesteEscala, Parametro);
                    ((frmListaTeste)formulario).ShowDialog();
                    ((frmListaTeste)formulario).Dispose();
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="listaPre"></param>
        internal void preencher(List<MOD_preTeste> listaPre)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaPre[0].CodPreTeste;
                lblStatus.Text = listaPre[0].Status;
                txtDataExame.Text = listaPre[0].DataExame;
                txtHoraExame.Text = listaPre[0].HoraExame;
                txtDataAbertura.Text = listaPre[0].DataAbertura;
                txtHoraAbertura.Text = listaPre[0].HoraAbertura;
                txtDataFecha.Text = listaPre[0].DataFechamento;
                txtHoraFecha.Text = listaPre[0].HoraFechamento;
                lblCodUsuAbertura.Text = listaPre[0].CodUsuarioAbertura;
                txtComum.Text = listaPre[0].CodCCB;
                lblCodigoCCB.Text = listaPre[0].CodigoCCB;
                lblComum.Text = listaPre[0].CodigoCCB + " - " + listaPre[0].DescricaoCCB + " - " + listaPre[0].DescricaoRegiao;
                txtAnciao.Text = listaPre[0].CodAnciao;
                lblAnciao.Text = listaPre[0].NomeAnciao;
                txtCoop.Text = listaPre[0].CodCooperador;
                lblCoop.Text = listaPre[0].NomeCooperador;
                txtExamina.Text = listaPre[0].CodExamina;
                lblExamina.Text = listaPre[0].NomeExamina;
                txtEncReg.Text = listaPre[0].CodEncReg;
                lblEncReg.Text = listaPre[0].NomeEncReg;
                txtEncLocal.Text = listaPre[0].CodEncLocal;
                lblEncLocal.Text = listaPre[0].NomeEncLocal;
                txtInstrutor.Text = listaPre[0].CodInstrutor;
                lblInstrutor.Text = listaPre[0].NomeInstrutor;

                listaFicha = listaPre[0].listaPreTesteFicha;
                carregaFichas(listaFicha);

                //Faz as verificações para preencher os CheckBoxes e Options
                verificacoes();
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="CodFicha"></param>
        internal void preencherFicha(string CodFicha)
        {
            try
            {
                objBLL_Ficha = new BLL_preTesteFicha();
                listaFicha = objBLL_Ficha.buscarCod(CodFicha);
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
        /// Verifica os buttons
        /// </summary>
        private void verificacoes()
        {
            try
            {
                if (string.IsNullOrEmpty(lblAnciao.Text))
                {
                    chkAnciao.Checked = false;
                }
                else
                {
                    chkAnciao.Checked = true;
                }

                if (string.IsNullOrEmpty(lblCoop.Text))
                {
                    chkCoop.Checked = false;
                }
                else
                {
                    chkCoop.Checked = true;
                }

                if (string.IsNullOrEmpty(lblEncReg.Text))
                {
                    chkEncReg.Checked = false;
                }
                else
                {
                    chkEncReg.Checked = true;
                }

                if (string.IsNullOrEmpty(lblEncLocal.Text))
                {
                    chkEncLoc.Checked = false;
                }
                else
                {
                    chkEncLoc.Checked = true;
                }

                if (string.IsNullOrEmpty(lblExamina.Text))
                {
                    chkExamina.Checked = false;
                }
                else
                {
                    chkExamina.Checked = true;
                }

                if (string.IsNullOrEmpty(lblInstrutor.Text))
                {
                    chkInstrutor.Checked = false;
                }
                else
                {
                    chkInstrutor.Checked = true;
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

        #region Ficha PreTeste

        /// <summary>
        /// Função que preenche o ComboBox Metodos
        /// </summary>
        /// <returns></returns>
        internal void carregaFichas(List<MOD_preTesteFicha> listaFichaPre)
        {
            try
            {
                //objBLL_Ficha = new BLL_preTesteFicha();
                //listaFicha = new List<MOD_preTesteFicha>();

                //listaFicha = objBLL_Ficha.buscarPreTeste(PreTeste);
                funcoes.gridFichaPreTeste(gridFicha);
                gridFicha.DataSource = listaFichaPre;
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
        /// Função que preenche o ComboBox Metodos
        /// </summary>
        /// <returns></returns>
        internal void buscarFichas(string CodPreTeste)
        {
            try
            {
                objBLL_Ficha = new BLL_preTesteFicha();
                listaFicha = new List<MOD_preTesteFicha>();
                listaFicha = objBLL_Ficha.buscarPreTeste(CodPreTeste);
                carregaFichas(listaFicha);
                definirImagens(gridFicha);
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
        /// Função que preenche as licoes a serem aplicadas no Exame
        /// </summary>
        /// <returns></returns>
        internal void criarFichaPreTeste(MOD_preTesteFicha objEnt_Ficha)
        {
            try
            {
                listaFicha.Add(objEnt_Ficha);
                carregaFichas(listaFicha);
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_preTesteFicha criarTabelaFicha()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt_Ficha = new MOD_preTesteFicha();
                objEnt_Ficha.CodFichaPreTeste = CodFicha;
                objEnt_Ficha.NomeCandidato = NomeCandidato;
                objEnt_Ficha.CodSolicitaTeste = CodSolicita;

                //retorna o objeto preenchido
                return objEnt_Ficha;
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermFicha(DataGridView dataGrid)
        {
            try
            {
                btnInsFicha.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoFichaPreTeste.RotInsFichaPreTeste);
                btnEditarFicha.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoFichaPreTeste.RotEditFichaPreTeste, dataGrid);
                btnExcluirFicha.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoFichaPreTeste.RotExcFichaPreTeste, dataGrid);
                btnImpFicha.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoFichaPreTeste.RotImpFichaPreTeste, dataGrid);
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
        /// Função que define a imagem do status
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (Convert.ToString(linha.Cells["Tipo"].Value).Contains("Reunião de Jovens"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[0];
                    }
                    else if (Convert.ToString(linha.Cells["Tipo"].Value).Contains("Meia Hora"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[1];
                    }
                    else if (Convert.ToString(linha.Cells["Tipo"].Value).Contains("Culto Oficial"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[2];
                    }
                    else if (Convert.ToString(linha.Cells["Tipo"].Value).Contains("Oficialização"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[3];
                    }
                    else if (Convert.ToString(linha.Cells["Tipo"].Value).Contains("Troca Instrumento"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[4];
                    }
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