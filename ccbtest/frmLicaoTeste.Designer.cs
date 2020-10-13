namespace ccbtest
{
    partial class frmLicaoTeste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLicaoTeste));
            this.tipMetodo = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnMtsSalvar = new System.Windows.Forms.Button();
            this.btnMtsCancelar = new System.Windows.Forms.Button();
            this.btnTeoriaSalvar = new System.Windows.Forms.Button();
            this.btnTeoriaCancelar = new System.Windows.Forms.Button();
            this.btnTeoriaEditar = new System.Windows.Forms.Button();
            this.btnTeoriaExcluir = new System.Windows.Forms.Button();
            this.btnTeoriaInserir = new System.Windows.Forms.Button();
            this.btnMtsEditar = new System.Windows.Forms.Button();
            this.btnMtsExcluir = new System.Windows.Forms.Button();
            this.btnMtsInserir = new System.Windows.Forms.Button();
            this.txtMtsPag = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.cboMtsMetodo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtMtsLicao = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.cboTeoria = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.tabTipo = new System.Windows.Forms.TabControl();
            this.tabMts = new System.Windows.Forms.TabPage();
            this.gpoMts = new System.Windows.Forms.GroupBox();
            this.lblCodLicaoMts = new System.Windows.Forms.Label();
            this.lblMtsAplicarEm = new System.Windows.Forms.Label();
            this.optMtsMeia = new System.Windows.Forms.RadioButton();
            this.lblTipoMts = new System.Windows.Forms.Label();
            this.optMtsCulto = new System.Windows.Forms.RadioButton();
            this.optMtsRjm = new System.Windows.Forms.RadioButton();
            this.optMtsOficial = new System.Windows.Forms.RadioButton();
            this.lblMtsPag = new System.Windows.Forms.Label();
            this.lblMtsMetodo = new System.Windows.Forms.Label();
            this.gpoMtsTipo = new System.Windows.Forms.GroupBox();
            this.optMtsRitmo = new System.Windows.Forms.RadioButton();
            this.optMtsSolfejo = new System.Windows.Forms.RadioButton();
            this.gridMts = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.tabTeoria = new System.Windows.Forms.TabPage();
            this.gpoTeoria = new System.Windows.Forms.GroupBox();
            this.lblCodLicaoTeoria = new System.Windows.Forms.Label();
            this.lblTeoriaAplicarEm = new System.Windows.Forms.Label();
            this.optTeoriaMeia = new System.Windows.Forms.RadioButton();
            this.optTeoriaCulto = new System.Windows.Forms.RadioButton();
            this.optTeoriaRjm = new System.Windows.Forms.RadioButton();
            this.optTeoriaOficial = new System.Windows.Forms.RadioButton();
            this.txtTeoriaPag = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblTeoriaPag = new System.Windows.Forms.Label();
            this.txtTeoriaNivel = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblTeoriaNivel = new System.Windows.Forms.Label();
            this.lblTeoria = new System.Windows.Forms.Label();
            this.gridTeoria = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.imgLicaoTeste = new System.Windows.Forms.ImageList(this.components);
            this.lblOficial = new System.Windows.Forms.Label();
            this.pctOficial = new System.Windows.Forms.PictureBox();
            this.lblCulto = new System.Windows.Forms.Label();
            this.pctCulto = new System.Windows.Forms.PictureBox();
            this.lblRjm = new System.Windows.Forms.Label();
            this.pctRjm = new System.Windows.Forms.PictureBox();
            this.lblMeiaHora = new System.Windows.Forms.Label();
            this.pctMeiaHora = new System.Windows.Forms.PictureBox();
            this.lblLegenda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtMtsPag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMtsLicao)).BeginInit();
            this.tabTipo.SuspendLayout();
            this.tabMts.SuspendLayout();
            this.gpoMts.SuspendLayout();
            this.gpoMtsTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMts)).BeginInit();
            this.tabTeoria.SuspendLayout();
            this.gpoTeoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOficial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCulto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRjm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMeiaHora)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(625, 366);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 52;
            this.btnFechar.Text = "&Fechar";
            this.tipMetodo.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnMtsSalvar
            // 
            this.btnMtsSalvar.Location = new System.Drawing.Point(583, 17);
            this.btnMtsSalvar.Name = "btnMtsSalvar";
            this.btnMtsSalvar.Size = new System.Drawing.Size(90, 25);
            this.btnMtsSalvar.TabIndex = 68;
            this.btnMtsSalvar.Text = "&Salvar ítem";
            this.tipMetodo.SetToolTip(this.btnMtsSalvar, "Salvar alterações");
            this.btnMtsSalvar.UseVisualStyleBackColor = true;
            this.btnMtsSalvar.Click += new System.EventHandler(this.btnMtsSalvar_Click);
            // 
            // btnMtsCancelar
            // 
            this.btnMtsCancelar.Location = new System.Drawing.Point(583, 46);
            this.btnMtsCancelar.Name = "btnMtsCancelar";
            this.btnMtsCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnMtsCancelar.TabIndex = 67;
            this.btnMtsCancelar.Text = "&Cancelar ítem";
            this.tipMetodo.SetToolTip(this.btnMtsCancelar, "Cancelar alterações");
            this.btnMtsCancelar.UseVisualStyleBackColor = true;
            this.btnMtsCancelar.Click += new System.EventHandler(this.btnMtsCancelar_Click);
            // 
            // btnTeoriaSalvar
            // 
            this.btnTeoriaSalvar.Location = new System.Drawing.Point(583, 17);
            this.btnTeoriaSalvar.Name = "btnTeoriaSalvar";
            this.btnTeoriaSalvar.Size = new System.Drawing.Size(90, 25);
            this.btnTeoriaSalvar.TabIndex = 68;
            this.btnTeoriaSalvar.Text = "&Salvar ítem";
            this.btnTeoriaSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipMetodo.SetToolTip(this.btnTeoriaSalvar, "Salvar alterações");
            this.btnTeoriaSalvar.UseVisualStyleBackColor = true;
            this.btnTeoriaSalvar.Click += new System.EventHandler(this.btnTeoriaSalvar_Click);
            // 
            // btnTeoriaCancelar
            // 
            this.btnTeoriaCancelar.Location = new System.Drawing.Point(583, 46);
            this.btnTeoriaCancelar.Name = "btnTeoriaCancelar";
            this.btnTeoriaCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnTeoriaCancelar.TabIndex = 67;
            this.btnTeoriaCancelar.Text = "&Cancelar ítem";
            this.tipMetodo.SetToolTip(this.btnTeoriaCancelar, "Cancelar alterações");
            this.btnTeoriaCancelar.UseVisualStyleBackColor = true;
            this.btnTeoriaCancelar.Click += new System.EventHandler(this.btnTeoriaCancelar_Click);
            // 
            // btnTeoriaEditar
            // 
            this.btnTeoriaEditar.Location = new System.Drawing.Point(506, 290);
            this.btnTeoriaEditar.Name = "btnTeoriaEditar";
            this.btnTeoriaEditar.Size = new System.Drawing.Size(90, 30);
            this.btnTeoriaEditar.TabIndex = 64;
            this.btnTeoriaEditar.Text = "&Editar";
            this.tipMetodo.SetToolTip(this.btnTeoriaEditar, "Editar");
            this.btnTeoriaEditar.UseVisualStyleBackColor = true;
            this.btnTeoriaEditar.Click += new System.EventHandler(this.btnTeoriaEditar_Click);
            // 
            // btnTeoriaExcluir
            // 
            this.btnTeoriaExcluir.Location = new System.Drawing.Point(600, 290);
            this.btnTeoriaExcluir.Name = "btnTeoriaExcluir";
            this.btnTeoriaExcluir.Size = new System.Drawing.Size(90, 30);
            this.btnTeoriaExcluir.TabIndex = 65;
            this.btnTeoriaExcluir.Text = "&Excluir";
            this.tipMetodo.SetToolTip(this.btnTeoriaExcluir, "Excluir");
            this.btnTeoriaExcluir.UseVisualStyleBackColor = true;
            this.btnTeoriaExcluir.Click += new System.EventHandler(this.btnTeoriaExcluir_Click);
            // 
            // btnTeoriaInserir
            // 
            this.btnTeoriaInserir.Location = new System.Drawing.Point(412, 290);
            this.btnTeoriaInserir.Name = "btnTeoriaInserir";
            this.btnTeoriaInserir.Size = new System.Drawing.Size(90, 30);
            this.btnTeoriaInserir.TabIndex = 66;
            this.btnTeoriaInserir.Text = "&Inserir";
            this.tipMetodo.SetToolTip(this.btnTeoriaInserir, "Inserir");
            this.btnTeoriaInserir.UseVisualStyleBackColor = true;
            this.btnTeoriaInserir.Click += new System.EventHandler(this.btnTeoriaInserir_Click);
            // 
            // btnMtsEditar
            // 
            this.btnMtsEditar.Location = new System.Drawing.Point(506, 290);
            this.btnMtsEditar.Name = "btnMtsEditar";
            this.btnMtsEditar.Size = new System.Drawing.Size(90, 30);
            this.btnMtsEditar.TabIndex = 64;
            this.btnMtsEditar.Text = "&Editar";
            this.tipMetodo.SetToolTip(this.btnMtsEditar, "Editar");
            this.btnMtsEditar.UseVisualStyleBackColor = true;
            this.btnMtsEditar.Click += new System.EventHandler(this.btnMtsEditar_Click);
            // 
            // btnMtsExcluir
            // 
            this.btnMtsExcluir.Location = new System.Drawing.Point(600, 290);
            this.btnMtsExcluir.Name = "btnMtsExcluir";
            this.btnMtsExcluir.Size = new System.Drawing.Size(90, 30);
            this.btnMtsExcluir.TabIndex = 65;
            this.btnMtsExcluir.Text = "&Excluir";
            this.tipMetodo.SetToolTip(this.btnMtsExcluir, "Excluir");
            this.btnMtsExcluir.UseVisualStyleBackColor = true;
            this.btnMtsExcluir.Click += new System.EventHandler(this.btnMtsExcluir_Click);
            // 
            // btnMtsInserir
            // 
            this.btnMtsInserir.Location = new System.Drawing.Point(412, 290);
            this.btnMtsInserir.Name = "btnMtsInserir";
            this.btnMtsInserir.Size = new System.Drawing.Size(90, 30);
            this.btnMtsInserir.TabIndex = 66;
            this.btnMtsInserir.Text = "&Inserir";
            this.tipMetodo.SetToolTip(this.btnMtsInserir, "Inserir");
            this.btnMtsInserir.UseVisualStyleBackColor = true;
            this.btnMtsInserir.Click += new System.EventHandler(this.btnMtsInserir_Click);
            // 
            // txtMtsPag
            // 
            this.txtMtsPag.BackColor = System.Drawing.Color.White;
            this.txtMtsPag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMtsPag.Location = new System.Drawing.Point(478, 49);
            this.txtMtsPag.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtMtsPag.Name = "txtMtsPag";
            this.txtMtsPag.Size = new System.Drawing.Size(45, 21);
            this.txtMtsPag.TabIndex = 47;
            this.txtMtsPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipMetodo.SetToolTip(this.txtMtsPag, "Página");
            // 
            // cboMtsMetodo
            // 
            this.cboMtsMetodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMtsMetodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMtsMetodo.BackColor = System.Drawing.Color.LightYellow;
            this.cboMtsMetodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMtsMetodo.FormattingEnabled = true;
            this.cboMtsMetodo.Location = new System.Drawing.Point(59, 49);
            this.cboMtsMetodo.Name = "cboMtsMetodo";
            this.cboMtsMetodo.Size = new System.Drawing.Size(177, 21);
            this.cboMtsMetodo.TabIndex = 61;
            this.tipMetodo.SetToolTip(this.cboMtsMetodo, "Selecione o método");
            this.cboMtsMetodo.SelectedIndexChanged += new System.EventHandler(this.cboMtsMetodo_SelectedIndexChanged);
            this.cboMtsMetodo.SelectionChangeCommitted += new System.EventHandler(this.cboMtsMetodo_SelectionChangeCommitted);
            // 
            // txtMtsLicao
            // 
            this.txtMtsLicao.BackColor = System.Drawing.Color.White;
            this.txtMtsLicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMtsLicao.Location = new System.Drawing.Point(527, 49);
            this.txtMtsLicao.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtMtsLicao.Name = "txtMtsLicao";
            this.txtMtsLicao.Size = new System.Drawing.Size(45, 21);
            this.txtMtsLicao.TabIndex = 49;
            this.txtMtsLicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipMetodo.SetToolTip(this.txtMtsLicao, "Lição");
            // 
            // cboTeoria
            // 
            this.cboTeoria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTeoria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTeoria.BackColor = System.Drawing.Color.LightYellow;
            this.cboTeoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTeoria.FormattingEnabled = true;
            this.cboTeoria.Location = new System.Drawing.Point(112, 50);
            this.cboTeoria.Name = "cboTeoria";
            this.cboTeoria.Size = new System.Drawing.Size(177, 21);
            this.cboTeoria.TabIndex = 62;
            this.tipMetodo.SetToolTip(this.cboTeoria, "Selecione a avaliação teórica");
            this.cboTeoria.SelectedIndexChanged += new System.EventHandler(this.cboTeoria_SelectedIndexChanged);
            this.cboTeoria.SelectionChangeCommitted += new System.EventHandler(this.cboTeoria_SelectionChangeCommitted);
            // 
            // tabTipo
            // 
            this.tabTipo.Controls.Add(this.tabMts);
            this.tabTipo.Controls.Add(this.tabTeoria);
            this.tabTipo.Location = new System.Drawing.Point(7, 6);
            this.tabTipo.Multiline = true;
            this.tabTipo.Name = "tabTipo";
            this.tabTipo.SelectedIndex = 0;
            this.tabTipo.Size = new System.Drawing.Size(707, 354);
            this.tabTipo.TabIndex = 0;
            this.tabTipo.SelectedIndexChanged += new System.EventHandler(this.tabTipo_SelectedIndexChanged);
            // 
            // tabMts
            // 
            this.tabMts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabMts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabMts.Controls.Add(this.gpoMts);
            this.tabMts.Controls.Add(this.btnMtsInserir);
            this.tabMts.Controls.Add(this.btnMtsExcluir);
            this.tabMts.Controls.Add(this.btnMtsEditar);
            this.tabMts.Controls.Add(this.gridMts);
            this.tabMts.Location = new System.Drawing.Point(4, 22);
            this.tabMts.Name = "tabMts";
            this.tabMts.Padding = new System.Windows.Forms.Padding(3);
            this.tabMts.Size = new System.Drawing.Size(699, 328);
            this.tabMts.TabIndex = 2;
            this.tabMts.Text = "MTS (Ritmo e Solfejo)";
            // 
            // gpoMts
            // 
            this.gpoMts.Controls.Add(this.lblCodLicaoMts);
            this.gpoMts.Controls.Add(this.txtMtsPag);
            this.gpoMts.Controls.Add(this.lblMtsAplicarEm);
            this.gpoMts.Controls.Add(this.optMtsMeia);
            this.gpoMts.Controls.Add(this.lblTipoMts);
            this.gpoMts.Controls.Add(this.optMtsCulto);
            this.gpoMts.Controls.Add(this.optMtsRjm);
            this.gpoMts.Controls.Add(this.optMtsOficial);
            this.gpoMts.Controls.Add(this.cboMtsMetodo);
            this.gpoMts.Controls.Add(this.btnMtsSalvar);
            this.gpoMts.Controls.Add(this.txtMtsLicao);
            this.gpoMts.Controls.Add(this.btnMtsCancelar);
            this.gpoMts.Controls.Add(this.lblMtsPag);
            this.gpoMts.Controls.Add(this.lblMtsMetodo);
            this.gpoMts.Controls.Add(this.gpoMtsTipo);
            this.gpoMts.Enabled = false;
            this.gpoMts.Location = new System.Drawing.Point(6, 6);
            this.gpoMts.Name = "gpoMts";
            this.gpoMts.Size = new System.Drawing.Size(684, 81);
            this.gpoMts.TabIndex = 69;
            this.gpoMts.TabStop = false;
            this.gpoMts.Text = "Informe a página e a lição do MTS que será pré-selecionada para o teste";
            // 
            // lblCodLicaoMts
            // 
            this.lblCodLicaoMts.Enabled = false;
            this.lblCodLicaoMts.Location = new System.Drawing.Point(497, 12);
            this.lblCodLicaoMts.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodLicaoMts.Name = "lblCodLicaoMts";
            this.lblCodLicaoMts.Size = new System.Drawing.Size(35, 13);
            this.lblCodLicaoMts.TabIndex = 136;
            // 
            // lblMtsAplicarEm
            // 
            this.lblMtsAplicarEm.Enabled = false;
            this.lblMtsAplicarEm.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblMtsAplicarEm.Location = new System.Drawing.Point(400, 22);
            this.lblMtsAplicarEm.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMtsAplicarEm.Name = "lblMtsAplicarEm";
            this.lblMtsAplicarEm.Size = new System.Drawing.Size(79, 13);
            this.lblMtsAplicarEm.TabIndex = 134;
            this.lblMtsAplicarEm.Visible = false;
            // 
            // optMtsMeia
            // 
            this.optMtsMeia.AutoSize = true;
            this.optMtsMeia.BackColor = System.Drawing.Color.Transparent;
            this.optMtsMeia.Location = new System.Drawing.Point(147, 18);
            this.optMtsMeia.Name = "optMtsMeia";
            this.optMtsMeia.Size = new System.Drawing.Size(73, 17);
            this.optMtsMeia.TabIndex = 132;
            this.optMtsMeia.Text = "Meia Hora";
            this.optMtsMeia.UseVisualStyleBackColor = false;
            this.optMtsMeia.CheckedChanged += new System.EventHandler(this.optMtsMeia_CheckedChanged);
            // 
            // lblTipoMts
            // 
            this.lblTipoMts.Location = new System.Drawing.Point(488, 25);
            this.lblTipoMts.Name = "lblTipoMts";
            this.lblTipoMts.Size = new System.Drawing.Size(72, 15);
            this.lblTipoMts.TabIndex = 72;
            // 
            // optMtsCulto
            // 
            this.optMtsCulto.AutoSize = true;
            this.optMtsCulto.BackColor = System.Drawing.Color.Transparent;
            this.optMtsCulto.Location = new System.Drawing.Point(226, 18);
            this.optMtsCulto.Name = "optMtsCulto";
            this.optMtsCulto.Size = new System.Drawing.Size(82, 17);
            this.optMtsCulto.TabIndex = 130;
            this.optMtsCulto.Text = "Culto Oficial";
            this.optMtsCulto.UseVisualStyleBackColor = false;
            this.optMtsCulto.CheckedChanged += new System.EventHandler(this.optMtsCulto_CheckedChanged);
            // 
            // optMtsRjm
            // 
            this.optMtsRjm.AutoSize = true;
            this.optMtsRjm.BackColor = System.Drawing.Color.Transparent;
            this.optMtsRjm.Location = new System.Drawing.Point(40, 18);
            this.optMtsRjm.Name = "optMtsRjm";
            this.optMtsRjm.Size = new System.Drawing.Size(101, 17);
            this.optMtsRjm.TabIndex = 129;
            this.optMtsRjm.Text = "Reunião Jovens";
            this.optMtsRjm.UseVisualStyleBackColor = false;
            this.optMtsRjm.CheckedChanged += new System.EventHandler(this.optMtsRjm_CheckedChanged);
            // 
            // optMtsOficial
            // 
            this.optMtsOficial.AutoSize = true;
            this.optMtsOficial.BackColor = System.Drawing.Color.Transparent;
            this.optMtsOficial.Location = new System.Drawing.Point(314, 18);
            this.optMtsOficial.Name = "optMtsOficial";
            this.optMtsOficial.Size = new System.Drawing.Size(84, 17);
            this.optMtsOficial.TabIndex = 131;
            this.optMtsOficial.Text = "Oficialização";
            this.optMtsOficial.UseVisualStyleBackColor = false;
            this.optMtsOficial.CheckedChanged += new System.EventHandler(this.optMtsOficial_CheckedChanged);
            // 
            // lblMtsPag
            // 
            this.lblMtsPag.AutoSize = true;
            this.lblMtsPag.Location = new System.Drawing.Point(400, 53);
            this.lblMtsPag.Name = "lblMtsPag";
            this.lblMtsPag.Size = new System.Drawing.Size(81, 13);
            this.lblMtsPag.TabIndex = 21;
            this.lblMtsPag.Text = "Módulo e Lição:";
            // 
            // lblMtsMetodo
            // 
            this.lblMtsMetodo.AutoSize = true;
            this.lblMtsMetodo.Location = new System.Drawing.Point(11, 53);
            this.lblMtsMetodo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMtsMetodo.Name = "lblMtsMetodo";
            this.lblMtsMetodo.Size = new System.Drawing.Size(47, 13);
            this.lblMtsMetodo.TabIndex = 60;
            this.lblMtsMetodo.Text = "Método:";
            // 
            // gpoMtsTipo
            // 
            this.gpoMtsTipo.BackColor = System.Drawing.Color.Transparent;
            this.gpoMtsTipo.Controls.Add(this.optMtsRitmo);
            this.gpoMtsTipo.Controls.Add(this.optMtsSolfejo);
            this.gpoMtsTipo.Location = new System.Drawing.Point(245, 39);
            this.gpoMtsTipo.Name = "gpoMtsTipo";
            this.gpoMtsTipo.Size = new System.Drawing.Size(147, 35);
            this.gpoMtsTipo.TabIndex = 62;
            this.gpoMtsTipo.TabStop = false;
            // 
            // optMtsRitmo
            // 
            this.optMtsRitmo.AutoSize = true;
            this.optMtsRitmo.Location = new System.Drawing.Point(64, 11);
            this.optMtsRitmo.Name = "optMtsRitmo";
            this.optMtsRitmo.Size = new System.Drawing.Size(85, 17);
            this.optMtsRitmo.TabIndex = 1;
            this.optMtsRitmo.TabStop = true;
            this.optMtsRitmo.Text = "Ling. Ritmica";
            this.optMtsRitmo.UseVisualStyleBackColor = true;
            this.optMtsRitmo.CheckedChanged += new System.EventHandler(this.optMtsRitmo_CheckedChanged);
            // 
            // optMtsSolfejo
            // 
            this.optMtsSolfejo.AutoSize = true;
            this.optMtsSolfejo.Location = new System.Drawing.Point(7, 11);
            this.optMtsSolfejo.Name = "optMtsSolfejo";
            this.optMtsSolfejo.Size = new System.Drawing.Size(58, 17);
            this.optMtsSolfejo.TabIndex = 0;
            this.optMtsSolfejo.TabStop = true;
            this.optMtsSolfejo.Text = "Solfejo";
            this.optMtsSolfejo.UseVisualStyleBackColor = true;
            this.optMtsSolfejo.CheckedChanged += new System.EventHandler(this.optMtsSolfejo_CheckedChanged);
            // 
            // gridMts
            // 
            this.gridMts.AllowUserToAddRows = false;
            this.gridMts.AllowUserToDeleteRows = false;
            this.gridMts.AllowUserToResizeRows = false;
            this.gridMts.BackgroundColor = System.Drawing.Color.White;
            this.gridMts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridMts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridMts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridMts.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridMts.DisabledCell = null;
            this.gridMts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridMts.EnableHeadersVisualStyles = false;
            this.gridMts.Location = new System.Drawing.Point(6, 93);
            this.gridMts.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridMts.MultiSelect = false;
            this.gridMts.Name = "gridMts";
            this.gridMts.ReadOnly = true;
            this.gridMts.RowHeadersVisible = false;
            this.gridMts.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridMts.RowTemplate.Height = 18;
            this.gridMts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridMts.Size = new System.Drawing.Size(684, 191);
            this.gridMts.TabIndex = 63;
            this.gridMts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridMts_CellDoubleClick);
            this.gridMts.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridMts_RowStateChanged);
            // 
            // tabTeoria
            // 
            this.tabTeoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabTeoria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabTeoria.Controls.Add(this.gpoTeoria);
            this.tabTeoria.Controls.Add(this.btnTeoriaInserir);
            this.tabTeoria.Controls.Add(this.btnTeoriaExcluir);
            this.tabTeoria.Controls.Add(this.btnTeoriaEditar);
            this.tabTeoria.Controls.Add(this.gridTeoria);
            this.tabTeoria.Location = new System.Drawing.Point(4, 22);
            this.tabTeoria.Name = "tabTeoria";
            this.tabTeoria.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeoria.Size = new System.Drawing.Size(699, 328);
            this.tabTeoria.TabIndex = 4;
            this.tabTeoria.Text = "Teoria";
            // 
            // gpoTeoria
            // 
            this.gpoTeoria.Controls.Add(this.lblCodLicaoTeoria);
            this.gpoTeoria.Controls.Add(this.lblTeoriaAplicarEm);
            this.gpoTeoria.Controls.Add(this.optTeoriaMeia);
            this.gpoTeoria.Controls.Add(this.optTeoriaCulto);
            this.gpoTeoria.Controls.Add(this.optTeoriaRjm);
            this.gpoTeoria.Controls.Add(this.optTeoriaOficial);
            this.gpoTeoria.Controls.Add(this.txtTeoriaPag);
            this.gpoTeoria.Controls.Add(this.lblTeoriaPag);
            this.gpoTeoria.Controls.Add(this.txtTeoriaNivel);
            this.gpoTeoria.Controls.Add(this.lblTeoriaNivel);
            this.gpoTeoria.Controls.Add(this.btnTeoriaSalvar);
            this.gpoTeoria.Controls.Add(this.cboTeoria);
            this.gpoTeoria.Controls.Add(this.btnTeoriaCancelar);
            this.gpoTeoria.Controls.Add(this.lblTeoria);
            this.gpoTeoria.Enabled = false;
            this.gpoTeoria.Location = new System.Drawing.Point(6, 6);
            this.gpoTeoria.Name = "gpoTeoria";
            this.gpoTeoria.Size = new System.Drawing.Size(684, 81);
            this.gpoTeoria.TabIndex = 69;
            this.gpoTeoria.TabStop = false;
            this.gpoTeoria.Text = "Informe a atividade teórica que será pré-selecionada para o teste";
            // 
            // lblCodLicaoTeoria
            // 
            this.lblCodLicaoTeoria.Enabled = false;
            this.lblCodLicaoTeoria.Location = new System.Drawing.Point(481, 24);
            this.lblCodLicaoTeoria.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodLicaoTeoria.Name = "lblCodLicaoTeoria";
            this.lblCodLicaoTeoria.Size = new System.Drawing.Size(35, 13);
            this.lblCodLicaoTeoria.TabIndex = 138;
            // 
            // lblTeoriaAplicarEm
            // 
            this.lblTeoriaAplicarEm.Enabled = false;
            this.lblTeoriaAplicarEm.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTeoriaAplicarEm.Location = new System.Drawing.Point(398, 20);
            this.lblTeoriaAplicarEm.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTeoriaAplicarEm.Name = "lblTeoriaAplicarEm";
            this.lblTeoriaAplicarEm.Size = new System.Drawing.Size(73, 13);
            this.lblTeoriaAplicarEm.TabIndex = 134;
            this.lblTeoriaAplicarEm.Visible = false;
            // 
            // optTeoriaMeia
            // 
            this.optTeoriaMeia.AutoSize = true;
            this.optTeoriaMeia.BackColor = System.Drawing.Color.Transparent;
            this.optTeoriaMeia.Location = new System.Drawing.Point(147, 18);
            this.optTeoriaMeia.Name = "optTeoriaMeia";
            this.optTeoriaMeia.Size = new System.Drawing.Size(73, 17);
            this.optTeoriaMeia.TabIndex = 132;
            this.optTeoriaMeia.Text = "Meia Hora";
            this.optTeoriaMeia.UseVisualStyleBackColor = false;
            this.optTeoriaMeia.CheckedChanged += new System.EventHandler(this.optTeoriaMeia_CheckedChanged);
            // 
            // optTeoriaCulto
            // 
            this.optTeoriaCulto.AutoSize = true;
            this.optTeoriaCulto.BackColor = System.Drawing.Color.Transparent;
            this.optTeoriaCulto.Location = new System.Drawing.Point(226, 18);
            this.optTeoriaCulto.Name = "optTeoriaCulto";
            this.optTeoriaCulto.Size = new System.Drawing.Size(82, 17);
            this.optTeoriaCulto.TabIndex = 130;
            this.optTeoriaCulto.Text = "Culto Oficial";
            this.optTeoriaCulto.UseVisualStyleBackColor = false;
            this.optTeoriaCulto.CheckedChanged += new System.EventHandler(this.optTeoriaCulto_CheckedChanged);
            // 
            // optTeoriaRjm
            // 
            this.optTeoriaRjm.AutoSize = true;
            this.optTeoriaRjm.BackColor = System.Drawing.Color.Transparent;
            this.optTeoriaRjm.Location = new System.Drawing.Point(40, 18);
            this.optTeoriaRjm.Name = "optTeoriaRjm";
            this.optTeoriaRjm.Size = new System.Drawing.Size(101, 17);
            this.optTeoriaRjm.TabIndex = 129;
            this.optTeoriaRjm.Text = "Reunião Jovens";
            this.optTeoriaRjm.UseVisualStyleBackColor = false;
            this.optTeoriaRjm.CheckedChanged += new System.EventHandler(this.optTeoriaRjm_CheckedChanged);
            // 
            // optTeoriaOficial
            // 
            this.optTeoriaOficial.AutoSize = true;
            this.optTeoriaOficial.BackColor = System.Drawing.Color.Transparent;
            this.optTeoriaOficial.Location = new System.Drawing.Point(314, 18);
            this.optTeoriaOficial.Name = "optTeoriaOficial";
            this.optTeoriaOficial.Size = new System.Drawing.Size(84, 17);
            this.optTeoriaOficial.TabIndex = 131;
            this.optTeoriaOficial.Text = "Oficialização";
            this.optTeoriaOficial.UseVisualStyleBackColor = false;
            this.optTeoriaOficial.CheckedChanged += new System.EventHandler(this.optTeoriaOficial_CheckedChanged);
            // 
            // txtTeoriaPag
            // 
            this.txtTeoriaPag.BackColor = System.Drawing.Color.LightGray;
            this.txtTeoriaPag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeoriaPag.Enabled = false;
            this.txtTeoriaPag.Location = new System.Drawing.Point(511, 49);
            this.txtTeoriaPag.Name = "txtTeoriaPag";
            this.txtTeoriaPag.Size = new System.Drawing.Size(52, 21);
            this.txtTeoriaPag.TabIndex = 82;
            this.txtTeoriaPag.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblTeoriaPag
            // 
            this.lblTeoriaPag.AutoSize = true;
            this.lblTeoriaPag.Enabled = false;
            this.lblTeoriaPag.Location = new System.Drawing.Point(421, 53);
            this.lblTeoriaPag.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTeoriaPag.Name = "lblTeoriaPag";
            this.lblTeoriaPag.Size = new System.Drawing.Size(90, 13);
            this.lblTeoriaPag.TabIndex = 81;
            this.lblTeoriaPag.Text = "Total de páginas:";
            // 
            // txtTeoriaNivel
            // 
            this.txtTeoriaNivel.BackColor = System.Drawing.Color.LightGray;
            this.txtTeoriaNivel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTeoriaNivel.Enabled = false;
            this.txtTeoriaNivel.Location = new System.Drawing.Point(338, 49);
            this.txtTeoriaNivel.Name = "txtTeoriaNivel";
            this.txtTeoriaNivel.Size = new System.Drawing.Size(69, 21);
            this.txtTeoriaNivel.TabIndex = 80;
            this.txtTeoriaNivel.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblTeoriaNivel
            // 
            this.lblTeoriaNivel.AutoSize = true;
            this.lblTeoriaNivel.Enabled = false;
            this.lblTeoriaNivel.Location = new System.Drawing.Point(299, 53);
            this.lblTeoriaNivel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTeoriaNivel.Name = "lblTeoriaNivel";
            this.lblTeoriaNivel.Size = new System.Drawing.Size(34, 13);
            this.lblTeoriaNivel.TabIndex = 79;
            this.lblTeoriaNivel.Text = "Nível:";
            // 
            // lblTeoria
            // 
            this.lblTeoria.AutoSize = true;
            this.lblTeoria.Location = new System.Drawing.Point(11, 53);
            this.lblTeoria.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTeoria.Name = "lblTeoria";
            this.lblTeoria.Size = new System.Drawing.Size(93, 13);
            this.lblTeoria.TabIndex = 60;
            this.lblTeoria.Text = "Avaliação teórica:";
            // 
            // gridTeoria
            // 
            this.gridTeoria.AllowUserToAddRows = false;
            this.gridTeoria.AllowUserToDeleteRows = false;
            this.gridTeoria.AllowUserToResizeRows = false;
            this.gridTeoria.BackgroundColor = System.Drawing.Color.White;
            this.gridTeoria.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTeoria.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTeoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridTeoria.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridTeoria.DisabledCell = null;
            this.gridTeoria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridTeoria.EnableHeadersVisualStyles = false;
            this.gridTeoria.Location = new System.Drawing.Point(6, 93);
            this.gridTeoria.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridTeoria.MultiSelect = false;
            this.gridTeoria.Name = "gridTeoria";
            this.gridTeoria.ReadOnly = true;
            this.gridTeoria.RowHeadersVisible = false;
            this.gridTeoria.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTeoria.RowTemplate.Height = 18;
            this.gridTeoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTeoria.Size = new System.Drawing.Size(684, 191);
            this.gridTeoria.TabIndex = 63;
            this.gridTeoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTeoria_CellDoubleClick);
            this.gridTeoria.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridTeoria_RowStateChanged);
            // 
            // imgLicaoTeste
            // 
            this.imgLicaoTeste.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLicaoTeste.ImageStream")));
            this.imgLicaoTeste.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLicaoTeste.Images.SetKeyName(0, "NotaAmarela.png");
            this.imgLicaoTeste.Images.SetKeyName(1, "NotaAzul.png");
            this.imgLicaoTeste.Images.SetKeyName(2, "NotaCinza.png");
            this.imgLicaoTeste.Images.SetKeyName(3, "NotaLilas.png");
            this.imgLicaoTeste.Images.SetKeyName(4, "NotaVerde.png");
            this.imgLicaoTeste.Images.SetKeyName(5, "NotaVermelha.png");
            // 
            // lblOficial
            // 
            this.lblOficial.AutoSize = true;
            this.lblOficial.Location = new System.Drawing.Point(310, 381);
            this.lblOficial.Name = "lblOficial";
            this.lblOficial.Size = new System.Drawing.Size(66, 13);
            this.lblOficial.TabIndex = 128;
            this.lblOficial.Text = "Oficialização";
            // 
            // pctOficial
            // 
            this.pctOficial.Location = new System.Drawing.Point(293, 377);
            this.pctOficial.Name = "pctOficial";
            this.pctOficial.Size = new System.Drawing.Size(16, 20);
            this.pctOficial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctOficial.TabIndex = 127;
            this.pctOficial.TabStop = false;
            // 
            // lblCulto
            // 
            this.lblCulto.AutoSize = true;
            this.lblCulto.Location = new System.Drawing.Point(223, 381);
            this.lblCulto.Name = "lblCulto";
            this.lblCulto.Size = new System.Drawing.Size(64, 13);
            this.lblCulto.TabIndex = 126;
            this.lblCulto.Text = "Culto Oficial";
            // 
            // pctCulto
            // 
            this.pctCulto.Location = new System.Drawing.Point(206, 377);
            this.pctCulto.Name = "pctCulto";
            this.pctCulto.Size = new System.Drawing.Size(16, 20);
            this.pctCulto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctCulto.TabIndex = 125;
            this.pctCulto.TabStop = false;
            // 
            // lblRjm
            // 
            this.lblRjm.AutoSize = true;
            this.lblRjm.Location = new System.Drawing.Point(24, 381);
            this.lblRjm.Name = "lblRjm";
            this.lblRjm.Size = new System.Drawing.Size(98, 13);
            this.lblRjm.TabIndex = 124;
            this.lblRjm.Text = "Reunião de Jovens";
            // 
            // pctRjm
            // 
            this.pctRjm.Location = new System.Drawing.Point(7, 376);
            this.pctRjm.Name = "pctRjm";
            this.pctRjm.Size = new System.Drawing.Size(16, 20);
            this.pctRjm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctRjm.TabIndex = 123;
            this.pctRjm.TabStop = false;
            // 
            // lblMeiaHora
            // 
            this.lblMeiaHora.AutoSize = true;
            this.lblMeiaHora.Location = new System.Drawing.Point(145, 381);
            this.lblMeiaHora.Name = "lblMeiaHora";
            this.lblMeiaHora.Size = new System.Drawing.Size(55, 13);
            this.lblMeiaHora.TabIndex = 122;
            this.lblMeiaHora.Text = "Meia Hora";
            // 
            // pctMeiaHora
            // 
            this.pctMeiaHora.Location = new System.Drawing.Point(128, 377);
            this.pctMeiaHora.Name = "pctMeiaHora";
            this.pctMeiaHora.Size = new System.Drawing.Size(16, 20);
            this.pctMeiaHora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctMeiaHora.TabIndex = 121;
            this.pctMeiaHora.TabStop = false;
            // 
            // lblLegenda
            // 
            this.lblLegenda.AutoSize = true;
            this.lblLegenda.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLegenda.Location = new System.Drawing.Point(4, 363);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(169, 13);
            this.lblLegenda.TabIndex = 131;
            this.lblLegenda.Text = "Legenda - Lições de Testes para: ";
            // 
            // frmLicaoTeste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(720, 404);
            this.Controls.Add(this.tabTipo);
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.lblOficial);
            this.Controls.Add(this.pctOficial);
            this.Controls.Add(this.lblCulto);
            this.Controls.Add(this.pctCulto);
            this.Controls.Add(this.lblRjm);
            this.Controls.Add(this.pctRjm);
            this.Controls.Add(this.lblMeiaHora);
            this.Controls.Add(this.pctMeiaHora);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLicaoTeste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Escolha de lições que serão aplicadas nos testes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLicaoTeste_FormClosing);
            this.Load += new System.EventHandler(this.frmLicaoTeste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMtsPag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMtsLicao)).EndInit();
            this.tabTipo.ResumeLayout(false);
            this.tabMts.ResumeLayout(false);
            this.gpoMts.ResumeLayout(false);
            this.gpoMts.PerformLayout();
            this.gpoMtsTipo.ResumeLayout(false);
            this.gpoMtsTipo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridMts)).EndInit();
            this.tabTeoria.ResumeLayout(false);
            this.gpoTeoria.ResumeLayout(false);
            this.gpoTeoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTeoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOficial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCulto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRjm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMeiaHora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipMetodo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.TabControl tabTipo;
        private System.Windows.Forms.TabPage tabMts;
        private System.Windows.Forms.GroupBox gpoMts;
        private BLL.validacoes.Controles.ComboBoxPersonal cboMtsMetodo;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtMtsLicao;
        private System.Windows.Forms.Label lblMtsPag;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtMtsPag;
        private System.Windows.Forms.Label lblMtsMetodo;
        private System.Windows.Forms.Button btnMtsSalvar;
        private System.Windows.Forms.Button btnMtsCancelar;
        private BLL.validacoes.Controles.DataGridViewPersonal gridMts;
        private System.Windows.Forms.TabPage tabTeoria;
        private System.Windows.Forms.GroupBox gpoMtsTipo;
        private System.Windows.Forms.RadioButton optMtsRitmo;
        private System.Windows.Forms.RadioButton optMtsSolfejo;
        private System.Windows.Forms.GroupBox gpoTeoria;
        private System.Windows.Forms.Label lblTeoria;
        private System.Windows.Forms.Button btnTeoriaSalvar;
        private System.Windows.Forms.Button btnTeoriaCancelar;
        private BLL.validacoes.Controles.DataGridViewPersonal gridTeoria;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTeoria;
        private System.Windows.Forms.Button btnMtsInserir;
        private System.Windows.Forms.Button btnMtsExcluir;
        private System.Windows.Forms.Button btnMtsEditar;
        private System.Windows.Forms.Button btnTeoriaInserir;
        private System.Windows.Forms.Button btnTeoriaExcluir;
        private System.Windows.Forms.Button btnTeoriaEditar;
        private System.Windows.Forms.Label lblTipoMts;
        private BLL.validacoes.Controles.TextBoxPersonal txtTeoriaPag;
        private System.Windows.Forms.Label lblTeoriaPag;
        private BLL.validacoes.Controles.TextBoxPersonal txtTeoriaNivel;
        private System.Windows.Forms.Label lblTeoriaNivel;
        private System.Windows.Forms.ImageList imgLicaoTeste;
        private System.Windows.Forms.Label lblOficial;
        private System.Windows.Forms.PictureBox pctOficial;
        private System.Windows.Forms.Label lblCulto;
        private System.Windows.Forms.PictureBox pctCulto;
        private System.Windows.Forms.Label lblRjm;
        private System.Windows.Forms.PictureBox pctRjm;
        private System.Windows.Forms.Label lblMeiaHora;
        private System.Windows.Forms.PictureBox pctMeiaHora;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.Label lblMtsAplicarEm;
        private System.Windows.Forms.RadioButton optMtsMeia;
        private System.Windows.Forms.RadioButton optMtsCulto;
        private System.Windows.Forms.RadioButton optMtsRjm;
        private System.Windows.Forms.RadioButton optMtsOficial;
        private System.Windows.Forms.Label lblTeoriaAplicarEm;
        private System.Windows.Forms.RadioButton optTeoriaMeia;
        private System.Windows.Forms.RadioButton optTeoriaCulto;
        private System.Windows.Forms.RadioButton optTeoriaRjm;
        private System.Windows.Forms.RadioButton optTeoriaOficial;
        private System.Windows.Forms.Label lblCodLicaoMts;
        private System.Windows.Forms.Label lblCodLicaoTeoria;
    }
}