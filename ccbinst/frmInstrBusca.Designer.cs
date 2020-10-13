namespace ccbinst
{
    partial class frmInstrBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInstrBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipInst = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.imgInst = new System.Windows.Forms.ImageList(this.components);
            this.lblNaoRecomenda = new System.Windows.Forms.Label();
            this.pctNaoRecomendado = new System.Windows.Forms.PictureBox();
            this.lblPermitido = new System.Windows.Forms.Label();
            this.pctPermitido = new System.Windows.Forms.PictureBox();
            this.lblProibido = new System.Windows.Forms.Label();
            this.pctProibido = new System.Windows.Forms.PictureBox();
            this.tabInstr = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.btnDescVisual = new System.Windows.Forms.Button();
            this.btnDescIns = new System.Windows.Forms.Button();
            this.btnDescEditar = new System.Windows.Forms.Button();
            this.btnDescExc = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCodVisual = new System.Windows.Forms.Button();
            this.btnCodIns = new System.Windows.Forms.Button();
            this.btnCodEditar = new System.Windows.Forms.Button();
            this.btnCodExc = new System.Windows.Forms.Button();
            this.btnCod = new System.Windows.Forms.Button();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabSituacao = new System.Windows.Forms.TabPage();
            this.cboSituacao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.btnSitVisual = new System.Windows.Forms.Button();
            this.btnSitIns = new System.Windows.Forms.Button();
            this.btnSitEditar = new System.Windows.Forms.Button();
            this.btnSitExc = new System.Windows.Forms.Button();
            this.gridSituacao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pctNaoRecomendado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPermitido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctProibido)).BeginInit();
            this.tabInstr.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabSituacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSituacao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(604, 443);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipInst.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // imgInst
            // 
            this.imgInst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgInst.ImageStream")));
            this.imgInst.TransparentColor = System.Drawing.Color.Transparent;
            this.imgInst.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgInst.Images.SetKeyName(1, "BolaAmarela.ico");
            this.imgInst.Images.SetKeyName(2, "BolaVermelha.ico");
            // 
            // lblNaoRecomenda
            // 
            this.lblNaoRecomenda.AutoSize = true;
            this.lblNaoRecomenda.Location = new System.Drawing.Point(97, 446);
            this.lblNaoRecomenda.Name = "lblNaoRecomenda";
            this.lblNaoRecomenda.Size = new System.Drawing.Size(97, 13);
            this.lblNaoRecomenda.TabIndex = 36;
            this.lblNaoRecomenda.Text = "Não Recomendado";
            // 
            // pctNaoRecomendado
            // 
            this.pctNaoRecomendado.Location = new System.Drawing.Point(81, 443);
            this.pctNaoRecomendado.Name = "pctNaoRecomendado";
            this.pctNaoRecomendado.Size = new System.Drawing.Size(16, 20);
            this.pctNaoRecomendado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctNaoRecomendado.TabIndex = 35;
            this.pctNaoRecomendado.TabStop = false;
            // 
            // lblPermitido
            // 
            this.lblPermitido.AutoSize = true;
            this.lblPermitido.Location = new System.Drawing.Point(24, 446);
            this.lblPermitido.Name = "lblPermitido";
            this.lblPermitido.Size = new System.Drawing.Size(51, 13);
            this.lblPermitido.TabIndex = 34;
            this.lblPermitido.Text = "Permitido";
            // 
            // pctPermitido
            // 
            this.pctPermitido.Location = new System.Drawing.Point(7, 443);
            this.pctPermitido.Name = "pctPermitido";
            this.pctPermitido.Size = new System.Drawing.Size(16, 20);
            this.pctPermitido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctPermitido.TabIndex = 33;
            this.pctPermitido.TabStop = false;
            // 
            // lblProibido
            // 
            this.lblProibido.AutoSize = true;
            this.lblProibido.Location = new System.Drawing.Point(216, 446);
            this.lblProibido.Name = "lblProibido";
            this.lblProibido.Size = new System.Drawing.Size(45, 13);
            this.lblProibido.TabIndex = 38;
            this.lblProibido.Text = "Proibido";
            // 
            // pctProibido
            // 
            this.pctProibido.Location = new System.Drawing.Point(200, 443);
            this.pctProibido.Name = "pctProibido";
            this.pctProibido.Size = new System.Drawing.Size(16, 20);
            this.pctProibido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctProibido.TabIndex = 37;
            this.pctProibido.TabStop = false;
            // 
            // tabInstr
            // 
            this.tabInstr.Controls.Add(this.tabDesc);
            this.tabInstr.Controls.Add(this.tabCodigo);
            this.tabInstr.Controls.Add(this.tabSituacao);
            this.tabInstr.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabInstr.Location = new System.Drawing.Point(7, 8);
            this.tabInstr.Name = "tabInstr";
            this.tabInstr.SelectedIndex = 0;
            this.tabInstr.Size = new System.Drawing.Size(687, 429);
            this.tabInstr.TabIndex = 0;
            this.tabInstr.SelectedIndexChanged += new System.EventHandler(this.tabInstr_SelectedIndexChanged);
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
            this.tabDesc.ForeColor = System.Drawing.Color.Black;
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(679, 403);
            this.tabDesc.TabIndex = 1;
            this.tabDesc.Text = "Descrição";
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
            this.tipInst.SetToolTip(this.txtDesc, "Descrição para pesquisar");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
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
            this.gridDesc.Size = new System.Drawing.Size(665, 322);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // btnDescVisual
            // 
            this.btnDescVisual.AccessibleDescription = "";
            this.btnDescVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescVisual.Enabled = false;
            this.btnDescVisual.Location = new System.Drawing.Point(299, 364);
            this.btnDescVisual.Name = "btnDescVisual";
            this.btnDescVisual.Size = new System.Drawing.Size(90, 30);
            this.btnDescVisual.TabIndex = 3;
            this.btnDescVisual.Text = "&Visualizar";
            this.tipInst.SetToolTip(this.btnDescVisual, "Visualizar");
            this.btnDescVisual.UseVisualStyleBackColor = true;
            this.btnDescVisual.Click += new System.EventHandler(this.btnDescVisual_Click);
            // 
            // btnDescIns
            // 
            this.btnDescIns.AccessibleDescription = "";
            this.btnDescIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescIns.Enabled = false;
            this.btnDescIns.Location = new System.Drawing.Point(393, 364);
            this.btnDescIns.Name = "btnDescIns";
            this.btnDescIns.Size = new System.Drawing.Size(90, 30);
            this.btnDescIns.TabIndex = 4;
            this.btnDescIns.Text = "&Inserir";
            this.tipInst.SetToolTip(this.btnDescIns, "Inserir");
            this.btnDescIns.UseVisualStyleBackColor = true;
            this.btnDescIns.Click += new System.EventHandler(this.btnDescIns_Click);
            // 
            // btnDescEditar
            // 
            this.btnDescEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescEditar.Enabled = false;
            this.btnDescEditar.Location = new System.Drawing.Point(487, 364);
            this.btnDescEditar.Name = "btnDescEditar";
            this.btnDescEditar.Size = new System.Drawing.Size(90, 30);
            this.btnDescEditar.TabIndex = 5;
            this.btnDescEditar.Text = "&Editar";
            this.tipInst.SetToolTip(this.btnDescEditar, "Editar");
            this.btnDescEditar.UseVisualStyleBackColor = true;
            this.btnDescEditar.Click += new System.EventHandler(this.btnDescEditar_Click);
            // 
            // btnDescExc
            // 
            this.btnDescExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescExc.Enabled = false;
            this.btnDescExc.Location = new System.Drawing.Point(581, 364);
            this.btnDescExc.Name = "btnDescExc";
            this.btnDescExc.Size = new System.Drawing.Size(90, 30);
            this.btnDescExc.TabIndex = 6;
            this.btnDescExc.Text = "E&xcluir";
            this.tipInst.SetToolTip(this.btnDescExc, "Excluir");
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
            this.tipInst.SetToolTip(this.btnDesc, "Pesquisar");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
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
            this.tabCodigo.ForeColor = System.Drawing.Color.Black;
            this.tabCodigo.Location = new System.Drawing.Point(4, 22);
            this.tabCodigo.Name = "tabCodigo";
            this.tabCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodigo.Size = new System.Drawing.Size(679, 403);
            this.tabCodigo.TabIndex = 0;
            this.tabCodigo.Text = "Código";
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
            this.tipInst.SetToolTip(this.txtCodigo, "Código para pesquisar");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnCodVisual
            // 
            this.btnCodVisual.AccessibleDescription = "";
            this.btnCodVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodVisual.Enabled = false;
            this.btnCodVisual.Location = new System.Drawing.Point(299, 364);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 3;
            this.btnCodVisual.Text = "&Visualizar";
            this.tipInst.SetToolTip(this.btnCodVisual, "Visualizar");
            this.btnCodVisual.UseVisualStyleBackColor = true;
            this.btnCodVisual.Click += new System.EventHandler(this.btnCodVisual_Click);
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(393, 364);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 4;
            this.btnCodIns.Text = "&Inserir";
            this.tipInst.SetToolTip(this.btnCodIns, "Inserir");
            this.btnCodIns.UseVisualStyleBackColor = true;
            this.btnCodIns.Click += new System.EventHandler(this.btnCodIns_Click);
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(487, 364);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 5;
            this.btnCodEditar.Text = "&Editar";
            this.tipInst.SetToolTip(this.btnCodEditar, "Editar");
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCodExc
            // 
            this.btnCodExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodExc.Enabled = false;
            this.btnCodExc.Location = new System.Drawing.Point(581, 364);
            this.btnCodExc.Name = "btnCodExc";
            this.btnCodExc.Size = new System.Drawing.Size(90, 30);
            this.btnCodExc.TabIndex = 6;
            this.btnCodExc.Text = "E&xcluir";
            this.tipInst.SetToolTip(this.btnCodExc, "Excluir");
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
            this.tipInst.SetToolTip(this.btnCod, "Pesquisar");
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
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
            this.gridCodigo.Size = new System.Drawing.Size(665, 322);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // tabSituacao
            // 
            this.tabSituacao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabSituacao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabSituacao.Controls.Add(this.cboSituacao);
            this.tabSituacao.Controls.Add(this.btnSitVisual);
            this.tabSituacao.Controls.Add(this.btnSitIns);
            this.tabSituacao.Controls.Add(this.btnSitEditar);
            this.tabSituacao.Controls.Add(this.btnSitExc);
            this.tabSituacao.Controls.Add(this.gridSituacao);
            this.tabSituacao.ForeColor = System.Drawing.Color.Black;
            this.tabSituacao.Location = new System.Drawing.Point(4, 22);
            this.tabSituacao.Name = "tabSituacao";
            this.tabSituacao.Padding = new System.Windows.Forms.Padding(3);
            this.tabSituacao.Size = new System.Drawing.Size(679, 403);
            this.tabSituacao.TabIndex = 2;
            this.tabSituacao.Text = "Situação";
            // 
            // cboSituacao
            // 
            this.cboSituacao.BackColor = System.Drawing.Color.White;
            this.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Items.AddRange(new object[] {
            "Permitido",
            "Não Recomendado",
            "Proibido"});
            this.cboSituacao.Location = new System.Drawing.Point(6, 7);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(150, 21);
            this.cboSituacao.TabIndex = 0;
            this.cboSituacao.SelectedIndexChanged += new System.EventHandler(this.cboSituacao_SelectedIndexChanged);
            // 
            // btnSitVisual
            // 
            this.btnSitVisual.AccessibleDescription = "";
            this.btnSitVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitVisual.Enabled = false;
            this.btnSitVisual.Location = new System.Drawing.Point(299, 364);
            this.btnSitVisual.Name = "btnSitVisual";
            this.btnSitVisual.Size = new System.Drawing.Size(90, 30);
            this.btnSitVisual.TabIndex = 2;
            this.btnSitVisual.Text = "&Visualizar";
            this.tipInst.SetToolTip(this.btnSitVisual, "Visualizar");
            this.btnSitVisual.UseVisualStyleBackColor = true;
            this.btnSitVisual.Click += new System.EventHandler(this.btnSitVisual_Click);
            // 
            // btnSitIns
            // 
            this.btnSitIns.AccessibleDescription = "";
            this.btnSitIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitIns.Enabled = false;
            this.btnSitIns.Location = new System.Drawing.Point(393, 364);
            this.btnSitIns.Name = "btnSitIns";
            this.btnSitIns.Size = new System.Drawing.Size(90, 30);
            this.btnSitIns.TabIndex = 3;
            this.btnSitIns.Text = "&Inserir";
            this.tipInst.SetToolTip(this.btnSitIns, "Inserir");
            this.btnSitIns.UseVisualStyleBackColor = true;
            this.btnSitIns.Click += new System.EventHandler(this.btnSitIns_Click);
            // 
            // btnSitEditar
            // 
            this.btnSitEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitEditar.Enabled = false;
            this.btnSitEditar.Location = new System.Drawing.Point(487, 364);
            this.btnSitEditar.Name = "btnSitEditar";
            this.btnSitEditar.Size = new System.Drawing.Size(90, 30);
            this.btnSitEditar.TabIndex = 4;
            this.btnSitEditar.Text = "&Editar";
            this.tipInst.SetToolTip(this.btnSitEditar, "Editar");
            this.btnSitEditar.UseVisualStyleBackColor = true;
            this.btnSitEditar.Click += new System.EventHandler(this.btnSitEditar_Click);
            // 
            // btnSitExc
            // 
            this.btnSitExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitExc.Enabled = false;
            this.btnSitExc.Location = new System.Drawing.Point(581, 364);
            this.btnSitExc.Name = "btnSitExc";
            this.btnSitExc.Size = new System.Drawing.Size(90, 30);
            this.btnSitExc.TabIndex = 5;
            this.btnSitExc.Text = "E&xcluir";
            this.tipInst.SetToolTip(this.btnSitExc, "Excluir");
            this.btnSitExc.UseVisualStyleBackColor = true;
            this.btnSitExc.Click += new System.EventHandler(this.btnSitExc_Click);
            // 
            // gridSituacao
            // 
            this.gridSituacao.AllowUserToAddRows = false;
            this.gridSituacao.AllowUserToDeleteRows = false;
            this.gridSituacao.AllowUserToResizeRows = false;
            this.gridSituacao.BackgroundColor = System.Drawing.Color.White;
            this.gridSituacao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSituacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridSituacao.ColumnHeadersHeight = 17;
            this.gridSituacao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSituacao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSituacao.EnableHeadersVisualStyles = false;
            this.gridSituacao.Location = new System.Drawing.Point(6, 36);
            this.gridSituacao.MultiSelect = false;
            this.gridSituacao.Name = "gridSituacao";
            this.gridSituacao.ReadOnly = true;
            this.gridSituacao.RowHeadersVisible = false;
            this.gridSituacao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSituacao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSituacao.Size = new System.Drawing.Size(665, 322);
            this.gridSituacao.TabIndex = 1;
            this.gridSituacao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSituacao_CellDoubleClick);
            this.gridSituacao.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridSituacao_RowStateChanged);
            this.gridSituacao.SelectionChanged += new System.EventHandler(this.gridSituacao_SelectionChanged);
            // 
            // frmInstrBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(702, 483);
            this.Controls.Add(this.lblProibido);
            this.Controls.Add(this.pctProibido);
            this.Controls.Add(this.tabInstr);
            this.Controls.Add(this.lblNaoRecomenda);
            this.Controls.Add(this.pctNaoRecomendado);
            this.Controls.Add(this.lblPermitido);
            this.Controls.Add(this.pctPermitido);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmInstrBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instrumentos";
            this.Load += new System.EventHandler(this.frmInstrBusca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctNaoRecomendado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPermitido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctProibido)).EndInit();
            this.tabInstr.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabSituacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSituacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipInst;
        private System.Windows.Forms.ImageList imgInst;
        private BLL.validacoes.Controles.tabControlPersonal tabInstr;
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
        private System.Windows.Forms.Label lblNaoRecomenda;
        private System.Windows.Forms.PictureBox pctNaoRecomendado;
        private System.Windows.Forms.Label lblPermitido;
        private System.Windows.Forms.PictureBox pctPermitido;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblProibido;
        private System.Windows.Forms.PictureBox pctProibido;
        private System.Windows.Forms.TabPage tabSituacao;
        private System.Windows.Forms.Button btnSitVisual;
        private System.Windows.Forms.Button btnSitIns;
        private System.Windows.Forms.Button btnSitEditar;
        private System.Windows.Forms.Button btnSitExc;
        private System.Windows.Forms.DataGridView gridSituacao;
        private BLL.validacoes.Controles.ComboBoxPersonal cboSituacao;
    }
}