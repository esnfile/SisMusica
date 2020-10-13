using BLL.Funcoes;
using BLL.importa;
using BLL.pessoa;
using BLL.Usuario;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using ENT.exporta;
using ENT.pessoa;
using ENT.relatorio;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ccbexp
{
    public partial class frmExpPessoa : Form
    {
        public frmExpPessoa()
        {
            InitializeComponent();

            try
            {

                ///preenche o comboRegional
                apoio.carregaComboRegional(cboRegional);
                //Carrega as Regiões e Comuns
                preencherGrid("Regiao", Convert.ToString(cboRegional.SelectedValue), gridRegiao);
                preencherGrid("Comum", string.Empty, gridComum);

                //Carrega os cargos
                preencherGrid("Cargo", string.Empty, gridCargo);

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

        #region declarações

        //variaveis
        string CodComum;
        string CodRegiao;
        string CodRegional;
        string CodCargo;

        bool blnValida;
        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;

        BLL_exportaPessoa objBLL;
        MOD_exportaPessoa objEnt;
        List<MOD_exportaPessoa> listaExporta = new List<MOD_exportaPessoa>();

        BLL_pessoa objBLL_Pessoa;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        List<MOD_ccb> listaCCB = new List<MOD_ccb>();

        BLL_usuario objBLL_Usuario;
        BindingList<MOD_usuarioCCB> listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();
        List<MOD_usuarioCargo> listaCargoCCB = new List<MOD_usuarioCargo>();

        BLL_regiaoAtuacao objBLL_Regiao;
        List<MOD_regiaoAtuacao> listaRegiao = new List<MOD_regiaoAtuacao>();
        List<MOD_regional> listaRegional = new List<MOD_regional>();

        List<MOD_cargo> listaCargo = new List<MOD_cargo>();

        Form formulario;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region Eventos do Formulario

        private void cboRegional_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CodRegional = Convert.ToString(cboRegional.SelectedValue);
                preencherGrid("Regiao", CodRegional, gridRegiao);
                preencherGrid("Comum", string.Empty, gridComum);
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
        private void gridRegiao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridRegiao != null || gridRegiao.RowCount > 0)
                {
                    //ao clicar na linha marca ou desmarca a primeira coluna
                    //verifica a situação da celula
                    if (gridRegiao != null || gridRegiao.RowCount > 0)
                    {
                        if (gridRegiao["Marcado", e.RowIndex].Value != null)
                        {
                            if (gridRegiao["Marcado", e.RowIndex].Value.Equals(true))
                            {
                                gridRegiao["Marcado", e.RowIndex].Value = false;
                            }
                            else
                            {
                                gridRegiao["Marcado", e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            gridRegiao["Marcado", e.RowIndex].Value = true;
                        }
                        gridRegiao.Refresh();
                    }

                    CodRegiao = preencherSelecionados("Regiao", gridRegiao);
                    preencherGrid("Comum", CodRegiao, gridComum);
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
        private void gridComum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridComum != null || gridComum.RowCount > 0)
                {
                    if (gridComum["Marcado", e.RowIndex].Value != null)
                    {
                        if (gridComum["Marcado", e.RowIndex].Value.Equals(true))
                        {
                            gridComum["Marcado", e.RowIndex].Value = false;
                        }
                        else
                        {
                            gridComum["Marcado", e.RowIndex].Value = true;
                        }
                    }
                    else
                    {
                        gridComum["Marcado", e.RowIndex].Value = true;
                    }
                    gridComum.Refresh();
                }
                CodComum = preencherSelecionados("Comum", gridComum);
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

        private void btnExpXls_Click(object sender, EventArgs e)
        {
            //Read more: http://www.linhadecodigo.com.br/artigo/3462/exportar-datagridview-para-arquivo-do-excel-com-csharp.aspx#ixzz6W4QV0PVL
            if (gridPessoa.Rows.Count > 0)
            {
                try
                {
                    if (salvarExporta().Equals(true))
                    {

                        apoio.Aguarde("Aguarde! Criando arquivo...");

                        SaveFileDialog salvar = new SaveFileDialog();

                        Excel.Application App; // Aplicação Excel
                        Excel.Workbook WorkBook; // Pasta
                        Excel.Worksheet WorkSheet; // Planilha
                        object misValue = System.Reflection.Missing.Value;

                        App = new Excel.Application();
                        WorkBook = App.Workbooks.Add(misValue);
                        WorkSheet = (Excel.Worksheet)WorkBook.Worksheets.get_Item(1);
                        int i = 0;
                        int j = 0;

                        //Exporta o Título
                        for (i = 1; i < gridPessoa.Columns.Count + 1; i++)
                        {
                            //DataGridViewCell cell = gridPessoa[j, i];
                            //WorkSheet.Cells[i + 1, j + 1] = cell.Value;
                            WorkSheet.Cells[1, i] = gridPessoa.Columns[i - 1].HeaderText;
                            lblExportado.Text = "Exportando o cabeçalho das colunas...";
                            lblExportado.Update();
                        }

                        // passa as celulas do DataGridView para a Pasta do Excel
                        for (i = 0; i <= gridPessoa.RowCount - 1; i++)
                        {
                            lblExportado.Text = "Exportando os dados do irmão(ã) " + gridPessoa["Nome", i].Value + "...";
                            lblExportado.Update();
                            for (j = 0; j <= gridPessoa.ColumnCount - 1; j++)
                            {
                                DataGridViewCell cell = gridPessoa[j, i];
                                WorkSheet.Cells[i + 2, j + 1] = cell.Value;

                            }
                        }

                        // define algumas propriedades da caixa salvar
                        salvar.Title = "Exportar para Excel";
                        salvar.Filter = "Arquivo do Excel *.xls | *.xls";
                        salvar.ShowDialog(); // mostra

                        // salva o arquivo
                        WorkBook.SaveAs(salvar.FileName, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue,

                        Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        App.Columns.AutoFit();
                        WorkBook.Close(true, misValue, misValue);

                        App.Quit(); // encerra o excel
                        MessageBox.Show("Exportação executada com êxito!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        System.Diagnostics.Process.Start(salvar.FileName);
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
        private void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Processando dados...");
                gerarRelatorio();
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

        private void btnSelRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridRegiao.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridRegiao.Refresh();

                CodRegiao = preencherSelecionados("Regiao", gridRegiao);
                preencherGrid("Comum", CodRegiao, gridComum);
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
        private void btnDesRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridRegiao.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridRegiao.Refresh();

                CodRegiao = preencherSelecionados("Regiao", gridRegiao);
                preencherGrid("Comum", CodRegiao, gridComum);
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
        private void btnSelComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridComum.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridComum.Refresh();

                CodComum = preencherSelecionados("Comum", gridComum);
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
        private void btnDesComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridComum.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridComum.Refresh();

                CodComum = preencherSelecionados("Comum", gridComum);
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
        private void gridCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridCargo != null || gridCargo.RowCount > 0)
                {
                    //ao clicar na linha marca ou desmarca a primeira coluna
                    //verifica a situação da celula
                    if (gridCargo != null || gridCargo.RowCount > 0)
                    {
                        if (gridCargo["Marcado", e.RowIndex].Value != null)
                        {
                            if (gridCargo["Marcado", e.RowIndex].Value.Equals(true))
                            {
                                gridCargo["Marcado", e.RowIndex].Value = false;
                            }
                            else
                            {
                                gridCargo["Marcado", e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            gridCargo["Marcado", e.RowIndex].Value = true;
                        }
                        gridCargo.Refresh();
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
        private void btnSelCargo_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridCargo.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridCargo.Refresh();

                CodCargo = preencherSelecionados("Cargo", gridCargo);
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
        private void btnDesCargo_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridCargo.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridCargo.Refresh();

                CodCargo = preencherSelecionados("Cargo", gridCargo);
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

        private void frmExpPessoa_Load(object sender, EventArgs e)
        {
            try
            {
                tabVisual.Enabled = false;
                lblVisualEnabled.Visible = true;
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

        private void chkMasculino_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkMasculino.Checked.Equals(true))
                {
                    if (chkFeminino.Checked.Equals(true))
                    {
                        lblSexo.Text = "Masculino','Feminino";
                    }
                    else
                    {
                        lblSexo.Text = "Masculino";
                    }
                }
                else
                {
                    if (chkFeminino.Checked.Equals(true))
                    {
                        lblSexo.Text = "Feminino";
                    }
                    else
                    {
                        lblSexo.Text = string.Empty;
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
        private void chkFeminino_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkFeminino.Checked.Equals(true))
                {
                    if (chkMasculino.Checked.Equals(true))
                    {
                        lblSexo.Text = "Masculino','Feminino";
                    }
                    else
                    {
                        lblSexo.Text = "Feminino";
                    }
                }
                else
                {
                    if (chkMasculino.Checked.Equals(true))
                    {
                        lblSexo.Text = "Masculino";
                    }
                    else
                    {
                        lblSexo.Text = string.Empty;
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
        private void chkAtivo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAtivo.Checked.Equals(true))
                {
                    if (chkInativo.Checked.Equals(true))
                    {
                        lblStatus.Text = "Ambos";
                    }
                    else
                    {
                        lblStatus.Text = "Sim";
                    }
                }
                else
                {
                    if (chkInativo.Checked.Equals(true))
                    {
                        lblStatus.Text = "Não";
                    }
                    else
                    {
                        lblStatus.Text = string.Empty;
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
        private void chkInativo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkInativo.Checked.Equals(true))
                {
                    if (chkAtivo.Checked.Equals(true))
                    {
                        lblStatus.Text = "Ambos";
                    }
                    else
                    {
                        lblStatus.Text = "Não";
                    }
                }
                else
                {
                    if (chkAtivo.Checked.Equals(true))
                    {
                        lblStatus.Text = "Sim";
                    }
                    else
                    {
                        lblStatus.Text = string.Empty;
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
        private void chkSolteiro_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSolteiro.Checked.Equals(true))
                {
                    lblSolteiro.Text = "Solteiro(a)";
                }
                else
                {
                    lblSolteiro.Text = string.Empty;
                }
                formarEstadoCivil();
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
        private void chkViuvo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkViuvo.Checked.Equals(true))
                {
                    lblViuvo.Text = "Viúvo(a)";
                }
                else
                {
                    lblViuvo.Text = string.Empty;
                }
                formarEstadoCivil();
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
        private void chkCasado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCasado.Checked.Equals(true))
                {
                    lblCasado.Text = "Casado(a)";
                }
                else
                {
                    lblCasado.Text = string.Empty;
                }
                formarEstadoCivil();
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
        private void chkDivorciado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkDivorciado.Checked.Equals(true))
                {
                    lblDivorciado.Text = "Divorciado(a)";
                }
                else
                {
                    lblDivorciado.Text = string.Empty;
                }
                formarEstadoCivil();
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
        private void optDadosGem_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optDadosGem.Checked.Equals(true))
                {
                    lbUltExp.Enabled = true;
                    lblUltExp.Enabled = true;
                    apoio.Aguarde("Buscando última exportação...");
                    carregaUltimaExporta();
                    lblExibeDados.Enabled = false;
                    lblExibeComp.Enabled = false;
                }
                else
                {
                    lblUltExp.Text = string.Empty;
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
        private void optDadosBasicos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optDadosBasicos.Checked.Equals(true))
                {
                    lblExibeDados.Enabled = true;
                    lblExibeComp.Enabled = false;
                    lbUltExp.Enabled = false;
                    lblUltExp.Enabled = false;
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
        private void optDadosCompleto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optDadosCompleto.Checked.Equals(true))
                {
                    lblExibeComp.Enabled = true;
                    lblExibeDados.Enabled = false;
                    lbUltExp.Enabled = false;
                    lblUltExp.Enabled = false;
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

        private void chkAluno_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAluno.Checked.Equals(true))
                {
                    lblAluno.Text = "Aluno GEM";
                }
                else
                {
                    lblAluno.Text = string.Empty;
                }
                formarDesenvolvimento();
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
        private void chkEnsaio_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkEnsaio.Checked.Equals(true))
                {
                    lblEnsaio.Text = "Ensaios";
                }
                else
                {
                    lblEnsaio.Text = string.Empty;
                }
                formarDesenvolvimento();
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
        private void chkMeiaHora_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkMeiaHora.Checked.Equals(true))
                {
                    lblMeiaHora.Text = "Meia Hora";
                }
                else
                {
                    lblMeiaHora.Text = string.Empty;
                }
                formarDesenvolvimento();
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
        private void chkRJM_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkRJM.Checked.Equals(true))
                {
                    lblRjm.Text = "Reunião Jovens";
                }
                else
                {
                    lblRjm.Text = string.Empty;
                }
                formarDesenvolvimento();
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
        private void chkCulto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkCulto.Checked.Equals(true))
                {
                    lblCulto.Text = "Culto Oficial";
                }
                else
                {
                    lblCulto.Text = string.Empty;
                }
                formarDesenvolvimento();
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
        private void chkOficial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkOficial.Checked.Equals(true))
                {
                    lblOficial.Text = "Oficializado";
                }
                else
                {
                    lblOficial.Text = string.Empty;
                }
                formarDesenvolvimento();
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

        private void txtDataInicial_Validated(object sender, EventArgs e)
        {
            int DtInicial = Convert.ToInt32(funcoes.DataInt(txtDataInicial.Text));
            int DtFinal = Convert.ToInt32(funcoes.DataInt(txtDataFinal.Text));

            if (DtInicial > DtFinal)
            {
                txtDataFinal.Text = txtDataInicial.Text;
                txtDataFinal.Focus();
                txtDataFinal.SelectAll();
            }
        }
        private void txtDataFinal_Validated(object sender, EventArgs e)
        {
            int DtInicial = Convert.ToInt32(funcoes.DataInt(txtDataInicial.Text));
            int DtFinal = Convert.ToInt32(funcoes.DataInt(txtDataFinal.Text));

            if (DtFinal < DtInicial)
            {
                txtDataInicial.Text = txtDataFinal.Text;
                txtDataInicial.Focus();
                txtDataInicial.SelectAll();
            }
        }
        private void btnDataInicial_Click(object sender, EventArgs e)
        {
            try
            {
                txtDataInicial.Text = funcoes.FormataData("01/01/1910");
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
        private void btnDataFinal_Click(object sender, EventArgs e)
        {
            try
            {
                txtDataFinal.Text = funcoes.FormataData("31/12/2050");
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

        #region funções privadas e publicas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private bool salvarExporta()
        {
            try
            {
                apoio.Aguarde("Salvando na base de dados...");

                if (MessageBox.Show("Mesmo que o arquivo não seja salvo, o sistema registrará como uma exportação feita com sucesso." + "\n" + "\n" +
                    "Deseja realmente efetuar a exportação dos cadastros?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    objBLL = new BLL_exportaPessoa();

                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    return objBLL.inserir(criarTabela());
                }
                else
                {
                    return false;
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        /// <summary>
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_exportaPessoa criarTabela()
        {
            try
            {
                objEnt = new MOD_exportaPessoa();
                objEnt.CodExportaPessoa = "0";
                objEnt.DataExporta = DateTime.Now.ToString("dd/MM/yyyy");
                objEnt.HoraExporta = DateTime.Now.ToString("HH:mm");
                objEnt.QtdeArquivo = txtQtde.Text;
                objEnt.CodUsuario = modulos.CodUsuario;
                objEnt.Usuario = modulos.Usuario;

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
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// <para> As Pesquisa são por: Regiao, Comum, Cargo</para>
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="DataGrid"></param>
        internal void carregaGrid(string Pesquisa, string Campo1, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("Regiao"))
                {
                    //chama a classe de negócios
                    objBLL_Regiao = new BLL_regiaoAtuacao();
                    listaRegiao = objBLL_Regiao.buscarRegional(Campo1);
                    funcoes.gridRegiao(dataGrid, "Relatorios");
                    dataGrid.DataSource = listaRegiao;
                    dataGrid.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (Pesquisa.Equals("Comum"))
                {
                    //chama a classe de negócios
                    //objBLL_CCB = new BLL_ccb();
                    //listaCCB = objBLL_CCB.buscarRegiao(Campo1);

                    objBLL_Usuario = new BLL_usuario();
                    listaUsuarioCCB = objBLL_Usuario.buscarUsuarioCCB(modulos.CodUsuario, preencherSelecionados("Regiao", gridRegiao));

                    funcoes.gridCCB(dataGrid, "Relatorios");
                    dataGrid.DataSource = listaUsuarioCCB;
                    dataGrid.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (Pesquisa.Equals("Cargo"))
                {
                    //chama a classe de negócios
                    //objBLL_Cargo = new BLL_cargo();
                    //listaCargo = objBLL_Cargo.buscarDescricao(Campo1);

                    objBLL_Usuario = new BLL_usuario();
                    listaCargoCCB = objBLL_Usuario.buscarUsuarioCargo(modulos.CodUsuario);

                    funcoes.gridCargo(dataGrid, "Relatorios");
                    dataGrid.DataSource = listaCargoCCB;
                    dataGrid.DefaultCellStyle.ForeColor = Color.Black;
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
        /// Função que valida os campos
        /// </summary>
        private bool ValidarControles()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;
                bool blnComum = false;
                bool blnCargo = false;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();

                if (string.IsNullOrEmpty(lblSexo.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Sexo.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblStatus.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Status.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblEstadoCivil.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Estado Civil.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (optDadosBasicos.Checked.Equals(false) && optDadosCompleto.Checked.Equals(false)
                     && optDadosGem.Checked.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário informar se deseja Dados básicos, completos ou Dados para GEM OnLine.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                foreach (DataGridViewRow row in gridCargo.Rows)
                {
                    if (row.Cells["Marcado"].Value != null)
                    {
                        if (row.Cells["Marcado"].Value.Equals(true))
                        {
                            blnCargo = true;
                            break;
                        }
                    }
                }
                if (blnCargo.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Ministério.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                foreach (DataGridViewRow row in gridComum.Rows)
                {
                    if (row.Cells["Marcado"].Value != null)
                    {
                        if (row.Cells["Marcado"].Value.Equals(true))
                        {
                            blnComum = true;
                            break;
                        }
                    }
                }
                if (blnComum.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar uma Comum Congregação.";
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="CodComum"></param>
        internal void preencherGrid(string Pesquisa, string Campo1, DataGridView dataGrid)
        {
            try
            {
                apoio.Aguarde();

                if (Pesquisa.Equals("Regiao"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, dataGrid);
                        CodRegiao = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridRegiao(dataGrid, "Relatorios");
                    }
                }
                else if (Pesquisa.Equals("Comum"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, dataGrid);
                        CodComum = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridCCB(dataGrid, "Relatorios");
                    }
                }
                else if (Pesquisa.Equals("Cargo"))
                {
                    carregaGrid(Pesquisa, Campo1, dataGrid);
                    CodCargo = preencherSelecionados(Pesquisa, dataGrid);
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        /// <summary>
        /// Sub que informa as Comuns que o Usuario poderá acessar
        /// </summary>
        private string preencherSelecionados(string Pesquisa, DataGridView dataGrid)
        {
            try
            {
                //Variavel de retorno
                string RetornoSelecao = string.Empty;

                if (Pesquisa.Equals("Comum"))
                {
                    string vCodCCB = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodCCB.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodCCB"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodCCB + "," + Convert.ToInt32(row.Cells["CodCCB"].Value).ToString();
                                }
                                vCodCCB = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodCCB;
                }
                else if (Pesquisa.Equals("Regiao"))
                {
                    string vCodRegiao = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodRegiao.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodRegiao"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodRegiao + "," + Convert.ToInt32(row.Cells["CodRegiao"].Value).ToString();
                                }
                                vCodRegiao = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodRegiao;
                }
                else if (Pesquisa.Equals("Cargo"))
                {
                    string vCodCargo = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodCargo.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodCargo"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodCargo + "," + Convert.ToInt32(row.Cells["CodCargo"].Value).ToString();
                                }
                                vCodCargo = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodCargo;
                }
                return RetornoSelecao;
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
        /// Sub que forma a seleção do estado civil para pesquisar
        /// </summary>
        private void formarEstadoCivil()
        {
            string[] civil = { lblSolteiro.Text, lblCasado.Text, lblViuvo.Text, lblDivorciado.Text };
            lblEstadoCivil.Text = string.Empty;

            lblEstadoCivil.Text = apoio.formarPesquisa(civil);
        }
        /// <summary>
        /// Sub que forma a seleção do desenvolvimento para pesquisar
        /// </summary>
        private void formarDesenvolvimento()
        {
            string[] desenvolvimento = { lblAluno.Text, lblEnsaio.Text, lblMeiaHora.Text, lblRjm.Text, lblCulto.Text, lblOficial.Text };
            lblDesenvolvimento.Text = string.Empty;

            lblDesenvolvimento.Text = apoio.formarPesquisa(desenvolvimento);
        }

        /// <summary>
        /// Função que carrega os dados da ultima exportação
        /// </summary>
        internal void carregaUltimaExporta()
        {
            try
            {
                objBLL = new BLL_exportaPessoa();
                listaExporta = objBLL.buscarDataUltimoRegistro();

                if (listaExporta.Count > 0)
                {
                    lblUltExp.Text = listaExporta[0].DataExporta + " - " + listaExporta[0].HoraExporta;
                }
                else
                {
                    btnExpTxt.Text = string.Empty;
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

        #region Gerar dados para relatorio

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void gerarRelatorio()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    CodCargo = preencherSelecionados("Cargo", gridCargo);
                    CodComum = preencherSelecionados("Comum", gridComum);

                    objBLL_Pessoa = new BLL_pessoa();
                    if (lblStatus.Text.Equals("Ambos"))
                    {
                        listaPessoa = objBLL_Pessoa.buscarRelatorioPessoa(lblSexo.Text, lblEstadoCivil.Text, CodCargo, CodComum, "DataCadastro", txtDataInicial.Text, txtDataFinal.Text, lblDesenvolvimento.Text);
                    }
                    else
                    {
                        listaPessoa = objBLL_Pessoa.buscarRelatorioPessoa(lblSexo.Text, lblEstadoCivil.Text, CodCargo, CodComum, lblStatus.Text.Equals("Sim") ? true : false, "DataCadastro", txtDataInicial.Text, txtDataFinal.Text, lblDesenvolvimento.Text);
                    }

                    listaPessoa = listaPessoa.OrderBy(p => p.Descricao).ToList();

                    funcoes.gridExportaPessoa(gridPessoa, optDadosBasicos.Checked.Equals(true) ? "Basico" : optDadosBasicos.Checked.Equals(true) ? "Completo" : "GEM");
                    gridPessoa.DataSource = listaPessoa;
                    txtQtde.Text = Convert.ToString(listaPessoa.Count()).PadLeft(5, '0');

                    tabVisual.Enabled = true;
                    lblVisualEnabled.Visible = false;
                    tabPessoa.SelectedTab = tabVisual;
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

        #endregion

        #endregion

    }
}