namespace ccbinst
{
    partial class frmEscala
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEscala));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipForm = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlEscala = new System.Windows.Forms.Panel();
            this.gpoEscala = new System.Windows.Forms.GroupBox();
            this.gpoAlteracoes = new System.Windows.Forms.GroupBox();
            this.optDSustenido = new System.Windows.Forms.RadioButton();
            this.optDBemol = new System.Windows.Forms.RadioButton();
            this.optSustenido = new System.Windows.Forms.RadioButton();
            this.optBemol = new System.Windows.Forms.RadioButton();
            this.optBequadro = new System.Windows.Forms.RadioButton();
            this.cboTipo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblAlteracoes = new System.Windows.Forms.Label();
            this.lbTipo = new System.Windows.Forms.Label();
            this.cboTonica = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lbTonica = new System.Windows.Forms.Label();
            this.cboModelo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lbModelo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblTonica = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblAltera = new System.Windows.Forms.Label();
            this.pnlEscala.SuspendLayout();
            this.gpoEscala.SuspendLayout();
            this.gpoAlteracoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(187, 268);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "&Salvar";
            this.tipForm.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(282, 268);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.tipForm.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(64, 10);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(53, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipForm.SetToolTip(this.txtCodigo, "Código");
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(64, 222);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(286, 21);
            this.txtDescricao.TabIndex = 13;
            this.tipForm.SetToolTip(this.txtDescricao, "Descrição do Cargo");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // pnlEscala
            // 
            this.pnlEscala.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlEscala.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEscala.Controls.Add(this.gpoEscala);
            this.pnlEscala.Controls.Add(this.txtDescricao);
            this.pnlEscala.Controls.Add(this.lblDescricao);
            this.pnlEscala.Controls.Add(this.txtCodigo);
            this.pnlEscala.Controls.Add(this.lblCodigo);
            this.pnlEscala.Location = new System.Drawing.Point(8, 7);
            this.pnlEscala.Name = "pnlEscala";
            this.pnlEscala.Size = new System.Drawing.Size(363, 256);
            this.pnlEscala.TabIndex = 0;
            // 
            // gpoEscala
            // 
            this.gpoEscala.Controls.Add(this.gpoAlteracoes);
            this.gpoEscala.Controls.Add(this.cboTipo);
            this.gpoEscala.Controls.Add(this.lblAlteracoes);
            this.gpoEscala.Controls.Add(this.lbTipo);
            this.gpoEscala.Controls.Add(this.cboTonica);
            this.gpoEscala.Controls.Add(this.lbTonica);
            this.gpoEscala.Controls.Add(this.cboModelo);
            this.gpoEscala.Controls.Add(this.lbModelo);
            this.gpoEscala.Location = new System.Drawing.Point(12, 39);
            this.gpoEscala.Name = "gpoEscala";
            this.gpoEscala.Size = new System.Drawing.Size(338, 177);
            this.gpoEscala.TabIndex = 3;
            this.gpoEscala.TabStop = false;
            this.gpoEscala.Text = "Monte a Escala";
            // 
            // gpoAlteracoes
            // 
            this.gpoAlteracoes.Controls.Add(this.optDSustenido);
            this.gpoAlteracoes.Controls.Add(this.optDBemol);
            this.gpoAlteracoes.Controls.Add(this.optSustenido);
            this.gpoAlteracoes.Controls.Add(this.optBemol);
            this.gpoAlteracoes.Controls.Add(this.optBequadro);
            this.gpoAlteracoes.Location = new System.Drawing.Point(62, 77);
            this.gpoAlteracoes.Name = "gpoAlteracoes";
            this.gpoAlteracoes.Size = new System.Drawing.Size(258, 59);
            this.gpoAlteracoes.TabIndex = 6;
            this.gpoAlteracoes.TabStop = false;
            this.gpoAlteracoes.Text = "Alterações";
            // 
            // optDSustenido
            // 
            this.optDSustenido.BackgroundImage = global::ccbinst.Properties.Resources.X;
            this.optDSustenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optDSustenido.Location = new System.Drawing.Point(199, 27);
            this.optDSustenido.Name = "optDSustenido";
            this.optDSustenido.Size = new System.Drawing.Size(55, 20);
            this.optDSustenido.TabIndex = 11;
            this.optDSustenido.TabStop = true;
            this.optDSustenido.UseVisualStyleBackColor = true;
            this.optDSustenido.Click += new System.EventHandler(this.optDSustenido_Click);
            // 
            // optDBemol
            // 
            this.optDBemol.BackgroundImage = global::ccbinst.Properties.Resources.bb;
            this.optDBemol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optDBemol.Location = new System.Drawing.Point(144, 24);
            this.optDBemol.Name = "optDBemol";
            this.optDBemol.Size = new System.Drawing.Size(60, 27);
            this.optDBemol.TabIndex = 10;
            this.optDBemol.TabStop = true;
            this.optDBemol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optDBemol.UseVisualStyleBackColor = true;
            this.optDBemol.Click += new System.EventHandler(this.optDBemol_Click);
            // 
            // optSustenido
            // 
            this.optSustenido.BackgroundImage = global::ccbinst.Properties.Resources.Sust;
            this.optSustenido.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optSustenido.Location = new System.Drawing.Point(95, 24);
            this.optSustenido.Name = "optSustenido";
            this.optSustenido.Size = new System.Drawing.Size(50, 27);
            this.optSustenido.TabIndex = 9;
            this.optSustenido.TabStop = true;
            this.optSustenido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optSustenido.UseVisualStyleBackColor = true;
            this.optSustenido.Click += new System.EventHandler(this.optSustenido_Click);
            // 
            // optBemol
            // 
            this.optBemol.BackgroundImage = global::ccbinst.Properties.Resources.b;
            this.optBemol.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optBemol.Location = new System.Drawing.Point(50, 24);
            this.optBemol.Name = "optBemol";
            this.optBemol.Size = new System.Drawing.Size(50, 27);
            this.optBemol.TabIndex = 8;
            this.optBemol.TabStop = true;
            this.optBemol.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optBemol.UseVisualStyleBackColor = true;
            this.optBemol.Click += new System.EventHandler(this.optBemol_Click);
            // 
            // optBequadro
            // 
            this.optBequadro.BackgroundImage = global::ccbinst.Properties.Resources.bequadro;
            this.optBequadro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.optBequadro.Location = new System.Drawing.Point(15, 24);
            this.optBequadro.Name = "optBequadro";
            this.optBequadro.Size = new System.Drawing.Size(45, 27);
            this.optBequadro.TabIndex = 7;
            this.optBequadro.TabStop = true;
            this.optBequadro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optBequadro.UseVisualStyleBackColor = true;
            this.optBequadro.Click += new System.EventHandler(this.optBequadro_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(62, 141);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(258, 21);
            this.cboTipo.TabIndex = 12;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // lblAlteracoes
            // 
            this.lblAlteracoes.Location = new System.Drawing.Point(11, 91);
            this.lblAlteracoes.Name = "lblAlteracoes";
            this.lblAlteracoes.Size = new System.Drawing.Size(56, 17);
            this.lblAlteracoes.TabIndex = 115;
            this.lblAlteracoes.Visible = false;
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Location = new System.Drawing.Point(12, 144);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(31, 13);
            this.lbTipo.TabIndex = 117;
            this.lbTipo.Text = "Tipo:";
            // 
            // cboTonica
            // 
            this.cboTonica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTonica.FormattingEnabled = true;
            this.cboTonica.Items.AddRange(new object[] {
            "Dó",
            "Ré",
            "Mi",
            "Fá",
            "Sol",
            "Lá",
            "Si"});
            this.cboTonica.Location = new System.Drawing.Point(61, 51);
            this.cboTonica.Name = "cboTonica";
            this.cboTonica.Size = new System.Drawing.Size(157, 21);
            this.cboTonica.TabIndex = 5;
            this.cboTonica.SelectedIndexChanged += new System.EventHandler(this.cboTonica_SelectedIndexChanged);
            // 
            // lbTonica
            // 
            this.lbTonica.AutoSize = true;
            this.lbTonica.Location = new System.Drawing.Point(11, 54);
            this.lbTonica.Name = "lbTonica";
            this.lbTonica.Size = new System.Drawing.Size(42, 13);
            this.lbTonica.TabIndex = 114;
            this.lbTonica.Text = "Tônica:";
            // 
            // cboModelo
            // 
            this.cboModelo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelo.FormattingEnabled = true;
            this.cboModelo.Items.AddRange(new object[] {
            "Diatônica",
            "Cromática"});
            this.cboModelo.Location = new System.Drawing.Point(61, 25);
            this.cboModelo.Name = "cboModelo";
            this.cboModelo.Size = new System.Drawing.Size(157, 21);
            this.cboModelo.TabIndex = 4;
            this.cboModelo.SelectedIndexChanged += new System.EventHandler(this.cboModelo_SelectedIndexChanged);
            // 
            // lbModelo
            // 
            this.lbModelo.AutoSize = true;
            this.lbModelo.Location = new System.Drawing.Point(11, 28);
            this.lbModelo.Name = "lbModelo";
            this.lbModelo.Size = new System.Drawing.Size(45, 13);
            this.lbModelo.TabIndex = 112;
            this.lbModelo.Text = "Modelo:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 224);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(41, 13);
            this.lblDescricao.TabIndex = 109;
            this.lblDescricao.Text = "Escala:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(12, 14);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // lblModelo
            // 
            this.lblModelo.Location = new System.Drawing.Point(12, 314);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(56, 17);
            this.lblModelo.TabIndex = 113;
            this.lblModelo.Visible = false;
            // 
            // lblTonica
            // 
            this.lblTonica.Location = new System.Drawing.Point(74, 314);
            this.lblTonica.Name = "lblTonica";
            this.lblTonica.Size = new System.Drawing.Size(56, 17);
            this.lblTonica.TabIndex = 114;
            this.lblTonica.Visible = false;
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(74, 332);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(56, 17);
            this.lblTipo.TabIndex = 116;
            this.lblTipo.Visible = false;
            // 
            // lblAltera
            // 
            this.lblAltera.Location = new System.Drawing.Point(12, 331);
            this.lblAltera.Name = "lblAltera";
            this.lblAltera.Size = new System.Drawing.Size(56, 17);
            this.lblAltera.TabIndex = 119;
            this.lblAltera.Visible = false;
            // 
            // frmEscala
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(377, 305);
            this.Controls.Add(this.lblAltera);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblTonica);
            this.Controls.Add(this.lblModelo);
            this.Controls.Add(this.pnlEscala);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEscala";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escalas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEscala_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEscala_FormClosed);
            this.Load += new System.EventHandler(this.frmEscala_Load);
            this.pnlEscala.ResumeLayout(false);
            this.pnlEscala.PerformLayout();
            this.gpoEscala.ResumeLayout(false);
            this.gpoEscala.PerformLayout();
            this.gpoAlteracoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipForm;
        private System.Windows.Forms.Panel pnlEscala;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gpoEscala;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTipo;
        private System.Windows.Forms.Label lbTipo;
        private System.Windows.Forms.GroupBox gpoAlteracoes;
        private System.Windows.Forms.RadioButton optDBemol;
        private System.Windows.Forms.RadioButton optDSustenido;
        private System.Windows.Forms.RadioButton optSustenido;
        private System.Windows.Forms.RadioButton optBemol;
        private System.Windows.Forms.RadioButton optBequadro;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTonica;
        private System.Windows.Forms.Label lbTonica;
        private BLL.validacoes.Controles.ComboBoxPersonal cboModelo;
        private System.Windows.Forms.Label lbModelo;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblTonica;
        private System.Windows.Forms.Label lblAlteracoes;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblAltera;
    }
}