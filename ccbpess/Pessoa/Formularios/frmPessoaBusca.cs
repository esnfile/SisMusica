using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.pessoa;
using BLL.Usuario;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ccbpess.pesquisa;
using ccbrepess;
using ENT.acessos;
using ENT.pessoa;
using ENT.relatorio;
using ENT.uteis;

namespace ccbpess
{
    public partial class frmPessoaBusca : Form
    {
        public frmPessoaBusca()
        {
            InitializeComponent();
        }

        #region declarações

        //variaveis
        string Codigo;
        string Descricao;
        string NomeRelatorio;

        IBLL_Pessoa objBLL = new BLL_pessoa();
        IBLL_buscaPessoa objBLL_Busca = null;
        MOD_pessoa objEnt = null;
        List<MOD_pessoa> lista;

        BLL_regiaoAtuacao objBLL_Regiao = null;
        List<MOD_regiaoAtuacao> listaRegiao = null;

        BLL_ccb objBLL_CCB = null;
        List<MOD_ccb> listaCCB = null;

        Form formulario;
        Form formChama;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        #region Aba Codigo

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnCod;
        }
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnCodIns;
        }
        private void btnCod_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        CarregaGrid(BuscaPessoaPorCodigo(txtCodigo.Text), gridCodigo);
                    }
                }
                else
                {
                    CarregaGrid(BuscaPessoaPorCodigo(txtCodigo.Text), gridCodigo);
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
        private void btnCodIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridCodigo);
                ((frmPessoa)formulario).Text = "Inserindo Pessoa";
                ((frmPessoa)formulario).enabledForm();
                ((frmPessoa)formulario).defineFoco();
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
        private void btnCodVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCodigo["CodPessoa", gridCodigo.CurrentRow.Index].Value.ToString();

                abrirForm(string.Empty, gridCodigo);
                ((frmPessoa)formulario).Text = "Visualizando Pessoa";
                ((frmPessoa)formulario).disabledForm();
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
        private void btnCodEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCodigo["CodPessoa", gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmPessoa)formulario).Text = "Editando Pessoa";
                ((frmPessoa)formulario).enabledForm();
                ((frmPessoa)formulario).defineFoco();
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
        private void btnCodExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridCodigo["CodPessoa", gridCodigo.CurrentRow.Index].Value.ToString();
                    //chama a função que exclui o registro na tabela
                    objBLL.Delete(criarTabela());

                    gridCodigo.DataSource = null;
                    funcoes.gridPessoa(gridCodigo);
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
            else
            {
                txtCodigo.Focus();
            }
        }
        private void gridCodigo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnCodEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridCodigo["CodPessoa", gridCodigo.CurrentRow.Index].Value.ToString();
                        abrirForm(string.Empty, gridCodigo);
                        ((frmPessoa)formulario).Text = "Editando Pessoa";
                        ((frmPessoa)formulario).enabledForm();
                        ((frmPessoa)formulario).defineFoco();
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
        private void gridCodigo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridCodigo["CodPessoa", gridCodigo.CurrentRow.Index].Value.ToString();
                Descricao = gridCodigo["Nome", gridCodigo.CurrentRow.Index].Value.ToString();
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
        private void gridCodigo_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void btnCodImp_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando registro...");
                Codigo = gridCodigo["CodPessoa", gridCodigo.CurrentRow.Index].Value.ToString();
                    NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa.rdlc";
                    abrirForm("frmFicha", gridCodigo);
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
        private void gridCodigo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermCodigo(gridCodigo);
                txtQtde.Text = Convert.ToString(gridCodigo.RowCount).PadLeft(6, '0');
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

        #region Aba Nome

        private void txtNome_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnNome;
        }
        private void txtNome_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnNomeIns;
        }
        private void btnNome_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (string.IsNullOrEmpty(txtNome.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        objBLL_Busca = new BLL_buscaPessoaPorNome();
                        lista = objBLL_Busca.Buscar(txtNome.Text);
                        CarregaGrid(lista, gridNome);
                    }
                }
                else
                {
                    objBLL_Busca = new BLL_buscaPessoaPorNome();
                    lista = objBLL_Busca.Buscar(txtNome.Text);
                    CarregaGrid(lista, gridNome);
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
        private void btnNomeVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridNome["CodPessoa", gridNome.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridNome);
                    ((frmPessoa)formulario).Text = "Visualizando Pessoa";
                    ((frmPessoa)formulario).disabledForm();
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
        private void btnNomeIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridNome);
                ((frmPessoa)formulario).Text = "Inserindo Pessoa";
                ((frmPessoa)formulario).enabledForm();
                ((frmPessoa)formulario).defineFoco();
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
        private void btnNomeEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridNome["CodPessoa", gridNome.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridNome);
                    ((frmPessoa)formulario).Text = "Editando Pessoa";
                    ((frmPessoa)formulario).enabledForm();
                    ((frmPessoa)formulario).defineFoco();
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
        private void btnNomeExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridNome["CodPessoa", gridNome.CurrentRow.Index].Value.ToString();
                        objBLL.Delete(criarTabela());

                        gridNome.DataSource = null;
                        funcoes.gridPessoa(gridNome);
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
            else
            {
                txtNome.Focus();
            }
        }
        private void gridNome_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnNomeEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridNome["CodPessoa", gridNome.CurrentRow.Index].Value.ToString();
                        abrirForm(string.Empty, gridNome);
                        ((frmPessoa)formulario).Text = "Editando Pessoa";
                        ((frmPessoa)formulario).enabledForm();
                        ((frmPessoa)formulario).defineFoco();
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
        private void gridNome_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridNome["CodPessoa", gridNome.CurrentRow.Index].Value.ToString();
                Descricao = gridNome["Nome", gridNome.CurrentRow.Index].Value.ToString();
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
        private void gridNome_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void btnNomeImp_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando registro...");
                Codigo = gridNome["CodPessoa", gridNome.CurrentRow.Index].Value.ToString();
                NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa.rdlc";
                abrirForm("frmFicha", gridNome);
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
        private void gridNome_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermNome(gridNome);
                txtQtde.Text = Convert.ToString(gridNome.RowCount).PadLeft(6, '0');
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

        #region Aba Cpf

        private void txtCpf_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnCpf;
        }
        private void txtCpf_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnCpfIns;
        }
        private void btnCpf_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (string.IsNullOrEmpty(this.txtCpf.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        objBLL_Busca = new BLL_buscaPessoaPorCpf();
                        lista = objBLL_Busca.Buscar(txtCpf.Text);
                        CarregaGrid(lista, gridCpf);
                    }
                }
                else
                {
                    objBLL_Busca = new BLL_buscaPessoaPorCpf();
                    lista = objBLL_Busca.Buscar(txtCpf.Text);
                    CarregaGrid(lista, gridCpf);
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
        private void btnCpfVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCpf["CodPessoa", gridCpf.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCpf);
                    ((frmPessoa)formulario).Text = "Visualizando Pessoa";
                    ((frmPessoa)formulario).disabledForm();
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
        private void btnCpfIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridCpf);
                ((frmPessoa)formulario).Text = "Inserindo Pessoa";
                ((frmPessoa)formulario).enabledForm();
                ((frmPessoa)formulario).defineFoco();
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
        private void btnCpfEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCpf["CodPessoa", gridCpf.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCpf);
                    ((frmPessoa)formulario).Text = "Editando Pessoa";
                    ((frmPessoa)formulario).enabledForm();
                    ((frmPessoa)formulario).defineFoco();
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
        private void btnCpfExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridCpf["CodPessoa", gridCpf.CurrentRow.Index].Value.ToString();
                        //chama a função que exclui o registro na tabela
                        objBLL.Delete(criarTabela());

                        gridCpf.DataSource = null;
                        funcoes.gridPessoa(gridCpf);
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
            else
            {
                txtCpf.Focus();
            }
        }
        private void gridCpf_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnCpfEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridCpf["CodPessoa", gridCpf.CurrentRow.Index].Value.ToString();
                        abrirForm(string.Empty, gridCpf);
                        ((frmPessoa)formulario).Text = "Editando Pessoa";
                        ((frmPessoa)formulario).enabledForm();
                        ((frmPessoa)formulario).defineFoco();
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
        private void gridCpf_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridCpf["CodPessoa", gridCpf.CurrentRow.Index].Value.ToString();
                Descricao = gridCpf["Nome", gridCpf.CurrentRow.Index].Value.ToString();
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
        private void gridCpf_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void btnCpfImp_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando registro...");
                Codigo = gridCpf["CodPessoa", gridCpf.CurrentRow.Index].Value.ToString();
                    NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa.rdlc";
                    abrirForm("frmFicha", gridCpf);
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
        private void gridCpf_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermCpf(gridCpf);
                txtQtde.Text = Convert.ToString(gridCpf.RowCount).PadLeft(6, '0');
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

        #region Aba Região

        private void lblCodRegiao_TextChanged(object sender, EventArgs e)
        {
            if (!lblCodRegiao.Text.Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    objBLL_Busca = new BLL_buscaPessoaPorRegiao();
                    lista = objBLL_Busca.Buscar(lblCodRegiao.Text);
                    CarregaGrid(lista, gridRegiao);
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
        private void btnRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmReg", gridRegiao);
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
        private void btnRegVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridRegiao["CodPessoa", gridRegiao.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridRegiao);
                    ((frmPessoa)formulario).Text = "Visualizando Pessoa";
                    ((frmPessoa)formulario).disabledForm();
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
        private void btnRegIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridRegiao);
                ((frmPessoa)formulario).Text = "Inserindo Pessoa";
                ((frmPessoa)formulario).enabledForm();
                ((frmPessoa)formulario).defineFoco();
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
        private void btnRegEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridRegiao["CodPessoa", gridRegiao.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridRegiao);
                    ((frmPessoa)formulario).Text = "Editando Pessoa";
                    ((frmPessoa)formulario).enabledForm();
                    ((frmPessoa)formulario).defineFoco();
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
        private void btnRegExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridRegiao["CodPessoa", gridRegiao.CurrentRow.Index].Value.ToString();
                        //chama a função que exclui o registro na tabela
                        objBLL.Delete(criarTabela());

                        gridRegiao.DataSource = null;
                        funcoes.gridPessoa(gridRegiao);
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
        private void gridRegiao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnRegEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridRegiao["CodPessoa", gridRegiao.CurrentRow.Index].Value.ToString();
                        abrirForm(string.Empty, gridRegiao);
                        ((frmPessoa)formulario).Text = "Editando Pessoa";
                        ((frmPessoa)formulario).enabledForm();
                        ((frmPessoa)formulario).defineFoco();
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
        private void gridRegiao_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridRegiao["CodPessoa", gridRegiao.CurrentRow.Index].Value.ToString();
                Descricao = gridRegiao["Nome", gridRegiao.CurrentRow.Index].Value.ToString();
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
        private void gridRegiao_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void btnRegImp_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando registro...");
                Codigo = gridRegiao["CodPessoa", gridRegiao.CurrentRow.Index].Value.ToString();
                    NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa.rdlc";
                    abrirForm("frmFicha", gridRegiao);
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
        private void gridRegiao_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermRegiao(gridRegiao);
                txtQtde.Text = Convert.ToString(gridRegiao.RowCount).PadLeft(6, '0');
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

        #region Aba Comum

        private void lblCodComum_TextChanged(object sender, EventArgs e)
        {
            if (!lblCodComum.Text.Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    objBLL_Busca = new BLL_buscaPessoaPorComum();
                    lista = objBLL_Busca.Buscar(lblCodComum.Text);
                    CarregaGrid(lista, gridComum);
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
        private void btnComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmCom", gridComum);
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
        private void btnComVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridComum["CodPessoa", gridComum.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridComum);
                    ((frmPessoa)formulario).Text = "Visualizando Pessoa";
                    ((frmPessoa)formulario).disabledForm();
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
        private void btnComIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridComum);
                ((frmPessoa)formulario).Text = "Inserindo Pessoa";
                ((frmPessoa)formulario).enabledForm();
                ((frmPessoa)formulario).defineFoco();
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
        private void btnComEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridComum["CodPessoa", gridComum.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridComum);
                    ((frmPessoa)formulario).Text = "Editando Pessoa";
                    ((frmPessoa)formulario).enabledForm();
                    ((frmPessoa)formulario).defineFoco();
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
        private void btnComExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    Codigo = gridComum["CodPessoa", gridComum.CurrentRow.Index].Value.ToString();
                        //chama a função que exclui o registro na tabela
                        objBLL.Delete(criarTabela());

                        gridComum.DataSource = null;
                        funcoes.gridPessoa(gridComum);
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
        private void gridComum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnComEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridComum["CodPessoa", gridComum.CurrentRow.Index].Value.ToString();
                        abrirForm(string.Empty, gridComum);
                        ((frmPessoa)formulario).Text = "Editando Pessoa";
                        ((frmPessoa)formulario).enabledForm();
                        ((frmPessoa)formulario).defineFoco();
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
        private void gridComum_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridComum["CodPessoa", gridComum.CurrentRow.Index].Value.ToString();
                Descricao = gridComum["Nome", gridComum.CurrentRow.Index].Value.ToString();
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
        private void gridComum_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void btnComImp_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando registro...");
                Codigo = gridComum["CodPessoa", gridComum.CurrentRow.Index].Value.ToString();
                    NomeRelatorio = "ccbrepess.relatorios.rptFichaCadastralPessoa.rdlc";
                    abrirForm("frmFicha", gridComum);
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
        private void gridComum_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermComum(gridComum);
                txtQtde.Text = Convert.ToString(gridComum.RowCount).PadLeft(6, '0');
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

        #region Eventos do Formulario

        private void tabPessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPessoa.SelectedTab.Name.Equals("tabCodigo"))
                {
                    funcoes.gridPessoa(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                    verPermCodigo(gridCodigo);
                    txtQtde.Text = "000000";
                }
                else if (tabPessoa.SelectedTab.Name.Equals("tabNome"))
                {
                    funcoes.gridPessoa(gridNome);
                    txtNome.Text = string.Empty;
                    txtNome.Focus();
                    verPermNome(gridNome);
                    txtQtde.Text = "000000";
                }
                else if (tabPessoa.SelectedTab.Name.Equals("tabCpf"))
                {
                    funcoes.gridPessoa(gridCpf);
                    txtCpf.Text = string.Empty;
                    txtCpf.Focus();
                    verPermCpf(gridCpf);
                    txtQtde.Text = "000000";
                }
                else if (tabPessoa.SelectedTab.Name.Equals("tabComum"))
                {
                    funcoes.gridPessoa(gridComum);
                    lblCodComum.Text = string.Empty;
                    lblDescricaoComum.Text = string.Empty;
                    AcceptButton = btnRegiao;
                    verPermComum(gridComum);
                    txtQtde.Text = "000000";
                }
                else if (tabPessoa.SelectedTab.Name.Equals("tabRegiao"))
                {
                    funcoes.gridPessoa(gridRegiao);
                    lblCodRegiao.Text = string.Empty;
                    lblDescricaoRegiao.Text = string.Empty;
                    AcceptButton = btnRegiao;
                    verPermRegiao(gridRegiao);
                    txtQtde.Text = "000000";
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
        private void frmPessoaBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridPessoa(gridNome);

                //verificar permissão de acesso
                verPermNome(gridNome);
                txtQtde.Text = "000000";

                //definir as imagens
                pctInativa.Image = imgPessoa.Images[0];
                pctAtiva.Image = imgPessoa.Images[1];
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
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="DataGrid"></param>
        internal void CarregaGrid(List<MOD_pessoa> listaPessoa, DataGridView dataGrid)
        {
            try
            {
                dataGrid.DataSource = listaPessoa;
                definirImagens(dataGrid);
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
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(string form, DataGridView dataGrid)
        {
            try
            {
                if (form.Equals("frmReg"))
                {
                    lblDescricaoRegiao.Text = string.Empty;
                    lblCodRegiao.Text = string.Empty;

                    formulario = new frmPesquisaRegiao(this);
                    ((frmPesquisaRegiao)formulario).MdiParent = MdiParent;
                    ((frmPesquisaRegiao)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaRegiao)formulario));
                    ((frmPesquisaRegiao)formulario).Show();
                    ((frmPesquisaRegiao)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmCom"))
                {
                    lblDescricaoComum.Text = string.Empty;
                    lblCodComum.Text = string.Empty;

                    formulario = new frmPesquisaComum(this, string.Empty);
                    ((frmPesquisaComum)formulario).MdiParent = MdiParent;
                    ((frmPesquisaComum)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaComum)formulario));
                    ((frmPesquisaComum)formulario).Show();
                    ((frmPesquisaComum)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmFicha"))
                {
                    preencher(Codigo);

                    MOD_paramRelatorio Parametro = new MOD_paramRelatorio();
                    Parametro.NomeRelatorio = NomeRelatorio;
                    Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                    Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                    Parametro.RodapeRelatorio = modulos.listaParametros[0].RodapeRelatorio;
                    formulario = new frmListaPessoa(this, lista, Parametro);
                    ((frmListaPessoa)formulario).ShowDialog();
                }
                else
                {
                    preencher(Codigo);

                    formulario = new frmPessoa(this, dataGrid, lista);
                    ((frmPessoa)formulario).MdiParent = MdiParent;
                    ((frmPessoa)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm((frmPessoa)formulario);
                    ((frmPessoa)formulario).Show();
                    ((frmPessoa)formulario).BringToFront();
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="CodPessoa"></param>
        internal void preencher(string CodPessoa)
        {
            try
            {
                //chama a classe de negócios
                IBLL_buscaPessoa objBLL = new BLL_buscaPessoaPorCodPessoa();
                lista = objBLL.Buscar(CodPessoa);

                //Verifica se o usuario a ser editado não é o usuario Administrador
                BLL_Liberacoes.LiberaEdicaoAdm(Convert.ToInt64(Codigo), new BLL_usuario().buscarPessoa(CodPessoa));
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
        /// Função que define a imagem do status da conta, se ativo ou inativo
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (Convert.ToString(linha.Cells["Ativo"].Value).Contains("Não"))
                    {
                        linha.Cells[0].Value = imgPessoa.Images[0];
                    }
                    else if (Convert.ToString(linha.Cells["Ativo"].Value).Contains("Sim"))
                    {
                        linha.Cells[0].Value = imgPessoa.Images[1];
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_pessoa criarTabela()
        {
            try
            {

                //Verifica se o usuario a ser editado não é o usuario 1
                funcoes.liberaEdicaoAdm(Convert.ToInt32(Codigo));

                //preenche o objeto da tabela Logs
                objEnt = new MOD_pessoa();
                objEnt.CodPessoa = Codigo;
                objEnt.Nome = Descricao;

                //retorna o objeto preenchido
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
        /// Função que carrega a Região pesquisado pelo Código
        /// </summary>
        /// <param name="vCodRegiao"></param>
        internal void carregaRegiao(string vCodRegiao)
        {
            try
            {
                objBLL_Regiao = new BLL_regiaoAtuacao();
                listaRegiao = objBLL_Regiao.buscarCod(vCodRegiao);

                if (listaRegiao != null && listaRegiao.Count > 0)
                {
                    lblCodRegiao.Text = listaRegiao[0].CodRegiao;
                    lblDescricaoRegiao.Text = "Microrregião: " + listaRegiao[0].Codigo + " - " + listaRegiao[0].DescRegiao + " - Regional: " + listaRegiao[0].DescricaoRegional;
                }
                else
                {
                    abrirForm("frmReg", gridRegiao);
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
        /// Função que carrega a Comum pesquisado pelo Código
        /// </summary>
        /// <param name="vCodCCB"></param>
        internal void carregaComum(string vCodCCB)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarCod(vCodCCB);

                if (listaCCB != null && listaCCB.Count > 0)
                {
                    lblCodComum.Text = listaCCB[0].CodCCB;
                    lblDescricaoComum.Text = "Comum Congregação: " + listaCCB[0].Codigo + " - " + listaCCB[0].Descricao + " - " + listaCCB[0].DescricaoRegiao + " - Regional: " + listaCCB[0].DescricaoRegional;
                }
                else
                {
                    abrirForm("frmCom", gridComum);
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
        public void defineFoco()
        {
            this.txtNome.Focus();
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermCodigo(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPessoa MOD_acessoPessoa = new MOD_acessoPessoa();

                //verificando o botão inserir
                btnCodIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotInsPessoa);
                btnCodEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotEditPessoa, dataGrid);
                btnCodExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotExcPessoa, dataGrid);
                btnCodVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotVisPessoa, dataGrid);
                btnCodImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesImpFicha, dataGrid);
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
        /// <param name="dataGrid"></param>
        internal void verPermNome(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPessoa MOD_acessoPessoa = new MOD_acessoPessoa();

                //verificando o botão inserir
                btnNomeIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotInsPessoa);
                btnNomeEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotEditPessoa, dataGrid);
                btnNomeExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotExcPessoa, dataGrid);
                btnNomeVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotVisPessoa, dataGrid);
                btnNomeImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesImpFicha, dataGrid);
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
        /// <param name="dataGrid"></param>
        internal void verPermCpf(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPessoa MOD_acessoPessoa = new MOD_acessoPessoa();

                //verificando o botão inserir
                btnCpfIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotInsPessoa);
                btnCpfEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotEditPessoa, dataGrid);
                btnCpfExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotExcPessoa, dataGrid);
                btnCpfVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotVisPessoa, dataGrid);
                btnCpfImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesImpFicha, dataGrid);
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
        /// <param name="dataGrid"></param>
        internal void verPermComum(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPessoa MOD_acessoPessoa = new MOD_acessoPessoa();

                //verificando o botão inserir
                btnComIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotInsPessoa);
                btnComEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotEditPessoa, dataGrid);
                btnComExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotExcPessoa, dataGrid);
                btnComVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotVisPessoa, dataGrid);
                btnComImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesImpFicha, dataGrid);
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
        /// <param name="dataGrid"></param>
        internal void verPermRegiao(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPessoa MOD_acessoPessoa = new MOD_acessoPessoa();

                //verificando o botão inserir
                btnRegIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotInsPessoa);
                btnRegEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotEditPessoa, dataGrid);
                btnRegExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotExcPessoa, dataGrid);
                btnRegVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotVisPessoa, dataGrid);
                btnRegImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoPessoa.RotPesImpFicha, dataGrid);
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