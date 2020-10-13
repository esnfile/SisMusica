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

namespace ccbutil
{
    public partial class frmRegionalBusca : Form
    {
        public frmRegionalBusca(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;

                ///carrega os estados
                apoio.carregaComboEstado(cboEstado);

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

        BLL_regional objBLL = null;
        MOD_regional objEnt = null;
        List<MOD_regional> lista;

        Form formulario;

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
                ((frmRegional)formulario).Text = "Inserindo Centro de Região";
                ((frmRegional)formulario).enabledForm();
                ((frmRegional)formulario).defineFoco();
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
                Codigo = gridCodigo[0, gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmRegional)formulario).Text = "Visualizando Centro de Região";
                ((frmRegional)formulario).disabledForm();
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
                Codigo = gridCodigo[0, gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmRegional)formulario).Text = "Editando Centro de Região";
                ((frmRegional)formulario).enabledForm();
                ((frmRegional)formulario).defineFoco();
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
                    Codigo = gridCodigo[0, gridCodigo.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.excluir(criarTabela());

                    gridCodigo.DataSource = null;
                    funcoes.gridRegional(gridCodigo);
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
                    Codigo = gridCodigo[0, gridCodigo.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCodigo);
                    ((frmRegional)formulario).Text = "Editando Centro de Região";
                    ((frmRegional)formulario).enabledForm();
                    ((frmRegional)formulario).defineFoco();
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
                Codigo = gridCodigo[0, gridCodigo.CurrentRow.Index].Value.ToString();
                Descricao = gridCodigo[2, gridCodigo.CurrentRow.Index].Value.ToString();
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
                Codigo = gridNome[0, gridNome.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridNome);
                ((frmRegional)formulario).Text = "Visualizando Centro de Região";
                ((frmRegional)formulario).disabledForm();
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
                ((frmRegional)formulario).Text = "Inserindo Centro de Região";
                ((frmRegional)formulario).enabledForm();
                ((frmRegional)formulario).defineFoco();
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
                Codigo = gridNome[0, gridNome.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridNome);
                ((frmRegional)formulario).Text = "Editando Centro de Região";
                ((frmRegional)formulario).enabledForm();
                ((frmRegional)formulario).defineFoco();
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
                    Codigo = gridNome[0, gridNome.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridNome.DataSource = null;
                    funcoes.gridRegional(gridNome);
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
                    Codigo = gridNome[0, gridNome.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridNome);
                    ((frmRegional)formulario).Text = "Editando Centro de Região";
                    ((frmRegional)formulario).enabledForm();
                    ((frmRegional)formulario).defineFoco();
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
                Codigo = gridNome[0, gridNome.CurrentRow.Index].Value.ToString();
                Descricao = gridNome[2, gridNome.CurrentRow.Index].Value.ToString();
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

        #region Aba Estado

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEstado.SelectedIndex.Equals(-1))
            {
                cboEstado.Focus();
            }
            else
            {
                try
                {
                    apoio.Aguarde();
                    carregaGrid("Estado", cboEstado.Text, gridEstado);
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
        private void btnEstVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridEstado[0, gridEstado.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridEstado);
                ((frmRegional)formulario).Text = "Visualizando Centro de Região";
                ((frmRegional)formulario).disabledForm();
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
        private void btnEstIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridEstado);
                ((frmRegional)formulario).Text = "Inserindo Centro de Região";
                ((frmRegional)formulario).enabledForm();
                ((frmRegional)formulario).defineFoco();
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
        private void btnEstEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridEstado[0, gridEstado.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridEstado);
                ((frmRegional)formulario).Text = "Editando Centro de Região";
                ((frmRegional)formulario).enabledForm();
                ((frmRegional)formulario).defineFoco();
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
        private void btnEstExc_Click(object sender, EventArgs e)
        {

        }
        private void gridEstado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnEstEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridEstado[0, gridEstado.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridEstado);
                    ((frmRegional)formulario).Text = "Editando Centro de Região";
                    ((frmRegional)formulario).enabledForm();
                    ((frmRegional)formulario).defineFoco();
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
        private void gridEstado_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermEstado(gridEstado);
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
        private void gridEstado_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridEstado[0, gridEstado.CurrentRow.Index].Value.ToString();
                Descricao = gridEstado[3, gridEstado.CurrentRow.Index].Value.ToString();
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

        #region Eventos do Formulario

        private void tabRegional_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabRegional.SelectedIndex.Equals(1))
                {
                    funcoes.gridRegional(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
                else if (tabRegional.SelectedIndex.Equals(0))
                {
                    funcoes.gridRegional(gridNome);
                    txtNome.Text = string.Empty;
                    txtNome.Focus();
                }
                else if (tabRegional.SelectedIndex.Equals(2))
                {
                    funcoes.gridRegional(gridEstado);
                    cboEstado.SelectedIndex = (-1);
                    cboEstado.Focus();
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
        private void frmRegionalBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridRegional(gridNome);

                //verificar permissão de acesso
                verPermNome(gridNome);
                verPermCodigo(gridCodigo);
                verPermEstado(gridEstado);

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
                if (Pesquisa.Equals("Regional"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regional();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridRegional(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regional();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridRegional(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Nome"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regional();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridRegional(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Estado"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regional();
                    lista = objBLL.buscarEstado(Campo);
                    funcoes.gridRegional(dataGrid);
                    dataGrid.DataSource = lista;
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
                preencher(Codigo);
                formulario = new frmRegional(this, dataGrid, lista);
                ((frmRegional)formulario).MdiParent = MdiParent;
                ((frmRegional)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmRegional)formulario));
                ((frmRegional)formulario).Show();
                ((frmRegional)formulario).BringToFront();
                Enabled = false;
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
        /// <param name="CodRegional"></param>
        internal void preencher(string CodRegional)
        {
            try
            {
                objBLL = new BLL_regional();
                lista = objBLL.buscarCod(CodRegional);
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
        private MOD_regional criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_regional();
                objEnt.CodRegional = Codigo;
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
                MOD_acessoRegional entAcesso = new MOD_acessoRegional();
                btnCodIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsRegional);
                btnCodEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditRegional, dataGrid);
                btnCodExc.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcRegional, dataGrid);
                btnCodVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisRegional, dataGrid);
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
                MOD_acessoRegional entAcesso = new MOD_acessoRegional();
                btnNomeIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsRegional);
                btnNomeEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditRegional, dataGrid);
                btnNomeExc.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcRegional, dataGrid);
                btnNomeVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisRegional, dataGrid);
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
        internal void verPermEstado(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoRegional entAcesso = new MOD_acessoRegional();
                btnEstIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsRegional);
                btnEstEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditRegional, dataGrid);
                btnEstExc.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcRegional, dataGrid);
                btnEstVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisRegional, dataGrid);
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
