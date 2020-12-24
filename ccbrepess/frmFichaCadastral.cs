using BLL.Funcoes;
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

namespace ccbrepess
{
    public partial class frmFichaCadastral : Form
    {
        public frmFichaCadastral()
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
                //preencherGrid("Cargo", string.Empty, gridCargo);
                apoio.carregaComboCargo(cboCargo, modulos.CodUsuario);
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
        string CodPessoa;

        bool blnValida;
        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;

        IBLL_buscaRelatorio objBLL_Pessoa;
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

                carregarPessoa();
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

                    carregarPessoa();
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

                carregarPessoa();
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

        private void cboCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cboCargo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando pessoas...");
                CodCargo = Convert.ToString(cboCargo.SelectedValue);

                carregarPessoa();
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

        private void btnCartao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Pesquisando dados...");
                gerarCartao();
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
        private void btnFicha_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Pesquisando dados...");
                gerarFichaCadastral();
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

                carregarPessoa();
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

                carregarPessoa();
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

                carregarPessoa();
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

                carregarPessoa();
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
        private void gridPessoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridPessoa != null || gridPessoa.RowCount > 0)
                {
                    //ao clicar na linha marca ou desmarca a primeira coluna
                    //verifica a situação da celula
                    if (gridPessoa != null || gridPessoa.RowCount > 0)
                    {
                        if (gridPessoa["Marcado", e.RowIndex].Value != null)
                        {
                            if (gridPessoa["Marcado", e.RowIndex].Value.Equals(true))
                            {
                                gridPessoa["Marcado", e.RowIndex].Value = false;
                            }
                            else
                            {
                                gridPessoa["Marcado", e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            gridPessoa["Marcado", e.RowIndex].Value = true;
                        }
                        gridPessoa.Refresh();
                        txtSelecionados.Text = Convert.ToString(pessoaSelecionada()).PadLeft(5, '0');
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
        private void btnSelPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridPessoa.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridPessoa.Refresh();

                txtSelecionados.Text = Convert.ToString(pessoaSelecionada()).PadLeft(5, '0');
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
        private void btnDesPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridPessoa.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridPessoa.Refresh();
                txtSelecionados.Text = Convert.ToString(pessoaSelecionada()).PadLeft(5, '0');
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

        private void frmFichaCadastral_Load(object sender, EventArgs e)
        {
            try
            {
                funcoes.gridPessoa(gridPessoa, "Relatorios");
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
                carregarPessoa();
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
                carregarPessoa();
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
                carregarPessoa();
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
                carregarPessoa();
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
        private void optDadosBasicos_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optDadosBasicos.Checked.Equals(true))
                {
                    lblExibeDados.Enabled = true;
                    lblExibeComp.Enabled = false;
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

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// <para> As Pesquisa são por: Regiao, Comum</para>
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
                    objBLL_Usuario = new BLL_usuario();
                    listaUsuarioCCB = objBLL_Usuario.buscarUsuarioCCB(modulos.CodUsuario, preencherSelecionados("Regiao", gridRegiao));

                    funcoes.gridCCB(dataGrid, "Relatorios");
                    dataGrid.DataSource = listaUsuarioCCB;
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
                if (optDadosBasicos.Checked.Equals(false) && optDadosCompleto.Checked.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário informar se deseja Dados básicos ou completos.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cboCargo.Text))
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
        /// Função que valida os campos
        /// </summary>
        private bool ValidarPessoa()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;
                bool blnPessoa = false;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();

                foreach (DataGridViewRow row in gridPessoa.Rows)
                {
                    if (row.Cells["Marcado"].Value != null)
                    {
                        if (row.Cells["Marcado"].Value.Equals(true))
                        {
                            blnPessoa = true;
                            break;
                        }
                    }
                }
                if (blnPessoa.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Irmão(ã) para Imprimir.";
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

                carregarPessoa();
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
            carregarPessoa();
        }

        /// <summary>
        /// Conta os registros que foram selecionados
        /// </summary>
        /// <returns></returns>
        private int pessoaSelecionada()
        {
            int Qtde = 0;
            foreach (DataGridViewRow row in gridPessoa.Rows)
            {
                if (row.Cells["Marcado"].Value != null)
                {
                    if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                    {
                        Qtde += 1;
                    }
                }
            }
            return Qtde;
        }

        #region Gerar dados para relatorio

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
                Parametro.Cargo = cboCargo.Text.ToUpper();
                Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                Parametro.RodapeRelatorio = modulos.listaParametros[0].RodapeRelatorio;
                Parametro.PulaPagina = chkPulaPagina.Checked.Equals(true) ? "Sim" : "Não";
                formulario = new frmListaPessoa(this, lista, Parametro);
                ((frmListaPessoa)formulario).ShowDialog();
                ((frmListaPessoa)formulario).Dispose();
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
        /// Função que carrega os dados da pessoa no Grid
        /// </summary>
        private void carregarPessoa()
        {
            try
            {
                if (!string.IsNullOrEmpty(CodComum) && !string.IsNullOrEmpty(CodCargo))
                {

                    if (ValidarControles().Equals(true))
                    {
                        CodCargo = Convert.ToInt64(cboCargo.SelectedValue).ToString();
                        CodComum = preencherSelecionados("Comum", gridComum);

                        objBLL_Pessoa = new BLL_buscaRelatorioPessoa();
                        if (lblStatus.Text.Equals("Ambos"))
                        {
                            listaPessoa = objBLL_Pessoa.Buscar(lblSexo.Text, lblEstadoCivil.Text, CodCargo, CodComum);
                        }
                        else
                        {
                            listaPessoa = objBLL_Pessoa.Buscar(lblSexo.Text, lblEstadoCivil.Text, CodCargo, CodComum, lblStatus.Text.Equals("Sim") ? true : false);
                        }

                        listaPessoa = listaPessoa.OrderBy(p => p.Descricao).ToList();

                        funcoes.gridPessoa(gridPessoa, "Relatorios");
                        gridPessoa.DataSource = listaPessoa;
                        txtQtdeRegistro.Text = Convert.ToString(gridPessoa.RowCount).PadLeft(5, '0');
                    }
                    else
                    {
                        funcoes.gridPessoa(gridPessoa, "Relatorios");
                        txtQtdeRegistro.Text = Convert.ToString(gridPessoa.RowCount).PadLeft(5, '0');
                    }
                }
                else
                {
                    funcoes.gridPessoa(gridPessoa, "Relatorios");
                    txtQtdeRegistro.Text = Convert.ToString(gridPessoa.RowCount).PadLeft(5, '0');
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
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void gerarFichaCadastral()
        {
            try
            {
                if (ValidarPessoa().Equals(true))
                {

                    List<MOD_pessoa> listaPessoaFiltro = new List<MOD_pessoa>();
                    List<MOD_pessoa> listaPessoaRelatorio = new List<MOD_pessoa>();

                    foreach (DataGridViewRow row in gridPessoa.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;

                                Codigo = row.Cells["CodPessoa"].Value.ToString();
                                listaPessoaFiltro = listaPessoa.Where(p => p.CodPessoa.Equals(Codigo)).ToList();
                                listaPessoaRelatorio.AddRange(listaPessoaFiltro);
                            }
                        }
                    }

                    listaPessoaRelatorio = listaPessoaRelatorio.OrderBy(p => p.Nome).ToList();

                    if (optDadosBasicos.Checked.Equals(true))
                    {
                        string NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa_Basico.rdlc";
                        abrirForm(listaPessoaRelatorio, NomeRelatorio);
                    }
                    else
                    {
                        string NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa.rdlc";
                        abrirForm(listaPessoaRelatorio, NomeRelatorio);
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
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void gerarCartao()
        {
            try
            {
                if (ValidarPessoa().Equals(true))
                {
                    List<MOD_pessoa> listaPessoaFiltro = new List<MOD_pessoa>();
                    List<MOD_pessoa> listaPessoaRelatorio = new List<MOD_pessoa>();

                    foreach (DataGridViewRow row in gridPessoa.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;

                                Codigo = row.Cells["CodPessoa"].Value.ToString();
                                listaPessoaFiltro = listaPessoa.Where(p => p.CodPessoa.Equals(Codigo)).ToList();
                                listaPessoaRelatorio.AddRange(listaPessoaFiltro);
                            }
                        }
                    }

                    listaPessoaRelatorio = listaPessoaRelatorio.OrderBy(p => p.Nome).ToList();

                    string NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa_Cartao.rdlc";
                    abrirForm(listaPessoaRelatorio, NomeRelatorio);
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