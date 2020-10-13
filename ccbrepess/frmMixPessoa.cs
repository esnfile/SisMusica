using BLL.Funcoes;
using BLL.pessoa;
using BLL.Usuario;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ccbpessra;
using ccbpessrs;
using ENT.acessos;
using ENT.Erros;
using ENT.pessoa;
using ENT.relatorio;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccbrepess
{
    public partial class frmMixPessoa : Form
    {
        public frmMixPessoa()
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

                //Faz as verificações para marcar os options
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
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
            Close();
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

        private void frmMixPessoa_Load(object sender, EventArgs e)
        {
            try
            {

                //funcoes.gridRegiao(gridRegiao, "VisaoOrquestral");
                //funcoes.gridCCB(gridComComum, "VisaoOrquestral");

                //verificar permissão de acesso
                //verPermVisao();
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
        private void chkFeminino_CheckedChanged(object sender, EventArgs e)
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
        private void chkAtivo_CheckedChanged(object sender, EventArgs e)
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
        private void chkInativo_CheckedChanged(object sender, EventArgs e)
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
        private void chkSolteiro_CheckedChanged(object sender, EventArgs e)
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
        private void chkViuvo_CheckedChanged(object sender, EventArgs e)
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
        private void chkCasado_CheckedChanged(object sender, EventArgs e)
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
        private void chkDivorciado_CheckedChanged(object sender, EventArgs e)
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

        private void optAgruRegiao_CheckedChanged(object sender, EventArgs e)
        {
            if (optAgruRegiao.Checked.Equals(true))
            {
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
                chkAgruDesenv.Enabled = true;
            }
            else
            {
                chkAgruComum.Checked = false;
                chkAgruComum.Enabled = false;
                chkAgruFamilia.Checked = false;
                chkAgruFamilia.Enabled = false;
                chkAgruDesenv.Checked = false;
                chkAgruDesenv.Enabled = false;
            }
        }
        private void optAgruCidade_CheckedChanged(object sender, EventArgs e)
        {
            if (optAgruCidade.Checked.Equals(true))
            {
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
                chkAgruDesenv.Enabled = true;
            }
            else
            {
                chkAgruComum.Checked = false;
                chkAgruComum.Enabled = false;
                chkAgruFamilia.Checked = false;
                chkAgruFamilia.Enabled = false;
                chkAgruDesenv.Checked = false;
                chkAgruDesenv.Enabled = false;
            }
        }
        private void optAgruCargo_CheckedChanged(object sender, EventArgs e)
        {
            if (optAgruCargo.Checked.Equals(true))
            {
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
            }
            else
            {
                chkAgruComum.Checked = false;
                chkAgruComum.Enabled = false;
                chkAgruFamilia.Checked = false;
                chkAgruFamilia.Enabled = false;
                chkAgruDesenv.Checked = false;
                chkAgruDesenv.Enabled = false;
            }
        }
        private void optAgruInstr_CheckedChanged(object sender, EventArgs e)
        {
            if (optAgruInstr.Checked.Equals(true))
            {
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
                chkAgruDesenv.Enabled = true;
            }
            else
            {
                chkAgruComum.Checked = false;
                chkAgruComum.Enabled = false;
                chkAgruFamilia.Checked = false;
                chkAgruFamilia.Enabled = false;
                chkAgruDesenv.Checked = false;
                chkAgruDesenv.Enabled = false;
            }
        }

        private void optOrdemComum_CheckedChanged(object sender, EventArgs e)
        {
            verificacoes();
        }
        private void optOrdemCodigo_CheckedChanged(object sender, EventArgs e)
        {
            verificacoes();
        }
        private void optOrdemNome_CheckedChanged(object sender, EventArgs e)
        {
            verificacoes();
        }
        private void optSintetico_CheckedChanged(object sender, EventArgs e)
        {
            verificacoes();
        }
        private void optAnalitico_CheckedChanged(object sender, EventArgs e)
        {
            verificacoes();
        }

        private void chkExibeDetalhe_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExibeDetalhe.Checked.Equals(true))
            {
                chkPulaPagina.Enabled = true;
            }
            else
            {
                chkPulaPagina.Enabled = false;
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

        #endregion

        #region funções privadas e publicas

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
                if (Convert.ToInt32(funcoes.DataInt(txtDataInicial.Text)) > Convert.ToInt32(funcoes.DataInt(txtDataFinal.Text)))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Data Inicial deve ser menor do que a Data Final.";
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
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(List<MOD_pessoa> lista, string NomeRelatorio)
        {
            try
            {
                MOD_paramRelatorio Parametro = new MOD_paramRelatorio();
                Parametro.NomeRelatorio = NomeRelatorio;
                Parametro.DataInicial = txtDataInicial.Text;
                Parametro.DataFinal = txtDataFinal.Text;
                Parametro.TipoData = optDataApresenta.Checked.Equals(true) ? "Data Apresentação" : optDataCadastro.Checked.Equals(true) ? "Data Cadastro" : "Data Nascimento";
                Parametro.PulaPagina = chkPulaPagina.Checked.Equals(true) ? "Sim" : "Não";
                Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                Parametro.RodapeRelatorio = modulos.listaParametros[0].RodapeRelatorio;
                Parametro.ExibeDetalhe = chkExibeDetalhe.Checked.Equals(true) ? "Sim" : "Não";

                //formulario = new frmListaPessoa(this, lista, Parametro);
                //((frmListaPessoa)formulario).ShowDialog();
                //((frmListaPessoa)formulario).Dispose();

                if (optSintetico.Checked.Equals(true))
                {
                    formulario = new frmListaPessoaSint(this, lista, Parametro);
                    ((frmListaPessoaSint)formulario).ShowDialog();
                    ((frmListaPessoaSint)formulario).Dispose();
                }
                else
                {
                    formulario = new frmListaPessoaAnalit(this, lista, Parametro);
                    ((frmListaPessoaAnalit)formulario).ShowDialog();
                    ((frmListaPessoaAnalit)formulario).Dispose();
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
            string Codigo = string.Empty;

            lblEstadoCivil.Text = string.Empty;

            foreach (string ent in civil)
            {
                if (!string.IsNullOrEmpty(ent))
                {
                    if (string.IsNullOrEmpty(lblEstadoCivil.Text))
                    {
                        Codigo = ent;
                    }
                    else
                    {
                        Codigo = Codigo + "','" + ent;
                    }
                    lblEstadoCivil.Text = Codigo;
                }
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
                        listaPessoa = objBLL_Pessoa.buscarRelatorioPessoa(lblSexo.Text, lblEstadoCivil.Text, CodCargo, CodComum, optDataCadastro.Checked.Equals(true) ? "DataCadastro" : optDataNasc.Checked.Equals(true) ? "DataNasc" : "DataApresentacao", txtDataInicial.Text, txtDataFinal.Text);
                    }
                    else
                    {
                        listaPessoa = objBLL_Pessoa.buscarRelatorioPessoa(lblSexo.Text, lblEstadoCivil.Text, CodCargo, CodComum, lblStatus.Text.Equals("Sim") ? true : false, optDataCadastro.Checked.Equals(true) ? "DataCadastro" : optDataNasc.Checked.Equals(true) ? "DataNasc" : "DataApresentacao", txtDataInicial.Text, txtDataFinal.Text);
                    }

                    if (optAnalitico.Checked.Equals(true))
                    {
                        List<MOD_pessoa> listaOrdem = new List<MOD_pessoa>();

                        ///Listagem Ordenada pelo Código
                        if (optOrdemCodigo.Checked.Equals(true))
                        {
                            listaOrdem = listaPessoa.OrderBy(p => p.CodPessoa).ToList();

                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Codigo.rdlc";
                            abrirForm(listaOrdem, NomeRelatorio);
                        }
                        ///Listagem Ordenada pelo Nome
                        else if (optOrdemNome.Checked.Equals(true))
                        {
                            listaOrdem = listaPessoa.OrderBy(p => p.Nome).ToList();
                            ///Listagem Agrupada pela Comum
                            if (optAgruRegiao.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg_Com_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg_Com_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg_Com_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg_Com.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Reg.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                            }
                            ///Listagem Agrupada pela Cidade
                            else if (optAgruCidade.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid_Com_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid_Com_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid_Com_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid_Com.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cid.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                            }
                            ///Listagem Agrupada pelo Cargo
                            else if (optAgruCargo.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cargo_Com_Fam.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                    else
                                    {
                                        string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cargo_Com.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cargo_Fam.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                    else
                                    {
                                        string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Cargo.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                }
                            }
                            ///Listagem Agrupada pelo Instrumento
                            else if (optAgruInstr.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr_Com_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr_Com_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr_Com_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr_Com.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessra.relatorios.rptListaPessoa_Anal_Instr.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        List<MOD_pessoa> listaOrdem = new List<MOD_pessoa>();
                        ///Listagem Ordenada pelo Código
                        if (optOrdemCodigo.Checked.Equals(true))
                        {
                            listaOrdem = listaPessoa.OrderBy(p => p.CodPessoa).ToList();

                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Codigo.rdlc";
                            abrirForm(listaOrdem, NomeRelatorio);
                        }
                        ///Listagem Ordenada pelo Nome
                        else if (optOrdemNome.Checked.Equals(true))
                        {
                            listaOrdem = listaPessoa.OrderBy(p => p.Descricao).ThenBy(c => c.Nome).ToList();

                            ///Listagem Agrupada pela Comum
                            if (optAgruRegiao.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg_Com_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg_Com_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg_Com_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg_Com.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Reg.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                            }
                            ///Listagem Agrupada pela Cidade
                            else if (optAgruCidade.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid_Com_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid_Com_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid_Com_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid_Com.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cid.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                            }
                            ///Listagem Agrupada pelo Cargo
                            else if (optAgruCargo.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cargo_Com_Fam.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                    else
                                    {
                                        string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cargo_Com.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cargo_Fam.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                    else
                                    {
                                        string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Cargo.rdlc";
                                        abrirForm(listaOrdem, NomeRelatorio);
                                    }
                                }
                            }
                            ///Listagem Agrupada pelo Instrumento
                            else if (optAgruInstr.Checked.Equals(true))
                            {
                                if (chkAgruComum.Checked.Equals(true))
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr_Com_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr_Com_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr_Com_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr_Com.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                                else
                                {
                                    if (chkAgruFamilia.Checked.Equals(true))
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr_Fam_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr_Fam.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                    else
                                    {
                                        if (chkAgruDesenv.Checked.Equals(true))
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr_Desenv.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                        else
                                        {
                                            string NomeRelatorio = "ccbpessrs.relatorios.rptListaPessoa_Sint_Instr.rdlc";
                                            abrirForm(listaOrdem, NomeRelatorio);
                                        }
                                    }
                                }
                            }
                        }
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
        /// Função que verifica os buttons e os checksboxes clicados para habilitar ou desabilitar funçoes
        /// </summary>
        private void verificacoes()
        {
            if (optSintetico.Checked.Equals(true))
            {
                if (optOrdemCodigo.Checked.Equals(true))
                {
                    gpoAgrupar.Enabled = false;
                    chkAgruComum.Checked = false;
                    chkAgruDesenv.Checked = false;
                    chkAgruFamilia.Checked = false;
                    chkAgruComum.Enabled = false;
                    chkAgruDesenv.Enabled = false;
                    chkAgruFamilia.Enabled = false;
                    gpoAdicionais.Enabled = false;
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = false;
                    chkExibeDetalhe.Checked = false;
                    chkExibeDetalhe.Enabled = false;
                }
                else if (optOrdemNome.Checked.Equals(true))
                {
                    gpoAgrupar.Enabled = true;
                    optAgruRegiao.Checked = true;
                    chkAgruComum.Checked = false;
                    chkAgruDesenv.Checked = false;
                    chkAgruFamilia.Checked = false;
                    chkAgruComum.Enabled = true;
                    chkAgruDesenv.Enabled = true;
                    chkAgruFamilia.Enabled = true;
                    gpoAdicionais.Enabled = true;
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = false;
                    chkExibeDetalhe.Checked = false;
                    chkExibeDetalhe.Enabled = true;
                }
                else
                {
                    gpoAgrupar.Enabled = false;
                    chkAgruComum.Checked = false;
                    chkAgruDesenv.Checked = false;
                    chkAgruFamilia.Checked = false;
                    chkAgruComum.Enabled = false;
                    chkAgruDesenv.Enabled = false;
                    chkAgruFamilia.Enabled = false;
                    gpoAdicionais.Enabled = false;
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = false;
                    chkExibeDetalhe.Checked = false;
                    chkExibeDetalhe.Enabled = false;
                }
            }
            else if (optAnalitico.Checked.Equals(true))
            {
                if (optOrdemCodigo.Checked.Equals(true))
                {
                    gpoAgrupar.Enabled = false;
                    chkAgruComum.Checked = false;
                    chkAgruDesenv.Checked = false;
                    chkAgruFamilia.Checked = false;
                    chkAgruComum.Enabled = false;
                    chkAgruDesenv.Enabled = false;
                    chkAgruFamilia.Enabled = false;
                    gpoAdicionais.Enabled = false;
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = false;
                    chkExibeDetalhe.Checked = false;
                    chkExibeDetalhe.Enabled = false;
                }
                else if (optOrdemNome.Checked.Equals(true))
                {
                    gpoAgrupar.Enabled = true;
                    optAgruRegiao.Checked = true;
                    chkAgruComum.Enabled = true;
                    chkAgruFamilia.Enabled = true;
                    chkAgruDesenv.Enabled = true;
                    chkAgruComum.Checked = false;
                    chkAgruDesenv.Checked = false;
                    chkAgruFamilia.Checked = false;
                    gpoAdicionais.Enabled = true;
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = true;
                    chkExibeDetalhe.Checked = false;
                    chkExibeDetalhe.Enabled = false;
                }
                else
                {
                    gpoAgrupar.Enabled = false;
                    chkAgruComum.Checked = false;
                    chkAgruDesenv.Checked = false;
                    chkAgruFamilia.Checked = false;
                    chkAgruComum.Enabled = false;
                    chkAgruDesenv.Enabled = false;
                    chkAgruFamilia.Enabled = false;
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = false;
                    gpoAdicionais.Enabled = false;
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = false;
                    chkExibeDetalhe.Checked = false;
                    chkExibeDetalhe.Enabled = false;
                }
            }
        }

        #endregion

        #endregion

    }
}