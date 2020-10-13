namespace ccbpess
{
    partial class frmCidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCidade));
            this.pnlCidade = new System.Windows.Forms.Panel();
            this.txtComplemento = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblComplemento = new System.Windows.Forms.Label();
            this.cboUf = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtCep = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtBairro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtTipo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtEndereco = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCidade = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblUf = new System.Windows.Forms.Label();
            this.lblBairro = new System.Windows.Forms.Label();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblCep = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.tipCidade = new System.Windows.Forms.ToolTip(this.components);
            this.pnlCidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCidade
            // 
            this.pnlCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCidade.Controls.Add(this.txtComplemento);
            this.pnlCidade.Controls.Add(this.lblComplemento);
            this.pnlCidade.Controls.Add(this.cboUf);
            this.pnlCidade.Controls.Add(this.txtCep);
            this.pnlCidade.Controls.Add(this.txtBairro);
            this.pnlCidade.Controls.Add(this.txtTipo);
            this.pnlCidade.Controls.Add(this.txtEndereco);
            this.pnlCidade.Controls.Add(this.txtCidade);
            this.pnlCidade.Controls.Add(this.txtCodigo);
            this.pnlCidade.Controls.Add(this.lblUf);
            this.pnlCidade.Controls.Add(this.lblBairro);
            this.pnlCidade.Controls.Add(this.lblEndereco);
            this.pnlCidade.Controls.Add(this.lblCep);
            this.pnlCidade.Controls.Add(this.lblCidade);
            this.pnlCidade.Controls.Add(this.lblCodigo);
            this.pnlCidade.Location = new System.Drawing.Point(8, 8);
            this.pnlCidade.Name = "pnlCidade";
            this.pnlCidade.Size = new System.Drawing.Size(530, 194);
            this.pnlCidade.TabIndex = 1;
            // 
            // txtComplemento
            // 
            this.txtComplemento.BackColor = System.Drawing.Color.White;
            this.txtComplemento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComplemento.Location = new System.Drawing.Point(115, 154);
            this.txtComplemento.MaxLength = 100;
            this.txtComplemento.Name = "txtComplemento";
            this.txtComplemento.Size = new System.Drawing.Size(397, 21);
            this.txtComplemento.TabIndex = 7;
            this.tipCidade.SetToolTip(this.txtComplemento, "Complemento");
            this.txtComplemento.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblComplemento
            // 
            this.lblComplemento.AutoSize = true;
            this.lblComplemento.Location = new System.Drawing.Point(16, 158);
            this.lblComplemento.Name = "lblComplemento";
            this.lblComplemento.Size = new System.Drawing.Size(76, 13);
            this.lblComplemento.TabIndex = 8;
            this.lblComplemento.Text = "Complemento:";
            // 
            // cboUf
            // 
            this.cboUf.BackColor = System.Drawing.Color.White;
            this.cboUf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUf.FormattingEnabled = true;
            this.cboUf.Location = new System.Drawing.Point(115, 73);
            this.cboUf.Name = "cboUf";
            this.cboUf.Size = new System.Drawing.Size(72, 21);
            this.cboUf.TabIndex = 1;
            this.tipCidade.SetToolTip(this.cboUf, "Estado");
            // 
            // txtCep
            // 
            this.txtCep.BackColor = System.Drawing.Color.White;
            this.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCep.Location = new System.Drawing.Point(382, 74);
            this.txtCep.MaxLength = 9;
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(130, 21);
            this.txtCep.TabIndex = 2;
            this.txtCep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCidade.SetToolTip(this.txtCep, "Cep");
            this.txtCep.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.White;
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.Location = new System.Drawing.Point(115, 127);
            this.txtBairro.MaxLength = 80;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(397, 21);
            this.txtBairro.TabIndex = 6;
            this.tipCidade.SetToolTip(this.txtBairro, "Bairro");
            this.txtBairro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.White;
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo.Location = new System.Drawing.Point(115, 100);
            this.txtTipo.MaxLength = 20;
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(72, 21);
            this.txtTipo.TabIndex = 3;
            this.tipCidade.SetToolTip(this.txtTipo, "Tipo de endereço.\r\n(Ex. Rua ou Av.)");
            this.txtTipo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.White;
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndereco.Location = new System.Drawing.Point(193, 100);
            this.txtEndereco.MaxLength = 100;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(319, 21);
            this.txtEndereco.TabIndex = 4;
            this.tipCidade.SetToolTip(this.txtEndereco, "Endereço completo");
            this.txtEndereco.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.White;
            this.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCidade.Location = new System.Drawing.Point(115, 46);
            this.txtCidade.MaxLength = 80;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(397, 21);
            this.txtCidade.TabIndex = 0;
            this.tipCidade.SetToolTip(this.txtCidade, "Informe o nome da cidade");
            this.txtCidade.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(115, 19);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(72, 21);
            this.txtCodigo.TabIndex = 8;
            this.txtCodigo.Text = "000000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblUf
            // 
            this.lblUf.AutoSize = true;
            this.lblUf.Location = new System.Drawing.Point(16, 77);
            this.lblUf.Name = "lblUf";
            this.lblUf.Size = new System.Drawing.Size(44, 13);
            this.lblUf.TabIndex = 5;
            this.lblUf.Text = "Estado:";
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(16, 131);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(39, 13);
            this.lblBairro.TabIndex = 4;
            this.lblBairro.Text = "Bairro:";
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(16, 104);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(56, 13);
            this.lblEndereco.TabIndex = 3;
            this.lblEndereco.Text = "Endereço:";
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(326, 78);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(30, 13);
            this.lblCep.TabIndex = 2;
            this.lblCep.Text = "Cep:";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(16, 50);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(82, 13);
            this.lblCidade.TabIndex = 1;
            this.lblCidade.Text = "Cidade/Distrito:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(16, 23);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(447, 207);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(351, 207);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmCidade
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(545, 244);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlCidade);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cidade";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCidade_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCidade_FormClosed);
            this.Load += new System.EventHandler(this.frmCidade_Load);
            this.pnlCidade.ResumeLayout(false);
            this.pnlCidade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCidade;
        private BLL.validacoes.Controles.TextBoxPersonal txtComplemento;
        private System.Windows.Forms.Label lblComplemento;
        private BLL.validacoes.Controles.ComboBoxPersonal cboUf;
        private BLL.validacoes.Controles.TextBoxPersonal txtCep;
        private BLL.validacoes.Controles.TextBoxPersonal txtBairro;
        private BLL.validacoes.Controles.TextBoxPersonal txtTipo;
        private BLL.validacoes.Controles.TextBoxPersonal txtEndereco;
        private BLL.validacoes.Controles.TextBoxPersonal txtCidade;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lblUf;
        private System.Windows.Forms.Label lblBairro;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ToolTip tipCidade;
    }
}