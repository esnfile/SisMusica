namespace ccbinst
{
    partial class frmMetodo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetodo));
            this.tipMetodo = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlMetodo = new System.Windows.Forms.Panel();
            this.gpoEscolha = new System.Windows.Forms.GroupBox();
            this.optSistema = new System.Windows.Forms.RadioButton();
            this.optCandidato = new System.Windows.Forms.RadioButton();
            this.lblTipoEscolha = new System.Windows.Forms.Label();
            this.gpoInstrumento = new System.Windows.Forms.GroupBox();
            this.optLicao = new System.Windows.Forms.RadioButton();
            this.lblPaginaFase = new System.Windows.Forms.Label();
            this.optFase = new System.Windows.Forms.RadioButton();
            this.optPagina = new System.Windows.Forms.RadioButton();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.gpoTipo = new System.Windows.Forms.GroupBox();
            this.optInstrumento = new System.Windows.Forms.RadioButton();
            this.optRitmo = new System.Windows.Forms.RadioButton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.optSolfejo = new System.Windows.Forms.RadioButton();
            this.gpoFamilia = new System.Windows.Forms.GroupBox();
            this.gridMetodoFamilia = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCompositor = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCompositor = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlMetodo.SuspendLayout();
            this.gpoEscolha.SuspendLayout();
            this.gpoInstrumento.SuspendLayout();
            this.gpoTipo.SuspendLayout();
            this.gpoFamilia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMetodoFamilia)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Location = new System.Drawing.Point(261, 253);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 12;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(354, 253);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlMetodo
            // 
            this.pnlMetodo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlMetodo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMetodo.Controls.Add(this.gpoEscolha);
            this.pnlMetodo.Controls.Add(this.gpoInstrumento);
            this.pnlMetodo.Controls.Add(this.chkAtivo);
            this.pnlMetodo.Controls.Add(this.gpoTipo);
            this.pnlMetodo.Controls.Add(this.gpoFamilia);
            this.pnlMetodo.Controls.Add(this.txtDescricao);
            this.pnlMetodo.Controls.Add(this.txtCodigo);
            this.pnlMetodo.Controls.Add(this.txtCompositor);
            this.pnlMetodo.Controls.Add(this.lblDescricao);
            this.pnlMetodo.Controls.Add(this.lblCompositor);
            this.pnlMetodo.Controls.Add(this.lblCodigo);
            this.pnlMetodo.Location = new System.Drawing.Point(6, 7);
            this.pnlMetodo.Name = "pnlMetodo";
            this.pnlMetodo.Size = new System.Drawing.Size(438, 242);
            this.pnlMetodo.TabIndex = 0;
            // 
            // gpoEscolha
            // 
            this.gpoEscolha.Controls.Add(this.optSistema);
            this.gpoEscolha.Controls.Add(this.optCandidato);
            this.gpoEscolha.Controls.Add(this.lblTipoEscolha);
            this.gpoEscolha.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gpoEscolha.Location = new System.Drawing.Point(257, 14);
            this.gpoEscolha.Name = "gpoEscolha";
            this.gpoEscolha.Size = new System.Drawing.Size(166, 44);
            this.gpoEscolha.TabIndex = 60;
            this.gpoEscolha.TabStop = false;
            this.gpoEscolha.Text = "Escolha de Lições (Teste)";
            // 
            // optSistema
            // 
            this.optSistema.AutoSize = true;
            this.optSistema.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optSistema.Location = new System.Drawing.Point(7, 19);
            this.optSistema.Name = "optSistema";
            this.optSistema.Size = new System.Drawing.Size(62, 17);
            this.optSistema.TabIndex = 10;
            this.optSistema.TabStop = true;
            this.optSistema.Text = "Sistema";
            this.optSistema.UseVisualStyleBackColor = true;
            this.optSistema.CheckedChanged += new System.EventHandler(this.optSistema_CheckedChanged);
            // 
            // optCandidato
            // 
            this.optCandidato.AutoSize = true;
            this.optCandidato.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optCandidato.Location = new System.Drawing.Point(74, 19);
            this.optCandidato.Name = "optCandidato";
            this.optCandidato.Size = new System.Drawing.Size(88, 17);
            this.optCandidato.TabIndex = 11;
            this.optCandidato.TabStop = true;
            this.optCandidato.Text = "Candidato(a)";
            this.optCandidato.UseVisualStyleBackColor = true;
            this.optCandidato.CheckedChanged += new System.EventHandler(this.optCandidato_CheckedChanged);
            // 
            // lblTipoEscolha
            // 
            this.lblTipoEscolha.Location = new System.Drawing.Point(67, 28);
            this.lblTipoEscolha.Name = "lblTipoEscolha";
            this.lblTipoEscolha.Size = new System.Drawing.Size(27, 13);
            this.lblTipoEscolha.TabIndex = 59;
            this.lblTipoEscolha.Visible = false;
            // 
            // gpoInstrumento
            // 
            this.gpoInstrumento.Controls.Add(this.optLicao);
            this.gpoInstrumento.Controls.Add(this.lblPaginaFase);
            this.gpoInstrumento.Controls.Add(this.optFase);
            this.gpoInstrumento.Controls.Add(this.optPagina);
            this.gpoInstrumento.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gpoInstrumento.Location = new System.Drawing.Point(285, 162);
            this.gpoInstrumento.Name = "gpoInstrumento";
            this.gpoInstrumento.Size = new System.Drawing.Size(138, 70);
            this.gpoInstrumento.TabIndex = 60;
            this.gpoInstrumento.TabStop = false;
            this.gpoInstrumento.Text = "Definição de escolha";
            // 
            // optLicao
            // 
            this.optLicao.AutoSize = true;
            this.optLicao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optLicao.Location = new System.Drawing.Point(9, 48);
            this.optLicao.Name = "optLicao";
            this.optLicao.Size = new System.Drawing.Size(54, 17);
            this.optLicao.TabIndex = 61;
            this.optLicao.TabStop = true;
            this.optLicao.Text = "Lições";
            this.optLicao.UseVisualStyleBackColor = true;
            this.optLicao.CheckedChanged += new System.EventHandler(this.optLicao_CheckedChanged);
            // 
            // lblPaginaFase
            // 
            this.lblPaginaFase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPaginaFase.Location = new System.Drawing.Point(63, 49);
            this.lblPaginaFase.Name = "lblPaginaFase";
            this.lblPaginaFase.Size = new System.Drawing.Size(27, 13);
            this.lblPaginaFase.TabIndex = 60;
            this.lblPaginaFase.Visible = false;
            // 
            // optFase
            // 
            this.optFase.AutoSize = true;
            this.optFase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.optFase.Location = new System.Drawing.Point(9, 14);
            this.optFase.Name = "optFase";
            this.optFase.Size = new System.Drawing.Size(127, 17);
            this.optFase.TabIndex = 14;
            this.optFase.TabStop = true;
            this.optFase.Text = "Fases/Páginas/Lições";
            this.optFase.UseVisualStyleBackColor = true;
            this.optFase.CheckedChanged += new System.EventHandler(this.optFase_CheckedChanged);
            // 
            // optPagina
            // 
            this.optPagina.AutoSize = true;
            this.optPagina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optPagina.Location = new System.Drawing.Point(9, 31);
            this.optPagina.Name = "optPagina";
            this.optPagina.Size = new System.Drawing.Size(95, 17);
            this.optPagina.TabIndex = 13;
            this.optPagina.TabStop = true;
            this.optPagina.Text = "Páginas/Lições";
            this.optPagina.UseVisualStyleBackColor = true;
            this.optPagina.CheckedChanged += new System.EventHandler(this.optPagina_CheckedChanged);
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Location = new System.Drawing.Point(174, 11);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(56, 17);
            this.chkAtivo.TabIndex = 2;
            this.chkAtivo.Text = "Ativo?";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // gpoTipo
            // 
            this.gpoTipo.Controls.Add(this.optInstrumento);
            this.gpoTipo.Controls.Add(this.optRitmo);
            this.gpoTipo.Controls.Add(this.lblTipo);
            this.gpoTipo.Controls.Add(this.optSolfejo);
            this.gpoTipo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gpoTipo.Location = new System.Drawing.Point(285, 92);
            this.gpoTipo.Name = "gpoTipo";
            this.gpoTipo.Size = new System.Drawing.Size(138, 70);
            this.gpoTipo.TabIndex = 9;
            this.gpoTipo.TabStop = false;
            this.gpoTipo.Text = "Definição de método";
            // 
            // optInstrumento
            // 
            this.optInstrumento.AutoSize = true;
            this.optInstrumento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optInstrumento.Location = new System.Drawing.Point(9, 47);
            this.optInstrumento.Name = "optInstrumento";
            this.optInstrumento.Size = new System.Drawing.Size(84, 17);
            this.optInstrumento.TabIndex = 12;
            this.optInstrumento.TabStop = true;
            this.optInstrumento.Text = "Instrumento";
            this.optInstrumento.UseVisualStyleBackColor = true;
            this.optInstrumento.CheckedChanged += new System.EventHandler(this.optInstrumento_CheckedChanged);
            // 
            // optRitmo
            // 
            this.optRitmo.AutoSize = true;
            this.optRitmo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optRitmo.Location = new System.Drawing.Point(9, 31);
            this.optRitmo.Name = "optRitmo";
            this.optRitmo.Size = new System.Drawing.Size(59, 17);
            this.optRitmo.TabIndex = 11;
            this.optRitmo.TabStop = true;
            this.optRitmo.Text = "Ritmico";
            this.optRitmo.UseVisualStyleBackColor = true;
            this.optRitmo.CheckedChanged += new System.EventHandler(this.optRitmo_CheckedChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(85, 17);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(27, 13);
            this.lblTipo.TabIndex = 59;
            this.lblTipo.Visible = false;
            // 
            // optSolfejo
            // 
            this.optSolfejo.AutoSize = true;
            this.optSolfejo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optSolfejo.Location = new System.Drawing.Point(9, 15);
            this.optSolfejo.Name = "optSolfejo";
            this.optSolfejo.Size = new System.Drawing.Size(58, 17);
            this.optSolfejo.TabIndex = 10;
            this.optSolfejo.TabStop = true;
            this.optSolfejo.Text = "Solfejo";
            this.optSolfejo.UseVisualStyleBackColor = true;
            this.optSolfejo.CheckedChanged += new System.EventHandler(this.optSolfejo_CheckedChanged);
            // 
            // gpoFamilia
            // 
            this.gpoFamilia.Controls.Add(this.gridMetodoFamilia);
            this.gpoFamilia.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gpoFamilia.Location = new System.Drawing.Point(13, 92);
            this.gpoFamilia.Name = "gpoFamilia";
            this.gpoFamilia.Size = new System.Drawing.Size(265, 140);
            this.gpoFamilia.TabIndex = 7;
            this.gpoFamilia.TabStop = false;
            this.gpoFamilia.Text = "Será utilizado por qual família?";
            // 
            // gridMetodoFamilia
            // 
            this.gridMetodoFamilia.AllowUserToAddRows = false;
            this.gridMetodoFamilia.AllowUserToDeleteRows = false;
            this.gridMetodoFamilia.AllowUserToResizeRows = false;
            this.gridMetodoFamilia.BackgroundColor = System.Drawing.Color.White;
            this.gridMetodoFamilia.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMetodoFamilia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMetodoFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMetodoFamilia.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMetodoFamilia.DisabledCell = null;
            this.gridMetodoFamilia.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridMetodoFamilia.EnableHeadersVisualStyles = false;
            this.gridMetodoFamilia.Location = new System.Drawing.Point(8, 17);
            this.gridMetodoFamilia.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridMetodoFamilia.MultiSelect = false;
            this.gridMetodoFamilia.Name = "gridMetodoFamilia";
            this.gridMetodoFamilia.ReadOnly = true;
            this.gridMetodoFamilia.RowHeadersVisible = false;
            this.gridMetodoFamilia.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMetodoFamilia.RowTemplate.Height = 18;
            this.gridMetodoFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMetodoFamilia.Size = new System.Drawing.Size(248, 115);
            this.gridMetodoFamilia.TabIndex = 8;
            this.gridMetodoFamilia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMetodoFamilia_CellClick);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(76, 37);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(168, 21);
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Silver;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(76, 10);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(49, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCompositor
            // 
            this.txtCompositor.BackColor = System.Drawing.Color.White;
            this.txtCompositor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompositor.Location = new System.Drawing.Point(76, 64);
            this.txtCompositor.Name = "txtCompositor";
            this.txtCompositor.Size = new System.Drawing.Size(347, 21);
            this.txtCompositor.TabIndex = 5;
            this.txtCompositor.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(11, 41);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 45;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblCompositor
            // 
            this.lblCompositor.AutoSize = true;
            this.lblCompositor.Location = new System.Drawing.Point(11, 68);
            this.lblCompositor.Name = "lblCompositor";
            this.lblCompositor.Size = new System.Drawing.Size(65, 13);
            this.lblCompositor.TabIndex = 15;
            this.lblCompositor.Text = "Compositor:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(11, 14);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Código:";
            // 
            // frmMetodo
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(449, 292);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlMetodo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMetodo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Métodos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMetodo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMetodo_FormClosed);
            this.Load += new System.EventHandler(this.frmMetodo_Load);
            this.pnlMetodo.ResumeLayout(false);
            this.pnlMetodo.PerformLayout();
            this.gpoEscolha.ResumeLayout(false);
            this.gpoEscolha.PerformLayout();
            this.gpoInstrumento.ResumeLayout(false);
            this.gpoInstrumento.PerformLayout();
            this.gpoTipo.ResumeLayout(false);
            this.gpoTipo.PerformLayout();
            this.gpoFamilia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridMetodoFamilia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip tipMetodo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlMetodo;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.GroupBox gpoTipo;
        private System.Windows.Forms.RadioButton optInstrumento;
        private System.Windows.Forms.RadioButton optSolfejo;
        private System.Windows.Forms.GroupBox gpoFamilia;
        private BLL.validacoes.Controles.DataGridViewPersonal gridMetodoFamilia;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCompositor;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCompositor;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.RadioButton optRitmo;
        private System.Windows.Forms.GroupBox gpoEscolha;
        private System.Windows.Forms.RadioButton optCandidato;
        private System.Windows.Forms.Label lblTipoEscolha;
        private System.Windows.Forms.RadioButton optSistema;
        private System.Windows.Forms.GroupBox gpoInstrumento;
        private System.Windows.Forms.RadioButton optFase;
        private System.Windows.Forms.RadioButton optPagina;
        private System.Windows.Forms.Label lblPaginaFase;
        private System.Windows.Forms.RadioButton optLicao;
    }
}