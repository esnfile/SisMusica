﻿namespace ccbreutil
{
    partial class frmListaCCB
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaCCB));
            this.bsCcb = new System.Windows.Forms.BindingSource(this.components);
            this.rptLista = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsCcb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // bsCcb
            // 
            this.bsCcb.DataSource = typeof(ENT.uteis.MOD_ccb);
            // 
            // rptLista
            // 
            this.rptLista.AutoScroll = true;
            this.rptLista.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsCcb";
            reportDataSource1.Value = this.bsCcb;
            this.rptLista.LocalReport.DataSources.Add(reportDataSource1);
            this.rptLista.LocalReport.ReportEmbeddedResource = "";
            this.rptLista.Location = new System.Drawing.Point(0, 0);
            this.rptLista.Name = "rptLista";
            this.rptLista.ServerReport.BearerToken = null;
            this.rptLista.ShowBackButton = false;
            this.rptLista.ShowContextMenu = false;
            this.rptLista.ShowCredentialPrompts = false;
            this.rptLista.ShowDocumentMapButton = false;
            this.rptLista.ShowFindControls = false;
            this.rptLista.ShowParameterPrompts = false;
            this.rptLista.ShowProgress = false;
            this.rptLista.ShowPromptAreaButton = false;
            this.rptLista.ShowRefreshButton = false;
            this.rptLista.ShowStopButton = false;
            this.rptLista.Size = new System.Drawing.Size(961, 441);
            this.rptLista.TabIndex = 0;
            this.rptLista.WaitControlDisplayAfter = 100;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.bsCcb;
            // 
            // frmListaCCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 441);
            this.Controls.Add(this.rptLista);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmListaCCB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de Comum Congregação";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListaCCB_FormClosed);
            this.Load += new System.EventHandler(this.frmListaCCB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bsCcb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer rptLista;
        private System.Windows.Forms.BindingSource bsCcb;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}