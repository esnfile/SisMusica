﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.instrumentos;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.instrumentos;

namespace ccbinst
{
    public partial class frmMtsFaseBusca : Form
    {
        public frmMtsFaseBusca(List<MOD_acessos> listaLibAcesso)
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

        BLL_mtsFase objBLL = null;
        MOD_mtsFase objEnt = null;
        List<MOD_mtsFase> lista;

        Form formulario;

        List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        #region Aba Descrição

        private void txtDesc_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnDesc;
        }
        private void txtDesc_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnDescIns;
        }
        private void btnDesc_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                carregaGrid("Descricao", txtDesc.Text, gridDesc);
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
        private void btnDescVisual_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmMtsFase)formulario).Text = "Visualizando Fase de Estudo";
                ((frmMtsFase)formulario).disabledForm();
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
        private void btnDescIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = "0";
                //chama a rotina para abrir o formulario
                abrirForm(string.Empty, gridDesc);
                ((frmMtsFase)formulario).Text = "Inserindo Fase de Estudo";
                ((frmMtsFase)formulario).enabledForm();
                ((frmMtsFase)formulario).defineFoco();
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
        private void btnDescEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                abrirForm(string.Empty, gridDesc);
                ((frmMtsFase)formulario).Text = "Editando Fase de Estudo";
                ((frmMtsFase)formulario).enabledForm();
                ((frmMtsFase)formulario).defineFoco();
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
        private void btnDescExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();

                    //chama a função que exclui o registro na tabela
                    Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                    objBLL.excluir(criarTabela());

                    gridDesc.DataSource = null;
                    funcoes.gridMtsFase(gridDesc);
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
                txtDesc.Focus();
            }
        }
        private void gridDesc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnDescEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                    abrirForm(string.Empty, gridDesc);
                    ((frmMtsFase)formulario).Text = "Editando Fase de Estudo";
                    ((frmMtsFase)formulario).enabledForm();
                    ((frmMtsFase)formulario).defineFoco();
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
        private void gridDesc_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                verPermDesc(gridDesc);
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
        private void gridDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridDesc[0, gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = gridDesc[1, gridDesc.CurrentRow.Index].Value.ToString();
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

        private void frmMtsFaseBusca_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridMtsFase(gridDesc);

                //verificar permissão de acesso
                verPermDesc(gridDesc);

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
        internal void carregaGrid(string Pesquisa, string Campo, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("MtsFase"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_mtsFase();
                    lista = objBLL.buscarCod(Campo);
                    funcoes.gridMtsFase(dataGrid);
                    dataGrid.DataSource = lista;
                }
                else if (Pesquisa.Equals("Descricao"))
                {
                    //chama a classe de negócios
                    objBLL = new BLL_mtsFase();
                    lista = objBLL.buscarDescricao(Campo);
                    funcoes.gridMtsFase(dataGrid);
                    dataGrid.DataSource = lista;
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
                formulario = new frmMtsFase(this, dataGrid, lista);
                ((frmMtsFase)formulario).MdiParent = MdiParent;
                ((frmMtsFase)formulario).StartPosition = FormStartPosition.Manual;
                funcoes.CentralizarForm(((frmMtsFase)formulario));
                ((frmMtsFase)formulario).Show();
                ((frmMtsFase)formulario).BringToFront();
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
        /// <param name="CodFase"></param>
        internal void preencher(string CodFase)
        {
            try
            {
                objBLL = new BLL_mtsFase();
                lista = objBLL.buscarCod(CodFase);
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
        private MOD_mtsFase criarTabela()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt = new MOD_mtsFase();
                objEnt.CodFaseMts = Codigo;
                objEnt.DescFase = Descricao;

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
            txtDesc.Focus();
        }

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermDesc(DataGridView dataGrid)
        {
            try
            {
                foreach (MOD_acessos ent in listaAcesso)
                {
                    //verificando o botão inserir
                    if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotInsMtsFase))
                    {
                        btnDescIns.Enabled = true;
                    }
                    //verificando o botão editar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotEditMtsFase))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnDescEditar.Enabled = true;
                        }
                        else
                        {
                            btnDescEditar.Enabled = false;
                        }
                    }
                    //verificando o botão excluir
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotExcMtsFase))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnDescExc.Enabled = true;
                        }
                        else
                        {
                            btnDescExc.Enabled = false;
                        }
                    }
                    //verificando o botão visualizar
                    else if (Convert.ToInt32(ent.CodRotina).Equals(modulos.rotVisMtsFase))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            btnDescVisual.Enabled = true;
                        }
                        else
                        {
                            btnDescVisual.Enabled = false;
                        }
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

        #endregion

    }
}
