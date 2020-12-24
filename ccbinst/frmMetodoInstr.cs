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

namespace ccbinst
{
    public partial class frmMetodoInstr : Form
    {
        public frmMetodoInstr(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;
                
                carregaInstrumento();
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

        string CodMetInstr;
        string CodInstr;
        string DescInstr;
        string DescMet;
        string CodFamilia;
        int IndiceMet;

        clsException excp;
        List<MOD_acessos> listaAcesso = null;

        BLL_metodoInstr objBLL = null;
        MOD_metodoInstr objEnt = null;
        BindingList<MOD_metodoInstr> listaMetodoInstr = new BindingList<MOD_metodoInstr>();
        List<MOD_metodoInstr> listaDeleteMetodoInstr = new List<MOD_metodoInstr>();

        BindingSource objBinding_Met = null;

        BLL_metodos objBLL_Met = null;
        List<MOD_metodoFamilia> listaMetodoRjm = null;
        List<MOD_metodoFamilia> listaMetodoMeiaHora = null;
        List<MOD_metodoFamilia> listaMetodoCulto = null;
        List<MOD_metodoFamilia> listaMetodoOficial = null;

        BLL_instrumento objBLL_Instr = null;
        List<MOD_instrumento> listaInstrumento = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        #endregion

        #region eventos do formulario

        private void frmMetodoInstr_Load(object sender, EventArgs e)
        {
            try
            {
                verPermInstr(gridMetodoInstr);
                //Define as imagens dos registros no grid
                definirImagens(gridMetodoInstr);

                //Define as imagens nos Pictures
                pctRjm.Image = imgMetodo.Images[0];
                pctMeiaHora.Image = imgMetodo.Images[1];
                pctCulto.Image = imgMetodo.Images[2];
                pctOficial.Image = imgMetodo.Images[3];
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
        private void frmMetodoInstr_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult sair;
                sair = MessageBox.Show(modulos.msgSair, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
        private void tabMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabMetodo.SelectedTab.Name.Equals("tabRjm"))
                {
                    carregaMetodosRjm();
                }
                else if (tabMetodo.SelectedTab.Name.Equals("tabMeiaHora"))
                {
                    carregaMetodosMeiaHora();
                }
                else if (tabMetodo.SelectedTab.Name.Equals("tabCulto"))
                {
                    carregaMetodosCulto();
                }
                else if (tabMetodo.SelectedTab.Name.Equals("tabOficial"))
                {
                    carregaMetodosOficial();
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

        private void gridInstrumento_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridInstrumento != null || gridInstrumento.Rows.Count > 0)
                {
                    //grava o valor do serviço selecionado
                    CodInstr = gridInstrumento["CodInstrumento", gridInstrumento.CurrentRow.Index].Value.ToString();
                    DescInstr = gridInstrumento["DescInstrumento", gridInstrumento.CurrentRow.Index].Value.ToString();
                    CodFamilia = gridInstrumento["CodFamilia", gridInstrumento.CurrentRow.Index].Value.ToString();
                    ///Carrega os valores de tabela dos serviços
                    carregaMetodoInstr(CodInstr);
                }
                else
                {
                    gridInstrumento.DataSource = null;
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
        private void gridMetodoInstr_SelectionChanged(object sender, EventArgs e)
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

        private void gridMetodoInstr_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermInstr(gridMetodoInstr);
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
        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparMetRjm();
                carregaMetodosRjm();
                enabledForm();
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();

                gridInstrumento.SelectionChanged -= new EventHandler(gridInstrumento_SelectionChanged);

                IndiceMet = gridMetodoInstr.CurrentRow.Index;
                enabledForm();
                preencheMetodoInstr(IndiceMet);
                CodMetInstr = gridMetodoInstr["CodMetodoInstr", IndiceMet].Value.ToString();

                gridInstrumento.Enabled = false;
                gridMetodoInstr.Enabled = false;

                gridInstrumento.SelectionChanged += new EventHandler(gridInstrumento_SelectionChanged);
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
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    gridMetodoInstr.SelectionChanged -= new EventHandler(gridMetodoInstr_SelectionChanged);

                    IndiceMet = gridMetodoInstr.CurrentRow.Index;
                    CodMetInstr = gridMetodoInstr["CodMetodoInstr", IndiceMet].Value.ToString();
                    DescMet = gridMetodoInstr["DescMetodo", IndiceMet].Value.ToString();
                    DescInstr = gridMetodoInstr["DescInstrumento", IndiceMet].Value.ToString();

                    deleteMetodo(IndiceMet);
                    carregaMetodoInstr(CodInstr);

                    gridMetodoInstr.SelectionChanged += new EventHandler(gridMetodoInstr_SelectionChanged);
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

        #region Aba Reuniao de Jovens

        private void cboMetodoRjm_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboMetodoRjm_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMetodoRjm.SelectedValue != null)
                {
                    foreach (MOD_metodoFamilia linha in listaMetodoRjm)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodMetodo.Contains(cboMetodoRjm.SelectedValue.ToString()))
                        {
                            txtTipoRjm.Text = linha.Tipo;
                            txtTipoEscolhaRjm.Text = linha.TipoEscolha;
                            txtPaginaFaseRjm.Text = linha.PaginaFase;

                            ///Verifica se o método é por fase ou página
                            if (txtPaginaFaseRjm.Text.Equals("Fase"))
                            {
                                lbFaseRjm.Enabled = true;
                                txtFaseInicioRjm.Value = 1;
                                txtFaseInicioRjm.Enabled = true;
                                txtFaseFimRjm.Value = 1;
                                txtFaseFimRjm.Enabled = true;
                                lbPagRjm.Enabled = true;
                                txtPagInicioRjm.Value = 0;
                                txtPagInicioRjm.Enabled = true;
                                txtPagFimRjm.Value = 0;
                                txtPagFimRjm.Enabled = true;
                                lbLicaoRjm.Enabled = true;
                                txtLicaoInicioRjm.Value = 0;
                                txtLicaoInicioRjm.Enabled = true;
                                txtLicaoFimRjm.Value = 0;
                                txtLicaoFimRjm.Enabled = true;
                            }
                            else if (txtPaginaFaseRjm.Text.Equals("Página"))
                            {
                                lbFaseRjm.Enabled = false;
                                txtFaseInicioRjm.Value = 0;
                                txtFaseInicioRjm.Enabled = false;
                                txtFaseFimRjm.Value = 0;
                                txtFaseFimRjm.Enabled = false;
                                lbPagRjm.Enabled = true;
                                txtPagInicioRjm.Value = 0;
                                txtPagInicioRjm.Enabled = true;
                                txtPagFimRjm.Value = 0;
                                txtPagFimRjm.Enabled = true;
                                lbLicaoRjm.Enabled = true;
                                txtLicaoInicioRjm.Value = 0;
                                txtLicaoInicioRjm.Enabled = true;
                                txtLicaoFimRjm.Value = 0;
                                txtLicaoFimRjm.Enabled = true;
                            }
                            else
                            {
                                lbFaseRjm.Enabled = false;
                                txtFaseInicioRjm.Value = 0;
                                txtFaseInicioRjm.Enabled = false;
                                txtFaseFimRjm.Value = 0;
                                txtFaseFimRjm.Enabled = false;
                                lbPagRjm.Enabled = false;
                                txtPagInicioRjm.Value = 0;
                                txtPagInicioRjm.Enabled = false;
                                txtPagFimRjm.Value = 0;
                                txtPagFimRjm.Enabled = false;
                                lbLicaoRjm.Enabled = true;
                                txtLicaoInicioRjm.Value = 0;
                                txtLicaoInicioRjm.Enabled = true;
                                txtLicaoFimRjm.Value = 0;
                                txtLicaoFimRjm.Enabled = true;
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
        private void btnSalvarRjm_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarMetRjm();
                //desabilita os controles
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
                apoio.FecharAguardeGravar();
            }
        }
        private void btnCancelarRjm_Click(object sender, EventArgs e)
        {
            try
            {
                limparMetRjm();
                //desabilita os controles
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

        #endregion

        #region Aba Meia Hora

        private void cboMetodoMeia_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboMetodoMeia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMetodoMeia.SelectedValue != null)
                {
                    foreach (MOD_metodoFamilia linha in listaMetodoMeiaHora)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodMetodo.Contains(cboMetodoMeia.SelectedValue.ToString()))
                        {
                            txtTipoMeia.Text = linha.Tipo;
                            txtTipoEscolhaMeia.Text = linha.TipoEscolha;
                            txtPaginaFaseMeia.Text = linha.PaginaFase;

                            ///Verifica se o método é por fase ou página
                            if (txtPaginaFaseMeia.Text.Equals("Fase"))
                            {
                                lbFaseMeia.Enabled = true;
                                txtFaseInicioMeia.Value = 1;
                                txtFaseInicioMeia.Enabled = true;
                                txtFaseFimMeia.Value = 1;
                                txtFaseFimMeia.Enabled = true;
                                lbPagMeia.Enabled = true;
                                txtPagInicioMeia.Value = 0;
                                txtPagInicioMeia.Enabled = true;
                                txtPagFimMeia.Value = 0;
                                txtPagFimMeia.Enabled = true;
                                lbLicaoMeia.Enabled = true;
                                txtLicaoInicioMeia.Value = 0;
                                txtLicaoInicioMeia.Enabled = true;
                                txtLicaoFimMeia.Value = 0;
                                txtLicaoFimMeia.Enabled = true;
                            }
                            else if (txtPaginaFaseMeia.Text.Equals("Página"))
                            {
                                lbFaseMeia.Enabled = false;
                                txtFaseInicioMeia.Value = 0;
                                txtFaseInicioMeia.Enabled = false;
                                txtFaseFimMeia.Value = 0;
                                txtFaseFimMeia.Enabled = false;
                                lbPagMeia.Enabled = true;
                                txtPagInicioMeia.Value = 0;
                                txtPagInicioMeia.Enabled = true;
                                txtPagFimMeia.Value = 0;
                                txtPagFimMeia.Enabled = true;
                                lbLicaoMeia.Enabled = true;
                                txtLicaoInicioMeia.Value = 0;
                                txtLicaoInicioMeia.Enabled = true;
                                txtLicaoFimMeia.Value = 0;
                                txtLicaoFimMeia.Enabled = true;
                            }
                            else
                            {
                                lbFaseMeia.Enabled = false;
                                txtFaseInicioMeia.Value = 0;
                                txtFaseInicioMeia.Enabled = false;
                                txtFaseFimMeia.Value = 0;
                                txtFaseFimMeia.Enabled = false;
                                lbPagMeia.Enabled = false;
                                txtPagInicioMeia.Value = 0;
                                txtPagInicioMeia.Enabled = false;
                                txtPagFimMeia.Value = 0;
                                txtPagFimMeia.Enabled = false;
                                lbLicaoMeia.Enabled = true;
                                txtLicaoInicioMeia.Value = 0;
                                txtLicaoInicioMeia.Enabled = true;
                                txtLicaoFimMeia.Value = 0;
                                txtLicaoFimMeia.Enabled = true;
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
        private void btnSalvarMeia_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarMetMeiaHora();
                //desabilita os controles
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
                apoio.FecharAguardeGravar();
            }
        }
        private void btnCancelarMeia_Click(object sender, EventArgs e)
        {
            try
            {
                limparMetMeiaHora();
                //desabilita os controles
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

        #endregion

        #region Aba Culto Oficial

        private void cboMetodoCulto_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboMetodoCulto_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMetodoCulto.SelectedValue != null)
                {
                    foreach (MOD_metodoFamilia linha in listaMetodoCulto)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodMetodo.Contains(cboMetodoCulto.SelectedValue.ToString()))
                        {
                            txtTipoCulto.Text = linha.Tipo;
                            txtTipoEscolhaCulto.Text = linha.TipoEscolha;
                            txtPaginaFaseCulto.Text = linha.PaginaFase;

                            ///Verifica se o método é por fase ou página
                            if (txtPaginaFaseCulto.Text.Equals("Fase"))
                            {
                                lbFaseCulto.Enabled = true;
                                txtFaseInicioCulto.Value = 1;
                                txtFaseInicioCulto.Enabled = true;
                                txtFaseFimCulto.Value = 1;
                                txtFaseFimCulto.Enabled = true;
                                lbPagCulto.Enabled = true;
                                txtPagInicioCulto.Value = 0;
                                txtPagInicioCulto.Enabled = true;
                                txtPagFimCulto.Value = 0;
                                txtPagFimCulto.Enabled = true;
                                lbLicaoCulto.Enabled = true;
                                txtLicaoInicioCulto.Value = 0;
                                txtLicaoInicioCulto.Enabled = true;
                                txtLicaoFimCulto.Value = 0;
                                txtLicaoFimCulto.Enabled = true;
                            }
                            else if (txtPaginaFaseCulto.Text.Equals("Página"))
                            {
                                lbFaseCulto.Enabled = false;
                                txtFaseInicioCulto.Value = 0;
                                txtFaseInicioCulto.Enabled = false;
                                txtFaseFimCulto.Value = 0;
                                txtFaseFimCulto.Enabled = false;
                                lbPagCulto.Enabled = true;
                                txtPagInicioCulto.Value = 0;
                                txtPagInicioCulto.Enabled = true;
                                txtPagFimCulto.Value = 0;
                                txtPagFimCulto.Enabled = true;
                                lbLicaoCulto.Enabled = true;
                                txtLicaoInicioCulto.Value = 0;
                                txtLicaoInicioCulto.Enabled = true;
                                txtLicaoFimCulto.Value = 0;
                                txtLicaoFimCulto.Enabled = true;
                            }
                            else
                            {
                                lbFaseCulto.Enabled = false;
                                txtFaseInicioCulto.Value = 0;
                                txtFaseInicioCulto.Enabled = false;
                                txtFaseFimCulto.Value = 0;
                                txtFaseFimCulto.Enabled = false;
                                lbPagCulto.Enabled = false;
                                txtPagInicioCulto.Value = 0;
                                txtPagInicioCulto.Enabled = false;
                                txtPagFimCulto.Value = 0;
                                txtPagFimCulto.Enabled = false;
                                lbLicaoCulto.Enabled = true;
                                txtLicaoInicioCulto.Value = 0;
                                txtLicaoInicioCulto.Enabled = true;
                                txtLicaoFimCulto.Value = 0;
                                txtLicaoFimCulto.Enabled = true;
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
        private void btnSalvarCulto_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarMetCulto();
                //desabilita os controles
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
                apoio.FecharAguardeGravar();
            }
        }
        private void btnCancelarCulto_Click(object sender, EventArgs e)
        {
            try
            {
                limparMetCulto();
                //desabilita os controles
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

        #endregion

        #region Aba Oficialização

        private void cboMetodoOficial_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboMetodoOficial_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cboMetodoOficial.SelectedValue != null)
                {
                    foreach (MOD_metodoFamilia linha in listaMetodoOficial)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodMetodo.Contains(cboMetodoOficial.SelectedValue.ToString()))
                        {
                            txtTipoOficial.Text = linha.Tipo;
                            txtTipoEscolhaOficial.Text = linha.TipoEscolha;
                            txtPaginaFaseOficial.Text = linha.PaginaFase;

                            ///Verifica se o método é por fase ou página
                            if (txtPaginaFaseOficial.Text.Equals("Fase"))
                            {
                                lbFaseOficial.Enabled = true;
                                txtFaseInicioOficial.Value = 1;
                                txtFaseInicioOficial.Enabled = true;
                                txtFaseFimOficial.Value = 1;
                                txtFaseFimOficial.Enabled = true;
                                lbPagOficial.Enabled = true;
                                txtPagInicioOficial.Value = 0;
                                txtPagInicioOficial.Enabled = true;
                                txtPagFimOficial.Value = 0;
                                txtPagFimOficial.Enabled = true;
                                lbLicaoOficial.Enabled = true;
                                txtLicaoInicioOficial.Value = 0;
                                txtLicaoInicioOficial.Enabled = true;
                                txtLicaoFimOficial.Value = 0;
                                txtLicaoFimOficial.Enabled = true;
                            }
                            else if (txtPaginaFaseOficial.Text.Equals("Página"))
                            {
                                lbFaseOficial.Enabled = false;
                                txtFaseInicioOficial.Value = 1;
                                txtFaseInicioOficial.Enabled = false;
                                txtFaseFimOficial.Value = 1;
                                txtFaseFimOficial.Enabled = false;
                                lbPagOficial.Enabled = true;
                                txtPagInicioOficial.Value = 0;
                                txtPagInicioOficial.Enabled = true;
                                txtPagFimOficial.Value = 0;
                                txtPagFimOficial.Enabled = true;
                                lbLicaoOficial.Enabled = true;
                                txtLicaoInicioOficial.Value = 0;
                                txtLicaoInicioOficial.Enabled = true;
                                txtLicaoFimOficial.Value = 0;
                                txtLicaoFimOficial.Enabled = true;
                            }
                            else
                            {
                                lbFaseOficial.Enabled = false;
                                txtFaseInicioOficial.Value = 0;
                                txtFaseInicioOficial.Enabled = false;
                                txtFaseFimOficial.Value = 0;
                                txtFaseFimOficial.Enabled = false;
                                lbPagOficial.Enabled = false;
                                txtPagInicioOficial.Value = 0;
                                txtPagInicioOficial.Enabled = false;
                                txtPagFimOficial.Value = 0;
                                txtPagFimOficial.Enabled = false;
                                lbLicaoOficial.Enabled = true;
                                txtLicaoInicioOficial.Value = 0;
                                txtLicaoInicioOficial.Enabled = true;
                                txtLicaoFimOficial.Value = 0;
                                txtLicaoFimOficial.Enabled = true;
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
        private void btnSalvarOficial_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarMetOficial();
                //desabilita os controles
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
                apoio.FecharAguardeGravar();
            }
        }
        private void btnCancelarOficial_Click(object sender, EventArgs e)
        {
            try
            {
                limparMetOficial();
                //desabilita os controles
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
                gridInstrumento.Enabled = true;
                gpoMetodoInstr.Enabled = false;
                gridMetodoInstr.Enabled = true;
                verPermInstr(gridMetodoInstr);
                enabledLabelTab();
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
                gridInstrumento.Enabled = false;
                gridMetodoInstr.Enabled = false;
                gpoMetodoInstr.Enabled = true;
                btnEditar.Enabled = false;
                btnInserir.Enabled = false;
                btnExcluir.Enabled = false;

                tabRjm.Enabled = true;
                if (Convert.ToInt16(CodFamilia).Equals(4))
                {
                    tabMeiaHora.Enabled = true;
                }
                else
                {
                    tabMeiaHora.Enabled = false;
                }
                tabCulto.Enabled = true;
                tabOficial.Enabled = true;
                enabledLabelTab();
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
        /// Habilita ou desabilita os Labels do Tab Control
        /// </summary>
        private void enabledLabelTab()
        {
            if (tabRjm.Enabled.Equals(true))
            {
                lbRjm.Visible = false;
            }
            else
            {
                if (tabMetodo.SelectedTab.Name.Equals("tabRjm"))
                {
                    lbRjm.BackColor = Color.White;
                    lbRjm.Visible = true;
                }
                else
                {
                    lbRjm.BackColor = Color.Transparent;
                    lbRjm.Visible = true;
                }
            }

            if (tabMeiaHora.Enabled.Equals(true))
            {
                lbMeiaHora.Visible = false;
            }
            else
            {
                if (tabMetodo.SelectedTab.Name.Equals("tabMeiaHora"))
                {
                    lbMeiaHora.BackColor = Color.White;
                    lbMeiaHora.Visible = true;
                }
                else
                {
                    lbMeiaHora.BackColor = Color.Transparent;
                    lbMeiaHora.Visible = true;
                }
            }

            if (tabCulto.Enabled.Equals(true))
            {
                lbCulto.Visible = false;
            }
            else
            {
                if (tabMetodo.SelectedTab.Name.Equals("tabCulto"))
                {
                    lbCulto.BackColor = Color.White;
                    lbCulto.Visible = true;
                }
                else
                {
                    lbCulto.BackColor = Color.Transparent;
                    lbCulto.Visible = true;
                }
            }

            if (tabOficial.Enabled.Equals(true))
            {
                lbOficial.Visible = false;
            }
            else
            {
                if (tabMetodo.SelectedTab.Name.Equals("tabOficial"))
                {
                    lbOficial.BackColor = Color.White;
                    lbOficial.Visible = true;
                }
                else
                {
                    lbOficial.BackColor = Color.Transparent;
                    lbOficial.Visible = true;
                }
            }
        }

        /// <summary>
        /// Função que carrega os Instrumentos
        /// </summary>
        private void carregaInstrumento()
        {
            try
            {
                objBLL_Instr = new BLL_instrumento();
                listaInstrumento = objBLL_Instr.buscarDescricao(string.Empty);

                funcoes.gridInstrumentos(gridInstrumento, "MetodoInstr");
                ///vincula a lista ao DataSource do DataGriView
                gridInstrumento.DataSource = listaInstrumento;
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
        private void carregaMetodoInstr(string CodInstr)
        {
            try
            {

                objBLL = new BLL_metodoInstr();
                listaMetodoInstr = objBLL.buscarInstrumento(CodInstr);

                funcoes.gridMetodoInstr(gridMetodoInstr);
                ///vincula a lista ao DataSource do DataGriView
                gridMetodoInstr.DataSource = listaMetodoInstr;
                definirImagens(gridMetodoInstr);
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
        private void preencheMetodoInstr(int Indice)
        {
            try
            {
                gpoMetodoInstr.Enabled = true;
                if (listaMetodoInstr[Indice].AplicarEm.Equals("Reunião de Jovens"))
                {
                    tabRjm.Enabled = true;
                    tabMetodo.SelectTab("tabRjm");
                    tabMeiaHora.Enabled = false;
                    tabCulto.Enabled = false;
                    tabOficial.Enabled = false;

                    carregaMetodosRjm();
                    cboMetodoRjm.SelectedValue = listaMetodoInstr[Indice].CodMetodo;
                    lblCodMetInstr.Text = listaMetodoInstr[Indice].CodMetodoInstr;
                    txtTipoRjm.Text = listaMetodoInstr[Indice].Tipo;
                    txtTipoEscolhaRjm.Text = listaMetodoInstr[Indice].TipoEscolha;
                    txtPaginaFaseRjm.Text = listaMetodoInstr[Indice].PaginaFase;

                    ///Verifica se o método é por fase ou página
                    if (txtPaginaFaseRjm.Text.Equals("Fase"))
                    {
                        lbFaseRjm.Enabled = true;
                        txtFaseInicioRjm.Enabled = true;
                        txtFaseFimRjm.Enabled = true;
                        lbPagRjm.Enabled = true;
                        txtPagInicioRjm.Value = 0;
                        txtPagInicioRjm.Enabled = true;
                        txtPagFimRjm.Value = 0;
                        txtPagFimRjm.Enabled = true;
                        lbLicaoRjm.Enabled = true;
                        txtLicaoInicioRjm.Value = 0;
                        txtLicaoInicioRjm.Enabled = true;
                        txtLicaoFimRjm.Value = 0;
                        txtLicaoFimRjm.Enabled = true;
                        txtFaseInicioRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseInicio);
                        txtFaseFimRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseFim);
                        txtPagInicioRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else if (txtPaginaFaseRjm.Text.Equals("Página"))
                    {
                        lbFaseRjm.Enabled = false;
                        txtFaseInicioRjm.Value = 0;
                        txtFaseInicioRjm.Enabled = false;
                        txtFaseFimRjm.Value = 0;
                        txtFaseFimRjm.Enabled = false;
                        lbPagRjm.Enabled = true;
                        txtPagInicioRjm.Value = 0;
                        txtPagInicioRjm.Enabled = true;
                        txtPagFimRjm.Value = 0;
                        txtPagFimRjm.Enabled = true;
                        txtLicaoInicioRjm.Value = 0;
                        txtLicaoInicioRjm.Enabled = true;
                        txtLicaoFimRjm.Value = 0;
                        txtLicaoFimRjm.Enabled = true;
                        txtPagInicioRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else
                    {
                        lbFaseRjm.Enabled = false;
                        txtFaseInicioRjm.Value = 0;
                        txtFaseInicioRjm.Enabled = false;
                        txtFaseFimRjm.Value = 0;
                        txtFaseFimRjm.Enabled = false;
                        lbPagRjm.Enabled = false;
                        txtPagInicioRjm.Value = 0;
                        txtPagInicioRjm.Enabled = false;
                        txtPagFimRjm.Value = 0;
                        txtPagFimRjm.Enabled = false;
                        txtLicaoInicioRjm.Value = 0;
                        txtLicaoInicioRjm.Enabled = true;
                        txtLicaoFimRjm.Value = 0;
                        txtLicaoFimRjm.Enabled = true;
                        txtLicaoInicioRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimRjm.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                }
                else if (listaMetodoInstr[Indice].AplicarEm.Equals("Meia Hora"))
                {
                    tabMeiaHora.Enabled = true;
                    tabMetodo.SelectTab("tabMeiaHora");
                    tabRjm.Enabled = false;
                    tabCulto.Enabled = false;
                    tabOficial.Enabled = false;

                    carregaMetodosMeiaHora();
                    cboMetodoMeia.SelectedValue = listaMetodoInstr[Indice].CodMetodo;
                    lblCodMetInstr.Text = listaMetodoInstr[Indice].CodMetodoInstr;
                    txtTipoMeia.Text = listaMetodoInstr[Indice].Tipo;
                    txtTipoEscolhaMeia.Text = listaMetodoInstr[Indice].TipoEscolha;
                    txtPaginaFaseMeia.Text = listaMetodoInstr[Indice].PaginaFase;

                    ///Verifica se o método é por fase ou página
                    if (txtPaginaFaseMeia.Text.Equals("Fase"))
                    {
                        lbFaseMeia.Enabled = true;
                        txtFaseInicioMeia.Value = 0;
                        txtFaseInicioMeia.Enabled = true;
                        txtFaseFimMeia.Value = 0;
                        txtFaseFimMeia.Enabled = true;
                        lbPagMeia.Enabled = true;
                        txtPagInicioMeia.Value = 0;
                        txtPagInicioMeia.Enabled = true;
                        txtPagFimMeia.Value = 0;
                        txtPagFimMeia.Enabled = true;
                        txtLicaoInicioMeia.Value = 0;
                        txtLicaoInicioMeia.Enabled = true;
                        txtLicaoFimMeia.Value = 0;
                        txtLicaoFimMeia.Enabled = true;
                        txtFaseInicioMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseInicio);
                        txtFaseFimMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseFim);
                        txtPagInicioMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else if (txtPaginaFaseMeia.Text.Equals("Página"))
                    {
                        lbFaseMeia.Enabled = false;
                        txtFaseInicioMeia.Value = 0;
                        txtFaseInicioMeia.Enabled = false;
                        txtFaseFimMeia.Value = 0;
                        txtFaseFimMeia.Enabled = false;
                        lbPagMeia.Enabled = true;
                        txtPagInicioMeia.Value = 0;
                        txtPagInicioMeia.Enabled = true;
                        txtPagFimMeia.Value = 0;
                        txtPagFimMeia.Enabled = true;
                        txtLicaoInicioMeia.Value = 0;
                        txtLicaoInicioMeia.Enabled = true;
                        txtLicaoFimMeia.Value = 0;
                        txtLicaoFimMeia.Enabled = true;
                        txtPagInicioMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else
                    {
                        lbFaseMeia.Enabled = false;
                        txtFaseInicioMeia.Value = 0;
                        txtFaseInicioMeia.Enabled = false;
                        txtFaseFimMeia.Value = 0;
                        txtFaseFimMeia.Enabled = false;
                        txtPagInicioMeia.Value = 0;
                        txtPagInicioMeia.Enabled = false;
                        txtPagFimMeia.Value = 0;
                        txtPagFimRjm.Enabled = false;
                        txtLicaoInicioMeia.Value = 0;
                        txtLicaoInicioMeia.Enabled = true;
                        txtLicaoFimMeia.Value = 0;
                        txtLicaoFimMeia.Enabled = true;
                        txtLicaoInicioMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimMeia.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                }
                else if (listaMetodoInstr[Indice].AplicarEm.Equals("Culto Oficial"))
                {
                    tabCulto.Enabled = true;
                    tabMetodo.SelectTab("tabCulto");
                    tabRjm.Enabled = false;
                    tabMeiaHora.Enabled = false;
                    tabOficial.Enabled = false;

                    carregaMetodosCulto();
                    cboMetodoCulto.SelectedValue = listaMetodoInstr[Indice].CodMetodo;
                    lblCodMetInstr.Text = listaMetodoInstr[Indice].CodMetodoInstr;
                    txtTipoCulto.Text = listaMetodoInstr[Indice].Tipo;
                    txtTipoEscolhaCulto.Text = listaMetodoInstr[Indice].TipoEscolha;
                    txtPaginaFaseCulto.Text = listaMetodoInstr[Indice].PaginaFase;

                    ///Verifica se o método é por fase ou página
                    if (txtPaginaFaseCulto.Text.Equals("Fase"))
                    {
                        lbFaseCulto.Enabled = true;
                        txtFaseInicioCulto.Value = 0;
                        txtFaseInicioCulto.Enabled = true;
                        txtFaseFimCulto.Value = 0;
                        txtFaseFimCulto.Enabled = true;
                        lbPagCulto.Enabled = true;
                        txtPagInicioCulto.Value = 0;
                        txtPagInicioCulto.Enabled = true;
                        txtPagFimCulto.Value = 0;
                        txtPagFimCulto.Enabled = true;
                        txtLicaoInicioCulto.Value = 0;
                        txtLicaoInicioCulto.Enabled = true;
                        txtLicaoFimCulto.Value = 0;
                        txtLicaoFimCulto.Enabled = true;
                        txtFaseInicioCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseInicio);
                        txtFaseFimCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseFim);
                        txtPagInicioCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else if (txtPaginaFaseCulto.Text.Equals("Página"))
                    {
                        lbFaseCulto.Enabled = false;
                        txtFaseInicioCulto.Value = 0;
                        txtFaseInicioCulto.Enabled = false;
                        txtFaseFimCulto.Value = 0;
                        txtFaseFimCulto.Enabled = false;
                        lbPagCulto.Enabled = true;
                        txtPagInicioCulto.Value = 0;
                        txtPagInicioCulto.Enabled = true;
                        txtPagFimCulto.Value = 0;
                        txtPagFimCulto.Enabled = true;
                        txtLicaoInicioCulto.Value = 0;
                        txtLicaoInicioCulto.Enabled = true;
                        txtLicaoFimCulto.Value = 0;
                        txtLicaoFimCulto.Enabled = true;
                        txtPagInicioCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else
                    {
                        lbFaseCulto.Enabled = false;
                        txtFaseInicioCulto.Value = 0;
                        txtFaseInicioCulto.Enabled = false;
                        txtFaseFimCulto.Value = 0;
                        txtFaseFimCulto.Enabled = false;
                        lbPagCulto.Enabled = false;
                        txtPagInicioCulto.Value = 0;
                        txtPagInicioCulto.Enabled = false;
                        txtPagFimCulto.Value = 0;
                        txtPagFimCulto.Enabled = false;
                        txtLicaoInicioCulto.Value = 0;
                        txtLicaoInicioCulto.Enabled = true;
                        txtLicaoFimCulto.Value = 0;
                        txtLicaoFimCulto.Enabled = true;
                        txtLicaoInicioCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimCulto.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }

                }
                else if (listaMetodoInstr[Indice].AplicarEm.Equals("Oficialização"))
                {
                    tabOficial.Enabled = true;
                    tabMetodo.SelectTab("tabOficial");
                    tabRjm.Enabled = false;
                    tabMeiaHora.Enabled = false;
                    tabCulto.Enabled = false;

                    carregaMetodosOficial();
                    cboMetodoOficial.SelectedValue = listaMetodoInstr[Indice].CodMetodo;
                    lblCodMetInstr.Text = listaMetodoInstr[Indice].CodMetodoInstr;
                    txtTipoOficial.Text = listaMetodoInstr[Indice].Tipo;
                    txtTipoEscolhaOficial.Text = listaMetodoInstr[Indice].TipoEscolha;
                    txtPaginaFaseOficial.Text = listaMetodoInstr[Indice].PaginaFase;

                    ///Verifica se o método é por fase ou página
                    if (txtPaginaFaseOficial.Text.Equals("Fase"))
                    {
                        lbFaseOficial.Enabled = true;
                        txtFaseInicioOficial.Value = 0;
                        txtFaseInicioOficial.Enabled = true;
                        txtFaseFimOficial.Value = 0;
                        txtFaseFimOficial.Enabled = true;
                        lbPagOficial.Enabled = true;
                        txtPagInicioOficial.Value = 0;
                        txtPagInicioOficial.Enabled = true;
                        txtPagFimOficial.Value = 0;
                        txtPagFimOficial.Enabled = true;
                        txtLicaoInicioOficial.Value = 0;
                        txtLicaoInicioOficial.Enabled = true;
                        txtLicaoFimOficial.Value = 0;
                        txtLicaoFimOficial.Enabled = true;
                        txtFaseInicioOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseInicio);
                        txtFaseFimOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].FaseFim);
                        txtPagInicioOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else if (txtPaginaFaseOficial.Text.Equals("Página"))
                    {
                        lbFaseOficial.Enabled = false;
                        txtFaseInicioOficial.Value = 0;
                        txtFaseInicioOficial.Enabled = false;
                        txtFaseFimOficial.Value = 0;
                        txtFaseFimOficial.Enabled = false;
                        lbPagOficial.Enabled = true;
                        txtPagInicioOficial.Value = 0;
                        txtPagInicioOficial.Enabled = true;
                        txtPagFimOficial.Value = 0;
                        txtPagFimOficial.Enabled = true;
                        txtLicaoInicioOficial.Value = 0;
                        txtLicaoInicioOficial.Enabled = true;
                        txtLicaoFimOficial.Value = 0;
                        txtLicaoFimOficial.Enabled = true;
                        txtPagInicioOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaInicio);
                        txtPagFimOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].PaginaFim);
                        txtLicaoInicioOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                    else
                    {
                        lbFaseOficial.Enabled = false;
                        txtFaseInicioOficial.Value = 0;
                        txtFaseInicioOficial.Enabled = false;
                        txtFaseFimOficial.Value = 0;
                        txtFaseFimOficial.Enabled = false;
                        lbPagOficial.Enabled = false;
                        txtPagInicioOficial.Value = 0;
                        txtPagInicioOficial.Enabled = false;
                        txtPagFimOficial.Value = 0;
                        txtPagFimOficial.Enabled = false;
                        txtLicaoInicioOficial.Value = 0;
                        txtLicaoInicioOficial.Enabled = true;
                        txtLicaoFimOficial.Value = 0;
                        txtLicaoFimOficial.Enabled = true;
                        txtLicaoInicioOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoInicio);
                        txtLicaoFimOficial.Value = Convert.ToDecimal(listaMetodoInstr[Indice].LicaoFim);
                    }
                }
                enabledLabelTab();
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

        #region Metodos RJM

        /// <summary>
        /// Função que valida os campos Reunião de Jovens
        /// </summary>
        private bool ValidarControlesRjm()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (cboMetodoRjm.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Reunião de Jovens > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtPaginaFaseRjm.Text.Equals("Fase"))
                {
                    if (txtFaseFimRjm.Value < txtFaseInicioRjm.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Reunião de Jovens > Fase Final não pode inferior a Fase inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtFaseFimRjm.Value.Equals(txtFaseInicioRjm.Value))
                    {
                        if (txtPagFimRjm.Value < txtPagInicioRjm.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Reunião de Jovens > Página Final não pode inferior a Página inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                    if (txtPagFimRjm.Value.Equals(txtPagInicioRjm.Value))
                    {
                        if (txtLicaoFimRjm.Value < txtLicaoInicioRjm.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Reunião de Jovens > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else if (txtPaginaFaseRjm.Text.Equals("Página"))
                {
                    if (txtPagFimRjm.Value < txtPagInicioRjm.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Reunião de Jovens > Página Final não pode inferior a Página inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtPagFimRjm.Value.Equals(txtPagInicioRjm.Value))
                    {
                        if (txtLicaoFimRjm.Value < txtLicaoInicioRjm.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Reunião de Jovens > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else
                {
                    if (txtLicaoFimRjm.Value < txtLicaoInicioRjm.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Reunião de Jovens > Lição Final não pode inferior a Lição inicial.";
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
        /// Função que preenche o ComboBox Metodos RJM
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodosRjm()
        {
            try
            {
                objBLL_Met = new BLL_metodos();
                listaMetodoRjm = new List<MOD_metodoFamilia>();

                listaMetodoRjm = objBLL_Met.buscarMetFamilia(CodFamilia, "Sim");
                cboMetodoRjm.DataSource = listaMetodoRjm;
                cboMetodoRjm.ValueMember = "CodMetodo";
                cboMetodoRjm.DisplayMember = "DescMetodo";
                cboMetodoRjm.SelectedIndex = (-1);
                txtTipoEscolhaRjm.Text = string.Empty;
                txtPaginaFaseRjm.Text = string.Empty;
                txtTipoRjm.Text = string.Empty;
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
        private MOD_metodoInstr criarTabelaRjm()
        {
            try
            {
                objEnt = new MOD_metodoInstr();
                objEnt.CodMetodoInstr = lblCodMetInstr.Text;
                objEnt.CodInstrumento = CodInstr;
                objEnt.DescInstrumento = DescInstr;
                objEnt.CodMetodo = Convert.ToString(cboMetodoRjm.SelectedValue);
                objEnt.DescMetodo = cboMetodoRjm.Text;
                objEnt.AplicarEm = "Reunião de Jovens";
                objEnt.Tipo = txtTipoRjm.Text;
                objEnt.TipoEscolha = txtTipoEscolhaRjm.Text;
                objEnt.PaginaFase = txtPaginaFaseRjm.Text;
                objEnt.FaseInicio = Convert.ToString(txtFaseInicioRjm.Value);
                objEnt.PaginaInicio = Convert.ToString(txtPagInicioRjm.Value);
                objEnt.LicaoInicio = Convert.ToString(txtLicaoInicioRjm.Value);
                objEnt.FaseFim = Convert.ToString(txtFaseFimRjm.Value);
                objEnt.PaginaFim = Convert.ToString(txtPagFimRjm.Value);
                objEnt.LicaoFim = Convert.ToString(txtLicaoFimRjm.Value);
                objEnt.Inicio = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseInicio + " - Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : "Lição: " + objEnt.LicaoInicio;
                objEnt.Fim = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseFim + " - Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : "Lição: " + objEnt.LicaoFim;

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
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarMetRjm()
        {
            try
            {
                if (ValidarControlesRjm().Equals(true))
                {
                    objBLL = new BLL_metodoInstr();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL.salvar(criarTabelaRjm());

                    //Carrega os instrumentos
                    carregaMetodoInstr(CodInstr);
                    //Limpa os controle e desabilita
                    limparMetRjm();
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
        private void limparMetRjm()
        {
            try
            {
                lblCodMetInstr.Text = string.Empty;
                cboMetodoRjm.SelectedValue = (-1);
                txtTipoRjm.Text = string.Empty;
                txtTipoEscolhaRjm.Text = string.Empty;
                txtPaginaFaseRjm.Text = string.Empty;
                txtFaseInicioRjm.Value = 0;
                txtPagInicioRjm.Value = 0;
                txtLicaoInicioRjm.Value = 0;
                txtFaseFimRjm.Value = 0;
                txtPagFimRjm.Value = 0;
                txtLicaoFimRjm.Value = 0;
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

        #region Metodos Meia Hora

        /// <summary>
        /// Função que valida os campos Meia Hora
        /// </summary>
        private bool ValidarControlesMeiaHora()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (cboMetodoMeia.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Meia Hora > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtPaginaFaseMeia.Text.Equals("Fase"))
                {
                    if (txtFaseFimMeia.Value < txtFaseInicioMeia.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Meia Hora > Fase Final não pode inferior a Fase inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtFaseFimMeia.Value.Equals(txtFaseInicioMeia.Value))
                    {
                        if (txtPagFimMeia.Value < txtPagInicioMeia.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Meia Hora > Página Final não pode inferior a Página inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                    if (txtPagFimMeia.Value.Equals(txtPagInicioMeia.Value))
                    {
                        if (txtLicaoFimMeia.Value < txtLicaoInicioMeia.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Meia Hora > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else if (txtPaginaFaseMeia.Text.Equals("Página"))
                {
                    if (txtPagFimMeia.Value < txtPagInicioMeia.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Meia Hora > Página Final não pode inferior a Página inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtPagFimMeia.Value.Equals(txtPagInicioMeia.Value))
                    {
                        if (txtLicaoFimMeia.Value < txtLicaoInicioMeia.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Meia Hora > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else
                {
                    if (txtLicaoFimMeia.Value < txtLicaoInicioMeia.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Meia Hora > Lição Final não pode inferior a Lição inicial.";
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
        /// Função que preenche o ComboBox Metodos Meia Hora
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodosMeiaHora()
        {
            try
            {
                objBLL_Met = new BLL_metodos();
                listaMetodoMeiaHora = new List<MOD_metodoFamilia>();

                listaMetodoMeiaHora = objBLL_Met.buscarMetFamilia(CodFamilia, "Sim");
                cboMetodoMeia.DataSource = listaMetodoMeiaHora;
                cboMetodoMeia.ValueMember = "CodMetodo";
                cboMetodoMeia.DisplayMember = "DescMetodo";
                cboMetodoMeia.SelectedIndex = (-1);
                txtTipoEscolhaMeia.Text = string.Empty;
                txtPaginaFaseMeia.Text = string.Empty;
                txtTipoMeia.Text = string.Empty;
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
        private MOD_metodoInstr criarTabelaMeiaHora()
        {
            try
            {
                objEnt = new MOD_metodoInstr();
                objEnt.CodMetodoInstr = lblCodMetInstr.Text;
                objEnt.CodInstrumento = CodInstr;
                objEnt.DescInstrumento = DescInstr;
                objEnt.CodMetodo = Convert.ToString(cboMetodoMeia.SelectedValue);
                objEnt.DescMetodo = cboMetodoMeia.Text;
                objEnt.AplicarEm = "Meia Hora";
                objEnt.Tipo = txtTipoMeia.Text;
                objEnt.TipoEscolha = txtTipoEscolhaMeia.Text;
                objEnt.PaginaFase = txtPaginaFaseMeia.Text;
                objEnt.FaseInicio = Convert.ToString(txtFaseInicioMeia.Value);
                objEnt.PaginaInicio = Convert.ToString(txtPagInicioMeia.Value);
                objEnt.LicaoInicio = Convert.ToString(txtLicaoInicioMeia.Value);
                objEnt.FaseFim = Convert.ToString(txtFaseFimMeia.Value);
                objEnt.PaginaFim = Convert.ToString(txtPagFimMeia.Value);
                objEnt.LicaoFim = Convert.ToString(txtLicaoFimMeia.Value);
                objEnt.Inicio = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseInicio + "Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : "Lição: " + objEnt.LicaoInicio;
                objEnt.Fim = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseFim + "Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : "Lição: " + objEnt.LicaoFim;

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
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarMetMeiaHora()
        {
            try
            {
                if (ValidarControlesMeiaHora().Equals(true))
                {
                    objBLL = new BLL_metodoInstr();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL.salvar(criarTabelaMeiaHora());

                    //Carrega os instrumentos
                    carregaMetodoInstr(CodInstr);

                    //Limpa os controle e desabilita
                    limparMetMeiaHora();
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
        private void limparMetMeiaHora()
        {
            try
            {
                lblCodMetInstr.Text = string.Empty;
                cboMetodoMeia.SelectedValue = (-1);
                txtTipoMeia.Text = string.Empty;
                txtTipoEscolhaMeia.Text = string.Empty;
                txtPaginaFaseMeia.Text = string.Empty;
                txtFaseInicioMeia.Value = 0;
                txtPagInicioMeia.Value = 0;
                txtLicaoInicioMeia.Value = 0;
                txtFaseFimMeia.Value = 0;
                txtPagFimMeia.Value = 0;
                txtLicaoFimMeia.Value = 0;
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

        #region Metodos Culto

        /// <summary>
        /// Função que valida os campos Culto Oficial
        /// </summary>
        private bool ValidarControlesCulto()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (cboMetodoCulto.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Culto Oficial > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtPaginaFaseCulto.Text.Equals("Fase"))
                {
                    if (txtFaseFimCulto.Value < txtFaseInicioCulto.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Culto Oficial > Fase Final não pode inferior a Fase inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtFaseFimCulto.Value.Equals(txtFaseInicioCulto.Value))
                    {
                        if (txtPagFimCulto.Value < txtPagInicioCulto.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Culto Oficial > Página Final não pode inferior a Página inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                    if (txtPagFimCulto.Value.Equals(txtPagInicioCulto.Value))
                    {
                        if (txtLicaoFimCulto.Value < txtLicaoInicioCulto.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Culto Oficial > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else if (txtPaginaFaseCulto.Text.Equals("Página"))
                {
                    if (txtPagFimCulto.Value < txtPagInicioCulto.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Culto Oficial > Página Final não pode inferior a Página inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtPagFimCulto.Value.Equals(txtPagInicioCulto.Value))
                    {
                        if (txtLicaoFimCulto.Value < txtLicaoInicioCulto.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Culto Oficial > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else
                {
                    if (txtLicaoFimCulto.Value < txtLicaoInicioCulto.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Culto Oficial > Lição Final não pode inferior a Lição inicial.";
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
        /// Função que preenche o ComboBox Metodos Culto Oticial
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodosCulto()
        {
            try
            {
                objBLL_Met = new BLL_metodos();
                listaMetodoCulto = new List<MOD_metodoFamilia>();

                listaMetodoCulto = objBLL_Met.buscarMetFamilia(CodFamilia, "Sim");
                cboMetodoCulto.DataSource = listaMetodoCulto;
                cboMetodoCulto.ValueMember = "CodMetodo";
                cboMetodoCulto.DisplayMember = "DescMetodo";
                cboMetodoCulto.SelectedIndex = (-1);
                txtTipoEscolhaCulto.Text = string.Empty;
                txtPaginaFaseCulto.Text = string.Empty;
                txtTipoCulto.Text = string.Empty;
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
        private MOD_metodoInstr criarTabelaCulto()
        {
            try
            {
                objEnt = new MOD_metodoInstr();
                objEnt.CodMetodoInstr = lblCodMetInstr.Text;
                objEnt.CodInstrumento = CodInstr;
                objEnt.DescInstrumento = DescInstr;
                objEnt.CodMetodo = Convert.ToString(cboMetodoCulto.SelectedValue);
                objEnt.DescMetodo = cboMetodoCulto.Text;
                objEnt.AplicarEm = "Culto Oficial";
                objEnt.Tipo = txtTipoCulto.Text;
                objEnt.TipoEscolha = txtTipoEscolhaCulto.Text;
                objEnt.PaginaFase = txtPaginaFaseCulto.Text;
                objEnt.FaseInicio = Convert.ToString(txtFaseInicioCulto.Value);
                objEnt.PaginaInicio = Convert.ToString(txtPagInicioCulto.Value);
                objEnt.LicaoInicio = Convert.ToString(txtLicaoInicioCulto.Value);
                objEnt.FaseFim = Convert.ToString(txtFaseFimCulto.Value);
                objEnt.PaginaFim = Convert.ToString(txtPagFimCulto.Value);
                objEnt.LicaoFim = Convert.ToString(txtLicaoFimCulto.Value);
                objEnt.Inicio = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseInicio + "Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : "Lição: " + objEnt.LicaoInicio;
                objEnt.Fim = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseFim + "Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : "Lição: " + objEnt.LicaoFim;

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
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarMetCulto()
        {
            try
            {
                if (ValidarControlesCulto().Equals(true))
                {
                    objBLL = new BLL_metodoInstr();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL.salvar(criarTabelaCulto());

                    //Carrega os instrumentos
                    carregaMetodoInstr(CodInstr);

                    //Limpa os controle e desabilita
                    limparMetCulto();
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
        private void limparMetCulto()
        {
            try
            {
                lblCodMetInstr.Text = string.Empty;
                cboMetodoCulto.SelectedValue = (-1);
                txtTipoCulto.Text = string.Empty;
                txtTipoEscolhaCulto.Text = string.Empty;
                txtPaginaFaseCulto.Text = string.Empty;
                txtFaseInicioCulto.Value = 0;
                txtPagInicioCulto.Value = 0;
                txtLicaoInicioCulto.Value = 0;
                txtFaseFimCulto.Value = 0;
                txtPagFimCulto.Value = 0;
                txtLicaoFimCulto.Value = 0;
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

        #region Metodos Oficialização

        /// <summary>
        /// Função que valida os campos Oficializacao
        /// </summary>
        private bool ValidarControlesOficial()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (cboMetodoOficial.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Oficialização > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtPaginaFaseOficial.Text.Equals("Fase"))
                {
                    if (txtFaseFimOficial.Value < txtFaseInicioOficial.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Oficialização > Fase Final não pode inferior a Fase inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtFaseFimOficial.Value.Equals(txtFaseInicioOficial.Value))
                    {
                        if (txtPagFimOficial.Value < txtPagInicioOficial.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Oficialização > Página Final não pode inferior a Página inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                    if (txtPagFimOficial.Value.Equals(txtPagInicioOficial.Value))
                    {
                        if (txtLicaoFimOficial.Value < txtLicaoInicioOficial.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Oficialização > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else if (txtPaginaFaseOficial.Text.Equals("Página"))
                {
                    if (txtPagFimOficial.Value < txtPagInicioOficial.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Oficialização > Página Final não pode inferior a Página inicial.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtPagFimOficial.Value.Equals(txtPagInicioOficial.Value))
                    {
                        if (txtLicaoFimOficial.Value < txtLicaoInicioOficial.Value)
                        {
                            blnValida = false;
                            objEnt_Erros = new MOD_erros();
                            objEnt_Erros.Texto = "Aba Oficialização > Lição Final não pode inferior a Lição inicial.";
                            objEnt_Erros.Grau = "Alto";
                            listaErros.Add(objEnt_Erros);
                        }
                    }
                }
                else
                {
                    if (txtLicaoFimOficial.Value < txtLicaoInicioOficial.Value)
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Oficialização > Lição Final não pode inferior a Lição inicial.";
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
        /// Função que preenche o ComboBox Metodos Oficialização
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodosOficial()
        {
            try
            {
                objBLL_Met = new BLL_metodos();
                listaMetodoOficial = new List<MOD_metodoFamilia>();

                listaMetodoOficial = objBLL_Met.buscarMetFamilia(CodFamilia, "Sim");
                cboMetodoOficial.DataSource = listaMetodoOficial;
                cboMetodoOficial.ValueMember = "CodMetodo";
                cboMetodoOficial.DisplayMember = "DescMetodo";
                cboMetodoOficial.SelectedIndex = (-1);
                txtTipoEscolhaOficial.Text = string.Empty;
                txtPaginaFaseOficial.Text = string.Empty;
                txtTipoOficial.Text = string.Empty;
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
        private MOD_metodoInstr criarTabelaOficial()
        {
            try
            {
                objEnt = new MOD_metodoInstr();
                objEnt.CodMetodoInstr = lblCodMetInstr.Text;
                objEnt.CodInstrumento = CodInstr;
                objEnt.DescInstrumento = DescInstr;
                objEnt.CodMetodo = Convert.ToString(cboMetodoOficial.SelectedValue);
                objEnt.DescMetodo = cboMetodoOficial.Text;
                objEnt.AplicarEm = "Oficialização";
                objEnt.Tipo = txtTipoOficial.Text;
                objEnt.TipoEscolha = txtTipoEscolhaOficial.Text;
                objEnt.PaginaFase = txtPaginaFaseOficial.Text;
                objEnt.FaseInicio = Convert.ToString(txtFaseInicioOficial.Value);
                objEnt.PaginaInicio = Convert.ToString(txtPagInicioOficial.Value);
                objEnt.LicaoInicio = Convert.ToString(txtLicaoInicioOficial.Value);
                objEnt.FaseFim = Convert.ToString(txtFaseFimOficial.Value);
                objEnt.PaginaFim = Convert.ToString(txtPagFimOficial.Value);
                objEnt.LicaoFim = Convert.ToString(txtLicaoFimOficial.Value);
                objEnt.Inicio = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseInicio + "Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaInicio + " - Lição: " + objEnt.LicaoInicio : "Lição: " + objEnt.LicaoInicio;
                objEnt.Fim = objEnt.PaginaFase.Equals("Fase") ? "Fase: " + objEnt.FaseFim + "Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : objEnt.PaginaFase.Equals("Página") ? "Pág.: " + objEnt.PaginaFim + " - Lição: " + objEnt.LicaoFim : "Lição: " + objEnt.LicaoFim;

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
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarMetOficial()
        {
            try
            {
                if (ValidarControlesOficial().Equals(true))
                {
                    objBLL = new BLL_metodoInstr();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL.salvar(criarTabelaOficial());

                    //Carrega os instrumentos
                    carregaMetodoInstr(CodInstr);

                    //Limpa os controle e desabilita
                    limparMetOficial();
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
        private void limparMetOficial()
        {
            try
            {
                lblCodMetInstr.Text = string.Empty;
                cboMetodoOficial.SelectedValue = (-1);
                txtTipoOficial.Text = string.Empty;
                txtTipoEscolhaOficial.Text = string.Empty;
                txtPaginaFaseOficial.Text = string.Empty;
                txtFaseInicioOficial.Value = 0;
                txtPagInicioOficial.Value = 0;
                txtLicaoInicioOficial.Value = 0;
                txtFaseFimOficial.Value = 0;
                txtPagFimOficial.Value = 0;
                txtLicaoFimOficial.Value = 0;
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
                    if (Convert.ToString(linha.Cells["AplicarEm"].Value).Contains("Meia Hora"))
                    {
                        linha.Cells[0].Value = imgMetodo.Images[1];
                    }
                    else if (Convert.ToString(linha.Cells["AplicarEm"].Value).Contains("Reunião de Jovens"))
                    {
                        linha.Cells[0].Value = imgMetodo.Images[0];
                    }
                    else if (Convert.ToString(linha.Cells["AplicarEm"].Value).Contains("Culto Oficial"))
                    {
                        linha.Cells[0].Value = imgMetodo.Images[2];
                    }
                    else if (Convert.ToString(linha.Cells["AplicarEm"].Value).Contains("Oficialização"))
                    {
                        linha.Cells[0].Value = imgMetodo.Images[3];
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
        /// Função que Deleta a linha selecionada no GridMetodoInstr
        /// </summary>
        private void deleteMetodo(int Indice)
        {
            try
            {
                MOD_metodoInstr ent = new MOD_metodoInstr();
                ent.CodMetodoInstr = CodMetInstr;
                ent.DescInstrumento = DescInstr;
                ent.DescMetodo = DescMet;

                objBLL = new BLL_metodoInstr();
                objBLL.excluir(ent);
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
        internal void verPermInstr(DataGridView dataGrid)
        {
            try
            {
                btnInserir.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoMetodoInstr.RotInsMetodoInstr);
                btnEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoMetodoInstr.RotEditMetodoInstr, dataGrid);
                btnExcluir.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoMetodoInstr.RotExcMetodoInstr, dataGrid);
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