namespace ccbinst
{
    partial class frmInst
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInst));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabInst = new System.Windows.Forms.TabControl();
            this.tabGeral = new System.Windows.Forms.TabPage();
            this.gpoHinario = new System.Windows.Forms.GroupBox();
            this.gridHinario = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.txtOrdem = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.lblOrdem = new System.Windows.Forms.Label();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.gpoSituacao = new System.Windows.Forms.GroupBox();
            this.optProibido = new System.Windows.Forms.RadioButton();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.optNaoRecomendado = new System.Windows.Forms.RadioButton();
            this.optPermitido = new System.Windows.Forms.RadioButton();
            this.txtObs = new BLL.validacoes.Controles.TextBoxPersonal();
            this.cboFamilia = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblObs = new System.Windows.Forms.Label();
            this.lblFamilia = new System.Windows.Forms.Label();
            this.gpoTonal = new System.Windows.Forms.GroupBox();
            this.gridTonalidade = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.btnFoto = new System.Windows.Forms.Button();
            this.pctFoto = new System.Windows.Forms.PictureBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.tabVoz = new System.Windows.Forms.TabPage();
            this.gpoAltern = new System.Windows.Forms.GroupBox();
            this.gridAlterna = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.gpoPrinc = new System.Windows.Forms.GroupBox();
            this.gridPrincipal = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.tabTessitura = new System.Windows.Forms.TabPage();
            this.gpoAfina = new System.Windows.Forms.GroupBox();
            this.lblNotaEfeito = new System.Windows.Forms.Label();
            this.cboPosEfeito = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboNotaEfeito = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblNotaAfina = new System.Windows.Forms.Label();
            this.cboPosAfina = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboNotaAfina = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.gpoAgudo = new System.Windows.Forms.GroupBox();
            this.lblAguda = new System.Windows.Forms.Label();
            this.pctAgudo = new System.Windows.Forms.PictureBox();
            this.tckAgudo = new System.Windows.Forms.TrackBar();
            this.gpoGrave = new System.Windows.Forms.GroupBox();
            this.lblGrave = new System.Windows.Forms.Label();
            this.pctGrave = new System.Windows.Forms.PictureBox();
            this.tckGrave = new System.Windows.Forms.TrackBar();
            this.tipInst = new System.Windows.Forms.ToolTip(this.components);
            this.lblCodFoto = new System.Windows.Forms.Label();
            this.tabInst.SuspendLayout();
            this.tabGeral.SuspendLayout();
            this.gpoHinario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHinario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdem)).BeginInit();
            this.gpoSituacao.SuspendLayout();
            this.gpoTonal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTonalidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFoto)).BeginInit();
            this.tabVoz.SuspendLayout();
            this.gpoAltern.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlterna)).BeginInit();
            this.gpoPrinc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrincipal)).BeginInit();
            this.tabTessitura.SuspendLayout();
            this.gpoAfina.SuspendLayout();
            this.gpoAgudo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctAgudo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckAgudo)).BeginInit();
            this.gpoGrave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctGrave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckGrave)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(418, 396);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 32);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(511, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 32);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabInst
            // 
            this.tabInst.Controls.Add(this.tabGeral);
            this.tabInst.Controls.Add(this.tabVoz);
            this.tabInst.Controls.Add(this.tabTessitura);
            this.tabInst.Location = new System.Drawing.Point(7, 7);
            this.tabInst.Name = "tabInst";
            this.tabInst.SelectedIndex = 0;
            this.tabInst.Size = new System.Drawing.Size(594, 383);
            this.tabInst.TabIndex = 0;
            this.tabInst.SelectedIndexChanged += new System.EventHandler(this.tabInstr_SelectedIndexChanged);
            // 
            // tabGeral
            // 
            this.tabGeral.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabGeral.Controls.Add(this.gpoHinario);
            this.tabGeral.Controls.Add(this.txtOrdem);
            this.tabGeral.Controls.Add(this.lblOrdem);
            this.tabGeral.Controls.Add(this.txtCodigo);
            this.tabGeral.Controls.Add(this.lblCodigo);
            this.tabGeral.Controls.Add(this.gpoSituacao);
            this.tabGeral.Controls.Add(this.txtObs);
            this.tabGeral.Controls.Add(this.cboFamilia);
            this.tabGeral.Controls.Add(this.txtDescricao);
            this.tabGeral.Controls.Add(this.lblObs);
            this.tabGeral.Controls.Add(this.lblFamilia);
            this.tabGeral.Controls.Add(this.gpoTonal);
            this.tabGeral.Controls.Add(this.btnFoto);
            this.tabGeral.Controls.Add(this.pctFoto);
            this.tabGeral.Controls.Add(this.lblDescricao);
            this.tabGeral.Location = new System.Drawing.Point(4, 22);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeral.Size = new System.Drawing.Size(586, 357);
            this.tabGeral.TabIndex = 0;
            this.tabGeral.Text = "Geral";
            // 
            // gpoHinario
            // 
            this.gpoHinario.Controls.Add(this.gridHinario);
            this.gpoHinario.Location = new System.Drawing.Point(9, 188);
            this.gpoHinario.Name = "gpoHinario";
            this.gpoHinario.Size = new System.Drawing.Size(300, 100);
            this.gpoHinario.TabIndex = 12;
            this.gpoHinario.TabStop = false;
            this.gpoHinario.Text = "Hinário";
            // 
            // gridHinario
            // 
            this.gridHinario.AllowUserToAddRows = false;
            this.gridHinario.AllowUserToDeleteRows = false;
            this.gridHinario.AllowUserToResizeRows = false;
            this.gridHinario.BackgroundColor = System.Drawing.Color.White;
            this.gridHinario.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridHinario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridHinario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridHinario.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridHinario.DisabledCell = null;
            this.gridHinario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridHinario.EnableHeadersVisualStyles = false;
            this.gridHinario.Location = new System.Drawing.Point(7, 14);
            this.gridHinario.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridHinario.MultiSelect = false;
            this.gridHinario.Name = "gridHinario";
            this.gridHinario.ReadOnly = true;
            this.gridHinario.RowHeadersVisible = false;
            this.gridHinario.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridHinario.RowTemplate.Height = 18;
            this.gridHinario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridHinario.Size = new System.Drawing.Size(285, 78);
            this.gridHinario.TabIndex = 11;
            this.gridHinario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridHinario_CellClick);
            // 
            // txtOrdem
            // 
            this.txtOrdem.BackColor = System.Drawing.Color.White;
            this.txtOrdem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrdem.Location = new System.Drawing.Point(211, 9);
            this.txtOrdem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.Size = new System.Drawing.Size(51, 21);
            this.txtOrdem.TabIndex = 2;
            this.txtOrdem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtOrdem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrdem.ValueChanged += new System.EventHandler(this.txtOrdem_ValueChanged);
            // 
            // lblOrdem
            // 
            this.lblOrdem.AutoSize = true;
            this.lblOrdem.Location = new System.Drawing.Point(161, 13);
            this.lblOrdem.Name = "lblOrdem";
            this.lblOrdem.Size = new System.Drawing.Size(43, 13);
            this.lblOrdem.TabIndex = 16;
            this.lblOrdem.Text = "Ordem:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(68, 9);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(56, 21);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipInst.SetToolTip(this.txtCodigo, "Código");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(6, 13);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // gpoSituacao
            // 
            this.gpoSituacao.Controls.Add(this.optProibido);
            this.gpoSituacao.Controls.Add(this.lblSituacao);
            this.gpoSituacao.Controls.Add(this.optNaoRecomendado);
            this.gpoSituacao.Controls.Add(this.optPermitido);
            this.gpoSituacao.Location = new System.Drawing.Point(323, 10);
            this.gpoSituacao.Name = "gpoSituacao";
            this.gpoSituacao.Size = new System.Drawing.Size(249, 47);
            this.gpoSituacao.TabIndex = 6;
            this.gpoSituacao.TabStop = false;
            this.gpoSituacao.Text = "Situação";
            // 
            // optProibido
            // 
            this.optProibido.AutoSize = true;
            this.optProibido.Location = new System.Drawing.Point(184, 17);
            this.optProibido.Name = "optProibido";
            this.optProibido.Size = new System.Drawing.Size(63, 17);
            this.optProibido.TabIndex = 9;
            this.optProibido.TabStop = true;
            this.optProibido.Text = "Proibido";
            this.optProibido.UseVisualStyleBackColor = true;
            this.optProibido.CheckedChanged += new System.EventHandler(this.optProibido_CheckedChanged);
            // 
            // lblSituacao
            // 
            this.lblSituacao.Location = new System.Drawing.Point(197, 26);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(42, 14);
            this.lblSituacao.TabIndex = 16;
            // 
            // optNaoRecomendado
            // 
            this.optNaoRecomendado.AutoSize = true;
            this.optNaoRecomendado.Location = new System.Drawing.Point(74, 17);
            this.optNaoRecomendado.Name = "optNaoRecomendado";
            this.optNaoRecomendado.Size = new System.Drawing.Size(112, 17);
            this.optNaoRecomendado.TabIndex = 8;
            this.optNaoRecomendado.TabStop = true;
            this.optNaoRecomendado.Text = "Não recomendado";
            this.optNaoRecomendado.UseVisualStyleBackColor = true;
            this.optNaoRecomendado.CheckedChanged += new System.EventHandler(this.optNaoRecomendado_CheckedChanged);
            // 
            // optPermitido
            // 
            this.optPermitido.AutoSize = true;
            this.optPermitido.Location = new System.Drawing.Point(8, 17);
            this.optPermitido.Name = "optPermitido";
            this.optPermitido.Size = new System.Drawing.Size(69, 17);
            this.optPermitido.TabIndex = 7;
            this.optPermitido.Text = "Permitido";
            this.optPermitido.UseVisualStyleBackColor = true;
            this.optPermitido.CheckedChanged += new System.EventHandler(this.optPermitido_CheckedChanged);
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.White;
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.Location = new System.Drawing.Point(9, 308);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(300, 37);
            this.txtObs.TabIndex = 17;
            this.tipInst.SetToolTip(this.txtObs, "Descrição do instrumento");
            this.txtObs.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // cboFamilia
            // 
            this.cboFamilia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFamilia.FormattingEnabled = true;
            this.cboFamilia.Location = new System.Drawing.Point(68, 61);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(104, 21);
            this.cboFamilia.TabIndex = 4;
            this.tipInst.SetToolTip(this.cboFamilia, "Família do instrumento");
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(68, 35);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(241, 21);
            this.txtDescricao.TabIndex = 3;
            this.tipInst.SetToolTip(this.txtDescricao, "Descrição do instrumento");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDescricao.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescricao_Validating);
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(6, 292);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(146, 13);
            this.lblObs.TabIndex = 10;
            this.lblObs.Text = "Observações e Comentários:";
            // 
            // lblFamilia
            // 
            this.lblFamilia.AutoSize = true;
            this.lblFamilia.Location = new System.Drawing.Point(6, 65);
            this.lblFamilia.Name = "lblFamilia";
            this.lblFamilia.Size = new System.Drawing.Size(43, 13);
            this.lblFamilia.TabIndex = 8;
            this.lblFamilia.Text = "Família:";
            // 
            // gpoTonal
            // 
            this.gpoTonal.Controls.Add(this.gridTonalidade);
            this.gpoTonal.Location = new System.Drawing.Point(9, 85);
            this.gpoTonal.Name = "gpoTonal";
            this.gpoTonal.Size = new System.Drawing.Size(300, 101);
            this.gpoTonal.TabIndex = 10;
            this.gpoTonal.TabStop = false;
            this.gpoTonal.Text = "Tonalidade";
            // 
            // gridTonalidade
            // 
            this.gridTonalidade.AllowUserToAddRows = false;
            this.gridTonalidade.AllowUserToDeleteRows = false;
            this.gridTonalidade.AllowUserToResizeRows = false;
            this.gridTonalidade.BackgroundColor = System.Drawing.Color.White;
            this.gridTonalidade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTonalidade.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTonalidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTonalidade.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridTonalidade.DisabledCell = null;
            this.gridTonalidade.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridTonalidade.EnableHeadersVisualStyles = false;
            this.gridTonalidade.Location = new System.Drawing.Point(7, 14);
            this.gridTonalidade.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridTonalidade.MultiSelect = false;
            this.gridTonalidade.Name = "gridTonalidade";
            this.gridTonalidade.ReadOnly = true;
            this.gridTonalidade.RowHeadersVisible = false;
            this.gridTonalidade.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTonalidade.RowTemplate.Height = 18;
            this.gridTonalidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTonalidade.Size = new System.Drawing.Size(285, 78);
            this.gridTonalidade.TabIndex = 11;
            this.gridTonalidade.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTonalidade_CellClick);
            // 
            // btnFoto
            // 
            this.btnFoto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnFoto.Image = global::ccbinst.Properties.Resources.CarregarFoto;
            this.btnFoto.Location = new System.Drawing.Point(322, 305);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(250, 42);
            this.btnFoto.TabIndex = 18;
            this.btnFoto.Text = "   Carregar foto";
            this.btnFoto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // pctFoto
            // 
            this.pctFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pctFoto.Location = new System.Drawing.Point(322, 61);
            this.pctFoto.Name = "pctFoto";
            this.pctFoto.Size = new System.Drawing.Size(250, 245);
            this.pctFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFoto.TabIndex = 4;
            this.pctFoto.TabStop = false;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(6, 39);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 2;
            this.lblDescricao.Text = "Descrição:";
            // 
            // tabVoz
            // 
            this.tabVoz.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabVoz.Controls.Add(this.gpoAltern);
            this.tabVoz.Controls.Add(this.gpoPrinc);
            this.tabVoz.Location = new System.Drawing.Point(4, 22);
            this.tabVoz.Name = "tabVoz";
            this.tabVoz.Padding = new System.Windows.Forms.Padding(3);
            this.tabVoz.Size = new System.Drawing.Size(586, 357);
            this.tabVoz.TabIndex = 2;
            this.tabVoz.Text = "Definição das vozes";
            // 
            // gpoAltern
            // 
            this.gpoAltern.Controls.Add(this.gridAlterna);
            this.gpoAltern.Location = new System.Drawing.Point(10, 187);
            this.gpoAltern.Name = "gpoAltern";
            this.gpoAltern.Size = new System.Drawing.Size(564, 155);
            this.gpoAltern.TabIndex = 1;
            this.gpoAltern.TabStop = false;
            this.gpoAltern.Text = "Voz alternativa";
            // 
            // gridAlterna
            // 
            this.gridAlterna.AllowUserToAddRows = false;
            this.gridAlterna.AllowUserToDeleteRows = false;
            this.gridAlterna.AllowUserToResizeRows = false;
            this.gridAlterna.BackgroundColor = System.Drawing.Color.White;
            this.gridAlterna.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridAlterna.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridAlterna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridAlterna.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridAlterna.DisabledCell = null;
            this.gridAlterna.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridAlterna.EnableHeadersVisualStyles = false;
            this.gridAlterna.Location = new System.Drawing.Point(9, 23);
            this.gridAlterna.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridAlterna.MultiSelect = false;
            this.gridAlterna.Name = "gridAlterna";
            this.gridAlterna.ReadOnly = true;
            this.gridAlterna.RowHeadersVisible = false;
            this.gridAlterna.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridAlterna.RowTemplate.Height = 18;
            this.gridAlterna.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridAlterna.Size = new System.Drawing.Size(546, 115);
            this.gridAlterna.TabIndex = 1;
            this.gridAlterna.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAlterna_CellContentClick);
            // 
            // gpoPrinc
            // 
            this.gpoPrinc.Controls.Add(this.gridPrincipal);
            this.gpoPrinc.Location = new System.Drawing.Point(10, 13);
            this.gpoPrinc.Name = "gpoPrinc";
            this.gpoPrinc.Size = new System.Drawing.Size(564, 155);
            this.gpoPrinc.TabIndex = 0;
            this.gpoPrinc.TabStop = false;
            this.gpoPrinc.Text = "Voz principal";
            // 
            // gridPrincipal
            // 
            this.gridPrincipal.AllowUserToAddRows = false;
            this.gridPrincipal.AllowUserToDeleteRows = false;
            this.gridPrincipal.AllowUserToResizeRows = false;
            this.gridPrincipal.BackgroundColor = System.Drawing.Color.White;
            this.gridPrincipal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPrincipal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.NullValue = null;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPrincipal.DefaultCellStyle = dataGridViewCellStyle8;
            this.gridPrincipal.DisabledCell = null;
            this.gridPrincipal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPrincipal.EnableHeadersVisualStyles = false;
            this.gridPrincipal.Location = new System.Drawing.Point(9, 21);
            this.gridPrincipal.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridPrincipal.MultiSelect = false;
            this.gridPrincipal.Name = "gridPrincipal";
            this.gridPrincipal.ReadOnly = true;
            this.gridPrincipal.RowHeadersVisible = false;
            this.gridPrincipal.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPrincipal.RowTemplate.Height = 18;
            this.gridPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPrincipal.Size = new System.Drawing.Size(546, 115);
            this.gridPrincipal.TabIndex = 0;
            this.gridPrincipal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPrincipal_CellContentClick);
            // 
            // tabTessitura
            // 
            this.tabTessitura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabTessitura.Controls.Add(this.gpoAfina);
            this.tabTessitura.Controls.Add(this.gpoAgudo);
            this.tabTessitura.Controls.Add(this.gpoGrave);
            this.tabTessitura.Location = new System.Drawing.Point(4, 22);
            this.tabTessitura.Name = "tabTessitura";
            this.tabTessitura.Padding = new System.Windows.Forms.Padding(3);
            this.tabTessitura.Size = new System.Drawing.Size(586, 357);
            this.tabTessitura.TabIndex = 1;
            this.tabTessitura.Text = "Adicionais";
            // 
            // gpoAfina
            // 
            this.gpoAfina.Controls.Add(this.lblNotaEfeito);
            this.gpoAfina.Controls.Add(this.cboPosEfeito);
            this.gpoAfina.Controls.Add(this.cboNotaEfeito);
            this.gpoAfina.Controls.Add(this.lblNotaAfina);
            this.gpoAfina.Controls.Add(this.cboPosAfina);
            this.gpoAfina.Controls.Add(this.cboNotaAfina);
            this.gpoAfina.Location = new System.Drawing.Point(11, 12);
            this.gpoAfina.Name = "gpoAfina";
            this.gpoAfina.Size = new System.Drawing.Size(300, 77);
            this.gpoAfina.TabIndex = 13;
            this.gpoAfina.TabStop = false;
            this.gpoAfina.Text = "Afinação";
            // 
            // lblNotaEfeito
            // 
            this.lblNotaEfeito.AutoSize = true;
            this.lblNotaEfeito.Location = new System.Drawing.Point(10, 48);
            this.lblNotaEfeito.Name = "lblNotaEfeito";
            this.lblNotaEfeito.Size = new System.Drawing.Size(132, 13);
            this.lblNotaEfeito.TabIndex = 36;
            this.lblNotaEfeito.Text = "Nota de afinação (efeito):";
            // 
            // cboPosEfeito
            // 
            this.cboPosEfeito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosEfeito.FormattingEnabled = true;
            this.cboPosEfeito.Items.AddRange(new object[] {
            "(-1)",
            "( 1)",
            "( 2)",
            "( 3)",
            "( 4)",
            "( 5)",
            "( 6)"});
            this.cboPosEfeito.Location = new System.Drawing.Point(235, 45);
            this.cboPosEfeito.Name = "cboPosEfeito";
            this.cboPosEfeito.Size = new System.Drawing.Size(47, 21);
            this.cboPosEfeito.TabIndex = 16;
            // 
            // cboNotaEfeito
            // 
            this.cboNotaEfeito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotaEfeito.FormattingEnabled = true;
            this.cboNotaEfeito.Items.AddRange(new object[] {
            "Dó",
            "Ré b",
            "Ré",
            "Mi b",
            "Mi",
            "Fá",
            "Sol b",
            "Sol",
            "Lá b",
            "Lá",
            "Si b",
            "Si"});
            this.cboNotaEfeito.Location = new System.Drawing.Point(150, 45);
            this.cboNotaEfeito.Name = "cboNotaEfeito";
            this.cboNotaEfeito.Size = new System.Drawing.Size(79, 21);
            this.cboNotaEfeito.TabIndex = 15;
            this.tipInst.SetToolTip(this.cboNotaEfeito, "Selecione a nota de efeito referente a nota de afinação");
            // 
            // lblNotaAfina
            // 
            this.lblNotaAfina.AutoSize = true;
            this.lblNotaAfina.Location = new System.Drawing.Point(10, 21);
            this.lblNotaAfina.Name = "lblNotaAfina";
            this.lblNotaAfina.Size = new System.Drawing.Size(134, 13);
            this.lblNotaAfina.TabIndex = 35;
            this.lblNotaAfina.Text = "Nota de afinação (escala):";
            // 
            // cboPosAfina
            // 
            this.cboPosAfina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPosAfina.FormattingEnabled = true;
            this.cboPosAfina.Items.AddRange(new object[] {
            "(-1)",
            "( 1)",
            "( 2)",
            "( 3)",
            "( 4)",
            "( 5)",
            "( 6)"});
            this.cboPosAfina.Location = new System.Drawing.Point(235, 18);
            this.cboPosAfina.Name = "cboPosAfina";
            this.cboPosAfina.Size = new System.Drawing.Size(47, 21);
            this.cboPosAfina.TabIndex = 14;
            // 
            // cboNotaAfina
            // 
            this.cboNotaAfina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotaAfina.FormattingEnabled = true;
            this.cboNotaAfina.Items.AddRange(new object[] {
            "Dó",
            "Ré b",
            "Ré",
            "Mi b",
            "Mi",
            "Fá",
            "Sol b",
            "Sol",
            "Lá b",
            "Lá",
            "Si b",
            "Si"});
            this.cboNotaAfina.Location = new System.Drawing.Point(150, 18);
            this.cboNotaAfina.Name = "cboNotaAfina";
            this.cboNotaAfina.Size = new System.Drawing.Size(79, 21);
            this.cboNotaAfina.TabIndex = 13;
            this.tipInst.SetToolTip(this.cboNotaAfina, "Selecione a nota de afinação, na escala natural do instrumento");
            // 
            // gpoAgudo
            // 
            this.gpoAgudo.Controls.Add(this.lblAguda);
            this.gpoAgudo.Controls.Add(this.pctAgudo);
            this.gpoAgudo.Controls.Add(this.tckAgudo);
            this.gpoAgudo.Location = new System.Drawing.Point(11, 218);
            this.gpoAgudo.Name = "gpoAgudo";
            this.gpoAgudo.Size = new System.Drawing.Size(564, 107);
            this.gpoAgudo.TabIndex = 2;
            this.gpoAgudo.TabStop = false;
            this.gpoAgudo.Text = "Nota mais aguda";
            // 
            // lblAguda
            // 
            this.lblAguda.Location = new System.Drawing.Point(481, 86);
            this.lblAguda.Name = "lblAguda";
            this.lblAguda.Size = new System.Drawing.Size(57, 13);
            this.lblAguda.TabIndex = 4;
            this.lblAguda.Text = "Dó(3)";
            this.lblAguda.Visible = false;
            // 
            // pctAgudo
            // 
            this.pctAgudo.Image = global::ccbinst.Properties.Resources.tesagudo;
            this.pctAgudo.Location = new System.Drawing.Point(6, 27);
            this.pctAgudo.Name = "pctAgudo";
            this.pctAgudo.Size = new System.Drawing.Size(546, 32);
            this.pctAgudo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctAgudo.TabIndex = 3;
            this.pctAgudo.TabStop = false;
            // 
            // tckAgudo
            // 
            this.tckAgudo.Location = new System.Drawing.Point(6, 57);
            this.tckAgudo.Maximum = 21;
            this.tckAgudo.Name = "tckAgudo";
            this.tckAgudo.Size = new System.Drawing.Size(546, 45);
            this.tckAgudo.TabIndex = 1;
            this.tckAgudo.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tckAgudo.ValueChanged += new System.EventHandler(this.tckAgudo_ValueChanged);
            // 
            // gpoGrave
            // 
            this.gpoGrave.Controls.Add(this.lblGrave);
            this.gpoGrave.Controls.Add(this.pctGrave);
            this.gpoGrave.Controls.Add(this.tckGrave);
            this.gpoGrave.Location = new System.Drawing.Point(11, 100);
            this.gpoGrave.Name = "gpoGrave";
            this.gpoGrave.Size = new System.Drawing.Size(564, 107);
            this.gpoGrave.TabIndex = 0;
            this.gpoGrave.TabStop = false;
            this.gpoGrave.Text = "Nota mais grave";
            // 
            // lblGrave
            // 
            this.lblGrave.Location = new System.Drawing.Point(481, 89);
            this.lblGrave.Name = "lblGrave";
            this.lblGrave.Size = new System.Drawing.Size(57, 13);
            this.lblGrave.TabIndex = 3;
            this.lblGrave.Text = "Dó(-1)";
            this.lblGrave.Visible = false;
            // 
            // pctGrave
            // 
            this.pctGrave.Image = global::ccbinst.Properties.Resources.tesgrave;
            this.pctGrave.Location = new System.Drawing.Point(6, 30);
            this.pctGrave.Name = "pctGrave";
            this.pctGrave.Size = new System.Drawing.Size(546, 32);
            this.pctGrave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctGrave.TabIndex = 2;
            this.pctGrave.TabStop = false;
            // 
            // tckGrave
            // 
            this.tckGrave.Location = new System.Drawing.Point(6, 60);
            this.tckGrave.Maximum = 21;
            this.tckGrave.Name = "tckGrave";
            this.tckGrave.Size = new System.Drawing.Size(546, 45);
            this.tckGrave.TabIndex = 1;
            this.tckGrave.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tckGrave.ValueChanged += new System.EventHandler(this.tckGrave_ValueChanged);
            // 
            // lblCodFoto
            // 
            this.lblCodFoto.Location = new System.Drawing.Point(292, 400);
            this.lblCodFoto.Name = "lblCodFoto";
            this.lblCodFoto.Size = new System.Drawing.Size(44, 13);
            this.lblCodFoto.TabIndex = 16;
            // 
            // frmInst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(609, 435);
            this.Controls.Add(this.lblCodFoto);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tabInst);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInst";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instrumentos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInstr_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInstr_FormClosed);
            this.Load += new System.EventHandler(this.frmInstr_Load);
            this.tabInst.ResumeLayout(false);
            this.tabGeral.ResumeLayout(false);
            this.tabGeral.PerformLayout();
            this.gpoHinario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHinario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdem)).EndInit();
            this.gpoSituacao.ResumeLayout(false);
            this.gpoSituacao.PerformLayout();
            this.gpoTonal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTonalidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFoto)).EndInit();
            this.tabVoz.ResumeLayout(false);
            this.gpoAltern.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridAlterna)).EndInit();
            this.gpoPrinc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPrincipal)).EndInit();
            this.tabTessitura.ResumeLayout(false);
            this.gpoAfina.ResumeLayout(false);
            this.gpoAfina.PerformLayout();
            this.gpoAgudo.ResumeLayout(false);
            this.gpoAgudo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctAgudo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckAgudo)).EndInit();
            this.gpoGrave.ResumeLayout(false);
            this.gpoGrave.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctGrave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tckGrave)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TabControl tabInst;
        private System.Windows.Forms.TabPage tabGeral;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.PictureBox pctFoto;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TabPage tabTessitura;
        private System.Windows.Forms.Label lblFamilia;
        private System.Windows.Forms.ToolTip tipInst;
        private System.Windows.Forms.GroupBox gpoTonal;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.GroupBox gpoGrave;
        private System.Windows.Forms.TrackBar tckGrave;
        private System.Windows.Forms.GroupBox gpoAgudo;
        private System.Windows.Forms.TrackBar tckAgudo;
        private System.Windows.Forms.TabPage tabVoz;
        private System.Windows.Forms.GroupBox gpoPrinc;
        private System.Windows.Forms.GroupBox gpoAltern;
        private BLL.validacoes.Controles.TextBoxPersonal txtObs;
        private BLL.validacoes.Controles.ComboBoxPersonal cboFamilia;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private BLL.validacoes.Controles.DataGridViewPersonal gridAlterna;
        private BLL.validacoes.Controles.DataGridViewPersonal gridPrincipal;
        private System.Windows.Forms.PictureBox pctGrave;
        private System.Windows.Forms.PictureBox pctAgudo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.GroupBox gpoSituacao;
        private System.Windows.Forms.RadioButton optPermitido;
        private System.Windows.Forms.RadioButton optProibido;
        private System.Windows.Forms.RadioButton optNaoRecomendado;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lblAguda;
        private System.Windows.Forms.Label lblGrave;
        private BLL.validacoes.Controles.DataGridViewPersonal gridTonalidade;
        private System.Windows.Forms.Label lblCodFoto;
        private System.Windows.Forms.Label lblOrdem;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtOrdem;
        private System.Windows.Forms.GroupBox gpoAfina;
        private System.Windows.Forms.Label lblNotaEfeito;
        private BLL.validacoes.Controles.ComboBoxPersonal cboPosEfeito;
        private BLL.validacoes.Controles.ComboBoxPersonal cboNotaEfeito;
        private System.Windows.Forms.Label lblNotaAfina;
        private BLL.validacoes.Controles.ComboBoxPersonal cboPosAfina;
        private BLL.validacoes.Controles.ComboBoxPersonal cboNotaAfina;
        private System.Windows.Forms.GroupBox gpoHinario;
        private BLL.validacoes.Controles.DataGridViewPersonal gridHinario;
    }
}