namespace ccbutil
{
    partial class frmVersao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVersao));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipVersao = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pnlVersao = new System.Windows.Forms.Panel();
            this.cboTipo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblTipo = new System.Windows.Forms.Label();
            this.gpoVersao = new System.Windows.Forms.GroupBox();
            this.txtRevisao = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.lblRevisao = new System.Windows.Forms.Label();
            this.txtVersao = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.lblVersao = new System.Windows.Forms.Label();
            this.txtSecundaria = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.lblSecundaria = new System.Windows.Forms.Label();
            this.txtPrincipal = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.lblPrincipal = new System.Windows.Forms.Label();
            this.txtHora = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtData = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblData = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlVersao.SuspendLayout();
            this.gpoVersao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevisao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecundaria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(302, 134);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipVersao.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(397, 134);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipVersao.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(58, 17);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(50, 21);
            this.txtCodigo.TabIndex = 106;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipVersao.SetToolTip(this.txtCodigo, "Código");
            // 
            // pnlVersao
            // 
            this.pnlVersao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlVersao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVersao.Controls.Add(this.cboTipo);
            this.pnlVersao.Controls.Add(this.lblTipo);
            this.pnlVersao.Controls.Add(this.gpoVersao);
            this.pnlVersao.Controls.Add(this.txtHora);
            this.pnlVersao.Controls.Add(this.txtData);
            this.pnlVersao.Controls.Add(this.lblData);
            this.pnlVersao.Controls.Add(this.txtCodigo);
            this.pnlVersao.Controls.Add(this.lblCodigo);
            this.pnlVersao.Location = new System.Drawing.Point(9, 9);
            this.pnlVersao.Name = "pnlVersao";
            this.pnlVersao.Size = new System.Drawing.Size(476, 121);
            this.pnlVersao.TabIndex = 5;
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Módulos",
            "Sistema"});
            this.cboTipo.Location = new System.Drawing.Point(345, 17);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(121, 21);
            this.cboTipo.TabIndex = 117;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTipo.Location = new System.Drawing.Point(312, 21);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 116;
            this.lblTipo.Text = "Tipo:";
            // 
            // gpoVersao
            // 
            this.gpoVersao.Controls.Add(this.txtRevisao);
            this.gpoVersao.Controls.Add(this.lblRevisao);
            this.gpoVersao.Controls.Add(this.txtVersao);
            this.gpoVersao.Controls.Add(this.lblVersao);
            this.gpoVersao.Controls.Add(this.txtSecundaria);
            this.gpoVersao.Controls.Add(this.lblSecundaria);
            this.gpoVersao.Controls.Add(this.txtPrincipal);
            this.gpoVersao.Controls.Add(this.lblPrincipal);
            this.gpoVersao.Location = new System.Drawing.Point(9, 48);
            this.gpoVersao.Name = "gpoVersao";
            this.gpoVersao.Size = new System.Drawing.Size(457, 54);
            this.gpoVersao.TabIndex = 115;
            this.gpoVersao.TabStop = false;
            this.gpoVersao.Text = "Versão a ser disponibilizada";
            // 
            // txtRevisao
            // 
            this.txtRevisao.BackColor = System.Drawing.Color.White;
            this.txtRevisao.Location = new System.Drawing.Point(404, 21);
            this.txtRevisao.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtRevisao.Name = "txtRevisao";
            this.txtRevisao.Size = new System.Drawing.Size(46, 21);
            this.txtRevisao.TabIndex = 114;
            this.txtRevisao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblRevisao
            // 
            this.lblRevisao.AutoSize = true;
            this.lblRevisao.Location = new System.Drawing.Point(358, 25);
            this.lblRevisao.Name = "lblRevisao";
            this.lblRevisao.Size = new System.Drawing.Size(49, 13);
            this.lblRevisao.TabIndex = 115;
            this.lblRevisao.Text = "Revisão:";
            // 
            // txtVersao
            // 
            this.txtVersao.BackColor = System.Drawing.Color.White;
            this.txtVersao.Location = new System.Drawing.Point(306, 21);
            this.txtVersao.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtVersao.Name = "txtVersao";
            this.txtVersao.Size = new System.Drawing.Size(46, 21);
            this.txtVersao.TabIndex = 112;
            this.txtVersao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(250, 25);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(59, 13);
            this.lblVersao.TabIndex = 113;
            this.lblVersao.Text = "Nº Versão:";
            // 
            // txtSecundaria
            // 
            this.txtSecundaria.BackColor = System.Drawing.Color.White;
            this.txtSecundaria.Location = new System.Drawing.Point(194, 21);
            this.txtSecundaria.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtSecundaria.Name = "txtSecundaria";
            this.txtSecundaria.Size = new System.Drawing.Size(46, 21);
            this.txtSecundaria.TabIndex = 110;
            this.txtSecundaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSecundaria
            // 
            this.lblSecundaria.AutoSize = true;
            this.lblSecundaria.Location = new System.Drawing.Point(120, 25);
            this.lblSecundaria.Name = "lblSecundaria";
            this.lblSecundaria.Size = new System.Drawing.Size(77, 13);
            this.lblSecundaria.TabIndex = 111;
            this.lblSecundaria.Text = "V. Secundária:";
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.BackColor = System.Drawing.Color.White;
            this.txtPrincipal.Location = new System.Drawing.Point(67, 21);
            this.txtPrincipal.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.Size = new System.Drawing.Size(46, 21);
            this.txtPrincipal.TabIndex = 108;
            this.txtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPrincipal
            // 
            this.lblPrincipal.AutoSize = true;
            this.lblPrincipal.Location = new System.Drawing.Point(7, 25);
            this.lblPrincipal.Name = "lblPrincipal";
            this.lblPrincipal.Size = new System.Drawing.Size(63, 13);
            this.lblPrincipal.TabIndex = 109;
            this.lblPrincipal.Text = "V. Principal:";
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.Color.LightGray;
            this.txtHora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHora.Location = new System.Drawing.Point(254, 17);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(43, 21);
            this.txtHora.TabIndex = 114;
            this.txtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHora.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.LightGray;
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtData.Location = new System.Drawing.Point(164, 17);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(85, 21);
            this.txtData.TabIndex = 112;
            this.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtData.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblData.Location = new System.Drawing.Point(126, 21);
            this.lblData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(34, 13);
            this.lblData.TabIndex = 111;
            this.lblData.Text = "Data:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(12, 21);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // frmVersao
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(497, 172);
            this.Controls.Add(this.pnlVersao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVersao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Versões";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVersao_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVersao_FormClosed);
            this.Load += new System.EventHandler(this.frmVersao_Load);
            this.pnlVersao.ResumeLayout(false);
            this.pnlVersao.PerformLayout();
            this.gpoVersao.ResumeLayout(false);
            this.gpoVersao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRevisao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVersao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSecundaria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipVersao;
        private System.Windows.Forms.Panel pnlVersao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtData;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblPrincipal;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtPrincipal;
        private System.Windows.Forms.GroupBox gpoVersao;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtSecundaria;
        private System.Windows.Forms.Label lblSecundaria;
        private BLL.validacoes.Controles.TextBoxPersonal txtHora;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTipo;
        private System.Windows.Forms.Label lblTipo;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtRevisao;
        private System.Windows.Forms.Label lblRevisao;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtVersao;
        private System.Windows.Forms.Label lblVersao;
    }
}