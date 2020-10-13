using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Threading;
using System.Deployment.Application;

using BLL.Funcoes;
using ccbinst;
using ccbpess;
using ccbtest;
using ccbutil;
using ENT.acessos;
using BLL.acessos;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using ccbusua;
using ccborq;
using ccbimp;
using ccbrepess;
using ccbaju;
using ENT.instrumentos;
using ENT.pessoa;
using ENT.preTeste;
using ENT.uteis;
using BLL.uteis;
using ENT.administracao;
using ccbadm;
using ccbreutil;
using ccbexp;

namespace ccbprinc
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;

                apoio.CarregaAcessosUsuario(modulos.CodUsuario);
                lblStUsuario.Text = "Usuário: " + modulos.CodUsuario.PadLeft(6, '0') + " - " + modulos.Usuario.ToUpper();
                lblStRegional.Text = "Regional: " + modulos.CodRegional.PadLeft(3, '0') + " - " + modulos.CodigoRegional.ToUpper() + " - " + modulos.DescRegional.ToUpper();
                lblStData.Text = "Data: " + funcoes.FormataData(DateTime.Now.ToString("dd/MM/yyyy"));
                lblStVersao.Text = buscarVersao();
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
        public string GetVersion()
        {
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version ver;
                ver = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                return String.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
            else
            {
                return "Não informado";
            }
        }

        #region declarações

        //instancias de validacoes
        clsException excp;
        MdiClient mdiClient = null;

        List<MOD_acessos> listaAcesso = null;
        BLL_acessos objBLL_Acesso = null;

        List<MOD_versao> listaVersao = null;
        BLL_versao objBLL_Versao = null;

        #endregion  

        #region Eventos do formulario

        private void principal_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c is MdiClient)
                    {
                        mdiClient = (MdiClient)c;
                    }
                }
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                foreach (Form filho in this.MdiChildren)
                {
                    if (filho.Enabled.Equals(true))
                    {
                        MessageBox.Show("Para encerramento do sistema é necessário " + '\n' +
                                        "que todas as janelas estejam fechadas.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        e.Cancel = true;
                        return;
                    }
                }
                DialogResult res = MessageBox.Show("Confirma o encerramento do sistema", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                e.Cancel = (!res.Equals(DialogResult.Yes));

#warning Fazer execução backup automatico
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
        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion

        #region Eventos Instrumentos

        private void mnuTabInstrEscala_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoEscala = new List<MOD_acessos>();
                MOD_acessoEscala entAcesso = new MOD_acessoEscala();
                listaAcessoEscala = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progEscala)).ToList();

                if (listaAcessoEscala.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmEscalaBusca formEscala = new frmEscalaBusca(listaAcessoEscala);
                    CheckForm(formEscala);
                    formEscala.defineFoco();
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
        private void mnuTabInstrFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoFamilia = new List<MOD_acessos>();
                listaAcessoFamilia = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progFamilia)).ToList();

                if (listaAcessoFamilia.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmFamiliaBusca formFamilia = new frmFamiliaBusca(listaAcessoFamilia);
                    CheckForm(formFamilia);
                    formFamilia.defineFoco();
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
        private void mnuTabInstrTonal_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoTonalidade = new List<MOD_acessos>();
                listaAcessoTonalidade = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progTonalidade)).ToList();

                if (listaAcessoTonalidade.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmTonalidadeBusca formTonalidade = new frmTonalidadeBusca(listaAcessoTonalidade);
                    CheckForm(formTonalidade);
                    formTonalidade.defineFoco();
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
        private void mnuTabInstrHino_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoHinario = new List<MOD_acessos>();
                listaAcessoHinario = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progHinario)).ToList();

                if (listaAcessoHinario.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmHinarioBusca formHino = new frmHinarioBusca(listaAcessoHinario);
                    CheckForm(formHino);
                    formHino.defineFoco();
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
        private void mnuTabInstrVozes_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoVoz = new List<MOD_acessos>();
                listaAcessoVoz = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progVoz)).ToList();

                if (listaAcessoVoz.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmVozesBusca formVoz = new frmVozesBusca(listaAcessoVoz);
                    CheckForm(formVoz);
                    formVoz.defineFoco();
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
        private void subMnuTeoria_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoTeoria = new List<MOD_acessos>();
                listaAcessoTeoria = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progTeoria)).ToList();

                if (listaAcessoTeoria.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmTeoriaBusca formTeoria = new frmTeoriaBusca(listaAcessoTeoria);
                    CheckForm(formTeoria);
                    formTeoria.defineFoco();
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
        private void subMnuFaseMts_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoFaseMts = new List<MOD_acessos>();
                listaAcessoFaseMts = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progMtsFase)).ToList();

                if (listaAcessoFaseMts.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmMtsFaseBusca formFase = new frmMtsFaseBusca(listaAcessoFaseMts);
                    CheckForm(formFase);
                    formFase.defineFoco();
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
        private void subMnuModuloMts_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoModuloMts = new List<MOD_acessos>();
                listaAcessoModuloMts = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progMtsModulo)).ToList();

                if (listaAcessoModuloMts.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmMtsModuloBusca formMod = new frmMtsModuloBusca(listaAcessoModuloMts);
                    CheckForm(formMod);
                    formMod.defineFoco();
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
        private void mnuInstr_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoInstr = new List<MOD_acessos>();
                listaAcessoInstr = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progInstrumento)).ToList();

                if (listaAcessoInstr.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmInstrBusca formInstr = new frmInstrBusca(listaAcessoInstr);
                    CheckForm(formInstr);
                    formInstr.defineFoco();
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
        private void subMnuMetodo_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoMet = new List<MOD_acessos>();
                MOD_acessoMetodo entAcesso = new MOD_acessoMetodo();
                listaAcessoMet = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progMetodo)).ToList();

                if (listaAcessoMet.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmMetodoBusca formMet = new frmMetodoBusca(listaAcessoMet);
                    CheckForm(formMet);
                    formMet.defineFoco();
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
        private void mnuConfInstrMet_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoMetInstr = new List<MOD_acessos>();
                MOD_acessoMetodoInstr entAcesso = new MOD_acessoMetodoInstr();
                listaAcessoMetInstr = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progMetodoInstr)).ToList();

                if (listaAcessoMetInstr.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmMetodoInstr formMetInstr = new frmMetodoInstr(listaAcessoMetInstr);
                    CheckForm(formMetInstr);
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

        #region Eventos Utilitários

        private void mnuTabUtilPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoPessoa = new List<MOD_acessos>();
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                listaAcessoPessoa = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progPessoa)).ToList();

                if (listaAcessoPessoa.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmPessoaBusca formPessoa = new frmPessoaBusca(listaAcessoPessoa);
                    CheckForm(formPessoa);
                    formPessoa.defineFoco();
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
        private void mnuTabUtilComum_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoComum = new List<MOD_acessos>();
                listaAcessoComum = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progComum)).ToList();

                if (listaAcessoComum.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmCCBBusca formComum = new frmCCBBusca(listaAcessoComum, this, string.Empty);
                    CheckForm(formComum);
                    formComum.defineFoco();
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
        private void mnuTabUtilRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoRegiao = new List<MOD_acessos>();
                listaAcessoRegiao = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progRegiao)).ToList();

                if (listaAcessoRegiao.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmRegiaoBusca formRegiao = new frmRegiaoBusca(listaAcessoRegiao);
                    CheckForm(formRegiao);
                    formRegiao.defineFoco();
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
        private void mnuTabUtilRegional_Click(object sender, EventArgs e)
        {
            try {
                List<MOD_acessos> listaAcessoRegional = new List<MOD_acessos>();
                MOD_acessoRegional entAcesso = new MOD_acessoRegional();
                listaAcessoRegional = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progRegional)).ToList();

                if (listaAcessoRegional.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmRegionalBusca formRegional = new frmRegionalBusca(listaAcessoRegional);
                    CheckForm(formRegional);
                    formRegional.defineFoco();
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
        private void mnuTabUtilCidade_Click(object sender, EventArgs e)
        {
            try {
                List<MOD_acessos> listaAcessoCidade = new List<MOD_acessos>();
                MOD_acessoCidade entAcesso = new MOD_acessoCidade();
                listaAcessoCidade = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progCidade)).ToList();

                if (listaAcessoCidade.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmCidadeBusca formCidade = new frmCidadeBusca(listaAcessoCidade);
                    CheckForm(formCidade);
                    formCidade.defineFoco();
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
        private void mnuTabUtilCargo_Click(object sender, EventArgs e)
        {
            try {
                List<MOD_acessos> listaAcessoCargo = new List<MOD_acessos>();
                MOD_acessoCargo entAcesso = new MOD_acessoCargo();
                listaAcessoCargo = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progCargo)).ToList();

                if (listaAcessoCargo.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmCargoBusca formCargo = new frmCargoBusca(listaAcessoCargo);
                    CheckForm(formCargo);
                    formCargo.defineFoco();
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
        private void mnuTabUtilDepart_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoDepart = new List<MOD_acessos>();
                MOD_acessoDepartamento entAcesso = new MOD_acessoDepartamento();
                listaAcessoDepart = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progDepartamento)).ToList();

                if (listaAcessoDepart.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmDepartamentoBusca formDepart = new frmDepartamentoBusca(listaAcessoDepart);
                    CheckForm(formDepart);
                    formDepart.defineFoco();
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

        private void mnuRelUtilPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoRelPes = new List<MOD_acessos>();
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                listaAcessoRelPes = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodRotina).Equals(entAcesso.rotPesMixRelatorio)).ToList();

                if (listaAcessoRelPes.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmMixPessoa formMixPessoa = new frmMixPessoa();
                    CheckForm(formMixPessoa);
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
        private void mnuRelUtilPessoaMinis_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoRelPes = new List<MOD_acessos>();
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                listaAcessoRelPes = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodRotina).Equals(entAcesso.rotPesRelMinisterio)).ToList();

                if (listaAcessoRelPes.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmConsultaSimples formConsPessoa = new frmConsultaSimples();
                    CheckForm(formConsPessoa);
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
        private void mnuRelUtilPessoaVisaoGeral_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoRelVisaoGeral = new List<MOD_acessos>();
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                listaAcessoRelVisaoGeral = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodRotina).Equals(entAcesso.rotPesRelVisaoGeral)).ToList();

                if (listaAcessoRelVisaoGeral.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmAnalisePessoa formAnalisePessoa = new frmAnalisePessoa();
                    CheckForm(formAnalisePessoa);
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
        private void mnuRelUtilCCB_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoRelCCB = new List<MOD_acessos>();
                MOD_acessoCcb entAcesso = new MOD_acessoCcb();
                listaAcessoRelCCB = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodRotina).Equals(entAcesso.rotCCBMixRelatorio)).ToList();

                if (listaAcessoRelCCB.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmMixCCB formMixCCB = new frmMixCCB();
                    CheckForm(formMixCCB);
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
        private void mnuRelUtilPessoaFichaCadastral_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoRelFicha = new List<MOD_acessos>();
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                listaAcessoRelFicha = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodRotina).Equals(entAcesso.rotPesRelFichaCadastral)).ToList();

                if (listaAcessoRelFicha.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmFichaCadastral formFichaCadastral = new frmFichaCadastral();
                    CheckForm(formFichaCadastral);
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

        #region Eventos Testes e Pretestes

        private void mnuConfExameAval_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoLicaoTeste = new List<MOD_acessos>();
                listaAcessoLicaoTeste = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progLicaoTeste)).ToList();

                if (listaAcessoLicaoTeste.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmLicaoTeste formLicaoTeste = new frmLicaoTeste(listaAcessoLicaoTeste);
                    CheckForm(formLicaoTeste);
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
        private void mnuConfTesteAvalInstr_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoLicaoTesteInstr = new List<MOD_acessos>();
                listaAcessoLicaoTesteInstr = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progLicaoPreTeste)).ToList();

                if (listaAcessoLicaoTesteInstr.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmMetodoTeste formMetodoTeste = new frmMetodoTeste(listaAcessoLicaoTesteInstr);
                    CheckForm(formMetodoTeste);
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
        private void mnuPreTeste_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoPreTeste = new List<MOD_acessos>();
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();
                listaAcessoPreTeste = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progPreTeste)).ToList();

                if (listaAcessoPreTeste.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmPreTesteBusca formPreTeste = new frmPreTesteBusca(listaAcessoPreTeste);
                    CheckForm(formPreTeste);
                    formPreTeste.defineFoco();
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
        private void mnuSolicitaPreTeste_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoLicaoSolicita = new List<MOD_acessos>();
                MOD_acessoSolicitaTeste entAcesso = new MOD_acessoSolicitaTeste();
                listaAcessoLicaoSolicita = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progSolicitaTeste)).ToList();

                if (listaAcessoLicaoSolicita.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmSolicitaTesteBusca formSolicita = new frmSolicitaTesteBusca(listaAcessoLicaoSolicita);
                    CheckForm(formSolicita);
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
        private void mnuConfTesteAvalTeoria_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoLicaTesteTeoria = new List<MOD_acessos>();
                listaAcessoLicaTesteTeoria = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progLicaoPreTeste)).ToList();

                if (listaAcessoLicaTesteTeoria.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmLicaoTeste formLicaoTeste = new frmLicaoTeste(listaAcessoLicaTesteTeoria);
                    CheckForm(formLicaoTeste);
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

        #region Eventos GerSys

        private void mnuGerUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoUsuario = new List<MOD_acessos>();
                listaAcessoUsuario = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progUsuario)).ToList();

                if (listaAcessoUsuario.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmUsuarioBusca formUsuario = new frmUsuarioBusca(listaAcessoUsuario);
                    CheckForm(formUsuario);
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
        private void mnuModProg_Click(object sender, EventArgs e)
        {
            try
            {
                int CodUsuario = Convert.ToInt32(modulos.CodUsuario);
                if (!CodUsuario.Equals(1))
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmModProg formProg = new frmModProg(this, modulos.listaLibAcesso);
                    CheckForm(formProg);
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

        #region Eventos Configurações

        private void mnuImportarPessoas_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoImpPessoa = new List<MOD_acessos>();
                listaAcessoImpPessoa = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progImportaPessoa)).ToList();

                if (listaAcessoImpPessoa.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmImportarPessoa formImport = new frmImportarPessoa(listaAcessoImpPessoa);
                    CheckForm(formImport);
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
        private void mnuImportaPessoaErro_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoImpPessoa = new List<MOD_acessos>();
                listaAcessoImpPessoa = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progImportaPessoa)).ToList();

                if (listaAcessoImpPessoa.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmImportarPessoaErros formImport = new frmImportarPessoaErros(listaAcessoImpPessoa);
                    CheckForm(formImport);
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
        private void mnuImportaPessoaSucesso_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoImpPessoa = new List<MOD_acessos>();
                listaAcessoImpPessoa = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progImportaPessoa)).ToList();

                if (listaAcessoImpPessoa.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmImportarPessoaBusca formImport = new frmImportarPessoaBusca(listaAcessoImpPessoa);
                    CheckForm(formImport);
                    formImport.defineFoco();
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
        private void mnuExportaPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                //List<MOD_acessos> listaAcessoImpPessoa = new List<MOD_acessos>();
                //listaAcessoImpPessoa = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progImportaPessoa)).ToList();

                //if (listaAcessoImpPessoa.Count < 1)
                //{
                //    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //}
                //else
                //{
                frmExpPessoa formExport = new frmExpPessoa();
                CheckForm(formExport);
                //}
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

        #region Eventos Administração

        private void mnuReuniaoMinisterial_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoReunMin = new List<MOD_acessos>();
                MOD_acessoReuniao entAcesso = new MOD_acessoReuniao();
                listaAcessoReunMin = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progReuniaoMinisterio)).ToList();

                if (listaAcessoReunMin.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmReunioesBusca formReuniao = new frmReunioesBusca(listaAcessoReunMin);
                    CheckForm(formReuniao);
                    formReuniao.defineFoco();
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
        private void mnuTabTipoReuniaoAdm_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoTipoReun = new List<MOD_acessos>();
                MOD_acessoTipoReuniao entAcesso = new MOD_acessoTipoReuniao();
                listaAcessoTipoReun = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progTipoReuniao)).ToList();

                if (listaAcessoTipoReun.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmTipoReuniaoBusca formTipoReuniao = new frmTipoReuniaoBusca(listaAcessoTipoReun);
                    CheckForm(formTipoReuniao);
                    formTipoReuniao.defineFoco();
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

        #region Eventos Orquestra

        private void mnuVisaoAmplaOrquestra_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoVisao = new List<MOD_acessos>();
                listaAcessoVisao = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progVisaoOrq)).ToList();

                if (listaAcessoVisao.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmVisaoOrquestra formVisaoOrquestra = new frmVisaoOrquestra(listaAcessoVisao);
                    CheckForm(formVisaoOrquestra);
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

        #region Eventos Ajuda

        private void mnuAjudaNovidades_Click(object sender, EventArgs e)
        {
            try
            {
                frmNovidadeBusca formNovidadeBusca = new frmNovidadeBusca();
                CheckForm(formNovidadeBusca);
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

        #region abrir formularios

        private void CheckForm(Form form)
        {
            try
            {
                foreach (Control c in Controls)
                {
                    if (c is MdiClient)
                    {
                        mdiClient = c as MdiClient;
                        break;
                    }
                }
                if (form != null)
                {
                    foreach (Form frm in MdiChildren)
                    {
                        if (frm.GetType().Equals(form.GetType()))
                        {
                            if (frm.Enabled.Equals(true))
                            {
                                frm.Focus();
                            }
                            return;
                        }
                    }
                    form.MdiParent = this;
                    //form.FormBorderStyle = FormBorderStyle.FixedSingle;
                    //form.TopLevel = false;
                    //form.Dock = DockStyle.None;
                    //pnlPrincipal.Controls.Add(form);
                    //apoio.CentralizarForm(form);
                    form.Show();
                    form.Activate();
                }
                form.BringToFront();
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

        #region Eventos Botoes de Atalhos

        private void btnInstrumento_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoInstr = new List<MOD_acessos>();
                listaAcessoInstr = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progInstrumento)).ToList();

                if (listaAcessoInstr.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmInstrBusca formInstr = new frmInstrBusca(listaAcessoInstr);
                    CheckForm(formInstr);
                    formInstr.defineFoco();
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
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoPessoa = new List<MOD_acessos>();
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                listaAcessoPessoa = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progPessoa)).ToList();

                if (listaAcessoPessoa.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmPessoaBusca formPessoa = new frmPessoaBusca(listaAcessoPessoa);
                    CheckForm(formPessoa);
                    formPessoa.defineFoco();
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
        private void btnPreTeste_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoPreTeste = new List<MOD_acessos>();
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();
                listaAcessoPreTeste = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(entAcesso.progPreTeste)).ToList();

                if (listaAcessoPreTeste.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmPreTesteBusca formPreTeste = new frmPreTesteBusca(listaAcessoPreTeste);
                    CheckForm(formPreTeste);
                    formPreTeste.defineFoco();
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
        private void btnComum_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoComum = new List<MOD_acessos>();
                listaAcessoComum = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progComum)).ToList();

                if (listaAcessoComum.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmCCBBusca formComum = new frmCCBBusca(listaAcessoComum, this, string.Empty);
                    CheckForm(formComum);
                    formComum.defineFoco();
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
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                List<MOD_acessos> listaAcessoUsuario = new List<MOD_acessos>();
                listaAcessoUsuario = modulos.listaLibAcesso.Where(x => Convert.ToInt32(x.CodPrograma).Equals(modulos.progUsuario)).ToList();

                if (listaAcessoUsuario.Count < 1)
                {
                    MessageBox.Show(modulos.semAcesso, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    frmUsuarioBusca formUsuario = new frmUsuarioBusca(listaAcessoUsuario);
                    CheckForm(formUsuario);
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
        private void btnSair_Click(object sender, EventArgs e)
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

        #endregion

        #region Funções

        private string buscarVersao()
        {
            try
            {
                string VersaoAtual = string.Empty;
                objBLL_Versao = new BLL_versao();
                listaVersao = new List<MOD_versao>();

                listaVersao = objBLL_Versao.buscarUltVersao();

                if (listaVersao != null && listaVersao.Count > 0)
                {
                    VersaoAtual = "Versão: " + listaVersao[0].VersaoPrincipal + "." +
                                               listaVersao[0].VersaoSecundaria + "." +
                                               listaVersao[0].NumeroVersao + "." +
                                               listaVersao[0].Revisao;
                }

                return VersaoAtual;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            string usuarioLogado = Environment.UserName;
            string folderName = @"C://Users//" + usuarioLogado + "//AppData//Local//SistemaCCB";

            if (!File.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }


            //Verifica se o arquivo existe na pasta de destino
            if (File.Exists(folderName + "\arquivo.txt"))
            {
                Process.Start(folderName + "\arquivo.txt");
            }

            //folderName = Path.Combine(folderName, ");
            //File.WriteAllLines(folderName, COD_MATERIAL);
        }

        public static void ProcurarArquivo(DirectoryInfo dir, String target)
        {
            FileInfo[] arquivos = dir.GetFiles();
            foreach (FileInfo file in arquivos)
            {
                if (file.Name.IndexOf(target) > -1)
                {
                    Console.WriteLine(file.Name);
                }
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (DirectoryInfo subDir in dirs)
            {
                ProcurarArquivo(subDir, target);
            }
        }

        static void ProcuraDir(string[] args)
        {
            String procurarNome = "ccbprinc";
            DirectoryInfo diretorio = new DirectoryInfo(@"c: emp");
            ProcurarArquivo(diretorio, procurarNome);
        }

    }
}
