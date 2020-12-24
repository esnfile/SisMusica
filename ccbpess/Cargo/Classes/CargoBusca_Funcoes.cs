using BLL.Funcoes;
using ENT.pessoa;
using sismus.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace ccbpess
{
    public partial class frmCargoBusca
    {

        /// <summary>
        /// Função que carrega a pesquisa, apenas informar a Lista de Dados e o grid que será preenchido
        /// </summary>
        /// <param name="listaCargo"></param>
        /// <param name="DataGrid"></param>
        internal void CarregaGrid(List<MOD_cargo> listaCargo, DataGridView dataGrid)
        {
            try
            {
                dataGrid.DataSource = listaCargo;
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
        private void AbrirForm(string form, DataGridView dataGrid, int codigo)
        {
            try
            {
                formulario = new frmCargo(this, dataGrid, codigo);
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
        /// Função que define o foco do cursor
        /// </summary>
        private void DefineFoco()
        {
            txtDesc.Focus();
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        private void VerPermDesc(DataGridView dataGrid)
        {
            try
            {
                btnDescIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoCargo.RotInsCargo);
                btnDescEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoCargo.RotEditCargo, dataGrid);
                btnDescExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoCargo.RotExcCargo, dataGrid);
                btnDescVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoCargo.RotVisCargo, dataGrid);
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
        /// Efetua a Busca de Cargo pelo Código
        /// </summary>
        /// <param name="codCargo"></param>
        /// <returns></returns>
        private List<MOD_cargo> BuscaCargoPorCodigo(string codCargo)
        {
            try
            {
                using (CargoController apiCargo = new CargoController())
                    return apiCargo.BuscaCargoPorCodigo(Convert.ToInt32(codCargo)).ToList();
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
        /// Efetua a Busca de Cargo pela Descrição
        /// </summary>
        /// <param name="descCargo"></param>
        /// <returns></returns>
        private List<MOD_cargo> BuscaCargoPorDescricao(string descCargo)
        {
            try
            {
                using (CargoController apiCargo = new CargoController())
                    return apiCargo.BuscaCargoPorDescricao(descCargo).ToList();
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
        /// Efetua a Busca de Cargo pelo Departamento
        /// </summary>
        /// <param name="codDepartamento"></param>
        /// <returns></returns>
        private List<MOD_cargo> BuscaCargoPorDepartamento(string codDepartamento)
        {
            try
            {
                using (CargoController apiCargo = new CargoController())
                    return apiCargo.BuscaCargoPorDepartamento(Convert.ToInt32(codDepartamento)).ToList();
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

    }
}