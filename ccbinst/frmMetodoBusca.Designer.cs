namespace ccbinst
{
    partial class frmMetodoBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMetodoBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipMetodo = new System.Windows.Forms.ToolTip(this.components);
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
            this.btnTipoVisual = new System.Windows.Forms.Button();
            this.btnTipoIns = new System.Windows.Forms.Button();
            this.btnTipoEditar = new System.Windows.Forms.Button();
            this.btnTipoExc = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.cboTipo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.tabMetodo = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabTipo = new System.Windows.Forms.TabPage();
            this.gridTipo = new System.Windows.Forms.DataGridView();
            this.lblInstrumento = new System.Windows.Forms.Label();
            this.pctInstrumento = new System.Windows.Forms.PictureBox();
            this.imgMetodo = new System.Windows.Forms.ImageList(this.components);
            this.lblSolfejo = new System.Windows.Forms.Label();
            this.pctSolfejo = new System.Windows.Forms.PictureBox();
            this.tabMetodo.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTipo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInstrumento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSolfejo)).BeginInit();
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
            this.tipMetodo.SetToolTip(this.txtDesc, "Nome para pesquisar");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // btnDescVisual
            // 
            this.btnDescVisual.AccessibleDescription = "";
            this.btnDescVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescVisual.Enabled = false;
            this.btnDescVisual.Location = new System.Drawing.Point(334, 360);
            this.btnDescVisual.Name = "btnDescVisual";
            this.btnDescVisual.Size = new System.Drawing.Size(90, 30);
            this.btnDescVisual.TabIndex = 3;
            this.btnDescVisual.Text = "&Visualizar";
            this.tipMetodo.SetToolTip(this.btnDescVisual, "Visualizar");
            this.btnDescVisual.UseVisualStyleBackColor = true;
            this.btnDescVisual.Click += new System.EventHandler(this.btnDescVisual_Click);
            // 
            // btnDescIns
            // 
            this.btnDescIns.AccessibleDescription = "";
            this.btnDescIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescIns.Enabled = false;
            this.btnDescIns.Location = new System.Drawing.Point(428, 360);
            this.btnDescIns.Name = "btnDescIns";
            this.btnDescIns.Size = new System.Drawing.Size(90, 30);
            this.btnDescIns.TabIndex = 4;
            this.btnDescIns.Text = "&Inserir";
            this.tipMetodo.SetToolTip(this.btnDescIns, "Inserir");
            this.btnDescIns.UseVisualStyleBackColor = true;
            this.btnDescIns.Click += new System.EventHandler(this.btnDescIns_Click);
            // 
            // btnDescEditar
            // 
            this.btnDescEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescEditar.Enabled = false;
            this.btnDescEditar.Location = new System.Drawing.Point(522, 360);
            this.btnDescEditar.Name = "btnDescEditar";
            this.btnDescEditar.Size = new System.Drawing.Size(90, 30);
            this.btnDescEditar.TabIndex = 5;
            this.btnDescEditar.Text = "&Editar";
            this.tipMetodo.SetToolTip(this.btnDescEditar, "Editar");
            this.btnDescEditar.UseVisualStyleBackColor = true;
            this.btnDescEditar.Click += new System.EventHandler(this.btnDescEditar_Click);
            // 
            // btnDescExc
            // 
            this.btnDescExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescExc.Enabled = false;
            this.btnDescExc.Location = new System.Drawing.Point(616, 360);
            this.btnDescExc.Name = "btnDescExc";
            this.btnDescExc.Size = new System.Drawing.Size(90, 30);
            this.btnDescExc.TabIndex = 6;
            this.btnDescExc.Text = "E&xcluir";
            this.tipMetodo.SetToolTip(this.btnDescExc, "Excluir");
            this.btnDescExc.UseVisualStyleBackColor = true;
            this.btnDescExc.Click += new System.EventHandler(this.btnDescExc_Click);
            // 
            // btnDesc
            // 
            this.btnDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnDesc.Image")));
            this.btnDesc.Location = new System.Drawing.Point(159, 6);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(23, 23);
            this.btnDesc.TabIndex = 1;
            this.tipMetodo.SetToolTip(this.btnDesc, "Pesquisar");
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
            this.tipMetodo.SetToolTip(this.txtCodigo, "Código para pesquisar");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnCodVisual
            // 
            this.btnCodVisual.AccessibleDescription = "";
            this.btnCodVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodVisual.Enabled = false;
            this.btnCodVisual.Location = new System.Drawing.Point(334, 360);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 3;
            this.btnCodVisual.Text = "&Visualizar";
            this.tipMetodo.SetToolTip(this.btnCodVisual, "Visualizar");
            this.btnCodVisual.UseVisualStyleBackColor = true;
            this.btnCodVisual.Click += new System.EventHandler(this.btnCodVisual_Click);
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(428, 360);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 4;
            this.btnCodIns.Text = "&Inserir";
            this.tipMetodo.SetToolTip(this.btnCodIns, "Inserir");
            this.btnCodIns.UseVisualStyleBackColor = true;
            this.btnCodIns.Click += new System.EventHandler(this.btnCodIns_Click);
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(522, 360);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 5;
            this.btnCodEditar.Text = "&Editar";
            this.tipMetodo.SetToolTip(this.btnCodEditar, "Editar");
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCodExc
            // 
            this.btnCodExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodExc.Enabled = false;
            this.btnCodExc.Location = new System.Drawing.Point(616, 360);
            this.btnCodExc.Name = "btnCodExc";
            this.btnCodExc.Size = new System.Drawing.Size(90, 30);
            this.btnCodExc.TabIndex = 6;
            this.btnCodExc.Text = "E&xcluir";
            this.tipMetodo.SetToolTip(this.btnCodExc, "Excluir");
            this.btnCodExc.UseVisualStyleBackColor = true;
            this.btnCodExc.Click += new System.EventHandler(this.btnCodExc_Click);
            // 
            // btnCod
            // 
            this.btnCod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCod.Image = ((System.Drawing.Image)(resources.GetObject("btnCod.Image")));
            this.btnCod.Location = new System.Drawing.Point(159, 6);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(23, 23);
            this.btnCod.TabIndex = 1;
            this.tipMetodo.SetToolTip(this.btnCod, "Pesquisar");
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
            // 
            // btnTipoVisual
            // 
            this.btnTipoVisual.AccessibleDescription = "";
            this.btnTipoVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTipoVisual.Enabled = false;
            this.btnTipoVisual.Location = new System.Drawing.Point(334, 360);
            this.btnTipoVisual.Name = "btnTipoVisual";
            this.btnTipoVisual.Size = new System.Drawing.Size(90, 30);
            this.btnTipoVisual.TabIndex = 3;
            this.btnTipoVisual.Text = "&Visualizar";
            this.tipMetodo.SetToolTip(this.btnTipoVisual, "Visualizar");
            this.btnTipoVisual.UseVisualStyleBackColor = true;
            this.btnTipoVisual.Click += new System.EventHandler(this.btnTipoVisual_Click);
            // 
            // btnTipoIns
            // 
            this.btnTipoIns.AccessibleDescription = "";
            this.btnTipoIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTipoIns.Enabled = false;
            this.btnTipoIns.Location = new System.Drawing.Point(428, 360);
            this.btnTipoIns.Name = "btnTipoIns";
            this.btnTipoIns.Size = new System.Drawing.Size(90, 30);
            this.btnTipoIns.TabIndex = 4;
            this.btnTipoIns.Text = "&Inserir";
            this.tipMetodo.SetToolTip(this.btnTipoIns, "Inserir");
            this.btnTipoIns.UseVisualStyleBackColor = true;
            this.btnTipoIns.Click += new System.EventHandler(this.btnTipoIns_Click);
            // 
            // btnTipoEditar
            // 
            this.btnTipoEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTipoEditar.Enabled = false;
            this.btnTipoEditar.Location = new System.Drawing.Point(522, 360);
            this.btnTipoEditar.Name = "btnTipoEditar";
            this.btnTipoEditar.Size = new System.Drawing.Size(90, 30);
            this.btnTipoEditar.TabIndex = 5;
            this.btnTipoEditar.Text = "&Editar";
            this.tipMetodo.SetToolTip(this.btnTipoEditar, "Editar");
            this.btnTipoEditar.UseVisualStyleBackColor = true;
            this.btnTipoEditar.Click += new System.EventHandler(this.btnTipoEditar_Click);
            // 
            // btnTipoExc
            // 
            this.btnTipoExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnTipoExc.Enabled = false;
            this.btnTipoExc.Location = new System.Drawing.Point(616, 360);
            this.btnTipoExc.Name = "btnTipoExc";
            this.btnTipoExc.Size = new System.Drawing.Size(90, 30);
            this.btnTipoExc.TabIndex = 6;
            this.btnTipoExc.Text = "E&xcluir";
            this.tipMetodo.SetToolTip(this.btnTipoExc, "Excluir");
            this.btnTipoExc.UseVisualStyleBackColor = true;
            this.btnTipoExc.Click += new System.EventHandler(this.btnTipoExc_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(641, 441);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipMetodo.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Solfejo",
            "Instrumento"});
            this.cboTipo.Location = new System.Drawing.Point(6, 7);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(150, 21);
            this.cboTipo.TabIndex = 7;
            this.tipMetodo.SetToolTip(this.cboTipo, "Selecione o tipo para pesquisar");
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // tabMetodo
            // 
            this.tabMetodo.Controls.Add(this.tabDesc);
            this.tabMetodo.Controls.Add(this.tabCodigo);
            this.tabMetodo.Controls.Add(this.tabTipo);
            this.tabMetodo.Location = new System.Drawing.Point(9, 9);
            this.tabMetodo.Name = "tabMetodo";
            this.tabMetodo.SelectedIndex = 0;
            this.tabMetodo.Size = new System.Drawing.Size(722, 426);
            this.tabMetodo.TabIndex = 31;
            this.tabMetodo.SelectedIndexChanged += new System.EventHandler(this.tabMetodo_SelectedIndexChanged);
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
            this.tabDesc.Size = new System.Drawing.Size(714, 400);
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
            this.gridDesc.Size = new System.Drawing.Size(700, 318);
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
            this.tabCodigo.Size = new System.Drawing.Size(714, 400);
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
            this.gridCodigo.Size = new System.Drawing.Size(700, 318);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // tabTipo
            // 
            this.tabTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabTipo.Controls.Add(this.cboTipo);
            this.tabTipo.Controls.Add(this.gridTipo);
            this.tabTipo.Controls.Add(this.btnTipoVisual);
            this.tabTipo.Controls.Add(this.btnTipoIns);
            this.tabTipo.Controls.Add(this.btnTipoEditar);
            this.tabTipo.Controls.Add(this.btnTipoExc);
            this.tabTipo.Location = new System.Drawing.Point(4, 22);
            this.tabTipo.Name = "tabTipo";
            this.tabTipo.Padding = new System.Windows.Forms.Padding(3);
            this.tabTipo.Size = new System.Drawing.Size(714, 400);
            this.tabTipo.TabIndex = 2;
            this.tabTipo.Text = "Tipo";
            // 
            // gridTipo
            // 
            this.gridTipo.AllowUserToAddRows = false;
            this.gridTipo.AllowUserToDeleteRows = false;
            this.gridTipo.AllowUserToResizeRows = false;
            this.gridTipo.BackgroundColor = System.Drawing.Color.White;
            this.gridTipo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridTipo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridTipo.ColumnHeadersHeight = 17;
            this.gridTipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridTipo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridTipo.EnableHeadersVisualStyles = false;
            this.gridTipo.Location = new System.Drawing.Point(6, 36);
            this.gridTipo.MultiSelect = false;
            this.gridTipo.Name = "gridTipo";
            this.gridTipo.ReadOnly = true;
            this.gridTipo.RowHeadersVisible = false;
            this.gridTipo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridTipo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTipo.Size = new System.Drawing.Size(700, 318);
            this.gridTipo.TabIndex = 2;
            this.gridTipo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTipo_CellDoubleClick);
            this.gridTipo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.GridTipo_RowStateChanged);
            this.gridTipo.SelectionChanged += new System.EventHandler(this.gridTipo_SelectionChanged);
            // 
            // lblInstrumento
            // 
            this.lblInstrumento.AutoSize = true;
            this.lblInstrumento.Location = new System.Drawing.Point(132, 450);
            this.lblInstrumento.Name = "lblInstrumento";
            this.lblInstrumento.Size = new System.Drawing.Size(115, 13);
            this.lblInstrumento.TabIndex = 38;
            this.lblInstrumento.Text = "Execução Instrumento";
            // 
            // pctInstrumento
            // 
            this.pctInstrumento.Location = new System.Drawing.Point(115, 446);
            this.pctInstrumento.Name = "pctInstrumento";
            this.pctInstrumento.Size = new System.Drawing.Size(16, 20);
            this.pctInstrumento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctInstrumento.TabIndex = 37;
            this.pctInstrumento.TabStop = false;
            // 
            // imgMetodo
            // 
            this.imgMetodo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMetodo.ImageStream")));
            this.imgMetodo.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMetodo.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgMetodo.Images.SetKeyName(1, "BolaAmarela.ico");
            this.imgMetodo.Images.SetKeyName(2, "BolaAzul.ico");
            this.imgMetodo.Images.SetKeyName(3, "BolaVermelha.ico");
            // 
            // lblSolfejo
            // 
            this.lblSolfejo.AutoSize = true;
            this.lblSolfejo.Location = new System.Drawing.Point(26, 450);
            this.lblSolfejo.Name = "lblSolfejo";
            this.lblSolfejo.Size = new System.Drawing.Size(79, 13);
            this.lblSolfejo.TabIndex = 44;
            this.lblSolfejo.Text = "Solfejo e Ritmo";
            // 
            // pctSolfejo
            // 
            this.pctSolfejo.Location = new System.Drawing.Point(9, 446);
            this.pctSolfejo.Name = "pctSolfejo";
            this.pctSolfejo.Size = new System.Drawing.Size(16, 20);
            this.pctSolfejo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctSolfejo.TabIndex = 43;
            this.pctSolfejo.TabStop = false;
            // 
            // frmMetodoBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(739, 479);
            this.Controls.Add(this.lblSolfejo);
            this.Controls.Add(this.pctSolfejo);
            this.Controls.Add(this.lblInstrumento);
            this.Controls.Add(this.pctInstrumento);
            this.Controls.Add(this.tabMetodo);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMetodoBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Métodos";
            this.Load += new System.EventHandler(this.frmMetodoBusca_Load);
            this.tabMetodo.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabTipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTipo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInstrumento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSolfejo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipMetodo;
        private BLL.validacoes.Controles.tabControlPersonal tabMetodo;
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
        private System.Windows.Forms.TabPage tabTipo;
        private System.Windows.Forms.DataGridView gridTipo;
        private System.Windows.Forms.Button btnTipoVisual;
        private System.Windows.Forms.Button btnTipoIns;
        private System.Windows.Forms.Button btnTipoEditar;
        private System.Windows.Forms.Button btnTipoExc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblInstrumento;
        private System.Windows.Forms.PictureBox pctInstrumento;
        private System.Windows.Forms.ImageList imgMetodo;
        private System.Windows.Forms.Label lblSolfejo;
        private System.Windows.Forms.PictureBox pctSolfejo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTipo;
    }
}