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
    public partial class frmEscala : Form
    {
        public frmEscala(Form forms, DataGridView gridPesquisa, List<MOD_escala> lista)
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


                //preenche o combobox TipoEscala
                apoio.carregaComboTipoEscala(cboTipo);

                ///Recebe a lista e armazena
                listaEscala = lista;

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

        BLL_escala objBLL = null;
        MOD_escala objEnt = null;
        List<MOD_escala> listaEscala = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formChama;
        DataGridView dataGrid;

        #endregion

        #region Eventos do Formulario

        private void cboModelo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cboModelo.Text.Equals(null))
            {
                lblModelo.Text = cboModelo.Text;
                formarEscala();
            }
        }
        private void cboTonica_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!cboModelo.Text.Equals(null))
                {
                    if (!cboTonica.Text.Equals(null))
                    {
                        lblTonica.Text = cboTonica.Text;
                        formarEscala();
                    }
                }
                else
                {
                    cboTonica.SelectedIndex = (-1);
                    cboModelo.Focus();
                    throw new Exception("Selecione o Modelo da escala!");
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
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!lblAlteracoes.Text.Equals(null))
                {
                    if (!cboTipo.Text.Equals(null))
                    {
                        lblTipo.Text = cboTipo.Text;
                        formarEscala();
                    }
                }
                else
                {
                    cboTipo.SelectedIndex = (-1);
                    throw new Exception("Selecione as Alterações da escala!");
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
                if (!cboTonica.Text.Equals(null))
                {
                    lblAlteracoes.Text = "Bemol";
                    lblAltera.Text = "b";
                    formarEscala();
                }
                else
                {
                    optBemol.Checked = false;
                    cboTonica.Focus();
                    throw new Exception("Selecione a Tônica da escala!");
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
        private void optBequadro_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboTonica.Text.Equals(null))
                {
                    lblAlteracoes.Text = "Bequadro";
                    lblAltera.Text = "";
                    formarEscala();
                }
                else
                {
                    optBequadro.Checked = false;
                    cboTonica.Focus();
                    throw new Exception("Selecione a Tônica da escala!");
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
                if (!cboTonica.Text.Equals(null))
                {
                    lblAlteracoes.Text = "Sustenido";
                    lblAltera.Text = "#";
                    formarEscala();
                }
                else
                {
                    optSustenido.Checked = false;
                    cboTonica.Focus();
                    throw new Exception("Selecione a Tônica da escala!");
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
        private void optDBemol_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboTonica.Text.Equals(null))
                {
                    lblAlteracoes.Text = "DBemol";
                    lblAltera.Text = "bb";
                    formarEscala();
                }
                else
                {
                    optDBemol.Checked = false;
                    cboTonica.Focus();
                    throw new Exception("Selecione a Tônica da escala!");
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
        private void optDSustenido_Click(object sender, EventArgs e)
        {
            try
            {
                if (!cboTonica.Text.Equals(null))
                {
                    lblAlteracoes.Text = "DSustenido";
                    lblAltera.Text = "x";
                    formarEscala();
                }
                else
                {
                    optDSustenido.Checked = false;
                    cboTonica.Focus();
                    throw new Exception("Selecione a Tônica da escala!");
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
        private void frmEscala_Load(object sender, EventArgs e)
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
        private void frmEscala_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Escala"))
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
        private void frmEscala_FormClosed(object sender, FormClosedEventArgs e)
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
                    objBLL = new BLL_escala();

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
                    if (formChama.Name.Equals("frmEscalaBusca"))
                    {
                        ((frmEscalaBusca)formChama).carregaGrid("Escala", objEnt.CodEscala, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmEscala_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmEscala_FormClosing);

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
                if (lblModelo.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Modelo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblTonica.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Tônica! Campo obrigatório.";
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
                if (lblTipo.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Tipo! Campo obrigatório.";
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
        private MOD_escala criarTabela()
        {
            try
            {
                objEnt = new MOD_escala();
                objEnt.CodEscala = txtCodigo.Text;
                objEnt.DescEscala = txtDescricao.Text;
                objEnt.Modelo = lblModelo.Text;
                objEnt.Tonica = lblTonica.Text;
                objEnt.Alteracoes = lblAlteracoes.Text;
                objEnt.CodTipoEscala = Convert.ToString(cboTipo.SelectedValue);

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
        /// <param name="listaEscala"></param>
        internal void preencher(List<MOD_escala> listaEscala)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaEscala[0].CodEscala;
                txtDescricao.Text = listaEscala[0].DescEscala;
                lblModelo.Text = listaEscala[0].Modelo;
                cboModelo.Text = listaEscala[0].Modelo;
                lblTonica.Text = listaEscala[0].Tonica;
                cboTonica.Text = listaEscala[0].Tonica;
                lblAlteracoes.Text = listaEscala[0].Alteracoes;
                lblTipo.Text = listaEscala[0].DescTipo;
                cboTipo.SelectedValue = listaEscala[0].CodTipoEscala;

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
                    optBequadro.Checked = true;
                    lblAltera.Text = "";
                }
                else if (lblAlteracoes.Text.Equals("Bemol"))
                {
                    optBemol.Checked = true;
                    lblAltera.Text = "b";
                }
                else if (lblAlteracoes.Text.Equals("Sustenido"))
                {
                    optSustenido.Checked = true;
                    lblAltera.Text = "#";
                }
                else if (lblAlteracoes.Text.Equals("DBemol"))
                {
                    optDBemol.Checked = true;
                    lblAltera.Text = "bb";
                }
                else if (lblAlteracoes.Text.Equals("DSustenido"))
                {
                    optDSustenido.Checked = true;
                    lblAltera.Text = "x";
                }
                formarEscala();
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
        /// Função que define o nome da escala
        /// </summary>
        internal void formarEscala()
        {
            txtDescricao.Text = lblModelo.Text + ": " + lblTonica.Text + "" + lblAltera.Text + "- " + lblTipo.Text;
        }

        /// <summary>
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                pnlEscala.Enabled = false;
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
                pnlEscala.Enabled = true;
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
            gpoEscala.Focus();
        }

        #endregion

    }
}
