using BLL.Funcoes;
using BLL.pessoa;
using BLL.Usuario;
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

namespace ccbrepess
{
    public partial class frmConsultaSimples : Form
    {
        public frmConsultaSimples()
        {
            InitializeComponent();

            try
            {

                //Carrega os cargos
                //preencherGrid("Cargo", string.Empty, gridCargo);
                apoio.carregaComboCargo(cboCargo, modulos.CodUsuario);
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
        string CodCargo;
        string CodComum;

        bool blnValida;
        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;

        BLL_pessoa objBLL_Pessoa;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        BLL_usuario objBLL_Usuario;
        BindingList<MOD_usuarioCCB> listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();
        List<MOD_usuarioCargo> listaCargoCCB = new List<MOD_usuarioCargo>();

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

        private void frmMixPessoa_Load(object sender, EventArgs e)
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

        private void chkMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMasculino.Checked.Equals(true))
            {
                if (chkFeminino.Checked.Equals(true))
                {
                    lblSexo.Text = "Masculino','Feminino";
                }
                else
                {
                    lblSexo.Text = "Masculino";
                }
            }
            else
            {
                if (chkFeminino.Checked.Equals(true))
                {
                    lblSexo.Text = "Feminino";
                }
                else
                {
                    lblSexo.Text = string.Empty;
                }
            }
        }
        private void chkFeminino_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFeminino.Checked.Equals(true))
            {
                if (chkMasculino.Checked.Equals(true))
                {
                    lblSexo.Text = "Masculino','Feminino";
                }
                else
                {
                    lblSexo.Text = "Feminino";
                }
            }
            else
            {
                if (chkMasculino.Checked.Equals(true))
                {
                    lblSexo.Text = "Masculino";
                }
                else
                {
                    lblSexo.Text = string.Empty;
                }
            }
        }
        private void chkSolteiro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSolteiro.Checked.Equals(true))
            {
                lblSolteiro.Text = "Solteiro(a)";
            }
            else
            {
                lblSolteiro.Text = string.Empty;
            }
            formarEstadoCivil();
        }
        private void chkViuvo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkViuvo.Checked.Equals(true))
            {
                lblViuvo.Text = "Viúvo(a)";
            }
            else
            {
                lblViuvo.Text = string.Empty;
            }
            formarEstadoCivil();
        }
        private void chkCasado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCasado.Checked.Equals(true))
            {
                lblCasado.Text = "Casado(a)";
            }
            else
            {
                lblCasado.Text = string.Empty;
            }
            formarEstadoCivil();
        }
        private void chkDivorciado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDivorciado.Checked.Equals(true))
            {
                lblDivorciado.Text = "Divorciado(a)";
            }
            else
            {
                lblDivorciado.Text = string.Empty;
            }
            formarEstadoCivil();
        }

        private void optAgruRegiao_CheckedChanged(object sender, EventArgs e)
        {
        }
        private void optAgruCidade_CheckedChanged(object sender, EventArgs e)
        {
        }

        #endregion

        #region funções privadas e publicas

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

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();

                if (string.IsNullOrEmpty(lblSexo.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Sexo.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblStatus.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Status.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(lblEstadoCivil.Text))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "É necessário selecionar um Estado Civil.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cboCargo.Text))
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
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="DataGrid"></param>
        private void abrirForm(List<MOD_pessoa> lista, string NomeRelatorio)
        {
            try
            {
                MOD_paramRelatorio Parametro = new MOD_paramRelatorio();
                Parametro.NomeRelatorio = NomeRelatorio;
                Parametro.Cargo = cboCargo.Text.ToUpper();
                Parametro.Regional = modulos.listaParametros[0].listaRegional[0].Descricao.ToUpper();
                Parametro.RegionalUf = modulos.listaParametros[0].listaRegional[0].Estado.ToUpper();
                Parametro.RodapeRelatorio = modulos.listaParametros[0].RodapeRelatorio;
                Parametro.PulaPagina = chkPulaPagina.Checked.Equals(true) ? "Sim" : "Não";
                Parametro.ExibeDetalhe = chkExibeDetalhe.Checked.Equals(true) ? "Sim" : "Não";
                formulario = new frmListaPessoa(this, lista, Parametro);
                ((frmListaPessoa)formulario).ShowDialog();
                ((frmListaPessoa)formulario).Dispose();
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
        /// Sub que forma a seleção do estado civil para pesquisar
        /// </summary>
        private void formarEstadoCivil()
        {
            string[] civil = { lblSolteiro.Text, lblCasado.Text, lblViuvo.Text, lblDivorciado.Text };
            string Codigo = string.Empty;

            lblEstadoCivil.Text = string.Empty;

            foreach (string ent in civil)
            {
                if (!string.IsNullOrEmpty(ent))
                {
                    if (string.IsNullOrEmpty(lblEstadoCivil.Text))
                    {
                        Codigo = ent;
                    }
                    else
                    {
                        Codigo = Codigo + "','" + ent;
                    }
                    lblEstadoCivil.Text = Codigo;
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
                if (ValidarControles().Equals(true))
                {
                    CodCargo = Convert.ToInt16(cboCargo.SelectedValue).ToString();
                    CodComum = modulos.CodUsuarioCCB;

                    objBLL_Pessoa = new BLL_pessoa();
                    listaPessoa = objBLL_Pessoa.buscarRelatorioPessoa(lblSexo.Text, lblEstadoCivil.Text, CodCargo, CodComum, lblStatus.Text.Equals("Sim") ? true : false);

                    List<MOD_pessoa> listaOrdem = new List<MOD_pessoa>();

                    listaOrdem = listaPessoa.OrderBy(p => p.Nome).ToList();

                    ///Listagem Agrupada pela Região
                    if (optAgruRegiao.Checked.Equals(true))
                    {
                        if (chkAgruComum.Checked.Equals(true))
                        {
                            string NomeRelatorio = "ccbrepess.relatorios.rptListaPessoa_Nome_Reg_Comum.rdlc";
                            abrirForm(listaOrdem, NomeRelatorio);
                        }
                        else
                        {
                            string NomeRelatorio = "ccbrepess.relatorios.rptListaPessoa_Nome_Reg.rdlc";
                            abrirForm(listaOrdem, NomeRelatorio);
                        }
                    }
                    ///Listagem Agrupada pela Cidade
                    else if (optAgruCidade.Checked.Equals(true))
                    {
                        if (chkAgruComum.Checked.Equals(true))
                        {
                            string NomeRelatorio = "ccbrepess.relatorios.rptListaPessoa_Nome_Cid_Comum.rdlc";
                            abrirForm(listaOrdem, NomeRelatorio);
                        }
                        else
                        {
                            string NomeRelatorio = "ccbrepess.relatorios.rptListaPessoa_Nome_Cid.rdlc";
                            abrirForm(listaOrdem, NomeRelatorio);
                        }
                    }
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