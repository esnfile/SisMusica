using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using ENT.instrumentos;
using BLL.instrumentos;
using BLL.Funcoes;
using ENT.Erros;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;

namespace ccbinst
{
    public partial class frmHinario : Form
    {
        public frmHinario(Form forms, DataGridView gridPesquisa, List<MOD_hinario> lista)
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
                listaHinario = lista;

                ///carrega os combos boxes
                //combos Tonalidade
                carregaInstrumentos(txtCodigo.Text);
                apoio.carregaComboTonalidade(cboTonalidade);

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

        BLL_hinario objBLL = null;
        MOD_hinario objEnt = null;
        List<MOD_hinario> listaHinario = null;

        BLL_tonalidade objBLL_Ton = null;
        List<MOD_tonalidade> listaTon = null;

        BLL_instrumento objBLL_Instr = null;
        List<MOD_instrumentoHinario> listaInstr = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formChama;

        DataGridView dataGrid;

        #endregion

        #region Eventos do Formulario

        private void cboTonalidade_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboTonalidade.SelectedValue != null)
            {
                try
                {
                    lblTonalidade.Text = Convert.ToString(cboTonalidade.SelectedValue);
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
        private void frmHinario_Load(object sender, EventArgs e)
        {
            try
            {
                //Carrega o Grid Instrumentos
                funcoes.gridInstrumentos(gridInstrumento, "Hinario");
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
        private void frmHinario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Hinário"))
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
        private void frmHinario_FormClosed(object sender, FormClosedEventArgs e)
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
                    objBLL = new BLL_hinario();

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
                    if (formChama.Name.Equals("frmHinarioBusca"))
                    {
                        ((frmHinarioBusca)formChama).carregaGrid("Hinario", objEnt.CodHinario, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmHinario_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmHinario_FormClosing);

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
                if (txtDescricao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                else if (lbTonalidade.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Tonalidade! Campo obrigatório.";
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
        private MOD_hinario criarTabela()
        {
            try
            {
                objEnt = new MOD_hinario();
                objEnt.CodHinario = txtCodigo.Text;
                objEnt.CodTonalidade = Convert.ToString(cboTonalidade.SelectedValue);
                objEnt.DescTonalidade = cboTonalidade.Text;
                objEnt.DescHinario = txtDescricao.Text;

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
        /// <param name="listaHin"></param>
        internal void preencher(List<MOD_hinario> listaHin)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaHin[0].CodHinario;
                lblTonalidade.Text = listaHin[0].CodTonalidade;
                cboTonalidade.SelectedValue = listaHin[0].CodTonalidade;
                txtDescricao.Text = listaHin[0].DescHinario;

                carregaInstrumentos(txtCodigo.Text);
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
        /// Função que preenche o ComboBox Tonalidade
        /// </summary>
        /// <returns></returns>
        internal void carregaTonalidade()
        {
            try
            {
                objBLL_Ton = new BLL_tonalidade();
                listaTon = new List<MOD_tonalidade>();

                listaTon = objBLL_Ton.buscarCod(string.Empty);
                cboTonalidade.DataSource = listaTon;
                cboTonalidade.ValueMember = "CodTonalidade";
                cboTonalidade.DisplayMember = "DescTonalidade";
                cboTonalidade.SelectedIndex = (-1);
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
        /// <param name="vCodHinario"></param>
        private void carregaInstrumentos(string vCodHinario)
        {
            try
            {
                objBLL_Instr = new BLL_instrumento();
                listaInstr = objBLL_Instr.buscarHinarioInstr(vCodHinario);

                funcoes.gridInstrumentos(gridInstrumento, "Hinario");
                ///vincula a lista ao DataSource do DataGriView
                gridInstrumento.DataSource = listaInstr;
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
                pnlHinario.Enabled = false;
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
                pnlHinario.Enabled = true;
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
            txtDescricao.Focus();
        }

        #endregion

    }
}
