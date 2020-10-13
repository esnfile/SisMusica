using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BLL.validacoes.Formularios
{
    public partial class carregBarra : Form
    {
        public ProgressBar pbBarra;
        public Label lblContador;
        private Panel pnlBarra;
        private Label lblmsg;

        internal int qtdeReg = 0;
        internal int regAtual = 0;
        private Button btnCancelar;
        internal string descricao = null;

        public carregBarra(int qtdeRegistro)
        {
            InitializeComponent();

            qtdeReg = qtdeRegistro;
            //define o stilo padrao do progressbar
            pbBarra.Style = ProgressBarStyle.Continuous;
            pbBarra.Value = 0;
            pbBarra.Maximum = qtdeRegistro;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(carregBarra));
            this.lblmsg = new System.Windows.Forms.Label();
            this.pbBarra = new System.Windows.Forms.ProgressBar();
            this.lblContador = new System.Windows.Forms.Label();
            this.pnlBarra = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlBarra.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(50, 13);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(124, 13);
            this.lblmsg.TabIndex = 1;
            this.lblmsg.Text = "Carregando registros ...";
            // 
            // pbBarra
            // 
            this.pbBarra.Location = new System.Drawing.Point(10, 35);
            this.pbBarra.Name = "pbBarra";
            this.pbBarra.Size = new System.Drawing.Size(208, 18);
            this.pbBarra.TabIndex = 2;
            // 
            // lblContador
            // 
            this.lblContador.Location = new System.Drawing.Point(10, 54);
            this.lblContador.Name = "lblContador";
            this.lblContador.Size = new System.Drawing.Size(208, 13);
            this.lblContador.TabIndex = 3;
            this.lblContador.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBarra
            // 
            this.pnlBarra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBarra.Controls.Add(this.lblmsg);
            this.pnlBarra.Controls.Add(this.lblContador);
            this.pnlBarra.Controls.Add(this.pbBarra);
            this.pnlBarra.Location = new System.Drawing.Point(7, 6);
            this.pnlBarra.Name = "pnlBarra";
            this.pnlBarra.Size = new System.Drawing.Size(230, 75);
            this.pnlBarra.TabIndex = 5;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(162, 84);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // carregBarra
            // 
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(241, 112);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlBarra);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "carregBarra";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aguarde...";
            this.pnlBarra.ResumeLayout(false);
            this.pnlBarra.PerformLayout();
            this.ResumeLayout(false);

        }

    }
}