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
    public partial class frmVersaoBusca : Form
    {
        public frmVersaoBusca()
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

        BLL_versao objBLL = null;
        MOD_versao objEnt = null;
        List<MOD_versao> lista;

        Form formulario;

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
                ((frmVersao)formulario).Text = "Inserindo Versão";
                ((frmVersao)formulario).enabledForm();
                ((frmVersao)formulario).defineFoco();
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
                Codigo = gridCodigo["CodVersao", gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmVersao)formulario).Text = "Visualizando Versão";
                ((frmVersao)formulario).disabledForm();
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
                Codigo = gridCodigo["CodVersao", gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmVersao)formulario).Text = "Editando Versão";
                ((frmVersao)formulario).enabledForm();
                ((frmVersao)formulario).defineFoco();
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
                    Codigo = gridCodigo["CodVersao", gridCodigo.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.excluir(criarTabela());

                    gridCodigo.DataSource = null;
                    funcoes.gridVersao(gridCodigo);
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
                    Codigo = gridCodigo["CodVersao", gridCodigo.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCodigo);
                    ((frmVersao)formulario).Text = "Editando Versão";
                    ((frmVersao)formulario).enabledForm();
                    ((frmVersao)formulario).defineFoco();
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
                if (gridCodigo.Rows.Count > 0)
                {
                    btnCodEditar.Enabled = true;
                    btnCodVisual.Enabled = true;
                    btnCodExc.Enabled = true;
                }
                else
                {
                    btnCodEditar.Enabled = false;
                    btnCodVisual.Enabled = false;
                    btnCodExc.Enabled = false;
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
        private void gridCodigo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridCodigo["CodVersao", gridCodigo.CurrentRow.Index].Value.ToString();
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

        private void tabVersao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabVersao.SelectedIndex.Equals(1))
                {
                    funcoes.gridVersao(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
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
        private void frmVersaoBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridVersao(gridCodigo);
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
                if (Pesquisa.Equals("Versao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_versao();
                    lista = objBLL.buscarVersao(Campo);
                    funcoes.gridVersao(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_versao();
                    lista = objBLL.buscarVersao(Campo);
                    funcoes.gridVersao(dataGrid);
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
                formulario = new frmVersao(this, dataGrid, lista);
                ((frmVersao)formulario).MdiParent = MdiParent;
                ((frmVersao)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmVersao)formulario));
                ((frmVersao)formulario).Show();
                ((frmVersao)formulario).BringToFront();
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
        /// <param name="CodVersao"></param>
        internal void preencher(string CodVersao)
        {
            try
            {
                objBLL = new BLL_versao();
                lista = objBLL.buscarVersao(CodVersao);
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
        private MOD_versao criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_versao();
                objEnt.CodVersao = Codigo;

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
            txtCodigo.Focus();
        }

        #endregion

    }
}