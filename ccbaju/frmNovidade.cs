using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using ENT.ajuda;
using BLL.ajuda;
using BLL.Funcoes;
using ENT.Erros;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using BLL.acessos;

namespace ccbaju
{
    public partial class frmNovidade : Form
    {
        public frmNovidade(Form forms, DataGridView gridPesquisa, List<MOD_novidades> lista)
        {
            InitializeComponent();
            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaNovidade = lista;
                txtData.Text = Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy");

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

        BLL_novidades objBLL = null;
        MOD_novidades objEnt = null;
        List<MOD_novidades> listaNovidade = null;

        BLL_programas objBLL_Pro = null;
        List<MOD_programas> listaPro = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formChama;
        Form formulario;

        DataGridView dataGrid;

        #endregion

        #region Eventos do Formulario

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

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
        private void frmNovidade_Load(object sender, EventArgs e)
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
        private void frmNovidade_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Novidade"))
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
        private void frmNovidade_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void txtPrograma_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPrograma;
        }
        private void txtPrograma_Leave(object sender, EventArgs e)
        {
            if (!txtPrograma.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaProg(txtPrograma.Text);
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
        private void btnPrograma_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmProg");
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
                    objBLL = new BLL_novidades();

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
                    if (formChama.Name.Equals("frmNovidadeBusca"))
                    {
                        ((frmNovidadeBusca)formChama).carregaGrid("Novidade", objEnt.CodNovidades, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmNovidade_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmNovidade_FormClosing);

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
                
                if (string.IsNullOrEmpty(cboStatus.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Status! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                else if (string.IsNullOrEmpty(cboTipoAtualiza.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Tipo de Atualização! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                else if (string.IsNullOrEmpty(cboAndamento.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Andamento! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                else if (string.IsNullOrEmpty(lblPrograma.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Programa! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                else if (string.IsNullOrEmpty(txtDescricao.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição das Novidades! Campo obrigatório.";
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
        private MOD_novidades criarTabela()
        {
            try
            {
                objEnt = new MOD_novidades();
                objEnt.CodNovidades = txtCodigo.Text;
                objEnt.Status = cboStatus.Text;
                objEnt.TipoAtualiza = cboTipoAtualiza.Text;
                objEnt.Andamento = cboAndamento.Text;
                objEnt.Data = txtData.Text;
                objEnt.CodPrograma = txtPrograma.Text;
                objEnt.Descricao = txtDescricao.Text;

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
        /// <param name="listaNov"></param>
        internal void preencher(List<MOD_novidades> listaNov)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaNov[0].CodNovidades;
                txtData.Text = listaNov[0].Data;
                cboStatus.Text = listaNov[0].Status;
                cboTipoAtualiza.Text = listaNov[0].TipoAtualiza;
                cboAndamento.Text = listaNov[0].Andamento;
                txtPrograma.Text = listaNov[0].CodPrograma;
                lblPrograma.Text = listaNov[0].DescPrograma + " - " + listaNov[0].DescSubModulo + " - " + listaNov[0].DescModulo;
                txtDescricao.Text = listaNov[0].Descricao;
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
                if (form.Equals("frmProg"))
                {
                    lblPrograma.Text = string.Empty;

                    formulario = new frmPesquisaPrograma(this);
                    ((frmPesquisaPrograma)formulario).MdiParent = MdiParent;
                    ((frmPesquisaPrograma)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaPrograma)formulario));
                    ((frmPesquisaPrograma)formulario).Show();
                    ((frmPesquisaPrograma)formulario).BringToFront();
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
        /// Função que carrega o Programa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodProg"></param>
        internal void carregaProg(string vCodProg)
        {
            try
            {
                objBLL_Pro = new BLL_programas();
                listaPro = objBLL_Pro.buscarCod(vCodProg);

                if (listaPro != null && listaPro.Count > 0)
                {
                    txtPrograma.Text = listaPro[0].CodPrograma;
                    lblPrograma.Text = listaPro[0].DescPrograma + " - " + listaPro[0].DescSubModulo + " - " + listaPro[0].DescModulo;
                }
                else
                {
                    abrirForm("frmProg");
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
                pnlNovidade.Enabled = false;
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
                pnlNovidade.Enabled = true;
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
            cboStatus.Focus();
        }

        #endregion

    }
}
