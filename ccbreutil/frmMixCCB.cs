using BLL.Funcoes;
using BLL.uteis;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using ENT.Erros;
using ENT.pessoa;
using ENT.relatorio;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccbreutil
{
    public partial class frmMixCCB : Form
    {
        public frmMixCCB()
        {
            InitializeComponent();

            try
            {

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
        string CodComumPermitido;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;

        BLL_ccb objBLL_CCB;
        List<MOD_ccb> listaCCB = new List<MOD_ccb>();

        //BLL_usuario objBLL_Usuario;
        //BindingList<MOD_usuarioCCB> listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();
        //List<MOD_usuarioCargo> listaCargoCCB = new List<MOD_usuarioCargo>();

        Form formulario;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region Eventos do Formulario

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                gerarRelatorio();
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
        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMixCCB_Load(object sender, EventArgs e)
        {
            try
            {

                //funcoes.gridRegiao(gridRegiao, "VisaoOrquestral");
                //funcoes.gridCCB(gridComComum, "VisaoOrquestral");

                //verificar permissão de acesso
                //verPermVisao();
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

        private void optAgruRegiao_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void optAgruCidade_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void chkAberta_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAberta.Checked.Equals(true))
            {
                lblAberta.Text = "Aberta";
            }
            else
            {
                lblAberta.Text = string.Empty;
            }
            formarSituacao();
        }
        private void chkConstrucao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConstrucao.Checked.Equals(true))
            {
                lblConstrucao.Text = "Em Construção";
            }
            else
            {
                lblConstrucao.Text = string.Empty;
            }
            formarSituacao();
        }
        private void chkReforma_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReforma.Checked.Equals(true))
            {
                lblReforma.Text = "Em reforma";
            }
            else
            {
                lblReforma.Text = string.Empty;
            }
            formarSituacao();
        }
        private void chkFechada_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFechada.Checked.Equals(true))
            {
                lblFechada.Text = "Fechada";
            }
            else
            {
                lblFechada.Text = string.Empty;
            }
            formarSituacao();
        }

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(List<MOD_ccb> lista, string NomeRelatorio)
        {
            try
            {
                MOD_paramRelatorio Parametro = new MOD_paramRelatorio();
                Parametro.NomeRelatorio = NomeRelatorio;
                Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                Parametro.RodapeRelatorio = modulos.listaParametros[0].RodapeRelatorio;
                Parametro.PulaPagina = chkPulaPagina.Checked.Equals(true) ? "Sim" : "Não";
                Parametro.ExibeDetalhe = chkExibeDetalhe.Checked.Equals(true) ? "Sim" : "Não";
                formulario = new frmListaCCB(this, lista, Parametro);
                ((frmListaCCB)formulario).ShowDialog();
                ((frmListaCCB)formulario).Dispose();
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
        /// Sub que forma a seleção do situação para pesquisar
        /// </summary>
        private void formarSituacao()
        {
            string[] situacao = { lblAberta.Text, lblConstrucao.Text, lblReforma.Text, lblFechada.Text };
            string Codigo = string.Empty;

            lblSituacao.Text = string.Empty;

            foreach (string ent in situacao)
            {
                if (!string.IsNullOrEmpty(ent))
                {
                    if (string.IsNullOrEmpty(lblSituacao.Text))
                    {
                        Codigo = ent;
                    }
                    else
                    {
                        Codigo = Codigo + "','" + ent;
                    }
                    lblSituacao.Text = Codigo;
                }
            }
        }

        #region Gerar dados para relatorio

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void gerarRelatorio()
        {
            try
            {
                CodComumPermitido = modulos.CodUsuarioCCB;

                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarRelatorioCCB(lblSituacao.Text, txtDataInicial.Text, txtDataFinal.Text);

                List<MOD_ccb> listaOrdem = new List<MOD_ccb>();

                if (optOrdemCodigo.Checked.Equals(true))
                {
                    listaOrdem = listaCCB.OrderBy(c => c.Codigo).ToList();
                }
                else
                {
                    listaOrdem = listaCCB.OrderBy(c => c.Descricao).ToList();
                }

                ///Listagem Agrupada pela Região
                if (optAgruRegiao.Checked.Equals(true))
                {
                    string NomeRelatorio = "ccbreutil.relatorios.CCB.rptLista_CCB_Reg.rdlc";
                    abrirForm(listaOrdem, NomeRelatorio);
                }
                ///Listagem Agrupada pela Cidade
                else if (optAgruCidade.Checked.Equals(true))
                {
                    string NomeRelatorio = "ccbreutil.relatorios.CCB.rptLista_CCB_Cid.rdlc";
                    abrirForm(listaOrdem, NomeRelatorio);
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

        #endregion

        #endregion

    }
}