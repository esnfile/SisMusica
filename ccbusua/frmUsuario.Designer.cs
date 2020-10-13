namespace ccbusua
{
    partial class frmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipUsuario = new System.Windows.Forms.ToolTip(this.components);
            this.lblSeg = new System.Windows.Forms.Label();
            this.lblBaixa = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.lblAlta = new System.Windows.Forms.Label();
            this.imgUsuario = new System.Windows.Forms.ImageList(this.components);
            this.pctBaixa = new System.Windows.Forms.PictureBox();
            this.pctMedia = new System.Windows.Forms.PictureBox();
            this.pctAlta = new System.Windows.Forms.PictureBox();
            this.tabUsuario = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabGeral = new System.Windows.Forms.TabPage();
            this.gpoAcesso = new System.Windows.Forms.GroupBox();
            this.tvwAcesso = new System.Windows.Forms.TreeView();
            this.gpoUsuario = new System.Windows.Forms.GroupBox();
            this.chkAlteraSenha = new System.Windows.Forms.CheckBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.txtDataCadastro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.txtDataAlteraSenha = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNomePessoa = new System.Windows.Forms.Label();
            this.lblDataAlteraSenha = new System.Windows.Forms.Label();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.txtSenha = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtPessoa = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnSenha = new System.Windows.Forms.Button();
            this.lbPessoa = new System.Windows.Forms.Label();
            this.txtUsuario = new BLL.validacoes.Controles.TextBoxPersonal();
            this.chkSupervisor = new System.Windows.Forms.CheckBox();
            this.lblAvisoLogin = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.tabComum = new System.Windows.Forms.TabPage();
            this.gpoComum = new System.Windows.Forms.GroupBox();
            this.btnDesComum = new System.Windows.Forms.Button();
            this.btnSelComum = new System.Windows.Forms.Button();
            this.gridComum = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.gpoRegiao = new System.Windows.Forms.GroupBox();
            this.btnDesRegiao = new System.Windows.Forms.Button();
            this.btnSelRegiao = new System.Windows.Forms.Button();
            this.gridRegiao = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.cboRegional = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegional = new System.Windows.Forms.Label();
            this.gpoCargo = new System.Windows.Forms.GroupBox();
            this.btnDesCargo = new System.Windows.Forms.Button();
            this.btnSelCargo = new System.Windows.Forms.Button();
            this.gridCargo = new BLL.validacoes.Controles.DataGridViewPersonal();
            ((System.ComponentModel.ISupportInitialize)(this.pctBaixa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMedia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAlta)).BeginInit();
            this.tabUsuario.SuspendLayout();
            this.tabGeral.SuspendLayout();
            this.gpoAcesso.SuspendLayout();
            this.gpoUsuario.SuspendLayout();
            this.tabComum.SuspendLayout();
            this.gpoComum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).BeginInit();
            this.gpoRegiao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
            this.gpoCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(452, 433);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(85, 30);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "&Salvar";
            this.tipUsuario.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(539, 433);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 30);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "&Cancelar";
            this.tipUsuario.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSeg
            // 
            this.lblSeg.AutoSize = true;
            this.lblSeg.Location = new System.Drawing.Point(15, 439);
            this.lblSeg.Name = "lblSeg";
            this.lblSeg.Size = new System.Drawing.Size(103, 13);
            this.lblSeg.TabIndex = 100;
            this.lblSeg.Text = "Nível de Segurança:";
            // 
            // lblBaixa
            // 
            this.lblBaixa.AutoSize = true;
            this.lblBaixa.Location = new System.Drawing.Point(255, 439);
            this.lblBaixa.Name = "lblBaixa";
            this.lblBaixa.Size = new System.Drawing.Size(33, 13);
            this.lblBaixa.TabIndex = 99;
            this.lblBaixa.Text = "Baixa";
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Location = new System.Drawing.Point(192, 439);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(35, 13);
            this.lblMedia.TabIndex = 97;
            this.lblMedia.Text = "Média";
            // 
            // lblAlta
            // 
            this.lblAlta.AutoSize = true;
            this.lblAlta.Location = new System.Drawing.Point(138, 439);
            this.lblAlta.Name = "lblAlta";
            this.lblAlta.Size = new System.Drawing.Size(26, 13);
            this.lblAlta.TabIndex = 95;
            this.lblAlta.Text = "Alta";
            // 
            // imgUsuario
            // 
            this.imgUsuario.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUsuario.ImageStream")));
            this.imgUsuario.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUsuario.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgUsuario.Images.SetKeyName(1, "BolaAmarela.ico");
            this.imgUsuario.Images.SetKeyName(2, "BolaVermelha.ico");
            // 
            // pctBaixa
            // 
            this.pctBaixa.Location = new System.Drawing.Point(239, 436);
            this.pctBaixa.Name = "pctBaixa";
            this.pctBaixa.Size = new System.Drawing.Size(16, 20);
            this.pctBaixa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctBaixa.TabIndex = 98;
            this.pctBaixa.TabStop = false;
            // 
            // pctMedia
            // 
            this.pctMedia.Location = new System.Drawing.Point(176, 436);
            this.pctMedia.Name = "pctMedia";
            this.pctMedia.Size = new System.Drawing.Size(16, 20);
            this.pctMedia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctMedia.TabIndex = 96;
            this.pctMedia.TabStop = false;
            // 
            // pctAlta
            // 
            this.pctAlta.Location = new System.Drawing.Point(121, 436);
            this.pctAlta.Name = "pctAlta";
            this.pctAlta.Size = new System.Drawing.Size(16, 20);
            this.pctAlta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAlta.TabIndex = 94;
            this.pctAlta.TabStop = false;
            // 
            // tabUsuario
            // 
            this.tabUsuario.Controls.Add(this.tabGeral);
            this.tabUsuario.Controls.Add(this.tabComum);
            this.tabUsuario.Location = new System.Drawing.Point(9, 9);
            this.tabUsuario.Name = "tabUsuario";
            this.tabUsuario.SelectedIndex = 0;
            this.tabUsuario.Size = new System.Drawing.Size(614, 421);
            this.tabUsuario.TabIndex = 101;
            this.tabUsuario.SelectedIndexChanged += new System.EventHandler(this.tabUsuario_SelectedIndexChanged);
            // 
            // tabGeral
            // 
            this.tabGeral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabGeral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabGeral.Controls.Add(this.gpoAcesso);
            this.tabGeral.Controls.Add(this.gpoUsuario);
            this.tabGeral.Location = new System.Drawing.Point(4, 22);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeral.Size = new System.Drawing.Size(606, 395);
            this.tabGeral.TabIndex = 0;
            this.tabGeral.Text = "Geral";
            // 
            // gpoAcesso
            // 
            this.gpoAcesso.Controls.Add(this.tvwAcesso);
            this.gpoAcesso.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoAcesso.Location = new System.Drawing.Point(11, 147);
            this.gpoAcesso.Name = "gpoAcesso";
            this.gpoAcesso.Size = new System.Drawing.Size(585, 242);
            this.gpoAcesso.TabIndex = 14;
            this.gpoAcesso.TabStop = false;
            this.gpoAcesso.Text = "Liberar ou bloquear acesso aos Módulos e Rotinas";
            // 
            // tvwAcesso
            // 
            this.tvwAcesso.BackColor = System.Drawing.SystemColors.Window;
            this.tvwAcesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvwAcesso.CheckBoxes = true;
            this.tvwAcesso.FullRowSelect = true;
            this.tvwAcesso.Location = new System.Drawing.Point(14, 19);
            this.tvwAcesso.Name = "tvwAcesso";
            this.tvwAcesso.PathSeparator = "/";
            this.tvwAcesso.Size = new System.Drawing.Size(556, 212);
            this.tvwAcesso.TabIndex = 13;
            this.tvwAcesso.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwAcesso_AfterCheck);
            // 
            // gpoUsuario
            // 
            this.gpoUsuario.Controls.Add(this.chkAlteraSenha);
            this.gpoUsuario.Controls.Add(this.chkAtivo);
            this.gpoUsuario.Controls.Add(this.txtDataCadastro);
            this.gpoUsuario.Controls.Add(this.lblDataCadastro);
            this.gpoUsuario.Controls.Add(this.txtDataAlteraSenha);
            this.gpoUsuario.Controls.Add(this.lblNomePessoa);
            this.gpoUsuario.Controls.Add(this.lblDataAlteraSenha);
            this.gpoUsuario.Controls.Add(this.btnPessoa);
            this.gpoUsuario.Controls.Add(this.txtSenha);
            this.gpoUsuario.Controls.Add(this.txtPessoa);
            this.gpoUsuario.Controls.Add(this.btnSenha);
            this.gpoUsuario.Controls.Add(this.lbPessoa);
            this.gpoUsuario.Controls.Add(this.txtUsuario);
            this.gpoUsuario.Controls.Add(this.chkSupervisor);
            this.gpoUsuario.Controls.Add(this.lblAvisoLogin);
            this.gpoUsuario.Controls.Add(this.txtCodigo);
            this.gpoUsuario.Controls.Add(this.lblCodigo);
            this.gpoUsuario.Controls.Add(this.lblSenha);
            this.gpoUsuario.Controls.Add(this.lblLogin);
            this.gpoUsuario.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoUsuario.Location = new System.Drawing.Point(11, 4);
            this.gpoUsuario.Name = "gpoUsuario";
            this.gpoUsuario.Size = new System.Drawing.Size(585, 137);
            this.gpoUsuario.TabIndex = 13;
            this.gpoUsuario.TabStop = false;
            this.gpoUsuario.Text = "Usuário e Senha";
            // 
            // chkAlteraSenha
            // 
            this.chkAlteraSenha.AutoSize = true;
            this.chkAlteraSenha.Enabled = false;
            this.chkAlteraSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAlteraSenha.Location = new System.Drawing.Point(287, 105);
            this.chkAlteraSenha.Name = "chkAlteraSenha";
            this.chkAlteraSenha.Size = new System.Drawing.Size(176, 17);
            this.chkAlteraSenha.TabIndex = 130;
            this.chkAlteraSenha.Text = "Altera senha no próximo Login?";
            this.chkAlteraSenha.UseVisualStyleBackColor = true;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtivo.Location = new System.Drawing.Point(263, 17);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(95, 17);
            this.chkAtivo.TabIndex = 3;
            this.chkAtivo.Text = "Usuário Ativo?";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BackColor = System.Drawing.Color.LightGray;
            this.txtDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDataCadastro.Location = new System.Drawing.Point(478, 15);
            this.txtDataCadastro.MaxLength = 10;
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.ReadOnly = true;
            this.txtDataCadastro.Size = new System.Drawing.Size(88, 21);
            this.txtDataCadastro.TabIndex = 4;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataCadastro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Enabled = false;
            this.lblDataCadastro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDataCadastro.Location = new System.Drawing.Point(389, 19);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(81, 13);
            this.lblDataCadastro.TabIndex = 129;
            this.lblDataCadastro.Text = "Data Cadastro:";
            // 
            // txtDataAlteraSenha
            // 
            this.txtDataAlteraSenha.BackColor = System.Drawing.Color.LightGray;
            this.txtDataAlteraSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataAlteraSenha.Enabled = false;
            this.txtDataAlteraSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDataAlteraSenha.Location = new System.Drawing.Point(478, 67);
            this.txtDataAlteraSenha.MaxLength = 10;
            this.txtDataAlteraSenha.Name = "txtDataAlteraSenha";
            this.txtDataAlteraSenha.ReadOnly = true;
            this.txtDataAlteraSenha.Size = new System.Drawing.Size(88, 21);
            this.txtDataAlteraSenha.TabIndex = 10;
            this.txtDataAlteraSenha.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataAlteraSenha.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblNomePessoa
            // 
            this.lblNomePessoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNomePessoa.Location = new System.Drawing.Point(165, 43);
            this.lblNomePessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNomePessoa.Name = "lblNomePessoa";
            this.lblNomePessoa.Size = new System.Drawing.Size(401, 17);
            this.lblNomePessoa.TabIndex = 128;
            // 
            // lblDataAlteraSenha
            // 
            this.lblDataAlteraSenha.AutoSize = true;
            this.lblDataAlteraSenha.Enabled = false;
            this.lblDataAlteraSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDataAlteraSenha.Location = new System.Drawing.Point(358, 71);
            this.lblDataAlteraSenha.Name = "lblDataAlteraSenha";
            this.lblDataAlteraSenha.Size = new System.Drawing.Size(122, 13);
            this.lblDataAlteraSenha.TabIndex = 89;
            this.lblDataAlteraSenha.Text = "Última Alteração Senha:";
            // 
            // btnPessoa
            // 
            this.btnPessoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPessoa.Image = global::ccbusua.Properties.Resources.Lupa;
            this.btnPessoa.Location = new System.Drawing.Point(134, 40);
            this.btnPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(23, 23);
            this.btnPessoa.TabIndex = 6;
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // txtSenha
            // 
            this.txtSenha.BackColor = System.Drawing.Color.LightGray;
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Enabled = false;
            this.txtSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSenha.Location = new System.Drawing.Point(254, 67);
            this.txtSenha.MaxLength = 20;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(87, 21);
            this.txtSenha.TabIndex = 9;
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtPessoa
            // 
            this.txtPessoa.BackColor = System.Drawing.Color.White;
            this.txtPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPessoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPessoa.Location = new System.Drawing.Point(73, 41);
            this.txtPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(58, 21);
            this.txtPessoa.TabIndex = 5;
            this.tipUsuario.SetToolTip(this.txtPessoa, "Informe a Pessoa, ou clique na lupa para buscar");
            this.txtPessoa.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtPessoa.Leave += new System.EventHandler(this.txtPessoa_Leave);
            // 
            // btnSenha
            // 
            this.btnSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSenha.Location = new System.Drawing.Point(478, 95);
            this.btnSenha.Name = "btnSenha";
            this.btnSenha.Size = new System.Drawing.Size(88, 35);
            this.btnSenha.TabIndex = 11;
            this.btnSenha.Text = "Alterar Senha";
            this.btnSenha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSenha.UseVisualStyleBackColor = true;
            this.btnSenha.Click += new System.EventHandler(this.btnSenha_Click);
            // 
            // lbPessoa
            // 
            this.lbPessoa.AutoSize = true;
            this.lbPessoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbPessoa.Location = new System.Drawing.Point(22, 45);
            this.lbPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPessoa.Name = "lbPessoa";
            this.lbPessoa.Size = new System.Drawing.Size(45, 13);
            this.lbPessoa.TabIndex = 126;
            this.lbPessoa.Text = "Pessoa:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUsuario.Location = new System.Drawing.Point(73, 67);
            this.txtUsuario.MaxLength = 25;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(119, 21);
            this.txtUsuario.TabIndex = 7;
            this.txtUsuario.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // chkSupervisor
            // 
            this.chkSupervisor.AutoSize = true;
            this.chkSupervisor.Enabled = false;
            this.chkSupervisor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSupervisor.Location = new System.Drawing.Point(24, 106);
            this.chkSupervisor.Name = "chkSupervisor";
            this.chkSupervisor.Size = new System.Drawing.Size(254, 17);
            this.chkSupervisor.TabIndex = 8;
            this.chkSupervisor.Text = "Senha de Supervisor? (Acesso total ao sistema)";
            this.chkSupervisor.UseVisualStyleBackColor = true;
            this.chkSupervisor.CheckedChanged += new System.EventHandler(this.chkSupervisor_CheckedChanged);
            // 
            // lblAvisoLogin
            // 
            this.lblAvisoLogin.AutoSize = true;
            this.lblAvisoLogin.Font = new System.Drawing.Font("Tahoma", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAvisoLogin.Location = new System.Drawing.Point(66, 87);
            this.lblAvisoLogin.Name = "lblAvisoLogin";
            this.lblAvisoLogin.Size = new System.Drawing.Size(128, 12);
            this.lblAvisoLogin.TabIndex = 6;
            this.lblAvisoLogin.Text = "Login máximo 25 caracteres";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCodigo.Location = new System.Drawing.Point(73, 15);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(58, 21);
            this.txtCodigo.TabIndex = 2;
            this.txtCodigo.Text = "000000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipUsuario.SetToolTip(this.txtCodigo, "Código");
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCodigo.Location = new System.Drawing.Point(22, 19);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 116;
            this.lblCodigo.Text = "Código:";
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Enabled = false;
            this.lblSenha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSenha.Location = new System.Drawing.Point(208, 71);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(41, 13);
            this.lblSenha.TabIndex = 2;
            this.lblSenha.Text = "Senha:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLogin.Location = new System.Drawing.Point(22, 71);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(36, 13);
            this.lblLogin.TabIndex = 1;
            this.lblLogin.Text = "Login:";
            // 
            // tabComum
            // 
            this.tabComum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabComum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabComum.Controls.Add(this.gpoComum);
            this.tabComum.Controls.Add(this.gpoRegiao);
            this.tabComum.Controls.Add(this.gpoCargo);
            this.tabComum.Location = new System.Drawing.Point(4, 22);
            this.tabComum.Name = "tabComum";
            this.tabComum.Padding = new System.Windows.Forms.Padding(3);
            this.tabComum.Size = new System.Drawing.Size(606, 395);
            this.tabComum.TabIndex = 1;
            this.tabComum.Text = "Liberações Avançadas";
            // 
            // gpoComum
            // 
            this.gpoComum.Controls.Add(this.btnDesComum);
            this.gpoComum.Controls.Add(this.btnSelComum);
            this.gpoComum.Controls.Add(this.gridComum);
            this.gpoComum.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoComum.Location = new System.Drawing.Point(288, 6);
            this.gpoComum.Name = "gpoComum";
            this.gpoComum.Size = new System.Drawing.Size(310, 381);
            this.gpoComum.TabIndex = 1;
            this.gpoComum.TabStop = false;
            this.gpoComum.Text = "Liberar acesso a comuns congregações";
            // 
            // btnDesComum
            // 
            this.btnDesComum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesComum.Image = global::ccbusua.Properties.Resources.DesTodos;
            this.btnDesComum.Location = new System.Drawing.Point(224, 352);
            this.btnDesComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesComum.Name = "btnDesComum";
            this.btnDesComum.Size = new System.Drawing.Size(80, 25);
            this.btnDesComum.TabIndex = 5;
            this.btnDesComum.Text = "Nenhuma";
            this.btnDesComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesComum.UseVisualStyleBackColor = true;
            this.btnDesComum.Click += new System.EventHandler(this.btnDesComum_Click);
            // 
            // btnSelComum
            // 
            this.btnSelComum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelComum.Image = global::ccbusua.Properties.Resources.SelTodos;
            this.btnSelComum.Location = new System.Drawing.Point(139, 352);
            this.btnSelComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelComum.Name = "btnSelComum";
            this.btnSelComum.Size = new System.Drawing.Size(80, 25);
            this.btnSelComum.TabIndex = 4;
            this.btnSelComum.Text = "Todas";
            this.btnSelComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelComum.UseVisualStyleBackColor = true;
            this.btnSelComum.Click += new System.EventHandler(this.btnSelComum_Click);
            // 
            // gridComum
            // 
            this.gridComum.AllowUserToAddRows = false;
            this.gridComum.AllowUserToDeleteRows = false;
            this.gridComum.AllowUserToResizeRows = false;
            this.gridComum.BackgroundColor = System.Drawing.Color.White;
            this.gridComum.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridComum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridComum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridComum.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridComum.DisabledCell = null;
            this.gridComum.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridComum.EnableHeadersVisualStyles = false;
            this.gridComum.Location = new System.Drawing.Point(6, 15);
            this.gridComum.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridComum.MultiSelect = false;
            this.gridComum.Name = "gridComum";
            this.gridComum.ReadOnly = true;
            this.gridComum.RowHeadersVisible = false;
            this.gridComum.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridComum.RowTemplate.Height = 18;
            this.gridComum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridComum.Size = new System.Drawing.Size(298, 335);
            this.gridComum.TabIndex = 1;
            this.gridComum.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComum_CellClick);
            // 
            // gpoRegiao
            // 
            this.gpoRegiao.Controls.Add(this.btnDesRegiao);
            this.gpoRegiao.Controls.Add(this.btnSelRegiao);
            this.gpoRegiao.Controls.Add(this.gridRegiao);
            this.gpoRegiao.Controls.Add(this.cboRegional);
            this.gpoRegiao.Controls.Add(this.lblRegional);
            this.gpoRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gpoRegiao.Location = new System.Drawing.Point(6, 178);
            this.gpoRegiao.Name = "gpoRegiao";
            this.gpoRegiao.Size = new System.Drawing.Size(274, 209);
            this.gpoRegiao.TabIndex = 0;
            this.gpoRegiao.TabStop = false;
            // 
            // btnDesRegiao
            // 
            this.btnDesRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesRegiao.Image = global::ccbusua.Properties.Resources.DesTodos;
            this.btnDesRegiao.Location = new System.Drawing.Point(186, 180);
            this.btnDesRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesRegiao.Name = "btnDesRegiao";
            this.btnDesRegiao.Size = new System.Drawing.Size(80, 25);
            this.btnDesRegiao.TabIndex = 24;
            this.btnDesRegiao.Text = "Nenhum";
            this.btnDesRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesRegiao.UseVisualStyleBackColor = true;
            this.btnDesRegiao.Click += new System.EventHandler(this.btnDesRegiao_Click);
            // 
            // btnSelRegiao
            // 
            this.btnSelRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelRegiao.Image = global::ccbusua.Properties.Resources.SelTodos;
            this.btnSelRegiao.Location = new System.Drawing.Point(102, 180);
            this.btnSelRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelRegiao.Name = "btnSelRegiao";
            this.btnSelRegiao.Size = new System.Drawing.Size(80, 25);
            this.btnSelRegiao.TabIndex = 23;
            this.btnSelRegiao.Text = "Todas";
            this.btnSelRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelRegiao.UseVisualStyleBackColor = true;
            this.btnSelRegiao.Click += new System.EventHandler(this.btnSelRegiao_Click);
            // 
            // gridRegiao
            // 
            this.gridRegiao.AllowUserToAddRows = false;
            this.gridRegiao.AllowUserToDeleteRows = false;
            this.gridRegiao.AllowUserToResizeRows = false;
            this.gridRegiao.BackgroundColor = System.Drawing.Color.White;
            this.gridRegiao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegiao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridRegiao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRegiao.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridRegiao.DisabledCell = null;
            this.gridRegiao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRegiao.EnableHeadersVisualStyles = false;
            this.gridRegiao.Location = new System.Drawing.Point(7, 38);
            this.gridRegiao.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridRegiao.MultiSelect = false;
            this.gridRegiao.Name = "gridRegiao";
            this.gridRegiao.ReadOnly = true;
            this.gridRegiao.RowHeadersVisible = false;
            this.gridRegiao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRegiao.RowTemplate.Height = 18;
            this.gridRegiao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegiao.Size = new System.Drawing.Size(259, 140);
            this.gridRegiao.TabIndex = 0;
            this.gridRegiao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellClick);
            // 
            // cboRegional
            // 
            this.cboRegional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegional.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cboRegional.FormattingEnabled = true;
            this.cboRegional.Location = new System.Drawing.Point(56, 13);
            this.cboRegional.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(210, 21);
            this.cboRegional.TabIndex = 21;
            this.cboRegional.SelectionChangeCommitted += new System.EventHandler(this.cboRegional_SelectionChangeCommitted);
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRegional.Location = new System.Drawing.Point(7, 16);
            this.lblRegional.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegional.Name = "lblRegional";
            this.lblRegional.Size = new System.Drawing.Size(52, 13);
            this.lblRegional.TabIndex = 25;
            this.lblRegional.Text = "Regional:";
            // 
            // gpoCargo
            // 
            this.gpoCargo.Controls.Add(this.btnDesCargo);
            this.gpoCargo.Controls.Add(this.btnSelCargo);
            this.gpoCargo.Controls.Add(this.gridCargo);
            this.gpoCargo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoCargo.Location = new System.Drawing.Point(6, 6);
            this.gpoCargo.Name = "gpoCargo";
            this.gpoCargo.Size = new System.Drawing.Size(274, 172);
            this.gpoCargo.TabIndex = 0;
            this.gpoCargo.TabStop = false;
            this.gpoCargo.Text = "Liberar acesso a cargos e ministérios";
            // 
            // btnDesCargo
            // 
            this.btnDesCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesCargo.Image = global::ccbusua.Properties.Resources.DesTodos;
            this.btnDesCargo.Location = new System.Drawing.Point(186, 141);
            this.btnDesCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesCargo.Name = "btnDesCargo";
            this.btnDesCargo.Size = new System.Drawing.Size(80, 25);
            this.btnDesCargo.TabIndex = 5;
            this.btnDesCargo.Text = "Nenhum";
            this.btnDesCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesCargo.UseVisualStyleBackColor = true;
            this.btnDesCargo.Click += new System.EventHandler(this.btnDesCargo_Click);
            // 
            // btnSelCargo
            // 
            this.btnSelCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelCargo.Image = global::ccbusua.Properties.Resources.SelTodos;
            this.btnSelCargo.Location = new System.Drawing.Point(101, 141);
            this.btnSelCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelCargo.Name = "btnSelCargo";
            this.btnSelCargo.Size = new System.Drawing.Size(80, 25);
            this.btnSelCargo.TabIndex = 4;
            this.btnSelCargo.Text = "Todos";
            this.btnSelCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelCargo.UseVisualStyleBackColor = true;
            this.btnSelCargo.Click += new System.EventHandler(this.btnSelCargo_Click);
            // 
            // gridCargo
            // 
            this.gridCargo.AllowUserToAddRows = false;
            this.gridCargo.AllowUserToDeleteRows = false;
            this.gridCargo.AllowUserToResizeRows = false;
            this.gridCargo.BackgroundColor = System.Drawing.Color.White;
            this.gridCargo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCargo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCargo.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridCargo.DisabledCell = null;
            this.gridCargo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCargo.EnableHeadersVisualStyles = false;
            this.gridCargo.Location = new System.Drawing.Point(7, 15);
            this.gridCargo.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridCargo.MultiSelect = false;
            this.gridCargo.Name = "gridCargo";
            this.gridCargo.ReadOnly = true;
            this.gridCargo.RowHeadersVisible = false;
            this.gridCargo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCargo.RowTemplate.Height = 18;
            this.gridCargo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCargo.Size = new System.Drawing.Size(259, 124);
            this.gridCargo.TabIndex = 0;
            this.gridCargo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCargo_CellClick);
            // 
            // frmUsuario
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(631, 469);
            this.Controls.Add(this.tabUsuario);
            this.Controls.Add(this.lblSeg);
            this.Controls.Add(this.lblBaixa);
            this.Controls.Add(this.pctBaixa);
            this.Controls.Add(this.lblMedia);
            this.Controls.Add(this.pctMedia);
            this.Controls.Add(this.lblAlta);
            this.Controls.Add(this.pctAlta);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuarios";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUsuario_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUsuario_FormClosed);
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctBaixa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMedia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAlta)).EndInit();
            this.tabUsuario.ResumeLayout(false);
            this.tabGeral.ResumeLayout(false);
            this.gpoAcesso.ResumeLayout(false);
            this.gpoUsuario.ResumeLayout(false);
            this.gpoUsuario.PerformLayout();
            this.tabComum.ResumeLayout(false);
            this.gpoComum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).EndInit();
            this.gpoRegiao.ResumeLayout(false);
            this.gpoRegiao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            this.gpoCargo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipUsuario;
        private System.Windows.Forms.Label lblSeg;
        private System.Windows.Forms.Label lblBaixa;
        private System.Windows.Forms.PictureBox pctBaixa;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.PictureBox pctMedia;
        private System.Windows.Forms.Label lblAlta;
        private System.Windows.Forms.PictureBox pctAlta;
        private System.Windows.Forms.ImageList imgUsuario;
        private BLL.validacoes.Controles.tabControlPersonal tabUsuario;
        private System.Windows.Forms.TabPage tabGeral;
        private System.Windows.Forms.GroupBox gpoAcesso;
        private System.Windows.Forms.TreeView tvwAcesso;
        private System.Windows.Forms.GroupBox gpoUsuario;
        private System.Windows.Forms.CheckBox chkAlteraSenha;
        private System.Windows.Forms.CheckBox chkAtivo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataCadastro;
        private System.Windows.Forms.Label lblDataCadastro;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataAlteraSenha;
        private System.Windows.Forms.Label lblNomePessoa;
        private System.Windows.Forms.Label lblDataAlteraSenha;
        private System.Windows.Forms.Button btnPessoa;
        private BLL.validacoes.Controles.TextBoxPersonal txtSenha;
        private BLL.validacoes.Controles.TextBoxPersonal txtPessoa;
        private System.Windows.Forms.Button btnSenha;
        private System.Windows.Forms.Label lbPessoa;
        private BLL.validacoes.Controles.TextBoxPersonal txtUsuario;
        private System.Windows.Forms.CheckBox chkSupervisor;
        private System.Windows.Forms.Label lblAvisoLogin;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TabPage tabComum;
        private System.Windows.Forms.GroupBox gpoComum;
        private System.Windows.Forms.GroupBox gpoCargo;
        private BLL.validacoes.Controles.DataGridViewPersonal gridComum;
        private BLL.validacoes.Controles.DataGridViewPersonal gridCargo;
        private System.Windows.Forms.Button btnDesComum;
        private System.Windows.Forms.Button btnSelComum;
        private System.Windows.Forms.Button btnDesCargo;
        private System.Windows.Forms.Button btnSelCargo;
        private System.Windows.Forms.GroupBox gpoRegiao;
        private System.Windows.Forms.Button btnDesRegiao;
        private System.Windows.Forms.Button btnSelRegiao;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegional;
        private System.Windows.Forms.Label lblRegional;
        private BLL.validacoes.Controles.DataGridViewPersonal gridRegiao;
    }
}