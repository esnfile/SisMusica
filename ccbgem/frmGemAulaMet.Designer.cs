namespace ccbgem
{
    partial class frmGemAulaMet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGemAulaMet));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlAula = new System.Windows.Forms.Panel();
            this.txtPaginaFaseRjm = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblPaginaFaseRjm = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.txtObs = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtProxima = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlSituacao = new System.Windows.Forms.Panel();
            this.optConcluido = new System.Windows.Forms.RadioButton();
            this.optEstudar = new System.Windows.Forms.RadioButton();
            this.txtLicao = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.numericUpDownPersonal1 = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.txtPag = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.cboMetodo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.gridExecutada = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.linha2 = new System.Windows.Forms.Panel();
            this.linha1 = new System.Windows.Forms.Panel();
            this.btnInstrutor = new System.Windows.Forms.Button();
            this.lblObs = new System.Windows.Forms.Label();
            this.lblAluno = new System.Windows.Forms.Label();
            this.lblProxima = new System.Windows.Forms.Label();
            this.lblExecutadas = new System.Windows.Forms.Label();
            this.lblFase = new System.Windows.Forms.Label();
            this.lblLicao = new System.Windows.Forms.Label();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblMetodo = new System.Windows.Forms.Label();
            this.lblSituacao = new System.Windows.Forms.Label();
            this.lbAluno = new System.Windows.Forms.Label();
            this.txtDataAula = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataAula = new System.Windows.Forms.Label();
            this.txtCodInstrutor = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblInstrutor = new System.Windows.Forms.Label();
            this.lbPessoa = new System.Windows.Forms.Label();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.cboLicao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.btnVisual = new System.Windows.Forms.Button();
            this.pnlAula.SuspendLayout();
            this.pnlSituacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPersonal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExecutada)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalvar.Location = new System.Drawing.Point(293, 370);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 24;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(387, 370);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 25;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // pnlAula
            // 
            this.pnlAula.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlAula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAula.Controls.Add(this.txtPaginaFaseRjm);
            this.pnlAula.Controls.Add(this.lblPaginaFaseRjm);
            this.pnlAula.Controls.Add(this.btnGravar);
            this.pnlAula.Controls.Add(this.txtObs);
            this.pnlAula.Controls.Add(this.txtProxima);
            this.pnlAula.Controls.Add(this.pnlSituacao);
            this.pnlAula.Controls.Add(this.txtLicao);
            this.pnlAula.Controls.Add(this.numericUpDownPersonal1);
            this.pnlAula.Controls.Add(this.txtPag);
            this.pnlAula.Controls.Add(this.cboMetodo);
            this.pnlAula.Controls.Add(this.gridExecutada);
            this.pnlAula.Controls.Add(this.linha2);
            this.pnlAula.Controls.Add(this.linha1);
            this.pnlAula.Controls.Add(this.btnInstrutor);
            this.pnlAula.Controls.Add(this.lblObs);
            this.pnlAula.Controls.Add(this.lblAluno);
            this.pnlAula.Controls.Add(this.lblProxima);
            this.pnlAula.Controls.Add(this.lblExecutadas);
            this.pnlAula.Controls.Add(this.lblFase);
            this.pnlAula.Controls.Add(this.lblLicao);
            this.pnlAula.Controls.Add(this.lblPagina);
            this.pnlAula.Controls.Add(this.lblMetodo);
            this.pnlAula.Controls.Add(this.lblSituacao);
            this.pnlAula.Controls.Add(this.lbAluno);
            this.pnlAula.Controls.Add(this.txtDataAula);
            this.pnlAula.Controls.Add(this.lblDataAula);
            this.pnlAula.Controls.Add(this.txtCodInstrutor);
            this.pnlAula.Controls.Add(this.lblInstrutor);
            this.pnlAula.Controls.Add(this.lbPessoa);
            this.pnlAula.Controls.Add(this.txtCodigo);
            this.pnlAula.Controls.Add(this.lblCodigo);
            this.pnlAula.Controls.Add(this.cboLicao);
            this.pnlAula.Location = new System.Drawing.Point(6, 6);
            this.pnlAula.Name = "pnlAula";
            this.pnlAula.Size = new System.Drawing.Size(470, 361);
            this.pnlAula.TabIndex = 23;
            // 
            // txtPaginaFaseRjm
            // 
            this.txtPaginaFaseRjm.BackColor = System.Drawing.Color.Silver;
            this.txtPaginaFaseRjm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPaginaFaseRjm.Enabled = false;
            this.txtPaginaFaseRjm.Location = new System.Drawing.Point(327, 76);
            this.txtPaginaFaseRjm.Name = "txtPaginaFaseRjm";
            this.txtPaginaFaseRjm.Size = new System.Drawing.Size(119, 21);
            this.txtPaginaFaseRjm.TabIndex = 108;
            this.txtPaginaFaseRjm.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblPaginaFaseRjm
            // 
            this.lblPaginaFaseRjm.AutoSize = true;
            this.lblPaginaFaseRjm.Enabled = false;
            this.lblPaginaFaseRjm.Location = new System.Drawing.Point(230, 80);
            this.lblPaginaFaseRjm.Name = "lblPaginaFaseRjm";
            this.lblPaginaFaseRjm.Size = new System.Drawing.Size(98, 13);
            this.lblPaginaFaseRjm.TabIndex = 109;
            this.lblPaginaFaseRjm.Text = "Definição será por:";
            // 
            // btnGravar
            // 
            this.btnGravar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGravar.Image = global::ccbgem.Properties.Resources.button_ok;
            this.btnGravar.Location = new System.Drawing.Point(332, 128);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(114, 25);
            this.btnGravar.TabIndex = 16;
            this.btnGravar.Text = "&Gravar lição";
            this.btnGravar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGravar.UseVisualStyleBackColor = true;
            // 
            // txtObs
            // 
            this.txtObs.BackColor = System.Drawing.Color.White;
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.Location = new System.Drawing.Point(9, 276);
            this.txtObs.MaxLength = 500;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(198, 75);
            this.txtObs.TabIndex = 18;
            this.txtObs.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtProxima
            // 
            this.txtProxima.BackColor = System.Drawing.Color.White;
            this.txtProxima.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProxima.Location = new System.Drawing.Point(221, 276);
            this.txtProxima.MaxLength = 1000;
            this.txtProxima.Multiline = true;
            this.txtProxima.Name = "txtProxima";
            this.txtProxima.Size = new System.Drawing.Size(239, 75);
            this.txtProxima.TabIndex = 19;
            this.txtProxima.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // pnlSituacao
            // 
            this.pnlSituacao.Controls.Add(this.optConcluido);
            this.pnlSituacao.Controls.Add(this.optEstudar);
            this.pnlSituacao.Location = new System.Drawing.Point(70, 128);
            this.pnlSituacao.Name = "pnlSituacao";
            this.pnlSituacao.Size = new System.Drawing.Size(238, 25);
            this.pnlSituacao.TabIndex = 13;
            // 
            // optConcluido
            // 
            this.optConcluido.Appearance = System.Windows.Forms.Appearance.Button;
            this.optConcluido.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optConcluido.Image = global::ccbgem.Properties.Resources.emoji_5;
            this.optConcluido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.optConcluido.Location = new System.Drawing.Point(103, 0);
            this.optConcluido.Name = "optConcluido";
            this.optConcluido.Size = new System.Drawing.Size(123, 25);
            this.optConcluido.TabIndex = 15;
            this.optConcluido.TabStop = true;
            this.optConcluido.Text = "Passou, parabéns!";
            this.optConcluido.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optConcluido.UseVisualStyleBackColor = true;
            // 
            // optEstudar
            // 
            this.optEstudar.Appearance = System.Windows.Forms.Appearance.Button;
            this.optEstudar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.optEstudar.Image = global::ccbgem.Properties.Resources.emoji_1;
            this.optEstudar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.optEstudar.Location = new System.Drawing.Point(1, 0);
            this.optEstudar.Name = "optEstudar";
            this.optEstudar.Size = new System.Drawing.Size(100, 25);
            this.optEstudar.TabIndex = 14;
            this.optEstudar.TabStop = true;
            this.optEstudar.Text = "Treinar mais";
            this.optEstudar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.optEstudar.UseVisualStyleBackColor = true;
            // 
            // txtLicao
            // 
            this.txtLicao.BackColor = System.Drawing.Color.White;
            this.txtLicao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicao.Enabled = false;
            this.txtLicao.Location = new System.Drawing.Point(279, 102);
            this.txtLicao.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtLicao.Name = "txtLicao";
            this.txtLicao.Size = new System.Drawing.Size(51, 21);
            this.txtLicao.TabIndex = 12;
            this.txtLicao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // numericUpDownPersonal1
            // 
            this.numericUpDownPersonal1.BackColor = System.Drawing.Color.White;
            this.numericUpDownPersonal1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownPersonal1.Enabled = false;
            this.numericUpDownPersonal1.Location = new System.Drawing.Point(71, 102);
            this.numericUpDownPersonal1.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.numericUpDownPersonal1.Name = "numericUpDownPersonal1";
            this.numericUpDownPersonal1.Size = new System.Drawing.Size(51, 21);
            this.numericUpDownPersonal1.TabIndex = 11;
            this.numericUpDownPersonal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPag
            // 
            this.txtPag.BackColor = System.Drawing.Color.White;
            this.txtPag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPag.Enabled = false;
            this.txtPag.Location = new System.Drawing.Point(179, 102);
            this.txtPag.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txtPag.Name = "txtPag";
            this.txtPag.Size = new System.Drawing.Size(51, 21);
            this.txtPag.TabIndex = 11;
            this.txtPag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboMetodo
            // 
            this.cboMetodo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMetodo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMetodo.FormattingEnabled = true;
            this.cboMetodo.Location = new System.Drawing.Point(70, 76);
            this.cboMetodo.Name = "cboMetodo";
            this.cboMetodo.Size = new System.Drawing.Size(151, 21);
            this.cboMetodo.TabIndex = 9;
            // 
            // gridExecutada
            // 
            this.gridExecutada.AllowUserToAddRows = false;
            this.gridExecutada.AllowUserToDeleteRows = false;
            this.gridExecutada.AllowUserToResizeRows = false;
            this.gridExecutada.BackgroundColor = System.Drawing.Color.White;
            this.gridExecutada.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridExecutada.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridExecutada.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridExecutada.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridExecutada.DisabledCell = null;
            this.gridExecutada.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridExecutada.EnableHeadersVisualStyles = false;
            this.gridExecutada.Location = new System.Drawing.Point(9, 176);
            this.gridExecutada.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridExecutada.MultiSelect = false;
            this.gridExecutada.Name = "gridExecutada";
            this.gridExecutada.ReadOnly = true;
            this.gridExecutada.RowHeadersVisible = false;
            this.gridExecutada.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridExecutada.RowTemplate.Height = 18;
            this.gridExecutada.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridExecutada.Size = new System.Drawing.Size(451, 77);
            this.gridExecutada.TabIndex = 17;
            // 
            // linha2
            // 
            this.linha2.BackColor = System.Drawing.Color.DarkGray;
            this.linha2.Location = new System.Drawing.Point(10, 156);
            this.linha2.Name = "linha2";
            this.linha2.Size = new System.Drawing.Size(450, 1);
            this.linha2.TabIndex = 107;
            // 
            // linha1
            // 
            this.linha1.BackColor = System.Drawing.Color.DarkGray;
            this.linha1.Location = new System.Drawing.Point(10, 69);
            this.linha1.Name = "linha1";
            this.linha1.Size = new System.Drawing.Size(450, 1);
            this.linha1.TabIndex = 107;
            // 
            // btnInstrutor
            // 
            this.btnInstrutor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstrutor.Enabled = false;
            this.btnInstrutor.Image = ((System.Drawing.Image)(resources.GetObject("btnInstrutor.Image")));
            this.btnInstrutor.Location = new System.Drawing.Point(122, 37);
            this.btnInstrutor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInstrutor.Name = "btnInstrutor";
            this.btnInstrutor.Size = new System.Drawing.Size(23, 23);
            this.btnInstrutor.TabIndex = 4;
            this.btnInstrutor.UseVisualStyleBackColor = true;
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Enabled = false;
            this.lblObs.Location = new System.Drawing.Point(9, 261);
            this.lblObs.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(133, 13);
            this.lblObs.TabIndex = 90;
            this.lblObs.Text = "Observações e Anotações";
            // 
            // lblAluno
            // 
            this.lblAluno.Enabled = false;
            this.lblAluno.Location = new System.Drawing.Point(308, 16);
            this.lblAluno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAluno.Name = "lblAluno";
            this.lblAluno.Size = new System.Drawing.Size(152, 13);
            this.lblAluno.TabIndex = 106;
            // 
            // lblProxima
            // 
            this.lblProxima.AutoSize = true;
            this.lblProxima.Enabled = false;
            this.lblProxima.Location = new System.Drawing.Point(221, 261);
            this.lblProxima.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblProxima.Name = "lblProxima";
            this.lblProxima.Size = new System.Drawing.Size(146, 13);
            this.lblProxima.TabIndex = 90;
            this.lblProxima.Text = "Atividades para próxima aula";
            // 
            // lblExecutadas
            // 
            this.lblExecutadas.AutoSize = true;
            this.lblExecutadas.Enabled = false;
            this.lblExecutadas.Location = new System.Drawing.Point(9, 160);
            this.lblExecutadas.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblExecutadas.Name = "lblExecutadas";
            this.lblExecutadas.Size = new System.Drawing.Size(161, 13);
            this.lblExecutadas.TabIndex = 90;
            this.lblExecutadas.Text = "Matérias executadas nessa aula";
            // 
            // lblFase
            // 
            this.lblFase.AutoSize = true;
            this.lblFase.Enabled = false;
            this.lblFase.Location = new System.Drawing.Point(18, 106);
            this.lblFase.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFase.Name = "lblFase";
            this.lblFase.Size = new System.Drawing.Size(34, 13);
            this.lblFase.TabIndex = 90;
            this.lblFase.Text = "Fase:";
            // 
            // lblLicao
            // 
            this.lblLicao.AutoSize = true;
            this.lblLicao.Enabled = false;
            this.lblLicao.Location = new System.Drawing.Point(239, 106);
            this.lblLicao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLicao.Name = "lblLicao";
            this.lblLicao.Size = new System.Drawing.Size(35, 13);
            this.lblLicao.TabIndex = 90;
            this.lblLicao.Text = "Lição:";
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Enabled = false;
            this.lblPagina.Location = new System.Drawing.Point(133, 106);
            this.lblPagina.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(43, 13);
            this.lblPagina.TabIndex = 90;
            this.lblPagina.Text = "Página:";
            // 
            // lblMetodo
            // 
            this.lblMetodo.AutoSize = true;
            this.lblMetodo.Location = new System.Drawing.Point(18, 80);
            this.lblMetodo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMetodo.Name = "lblMetodo";
            this.lblMetodo.Size = new System.Drawing.Size(47, 13);
            this.lblMetodo.TabIndex = 90;
            this.lblMetodo.Text = "Método:";
            // 
            // lblSituacao
            // 
            this.lblSituacao.AutoSize = true;
            this.lblSituacao.Location = new System.Drawing.Point(18, 133);
            this.lblSituacao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSituacao.Name = "lblSituacao";
            this.lblSituacao.Size = new System.Drawing.Size(52, 13);
            this.lblSituacao.TabIndex = 90;
            this.lblSituacao.Text = "Situação:";
            // 
            // lbAluno
            // 
            this.lbAluno.AutoSize = true;
            this.lbAluno.Enabled = false;
            this.lbAluno.Location = new System.Drawing.Point(268, 16);
            this.lbAluno.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbAluno.Name = "lbAluno";
            this.lbAluno.Size = new System.Drawing.Size(38, 13);
            this.lbAluno.TabIndex = 90;
            this.lbAluno.Text = "Aluno:";
            // 
            // txtDataAula
            // 
            this.txtDataAula.BackColor = System.Drawing.Color.LightGray;
            this.txtDataAula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataAula.Enabled = false;
            this.txtDataAula.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataAula.Location = new System.Drawing.Point(187, 12);
            this.txtDataAula.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataAula.Name = "txtDataAula";
            this.txtDataAula.Size = new System.Drawing.Size(75, 21);
            this.txtDataAula.TabIndex = 2;
            this.txtDataAula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataAula.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataAula
            // 
            this.lblDataAula.AutoSize = true;
            this.lblDataAula.Enabled = false;
            this.lblDataAula.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDataAula.Location = new System.Drawing.Point(127, 16);
            this.lblDataAula.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataAula.Name = "lblDataAula";
            this.lblDataAula.Size = new System.Drawing.Size(58, 13);
            this.lblDataAula.TabIndex = 97;
            this.lblDataAula.Text = "Data Aula:";
            // 
            // txtCodInstrutor
            // 
            this.txtCodInstrutor.BackColor = System.Drawing.Color.White;
            this.txtCodInstrutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodInstrutor.Enabled = false;
            this.txtCodInstrutor.Location = new System.Drawing.Point(74, 38);
            this.txtCodInstrutor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodInstrutor.MaxLength = 6;
            this.txtCodInstrutor.Name = "txtCodInstrutor";
            this.txtCodInstrutor.Size = new System.Drawing.Size(45, 21);
            this.txtCodInstrutor.TabIndex = 3;
            this.txtCodInstrutor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodInstrutor.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // lblInstrutor
            // 
            this.lblInstrutor.Enabled = false;
            this.lblInstrutor.Location = new System.Drawing.Point(149, 42);
            this.lblInstrutor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInstrutor.Name = "lblInstrutor";
            this.lblInstrutor.Size = new System.Drawing.Size(311, 13);
            this.lblInstrutor.TabIndex = 79;
            // 
            // lbPessoa
            // 
            this.lbPessoa.AutoSize = true;
            this.lbPessoa.Enabled = false;
            this.lbPessoa.Location = new System.Drawing.Point(8, 42);
            this.lbPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPessoa.Name = "lbPessoa";
            this.lbPessoa.Size = new System.Drawing.Size(68, 13);
            this.lbPessoa.TabIndex = 76;
            this.lbPessoa.Text = "Instrutor(a):";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(74, 12);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(45, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(8, 16);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(47, 13);
            this.lblCodigo.TabIndex = 12;
            this.lblCodigo.Text = "Aula Nº:";
            // 
            // cboLicao
            // 
            this.cboLicao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboLicao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboLicao.FormattingEnabled = true;
            this.cboLicao.Location = new System.Drawing.Point(279, 102);
            this.cboLicao.Name = "cboLicao";
            this.cboLicao.Size = new System.Drawing.Size(167, 21);
            this.cboLicao.TabIndex = 110;
            this.cboLicao.Visible = false;
            // 
            // btnVisual
            // 
            this.btnVisual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVisual.Location = new System.Drawing.Point(6, 370);
            this.btnVisual.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnVisual.Name = "btnVisual";
            this.btnVisual.Size = new System.Drawing.Size(90, 30);
            this.btnVisual.TabIndex = 26;
            this.btnVisual.Text = "&Aula Anteriores";
            this.btnVisual.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVisual.UseVisualStyleBackColor = true;
            // 
            // frmGemAulaMet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(482, 407);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlAula);
            this.Controls.Add(this.btnVisual);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmGemAulaMet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aula de Instrumento (Métodos)";
            this.Load += new System.EventHandler(this.frmGemAcompAula_Load);
            this.pnlAula.ResumeLayout(false);
            this.pnlAula.PerformLayout();
            this.pnlSituacao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPersonal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridExecutada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlAula;
        private BLL.validacoes.Controles.TextBoxPersonal txtPaginaFaseRjm;
        private System.Windows.Forms.Label lblPaginaFaseRjm;
        private System.Windows.Forms.Button btnGravar;
        private BLL.validacoes.Controles.TextBoxPersonal txtObs;
        private BLL.validacoes.Controles.TextBoxPersonal txtProxima;
        private System.Windows.Forms.Panel pnlSituacao;
        private System.Windows.Forms.RadioButton optConcluido;
        private System.Windows.Forms.RadioButton optEstudar;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtLicao;
        private BLL.validacoes.Controles.NumericUpDownPersonal numericUpDownPersonal1;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtPag;
        private BLL.validacoes.Controles.ComboBoxPersonal cboMetodo;
        private BLL.validacoes.Controles.DataGridViewPersonal gridExecutada;
        private System.Windows.Forms.Panel linha2;
        private System.Windows.Forms.Panel linha1;
        private System.Windows.Forms.Button btnInstrutor;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.Label lblAluno;
        private System.Windows.Forms.Label lblProxima;
        private System.Windows.Forms.Label lblExecutadas;
        private System.Windows.Forms.Label lblFase;
        private System.Windows.Forms.Label lblLicao;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblMetodo;
        private System.Windows.Forms.Label lblSituacao;
        private System.Windows.Forms.Label lbAluno;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataAula;
        private System.Windows.Forms.Label lblDataAula;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodInstrutor;
        private System.Windows.Forms.Label lblInstrutor;
        private System.Windows.Forms.Label lbPessoa;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboLicao;
        private System.Windows.Forms.Button btnVisual;
    }
}