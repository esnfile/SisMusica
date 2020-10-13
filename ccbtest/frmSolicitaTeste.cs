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
using BLL.preTeste;
using BLL.Funcoes;
using ENT.Erros;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using BLL.pessoa;
using ENT.pessoa;
using ENT.preTeste;
using BLL.uteis;
using ccbtest.pesquisa;

namespace ccbtest
{
    public partial class frmSolicitaTeste : Form
    {
        public frmSolicitaTeste(Form forms, DataGridView gridPesquisa, List<MOD_solicitaTeste> lista)
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
                listaSolicita = lista;

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
                }
                else
                {
                    txtDataLancto.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtHoraLancto.Text = DateTime.Now.ToString("HH:mm");
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

        BLL_solicitaTeste objBLL = null;
        MOD_solicitaTeste objEnt = null;
        List<MOD_solicitaTeste> listaSolicita = null;

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
        private void frmSolicitaTeste_Load(object sender, EventArgs e)
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
        private void frmSolicitaTeste_FormClosing(object sender, FormClosingEventArgs e)
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
        private void frmSolicitaTeste_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
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
        private void optMeia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMeia.Checked.Equals(true))
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
        private void txtPessoa_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPessoa;
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
        }
        private void txtCodCCB_Leave(object sender, EventArgs e)
        {
            if (!txtCodCCB.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaCCB(txtCodCCB.Text);
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
                    objBLL = new BLL_solicitaTeste();

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
                    if (formChama.Name.Equals("frmSolicitaTesteBusca"))
                    {
                        ((frmSolicitaTesteBusca)formChama).carregaGrid("Solicitacao", objEnt.CodSolicitaTeste, string.Empty, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmSolicitaTeste_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmSolicitaTeste_FormClosing);

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
                if (lblTipo.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Informe qual o tipo de teste.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblPessoa.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aluno(a)! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblComum.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Comum congregação! Campo obrigatório.";
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
        private MOD_solicitaTeste criarTabela()
        {
            try
            {
                objEnt = new MOD_solicitaTeste();
                objEnt.CodSolicitaTeste = txtCodigo.Text;
                objEnt.Tipo = lblTipo.Text;
                objEnt.CodPessoa = txtPessoa.Text;
                objEnt.Nome = lblPessoa.Text;
                objEnt.CodCCB = txtCodCCB.Text;
                objEnt.Data = txtDataLancto.Text;
                objEnt.Hora = txtHoraLancto.Text;
                objEnt.CodUsuario = lblCodUsuario.Text;
                objEnt.Usuario = txtUsuario.Text;
                objEnt.Status = lblStatus.Text;

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
        /// <param name="listaSolicita"></param>
        internal void preencher(List<MOD_solicitaTeste> listaSolicita)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaSolicita[0].CodSolicitaTeste;
                lblTipo.Text = listaSolicita[0].Tipo;
                lblStatus.Text = listaSolicita[0].Status;
                txtPessoa.Text = listaSolicita[0].CodPessoa;
                lblPessoa.Text = listaSolicita[0].Nome;
                txtInstrumento.Text = listaSolicita[0].DescInstrumento;
                txtFamilia.Text = listaSolicita[0].DescFamilia;
                txtDataLancto.Text = listaSolicita[0].Data;
                txtHoraLancto.Text = listaSolicita[0].Hora;
                lblCodUsuario.Text = listaSolicita[0].CodUsuario;
                txtUsuario.Text = listaSolicita[0].Usuario;
                txtCodCCB.Text = listaSolicita[0].CodCCB;
                lblComum.Text = listaSolicita[0].CodigoCCB + " - " + listaSolicita[0].DescricaoCCB + " - " + listaSolicita[0].DescricaoRegiao;

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
                            txtFamilia.Text = listaPesFiltro[0].DescFamilia;
                            txtCodCCB.Text = listaPesFiltro[0].CodCCB;
                            lblComum.Text = listaPesFiltro[0].Nome;
                            lblComum.Text = listaPesFiltro[0].CodigoCCB + " - " + listaPesFiltro[0].Descricao + " - " + listaPesFiltro[0].DescRegiaoCCB;
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
        internal void carregaCCB(string vCodCCB)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarCod(vCodCCB);

                if (listaCCB != null && listaCCB.Count > 0)
                {
                    txtCodCCB.Text = listaCCB[0].CodCCB;
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
                pnlSolicita.Enabled = false;
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
                pnlSolicita.Enabled = true;
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
            gpoTipo.Focus();
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
                    optMeia.Checked = true;
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

        #endregion

    }
}