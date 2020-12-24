using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using ENT.uteis;
using BLL.uteis;
using BLL.Funcoes;
using ENT.Erros;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using BLL.pessoa;
using ENT.pessoa;
using BLL.cargo;

namespace ccbpess
{
    public partial class frmCargo : Form
    {

        public frmCargo(Form forms, DataGridView gridPesquisa, int codigo)
        {
            InitializeComponent();

            try
            {
                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///carrega os estados
                apoio.carregaComboDepartament(cboDepartamento);

                ///Verifica se está sendo solicitado inclusão de novo registro 
                ///ou alteração de registro existente
                ///Caso codigo seja  = 0 (Está em modo de inserção)
                if (!0.Equals(codigo))
                    listaCargo = Preencher(BuscaCargoPorCodigo(codigo));
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

        #region declaracoes

        clsException excp;

        IBLL_Cargo objBLL = null;
        MOD_cargo objEnt = null;
        List<MOD_cargo> listaCargo = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        #endregion

        #region Eventos do Formulario

        #region Atendimento

        private void ChkAtGem_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtEnsLoc_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtEnsReg_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtEnsParc_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtEnsTec_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChkPreRjmMus_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkPreRjmOrg_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkPreCultoMus_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkPreCultoOrg_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkPreOficialMus_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkPreOficialOrg_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChkTesRjmMus_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkTesRjmOrg_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkTesCultoMus_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkTesCultoOrg_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkTesOficialMus_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkTesOficialOrg_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChkAtBatismo_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtCeia_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtReunMin_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtOrdenacao_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtRjm_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtReunMoc_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkAtCasal_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void OptAtComSim_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void OptAtComNao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAtComNao.Checked.Equals(true))
                {
                    optAtRegNao.Checked = true;
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void OptAtRegSim_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAtRegSim.Checked.Equals(true))
                {
                    optAtComSim.Checked = true;
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void OptAtRegNao_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void ChkMasculino_CheckedChanged(object sender, EventArgs e)
        {
            VerPermAtendimento();
        }
        private void ChkFeminino_CheckedChanged(object sender, EventArgs e)
        {
            VerPermAtendimento();
        }
        private void ChkPermiteInstr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPermiteInstr.Checked.Equals(true))
            {
                gpoDesenvolvimento.Enabled = true;
            }
            else
            {
                chkAlunoGem.Checked = false;
                chkMeiaHora.Checked = false;
                chkRjm.Checked = false;
                chkCulto.Checked = false;
                chkOficial.Checked = false;
                chkEnsaio.Checked = false;
                gpoDesenvolvimento.Enabled = false;
            }
        }

        private void ChkAlunoGem_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkEnsaio_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkMeiaHora_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkRjm_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkCulto_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void ChkOficial_CheckedChanged(object sender, EventArgs e)
        {
        }

        #endregion

        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                Salvar();
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
                apoio.FecharAguardeGravar();
            }
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
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
        }
        private void FrmCargo_Load(object sender, EventArgs e)
        {
            try
            {
                ///Verifica as liberações
                Verificacoes();

                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                VerPermAtendimento();
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
        private void FrmCargo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Cargo"))
                {
                    e.Cancel = false;
                }
                else
                {
                    DialogResult sair;
                    sair = MessageBox.Show(modulos.msgSalvar, "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (sair.Equals(DialogResult.Yes))
                    {
                        Salvar();
                    }
                    else if (sair.Equals(DialogResult.Cancel))
                    {
                        e.Cancel = true;
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
        private void FrmCargo_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void FrmCargo_Activated(object sender, EventArgs e)
        {
            DefineFoco();
        }

        #endregion

    }
}