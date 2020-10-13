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

namespace ccbimp
{
    public partial class frmPesquisaComumImp : Form
    {
        public frmPesquisaComumImp()
        {
            InitializeComponent();
        }

        #region declarações

        //variaveis
        public string Codigo;
        string Descricao;

        BLL_ccb objBLL = null;
        List<MOD_ccb> lista;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        private void txtDesc_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnDesc;
        }
        private void txtDesc_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnSel;
        }
        private void btnDesc_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (string.IsNullOrEmpty(txtDesc.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        carregaGrid(txtDesc.Text);
                    }
                }
                else
                {
                    carregaGrid(txtDesc.Text);
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
        private void btnSel_Click(object sender, EventArgs e)
        {
            if (!btnSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    //chama a rotina para preencher dados
                    Codigo = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
                    DialogResult = DialogResult.OK;
                    //fecha o formulário
                    Close();
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
                if (gridDesc.RowCount > 0)
                {
                    btnSel.Enabled = true;
                }
                else
                {
                    btnSel.Enabled = false;
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
        private void gridDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = gridDesc[4, gridDesc.CurrentRow.Index].Value.ToString();
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
        private void gridDesc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridDesc[2, gridDesc.CurrentRow.Index].Value.ToString();
                    DialogResult = DialogResult.OK;
                    //fecha o formulário
                    Close();
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

        #region Eventos do Formulario

        private void frmPesquisaComumImp_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridCCB(gridDesc);
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
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmPesquisaComumImp_Activated(object sender, EventArgs e)
        {
            defineFoco();
        }

        #endregion

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo1"></param>
        internal void carregaGrid(string Comum)
        {
            try
            {
                //chama a classe de negócios
                objBLL = new BLL_ccb();
                lista = objBLL.buscarDescricao(Comum);
                funcoes.gridCCB(gridDesc);
                gridDesc.DataSource = lista;
                definirImagens(gridDesc);
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
        /// Função que define o Foco do cursor
        /// </summary>
        private void defineFoco()
        {
            txtDesc.Focus();
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

        #endregion

    }
}
