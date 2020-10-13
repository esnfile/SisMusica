namespace ccbutil
{
    partial class frmRegionalBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegionalBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipRegiao = new System.Windows.Forms.ToolTip(this.components);
            this.txtNome = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnNomeVisual = new System.Windows.Forms.Button();
            this.btnNomeIns = new System.Windows.Forms.Button();
            this.btnNomeEditar = new System.Windows.Forms.Button();
            this.btnNomeExc = new System.Windows.Forms.Button();
            this.btnNome = new System.Windows.Forms.Button();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCodVisual = new System.Windows.Forms.Button();
            this.btnCodIns = new System.Windows.Forms.Button();
            this.btnCodEditar = new System.Windows.Forms.Button();
            this.btnCodExc = new System.Windows.Forms.Button();
            this.btnCod = new System.Windows.Forms.Button();
            this.btnEstVisual = new System.Windows.Forms.Button();
            this.btnEstIns = new System.Windows.Forms.Button();
            this.btnEstEditar = new System.Windows.Forms.Button();
            this.btnEstExc = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.tabRegional = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabNome = new System.Windows.Forms.TabPage();
            this.gridNome = new System.Windows.Forms.DataGridView();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabEstado = new System.Windows.Forms.TabPage();
            this.cboEstado = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.gridEstado = new System.Windows.Forms.DataGridView();
            this.tabRegional.SuspendLayout();
            this.tabNome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).BeginInit();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstado)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(6, 7);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(150, 21);
            this.txtNome.TabIndex = 0;
            this.tipRegiao.SetToolTip(this.txtNome, "Nome para pesquisar");
            this.txtNome.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // btnNomeVisual
            // 
            this.btnNomeVisual.AccessibleDescription = "";
            this.btnNomeVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeVisual.Enabled = false;
            this.btnNomeVisual.Location = new System.Drawing.Point(111, 295);
            this.btnNomeVisual.Name = "btnNomeVisual";
            this.btnNomeVisual.Size = new System.Drawing.Size(90, 30);
            this.btnNomeVisual.TabIndex = 3;
            this.btnNomeVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnNomeVisual, "Visualizar");
            this.btnNomeVisual.UseVisualStyleBackColor = true;
            this.btnNomeVisual.Click += new System.EventHandler(this.btnNomeVisual_Click);
            // 
            // btnNomeIns
            // 
            this.btnNomeIns.AccessibleDescription = "";
            this.btnNomeIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeIns.Enabled = false;
            this.btnNomeIns.Location = new System.Drawing.Point(205, 295);
            this.btnNomeIns.Name = "btnNomeIns";
            this.btnNomeIns.Size = new System.Drawing.Size(90, 30);
            this.btnNomeIns.TabIndex = 4;
            this.btnNomeIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnNomeIns, "Inserir");
            this.btnNomeIns.UseVisualStyleBackColor = true;
            this.btnNomeIns.Click += new System.EventHandler(this.btnNomeIns_Click);
            // 
            // btnNomeEditar
            // 
            this.btnNomeEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeEditar.Enabled = false;
            this.btnNomeEditar.Location = new System.Drawing.Point(299, 295);
            this.btnNomeEditar.Name = "btnNomeEditar";
            this.btnNomeEditar.Size = new System.Drawing.Size(90, 30);
            this.btnNomeEditar.TabIndex = 5;
            this.btnNomeEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnNomeEditar, "Editar");
            this.btnNomeEditar.UseVisualStyleBackColor = true;
            this.btnNomeEditar.Click += new System.EventHandler(this.btnNomeEditar_Click);
            // 
            // btnNomeExc
            // 
            this.btnNomeExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeExc.Enabled = false;
            this.btnNomeExc.Location = new System.Drawing.Point(393, 295);
            this.btnNomeExc.Name = "btnNomeExc";
            this.btnNomeExc.Size = new System.Drawing.Size(90, 30);
            this.btnNomeExc.TabIndex = 6;
            this.btnNomeExc.Text = "E&xcluir";
            this.tipRegiao.SetToolTip(this.btnNomeExc, "Excluir");
            this.btnNomeExc.UseVisualStyleBackColor = true;
            this.btnNomeExc.Click += new System.EventHandler(this.btnNomeExc_Click);
            // 
            // btnNome
            // 
            this.btnNome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNome.Image = ((System.Drawing.Image)(resources.GetObject("btnNome.Image")));
            this.btnNome.Location = new System.Drawing.Point(159, 6);
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(23, 23);
            this.btnNome.TabIndex = 1;
            this.tipRegiao.SetToolTip(this.btnNome, "Pesquisar");
            this.btnNome.UseVisualStyleBackColor = true;
            this.btnNome.Click += new System.EventHandler(this.btnNome_Click);
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
            this.btnCodVisual.Location = new System.Drawing.Point(111, 295);
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
            this.btnCodIns.Location = new System.Drawing.Point(205, 295);
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
            this.btnCodEditar.Location = new System.Drawing.Point(299, 295);
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
            this.btnCodExc.Location = new System.Drawing.Point(393, 295);
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
            this.btnCod.Location = new System.Drawing.Point(159, 6);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(23, 23);
            this.btnCod.TabIndex = 1;
            this.tipRegiao.SetToolTip(this.btnCod, "Pesquisar");
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
            // 
            // btnEstVisual
            // 
            this.btnEstVisual.AccessibleDescription = "";
            this.btnEstVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEstVisual.Enabled = false;
            this.btnEstVisual.Location = new System.Drawing.Point(111, 295);
            this.btnEstVisual.Name = "btnEstVisual";
            this.btnEstVisual.Size = new System.Drawing.Size(90, 30);
            this.btnEstVisual.TabIndex = 3;
            this.btnEstVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnEstVisual, "Visualizar");
            this.btnEstVisual.UseVisualStyleBackColor = true;
            this.btnEstVisual.Click += new System.EventHandler(this.btnEstVisual_Click);
            // 
            // btnEstIns
            // 
            this.btnEstIns.AccessibleDescription = "";
            this.btnEstIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEstIns.Enabled = false;
            this.btnEstIns.Location = new System.Drawing.Point(205, 295);
            this.btnEstIns.Name = "btnEstIns";
            this.btnEstIns.Size = new System.Drawing.Size(90, 30);
            this.btnEstIns.TabIndex = 4;
            this.btnEstIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnEstIns, "Inserir");
            this.btnEstIns.UseVisualStyleBackColor = true;
            this.btnEstIns.Click += new System.EventHandler(this.btnEstIns_Click);
            // 
            // btnEstEditar
            // 
            this.btnEstEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEstEditar.Enabled = false;
            this.btnEstEditar.Location = new System.Drawing.Point(299, 295);
            this.btnEstEditar.Name = "btnEstEditar";
            this.btnEstEditar.Size = new System.Drawing.Size(90, 30);
            this.btnEstEditar.TabIndex = 5;
            this.btnEstEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnEstEditar, "Editar");
            this.btnEstEditar.UseVisualStyleBackColor = true;
            this.btnEstEditar.Click += new System.EventHandler(this.btnEstEditar_Click);
            // 
            // btnEstExc
            // 
            this.btnEstExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEstExc.Enabled = false;
            this.btnEstExc.Location = new System.Drawing.Point(393, 295);
            this.btnEstExc.Name = "btnEstExc";
            this.btnEstExc.Size = new System.Drawing.Size(90, 30);
            this.btnEstExc.TabIndex = 6;
            this.btnEstExc.Text = "E&xcluir";
            this.tipRegiao.SetToolTip(this.btnEstExc, "Excluir");
            this.btnEstExc.UseVisualStyleBackColor = true;
            this.btnEstExc.Click += new System.EventHandler(this.btnEstExc_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(418, 375);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // tabRegional
            // 
            this.tabRegional.Controls.Add(this.tabNome);
            this.tabRegional.Controls.Add(this.tabCodigo);
            this.tabRegional.Controls.Add(this.tabEstado);
            this.tabRegional.Location = new System.Drawing.Point(9, 9);
            this.tabRegional.Name = "tabRegional";
            this.tabRegional.SelectedIndex = 0;
            this.tabRegional.Size = new System.Drawing.Size(498, 360);
            this.tabRegional.TabIndex = 31;
            this.tabRegional.SelectedIndexChanged += new System.EventHandler(this.tabRegional_SelectedIndexChanged);
            // 
            // tabNome
            // 
            this.tabNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabNome.Controls.Add(this.txtNome);
            this.tabNome.Controls.Add(this.gridNome);
            this.tabNome.Controls.Add(this.btnNomeVisual);
            this.tabNome.Controls.Add(this.btnNomeIns);
            this.tabNome.Controls.Add(this.btnNomeEditar);
            this.tabNome.Controls.Add(this.btnNomeExc);
            this.tabNome.Controls.Add(this.btnNome);
            this.tabNome.Location = new System.Drawing.Point(4, 22);
            this.tabNome.Name = "tabNome";
            this.tabNome.Padding = new System.Windows.Forms.Padding(3);
            this.tabNome.Size = new System.Drawing.Size(490, 334);
            this.tabNome.TabIndex = 1;
            this.tabNome.Text = "Descrição";
            // 
            // gridNome
            // 
            this.gridNome.AllowUserToAddRows = false;
            this.gridNome.AllowUserToDeleteRows = false;
            this.gridNome.AllowUserToResizeRows = false;
            this.gridNome.BackgroundColor = System.Drawing.Color.White;
            this.gridNome.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridNome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridNome.ColumnHeadersHeight = 17;
            this.gridNome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridNome.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridNome.EnableHeadersVisualStyles = false;
            this.gridNome.Location = new System.Drawing.Point(6, 36);
            this.gridNome.MultiSelect = false;
            this.gridNome.Name = "gridNome";
            this.gridNome.ReadOnly = true;
            this.gridNome.RowHeadersVisible = false;
            this.gridNome.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridNome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNome.Size = new System.Drawing.Size(477, 253);
            this.gridNome.TabIndex = 2;
            this.gridNome.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNome_CellDoubleClick);
            this.gridNome.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridNome_RowStateChanged);
            this.gridNome.SelectionChanged += new System.EventHandler(this.gridNome_SelectionChanged);
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
            this.tabCodigo.Size = new System.Drawing.Size(490, 334);
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
            this.gridCodigo.Size = new System.Drawing.Size(477, 253);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // tabEstado
            // 
            this.tabEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabEstado.Controls.Add(this.cboEstado);
            this.tabEstado.Controls.Add(this.gridEstado);
            this.tabEstado.Controls.Add(this.btnEstVisual);
            this.tabEstado.Controls.Add(this.btnEstIns);
            this.tabEstado.Controls.Add(this.btnEstEditar);
            this.tabEstado.Controls.Add(this.btnEstExc);
            this.tabEstado.Location = new System.Drawing.Point(4, 22);
            this.tabEstado.Name = "tabEstado";
            this.tabEstado.Padding = new System.Windows.Forms.Padding(3);
            this.tabEstado.Size = new System.Drawing.Size(490, 334);
            this.tabEstado.TabIndex = 2;
            this.tabEstado.Text = "Estado";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.LightYellow;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(6, 6);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(150, 21);
            this.cboEstado.TabIndex = 0;
            this.cboEstado.SelectedIndexChanged += new System.EventHandler(this.cboEstado_SelectedIndexChanged);
            // 
            // gridEstado
            // 
            this.gridEstado.AllowUserToAddRows = false;
            this.gridEstado.AllowUserToDeleteRows = false;
            this.gridEstado.AllowUserToResizeRows = false;
            this.gridEstado.BackgroundColor = System.Drawing.Color.White;
            this.gridEstado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridEstado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridEstado.ColumnHeadersHeight = 17;
            this.gridEstado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridEstado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridEstado.EnableHeadersVisualStyles = false;
            this.gridEstado.Location = new System.Drawing.Point(6, 36);
            this.gridEstado.MultiSelect = false;
            this.gridEstado.Name = "gridEstado";
            this.gridEstado.ReadOnly = true;
            this.gridEstado.RowHeadersVisible = false;
            this.gridEstado.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridEstado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEstado.Size = new System.Drawing.Size(477, 253);
            this.gridEstado.TabIndex = 2;
            this.gridEstado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEstado_CellDoubleClick);
            this.gridEstado.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridEstado_RowStateChanged);
            this.gridEstado.SelectionChanged += new System.EventHandler(this.gridEstado_SelectionChanged);
            // 
            // frmRegionalBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(514, 411);
            this.Controls.Add(this.tabRegional);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRegionalBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Centro de Região (Regional)";
            this.Load += new System.EventHandler(this.frmRegionalBusca_Load);
            this.tabRegional.ResumeLayout(false);
            this.tabNome.ResumeLayout(false);
            this.tabNome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).EndInit();
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabEstado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEstado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private BLL.validacoes.Controles.tabControlPersonal tabRegional;
        private System.Windows.Forms.TabPage tabNome;
        private BLL.validacoes.Controles.TextBoxPersonal txtNome;
        private System.Windows.Forms.DataGridView gridNome;
        private System.Windows.Forms.Button btnNomeVisual;
        private System.Windows.Forms.Button btnNomeIns;
        private System.Windows.Forms.Button btnNomeEditar;
        private System.Windows.Forms.Button btnNomeExc;
        private System.Windows.Forms.Button btnNome;
        private System.Windows.Forms.TabPage tabCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Button btnCodVisual;
        private System.Windows.Forms.Button btnCodIns;
        private System.Windows.Forms.Button btnCodEditar;
        private System.Windows.Forms.Button btnCodExc;
        private System.Windows.Forms.Button btnCod;
        private System.Windows.Forms.DataGridView gridCodigo;
        private System.Windows.Forms.TabPage tabEstado;
        private System.Windows.Forms.DataGridView gridEstado;
        private System.Windows.Forms.Button btnEstVisual;
        private System.Windows.Forms.Button btnEstIns;
        private System.Windows.Forms.Button btnEstEditar;
        private System.Windows.Forms.Button btnEstExc;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.ComboBoxPersonal cboEstado;
    }
}