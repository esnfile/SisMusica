using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using ENT.uteis;
using BLL.administracao;
using BLL.Funcoes;
using ENT.Erros;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using BLL.pessoa;
using ENT.pessoa;
using ENT.administracao;
using BLL.uteis;
using ccbadm.pesquisa;

namespace ccbadm
{
    public partial class frmReunioes : Form
    {
        public frmReunioes(Form forms, DataGridView gridPesquisa, List<MOD_reuniaoMinisterio> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                //carregando a lista de permissões de acesso.
                listaAcesso = modulos.listaLibAcesso;

                //Carrega o ComboBox TipoReunião
                apoio.carregaComboTipoReuniao(cboTipo);
                //Carrega o ComboBox Biblia
                carregaBiblia();

                ///Recebe a lista e armazena
                listaReuniao = lista;

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
                }
                else
                {
                    txtDataInclusao.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtHoraInclusao.Text = DateTime.Now.ToString("HH:mm");
                    lblCodUsuario.Text = modulos.CodUsuario;
                    txtUsuario.Text = modulos.Usuario;
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

        List<MOD_acessos> listaAcesso = null;

        BLL_reuniaoMinisterio objBLL = null;
        MOD_reuniaoMinisterio objEnt = null;
        List<MOD_reuniaoMinisterio> listaReuniao = null;

        BLL_biblia objBLL_Biblia = null;
        List<MOD_biblia> listaBiblia = null;

        BLL_pessoa objBLL_Pessoa = null;
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

        #endregion

        #region Eventos do Formulario

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
        private void frmReunioes_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
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
        private void frmReunioes_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (btnSalvar.Enabled.Equals(false))
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
        private void frmReunioes_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
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
        private void txtCodCCB_Leave(object sender, EventArgs e)
        {
            if (!txtCodCCB.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaComum(txtCodCCB.Text);
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
        private void txtCodCCB_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnComum;
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
        private void txtExamina_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnExamina;
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

        private void btnListaPresenca_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                salvarLista();
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

        private void cboBiblia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cboBiblia.SelectedValue != null)
                {
                    foreach (MOD_biblia linha in listaBiblia)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodBiblia.Equals(Convert.ToString(cboBiblia.SelectedValue)))
                        {
                            lblCapitulo.Enabled = true;
                            cboCapitulo.Enabled = true;
                            lblVerso.Enabled = true;
                            txtVersoInicio.Enabled = true;
                            lblAo.Enabled = true;
                            txtVersoFim.Enabled = true;
                            lblAssunto.Enabled = true;
                            txtAssunto.Enabled = true;
                            cboCapitulo.Items.Clear();

                            for (int i = 0; i < Convert.ToInt16(linha.QtdeCapitulos); i++)
                            {
                                cboCapitulo.Items.Add(Convert.ToString(i + 1).PadLeft(3, '0'));
                            }
                            break;
                        }
                    }
                }
                else
                {
                    cboCapitulo.SelectedIndex = -1;
                    txtVersoInicio.Text = string.Empty;
                    txtVersoFim.Text = string.Empty;
                    txtAssunto.Text = string.Empty;
                    lblCapitulo.Enabled = false;
                    cboCapitulo.Enabled = false;
                    lblVerso.Enabled = false;
                    txtVersoInicio.Enabled = false;
                    lblAo.Enabled = false;
                    txtVersoFim.Enabled = false;
                    lblAssunto.Enabled = false;
                    txtAssunto.Enabled = false;
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

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    objBLL = new BLL_reuniaoMinisterio();

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
                    if (formChama.Name.Equals("frmReunioesBusca"))
                    {
                        ((frmReunioesBusca)formChama).carregaGrid("Reuniao", objEnt.CodReuniao, string.Empty, dataGrid);

                        FormClosing -= new FormClosingEventHandler(frmReunioes_FormClosing);

                        Close();

                        FormClosing += new FormClosingEventHandler(frmReunioes_FormClosing);
                    }
                    else if (formulario.Name.Equals("frmListaPresenca"))
                    {
                        //chama a rotina para abrir o formulario
                        abrirForm("frmLista", string.Empty);
                    }
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
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvarLista()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    objBLL = new BLL_reuniaoMinisterio();

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
                    //chama a rotina para abrir o formulario
                    abrirForm("frmLista", string.Empty);
                    ((frmListaPresenca)formulario).defineFoco();
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
                if (string.IsNullOrEmpty(cboTipo.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Informe qual o Tipo de Reunião.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblComum.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Comum congregação onde será realizada! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                 if (string.IsNullOrEmpty(txtDataReuniao.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Data da reunião! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
               if (string.IsNullOrEmpty(txtHoraReuniao.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Hora da reunião! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (chkAnciao.Checked.Equals(false) && chkEncReg.Checked.Equals(false) &&
                    chkExamina.Checked.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Necessário informar pelo menos um irmão(ã) para atendimento!";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                else
                {
                    if (chkAnciao.Checked.Equals(true))
                    {
                        if (string.IsNullOrEmpty(lblAnciao.Text))
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Ancião! Campo obrigatório.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                    if (chkEncReg.Checked.Equals(true))
                    {
                        if (string.IsNullOrEmpty(lblEncReg.Text))
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Encarregado Regional! Campo obrigatório.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                    if (chkExamina.Checked.Equals(true))
                    {
                        if (string.IsNullOrEmpty(lblExamina.Text))
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Examinadora! Campo obrigatório.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
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
        private MOD_reuniaoMinisterio criarTabela()
        {
            try
            {
                objEnt = new MOD_reuniaoMinisterio();
                objEnt.CodReuniao = txtCodigo.Text;
                objEnt.Status = lblStatus.Text;
                objEnt.DataInclusao = txtDataInclusao.Text;
                objEnt.HoraInclusao = txtHoraInclusao.Text;
                objEnt.CodUsuario = lblCodUsuario.Text;
                objEnt.DataReuniao = txtDataReuniao.Text;
                objEnt.HoraReuniao = txtHoraReuniao.Text;
                objEnt.CodTipoReuniao = Convert.ToString(cboTipo.SelectedValue);
                objEnt.DescTipoReuniao = cboTipo.Text;
                objEnt.CodCCB = txtCodCCB.Text;
                objEnt.DescricaoCCB = lblComum.Text;
                objEnt.DataFinaliza = txtDataFinaliza.Text;
                objEnt.HoraFinaliza = txtHoraFinaliza.Text;
                objEnt.CodUsuarioFinaliza = lblCodUsuarioFinaliza.Text;
                objEnt.DataCancela = txtDataCancela.Text;
                objEnt.HoraCancela = txtHoraCancela.Text;
                objEnt.CodUsuarioCancela = lblCodUsuarioCancela.Text;
                objEnt.CodAnciao = txtAnciao.Text;
                objEnt.NomeAnciao = lblAnciao.Text;
                objEnt.CodEncReg = txtEncReg.Text;
                objEnt.NomeEncReg = lblEncReg.Text;
                objEnt.CodExamina = txtExamina.Text;
                objEnt.NomeExamina = lblExamina.Text;
                objEnt.CodCooperador = txtCoop.Text;
                objEnt.NomeCoop = lblCoop.Text;
                objEnt.CodEncLocal = txtEncLocal.Text;
                objEnt.NomeEncLocal = lblEncLocal.Text;
                objEnt.CodInstrutor = txtInstrutor.Text;
                objEnt.NomeInstrutor = lblInstrutor.Text;
                objEnt.Obs = txtObs.Text;
                objEnt.CodBiblia = Convert.ToString(cboBiblia.SelectedValue);
                objEnt.DescLivro = cboBiblia.Text;
                objEnt.Capitulo = cboCapitulo.Text;
                objEnt.VersoInicio = txtVersoInicio.Text;
                objEnt.VersoFim = txtVersoFim.Text;
                objEnt.AssuntoPalavra = txtAssunto.Text;
                objEnt.HinoAbertura = txtHino.Text;

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
        /// <param name="listaReuniao"></param>
        internal void preencher(List<MOD_reuniaoMinisterio> listaReuniao)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaReuniao[0].CodReuniao;
                lblStatus.Text = listaReuniao[0].Status;
                txtDataInclusao.Text = listaReuniao[0].DataInclusao;
                txtHoraInclusao.Text = listaReuniao[0].HoraInclusao;
                lblCodUsuario.Text = listaReuniao[0].CodUsuario;
                txtUsuario.Text = listaReuniao[0].Usuario;
                txtDataReuniao.Text = listaReuniao[0].DataReuniao;
                txtHoraReuniao.Text = listaReuniao[0].HoraReuniao;
                cboTipo.SelectedValue = Convert.ToString(listaReuniao[0].CodTipoReuniao);
                txtCodCCB.Text = listaReuniao[0].CodCCB;
                lblComum.Text = listaReuniao[0].CodigoCCB + " - " + listaReuniao[0].DescricaoCCB;
                txtDataFinaliza.Text = listaReuniao[0].DataFinaliza;
                txtHoraFinaliza.Text = listaReuniao[0].HoraFinaliza;
                lblCodUsuarioFinaliza.Text = listaReuniao[0].CodUsuarioFinaliza;
                txtDataCancela.Text = listaReuniao[0].DataCancela;
                txtHoraCancela.Text = listaReuniao[0].HoraCancela;
                lblCodUsuarioCancela.Text = listaReuniao[0].CodUsuarioCancela;
                txtAnciao.Text = listaReuniao[0].CodAnciao;
                lblAnciao.Text = listaReuniao[0].NomeAnciao;
                txtEncReg.Text = listaReuniao[0].CodEncReg;
                lblEncReg.Text = listaReuniao[0].NomeEncReg;
                txtExamina.Text = listaReuniao[0].CodExamina;
                lblExamina.Text = listaReuniao[0].NomeExamina;
                txtCoop.Text = listaReuniao[0].CodCooperador;
                lblCoop.Text = listaReuniao[0].NomeCoop;
                txtEncLocal.Text = listaReuniao[0].CodEncLocal;
                lblEncLocal.Text = listaReuniao[0].NomeEncLocal;
                txtInstrutor.Text = listaReuniao[0].CodInstrutor;
                lblInstrutor.Text = listaReuniao[0].NomeInstrutor;
                txtObs.Text = listaReuniao[0].Obs;
                if (!string.IsNullOrEmpty(listaReuniao[0].CodBiblia))
                {
                    cboBiblia.SelectedValue = Convert.ToString(listaReuniao[0].CodBiblia);
                    cboCapitulo.Text = listaReuniao[0].Capitulo;
                    txtVersoInicio.Text = listaReuniao[0].VersoInicio;
                    txtVersoFim.Text = listaReuniao[0].VersoFim;
                    txtAssunto.Text = listaReuniao[0].AssuntoPalavra;
                }
                txtHino.Text = listaReuniao[0].HinoAbertura;

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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa">Código da Pessoa</param>
        /// <param name="Campo">Tipo de Pessoa</param>
        internal void carregaPessoa(string vCodPessoa, string Campo)
        {
            try
            {
                List<MOD_pessoa> listaPesFiltro = new List<MOD_pessoa>();

                objBLL_Pessoa = new BLL_pessoa();
                listaPessoa = objBLL_Pessoa.buscarCod(vCodPessoa, modulos.CodUsuarioCCB, true);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    if (Campo.Equals("Anciao"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(1)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtAnciao.Text = listaPesFiltro[0].CodPessoa;
                            lblAnciao.Text = listaPesFiltro[0].Nome;
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
                            txtEncReg.Text = listaPesFiltro[0].CodPessoa;
                            lblEncReg.Text = listaPesFiltro[0].Nome;
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
                            txtExamina.Text = listaPesFiltro[0].CodPessoa;
                            lblExamina.Text = listaPesFiltro[0].Nome;
                        }
                        else
                        {
                            abrirForm("frmPes", Campo);
                        }
                    }
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
                    txtCodCCB.Text = listaCCB[0].CodCCB;
                    lblComum.Text = listaCCB[0].Codigo + " - " + listaCCB[0].Descricao;
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
                }
                else if (form.Equals("frmCCB"))
                {
                    txtCodCCB.Text = string.Empty;
                    lblComum.Text = string.Empty;

                    formulario = new frmPesquisaComum(this, Campo);
                    ((frmPesquisaComum)formulario).MdiParent = MdiParent;
                    ((frmPesquisaComum)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaComum)formulario));
                    ((frmPesquisaComum)formulario).Show();
                    ((frmPesquisaComum)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmLista"))
                {
                    objBLL = new BLL_reuniaoMinisterio();
                    List<MOD_reuniaoMinisterio> lista = new List<MOD_reuniaoMinisterio>();
                    lista = objBLL.buscarCod(objEnt.CodReuniao);
                    preencher(lista);

                    formulario = new frmListaPresenca(listaAcesso, this, lista);
                    ((frmListaPresenca)formulario).MdiParent = MdiParent;
                    ((frmListaPresenca)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmListaPresenca)formulario));
                    ((frmListaPresenca)formulario).Show();
                    ((frmListaPresenca)formulario).BringToFront();
                    Enabled = false;
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
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                pnlReunioes.Enabled = false;
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
                pnlReunioes.Enabled = true;
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
            cboTipo.Focus();
        }
        /// <summary>
        /// Função que preenche o ComboBox Biblia
        /// </summary>
        /// <returns></returns>
        internal void carregaBiblia()
        {
            try
            {
                objBLL_Biblia = new BLL_biblia();
                listaBiblia = new List<MOD_biblia>();

                cboBiblia.SelectedIndexChanged -= new EventHandler(cboBiblia_SelectedIndexChanged);

                listaBiblia = objBLL_Biblia.buscarCod(string.Empty);
                cboBiblia.DataSource = listaBiblia;
                cboBiblia.ValueMember = "CodBiblia";
                cboBiblia.DisplayMember = "DescLivro";

                cboBiblia.SelectedIndexChanged += new EventHandler(cboBiblia_SelectedIndexChanged);

                cboBiblia.SelectedIndex = (-1);

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

                if (string.IsNullOrEmpty(lblEncReg.Text))
                {
                    chkEncReg.Checked = false;
                }
                else
                {
                    chkEncReg.Checked = true;
                }

                if (string.IsNullOrEmpty(lblExamina.Text))
                {
                    chkExamina.Checked = false;
                }
                else
                {
                    chkExamina.Checked = true;
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