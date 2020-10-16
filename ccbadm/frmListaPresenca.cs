using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.Funcoes;
using BLL.administracao;
using BLL.pessoa;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using ENT.administracao;
using ENT.pessoa;
using ccbadm.pesquisa;

namespace ccbadm
{
    public partial class frmListaPresenca : Form
    {
        public frmListaPresenca(List<MOD_acessos> listaLibAcesso, Form forms, List<MOD_reuniaoMinisterio> listaReuniao)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;

                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;

                txtCodReuniao.Text = listaReuniao[0].CodReuniao;
                txtDataReuniao.Text = listaReuniao[0].DataReuniao;
                txtHoraReuniao.Text = listaReuniao[0].HoraReuniao;
                txtTipo.Text = listaReuniao[0].DescTipoReuniao;
                txtLocal.Text = listaReuniao[0].DescricaoCCB;

                carregaListaPresenca(listaReuniao[0].CodReuniao);
                disabledForm();
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

        string CodListaPresenca;
        string CodPessoa;
        string Nome;
        string CodReuniao;

        int IndiceLista;

        clsException excp;
        List<MOD_acessos> listaAcesso = null;

        BLL_listaPresenca objBLL_Presenca = null;
        MOD_listaPresenca objEnt_Presenca = null;
        List<MOD_listaPresenca> listaPresenca = new List<MOD_listaPresenca>();

        BLL_pessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa = null;

        Form formulario;
        Form formChama;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        #endregion

        #region eventos do formulario

