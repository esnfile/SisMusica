namespace ccbinst
{
    partial class frmTonalidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTonalidade));
            this.gpoAltera = new System.Windows.Forms.GroupBox();
            this.optSustenido = new System.Windows.Forms.RadioButton();
            this.optBemol = new System.Windows.Forms.RadioButton();
            this.optNatural = new System.Windows.Forms.RadioButton();
            this.cboNota = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lbNota = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCodFamilia = new System.Windows.Forms.Label();
            this.lblNota = new System.Windows.Forms.Label();
            this.lblAltera = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlTonalidade = new System.Windows.Forms.Panel();
            this.lblAlteracoes = new System.Windows.Forms.Label();
            this.gpoAltera.SuspendLayout();
            this.pnlTonalidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoAltera
            // 
            this.gpoAltera.Controls.Add(this.optSustenido);
            this.gpoAltera.Controls.Add(this.optBemol);
            this.gpoAltera.Controls.Add(this.optNatural);
            this.gpoAltera.Location = new System.Drawing.Point(91, 71);
            this.gpoAltera.Name = "gpoAltera";
            this.gpoAltera.Size = new System.Drawing.Size(189, 50);
            this.gpoAltera.TabIndex = 3;
            this.gpoAltera.TabStop = false;
            this.gpoAltera.Text = "Alterações";
            // 
            // optSustenido
            // 
            this.optSustenido.BackgroundImage = global::ccbinst.Properties.Resources.Sust;
            this.optSustenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optSustenido.Location = new System.Drawing.Point(122, 17);
            this.optSustenido.Name = "optSustenido";
            this.optSustenido.Size = new System.Drawing.Size(50, 27);
            this.optSustenido.TabIndex = 6;
            this.optSustenido.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.optSustenido.UseVisualStyleBackColor = true;
            this.optSustenido.Click += new System.EventHandler(this.optSustenido_Click);
            // 
            // optBemol
            // 
            this.optBemol.BackgroundImage = global::ccbinst.Properties.Resources.b;
            this.optBemol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optBemol.Location = new System.Drawing.Point(69, 17);
            this.optBemol.Name = "optBemol";
            this.optBemol.Size = new System.Drawing.Size(50, 27);
            this.optBemol.TabIndex = 5;
            this.optBemol.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.optBemol.UseVisualStyleBackColor = true;
            this.optBemol.Click += new System.EventHandler(this.optBemol_Click);
            // 
            // optNatural
            // 
            this.optNatural.BackgroundImage = global::ccbinst.Properties.Resources.bequadro;
            this.optNatural.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optNatural.Location = new System.Drawing.Point(18, 17);
            this.optNatural.Name = "optNatural";
            this.optNatural.Size = new System.Drawing.Size(45, 27);
            this.optNatural.TabIndex = 4;
            this.optNatural.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optNatural.UseVisualStyleBackColor = true;
            this.optNatural.Click += new System.EventHandler(this.optNatural_Click);
            // 
            // cboNota
            // 
            this.cboNota.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNota.FormattingEnabled = true;
            this.cboNota.Items.AddRange(new object[] {
            "Dó",
            "Ré",
            "Mi",
            "Fá",
            "Sol",
            "Lá",
            "Si"});
            this.cboNota.Location = new System.Drawing.Point(91, 44);
            this.cboNota.Name = "cboNota";
            this.cboNota.Size = new System.Drawing.Size(185, 21);
            this.cboNota.TabIndex = 2;
            this.cboNota.SelectedIndexChanged += new System.EventHandler(this.cboNota_SelectedIndexChanged);
            // 
            // lbNota
            // 
            this.lbNota.AutoSize = true;
            this.lbNota.Location = new System.Drawing.Point(22, 47);
            this.lbNota.Name = "lbNota";
            this.lbNota.Size = new System.Drawing.Size(34, 13);
            this.lbNota.TabIndex = 15;
            this.lbNota.Text = "Nota:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Enabled = false;
            this.lblDescricao.Location = new System.Drawing.Point(22, 129);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(63, 13);
            this.lblDescricao.TabIndex = 20;
            this.lblDescricao.Text = "Tonalidade:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Silver;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(91, 17);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(49, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.LightGray;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(91, 127);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(189, 21);
            this.txtDescricao.TabIndex = 7;
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCodFamilia
            // 
            this.lblCodFamilia.AutoSize = true;
            this.lblCodFamilia.Enabled = false;
            this.lblCodFamilia.Location = new System.Drawing.Point(22, 20);
            this.lblCodFamilia.Name = "lblCodFamilia";
            this.lblCodFamilia.Size = new System.Drawing.Size(44, 13);
            this.lblCodFamilia.TabIndex = 18;
            this.lblCodFamilia.Text = "Código:";
            // 
            // lblNota
            // 
            this.lblNota.Location = new System.Drawing.Point(84, 201);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(37, 17);
            this.lblNota.TabIndex = 23;
            this.lblNota.Visible = false;
            // 
            // lblAltera
            // 
            this.lblAltera.Location = new System.Drawing.Point(6, 201);
            this.lblAltera.Name = "lblAltera";
            this.lblAltera.Size = new System.Drawing.Size(70, 17);
            this.lblAltera.TabIndex = 22;
            this.lblAltera.Visible = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(122, 200);
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
            this.btnCancelar.Location = new System.Drawing.Point(218, 200);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlTonalidade
            // 
            this.pnlTonalidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlTonalidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTonalidade.Controls.Add(this.lblAlteracoes);
            this.pnlTonalidade.Controls.Add(this.lblDescricao);
            this.pnlTonalidade.Controls.Add(this.txtCodigo);
            this.pnlTonalidade.Controls.Add(this.gpoAltera);
            this.pnlTonalidade.Controls.Add(this.txtDescricao);
            this.pnlTonalidade.Controls.Add(this.lblCodFamilia);
            this.pnlTonalidade.Controls.Add(this.cboNota);
            this.pnlTonalidade.Controls.Add(this.lbNota);
            this.pnlTonalidade.Location = new System.Drawing.Point(7, 7);
            this.pnlTonalidade.Name = "pnlTonalidade";
            this.pnlTonalidade.Size = new System.Drawing.Size(300, 187);
            this.pnlTonalidade.TabIndex = 0;
            // 
            // lblAlteracoes
            // 
            this.lblAlteracoes.Location = new System.Drawing.Point(22, 86);
            this.lblAlteracoes.Name = "lblAlteracoes";
            this.lblAlteracoes.Size = new System.Drawing.Size(42, 17);
            this.lblAlteracoes.TabIndex = 38;
            this.lblAlteracoes.Visible = false;
            // 
            // frmTonalidade
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(313, 234);
            this.Controls.Add(this.lblNota);
            this.Controls.Add(this.lblAltera);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlTonalidade);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTonalidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tonalidade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTonalidade_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTonalidade_FormClosed);
            this.Load += new System.EventHandler(this.frmTonalidade_Load);
            this.gpoAltera.ResumeLayout(false);
            this.pnlTonalidade.ResumeLayout(false);
            this.pnlTonalidade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoAltera;
        private System.Windows.Forms.RadioButton optSustenido;
        private System.Windows.Forms.RadioButton optBemol;
        private System.Windows.Forms.RadioButton optNatural;
        private BLL.validacoes.Controles.ComboBoxPersonal cboNota;
        private System.Windows.Forms.Label lbNota;
        private System.Windows.Forms.Label lblDescricao;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblCodFamilia;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.Label lblAltera;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlTonalidade;
        private System.Windows.Forms.Label lblAlteracoes;
    }
}