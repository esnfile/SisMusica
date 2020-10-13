namespace ccbusua
{
    partial class frmModProg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModProg));
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlMod = new System.Windows.Forms.Panel();
            this.gpoSubMod = new System.Windows.Forms.GroupBox();
            this.gridSubMod = new System.Windows.Forms.DataGridView();
            this.btnSubIns = new System.Windows.Forms.Button();
            this.btnSubEditar = new System.Windows.Forms.Button();
            this.btnSubExc = new System.Windows.Forms.Button();
            this.gpoRotina = new System.Windows.Forms.GroupBox();
            this.gridRot = new System.Windows.Forms.DataGridView();
            this.colAcaoCod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcaoDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcaoSeg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcaoMod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAcaoProg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRotIns = new System.Windows.Forms.Button();
            this.btnRotExc = new System.Windows.Forms.Button();
            this.btnRotEditar = new System.Windows.Forms.Button();
            this.gpoPrograma = new System.Windows.Forms.GroupBox();
            this.gridProg = new System.Windows.Forms.DataGridView();
            this.btnProgIns = new System.Windows.Forms.Button();
            this.btnProgExc = new System.Windows.Forms.Button();
            this.btnProgEditar = new System.Windows.Forms.Button();
            this.gpoModulo = new System.Windows.Forms.GroupBox();
            this.gridModulo = new System.Windows.Forms.DataGridView();
            this.btnModIns = new System.Windows.Forms.Button();
            this.btnModEditar = new System.Windows.Forms.Button();
            this.btnModExc = new System.Windows.Forms.Button();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.pnlMod.SuspendLayout();
            this.gpoSubMod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubMod)).BeginInit();
            this.gpoRotina.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRot)).BeginInit();
            this.gpoPrograma.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridProg)).BeginInit();
            this.gpoModulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModulo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(652, 403);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 25);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pnlMod
            // 
            this.pnlMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlMod.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlMod.Controls.Add(this.gpoSubMod);
            this.pnlMod.Controls.Add(this.gpoRotina);
            this.pnlMod.Controls.Add(this.gpoPrograma);
            this.pnlMod.Controls.Add(this.gpoModulo);
            this.pnlMod.Location = new System.Drawing.Point(5, 5);
            this.pnlMod.Name = "pnlMod";
            this.pnlMod.Size = new System.Drawing.Size(722, 392);
            this.pnlMod.TabIndex = 0;
            // 
            // gpoSubMod
            // 
            this.gpoSubMod.Controls.Add(this.gridSubMod);
            this.gpoSubMod.Controls.Add(this.btnSubIns);
            this.gpoSubMod.Controls.Add(this.btnSubEditar);
            this.gpoSubMod.Controls.Add(this.btnSubExc);
            this.gpoSubMod.Location = new System.Drawing.Point(227, 7);
            this.gpoSubMod.Name = "gpoSubMod";
            this.gpoSubMod.Size = new System.Drawing.Size(213, 171);
            this.gpoSubMod.TabIndex = 1;
            this.gpoSubMod.TabStop = false;
            this.gpoSubMod.Text = "Sub-Módulos";
            // 
            // gridSubMod
            // 
            this.gridSubMod.AllowUserToAddRows = false;
            this.gridSubMod.AllowUserToDeleteRows = false;
            this.gridSubMod.AllowUserToResizeColumns = false;
            this.gridSubMod.AllowUserToResizeRows = false;
            this.gridSubMod.BackgroundColor = System.Drawing.Color.White;
            this.gridSubMod.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSubMod.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSubMod.ColumnHeadersHeight = 17;
            this.gridSubMod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSubMod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSubMod.EnableHeadersVisualStyles = false;
            this.gridSubMod.Location = new System.Drawing.Point(6, 13);
            this.gridSubMod.MultiSelect = false;
            this.gridSubMod.Name = "gridSubMod";
            this.gridSubMod.ReadOnly = true;
            this.gridSubMod.RowHeadersVisible = false;
            this.gridSubMod.RowTemplate.Height = 18;
            this.gridSubMod.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridSubMod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSubMod.Size = new System.Drawing.Size(201, 125);
            this.gridSubMod.TabIndex = 0;
            this.gridSubMod.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSubMod_CellDoubleClick);
            this.gridSubMod.SelectionChanged += new System.EventHandler(this.gridSubMod_SelectionChanged);
            this.gridSubMod.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridSubMod_RowStateChanged);
            // 
            // btnSubIns
            // 
            this.btnSubIns.Enabled = false;
            this.btnSubIns.Location = new System.Drawing.Point(21, 141);
            this.btnSubIns.Name = "btnSubIns";
            this.btnSubIns.Size = new System.Drawing.Size(60, 25);
            this.btnSubIns.TabIndex = 1;
            this.btnSubIns.Text = "Inserir";
            this.btnSubIns.UseVisualStyleBackColor = true;
            this.btnSubIns.Click += new System.EventHandler(this.btnSubIns_Click);
            // 
            // btnSubEditar
            // 
            this.btnSubEditar.Enabled = false;
            this.btnSubEditar.Location = new System.Drawing.Point(84, 141);
            this.btnSubEditar.Name = "btnSubEditar";
            this.btnSubEditar.Size = new System.Drawing.Size(60, 25);
            this.btnSubEditar.TabIndex = 2;
            this.btnSubEditar.Text = "Editar";
            this.btnSubEditar.UseVisualStyleBackColor = true;
            this.btnSubEditar.Click += new System.EventHandler(this.btnSubEditar_Click);
            // 
            // btnSubExc
            // 
            this.btnSubExc.Enabled = false;
            this.btnSubExc.Location = new System.Drawing.Point(147, 141);
            this.btnSubExc.Name = "btnSubExc";
            this.btnSubExc.Size = new System.Drawing.Size(60, 25);
            this.btnSubExc.TabIndex = 3;
            this.btnSubExc.Text = "Excluir";
            this.btnSubExc.UseVisualStyleBackColor = true;
            this.btnSubExc.Click += new System.EventHandler(this.btnSubExc_Click);
            // 
            // gpoRotina
            // 
            this.gpoRotina.Controls.Add(this.gridRot);
            this.gpoRotina.Controls.Add(this.btnRotIns);
            this.gpoRotina.Controls.Add(this.btnRotExc);
            this.gpoRotina.Controls.Add(this.btnRotEditar);
            this.gpoRotina.Location = new System.Drawing.Point(8, 179);
            this.gpoRotina.Name = "gpoRotina";
            this.gpoRotina.Size = new System.Drawing.Size(705, 205);
            this.gpoRotina.TabIndex = 3;
            this.gpoRotina.TabStop = false;
            this.gpoRotina.Text = "Rotinas";
            // 
            // gridRot
            // 
            this.gridRot.AllowUserToAddRows = false;
            this.gridRot.AllowUserToDeleteRows = false;
            this.gridRot.AllowUserToResizeColumns = false;
            this.gridRot.AllowUserToResizeRows = false;
            this.gridRot.BackgroundColor = System.Drawing.Color.White;
            this.gridRot.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRot.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridRot.ColumnHeadersHeight = 17;
            this.gridRot.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridRot.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAcaoCod,
            this.colAcaoDesc,
            this.colAcaoSeg,
            this.colAcaoMod,
            this.colAcaoProg});
            this.gridRot.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRot.EnableHeadersVisualStyles = false;
            this.gridRot.Location = new System.Drawing.Point(6, 14);
            this.gridRot.MultiSelect = false;
            this.gridRot.Name = "gridRot";
            this.gridRot.ReadOnly = true;
            this.gridRot.RowHeadersVisible = false;
            this.gridRot.RowTemplate.Height = 18;
            this.gridRot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridRot.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRot.Size = new System.Drawing.Size(693, 154);
            this.gridRot.TabIndex = 0;
            this.gridRot.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridAcao_CellDoubleClick);
            this.gridRot.SelectionChanged += new System.EventHandler(this.gridAcao_SelectionChanged);
            this.gridRot.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridAcao_RowStateChanged);
            // 
            // colAcaoCod
            // 
            this.colAcaoCod.HeaderText = "Código";
            this.colAcaoCod.MaxInputLength = 6;
            this.colAcaoCod.Name = "colAcaoCod";
            this.colAcaoCod.ReadOnly = true;
            this.colAcaoCod.Width = 50;
            // 
            // colAcaoDesc
            // 
            this.colAcaoDesc.HeaderText = "Descrição da Ação";
            this.colAcaoDesc.MaxInputLength = 30;
            this.colAcaoDesc.Name = "colAcaoDesc";
            this.colAcaoDesc.ReadOnly = true;
            this.colAcaoDesc.Width = 132;
            // 
            // colAcaoSeg
            // 
            this.colAcaoSeg.HeaderText = "Nível Segurança";
            this.colAcaoSeg.MaxInputLength = 6;
            this.colAcaoSeg.Name = "colAcaoSeg";
            this.colAcaoSeg.ReadOnly = true;
            // 
            // colAcaoMod
            // 
            this.colAcaoMod.HeaderText = "Módulo";
            this.colAcaoMod.MaxInputLength = 50;
            this.colAcaoMod.Name = "colAcaoMod";
            this.colAcaoMod.ReadOnly = true;
            this.colAcaoMod.Width = 110;
            // 
            // colAcaoProg
            // 
            this.colAcaoProg.HeaderText = "Programa";
            this.colAcaoProg.MaxInputLength = 50;
            this.colAcaoProg.Name = "colAcaoProg";
            this.colAcaoProg.ReadOnly = true;
            this.colAcaoProg.Width = 110;
            // 
            // btnRotIns
            // 
            this.btnRotIns.Enabled = false;
            this.btnRotIns.Location = new System.Drawing.Point(513, 174);
            this.btnRotIns.Name = "btnRotIns";
            this.btnRotIns.Size = new System.Drawing.Size(60, 25);
            this.btnRotIns.TabIndex = 1;
            this.btnRotIns.Text = "Inserir";
            this.btnRotIns.UseVisualStyleBackColor = true;
            this.btnRotIns.Click += new System.EventHandler(this.btnAcaoIns_Click);
            // 
            // btnRotExc
            // 
            this.btnRotExc.Enabled = false;
            this.btnRotExc.Location = new System.Drawing.Point(639, 174);
            this.btnRotExc.Name = "btnRotExc";
            this.btnRotExc.Size = new System.Drawing.Size(60, 25);
            this.btnRotExc.TabIndex = 3;
            this.btnRotExc.Text = "Excluir";
            this.btnRotExc.UseVisualStyleBackColor = true;
            this.btnRotExc.Click += new System.EventHandler(this.btnAcaoExc_Click);
            // 
            // btnRotEditar
            // 
            this.btnRotEditar.Enabled = false;
            this.btnRotEditar.Location = new System.Drawing.Point(576, 174);
            this.btnRotEditar.Name = "btnRotEditar";
            this.btnRotEditar.Size = new System.Drawing.Size(60, 25);
            this.btnRotEditar.TabIndex = 2;
            this.btnRotEditar.Text = "Editar";
            this.btnRotEditar.UseVisualStyleBackColor = true;
            this.btnRotEditar.Click += new System.EventHandler(this.btnAcaoEditar_Click);
            // 
            // gpoPrograma
            // 
            this.gpoPrograma.Controls.Add(this.gridProg);
            this.gpoPrograma.Controls.Add(this.btnProgIns);
            this.gpoPrograma.Controls.Add(this.btnProgExc);
            this.gpoPrograma.Controls.Add(this.btnProgEditar);
            this.gpoPrograma.Location = new System.Drawing.Point(446, 7);
            this.gpoPrograma.Name = "gpoPrograma";
            this.gpoPrograma.Size = new System.Drawing.Size(267, 171);
            this.gpoPrograma.TabIndex = 2;
            this.gpoPrograma.TabStop = false;
            this.gpoPrograma.Text = "Programas";
            // 
            // gridProg
            // 
            this.gridProg.AllowUserToAddRows = false;
            this.gridProg.AllowUserToDeleteRows = false;
            this.gridProg.AllowUserToResizeColumns = false;
            this.gridProg.AllowUserToResizeRows = false;
            this.gridProg.BackgroundColor = System.Drawing.Color.White;
            this.gridProg.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridProg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridProg.ColumnHeadersHeight = 17;
            this.gridProg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridProg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridProg.EnableHeadersVisualStyles = false;
            this.gridProg.Location = new System.Drawing.Point(6, 13);
            this.gridProg.MultiSelect = false;
            this.gridProg.Name = "gridProg";
            this.gridProg.ReadOnly = true;
            this.gridProg.RowHeadersVisible = false;
            this.gridProg.RowTemplate.Height = 18;
            this.gridProg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridProg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridProg.Size = new System.Drawing.Size(255, 125);
            this.gridProg.TabIndex = 0;
            this.gridProg.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridProg_CellDoubleClick);
            this.gridProg.SelectionChanged += new System.EventHandler(this.gridProg_SelectionChanged);
            this.gridProg.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridProg_RowStateChanged);
            // 
            // btnProgIns
            // 
            this.btnProgIns.Enabled = false;
            this.btnProgIns.Location = new System.Drawing.Point(75, 141);
            this.btnProgIns.Name = "btnProgIns";
            this.btnProgIns.Size = new System.Drawing.Size(60, 25);
            this.btnProgIns.TabIndex = 1;
            this.btnProgIns.Text = "Inserir";
            this.btnProgIns.UseVisualStyleBackColor = true;
            this.btnProgIns.Click += new System.EventHandler(this.btnProgIns_Click);
            // 
            // btnProgExc
            // 
            this.btnProgExc.Enabled = false;
            this.btnProgExc.Location = new System.Drawing.Point(201, 141);
            this.btnProgExc.Name = "btnProgExc";
            this.btnProgExc.Size = new System.Drawing.Size(60, 25);
            this.btnProgExc.TabIndex = 3;
            this.btnProgExc.Text = "Excluir";
            this.btnProgExc.UseVisualStyleBackColor = true;
            this.btnProgExc.Click += new System.EventHandler(this.btnProgExc_Click);
            // 
            // btnProgEditar
            // 
            this.btnProgEditar.Enabled = false;
            this.btnProgEditar.Location = new System.Drawing.Point(138, 141);
            this.btnProgEditar.Name = "btnProgEditar";
            this.btnProgEditar.Size = new System.Drawing.Size(60, 25);
            this.btnProgEditar.TabIndex = 2;
            this.btnProgEditar.Text = "Editar";
            this.btnProgEditar.UseVisualStyleBackColor = true;
            this.btnProgEditar.Click += new System.EventHandler(this.btnProgEditar_Click);
            // 
            // gpoModulo
            // 
            this.gpoModulo.Controls.Add(this.gridModulo);
            this.gpoModulo.Controls.Add(this.btnModIns);
            this.gpoModulo.Controls.Add(this.btnModEditar);
            this.gpoModulo.Controls.Add(this.btnModExc);
            this.gpoModulo.Location = new System.Drawing.Point(8, 7);
            this.gpoModulo.Name = "gpoModulo";
            this.gpoModulo.Size = new System.Drawing.Size(213, 171);
            this.gpoModulo.TabIndex = 0;
            this.gpoModulo.TabStop = false;
            this.gpoModulo.Text = "Módulos";
            // 
            // gridModulo
            // 
            this.gridModulo.AllowUserToAddRows = false;
            this.gridModulo.AllowUserToDeleteRows = false;
            this.gridModulo.AllowUserToResizeColumns = false;
            this.gridModulo.AllowUserToResizeRows = false;
            this.gridModulo.BackgroundColor = System.Drawing.Color.White;
            this.gridModulo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridModulo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridModulo.ColumnHeadersHeight = 17;
            this.gridModulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridModulo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridModulo.EnableHeadersVisualStyles = false;
            this.gridModulo.Location = new System.Drawing.Point(6, 13);
            this.gridModulo.MultiSelect = false;
            this.gridModulo.Name = "gridModulo";
            this.gridModulo.ReadOnly = true;
            this.gridModulo.RowHeadersVisible = false;
            this.gridModulo.RowTemplate.Height = 18;
            this.gridModulo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridModulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridModulo.Size = new System.Drawing.Size(201, 125);
            this.gridModulo.TabIndex = 0;
            this.gridModulo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridModulo_CellDoubleClick);
            this.gridModulo.SelectionChanged += new System.EventHandler(this.gridModulo_SelectionChanged);
            this.gridModulo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridModulo_RowStateChanged);
            // 
            // btnModIns
            // 
            this.btnModIns.Enabled = false;
            this.btnModIns.Location = new System.Drawing.Point(21, 141);
            this.btnModIns.Name = "btnModIns";
            this.btnModIns.Size = new System.Drawing.Size(60, 25);
            this.btnModIns.TabIndex = 1;
            this.btnModIns.Text = "Inserir";
            this.btnModIns.UseVisualStyleBackColor = true;
            this.btnModIns.Click += new System.EventHandler(this.btnModIns_Click);
            // 
            // btnModEditar
            // 
            this.btnModEditar.Enabled = false;
            this.btnModEditar.Location = new System.Drawing.Point(84, 141);
            this.btnModEditar.Name = "btnModEditar";
            this.btnModEditar.Size = new System.Drawing.Size(60, 25);
            this.btnModEditar.TabIndex = 2;
            this.btnModEditar.Text = "Editar";
            this.btnModEditar.UseVisualStyleBackColor = true;
            this.btnModEditar.Click += new System.EventHandler(this.btnModEditar_Click);
            // 
            // btnModExc
            // 
            this.btnModExc.Enabled = false;
            this.btnModExc.Location = new System.Drawing.Point(147, 141);
            this.btnModExc.Name = "btnModExc";
            this.btnModExc.Size = new System.Drawing.Size(60, 25);
            this.btnModExc.TabIndex = 3;
            this.btnModExc.Text = "Excluir";
            this.btnModExc.UseVisualStyleBackColor = true;
            this.btnModExc.Click += new System.EventHandler(this.btnModExc_Click);
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(5, 403);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(75, 25);
            this.btnCarregar.TabIndex = 1;
            this.btnCarregar.Text = "Carregar";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // frmModProg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(732, 440);
            this.Controls.Add(this.btnCarregar);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlMod);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmModProg";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Módulos e Programas";
            this.Load += new System.EventHandler(this.frmModProg_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmModProg_FormClosed);
            this.pnlMod.ResumeLayout(false);
            this.gpoSubMod.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSubMod)).EndInit();
            this.gpoRotina.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRot)).EndInit();
            this.gpoPrograma.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridProg)).EndInit();
            this.gpoModulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridModulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.DataGridViewTextBoxColumn colAcaoCod;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colAcaoDesc;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colAcaoSeg;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colAcaoMod;
        internal System.Windows.Forms.DataGridViewTextBoxColumn colAcaoProg;
        private System.Windows.Forms.GroupBox gpoRotina;
        private System.Windows.Forms.DataGridView gridRot;
        private System.Windows.Forms.Button btnRotIns;
        private System.Windows.Forms.Button btnRotExc;
        private System.Windows.Forms.Button btnRotEditar;
        private System.Windows.Forms.GroupBox gpoPrograma;
        private System.Windows.Forms.DataGridView gridProg;
        private System.Windows.Forms.Button btnProgIns;
        private System.Windows.Forms.Button btnProgExc;
        private System.Windows.Forms.Button btnProgEditar;
        private System.Windows.Forms.GroupBox gpoModulo;
        private System.Windows.Forms.GroupBox gpoSubMod;
        private System.Windows.Forms.DataGridView gridSubMod;
        private System.Windows.Forms.Button btnSubIns;
        private System.Windows.Forms.Button btnSubEditar;
        private System.Windows.Forms.Button btnSubExc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlMod;
        private System.Windows.Forms.DataGridView gridModulo;
        private System.Windows.Forms.Button btnModIns;
        private System.Windows.Forms.Button btnModEditar;
        private System.Windows.Forms.Button btnModExc;
        private System.Windows.Forms.Button btnCarregar;
    }
}