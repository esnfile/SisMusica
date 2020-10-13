using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using BLL.Funcoes;
using ENT.Erros;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using BLL.instrumentos;
using ENT.instrumentos;

namespace ccbinst
{
    public partial class frmTonalidade : Form
    {
        public frmTonalidade(Form forms, DataGridView gridPesquisa, List<MOD_tonalidade> lista)
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

                ///Recebe a lista e armazena
                listaTonalidade = lista;

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

        BLL_tonalidade objBLL = null;
        MOD_tonalidade objEnt = null;
        List<MOD_tonalidade> listaTonalidade = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        #endregion

        #region Eventos do Formulario

        private void cboNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!cboNota.Text.Equals(null))
                {
                    lblNota.Text = cboNota.Text;
                    formarTonalidade();
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
        private void optNatural_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lblNota.Text.Equals(string.Empty))
                {
                    lblAltera.Text = " Maior";
                    lblAlteracoes.Text = "Bequadro";
                    formarTonalidade();
                }
                else
                {
                    optNatural.Checked = false;
                    cboNota.Focus();
                    throw new Exception("Seleciona a nota!");
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
        private void optBemol_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lblNota.Text.Equals(string.Empty))
                {
                    lblAltera.Text = " b Maior";
                    lblAlteracoes.Text = "Bemol";
                    formarTonalidade();
                }
                else
                {
                    optBemol.Checked = false;
                    cboNota.Focus();
                    throw new Exception("Seleciona a nota!");
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
        private void optSustenido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!lblNota.Text.Equals(string.Empty))
                {
                    lblAltera.Text = " # Maior";
                    lblAlteracoes.Text = "Sustenido";
                    formarTonalidade();
                }
                else
                {
                    optSustenido.Checked = false;
                    cboNota.Focus();
                    throw new Exception("Seleciona a nota!");
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
        private void frmTonalidade_Load(object sender, EventArgs e)
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
        private void frmTonalidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Tonalidade"))
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
        private void frmTonalidade_FormClosed(object sender, FormClosedEventArgs e)
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
                    objBLL = new BLL_tonalidade();

                    if (Convert.ToInt16(txtCodigo.Text).Equals(0))
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
                    if (formChama.Name.Equals("frmTonalidadeBusca"))
                    {
                        ((frmTonalidadeBusca)formChama).carregaGrid("Tonalidade", objEnt.CodTonalidade, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmTonalidade_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmTonalidade_FormClosing);

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
                if (lblNota.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nota! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblAlteracoes.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Alterações! Campo obrigatório.";
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
        private MOD_tonalidade criarTabela()
        {
            try
            {
                objEnt = new MOD_tonalidade();
                objEnt.CodTonalidade = txtCodigo.Text;
                objEnt.Nota = cboNota.Text;
                objEnt.Alteracoes = lblAlteracoes.Text;
                objEnt.DescTonalidade = txtDescricao.Text;

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
        /// <param name="listaTonalidade"></param>
        internal void preencher(List<MOD_tonalidade> listaTonalidade)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaTonalidade[0].CodTonalidade;
                txtDescricao.Text = listaTonalidade[0].DescTonalidade;
                cboNota.Text = listaTonalidade[0].Nota;
                lblNota.Text = listaTonalidade[0].Nota;
                lblAlteracoes.Text = listaTonalidade[0].Alteracoes;

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
        /// Função que verifica os valores e marca as Opções
        /// </summary>
        internal void verificacoes()
        {
            try
            {
                ///verifica AtendeComum
                if (lblAlteracoes.Text.Equals("Bequadro"))
                {
                    optNatural.Checked = true;
                    lblAltera.Text = " Maior";
                }
                else if (lblAlteracoes.Text.Equals("Bemol"))
                {
                    optBemol.Checked = true;
                    lblAltera.Text = " b Maior";
                }
                else if (lblAlteracoes.Text.Equals("Sustenido"))
                {
                    optSustenido.Checked = true;
                    lblAltera.Text = " # Maior";
                }
                formarTonalidade();
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
        /// Função que define o nome da Ton
        /// alidade
        /// </summary>
        private void formarTonalidade()
        {
            txtDescricao.Text = Convert.ToString(lblNota.Text + lblAltera.Text);
        }

        /// <summary>
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                pnlTonalidade.Enabled = false;
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
                pnlTonalidade.Enabled = true;
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
            cboNota.Focus();
        }

        #endregion

    }
}
