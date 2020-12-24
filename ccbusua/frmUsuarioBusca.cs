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
using BLL.Usuario;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.pessoa;

namespace ccbusua
{
    public partial class frmUsuarioBusca : Form
    {
        public frmUsuarioBusca(List<MOD_acessos> listaLibAcesso)
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

        BLL_usuario objBLL = null;
        MOD_usuario objEnt = null;
        List<MOD_usuario> lista;

        IBLL_buscaPessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa = null;

        Form formulario;
        Form formChama;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

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
                        carregaGrid("Usuario", txtNome.Text, gridNome);
                    }
                }
                else
                {
                    carregaGrid("Usuario", txtNome.Text, gridNome);
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
                ((frmUsuario)formulario).Text = "Visualizando Usuário";
                ((frmUsuario)formulario).disabledForm();
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
                ((frmUsuario)formulario).Text = "Inserindo Usuário";
                ((frmUsuario)formulario).enabledForm();
                ((frmUsuario)formulario).defineFoco();
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
                    ((frmUsuario)formulario).Text = "Editando Usuário";
                    ((frmUsuario)formulario).enabledForm();
                    ((frmUsuario)formulario).defineFoco();
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
                    funcoes.gridUsuario(gridNome);
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
                    ((frmUsuario)formulario).Text = "Editando Usuário";
                    ((frmUsuario)formulario).enabledForm();
                    ((frmUsuario)formulario).defineFoco();
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
                Descricao = gridNome[3, gridNome.CurrentRow.Index].Value.ToString();
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

        #region Aba Pessoa

        private void lblCodPessoa_TextChanged(object sender, EventArgs e)
        {
            if (!lblCodPessoa.Text.Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaGrid("Pessoa", lblCodPessoa.Text, gridPessoa);
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
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", gridPessoa);
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
        private void btnPesVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridPessoa[2, gridPessoa.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridPessoa);
                ((frmUsuario)formulario).Text = "Visualizando Usuário";
                ((frmUsuario)formulario).disabledForm();
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
        private void btnPesIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridPessoa);
                ((frmUsuario)formulario).Text = "Inserindo Usuário";
                ((frmUsuario)formulario).enabledForm();
                ((frmUsuario)formulario).defineFoco();
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
        private void btnPesEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridPessoa[2, gridPessoa.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridPessoa);
                ((frmUsuario)formulario).Text = "Editando Usuário";
                ((frmUsuario)formulario).enabledForm();
                ((frmUsuario)formulario).defineFoco();
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
        private void btnPesExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridPessoa[2, gridPessoa.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.excluir(criarTabela());

                    gridPessoa.DataSource = null;
                    funcoes.gridUsuario(gridPessoa);
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
                AcceptButton = btnPessoa;
            }
        }
        private void gridPessoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnPesEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridPessoa[2, gridPessoa.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridPessoa);
                    ((frmUsuario)formulario).Text = "Editando Usuário";
                    ((frmUsuario)formulario).enabledForm();
                    ((frmUsuario)formulario).defineFoco();
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
        private void gridPessoa_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermPessoa(gridPessoa);
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
        private void gridPessoa_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridPessoa[2, gridPessoa.CurrentRow.Index].Value.ToString();
                Descricao = gridPessoa[3, gridPessoa.CurrentRow.Index].Value.ToString();
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

        private void tabUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabUsuario.SelectedIndex.Equals(0))
                {
                    funcoes.gridUsuario(gridNome);
                    txtNome.Text = string.Empty;
                    txtNome.Focus();
                }
                else if (tabUsuario.SelectedIndex.Equals(1))
                {
                    funcoes.gridUsuario(gridPessoa);
                    lblCodPessoa.Text = string.Empty;
                    lblNomePessoa.Text = string.Empty;
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
        private void frmUsuarioBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridUsuario(gridNome);

                //verificar permissão de acesso
                verPermNome(gridNome);
                verPermPessoa(gridPessoa);

                //definir as imagens
                pctAtivo.Image = imgUsuario.Images[0];
                pctInativo.Image = imgUsuario.Images[1];
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
                if (Pesquisa.Equals("Usuario"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_usuario();
                    lista = objBLL.buscarUsuario(Campo);
                    funcoes.gridUsuario(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_usuario();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridUsuario(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Pessoa"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_usuario();
                    lista = objBLL.buscarPessoa(Campo);
                    funcoes.gridUsuario(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("NomePessoa"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_usuario();
                    lista = objBLL.buscarNome(Campo);
                    funcoes.gridUsuario(dataGrid);
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
                if (form.Equals("frmPes"))
                {
                    lblNomePessoa.Text = string.Empty;
                    lblCodPessoa.Text = string.Empty;

                    formChama = new frmPesquisaPessoa(this);
                    ((frmPesquisaPessoa)formChama).MdiParent = MdiParent;
                    ((frmPesquisaPessoa)formChama).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaPessoa)formChama));
                    ((frmPesquisaPessoa)formChama).Show();
                    ((frmPesquisaPessoa)formChama).BringToFront();
                    Enabled = false;
                }
                else
                {
                    preencher(Codigo);

                    formulario = new frmUsuario(this, dataGrid, lista);
                    ((frmUsuario)formulario).MdiParent = MdiParent;
                    ((frmUsuario)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmUsuario)formulario));
                    ((frmUsuario)formulario).Show();
                    ((frmUsuario)formulario).BringToFront();
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="CodUsuario"></param>
        internal void preencher(string CodUsuario)
        {
            try
            {
                objBLL = new BLL_usuario();
                lista = objBLL.buscarCod(CodUsuario);

                //Verifica se o usuario a ser editado não é o usuario 1
                BLL_Liberacoes.LiberaEdicaoAdm(Convert.ToInt32(Codigo), lista);
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
                    if (linha.Cells["Ativo"].Value.ToString().Contains("Sim"))
                    {
                        linha.Cells[0].Value = imgUsuario.Images[0];
                    }
                    else if (linha.Cells["Ativo"].Value.ToString().Contains("Não"))
                    {
                        linha.Cells[0].Value = imgUsuario.Images[1];
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
        private MOD_usuario criarTabela()
        {
            try
            {

                //Verifica se o usuario a ser editado não é o usuario 1
                funcoes.liberaEdicaoAdm(Convert.ToInt32(Codigo));

                //preenche o objeto da tabela Logs
                objEnt = new MOD_usuario();
                objEnt.CodUsuario = Codigo;
                objEnt.Nome = Descricao;

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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa"></param>
        internal void carregaPessoa(string vCodPessoa)
        {
            try
            {
                objBLL_Pessoa = new BLL_buscaPessoaPorCodPessoa();
                listaPessoa = objBLL_Pessoa.Buscar(vCodPessoa);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    lblCodPessoa.Text = listaPessoa[0].CodPessoa;
                    lblNomePessoa.Text = listaPessoa[0].CodPessoa.PadLeft(6,'0') + " - " + listaPessoa[0].Nome;
                }
                else
                {
                    abrirForm("frmPes", gridPessoa);
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
        internal void verPermNome(DataGridView dataGrid)
        {
            try
            {
                //verificando o botão inserir
                btnNomeIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotInsUsuario);
                btnNomeEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotEditUsuario, dataGrid);
                btnNomeExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotExcUsuario, dataGrid);
                btnNomeVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotVisUsuario, dataGrid);
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
        internal void verPermPessoa(DataGridView dataGrid)
        {
            try
            {
                //verificando o botão inserir
                btnPesIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotInsUsuario);
                btnPesEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotEditUsuario, dataGrid);
                btnPesExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotExcUsuario, dataGrid);
                btnPesVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotVisUsuario, dataGrid);
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
