using System;
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
using BLL.validacoes.Exceptions;
using ENT.pessoa;
using ENT.relatorio;
using ENT.uteis;
using Microsoft.Reporting.WinForms;

namespace ccbpessrs
{
    public partial class frmListaPessoaSint : Form
    {
        public frmListaPessoaSint(Form forms, List<MOD_pessoa> lista, MOD_paramRelatorio Parametro)
        {
            InitializeComponent();
            try
            {
                formulario = forms;

                bsPessoa.DataSource = lista;
                //bsRegional.DataSource = modulos.listaParametros[0].listaRegional;
                rptLista.LocalReport.ReportEmbeddedResource = Parametro.NomeRelatorio;
                rptLista.SetDisplayMode(DisplayMode.PrintLayout);
                rptLista.ZoomMode = ZoomMode.Percent;
                rptLista.LocalReport.SetParameters(new ReportParameter("DataInicial", Parametro.DataInicial));
                rptLista.LocalReport.SetParameters(new ReportParameter("DataFinal", Parametro.DataFinal));
                rptLista.LocalReport.SetParameters(new ReportParameter("TipoData", Parametro.TipoData));
                rptLista.LocalReport.SetParameters(new ReportParameter("PulaPagina", Parametro.PulaPagina));
                rptLista.LocalReport.SetParameters(new ReportParameter("RodapeRelatorio", Parametro.RodapeRelatorio));
                rptLista.LocalReport.SetParameters(new ReportParameter("Regional", Parametro.Regional));
                rptLista.LocalReport.SetParameters(new ReportParameter("RegionalUf", Parametro.RegionalUf));
                rptLista.LocalReport.SetParameters(new ReportParameter("ExibeDetalhe", Parametro.ExibeDetalhe));
                rptLista.RefreshReport();
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

        #region Declarações

        Form formulario;
        //instancias de validacoes
        clsException excp;

        #endregion

        private void frmListaPessoa_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.Enabled = true;
        }

        private void frmListaPessoa_Load(object sender, EventArgs e)
        {
            //this.rptLista.RefreshReport();
        }
    }
}