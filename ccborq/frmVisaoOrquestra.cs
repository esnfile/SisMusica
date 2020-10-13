using BLL.Funcoes;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using borq;
using ENT.acessos;
using ENT.Erros;
using ENT.instrumentos;
using ENT.orquestra;
using ENT.pessoa;
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


namespace ccborq
{
    public partial class frmVisaoOrquestra : Form
    {
        public frmVisaoOrquestra(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();

            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;

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

        #region declarações

        //variaveis
        string CodComComum;
        string CodRegiao;
        string CodRegional;
        string CodCidade;
        string Estado;
        string CodCidComum;

        string CodVoz;
        string CodFamilia;
        string CodInstrumento;

        bool blnValida;
        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;

        BLL_visaoOrquestral objBLL = null;
        List<MOD_ccb> listaCidCCB = new List<MOD_ccb>();
        List<MOD_ccb> listaComCCB = new List<MOD_ccb>();
        List<MOD_regiaoAtuacao> listaRegiao = new List<MOD_regiaoAtuacao>();
        List<MOD_regional> listaRegional = new List<MOD_regional>();
        List<MOD_cidade> listaCidade = new List<MOD_cidade>();
        List<MOD_uf> listaEstado = new List<MOD_uf>();

        List<MOD_familia> listaFamilia = new List<MOD_familia>();
        List<MOD_voz> listaVoz = new List<MOD_voz>();
        List<MOD_instrumentoVozPrincipal> listaInstrumento = new List<MOD_instrumentoVozPrincipal>();

        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        Form formulario;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        private void tabLocalidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabLocalidade.SelectedTab.Equals(tabComum))
                {
                    preencherGrid("Regional", string.Empty, string.Empty, gridRegional);
                }
                else if (tabLocalidade.SelectedTab.Equals(tabCidade))
                {
                    preencherGrid("Estado", string.Empty, string.Empty, gridEstado);
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

        #region Eventos Aba Região

        private void gridRegional_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridRegional != null || gridRegional.RowCount > 0)
                {
                    CodRegional = gridRegional["CodRegional", gridRegional.CurrentRow.Index].Value.ToString();
                    preencherGrid("Regiao", CodRegional, string.Empty, gridRegiao);
                    preencherGrid("ComComum", string.Empty, string.Empty, gridComComum);
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
                    preencherGrid("ComComum", CodRegiao, string.Empty, gridComComum);
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
        private void gridComComum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridComComum != null || gridComComum.RowCount > 0)
                {
                    if (gridComComum["Marcado", e.RowIndex].Value != null)
                    {
                        if (gridComComum["Marcado", e.RowIndex].Value.Equals(true))
                        {
                            gridComComum["Marcado", e.RowIndex].Value = false;
                        }
                        else
                        {
                            gridComComum["Marcado", e.RowIndex].Value = true;
                        }
                    }
                    else
                    {
                        gridComComum["Marcado", e.RowIndex].Value = true;
                    }
                    gridComComum.Refresh();
                }
                    CodComComum = preencherSelecionados("ComComum", gridComComum);
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
                preencherGrid("ComComum", CodRegiao, string.Empty, gridComComum);
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
                preencherGrid("ComComum", CodRegiao, string.Empty, gridComComum);
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
        private void btnSelComComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridComComum.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridComComum.Refresh();

                CodComComum = preencherSelecionados("ComComum", gridComComum);
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
        private void btnDesComComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridComComum.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridComComum.Refresh();

                CodComComum = preencherSelecionados("ComComum", gridComComum);
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

        #region Eventos Aba Cidade

