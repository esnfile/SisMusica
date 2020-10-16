namespace ccbpess
{
    partial class frmPessoaBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPessoaBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipPessoa = new System.Windows.Forms.ToolTip(this.components);
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
            this.txtCpf = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCpfVisual = new System.Windows.Forms.Button();
            this.btnCpfIns = new System.Windows.Forms.Button();
            this.btnCpfEditar = new System.Windows.Forms.Button();
            this.btnCpfExc = new System.Windows.Forms.Button();
            this.btnCpf = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnRegVisual = new System.Windows.Forms.Button();
            this.btnRegIns = new System.Windows.Forms.Button();
            this.btnRegEditar = new System.Windows.Forms.Button();
            this.btnRegExc = new System.Windows.Forms.Button();
            this.btnComVisual = new System.Windows.Forms.Button();
            this.btnComIns = new System.Windows.Forms.Button();
            this.btnComEditar = new System.Windows.Forms.Button();
            this.btnComExc = new System.Windows.Forms.Button();
            this.btnNomeImp = new System.Windows.Forms.Button();
            this.btnCodImp = new System.Windows.Forms.Button();
            this.btnCpfImp = new System.Windows.Forms.Button();
            this.btnComImp = new System.Windows.Forms.Button();
            this.btnRegImp = new System.Windows.Forms.Button();
            this.imgPessoa = new System.Windows.Forms.ImageList(this.components);
            this.tabPessoa = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabNome = new System.Windows.Forms.TabPage();
            this.gridNome = new System.Windows.Forms.DataGridView();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabCpf = new System.Windows.Forms.TabPage();
            this.gridCpf = new System.Windows.Forms.DataGridView();
            this.tabComum = new System.Windows.Forms.TabPage();
            this.lblDescricaoComum = new System.Windows.Forms.Label();
            this.lblCodComum = new System.Windows.Forms.Label();
            this.btnComum = new System.Windows.Forms.Button();
            this.gridComum = new System.Windows.Forms.DataGridView();
            this.tabRegiao = new System.Windows.Forms.TabPage();
            this.lblDescricaoRegiao = new System.Windows.Forms.Label();
            this.lblCodRegiao = new System.Windows.Forms.Label();
            this.btnRegiao = new System.Windows.Forms.Button();
            this.gridRegiao = new System.Windows.Forms.DataGridView();
            this.lblInativa = new System.Windows.Forms.Label();
            this.pctInativa = new System.Windows.Forms.PictureBox();
            this.lblAtiva = new System.Windows.Forms.Label();
            this.pctAtiva = new System.Windows.Forms.PictureBox();
            this.lblQtde = new System.Windows.Forms.Label();
            this.txtQtde = new BLL.validacoes.Controles.TextBoxPersonal();
            this.tabPessoa.SuspendLayout();
            this.tabNome.SuspendLayout();
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
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.LightYellow;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(6, 7);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(150, 21);
            this.txtNome.TabIndex = 0;
            this.tipPessoa.SetToolTip(this.txtNome, "Nome para pesquisar");
            this.txtNome.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // btnNomeVisual
            // 
            this.btnNomeVisual.AccessibleDescription = "";
            this.btnNomeVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNomeVisual.Enabled = false;
            this.btnNomeVisual.Location = new System.Drawing.Point(393, 413);
            this.btnNomeVisual.Name = "btnNomeVisual";
            this.btnNomeVisual.Size = new System.Drawing.Size(90, 30);
            this.btnNomeVisual.TabIndex = 3;
            this.btnNomeVisual.Text = "&Visualizar";
            this.tipPessoa.SetToolTip(this.btnNomeVisual, "Visualizar");
            this.btnNomeVisual.UseVisualStyleBackColor = true;
            this.btnNomeVisual.Click += new System.EventHandler(this.btnNomeVisual_Click);
            // 
            // btnNomeIns
            // 
            this.btnNomeIns.AccessibleDescription = "";
            this.btnNomeIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNomeIns.Enabled = false;
            this.btnNomeIns.Location = new System.Drawing.Point(487, 413);
            this.btnNomeIns.Name = "btnNomeIns";
            this.btnNomeIns.Size = new System.Drawing.Size(90, 30);
            this.btnNomeIns.TabIndex = 4;
            this.btnNomeIns.Text = "&Inserir";
            this.tipPessoa.SetToolTip(this.btnNomeIns, "Inserir");
            this.btnNomeIns.UseVisualStyleBackColor = true;
            this.btnNomeIns.Click += new System.EventHandler(this.btnNomeIns_Click);
            // 
            // btnNomeEditar
            // 
            this.btnNomeEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNomeEditar.Enabled = false;
            this.btnNomeEditar.Location = new System.Drawing.Point(581, 413);
            this.btnNomeEditar.Name = "btnNomeEditar";
            this.btnNomeEditar.Size = new System.Drawing.Size(90, 30);
            this.btnNomeEditar.TabIndex = 5;
            this.btnNomeEditar.Text = "&Editar";
            this.tipPessoa.SetToolTip(this.btnNomeEditar, "Editar");
            this.btnNomeEditar.UseVisualStyleBackColor = true;
            this.btnNomeEditar.Click += new System.EventHandler(this.btnNomeEditar_Click);
            // 
            // btnNomeExc
            // 
            this.btnNomeExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNomeExc.Enabled = false;
            this.btnNomeExc.Location = new System.Drawing.Point(675, 413);
            this.btnNomeExc.Name = "btnNomeExc";
            this.btnNomeExc.Size = new System.Drawing.Size(90, 30);
            this.btnNomeExc.TabIndex = 6;
            this.btnNomeExc.Text = "E&xcluir";
            this.tipPessoa.SetToolTip(this.btnNomeExc, "Excluir");
            this.btnNomeExc.UseVisualStyleBackColor = true;
            this.btnNomeExc.Click += new System.EventHandler(this.btnNomeExc_Click);
            // 
            // btnNome
            // 
            this.btnNome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNome.Image = ((System.Drawing.Image)(resources.GetObject("btnNome.Image")));
            this.btnNome.Location = new System.Drawing.Point(159, 6);
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(23, 23);
            this.btnNome.TabIndex = 1;
            this.tipPessoa.SetToolTip(this.btnNome, "Pesquisar funcionários");
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
            this.tipPessoa.SetToolTip(this.txtCodigo, "Código para pesquisar");
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
            this.btnCodVisual.Location = new System.Drawing.Point(393, 413);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 3;
            this.btnCodVisual.Text = "&Visualizar";
            this.tipPessoa.SetToolTip(this.btnCodVisual, "Visualizar");
            this.btnCodVisual.UseVisualStyleBackColor = true;
            this.btnCodVisual.Click += new System.EventHandler(this.btnCodVisual_Click);
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(487, 413);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 4;
            this.btnCodIns.Text = "&Inserir";
            this.tipPessoa.SetToolTip(this.btnCodIns, "Inserir");
            this.btnCodIns.UseVisualStyleBackColor = true;
            this.btnCodIns.Click += new System.EventHandler(this.btnCodIns_Click);
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(581, 413);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 5;
            this.btnCodEditar.Text = "&Editar";
            this.tipPessoa.SetToolTip(this.btnCodEditar, "Editar");
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCodExc
            // 
            this.btnCodExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodExc.Enabled = false;
            this.btnCodExc.Location = new System.Drawing.Point(675, 413);
            this.btnCodExc.Name = "btnCodExc";
            this.btnCodExc.Size = new System.Drawing.Size(90, 30);
            this.btnCodExc.TabIndex = 6;
            this.btnCodExc.Text = "E&xcluir";
            this.tipPessoa.SetToolTip(this.btnCodExc, "Excluir");
            this.btnCodExc.UseVisualStyleBackColor = true;
            this.btnCodExc.Click += new System.EventHandler(this.btnCodExc_Click);
            // 
            // btnCod
            // 
            this.btnCod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCod.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCod.Image = ((System.Drawing.Image)(resources.GetObject("btnCod.Image")));
            this.btnCod.Location = new System.Drawing.Point(159, 6);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(23, 23);
            this.btnCod.TabIndex = 1;
            this.tipPessoa.SetToolTip(this.btnCod, "Pesquisar funcionários");
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
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
            this.tipPessoa.SetToolTip(this.txtCpf, "C.P.F. para pesquisar");
            this.txtCpf.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCpf.Enter += new System.EventHandler(this.txtCpf_Enter);
            this.txtCpf.Leave += new System.EventHandler(this.txtCpf_Leave);
            // 
            // btnCpfVisual
            // 
            this.btnCpfVisual.AccessibleDescription = "";
            this.btnCpfVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCpfVisual.Enabled = false;
            this.btnCpfVisual.Location = new System.Drawing.Point(393, 413);
            this.btnCpfVisual.Name = "btnCpfVisual";
            this.btnCpfVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCpfVisual.TabIndex = 3;
            this.btnCpfVisual.Text = "&Visualizar";
            this.tipPessoa.SetToolTip(this.btnCpfVisual, "Visualizar");
            this.btnCpfVisual.UseVisualStyleBackColor = true;
            this.btnCpfVisual.Click += new System.EventHandler(this.btnCpfVisual_Click);
            // 
            // btnCpfIns
            // 
            this.btnCpfIns.AccessibleDescription = "";
            this.btnCpfIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCpfIns.Enabled = false;
            this.btnCpfIns.Location = new System.Drawing.Point(487, 413);
            this.btnCpfIns.Name = "btnCpfIns";
            this.btnCpfIns.Size = new System.Drawing.Size(90, 30);
            this.btnCpfIns.TabIndex = 4;
            this.btnCpfIns.Text = "&Inserir";
            this.tipPessoa.SetToolTip(this.btnCpfIns, "Inserir");
            this.btnCpfIns.UseVisualStyleBackColor = true;
            this.btnCpfIns.Click += new System.EventHandler(this.btnCpfIns_Click);
            // 
            // btnCpfEditar
            // 
            this.btnCpfEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCpfEditar.Enabled = false;
            this.btnCpfEditar.Location = new System.Drawing.Point(581, 413);
            this.btnCpfEditar.Name = "btnCpfEditar";
            this.btnCpfEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCpfEditar.TabIndex = 5;
            this.btnCpfEditar.Text = "&Editar";
            this.tipPessoa.SetToolTip(this.btnCpfEditar, "Editar");
            this.btnCpfEditar.UseVisualStyleBackColor = true;
            this.btnCpfEditar.Click += new System.EventHandler(this.btnCpfEditar_Click);
            // 
            // btnCpfExc
            // 
            this.btnCpfExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCpfExc.Enabled = false;
            this.btnCpfExc.Location = new System.Drawing.Point(675, 413);
            this.btnCpfExc.Name = "btnCpfExc";
            this.btnCpfExc.Size = new System.Drawing.Size(90, 30);
            this.btnCpfExc.TabIndex = 6;
            this.btnCpfExc.Text = "E&xcluir";
            this.tipPessoa.SetToolTip(this.btnCpfExc, "Excluir");
            this.btnCpfExc.UseVisualStyleBackColor = true;
            this.btnCpfExc.Click += new System.EventHandler(this.btnCpfExc_Click);
            // 
            // btnCpf
            // 
            this.btnCpf.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCpf.Image = ((System.Drawing.Image)(resources.GetObject("btnCpf.Image")));
            this.btnCpf.Location = new System.Drawing.Point(159, 6);
            this.btnCpf.Name = "btnCpf";
            this.btnCpf.Size = new System.Drawing.Size(23, 23);
            this.btnCpf.TabIndex = 1;
            this.tipPessoa.SetToolTip(this.btnCpf, "Pesquisar funcionários");
            this.btnCpf.UseVisualStyleBackColor = true;
            this.btnCpf.Click += new System.EventHandler(this.btnCpf_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(698, 494);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipPessoa.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnRegVisual
            // 
            this.btnRegVisual.AccessibleDescription = "";
            this.btnRegVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegVisual.Enabled = false;
            this.btnRegVisual.Location = new System.Drawing.Point(393, 413);
            this.btnRegVisual.Name = "btnRegVisual";
            this.btnRegVisual.Size = new System.Drawing.Size(90, 30);
            this.btnRegVisual.TabIndex = 10;
            this.btnRegVisual.Text = "&Visualizar";
            this.tipPessoa.SetToolTip(this.btnRegVisual, "Visualizar");
            this.btnRegVisual.UseVisualStyleBackColor = true;
            this.btnRegVisual.Click += new System.EventHandler(this.btnRegVisual_Click);
            // 
            // btnRegIns
            // 
            this.btnRegIns.AccessibleDescription = "";
            this.btnRegIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegIns.Enabled = false;
            this.btnRegIns.Location = new System.Drawing.Point(487, 413);
            this.btnRegIns.Name = "btnRegIns";
            this.btnRegIns.Size = new System.Drawing.Size(90, 30);
            this.btnRegIns.TabIndex = 11;
            this.btnRegIns.Text = "&Inserir";
            this.tipPessoa.SetToolTip(this.btnRegIns, "Inserir");
            this.btnRegIns.UseVisualStyleBackColor = true;
            this.btnRegIns.Click += new System.EventHandler(this.btnRegIns_Click);
            // 
            // btnRegEditar
            // 
            this.btnRegEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegEditar.Enabled = false;
            this.btnRegEditar.Location = new System.Drawing.Point(581, 413);
            this.btnRegEditar.Name = "btnRegEditar";
            this.btnRegEditar.Size = new System.Drawing.Size(90, 30);
            this.btnRegEditar.TabIndex = 12;
            this.btnRegEditar.Text = "&Editar";
            this.tipPessoa.SetToolTip(this.btnRegEditar, "Editar");
            this.btnRegEditar.UseVisualStyleBackColor = true;
            this.btnRegEditar.Click += new System.EventHandler(this.btnRegEditar_Click);
            // 
            // btnRegExc
            // 
            this.btnRegExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegExc.Enabled = false;
            this.btnRegExc.Location = new System.Drawing.Point(675, 413);
            this.btnRegExc.Name = "btnRegExc";
            this.btnRegExc.Size = new System.Drawing.Size(90, 30);
            this.btnRegExc.TabIndex = 13;
            this.btnRegExc.Text = "E&xcluir";
            this.tipPessoa.SetToolTip(this.btnRegExc, "Excluir");
            this.btnRegExc.UseVisualStyleBackColor = true;
            this.btnRegExc.Click += new System.EventHandler(this.btnRegExc_Click);
            // 
            // btnComVisual
            // 
            this.btnComVisual.AccessibleDescription = "";
            this.btnComVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComVisual.Enabled = false;
            this.btnComVisual.Location = new System.Drawing.Point(393, 413);
            this.btnComVisual.Name = "btnComVisual";
            this.btnComVisual.Size = new System.Drawing.Size(90, 30);
            this.btnComVisual.TabIndex = 122;
            this.btnComVisual.Text = "&Visualizar";
            this.tipPessoa.SetToolTip(this.btnComVisual, "Visualizar");
            this.btnComVisual.UseVisualStyleBackColor = true;
            this.btnComVisual.Click += new System.EventHandler(this.btnComVisual_Click);
            // 
            // btnComIns
            // 
            this.btnComIns.AccessibleDescription = "";
            this.btnComIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComIns.Enabled = false;
            this.btnComIns.Location = new System.Drawing.Point(487, 413);
            this.btnComIns.Name = "btnComIns";
            this.btnComIns.Size = new System.Drawing.Size(90, 30);
            this.btnComIns.TabIndex = 123;
            this.btnComIns.Text = "&Inserir";
            this.tipPessoa.SetToolTip(this.btnComIns, "Inserir");
            this.btnComIns.UseVisualStyleBackColor = true;
            this.btnComIns.Click += new System.EventHandler(this.btnComIns_Click);
            // 
            // btnComEditar
            // 
            this.btnComEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComEditar.Enabled = false;
            this.btnComEditar.Location = new System.Drawing.Point(581, 413);
            this.btnComEditar.Name = "btnComEditar";
            this.btnComEditar.Size = new System.Drawing.Size(90, 30);
            this.btnComEditar.TabIndex = 124;
            this.btnComEditar.Text = "&Editar";
            this.tipPessoa.SetToolTip(this.btnComEditar, "Editar");
            this.btnComEditar.UseVisualStyleBackColor = true;
            this.btnComEditar.Click += new System.EventHandler(this.btnComEditar_Click);
            // 
            // btnComExc
            // 
            this.btnComExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComExc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComExc.Enabled = false;
            this.btnComExc.Location = new System.Drawing.Point(675, 413);
            this.btnComExc.Name = "btnComExc";
            this.btnComExc.Size = new System.Drawing.Size(90, 30);
            this.btnComExc.TabIndex = 125;
            this.btnComExc.Text = "E&xcluir";
            this.tipPessoa.SetToolTip(this.btnComExc, "Excluir");
            this.btnComExc.UseVisualStyleBackColor = true;
            this.btnComExc.Click += new System.EventHandler(this.btnComExc_Click);
            // 
            // btnNomeImp
            // 
            this.btnNomeImp.AccessibleDescription = "";
            this.btnNomeImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNomeImp.Enabled = false;
            this.btnNomeImp.Image = global::ccbpess.Properties.Resources.Impressora;
            this.btnNomeImp.Location = new System.Drawing.Point(6, 413);
            this.btnNomeImp.Name = "btnNomeImp";
            this.btnNomeImp.Size = new System.Drawing.Size(121, 30);
            this.btnNomeImp.TabIndex = 7;
            this.btnNomeImp.Text = "&Ficha Cadastral";
            this.btnNomeImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPessoa.SetToolTip(this.btnNomeImp, "Visualizar");
            this.btnNomeImp.UseVisualStyleBackColor = true;
            this.btnNomeImp.Click += new System.EventHandler(this.btnNomeImp_Click);
            // 
            // btnCodImp
            // 
            this.btnCodImp.AccessibleDescription = "";
            this.btnCodImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCodImp.Enabled = false;
            this.btnCodImp.Image = global::ccbpess.Properties.Resources.Impressora;
            this.btnCodImp.Location = new System.Drawing.Point(6, 413);
            this.btnCodImp.Name = "btnCodImp";
            this.btnCodImp.Size = new System.Drawing.Size(121, 30);
            this.btnCodImp.TabIndex = 8;
            this.btnCodImp.Text = "&Ficha Cadastral";
            this.btnCodImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPessoa.SetToolTip(this.btnCodImp, "Visualizar");
            this.btnCodImp.UseVisualStyleBackColor = true;
            this.btnCodImp.Click += new System.EventHandler(this.btnCodImp_Click);
            // 
            // btnCpfImp
            // 
            this.btnCpfImp.AccessibleDescription = "";
            this.btnCpfImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCpfImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCpfImp.Enabled = false;
            this.btnCpfImp.Image = global::ccbpess.Properties.Resources.Impressora;
            this.btnCpfImp.Location = new System.Drawing.Point(6, 413);
            this.btnCpfImp.Name = "btnCpfImp";
            this.btnCpfImp.Size = new System.Drawing.Size(121, 30);
            this.btnCpfImp.TabIndex = 8;
            this.btnCpfImp.Text = "&Ficha Cadastral";
            this.btnCpfImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPessoa.SetToolTip(this.btnCpfImp, "Visualizar");
            this.btnCpfImp.UseVisualStyleBackColor = true;
            this.btnCpfImp.Click += new System.EventHandler(this.btnCpfImp_Click);
            // 
            // btnComImp
            // 
            this.btnComImp.AccessibleDescription = "";
            this.btnComImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComImp.Enabled = false;
            this.btnComImp.Image = global::ccbpess.Properties.Resources.Impressora;
            this.btnComImp.Location = new System.Drawing.Point(6, 413);
            this.btnComImp.Name = "btnComImp";
            this.btnComImp.Size = new System.Drawing.Size(121, 30);
            this.btnComImp.TabIndex = 129;
            this.btnComImp.Text = "&Ficha Cadastral";
            this.btnComImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPessoa.SetToolTip(this.btnComImp, "Visualizar");
            this.btnComImp.UseVisualStyleBackColor = true;
            this.btnComImp.Click += new System.EventHandler(this.btnComImp_Click);
            // 
            // btnRegImp
            // 
            this.btnRegImp.AccessibleDescription = "";
            this.btnRegImp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegImp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegImp.Enabled = false;
            this.btnRegImp.Image = global::ccbpess.Properties.Resources.Impressora;
            this.btnRegImp.Location = new System.Drawing.Point(6, 413);
            this.btnRegImp.Name = "btnRegImp";
            this.btnRegImp.Size = new System.Drawing.Size(121, 30);
            this.btnRegImp.TabIndex = 121;
            this.btnRegImp.Text = "&Ficha Cadastral";
            this.btnRegImp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPessoa.SetToolTip(this.btnRegImp, "Visualizar");
            this.btnRegImp.UseVisualStyleBackColor = true;
            this.btnRegImp.Click += new System.EventHandler(this.btnRegImp_Click);
            // 
            // imgPessoa
            // 
            this.imgPessoa.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPessoa.ImageStream")));
            this.imgPessoa.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPessoa.Images.SetKeyName(0, "BolaVermelha.ico");
            this.imgPessoa.Images.SetKeyName(1, "BolaVerde.ico");
            this.imgPessoa.Images.SetKeyName(2, "BolaAmarela.ico");
            this.imgPessoa.Images.SetKeyName(3, "BolaAzul.ico");
            // 
            // tabPessoa
            // 
            this.tabPessoa.Controls.Add(this.tabNome);
            this.tabPessoa.Controls.Add(this.tabCodigo);
            this.tabPessoa.Controls.Add(this.tabCpf);
            this.tabPessoa.Controls.Add(this.tabComum);
            this.tabPessoa.Controls.Add(this.tabRegiao);
            this.tabPessoa.Location = new System.Drawing.Point(8, 6);
            this.tabPessoa.Name = "tabPessoa";
            this.tabPessoa.SelectedIndex = 0;
            this.tabPessoa.Size = new System.Drawing.Size(779, 479);
            this.tabPessoa.TabIndex = 31;
            this.tabPessoa.SelectedIndexChanged += new System.EventHandler(this.tabPessoa_SelectedIndexChanged);
            // 
            // tabNome
            // 
            this.tabNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabNome.Controls.Add(this.btnNomeImp);
            this.tabNome.Controls.Add(this.txtNome);
            this.tabNome.Controls.Add(this.gridNome);
            this.tabNome.Controls.Add(this.btnNomeVisual);
            this.tabNome.Controls.Add(this.btnNomeIns);
            this.tabNome.Controls.Add(this.btnNomeEditar);
            this.tabNome.Controls.Add(this.btnNomeExc);
            this.tabNome.Controls.Add(this.btnNome);
            this.tabNome.ForeColor = System.Drawing.Color.Black;
            this.tabNome.Location = new System.Drawing.Point(4, 22);
            this.tabNome.Name = "tabNome";
            this.tabNome.Padding = new System.Windows.Forms.Padding(3);
            this.tabNome.Size = new System.Drawing.Size(771, 453);
            this.tabNome.TabIndex = 1;
            this.tabNome.Text = "Nome";
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
            this.gridNome.Size = new System.Drawing.Size(759, 371);
            this.gridNome.TabIndex = 2;
            this.gridNome.DataSourceChanged += new System.EventHandler(this.gridNome_DataSourceChanged);
            this.gridNome.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNome_CellDoubleClick);
            this.gridNome.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridNome_DataBindingComplete);
            this.gridNome.SelectionChanged += new System.EventHandler(this.gridNome_SelectionChanged);
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
            this.gridCodigo.Size = new System.Drawing.Size(759, 371);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.DataSourceChanged += new System.EventHandler(this.gridCodigo_DataSourceChanged);
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridCodigo_DataBindingComplete);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
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
            // gridCpf
            // 
            this.gridCpf.AllowUserToAddRows = false;
            this.gridCpf.AllowUserToDeleteRows = false;
            this.gridCpf.AllowUserToResizeRows = false;
            this.gridCpf.BackgroundColor = System.Drawing.Color.White;
            this.gridCpf.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCpf.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            this.gridCpf.DataSourceChanged += new System.EventHandler(this.gridCpf_DataSourceChanged);
            this.gridCpf.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCpf_CellDoubleClick);
            this.gridCpf.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridCpf_DataBindingComplete);
            this.gridCpf.SelectionChanged += new System.EventHandler(this.gridCpf_SelectionChanged);
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
            this.lblCodComum.TextChanged += new System.EventHandler(this.lblCodComum_TextChanged);
            // 
            // btnComum
            // 
            this.btnComum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnComum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComum.Image = global::ccbpess.Properties.Resources.PesquisaOS;
            this.btnComum.Location = new System.Drawing.Point(8, 5);
            this.btnComum.Name = "btnComum";
            this.btnComum.Size = new System.Drawing.Size(90, 26);
            this.btnComum.TabIndex = 126;
            this.btnComum.Text = "Comum";
            this.btnComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnComum.UseVisualStyleBackColor = true;
            this.btnComum.Click += new System.EventHandler(this.btnComum_Click);
            // 
            // gridComum
            // 
            this.gridComum.AllowUserToAddRows = false;
            this.gridComum.AllowUserToDeleteRows = false;
            this.gridComum.AllowUserToResizeRows = false;
            this.gridComum.BackgroundColor = System.Drawing.Color.White;
            this.gridComum.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridComum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            this.gridComum.DataSourceChanged += new System.EventHandler(this.gridComum_DataSourceChanged);
            this.gridComum.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComum_CellDoubleClick);
            this.gridComum.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridComum_DataBindingComplete);
            this.gridComum.SelectionChanged += new System.EventHandler(this.gridComum_SelectionChanged);
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
            this.lblCodRegiao.TextChanged += new System.EventHandler(this.lblCodRegiao_TextChanged);
            // 
            // btnRegiao
            // 
            this.btnRegiao.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegiao.Image = global::ccbpess.Properties.Resources.PesquisaOS;
            this.btnRegiao.Location = new System.Drawing.Point(8, 5);
            this.btnRegiao.Name = "btnRegiao";
            this.btnRegiao.Size = new System.Drawing.Size(90, 26);
            this.btnRegiao.TabIndex = 118;
            this.btnRegiao.Text = "Região";
            this.btnRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRegiao.UseVisualStyleBackColor = true;
            this.btnRegiao.Click += new System.EventHandler(this.btnRegiao_Click);
            // 
            // gridRegiao
            // 
            this.gridRegiao.AllowUserToAddRows = false;
            this.gridRegiao.AllowUserToDeleteRows = false;
            this.gridRegiao.AllowUserToResizeRows = false;
            this.gridRegiao.BackgroundColor = System.Drawing.Color.White;
            this.gridRegiao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegiao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
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
            this.gridRegiao.DataSourceChanged += new System.EventHandler(this.gridRegiao_DataSourceChanged);
            this.gridRegiao.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellDoubleClick);
            this.gridRegiao.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridRegiao_DataBindingComplete);
            this.gridRegiao.SelectionChanged += new System.EventHandler(this.gridRegiao_SelectionChanged);
            // 
            // lblInativa
            // 
            this.lblInativa.AutoSize = true;
            this.lblInativa.Location = new System.Drawing.Point(80, 502);
            this.lblInativa.Name = "lblInativa";
            this.lblInativa.Size = new System.Drawing.Size(41, 13);
            this.lblInativa.TabIndex = 36;
            this.lblInativa.Text = "Inativo";
            // 
            // pctInativa
            // 
            this.pctInativa.Location = new System.Drawing.Point(64, 499);
            this.pctInativa.Name = "pctInativa";
            this.pctInativa.Size = new System.Drawing.Size(16, 20);
            this.pctInativa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctInativa.TabIndex = 35;
            this.pctInativa.TabStop = false;
            // 
            // lblAtiva
            // 
            this.lblAtiva.AutoSize = true;
            this.lblAtiva.Location = new System.Drawing.Point(26, 502);
            this.lblAtiva.Name = "lblAtiva";
            this.lblAtiva.Size = new System.Drawing.Size(32, 13);
            this.lblAtiva.TabIndex = 34;
            this.lblAtiva.Text = "Ativo";
            // 
            // pctAtiva
            // 
            this.pctAtiva.Location = new System.Drawing.Point(9, 499);
            this.pctAtiva.Name = "pctAtiva";
            this.pctAtiva.Size = new System.Drawing.Size(16, 20);
            this.pctAtiva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAtiva.TabIndex = 33;
            this.pctAtiva.TabStop = false;
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Location = new System.Drawing.Point(268, 502);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(119, 13);
            this.lblQtde.TabIndex = 37;
            this.lblQtde.Text = "Qtde registros listados:";
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.LightGray;
            this.txtQtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtde.Enabled = false;
            this.txtQtde.Location = new System.Drawing.Point(387, 498);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(47, 21);
            this.txtQtde.TabIndex = 38;
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtde.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // frmPessoaBusca
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
            this.MaximizeBox = false;
            this.Name = "frmPessoaBusca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pessoas";
            this.Load += new System.EventHandler(this.frmPessoaBusca_Load);
            this.tabPessoa.ResumeLayout(false);
            this.tabNome.ResumeLayout(false);
            this.tabNome.PerformLayout();
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

        private System.Windows.Forms.ToolTip tipPessoa;
        private System.Windows.Forms.ImageList imgPessoa;
        private BLL.validacoes.Controles.tabControlPersonal tabPessoa;
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
        private System.Windows.Forms.TabPage tabCpf;
        private BLL.validacoes.Controles.TextBoxPersonal txtCpf;
        private System.Windows.Forms.DataGridView gridCpf;
        private System.Windows.Forms.Button btnCpfVisual;
        private System.Windows.Forms.Button btnCpfIns;
        private System.Windows.Forms.Button btnCpfEditar;
        private System.Windows.Forms.Button btnCpfExc;
        private System.Windows.Forms.Button btnCpf;
        private System.Windows.Forms.Label lblInativa;
        private System.Windows.Forms.PictureBox pctInativa;
        private System.Windows.Forms.Label lblAtiva;
        private System.Windows.Forms.PictureBox pctAtiva;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblQtde;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtde;
        private System.Windows.Forms.TabPage tabRegiao;
        private System.Windows.Forms.DataGridView gridRegiao;
        private System.Windows.Forms.Button btnRegVisual;
        private System.Windows.Forms.Button btnRegIns;
        private System.Windows.Forms.Button btnRegEditar;
        private System.Windows.Forms.Button btnRegExc;
        private System.Windows.Forms.Label lblDescricaoRegiao;
        private System.Windows.Forms.Label lblCodRegiao;
        private System.Windows.Forms.Button btnRegiao;
        private System.Windows.Forms.TabPage tabComum;
        private System.Windows.Forms.Label lblDescricaoComum;
        private System.Windows.Forms.Label lblCodComum;
        private System.Windows.Forms.Button btnComum;
        private System.Windows.Forms.DataGridView gridComum;
        private System.Windows.Forms.Button btnComVisual;
        private System.Windows.Forms.Button btnComIns;
        private System.Windows.Forms.Button btnComEditar;
        private System.Windows.Forms.Button btnComExc;
        private System.Windows.Forms.Button btnNomeImp;
        private System.Windows.Forms.Button btnCodImp;
        private System.Windows.Forms.Button btnCpfImp;
        private System.Windows.Forms.Button btnComImp;
        private System.Windows.Forms.Button btnRegImp;
    }
}