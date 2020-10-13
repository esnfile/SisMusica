using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL.validacoes.Exceptions;
using ENT.relatorio;
using ENT.uteis;
using Microsoft.Reporting.WinForms;

namespace ccbreutil
{
    public partial class frmListaCCB : Form
    {
        public frmListaCCB(Form forms, List<MOD_ccb> lista, MOD_paramRelatorio Parametro)
        {
            InitializeComponent();
            try
            {
                formulario = forms;

                bsCcb.DataSource = lista;
                //bsRegional.DataSource = modulos.listaParametros[0].listaRegional;
                rptLista.LocalReport.ReportEmbeddedResource = Parametro.NomeRelatorio;
                rptLista.SetDisplayMode(DisplayMode.PrintLayout);
                rptLista.ZoomMode = ZoomMode.Percent;
                rptLista.LocalReport.SetParameters(new ReportParameter("DataInicial", string.IsNullOrEmpty(Parametro.DataInicial) ? null : Parametro.DataInicial));
                rptLista.LocalReport.SetParameters(new ReportParameter("DataFinal", string.IsNullOrEmpty(Parametro.DataFinal) ? null : Parametro.DataFinal));
                rptLista.LocalReport.SetParameters(new ReportParameter("PulaPagina", string.IsNullOrEmpty(Parametro.PulaPagina) ? null : Parametro.PulaPagina));
                rptLista.LocalReport.SetParameters(new ReportParameter("RodapeRelatorio", string.IsNullOrEmpty(Parametro.RodapeRelatorio) ? null : Parametro.RodapeRelatorio));
                rptLista.LocalReport.SetParameters(new ReportParameter("Regional", string.IsNullOrEmpty(Parametro.Regional) ? null : Parametro.Regional));
                rptLista.LocalReport.SetParameters(new ReportParameter("RegionalUf", string.IsNullOrEmpty(Parametro.RegionalUf) ? null : Parametro.RegionalUf));
                rptLista.LocalReport.SetParameters(new ReportParameter("ExibeDetalhe", string.IsNullOrEmpty(Parametro.ExibeDetalhe) ? null : Parametro.ExibeDetalhe));
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

        private void frmListaCCB_FormClosed(object sender, FormClosedEventArgs e)
        {
            formulario.Enabled = true;
        }

        private void frmListaCCB_Load(object sender, EventArgs e)
        {
            //this.rptLista.RefreshReport();
        }
    }
}