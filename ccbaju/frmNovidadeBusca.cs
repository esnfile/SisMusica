using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.ajuda;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.ajuda;

namespace ccbaju
{
    public partial class frmNovidadeBusca : Form
    {
        public frmNovidadeBusca()
        {
            InitializeComponent();
            try
            {
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

        BLL_novidades objBLL = null;
        MOD_novidades objEnt = null;
        List<MOD_novidades> lista;

        Form formulario;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

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
                carregaGrid("Descricao", txtDesc.Text, gridDesc);
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
                Codigo = gridDesc["CodNovidades", gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmNovidade)formulario).Text = "Visualizando Novidades";
                ((frmNovidade)formulario).disabledForm();
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
                ((frmNovidade)formulario).Text = "Inserindo Novidades";
                ((frmNovidade)formulario).enabledForm();
                ((frmNovidade)formulario).defineFoco();
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
                Codigo = gridDesc["CodNovidades", gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmNovidade)formulario).Text = "Editando Novidades";
                ((frmNovidade)formulario).enabledForm();
                ((frmNovidade)formulario).defineFoco();
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
                    Codigo = gridDesc["CodNovidades", gridDesc.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridDesc.DataSource = null;
                    funcoes.gridNovidade(gridDesc);
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
                    Codigo = gridDesc["CodNovidades", gridDesc.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridDesc);
                    ((frmNovidade)formulario).Text = "Editando Novidades";
                    ((frmNovidade)formulario).enabledForm();
                    ((frmNovidade)formulario).defineFoco();
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
                Codigo = gridDesc["CodNovidades", gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = gridDesc["Descricao", gridDesc.CurrentRow.Index].Value.ToString();
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

        private void frmNovidadeBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //Definir as imagens do pctbox
                pctImplementa.Image = imgNovidade.Images[3];
                pctTeste.Image = imgNovidade.Images[1];
                pctAprova.Image = imgNovidade.Images[2];
                pctPublica.Image = imgNovidade.Images[0];

                //chama a funcão montar grid
                funcoes.gridNovidade(gridDesc);
                //verificar permissão de acesso
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
                if (Pesquisa.Equals("Novidade"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_novidades();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridNovidade(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_novidades();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridNovidade(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Descricao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_novidades();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridNovidade(dataGrid);
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
                formulario = new frmNovidade(this, dataGrid, lista);
                ((frmNovidade)formulario).MdiParent = MdiParent;
                ((frmNovidade)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmNovidade)formulario));
                ((frmNovidade)formulario).Show();
                ((frmNovidade)formulario).BringToFront();
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
        /// <param name="CodNov"></param>
        internal void preencher(string CodNov)
        {
            try
            {
                objBLL = new BLL_novidades();
                lista = objBLL.buscarCod(CodNov);
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
        private MOD_novidades criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_novidades();
                objEnt.CodNovidades = Codigo;
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
        /// Função que define a imagem do Andamento das Novidades
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (linha.Cells["Andamento"].Value.ToString().Contains("A Implementar"))
                    {
                        linha.Cells["img"].Value = imgNovidade.Images[3];
                    }
                    else if (linha.Cells["Andamento"].Value.ToString().Contains("Em Teste"))
                    {
                        linha.Cells["img"].Value = imgNovidade.Images[1];
                    }
                    else if (linha.Cells["Andamento"].Value.ToString().Contains("Aprovada"))
                    {
                        linha.Cells["img"].Value = imgNovidade.Images[2];
                    }
                    else if (linha.Cells["Andamento"].Value.ToString().Contains("Publicada"))
                    {
                        linha.Cells["img"].Value = imgNovidade.Images[0];
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
        internal void verPermDesc(DataGridView dataGrid)
        {
            try
            {
                if (Convert.ToInt32(modulos.CodUsuario).Equals(1))
                {
                    //verificando o botão inserir
                    btnDescIns.Enabled = true;

                    //verificando os outros botoes
                    if (dataGrid.Rows.Count > 0)
                    {
                        btnDescEditar.Enabled = true;
                        btnDescVisual.Enabled = true;
                        btnDescExc.Enabled = true;
                    }
                    else
                    {
                        btnDescEditar.Enabled = false;
                        btnDescExc.Enabled = false;
                        btnDescVisual.Enabled = false;
                    }
                }
                else
                {
                    //verificando o botão inserir
                    btnDescIns.Enabled = false;

                    //verificando os outros botoes
                    if (dataGrid.Rows.Count > 0)
                    {
                        btnDescEditar.Enabled = false;
                        btnDescVisual.Enabled = true;
                        btnDescExc.Enabled = false;
                    }
                    else
                    {
                        btnDescEditar.Enabled = false;
                        btnDescExc.Enabled = false;
                        btnDescVisual.Enabled = false;
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
