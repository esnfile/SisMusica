namespace ccbinst
{
    partial class frmTeoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeoria));
            this.tipTeoria = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.btnFotoCancelar = new System.Windows.Forms.Button();
            this.btnFotoSalvar = new System.Windows.Forms.Button();
            this.btnTeoria = new System.Windows.Forms.Button();
            this.btnVisual = new System.Windows.Forms.Button();
            this.pnlTeoria = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.gpoFoto = new System.Windows.Forms.GroupBox();
            this.lblAviso = new System.Windows.Forms.Label();
            this.lblContemFoto = new System.Windows.Forms.Label();
            this.pctFoto = new System.Windows.Forms.PictureBox();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblCodFoto = new System.Windows.Forms.Label();
            this.lblTotPagina = new System.Windows.Forms.Label();
            this.lblCodUsuario = new System.Windows.Forms.Label();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.gpoModulo = new System.Windows.Forms.GroupBox();
            this.optModulo = new System.Windows.Forms.RadioButton();
            this.optFase = new System.Windows.Forms.RadioButton();
            this.lblCodFase = new System.Windows.Forms.Label();
            this.lblCodModulo = new System.Windows.Forms.Label();
            this.lblSepararPor = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.gpoTipo = new System.Windows.Forms.GroupBox();
            this.optAval = new System.Windows.Forms.RadioButton();
            this.lblTipoCadastro = new System.Windows.Forms.Label();
            this.optAtiv = new System.Windows.Forms.RadioButton();
            this.gpoAplicarEm = new System.Windows.Forms.GroupBox();
            this.optMeia = new System.Windows.Forms.RadioButton();
            this.lblAplicaEm = new System.Windows.Forms.Label();
            this.optGem = new System.Windows.Forms.RadioButton();
            this.optOficial = new System.Windows.Forms.RadioButton();
            this.optCulto = new System.Windows.Forms.RadioButton();
            this.optRjm = new System.Windows.Forms.RadioButton();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.imgTeoria = new System.Windows.Forms.ImageList(this.components);
            this.cboPagina = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtTotalPag = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.gridFotoTeoria = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.txtUsuario = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHoraCadastro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataCadastro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.cboModulo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboNivel = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlTeoria.SuspendLayout();
            this.gpoFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFoto)).BeginInit();
            this.gpoModulo.SuspendLayout();
            this.gpoTipo.SuspendLayout();
            this.gpoAplicarEm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFotoTeoria)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSalvar.Location = new System.Drawing.Point(483, 489);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 25;
            this.btnSalvar.Text = "&Salvar";
            this.tipTeoria.SetToolTip(this.btnSalvar, "Salvar");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(579, 489);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 26;
            this.btnCancelar.Text = "&Cancelar";
            this.tipTeoria.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(9, 489);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 30);
            this.btnImprimir.TabIndex = 27;
            this.btnImprimir.Text = "&Imprimir";
            this.tipTeoria.SetToolTip(this.btnImprimir, "Imprimir");
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(576, 382);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 25);
            this.btnExcluir.TabIndex = 20;
            this.btnExcluir.Text = "E&xcluir";
            this.tipTeoria.SetToolTip(this.btnExcluir, "Excluir");
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(497, 382);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 25);
            this.btnInserir.TabIndex = 19;
            this.btnInserir.Text = "&Inserir";
            this.tipTeoria.SetToolTip(this.btnInserir, "Inserir");
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // btnFotoCancelar
            // 
            this.btnFotoCancelar.Image = global::ccbinst.Properties.Resources.Cancela;
            this.btnFotoCancelar.Location = new System.Drawing.Point(161, 325);
            this.btnFotoCancelar.Name = "btnFotoCancelar";
            this.btnFotoCancelar.Size = new System.Drawing.Size(68, 37);
            this.btnFotoCancelar.TabIndex = 23;
            this.tipTeoria.SetToolTip(this.btnFotoCancelar, "Cancelar Imagem");
            this.btnFotoCancelar.UseVisualStyleBackColor = true;
            this.btnFotoCancelar.Click += new System.EventHandler(this.btnFotoCancelar_Click);
            // 
            // btnFotoSalvar
            // 
            this.btnFotoSalvar.Image = global::ccbinst.Properties.Resources.proximo2;
            this.btnFotoSalvar.Location = new System.Drawing.Point(235, 325);
            this.btnFotoSalvar.Name = "btnFotoSalvar";
            this.btnFotoSalvar.Size = new System.Drawing.Size(68, 37);
            this.btnFotoSalvar.TabIndex = 24;
            this.tipTeoria.SetToolTip(this.btnFotoSalvar, "Inserir Imagem");
            this.btnFotoSalvar.UseVisualStyleBackColor = true;
            this.btnFotoSalvar.Click += new System.EventHandler(this.btnFotoSalvar_Click);
            // 
            // btnTeoria
            // 
            this.btnTeoria.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnTeoria.Image = global::ccbinst.Properties.Resources.CarregarFoto;
            this.btnTeoria.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTeoria.Location = new System.Drawing.Point(161, 283);
            this.btnTeoria.Name = "btnTeoria";
            this.btnTeoria.Size = new System.Drawing.Size(142, 39);
            this.btnTeoria.TabIndex = 22;
            this.btnTeoria.Text = "    Buscar Lição";
            this.btnTeoria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipTeoria.SetToolTip(this.btnTeoria, "Carregar atividade ou avaliação");
            this.btnTeoria.UseVisualStyleBackColor = true;
            this.btnTeoria.Click += new System.EventHandler(this.btnTeoria_Click);
            // 
            // btnVisual
            // 
            this.btnVisual.Location = new System.Drawing.Point(418, 382);
            this.btnVisual.Name = "btnVisual";
            this.btnVisual.Size = new System.Drawing.Size(75, 25);
            this.btnVisual.TabIndex = 18;
            this.btnVisual.Text = "&Visualizar";
            this.tipTeoria.SetToolTip(this.btnVisual, "Visualizar");
            this.btnVisual.UseVisualStyleBackColor = true;
            this.btnVisual.Click += new System.EventHandler(this.btnVisual_Click);
            // 
            // pnlTeoria
            // 
            this.pnlTeoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlTeoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTeoria.Controls.Add(this.btnVisual);
            this.pnlTeoria.Controls.Add(this.btnInserir);
            this.pnlTeoria.Controls.Add(this.btnExcluir);
            this.pnlTeoria.Controls.Add(this.lblUsuario);
            this.pnlTeoria.Controls.Add(this.gpoFoto);
            this.pnlTeoria.Controls.Add(this.txtTotalPag);
            this.pnlTeoria.Controls.Add(this.lblTotPagina);
            this.pnlTeoria.Controls.Add(this.lblCodUsuario);
            this.pnlTeoria.Controls.Add(this.gridFotoTeoria);
            this.pnlTeoria.Controls.Add(this.txtUsuario);
            this.pnlTeoria.Controls.Add(this.txtHoraCadastro);
            this.pnlTeoria.Controls.Add(this.txtDataCadastro);
            this.pnlTeoria.Controls.Add(this.lblCadastro);
            this.pnlTeoria.Controls.Add(this.gpoModulo);
            this.pnlTeoria.Controls.Add(this.cboNivel);
            this.pnlTeoria.Controls.Add(this.lblNivel);
            this.pnlTeoria.Controls.Add(this.gpoTipo);
            this.pnlTeoria.Controls.Add(this.gpoAplicarEm);
            this.pnlTeoria.Controls.Add(this.txtCodigo);
            this.pnlTeoria.Controls.Add(this.lblCodigo);
            this.pnlTeoria.Controls.Add(this.txtDescricao);
            this.pnlTeoria.Controls.Add(this.lblDescricao);
            this.pnlTeoria.Location = new System.Drawing.Point(9, 9);
            this.pnlTeoria.Name = "pnlTeoria";
            this.pnlTeoria.Size = new System.Drawing.Size(660, 474);
            this.pnlTeoria.TabIndex = 0;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblUsuario.Location = new System.Drawing.Point(340, 419);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(88, 13);
            this.lblUsuario.TabIndex = 93;
            this.lblUsuario.Text = "Ultima alteração:";
            // 
            // gpoFoto
            // 
            this.gpoFoto.Controls.Add(this.lblAviso);
            this.gpoFoto.Controls.Add(this.btnFotoCancelar);
            this.gpoFoto.Controls.Add(this.lblContemFoto);
            this.gpoFoto.Controls.Add(this.btnFotoSalvar);
            this.gpoFoto.Controls.Add(this.btnTeoria);
            this.gpoFoto.Controls.Add(this.cboPagina);
            this.gpoFoto.Controls.Add(this.pctFoto);
            this.gpoFoto.Controls.Add(this.lblPagina);
            this.gpoFoto.Controls.Add(this.lblCodFoto);
            this.gpoFoto.Enabled = false;
            this.gpoFoto.Location = new System.Drawing.Point(6, 92);
            this.gpoFoto.Name = "gpoFoto";
            this.gpoFoto.Size = new System.Drawing.Size(314, 372);
            this.gpoFoto.TabIndex = 107;
            this.gpoFoto.TabStop = false;
            this.gpoFoto.Text = "Selecionar Foto";
            // 
            // lblAviso
            // 
            this.lblAviso.AutoSize = true;
            this.lblAviso.Font = new System.Drawing.Font("Tahoma", 6.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblAviso.ForeColor = System.Drawing.Color.Red;
            this.lblAviso.Location = new System.Drawing.Point(53, 101);
            this.lblAviso.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAviso.Name = "lblAviso";
            this.lblAviso.Size = new System.Drawing.Size(205, 22);
            this.lblAviso.TabIndex = 113;
            this.lblAviso.Text = "Visualização indisponível!\r\nImagem não foi salva na Base de Dados!";
            this.lblAviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAviso.Visible = false;
            // 
            // lblContemFoto
            // 
            this.lblContemFoto.Enabled = false;
            this.lblContemFoto.Location = new System.Drawing.Point(78, 316);
            this.lblContemFoto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblContemFoto.Name = "lblContemFoto";
            this.lblContemFoto.Size = new System.Drawing.Size(41, 17);
            this.lblContemFoto.TabIndex = 111;
            this.lblContemFoto.Visible = false;
            // 
            // pctFoto
            // 
            this.pctFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctFoto.Location = new System.Drawing.Point(10, 17);
            this.pctFoto.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.pctFoto.Name = "pctFoto";
            this.pctFoto.Size = new System.Drawing.Size(293, 268);
            this.pctFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFoto.TabIndex = 83;
            this.pctFoto.TabStop = false;
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblPagina.Location = new System.Drawing.Point(7, 296);
            this.lblPagina.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(43, 13);
            this.lblPagina.TabIndex = 103;
            this.lblPagina.Text = "Página:";
            // 
            // lblCodFoto
            // 
            this.lblCodFoto.Enabled = false;
            this.lblCodFoto.Location = new System.Drawing.Point(27, 331);
            this.lblCodFoto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodFoto.Name = "lblCodFoto";
            this.lblCodFoto.Size = new System.Drawing.Size(41, 17);
            this.lblCodFoto.TabIndex = 101;
            this.lblCodFoto.Visible = false;
            // 
            // lblTotPagina
            // 
            this.lblTotPagina.AutoSize = true;
            this.lblTotPagina.Location = new System.Drawing.Point(364, 70);
            this.lblTotPagina.Name = "lblTotPagina";
            this.lblTotPagina.Size = new System.Drawing.Size(75, 13);
            this.lblTotPagina.TabIndex = 104;
            this.lblTotPagina.Text = "Qtde páginas:";
            // 
            // lblCodUsuario
            // 
            this.lblCodUsuario.Enabled = false;
            this.lblCodUsuario.Location = new System.Drawing.Point(337, 416);
            this.lblCodUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuario.Name = "lblCodUsuario";
            this.lblCodUsuario.Size = new System.Drawing.Size(41, 17);
            this.lblCodUsuario.TabIndex = 100;
            this.lblCodUsuario.Visible = false;
            // 
            // lblCadastro
            // 
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.Enabled = false;
            this.lblCadastro.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCadastro.Location = new System.Drawing.Point(340, 444);
            this.lblCadastro.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(81, 13);
            this.lblCadastro.TabIndex = 90;
            this.lblCadastro.Text = "Data Cadastro:";
            // 
            // gpoModulo
            // 
            this.gpoModulo.Controls.Add(this.cboModulo);
            this.gpoModulo.Controls.Add(this.optModulo);
            this.gpoModulo.Controls.Add(this.optFase);
            this.gpoModulo.Controls.Add(this.lblCodFase);
            this.gpoModulo.Controls.Add(this.lblCodModulo);
            this.gpoModulo.Controls.Add(this.lblSepararPor);
            this.gpoModulo.Location = new System.Drawing.Point(511, 3);
            this.gpoModulo.Name = "gpoModulo";
            this.gpoModulo.Size = new System.Drawing.Size(140, 84);
            this.gpoModulo.TabIndex = 11;
            this.gpoModulo.TabStop = false;
            this.gpoModulo.Text = "Referência";
            // 
            // optModulo
            // 
            this.optModulo.AutoSize = true;
            this.optModulo.Location = new System.Drawing.Point(15, 21);
            this.optModulo.Name = "optModulo";
            this.optModulo.Size = new System.Drawing.Size(59, 17);
            this.optModulo.TabIndex = 12;
            this.optModulo.Text = "Módulo";
            this.optModulo.UseVisualStyleBackColor = true;
            this.optModulo.CheckedChanged += new System.EventHandler(this.optModulo_CheckedChanged);
            // 
            // optFase
            // 
            this.optFase.AutoSize = true;
            this.optFase.Location = new System.Drawing.Point(79, 21);
            this.optFase.Name = "optFase";
            this.optFase.Size = new System.Drawing.Size(48, 17);
            this.optFase.TabIndex = 13;
            this.optFase.Text = "Fase";
            this.optFase.UseVisualStyleBackColor = true;
            this.optFase.CheckedChanged += new System.EventHandler(this.optFase_CheckedChanged);
            // 
            // lblCodFase
            // 
            this.lblCodFase.Enabled = false;
            this.lblCodFase.Location = new System.Drawing.Point(70, 55);
            this.lblCodFase.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodFase.Name = "lblCodFase";
            this.lblCodFase.Size = new System.Drawing.Size(41, 17);
            this.lblCodFase.TabIndex = 99;
            this.lblCodFase.Visible = false;
            // 
            // lblCodModulo
            // 
            this.lblCodModulo.Enabled = false;
            this.lblCodModulo.Location = new System.Drawing.Point(75, 17);
            this.lblCodModulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodModulo.Name = "lblCodModulo";
            this.lblCodModulo.Size = new System.Drawing.Size(41, 17);
            this.lblCodModulo.TabIndex = 98;
            this.lblCodModulo.Visible = false;
            // 
            // lblSepararPor
            // 
            this.lblSepararPor.Enabled = false;
            this.lblSepararPor.Location = new System.Drawing.Point(22, 17);
            this.lblSepararPor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSepararPor.Name = "lblSepararPor";
            this.lblSepararPor.Size = new System.Drawing.Size(41, 17);
            this.lblSepararPor.TabIndex = 97;
            this.lblSepararPor.Visible = false;
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(12, 43);
            this.lblNivel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(34, 13);
            this.lblNivel.TabIndex = 81;
            this.lblNivel.Text = "Nível:";
            // 
            // gpoTipo
            // 
            this.gpoTipo.Controls.Add(this.optAval);
            this.gpoTipo.Controls.Add(this.lblTipoCadastro);
            this.gpoTipo.Controls.Add(this.optAtiv);
            this.gpoTipo.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gpoTipo.Location = new System.Drawing.Point(175, 3);
            this.gpoTipo.Name = "gpoTipo";
            this.gpoTipo.Size = new System.Drawing.Size(80, 59);
            this.gpoTipo.TabIndex = 3;
            this.gpoTipo.TabStop = false;
            this.gpoTipo.Text = "Tipo";
            // 
            // optAval
            // 
            this.optAval.AutoSize = true;
            this.optAval.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAval.Location = new System.Drawing.Point(6, 35);
            this.optAval.Name = "optAval";
            this.optAval.Size = new System.Drawing.Size(71, 17);
            this.optAval.TabIndex = 5;
            this.optAval.Text = "Avaliação";
            this.optAval.UseVisualStyleBackColor = true;
            this.optAval.CheckedChanged += new System.EventHandler(this.optAval_CheckedChanged);
            // 
            // lblTipoCadastro
            // 
            this.lblTipoCadastro.Enabled = false;
            this.lblTipoCadastro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTipoCadastro.Location = new System.Drawing.Point(37, 28);
            this.lblTipoCadastro.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipoCadastro.Name = "lblTipoCadastro";
            this.lblTipoCadastro.Size = new System.Drawing.Size(41, 17);
            this.lblTipoCadastro.TabIndex = 95;
            this.lblTipoCadastro.Visible = false;
            // 
            // optAtiv
            // 
            this.optAtiv.AutoSize = true;
            this.optAtiv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAtiv.Location = new System.Drawing.Point(5, 15);
            this.optAtiv.Name = "optAtiv";
            this.optAtiv.Size = new System.Drawing.Size(70, 17);
            this.optAtiv.TabIndex = 4;
            this.optAtiv.Text = "Atividade";
            this.optAtiv.UseVisualStyleBackColor = true;
            this.optAtiv.CheckedChanged += new System.EventHandler(this.optAtiv_CheckedChanged);
            // 
            // gpoAplicarEm
            // 
            this.gpoAplicarEm.Controls.Add(this.optMeia);
            this.gpoAplicarEm.Controls.Add(this.lblAplicaEm);
            this.gpoAplicarEm.Controls.Add(this.optGem);
            this.gpoAplicarEm.Controls.Add(this.optOficial);
            this.gpoAplicarEm.Controls.Add(this.optCulto);
            this.gpoAplicarEm.Controls.Add(this.optRjm);
            this.gpoAplicarEm.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.gpoAplicarEm.Location = new System.Drawing.Point(261, 3);
            this.gpoAplicarEm.Name = "gpoAplicarEm";
            this.gpoAplicarEm.Size = new System.Drawing.Size(243, 59);
            this.gpoAplicarEm.TabIndex = 6;
            this.gpoAplicarEm.TabStop = false;
            this.gpoAplicarEm.Text = "Aplicação";
            // 
            // optMeia
            // 
            this.optMeia.AutoSize = true;
            this.optMeia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optMeia.Location = new System.Drawing.Point(53, 15);
            this.optMeia.Name = "optMeia";
            this.optMeia.Size = new System.Drawing.Size(73, 17);
            this.optMeia.TabIndex = 97;
            this.optMeia.Text = "Meia Hora";
            this.optMeia.UseVisualStyleBackColor = true;
            this.optMeia.CheckedChanged += new System.EventHandler(this.optMeia_CheckedChanged);
            // 
            // lblAplicaEm
            // 
            this.lblAplicaEm.Enabled = false;
            this.lblAplicaEm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAplicaEm.Location = new System.Drawing.Point(4, 36);
            this.lblAplicaEm.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAplicaEm.Name = "lblAplicaEm";
            this.lblAplicaEm.Size = new System.Drawing.Size(41, 17);
            this.lblAplicaEm.TabIndex = 96;
            this.lblAplicaEm.Visible = false;
            // 
            // optGem
            // 
            this.optGem.AutoSize = true;
            this.optGem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optGem.Location = new System.Drawing.Point(5, 15);
            this.optGem.Name = "optGem";
            this.optGem.Size = new System.Drawing.Size(46, 17);
            this.optGem.TabIndex = 7;
            this.optGem.Text = "GEM";
            this.optGem.UseVisualStyleBackColor = true;
            this.optGem.CheckedChanged += new System.EventHandler(this.optGem_CheckedChanged);
            // 
            // optOficial
            // 
            this.optOficial.AutoSize = true;
            this.optOficial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optOficial.Location = new System.Drawing.Point(138, 35);
            this.optOficial.Name = "optOficial";
            this.optOficial.Size = new System.Drawing.Size(84, 17);
            this.optOficial.TabIndex = 10;
            this.optOficial.Text = "Oficialização";
            this.optOficial.UseVisualStyleBackColor = true;
            this.optOficial.CheckedChanged += new System.EventHandler(this.optOficial_CheckedChanged);
            // 
            // optCulto
            // 
            this.optCulto.AutoSize = true;
            this.optCulto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optCulto.Location = new System.Drawing.Point(53, 35);
            this.optCulto.Name = "optCulto";
            this.optCulto.Size = new System.Drawing.Size(82, 17);
            this.optCulto.TabIndex = 9;
            this.optCulto.Text = "Culto Oficial";
            this.optCulto.UseVisualStyleBackColor = true;
            this.optCulto.CheckedChanged += new System.EventHandler(this.optCulto_CheckedChanged);
            // 
            // optRjm
            // 
            this.optRjm.AutoSize = true;
            this.optRjm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optRjm.Location = new System.Drawing.Point(138, 15);
            this.optRjm.Name = "optRjm";
            this.optRjm.Size = new System.Drawing.Size(101, 17);
            this.optRjm.TabIndex = 8;
            this.optRjm.Text = "Reunião Jovens";
            this.optRjm.UseVisualStyleBackColor = true;
            this.optRjm.CheckedChanged += new System.EventHandler(this.optRjm_CheckedChanged);
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(12, 17);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 73;
            this.lblCodigo.Text = "Código:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(12, 70);
            this.lblDescricao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 71;
            this.lblDescricao.Text = "Descrição:";
            // 
            // imgTeoria
            // 
            this.imgTeoria.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgTeoria.ImageSize = new System.Drawing.Size(16, 16);
            this.imgTeoria.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cboPagina
            // 
            this.cboPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPagina.FormattingEnabled = true;
            this.cboPagina.Location = new System.Drawing.Point(59, 293);
            this.cboPagina.Name = "cboPagina";
            this.cboPagina.Size = new System.Drawing.Size(87, 21);
            this.cboPagina.TabIndex = 21;
            this.tipTeoria.SetToolTip(this.cboPagina, "Selecione a página correspondente a imagem");
            // 
            // txtTotalPag
            // 
            this.txtTotalPag.BackColor = System.Drawing.Color.White;
            this.txtTotalPag.Location = new System.Drawing.Point(439, 66);
            this.txtTotalPag.Name = "txtTotalPag";
            this.txtTotalPag.Size = new System.Drawing.Size(53, 21);
            this.txtTotalPag.TabIndex = 16;
            this.txtTotalPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalPag.ThousandsSeparator = true;
            this.txtTotalPag.ValueChanged += new System.EventHandler(this.txtTotalPag_ValueChanged);
            // 
            // gridFotoTeoria
            // 
            this.gridFotoTeoria.AllowUserToAddRows = false;
            this.gridFotoTeoria.AllowUserToDeleteRows = false;
            this.gridFotoTeoria.AllowUserToResizeRows = false;
            this.gridFotoTeoria.BackgroundColor = System.Drawing.Color.White;
            this.gridFotoTeoria.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridFotoTeoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridFotoTeoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridFotoTeoria.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridFotoTeoria.DisabledCell = null;
            this.gridFotoTeoria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridFotoTeoria.EnableHeadersVisualStyles = false;
            this.gridFotoTeoria.Location = new System.Drawing.Point(345, 100);
            this.gridFotoTeoria.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridFotoTeoria.MultiSelect = false;
            this.gridFotoTeoria.Name = "gridFotoTeoria";
            this.gridFotoTeoria.ReadOnly = true;
            this.gridFotoTeoria.RowHeadersVisible = false;
            this.gridFotoTeoria.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridFotoTeoria.RowTemplate.Height = 18;
            this.gridFotoTeoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridFotoTeoria.Size = new System.Drawing.Size(306, 277);
            this.gridFotoTeoria.TabIndex = 17;
            this.gridFotoTeoria.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridFotoTeoria_RowStateChanged);
            this.gridFotoTeoria.SelectionChanged += new System.EventHandler(this.gridFotoTeoria_SelectionChanged);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtUsuario.Location = new System.Drawing.Point(429, 415);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(222, 21);
            this.txtUsuario.TabIndex = 92;
            this.txtUsuario.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtHoraCadastro
            // 
            this.txtHoraCadastro.BackColor = System.Drawing.Color.White;
            this.txtHoraCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraCadastro.Enabled = false;
            this.txtHoraCadastro.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraCadastro.Location = new System.Drawing.Point(531, 442);
            this.txtHoraCadastro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraCadastro.Name = "txtHoraCadastro";
            this.txtHoraCadastro.Size = new System.Drawing.Size(50, 21);
            this.txtHoraCadastro.TabIndex = 91;
            this.txtHoraCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraCadastro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtDataCadastro
            // 
            this.txtDataCadastro.BackColor = System.Drawing.Color.White;
            this.txtDataCadastro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCadastro.Enabled = false;
            this.txtDataCadastro.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataCadastro.Location = new System.Drawing.Point(429, 442);
            this.txtDataCadastro.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataCadastro.Name = "txtDataCadastro";
            this.txtDataCadastro.Size = new System.Drawing.Size(98, 21);
            this.txtDataCadastro.TabIndex = 89;
            this.txtDataCadastro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataCadastro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(10, 51);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(120, 21);
            this.cboModulo.TabIndex = 14;
            this.tipTeoria.SetToolTip(this.cboModulo, "Módulo");
            this.cboModulo.SelectionChangeCommitted += new System.EventHandler(this.cboModulo_SelectionChangeCommitted);
            this.cboModulo.SelectedValueChanged += new System.EventHandler(this.cboModulo_SelectedValueChanged);
            // 
            // cboNivel
            // 
            this.cboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNivel.FormattingEnabled = true;
            this.cboNivel.Items.AddRange(new object[] {
            "Crianças",
            "Adultos (Básico)",
            "Adultos"});
            this.cboNivel.Location = new System.Drawing.Point(69, 39);
            this.cboNivel.Name = "cboNivel";
            this.cboNivel.Size = new System.Drawing.Size(100, 21);
            this.cboNivel.TabIndex = 2;
            this.tipTeoria.SetToolTip(this.cboNivel, "Nível de dificuldade");
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(69, 13);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(51, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipTeoria.SetToolTip(this.txtCodigo, "Código da avaliação");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(69, 66);
            this.txtDescricao.MaxLength = 150;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(285, 21);
            this.txtDescricao.TabIndex = 15;
            this.tipTeoria.SetToolTip(this.txtDescricao, "Descrição da avaliação");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // frmTeoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(676, 526);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.pnlTeoria);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTeoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avaliação de teoria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTeoria_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTeoria_FormClosed);
            this.Load += new System.EventHandler(this.frmTeoria_Load);
            this.pnlTeoria.ResumeLayout(false);
            this.pnlTeoria.PerformLayout();
            this.gpoFoto.ResumeLayout(false);
            this.gpoFoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFoto)).EndInit();
            this.gpoModulo.ResumeLayout(false);
            this.gpoModulo.PerformLayout();
            this.gpoTipo.ResumeLayout(false);
            this.gpoTipo.PerformLayout();
            this.gpoAplicarEm.ResumeLayout(false);
            this.gpoAplicarEm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridFotoTeoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipTeoria;
        private System.Windows.Forms.Panel pnlTeoria;
        private System.Windows.Forms.Button btnTeoria;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.GroupBox gpoAplicarEm;
        private System.Windows.Forms.RadioButton optOficial;
        private System.Windows.Forms.RadioButton optCulto;
        private System.Windows.Forms.RadioButton optRjm;
        private System.Windows.Forms.GroupBox gpoTipo;
        private System.Windows.Forms.RadioButton optGem;
        private System.Windows.Forms.RadioButton optAval;
        private System.Windows.Forms.RadioButton optAtiv;
        private BLL.validacoes.Controles.ComboBoxPersonal cboModulo;
        private System.Windows.Forms.RadioButton optModulo;
        private System.Windows.Forms.RadioButton optFase;
        private BLL.validacoes.Controles.ComboBoxPersonal cboNivel;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.PictureBox pctFoto;
        private System.Windows.Forms.GroupBox gpoModulo;
        private BLL.validacoes.Controles.TextBoxPersonal txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraCadastro;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataCadastro;
        private System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.Label lblTipoCadastro;
        private System.Windows.Forms.Label lblAplicaEm;
        private System.Windows.Forms.Label lblSepararPor;
        private BLL.validacoes.Controles.DataGridViewPersonal gridFotoTeoria;
        private System.Windows.Forms.Label lblCodFase;
        private System.Windows.Forms.Label lblCodModulo;
        private System.Windows.Forms.Label lblCodUsuario;
        private System.Windows.Forms.Label lblCodFoto;
        private System.Windows.Forms.Label lblPagina;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtTotalPag;
        private System.Windows.Forms.Label lblTotPagina;
        private BLL.validacoes.Controles.ComboBoxPersonal cboPagina;
        private System.Windows.Forms.GroupBox gpoFoto;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnFotoSalvar;
        private System.Windows.Forms.Label lblContemFoto;
        private System.Windows.Forms.Button btnFotoCancelar;
        private System.Windows.Forms.Button btnVisual;
        private System.Windows.Forms.Label lblAviso;
        private System.Windows.Forms.ImageList imgTeoria;
        private System.Windows.Forms.RadioButton optMeia;
    }
}