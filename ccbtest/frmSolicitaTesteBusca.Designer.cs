namespace ccbtest
{
    partial class frmSolicitaTesteBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSolicitaTesteBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipRegiao = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.imgSolicita = new System.Windows.Forms.ImageList(this.components);
            this.lblLegenda = new System.Windows.Forms.Label();
            this.lblNegada = new System.Windows.Forms.Label();
            this.pctNegada = new System.Windows.Forms.PictureBox();
            this.lblCancelada = new System.Windows.Forms.Label();
            this.pctCancelada = new System.Windows.Forms.PictureBox();
            this.lblPendente = new System.Windows.Forms.Label();
            this.pctPendente = new System.Windows.Forms.PictureBox();
            this.lblAutoriza = new System.Windows.Forms.Label();
            this.pctAutoriza = new System.Windows.Forms.PictureBox();
            this.tabSolicitaTeste = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.btnCodImp = new System.Windows.Forms.Button();
            this.btnCodNegar = new System.Windows.Forms.Button();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCodVisual = new System.Windows.Forms.Button();
            this.btnCodIns = new System.Windows.Forms.Button();
            this.btnCodEditar = new System.Windows.Forms.Button();
            this.btnCodCancel = new System.Windows.Forms.Button();
            this.btnCod = new System.Windows.Forms.Button();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabPessoa = new System.Windows.Forms.TabPage();
            this.btnPesImp = new System.Windows.Forms.Button();
            this.btnPesNegar = new System.Windows.Forms.Button();
            this.lblDescPessoa = new System.Windows.Forms.Label();
            this.lblCodPessoa = new System.Windows.Forms.Label();
            this.gridPessoa = new System.Windows.Forms.DataGridView();
            this.btnPesVisual = new System.Windows.Forms.Button();
            this.btnPesIns = new System.Windows.Forms.Button();
            this.btnPesEditar = new System.Windows.Forms.Button();
            this.btnPesCancel = new System.Windows.Forms.Button();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.tabData = new System.Windows.Forms.TabPage();
            this.btnDataImp = new System.Windows.Forms.Button();
            this.btnDataNegar = new System.Windows.Forms.Button();
            this.btnDataFinal = new System.Windows.Forms.Button();
            this.btnDataInicial = new System.Windows.Forms.Button();
            this.lblA = new System.Windows.Forms.Label();
            this.txtDataInicial = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataFinal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnData = new System.Windows.Forms.Button();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.btnDataVisual = new System.Windows.Forms.Button();
            this.btnDataIns = new System.Windows.Forms.Button();
            this.btnDataEditar = new System.Windows.Forms.Button();
            this.btnDataCancel = new System.Windows.Forms.Button();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.btnSitImp = new System.Windows.Forms.Button();
            this.btnSitNegar = new System.Windows.Forms.Button();
            this.cboSituacao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.gridSituacao = new System.Windows.Forms.DataGridView();
            this.btnSitVisual = new System.Windows.Forms.Button();
            this.btnSitIns = new System.Windows.Forms.Button();
            this.btnSitEditar = new System.Windows.Forms.Button();
            this.btnSitCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctNegada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCancelada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPendente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAutoriza)).BeginInit();
            this.tabSolicitaTeste.SuspendLayout();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabPessoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoa)).BeginInit();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.tabStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSituacao)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(644, 386);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 35);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // imgSolicita
            // 
            this.imgSolicita.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSolicita.ImageStream")));
            this.imgSolicita.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSolicita.Images.SetKeyName(0, "Abertas.ico");
            this.imgSolicita.Images.SetKeyName(1, "finalizado.png");
            this.imgSolicita.Images.SetKeyName(2, "cancelado.png");
            this.imgSolicita.Images.SetKeyName(3, "negar.png");
            // 
            // lblLegenda
            // 
            this.lblLegenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLegenda.AutoSize = true;
            this.lblLegenda.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLegenda.Location = new System.Drawing.Point(5, 383);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(170, 13);
            this.lblLegenda.TabIndex = 73;
            this.lblLegenda.Text = "Legenda - Solicitações de Testes: ";
            // 
            // lblNegada
            // 
            this.lblNegada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNegada.AutoSize = true;
            this.lblNegada.Location = new System.Drawing.Point(269, 403);
            this.lblNegada.Name = "lblNegada";
            this.lblNegada.Size = new System.Drawing.Size(44, 13);
            this.lblNegada.TabIndex = 72;
            this.lblNegada.Text = "Negada";
            // 
            // pctNegada
            // 
            this.pctNegada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctNegada.Location = new System.Drawing.Point(252, 399);
            this.pctNegada.Name = "pctNegada";
            this.pctNegada.Size = new System.Drawing.Size(16, 20);
            this.pctNegada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctNegada.TabIndex = 71;
            this.pctNegada.TabStop = false;
            // 
            // lblCancelada
            // 
            this.lblCancelada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCancelada.AutoSize = true;
            this.lblCancelada.Location = new System.Drawing.Point(186, 403);
            this.lblCancelada.Name = "lblCancelada";
            this.lblCancelada.Size = new System.Drawing.Size(57, 13);
            this.lblCancelada.TabIndex = 70;
            this.lblCancelada.Text = "Cancelada";
            // 
            // pctCancelada
            // 
            this.pctCancelada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctCancelada.Location = new System.Drawing.Point(169, 399);
            this.pctCancelada.Name = "pctCancelada";
            this.pctCancelada.Size = new System.Drawing.Size(16, 20);
            this.pctCancelada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctCancelada.TabIndex = 69;
            this.pctCancelada.TabStop = false;
            // 
            // lblPendente
            // 
            this.lblPendente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPendente.AutoSize = true;
            this.lblPendente.Location = new System.Drawing.Point(23, 403);
            this.lblPendente.Name = "lblPendente";
            this.lblPendente.Size = new System.Drawing.Size(53, 13);
            this.lblPendente.TabIndex = 68;
            this.lblPendente.Text = "Pendente";
            // 
            // pctPendente
            // 
            this.pctPendente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctPendente.Location = new System.Drawing.Point(6, 399);
            this.pctPendente.Name = "pctPendente";
            this.pctPendente.Size = new System.Drawing.Size(16, 20);
            this.pctPendente.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctPendente.TabIndex = 67;
            this.pctPendente.TabStop = false;
            // 
            // lblAutoriza
            // 
            this.lblAutoriza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutoriza.AutoSize = true;
            this.lblAutoriza.Location = new System.Drawing.Point(101, 403);
            this.lblAutoriza.Name = "lblAutoriza";
            this.lblAutoriza.Size = new System.Drawing.Size(59, 13);
            this.lblAutoriza.TabIndex = 66;
            this.lblAutoriza.Text = "Autorizada";
            // 
            // pctAutoriza
            // 
            this.pctAutoriza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctAutoriza.Location = new System.Drawing.Point(84, 399);
            this.pctAutoriza.Name = "pctAutoriza";
            this.pctAutoriza.Size = new System.Drawing.Size(16, 20);
            this.pctAutoriza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAutoriza.TabIndex = 65;
            this.pctAutoriza.TabStop = false;
            // 
            // tabSolicitaTeste
            // 
            this.tabSolicitaTeste.Controls.Add(this.tabCodigo);
            this.tabSolicitaTeste.Controls.Add(this.tabPessoa);
            this.tabSolicitaTeste.Controls.Add(this.tabData);
            this.tabSolicitaTeste.Controls.Add(this.tabStatus);
            this.tabSolicitaTeste.Location = new System.Drawing.Point(6, 6);
            this.tabSolicitaTeste.Name = "tabSolicitaTeste";
            this.tabSolicitaTeste.SelectedIndex = 0;
            this.tabSolicitaTeste.Size = new System.Drawing.Size(726, 376);
            this.tabSolicitaTeste.TabIndex = 31;
            this.tabSolicitaTeste.SelectedIndexChanged += new System.EventHandler(this.tabSolicitaTeste_SelectedIndexChanged);
            // 
            // tabCodigo
            // 
            this.tabCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCodigo.Controls.Add(this.btnCodImp);
            this.tabCodigo.Controls.Add(this.btnCodNegar);
            this.tabCodigo.Controls.Add(this.txtCodigo);
            this.tabCodigo.Controls.Add(this.btnCodVisual);
            this.tabCodigo.Controls.Add(this.btnCodIns);
            this.tabCodigo.Controls.Add(this.btnCodEditar);
            this.tabCodigo.Controls.Add(this.btnCodCancel);
            this.tabCodigo.Controls.Add(this.btnCod);
            this.tabCodigo.Controls.Add(this.gridCodigo);
            this.tabCodigo.Location = new System.Drawing.Point(4, 22);
            this.tabCodigo.Name = "tabCodigo";
            this.tabCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodigo.Size = new System.Drawing.Size(718, 350);
            this.tabCodigo.TabIndex = 2;
            this.tabCodigo.Text = "Solicitação";
            // 
            // btnCodImp
            // 
            this.btnCodImp.AccessibleDescription = "";
            this.btnCodImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodImp.Enabled = false;
            this.btnCodImp.Location = new System.Drawing.Point(6, 312);
            this.btnCodImp.Name = "btnCodImp";
            this.btnCodImp.Size = new System.Drawing.Size(90, 30);
            this.btnCodImp.TabIndex = 155;
            this.btnCodImp.Text = "I&mprimir";
            this.tipRegiao.SetToolTip(this.btnCodImp, "Imprimir");
            this.btnCodImp.UseVisualStyleBackColor = true;
            // 
            // btnCodNegar
            // 
            this.btnCodNegar.AccessibleDescription = "";
            this.btnCodNegar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodNegar.Enabled = false;
            this.btnCodNegar.Location = new System.Drawing.Point(102, 312);
            this.btnCodNegar.Name = "btnCodNegar";
            this.btnCodNegar.Size = new System.Drawing.Size(90, 30);
            this.btnCodNegar.TabIndex = 15;
            this.btnCodNegar.Text = "&Negar";
            this.btnCodNegar.UseVisualStyleBackColor = true;
            this.btnCodNegar.Click += new System.EventHandler(this.btnCodNegar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Location = new System.Drawing.Point(7, 7);
            this.txtCodigo.MaxLength = 100;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 21);
            this.txtCodigo.TabIndex = 7;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnCodVisual
            // 
            this.btnCodVisual.AccessibleDescription = "";
            this.btnCodVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodVisual.Enabled = false;
            this.btnCodVisual.Location = new System.Drawing.Point(338, 312);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 10;
            this.btnCodVisual.Text = "&Visualizar";
            this.btnCodVisual.UseVisualStyleBackColor = true;
            this.btnCodVisual.Click += new System.EventHandler(this.btnCodVisual_Click);
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(432, 312);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 11;
            this.btnCodIns.Text = "&Inserir";
            this.btnCodIns.UseVisualStyleBackColor = true;
            this.btnCodIns.Click += new System.EventHandler(this.btnCodIns_Click);
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(526, 312);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 12;
            this.btnCodEditar.Text = "&Editar";
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCodCancel
            // 
            this.btnCodCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodCancel.Enabled = false;
            this.btnCodCancel.Location = new System.Drawing.Point(620, 312);
            this.btnCodCancel.Name = "btnCodCancel";
            this.btnCodCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCodCancel.TabIndex = 13;
            this.btnCodCancel.Text = "&Cancelar";
            this.tipRegiao.SetToolTip(this.btnCodCancel, "Cancelar");
            this.btnCodCancel.UseVisualStyleBackColor = true;
            this.btnCodCancel.Click += new System.EventHandler(this.btnCodCancel_Click);
            // 
            // btnCod
            // 
            this.btnCod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCod.Image = global::ccbtest.Properties.Resources.Lupa;
            this.btnCod.Location = new System.Drawing.Point(160, 6);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(23, 23);
            this.btnCod.TabIndex = 8;
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCodigo_Click);
            // 
            // gridCodigo
            // 
            this.gridCodigo.AllowUserToAddRows = false;
            this.gridCodigo.AllowUserToDeleteRows = false;
            this.gridCodigo.AllowUserToResizeRows = false;
            this.gridCodigo.BackgroundColor = System.Drawing.Color.White;
            this.gridCodigo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCodigo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.gridCodigo.Size = new System.Drawing.Size(704, 270);
            this.gridCodigo.TabIndex = 9;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // tabPessoa
            // 
            this.tabPessoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPessoa.Controls.Add(this.btnPesImp);
            this.tabPessoa.Controls.Add(this.btnPesNegar);
            this.tabPessoa.Controls.Add(this.lblDescPessoa);
            this.tabPessoa.Controls.Add(this.lblCodPessoa);
            this.tabPessoa.Controls.Add(this.gridPessoa);
            this.tabPessoa.Controls.Add(this.btnPesVisual);
            this.tabPessoa.Controls.Add(this.btnPesIns);
            this.tabPessoa.Controls.Add(this.btnPesEditar);
            this.tabPessoa.Controls.Add(this.btnPesCancel);
            this.tabPessoa.Controls.Add(this.btnPessoa);
            this.tabPessoa.Location = new System.Drawing.Point(4, 22);
            this.tabPessoa.Name = "tabPessoa";
            this.tabPessoa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPessoa.Size = new System.Drawing.Size(718, 350);
            this.tabPessoa.TabIndex = 1;
            this.tabPessoa.Text = "Candidato(a)";
            // 
            // btnPesImp
            // 
            this.btnPesImp.AccessibleDescription = "";
            this.btnPesImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesImp.Enabled = false;
            this.btnPesImp.Location = new System.Drawing.Point(6, 312);
            this.btnPesImp.Name = "btnPesImp";
            this.btnPesImp.Size = new System.Drawing.Size(90, 30);
            this.btnPesImp.TabIndex = 155;
            this.btnPesImp.Text = "I&mprimir";
            this.tipRegiao.SetToolTip(this.btnPesImp, "Imprimir");
            this.btnPesImp.UseVisualStyleBackColor = true;
            this.btnPesImp.Click += new System.EventHandler(this.btnPesImp_Click);
            // 
            // btnPesNegar
            // 
            this.btnPesNegar.AccessibleDescription = "";
            this.btnPesNegar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesNegar.Enabled = false;
            this.btnPesNegar.Location = new System.Drawing.Point(102, 312);
            this.btnPesNegar.Name = "btnPesNegar";
            this.btnPesNegar.Size = new System.Drawing.Size(90, 30);
            this.btnPesNegar.TabIndex = 132;
            this.btnPesNegar.Text = "&Negar";
            this.btnPesNegar.UseVisualStyleBackColor = true;
            this.btnPesNegar.Click += new System.EventHandler(this.btnPesNegar_Click);
            // 
            // lblDescPessoa
            // 
            this.lblDescPessoa.Enabled = false;
            this.lblDescPessoa.Location = new System.Drawing.Point(102, 10);
            this.lblDescPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescPessoa.Name = "lblDescPessoa";
            this.lblDescPessoa.Size = new System.Drawing.Size(608, 17);
            this.lblDescPessoa.TabIndex = 130;
            // 
            // lblCodPessoa
            // 
            this.lblCodPessoa.Location = new System.Drawing.Point(115, 6);
            this.lblCodPessoa.Name = "lblCodPessoa";
            this.lblCodPessoa.Size = new System.Drawing.Size(46, 17);
            this.lblCodPessoa.TabIndex = 131;
            this.lblCodPessoa.Visible = false;
            this.lblCodPessoa.TextChanged += new System.EventHandler(this.lblCodPessoa_TextChanged);
            // 
            // gridPessoa
            // 
            this.gridPessoa.AllowUserToAddRows = false;
            this.gridPessoa.AllowUserToDeleteRows = false;
            this.gridPessoa.AllowUserToResizeRows = false;
            this.gridPessoa.BackgroundColor = System.Drawing.Color.White;
            this.gridPessoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPessoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridPessoa.ColumnHeadersHeight = 17;
            this.gridPessoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridPessoa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPessoa.EnableHeadersVisualStyles = false;
            this.gridPessoa.Location = new System.Drawing.Point(6, 36);
            this.gridPessoa.MultiSelect = false;
            this.gridPessoa.Name = "gridPessoa";
            this.gridPessoa.ReadOnly = true;
            this.gridPessoa.RowHeadersVisible = false;
            this.gridPessoa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPessoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPessoa.Size = new System.Drawing.Size(704, 270);
            this.gridPessoa.TabIndex = 2;
            this.gridPessoa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPessoa_CellDoubleClick);
            this.gridPessoa.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridPessoa_RowStateChanged);
            this.gridPessoa.SelectionChanged += new System.EventHandler(this.gridPessoa_SelectionChanged);
            // 
            // btnPesVisual
            // 
            this.btnPesVisual.AccessibleDescription = "";
            this.btnPesVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesVisual.Enabled = false;
            this.btnPesVisual.Location = new System.Drawing.Point(338, 312);
            this.btnPesVisual.Name = "btnPesVisual";
            this.btnPesVisual.Size = new System.Drawing.Size(90, 30);
            this.btnPesVisual.TabIndex = 3;
            this.btnPesVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnPesVisual, "Visualizar");
            this.btnPesVisual.UseVisualStyleBackColor = true;
            this.btnPesVisual.Click += new System.EventHandler(this.btnPesVisual_Click);
            // 
            // btnPesIns
            // 
            this.btnPesIns.AccessibleDescription = "";
            this.btnPesIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesIns.Enabled = false;
            this.btnPesIns.Location = new System.Drawing.Point(432, 312);
            this.btnPesIns.Name = "btnPesIns";
            this.btnPesIns.Size = new System.Drawing.Size(90, 30);
            this.btnPesIns.TabIndex = 4;
            this.btnPesIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnPesIns, "Inserir");
            this.btnPesIns.UseVisualStyleBackColor = true;
            this.btnPesIns.Click += new System.EventHandler(this.btnPesIns_Click);
            // 
            // btnPesEditar
            // 
            this.btnPesEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesEditar.Enabled = false;
            this.btnPesEditar.Location = new System.Drawing.Point(526, 312);
            this.btnPesEditar.Name = "btnPesEditar";
            this.btnPesEditar.Size = new System.Drawing.Size(90, 30);
            this.btnPesEditar.TabIndex = 5;
            this.btnPesEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnPesEditar, "Editar");
            this.btnPesEditar.UseVisualStyleBackColor = true;
            this.btnPesEditar.Click += new System.EventHandler(this.btnPesEditar_Click);
            // 
            // btnPesCancel
            // 
            this.btnPesCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesCancel.Enabled = false;
            this.btnPesCancel.Location = new System.Drawing.Point(620, 312);
            this.btnPesCancel.Name = "btnPesCancel";
            this.btnPesCancel.Size = new System.Drawing.Size(90, 30);
            this.btnPesCancel.TabIndex = 6;
            this.btnPesCancel.Text = "&Cancelar";
            this.tipRegiao.SetToolTip(this.btnPesCancel, "Cancelar");
            this.btnPesCancel.UseVisualStyleBackColor = true;
            this.btnPesCancel.Click += new System.EventHandler(this.btnPesCancel_Click);
            // 
            // btnPessoa
            // 
            this.btnPessoa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPessoa.Image = global::ccbtest.Properties.Resources.PesquisaOS;
            this.btnPessoa.Location = new System.Drawing.Point(6, 5);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(90, 26);
            this.btnPessoa.TabIndex = 129;
            this.btnPessoa.Text = "Pessoa";
            this.btnPessoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabData.Controls.Add(this.btnDataImp);
            this.tabData.Controls.Add(this.btnDataNegar);
            this.tabData.Controls.Add(this.btnDataFinal);
            this.tabData.Controls.Add(this.btnDataInicial);
            this.tabData.Controls.Add(this.lblA);
            this.tabData.Controls.Add(this.txtDataInicial);
            this.tabData.Controls.Add(this.txtDataFinal);
            this.tabData.Controls.Add(this.btnData);
            this.tabData.Controls.Add(this.gridData);
            this.tabData.Controls.Add(this.btnDataVisual);
            this.tabData.Controls.Add(this.btnDataIns);
            this.tabData.Controls.Add(this.btnDataEditar);
            this.tabData.Controls.Add(this.btnDataCancel);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(718, 350);
            this.tabData.TabIndex = 5;
            this.tabData.Text = "Data";
            // 
            // btnDataImp
            // 
            this.btnDataImp.AccessibleDescription = "";
            this.btnDataImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataImp.Enabled = false;
            this.btnDataImp.Location = new System.Drawing.Point(6, 312);
            this.btnDataImp.Name = "btnDataImp";
            this.btnDataImp.Size = new System.Drawing.Size(90, 30);
            this.btnDataImp.TabIndex = 157;
            this.btnDataImp.Text = "I&mprimir";
            this.tipRegiao.SetToolTip(this.btnDataImp, "Imprimir");
            this.btnDataImp.UseVisualStyleBackColor = true;
            this.btnDataImp.Click += new System.EventHandler(this.btnDataImp_Click);
            // 
            // btnDataNegar
            // 
            this.btnDataNegar.AccessibleDescription = "";
            this.btnDataNegar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataNegar.Enabled = false;
            this.btnDataNegar.Location = new System.Drawing.Point(102, 312);
            this.btnDataNegar.Name = "btnDataNegar";
            this.btnDataNegar.Size = new System.Drawing.Size(90, 30);
            this.btnDataNegar.TabIndex = 156;
            this.btnDataNegar.Text = "&Negar";
            this.btnDataNegar.UseVisualStyleBackColor = true;
            this.btnDataNegar.Click += new System.EventHandler(this.btnDataNegar_Click);
            // 
            // btnDataFinal
            // 
            this.btnDataFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataFinal.BackgroundImage = global::ccbtest.Properties.Resources.depois;
            this.btnDataFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDataFinal.Location = new System.Drawing.Point(188, 8);
            this.btnDataFinal.Name = "btnDataFinal";
            this.btnDataFinal.Size = new System.Drawing.Size(18, 19);
            this.btnDataFinal.TabIndex = 155;
            this.tipRegiao.SetToolTip(this.btnDataFinal, "Definir data máxima");
            this.btnDataFinal.UseVisualStyleBackColor = true;
            this.btnDataFinal.Click += new System.EventHandler(this.btnDataFinal_Click);
            // 
            // btnDataInicial
            // 
            this.btnDataInicial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataInicial.BackgroundImage = global::ccbtest.Properties.Resources.antes;
            this.btnDataInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataInicial.Location = new System.Drawing.Point(78, 8);
            this.btnDataInicial.Name = "btnDataInicial";
            this.btnDataInicial.Size = new System.Drawing.Size(18, 19);
            this.btnDataInicial.TabIndex = 154;
            this.tipRegiao.SetToolTip(this.btnDataInicial, "Definir data mínima");
            this.btnDataInicial.UseVisualStyleBackColor = true;
            this.btnDataInicial.Click += new System.EventHandler(this.btnDataInicial_Click);
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(102, 11);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(13, 13);
            this.lblA.TabIndex = 153;
            this.lblA.Text = "à";
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.BackColor = System.Drawing.Color.White;
            this.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataInicial.Location = new System.Drawing.Point(7, 7);
            this.txtDataInicial.MaxLength = 10;
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(90, 21);
            this.txtDataInicial.TabIndex = 152;
            this.tipRegiao.SetToolTip(this.txtDataInicial, "Data Inicial");
            this.txtDataInicial.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataInicial.Enter += new System.EventHandler(this.txtDataInicial_Enter);
            this.txtDataInicial.Leave += new System.EventHandler(this.txtDataInicial_Leave);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.BackColor = System.Drawing.Color.White;
            this.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataFinal.Location = new System.Drawing.Point(117, 7);
            this.txtDataFinal.MaxLength = 100;
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(90, 21);
            this.txtDataFinal.TabIndex = 150;
            this.tipRegiao.SetToolTip(this.txtDataFinal, "Data Final");
            this.txtDataFinal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataFinal.Enter += new System.EventHandler(this.txtDataFinal_Enter);
            this.txtDataFinal.Leave += new System.EventHandler(this.txtDataFinal_Leave);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnData.Image = global::ccbtest.Properties.Resources.Lupa;
            this.btnData.Location = new System.Drawing.Point(211, 6);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(23, 23);
            this.btnData.TabIndex = 151;
            this.tipRegiao.SetToolTip(this.btnData, "Pesquisar");
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.BackgroundColor = System.Drawing.Color.White;
            this.gridData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridData.ColumnHeadersHeight = 17;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridData.EnableHeadersVisualStyles = false;
            this.gridData.Location = new System.Drawing.Point(6, 36);
            this.gridData.MultiSelect = false;
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            this.gridData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.Size = new System.Drawing.Size(704, 270);
            this.gridData.TabIndex = 145;
            this.gridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellDoubleClick);
            this.gridData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridData_RowStateChanged);
            this.gridData.SelectionChanged += new System.EventHandler(this.gridData_SelectionChanged);
            // 
            // btnDataVisual
            // 
            this.btnDataVisual.AccessibleDescription = "";
            this.btnDataVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataVisual.Enabled = false;
            this.btnDataVisual.Location = new System.Drawing.Point(338, 312);
            this.btnDataVisual.Name = "btnDataVisual";
            this.btnDataVisual.Size = new System.Drawing.Size(90, 30);
            this.btnDataVisual.TabIndex = 146;
            this.btnDataVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnDataVisual, "Visualizar");
            this.btnDataVisual.UseVisualStyleBackColor = true;
            this.btnDataVisual.Click += new System.EventHandler(this.btnDataVisual_Click);
            // 
            // btnDataIns
            // 
            this.btnDataIns.AccessibleDescription = "";
            this.btnDataIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataIns.Enabled = false;
            this.btnDataIns.Location = new System.Drawing.Point(432, 312);
            this.btnDataIns.Name = "btnDataIns";
            this.btnDataIns.Size = new System.Drawing.Size(90, 30);
            this.btnDataIns.TabIndex = 147;
            this.btnDataIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnDataIns, "Inserir");
            this.btnDataIns.UseVisualStyleBackColor = true;
            this.btnDataIns.Click += new System.EventHandler(this.btnDataIns_Click);
            // 
            // btnDataEditar
            // 
            this.btnDataEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataEditar.Enabled = false;
            this.btnDataEditar.Location = new System.Drawing.Point(526, 312);
            this.btnDataEditar.Name = "btnDataEditar";
            this.btnDataEditar.Size = new System.Drawing.Size(90, 30);
            this.btnDataEditar.TabIndex = 148;
            this.btnDataEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnDataEditar, "Editar");
            this.btnDataEditar.UseVisualStyleBackColor = true;
            this.btnDataEditar.Click += new System.EventHandler(this.btnDataEditar_Click);
            // 
            // btnDataCancel
            // 
            this.btnDataCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataCancel.Enabled = false;
            this.btnDataCancel.Location = new System.Drawing.Point(620, 312);
            this.btnDataCancel.Name = "btnDataCancel";
            this.btnDataCancel.Size = new System.Drawing.Size(90, 30);
            this.btnDataCancel.TabIndex = 149;
            this.btnDataCancel.Text = "&Cancelar";
            this.tipRegiao.SetToolTip(this.btnDataCancel, "Cancelar");
            this.btnDataCancel.UseVisualStyleBackColor = true;
            this.btnDataCancel.Click += new System.EventHandler(this.btnDataCancel_Click);
            // 
            // tabStatus
            // 
            this.tabStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabStatus.Controls.Add(this.btnSitImp);
            this.tabStatus.Controls.Add(this.btnSitNegar);
            this.tabStatus.Controls.Add(this.cboSituacao);
            this.tabStatus.Controls.Add(this.gridSituacao);
            this.tabStatus.Controls.Add(this.btnSitVisual);
            this.tabStatus.Controls.Add(this.btnSitIns);
            this.tabStatus.Controls.Add(this.btnSitEditar);
            this.tabStatus.Controls.Add(this.btnSitCancel);
            this.tabStatus.Location = new System.Drawing.Point(4, 22);
            this.tabStatus.Name = "tabStatus";
            this.tabStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatus.Size = new System.Drawing.Size(718, 350);
            this.tabStatus.TabIndex = 6;
            this.tabStatus.Text = "Situação";
            // 
            // btnSitImp
            // 
            this.btnSitImp.AccessibleDescription = "";
            this.btnSitImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitImp.Enabled = false;
            this.btnSitImp.Location = new System.Drawing.Point(6, 312);
            this.btnSitImp.Name = "btnSitImp";
            this.btnSitImp.Size = new System.Drawing.Size(90, 30);
            this.btnSitImp.TabIndex = 154;
            this.btnSitImp.Text = "I&mprimir";
            this.tipRegiao.SetToolTip(this.btnSitImp, "Imprimir");
            this.btnSitImp.UseVisualStyleBackColor = true;
            this.btnSitImp.Click += new System.EventHandler(this.btnSitImp_Click);
            // 
            // btnSitNegar
            // 
            this.btnSitNegar.AccessibleDescription = "";
            this.btnSitNegar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitNegar.Enabled = false;
            this.btnSitNegar.Location = new System.Drawing.Point(102, 312);
            this.btnSitNegar.Name = "btnSitNegar";
            this.btnSitNegar.Size = new System.Drawing.Size(90, 30);
            this.btnSitNegar.TabIndex = 153;
            this.btnSitNegar.Text = "&Negar";
            this.tipRegiao.SetToolTip(this.btnSitNegar, "Negar autorização");
            this.btnSitNegar.UseVisualStyleBackColor = true;
            this.btnSitNegar.Click += new System.EventHandler(this.btnSitNegar_Click);
            // 
            // cboSituacao
            // 
            this.cboSituacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSituacao.FormattingEnabled = true;
            this.cboSituacao.Items.AddRange(new object[] {
            "Pendente",
            "Autorizada",
            "Cancelada",
            "Negada"});
            this.cboSituacao.Location = new System.Drawing.Point(7, 7);
            this.cboSituacao.Name = "cboSituacao";
            this.cboSituacao.Size = new System.Drawing.Size(175, 21);
            this.cboSituacao.TabIndex = 152;
            this.cboSituacao.SelectionChangeCommitted += new System.EventHandler(this.cboSituacao_SelectionChangeCommitted);
            // 
            // gridSituacao
            // 
            this.gridSituacao.AllowUserToAddRows = false;
            this.gridSituacao.AllowUserToDeleteRows = false;
            this.gridSituacao.AllowUserToResizeRows = false;
            this.gridSituacao.BackgroundColor = System.Drawing.Color.White;
            this.gridSituacao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSituacao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.gridSituacao.Size = new System.Drawing.Size(704, 270);
            this.gridSituacao.TabIndex = 147;
            this.gridSituacao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSituacao_CellDoubleClick);
            this.gridSituacao.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridSituacao_RowStateChanged);
            this.gridSituacao.SelectionChanged += new System.EventHandler(this.gridSituacao_SelectionChanged);
            // 
            // btnSitVisual
            // 
            this.btnSitVisual.AccessibleDescription = "";
            this.btnSitVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitVisual.Enabled = false;
            this.btnSitVisual.Location = new System.Drawing.Point(338, 312);
            this.btnSitVisual.Name = "btnSitVisual";
            this.btnSitVisual.Size = new System.Drawing.Size(90, 30);
            this.btnSitVisual.TabIndex = 148;
            this.btnSitVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnSitVisual, "Visualizar");
            this.btnSitVisual.UseVisualStyleBackColor = true;
            this.btnSitVisual.Click += new System.EventHandler(this.btnSitVisual_Click);
            // 
            // btnSitIns
            // 
            this.btnSitIns.AccessibleDescription = "";
            this.btnSitIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitIns.Enabled = false;
            this.btnSitIns.Location = new System.Drawing.Point(432, 312);
            this.btnSitIns.Name = "btnSitIns";
            this.btnSitIns.Size = new System.Drawing.Size(90, 30);
            this.btnSitIns.TabIndex = 149;
            this.btnSitIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnSitIns, "Inserir");
            this.btnSitIns.UseVisualStyleBackColor = true;
            this.btnSitIns.Click += new System.EventHandler(this.btnSitIns_Click);
            // 
            // btnSitEditar
            // 
            this.btnSitEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitEditar.Enabled = false;
            this.btnSitEditar.Location = new System.Drawing.Point(526, 312);
            this.btnSitEditar.Name = "btnSitEditar";
            this.btnSitEditar.Size = new System.Drawing.Size(90, 30);
            this.btnSitEditar.TabIndex = 150;
            this.btnSitEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnSitEditar, "Editar");
            this.btnSitEditar.UseVisualStyleBackColor = true;
            this.btnSitEditar.Click += new System.EventHandler(this.btnSitEditar_Click);
            // 
            // btnSitCancel
            // 
            this.btnSitCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitCancel.Enabled = false;
            this.btnSitCancel.Location = new System.Drawing.Point(620, 312);
            this.btnSitCancel.Name = "btnSitCancel";
            this.btnSitCancel.Size = new System.Drawing.Size(90, 30);
            this.btnSitCancel.TabIndex = 151;
            this.btnSitCancel.Text = "&Cancelar";
            this.tipRegiao.SetToolTip(this.btnSitCancel, "Cancelar");
            this.btnSitCancel.UseVisualStyleBackColor = true;
            this.btnSitCancel.Click += new System.EventHandler(this.btnSitCancel_Click);
            // 
            // frmSolicitaTesteBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(739, 426);
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.lblNegada);
            this.Controls.Add(this.pctNegada);
            this.Controls.Add(this.lblCancelada);
            this.Controls.Add(this.pctCancelada);
            this.Controls.Add(this.lblPendente);
            this.Controls.Add(this.pctPendente);
            this.Controls.Add(this.lblAutoriza);
            this.Controls.Add(this.pctAutoriza);
            this.Controls.Add(this.tabSolicitaTeste);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSolicitaTesteBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solicitações para Pré-testes";
            this.Load += new System.EventHandler(this.frmSolicitaTesteBusca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctNegada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCancelada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPendente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAutoriza)).EndInit();
            this.tabSolicitaTeste.ResumeLayout(false);
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabPessoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoa)).EndInit();
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.tabStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSituacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.tabControlPersonal tabSolicitaTeste;
        private System.Windows.Forms.TabPage tabPessoa;
        private System.Windows.Forms.DataGridView gridPessoa;
        private System.Windows.Forms.Button btnPesVisual;
        private System.Windows.Forms.Button btnPesIns;
        private System.Windows.Forms.Button btnPesEditar;
        private System.Windows.Forms.Button btnPesCancel;
        private System.Windows.Forms.TabPage tabCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Button btnCodVisual;
        private System.Windows.Forms.Button btnCodIns;
        private System.Windows.Forms.Button btnCodEditar;
        private System.Windows.Forms.Button btnCodCancel;
        private System.Windows.Forms.Button btnCod;
        private System.Windows.Forms.DataGridView gridCodigo;
        private System.Windows.Forms.Label lblDescPessoa;
        private System.Windows.Forms.Label lblCodPessoa;
        private System.Windows.Forms.Button btnPessoa;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.Button btnDataVisual;
        private System.Windows.Forms.Button btnDataIns;
        private System.Windows.Forms.Button btnDataEditar;
        private System.Windows.Forms.Button btnDataCancel;
        private System.Windows.Forms.Button btnDataFinal;
        private System.Windows.Forms.Button btnDataInicial;
        private System.Windows.Forms.Label lblA;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataInicial;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataFinal;
        private System.Windows.Forms.Button btnData;
        private System.Windows.Forms.TabPage tabStatus;
        private BLL.validacoes.Controles.ComboBoxPersonal cboSituacao;
        private System.Windows.Forms.DataGridView gridSituacao;
        private System.Windows.Forms.Button btnSitVisual;
        private System.Windows.Forms.Button btnSitIns;
        private System.Windows.Forms.Button btnSitEditar;
        private System.Windows.Forms.Button btnSitCancel;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Button btnCodNegar;
        private System.Windows.Forms.Button btnPesNegar;
        private System.Windows.Forms.Button btnDataNegar;
        private System.Windows.Forms.Button btnSitNegar;
        private System.Windows.Forms.Button btnSitImp;
        private System.Windows.Forms.Button btnPesImp;
        private System.Windows.Forms.Button btnDataImp;
        private System.Windows.Forms.Button btnCodImp;
        private System.Windows.Forms.ImageList imgSolicita;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.Label lblNegada;
        private System.Windows.Forms.PictureBox pctNegada;
        private System.Windows.Forms.Label lblCancelada;
        private System.Windows.Forms.PictureBox pctCancelada;
        private System.Windows.Forms.Label lblPendente;
        private System.Windows.Forms.PictureBox pctPendente;
        private System.Windows.Forms.Label lblAutoriza;
        private System.Windows.Forms.PictureBox pctAutoriza;
    }
}