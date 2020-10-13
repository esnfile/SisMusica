namespace ccbpess
{
    partial class frmRegiaoBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegiaoBusca));
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
            this.btnRegVisual = new System.Windows.Forms.Button();
            this.btnRegIns = new System.Windows.Forms.Button();
            this.btnRegEditar = new System.Windows.Forms.Button();
            this.btnRegExc = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.tabRegiao = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabNome = new System.Windows.Forms.TabPage();
            this.gridNome = new System.Windows.Forms.DataGridView();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabRegional = new System.Windows.Forms.TabPage();
            this.lblCodRegional = new System.Windows.Forms.Label();
            this.lblDescricaoRegional = new System.Windows.Forms.Label();
            this.lblCodigoRegional = new System.Windows.Forms.Label();
            this.btnRegional = new System.Windows.Forms.Button();
            this.gridRegional = new System.Windows.Forms.DataGridView();
            this.tabRegiao.SuspendLayout();
            this.tabNome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).BeginInit();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabRegional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegional)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.White;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(6, 7);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(150, 24);
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
            this.btnNomeVisual.Location = new System.Drawing.Point(205, 413);
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
            this.btnNomeIns.Location = new System.Drawing.Point(299, 413);
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
            this.btnNomeEditar.Location = new System.Drawing.Point(393, 413);
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
            this.btnNomeExc.Location = new System.Drawing.Point(487, 413);
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
            this.btnNome.Location = new System.Drawing.Point(159, 7);
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(24, 24);
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
            this.txtCodigo.Size = new System.Drawing.Size(150, 24);
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
            this.btnCodVisual.Location = new System.Drawing.Point(205, 413);
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
            this.btnCodIns.Location = new System.Drawing.Point(299, 413);
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
            this.btnCodEditar.Location = new System.Drawing.Point(393, 413);
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
            this.btnCodExc.Location = new System.Drawing.Point(487, 413);
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
            // btnRegVisual
            // 
            this.btnRegVisual.AccessibleDescription = "";
            this.btnRegVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegVisual.Enabled = false;
            this.btnRegVisual.Location = new System.Drawing.Point(205, 413);
            this.btnRegVisual.Name = "btnRegVisual";
            this.btnRegVisual.Size = new System.Drawing.Size(90, 30);
            this.btnRegVisual.TabIndex = 3;
            this.btnRegVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnRegVisual, "Visualizar");
            this.btnRegVisual.UseVisualStyleBackColor = true;
            this.btnRegVisual.Click += new System.EventHandler(this.btnRegVisual_Click);
            // 
            // btnRegIns
            // 
            this.btnRegIns.AccessibleDescription = "";
            this.btnRegIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegIns.Enabled = false;
            this.btnRegIns.Location = new System.Drawing.Point(299, 413);
            this.btnRegIns.Name = "btnRegIns";
            this.btnRegIns.Size = new System.Drawing.Size(90, 30);
            this.btnRegIns.TabIndex = 4;
            this.btnRegIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnRegIns, "Inserir");
            this.btnRegIns.UseVisualStyleBackColor = true;
            this.btnRegIns.Click += new System.EventHandler(this.btnRegIns_Click);
            // 
            // btnRegEditar
            // 
            this.btnRegEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegEditar.Enabled = false;
            this.btnRegEditar.Location = new System.Drawing.Point(393, 413);
            this.btnRegEditar.Name = "btnRegEditar";
            this.btnRegEditar.Size = new System.Drawing.Size(90, 30);
            this.btnRegEditar.TabIndex = 5;
            this.btnRegEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnRegEditar, "Editar");
            this.btnRegEditar.UseVisualStyleBackColor = true;
            this.btnRegEditar.Click += new System.EventHandler(this.btnRegEditar_Click);
            // 
            // btnRegExc
            // 
            this.btnRegExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegExc.Enabled = false;
            this.btnRegExc.Location = new System.Drawing.Point(487, 413);
            this.btnRegExc.Name = "btnRegExc";
            this.btnRegExc.Size = new System.Drawing.Size(90, 30);
            this.btnRegExc.TabIndex = 6;
            this.btnRegExc.Text = "E&xcluir";
            this.tipRegiao.SetToolTip(this.btnRegExc, "Excluir");
            this.btnRegExc.UseVisualStyleBackColor = true;
            this.btnRegExc.Click += new System.EventHandler(this.btnRegExc_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(514, 494);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // tabRegiao
            // 
            this.tabRegiao.Controls.Add(this.tabNome);
            this.tabRegiao.Controls.Add(this.tabCodigo);
            this.tabRegiao.Controls.Add(this.tabRegional);
            this.tabRegiao.Location = new System.Drawing.Point(9, 9);
            this.tabRegiao.Name = "tabRegiao";
            this.tabRegiao.SelectedIndex = 0;
            this.tabRegiao.Size = new System.Drawing.Size(595, 479);
            this.tabRegiao.TabIndex = 31;
            this.tabRegiao.SelectedIndexChanged += new System.EventHandler(this.tabRegiao_SelectedIndexChanged);
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
            this.tabNome.Location = new System.Drawing.Point(4, 26);
            this.tabNome.Name = "tabNome";
            this.tabNome.Padding = new System.Windows.Forms.Padding(3);
            this.tabNome.Size = new System.Drawing.Size(587, 449);
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
            this.gridNome.Size = new System.Drawing.Size(571, 371);
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
            this.tabCodigo.Location = new System.Drawing.Point(4, 26);
            this.tabCodigo.Name = "tabCodigo";
            this.tabCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodigo.Size = new System.Drawing.Size(587, 449);
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
            this.gridCodigo.Size = new System.Drawing.Size(571, 371);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // tabRegional
            // 
            this.tabRegional.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabRegional.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRegional.Controls.Add(this.lblCodRegional);
            this.tabRegional.Controls.Add(this.lblDescricaoRegional);
            this.tabRegional.Controls.Add(this.lblCodigoRegional);
            this.tabRegional.Controls.Add(this.btnRegional);
            this.tabRegional.Controls.Add(this.gridRegional);
            this.tabRegional.Controls.Add(this.btnRegVisual);
            this.tabRegional.Controls.Add(this.btnRegIns);
            this.tabRegional.Controls.Add(this.btnRegEditar);
            this.tabRegional.Controls.Add(this.btnRegExc);
            this.tabRegional.Location = new System.Drawing.Point(4, 26);
            this.tabRegional.Name = "tabRegional";
            this.tabRegional.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegional.Size = new System.Drawing.Size(587, 449);
            this.tabRegional.TabIndex = 2;
            this.tabRegional.Text = "Regional";
            // 
            // lblCodRegional
            // 
            this.lblCodRegional.Enabled = false;
            this.lblCodRegional.Location = new System.Drawing.Point(155, 3);
            this.lblCodRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodRegional.Name = "lblCodRegional";
            this.lblCodRegional.Size = new System.Drawing.Size(67, 17);
            this.lblCodRegional.TabIndex = 120;
            this.lblCodRegional.TextChanged += new System.EventHandler(this.lblCodRegional_TextChanged);
            // 
            // lblDescricaoRegional
            // 
            this.lblDescricaoRegional.Enabled = false;
            this.lblDescricaoRegional.Location = new System.Drawing.Point(244, 11);
            this.lblDescricaoRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoRegional.Name = "lblDescricaoRegional";
            this.lblDescricaoRegional.Size = new System.Drawing.Size(333, 17);
            this.lblDescricaoRegional.TabIndex = 119;
            // 
            // lblCodigoRegional
            // 
            this.lblCodigoRegional.Enabled = false;
            this.lblCodigoRegional.Location = new System.Drawing.Point(119, 11);
            this.lblCodigoRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigoRegional.Name = "lblCodigoRegional";
            this.lblCodigoRegional.Size = new System.Drawing.Size(115, 17);
            this.lblCodigoRegional.TabIndex = 118;
            // 
            // btnRegional
            // 
            this.btnRegional.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegional.Image = global::ccbpess.Properties.Resources.PesquisaOS;
            this.btnRegional.Location = new System.Drawing.Point(6, 3);
            this.btnRegional.Name = "btnRegional";
            this.btnRegional.Size = new System.Drawing.Size(101, 30);
            this.btnRegional.TabIndex = 117;
            this.btnRegional.Text = "Regional";
            this.btnRegional.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegional.UseVisualStyleBackColor = true;
            this.btnRegional.Click += new System.EventHandler(this.btnRegional_Click);
            // 
            // gridRegional
            // 
            this.gridRegional.AllowUserToAddRows = false;
            this.gridRegional.AllowUserToDeleteRows = false;
            this.gridRegional.AllowUserToResizeRows = false;
            this.gridRegional.BackgroundColor = System.Drawing.Color.White;
            this.gridRegional.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegional.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridRegional.ColumnHeadersHeight = 17;
            this.gridRegional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridRegional.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRegional.EnableHeadersVisualStyles = false;
            this.gridRegional.Location = new System.Drawing.Point(6, 36);
            this.gridRegional.MultiSelect = false;
            this.gridRegional.Name = "gridRegional";
            this.gridRegional.ReadOnly = true;
            this.gridRegional.RowHeadersVisible = false;
            this.gridRegional.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRegional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegional.Size = new System.Drawing.Size(571, 371);
            this.gridRegional.TabIndex = 2;
            this.gridRegional.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegional_CellDoubleClick);
            this.gridRegional.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridRegional_RowStateChanged);
            this.gridRegional.SelectionChanged += new System.EventHandler(this.gridRegional_SelectionChanged);
            // 
            // frmRegiaoBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(614, 535);
            this.Controls.Add(this.tabRegiao);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRegiaoBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Região";
            this.Load += new System.EventHandler(this.frmRegiaoBusca_Load);
            this.tabRegiao.ResumeLayout(false);
            this.tabNome.ResumeLayout(false);
            this.tabNome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).EndInit();
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabRegional.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegional)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private BLL.validacoes.Controles.tabControlPersonal tabRegiao;
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
        private System.Windows.Forms.TabPage tabRegional;
        private System.Windows.Forms.DataGridView gridRegional;
        private System.Windows.Forms.Button btnRegVisual;
        private System.Windows.Forms.Button btnRegIns;
        private System.Windows.Forms.Button btnRegEditar;
        private System.Windows.Forms.Button btnRegExc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblDescricaoRegional;
        private System.Windows.Forms.Label lblCodigoRegional;
        private System.Windows.Forms.Button btnRegional;
        private System.Windows.Forms.Label lblCodRegional;
    }
}