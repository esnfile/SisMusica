namespace ccbadm
{
    partial class frmReunioesBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReunioesBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipReuniao = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCodImp = new System.Windows.Forms.Button();
            this.btnCodCancel = new System.Windows.Forms.Button();
            this.btnRegImp = new System.Windows.Forms.Button();
            this.btnRegVisual = new System.Windows.Forms.Button();
            this.btnRegIns = new System.Windows.Forms.Button();
            this.btnRegEditar = new System.Windows.Forms.Button();
            this.btnRegCancel = new System.Windows.Forms.Button();
            this.btnDataImp = new System.Windows.Forms.Button();
            this.btnDataFinal = new System.Windows.Forms.Button();
            this.btnDataInicial = new System.Windows.Forms.Button();
            this.txtDataInicial = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataFinal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnData = new System.Windows.Forms.Button();
            this.btnDataVisual = new System.Windows.Forms.Button();
            this.btnDataIns = new System.Windows.Forms.Button();
            this.btnDataEditar = new System.Windows.Forms.Button();
            this.btnDataCancel = new System.Windows.Forms.Button();
            this.btnSitImp = new System.Windows.Forms.Button();
            this.btnSitFinaliza = new System.Windows.Forms.Button();
            this.btnSitVisual = new System.Windows.Forms.Button();
            this.btnSitIns = new System.Windows.Forms.Button();
            this.btnSitEditar = new System.Windows.Forms.Button();
            this.btnSitCancel = new System.Windows.Forms.Button();
            this.btnCodFinaliza = new System.Windows.Forms.Button();
            this.btnRegFinaliza = new System.Windows.Forms.Button();
            this.btnDataFinaliza = new System.Windows.Forms.Button();
            this.imgReuniao = new System.Windows.Forms.ImageList(this.components);
            this.lblLegenda = new System.Windows.Forms.Label();
            this.lblCancelada = new System.Windows.Forms.Label();
            this.pctCancelada = new System.Windows.Forms.PictureBox();
            this.lblRealizar = new System.Windows.Forms.Label();
            this.pctRealizar = new System.Windows.Forms.PictureBox();
            this.lblRealizada = new System.Windows.Forms.Label();
            this.pctRealizada = new System.Windows.Forms.PictureBox();
            this.tabReunioes = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCodVisual = new System.Windows.Forms.Button();
            this.btnCodIns = new System.Windows.Forms.Button();
            this.btnCodEditar = new System.Windows.Forms.Button();
            this.btnCod = new System.Windows.Forms.Button();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabRegiao = new System.Windows.Forms.TabPage();
            this.cboRegiao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.gridRegiao = new System.Windows.Forms.DataGridView();
            this.tabData = new System.Windows.Forms.TabPage();
            this.lblA = new System.Windows.Forms.Label();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.tabStatus = new System.Windows.Forms.TabPage();
            this.cboSituacao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.gridSituacao = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.pctCancelada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRealizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRealizada)).BeginInit();
            this.tabReunioes.SuspendLayout();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabRegiao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
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
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(644, 386);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 35);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipReuniao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCodImp
            // 
            this.btnCodImp.AccessibleDescription = "";
            this.btnCodImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodImp.Enabled = false;
            this.btnCodImp.Location = new System.Drawing.Point(6, 312);
            this.btnCodImp.Name = "btnCodImp";
            this.btnCodImp.Size = new System.Drawing.Size(90, 30);
            this.btnCodImp.TabIndex = 155;
            this.btnCodImp.Text = "I&mprimir";
            this.tipReuniao.SetToolTip(this.btnCodImp, "Imprimir");
            this.btnCodImp.UseVisualStyleBackColor = true;
            this.btnCodImp.Click += new System.EventHandler(this.btnCodImp_Click);
            // 
            // btnCodCancel
            // 
            this.btnCodCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodCancel.Enabled = false;
            this.btnCodCancel.Location = new System.Drawing.Point(620, 312);
            this.btnCodCancel.Name = "btnCodCancel";
            this.btnCodCancel.Size = new System.Drawing.Size(90, 30);
            this.btnCodCancel.TabIndex = 13;
            this.btnCodCancel.Text = "&Cancelar";
            this.tipReuniao.SetToolTip(this.btnCodCancel, "Cancelar");
            this.btnCodCancel.UseVisualStyleBackColor = true;
            this.btnCodCancel.Click += new System.EventHandler(this.btnCodCancel_Click);
            // 
            // btnRegImp
            // 
            this.btnRegImp.AccessibleDescription = "";
            this.btnRegImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegImp.Enabled = false;
            this.btnRegImp.Location = new System.Drawing.Point(6, 312);
            this.btnRegImp.Name = "btnRegImp";
            this.btnRegImp.Size = new System.Drawing.Size(90, 30);
            this.btnRegImp.TabIndex = 155;
            this.btnRegImp.Text = "I&mprimir";
            this.tipReuniao.SetToolTip(this.btnRegImp, "Imprimir");
            this.btnRegImp.UseVisualStyleBackColor = true;
            this.btnRegImp.Click += new System.EventHandler(this.btnRegImp_Click);
            // 
            // btnRegVisual
            // 
            this.btnRegVisual.AccessibleDescription = "";
            this.btnRegVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegVisual.Enabled = false;
            this.btnRegVisual.Location = new System.Drawing.Point(338, 312);
            this.btnRegVisual.Name = "btnRegVisual";
            this.btnRegVisual.Size = new System.Drawing.Size(90, 30);
            this.btnRegVisual.TabIndex = 3;
            this.btnRegVisual.Text = "&Visualizar";
            this.tipReuniao.SetToolTip(this.btnRegVisual, "Visualizar");
            this.btnRegVisual.UseVisualStyleBackColor = true;
            this.btnRegVisual.Click += new System.EventHandler(this.btnRegVisual_Click);
            // 
            // btnRegIns
            // 
            this.btnRegIns.AccessibleDescription = "";
            this.btnRegIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegIns.Enabled = false;
            this.btnRegIns.Location = new System.Drawing.Point(432, 312);
            this.btnRegIns.Name = "btnRegIns";
            this.btnRegIns.Size = new System.Drawing.Size(90, 30);
            this.btnRegIns.TabIndex = 4;
            this.btnRegIns.Text = "&Inserir";
            this.tipReuniao.SetToolTip(this.btnRegIns, "Inserir");
            this.btnRegIns.UseVisualStyleBackColor = true;
            this.btnRegIns.Click += new System.EventHandler(this.btnRegIns_Click);
            // 
            // btnRegEditar
            // 
            this.btnRegEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegEditar.Enabled = false;
            this.btnRegEditar.Location = new System.Drawing.Point(526, 312);
            this.btnRegEditar.Name = "btnRegEditar";
            this.btnRegEditar.Size = new System.Drawing.Size(90, 30);
            this.btnRegEditar.TabIndex = 5;
            this.btnRegEditar.Text = "&Editar";
            this.tipReuniao.SetToolTip(this.btnRegEditar, "Editar");
            this.btnRegEditar.UseVisualStyleBackColor = true;
            this.btnRegEditar.Click += new System.EventHandler(this.btnRegEditar_Click);
            // 
            // btnRegCancel
            // 
            this.btnRegCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegCancel.Enabled = false;
            this.btnRegCancel.Location = new System.Drawing.Point(620, 312);
            this.btnRegCancel.Name = "btnRegCancel";
            this.btnRegCancel.Size = new System.Drawing.Size(90, 30);
            this.btnRegCancel.TabIndex = 6;
            this.btnRegCancel.Text = "&Cancelar";
            this.tipReuniao.SetToolTip(this.btnRegCancel, "Cancelar");
            this.btnRegCancel.UseVisualStyleBackColor = true;
            this.btnRegCancel.Click += new System.EventHandler(this.btnRegCancel_Click);
            // 
            // btnDataImp
            // 
            this.btnDataImp.AccessibleDescription = "";
            this.btnDataImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataImp.Enabled = false;
            this.btnDataImp.Location = new System.Drawing.Point(6, 312);
            this.btnDataImp.Name = "btnDataImp";
            this.btnDataImp.Size = new System.Drawing.Size(90, 30);
            this.btnDataImp.TabIndex = 157;
            this.btnDataImp.Text = "I&mprimir";
            this.tipReuniao.SetToolTip(this.btnDataImp, "Imprimir");
            this.btnDataImp.UseVisualStyleBackColor = true;
            this.btnDataImp.Click += new System.EventHandler(this.btnDataImp_Click);
            // 
            // btnDataFinal
            // 
            this.btnDataFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataFinal.BackgroundImage = global::ccbadm.Properties.Resources.depois;
            this.btnDataFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDataFinal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataFinal.Location = new System.Drawing.Point(188, 8);
            this.btnDataFinal.Name = "btnDataFinal";
            this.btnDataFinal.Size = new System.Drawing.Size(18, 19);
            this.btnDataFinal.TabIndex = 155;
            this.tipReuniao.SetToolTip(this.btnDataFinal, "Definir data máxima");
            this.btnDataFinal.UseVisualStyleBackColor = true;
            this.btnDataFinal.Click += new System.EventHandler(this.btnDataFinal_Click);
            // 
            // btnDataInicial
            // 
            this.btnDataInicial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataInicial.BackgroundImage = global::ccbadm.Properties.Resources.antes;
            this.btnDataInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataInicial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataInicial.Location = new System.Drawing.Point(78, 8);
            this.btnDataInicial.Name = "btnDataInicial";
            this.btnDataInicial.Size = new System.Drawing.Size(18, 19);
            this.btnDataInicial.TabIndex = 154;
            this.tipReuniao.SetToolTip(this.btnDataInicial, "Definir data mínima");
            this.btnDataInicial.UseVisualStyleBackColor = true;
            this.btnDataInicial.Click += new System.EventHandler(this.btnDataInicial_Click);
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
            this.tipReuniao.SetToolTip(this.txtDataInicial, "Data Inicial");
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
            this.tipReuniao.SetToolTip(this.txtDataFinal, "Data Final");
            this.txtDataFinal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataFinal.Enter += new System.EventHandler(this.txtDataFinal_Enter);
            this.txtDataFinal.Leave += new System.EventHandler(this.txtDataFinal_Leave);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnData.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnData.Location = new System.Drawing.Point(211, 6);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(23, 23);
            this.btnData.TabIndex = 151;
            this.tipReuniao.SetToolTip(this.btnData, "Pesquisar");
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnDataVisual
            // 
            this.btnDataVisual.AccessibleDescription = "";
            this.btnDataVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataVisual.Enabled = false;
            this.btnDataVisual.Location = new System.Drawing.Point(338, 312);
            this.btnDataVisual.Name = "btnDataVisual";
            this.btnDataVisual.Size = new System.Drawing.Size(90, 30);
            this.btnDataVisual.TabIndex = 146;
            this.btnDataVisual.Text = "&Visualizar";
            this.tipReuniao.SetToolTip(this.btnDataVisual, "Visualizar");
            this.btnDataVisual.UseVisualStyleBackColor = true;
            this.btnDataVisual.Click += new System.EventHandler(this.btnDataVisual_Click);
            // 
            // btnDataIns
            // 
            this.btnDataIns.AccessibleDescription = "";
            this.btnDataIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataIns.Enabled = false;
            this.btnDataIns.Location = new System.Drawing.Point(432, 312);
            this.btnDataIns.Name = "btnDataIns";
            this.btnDataIns.Size = new System.Drawing.Size(90, 30);
            this.btnDataIns.TabIndex = 147;
            this.btnDataIns.Text = "&Inserir";
            this.tipReuniao.SetToolTip(this.btnDataIns, "Inserir");
            this.btnDataIns.UseVisualStyleBackColor = true;
            this.btnDataIns.Click += new System.EventHandler(this.btnDataIns_Click);
            // 
            // btnDataEditar
            // 
            this.btnDataEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataEditar.Enabled = false;
            this.btnDataEditar.Location = new System.Drawing.Point(526, 312);
            this.btnDataEditar.Name = "btnDataEditar";
            this.btnDataEditar.Size = new System.Drawing.Size(90, 30);
            this.btnDataEditar.TabIndex = 148;
            this.btnDataEditar.Text = "&Editar";
            this.tipReuniao.SetToolTip(this.btnDataEditar, "Editar");
            this.btnDataEditar.UseVisualStyleBackColor = true;
            this.btnDataEditar.Click += new System.EventHandler(this.btnDataEditar_Click);
            // 
            // btnDataCancel
            // 
            this.btnDataCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataCancel.Enabled = false;
            this.btnDataCancel.Location = new System.Drawing.Point(620, 312);
            this.btnDataCancel.Name = "btnDataCancel";
            this.btnDataCancel.Size = new System.Drawing.Size(90, 30);
            this.btnDataCancel.TabIndex = 149;
            this.btnDataCancel.Text = "&Cancelar";
            this.tipReuniao.SetToolTip(this.btnDataCancel, "Cancelar");
            this.btnDataCancel.UseVisualStyleBackColor = true;
            this.btnDataCancel.Click += new System.EventHandler(this.btnDataCancel_Click);
            // 
            // btnSitImp
            // 
            this.btnSitImp.AccessibleDescription = "";
            this.btnSitImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSitImp.Enabled = false;
            this.btnSitImp.Location = new System.Drawing.Point(6, 312);
            this.btnSitImp.Name = "btnSitImp";
            this.btnSitImp.Size = new System.Drawing.Size(90, 30);
            this.btnSitImp.TabIndex = 154;
            this.btnSitImp.Text = "I&mprimir";
            this.tipReuniao.SetToolTip(this.btnSitImp, "Imprimir");
            this.btnSitImp.UseVisualStyleBackColor = true;
            this.btnSitImp.Click += new System.EventHandler(this.btnSitImp_Click);
            // 
            // btnSitFinaliza
            // 
            this.btnSitFinaliza.AccessibleDescription = "";
            this.btnSitFinaliza.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitFinaliza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSitFinaliza.Enabled = false;
            this.btnSitFinaliza.Location = new System.Drawing.Point(102, 312);
            this.btnSitFinaliza.Name = "btnSitFinaliza";
            this.btnSitFinaliza.Size = new System.Drawing.Size(90, 30);
            this.btnSitFinaliza.TabIndex = 153;
            this.btnSitFinaliza.Text = "&Finalizar";
            this.tipReuniao.SetToolTip(this.btnSitFinaliza, "Finalizar");
            this.btnSitFinaliza.UseVisualStyleBackColor = true;
            this.btnSitFinaliza.Click += new System.EventHandler(this.btnSitFinaliza_Click);
            // 
            // btnSitVisual
            // 
            this.btnSitVisual.AccessibleDescription = "";
            this.btnSitVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSitVisual.Enabled = false;
            this.btnSitVisual.Location = new System.Drawing.Point(338, 312);
            this.btnSitVisual.Name = "btnSitVisual";
            this.btnSitVisual.Size = new System.Drawing.Size(90, 30);
            this.btnSitVisual.TabIndex = 148;
            this.btnSitVisual.Text = "&Visualizar";
            this.tipReuniao.SetToolTip(this.btnSitVisual, "Visualizar");
            this.btnSitVisual.UseVisualStyleBackColor = true;
            this.btnSitVisual.Click += new System.EventHandler(this.btnSitVisual_Click);
            // 
            // btnSitIns
            // 
            this.btnSitIns.AccessibleDescription = "";
            this.btnSitIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSitIns.Enabled = false;
            this.btnSitIns.Location = new System.Drawing.Point(432, 312);
            this.btnSitIns.Name = "btnSitIns";
            this.btnSitIns.Size = new System.Drawing.Size(90, 30);
            this.btnSitIns.TabIndex = 149;
            this.btnSitIns.Text = "&Inserir";
            this.tipReuniao.SetToolTip(this.btnSitIns, "Inserir");
            this.btnSitIns.UseVisualStyleBackColor = true;
            this.btnSitIns.Click += new System.EventHandler(this.btnSitIns_Click);
            // 
            // btnSitEditar
            // 
            this.btnSitEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSitEditar.Enabled = false;
            this.btnSitEditar.Location = new System.Drawing.Point(526, 312);
            this.btnSitEditar.Name = "btnSitEditar";
            this.btnSitEditar.Size = new System.Drawing.Size(90, 30);
            this.btnSitEditar.TabIndex = 150;
            this.btnSitEditar.Text = "&Editar";
            this.tipReuniao.SetToolTip(this.btnSitEditar, "Editar");
            this.btnSitEditar.UseVisualStyleBackColor = true;
            this.btnSitEditar.Click += new System.EventHandler(this.btnSitEditar_Click);
            // 
            // btnSitCancel
            // 
            this.btnSitCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSitCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSitCancel.Enabled = false;
            this.btnSitCancel.Location = new System.Drawing.Point(620, 312);
            this.btnSitCancel.Name = "btnSitCancel";
            this.btnSitCancel.Size = new System.Drawing.Size(90, 30);
            this.btnSitCancel.TabIndex = 151;
            this.btnSitCancel.Text = "&Cancelar";
            this.tipReuniao.SetToolTip(this.btnSitCancel, "Cancelar");
            this.btnSitCancel.UseVisualStyleBackColor = true;
            this.btnSitCancel.Click += new System.EventHandler(this.btnSitCancel_Click);
            // 
            // btnCodFinaliza
            // 
            this.btnCodFinaliza.AccessibleDescription = "";
            this.btnCodFinaliza.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodFinaliza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodFinaliza.Enabled = false;
            this.btnCodFinaliza.Location = new System.Drawing.Point(102, 312);
            this.btnCodFinaliza.Name = "btnCodFinaliza";
            this.btnCodFinaliza.Size = new System.Drawing.Size(90, 30);
            this.btnCodFinaliza.TabIndex = 15;
            this.btnCodFinaliza.Text = "&Finalizar";
            this.tipReuniao.SetToolTip(this.btnCodFinaliza, "Finalizar");
            this.btnCodFinaliza.UseVisualStyleBackColor = true;
            this.btnCodFinaliza.Click += new System.EventHandler(this.btnCodFinaliza_Click);
            // 
            // btnRegFinaliza
            // 
            this.btnRegFinaliza.AccessibleDescription = "";
            this.btnRegFinaliza.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegFinaliza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegFinaliza.Enabled = false;
            this.btnRegFinaliza.Location = new System.Drawing.Point(102, 312);
            this.btnRegFinaliza.Name = "btnRegFinaliza";
            this.btnRegFinaliza.Size = new System.Drawing.Size(90, 30);
            this.btnRegFinaliza.TabIndex = 132;
            this.btnRegFinaliza.Text = "&Finalizar";
            this.tipReuniao.SetToolTip(this.btnRegFinaliza, "Finalizar");
            this.btnRegFinaliza.UseVisualStyleBackColor = true;
            this.btnRegFinaliza.Click += new System.EventHandler(this.btnRegFinaliza_Click);
            // 
            // btnDataFinaliza
            // 
            this.btnDataFinaliza.AccessibleDescription = "";
            this.btnDataFinaliza.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataFinaliza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataFinaliza.Enabled = false;
            this.btnDataFinaliza.Location = new System.Drawing.Point(102, 312);
            this.btnDataFinaliza.Name = "btnDataFinaliza";
            this.btnDataFinaliza.Size = new System.Drawing.Size(90, 30);
            this.btnDataFinaliza.TabIndex = 156;
            this.btnDataFinaliza.Text = "&Finalizar";
            this.tipReuniao.SetToolTip(this.btnDataFinaliza, "Finalizar");
            this.btnDataFinaliza.UseVisualStyleBackColor = true;
            this.btnDataFinaliza.Click += new System.EventHandler(this.btnDataFinaliza_Click);
            // 
            // imgReuniao
            // 
            this.imgReuniao.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgReuniao.ImageStream")));
            this.imgReuniao.TransparentColor = System.Drawing.Color.Transparent;
            this.imgReuniao.Images.SetKeyName(0, "Abertas.ico");
            this.imgReuniao.Images.SetKeyName(1, "finalizado.png");
            this.imgReuniao.Images.SetKeyName(2, "cancelado.png");
            this.imgReuniao.Images.SetKeyName(3, "negar.png");
            // 
            // lblLegenda
            // 
            this.lblLegenda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLegenda.AutoSize = true;
            this.lblLegenda.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLegenda.Location = new System.Drawing.Point(5, 383);
            this.lblLegenda.Name = "lblLegenda";
            this.lblLegenda.Size = new System.Drawing.Size(146, 13);
            this.lblLegenda.TabIndex = 73;
            this.lblLegenda.Text = "Legenda - Status da Reunião";
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
            // lblRealizar
            // 
            this.lblRealizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRealizar.AutoSize = true;
            this.lblRealizar.Location = new System.Drawing.Point(23, 403);
            this.lblRealizar.Name = "lblRealizar";
            this.lblRealizar.Size = new System.Drawing.Size(55, 13);
            this.lblRealizar.TabIndex = 68;
            this.lblRealizar.Text = "A Realizar";
            // 
            // pctRealizar
            // 
            this.pctRealizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctRealizar.Location = new System.Drawing.Point(6, 399);
            this.pctRealizar.Name = "pctRealizar";
            this.pctRealizar.Size = new System.Drawing.Size(16, 20);
            this.pctRealizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctRealizar.TabIndex = 67;
            this.pctRealizar.TabStop = false;
            // 
            // lblRealizada
            // 
            this.lblRealizada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRealizada.AutoSize = true;
            this.lblRealizada.Location = new System.Drawing.Point(101, 403);
            this.lblRealizada.Name = "lblRealizada";
            this.lblRealizada.Size = new System.Drawing.Size(53, 13);
            this.lblRealizada.TabIndex = 66;
            this.lblRealizada.Text = "Realizada";
            // 
            // pctRealizada
            // 
            this.pctRealizada.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctRealizada.Location = new System.Drawing.Point(84, 399);
            this.pctRealizada.Name = "pctRealizada";
            this.pctRealizada.Size = new System.Drawing.Size(16, 20);
            this.pctRealizada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctRealizada.TabIndex = 65;
            this.pctRealizada.TabStop = false;
            // 
            // tabReunioes
            // 
            this.tabReunioes.Controls.Add(this.tabCodigo);
            this.tabReunioes.Controls.Add(this.tabRegiao);
            this.tabReunioes.Controls.Add(this.tabData);
            this.tabReunioes.Controls.Add(this.tabStatus);
            this.tabReunioes.Location = new System.Drawing.Point(6, 6);
            this.tabReunioes.Name = "tabReunioes";
            this.tabReunioes.SelectedIndex = 0;
            this.tabReunioes.Size = new System.Drawing.Size(726, 376);
            this.tabReunioes.TabIndex = 31;
            this.tabReunioes.SelectedIndexChanged += new System.EventHandler(this.tabReunioes_SelectedIndexChanged);
            // 
            // tabCodigo
            // 
            this.tabCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCodigo.Controls.Add(this.btnCodImp);
            this.tabCodigo.Controls.Add(this.btnCodFinaliza);
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
            this.tabCodigo.Text = "Reunião";
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
            this.btnCodVisual.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnCodIns.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnCodEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(526, 312);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 12;
            this.btnCodEditar.Text = "&Editar";
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCod
            // 
            this.btnCod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCod.Image = global::ccbadm.Properties.Resources.Lupa;
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
            // tabRegiao
            // 
            this.tabRegiao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRegiao.Controls.Add(this.cboRegiao);
            this.tabRegiao.Controls.Add(this.btnRegImp);
            this.tabRegiao.Controls.Add(this.btnRegFinaliza);
            this.tabRegiao.Controls.Add(this.gridRegiao);
            this.tabRegiao.Controls.Add(this.btnRegVisual);
            this.tabRegiao.Controls.Add(this.btnRegIns);
            this.tabRegiao.Controls.Add(this.btnRegEditar);
            this.tabRegiao.Controls.Add(this.btnRegCancel);
            this.tabRegiao.Location = new System.Drawing.Point(4, 22);
            this.tabRegiao.Name = "tabRegiao";
            this.tabRegiao.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegiao.Size = new System.Drawing.Size(718, 350);
            this.tabRegiao.TabIndex = 1;
            this.tabRegiao.Text = "Microrregião";
            // 
            // cboRegiao
            // 
            this.cboRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboRegiao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegiao.FormattingEnabled = true;
            this.cboRegiao.Items.AddRange(new object[] {
            "Pendente",
            "Autorizada",
            "Cancelada",
            "Negada"});
            this.cboRegiao.Location = new System.Drawing.Point(7, 7);
            this.cboRegiao.Name = "cboRegiao";
            this.cboRegiao.Size = new System.Drawing.Size(175, 21);
            this.cboRegiao.TabIndex = 156;
            this.cboRegiao.SelectionChangeCommitted += new System.EventHandler(this.cboRegiao_SelectionChangeCommitted);
            // 
            // gridRegiao
            // 
            this.gridRegiao.AllowUserToAddRows = false;
            this.gridRegiao.AllowUserToDeleteRows = false;
            this.gridRegiao.AllowUserToResizeRows = false;
            this.gridRegiao.BackgroundColor = System.Drawing.Color.White;
            this.gridRegiao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegiao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.gridRegiao.Size = new System.Drawing.Size(704, 270);
            this.gridRegiao.TabIndex = 2;
            this.gridRegiao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellDoubleClick);
            this.gridRegiao.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridRegiao_RowStateChanged);
            this.gridRegiao.SelectionChanged += new System.EventHandler(this.gridRegiao_SelectionChanged);
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabData.Controls.Add(this.btnDataImp);
            this.tabData.Controls.Add(this.btnDataFinaliza);
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
            this.tabData.Text = "Data Reunião";
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
            // tabStatus
            // 
            this.tabStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabStatus.Controls.Add(this.btnSitImp);
            this.tabStatus.Controls.Add(this.btnSitFinaliza);
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
            // cboSituacao
            // 
            this.cboSituacao.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // frmReunioesBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(739, 426);
            this.Controls.Add(this.lblLegenda);
            this.Controls.Add(this.lblCancelada);
            this.Controls.Add(this.pctCancelada);
            this.Controls.Add(this.lblRealizar);
            this.Controls.Add(this.pctRealizar);
            this.Controls.Add(this.lblRealizada);
            this.Controls.Add(this.pctRealizada);
            this.Controls.Add(this.tabReunioes);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReunioesBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Reuniões Ministeriais";
            this.Load += new System.EventHandler(this.frmReunioesBusca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctCancelada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRealizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRealizada)).EndInit();
            this.tabReunioes.ResumeLayout(false);
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabRegiao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.tabStatus.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSituacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipReuniao;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.tabControlPersonal tabReunioes;
        private System.Windows.Forms.TabPage tabRegiao;
        private System.Windows.Forms.DataGridView gridRegiao;
        private System.Windows.Forms.Button btnRegVisual;
        private System.Windows.Forms.Button btnRegIns;
        private System.Windows.Forms.Button btnRegEditar;
        private System.Windows.Forms.Button btnRegCancel;
        private System.Windows.Forms.TabPage tabCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Button btnCodVisual;
        private System.Windows.Forms.Button btnCodIns;
        private System.Windows.Forms.Button btnCodEditar;
        private System.Windows.Forms.Button btnCodCancel;
        private System.Windows.Forms.Button btnCod;
        private System.Windows.Forms.DataGridView gridCodigo;
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
        private System.Windows.Forms.Button btnCodFinaliza;
        private System.Windows.Forms.Button btnRegFinaliza;
        private System.Windows.Forms.Button btnDataFinaliza;
        private System.Windows.Forms.Button btnSitFinaliza;
        private System.Windows.Forms.Button btnSitImp;
        private System.Windows.Forms.Button btnRegImp;
        private System.Windows.Forms.Button btnDataImp;
        private System.Windows.Forms.Button btnCodImp;
        private System.Windows.Forms.ImageList imgReuniao;
        private System.Windows.Forms.Label lblLegenda;
        private System.Windows.Forms.Label lblCancelada;
        private System.Windows.Forms.PictureBox pctCancelada;
        private System.Windows.Forms.Label lblRealizar;
        private System.Windows.Forms.PictureBox pctRealizar;
        private System.Windows.Forms.Label lblRealizada;
        private System.Windows.Forms.PictureBox pctRealizada;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegiao;
    }
}