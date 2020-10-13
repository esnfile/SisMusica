namespace ccbpess
{
    partial class frmImportarPessoa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarPessoa));
            this.tipImporta = new System.Windows.Forms.ToolTip(this.components);
            this.btnArquivo = new System.Windows.Forms.Button();
            this.cboProcurar = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtProcurar = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.btnVincular = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.txtCodUsuario = new BLL.validacoes.Controles.TextBoxPersonal();
            this.chkLimparImportado = new System.Windows.Forms.CheckBox();
            this.chkLimparVinculado = new System.Windows.Forms.CheckBox();
            this.txtQtdeDados = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblQtdeDados = new System.Windows.Forms.Label();
            this.gridDados = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.txtQtde = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblQtde = new System.Windows.Forms.Label();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.lblPesquisa = new System.Windows.Forms.Label();
            this.gridImporta = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.txtCaminho = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHoraImporta = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataImporta = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCadastro = new System.Windows.Forms.Label();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ofdImport = new System.Windows.Forms.OpenFileDialog();
            this.tabImportacao = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabImporta = new System.Windows.Forms.TabPage();
            this.tabDados = new System.Windows.Forms.TabPage();
            this.lblCodigoDados = new System.Windows.Forms.Label();
            this.txtCodUsuarioDados = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodigoDados = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataDados = new System.Windows.Forms.Label();
            this.txtDataDados = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHoraDados = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtUsuarioDados = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblUsuarioDados = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridDados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImporta)).BeginInit();
            this.tabImportacao.SuspendLayout();
            this.tabImporta.SuspendLayout();
            this.tabDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnArquivo
            // 
            this.btnArquivo.Location = new System.Drawing.Point(641, 36);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(23, 23);
            this.btnArquivo.TabIndex = 53;
            this.btnArquivo.Text = "...";
            this.btnArquivo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipImporta.SetToolTip(this.btnArquivo, "Buscar arquivo a importar");
            this.btnArquivo.UseCompatibleTextRendering = true;
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // cboProcurar
            // 
            this.cboProcurar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProcurar.FormattingEnabled = true;
            this.cboProcurar.Location = new System.Drawing.Point(91, 63);
            this.cboProcurar.Name = "cboProcurar";
            this.cboProcurar.Size = new System.Drawing.Size(139, 21);
            this.cboProcurar.TabIndex = 56;
            this.tipImporta.SetToolTip(this.cboProcurar, "Selecione a coluna que deseja efetuar a busca");
            // 
            // txtProcurar
            // 
            this.txtProcurar.BackColor = System.Drawing.Color.White;
            this.txtProcurar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProcurar.Location = new System.Drawing.Point(238, 63);
            this.txtProcurar.Name = "txtProcurar";
            this.txtProcurar.Size = new System.Drawing.Size(170, 21);
            this.txtProcurar.TabIndex = 57;
            this.tipImporta.SetToolTip(this.txtProcurar, "Texto ou parte do texto a ser pesquisado");
            this.txtProcurar.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(414, 62);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 58;
            this.btnPesquisar.Text = "Pesquisar";
            this.tipImporta.SetToolTip(this.btnPesquisar, "Pesquisar");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // btnVincular
            // 
            this.btnVincular.Location = new System.Drawing.Point(714, 454);
            this.btnVincular.Name = "btnVincular";
            this.btnVincular.Size = new System.Drawing.Size(102, 25);
            this.btnVincular.TabIndex = 62;
            this.btnVincular.Text = "Vincular Campos";
            this.tipImporta.SetToolTip(this.btnVincular, "Vincular");
            this.btnVincular.UseVisualStyleBackColor = true;
            this.btnVincular.Click += new System.EventHandler(this.btnVincular_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(723, 455);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(102, 25);
            this.btnEditar.TabIndex = 63;
            this.btnEditar.Text = "Editar Erros";
            this.tipImporta.SetToolTip(this.btnEditar, "Editar");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Image = global::ccbpess.Properties.Resources.compfile;
            this.btnImportar.Location = new System.Drawing.Point(670, 36);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(97, 40);
            this.btnImportar.TabIndex = 60;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipImporta.SetToolTip(this.btnImportar, "Importar");
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // txtCodUsuario
            // 
            this.txtCodUsuario.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodUsuario.Enabled = false;
            this.txtCodUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodUsuario.Location = new System.Drawing.Point(471, 11);
            this.txtCodUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodUsuario.MaxLength = 150;
            this.txtCodUsuario.Name = "txtCodUsuario";
            this.txtCodUsuario.Size = new System.Drawing.Size(56, 21);
            this.txtCodUsuario.TabIndex = 68;
            this.txtCodUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodUsuario.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // chkLimparImportado
            // 
            this.chkLimparImportado.AutoSize = true;
            this.chkLimparImportado.Location = new System.Drawing.Point(503, 458);
            this.chkLimparImportado.Name = "chkLimparImportado";
            this.chkLimparImportado.Size = new System.Drawing.Size(158, 17);
            this.chkLimparImportado.TabIndex = 67;
            this.chkLimparImportado.Text = "Limpar registros importados";
            this.chkLimparImportado.UseVisualStyleBackColor = true;
            this.chkLimparImportado.CheckedChanged += new System.EventHandler(this.chkLimparImportado_CheckedChanged);
            // 
            // chkLimparVinculado
            // 
            this.chkLimparVinculado.AutoSize = true;
            this.chkLimparVinculado.Location = new System.Drawing.Point(498, 457);
            this.chkLimparVinculado.Name = "chkLimparVinculado";
            this.chkLimparVinculado.Size = new System.Drawing.Size(155, 17);
            this.chkLimparVinculado.TabIndex = 66;
            this.chkLimparVinculado.Text = "Limpar registros vinculados";
            this.chkLimparVinculado.UseVisualStyleBackColor = true;
            this.chkLimparVinculado.CheckedChanged += new System.EventHandler(this.chkLimparVinculado_CheckedChanged);
            // 
            // txtQtdeDados
            // 
            this.txtQtdeDados.BackColor = System.Drawing.Color.LightGray;
            this.txtQtdeDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdeDados.Enabled = false;
            this.txtQtdeDados.Location = new System.Drawing.Point(88, 455);
            this.txtQtdeDados.Name = "txtQtdeDados";
            this.txtQtdeDados.Size = new System.Drawing.Size(50, 21);
            this.txtQtdeDados.TabIndex = 65;
            this.txtQtdeDados.Text = "000000";
            this.txtQtdeDados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeDados.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblQtdeDados
            // 
            this.lblQtdeDados.AutoSize = true;
            this.lblQtdeDados.Enabled = false;
            this.lblQtdeDados.Location = new System.Drawing.Point(6, 459);
            this.lblQtdeDados.Name = "lblQtdeDados";
            this.lblQtdeDados.Size = new System.Drawing.Size(80, 13);
            this.lblQtdeDados.TabIndex = 64;
            this.lblQtdeDados.Text = "Qtde registros:";
            // 
            // gridDados
            // 
            this.gridDados.AllowUserToAddRows = false;
            this.gridDados.AllowUserToDeleteRows = false;
            this.gridDados.AllowUserToResizeRows = false;
            this.gridDados.BackgroundColor = System.Drawing.Color.White;
            this.gridDados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridDados.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridDados.DisabledCell = null;
            this.gridDados.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDados.EnableHeadersVisualStyles = false;
            this.gridDados.Location = new System.Drawing.Point(6, 39);
            this.gridDados.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridDados.MultiSelect = false;
            this.gridDados.Name = "gridDados";
            this.gridDados.ReadOnly = true;
            this.gridDados.RowHeadersVisible = false;
            this.gridDados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDados.RowTemplate.Height = 18;
            this.gridDados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDados.Size = new System.Drawing.Size(819, 411);
            this.gridDados.TabIndex = 61;
            this.gridDados.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridDados_CellBeginEdit);
            this.gridDados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDados_CellDoubleClick);
            this.gridDados.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDados_CellEndEdit);
            this.gridDados.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDados_CellEnter);
            this.gridDados.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDados_CellLeave);
            this.gridDados.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridDados_CellValidating);
            this.gridDados.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.gridDados_DataError);
            this.gridDados.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDados_RowStateChanged);
            this.gridDados.SelectionChanged += new System.EventHandler(this.gridDados_SelectionChanged);
            this.gridDados.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridDados_KeyDown);
            this.gridDados.Leave += new System.EventHandler(this.gridDados_Leave);
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.LightGray;
            this.txtQtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtde.Enabled = false;
            this.txtQtde.Location = new System.Drawing.Point(93, 455);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(50, 21);
            this.txtQtde.TabIndex = 3;
            this.txtQtde.Text = "000000";
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtde.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Enabled = false;
            this.lblQtde.Location = new System.Drawing.Point(11, 459);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(80, 13);
            this.lblQtde.TabIndex = 2;
            this.lblQtde.Text = "Qtde registros:";
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(503, 64);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(161, 17);
            this.chkTodos.TabIndex = 59;
            this.chkTodos.Text = "Limpar critério e exibir todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodos_CheckedChanged);
            // 
            // lblPesquisa
            // 
            this.lblPesquisa.AutoSize = true;
            this.lblPesquisa.Enabled = false;
            this.lblPesquisa.Location = new System.Drawing.Point(39, 67);
            this.lblPesquisa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPesquisa.Name = "lblPesquisa";
            this.lblPesquisa.Size = new System.Drawing.Size(52, 13);
            this.lblPesquisa.TabIndex = 55;
            this.lblPesquisa.Text = "Procurar:";
            // 
            // gridImporta
            // 
            this.gridImporta.AllowUserToAddRows = false;
            this.gridImporta.AllowUserToDeleteRows = false;
            this.gridImporta.AllowUserToResizeRows = false;
            this.gridImporta.BackgroundColor = System.Drawing.Color.White;
            this.gridImporta.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridImporta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridImporta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridImporta.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridImporta.DisabledCell = null;
            this.gridImporta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridImporta.EnableHeadersVisualStyles = false;
            this.gridImporta.Location = new System.Drawing.Point(11, 94);
            this.gridImporta.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridImporta.MultiSelect = false;
            this.gridImporta.Name = "gridImporta";
            this.gridImporta.ReadOnly = true;
            this.gridImporta.RowHeadersVisible = false;
            this.gridImporta.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridImporta.RowTemplate.Height = 18;
            this.gridImporta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridImporta.Size = new System.Drawing.Size(805, 355);
            this.gridImporta.TabIndex = 54;
            // 
            // lblCaminho
            // 
            this.lblCaminho.AutoSize = true;
            this.lblCaminho.Enabled = false;
            this.lblCaminho.Location = new System.Drawing.Point(39, 41);
            this.lblCaminho.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(52, 13);
            this.lblCaminho.TabIndex = 51;
            this.lblCaminho.Text = "Caminho:";
            // 
            // txtCaminho
            // 
            this.txtCaminho.BackColor = System.Drawing.Color.LightYellow;
            this.txtCaminho.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaminho.Enabled = false;
            this.txtCaminho.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCaminho.Location = new System.Drawing.Point(91, 37);
            this.txtCaminho.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCaminho.MaxLength = 150;
            this.txtCaminho.Name = "txtCaminho";
            this.txtCaminho.Size = new System.Drawing.Size(546, 21);
            this.txtCaminho.TabIndex = 52;
            this.txtCaminho.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Location = new System.Drawing.Point(424, 15);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(47, 13);
            this.lblUsuario.TabIndex = 49;
            this.lblUsuario.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.LightYellow;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUsuario.Location = new System.Drawing.Point(532, 11);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUsuario.MaxLength = 150;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(235, 21);
            this.txtUsuario.TabIndex = 50;
            this.txtUsuario.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtHoraImporta
            // 
            this.txtHoraImporta.BackColor = System.Drawing.Color.White;
            this.txtHoraImporta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraImporta.Enabled = false;
            this.txtHoraImporta.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraImporta.Location = new System.Drawing.Point(344, 11);
            this.txtHoraImporta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraImporta.Name = "txtHoraImporta";
            this.txtHoraImporta.Size = new System.Drawing.Size(38, 21);
            this.txtHoraImporta.TabIndex = 47;
            this.txtHoraImporta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraImporta.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtDataImporta
            // 
            this.txtDataImporta.BackColor = System.Drawing.Color.White;
            this.txtDataImporta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataImporta.Enabled = false;
            this.txtDataImporta.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataImporta.Location = new System.Drawing.Point(267, 11);
            this.txtDataImporta.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataImporta.Name = "txtDataImporta";
            this.txtDataImporta.Size = new System.Drawing.Size(73, 21);
            this.txtDataImporta.TabIndex = 46;
            this.txtDataImporta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataImporta.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblCadastro
            // 
            this.lblCadastro.AutoSize = true;
            this.lblCadastro.Enabled = false;
            this.lblCadastro.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCadastro.Location = new System.Drawing.Point(175, 15);
            this.lblCadastro.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCadastro.Name = "lblCadastro";
            this.lblCadastro.Size = new System.Drawing.Size(92, 13);
            this.lblCadastro.TabIndex = 48;
            this.lblCadastro.Text = "Data Importação:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(91, 11);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(57, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "000000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(39, 15);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(663, 525);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 39;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(758, 525);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 40;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tabImportacao
            // 
            this.tabImportacao.Controls.Add(this.tabImporta);
            this.tabImportacao.Controls.Add(this.tabDados);
            this.tabImportacao.Location = new System.Drawing.Point(9, 7);
            this.tabImportacao.Name = "tabImportacao";
            this.tabImportacao.SelectedIndex = 0;
            this.tabImportacao.Size = new System.Drawing.Size(839, 511);
            this.tabImportacao.TabIndex = 41;
            this.tabImportacao.SelectedIndexChanged += new System.EventHandler(this.tabImportacao_SelectedIndexChanged);
            // 
            // tabImporta
            // 
            this.tabImporta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabImporta.Controls.Add(this.lblCodigo);
            this.tabImporta.Controls.Add(this.txtCodUsuario);
            this.tabImporta.Controls.Add(this.txtCodigo);
            this.tabImporta.Controls.Add(this.chkLimparImportado);
            this.tabImporta.Controls.Add(this.lblCadastro);
            this.tabImporta.Controls.Add(this.btnVincular);
            this.tabImporta.Controls.Add(this.txtDataImporta);
            this.tabImporta.Controls.Add(this.txtQtde);
            this.tabImporta.Controls.Add(this.txtHoraImporta);
            this.tabImporta.Controls.Add(this.btnImportar);
            this.tabImporta.Controls.Add(this.txtUsuario);
            this.tabImporta.Controls.Add(this.lblQtde);
            this.tabImporta.Controls.Add(this.lblUsuario);
            this.tabImporta.Controls.Add(this.chkTodos);
            this.tabImporta.Controls.Add(this.txtCaminho);
            this.tabImporta.Controls.Add(this.btnPesquisar);
            this.tabImporta.Controls.Add(this.lblCaminho);
            this.tabImporta.Controls.Add(this.txtProcurar);
            this.tabImporta.Controls.Add(this.btnArquivo);
            this.tabImporta.Controls.Add(this.cboProcurar);
            this.tabImporta.Controls.Add(this.gridImporta);
            this.tabImporta.Controls.Add(this.lblPesquisa);
            this.tabImporta.Location = new System.Drawing.Point(4, 22);
            this.tabImporta.Name = "tabImporta";
            this.tabImporta.Padding = new System.Windows.Forms.Padding(3);
            this.tabImporta.Size = new System.Drawing.Size(831, 485);
            this.tabImporta.TabIndex = 0;
            this.tabImporta.Text = "Arquivo para importação";
            // 
            // tabDados
            // 
            this.tabDados.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabDados.Controls.Add(this.lblCodigoDados);
            this.tabDados.Controls.Add(this.txtCodUsuarioDados);
            this.tabDados.Controls.Add(this.txtCodigoDados);
            this.tabDados.Controls.Add(this.lblDataDados);
            this.tabDados.Controls.Add(this.txtDataDados);
            this.tabDados.Controls.Add(this.txtHoraDados);
            this.tabDados.Controls.Add(this.txtUsuarioDados);
            this.tabDados.Controls.Add(this.lblUsuarioDados);
            this.tabDados.Controls.Add(this.gridDados);
            this.tabDados.Controls.Add(this.btnEditar);
            this.tabDados.Controls.Add(this.lblQtdeDados);
            this.tabDados.Controls.Add(this.txtQtdeDados);
            this.tabDados.Controls.Add(this.chkLimparVinculado);
            this.tabDados.Location = new System.Drawing.Point(4, 22);
            this.tabDados.Name = "tabDados";
            this.tabDados.Padding = new System.Windows.Forms.Padding(3);
            this.tabDados.Size = new System.Drawing.Size(831, 485);
            this.tabDados.TabIndex = 1;
            this.tabDados.Text = "Dados Vinculados";
            // 
            // lblCodigoDados
            // 
            this.lblCodigoDados.AutoSize = true;
            this.lblCodigoDados.Enabled = false;
            this.lblCodigoDados.Location = new System.Drawing.Point(39, 15);
            this.lblCodigoDados.Name = "lblCodigoDados";
            this.lblCodigoDados.Size = new System.Drawing.Size(44, 13);
            this.lblCodigoDados.TabIndex = 69;
            this.lblCodigoDados.Text = "Código:";
            // 
            // txtCodUsuarioDados
            // 
            this.txtCodUsuarioDados.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodUsuarioDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodUsuarioDados.Enabled = false;
            this.txtCodUsuarioDados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodUsuarioDados.Location = new System.Drawing.Point(471, 11);
            this.txtCodUsuarioDados.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodUsuarioDados.MaxLength = 150;
            this.txtCodUsuarioDados.Name = "txtCodUsuarioDados";
            this.txtCodUsuarioDados.Size = new System.Drawing.Size(56, 21);
            this.txtCodUsuarioDados.TabIndex = 76;
            this.txtCodUsuarioDados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodUsuarioDados.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodigoDados
            // 
            this.txtCodigoDados.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodigoDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoDados.Enabled = false;
            this.txtCodigoDados.Location = new System.Drawing.Point(91, 11);
            this.txtCodigoDados.Name = "txtCodigoDados";
            this.txtCodigoDados.Size = new System.Drawing.Size(57, 21);
            this.txtCodigoDados.TabIndex = 70;
            this.txtCodigoDados.Text = "000000";
            this.txtCodigoDados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoDados.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblDataDados
            // 
            this.lblDataDados.AutoSize = true;
            this.lblDataDados.Enabled = false;
            this.lblDataDados.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDataDados.Location = new System.Drawing.Point(175, 15);
            this.lblDataDados.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataDados.Name = "lblDataDados";
            this.lblDataDados.Size = new System.Drawing.Size(92, 13);
            this.lblDataDados.TabIndex = 73;
            this.lblDataDados.Text = "Data Importação:";
            // 
            // txtDataDados
            // 
            this.txtDataDados.BackColor = System.Drawing.Color.White;
            this.txtDataDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataDados.Enabled = false;
            this.txtDataDados.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataDados.Location = new System.Drawing.Point(267, 11);
            this.txtDataDados.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataDados.Name = "txtDataDados";
            this.txtDataDados.Size = new System.Drawing.Size(73, 21);
            this.txtDataDados.TabIndex = 71;
            this.txtDataDados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataDados.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // txtHoraDados
            // 
            this.txtHoraDados.BackColor = System.Drawing.Color.White;
            this.txtHoraDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraDados.Enabled = false;
            this.txtHoraDados.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraDados.Location = new System.Drawing.Point(344, 11);
            this.txtHoraDados.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraDados.Name = "txtHoraDados";
            this.txtHoraDados.Size = new System.Drawing.Size(38, 21);
            this.txtHoraDados.TabIndex = 72;
            this.txtHoraDados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraDados.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtUsuarioDados
            // 
            this.txtUsuarioDados.BackColor = System.Drawing.Color.LightYellow;
            this.txtUsuarioDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioDados.Enabled = false;
            this.txtUsuarioDados.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUsuarioDados.Location = new System.Drawing.Point(532, 11);
            this.txtUsuarioDados.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUsuarioDados.MaxLength = 150;
            this.txtUsuarioDados.Name = "txtUsuarioDados";
            this.txtUsuarioDados.Size = new System.Drawing.Size(235, 21);
            this.txtUsuarioDados.TabIndex = 75;
            this.txtUsuarioDados.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblUsuarioDados
            // 
            this.lblUsuarioDados.AutoSize = true;
            this.lblUsuarioDados.Enabled = false;
            this.lblUsuarioDados.Location = new System.Drawing.Point(424, 15);
            this.lblUsuarioDados.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuarioDados.Name = "lblUsuarioDados";
            this.lblUsuarioDados.Size = new System.Drawing.Size(47, 13);
            this.lblUsuarioDados.TabIndex = 74;
            this.lblUsuarioDados.Text = "Usuário:";
            // 
            // frmImportarPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(857, 559);
            this.Controls.Add(this.tabImportacao);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportarPessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação de Pessoas (Cadastramento Efetuado no Formulário On-Line)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImportarPessoa_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportarPessoa_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.gridDados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridImporta)).EndInit();
            this.tabImportacao.ResumeLayout(false);
            this.tabImporta.ResumeLayout(false);
            this.tabImporta.PerformLayout();
            this.tabDados.ResumeLayout(false);
            this.tabDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipImporta;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraImporta;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataImporta;
        private System.Windows.Forms.Label lblCadastro;
        private System.Windows.Forms.Label lblUsuario;
        private BLL.validacoes.Controles.TextBoxPersonal txtUsuario;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.Label lblCaminho;
        private BLL.validacoes.Controles.TextBoxPersonal txtCaminho;
        private BLL.validacoes.Controles.DataGridViewPersonal gridImporta;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtde;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.OpenFileDialog ofdImport;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.Button btnPesquisar;
        private BLL.validacoes.Controles.TextBoxPersonal txtProcurar;
        private BLL.validacoes.Controles.ComboBoxPersonal cboProcurar;
        private System.Windows.Forms.Label lblPesquisa;
        private System.Windows.Forms.Button btnImportar;
        private BLL.validacoes.Controles.DataGridViewPersonal gridDados;
        private System.Windows.Forms.Button btnVincular;
        private System.Windows.Forms.Button btnEditar;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtdeDados;
        private System.Windows.Forms.Label lblQtdeDados;
        private System.Windows.Forms.CheckBox chkLimparVinculado;
        private System.Windows.Forms.CheckBox chkLimparImportado;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodUsuario;
        private BLL.validacoes.Controles.tabControlPersonal tabImportacao;
        private System.Windows.Forms.TabPage tabImporta;
        private System.Windows.Forms.TabPage tabDados;
        private System.Windows.Forms.Label lblCodigoDados;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodUsuarioDados;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigoDados;
        private System.Windows.Forms.Label lblDataDados;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataDados;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraDados;
        private BLL.validacoes.Controles.TextBoxPersonal txtUsuarioDados;
        private System.Windows.Forms.Label lblUsuarioDados;
    }
}