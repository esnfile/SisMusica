using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

using ENT.uteis;
using BLL.Funcoes;
using BLL.instrumentos;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.Erros;
using ENT.instrumentos;
using ENT.pessoa;
using ENT.acessos;

namespace ccbinst
{
    public partial class frmTeoria : Form
    {
        public frmTeoria(Form forms, DataGridView gridPesquisa, List<MOD_teoria> lista)
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
                listaTeoria = lista;

                //define a data do cadastro como data atual para o modo de inserção
                txtDataCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtHoraCadastro.Text = DateTime.Now.ToString("HH:mm");

                //Montar o GridFoto
                carregaGridFoto();

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
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

        BLL_teoria objBLL = null;
        MOD_teoria objEnt = null;
        List<MOD_teoria> listaTeoria = null;

        BLL_mtsModulo objBLL_Modulo = null;
        List<MOD_mtsModulo> listaModulo = null;

        BLL_mtsFase objBLL_Fase = null;
        List<MOD_mtsFase> listaFase = null;

        BindingList<MOD_teoriaFoto> listaFotoTeoria = new BindingList<MOD_teoriaFoto>();
        List<MOD_teoriaFoto> listaDeleteFotoTeoria = new List<MOD_teoriaFoto>();
        DataTable objDtb_Foto = null;

        BindingSource objBinding_Foto = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formChama;
        DataGridView dataGrid;

        private string foto = null;
        string CodFoto;

        #endregion

        #region Eventos do Formulario

