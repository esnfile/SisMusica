namespace ccbtest
{
    partial class frmSolicitaTeste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitaTeste));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipForm = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnDados = new System.Windows.Forms.Button();
            this.pnlSolicita = new System.Windows.Forms.Panel();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtUsuario = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblComum = new System.Windows.Forms.Label();
            this.btnComum = new System.Windows.Forms.Button();
            this.gpoTipo = new System.Windows.Forms.GroupBox();
            this.optTroca = new System.Windows.Forms.RadioButton();
            this.optMeia = new System.Windows.Forms.RadioButton();
            this.optCulto = new System.Windows.Forms.RadioButton();
            this.optRjm = new System.Windows.Forms.RadioButton();
            this.optOficial = new System.Windows.Forms.RadioButton();
            this.txtCodCCB = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbComum = new System.Windows.Forms.Label();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.txtInstrumento = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbInstrumento = new System.Windows.Forms.Label();
            this.txtFamilia = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtPessoa = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblPessoa = new System.Windows.Forms.Label();
            this.lbPessoa = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtHoraLancto = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataLancto = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataLancto = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCodUsuario = new System.Windows.Forms.Label();
            this.pnlSolicita.SuspendLayout();
            this.gpoTipo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(466, 155);
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
            this.btnCancelar.Location = new System.Drawing.Point(561, 155);
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
            this.txtCodigo.Location = new System.Drawing.Point(69, 54);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(45, 21);
            this.txtCodigo.TabIndex = 106;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipForm.SetToolTip(this.txtCodigo, "Código");
            // 
            // btnDados
            // 
            this.btnDados.Enabled = false;
            this.btnDados.Location = new System.Drawing.Point(7, 155);
            this.btnDados.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDados.Name = "btnDados";
            this.btnDados.Size = new System.Drawing.Size(141, 30);
            this.btnDados.TabIndex = 6;
            this.btnDados.Text = "&Análise do Candidato(a)";
            this.tipForm.SetToolTip(this.btnDados, "Salvar alterações");
            this.btnDados.UseVisualStyleBackColor = true;
            // 
            // pnlSolicita
            // 
            this.pnlSolicita.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlSolicita.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSolicita.Controls.Add(this.lblTipo);
            this.pnlSolicita.Controls.Add(this.txtUsuario);
            this.pnlSolicita.Controls.Add(this.lblUsuario);
            this.pnlSolicita.Controls.Add(this.lblComum);
            this.pnlSolicita.Controls.Add(this.btnComum);
            this.pnlSolicita.Controls.Add(this.gpoTipo);
            this.pnlSolicita.Controls.Add(this.txtCodCCB);
            this.pnlSolicita.Controls.Add(this.lbComum);
            this.pnlSolicita.Controls.Add(this.btnPessoa);
            this.pnlSolicita.Controls.Add(this.txtInstrumento);
            this.pnlSolicita.Controls.Add(this.lbInstrumento);
            this.pnlSolicita.Controls.Add(this.txtFamilia);
            this.pnlSolicita.Controls.Add(this.txtPessoa);
            this.pnlSolicita.Controls.Add(this.lblPessoa);
            this.pnlSolicita.Controls.Add(this.lbPessoa);
            this.pnlSolicita.Controls.Add(this.lblStatus);
            this.pnlSolicita.Controls.Add(this.txtHoraLancto);
            this.pnlSolicita.Controls.Add(this.txtDataLancto);
            this.pnlSolicita.Controls.Add(this.lblDataLancto);
            this.pnlSolicita.Controls.Add(this.txtCodigo);
            this.pnlSolicita.Controls.Add(this.lblCodigo);
            this.pnlSolicita.Location = new System.Drawing.Point(8, 8);
            this.pnlSolicita.Name = "pnlSolicita";
            this.pnlSolicita.Size = new System.Drawing.Size(643, 143);
            this.pnlSolicita.TabIndex = 5;
            // 
            // lblTipo
            // 
            this.lblTipo.Enabled = false;
            this.lblTipo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTipo.Location = new System.Drawing.Point(301, 4);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(98, 13);
            this.lblTipo.TabIndex = 126;
            this.lblTipo.Visible = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.LightGray;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(464, 54);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(163, 21);
            this.txtUsuario.TabIndex = 125;
            this.txtUsuario.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Location = new System.Drawing.Point(394, 58);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(60, 13);
            this.lblUsuario.TabIndex = 124;
            this.lblUsuario.Text = "Solicitante:";
            // 
            // lblComum
            // 
            this.lblComum.Enabled = false;
            this.lblComum.Location = new System.Drawing.Point(146, 112);
            this.lblComum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComum.Name = "lblComum";
            this.lblComum.Size = new System.Drawing.Size(481, 13);
            this.lblComum.TabIndex = 123;
            // 
            // btnComum
            // 
            this.btnComum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComum.Enabled = false;
            this.btnComum.Image = ((System.Drawing.Image)(resources.GetObject("btnComum.Image")));
            this.btnComum.Location = new System.Drawing.Point(117, 107);
            this.btnComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnComum.Name = "btnComum";
            this.btnComum.Size = new System.Drawing.Size(23, 23);
            this.btnComum.TabIndex = 94;
            this.btnComum.UseVisualStyleBackColor = true;
            this.btnComum.Click += new System.EventHandler(this.btnComum_Click);
            // 
            // gpoTipo
            // 
            this.gpoTipo.Controls.Add(this.optTroca);
            this.gpoTipo.Controls.Add(this.optMeia);
            this.gpoTipo.Controls.Add(this.optCulto);
            this.gpoTipo.Controls.Add(this.optRjm);
            this.gpoTipo.Controls.Add(this.optOficial);
            this.gpoTipo.Location = new System.Drawing.Point(13, 6);
            this.gpoTipo.Name = "gpoTipo";
            this.gpoTipo.Size = new System.Drawing.Size(441, 42);
            this.gpoTipo.TabIndex = 108;
            this.gpoTipo.TabStop = false;
            this.gpoTipo.Text = "Solicitação de teste para?";
            // 
            // optTroca
            // 
            this.optTroca.AutoSize = true;
            this.optTroca.BackColor = System.Drawing.Color.Transparent;
            this.optTroca.Location = new System.Drawing.Point(373, 16);
            this.optTroca.Name = "optTroca";
            this.optTroca.Size = new System.Drawing.Size(52, 17);
            this.optTroca.TabIndex = 4;
            this.optTroca.Text = "Troca";
            this.optTroca.UseVisualStyleBackColor = false;
            this.optTroca.CheckedChanged += new System.EventHandler(this.optTroca_CheckedChanged);
            // 
            // optMeia
            // 
            this.optMeia.AutoSize = true;
            this.optMeia.BackColor = System.Drawing.Color.Transparent;
            this.optMeia.Location = new System.Drawing.Point(116, 16);
            this.optMeia.Name = "optMeia";
            this.optMeia.Size = new System.Drawing.Size(73, 17);
            this.optMeia.TabIndex = 3;
            this.optMeia.Text = "Meia Hora";
            this.optMeia.UseVisualStyleBackColor = false;
            this.optMeia.CheckedChanged += new System.EventHandler(this.optMeia_CheckedChanged);
            // 
            // optCulto
            // 
            this.optCulto.AutoSize = true;
            this.optCulto.BackColor = System.Drawing.Color.Transparent;
            this.optCulto.Location = new System.Drawing.Point(195, 16);
            this.optCulto.Name = "optCulto";
            this.optCulto.Size = new System.Drawing.Size(82, 17);
            this.optCulto.TabIndex = 1;
            this.optCulto.Text = "Culto Oficial";
            this.optCulto.UseVisualStyleBackColor = false;
            this.optCulto.CheckedChanged += new System.EventHandler(this.optCulto_CheckedChanged);
            // 
            // optRjm
            // 
            this.optRjm.AutoSize = true;
            this.optRjm.BackColor = System.Drawing.Color.Transparent;
            this.optRjm.Location = new System.Drawing.Point(9, 16);
            this.optRjm.Name = "optRjm";
            this.optRjm.Size = new System.Drawing.Size(101, 17);
            this.optRjm.TabIndex = 0;
            this.optRjm.Text = "Reunião Jovens";
            this.optRjm.UseVisualStyleBackColor = false;
            this.optRjm.CheckedChanged += new System.EventHandler(this.optRjm_CheckedChanged);
            // 
            // optOficial
            // 
            this.optOficial.AutoSize = true;
            this.optOficial.BackColor = System.Drawing.Color.Transparent;
            this.optOficial.Location = new System.Drawing.Point(283, 16);
            this.optOficial.Name = "optOficial";
            this.optOficial.Size = new System.Drawing.Size(84, 17);
            this.optOficial.TabIndex = 2;
            this.optOficial.Text = "Oficialização";
            this.optOficial.UseVisualStyleBackColor = false;
            this.optOficial.CheckedChanged += new System.EventHandler(this.optOficial_CheckedChanged);
            // 
            // txtCodCCB
            // 
            this.txtCodCCB.BackColor = System.Drawing.Color.White;
            this.txtCodCCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodCCB.Enabled = false;
            this.txtCodCCB.Location = new System.Drawing.Point(69, 108);
            this.txtCodCCB.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodCCB.MaxLength = 6;
            this.txtCodCCB.Name = "txtCodCCB";
            this.txtCodCCB.Size = new System.Drawing.Size(45, 21);
            this.txtCodCCB.TabIndex = 85;
            this.txtCodCCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodCCB.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtCodCCB.Enter += new System.EventHandler(this.txtCodCCB_Enter);
            this.txtCodCCB.Leave += new System.EventHandler(this.txtCodCCB_Leave);
            // 
            // lbComum
            // 
            this.lbComum.AutoSize = true;
            this.lbComum.Enabled = false;
            this.lbComum.Location = new System.Drawing.Point(10, 112);
            this.lbComum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbComum.Name = "lbComum";
            this.lbComum.Size = new System.Drawing.Size(46, 13);
            this.lbComum.TabIndex = 90;
            this.lbComum.Text = "Comum:";
            // 
            // btnPessoa
            // 
            this.btnPessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPessoa.Image = ((System.Drawing.Image)(resources.GetObject("btnPessoa.Image")));
            this.btnPessoa.Location = new System.Drawing.Point(117, 80);
            this.btnPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(23, 23);
            this.btnPessoa.TabIndex = 116;
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // txtInstrumento
            // 
            this.txtInstrumento.BackColor = System.Drawing.Color.LightGray;
            this.txtInstrumento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstrumento.Enabled = false;
            this.txtInstrumento.Location = new System.Drawing.Point(464, 81);
            this.txtInstrumento.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtInstrumento.Name = "txtInstrumento";
            this.txtInstrumento.Size = new System.Drawing.Size(99, 21);
            this.txtInstrumento.TabIndex = 122;
            this.txtInstrumento.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lbInstrumento
            // 
            this.lbInstrumento.AutoSize = true;
            this.lbInstrumento.Enabled = false;
            this.lbInstrumento.Location = new System.Drawing.Point(394, 85);
            this.lbInstrumento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbInstrumento.Name = "lbInstrumento";
            this.lbInstrumento.Size = new System.Drawing.Size(70, 13);
            this.lbInstrumento.TabIndex = 118;
            this.lbInstrumento.Text = "Instrumento:";
            // 
            // txtFamilia
            // 
            this.txtFamilia.BackColor = System.Drawing.Color.LightGray;
            this.txtFamilia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFamilia.Enabled = false;
            this.txtFamilia.Location = new System.Drawing.Point(567, 81);
            this.txtFamilia.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFamilia.Name = "txtFamilia";
            this.txtFamilia.Size = new System.Drawing.Size(60, 21);
            this.txtFamilia.TabIndex = 119;
            this.txtFamilia.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtPessoa
            // 
            this.txtPessoa.BackColor = System.Drawing.Color.White;
            this.txtPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPessoa.Location = new System.Drawing.Point(69, 81);
            this.txtPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPessoa.MaxLength = 6;
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(45, 21);
            this.txtPessoa.TabIndex = 115;
            this.txtPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPessoa.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtPessoa.Enter += new System.EventHandler(this.txtPessoa_Enter);
            this.txtPessoa.Leave += new System.EventHandler(this.txtPessoa_Leave);
            // 
            // lblPessoa
            // 
            this.lblPessoa.Location = new System.Drawing.Point(146, 85);
            this.lblPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPessoa.Name = "lblPessoa";
            this.lblPessoa.Size = new System.Drawing.Size(220, 13);
            this.lblPessoa.TabIndex = 117;
            // 
            // lbPessoa
            // 
            this.lbPessoa.AutoSize = true;
            this.lbPessoa.Location = new System.Drawing.Point(10, 85);
            this.lbPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPessoa.Name = "lbPessoa";
            this.lbPessoa.Size = new System.Drawing.Size(52, 13);
            this.lbPessoa.TabIndex = 114;
            this.lbPessoa.Text = "Aluno(a):";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(464, 19);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(163, 20);
            this.lblStatus.TabIndex = 112;
            this.lblStatus.Text = "Pendente";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtHoraLancto
            // 
            this.txtHoraLancto.BackColor = System.Drawing.Color.LightGray;
            this.txtHoraLancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraLancto.Enabled = false;
            this.txtHoraLancto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraLancto.Location = new System.Drawing.Point(325, 54);
            this.txtHoraLancto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraLancto.Name = "txtHoraLancto";
            this.txtHoraLancto.Size = new System.Drawing.Size(41, 21);
            this.txtHoraLancto.TabIndex = 111;
            this.txtHoraLancto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraLancto.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtDataLancto
            // 
            this.txtDataLancto.BackColor = System.Drawing.Color.LightGray;
            this.txtDataLancto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataLancto.Enabled = false;
            this.txtDataLancto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataLancto.Location = new System.Drawing.Point(236, 54);
            this.txtDataLancto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataLancto.Name = "txtDataLancto";
            this.txtDataLancto.Size = new System.Drawing.Size(84, 21);
            this.txtDataLancto.TabIndex = 109;
            this.txtDataLancto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataLancto.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataLancto
            // 
            this.lblDataLancto.AutoSize = true;
            this.lblDataLancto.Enabled = false;
            this.lblDataLancto.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDataLancto.Location = new System.Drawing.Point(146, 58);
            this.lblDataLancto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataLancto.Name = "lblDataLancto";
            this.lblDataLancto.Size = new System.Drawing.Size(87, 13);
            this.lblDataLancto.TabIndex = 110;
            this.lblDataLancto.Text = "Data Solicitação:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(10, 58);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(61, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Solicitação:";
            // 
            // lblCodUsuario
            // 
            this.lblCodUsuario.Enabled = false;
            this.lblCodUsuario.Location = new System.Drawing.Point(215, 164);
            this.lblCodUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuario.Name = "lblCodUsuario";
            this.lblCodUsuario.Size = new System.Drawing.Size(60, 13);
            this.lblCodUsuario.TabIndex = 127;
            this.lblCodUsuario.Visible = false;
            // 
            // frmSolicitaTeste
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(658, 193);
            this.Controls.Add(this.lblCodUsuario);
            this.Controls.Add(this.btnDados);
            this.Controls.Add(this.pnlSolicita);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSolicitaTeste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitação de teste";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSolicitaTeste_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSolicitaTeste_FormClosed);
            this.Load += new System.EventHandler(this.frmSolicitaTeste_Load);
            this.pnlSolicita.ResumeLayout(false);
            this.pnlSolicita.PerformLayout();
            this.gpoTipo.ResumeLayout(false);
            this.gpoTipo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipForm;
        private System.Windows.Forms.Panel pnlSolicita;
        private System.Windows.Forms.GroupBox gpoTipo;
        private System.Windows.Forms.RadioButton optCulto;
        private System.Windows.Forms.RadioButton optRjm;
        private System.Windows.Forms.RadioButton optOficial;
        private System.Windows.Forms.Label lblComum;
        private System.Windows.Forms.Button btnComum;
        private System.Windows.Forms.Button btnPessoa;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodCCB;
        private BLL.validacoes.Controles.TextBoxPersonal txtInstrumento;
        private System.Windows.Forms.Label lbComum;
        private System.Windows.Forms.Label lbInstrumento;
        private BLL.validacoes.Controles.TextBoxPersonal txtFamilia;
        private BLL.validacoes.Controles.TextBoxPersonal txtPessoa;
        private System.Windows.Forms.Label lblPessoa;
        private System.Windows.Forms.Label lbPessoa;
        private System.Windows.Forms.Label lblStatus;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraLancto;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataLancto;
        private System.Windows.Forms.Label lblDataLancto;
        private BLL.validacoes.Controles.TextBoxPersonal txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnDados;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblCodUsuario;
        private System.Windows.Forms.RadioButton optTroca;
        private System.Windows.Forms.RadioButton optMeia;
    }
}