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

namespace ccbpess
{
    public partial class frmCargo : Form
    {
        public frmCargo(Form forms, DataGridView gridPesquisa, List<MOD_cargo> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                //carregando a lista de permissões de acesso.
                listaAcesso = modulos.listaLibAcesso;

                ///carrega os estados
                apoio.carregaComboDepartament(cboDepartamento);

                ///Recebe a lista e armazena
                listaCargo = lista;

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);
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

        #region declaracoes

        clsException excp;

        List<MOD_acessos> listaAcesso = null;

        BLL_cargo objBLL = null;
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

        private void chkAtGem_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtGem.Checked.Equals(true))
            {
                lblAtendeGEM.Text = "Sim";
            }
            else
            {
                lblAtendeGEM.Text = "Não";
            }
        }
        private void chkAtEnsLoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtEnsLoc.Checked.Equals(true))
            {
                lblAtendeEnsLoc.Text = "Sim";
            }
            else
            {
                lblAtendeEnsLoc.Text = "Não";
            }
        }
        private void chkAtEnsReg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtEnsReg.Checked.Equals(true))
            {
                lblAtendeEnsReg.Text = "Sim";
            }
            else
            {
                lblAtendeEnsReg.Text = "Não";
            }
        }
        private void chkAtEnsParc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtEnsParc.Checked.Equals(true))
            {
                lblAtendeEnsParc.Text = "Sim";
            }
            else
            {
                lblAtendeEnsParc.Text = "Não";
            }
        }
        private void chkAtEnsTec_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtEnsTec.Checked.Equals(true))
            {
                lblAtendeEnsTec.Text = "Sim";
            }
            else
            {
                lblAtendeEnsTec.Text = "Não";
            }
        }

        private void chkPreRjmMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreRjmMus.Checked.Equals(true))
            {
                lblAtendePreTesteRjmMus.Text = "Sim";
            }
            else
            {
                lblAtendePreTesteRjmMus.Text = "Não";
            }
        }
        private void chkPreRjmOrg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreRjmOrg.Checked.Equals(true))
            {
                lblAtendePreTesteRjmOrg.Text = "Sim";
            }
            else
            {
                lblAtendePreTesteRjmOrg.Text = "Não";
            }
        }
        private void chkPreCultoMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreCultoMus.Checked.Equals(true))
            {
                lblAtendePreTesteCultoMus.Text = "Sim";
            }
            else
            {
                lblAtendePreTesteCultoMus.Text = "Não";
            }
        }
        private void chkPreCultoOrg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreCultoOrg.Checked.Equals(true))
            {
                lblAtendePreTesteCultoOrg.Text = "Sim";
            }
            else
            {
                lblAtendePreTesteCultoOrg.Text = "Não";
            }
        }
        private void chkPreOficialMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreOficialMus.Checked.Equals(true))
            {
                lblAtendePreTesteOficialMus.Text = "Sim";
            }
            else
            {
                lblAtendePreTesteOficialMus.Text = "Não";
            }
        }
        private void chkPreOficialOrg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPreOficialOrg.Checked.Equals(true))
            {
                lblAtendePreTesteOficialOrg.Text = "Sim";
            }
            else
            {
                lblAtendePreTesteOficialOrg.Text = "Não";
            }
        }

        private void chkTesRjmMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTesRjmMus.Checked.Equals(true))
            {
                lblAtendeTesteRjmMus.Text = "Sim";
            }
            else
            {
                lblAtendeTesteRjmMus.Text = "Não";
            }
        }
        private void chkTesRjmOrg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTesRjmOrg.Checked.Equals(true))
            {
                lblAtendeTesteRjmOrg.Text = "Sim";
            }
            else
            {
                lblAtendeTesteRjmOrg.Text = "Não";
            }
        }
        private void chkTesCultoMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTesCultoMus.Checked.Equals(true))
            {
                lblAtendeTesteCultoMus.Text = "Sim";
            }
            else
            {
                lblAtendeTesteCultoMus.Text = "Não";
            }
        }
        private void chkTesCultoOrg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTesCultoOrg.Checked.Equals(true))
            {
                lblAtendeTesteCultoOrg.Text = "Sim";
            }
            else
            {
                lblAtendeTesteCultoOrg.Text = "Não";
            }
        }
        private void chkTesOficialMus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTesOficialMus.Checked.Equals(true))
            {
                lblAtendeTesteOficialMus.Text = "Sim";
            }
            else
            {
                lblAtendeTesteOficialMus.Text = "Não";
            }
        }
        private void chkTesOficialOrg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTesOficialOrg.Checked.Equals(true))
            {
                lblAtendeTesteOficialOrg.Text = "Sim";
            }
            else
            {
                lblAtendeTesteOficialOrg.Text = "Não";
            }
        }

        private void chkAtBatismo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtBatismo.Checked.Equals(true))
            {
                lblAtendeBatismo.Text = "Sim";
            }
            else
            {
                lblAtendeBatismo.Text = "Não";
            }
        }
        private void chkAtCeia_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void chkAtReunMin_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtReunMin.Checked.Equals(true))
            {
                lblAtendeReunMin.Text = "Sim";
            }
            else
            {
                lblAtendeReunMin.Text = "Não";
            }
        }
        private void chkAtOrdenacao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtOrdenacao.Checked.Equals(true))
            {
                lblAtendeOrdenacao.Text = "Sim";
            }
            else
            {
                lblAtendeOrdenacao.Text = "Não";
            }
        }
        private void chkAtRjm_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtRjm.Checked.Equals(true))
            {
                lblAtendeRJM.Text = "Sim";
            }
            else
            {
                lblAtendeRJM.Text = "Não";
            }
        }
        private void chkAtReunMoc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtReunMoc.Checked.Equals(true))
            {
                lblAtendeReunMoc.Text = "Sim";
            }
            else
            {
                lblAtendeReunMoc.Text = "Não";
            }
        }
        private void chkAtCasal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtCasal.Checked.Equals(true))
            {
                lblAtendeCasal.Text = "Sim";
            }
            else
            {
                lblAtendeCasal.Text = "Não";
            }
        }

        private void optAtComSim_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAtComSim.Checked.Equals(true))
                {
                    lblAtendeComum.Text = "Sim";
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }

        }
        private void optAtComNao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAtComNao.Checked.Equals(true))
                {
                    optAtRegNao.Checked = true;
                    lblAtendeComum.Text = "Não";
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void optAtRegSim_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAtRegSim.Checked.Equals(true))
                {
                    optAtComSim.Checked = true;
                    lblAtendeRegiao.Text = "Sim";
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void optAtRegNao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optAtRegNao.Checked.Equals(true))
                {
                    lblAtendeRegiao.Text = "Não";
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void chkMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMasculino.Checked.Equals(true))
            {
                lblMasculino.Text = "Sim";
            }
            else
            {
                lblMasculino.Text = "Não";
            }
            verPermAtendimento();
        }
        private void chkFeminino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFeminino.Checked.Equals(true))
            {
                lblFeminino.Text = "Sim";
            }
            else
            {
                lblFeminino.Text = "Não";
            }
            verPermAtendimento();
        }
        private void chkPermiteInstr_CheckedChanged(object sender, EventArgs e)
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

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvar();
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
        private void btnCancelar_Click(object sender, EventArgs e)
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
        private void frmCargo_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                verPermAtendimento();
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
        private void frmCargo_FormClosing(object sender, FormClosingEventArgs e)
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
                        salvar();
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
        private void frmCargo_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                if (ValidarControles(criarTabela()))
                {
                    objBLL = new BLL_cargo();

                    if (Convert.ToInt32(txtCodigo.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.inserir(objEnt);
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.salvar(objEnt);
                    }

                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmCargoBusca"))
                    {
                        ((frmCargoBusca)formChama).carregaGrid("Cargo", objEnt.CodCargo, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmCargo_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmCargo_FormClosing);
                }
            }
            catch (ArgumentException ae)
            {
                throw new Exception(ae.Message);
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
        /// Função que valida os campos
        /// </summary>
        private bool ValidarControles(MOD_cargo cargo)
        {
            try
            {
                IValidacaoCampo valida = new ValidacaoCampo();
                List<MOD_erros> erros = valida.ValidaCamposCargo(cargo);
                if (erros.Count > 0)
                {
                    return funcoes.AbrirErros(erros);
                }
                return true;
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
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_cargo criarTabela()
        {
            try
            {
                objEnt = new MOD_cargo();
                objEnt.CodCargo = txtCodigo.Text;
                objEnt.DescCargo = txtDescricao.Text;
                objEnt.SiglaCargo = txtSigla.Text;
                objEnt.Ordem = Convert.ToString(txtOrdem.Value);
                objEnt.CodDepartamento = Convert.ToString(cboDepartamento.SelectedValue);
                objEnt.PermiteEdicao = lblPermiteEdicao.Text;
                objEnt.AtendeComum = lblAtendeComum.Text;
                objEnt.AtendeRegiao = lblAtendeRegiao.Text;
                objEnt.AtendeGEM = lblAtendeGEM.Text;
                objEnt.AtendeEnsaioLocal = lblAtendeEnsLoc.Text;
                objEnt.AtendeEnsaioRegional = lblAtendeEnsReg.Text;
                objEnt.AtendeEnsaioParcial = lblAtendeEnsParc.Text;
                objEnt.AtendeEnsaioTecnico = lblAtendeEnsTec.Text;
                objEnt.AtendeReuniaoMocidade = lblAtendeReunMoc.Text;
                objEnt.AtendeBatismo = lblAtendeBatismo.Text;
                objEnt.AtendeSantaCeia = lblAtendeSantaCeia.Text;
                objEnt.AtendeRJM = lblAtendeRJM.Text;
                objEnt.AtendePreTesteRjmMusico = lblAtendePreTesteRjmMus.Text;
                objEnt.AtendePreTesteRjmOrganista = lblAtendePreTesteRjmOrg.Text;
                objEnt.AtendePreTesteCultoMusico = lblAtendePreTesteCultoMus.Text;
                objEnt.AtendePreTesteCultoOrganista = lblAtendePreTesteCultoOrg.Text;
                objEnt.AtendePreTesteOficialMusico = lblAtendePreTesteOficialMus.Text;
                objEnt.AtendePreTesteOficialOrganista = lblAtendePreTesteOficialOrg.Text;
                objEnt.AtendeTesteRjmMusico = lblAtendeTesteRjmMus.Text;
                objEnt.AtendeTesteRjmOrganista = lblAtendeTesteRjmOrg.Text;
                objEnt.AtendeTesteCultoMusico = lblAtendeTesteCultoMus.Text;
                objEnt.AtendeTesteCultoOrganista = lblAtendeTesteCultoOrg.Text;
                objEnt.AtendeTesteOficialMusico = lblAtendeTesteOficialMus.Text;
                objEnt.AtendeTesteOficialOrganista = lblAtendeTesteOficialOrg.Text;
                objEnt.AtendeReuniaoMinisterial = lblAtendeReunMin.Text;
                objEnt.AtendeCasal = lblAtendeCasal.Text;
                objEnt.AtendeOrdenacao = lblAtendeOrdenacao.Text;
                objEnt.Masculino = lblMasculino.Text;
                objEnt.Feminino = lblFeminino.Text;
                objEnt.PermiteInstrumento = chkPermiteInstr.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.AlunoGem = chkAlunoGem.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.Ensaio = chkEnsaio.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.MeiaHora = chkMeiaHora.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.Rjm = chkRjm.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.Culto = chkCulto.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.Oficial = chkOficial.Checked.Equals(true) ? "Sim" : "Não";

                //retorna a classe de propriedades preenchida com os textbox
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
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaReg"></param>
        internal void preencher(List<MOD_cargo> listaCargo)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaCargo[0].CodCargo;
                txtDescricao.Text = listaCargo[0].DescCargo;
                txtSigla.Text = listaCargo[0].SiglaCargo;
                txtOrdem.Value = Convert.ToDecimal(listaCargo[0].Ordem);
                cboDepartamento.SelectedValue = listaCargo[0].CodDepartamento;
                lblPermiteEdicao.Text = listaCargo[0].PermiteEdicao;
                lblAtendeComum.Text = listaCargo[0].AtendeComum;
                lblAtendeRegiao.Text = listaCargo[0].AtendeRegiao;
                lblAtendeGEM.Text = listaCargo[0].AtendeGEM;
                lblAtendeEnsLoc.Text = listaCargo[0].AtendeEnsaioLocal;
                lblAtendeEnsReg.Text = listaCargo[0].AtendeEnsaioRegional;
                lblAtendeEnsParc.Text = listaCargo[0].AtendeEnsaioParcial;
                lblAtendeEnsTec.Text = listaCargo[0].AtendeEnsaioTecnico;
                lblAtendeReunMoc.Text = listaCargo[0].AtendeReuniaoMocidade;
                lblAtendeBatismo.Text = listaCargo[0].AtendeBatismo;
                lblAtendeSantaCeia.Text = listaCargo[0].AtendeSantaCeia;
                lblAtendeRJM.Text = listaCargo[0].AtendeRJM;
                lblAtendePreTesteRjmMus.Text = listaCargo[0].AtendePreTesteRjmMusico;
                lblAtendePreTesteRjmOrg.Text = listaCargo[0].AtendePreTesteRjmOrganista;
                lblAtendePreTesteCultoMus.Text = listaCargo[0].AtendePreTesteCultoMusico;
                lblAtendePreTesteCultoOrg.Text = listaCargo[0].AtendePreTesteCultoOrganista;
                lblAtendePreTesteOficialMus.Text = listaCargo[0].AtendePreTesteOficialMusico;
                lblAtendePreTesteOficialOrg.Text = listaCargo[0].AtendePreTesteOficialOrganista;
                lblAtendeTesteRjmMus.Text = listaCargo[0].AtendeTesteRjmMusico;
                lblAtendeTesteRjmOrg.Text = listaCargo[0].AtendeTesteRjmOrganista;
                lblAtendeTesteCultoMus.Text = listaCargo[0].AtendeTesteCultoMusico;
                lblAtendeTesteCultoOrg.Text = listaCargo[0].AtendeTesteCultoOrganista;
                lblAtendeTesteOficialMus.Text = listaCargo[0].AtendeTesteOficialMusico;
                lblAtendeTesteOficialOrg.Text = listaCargo[0].AtendeTesteOficialOrganista;
                lblAtendeReunMin.Text = listaCargo[0].AtendeReuniaoMinisterial;
                lblAtendeCasal.Text = listaCargo[0].AtendeCasal;
                lblAtendeOrdenacao.Text = listaCargo[0].AtendeOrdenacao;
                lblMasculino.Text = listaCargo[0].Masculino;
                lblFeminino.Text = listaCargo[0].Feminino;
                chkPermiteInstr.Checked = string.IsNullOrEmpty(listaCargo[0].PermiteInstrumento) || listaCargo[0].PermiteInstrumento.Equals("Não") ? false : true;
                chkAlunoGem.Checked = string.IsNullOrEmpty(listaCargo[0].AlunoGem) || listaCargo[0].AlunoGem.Equals("Não") ? false : true;
                chkEnsaio.Checked = string.IsNullOrEmpty(listaCargo[0].Ensaio) || listaCargo[0].Ensaio.Equals("Não") ? false : true;
                chkMeiaHora.Checked = string.IsNullOrEmpty(listaCargo[0].MeiaHora) || listaCargo[0].MeiaHora.Equals("Não") ? false : true;
                chkRjm.Checked = string.IsNullOrEmpty(listaCargo[0].Rjm) || listaCargo[0].Rjm.Equals("Não") ? false : true;
                chkCulto.Checked = string.IsNullOrEmpty(listaCargo[0].Culto) || listaCargo[0].Culto.Equals("Não") ? false : true;
                chkOficial.Checked = string.IsNullOrEmpty(listaCargo[0].Oficial) || listaCargo[0].Oficial.Equals("Não") ? false : true;

                verificacoes();

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
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                pnlCargo.Enabled = false;
                btnSalvar.Enabled = false;
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledForm()
        {
            try
            {
                pnlCargo.Enabled = true;
                btnSalvar.Enabled = true;
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
        internal void defineFoco()
        {
            txtSigla.Focus();
        }

        /// <summary>
        /// Função que verifica os valores e marca as Opções
        /// </summary>
        internal void verificacoes()
        {
            try
            {

                ///verifica o sexo
                chkMasculino.Checked = lblMasculino.Text.Equals("Sim") ? true : false;
                chkFeminino.Checked = lblFeminino.Text.Equals("Sim") ? true : false;

                ///verifica AtendeComum
                if (lblAtendeComum.Text.Equals("Sim"))
                {
                    optAtComSim.Checked = true;
                }
                else
                {
                    optAtComNao.Checked = true;
                }

                ///verifica AtendeRegião
                if (lblAtendeRegiao.Text.Equals("Sim"))
                {
                    optAtRegSim.Checked = true;
                }
                else
                {
                    optAtRegNao.Checked = true;
                }

                chkAtGem.Checked = lblAtendeGEM.Text.Equals("Sim") ? true : false;
                chkAtEnsLoc.Checked = lblAtendeEnsLoc.Text.Equals("Sim") ? true : false;
                chkAtEnsReg.Checked = lblAtendeEnsReg.Text.Equals("Sim") ? true : false;
                chkAtEnsParc.Checked = lblAtendeEnsParc.Text.Equals("Sim") ? true : false;
                chkAtEnsTec.Checked = lblAtendeEnsTec.Text.Equals("Sim") ? true : false;
                chkAtReunMoc.Checked = lblAtendeReunMoc.Text.Equals("Sim") ? true : false;
                chkAtReunMin.Checked = lblAtendeReunMin.Text.Equals("Sim") ? true : false;
                chkAtBatismo.Checked = lblAtendeBatismo.Text.Equals("Sim") ? true : false;
                chkAtCeia.Checked = lblAtendeSantaCeia.Text.Equals("Sim") ? true : false;
                chkAtRjm.Checked = lblAtendeRJM.Text.Equals("Sim") ? true : false;
                chkPreRjmMus.Checked = lblAtendePreTesteRjmMus.Text.Equals("Sim") ? true : false;
                chkPreRjmOrg.Checked = lblAtendePreTesteRjmOrg.Text.Equals("Sim") ? true : false;
                chkTesRjmMus.Checked = lblAtendeTesteRjmMus.Text.Equals("Sim") ? true : false;
                chkTesRjmOrg.Checked = lblAtendeTesteRjmOrg.Text.Equals("Sim") ? true : false;
                chkPreCultoMus.Checked = lblAtendePreTesteCultoMus.Text.Equals("Sim") ? true : false;
                chkPreCultoOrg.Checked = lblAtendePreTesteCultoOrg.Text.Equals("Sim") ? true : false;
                chkTesCultoMus.Checked = lblAtendeTesteCultoMus.Text.Equals("Sim") ? true : false;
                chkTesCultoOrg.Checked = lblAtendeTesteCultoOrg.Text.Equals("Sim") ? true : false;
                chkPreOficialMus.Checked = lblAtendePreTesteOficialMus.Text.Equals("Sim") ? true : false;
                chkPreOficialOrg.Checked = lblAtendePreTesteOficialOrg.Text.Equals("Sim") ? true : false;
                chkTesOficialMus.Checked = lblAtendeTesteOficialMus.Text.Equals("Sim") ? true : false;
                chkTesOficialOrg.Checked = lblAtendeTesteOficialOrg.Text.Equals("Sim") ? true : false;
                chkAtCasal.Checked = lblAtendeCasal.Text.Equals("Sim") ? true : false;
                chkAtOrdenacao.Checked = lblAtendeOrdenacao.Text.Equals("Sim") ? true : false;

                ///Verifica se o registro permite edição ou não
                if (lblPermiteEdicao.Text.Equals("Não"))
                {
                    lblSigla.Enabled = false;
                    txtSigla.Enabled = false;
                    lblOrdem.Enabled = false;
                    txtOrdem.Enabled = false;
                    lblDescricao.Enabled = false;
                    txtDescricao.Enabled = false;
                    cboDepartamento.Enabled = false;
                }
                else
                {
                    lblSigla.Enabled = true;
                    txtSigla.Enabled = true;
                    lblOrdem.Enabled = true;
                    txtOrdem.Enabled = true;
                    lblDescricao.Enabled = true;
                    txtDescricao.Enabled = true;
                    cboDepartamento.Enabled = true;
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermAtendimento()
        {
            if (lblMasculino.Text.Equals("Sim"))
            {
                gpoAtCom.Enabled = true;
                gpoAtReg.Enabled = true;
                gpoAtEspiritual.Enabled = true;
                gpoAtMusical.Enabled = true;
                chkAtBatismo.Enabled = true;
                chkAtCeia.Enabled = true;
                chkAtReunMoc.Enabled = true;
                chkAtReunMin.Enabled = true;
                chkAtRjm.Enabled = true;
                chkAtCasal.Enabled = true;
                chkAtOrdenacao.Enabled = true;
                chkAtGem.Enabled = true;
                chkAtGem.Enabled = true;
                chkAtEnsLoc.Enabled = true;
                chkAtEnsReg.Enabled = true;
                chkAtEnsTec.Enabled = true;
                chkAtEnsParc.Enabled = true;
                chkPreRjmMus.Enabled = true;
                chkPreRjmOrg.Enabled = true;
                chkPreCultoMus.Enabled = true;
                chkPreCultoOrg.Enabled = true;
                chkPreOficialMus.Enabled = true;
                chkPreOficialOrg.Enabled = true;
                chkTesRjmMus.Enabled = true;
                chkTesRjmOrg.Enabled = true;
                chkTesCultoMus.Enabled = true;
                chkTesCultoOrg.Enabled = true;
                chkTesOficialMus.Enabled = true;
                chkTesOficialOrg.Enabled = true;
            }
            else
            {
                if (lblFeminino.Text.Equals("Sim"))
                {
                    gpoAtCom.Enabled = true;
                    gpoAtReg.Enabled = true;
                    gpoAtEspiritual.Enabled = false;
                    gpoAtMusical.Enabled = true;
                    chkAtGem.Enabled = true;
                    chkAtEnsLoc.Enabled = false;
                    chkAtEnsReg.Enabled = false;
                    chkAtEnsTec.Enabled = true;
                    chkAtEnsParc.Enabled = false;
                    chkPreRjmMus.Enabled = false;
                    chkPreRjmOrg.Enabled = true;
                    chkPreCultoMus.Enabled = false;
                    chkPreCultoOrg.Enabled = true;
                    chkPreOficialMus.Enabled = false;
                    chkPreOficialOrg.Enabled = true;
                    chkTesRjmMus.Enabled = false;
                    chkTesRjmOrg.Enabled = true;
                    chkTesCultoMus.Enabled = false;
                    chkTesCultoOrg.Enabled = true;
                    chkTesOficialMus.Enabled = false;
                    chkTesOficialOrg.Enabled = true;
                }
                else
                {
                    gpoAtCom.Enabled = false;
                    gpoAtReg.Enabled = false;
                    gpoAtEspiritual.Enabled = false;
                    gpoAtMusical.Enabled = false;
                }
            }
        }

        #endregion

    }
}
