namespace ccbusua
{
    partial class frmModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModulo));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlModulo = new System.Windows.Forms.Panel();
            this.txtNivel = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblMod = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.tipModulo = new System.Windows.Forms.ToolTip(this.components);
            this.pnlModulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.Location = new System.Drawing.Point(213, 114);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 28);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipModulo.SetToolTip(this.btnSalvar, "Salvar");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(291, 114);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipModulo.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlModulo
            // 
            this.pnlModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModulo.Controls.Add(this.txtNivel);
            this.pnlModulo.Controls.Add(this.txtCodigo);
            this.pnlModulo.Controls.Add(this.txtDesc);
            this.pnlModulo.Controls.Add(this.lblNivel);
            this.pnlModulo.Controls.Add(this.lblMod);
            this.pnlModulo.Controls.Add(this.lblCod);
            this.pnlModulo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pnlModulo.Location = new System.Drawing.Point(6, 6);
            this.pnlModulo.Name = "pnlModulo";
            this.pnlModulo.Size = new System.Drawing.Size(360, 105);
            this.pnlModulo.TabIndex = 0;
            // 
            // txtNivel
            // 
            this.txtNivel.BackColor = System.Drawing.Color.White;
            this.txtNivel.Enabled = false;
            this.txtNivel.Location = new System.Drawing.Point(78, 63);
            this.txtNivel.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(54, 21);
            this.txtNivel.TabIndex = 1;
            this.txtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipModulo.SetToolTip(this.txtNivel, "Nível do módulo");
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(78, 9);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(54, 21);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.Text = "000000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipModulo.SetToolTip(this.txtCodigo, "Código");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(78, 36);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(263, 21);
            this.txtDesc.TabIndex = 0;
            this.tipModulo.SetToolTip(this.txtDesc, "Descrição do módulo");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(15, 67);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(34, 13);
            this.lblNivel.TabIndex = 5;
            this.lblNivel.Text = "Nível:";
            // 
            // lblMod
            // 
            this.lblMod.AutoSize = true;
            this.lblMod.Location = new System.Drawing.Point(15, 41);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(57, 13);
            this.lblMod.TabIndex = 4;
            this.lblMod.Text = "Descrição:";
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Enabled = false;
            this.lblCod.Location = new System.Drawing.Point(15, 12);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(44, 13);
            this.lblCod.TabIndex = 0;
            this.lblCod.Text = "Código:";
            // 
            // frmModulo
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(372, 148);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlModulo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmModulo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmModulo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModulo_FormClosed);
            this.Load += new System.EventHandler(this.frmModulo_Load);
            this.pnlModulo.ResumeLayout(false);
            this.pnlModulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipModulo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlModulo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.Label lblCod;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtNivel;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
    }
}