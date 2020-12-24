using BLL.administracao;
using BLL.Funcoes;
using BLL.pessoa;
using BLL.Usuario;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ccbadm;
using ENT.acessos;
using ENT.administracao;
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

namespace ccbadm.relatorios
{
    public partial class frmMixListaReuniao : Form
    {
        public frmMixListaReuniao(Form forms, List<MOD_reuniaoMinisterio> lista)
        {
            InitializeComponent();

            try
            {
                formChama = forms;

                //Carrega os dados da Reunião
                preencheReuniao(lista);

                ///preenche o comboRegional
                apoio.carregaComboRegional(cboRegional);
                //Carrega as Regiões e Comuns
                preencherGrid("Regiao", Convert.ToString(cboRegional.SelectedValue), gridRegiao);
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
        string CodRegiao;
        string CodRegional;
        string CodCargo;

        bool blnValida;
        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        
        BLL_listaPresenca objBLL_Presenca;
        List<MOD_listaPresenca> listaPresenca = new List<MOD_listaPresenca>();

        List<MOD_ccb> listaCCB = new List<MOD_ccb>();

        BLL_usuario objBLL_Usuario;
        BindingList<MOD_usuarioCCB> listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();
        List<MOD_usuarioCargo> listaUsuarioCargo = new List<MOD_usuarioCargo>();

        BLL_regiaoAtuacao objBLL_Regiao;
        List<MOD_regiaoAtuacao> listaRegiao = new List<MOD_regiaoAtuacao>();
        List<MOD_regional> listaRegional = new List<MOD_regional>();
        BindingList<MOD_usuarioRegiao> listaUsuarioRegiao = new BindingList<MOD_usuarioRegiao>();

        List<MOD_cargo> listaCargo = new List<MOD_cargo>();

        Form formulario;
        Form formChama;

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

        private void frmMixListaReuniao_Load(object sender, EventArgs e)
        {
            try
            {

                //chama a funcão montar grid
                new BLL_GridCargo().MontarGrid(gridCargo, string.Empty);

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
        private void frmMixListaReuniao_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
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

        private void optAgruRegiao_CheckedChanged(object sender, EventArgs e)
        {
            if (optAgruRegiao.Checked.Equals(true))
            {
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
                chkAgruCargo.Enabled = true;
            }
            else
            {
                chkAgruComum.Checked = false;
                chkAgruComum.Enabled = false;
                chkAgruFamilia.Checked = false;
                chkAgruFamilia.Enabled = false;
                chkAgruCargo.Checked = false;
                chkAgruCargo.Enabled = false;
            }
        }
        private void optAgruCargo_CheckedChanged(object sender, EventArgs e)
        {
            if (optAgruCargo.Checked.Equals(true))
            {
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
                chkAgruCargo.Checked = false;
                chkAgruCargo.Enabled = false;
            }
            else
            {
                chkAgruComum.Checked = false;
                chkAgruComum.Enabled = false;
                chkAgruFamilia.Checked = false;
                chkAgruFamilia.Enabled = false;
                chkAgruCargo.Checked = false;
                chkAgruCargo.Enabled = false;
            }
        }
        private void optAgruInstr_CheckedChanged(object sender, EventArgs e)
        {
            if (optAgruInstr.Checked.Equals(true))
            {
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
                chkAgruCargo.Enabled = true;
            }
            else
            {
                chkAgruComum.Checked = false;
                chkAgruComum.Enabled = false;
                chkAgruFamilia.Checked = false;
                chkAgruFamilia.Enabled = false;
                chkAgruCargo.Checked = false;
                chkAgruCargo.Enabled = false;
            }
        }

        private void optSintetico_CheckedChanged(object sender, EventArgs e)
        {
            verificacoes();
        }
        private void optAnalitico_CheckedChanged(object sender, EventArgs e)
        {
            verificacoes();
        }

        private void chkExibeAusente_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExibeAusente.Checked.Equals(true))
            {
                if (optAnalitico.Checked.Equals(true))
                {
                    chkPulaPagina.Enabled = true;
                }
                else
                {
                    chkPulaPagina.Checked = false;
                    chkPulaPagina.Enabled = false;
                }
            }
            else
            {
                chkPulaPagina.Checked = false;
                chkPulaPagina.Enabled = false;
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
                    objBLL_Usuario = new BLL_usuario();
                    listaUsuarioRegiao = objBLL_Usuario.buscarUsuarioRegiao(modulos.CodUsuario, Campo1);

                    funcoes.gridRegiao(dataGrid, "Relatorios");
                    dataGrid.DataSource = listaUsuarioRegiao;
                    dataGrid.DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (Pesquisa.Equals("Cargo"))
                {
                    BLL_tipoReuniao objBLL_Tipo = new BLL_tipoReuniao();
                    listaUsuarioCargo = new List<MOD_usuarioCargo>();
                    listaUsuarioCargo = objBLL_Tipo.buscarUsuarioCargo(lblTipo.Text, modulos.CodUsuario);

                    dataGrid.DataSource = listaUsuarioCargo;
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
                bool blnRegiao = false;
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

                foreach (DataGridViewRow row in gridRegiao.Rows)
                {
                    if (row.Cells["Marcado"].Value != null)
                    {
                        if (row.Cells["Marcado"].Value.Equals(true))
                        {
                            blnRegiao = true;
                            break;
                        }
                    }
                }
                if (blnRegiao.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar uma Microrregião.";
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
        private void abrirForm(List<MOD_listaPresenca> lista, List<MOD_totalListaPresenca> listaTotal, string NomeRelatorio)
        {
            try
            {
                apoio.Aguarde("Carregando relatório...");
                MOD_paramRelatorio Parametro = new MOD_paramRelatorio();
                Parametro.NomeRelatorio = NomeRelatorio;
                Parametro.PulaPagina = chkPulaPagina.Checked.Equals(true) ? "Sim" : "Não";
                Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                Parametro.RodapeRelatorio = modulos.listaParametros[0].RodapeRelatorio;
                Parametro.TipoRelatorio = optSintetico.Checked.Equals(true) ? "Sintético" : "Analítico";
                Parametro.ExibeDetalhe = optSintetico.Checked.Equals(true) ? "Não" : "Sim";
                Parametro.ExibeResumo = chkExibeResumo.Checked.Equals(true) ? "Sim" : "Não";
                Parametro.ExibeAusente = chkExibeAusente.Checked.Equals(true) ? "Sim" : "Não";

                formulario = new frmListaReuniao(this, lista, listaTotal, Parametro);
                ((frmListaReuniao)formulario).ShowDialog();
                ((frmListaReuniao)formulario).Dispose();
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

                if (Pesquisa.Equals("Regiao"))
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
        /// Sub que preenche os dados da Reunião
        /// </summary>
        private void preencheReuniao(List<MOD_reuniaoMinisterio> lista)
        {
            txtCodReuniao.Text = lista[0].CodReuniao;
            txtDataReuniao.Text = lista[0].DataReuniao;
            txtHoraReuniao.Text = lista[0].HoraReuniao;
            lblTipo.Text = lista[0].CodTipoReuniao;
            txtTipo.Text = lista[0].DescTipoReuniao;
            txtLocal.Text = lista[0].CodigoCCB + " - " + lista[0].DescricaoCCB;
        }

        #region Gerar dados para relatorio

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void gerarRelatorio()
        {
            try
            {
                apoio.Aguarde("Carregando presentes...");
                if (ValidarControles().Equals(true))
                {
                    CodCargo = preencherSelecionados("Cargo", gridCargo);
                    CodRegiao = preencherSelecionados("Regiao", gridRegiao);

                    string NomeRelatorio = null;

                    List<MOD_listaPresenca> listaAusente = new List<MOD_listaPresenca>();
                    List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
                    List<MOD_totalListaPresenca> listaTotal = new List<MOD_totalListaPresenca>();

                    objBLL_Presenca = new BLL_listaPresenca();
                    listaPresenca = objBLL_Presenca.buscarRelatorioPresentes(txtCodReuniao.Text, lblSexo.Text, CodCargo, CodRegiao);

                    //Verifica se a caixa exibir ausente está marcada
                    if (chkExibeAusente.Checked.Equals(true))
                    {
                        apoio.FecharAguarde();
                        apoio.Aguarde("Carregando ausentes...");
                        objBLL_Presenca = new BLL_listaPresenca();
                        listaPessoa = objBLL_Presenca.buscarRelatorioAusente(txtCodReuniao.Text, lblSexo.Text, CodCargo, CodRegiao);

                        foreach (MOD_pessoa entPessoa in listaPessoa)
                        {

                            MOD_listaPresenca ent = new MOD_listaPresenca();

                            ent.CodListaPresenca = "0";
                            ent.CodPessoa = entPessoa.CodPessoa;
                            ent.Nome = entPessoa.Nome;
                            ent.CodCCBPessoa = entPessoa.CodCCB;
                            ent.CodigoCCBPessoa = entPessoa.CodigoCCB;
                            ent.DescricaoCCBPessoa = entPessoa.Descricao;
                            ent.CodCargo = entPessoa.CodCargo;
                            ent.DescCargo = entPessoa.DescCargo;
                            ent.SiglaCargo = entPessoa.SiglaCargo;
                            ent.Ordem = entPessoa.OrdemCargo;
                            ent.CodInstrumento = entPessoa.CodInstrumento;
                            ent.DescInstrumento = entPessoa.DescInstrumento;
                            ent.CodFamilia = entPessoa.CodFamilia;
                            ent.DescFamilia = entPessoa.DescFamilia;
                            ent.CodCidadeCCBPessoa = entPessoa.CodCidadeCCB;
                            ent.CidadeCCBPessoa = entPessoa.CidadeCCB;
                            ent.CodRegiaoPessoa = entPessoa.CodRegiaoCCB;
                            ent.DescricaoRegiaoPessoa = entPessoa.DescRegiaoCCB;
                            ent.Sexo = entPessoa.Sexo;
                            ent.Feminino = entPessoa.Feminino;
                            ent.Masculino = entPessoa.Masculino;
                            ent.Presente = false;

                            listaAusente.Add(ent);

                        }

                        listaPresenca.AddRange(listaAusente);

                    }

                    ///Listagem Agrupada pela Comum
                    if (optAgruRegiao.Checked.Equals(true))
                    {
                        if (chkAgruComum.Checked.Equals(true))
                        {
                            if (chkAgruFamilia.Checked.Equals(true))
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg_Com_Fam_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg_Com_Fam.rdlc";
                                }
                            }
                            else
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg_Com_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg_Com.rdlc";
                                }
                            }
                        }
                        else
                        {
                            if (chkAgruFamilia.Checked.Equals(true))
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg_Fam_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg_Fam.rdlc";
                                }
                            }
                            else
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Reg.rdlc";
                                }
                            }
                        }
                        listaTotal = preencherTotalRegiao(listaPresenca);
                    }
                    ///Listagem Agrupada pelo Cargo
                    else if (optAgruCargo.Checked.Equals(true))
                    {
                        if (chkAgruComum.Checked.Equals(true))
                        {
                            if (chkAgruFamilia.Checked.Equals(true))
                            {
                                NomeRelatorio = "ccbadm.relatorios.rptReuniao_Cargo_Com_Fam.rdlc";
                            }
                            else
                            {
                                NomeRelatorio = "ccbadm.relatorios.rptReuniao_Cargo_Com.rdlc";
                            }
                        }
                        else
                        {
                            if (chkAgruFamilia.Checked.Equals(true))
                            {
                                NomeRelatorio = "ccbadm.relatorios.rptReuniao_Cargo_Fam.rdlc";
                            }
                            else
                            {
                                NomeRelatorio = "ccbadm.relatorios.rptReuniao_Cargo.rdlc";
                            }
                        }
                        listaTotal = preencherTotalCargo(listaPresenca);
                    }
                    ///Listagem Agrupada pelo Instrumento
                    else if (optAgruInstr.Checked.Equals(true))
                    {
                        if (chkAgruComum.Checked.Equals(true))
                        {
                            if (chkAgruFamilia.Checked.Equals(true))
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr_Com_Fam_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr_Com_Fam.rdlc";
                                }
                            }
                            else
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr_Com_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr_Com.rdlc";
                                }
                            }
                        }
                        else
                        {
                            if (chkAgruFamilia.Checked.Equals(true))
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr_Fam_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr_Cargo.rdlc";
                                }
                            }
                            else
                            {
                                if (chkAgruCargo.Checked.Equals(true))
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr_Cargo.rdlc";
                                }
                                else
                                {
                                    NomeRelatorio = "ccbadm.relatorios.rptReuniao_Instr.rdlc";
                                }
                            }
                        }
                    }
                    apoio.FecharAguarde();
                    abrirForm(listaPresenca, listaTotal, NomeRelatorio);
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
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaPresenca"></param>
        internal List<MOD_totalListaPresenca> preencherTotalCargo(List<MOD_listaPresenca> listaPresenca)
        {
            try
            {
                List<MOD_totalListaPresenca> listaTotal = new List<MOD_totalListaPresenca>();
                List<MOD_totalListaPresenca> listaNova = new List<MOD_totalListaPresenca>();

                BLL_tipoReuniao objBLL_tipoReuniao = new BLL_tipoReuniao();
                List<MOD_tipoReuniaoCargo> listaCargosPermitidos = new List<MOD_tipoReuniaoCargo>();

                listaCargosPermitidos = objBLL_tipoReuniao.buscarTipoReuniaoCargo(listaPresenca[0].CodTipoReuniao);

                foreach (MOD_tipoReuniaoCargo entCargo in listaCargosPermitidos)
                {
                    MOD_totalListaPresenca ent = new MOD_totalListaPresenca();

                    ent.CodCargo = entCargo.CodCargo;
                    ent.DescCargo = entCargo.DescCargo;
                    ent.OrdemCargo = entCargo.Ordem;
                    ent.SiglaCargo = entCargo.SiglaCargo;
                    ent.Masculino = entCargo.Masculino;
                    ent.Feminino = entCargo.Feminino;

                    listaTotal.Add(ent);
                }

                //Buscar os registros que estão com os cargos permitidos acima... 
                //Tanto os da tabela lista presenca, quanto os da tabela Pessoas
                foreach (MOD_totalListaPresenca entTotal in listaTotal)
                {

                    if (entTotal.Masculino.Equals("Sim"))
                    {
                        //Calcula o Total de irmãos presente ref esse cargo
                        entTotal.QtdePresenteMasc = listaPresenca.Count(p => p.CodCargo.Equals(entTotal.CodCargo) && p.Presente.Equals(true) && p.Sexo.Equals("Masculino"));
                        //Calcula o Total de irmãos Totais que constam na base ref esse cargo
                        entTotal.QtdeTotalMasc = listaPresenca.Count(p => p.CodCargo.Equals(entTotal.CodCargo) && p.Sexo.Equals("Masculino"));

                        entTotal.QtdeAusenteMasc = entTotal.QtdeTotalMasc - entTotal.QtdePresenteMasc;

                        if (!entTotal.QtdeTotalMasc.Equals(0))
                        {
                            entTotal.PercTotalMasc = entTotal.QtdeTotalMasc / entTotal.QtdeTotalMasc;
                            entTotal.PercPresenteMasc = entTotal.QtdePresenteMasc / entTotal.QtdeTotalMasc;
                            entTotal.PercAusenteMasc = entTotal.QtdeAusenteMasc / entTotal.QtdeTotalMasc;
                        }
                    }

                    if (entTotal.Feminino.Equals("Sim"))
                    {
                        //Calcula o Total de irmãs presente ref esse cargo
                        entTotal.QtdePresenteFem = listaPresenca.Count(p => p.CodCargo.Equals(entTotal.CodCargo) && p.Presente.Equals(true) && p.Sexo.Equals("Feminino"));
                        //Calcula o Total de irmãs Totais que constam na base ref esse cargo
                        entTotal.QtdeTotalFem = listaPresenca.Count(p => p.CodCargo.Equals(entTotal.CodCargo) && p.Sexo.Equals("Feminino"));

                        entTotal.QtdeAusenteFem = entTotal.QtdeTotalFem - entTotal.QtdePresenteFem;

                        if (!entTotal.QtdeTotalFem.Equals(0))
                        {
                            entTotal.PercTotalFem = entTotal.QtdeTotalFem / entTotal.QtdeTotalFem;
                            entTotal.PercPresenteFem = entTotal.QtdePresenteFem / entTotal.QtdeTotalFem;
                            entTotal.PercAusenteFem = entTotal.QtdeAusenteFem / entTotal.QtdeTotalFem;
                        }
                    }

                    listaNova.Add(entTotal);
                }

                return listaNova;
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
        /// <param name="listaPresenca"></param>
        internal List<MOD_totalListaPresenca> preencherTotalRegiao(List<MOD_listaPresenca> listaPresenca)
        {
            try
            {
                List<MOD_totalListaPresenca> listaTotal = new List<MOD_totalListaPresenca>();
                List<MOD_totalListaPresenca> listaNova = new List<MOD_totalListaPresenca>();

                //BLL_regiaoAtuacao objBLL_tipoRegiao = new BLL_regiaoAtuacao();
                //List<MOD_tipoReuniaoCargo> listaCargosPermitidos = new List<MOD_tipoReuniaoCargo>();

                //listaCargosPermitidos = objBLL_tipoReuniao.buscarTipoReuniaoCargo(listaPresenca[0].CodTipoReuniao);

                foreach (DataGridViewRow row in gridRegiao.Rows)
                {
                    if (row.Cells["Marcado"].Value != null)
                    {
                        if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                        {
                            MOD_totalListaPresenca ent = new MOD_totalListaPresenca();

                            ent.CodRegiao = Convert.ToString(row.Cells["CodRegiao"].Value);
                            ent.DescRegiao = Convert.ToString(row.Cells["Descricao"].Value);

                            listaTotal.Add(ent);
                        }
                    }
                }

                //Buscar os registros que estão com os cargos permitidos acima... 
                //Tanto os da tabela lista presenca, quanto os da tabela Pessoas
                foreach (MOD_totalListaPresenca entTotal in listaTotal)
                {

                    //Calcula o Total de irmãos presente ref esse cargo
                    entTotal.QtdePresenteMasc = listaPresenca.Count(p => p.CodRegiaoPessoa.Equals(entTotal.CodRegiao) && p.Presente.Equals(true) && p.Sexo.Equals("Masculino"));
                    //Calcula o Total de irmãos Totais que constam na base ref esse cargo
                    entTotal.QtdeTotalMasc = listaPresenca.Count(p => p.CodRegiaoPessoa.Equals(entTotal.CodRegiao) && p.Sexo.Equals("Masculino"));

                    entTotal.QtdeAusenteMasc = entTotal.QtdeTotalMasc - entTotal.QtdePresenteMasc;

                    if (!entTotal.QtdeTotalMasc.Equals(0))
                    {
                        entTotal.PercTotalMasc = entTotal.QtdeTotalMasc / entTotal.QtdeTotalMasc;
                        entTotal.PercPresenteMasc = entTotal.QtdePresenteMasc / entTotal.QtdeTotalMasc;
                        entTotal.PercAusenteMasc = entTotal.QtdeAusenteMasc / entTotal.QtdeTotalMasc;
                    }
                    //Calcula o Total de irmãs presente ref esse cargo
                    entTotal.QtdePresenteFem = listaPresenca.Count(p => p.CodRegiaoPessoa.Equals(entTotal.CodRegiao) && p.Presente.Equals(true) && p.Sexo.Equals("Feminino"));
                    //Calcula o Total de irmãs Totais que constam na base ref esse cargo
                    entTotal.QtdeTotalFem = listaPresenca.Count(p => p.CodRegiaoPessoa.Equals(entTotal.CodRegiao) && p.Sexo.Equals("Feminino"));

                    entTotal.QtdeAusenteFem = entTotal.QtdeTotalFem - entTotal.QtdePresenteFem;

                    if (!entTotal.QtdeTotalFem.Equals(0))
                    {
                        entTotal.PercTotalFem = entTotal.QtdeTotalFem / entTotal.QtdeTotalFem;
                        entTotal.PercPresenteFem = entTotal.QtdePresenteFem / entTotal.QtdeTotalFem;
                        entTotal.PercAusenteFem = entTotal.QtdeAusenteFem / entTotal.QtdeTotalFem;
                    }

                    listaNova.Add(entTotal);
                }

                return listaNova;
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
                gpoAgrupar.Enabled = true;
                optAgruRegiao.Checked = true;
                chkAgruComum.Checked = false;
                chkAgruCargo.Checked = false;
                chkAgruFamilia.Checked = false;
                chkAgruComum.Enabled = true;
                chkAgruCargo.Enabled = true;
                chkAgruFamilia.Enabled = true;
                gpoAdicionais.Enabled = true;
                chkPulaPagina.Checked = false;
                chkPulaPagina.Enabled = false;
                chkExibeResumo.Checked = false;
                chkExibeResumo.Enabled = true;
                chkExibeAusente.Checked = false;
                chkExibeAusente.Enabled = true;
            }
            else
            {
                gpoAgrupar.Enabled = true;
                optAgruRegiao.Checked = true;
                chkAgruComum.Enabled = true;
                chkAgruFamilia.Enabled = true;
                chkAgruCargo.Enabled = true;
                chkAgruComum.Checked = false;
                chkAgruCargo.Checked = false;
                chkAgruFamilia.Checked = false;
                gpoAdicionais.Enabled = true;
                chkPulaPagina.Checked = false;
                chkPulaPagina.Enabled = true;
                chkExibeResumo.Checked = false;
                chkExibeResumo.Enabled = true;
                chkExibeAusente.Checked = false;
                chkExibeAusente.Enabled = true;
                chkPulaPagina.Checked = false;
                chkPulaPagina.Enabled = false;
            }
        }

        #endregion

        #endregion

    }
}