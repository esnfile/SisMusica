namespace ccbrepess
{
    partial class frmConsultaSimples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaSimples));
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlMix = new System.Windows.Forms.Panel();
            this.gpoAdicionais = new System.Windows.Forms.GroupBox();
            this.chkPulaPagina = new System.Windows.Forms.CheckBox();
            this.chkExibeDetalhe = new System.Windows.Forms.CheckBox();
            this.cboCargo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblCargo = new System.Windows.Forms.Label();
            this.chkAgruComum = new System.Windows.Forms.CheckBox();
            this.gpoAgrupar = new System.Windows.Forms.GroupBox();
            this.optAgruCidade = new System.Windows.Forms.RadioButton();
            this.optAgruRegiao = new System.Windows.Forms.RadioButton();
            this.gpoEstadoCivil = new System.Windows.Forms.GroupBox();
            this.chkDivorciado = new System.Windows.Forms.CheckBox();
            this.chkViuvo = new System.Windows.Forms.CheckBox();
            this.chkCasado = new System.Windows.Forms.CheckBox();
            this.chkSolteiro = new System.Windows.Forms.CheckBox();
            this.gpoSexo = new System.Windows.Forms.GroupBox();
            this.chkMasculino = new System.Windows.Forms.CheckBox();
            this.chkFeminino = new System.Windows.Forms.CheckBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblSolteiro = new System.Windows.Forms.Label();
            this.lblCasado = new System.Windows.Forms.Label();
            this.lblViuvo = new System.Windows.Forms.Label();
            this.lblDivorciado = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlMix.SuspendLayout();
            this.gpoAdicionais.SuspendLayout();
            this.gpoAgrupar.SuspendLayout();
            this.gpoEstadoCivil.SuspendLayout();
            this.gpoSexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(278, 159);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 35);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pnlMix
            // 
            this.pnlMix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlMix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMix.Controls.Add(this.gpoAdicionais);
            this.pnlMix.Controls.Add(this.cboCargo);
            this.pnlMix.Controls.Add(this.lblCargo);
            this.pnlMix.Controls.Add(this.chkAgruComum);
            this.pnlMix.Controls.Add(this.gpoAgrupar);
            this.pnlMix.Controls.Add(this.gpoEstadoCivil);
            this.pnlMix.Controls.Add(this.gpoSexo);
            this.pnlMix.Location = new System.Drawing.Point(7, 7);
            this.pnlMix.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pnlMix.Name = "pnlMix";
            this.pnlMix.Size = new System.Drawing.Size(366, 148);
            this.pnlMix.TabIndex = 0;
            // 
            // gpoAdicionais
            // 
            this.gpoAdicionais.Controls.Add(this.chkExibeDetalhe);
            this.gpoAdicionais.Controls.Add(this.chkPulaPagina);
            this.gpoAdicionais.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAdicionais.Location = new System.Drawing.Point(10, 94);
            this.gpoAdicionais.Name = "gpoAdicionais";
            this.gpoAdicionais.Size = new System.Drawing.Size(185, 42);
            this.gpoAdicionais.TabIndex = 27;
            this.gpoAdicionais.TabStop = false;
            this.gpoAdicionais.Text = "Configurações adicionais";
            // 
            // chkPulaPagina
            // 
            this.chkPulaPagina.AutoSize = true;
            this.chkPulaPagina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPulaPagina.Location = new System.Drawing.Point(12, 18);
            this.chkPulaPagina.Name = "chkPulaPagina";
            this.chkPulaPagina.Size = new System.Drawing.Size(166, 17);
            this.chkPulaPagina.TabIndex = 25;
            this.chkPulaPagina.Text = "Inicia grupo em nova página?";
            this.chkPulaPagina.UseVisualStyleBackColor = true;
            this.chkPulaPagina.Visible = false;
            // 
            // chkExibeDetalhe
            // 
            this.chkExibeDetalhe.AutoSize = true;
            this.chkExibeDetalhe.Checked = true;
            this.chkExibeDetalhe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExibeDetalhe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkExibeDetalhe.Location = new System.Drawing.Point(12, 18);
            this.chkExibeDetalhe.Name = "chkExibeDetalhe";
            this.chkExibeDetalhe.Size = new System.Drawing.Size(140, 17);
            this.chkExibeDetalhe.TabIndex = 26;
            this.chkExibeDetalhe.Text = "Exibe dados completos?";
            this.chkExibeDetalhe.UseVisualStyleBackColor = true;
            // 
            // cboCargo
            // 
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(204, 67);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(150, 21);
            this.cboCargo.TabIndex = 23;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCargo.Location = new System.Drawing.Point(146, 71);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(56, 13);
            this.lblCargo.TabIndex = 24;
            this.lblCargo.Text = "Ministério:";
            // 
            // chkAgruComum
            // 
            this.chkAgruComum.AutoSize = true;
            this.chkAgruComum.Location = new System.Drawing.Point(10, 70);
            this.chkAgruComum.Name = "chkAgruComum";
            this.chkAgruComum.Size = new System.Drawing.Size(127, 17);
            this.chkAgruComum.TabIndex = 22;
            this.chkAgruComum.Text = "Agrupar por Comum?";
            this.chkAgruComum.UseVisualStyleBackColor = true;
            // 
            // gpoAgrupar
            // 
            this.gpoAgrupar.Controls.Add(this.optAgruCidade);
            this.gpoAgrupar.Controls.Add(this.optAgruRegiao);
            this.gpoAgrupar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAgrupar.Location = new System.Drawing.Point(9, 3);
            this.gpoAgrupar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoAgrupar.Name = "gpoAgrupar";
            this.gpoAgrupar.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoAgrupar.Size = new System.Drawing.Size(86, 59);
            this.gpoAgrupar.TabIndex = 3;
            this.gpoAgrupar.TabStop = false;
            this.gpoAgrupar.Text = "Agrupar por";
            // 
            // optAgruCidade
            // 
            this.optAgruCidade.AutoSize = true;
            this.optAgruCidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruCidade.Location = new System.Drawing.Point(12, 35);
            this.optAgruCidade.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruCidade.Name = "optAgruCidade";
            this.optAgruCidade.Size = new System.Drawing.Size(58, 17);
            this.optAgruCidade.TabIndex = 1;
            this.optAgruCidade.Text = "Cidade";
            this.optAgruCidade.UseVisualStyleBackColor = true;
            this.optAgruCidade.CheckedChanged += new System.EventHandler(this.optAgruCidade_CheckedChanged);
            // 
            // optAgruRegiao
            // 
            this.optAgruRegiao.AutoSize = true;
            this.optAgruRegiao.Checked = true;
            this.optAgruRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruRegiao.Location = new System.Drawing.Point(12, 17);
            this.optAgruRegiao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruRegiao.Name = "optAgruRegiao";
            this.optAgruRegiao.Size = new System.Drawing.Size(58, 17);
            this.optAgruRegiao.TabIndex = 0;
            this.optAgruRegiao.TabStop = true;
            this.optAgruRegiao.Text = "Região";
            this.optAgruRegiao.UseVisualStyleBackColor = true;
            this.optAgruRegiao.CheckedChanged += new System.EventHandler(this.optAgruRegiao_CheckedChanged);
            // 
            // gpoEstadoCivil
            // 
            this.gpoEstadoCivil.Controls.Add(this.chkDivorciado);
            this.gpoEstadoCivil.Controls.Add(this.chkViuvo);
            this.gpoEstadoCivil.Controls.Add(this.chkCasado);
            this.gpoEstadoCivil.Controls.Add(this.chkSolteiro);
            this.gpoEstadoCivil.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoEstadoCivil.Location = new System.Drawing.Point(202, 3);
            this.gpoEstadoCivil.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoEstadoCivil.Name = "gpoEstadoCivil";
            this.gpoEstadoCivil.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoEstadoCivil.Size = new System.Drawing.Size(152, 59);
            this.gpoEstadoCivil.TabIndex = 6;
            this.gpoEstadoCivil.TabStop = false;
            this.gpoEstadoCivil.Text = "Estado Civil";
            // 
            // chkDivorciado
            // 
            this.chkDivorciado.AutoSize = true;
            this.chkDivorciado.Checked = true;
            this.chkDivorciado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDivorciado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDivorciado.Location = new System.Drawing.Point(71, 35);
            this.chkDivorciado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkDivorciado.Name = "chkDivorciado";
            this.chkDivorciado.Size = new System.Drawing.Size(76, 17);
            this.chkDivorciado.TabIndex = 3;
            this.chkDivorciado.Text = "Divorciado";
            this.chkDivorciado.UseVisualStyleBackColor = true;
            this.chkDivorciado.CheckedChanged += new System.EventHandler(this.chkDivorciado_CheckedChanged);
            // 
            // chkViuvo
            // 
            this.chkViuvo.AutoSize = true;
            this.chkViuvo.Checked = true;
            this.chkViuvo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViuvo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViuvo.Location = new System.Drawing.Point(9, 35);
            this.chkViuvo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkViuvo.Name = "chkViuvo";
            this.chkViuvo.Size = new System.Drawing.Size(52, 17);
            this.chkViuvo.TabIndex = 1;
            this.chkViuvo.Text = "Viúvo";
            this.chkViuvo.UseVisualStyleBackColor = true;
            this.chkViuvo.CheckedChanged += new System.EventHandler(this.chkViuvo_CheckedChanged);
            // 
            // chkCasado
            // 
            this.chkCasado.AutoSize = true;
            this.chkCasado.Checked = true;
            this.chkCasado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCasado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCasado.Location = new System.Drawing.Point(71, 17);
            this.chkCasado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkCasado.Name = "chkCasado";
            this.chkCasado.Size = new System.Drawing.Size(62, 17);
            this.chkCasado.TabIndex = 2;
            this.chkCasado.Text = "Casado";
            this.chkCasado.UseVisualStyleBackColor = true;
            this.chkCasado.CheckedChanged += new System.EventHandler(this.chkCasado_CheckedChanged);
            // 
            // chkSolteiro
            // 
            this.chkSolteiro.AutoSize = true;
            this.chkSolteiro.Checked = true;
            this.chkSolteiro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSolteiro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSolteiro.Location = new System.Drawing.Point(9, 17);
            this.chkSolteiro.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkSolteiro.Name = "chkSolteiro";
            this.chkSolteiro.Size = new System.Drawing.Size(62, 17);
            this.chkSolteiro.TabIndex = 0;
            this.chkSolteiro.Text = "Solteiro";
            this.chkSolteiro.UseVisualStyleBackColor = true;
            this.chkSolteiro.CheckedChanged += new System.EventHandler(this.chkSolteiro_CheckedChanged);
            // 
            // gpoSexo
            // 
            this.gpoSexo.Controls.Add(this.chkMasculino);
            this.gpoSexo.Controls.Add(this.chkFeminino);
            this.gpoSexo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSexo.Location = new System.Drawing.Point(102, 3);
            this.gpoSexo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Name = "gpoSexo";
            this.gpoSexo.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Size = new System.Drawing.Size(93, 59);
            this.gpoSexo.TabIndex = 4;
            this.gpoSexo.TabStop = false;
            this.gpoSexo.Text = "Sexo";
            // 
            // chkMasculino
            // 
            this.chkMasculino.AutoSize = true;
            this.chkMasculino.Checked = true;
            this.chkMasculino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMasculino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMasculino.Location = new System.Drawing.Point(10, 17);
            this.chkMasculino.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkMasculino.Name = "chkMasculino";
            this.chkMasculino.Size = new System.Drawing.Size(72, 17);
            this.chkMasculino.TabIndex = 0;
            this.chkMasculino.Text = "Masculino";
            this.chkMasculino.UseVisualStyleBackColor = true;
            this.chkMasculino.CheckedChanged += new System.EventHandler(this.chkMasculino_CheckedChanged);
            // 
            // chkFeminino
            // 
            this.chkFeminino.AutoSize = true;
            this.chkFeminino.Checked = true;
            this.chkFeminino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFeminino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFeminino.Location = new System.Drawing.Point(10, 35);
            this.chkFeminino.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkFeminino.Name = "chkFeminino";
            this.chkFeminino.Size = new System.Drawing.Size(68, 17);
            this.chkFeminino.TabIndex = 1;
            this.chkFeminino.Text = "Feminino";
            this.chkFeminino.UseVisualStyleBackColor = true;
            this.chkFeminino.CheckedChanged += new System.EventHandler(this.chkFeminino_CheckedChanged);
            // 
            // lblSexo
            // 
            this.lblSexo.Location = new System.Drawing.Point(1, 159);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(118, 13);
            this.lblSexo.TabIndex = 41;
            this.lblSexo.Text = "Masculino\', \'Feminino";
            this.lblSexo.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(1, 176);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 13);
            this.lblStatus.TabIndex = 42;
            this.lblStatus.Text = "Sim";
            this.lblStatus.Visible = false;
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.Location = new System.Drawing.Point(66, 176);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(241, 13);
            this.lblEstadoCivil.TabIndex = 43;
            this.lblEstadoCivil.Text = "Solteiro(a)\',\'Casado(a)\',\'Viúvo(a)\',\'Divorciado(a)";
            this.lblEstadoCivil.Visible = false;
            // 
            // lblSolteiro
            // 
            this.lblSolteiro.Location = new System.Drawing.Point(110, 160);
            this.lblSolteiro.Name = "lblSolteiro";
            this.lblSolteiro.Size = new System.Drawing.Size(64, 13);
            this.lblSolteiro.TabIndex = 44;
            this.lblSolteiro.Text = "Solteiro(a)";
            this.lblSolteiro.Visible = false;
            // 
            // lblCasado
            // 
            this.lblCasado.Location = new System.Drawing.Point(174, 160);
            this.lblCasado.Name = "lblCasado";
            this.lblCasado.Size = new System.Drawing.Size(62, 13);
            this.lblCasado.TabIndex = 45;
            this.lblCasado.Text = "Casado(a)";
            this.lblCasado.Visible = false;
            // 
            // lblViuvo
            // 
            this.lblViuvo.Location = new System.Drawing.Point(235, 160);
            this.lblViuvo.Name = "lblViuvo";
            this.lblViuvo.Size = new System.Drawing.Size(47, 13);
            this.lblViuvo.TabIndex = 46;
            this.lblViuvo.Text = "Viúvo(a)";
            this.lblViuvo.Visible = false;
            // 
            // lblDivorciado
            // 
            this.lblDivorciado.Location = new System.Drawing.Point(288, 160);
            this.lblDivorciado.Name = "lblDivorciado";
            this.lblDivorciado.Size = new System.Drawing.Size(71, 13);
            this.lblDivorciado.TabIndex = 47;
            this.lblDivorciado.Text = "Divorciado(a)";
            this.lblDivorciado.Visible = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::ccbrepess.Properties.Resources.Impressora;
            this.btnImprimir.Location = new System.Drawing.Point(180, 159);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(95, 35);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = " &Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmConsultaSimples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(378, 203);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblDivorciado);
            this.Controls.Add(this.lblViuvo);
            this.Controls.Add(this.lblCasado);
            this.Controls.Add(this.lblSolteiro);
            this.Controls.Add(this.lblEstadoCivil);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.pnlMix);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "frmConsultaSimples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de Irmãos(ãs) por Ministério";
            this.Load += new System.EventHandler(this.frmMixPessoa_Load);
            this.pnlMix.ResumeLayout(false);
            this.pnlMix.PerformLayout();
            this.gpoAdicionais.ResumeLayout(false);
            this.gpoAdicionais.PerformLayout();
            this.gpoAgrupar.ResumeLayout(false);
            this.gpoAgrupar.PerformLayout();
            this.gpoEstadoCivil.ResumeLayout(false);
            this.gpoEstadoCivil.PerformLayout();
            this.gpoSexo.ResumeLayout(false);
            this.gpoSexo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlMix;
        private System.Windows.Forms.GroupBox gpoSexo;
        private System.Windows.Forms.CheckBox chkFeminino;
        private System.Windows.Forms.CheckBox chkMasculino;
        private System.Windows.Forms.GroupBox gpoAgrupar;
        private System.Windows.Forms.RadioButton optAgruCidade;
        private System.Windows.Forms.RadioButton optAgruRegiao;
        private System.Windows.Forms.GroupBox gpoEstadoCivil;
        private System.Windows.Forms.CheckBox chkViuvo;
        private System.Windows.Forms.CheckBox chkSolteiro;
        private System.Windows.Forms.CheckBox chkDivorciado;
        private System.Windows.Forms.CheckBox chkCasado;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblSolteiro;
        private System.Windows.Forms.Label lblCasado;
        private System.Windows.Forms.Label lblViuvo;
        private System.Windows.Forms.Label lblDivorciado;
        private System.Windows.Forms.CheckBox chkAgruComum;
        private System.Windows.Forms.Label lblCargo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboCargo;
        private System.Windows.Forms.CheckBox chkPulaPagina;
        private System.Windows.Forms.GroupBox gpoAdicionais;
        private System.Windows.Forms.CheckBox chkExibeDetalhe;
    }
}