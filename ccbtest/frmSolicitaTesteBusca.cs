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
using ENT.pessoa;
using ENT.preTeste;

namespace ccbtest
{
    public partial class frmSolicitaTesteBusca : Form
    {
        public frmSolicitaTesteBusca(List<MOD_acessos> listaLibAcesso)
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
        string Tipo;
        string Nome;
        string Data;

        BLL_solicitaTeste objBLL = null;
        MOD_solicitaTeste objEnt = null;
        List<MOD_solicitaTeste> lista;

        IBLL_buscaPessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa = null;

        Form formulario;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        #region Aba Solicitação

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
                Codigo = gridCodigo["CodSolicitaTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridCodigo);
                ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                ((frmSolicitaTeste)formulario).disabledForm();
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
                preencher(Codigo);
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridCodigo);
                ((frmSolicitaTeste)formulario).Text = "Inserindo Solicitação";
                ((frmSolicitaTeste)formulario).enabledForm();
                ((frmSolicitaTeste)formulario).defineFoco();
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
                Codigo = gridCodigo["CodSolicitaTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("Pendente"))
                {
                    abrirForm(string.Empty, gridCodigo);
                    ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                    ((frmSolicitaTeste)formulario).enabledForm();
                    ((frmSolicitaTeste)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridCodigo);
                        ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                        ((frmSolicitaTeste)formulario).disabledForm();
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void btnCodCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.cancelar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeCancelar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridCodigo["CodSolicitaTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Cancela");

                    carregaGrid("Codigo", Codigo, string.Empty, gridCodigo);
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
                    apoio.FecharAguardeCancelar();
                }
            }
            else
            {
                txtCodigo.Focus();
            }
        }
        private void btnCodNegar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.negar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridCodigo["CodSolicitaTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Nega");

                    carregaGrid("Codigo", Codigo, string.Empty, gridCodigo);
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
                    Codigo = gridCodigo["CodSolicitaTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("Pendente"))
                    {
                        abrirForm(string.Empty, gridCodigo);
                        ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                        ((frmSolicitaTeste)formulario).enabledForm();
                        ((frmSolicitaTeste)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridCodigo);
                            ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                            ((frmSolicitaTeste)formulario).disabledForm();
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
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }
        private void gridCodigo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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
        private void gridCodigo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridCodigo["CodSolicitaTeste", gridCodigo.CurrentRow.Index].Value.ToString();
                Tipo = gridCodigo["Tipo", gridCodigo.CurrentRow.Index].Value.ToString();
                Data = gridCodigo["Data", gridCodigo.CurrentRow.Index].Value.ToString();
                Nome = gridCodigo["Nome", gridCodigo.CurrentRow.Index].Value.ToString();
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
        private void btnPesVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridPessoa["CodSolicitaTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridPessoa);
                ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                ((frmSolicitaTeste)formulario).disabledForm();
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
                preencher(Codigo);
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridPessoa);
                ((frmSolicitaTeste)formulario).Text = "Inserindo Solicitação";
                ((frmSolicitaTeste)formulario).enabledForm();
                ((frmSolicitaTeste)formulario).defineFoco();
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
        private void btnPesEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridPessoa["CodSolicitaTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("Pendente"))
                {
                    abrirForm(string.Empty, gridPessoa);
                    ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                    ((frmSolicitaTeste)formulario).enabledForm();
                    ((frmSolicitaTeste)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridPessoa);
                        ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                        ((frmSolicitaTeste)formulario).disabledForm();
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void btnPesCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.cancelar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeCancelar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridPessoa["CodSolicitaTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Cancela");

                    carregaGrid("Codigo", Codigo, string.Empty, gridPessoa);
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
                    apoio.FecharAguardeCancelar();
                }
            }
        }
        private void btnPesNegar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.negar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridPessoa["CodSolicitaTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Nega");

