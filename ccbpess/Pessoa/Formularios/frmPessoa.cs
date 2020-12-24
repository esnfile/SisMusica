using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.IO;

using BLL.Funcoes;
using BLL.pessoa;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using BLL.uteis;
using ENT.Erros;
using ENT.instrumentos;
using ENT.pessoa;
using ENT.uteis;
using ENT.acessos;
using BLL.instrumentos;
using ccbpess.pesquisa;
using BLL.cargo;
using ENT.Session;

namespace ccbpess
{
    public partial class frmPessoa : Form
    {
        public frmPessoa(Form forms, DataGridView gridPesquisa, List<MOD_pessoa> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                //carregando a lista de permissões de acesso.
                listaAcesso = MOD_Session.ListaAcessoLogado;

                ///Recebe a lista e armazena
                listaPessoa = lista;

                #region Carrega Combo Boxes

                ///carrega os combos boxes
                //combos Cargo
                carregaCargo();
                carregaInstrAdicionais();

                #endregion

                //define a data do cadastro como data atual para o modo de inserção
                txtDataCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtHoraCadastro.Text = DateTime.Now.ToString("HH:mm");

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

        string CodCCBPessoa;
        string CodRegiaoPessoa;
        int IndiceCCB;
        int IndiceRegiao;

        clsException excp;
        List<MOD_acessos> listaAcesso = null;

        BLL_pessoa objBLL = null;
        MOD_pessoa objEnt = null;
        List<MOD_pessoa> listaPessoa = null;

        BLL_ccb objBLL_CCB = null;
        List<MOD_ccb> listaCCB = null;
        List<MOD_ccb> listaCCBAtende = null;

        BLL_regiaoAtuacao objBLL_Regiao = null;
        List<MOD_regiaoAtuacao> listaRegiao = null;

        BLL_cidade objBLL_Cid = null;
        List<MOD_cidade> listaCidade = null;

        IBLL_buscaCargo objBLL_Cargo = null;
        List<MOD_cargo> listaCargo = null;
        MOD_cargo CargoSelecao = null;

        List<MOD_pessoaInstr> listaPessoaInstr = null;
        List<MOD_pessoaInstr> listaInstrumento = null;

        BLL_instrumento objBLL_Instrumento = null;
        List<MOD_instrumento> listaInstrAdicionais = null;

        MOD_pessoaMetodo objEnt_PessoaMet = null;
        List<MOD_pessoaMetodo> listaPessoaMetodo = new List<MOD_pessoaMetodo>();
        
        List<MOD_pessoaMetodo> listaMetodo = new List<MOD_pessoaMetodo>();

        BindingList<MOD_pessoaCCB> listaCCBPessoa = new BindingList<MOD_pessoaCCB>();
        List<MOD_pessoaCCB> listaDeleteCCBPessoa = new List<MOD_pessoaCCB>();

        BindingList<MOD_regiaoPessoa> listaRegiaoPessoa = new BindingList<MOD_regiaoPessoa>();
        List<MOD_regiaoPessoa> listaDeleteRegiaoPessoa = new List<MOD_regiaoPessoa>();

        BindingSource objBinding_CCB = null;
        BindingSource objBinding_Regiao = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        string caminhoFoto = null;

        /// <summary>
        /// Variavel que retorna os resultados nas edições das pessoas
        /// </summary>
        public static string CodPessoaRetorno = "0";

        #endregion

        #region eventos do formulario

        #region Aba Geral

        private void optMasculino_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optMasculino.Checked.Equals(true))
                {
                    lblSexo.Text = "Masculino";
                    filtraCargo(lblSexo.Text);
                }
                else
                {
                    lblSexo.Text = string.Empty;
                    filtraCargo(lblSexo.Text);
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
        private void optFeminino_CheckedChanged(object sender, EventArgs e)
        {
             try
            {
                if (optFeminino.Checked.Equals(true))
                {
                    lblSexo.Text = "Feminino";
                    filtraCargo(lblSexo.Text);
                }
                else
                {
                    lblSexo.Text = string.Empty;
                    filtraCargo(lblSexo.Text);
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
        private void btnFoto_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                buscarFoto();
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
        private void txtCpf_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (!txtCpf.Text.Equals(string.Empty))
                {
                    if (txtCpf.Text.Equals("000.000.000-00"))
                    {
                        if (!modulos.listaParametros[0].CpfZerado.Equals("Sim"))
                        {
                            e.Cancel = true;
                            throw new Exception("O sistema não está habilitado para permitir " + '\n' +
                                                "CPF zerado!" + '\n' + '\n' +
                                                "Informe um CPF válido para continuar.");
                        }
                    }
                    else
                    {
                        ValidarCpf();
                        e.Cancel = false;
                    }
                }
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
                e.Cancel = true;
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
                e.Cancel = true;
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void btnCepRes_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCid", "Residencial");
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
        private void txtCepRes_Leave(object sender, EventArgs e)
        {
            if (!txtCepRes.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaCep(txtCepRes.Text, "Residencial");
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
        private void txtCepRes_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnCepRes;
        }
        private void cboCodCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(lblSexo.Text))
                {
                    CargoSelecao = new MOD_cargo();

                    if (cboCodCargo.SelectedValue != null)
                    {

                        foreach (MOD_cargo linha in listaCargo)
                        {
                            ///verifica a condição especificada para exibir a imagem
                            if (linha.CodCargo.Equals(Convert.ToString(cboCodCargo.SelectedValue)))
                            {
                                lblCodCargo.Text = linha.CodCargo;
                                //Preenche a Clase com o cargo selecionado
                                CargoSelecao = linha;
                                break;
                            }
                        }

                        /////Verifica se já foi preenchido a pessoa
                        //if (listaPessoa != null && listaPessoa.Count > 0)
                        //{
                        CheckPessoa();
                        //}
                    }
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
        private void txtCodCCB_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnComum;
        }
        private void txtCodCCB_Leave(object sender, EventArgs e)
        {
            if (!txtCodCCB.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaComum(txtCodCCB.Text, "Comum");
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
            else
            {
                txtCodCCB.Text = string.Empty;
                txtCodigoCCB.Text = string.Empty;
                txtDescCCB.Text = string.Empty;
                txtEndCom.Text = string.Empty;
                txtNumCom.Text = string.Empty;
                txtBairroCom.Text = string.Empty;
                txtCepCom.Text = string.Empty;
                txtCidadeCom.Text = string.Empty;
                lblCidadeCom.Text = string.Empty;
                txtEstadoCom.Text = string.Empty;
            }
        }
        private void btnComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCCB", "Comum");
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
        private void txtNome_Leave(object sender, EventArgs e)
        {
            txtNome.Text = txtNome.Text.ToUpper();
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.ToLower();
        }

        #endregion

        #region Aba Adicionais

        private void chkAtivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtivo.Checked.Equals(true))
            {
                lblAtivo.Text = "Sim";
                cboMotivoInativa.SelectedIndex = -1;
                txtMotivoInativa.Text = string.Empty;
                lblMotivoInativa.Enabled = false;
                cboMotivoInativa.Enabled = false;
            }
            else
            {
                lblAtivo.Text = "Não";
                cboMotivoInativa.SelectedIndex = -1;
                txtMotivoInativa.Text = string.Empty;
                lblMotivoInativa.Enabled = true;
                cboMotivoInativa.Enabled = true;
            }
        }
        private void optPaisSim_CheckedChanged(object sender, EventArgs e)
        {
            if (optPaisSim.Checked.Equals(true))
            {
                lblPaiCCB.Text = "Sim";
            }
            else
            {
                lblPaiCCB.Text = string.Empty;
            }
        }
        private void optPaisNao_CheckedChanged(object sender, EventArgs e)
        {
            if (optPaisNao.Checked.Equals(true))
            {
                lblPaiCCB.Text = "Não";
            }
            else
            {
                lblPaiCCB.Text = string.Empty;
            }
        }
        private void optFormaSim_CheckedChanged(object sender, EventArgs e)
        {
            if (optFormaSim.Checked.Equals(true))
            {
                lblFormacaoFora.Text = "Sim";
                lblLocalForma.Enabled = true;
                txtLocalFormacao.Enabled = true;
                lblFormaMusical.Enabled = true;
                txtQualFormacao.Enabled = true;
            }
        }
        private void optFormaNao_CheckedChanged(object sender, EventArgs e)
        {
            if (optFormaNao.Checked.Equals(true))
            {
                lblFormacaoFora.Text = "Não";
                lblLocalForma.Enabled = false;
                txtLocalFormacao.Enabled = false;
                txtLocalFormacao.BackColor = Color.LightGray;
                lblFormaMusical.Enabled = false;
                txtQualFormacao.Enabled = false;
                txtQualFormacao.BackColor = Color.LightGray;
            }
        }
        private void optOutraSim_CheckedChanged(object sender, EventArgs e)
        {
            if (optOutraSim.Checked.Equals(true))
            {
                lblOutraOrquestra.Text = "Sim";
                lblOrquestra1.Enabled = true;
                txtOrquestra1.Enabled = true;
                lblFuncao1.Enabled = true;
                txtFuncao1.Enabled = true;
                lblOrquestra2.Enabled = true;
                txtOrquestra2.Enabled = true;
                lblFuncao2.Enabled = true;
                txtFuncao2.Enabled = true;
                lblOrquestra3.Enabled = true;
                txtOrquestra3.Enabled = true;
                lblFuncao3.Enabled = true;
                txtFuncao3.Enabled = true;
            }
        }
        private void optOutraNao_CheckedChanged(object sender, EventArgs e)
        {
            if (optOutraNao.Checked.Equals(true))
            {
                lblOutraOrquestra.Text = "Não";
                lblOrquestra1.Enabled = false;
                txtOrquestra1.Enabled = false;
                lblFuncao1.Enabled = false;
                txtFuncao1.Enabled = false;
                lblOrquestra2.Enabled = false;
                txtOrquestra2.Enabled = false;
                lblFuncao2.Enabled = false;
                txtFuncao2.Enabled = false;
                lblOrquestra3.Enabled = false;
                txtOrquestra3.Enabled = false;
                lblFuncao3.Enabled = false;
                txtFuncao3.Enabled = false;
            }
        }
        private void cboInstrumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboInstrumento.SelectedValue != null)
                {
                    foreach (MOD_instrumento linha in listaInstrAdicionais)
                    {
                        ///verifica a condição especificada para exibir a imagem
                        if (linha.CodInstrumento.Contains(cboInstrumento.SelectedValue.ToString()))
                        {
                            txtFamilia.Text = linha.DescFamilia;
                            apoio.Aguarde("Carregando métodos...");
                            carregaMetodos(txtCodigo.Text, Convert.ToInt16(cboInstrumento.SelectedValue).ToString());
                            break;
                        }
                    }
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
        private void chkAlunoInstr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlunoInstr.Checked.Equals(true))
            {
                lblAlunoInstr.Text = "Sim";
                lblInstrumento.Enabled = true;
                cboInstrumento.Enabled = true;
            }
            else
            {
                lblAlunoInstr.Text = "Não";
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                cboInstrumento.SelectedIndex = (-1);
                txtFamilia.Text = string.Empty;
            }
        }

        private void optMeiaHora_CheckedChanged(object sender, EventArgs e)
        {
            if (optMeiaHora.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Meia Hora";
                chkAlunoInstr.Checked = true;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = true;
                cboInstrumento.Enabled = true;
            }
            else
            {
                lblDesenvolvimento.Text = string.Empty;
                chkAlunoInstr.Checked = false;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                txtFamilia.Text = string.Empty;
            }
        }
        private void optGem_CheckedChanged(object sender, EventArgs e)
        {
            if (optGem.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Aluno GEM";
                chkAlunoInstr.Enabled = true;
            }
            else
            {
                lblDesenvolvimento.Text = string.Empty;
                chkAlunoInstr.Checked = false;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                txtFamilia.Text = string.Empty;
            }
        }
        private void optEnsaio_CheckedChanged(object sender, EventArgs e)
        {
            if (optEnsaio.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Ensaios";
                chkAlunoInstr.Checked = true;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = true;
                cboInstrumento.Enabled = true;
            }
            else
            {
                lblDesenvolvimento.Text = string.Empty;
                chkAlunoInstr.Checked = false;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                txtFamilia.Text = string.Empty;
            }
        }
        private void optRjm_CheckedChanged(object sender, EventArgs e)
        {
            if (optRjm.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Reunião Jovens";
                chkAlunoInstr.Checked = true;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = true;
                cboInstrumento.Enabled = true;
            }
            else
            {
                lblDesenvolvimento.Text = string.Empty;
                chkAlunoInstr.Checked = false;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                txtFamilia.Text = string.Empty;
            }
        }
        private void optCulto_CheckedChanged(object sender, EventArgs e)
        {
            if (optCulto.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Culto Oficial";
                chkAlunoInstr.Checked = true;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = true;
                cboInstrumento.Enabled = true;
            }
            else
            {
                lblDesenvolvimento.Text = string.Empty;
                chkAlunoInstr.Checked = false;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                txtFamilia.Text = string.Empty;
            }
        }
        private void optOficial_CheckedChanged(object sender, EventArgs e)
        {
            if (optOficial.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Oficializado";
                chkAlunoInstr.Checked = true;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = true;
                cboInstrumento.Enabled = true;
            }
            else
            {
                lblDesenvolvimento.Text = string.Empty;
                chkAlunoInstr.Checked = false;
                chkAlunoInstr.Enabled = false;
                lblInstrumento.Enabled = false;
                cboInstrumento.Enabled = false;
                txtFamilia.Text = string.Empty;
            }
        }

        private void cboMotivoInativa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtMotivoInativa.Text = cboMotivoInativa.Text;
                if (cboMotivoInativa.Text.Equals("Outros"))
                {
                    txtMotivoInativa.Text = string.Empty;
                    txtMotivoInativa.Visible = true;
                    txtMotivoInativa.Enabled = true;
                }
                else
                {
                    txtMotivoInativa.Enabled = false;
                    txtMotivoInativa.Visible = false;
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

        #endregion

        #region Aba Atendimento

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
            verPermAtendimento();
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
            if (chkAtCeia.Checked.Equals(true))
            {
                lblAtendeSantaCeia.Text = "Sim";
            }
            else
            {
                lblAtendeSantaCeia.Text = "Não";
            }
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
                    verPermAtendimento();
                }
                else
                {
                    lblAtendeComum.Text = string.Empty;
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
                    verPermAtendimento();
                }
                else
                {
                    lblAtendeComum.Text = string.Empty;
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
                    optAtComSim.CheckedChanged -= new EventHandler(optAtComSim_CheckedChanged);

                    optAtComSim.Checked = true;
                    lblAtendeRegiao.Text = "Sim";
                    verPermAtendimento();

                    optAtComSim.CheckedChanged += new EventHandler(optAtComSim_CheckedChanged);
                }
                else
                {
                    lblAtendeRegiao.Text = string.Empty;
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
                    verPermAtendimento();
                }
                else
                {
                    lblAtendeRegiao.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void tabAtende_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabAtende.SelectedTab.Name.Equals("tabAtendeComum"))
                {
                    disabledAtendPessoa();
                    if (listaCCBPessoa == null || listaCCBPessoa.Count < 1)
                    {
                        apoio.Aguarde();
                        carregaCCBPessoa(txtCodigo.Text);
                    }
                }
                else if (tabAtende.SelectedTab.Name.Equals("tabInstrutor"))
                {
                    if (listaPessoaInstr == null || listaInstrumento == null ||
                        listaPessoaInstr.Count < 1 || listaInstrumento.Count < 1)
                    {
                        apoio.Aguarde();
                        carregaInstrumentos(txtCodigo.Text);
                    }
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

        #region Grid Instrumentos

        private void btnSelProfInstrum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_pessoaInstr entInst in listaPessoaInstr)
                {
                    entInst.Marcado = true;
                }
                gridProfInst.Refresh();
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
        private void btnDesProfInstrum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_pessoaInstr entInst in listaPessoaInstr)
                {
                    entInst.Marcado = false;
                }
                gridProfInst.Refresh();
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
        private void gridProfInst_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridProfInst != null || gridProfInst.RowCount > 0)
                {
                    if (listaPessoaInstr[e.RowIndex].Marcado.Equals(true))
                    {
                        listaPessoaInstr[e.RowIndex].Marcado = false;
                    }
                    else
                    {
                        listaPessoaInstr[e.RowIndex].Marcado = true;
                    }
                    gridProfInst.Refresh();
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

        #endregion

        #region Aba Atendimento Comum

        private void txtCCBPesCod_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnCCBPesCod;
        }
        private void txtCCBPesCod_Leave(object sender, EventArgs e)
        {
            if (!txtCCBPesCod.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaComumAtende(txtCCBPesCod.Text);
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
            else
            {
                txtCCBPesCod.Text = string.Empty;
                txtCCBPesIdent.Text = string.Empty;
                txtCCBPesDesc.Text = string.Empty;
                txtCCBPesEnd.Text = string.Empty;
                txtCCBPesNum.Text = string.Empty;
                txtCCBPesBairro.Text = string.Empty;
                txtCCBPesCep.Text = string.Empty;
                txtCCBPesCodCid.Text = string.Empty;
                lblCCBPesCidade.Text = string.Empty;
                txtCCBPesEstado.Text = string.Empty;
            }
        }
        private void btnCCBPesCod_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCCB", "CCBAtend");
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

        private void btnCCBPesInc_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                inserirCCBPessoa();
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
        private void btnCCBPesRet_Click(object sender, EventArgs e)
        {
            try
            {
                limparCCBAtendPessoa();
                disabledAtendPessoa();
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
        private void btnCCBPesIns_Click(object sender, EventArgs e)
        {
            try
            {
                limparCCBAtendPessoa();
                enabledAtendPessoa();
                gpoCCBPes.Enabled = true;
                txtCCBPesCod.Focus();
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
        private void btnCCBPesExc_Click(object sender, EventArgs e)
        {
            try
            {
                deleteCCBPessoa(gridCCBPes.CurrentRow.Index);
                disabledAtendPessoa();
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

        private void gridCCBPes_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                //Verifica se o grid possui registro
                if (gridCCBPes.RowCount > 0)
                {
                    btnCCBPesExc.Enabled = true;
                }
                else
                {
                    btnCCBPesExc.Enabled = false;
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
        private void gridCCBPes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridCCBPes.RowCount > 0)
                {
                    IndiceCCB = gridCCBPes.CurrentRow.Index;

                    if (IndiceCCB > (-1))
                    {
                        //CodCCBPessoa = gridCCBPes["CodCCB", IndiceCCB].Value.ToString();
                    }
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

        #endregion

        #endregion

        #region Aba Informações GEM


        private void txtInstrutor_Leave(object sender, EventArgs e)
        {
            if (!txtInstrutor.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtInstrutor.Text, "Instrutor");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
            else
            {
                txtInstrutor.Text = string.Empty;
                lblInstrutor.Text = string.Empty;
            }
        }
        private void btnInstrutor_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", "Instrutor");
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
        private void txtInstrutor_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnInstrutor;
        }

        private void txtCodCCBGem_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnCCBGem;
        }
        private void txtCodCCBGem_Leave(object sender, EventArgs e)
        {
            if (!txtCodCCBGem.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaComum(txtCodCCBGem.Text, "CCBGem");
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
                    AcceptButton = btnSalvar;
                    apoio.FecharAguarde();
                }
            }
            else
            {
                txtCodCCBGem.Text = string.Empty;
                txtCodigoCCBGem.Text = string.Empty;
                txtDescricaoCCBGem.Text = string.Empty;
                txtEndCCBGem.Text = string.Empty;
                txtNumCCBGem.Text = string.Empty;
                txtBairroCCBGem.Text = string.Empty;
                txtCepCCBGem.Text = string.Empty;
                lblCidadeCCBGem.Text = string.Empty;
                txtEstadoCCBGem.Text = string.Empty;
            }
        }
        private void btnCCBGem_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCCB", "CCBGem");
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

        #endregion

        #region Eventos do Formulario

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
        private void frmPessoa_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                tabGeral.Enabled = true;
                tabAdicionais.Enabled = false;
                tabAtendimento.Enabled = false;

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
        private void frmPessoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Pessoa"))
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
        private void frmPessoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void tabPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPessoa.SelectedTab.Name.Equals("tabAdicionais"))
                {
                    if (cboInstrumento.SelectedIndex.Equals(-1))
                    {
                    }
                }
                else if (tabPessoa.SelectedTab.Name.Equals("tabAtendimento"))
                {
                    if (tabAtendeComum.Enabled.Equals(true))
                    {
                        if (listaCCBPessoa == null || listaCCBPessoa.Count < 1)
                        {
                            apoio.Aguarde("Carregando comuns...");
                            carregaCCBPessoa(txtCodigo.Text);
                        }
                    }
                    //Preenche os instrumentos que o instrutor ensina
                    else if (listaInstrumento == null || listaInstrumento.Count < 1)
                    {
                        if (listaPessoaInstr == null || listaInstrumento == null ||
                            listaPessoaInstr.Count < 1 || listaInstrumento.Count < 1)
                        {
                            apoio.Aguarde();
                            carregaInstrumentos(txtCodigo.Text);
                        }
                    }
                }
                else if (tabPessoa.SelectedTab.Name.Equals("tabAluno"))
                {
                    if (listaPessoaMetodo == null || listaPessoaMetodo.Count < 1)
                    {
                        apoio.Aguarde("Carregando métodos...");
                        carregaMetodos(txtCodigo.Text, Convert.ToInt16(cboInstrumento.SelectedValue).ToString());
                    }
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
        private void frmPessoa_Activated(object sender, EventArgs e)
        {
            txtNome.Focus();
        }

        #endregion

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

                    bool blnRetorno;
                    objBLL = new BLL_pessoa();

                    if (Convert.ToInt64(txtCodigo.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        blnRetorno = objBLL.Insert(criarTabela(), out listaPessoa);
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        blnRetorno = objBLL.Update(criarTabela(), out listaPessoa);
                    }

                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmPessoaBusca"))
                    {
                        ((frmPessoaBusca)formChama).CarregaGrid(listaPessoa, dataGrid);
                    }
                    else if (formChama.Name.Equals("frmListaPresenca"))
                    {
                        CodPessoaRetorno = txtCodigo.Text;
                    }

                    FormClosing -= new FormClosingEventHandler(frmPessoa_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmPessoa_FormClosing);
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
        /// Função que valida os controle do Form
        /// </summary>
        /// <returns></returns>
        private bool ValidarControles(MOD_pessoa pessoa)
        {
            IBLL_ValidacaoPessoa valida = new BLL_ValidacaoPessoa();
            List<MOD_erros> erros = valida.ValidaCamposPessoa(pessoa);
            if (erros.Count > 0)
            {
                return apoio.AbrirErros(erros, this);
            }
            return true;
        }
        /// <summary>
        /// Funcão que valida o CPF digitado, caso tenha outra pessoa
        /// cadastrado com esse CPF retorna o cadastro para edição
        /// </summary>
        private void ValidarCpf()
        {
            try
            {
                MOD_pessoa pessoa = new MOD_pessoa();
                pessoa.Cpf = txtCpf.Text;
                pessoa.CodPessoa = txtCodigo.Text;

                IBLL_ValidacaoPessoa valida = new BLL_ValidacaoPessoa();
                List<MOD_pessoa> validaCpf = valida.ValidaCpfDuplicado(pessoa);

                if (validaCpf.Count > 0)
                {
                    if (!pessoa.CodPessoa.Equals(validaCpf[0].CodPessoa))
                    {
                        if (MessageBox.Show("Pessoa já cadastrada!" + "\n" +
                                            "Código: " + validaCpf[0].CodPessoa + "\n" +
                                            "Nome: " + validaCpf[0].Nome + "\n" + "\n" +
                                            "Deseja editar essa Pessoa?",
                                            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            preencher(validaCpf);
                            enabledForm();
                        }
                        else
                        {
                            txtCpf.Text = listaPessoa[0].Cpf;
                            txtCpf.Focus();
                            txtCpf.SelectAll();
                        }
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
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_pessoa criarTabela()
        {
            try
            {
                objEnt = new MOD_pessoa();
                objEnt.CodPessoa = txtCodigo.Text;
                objEnt.Ativo = lblAtivo.Text;
                objEnt.DataCadastro = txtDataCadastro.Text;
                objEnt.HoraCadastro = txtHoraCadastro.Text;
                objEnt.CodCargo = Convert.ToString(cboCodCargo.SelectedValue);
                objEnt.PermiteInstrumento = true.Equals(CargoSelecao.PermiteInstrumento) ? "Sim" : "Não";
                objEnt.Nome = txtNome.Text;
                objEnt.DataNasc = txtNascimento.Text;
                objEnt.Cpf = txtCpf.Text;
                objEnt.Rg = txtRg.Text;
                objEnt.OrgaoEmissor = txtOrgaoEmissor.Text;
                objEnt.Sexo = lblSexo.Text;
                objEnt.DataBatismo = txtBatismo.Text;
                objEnt.CodCidadeRes = txtCodCidRes.Text;
                objEnt.EndRes = txtEndRes.Text;
                objEnt.NumRes = txtNumRes.Text;
                objEnt.BairroRes = txtBairroRes.Text;
                objEnt.ComplRes = txtCompRes.Text;
                objEnt.Telefone1 = txtTel1.Text;
                objEnt.Telefone2 = txtTel2.Text;
                objEnt.Celular1 = txtCel1.Text;
                objEnt.Celular2 = txtCel2.Text;
                objEnt.Email = txtEmail.Text;
                objEnt.CodCCB = txtCodCCB.Text;
                objEnt.CodigoCCB = txtCodigoCCB.Text;
                objEnt.DescCargo = txtDescCCB.Text;
                objEnt.EndCCB = txtEndCom.Text;
                objEnt.NumCCB = txtNumCom.Text;
                objEnt.BairroCCB = txtBairroCom.Text;
                objEnt.CepCCB = txtCepCom.Text;
                objEnt.EstadoCCB = txtEstadoCom.Text;
                objEnt.CodCidadeCCB = txtCidadeCom.Text;
                objEnt.CidadeCCB = lblCidadeCom.Text;
                objEnt.EstadoCivil = cboEstadoCivil.Text;
                objEnt.DataApresentacao = txtApresentacao.Text;
                objEnt.PaisCCB = lblPaiCCB.Text;
                objEnt.Pai = txtPai.Text;
                objEnt.Mae = txtMae.Text;
                objEnt.InstrutorSeguro = txtInstrutorSeguro.Text;
                objEnt.FormacaoFora = lblFormacaoFora.Text;
                objEnt.LocalFormacao = txtLocalFormacao.Text;
                objEnt.QualFormacao = txtQualFormacao.Text;
                objEnt.OutraOrquestra = lblOutraOrquestra.Text;
                objEnt.Orquestra1 = txtOrquestra1.Text;
                objEnt.Funcao1 = txtFuncao1.Text;
                objEnt.Orquestra2 = txtOrquestra2.Text;
                objEnt.Funcao2 = txtFuncao2.Text;
                objEnt.Orquestra3 = txtOrquestra3.Text;
                objEnt.Funcao3 = txtFuncao3.Text;
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
                objEnt.CodInstrumento = Convert.ToString(cboInstrumento.SelectedValue);
                objEnt.CodCCBGem = txtCodCCBGem.Text;
                objEnt.DescricaoCCBGem = txtDescricaoCCBGem.Text;
                objEnt.CodigoCCBGem = txtCodigoCCBGem.Text;
                objEnt.Desenvolvimento = lblDesenvolvimento.Text;
                objEnt.DataUltimoTeste = txtUltimoTeste.Text;
                objEnt.DataInicioEstudo = txtDataInicio.Text;
                objEnt.ExecutInstrumento = lblAlunoInstr.Text;
                objEnt.CodInstrutor = txtInstrutor.Text;
                objEnt.NomeInstrutor = lblInstrutor.Text;
                objEnt.MotivoInativa = txtMotivoInativa.Text;

                if (!string.IsNullOrEmpty(caminhoFoto))
                    //retorna o objeto Foto preenchido
                    objEnt.FotoPessoa = criarFoto();

                //retorna o objeto Instrumento Pessoa
                if (listaPessoaInstr != null)
                {
                    objEnt.listaPessoaInstr = new List<MOD_pessoaInstr>();
                    objEnt.listaPessoaInstr = listaPessoaInstr;
                }

                //retorna o objeto Metodo Pessoa
                if (listaPessoaMetodo != null)
                {
                    objEnt.listaPessoaMet = new List<MOD_pessoaMetodo>();
                    objEnt.listaPessoaMet = listaPessoaMetodo;
                }

                //retorna o objeto CCBPessoa
                if (listaCCBPessoa != null || listaDeleteCCBPessoa != null)
                {
                    objEnt.listaCCBPessoa = new BindingList<MOD_pessoaCCB>();
                    objEnt.listaDeleteCCBPessoa = new List<MOD_pessoaCCB>();
                    objEnt.listaCCBPessoa = listaCCBPessoa;
                    objEnt.listaDeleteCCBPessoa = listaDeleteCCBPessoa;
                }

                //retorna o objeto RegiãoPessoa
                if (listaRegiaoPessoa != null || listaDeleteRegiaoPessoa != null)
                {
                    objEnt.listaRegiaoPessoa = new BindingList<MOD_regiaoPessoa>();
                    objEnt.listaDeleteRegiaoPessoa = new List<MOD_regiaoPessoa>();
                    objEnt.listaRegiaoPessoa = listaRegiaoPessoa;
                    objEnt.listaDeleteRegiaoPessoa = listaDeleteRegiaoPessoa;
                }

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
        /// Função que preenche os valores das entidades com a Foto
        /// </summary>
        /// <returns></returns>
        private MOD_pessoaFoto criarFoto()
        {
            try
            {
                objEnt.FotoPessoa = new MOD_pessoaFoto();
                objEnt.FotoPessoa.CodFoto = this.lblCodFoto.Text;
                objEnt.FotoPessoa.CodPessoa = this.txtCodigo.Text;
                objEnt.FotoPessoa.Foto = carregaFoto();
                return objEnt.FotoPessoa;
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
        /// <param name="listaPessoa"></param>
        internal void preencher(List<MOD_pessoa> listaPes)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaPes[0].CodPessoa;
                lblAtivo.Text = listaPes[0].Ativo;
                txtDataCadastro.Text = listaPes[0].DataCadastro;
                txtHoraCadastro.Text = listaPes[0].HoraCadastro;
                lblSexo.Text = listaPes[0].Sexo;
                cboCodCargo.SelectedValue = listaPes[0].CodCargo;
                txtNome.Text = listaPes[0].Nome;
                txtNascimento.Text = listaPes[0].DataNasc;
                txtCpf.Text = listaPes[0].Cpf;
                txtRg.Text = listaPes[0].Rg;
                txtOrgaoEmissor.Text = listaPes[0].OrgaoEmissor;
                txtBatismo.Text = listaPes[0].DataBatismo;
                txtCepRes.Text = listaPes[0].CepRes;
                txtEstadoRes.Text = listaPes[0].EstadoRes;
                txtCodCidRes.Text = listaPes[0].CodCidadeRes;
                lblCidRes.Text = listaPes[0].CidadeRes;
                txtEndRes.Text = listaPes[0].EndRes;
                txtNumRes.Text = listaPes[0].NumRes;
                txtBairroRes.Text = listaPes[0].BairroRes;
                txtCompRes.Text = listaPes[0].ComplRes;
                txtEmail.Text = listaPes[0].Email;
                txtTel1.Text = listaPes[0].Telefone1;
                txtTel2.Text = listaPes[0].Telefone2;
                txtCel1.Text = listaPes[0].Celular1;
                txtCel2.Text = listaPes[0].Celular2;
                txtCodCCB.Text = listaPes[0].CodCCB;
                txtCodigoCCB.Text = listaPes[0].CodigoCCB;
                txtDescCCB.Text = listaPes[0].Descricao;
                txtEndCom.Text = listaPes[0].EndCCB;
                txtNumCom.Text = listaPes[0].NumCCB;
                txtBairroCom.Text = listaPes[0].BairroCCB;
                txtCepCom.Text = listaPes[0].CepCCB;
                txtEstadoCom.Text = listaPes[0].EstadoCCB;
                txtCidadeCom.Text = listaPes[0].CodCidadeCCB;
                lblCidadeCom.Text = listaPes[0].CidadeCCB;
                txtCidadeCom.Text = listaPes[0].CodCidadeCCB;
                cboEstadoCivil.Text = listaPes[0].EstadoCivil;
                txtApresentacao.Text = listaPes[0].DataApresentacao;
                lblPaiCCB.Text = listaPes[0].PaisCCB;
                txtPai.Text = listaPes[0].Pai;
                txtMae.Text = listaPes[0].Mae;
                txtInstrutorSeguro.Text = listaPes[0].InstrutorSeguro;
                lblFormacaoFora.Text = listaPes[0].FormacaoFora;
                txtLocalFormacao.Text = listaPes[0].LocalFormacao;
                txtQualFormacao.Text = listaPes[0].QualFormacao;
                lblOutraOrquestra.Text = listaPes[0].OutraOrquestra;
                txtOrquestra1.Text = listaPes[0].Orquestra1;
                txtFuncao1.Text = listaPes[0].Funcao1;
                txtOrquestra2.Text = listaPes[0].Orquestra2;
                txtFuncao2.Text = listaPes[0].Funcao2;
                txtOrquestra3.Text = listaPes[0].Orquestra3;
                txtFuncao3.Text = listaPes[0].Funcao3;
                lblAtendeComum.Text = listaPes[0].AtendeComum;
                lblAtendeRegiao.Text = listaPes[0].AtendeRegiao;
                lblAtendeGEM.Text = listaPes[0].AtendeGEM;
                lblAtendeEnsLoc.Text = listaPes[0].AtendeEnsaioLocal;
                lblAtendeEnsReg.Text = listaPes[0].AtendeEnsaioRegional;
                lblAtendeEnsParc.Text = listaPes[0].AtendeEnsaioParcial;
                lblAtendeEnsTec.Text = listaPes[0].AtendeEnsaioTecnico;
                lblAtendeReunMoc.Text = listaPes[0].AtendeReuniaoMocidade;
                lblAtendeReunMin.Text = listaPes[0].AtendeReuniaoMinisterial;
                lblAtendeBatismo.Text = listaPes[0].AtendeBatismo;
                lblAtendeSantaCeia.Text = listaPes[0].AtendeSantaCeia;
                lblAtendeRJM.Text = listaPes[0].AtendeRJM;
                lblAtendePreTesteRjmMus.Text = listaPes[0].AtendePreTesteRjmMusico;
                lblAtendePreTesteRjmOrg.Text = listaPes[0].AtendePreTesteRjmOrganista;
                lblAtendeTesteRjmMus.Text = listaPes[0].AtendeTesteRjmMusico;
                lblAtendeTesteRjmOrg.Text = listaPes[0].AtendeTesteRjmOrganista;
                lblAtendePreTesteCultoMus.Text = listaPes[0].AtendePreTesteCultoMusico;
                lblAtendePreTesteCultoOrg.Text = listaPes[0].AtendePreTesteCultoOrganista;
                lblAtendeTesteCultoMus.Text = listaPes[0].AtendeTesteCultoMusico;
                lblAtendeTesteCultoOrg.Text = listaPes[0].AtendeTesteCultoOrganista;
                lblAtendePreTesteOficialMus.Text = listaPes[0].AtendePreTesteOficialMusico;
                lblAtendePreTesteOficialOrg.Text = listaPes[0].AtendePreTesteOficialOrganista;
                lblAtendeTesteOficialMus.Text = listaPes[0].AtendeTesteOficialMusico;
                lblAtendeTesteOficialOrg.Text = listaPes[0].AtendeTesteOficialOrganista;
                lblAtendeCasal.Text = listaPes[0].AtendeCasal;
                lblAtendeOrdenacao.Text = listaPes[0].AtendeOrdenacao;
                cboInstrumento.Text = listaPes[0].DescInstrumento;
                lblDesenvolvimento.Text = listaPes[0].Desenvolvimento;
                lblAlunoInstr.Text = listaPes[0].ExecutInstrumento;
                txtCodCCBGem.Text = listaPes[0].CodCCBGem;
                txtCodigoCCBGem.Text = listaPes[0].CodigoCCBGem;
                txtDescricaoCCBGem.Text = listaPes[0].DescricaoCCBGem;
                txtEndCCBGem.Text = listaPes[0].EndCCBGem;
                txtNumCCBGem.Text = listaPes[0].NumCCBGem;
                txtBairroCCBGem.Text = listaPes[0].BairroCCBGem;
                txtCepCCBGem.Text = listaPes[0].CepCCBGem;
                txtEstadoCCBGem.Text = listaPes[0].EstadoCCBGem;
                lblCidadeCCBGem.Text = listaPes[0].CidadeCCBGem;
                txtInstrutor.Text = listaPes[0].CodInstrutor;
                lblInstrutor.Text = listaPes[0].NomeInstrutor;
                txtDataInicio.Text = listaPes[0].DataInicioEstudo;
                txtUltimoTeste.Text = listaPes[0].DataUltimoTeste;
                cboMotivoInativa.Text = listaPes[0].MotivoInativa;
                txtMotivoInativa.Text = listaPes[0].MotivoInativa;

                ///verificações para preenchimento de radiobuttons
                verificacoes();

                //Carregar a Foto
                carregaFoto(listaPes);

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
        /// Função que carrega a foto da Pessoa na base de dados
        /// </summary>
        private void carregaFoto(List<MOD_pessoa> listaPes)
        {
            try
            {
                if (listaPes[0].listaFotoPessoa.Count > 0)
                {
                    foreach (MOD_pessoaFoto row in listaPes[0].listaFotoPessoa)
                    {
                        try
                        {
                            lblCodFoto.Text = row.CodFoto;
                            pctFoto.Image = new BLL_ProcessaImagem().ConvertBinarioEmImagem(row.Foto);
                        }
                        catch
                        {
                            pctFoto.Image = null;
                            pctFoto.Refresh();
                        }
                    }
                }
                else
                {
                    pctFoto.Image = null;
                    pctFoto.Refresh();
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
        /// Função que carrega os dados do Cep pesquisado
        /// <para>Campo: Residencial </para>
        /// </summary>
        /// <param name="vCep"></param>
        /// <param name="Campo"></param>
        internal void carregaCep(string vCep, string Campo)
        {
            try
            {
                objBLL_Cid = new BLL_cidade();
                listaCidade = objBLL_Cid.buscarCep(vCep);

                if (Campo.Equals("Residencial"))
                {
                    if (listaCidade.Count > 0)
                    {
                        txtCepRes.Text = listaCidade[0].Cep;
                        txtEstadoRes.Text = listaCidade[0].Estado;
                        txtCodCidRes.Text = listaCidade[0].CodCidade;
                        lblCidRes.Text = listaCidade[0].Cidade;
                        txtEndRes.Text = string.IsNullOrEmpty(listaCidade[0].Endereco) ? null : listaCidade[0].Tipo + " " + listaCidade[0].Endereco;
                        txtBairroRes.Text = listaCidade[0].Bairro;
                    }
                    else
                    {
                        abrirForm("frmCid", Campo);
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
        /// Função que carrega a Comum pesquisado pelo Código
        /// </summary>
        /// <param name="vCodCCB"></param>
        internal void carregaComum(string vCodCCB, string Campo)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarCod(vCodCCB);

                if (Campo.Equals("Comum"))
                {
                    if (listaCCB != null && listaCCB.Count > 0)
                    {
                        txtCodCCB.Text = listaCCB[0].CodCCB;
                        txtCodigoCCB.Text = listaCCB[0].Codigo;
                        txtDescCCB.Text = listaCCB[0].Descricao;
                        txtEndCom.Text = listaCCB[0].Endereco;
                        txtNumCom.Text = listaCCB[0].Numero;
                        txtBairroCom.Text = listaCCB[0].Bairro;
                        txtCepCom.Text = listaCCB[0].Cep;
                        txtCidadeCom.Text = listaCCB[0].CodCidade;
                        lblCidadeCom.Text = listaCCB[0].Cidade;
                        txtEstadoCom.Text = listaCCB[0].Estado;
                    }
                    else
                    {
                        abrirForm("frmCCB", "Comum");
                    }
                }
                else if (Campo.Equals("CCBGem"))
                {
                    if (listaCCB != null && listaCCB.Count > 0)
                    {
                        txtCodCCBGem.Text = listaCCB[0].CodCCB;
                        txtCodigoCCBGem.Text = listaCCB[0].Codigo;
                        txtDescricaoCCBGem.Text = listaCCB[0].Descricao;
                        txtEndCCBGem.Text = listaCCB[0].Endereco;
                        txtNumCCBGem.Text = listaCCB[0].Numero;
                        txtBairroCCBGem.Text = listaCCB[0].Bairro;
                        txtCepCCBGem.Text = listaCCB[0].Cep;
                        lblCidadeCCBGem.Text = listaCCB[0].Cidade;
                        txtEstadoCCBGem.Text = listaCCB[0].Estado;
                    }
                    else
                    {
                        abrirForm("frmCCB", "CCBGem");
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
        /// Função que carrega a Comum para Atendimento pesquisado pelo Código
        /// </summary>
        /// <param name="vCodCCB"></param>
        internal void carregaComumAtende(string vCodCCB)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCBAtende = this.objBLL_CCB.buscarCod(vCodCCB);

                if (listaCCBAtende != null && listaCCBAtende.Count > 0)
                {
                    txtCCBPesCod.Text = listaCCBAtende[0].CodCCB.PadLeft(6, '0');
                    txtCCBPesIdent.Text = listaCCBAtende[0].Codigo;
                    txtCCBPesDesc.Text = listaCCBAtende[0].Descricao;
                    txtCCBPesEnd.Text = listaCCBAtende[0].Endereco;
                    txtCCBPesNum.Text = listaCCBAtende[0].Numero;
                    txtCCBPesBairro.Text = listaCCBAtende[0].Bairro;
                    txtCCBPesCep.Text = listaCCBAtende[0].Cep;
                    txtCCBPesCodCid.Text = listaCCBAtende[0].CodCidade.PadLeft(6, '0');
                    lblCCBPesCidade.Text = listaCCBAtende[0].Cidade;
                    txtCCBPesEstado.Text = listaCCBAtende[0].Estado;
                }
                else
                {
                    abrirForm("frmCCB", "CCBAtend");
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
        /// Função que preenche o ComboBox Cargo
        /// </summary>
        /// <returns></returns>
        internal void carregaCargo()
        {
            try
            {
                objBLL_Cargo = new BLL_buscaCargoPorDescricao();
                listaCargo = new List<MOD_cargo>();

                cboCodCargo.SelectedIndexChanged -= new EventHandler(cboCodCargo_SelectedIndexChanged);

                listaCargo = objBLL_Cargo.Buscar(string.Empty);
                cboCodCargo.DataSource = listaCargo;
                cboCodCargo.ValueMember = "CodCargo";
                cboCodCargo.DisplayMember = "DescCargo";

                cboCodCargo.SelectedIndexChanged += new EventHandler(cboCodCargo_SelectedIndexChanged);

                cboCodCargo.SelectedIndex = (-1);

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
        /// Filtra os cargos de acordo com o Sexo
        /// </summary>
        internal void filtraCargo(string Sexo)
        {
            if (string.IsNullOrEmpty(Sexo))
            {
                cboCodCargo.DataSource = null;
                lblCargo.Enabled = false;
                cboCodCargo.Enabled = false;
            }
            else
            {
                List<MOD_cargo> listaFiltro = new List<MOD_cargo>();
                if (Sexo.Equals("Masculino"))
                {
                    listaFiltro = listaCargo.Where(c => c.Masculino.Equals("Sim")).ToList();
                }
                else if (Sexo.Equals("Feminino"))
                {
                    listaFiltro = listaCargo.Where(c => c.Feminino.Equals("Sim")).ToList();
                }
                cboCodCargo.SelectedIndexChanged -= new EventHandler(cboCodCargo_SelectedIndexChanged);

                cboCodCargo.DataSource = null;
                cboCodCargo.DataSource = listaFiltro;
                cboCodCargo.ValueMember = "CodCargo";
                cboCodCargo.DisplayMember = "DescCargo";

                cboCodCargo.SelectedIndexChanged += new EventHandler(cboCodCargo_SelectedIndexChanged);

                lblCodCargo.Text = string.Empty;
                cboCodCargo.SelectedIndex = (-1);

                if (!Convert.ToInt64(txtCodigo.Text).Equals(0))
                {
                    cboCodCargo.SelectedValue = listaPessoa[0].CodCargo;
                }
            }
            verPermCargo();
        }

        /// <summary>
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa"></param>
        internal void carregaPessoa(string vCodPessoa, string Campo)
        {
            try
            {
                IBLL_buscaPessoa objBLL_Pessoa = new BLL_buscaPessoaPorCodPessoa();
                List<MOD_pessoa> listaPes = new List<MOD_pessoa>();
                List<MOD_pessoa> listaPesFiltro = new List<MOD_pessoa>();

                listaPes = objBLL_Pessoa.Buscar(vCodPessoa);

                if (Campo.Equals("Instrutor"))
                {
                    listaPesFiltro = listaPes.Where(x => Convert.ToInt16(x.CodCargo).Equals(8)).ToList();

                    if (listaPesFiltro != null && listaPesFiltro.Count > 0)
                    {
                        if (listaPesFiltro[0].Ativo.Equals("Sim"))
                        {
                                txtInstrutor.Text = listaPesFiltro[0].CodPessoa;
                                lblInstrutor.Text = listaPesFiltro[0].Nome;
                        }
                        else
                        {
                            txtInstrutor.Text = string.Empty;
                            lblInstrutor.Text = string.Empty;
                            txtInstrutor.Focus();
                            throw new Exception("Essa pessoa está inativa!" + "\n" + "Para utilizar deverá ativar o cadastro." + 
                                                "\n" + "\n" + "Pessoas >> Aba Adicionais >> Pessoa Ativa.");
                        }
                    }
                    else
                    {
                        abrirForm("frmPes", "Instrutor");
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
        /// Função que abre os formulários de pesquisa
        /// </summary>
        /// <param name="form"></param>
        private void abrirForm(string form, string Campo)
        {
            try
            {
                if (form.Equals("frmCid"))
                {
                    if (Campo.Equals("Residencial"))
                    {
                        txtCepRes.Text = string.Empty;
                        txtEstadoRes.Text = string.Empty;
                        txtCodCidRes.Text = string.Empty;
                        lblCidRes.Text = string.Empty;
                        //txtEndRes.Text = string.Empty;
                        //txtBairroRes.Text = string.Empty;

                        formulario = new frmPesquisaCidade(this, "Residencial");
                        ((frmPesquisaCidade)formulario).MdiParent = MdiParent;
                        ((frmPesquisaCidade)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaCidade)formulario));
                        ((frmPesquisaCidade)formulario).Show();
                        ((frmPesquisaCidade)formulario).BringToFront();
                        Enabled = false;
                    }
                }
                else if (form.Equals("frmCCB"))
                {
                    if (Campo.Equals("Comum"))
                    {
                        txtCodCCB.Text = string.Empty;
                        txtCodigoCCB.Text = string.Empty;
                        txtDescCCB.Text = string.Empty;
                        txtEndCom.Text = string.Empty;
                        txtNumCom.Text = string.Empty;
                        txtBairroCom.Text = string.Empty;
                        txtCepCom.Text = string.Empty;
                        txtCidadeCom.Text = string.Empty;
                        lblCidadeCom.Text = string.Empty;
                        txtEstadoCom.Text = string.Empty;

                        formulario = new frmCCBBusca(MOD_Session.ListaAcessoLogado, this, Campo);
                        ((frmCCBBusca)formulario).MdiParent = MdiParent;
                        ((frmCCBBusca)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmCCBBusca)formulario));
                        ((frmCCBBusca)formulario).Text = "Pesquisar Comum";
                        ((frmCCBBusca)formulario).Show();
                        ((frmCCBBusca)formulario).BringToFront();
                        Enabled = false;
                        ((frmCCBBusca)formulario).defineFoco();
                    }
                    else if (Campo.Equals("CCBAtend"))
                    {
                        txtCCBPesCod.Text = string.Empty;
                        txtCCBPesIdent.Text = string.Empty;
                        txtCCBPesDesc.Text = string.Empty;
                        txtCCBPesEnd.Text = string.Empty;
                        txtCCBPesNum.Text = string.Empty;
                        txtCCBPesBairro.Text = string.Empty;
                        txtCCBPesCep.Text = string.Empty;
                        txtCCBPesCodCid.Text = string.Empty;
                        lblCCBPesCidade.Text = string.Empty;
                        txtCCBPesEstado.Text = string.Empty;

                        formulario = new frmPesquisaComum(this, Campo);
                        ((frmPesquisaComum)formulario).MdiParent = MdiParent;
                        ((frmPesquisaComum)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaComum)formulario));
                        ((frmPesquisaComum)formulario).Show();
                        ((frmPesquisaComum)formulario).BringToFront();
                        Enabled = false;
                        ((frmPesquisaComum)formulario).defineFoco();
                    }
                    else if (Campo.Equals("CCBGem"))
                    {
                        txtCodCCBGem.Text = string.Empty;
                        txtCodigoCCBGem.Text = string.Empty;
                        txtDescricaoCCBGem.Text = string.Empty;
                        txtEndCCBGem.Text = string.Empty;
                        txtNumCCBGem.Text = string.Empty;
                        txtBairroCCBGem.Text = string.Empty;
                        txtCepCCBGem.Text = string.Empty;
                        lblCidadeCCBGem.Text = string.Empty;
                        txtEstadoCCBGem.Text = string.Empty;

                        formulario = new frmPesquisaComum(this, Campo);
                        ((frmPesquisaComum)formulario).MdiParent = MdiParent;
                        ((frmPesquisaComum)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaComum)formulario));
                        ((frmPesquisaComum)formulario).Show();
                        ((frmPesquisaComum)formulario).BringToFront();
                        Enabled = false;
                        ((frmPesquisaComum)formulario).defineFoco();
                    }
                }
                else if (form.Equals("frmPes"))
                {
                    if (Campo.Equals("Instrutor"))
                    {
                        txtInstrutor.Text = string.Empty;
                        lblInstrutor.Text = string.Empty;

                        formulario = new frmPesquisaPessoa(this, Campo);
                        ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                        ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                        funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                        ((frmPesquisaPessoa)formulario).Show();
                        ((frmPesquisaPessoa)formulario).BringToFront();
                        Enabled = false;
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
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                tabGeral.Enabled = false;
                tabAtendeComum.Enabled = false;
                txtNome.Enabled = false;
                tabInstrutor.Enabled = false;
                tabDiversos.Enabled = false;
                tabFormacao.Enabled = false;
                gpoPais.Enabled = false;
                gpoDiversos.Enabled = false;
                tabAluno.Enabled = false;
                tabRjm.Enabled = false;
                tabCulto.Enabled = false;
                tabOficial.Enabled = false;
                gridProfInst.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridCCBPes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridMetodoAlu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridMtsRjm.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridMtsCulto.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridMtsOficial.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridHinoRjm.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridHinoCulto.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridHinoOficial.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridMetodoRjm.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridMetodoCulto.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridMetodoOficial.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridEscalaRjm.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridEscalaCulto.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                gridEscalaOficial.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
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
        public void enabledForm()
        {
            try
            {
                CheckPessoa();
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
        /// Função que verifica os valores e marca as Opções
        /// </summary>
        internal void verificacoes()
        {
            try
            {
                ///verifica o sexo
                if (lblSexo.Text.Equals("Masculino"))
                {
                    optMasculino.Checked = true;
                }
                else if (lblSexo.Text.Equals("Feminino"))
                {
                    optFeminino.Checked = true;
                }

                ///verifica desenvolvimento
                if (lblDesenvolvimento.Text.Equals("Aluno GEM"))
                {
                    optGem.Checked = true;
                }
                else if (lblDesenvolvimento.Text.Equals("Ensaios"))
                {
                    optEnsaio.Checked = true;
                }
                else if (lblDesenvolvimento.Text.Equals("Reunião Jovens"))
                {
                    optRjm.Checked = true;
                }
                else if (lblDesenvolvimento.Text.Equals("Culto Oficial"))
                {
                    optCulto.Checked = true;
                }
                else if (lblDesenvolvimento.Text.Equals("Oficializado"))
                {
                    optOficial.Checked = true;
                }
                chkAlunoInstr.Checked = lblAlunoInstr.Text.Equals("Sim") ? true : false;

                #region Aba Adicionais

                chkAtivo.Checked = lblAtivo.Text.Equals("Sim") ? true : false;

                ///verifica os pais CCB
                if (lblPaiCCB.Text.Equals("Sim"))
                {
                    optPaisSim.Checked = true;
                }
                else
                {
                    optPaisNao.Checked = true;
                }
                ///verifica formação fora
                if (lblFormacaoFora.Text.Equals("Sim"))
                {
                    optFormaSim.Checked = true;
                }
                else
                {
                    optFormaNao.Checked = true;
                }
                ///verifica outra orquestra
                if (lblOutraOrquestra.Text.Equals("Sim"))
                {
                    optOutraSim.Checked = true;
                }
                else
                {
                    optOutraNao.Checked = true;
                }
                #endregion

                #region Aba Atendimento

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

                #endregion

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
        /// Função que checa as opções marcadas e habilita ou desabilita campos
        /// </summary>
        private void CheckPessoa()
        {
            try
            {
                verPermCargo();
                verPermAdicionais();
                verPermAtendimento();
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
            txtNome.Focus();
        }

        #region Aba Adicionais

        /// <summary>
        /// Função que preenche o ComboBox Instrumento
        /// </summary>
        /// <returns></returns>
        internal void carregaInstrAdicionais()
        {
            try
            {
                objBLL_Instrumento = new BLL_instrumento();
                listaInstrAdicionais = new List<MOD_instrumento>();

                listaInstrAdicionais = objBLL_Instrumento.buscarDescricao(string.Empty);

                cboInstrumento.DataSource = listaInstrAdicionais;
                cboInstrumento.ValueMember = "CodInstrumento";
                cboInstrumento.DisplayMember = "DescInstrumento";
                cboInstrumento.SelectedIndex = (-1);
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

        #region Aba Atendimento

        #region Grid CCBPessoa

        /// <summary>
        /// Função que carrega as Comuns da Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        private void carregaCCBPessoa(string CodPessoa)
        {
            try
            {
                IBLL_buscaPessoaCCB objBLL_PessoaCCB = new BLL_buscaCCBPessoaPorPessoaCCB();
                objBinding_CCB = new BindingSource();
                listaCCBPessoa = new BindingList<MOD_pessoaCCB>(objBLL_PessoaCCB.Buscar(CodPessoa));

                objBinding_CCB.DataSource = listaCCBPessoa;

                funcoes.gridCCB(gridCCBPes, "CCBPessoa");
                ///vincula a lista ao DataSource do DataGriView
                gridCCBPes.DataSource = objBinding_CCB;
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
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void inserirCCBPessoa()
        {
            try
            {
                MOD_pessoaCCB ent = new MOD_pessoaCCB();
                ent.CodPessoa = txtCodigo.Text;
                ent.CodCCB = txtCCBPesCod.Text;
                ent.CodigoCCB = txtCCBPesIdent.Text;
                ent.DescricaoCCB = txtCCBPesDesc.Text;
                ent.Endereco = txtCCBPesEnd.Text;
                ent.Numero = txtCCBPesNum.Text;
                ent.Bairro = txtCCBPesBairro.Text;
                ent.CodCidade = txtCCBPesCodCid.Text;
                ent.Cidade = lblCCBPesCidade.Text;
                ent.Estado = txtCCBPesEstado.Text;
                ent.Cep = txtCCBPesCep.Text;

                listaCCBPessoa = ((BindingList<MOD_pessoaCCB>)objBinding_CCB.DataSource);
                //adiciona um novo item a lista
                listaCCBPessoa.Add(ent);
                //atualiza o datagridview

                listaCCBPessoa.ResetItem(gridCCBPes.RowCount - 1);

                //Limpa os controle e desabilita
                limparCCBAtendPessoa();
                disabledAtendPessoa();
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
        /// Função que Deleta a linha selecionada no GridCCBPesoa
        /// </summary>
        private void deleteCCBPessoa(int Indice)
        {
            try
            {
                MOD_pessoaCCB ent = new MOD_pessoaCCB();
                ent = listaCCBPessoa[Indice];

                //Insere a linha na Lista Delete
                listaDeleteCCBPessoa.Add(ent);
                //Exclui a linha da lista
                listaCCBPessoa.RemoveAt(Indice);

                //Seleciona a linha anterior a excluida
                if (gridCCBPes.RowCount > 0)
                {
                    if (!gridCCBPes.Rows[0].Selected.Equals(true))
                    {
                        gridCCBPes.Rows[Indice - 1].Selected = true;
                    }
                    else
                    {
                        gridCCBPes.Rows[gridCCBPes.RowCount - 1].Selected = true;
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
        /// Função que limpa os controle para Inserir nova CCBPessoa
        /// </summary>
        private void limparCCBAtendPessoa()
        {
            try
            {
                txtCCBPesCod.Text = string.Empty;
                txtCCBPesIdent.Text = string.Empty;
                txtCCBPesDesc.Text = string.Empty;
                txtCCBPesEnd.Text = string.Empty;
                txtCCBPesNum.Text = string.Empty;
                txtCCBPesBairro.Text = string.Empty;
                txtCCBPesCodCid.Text = string.Empty;
                txtCCBPesCep.Text = string.Empty;
                lblCCBPesCidade.Text = string.Empty;
                txtCCBPesEstado.Text = string.Empty;
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
        internal void disabledAtendPessoa()
        {
            try
            {
                gpoCCBPes.Enabled = false;
                gridCCBPes.Enabled = true;
                btnCCBPesIns.Enabled = true;

                //Verifica se o grid possui registro
                if (gridCCBPes.RowCount > 0)
                {
                    btnCCBPesExc.Enabled = true;
                }
                else
                {
                    btnCCBPesExc.Enabled = false;
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledAtendPessoa()
        {
            try
            {
                gpoCCBPes.Enabled = true;
                gridCCBPes.Enabled = false;
                btnCCBPesIns.Enabled = false;
                btnCCBPesExc.Enabled = false;
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

        #region Grid Instrumentos

        /// <summary>
        /// Função que carrega os Instrumentos
        /// </summary>
        /// <param name="CodPessoa"></param>
        private void carregaInstrumentos(string CodPessoa)
        {
            try
            {
                List<MOD_pessoaInstr> listaNova = new List<MOD_pessoaInstr>();

                IBLL_buscaPessoaInstr objBLL_BuscaPesInstr = new BLL_buscaPessoaInstrPorPessoa();
                listaPessoaInstr = objBLL_BuscaPesInstr.Buscar(CodPessoa);

                IBLL_buscaPessoaInstr objBLL_BuscaInstr = new BLL_buscaPessoaInstrPorInstrumento();
                listaInstrumento = objBLL_BuscaInstr.Buscar(CodPessoa);

                foreach (MOD_pessoaInstr objEnt_Inst in listaInstrumento)
                {
                    MOD_pessoaInstr ent = new MOD_pessoaInstr
                    {
                        CodInstrumento = objEnt_Inst.CodInstrumento,
                        DescInstrumento = objEnt_Inst.DescInstrumento,
                        DescFamilia = objEnt_Inst.DescFamilia,
                        CodPessoa = txtCodigo.Text,
                        Marcado = false
                    };

                    listaNova.Add(ent);
                }

                listaPessoaInstr.AddRange(listaNova);

                funcoes.gridInstrumentos(gridProfInst, "PessoaInstr");
                ///vincula a lista ao DataSource do DataGriView
                gridProfInst.DataSource = listaPessoaInstr;
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

        #endregion

        #region Aba Informações GEM

        /// <summary>
        /// Função que monta o GridView de Metódos - Aba Informações GEM
        /// </summary>
        private void montaGridMetodo()
        {
            try
            {

                gridMetodoAlu.AutoGenerateColumns = false;
                gridMetodoAlu.DataSource = null;
                gridMetodoAlu.Columns.Clear();
                gridMetodoAlu.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodPesMet = new DataGridViewTextBoxColumn();
                colCodPesMet.DataPropertyName = "CodPessoaMet";
                colCodPesMet.HeaderText = "CodPessoaMet";
                colCodPesMet.Name = "CodPessoaMet";
                colCodPesMet.Width = 100;
                colCodPesMet.Frozen = false;
                colCodPesMet.MinimumWidth = 100;
                colCodPesMet.ReadOnly = true;
                colCodPesMet.FillWeight = 100;
                colCodPesMet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodPesMet.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodPesMet.MaxInputLength = 20;
                colCodPesMet.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodMetodo = new DataGridViewTextBoxColumn();
                colCodMetodo.DataPropertyName = "CodMetodo";
                colCodMetodo.HeaderText = "Código";
                colCodMetodo.Name = "CodMetodo";
                colCodMetodo.Width = 60;
                colCodMetodo.Frozen = false;
                colCodMetodo.MinimumWidth = 55;
                colCodMetodo.ReadOnly = true;
                colCodMetodo.FillWeight = 100;
                colCodMetodo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodMetodo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescMetodo";
                colDescricao.HeaderText = "Método";
                colDescricao.Name = "DescMetodo";
                colDescricao.Width = 150;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colCompositor = new DataGridViewTextBoxColumn();
                colCompositor.DataPropertyName = "Compositor";
                colCompositor.HeaderText = "Compositor";
                colCompositor.Name = "Compositor";
                colCompositor.Width = 150;
                colCompositor.Frozen = false;
                colCompositor.MinimumWidth = 120;
                colCompositor.ReadOnly = true;
                colCompositor.FillWeight = 100;
                colCompositor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCompositor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colCompositor.MaxInputLength = 100;
                colCompositor.Visible = true;
                ///5ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                gridMetodoAlu.Columns.Add(colMarc);
                gridMetodoAlu.Columns.Add(colCodPesMet);
                gridMetodoAlu.Columns.Add(colCodMetodo);
                gridMetodoAlu.Columns.Add(colDescricao);
                gridMetodoAlu.Columns.Add(colCompositor);

                ///feito um refresh para fazer a atualização do datagridview
                gridMetodoAlu.Refresh();
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
        /// Função que carrega os Instrumentos
        /// </summary>
        /// <param name="CodPessoa"></param>
        private void carregaMetodos(string CodPessoa, string CodInstrumento)
        {
            try
            {
                List<MOD_pessoaMetodo> listaNova = new List<MOD_pessoaMetodo>();

                IBLL_buscaPessoaMetodo objBLL_MetPes = new BLL_buscaPessoaMetodoPorPessoa();
                listaPessoaMetodo = objBLL_MetPes.Buscar(CodPessoa);

                IBLL_buscaPessoaMetodo objBLL_Metodo = new BLL_buscaPessoaMetodoPorMetodos();
                listaMetodo = objBLL_Metodo.Buscar(CodPessoa, string.Empty, "Sim", CodInstrumento);

                foreach (MOD_pessoaMetodo objEnt_Met in listaMetodo)
                {
                    MOD_pessoaMetodo ent = new MOD_pessoaMetodo
                    {
                        CodMetodo = objEnt_Met.CodMetodo,
                        DescMetodo = objEnt_Met.DescMetodo,
                        TipoEscolha = objEnt_Met.TipoEscolha,
                        PaginaFase = objEnt_Met.PaginaFase,
                        Tipo = objEnt_Met.Tipo,
                        Ativo = objEnt_Met.Ativo,
                        Compositor = objEnt_Met.Compositor,
                        CodPessoa = "0",
                        Marcado = false
                    };

                    listaNova.Add(ent);
                }

                listaPessoaMetodo.AddRange(listaNova);
                montaGridMetodo();
                ///vincula a lista ao DataSource do DataGriView
                gridMetodoAlu.DataSource = listaPessoaMetodo;
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

        /// <summary>
        /// Função que abre a Caixa de diálogo para Pesquisar a Foto
        /// </summary>
        private void buscarFoto()
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();

                dlg.Title = "Carregar Foto";
                dlg.Filter = "JPEG (*.jpg)|*.jpg|BMP (*.bmp)|*.bmp";

                if (dlg.ShowDialog().Equals(DialogResult.OK))
                {
                    try
                    {
                        pctFoto.Image = new Bitmap(dlg.OpenFile());
                        caminhoFoto = dlg.FileName;
                    }
                    catch (Exception ex)
                    {
                        excp = new clsException(ex);
                    }
                }
                dlg.Dispose();
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
        /// Função que carrega a Imagem e Converte em Binário
        /// </summary>
        /// <returns></returns>
        private byte[] carregaFoto()
        {
            try
            {
                FileStream fs = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                byte[] foto = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                return foto;
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

        #region verificação e liberação de acesso

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermCargo()
        {
            try
            {
                if (!lblSexo.Text.Equals(string.Empty))
                {
                    if (Convert.ToInt64(txtCodigo.Text).Equals(0))
                    {
                        lblCargo.Enabled = true;
                        cboCodCargo.Enabled = true;
                    }
                    else
                    {
                        lblCargo.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAteraCargo);
                        cboCodCargo.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAteraCargo);
                    }
                }
                else
                {
                    lblCodCargo.Text = string.Empty;
                    lblCargo.Enabled = false;
                    cboCodCargo.Enabled = false;
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
        internal void verPermAdicionais()
        {
            try
            {
                tabAdicionais.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAdicionais);

                if (tabAdicionais.Enabled.Equals(true))
                {
                    tabFormacao.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAdiForma);
                    tabDiversos.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAdiOrquetra);
                    tabOutraOrquestra.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAdiOrquetra);

                    if (!lblCodCargo.Text.Equals(string.Empty))
                    {
                        if (CargoSelecao.PermiteInstrumento.Equals("Sim"))
                        {
                            if (BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAdiInstrumento).Equals(true))
                            {
                                gpoEstudo.Enabled = true;

                                //Verifica quais opções de seleção sera liberado
                                //Aluno no Gem
                                if (CargoSelecao.AlunoGem.Equals("Sim"))
                                {
                                    optGem.Enabled = true;
                                }
                                else
                                {
                                    optGem.Enabled = false;
                                }
                                //Ensaios
                                if (CargoSelecao.Ensaio.Equals("Sim"))
                                {
                                    optEnsaio.Enabled = true;
                                }
                                else
                                {
                                    optEnsaio.Enabled = false;
                                }
                                //Meia Hora
                                if (CargoSelecao.MeiaHora.Equals("Sim"))
                                {
                                    optMeiaHora.Enabled = true;
                                }
                                else
                                {
                                    optMeiaHora.Enabled = false;
                                }
                                //Reunião de Jovens
                                if (CargoSelecao.Rjm.Equals("Sim"))
                                {
                                    optRjm.Enabled = true;
                                }
                                else
                                {
                                    optRjm.Enabled = false;
                                }
                                //Culto Oficial
                                if (CargoSelecao.Culto.Equals("Sim"))
                                {
                                    optCulto.Enabled = true;
                                }
                                else
                                {
                                    optCulto.Enabled = false;
                                }
                                //Oficialização
                                if (CargoSelecao.Oficial.Equals("Sim"))
                                {
                                    optOficial.Enabled = true;
                                }
                                else
                                {
                                    optOficial.Enabled = false;
                                }
                            }
                        }
                        else
                        {
                            gpoEstudo.Enabled = false;
                        }
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermAtendimento()
        {
            try
            {
                apoio.AguardeAtendimento();

                //verificando se tem acesso a Aba Atendimento
                if (BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAtendimento))
                {
                    //Caso tenha, habilita a aba Atendimento
                    tabAtendimento.Enabled = true;

                    ///Verifica se tem acesso para editar o atendimento a Região
                    if (BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAteRegiao))
                    {
                        ///Verifica se o Cargo permite Regiao
                        if (CargoSelecao != null && CargoSelecao.AtendeRegiao != null && CargoSelecao.AtendeRegiao.Equals("Sim"))
                        {
                            optAtRegSim.CheckedChanged -= new EventHandler(optAtRegSim_CheckedChanged);

                            //Caso o Usuario tenha acesso e o Cargo permite Regiao, habilita o Campo
                            gpoAtReg.Enabled = true;
                            optAtRegSim.Checked = true;
                            lblAtendeRegiao.Text = "Sim";

                            optAtRegSim.CheckedChanged += new EventHandler(optAtRegSim_CheckedChanged);

                            ///Verifica se o AtendeRegiao está marcado com Sim
                            if (lblAtendeRegiao.Text.Equals("Sim"))
                            {
                                ///Libera os ítens da Aba Regiao
                                tabAtende.Enabled = true;

                                if (CargoSelecao.AtendeEnsaioLocal.Equals("Sim"))
                                {
                                    chkAtEnsLoc.Enabled = true;
                                }
                                else
                                {
                                    chkAtEnsLoc.Checked = false;
                                    chkAtEnsLoc.Enabled = false;
                                }

                                if (CargoSelecao.AtendeEnsaioTecnico.Equals("Sim"))
                                {
                                    chkAtEnsTec.Enabled = true;
                                }
                                else
                                {
                                    chkAtEnsTec.Checked = false;
                                    chkAtEnsTec.Enabled = false;
                                }

                                if (CargoSelecao.AtendePreTesteRjmMusico.Equals("Sim"))
                                {
                                    chkPreRjmMus.Enabled = true;
                                }
                                else
                                {
                                    chkPreRjmMus.Checked = false;
                                    chkPreRjmMus.Enabled = false;
                                }

                                if (CargoSelecao.AtendePreTesteRjmOrganista.Equals("Sim"))
                                {
                                    chkPreRjmOrg.Enabled = true;
                                }
                                else
                                {
                                    chkPreRjmOrg.Checked = false;
                                    chkPreRjmOrg.Enabled = false;
                                }

                                if (CargoSelecao.AtendePreTesteCultoMusico.Equals("Sim"))
                                {
                                    chkPreCultoMus.Enabled = true;
                                }
                                else
                                {
                                    chkPreCultoMus.Checked = false;
                                    chkPreCultoMus.Enabled = false;
                                }

                                if (CargoSelecao.AtendePreTesteCultoOrganista.Equals("Sim"))
                                {
                                    chkPreCultoOrg.Enabled = true;
                                }
                                else
                                {
                                    chkPreCultoOrg.Checked = false;
                                    chkPreCultoOrg.Enabled = false;
                                }

                                if (CargoSelecao.AtendePreTesteOficialMusico.Equals("Sim"))
                                {
                                    chkPreOficialMus.Enabled = true;
                                }
                                else
                                {
                                    chkPreOficialMus.Checked = false;
                                    chkPreOficialMus.Enabled = false;
                                }

                                if (CargoSelecao.AtendePreTesteCultoOrganista.Equals("Sim"))
                                {
                                    chkPreOficialOrg.Enabled = true;
                                }
                                else
                                {
                                    chkPreOficialOrg.Checked = false;
                                    chkPreOficialOrg.Enabled = false;
                                }

                                if (CargoSelecao.AtendeEnsaioRegional.Equals("Sim"))
                                {
                                    chkAtEnsReg.Enabled = true;
                                }
                                else
                                {
                                    chkAtEnsReg.Checked = false;
                                    chkAtEnsReg.Enabled = false;
                                }

                                if (CargoSelecao.AtendeEnsaioParcial.Equals("Sim"))
                                {
                                    chkAtEnsParc.Enabled = true;
                                }
                                else
                                {
                                    chkAtEnsParc.Checked = false;
                                    chkAtEnsParc.Enabled = false;
                                }

                                if (CargoSelecao.AtendeTesteRjmMusico.Equals("Sim"))
                                {
                                    chkTesRjmMus.Enabled = true;
                                }
                                else
                                {
                                    chkTesRjmMus.Checked = false;
                                    chkTesRjmMus.Enabled = false;
                                }

                                if (CargoSelecao.AtendeTesteRjmOrganista.Equals("Sim"))
                                {
                                    chkTesRjmOrg.Enabled = true;
                                }
                                else
                                {
                                    chkTesRjmOrg.Checked = false;
                                    chkTesRjmOrg.Enabled = false;
                                }

                                if (CargoSelecao.AtendeTesteCultoMusico.Equals("Sim"))
                                {
                                    chkTesCultoMus.Enabled = true;
                                }
                                else
                                {
                                    chkTesCultoMus.Checked = false;
                                    chkTesCultoMus.Enabled = false;
                                }

                                if (CargoSelecao.AtendeTesteCultoOrganista.Equals("Sim"))
                                {
                                    chkTesCultoOrg.Enabled = true;
                                }
                                else
                                {
                                    chkTesCultoOrg.Checked = false;
                                    chkTesCultoOrg.Enabled = false;
                                }

                                if (CargoSelecao.AtendeTesteOficialMusico.Equals("Sim"))
                                {
                                    chkTesOficialMus.Enabled = true;
                                }
                                else
                                {
                                    chkTesOficialMus.Checked = false;
                                    chkTesOficialMus.Enabled = false;
                                }

                                if (CargoSelecao.AtendeTesteOficialOrganista.Equals("Sim"))
                                {
                                    chkTesOficialOrg.Enabled = true;
                                }
                                else
                                {
                                    chkTesOficialOrg.Checked = false;
                                    chkTesOficialOrg.Enabled = false;
                                }

                                if (CargoSelecao.AtendeBatismo.Equals("Sim"))
                                {
                                    chkAtBatismo.Enabled = true;
                                }
                                else
                                {
                                    chkAtBatismo.Checked = false;
                                    chkAtBatismo.Enabled = false;
                                }

                                if (CargoSelecao.AtendeSantaCeia.Equals("Sim"))
                                {
                                    chkAtCeia.Enabled = true;
                                }
                                else
                                {
                                    chkAtCeia.Checked = false;
                                    chkAtCeia.Enabled = false;
                                }

                                if (CargoSelecao.AtendeReuniaoMinisterial.Equals("Sim"))
                                {
                                    chkAtReunMin.Enabled = true;
                                }
                                else
                                {
                                    chkAtReunMin.Checked = false;
                                    chkAtReunMin.Enabled = false;
                                }

                                if (CargoSelecao.AtendeOrdenacao.Equals("Sim"))
                                {
                                    chkAtOrdenacao.Enabled = true;
                                }
                                else
                                {
                                    chkAtOrdenacao.Checked = false;
                                    chkAtOrdenacao.Enabled = false;
                                }

                                if (CargoSelecao.AtendeReuniaoMocidade.Equals("Sim"))
                                {
                                    chkAtReunMoc.Enabled = true;
                                }
                                else
                                {
                                    chkAtReunMoc.Checked = false;
                                    chkAtReunMoc.Enabled = false;
                                }

                                if (CargoSelecao.AtendeRJM.Equals("Sim"))
                                {
                                    chkAtRjm.Enabled = true;
                                }
                                else
                                {
                                    chkAtRjm.Checked = false;
                                    chkAtRjm.Enabled = false;
                                }

                                if (CargoSelecao.AtendeCasal.Equals("Sim"))
                                {
                                    chkAtCasal.Enabled = true;
                                }
                                else
                                {
                                    chkAtCasal.Checked = false;
                                    chkAtCasal.Enabled = false;
                                }

                                tabAtende.SelectedTab.Name.Equals("tabAtendeRegiao");

                            }
                            ///Caso o lblAtendeRegiao esteja Marcado como Não Desabilita os campos
                            else
                            {
                                chkAtEnsReg.Checked = false;
                                chkAtEnsReg.Enabled = false;
                                chkAtEnsParc.Checked = false;
                                chkAtEnsParc.Enabled = false;
                                chkTesRjmMus.Checked = false;
                                chkTesRjmMus.Enabled = false;
                                chkTesRjmOrg.Checked = false;
                                chkTesRjmOrg.Enabled = false;
                                chkTesCultoMus.Checked = false;
                                chkTesCultoMus.Enabled = false;
                                chkTesCultoOrg.Checked = false;
                                chkTesCultoOrg.Enabled = false;
                                chkTesOficialMus.Checked = false;
                                chkTesOficialMus.Enabled = false;
                                chkTesOficialOrg.Checked = false;
                                chkTesOficialOrg.Enabled = false;
                                chkAtBatismo.Checked = false;
                                chkAtBatismo.Enabled = false;
                                chkAtCeia.Checked = false;
                                chkAtCeia.Enabled = false;
                                chkAtReunMin.Checked = false;
                                chkAtReunMin.Enabled = false;
                                chkAtOrdenacao.Checked = false;
                                chkAtOrdenacao.Enabled = false;
                                chkAtReunMoc.Checked = false;
                                chkAtReunMoc.Enabled = false;
                                chkAtRjm.Checked = false;
                                chkAtRjm.Enabled = false;
                                chkAtCasal.Checked = false;
                                chkAtCasal.Enabled = false;
                            }
                        }
                        else
                        {
                            gpoAtReg.Enabled = false;
                            optAtRegNao.Checked = true;
                            lblAtendeRegiao.Text = "Não";
                            chkAtEnsReg.Enabled = false;
                            chkTesRjmMus.Enabled = false;
                            chkTesRjmOrg.Enabled = false;
                            chkTesCultoMus.Enabled = false;
                            chkTesCultoOrg.Enabled = false;
                            chkTesOficialMus.Enabled = false;
                            chkTesOficialOrg.Enabled = false;
                            chkAtBatismo.Enabled = false;
                            chkAtCeia.Enabled = false;
                            chkAtReunMin.Enabled = false;
                            chkAtOrdenacao.Enabled = false;
                            chkAtReunMoc.Enabled = false;
                            chkAtRjm.Enabled = false;
                            chkAtCasal.Enabled = false;
                        }
                    }
                    ///Verifica se tem acesso a editar o atendimento a Comum
                    if (BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAteComum))
                    {
                        ///Verifica se o Cargo permite Comum
                        if (CargoSelecao != null && CargoSelecao.AtendeComum != null && CargoSelecao.AtendeComum.Equals("Sim"))
                        {
                            optAtComSim.CheckedChanged -= new EventHandler(optAtComSim_CheckedChanged);

                            //Caso o Usuario tenha acesso e o Cargo permite Comum, habilita o Campo
                            gpoAtCom.Enabled = true;
                            optAtComSim.Checked = true;
                            lblAtendeComum.Text = "Sim";

                            ///Verifica se o AtendeComum está marcado com Sim
                            if (lblAtendeComum.Text.Equals("Sim"))
                            {
                                ///Verifica se o usuario tem acesso a Aba Instrutores
                                ///Percorre a lista para verificar acesso a Aba Comum
                                if (BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesAteInstrutor))
                                {
                                    ///Libera os ítens da Aba Comum
                                    tabAtende.Enabled = true;
                                    tabAtendeComum.Enabled = true;
                                    gpoCCBPes.Enabled = false;
                                    gridCCBPes.Enabled = true;

                                    if (CargoSelecao.AtendeEnsaioLocal.Equals("Sim"))
                                    {
                                        chkAtEnsLoc.Enabled = true;
                                    }
                                    else
                                    {
                                        chkAtEnsLoc.Checked = false;
                                        chkAtEnsLoc.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendeEnsaioParcial.Equals("Sim"))
                                    {
                                        chkAtEnsParc.Enabled = true;
                                    }
                                    else
                                    {
                                        chkAtEnsParc.Checked = false;
                                        chkAtEnsParc.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendeEnsaioTecnico.Equals("Sim"))
                                    {
                                        chkAtEnsTec.Enabled = true;
                                    }
                                    else
                                    {
                                        chkAtEnsTec.Checked = false;
                                        chkAtEnsTec.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendePreTesteRjmMusico.Equals("Sim"))
                                    {
                                        chkPreRjmMus.Enabled = true;
                                    }
                                    else
                                    {
                                        chkPreRjmMus.Checked = false;
                                        chkPreRjmMus.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendePreTesteRjmOrganista.Equals("Sim"))
                                    {
                                        chkPreRjmOrg.Enabled = true;
                                    }
                                    else
                                    {
                                        chkPreRjmOrg.Checked = false;
                                        chkPreRjmOrg.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendePreTesteCultoMusico.Equals("Sim"))
                                    {
                                        chkPreCultoMus.Enabled = true;
                                    }
                                    else
                                    {
                                        chkPreCultoMus.Checked = false;
                                        chkPreCultoMus.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendePreTesteCultoOrganista.Equals("Sim"))
                                    {
                                        chkPreCultoOrg.Enabled = true;
                                    }
                                    else
                                    {
                                        chkPreCultoOrg.Checked = false;
                                        chkPreCultoOrg.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendePreTesteOficialMusico.Equals("Sim"))
                                    {
                                        chkPreOficialMus.Enabled = true;
                                    }
                                    else
                                    {
                                        chkPreOficialMus.Checked = false;
                                        chkPreOficialMus.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendePreTesteCultoOrganista.Equals("Sim"))
                                    {
                                        chkPreOficialOrg.Enabled = true;
                                    }
                                    else
                                    {
                                        chkPreOficialOrg.Checked = false;
                                        chkPreOficialOrg.Enabled = false;
                                    }

                                    if (CargoSelecao.AtendeGEM.Equals("Sim"))
                                    {
                                        ///Habilita o Check AtendeGEM
                                        chkAtGem.Enabled = true;
                                    }
                                    else
                                    {
                                        chkAtGem.Checked = false;
                                        chkAtGem.Enabled = false;
                                    }

                                    ///Verifica se o Atende GEM está marcado e libera a Aba Instrutor
                                    if (lblAtendeGEM.Text.Equals("Sim"))
                                    {
                                        tabInstrutor.Enabled = true;
                                        gpoProfInstrum.Enabled = true;
                                        lblInstrutorSeguro.Enabled = true;
                                        txtInstrutor.Enabled = true;
                                        tabAtende.SelectedTab.Name.Equals("tabInstrutor");
                                    }
                                    else
                                    {
                                        tabInstrutor.Enabled = false;
                                        gpoProfInstrum.Enabled = false;
                                        lblInstrutorSeguro.Enabled = false;
                                        txtInstrutor.Enabled = false;
                                        tabAtende.SelectedTab.Name.Equals("tabAtendeComum");
                                    }
                                }
                                ///Caso não tenha acesso a Aba Instrutores, desabilita o CheCkGEM
                                else
                                {
                                    chkAtGem.Enabled = false;
                                    tabInstrutor.Enabled = false;
                                    gpoProfInstrum.Enabled = false;
                                    lblInstrutorSeguro.Enabled = false;
                                    txtInstrutor.Enabled = false;
                                }
                            }
                            ///Caso o lblAtendeComum esteja Marcado como Não Desabilita os campos
                            else
                            {
                                tabAtendeComum.Enabled = false;
                                tabInstrutor.Enabled = false;
                                gpoCCBPes.Enabled = false;
                                gridCCBPes.Enabled = false;
                                chkAtGem.Checked = false;
                                chkAtGem.Enabled = false;
                                chkAtEnsLoc.Checked = false;
                                chkAtEnsLoc.Enabled = false;
                                chkAtEnsTec.Checked = false;
                                chkAtEnsTec.Enabled = false;
                                chkAtEnsParc.Checked = false;
                                chkAtEnsParc.Enabled = false;
                                chkPreRjmMus.Checked = false;
                                chkPreRjmMus.Enabled = false;
                                chkPreRjmOrg.Checked = false;
                                chkPreRjmOrg.Enabled = false;
                                chkPreCultoMus.Checked = false;
                                chkPreCultoMus.Enabled = false;
                                chkPreCultoOrg.Checked = false;
                                chkPreCultoOrg.Enabled = false;
                                chkPreOficialMus.Checked = false;
                                chkPreOficialMus.Enabled = false;
                                chkPreOficialOrg.Checked = false;
                                chkPreOficialOrg.Enabled = false;
                            }
                        }
                        //Caso o Cargo não permita comum, desabilita os campos
                        else
                        {
                            gpoAtCom.Enabled = false;
                            optAtComNao.Checked = true;
                            tabAtendeComum.Enabled = false;
                            tabInstrutor.Enabled = false;
                            gpoCCBPes.Enabled = false;
                            gridCCBPes.Enabled = false;
                            chkAtGem.Enabled = false;
                            chkAtEnsLoc.Enabled = false;
                            chkAtEnsTec.Enabled = false;
                            chkAtEnsParc.Enabled = false;
                            chkPreRjmMus.Enabled = false;
                            chkPreRjmOrg.Enabled = false;
                            chkPreCultoMus.Enabled = false;
                            chkPreCultoOrg.Enabled = false;
                            chkPreOficialMus.Enabled = false;
                            chkPreOficialOrg.Enabled = false;
                        }
                    }

                    //Verifica qual Aba está habilitada e deixa o foco nela

                    if (tabAtendeComum.Enabled.Equals(true))
                    {
                        tabAtende.SelectTab("tabAtendeComum");
                    }
                    else
                    {
                        tabAtende.SelectTab("tabInstrutor");
                    }
                }
                else
                {
                    tabAtendimento.Enabled = false;
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
            finally
            {
                apoio.FecharAguardeAtendimento();
            }
        }

        #endregion

        #endregion

    }
}