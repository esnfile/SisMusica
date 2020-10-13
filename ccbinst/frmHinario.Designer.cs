namespace ccbinst
{
    partial class frmHinario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHinario));
            this.tipHinario = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.cboTonalidade = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.pnlHinario = new System.Windows.Forms.Panel();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblTonalidade = new System.Windows.Forms.Label();
            this.gpoInstrumento = new System.Windows.Forms.GroupBox();
            this.gridInstrumento = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.lbTonalidade = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlHinario.SuspendLayout();
            this.gpoInstrumento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInstrumento)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(177, 273);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "&Salvar";
            this.tipHinario.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(271, 273);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.tipHinario.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Silver;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(77, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(69, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipHinario.SetToolTip(this.txtCodigo, "Código");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // cboTonalidade
            // 
            this.cboTonalidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTonalidade.FormattingEnabled = true;
            this.cboTonalidade.Location = new System.Drawing.Point(77, 67);
            this.cboTonalidade.Name = "cboTonalidade";
            this.cboTonalidade.Size = new System.Drawing.Size(121, 21);
            this.cboTonalidade.TabIndex = 3;
            this.tipHinario.SetToolTip(this.cboTonalidade, "Seleciona a tonalidade do hinário");
            this.cboTonalidade.SelectedIndexChanged += new System.EventHandler(this.cboTonalidade_SelectedIndexChanged);
            // 
            // pnlHinario
            // 
            this.pnlHinario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlHinario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHinario.Controls.Add(this.txtDescricao);
            this.pnlHinario.Controls.Add(this.lblDescricao);
            this.pnlHinario.Controls.Add(this.lblTonalidade);
            this.pnlHinario.Controls.Add(this.gpoInstrumento);
            this.pnlHinario.Controls.Add(this.txtCodigo);
            this.pnlHinario.Controls.Add(this.lbTonalidade);
            this.pnlHinario.Controls.Add(this.cboTonalidade);
            this.pnlHinario.Controls.Add(this.lblCodigo);
            this.pnlHinario.Location = new System.Drawing.Point(10, 10);
            this.pnlHinario.Name = "pnlHinario";
            this.pnlHinario.Size = new System.Drawing.Size(351, 259);
            this.pnlHinario.TabIndex = 0;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(77, 40);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(248, 21);
            this.txtDescricao.TabIndex = 2;
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(10, 44);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 111;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblTonalidade
            // 
            this.lblTonalidade.Location = new System.Drawing.Point(247, 49);
            this.lblTonalidade.Name = "lblTonalidade";
            this.lblTonalidade.Size = new System.Drawing.Size(78, 17);
            this.lblTonalidade.TabIndex = 30;
            // 
            // gpoInstrumento
            // 
            this.gpoInstrumento.Controls.Add(this.gridInstrumento);
            this.gpoInstrumento.Location = new System.Drawing.Point(8, 93);
            this.gpoInstrumento.Name = "gpoInstrumento";
            this.gpoInstrumento.Size = new System.Drawing.Size(334, 155);
            this.gpoInstrumento.TabIndex = 4;
            this.gpoInstrumento.TabStop = false;
            this.gpoInstrumento.Text = "Instrumentos que utilizam esse hinário";
            // 
            // gridInstrumento
            // 
            this.gridInstrumento.AllowUserToAddRows = false;
            this.gridInstrumento.AllowUserToDeleteRows = false;
            this.gridInstrumento.AllowUserToResizeRows = false;
            this.gridInstrumento.BackgroundColor = System.Drawing.Color.White;
            this.gridInstrumento.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridInstrumento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridInstrumento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInstrumento.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridInstrumento.DisabledCell = null;
            this.gridInstrumento.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridInstrumento.EnableHeadersVisualStyles = false;
            this.gridInstrumento.Location = new System.Drawing.Point(8, 17);
            this.gridInstrumento.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridInstrumento.MultiSelect = false;
            this.gridInstrumento.Name = "gridInstrumento";
            this.gridInstrumento.ReadOnly = true;
            this.gridInstrumento.RowHeadersVisible = false;
            this.gridInstrumento.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridInstrumento.RowTemplate.Height = 18;
            this.gridInstrumento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridInstrumento.Size = new System.Drawing.Size(318, 130);
            this.gridInstrumento.TabIndex = 5;
            // 
            // lbTonalidade
            // 
            this.lbTonalidade.AutoSize = true;
            this.lbTonalidade.Location = new System.Drawing.Point(10, 70);
            this.lbTonalidade.Name = "lbTonalidade";
            this.lbTonalidade.Size = new System.Drawing.Size(63, 13);
            this.lbTonalidade.TabIndex = 21;
            this.lbTonalidade.Text = "Tonalidade:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(10, 17);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Código:";
            // 
            // frmHinario
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(365, 311);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlHinario);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmHinario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hinário";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHinario_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmHinario_FormClosed);
            this.Load += new System.EventHandler(this.frmHinario_Load);
            this.pnlHinario.ResumeLayout(false);
            this.pnlHinario.PerformLayout();
            this.gpoInstrumento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInstrumento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipHinario;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlHinario;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lbTonalidade;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTonalidade;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gpoInstrumento;
        private BLL.validacoes.Controles.DataGridViewPersonal gridInstrumento;
        private System.Windows.Forms.Label lblTonalidade;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
    }
}