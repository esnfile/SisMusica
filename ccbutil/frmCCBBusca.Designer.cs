namespace ccbutil
{
    partial class frmCCBBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCCBBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipCCB = new System.Windows.Forms.ToolTip(this.components);
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
            this.btnRegiao = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnNomeSel = new System.Windows.Forms.Button();
            this.btnCodSel = new System.Windows.Forms.Button();
            this.btnRegSel = new System.Windows.Forms.Button();
            this.imgCCB = new System.Windows.Forms.ImageList(this.components);
            this.tabCCB = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabNome = new System.Windows.Forms.TabPage();
            this.gridNome = new System.Windows.Forms.DataGridView();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabRegiao = new System.Windows.Forms.TabPage();
            this.lblDescricaoRegiao = new System.Windows.Forms.Label();
            this.lblCodRegiao = new System.Windows.Forms.Label();
            this.gridRegiao = new System.Windows.Forms.DataGridView();
            this.lblFechada = new System.Windows.Forms.Label();
            this.pctFechada = new System.Windows.Forms.PictureBox();
            this.lblAberta = new System.Windows.Forms.Label();
            this.pctAberta = new System.Windows.Forms.PictureBox();
            this.lblConstrucao = new System.Windows.Forms.Label();
            this.pctConstrucao = new System.Windows.Forms.PictureBox();
            this.lblReforma = new System.Windows.Forms.Label();
            this.pctReforma = new System.Windows.Forms.PictureBox();
            this.tabCCB.SuspendLayout();
            this.tabNome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).BeginInit();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabRegiao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFechada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAberta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctConstrucao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReforma)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.LightYellow;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(6, 7);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(150, 21);
            this.txtNome.TabIndex = 0;
            this.tipCCB.SetToolTip(this.txtNome, "Nome para pesquisar");
            this.txtNome.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // btnNomeVisual
            // 
            this.btnNomeVisual.AccessibleDescription = "";
            this.btnNomeVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeVisual.Enabled = false;
            this.btnNomeVisual.Location = new System.Drawing.Point(299, 324);
            this.btnNomeVisual.Name = "btnNomeVisual";
            this.btnNomeVisual.Size = new System.Drawing.Size(90, 30);
            this.btnNomeVisual.TabIndex = 3;
            this.btnNomeVisual.Text = "&Visualizar";
            this.tipCCB.SetToolTip(this.btnNomeVisual, "Visualizar");
            this.btnNomeVisual.UseVisualStyleBackColor = true;
            this.btnNomeVisual.Click += new System.EventHandler(this.btnNomeVisual_Click);
            // 
            // btnNomeIns
            // 
            this.btnNomeIns.AccessibleDescription = "";
            this.btnNomeIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeIns.Enabled = false;
            this.btnNomeIns.Location = new System.Drawing.Point(393, 324);
            this.btnNomeIns.Name = "btnNomeIns";
            this.btnNomeIns.Size = new System.Drawing.Size(90, 30);
            this.btnNomeIns.TabIndex = 4;
            this.btnNomeIns.Text = "&Inserir";
            this.tipCCB.SetToolTip(this.btnNomeIns, "Inserir");
            this.btnNomeIns.UseVisualStyleBackColor = true;
            this.btnNomeIns.Click += new System.EventHandler(this.btnNomeIns_Click);
            // 
            // btnNomeEditar
            // 
            this.btnNomeEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeEditar.Enabled = false;
            this.btnNomeEditar.Location = new System.Drawing.Point(487, 324);
            this.btnNomeEditar.Name = "btnNomeEditar";
            this.btnNomeEditar.Size = new System.Drawing.Size(90, 30);
            this.btnNomeEditar.TabIndex = 5;
            this.btnNomeEditar.Text = "&Editar";
            this.tipCCB.SetToolTip(this.btnNomeEditar, "Editar");
            this.btnNomeEditar.UseVisualStyleBackColor = true;
            this.btnNomeEditar.Click += new System.EventHandler(this.btnNomeEditar_Click);
            // 
            // btnNomeExc
            // 
            this.btnNomeExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeExc.Enabled = false;
            this.btnNomeExc.Location = new System.Drawing.Point(581, 324);
            this.btnNomeExc.Name = "btnNomeExc";
            this.btnNomeExc.Size = new System.Drawing.Size(90, 30);
            this.btnNomeExc.TabIndex = 6;
            this.btnNomeExc.Text = "E&xcluir";
            this.tipCCB.SetToolTip(this.btnNomeExc, "Excluir");
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
            this.tipCCB.SetToolTip(this.btnNome, "Pesquisar");
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
            this.tipCCB.SetToolTip(this.txtCodigo, "Código para pesquisar");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnCodVisual
            // 
            this.btnCodVisual.AccessibleDescription = "";
            this.btnCodVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodVisual.Enabled = false;
            this.btnCodVisual.Location = new System.Drawing.Point(299, 324);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 3;
            this.btnCodVisual.Text = "&Visualizar";
            this.tipCCB.SetToolTip(this.btnCodVisual, "Visualizar");
            this.btnCodVisual.UseVisualStyleBackColor = true;
            this.btnCodVisual.Click += new System.EventHandler(this.btnCodVisual_Click);
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(393, 324);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 4;
            this.btnCodIns.Text = "&Inserir";
            this.tipCCB.SetToolTip(this.btnCodIns, "Inserir");
            this.btnCodIns.UseVisualStyleBackColor = true;
            this.btnCodIns.Click += new System.EventHandler(this.btnCodIns_Click);
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(487, 324);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 5;
            this.btnCodEditar.Text = "&Editar";
            this.tipCCB.SetToolTip(this.btnCodEditar, "Editar");
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCodExc
            // 
            this.btnCodExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodExc.Enabled = false;
            this.btnCodExc.Location = new System.Drawing.Point(581, 324);
            this.btnCodExc.Name = "btnCodExc";
            this.btnCodExc.Size = new System.Drawing.Size(90, 30);
            this.btnCodExc.TabIndex = 6;
            this.btnCodExc.Text = "E&xcluir";
            this.tipCCB.SetToolTip(this.btnCodExc, "Excluir");
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
            this.tipCCB.SetToolTip(this.btnCod, "Pesquisar");
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
            // 
            // btnRegVisual
            // 
            this.btnRegVisual.AccessibleDescription = "";
            this.btnRegVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegVisual.Enabled = false;
            this.btnRegVisual.Location = new System.Drawing.Point(299, 324);
            this.btnRegVisual.Name = "btnRegVisual";
            this.btnRegVisual.Size = new System.Drawing.Size(90, 30);
            this.btnRegVisual.TabIndex = 3;
            this.btnRegVisual.Text = "&Visualizar";
            this.tipCCB.SetToolTip(this.btnRegVisual, "Visualizar");
            this.btnRegVisual.UseVisualStyleBackColor = true;
            this.btnRegVisual.Click += new System.EventHandler(this.btnRegVisual_Click);
            // 
            // btnRegIns
            // 
            this.btnRegIns.AccessibleDescription = "";
            this.btnRegIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegIns.Enabled = false;
            this.btnRegIns.Location = new System.Drawing.Point(393, 324);
            this.btnRegIns.Name = "btnRegIns";
            this.btnRegIns.Size = new System.Drawing.Size(90, 30);
            this.btnRegIns.TabIndex = 4;
            this.btnRegIns.Text = "&Inserir";
            this.tipCCB.SetToolTip(this.btnRegIns, "Inserir");
            this.btnRegIns.UseVisualStyleBackColor = true;
            this.btnRegIns.Click += new System.EventHandler(this.btnRegiao_Click);
            // 
            // btnRegEditar
            // 
            this.btnRegEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegEditar.Enabled = false;
            this.btnRegEditar.Location = new System.Drawing.Point(487, 324);
            this.btnRegEditar.Name = "btnRegEditar";
            this.btnRegEditar.Size = new System.Drawing.Size(90, 30);
            this.btnRegEditar.TabIndex = 5;
            this.btnRegEditar.Text = "&Editar";
            this.tipCCB.SetToolTip(this.btnRegEditar, "Editar");
            this.btnRegEditar.UseVisualStyleBackColor = true;
            this.btnRegEditar.Click += new System.EventHandler(this.btnRegEditar_Click);
            // 
            // btnRegExc
            // 
            this.btnRegExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegExc.Enabled = false;
            this.btnRegExc.Location = new System.Drawing.Point(581, 324);
            this.btnRegExc.Name = "btnRegExc";
            this.btnRegExc.Size = new System.Drawing.Size(90, 30);
            this.btnRegExc.TabIndex = 6;
            this.btnRegExc.Text = "E&xcluir";
            this.tipCCB.SetToolTip(this.btnRegExc, "Excluir");
            this.btnRegExc.UseVisualStyleBackColor = true;
            this.btnRegExc.Click += new System.EventHandler(this.btnRegExc_Click);
            // 
            // btnRegiao
            // 
            this.btnRegiao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegiao.Image = global::ccbutil.Properties.Resources.PesquisaOS;
            this.btnRegiao.Location = new System.Drawing.Point(6, 3);
            this.btnRegiao.Name = "btnRegiao";
            this.btnRegiao.Size = new System.Drawing.Size(101, 30);
            this.btnRegiao.TabIndex = 1;
            this.btnRegiao.Text = "Região";
            this.btnRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipCCB.SetToolTip(this.btnRegiao, "Pesquisar");
            this.btnRegiao.UseVisualStyleBackColor = true;
            this.btnRegiao.Click += new System.EventHandler(this.btnRegiao_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(606, 403);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipCCB.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnNomeSel
            // 
            this.btnNomeSel.AccessibleDescription = "";
            this.btnNomeSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeSel.Enabled = false;
            this.btnNomeSel.Location = new System.Drawing.Point(6, 324);
            this.btnNomeSel.Name = "btnNomeSel";
            this.btnNomeSel.Size = new System.Drawing.Size(90, 30);
            this.btnNomeSel.TabIndex = 7;
            this.btnNomeSel.Text = "&Selecionar";
            this.tipCCB.SetToolTip(this.btnNomeSel, "Visualizar");
            this.btnNomeSel.UseVisualStyleBackColor = true;
            this.btnNomeSel.Visible = false;
            this.btnNomeSel.Click += new System.EventHandler(this.btnNomeSel_Click);
            // 
            // btnCodSel
            // 
            this.btnCodSel.AccessibleDescription = "";
            this.btnCodSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodSel.Enabled = false;
            this.btnCodSel.Location = new System.Drawing.Point(6, 324);
            this.btnCodSel.Name = "btnCodSel";
            this.btnCodSel.Size = new System.Drawing.Size(90, 30);
            this.btnCodSel.TabIndex = 8;
            this.btnCodSel.Text = "&Selecionar";
            this.tipCCB.SetToolTip(this.btnCodSel, "Visualizar");
            this.btnCodSel.UseVisualStyleBackColor = true;
            this.btnCodSel.Visible = false;
            this.btnCodSel.Click += new System.EventHandler(this.btnCodSel_Click);
            // 
            // btnRegSel
            // 
            this.btnRegSel.AccessibleDescription = "";
            this.btnRegSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegSel.Enabled = false;
            this.btnRegSel.Location = new System.Drawing.Point(6, 324);
            this.btnRegSel.Name = "btnRegSel";
            this.btnRegSel.Size = new System.Drawing.Size(90, 30);
            this.btnRegSel.TabIndex = 118;
            this.btnRegSel.Text = "&Selecionar";
            this.tipCCB.SetToolTip(this.btnRegSel, "Visualizar");
            this.btnRegSel.UseVisualStyleBackColor = true;
            this.btnRegSel.Visible = false;
            this.btnRegSel.Click += new System.EventHandler(this.btnRegSel_Click);
            // 
            // imgCCB
            // 
            this.imgCCB.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgCCB.ImageStream")));
            this.imgCCB.TransparentColor = System.Drawing.Color.Transparent;
            this.imgCCB.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgCCB.Images.SetKeyName(1, "BolaVermelha.ico");
            this.imgCCB.Images.SetKeyName(2, "BolaAmarela.ico");
            this.imgCCB.Images.SetKeyName(3, "BolaAzul.ico");
            // 
            // tabCCB
            // 
            this.tabCCB.Controls.Add(this.tabNome);
            this.tabCCB.Controls.Add(this.tabCodigo);
            this.tabCCB.Controls.Add(this.tabRegiao);
            this.tabCCB.Location = new System.Drawing.Point(9, 9);
            this.tabCCB.Name = "tabCCB";
            this.tabCCB.SelectedIndex = 0;
            this.tabCCB.Size = new System.Drawing.Size(686, 388);
            this.tabCCB.TabIndex = 31;
            this.tabCCB.SelectedIndexChanged += new System.EventHandler(this.tabCCB_SelectedIndexChanged);
            // 
            // tabNome
            // 
            this.tabNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabNome.Controls.Add(this.btnNomeSel);
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
            this.tabNome.Size = new System.Drawing.Size(678, 362);
            this.tabNome.TabIndex = 1;
            this.tabNome.Text = "Nome Comum";
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
            this.gridNome.Size = new System.Drawing.Size(665, 282);
            this.gridNome.TabIndex = 2;
            this.gridNome.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNome_CellDoubleClick);
            this.gridNome.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridNome_RowStateChanged);
            this.gridNome.SelectionChanged += new System.EventHandler(this.gridNome_SelectionChanged);
            // 
            // tabCodigo
            // 
            this.tabCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCodigo.Controls.Add(this.btnCodSel);
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
            this.tabCodigo.Size = new System.Drawing.Size(678, 362);
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
            this.gridCodigo.Size = new System.Drawing.Size(665, 282);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // tabRegiao
            // 
            this.tabRegiao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRegiao.Controls.Add(this.btnRegSel);
            this.tabRegiao.Controls.Add(this.lblDescricaoRegiao);
            this.tabRegiao.Controls.Add(this.lblCodRegiao);
            this.tabRegiao.Controls.Add(this.gridRegiao);
            this.tabRegiao.Controls.Add(this.btnRegVisual);
            this.tabRegiao.Controls.Add(this.btnRegIns);
            this.tabRegiao.Controls.Add(this.btnRegEditar);
            this.tabRegiao.Controls.Add(this.btnRegExc);
            this.tabRegiao.Controls.Add(this.btnRegiao);
            this.tabRegiao.Location = new System.Drawing.Point(4, 22);
            this.tabRegiao.Name = "tabRegiao";
            this.tabRegiao.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegiao.Size = new System.Drawing.Size(678, 362);
            this.tabRegiao.TabIndex = 2;
            this.tabRegiao.Text = "Região";
            // 
            // lblDescricaoRegiao
            // 
            this.lblDescricaoRegiao.Enabled = false;
            this.lblDescricaoRegiao.Location = new System.Drawing.Point(115, 11);
            this.lblDescricaoRegiao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoRegiao.Name = "lblDescricaoRegiao";
            this.lblDescricaoRegiao.Size = new System.Drawing.Size(650, 17);
            this.lblDescricaoRegiao.TabIndex = 116;
            // 
            // lblCodRegiao
            // 
            this.lblCodRegiao.Location = new System.Drawing.Point(117, 5);
            this.lblCodRegiao.Name = "lblCodRegiao";
            this.lblCodRegiao.Size = new System.Drawing.Size(46, 17);
            this.lblCodRegiao.TabIndex = 117;
            this.lblCodRegiao.Visible = false;
            this.lblCodRegiao.TextChanged += new System.EventHandler(this.lblCodRegiao_TextChanged);
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
            this.gridRegiao.ColumnHeadersHeight = 17;
            this.gridRegiao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridRegiao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRegiao.EnableHeadersVisualStyles = false;
            this.gridRegiao.Location = new System.Drawing.Point(6, 36);
            this.gridRegiao.MultiSelect = false;
            this.gridRegiao.Name = "gridRegiao";
            this.gridRegiao.ReadOnly = true;
            this.gridRegiao.RowHeadersVisible = false;
            this.gridRegiao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRegiao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegiao.Size = new System.Drawing.Size(665, 282);
            this.gridRegiao.TabIndex = 2;
            this.gridRegiao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellDoubleClick);
            this.gridRegiao.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridRegiao_RowStateChanged);
            this.gridRegiao.SelectionChanged += new System.EventHandler(this.gridRegiao_SelectionChanged);
            // 
            // lblFechada
            // 
            this.lblFechada.AutoSize = true;
            this.lblFechada.Location = new System.Drawing.Point(94, 407);
            this.lblFechada.Name = "lblFechada";
            this.lblFechada.Size = new System.Drawing.Size(48, 13);
            this.lblFechada.TabIndex = 36;
            this.lblFechada.Text = "Fechada";
            // 
            // pctFechada
            // 
            this.pctFechada.Location = new System.Drawing.Point(78, 404);
            this.pctFechada.Name = "pctFechada";
            this.pctFechada.Size = new System.Drawing.Size(16, 20);
            this.pctFechada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctFechada.TabIndex = 35;
            this.pctFechada.TabStop = false;
            // 
            // lblAberta
            // 
            this.lblAberta.AutoSize = true;
            this.lblAberta.Location = new System.Drawing.Point(26, 407);
            this.lblAberta.Name = "lblAberta";
            this.lblAberta.Size = new System.Drawing.Size(40, 13);
            this.lblAberta.TabIndex = 34;
            this.lblAberta.Text = "Aberta";
            // 
            // pctAberta
            // 
            this.pctAberta.Location = new System.Drawing.Point(9, 404);
            this.pctAberta.Name = "pctAberta";
            this.pctAberta.Size = new System.Drawing.Size(16, 20);
            this.pctAberta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAberta.TabIndex = 33;
            this.pctAberta.TabStop = false;
            // 
            // lblConstrucao
            // 
            this.lblConstrucao.AutoSize = true;
            this.lblConstrucao.Location = new System.Drawing.Point(173, 407);
            this.lblConstrucao.Name = "lblConstrucao";
            this.lblConstrucao.Size = new System.Drawing.Size(79, 13);
            this.lblConstrucao.TabIndex = 38;
            this.lblConstrucao.Text = "Em Construção";
            // 
            // pctConstrucao
            // 
            this.pctConstrucao.Location = new System.Drawing.Point(157, 404);
            this.pctConstrucao.Name = "pctConstrucao";
            this.pctConstrucao.Size = new System.Drawing.Size(16, 20);
            this.pctConstrucao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctConstrucao.TabIndex = 37;
            this.pctConstrucao.TabStop = false;
            // 
            // lblReforma
            // 
            this.lblReforma.AutoSize = true;
            this.lblReforma.Location = new System.Drawing.Point(295, 407);
            this.lblReforma.Name = "lblReforma";
            this.lblReforma.Size = new System.Drawing.Size(48, 13);
            this.lblReforma.TabIndex = 40;
            this.lblReforma.Text = "Reforma";
            // 
            // pctReforma
            // 
            this.pctReforma.Location = new System.Drawing.Point(279, 404);
            this.pctReforma.Name = "pctReforma";
            this.pctReforma.Size = new System.Drawing.Size(16, 20);
            this.pctReforma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctReforma.TabIndex = 39;
            this.pctReforma.TabStop = false;
            // 
            // frmCCBBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(704, 442);
            this.Controls.Add(this.lblReforma);
            this.Controls.Add(this.pctReforma);
            this.Controls.Add(this.lblConstrucao);
            this.Controls.Add(this.pctConstrucao);
            this.Controls.Add(this.tabCCB);
            this.Controls.Add(this.lblFechada);
            this.Controls.Add(this.pctFechada);
            this.Controls.Add(this.lblAberta);
            this.Controls.Add(this.pctAberta);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCCBBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comum Congregação";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCCBBusca_FormClosed);
            this.Load += new System.EventHandler(this.frmCCBBusca_Load);
            this.tabCCB.ResumeLayout(false);
            this.tabNome.ResumeLayout(false);
            this.tabNome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).EndInit();
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabRegiao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFechada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAberta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctConstrucao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReforma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipCCB;
        private System.Windows.Forms.ImageList imgCCB;
        private BLL.validacoes.Controles.tabControlPersonal tabCCB;
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
        private System.Windows.Forms.TabPage tabRegiao;
        private System.Windows.Forms.DataGridView gridRegiao;
        private System.Windows.Forms.Button btnRegVisual;
        private System.Windows.Forms.Button btnRegIns;
        private System.Windows.Forms.Button btnRegEditar;
        private System.Windows.Forms.Button btnRegExc;
        private System.Windows.Forms.Button btnRegiao;
        private System.Windows.Forms.Label lblFechada;
        private System.Windows.Forms.PictureBox pctFechada;
        private System.Windows.Forms.Label lblAberta;
        private System.Windows.Forms.PictureBox pctAberta;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblConstrucao;
        private System.Windows.Forms.PictureBox pctConstrucao;
        private System.Windows.Forms.Label lblReforma;
        private System.Windows.Forms.PictureBox pctReforma;
        private System.Windows.Forms.Label lblDescricaoRegiao;
        private System.Windows.Forms.Label lblCodRegiao;
        private System.Windows.Forms.Button btnNomeSel;
        private System.Windows.Forms.Button btnCodSel;
        private System.Windows.Forms.Button btnRegSel;
    }
}