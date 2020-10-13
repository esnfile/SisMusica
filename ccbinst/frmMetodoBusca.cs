using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.instrumentos;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.instrumentos;

namespace ccbinst
{
    public partial class frmMetodoBusca : Form
    {
        public frmMetodoBusca(List<MOD_acessos> listaLibAcesso)
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

        BLL_metodos objBLL = null;
        MOD_metodos objEnt = null;
        List<MOD_metodos> lista;

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
                carregaGrid("Codigo", txtCodigo.Text, gridCodigo);
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
                ((frmMetodo)formulario).Text = "Inserindo Método";
                ((frmMetodo)formulario).enabledForm();
                ((frmMetodo)formulario).defineFoco();
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
                ((frmMetodo)formulario).Text = "Visualizando Método";
                ((frmMetodo)formulario).disabledForm();
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
                ((frmMetodo)formulario).Text = "Editando Método";
                ((frmMetodo)formulario).enabledForm();
                ((frmMetodo)formulario).defineFoco();
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
                    funcoes.gridMetodo(gridCodigo, string.Empty);
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
                    ((frmMetodo)formulario).Text = "Editando Método";
                    ((frmMetodo)formulario).enabledForm();
                    ((frmMetodo)formulario).defineFoco();
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
                Codigo = Convert.ToString(gridCodigo[2, gridCodigo.CurrentRow.Index].Value);
                Descricao = Convert.ToString(gridCodigo[4, gridCodigo.CurrentRow.Index].Value);
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

        #region Aba Descrição

