namespace ccbreutil
{
    partial class frmMixCCB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMixCCB));
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlMix = new System.Windows.Forms.Panel();
            this.gpoOrdem = new System.Windows.Forms.GroupBox();
            this.optOrdemDesc = new System.Windows.Forms.RadioButton();
            this.optOrdemCodigo = new System.Windows.Forms.RadioButton();
            this.gpoPeriodo = new System.Windows.Forms.GroupBox();
            this.btnDataFinal = new System.Windows.Forms.Button();
            this.btnDataInicial = new System.Windows.Forms.Button();
            this.txtDataInicial = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataFinal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.gpoAdicionais = new System.Windows.Forms.GroupBox();
            this.chkExibeDetalhe = new System.Windows.Forms.CheckBox();
            this.chkPulaPagina = new System.Windows.Forms.CheckBox();
            this.gpoSituacao = new System.Windows.Forms.GroupBox();
            this.chkFechada = new System.Windows.Forms.CheckBox();
            this.chkReforma = new System.Windows.Forms.CheckBox();
            this.chkConstrucao = new System.Windows.Forms.CheckBox();
            this.chkAberta = new System.Windows.Forms.CheckBox();
            this.gpoAgrupar = new System.Windows.Forms.GroupBox();
            this.optAgruCidade = new System.Windows.Forms.RadioButton();
            this.optAgruRegiao = new System.Windows.Forms.RadioButton();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.lblAberta = new System.Windows.Forms.Label();
            this.lblConstrucao = new System.Windows.Forms.Label();
            this.lblReforma = new System.Windows.Forms.Label();
            this.lblFechada = new System.Windows.Forms.Label();
            this.pnlMix.SuspendLayout();
            this.gpoOrdem.SuspendLayout();
            this.gpoPeriodo.SuspendLayout();
            this.gpoAdicionais.SuspendLayout();
            this.gpoSituacao.SuspendLayout();
            this.gpoAgrupar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(287, 187);
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
            this.pnlMix.Controls.Add(this.gpoOrdem);
            this.pnlMix.Controls.Add(this.gpoPeriodo);
            this.pnlMix.Controls.Add(this.gpoAdicionais);
            this.pnlMix.Controls.Add(this.gpoSituacao);
            this.pnlMix.Controls.Add(this.gpoAgrupar);
            this.pnlMix.Location = new System.Drawing.Point(7, 7);
            this.pnlMix.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pnlMix.Name = "pnlMix";
            this.pnlMix.Size = new System.Drawing.Size(375, 175);
            this.pnlMix.TabIndex = 0;
            // 
            // gpoOrdem
            // 
            this.gpoOrdem.Controls.Add(this.optOrdemDesc);
            this.gpoOrdem.Controls.Add(this.optOrdemCodigo);
            this.gpoOrdem.Enabled = false;
            this.gpoOrdem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoOrdem.Location = new System.Drawing.Point(100, 3);
            this.gpoOrdem.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoOrdem.Name = "gpoOrdem";
            this.gpoOrdem.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoOrdem.Size = new System.Drawing.Size(85, 68);
            this.gpoOrdem.TabIndex = 29;
            this.gpoOrdem.TabStop = false;
            this.gpoOrdem.Text = "Ordem";
            // 
            // optOrdemDesc
            // 
            this.optOrdemDesc.AutoSize = true;
            this.optOrdemDesc.Checked = true;
            this.optOrdemDesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optOrdemDesc.Location = new System.Drawing.Point(10, 41);
            this.optOrdemDesc.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optOrdemDesc.Name = "optOrdemDesc";
            this.optOrdemDesc.Size = new System.Drawing.Size(71, 17);
            this.optOrdemDesc.TabIndex = 1;
            this.optOrdemDesc.TabStop = true;
            this.optOrdemDesc.Text = "Descrição";
            this.optOrdemDesc.UseVisualStyleBackColor = true;
            // 
            // optOrdemCodigo
            // 
            this.optOrdemCodigo.AutoSize = true;
            this.optOrdemCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optOrdemCodigo.Location = new System.Drawing.Point(10, 18);
            this.optOrdemCodigo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optOrdemCodigo.Name = "optOrdemCodigo";
            this.optOrdemCodigo.Size = new System.Drawing.Size(58, 17);
            this.optOrdemCodigo.TabIndex = 0;
            this.optOrdemCodigo.Text = "Código";
            this.optOrdemCodigo.UseVisualStyleBackColor = true;
            // 
            // gpoPeriodo
            // 
            this.gpoPeriodo.Controls.Add(this.btnDataFinal);
            this.gpoPeriodo.Controls.Add(this.btnDataInicial);
            this.gpoPeriodo.Controls.Add(this.txtDataInicial);
            this.gpoPeriodo.Controls.Add(this.txtDataFinal);
            this.gpoPeriodo.Controls.Add(this.lblDataFinal);
            this.gpoPeriodo.Controls.Add(this.lblDataInicial);
            this.gpoPeriodo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoPeriodo.Location = new System.Drawing.Point(191, 3);
            this.gpoPeriodo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoPeriodo.Name = "gpoPeriodo";
            this.gpoPeriodo.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoPeriodo.Size = new System.Drawing.Size(172, 68);
            this.gpoPeriodo.TabIndex = 28;
            this.gpoPeriodo.TabStop = false;
            this.gpoPeriodo.Text = "Data de Abertura";
            // 
            // btnDataFinal
            // 
            this.btnDataFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataFinal.BackgroundImage = global::ccbreutil.Properties.Resources.depois;
            this.btnDataFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDataFinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataFinal.Location = new System.Drawing.Point(141, 41);
            this.btnDataFinal.Name = "btnDataFinal";
            this.btnDataFinal.Size = new System.Drawing.Size(18, 19);
            this.btnDataFinal.TabIndex = 6;
            this.btnDataFinal.UseVisualStyleBackColor = true;
            // 
            // btnDataInicial
            // 
            this.btnDataInicial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataInicial.BackgroundImage = global::ccbreutil.Properties.Resources.antes;
            this.btnDataInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataInicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataInicial.Location = new System.Drawing.Point(141, 16);
            this.btnDataInicial.Name = "btnDataInicial";
            this.btnDataInicial.Size = new System.Drawing.Size(18, 19);
            this.btnDataInicial.TabIndex = 4;
            this.btnDataInicial.UseVisualStyleBackColor = true;
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.BackColor = System.Drawing.Color.White;
            this.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataInicial.Location = new System.Drawing.Point(70, 15);
            this.txtDataInicial.MaxLength = 10;
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(90, 21);
            this.txtDataInicial.TabIndex = 3;
            this.txtDataInicial.Text = "01/01/1910";
            this.txtDataInicial.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.BackColor = System.Drawing.Color.White;
            this.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataFinal.Location = new System.Drawing.Point(70, 40);
            this.txtDataFinal.MaxLength = 100;
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(90, 21);
            this.txtDataFinal.TabIndex = 5;
            this.txtDataFinal.Text = "31/12/2050";
            this.txtDataFinal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDataFinal.Location = new System.Drawing.Point(7, 44);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(59, 13);
            this.lblDataFinal.TabIndex = 162;
            this.lblDataFinal.Text = "Data Final:";
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDataInicial.Location = new System.Drawing.Point(7, 19);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(64, 13);
            this.lblDataInicial.TabIndex = 159;
            this.lblDataInicial.Text = "Data Inicial:";
            // 
            // gpoAdicionais
            // 
            this.gpoAdicionais.Controls.Add(this.chkExibeDetalhe);
            this.gpoAdicionais.Controls.Add(this.chkPulaPagina);
            this.gpoAdicionais.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAdicionais.Location = new System.Drawing.Point(9, 120);
            this.gpoAdicionais.Name = "gpoAdicionais";
            this.gpoAdicionais.Size = new System.Drawing.Size(282, 42);
            this.gpoAdicionais.TabIndex = 27;
            this.gpoAdicionais.TabStop = false;
            this.gpoAdicionais.Text = "Configurações adicionais";
            // 
            // chkExibeDetalhe
            // 
            this.chkExibeDetalhe.AutoSize = true;
            this.chkExibeDetalhe.Checked = true;
            this.chkExibeDetalhe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExibeDetalhe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkExibeDetalhe.Location = new System.Drawing.Point(12, 18);
            this.chkExibeDetalhe.Name = "chkExibeDetalhe";
            this.chkExibeDetalhe.Size = new System.Drawing.Size(89, 17);
            this.chkExibeDetalhe.TabIndex = 26;
            this.chkExibeDetalhe.Text = "Exibe dados?";
            this.chkExibeDetalhe.UseVisualStyleBackColor = true;
            // 
            // chkPulaPagina
            // 
            this.chkPulaPagina.AutoSize = true;
            this.chkPulaPagina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPulaPagina.Location = new System.Drawing.Point(110, 18);
            this.chkPulaPagina.Name = "chkPulaPagina";
            this.chkPulaPagina.Size = new System.Drawing.Size(166, 17);
            this.chkPulaPagina.TabIndex = 25;
            this.chkPulaPagina.Text = "Inicia grupo em nova página?";
            this.chkPulaPagina.UseVisualStyleBackColor = true;
            this.chkPulaPagina.Visible = false;
            // 
            // gpoSituacao
            // 
            this.gpoSituacao.Controls.Add(this.chkFechada);
            this.gpoSituacao.Controls.Add(this.chkReforma);
            this.gpoSituacao.Controls.Add(this.chkConstrucao);
            this.gpoSituacao.Controls.Add(this.chkAberta);
            this.gpoSituacao.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSituacao.Location = new System.Drawing.Point(9, 72);
            this.gpoSituacao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSituacao.Name = "gpoSituacao";
            this.gpoSituacao.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSituacao.Size = new System.Drawing.Size(354, 45);
            this.gpoSituacao.TabIndex = 3;
            this.gpoSituacao.TabStop = false;
            this.gpoSituacao.Text = "Situação";
            // 
            // chkFechada
            // 
            this.chkFechada.AutoSize = true;
            this.chkFechada.Checked = true;
            this.chkFechada.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFechada.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFechada.Location = new System.Drawing.Point(279, 18);
            this.chkFechada.Name = "chkFechada";
            this.chkFechada.Size = new System.Drawing.Size(67, 17);
            this.chkFechada.TabIndex = 26;
            this.chkFechada.Text = "Fechada";
            this.chkFechada.UseVisualStyleBackColor = true;
            this.chkFechada.CheckedChanged += new System.EventHandler(this.chkFechada_CheckedChanged);
            // 
            // chkReforma
            // 
            this.chkReforma.AutoSize = true;
            this.chkReforma.Checked = true;
            this.chkReforma.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkReforma.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkReforma.Location = new System.Drawing.Point(186, 18);
            this.chkReforma.Name = "chkReforma";
            this.chkReforma.Size = new System.Drawing.Size(84, 17);
            this.chkReforma.TabIndex = 26;
            this.chkReforma.Text = "Em Reforma";
            this.chkReforma.UseVisualStyleBackColor = true;
            this.chkReforma.CheckedChanged += new System.EventHandler(this.chkReforma_CheckedChanged);
            // 
            // chkConstrucao
            // 
            this.chkConstrucao.AutoSize = true;
            this.chkConstrucao.Checked = true;
            this.chkConstrucao.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConstrucao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkConstrucao.Location = new System.Drawing.Point(80, 18);
            this.chkConstrucao.Name = "chkConstrucao";
            this.chkConstrucao.Size = new System.Drawing.Size(98, 17);
            this.chkConstrucao.TabIndex = 26;
            this.chkConstrucao.Text = "Em Construção";
            this.chkConstrucao.UseVisualStyleBackColor = true;
            this.chkConstrucao.CheckedChanged += new System.EventHandler(this.chkConstrucao_CheckedChanged);
            // 
            // chkAberta
            // 
            this.chkAberta.AutoSize = true;
            this.chkAberta.Checked = true;
            this.chkAberta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAberta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAberta.Location = new System.Drawing.Point(12, 18);
            this.chkAberta.Name = "chkAberta";
            this.chkAberta.Size = new System.Drawing.Size(59, 17);
            this.chkAberta.TabIndex = 26;
            this.chkAberta.Text = "Aberta";
            this.chkAberta.UseVisualStyleBackColor = true;
            this.chkAberta.CheckedChanged += new System.EventHandler(this.chkAberta_CheckedChanged);
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
            this.gpoAgrupar.Size = new System.Drawing.Size(86, 68);
            this.gpoAgrupar.TabIndex = 3;
            this.gpoAgrupar.TabStop = false;
            this.gpoAgrupar.Text = "Agrupar por";
            // 
            // optAgruCidade
            // 
            this.optAgruCidade.AutoSize = true;
            this.optAgruCidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruCidade.Location = new System.Drawing.Point(12, 41);
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
            this.optAgruRegiao.Location = new System.Drawing.Point(12, 18);
            this.optAgruRegiao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruRegiao.Name = "optAgruRegiao";
            this.optAgruRegiao.Size = new System.Drawing.Size(58, 17);
            this.optAgruRegiao.TabIndex = 0;
            this.optAgruRegiao.TabStop = true;
            this.optAgruRegiao.Text = "Região";
            this.optAgruRegiao.UseVisualStyleBackColor = true;
            this.optAgruRegiao.CheckedChanged += new System.EventHandler(this.optAgruRegiao_CheckedChanged);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = global::ccbreutil.Properties.Resources.Impressora;
            this.btnImprimir.Location = new System.Drawing.Point(189, 187);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(95, 35);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = " &Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblSituacao
            // 
            this.lblSituacao.Location = new System.Drawing.Point(9, 187);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(222, 16);
            this.lblSituacao.TabIndex = 3;
            this.lblSituacao.Text = "Aberta\', \'Em Construção\', \'Em Reforma\', \'Fechada";
            this.lblSituacao.Visible = false;
            // 
            // lblAberta
            // 
            this.lblAberta.AutoSize = true;
            this.lblAberta.Location = new System.Drawing.Point(7, 215);
            this.lblAberta.Name = "lblAberta";
            this.lblAberta.Size = new System.Drawing.Size(40, 13);
            this.lblAberta.TabIndex = 4;
            this.lblAberta.Text = "Aberta";
            this.lblAberta.Visible = false;
            // 
            // lblConstrucao
            // 
            this.lblConstrucao.AutoSize = true;
            this.lblConstrucao.Location = new System.Drawing.Point(9, 202);
            this.lblConstrucao.Name = "lblConstrucao";
            this.lblConstrucao.Size = new System.Drawing.Size(79, 13);
            this.lblConstrucao.TabIndex = 4;
            this.lblConstrucao.Text = "Em Construção";
            this.lblConstrucao.Visible = false;
            // 
            // lblReforma
            // 
            this.lblReforma.AutoSize = true;
            this.lblReforma.Location = new System.Drawing.Point(53, 215);
            this.lblReforma.Name = "lblReforma";
            this.lblReforma.Size = new System.Drawing.Size(65, 13);
            this.lblReforma.TabIndex = 4;
            this.lblReforma.Text = "Em Reforma";
            this.lblReforma.Visible = false;
            // 
            // lblFechada
            // 
            this.lblFechada.AutoSize = true;
            this.lblFechada.Location = new System.Drawing.Point(89, 202);
            this.lblFechada.Name = "lblFechada";
            this.lblFechada.Size = new System.Drawing.Size(48, 13);
            this.lblFechada.TabIndex = 4;
            this.lblFechada.Text = "Fechada";
            this.lblFechada.Visible = false;
            // 
            // frmMixCCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(388, 232);
            this.Controls.Add(this.lblFechada);
            this.Controls.Add(this.lblReforma);
            this.Controls.Add(this.lblConstrucao);
            this.Controls.Add(this.lblAberta);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlMix);
            this.Controls.Add(this.lblSituacao);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "frmMixCCB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de Comum Congregação";
            this.Load += new System.EventHandler(this.frmMixCCB_Load);
            this.pnlMix.ResumeLayout(false);
            this.gpoOrdem.ResumeLayout(false);
            this.gpoOrdem.PerformLayout();
            this.gpoPeriodo.ResumeLayout(false);
            this.gpoPeriodo.PerformLayout();
            this.gpoAdicionais.ResumeLayout(false);
            this.gpoAdicionais.PerformLayout();
            this.gpoSituacao.ResumeLayout(false);
            this.gpoSituacao.PerformLayout();
            this.gpoAgrupar.ResumeLayout(false);
            this.gpoAgrupar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlMix;
        private System.Windows.Forms.GroupBox gpoAgrupar;
        private System.Windows.Forms.RadioButton optAgruCidade;
        private System.Windows.Forms.RadioButton optAgruRegiao;
        private System.Windows.Forms.CheckBox chkPulaPagina;
        private System.Windows.Forms.GroupBox gpoAdicionais;
        private System.Windows.Forms.CheckBox chkExibeDetalhe;
        private System.Windows.Forms.GroupBox gpoPeriodo;
        private System.Windows.Forms.Button btnDataFinal;
        private System.Windows.Forms.Button btnDataInicial;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataInicial;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataFinal;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Label lblDataInicial;
        private System.Windows.Forms.GroupBox gpoOrdem;
        private System.Windows.Forms.RadioButton optOrdemDesc;
        private System.Windows.Forms.RadioButton optOrdemCodigo;
        private System.Windows.Forms.GroupBox gpoSituacao;
        private System.Windows.Forms.CheckBox chkFechada;
        private System.Windows.Forms.CheckBox chkReforma;
        private System.Windows.Forms.CheckBox chkConstrucao;
        private System.Windows.Forms.CheckBox chkAberta;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lblAberta;
        private System.Windows.Forms.Label lblConstrucao;
        private System.Windows.Forms.Label lblReforma;
        private System.Windows.Forms.Label lblFechada;
    }
}