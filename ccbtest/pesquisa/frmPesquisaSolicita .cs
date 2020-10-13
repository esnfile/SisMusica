using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.pessoa;
using BLL.preTeste;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.pessoa;
using ENT.preTeste;
using ENT.uteis;

namespace ccbtest.pesquisa
{
    public partial class frmPesquisaSolicita : Form
    {
        public frmPesquisaSolicita(Form forms)
        {
            InitializeComponent();

            try
            {
                formChama = forms;

                //Carrega Combo Região
                apoio.carregaComboRegiao(cboRegiao);
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
        string Codigo;
        string Descricao;

        BLL_solicitaTeste objBLL = null;
        List<MOD_solicitaTeste> lista;

        BLL_pessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa;

        BLL_ccb objBLL_CCB = null;
        List<MOD_ccb> listaCCB;

        //instancias de validacoes
        clsException excp;

        Form formChama;
        Form formulario;

        #endregion

        #region eventos

        #region Aba Aluno

        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", gridPes);
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
        private void lblCodPessoa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid(lblCodPessoa.Text, "Pessoa");
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
        private void btnSelPes_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridPes["CodSolicitaTeste", gridPes.CurrentRow.Index].Value.ToString();
                //chama a rotina para preencher dados
                preencher(Codigo);
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
        private void gridPes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (gridPes.RowCount > 0)
                {
                    btnSelPes.Enabled = true;
                }
                else
                {
                    btnSelPes.Enabled = false;
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
        private void gridPes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridPes["CodSolicitaTeste", gridPes.CurrentRow.Index].Value.ToString();
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
        private void gridPes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSelPes.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridPes["CodSolicitaTeste", gridPes.CurrentRow.Index].Value.ToString();
                    //chama a rotina para preencher dados
                    preencher(Codigo);
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

        #region Aba CCB

        private void lblCodCCB_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid(lblCodCCB.Text, "CCB");
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
        private void btnCCB_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCCB", gridCCB);
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
        private void btnSelCCB_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCCB["CodSolicitaTeste", gridCCB.CurrentRow.Index].Value.ToString();
                //chama a rotina para preencher dados
                preencher(Codigo);
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
        private void gridCCB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSelCCB.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridCCB["CodSolicitaTeste", gridCCB.CurrentRow.Index].Value.ToString();
                    //chama a rotina para preencher dados
                    preencher(Codigo);
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
        private void gridCCB_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (gridCCB.RowCount > 0)
                {
                    btnSelCCB.Enabled = true;
                }
                else
                {
                    btnSelCCB.Enabled = false;
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
        private void gridCCB_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridCCB["CodSolicitaTeste", gridCCB.CurrentRow.Index].Value.ToString();
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

        #region Aba Regiao

        private void cboRegiao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid(Convert.ToString(cboRegiao.SelectedValue), "Regiao");
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
        private void gridRegiao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSelReg.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridRegiao["CodSolicitaTeste", gridRegiao.CurrentRow.Index].Value.ToString();
                    //chama a rotina para preencher dados
                    preencher(Codigo);
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
        private void gridRegiao_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                if (gridRegiao.RowCount > 0)
                {
                    btnSelReg.Enabled = true;
                }
                else
                {
                    btnSelReg.Enabled = false;
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
        private void gridRegiao_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridRegiao["CodSolicitaTeste", gridRegiao.CurrentRow.Index].Value.ToString();
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
        private void btnSelReg_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridRegiao["CodSolicitaTeste", gridRegiao.CurrentRow.Index].Value.ToString();
                //chama a rotina para preencher dados
                preencher(Codigo);
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

        #region Eventos do Formulario

        private void frmPesquisaSolicita_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridSolicitaTeste(gridPes, "PesquisaSolicita");
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
            Close();
        }
        private void frmPesquisaSolicita_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void tabSolicita_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabSolicita.SelectedTab.Name.Equals("tabRegiao"))
                {
                    funcoes.gridSolicitaTeste(gridRegiao, "PesquisaSolicita");
                    cboRegiao.SelectedIndex = -1;
                    cboRegiao.Focus();
                }
                else if (tabSolicita.SelectedTab.Name.Equals("tabComum"))
                {
                    funcoes.gridSolicitaTeste(gridCCB, "PesquisaSolicita");
                    lblCodCCB.Text = string.Empty;
                    lblDescCCB.Text = string.Empty;
                    AcceptButton = btnCCB;
                }
                else if (tabSolicita.SelectedTab.Name.Equals("tabPes"))
                {
                    funcoes.gridSolicitaTeste(gridPes, "PesquisaSolicita");
                    lblCodPessoa.Text = string.Empty;
                    lblDescPessoa.Text = string.Empty;
                    AcceptButton = btnPessoa;
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

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// <para>Campo= Valor a ser pesquisado  /  Pesquisa= 'Pessoa', 'CCB', 'Regiao'</para>
        /// </summary>
        /// <param name="Campo1"></param>
        internal void carregaGrid(string Campo1, string Pesquisa)
        {
            try
            {
                if (Pesquisa.Equals("Pessoa"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarPessoa(Campo1, modulos.CodUsuarioCCB, "Pendente");
                    funcoes.gridSolicitaTeste(gridPes, "PesquisaSolicita");
                    gridPes.DataSource = lista;
                    //Define os icones de legenda
                    definirImagens(gridPes);
                }
                else if (Pesquisa.Equals("CCB"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarCCB(Campo1, "Pendente");
                    funcoes.gridSolicitaTeste(gridCCB, "PesquisaSolicita");
                    gridCCB.DataSource = lista;
                    //Define os icones de legenda
                    definirImagens(gridCCB);
                }
                else if (Pesquisa.Equals("Regiao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarRegiao(Campo1, modulos.CodUsuarioCCB, "Pendente");
                    funcoes.gridSolicitaTeste(gridRegiao, "PesquisaSolicita");
                    gridRegiao.DataSource = lista;
                    //Define os icones de legenda
                    definirImagens(gridRegiao);
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
        /// Função que preenche o formulário para seleção
        /// </summary>
        /// <param name="vCodigo"></param>
        private void preencher(string vCodigo)
        {
            try
            {
                if (formChama.Name.Equals("frmFichaPreTeste"))
                {
                    ((frmFichaPreTeste)formChama).carregaSolicita(vCodigo);
                    Close();
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
        /// Função que define o Foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            btnPessoa.Focus();
        }
        /// <summary>
        /// Função que define a imagem da Situação da Solicitação
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (linha.Cells["Tipo"].Value.ToString().Contains("Reunião de Jovens"))
                    {
                        linha.Cells[0].Value = imgSolicita.Images[0];
                    }
                    else if (linha.Cells["Tipo"].Value.ToString().Contains("Meia Hora"))
                    {
                        linha.Cells[0].Value = imgSolicita.Images[1];
                    }
                    else if (linha.Cells["Tipo"].Value.ToString().Contains("Culto Oficial"))
                    {
                        linha.Cells[0].Value = imgSolicita.Images[2];
                    }
                    else if (linha.Cells["Tipo"].Value.ToString().Contains("Oficialização"))
                    {
                        linha.Cells[0].Value = imgSolicita.Images[3];
                    }
                    else if (linha.Cells["Tipo"].Value.ToString().Contains("Troca Instrumento"))
                    {
                        linha.Cells[0].Value = imgSolicita.Images[4];
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
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(string form, DataGridView dataGrid)
        {
            try
            {
                if (form.Equals("frmPes"))
                {
                    lblCodPessoa.Text = string.Empty;
                    lblDescPessoa.Text = string.Empty;

                    formulario = new frmPesquisaPessoa(this, "Aluno");
                    ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                    ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                    ((frmPesquisaPessoa)formulario).Show();
                    ((frmPesquisaPessoa)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmCCB"))
                {
                    lblDescCCB.Text = string.Empty;
                    lblCodCCB.Text = string.Empty;

                    formulario = new frmPesquisaComum(this, string.Empty);
                    ((frmPesquisaComum)formulario).MdiParent = MdiParent;
                    ((frmPesquisaComum)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaComum)formulario));
                    ((frmPesquisaComum)formulario).Show();
                    ((frmPesquisaComum)formulario).BringToFront();
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
        /// Função que carrega a Comum pesquisado pelo Código
        /// </summary>
        /// <param name="vCodCCB"></param>
        internal void carregaCCB(string vCodCCB)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarCod(vCodCCB);

                if (listaCCB != null && listaCCB.Count > 0)
                {
                    lblCodCCB.Text = listaCCB[0].CodCCB;
                    lblDescCCB.Text = "Comum Congregação: " + listaCCB[0].Codigo + " - " + listaCCB[0].Descricao + " - " + listaCCB[0].DescricaoRegiao + " - Regional: " + listaCCB[0].DescricaoRegional;
                }
                else
                {
                    abrirForm("frmCom", gridCCB);
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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPes"></param>
        internal void carregaPessoa(string vCodPes)
        {
            try
            {
                objBLL_Pessoa = new BLL_pessoa();
                listaPessoa = objBLL_Pessoa.buscarCod(vCodPes);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    lblCodPessoa.Text = listaPessoa[0].CodPessoa;
                    lblDescPessoa.Text = listaPessoa[0].Nome + " - Instrumento: " + listaPessoa[0].DescInstrumento;
                }
                else
                {
                    abrirForm("frmPes", gridPes);
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