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
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.pessoa;
using ENT.uteis;

namespace ccbpess
{
    public partial class frmCargoBusca : Form
    {
        public frmCargoBusca(List<MOD_acessos> listaLibAcesso)
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

        BLL_cargo objBLL = null;
        MOD_cargo objEnt = null;
        List<MOD_cargo> lista;

        Form formulario;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        private void txtDesc_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnDesc;
        }
        private void txtNome_Leave(object sender, EventArgs e)
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
                ((frmCargo)formulario).Text = "Visualizando Cargo";
                ((frmCargo)formulario).disabledForm();
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
                ((frmCargo)formulario).Text = "Inserindo Cargo";
                ((frmCargo)formulario).enabledForm();
                ((frmCargo)formulario).defineFoco();
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
                ((frmCargo)formulario).Text = "Editando Cargo";
                ((frmCargo)formulario).enabledForm();
                ((frmCargo)formulario).defineFoco();
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
                    funcoes.gridCargo(gridDesc, string.Empty);
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
                    ((frmCargo)formulario).Text = "Editando Cargo";
                    ((frmCargo)formulario).enabledForm();
                    ((frmCargo)formulario).defineFoco();
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
                Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
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

        #region Eventos do Formulario

        private void frmCargoBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridCargo(gridDesc, string.Empty);

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
                if (Pesquisa.Equals("Cargo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_cargo();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridCargo(dataGrid, string.Empty);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Descricao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_cargo();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridCargo(dataGrid, string.Empty);
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
                formulario = new frmCargo(this, dataGrid, lista);
                ((frmCargo)formulario).MdiParent = MdiParent;
                ((frmCargo)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmCargo)formulario));
                ((frmCargo)formulario).Show();
                ((frmCargo)formulario).BringToFront();
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
        /// <param name="CodCargo"></param>
        internal void preencher(string CodCargo)
        {
            try
            {
                objBLL = new BLL_cargo();
                lista = objBLL.buscarCod(CodCargo);
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
        private MOD_cargo criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_cargo();
                objEnt.CodCargo = Codigo;
                objEnt.DescCargo = Descricao;

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
                MOD_acessoCargo entAcesso = new MOD_acessoCargo();
                btnDescIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsCargo);
                btnDescEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditCargo, dataGrid);
                btnDescExc.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotExcCargo, dataGrid);
                btnDescVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisCargo, dataGrid);
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
