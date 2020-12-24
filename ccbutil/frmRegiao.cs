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

namespace ccbutil
{
    public partial class frmRegiao : Form
    {
        public frmRegiao(Form forms, DataGridView gridPesquisa, List<MOD_regiaoAtuacao> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaRegiao = lista;

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

        BLL_regiaoAtuacao objBLL = null;
        MOD_regiaoAtuacao objEnt = null;
        List<MOD_regiaoAtuacao> listaRegiao = null;

        BLL_regional objBLL_Reg = null;
        List<MOD_regional> listaRegional = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        #endregion

        #region Eventos do Formulario

        private void txtRegional_Leave(object sender, EventArgs e)
        {
            if (!txtRegional.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaRegional(txtRegional.Text);
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
        private void btnRegional_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmReg");
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
        private void frmRegiao_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso

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
        private void frmRegiao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Região"))
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
        private void frmRegiao_FormClosed(object sender, FormClosedEventArgs e)
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
                if (ValidarControles().Equals(true))
                {
                    objBLL = new BLL_regiaoAtuacao();

                    if (Convert.ToInt32(txtCodigo.Text).Equals(0))
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
                    if (formChama.Name.Equals("frmRegiaoBusca"))
                    {
                        ((frmRegiaoBusca)formChama).carregaGrid("Regiao", objEnt.CodRegiao, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmRegiao_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmRegiao_FormClosing);

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
                if (txtCodigoRegiao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Identificador! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtDescricao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nome da Região! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblDescricaoRegional.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Regional! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
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
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_regiaoAtuacao criarTabela()
        {
            try
            {
                objEnt = new MOD_regiaoAtuacao();
                objEnt.CodRegiao = txtCodigo.Text;
                objEnt.Codigo = txtCodigoRegiao.Text;
                objEnt.DescRegiao = txtDescricao.Text;
                objEnt.CodRegional = txtRegional.Text;

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
        internal void preencher(List<MOD_regiaoAtuacao> listaReg)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaReg[0].CodRegiao;
                txtCodigoRegiao.Text = listaReg[0].Codigo;
                txtDescricao.Text = listaReg[0].DescRegiao;
                txtRegional.Text = listaReg[0].CodRegional;
                lblDescricaoRegional.Text = listaReg[0].CodigoRegional + " - " + listaReg[0].DescricaoRegional;

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
        /// Função que carrega a Regional pesquisado pelo Código
        /// </summary>
        /// <param name="vCodRegional"></param>
        internal void carregaRegional(string vCodRegional)
        {
            try
            {
                objBLL_Reg = new BLL_regional();
                listaRegional = objBLL_Reg.buscarCod(vCodRegional);

                if (listaRegional != null && listaRegional.Count > 0)
                {
                    txtRegional.Text = listaRegional[0].CodRegional.PadLeft(5, '0');
                    lblDescricaoRegional.Text = listaRegional[0].Codigo + " - " + listaRegional[0].Descricao;
                }
                else
                {
                    abrirForm("frmReg");
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
        private void abrirForm(string form)
        {
            try
            {
                if (form.Equals("frmReg"))
                {
                    txtRegional.Text = string.Empty;
                    lblDescricaoRegional.Text = string.Empty;

                    formulario = new frmPesquisaRegional(this);
                    ((frmPesquisaRegional)formulario).MdiParent = MdiParent;
                    ((frmPesquisaRegional)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaRegional)formulario));
                    ((frmPesquisaRegional)formulario).Show();
                    ((frmPesquisaRegional)formulario).BringToFront();
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
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                pnlRegiao.Enabled = false;
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
                pnlRegiao.Enabled = true;
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
            txtCodigoRegiao.Focus();
        }

        #endregion

    }
}
