using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using ENT.instrumentos;
using BLL.instrumentos;
using BLL.Funcoes;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using System.IO;

namespace ccbinst
{
    public partial class frmInst : Form
    {
        public frmInst(Form forms, DataGridView gridPesquisa, List<MOD_instrumento> lista)
        {
            InitializeComponent();
            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaInstr = lista;

                #region Carrega Combo Boxes

                ///carrega os combos boxes
                //combo Familia
                apoio.carregaComboFamilia(cboFamilia);

                #endregion

                carregaTonalidade(txtCodigo.Text);
                carregaHinario(txtCodigo.Text);

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

        BLL_instrumento objBLL = null;
        MOD_instrumento objEnt = null;
        List<MOD_instrumento> listaInstr = null;

        List<MOD_instrumentoVozPrincipal> listaVozPrincipal = null;
        List<MOD_instrumentoVozAlternativa> listaVozAlternativa = null;
        List<MOD_voz> listaVozesPrincipal = null;
        List<MOD_voz> listaVozesAlternativa = null;

        List<MOD_instrumentoTom> listaInstrTom = null;
        List<MOD_tonalidade> listaTonal = null;

        List<MOD_instrumentoHinario> listaInstrHinario = null;
        List<MOD_hinario> listaHinario = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formChama;
        DataGridView dataGrid;

        string foto = null;

        #endregion

        #region eventos do formulario

        #region Aba Geral

        private void optPermitido_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optPermitido.Checked.Equals(true))
                {
                    lblSituacao.Text = "Permitido";
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
        private void optNaoRecomendado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optNaoRecomendado.Checked.Equals(true))
                {
                    lblSituacao.Text = "Não Recomendado";
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
        private void optProibido_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optProibido.Checked.Equals(true))
                {
                    lblSituacao.Text = "Proibido";
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

        private void btnFoto_Click(object sender, EventArgs e)
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
        private void txtDescricao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (!txtDescricao.Text.Equals(string.Empty))
                {
                    ValidarInstrumento();
                    e.Cancel = false;
                }
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
                e.Cancel = true;
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }

