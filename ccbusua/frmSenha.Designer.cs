namespace ccbusua
{
    partial class frmSenha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSenha));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipSenha = new System.Windows.Forms.ToolTip(this.components);
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPessoa = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodUsuario = new System.Windows.Forms.TextBox();
            this.txtSenhaAtual = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtNovaSenha = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtConfirme = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlSenha = new System.Windows.Forms.Panel();
            this.gpoSenha = new System.Windows.Forms.GroupBox();
            this.lblConfirme = new System.Windows.Forms.Label();
            this.lblNovaSenha = new System.Windows.Forms.Label();
            this.txtDataAlteraSenha = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataAlteraSenha = new System.Windows.Forms.Label();
            this.lblSenhaAnterior = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblPessoa = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlSenha.SuspendLayout();
            this.gpoSenha.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(169, 242);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipSenha.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(264, 242);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipSenha.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.SystemColors.Window;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtUsuario.Location = new System.Drawing.Point(221, 17);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUsuario.MaxLength = 25;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(107, 21);
            this.txtUsuario.TabIndex = 110;
            this.tipSenha.SetToolTip(this.txtUsuario, "Usuário");
            // 
            // txtPessoa
            // 
            this.txtPessoa.BackColor = System.Drawing.Color.White;
            this.txtPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPessoa.Enabled = false;
            this.txtPessoa.Location = new System.Drawing.Point(67, 45);
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(261, 21);
            this.txtPessoa.TabIndex = 108;
            this.tipSenha.SetToolTip(this.txtPessoa, "Nome da Pessoa");
            this.txtPessoa.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodUsuario
            // 
            this.txtCodUsuario.BackColor = System.Drawing.Color.LightGray;
            this.txtCodUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodUsuario.Enabled = false;
            this.txtCodUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodUsuario.Location = new System.Drawing.Point(67, 16);
            this.txtCodUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodUsuario.MaxLength = 6;
            this.txtCodUsuario.Name = "txtCodUsuario";
            this.txtCodUsuario.Size = new System.Drawing.Size(51, 21);
            this.txtCodUsuario.TabIndex = 106;
            this.txtCodUsuario.Text = "00000";
            this.txtCodUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipSenha.SetToolTip(this.txtCodUsuario, "Código");
            // 
            // txtSenhaAtual
            // 
            this.txtSenhaAtual.BackColor = System.Drawing.Color.White;
            this.txtSenhaAtual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenhaAtual.Location = new System.Drawing.Point(91, 19);
            this.txtSenhaAtual.MaxLength = 20;
            this.txtSenhaAtual.Name = "txtSenhaAtual";
            this.txtSenhaAtual.Size = new System.Drawing.Size(147, 21);
            this.txtSenhaAtual.TabIndex = 117;
            this.tipSenha.SetToolTip(this.txtSenhaAtual, "Informe a Senha Atual");
            this.txtSenhaAtual.UseSystemPasswordChar = true;
            this.txtSenhaAtual.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtNovaSenha
            // 
            this.txtNovaSenha.BackColor = System.Drawing.Color.White;
            this.txtNovaSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNovaSenha.Location = new System.Drawing.Point(91, 46);
            this.txtNovaSenha.MaxLength = 20;
            this.txtNovaSenha.Name = "txtNovaSenha";
            this.txtNovaSenha.Size = new System.Drawing.Size(147, 21);
            this.txtNovaSenha.TabIndex = 121;
            this.tipSenha.SetToolTip(this.txtNovaSenha, "Informe a Nova Senha");
            this.txtNovaSenha.UseSystemPasswordChar = true;
            this.txtNovaSenha.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtConfirme
            // 
            this.txtConfirme.BackColor = System.Drawing.Color.White;
            this.txtConfirme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirme.Location = new System.Drawing.Point(91, 73);
            this.txtConfirme.MaxLength = 20;
            this.txtConfirme.Name = "txtConfirme";
            this.txtConfirme.Size = new System.Drawing.Size(147, 21);
            this.txtConfirme.TabIndex = 123;
            this.tipSenha.SetToolTip(this.txtConfirme, "Confirme a Nova Senha");
            this.txtConfirme.UseSystemPasswordChar = true;
            this.txtConfirme.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtConfirme.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirme_Validating);
            // 
            // pnlSenha
            // 
            this.pnlSenha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSenha.Controls.Add(this.gpoSenha);
            this.pnlSenha.Controls.Add(this.txtUsuario);
            this.pnlSenha.Controls.Add(this.lblUsuario);
            this.pnlSenha.Controls.Add(this.txtPessoa);
            this.pnlSenha.Controls.Add(this.lblPessoa);
            this.pnlSenha.Controls.Add(this.txtCodUsuario);
            this.pnlSenha.Controls.Add(this.lblCodigo);
            this.pnlSenha.Location = new System.Drawing.Point(9, 9);
            this.pnlSenha.Name = "pnlSenha";
            this.pnlSenha.Size = new System.Drawing.Size(345, 226);
            this.pnlSenha.TabIndex = 5;
            // 
            // gpoSenha
            // 
            this.gpoSenha.Controls.Add(this.txtConfirme);
            this.gpoSenha.Controls.Add(this.lblConfirme);
            this.gpoSenha.Controls.Add(this.txtNovaSenha);
            this.gpoSenha.Controls.Add(this.lblNovaSenha);
            this.gpoSenha.Controls.Add(this.txtDataAlteraSenha);
            this.gpoSenha.Controls.Add(this.lblDataAlteraSenha);
            this.gpoSenha.Controls.Add(this.txtSenhaAtual);
            this.gpoSenha.Controls.Add(this.lblSenhaAnterior);
            this.gpoSenha.Location = new System.Drawing.Point(67, 75);
            this.gpoSenha.Name = "gpoSenha";
            this.gpoSenha.Size = new System.Drawing.Size(261, 137);
            this.gpoSenha.TabIndex = 112;
            this.gpoSenha.TabStop = false;
            this.gpoSenha.Text = "Alteração de Senha";
            // 
            // lblConfirme
            // 
            this.lblConfirme.AutoSize = true;
            this.lblConfirme.Location = new System.Drawing.Point(16, 77);
            this.lblConfirme.Name = "lblConfirme";
            this.lblConfirme.Size = new System.Drawing.Size(71, 13);
            this.lblConfirme.TabIndex = 122;
            this.lblConfirme.Text = "Confirmação:";
            // 
            // lblNovaSenha
            // 
            this.lblNovaSenha.AutoSize = true;
            this.lblNovaSenha.Location = new System.Drawing.Point(16, 50);
            this.lblNovaSenha.Name = "lblNovaSenha";
            this.lblNovaSenha.Size = new System.Drawing.Size(69, 13);
            this.lblNovaSenha.TabIndex = 120;
            this.lblNovaSenha.Text = "Nova Senha:";
            // 
            // txtDataAlteraSenha
            // 
            this.txtDataAlteraSenha.BackColor = System.Drawing.Color.LightGray;
            this.txtDataAlteraSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataAlteraSenha.Enabled = false;
            this.txtDataAlteraSenha.Location = new System.Drawing.Point(133, 100);
            this.txtDataAlteraSenha.MaxLength = 10;
            this.txtDataAlteraSenha.Name = "txtDataAlteraSenha";
            this.txtDataAlteraSenha.ReadOnly = true;
            this.txtDataAlteraSenha.Size = new System.Drawing.Size(105, 21);
            this.txtDataAlteraSenha.TabIndex = 118;
            this.txtDataAlteraSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataAlteraSenha.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblDataAlteraSenha
            // 
            this.lblDataAlteraSenha.AutoSize = true;
            this.lblDataAlteraSenha.Enabled = false;
            this.lblDataAlteraSenha.Location = new System.Drawing.Point(16, 104);
            this.lblDataAlteraSenha.Name = "lblDataAlteraSenha";
            this.lblDataAlteraSenha.Size = new System.Drawing.Size(116, 13);
            this.lblDataAlteraSenha.TabIndex = 119;
            this.lblDataAlteraSenha.Text = "Data Alteração Senha:";
            // 
            // lblSenhaAnterior
            // 
            this.lblSenhaAnterior.AutoSize = true;
            this.lblSenhaAnterior.Location = new System.Drawing.Point(16, 23);
            this.lblSenhaAnterior.Name = "lblSenhaAnterior";
            this.lblSenhaAnterior.Size = new System.Drawing.Size(69, 13);
            this.lblSenhaAnterior.TabIndex = 116;
            this.lblSenhaAnterior.Text = "Senha Atual:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblUsuario.Location = new System.Drawing.Point(146, 20);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(76, 13);
            this.lblUsuario.TabIndex = 111;
            this.lblUsuario.Text = "Login/Usuário:";
            // 
            // lblPessoa
            // 
            this.lblPessoa.AutoSize = true;
            this.lblPessoa.Enabled = false;
            this.lblPessoa.Location = new System.Drawing.Point(8, 48);
            this.lblPessoa.Name = "lblPessoa";
            this.lblPessoa.Size = new System.Drawing.Size(45, 13);
            this.lblPessoa.TabIndex = 109;
            this.lblPessoa.Text = "Pessoa:";
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
            // frmSenha
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(361, 282);
            this.Controls.Add(this.pnlSenha);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSenha";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar Senha do usuário";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSenha_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSenha_FormClosed);
            this.Load += new System.EventHandler(this.frmSenha_Load);
            this.pnlSenha.ResumeLayout(false);
            this.pnlSenha.PerformLayout();
            this.gpoSenha.ResumeLayout(false);
            this.gpoSenha.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipSenha;
        private System.Windows.Forms.Panel pnlSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private BLL.validacoes.Controles.TextBoxPersonal txtPessoa;
        private System.Windows.Forms.Label lblPessoa;
        private System.Windows.Forms.TextBox txtCodUsuario;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gpoSenha;
        private BLL.validacoes.Controles.TextBoxPersonal txtConfirme;
        private System.Windows.Forms.Label lblConfirme;
        private BLL.validacoes.Controles.TextBoxPersonal txtNovaSenha;
        private System.Windows.Forms.Label lblNovaSenha;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataAlteraSenha;
        private System.Windows.Forms.Label lblDataAlteraSenha;
        private BLL.validacoes.Controles.TextBoxPersonal txtSenhaAtual;
        private System.Windows.Forms.Label lblSenhaAnterior;
    }
}