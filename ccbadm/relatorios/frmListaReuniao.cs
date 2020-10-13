using BLL.validacoes.Exceptions;
using ENT.administracao;
using ENT.relatorio;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ccbadm.relatorios
{
    public partial class frmListaReuniao : Form
    {
        public frmListaReuniao(Form forms, List<MOD_listaPresenca> lista, List<MOD_totalListaPresenca> listaTotal, MOD_paramRelatorio Parametro)
        {
            InitializeComponent();
            try
            {
                formulario = forms;

                rptLista.LocalReport.DataSources.Clear();
                rptLista.LocalReport.ReportEmbeddedResource = Parametro.NomeRelatorio;

                ReportDataSource ds = new ReportDataSource("bsListaPresenca", lista);
                rptLista.LocalReport.DataSources.Add(ds);
                ds.Value = lista;
                //rptLista.LocalReport.Refresh();

                ReportDataSource dst = new ReportDataSource("bsTotalPresenca", listaTotal);
                rptLista.LocalReport.DataSources.Add(dst);
                dst.Value = listaTotal;

                rptLista.SetDisplayMode(DisplayMode.PrintLayout);
                rptLista.ZoomMode = ZoomMode.Percent;
                rptLista.ZoomPercent = 150;
                rptLista.LocalReport.SetParameters(new ReportParameter("PulaPagina", string.IsNullOrEmpty(Parametro.PulaPagina) ? null : Parametro.PulaPagina));
                rptLista.LocalReport.SetParameters(new ReportParameter("RodapeRelatorio", string.IsNullOrEmpty(Parametro.RodapeRelatorio) ? null : Parametro.RodapeRelatorio));
                rptLista.LocalReport.SetParameters(new ReportParameter("Regional", string.IsNullOrEmpty(Parametro.Regional) ? null : Parametro.Regional));
                rptLista.LocalReport.SetParameters(new ReportParameter("RegionalUf", string.IsNullOrEmpty(Parametro.RegionalUf) ? null : Parametro.RegionalUf));
                rptLista.LocalReport.SetParameters(new ReportParameter("TipoRelatorio", string.IsNullOrEmpty(Parametro.TipoRelatorio) ? null : Parametro.TipoRelatorio));
                rptLista.LocalReport.SetParameters(new ReportParameter("ExibeDetalhe", string.IsNullOrEmpty(Parametro.ExibeDetalhe) ? null : Parametro.ExibeDetalhe));
                rptLista.LocalReport.SetParameters(new ReportParameter("ExibeResumo", string.IsNullOrEmpty(Parametro.ExibeResumo) ? null : Parametro.ExibeResumo));
                rptLista.LocalReport.SetParameters(new ReportParameter("ExibeAusente", string.IsNullOrEmpty(Parametro.ExibeAusente) ? null : Parametro.ExibeAusente));
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


        private void frmListaPresenca_Load(object sender, EventArgs e)
        {

        }

        private void frmListaReuniao_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.Enabled = true;
        }
    }
}
