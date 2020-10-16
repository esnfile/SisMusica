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
using ENT.importa;

namespace ccbimp
{
    public partial class frmPessoaErros : Form
    {
        public frmPessoaErros(Form forms, string CodImporta, string CodImportaErro, List<MOD_pessoa> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                txtCodImportaErro.Text = CodImportaErro;

                //carregando a lista de permissões de acesso.
                listaAcesso = modulos.listaLibAcesso;

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

        clsException excp;
        List<MOD_acessos> listaAcesso = null;

        BLL_pessoa objBLL = null;
        MOD_pessoa objEnt = null;
        List<MOD_pessoa> listaPessoa = null;

        BLL_ccb objBLL_CCB = null;
        List<MOD_ccb> listaCCB = null;

        BLL_cidade objBLL_Cid = null;
        List<MOD_cidade> listaCidade = null;

        BLL_cargo objBLL_Cargo = null;
        List<MOD_cargo> listaCargo = null;
        MOD_cargo CargoSelecao = null;

        BLL_instrumento objBLL_Instrumento = null;
        List<MOD_instrumento> listaInstrAdicionais = null;
        
        BLL_metodoInstr objBLL_MetInstrumento = null;
        BindingList<MOD_metodoInstr> listaMetInstrumento = null;
        List<MOD_metodos> listaMetodos = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formChama;

        string foto = null;

        #endregion

        #region eventos do formulario

        #region Aba Geral

        private void optMasculino_Click(object sender, EventArgs e)
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
        private void optFeminino_Click(object sender, EventArgs e)
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
            }
            else
            {
                lblAtivo.Text = "Não";
            }
        }
        private void optPaisSim_CheckedChanged(object sender, EventArgs e)
        {
            if (optPaisSim.Checked.Equals(true))
            {
                lblPaiCCB.Text = "Sim";
            }
        }
        private void optPaisNao_CheckedChanged(object sender, EventArgs e)
        {
            if (optPaisNao.Checked.Equals(true))
            {
                lblPaiCCB.Text = "Não";
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
        }
        private void chkAlunoInstr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAlunoInstr.Checked.Equals(true))
            {
                lblAlunoInstr.Text = "Sim";
            }
            else
            {
                lblAlunoInstr.Text = "Não";
            }
        }

        private void optGem_CheckedChanged(object sender, EventArgs e)
        {
            if (optGem.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Aluno GEM";
            }
        }
        private void optEnsaio_CheckedChanged(object sender, EventArgs e)
        {
            if (optEnsaio.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Ensaios";
            }
        }
        private void optRjm_CheckedChanged(object sender, EventArgs e)
        {
            if (optRjm.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Reunião Jovens";
            }
        }
        private void optCulto_CheckedChanged(object sender, EventArgs e)
        {
            if (optCulto.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Culto Oficial";
            }
        }
        private void optOficial_CheckedChanged(object sender, EventArgs e)
        {
            if (optOficial.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Oficializado";
            }
        }
        private void optMeiaHora_CheckedChanged(object sender, EventArgs e)
        {
            if (optMeiaHora.Checked.Equals(true))
            {
                lblDesenvolvimento.Text = "Meia Hora";
            }
        }

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
        private void frmPessoaErros_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                tabGeral.Enabled = true;
                tabAdicionais.Enabled = false;
                tabGem.Enabled = true;
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
        private void frmPessoaErros_FormClosing(object sender, FormClosingEventArgs e)
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
        private void frmPessoaErros_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void tabPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPessoa.SelectedIndex.Equals(tabAdicionais))
                {
                    if (cboInstrumento.SelectedIndex.Equals(-1))
                    {
                    }
                }
                else if (tabPessoa.SelectedIndex.Equals(tabGem))
                {
                    //if (listaMetodo == null || listaMetodo.Count < 1)
                    //{
                    //    apoio.Aguarde();
                    //    carregaMetodos(txtCodigo.Text);
                    //}
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
                if (ValidarControles().Equals(true))
                {
                    if (ValidarCpf().Equals(true))
                    {
                        objBLL = new BLL_pessoa();

                        if (Convert.ToInt64(txtCodigo.Text).Equals(0))
                        {
                            //chama a rotina da camada de negocios para efetuar inserção ou update
                            objBLL.inserir(criarTabela());
                        }
                        else
                        {
                            //chama a rotina da camada de negocios para efetuar inserção ou update
                            objBLL.salvar(criarTabela());
                        }

                        //conversor para retorno ao formulario que chamou
                        if (formChama.Name.Equals("frmImportarPessoaErros"))
                        {
                            ((frmImportarPessoaErros)formChama).objEnt_ItemErro = criarItemImportado();
                            ((frmImportarPessoaErros)formChama).salvarItem();
                        }

                        FormClosing -= new FormClosingEventHandler(frmPessoaErros_FormClosing);

                        Close();

                        FormClosing += new FormClosingEventHandler(frmPessoaErros_FormClosing);
                    }
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
        private bool ValidarControles()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (cboCodCargo.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Cargo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtNome.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nome! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtNascimento.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Data Nascimento! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtCpf.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "C.P.F.! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblSexo.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Sexo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtCodCidRes.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Cep! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtEndRes.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Endereço! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtNumRes.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Número! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtBairroRes.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Bairro! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtEmail.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É aconselhável informar o e-mail, é uma ótima forma de contato.";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtTel1.Text.Equals(string.Empty) && this.txtTel2.Text.Equals(string.Empty) &&
                    txtCel1.Text.Equals(string.Empty) && this.txtCel2.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Necessário informar ao menos um Telefone ou Celular!";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtCodigoCCB.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Comum Congregação! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                if (lblAtivo.Text.Equals("Não"))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Adicionais -> Pessoa Inativa. Confirma essa informação?";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblFormacaoFora.Text.Equals("Sim"))
                {
                    if (txtLocalFormacao.Text.Equals(string.Empty))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Formação. Informe o local onde se formou!";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (txtQualFormacao.Text.Equals(string.Empty))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Formação. Informe a formação musical!";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                if (lblOutraOrquestra.Text.Equals("Sim"))
                {
                    if (txtOrquestra1.Text.Equals(string.Empty) || txtFuncao1.Text.Equals(string.Empty))
                    {
                        blnValida = false;
                        objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Outras Orquestras. Informe a Orquestra e Função 01!";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }

                //chama o formulário para gerar os erros
                if (blnValida.Equals(false))
                {
                    blnRetorno = apoio.AbrirErros(listaErros, this);
                }
                return blnRetorno;
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
        /// Funcão que valida o CPF digitado, caso tenha outra pessoa
        /// cadastrado com esse CPF retorna o cadastro para edição
        /// </summary>
        private bool ValidarCpf()
        {
            try
            {
                if (txtCpf.Text.Equals("000.000.000-00"))
                {
                    if (modulos.listaParametros[0].CpfZerado.Equals("Sim"))
                    {
                        return true;
                    }
                    else
                    {
                        txtCpf.Focus();
                        txtCpf.SelectAll();
                        throw new Exception("C.P.F. inválido!");
                    }
                }
                else
                {
                    objBLL = new BLL_pessoa();
                    List<MOD_pessoa> listaValidaCpf = new List<MOD_pessoa>();
                    listaValidaCpf = objBLL.buscarCpf(txtCpf.Text);

                    if (listaValidaCpf.Count > 0)
                    {
                        if (!Convert.ToInt64(listaValidaCpf[0].CodPessoa).Equals(Convert.ToInt64(this.txtCodigo.Text)))
                        {
                            if (MessageBox.Show("Pessoa já cadastrada!" + "\n" +
                                                "Código: " + listaValidaCpf[0].CodPessoa + '\n' +
                                                "Nome: " + listaValidaCpf[0].Nome + '\n' + '\n' +
                                                "Deseja editar essa Pessoa?",
                                                "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                            {
                                preencher(listaValidaCpf);
                                enabledForm();
                                return false;
                            }
                            else
                            {
                                txtCpf.Focus();
                                txtCpf.SelectAll();
                                return false;
                            }
                        }
                    }
                    return true;
                }
            }
            catch (SqlException exl)
            {
                return false;
                throw exl;
            }
            catch (Exception ex)
            {
                return false;
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

                //retorna o objeto Foto preenchido
                objEnt.FotoPessoa = criarFoto();

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
                objEnt.FotoPessoa.Foto = foto;
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private MOD_importaPessoaItemErro criarItemImportado()
        {
            try
            {
                //instancia a entidade
                MOD_importaPessoaItemErro ent = new MOD_importaPessoaItemErro();

                //adiciona os campos às propriedades
                ent.CodImportaPessoaItem = txtCodImportaErro.Text;
                ent.CodImportaPessoa = txtCodImporta.Text;
                ent.DataCadastro = txtDataCadastro.Text;
                ent.HoraCadastro = txtHoraCadastro.Text;
                ent.CodCargo = Convert.ToString(cboCodCargo.SelectedValue);
                ent.Nome = txtNome.Text;
                ent.DataNasc = txtNascimento.Text;
                ent.Cpf = txtCpf.Text;
                ent.Rg = txtRg.Text;
                ent.OrgaoEmissor = txtOrgaoEmissor.Text;
                ent.Sexo = lblSexo.Text;
                ent.DataBatismo = txtBatismo.Text;
                ent.CodCidadeRes = txtCodCidRes.Text;
                ent.EndRes = txtEndRes.Text;
                ent.NumRes = txtNumRes.Text;
                ent.BairroRes = txtBairroRes.Text;
                ent.ComplRes = txtCompRes.Text;
                ent.Telefone1 = txtTel1.Text;
                ent.Telefone2 = txtTel2.Text;
                ent.Celular1 = txtCel1.Text;
                ent.Celular2 = txtCel2.Text;
                ent.Email = txtEmail.Text;
                ent.CodCCB = txtCodCCB.Text;
                ent.CodigoCCB = txtCodigoCCB.Text;
                ent.DescCargo = txtDescCCB.Text;
                ent.EstadoCivil = cboEstadoCivil.Text;
                ent.DataApresentacao = txtApresentacao.Text;
                ent.PaisCCB = lblPaiCCB.Text;
                ent.Pai = txtPai.Text;
                ent.Mae = txtMae.Text;
                ent.FormacaoFora = lblFormacaoFora.Text;
                ent.LocalFormacao = txtLocalFormacao.Text;
                ent.QualFormacao = txtQualFormacao.Text;
                ent.OutraOrquestra = lblOutraOrquestra.Text;
                ent.Orquestra1 = txtOrquestra1.Text;
                ent.Funcao1 = txtFuncao1.Text;
                ent.Orquestra2 = txtOrquestra2.Text;
                ent.Funcao2 = txtFuncao2.Text;
                ent.Orquestra3 = txtOrquestra3.Text;
                ent.Funcao3 = txtFuncao3.Text;
                ent.CodInstrumento = Convert.ToString(cboInstrumento.SelectedValue);
                ent.CodCCBGem = txtCodCCBGem.Text;
                ent.DescCCBGem = txtDescricaoCCBGem.Text;
                ent.Desenvolvimento = lblDesenvolvimento.Text;
                ent.DataUltimoTeste = txtUltimoTeste.Text;
                ent.DataInicioEstudo = txtDataInicio.Text;
                ent.ExecutInstrumento = lblAlunoInstr.Text;

                //retorna a lista com os valores pesquisados
                return ent;
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
                txtCodigo.Text = string.IsNullOrEmpty(listaPes[0].CodPessoa) ? "000000": listaPes[0].CodPessoa;
                lblAtivo.Text = listaPes[0].Ativo;
                txtDataCadastro.Text = listaPes[0].DataCadastro;
                txtHoraCadastro.Text = listaPes[0].HoraCadastro;
                lblSexo.Text = listaPes[0].Sexo;
                lblCodCargo.Text = listaPes[0].CodCargo;
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

                ///verificações para preenchimento de radiobuttons
                verificacoes();

                //Carregar a Foto
                carregaFoto(listaPes);

                if (!listaPes[0].CodCCB.Contains("Erro"))
                {
                    //carregar Comum
                    carregaComum(listaPes[0].CodCCB, "Comum");
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
        /// Função que carrega a foto da Pessoa na base de dados
        /// </summary>
        private void carregaFoto(List<MOD_pessoa> listaPes)
        {
            try
            {
                if (listaPes[0].CarregarFotoPessoa != null && listaPes[0].CarregarFotoPessoa.Rows.Count > 0)
                {
                    foreach (DataRow row in listaPes[0].CarregarFotoPessoa.Rows)
                    {
                        try
                        {
                            lblCodFoto.Text = (string)(row.IsNull("CodFoto") ? Convert.ToString(null) : Convert.ToString(row["CodFoto"]));
                            byte[] bits = ((byte[])row["Foto"]);
                            MemoryStream memorybits = new MemoryStream(bits);
                            Bitmap bit = new Bitmap(memorybits);
                            pctFoto.Image = bit;
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
                        txtEndRes.Text = string.IsNullOrEmpty(listaCidade[0].Endereco) ? txtEndRes.Text : listaCidade[0].Tipo + " " + listaCidade[0].Endereco;
                        txtBairroRes.Text = string.IsNullOrEmpty(listaCidade[0].Bairro) ? txtBairroRes.Text : listaCidade[0].Bairro;
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
        /// Função que preenche o ComboBox Cargo
        /// </summary>
        /// <returns></returns>
        internal void carregaCargo()
        {
            try
            {
                objBLL_Cargo = new BLL_cargo();
                listaCargo = new List<MOD_cargo>();

                cboCodCargo.SelectedIndexChanged -= new EventHandler(cboCodCargo_SelectedIndexChanged); 
                    
                listaCargo = objBLL_Cargo.buscarCod(string.Empty);
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
            try
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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa"></param>
        internal void carregaPessoa(string vCodPessoa, string Campo)
        {
            try
            {
                BLL_pessoa objBLL_Pessoa = new BLL_pessoa();
                List<MOD_pessoa> listaPes = new List<MOD_pessoa>();
                List<MOD_pessoa> listaPesFiltro = new List<MOD_pessoa>();

                listaPes = objBLL_Pessoa.buscarCod(vCodPessoa, modulos.CodUsuarioCCB, modulos.CodUsuarioCargo);

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

                        formulario = new frmPesquisaPessoa(this, "Instrutor");
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
                txtNome.Enabled = false;
                tabDiversos.Enabled = false;
                tabFormacao.Enabled = false;
                gpoPais.Enabled = false;
                gpoDiversos.Enabled = false;
                tabGem.Enabled = false;
                gridMetodoAlu.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
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
                    lblAlunoInstr.Text = "Sim";
                }
                else if (lblDesenvolvimento.Text.Equals("Meia Hora"))
                {
                    optMeiaHora.Checked = true;
                    lblAlunoInstr.Text = "Sim";
                }
                else if (lblDesenvolvimento.Text.Equals("Reunião Jovens"))
                {
                    optRjm.Checked = true;
                    lblAlunoInstr.Text = "Sim";
                }
                else if (lblDesenvolvimento.Text.Equals("Culto Oficial"))
                {
                    optCulto.Checked = true;
                    lblAlunoInstr.Text = "Sim";
                }
                else if (lblDesenvolvimento.Text.Equals("Oficializado"))
                {
                    optOficial.Checked = true;
                    lblAlunoInstr.Text = "Sim";
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

        #region Aba Informações GEM

        /// <summary>
        /// Função que monta o GridView de Metódos - Aba Informações GEM
        /// </summary>
        private void montaGridMetododo()
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
        /// Função que carrega os Métodos
        /// </summary>
        /// <param name="CodPessoa"></param>
        private void carregaMetodoPessoa(string CodInstrumento)
        {
            //try
            //{
            //    List<MOD_metodoInstr> listaNova = new List<MOD_metodoInstr>();

            //    objBLL_MetInstrumento = new BLL_metodoInstr();
            //    listaMetInstrumento = objBLL_MetInstrumento.buscarInstrumento(CodInstrumento);

            //    objBLL_MetInstrumento = new BLL_metodoInstr();
            //    listaMetodos = objBLL_MetInstrumento.buscarMetodo()

            //    foreach (MOD_instrumento objEnt_Inst in listaInstrumento)
            //    {
            //        MOD_pessoaInstr ent = new MOD_pessoaInstr();

            //        ent.CodPessoaInstr = "0";
            //        ent.CodInstrumento = objEnt_Inst.CodInstrumento;
            //        ent.DescInstrumento = objEnt_Inst.DescInstrumento;
            //        ent.CodPessoa = "0";
            //        ent.Marcado = false;

            //        listaNova.Add(ent);
            //    }

            //    listaPessoaInstr.AddRange(listaNova);
            //    funcoes.gridInstrumentos(gridProfInst, "PessoaInstr");
            //    ///vincula a lista ao DataSource do DataGriView
            //    gridProfInst.DataSource = listaPessoaInstr;
            //}
            //catch (SqlException exl)
            //{
            //    throw exl;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
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
                        foto = dlg.FileName;
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
                    MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                    if (Convert.ToInt64(txtCodigo.Text).Equals(0))
                    {
                        lblCargo.Enabled = true;
                        cboCodCargo.Enabled = true;
                    }
                    else
                    {
                        lblCargo.Enabled = funcoes.liberacoes(entAcesso.rotPesAteraCargo);
                        cboCodCargo.Enabled = funcoes.liberacoes(entAcesso.rotPesAteraCargo);
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
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();

                tabAdicionais.Enabled = funcoes.liberacoes(entAcesso.rotPesAdicionais);

                if (tabAdicionais.Enabled.Equals(true))
                {
                    tabFormacao.Enabled = funcoes.liberacoes(entAcesso.rotPesAdiForma);
                    tabDiversos.Enabled = funcoes.liberacoes(entAcesso.rotPesAdiOrquetra);
                    tabOutraOrquestra.Enabled = funcoes.liberacoes(entAcesso.rotPesAdiOrquetra);

                    if (!lblCodCargo.Text.Equals(string.Empty))
                    {
                        if (CargoSelecao.PermiteInstrumento.Equals("Sim"))
                        {
                            if (funcoes.liberacoes(entAcesso.rotPesAdiInstrumento).Equals(true))
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

        #endregion

        #endregion

    }
}
