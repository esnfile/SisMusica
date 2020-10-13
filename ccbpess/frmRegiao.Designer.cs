namespace ccbpess
{
    partial class frmRegiao
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
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipCCB = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigoRegiao = new System.Windows.Forms.TextBox();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtRegional = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlRegiao = new System.Windows.Forms.Panel();
            this.lblDescricaoRegional = new System.Windows.Forms.Label();
            this.btnRegional = new System.Windows.Forms.Button();
            this.lbRegional = new System.Windows.Forms.Label();
            this.lblCodigoCCB = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlRegiao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(293, 178);
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
            this.btnCancelar.Location = new System.Drawing.Point(388, 178);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipCCB.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigoRegiao
            // 
            this.txtCodigoRegiao.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoRegiao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigoRegiao.Location = new System.Drawing.Point(94, 49);
            this.txtCodigoRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigoRegiao.MaxLength = 6;
            this.txtCodigoRegiao.Name = "txtCodigoRegiao";
            this.txtCodigoRegiao.Size = new System.Drawing.Size(136, 24);
            this.txtCodigoRegiao.TabIndex = 110;
            this.tipCCB.SetToolTip(this.txtCodigoRegiao, "Código definido");
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(94, 82);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(358, 24);
            this.txtDescricao.TabIndex = 108;
            this.tipCCB.SetToolTip(this.txtDescricao, "Define um nome para a Comum Congregação\r\nEx. Central");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(94, 16);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(64, 24);
            this.txtCodigo.TabIndex = 106;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtCodigo, "Código");
            // 
            // txtRegional
            // 
            this.txtRegional.BackColor = System.Drawing.Color.White;
            this.txtRegional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRegional.Location = new System.Drawing.Point(94, 115);
            this.txtRegional.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtRegional.Name = "txtRegional";
            this.txtRegional.Size = new System.Drawing.Size(62, 24);
            this.txtRegional.TabIndex = 115;
            this.tipCCB.SetToolTip(this.txtRegional, "Informe a Regional, ou clique na lupa para buscar");
            this.txtRegional.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtRegional.Leave += new System.EventHandler(this.txtRegional_Leave);
            // 
            // pnlRegiao
            // 
            this.pnlRegiao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRegiao.Controls.Add(this.lblDescricaoRegional);
            this.pnlRegiao.Controls.Add(this.btnRegional);
            this.pnlRegiao.Controls.Add(this.txtRegional);
            this.pnlRegiao.Controls.Add(this.lbRegional);
            this.pnlRegiao.Controls.Add(this.txtCodigoRegiao);
            this.pnlRegiao.Controls.Add(this.lblCodigoCCB);
            this.pnlRegiao.Controls.Add(this.txtDescricao);
            this.pnlRegiao.Controls.Add(this.lblDescricao);
            this.pnlRegiao.Controls.Add(this.txtCodigo);
            this.pnlRegiao.Controls.Add(this.lblCodigo);
            this.pnlRegiao.Location = new System.Drawing.Point(9, 9);
            this.pnlRegiao.Name = "pnlRegiao";
            this.pnlRegiao.Size = new System.Drawing.Size(469, 162);
            this.pnlRegiao.TabIndex = 5;
            // 
            // lblDescricaoRegional
            // 
            this.lblDescricaoRegional.Location = new System.Drawing.Point(194, 119);
            this.lblDescricaoRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoRegional.Name = "lblDescricaoRegional";
            this.lblDescricaoRegional.Size = new System.Drawing.Size(255, 17);
            this.lblDescricaoRegional.TabIndex = 119;
            // 
            // btnRegional
            // 
            this.btnRegional.Image = global::ccbpess.Properties.Resources.Lupa;
            this.btnRegional.Location = new System.Drawing.Point(162, 115);
            this.btnRegional.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRegional.Name = "btnRegional";
            this.btnRegional.Size = new System.Drawing.Size(25, 25);
            this.btnRegional.TabIndex = 117;
            this.btnRegional.UseVisualStyleBackColor = true;
            this.btnRegional.Click += new System.EventHandler(this.btnRegional_Click);
            // 
            // lbRegional
            // 
            this.lbRegional.AutoSize = true;
            this.lbRegional.Location = new System.Drawing.Point(7, 119);
            this.lbRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRegional.Name = "lbRegional";
            this.lbRegional.Size = new System.Drawing.Size(64, 17);
            this.lbRegional.TabIndex = 116;
            this.lbRegional.Text = "Regional:";
            // 
            // lblCodigoCCB
            // 
            this.lblCodigoCCB.AutoSize = true;
            this.lblCodigoCCB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigoCCB.Location = new System.Drawing.Point(8, 52);
            this.lblCodigoCCB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigoCCB.Name = "lblCodigoCCB";
            this.lblCodigoCCB.Size = new System.Drawing.Size(88, 17);
            this.lblCodigoCCB.TabIndex = 111;
            this.lblCodigoCCB.Text = "Identificador:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(8, 85);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(72, 17);
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
            this.lblCodigo.Size = new System.Drawing.Size(56, 17);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // frmRegiao
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(488, 217);
            this.Controls.Add(this.pnlRegiao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmRegiao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Região";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRegiao_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegiao_FormClosed);
            this.Load += new System.EventHandler(this.frmRegiao_Load);
            this.pnlRegiao.ResumeLayout(false);
            this.pnlRegiao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipCCB;
        private System.Windows.Forms.Panel pnlRegiao;
        private System.Windows.Forms.TextBox txtCodigoRegiao;
        private System.Windows.Forms.Label lblCodigoCCB;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblDescricaoRegional;
        private System.Windows.Forms.Button btnRegional;
        private BLL.validacoes.Controles.TextBoxPersonal txtRegional;
        private System.Windows.Forms.Label lbRegional;
    }
}