        private void txtDesc_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnDesc;
        }
        private void txtDesc_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnDescIns;
        }
        private void btnDesc_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid("Desc", txtDesc.Text, gridDesc);
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
        private void btnDescVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmMetodo)formulario).Text = "Visualizando Método";
                ((frmMetodo)formulario).disabledForm();
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
        private void btnDescIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridDesc);
                ((frmMetodo)formulario).Text = "Inserindo Método";
                ((frmMetodo)formulario).enabledForm();
                ((frmMetodo)formulario).defineFoco();
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
        private void btnDescEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmMetodo)formulario).Text = "Editando Método";
                ((frmMetodo)formulario).enabledForm();
                ((frmMetodo)formulario).defineFoco();
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
        private void btnDescExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridDesc.DataSource = null;
                    funcoes.gridMetodo(gridDesc, string.Empty);
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
                txtDesc.Focus();
            }
        }
        private void gridDesc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnDescEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridDesc);
                    ((frmMetodo)formulario).Text = "Editando Método";
                    ((frmMetodo)formulario).enabledForm();
                    ((frmMetodo)formulario).defineFoco();
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
        private void gridDesc_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermDesc(gridDesc);
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
        private void gridDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = Convert.ToString(gridDesc[2, gridDesc.CurrentRow.Index].Value);
                Descricao = Convert.ToString(gridDesc[4, gridDesc.CurrentRow.Index].Value);
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

        #region Aba Tipo

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid("Tipo", cboTipo.Text, gridTipo);
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
        private void btnTipoVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridTipo[2, gridTipo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridTipo);
                ((frmMetodo)formulario).Text = "Visualizando Método";
                ((frmMetodo)formulario).disabledForm();
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
        private void btnTipoIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridTipo);
                ((frmMetodo)formulario).Text = "Inserindo Método";
                ((frmMetodo)formulario).enabledForm();
                ((frmMetodo)formulario).defineFoco();
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
        private void btnTipoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridTipo[2, gridTipo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridTipo);
                ((frmMetodo)formulario).Text = "Editando Método";
                ((frmMetodo)formulario).enabledForm();
                ((frmMetodo)formulario).defineFoco();
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
        private void btnTipoExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridTipo[2, gridTipo.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridTipo.DataSource = null;
                    funcoes.gridMetodo(gridTipo, string.Empty);
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
        }
        private void gridTipo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnTipoEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridTipo[2, gridTipo.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridTipo);
                    ((frmMetodo)formulario).Text = "Editando Método";
                    ((frmMetodo)formulario).enabledForm();
                    ((frmMetodo)formulario).defineFoco();
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
        private void GridTipo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermTipo(gridTipo);
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
        private void gridTipo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridTipo[2, gridTipo.CurrentRow.Index].Value.ToString();
                Descricao = gridTipo[4, gridTipo.CurrentRow.Index].Value.ToString();
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

        private void tabMetodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabMetodo.SelectedIndex.Equals(1))
                {
                    funcoes.gridMetodo(gridCodigo, string.Empty);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
                else if (tabMetodo.SelectedIndex.Equals(0))
                {
                    funcoes.gridMetodo(gridDesc, string.Empty);
                    txtDesc.Text = string.Empty;
                    txtDesc.Focus();
                }
                else if (tabMetodo.SelectedIndex.Equals(2))
                {
                    funcoes.gridMetodo(gridTipo, string.Empty);
                    cboTipo.Text = string.Empty;
                    cboTipo.Focus();
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
        private void frmMetodoBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridMetodo(gridDesc, string.Empty);

                //verificar permissão de acesso
                verPermDesc(gridDesc);
                verPermCodigo(gridCodigo);
                verPermTipo(gridTipo);

                //definir as imagens
                pctSolfejo.Image = imgMetodo.Images[0];
                pctInstrumento.Image = imgMetodo.Images[1];
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
                if (Pesquisa.Equals("Metodo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_metodos();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridMetodo(dataGrid, string.Empty);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_metodos();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridMetodo(dataGrid, string.Empty);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Desc"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_metodos();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridMetodo(dataGrid, string.Empty);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Tipo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_metodos();
                    lista = objBLL.buscarTipo(Campo);
                    funcoes.gridMetodo(dataGrid, string.Empty);
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
                preencher(Codigo);
                formulario = new frmMetodo(this, dataGrid, lista);
                ((frmMetodo)formulario).MdiParent = MdiParent;
                ((frmMetodo)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmMetodo)formulario));
                ((frmMetodo)formulario).Show();
                ((frmMetodo)formulario).BringToFront();
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
        /// <param name="CodMetodo"></param>
        internal void preencher(string CodMetodo)
        {
            try
            {
                objBLL = new BLL_metodos();
                lista = objBLL.buscarCod(CodMetodo);
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
        /// Função que define a imagem do status da conta, se ativo ou inativo
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (linha.Cells["Tipo"].Value.ToString().Contains("Solfejo"))
                    {
                        linha.Cells[0].Value = imgMetodo.Images[0];
                    }
                    else if (linha.Cells["Tipo"].Value.ToString().Contains("Instrumento"))
                    {
                        linha.Cells[0].Value = imgMetodo.Images[1];
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
        private MOD_metodos criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_metodos();
                objEnt.CodMetodo = Codigo;
                objEnt.DescMetodo = Descricao;

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
            txtDesc.Focus();
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermCodigo(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoMetodo entAcesso = new MOD_acessoMetodo();
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetodo))
                    {
                        btnCodIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotEditMetodo))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetodo))
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
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotVisMetodo))
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
        internal void verPermDesc(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoMetodo entAcesso = new MOD_acessoMetodo();
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetodo))
                    {
                        btnDescIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotEditMetodo))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnDescEditar.Enabled = true;
                        }
                        else
                        {
                            btnDescEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetodo))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnDescExc.Enabled = true;
                        }
                        else
                        {
                            btnDescExc.Enabled = false;
                        }
                    }
                    //verificando o botão visualizar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotVisMetodo))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnDescVisual.Enabled = true;
                        }
                        else
                        {
                            btnDescVisual.Enabled = false;
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
        internal void verPermTipo(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoMetodo entAcesso = new MOD_acessoMetodo();
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotInsMetodo))
                    {
                        btnTipoIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotEditMetodo))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnTipoEditar.Enabled = true;
                        }
                        else
                        {
                            btnTipoEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotExcMetodo))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnTipoExc.Enabled = true;
                        }
                        else
                        {
                            btnTipoExc.Enabled = false;
                        }
                    }
                    //verificando o botão visualizar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(entAcesso.rotVisMetodo))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnTipoVisual.Enabled = true;
                        }
                        else
                        {
                            btnTipoVisual.Enabled = false;
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