                    carregaGrid("Codigo", Codigo, string.Empty, gridPessoa);
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
        }
        private void btnPesImp_Click(object sender, EventArgs e)
        {

        }
        private void gridPessoa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnPesEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridPessoa["CodSolicitaTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("Pendente"))
                    {
                        abrirForm(string.Empty, gridPessoa);
                        ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                        ((frmSolicitaTeste)formulario).enabledForm();
                        ((frmSolicitaTeste)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridPessoa);
                            ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                            ((frmSolicitaTeste)formulario).disabledForm();
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
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }
        private void gridPessoa_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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
        private void gridPessoa_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridPessoa["CodSolicitaTeste", gridPessoa.CurrentRow.Index].Value.ToString();
                Tipo = gridPessoa["Tipo", gridPessoa.CurrentRow.Index].Value.ToString();
                Data = gridPessoa["Data", gridPessoa.CurrentRow.Index].Value.ToString();
                Nome = gridPessoa["Nome", gridPessoa.CurrentRow.Index].Value.ToString();
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
            txtDataInicial.Text = funcoes.FormataData("01/01/1990");
        }
        private void txtDataInicial_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnData;
        }
        private void txtDataInicial_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnData;
        }
        private void btnDataFinal_Click(object sender, EventArgs e)
        {
            txtDataFinal.Text = funcoes.FormataData("31/12/2050");
        }
        private void txtDataFinal_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnData;
        }
        private void txtDataFinal_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnData;
        }
        private void btnData_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid("Data", txtDataInicial.Text, txtDataFinal.Text, gridData);
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
                Codigo = gridData["CodSolicitaTeste", gridData.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridData);
                ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                ((frmSolicitaTeste)formulario).disabledForm();
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
                preencher(Codigo);
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridData);
                ((frmSolicitaTeste)formulario).Text = "Inserindo Solicitação";
                ((frmSolicitaTeste)formulario).enabledForm();
                ((frmSolicitaTeste)formulario).defineFoco();
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
                Codigo = gridData["CodSolicitaTeste", gridData.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("Pendente"))
                {
                    abrirForm(string.Empty, gridData);
                    ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                    ((frmSolicitaTeste)formulario).enabledForm();
                    ((frmSolicitaTeste)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridData);
                        ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                        ((frmSolicitaTeste)formulario).disabledForm();
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void btnDataCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.cancelar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeCancelar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridData["CodSolicitaTeste", gridData.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Cancela");

                    carregaGrid("Codigo", Codigo, string.Empty, gridData);
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
                    apoio.FecharAguardeCancelar();
                }
            }
            else
            {
                txtDataInicial.Focus();
            }
        }
        private void btnDataImp_Click(object sender, EventArgs e)
        {

        }
        private void btnDataNegar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.negar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridData["CodSolicitaTeste", gridData.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Nega");

                    carregaGrid("Codigo", Codigo, string.Empty, gridData);
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
                    Codigo = gridData["CodSolicitaTeste", gridData.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("Pendente"))
                    {
                        abrirForm(string.Empty, gridData);
                        ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                        ((frmSolicitaTeste)formulario).enabledForm();
                        ((frmSolicitaTeste)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridData);
                            ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                            ((frmSolicitaTeste)formulario).disabledForm();
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
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }
        private void gridData_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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
        private void gridData_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridData["CodSolicitaTeste", gridData.CurrentRow.Index].Value.ToString();
                Tipo = gridData["Tipo", gridData.CurrentRow.Index].Value.ToString();
                Data = gridData["Data", gridData.CurrentRow.Index].Value.ToString();
                Nome = gridData["Nome", gridData.CurrentRow.Index].Value.ToString();
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

        #region Aba Situação

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
                Codigo = gridSituacao["CodSolicitaTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridSituacao);
                ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                ((frmSolicitaTeste)formulario).disabledForm();
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
                preencher(Codigo);
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridSituacao);
                ((frmSolicitaTeste)formulario).Text = "Inserindo Solicitação";
                ((frmSolicitaTeste)formulario).enabledForm();
                ((frmSolicitaTeste)formulario).defineFoco();
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
        private void btnSitEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridSituacao["CodSolicitaTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("Pendente"))
                {
                    abrirForm(string.Empty, gridSituacao);
                    ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                    ((frmSolicitaTeste)formulario).enabledForm();
                    ((frmSolicitaTeste)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridSituacao);
                        ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                        ((frmSolicitaTeste)formulario).disabledForm();
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void btnSitCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.cancelar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeCancelar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridSituacao["CodSolicitaTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Cancela");

                    carregaGrid("Codigo", Codigo, string.Empty, gridSituacao);
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
                    apoio.FecharAguardeCancelar();
                }
            }
        }
        private void btnSitImp_Click(object sender, EventArgs e)
        {

        }
        private void btnSitNegar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.negar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridSituacao["CodSolicitaTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Nega");

                    carregaGrid("Codigo", Codigo, string.Empty, gridSituacao);
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
        }

        private void gridSituacao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSitEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridSituacao["CodSolicitaTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("Pendente"))
                    {
                        abrirForm(string.Empty, gridSituacao);
                        ((frmSolicitaTeste)formulario).Text = "Editando Solicitação";
                        ((frmSolicitaTeste)formulario).enabledForm();
                        ((frmSolicitaTeste)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar solicitações com status pendente!" + "\n" + "Deseja visualizar a solicitação?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridSituacao);
                            ((frmSolicitaTeste)formulario).Text = "Visualizando Solicitação";
                            ((frmSolicitaTeste)formulario).disabledForm();
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
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }
        private void gridSituacao_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
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
        private void gridSituacao_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridSituacao["CodSolicitaTeste", gridSituacao.CurrentRow.Index].Value.ToString();
                Tipo = gridSituacao["Tipo", gridSituacao.CurrentRow.Index].Value.ToString();
                Data = gridSituacao["Data", gridSituacao.CurrentRow.Index].Value.ToString();
                Nome = gridSituacao["Nome", gridSituacao.CurrentRow.Index].Value.ToString();
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

        private void frmSolicitaTesteBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridSolicitaTeste(gridCodigo);

                //verificar permissão de acesso
                verPermCod(gridCodigo);

                pctPendente.Image = imgSolicita.Images[0];
                pctAutoriza.Image = imgSolicita.Images[1];
                pctCancelada.Image = imgSolicita.Images[2];
                pctNegada.Image = imgSolicita.Images[3];
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
        private void tabSolicitaTeste_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabSolicitaTeste.SelectedTab.Name.Equals("tabCodigo"))
                {
                    funcoes.gridSolicitaTeste(gridCodigo);
                    verPermCod(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
                else if (tabSolicitaTeste.SelectedTab.Name.Equals("tabPessoa"))
                {
                    funcoes.gridSolicitaTeste(gridPessoa);
                    verPermPessoa(gridPessoa);
                    lblCodPessoa.Text = string.Empty;
                    lblDescPessoa.Text = string.Empty;
                    AcceptButton = btnPessoa;
                }
                else if (tabSolicitaTeste.SelectedTab.Name.Equals("tabData"))
                {
                    funcoes.gridSolicitaTeste(gridData);
                    verPermData(gridData);
                    txtDataInicial.Text = string.Empty;
                    txtDataFinal.Text = string.Empty;
                    txtDataInicial.Focus();
                }
                else if (tabSolicitaTeste.SelectedTab.Name.Equals("tabStatus"))
                {
                    funcoes.gridSolicitaTeste(gridSituacao);
                    verPermSit(gridSituacao);
                    cboSituacao.SelectedIndex = - 1;
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
                if (Pesquisa.Equals("Solicitacao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarCod(Campo1);
                    funcoes.gridSolicitaTeste(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarCod(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridSolicitaTeste(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Pessoa"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarPessoa(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridSolicitaTeste(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Data"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarData(Campo1, Campo2, modulos.CodUsuarioCCB);
                    funcoes.gridSolicitaTeste(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Situacao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_solicitaTeste();
                    lista = objBLL.buscarStatus(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridSolicitaTeste(dataGrid);
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
                if (form.Equals("frmPes"))
                {
                    formulario = new frmPesquisaPessoa(this, string.Empty);
                    ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                    ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                    ((frmPesquisaPessoa)formulario).Show();
                    ((frmPesquisaPessoa)formulario).BringToFront();
                    Enabled = false;
                }
                else
                {
                    formulario = new frmSolicitaTeste(this, dataGrid, lista);
                    ((frmSolicitaTeste)formulario).MdiParent = MdiParent;
                    ((frmSolicitaTeste)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmSolicitaTeste)formulario));
                    ((frmSolicitaTeste)formulario).Show();
                    ((frmSolicitaTeste)formulario).BringToFront();
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
        /// <param name="CodSolicitaTeste"></param>
        internal void preencher(string CodSolicitaTeste)
        {
            try
            {
                objBLL = new BLL_solicitaTeste();
                lista = objBLL.buscarCod(CodSolicitaTeste);
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
        private MOD_solicitaTeste criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_solicitaTeste();
                objEnt.CodSolicitaTeste = Codigo;
                objEnt.Tipo = Tipo;
                objEnt.Nome = Nome;
                objEnt.Data = Data;

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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa">Código da Pessoa</param>
        internal void carregaPessoa(string vCodPessoa)
        {
            try
            {

                objBLL_Pessoa = new BLL_buscaPessoaPorCodPessoa();
                listaPessoa = objBLL_Pessoa.Buscar(vCodPessoa, true);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    if (listaPessoa != null && listaPessoa.Count > 0)
                    {
                        lblCodPessoa.Text = listaPessoa[0].CodPessoa;
                        lblDescPessoa.Text = listaPessoa[0].Nome;
                    }
                    else
                    {
                        abrirForm("frmPes", gridPessoa);
                    }
                }
                else
                {
                    abrirForm("frmPes", gridPessoa);
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
                    if (Convert.ToString(linha.Cells["Status"].Value).Contains("Pendente"))
                    {
                        linha.Cells["img"].Value = imgSolicita.Images[0];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Autorizada"))
                    {
                        linha.Cells["img"].Value = imgSolicita.Images[1];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Cancelada"))
                    {
                        linha.Cells["img"].Value = imgSolicita.Images[2];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Negada"))
                    {
                        linha.Cells["img"].Value = imgSolicita.Images[3];
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermCod(DataGridView dataGrid)
        {
            try
            {
                btnCodIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste);
                btnCodEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnCodCancel.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnCodVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnCodNegar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnCodImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
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
                btnPesIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste);
                btnPesEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnPesCancel.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnPesVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnPesNegar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnPesImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
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
                btnDataIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste);
                btnDataEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnDataCancel.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnDataVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnDataNegar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnDataImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
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
                btnSitIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste);
                btnSitEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnSitCancel.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnSitVisual.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnSitNegar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
                btnSitImp.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoSolicitaTeste.RotInsSolicitaTeste, dataGrid);
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