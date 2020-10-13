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
using ccbtest.pesquisa;
using ENT.licao;
using BLL.licao;

namespace ccbtest
{
    public partial class frmFichaPreTeste : Form
    {
        public frmFichaPreTeste(Form forms, DataGridView gridPesquisa, List<MOD_preTesteFicha> lista, MOD_preTeste ent_PreTeste)
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

                ///Recebe a lista e armazena
                listaPreTesteFicha = lista;
                objEnt_PreTeste = ent_PreTeste;

                txtCodPreTeste.Text = objEnt_PreTeste.CodPreTeste;
                txtComum.Text = objEnt_PreTeste.DescricaoCCB;
                txtDataExame.Text = objEnt_PreTeste.DataExame;
                txtHoraExame.Text = objEnt_PreTeste.HoraExame;
                txtDataLancto.Text = objEnt_PreTeste.DataAbertura;
                txtHoraLancto.Text = objEnt_PreTeste.HoraAbertura;
                txtDataFecha.Text = objEnt_PreTeste.DataFechamento;
                txtHoraFecha.Text = objEnt_PreTeste.HoraFechamento;

                //monta o grid ficha
                montaGridMet(gridMetodo);
                montaGridHinario(gridHino);
                montaGridMts(gridMts);
                montaGridEscala(gridEscala);
                montaGridTeoria(gridTeoria);

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
                }
                else
                {
                    //define a data do cadastro como data atual para o modo de inserção
                    txtData.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtHora.Text = DateTime.Now.ToString("HH:mm");
                    txtCodUsuario.Text = modulos.CodUsuario;
                    txtUsuario.Text = modulos.Usuario;

                    ///Preenche os dados recebidos dos parametros
                    txtObsMet.Text = modulos.listaParametros[0].TesteObsMet;
                    txtObsMts.Text = modulos.listaParametros[0].TesteObsMts;
                    txtObsHino.Text = modulos.listaParametros[0].TesteObsHino;
                    txtObsEsc.Text = modulos.listaParametros[0].TesteObsEsc;
                    txtObsTeoria.Text = modulos.listaParametros[0].TesteObsTeoria;

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

        MOD_preTeste objEnt_PreTeste = null;

        BLL_preTesteFicha objBLL = null;
        MOD_preTesteFicha objEnt = null;
        List<MOD_preTesteFicha> listaPreTesteFicha = new List<MOD_preTesteFicha>();

        MOD_preTesteMet objEnt_TesteMet = null;
        BindingList<MOD_preTesteMet> listaTesteMetodo = new BindingList<MOD_preTesteMet>();
        List<MOD_preTesteMet> listaDeleteTesteMetodo = new List<MOD_preTesteMet>();
        BindingSource objBind_TesteMetodo = new BindingSource();

        MOD_preTesteEscala objEnt_TesteEscala = null;
        BindingList<MOD_preTesteEscala> listaTesteEscala = new BindingList<MOD_preTesteEscala>();
        List<MOD_preTesteEscala> listaDeleteTesteEscala = new List<MOD_preTesteEscala>();
        BindingSource objBind_TesteEscala = new BindingSource();

        MOD_preTesteHino objEnt_TesteHino = null;
        BindingList<MOD_preTesteHino> listaTesteHino = new BindingList<MOD_preTesteHino>();
        List<MOD_preTesteHino> listaDeleteTesteHino = new List<MOD_preTesteHino>();
        BindingSource objBind_TesteHino = new BindingSource();

        MOD_preTesteMts objEnt_TesteMts = null;
        BindingList<MOD_preTesteMts> listaTesteMts = new BindingList<MOD_preTesteMts>();
        List<MOD_preTesteMts> listaDeleteTesteMts = new List<MOD_preTesteMts>();
        BindingSource objBind_TesteMts = new BindingSource();

        MOD_preTesteTeoria objEnt_TesteTeoria = null;
        BindingList<MOD_preTesteTeoria> listaTesteTeoria = new BindingList<MOD_preTesteTeoria>();
        List<MOD_preTesteTeoria> listaDeleteTesteTeoria = new List<MOD_preTesteTeoria>();
        BindingSource objBind_TesteTeoria = new BindingSource();

        BLL_pessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        BLL_solicitaTeste objBLL_Solicita = null;
        List<MOD_solicitaTeste> listaSolicita = new List<MOD_solicitaTeste>();

        BLL_ccb objBLL_CCB = null;
        List<MOD_ccb> listaCCB = new List<MOD_ccb>();

        BLL_metodos objBLL_Metodos = null;
        List<MOD_metodos> listaMts = new List<MOD_metodos>();

        BLL_tipoEscala objBLL_TipoEscala = null;
        List<MOD_tipoEscala> listaTipoEscala = new List<MOD_tipoEscala>();

        BLL_instrumento objBLL_Instrumento = null;
        List<MOD_pessoaInstr> listaPessoaInstr = new List<MOD_pessoaInstr>();
        List<MOD_instrumento> listaInstrumento = new List<MOD_instrumento>();
        
        MOD_pessoaMetodo objEnt_PessoaMet = null;
        List<MOD_pessoaMetodo> listaPessoaMetodo = new List<MOD_pessoaMetodo>();

        BLL_pessoaMetodoLicao objBLL_PesMetLicao = null;
        MOD_pessoaMetodoLicao objEnt_PesMetLicao = null;
        List<MOD_pessoaMetodoLicao> listaPesMetLicao = new List<MOD_pessoaMetodoLicao>();

        BLL_metodoInstr objBLL_InstrMet = null;
        BindingList<MOD_metodoInstr> listaInstrMet = new BindingList<MOD_metodoInstr>();

        BLL_hinario objBLL_Hino = null;
        List<MOD_hinario> listaHino = new List<MOD_hinario>();
        List<MOD_instrumentoHinario> listaInstrHino = new List<MOD_instrumentoHinario>();

        BLL_teoria objBLL_Teoria = null;
        List<MOD_teoria> listaTeoria = new List<MOD_teoria>();

        BLL_licaoTesteEscala objBLL_LicaoEscala = null;
        List<MOD_licaoTesteEscala> listaLicaoEscala = new List<MOD_licaoTesteEscala>();

        BLL_licaoTesteMet objBLL_LicaoMet = null;
        List<MOD_licaoTesteMet> listaLicaoMet = new List<MOD_licaoTesteMet>();

        BLL_licaoTesteMts objBLL_LicaoMts = null;
        List<MOD_licaoTesteMts> listaLicaoMts = new List<MOD_licaoTesteMts>();

        BLL_licaoTesteHino objBLL_LicaoHino = null;
        List<MOD_licaoTesteHino> listaLicaoHino = new List<MOD_licaoTesteHino>();

        BLL_licaoTesteTeoria objBLL_LicaoTeoria = null;
        List<MOD_licaoTesteTeoria> listaLicaoTeoria = new List<MOD_licaoTesteTeoria>();

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        string CodMetodo;
        string CodPreTesteMet;
        string CodPreTesteHino;
        string CodPreTesteMts;
        string CodPreTesteEscala;
        string CodPreTesteTeoria;

        string CodHino;
        string CodMts;
        string CodTeoria;
        string CodEscala;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

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
        private void frmFichaPreTeste_Load(object sender, EventArgs e)
        {
            try
            {
                verParamametros();

                //Verifica se Text ObsMet
                if (txtObsMet.TextLength > 0)
                {
                    lblObsPadraoMet.Visible = false;
                }
                else
                {
                    lblObsPadraoMet.Visible = true;
                }
                //Verifica se Text ObsMts
                if (txtObsMts.TextLength > 0)
                {
                    lblObsPadraoMts.Visible = false;
                }
                else
                {
                    lblObsPadraoMts.Visible = true;
                }
                //Verifica se Text ObsHino
                if (txtObsHino.TextLength > 0)
                {
                    lblObsPadraoHino.Visible = false;
                }
                else
                {
                    lblObsPadraoHino.Visible = true;
                }
                //Verifica se Text ObsEsc
                if (txtObsEsc.TextLength > 0)
                {
                    lblObsPadraoEsc.Visible = false;
                }
                else
                {
                    lblObsPadraoEsc.Visible = true;
                }
                //Verifica se Text ObsTeoria
                if (txtObsTeoria.TextLength > 0)
                {
                    lblObsPadraoTeoria.Visible = false;
                }
                else
                {
                    lblObsPadraoTeoria.Visible = true;
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
        private void frmFichaPreTeste_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void frmFichaPreTeste_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Ficha Pré-Teste"))
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

        private void tabTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabTipo.SelectedTab.Name.Equals("tabMetodo"))
                {
                    disabledMetodo();
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabHino"))
                {
                    disabledHinario();
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabMts"))
                {
                    disabledMts();
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabEscala"))
                {
                    disabledEscala();
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabTeoria"))
                {
                    disabledTeoria();
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

        private void txtPessoa_Leave(object sender, EventArgs e)
        {
            if (!txtPessoa.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtPessoa.Text, "Aluno");
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
            else
            {
                txtPessoa.Text = string.Empty;
                lblPessoa.Text = string.Empty;
                txtInstrumento.Text = string.Empty;
            }
        }
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "Aluno");
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
        private void txtPessoa_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPessoa;
        }
        private void txtInstrumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInstrumento.Text.Trim()))
                {
                    tabTipo.Enabled = false;
                }
                else
                {
                    tabTipo.Enabled = true;
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

        private void txtSolicita_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnSolicita;
        }
        private void btnSolicita_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmSolicitacao", string.Empty);
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
        private void txtSolicita_Leave(object sender, EventArgs e)
        {
            if (!txtSolicita.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaSolicita(txtSolicita.Text);
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
            else
            {
                txtSolicita.Text = string.Empty;
                lblSolicita.Text = string.Empty;
                txtPessoa.Text = string.Empty;
                lblPessoa.Text = string.Empty;
                txtInstrumento.Text = string.Empty;
            }
        }

        private void optRjm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optRjm.Checked.Equals(true))
                {
                    lblTipo.Text = "Reunião de Jovens";
                }
                else
                {
                    lblTipo.Text = string.Empty;
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
        private void optCulto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optCulto.Checked.Equals(true))
                {
                    lblTipo.Text = "Culto Oficial";
                }
                else
                {
                    lblTipo.Text = string.Empty;
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
        private void optOficial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optOficial.Checked.Equals(true))
                {
                    lblTipo.Text = "Oficialização";
                }
                else
                {
                    lblTipo.Text = string.Empty;
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
        private void optMeiaHora_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMeiaHora.Checked.Equals(true))
                {
                    lblTipo.Text = "Meia Hora";
                }
                else
                {
                    lblTipo.Text = string.Empty;
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
        private void optTroca_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optTroca.Checked.Equals(true))
                {
                    lblTipo.Text = "Troca Instrumento";
                }
                else
                {
                    lblTipo.Text = string.Empty;
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

        #region Aba Metodo

        private void btnMetIns_Click(object sender, EventArgs e)
        {
            try
            {
                limparMetodo();
                enabledMetodo();

                if (modulos.listaParametros[0].TesteMetodo.Equals("Candidato"))
                {
                    if (listaPessoaMetodo == null || listaPessoaMetodo.Count < 1)
                    {
                        apoio.Aguarde();
                        carregaMetodoPessoa(txtPessoa.Text);
                    }
                }
                else
                {
                    if (listaInstrMet == null || listaInstrMet.Count < 1)
                    {
                        apoio.Aguarde();
                        carregaMetodoInstr(lblCodInstrumento.Text);
                    }
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
        private void btnMetExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                deleteMetodo(gridMetodo.CurrentRow.Index);
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
        private void btnDefinirLicaoMet_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Efetuando Gravações...");
                salvarMetodo(Convert.ToString(cboMetodo.SelectedValue));
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
        private void btnCancelarLicaoMet_Click(object sender, EventArgs e)
        {
            try
            {
                limparMetodo();
                disabledMetodo();
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
        private void cboMetodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMetodo.SelectedValue != null)
                {
                    if (modulos.listaParametros[0].TesteMetodo.Equals("Candidato"))
                    {
                        foreach (MOD_pessoaMetodo linha in listaPessoaMetodo)
                        {
                            ///verifica a condição especificada para exibir a imagem
                            if (linha.CodMetodo.Contains(Convert.ToString(cboMetodo.SelectedValue)))
                            {
                                List<MOD_parametroPreTesteMet> listaFiltro = new List<MOD_parametroPreTesteMet>();
                                listaFiltro = modulos.listaParametros[0].listaParamPreTeste.Where(c => c.CodMetodo.Equals(Convert.ToString(cboMetodo.SelectedValue))).ToList();

                                txtQtdeMet.Value = Convert.ToInt16(listaFiltro[0].QtdeLicao);
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (MOD_metodoInstr linha in listaInstrMet)
                        {
                            ///verifica a condição especificada para exibir a imagem
                            if (linha.CodMetodo.Equals(Convert.ToString(cboMetodo.SelectedValue)))
                            {
                                //List<MOD_parametroPreTesteMet> listaFiltro = new List<MOD_parametroPreTesteMet>();
                                //listaFiltro = modulos.listaParametros[0].listaParamPreTeste.Where(c => c.CodMetodo.Equals(Convert.ToString(cboMetodo.SelectedValue))).ToList();

                                //txtQtdeMet.Value = Convert.ToInt16(listaFiltro[0].QtdeLicao);
                                lblQtdeMet.Enabled = true;
                                txtQtdeMet.Enabled = true;
                                break;
                            }
                        }
                    }
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
        private void gridMetodo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermMetodo(gridMetodo);
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
        private void gridMetodo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!gridMetodo.Equals(null) && gridMetodo.Rows.Count > 0)
                {
                    CodPreTesteMet = gridMetodo["CodPreTesteMet", gridMetodo.CurrentRow.Index].Value.ToString();
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
        private void txtObsMet_Enter(object sender, EventArgs e)
        {
            lblObsPadraoMet.Visible = false;
        }
        private void txtObsMet_Leave(object sender, EventArgs e)
        {
            if (txtObsMet.TextLength > 0)
            {
                lblObsPadraoMet.Visible = false;
            }
            else
            {
                lblObsPadraoMet.Visible = true;
            }
        }
        private void lblObsPadraoMet_Click(object sender, EventArgs e)
        {
            txtObsMet.Text = modulos.listaParametros[0].TesteObsMet;
            lblObsPadraoMet.Visible = false;
            txtObsMet.Focus();
        }

        #endregion

        #region Aba Hinario

        private void btnHinoInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparHinario();
                enabledHinario();

                if (listaInstrHino == null || listaInstrHino.Count < 1)
                {
                    apoio.Aguarde();
                    carregaHinario(lblCodInstrumento.Text);
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
        private void btnHinoExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                deleteHinario(gridHino.CurrentRow.Index);
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
        private void btnDefinirLicaoHino_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Efetuando Gravações...");
                salvarHinario(Convert.ToString(cboHinoHinario.SelectedValue));
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
        private void btnCancelarLicaoHino_Click(object sender, EventArgs e)
        {
            try
            {
                limparHinario();
                disabledHinario();
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
        private void cboHinoHinario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboHinoHinario.SelectedValue != null)
                {
                    foreach (MOD_instrumentoHinario linha in listaInstrHino)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodHinario.Equals(Convert.ToString(cboHinoHinario.SelectedValue)))
                        {
                            lblQtdeHino.Enabled = true;
                            txtQtdeHino.Enabled = true;
                            break;
                        }
                    }
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
        private void gridHino_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermHinario(gridHino);
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
        private void gridHino_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!gridHino.Equals(null) && gridHino.Rows.Count > 0)
                {
                    CodPreTesteHino = gridHino["CodPreTesteHino", gridHino.CurrentRow.Index].Value.ToString();
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
        private void lblObsPadraoHino_Click(object sender, EventArgs e)
        {
            txtObsHino.Text = modulos.listaParametros[0].TesteObsHino;
            txtObsHino.Focus();
        }
        private void txtObsHino_Enter(object sender, EventArgs e)
        {
            lblObsPadraoHino.Visible = false;
        }
        private void txtObsHino_Leave(object sender, EventArgs e)
        {
            if (txtObsHino.TextLength > 0)
            {
                lblObsPadraoHino.Visible = false;
            }
            else
            {
                lblObsPadraoHino.Visible = true;
            }
        }

        #endregion

        #region Aba Mts

        private void btnMtsInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparMts();
                enabledMts();

                if (listaMts == null || listaMts.Count < 1)
                {
                    apoio.Aguarde();
                    carregaMts();
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
        private void btnMtsExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                deleteMts(gridMts.CurrentRow.Index);
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
        private void btnDefinirLicaoMts_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Efetuando Gravações...");
                salvarMts(Convert.ToString(cboMts.SelectedValue));
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
        private void btnCancelarLicaoMts_Click(object sender, EventArgs e)
        {
            try
            {
                limparMts();
                disabledMts();
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
        private void cboMts_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMts.SelectedValue != null)
                {
                    foreach (MOD_metodos linha in listaMts)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodMetodo.Equals(Convert.ToString(cboMts.SelectedValue)))
                        {
                            lblQtdeMts.Enabled = true;
                            txtQtdeMts.Enabled = true;
                            break;
                        }
                    }
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
        private void gridMts_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermMts(gridMts);
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
        private void gridMts_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!gridMts.Equals(null) && gridMts.Rows.Count > 0)
                {
                    CodPreTesteMts = gridMts["CodPreTesteMts", gridMts.CurrentRow.Index].Value.ToString();
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

        private void optMtsSolfejo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMtsSolfejo.Checked.Equals(true))
                {
                    lblTipoMts.Text = "Solfejo";
                }
                else
                {
                    lblTipoMts.Text = string.Empty;
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
        private void optMtsRitmo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMtsRitmo.Checked.Equals(true))
                {
                    lblTipoMts.Text = "Ritmo";
                }
                else
                {
                    lblTipoMts.Text = string.Empty;
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
        private void lblObsPadraoMts_Click(object sender, EventArgs e)
        {
            txtObsMts.Text = modulos.listaParametros[0].TesteObsMts;
            txtObsMts.Focus();
        }
        private void txtObsMts_Enter(object sender, EventArgs e)
        {
            lblObsPadraoMts.Visible = false;
        }
        private void txtObsMts_Leave(object sender, EventArgs e)
        {
            if (txtObsMts.TextLength > 0)
            {
                lblObsPadraoMts.Visible = false;
            }
            else
            {
                lblObsPadraoMts.Visible = true;
            }
        }

        #endregion

        #region Aba Escala

        private void btnEscalaInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparEscala();
                enabledEscala();

                if (listaTipoEscala == null || listaTipoEscala.Count < 1)
                {
                    apoio.Aguarde();
                    carregaTipoEscala(lblCodInstrumento.Text);
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
        private void btnEscalaExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                deleteEscala(gridEscala.CurrentRow.Index);
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
        private void btnDefinirLicaoEscala_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Efetuando Gravações...");
                salvarEscala(Convert.ToString(cboTipoEscala.SelectedValue));
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
        private void btnCancelarLicaoEscala_Click(object sender, EventArgs e)
        {
            try
            {
                limparEscala();
                disabledEscala();
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
        private void cboTipoEscala_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoEscala.SelectedValue != null)
                {
                    foreach (MOD_tipoEscala linha in listaTipoEscala)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodTipoEscala.Equals(Convert.ToString(cboTipoEscala.SelectedValue)))
                        {
                            lblQtdeEscala.Enabled = true;
                            txtQtdeEscala.Enabled = true;
                            break;
                        }
                    }
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
        private void gridEscala_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermEscala(gridEscala);
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
        private void gridEscala_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!gridEscala.Equals(null) && gridEscala.Rows.Count > 0)
                {
                    CodPreTesteEscala = gridEscala["CodPreTesteEscala", gridEscala.CurrentRow.Index].Value.ToString();
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
        private void lblObsPadraoEsc_Click(object sender, EventArgs e)
        {
            txtObsEsc.Text = modulos.listaParametros[0].TesteObsEsc;
            txtObsEsc.Focus();
        }
        private void txtObsEsc_Enter(object sender, EventArgs e)
        {
            lblObsPadraoEsc.Visible = false;
        }
        private void txtObsEsc_Leave(object sender, EventArgs e)
        {
            if (txtObsEsc.TextLength > 0)
            {
                lblObsPadraoEsc.Visible = false;
            }
            else
            {
                lblObsPadraoEsc.Visible = true;
            }
        }

        #endregion

        #region Aba Teoria

        private void btnTeoriaInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparTeoria();
                enabledTeoria();
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
        private void btnTeoriaExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                deleteTeoria(gridTeoria.CurrentRow.Index);
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
        private void btnDefinirLicaoTeoria_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Efetuando Gravações...");
                salvarTeoria(Convert.ToString(cboNivelTeoria.Text));
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
        private void btnCancelarLicaoTeoria_Click(object sender, EventArgs e)
        {
            try
            {
                limparTeoria();
                disabledTeoria();
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
        private void gridTeoria_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermTeoria(gridTeoria);
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
        private void gridTeoria_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (!gridTeoria.Equals(null) && gridTeoria.Rows.Count > 0)
                {
                    CodPreTesteTeoria = gridTeoria["CodPreTesteTeoria", gridTeoria.CurrentRow.Index].Value.ToString();
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
        private void lblObsPadraoTeoria_Click(object sender, EventArgs e)
        {
            txtObsTeoria.Text = modulos.listaParametros[0].TesteObsTeoria;
            txtObsTeoria.Focus();
        }
        private void txtObsTeoria_Enter(object sender, EventArgs e)
        {
            lblObsPadraoTeoria.Visible = false;
        }
        private void txtObsTeoria_Leave(object sender, EventArgs e)
        {
            if (txtObsTeoria.TextLength > 0)
            {
                lblObsPadraoTeoria.Visible = false;
            }
            else
            {
                lblObsPadraoTeoria.Visible = true;
            }
        }

        #endregion

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
                    objBLL = new BLL_preTesteFicha();

                    if (Convert.ToInt64(txtFicha.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.inserir(criarTabela());
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.salvar(criarTabela());
                    }

                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmPreTeste"))
                    {
                        ((frmPreTeste)formChama).buscarFichas(txtCodPreTeste.Text);
                    }

                    FormClosing -= new FormClosingEventHandler(frmFichaPreTeste_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmFichaPreTeste_FormClosing);
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
                if (optRjm.Checked.Equals(false) && optMeiaHora.Checked.Equals(false) && optTroca.Checked.Equals(false) && optCulto.Checked.Equals(false) && optOficial.Checked.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Informe o tipo de Pré-Teste.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(txtSolicita.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Solicitação! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblPessoa.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aluno! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(txtDataExame.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Data do Exame! Campo obrigatório.";
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
        private MOD_preTesteFicha criarTabela()
        {
            try
            {
                objEnt = new MOD_preTesteFicha();
                objEnt.CodFichaPreTeste = txtFicha.Text;
                objEnt.CodPreTeste = txtCodPreTeste.Text;
                objEnt.Tipo = lblTipo.Text;
                objEnt.CodSolicitaTeste = txtSolicita.Text;
                objEnt.CodCandidato = txtPessoa.Text;
                objEnt.NomeCandidato = lblPessoa.Text;
                objEnt.CodInstrumento = lblCodInstrumento.Text;
                objEnt.DescInstrumento = txtInstrumento.Text;
                objEnt.Data = txtData.Text;
                objEnt.Hora = txtHora.Text;
                objEnt.Obs = txtObs.Text;
                objEnt.ObsMet = txtObsMet.Text;
                objEnt.ObsMts = txtObsMts.Text;
                objEnt.ObsHino = txtObsHino.Text;
                objEnt.ObsEsc = txtObsEsc.Text;
                objEnt.ObsTeoria = txtObsTeoria.Text;

                //retorna o objeto Aba Metodo
                if (listaTesteMetodo != null || listaDeleteTesteMetodo != null)
                {
                    objEnt.listaPreTesteMet = new BindingList<MOD_preTesteMet>();
                    objEnt.listaDeletePreTesteMet = new List<MOD_preTesteMet>();
                    objEnt.listaPreTesteMet = listaTesteMetodo;
                    objEnt.listaDeletePreTesteMet = listaDeleteTesteMetodo;
                }

                //retorna o objeto Aba Hinario
                if (listaTesteHino != null || listaDeleteTesteHino != null)
                {
                    objEnt.listaPreTesteHino = new BindingList<MOD_preTesteHino>();
                    objEnt.listaDeletePreTesteHino = new List<MOD_preTesteHino>();
                    objEnt.listaPreTesteHino = listaTesteHino;
                    objEnt.listaDeletePreTesteHino = listaDeleteTesteHino;
                }

                //retorna o objeto Aba Mts
                if (listaTesteMts != null || listaDeleteTesteMts != null)
                {
                    objEnt.listaPreTesteMts = new BindingList<MOD_preTesteMts>();
                    objEnt.listaDeletePreTesteMts = new List<MOD_preTesteMts>();
                    objEnt.listaPreTesteMts = listaTesteMts;
                    objEnt.listaDeletePreTesteMts = listaDeleteTesteMts;
                }

                //retorna o objeto Aba Escala
                if (listaTesteEscala != null || listaDeleteTesteEscala != null)
                {
                    objEnt.listaPreTesteEscala = new BindingList<MOD_preTesteEscala>();
                    objEnt.listaDeletePreTesteEscala = new List<MOD_preTesteEscala>();
                    objEnt.listaPreTesteEscala = listaTesteEscala;
                    objEnt.listaDeletePreTesteEscala = listaDeleteTesteEscala;
                }

                //retorna o objeto Aba Teoria
                if (listaTesteTeoria != null || listaDeleteTesteTeoria != null)
                {
                    objEnt.listaPreTesteTeoria = new BindingList<MOD_preTesteTeoria>();
                    objEnt.listaDeletePreTesteTeoria = new List<MOD_preTesteTeoria>();
                    objEnt.listaPreTesteTeoria = listaTesteTeoria;
                    objEnt.listaDeletePreTesteTeoria = listaDeleteTesteTeoria;
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
                
                if (Text.Equals("Editando Ficha Pré-Teste"))
                {
                    lblSolicita.Enabled = false;
                    txtSolicita.Enabled = false;
                    btnSolicita.Enabled = false;
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
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaSolicita"></param>
        internal void preencher(List<MOD_preTesteFicha> listaFicha)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtFicha.Text = listaFicha[0].CodFichaPreTeste;
                lblTipo.Text = listaFicha[0].Tipo;
                txtSolicita.Text = listaFicha[0].CodSolicitaTeste;
                txtPessoa.Text = listaFicha[0].CodCandidato;
                lblPessoa.Text = listaFicha[0].NomeCandidato;
                lblCodInstrumento.Text = listaFicha[0].CodInstrumento;
                txtInstrumento.Text = listaFicha[0].DescInstrumento;
                txtData.Text = listaFicha[0].Data;
                txtHora.Text = listaFicha[0].Hora;
                txtCodUsuario.Text = listaFicha[0].CodUsuario;
                txtUsuario.Text = listaFicha[0].Usuario;
                txtHora.Text = listaFicha[0].Hora;
                txtObs.Text = listaFicha[0].Obs;
                txtObsMet.Text = listaFicha[0].ObsMet;
                txtObsMts.Text = listaFicha[0].ObsMts;
                txtObsHino.Text = listaFicha[0].ObsHino;
                txtObsEsc.Text = listaFicha[0].ObsEsc;
                txtObsTeoria.Text = listaFicha[0].ObsTeoria;

                //Preencher a Aba Metodo
                carregaMetodoFicha(listaFicha[0].listaPreTesteMet);
                //Preencher a Aba Hinario
                carregaHinarioFicha(listaFicha[0].listaPreTesteHino);
                //Preencher a Aba Mts
                carregaMtsFicha(listaFicha[0].listaPreTesteMts);
                //Preencher a Aba Escala
                carregaEscalaFicha(listaFicha[0].listaPreTesteEscala);
                //Preencher a Aba Teoria
                carregaTeoriaFicha(listaFicha[0].listaPreTesteTeoria);

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
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            tabTipo.Focus();
        }

        /// <summary>
        /// Verifica os buttons
        /// </summary>
        private void verificacoes()
        {
            try
            {
                if (lblTipo.Text.Equals("Reunião de Jovens"))
                {
                    optRjm.Checked = true;
                }
                else if (lblTipo.Text.Equals("Culto Oficial"))
                {
                    optCulto.Checked = true;
                }
                else if (lblTipo.Text.Equals("Oficialização"))
                {
                    optOficial.Checked = true;
                }
                else if (lblTipo.Text.Equals("Meia Hora"))
                {
                    optMeiaHora.Checked = true;
                }
                else if (lblTipo.Text.Equals("Troca Instrumento"))
                {
                    optTroca.Checked = true;
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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa">Código da Pessoa</param>
        /// <param name="Campo">Campo a ser pesquisado</param>
        internal void carregaPessoa(string vCodPessoa, string Campo)
        {
            try
            {
                List<MOD_pessoa> listaPesFiltro = new List<MOD_pessoa>();

                objBLL_Pessoa = new BLL_pessoa();
                listaPessoa = objBLL_Pessoa.buscarCod(vCodPessoa, modulos.CodUsuarioCCB, true);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    if (Campo.Equals("Aluno"))
                    {
                        listaPesFiltro = listaPessoa.Where(x => Convert.ToInt16(x.CodCargo).Equals(10) ||
                                                           Convert.ToInt16(x.CodCargo).Equals(11) ||
                                                           Convert.ToInt16(x.CodCargo).Equals(12)).ToList();

                        if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                        {
                            txtPessoa.Text = listaPesFiltro[0].CodPessoa;
                            lblPessoa.Text = listaPesFiltro[0].Nome;
                            txtInstrumento.Text = listaPesFiltro[0].DescInstrumento;
                            lblCodInstrumento.Text = listaPesFiltro[0].CodInstrumento;
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
        /// Função que carrega a Solicitação pesquisado pelo Código
        /// </summary>
        /// <param name="vCodSolicita">Código da Solicitação</param>
        internal void carregaSolicita(string vCodSolicita)
        {
            try
            {
                objBLL_Solicita = new BLL_solicitaTeste();
                listaSolicita = objBLL_Solicita.buscarCod(vCodSolicita, modulos.CodUsuarioCCB, "Pendente");

                if (listaSolicita != null && listaSolicita.Count > 0)
                {
                    if (listaSolicita != null && listaSolicita.Count > 0)
                    {
                        txtSolicita.Text = listaSolicita[0].CodSolicitaTeste;
                        lblSolicita.Text = listaSolicita[0].CodSolicitaTeste;
                        txtPessoa.Text = listaSolicita[0].CodPessoa;
                        lblPessoa.Text = listaSolicita[0].Nome;
                        txtInstrumento.Text = listaSolicita[0].DescInstrumento;
                        lblCodInstrumento.Text = listaSolicita[0].CodInstrumento;
                        lblTipo.Text = listaSolicita[0].Tipo;

                        //Verifica o Tipo de teste e marca os buttons
                        if (lblTipo.Text.Equals("Reunião de Jovens"))
                        {
                            optRjm.Checked = true;
                        }
                        else if (lblTipo.Text.Equals("Meia Hora"))
                        {
                            optMeiaHora.Checked = true;
                        }
                        else if (lblTipo.Text.Equals("Culto Oficial"))
                        {
                            optCulto.Checked = true;
                        }
                        else if (lblTipo.Text.Equals("Oficialização"))
                        {
                            optOficial.Checked = true;
                        }
                        else if (lblTipo.Text.Equals("Troca Instrumento"))
                        {
                            optTroca.Checked = true;
                        }
                    }
                    else
                    {
                        abrirForm("frmSolicitacao", string.Empty);
                    }

                    //ValidarPessoa();
                }
                else
                {
                    abrirForm("frmSolicitacao", string.Empty);
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
                    if (Campo.Equals("Aluno"))
                    {
                        txtPessoa.Text = string.Empty;
                        lblPessoa.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, "Aluno");
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
                    }
                }
                if (form.Equals("frmSolicitacao"))
                {
                    txtSolicita.Text = string.Empty;
                    lblSolicita.Text = string.Empty;

                    formulario = new frmPesquisaSolicita(this);
                    ((frmPesquisaSolicita)formulario).MdiParent = MdiParent;
                    ((frmPesquisaSolicita)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaSolicita)formulario));
                    ((frmPesquisaSolicita)formulario).Show();
                    ((frmPesquisaSolicita)formulario).BringToFront();
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

        #region Aba Metodos

        /// <summary>
        /// Função que valida os campos da aba Metodo
        /// </summary>
        private bool ValidarControlesMetodos()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (string.IsNullOrEmpty(cboMetodo.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Métodos > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtQtdeMet.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Métodos > Quantidade de lições não pode ser zero.";
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
        /// Função que preenche o ComboBox Metodos por Pessoa
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodoPessoa(string Pessoa)
        {
            try
            {
                objBLL_Pessoa = new BLL_pessoa();
                listaPessoaMetodo = new List<MOD_pessoaMetodo>();

                listaPessoaMetodo = objBLL_Pessoa.buscarMetodoPessoa(Pessoa);
                cboMetodo.DataSource = listaPessoaMetodo;
                cboMetodo.ValueMember = "CodMetodo";
                cboMetodo.DisplayMember = "DescMetodo";
                cboMetodo.SelectedIndex = (-1);
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
        /// Função que preenche o ComboBox Metodos por Instrumento
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodoInstr(string CodInstr)
        {
            try
            {
                objBLL_InstrMet = new BLL_metodoInstr();
                listaInstrMet = new BindingList<MOD_metodoInstr>();

                listaInstrMet = objBLL_InstrMet.buscarInstrumento(CodInstr, lblTipo.Text);
                cboMetodo.DataSource = listaInstrMet;
                cboMetodo.ValueMember = "CodMetodo";
                cboMetodo.DisplayMember = "DescMetodo";
                cboMetodo.SelectedIndex = (-1);
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
        private void criarLicaoMetodo(string CodMetodoSelecao)
        {
            try
            {
                objBLL_LicaoMet = new BLL_licaoTesteMet();
                listaLicaoMet = new List<MOD_licaoTesteMet>();
                objBLL_Metodos = new BLL_metodos();

                ///Faz a verificação se as lições é escolhido pelo sistema ou pelo candidato
                List<MOD_metodos> listaMetSelecao = new List<MOD_metodos>();
                listaMetSelecao = objBLL_Metodos.buscarCod(CodMetodoSelecao);

                //Eliminar os registros anteriores, que são do mesmo mesmo método
                deleteMetodos(listaMetSelecao[0].CodMetodo);

                if (listaMetSelecao[0].TipoEscolha.Equals("Sistema"))
                {
                    List<MOD_licaoTesteMet> listaRnd = new List<MOD_licaoTesteMet>();
                    listaLicaoMet = objBLL_LicaoMet.buscarLicaoMet(lblCodInstrumento.Text, CodMetodoSelecao, lblTipo.Text);
                    Random rnd = new Random();
                    listaRnd = listaLicaoMet.OrderBy(p => rnd.Next()).Take(Convert.ToInt32(txtQtdeMet.Value)).ToList();

                    foreach (MOD_licaoTesteMet ent in listaRnd)
                    {
                        objEnt_TesteMet = new MOD_preTesteMet();

                        objEnt_TesteMet.CodPreTesteMet = "0";
                        objEnt_TesteMet.CodFichaPreTeste = txtFicha.Text;
                        objEnt_TesteMet.CodMetodo = ent.CodMetodo;
                        objEnt_TesteMet.DescMetodo = ent.DescMetodo;
                        objEnt_TesteMet.Tipo = ent.AplicaEm;
                        objEnt_TesteMet.TipoEscolha = ent.TipoEscolha;
                        objEnt_TesteMet.PaginaFase = ent.PaginaFase;
                        objEnt_TesteMet.FaseMet = ent.FaseMet;
                        objEnt_TesteMet.PaginaMet = ent.PaginaMet;
                        objEnt_TesteMet.LicaoMet = ent.LicaoMet;
                        objEnt_TesteMet.FasePagLicao = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseMet.PadLeft(3, '0') + " - Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0') : "Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0');

                        listaTesteMetodo.Add(objEnt_TesteMet);
                    }
                    objBind_TesteMetodo.DataSource = listaTesteMetodo;
                }
                else
                {
                    List<MOD_pessoaMetodoLicao> listaRnd = new List<MOD_pessoaMetodoLicao>();
                    listaPesMetLicao = objBLL_PesMetLicao.buscarPessoaMetodo(txtPessoa.Text, CodMetodoSelecao);
                    Random rnd = new Random();
                    listaRnd = listaPesMetLicao.OrderBy(p => rnd.Next()).Take(Convert.ToInt32(txtQtdeMet.Value)).ToList();

                    foreach (MOD_pessoaMetodoLicao ent in listaRnd)
                    {
                        objEnt_TesteMet = new MOD_preTesteMet();

                        objEnt_TesteMet.CodPreTesteMet = "0";
                        objEnt_TesteMet.CodFichaPreTeste = txtFicha.Text;
                        objEnt_TesteMet.CodMetodo = ent.CodMetodo;
                        objEnt_TesteMet.DescMetodo = ent.DescMetodo;
                        objEnt_TesteMet.Tipo = ent.Tipo;
                        objEnt_TesteMet.TipoEscolha = ent.TipoEscolha;
                        objEnt_TesteMet.PaginaFase = ent.PaginaFase;
                        objEnt_TesteMet.FaseMet = ent.Fase;
                        objEnt_TesteMet.PaginaMet = ent.Pagina;
                        objEnt_TesteMet.LicaoMet = ent.Licao;
                        objEnt_TesteMet.FasePagLicao = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.Fase.PadLeft(3, '0') + " - Pág.: " + ent.Pagina.PadLeft(3, '0') + " - Lição: " + ent.Licao.PadLeft(3, '0') : "Pág.: " + ent.Pagina.PadLeft(3, '0') + " - Lição: " + ent.Licao.PadLeft(3, '0');

                        listaTesteMetodo.Add(objEnt_TesteMet);
                    }
                    objBind_TesteMetodo.DataSource = listaTesteMetodo;
                }

                montaGridMet(gridMetodo);
                ///vincula a lista ao DataSource do DataGriView
                gridMetodo.DataSource = objBind_TesteMetodo;

                limparMetodo();
                disabledMetodo();
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

        ///<summary> Montar DataGrid Metodo
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Metodo, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridMet(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodPreTesteMet";
            colCod.Name = "CodPreTesteMet";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colFicha = new DataGridViewTextBoxColumn();
            colFicha.DataPropertyName = "CodFichaPreTeste";
            colFicha.Name = "CodFichaPreTeste";
            colFicha.HeaderText = "CodFichaPreTeste";
            colFicha.Width = 60;
            colFicha.Frozen = false;
            colFicha.MinimumWidth = 45;
            colFicha.ReadOnly = true;
            colFicha.FillWeight = 100;
            colFicha.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFicha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFicha.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodMet = new DataGridViewTextBoxColumn();
            colCodMet.DataPropertyName = "CodMetodo";
            colCodMet.Name = "CodMetodo";
            colCodMet.HeaderText = "CodMetodo";
            colCodMet.Width = 60;
            colCodMet.Frozen = false;
            colCodMet.MinimumWidth = 45;
            colCodMet.ReadOnly = true;
            colCodMet.FillWeight = 100;
            colCodMet.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodMet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodMet.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colMetodo = new DataGridViewTextBoxColumn();
            colMetodo.DataPropertyName = "DescMetodo";
            colMetodo.Name = "DescMetodo";
            colMetodo.HeaderText = "Método";
            colMetodo.Width = 120;
            colMetodo.Frozen = false;
            colMetodo.MinimumWidth = 100;
            colMetodo.ReadOnly = true;
            colMetodo.FillWeight = 100;
            colMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMetodo.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "Tipo";
            colTipo.Name = "Tipo";
            colTipo.HeaderText = "Tipo Aplicação";
            colTipo.Width = 150;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 130;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colEscolha = new DataGridViewTextBoxColumn();
            colEscolha.DataPropertyName = "TipoEscolha";
            colEscolha.Name = "TipoEscolha";
            colEscolha.HeaderText = "Tipo Escolha";
            colEscolha.Width = 100;
            colEscolha.Frozen = false;
            colEscolha.MinimumWidth = 80;
            colEscolha.ReadOnly = true;
            colEscolha.FillWeight = 100;
            colEscolha.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEscolha.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colPagFase = new DataGridViewTextBoxColumn();
            colPagFase.DataPropertyName = "PaginaFase";
            colPagFase.Name = "PaginaFase";
            colPagFase.HeaderText = "Pág/Fase";
            colPagFase.Width = 80;
            colPagFase.Frozen = false;
            colPagFase.MinimumWidth = 70;
            colPagFase.ReadOnly = true;
            colPagFase.FillWeight = 100;
            colPagFase.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPagFase.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colFase = new DataGridViewTextBoxColumn();
            colFase.DataPropertyName = "FasePagLicao";
            colFase.Name = "FasePagLicao";
            colFase.HeaderText = "Fase/Página/Lição";
            colFase.Width = 150;
            colFase.Frozen = false;
            colFase.MinimumWidth = 130;
            colFase.ReadOnly = true;
            colFase.FillWeight = 100;
            colFase.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFase.Visible = true;
            /////5ª coluna
            //DataGridViewTextBoxColumn colPag = new DataGridViewTextBoxColumn();
            //colPag.DataPropertyName = "PaginaMet";
            //colPag.Name = "PaginaMet";
            //colPag.HeaderText = "Página";
            //colPag.Width = 70;
            //colPag.Frozen = false;
            //colPag.MinimumWidth = 50;
            //colPag.ReadOnly = true;
            //colPag.FillWeight = 100;
            //colPag.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            //colPag.Visible = true;
            /////5ª coluna
            //DataGridViewTextBoxColumn colLicao = new DataGridViewTextBoxColumn();
            //colLicao.DataPropertyName = "LicaoMet";
            //colLicao.Name = "LicaoMet";
            //colLicao.HeaderText = "Lição";
            //colLicao.Width = 70;
            //colLicao.Frozen = false;
            //colLicao.MinimumWidth = 50;
            //colLicao.ReadOnly = true;
            //colLicao.FillWeight = 100;
            //colLicao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            //colLicao.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colFicha);
            dataGrid.Columns.Add(colCodMet);
            dataGrid.Columns.Add(colMetodo);
            dataGrid.Columns.Add(colEscolha);
            dataGrid.Columns.Add(colPagFase);
            dataGrid.Columns.Add(colFase);
            dataGrid.Columns.Add(colTipo);
            //dataGrid.Columns.Add(colPag);
            //dataGrid.Columns.Add(colLicao);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        /// <summary>
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarMetodo(string CodMetodoSelecao)
        {
            try
            {
                if (ValidarControlesMetodos().Equals(true))
                {
                    //Carrega as licoes selecionadas
                    criarLicaoMetodo(CodMetodoSelecao);

                    //Limpa os controle e desabilita
                    limparMetodo();
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
        /// Função que Deleta a linha selecionada no gridMetodo
        /// </summary>
        private void deleteMetodo(int Indice)
        {
            try
            {
                MOD_preTesteMet ent = new MOD_preTesteMet();
                ent.CodPreTesteMet = listaTesteMetodo[Indice].CodPreTesteMet;

                //Insere a linha na Lista Delete
                listaDeleteTesteMetodo.Add(ent);
                //Exclui a linha da lista
                listaTesteMetodo.RemoveAt(Indice);
                listaTesteMetodo.ResetBindings();
                
                //Seleciona a linha anterior a excluida
                if (gridMetodo.RowCount > 0)
                {
                    if (!gridMetodo.Rows[0].Selected.Equals(true))
                    {
                        gridMetodo.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridMetodo.Rows[gridMetodo.RowCount - 1].Selected = true;
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
        /// <summary>
        /// Função que Deleta os Metodos que serão sobrepostos pela nova inserção
        /// </summary>
        private void deleteMetodos(string CodMetodos)
        {
            try
            {
                if (listaTesteMetodo != null && listaTesteMetodo.Count > 0)
                {
                    List<MOD_preTesteMet> listaNova = new List<MOD_preTesteMet>();
                    listaNova.AddRange(listaTesteMetodo);

                    //for (int i = 0; i < listaTesteMts.Count; i++)
                    foreach (MOD_preTesteMet ent in listaNova)
                    {
                        if (ent.CodMetodo.Equals(CodMetodos))
                        {
                            MOD_preTesteMet objEnt_Met = new MOD_preTesteMet();
                            objEnt_Met.CodPreTesteMet = ent.CodPreTesteMet;
                            objEnt_Met.CodFichaPreTeste = txtFicha.Text;
                            objEnt_Met.CodMetodo = ent.CodMetodo;
                            objEnt_Met.DescMetodo = ent.DescMetodo;
                            objEnt_Met.Tipo = ent.Tipo;
                            objEnt_Met.TipoEscolha = ent.TipoEscolha;
                            objEnt_Met.PaginaFase = ent.PaginaFase;
                            objEnt_Met.FaseMet = ent.FaseMet;
                            objEnt_Met.PaginaMet = ent.PaginaMet;
                            objEnt_Met.LicaoMet = ent.LicaoMet;
                            objEnt_Met.FasePagLicao = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseMet.PadLeft(3, '0') + " - Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0') : "Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0');


                            //Insere a linha na Lista Delete
                            listaDeleteTesteMetodo.Add(objEnt_Met);
                            listaTesteMetodo.Remove(ent);
                        }
                    }
                    ////atualiza a lista
                    listaTesteMetodo.ResetBindings();
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledMetodo()
        {
            try
            {
                gpoMetodo.Enabled = true;
                btnDefinirLicaoMet.Enabled = true;
                gridMetodo.Enabled = false;
                btnMetIns.Enabled = false;
                btnMetExcluir.Enabled = false;
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
        internal void disabledMetodo()
        {
            try
            {
                verPermMetodo(gridMetodo);
                gridMetodo.Enabled = true;
                btnMetIns.Focus();
                gpoMetodo.Enabled = false;
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
        /// Função que limpa os controle para Inserir novo metodo
        /// </summary>
        private void limparMetodo()
        {
            try
            {
                cboMetodo.SelectedIndex = (-1);
                txtQtdeMet.Value = 1;
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
        /// Função que carrega as Lições da Aba Metodo
        /// </summary>
        private void carregaMetodoFicha(BindingList<MOD_preTesteMet> listaFichaMet)
        {
            try
            {
                listaTesteMetodo = listaFichaMet;
                objBind_TesteMetodo.DataSource = listaTesteMetodo;
                montaGridMet(gridMetodo);
                ///vincula a lista ao DataSource do DataGriView
                gridMetodo.DataSource = objBind_TesteMetodo;
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

        #region Aba Hinario

        /// <summary>
        /// Função que valida os campos da aba Hinário
        /// </summary>
        private bool ValidarControlesHinario()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (string.IsNullOrEmpty(cboHinoHinario.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Hinário > Hinário! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtQtdeHino.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Hinário > Quantidade de hinos não pode ser zero.";
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
        /// Função que preenche o ComboBox Hinario
        /// </summary>
        /// <returns></returns>
        internal void carregaHinario(string CodInstr)
        {
            try
            {
                objBLL_Instrumento = new BLL_instrumento();
                listaInstrHino = new List<MOD_instrumentoHinario>();

                listaInstrHino = objBLL_Instrumento.buscarInstrumentoHinario(CodInstr);
                cboHinoHinario.DataSource = listaInstrHino;
                cboHinoHinario.ValueMember = "CodHinario";
                cboHinoHinario.DisplayMember = "DescHinario";
                cboHinoHinario.SelectedIndex = (-1);
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
        /// Função que preenche os a serem aplicadas no Exame
        /// </summary>
        /// <returns></returns>
        private void criarLicaoHinario(string CodHinarioSelecao)
        {
            try
            {
                objBLL_LicaoHino = new BLL_licaoTesteHino();
                listaLicaoHino = new List<MOD_licaoTesteHino>();
                objBLL_Hino = new BLL_hinario();

                ///Faz a verificação se as lições é escolhido pelo sistema ou pelo candidato
                List<MOD_hinario> listaHinoSelecao = new List<MOD_hinario>();
                listaHinoSelecao = objBLL_Hino.buscarCod(CodHinarioSelecao);

                //Eliminar os registros anteriores, que são do mesmo mesmo método
                deleteHinarios(listaHinoSelecao[0].CodHinario);

                List<MOD_licaoTesteHino> listaRnd = new List<MOD_licaoTesteHino>();
                listaLicaoHino = objBLL_LicaoHino.buscarLicaoHino(lblCodInstrumento.Text, CodHinarioSelecao, lblTipo.Text);
                Random rnd = new Random();
                listaRnd = listaLicaoHino.OrderBy(p => rnd.Next()).Take(Convert.ToInt32(txtQtdeHino.Value)).ToList();

                foreach (MOD_licaoTesteHino ent in listaRnd)
                {
                    objEnt_TesteHino = new MOD_preTesteHino();

                    objEnt_TesteHino.CodPreTesteHino = "0";
                    objEnt_TesteHino.CodFichaPreTeste = txtFicha.Text;
                    objEnt_TesteHino.CodHinario = ent.CodHinario;
                    objEnt_TesteHino.DescHinario = ent.DescHinario;
                    objEnt_TesteHino.Tipo = ent.AplicaEm;
                    objEnt_TesteHino.Hino = ent.Hino;

                    listaTesteHino.Add(objEnt_TesteHino);
                }
                objBind_TesteHino.DataSource = listaTesteHino;

                montaGridHinario(gridHino);
                ///vincula a lista ao DataSource do DataGriView
                gridHino.DataSource = objBind_TesteHino;

                limparHinario();
                disabledHinario();
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

        ///<summary> Montar DataGrid Hinário
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Hinario, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridHinario(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodPreTesteHino";
            colCod.Name = "CodPreTesteHino";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colFicha = new DataGridViewTextBoxColumn();
            colFicha.DataPropertyName = "CodFichaPreTeste";
            colFicha.Name = "CodFichaPreTeste";
            colFicha.HeaderText = "CodFichaPreTeste";
            colFicha.Width = 60;
            colFicha.Frozen = false;
            colFicha.MinimumWidth = 45;
            colFicha.ReadOnly = true;
            colFicha.FillWeight = 100;
            colFicha.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFicha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFicha.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodHino = new DataGridViewTextBoxColumn();
            colCodHino.DataPropertyName = "CodHinario";
            colCodHino.Name = "CodHinario";
            colCodHino.HeaderText = "CodHinario";
            colCodHino.Width = 60;
            colCodHino.Frozen = false;
            colCodHino.MinimumWidth = 45;
            colCodHino.ReadOnly = true;
            colCodHino.FillWeight = 100;
            colCodHino.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodHino.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodHino.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colHinario = new DataGridViewTextBoxColumn();
            colHinario.DataPropertyName = "DescHinario";
            colHinario.Name = "DescHinario";
            colHinario.HeaderText = "Hinário";
            colHinario.Width = 120;
            colHinario.Frozen = false;
            colHinario.MinimumWidth = 100;
            colHinario.ReadOnly = true;
            colHinario.FillWeight = 100;
            colHinario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colHinario.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colHino = new DataGridViewTextBoxColumn();
            colHino.DataPropertyName = "Hino";
            colHino.Name = "Hino";
            colHino.HeaderText = "Hino";
            colHino.Width = 80;
            colHino.Frozen = false;
            colHino.MinimumWidth = 70;
            colHino.ReadOnly = true;
            colHino.FillWeight = 100;
            colHino.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHino.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "Tipo";
            colTipo.Name = "Tipo";
            colTipo.HeaderText = "Tipo Aplicação";
            colTipo.Width = 150;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 130;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colFicha);
            dataGrid.Columns.Add(colCodHino);
            dataGrid.Columns.Add(colHinario);
            dataGrid.Columns.Add(colHino);
            dataGrid.Columns.Add(colTipo);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        /// <summary>
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarHinario(string CodHinoSelecao)
        {
            try
            {
                if (ValidarControlesHinario().Equals(true))
                {
                    //Carrega as licoes selecionadas
                    criarLicaoHinario(CodHinoSelecao);

                    //Limpa os controle e desabilita
                    limparHinario();
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
        /// Função que Deleta a linha selecionada no gridHinario
        /// </summary>
        private void deleteHinario(int Indice)
        {
            try
            {
                MOD_preTesteHino ent = new MOD_preTesteHino();
                ent.CodPreTesteHino = listaTesteHino[Indice].CodPreTesteHino;

                //Insere a linha na Lista Delete
                listaDeleteTesteHino.Add(ent);
                //Exclui a linha da lista
                listaTesteHino.RemoveAt(Indice);
                listaTesteHino.ResetBindings();

                /////vincula a lista ao DataSource do DataGriView
                //gridHino.DataSource = listaTesteHino;

                //Seleciona a linha anterior a excluida
                if (gridHino.RowCount > 0)
                {
                    if (!gridHino.Rows[0].Selected.Equals(true))
                    {
                        gridHino.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridHino.Rows[gridHino.RowCount - 1].Selected = true;
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
        /// <summary>
        /// Função que Deleta os Hinarios que serão sobrepostos pela nova inserção
        /// </summary>
        private void deleteHinarios(string CodHinarios)
        {
            try
            {
                if (listaTesteHino != null && listaTesteHino.Count > 0)
                {
                    List<MOD_preTesteHino> listaNova = new List<MOD_preTesteHino>();
                    listaNova.AddRange(listaTesteHino);

                    foreach (MOD_preTesteHino ent in listaNova)
                    {
                        if (ent.CodHinario.Equals(CodHinarios))
                        {
                            MOD_preTesteHino objEnt_Hino = new MOD_preTesteHino();
                            objEnt_Hino.CodPreTesteHino = ent.CodPreTesteHino;
                            objEnt_Hino.CodFichaPreTeste = txtFicha.Text;
                            objEnt_Hino.CodHinario = ent.CodHinario;
                            objEnt_Hino.DescHinario = ent.DescHinario;
                            objEnt_Hino.Hino = ent.Hino;
                            objEnt_Hino.Tipo = ent.Tipo;
 
                            //Insere a linha na Lista Delete
                            listaDeleteTesteHino.Add(objEnt_Hino);
                            listaTesteHino.Remove(ent);
                        }
                    }
                    ////atualiza a lista
                    listaTesteHino.ResetBindings();
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledHinario()
        {
            try
            {
                gpoHino.Enabled = true;
                btnDefinirLicaoHino.Enabled = true;
                gridHino.Enabled = false;
                btnHinoInserir.Enabled = false;
                btnHinoExcluir.Enabled = false;
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
        internal void disabledHinario()
        {
            try
            {
                verPermHinario(gridHino);
                gridHino.Enabled = true;
                btnHinoInserir.Focus();
                gpoHino.Enabled = false;
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
        /// Função que limpa os controle para Inserir novo hino
        /// </summary>
        private void limparHinario()
        {
            try
            {
                cboHinoHinario.SelectedIndex = (-1);
                txtQtdeHino.Value = 1;
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
        /// Função que carrega as Lições da Aba Hinario
        /// </summary>
        private void carregaHinarioFicha(BindingList<MOD_preTesteHino> listaFichaHinario)
        {
            try
            {
                listaTesteHino = listaFichaHinario;
                objBind_TesteHino.DataSource = listaTesteHino;
                montaGridHinario(gridHino);
                ///vincula a lista ao DataSource do DataGriView
                gridHino.DataSource = objBind_TesteHino;
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

        #region Aba Mts

        /// <summary>
        /// Função que valida os campos da aba MTS
        /// </summary>
        private bool ValidarControlesMts()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (string.IsNullOrEmpty(cboMts.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblTipoMts.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Informe se será Solfejo ou Liguagem Ritmica.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtQtdeMts.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Quantidade de lições não pode ser zero.";
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
        /// Função que preenche o ComboBox MTS
        /// </summary>
        /// <returns></returns>
        internal void carregaMts()
        {
            try
            {
                objBLL_Metodos = new BLL_metodos();
                listaMts = new List<MOD_metodos>();

                listaMts = objBLL_Metodos.buscarTipo("Solfejo");

                cboMts.DataSource = listaMts;
                cboMts.ValueMember = "CodMetodo";
                cboMts.DisplayMember = "DescMetodo";
                cboMts.SelectedIndex = (-1);
                optMtsSolfejo.Checked = false;
                optMtsRitmo.Checked = false;
                lblTipoMts.Text = string.Empty;
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
        private void criarLicaoMts(string CodMtsSelecao)
        {
            try
            {
                objBLL_LicaoMts = new BLL_licaoTesteMts();
                listaLicaoMts = new List<MOD_licaoTesteMts>();
                objBLL_Metodos = new BLL_metodos();

                ///Faz a verificação se as lições
                List<MOD_metodos> listaMtsSelecao = new List<MOD_metodos>();
                listaMtsSelecao = objBLL_Metodos.buscarCod(CodMtsSelecao);

                //Eliminar os registros anteriores, que são do mesmo mesmo método
                deleteMetMts(lblTipoMts.Text);

                List<MOD_licaoTesteMts> listaRnd = new List<MOD_licaoTesteMts>();
                listaLicaoMts = objBLL_LicaoMts.buscarLicaoMts(lblTipo.Text, CodMtsSelecao, lblTipoMts.Text);
                Random rnd = new Random();
                listaRnd = listaLicaoMts.OrderBy(p => rnd.Next()).Take(Convert.ToInt32(txtQtdeMts.Value)).ToList();

                foreach (MOD_licaoTesteMts ent in listaRnd)
                {
                    objEnt_TesteMts = new MOD_preTesteMts();

                    objEnt_TesteMts.CodPreTesteMts = "0";
                    objEnt_TesteMts.CodFichaPreTeste = txtFicha.Text;
                    objEnt_TesteMts.CodMetodo = ent.CodMetMts;
                    objEnt_TesteMts.DescMetodo = ent.DescMetodo;
                    objEnt_TesteMts.Tipo = ent.AplicaEm;
                    objEnt_TesteMts.TipoMts = ent.TipoMts;
                    objEnt_TesteMts.ModuloMts = ent.ModuloMts;
                    objEnt_TesteMts.LicaoMts = ent.LicaoMts;
                    objEnt_TesteMts.ModuloLicao = "Módulo: " + ent.ModuloMts.PadLeft(2, '0') + " - Lição: " + ent.LicaoMts.PadLeft(2, '0');

                    listaTesteMts.Add(objEnt_TesteMts);
                }

                objBind_TesteMts.DataSource = listaTesteMts;

                montaGridMts(gridMts);
                ///vincula a lista ao DataSource do DataGriView
                gridMts.DataSource = objBind_TesteMts;

                limparMts();
                disabledMts();
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

        ///<summary> Montar DataGrid MTS
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta MTS, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridMts(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodPreTesteMts";
            colCod.Name = "CodPreTesteMts";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colFicha = new DataGridViewTextBoxColumn();
            colFicha.DataPropertyName = "CodFichaPreTeste";
            colFicha.Name = "CodFichaPreTeste";
            colFicha.HeaderText = "CodFichaPreTeste";
            colFicha.Width = 60;
            colFicha.Frozen = false;
            colFicha.MinimumWidth = 45;
            colFicha.ReadOnly = true;
            colFicha.FillWeight = 100;
            colFicha.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFicha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFicha.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodMet = new DataGridViewTextBoxColumn();
            colCodMet.DataPropertyName = "CodMetodo";
            colCodMet.Name = "CodMetodo";
            colCodMet.HeaderText = "CodMetodo";
            colCodMet.Width = 60;
            colCodMet.Frozen = false;
            colCodMet.MinimumWidth = 45;
            colCodMet.ReadOnly = true;
            colCodMet.FillWeight = 100;
            colCodMet.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodMet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodMet.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colMetodo = new DataGridViewTextBoxColumn();
            colMetodo.DataPropertyName = "DescMetodo";
            colMetodo.Name = "DescMetodo";
            colMetodo.HeaderText = "Método";
            colMetodo.Width = 120;
            colMetodo.Frozen = false;
            colMetodo.MinimumWidth = 100;
            colMetodo.ReadOnly = true;
            colMetodo.FillWeight = 100;
            colMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colMetodo.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "Tipo";
            colTipo.Name = "Tipo";
            colTipo.HeaderText = "Tipo Aplicação";
            colTipo.Width = 150;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 130;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipoMts = new DataGridViewTextBoxColumn();
            colTipoMts.DataPropertyName = "TipoMts";
            colTipoMts.Name = "TipoMts";
            colTipoMts.HeaderText = "Tipo Execução";
            colTipoMts.Width = 120;
            colTipoMts.Frozen = false;
            colTipoMts.MinimumWidth = 80;
            colTipoMts.ReadOnly = true;
            colTipoMts.FillWeight = 100;
            colTipoMts.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipoMts.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colMod = new DataGridViewTextBoxColumn();
            colMod.DataPropertyName = "ModuloLicao";
            colMod.Name = "ModuloLicao";
            colMod.HeaderText = "Módulo/Lição";
            colMod.Width = 150;
            colMod.Frozen = false;
            colMod.MinimumWidth = 100;
            colMod.ReadOnly = true;
            colMod.FillWeight = 100;
            colMod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colMod.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colFicha);
            dataGrid.Columns.Add(colCodMet);
            dataGrid.Columns.Add(colMetodo);
            dataGrid.Columns.Add(colTipoMts);
            dataGrid.Columns.Add(colMod);
            dataGrid.Columns.Add(colTipo);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        /// <summary>
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarMts(string CodMtsSelecao)
        {
            try
            {
                if (ValidarControlesMts().Equals(true))
                {
                    //Carrega as licoes selecionadas
                    criarLicaoMts(CodMtsSelecao);

                    //Limpa os controle e desabilita
                    limparMts();
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
        /// Função que Deleta a linha selecionada no gridMts
        /// </summary>
        private void deleteMts(int Indice)
        {
            try
            {
                MOD_preTesteMts ent = new MOD_preTesteMts();
                ent.CodPreTesteMts = listaTesteMts[Indice].CodPreTesteMts;

                //Insere a linha na Lista Delete
                listaDeleteTesteMts.Add(ent);
                //Exclui a linha da lista
                listaTesteMts.RemoveAt(Indice);
                listaTesteMts.ResetBindings();

                //Seleciona a linha anterior a excluida
                if (gridMts.RowCount > 0)
                {
                    if (!gridMts.Rows[0].Selected.Equals(true))
                    {
                        gridMts.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridMts.Rows[gridMts.RowCount - 1].Selected = true;
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
        /// <summary>
        /// Função que Deleta os Mts que serão sobrepostos pela nova inserção
        /// </summary>
        private void deleteMetMts(string TipoMts)
        {
            try
            {
                if (listaTesteMts != null && listaTesteMts.Count > 0)
                {
                    List<MOD_preTesteMts> listaNova = new List<MOD_preTesteMts>();
                    listaNova.AddRange(listaTesteMts);

                    //for (int i = 0; i < listaTesteMts.Count; i++)
                    foreach (MOD_preTesteMts ent in listaNova)
                    {
                        if (ent.TipoMts.Equals(TipoMts))
                        {
                            MOD_preTesteMts objEnt_Mts = new MOD_preTesteMts();
                            objEnt_Mts.CodPreTesteMts = ent.CodPreTesteMts;
                            objEnt_Mts.CodFichaPreTeste = txtFicha.Text;
                            objEnt_Mts.CodMetodo = ent.CodMetodo;
                            objEnt_Mts.DescMetodo = ent.DescMetodo;
                            objEnt_Mts.Tipo = ent.Tipo;
                            objEnt_Mts.TipoMts = ent.TipoMts;
                            objEnt_Mts.ModuloMts = ent.ModuloMts;
                            objEnt_Mts.LicaoMts = ent.LicaoMts;
                            objEnt_Mts.ModuloLicao = "Módulo: " + ent.ModuloMts.PadLeft(2, '0') + " - Lição: " + ent.LicaoMts.PadLeft(2, '0');

                            //Insere a linha na Lista Delete
                            listaDeleteTesteMts.Add(objEnt_Mts);
                            listaTesteMts.Remove(ent);
                        }
                    }
                    ////atualiza a lista
                    listaTesteMts.ResetBindings();
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledMts()
        {
            try
            {
                gpoMts.Enabled = true;
                btnDefinirLicaoMts.Enabled = true;
                gridMts.Enabled = false;
                btnMtsInserir.Enabled = false;
                btnMtsExcluir.Enabled = false;
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
        internal void disabledMts()
        {
            try
            {
                verPermMts(gridMts);
                gridMts.Enabled = true;
                btnMtsInserir.Focus();
                gpoMts.Enabled = false;
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
        /// Função que limpa os controle para Inserir novo metodo
        /// </summary>
        private void limparMts()
        {
            try
            {
                cboMts.SelectedIndex = (-1);
                optMtsSolfejo.Checked = false;
                optMtsRitmo.Checked = false;
                txtQtdeMts.Value = 1;
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
        /// Função que carrega as Lições da Aba Mts
        /// </summary>
        private void carregaMtsFicha(BindingList<MOD_preTesteMts> listaFichaMts)
        {
            try
            {
                listaTesteMts = listaFichaMts;
                objBind_TesteMts.DataSource = listaTesteMts;
                montaGridMts(gridMts);
                ///vincula a lista ao DataSource do DataGriView
                gridMts.DataSource = objBind_TesteMts;
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

        #region Aba Escala

        /// <summary>
        /// Função que valida os campos da aba Escala
        /// </summary>
        private bool ValidarControlesEscala()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (string.IsNullOrEmpty(cboTipoEscala.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Escala > Tipo de Escala! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtQtdeEscala.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Escala > Quantidade de escalas não pode ser zero.";
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
        /// Função que preenche o ComboBox Tipo de Escala
        /// </summary>
        /// <returns></returns>
        internal void carregaTipoEscala(string CodInstr)
        {
            try
            {
                objBLL_LicaoEscala = new BLL_licaoTesteEscala();
                listaTipoEscala = new List<MOD_tipoEscala>();

                listaTipoEscala = objBLL_LicaoEscala.buscarLicaoTipoEscala(CodInstr, lblTipo.Text);
                cboTipoEscala.DataSource = listaTipoEscala;
                cboTipoEscala.ValueMember = "CodTipoEscala";
                cboTipoEscala.DisplayMember = "DescTipo";
                cboTipoEscala.SelectedIndex = (-1);
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
        /// Função que preenche as escalas a serem aplicadas no Exame
        /// </summary>
        /// <returns></returns>
        private void criarLicaoEscala(string CodTipoEscalaSelecao)
        {
            try
            {
                objBLL_LicaoEscala = new BLL_licaoTesteEscala();
                listaLicaoEscala = new List<MOD_licaoTesteEscala>();
                BLL_escala objBLL_Escala = new BLL_escala();

                ///Faz a verificação se as lições é escolhido pelo sistema ou pelo candidato
                List<MOD_escala> listaEscalaSelecao = new List<MOD_escala>();
                listaEscalaSelecao = objBLL_Escala.buscarTipo(CodTipoEscalaSelecao);

                //Eliminar os registros anteriores, que são do mesmo mesmo método
                deleteEscalas(listaEscalaSelecao[0].CodTipoEscala);

                List<MOD_licaoTesteEscala> listaRnd = new List<MOD_licaoTesteEscala>();
                listaLicaoEscala = objBLL_LicaoEscala.buscarLicaoEscala(lblCodInstrumento.Text, CodTipoEscalaSelecao, lblTipo.Text);
                //listaLicaoEscala = listaLicaoEscala.Where(p => p.AplicaEm.Equals(lblTipo.Text)).ToList();

                Random rnd = new Random();
                listaRnd = listaLicaoEscala.OrderBy(p => rnd.Next()).Take(Convert.ToInt32(txtQtdeEscala.Value)).ToList();

                foreach (MOD_licaoTesteEscala ent in listaRnd)
                {
                    objEnt_TesteEscala = new MOD_preTesteEscala();

                    objEnt_TesteEscala.CodPreTesteEscala = "0";
                    objEnt_TesteEscala.CodFichaPreTeste = txtFicha.Text;
                    objEnt_TesteEscala.CodEscala = ent.CodEscala;
                    objEnt_TesteEscala.DescEscala = ent.DescEscala;
                    objEnt_TesteEscala.CodTipoEscala = ent.CodTipoEscala;
                    objEnt_TesteEscala.DescTipoEscala = ent.DescTipo;
                    objEnt_TesteEscala.Tipo = ent.AplicaEm;

                    listaTesteEscala.Add(objEnt_TesteEscala);
                }

                objBind_TesteEscala.DataSource = listaTesteEscala;

                montaGridEscala(gridEscala);
                ///vincula a lista ao DataSource do DataGriView
                gridEscala.DataSource = objBind_TesteEscala;

                limparEscala();
                disabledEscala();
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

        ///<summary> Montar DataGrid Escala
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Escala, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridEscala(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodPreTesteEscala";
            colCod.Name = "CodPreTesteEscala";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colFicha = new DataGridViewTextBoxColumn();
            colFicha.DataPropertyName = "CodFichaPreTeste";
            colFicha.Name = "CodFichaPreTeste";
            colFicha.HeaderText = "CodFichaPreTeste";
            colFicha.Width = 60;
            colFicha.Frozen = false;
            colFicha.MinimumWidth = 45;
            colFicha.ReadOnly = true;
            colFicha.FillWeight = 100;
            colFicha.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFicha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFicha.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodEsc = new DataGridViewTextBoxColumn();
            colCodEsc.DataPropertyName = "CodEscala";
            colCodEsc.Name = "CodEscala";
            colCodEsc.HeaderText = "CodEscala";
            colCodEsc.Width = 60;
            colCodEsc.Frozen = false;
            colCodEsc.MinimumWidth = 45;
            colCodEsc.ReadOnly = true;
            colCodEsc.FillWeight = 100;
            colCodEsc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodEsc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodEsc.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colDescEsc = new DataGridViewTextBoxColumn();
            colDescEsc.DataPropertyName = "DescEscala";
            colDescEsc.Name = "DescEscala";
            colDescEsc.HeaderText = "Escala";
            colDescEsc.Width = 120;
            colDescEsc.Frozen = false;
            colDescEsc.MinimumWidth = 100;
            colDescEsc.ReadOnly = true;
            colDescEsc.FillWeight = 100;
            colDescEsc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescEsc.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "Tipo";
            colTipo.Name = "Tipo";
            colTipo.HeaderText = "Tipo Aplicação";
            colTipo.Width = 150;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 130;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colDescTipo = new DataGridViewTextBoxColumn();
            colDescTipo.DataPropertyName = "DescTipoEscala";
            colDescTipo.Name = "DescTipoEscala";
            colDescTipo.HeaderText = "Modo Escala";
            colDescTipo.Width = 180;
            colDescTipo.Frozen = false;
            colDescTipo.MinimumWidth = 160;
            colDescTipo.ReadOnly = true;
            colDescTipo.FillWeight = 100;
            colDescTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDescTipo.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colFicha);
            dataGrid.Columns.Add(colDescTipo);
            dataGrid.Columns.Add(colCodEsc);
            dataGrid.Columns.Add(colDescEsc);
            dataGrid.Columns.Add(colTipo);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        /// <summary>
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarEscala(string CodEscalaSelecao)
        {
            try
            {
                if (ValidarControlesEscala().Equals(true))
                {
                    //Carrega as licoes selecionadas
                    criarLicaoEscala(CodEscalaSelecao);

                    //Limpa os controle e desabilita
                    limparEscala();
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
        /// Função que Deleta a linha selecionada no gridEscala
        /// </summary>
        private void deleteEscala(int Indice)
        {
            try
            {
                MOD_preTesteEscala ent = new MOD_preTesteEscala();
                ent.CodPreTesteEscala = listaTesteEscala[Indice].CodPreTesteEscala;

                //Insere a linha na Lista Delete
                listaDeleteTesteEscala.Add(ent);
                //Exclui a linha da lista
                listaTesteEscala.RemoveAt(Indice);
                listaTesteEscala.ResetBindings();

                //Seleciona a linha anterior a excluida
                if (gridEscala.RowCount > 0)
                {
                    if (!gridEscala.Rows[0].Selected.Equals(true))
                    {
                        gridEscala.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridEscala.Rows[gridEscala.RowCount - 1].Selected = true;
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
        /// <summary>
        /// Função que Deleta as Escalas que serão sobrepostos pela nova inserção
        /// </summary>
        private void deleteEscalas(string CodTipoEscala)
        {
            try
            {
                if (listaTesteEscala != null && listaTesteEscala.Count > 0)
                {
                    List<MOD_preTesteEscala> listaNova = new List<MOD_preTesteEscala>();
                    listaNova.AddRange(listaTesteEscala);

                    foreach (MOD_preTesteEscala ent in listaNova)
                    {
                        if (ent.CodTipoEscala.Equals(CodTipoEscala))
                        {
                            MOD_preTesteEscala objEnt_Esc = new MOD_preTesteEscala();
                            objEnt_Esc.CodPreTesteEscala = ent.CodPreTesteEscala;
                            objEnt_Esc.CodFichaPreTeste = txtFicha.Text;
                            objEnt_Esc.CodEscala = ent.CodEscala;
                            objEnt_Esc.DescEscala = ent.DescEscala;
                            objEnt_Esc.CodTipoEscala = ent.CodTipoEscala;
                            objEnt_Esc.DescTipoEscala = ent.DescTipoEscala;
                            objEnt_Esc.Tipo = ent.Tipo;

                            //Insere a linha na Lista Delete
                            listaDeleteTesteEscala.Add(objEnt_Esc);
                            listaTesteEscala.Remove(ent);
                        }
                    }
                    ////atualiza a lista
                    listaTesteEscala.ResetBindings();
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledEscala()
        {
            try
            {
                gpoEscala.Enabled = true;
                btnDefinirLicaoEscala.Enabled = true;
                gridEscala.Enabled = false;
                btnEscalaInserir.Enabled = false;
                btnEscalaExcluir.Enabled = false;
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
        internal void disabledEscala()
        {
            try
            {
                verPermEscala(gridEscala);
                gridEscala.Enabled = true;
                btnEscalaInserir.Focus();
                gpoEscala.Enabled = false;
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
        /// Função que limpa os controle para Inserir nova Escala
        /// </summary>
        private void limparEscala()
        {
            try
            {
                cboTipoEscala.SelectedIndex = (-1);
                txtQtdeEscala.Value = 1;
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
        /// Função que carrega as Lições da Aba Escala
        /// </summary>
        private void carregaEscalaFicha(BindingList<MOD_preTesteEscala> listaFichaEscala)
        {
            try
            {
                listaTesteEscala = listaFichaEscala;
                objBind_TesteEscala.DataSource = listaTesteEscala;
                montaGridEscala(gridEscala);
                ///vincula a lista ao DataSource do DataGriView
                gridEscala.DataSource = objBind_TesteEscala;
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

        #region Aba Teoria

        /// <summary>
        /// Função que valida os campos da aba Teoria
        /// </summary>
        private bool ValidarControlesTeoria()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (string.IsNullOrEmpty(cboNivelTeoria.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Teoria > Nível! Campo obrigatório.";
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
        /// Função que preenche os a serem aplicadas no Exame
        /// </summary>
        /// <returns></returns>
        private void criarLicaoTeoria(string Nivel)
        {
            try
            {
                objBLL_LicaoTeoria = new BLL_licaoTesteTeoria();
                listaLicaoTeoria = new List<MOD_licaoTesteTeoria>();
                objBLL_Teoria = new BLL_teoria();

                ///Faz a verificação se as lições é escolhido pelo sistema ou pelo candidato
                List<MOD_teoria> listaTeoriaSelecao = new List<MOD_teoria>();
                listaTeoriaSelecao = objBLL_Teoria.buscarNivel(Nivel, lblTipo.Text, "Avaliação");

                //Eliminar os registros anteriores, que são do mesmo mesmo método
                deleteTeorias(listaTeoriaSelecao[0].CodTeoria);

                List<MOD_licaoTesteTeoria> listaRnd = new List<MOD_licaoTesteTeoria>();
                listaLicaoTeoria = objBLL_LicaoTeoria.buscarLicaoTeoria(Nivel, lblTipo.Text, "Avaliação");
                Random rnd = new Random();
                listaRnd = listaLicaoTeoria.OrderBy(p => rnd.Next()).Take(Convert.ToInt32(1)).ToList();

                foreach (MOD_licaoTesteTeoria ent in listaRnd)
                {
                    objEnt_TesteTeoria = new MOD_preTesteTeoria();

                    objEnt_TesteTeoria.CodPreTesteTeoria = "0";
                    objEnt_TesteTeoria.CodFichaPreTeste = txtFicha.Text;
                    objEnt_TesteTeoria.CodTeoria = ent.CodTeoria;
                    objEnt_TesteTeoria.DescTeoria = ent.DescTeoria;
                    objEnt_TesteTeoria.Tipo = ent.AplicaEm;
                    objEnt_TesteTeoria.Nivel = ent.Nivel;
                    objEnt_TesteTeoria.Paginas = ent.Paginas;

                    listaTesteTeoria.Add(objEnt_TesteTeoria);
                }
                objBind_TesteTeoria.DataSource = listaTesteTeoria;

                montaGridTeoria(gridTeoria);
                ///vincula a lista ao DataSource do DataGriView
                gridTeoria.DataSource = objBind_TesteTeoria;

                limparTeoria();
                disabledTeoria();
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

        ///<summary> Montar DataGrid Teoria
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Teoria, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridTeoria(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodPreTesteTeoria";
            colCod.Name = "CodPreTesteTeoria";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colFicha = new DataGridViewTextBoxColumn();
            colFicha.DataPropertyName = "CodFichaPreTeste";
            colFicha.Name = "CodFichaPreTeste";
            colFicha.HeaderText = "CodFichaPreTeste";
            colFicha.Width = 60;
            colFicha.Frozen = false;
            colFicha.MinimumWidth = 45;
            colFicha.ReadOnly = true;
            colFicha.FillWeight = 100;
            colFicha.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFicha.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFicha.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodTeoria = new DataGridViewTextBoxColumn();
            colCodTeoria.DataPropertyName = "CodTeoria";
            colCodTeoria.Name = "CodTeoria";
            colCodTeoria.HeaderText = "CodTeoria";
            colCodTeoria.Width = 60;
            colCodTeoria.Frozen = false;
            colCodTeoria.MinimumWidth = 45;
            colCodTeoria.ReadOnly = true;
            colCodTeoria.FillWeight = 100;
            colCodTeoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodTeoria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodTeoria.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colDescTeoria = new DataGridViewTextBoxColumn();
            colDescTeoria.DataPropertyName = "DescTeoria";
            colDescTeoria.Name = "DescTeoria";
            colDescTeoria.HeaderText = "Teoria";
            colDescTeoria.Width = 120;
            colDescTeoria.Frozen = false;
            colDescTeoria.MinimumWidth = 100;
            colDescTeoria.ReadOnly = true;
            colDescTeoria.FillWeight = 100;
            colDescTeoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescTeoria.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "Tipo";
            colTipo.Name = "Tipo";
            colTipo.HeaderText = "Tipo Aplicação";
            colTipo.Width = 150;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 130;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colNivel = new DataGridViewTextBoxColumn();
            colNivel.DataPropertyName = "Nivel";
            colNivel.Name = "Nivel";
            colNivel.HeaderText = "Nível";
            colNivel.Width = 130;
            colNivel.Frozen = false;
            colNivel.MinimumWidth = 80;
            colNivel.ReadOnly = true;
            colNivel.FillWeight = 100;
            colNivel.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNivel.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colPaginas = new DataGridViewTextBoxColumn();
            colPaginas.DataPropertyName = "Paginas";
            colPaginas.Name = "Paginas";
            colPaginas.HeaderText = "Qtde Páginas";
            colPaginas.Width = 100;
            colPaginas.Frozen = false;
            colPaginas.MinimumWidth = 100;
            colPaginas.ReadOnly = true;
            colPaginas.FillWeight = 100;
            colPaginas.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPaginas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPaginas.DefaultCellStyle.Format = "000";
            colPaginas.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colFicha);
            dataGrid.Columns.Add(colNivel);
            dataGrid.Columns.Add(colCodTeoria);
            dataGrid.Columns.Add(colDescTeoria);
            dataGrid.Columns.Add(colPaginas);
            dataGrid.Columns.Add(colTipo);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        /// <summary>
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarTeoria(string CodTeoriaSelecao)
        {
            try
            {
                if (ValidarControlesTeoria().Equals(true))
                {
                    //Carrega as licoes selecionadas
                    criarLicaoTeoria(CodTeoriaSelecao);

                    //Limpa os controle e desabilita
                    limparTeoria();
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
        /// Função que Deleta a linha selecionada no gridTeoria
        /// </summary>
        private void deleteTeoria(int Indice)
        {
            try
            {
                MOD_preTesteTeoria ent = new MOD_preTesteTeoria();
                ent.CodPreTesteTeoria = listaTesteTeoria[Indice].CodPreTesteTeoria;

                //Insere a linha na Lista Delete
                listaDeleteTesteTeoria.Add(ent);
                //Exclui a linha da lista
                listaTesteTeoria.RemoveAt(Indice);
                listaTesteTeoria.ResetBindings();

                //Seleciona a linha anterior a excluida
                if (gridTeoria.RowCount > 0)
                {
                    if (!gridTeoria.Rows[0].Selected.Equals(true))
                    {
                        gridTeoria.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridTeoria.Rows[gridTeoria.RowCount - 1].Selected = true;
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
        /// <summary>
        /// Função que Deleta os Teorias que serão sobrepostos pela nova inserção
        /// </summary>
        private void deleteTeorias(string CodTeorias)
        {
            try
            {
                if (listaTesteTeoria != null && listaTesteTeoria.Count > 0)
                {
                    List<MOD_preTesteTeoria> listaNova = new List<MOD_preTesteTeoria>();
                    listaNova.AddRange(listaTesteTeoria);

                    foreach (MOD_preTesteTeoria ent in listaNova)
                    {
                        if (ent.CodTeoria.Equals(CodTeorias))
                        {
                            MOD_preTesteTeoria objEnt_Teo = new MOD_preTesteTeoria();
                            objEnt_Teo.CodPreTesteTeoria = ent.CodPreTesteTeoria;
                            objEnt_Teo.CodFichaPreTeste = txtFicha.Text;
                            objEnt_Teo.CodTeoria = ent.CodTeoria;
                            objEnt_Teo.DescTeoria = ent.DescTeoria;
                            objEnt_Teo.Tipo = ent.Tipo;

                            //Insere a linha na Lista Delete
                            listaDeleteTesteTeoria.Add(objEnt_Teo);
                            listaTesteTeoria.Remove(ent);
                        }
                    }
                    ////atualiza a lista
                    listaTesteTeoria.ResetBindings();
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledTeoria()
        {
            try
            {
                gpoTeoria.Enabled = true;
                btnDefinirLicaoTeoria.Enabled = true;
                gridTeoria.Enabled = false;
                btnTeoriaInserir.Enabled = false;
                btnTeoriaExcluir.Enabled = false;
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
        internal void disabledTeoria()
        {
            try
            {
                verPermTeoria(gridTeoria);
                gridTeoria.Enabled = true;
                btnTeoriaInserir.Focus();
                gpoTeoria.Enabled = false;
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
        /// Função que limpa os controle para Inserir novo hino
        /// </summary>
        private void limparTeoria()
        {
            try
            {
                cboNivelTeoria.SelectedIndex = (-1);
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
        /// Função que carrega as Lições da Aba Teoria
        /// </summary>
        private void carregaTeoriaFicha(BindingList<MOD_preTesteTeoria> listaFichaTeoria)
        {
            try
            {
                listaTesteTeoria = listaFichaTeoria;
                objBind_TesteTeoria.DataSource = listaTesteTeoria;
                montaGridTeoria(gridTeoria);
                ///vincula a lista ao DataSource do DataGriView
                gridTeoria.DataSource = objBind_TesteTeoria;
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

        #region Verificar permissões de Acesso

        /// <summary>
        /// Analisa os Parametros e libera os controles de acordo com o definido
        /// </summary>
        internal void verParamametros()
        {
            ///Veriicação nos parametros se é atorizado a alterar os dados da solicitação
            if (modulos.listaParametros[0].AlteraSolicita.Equals("Não"))
            {
                lblTestePara.Enabled = false;
                optRjm.Enabled = false;
                optMeiaHora.Enabled = false;
                optCulto.Enabled = false;
                optOficial.Enabled = false;
                optTroca.Enabled = false;
                lbPessoa.Enabled = false;
                txtPessoa.Enabled = false;
                btnPessoa.Enabled = false;
                lblPessoa.Enabled = false;
            }
            else
            {
                lblTestePara.Enabled = true;
                optRjm.Enabled = true;
                optMeiaHora.Enabled = true;
                optCulto.Enabled = true;
                optOficial.Enabled = true;
                optTroca.Enabled = true;
                lbPessoa.Enabled = true;
                txtPessoa.Enabled = true;
                btnPessoa.Enabled = true;
                lblPessoa.Enabled = true;
            }
            ///Verificação nos parametros se é autorizado a alterar a quantidade de lições
            if (modulos.listaParametros[0].AlteraQtdeLicoesPreTeste.Equals("Não"))
            {
                txtQtdeMet.Enabled = false;
                lblQtdeMet.Enabled = false;
                txtQtdeHino.Enabled = false;
                lblQtdeHino.Enabled = false;
                txtQtdeMts.Enabled = false;
                lblQtdeMts.Enabled = false;
                txtQtdeEscala.Enabled = false;
                lblQtdeEscala.Enabled = false;
            }
            else
            {
                txtQtdeMet.Enabled = true;
                lblQtdeMet.Enabled = true;
                txtQtdeHino.Enabled = true;
                lblQtdeHino.Enabled = true;
                txtQtdeMts.Enabled = true;
                lblQtdeMts.Enabled = true;
                txtQtdeEscala.Enabled = true;
                lblQtdeEscala.Enabled = true;
            }
            ///Verificação nos parametros se é autorizado a alterar as observações no preteste
            if (modulos.listaParametros[0].TestePermAltObsMet.Equals("Não"))
            {
                lblObsMet.Enabled = false;
                txtObsMet.Enabled = false;
            }
            else
            {
                lblObsMet.Enabled = true;
                txtObsMet.Enabled = true;
            }
            if (modulos.listaParametros[0].TestePermAltObsMts.Equals("Não"))
            {
                lblObsMts.Enabled = false;
                txtObsMts.Enabled = false;
            }
            else
            {
                lblObsMts.Enabled = true;
                txtObsMts.Enabled = true;
            }
            if (modulos.listaParametros[0].TestePermAltObsHino.Equals("Não"))
            {
                lblObsHino.Enabled = false;
                txtObsHino.Enabled = false;
            }
            else
            {
                lblObsHino.Enabled = true;
                txtObsHino.Enabled = true;
            }
            if (modulos.listaParametros[0].TestePermAltObsEsc.Equals("Não"))
            {
                lblObsEsc.Enabled = false;
                txtObsEsc.Enabled = false;
            }
            else
            {
                lblObsEsc.Enabled = true;
                txtObsEsc.Enabled = true;
            }
            if (modulos.listaParametros[0].TestePermAltObsTeoria.Equals("Não"))
            {
                lblObsTeoria.Enabled = false;
                txtObsTeoria.Enabled = false;
            }
            else
            {
                lblObsTeoria.Enabled = true;
                txtObsTeoria.Enabled = true;
            }
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermMetodo(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoFichaPreTeste entAcesso = new MOD_acessoFichaPreTeste();
                btnMetIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsMetFichaPreTeste);
                btnMetExcluir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcMetFichaPreTeste, dataGrid);

                //foreach (MOD_acessos ent in listaAcesso)
                //{
                //    //verificando o botão inserir
                //    if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetFichaPreTeste))
                //    {
                //        btnMetIns.Enabled = true;
                //    }
                //    //verificando o botão excluir
                //    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetFichaPreTeste))
                //    {
                //        if (dataGrid.Rows.Count > 0)
                //        {
                //            btnMetExcluir.Enabled = true;
                //        }
                //        else
                //        {
                //            btnMetExcluir.Enabled = false;
                //        }
                //    }
                //}
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
        internal void verPermHinario(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoFichaPreTeste entAcesso = new MOD_acessoFichaPreTeste();
                //verificando o botão inserir
                btnHinoInserir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsHinoFichaPreTeste);
                btnHinoExcluir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcHinoFichaPreTeste, dataGrid);

                //foreach (MOD_acessos ent in listaAcesso)
                //{
                ////verificando o botão inserir
                //if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetFichaPreTeste))
                //{
                //    btnMetIns.Enabled = true;
                //}
                //verificando o botão excluir
                //else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetFichaPreTeste))
                //{
                //    if (dataGrid.Rows.Count > 0)
                //    {
                //        btnMetExcluir.Enabled = true;
                //    }
                //    else
                //    {
                //        btnMetExcluir.Enabled = false;
                //    }
                //}
                //}
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
        internal void verPermMts(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoFichaPreTeste entAcesso = new MOD_acessoFichaPreTeste();
                btnMtsInserir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsMtsFichaPreTeste);
                btnMtsExcluir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcMtsFichaPreTeste, dataGrid);

                //foreach (MOD_acessos ent in listaAcesso)
                //{
                //    //verificando o botão inserir
                //    if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetFichaPreTeste))
                //    {
                //        btnMetIns.Enabled = true;
                //    }
                //    //verificando o botão excluir
                //    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetFichaPreTeste))
                //    {
                //        if (dataGrid.Rows.Count > 0)
                //        {
                //            btnMetExcluir.Enabled = true;
                //        }
                //        else
                //        {
                //            btnMetExcluir.Enabled = false;
                //        }
                //    }
                //}
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
        internal void verPermEscala(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoFichaPreTeste entAcesso = new MOD_acessoFichaPreTeste();
                btnEscalaInserir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsEscalaFichaPreTeste);
                btnEscalaExcluir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcEscalaFichaPreTeste, dataGrid);

                //foreach (MOD_acessos ent in listaAcesso)
                //{
                //    //verificando o botão inserir
                //    if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetFichaPreTeste))
                //    {
                //        btnMetIns.Enabled = true;
                //    }
                //    //verificando o botão excluir
                //    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetFichaPreTeste))
                //    {
                //        if (dataGrid.Rows.Count > 0)
                //        {
                //            btnMetExcluir.Enabled = true;
                //        }
                //        else
                //        {
                //            btnMetExcluir.Enabled = false;
                //        }
                //    }
                //}
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
        internal void verPermTeoria(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoFichaPreTeste entAcesso = new MOD_acessoFichaPreTeste();
                btnTeoriaInserir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsTeoriaFichaPreTeste);
                btnTeoriaExcluir.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcTeoriaFichaPreTeste, dataGrid);

                //foreach (MOD_acessos ent in listaAcesso)
                //{
                //    //verificando o botão inserir
                //    if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetFichaPreTeste))
                //    {
                //        btnMetIns.Enabled = true;
                //    }
                //    //verificando o botão excluir
                //    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetFichaPreTeste))
                //    {
                //        if (dataGrid.Rows.Count > 0)
                //        {
                //            btnMetExcluir.Enabled = true;
                //        }
                //        else
                //        {
                //            btnMetExcluir.Enabled = false;
                //        }
                //    }
                //}
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

        #endregion

    }
}