        private void optAtiv_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAtiv.Checked.Equals(true))
                {
                    lblTipoCadastro.Text = "Atividade";
                    gpoModulo.Enabled = true;
                    formarDescricao();
                }
                else
                {
                    lblTipoCadastro.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void optAval_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAval.Checked.Equals(true))
                {
                    lblTipoCadastro.Text = "Avaliação";

                    lblCodModulo.Text = null;
                    lblCodFase.Text = null;
                    optModulo.Checked = false;
                    optFase.Checked = false;
                    cboModulo.SelectedIndex = -1;
                    gpoModulo.Enabled = false;

                    formarDescricao();
                }
                else
                {
                    lblTipoCadastro.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void optGem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optGem.Checked.Equals(true))
                {
                    lblAplicaEm.Text = "GEM";
                    formarDescricao();
                }
                else
                {
                    lblAplicaEm.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void optRjm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optRjm.Checked.Equals(true))
                {
                    lblAplicaEm.Text = "Reunião de Jovens";
                    formarDescricao();
                }
                else
                {
                    lblAplicaEm.Text = string.Empty;
                }
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
                    lblAplicaEm.Text = "Culto Oficial";
                    formarDescricao();
                }
                else
                {
                    lblAplicaEm.Text = string.Empty;
                }
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
                    lblAplicaEm.Text = "Oficialização";
                    formarDescricao();
                }
                else
                {
                    lblAplicaEm.Text = string.Empty;
                }
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
                    lblAplicaEm.Text = "Meia Hora";
                    formarDescricao();
                }
                else
                {
                    lblAplicaEm.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void optModulo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optModulo.Checked.Equals(true))
                {
                    apoio.Aguarde();
                    lblSepararPor.Text = "Módulo";
                    carregaMts(lblSepararPor.Text);
                }
                else
                {
                    lblSepararPor.Text = null;
                }
                formarDescricao();
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
        private void optFase_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optFase.Checked.Equals(true))
                {
                    apoio.Aguarde();
                    lblSepararPor.Text = "Fase";
                    carregaMts(lblSepararPor.Text);
                }
                else
                {
                    lblSepararPor.Text = null;
                }
                formarDescricao();
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
        private void cboModulo_SelectedValueChanged(object sender, EventArgs e)
        {
        }
        private void cboModulo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cboModulo.SelectedValue != null)
            {
                try
                {
                    if (optModulo.Checked.Equals(true))
                    {
                        lblCodModulo.Text = Convert.ToString(cboModulo.SelectedValue);
                        lblCodFase.Text = null;
                    }
                    else if (optFase.Checked.Equals(true))
                    {
                        lblCodFase.Text = Convert.ToString(cboModulo.SelectedValue);
                        lblCodModulo.Text = null;
                    }
                    formarDescricao();
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
        private void txtTotalPag_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                definirPaginas();
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        #region Maninulação das imagens

        private void gridFotoTeoria_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermFotoTeoria(gridFotoTeoria);
                definirOrdem();
                definirPaginas();
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
        private void gridFotoTeoria_SelectionChanged(object sender, EventArgs e)
        {
            if (gridFotoTeoria != null && gridFotoTeoria.RowCount > 0)
            {
                CodFoto = Convert.ToString(gridFotoTeoria[1, gridFotoTeoria.CurrentRow.Index].Value);
                carregaFoto(CodFoto);
            }
        }
        private void btnTeoria_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                buscarFoto();
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
        private void btnFotoCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                //Limpa os controle e desabilita
                limparFotoTeoria();
                disabledFoto();
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
        private void btnFotoSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                inserirFotoTeoria();
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
        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparFotoTeoria();
                enabledFoto();
                definirPaginas();
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
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                deleteFotoTeoria(gridFotoTeoria.CurrentRow.Index);
                disabledFoto();
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
        private void btnVisual_Click(object sender, EventArgs e)
        {
            try
            {
                carregaFoto(CodFoto);
                enabledFoto();
                btnFotoSalvar.Enabled = false;
                btnTeoria.Enabled = false;
                cboPagina.Enabled = false;
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
        private void frmTeoria_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                verPermFotoTeoria(gridFotoTeoria);
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
        private void frmTeoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Teoria"))
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
        private void frmTeoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
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
                    objBLL = new BLL_teoria();

                    if (Convert.ToInt64(txtCodigo.Text).Equals(0))
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
                    if (formChama.Name.Equals("frmTeoriaBusca"))
                    {
                        ((frmTeoriaBusca)formChama).carregaGrid("Teoria", objEnt.CodTeoria, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmTeoria_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmTeoria_FormClosing);
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
                if (cboNivel.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nível! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblTipoCadastro.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Tipo de Cadastro! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblAplicaEm.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aplicação! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (gpoModulo.Enabled.Equals(true))
                {
                    if (lblSepararPor.Text.Equals(string.Empty))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Referência! Campo obrigatório.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (cboModulo.Text.Equals(string.Empty))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Módulo ou Fase! Campo obrigatório.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                if (txtDescricao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtTotalPag.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Tota de Páginas! Deve ser diferente de ZERO.";
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
        /// Função que valida os campos
        /// </summary>
        private bool ValidarControlesFoto()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (cboPagina.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Selecione a Página! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblContemFoto.Equals("Não"))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Selecione uma imagem Válida!";
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
        private MOD_teoria criarTabela()
        {
            try
            {
                objEnt = new MOD_teoria();
                objEnt.CodTeoria = txtCodigo.Text;
                objEnt.DescTeoria = txtDescricao.Text;
                objEnt.AplicaEm = lblAplicaEm.Text;
                objEnt.TipoCadastro = lblTipoCadastro.Text;
                objEnt.SepararPor = lblSepararPor.Text;
                objEnt.CodModuloMts = optModulo.Checked.Equals(true) ? lblCodModulo.Text : null;
                objEnt.CodFaseMts = optFase.Checked.Equals(true) ? lblCodFase.Text : null;
                objEnt.Nivel = cboNivel.Text;
                objEnt.Paginas = Convert.ToString(txtTotalPag.Value);
                objEnt.CodUsuario = Convert.ToString(modulos.CodUsuario);
                objEnt.Nome = txtUsuario.Text;
                objEnt.DataCadastro = txtDataCadastro.Text;
                objEnt.HoraCadastro = txtHoraCadastro.Text;

                //retorna o objeto Foto preenchido
                objEnt.listaFotoTeoria = ((BindingList<MOD_teoriaFoto>)objBinding_Foto.DataSource);
                objEnt.CarregarFotoTeoria = objDtb_Foto;

                //objEnt.listaFotoTeoria = listaFotoTeoria;
                objEnt.listaDeleteFotoTeoria = listaDeleteFotoTeoria;

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
        /// <param name="listaTeoria"></param>
        internal void preencher(List<MOD_teoria> listaTeo)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaTeo[0].CodTeoria;
                txtDescricao.Text = listaTeo[0].DescTeoria;
                lblAplicaEm.Text = listaTeo[0].AplicaEm;
                lblTipoCadastro.Text = listaTeo[0].TipoCadastro;
                lblSepararPor.Text = listaTeo[0].SepararPor;
                lblCodModulo.Text = listaTeo[0].CodModuloMts;
                lblCodFase.Text = listaTeo[0].CodFaseMts;

                //Carrega a referencia no cboModulo
                carregaMts(lblSepararPor.Text);
                cboModulo.SelectedValue = lblSepararPor.Text.Equals("Fase") ? lblCodFase.Text : lblCodModulo.Text;

                cboNivel.Text = listaTeo[0].Nivel;
                txtTotalPag.Value = Convert.ToInt16(listaTeo[0].Paginas);
                lblCodUsuario.Text = listaTeo[0].CodUsuario;
                txtUsuario.Text = listaTeo[0].Nome;
                txtDataCadastro.Text = listaTeo[0].DataCadastro;
                txtHoraCadastro.Text = listaTeo[0].HoraCadastro;

                //retorna o objeto Foto preenchido
                listaFotoTeoria = listaTeo[0].listaFotoTeoria;

                ///verificações para preenchimento de radiobuttons
                verificacoes();

                //Carregar o Grid Foto
                objDtb_Foto = listaTeo[0].CarregarFotoTeoria;

                carregaGridFoto();

                ////Carregar a Foto
                //carregaFoto(listaTeo);

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
        /// Função que preenche o ComboBox Módulos
        /// </summary>
        /// <returns></returns>
        internal void carregaMts(string Referencia)
        {
            try
            {
                if (Referencia.Equals("Módulo"))
                {
                    objBLL_Modulo = new BLL_mtsModulo();
                    listaModulo = new List<MOD_mtsModulo>();

                    listaModulo = objBLL_Modulo.buscarCod(string.Empty);
                    cboModulo.DataSource = listaModulo;
                    cboModulo.ValueMember = "CodModuloMts";
                    cboModulo.DisplayMember = "DescModulo";
                    cboModulo.SelectedIndex = (-1);
                }
                else if (Referencia.Equals("Fase"))
                {
                    objBLL_Fase = new BLL_mtsFase();
                    listaFase = new List<MOD_mtsFase>();

                    listaFase = objBLL_Fase.buscarCod(string.Empty);
                    cboModulo.DataSource = listaFase;
                    cboModulo.ValueMember = "CodFaseMts";
                    cboModulo.DisplayMember = "DescFase";
                    cboModulo.SelectedIndex = (-1);
                }
                else
                {
                    cboModulo.DataSource = null;
                    cboModulo.SelectedIndex = (-1);
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

        #region Grid Fotos

        /// <summary>
        /// Função que monta o GridView de AtendeComum - Aba Adicionais
        /// </summary>
        private void montaGridFoto()
        {
            try
            {
                gridFotoTeoria.AutoGenerateColumns = false;
                gridFotoTeoria.DataSource = null;
                gridFotoTeoria.Columns.Clear();
                gridFotoTeoria.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn CodFoto = new DataGridViewTextBoxColumn();
                CodFoto.DataPropertyName = "CodFoto";
                CodFoto.HeaderText = "Código";
                CodFoto.Name = "CodFoto";
                CodFoto.Width = 60;
                CodFoto.Frozen = false;
                CodFoto.MinimumWidth = 50;
                CodFoto.ReadOnly = true;
                CodFoto.DefaultCellStyle.Format = "000000";
                CodFoto.FillWeight = 100;
                CodFoto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                CodFoto.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                CodFoto.MaxInputLength = 20;
                CodFoto.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodTeoria = new DataGridViewTextBoxColumn();
                colCodTeoria.DataPropertyName = "CodTeoria";
                colCodTeoria.HeaderText = "CodTeoria";
                colCodTeoria.Name = "CodTeoria";
                colCodTeoria.Width = 150;
                colCodTeoria.Frozen = false;
                colCodTeoria.MinimumWidth = 100;
                colCodTeoria.ReadOnly = false;
                colCodTeoria.FillWeight = 100;
                colCodTeoria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodTeoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodTeoria.MaxInputLength = 255;
                colCodTeoria.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colPagina = new DataGridViewTextBoxColumn();
                colPagina.DataPropertyName = "Pagina";
                colPagina.HeaderText = "Página";
                colPagina.Name = "Pagina";
                colPagina.Width = 170;
                colPagina.Frozen = false;
                colPagina.MinimumWidth = 100;
                colPagina.ReadOnly = true;
                colPagina.FillWeight = 170;
                colPagina.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colPagina.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colPagina.MaxInputLength = 255;
                colPagina.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colOrdem = new DataGridViewTextBoxColumn();
                colOrdem.HeaderText = "";
                colOrdem.Name = "Ordem";
                colOrdem.Width = 50;
                colOrdem.Frozen = false;
                colOrdem.MinimumWidth = 30;
                colOrdem.ReadOnly = true;
                colOrdem.FillWeight = 170;
                colOrdem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colOrdem.DefaultCellStyle.Format = "000";
                colOrdem.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colOrdem.MaxInputLength = 255;
                colOrdem.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                gridFotoTeoria.Columns.Add(colOrdem);
                gridFotoTeoria.Columns.Add(CodFoto);
                gridFotoTeoria.Columns.Add(colCodTeoria);
                gridFotoTeoria.Columns.Add(colPagina);
                ///feito um refresh para fazer a atualização do datagridview
                gridFotoTeoria.Refresh();
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
        /// Função que carrega as Fotos da Teoria
        /// </summary>
        /// <param name="vCodTeoria"></param>
        private void carregaGridFoto()
        {
            try
            {
                objBLL = new BLL_teoria();
                objBinding_Foto = new BindingSource();
                //listaFotoTeoria = objBLL.buscarTeoriaFoto(vCodTeoria);

                objBinding_Foto.DataSource = listaFotoTeoria;

                montaGridFoto();
                ///vincula a lista ao DataSource do DataGriView
                gridFotoTeoria.DataSource = objBinding_Foto;
                //gridFotoTeoria.DataSource = objDtb_Foto;
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
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void inserirFotoTeoria()
        {
            try
            {
                if (ValidarControlesFoto().Equals(true))
                {
                    MOD_teoriaFoto ent = new MOD_teoriaFoto();
                    ent.CodFoto = "00000";
                    ent.CodTeoria = txtCodigo.Text;
                    ent.Pagina = cboPagina.Text;
                    ent.Foto = foto;

                    //objDtb_Foto.Rows.Add(ent);

                    listaFotoTeoria = ((BindingList<MOD_teoriaFoto>)objBinding_Foto.DataSource);
                    //adiciona um novo item a lista
                    listaFotoTeoria.Add(ent);
                    //atualiza o datagridview
                    listaFotoTeoria.ResetItem(gridFotoTeoria.RowCount - 1);

                    //Limpa os controle e desabilita
                    limparFotoTeoria();
                    disabledFoto();
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
        /// Função que Deleta a linha selecionada no GridFotoTeoria
        /// </summary>
        private void deleteFotoTeoria(int Indice)
        {
            try
            {
                MOD_teoriaFoto ent = new MOD_teoriaFoto();
                ent.CodFoto = CodFoto;

                //Insere a linha na Lista Delete
                listaDeleteFotoTeoria.Add(ent);
                //Exclui a linha da lista
                listaFotoTeoria.RemoveAt(Indice);
                ////atualiza o datagridview
                //listaFotoTeoria.ResetItem(-1);

                //Seleciona a linha anterior a excluida
                if (gridFotoTeoria.RowCount > 0)
                {
                    if (!gridFotoTeoria.Rows[0].Selected.Equals(true))
                    {
                        gridFotoTeoria.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridFotoTeoria.Rows[gridFotoTeoria.RowCount - 1].Selected = true;
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
        /// Função que limpa os controle para Inserir nova Foto
        /// </summary>
        private void limparFotoTeoria()
        {
            try
            {
                cboPagina.SelectedValue = (-1);
                lblCodFoto.Text = string.Empty;
                pctFoto.Image = null;
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
        /// Função que carrega a foto da Teoria na base de dados
        /// </summary>
        private void carregaFoto(string vCodFoto)
        {
            try
            {

                objBLL = new BLL_teoria();
                objDtb_Foto = new DataTable();

                objDtb_Foto = objBLL.buscarFoto(vCodFoto);

                if (objDtb_Foto.Rows.Count > 0)
                {

                    lblContemFoto.Text = "Não";

                    foreach (DataRow row in objDtb_Foto.Rows)
                    {
                        try
                        {
                            lblCodFoto.Text = (string)(row.IsNull("CodFoto") ? Convert.ToString(null) : Convert.ToString(row["CodFoto"]));
                            cboPagina.Items.Add((string)(row.IsNull("Pagina") ? Convert.ToString(null) : Convert.ToString(row["Pagina"])));
                            cboPagina.Text = (string)(row.IsNull("Pagina") ? Convert.ToString(null) : Convert.ToString(row["Pagina"]));
                            byte[] bits = ((byte[])row["Foto"]);
                            MemoryStream memorybits = new MemoryStream(bits);
                            Bitmap bit = new Bitmap(memorybits);
                            pctFoto.Image = bit;
                            lblContemFoto.Text = "Sim";
                            lblAviso.Visible = false;
                        }
                        catch
                        {
                            pctFoto.Image = null;
                            pctFoto.Refresh();
                        }
                    }
                }
                else
                {
                    pctFoto.Image = null;
                    pctFoto.Refresh();
                    lblAviso.Visible = true;
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
        /// Função que define a ordem no grid
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirOrdem()
        {
            try
            {
                int vOrdem = 0;
                foreach (DataGridViewRow linha in gridFotoTeoria.Rows)
                {
                    vOrdem = vOrdem + 1;
                    linha.Cells["Ordem"].Value = vOrdem.ToString("000");
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
        /// Função que define as páginas do Combo
        /// </summary>
        /// <param name="dataGrid"></param>
        private void definirPaginas()
        {
            try
            {
                int vPag;
                vPag = Convert.ToInt16(txtTotalPag.Value);

                cboPagina.Items.Clear();

                for (int i = 0; i < vPag; i++)
                {
                    string vPagina;
                    vPagina = Convert.ToString("Página " + (i + 1));
                    cboPagina.Items.Add(vPagina);

                    if (gridFotoTeoria.RowCount > 0)
                    {
                        foreach (DataGridViewRow linha in gridFotoTeoria.Rows)
                        {
                            ///verifica a condição especificada para exibir a imagem
                            if (linha.Cells["Pagina"].Value.ToString().Contains(vPagina))
                            {
                                if (cboPagina.Items.Count > 0)
                                {
                                    cboPagina.Items.Remove(vPagina);
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                pnlTeoria.Enabled = false;
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
                pnlTeoria.Enabled = true;
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
        /// Função que verifica os valores e marca as Opções
        /// </summary>
        internal void verificacoes()
        {
            try
            {
                optAtiv.CheckedChanged -= new EventHandler(optAtiv_CheckedChanged);
                optAval.CheckedChanged -= new EventHandler(optAval_CheckedChanged);
                optGem.CheckedChanged -= new EventHandler(optGem_CheckedChanged);
                optCulto.CheckedChanged -= new EventHandler(optCulto_CheckedChanged);
                optRjm.CheckedChanged -= new EventHandler(optRjm_CheckedChanged);
                optOficial.CheckedChanged -= new EventHandler(optOficial_CheckedChanged);
                optMeia.CheckedChanged -= new EventHandler(optMeia_CheckedChanged);
                optModulo.CheckedChanged -= new EventHandler(optModulo_CheckedChanged);
                optFase.CheckedChanged -= new EventHandler(optFase_CheckedChanged);
                
                ///verifica o Tipo de Cadastro
                if (lblTipoCadastro.Text.Equals("Atividade"))
                {
                    optAtiv.Checked = true;
                }
                else if (lblTipoCadastro.Text.Equals("Avaliação"))
                {
                    optAval.Checked = true;
                }

                ///verifica a Aplicação
                if (lblAplicaEm.Text.Equals("GEM"))
                {
                    optGem.Checked = true;
                }
                else if (lblAplicaEm.Text.Equals("Reunião de Jovens"))
                {
                    optRjm.Checked = true;
                }
                else if (lblAplicaEm.Text.Equals("Culto Oficial"))
                {
                    optCulto.Checked = true;
                }
                else if (lblAplicaEm.Text.Equals("Meia Hora"))
                {
                    optMeia.Checked = true;
                }
                else if (lblAplicaEm.Text.Equals("Oficialização"))
                {
                    optOficial.Checked = true;
                }

                if (lblTipoCadastro.Text.Equals("Atividade"))
                {
                    ///verifica a Referencia
                    if (lblSepararPor.Text.Equals("Módulo"))
                    {
                        optModulo.Checked = true;
                    }
                    else if (lblSepararPor.Text.Equals("Fase"))
                    {
                        optFase.Checked = true;
                    }
                }
                else
                {
                    gpoModulo.Enabled = false;
                }

                optAtiv.CheckedChanged += new EventHandler(optAtiv_CheckedChanged);
                optAval.CheckedChanged += new EventHandler(optAval_CheckedChanged);
                optGem.CheckedChanged += new EventHandler(optGem_CheckedChanged);
                optCulto.CheckedChanged += new EventHandler(optCulto_CheckedChanged);
                optRjm.CheckedChanged += new EventHandler(optRjm_CheckedChanged);
                optOficial.CheckedChanged += new EventHandler(optOficial_CheckedChanged);
                optMeia.CheckedChanged += new EventHandler(optMeia_CheckedChanged);
                optModulo.CheckedChanged += new EventHandler(optModulo_CheckedChanged);
                optFase.CheckedChanged += new EventHandler(optFase_CheckedChanged);

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
            cboNivel.Focus();
        }

        /// <summary>
        /// Função que define a descrição
        /// </summary>
        internal void formarDescricao()
        {
            if (string.IsNullOrEmpty(cboModulo.Text))
            {
                txtDescricao.Text = lblTipoCadastro.Text + " " + lblAplicaEm.Text;
            }
            else
            {
                txtDescricao.Text = lblTipoCadastro.Text + " " + lblAplicaEm.Text + " " + cboModulo.Text;
            }
        }

        /// <summary>
        /// Função que abre a Caixa de diálogo para Pesquisar a Foto
        /// </summary>
        private void buscarFoto()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Carregar Imagem";
                dlg.Filter = "JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp|PNG(*.png) | *.png";

                lblContemFoto.Text = "Não";
                if (dlg.ShowDialog().Equals(DialogResult.OK))
                {
                    try
                    {
                        pctFoto.Image = new Bitmap(dlg.OpenFile());
                        foto = dlg.FileName;
                        lblContemFoto.Text = "Sim";
                    }
                    catch (Exception ex)
                    {
                        excp = new clsException(ex);
                    }
                }
                else
                {
                }
                dlg.Dispose();
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
        /// Função que habilita os controles da Foto
        /// </summary>
        internal void enabledFoto()
        {
            try
            {
                gpoFoto.Enabled = true;
                btnFotoSalvar.Enabled = true;
                btnTeoria.Enabled = true;
                cboPagina.Enabled = true;
                btnInserir.Enabled = false;
                btnExcluir.Enabled = false;
                btnVisual.Enabled = false;
                gridFotoTeoria.Enabled = false;
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
        /// Função que habilita os controles da Foto
        /// </summary>
        internal void disabledFoto()
        {
            try
            {
                gpoFoto.Enabled = false;
                //btnFotoSalvar.Enabled = false;
                //btnTeoria.Enabled = false;
                cboPagina.Items.Clear();
                gridFotoTeoria.Enabled = true;
                verPermFotoTeoria(gridFotoTeoria);
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
        internal void verPermFotoTeoria(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsFotoTeoria))
                    {
                        btnInserir.Enabled = true;
                    }
                    //verificando o botão visualizar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotVisualFotoTeoria))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnVisual.Enabled = true;
                        }
                        else
                        {
                            btnVisual.Enabled = false;
                        }
                    }

                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotExcFotoTeoria))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnExcluir.Enabled = true;
                        }
                        else
                        {
                            btnExcluir.Enabled = false;
                        }
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