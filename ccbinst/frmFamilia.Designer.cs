namespace ccbinst
{
    partial class frmFamilia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFamilia));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipForm = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlFamilia = new System.Windows.Forms.Panel();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.gpoTeste = new System.Windows.Forms.GroupBox();
            this.chkRjm = new System.Windows.Forms.CheckBox();
            this.chkMeiaHora = new System.Windows.Forms.CheckBox();
            this.chkCulto = new System.Windows.Forms.CheckBox();
            this.chkOficial = new System.Windows.Forms.CheckBox();
            this.chkTroca = new System.Windows.Forms.CheckBox();
            this.pnlFamilia.SuspendLayout();
            this.gpoTeste.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(104, 164);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipForm.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(197, 164);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
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
            this.txtCodigo.Location = new System.Drawing.Point(72, 12);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(64, 21);
            this.txtCodigo.TabIndex = 106;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipForm.SetToolTip(this.txtCodigo, "Código");
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(72, 38);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(194, 21);
            this.txtDescricao.TabIndex = 108;
            this.tipForm.SetToolTip(this.txtDescricao, "Descrição");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // pnlFamilia
            // 
            this.pnlFamilia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFamilia.Controls.Add(this.gpoTeste);
            this.pnlFamilia.Controls.Add(this.txtDescricao);
            this.pnlFamilia.Controls.Add(this.lblDescricao);
            this.pnlFamilia.Controls.Add(this.txtCodigo);
            this.pnlFamilia.Controls.Add(this.lblCodigo);
            this.pnlFamilia.Location = new System.Drawing.Point(6, 7);
            this.pnlFamilia.Name = "pnlFamilia";
            this.pnlFamilia.Size = new System.Drawing.Size(280, 153);
            this.pnlFamilia.TabIndex = 5;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(10, 42);
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
            this.lblCodigo.Location = new System.Drawing.Point(10, 16);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // gpoTeste
            // 
            this.gpoTeste.Controls.Add(this.chkTroca);
            this.gpoTeste.Controls.Add(this.chkOficial);
            this.gpoTeste.Controls.Add(this.chkCulto);
            this.gpoTeste.Controls.Add(this.chkMeiaHora);
            this.gpoTeste.Controls.Add(this.chkRjm);
            this.gpoTeste.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoTeste.Location = new System.Drawing.Point(13, 62);
            this.gpoTeste.Name = "gpoTeste";
            this.gpoTeste.Size = new System.Drawing.Size(253, 80);
            this.gpoTeste.TabIndex = 110;
            this.gpoTeste.TabStop = false;
            this.gpoTeste.Text = "Permite teste para?";
            // 
            // chkRjm
            // 
            this.chkRjm.AutoSize = true;
            this.chkRjm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkRjm.Location = new System.Drawing.Point(15, 17);
            this.chkRjm.Name = "chkRjm";
            this.chkRjm.Size = new System.Drawing.Size(117, 17);
            this.chkRjm.TabIndex = 0;
            this.chkRjm.Text = "Reunião de Jovens";
            this.chkRjm.UseVisualStyleBackColor = true;
            // 
            // chkMeiaHora
            // 
            this.chkMeiaHora.AutoSize = true;
            this.chkMeiaHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMeiaHora.Location = new System.Drawing.Point(150, 17);
            this.chkMeiaHora.Name = "chkMeiaHora";
            this.chkMeiaHora.Size = new System.Drawing.Size(74, 17);
            this.chkMeiaHora.TabIndex = 1;
            this.chkMeiaHora.Text = "Meia Hora";
            this.chkMeiaHora.UseVisualStyleBackColor = true;
            // 
            // chkCulto
            // 
            this.chkCulto.AutoSize = true;
            this.chkCulto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCulto.Location = new System.Drawing.Point(15, 36);
            this.chkCulto.Name = "chkCulto";
            this.chkCulto.Size = new System.Drawing.Size(83, 17);
            this.chkCulto.TabIndex = 2;
            this.chkCulto.Text = "Culto Oficial";
            this.chkCulto.UseVisualStyleBackColor = true;
            // 
            // chkOficial
            // 
            this.chkOficial.AutoSize = true;
            this.chkOficial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOficial.Location = new System.Drawing.Point(150, 36);
            this.chkOficial.Name = "chkOficial";
            this.chkOficial.Size = new System.Drawing.Size(85, 17);
            this.chkOficial.TabIndex = 3;
            this.chkOficial.Text = "Oficialização";
            this.chkOficial.UseVisualStyleBackColor = true;
            // 
            // chkTroca
            // 
            this.chkTroca.AutoSize = true;
            this.chkTroca.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTroca.Location = new System.Drawing.Point(15, 55);
            this.chkTroca.Name = "chkTroca";
            this.chkTroca.Size = new System.Drawing.Size(130, 17);
            this.chkTroca.TabIndex = 4;
            this.chkTroca.Text = "Troca de Instrumento";
            this.chkTroca.UseVisualStyleBackColor = true;
            // 
            // frmFamilia
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(292, 201);
            this.Controls.Add(this.pnlFamilia);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFamilia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Familia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFamilia_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFamilia_FormClosed);
            this.Load += new System.EventHandler(this.frmFamilia_Load);
            this.pnlFamilia.ResumeLayout(false);
            this.pnlFamilia.PerformLayout();
            this.gpoTeste.ResumeLayout(false);
            this.gpoTeste.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipForm;
        private System.Windows.Forms.Panel pnlFamilia;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gpoTeste;
        private System.Windows.Forms.CheckBox chkTroca;
        private System.Windows.Forms.CheckBox chkOficial;
        private System.Windows.Forms.CheckBox chkCulto;
        private System.Windows.Forms.CheckBox chkMeiaHora;
        private System.Windows.Forms.CheckBox chkRjm;
    }
}