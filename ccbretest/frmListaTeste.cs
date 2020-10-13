using BLL.validacoes.Exceptions;
using ENT.preTeste;
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


namespace ccbretest
{
    public partial class frmListaTeste : Form
    {
        public frmListaTeste(Form forms, List<MOD_preTesteFicha> lista, BindingList<MOD_preTesteMet> listaMetodo,
                                         BindingList<MOD_preTesteMts> listaMts, BindingList<MOD_preTesteHino> listaHinario,
                                         BindingList<MOD_preTesteTeoria> listaTeoria, BindingList<MOD_preTesteEscala> listaEscala, 
                                         MOD_paramRelatorio Parametro)
        {
            InitializeComponent();
            try
            {
                formulario = forms;

                rptLista.LocalReport.DataSources.Clear();
                rptLista.LocalReport.ReportEmbeddedResource = Parametro.NomeRelatorio;

                ReportDataSource ds = new ReportDataSource("dsFicha", lista);
                rptLista.LocalReport.DataSources.Add(ds);
                ds.Value = lista;
                //rptLista.LocalReport.Refresh();

                //Lista de Metodos
                ReportDataSource dsmet = new ReportDataSource("dsMet", listaMetodo);
                rptLista.LocalReport.DataSources.Add(dsmet);
                dsmet.Value = listaMetodo;

                //Lista de Mts
                ReportDataSource dsmts = new ReportDataSource("dsMts", listaMts);
                rptLista.LocalReport.DataSources.Add(dsmts);
                dsmts.Value = listaMts;

                //Lista de Hinario
                ReportDataSource dshino = new ReportDataSource("dsHino", listaHinario);
                rptLista.LocalReport.DataSources.Add(dshino);
                dshino.Value = listaHinario;

                //Lista de Escala
                ReportDataSource dsEsc = new ReportDataSource("dsEscala", listaEscala);
                rptLista.LocalReport.DataSources.Add(dsEsc);
                dsEsc.Value = listaEscala;

                //Lista de Teoria
                ReportDataSource dsTeo = new ReportDataSource("dsTeoria", listaTeoria);
                rptLista.LocalReport.DataSources.Add(dsTeo);
                dsTeo.Value = listaTeoria;

                rptLista.SetDisplayMode(DisplayMode.PrintLayout);
                rptLista.ZoomMode = ZoomMode.Percent;
                rptLista.ZoomPercent = 150;
                rptLista.LocalReport.SetParameters(new ReportParameter("RodapeRelatorio", string.IsNullOrEmpty(Parametro.RodapeRelatorio) ? null : Parametro.RodapeRelatorio));
                rptLista.LocalReport.SetParameters(new ReportParameter("Regional", string.IsNullOrEmpty(Parametro.Regional) ? null : Parametro.Regional));
                rptLista.LocalReport.SetParameters(new ReportParameter("RegionalUf", string.IsNullOrEmpty(Parametro.RegionalUf) ? null : Parametro.RegionalUf));
                rptLista.LocalReport.SetParameters(new ReportParameter("QtdeSolfejo", string.IsNullOrEmpty(Parametro.QtdeSolfejo) ? null : Parametro.QtdeSolfejo));
                rptLista.LocalReport.SetParameters(new ReportParameter("QtdeRitmo", string.IsNullOrEmpty(Parametro.QtdeRitmo) ? null : Parametro.QtdeRitmo));
                rptLista.LocalReport.SetParameters(new ReportParameter("QtdeMetodo", string.IsNullOrEmpty(Parametro.QtdeMetodo) ? null : Parametro.QtdeMetodo));
                rptLista.LocalReport.SetParameters(new ReportParameter("QtdeHino", string.IsNullOrEmpty(Parametro.QtdeHino) ? null : Parametro.QtdeHino));
                rptLista.LocalReport.SetParameters(new ReportParameter("QtdeEscala", string.IsNullOrEmpty(Parametro.QtdeEscala) ? null : Parametro.QtdeEscala));
                rptLista.LocalReport.SetParameters(new ReportParameter("QtdeTeoria", string.IsNullOrEmpty(Parametro.QtdeTeoria) ? null : Parametro.QtdeTeoria));
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