        private void gridTonalidade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridTonalidade != null || gridTonalidade.RowCount > 0)
                {
                    if (listaInstrTom[e.RowIndex].Marcado.Equals(true))
                    {
                        listaInstrTom[e.RowIndex].Marcado = false;
                    }
                    else
                    {
                        listaInstrTom[e.RowIndex].Marcado = true;
                    }
                    gridTonalidade.Refresh();
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
        private void gridHinario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridHinario != null || gridHinario.RowCount > 0)
                {
                    if (listaInstrHinario[e.RowIndex].Marcado.Equals(true))
                    {
                        listaInstrHinario[e.RowIndex].Marcado = false;
                    }
                    else
                    {
                        listaInstrHinario[e.RowIndex].Marcado = true;
                    }
                    gridHinario.Refresh();
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

        private void txtOrdem_ValueChanged(object sender, EventArgs e)
        {
            txtOrdem.Value = Convert.ToDecimal(txtOrdem.Value.ToString("000"));
        }

        #endregion

        #region Aba Definição das Vozes

        private void gridPrincipal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridPrincipal != null || gridPrincipal.RowCount > 0)
                {
                    if (gridPrincipal.Columns[e.ColumnIndex].Name.Equals("Escrita"))
                    {
                        if (listaVozPrincipal[e.RowIndex].Escrita.Equals(true))
                        {
                            listaVozPrincipal[e.RowIndex].Escrita = false;
                        }
                        else
                        {
                            listaVozPrincipal[e.RowIndex].Escrita = true;
                        }
                    }
                    else if (gridPrincipal.Columns[e.ColumnIndex].Name.Equals("Abaixo"))
                    {
                        if (listaVozPrincipal[e.RowIndex].Abaixo.Equals(true))
                        {
                            listaVozPrincipal[e.RowIndex].Abaixo = false;
                        }
                        else
                        {
                            listaVozPrincipal[e.RowIndex].Abaixo = true;
                        }
                    }
                    else if (gridPrincipal.Columns[e.ColumnIndex].Name.Equals("Acima"))
                    {
                        if (listaVozPrincipal[e.RowIndex].Acima.Equals(true))
                        {
                            listaVozPrincipal[e.RowIndex].Acima = false;
                        }
                        else
                        {
                            listaVozPrincipal[e.RowIndex].Acima = true;
                        }
                    }
                    gridPrincipal.Refresh();
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
        private void gridAlterna_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridAlterna != null || gridAlterna.RowCount > 0)
                {
                    if (gridAlterna.Columns[e.ColumnIndex].Name.Equals("Escrita"))
                    {
                        if (listaVozAlternativa[e.RowIndex].Escrita.Equals(true))
                        {
                            listaVozAlternativa[e.RowIndex].Escrita = false;
                        }
                        else
                        {
                            listaVozAlternativa[e.RowIndex].Escrita = true;
                        }
                    }
                    else if (gridAlterna.Columns[e.ColumnIndex].Name.Equals("Abaixo"))
                    {
                        if (listaVozAlternativa[e.RowIndex].Abaixo.Equals(true))
                        {
                            listaVozAlternativa[e.RowIndex].Abaixo = false;
                        }
                        else
                        {
                            listaVozAlternativa[e.RowIndex].Abaixo = true;
                        }
                    }
                    else if (gridAlterna.Columns[e.ColumnIndex].Name.Equals("Acima"))
                    {
                        if (listaVozAlternativa[e.RowIndex].Acima.Equals(true))
                        {
                            listaVozAlternativa[e.RowIndex].Acima = false;
                        }
                        else
                        {
                            listaVozAlternativa[e.RowIndex].Acima = true;
                        }
                    }
                    gridAlterna.Refresh();
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

        #region Aba Tessitura

        private void tckGrave_ValueChanged(object sender, EventArgs e)
        {
            ///verifica a tessitura grave
            if (tckGrave.Value.Equals(0))
            {
                lblGrave.Text = "Dó(-1)";
            }
            else if (tckGrave.Value.Equals(1))
            {
                lblGrave.Text = "Ré(-1)";
            }
            else if (tckGrave.Value.Equals(2))
            {
                lblGrave.Text = "Mi(-1)";
            }
            else if (tckGrave.Value.Equals(3))
            {
                lblGrave.Text = "Fá(-1)";
            }
            else if (tckGrave.Value.Equals(4))
            {
                lblGrave.Text = "Sol(-1)";
            }
            else if (tckGrave.Value.Equals(5))
            {
                lblGrave.Text = "Lá(-1)";
            }
            else if (tckGrave.Value.Equals(6))
            {
                lblGrave.Text = "Si(-1)";
            }
            else if (tckGrave.Value.Equals(7))
            {
                lblGrave.Text = "Dó(1)";
            }
            else if (tckGrave.Value.Equals(8))
            {
                lblGrave.Text = "Ré(1)";
            }
            else if (tckGrave.Value.Equals(9))
            {
                lblGrave.Text = "Mi(1)";
            }
            else if (tckGrave.Value.Equals(10))
            {
                lblGrave.Text = "Fá(1)";
            }
            else if (tckGrave.Value.Equals(11))
            {
                lblGrave.Text = "Sol(1)";
            }
            else if (tckGrave.Value.Equals(12))
            {
                lblGrave.Text = "Lá(1)";
            }
            else if (tckGrave.Value.Equals(13))
            {
                lblGrave.Text = "Si(1)";
            }
            else if (tckGrave.Value.Equals(14))
            {
                lblGrave.Text = "Dó(2)";
            }
            else if (tckGrave.Value.Equals(15))
            {
                lblGrave.Text = "Ré(2)";
            }
            else if (tckGrave.Value.Equals(16))
            {
                lblGrave.Text = "Mi(2)";
            }
            else if (tckGrave.Value.Equals(17))
            {
                lblGrave.Text = "Fá(2)";
            }
            else if (tckGrave.Value.Equals(18))
            {
                lblGrave.Text = "Sol(2)";
            }
            else if (tckGrave.Value.Equals(19))
            {
                lblGrave.Text = "Lá(2)";
            }
            else if (tckGrave.Value.Equals(20))
            {
                lblGrave.Text = "Si(2)";
            }
            else if (tckGrave.Value.Equals(21))
            {
                lblGrave.Text = "Dó(3)";
            }
        }
        private void tckAgudo_ValueChanged(object sender, EventArgs e)
        {
            ///verifica a tessitura grave
            if (tckAgudo.Value.Equals(0))
            {
                lblAguda.Text = "Dó(3)";
            }
            else if (tckAgudo.Value.Equals(1))
            {
                lblAguda.Text = "Ré(3)";
            }
            else if (tckAgudo.Value.Equals(2))
            {
                lblAguda.Text = "Mi(3)";
            }
            else if (tckAgudo.Value.Equals(3))
            {
                lblAguda.Text = "Fá(3)";
            }
            else if (tckAgudo.Value.Equals(4))
            {
                lblAguda.Text = "Sol(3)";
            }
            else if (tckAgudo.Value.Equals(5))
            {
                lblAguda.Text = "Lá(3)";
            }
            else if (tckAgudo.Value.Equals(6))
            {
                lblAguda.Text = "Si(3)";
            }
            else if (tckAgudo.Value.Equals(7))
            {
                lblAguda.Text = "Dó(4)";
            }
            else if (tckAgudo.Value.Equals(8))
            {
                lblAguda.Text = "Ré(4)";
            }
            else if (tckAgudo.Value.Equals(9))
            {
                lblAguda.Text = "Mi(4)";
            }
            else if (tckAgudo.Value.Equals(10))
            {
                lblAguda.Text = "Fá(4)";
            }
            else if (tckAgudo.Value.Equals(11))
            {
                lblAguda.Text = "Sol(4)";
            }
            else if (tckAgudo.Value.Equals(12))
            {
                lblAguda.Text = "Lá(4)";
            }
            else if (tckAgudo.Value.Equals(13))
            {
                lblAguda.Text = "Si(4)";
            }
            else if (tckAgudo.Value.Equals(14))
            {
                lblAguda.Text = "Dó(5)";
            }
            else if (tckAgudo.Value.Equals(15))
            {
                lblAguda.Text = "Ré(5)";
            }
            else if (tckAgudo.Value.Equals(16))
            {
                lblAguda.Text = "Mi(5)";
            }
            else if (tckAgudo.Value.Equals(17))
            {
                lblAguda.Text = "Fá(5)";
            }
            else if (tckAgudo.Value.Equals(18))
            {
                lblAguda.Text = "Sol(5)";
            }
            else if (tckAgudo.Value.Equals(19))
            {
                lblAguda.Text = "Lá(5)";
            }
            else if (tckAgudo.Value.Equals(20))
            {
                lblAguda.Text = "Si(5)";
            }
            else if (tckAgudo.Value.Equals(21))
            {
                lblAguda.Text = "Dó(6)";
            }
        }

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
        private void frmInstr_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                tabGeral.Enabled = true;
                tabVoz.Enabled = false;
                tabTessitura.Enabled = false;

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
        private void frmInstr_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Instrumento"))
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
        private void frmInstr_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void tabInstr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabInst.SelectedIndex.Equals(1))
            {
                try
                {
                    if (listaVozesPrincipal == null || listaVozesPrincipal.Count < 1)
                    {
                        apoio.Aguarde();
                        carregaVozPrincipal(txtCodigo.Text);
                    }
                    if (listaVozesAlternativa == null || listaVozesAlternativa.Count < 1)
                    {
                        apoio.Aguarde();
                        carregaVozAlterna(txtCodigo.Text);
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
                    objBLL = new BLL_instrumento();

                    if (Convert.ToInt16(txtCodigo.Text).Equals(0))
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
                    if (formChama.Name.Equals("frmInstrBusca"))
                    {
                        ((frmInstrBusca)formChama).carregaGrid("Instrumento", objEnt.CodInstrumento, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmInstr_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmInstr_FormClosing);

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
                if (txtDescricao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (cboFamilia.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Família! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblSituacao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Situação! Campo obrigatório.";
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
        /// Funcão que valida a Descrição digitada, caso tenha outo Instrumento
        /// cadastrado com essa Descrição retorna o cadastro para edição
        /// </summary>
        private void ValidarInstrumento()
        {
            try
            {
                objBLL = new BLL_instrumento();
                List<MOD_instrumento> listaValidaInstr = new List<MOD_instrumento>();
                listaValidaInstr = objBLL.buscarDescricao(this.txtDescricao.Text);

                if (listaValidaInstr.Count > 0)
                {
                    if (!Convert.ToInt16(listaValidaInstr[0].CodInstrumento).Equals(Convert.ToInt16(txtCodigo.Text)))
                    {
                        if (MessageBox.Show("Instrumento já cadastrado!" + '\n' +
                                            "Código: " + listaValidaInstr[0].CodInstrumento + '\n' +
                                            "Nome: " + listaValidaInstr[0].DescInstrumento + '\n' + '\n' +
                                            "Deseja editar esse Instrumento?",
                                            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            preencher(listaValidaInstr);
                            enabledForm();
                        }
                        else
                        {
                            txtDescricao.Focus();
                            txtDescricao.SelectAll();
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
        /// <summary>
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_instrumento criarTabela()
        {
            try
            {
                objEnt = new MOD_instrumento();
                objEnt.CodInstrumento = txtCodigo.Text;
                objEnt.DescInstrumento = txtDescricao.Text;
                objEnt.CodFamilia = Convert.ToString(cboFamilia.SelectedValue);
                objEnt.NotaAfina = cboNotaAfina.Text;
                objEnt.PosAfina = cboPosAfina.Text;
                objEnt.NotaEfeito = cboNotaEfeito.Text;
                objEnt.PosEfeito = cboPosEfeito.Text;
                objEnt.Obs = txtObs.Text;
                objEnt.TesNotaGrave = lblGrave.Text;
                objEnt.TesNotaAguda = lblAguda.Text;
                objEnt.Situacao = lblSituacao.Text;
                objEnt.Ordem = Convert.ToString(txtOrdem.Value);

                //retorna o objeto Foto preenchido
                objEnt.FotoInstrumento = criarFoto();

                //retorna o objeto Instrumento Tom
                if (listaInstrTom != null)
                {
                    objEnt.listaTomInstr = listaInstrTom;
                }
                //retorna o objeto Instrumento Hinario
                if (listaInstrHinario != null)
                {
                    objEnt.listaHinoInstr = listaInstrHinario;
                }

                //retorna o objeto Instrumento Voz Principal
                if (listaVozPrincipal != null || listaVozAlternativa != null)
                {
                    objEnt.listaVozInstrPrincipal = new List<MOD_instrumentoVozPrincipal>();
                    objEnt.listaVozInstrAlternativa = new List<MOD_instrumentoVozAlternativa>();
                    objEnt.listaVozInstrPrincipal.AddRange(listaVozPrincipal);
                    objEnt.listaVozInstrAlternativa.AddRange(listaVozAlternativa);
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
        /// Função que preenche os valores das entidades com a Foto
        /// </summary>
        /// <returns></returns>
        private MOD_instrumentoFoto criarFoto()
        {
            try
            {
                objEnt.FotoInstrumento = new MOD_instrumentoFoto();
                objEnt.FotoInstrumento.CodFoto = lblCodFoto.Text;
                objEnt.FotoInstrumento.CodInstrumento = txtCodigo.Text;
                objEnt.FotoInstrumento.Foto = foto;
                return objEnt.FotoInstrumento;
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
        /// <param name="listaInstr"></param>
        internal void preencher(List<MOD_instrumento> listaInst)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaInst[0].CodInstrumento;
                txtDescricao.Text = listaInst[0].DescInstrumento;
                cboFamilia.SelectedValue = listaInst[0].CodFamilia;
                cboNotaAfina.Text = listaInst[0].NotaAfina;
                cboPosAfina.Text = listaInst[0].PosAfina;
                cboNotaEfeito.Text = listaInst[0].NotaEfeito;
                cboPosEfeito.Text = listaInst[0].PosEfeito;
                txtObs.Text = listaInst[0].Obs;
                lblGrave.Text = listaInst[0].TesNotaGrave;
                lblAguda.Text = listaInst[0].TesNotaAguda;
                lblSituacao.Text = listaInst[0].Situacao;
                txtOrdem.Text = listaInst[0].Ordem;

                //Carregar a Tonalidade
                carregaTonalidade(txtCodigo.Text);

                //Carregar os Hinarios
                carregaHinario(txtCodigo.Text);

                //Carregar a Foto
                carregaFoto(listaInst);

                ///verificações para preenchimento de radiobuttons
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
        /// Função que carrega a foto do Instrumento na base de dados
        /// </summary>
        private void carregaFoto(List<MOD_instrumento> listaInst)
        {
            try
            {
                if (listaInst[0].CarregaFoto.Rows.Count > 0)
                {
                    foreach (DataRow row in listaInst[0].CarregaFoto.Rows)
                    {
                        try
                        {
                            lblCodFoto.Text = (string)(row.IsNull("CodFoto") ? Convert.ToString(null) : Convert.ToString(row["CodFoto"]));
                            byte[] bits = ((byte[])row["Foto"]);
                            MemoryStream memorybits = new MemoryStream(bits);
                            Bitmap bit = new Bitmap(memorybits);
                            pctFoto.Image = bit;
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
                tabGeral.Enabled = false;
                tabTessitura.Enabled = false;
                tabVoz.Enabled = false;
                gridAlterna.Enabled = false;
                gridPrincipal.Enabled = false;
                gridTonalidade.Enabled = false;
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
                tabGeral.Enabled = true;
                tabTessitura.Enabled = true;
                tabVoz.Enabled = true;
                gridAlterna.Enabled = true;
                gridPrincipal.Enabled = true;
                gridTonalidade.Enabled = true;
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
                ///verifica a situação
                if (lblSituacao.Text.Equals("Permitido"))
                {
                    optPermitido.Checked = true;
                }
                else if (lblSituacao.Text.Equals("Não Recomendado"))
                {
                    optNaoRecomendado.Checked = true;
                }
                else if (lblSituacao.Text.Equals("Proibido"))
                {
                    optProibido.Checked = true;
                }

                #region Tessitura Grave

                ///verifica a tessitura grave
                if (lblGrave.Text.Equals("Dó(-1)"))
                {
                    tckGrave.Value = 0;
                }
                else if (lblGrave.Text.Equals("Ré(-1)"))
                {
                    tckGrave.Value = 1;
                }
                else if (lblGrave.Text.Equals("Mi(-1)"))
                {
                    tckGrave.Value = 2;
                }
                else if (lblGrave.Text.Equals("Fá(-1)"))
                {
                    tckGrave.Value = 3;
                }
                else if (lblGrave.Text.Equals("Sol(-1)"))
                {
                    tckGrave.Value = 4;
                }
                else if (lblGrave.Text.Equals("Lá(-1)"))
                {
                    tckGrave.Value = 5;
                }
                else if (lblGrave.Text.Equals("Si(-1)"))
                {
                    tckGrave.Value = 6;
                }
                else if (lblGrave.Text.Equals("Dó(1)"))
                {
                    tckGrave.Value = 7;
                }
                else if (lblGrave.Text.Equals("Ré(1)"))
                {
                    tckGrave.Value = 8;
                }
                else if (lblGrave.Text.Equals("Mi(1)"))
                {
                    tckGrave.Value = 9;
                }
                else if (lblGrave.Text.Equals("Fá(1)"))
                {
                    tckGrave.Value = 10;
                }
                else if (lblGrave.Text.Equals("Sol(1)"))
                {
                    tckGrave.Value = 11;
                }
                else if (lblGrave.Text.Equals("Lá(1)"))
                {
                    tckGrave.Value = 12;
                }
                else if (lblGrave.Text.Equals("Si(1)"))
                {
                    tckGrave.Value = 13;
                }
                else if (lblGrave.Text.Equals("Dó(2)"))
                {
                    tckGrave.Value = 14;
                }
                else if (lblGrave.Text.Equals("Ré(2)"))
                {
                    tckGrave.Value = 15;
                }
                else if (lblGrave.Text.Equals("Mi(2)"))
                {
                    tckGrave.Value = 16;
                }
                else if (lblGrave.Text.Equals("Fá(2)"))
                {
                    tckGrave.Value = 17;
                }
                else if (lblGrave.Text.Equals("Sol(2)"))
                {
                    tckGrave.Value = 18;
                }
                else if (lblGrave.Text.Equals("Lá(2)"))
                {
                    tckGrave.Value = 19;
                }
                else if (lblGrave.Text.Equals("Si(2)"))
                {
                    tckGrave.Value = 20;
                }
                else if (lblGrave.Text.Equals("Dó(3)"))
                {
                    tckGrave.Value = 21;
                }

                #endregion

                #region Tessitura Agudo

                ///verifica a tessitura grave
                if (lblAguda.Text.Equals("Dó(3)"))
                {
                    tckAgudo.Value = 0;
                }
                else if (lblAguda.Text.Equals("Ré(3)"))
                {
                    tckAgudo.Value = 1;
                }
                else if (lblAguda.Text.Equals("Mi(3)"))
                {
                    tckAgudo.Value = 2;
                }
                else if (lblAguda.Text.Equals("Fá(3)"))
                {
                    tckAgudo.Value = 3;
                }
                else if (lblAguda.Text.Equals("Sol(3)"))
                {
                    tckAgudo.Value = 4;
                }
                else if (lblAguda.Text.Equals("Lá(3)"))
                {
                    tckAgudo.Value = 5;
                }
                else if (lblAguda.Text.Equals("Si(3)"))
                {
                    tckAgudo.Value = 6;
                }
                else if (lblAguda.Text.Equals("Dó(4)"))
                {
                    tckAgudo.Value = 7;
                }
                else if (lblAguda.Text.Equals("Ré(4)"))
                {
                    tckAgudo.Value = 8;
                }
                else if (lblAguda.Text.Equals("Mi(4)"))
                {
                    tckAgudo.Value = 9;
                }
                else if (lblAguda.Text.Equals("Fá(4)"))
                {
                    tckAgudo.Value = 10;
                }
                else if (lblAguda.Text.Equals("Sol(4)"))
                {
                    tckAgudo.Value = 11;
                }
                else if (lblAguda.Text.Equals("Lá(4)"))
                {
                    tckAgudo.Value = 12;
                }
                else if (lblAguda.Text.Equals("Si(4)"))
                {
                    tckAgudo.Value = 13;
                }
                else if (lblAguda.Text.Equals("Dó(5)"))
                {
                    tckAgudo.Value = 14;
                }
                else if (lblAguda.Text.Equals("Ré(5)"))
                {
                    tckAgudo.Value = 15;
                }
                else if (lblAguda.Text.Equals("Mi(5)"))
                {
                    tckAgudo.Value = 16;
                }
                else if (lblAguda.Text.Equals("Fá(5)"))
                {
                    tckAgudo.Value = 17;
                }
                else if (lblAguda.Text.Equals("Sol(5)"))
                {
                    tckAgudo.Value = 18;
                }
                else if (lblAguda.Text.Equals("Lá(5)"))
                {
                    tckAgudo.Value = 19;
                }
                else if (lblAguda.Text.Equals("Si(5)"))
                {
                    tckAgudo.Value = 20;
                }
                else if (lblAguda.Text.Equals("Dó(6)"))
                {
                    tckAgudo.Value = 21;
                }

                #endregion

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
            txtDescricao.Focus();
        }

        /// <summary>
        /// Função que carrega as Tonalidades
        /// </summary>
        /// <param name="CodInstr"></param>
        private void carregaTonalidade(string CodInstr)
        {
            try
            {
                List<MOD_instrumentoTom> listaNova = new List<MOD_instrumentoTom>();

                objBLL = new BLL_instrumento();
                listaInstrTom = objBLL.buscarInstrumentoTom(CodInstr);

                objBLL = new BLL_instrumento();
                listaTonal = objBLL.buscarTonalidades(CodInstr);

                foreach (MOD_tonalidade objEnt_Tom in listaTonal)
                {
                    MOD_instrumentoTom ent = new MOD_instrumentoTom();

                    ent.CodInstrumentoTom = "0";
                    ent.CodTonalidade = objEnt_Tom.CodTonalidade;
                    ent.DescTonalidade = objEnt_Tom.DescTonalidade;
                    ent.CodInstrumento = "0";
                    ent.Marcado = false;

                    listaNova.Add(ent);
                }

                listaInstrTom.AddRange(listaNova);
                funcoes.gridTonalidade(gridTonalidade, "InstrumentoTom");
                ///vincula a lista ao DataSource do DataGriView
                gridTonalidade.DataSource = listaInstrTom;
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
        /// Função que carrega os Hinarios
        /// </summary>
        /// <param name="CodInstr"></param>
        private void carregaHinario(string CodInstr)
        {
            try
            {
                List<MOD_instrumentoHinario> listaNova = new List<MOD_instrumentoHinario>();

                objBLL = new BLL_instrumento();
                listaInstrHinario = objBLL.buscarInstrumentoHinario(CodInstr);

                objBLL = new BLL_instrumento();
                listaHinario = objBLL.buscarHinarios(CodInstr);

                foreach (MOD_hinario objEnt_Hino in listaHinario)
                {
                    MOD_instrumentoHinario ent = new MOD_instrumentoHinario();

                    ent.CodInstrumentoHino = "0";
                    ent.CodHinario = objEnt_Hino.CodHinario;
                    ent.DescHinario = objEnt_Hino.DescHinario;
                    ent.CodInstrumento = "0";
                    ent.Marcado = false;

                    listaNova.Add(ent);
                }

                listaInstrHinario.AddRange(listaNova);
                funcoes.gridHinario(gridHinario, "InstrumentoHinario");
                ///vincula a lista ao DataSource do DataGriView
                gridHinario.DataSource = listaInstrHinario;
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

        #region Aba Voz

        /// <summary>
        /// Função que monta o GridView de Voz Principal - Aba Voz
        /// </summary>
        private void montaGridVozPrincipal()
        {
            try
            {

                gridPrincipal.AutoGenerateColumns = false;
                gridPrincipal.DataSource = null;
                gridPrincipal.Columns.Clear();
                gridPrincipal.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodInstrVoz = new DataGridViewTextBoxColumn();
                colCodInstrVoz.DataPropertyName = "CodInstrumentoVoz";
                colCodInstrVoz.HeaderText = "CodInstrumentoVoz";
                colCodInstrVoz.Name = "CodInstrumentoVoz";
                colCodInstrVoz.Width = 100;
                colCodInstrVoz.Frozen = false;
                colCodInstrVoz.MinimumWidth = 100;
                colCodInstrVoz.ReadOnly = true;
                colCodInstrVoz.FillWeight = 100;
                colCodInstrVoz.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodInstrVoz.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrVoz.MaxInputLength = 20;
                colCodInstrVoz.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodVoz = new DataGridViewTextBoxColumn();
                colCodVoz.DataPropertyName = "CodVoz";
                colCodVoz.HeaderText = "Código";
                colCodVoz.Name = "CodVoz";
                colCodVoz.Width = 60;
                colCodVoz.Frozen = false;
                colCodVoz.MinimumWidth = 55;
                colCodVoz.ReadOnly = true;
                colCodVoz.FillWeight = 100;
                colCodVoz.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodVoz.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodVoz.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescVoz";
                colDescricao.HeaderText = "Voz Principal";
                colDescricao.Name = "DescVoz";
                colDescricao.Width = 280;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colEscrita = new DataGridViewCheckBoxColumn();
                colEscrita.DataPropertyName = "Escrita";
                colEscrita.HeaderText = "Escrita";
                colEscrita.Name = "Escrita";
                colEscrita.Width = 65;
                colEscrita.Frozen = false;
                colEscrita.MinimumWidth = 60;
                colEscrita.ReadOnly = false;
                colEscrita.FillWeight = 100;
                colEscrita.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colEscrita.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEscrita.Visible = true;
                ///5ª coluna
                DataGridViewCheckBoxColumn colAcima = new DataGridViewCheckBoxColumn();
                colAcima.DataPropertyName = "Acima";
                colAcima.HeaderText = "Acima";
                colAcima.Name = "Acima";
                colAcima.Width = 65;
                colAcima.Frozen = false;
                colAcima.MinimumWidth = 60;
                colAcima.ReadOnly = false;
                colAcima.FillWeight = 100;
                colAcima.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colAcima.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAcima.Visible = true;
                ///6ª coluna
                DataGridViewCheckBoxColumn colAbaixo = new DataGridViewCheckBoxColumn();
                colAbaixo.DataPropertyName = "Abaixo";
                colAbaixo.HeaderText = "Abaixo";
                colAbaixo.Name = "Abaixo";
                colAbaixo.Width = 65;
                colAbaixo.Frozen = false;
                colAbaixo.MinimumWidth = 60;
                colAbaixo.ReadOnly = false;
                colAbaixo.FillWeight = 100;
                colAbaixo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colAbaixo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAbaixo.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                gridPrincipal.Columns.Add(colCodInstrVoz);
                gridPrincipal.Columns.Add(colCodVoz);
                gridPrincipal.Columns.Add(colDescricao);
                gridPrincipal.Columns.Add(colEscrita);
                gridPrincipal.Columns.Add(colAcima);
                gridPrincipal.Columns.Add(colAbaixo);

                ///feito um refresh para fazer a atualização do datagridview
                gridPrincipal.Refresh();
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
        /// Função que monta o GridView de Voz Alternativa - Aba Voz
        /// </summary>
        private void montaGridVozAlterna()
        {
            try
            {

                gridAlterna.AutoGenerateColumns = false;
                gridAlterna.DataSource = null;
                gridAlterna.Columns.Clear();
                gridAlterna.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodInstrVoz = new DataGridViewTextBoxColumn();
                colCodInstrVoz.DataPropertyName = "CodInstrumentoVoz";
                colCodInstrVoz.HeaderText = "CodInstrumentoVoz";
                colCodInstrVoz.Name = "CodInstrumentoVoz";
                colCodInstrVoz.Width = 100;
                colCodInstrVoz.Frozen = false;
                colCodInstrVoz.MinimumWidth = 100;
                colCodInstrVoz.ReadOnly = true;
                colCodInstrVoz.FillWeight = 100;
                colCodInstrVoz.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodInstrVoz.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrVoz.MaxInputLength = 20;
                colCodInstrVoz.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodVoz = new DataGridViewTextBoxColumn();
                colCodVoz.DataPropertyName = "CodVoz";
                colCodVoz.HeaderText = "Código";
                colCodVoz.Name = "CodVoz";
                colCodVoz.Width = 60;
                colCodVoz.Frozen = false;
                colCodVoz.MinimumWidth = 55;
                colCodVoz.ReadOnly = true;
                colCodVoz.FillWeight = 100;
                colCodVoz.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodVoz.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodVoz.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescVoz";
                colDescricao.HeaderText = "Voz Alternativa";
                colDescricao.Name = "DescVoz";
                colDescricao.Width = 280;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colEscrita = new DataGridViewCheckBoxColumn();
                colEscrita.DataPropertyName = "Escrita";
                colEscrita.HeaderText = "Escrita";
                colEscrita.Name = "Escrita";
                colEscrita.Width = 65;
                colEscrita.Frozen = false;
                colEscrita.MinimumWidth = 60;
                colEscrita.ReadOnly = false;
                colEscrita.FillWeight = 100;
                colEscrita.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colEscrita.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEscrita.Visible = true;
                ///5ª coluna
                DataGridViewCheckBoxColumn colAcima = new DataGridViewCheckBoxColumn();
                colAcima.DataPropertyName = "Acima";
                colAcima.HeaderText = "Acima";
                colAcima.Name = "Acima";
                colAcima.Width = 65;
                colAcima.Frozen = false;
                colAcima.MinimumWidth = 60;
                colAcima.ReadOnly = false;
                colAcima.FillWeight = 100;
                colAcima.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colAcima.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAcima.Visible = true;
                ///6ª coluna
                DataGridViewCheckBoxColumn colAbaixo = new DataGridViewCheckBoxColumn();
                colAbaixo.DataPropertyName = "Abaixo";
                colAbaixo.HeaderText = "Abaixo";
                colAbaixo.Name = "Abaixo";
                colAbaixo.Width = 65;
                colAbaixo.Frozen = false;
                colAbaixo.MinimumWidth = 60;
                colAbaixo.ReadOnly = false;
                colAbaixo.FillWeight = 100;
                colAbaixo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colAbaixo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAbaixo.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                gridAlterna.Columns.Add(colCodInstrVoz);
                gridAlterna.Columns.Add(colCodVoz);
                gridAlterna.Columns.Add(colDescricao);
                gridAlterna.Columns.Add(colEscrita);
                gridAlterna.Columns.Add(colAcima);
                gridAlterna.Columns.Add(colAbaixo);

                ///feito um refresh para fazer a atualização do datagridview
                gridAlterna.Refresh();
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
        /// Função que carrega as Vozes Principal
        /// </summary>
        /// <param name="CodInstr"></param>
        private void carregaVozPrincipal(string CodInstr)
        {
            try
            {
                List<MOD_instrumentoVozPrincipal> listaNova = new List<MOD_instrumentoVozPrincipal>();

                objBLL = new BLL_instrumento();
                listaVozPrincipal = objBLL.buscarInstrumentoVozPrincipal(CodInstr);

                objBLL = new BLL_instrumento();
                listaVozesPrincipal = objBLL.buscarVozesPrincipal(CodInstr);

                foreach (MOD_voz objEnt_Voz in listaVozesPrincipal)
                {
                    MOD_instrumentoVozPrincipal ent = new MOD_instrumentoVozPrincipal();

                    ent.CodInstrumentoVoz = "0";
                    ent.CodVoz = objEnt_Voz.CodVoz;
                    ent.DescVoz = objEnt_Voz.DescVoz;
                    ent.Escrita = false;
                    ent.Acima = false;
                    ent.Abaixo = false;
                    ent.CodInstrumento = "0";

                    listaNova.Add(ent);
                }

                listaVozPrincipal.AddRange(listaNova);
                montaGridVozPrincipal();

                ///vincula a lista ao DataSource do DataGriView
                gridPrincipal.DataSource = listaVozPrincipal;
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
        /// Função que carrega as Vozes Alternativa
        /// </summary>
        /// <param name="CodInstr"></param>
        private void carregaVozAlterna(string CodInstr)
        {
            try
            {
                List<MOD_instrumentoVozAlternativa> listaNova = new List<MOD_instrumentoVozAlternativa>();

                objBLL = new BLL_instrumento();
                listaVozAlternativa = objBLL.buscarInstrumentoVozAlternativa(CodInstr);

                objBLL = new BLL_instrumento();
                listaVozesAlternativa = objBLL.buscarVozesAlternativa(CodInstr);

                foreach (MOD_voz objEnt_Voz in listaVozesAlternativa)
                {
                    MOD_instrumentoVozAlternativa ent = new MOD_instrumentoVozAlternativa();

                    ent.CodInstrumentoVoz = "0";
                    ent.CodVoz = objEnt_Voz.CodVoz;
                    ent.DescVoz = objEnt_Voz.DescVoz;
                    ent.Escrita = false;
                    ent.Acima = false;
                    ent.Abaixo = false;
                    ent.CodInstrumento = "0";

                    listaNova.Add(ent);
                }

                listaVozAlternativa.AddRange(listaNova);
                montaGridVozAlterna();

                ///vincula a lista ao DataSource do DataGriView
                gridAlterna.DataSource = listaVozAlternativa;
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

        /// <summary>
        /// Função que abre a Caixa de diálogo para Pesquisar a Foto
        /// </summary>
        private void buscarFoto()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Carregar Foto";
                dlg.Filter = "JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp";

                if (dlg.ShowDialog().Equals(DialogResult.OK))
                {
                    try
                    {
                        pctFoto.Image = new Bitmap(dlg.OpenFile());
                        foto = dlg.FileName;
                    }
                    catch (Exception ex)
                    {
                        excp = new clsException(ex);
                    }
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

        #endregion

    }
}
