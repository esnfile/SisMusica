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
    public partial class frmRegiaoBusca : Form
    {
        public frmRegiaoBusca(List<MOD_acessos> listaLibAcesso)
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
        string Codigo;
        string Descricao;

        BLL_regiaoAtuacao objBLL = null;
        MOD_regiaoAtuacao objEnt = null;
        List<MOD_regiaoAtuacao> lista;

        BLL_regional objBLL_Reg = null;
        List<MOD_regional> listaRegional = null;

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
                ((frmRegiao)formulario).Text = "Inserindo Região";
                ((frmRegiao)formulario).enabledForm();
                ((frmRegiao)formulario).defineFoco();
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
                ((frmRegiao)formulario).Text = "Visualizando Região";
                ((frmRegiao)formulario).disabledForm();
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
                ((frmRegiao)formulario).Text = "Editando Região";
                ((frmRegiao)formulario).enabledForm();
                ((frmRegiao)formulario).defineFoco();
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
                    funcoes.gridRegiao(gridCodigo);
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
            if (!this.btnCodEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridCodigo[0, gridCodigo.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCodigo);
                    ((frmRegiao)formulario).Text = "Editando Região";
                    ((frmRegiao)formulario).enabledForm();
                    ((frmRegiao)formulario).defineFoco();
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
                ((frmRegiao)formulario).Text = "Visualizando Região";
                ((frmRegiao)formulario).disabledForm();
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
                ((frmRegiao)formulario).Text = "Inserindo Região";
                ((frmRegiao)formulario).enabledForm();
                ((frmRegiao)formulario).defineFoco();
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
                ((frmRegiao)formulario).Text = "Editando Região";
                ((frmRegiao)formulario).enabledForm();
                ((frmRegiao)formulario).defineFoco();
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
                    funcoes.gridRegiao(gridNome);
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
                    ((frmRegiao)formulario).Text = "Editando Região";
                    ((frmRegiao)formulario).enabledForm();
                    ((frmRegiao)formulario).defineFoco();
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

        #region Aba Regional

        private void btnRegional_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.abrirForm("frmReg", gridRegional);
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
        private void lblCodRegional_TextChanged(object sender, EventArgs e)
        {
            if (!lblCodRegional.Text.Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaGrid("Regional", lblCodRegional.Text, gridRegional);
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
        private void btnRegVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridRegional[0, gridRegional.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridRegional);
                ((frmRegiao)formulario).Text = "Visualizando Região";
                ((frmRegiao)formulario).disabledForm();
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
                abrirForm(string.Empty, gridRegional);
                ((frmRegiao)formulario).Text = "Inserindo Região";
                ((frmRegiao)formulario).enabledForm();
                ((frmRegiao)formulario).defineFoco();
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
                Codigo = gridRegional[0, gridRegional.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridRegional);
                ((frmRegiao)formulario).Text = "Editando Região";
                ((frmRegiao)formulario).enabledForm();
                ((frmRegiao)formulario).defineFoco();
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
                    Codigo = gridRegional[0, gridRegional.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.excluir(criarTabela());

                    gridRegional.DataSource = null;
                    funcoes.gridRegiao(gridRegional);
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
                AcceptButton = btnRegional;
            }
        }
        private void gridRegional_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnRegEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridRegional[0, gridRegional.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridRegional);
                    ((frmRegiao)formulario).Text = "Editando Região";
                    ((frmRegiao)formulario).enabledForm();
                    ((frmRegiao)formulario).defineFoco();
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
        private void gridRegional_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermRegional(gridRegional);
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
        private void gridRegional_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridRegional[0, gridRegional.CurrentRow.Index].Value.ToString();
                Descricao = gridRegional[2, gridRegional.CurrentRow.Index].Value.ToString();
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

        private void tabRegiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabRegiao.SelectedIndex.Equals(1))
                {
                    funcoes.gridRegiao(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
                else if (tabRegiao.SelectedIndex.Equals(0))
                {
                    funcoes.gridRegiao(gridNome);
                    txtNome.Text = string.Empty;
                    txtNome.Focus();
                }
                else if (tabRegiao.SelectedIndex.Equals(2))
                {
                    funcoes.gridRegiao(gridRegional);
                    lblCodRegional.Text = string.Empty;
                    lblCodigoRegional.Text = string.Empty;
                    lblDescricaoRegional.Text = string.Empty;
                    AcceptButton = btnRegional;
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
        private void frmRegiaoBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridRegiao(gridNome);

                //verificar permissão de acesso
                verPermNome(gridNome);
                verPermCodigo(gridCodigo);
                verPermRegional(gridRegional);

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
                if (Pesquisa.Equals("Regiao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regiaoAtuacao();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridRegiao(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regiaoAtuacao();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridRegiao(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Nome"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regiaoAtuacao();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridRegiao(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Regional"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_regiaoAtuacao();
                    lista = objBLL.buscarRegional(Campo);
                    funcoes.gridRegiao(dataGrid);
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
                if (form.Equals("frmReg"))
                {

                    formulario = new frmPesquisaRegional(this);
                    ((frmPesquisaRegional)formulario).MdiParent = MdiParent;
                    ((frmPesquisaRegional)formulario).Show();
                    Enabled = false;

                    lblCodRegional.Text = string.Empty;
                    lblCodigoRegional.Text = string.Empty;
                    lblDescricaoRegional.Text = string.Empty;
               }
                else
                {
                    if (((frmRegiao)formulario) == null || ((frmRegiao)formulario).IsDisposed)
                    {
                        preencher(Codigo);
                        formulario = new frmRegiao(this, dataGrid, lista);
                        ((frmRegiao)formulario).MdiParent = MdiParent;
                        ((frmRegiao)formulario).Show();
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
        /// <param name="CodRegiao"></param>
        internal void preencher(string CodRegiao)
        {
            try
            {
                objBLL = new BLL_regiaoAtuacao();
                lista = objBLL.buscarCod(CodRegiao);
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
        private MOD_regiaoAtuacao criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_regiaoAtuacao();
                objEnt.CodRegiao = Codigo;
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
        /// Função que carrega a Regional pesquisado pelo Código
        /// </summary>
        /// <param name="vCodRegional"></param>
        internal void carregaRegional(string vCodRegional)
        {
            try
            {
                objBLL = new BLL_regiaoAtuacao();
                listaRegional = objBLL_Reg.buscarCod(vCodRegional);

                if (listaRegional != null && listaRegional.Count > 0)
                {
                    lblCodRegional.Text = listaRegional[0].CodRegional.PadLeft(5, '0');
                    lblCodigoRegional.Text = listaRegional[0].Codigo;
                    lblDescricaoRegional.Text = listaRegional[0].Descricao;
                }
                else
                {
                    abrirForm("frmReg", gridRegional);
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
                    if (Convert.ToInt32(ent.CodRotina).Equals(50))
                    {
                        btnCodIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(51))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(52))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(53))
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
                    if (Convert.ToInt32(ent.CodRotina).Equals(50))
                    {
                        btnNomeIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(51))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(52))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(53))
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
        internal void verPermRegional(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(50))
                    {
                        btnRegIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(51))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(52))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(53))
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
