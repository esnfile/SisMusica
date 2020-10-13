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
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.uteis;

namespace ccbpess
{
    public partial class frmCCBBusca : Form
    {
        public frmCCBBusca(List<MOD_acessos> listaLibAcesso, Form forms, string Campo)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;
                ///Recebe o Nome do formulário que chamou
                formChama = forms;
                campoChama = Campo;
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
        string Codigo;
        string Descricao;

        BLL_ccb objBLL = null;
        MOD_ccb objEnt = null;
        List<MOD_ccb> lista;

        BLL_regiaoAtuacao objBLL_Regiao = null;
        List<MOD_regiaoAtuacao> listaRegiao = null;

        Form formulario;
        Form formChama;
        string campoChama;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        #region Aba Codigo

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnCod;
        }
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnCodIns;
        }
        private void btnCod_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        carregaGrid("Codigo", txtCodigo.Text, gridCodigo);
                    }
                }
                else
                {
                    carregaGrid("Codigo", txtCodigo.Text, gridCodigo);
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
        private void btnCodIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridCodigo);
                ((frmCCB)formulario).Text = "Inserindo Comum";
                ((frmCCB)formulario).enabledForm();
                ((frmCCB)formulario).defineFoco();
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
        private void btnCodVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCodigo[2, gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmCCB)formulario).Text = "Visualizando Comum";
                ((frmCCB)formulario).disabledForm();
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
        private void btnCodEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCodigo[2, gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmCCB)formulario).Text = "Editando Comum";
                ((frmCCB)formulario).enabledForm();
                ((frmCCB)formulario).defineFoco();
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
        private void btnCodExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridCodigo[2, gridCodigo.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.excluir(criarTabela());

                    gridCodigo.DataSource = null;
                    funcoes.gridCCB(gridCodigo);
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
            else
            {
                txtCodigo.Focus();
            }
        }
        private void gridCodigo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnCodEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridCodigo[2, gridCodigo.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCodigo);
                    ((frmCCB)formulario).Text = "Editando Comum";
                    ((frmCCB)formulario).enabledForm();
                    ((frmCCB)formulario).defineFoco();
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
        private void gridCodigo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermCodigo(gridCodigo);
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
        private void gridCodigo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridCodigo[2, gridCodigo.CurrentRow.Index].Value.ToString();
                Descricao = gridCodigo[4, gridCodigo.CurrentRow.Index].Value.ToString();
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
        private void btnCodSel_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCodigo[2, gridCodigo.CurrentRow.Index].Value.ToString();
                preencher(Codigo, formChama.Name, campoChama);
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

        #region Aba Nome

        private void txtNome_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnNome;
        }
        private void txtNome_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnNomeIns;
        }
        private void btnNome_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        carregaGrid("Nome", txtNome.Text, gridNome);
                    }
                }
                else
                {
                    carregaGrid("Nome", txtNome.Text, gridNome);
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
        private void btnNomeVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridNome[2, gridNome.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridNome);
                ((frmCCB)formulario).Text = "Visualizando Comum";
                ((frmCCB)formulario).disabledForm();
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
        private void btnNomeIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridNome);
                ((frmCCB)formulario).Text = "Inserindo Comum";
                ((frmCCB)formulario).enabledForm();
                ((frmCCB)formulario).defineFoco();
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
        private void btnNomeEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridNome[2, gridNome.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridNome);
                ((frmCCB)formulario).Text = "Editando Comum";
                ((frmCCB)formulario).enabledForm();
                ((frmCCB)formulario).defineFoco();
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
        private void btnNomeExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridNome[2, gridNome.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridNome.DataSource = null;
                    funcoes.gridCCB(gridNome);
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
            else
            {
                txtNome.Focus();
            }
        }
        private void gridNome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnNomeEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridNome[2, gridNome.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridNome);
                    ((frmCCB)formulario).Text = "Editando Comum";
                    ((frmCCB)formulario).enabledForm();
                    ((frmCCB)formulario).defineFoco();
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
        private void gridNome_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermNome(gridNome);
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
        private void gridNome_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridNome[2, gridNome.CurrentRow.Index].Value.ToString();
                Descricao = gridNome[4, gridNome.CurrentRow.Index].Value.ToString();
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
        private void btnNomeSel_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridNome[2, gridNome.CurrentRow.Index].Value.ToString();
                preencher(Codigo, formChama.Name, campoChama);
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

        #region Aba Regiao

        private void lblCodRegiao_TextChanged(object sender, EventArgs e)
        {
            if (!lblCodRegiao.Text.Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaGrid("Regiao", lblCodRegiao.Text, gridRegiao);
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
        private void btnRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmReg", gridRegiao);
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
        private void btnRegVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridRegiao[2, gridRegiao.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridRegiao);
                ((frmCCB)formulario).Text = "Visualizando Comum";
                ((frmCCB)formulario).disabledForm();
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
        private void btnRegIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridRegiao);
                ((frmCCB)formulario).Text = "Inserindo Comum";
                ((frmCCB)formulario).enabledForm();
                ((frmCCB)formulario).defineFoco();
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
        private void btnRegEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridRegiao[2, gridRegiao.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridRegiao);
                ((frmCCB)formulario).Text = "Editando Comum";
                ((frmCCB)formulario).enabledForm();
                ((frmCCB)formulario).defineFoco();
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
        private void btnRegExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridRegiao[2, gridRegiao.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.excluir(criarTabela());

                    gridRegiao.DataSource = null;
                    funcoes.gridCCB(gridRegiao);
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
            else
            {
                AcceptButton = btnRegiao;
            }
        }
        private void gridRegiao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnRegEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridRegiao[2, gridRegiao.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridRegiao);
                    ((frmCCB)formulario).Text = "Editando Comum";
                    ((frmCCB)formulario).enabledForm();
                    ((frmCCB)formulario).defineFoco();
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
                verPermRegiao(gridRegiao);
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
                Codigo = gridRegiao[2, gridRegiao.CurrentRow.Index].Value.ToString();
                Descricao = gridRegiao[4, gridRegiao.CurrentRow.Index].Value.ToString();
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
        private void btnRegSel_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridRegiao[2, gridRegiao.CurrentRow.Index].Value.ToString();
                preencher(Codigo, formChama.Name, campoChama);
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

        private void tabCCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabCCB.SelectedIndex.Equals(1))
                {
                    funcoes.gridCCB(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
                else if (tabCCB.SelectedIndex.Equals(0))
                {
                    funcoes.gridCCB(gridNome);
                    txtNome.Text = string.Empty;
                    txtNome.Focus();
                }
                else if (tabCCB.SelectedIndex.Equals(2))
                {
                    funcoes.gridCCB(gridRegiao);
                    lblCodRegiao.Text = string.Empty;
                    lblDescricaoRegiao.Text = string.Empty;
                    AcceptButton = btnRegiao;
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
        private void frmCCBBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridCCB(gridNome);

                //verificar permissão de acesso
                verPermNome(gridNome);
                verPermCodigo(gridCodigo);
                verPermRegiao(gridRegiao);

                //definir as imagens
                pctAberta.Image = imgCCB.Images[0];
                pctFechada.Image = imgCCB.Images[1];
                pctConstrucao.Image = imgCCB.Images[2];
                pctReforma.Image = imgCCB.Images[3];
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
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmCCBBusca_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }

        #endregion

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="DataGrid"></param>
        internal void carregaGrid(string Pesquisa, string Campo, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("CCB"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_ccb();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridCCB(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_ccb();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridCCB(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Nome"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_ccb();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridCCB(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Regiao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_ccb();
                    lista = objBLL.buscarRegiao(Campo);
                    funcoes.gridCCB(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
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
                if (form.Equals("frmReg"))
                {
                    formChama = new frmPesquisaRegiao(this);
                    ((frmPesquisaRegiao)formChama).MdiParent = MdiParent;
                    ((frmPesquisaRegiao)formChama).Show();
                    Enabled = false;

                    lblDescricaoRegiao.Text = string.Empty;
                    lblCodRegiao.Text = string.Empty;
                }
                else
                {
                    if (((frmCCB)formulario) == null || ((frmCCB)formulario).IsDisposed)
                    {
                        preencher(Codigo, string.Empty, string.Empty);
                        //funcoes.AbrirFormulario("ccbpess", "ccbpess.frmCCB");
                        formulario = new frmCCB(this, dataGrid, lista);
                        ((frmCCB)formulario).MdiParent = MdiParent;
                        ((frmCCB)formulario).Show();
                        Enabled = false;
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="CodCCB"></param>
        internal void preencher(string CodCCB, string form, string Campo)
        {
            try
            {
                if (form.Equals("frmPessoa"))
                {
                    ((frmPessoa)formChama).carregaComum(CodCCB, Campo);
                    Close();
                }
                else
                {
                    objBLL = new BLL_ccb();
                    lista = objBLL.buscarCod(CodCCB);
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
        /// Função que define a imagem da Situação da Comum
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (linha.Cells["Situacao"].Value.ToString().Contains("Aberta"))
                    {
                        linha.Cells[0].Value = imgCCB.Images[0];
                    }
                    else if (linha.Cells["Situacao"].Value.ToString().Contains("Fechada"))
                    {
                        linha.Cells[0].Value = imgCCB.Images[1];
                    }
                    else if (linha.Cells["Situacao"].Value.ToString().Contains("Em Construcao"))
                    {
                        linha.Cells[0].Value = imgCCB.Images[2];
                    }
                    else if (linha.Cells["Situacao"].Value.ToString().Contains("Em Reforma"))
                    {
                        linha.Cells[0].Value = imgCCB.Images[3];
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_ccb criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_ccb();
                objEnt.CodCCB = Codigo;
                objEnt.Descricao = Descricao;

                //retorna o objeto preenchido
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
        /// Função que carrega a Região pesquisado pelo Código
        /// </summary>
        /// <param name="vCodRegiao"></param>
        internal void carregaRegiao(string vCodRegiao)
        {
            try
            {
                objBLL_Regiao = new BLL_regiaoAtuacao();
                listaRegiao = objBLL_Regiao.buscarCod(vCodRegiao);

                if (listaRegiao != null && listaRegiao.Count > 0)
                {
                    lblCodRegiao.Text = listaRegiao[0].CodRegiao;
                    lblDescricaoRegiao.Text = "Microrregião: " + listaRegiao[0].Codigo + " - " + listaRegiao[0].Descricao + " - Regional: " + listaRegiao[0].DescricaoRegional;
                }
                else
                {
                    abrirForm("frmReg", gridRegiao);
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
        /// Função que define o foco do cursor
        /// </summary>
        public void defineFoco()
        {
            txtNome.Focus();
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermCodigo(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(26))
                    {
                        btnCodIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(27))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnCodEditar.Enabled = true;
                        }
                        else
                        {
                            btnCodEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(28))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnCodExc.Enabled = true;
                        }
                        else
                        {
                            btnCodExc.Enabled = false;
                        }
                    }
                    //verificando o botão visualizar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(29))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnCodVisual.Enabled = true;
                        }
                        else
                        {
                            btnCodVisual.Enabled = false;
                        }
                    }
                }
                //verificando o botão Selecionar
                if (Text.Equals("Pesquisar Comum"))
                {
                    if (dataGrid.Rows.Count > 0)
                    {
                        btnCodSel.Visible = true;
                        btnCodSel.Enabled = true;
                    }
                    else
                    {
                        btnCodSel.Visible = true;
                        btnCodSel.Enabled = false;
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
        internal void verPermNome(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(26))
                    {
                        btnNomeIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(27))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnNomeEditar.Enabled = true;
                        }
                        else
                        {
                            btnNomeEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(28))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnNomeExc.Enabled = true;
                        }
                        else
                        {
                            btnNomeExc.Enabled = false;
                        }
                    }
                    //verificando o botão visualizar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(29))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnNomeVisual.Enabled = true;
                        }
                        else
                        {
                            btnNomeVisual.Enabled = false;
                        }
                    }
                }
                //verificando o botão Selecionar
                if (Text.Equals("Pesquisar Comum"))
                {
                    if (dataGrid.Rows.Count > 0)
                    {
                        btnNomeSel.Visible = true;
                        btnNomeSel.Enabled = true;
                    }
                    else
                    {
                        btnNomeSel.Visible = true;
                        btnNomeSel.Enabled = false;
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
        internal void verPermRegiao(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(26))
                    {
                        btnRegIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(27))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnRegEditar.Enabled = true;
                        }
                        else
                        {
                            btnRegEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(28))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnRegExc.Enabled = true;
                        }
                        else
                        {
                            btnRegExc.Enabled = false;
                        }
                    }
                    //verificando o botão visualizar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(29))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnRegVisual.Enabled = true;
                        }
                        else
                        {
                            btnRegVisual.Enabled = false;
                        }
                    }
                }
                //verificando o botão Selecionar
                if (Text.Equals("Pesquisar Comum"))
                {
                    if (dataGrid.Rows.Count > 0)
                    {
                        btnRegSel.Visible = true;
                        btnRegSel.Enabled = true;
                    }
                    else
                    {
                        btnRegSel.Visible = true;
                        btnRegSel.Enabled = false;
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