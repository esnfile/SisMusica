using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.pessoa;
using BLL.preTeste;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using ENT.pessoa;
using ENT.preTeste;

namespace ccbtest
{
    public partial class frmPreTesteBusca : Form
    {
        public frmPreTesteBusca(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();
            try
            {
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;
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

        #region declarações

        //variaveis
        string Codigo;
        string Descricao;

        BLL_preTeste objBLL = null;
        MOD_preTeste objEnt = null;
        List<MOD_preTeste> lista;

        Form formulario;

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
        private void btnCodigo_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtCodigo.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        apoio.Aguarde();
                        carregaGrid("Codigo", txtCodigo.Text, string.Empty, gridCodigo);
                    }
                }
                else
                {
                    apoio.Aguarde();
                    carregaGrid("Codigo", txtCodigo.Text, string.Empty, gridCodigo);
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

        private void btnCodVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCodigo["CodPreTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmPreTeste)formulario).Text = "Visualizando Pré-Teste";
                ((frmPreTeste)formulario).disabledForm();
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
                ((frmPreTeste)formulario).Text = "Inserindo Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
                Codigo = gridCodigo["CodPreTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridCodigo);
                ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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

                    //chama a função que exclui o registro na tabela
                    Codigo = gridCodigo["CodPreTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridCodigo.DataSource = null;
                    funcoes.gridPreTeste(gridCodigo, "PreTeste");
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
            if (!btnCodEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridCodigo["CodPreTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridCodigo);
                    ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                    ((frmPreTeste)formulario).enabledForm();
                    ((frmPreTeste)formulario).defineFoco();
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
                Codigo = gridCodigo["CodPreTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                Descricao = gridCodigo["DescricaoCCB", gridCodigo.CurrentRow.Index].Value.ToString();
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
        private void gridCodigo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermCod(gridCodigo);
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

        #region Aba Pessoa

        private void btnPesVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridPessoa["CodPreTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridPessoa);
                ((frmPreTeste)formulario).Text = "Visualizando Pré-Teste";
                ((frmPreTeste)formulario).disabledForm();
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
        private void btnPesIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridPessoa);
                ((frmPreTeste)formulario).Text = "Inserindo Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnPesEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridPessoa["CodPreTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridPessoa);
                ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnPesExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridPessoa["CodPreTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridPessoa.DataSource = null;
                    funcoes.gridPreTeste(gridPessoa, "PreTeste");
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
                AcceptButton = btnPessoa;
            }
        }

        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes", gridPessoa);
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
        private void lblCodPessoa_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCodPessoa.Text))
            {
                try
                {
                    apoio.Aguarde();
                    carregaGrid("Pessoa", lblCodPessoa.Text, string.Empty, gridPessoa);
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

        private void gridPessoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnPesEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridPessoa["CodPreTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridPessoa);
                    ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                    ((frmPreTeste)formulario).enabledForm();
                    ((frmPreTeste)formulario).defineFoco();
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
        private void gridPessoa_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridPessoa["CodPreTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                Descricao = gridPessoa["DescricaoCCB", gridPessoa.CurrentRow.Index].Value.ToString();
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
        private void gridPessoa_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermPessoa(gridPessoa);
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
        private void lblCodComum_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCodComum.Text))
            {
                try
                {
                    apoio.Aguarde();
                    carregaGrid("Comum", lblCodComum.Text, string.Empty, gridComum);
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

        private void btnComVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridComum["CodPreTeste", gridComum.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridComum);
                ((frmPreTeste)formulario).Text = "Visualizando Pré-Teste";
                ((frmPreTeste)formulario).disabledForm();
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
                ((frmPreTeste)formulario).Text = "Inserindo Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnComEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridComum["CodPreTeste", gridComum.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridComum);
                ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnComExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridComum["CodPreTeste", gridComum.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridComum.DataSource = null;
                    funcoes.gridPreTeste(gridComum, "PreTeste");
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
                AcceptButton = btnComum;
            }
        }

        private void gridComum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnComEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridComum["CodPreTeste", gridComum.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridComum);
                    ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                    ((frmPreTeste)formulario).enabledForm();
                    ((frmPreTeste)formulario).defineFoco();
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
                Codigo = gridComum["CodPreTeste", gridComum.CurrentRow.Index].Value.ToString();
                Descricao = gridComum["DescricaoCCB", gridComum.CurrentRow.Index].Value.ToString();
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
        private void gridComum_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermComum(gridComum);
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

        #region Aba Solicitação

        private void txtSolicita_Leave(object sender, EventArgs e)
        {
            try
            {
                AcceptButton = btnCodIns;
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
        private void txtSolicita_Enter(object sender, EventArgs e)
        {
            try
            {
                AcceptButton = btnCod;
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
        private void btnSolicita_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtSolicita.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        apoio.Aguarde();
                        carregaGrid("Solicita", txtSolicita.Text, string.Empty, gridSolicita);
                    }
                }
                else
                {
                    apoio.Aguarde();
                    carregaGrid("Solicita", txtSolicita.Text, string.Empty, gridSolicita);
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

        private void btnSolVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridSolicita["CodPreTeste", gridSolicita.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridSolicita);
                ((frmPreTeste)formulario).Text = "Visualizando Pré-Teste";
                ((frmPreTeste)formulario).disabledForm();
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
        private void btnSolIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridSolicita);
                ((frmPreTeste)formulario).Text = "Inserindo Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnSolEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridSolicita["CodPreTeste", gridSolicita.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridSolicita);
                ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnSolExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridSolicita["CodPreTeste", gridSolicita.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridSolicita.DataSource = null;
                    funcoes.gridPreTeste(gridSolicita, "PreTeste");
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
                txtSolicita.Focus();
            }
        }

        private void gridSolicita_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSolEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridSolicita["CodPreTeste", gridSolicita.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridSolicita);
                    ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                    ((frmPreTeste)formulario).enabledForm();
                    ((frmPreTeste)formulario).defineFoco();
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
        private void gridSolicita_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridSolicita["CodPreTeste", gridSolicita.CurrentRow.Index].Value.ToString();
                Descricao = gridSolicita["DescricaoCCB", gridSolicita.CurrentRow.Index].Value.ToString();
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
        private void gridSolicita_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermSolicita(gridSolicita);
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

        #region Aba Data

        private void btnDataInicial_Click(object sender, EventArgs e)
        {
            try
            {
                txtDataInicial.Text = funcoes.FormataData("01/01/1910");
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
        private void btnDataFinal_Click(object sender, EventArgs e)
        {
            try
            {
                txtDataFinal.Text = funcoes.FormataData("31/12/2050");
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
        private void txtDataInicial_Leave(object sender, EventArgs e)
        {
            try
            {
                string DataInicial = string.Empty;
                string DataFinal = string.Empty;
                DataInicial = funcoes.DataInt(txtDataInicial.Text);
                DataFinal = funcoes.DataInt(txtDataFinal.Text);

                if (!string.IsNullOrEmpty(DataInicial) && !string.IsNullOrEmpty(DataFinal))
                {
                    if (Convert.ToInt32(DataInicial) > Convert.ToInt32(DataFinal))
                    {
                        txtDataFinal.Text = txtDataInicial.Text;
                    }
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
        private void txtDataFinal_Leave(object sender, EventArgs e)
        {
            try
            {
                string DataInicial = string.Empty;
                string DataFinal = string.Empty;
                DataInicial = funcoes.DataInt(txtDataInicial.Text);
                DataFinal = funcoes.DataInt(txtDataFinal.Text);

                if (!string.IsNullOrEmpty(DataInicial) && !string.IsNullOrEmpty(DataFinal))
                {
                    if (Convert.ToInt32(DataFinal) < Convert.ToInt32(DataInicial))
                    {
                        txtDataInicial.Text = txtDataFinal.Text;
                    }
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
        private void btnData_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtDataInicial.Text) || string.IsNullOrEmpty(this.txtDataInicial.Text))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    List<MOD_erros> listaErros = new List<MOD_erros>();
                    objEnt_Erros.Texto = "Data Inicial e Final. Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                else
                {
                    apoio.Aguarde();
                    carregaGrid("Data", txtDataInicial.Text, txtDataFinal.Text, gridData);
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

        private void btnDataVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridData["CodPreTeste", gridData.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridData);
                ((frmPreTeste)formulario).Text = "Visualizando Pré-Teste";
                ((frmPreTeste)formulario).disabledForm();
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
        private void btnDataIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridData);
                ((frmPreTeste)formulario).Text = "Inserindo Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnDataEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridData["CodPreTeste", gridData.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridData);
                ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnDataExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridData["CodPreTeste", gridData.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridSolicita.DataSource = null;
                    funcoes.gridPreTeste(gridData, "PreTeste");
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
                txtDataInicial.Focus();
            }
        }

        private void gridData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnDataEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridData["CodPreTeste", gridData.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridData);
                    ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                    ((frmPreTeste)formulario).enabledForm();
                    ((frmPreTeste)formulario).defineFoco();
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
        private void gridData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridData["CodPreTeste", gridData.CurrentRow.Index].Value.ToString();
                Descricao = gridData["DescricaoCCB", gridData.CurrentRow.Index].Value.ToString();
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
        private void gridData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermData(gridData);
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

        #region Situacao

        private void cboSituacao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboSituacao.Text))
            {
                try
                {
                    apoio.Aguarde();
                    carregaGrid("Situacao", cboSituacao.Text, string.Empty, gridSituacao);
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

        private void btnSitVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridSituacao["CodPreTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridSituacao);
                ((frmPreTeste)formulario).Text = "Visualizando Pré-Teste";
                ((frmPreTeste)formulario).disabledForm();
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
        private void btnSitIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridSituacao);
                ((frmPreTeste)formulario).Text = "Inserindo Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnSitEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridSituacao["CodPreTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridSituacao);
                ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                ((frmPreTeste)formulario).enabledForm();
                ((frmPreTeste)formulario).defineFoco();
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
        private void btnSitExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridSituacao["CodPreTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridSituacao.DataSource = null;
                    funcoes.gridPreTeste(gridSituacao, "PreTeste");
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
                AcceptButton = btnComum;
            }
        }

        private void gridSituacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSitEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridSituacao["CodPreTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridSituacao);
                    ((frmPreTeste)formulario).Text = "Editando Pré-Teste";
                    ((frmPreTeste)formulario).enabledForm();
                    ((frmPreTeste)formulario).defineFoco();
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
        private void gridSituacao_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridSituacao["CodPreTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                Descricao = gridSituacao["DescricaoCCB", gridSituacao.CurrentRow.Index].Value.ToString();
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
        private void gridSituacao_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                verPermSit(gridSituacao);
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

        private void frmPreTesteBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridPreTeste(gridCodigo, "PreTeste");

                //verificar permissão de acesso
                verPermCod(gridCodigo);

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
        private void tabPreTeste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabPreTeste.SelectedTab.Name.Equals("tabCodigo"))
                {
                    funcoes.gridPreTeste(gridCodigo, "PreTeste");
                    verPermCod(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
                else if (tabPreTeste.SelectedTab.Name.Equals("tabPessoa"))
                {
                    funcoes.gridPreTeste(gridPessoa, "PreTeste");
                    verPermPessoa(gridPessoa);
                    lblCodPessoa.Text = string.Empty;
                    lblDescPessoa.Text = string.Empty;
                    AcceptButton = btnPessoa;
                }
                else if (tabPreTeste.SelectedTab.Name.Equals("tabData"))
                {
                    funcoes.gridPreTeste(gridData, "PreTeste");
                    verPermData(gridData);
                    txtDataInicial.Text = string.Empty;
                    txtDataFinal.Text = string.Empty;
                    txtDataInicial.Focus();
                }
                else if (tabPreTeste.SelectedTab.Name.Equals("tabSolicita"))
                {
                    funcoes.gridPreTeste(gridSolicita, "PreTeste");
                    verPermSolicita(gridSolicita);
                    txtSolicita.Text = string.Empty;
                    txtSolicita.Focus();
                }
                else if (tabPreTeste.SelectedTab.Name.Equals("tabSituacao"))
                {
                    funcoes.gridPreTeste(gridSituacao, "PreTeste");
                    verPermSit(gridSituacao);
                    cboSituacao.SelectedIndex = -1;
                    cboSituacao.Focus();
                }
                else if (tabPreTeste.SelectedTab.Name.Equals("tabComum"))
                {
                    funcoes.gridPreTeste(gridComum, "PreTeste");
                    verPermComum(gridComum);
                    cboSituacao.SelectedIndex = -1;
                    cboSituacao.Focus();
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

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="DataGrid"></param>
        internal void carregaGrid(string Pesquisa, string Campo1, string Campo2, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("PreTeste"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_preTeste();
                    lista = objBLL.buscarCod(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridPreTeste(dataGrid, "PreTeste");
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_preTeste();
                    lista = objBLL.buscarCod(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridPreTeste(dataGrid, "PreTeste");
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Pessoa"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_preTeste();
                    lista = objBLL.buscarPessoa(Campo1);
                    funcoes.gridPreTeste(dataGrid, "PreTeste");
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Comum"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_preTeste();
                    lista = objBLL.buscarComum(Campo1);
                    funcoes.gridPreTeste(dataGrid, "PreTeste");
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Solicita"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_preTeste();
                    lista = objBLL.buscarSolicita(Campo1);
                    funcoes.gridPreTeste(dataGrid, "PreTeste");
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Data"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_preTeste();
                    lista = objBLL.buscarData("DataExame", Campo1, Campo2);
                    funcoes.gridPreTeste(dataGrid, "PreTeste");
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Situacao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_preTeste();
                    lista = objBLL.buscarStatus(Campo1);
                    funcoes.gridPreTeste(dataGrid, "PreTeste");
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
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
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(string form, DataGridView dataGrid)
        {
            try
            {
                preencher(Codigo);
                formulario = new frmPreTeste(this, dataGrid, lista);
                ((frmPreTeste)formulario).MdiParent = MdiParent;
                ((frmPreTeste)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmPreTeste)formulario));
                ((frmPreTeste)formulario).Show();
                ((frmPreTeste)formulario).BringToFront();
                Enabled = false;
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
        /// <param name="CodDepartamento"></param>
        internal void preencher(string CodPreTeste)
        {
            try
            {
                objBLL = new BLL_preTeste();
                lista = objBLL.buscarCod(CodPreTeste);
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
        private MOD_preTeste criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_preTeste();
                objEnt.CodPreTeste = Codigo;

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
                    if (Convert.ToString(linha.Cells["Status"].Value).Contains("Aberto"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[0];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Finalizado"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[4];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Cancelado"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[2];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Realizado"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[1];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("ReAgendado"))
                    {
                        linha.Cells["img"].Value = imgPreTeste.Images[3];
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
        public void defineFoco()
        {
            txtCodigo.Focus();
        }

        #region Verificar Permissões de Acessos

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermCod(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();

                btnCodIns.Enabled = funcoes.liberacoes(entAcesso.rotInsPreTeste);
                btnCodEditar.Enabled = funcoes.liberacoes(entAcesso.rotEditPreTeste, dataGrid);
                btnCodExc.Enabled = funcoes.liberacoes(entAcesso.rotCancelPreTeste, dataGrid);
                btnCodVisual.Enabled = funcoes.liberacoes(entAcesso.rotVisPreTeste, dataGrid);
                btnCodEncerra.Enabled = funcoes.liberacoes(entAcesso.rotEncerraPreTeste, dataGrid);
                btnCodAgenda.Enabled = funcoes.liberacoes(entAcesso.rotReAgendaPreTeste, dataGrid);
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
        internal void verPermPessoa(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();

                btnPesIns.Enabled = funcoes.liberacoes(entAcesso.rotInsPreTeste);
                btnPesEditar.Enabled = funcoes.liberacoes(entAcesso.rotEditPreTeste, dataGrid);
                btnPesExc.Enabled = funcoes.liberacoes(entAcesso.rotCancelPreTeste, dataGrid);
                btnPesVisual.Enabled = funcoes.liberacoes(entAcesso.rotVisPreTeste, dataGrid);
                btnPesEncerra.Enabled = funcoes.liberacoes(entAcesso.rotEncerraPreTeste, dataGrid);
                btnPesAgenda.Enabled = funcoes.liberacoes(entAcesso.rotReAgendaPreTeste, dataGrid);
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
        internal void verPermData(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();

                btnDataIns.Enabled = funcoes.liberacoes(entAcesso.rotInsPreTeste);
                btnDataEditar.Enabled = funcoes.liberacoes(entAcesso.rotEditPreTeste, dataGrid);
                btnDataExc.Enabled = funcoes.liberacoes(entAcesso.rotCancelPreTeste, dataGrid);
                btnDataVisual.Enabled = funcoes.liberacoes(entAcesso.rotVisPreTeste, dataGrid);
                btnDataEncerra.Enabled = funcoes.liberacoes(entAcesso.rotEncerraPreTeste, dataGrid);
                btnDataAgenda.Enabled = funcoes.liberacoes(entAcesso.rotReAgendaPreTeste, dataGrid);
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
        internal void verPermSolicita(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();

                btnSolIns.Enabled = funcoes.liberacoes(entAcesso.rotInsPreTeste);
                btnSolEditar.Enabled = funcoes.liberacoes(entAcesso.rotEditPreTeste, dataGrid);
                btnSolExc.Enabled = funcoes.liberacoes(entAcesso.rotCancelPreTeste, dataGrid);
                btnSolVisual.Enabled = funcoes.liberacoes(entAcesso.rotVisPreTeste, dataGrid);
                btnSolEncerra.Enabled = funcoes.liberacoes(entAcesso.rotEncerraPreTeste, dataGrid);
                btnSolAgenda.Enabled = funcoes.liberacoes(entAcesso.rotReAgendaPreTeste, dataGrid);
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
        internal void verPermSit(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();

                btnSitIns.Enabled = funcoes.liberacoes(entAcesso.rotInsPreTeste);
                btnSitEditar.Enabled = funcoes.liberacoes(entAcesso.rotEditPreTeste, dataGrid);
                btnSitExc.Enabled = funcoes.liberacoes(entAcesso.rotCancelPreTeste, dataGrid);
                btnSitVisual.Enabled = funcoes.liberacoes(entAcesso.rotVisPreTeste, dataGrid);
                btnSitEncerra.Enabled = funcoes.liberacoes(entAcesso.rotEncerraPreTeste, dataGrid);
                btnSitAgenda.Enabled = funcoes.liberacoes(entAcesso.rotReAgendaPreTeste, dataGrid);
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
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();

                btnComIns.Enabled = funcoes.liberacoes(entAcesso.rotInsPreTeste);
                btnComEditar.Enabled = funcoes.liberacoes(entAcesso.rotEditPreTeste, dataGrid);
                btnComExc.Enabled = funcoes.liberacoes(entAcesso.rotCancelPreTeste, dataGrid);
                btnComVisual.Enabled = funcoes.liberacoes(entAcesso.rotVisPreTeste, dataGrid);
                btnComEncerra.Enabled = funcoes.liberacoes(entAcesso.rotEncerraPreTeste, dataGrid);
                btnComAgenda.Enabled = funcoes.liberacoes(entAcesso.rotReAgendaPreTeste, dataGrid);
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