namespace ccbinst
{
    partial class frmVozes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVozes));
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblNotaGrave = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlVoz = new System.Windows.Forms.Panel();
            this.lblNotaAguda = new System.Windows.Forms.Label();
            this.lblPosAguda = new System.Windows.Forms.Label();
            this.lbNotaAguda = new System.Windows.Forms.Label();
            this.cboPosAgudo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboNotaAguda = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lbNotaGrave = new System.Windows.Forms.Label();
            this.cboPosGrave = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboNotaGrave = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblPosGrave = new System.Windows.Forms.Label();
            this.pnlVoz.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Silver;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(106, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(47, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(22, 20);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 18;
            this.lblCodigo.Text = "Código:";
            // 
            // lblNotaGrave
            // 
            this.lblNotaGrave.Location = new System.Drawing.Point(230, 74);
            this.lblNotaGrave.Name = "lblNotaGrave";
            this.lblNotaGrave.Size = new System.Drawing.Size(37, 17);
            this.lblNotaGrave.TabIndex = 22;
            this.lblNotaGrave.Visible = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(132, 147);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(226, 147);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlVoz
            // 
            this.pnlVoz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlVoz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVoz.Controls.Add(this.lblNotaAguda);
            this.pnlVoz.Controls.Add(this.lblPosAguda);
            this.pnlVoz.Controls.Add(this.lbNotaAguda);
            this.pnlVoz.Controls.Add(this.lblNotaGrave);
            this.pnlVoz.Controls.Add(this.cboPosAgudo);
            this.pnlVoz.Controls.Add(this.cboNotaAguda);
            this.pnlVoz.Controls.Add(this.lbNotaGrave);
            this.pnlVoz.Controls.Add(this.cboPosGrave);
            this.pnlVoz.Controls.Add(this.cboNotaGrave);
            this.pnlVoz.Controls.Add(this.txtDescricao);
            this.pnlVoz.Controls.Add(this.lblDescricao);
            this.pnlVoz.Controls.Add(this.lblPosGrave);
            this.pnlVoz.Controls.Add(this.txtCodigo);
            this.pnlVoz.Controls.Add(this.lblCodigo);
            this.pnlVoz.Location = new System.Drawing.Point(7, 7);
            this.pnlVoz.Name = "pnlVoz";
            this.pnlVoz.Size = new System.Drawing.Size(308, 134);
            this.pnlVoz.TabIndex = 0;
            // 
            // lblNotaAguda
            // 
            this.lblNotaAguda.Location = new System.Drawing.Point(232, 101);
            this.lblNotaAguda.Name = "lblNotaAguda";
            this.lblNotaAguda.Size = new System.Drawing.Size(37, 17);
            this.lblNotaAguda.TabIndex = 47;
            this.lblNotaAguda.Visible = false;
            // 
            // lblPosAguda
            // 
            this.lblPosAguda.Location = new System.Drawing.Point(251, 102);
            this.lblPosAguda.Name = "lblPosAguda";
            this.lblPosAguda.Size = new System.Drawing.Size(42, 17);
            this.lblPosAguda.TabIndex = 48;
            this.lblPosAguda.Visible = false;
            // 
            // lbNotaAguda
            // 
            this.lbNotaAguda.AutoSize = true;
            this.lbNotaAguda.Location = new System.Drawing.Point(22, 101);
            this.lbNotaAguda.Name = "lbNotaAguda";
            this.lbNotaAguda.Size = new System.Drawing.Size(67, 13);
            this.lbNotaAguda.TabIndex = 46;
            this.lbNotaAguda.Text = "Nota aguda:";
            // 
            // cboPosAgudo
            // 
            this.cboPosAgudo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosAgudo.FormattingEnabled = true;
            this.cboPosAgudo.Items.AddRange(new object[] {
            "(-1)",
            "( 1)",
            "( 2)",
            "( 3)",
            "( 4)",
            "( 5)",
            "( 6)"});
            this.cboPosAgudo.Location = new System.Drawing.Point(180, 98);
            this.cboPosAgudo.Name = "cboPosAgudo";
            this.cboPosAgudo.Size = new System.Drawing.Size(44, 21);
            this.cboPosAgudo.TabIndex = 43;
            this.cboPosAgudo.SelectedIndexChanged += new System.EventHandler(this.cboPosAgudo_SelectedIndexChanged);
            // 
            // cboNotaAguda
            // 
            this.cboNotaAguda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotaAguda.FormattingEnabled = true;
            this.cboNotaAguda.Items.AddRange(new object[] {
            "Dó",
            "Ré",
            "Mi",
            "Fá",
            "Sol",
            "Lá",
            "Si"});
            this.cboNotaAguda.Location = new System.Drawing.Point(106, 98);
            this.cboNotaAguda.Name = "cboNotaAguda";
            this.cboNotaAguda.Size = new System.Drawing.Size(68, 21);
            this.cboNotaAguda.TabIndex = 42;
            this.cboNotaAguda.SelectedIndexChanged += new System.EventHandler(this.cboNotaAguda_SelectedIndexChanged);
            // 
            // lbNotaGrave
            // 
            this.lbNotaGrave.AutoSize = true;
            this.lbNotaGrave.Location = new System.Drawing.Point(22, 74);
            this.lbNotaGrave.Name = "lbNotaGrave";
            this.lbNotaGrave.Size = new System.Drawing.Size(65, 13);
            this.lbNotaGrave.TabIndex = 45;
            this.lbNotaGrave.Text = "Nota grave:";
            // 
            // cboPosGrave
            // 
            this.cboPosGrave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosGrave.FormattingEnabled = true;
            this.cboPosGrave.Items.AddRange(new object[] {
            "(-1)",
            "( 1)",
            "( 2)",
            "( 3)",
            "( 4)",
            "( 5)",
            "( 6)"});
            this.cboPosGrave.Location = new System.Drawing.Point(180, 71);
            this.cboPosGrave.Name = "cboPosGrave";
            this.cboPosGrave.Size = new System.Drawing.Size(44, 21);
            this.cboPosGrave.TabIndex = 41;
            this.cboPosGrave.SelectedIndexChanged += new System.EventHandler(this.cboPosGrave_SelectedIndexChanged);
            // 
            // cboNotaGrave
            // 
            this.cboNotaGrave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotaGrave.FormattingEnabled = true;
            this.cboNotaGrave.Items.AddRange(new object[] {
            "Dó",
            "Ré",
            "Mi",
            "Fá",
            "Sol",
            "Lá",
            "Si"});
            this.cboNotaGrave.Location = new System.Drawing.Point(106, 71);
            this.cboNotaGrave.Name = "cboNotaGrave";
            this.cboNotaGrave.Size = new System.Drawing.Size(68, 21);
            this.cboNotaGrave.TabIndex = 40;
            this.cboNotaGrave.SelectedIndexChanged += new System.EventHandler(this.cboNotaGrave_SelectedIndexChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(106, 44);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(176, 21);
            this.txtDescricao.TabIndex = 39;
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(22, 47);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 44;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblPosGrave
            // 
            this.lblPosGrave.Location = new System.Drawing.Point(255, 84);
            this.lblPosGrave.Name = "lblPosGrave";
            this.lblPosGrave.Size = new System.Drawing.Size(42, 17);
            this.lblPosGrave.TabIndex = 38;
            this.lblPosGrave.Visible = false;
            // 
            // frmVozes
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(323, 184);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlVoz);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVozes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vozes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVozes_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVozes_FormClosed);
            this.Load += new System.EventHandler(this.frmVozes_Load);
            this.pnlVoz.ResumeLayout(false);
            this.pnlVoz.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblNotaGrave;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlVoz;
        private System.Windows.Forms.Label lblPosGrave;
        private System.Windows.Forms.Label lbNotaAguda;
        private BLL.validacoes.Controles.ComboBoxPersonal cboPosAgudo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboNotaAguda;
        private System.Windows.Forms.Label lbNotaGrave;
        private BLL.validacoes.Controles.ComboBoxPersonal cboPosGrave;
        private BLL.validacoes.Controles.ComboBoxPersonal cboNotaGrave;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblNotaAguda;
        private System.Windows.Forms.Label lblPosAguda;
    }
}