        private void frmListaPresenca_Load(object sender, EventArgs e)
        {
            try
            {
                verPermLista(gridLista);
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
        private void frmListaPresenca_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult sair;
                sair = MessageBox.Show("Deseja sair?" + '\n' + "Os registros não salvos serão perdidos!", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sair.Equals(DialogResult.No))
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
        private void frmListaPresenca_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void btnFechar_Click(object sender, EventArgs e)
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

        private void txtPessoa_Leave(object sender, EventArgs e)
        {
            if (!txtPessoa.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde("Buscando pessoas...");
                    carregaPessoa(txtPessoa.Text, string.Empty);
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
                    defineFocoIncluir();
                }
            }
            else
            {
                limparListaPresenca();
            }
        }
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", string.Empty);
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
        private void txtPessoa_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnPessoa;
        }
        private void lblPessoa_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblPessoa.Text.Trim()))
            {
                btnEditar.Enabled = true;
            }
            else
            {
                btnEditar.Enabled = false;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
                salvarListaPresenca();
                btnIns.PerformClick();
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
        private void btnRetornar_Click(object sender, EventArgs e)
        {
            try
            {
                limparListaPresenca();
                disabledForm();
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
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblPessoa.Text))
                {
                    throw new Exception("Necessário informar o Irmão(ã) para alterar os dados.");
                }
                else
                {
                    apoio.Aguarde("Carregando informações...");
                    abrirForm("frmPessoa", string.Empty);
                    ((frmPessoa)formulario).Text = "Editando Pessoa";
                    ((frmPessoa)formulario).enabledForm();
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

        private void gridLista_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermLista(gridLista);
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
        private void gridLista_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                IndiceLista = gridLista.CurrentRow.Index;

                if (IndiceLista > (-1))
                {
                    CodListaPresenca = gridLista["CodListaPresenca", IndiceLista].Value.ToString();
                    CodReuniao = gridLista["CodReuniao", IndiceLista].Value.ToString();
                    CodPessoa = gridLista["CodPessoa", IndiceLista].Value.ToString();
                    Nome = gridLista["Nome", IndiceLista].Value.ToString();

                    preenchePessoa(IndiceLista);
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

        private void btnIns_Click(object sender, EventArgs e)
        {
            try
            {
                limparListaPresenca();
                enabledForm();
                gpoPessoa.Enabled = true;
                txtPessoa.Focus();
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
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    IndiceLista = gridLista.CurrentRow.Index;
                    CodListaPresenca = gridLista["CodListaPresenca", IndiceLista].Value.ToString();
                    CodReuniao = gridLista["CodReuniao", IndiceLista].Value.ToString();
                    CodPessoa = gridLista["CodPessoa", IndiceLista].Value.ToString();
                    Nome = gridLista["Nome", IndiceLista].Value.ToString();

                    deleteListaPresenca(IndiceLista);
                    carregaListaPresenca(txtCodReuniao.Text);
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
                    apoio.FecharAguardeExcluir();
                }
            }
        }

        private void btnPrevia_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando dados...");
                abrirForm("frmPrevia", string.Empty);
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
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                gpoPessoa.Enabled = false;
                gridLista.Enabled = true;
                verPermLista(gridLista);
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
                btnIns.Enabled = false;
                btnExcluir.Enabled = false;
                gridLista.Enabled = false;
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
                if (form.Equals("frmPes"))
                {
                    limparListaPresenca();

                    formulario = new frmPesquisaPessoa(this, Campo);
                    ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                    ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                    ((frmPesquisaPessoa)formulario).Show();
                    ((frmPesquisaPessoa)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmPessoa"))
                {
                    formulario = new frmPessoa(this, gridLista, listaPessoa);
                    ((frmPessoa)formulario).MdiParent = MdiParent;
                    ((frmPessoa)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm((frmPessoa)formulario);
                    ((frmPessoa)formulario).Show();
                    ((frmPessoa)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmPrevia"))
                {
                    carregaListaPresenca(txtCodReuniao.Text);
                    formulario = new frmPreviaLista(this, gridLista, listaPresenca);
                    ((frmPreviaLista)formulario).MdiParent = MdiParent;
                    ((frmPreviaLista)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm((frmPreviaLista)formulario);
                    ((frmPreviaLista)formulario).Show();
                    ((frmPreviaLista)formulario).BringToFront();
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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa">Código da Pessoa</param>
        /// <param name="Campo">Campo a ser pesquisado</param>
        internal void carregaPessoa(string vCodPessoa, string Campo)
        {
            try
            {
                objBLL_Pessoa = new BLL_pessoa();
                listaPessoa = objBLL_Pessoa.buscarCod(vCodPessoa, modulos.CodUsuarioCCB, true);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    txtPessoa.Text = listaPessoa[0].CodPessoa;
                    lblPessoa.Text = listaPessoa[0].Nome;
                    txtDataNasc.Text = listaPessoa[0].DataNasc;
                    txtCpf.Text = listaPessoa[0].Cpf;
                    txtComum.Text = listaPessoa[0].CodigoCCB + " - " + listaPessoa[0].Descricao;
                    txtCidade.Text = listaPessoa[0].CidadeRes;
                    txtCargo.Text = listaPessoa[0].DescCargo;
                    txtTelefone.Text = listaPessoa[0].Telefone1 + " - " + listaPessoa[0].Celular1;
                }
                else
                {
                    abrirForm("frmPes", Campo);
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
        /// Função que carrega a Pessoa e envia para o formulario de edição
        /// </summary>
        /// <param name="vCodPessoa">Código da Pessoa</param>
        internal void editarPessoa(string vCodPessoa)
        {
            try
            {
                objBLL_Pessoa = new BLL_pessoa();
                listaPessoa = objBLL_Pessoa.buscarCod(vCodPessoa);
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
        /// Função que valida os campos Lista Presenca
        /// </summary>
        private bool ValidarControlesListaPresenca()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();
                if (lblPessoa.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Irmão(ã)! Campo obrigatório.";
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
        private MOD_listaPresenca criarTabelaListaPresenca()
        {
            try
            {
                objEnt_Presenca = new MOD_listaPresenca();
                objEnt_Presenca.CodListaPresenca = lblCodListaPresenca.Text;
                objEnt_Presenca.CodPessoa = txtPessoa.Text;
                objEnt_Presenca.Nome = lblPessoa.Text;
                objEnt_Presenca.CodReuniao = txtCodReuniao.Text;

                //retorna a classe de propriedades preenchida com os textbox
                return objEnt_Presenca;
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
        private void carregaListaPresenca(string CodReuniao)
        {
            try
            {

                objBLL_Presenca = new BLL_listaPresenca();
                listaPresenca = objBLL_Presenca.buscarListaPresenca(CodReuniao);

                funcoes.gridListaPresenca(gridLista);
                ///vincula a lista ao DataSource do DataGriView
                gridLista.DataSource = listaPresenca;
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
        /// Função que insere uma nova linha no DataGridView
        /// </summary>
        private void salvarListaPresenca()
        {
            try
            {
                if (ValidarControlesListaPresenca().Equals(true))
                {
                    objBLL_Presenca = new BLL_listaPresenca();
                    //chama a rotina da camada de negocios para efetuar inserção ou update
                    objBLL_Presenca.inserir(criarTabelaListaPresenca());

                    //Carrega as lições
                    carregaListaPresenca(txtCodReuniao.Text);
                    //Limpa os controle e desabilita
                    //limparListaPresenca();
                    disabledForm();
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
        /// Função que limpa os controle para Inserir novo irmão
        /// </summary>
        private void limparListaPresenca()
        {
            try
            {
                txtPessoa.Text = string.Empty;
                lblPessoa.Text = string.Empty;
                txtDataNasc.Text = string.Empty;
                txtCpf.Text = string.Empty;
                txtComum.Text = string.Empty;
                txtCidade.Text = string.Empty;
                txtCargo.Text = string.Empty;
                txtTelefone.Text = string.Empty;
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
        /// Função que Deleta a linha selecionada no gridLista
        /// </summary>
        private void deleteListaPresenca(int Indice)
        {
            try
            {
                MOD_listaPresenca ent = new MOD_listaPresenca();
                ent.CodListaPresenca = CodListaPresenca;
                ent.CodPessoa = CodPessoa;
                ent.Nome = Nome;
                ent.CodReuniao = CodReuniao;

                objBLL_Presenca = new BLL_listaPresenca();
                objBLL_Presenca.excluir(ent);
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
        /// Função que preenche os dados do Grid para os TextBoxes
        /// </summary>
        /// <param name="Indice"></param>
        private void preenchePessoa(int Indice)
        {
            try
            {
                //gpoPessoa.Enabled = true;

                foreach (MOD_listaPresenca linha in listaPresenca)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (linha.CodListaPresenca.Equals(CodListaPresenca))
                    {
                        txtPessoa.Text = linha.listaPessoa[0].CodPessoa;
                        lblPessoa.Text = linha.listaPessoa[0].Nome;
                        txtDataNasc.Text = linha.listaPessoa[0].DataNasc;
                        txtCpf.Text = linha.listaPessoa[0].Cpf;
                        txtComum.Text = linha.listaPessoa[0].CodigoCCB + " - " + linha.listaPessoa[0].Descricao;
                        txtCidade.Text = linha.listaPessoa[0].CidadeRes;
                        txtCargo.Text = linha.listaPessoa[0].DescCargo;
                        txtTelefone.Text = linha.listaPessoa[0].Telefone1 + " - " + linha.listaPessoa[0].Celular1;

                        break;
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
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            btnIns.Focus();
            AcceptButton = btnIns;
        }
        /// <summary>
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFocoIncluir()
        {
            btnIncluir.Focus();
            AcceptButton = btnIncluir;
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermLista(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoListaPresenca entAcesso = new MOD_acessoListaPresenca();
                btnIns.Enabled = funcoes.liberacoes(entAcesso.rotInsPresenca);
                btnExcluir.Enabled = funcoes.liberacoes(entAcesso.rotExcPresenca, dataGrid);
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