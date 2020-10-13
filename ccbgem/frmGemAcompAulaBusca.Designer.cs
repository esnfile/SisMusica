namespace ccbgem
{
    partial class frmGemAcompAulaBusca
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGemAcompAulaBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPessoa = new BLL.validacoes.Controles.tabControlPersonal();
            this.tab = new System.Windows.Forms.TabPage();
            this.btnNomeImp = new System.Windows.Forms.Button();
            this.txtNome = new BLL.validacoes.Controles.TextBoxPersonal();
            this.gridNome = new System.Windows.Forms.DataGridView();
            this.btnNomeVisual = new System.Windows.Forms.Button();
            this.btnNomeIns = new System.Windows.Forms.Button();
            this.btnNomeEditar = new System.Windows.Forms.Button();
            this.btnNomeExc = new System.Windows.Forms.Button();
            this.btnNome = new System.Windows.Forms.Button();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.btnCodImp = new System.Windows.Forms.Button();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCodVisual = new System.Windows.Forms.Button();
            this.btnCodIns = new System.Windows.Forms.Button();
            this.btnCodEditar = new System.Windows.Forms.Button();
            this.btnCodExc = new System.Windows.Forms.Button();
            this.btnCod = new System.Windows.Forms.Button();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabCpf = new System.Windows.Forms.TabPage();
            this.btnCpfImp = new System.Windows.Forms.Button();
            this.txtCpf = new BLL.validacoes.Controles.TextBoxPersonal();
            this.gridCpf = new System.Windows.Forms.DataGridView();
            this.btnCpfVisual = new System.Windows.Forms.Button();
            this.btnCpfIns = new System.Windows.Forms.Button();
            this.btnCpfEditar = new System.Windows.Forms.Button();
            this.btnCpfExc = new System.Windows.Forms.Button();
            this.btnCpf = new System.Windows.Forms.Button();
            this.tabComum = new System.Windows.Forms.TabPage();
            this.btnComImp = new System.Windows.Forms.Button();
            this.lblDescricaoComum = new System.Windows.Forms.Label();
            this.lblCodComum = new System.Windows.Forms.Label();
            this.btnComum = new System.Windows.Forms.Button();
            this.gridComum = new System.Windows.Forms.DataGridView();
            this.btnComVisual = new System.Windows.Forms.Button();
            this.btnComIns = new System.Windows.Forms.Button();
            this.btnComEditar = new System.Windows.Forms.Button();
            this.btnComExc = new System.Windows.Forms.Button();
            this.tabRegiao = new System.Windows.Forms.TabPage();
            this.btnRegImp = new System.Windows.Forms.Button();
            this.lblDescricaoRegiao = new System.Windows.Forms.Label();
            this.lblCodRegiao = new System.Windows.Forms.Label();
            this.btnRegiao = new System.Windows.Forms.Button();
            this.gridRegiao = new System.Windows.Forms.DataGridView();
            this.btnRegVisual = new System.Windows.Forms.Button();
            this.btnRegIns = new System.Windows.Forms.Button();
            this.btnRegEditar = new System.Windows.Forms.Button();
            this.btnRegExc = new System.Windows.Forms.Button();
            this.txtQtde = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblQtde = new System.Windows.Forms.Label();
            this.lblInativa = new System.Windows.Forms.Label();
            this.pctInativa = new System.Windows.Forms.PictureBox();
            this.lblAtiva = new System.Windows.Forms.Label();
            this.pctAtiva = new System.Windows.Forms.PictureBox();
            this.btnFechar = new System.Windows.Forms.Button();
            this.tabPessoa.SuspendLayout();
            this.tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).BeginInit();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.tabCpf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCpf)).BeginInit();
            this.tabComum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).BeginInit();
            this.tabRegiao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAtiva)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPessoa
            // 
            this.tabPessoa.Controls.Add(this.tab);
            this.tabPessoa.Controls.Add(this.tabCodigo);
            this.tabPessoa.Controls.Add(this.tabCpf);
            this.tabPessoa.Controls.Add(this.tabComum);
            this.tabPessoa.Controls.Add(this.tabRegiao);
            this.tabPessoa.Location = new System.Drawing.Point(7, 6);
            this.tabPessoa.Name = "tabPessoa";
            this.tabPessoa.SelectedIndex = 0;
            this.tabPessoa.Size = new System.Drawing.Size(779, 479);
            this.tabPessoa.TabIndex = 39;
            // 
            // tab
            // 
            this.tab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab.Controls.Add(this.btnNomeImp);
            this.tab.Controls.Add(this.txtNome);
            this.tab.Controls.Add(this.gridNome);
            this.tab.Controls.Add(this.btnNomeVisual);
            this.tab.Controls.Add(this.btnNomeIns);
            this.tab.Controls.Add(this.btnNomeEditar);
            this.tab.Controls.Add(this.btnNomeExc);
            this.tab.Controls.Add(this.btnNome);
            this.tab.ForeColor = System.Drawing.Color.Black;
            this.tab.Location = new System.Drawing.Point(4, 22);
            this.tab.Name = "tab";
            this.tab.Padding = new System.Windows.Forms.Padding(3);
            this.tab.Size = new System.Drawing.Size(771, 453);
            this.tab.TabIndex = 1;
            this.tab.Text = "Nome";
            // 
            // btnNomeImp
            // 
            this.btnNomeImp.AccessibleDescription = "";
            this.btnNomeImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeImp.Enabled = false;
            this.btnNomeImp.Location = new System.Drawing.Point(6, 413);
            this.btnNomeImp.Name = "btnNomeImp";
            this.btnNomeImp.Size = new System.Drawing.Size(121, 30);
            this.btnNomeImp.TabIndex = 7;
            this.btnNomeImp.Text = "&Ficha Cadastral";
            this.btnNomeImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNomeImp.UseVisualStyleBackColor = true;
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
            this.txtNome.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // gridNome
            // 
            this.gridNome.AllowUserToAddRows = false;
            this.gridNome.AllowUserToDeleteRows = false;
            this.gridNome.AllowUserToResizeRows = false;
            this.gridNome.BackgroundColor = System.Drawing.Color.White;
            this.gridNome.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridNome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gridNome.ColumnHeadersHeight = 17;
            this.gridNome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridNome.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridNome.EnableHeadersVisualStyles = false;
            this.gridNome.Location = new System.Drawing.Point(6, 63);
            this.gridNome.MultiSelect = false;
            this.gridNome.Name = "gridNome";
            this.gridNome.ReadOnly = true;
            this.gridNome.RowHeadersVisible = false;
            this.gridNome.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridNome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNome.Size = new System.Drawing.Size(759, 344);
            this.gridNome.TabIndex = 2;
            // 
            // btnNomeVisual
            // 
            this.btnNomeVisual.AccessibleDescription = "";
            this.btnNomeVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeVisual.Enabled = false;
            this.btnNomeVisual.Location = new System.Drawing.Point(393, 413);
            this.btnNomeVisual.Name = "btnNomeVisual";
            this.btnNomeVisual.Size = new System.Drawing.Size(90, 30);
            this.btnNomeVisual.TabIndex = 3;
            this.btnNomeVisual.Text = "&Visualizar";
            this.btnNomeVisual.UseVisualStyleBackColor = true;
            // 
            // btnNomeIns
            // 
            this.btnNomeIns.AccessibleDescription = "";
            this.btnNomeIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeIns.Enabled = false;
            this.btnNomeIns.Location = new System.Drawing.Point(487, 413);
            this.btnNomeIns.Name = "btnNomeIns";
            this.btnNomeIns.Size = new System.Drawing.Size(90, 30);
            this.btnNomeIns.TabIndex = 4;
            this.btnNomeIns.Text = "&Inserir";
            this.btnNomeIns.UseVisualStyleBackColor = true;
            // 
            // btnNomeEditar
            // 
            this.btnNomeEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeEditar.Enabled = false;
            this.btnNomeEditar.Location = new System.Drawing.Point(581, 413);
            this.btnNomeEditar.Name = "btnNomeEditar";
            this.btnNomeEditar.Size = new System.Drawing.Size(90, 30);
            this.btnNomeEditar.TabIndex = 5;
            this.btnNomeEditar.Text = "&Editar";
            this.btnNomeEditar.UseVisualStyleBackColor = true;
            // 
            // btnNomeExc
            // 
            this.btnNomeExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeExc.Enabled = false;
            this.btnNomeExc.Location = new System.Drawing.Point(675, 413);
            this.btnNomeExc.Name = "btnNomeExc";
            this.btnNomeExc.Size = new System.Drawing.Size(90, 30);
            this.btnNomeExc.TabIndex = 6;
            this.btnNomeExc.Text = "E&xcluir";
            this.btnNomeExc.UseVisualStyleBackColor = true;
            // 
            // btnNome
            // 
            this.btnNome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNome.Image = ((System.Drawing.Image)(resources.GetObject("btnNome.Image")));
            this.btnNome.Location = new System.Drawing.Point(159, 6);
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(23, 23);
            this.btnNome.TabIndex = 1;
            this.btnNome.UseVisualStyleBackColor = true;
            // 
            // tabCodigo
            // 
            this.tabCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCodigo.Controls.Add(this.btnCodImp);
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
            this.tabCodigo.Size = new System.Drawing.Size(771, 453);
            this.tabCodigo.TabIndex = 0;
            this.tabCodigo.Text = "Código";
            // 
            // btnCodImp
            // 
            this.btnCodImp.AccessibleDescription = "";
            this.btnCodImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodImp.Enabled = false;
            this.btnCodImp.Location = new System.Drawing.Point(6, 413);
            this.btnCodImp.Name = "btnCodImp";
            this.btnCodImp.Size = new System.Drawing.Size(121, 30);
            this.btnCodImp.TabIndex = 8;
            this.btnCodImp.Text = "&Ficha Cadastral";
            this.btnCodImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCodImp.UseVisualStyleBackColor = true;
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
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // btnCodVisual
            // 
            this.btnCodVisual.AccessibleDescription = "";
            this.btnCodVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodVisual.Enabled = false;
            this.btnCodVisual.Location = new System.Drawing.Point(393, 413);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 3;
            this.btnCodVisual.Text = "&Visualizar";
            this.btnCodVisual.UseVisualStyleBackColor = true;
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(487, 413);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 4;
            this.btnCodIns.Text = "&Inserir";
            this.btnCodIns.UseVisualStyleBackColor = true;
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(581, 413);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 5;
            this.btnCodEditar.Text = "&Editar";
            this.btnCodEditar.UseVisualStyleBackColor = true;
            // 
            // btnCodExc
            // 
            this.btnCodExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodExc.Enabled = false;
            this.btnCodExc.Location = new System.Drawing.Point(675, 413);
            this.btnCodExc.Name = "btnCodExc";
            this.btnCodExc.Size = new System.Drawing.Size(90, 30);
            this.btnCodExc.TabIndex = 6;
            this.btnCodExc.Text = "E&xcluir";
            this.btnCodExc.UseVisualStyleBackColor = true;
            // 
            // btnCod
            // 
            this.btnCod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCod.Image = ((System.Drawing.Image)(resources.GetObject("btnCod.Image")));
            this.btnCod.Location = new System.Drawing.Point(159, 6);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(23, 23);
            this.btnCod.TabIndex = 1;
            this.btnCod.UseVisualStyleBackColor = true;
            // 
            // gridCodigo
            // 
            this.gridCodigo.AllowUserToAddRows = false;
            this.gridCodigo.AllowUserToDeleteRows = false;
            this.gridCodigo.AllowUserToResizeRows = false;
            this.gridCodigo.BackgroundColor = System.Drawing.Color.White;
            this.gridCodigo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCodigo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
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
            this.gridCodigo.Size = new System.Drawing.Size(759, 371);
            this.gridCodigo.TabIndex = 2;
            // 
            // tabCpf
            // 
            this.tabCpf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCpf.Controls.Add(this.btnCpfImp);
            this.tabCpf.Controls.Add(this.txtCpf);
            this.tabCpf.Controls.Add(this.gridCpf);
            this.tabCpf.Controls.Add(this.btnCpfVisual);
            this.tabCpf.Controls.Add(this.btnCpfIns);
            this.tabCpf.Controls.Add(this.btnCpfEditar);
            this.tabCpf.Controls.Add(this.btnCpfExc);
            this.tabCpf.Controls.Add(this.btnCpf);
            this.tabCpf.ForeColor = System.Drawing.Color.Black;
            this.tabCpf.Location = new System.Drawing.Point(4, 22);
            this.tabCpf.Name = "tabCpf";
            this.tabCpf.Padding = new System.Windows.Forms.Padding(3);
            this.tabCpf.Size = new System.Drawing.Size(771, 453);
            this.tabCpf.TabIndex = 2;
            this.tabCpf.Text = "C.P.F.";
            // 
            // btnCpfImp
            // 
            this.btnCpfImp.AccessibleDescription = "";
            this.btnCpfImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfImp.Enabled = false;
            this.btnCpfImp.Location = new System.Drawing.Point(6, 413);
            this.btnCpfImp.Name = "btnCpfImp";
            this.btnCpfImp.Size = new System.Drawing.Size(121, 30);
            this.btnCpfImp.TabIndex = 8;
            this.btnCpfImp.Text = "&Ficha Cadastral";
            this.btnCpfImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCpfImp.UseVisualStyleBackColor = true;
            // 
            // txtCpf
            // 
            this.txtCpf.BackColor = System.Drawing.Color.White;
            this.txtCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCpf.Location = new System.Drawing.Point(6, 7);
            this.txtCpf.MaxLength = 100;
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(150, 21);
            this.txtCpf.TabIndex = 0;
            this.txtCpf.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // gridCpf
            // 
            this.gridCpf.AllowUserToAddRows = false;
            this.gridCpf.AllowUserToDeleteRows = false;
            this.gridCpf.AllowUserToResizeRows = false;
            this.gridCpf.BackgroundColor = System.Drawing.Color.White;
            this.gridCpf.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCpf.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gridCpf.ColumnHeadersHeight = 17;
            this.gridCpf.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCpf.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCpf.EnableHeadersVisualStyles = false;
            this.gridCpf.Location = new System.Drawing.Point(6, 36);
            this.gridCpf.MultiSelect = false;
            this.gridCpf.Name = "gridCpf";
            this.gridCpf.ReadOnly = true;
            this.gridCpf.RowHeadersVisible = false;
            this.gridCpf.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCpf.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCpf.Size = new System.Drawing.Size(759, 371);
            this.gridCpf.TabIndex = 2;
            // 
            // btnCpfVisual
            // 
            this.btnCpfVisual.AccessibleDescription = "";
            this.btnCpfVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfVisual.Enabled = false;
            this.btnCpfVisual.Location = new System.Drawing.Point(393, 413);
            this.btnCpfVisual.Name = "btnCpfVisual";
            this.btnCpfVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCpfVisual.TabIndex = 3;
            this.btnCpfVisual.Text = "&Visualizar";
            this.btnCpfVisual.UseVisualStyleBackColor = true;
            // 
            // btnCpfIns
            // 
            this.btnCpfIns.AccessibleDescription = "";
            this.btnCpfIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfIns.Enabled = false;
            this.btnCpfIns.Location = new System.Drawing.Point(487, 413);
            this.btnCpfIns.Name = "btnCpfIns";
            this.btnCpfIns.Size = new System.Drawing.Size(90, 30);
            this.btnCpfIns.TabIndex = 4;
            this.btnCpfIns.Text = "&Inserir";
            this.btnCpfIns.UseVisualStyleBackColor = true;
            // 
            // btnCpfEditar
            // 
            this.btnCpfEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfEditar.Enabled = false;
            this.btnCpfEditar.Location = new System.Drawing.Point(581, 413);
            this.btnCpfEditar.Name = "btnCpfEditar";
            this.btnCpfEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCpfEditar.TabIndex = 5;
            this.btnCpfEditar.Text = "&Editar";
            this.btnCpfEditar.UseVisualStyleBackColor = true;
            // 
            // btnCpfExc
            // 
            this.btnCpfExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfExc.Enabled = false;
            this.btnCpfExc.Location = new System.Drawing.Point(675, 413);
            this.btnCpfExc.Name = "btnCpfExc";
            this.btnCpfExc.Size = new System.Drawing.Size(90, 30);
            this.btnCpfExc.TabIndex = 6;
            this.btnCpfExc.Text = "E&xcluir";
            this.btnCpfExc.UseVisualStyleBackColor = true;
            // 
            // btnCpf
            // 
            this.btnCpf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpf.Image = ((System.Drawing.Image)(resources.GetObject("btnCpf.Image")));
            this.btnCpf.Location = new System.Drawing.Point(159, 6);
            this.btnCpf.Name = "btnCpf";
            this.btnCpf.Size = new System.Drawing.Size(23, 23);
            this.btnCpf.TabIndex = 1;
            this.btnCpf.UseVisualStyleBackColor = true;
            // 
            // tabComum
            // 
            this.tabComum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabComum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabComum.Controls.Add(this.btnComImp);
            this.tabComum.Controls.Add(this.lblDescricaoComum);
            this.tabComum.Controls.Add(this.lblCodComum);
            this.tabComum.Controls.Add(this.btnComum);
            this.tabComum.Controls.Add(this.gridComum);
            this.tabComum.Controls.Add(this.btnComVisual);
            this.tabComum.Controls.Add(this.btnComIns);
            this.tabComum.Controls.Add(this.btnComEditar);
            this.tabComum.Controls.Add(this.btnComExc);
            this.tabComum.ForeColor = System.Drawing.Color.Black;
            this.tabComum.Location = new System.Drawing.Point(4, 22);
            this.tabComum.Name = "tabComum";
            this.tabComum.Padding = new System.Windows.Forms.Padding(3);
            this.tabComum.Size = new System.Drawing.Size(771, 453);
            this.tabComum.TabIndex = 4;
            this.tabComum.Text = "Comum Congregação";
            // 
            // btnComImp
            // 
            this.btnComImp.AccessibleDescription = "";
            this.btnComImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComImp.Enabled = false;
            this.btnComImp.Location = new System.Drawing.Point(6, 413);
            this.btnComImp.Name = "btnComImp";
            this.btnComImp.Size = new System.Drawing.Size(121, 30);
            this.btnComImp.TabIndex = 129;
            this.btnComImp.Text = "&Ficha Cadastral";
            this.btnComImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComImp.UseVisualStyleBackColor = true;
            // 
            // lblDescricaoComum
            // 
            this.lblDescricaoComum.Enabled = false;
            this.lblDescricaoComum.Location = new System.Drawing.Point(106, 11);
            this.lblDescricaoComum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoComum.Name = "lblDescricaoComum";
            this.lblDescricaoComum.Size = new System.Drawing.Size(657, 17);
            this.lblDescricaoComum.TabIndex = 127;
            // 
            // lblCodComum
            // 
            this.lblCodComum.Location = new System.Drawing.Point(117, 6);
            this.lblCodComum.Name = "lblCodComum";
            this.lblCodComum.Size = new System.Drawing.Size(46, 17);
            this.lblCodComum.TabIndex = 128;
            this.lblCodComum.Visible = false;
            // 
            // btnComum
            // 
            this.btnComum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComum.Location = new System.Drawing.Point(8, 5);
            this.btnComum.Name = "btnComum";
            this.btnComum.Size = new System.Drawing.Size(90, 26);
            this.btnComum.TabIndex = 126;
            this.btnComum.Text = "Comum";
            this.btnComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComum.UseVisualStyleBackColor = true;
            // 
            // gridComum
            // 
            this.gridComum.AllowUserToAddRows = false;
            this.gridComum.AllowUserToDeleteRows = false;
            this.gridComum.AllowUserToResizeRows = false;
            this.gridComum.BackgroundColor = System.Drawing.Color.White;
            this.gridComum.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridComum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.gridComum.ColumnHeadersHeight = 17;
            this.gridComum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridComum.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridComum.EnableHeadersVisualStyles = false;
            this.gridComum.Location = new System.Drawing.Point(6, 36);
            this.gridComum.MultiSelect = false;
            this.gridComum.Name = "gridComum";
            this.gridComum.ReadOnly = true;
            this.gridComum.RowHeadersVisible = false;
            this.gridComum.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridComum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridComum.Size = new System.Drawing.Size(759, 371);
            this.gridComum.TabIndex = 121;
            // 
            // btnComVisual
            // 
            this.btnComVisual.AccessibleDescription = "";
            this.btnComVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComVisual.Enabled = false;
            this.btnComVisual.Location = new System.Drawing.Point(393, 413);
            this.btnComVisual.Name = "btnComVisual";
            this.btnComVisual.Size = new System.Drawing.Size(90, 30);
            this.btnComVisual.TabIndex = 122;
            this.btnComVisual.Text = "&Visualizar";
            this.btnComVisual.UseVisualStyleBackColor = true;
            // 
            // btnComIns
            // 
            this.btnComIns.AccessibleDescription = "";
            this.btnComIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComIns.Enabled = false;
            this.btnComIns.Location = new System.Drawing.Point(487, 413);
            this.btnComIns.Name = "btnComIns";
            this.btnComIns.Size = new System.Drawing.Size(90, 30);
            this.btnComIns.TabIndex = 123;
            this.btnComIns.Text = "&Inserir";
            this.btnComIns.UseVisualStyleBackColor = true;
            // 
            // btnComEditar
            // 
            this.btnComEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComEditar.Enabled = false;
            this.btnComEditar.Location = new System.Drawing.Point(581, 413);
            this.btnComEditar.Name = "btnComEditar";
            this.btnComEditar.Size = new System.Drawing.Size(90, 30);
            this.btnComEditar.TabIndex = 124;
            this.btnComEditar.Text = "&Editar";
            this.btnComEditar.UseVisualStyleBackColor = true;
            // 
            // btnComExc
            // 
            this.btnComExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComExc.Enabled = false;
            this.btnComExc.Location = new System.Drawing.Point(675, 413);
            this.btnComExc.Name = "btnComExc";
            this.btnComExc.Size = new System.Drawing.Size(90, 30);
            this.btnComExc.TabIndex = 125;
            this.btnComExc.Text = "E&xcluir";
            this.btnComExc.UseVisualStyleBackColor = true;
            // 
            // tabRegiao
            // 
            this.tabRegiao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabRegiao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabRegiao.Controls.Add(this.btnRegImp);
            this.tabRegiao.Controls.Add(this.lblDescricaoRegiao);
            this.tabRegiao.Controls.Add(this.lblCodRegiao);
            this.tabRegiao.Controls.Add(this.btnRegiao);
            this.tabRegiao.Controls.Add(this.gridRegiao);
            this.tabRegiao.Controls.Add(this.btnRegVisual);
            this.tabRegiao.Controls.Add(this.btnRegIns);
            this.tabRegiao.Controls.Add(this.btnRegEditar);
            this.tabRegiao.Controls.Add(this.btnRegExc);
            this.tabRegiao.ForeColor = System.Drawing.Color.Black;
            this.tabRegiao.Location = new System.Drawing.Point(4, 22);
            this.tabRegiao.Name = "tabRegiao";
            this.tabRegiao.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegiao.Size = new System.Drawing.Size(771, 453);
            this.tabRegiao.TabIndex = 3;
            this.tabRegiao.Text = "Região";
            // 
            // btnRegImp
            // 
            this.btnRegImp.AccessibleDescription = "";
            this.btnRegImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegImp.Enabled = false;
            this.btnRegImp.Location = new System.Drawing.Point(6, 413);
            this.btnRegImp.Name = "btnRegImp";
            this.btnRegImp.Size = new System.Drawing.Size(121, 30);
            this.btnRegImp.TabIndex = 121;
            this.btnRegImp.Text = "&Ficha Cadastral";
            this.btnRegImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegImp.UseVisualStyleBackColor = true;
            // 
            // lblDescricaoRegiao
            // 
            this.lblDescricaoRegiao.Enabled = false;
            this.lblDescricaoRegiao.Location = new System.Drawing.Point(106, 11);
            this.lblDescricaoRegiao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoRegiao.Name = "lblDescricaoRegiao";
            this.lblDescricaoRegiao.Size = new System.Drawing.Size(657, 17);
            this.lblDescricaoRegiao.TabIndex = 119;
            // 
            // lblCodRegiao
            // 
            this.lblCodRegiao.Location = new System.Drawing.Point(117, 6);
            this.lblCodRegiao.Name = "lblCodRegiao";
            this.lblCodRegiao.Size = new System.Drawing.Size(46, 17);
            this.lblCodRegiao.TabIndex = 120;
            this.lblCodRegiao.Visible = false;
            // 
            // btnRegiao
            // 
            this.btnRegiao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegiao.Location = new System.Drawing.Point(8, 5);
            this.btnRegiao.Name = "btnRegiao";
            this.btnRegiao.Size = new System.Drawing.Size(90, 26);
            this.btnRegiao.TabIndex = 118;
            this.btnRegiao.Text = "Região";
            this.btnRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegiao.UseVisualStyleBackColor = true;
            // 
            // gridRegiao
            // 
            this.gridRegiao.AllowUserToAddRows = false;
            this.gridRegiao.AllowUserToDeleteRows = false;
            this.gridRegiao.AllowUserToResizeRows = false;
            this.gridRegiao.BackgroundColor = System.Drawing.Color.White;
            this.gridRegiao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegiao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
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
            this.gridRegiao.Size = new System.Drawing.Size(759, 371);
            this.gridRegiao.TabIndex = 9;
            // 
            // btnRegVisual
            // 
            this.btnRegVisual.AccessibleDescription = "";
            this.btnRegVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegVisual.Enabled = false;
            this.btnRegVisual.Location = new System.Drawing.Point(393, 413);
            this.btnRegVisual.Name = "btnRegVisual";
            this.btnRegVisual.Size = new System.Drawing.Size(90, 30);
            this.btnRegVisual.TabIndex = 10;
            this.btnRegVisual.Text = "&Visualizar";
            this.btnRegVisual.UseVisualStyleBackColor = true;
            // 
            // btnRegIns
            // 
            this.btnRegIns.AccessibleDescription = "";
            this.btnRegIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegIns.Enabled = false;
            this.btnRegIns.Location = new System.Drawing.Point(487, 413);
            this.btnRegIns.Name = "btnRegIns";
            this.btnRegIns.Size = new System.Drawing.Size(90, 30);
            this.btnRegIns.TabIndex = 11;
            this.btnRegIns.Text = "&Inserir";
            this.btnRegIns.UseVisualStyleBackColor = true;
            // 
            // btnRegEditar
            // 
            this.btnRegEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegEditar.Enabled = false;
            this.btnRegEditar.Location = new System.Drawing.Point(581, 413);
            this.btnRegEditar.Name = "btnRegEditar";
            this.btnRegEditar.Size = new System.Drawing.Size(90, 30);
            this.btnRegEditar.TabIndex = 12;
            this.btnRegEditar.Text = "&Editar";
            this.btnRegEditar.UseVisualStyleBackColor = true;
            // 
            // btnRegExc
            // 
            this.btnRegExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegExc.Enabled = false;
            this.btnRegExc.Location = new System.Drawing.Point(675, 413);
            this.btnRegExc.Name = "btnRegExc";
            this.btnRegExc.Size = new System.Drawing.Size(90, 30);
            this.btnRegExc.TabIndex = 13;
            this.btnRegExc.Text = "E&xcluir";
            this.btnRegExc.UseVisualStyleBackColor = true;
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.LightGray;
            this.txtQtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtde.Enabled = false;
            this.txtQtde.Location = new System.Drawing.Point(386, 498);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(47, 21);
            this.txtQtde.TabIndex = 46;
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtde.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Location = new System.Drawing.Point(267, 502);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(119, 13);
            this.lblQtde.TabIndex = 45;
            this.lblQtde.Text = "Qtde registros listados:";
            // 
            // lblInativa
            // 
            this.lblInativa.AutoSize = true;
            this.lblInativa.Location = new System.Drawing.Point(79, 502);
            this.lblInativa.Name = "lblInativa";
            this.lblInativa.Size = new System.Drawing.Size(41, 13);
            this.lblInativa.TabIndex = 44;
            this.lblInativa.Text = "Inativo";
            // 
            // pctInativa
            // 
            this.pctInativa.Location = new System.Drawing.Point(63, 499);
            this.pctInativa.Name = "pctInativa";
            this.pctInativa.Size = new System.Drawing.Size(16, 20);
            this.pctInativa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctInativa.TabIndex = 43;
            this.pctInativa.TabStop = false;
            // 
            // lblAtiva
            // 
            this.lblAtiva.AutoSize = true;
            this.lblAtiva.Location = new System.Drawing.Point(25, 502);
            this.lblAtiva.Name = "lblAtiva";
            this.lblAtiva.Size = new System.Drawing.Size(32, 13);
            this.lblAtiva.TabIndex = 42;
            this.lblAtiva.Text = "Ativo";
            // 
            // pctAtiva
            // 
            this.pctAtiva.Location = new System.Drawing.Point(8, 499);
            this.pctAtiva.Name = "pctAtiva";
            this.pctAtiva.Size = new System.Drawing.Size(16, 20);
            this.pctAtiva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAtiva.TabIndex = 41;
            this.pctAtiva.TabStop = false;
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(697, 494);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 40;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // frmGemAcompAulaBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(794, 531);
            this.Controls.Add(this.tabPessoa);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.lblInativa);
            this.Controls.Add(this.pctInativa);
            this.Controls.Add(this.lblAtiva);
            this.Controls.Add(this.pctAtiva);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGemAcompAulaBusca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Acompanhamento de Aulas GEM";
            this.tabPessoa.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).EndInit();
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.tabCpf.ResumeLayout(false);
            this.tabCpf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCpf)).EndInit();
            this.tabComum.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).EndInit();
            this.tabRegiao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAtiva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BLL.validacoes.Controles.tabControlPersonal tabPessoa;
        private System.Windows.Forms.TabPage tab;
        private System.Windows.Forms.Button btnNomeImp;
        private BLL.validacoes.Controles.TextBoxPersonal txtNome;
        private System.Windows.Forms.DataGridView gridNome;
        private System.Windows.Forms.Button btnNomeVisual;
        private System.Windows.Forms.Button btnNomeIns;
        private System.Windows.Forms.Button btnNomeEditar;
        private System.Windows.Forms.Button btnNomeExc;
        private System.Windows.Forms.Button btnNome;
        private System.Windows.Forms.TabPage tabCodigo;
        private System.Windows.Forms.Button btnCodImp;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Button btnCodVisual;
        private System.Windows.Forms.Button btnCodIns;
        private System.Windows.Forms.Button btnCodEditar;
        private System.Windows.Forms.Button btnCodExc;
        private System.Windows.Forms.Button btnCod;
        private System.Windows.Forms.DataGridView gridCodigo;
        private System.Windows.Forms.TabPage tabCpf;
        private System.Windows.Forms.Button btnCpfImp;
        private BLL.validacoes.Controles.TextBoxPersonal txtCpf;
        private System.Windows.Forms.DataGridView gridCpf;
        private System.Windows.Forms.Button btnCpfVisual;
        private System.Windows.Forms.Button btnCpfIns;
        private System.Windows.Forms.Button btnCpfEditar;
        private System.Windows.Forms.Button btnCpfExc;
        private System.Windows.Forms.Button btnCpf;
        private System.Windows.Forms.TabPage tabComum;
        private System.Windows.Forms.Button btnComImp;
        private System.Windows.Forms.Label lblDescricaoComum;
        private System.Windows.Forms.Label lblCodComum;
        private System.Windows.Forms.Button btnComum;
        private System.Windows.Forms.DataGridView gridComum;
        private System.Windows.Forms.Button btnComVisual;
        private System.Windows.Forms.Button btnComIns;
        private System.Windows.Forms.Button btnComEditar;
        private System.Windows.Forms.Button btnComExc;
        private System.Windows.Forms.TabPage tabRegiao;
        private System.Windows.Forms.Button btnRegImp;
        private System.Windows.Forms.Label lblDescricaoRegiao;
        private System.Windows.Forms.Label lblCodRegiao;
        private System.Windows.Forms.Button btnRegiao;
        private System.Windows.Forms.DataGridView gridRegiao;
        private System.Windows.Forms.Button btnRegVisual;
        private System.Windows.Forms.Button btnRegIns;
        private System.Windows.Forms.Button btnRegEditar;
        private System.Windows.Forms.Button btnRegExc;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtde;
        private System.Windows.Forms.Label lblQtde;
        private System.Windows.Forms.Label lblInativa;
        private System.Windows.Forms.PictureBox pctInativa;
        private System.Windows.Forms.Label lblAtiva;
        private System.Windows.Forms.PictureBox pctAtiva;
        private System.Windows.Forms.Button btnFechar;
    }
}