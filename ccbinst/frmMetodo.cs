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
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using System.IO;

namespace ccbinst
{
    public partial class frmMetodo : Form
    {
        public frmMetodo(Form forms, DataGridView gridPesquisa, List<MOD_metodos> lista)
        {
            InitializeComponent();
            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaMetodo = lista;

                carregaFamilia(txtCodigo.Text);

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

        BLL_metodos objBLL = null;
        MOD_metodos objEnt = null;
        List<MOD_metodos> listaMetodo = null;

        List<MOD_metodoFamilia> listaMetFamilia = null;
        List<MOD_familia> listaFamilia = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        Form formChama;
        DataGridView dataGrid;

        #endregion

        #region eventos do formulario

        private void optSolfejo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optSolfejo.Checked.Equals(true))
                {
                    gpoInstrumento.Enabled = true;
                    lblTipo.Text = "Solfejo";
                }
                else
                {
                    optPagina.Checked = false;
                    optFase.Checked = false;
                    optLicao.Checked = false;
                    gpoInstrumento.Enabled = false;
                    lblPaginaFase.Text = string.Empty;
                    lblTipo.Text = string.Empty;
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
        private void optInstrumento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optInstrumento.Checked.Equals(true))
                {
                    gpoInstrumento.Enabled = true;
                    lblTipo.Text = "Instrumento";
                }
                else
                {
                    optPagina.Checked = false;
                    optFase.Checked = false;
                    optLicao.Checked = false;
                    gpoInstrumento.Enabled = false;
                    lblPaginaFase.Text = string.Empty;
                    lblTipo.Text = string.Empty;
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
        private void optRitmo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optRitmo.Checked.Equals(true))
                {
                    gpoInstrumento.Enabled = true;
                    lblTipo.Text = "Ritmo";
                }
                else
                {
                    optPagina.Checked = false;
                    optFase.Checked = false;
                    optLicao.Checked = false;
                    gpoInstrumento.Enabled = false;
                    lblPaginaFase.Text = string.Empty;
                    lblTipo.Text = string.Empty;
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
        private void optSistema_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optSistema.Checked.Equals(true))
                {
                    lblTipoEscolha.Text = "Sistema";
                }
                else
                {
                    lblTipoEscolha.Text = string.Empty;
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
        private void optCandidato_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optCandidato.Checked.Equals(true))
                {
                    lblTipoEscolha.Text = "Candidato";
                }
                else
                {
                    lblTipoEscolha.Text = string.Empty;
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
        private void optPagina_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optPagina.Checked.Equals(true))
                {
                    lblPaginaFase.Text = "Página";
                }
                else
                {
                    lblPaginaFase.Text = string.Empty;
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
        private void optFase_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optFase.Checked.Equals(true))
                {
                    lblPaginaFase.Text = "Fase";
                }
                else
                {
                    lblPaginaFase.Text = string.Empty;
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
        private void optLicao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (optLicao.Checked.Equals(true))
                {
                    lblPaginaFase.Text = "Lição";
                }
                else
                {
                    lblPaginaFase.Text = string.Empty;
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

        private void gridMetodoFamilia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridMetodoFamilia != null || gridMetodoFamilia.RowCount > 0)
                {
                    if (listaMetFamilia[e.RowIndex].Marcado.Equals(true))
                    {
                        listaMetFamilia[e.RowIndex].Marcado = false;
                    }
                    else
                    {
                        listaMetFamilia[e.RowIndex].Marcado = true;
                    }
                    gridMetodoFamilia.Refresh();
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
        private void frmMetodo_Load(object sender, EventArgs e)
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
        private void frmMetodo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Método"))
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
        private void frmMetodo_FormClosed(object sender, FormClosedEventArgs e)
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
                    objBLL = new BLL_metodos();

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
                    if (formChama.Name.Equals("frmMetodoBusca"))
                    {
                        ((frmMetodoBusca)formChama).carregaGrid("Metodo", objEnt.CodMetodo, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmMetodo_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmMetodo_FormClosing);

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
                bool blnValidaGrid = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (lblTipoEscolha.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Escolha de Lições! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtDescricao.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (lblTipo.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Tipo de Método! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                foreach (MOD_metodoFamilia ent in listaMetFamilia)
                {

                    if (ent.Marcado.Equals(true))
                    {
                        blnValidaGrid = true;
                        break;
                    }
                    else
                    {
                        blnValidaGrid = false;
                    }
                }

                if (blnValidaGrid.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Necessário marcar pelo menos uma Família.";
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
        private MOD_metodos criarTabela()
        {
            try
            {
                objEnt = new MOD_metodos();
                objEnt.CodMetodo = txtCodigo.Text;
                objEnt.DescMetodo = txtDescricao.Text;
                objEnt.Compositor = txtCompositor.Text;
                objEnt.TipoEscolha = lblTipoEscolha.Text;
                objEnt.Tipo = lblTipo.Text;
                objEnt.Ativo = chkAtivo.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.PaginaFase = lblPaginaFase.Text;

                //retorna o objeto Instrumento Tom
                if (listaMetFamilia != null)
                {
                    objEnt.listaMetodoFamilia = listaMetFamilia;
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
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaMetodo"></param>
        internal void preencher(List<MOD_metodos> listaMet)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaMet[0].CodMetodo;
                txtDescricao.Text = listaMet[0].DescMetodo;
                txtCompositor.Text = listaMet[0].Compositor;
                lblTipoEscolha.Text = listaMet[0].TipoEscolha;
                lblTipo.Text = listaMet[0].Tipo;
                chkAtivo.Checked = listaMet[0].Ativo.Equals("Sim") ? true : false;
                lblPaginaFase.Text = listaMet[0].PaginaFase;

                ///verificações para preenchimento de radiobuttons
                verificacoes();

                //Carregar a Familia
                carregaFamilia(txtCodigo.Text);

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
                pnlMetodo.Enabled = false;
                gridMetodoFamilia.Enabled = false;
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
                pnlMetodo.Enabled = true;
                gridMetodoFamilia.Enabled = true;
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
                ///verifica a situação
                if (lblTipo.Text.Equals("Solfejo"))
                {
                    optSolfejo.Checked = true;
                }
                else if (lblTipo.Text.Equals("Instrumento"))
                {
                    optInstrumento.Checked = true;
                }
                else if (lblTipo.Text.Equals("Ritmo"))
                {
                    optRitmo.Checked = true;
                }

                if (lblTipoEscolha.Text.Equals("Sistema"))
                {
                    optSistema.Checked = true;
                }
                else if (lblTipoEscolha.Text.Equals("Candidato"))
                {
                    optCandidato.Checked = true;
                }

                if (lblPaginaFase.Text.Equals("Página"))
                {
                    optPagina.Checked = true;
                }
                else if (lblPaginaFase.Text.Equals("Fase"))
                {
                    optFase.Checked = true;
                }
                else if (lblPaginaFase.Text.Equals("Lição"))
                {
                    optLicao.Checked = true;
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
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            txtDescricao.Focus();
        }

        /// <summary>
        /// Função que carrega as Familia
        /// </summary>
        /// <param name="CodInstr"></param>
        private void carregaFamilia(string CodInstr)
        {
            try
            {
                List<MOD_metodoFamilia> listaNova = new List<MOD_metodoFamilia>();

                objBLL = new BLL_metodos();
                listaMetFamilia = objBLL.buscarMetodoFamilia(CodInstr);

                objBLL = new BLL_metodos();
                listaFamilia = objBLL.buscarFamilia(CodInstr);

                foreach (MOD_familia objEnt_Fam in listaFamilia)
                {
                    MOD_metodoFamilia ent = new MOD_metodoFamilia();

                    ent.CodMetodoFamilia = "0";
                    ent.CodFamilia = objEnt_Fam.CodFamilia;
                    ent.DescFamilia = objEnt_Fam.DescFamilia;
                    ent.CodMetodo = "0";
                    ent.Marcado = false;

                    listaNova.Add(ent);
                }

                listaMetFamilia.AddRange(listaNova);
                funcoes.gridFamilia(gridMetodoFamilia, "Metodo");
                ///vincula a lista ao DataSource do DataGriView
                gridMetodoFamilia.DataSource = listaMetFamilia;
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

    }
}