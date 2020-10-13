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
    public partial class frmLicaoTeste : Form
    {
        public frmLicaoTeste(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;
                carregaLicaoPreTesteMts(string.Empty);
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

        string CodLicaoMts;
        string DescMts;
        string AplicaEmMts;

        string CodLicaoTeoria;
        string DescTeoria;
        string AplicaEmTeoria;

        int IndiceMts;
        int IndiceTeoria;

        clsException excp;
        List<MOD_acessos> listaAcesso = null;

        BLL_licaoTesteMts objBLL_licaoPreMts = null;
        MOD_licaoTesteMts objEnt_licaoTesteMts = null;
        List<MOD_licaoTesteMts> listaLicaoTesteMts = new List<MOD_licaoTesteMts>();

        BLL_licaoTesteTeoria objBLL_licaoTesteTeoria = null;
        MOD_licaoTesteTeoria objEnt_licaoTesteTeoria = null;
        List<MOD_licaoTesteTeoria> listaLicaoTesteTeoria = new List<MOD_licaoTesteTeoria>();

        BLL_metodos objBLL_Mts = null;
        List<MOD_metodos> listaMts = null;

        BLL_teoria objBLL_Teoria = null;
        List<MOD_teoria> listaTeoria = null;

        Form formulario;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        #endregion

        #region eventos do formulario

        private void frmLicaoTeste_Load(object sender, EventArgs e)
        {
            try
            {
                verPermMts(gridMts);

                pctRjm.Image = imgLicaoTeste.Images[0];
                pctMeiaHora.Image = imgLicaoTeste.Images[1];
                pctCulto.Image = imgLicaoTeste.Images[2];
                pctOficial.Image = imgLicaoTeste.Images[3];
                definirImagens(gridMts);
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
        private void frmLicaoTeste_FormClosing(object sender, FormClosingEventArgs e)
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
                if (tabTipo.SelectedTab.Name.Equals("tabMts"))
                {
                    carregaLicaoPreTesteMts(string.Empty);
                    verPermMts(gridMts);
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabTeoria"))
                {
                    carregaLicaoPreTesteTeoria(string.Empty);
                    verPermTeoria(gridTeoria);
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

        #region Aba MTS

        private void cboMtsMetodo_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void cboMtsMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboMtsMetodo.SelectedValue != null)
                {
                    foreach (MOD_metodos linha in listaMts)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodMetodo.Equals(Convert.ToString(cboMtsMetodo.SelectedValue)))
                        {
                            lblTipoMts.Text = Convert.ToString(linha.Tipo);

                            if (lblTipoMts.Text.Equals("Solfejo"))
                            {
                                optMtsSolfejo.Checked = true;
                            }
                            else if (lblTipoMts.Text.Equals("Ritmo"))
                            {
                                optMtsRitmo.Checked = true;
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
        private void btnMtsSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarMts();
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
        private void btnMtsCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limparMts();
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
        private void gridMts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnMtsEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde("Carregando informações...");

                    IndiceMts = gridMts.CurrentRow.Index;
                    enabledForm();
                    preencheMts(IndiceMts);
                    CodLicaoMts = gridMts["CodLicaoMts", IndiceMts].Value.ToString();
                    gpoMts.Enabled = true;
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

        private void btnMtsInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparMts();
                carregaMetodosMts();
                enabledForm();
                gpoMts.Enabled = true;
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
        private void btnMtsEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando informações...");

                IndiceMts = gridMts.CurrentRow.Index;
                gpoMts.Enabled = true;
                enabledForm();
                preencheMts(IndiceMts);
                CodLicaoMts = gridMts["CodLicaoMts", IndiceMts].Value.ToString();
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
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    IndiceMts = gridMts.CurrentRow.Index;
                    CodLicaoMts = gridMts["CodLicaoMts", IndiceMts].Value.ToString();
                    DescMts = gridMts["DescMetodo", IndiceMts].Value.ToString();
                    AplicaEmMts = gridMts["AplicaEm", IndiceMts].Value.ToString();

                    deleteMts(IndiceMts);
                    carregaLicaoPreTesteMts(string.Empty);
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

        private void optMtsRjm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMtsRjm.Checked.Equals(true))
                {
                    lblMtsAplicarEm.Text = "Reunião de Jovens";
                }
                else
                {
                    lblMtsAplicarEm.Text = string.Empty;
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
        private void optMtsCulto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMtsCulto.Checked.Equals(true))
                {
                    lblMtsAplicarEm.Text = "Culto Oficial";
                }
                else
                {
                    lblMtsAplicarEm.Text = string.Empty;
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
        private void optMtsOficial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMtsOficial.Checked.Equals(true))
                {
                    lblMtsAplicarEm.Text = "Oficialização";
                }
                else
                {
                    lblMtsAplicarEm.Text = string.Empty;
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
        private void optMtsMeia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMtsOficial.Checked.Equals(true))
                {
                    lblMtsAplicarEm.Text = "Meia Hora";
                }
                else
                {
                    lblMtsAplicarEm.Text = string.Empty;
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

        #endregion

        #region Aba Teoria

        private void cboTeoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        private void cboTeoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTeoria.SelectedValue != null)
                {
                    foreach (MOD_teoria linha in listaTeoria)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodTeoria.Equals(cboTeoria.SelectedValue))
                        {
                            txtTeoriaNivel.Text = Convert.ToString(linha.Nivel);
                            txtTeoriaPag.Text = Convert.ToString(linha.Paginas).PadLeft(2, '0');
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
        private void btnTeoriaSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarTeoria();
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
        private void btnTeoriaCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limparTeoria();
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

        private void gridTeoria_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnTeoriaEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde("Carregando informações...");

                    IndiceTeoria = gridTeoria.CurrentRow.Index;
                    enabledForm();
                    preencheTeoria(IndiceTeoria);
                    CodLicaoTeoria = gridTeoria["CodLicaoTeoria", IndiceTeoria].Value.ToString();
                    gridTeoria.Enabled = true;
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

        private void btnTeoriaInserir_Click(object sender, EventArgs e)
        {
            try
            {
                limparTeoria();
                enabledForm();
                gpoTeoria.Enabled = true;
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
        private void btnTeoriaEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando informações...");

                IndiceTeoria = gridTeoria.CurrentRow.Index;
                gpoTeoria.Enabled = true;
                enabledForm();
                preencheTeoria(IndiceTeoria);
                CodLicaoTeoria = gridTeoria["CodLicaoTeoria", IndiceTeoria].Value.ToString();
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
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    IndiceTeoria = gridTeoria.CurrentRow.Index;
                    CodLicaoTeoria = gridTeoria["CodLicaoTeoria", IndiceTeoria].Value.ToString();
                    DescTeoria = gridTeoria["DescTeoria", IndiceTeoria].Value.ToString();
                    AplicaEmTeoria = gridTeoria["AplicaEmTeoria", IndiceTeoria].Value.ToString();

                    deleteTeoria(IndiceTeoria);
                    carregaLicaoPreTesteTeoria(string.Empty);
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

        private void optTeoriaRjm_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optTeoriaRjm.Checked.Equals(true))
                {
                    lblTeoriaAplicarEm.Text = "Reunião de Jovens";
                    apoio.Aguarde("Carregando avaliações...");
                    carregaTeoria(lblTeoriaAplicarEm.Text, "Avaliação");
                }
                else
                {
                    lblTeoriaAplicarEm.Text = string.Empty;
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
        private void optTeoriaCulto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optTeoriaCulto.Checked.Equals(true))
                {
                    lblTeoriaAplicarEm.Text = "Culto Oficial";
                    apoio.Aguarde("Carregando avaliações...");
                    carregaTeoria(lblTeoriaAplicarEm.Text, "Avaliação");
                }
                else
                {
                    lblTeoriaAplicarEm.Text = string.Empty;
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
        private void optTeoriaOficial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optTeoriaOficial.Checked.Equals(true))
                {
                    lblTeoriaAplicarEm.Text = "Oficialização";
                    apoio.Aguarde("Carregando avaliações...");
                    carregaTeoria(lblTeoriaAplicarEm.Text, "Avaliação");
                }
                else
                {
                    lblTeoriaAplicarEm.Text = string.Empty;
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
        private void optTeoriaMeia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optTeoriaMeia.Checked.Equals(true))
                {
                    lblTeoriaAplicarEm.Text = "Meia Hora";
                    apoio.Aguarde("Carregando avaliações...");
                    carregaTeoria(lblTeoriaAplicarEm.Text, "Avaliação");
                }
                else
                {
                    lblTeoriaAplicarEm.Text = string.Empty;
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

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                tabTipo.Enabled = true;
                tabMts.Enabled = true;
                tabTeoria.Enabled = true;

                if (tabTipo.SelectedTab.Name.Equals("tabMts"))
                {
                    gpoMts.Enabled = false;
                    gridMts.Enabled = true;
                    verPermMts(gridMts);
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabTeoria"))
                {
                    gpoTeoria.Enabled = false;
                    gridTeoria.Enabled = true;
                    verPermTeoria(gridTeoria);
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
                tabTipo.Enabled = true;

                if (tabTipo.SelectedTab.Name.Equals("tabMts"))
                {
                    btnMtsEditar.Enabled = false;
                    btnMtsInserir.Enabled = false;
                    btnMtsExcluir.Enabled = false;
                    gridMts.Enabled = false;
                }
                else if (tabTipo.SelectedTab.Name.Equals("tabTeoria"))
                {
                    btnTeoriaEditar.Enabled = false;
                    btnTeoriaInserir.Enabled = false;
                    btnTeoriaExcluir.Enabled = false;
                    gridTeoria.Enabled = false;
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

        #region Mts

        /// <summary>
        /// Função que valida os campos Metodos
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
                if (lblMtsAplicarEm.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Informe a Aplicação. (Reunião de Jovens, Culto Oficial ou Oficialização)";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (cboMtsMetodo.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblTipoMts.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Informe o tipo. (Solfejo ou Ritmico)";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                if (txtMtsPag.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Módulo deve ser diferente de 0.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtMtsLicao.Value.Equals(0))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba MTS > Licão deve ser diferente de 0.";
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
        /// Função que preenche o ComboBox Metodos
        /// </summary>
        /// <returns></returns>
        internal void carregaMetodosMts()
        {
            try
            {
                cboMtsMetodo.SelectedIndexChanged -= new EventHandler(cboMtsMetodo_SelectedIndexChanged);
                objBLL_Mts = new BLL_metodos();
                listaMts = new List<MOD_metodos>();

                listaMts = objBLL_Mts.buscarTipo("Solfejo");

                cboMtsMetodo.DataSource = listaMts;
                cboMtsMetodo.ValueMember = "CodMetodo";
                cboMtsMetodo.DisplayMember = "DescMetodo";
                cboMtsMetodo.SelectedIndex = (-1);
                txtMtsPag.Value = 0;
                txtMtsLicao.Value = 0;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cboMtsMetodo.SelectedIndexChanged += new EventHandler(cboMtsMetodo_SelectedIndexChanged);
            }
        }
        /// <summary>
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_licaoTesteMts criarTabelaMts()
        {
            try
            {
                objEnt_licaoTesteMts = new MOD_licaoTesteMts();
                objEnt_licaoTesteMts.CodLicaoMts = lblCodLicaoMts.Text;
                objEnt_licaoTesteMts.CodMetMts = Convert.ToString(cboMtsMetodo.SelectedValue);
                objEnt_licaoTesteMts.DescMetodo = cboMtsMetodo.Text;
                objEnt_licaoTesteMts.AplicaEm = lblMtsAplicarEm.Text;
                objEnt_licaoTesteMts.TipoMts = lblTipoMts.Text;
                objEnt_licaoTesteMts.ModuloMts = Convert.ToString(txtMtsPag.Value);
                objEnt_licaoTesteMts.LicaoMts = Convert.ToString(txtMtsLicao.Value);

                //retorna a classe de propriedades preenchida com os textbox
                return objEnt_licaoTesteMts;
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
        private void carregaLicaoPreTesteMts(string CodMetMts)
        {
            try
            {

                objBLL_licaoPreMts = new BLL_licaoTesteMts();
                listaLicaoTesteMts = objBLL_licaoPreMts.buscarLicaoMts(CodMetMts);

                funcoes.gridLicaoTeste(gridMts, "LicaoTesteMts");
                ///vincula a lista ao DataSource do DataGriView
                gridMts.DataSource = listaLicaoTesteMts;
                definirImagens(gridMts);
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
        private void salvarMts()
        {
            try
            {
                if (ValidarControlesMts().Equals(true))
                {
                    objBLL_licaoPreMts = new BLL_licaoTesteMts();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL_licaoPreMts.salvar(criarTabelaMts());

                    //Carrega as lições
                    carregaLicaoPreTesteMts(string.Empty);
                    //Limpa os controle e desabilita
                    limparMts();
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
        private void limparMts()
        {
            try
            {
                lblCodLicaoMts.Text = string.Empty;
                cboMtsMetodo.SelectedValue = (-1);
                optMtsRjm.Checked = false;
                optMtsCulto.Checked = false;
                optMtsOficial.Checked = false;
                txtMtsPag.Value = 0;
                txtMtsLicao.Value = 0;
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
                MOD_licaoTesteMts ent = new MOD_licaoTesteMts();
                ent.CodLicaoMts = CodLicaoMts;
                ent.DescMetodo = DescMts;
                ent.AplicaEm = AplicaEmMts;

                objBLL_licaoPreMts = new BLL_licaoTesteMts();
                objBLL_licaoPreMts.excluir(ent);
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
        private void preencheMts(int Indice)
        {
            try
            {
                tabMts.Enabled = true;
                tabTeoria.Enabled = false;
                tabTipo.SelectTab("tabMts");

                carregaMetodosMts();
                cboMtsMetodo.SelectedValue = listaLicaoTesteMts[Indice].CodMetMts;
                lblMtsAplicarEm.Text = listaLicaoTesteMts[Indice].AplicaEm;
                lblTipoMts.Text = listaLicaoTesteMts[Indice].TipoMts;
                verificarMts();
                lblCodLicaoMts.Text = listaLicaoTesteMts[Indice].CodLicaoMts;
                txtMtsPag.Value = Convert.ToInt16(listaLicaoTesteMts[Indice].ModuloMts);
                txtMtsLicao.Value = Convert.ToInt16(listaLicaoTesteMts[Indice].LicaoMts);
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
        internal void verificarMts()
        {
            try
            {
                ///verifica a situação
                if (lblMtsAplicarEm.Text.Equals("Reunião de Jovens"))
                {
                    optMtsRjm.Checked = true;
                }
                else if (lblMtsAplicarEm.Text.Equals("Culto Oficial"))
                {
                    optMtsCulto.Checked = true;
                }
                else if (lblMtsAplicarEm.Text.Equals("Meia Hora"))
                {
                    optMtsMeia.Checked = true;
                }
                else if (lblMtsAplicarEm.Text.Equals("Oficialização"))
                {
                    optMtsOficial.Checked = true;
                }
                //verifica o tipo MTS
                if (lblTipoMts.Text.Equals("Solfejo"))
                {
                    optMtsSolfejo.Checked = true;
                }
                else if (lblTipoMts.Text.Equals("Ritmo"))
                {
                    optMtsRitmo.Checked = true;
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

        #region Teoria

        /// <summary>
        /// Função que valida os campos Metodos
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
                if (lblTeoriaAplicarEm.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Teoria > Informe a Aplicação. (Reunião de Jovens, Culto Oficial ou Oficialização)";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (cboTeoria.SelectedIndex.Equals(-1))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Teoria > Avaliação! Campo obrigatório.";
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
        /// Função que preenche o ComboBox Metodos
        /// <para> AplicaEm = GEM, RJM, Culto Oficial, Oficialização</para>
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <returns></returns>
        internal void carregaTeoria(string AplicaEm, string TipoCadastro)
        {
            try
            {
                cboTeoria.SelectedIndexChanged -= new EventHandler(cboTeoria_SelectedIndexChanged);
                objBLL_Teoria = new BLL_teoria();
                listaTeoria = new List<MOD_teoria>();

                listaTeoria = objBLL_Teoria.buscarAplicaEm(AplicaEm, TipoCadastro);

                cboTeoria.DataSource = listaTeoria;
                cboTeoria.ValueMember = "CodTeoria";
                cboTeoria.DisplayMember = "DescTeoria";
                cboTeoria.SelectedIndex = (-1);
                txtTeoriaNivel.Text = string.Empty;
                txtTeoriaPag.Text = string.Empty;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cboTeoria.SelectedIndexChanged += new EventHandler(cboTeoria_SelectedIndexChanged);
            }
        }

        /// <summary>
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_licaoTesteTeoria criarTabelaTeoria()
        {
            try
            {
                objEnt_licaoTesteTeoria = new MOD_licaoTesteTeoria();
                objEnt_licaoTesteTeoria.CodLicaoTeoria = lblCodLicaoTeoria.Text;
                objEnt_licaoTesteTeoria.CodTeoria = Convert.ToString(cboTeoria.SelectedValue);
                objEnt_licaoTesteTeoria.DescTeoria = cboTeoria.Text;
                objEnt_licaoTesteTeoria.AplicaEm = lblTeoriaAplicarEm.Text;

                //retorna a classe de propriedades preenchida com os textbox
                return objEnt_licaoTesteTeoria;
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
        private void carregaLicaoPreTesteTeoria(string CodTeoria)
        {
            try
            {

                objBLL_licaoTesteTeoria = new BLL_licaoTesteTeoria();
                listaLicaoTesteTeoria = objBLL_licaoTesteTeoria.buscarLicaoTeoria(CodTeoria);

                funcoes.gridLicaoTeste(gridTeoria, "LicaoTesteTeoria");
                ///vincula a lista ao DataSource do DataGriView
                gridTeoria.DataSource = listaLicaoTesteTeoria;
                definirImagens(gridTeoria);
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
        private void salvarTeoria()
        {
            try
            {
                if (ValidarControlesTeoria().Equals(true))
                {
                    objBLL_licaoTesteTeoria = new BLL_licaoTesteTeoria();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL_licaoTesteTeoria.salvar(criarTabelaTeoria());

                    //Carrega os instrumentos
                    carregaLicaoPreTesteTeoria(string.Empty);

                    //Limpa os controle e desabilita
                    limparTeoria();
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
        private void limparTeoria()
        {
            try
            {
                lblCodLicaoTeoria.Text = string.Empty;
                cboTeoria.DataSource = null;
                optTeoriaRjm.Checked = false;
                optTeoriaCulto.Checked = false;
                optTeoriaOficial.Checked = false;
                txtTeoriaNivel.Text = string.Empty;
                txtTeoriaPag.Text = string.Empty;
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
                MOD_licaoTesteTeoria ent = new MOD_licaoTesteTeoria();
                ent.CodLicaoTeoria = CodLicaoTeoria;
                ent.DescTeoria = DescTeoria;
                ent.AplicaEm = AplicaEmTeoria;

                objBLL_licaoTesteTeoria = new BLL_licaoTesteTeoria();
                objBLL_licaoTesteTeoria.excluir(ent);
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
        private void preencheTeoria(int Indice)
        {
            try
            {
                tabTeoria.Enabled = true;
                tabMts.Enabled = false;
                tabTipo.SelectTab("tabTeoria");

                lblTeoriaAplicarEm.Text = listaLicaoTesteTeoria[Indice].AplicaEm;
                verificarTeoria();
                cboTeoria.SelectedValue = listaLicaoTesteTeoria[Indice].CodTeoria;
                lblCodLicaoTeoria.Text = listaLicaoTesteTeoria[Indice].CodLicaoTeoria;
                txtTeoriaNivel.Text = listaLicaoTesteTeoria[Indice].Nivel;
                txtTeoriaPag.Text = listaLicaoTesteTeoria[Indice].Paginas;
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
        internal void verificarTeoria()
        {
            try
            {
                ///verifica a situação
                if (lblTeoriaAplicarEm.Text.Equals("Reunião de Jovens"))
                {
                    optTeoriaRjm.Checked = true;
                }
                else if (lblTeoriaAplicarEm.Text.Equals("Culto Oficial"))
                {
                    optTeoriaCulto.Checked = true;
                }
                else if (lblTeoriaAplicarEm.Text.Equals("Meia Hora"))
                {
                    optTeoriaMeia.Checked = true;
                }
                else if (lblTeoriaAplicarEm.Text.Equals("Oficialização"))
                {
                    optTeoriaOficial.Checked = true;
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
        internal void verPermMts(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsLicaoPreTesteMts))
                    {
                        btnMtsInserir.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotEditLicaoPreTesteMts))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnMtsEditar.Enabled = true;
                        }
                        else
                        {
                            btnMtsEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotExcLicaoPreTesteMts))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnMtsExcluir.Enabled = true;
                        }
                        else
                        {
                            btnMtsExcluir.Enabled = false;
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
        internal void verPermTeoria(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsLicaoPreTesteTeoria))
                    {
                        btnTeoriaInserir.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotEditLicaoPreTesteTeoria))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnTeoriaEditar.Enabled = true;
                        }
                        else
                        {
                            btnTeoriaEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotExcLicaoPreTesteTeoria))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnTeoriaExcluir.Enabled = true;
                        }
                        else
                        {
                            btnTeoriaExcluir.Enabled = false;
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