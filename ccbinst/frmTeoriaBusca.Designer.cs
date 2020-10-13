namespace ccbinst
{
    partial class frmTeoriaBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeoriaBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipRegiao = new System.Windows.Forms.ToolTip(this.components);
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnDescVisual = new System.Windows.Forms.Button();
            this.btnDescIns = new System.Windows.Forms.Button();
            this.btnDescEditar = new System.Windows.Forms.Button();
            this.btnDescExc = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCodVisual = new System.Windows.Forms.Button();
            this.btnCodIns = new System.Windows.Forms.Button();
            this.btnCodEditar = new System.Windows.Forms.Button();
            this.btnCodExc = new System.Windows.Forms.Button();
            this.btnCod = new System.Windows.Forms.Button();
            this.btnRefVisual = new System.Windows.Forms.Button();
            this.btnRefIns = new System.Windows.Forms.Button();
            this.btnRefEditar = new System.Windows.Forms.Button();
            this.btnRefExc = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.tabTeoria = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabRef = new System.Windows.Forms.TabPage();
            this.gridRef = new System.Windows.Forms.DataGridView();
            this.lblCulto = new System.Windows.Forms.Label();
            this.pctCulto = new System.Windows.Forms.PictureBox();
            this.lblRjm = new System.Windows.Forms.Label();
            this.pctRjm = new System.Windows.Forms.PictureBox();
            this.imgTeoria = new System.Windows.Forms.ImageList(this.components);
            this.lblOficial = new System.Windows.Forms.Label();
            this.pctOficial = new System.Windows.Forms.PictureBox();
            this.lblGem = new System.Windows.Forms.Label();
            this.pctGem = new System.Windows.Forms.PictureBox();
            this.tabTeoria.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabRef.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCulto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRjm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOficial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctGem)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.LightYellow;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(6, 7);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(150, 21);
            this.txtDesc.TabIndex = 0;
            this.tipRegiao.SetToolTip(this.txtDesc, "Nome para pesquisar");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // btnDescVisual
            // 
            this.btnDescVisual.AccessibleDescription = "";
            this.btnDescVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescVisual.Enabled = false;
            this.btnDescVisual.Location = new System.Drawing.Point(365, 354);
            this.btnDescVisual.Name = "btnDescVisual";
            this.btnDescVisual.Size = new System.Drawing.Size(90, 30);
            this.btnDescVisual.TabIndex = 3;
            this.btnDescVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnDescVisual, "Visualizar");
            this.btnDescVisual.UseVisualStyleBackColor = true;
            this.btnDescVisual.Click += new System.EventHandler(this.btnDescVisual_Click);
            // 
            // btnDescIns
            // 
            this.btnDescIns.AccessibleDescription = "";
            this.btnDescIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescIns.Enabled = false;
            this.btnDescIns.Location = new System.Drawing.Point(459, 354);
            this.btnDescIns.Name = "btnDescIns";
            this.btnDescIns.Size = new System.Drawing.Size(90, 30);
            this.btnDescIns.TabIndex = 4;
            this.btnDescIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnDescIns, "Inserir");
            this.btnDescIns.UseVisualStyleBackColor = true;
            this.btnDescIns.Click += new System.EventHandler(this.btnDescIns_Click);
            // 
            // btnDescEditar
            // 
            this.btnDescEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescEditar.Enabled = false;
            this.btnDescEditar.Location = new System.Drawing.Point(553, 354);
            this.btnDescEditar.Name = "btnDescEditar";
            this.btnDescEditar.Size = new System.Drawing.Size(90, 30);
            this.btnDescEditar.TabIndex = 5;
            this.btnDescEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnDescEditar, "Editar");
            this.btnDescEditar.UseVisualStyleBackColor = true;
            this.btnDescEditar.Click += new System.EventHandler(this.btnDescEditar_Click);
            // 
            // btnDescExc
            // 
            this.btnDescExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescExc.Enabled = false;
            this.btnDescExc.Location = new System.Drawing.Point(647, 354);
            this.btnDescExc.Name = "btnDescExc";
            this.btnDescExc.Size = new System.Drawing.Size(90, 30);
            this.btnDescExc.TabIndex = 6;
            this.btnDescExc.Text = "E&xcluir";
            this.tipRegiao.SetToolTip(this.btnDescExc, "Excluir");
            this.btnDescExc.UseVisualStyleBackColor = true;
            this.btnDescExc.Click += new System.EventHandler(this.btnDescExc_Click);
            // 
            // btnDesc
            // 
            this.btnDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnDesc.Image")));
            this.btnDesc.Location = new System.Drawing.Point(159, 7);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(24, 24);
            this.btnDesc.TabIndex = 1;
            this.tipRegiao.SetToolTip(this.btnDesc, "Pesquisar");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Location = new System.Drawing.Point(6, 7);
            this.txtCodigo.MaxLength = 100;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 21);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipRegiao.SetToolTip(this.txtCodigo, "Código para pesquisar");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnCodVisual
            // 
            this.btnCodVisual.AccessibleDescription = "";
            this.btnCodVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodVisual.Enabled = false;
            this.btnCodVisual.Location = new System.Drawing.Point(365, 354);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 3;
            this.btnCodVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnCodVisual, "Visualizar");
            this.btnCodVisual.UseVisualStyleBackColor = true;
            this.btnCodVisual.Click += new System.EventHandler(this.btnCodVisual_Click);
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(459, 354);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 4;
            this.btnCodIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnCodIns, "Inserir");
            this.btnCodIns.UseVisualStyleBackColor = true;
            this.btnCodIns.Click += new System.EventHandler(this.btnCodIns_Click);
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(553, 354);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 5;
            this.btnCodEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnCodEditar, "Editar");
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCodExc
            // 
            this.btnCodExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodExc.Enabled = false;
            this.btnCodExc.Location = new System.Drawing.Point(647, 354);
            this.btnCodExc.Name = "btnCodExc";
            this.btnCodExc.Size = new System.Drawing.Size(90, 30);
            this.btnCodExc.TabIndex = 6;
            this.btnCodExc.Text = "E&xcluir";
            this.tipRegiao.SetToolTip(this.btnCodExc, "Excluir");
            this.btnCodExc.UseVisualStyleBackColor = true;
            this.btnCodExc.Click += new System.EventHandler(this.btnCodExc_Click);
            // 
            // btnCod
            // 
            this.btnCod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCod.Image = ((System.Drawing.Image)(resources.GetObject("btnCod.Image")));
            this.btnCod.Location = new System.Drawing.Point(159, 7);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(24, 24);
            this.btnCod.TabIndex = 1;
            this.tipRegiao.SetToolTip(this.btnCod, "Pesquisar");
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
            // 
            // btnRefVisual
            // 
            this.btnRefVisual.AccessibleDescription = "";
            this.btnRefVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefVisual.Enabled = false;
            this.btnRefVisual.Location = new System.Drawing.Point(365, 354);
            this.btnRefVisual.Name = "btnRefVisual";
            this.btnRefVisual.Size = new System.Drawing.Size(90, 30);
            this.btnRefVisual.TabIndex = 3;
            this.btnRefVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnRefVisual, "Visualizar");
            this.btnRefVisual.UseVisualStyleBackColor = true;
            this.btnRefVisual.Click += new System.EventHandler(this.btnRefVisual_Click);
            // 
            // btnRefIns
            // 
            this.btnRefIns.AccessibleDescription = "";
            this.btnRefIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefIns.Enabled = false;
            this.btnRefIns.Location = new System.Drawing.Point(459, 354);
            this.btnRefIns.Name = "btnRefIns";
            this.btnRefIns.Size = new System.Drawing.Size(90, 30);
            this.btnRefIns.TabIndex = 4;
            this.btnRefIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnRefIns, "Inserir");
            this.btnRefIns.UseVisualStyleBackColor = true;
            this.btnRefIns.Click += new System.EventHandler(this.btnRefIns_Click);
            // 
            // btnRefEditar
            // 
            this.btnRefEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefEditar.Enabled = false;
            this.btnRefEditar.Location = new System.Drawing.Point(553, 354);
            this.btnRefEditar.Name = "btnRefEditar";
            this.btnRefEditar.Size = new System.Drawing.Size(90, 30);
            this.btnRefEditar.TabIndex = 5;
            this.btnRefEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnRefEditar, "Editar");
            this.btnRefEditar.UseVisualStyleBackColor = true;
            this.btnRefEditar.Click += new System.EventHandler(this.btnRefEditar_Click);
            // 
            // btnRefExc
            // 
            this.btnRefExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefExc.Enabled = false;
            this.btnRefExc.Location = new System.Drawing.Point(647, 354);
            this.btnRefExc.Name = "btnRefExc";
            this.btnRefExc.Size = new System.Drawing.Size(90, 30);
            this.btnRefExc.TabIndex = 6;
            this.btnRefExc.Text = "E&xcluir";
            this.tipRegiao.SetToolTip(this.btnRefExc, "Excluir");
            this.btnRefExc.UseVisualStyleBackColor = true;
            this.btnRefExc.Click += new System.EventHandler(this.btnRefExc_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(673, 432);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // tabTeoria
            // 
            this.tabTeoria.Controls.Add(this.tabDesc);
            this.tabTeoria.Controls.Add(this.tabCodigo);
            this.tabTeoria.Controls.Add(this.tabRef);
            this.tabTeoria.Location = new System.Drawing.Point(9, 9);
            this.tabTeoria.Name = "tabTeoria";
            this.tabTeoria.SelectedIndex = 0;
            this.tabTeoria.Size = new System.Drawing.Size(754, 417);
            this.tabTeoria.TabIndex = 31;
            this.tabTeoria.SelectedIndexChanged += new System.EventHandler(this.tabTeoria_SelectedIndexChanged);
            // 
            // tabDesc
            // 
            this.tabDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDesc.Controls.Add(this.txtDesc);
            this.tabDesc.Controls.Add(this.gridDesc);
            this.tabDesc.Controls.Add(this.btnDescVisual);
            this.tabDesc.Controls.Add(this.btnDescIns);
            this.tabDesc.Controls.Add(this.btnDescEditar);
            this.tabDesc.Controls.Add(this.btnDescExc);
            this.tabDesc.Controls.Add(this.btnDesc);
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(746, 391);
            this.tabDesc.TabIndex = 1;
            this.tabDesc.Text = "Descrição";
            // 
            // gridDesc
            // 
            this.gridDesc.AllowUserToAddRows = false;
            this.gridDesc.AllowUserToDeleteRows = false;
            this.gridDesc.AllowUserToResizeRows = false;
            this.gridDesc.BackgroundColor = System.Drawing.Color.White;
            this.gridDesc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDesc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDesc.ColumnHeadersHeight = 17;
            this.gridDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDesc.EnableHeadersVisualStyles = false;
            this.gridDesc.Location = new System.Drawing.Point(6, 36);
            this.gridDesc.MultiSelect = false;
            this.gridDesc.Name = "gridDesc";
            this.gridDesc.ReadOnly = true;
            this.gridDesc.RowHeadersVisible = false;
            this.gridDesc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDesc.Size = new System.Drawing.Size(731, 312);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // tabCodigo
            // 
            this.tabCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCodigo.Controls.Add(this.txtCodigo);
            this.tabCodigo.Controls.Add(this.btnCodVisual);
            this.tabCodigo.Controls.Add(this.btnCodIns);
            this.tabCodigo.Controls.Add(this.btnCodEditar);
            this.tabCodigo.Controls.Add(this.btnCodExc);
            this.tabCodigo.Controls.Add(this.btnCod);
            this.tabCodigo.Controls.Add(this.gridCodigo);
            this.tabCodigo.Location = new System.Drawing.Point(4, 22);
            this.tabCodigo.Name = "tabCodigo";
            this.tabCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodigo.Size = new System.Drawing.Size(746, 391);
            this.tabCodigo.TabIndex = 0;
            this.tabCodigo.Text = "Código";
            // 
            // gridCodigo
            // 
            this.gridCodigo.AllowUserToAddRows = false;
            this.gridCodigo.AllowUserToDeleteRows = false;
            this.gridCodigo.AllowUserToResizeRows = false;
            this.gridCodigo.BackgroundColor = System.Drawing.Color.White;
            this.gridCodigo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCodigo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridCodigo.ColumnHeadersHeight = 17;
            this.gridCodigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCodigo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCodigo.EnableHeadersVisualStyles = false;
            this.gridCodigo.Location = new System.Drawing.Point(6, 36);
            this.gridCodigo.MultiSelect = false;
            this.gridCodigo.Name = "gridCodigo";
            this.gridCodigo.ReadOnly = true;
            this.gridCodigo.RowHeadersVisible = false;
            this.gridCodigo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCodigo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCodigo.Size = new System.Drawing.Size(731, 312);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // tabRef
            // 
            this.tabRef.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRef.Controls.Add(this.gridRef);
            this.tabRef.Controls.Add(this.btnRefVisual);
            this.tabRef.Controls.Add(this.btnRefIns);
            this.tabRef.Controls.Add(this.btnRefEditar);
            this.tabRef.Controls.Add(this.btnRefExc);
            this.tabRef.Location = new System.Drawing.Point(4, 22);
            this.tabRef.Name = "tabRef";
            this.tabRef.Padding = new System.Windows.Forms.Padding(3);
            this.tabRef.Size = new System.Drawing.Size(746, 391);
            this.tabRef.TabIndex = 2;
            this.tabRef.Text = "Referência";
            // 
            // gridRef
            // 
            this.gridRef.AllowUserToAddRows = false;
            this.gridRef.AllowUserToDeleteRows = false;
            this.gridRef.AllowUserToResizeRows = false;
            this.gridRef.BackgroundColor = System.Drawing.Color.White;
            this.gridRef.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRef.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridRef.ColumnHeadersHeight = 17;
            this.gridRef.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridRef.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRef.EnableHeadersVisualStyles = false;
            this.gridRef.Location = new System.Drawing.Point(6, 36);
            this.gridRef.MultiSelect = false;
            this.gridRef.Name = "gridRef";
            this.gridRef.ReadOnly = true;
            this.gridRef.RowHeadersVisible = false;
            this.gridRef.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRef.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRef.Size = new System.Drawing.Size(731, 312);
            this.gridRef.TabIndex = 2;
            this.gridRef.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRef_CellDoubleClick);
            this.gridRef.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridRef_RowStateChanged);
            this.gridRef.SelectionChanged += new System.EventHandler(this.gridRef_SelectionChanged);
            // 
            // lblCulto
            // 
            this.lblCulto.AutoSize = true;
            this.lblCulto.Location = new System.Drawing.Point(214, 438);
            this.lblCulto.Name = "lblCulto";
            this.lblCulto.Size = new System.Drawing.Size(64, 13);
            this.lblCulto.TabIndex = 40;
            this.lblCulto.Text = "Culto Oficial";
            // 
            // pctCulto
            // 
            this.pctCulto.Location = new System.Drawing.Point(198, 435);
            this.pctCulto.Name = "pctCulto";
            this.pctCulto.Size = new System.Drawing.Size(16, 20);
            this.pctCulto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctCulto.TabIndex = 39;
            this.pctCulto.TabStop = false;
            // 
            // lblRjm
            // 
            this.lblRjm.AutoSize = true;
            this.lblRjm.Location = new System.Drawing.Point(88, 438);
            this.lblRjm.Name = "lblRjm";
            this.lblRjm.Size = new System.Drawing.Size(83, 13);
            this.lblRjm.TabIndex = 38;
            this.lblRjm.Text = "Reunião Jovens";
            // 
            // pctRjm
            // 
            this.pctRjm.Location = new System.Drawing.Point(71, 435);
            this.pctRjm.Name = "pctRjm";
            this.pctRjm.Size = new System.Drawing.Size(16, 20);
            this.pctRjm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctRjm.TabIndex = 37;
            this.pctRjm.TabStop = false;
            // 
            // imgTeoria
            // 
            this.imgTeoria.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTeoria.ImageStream")));
            this.imgTeoria.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTeoria.Images.SetKeyName(0, "BolaVermelha.ico");
            this.imgTeoria.Images.SetKeyName(1, "BolaAmarela.ico");
            this.imgTeoria.Images.SetKeyName(2, "BolaVerde.ico");
            this.imgTeoria.Images.SetKeyName(3, "BolaAzul.ico");
            // 
            // lblOficial
            // 
            this.lblOficial.AutoSize = true;
            this.lblOficial.Location = new System.Drawing.Point(314, 438);
            this.lblOficial.Name = "lblOficial";
            this.lblOficial.Size = new System.Drawing.Size(66, 13);
            this.lblOficial.TabIndex = 42;
            this.lblOficial.Text = "Oficialização";
            // 
            // pctOficial
            // 
            this.pctOficial.Location = new System.Drawing.Point(298, 435);
            this.pctOficial.Name = "pctOficial";
            this.pctOficial.Size = new System.Drawing.Size(16, 20);
            this.pctOficial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctOficial.TabIndex = 41;
            this.pctOficial.TabStop = false;
            // 
            // lblGem
            // 
            this.lblGem.AutoSize = true;
            this.lblGem.Location = new System.Drawing.Point(28, 438);
            this.lblGem.Name = "lblGem";
            this.lblGem.Size = new System.Drawing.Size(28, 13);
            this.lblGem.TabIndex = 44;
            this.lblGem.Text = "GEM";
            // 
            // pctGem
            // 
            this.pctGem.Location = new System.Drawing.Point(11, 435);
            this.pctGem.Name = "pctGem";
            this.pctGem.Size = new System.Drawing.Size(16, 20);
            this.pctGem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctGem.TabIndex = 43;
            this.pctGem.TabStop = false;
            // 
            // frmTeoriaBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(770, 471);
            this.Controls.Add(this.lblGem);
            this.Controls.Add(this.pctGem);
            this.Controls.Add(this.lblOficial);
            this.Controls.Add(this.pctOficial);
            this.Controls.Add(this.lblCulto);
            this.Controls.Add(this.pctCulto);
            this.Controls.Add(this.lblRjm);
            this.Controls.Add(this.pctRjm);
            this.Controls.Add(this.tabTeoria);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTeoriaBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Avaliações e Atividades de Teoria";
            this.Load += new System.EventHandler(this.frmTeoriaBusca_Load);
            this.tabTeoria.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabRef.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCulto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRjm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOficial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctGem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private BLL.validacoes.Controles.tabControlPersonal tabTeoria;
        private System.Windows.Forms.TabPage tabDesc;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnDescVisual;
        private System.Windows.Forms.Button btnDescIns;
        private System.Windows.Forms.Button btnDescEditar;
        private System.Windows.Forms.Button btnDescExc;
        private System.Windows.Forms.Button btnDesc;
        private System.Windows.Forms.TabPage tabCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Button btnCodVisual;
        private System.Windows.Forms.Button btnCodIns;
        private System.Windows.Forms.Button btnCodEditar;
        private System.Windows.Forms.Button btnCodExc;
        private System.Windows.Forms.Button btnCod;
        private System.Windows.Forms.DataGridView gridCodigo;
        private System.Windows.Forms.TabPage tabRef;
        private System.Windows.Forms.DataGridView gridRef;
        private System.Windows.Forms.Button btnRefVisual;
        private System.Windows.Forms.Button btnRefIns;
        private System.Windows.Forms.Button btnRefEditar;
        private System.Windows.Forms.Button btnRefExc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblCulto;
        private System.Windows.Forms.PictureBox pctCulto;
        private System.Windows.Forms.Label lblRjm;
        private System.Windows.Forms.PictureBox pctRjm;
        private System.Windows.Forms.ImageList imgTeoria;
        private System.Windows.Forms.Label lblOficial;
        private System.Windows.Forms.PictureBox pctOficial;
        private System.Windows.Forms.Label lblGem;
        private System.Windows.Forms.PictureBox pctGem;
    }
}