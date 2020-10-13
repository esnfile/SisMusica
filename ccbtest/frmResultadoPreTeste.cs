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
    public partial class frmResultadoPreTeste : Form
    {
        public frmResultadoPreTeste(Form forms, DataGridView gridPesquisa, List<MOD_preTesteFicha> lista, MOD_preTeste ent_PreTeste)
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

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
                }
                else
                {

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
        }
        private void txtInstrumento_TextChanged(object sender, EventArgs e)
        {
            try
            {
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
                objEnt.NomeCandidato = lblPessoa.Text;

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
                lblPessoa.Text = listaFicha[0].NomeCandidato;

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
                lblPessoa.Enabled = true;
            }
        }

        #endregion

        #endregion

    }
}