        private void gridEstado_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridEstado != null || gridEstado.RowCount > 0)
                {
                    Estado = gridEstado["Sigla", gridEstado.CurrentRow.Index].Value.ToString();
                    preencherGrid("Cidade", Estado, string.Empty, gridCidade);
                    preencherGrid("CidComum", string.Empty, string.Empty, gridCidComum);
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

        private void gridCidade_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridCidade != null || gridCidade.RowCount > 0)
                {
                    //ao clicar na linha marca ou desmarca a primeira coluna
                    //verifica a situação da celula
                    if (gridCidade != null || gridCidade.RowCount > 0)
                    {
                        if (gridCidade["Marcado", e.RowIndex].Value != null)
                        {
                            if (gridCidade["Marcado", e.RowIndex].Value.Equals(true))
                            {
                                gridCidade["Marcado", e.RowIndex].Value = false;
                            }
                            else
                            {
                                gridCidade["Marcado", e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            gridCidade["Marcado", e.RowIndex].Value = true;
                        }
                        gridCidade.Refresh();
                    }

                    CodCidade = preencherSelecionados("Cidade", gridCidade);
                    preencherGrid("CidComum", CodCidade, string.Empty, gridCidComum);
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
        private void gridCidComum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridCidComum != null || gridCidComum.RowCount > 0)
                {
                    if (gridCidComum["Marcado", e.RowIndex].Value != null)
                    {
                        if (gridCidComum["Marcado", e.RowIndex].Value.Equals(true))
                        {
                            gridCidComum["Marcado", e.RowIndex].Value = false;
                        }
                        else
                        {
                            gridCidComum["Marcado", e.RowIndex].Value = true;
                        }
                    }
                    else
                    {
                        gridCidComum["Marcado", e.RowIndex].Value = true;
                    }
                    gridCidComum.Refresh();
                }
                CodCidComum = preencherSelecionados("CidComum", gridCidComum);
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
        private void btnSelCidade_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridCidade.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridCidade.Refresh();

                CodCidade = preencherSelecionados("Cidade", gridCidade);
                preencherGrid("CidComum", CodCidade, string.Empty, gridCidComum);
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
        private void btnDesCidade_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridCidade.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridCidade.Refresh();

                CodCidade = preencherSelecionados("Cidade", gridCidade);
                preencherGrid("CidComum", CodCidade, string.Empty, gridCidComum);
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
        private void btnSelCidComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridCidComum.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridCidComum.Refresh();

                CodCidComum = preencherSelecionados("CidComum", gridCidComum);
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
        private void btnDesCidComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridCidComum.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridCidComum.Refresh();

                CodCidComum = preencherSelecionados("CidComum", gridCidComum);
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

        private void gridVoz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridVoz != null || gridVoz.RowCount > 0)
                {
                    //ao clicar na linha marca ou desmarca a primeira coluna
                    //verifica a situação da celula
                    if (gridVoz != null || gridVoz.RowCount > 0)
                    {
                        if (gridVoz["Marcado", e.RowIndex].Value != null)
                        {
                            if (gridVoz["Marcado", e.RowIndex].Value.Equals(true))
                            {
                                gridVoz["Marcado", e.RowIndex].Value = false;
                            }
                            else
                            {
                                gridVoz["Marcado", e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            gridVoz["Marcado", e.RowIndex].Value = true;
                        }
                        gridVoz.Refresh();
                    }

                    CodVoz = preencherSelecionados("Voz", gridVoz);
                    preencherGrid("Instrumento", CodVoz, CodFamilia, gridInstrumento);
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
        private void gridFamilia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridFamilia != null || gridFamilia.RowCount > 0)
                {
                    //ao clicar na linha marca ou desmarca a primeira coluna
                    //verifica a situação da celula
                    if (gridFamilia != null || gridFamilia.RowCount > 0)
                    {
                        if (gridFamilia["Marcado", e.RowIndex].Value != null)
                        {
                            if (gridFamilia["Marcado", e.RowIndex].Value.Equals(true))
                            {
                                gridFamilia["Marcado", e.RowIndex].Value = false;
                            }
                            else
                            {
                                gridFamilia["Marcado", e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            gridFamilia["Marcado", e.RowIndex].Value = true;
                        }
                        gridFamilia.Refresh();
                    }

                    CodFamilia = preencherSelecionados("Familia", gridFamilia);
                    preencherGrid("Instrumento", CodVoz, CodFamilia, gridInstrumento);
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
        private void gridInstrumento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridInstrumento != null || gridInstrumento.RowCount > 0)
                {
                    //ao clicar na linha marca ou desmarca a primeira coluna
                    //verifica a situação da celula
                    if (gridInstrumento != null || gridInstrumento.RowCount > 0)
                    {
                        if (gridInstrumento["Marcado", e.RowIndex].Value != null)
                        {
                            if (gridInstrumento["Marcado", e.RowIndex].Value.Equals(true))
                            {
                                gridInstrumento["Marcado", e.RowIndex].Value = false;
                            }
                            else
                            {
                                gridInstrumento["Marcado", e.RowIndex].Value = true;
                            }
                        }
                        else
                        {
                            gridInstrumento["Marcado", e.RowIndex].Value = true;
                        }
                        gridInstrumento.Refresh();
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
        private void btnSelFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridFamilia.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridFamilia.Refresh();

                CodFamilia = preencherSelecionados("Familia", gridFamilia);
                preencherGrid("Instrumento", CodVoz, CodFamilia, gridInstrumento);
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
        private void btnDesFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridFamilia.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridFamilia.Refresh();

                CodFamilia = preencherSelecionados("Familia", gridFamilia);
                preencherGrid("Instrumento", CodVoz, CodFamilia, gridInstrumento);
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
        private void btnSelVoz_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridVoz.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridVoz.Refresh();

                CodVoz = preencherSelecionados("Voz", gridVoz);
                preencherGrid("Instrumento", CodVoz, CodFamilia, gridInstrumento);
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
        private void btnDesVoz_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridVoz.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridVoz.Refresh();

                CodVoz = preencherSelecionados("Voz", gridVoz);
                preencherGrid("Instrumento", CodVoz, CodFamilia, gridInstrumento);
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
        private void btnSelInstrumento_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridInstrumento.Rows)
                {
                    row.Cells["Marcado"].Value = true;
                }
                gridInstrumento.Refresh();

                CodInstrumento = preencherSelecionados("Instrumento", gridInstrumento);
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
        private void btnDesInstrumento_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (DataGridViewRow row in gridInstrumento.Rows)
                {
                    row.Cells["Marcado"].Value = false;
                }
                gridInstrumento.Refresh();

                CodInstrumento = preencherSelecionados("Instrumento", gridInstrumento);
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
        private void btnProcessar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                gerarResultados();
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
        private void cboFamFamilia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                preencherGridFamInstrumento(cboFamFamilia.Text, listaPessoa);
                preencherGrafFamilia(cboFamFamilia.Text, listaPessoa);
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

        private void frmVisaoOrquestra_Load(object sender, EventArgs e)
        {
            try
            {

                //Preenche as Regionais
                preencherGrid("Regional", string.Empty, string.Empty, gridRegional);
                preencherGrid("Familia", string.Empty, string.Empty, gridFamilia);
                preencherGrid("Voz", string.Empty, string.Empty, gridVoz);
                preencherGrid("Instrumento", string.Empty, string.Empty, gridInstrumento);

                tabResultado.Enabled = false;
                //funcoes.gridRegiao(gridRegiao, "VisaoOrquestral");
                //funcoes.gridCCB(gridComComum, "VisaoOrquestral");

                //verificar permissão de acesso
                verPermVisao();
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

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// <para> AS Pesquisa são por: Regional, Regiao, ComComum, Estado, Cidade, CidComum, Voz, Familia, Instrumento</para>
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="DataGrid"></param>
        internal void carregaGrid(string Pesquisa, string Campo1, string Campo2, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("Regional"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaRegional = objBLL.buscarRegional(Campo1);
                    funcoes.gridRegional(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaRegional;
                }
                else if (Pesquisa.Equals("Regiao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaRegiao = objBLL.buscarRegiao(Campo1);
                    funcoes.gridRegiao(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaRegiao;
                }
                else if (Pesquisa.Equals("ComComum"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaComCCB = objBLL.buscarCCBRegiao(Campo1);
                    funcoes.gridCCB(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaComCCB;
                }
                else if (Pesquisa.Equals("Estado"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaEstado = objBLL.buscarUf(Campo1);
                    funcoes.gridUf(dataGrid);
                    dataGrid.DataSource = listaEstado;
                }
                else if (Pesquisa.Equals("Cidade"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaCidade = objBLL.buscarMunicipios(Campo1);
                    funcoes.gridCidade(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaCidade;
                }
                else if (Pesquisa.Equals("CidComum"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaCidCCB = objBLL.buscarCCBCidade(Campo1);
                    funcoes.gridCCB(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaCidCCB;
                }
                else if (Pesquisa.Equals("Voz"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaVoz = objBLL.buscarVozes(Campo1);
                    funcoes.gridVozes(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaVoz;
                }
                else if (Pesquisa.Equals("Familia"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaFamilia = objBLL.buscarFamilia(Campo1);
                    funcoes.gridFamilia(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaFamilia;
                }
                else if (Pesquisa.Equals("Instrumento"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_visaoOrquestral();
                    listaInstrumento = objBLL.buscarInstrumentos(Campo1, Campo2);
                    funcoes.gridInstrumentos(dataGrid, "VisaoOrquestral");
                    dataGrid.DataSource = listaInstrumento;
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
                bool blnInstrumento = false;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();

                foreach (DataGridViewRow row in gridInstrumento.Rows)
                {
                    if (row.Cells["Marcado"].Value != null)
                    {
                        if (row.Cells["Marcado"].Value.Equals(true))
                        {
                            blnInstrumento = true;
                            break;
                        }
                    }
                }

                if (blnInstrumento.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Instrumento.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                if (tabLocalidade.SelectedTab.Equals(tabComum))
                {
                    foreach (DataGridViewRow row in gridComComum.Rows)
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
                }
                else if (tabLocalidade.SelectedTab.Equals(tabCidade))
                {
                    foreach (DataGridViewRow row in gridCidComum.Rows)
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
        private void abrirForm(string form, DataGridView dataGrid)
        {
            try
            {
                //preencher(CodComum);
                //formulario = new frmEscala(this, dataGrid, lista);
                //((frmVozes)formulario).MdiParent = MdiParent;
                //((frmVozes)formulario).StartPosition = FormStartPosition.Manual;
                //apoio.CentralizarForm(((frmVozes)formulario));
                //((frmVozes)formulario).Show();
                //((frmVozes)formulario).BringToFront();
                //Enabled = false;
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
        internal void preencherGrid(string Pesquisa, string Campo1, string Campo2, DataGridView dataGrid)
        {
            try
            {
                apoio.Aguarde();

                if (Pesquisa.Equals("Regional"))
                {
                    gridRegional.SelectionChanged -= new EventHandler(gridRegional_SelectionChanged);

                    carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);

                    gridRegional.SelectionChanged += new EventHandler(gridRegional_SelectionChanged);
                }
                else if (Pesquisa.Equals("Regiao"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                        CodRegiao = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridRegiao(dataGrid, "VisaoOrquestral");
                    }
                }
                else if (Pesquisa.Equals("ComComum"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                        CodComComum = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridCCB(dataGrid, "VisaoOrquestral");
                    }
                }
                else if (Pesquisa.Equals("Estado"))
                {
                    carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                }
                else if (Pesquisa.Equals("Cidade"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                        CodCidade = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridCCB(dataGrid, "VisaoOrquestral");
                    }
                }
                else if (Pesquisa.Equals("CidComum"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                        CodCidComum = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridCCB(dataGrid, "VisaoOrquestral");
                    }
                }
                else if (Pesquisa.Equals("Voz"))
                {
                    carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                    CodVoz = preencherSelecionados(Pesquisa, dataGrid);
                }
                else if (Pesquisa.Equals("Familia"))
                {
                    carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                    CodFamilia = preencherSelecionados(Pesquisa, dataGrid);
                }
                else if (Pesquisa.Equals("Instrumento"))
                {
                    if (!string.IsNullOrEmpty(Campo1) && !string.IsNullOrEmpty(Campo2))
                    {
                        carregaGrid(Pesquisa, Campo1, Campo2, dataGrid);
                        CodInstrumento = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridInstrumentos(dataGrid, "VisaoOrquestral");
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

                if (Pesquisa.Equals("ComComum"))
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
                else if (Pesquisa.Equals("Regional"))
                {
                    string vCodRegional = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.SelectedRows)
                    {
                        string Codigo = string.Empty;
                        if (vCodRegional.Equals(string.Empty))
                        {
                            Codigo = Convert.ToInt32(row.Cells["CodRegional"].Value).ToString();
                        }
                        else
                        {
                            Codigo = vCodRegional + "," + Convert.ToInt32(row.Cells["CodRegional"].Value).ToString();
                        }
                        vCodRegional = Codigo;
                    }
                    RetornoSelecao = vCodRegional;
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
                else if (Pesquisa.Equals("Estado"))
                {
                    string vCodEstado = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.SelectedRows)
                    {
                        string Codigo = string.Empty;
                        if (vCodEstado.Equals(string.Empty))
                        {
                            Codigo = Convert.ToString(row.Cells["Sigla"].Value).ToString();
                        }
                        else
                        {
                            Codigo = vCodEstado + "','" + Convert.ToString(row.Cells["Sigla"].Value).ToString();
                        }
                        vCodEstado = Codigo;
                    }
                    RetornoSelecao = vCodEstado;
                }
                else if (Pesquisa.Equals("Cidade"))
                {
                    string vCodCidade = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodCidade.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToString(row.Cells["Cidade"].Value);
                                }
                                else
                                {
                                    Codigo = vCodCidade + "','" + Convert.ToString(row.Cells["Cidade"].Value);
                                }
                                vCodCidade = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodCidade;
                }
                else if (Pesquisa.Equals("CidComum"))
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
                else if (Pesquisa.Equals("Voz"))
                {
                    string vCodVoz = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodVoz.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodVoz"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodVoz + "," + Convert.ToInt32(row.Cells["CodVoz"].Value).ToString();
                                }
                                vCodVoz = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodVoz;
                }
                else if (Pesquisa.Equals("Familia"))
                {
                    string vCodFamilia = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodFamilia.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodFamilia"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodFamilia + "," + Convert.ToInt32(row.Cells["CodFamilia"].Value).ToString();
                                }
                                vCodFamilia = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodFamilia;
                }
                else if (Pesquisa.Equals("Instrumento"))
                {
                    string vCodInst = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodInst.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodInstrumento"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodInst + "," + Convert.ToInt32(row.Cells["CodInstrumento"].Value).ToString();
                                }
                                vCodInst = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodInst;
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermVisao()
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotProcVisaoOrq))
                    {
                        btnProcessar.Enabled = true;
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

        #region Aba Resultados

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void gerarResultados()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    CodInstrumento = preencherSelecionados("Instrumento", gridInstrumento);

                    if (tabLocalidade.SelectedTab.Equals(tabComum))
                    {
                        CodComComum = preencherSelecionados("ComComum", gridComComum);
                        listaPessoa = objBLL.buscarVisaoOrquestral(CodInstrumento, CodComComum, true);
                    }
                    else if (tabLocalidade.SelectedTab.Equals(tabCidade))
                    {
                        CodCidComum = preencherSelecionados("CidComum", gridCidComum);
                        listaPessoa = objBLL.buscarVisaoOrquestral(CodInstrumento, CodCidComum, true);
                    }

                    cboFamFamilia.Text = "Todas";
                    preencherGridFamInstrumento("Todas", listaPessoa);
                    preencherGrafFamilia("Todas", listaPessoa);

                    tabResultado.Enabled = true;
                    tabVisao.SelectTab(tabResultado);
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

        ///<summary> Montar DataGrid Familia Instrumentos
        ///</summary>
        private void criarGridFamInstrumento(DataGridView dataGrid)
        {
            try
            {
                dataGrid.AutoGenerateColumns = false;
                dataGrid.DataSource = null;
                dataGrid.Columns.Clear();
                dataGrid.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = false;
                ///1ª coluna
                DataGridViewTextBoxColumn colCodInstrumento = new DataGridViewTextBoxColumn();
                colCodInstrumento.HeaderText = "Código";
                colCodInstrumento.Name = "CodInstrumento";
                colCodInstrumento.DataPropertyName = "CodInstrumento";
                colCodInstrumento.Width = 55;
                colCodInstrumento.Frozen = false;
                colCodInstrumento.MinimumWidth = 55;
                colCodInstrumento.ReadOnly = true;
                colCodInstrumento.FillWeight = 100;
                colCodInstrumento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodInstrumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrumento.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.HeaderText = "Instrumento";
                colDescricao.Name = "DescInstrumento";
                colDescricao.DataPropertyName = "DescInstrumento";
                colDescricao.Width = 250;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colCodFam = new DataGridViewTextBoxColumn();
                colCodFam.HeaderText = "Família";
                colCodFam.Name = "CodFamilia";
                colCodFam.DataPropertyName = "CodFamilia";
                colCodFam.Width = 100;
                colCodFam.Frozen = false;
                colCodFam.MinimumWidth = 70;
                colCodFam.ReadOnly = true;
                colCodFam.FillWeight = 100;
                colCodFam.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodFam.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodFam.MaxInputLength = 100;
                colCodFam.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colFamilia = new DataGridViewTextBoxColumn();
                colFamilia.HeaderText = "Família";
                colFamilia.Name = "DescFamilia";
                colFamilia.DataPropertyName = "DescFamilia";
                colFamilia.Width = 70;
                colFamilia.Frozen = false;
                colFamilia.MinimumWidth = 50;
                colFamilia.ReadOnly = true;
                colFamilia.FillWeight = 100;
                colFamilia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colFamilia.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFamilia.MaxInputLength = 100;
                colFamilia.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
                colTotal.HeaderText = "Total";
                colTotal.Name = "Total";
                colTotal.DataPropertyName = "TotalInstrumentos";
                colTotal.Width = 70;
                colTotal.Frozen = false;
                colTotal.MinimumWidth = 50;
                colTotal.ReadOnly = true;
                colTotal.FillWeight = 100;
                colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTotal.MaxInputLength = 100;
                colTotal.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colCodFam);
                dataGrid.Columns.Add(colFamilia);
                dataGrid.Columns.Add(colCodInstrumento);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colTotal);

                ///feito um refresh para fazer a atualização do datagridview
                dataGrid.Refresh();
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
        internal void preencherGridFamInstrumento(string Familia, List<MOD_pessoa> listaPes)
        {
            try
            {
                List<MOD_visaoOrquestral> listaCordas = new List<MOD_visaoOrquestral>();
                List<MOD_visaoOrquestral> listaMadeiras = new List<MOD_visaoOrquestral>();
                List<MOD_visaoOrquestral> listaMetais = new List<MOD_visaoOrquestral>();

                List<MOD_visaoOrquestral> listaGridFamInstrumento = new List<MOD_visaoOrquestral>();

                List<MOD_pessoa> listaSoprano = new List<MOD_pessoa>();
                List<MOD_pessoa> listaContralto = new List<MOD_pessoa>();
                List<MOD_pessoa> listaTenor = new List<MOD_pessoa>();
                List<MOD_pessoa> listaBaixo = new List<MOD_pessoa>();
                
                if (Familia.Equals("Todas"))
                {
                    listaCordas = agrupaFamInstrumento("Cordas", listaPes);
                    listaMadeiras = agrupaFamInstrumento("Madeiras", listaPes);
                    listaMetais = agrupaFamInstrumento("Metais", listaPes);

                    listaGridFamInstrumento.AddRange(listaCordas);
                    listaGridFamInstrumento.AddRange(listaMadeiras);
                    listaGridFamInstrumento.AddRange(listaMetais);

                }
                else if (Familia.Equals("Cordas"))
                {
                    listaCordas = agrupaFamInstrumento(Familia, listaPes);
                    listaGridFamInstrumento.AddRange(listaCordas);
                }
                else if (Familia.Equals("Madeiras"))
                {
                    listaMadeiras = agrupaFamInstrumento(Familia, listaPes);
                    listaGridFamInstrumento.AddRange(listaMadeiras);
                }
                else if (Familia.Equals("Metais"))
                {
                    listaMetais = agrupaFamInstrumento(Familia, listaPes);
                    listaGridFamInstrumento.AddRange(listaMetais);
                }

                criarGridFamInstrumento(gridFamInstrumento);
                gridFamInstrumento.DataSource = listaGridFamInstrumento;
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
        internal void preencherGrafFamilia(string Familia, List<MOD_pessoa> listaPes)
        {
            try
            {
                List<MOD_visaoOrquestral> listaCordasGraf = new List<MOD_visaoOrquestral>();
                List<MOD_visaoOrquestral> listaMadeirasGraf = new List<MOD_visaoOrquestral>();
                List<MOD_visaoOrquestral> listaMetaisGraf = new List<MOD_visaoOrquestral>();

                List<MOD_visaoOrquestral> listaGrafFamilia = new List<MOD_visaoOrquestral>();

                List<MOD_pessoa> listaSoprano = new List<MOD_pessoa>();
                List<MOD_pessoa> listaContralto = new List<MOD_pessoa>();
                List<MOD_pessoa> listaTenor = new List<MOD_pessoa>();
                List<MOD_pessoa> listaBaixo = new List<MOD_pessoa>();

                if (Familia.Equals("Todas"))
                {
                    listaCordasGraf = agrupaGrafFamilia("Cordas", listaPes);
                    listaMadeirasGraf = agrupaGrafFamilia("Madeiras", listaPes);
                    listaMetaisGraf = agrupaGrafFamilia("Metais", listaPes);

                    listaGrafFamilia.AddRange(listaCordasGraf);
                    listaGrafFamilia.AddRange(listaMadeirasGraf);
                    listaGrafFamilia.AddRange(listaMetaisGraf);
                }
                else if (Familia.Equals("Cordas"))
                {
                    listaCordasGraf = agrupaGrafFamilia(Familia, listaPes);
                    listaGrafFamilia.AddRange(listaCordasGraf);
                }
                else if (Familia.Equals("Madeiras"))
                {
                    listaMadeirasGraf = agrupaGrafFamilia(Familia, listaPes);
                    listaGrafFamilia.AddRange(listaMadeirasGraf);
                }
                else if (Familia.Equals("Metais"))
                {
                    listaMetaisGraf = agrupaGrafFamilia(Familia, listaPes);
                    listaGrafFamilia.AddRange(listaMetaisGraf);
                }

                txtFamCordas.Text = "0000";
                txtFamMadeiras.Text = "0000";
                txtFamMetais.Text = "0000";

                if (listaCordasGraf != null && listaCordasGraf.Count > 0)
                {
                    txtFamCordas.Text = Convert.ToString(listaCordasGraf[0].TotalInstrumentos).PadLeft(4, '0');
                }
                if (listaMadeirasGraf != null && listaMadeirasGraf.Count > 0)
                {
                    txtFamMadeiras.Text = Convert.ToString(listaMadeirasGraf[0].TotalInstrumentos).PadLeft(4, '0');
                }
                if (listaMetaisGraf != null && listaMetaisGraf.Count > 0)
                {
                    txtFamMetais.Text = Convert.ToString(listaMetaisGraf[0].TotalInstrumentos).PadLeft(4, '0');
                }

                chtFamilia.Titles.Clear();
                chtFamilia.Titles.Add("(%) Comparativo Famílias");
                chtFamilia.DataSource = listaGrafFamilia;
                chtFamilia.Legends["Familia"].BackColor = Color.Transparent;
                chtFamilia.Legends["Familia"].ForeColor = Color.Black;
                chtFamilia.Series["Familia"].Label = "#PERCENT";
                chtFamilia.Series["Familia"].LegendText = "#AXISLABEL";
                chtFamilia.Series["Familia"].LabelForeColor = Color.Black;
                chtFamilia.Series["Familia"].BorderColor = Color.White;
                chtFamilia.Series["Familia"].XValueMember = "DescFamilia";
                chtFamilia.Series["Familia"].YValueMembers = "TotalInstrumentos";
                chtFamilia.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
                chtFamilia.PaletteCustomColors = new Color[] { Color.LightBlue, Color.DeepSkyBlue, Color.CornflowerBlue };
                chtFamilia.DataBind();

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
        internal List<MOD_visaoOrquestral> agrupaFamInstrumento(string Familia, List<MOD_pessoa> listaPes)
        {
            try
            {
                List<MOD_visaoOrquestral> listaAgrupada = new List<MOD_visaoOrquestral>();
                listaAgrupada = (listaPes.AsEnumerable().Where(c => Convert.ToString(c.DescFamilia).Equals(Familia)).GroupBy(
                                    a => new { a.CodFamilia, a.DescFamilia, a.CodInstrumento, a.DescInstrumento }).Select(
                                     g => new MOD_visaoOrquestral
                                     {
                                         CodFamilia = g.Key.CodFamilia,
                                         DescFamilia = g.Key.DescFamilia,
                                         CodInstrumento = g.Key.CodInstrumento,
                                         DescInstrumento = g.Key.DescInstrumento,
                                         TotalInstrumentos = Convert.ToString(g.Count()).PadLeft(4, '0')
                                     }).ToList());

                return listaAgrupada;
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
        internal List<MOD_visaoOrquestral> agrupaGrafFamilia(string Familia, List<MOD_pessoa> listaPes)
        {
            try
            {
                List<MOD_visaoOrquestral> listaAgrupada = new List<MOD_visaoOrquestral>();
                listaAgrupada = (listaPes.AsEnumerable().Where(c => Convert.ToString(c.DescFamilia).Equals(Familia)).GroupBy(
                                    a => new { a.CodFamilia, a.DescFamilia }).Select(
                                     g => new MOD_visaoOrquestral
                                     {
                                         CodFamilia = g.Key.CodFamilia,
                                         DescFamilia = g.Key.DescFamilia,
                                         TotalInstrumentos = Convert.ToString(g.Count()).PadLeft(4, '0')
                                     }).ToList());

                return listaAgrupada;
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