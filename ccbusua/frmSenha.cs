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
using BLL.pessoa;
using ENT.pessoa;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using Microsoft.VisualBasic;
using BLL.Usuario;

namespace ccbusua
{
    public partial class frmSenha : Form
    {
        public frmSenha(Form forms, List<MOD_usuario> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;

                //carregando a lista de permissões de acesso.
                listaAcesso = modulos.listaLibAcesso;

                ///Recebe a lista e armazena
                listaUsuario = lista;

                txtDataAlteraSenha.Text = DateTime.Now.ToString("dd/MM/yyyy");

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

        BLL_usuario objBLL = null;
        MOD_usuario objEnt = null;
        List<MOD_usuario> listaUsuario = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formChama;
        DataGridView dataGrid;

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
        private void frmSenha_Load(object sender, EventArgs e)
        {
            try
            {

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
        private void frmSenha_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
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
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmSenha_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void txtConfirme_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!txtConfirme.Text.Equals(txtNovaSenha.Text))
                {
                    e.Cancel = true;
                    throw new Exception("Senha de Confirmação não confere com a Nova Senha digitada!");
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
                    if (ValidarSenha().Equals(true))
                    {
                        objBLL = new BLL_usuario();

                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.salvarSenha(criarTabela());

                        //conversor para retorno ao formulario que chamou
                        if (formChama.Name.Equals("frmUsuario"))
                        {
                            buscarUsuario(txtCodUsuario.Text);
                            ((frmUsuario)formChama).preencher(listaUsuario);
                        }

                        FormClosing -= new FormClosingEventHandler(frmSenha_FormClosing);

                        Close();

                        FormClosing += new FormClosingEventHandler(frmSenha_FormClosing);
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
                if (txtSenhaAtual.Text.Equals(string.Empty) && txtSenhaAtual.Enabled.Equals(true))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Senha Atual! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtNovaSenha.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nova Senha! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtConfirme.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Confirmação de Senha! Campo obrigatório.";
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
        /// Funcão que valida a Senha Atual digitada
        /// </summary>
        private bool ValidarSenha()
        {
            try
            {
                objBLL = new BLL_usuario();
                List<MOD_usuario> listaValidaSenha = new List<MOD_usuario>();
                listaValidaSenha = objBLL.buscarSenha(txtUsuario.Text, txtSenhaAtual.Text, "Sim");

                if (listaValidaSenha.Count > 0 || txtSenhaAtual.Enabled.Equals(false))
                {
                    return true;
                }
                else
                {
                    throw new Exception("Senha atual não confere!");
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
        private MOD_usuario criarTabela()
        {
            try
            {
                objEnt = new MOD_usuario();
                objEnt.CodUsuario = txtCodUsuario.Text;
                objEnt.Senha = txtConfirme.Text;
                objEnt.DataAlteraSenha = txtDataAlteraSenha.Text;
                objEnt.AlteraSenha = "Não";

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
        /// <param name="listaSenha"></param>
        internal void preencher(List<MOD_usuario> listaSenha)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodUsuario.Text = listaSenha[0].CodUsuario;
                txtUsuario.Text = listaSenha[0].Usuario;
                txtPessoa.Text = listaSenha[0].Nome;

                if (listaSenha[0].AlteraSenha.Equals("Sim"))
                {
                    txtSenhaAtual.Text = string.Empty;
                    lblSenhaAnterior.Enabled = false;
                    txtSenhaAtual.Enabled = false;
                }
                else
                {
                    lblSenhaAnterior.Enabled = true;
                    txtSenhaAtual.Enabled = true;
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
        /// Função que Busca o Usuario Alterado o formulário para edição
        /// </summary>
        /// <param name="CodUsuario"></param>
        internal void buscarUsuario(string CodUsuario)
        {
            try
            {
                objBLL = new BLL_usuario();
                listaUsuario = objBLL.buscarCod(CodUsuario);
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
                pnlSenha.Enabled = false;
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
                pnlSenha.Enabled = true;
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
            txtSenhaAtual.Focus();
        }

        #endregion

    }
}