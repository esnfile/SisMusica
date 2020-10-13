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
using BLL.licao;
using BLL.Funcoes;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using ENT.licao;

namespace ccbtest
{
    public partial class frmMetodoTeste : Form
    {
        public frmMetodoTeste(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;

                //Carrega as Combos boxes
                apoio.carregaComboFamilia(cboFamilia);

                carregaLicaoTesteMet(Convert.ToString(cboInstrumento.SelectedValue));
                disabledForm();
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

        string CodLicaoMet;
        string DescInstrMet;
        string DescMet;
        string AplicaEmMet;

        string CodLicaoEscala;
        string DescInstrEscala;
        string DescEscala;
        string AplicaEmEscala;

        string CodLicaoHino;
        string DescInstrHino;
        string DescHino;
        string AplicaEmHino;

        int IndiceMet;
        int IndiceEscala;
        int IndiceHino;

        clsException excp;
        List<MOD_acessos> listaAcesso = null;

        BLL_licaoTesteMet objBLL_licaoTesteMet = null;
        MOD_licaoTesteMet objEnt_licaoTesteMet = null;
        List<MOD_licaoTesteMet> listaLicaoTesteMet = new List<MOD_licaoTesteMet>();

        BLL_licaoTesteEscala objBLL_licaoTesteEsc = null;
        MOD_licaoTesteEscala objEnt_licaoTesteEsc = null;
        List<MOD_licaoTesteEscala> listaLicaoTesteEsc = new List<MOD_licaoTesteEscala>();

        BLL_licaoTesteHino objBLL_licaoTesteHino = null;
        MOD_licaoTesteHino objEnt_licaoTesteHino = null;
        List<MOD_licaoTesteHino> listaLicaoTesteHino = new List<MOD_licaoTesteHino>();

        BLL_metodoInstr objBLL_Met = null;
        BindingList<MOD_metodoInstr> listaMet = null;

        BLL_escala objBLL_Escala = null;
        List<MOD_escala> listaEscala = null;

        BLL_hinario objBLL_Hinario = null;
        List<MOD_hinario> listaHinario = null;

        BLL_instrumento objBLL_Instr = null;
        List<MOD_instrumento> listaInstrumento = null;
        List<MOD_instrumentoHinario> listaInstrHinario = null;

        Form formulario;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        #endregion

        #region eventos do formulario

        private void frmMetodoTeste_Load(object sender, EventArgs e)
        {
            try
            {
                verPermMet(gridMet);

                pctRjm.Image = imgLicaoTeste.Images[0];
                pctMeiaHora.Image = imgLicaoTeste.Images[1];
                pctCulto.Image = imgLicaoTeste.Images[2];
                pctOficial.Image = imgLicaoTeste.Images[3];
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
        private void frmMetodoTeste_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult sair;
                sair = MessageBox.Show("Deseja sair?" + '\n' + "Os registros não salvos serão perdidos!", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sair.Equals(DialogResult.No))
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
        private void btnFechar_Click(object sender, EventArgs e)
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
        private void tabTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                disabledForm();
                if (tabTipo.SelectedTab.Name.Equals("tabMetodo"))
                {
                    if (string.IsNullOrEmpty(cboInstrumento.Text))
                    {
                        funcoes.gridLicaoTeste(gridMet, "LicaoTesteMet");
                    }
                    else
                    {
                        carregaLicaoTesteMet(Convert.ToString(cboInstrumento.SelectedValue));
                        verPermMet(gridMet);
                    }
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabHino"))
                {
                    if (string.IsNullOrEmpty(cboInstrumento.Text))
                    {
                        funcoes.gridLicaoTeste(gridHino, "LicaoTesteHino");
                    }
                    else
                    {
                        carregaLicaoPreTesteHino(Convert.ToString(cboInstrumento.SelectedValue));
                        verPermHino(gridHino);
                    }
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabEscala"))
                {
                    if (string.IsNullOrEmpty(cboInstrumento.Text))
                    {
                        funcoes.gridLicaoTeste(gridEscala, "LicaoTesteEscala");
                    }
                    else
                    {
                        carregaLicaoPreTesteEscala(Convert.ToString(cboInstrumento.SelectedValue));
                        verPermEscala(gridEscala);
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
        }
        private void cboInstrumento_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (tabTipo.SelectedTab.Name.Equals("tabMetodo"))
                {
                    apoio.Aguarde("Carregando métodos...");
                    carregaLicaoTesteMet(Convert.ToString(cboInstrumento.SelectedValue));
                    limparMet();
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabHino"))
                {
                    apoio.Aguarde("Carregando hinos...");
                    carregaLicaoPreTesteHino(Convert.ToString(cboInstrumento.SelectedValue));
                    limparHino();
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabEscala"))
                {
                    apoio.Aguarde("Carregando escalas...");
                    carregaLicaoPreTesteEscala(Convert.ToString(cboInstrumento.SelectedValue));
                    limparEscala();
                }
                disabledForm();
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
        private void cboFamilia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando instrumentos...");
                apoio.carregaComboInstrumento(cboInstrumento, Convert.ToString(cboFamilia.SelectedValue));
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

        #region Aba Metodo

        private void cboMetMetodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void cboMetMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMetMetodo.SelectedValue != null)
                {
                    foreach (MOD_metodoInstr linha in listaMet)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodMetodo.Equals(Convert.ToString(cboMetMetodo.SelectedValue)))
                        {
                            if (linha.PaginaFase.Equals("Fase"))
                            {
                                lblPaginaFase.Text = "Fase";
                                lbMetFase.Enabled = true;
                                txtMetFase.Enabled = true;
                                txtMetFase.Value = 0;
                                lbMetPagina.Enabled = true;
                                txtMetPagina.Enabled = true;
                                txtMetPagina.Value = 0;
                                lbMetLicao.Enabled = true;
                                txtMetLicao.Enabled = true;
                                txtMetLicao.Value = 0;
                                txtMetAteFase.Text = string.IsNullOrEmpty(linha.FaseFim) ? "000" : Convert.ToString(linha.FaseFim);
                                txtMetAtePag.Text = string.IsNullOrEmpty(linha.PaginaFim) ? "000" : Convert.ToString(linha.PaginaFim);
                                txtMetAteLicao.Text = string.IsNullOrEmpty(linha.LicaoFim) ? "000" : Convert.ToString(linha.LicaoFim);
                            }
                            else if (linha.PaginaFase.Equals("Página"))
                            {
                                lblPaginaFase.Text = "Página";
                                lbMetFase.Enabled = false;
                                txtMetFase.Enabled = false;
                                txtMetFase.Value = 0;
                                lbMetPagina.Enabled = true;
                                txtMetPagina.Enabled = true;
                                txtMetPagina.Value = 0;
                                lbMetLicao.Enabled = true;
                                txtMetLicao.Enabled = true;
                                txtMetLicao.Value = 0;
                                txtMetAteFase.Text = string.IsNullOrEmpty(linha.FaseFim) ? "000" : Convert.ToString(linha.FaseFim);
                                txtMetAtePag.Text = string.IsNullOrEmpty(linha.PaginaFim) ? "000" : Convert.ToString(linha.PaginaFim);
                                txtMetAteLicao.Text = string.IsNullOrEmpty(linha.LicaoFim) ? "000" : Convert.ToString(linha.LicaoFim);
                            }
                            else
                            {
                                lblPaginaFase.Text = "Lição";
                                lbMetFase.Enabled = false;
                                txtMetFase.Enabled = false;
                                txtMetFase.Value = 0;
                                lbMetPagina.Enabled = false;
                                txtMetPagina.Enabled = false;
                                txtMetPagina.Value = 0;
                                lbMetLicao.Enabled = true;
                                txtMetLicao.Enabled = true;
                                txtMetLicao.Value = 0;
                                txtMetAteFase.Text = string.IsNullOrEmpty(linha.FaseFim) ? "000" : Convert.ToString(linha.FaseFim);
                                txtMetAtePag.Text = string.IsNullOrEmpty(linha.PaginaFim) ? "000" : Convert.ToString(linha.PaginaFim);
                                txtMetAteLicao.Text = string.IsNullOrEmpty(linha.LicaoFim) ? "000" : Convert.ToString(linha.LicaoFim);
                            }
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
        }
        private void btnMetSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarMet();
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
        private void btnMetCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limparMet();
                disabledForm();
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

        private void gridMet_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                //if (gridMetodoInstr != null || gridMetodoInstr.Rows.Count > 0)
                //{
                //    gridInstrumento.SelectionChanged -= new EventHandler(gridInstrumento_SelectionChanged);

                //    IndiceMet = gridMetodoInstr.CurrentRow.Index;
                //    preencheMetodoInstr(IndiceMet);
                //    CodMetInstr = gridMetodoInstr["CodMetodoInstr", IndiceMet].Value.ToString();

                //    gridInstrumento.SelectionChanged += new EventHandler(gridInstrumento_SelectionChanged);
                //}
                //else
                //{
                //    gridMetodoInstr.DataSource = null;
                //}
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

        private void gridMet_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermMet(gridMet);
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
        private void gridMet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnMetEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde("Carregando informações...");

                    IndiceMet = gridMet.CurrentRow.Index;
                    enabledForm();
                    preencheMet(IndiceMet);
                    CodLicaoMet = gridMet["CodLicaoMet", IndiceMet].Value.ToString();
                    gpoMetodo.Enabled = true;
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
        private void btnMetIns_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboInstrumento.SelectedIndex.Equals(-1))
                {
                    limparMet();
                    enabledForm();
                    gpoMetodo.Enabled = true;
                }
                else
                {
                    throw new Exception("Selecione um Instrumento para continuar!");
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
        private void btnMetEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando informações...");

                IndiceMet = gridMet.CurrentRow.Index;
                gpoMetodo.Enabled = true;
                enabledForm();
                preencheMet(IndiceMet);
                CodLicaoMet = gridMet["CodLicaoMet", IndiceMet].Value.ToString();
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
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    IndiceMet = gridMet.CurrentRow.Index;
                    CodLicaoMet = gridMet["CodLicaoMet", IndiceMet].Value.ToString();
                    DescMet = gridMet["DescMetodo", IndiceMet].Value.ToString();
                    DescInstrMet = gridMet["DescInstrumento", IndiceMet].Value.ToString();
                    AplicaEmMet = gridMet["AplicaEm", IndiceMet].Value.ToString();

                    deleteMet(IndiceMet);
                    carregaLicaoTesteMet(Convert.ToString(cboInstrumento.SelectedValue));
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

        private void optMetRjm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando métodos...");
                if (optMetRjm.Checked.Equals(true))
                {
                    lblMetAplicarEm.Text = "Reunião de Jovens";
                    carregaMetodosMet(Convert.ToString(cboInstrumento.SelectedValue), "Reunião de Jovens", "Instrumento");
                }
                else
                {
                    lblMetAplicarEm.Text = string.Empty;
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
        private void optMetCulto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando métodos...");
                if (optMetCulto.Checked.Equals(true))
                {
                    lblMetAplicarEm.Text = "Culto Oficial";
                    carregaMetodosMet(Convert.ToString(cboInstrumento.SelectedValue), "Culto Oficial", "Instrumento");
                }
                else
                {
                    lblMetAplicarEm.Text = string.Empty;
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
        private void optMetOficial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando métodos...");
                if (optMetOficial.Checked.Equals(true))
                {
                    lblMetAplicarEm.Text = "Oficialização";
                    carregaMetodosMet(Convert.ToString(cboInstrumento.SelectedValue), "Oficialização", "Instrumento");
                }
                else
                {
                    lblMetAplicarEm.Text = string.Empty;
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
        private void txtMetPagina_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMetPagina.Value.Equals(txtMetPagina.Maximum))
                {
                    txtMetLicao.Maximum = Convert.ToInt16(txtMetAteLicao.Text);
                }
                else
                {
                    txtMetLicao.Maximum = 999;
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
        private void optMetMeia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando métodos...");
                if (optMetMeia.Checked.Equals(true))
                {
                    lblMetAplicarEm.Text = "Meia Hora";
                    carregaMetodosMet(Convert.ToString(cboInstrumento.SelectedValue), "Meia Hora", "Instrumento");
                }
                else
                {
                    lblMetAplicarEm.Text = string.Empty;
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

        #endregion

        #region Aba Hinario

        private void cboHinario_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void cboHinario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboHinario.SelectedValue != null)
                {
                    foreach (MOD_hinario linha in listaHinario)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodHinario.Equals(Convert.ToString(cboHinario.SelectedValue)))
                        {
                            definirHino();
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
        }
        private void btnHinoSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarHino();
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
        private void btnHinoCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limparHino();
                disabledForm();
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
        private void txtHinoNumero_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtHinoNumero.Value < Convert.ToInt16(txtHinoInicio.Text) ||
                    txtHinoNumero.Value > Convert.ToInt16(txtHinoFim.Text))
                {
                    txtHinoNumero.Focus();
                    throw new Exception("Informe um hino entre os disponiveis!");
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void gridHino_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnHinoEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde("Carregando informações...");

                    IndiceHino = gridHino.CurrentRow.Index;
                    enabledForm();
                    preencheHino(IndiceHino);
                    CodLicaoHino = gridHino["CodLicaoHino", IndiceHino].Value.ToString();
                    gpoHino.Enabled = true;
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
        private void gridHino_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermHino(gridHino);
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

        private void btnHinoInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboInstrumento.SelectedIndex.Equals(-1))
                {
                    limparHino();
                    enabledForm();
                    carregaHino(Convert.ToString(cboInstrumento.SelectedValue));
                    gpoHino.Enabled = true;
                }
                else
                {
                    throw new Exception("Selecione um Instrumento para continuar!");
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
        private void btnHinoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando informações...");

                IndiceHino = gridHino.CurrentRow.Index;
                enabledForm();
                preencheHino(IndiceHino);
                CodLicaoHino = gridHino["CodLicaoHino", IndiceHino].Value.ToString();
                gpoHino.Enabled = true;
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
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    IndiceHino = gridHino.CurrentRow.Index;
                    CodLicaoHino = gridHino["CodLicaoHino", IndiceHino].Value.ToString();
                    DescHino = gridHino["DescHino", IndiceHino].Value.ToString();
                    DescInstrHino = gridHino["DescInstrHino", IndiceHino].Value.ToString();
                    AplicaEmHino = gridHino["AplicaEmHino", IndiceHino].Value.ToString();

                    deleteHino(IndiceHino);
                    carregaLicaoPreTesteHino(Convert.ToString(cboInstrumento.SelectedValue));
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

        private void optHinoRjm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optHinoRjm.Checked.Equals(true))
                {
                    apoio.Aguarde("Carregando hinários...");
                    lblHinoAplicarEm.Text = "Reunião de Jovens";
                    definirHino();
                }
                else
                {
                    lblHinoAplicarEm.Text = string.Empty;
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
        private void optHinoCulto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optHinoCulto.Checked.Equals(true))
                {
                    apoio.Aguarde("Carregando hinários...");
                    lblHinoAplicarEm.Text = "Culto Oficial";
                    definirHino();
                }
                else
                {
                    lblHinoAplicarEm.Text = string.Empty;
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
        private void optHinoOficial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optHinoOficial.Checked.Equals(true))
                {
                    apoio.Aguarde("Carregando hinários...");
                    lblHinoAplicarEm.Text = "Oficialização";
                    definirHino();
                }
                else
                {
                    lblHinoAplicarEm.Text = string.Empty;
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
        private void optHinoMeia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optHinoMeia.Checked.Equals(true))
                {
                    apoio.Aguarde("Carregando hinários...");
                    lblHinoAplicarEm.Text = "Meia Hora";
                    definirHino();
                }
                else
                {
                    lblHinoAplicarEm.Text = string.Empty;
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

        #endregion

        #region Escala

        private void cboEscala_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void cboEscala_SelectedIndexChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (cboTipoEscala.SelectedValue != null)
            //    {
            //        foreach (MOD_escala linha in listaEscala)
            //        {
            //            ///verifica a condição especificada para exibir a imagem
            //            if (linha.CodEscala.Equals(Convert.ToString(cboTipoEscala.SelectedValue)))
            //            {
            //                break;
            //            }
            //        }
            //    }
            //}
            //catch (SqlException exl)
            //{
            //    excp = new clsException(exl);
            //}
            //catch (Exception ex)
            //{
            //    excp = new clsException(ex);
            //}
        }
        private void cboTipoEscala_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando escalas...");
                carregaEscala(Convert.ToString(cboTipoEscala.SelectedValue));
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
        private void cboTipoEscala_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void btnEscalaSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarEscala();
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
        private void btnEscalaCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limparEscala();
                disabledForm();
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

        private void gridEscala_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnEscalaEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde("Carregando informações...");

                    IndiceEscala = gridEscala.CurrentRow.Index;
                    enabledForm();
                    preencheEscala(IndiceEscala);
                    CodLicaoEscala = gridEscala["CodLicaoEscala", IndiceEscala].Value.ToString();
                    gridEscala.Enabled = true;
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
        private void btnEscalaInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboInstrumento.SelectedIndex.Equals(-1))
                {
                    limparEscala();
                    enabledForm();
                    gpoEscala.Enabled = true;
                }
                else
                {
                    throw new Exception("Selecione um Instrumento para continuar!");
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
        private void btnEscalaEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando informações...");

                IndiceEscala = gridEscala.CurrentRow.Index;
                enabledForm();
                preencheEscala(IndiceEscala);
                CodLicaoEscala = gridEscala["CodLicaoEscala", IndiceEscala].Value.ToString();
                gpoEscala.Enabled = true;
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
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    IndiceEscala = gridEscala.CurrentRow.Index;
                    CodLicaoEscala = gridEscala["CodLicaoEscala", IndiceEscala].Value.ToString();
                    DescEscala = gridEscala["DescEscala", IndiceEscala].Value.ToString();
                    DescInstrEscala = gridEscala["DescInstrEscala", IndiceEscala].Value.ToString();
                    AplicaEmEscala = gridEscala["AplicaEmEscala", IndiceEscala].Value.ToString();

                    deleteEscala(IndiceEscala);
                    carregaLicaoPreTesteEscala(Convert.ToString(cboInstrumento.SelectedValue));
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

        private void optEscalaRjm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optEscalaRjm.Checked.Equals(true))
                {
                    lblEscalaAplicarEm.Text = "Reunião de Jovens";
                }
                else
                {
                    lblEscalaAplicarEm.Text = string.Empty;
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
        private void optEscalaCulto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optEscalaCulto.Checked.Equals(true))
                {
                    lblEscalaAplicarEm.Text = "Culto Oficial";
                }
                else
                {
                    lblEscalaAplicarEm.Text = string.Empty;
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
        private void optEscalaOficial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optEscalaOficial.Checked.Equals(true))
                {
                    lblEscalaAplicarEm.Text = "Oficialização";
                }
                else
                {
                    lblEscalaAplicarEm.Text = string.Empty;
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
        private void optEscalaMeia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optEscalaMeia.Checked.Equals(true))
                {
                    lblEscalaAplicarEm.Text = "Meia Hora";
                }
                else
                {
                    lblEscalaAplicarEm.Text = string.Empty;
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

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                lblFamilia.Enabled = true;
                cboFamilia.Enabled = true;
                lblInstrumento.Enabled = true;
                cboInstrumento.Enabled = true;
                tabTipo.Enabled = true;
                tabMetodo.Enabled = true;
                tabHino.Enabled = true;
                tabEscala.Enabled = true;

                if (tabTipo.SelectedTab.Name.Equals("tabMetodo"))
                {
                    gpoMetodo.Enabled = false;
                    gridMet.Enabled = true;
                    verPermMet(gridMet);
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabHino"))
                {
                    gpoHino.Enabled = false;
                    gridHino.Enabled = true;
                    verPermHino(gridHino);
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabEscala"))
                {
                    gpoEscala.Enabled = false;
                    gridEscala.Enabled = true;
                    verPermEscala(gridEscala);
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
        internal void enabledForm()
        {
            try
            {
                lblFamilia.Enabled = false;
                cboFamilia.Enabled = false;
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                tabTipo.Enabled = true;

                if (tabTipo.SelectedTab.Name.Equals("tabMetodo"))
                {
                    btnMetEditar.Enabled = false;
                    btnMetIns.Enabled = false;
                    btnMetExcluir.Enabled = false;
                    gridMet.Enabled = false;

                    if (cboFamilia.SelectedValue.Equals("004"))
                    {
                        optMetMeia.Enabled = true;
                    }
                    else
                    {
                        optMetMeia.Enabled = false;
                    }
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabHino"))
                {
                    btnHinoEditar.Enabled = false;
                    btnHinoInserir.Enabled = false;
                    btnHinoExcluir.Enabled = false;
                    gridHino.Enabled = false;

                    if (cboFamilia.SelectedValue.Equals("004"))
                    {
                        optHinoMeia.Enabled = true;
                    }
                    else
                    {
                        optHinoMeia.Enabled = false;
                    }
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabEscala"))
                {
                    btnEscalaEditar.Enabled = false;
                    btnEscalaInserir.Enabled = false;
                    btnEscalaExcluir.Enabled = false;
                    gridEscala.Enabled = false;

                    if (cboFamilia.SelectedValue.Equals("004"))
                    {
                        optEscalaMeia.Enabled = true;
                    }
                    else
                    {
                        optEscalaMeia.Enabled = false;
                    }
                    apoio.carregaComboTipoEscala(cboTipoEscala);
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
        /// Função que carrega os Instrumentos
        /// </summary>
        /// <param name="vCodInstr"></param>
        internal void carregaInstrumento(string vCodInstr)
        {
            try
            {
                objBLL_Instr = new BLL_instrumento();
                listaInstrumento = objBLL_Instr.buscarCod(vCodInstr);

                if (listaInstrumento != null && listaInstrumento.Count > 0)
                {
                    cboFamilia.SelectedValue = Convert.ToInt16(listaInstrumento[0].CodFamilia);
                    cboInstrumento.SelectedValue = Convert.ToInt16(listaInstrumento[0].CodInstrumento);
                }
                else
                {
                    abrirForm("frmInstr");
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
        private void abrirForm(string form)
        {
            try
            {
                if (form.Equals("frmInstr"))
                {
                    cboFamilia.SelectedIndex = (-1);
                    cboInstrumento.SelectedIndex = (-1);

                    formulario = new frmPesquisaInstr(this);
                    ((frmPesquisaInstr)formulario).MdiParent = MdiParent;
                    ((frmPesquisaInstr)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaInstr)formulario));
                    ((frmPesquisaInstr)formulario).Show();
                    ((frmPesquisaInstr)formulario).BringToFront();
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
        /// Função que define a imagem do status da conta, se ativo ou inativo
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (linha.Cells["AplicaEm"].Value.ToString().Contains("Reunião de Jovens"))
                    {
                        linha.Cells[0].Value = imgLicaoTeste.Images[0];
                    }
                    else if (linha.Cells["AplicaEm"].Value.ToString().Contains("Culto Oficial"))
                    {
                        linha.Cells[0].Value = imgLicaoTeste.Images[2];
                    }
                    else if (linha.Cells["AplicaEm"].Value.ToString().Contains("Meia Hora"))
                    {
                        linha.Cells[0].Value = imgLicaoTeste.Images[1];
                    }
                    else if (linha.Cells["AplicaEm"].Value.ToString().Contains("Oficialização"))
                    {
                        linha.Cells[0].Value = imgLicaoTeste.Images[3];
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

        #region Metodos

        /// <summary>
        /// Função que valida os campos Metodos
        /// </summary>
        private bool ValidarControlesMet()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (lblMetAplicarEm.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Método > Informe a Aplicação. (Reunião de Jovens, Culto Oficial ou Oficialização)";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (cboMetMetodo.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Método > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblPaginaFase.Text.Equals("Fase"))
                {
                    if (txtMetFase.Value.Equals(0))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Fase deve ser diferente de 0.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtMetPagina.Value.Equals(0))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Página deve ser diferente de 0.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtMetLicao.Value.Equals(0))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Licão deve ser diferente de 0.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                else if (lblPaginaFase.Text.Equals("Página"))
                {
                    if (txtMetPagina.Value.Equals(0))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Página deve ser diferente de 0.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtMetLicao.Value.Equals(0))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Licão deve ser diferente de 0.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                else if (lblPaginaFase.Text.Equals("Lição"))
                {
                    if (txtMetLicao.Value.Equals(0))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Licão deve ser diferente de 0.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }

                if (lblPaginaFase.Text.Equals("Fase"))
                {
                    if (Convert.ToInt16(txtMetFase.Value) > Convert.ToInt16(txtMetAteFase.Text))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Fase informada não pode superior ao Programa mínimo.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    else if (Convert.ToInt16(txtMetFase.Value) <= Convert.ToInt16(txtMetAteFase.Text))
                    {
                        if (Convert.ToInt16(txtMetPagina.Value) > Convert.ToInt16(txtMetAtePag.Text))
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Método > Página informada não pode superior ao Programa mínimo.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                        else if (Convert.ToInt16(txtMetPagina.Value) <= Convert.ToInt16(txtMetAtePag.Text))
                        {
                            if (Convert.ToInt16(txtMetLicao.Value) > Convert.ToInt16(txtMetAteLicao.Text))
                            {
                                blnValida = false;
                                objEnt_Erros = new MOD_erros();
                                objEnt_Erros.Texto = "Aba Método > Lição informada não pode superior ao Programa mínimo.";
                                objEnt_Erros.Grau = "Alto";
                                listaErros.Add(objEnt_Erros);
                            }
                        }
                    }
                }
                else if (lblPaginaFase.Text.Equals("Página"))
                {
                    if (Convert.ToInt16(txtMetPagina.Value) > Convert.ToInt16(txtMetAtePag.Text))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Página informada não pode superior ao Programa mínimo.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    else if (Convert.ToInt16(txtMetPagina.Value).Equals(Convert.ToInt16(txtMetAtePag.Text)))
                    {
                        if (Convert.ToInt16(txtMetLicao.Value) > Convert.ToInt16(txtMetAteLicao.Text))
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Método > Lição informada não pode superior ao Programa mínimo.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else if (lblPaginaFase.Text.Equals("Lição"))
                {
                    if (Convert.ToInt16(txtMetLicao.Value) > Convert.ToInt16(txtMetAteLicao.Text))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Método > Lição informada não pode superior ao Programa mínimo.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
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
        /// Função que preenche o Combo Metodos
        /// <para> TipoMetodo In('Solfejo', 'Ritmo' ou 'Instrumento'))</para>
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodosMet(string CodInstr, string AplicaEm, string TipoMetodo)
        {
            try
            {
                objBLL_Met = new BLL_metodoInstr();
                listaMet = new BindingList<MOD_metodoInstr>();

                listaMet = objBLL_Met.buscarInstrumento(CodInstr, AplicaEm, TipoMetodo);

                cboMetMetodo.DataSource = listaMet;
                cboMetMetodo.ValueMember = "CodMetodo";
                cboMetMetodo.DisplayMember = "DescMetodo";
                cboMetMetodo.SelectedIndex = (-1);
                txtMetAtePag.Text = string.Empty;
                txtMetAteLicao.Text = string.Empty;
                txtMetAteFase.Text = string.Empty;
                txtMetFase.Value = 0;
                txtMetPagina.Value = 0;
                txtMetLicao.Value = 0;
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
        private MOD_licaoTesteMet criarTabelaMet()
        {
            try
            {
                objEnt_licaoTesteMet = new MOD_licaoTesteMet();
                objEnt_licaoTesteMet.CodLicaoMet = lblCodLicaoMet.Text;
                objEnt_licaoTesteMet.CodInstrumento = Convert.ToString(cboInstrumento.SelectedValue);
                objEnt_licaoTesteMet.DescInstrumento = cboInstrumento.Text;
                objEnt_licaoTesteMet.CodMetodo = Convert.ToString(cboMetMetodo.SelectedValue);
                objEnt_licaoTesteMet.DescMetodo = cboMetMetodo.Text;
                objEnt_licaoTesteMet.AplicaEm = lblMetAplicarEm.Text;
                objEnt_licaoTesteMet.FaseMet = Convert.ToString(txtMetFase.Value);
                objEnt_licaoTesteMet.PaginaMet = Convert.ToString(txtMetPagina.Value);
                objEnt_licaoTesteMet.LicaoMet = Convert.ToString(txtMetLicao.Value);

                //retorna a classe de propriedades preenchida com os textbox
                return objEnt_licaoTesteMet;
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
        /// Função que carrega os Instrumentos
        /// </summary>
        private void carregaLicaoTesteMet(string CodInstr)
        {
            try
            {

                objBLL_licaoTesteMet = new BLL_licaoTesteMet();
                listaLicaoTesteMet = objBLL_licaoTesteMet.buscarLicaoMet(CodInstr);

                funcoes.gridLicaoTeste(gridMet, "LicaoTesteMet");
                ///vincula a lista ao DataSource do DataGriView
                gridMet.DataSource = listaLicaoTesteMet;
                definirImagens(gridMet);
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
        private void salvarMet()
        {
            try
            {
                if (ValidarControlesMet().Equals(true))
                {
                    objBLL_licaoTesteMet = new BLL_licaoTesteMet();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL_licaoTesteMet.salvar(criarTabelaMet());

                    //Atualiza o grid com as lições
                    carregaLicaoTesteMet(Convert.ToString(cboInstrumento.SelectedValue));

                    //Limpa os controle e desabilita
                    limparMet();
                    disabledForm();
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
        /// Função que limpa os controle para Inserir novo metodo
        /// </summary>
        private void limparMet()
        {
            try
            {
                lblCodLicaoMet.Text = string.Empty;
                cboMetMetodo.DataSource = null;
                cboMetMetodo.SelectedValue = (-1);
                optMetRjm.Checked = false;
                optMetCulto.Checked = false;
                optMetOficial.Checked = false;
                txtMetFase.Value = 0;
                txtMetPagina.Value = 0;
                txtMetLicao.Value = 0;
                txtMetAteFase.Text = string.Empty;
                txtMetAtePag.Text = string.Empty;
                txtMetAteLicao.Text = string.Empty;
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
        /// Função que Deleta a linha selecionada no gridMet
        /// </summary>
        private void deleteMet(int Indice)
        {
            try
            {
                MOD_licaoTesteMet ent = new MOD_licaoTesteMet();
                ent.CodLicaoMet = CodLicaoMet;
                ent.DescInstrumento = DescInstrMet;
                ent.DescMetodo = DescMet;
                ent.AplicaEm = AplicaEmMet;

                objBLL_licaoTesteMet = new BLL_licaoTesteMet();
                objBLL_licaoTesteMet.excluir(ent);
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
        /// Função que preenche os dados do Grid para os TextBoxes
        /// </summary>
        /// <param name="Indice"></param>
        private void preencheMet(int Indice)
        {
            try
            {
                tabMetodo.Enabled = true;
                tabHino.Enabled = false;
                tabEscala.Enabled = false;
                tabTipo.SelectTab("tabMetodo");

                //objBLL_licaoTesteMet = new BLL_licaoTesteMet();
                //listaLicaoTesteMet = new List<MOD_licaoTesteMet>();

                lblMetAplicarEm.Text = listaLicaoTesteMet[Indice].AplicaEm;
                verificarMet();
                //carregaMetodosMet(Convert.ToString(cboInstrumento.SelectedValue));
                //lblCodMetodo.Text = listaLicaoTesteMet[Indice].CodMetodo;
                cboMetMetodo.SelectedValue = listaLicaoTesteMet[Indice].CodMetodo;
                lblCodLicaoMet.Text = listaLicaoTesteMet[Indice].CodLicaoMet;
                txtMetFase.Value = Convert.ToInt16(listaLicaoTesteMet[Indice].FaseMet);
                txtMetPagina.Value = Convert.ToInt16(listaLicaoTesteMet[Indice].PaginaMet);
                txtMetLicao.Value = Convert.ToInt16(listaLicaoTesteMet[Indice].LicaoMet);

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
        internal void verificarMet()
        {
            try
            {
                ///verifica a situação
                if (lblMetAplicarEm.Text.Equals("Reunião de Jovens"))
                {
                    optMetRjm.Checked = true;
                }
                else if (lblMetAplicarEm.Text.Equals("Culto Oficial"))
                {
                    optMetCulto.Checked = true;
                }
                else if (lblMetAplicarEm.Text.Equals("Meia Hora"))
                {
                    optMetMeia.Checked = true;
                }
                else if (lblMetAplicarEm.Text.Equals("Oficialização"))
                {
                    optMetOficial.Checked = true;
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

        #region Hinario

        /// <summary>
        /// Função que valida os campos Hino
        /// </summary>
        private bool ValidarControlesHino()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (lblHinoAplicarEm.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Hinário > Informe a Aplicação. (Reunião de Jovens, Meia Hora, Culto Oficial ou Oficialização)";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (cboHinario.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Hinário > Hinário! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtHinoNumero.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Hinário > Hino deve ser diferente de 0.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (Convert.ToInt16(txtHinoNumero.Value) < Convert.ToInt16(txtHinoInicio.Text) ||
                    Convert.ToInt16(txtHinoNumero.Value) > Convert.ToInt16(txtHinoFim.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Hinário > Hino deve estar entre os disponíveis.";
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
        internal void carregaHino(string CodInstr)
        {
            try
            {
                objBLL_Instr = new BLL_instrumento();
                listaHinario = new List<MOD_hinario>();

                listaInstrHinario = objBLL_Instr.buscarInstrumentoHinario(CodInstr);

                cboHinario.DataSource = listaInstrHinario;
                cboHinario.ValueMember = "CodHinario";
                cboHinario.DisplayMember = "DescHinario";
                cboHinario.SelectedIndex = (-1);
                txtHinoNumero.Value = 0;
                txtHinoInicio.Text = string.Empty;
                txtHinoFim.Text = string.Empty;
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
        private MOD_licaoTesteHino criarTabelaHino()
        {
            try
            {
                objEnt_licaoTesteHino = new MOD_licaoTesteHino();
                objEnt_licaoTesteHino.CodLicaoHino = lblCodLicaoHino.Text;
                objEnt_licaoTesteHino.CodInstrumento = Convert.ToString(cboInstrumento.SelectedValue);
                objEnt_licaoTesteHino.DescInstrumento = cboInstrumento.Text;
                objEnt_licaoTesteHino.CodHinario = Convert.ToString(cboHinario.SelectedValue);
                objEnt_licaoTesteHino.DescHinario = cboHinario.Text;
                objEnt_licaoTesteHino.AplicaEm = lblHinoAplicarEm.Text;
                objEnt_licaoTesteHino.Hino = Convert.ToString(txtHinoNumero.Value);

                //retorna a classe de propriedades preenchida com os textbox
                return objEnt_licaoTesteHino;
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
        /// Função que carrega os Instrumentos
        /// </summary>
        private void carregaLicaoPreTesteHino(string CodInstr)
        {
            try
            {

                objBLL_licaoTesteHino = new BLL_licaoTesteHino();
                listaLicaoTesteHino = objBLL_licaoTesteHino.buscarLicaoHino(CodInstr);

                funcoes.gridLicaoTeste(gridHino, "LicaoTesteHino");
                ///vincula a lista ao DataSource do DataGriView
                gridHino.DataSource = listaLicaoTesteHino;
                definirImagens(gridHino);
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
        private void salvarHino()
        {
            try
            {
                if (ValidarControlesHino().Equals(true))
                {
                    objBLL_licaoTesteHino = new BLL_licaoTesteHino();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL_licaoTesteHino.salvar(criarTabelaHino());

                    //Atualiza o grid com as lições
                    carregaLicaoPreTesteHino(Convert.ToString(cboInstrumento.SelectedValue));

                    //Limpa os controle e desabilita
                    limparHino();
                    disabledForm();
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
        /// Função que limpa os controle para Inserir novo Hino
        /// </summary>
        private void limparHino()
        {
            try
            {
                lblCodLicaoHino.Text = string.Empty;
                cboHinario.SelectedValue = (-1);
                optHinoRjm.Checked = false;
                optHinoCulto.Checked = false;
                optHinoOficial.Checked = false;
                txtHinoNumero.Value = 0;
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
        /// Função que limpa os controle para Inserir novo Hino
        /// </summary>
        private void definirHino()
        {
            try
            {
                if (optHinoRjm.Checked.Equals(true))
                {
                    txtHinoInicio.Text = "431";
                    txtHinoFim.Text = "480";
                }
                else if (optHinoCulto.Checked.Equals(true))
                {
                    txtHinoInicio.Text = "001";
                    txtHinoFim.Text = "480";
                }
                else if (optHinoMeia.Checked.Equals(true))
                {
                    txtHinoInicio.Text = "001";
                    txtHinoFim.Text = "480";
                }
                else if (optHinoOficial.Checked.Equals(true))
                {
                    txtHinoInicio.Text = "001";
                    txtHinoFim.Text = "480";
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
        /// Função que Deleta a linha selecionada no gridHino
        /// </summary>
        private void deleteHino(int Indice)
        {
            try
            {
                MOD_licaoTesteHino ent = new MOD_licaoTesteHino();
                ent.CodLicaoHino = CodLicaoHino;
                ent.DescInstrumento = DescInstrHino;
                ent.DescHinario = DescHino;
                ent.AplicaEm = AplicaEmMet;

                objBLL_licaoTesteHino = new BLL_licaoTesteHino();
                objBLL_licaoTesteHino.excluir(ent);
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
        /// Função que preenche os dados do Grid para os TextBoxes
        /// </summary>
        /// <param name="Indice"></param>
        private void preencheHino(int Indice)
        {
            try
            {
                tabTipo.Enabled = true;
                tabHino.Enabled = true;
                tabTipo.SelectTab("tabHino");
                tabMetodo.Enabled = false;
                tabEscala.Enabled = false;

                lblHinoAplicarEm.Text = listaLicaoTesteHino[Indice].AplicaEm;
                carregaHino(Convert.ToString(cboInstrumento.SelectedValue));
                cboHinario.SelectedValue = listaLicaoTesteHino[Indice].CodHinario;
                lblCodLicaoHino.Text = listaLicaoTesteHino[Indice].CodLicaoHino;
                txtHinoNumero.Value = Convert.ToInt16(listaLicaoTesteHino[Indice].Hino);
                verificarHino();
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
        internal void verificarHino()
        {
            try
            {
                ///verifica a situação
                if (lblHinoAplicarEm.Text.Equals("Reunião de Jovens"))
                {
                    optHinoRjm.Checked = true;
                }
                else if (lblHinoAplicarEm.Text.Equals("Culto Oficial"))
                {
                    optHinoCulto.Checked = true;
                }
                else if (lblHinoAplicarEm.Text.Equals("Meia Hora"))
                {
                    optHinoMeia.Checked = true;
                }
                else if (lblHinoAplicarEm.Text.Equals("Oficialização"))
                {
                    optHinoOficial.Checked = true;
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

        #region Escala

        /// <summary>
        /// Função que valida os campos Escala
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
                if (lblEscalaAplicarEm.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Escala > Informe a Aplicação. (Reunião de Jovens, Culto Oficial ou Oficialização)";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (cboEscala.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Escala > Escala! Campo obrigatório.";
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
        /// Função que preenche o ComboBox Escala
        /// </summary>
        /// <returns></returns>
        internal void carregaEscala(string CodTipoEscala)
        {
            try
            {
                objBLL_Escala = new BLL_escala();
                listaEscala = new List<MOD_escala>();

                listaEscala = objBLL_Escala.buscarTipo(CodTipoEscala);

                cboEscala.DataSource = listaEscala;
                cboEscala.ValueMember = "CodEscala";
                cboEscala.DisplayMember = "DescEscala";
                cboEscala.SelectedIndex = (-1);
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
        private MOD_licaoTesteEscala criarTabelaEscala()
        {
            try
            {
                objEnt_licaoTesteEsc = new MOD_licaoTesteEscala();
                objEnt_licaoTesteEsc.CodLicaoEscala = lblCodLicaoEscala.Text;
                objEnt_licaoTesteEsc.CodInstrumento = Convert.ToString(cboInstrumento.SelectedValue);
                objEnt_licaoTesteEsc.DescInstrumento = cboInstrumento.Text;
                objEnt_licaoTesteEsc.CodEscala = Convert.ToString(cboEscala.SelectedValue);
                objEnt_licaoTesteEsc.DescEscala = cboEscala.Text;
                objEnt_licaoTesteEsc.AplicaEm = lblEscalaAplicarEm.Text;
                //retorna a classe de propriedades preenchida com os textbox
                return objEnt_licaoTesteEsc;
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
        /// Função que carrega os Instrumentos
        /// </summary>
        private void carregaLicaoPreTesteEscala(string CodInstr)
        {
            try
            {

                objBLL_licaoTesteEsc = new BLL_licaoTesteEscala();
                listaLicaoTesteEsc = objBLL_licaoTesteEsc.buscarLicaoEscala(CodInstr);

                funcoes.gridLicaoTeste(gridEscala, "LicaoTesteEscala");
                ///vincula a lista ao DataSource do DataGriView
                gridEscala.DataSource = listaLicaoTesteEsc;
                definirImagens(gridEscala);
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
        private void salvarEscala()
        {
            try
            {
                if (ValidarControlesEscala().Equals(true))
                {
                    objBLL_licaoTesteEsc = new BLL_licaoTesteEscala();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL_licaoTesteEsc.salvar(criarTabelaEscala());

                    //Carrega os instrumentos
                    carregaLicaoPreTesteEscala(Convert.ToString(cboInstrumento.SelectedValue));

                    //Limpa os controle e desabilita
                    limparEscala();
                    disabledForm();
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
        /// Função que limpa os controle para Inserir nova Escala
        /// </summary>
        private void limparEscala()
        {
            try
            {
                lblCodLicaoEscala.Text = string.Empty;
                cboTipoEscala.SelectedValue = (-1);
                cboEscala.SelectedValue = (-1);
                optEscalaRjm.Checked = false;
                optEscalaMeia.Checked = false;
                optEscalaCulto.Checked = false;
                optEscalaOficial.Checked = false;
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
                MOD_licaoTesteEscala ent = new MOD_licaoTesteEscala();
                ent.CodLicaoEscala = CodLicaoEscala;
                ent.DescInstrumento = DescInstrEscala;
                ent.DescEscala = DescEscala;
                ent.AplicaEm = AplicaEmEscala;

                objBLL_licaoTesteEsc = new BLL_licaoTesteEscala();
                objBLL_licaoTesteEsc.excluir(ent);
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
        /// Função que preenche os dados do Grid para os TextBoxes
        /// </summary>
        /// <param name="Indice"></param>
        private void preencheEscala(int Indice)
        {
            try
            {
                tabEscala.Enabled = true;
                tabMetodo.Enabled = false;
                tabHino.Enabled = false;
                tabTipo.SelectTab("tabEscala");

                lblEscalaAplicarEm.Text = listaLicaoTesteEsc[Indice].AplicaEm;
                verificarEscala();
                cboTipoEscala.SelectedValue = listaLicaoTesteEsc[Indice].CodTipoEscala;
                carregaEscala(Convert.ToString(cboTipoEscala.SelectedValue));
                cboEscala.SelectedValue = listaLicaoTesteEsc[Indice].CodEscala;
                lblCodLicaoEscala.Text = listaLicaoTesteEsc[Indice].CodLicaoEscala;
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
        internal void verificarEscala()
        {
            try
            {
                ///verifica a situação
                if (lblEscalaAplicarEm.Text.Equals("Reunião de Jovens"))
                {
                    optEscalaRjm.Checked = true;
                }
                else if (lblEscalaAplicarEm.Text.Equals("Culto Oficial"))
                {
                    optEscalaCulto.Checked = true;
                }
                else if (lblEscalaAplicarEm.Text.Equals("Meia Hora"))
                {
                    optEscalaMeia.Checked = true;
                }
                else if (lblEscalaAplicarEm.Text.Equals("Oficialização"))
                {
                    optEscalaOficial.Checked = true;
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

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermMet(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsLicaoPreTesteMet))
                    {
                        btnMetIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotEditLicaoPreTesteMet))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnMetEditar.Enabled = true;
                        }
                        else
                        {
                            btnMetEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotExcLicaoPreTesteMet))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnMetExcluir.Enabled = true;
                        }
                        else
                        {
                            btnMetExcluir.Enabled = false;
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermHino(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsLicaoPreTesteHino))
                    {
                        btnHinoInserir.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotEditLicaoPreTesteHino))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnHinoEditar.Enabled = true;
                        }
                        else
                        {
                            btnHinoEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotExcLicaoPreTesteHino))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnHinoExcluir.Enabled = true;
                        }
                        else
                        {
                            btnHinoExcluir.Enabled = false;
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermEscala(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsLicaoPreTesteEsc))
                    {
                        btnEscalaInserir.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotEditLicaoPreTesteEsc))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnEscalaEditar.Enabled = true;
                        }
                        else
                        {
                            btnEscalaEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotExcLicaoPreTesteEsc))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnEscalaExcluir.Enabled = true;
                        }
                        else
                        {
                            btnEscalaExcluir.Enabled = false;
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