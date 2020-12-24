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
using ENT.administracao;
using BLL.administracao;
using ENT.pessoa;

namespace ccbadm
{
    public partial class frmTipoReuniao : Form
    {
        public frmTipoReuniao(Form forms, DataGridView gridPesquisa, List<MOD_tipoReuniao> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaTipo = lista;

                //Função que carrega os cargos
                carregaCargos(string.Empty);

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

        BLL_tipoReuniao objBLL = null;
        MOD_tipoReuniao objEnt = null;
        List<MOD_tipoReuniao> listaTipo = null;

        List<MOD_tipoReuniaoCargo> listaTipoCargo = null;
        List<MOD_cargo> listaCargo = null;

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
        private void frmTipoReuniao_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                verPermAlteraCargo();
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
        private void frmTipoReuniao_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Tipo de Reunião"))
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
        private void frmTipoReuniao_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }

        private void gridCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridCargo != null || gridCargo.RowCount > 0)
                {
                    if (listaTipoCargo[e.RowIndex].Marcado.Equals(true))
                    {
                        listaTipoCargo[e.RowIndex].Marcado = false;
                    }
                    else
                    {
                        listaTipoCargo[e.RowIndex].Marcado = true;
                    }
                    gridCargo.Refresh();
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
        private void btnSelCargo_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_tipoReuniaoCargo entCargo in listaTipoCargo)
                {
                    entCargo.Marcado = true;
                }
                gridCargo.Refresh();
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
        private void btnDesCargo_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_tipoReuniaoCargo entCargo in listaTipoCargo)
                {
                    entCargo.Marcado = false;
                }
                gridCargo.Refresh();
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
                    objBLL = new BLL_tipoReuniao();

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
                    if (formChama.Name.Equals("frmTipoReuniaoBusca"))
                    {
                        ((frmTipoReuniaoBusca)formChama).carregaGrid("TipoReuniao", objEnt.CodTipoReuniao, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmTipoReuniao_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmTipoReuniao_FormClosing);

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
                bool blnCargo = false;

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

                foreach (DataGridViewRow row in gridCargo.Rows)
                {
                    if (row.Cells["Marcado"].Value != null)
                    {
                        if (row.Cells["Marcado"].Value.Equals(true))
                        {
                            blnCargo = true;
                            break;
                        }
                    }
                }

                if (blnCargo.Equals(false))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Ministério.";
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
        private MOD_tipoReuniao criarTabela()
        {
            try
            {
                objEnt = new MOD_tipoReuniao();
                objEnt.CodTipoReuniao = txtCodigo.Text;
                objEnt.DescTipoReuniao = txtDescricao.Text;

                //retorna o objeto TipoReuniaoCargo
                if (listaTipoCargo != null)
                {
                    objEnt.listaCargoReuniao = new List<MOD_tipoReuniaoCargo>();
                    objEnt.listaCargoReuniao = listaTipoCargo;
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
        /// <param name="listaTipo"></param>
        internal void preencher(List<MOD_tipoReuniao> listaTipo)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaTipo[0].CodTipoReuniao;
                txtDescricao.Text = listaTipo[0].DescTipoReuniao;

                //Carrega os Cargos
                carregaCargos(listaTipo[0].CodTipoReuniao);
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
                pnlTipo.Enabled = false;
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
                pnlTipo.Enabled = true;
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

        #region Aba Cargos

        /// <summary>
        /// Função que carrega os Cargos
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        private void carregaCargos(string CodTipoReuniao)
        {
            try
            {
                List<MOD_tipoReuniaoCargo> listaNova = new List<MOD_tipoReuniaoCargo>();

                objBLL = new BLL_tipoReuniao();
                listaTipoCargo = objBLL.buscarTipoReuniaoCargo(CodTipoReuniao);

                objBLL = new BLL_tipoReuniao();
                listaCargo = objBLL.buscarCargos(CodTipoReuniao);

                foreach (MOD_cargo objEnt_Cargo in listaCargo)
                {
                    MOD_tipoReuniaoCargo ent = new MOD_tipoReuniaoCargo();

                    ent.CodCargoReuniao = "0";
                    ent.CodCargo = objEnt_Cargo.CodCargo;
                    ent.DescCargo = objEnt_Cargo.DescCargo;
                    ent.SiglaCargo = objEnt_Cargo.SiglaCargo;
                    ent.Ordem = objEnt_Cargo.Ordem;
                    ent.Marcado = false;

                    listaNova.Add(ent);
                }

                listaTipoCargo.AddRange(listaNova);
                //chama a funcão montar grid
                new BLL_GridCargo().MontarGrid(gridCargo, "Relatorios");
                ///vincula a lista ao DataSource do DataGriView
                gridCargo.DataSource = listaTipoCargo;
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
        internal void verPermAlteraCargo()
        {
            try
            {
                gpoCargo.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoTipoReuniao.RotipoReuniaoCargo);
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
