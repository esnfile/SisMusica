namespace ccbutil
{
    partial class frmRegional
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegional));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipCCB = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodRegional = new System.Windows.Forms.TextBox();
            this.pnlRegional = new System.Windows.Forms.Panel();
            this.cboEstado = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblCodigoCCB = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlRegional.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(293, 147);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipCCB.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(388, 147);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipCCB.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(94, 44);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(136, 21);
            this.txtCodigo.TabIndex = 110;
            this.tipCCB.SetToolTip(this.txtCodigo, "Identificação definida pelo Usuário");
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(94, 72);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(358, 21);
            this.txtDescricao.TabIndex = 108;
            this.tipCCB.SetToolTip(this.txtDescricao, "Define um nome para a Comum Congregação\r\nEx. Central");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodRegional
            // 
            this.txtCodRegional.BackColor = System.Drawing.Color.LightGray;
            this.txtCodRegional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodRegional.Enabled = false;
            this.txtCodRegional.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodRegional.Location = new System.Drawing.Point(94, 16);
            this.txtCodRegional.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodRegional.MaxLength = 6;
            this.txtCodRegional.Name = "txtCodRegional";
            this.txtCodRegional.Size = new System.Drawing.Size(64, 21);
            this.txtCodRegional.TabIndex = 106;
            this.txtCodRegional.Text = "00000";
            this.txtCodRegional.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtCodRegional, "Código");
            // 
            // pnlRegional
            // 
            this.pnlRegional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlRegional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegional.Controls.Add(this.cboEstado);
            this.pnlRegional.Controls.Add(this.lblEstado);
            this.pnlRegional.Controls.Add(this.txtCodigo);
            this.pnlRegional.Controls.Add(this.lblCodigoCCB);
            this.pnlRegional.Controls.Add(this.txtDescricao);
            this.pnlRegional.Controls.Add(this.lblDescricao);
            this.pnlRegional.Controls.Add(this.txtCodRegional);
            this.pnlRegional.Controls.Add(this.lblCodigo);
            this.pnlRegional.Location = new System.Drawing.Point(9, 9);
            this.pnlRegional.Name = "pnlRegional";
            this.pnlRegional.Size = new System.Drawing.Size(469, 133);
            this.pnlRegional.TabIndex = 5;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(94, 99);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(64, 21);
            this.cboEstado.TabIndex = 113;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(8, 103);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(44, 13);
            this.lblEstado.TabIndex = 112;
            this.lblEstado.Text = "Estado:";
            // 
            // lblCodigoCCB
            // 
            this.lblCodigoCCB.AutoSize = true;
            this.lblCodigoCCB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigoCCB.Location = new System.Drawing.Point(8, 47);
            this.lblCodigoCCB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigoCCB.Name = "lblCodigoCCB";
            this.lblCodigoCCB.Size = new System.Drawing.Size(72, 13);
            this.lblCodigoCCB.TabIndex = 111;
            this.lblCodigoCCB.Text = "Identificador:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(8, 75);
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
            this.lblCodigo.Location = new System.Drawing.Point(8, 19);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // frmRegional
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(488, 187);
            this.Controls.Add(this.pnlRegional);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRegional";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centro de Região";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegional_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegional_FormClosed);
            this.Load += new System.EventHandler(this.frmRegional_Load);
            this.pnlRegional.ResumeLayout(false);
            this.pnlRegional.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipCCB;
        private System.Windows.Forms.Panel pnlRegional;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigoCCB;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodRegional;
        private System.Windows.Forms.Label lblCodigo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboEstado;
        private System.Windows.Forms.Label lblEstado;
    }
}