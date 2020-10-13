namespace ccbinst
{
    partial class frmMtsModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMtsModulo));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipCCB = new System.Windows.Forms.ToolTip(this.components);
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cboFase = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.pnlModulo = new System.Windows.Forms.Panel();
            this.lblFase = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlModulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(120, 115);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipCCB.SetToolTip(this.btnSalvar, "Salvar");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(215, 115);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipCCB.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(69, 39);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(213, 21);
            this.txtDescricao.TabIndex = 108;
            this.tipCCB.SetToolTip(this.txtDescricao, "Descrição");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(69, 11);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(64, 21);
            this.txtCodigo.TabIndex = 106;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtCodigo, "Código");
            // 
            // cboFase
            // 
            this.cboFase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFase.FormattingEnabled = true;
            this.cboFase.Location = new System.Drawing.Point(69, 66);
            this.cboFase.Name = "cboFase";
            this.cboFase.Size = new System.Drawing.Size(213, 21);
            this.cboFase.TabIndex = 112;
            this.tipCCB.SetToolTip(this.cboFase, "Fase");
            // 
            // pnlModulo
            // 
            this.pnlModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModulo.Controls.Add(this.cboFase);
            this.pnlModulo.Controls.Add(this.lblFase);
            this.pnlModulo.Controls.Add(this.txtDescricao);
            this.pnlModulo.Controls.Add(this.lblDescricao);
            this.pnlModulo.Controls.Add(this.txtCodigo);
            this.pnlModulo.Controls.Add(this.lblCodigo);
            this.pnlModulo.Location = new System.Drawing.Point(7, 7);
            this.pnlModulo.Name = "pnlModulo";
            this.pnlModulo.Size = new System.Drawing.Size(297, 103);
            this.pnlModulo.TabIndex = 5;
            // 
            // lblFase
            // 
            this.lblFase.AutoSize = true;
            this.lblFase.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblFase.Location = new System.Drawing.Point(8, 70);
            this.lblFase.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFase.Name = "lblFase";
            this.lblFase.Size = new System.Drawing.Size(34, 13);
            this.lblFase.TabIndex = 111;
            this.lblFase.Text = "Fase:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(8, 42);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 109;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(8, 14);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // frmMtsModulo
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(311, 153);
            this.Controls.Add(this.pnlModulo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMtsModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMtsModulo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMtsModulo_FormClosed);
            this.Load += new System.EventHandler(this.frmMtsModulo_Load);
            this.pnlModulo.ResumeLayout(false);
            this.pnlModulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipCCB;
        private System.Windows.Forms.Panel pnlModulo;
        private System.Windows.Forms.Label lblFase;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboFase;
    }
}