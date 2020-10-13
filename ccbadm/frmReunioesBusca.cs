using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.uteis;
using BLL.administracao;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ccbadm.pesquisa;
using ENT.acessos;
using ENT.uteis;
using ENT.administracao;
using ENT.relatorio;
using ccbadm.relatorios;

namespace ccbadm
{
    public partial class frmReunioesBusca : Form
    {
        public frmReunioesBusca(List<MOD_acessos> listaLibAcesso)
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
        string Status;
        string DescricaoCCB;
        string Data;

        BLL_reuniaoMinisterio objBLL = null;
        MOD_reuniaoMinisterio objEnt = null;
        List<MOD_reuniaoMinisterio> lista;

        BLL_listaPresenca objBLL_Presenca = null;
        List<MOD_listaPresenca> listaPresenca = null;

        Form formulario;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        #region Aba Reuniao

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
                Codigo = gridCodigo["CodReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridCodigo);
                ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                ((frmReunioes)formulario).disabledForm();
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
                ((frmReunioes)formulario).Text = "Inserindo Reunião Ministerial";
                ((frmReunioes)formulario).enabledForm();
                ((frmReunioes)formulario).defineFoco();
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
                Codigo = gridCodigo["CodReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("A Realizar"))
                {
                    abrirForm(string.Empty, gridCodigo);
                    ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                    ((frmReunioes)formulario).enabledForm();
                    ((frmReunioes)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridCodigo);
                        ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                        ((frmReunioes)formulario).disabledForm();
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
                    Codigo = gridCodigo["CodReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
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
        private void btnCodFinaliza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.finalizar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridCodigo["CodReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Finaliza");

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
                    Codigo = gridCodigo["CodReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("A Realizar"))
                    {
                        abrirForm(string.Empty, gridCodigo);
                        ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                        ((frmReunioes)formulario).enabledForm();
                        ((frmReunioes)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridCodigo);
                            ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                            ((frmReunioes)formulario).disabledForm();
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
                Codigo = gridCodigo["CodReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
                Status = gridCodigo["Status", gridCodigo.CurrentRow.Index].Value.ToString();
                Data = gridCodigo["DataReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
                DescricaoCCB = gridCodigo["DescricaoCCB", gridCodigo.CurrentRow.Index].Value.ToString();
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
        private void btnCodImp_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridCodigo["CodReuniao", gridCodigo.CurrentRow.Index].Value.ToString();
                //NomeRelatorio = "ccbadm.relatorios.rptReuniao_Sint_Cargo.rdlc";
                abrirForm("frmListagem", gridCodigo);
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

        #region Aba Regiao

        private void cboRegiao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid("Regiao", Convert.ToString(cboRegiao.SelectedValue), string.Empty, gridRegiao);
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
                Codigo = gridRegiao["CodReuniao", gridRegiao.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridRegiao);
                ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                ((frmReunioes)formulario).disabledForm();
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
                preencher(Codigo);
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridRegiao);
                ((frmReunioes)formulario).Text = "Inserindo Reunião Ministerial";
                ((frmReunioes)formulario).enabledForm();
                ((frmReunioes)formulario).defineFoco();
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
                Codigo = gridRegiao["CodReuniao", gridRegiao.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("A Realizar"))
                {
                    abrirForm(string.Empty, gridRegiao);
                    ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                    ((frmReunioes)formulario).enabledForm();
                    ((frmReunioes)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridRegiao);
                        ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                        ((frmReunioes)formulario).disabledForm();
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
        private void btnRegCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.cancelar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeCancelar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridRegiao["CodReuniao", gridRegiao.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Cancela");

                    carregaGrid("Codigo", Codigo, string.Empty, gridRegiao);
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
        private void btnRegFinaliza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.finalizar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridRegiao["CodReuniao", gridRegiao.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Finaliza");

                    carregaGrid("Codigo", Codigo, string.Empty, gridRegiao);
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
        private void btnRegImp_Click(object sender, EventArgs e)
        {

        }
        private void gridRegiao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnRegEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridRegiao["CodReuniao", gridRegiao.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("A Realizar"))
                    {
                        abrirForm(string.Empty, gridRegiao);
                        ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                        ((frmReunioes)formulario).enabledForm();
                        ((frmReunioes)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridRegiao);
                            ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                            ((frmReunioes)formulario).disabledForm();
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
        private void gridRegiao_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermRegiao(gridRegiao);
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
        private void gridRegiao_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridRegiao["CodReuniao", gridRegiao.CurrentRow.Index].Value.ToString();
                Status = gridRegiao["Status", gridRegiao.CurrentRow.Index].Value.ToString();
                Data = gridRegiao["DataReuniao", gridRegiao.CurrentRow.Index].Value.ToString();
                DescricaoCCB = gridRegiao["DescricaoCCB", gridRegiao.CurrentRow.Index].Value.ToString();
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
                Codigo = gridData["CodReuniao", gridData.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridData);
                ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                ((frmReunioes)formulario).disabledForm();
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
                ((frmReunioes)formulario).Text = "Inserindo Reunião Ministerial";
                ((frmReunioes)formulario).enabledForm();
                ((frmReunioes)formulario).defineFoco();
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
                Codigo = gridData["CodReuniao", gridData.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("A Realizar"))
                {
                    abrirForm(string.Empty, gridData);
                    ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                    ((frmReunioes)formulario).enabledForm();
                    ((frmReunioes)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridData);
                        ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                        ((frmReunioes)formulario).disabledForm();
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
                    Codigo = gridData["CodReuniao", gridData.CurrentRow.Index].Value.ToString();
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
        private void btnDataFinaliza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.negar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridData["CodReuniao", gridData.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Finaliza");

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
                    Codigo = gridData["CodReuniao", gridData.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("A Realizar"))
                    {
                        abrirForm(string.Empty, gridData);
                        ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                        ((frmReunioes)formulario).enabledForm();
                        ((frmReunioes)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridData);
                            ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                            ((frmReunioes)formulario).disabledForm();
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
                Codigo = gridData["CodReuniao", gridData.CurrentRow.Index].Value.ToString();
                Status = gridData["Status", gridData.CurrentRow.Index].Value.ToString();
                Data = gridData["DataReuniao", gridData.CurrentRow.Index].Value.ToString();
                DescricaoCCB = gridData["DescricaoCCB", gridData.CurrentRow.Index].Value.ToString();
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
                Codigo = gridSituacao["CodReuniao", gridSituacao.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                abrirForm(string.Empty, gridSituacao);
                ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                ((frmReunioes)formulario).disabledForm();
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
                ((frmReunioes)formulario).Text = "Inserindo Reunião Ministerial";
                ((frmReunioes)formulario).enabledForm();
                ((frmReunioes)formulario).defineFoco();
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
                Codigo = gridSituacao["CodReuniao", gridSituacao.CurrentRow.Index].Value.ToString();
                preencher(Codigo);
                if (lista[0].Status.Equals("A Realizar"))
                {
                    abrirForm(string.Empty, gridSituacao);
                    ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                    ((frmReunioes)formulario).enabledForm();
                    ((frmReunioes)formulario).defineFoco();
                }
                else
                {
                    if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        abrirForm(string.Empty, gridSituacao);
                        ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                        ((frmReunioes)formulario).disabledForm();
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
                    Codigo = gridSituacao["CodReuniao", gridSituacao.CurrentRow.Index].Value.ToString();
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
        private void btnSitFinaliza_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.negar, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeGravar();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridSituacao["CodReuniao", gridSituacao.CurrentRow.Index].Value.ToString();
                    objBLL.salvar(criarTabela(), "Finaliza");

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
                    Codigo = gridSituacao["CodReuniao", gridSituacao.CurrentRow.Index].Value.ToString();
                    preencher(Codigo);
                    if (lista[0].Status.Equals("A Realizar"))
                    {
                        abrirForm(string.Empty, gridSituacao);
                        ((frmReunioes)formulario).Text = "Editando Reunião Ministerial";
                        ((frmReunioes)formulario).enabledForm();
                        ((frmReunioes)formulario).defineFoco();
                    }
                    else
                    {
                        if (MessageBox.Show("Somente possível editar Reuniões Ministeriais com Status < A Realizar > !" + "\n" + "Deseja visualizar os dados da Reunião?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            abrirForm(string.Empty, gridSituacao);
                            ((frmReunioes)formulario).Text = "Visualizando Reunião Ministerial";
                            ((frmReunioes)formulario).disabledForm();
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
                Codigo = gridSituacao["CodReuniao", gridSituacao.CurrentRow.Index].Value.ToString();
                Status = gridSituacao["Status", gridSituacao.CurrentRow.Index].Value.ToString();
                Data = gridSituacao["DataReuniao", gridSituacao.CurrentRow.Index].Value.ToString();
                DescricaoCCB = gridSituacao["DescricaoCCB", gridSituacao.CurrentRow.Index].Value.ToString();
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

        private void frmReunioesBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridReuniaoMinisterio(gridCodigo);

                //verificar permissão de acesso
                verPermCod(gridCodigo);

                pctRealizar.Image = imgReuniao.Images[0];
                pctRealizada.Image = imgReuniao.Images[1];
                pctCancelada.Image = imgReuniao.Images[2];
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
        private void tabReunioes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabReunioes.SelectedTab.Name.Equals("tabCodigo"))
                {
                    funcoes.gridReuniaoMinisterio(gridCodigo);
                    verPermCod(gridCodigo);
                    txtCodigo.Text = string.Empty;
                    txtCodigo.Focus();
                }
                else if (tabReunioes.SelectedTab.Name.Equals("tabRegiao"))
                {
                    //Carrega o ComboRegiao
                    apoio.carregaComboRegiao(cboRegiao);
                    funcoes.gridReuniaoMinisterio(gridRegiao);
                    verPermRegiao(gridRegiao);
                    cboRegiao.SelectedIndex = -1;
                    cboRegiao.Focus();
               }
                else if (tabReunioes.SelectedTab.Name.Equals("tabData"))
                {
                    funcoes.gridReuniaoMinisterio(gridData);
                    verPermData(gridData);
                    txtDataInicial.Text = string.Empty;
                    txtDataFinal.Text = string.Empty;
                    txtDataInicial.Focus();
                }
                else if (tabReunioes.SelectedTab.Name.Equals("tabStatus"))
                {
                    funcoes.gridReuniaoMinisterio(gridSituacao);
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
                if (Pesquisa.Equals("Reuniao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_reuniaoMinisterio();
                    lista = objBLL.buscarCod(Campo1);
                    funcoes.gridReuniaoMinisterio(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Codigo"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_reuniaoMinisterio();
                    lista = objBLL.buscarCod(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridReuniaoMinisterio(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Regiao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_reuniaoMinisterio();
                    lista = objBLL.buscarRegiao(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridReuniaoMinisterio(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Data"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_reuniaoMinisterio();
                    lista = objBLL.buscarData("DataReuniao", Campo1, Campo2, modulos.CodUsuarioCCB);
                    funcoes.gridReuniaoMinisterio(dataGrid);
                    dataGrid.DataSource = lista;
                    definirImagens(dataGrid);
                }
                else if (Pesquisa.Equals("Situacao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_reuniaoMinisterio();
                    lista = objBLL.buscarStatus(Campo1, modulos.CodUsuarioCCB);
                    funcoes.gridReuniaoMinisterio(dataGrid);
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
                if (form.Equals("frmListagem"))
                {
                    preencher(Codigo);
                    formulario = new frmMixListaReuniao(this, lista);
                    ((frmMixListaReuniao)formulario).MdiParent = MdiParent;
                    ((frmMixListaReuniao)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmMixListaReuniao)formulario));
                    ((frmMixListaReuniao)formulario).Show();
                    ((frmMixListaReuniao)formulario).BringToFront();
                    Enabled = false;
                }
                else
                {
                    formulario = new frmReunioes(this, dataGrid, lista);
                    ((frmReunioes)formulario).MdiParent = MdiParent;
                    ((frmReunioes)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmReunioes)formulario));
                    ((frmReunioes)formulario).Show();
                    ((frmReunioes)formulario).BringToFront();
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
        /// <param name="CodReuniao"></param>
        internal void preencher(string CodReuniao)
        {
            try
            {
                objBLL = new BLL_reuniaoMinisterio();
                lista = objBLL.buscarCod(CodReuniao);
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
        /// Função que preenche a Reunião para ser impresso a lista de presentes
        /// </summary>
        /// <param name="CodReuniao"></param>
        internal void preencherLista(string CodReuniao)
        {
            try
            {
                objBLL_Presenca = new BLL_listaPresenca();
                listaPresenca = objBLL_Presenca.buscarListaPresenca(CodReuniao);
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
        private MOD_reuniaoMinisterio criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_reuniaoMinisterio();
                objEnt.CodReuniao = Codigo;
                objEnt.CodReuniao = Status;
                objEnt.DataReuniao = Data;
                objEnt.DescricaoCCB = DescricaoCCB;

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
                    if (Convert.ToString(linha.Cells["Status"].Value).Contains("A Realizar"))
                    {
                        linha.Cells["img"].Value = imgReuniao.Images[0];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Realizada"))
                    {
                        linha.Cells["img"].Value = imgReuniao.Images[1];
                    }
                    else if (Convert.ToString(linha.Cells["Status"].Value).Contains("Cancelada"))
                    {
                        linha.Cells["img"].Value = imgReuniao.Images[2];
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
                MOD_acessoReuniao entAcesso = new MOD_acessoReuniao();

                btnCodIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsReuniao);
                btnCodEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditReuniao, dataGrid);
                btnCodCancel.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotCancelReuniao, dataGrid);
                btnCodVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisReuniao, dataGrid);
                btnCodImp.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotImpReuniao, dataGrid);
                btnCodFinaliza.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotFinalReuniao, dataGrid);
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
                MOD_acessoReuniao entAcesso = new MOD_acessoReuniao();

                btnRegIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsReuniao);
                btnRegEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditReuniao, dataGrid);
                btnRegCancel.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotCancelReuniao, dataGrid);
                btnRegVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisReuniao, dataGrid);
                btnRegImp.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotImpReuniao, dataGrid);
                btnRegFinaliza.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotFinalReuniao, dataGrid);
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
                MOD_acessoReuniao entAcesso = new MOD_acessoReuniao();

                btnDataIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsReuniao);
                btnDataEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditReuniao, dataGrid);
                btnDataCancel.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotCancelReuniao, dataGrid);
                btnDataVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisReuniao, dataGrid);
                btnDataImp.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotImpReuniao, dataGrid);
                btnDataFinaliza.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotFinalReuniao, dataGrid);
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
                MOD_acessoReuniao entAcesso = new MOD_acessoReuniao();

                btnSitIns.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotInsReuniao);
                btnSitEditar.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotEditReuniao, dataGrid);
                btnSitCancel.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotCancelReuniao, dataGrid);
                btnSitVisual.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotVisReuniao, dataGrid);
                btnSitImp.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotImpReuniao, dataGrid);
                btnSitFinaliza.Enabled = funcoes.liberacoes(listaAcesso, entAcesso.rotFinalReuniao, dataGrid);
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