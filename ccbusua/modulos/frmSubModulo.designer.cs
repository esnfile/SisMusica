namespace ccbusua
{
    partial class frmSubModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubModulo));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlSubModulo = new System.Windows.Forms.Panel();
            this.txtNivelMod = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNivelMod = new System.Windows.Forms.Label();
            this.txtModulo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescModulo = new System.Windows.Forms.Label();
            this.btnModulo = new System.Windows.Forms.Button();
            this.lbModulo = new System.Windows.Forms.Label();
            this.txtNivel = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.tipModulo = new System.Windows.Forms.ToolTip(this.components);
            this.pnlSubModulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.Location = new System.Drawing.Point(255, 132);
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
            this.btnCancelar.Location = new System.Drawing.Point(333, 132);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipModulo.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlSubModulo
            // 
            this.pnlSubModulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlSubModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubModulo.Controls.Add(this.txtNivelMod);
            this.pnlSubModulo.Controls.Add(this.lblNivelMod);
            this.pnlSubModulo.Controls.Add(this.txtModulo);
            this.pnlSubModulo.Controls.Add(this.lblDescModulo);
            this.pnlSubModulo.Controls.Add(this.btnModulo);
            this.pnlSubModulo.Controls.Add(this.lbModulo);
            this.pnlSubModulo.Controls.Add(this.txtNivel);
            this.pnlSubModulo.Controls.Add(this.txtCodigo);
            this.pnlSubModulo.Controls.Add(this.txtDesc);
            this.pnlSubModulo.Controls.Add(this.lblNivel);
            this.pnlSubModulo.Controls.Add(this.lblDesc);
            this.pnlSubModulo.Controls.Add(this.lblCod);
            this.pnlSubModulo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pnlSubModulo.Location = new System.Drawing.Point(6, 6);
            this.pnlSubModulo.Name = "pnlSubModulo";
            this.pnlSubModulo.Size = new System.Drawing.Size(402, 123);
            this.pnlSubModulo.TabIndex = 0;
            // 
            // txtNivelMod
            // 
            this.txtNivelMod.BackColor = System.Drawing.Color.LightGray;
            this.txtNivelMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNivelMod.Enabled = false;
            this.txtNivelMod.Location = new System.Drawing.Point(339, 36);
            this.txtNivelMod.MaxLength = 2;
            this.txtNivelMod.Name = "txtNivelMod";
            this.txtNivelMod.Size = new System.Drawing.Size(45, 21);
            this.txtNivelMod.TabIndex = 2;
            this.txtNivelMod.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // lblNivelMod
            // 
            this.lblNivelMod.AutoSize = true;
            this.lblNivelMod.Enabled = false;
            this.lblNivelMod.Location = new System.Drawing.Point(304, 40);
            this.lblNivelMod.Name = "lblNivelMod";
            this.lblNivelMod.Size = new System.Drawing.Size(34, 13);
            this.lblNivelMod.TabIndex = 20;
            this.lblNivelMod.Text = "Nível:";
            // 
            // txtModulo
            // 
            this.txtModulo.BackColor = System.Drawing.Color.White;
            this.txtModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModulo.Location = new System.Drawing.Point(78, 36);
            this.txtModulo.MaxLength = 10;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(47, 21);
            this.txtModulo.TabIndex = 0;
            this.txtModulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtModulo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtModulo.Leave += new System.EventHandler(this.txtModulo_Leave);
            // 
            // lblDescModulo
            // 
            this.lblDescModulo.Location = new System.Drawing.Point(150, 40);
            this.lblDescModulo.Name = "lblDescModulo";
            this.lblDescModulo.Size = new System.Drawing.Size(148, 13);
            this.lblDescModulo.TabIndex = 19;
            this.lblDescModulo.UseCompatibleTextRendering = true;
            // 
            // btnModulo
            // 
            this.btnModulo.Image = global::ccbusua.Properties.Resources.Lupa;
            this.btnModulo.Location = new System.Drawing.Point(127, 35);
            this.btnModulo.Name = "btnModulo";
            this.btnModulo.Size = new System.Drawing.Size(23, 23);
            this.btnModulo.TabIndex = 1;
            this.btnModulo.UseVisualStyleBackColor = true;
            this.btnModulo.Click += new System.EventHandler(this.btnModulo_Click);
            // 
            // lbModulo
            // 
            this.lbModulo.AutoSize = true;
            this.lbModulo.Location = new System.Drawing.Point(12, 40);
            this.lbModulo.Name = "lbModulo";
            this.lbModulo.Size = new System.Drawing.Size(45, 13);
            this.lbModulo.TabIndex = 18;
            this.lbModulo.Text = "Módulo:";
            // 
            // txtNivel
            // 
            this.txtNivel.BackColor = System.Drawing.Color.White;
            this.txtNivel.Enabled = false;
            this.txtNivel.Location = new System.Drawing.Point(78, 90);
            this.txtNivel.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtNivel.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(69, 21);
            this.txtNivel.TabIndex = 4;
            this.txtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipModulo.SetToolTip(this.txtNivel, "Nível do sub-módulo");
            this.txtNivel.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(78, 9);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(72, 21);
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
            this.txtDesc.Location = new System.Drawing.Point(78, 63);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(306, 21);
            this.txtDesc.TabIndex = 3;
            this.tipModulo.SetToolTip(this.txtDesc, "Descrição do módulo");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(13, 94);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(34, 13);
            this.lblNivel.TabIndex = 5;
            this.lblNivel.Text = "Nível:";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(13, 67);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(67, 13);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Sub-Módulo:";
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(13, 12);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(44, 13);
            this.lblCod.TabIndex = 0;
            this.lblCod.Text = "Código:";
            // 
            // frmSubModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(414, 167);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlSubModulo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSubModulo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSubModulo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSubModulo_FormClosed);
            this.Load += new System.EventHandler(this.frmSubModulo_Load);
            this.pnlSubModulo.ResumeLayout(false);
            this.pnlSubModulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipModulo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlSubModulo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblCod;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtNivel;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtNivelMod;
        private System.Windows.Forms.Label lblNivelMod;
        private BLL.validacoes.Controles.TextBoxPersonal txtModulo;
        private System.Windows.Forms.Label lblDescModulo;
        private System.Windows.Forms.Button btnModulo;
        private System.Windows.Forms.Label lbModulo;
    }
}