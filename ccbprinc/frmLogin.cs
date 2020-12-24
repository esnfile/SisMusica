using BLL.Funcoes;
using BLL.Usuario;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using BLL.validacoes.Formularios;
using BLL.conecta;
using ccbusua;
using ENT.acessos;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.Valida;

namespace ccbprinc
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            bool retorno;
            BLL.conecta.conectarBanco formulario;
            formulario = new BLL.conecta.conectarBanco();

            try
            {
                retorno = formulario.conectar();
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                formulario.Close();
                formulario.Dispose();
            }
        }

        #region declarações

        BLL_usuario objBLL = null;
        BLL_parametros objBLL_Param = null;

        List<MOD_usuario> lista;
        List<MOD_usuario> listaSenha;
        List<MOD_parametros> listaParam = new List<MOD_parametros>();

        clsException excp;

        frmPrincipal FormPrincipal = null;
        frmSenha FormSenha = null;

        string vAlteraSenha;

        #endregion

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Abre Formulario aguarde
                apoio.Aguarde();
                carregaUsuario();
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                //Fecha Formulario aguarde
                apoio.FecharAguarde();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        #region funções privadas

        private void carregaUsuario()
        {
            try
            {
                if (txtUsuario.Text.Equals(string.Empty))
                {
                    txtSenha.Text = string.Empty;
                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                    throw new Exception("Olá para acessar o sistema é necessário" + '\n' + "informar o seu Usuário e Senha.");
                }
                objBLL = new BLL_usuario();
                lista = new List<MOD_usuario>();
                lista = objBLL.buscarUsuario(txtUsuario.Text, "Sim");

                if (lista.Count > 0)
                {

                    vAlteraSenha = lista[0].AlteraSenha;

                    if (vAlteraSenha.Equals("Sim"))
                    {
                        MessageBox.Show("Foi solicitado pelo Supervisor do sistema, que você " + '\n' +
                            "deverá alterar sua senha nesse login!" + '\n' + '\n' + "Por gentileza, informe a nova senha na próxima tela.", "Atenção", MessageBoxButtons.OK,MessageBoxIcon.Information);

                        FormSenha = new frmSenha(this, lista);
                        FormSenha.MdiParent = MdiParent;
                        FormSenha.Show();
                        Enabled = false;

                    }
                    else
                    {
                        listaSenha = new List<MOD_usuario>();
                        listaSenha = objBLL.buscarSenha(txtUsuario.Text, txtSenha.Text, "Sim");
                        if (listaSenha.Count > 0)
                        {

                            //buscando os Parametros do sistema
                            objBLL_Param = new BLL_parametros();

                            new BLL_Session(1, out listaParam);

                            modulos.CodRegional = listaParam[0].CodRegional.PadLeft(3, '0');
                            modulos.CodigoRegional = listaParam[0].CodigoRegional;
                            modulos.DescRegional = listaParam[0].DescricaoRegional;

                            new BLL_Session(Convert.ToInt64(listaSenha[0].CodUsuario), out listaSenha);
                            modulos.CodUsuario = listaSenha[0].CodUsuario;
                            modulos.CodPessoaUser = listaSenha[0].CodPessoa;
                            modulos.NomePessoaUser = listaSenha[0].Nome;
                            modulos.Usuario = listaSenha[0].Usuario;
                            modulos.Supervisor = listaSenha[0].Supervisor;

                            apoio.preencheUsuarioCCB(listaSenha[0].CodUsuario);
                            apoio.preencheUsuarioCargo(listaSenha[0].CodUsuario);

                            FormPrincipal = new frmPrincipal();
                            FormPrincipal.Show();
                            Hide();
                        }
                        else
                        {
                            if (txtSenha.Text.Equals(string.Empty))
                            {
                                txtSenha.Text = string.Empty;
                                txtSenha.Focus();
                                throw new Exception("Olá " + lista[0].Usuario + ", por favor informe a senha!");
                            }
                            else
                            {
                                txtSenha.Text = string.Empty;
                                txtSenha.Focus();
                                throw new Exception("Olá " + lista[0].Usuario + ", a senha que você informou não confere!" + '\n' + "Por favor, tente novamente.");
                            }
                        }
                    }
                }
                else
                {
                    txtSenha.Text = string.Empty;
                    txtUsuario.Focus();
                    txtUsuario.SelectAll();
                    throw new Exception("Usuário não encontrado!" + '\n' + "Impossível logar no sistema.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion
    }
}
