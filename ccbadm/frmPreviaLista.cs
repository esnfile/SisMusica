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
using BLL.pessoa;

namespace ccbadm
{
    public partial class frmPreviaLista : Form
    {
        public frmPreviaLista(Form forms, DataGridView gridPesquisa, List<MOD_listaPresenca> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaPresenca = lista;

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

        List<MOD_listaPresenca> listaPresenca = null;

        BLL_pessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa = null;

        Form formChama;
        DataGridView dataGrid;

        #endregion

        #region Eventos do Formulario

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
        private void frmPreviaLista_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
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
        private void frmPreviaLista_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = false;
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
        private void frmPreviaLista_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void txtDemaisIrmasPres_Leave(object sender, EventArgs e)
        {
            txtDemaisIrmasPres.Text = txtDemaisIrmasPres.Text.PadLeft(5, '0');
            SomaTotal();
        }
        private void txtDemaisIrmaosPres_Leave(object sender, EventArgs e)
        {
            txtDemaisIrmaosPres.Text = txtDemaisIrmaosPres.Text.PadLeft(5, '0');
            SomaTotal();
        }

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaPresenca"></param>
        internal void preencher(List<MOD_listaPresenca> listaPresenca)
        {
            try
            {
                List<MOD_pessoa> listaTotEncReg = new List<MOD_pessoa>();
                List<MOD_pessoa> listaTotEncLoc = new List<MOD_pessoa>();
                List<MOD_pessoa> listaTotExamina = new List<MOD_pessoa>();
                List<MOD_pessoa> listaTotInstrutor = new List<MOD_pessoa>();
                List<MOD_pessoa> listaTotInstrutora = new List<MOD_pessoa>();
                List<MOD_pessoa> listaTotProf = new List<MOD_pessoa>();

                List<MOD_listaPresenca> listaFiltroReg = new List<MOD_listaPresenca>();
                List<MOD_listaPresenca> listaFiltroLocal = new List<MOD_listaPresenca>();
                List<MOD_listaPresenca> listaFiltroExamina = new List<MOD_listaPresenca>();
                List<MOD_listaPresenca> listaFiltroInstrutor = new List<MOD_listaPresenca>();
                List<MOD_listaPresenca> listaFiltroInstrutora = new List<MOD_listaPresenca>();
                List<MOD_listaPresenca> listaFiltroProf = new List<MOD_listaPresenca>();

                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaPresenca[0].CodReuniao;
                txtDescricao.Text = listaPresenca[0].DescTipoReuniao;

                foreach (MOD_listaPresenca ent in listaPresenca)
                {
                    //Encarregado Regional
                    if (Convert.ToInt16(ent.CodCargo).Equals(5))
                    {
                        listaFiltroReg.Add(ent);
                    }
                    //Encarregado Local
                    else if (Convert.ToInt16(ent.CodCargo).Equals(6))
                    {
                        listaFiltroLocal.Add(ent);
                    }
                    //Examinadora
                    else if (Convert.ToInt16(ent.CodCargo).Equals(7))
                    {
                        listaFiltroExamina.Add(ent);
                    }
                    //Instrutor e Instrutora
                    else if (Convert.ToInt16(ent.CodCargo).Equals(8))
                    {
                        if (ent.listaPessoa[0].Sexo.Equals("Feminino"))
                        {
                            listaFiltroInstrutora.Add(ent);
                        }
                        else
                        {
                            listaFiltroInstrutor.Add(ent);
                        }
                    }
                    //Professor e Professora
                    else if (Convert.ToInt16(ent.CodCargo).Equals(9))
                    {
                        listaFiltroProf.Add(ent);
                    }
                    else
                    {
                        //txtDemaisIrmaosPres.Text += txtDemaisIrmaosPres.Text;
                    }
                }

                //Total dos Presentes
                txtEncRegPres.Text = Convert.ToString(listaFiltroReg.Count()).PadLeft(5, '0');
                txtEncLocalPres.Text = Convert.ToString(listaFiltroLocal.Count()).PadLeft(5, '0');
                txtExaminaPres.Text = Convert.ToString(listaFiltroExamina.Count()).PadLeft(5, '0');
                txtInstrutorPres.Text = Convert.ToString(listaFiltroInstrutor.Count()).PadLeft(5, '0');
                txtInstrutoraPres.Text = Convert.ToString(listaFiltroInstrutora.Count()).PadLeft(5, '0');
                txtProfessoraPres.Text = Convert.ToString(listaFiltroProf.Count()).PadLeft(5, '0');

                //Total Geral
                objBLL_Pessoa = new BLL_pessoa();
                listaPessoa = objBLL_Pessoa.buscarCod(string.Empty);

                //Encarregado Regional
                foreach (MOD_pessoa entPessoa in listaPessoa)
                {
                    //Encarregado Regional
                    if (Convert.ToInt16(entPessoa.CodCargo).Equals(5))
                    {
                        listaTotEncReg.Add(entPessoa);
                    }
                    //Encarregado Local
                    else if (Convert.ToInt16(entPessoa.CodCargo).Equals(6))
                    {
                        listaTotEncLoc.Add(entPessoa);
                    }
                    //Examinadora
                    else if (Convert.ToInt16(entPessoa.CodCargo).Equals(7))
                    {
                        listaTotExamina.Add(entPessoa);
                    }
                    //Instrutor e Instrutora
                    else if (Convert.ToInt16(entPessoa.CodCargo).Equals(8))
                    {
                        if (entPessoa.Sexo.Equals("Feminino"))
                        {
                            listaTotInstrutora.Add(entPessoa);
                        }
                        else
                        {
                            listaTotInstrutor.Add(entPessoa);
                        }
                    }
                    //Professor e Professora
                    else if (Convert.ToInt16(entPessoa.CodCargo).Equals(9))
                    {
                        listaTotProf.Add(entPessoa);
                    }
                }
                txtEncRegPrev.Text = Convert.ToString(listaTotEncReg.Count()).PadLeft(5, '0');
                txtEncLocalPrev.Text = Convert.ToString(listaTotEncLoc.Count()).PadLeft(5, '0');
                txtExaminaPrev.Text = Convert.ToString(listaTotExamina.Count()).PadLeft(5, '0');
                txtInstrutorPrev.Text = Convert.ToString(listaTotInstrutor.Count()).PadLeft(5, '0');
                txtInstrutoraPrev.Text = Convert.ToString(listaTotInstrutora.Count()).PadLeft(5, '0');
                txtProfessoraPrev.Text = Convert.ToString(listaTotProf.Count()).PadLeft(5, '0');

                SomaTotal();
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
        /// Soma e atualiza os totais
        /// </summary>
        internal void SomaTotal()
        {
            //Previsto
            txtTotalIrmaosPrev.Text = Convert.ToString(Convert.ToInt32(txtEncRegPrev.Text) +
                                       Convert.ToInt32(txtEncLocalPrev.Text) +
                                       Convert.ToInt32(txtInstrutorPrev.Text)).PadLeft(5, '0');

            txtTotalIrmasPrev.Text = Convert.ToString(Convert.ToInt32(txtExaminaPrev.Text) +
                                                   Convert.ToInt32(txtInstrutoraPrev.Text) +
                                                   Convert.ToInt32(txtProfessoraPrev.Text)).PadLeft(5, '0');

            //Presentes
            txtTotalIrmaosPres.Text = Convert.ToString(Convert.ToInt32(txtEncRegPres.Text) +
                                                   Convert.ToInt32(txtEncLocalPres.Text) +
                                                   Convert.ToInt32(txtInstrutorPres.Text) +
                                                   Convert.ToInt32(txtDemaisIrmaosPres.Text)).PadLeft(5, '0');

            txtTotalIrmasPres.Text = Convert.ToString(Convert.ToInt32(txtExaminaPres.Text) +
                                                   Convert.ToInt32(txtInstrutoraPres.Text) +
                                                   Convert.ToInt32(txtProfessoraPres.Text) +
                                                   Convert.ToInt32(txtDemaisIrmasPres.Text)).PadLeft(5, '0');

            //Ausentes
            txtEncRegAus.Text = Convert.ToString(Convert.ToInt32(txtEncRegPrev.Text) -
                           Convert.ToInt32(txtEncRegPres.Text)).PadLeft(5, '0');
            txtEncLocalAus.Text = Convert.ToString(Convert.ToInt32(txtEncLocalPrev.Text) -
                           Convert.ToInt32(txtEncLocalPres.Text)).PadLeft(5, '0');
            txtInstrutorAus.Text = Convert.ToString(Convert.ToInt32(txtInstrutorPrev.Text) -
                           Convert.ToInt32(txtInstrutorPres.Text)).PadLeft(5, '0');
            txtInstrutoraAus.Text = Convert.ToString(Convert.ToInt32(txtInstrutoraPrev.Text) -
                           Convert.ToInt32(txtInstrutoraPres.Text)).PadLeft(5, '0');
            txtExaminaAus.Text = Convert.ToString(Convert.ToInt32(txtExaminaPrev.Text) -
                           Convert.ToInt32(txtExaminaPres.Text)).PadLeft(5, '0');
            txtProfessoraAus.Text = Convert.ToString(Convert.ToInt32(txtProfessoraPrev.Text) -
                           Convert.ToInt32(txtProfessoraPres.Text)).PadLeft(5, '0');

            txtTotalIrmaosAus.Text = Convert.ToString(Convert.ToInt32(txtEncRegAus.Text) +
                                       Convert.ToInt32(txtEncLocalAus.Text) +
                                       Convert.ToInt32(txtInstrutorAus.Text)).PadLeft(5, '0');

            txtTotalIrmasAus.Text = Convert.ToString(Convert.ToInt32(txtExaminaAus.Text) +
                                                   Convert.ToInt32(txtInstrutoraAus.Text) +
                                                   Convert.ToInt32(txtProfessoraAus.Text)).PadLeft(5, '0');


            //Calcula Porcentagem
            //Regionais
            decimal EncRegPrev = Convert.ToDecimal(Convert.ToDecimal(txtEncRegPrev.Text) / Convert.ToDecimal(txtEncRegPrev.Text));
            decimal EncRegPres = Convert.ToDecimal(Convert.ToDecimal(txtEncRegPres.Text) / Convert.ToDecimal(txtEncRegPrev.Text));
            decimal EncRegAus = Convert.ToDecimal(Convert.ToDecimal(txtEncRegAus.Text) / Convert.ToDecimal(txtEncRegPrev.Text));

            lblPorcEncRegPrev.Text = string.Format("{0:P0}", EncRegPrev);
            lblPorcEncRegPres.Text = string.Format("{0:P0}", EncRegPres);
            lblPorcEncRegAus.Text = string.Format("{0:P0}", EncRegAus);

            //Locais
            decimal EncLocalPrev = Convert.ToDecimal(Convert.ToDecimal(txtEncLocalPrev.Text) / Convert.ToDecimal(txtEncLocalPrev.Text));
            decimal EncLocalPres = Convert.ToDecimal(Convert.ToDecimal(txtEncLocalPres.Text) / Convert.ToDecimal(txtEncLocalPrev.Text));
            decimal EncLocalAus = Convert.ToDecimal(Convert.ToDecimal(txtEncLocalAus.Text) / Convert.ToDecimal(txtEncLocalPrev.Text));

            lblPorcEncLocPrev.Text = string.Format("{0:P0}", EncLocalPrev);
            lblPorcEncLocPres.Text = string.Format("{0:P0}", EncLocalPres);
            lblPorcEncLocAus.Text = string.Format("{0:P0}", EncLocalAus);

            //Instrutores
            decimal InstrutorPrev = Convert.ToDecimal(Convert.ToDecimal(txtInstrutorPrev.Text) / Convert.ToDecimal(txtInstrutorPrev.Text));
            decimal InstrutorPres = Convert.ToDecimal(Convert.ToDecimal(txtInstrutorPres.Text) / Convert.ToDecimal(txtInstrutorPrev.Text));
            decimal InstrutorAus = Convert.ToDecimal(Convert.ToDecimal(txtInstrutorAus.Text) / Convert.ToDecimal(txtInstrutorPrev.Text));

            lblPorcInstrutorPrev.Text = string.Format("{0:P0}", InstrutorPrev);
            lblPorcInstrutorPres.Text = string.Format("{0:P0}", InstrutorPres);
            lblPorcInstrutorAus.Text = string.Format("{0:P0}", InstrutorAus);

            //Instrutoras
            decimal InstrutoraPrev = Convert.ToDecimal(Convert.ToDecimal(txtInstrutoraPrev.Text) / Convert.ToDecimal(txtInstrutoraPrev.Text));
            decimal InstrutoraPres = Convert.ToDecimal(Convert.ToDecimal(txtInstrutoraPres.Text) / Convert.ToDecimal(txtInstrutoraPrev.Text));
            decimal InstrutoraAus = Convert.ToDecimal(Convert.ToDecimal(txtInstrutoraAus.Text) / Convert.ToDecimal(txtInstrutoraPrev.Text));

            lblPorcInstrutoraPrev.Text = string.Format("{0:P0}", InstrutoraPrev);
            lblPorcInstrutoraPres.Text = string.Format("{0:P0}", InstrutoraPres);
            lblPorcInstrutoraAus.Text = string.Format("{0:P0}", InstrutoraAus);

            //Examinadoras
            decimal ExaminaPrev = Convert.ToDecimal(Convert.ToDecimal(txtExaminaPrev.Text) / Convert.ToDecimal(txtExaminaPrev.Text));
            decimal ExaminaPres = Convert.ToDecimal(Convert.ToDecimal(txtExaminaPres.Text) / Convert.ToDecimal(txtExaminaPrev.Text));
            decimal ExaminaAus = Convert.ToDecimal(Convert.ToDecimal(txtExaminaAus.Text) / Convert.ToDecimal(txtExaminaPrev.Text));

            lblPorcExaminaPrev.Text = string.Format("{0:P0}", ExaminaPrev);
            lblPorcExaminaPres.Text = string.Format("{0:P0}", ExaminaPres);
            lblPorcExaminaAus.Text = string.Format("{0:P0}", ExaminaAus);

            //Professoras
            decimal ProfPrev = Convert.ToDecimal(Convert.ToDecimal(txtProfessoraPrev.Text) / Convert.ToDecimal(txtProfessoraPrev.Text));
            decimal ProfPres = Convert.ToDecimal(Convert.ToDecimal(txtProfessoraPres.Text) / Convert.ToDecimal(txtProfessoraPrev.Text));
            decimal ProfAus = Convert.ToDecimal(Convert.ToDecimal(txtProfessoraAus.Text) / Convert.ToDecimal(txtProfessoraPrev.Text));

            lblPorcProfPrev.Text = string.Format("{0:P0}", ProfPrev);
            lblPorcProfPres.Text = string.Format("{0:P0}", ProfPres);
            lblPorcProfAus.Text = string.Format("{0:P0}", ProfAus);

            //Totais
            decimal TotalIrmaosPrev = Convert.ToDecimal(Convert.ToDecimal(txtTotalIrmaosPrev.Text) / Convert.ToDecimal(txtTotalIrmaosPrev.Text));
            decimal TotalIrmaosPres = Convert.ToDecimal(Convert.ToDecimal(txtTotalIrmaosPres.Text) / Convert.ToDecimal(txtTotalIrmaosPrev.Text));
            decimal TotalIrmaosAus = Convert.ToDecimal(Convert.ToDecimal(txtTotalIrmaosAus.Text) / Convert.ToDecimal(txtTotalIrmaosPrev.Text));
            decimal TotalIrmasPrev = Convert.ToDecimal(Convert.ToDecimal(txtTotalIrmasPrev.Text) / Convert.ToDecimal(txtTotalIrmasPrev.Text));
            decimal TotalIrmasPres = Convert.ToDecimal(Convert.ToDecimal(txtTotalIrmasPres.Text) / Convert.ToDecimal(txtTotalIrmasPrev.Text));
            decimal TotalIrmasAus = Convert.ToDecimal(Convert.ToDecimal(txtTotalIrmasAus.Text) / Convert.ToDecimal(txtTotalIrmasPrev.Text));

            lblPorcTotalIrmaosPrev.Text = string.Format("{0:P0}", TotalIrmaosPrev);
            lblPorcTotalIrmaosPres.Text = string.Format("{0:P0}", TotalIrmaosPres);
            lblPorcTotalIrmaosAus.Text = string.Format("{0:P0}", TotalIrmaosAus);
            lblPorcTotalIrmasPrev.Text = string.Format("{0:P0}", TotalIrmasPrev);
            lblPorcTotalIrmasPres.Text = string.Format("{0:P0}", TotalIrmasPres);
            lblPorcTotalIrmasAus.Text = string.Format("{0:P0}", TotalIrmasAus);

        }

        /// <summary>
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            btnFechar.Focus();
        }

        #endregion

    }
}