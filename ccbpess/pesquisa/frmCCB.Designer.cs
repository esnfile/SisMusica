namespace ccbpess.pesquisa
{
    partial class frmCCB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCCB));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabCCB = new System.Windows.Forms.TabControl();
            this.tabGeral = new System.Windows.Forms.TabPage();
            this.lblDescricaoRegional = new System.Windows.Forms.Label();
            this.lbRegional = new System.Windows.Forms.Label();
            this.gpoSituacao = new System.Windows.Forms.GroupBox();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.optSitFechada = new System.Windows.Forms.RadioButton();
            this.optSitAberta = new System.Windows.Forms.RadioButton();
            this.optSitReforma = new System.Windows.Forms.RadioButton();
            this.optSitConstrucao = new System.Windows.Forms.RadioButton();
            this.lblDescricaoRegiao = new System.Windows.Forms.Label();
            this.btnRegiao = new System.Windows.Forms.Button();
            this.txtCodRegiao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbRegiao = new System.Windows.Forms.Label();
            this.txtCnpj = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCnpj = new System.Windows.Forms.Label();
            this.txtDataAbertura = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataAbertura = new System.Windows.Forms.Label();
            this.txtCodigoCCB = new System.Windows.Forms.TextBox();
            this.lblCodigoCCB = new System.Windows.Forms.Label();
            this.txtComum = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.gpoContato = new System.Windows.Forms.GroupBox();
            this.txtSkype = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblSkype = new System.Windows.Forms.Label();
            this.txtEmail = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCel = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCel = new System.Windows.Forms.Label();
            this.txtTel = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblTel = new System.Windows.Forms.Label();
            this.gpoEndereco = new System.Windows.Forms.GroupBox();
            this.txtEstado = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCidade = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCodCidade = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbCidade = new System.Windows.Forms.Label();
            this.txtBairro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtComp = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.lblComp = new System.Windows.Forms.Label();
            this.lblCep = new System.Windows.Forms.Label();
            this.lblBairroEnd = new System.Windows.Forms.Label();
            this.txtEndereco = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCep = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNumEnd = new System.Windows.Forms.Label();
            this.btnCep = new System.Windows.Forms.Button();
            this.txtNum = new BLL.validacoes.Controles.TextBoxPersonal();
            this.tabMinisterio = new System.Windows.Forms.TabPage();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.gpoMinisterio = new System.Windows.Forms.GroupBox();
            this.txtDataApresentacao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataApresentacao = new System.Windows.Forms.Label();
            this.btnSalvarItem = new System.Windows.Forms.Button();
            this.txtMinisterio = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCancelarItem = new System.Windows.Forms.Button();
            this.lblMinisterio = new System.Windows.Forms.Label();
            this.txtPessoa = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbPessoa = new System.Windows.Forms.Label();
            this.lblPessoa = new System.Windows.Forms.Label();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.gridMinisterio = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.tipCCB = new System.Windows.Forms.ToolTip(this.components);
            this.tabCCB.SuspendLayout();
            this.tabGeral.SuspendLayout();
            this.gpoSituacao.SuspendLayout();
            this.gpoContato.SuspendLayout();
            this.gpoEndereco.SuspendLayout();
            this.tabMinisterio.SuspendLayout();
            this.gpoMinisterio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMinisterio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(491, 428);
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
            this.btnCancelar.Location = new System.Drawing.Point(586, 428);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipCCB.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabCCB
            // 
            this.tabCCB.Controls.Add(this.tabGeral);
            this.tabCCB.Controls.Add(this.tabMinisterio);
            this.tabCCB.Location = new System.Drawing.Point(9, 9);
            this.tabCCB.Name = "tabCCB";
            this.tabCCB.SelectedIndex = 0;
            this.tabCCB.Size = new System.Drawing.Size(666, 412);
            this.tabCCB.TabIndex = 5;
            this.tabCCB.SelectedIndexChanged += new System.EventHandler(this.tabCCB_SelectedIndexChanged);
            // 
            // tabGeral
            // 
            this.tabGeral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabGeral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabGeral.Controls.Add(this.lblDescricaoRegional);
            this.tabGeral.Controls.Add(this.lbRegional);
            this.tabGeral.Controls.Add(this.gpoSituacao);
            this.tabGeral.Controls.Add(this.lblDescricaoRegiao);
            this.tabGeral.Controls.Add(this.btnRegiao);
            this.tabGeral.Controls.Add(this.txtCodRegiao);
            this.tabGeral.Controls.Add(this.lbRegiao);
            this.tabGeral.Controls.Add(this.txtCnpj);
            this.tabGeral.Controls.Add(this.lblCnpj);
            this.tabGeral.Controls.Add(this.txtDataAbertura);
            this.tabGeral.Controls.Add(this.lblDataAbertura);
            this.tabGeral.Controls.Add(this.txtCodigoCCB);
            this.tabGeral.Controls.Add(this.lblCodigoCCB);
            this.tabGeral.Controls.Add(this.txtComum);
            this.tabGeral.Controls.Add(this.lblDescricao);
            this.tabGeral.Controls.Add(this.txtCodigo);
            this.tabGeral.Controls.Add(this.lblCodigo);
            this.tabGeral.Controls.Add(this.gpoContato);
            this.tabGeral.Controls.Add(this.gpoEndereco);
            this.tabGeral.Location = new System.Drawing.Point(4, 22);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeral.Size = new System.Drawing.Size(658, 386);
            this.tabGeral.TabIndex = 0;
            this.tabGeral.Text = "Geral";
            // 
            // lblDescricaoRegional
            // 
            this.lblDescricaoRegional.Location = new System.Drawing.Point(490, 102);
            this.lblDescricaoRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoRegional.Name = "lblDescricaoRegional";
            this.lblDescricaoRegional.Size = new System.Drawing.Size(155, 17);
            this.lblDescricaoRegional.TabIndex = 117;
            // 
            // lbRegional
            // 
            this.lbRegional.AutoSize = true;
            this.lbRegional.Location = new System.Drawing.Point(425, 104);
            this.lbRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRegional.Name = "lbRegional";
            this.lbRegional.Size = new System.Drawing.Size(52, 13);
            this.lbRegional.TabIndex = 116;
            this.lbRegional.Text = "Regional:";
            // 
            // gpoSituacao
            // 
            this.gpoSituacao.Controls.Add(this.lblSituacao);
            this.gpoSituacao.Controls.Add(this.optSitFechada);
            this.gpoSituacao.Controls.Add(this.optSitAberta);
            this.gpoSituacao.Controls.Add(this.optSitReforma);
            this.gpoSituacao.Controls.Add(this.optSitConstrucao);
            this.gpoSituacao.Location = new System.Drawing.Point(490, 260);
            this.gpoSituacao.Name = "gpoSituacao";
            this.gpoSituacao.Size = new System.Drawing.Size(155, 115);
            this.gpoSituacao.TabIndex = 115;
            this.gpoSituacao.TabStop = false;
            this.gpoSituacao.Text = "Situação";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(102, 87);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(40, 13);
            this.lblSituacao.TabIndex = 4;
            this.lblSituacao.Text = "Aberta";
            this.lblSituacao.Visible = false;
            // 
            // optSitFechada
            // 
            this.optSitFechada.AutoSize = true;
            this.optSitFechada.Location = new System.Drawing.Point(15, 89);
            this.optSitFechada.Name = "optSitFechada";
            this.optSitFechada.Size = new System.Drawing.Size(66, 17);
            this.optSitFechada.TabIndex = 3;
            this.optSitFechada.Text = "Fechada";
            this.optSitFechada.UseVisualStyleBackColor = true;
            this.optSitFechada.Click += new System.EventHandler(this.optSitFechada_Click);
            // 
            // optSitAberta
            // 
            this.optSitAberta.AutoSize = true;
            this.optSitAberta.Checked = true;
            this.optSitAberta.Location = new System.Drawing.Point(15, 20);
            this.optSitAberta.Name = "optSitAberta";
            this.optSitAberta.Size = new System.Drawing.Size(58, 17);
            this.optSitAberta.TabIndex = 2;
            this.optSitAberta.TabStop = true;
            this.optSitAberta.Text = "Aberta";
            this.optSitAberta.UseVisualStyleBackColor = true;
            this.optSitAberta.Click += new System.EventHandler(this.optSitAberta_Click);
            // 
            // optSitReforma
            // 
            this.optSitReforma.AutoSize = true;
            this.optSitReforma.Location = new System.Drawing.Point(15, 66);
            this.optSitReforma.Name = "optSitReforma";
            this.optSitReforma.Size = new System.Drawing.Size(83, 17);
            this.optSitReforma.TabIndex = 1;
            this.optSitReforma.Text = "Em Reforma";
            this.optSitReforma.UseVisualStyleBackColor = true;
            this.optSitReforma.Click += new System.EventHandler(this.optSitReforma_Click);
            // 
            // optSitConstrucao
            // 
            this.optSitConstrucao.AutoSize = true;
            this.optSitConstrucao.Location = new System.Drawing.Point(15, 43);
            this.optSitConstrucao.Name = "optSitConstrucao";
            this.optSitConstrucao.Size = new System.Drawing.Size(97, 17);
            this.optSitConstrucao.TabIndex = 0;
            this.optSitConstrucao.Text = "Em Construção";
            this.optSitConstrucao.UseVisualStyleBackColor = true;
            this.optSitConstrucao.Click += new System.EventHandler(this.optSitConstrucao_Click);
            // 
            // lblDescricaoRegiao
            // 
            this.lblDescricaoRegiao.Location = new System.Drawing.Point(219, 102);
            this.lblDescricaoRegiao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoRegiao.Name = "lblDescricaoRegiao";
            this.lblDescricaoRegiao.Size = new System.Drawing.Size(197, 17);
            this.lblDescricaoRegiao.TabIndex = 114;
            // 
            // btnRegiao
            // 
            this.btnRegiao.Image = global::ccbpess.Properties.Resources.Lupa;
            this.btnRegiao.Location = new System.Drawing.Point(188, 99);
            this.btnRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnRegiao.Name = "btnRegiao";
            this.btnRegiao.Size = new System.Drawing.Size(23, 23);
            this.btnRegiao.TabIndex = 112;
            this.btnRegiao.UseVisualStyleBackColor = true;
            this.btnRegiao.Click += new System.EventHandler(this.btnRegiao_Click);
            // 
            // txtCodRegiao
            // 
            this.txtCodRegiao.BackColor = System.Drawing.Color.White;
            this.txtCodRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodRegiao.Location = new System.Drawing.Point(101, 100);
            this.txtCodRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodRegiao.Name = "txtCodRegiao";
            this.txtCodRegiao.Size = new System.Drawing.Size(84, 21);
            this.txtCodRegiao.TabIndex = 110;
            this.tipCCB.SetToolTip(this.txtCodRegiao, "Informe a Região, ou clique na lupa para buscar");
            this.txtCodRegiao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCodRegiao.Leave += new System.EventHandler(this.txtCodRegiao_Leave);
            // 
            // lbRegiao
            // 
            this.lbRegiao.AutoSize = true;
            this.lbRegiao.Location = new System.Drawing.Point(14, 104);
            this.lbRegiao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRegiao.Name = "lbRegiao";
            this.lbRegiao.Size = new System.Drawing.Size(44, 13);
            this.lbRegiao.TabIndex = 111;
            this.lbRegiao.Text = "Região:";
            // 
            // txtCnpj
            // 
            this.txtCnpj.BackColor = System.Drawing.Color.White;
            this.txtCnpj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCnpj.Location = new System.Drawing.Point(101, 72);
            this.txtCnpj.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCnpj.MaxLength = 15;
            this.txtCnpj.Name = "txtCnpj";
            this.txtCnpj.Size = new System.Drawing.Size(195, 21);
            this.txtCnpj.TabIndex = 108;
            this.txtCnpj.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Cnpj;
            // 
            // lblCnpj
            // 
            this.lblCnpj.AutoSize = true;
            this.lblCnpj.Location = new System.Drawing.Point(14, 76);
            this.lblCnpj.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCnpj.Name = "lblCnpj";
            this.lblCnpj.Size = new System.Drawing.Size(52, 13);
            this.lblCnpj.TabIndex = 109;
            this.lblCnpj.Text = "C.N.P.J.:";
            // 
            // txtDataAbertura
            // 
            this.txtDataAbertura.BackColor = System.Drawing.Color.White;
            this.txtDataAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataAbertura.Location = new System.Drawing.Point(548, 16);
            this.txtDataAbertura.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataAbertura.Name = "txtDataAbertura";
            this.txtDataAbertura.Size = new System.Drawing.Size(97, 21);
            this.txtDataAbertura.TabIndex = 106;
            this.txtDataAbertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtDataAbertura, "Data Abertura");
            this.txtDataAbertura.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataAbertura
            // 
            this.lblDataAbertura.AutoSize = true;
            this.lblDataAbertura.Location = new System.Drawing.Point(450, 20);
            this.lblDataAbertura.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataAbertura.Name = "lblDataAbertura";
            this.lblDataAbertura.Size = new System.Drawing.Size(80, 13);
            this.lblDataAbertura.TabIndex = 107;
            this.lblDataAbertura.Text = "Data Abertura:";
            // 
            // txtCodigoCCB
            // 
            this.txtCodigoCCB.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoCCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoCCB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigoCCB.Location = new System.Drawing.Point(301, 16);
            this.txtCodigoCCB.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigoCCB.MaxLength = 20;
            this.txtCodigoCCB.Name = "txtCodigoCCB";
            this.txtCodigoCCB.Size = new System.Drawing.Size(136, 21);
            this.txtCodigoCCB.TabIndex = 104;
            this.tipCCB.SetToolTip(this.txtCodigoCCB, "Código definido");
            // 
            // lblCodigoCCB
            // 
            this.lblCodigoCCB.AutoSize = true;
            this.lblCodigoCCB.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigoCCB.Location = new System.Drawing.Point(205, 19);
            this.lblCodigoCCB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigoCCB.Name = "lblCodigoCCB";
            this.lblCodigoCCB.Size = new System.Drawing.Size(72, 13);
            this.lblCodigoCCB.TabIndex = 105;
            this.lblCodigoCCB.Text = "Identificador:";
            // 
            // txtComum
            // 
            this.txtComum.BackColor = System.Drawing.Color.White;
            this.txtComum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComum.Location = new System.Drawing.Point(101, 44);
            this.txtComum.MaxLength = 150;
            this.txtComum.Name = "txtComum";
            this.txtComum.Size = new System.Drawing.Size(544, 21);
            this.txtComum.TabIndex = 102;
            this.tipCCB.SetToolTip(this.txtComum, "Define um nome para a Comum Congregação\r\nEx. Central");
            this.txtComum.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(14, 47);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(46, 13);
            this.lblDescricao.TabIndex = 103;
            this.lblDescricao.Text = "Comum:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(101, 16);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(86, 21);
            this.txtCodigo.TabIndex = 100;
            this.txtCodigo.Text = "000000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtCodigo, "Código");
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(14, 19);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 101;
            this.lblCodigo.Text = "Código:";
            // 
            // gpoContato
            // 
            this.gpoContato.Controls.Add(this.txtSkype);
            this.gpoContato.Controls.Add(this.lblSkype);
            this.gpoContato.Controls.Add(this.txtEmail);
            this.gpoContato.Controls.Add(this.lblEmail);
            this.gpoContato.Controls.Add(this.txtCel);
            this.gpoContato.Controls.Add(this.lblCel);
            this.gpoContato.Controls.Add(this.txtTel);
            this.gpoContato.Controls.Add(this.lblTel);
            this.gpoContato.Location = new System.Drawing.Point(11, 260);
            this.gpoContato.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gpoContato.Name = "gpoContato";
            this.gpoContato.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.gpoContato.Size = new System.Drawing.Size(471, 115);
            this.gpoContato.TabIndex = 99;
            this.gpoContato.TabStop = false;
            this.gpoContato.Text = "Contatos";
            // 
            // txtSkype
            // 
            this.txtSkype.BackColor = System.Drawing.Color.White;
            this.txtSkype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSkype.Location = new System.Drawing.Point(90, 83);
            this.txtSkype.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSkype.Name = "txtSkype";
            this.txtSkype.Size = new System.Drawing.Size(365, 21);
            this.txtSkype.TabIndex = 50;
            this.tipCCB.SetToolTip(this.txtSkype, "Skype");
            this.txtSkype.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblSkype
            // 
            this.lblSkype.AutoSize = true;
            this.lblSkype.Location = new System.Drawing.Point(13, 87);
            this.lblSkype.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSkype.Name = "lblSkype";
            this.lblSkype.Size = new System.Drawing.Size(40, 13);
            this.lblSkype.TabIndex = 51;
            this.lblSkype.Text = "Skype:";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(90, 54);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(365, 21);
            this.txtEmail.TabIndex = 32;
            this.tipCCB.SetToolTip(this.txtEmail, "Email");
            this.txtEmail.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(13, 58);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 49;
            this.lblEmail.Text = "Email:";
            // 
            // txtCel
            // 
            this.txtCel.BackColor = System.Drawing.Color.White;
            this.txtCel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCel.Location = new System.Drawing.Point(318, 25);
            this.txtCel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCel.Name = "txtCel";
            this.txtCel.Size = new System.Drawing.Size(137, 21);
            this.txtCel.TabIndex = 30;
            this.tipCCB.SetToolTip(this.txtCel, "Celular");
            this.txtCel.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Celular;
            // 
            // lblCel
            // 
            this.lblCel.AutoSize = true;
            this.lblCel.Location = new System.Drawing.Point(250, 29);
            this.lblCel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCel.Name = "lblCel";
            this.lblCel.Size = new System.Drawing.Size(44, 13);
            this.lblCel.TabIndex = 45;
            this.lblCel.Text = "Celular:";
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.Color.White;
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel.Location = new System.Drawing.Point(90, 25);
            this.txtTel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(132, 21);
            this.txtTel.TabIndex = 28;
            this.tipCCB.SetToolTip(this.txtTel, "Telefone");
            this.txtTel.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Telefone;
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(13, 24);
            this.lblTel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(53, 13);
            this.lblTel.TabIndex = 41;
            this.lblTel.Text = "Telefone:";
            // 
            // gpoEndereco
            // 
            this.gpoEndereco.Controls.Add(this.txtEstado);
            this.gpoEndereco.Controls.Add(this.lblCidade);
            this.gpoEndereco.Controls.Add(this.lblEstado);
            this.gpoEndereco.Controls.Add(this.txtCodCidade);
            this.gpoEndereco.Controls.Add(this.lbCidade);
            this.gpoEndereco.Controls.Add(this.txtBairro);
            this.gpoEndereco.Controls.Add(this.txtComp);
            this.gpoEndereco.Controls.Add(this.lblEndereco);
            this.gpoEndereco.Controls.Add(this.lblComp);
            this.gpoEndereco.Controls.Add(this.lblCep);
            this.gpoEndereco.Controls.Add(this.lblBairroEnd);
            this.gpoEndereco.Controls.Add(this.txtEndereco);
            this.gpoEndereco.Controls.Add(this.txtCep);
            this.gpoEndereco.Controls.Add(this.lblNumEnd);
            this.gpoEndereco.Controls.Add(this.btnCep);
            this.gpoEndereco.Controls.Add(this.txtNum);
            this.gpoEndereco.Location = new System.Drawing.Point(14, 130);
            this.gpoEndereco.Name = "gpoEndereco";
            this.gpoEndereco.Size = new System.Drawing.Size(631, 119);
            this.gpoEndereco.TabIndex = 98;
            this.gpoEndereco.TabStop = false;
            this.gpoEndereco.Text = "Endereço";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.Color.LightGray;
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstado.Enabled = false;
            this.txtEstado.Location = new System.Drawing.Point(242, 23);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(40, 21);
            this.txtEstado.TabIndex = 94;
            this.txtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstado.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCidade
            // 
            this.lblCidade.Enabled = false;
            this.lblCidade.Location = new System.Drawing.Point(411, 26);
            this.lblCidade.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(205, 14);
            this.lblCidade.TabIndex = 93;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Enabled = false;
            this.lblEstado.Location = new System.Drawing.Point(216, 27);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(24, 13);
            this.lblEstado.TabIndex = 92;
            this.lblEstado.Text = "UF:";
            // 
            // txtCodCidade
            // 
            this.txtCodCidade.BackColor = System.Drawing.Color.LightGray;
            this.txtCodCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodCidade.Enabled = false;
            this.txtCodCidade.Location = new System.Drawing.Point(351, 23);
            this.txtCodCidade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodCidade.Name = "txtCodCidade";
            this.txtCodCidade.Size = new System.Drawing.Size(55, 21);
            this.txtCodCidade.TabIndex = 90;
            this.txtCodCidade.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodCidade.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lbCidade
            // 
            this.lbCidade.AutoSize = true;
            this.lbCidade.Enabled = false;
            this.lbCidade.Location = new System.Drawing.Point(299, 27);
            this.lbCidade.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCidade.Name = "lbCidade";
            this.lbCidade.Size = new System.Drawing.Size(44, 13);
            this.lbCidade.TabIndex = 91;
            this.lbCidade.Text = "Cidade:";
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.White;
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.Location = new System.Drawing.Point(87, 81);
            this.txtBairro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(195, 21);
            this.txtBairro.TabIndex = 48;
            this.tipCCB.SetToolTip(this.txtBairro, "Bairro");
            this.txtBairro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtComp
            // 
            this.txtComp.BackColor = System.Drawing.Color.White;
            this.txtComp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComp.Location = new System.Drawing.Point(362, 81);
            this.txtComp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtComp.Name = "txtComp";
            this.txtComp.Size = new System.Drawing.Size(254, 21);
            this.txtComp.TabIndex = 49;
            this.tipCCB.SetToolTip(this.txtComp, "Complemento");
            this.txtComp.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(14, 54);
            this.lblEndereco.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(56, 13);
            this.lblEndereco.TabIndex = 52;
            this.lblEndereco.Text = "Endereço:";
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Location = new System.Drawing.Point(289, 84);
            this.lblComp.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(54, 13);
            this.lblComp.TabIndex = 58;
            this.lblComp.Text = "Complem:";
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(14, 26);
            this.lblCep.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(30, 13);
            this.lblCep.TabIndex = 53;
            this.lblCep.Text = "CEP:";
            // 
            // lblBairroEnd
            // 
            this.lblBairroEnd.AutoSize = true;
            this.lblBairroEnd.Location = new System.Drawing.Point(14, 84);
            this.lblBairroEnd.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBairroEnd.Name = "lblBairroEnd";
            this.lblBairroEnd.Size = new System.Drawing.Size(39, 13);
            this.lblBairroEnd.TabIndex = 57;
            this.lblBairroEnd.Text = "Bairro:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.White;
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndereco.Location = new System.Drawing.Point(87, 52);
            this.txtEndereco.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEndereco.MaxLength = 150;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(412, 21);
            this.txtEndereco.TabIndex = 46;
            this.tipCCB.SetToolTip(this.txtEndereco, "Endereço");
            this.txtEndereco.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCep
            // 
            this.txtCep.BackColor = System.Drawing.Color.White;
            this.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCep.Location = new System.Drawing.Point(87, 23);
            this.txtCep.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(85, 21);
            this.txtCep.TabIndex = 44;
            this.tipCCB.SetToolTip(this.txtCep, "Informe o Cep ou clique na lupa para buscar");
            this.txtCep.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Cep;
            this.txtCep.Leave += new System.EventHandler(this.txtCep_Leave);
            // 
            // lblNumEnd
            // 
            this.lblNumEnd.AutoSize = true;
            this.lblNumEnd.Location = new System.Drawing.Point(523, 54);
            this.lblNumEnd.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNumEnd.Name = "lblNumEnd";
            this.lblNumEnd.Size = new System.Drawing.Size(23, 13);
            this.lblNumEnd.TabIndex = 54;
            this.lblNumEnd.Text = "Nº:";
            // 
            // btnCep
            // 
            this.btnCep.Image = global::ccbpess.Properties.Resources.Lupa;
            this.btnCep.Location = new System.Drawing.Point(175, 22);
            this.btnCep.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCep.Name = "btnCep";
            this.btnCep.Size = new System.Drawing.Size(23, 23);
            this.btnCep.TabIndex = 45;
            this.tipCCB.SetToolTip(this.btnCep, "Buscar o Cep");
            this.btnCep.UseVisualStyleBackColor = true;
            this.btnCep.Click += new System.EventHandler(this.btnCep_Click);
            // 
            // txtNum
            // 
            this.txtNum.BackColor = System.Drawing.Color.White;
            this.txtNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNum.Location = new System.Drawing.Point(555, 52);
            this.txtNum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(61, 21);
            this.txtNum.TabIndex = 47;
            this.txtNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtNum, "Numero");
            this.txtNum.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // tabMinisterio
            // 
            this.tabMinisterio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabMinisterio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabMinisterio.Controls.Add(this.btnInserir);
            this.tabMinisterio.Controls.Add(this.btnExcluir);
            this.tabMinisterio.Controls.Add(this.gpoMinisterio);
            this.tabMinisterio.Controls.Add(this.gridMinisterio);
            this.tabMinisterio.Location = new System.Drawing.Point(4, 22);
            this.tabMinisterio.Name = "tabMinisterio";
            this.tabMinisterio.Padding = new System.Windows.Forms.Padding(3);
            this.tabMinisterio.Size = new System.Drawing.Size(658, 386);
            this.tabMinisterio.TabIndex = 1;
            this.tabMinisterio.Text = "Ministério";
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(463, 348);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(90, 30);
            this.btnInserir.TabIndex = 109;
            this.btnInserir.Text = "&Inserir";
            this.tipCCB.SetToolTip(this.btnInserir, "Inserir");
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(556, 348);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(90, 30);
            this.btnExcluir.TabIndex = 108;
            this.btnExcluir.Text = "&Excluir";
            this.tipCCB.SetToolTip(this.btnExcluir, "Excluir");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // gpoMinisterio
            // 
            this.gpoMinisterio.Controls.Add(this.txtDataApresentacao);
            this.gpoMinisterio.Controls.Add(this.lblDataApresentacao);
            this.gpoMinisterio.Controls.Add(this.btnSalvarItem);
            this.gpoMinisterio.Controls.Add(this.txtMinisterio);
            this.gpoMinisterio.Controls.Add(this.btnCancelarItem);
            this.gpoMinisterio.Controls.Add(this.lblMinisterio);
            this.gpoMinisterio.Controls.Add(this.txtPessoa);
            this.gpoMinisterio.Controls.Add(this.lbPessoa);
            this.gpoMinisterio.Controls.Add(this.lblPessoa);
            this.gpoMinisterio.Controls.Add(this.btnPessoa);
            this.gpoMinisterio.Location = new System.Drawing.Point(13, 8);
            this.gpoMinisterio.Name = "gpoMinisterio";
            this.gpoMinisterio.Size = new System.Drawing.Size(633, 121);
            this.gpoMinisterio.TabIndex = 105;
            this.gpoMinisterio.TabStop = false;
            this.gpoMinisterio.Text = "Irmãos(ãs) que atendem";
            // 
            // txtDataApresentacao
            // 
            this.txtDataApresentacao.BackColor = System.Drawing.Color.LightGray;
            this.txtDataApresentacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataApresentacao.Enabled = false;
            this.txtDataApresentacao.Location = new System.Drawing.Point(360, 56);
            this.txtDataApresentacao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataApresentacao.Name = "txtDataApresentacao";
            this.txtDataApresentacao.Size = new System.Drawing.Size(88, 21);
            this.txtDataApresentacao.TabIndex = 95;
            this.txtDataApresentacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataApresentacao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataApresentacao
            // 
            this.lblDataApresentacao.AutoSize = true;
            this.lblDataApresentacao.Enabled = false;
            this.lblDataApresentacao.Location = new System.Drawing.Point(246, 60);
            this.lblDataApresentacao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataApresentacao.Name = "lblDataApresentacao";
            this.lblDataApresentacao.Size = new System.Drawing.Size(104, 13);
            this.lblDataApresentacao.TabIndex = 94;
            this.lblDataApresentacao.Text = "Data Apresentação:";
            // 
            // btnSalvarItem
            // 
            this.btnSalvarItem.Location = new System.Drawing.Point(432, 87);
            this.btnSalvarItem.Name = "btnSalvarItem";
            this.btnSalvarItem.Size = new System.Drawing.Size(90, 25);
            this.btnSalvarItem.TabIndex = 95;
            this.btnSalvarItem.Text = "&Salvar ítem";
            this.tipCCB.SetToolTip(this.btnSalvarItem, "Salvar dados");
            this.btnSalvarItem.UseVisualStyleBackColor = true;
            this.btnSalvarItem.Click += new System.EventHandler(this.btnSalvarItem_Click);
            // 
            // txtMinisterio
            // 
            this.txtMinisterio.BackColor = System.Drawing.Color.LightGray;
            this.txtMinisterio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMinisterio.Enabled = false;
            this.txtMinisterio.Location = new System.Drawing.Point(89, 56);
            this.txtMinisterio.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtMinisterio.Name = "txtMinisterio";
            this.txtMinisterio.Size = new System.Drawing.Size(121, 21);
            this.txtMinisterio.TabIndex = 93;
            this.txtMinisterio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinisterio.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // btnCancelarItem
            // 
            this.btnCancelarItem.Location = new System.Drawing.Point(527, 87);
            this.btnCancelarItem.Name = "btnCancelarItem";
            this.btnCancelarItem.Size = new System.Drawing.Size(90, 25);
            this.btnCancelarItem.TabIndex = 94;
            this.btnCancelarItem.Text = "&Cancelar ítem";
            this.tipCCB.SetToolTip(this.btnCancelarItem, "Cancelar dados");
            this.btnCancelarItem.UseVisualStyleBackColor = true;
            this.btnCancelarItem.Click += new System.EventHandler(this.btnCancelarItem_Click);
            // 
            // lblMinisterio
            // 
            this.lblMinisterio.AutoSize = true;
            this.lblMinisterio.Enabled = false;
            this.lblMinisterio.Location = new System.Drawing.Point(16, 60);
            this.lblMinisterio.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMinisterio.Name = "lblMinisterio";
            this.lblMinisterio.Size = new System.Drawing.Size(56, 13);
            this.lblMinisterio.TabIndex = 92;
            this.lblMinisterio.Text = "Ministério:";
            // 
            // txtPessoa
            // 
            this.txtPessoa.BackColor = System.Drawing.Color.White;
            this.txtPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPessoa.Location = new System.Drawing.Point(89, 24);
            this.txtPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(63, 21);
            this.txtPessoa.TabIndex = 83;
            this.txtPessoa.Text = "00000";
            this.txtPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtPessoa, "Informe o código da pessoa ou clique na lupa para buscar");
            this.txtPessoa.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtPessoa.Leave += new System.EventHandler(this.txtPessoa_Leave);
            // 
            // lbPessoa
            // 
            this.lbPessoa.AutoSize = true;
            this.lbPessoa.Location = new System.Drawing.Point(16, 28);
            this.lbPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPessoa.Name = "lbPessoa";
            this.lbPessoa.Size = new System.Drawing.Size(53, 13);
            this.lbPessoa.TabIndex = 81;
            this.lbPessoa.Text = "Irmão(ã):";
            // 
            // lblPessoa
            // 
            this.lblPessoa.Location = new System.Drawing.Point(187, 27);
            this.lblPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPessoa.Name = "lblPessoa";
            this.lblPessoa.Size = new System.Drawing.Size(423, 18);
            this.lblPessoa.TabIndex = 91;
            // 
            // btnPessoa
            // 
            this.btnPessoa.Image = global::ccbpess.Properties.Resources.Lupa;
            this.btnPessoa.Location = new System.Drawing.Point(155, 23);
            this.btnPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(23, 23);
            this.btnPessoa.TabIndex = 84;
            this.tipCCB.SetToolTip(this.btnPessoa, "Buscar a pessoa");
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // gridMinisterio
            // 
            this.gridMinisterio.AllowUserToAddRows = false;
            this.gridMinisterio.AllowUserToDeleteRows = false;
            this.gridMinisterio.AllowUserToResizeRows = false;
            this.gridMinisterio.BackgroundColor = System.Drawing.Color.White;
            this.gridMinisterio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMinisterio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMinisterio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMinisterio.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMinisterio.DisabledCell = null;
            this.gridMinisterio.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridMinisterio.EnableHeadersVisualStyles = false;
            this.gridMinisterio.Location = new System.Drawing.Point(13, 137);
            this.gridMinisterio.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridMinisterio.MultiSelect = false;
            this.gridMinisterio.Name = "gridMinisterio";
            this.gridMinisterio.ReadOnly = true;
            this.gridMinisterio.RowHeadersVisible = false;
            this.gridMinisterio.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMinisterio.RowTemplate.Height = 18;
            this.gridMinisterio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMinisterio.Size = new System.Drawing.Size(633, 204);
            this.gridMinisterio.TabIndex = 106;
            this.gridMinisterio.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridMinisterio_RowStateChanged);
            this.gridMinisterio.SelectionChanged += new System.EventHandler(this.gridMinisterio_SelectionChanged);
            // 
            // frmCCB
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(686, 466);
            this.Controls.Add(this.tabCCB);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCCB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comum Congregação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCCB_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCCB_FormClosed);
            this.Load += new System.EventHandler(this.frmCCB_Load);
            this.tabCCB.ResumeLayout(false);
            this.tabGeral.ResumeLayout(false);
            this.tabGeral.PerformLayout();
            this.gpoSituacao.ResumeLayout(false);
            this.gpoSituacao.PerformLayout();
            this.gpoContato.ResumeLayout(false);
            this.gpoContato.PerformLayout();
            this.gpoEndereco.ResumeLayout(false);
            this.gpoEndereco.PerformLayout();
            this.tabMinisterio.ResumeLayout(false);
            this.gpoMinisterio.ResumeLayout(false);
            this.gpoMinisterio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMinisterio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TabControl tabCCB;
        private System.Windows.Forms.TabPage tabGeral;
        private BLL.validacoes.Controles.TextBoxPersonal txtComum;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gpoContato;
        private BLL.validacoes.Controles.TextBoxPersonal txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private BLL.validacoes.Controles.TextBoxPersonal txtCel;
        private System.Windows.Forms.Label lblCel;
        private BLL.validacoes.Controles.TextBoxPersonal txtTel;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.GroupBox gpoEndereco;
        private BLL.validacoes.Controles.TextBoxPersonal txtBairro;
        private BLL.validacoes.Controles.TextBoxPersonal txtComp;
        private System.Windows.Forms.Label lblEndereco;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblCep;
        private System.Windows.Forms.Label lblBairroEnd;
        private BLL.validacoes.Controles.TextBoxPersonal txtEndereco;
        private BLL.validacoes.Controles.TextBoxPersonal txtCep;
        private System.Windows.Forms.Label lblNumEnd;
        private System.Windows.Forms.Button btnCep;
        private BLL.validacoes.Controles.TextBoxPersonal txtNum;
        private System.Windows.Forms.TabPage tabMinisterio;
        private System.Windows.Forms.GroupBox gpoMinisterio;
        private BLL.validacoes.Controles.TextBoxPersonal txtPessoa;
        private System.Windows.Forms.Label lbPessoa;
        private System.Windows.Forms.Label lblPessoa;
        private System.Windows.Forms.Button btnPessoa;
        private BLL.validacoes.Controles.DataGridViewPersonal gridMinisterio;
        private System.Windows.Forms.Button btnSalvarItem;
        private System.Windows.Forms.Button btnCancelarItem;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.ToolTip tipCCB;
        private BLL.validacoes.Controles.TextBoxPersonal txtMinisterio;
        private System.Windows.Forms.Label lblMinisterio;
        private System.Windows.Forms.TextBox txtCodigoCCB;
        private System.Windows.Forms.Label lblCodigoCCB;
        private BLL.validacoes.Controles.TextBoxPersonal txtEstado;
        private System.Windows.Forms.Label lblCidade;
        private System.Windows.Forms.Label lblEstado;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodCidade;
        private System.Windows.Forms.Label lbCidade;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataAbertura;
        private System.Windows.Forms.Label lblDataAbertura;
        private BLL.validacoes.Controles.TextBoxPersonal txtSkype;
        private System.Windows.Forms.Label lblSkype;
        private BLL.validacoes.Controles.TextBoxPersonal txtCnpj;
        private System.Windows.Forms.Label lblCnpj;
        private System.Windows.Forms.Label lblDescricaoRegiao;
        private System.Windows.Forms.Button btnRegiao;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodRegiao;
        private System.Windows.Forms.Label lbRegiao;
        private System.Windows.Forms.GroupBox gpoSituacao;
        private System.Windows.Forms.RadioButton optSitFechada;
        private System.Windows.Forms.RadioButton optSitAberta;
        private System.Windows.Forms.RadioButton optSitReforma;
        private System.Windows.Forms.RadioButton optSitConstrucao;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lblDescricaoRegional;
        private System.Windows.Forms.Label lbRegional;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataApresentacao;
        private System.Windows.Forms.Label lblDataApresentacao;
    }
}