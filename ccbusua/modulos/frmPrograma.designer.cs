namespace ccbusua
{
    partial class frmPrograma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrograma));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlPrograma = new System.Windows.Forms.Panel();
            this.txtNivelSubMod = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNivelSubMod = new System.Windows.Forms.Label();
            this.txtSubMod = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescSubMod = new System.Windows.Forms.Label();
            this.btnSubMod = new System.Windows.Forms.Button();
            this.lblSubMod = new System.Windows.Forms.Label();
            this.txtNivelMod = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNivelMod = new System.Windows.Forms.Label();
            this.txtNivel = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtModulo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescModulo = new System.Windows.Forms.Label();
            this.lbModulo = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.lblProg = new System.Windows.Forms.Label();
            this.lblCod = new System.Windows.Forms.Label();
            this.tipPrograma = new System.Windows.Forms.ToolTip(this.components);
            this.pnlPrograma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.Location = new System.Drawing.Point(270, 166);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 28);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(348, 166);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlPrograma
            // 
            this.pnlPrograma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlPrograma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrograma.Controls.Add(this.txtNivelSubMod);
            this.pnlPrograma.Controls.Add(this.lblNivelSubMod);
            this.pnlPrograma.Controls.Add(this.txtSubMod);
            this.pnlPrograma.Controls.Add(this.lblDescSubMod);
            this.pnlPrograma.Controls.Add(this.btnSubMod);
            this.pnlPrograma.Controls.Add(this.lblSubMod);
            this.pnlPrograma.Controls.Add(this.txtNivelMod);
            this.pnlPrograma.Controls.Add(this.lblNivelMod);
            this.pnlPrograma.Controls.Add(this.txtNivel);
            this.pnlPrograma.Controls.Add(this.txtDesc);
            this.pnlPrograma.Controls.Add(this.txtModulo);
            this.pnlPrograma.Controls.Add(this.txtCodigo);
            this.pnlPrograma.Controls.Add(this.lblDescModulo);
            this.pnlPrograma.Controls.Add(this.lbModulo);
            this.pnlPrograma.Controls.Add(this.lblNivel);
            this.pnlPrograma.Controls.Add(this.lblProg);
            this.pnlPrograma.Controls.Add(this.lblCod);
            this.pnlPrograma.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.pnlPrograma.Location = new System.Drawing.Point(6, 6);
            this.pnlPrograma.Name = "pnlPrograma";
            this.pnlPrograma.Size = new System.Drawing.Size(416, 156);
            this.pnlPrograma.TabIndex = 0;
            // 
            // txtNivelSubMod
            // 
            this.txtNivelSubMod.BackColor = System.Drawing.Color.LightGray;
            this.txtNivelSubMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNivelSubMod.Enabled = false;
            this.txtNivelSubMod.Location = new System.Drawing.Point(352, 36);
            this.txtNivelSubMod.MaxLength = 2;
            this.txtNivelSubMod.Name = "txtNivelSubMod";
            this.txtNivelSubMod.Size = new System.Drawing.Size(45, 21);
            this.txtNivelSubMod.TabIndex = 2;
            this.tipPrograma.SetToolTip(this.txtNivelSubMod, "Nível Módulo");
            this.txtNivelSubMod.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // lblNivelSubMod
            // 
            this.lblNivelSubMod.AutoSize = true;
            this.lblNivelSubMod.Enabled = false;
            this.lblNivelSubMod.Location = new System.Drawing.Point(317, 40);
            this.lblNivelSubMod.Name = "lblNivelSubMod";
            this.lblNivelSubMod.Size = new System.Drawing.Size(34, 13);
            this.lblNivelSubMod.TabIndex = 20;
            this.lblNivelSubMod.Text = "Nível:";
            // 
            // txtSubMod
            // 
            this.txtSubMod.BackColor = System.Drawing.Color.White;
            this.txtSubMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubMod.Location = new System.Drawing.Point(79, 36);
            this.txtSubMod.MaxLength = 10;
            this.txtSubMod.Name = "txtSubMod";
            this.txtSubMod.Size = new System.Drawing.Size(47, 21);
            this.txtSubMod.TabIndex = 0;
            this.txtSubMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPrograma.SetToolTip(this.txtSubMod, "Código do módulo");
            this.txtSubMod.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtSubMod.Leave += new System.EventHandler(this.txtSubMod_Leave);
            // 
            // lblDescSubMod
            // 
            this.lblDescSubMod.Location = new System.Drawing.Point(151, 40);
            this.lblDescSubMod.Name = "lblDescSubMod";
            this.lblDescSubMod.Size = new System.Drawing.Size(160, 13);
            this.lblDescSubMod.TabIndex = 18;
            this.lblDescSubMod.UseCompatibleTextRendering = true;
            // 
            // btnSubMod
            // 
            this.btnSubMod.Image = global::ccbusua.Properties.Resources.Lupa;
            this.btnSubMod.Location = new System.Drawing.Point(128, 35);
            this.btnSubMod.Name = "btnSubMod";
            this.btnSubMod.Size = new System.Drawing.Size(23, 23);
            this.btnSubMod.TabIndex = 1;
            this.btnSubMod.UseVisualStyleBackColor = true;
            this.btnSubMod.Click += new System.EventHandler(this.btnSubMod_Click);
            // 
            // lblSubMod
            // 
            this.lblSubMod.AutoSize = true;
            this.lblSubMod.Location = new System.Drawing.Point(15, 40);
            this.lblSubMod.Name = "lblSubMod";
            this.lblSubMod.Size = new System.Drawing.Size(67, 13);
            this.lblSubMod.TabIndex = 16;
            this.lblSubMod.Text = "Sub-Módulo:";
            // 
            // txtNivelMod
            // 
            this.txtNivelMod.BackColor = System.Drawing.Color.LightGray;
            this.txtNivelMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNivelMod.Enabled = false;
            this.txtNivelMod.Location = new System.Drawing.Point(352, 63);
            this.txtNivelMod.MaxLength = 2;
            this.txtNivelMod.Name = "txtNivelMod";
            this.txtNivelMod.Size = new System.Drawing.Size(45, 21);
            this.txtNivelMod.TabIndex = 4;
            this.tipPrograma.SetToolTip(this.txtNivelMod, "Nível Módulo");
            this.txtNivelMod.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // lblNivelMod
            // 
            this.lblNivelMod.AutoSize = true;
            this.lblNivelMod.Enabled = false;
            this.lblNivelMod.Location = new System.Drawing.Point(317, 67);
            this.lblNivelMod.Name = "lblNivelMod";
            this.lblNivelMod.Size = new System.Drawing.Size(34, 13);
            this.lblNivelMod.TabIndex = 14;
            this.lblNivelMod.Text = "Nível:";
            // 
            // txtNivel
            // 
            this.txtNivel.BackColor = System.Drawing.Color.White;
            this.txtNivel.Location = new System.Drawing.Point(79, 117);
            this.txtNivel.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txtNivel.Minimum = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(69, 21);
            this.txtNivel.TabIndex = 6;
            this.txtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPrograma.SetToolTip(this.txtNivel, "Nivel do programa");
            this.txtNivel.Value = new decimal(new int[] {
            1001,
            0,
            0,
            0});
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(79, 90);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(318, 21);
            this.txtDesc.TabIndex = 5;
            this.tipPrograma.SetToolTip(this.txtDesc, "Descrição do programa");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtModulo
            // 
            this.txtModulo.BackColor = System.Drawing.Color.LightGray;
            this.txtModulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModulo.Enabled = false;
            this.txtModulo.Location = new System.Drawing.Point(79, 63);
            this.txtModulo.MaxLength = 10;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(69, 21);
            this.txtModulo.TabIndex = 3;
            this.txtModulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPrograma.SetToolTip(this.txtModulo, "Código do módulo");
            this.txtModulo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(79, 9);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(69, 21);
            this.txtCodigo.TabIndex = 10;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPrograma.SetToolTip(this.txtCodigo, "Código");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // lblDescModulo
            // 
            this.lblDescModulo.Enabled = false;
            this.lblDescModulo.Location = new System.Drawing.Point(154, 67);
            this.lblDescModulo.Name = "lblDescModulo";
            this.lblDescModulo.Size = new System.Drawing.Size(157, 13);
            this.lblDescModulo.TabIndex = 9;
            this.lblDescModulo.UseCompatibleTextRendering = true;
            // 
            // lbModulo
            // 
            this.lbModulo.AutoSize = true;
            this.lbModulo.Enabled = false;
            this.lbModulo.Location = new System.Drawing.Point(15, 67);
            this.lbModulo.Name = "lbModulo";
            this.lbModulo.Size = new System.Drawing.Size(45, 13);
            this.lbModulo.TabIndex = 6;
            this.lbModulo.Text = "Módulo:";
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(15, 121);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(34, 13);
            this.lblNivel.TabIndex = 5;
            this.lblNivel.Text = "Nível:";
            // 
            // lblProg
            // 
            this.lblProg.AutoSize = true;
            this.lblProg.Location = new System.Drawing.Point(15, 94);
            this.lblProg.Name = "lblProg";
            this.lblProg.Size = new System.Drawing.Size(57, 13);
            this.lblProg.TabIndex = 4;
            this.lblProg.Text = "Programa:";
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Enabled = false;
            this.lblCod.Location = new System.Drawing.Point(15, 13);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(44, 13);
            this.lblCod.TabIndex = 0;
            this.lblCod.Text = "Código:";
            // 
            // frmPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(427, 200);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlPrograma);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrograma";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrograma_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPrograma_FormClosed);
            this.Load += new System.EventHandler(this.frmPrograma_Load);
            this.pnlPrograma.ResumeLayout(false);
            this.pnlPrograma.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipPrograma;
        private BLL.validacoes.Controles.TextBoxPersonal txtNivelSubMod;
        private System.Windows.Forms.Label lblNivelSubMod;
        private BLL.validacoes.Controles.TextBoxPersonal txtSubMod;
        private System.Windows.Forms.Label lblDescSubMod;
        private System.Windows.Forms.Button btnSubMod;
        private System.Windows.Forms.Label lblSubMod;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlPrograma;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lblDescModulo;
        private System.Windows.Forms.Label lbModulo;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.Label lblProg;
        private System.Windows.Forms.Label lblCod;
        private BLL.validacoes.Controles.TextBoxPersonal txtModulo;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtNivel;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private BLL.validacoes.Controles.TextBoxPersonal txtNivelMod;
        private System.Windows.Forms.Label lblNivelMod;
    }
}