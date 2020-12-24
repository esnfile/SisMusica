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
using ENT.importa;
using BLL.importa;

namespace ccbimp
{
    public partial class frmImportarPessoaBusca : Form
    {
        public frmImportarPessoaBusca(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;

                txtDataInicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtDataFinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
        string DataImporta;
        string Usuario;

        IBLL_buscaPorCodImportaPessoa objBLL = null;
        MOD_importaPessoa objEnt = null;
        List<MOD_importaPessoa> lista;

        Form formulario;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        private void txtDataInicial_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnData;
        }
        private void txtDataInicial_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnData;
        }
        private void btnDataInicial_Click(object sender, EventArgs e)
        {
            txtDataInicial.Text = funcoes.FormataData("01/01/1990");
        }
        private void btnDataFinal_Click(object sender, EventArgs e)
        {
            txtDataFinal.Text = funcoes.FormataData("31/12/2050");
        }
        private void txtDataFinal_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnData;
        }
        private void txtDataFinal_Leave(object sender, EventArgs e)
        {
        }
        private void btnData_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                 carregaGrid("Data", txtDataInicial.Text, txtDataFinal.Text, gridData);
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
        private void btnDataVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridData[0, gridData.CurrentRow.Index].Value.ToString();
                abrirForm("frmSucesso", gridData);
                ((frmImportarPessoaSucesso)formulario).Text = "Visualizando Importação";
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
        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnDataVisual.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridData[0, gridData.CurrentRow.Index].Value.ToString();
                    abrirForm("frmSucesso", gridData);
                    ((frmImportarPessoaSucesso)formulario).Text = "Visualizando Importação";
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
        private void gridData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridData[0, gridData.CurrentRow.Index].Value.ToString();
                DataImporta = gridData[1, gridData.CurrentRow.Index].Value.ToString();
                Usuario = gridData[2, gridData.CurrentRow.Index].Value.ToString();
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
        private void gridData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermData(gridData);
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

        private void frmImportarPessoaBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridImportaPessoa(gridData);

                //verificar permissão de acesso
                verPermData(gridData);

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
        internal void carregaGrid(string Pesquisa, string Campo1, string Campo2, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_buscaPorCodImportaPessoa();
                    lista = objBLL.Buscar(Campo1);
                    funcoes.gridImportaPessoa(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Data"))
                {
                    //chama a classe de negócios
                    IBLL_buscaPorDataImportaPessoa objBLL_Data = new BLL_buscaPorDataImportaPessoa();
                    lista = objBLL_Data.Buscar(Campo1, Campo2);
                    funcoes.gridImportaPessoa(dataGrid);
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
                if (form.Equals("frmSucesso"))
                {
                    preencher(Codigo);
                    formulario = new frmImportarPessoaSucesso(this, gridData, lista);
                    ((frmImportarPessoaSucesso)formulario).MdiParent = MdiParent;
                    ((frmImportarPessoaSucesso)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmImportarPessoaSucesso)formulario));
                    ((frmImportarPessoaSucesso)formulario).Show();
                    ((frmImportarPessoaSucesso)formulario).BringToFront();
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
        /// <param name="CodImporta"></param>
        internal void preencher(string CodImporta)
        {
            try
            {
                objBLL = new BLL_buscaPorCodImportaPessoa();
                lista = objBLL.Buscar(CodImporta);
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
        private MOD_importaPessoa criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_importaPessoa();
                objEnt.CodImportaPessoa = Codigo;
                objEnt.DataImporta = DataImporta;
                objEnt.Usuario = Usuario;

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
            txtDataInicial.Focus();
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermData(DataGridView dataGrid)
        {
            try
            {
                btnDataVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoImportaPessoa.RotVisImportaPessoa, dataGrid);
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