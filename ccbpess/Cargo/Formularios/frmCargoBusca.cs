using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using BLL.cargo;
using BLL.Funcoes;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.pessoa;
using sismus.Controllers;

namespace ccbpess
{
    public partial class frmCargoBusca : Form
    {
        public frmCargoBusca()
        {
            InitializeComponent();
        }

        #region declarações

        //variaveis
        int codigo;
        string descricao;

        IBLL_buscaCargo objBLL_Busca;
        IBLL_Cargo objBLL_Cargo;
        MOD_cargo objEnt = null;
        List<MOD_cargo> lista;

        Form formulario;

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
                CarregaGrid(BuscaCargoPorDescricao(txtDesc.Text), gridDesc);
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
                codigo = Convert.ToInt32(gridDesc["CodCargo", gridDesc.CurrentRow.Index].Value);
                AbrirForm(string.Empty, gridDesc, codigo);
                ((frmCargo)formulario).Text = "Visualizando Cargo";
                ((frmCargo)formulario).DisabledForm();
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
                //chama a rotina para abrir o formulario
                AbrirForm(string.Empty, gridDesc, 0);
                ((frmCargo)formulario).Text = "Inserindo Cargo";
                ((frmCargo)formulario).EnabledForm();
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
                codigo = Convert.ToInt32(gridDesc["CodCargo", gridDesc.CurrentRow.Index].Value);
                AbrirForm(string.Empty, gridDesc, codigo);
                ((frmCargo)formulario).Text = "Editando Cargo";
                ((frmCargo)formulario).EnabledForm();
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
                    codigo = Convert.ToInt32(gridDesc["CodCargo", gridDesc.CurrentRow.Index].Value);

                    using (CargoController apiCargo = new CargoController()) { apiCargo.Delete(codigo); }

                    //chama a funcão montar grid
                    using (IBLL_DataGridView grid = new BLL_GridCargo()) { grid.MontarGrid(gridDesc, string.Empty); }
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
                    codigo = Convert.ToInt32(gridDesc["CodCargo", gridDesc.CurrentRow.Index].Value);

                    AbrirForm(string.Empty, gridDesc, codigo);
                    ((frmCargo)formulario).Text = "Editando Cargo";
                    ((frmCargo)formulario).EnabledForm();
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
        private void gridDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                codigo = Convert.ToInt32(gridDesc["CodCargo", gridDesc.CurrentRow.Index].Value);
                descricao = gridDesc["DescCargo", gridDesc.CurrentRow.Index].Value.ToString();
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
        private void gridDesc_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                VerPermDesc(gridDesc);
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
                using (IBLL_DataGridView grid = new BLL_GridCargo()) { grid.MontarGrid(gridDesc, string.Empty); }
                //verificar permissão de acesso
                VerPermDesc(gridDesc);
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
        private void frmCargoBusca_Activated(object sender, EventArgs e)
        {
            DefineFoco();
        }

        #endregion

        #endregion

    }
}