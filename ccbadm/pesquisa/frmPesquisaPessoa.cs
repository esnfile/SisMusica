﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using BLL.Funcoes;
using BLL.pessoa;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.pessoa;

namespace ccbadm.pesquisa
{
    public partial class frmPesquisaPessoa : Form
    {
        public frmPesquisaPessoa(Form forms, string Campo)
        {
            InitializeComponent();

            try
            {
                formChama = forms;
                campoChama = Campo;
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

        #region declarações

        //variaveis
        string Codigo;
        string Descricao;

        IBLL_buscaPessoa objBLL = null;
        MOD_pessoa objEnt = null;
        List<MOD_pessoa> lista;

        //instancias de validacoes
        clsException excp;

        Form formChama;
        Form formulario;
        string campoChama;

        #endregion

        #region eventos

        #region Aba Descrição

        private void txtDesc_Enter(object sender, EventArgs e)
        {
            AcceptButton = btnDesc;
        }
        private void txtDesc_Leave(object sender, EventArgs e)
        {
            AcceptButton = btnSel;
        }
        private void btnDesc_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (string.IsNullOrEmpty(this.txtDesc.Text))
                {
                    if (MessageBox.Show(modulos.branco, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        carregaGrid(txtDesc.Text);
                    }
                }
                else
                {
                    carregaGrid(txtDesc.Text);
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
        private void btnSel_Click(object sender, EventArgs e)
        {
            if (!btnSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    //chama a rotina para preencher dados
                    preencher(Codigo);
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
                if (gridDesc.RowCount > 0)
                {
                    btnSel.Enabled = true;
                }
                else
                {
                    btnSel.Enabled = false;
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
        private void gridDesc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridDesc["CodPessoa", gridDesc.CurrentRow.Index].Value.ToString();
                Descricao = gridDesc["Nome", gridDesc.CurrentRow.Index].Value.ToString();
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
        private void gridDesc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!btnSel.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    //chama a rotina para preencher dados
                    preencher(Codigo);
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

        #endregion

        #region Eventos do Formulario

        private void frmPesquisaPessoa_Load(object sender, EventArgs e)
        {
            try
            {
                //chama a funcão montar grid
                funcoes.gridPessoa(gridDesc);
                //definir as imagens
                pctInativa.Image = imgPessoa.Images[0];
                pctAtiva.Image = imgPessoa.Images[1];
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
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmPesquisaPessoa_Activated(object sender, EventArgs e)
        {
            defineFoco();
        }
        private void frmPesquisaPessoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
            //frmListaPresenca.defineFocoIncluir();
        }

        #endregion

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo
        /// </summary>
        /// <param name="Campo1"></param>
        internal void carregaGrid(string Pessoa)
        {
            try
            {
                //chama a classe de negócios
                objBLL = new BLL_buscaPessoaPorCodPessoa();
                List<MOD_pessoa> listaPesFiltro = new List<MOD_pessoa>();
                lista = objBLL.Buscar(Pessoa);

                if (campoChama.Equals("Instrutor"))
                {
                    listaPesFiltro = lista.Where(x => Convert.ToInt16(x.CodCargo).Equals(8)).ToList();

                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = listaPesFiltro;
                    definirImagens(gridDesc);
                }
                else if (campoChama.Equals("Aluno"))
                {
                    listaPesFiltro = lista.Where(x => Convert.ToInt16(x.CodCargo).Equals(10) ||
                                                      Convert.ToInt16(x.CodCargo).Equals(11) ||
                                                      Convert.ToInt16(x.CodCargo).Equals(12)).ToList();

                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = listaPesFiltro;
                    definirImagens(gridDesc);
                }
                else if (campoChama.Equals("Anciao"))
                {
                    listaPesFiltro = lista.Where(x => Convert.ToInt16(x.CodCargo).Equals(1)).ToList();

                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = listaPesFiltro;
                    definirImagens(gridDesc);
                }
                else if (campoChama.Equals("Coop"))
                {
                    listaPesFiltro = lista.Where(x => Convert.ToInt16(x.CodCargo).Equals(2)).ToList();

                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = listaPesFiltro;
                    definirImagens(gridDesc);
                }
                else if (campoChama.Equals("EncReg"))
                {
                    listaPesFiltro = lista.Where(x => Convert.ToInt16(x.CodCargo).Equals(5)).ToList();

                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = listaPesFiltro;
                    definirImagens(gridDesc);
                }
                else if (campoChama.Equals("EncLocal"))
                {
                    listaPesFiltro = lista.Where(x => Convert.ToInt16(x.CodCargo).Equals(6)).ToList();

                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = listaPesFiltro;
                    definirImagens(gridDesc);
                }
                else if (campoChama.Equals("Examina"))
                {
                    listaPesFiltro = lista.Where(x => Convert.ToInt16(x.CodCargo).Equals(7)).ToList();

                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = listaPesFiltro;
                    definirImagens(gridDesc);
                }
                else
                {
                    funcoes.gridPessoa(gridDesc);
                    gridDesc.DataSource = lista;
                    definirImagens(gridDesc);
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
        /// Função que preenche o formulário para seleção
        /// </summary>
        /// <param name="vCodigo"></param>
        private void preencher(string vCodigo)
        {
            try
            {
                if (formChama.Name.Equals("frmListaPresenca"))
                {
                    ((frmListaPresenca)formChama).carregaPessoa(vCodigo, campoChama);
                    Close();
                }
                else if (formChama.Name.Equals("frmReunioes"))
                {
                    ((frmReunioes)formChama).carregaPessoa(vCodigo, campoChama);
                    Close();
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
        /// Função que define o Foco do cursor
        /// </summary>
        private void defineFoco()
        {
            txtDesc.Focus();
        }
        /// <summary>
        /// Função que define a imagem da Situação da Comum
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    if (linha.Cells["Ativo"].Value.ToString().Contains("Não"))
                    {
                        linha.Cells[0].Value = imgPessoa.Images[0];
                    }
                    else if (linha.Cells["Ativo"].Value.ToString().Contains("Sim"))
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

        #endregion

    }
}