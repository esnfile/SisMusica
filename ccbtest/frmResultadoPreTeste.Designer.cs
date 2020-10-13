namespace ccbtest
{
    partial class frmResultadoPreTeste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmResultadoPreTeste));
            this.tipPreTeste = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtHoraExame = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataExame = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlPreTeste = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInstrumento = new System.Windows.Forms.Label();
            this.optTroca = new System.Windows.Forms.RadioButton();
            this.optMeiaHora = new System.Windows.Forms.RadioButton();
            this.optOficial = new System.Windows.Forms.RadioButton();
            this.optCulto = new System.Windows.Forms.RadioButton();
            this.optRjm = new System.Windows.Forms.RadioButton();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblTestePara = new System.Windows.Forms.Label();
            this.lbInstrumento = new System.Windows.Forms.Label();
            this.gpoComum = new System.Windows.Forms.GroupBox();
            this.txtCodPreTeste = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblTeste = new System.Windows.Forms.Label();
            this.txtComum = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbComum = new System.Windows.Forms.Label();
            this.lblDataExame = new System.Windows.Forms.Label();
            this.lblPessoa = new System.Windows.Forms.Label();
            this.lbPessoa = new System.Windows.Forms.Label();
            this.txtFicha = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblFicha = new System.Windows.Forms.Label();
            this.lblCodUsuarioAbertura = new System.Windows.Forms.Label();
            this.lblCodUsuarioFecha = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSolicita = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pnlPreTeste.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpoComum.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Location = new System.Drawing.Point(503, 421);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipPreTeste.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(597, 421);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipPreTeste.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtHoraExame
            // 
            this.txtHoraExame.BackColor = System.Drawing.Color.LightGray;
            this.txtHoraExame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraExame.Enabled = false;
            this.txtHoraExame.Location = new System.Drawing.Point(274, 17);
            this.txtHoraExame.MaxLength = 5;
            this.txtHoraExame.Name = "txtHoraExame";
            this.txtHoraExame.Size = new System.Drawing.Size(40, 21);
            this.txtHoraExame.TabIndex = 105;
            this.txtHoraExame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPreTeste.SetToolTip(this.txtHoraExame, "Hora do exame");
            this.txtHoraExame.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtDataExame
            // 
            this.txtDataExame.BackColor = System.Drawing.Color.LightGray;
            this.txtDataExame.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataExame.Enabled = false;
            this.txtDataExame.Location = new System.Drawing.Point(195, 17);
            this.txtDataExame.MaxLength = 10;
            this.txtDataExame.Name = "txtDataExame";
            this.txtDataExame.Size = new System.Drawing.Size(75, 21);
            this.txtDataExame.TabIndex = 104;
            this.txtDataExame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPreTeste.SetToolTip(this.txtDataExame, "Data do exame");
            this.txtDataExame.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // pnlPreTeste
            // 
            this.pnlPreTeste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlPreTeste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreTeste.Controls.Add(this.groupBox1);
            this.pnlPreTeste.Controls.Add(this.lblInstrumento);
            this.pnlPreTeste.Controls.Add(this.optTroca);
            this.pnlPreTeste.Controls.Add(this.optMeiaHora);
            this.pnlPreTeste.Controls.Add(this.optOficial);
            this.pnlPreTeste.Controls.Add(this.optCulto);
            this.pnlPreTeste.Controls.Add(this.optRjm);
            this.pnlPreTeste.Controls.Add(this.lblTipo);
            this.pnlPreTeste.Controls.Add(this.lblTestePara);
            this.pnlPreTeste.Controls.Add(this.lbInstrumento);
            this.pnlPreTeste.Controls.Add(this.btnSolicita);
            this.pnlPreTeste.Controls.Add(this.gpoComum);
            this.pnlPreTeste.Controls.Add(this.lblPessoa);
            this.pnlPreTeste.Controls.Add(this.lbPessoa);
            this.pnlPreTeste.Controls.Add(this.txtFicha);
            this.pnlPreTeste.Controls.Add(this.lblFicha);
            this.pnlPreTeste.Location = new System.Drawing.Point(6, 6);
            this.pnlPreTeste.Name = "pnlPreTeste";
            this.pnlPreTeste.Size = new System.Drawing.Size(680, 411);
            this.pnlPreTeste.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 234);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultado do Pré-teste";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Teoria:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Escalas:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hinário:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Método:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "MTS - Ritmo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "MTS - Solfejo:";
            // 
            // lblInstrumento
            // 
            this.lblInstrumento.Enabled = false;
            this.lblInstrumento.Location = new System.Drawing.Point(466, 89);
            this.lblInstrumento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInstrumento.Name = "lblInstrumento";
            this.lblInstrumento.Size = new System.Drawing.Size(202, 13);
            this.lblInstrumento.TabIndex = 111;
            // 
            // optTroca
            // 
            this.optTroca.AutoSize = true;
            this.optTroca.Location = new System.Drawing.Point(605, 57);
            this.optTroca.Name = "optTroca";
            this.optTroca.Size = new System.Drawing.Size(52, 17);
            this.optTroca.TabIndex = 110;
            this.optTroca.Text = "Troca";
            this.optTroca.UseVisualStyleBackColor = true;
            this.optTroca.CheckedChanged += new System.EventHandler(this.optTroca_CheckedChanged);
            // 
            // optMeiaHora
            // 
            this.optMeiaHora.AutoSize = true;
            this.optMeiaHora.Location = new System.Drawing.Point(354, 57);
            this.optMeiaHora.Name = "optMeiaHora";
            this.optMeiaHora.Size = new System.Drawing.Size(73, 17);
            this.optMeiaHora.TabIndex = 109;
            this.optMeiaHora.Text = "Meia Hora";
            this.optMeiaHora.UseVisualStyleBackColor = true;
            this.optMeiaHora.CheckedChanged += new System.EventHandler(this.optMeiaHora_CheckedChanged);
            // 
            // optOficial
            // 
            this.optOficial.AutoSize = true;
            this.optOficial.Location = new System.Drawing.Point(517, 57);
            this.optOficial.Name = "optOficial";
            this.optOficial.Size = new System.Drawing.Size(84, 17);
            this.optOficial.TabIndex = 2;
            this.optOficial.Text = "Oficialização";
            this.optOficial.UseVisualStyleBackColor = true;
            this.optOficial.CheckedChanged += new System.EventHandler(this.optOficial_CheckedChanged);
            // 
            // optCulto
            // 
            this.optCulto.AutoSize = true;
            this.optCulto.Location = new System.Drawing.Point(431, 57);
            this.optCulto.Name = "optCulto";
            this.optCulto.Size = new System.Drawing.Size(82, 17);
            this.optCulto.TabIndex = 1;
            this.optCulto.Text = "Culto Oficial";
            this.optCulto.UseVisualStyleBackColor = true;
            this.optCulto.CheckedChanged += new System.EventHandler(this.optCulto_CheckedChanged);
            // 
            // optRjm
            // 
            this.optRjm.AutoSize = true;
            this.optRjm.Location = new System.Drawing.Point(249, 57);
            this.optRjm.Name = "optRjm";
            this.optRjm.Size = new System.Drawing.Size(101, 17);
            this.optRjm.TabIndex = 0;
            this.optRjm.Text = "Reunião Jovens";
            this.optRjm.UseVisualStyleBackColor = true;
            this.optRjm.CheckedChanged += new System.EventHandler(this.optRjm_CheckedChanged);
            // 
            // lblTipo
            // 
            this.lblTipo.Location = new System.Drawing.Point(463, 73);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(76, 13);
            this.lblTipo.TabIndex = 100;
            this.lblTipo.Text = "Reunião de Jovens";
            this.lblTipo.Visible = false;
            // 
            // lblTestePara
            // 
            this.lblTestePara.AutoSize = true;
            this.lblTestePara.Location = new System.Drawing.Point(164, 59);
            this.lblTestePara.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTestePara.Name = "lblTestePara";
            this.lblTestePara.Size = new System.Drawing.Size(81, 13);
            this.lblTestePara.TabIndex = 107;
            this.lblTestePara.Text = "Pré-teste para:";
            // 
            // lbInstrumento
            // 
            this.lbInstrumento.AutoSize = true;
            this.lbInstrumento.Enabled = false;
            this.lbInstrumento.Location = new System.Drawing.Point(389, 89);
            this.lbInstrumento.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbInstrumento.Name = "lbInstrumento";
            this.lbInstrumento.Size = new System.Drawing.Size(70, 13);
            this.lbInstrumento.TabIndex = 106;
            this.lbInstrumento.Text = "Instrumento:";
            // 
            // gpoComum
            // 
            this.gpoComum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.gpoComum.Controls.Add(this.txtHoraExame);
            this.gpoComum.Controls.Add(this.txtDataExame);
            this.gpoComum.Controls.Add(this.txtCodPreTeste);
            this.gpoComum.Controls.Add(this.lblTeste);
            this.gpoComum.Controls.Add(this.txtComum);
            this.gpoComum.Controls.Add(this.lbComum);
            this.gpoComum.Controls.Add(this.lblDataExame);
            this.gpoComum.Enabled = false;
            this.gpoComum.Location = new System.Drawing.Point(8, 4);
            this.gpoComum.Name = "gpoComum";
            this.gpoComum.Size = new System.Drawing.Size(662, 47);
            this.gpoComum.TabIndex = 95;
            this.gpoComum.TabStop = false;
            this.gpoComum.Text = "Dados sobre o Pré-teste";
            // 
            // txtCodPreTeste
            // 
            this.txtCodPreTeste.BackColor = System.Drawing.Color.LightGray;
            this.txtCodPreTeste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodPreTeste.Enabled = false;
            this.txtCodPreTeste.Location = new System.Drawing.Point(72, 17);
            this.txtCodPreTeste.Name = "txtCodPreTeste";
            this.txtCodPreTeste.Size = new System.Drawing.Size(49, 21);
            this.txtCodPreTeste.TabIndex = 109;
            this.txtCodPreTeste.Text = "00000";
            this.txtCodPreTeste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodPreTeste.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblTeste
            // 
            this.lblTeste.AutoSize = true;
            this.lblTeste.Enabled = false;
            this.lblTeste.Location = new System.Drawing.Point(8, 21);
            this.lblTeste.Name = "lblTeste";
            this.lblTeste.Size = new System.Drawing.Size(56, 13);
            this.lblTeste.TabIndex = 108;
            this.lblTeste.Text = "Pré-teste:";
            // 
            // txtComum
            // 
            this.txtComum.BackColor = System.Drawing.Color.LightGray;
            this.txtComum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComum.Enabled = false;
            this.txtComum.Location = new System.Drawing.Point(372, 17);
            this.txtComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtComum.Name = "txtComum";
            this.txtComum.Size = new System.Drawing.Size(279, 21);
            this.txtComum.TabIndex = 106;
            this.txtComum.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lbComum
            // 
            this.lbComum.AutoSize = true;
            this.lbComum.Enabled = false;
            this.lbComum.Location = new System.Drawing.Point(323, 21);
            this.lbComum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbComum.Name = "lbComum";
            this.lbComum.Size = new System.Drawing.Size(46, 13);
            this.lbComum.TabIndex = 107;
            this.lbComum.Text = "Comum:";
            // 
            // lblDataExame
            // 
            this.lblDataExame.AutoSize = true;
            this.lblDataExame.Enabled = false;
            this.lblDataExame.Location = new System.Drawing.Point(131, 21);
            this.lblDataExame.Name = "lblDataExame";
            this.lblDataExame.Size = new System.Drawing.Size(64, 13);
            this.lblDataExame.TabIndex = 103;
            this.lblDataExame.Text = "Data Teste:";
            // 
            // lblPessoa
            // 
            this.lblPessoa.Location = new System.Drawing.Point(80, 88);
            this.lblPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPessoa.Name = "lblPessoa";
            this.lblPessoa.Size = new System.Drawing.Size(297, 15);
            this.lblPessoa.TabIndex = 79;
            // 
            // lbPessoa
            // 
            this.lbPessoa.AutoSize = true;
            this.lbPessoa.Location = new System.Drawing.Point(9, 89);
            this.lbPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPessoa.Name = "lbPessoa";
            this.lbPessoa.Size = new System.Drawing.Size(74, 13);
            this.lbPessoa.TabIndex = 76;
            this.lbPessoa.Text = "Candidato(a):";
            // 
            // txtFicha
            // 
            this.txtFicha.BackColor = System.Drawing.Color.White;
            this.txtFicha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFicha.Location = new System.Drawing.Point(80, 57);
            this.txtFicha.Name = "txtFicha";
            this.txtFicha.Size = new System.Drawing.Size(49, 21);
            this.txtFicha.TabIndex = 13;
            this.txtFicha.Text = "00000";
            this.txtFicha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFicha.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblFicha
            // 
            this.lblFicha.AutoSize = true;
            this.lblFicha.Location = new System.Drawing.Point(9, 61);
            this.lblFicha.Name = "lblFicha";
            this.lblFicha.Size = new System.Drawing.Size(50, 13);
            this.lblFicha.TabIndex = 12;
            this.lblFicha.Text = "Ficha nº:";
            // 
            // lblCodUsuarioAbertura
            // 
            this.lblCodUsuarioAbertura.Enabled = false;
            this.lblCodUsuarioAbertura.Location = new System.Drawing.Point(14, 565);
            this.lblCodUsuarioAbertura.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuarioAbertura.Name = "lblCodUsuarioAbertura";
            this.lblCodUsuarioAbertura.Size = new System.Drawing.Size(70, 13);
            this.lblCodUsuarioAbertura.TabIndex = 106;
            // 
            // lblCodUsuarioFecha
            // 
            this.lblCodUsuarioFecha.Enabled = false;
            this.lblCodUsuarioFecha.Location = new System.Drawing.Point(14, 578);
            this.lblCodUsuarioFecha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuarioFecha.Name = "lblCodUsuarioFecha";
            this.lblCodUsuarioFecha.Size = new System.Drawing.Size(70, 13);
            this.lblCodUsuarioFecha.TabIndex = 107;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::ccbtest.Properties.Resources.emoji_1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(90, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 13;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSolicita
            // 
            this.btnSolicita.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSolicita.Image = global::ccbtest.Properties.Resources.Lupa;
            this.btnSolicita.Location = new System.Drawing.Point(132, 56);
            this.btnSolicita.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSolicita.Name = "btnSolicita";
            this.btnSolicita.Size = new System.Drawing.Size(23, 23);
            this.btnSolicita.TabIndex = 101;
            this.tipPreTeste.SetToolTip(this.btnSolicita, "Selecione o Solicitação");
            this.btnSolicita.UseVisualStyleBackColor = true;
            this.btnSolicita.Click += new System.EventHandler(this.btnSolicita_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::ccbtest.Properties.Resources.emoji_2;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(136, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 40);
            this.button2.TabIndex = 13;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::ccbtest.Properties.Resources.emoji_3;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(182, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 40);
            this.button3.TabIndex = 13;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::ccbtest.Properties.Resources.emoji_4;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Location = new System.Drawing.Point(226, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 40);
            this.button4.TabIndex = 13;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.BackgroundImage = global::ccbtest.Properties.Resources.emoji_5;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Location = new System.Drawing.Point(270, 27);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 40);
            this.button5.TabIndex = 13;
            this.button5.UseVisualStyleBackColor = true;
            // 
            // frmResultadoPreTeste
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(692, 456);
            this.Controls.Add(this.lblCodUsuarioFecha);
            this.Controls.Add(this.lblCodUsuarioAbertura);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlPreTeste);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmResultadoPreTeste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Resultado de Pré-teste";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFichaPreTeste_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFichaPreTeste_FormClosed);
            this.Load += new System.EventHandler(this.frmFichaPreTeste_Load);
            this.pnlPreTeste.ResumeLayout(false);
            this.pnlPreTeste.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpoComum.ResumeLayout(false);
            this.gpoComum.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipPreTeste;
        private System.Windows.Forms.Panel pnlPreTeste;
        private BLL.validacoes.Controles.TextBoxPersonal txtFicha;
        private System.Windows.Forms.Label lblFicha;
        private System.Windows.Forms.Label lblPessoa;
        private System.Windows.Forms.Label lbPessoa;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSolicita;
        private System.Windows.Forms.GroupBox gpoComum;
        private System.Windows.Forms.Label lbComum;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraExame;
        private System.Windows.Forms.Label lblDataExame;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataExame;
        private System.Windows.Forms.Label lblCodUsuarioAbertura;
        private System.Windows.Forms.Label lblCodUsuarioFecha;
        private System.Windows.Forms.RadioButton optOficial;
        private System.Windows.Forms.RadioButton optCulto;
        private System.Windows.Forms.RadioButton optRjm;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblTestePara;
        private System.Windows.Forms.Label lbInstrumento;
        private BLL.validacoes.Controles.TextBoxPersonal txtComum;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodPreTeste;
        private System.Windows.Forms.Label lblTeste;
        private System.Windows.Forms.RadioButton optTroca;
        private System.Windows.Forms.RadioButton optMeiaHora;
        private System.Windows.Forms.Label lblInstrumento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}