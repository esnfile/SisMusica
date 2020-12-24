using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.administracao;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.administracao;

namespace ccbadm
{
    public partial class frmTipoReuniaoBusca : Form
    {
        public frmTipoReuniaoBusca(List<MOD_acessos> listaLibAcesso)
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

        BLL_tipoReuniao objBLL = null;
        MOD_tipoReuniao objEnt = null;
        List<MOD_tipoReuniao> lista;

        Form formulario;

        List<MOD_acessos> listaAcesso = null;

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
                Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmTipoReuniao)formulario).Text = "Visualizando Tipo de Reunião";
                ((frmTipoReuniao)formulario).disabledForm();
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
                ((frmTipoReuniao)formulario).Text = "Inserindo Tipo de Reunião";
                ((frmTipoReuniao)formulario).enabledForm();
                ((frmTipoReuniao)formulario).defineFoco();
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
                Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmTipoReuniao)formulario).Text = "Editando Tipo de Reunião";
                ((frmTipoReuniao)formulario).enabledForm();
                ((frmTipoReuniao)formulario).defineFoco();
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
                    Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridDesc.DataSource = null;
                    funcoes.gridTipoReuniao(gridDesc);
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
                    Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridDesc);
                    ((frmTipoReuniao)formulario).Text = "Editando Tipo de Reunião";
                    ((frmTipoReuniao)formulario).enabledForm();
                    ((frmTipoReuniao)formulario).defineFoco();
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
                Codigo = gridDesc["CodTipoReuniao", gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = gridDesc["DescTipoReuniao", gridDesc.CurrentRow.Index].Value.ToString();
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

        private void frmTipoReuniaoBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridTipoReuniao(gridDesc);

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
                if (Pesquisa.Equals("TipoReuniao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_tipoReuniao();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridTipoReuniao(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Descricao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_tipoReuniao();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridTipoReuniao(dataGrid);
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
                formulario = new frmTipoReuniao(this, dataGrid, lista);
                ((frmTipoReuniao)formulario).MdiParent = MdiParent;
                ((frmTipoReuniao)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmTipoReuniao)formulario));
                ((frmTipoReuniao)formulario).Show();
                ((frmTipoReuniao)formulario).BringToFront();
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
        /// <param name="CodTipoReuniao"></param>
        internal void preencher(string CodTipoReuniao)
        {
            try
            {
                objBLL = new BLL_tipoReuniao();
                lista = objBLL.buscarCod(CodTipoReuniao);
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
        private MOD_tipoReuniao criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_tipoReuniao();
                objEnt.CodTipoReuniao = Codigo;
                objEnt.DescTipoReuniao = Descricao;

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
        internal void verPermDesc(DataGridView dataGrid)
        {
            try
            {
                btnDescIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoTipoReuniao.RotInsTipoReuniao);
                btnDescEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoTipoReuniao.RotEditTipoReuniao, dataGrid);
                btnDescExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoTipoReuniao.RotExcTipoReuniao, dataGrid);
                btnDescVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoTipoReuniao.RotVisTipoReuniao, dataGrid);
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
