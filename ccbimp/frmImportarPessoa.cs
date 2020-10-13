using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using ENT.pessoa;
using BLL.Funcoes;
using System.Data.SqlClient;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using BLL.importa;
using BLL.uteis;
using ENT.uteis;
using BLL.instrumentos;
using ENT.instrumentos;
using BLL.validacoes.Controles;
using ENT.Erros;
using BLL.validacoes.Formularios;
using System.Threading;
using ENT.acessos;
using ENT.importa;
using BLL.pessoa;

namespace ccbimp
{
    public partial class frmImportarPessoa : Form
    {
        public frmImportarPessoa(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();

            try
            {
                //carregando a lista de permissões de acesso.
                listaAcesso = listaLibAcesso;

                montaGridDados();

                txtDataImporta.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtHoraImporta.Text = DateTime.Now.ToString("HH:mm");
                txtUsuario.Text = modulos.Usuario;
                txtCodUsuario.Text = modulos.CodUsuario;
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

        string arquivoExcel = @"Pessoas.xlsx";
        string[] listaColunaImporta;
        DataTable dt;

        string CodCargo;
        string CodCCB;
        string DescCCB;
        string CodInstr;
        string DescInstr;
        string CodCidade;
        string DescCidade;

        Form formulario;
        Form formChama;
        carregBarra formBarra;
        DataGridView dataGrid;

        List<MOD_vincularCampos> listaDados = null;
        List<MOD_vincularCampos> listaVincula = null;

        BindingList<MOD_pessoa> listaPessoa = new BindingList<MOD_pessoa>();
        List<MOD_pessoa> listaDeletePessoa = new List<MOD_pessoa>();

        BLL_importaPessoa objBLL_Importa = null;
        MOD_importaPessoa objEnt = null;
        List<MOD_importaPessoa> listaImporta = null;
        BindingList<MOD_importaPessoaItem> listaImportaItem = new BindingList<MOD_importaPessoaItem>();
        List<MOD_importaPessoaItem> listaDeleteImportaItem = new List<MOD_importaPessoaItem>();

        BindingSource objBind_Pessoa = null;

        clsException excp;

        List<MOD_acessos> listaAcesso = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        private bool threadAtiva = false;

        #endregion

        #region Eventos no Formulário

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drResult = ofdImport.ShowDialog();

                if (drResult == DialogResult.OK)
                {
                    txtCaminho.Text = ofdImport.FileName;
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
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                ((DataTable)gridImporta.DataSource).DefaultView.RowFilter = string.Format("" + cboProcurar.Text + " like '%{0}%'", txtProcurar.Text.Trim().Replace("'", "''"));
                txtQtde.Text = (gridImporta.Rows.Count - 1).ToString();
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
        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (!string.IsNullOrEmpty(txtCaminho.Text) && File.Exists(txtCaminho.Text))
                {
                    arquivoExcel = txtCaminho.Text;
                    CarregaDadosExcel();
                }
                else
                {
                    CarregaDadosExcel();
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
        private void frmImportarPessoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Importação"))
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
                    else if (sair.Equals(DialogResult.No))
                    {
                        e.Cancel = false;
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
        private void frmImportarPessoa_Load(object sender, EventArgs e)
        {
            verPermImp();
        }
        private void btnVincular_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarVinculo().Equals(true))
                {
                    apoio.Aguarde();
                    abrirForm("frmVincular", 0);
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
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
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
                apoio.FecharAguarde();
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
        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                gridImporta.DataSource = dt;
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
        private void chkLimparImportado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dt = null;
                gridImporta.DataSource = null;
                txtQtde.Text = "000000";
                chkLimparImportado.Checked = false;
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
        private void chkLimparVinculado_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                objBind_Pessoa.DataSource = null;
                listaPessoa = null;
                txtQtdeDados.Text = "000000";
                montaGridDados();
                chkLimparVinculado.Checked = false;
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
        private void tabImportacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabImportacao.SelectedTab.Equals(tabDados))
                {
                    txtCodigoDados.Text = txtCodigo.Text;
                    txtDataDados.Text = txtDataImporta.Text;
                    txtHoraDados.Text = txtHoraImporta.Text;
                    txtCodUsuarioDados.Text = txtCodUsuario.Text;
                    txtUsuarioDados.Text = txtUsuario.Text;
                    txtDescricaoDados.Text = txtDescricao.Text;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                //define algumas propridades no grid para atualização
                gridDados.ReadOnly = false;
                gridDados.ModoOpera = DataGridViewPersonal.modoOpera.Edit;
                gridDados.Rows[gridDados.CurrentRow.Index].Cells[0].Selected = true;
                gridDados.BeginEdit(true);
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

        #region Eventos Manipulação do GridDados

        private void gridDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEditar.Enabled.Equals(true))
            {
                try
                {
                    //define algumas propridades no grid para atualização
                    gridDados.ReadOnly = false;
                    gridDados.ModoOpera = DataGridViewPersonal.modoOpera.Edit;
                    gridDados.Rows[gridDados.CurrentRow.Index].Cells[e.ColumnIndex].ReadOnly = false;
                    gridDados.Rows[gridDados.CurrentRow.Index].Cells[e.ColumnIndex].Selected = true;
                    gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                    gridDados.BeginEdit(true);
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
        }
        private void gridDados_Leave(object sender, EventArgs e)
        {
            try
            {
                gridDados.EndEdit();
                gridDados.ReadOnly = true;
                gridDados.ModoOpera = DataGridViewPersonal.modoOpera.Nenhum;
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
        private void gridDados_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //habilitação das celulas após a entrada para edição
                if (gridDados != null && gridDados.Rows.Count > 0)
                {
                    if (gridDados.ReadOnly.Equals(false))
                    {
                        if (gridDados.Columns[e.ColumnIndex].Name.Equals("Cpf"))
                        {
                            gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                            gridDados.BeginEdit(true);
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DataNasc"))
                        {
                            gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                            gridDados.BeginEdit(true);
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCargo"))
                        {
                            gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                            gridDados.BeginEdit(true);
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DescCargo"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(gridDados["CodCargo", e.RowIndex].Value)))
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                            }
                            else
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                                gridDados.BeginEdit(true);
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CepRes"))
                        {
                            gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                            gridDados.BeginEdit(true);
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCidadeRes"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(gridDados["CepRes", e.RowIndex].Value)))
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                            }
                            else
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                                gridDados.BeginEdit(true);
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CidadeRes"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(gridDados["CepRes", e.RowIndex].Value)))
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                            }
                            else
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                                gridDados.BeginEdit(true);
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCCB"))
                        {
                            gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                            gridDados.BeginEdit(true);
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DescCCB"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(gridDados["CodCCB", e.RowIndex].Value)))
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                            }
                            else
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                                gridDados.BeginEdit(true);
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodInstrumento"))
                        {
                            gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                            gridDados.BeginEdit(true);
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DescInstrumento"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(gridDados["CodInstrumento", e.RowIndex].Value)))
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                            }
                            else
                            {
                                gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                                gridDados.BeginEdit(true);
                            }
                        }
                        else
                        {
                            gridDados.Columns[e.ColumnIndex].ReadOnly = true;
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
        private void gridDados_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //desabilitação das celulas após a saída da mesma
                if (gridDados != null || gridDados.Rows.Count < 1)
                {
                    if (gridDados.ReadOnly.Equals(false))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = true;
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
        private void gridDados_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                //habilitação das celulas após a entrada para edição
                if (gridDados != null || gridDados.Rows.Count > 0)
                {
                    if (gridDados.ReadOnly.Equals(false))
                    {
                        if (gridDados.Columns[e.ColumnIndex].Name.Equals("DataCadastro"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue)))
                            {
                                listaPessoa[e.RowIndex].DataCadastro = funcoes.FormataData(Convert.ToString(e.FormattedValue));
                                e.Cancel = false;
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("HoraCadastro"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue)))
                            {
                                listaPessoa[e.RowIndex].HoraCadastro = funcoes.FormataHora(Convert.ToString(e.FormattedValue));
                                e.Cancel = false;
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCargo"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue).Trim()))
                            {
                                //verifica se a função que carrega o serviço foi preenchida
                                carregaCargo(Convert.ToString(e.FormattedValue), e.RowIndex);
                                e.Cancel = false;
                            }
                            else
                            {
                                listaPessoa[e.RowIndex].DescCargo = string.Empty;
                                abrirForm("frmCargo", e.RowIndex);
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DataNasc"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue)))
                            {
                                listaPessoa[e.RowIndex].DataNasc = funcoes.FormataData(Convert.ToString(e.FormattedValue));
                                e.Cancel = false;
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("Cpf"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue)))
                            {
                                listaPessoa[e.RowIndex].Cpf = funcoes.FormataCpf(Convert.ToString(e.FormattedValue));
                                e.Cancel = false;
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DataBatismo"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue)))
                            {
                                listaPessoa[e.RowIndex].DataBatismo = funcoes.FormataData(Convert.ToString(e.FormattedValue));
                                e.Cancel = false;
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CepRes"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue).Trim()))
                            {
                                //verifica se a função que carrega o serviço foi preenchida
                                carregaCep(Convert.ToString(e.FormattedValue), e.RowIndex);
                                e.Cancel = false;
                            }
                            else
                            {
                                listaPessoa[e.RowIndex].CodCidadeRes = string.Empty;
                                listaPessoa[e.RowIndex].CidadeRes = string.Empty;
                                abrirForm("frmCidade", e.RowIndex);
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCCB"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue).Trim()))
                            {
                                //verifica se a função que carrega o serviço foi preenchida
                                carregaCCB(Convert.ToString(e.FormattedValue), e.RowIndex);
                                e.Cancel = false;
                            }
                            else
                            {
                                listaPessoa[e.RowIndex].Descricao = string.Empty;
                                abrirForm("frmCCB", e.RowIndex);
                            }
                        }
                        else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodInstrumento"))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(e.FormattedValue).Trim()))
                            {
                                //verifica se a função que carrega o serviço foi preenchida
                                carregaInstr(Convert.ToString(e.FormattedValue), e.RowIndex);
                                e.Cancel = false;
                            }
                            else
                            {
                                listaPessoa[e.RowIndex].DescInstrumento = string.Empty;
                                abrirForm("frmInstr", e.RowIndex);
                            }
                        }
                        definirErro(Convert.ToInt32(e.RowIndex));
                    }
                }
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                gridDados[e.ColumnIndex, e.RowIndex].ReadOnly = false;
                excp = new clsException(ex);
            }
        }
        private void gridDados_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //desabilitação das celulas após a saida
                if (gridDados != null || gridDados.Rows.Count > 0)
                {
                    if (gridDados.ReadOnly.Equals(false))
                    {
                        gridDados.EndEdit();
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
        private void gridDados_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                //habilitação das celulas após a entrada para edição
                if (gridDados != null && gridDados.Rows.Count > 0)
                {
                    if (gridDados.Columns[e.ColumnIndex].Name.Equals("Cpf"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DataNasc"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCargo"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DescCargo"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                        gridDados["CodCargo", e.RowIndex].ReadOnly = false;
                        gridDados["CodCargo", e.RowIndex].Selected = true;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CepRes"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCidadeRes"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                        gridDados["CepRes", e.RowIndex].ReadOnly = false;
                        gridDados["CepRes", e.RowIndex].Selected = true;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CidadeRes"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                        gridDados["CepRes", e.RowIndex].ReadOnly = false;
                        gridDados["CepRes", e.RowIndex].Selected = true;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodCCB"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DescCCB"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                        gridDados["CodCCB", e.RowIndex].ReadOnly = false;
                        gridDados["CodCCB", e.RowIndex].Selected = true;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("CodInstrumento"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                    else if (gridDados.Columns[e.ColumnIndex].Name.Equals("DescInstrumento"))
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = true;
                        gridDados["CodInstrumento", e.RowIndex].ReadOnly = false;
                        gridDados["CodInstrumento", e.RowIndex].Selected = true;
                    }
                    else
                    {
                        gridDados.Columns[e.ColumnIndex].ReadOnly = false;
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
        private void gridDados_SelectionChanged(object sender, EventArgs e)
        {
        }
        private void gridDados_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (gridDados.CurrentCell.ColumnIndex.Equals(gridDados.ColumnCount - 1))
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        try
                        {
                            gridDados.ReadOnly = true;
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
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    if (gridDados.ModoOpera.Equals(DataGridViewPersonal.modoOpera.Edit))
                    {
                        gridDados.ReadOnly = true;
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
        private void gridDados_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                if (e.Exception != null)
                {
                    e.Cancel = true;
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
        private void gridDados_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void gridDados_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (gridDados.Rows.Count > 0)
                {
                    btnEditar.Enabled = true;
                }
                else
                {
                    btnEditar.Enabled = false;
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

        private void frmImportarPessoa_Activated(object sender, EventArgs e)
        {
            try
            {
                if (gridDados.Rows.Count > 0)
                {
                    foreach (DataGridViewRow linha in gridDados.Rows)
                    {
                        definirErro(Convert.ToInt32(linha.Index));
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

        #endregion

        #region Funções publicas e privadas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    if (MessageBox.Show("Esse processo é irreversível, e qualquer alteração ou exclusão " + "\n" +
                        "deverá ser feito individualmente em cada cadastro." + "\n" + "\n" +
                        "Deseja realmente efetuar a importação dos cadastros?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        objBLL_Importa = new BLL_importaPessoa();

                        if (Convert.ToInt64(txtCodigo.Text).Equals(0))
                        {
                            //chama a rotina da camada de negocios para efetuar inserção ou update
                            objBLL_Importa.inserir(criarLista(gridDados));
                        }
                        else
                        {
                            //chama a rotina da camada de negocios para efetuar inserção ou update
                            objBLL_Importa.salvar(criarLista(gridDados));
                        }

                        //conversor para retorno ao formulario que chamou
                        if (formChama.Name.Equals("frmImportarPessoaBusca"))
                        {
                            ((frmImportarPessoaBusca)formChama).carregaGrid("Codigo", objEnt.CodImportaPessoa, string.Empty, dataGrid);
                        }

                        FormClosing -= new FormClosingEventHandler(frmImportarPessoa_FormClosing);

                        Close();

                        FormClosing += new FormClosingEventHandler(frmImportarPessoa_FormClosing);
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

                foreach (DataGridViewRow linha in gridDados.Rows)
                {
                    foreach (DataGridViewCell celula in linha.Cells)
                    {
                        if (celula.Value != null)
                        {
                            if (celula.Value.Equals("Erro"))
                            {

                                blnValida = false;
                                objEnt_Erros = new MOD_erros();
                                objEnt_Erros.Texto = "Há erros na lista.    Linha: " + Convert.ToString(linha.Index + 1).PadLeft(5, '0') + "   -   Coluna: " + gridDados.Columns[celula.ColumnIndex].HeaderText + ".";

                                if (Convert.ToString(modulos.listaParametros[0].ValidarDadosImportacao).Equals("Sim"))
                                {
                                    objEnt_Erros.Grau = "Alto";
                                    listaErros.Add(objEnt_Erros);
                                }
                                else
                                {
                                    objEnt_Erros.Grau = "Baixo";
                                    listaErros.Add(objEnt_Erros);
                                }
                            }
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
        /// Função que valida os campos
        /// </summary>
        private bool ValidarVinculo()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();

                if (string.IsNullOrEmpty(txtDescricao.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private MOD_importaPessoa criarLista(DataGridView dataGrid)
        {
            try
            {
                //instancia a lista
                objEnt = new MOD_importaPessoa();

                //adiciona os campos às propriedades
                objEnt.CodImportaPessoa = txtCodigo.Text;
                objEnt.DataImporta = txtDataImporta.Text;
                objEnt.HoraImporta = txtHoraImporta.Text;
                objEnt.CodUsuario = modulos.CodUsuario;
                objEnt.QtdeArquivo = txtQtdeDados.Text;
                objEnt.Descricao = txtDescricaoDados.Text;

                objEnt.ListaPessoaItem = criarListaItens(dataGrid);
                objEnt.ListaPessoaItemErros = criarListaItensErros(dataGrid);

                //retorna a lista com os valores pesquisados
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_importaPessoaItem> criarListaItens(DataGridView dataGrid)
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoaItem> lista = new List<MOD_importaPessoaItem>();

                string LinhaErro;

                //faz um loop no DataTable e preenche a lista
                foreach (DataGridViewRow row in gridDados.Rows)
                {
                    LinhaErro = "Não";

                    //Faz a leitura em todas as celulas da linha, a procura de erros
                    foreach (DataGridViewCell celula in row.Cells)
                    {
                        if (celula.Value != null)
                        {
                            if (celula.Value.Equals("Erro"))
                            {
                                LinhaErro = "Sim";
                                break;
                            }
                        }
                    }

                    if (LinhaErro.Equals("Sim"))
                    {
                        //break;
                    }
                    else
                    {
                        //instancia a entidade
                        MOD_importaPessoaItem ent = new MOD_importaPessoaItem();
                        //adiciona os campos às propriedades
                        ent.CodImportaPessoaItem = "0";
                        ent.CodImportaPessoa = txtCodigo.Text;
                        ent.DataCadastro = funcoes.FormataData(Convert.ToString(row.Cells["DataCadastro"].Value));
                        ent.HoraCadastro = funcoes.FormataHora(Convert.ToString(row.Cells["HoraCadastro"].Value));
                        ent.CodCargo = Convert.ToString(row.Cells["CodCargo"].Value).PadLeft(3, '0');
                        ent.DescCargo = Convert.ToString(row.Cells["DescCargo"].Value);
                        ent.Nome = Convert.ToString(row.Cells["Nome"].Value).ToUpper();
                        ent.DataNasc = funcoes.FormataData(Convert.ToString(row.Cells["DataNasc"].Value));
                        ent.Cpf = Convert.ToString(row.Cells["Cpf"].Value);
                        ent.Rg = Convert.ToString(row.Cells["Rg"].Value);
                        ent.OrgaoEmissor = Convert.ToString(row.Cells["OrgaoEmissor"].Value);
                        ent.Sexo = Convert.ToString(row.Cells["Sexo"].Value);
                        ent.DataBatismo = funcoes.FormataData(Convert.ToString(row.Cells["DataBatismo"].Value));
                        ent.CodCidadeRes = Convert.ToString(row.Cells["CodCidadeRes"].Value).PadLeft(6, '0');
                        ent.CidadeRes = Convert.ToString(row.Cells["CidadeRes"].Value);
                        ent.CepRes = funcoes.FormataString("#####-###", Convert.ToString(row.Cells["CepRes"].Value));
                        ent.EndRes = Convert.ToString(row.Cells["EndRes"].Value).ToUpper();
                        ent.NumRes = Convert.ToString(row.Cells["NumRes"].Value);
                        ent.BairroRes = Convert.ToString(row.Cells["BairroRes"].Value).ToUpper();
                        ent.ComplRes = Convert.ToString(row.Cells["ComplRes"].Value).ToUpper();
                        ent.Telefone1 = funcoes.FormataString("(##) ####-####", Convert.ToString(row.Cells["Telefone1"].Value));
                        ent.Telefone2 = funcoes.FormataString("(##) ####-####", Convert.ToString(row.Cells["Telefone2"].Value));
                        ent.Celular1 = funcoes.FormataString("(##) #####-####", Convert.ToString(row.Cells["Celular1"].Value));
                        ent.Celular2 = funcoes.FormataString("(##) #####-####", Convert.ToString(row.Cells["Celular2"].Value));
                        ent.Email = Convert.ToString(row.Cells["Email"].Value).ToLower();
                        ent.CodCCB = Convert.ToString(row.Cells["CodCCB"].Value).PadLeft(6, '0');
                        ent.Descricao = Convert.ToString(row.Cells["DescCCB"].Value);
                        ent.EstadoCivil = Convert.ToString(row.Cells["EstadoCivil"].Value);
                        ent.DataApresentacao = funcoes.FormataData(Convert.ToString(row.Cells["DataApresentacao"].Value));
                        ent.PaisCCB = Convert.ToString(row.Cells["PaisCCB"].Value);
                        ent.Pai = Convert.ToString(row.Cells["Pai"].Value).ToUpper();
                        ent.Mae = Convert.ToString(row.Cells["Mae"].Value).ToUpper();
                        ent.FormacaoFora = Convert.ToString(row.Cells["FormacaoFora"].Value);
                        ent.LocalFormacao = Convert.ToString(row.Cells["LocalFormacao"].Value).ToUpper();
                        ent.QualFormacao = Convert.ToString(row.Cells["QualFormacao"].Value).ToUpper();
                        ent.OutraOrquestra = Convert.ToString(row.Cells["OutraOrquestra"].Value);
                        ent.Orquestra1 = Convert.ToString(row.Cells["Orquestra1"].Value).ToUpper();
                        ent.Funcao1 = Convert.ToString(row.Cells["Funcao1"].Value).ToUpper();
                        ent.Orquestra2 = Convert.ToString(row.Cells["Orquestra2"].Value).ToUpper();
                        ent.Funcao2 = Convert.ToString(row.Cells["Funcao2"].Value).ToUpper();
                        ent.Orquestra3 = Convert.ToString(row.Cells["Orquestra3"].Value).ToUpper();
                        ent.Funcao3 = Convert.ToString(row.Cells["Funcao3"].Value).ToUpper();
                        ent.CodInstrumento = Convert.ToString(row.Cells["CodInstrumento"].Value).PadLeft(5, '0');
                        ent.DescInstrumento = Convert.ToString(row.Cells["DescInstrumento"].Value);
                        ent.Desenvolvimento = Convert.ToString(row.Cells["Desenvolvimento"].Value);
                        ent.DataUltimoTeste = funcoes.FormataData(Convert.ToString(row.Cells["DataUltimoTeste"].Value));
                        ent.DataInicioEstudo = funcoes.FormataData(Convert.ToString(row.Cells["DataInicioEstudo"].Value));
                        ent.ExecutInstrumento = Convert.ToString(row.Cells["ExecutandoInstrumento"].Value);

                        //adiciona os dados à lista
                        lista.Add(ent);

                    }
                }
                //retorna a lista com os valores pesquisados
                return lista;
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_importaPessoaItemErro> criarListaItensErros(DataGridView dataGrid)
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoaItemErro> listaItensErro = new List<MOD_importaPessoaItemErro>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataGridViewRow row in gridDados.Rows)
                {
                    foreach (DataGridViewCell celula in row.Cells)
                    {
                        if (celula.Value != null)
                        {
                            if (celula.Value.Equals("Erro"))
                            {
                                //instancia a entidade
                                MOD_importaPessoaItemErro ent = new MOD_importaPessoaItemErro();
                                //adiciona os campos às propriedades
                                ent.CodImportaPessoaItem = "0";
                                ent.CodImportaPessoa = txtCodigo.Text;
                                ent.DataCadastro = funcoes.FormataData(Convert.ToString(row.Cells["DataCadastro"].Value));
                                ent.HoraCadastro = funcoes.FormataHora(Convert.ToString(row.Cells["HoraCadastro"].Value));
                                ent.CodCargo = Convert.ToString(row.Cells["CodCargo"].Value);
                                ent.DescCargo = Convert.ToString(row.Cells["DescCargo"].Value);
                                ent.Nome = Convert.ToString(row.Cells["Nome"].Value).ToUpper();
                                ent.DataNasc = funcoes.FormataData(Convert.ToString(row.Cells["DataNasc"].Value));
                                ent.Cpf = Convert.ToString(row.Cells["Cpf"].Value);
                                ent.Rg = Convert.ToString(row.Cells["Rg"].Value);
                                ent.OrgaoEmissor = Convert.ToString(row.Cells["OrgaoEmissor"].Value);
                                ent.Sexo = Convert.ToString(row.Cells["Sexo"].Value);
                                ent.DataBatismo = funcoes.FormataData(Convert.ToString(row.Cells["DataBatismo"].Value));
                                ent.CodCidadeRes = Convert.ToString(row.Cells["CodCidadeRes"].Value);
                                ent.CidadeRes = Convert.ToString(row.Cells["CidadeRes"].Value);
                                ent.EstadoRes = Convert.ToString(row.Cells["EstadoRes"].Value);
                                ent.CepRes = funcoes.FormataString("#####-###", Convert.ToString(row.Cells["CepRes"].Value));
                                ent.EndRes = Convert.ToString(row.Cells["EndRes"].Value).ToUpper();
                                ent.NumRes = Convert.ToString(row.Cells["NumRes"].Value);
                                ent.BairroRes = Convert.ToString(row.Cells["BairroRes"].Value).ToUpper();
                                ent.ComplRes = Convert.ToString(row.Cells["ComplRes"].Value).ToUpper();
                                ent.Telefone1 = funcoes.FormataString("(##) ####-####", Convert.ToString(row.Cells["Telefone1"].Value));
                                ent.Telefone2 = funcoes.FormataString("(##) ####-####", Convert.ToString(row.Cells["Telefone2"].Value));
                                ent.Celular1 = funcoes.FormataString("(##) #####-####", Convert.ToString(row.Cells["Celular1"].Value));
                                ent.Celular2 = funcoes.FormataString("(##) #####-####", Convert.ToString(row.Cells["Celular2"].Value));
                                ent.Email = Convert.ToString(row.Cells["Email"].Value).ToLower();
                                ent.CodCCB = Convert.ToString(row.Cells["CodCCB"].Value);
                                ent.DescCCB = Convert.ToString(row.Cells["DescCCB"].Value);
                                ent.EstadoCivil = Convert.ToString(row.Cells["EstadoCivil"].Value);
                                ent.DataApresentacao = funcoes.FormataData(Convert.ToString(row.Cells["DataApresentacao"].Value));
                                ent.PaisCCB = Convert.ToString(row.Cells["PaisCCB"].Value);
                                ent.Pai = Convert.ToString(row.Cells["Pai"].Value).ToUpper();
                                ent.Mae = Convert.ToString(row.Cells["Mae"].Value).ToUpper();
                                ent.FormacaoFora = Convert.ToString(row.Cells["FormacaoFora"].Value);
                                ent.LocalFormacao = Convert.ToString(row.Cells["LocalFormacao"].Value).ToUpper();
                                ent.QualFormacao = Convert.ToString(row.Cells["QualFormacao"].Value).ToUpper();
                                ent.OutraOrquestra = Convert.ToString(row.Cells["OutraOrquestra"].Value);
                                ent.Orquestra1 = Convert.ToString(row.Cells["Orquestra1"].Value).ToUpper();
                                ent.Funcao1 = Convert.ToString(row.Cells["Funcao1"].Value).ToUpper();
                                ent.Orquestra2 = Convert.ToString(row.Cells["Orquestra2"].Value).ToUpper();
                                ent.Funcao2 = Convert.ToString(row.Cells["Funcao2"].Value).ToUpper();
                                ent.Orquestra3 = Convert.ToString(row.Cells["Orquestra3"].Value).ToUpper();
                                ent.Funcao3 = Convert.ToString(row.Cells["Funcao3"].Value).ToUpper();
                                ent.CodInstrumento = Convert.ToString(row.Cells["CodInstrumento"].Value);
                                ent.DescInstrumento = Convert.ToString(row.Cells["DescInstrumento"].Value);
                                ent.Desenvolvimento = Convert.ToString(row.Cells["Desenvolvimento"].Value);
                                ent.DataUltimoTeste = funcoes.FormataData(Convert.ToString(row.Cells["DataUltimoTeste"].Value));
                                ent.DataInicioEstudo = funcoes.FormataData(Convert.ToString(row.Cells["DataInicioEstudo"].Value));
                                ent.ExecutInstrumento = Convert.ToString(row.Cells["ExecutandoInstrumento"].Value);

                                //adiciona os dados à lista
                                listaItensErro.Add(ent);

                                break;
                            }
                        }
                    }
                }

                //retorna a lista com os valores pesquisados
                return listaItensErro;
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
        /// Função que lista preenche o GridImportar
        /// </summary>
        private void CarregaDadosExcel()
        {
            try
            {
                //limpa o combobox
                cboProcurar.Items.Clear();

                //converte os dados do Excel para um DataTable
                dt = GetTabelaExcel(arquivoExcel);
                //ajusta a largura das colunas aos dados
                gridImporta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridImporta.DataSource = dt;
                //No total de registros
                txtQtde.Text = Convert.ToString(gridImporta.Rows.Count).PadLeft(6, '0');
                listaColunaImporta = dt.Columns.OfType<DataColumn>().Select(x => x.ColumnName).ToArray();

                //Adiciona os nomes das colunas no Combobox
                cboProcurar.Items.AddRange(listaColunaImporta);
                if (cboProcurar.Items.Count > 0)
                {
                    cboProcurar.SelectedIndex = 0;
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
        /// Função que convert os dados do excel para um datatable
        /// </summary>
        private DataTable GetTabelaExcel(string arquivoExcel)
        {
            try
            {
                DataTable dtb = new DataTable();
                //pega a extensão do arquivo
                string Ext = Path.GetExtension(arquivoExcel);
                string connectionString = string.Empty;
                //verifica a versão do Excel pela extensão
                if (Ext == ".xls")
                { //para o  Excel 97-03    
                    connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" + arquivoExcel + "; Extended Properties = 'Excel 8.0;HDR=YES'";
                }
                else if (Ext == ".xlsx")
                { //para o  Excel 07 e superior
                    connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" + arquivoExcel + "; Extended Properties = 'Excel 8.0;HDR=YES'";
                }
                OleDbConnection conn = new OleDbConnection(connectionString);

                ////Nova forma
                //conn.Open();
                //dtb = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, "TABLE" });
                //DataSet outPut = new DataSet();

                //foreach (DataRow row in dtb.Rows)
                //{
                //    //Obtem o nome da planilha
                //    string sheet = row["TABLE_NAME"].ToString();
                //    //Obtem todas as linhas da planihla corrente
                //    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn);
                //    cmd.CommandType = CommandType.Text;

                //    //copia os dados da planilha para o datatable
                //    DataTable outputDataTable = new DataTable(sheet);
                //    outPut.Tables.Add(outputDataTable);
                //    new OleDbDataAdapter(cmd).Fill(outputDataTable);
                //}

                //return outPut.Tables[0];

                OleDbCommand cmd = new OleDbCommand();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
                cmd.Connection = conn;
                conn.Open();
                DataTable dtSchema;
                dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                string nomePlanilha = dtSchema.Rows[0]["TABLE_NAME"].ToString();
                conn.Close();
                //le todos os dados da planilha para o Data Table    
                conn.Open();
                cmd.CommandText = "SELECT * From [" + nomePlanilha + "]";
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dtb);
                conn.Close();
                return dtb;
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
        private void abrirForm(string form, int Indice)
        {
            try
            {
                if (form.Equals("frmVincular"))
                {
                    listaVincula = new List<MOD_vincularCampos>();
                    listaDados = new List<MOD_vincularCampos>();

                    foreach (DataColumn Coluna in dt.Columns)
                    {
                        //instancia a entidade
                        MOD_vincularCampos ent = new MOD_vincularCampos();
                        //adiciona os campos às propriedades
                        ent.CampoImportado = Coluna.ColumnName;
                        listaDados.Add(ent);
                    }

                    foreach (DataGridViewColumn colVincula in gridDados.Columns)
                    {
                        if (colVincula.Visible.Equals(true))
                        {
                            //instancia a entidade
                            MOD_vincularCampos ent = new MOD_vincularCampos();
                            //adiciona os campos às propriedades
                            ent.CampoVinculado = colVincula.Name;
                            listaVincula.Add(ent);
                        }
                    }

                    formulario = new frmVincularCampos(this, listaDados, listaVincula);
                    ((frmVincularCampos)formulario).MdiParent = MdiParent;
                    ((frmVincularCampos)formulario).StartPosition = FormStartPosition.Manual;
                    ((frmVincularCampos)formulario).Show();
                    ((frmVincularCampos)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmCargo"))
                {
                    //limpa o DataGridView
                    listaPessoa[Indice].CodCargo = string.Empty;
                    listaPessoa[Indice].DescCargo = string.Empty;

                    frmPesquisaCargoImp formPesq = new frmPesquisaCargoImp();
                    //funcoes.CentralizarForm(formPesq);

                    if (formPesq.ShowDialog().Equals(DialogResult.OK))
                    {
                        carregaCargo(formPesq.Codigo, Indice);
                    }
                }
                else if (form.Equals("frmCCB"))
                {
                    //limpa o DataGridView
                    listaPessoa[Indice].CodCCB = string.Empty;
                    listaPessoa[Indice].Descricao = string.Empty;

                    frmPesquisaComumImp formPesq = new frmPesquisaComumImp();
                    //funcoes.CentralizarForm(formPesq);

                    if (formPesq.ShowDialog().Equals(DialogResult.OK))
                    {
                        carregaCCB(formPesq.Codigo, Indice);
                    }
                }
                else if (form.Equals("frmCidade"))
                {
                    //limpa o DataGridView
                    listaPessoa[Indice].CepRes = string.Empty;
                    listaPessoa[Indice].CidadeRes = string.Empty;
                    listaPessoa[Indice].CepRes = string.Empty;

                    frmPesquisaCidadeImp formPesq = new frmPesquisaCidadeImp();
                    //funcoes.CentralizarForm(formPesq);

                    if (formPesq.ShowDialog().Equals(DialogResult.OK))
                    {
                        carregaCep(formPesq.Cep, Indice);
                    }
                }
                else if (form.Equals("frmInstr"))
                {
                    //limpa o DataGridView
                    listaPessoa[Indice].CodInstrumento = string.Empty;
                    listaPessoa[Indice].DescInstrumento = string.Empty;

                    frmPesquisaInstrImp formPesq = new frmPesquisaInstrImp();
                    //funcoes.CentralizarForm(formPesq);

                    if (formPesq.ShowDialog().Equals(DialogResult.OK))
                    {
                        carregaInstr(formPesq.Codigo, Indice);
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

        ///<summary> Montar DataGrid Dados Importados
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta pessoas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridDados()
        {
            try
            {
                gridDados.AutoGenerateColumns = false;
                gridDados.DataSource = null;
                gridDados.Columns.Clear();
                gridDados.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///1ª coluna
                DataGridViewTextBoxColumn colAtivo = new DataGridViewTextBoxColumn();
                colAtivo.DataPropertyName = "Ativo";
                colAtivo.Name = "Ativo";
                colAtivo.HeaderText = "Ativo";
                colAtivo.Width = 80;
                colAtivo.Frozen = false;
                colAtivo.MinimumWidth = 80;
                colAtivo.ReadOnly = true;
                colAtivo.FillWeight = 100;
                colAtivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAtivo.MaxInputLength = 200;
                colAtivo.Visible = false;
                ///1ª coluna
                DataGridViewTextBoxColumn colCodPessoa = new DataGridViewTextBoxColumn();
                colCodPessoa.DataPropertyName = "CodPessoa";
                colCodPessoa.Name = "CodPessoa";
                colCodPessoa.HeaderText = "CodPessoa";
                colCodPessoa.Width = 80;
                colCodPessoa.Frozen = false;
                colCodPessoa.MinimumWidth = 80;
                colCodPessoa.ReadOnly = true;
                colCodPessoa.FillWeight = 100;
                colCodPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodPessoa.MaxInputLength = 200;
                colCodPessoa.Visible = false;
                ///1ª coluna
                DataGridViewTextBoxColumn colDataCadastro = new DataGridViewTextBoxColumn();
                colDataCadastro.DataPropertyName = "DataCadastro";
                colDataCadastro.Name = "DataCadastro";
                colDataCadastro.HeaderText = "Data Cadastro";
                colDataCadastro.Width = 80;
                colDataCadastro.Frozen = false;
                colDataCadastro.DefaultCellStyle.Format = "dd/mm/yyyy";
                colDataCadastro.MinimumWidth = 80;
                colDataCadastro.ReadOnly = true;
                colDataCadastro.FillWeight = 100;
                colDataCadastro.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDataCadastro.MaxInputLength = 200;
                colDataCadastro.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colHoraCadastro = new DataGridViewTextBoxColumn();
                colHoraCadastro.DataPropertyName = "HoraCadastro";
                colHoraCadastro.Name = "HoraCadastro";
                colHoraCadastro.HeaderText = "Hora";
                colHoraCadastro.Width = 60;
                colHoraCadastro.Frozen = false;
                colHoraCadastro.DefaultCellStyle.Format = "HH:mm";
                colHoraCadastro.MinimumWidth = 60;
                colHoraCadastro.ReadOnly = true;
                colHoraCadastro.FillWeight = 100;
                colHoraCadastro.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colHoraCadastro.MaxInputLength = 200;
                colHoraCadastro.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colCodCargo = new DataGridViewTextBoxColumn();
                colCodCargo.Name = "CodCargo";
                colCodCargo.HeaderText = "CodCargo";
                colCodCargo.DataPropertyName = "CodCargo";
                colCodCargo.Width = 50;
                colCodCargo.Frozen = false;
                colCodCargo.MinimumWidth = 50;
                colCodCargo.ReadOnly = true;
                colCodCargo.FillWeight = 100;
                colCodCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCargo.MaxInputLength = 100;
                colCodCargo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescCargo = new DataGridViewTextBoxColumn();
                colDescCargo.Name = "DescCargo";
                colDescCargo.HeaderText = "Cargo";
                colDescCargo.DataPropertyName = "DescCargo";
                colDescCargo.Width = 80;
                colDescCargo.Frozen = false;
                colDescCargo.MinimumWidth = 80;
                colDescCargo.ReadOnly = true;
                colDescCargo.FillWeight = 100;
                colDescCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescCargo.MaxInputLength = 200;
                colDescCargo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
                colNome.Name = "Nome";
                colNome.HeaderText = "Nome";
                colNome.DataPropertyName = "Nome";
                colNome.Width = 120;
                colNome.Frozen = false;
                colNome.MinimumWidth = 120;
                colNome.ReadOnly = true;
                colNome.FillWeight = 100;
                colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colNome.MaxInputLength = 200;
                colNome.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDataNasc = new DataGridViewTextBoxColumn();
                colDataNasc.Name = "DataNasc";
                colDataNasc.HeaderText = "Nascimento";
                colDataNasc.DataPropertyName = "DataNasc";
                colDataNasc.Width = 80;
                colDataNasc.Frozen = false;
                colDataNasc.DefaultCellStyle.Format = "dd/mm/yyyy";
                colDataNasc.MinimumWidth = 80;
                colDataNasc.ReadOnly = true;
                colDataNasc.FillWeight = 100;
                colDataNasc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDataNasc.MaxInputLength = 200;
                colDataNasc.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colCpf = new DataGridViewTextBoxColumn();
                colCpf.Name = "Cpf";
                colCpf.HeaderText = "C.P.F.";
                colCpf.DataPropertyName = "Cpf";
                colCpf.Width = 100;
                colCpf.Frozen = false;
                colCpf.MinimumWidth = 80;
                colCpf.ReadOnly = true;
                colCpf.FillWeight = 100;
                colCpf.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCpf.MaxInputLength = 30;
                colCpf.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colRg = new DataGridViewTextBoxColumn();
                colRg.Name = "Rg";
                colRg.HeaderText = "R.G.";
                colRg.DataPropertyName = "Rg";
                colRg.Width = 80;
                colRg.Frozen = false;
                colRg.MinimumWidth = 80;
                colRg.ReadOnly = true;
                colRg.FillWeight = 100;
                colRg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colRg.MaxInputLength = 30;
                colRg.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colEmis = new DataGridViewTextBoxColumn();
                colEmis.Name = "OrgaoEmissor";
                colEmis.HeaderText = "Org. Emissor";
                colEmis.DataPropertyName = "OrgaoEmissor";
                colEmis.Width = 80;
                colEmis.Frozen = false;
                colEmis.MinimumWidth = 80;
                colEmis.ReadOnly = true;
                colEmis.FillWeight = 100;
                colEmis.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEmis.MaxInputLength = 30;
                colEmis.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colSexo = new DataGridViewTextBoxColumn();
                colSexo.Name = "Sexo";
                colSexo.HeaderText = "Sexo";
                colSexo.DataPropertyName = "Sexo";
                colSexo.Width = 60;
                colSexo.Frozen = false;
                colSexo.MinimumWidth = 60;
                colSexo.ReadOnly = true;
                colSexo.FillWeight = 100;
                colSexo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSexo.MaxInputLength = 30;
                colSexo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDataBatismo = new DataGridViewTextBoxColumn();
                colDataBatismo.Name = "DataBatismo";
                colDataBatismo.HeaderText = "Data Batismo";
                colDataBatismo.DataPropertyName = "DataBatismo";
                colDataBatismo.Width = 80;
                colDataBatismo.Frozen = false;
                colDataBatismo.DefaultCellStyle.Format = "dd/mm/yyyy";
                colDataBatismo.MinimumWidth = 80;
                colDataBatismo.ReadOnly = true;
                colDataBatismo.FillWeight = 100;
                colDataBatismo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDataBatismo.MaxInputLength = 200;
                colDataBatismo.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colCep = new DataGridViewTextBoxColumn();
                colCep.Name = "CepRes";
                colCep.HeaderText = "Cep Residência";
                colCep.DataPropertyName = "CepRes";
                colCep.Width = 80;
                colCep.Frozen = false;
                colCep.MinimumWidth = 80;
                colCep.ReadOnly = true;
                colCep.FillWeight = 100;
                colCep.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCep.MaxInputLength = 100;
                colCep.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colCodCidadeRes = new DataGridViewTextBoxColumn();
                colCodCidadeRes.Name = "CodCidadeRes";
                colCodCidadeRes.HeaderText = "CodCidadeRes";
                colCodCidadeRes.DataPropertyName = "CodCidadeRes";
                colCodCidadeRes.Width = 50;
                colCodCidadeRes.Frozen = false;
                colCodCidadeRes.MinimumWidth = 50;
                colCodCidadeRes.ReadOnly = true;
                colCodCidadeRes.FillWeight = 100;
                colCodCidadeRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCidadeRes.MaxInputLength = 100;
                colCodCidadeRes.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colEstRes = new DataGridViewTextBoxColumn();
                colEstRes.Name = "EstadoRes";
                colEstRes.HeaderText = "Estaso Residência";
                colEstRes.DataPropertyName = "EstadoRes";
                colEstRes.Width = 100;
                colEstRes.Frozen = false;
                colEstRes.MinimumWidth = 80;
                colEstRes.ReadOnly = true;
                colEstRes.FillWeight = 100;
                colEstRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEstRes.MaxInputLength = 100;
                colEstRes.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colCid = new DataGridViewTextBoxColumn();
                colCid.Name = "CidadeRes";
                colCid.HeaderText = "Cidade Residência";
                colCid.DataPropertyName = "CidadeRes";
                colCid.Width = 100;
                colCid.Frozen = false;
                colCid.MinimumWidth = 80;
                colCid.ReadOnly = true;
                colCid.FillWeight = 100;
                colCid.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCid.MaxInputLength = 100;
                colCid.Visible = true;
                ///7ª coluna
                DataGridViewTextBoxColumn colEndRes = new DataGridViewTextBoxColumn();
                colEndRes.Name = "EndRes";
                colEndRes.HeaderText = "End. Residência";
                colEndRes.DataPropertyName = "EndRes";
                colEndRes.Width = 100;
                colEndRes.Frozen = false;
                colEndRes.MinimumWidth = 100;
                colEndRes.ReadOnly = true;
                colEndRes.FillWeight = 100;
                colEndRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEndRes.MaxInputLength = 200;
                colEndRes.Visible = true;
                ///8ª coluna
                DataGridViewTextBoxColumn colNumRes = new DataGridViewTextBoxColumn();
                colNumRes.Name = "NumRes";
                colNumRes.HeaderText = "Nº Residência";
                colNumRes.DataPropertyName = "NumRes";
                colNumRes.Width = 50;
                colNumRes.Frozen = false;
                colNumRes.MinimumWidth = 40;
                colNumRes.ReadOnly = true;
                colNumRes.FillWeight = 100;
                colNumRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colNumRes.MaxInputLength = 20;
                colNumRes.Visible = true;
                ///8ª coluna
                DataGridViewTextBoxColumn colBairroRes = new DataGridViewTextBoxColumn();
                colBairroRes.Name = "BairroRes";
                colBairroRes.HeaderText = "Bairro Residência";
                colBairroRes.DataPropertyName = "BairroRes";
                colBairroRes.Width = 80;
                colBairroRes.Frozen = false;
                colBairroRes.MinimumWidth = 80;
                colBairroRes.ReadOnly = true;
                colBairroRes.FillWeight = 100;
                colBairroRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colBairroRes.MaxInputLength = 100;
                colBairroRes.Visible = true;
                ///8ª coluna
                DataGridViewTextBoxColumn colComplRes = new DataGridViewTextBoxColumn();
                colComplRes.Name = "ComplRes";
                colComplRes.HeaderText = "Complemento Residência";
                colComplRes.DataPropertyName = "ComplRes";
                colComplRes.Width = 100;
                colComplRes.Frozen = false;
                colComplRes.MinimumWidth = 100;
                colComplRes.ReadOnly = true;
                colComplRes.FillWeight = 100;
                colComplRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colComplRes.MaxInputLength = 200;
                colComplRes.Visible = true;
                ///9ª Coluna
                DataGridViewTextBoxColumn colTel1 = new DataGridViewTextBoxColumn();
                colTel1.Name = "Telefone1";
                colTel1.HeaderText = "Telefone 1";
                colTel1.DataPropertyName = "Telefone1";
                colTel1.Width = 80;
                colTel1.Frozen = false;
                colTel1.MinimumWidth = 80;
                colTel1.ReadOnly = true;
                colTel1.FillWeight = 100;
                colTel1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTel1.MaxInputLength = 30;
                colTel1.Visible = true;
                ///9ª Coluna
                DataGridViewTextBoxColumn colTel2 = new DataGridViewTextBoxColumn();
                colTel2.Name = "Telefone2";
                colTel2.HeaderText = "Telefone 2";
                colTel2.DataPropertyName = "Telefone2";
                colTel2.Width = 80;
                colTel2.Frozen = false;
                colTel2.MinimumWidth = 80;
                colTel2.ReadOnly = true;
                colTel2.FillWeight = 100;
                colTel2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTel2.MaxInputLength = 30;
                colTel2.Visible = true;
                ///9ª Coluna
                DataGridViewTextBoxColumn colCel1 = new DataGridViewTextBoxColumn();
                colCel1.Name = "Celular1";
                colCel1.HeaderText = "Celular 1";
                colCel1.DataPropertyName = "Celular1";
                colCel1.Width = 80;
                colCel1.Frozen = false;
                colCel1.MinimumWidth = 80;
                colCel1.ReadOnly = true;
                colCel1.FillWeight = 100;
                colCel1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCel1.MaxInputLength = 30;
                colCel1.Visible = true;
                ///9ª Coluna
                DataGridViewTextBoxColumn colCel2 = new DataGridViewTextBoxColumn();
                colCel2.Name = "Celular2";
                colCel2.HeaderText = "Celular 2";
                colCel2.DataPropertyName = "Celular2";
                colCel2.Width = 80;
                colCel2.Frozen = false;
                colCel2.MinimumWidth = 80;
                colCel2.ReadOnly = true;
                colCel2.FillWeight = 100;
                colCel2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCel2.MaxInputLength = 30;
                colCel2.Visible = true;
                ///9ª Coluna
                DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
                colEmail.Name = "Email";
                colEmail.HeaderText = "Email";
                colEmail.DataPropertyName = "Email";
                colEmail.Width = 80;
                colEmail.Frozen = false;
                colEmail.MinimumWidth = 80;
                colEmail.ReadOnly = true;
                colEmail.FillWeight = 100;
                colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEmail.MaxInputLength = 200;
                colEmail.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colCodCCB = new DataGridViewTextBoxColumn();
                colCodCCB.Name = "CodCCB";
                colCodCCB.HeaderText = "CodCCB";
                colCodCCB.DataPropertyName = "CodCCB";
                colCodCCB.Width = 50;
                colCodCCB.Frozen = false;
                colCodCCB.MinimumWidth = 50;
                colCodCCB.ReadOnly = true;
                colCodCCB.FillWeight = 100;
                colCodCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCCB.MaxInputLength = 100;
                colCodCCB.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colDescCCB = new DataGridViewTextBoxColumn();
                colDescCCB.Name = "DescCCB";
                colDescCCB.HeaderText = "Comum CCB";
                colDescCCB.DataPropertyName = "Descricao";
                colDescCCB.Width = 80;
                colDescCCB.Frozen = false;
                colDescCCB.MinimumWidth = 80;
                colDescCCB.ReadOnly = true;
                colDescCCB.FillWeight = 100;
                colDescCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescCCB.MaxInputLength = 100;
                colDescCCB.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colEstadoCivil = new DataGridViewTextBoxColumn();
                colEstadoCivil.Name = "EstadoCivil";
                colEstadoCivil.HeaderText = "Estado Civil";
                colEstadoCivil.DataPropertyName = "EstadoCivil";
                colEstadoCivil.Width = 100;
                colEstadoCivil.Frozen = false;
                colEstadoCivil.MinimumWidth = 80;
                colEstadoCivil.ReadOnly = true;
                colEstadoCivil.FillWeight = 100;
                colEstadoCivil.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEstadoCivil.MaxInputLength = 100;
                colEstadoCivil.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDataApresenta = new DataGridViewTextBoxColumn();
                colDataApresenta.Name = "DataApresentacao";
                colDataApresenta.HeaderText = "Data Apresentacao";
                colDataApresenta.DataPropertyName = "DataApresentacao";
                colDataApresenta.Width = 80;
                colDataApresenta.Frozen = false;
                colDataApresenta.DefaultCellStyle.Format = "dd/mm/yyyy";
                colDataApresenta.MinimumWidth = 80;
                colDataApresenta.ReadOnly = true;
                colDataApresenta.FillWeight = 100;
                colDataApresenta.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDataApresenta.MaxInputLength = 200;
                colDataApresenta.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colPaisCCB = new DataGridViewTextBoxColumn();
                colPaisCCB.Name = "PaisCCB";
                colPaisCCB.HeaderText = "Pais CCB";
                colPaisCCB.DataPropertyName = "PaisCCB";
                colPaisCCB.Width = 50;
                colPaisCCB.Frozen = false;
                colPaisCCB.MinimumWidth = 50;
                colPaisCCB.ReadOnly = true;
                colPaisCCB.FillWeight = 100;
                colPaisCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colPaisCCB.MaxInputLength = 200;
                colPaisCCB.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colPai = new DataGridViewTextBoxColumn();
                colPai.Name = "Pai";
                colPai.HeaderText = "Pai";
                colPai.DataPropertyName = "Pai";
                colPai.Width = 80;
                colPai.Frozen = false;
                colPai.MinimumWidth = 80;
                colPai.ReadOnly = true;
                colPai.FillWeight = 100;
                colPai.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colPai.MaxInputLength = 200;
                colPai.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colMae = new DataGridViewTextBoxColumn();
                colMae.Name = "Mae";
                colMae.HeaderText = "Mãe";
                colMae.DataPropertyName = "Mae";
                colMae.Width = 80;
                colMae.Frozen = false;
                colMae.MinimumWidth = 80;
                colMae.ReadOnly = true;
                colMae.FillWeight = 100;
                colMae.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMae.MaxInputLength = 200;
                colMae.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFormacaoFora = new DataGridViewTextBoxColumn();
                colFormacaoFora.Name = "FormacaoFora";
                colFormacaoFora.HeaderText = "Formação Fora";
                colFormacaoFora.DataPropertyName = "FormacaoFora";
                colFormacaoFora.Width = 60;
                colFormacaoFora.Frozen = false;
                colFormacaoFora.MinimumWidth = 60;
                colFormacaoFora.ReadOnly = true;
                colFormacaoFora.FillWeight = 100;
                colFormacaoFora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFormacaoFora.MaxInputLength = 200;
                colFormacaoFora.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colLocalForma = new DataGridViewTextBoxColumn();
                colLocalForma.Name = "LocalFormacao";
                colLocalForma.HeaderText = "Local Formação";
                colLocalForma.DataPropertyName = "LocalFormacao";
                colLocalForma.Width = 80;
                colLocalForma.Frozen = false;
                colLocalForma.MinimumWidth = 80;
                colLocalForma.ReadOnly = true;
                colLocalForma.FillWeight = 100;
                colLocalForma.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colLocalForma.MaxInputLength = 200;
                colLocalForma.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colQualFormacao = new DataGridViewTextBoxColumn();
                colQualFormacao.Name = "QualFormacao";
                colQualFormacao.HeaderText = "Qual Formação";
                colQualFormacao.DataPropertyName = "QualFormacao";
                colQualFormacao.Width = 60;
                colQualFormacao.Frozen = false;
                colQualFormacao.MinimumWidth = 60;
                colQualFormacao.ReadOnly = true;
                colQualFormacao.FillWeight = 100;
                colQualFormacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colQualFormacao.MaxInputLength = 200;
                colQualFormacao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colOutraOrquestra = new DataGridViewTextBoxColumn();
                colOutraOrquestra.Name = "OutraOrquestra";
                colOutraOrquestra.HeaderText = "Outra Orquestra";
                colOutraOrquestra.DataPropertyName = "OutraOrquestra";
                colOutraOrquestra.Width = 60;
                colOutraOrquestra.Frozen = false;
                colOutraOrquestra.MinimumWidth = 60;
                colOutraOrquestra.ReadOnly = true;
                colOutraOrquestra.FillWeight = 100;
                colOutraOrquestra.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colOutraOrquestra.MaxInputLength = 200;
                colOutraOrquestra.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colOrquestra1 = new DataGridViewTextBoxColumn();
                colOrquestra1.Name = "Orquestra1";
                colOrquestra1.HeaderText = "Orquestra 1";
                colOrquestra1.DataPropertyName = "Orquestra1";
                colOrquestra1.Width = 80;
                colOrquestra1.Frozen = false;
                colOrquestra1.MinimumWidth = 80;
                colOrquestra1.ReadOnly = true;
                colOrquestra1.FillWeight = 100;
                colOrquestra1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colOrquestra1.MaxInputLength = 200;
                colOrquestra1.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFuncao1 = new DataGridViewTextBoxColumn();
                colFuncao1.Name = "Funcao1";
                colFuncao1.HeaderText = "Função 1";
                colFuncao1.DataPropertyName = "Funcao1";
                colFuncao1.Width = 60;
                colFuncao1.Frozen = false;
                colFuncao1.MinimumWidth = 60;
                colFuncao1.ReadOnly = true;
                colFuncao1.FillWeight = 100;
                colFuncao1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFuncao1.MaxInputLength = 200;
                colFuncao1.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colOrquestra2 = new DataGridViewTextBoxColumn();
                colOrquestra2.Name = "Orquestra2";
                colOrquestra2.HeaderText = "Orquestra 2";
                colOrquestra2.DataPropertyName = "Orquestra2";
                colOrquestra2.Width = 80;
                colOrquestra2.Frozen = false;
                colOrquestra2.MinimumWidth = 80;
                colOrquestra2.ReadOnly = true;
                colOrquestra2.FillWeight = 100;
                colOrquestra2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colOrquestra2.MaxInputLength = 200;
                colOrquestra2.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFuncao2 = new DataGridViewTextBoxColumn();
                colFuncao2.Name = "Funcao2";
                colFuncao2.HeaderText = "Função 2";
                colFuncao2.DataPropertyName = "Funcao2";
                colFuncao2.Width = 60;
                colFuncao2.Frozen = false;
                colFuncao2.MinimumWidth = 60;
                colFuncao2.ReadOnly = true;
                colFuncao2.FillWeight = 100;
                colFuncao2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFuncao2.MaxInputLength = 200;
                colFuncao2.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colOrquestra3 = new DataGridViewTextBoxColumn();
                colOrquestra3.Name = "Orquestra3";
                colOrquestra3.HeaderText = "Orquestra 3";
                colOrquestra3.DataPropertyName = "Orquestra3";
                colOrquestra3.Width = 80;
                colOrquestra3.Frozen = false;
                colOrquestra3.MinimumWidth = 80;
                colOrquestra3.ReadOnly = true;
                colOrquestra3.FillWeight = 100;
                colOrquestra3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colOrquestra3.MaxInputLength = 200;
                colOrquestra3.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFuncao3 = new DataGridViewTextBoxColumn();
                colFuncao3.Name = "Funcao3";
                colFuncao3.HeaderText = "Função 3";
                colFuncao3.DataPropertyName = "Funcao3";
                colFuncao3.Width = 60;
                colFuncao3.Frozen = false;
                colFuncao3.MinimumWidth = 60;
                colFuncao3.ReadOnly = true;
                colFuncao3.FillWeight = 100;
                colFuncao3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFuncao3.MaxInputLength = 200;
                colFuncao3.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colCodInstr = new DataGridViewTextBoxColumn();
                colCodInstr.Name = "CodInstrumento";
                colCodInstr.HeaderText = "CodInstrumento";
                colCodInstr.DataPropertyName = "CodInstrumento";
                colCodInstr.Width = 50;
                colCodInstr.Frozen = false;
                colCodInstr.MinimumWidth = 50;
                colCodInstr.ReadOnly = true;
                colCodInstr.FillWeight = 100;
                colCodInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstr.MaxInputLength = 100;
                colCodInstr.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colDescInstr = new DataGridViewTextBoxColumn();
                colDescInstr.Name = "DescInstrumento";
                colDescInstr.HeaderText = "Instrumento";
                colDescInstr.DataPropertyName = "DescInstrumento";
                colDescInstr.Width = 80;
                colDescInstr.Frozen = false;
                colDescInstr.MinimumWidth = 80;
                colDescInstr.ReadOnly = true;
                colDescInstr.FillWeight = 100;
                colDescInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescInstr.MaxInputLength = 100;
                colDescInstr.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colDesenv = new DataGridViewTextBoxColumn();
                colDesenv.Name = "Desenvolvimento";
                colDesenv.HeaderText = "Desenvolvimento";
                colDesenv.DataPropertyName = "Desenvolvimento";
                colDesenv.Width = 80;
                colDesenv.Frozen = false;
                colDesenv.MinimumWidth = 80;
                colDesenv.ReadOnly = true;
                colDesenv.FillWeight = 100;
                colDesenv.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDesenv.MaxInputLength = 100;
                colDesenv.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colUltTeste = new DataGridViewTextBoxColumn();
                colUltTeste.Name = "DataUltimoTeste";
                colUltTeste.HeaderText = "Ultimo Teste";
                colUltTeste.DataPropertyName = "DataUltimoTeste";
                colUltTeste.Width = 60;
                colUltTeste.Frozen = false;
                colUltTeste.DefaultCellStyle.Format = "dd/mm/yyyy";
                colUltTeste.MinimumWidth = 60;
                colUltTeste.ReadOnly = true;
                colUltTeste.FillWeight = 100;
                colUltTeste.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colUltTeste.MaxInputLength = 100;
                colUltTeste.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colInicioEstudo = new DataGridViewTextBoxColumn();
                colInicioEstudo.Name = "DataInicioEstudo";
                colInicioEstudo.HeaderText = "Inicio Estudo";
                colInicioEstudo.DataPropertyName = "DataInicioEstudo";
                colInicioEstudo.Width = 60;
                colInicioEstudo.DefaultCellStyle.Format = "dd/mm/yyyy";
                colInicioEstudo.Frozen = false;
                colInicioEstudo.MinimumWidth = 60;
                colInicioEstudo.ReadOnly = true;
                colInicioEstudo.FillWeight = 100;
                colInicioEstudo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colInicioEstudo.MaxInputLength = 100;
                colInicioEstudo.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colExecutInstr = new DataGridViewTextBoxColumn();
                colExecutInstr.Name = "ExecutandoInstrumento";
                colExecutInstr.HeaderText = "Execut. Instrumento";
                colExecutInstr.DataPropertyName = "ExecutInstrumento";
                colExecutInstr.Width = 80;
                colExecutInstr.Frozen = false;
                colExecutInstr.MinimumWidth = 60;
                colExecutInstr.ReadOnly = true;
                colExecutInstr.FillWeight = 100;
                colExecutInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colExecutInstr.MaxInputLength = 100;
                colExecutInstr.Visible = true;
                ///1ª coluna
                DataGridViewTextBoxColumn colSeq = new DataGridViewTextBoxColumn();
                colSeq.DataPropertyName = "Sequencia";
                colSeq.Name = "Sequencia";
                colSeq.HeaderText = "";
                colSeq.DefaultCellStyle.ForeColor = Color.DarkGray;
                colSeq.Width = 40;
                colSeq.Frozen = false;
                colSeq.DefaultCellStyle.Format = "00000";
                colSeq.MinimumWidth = 40;
                colSeq.ReadOnly = true;
                colSeq.FillWeight = 100;
                colSeq.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSeq.MaxInputLength = 200;
                colSeq.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                gridDados.Columns.Add(colSeq);
                gridDados.Columns.Add(colAtivo);
                gridDados.Columns.Add(colCodPessoa);
                gridDados.Columns.Add(colDataCadastro);
                gridDados.Columns.Add(colHoraCadastro);
                gridDados.Columns.Add(colCodCargo);
                gridDados.Columns.Add(colDescCargo);
                gridDados.Columns.Add(colNome);
                gridDados.Columns.Add(colDataNasc);
                gridDados.Columns.Add(colCpf);
                gridDados.Columns.Add(colRg);
                gridDados.Columns.Add(colEmis);
                gridDados.Columns.Add(colSexo);
                gridDados.Columns.Add(colDataBatismo);
                gridDados.Columns.Add(colCep);
                gridDados.Columns.Add(colCid);
                gridDados.Columns.Add(colCodCidadeRes);
                gridDados.Columns.Add(colEstRes);
                gridDados.Columns.Add(colEndRes);
                gridDados.Columns.Add(colNumRes);
                gridDados.Columns.Add(colBairroRes);
                gridDados.Columns.Add(colComplRes);
                gridDados.Columns.Add(colTel1);
                gridDados.Columns.Add(colTel2);
                gridDados.Columns.Add(colCel1);
                gridDados.Columns.Add(colCel2);
                gridDados.Columns.Add(colEmail);
                gridDados.Columns.Add(colCodCCB);
                gridDados.Columns.Add(colDescCCB);
                gridDados.Columns.Add(colEstadoCivil);
                gridDados.Columns.Add(colDataApresenta);
                gridDados.Columns.Add(colPaisCCB);
                gridDados.Columns.Add(colPai);
                gridDados.Columns.Add(colMae);
                gridDados.Columns.Add(colFormacaoFora);
                gridDados.Columns.Add(colLocalForma);
                gridDados.Columns.Add(colQualFormacao);
                gridDados.Columns.Add(colOutraOrquestra);
                gridDados.Columns.Add(colOrquestra1);
                gridDados.Columns.Add(colFuncao1);
                gridDados.Columns.Add(colOrquestra2);
                gridDados.Columns.Add(colFuncao2);
                gridDados.Columns.Add(colOrquestra3);
                gridDados.Columns.Add(colFuncao3);
                gridDados.Columns.Add(colCodInstr);
                gridDados.Columns.Add(colDescInstr);
                gridDados.Columns.Add(colDesenv);
                gridDados.Columns.Add(colUltTeste);
                gridDados.Columns.Add(colInicioEstudo);
                gridDados.Columns.Add(colExecutInstr);

                gridDados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                ///feito um refresh para fazer a atualização do datagridview
                gridDados.Refresh();
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
        /// Função que carrega os dados vinculados
        /// </summary>
        /// <param name="lista"></param>
        internal void carregaDados(List<MOD_vincularCampos> lista)
        {
            try
            {

                listaDados = lista;

                formBarra = new carregBarra(gridImporta.Rows.Count);
                formBarra.Show();
                formBarra.Refresh();

                listaPessoa = new BindingList<MOD_pessoa>();
                objBind_Pessoa = new BindingSource();
                objBind_Pessoa.DataSource = listaPessoa;

                foreach (DataGridViewRow linha in gridImporta.Rows)
                {
                    gridDados.Rows.Add(1);
                    MOD_pessoa objEnt_Pessoa = new MOD_pessoa();
                    MOD_pessoa objEnt_PessoaErros = new MOD_pessoa();
                    objEnt_Pessoa.Ativo = "Sim";

                    foreach (MOD_vincularCampos ent in lista)
                    {
                        if (ent.CampoVinculado.Equals("DataCadastro"))
                        {
                            try
                            {
                                var datacadastro = string.IsNullOrEmpty(Convert.ToString(linha.Cells[ent.CampoImportado].Value)) ? null : DateTime.Parse(Convert.ToString(linha.Cells[ent.CampoImportado].Value)).ToString("dd/MM/yyyy");
                                objEnt_Pessoa.DataCadastro = datacadastro;
                            }
                            catch
                            {
                                objEnt_Pessoa.DataCadastro = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DataNasc"))
                        {
                            try
                            {
                                var datanasc = string.IsNullOrEmpty(Convert.ToString(linha.Cells[ent.CampoImportado].Value)) ? null : DateTime.Parse(Convert.ToString(linha.Cells[ent.CampoImportado].Value)).ToString("dd/MM/yyyy");
                                objEnt_Pessoa.DataNasc = datanasc;
                                //objEnt_Pessoa.DataNasc = funcoes.FormataData(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.DataNasc = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DataBatismo"))
                        {
                            try
                            {
                                var databatismo = string.IsNullOrEmpty(Convert.ToString(linha.Cells[ent.CampoImportado].Value)) ? null : DateTime.Parse(Convert.ToString(linha.Cells[ent.CampoImportado].Value)).ToString("dd/MM/yyyy");
                                objEnt_Pessoa.DataBatismo = databatismo;
                                //objEnt_Pessoa.DataBatismo = funcoes.FormataData(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.DataBatismo = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DataApresentacao"))
                        {
                            try
                            {
                                var dataapresente = string.IsNullOrEmpty(Convert.ToString(linha.Cells[ent.CampoImportado].Value)) ? null : DateTime.Parse(Convert.ToString(linha.Cells[ent.CampoImportado].Value)).ToString("dd/MM/yyyy");
                                objEnt_Pessoa.DataApresentacao = dataapresente;
                                //objEnt_Pessoa.DataApresentacao = funcoes.FormataData(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.DataApresentacao = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("HoraCadastro"))
                        {
                            try
                            {
                                var horacadastro = string.IsNullOrEmpty(Convert.ToString(linha.Cells[ent.CampoImportado].Value)) ? null : DateTime.Parse(Convert.ToString(linha.Cells[ent.CampoImportado].Value)).ToString("HH:mm");
                                objEnt_Pessoa.HoraCadastro = horacadastro;
                                //objEnt_Pessoa.HoraCadastro = funcoes.FormataHora(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.HoraCadastro = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DataUltimoTeste"))
                        {
                            try
                            {
                                var datateste = string.IsNullOrEmpty(Convert.ToString(linha.Cells[ent.CampoImportado].Value)) ? null : DateTime.Parse(Convert.ToString(linha.Cells[ent.CampoImportado].Value)).ToString("dd/MM/yyyy");
                                objEnt_Pessoa.DataUltimoTeste = datateste;
                                //objEnt_Pessoa.DataUltimoTeste = funcoes.FormataData(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.DataUltimoTeste = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DataInicioEstudo"))
                        {
                            try
                            {
                                var dataestudo = string.IsNullOrEmpty(Convert.ToString(linha.Cells[ent.CampoImportado].Value)) ? null : DateTime.Parse(Convert.ToString(linha.Cells[ent.CampoImportado].Value)).ToString("dd/MM/yyyy");
                                objEnt_Pessoa.DataInicioEstudo = dataestudo;
                                //objEnt_Pessoa.DataInicioEstudo = funcoes.FormataData(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.DataInicioEstudo = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Nome"))
                        {
                            try
                            {
                                objEnt_Pessoa.Nome = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Nome = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DescCargo"))
                        {
                            try
                            {
                                objEnt_Pessoa.DescCargo = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                                objEnt_Pessoa.CodCargo = validarCargo(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.CodCargo = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Cpf"))
                        {
                            try
                            {
                                objEnt_Pessoa.Cpf = funcoes.FormataCpf(Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.Cpf = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Rg"))
                        {
                            try
                            {
                                objEnt_Pessoa.Rg = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Rg = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("OrgaoEmissor"))
                        {
                            try
                            {
                                objEnt_Pessoa.OrgaoEmissor = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.OrgaoEmissor = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Sexo"))
                        {
                            try
                            {
                                objEnt_Pessoa.Sexo = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Sexo = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("CepRes"))
                        {
                            try
                            {
                                objEnt_Pessoa.CepRes = funcoes.FormataString("#####-###", Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                                objEnt_Pessoa.CodCidadeRes = validarCep(Convert.ToString(objEnt_Pessoa.CepRes));
                                objEnt_Pessoa.CidadeRes = DescCidade;
                            }
                            catch
                            {
                                objEnt_Pessoa.CodCidadeRes = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("CidadeRes"))
                        {
                            try
                            {
                                if (!Convert.ToString(objEnt_Pessoa.CidadeRes).ToUpper().Equals(Convert.ToString(linha.Cells[ent.CampoImportado].Value).ToUpper()))
                                {
                                    throw new Exception();
                                }
                            }
                            catch
                            {
                                objEnt_Pessoa.CidadeRes = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                                objEnt_Pessoa.CodCidadeRes = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("EndRes"))
                        {
                            try
                            {
                                objEnt_Pessoa.EndRes = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.EndRes = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("EstadoRes"))
                        {
                            try
                            {
                                objEnt_Pessoa.EstadoRes = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.EstadoRes = "Erro";
                            }
                        }

                        else if (ent.CampoVinculado.Equals("NumRes"))
                        {
                            try
                            {
                                objEnt_Pessoa.NumRes = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.NumRes = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("BairroRes"))
                        {
                            try
                            {
                                objEnt_Pessoa.BairroRes = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.BairroRes = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("ComplRes"))
                        {
                            try
                            {
                                objEnt_Pessoa.ComplRes = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.ComplRes = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Telefone1"))
                        {
                            try
                            {
                                objEnt_Pessoa.Telefone1 = funcoes.FormataString("(##) ####-####", Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.Telefone1 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Telefone2"))
                        {
                            try
                            {
                                objEnt_Pessoa.Telefone2 = funcoes.FormataString("(##) ####-####", Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.Telefone2 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Celular1"))
                        {
                            try
                            {
                                objEnt_Pessoa.Celular1 = funcoes.FormataString("(##) #####-####", Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.Celular1 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Celular2"))
                        {
                            try
                            {
                                objEnt_Pessoa.Celular2 = funcoes.FormataString("(##) #####-####", Convert.ToString(linha.Cells[ent.CampoImportado].Value));
                            }
                            catch
                            {
                                objEnt_Pessoa.Celular2 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Email"))
                        {
                            try
                            {
                                objEnt_Pessoa.Email = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Email = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DescCCB"))
                        {
                            try
                            {
                                objEnt_Pessoa.Descricao = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                                objEnt_Pessoa.CodCCB = validarCCB(Convert.ToString(objEnt_Pessoa.Descricao));
                                objEnt_Pessoa.Descricao = DescCCB;
                            }
                            catch
                            {
                                objEnt_Pessoa.CodCCB = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("EstadoCivil"))
                        {
                            try
                            {
                                objEnt_Pessoa.EstadoCivil = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.EstadoCivil = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("PaisCCB"))
                        {
                            try
                            {
                                objEnt_Pessoa.PaisCCB = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.PaisCCB = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Pai"))
                        {
                            try
                            {
                                objEnt_Pessoa.Pai = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Pai = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Mae"))
                        {
                            try
                            {
                                objEnt_Pessoa.Mae = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Mae = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("FormacaoFora"))
                        {
                            try
                            {
                                objEnt_Pessoa.FormacaoFora = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.FormacaoFora = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("LocalFormacao"))
                        {
                            try
                            {
                                objEnt_Pessoa.LocalFormacao = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.LocalFormacao = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("QualFormacao"))
                        {
                            try
                            {
                                objEnt_Pessoa.QualFormacao = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.QualFormacao = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("OutraOrquestra"))
                        {
                            try
                            {
                                objEnt_Pessoa.OutraOrquestra = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.OutraOrquestra = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Orquestra1"))
                        {
                            try
                            {
                                objEnt_Pessoa.Orquestra1 = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Orquestra1 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Funcao1"))
                        {
                            try
                            {
                                objEnt_Pessoa.Funcao1 = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Funcao1 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Orquestra2"))
                        {
                            try
                            {
                                objEnt_Pessoa.Orquestra2 = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Orquestra2 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Funcao2"))
                        {
                            try
                            {
                                objEnt_Pessoa.Funcao2 = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Funcao2 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Orquestra3"))
                        {
                            try
                            {
                                objEnt_Pessoa.Orquestra3 = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Orquestra3 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Funcao3"))
                        {
                            try
                            {
                                objEnt_Pessoa.Funcao3 = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Funcao3 = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("DescInstrumento"))
                        {
                            try
                            {
                                objEnt_Pessoa.DescInstrumento = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                                objEnt_Pessoa.CodInstrumento = validarInstrumento(objEnt_Pessoa.DescInstrumento);
                            }
                            catch
                            {
                                objEnt_Pessoa.CodInstrumento = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("Desenvolvimento"))
                        {
                            try
                            {
                                objEnt_Pessoa.Desenvolvimento = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.Desenvolvimento = "Erro";
                            }
                        }
                        else if (ent.CampoVinculado.Equals("ExecutandoInstrumento"))
                        {
                            try
                            {
                                objEnt_Pessoa.ExecutInstrumento = Convert.ToString(linha.Cells[ent.CampoImportado].Value);
                            }
                            catch
                            {
                                objEnt_Pessoa.ExecutInstrumento = "Erro";
                            }
                        }
                        else
                        {
                            try
                            {
                                gridDados.Rows[gridDados.Rows.Count - 1].Cells[ent.CampoVinculado].Value = linha.Cells[ent.CampoImportado].Value;
                                //gridDados[ent.CampoVinculado, gridDados.Rows.Count - 1].Value = linha.Cells[ent.CampoImportado].Value;
                            }
                            catch
                            {
                                gridDados.Rows[gridDados.Rows.Count - 1].Cells[ent.CampoVinculado].Value = "Erro";
                            }
                        }
                    }

                    listaPessoa.Add(objEnt_Pessoa);

                    objEnt_Pessoa.Sequencia = Convert.ToString(listaPessoa.Count).PadLeft(5, '0');

                    Thread.Sleep(20);

                    formBarra.lblContador.Text = objEnt_Pessoa.Nome;
                    formBarra.lblContador.Update();
                    formBarra.pbBarra.Value = gridDados.Rows.Count;
                    formBarra.pbBarra.Update();
                }

                objBind_Pessoa.DataSource = listaPessoa;
                montaGridDados();
                gridDados.DataSource = objBind_Pessoa;

                //No total de registros
                txtQtdeDados.Text = Convert.ToString(gridDados.Rows.Count).PadLeft(6, '0');

                formBarra.lblContador.Text = "Importação concluída com sucesso!";
                formBarra.lblContador.Update();

                Thread.Sleep(1000);
            }
            catch (SqlException exl)
            {
                MessageBox.Show(exl.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBarra.Close();
                formBarra.Dispose();
            }
        }

        /// <summary>
        /// Função que define a cor da celula com erro
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirErro(int RowIndex)
        {
            try
            {
                foreach (DataGridViewCell celula in gridDados.Rows[RowIndex].Cells)
                {
                    if (celula.Value != null)
                    {
                        if (celula.Value.Equals("Erro"))
                        {
                            celula.Style.BackColor = Color.Red;
                        }
                        else
                        {
                            celula.Style.BackColor = Color.White;
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
        /// Função que busca os dados do Cargo referente ao Código
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="Indice"></param>
        /// <returns></returns>
        internal void carregaCargo(string CodCargo, int Indice)
        {
            try
            {
                BLL_cargo objBLL_cargo = new BLL_cargo();
                List<MOD_cargo> listaCargo = new List<MOD_cargo>();

                listaCargo = objBLL_cargo.buscarCod(CodCargo);

                if (listaCargo != null && listaCargo.Count > 0)
                {
                    listaPessoa[Indice].CodCargo = listaCargo[0].CodCargo;
                    listaPessoa[Indice].DescCargo = listaCargo[0].DescCargo;

                    //Atualiza o DataGridView
                    listaPessoa.ResetItem(Indice);
                }
                else
                {
                    //abre o formulario Cargo
                    this.abrirForm("frmCargo", Indice);
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
        /// Função que busca os dados do Cargo referente a descrição
        /// </summary>
        /// <param name="DescCargo"></param>
        /// <returns></returns>
        private string validarCargo(string DescCargo)
        {
            try
            {
                BLL_cargo objBLL_cargo = new BLL_cargo();
                List<MOD_cargo> listaCargo = new List<MOD_cargo>();

                listaCargo = objBLL_cargo.buscarDescricao(DescCargo);

                if (listaCargo != null && listaCargo.Count > 0)
                {
                    CodCargo = listaCargo[0].CodCargo;
                }
                else
                {
                    throw new Exception();
                }
                return CodCargo;
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
        /// Função que busca os dados da Comum referente ao CodCCB
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="Indice"></param>
        /// <returns></returns>
        internal void carregaCCB(string CodCCB, int Indice)
        {
            try
            {
                BLL_ccb objBLL_CCB = new BLL_ccb();
                List<MOD_ccb> listaCCB = new List<MOD_ccb>();

                listaCCB = objBLL_CCB.buscarCod(CodCCB);

                if (listaCCB != null && listaCCB.Count > 0)
                {
                    listaPessoa[Indice].CodCCB = listaCCB[0].CodCCB;
                    listaPessoa[Indice].Descricao = listaCCB[0].Descricao;

                    //Atualiza o DataGridView
                    listaPessoa.ResetItem(Indice);
                }
                else
                {
                    //abre o formulario CCB
                    abrirForm("frmCCB", Indice);
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
        /// Função que busca os dados da Comum referente a descrição
        /// </summary>
        /// <param name="DescCargo"></param>
        /// <returns></returns>
        private string validarCCB(string DescComum)
        {
            try
            {
                BLL_ccb objBLL_ccb = new BLL_ccb();
                List<MOD_ccb> listaCCB = new List<MOD_ccb>();

                listaCCB = objBLL_ccb.buscarDescricao(DescComum);

                if (listaCCB != null && listaCCB.Count > 0)
                {
                    CodCCB = listaCCB[0].CodCCB;
                    DescCCB = listaCCB[0].Descricao;
                }
                else
                {
                    throw new Exception();
                }

                return CodCCB;
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
        /// Função que busca os dados do Instrumento referente ao CodInstrumento
        /// </summary>
        /// <param name="CodInstr"></param>
        /// <param name="Indice"></param>
        /// <returns></returns>
        internal void carregaInstr(string CodInstr, int Indice)
        {
            try
            {
                BLL_instrumento objBLL_Instr = new BLL_instrumento();
                List<MOD_instrumento> listaInstr = new List<MOD_instrumento>();

                listaInstr = objBLL_Instr.buscarCod(CodInstr);

                if (listaInstr != null && listaInstr.Count > 0)
                {
                    listaPessoa[Indice].CodInstrumento = listaInstr[0].CodInstrumento;
                    listaPessoa[Indice].DescInstrumento = listaInstr[0].DescInstrumento;

                    ////Atualiza o DataGridView
                    //listaPessoa.ResetItem(Indice);
                }
                else
                {
                    //abre o formulario Instrumento
                    abrirForm("frmInstr", Indice);
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
        /// Função que busca os dados do Instrumento referente a descrição
        /// </summary>
        /// <param name="DescInstrumento"></param>
        /// <returns></returns>
        private string validarInstrumento(string DescInstrumento)
        {
            try
            {
                if (DescInstrumento.Trim() != null && DescInstrumento.Trim() != "")
                {

                    BLL_instrumento objBLL_instr = new BLL_instrumento();
                    List<MOD_instrumento> listaInstr = new List<MOD_instrumento>();

                    listaInstr = objBLL_instr.buscarDescricao(DescInstrumento);


                    if (listaInstr != null && listaInstr.Count > 0)
                    {
                        CodInstr = listaInstr[0].CodInstrumento;
                        DescInstr = listaInstr[0].DescInstrumento;
                    }
                    else
                    {
                        throw new Exception();
                    }
                    return CodInstr;
                }
                else
                {
                    return null;
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
        /// Função que busca os dados da Cidade referente ao Cep
        /// </summary>
        /// <param name="CepRes"></param>
        /// <param name="Indice"></param>
        /// <returns></returns>
        internal void carregaCep(string CepRes, int Indice)
        {
            try
            {
                BLL_cidade objBLL_cep = new BLL_cidade();
                List<MOD_cidade> listaCep = new List<MOD_cidade>();

                listaCep = objBLL_cep.buscarCep(CepRes);

                if (listaCep != null && listaCep.Count > 0)
                {
                    listaPessoa[Indice].CodCidadeRes = listaCep[0].CodCidade;
                    listaPessoa[Indice].CidadeRes = listaCep[0].Cidade;
                    listaPessoa[Indice].CepRes = listaCep[0].Cep;

                    //Atualiza o DataGridView
                    listaPessoa.ResetItem(Indice);
                }
                else
                {
                    //abre o formulario Cep
                    abrirForm("frmCidade", Indice);
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
        /// Função que busca os dados da Cidade referente ao Cep informado
        /// </summary>
        /// <param name="Cep"></param>
        /// <returns></returns>
        private string validarCep(string Cep)
        {
            try
            {
                BLL_cidade objBLL_Cep = new BLL_cidade();
                List<MOD_cidade> listaCep = new List<MOD_cidade>();

                listaCep = objBLL_Cep.buscarCep(Cep);

                if (listaCep != null && listaCep.Count > 0)
                {
                    CodCidade = listaCep[0].CodCidade;
                    DescCidade = listaCep[0].Cidade;
                }
                else
                {
                    throw new Exception();
                }

                return CodCidade;
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
        /// <param name="listaReg"></param>
        internal void preencher(List<MOD_importaPessoa> listaImporta)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaImporta[0].CodImportaPessoa;
                txtDataImporta.Text = listaImporta[0].DataImporta;
                txtHoraImporta.Text = listaImporta[0].HoraImporta;
                txtCodUsuario.Text = listaImporta[0].CodUsuario;
                txtUsuario.Text = listaImporta[0].Usuario;
                txtDescricao.Text = listaImporta[0].Descricao;

                objBind_Pessoa = new BindingSource();
                objBind_Pessoa.DataSource = listaImporta[0].ListaPessoaItem;
                montaGridDados();
                gridDados.DataSource = objBind_Pessoa;

                //No total de registros
                txtQtdeDados.Text = (gridDados.Rows.Count).ToString();

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
                tabImporta.Enabled = false;
                tabImportacao.SelectedTab = tabDados;
                tabDados.Enabled = true;
                btnEditar.Enabled = false;
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
                tabImportacao.Enabled = true;
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
            txtDescricao.Focus();
        }
        /// <summary>
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineAba()
        {
            tabImportacao.SelectedTab = tabDados;

            foreach (DataGridViewRow linha in gridDados.Rows)
            {
                definirErro(Convert.ToInt32(linha.Index));
            }
        }

        #endregion

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermImp()
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão visualizar
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsImportaPessoa))
                    {
                        btnSalvar.Enabled = true;
                        break;
                    }
                    else
                    {
                        btnSalvar.Enabled = false;
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

    }
}
