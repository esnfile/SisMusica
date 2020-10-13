namespace ccbtest.pesquisa
{
    partial class frmPesquisaSolicita
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaSolicita));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipRegiao = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSelPes = new System.Windows.Forms.Button();
            this.btnSelCCB = new System.Windows.Forms.Button();
            this.tabSolicita = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabPes = new System.Windows.Forms.TabPage();
            this.lblDescPessoa = new System.Windows.Forms.Label();
            this.lblCodPessoa = new System.Windows.Forms.Label();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.gridPes = new System.Windows.Forms.DataGridView();
            this.tabComum = new System.Windows.Forms.TabPage();
            this.lblDescCCB = new System.Windows.Forms.Label();
            this.lblCodCCB = new System.Windows.Forms.Label();
            this.btnCCB = new System.Windows.Forms.Button();
            this.gridCCB = new System.Windows.Forms.DataGridView();
            this.imgSolicita = new System.Windows.Forms.ImageList(this.components);
            this.lblLegenda = new System.Windows.Forms.Label();
            this.lblOficial = new System.Windows.Forms.Label();
            this.pctOficial = new System.Windows.Forms.PictureBox();
            this.lblCulto = new System.Windows.Forms.Label();
            this.pctCulto = new System.Windows.Forms.PictureBox();
            this.lblRjm = new System.Windows.Forms.Label();
            this.pctRjm = new System.Windows.Forms.PictureBox();
            this.lblMeiaHora = new System.Windows.Forms.Label();
            this.pctMeiaHora = new System.Windows.Forms.PictureBox();
            this.lblTroca = new System.Windows.Forms.Label();
            this.pctTroca = new System.Windows.Forms.PictureBox();
            this.tabRegiao = new System.Windows.Forms.TabPage();
            this.gridRegiao = new System.Windows.Forms.DataGridView();
            this.btnSelReg = new System.Windows.Forms.Button();
            this.cboRegiao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.tabSolicita.SuspendLayout();
            this.tabPes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPes)).BeginInit();
            this.tabComum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCCB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOficial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCulto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRjm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMeiaHora)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTroca)).BeginInit();
            this.tabRegiao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(534, 362);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSelPes
            // 
            this.btnSelPes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelPes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSelPes.Enabled = false;
            this.btnSelPes.Location = new System.Drawing.Point(507, 287);
            this.btnSelPes.Name = "btnSelPes";
            this.btnSelPes.Size = new System.Drawing.Size(90, 30);
            this.btnSelPes.TabIndex = 5;
            this.btnSelPes.Text = "&Selecionar";
            this.tipRegiao.SetToolTip(this.btnSelPes, "Selecionar");
            this.btnSelPes.UseVisualStyleBackColor = true;
            this.btnSelPes.Click += new System.EventHandler(this.btnSelPes_Click);
            // 
            // btnSelCCB
            // 
            this.btnSelCCB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelCCB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSelCCB.Enabled = false;
            this.btnSelCCB.Location = new System.Drawing.Point(507, 287);
            this.btnSelCCB.Name = "btnSelCCB";
            this.btnSelCCB.Size = new System.Drawing.Size(90, 30);
            this.btnSelCCB.TabIndex = 136;
            this.btnSelCCB.Text = "&Selecionar";
            this.tipRegiao.SetToolTip(this.btnSelCCB, "Selecionar");
            this.btnSelCCB.UseVisualStyleBackColor = true;
            this.btnSelCCB.Click += new System.EventHandler(this.btnSelCCB_Click);
            // 
            // tabSolicita
            // 
            this.tabSolicita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabSolicita.Controls.Add(this.tabRegiao);
            this.tabSolicita.Controls.Add(this.tabPes);
            this.tabSolicita.Controls.Add(this.tabComum);
            this.tabSolicita.Location = new System.Drawing.Point(7, 6);
            this.tabSolicita.Name = "tabSolicita";
            this.tabSolicita.SelectedIndex = 0;
            this.tabSolicita.Size = new System.Drawing.Size(615, 352);
            this.tabSolicita.TabIndex = 31;
            this.tabSolicita.SelectedIndexChanged += new System.EventHandler(this.tabSolicita_SelectedIndexChanged);
            // 
            // tabPes
            // 
            this.tabPes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabPes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPes.Controls.Add(this.lblDescPessoa);
            this.tabPes.Controls.Add(this.lblCodPessoa);
            this.tabPes.Controls.Add(this.btnPessoa);
            this.tabPes.Controls.Add(this.gridPes);
            this.tabPes.Controls.Add(this.btnSelPes);
            this.tabPes.Location = new System.Drawing.Point(4, 22);
            this.tabPes.Name = "tabPes";
            this.tabPes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPes.Size = new System.Drawing.Size(607, 326);
            this.tabPes.TabIndex = 1;
            this.tabPes.Text = "Candidato(a)";
            // 
            // lblDescPessoa
            // 
            this.lblDescPessoa.Enabled = false;
            this.lblDescPessoa.Location = new System.Drawing.Point(104, 10);
            this.lblDescPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescPessoa.Name = "lblDescPessoa";
            this.lblDescPessoa.Size = new System.Drawing.Size(473, 17);
            this.lblDescPessoa.TabIndex = 133;
            // 
            // lblCodPessoa
            // 
            this.lblCodPessoa.Location = new System.Drawing.Point(115, 6);
            this.lblCodPessoa.Name = "lblCodPessoa";
            this.lblCodPessoa.Size = new System.Drawing.Size(46, 17);
            this.lblCodPessoa.TabIndex = 134;
            this.lblCodPessoa.Visible = false;
            this.lblCodPessoa.TextChanged += new System.EventHandler(this.lblCodPessoa_TextChanged);
            // 
            // btnPessoa
            // 
            this.btnPessoa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPessoa.Image = global::ccbtest.Properties.Resources.PesquisaOS;
            this.btnPessoa.Location = new System.Drawing.Point(6, 5);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(90, 26);
            this.btnPessoa.TabIndex = 132;
            this.btnPessoa.Text = "Pessoa";
            this.btnPessoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // gridPes
            // 
            this.gridPes.AllowUserToAddRows = false;
            this.gridPes.AllowUserToDeleteRows = false;
            this.gridPes.AllowUserToResizeRows = false;
            this.gridPes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridPes.BackgroundColor = System.Drawing.Color.White;
            this.gridPes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridPes.ColumnHeadersHeight = 17;
            this.gridPes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridPes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPes.EnableHeadersVisualStyles = false;
            this.gridPes.Location = new System.Drawing.Point(6, 36);
            this.gridPes.MultiSelect = false;
            this.gridPes.Name = "gridPes";
            this.gridPes.ReadOnly = true;
            this.gridPes.RowHeadersVisible = false;
            this.gridPes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPes.Size = new System.Drawing.Size(591, 245);
            this.gridPes.TabIndex = 2;
            this.gridPes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPes_CellDoubleClick);
            this.gridPes.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridPes_RowStateChanged);
            this.gridPes.SelectionChanged += new System.EventHandler(this.gridPes_SelectionChanged);
            // 
            // tabComum
            // 
            this.tabComum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabComum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabComum.Controls.Add(this.lblDescCCB);
            this.tabComum.Controls.Add(this.lblCodCCB);
            this.tabComum.Controls.Add(this.btnCCB);
            this.tabComum.Controls.Add(this.gridCCB);
            this.tabComum.Controls.Add(this.btnSelCCB);
            this.tabComum.Location = new System.Drawing.Point(4, 22);
            this.tabComum.Name = "tabComum";
            this.tabComum.Padding = new System.Windows.Forms.Padding(3);
            this.tabComum.Size = new System.Drawing.Size(607, 326);
            this.tabComum.TabIndex = 2;
            this.tabComum.Text = "Comum";
            // 
            // lblDescCCB
            // 
            this.lblDescCCB.Enabled = false;
            this.lblDescCCB.Location = new System.Drawing.Point(104, 10);
            this.lblDescCCB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescCCB.Name = "lblDescCCB";
            this.lblDescCCB.Size = new System.Drawing.Size(473, 17);
            this.lblDescCCB.TabIndex = 138;
            // 
            // lblCodCCB
            // 
            this.lblCodCCB.Location = new System.Drawing.Point(115, 6);
            this.lblCodCCB.Name = "lblCodCCB";
            this.lblCodCCB.Size = new System.Drawing.Size(46, 17);
            this.lblCodCCB.TabIndex = 139;
            this.lblCodCCB.Visible = false;
            this.lblCodCCB.Click += new System.EventHandler(this.lblCodCCB_Click);
            // 
            // btnCCB
            // 
            this.btnCCB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCCB.Image = global::ccbtest.Properties.Resources.PesquisaOS;
            this.btnCCB.Location = new System.Drawing.Point(6, 5);
            this.btnCCB.Name = "btnCCB";
            this.btnCCB.Size = new System.Drawing.Size(90, 26);
            this.btnCCB.TabIndex = 137;
            this.btnCCB.Text = "Comum";
            this.btnCCB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCCB.UseVisualStyleBackColor = true;
            this.btnCCB.Click += new System.EventHandler(this.btnCCB_Click);
            // 
            // gridCCB
            // 
            this.gridCCB.AllowUserToAddRows = false;
            this.gridCCB.AllowUserToDeleteRows = false;
            this.gridCCB.AllowUserToResizeRows = false;
            this.gridCCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCCB.BackgroundColor = System.Drawing.Color.White;
            this.gridCCB.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCCB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridCCB.ColumnHeadersHeight = 17;
            this.gridCCB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCCB.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCCB.EnableHeadersVisualStyles = false;
            this.gridCCB.Location = new System.Drawing.Point(6, 36);
            this.gridCCB.MultiSelect = false;
            this.gridCCB.Name = "gridCCB";
            this.gridCCB.ReadOnly = true;
            this.gridCCB.RowHeadersVisible = false;
            this.gridCCB.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCCB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCCB.Size = new System.Drawing.Size(591, 245);
            this.gridCCB.TabIndex = 135;
            this.gridCCB.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCCB_CellDoubleClick);
            this.gridCCB.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCCB_RowStateChanged);
            this.gridCCB.SelectionChanged += new System.EventHandler(this.gridCCB_SelectionChanged);
            // 
            // imgSolicita
            // 
            this.imgSolicita.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSolicita.ImageStream")));
            this.imgSolicita.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSolicita.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgSolicita.Images.SetKeyName(1, "BolaVermelha.ico");
            this.imgSolicita.Images.SetKeyName(2, "BolaAmarela.ico");
            this.imgSolicita.Images.SetKeyName(3, "BolaAzul.ico");
            // 
            // lblLegenda
            // 
            this.lblLegenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLegenda.AutoSize = true;
            this.lblLegenda.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLegenda.Location = new System.Drawing.Point(4, 359);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(195, 13);
            this.lblLegenda.TabIndex = 62;
            this.lblLegenda.Text = "Legenda - Solicitações de Testes para: ";
            // 
            // lblOficial
            // 
            this.lblOficial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOficial.AutoSize = true;
            this.lblOficial.Location = new System.Drawing.Point(308, 379);
            this.lblOficial.Name = "lblOficial";
            this.lblOficial.Size = new System.Drawing.Size(66, 13);
            this.lblOficial.TabIndex = 61;
            this.lblOficial.Text = "Oficialização";
            // 
            // pctOficial
            // 
            this.pctOficial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctOficial.Location = new System.Drawing.Point(291, 375);
            this.pctOficial.Name = "pctOficial";
            this.pctOficial.Size = new System.Drawing.Size(16, 20);
            this.pctOficial.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctOficial.TabIndex = 60;
            this.pctOficial.TabStop = false;
            // 
            // lblCulto
            // 
            this.lblCulto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCulto.AutoSize = true;
            this.lblCulto.Location = new System.Drawing.Point(221, 379);
            this.lblCulto.Name = "lblCulto";
            this.lblCulto.Size = new System.Drawing.Size(64, 13);
            this.lblCulto.TabIndex = 59;
            this.lblCulto.Text = "Culto Oficial";
            // 
            // pctCulto
            // 
            this.pctCulto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctCulto.Location = new System.Drawing.Point(204, 375);
            this.pctCulto.Name = "pctCulto";
            this.pctCulto.Size = new System.Drawing.Size(16, 20);
            this.pctCulto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctCulto.TabIndex = 58;
            this.pctCulto.TabStop = false;
            // 
            // lblRjm
            // 
            this.lblRjm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRjm.AutoSize = true;
            this.lblRjm.Location = new System.Drawing.Point(22, 379);
            this.lblRjm.Name = "lblRjm";
            this.lblRjm.Size = new System.Drawing.Size(98, 13);
            this.lblRjm.TabIndex = 57;
            this.lblRjm.Text = "Reunião de Jovens";
            // 
            // pctRjm
            // 
            this.pctRjm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctRjm.Location = new System.Drawing.Point(5, 375);
            this.pctRjm.Name = "pctRjm";
            this.pctRjm.Size = new System.Drawing.Size(16, 20);
            this.pctRjm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctRjm.TabIndex = 56;
            this.pctRjm.TabStop = false;
            // 
            // lblMeiaHora
            // 
            this.lblMeiaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMeiaHora.AutoSize = true;
            this.lblMeiaHora.Location = new System.Drawing.Point(143, 379);
            this.lblMeiaHora.Name = "lblMeiaHora";
            this.lblMeiaHora.Size = new System.Drawing.Size(55, 13);
            this.lblMeiaHora.TabIndex = 55;
            this.lblMeiaHora.Text = "Meia Hora";
            // 
            // pctMeiaHora
            // 
            this.pctMeiaHora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctMeiaHora.Location = new System.Drawing.Point(126, 375);
            this.pctMeiaHora.Name = "pctMeiaHora";
            this.pctMeiaHora.Size = new System.Drawing.Size(16, 20);
            this.pctMeiaHora.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctMeiaHora.TabIndex = 54;
            this.pctMeiaHora.TabStop = false;
            // 
            // lblTroca
            // 
            this.lblTroca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTroca.AutoSize = true;
            this.lblTroca.Location = new System.Drawing.Point(397, 379);
            this.lblTroca.Name = "lblTroca";
            this.lblTroca.Size = new System.Drawing.Size(96, 13);
            this.lblTroca.TabIndex = 64;
            this.lblTroca.Text = "Troca Instrumento";
            // 
            // pctTroca
            // 
            this.pctTroca.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctTroca.Location = new System.Drawing.Point(380, 375);
            this.pctTroca.Name = "pctTroca";
            this.pctTroca.Size = new System.Drawing.Size(16, 20);
            this.pctTroca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctTroca.TabIndex = 63;
            this.pctTroca.TabStop = false;
            // 
            // tabRegiao
            // 
            this.tabRegiao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRegiao.Controls.Add(this.cboRegiao);
            this.tabRegiao.Controls.Add(this.gridRegiao);
            this.tabRegiao.Controls.Add(this.btnSelReg);
            this.tabRegiao.Location = new System.Drawing.Point(4, 22);
            this.tabRegiao.Name = "tabRegiao";
            this.tabRegiao.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegiao.Size = new System.Drawing.Size(607, 326);
            this.tabRegiao.TabIndex = 3;
            this.tabRegiao.Text = "Microrregião";
            // 
            // gridRegiao
            // 
            this.gridRegiao.AllowUserToAddRows = false;
            this.gridRegiao.AllowUserToDeleteRows = false;
            this.gridRegiao.AllowUserToResizeRows = false;
            this.gridRegiao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridRegiao.BackgroundColor = System.Drawing.Color.White;
            this.gridRegiao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegiao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
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
            this.gridRegiao.Size = new System.Drawing.Size(591, 245);
            this.gridRegiao.TabIndex = 137;
            this.gridRegiao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellDoubleClick);
            this.gridRegiao.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridRegiao_RowStateChanged);
            this.gridRegiao.SelectionChanged += new System.EventHandler(this.gridRegiao_SelectionChanged);
            // 
            // btnSelReg
            // 
            this.btnSelReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelReg.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSelReg.Enabled = false;
            this.btnSelReg.Location = new System.Drawing.Point(507, 287);
            this.btnSelReg.Name = "btnSelReg";
            this.btnSelReg.Size = new System.Drawing.Size(90, 30);
            this.btnSelReg.TabIndex = 138;
            this.btnSelReg.Text = "&Selecionar";
            this.tipRegiao.SetToolTip(this.btnSelReg, "Selecionar");
            this.btnSelReg.UseVisualStyleBackColor = true;
            this.btnSelReg.Click += new System.EventHandler(this.btnSelReg_Click);
            // 
            // cboRegiao
            // 
            this.cboRegiao.FormattingEnabled = true;
            this.cboRegiao.Location = new System.Drawing.Point(6, 7);
            this.cboRegiao.Name = "cboRegiao";
            this.cboRegiao.Size = new System.Drawing.Size(180, 21);
            this.cboRegiao.TabIndex = 139;
            this.tipRegiao.SetToolTip(this.cboRegiao, "Selecione a microrregião");
            this.cboRegiao.SelectionChangeCommitted += new System.EventHandler(this.cboRegiao_SelectionChangeCommitted);
            // 
            // frmPesquisaSolicita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(628, 398);
            this.Controls.Add(this.lblTroca);
            this.Controls.Add(this.pctTroca);
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.lblOficial);
            this.Controls.Add(this.pctOficial);
            this.Controls.Add(this.lblCulto);
            this.Controls.Add(this.pctCulto);
            this.Controls.Add(this.lblRjm);
            this.Controls.Add(this.pctRjm);
            this.Controls.Add(this.lblMeiaHora);
            this.Controls.Add(this.pctMeiaHora);
            this.Controls.Add(this.tabSolicita);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPesquisaSolicita";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Solicitação de Teste";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPesquisaSolicita_FormClosed);
            this.Load += new System.EventHandler(this.frmPesquisaSolicita_Load);
            this.tabSolicita.ResumeLayout(false);
            this.tabPes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPes)).EndInit();
            this.tabComum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCCB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOficial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCulto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRjm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctMeiaHora)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTroca)).EndInit();
            this.tabRegiao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private BLL.validacoes.Controles.tabControlPersonal tabSolicita;
        private System.Windows.Forms.TabPage tabPes;
        private System.Windows.Forms.DataGridView gridPes;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSelPes;
        private System.Windows.Forms.ImageList imgSolicita;
        private System.Windows.Forms.Label lblDescPessoa;
        private System.Windows.Forms.Label lblCodPessoa;
        private System.Windows.Forms.Button btnPessoa;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.Label lblOficial;
        private System.Windows.Forms.PictureBox pctOficial;
        private System.Windows.Forms.Label lblCulto;
        private System.Windows.Forms.PictureBox pctCulto;
        private System.Windows.Forms.Label lblRjm;
        private System.Windows.Forms.PictureBox pctRjm;
        private System.Windows.Forms.Label lblMeiaHora;
        private System.Windows.Forms.PictureBox pctMeiaHora;
        private System.Windows.Forms.Label lblTroca;
        private System.Windows.Forms.PictureBox pctTroca;
        private System.Windows.Forms.TabPage tabComum;
        private System.Windows.Forms.Label lblDescCCB;
        private System.Windows.Forms.Label lblCodCCB;
        private System.Windows.Forms.Button btnCCB;
        private System.Windows.Forms.DataGridView gridCCB;
        private System.Windows.Forms.Button btnSelCCB;
        private System.Windows.Forms.TabPage tabRegiao;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegiao;
        private System.Windows.Forms.DataGridView gridRegiao;
        private System.Windows.Forms.Button btnSelReg;
    }
}