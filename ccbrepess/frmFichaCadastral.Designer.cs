namespace ccbrepess
{
    partial class frmFichaCadastral
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFichaCadastral));
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblSolteiro = new System.Windows.Forms.Label();
            this.lblCasado = new System.Windows.Forms.Label();
            this.lblViuvo = new System.Windows.Forms.Label();
            this.lblDivorciado = new System.Windows.Forms.Label();
            this.pnlFicha = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkPulaPagina = new System.Windows.Forms.CheckBox();
            this.gpoAdicionais = new System.Windows.Forms.GroupBox();
            this.optDadosCompleto = new System.Windows.Forms.RadioButton();
            this.optDadosBasicos = new System.Windows.Forms.RadioButton();
            this.lblExibeComp = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMsgBasico = new System.Windows.Forms.Label();
            this.lblExibeDados = new System.Windows.Forms.Label();
            this.gpoSexo = new System.Windows.Forms.GroupBox();
            this.chkMasculino = new System.Windows.Forms.CheckBox();
            this.chkFeminino = new System.Windows.Forms.CheckBox();
            this.gpoEstadoCivil = new System.Windows.Forms.GroupBox();
            this.chkDivorciado = new System.Windows.Forms.CheckBox();
            this.chkViuvo = new System.Windows.Forms.CheckBox();
            this.chkCasado = new System.Windows.Forms.CheckBox();
            this.chkSolteiro = new System.Windows.Forms.CheckBox();
            this.gpoSelecione = new System.Windows.Forms.GroupBox();
            this.gridRegiao = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.cboRegional = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegional = new System.Windows.Forms.Label();
            this.gridComum = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.gridPessoa = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.cboCargo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblCargo = new System.Windows.Forms.Label();
            this.gpoStatus = new System.Windows.Forms.GroupBox();
            this.chkInativo = new System.Windows.Forms.CheckBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.lblSelecionados = new System.Windows.Forms.Label();
            this.lblQtdeRegistro = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtSelecionados = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtQtdeRegistro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.tipFicha = new System.Windows.Forms.ToolTip(this.components);
            this.btnCracha = new System.Windows.Forms.Button();
            this.btnFicha = new System.Windows.Forms.Button();
            this.btnCartao = new System.Windows.Forms.Button();
            this.btnDesRegiao = new System.Windows.Forms.Button();
            this.btnSelRegiao = new System.Windows.Forms.Button();
            this.btnDesPessoa = new System.Windows.Forms.Button();
            this.btnSelPessoa = new System.Windows.Forms.Button();
            this.btnDesComum = new System.Windows.Forms.Button();
            this.btnSelComum = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlFicha.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpoAdicionais.SuspendLayout();
            this.gpoSexo.SuspendLayout();
            this.gpoEstadoCivil.SuspendLayout();
            this.gpoSelecione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoa)).BeginInit();
            this.gpoStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSexo
            // 
            this.lblSexo.Location = new System.Drawing.Point(21, 436);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(118, 13);
            this.lblSexo.TabIndex = 41;
            this.lblSexo.Text = "Masculino\', \'Feminino";
            this.lblSexo.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(18, 453);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 13);
            this.lblStatus.TabIndex = 42;
            this.lblStatus.Text = "Sim";
            this.lblStatus.Visible = false;
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.Location = new System.Drawing.Point(83, 453);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(241, 13);
            this.lblEstadoCivil.TabIndex = 43;
            this.lblEstadoCivil.Text = "Solteiro(a)\',\'Casado(a)\',\'Viúvo(a)\',\'Divorciado(a)";
            this.lblEstadoCivil.Visible = false;
            // 
            // lblSolteiro
            // 
            this.lblSolteiro.Location = new System.Drawing.Point(138, 436);
            this.lblSolteiro.Name = "lblSolteiro";
            this.lblSolteiro.Size = new System.Drawing.Size(64, 13);
            this.lblSolteiro.TabIndex = 44;
            this.lblSolteiro.Text = "Solteiro(a)";
            this.lblSolteiro.Visible = false;
            // 
            // lblCasado
            // 
            this.lblCasado.Location = new System.Drawing.Point(202, 436);
            this.lblCasado.Name = "lblCasado";
            this.lblCasado.Size = new System.Drawing.Size(62, 13);
            this.lblCasado.TabIndex = 45;
            this.lblCasado.Text = "Casado(a)";
            this.lblCasado.Visible = false;
            // 
            // lblViuvo
            // 
            this.lblViuvo.Location = new System.Drawing.Point(263, 436);
            this.lblViuvo.Name = "lblViuvo";
            this.lblViuvo.Size = new System.Drawing.Size(47, 13);
            this.lblViuvo.TabIndex = 46;
            this.lblViuvo.Text = "Viúvo(a)";
            this.lblViuvo.Visible = false;
            // 
            // lblDivorciado
            // 
            this.lblDivorciado.Location = new System.Drawing.Point(316, 436);
            this.lblDivorciado.Name = "lblDivorciado";
            this.lblDivorciado.Size = new System.Drawing.Size(71, 13);
            this.lblDivorciado.TabIndex = 47;
            this.lblDivorciado.Text = "Divorciado(a)";
            this.lblDivorciado.Visible = false;
            // 
            // pnlFicha
            // 
            this.pnlFicha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlFicha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFicha.Controls.Add(this.groupBox1);
            this.pnlFicha.Controls.Add(this.btnCracha);
            this.pnlFicha.Controls.Add(this.btnFicha);
            this.pnlFicha.Controls.Add(this.btnCartao);
            this.pnlFicha.Controls.Add(this.gpoAdicionais);
            this.pnlFicha.Controls.Add(this.gpoSexo);
            this.pnlFicha.Controls.Add(this.gpoEstadoCivil);
            this.pnlFicha.Controls.Add(this.gpoSelecione);
            this.pnlFicha.Controls.Add(this.gpoStatus);
            this.pnlFicha.Location = new System.Drawing.Point(7, 7);
            this.pnlFicha.Name = "pnlFicha";
            this.pnlFicha.Size = new System.Drawing.Size(875, 426);
            this.pnlFicha.TabIndex = 48;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkPulaPagina);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(11, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 42);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurações adicionais";
            // 
            // chkPulaPagina
            // 
            this.chkPulaPagina.AutoSize = true;
            this.chkPulaPagina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPulaPagina.Location = new System.Drawing.Point(12, 18);
            this.chkPulaPagina.Name = "chkPulaPagina";
            this.chkPulaPagina.Size = new System.Drawing.Size(202, 17);
            this.chkPulaPagina.TabIndex = 25;
            this.chkPulaPagina.Text = "Inicia novo registro em nova página?";
            this.chkPulaPagina.UseVisualStyleBackColor = true;
            // 
            // gpoAdicionais
            // 
            this.gpoAdicionais.Controls.Add(this.optDadosCompleto);
            this.gpoAdicionais.Controls.Add(this.optDadosBasicos);
            this.gpoAdicionais.Controls.Add(this.lblExibeComp);
            this.gpoAdicionais.Controls.Add(this.label1);
            this.gpoAdicionais.Controls.Add(this.lblMsgBasico);
            this.gpoAdicionais.Controls.Add(this.lblExibeDados);
            this.gpoAdicionais.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAdicionais.Location = new System.Drawing.Point(333, 5);
            this.gpoAdicionais.Name = "gpoAdicionais";
            this.gpoAdicionais.Size = new System.Drawing.Size(528, 58);
            this.gpoAdicionais.TabIndex = 34;
            this.gpoAdicionais.TabStop = false;
            this.gpoAdicionais.Text = "Configurações adicionais (somente para emissão de Ficha Cadastral)";
            // 
            // optDadosCompleto
            // 
            this.optDadosCompleto.AutoSize = true;
            this.optDadosCompleto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.optDadosCompleto.Location = new System.Drawing.Point(11, 34);
            this.optDadosCompleto.Name = "optDadosCompleto";
            this.optDadosCompleto.Size = new System.Drawing.Size(132, 17);
            this.optDadosCompleto.TabIndex = 28;
            this.optDadosCompleto.Text = "Exbir dados completo?";
            this.optDadosCompleto.UseVisualStyleBackColor = true;
            this.optDadosCompleto.CheckedChanged += new System.EventHandler(this.optDadosCompleto_CheckedChanged);
            // 
            // optDadosBasicos
            // 
            this.optDadosBasicos.AutoSize = true;
            this.optDadosBasicos.Checked = true;
            this.optDadosBasicos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.optDadosBasicos.Location = new System.Drawing.Point(11, 15);
            this.optDadosBasicos.Name = "optDadosBasicos";
            this.optDadosBasicos.Size = new System.Drawing.Size(124, 17);
            this.optDadosBasicos.TabIndex = 28;
            this.optDadosBasicos.TabStop = true;
            this.optDadosBasicos.Text = "Exbir dados básicos?";
            this.optDadosBasicos.UseVisualStyleBackColor = true;
            this.optDadosBasicos.CheckedChanged += new System.EventHandler(this.optDadosBasicos_CheckedChanged);
            // 
            // lblExibeComp
            // 
            this.lblExibeComp.AutoSize = true;
            this.lblExibeComp.Enabled = false;
            this.lblExibeComp.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.lblExibeComp.ForeColor = System.Drawing.Color.DarkRed;
            this.lblExibeComp.Location = new System.Drawing.Point(144, 34);
            this.lblExibeComp.Name = "lblExibeComp";
            this.lblExibeComp.Size = new System.Drawing.Size(248, 20);
            this.lblExibeComp.TabIndex = 27;
            this.lblExibeComp.Text = "(Nome, cpf, comum, ministério, instrumento, cidade, estado,\r\nendereço, número, ba" +
    "irro, telefone, email, demais dados...)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(394, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 10);
            this.label1.TabIndex = 27;
            this.label1.Text = "(01 registro na folha A4)";
            // 
            // lblMsgBasico
            // 
            this.lblMsgBasico.AutoSize = true;
            this.lblMsgBasico.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.lblMsgBasico.ForeColor = System.Drawing.Color.Gray;
            this.lblMsgBasico.Location = new System.Drawing.Point(394, 19);
            this.lblMsgBasico.Name = "lblMsgBasico";
            this.lblMsgBasico.Size = new System.Drawing.Size(105, 10);
            this.lblMsgBasico.TabIndex = 27;
            this.lblMsgBasico.Text = "(02 registros na folha A4)";
            // 
            // lblExibeDados
            // 
            this.lblExibeDados.AutoSize = true;
            this.lblExibeDados.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.lblExibeDados.ForeColor = System.Drawing.Color.DarkRed;
            this.lblExibeDados.Location = new System.Drawing.Point(144, 19);
            this.lblExibeDados.Name = "lblExibeDados";
            this.lblExibeDados.Size = new System.Drawing.Size(232, 10);
            this.lblExibeDados.TabIndex = 27;
            this.lblExibeDados.Text = "(Nome, comum, ministério, instrumento, cidade, estado)";
            // 
            // gpoSexo
            // 
            this.gpoSexo.Controls.Add(this.chkMasculino);
            this.gpoSexo.Controls.Add(this.chkFeminino);
            this.gpoSexo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSexo.Location = new System.Drawing.Point(9, 5);
            this.gpoSexo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Name = "gpoSexo";
            this.gpoSexo.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Size = new System.Drawing.Size(82, 58);
            this.gpoSexo.TabIndex = 30;
            this.gpoSexo.TabStop = false;
            this.gpoSexo.Text = "Sexo";
            // 
            // chkMasculino
            // 
            this.chkMasculino.AutoSize = true;
            this.chkMasculino.Checked = true;
            this.chkMasculino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMasculino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMasculino.Location = new System.Drawing.Point(8, 15);
            this.chkMasculino.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkMasculino.Name = "chkMasculino";
            this.chkMasculino.Size = new System.Drawing.Size(72, 17);
            this.chkMasculino.TabIndex = 0;
            this.chkMasculino.Text = "Masculino";
            this.chkMasculino.UseVisualStyleBackColor = true;
            this.chkMasculino.CheckedChanged += new System.EventHandler(this.chkMasculino_CheckedChanged);
            // 
            // chkFeminino
            // 
            this.chkFeminino.AutoSize = true;
            this.chkFeminino.Checked = true;
            this.chkFeminino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFeminino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFeminino.Location = new System.Drawing.Point(8, 34);
            this.chkFeminino.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkFeminino.Name = "chkFeminino";
            this.chkFeminino.Size = new System.Drawing.Size(68, 17);
            this.chkFeminino.TabIndex = 1;
            this.chkFeminino.Text = "Feminino";
            this.chkFeminino.UseVisualStyleBackColor = true;
            this.chkFeminino.CheckedChanged += new System.EventHandler(this.chkFeminino_CheckedChanged);
            // 
            // gpoEstadoCivil
            // 
            this.gpoEstadoCivil.Controls.Add(this.chkDivorciado);
            this.gpoEstadoCivil.Controls.Add(this.chkViuvo);
            this.gpoEstadoCivil.Controls.Add(this.chkCasado);
            this.gpoEstadoCivil.Controls.Add(this.chkSolteiro);
            this.gpoEstadoCivil.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoEstadoCivil.Location = new System.Drawing.Point(170, 5);
            this.gpoEstadoCivil.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoEstadoCivil.Name = "gpoEstadoCivil";
            this.gpoEstadoCivil.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoEstadoCivil.Size = new System.Drawing.Size(158, 58);
            this.gpoEstadoCivil.TabIndex = 32;
            this.gpoEstadoCivil.TabStop = false;
            this.gpoEstadoCivil.Text = "Estado Civil";
            // 
            // chkDivorciado
            // 
            this.chkDivorciado.AutoSize = true;
            this.chkDivorciado.Checked = true;
            this.chkDivorciado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDivorciado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDivorciado.Location = new System.Drawing.Point(74, 34);
            this.chkDivorciado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkDivorciado.Name = "chkDivorciado";
            this.chkDivorciado.Size = new System.Drawing.Size(76, 17);
            this.chkDivorciado.TabIndex = 3;
            this.chkDivorciado.Text = "Divorciado";
            this.chkDivorciado.UseVisualStyleBackColor = true;
            this.chkDivorciado.CheckedChanged += new System.EventHandler(this.chkDivorciado_CheckedChanged);
            // 
            // chkViuvo
            // 
            this.chkViuvo.AutoSize = true;
            this.chkViuvo.Checked = true;
            this.chkViuvo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkViuvo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkViuvo.Location = new System.Drawing.Point(9, 34);
            this.chkViuvo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkViuvo.Name = "chkViuvo";
            this.chkViuvo.Size = new System.Drawing.Size(52, 17);
            this.chkViuvo.TabIndex = 1;
            this.chkViuvo.Text = "Viúvo";
            this.chkViuvo.UseVisualStyleBackColor = true;
            this.chkViuvo.CheckedChanged += new System.EventHandler(this.chkViuvo_CheckedChanged);
            // 
            // chkCasado
            // 
            this.chkCasado.AutoSize = true;
            this.chkCasado.Checked = true;
            this.chkCasado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCasado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCasado.Location = new System.Drawing.Point(74, 15);
            this.chkCasado.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkCasado.Name = "chkCasado";
            this.chkCasado.Size = new System.Drawing.Size(62, 17);
            this.chkCasado.TabIndex = 2;
            this.chkCasado.Text = "Casado";
            this.chkCasado.UseVisualStyleBackColor = true;
            this.chkCasado.CheckedChanged += new System.EventHandler(this.chkCasado_CheckedChanged);
            // 
            // chkSolteiro
            // 
            this.chkSolteiro.AutoSize = true;
            this.chkSolteiro.Checked = true;
            this.chkSolteiro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSolteiro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSolteiro.Location = new System.Drawing.Point(9, 15);
            this.chkSolteiro.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkSolteiro.Name = "chkSolteiro";
            this.chkSolteiro.Size = new System.Drawing.Size(62, 17);
            this.chkSolteiro.TabIndex = 0;
            this.chkSolteiro.Text = "Solteiro";
            this.chkSolteiro.UseVisualStyleBackColor = true;
            this.chkSolteiro.CheckedChanged += new System.EventHandler(this.chkSolteiro_CheckedChanged);
            // 
            // gpoSelecione
            // 
            this.gpoSelecione.Controls.Add(this.btnDesRegiao);
            this.gpoSelecione.Controls.Add(this.btnSelRegiao);
            this.gpoSelecione.Controls.Add(this.gridRegiao);
            this.gpoSelecione.Controls.Add(this.btnDesPessoa);
            this.gpoSelecione.Controls.Add(this.btnSelPessoa);
            this.gpoSelecione.Controls.Add(this.btnDesComum);
            this.gpoSelecione.Controls.Add(this.btnSelComum);
            this.gpoSelecione.Controls.Add(this.cboRegional);
            this.gpoSelecione.Controls.Add(this.lblRegional);
            this.gpoSelecione.Controls.Add(this.gridComum);
            this.gpoSelecione.Controls.Add(this.gridPessoa);
            this.gpoSelecione.Controls.Add(this.cboCargo);
            this.gpoSelecione.Controls.Add(this.lblCargo);
            this.gpoSelecione.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSelecione.Location = new System.Drawing.Point(11, 63);
            this.gpoSelecione.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSelecione.Name = "gpoSelecione";
            this.gpoSelecione.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSelecione.Size = new System.Drawing.Size(850, 314);
            this.gpoSelecione.TabIndex = 33;
            this.gpoSelecione.TabStop = false;
            this.gpoSelecione.Text = "Selecione";
            // 
            // gridRegiao
            // 
            this.gridRegiao.AllowUserToAddRows = false;
            this.gridRegiao.AllowUserToDeleteRows = false;
            this.gridRegiao.AllowUserToResizeRows = false;
            this.gridRegiao.BackgroundColor = System.Drawing.Color.White;
            this.gridRegiao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegiao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRegiao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRegiao.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridRegiao.DisabledCell = null;
            this.gridRegiao.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRegiao.EnableHeadersVisualStyles = false;
            this.gridRegiao.Location = new System.Drawing.Point(6, 43);
            this.gridRegiao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridRegiao.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridRegiao.MultiSelect = false;
            this.gridRegiao.Name = "gridRegiao";
            this.gridRegiao.ReadOnly = true;
            this.gridRegiao.RowHeadersVisible = false;
            this.gridRegiao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRegiao.RowTemplate.Height = 18;
            this.gridRegiao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegiao.Size = new System.Drawing.Size(207, 224);
            this.gridRegiao.TabIndex = 29;
            this.gridRegiao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellClick);
            // 
            // cboRegional
            // 
            this.cboRegional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegional.FormattingEnabled = true;
            this.cboRegional.Location = new System.Drawing.Point(60, 14);
            this.cboRegional.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(153, 21);
            this.cboRegional.TabIndex = 28;
            this.cboRegional.SelectionChangeCommitted += new System.EventHandler(this.cboRegional_SelectionChangeCommitted);
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRegional.Location = new System.Drawing.Point(4, 17);
            this.lblRegional.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegional.Name = "lblRegional";
            this.lblRegional.Size = new System.Drawing.Size(52, 13);
            this.lblRegional.TabIndex = 35;
            this.lblRegional.Text = "Regional:";
            // 
            // gridComum
            // 
            this.gridComum.AllowUserToAddRows = false;
            this.gridComum.AllowUserToDeleteRows = false;
            this.gridComum.AllowUserToResizeRows = false;
            this.gridComum.BackgroundColor = System.Drawing.Color.White;
            this.gridComum.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridComum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridComum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridComum.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridComum.DisabledCell = null;
            this.gridComum.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridComum.EnableHeadersVisualStyles = false;
            this.gridComum.Location = new System.Drawing.Point(221, 14);
            this.gridComum.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridComum.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridComum.MultiSelect = false;
            this.gridComum.Name = "gridComum";
            this.gridComum.ReadOnly = true;
            this.gridComum.RowHeadersVisible = false;
            this.gridComum.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridComum.RowTemplate.Height = 18;
            this.gridComum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridComum.Size = new System.Drawing.Size(236, 253);
            this.gridComum.TabIndex = 32;
            this.gridComum.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComum_CellClick);
            // 
            // gridPessoa
            // 
            this.gridPessoa.AllowUserToAddRows = false;
            this.gridPessoa.AllowUserToDeleteRows = false;
            this.gridPessoa.AllowUserToResizeRows = false;
            this.gridPessoa.BackgroundColor = System.Drawing.Color.White;
            this.gridPessoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPessoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridPessoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPessoa.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridPessoa.DisabledCell = null;
            this.gridPessoa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPessoa.EnableHeadersVisualStyles = false;
            this.gridPessoa.Location = new System.Drawing.Point(466, 41);
            this.gridPessoa.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridPessoa.MultiSelect = false;
            this.gridPessoa.Name = "gridPessoa";
            this.gridPessoa.ReadOnly = true;
            this.gridPessoa.RowHeadersVisible = false;
            this.gridPessoa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPessoa.RowTemplate.Height = 18;
            this.gridPessoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPessoa.Size = new System.Drawing.Size(377, 226);
            this.gridPessoa.TabIndex = 27;
            this.gridPessoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPessoa_CellClick);
            // 
            // cboCargo
            // 
            this.cboCargo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCargo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Location = new System.Drawing.Point(528, 14);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(186, 21);
            this.cboCargo.TabIndex = 25;
            this.cboCargo.SelectionChangeCommitted += new System.EventHandler(this.cboCargo_SelectionChangeCommitted);
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCargo.Location = new System.Drawing.Point(470, 18);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(56, 13);
            this.lblCargo.TabIndex = 26;
            this.lblCargo.Text = "Ministério:";
            // 
            // gpoStatus
            // 
            this.gpoStatus.Controls.Add(this.chkInativo);
            this.gpoStatus.Controls.Add(this.chkAtivo);
            this.gpoStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoStatus.Location = new System.Drawing.Point(96, 5);
            this.gpoStatus.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoStatus.Name = "gpoStatus";
            this.gpoStatus.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoStatus.Size = new System.Drawing.Size(70, 58);
            this.gpoStatus.TabIndex = 31;
            this.gpoStatus.TabStop = false;
            this.gpoStatus.Text = "Status";
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkInativo.Location = new System.Drawing.Point(8, 34);
            this.chkInativo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkInativo.Name = "chkInativo";
            this.chkInativo.Size = new System.Drawing.Size(60, 17);
            this.chkInativo.TabIndex = 1;
            this.chkInativo.Text = "Inativo";
            this.chkInativo.UseVisualStyleBackColor = true;
            this.chkInativo.CheckedChanged += new System.EventHandler(this.chkInativo_CheckedChanged);
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtivo.Location = new System.Drawing.Point(8, 15);
            this.chkAtivo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(51, 17);
            this.chkAtivo.TabIndex = 0;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            this.chkAtivo.CheckedChanged += new System.EventHandler(this.chkAtivo_CheckedChanged);
            // 
            // lblSelecionados
            // 
            this.lblSelecionados.AutoSize = true;
            this.lblSelecionados.Location = new System.Drawing.Point(592, 449);
            this.lblSelecionados.Name = "lblSelecionados";
            this.lblSelecionados.Size = new System.Drawing.Size(120, 13);
            this.lblSelecionados.TabIndex = 36;
            this.lblSelecionados.Text = "Registros selecionados:";
            // 
            // lblQtdeRegistro
            // 
            this.lblQtdeRegistro.AutoSize = true;
            this.lblQtdeRegistro.Location = new System.Drawing.Point(438, 449);
            this.lblQtdeRegistro.Name = "lblQtdeRegistro";
            this.lblQtdeRegistro.Size = new System.Drawing.Size(95, 13);
            this.lblQtdeRegistro.TabIndex = 36;
            this.lblQtdeRegistro.Text = "Qtde de registros:";
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(787, 437);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 35);
            this.btnFechar.TabIndex = 36;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtSelecionados
            // 
            this.txtSelecionados.BackColor = System.Drawing.Color.LightGray;
            this.txtSelecionados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelecionados.Enabled = false;
            this.txtSelecionados.Location = new System.Drawing.Point(711, 445);
            this.txtSelecionados.Name = "txtSelecionados";
            this.txtSelecionados.Size = new System.Drawing.Size(50, 21);
            this.txtSelecionados.TabIndex = 37;
            this.txtSelecionados.Text = "00000";
            this.txtSelecionados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSelecionados.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtQtdeRegistro
            // 
            this.txtQtdeRegistro.BackColor = System.Drawing.Color.LightGray;
            this.txtQtdeRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdeRegistro.Enabled = false;
            this.txtQtdeRegistro.Location = new System.Drawing.Point(532, 445);
            this.txtQtdeRegistro.Name = "txtQtdeRegistro";
            this.txtQtdeRegistro.Size = new System.Drawing.Size(50, 21);
            this.txtQtdeRegistro.TabIndex = 37;
            this.txtQtdeRegistro.Text = "00000";
            this.txtQtdeRegistro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeRegistro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // btnCracha
            // 
            this.btnCracha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCracha.Enabled = false;
            this.btnCracha.Image = global::ccbrepess.Properties.Resources.cracha;
            this.btnCracha.Location = new System.Drawing.Point(754, 382);
            this.btnCracha.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCracha.Name = "btnCracha";
            this.btnCracha.Size = new System.Drawing.Size(107, 35);
            this.btnCracha.TabIndex = 35;
            this.btnCracha.Text = " Emitir &Cartão Identificação";
            this.btnCracha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipFicha.SetToolTip(this.btnCracha, "Imprimir crachá de identificação");
            this.btnCracha.UseVisualStyleBackColor = true;
            // 
            // btnFicha
            // 
            this.btnFicha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFicha.Image = global::ccbrepess.Properties.Resources.Impressora;
            this.btnFicha.Location = new System.Drawing.Point(534, 382);
            this.btnFicha.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFicha.Name = "btnFicha";
            this.btnFicha.Size = new System.Drawing.Size(106, 35);
            this.btnFicha.TabIndex = 35;
            this.btnFicha.Text = "  &Ficha Cadastral";
            this.btnFicha.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFicha.UseVisualStyleBackColor = true;
            this.btnFicha.Click += new System.EventHandler(this.btnFicha_Click);
            // 
            // btnCartao
            // 
            this.btnCartao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCartao.Image = global::ccbrepess.Properties.Resources.solicitacao;
            this.btnCartao.Location = new System.Drawing.Point(644, 382);
            this.btnCartao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCartao.Name = "btnCartao";
            this.btnCartao.Size = new System.Drawing.Size(106, 35);
            this.btnCartao.TabIndex = 35;
            this.btnCartao.Text = "  &Solicitação Cartão";
            this.btnCartao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipFicha.SetToolTip(this.btnCartao, "Imprimir ficha cadastral de acordo com as opções selecionadas");
            this.btnCartao.UseVisualStyleBackColor = true;
            this.btnCartao.Click += new System.EventHandler(this.btnCartao_Click);
            // 
            // btnDesRegiao
            // 
            this.btnDesRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesRegiao.Image = global::ccbrepess.Properties.Resources.DesTodos;
            this.btnDesRegiao.Location = new System.Drawing.Point(133, 271);
            this.btnDesRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesRegiao.Name = "btnDesRegiao";
            this.btnDesRegiao.Size = new System.Drawing.Size(80, 27);
            this.btnDesRegiao.TabIndex = 31;
            this.btnDesRegiao.Text = "Nenhum";
            this.btnDesRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesRegiao.UseVisualStyleBackColor = true;
            this.btnDesRegiao.Click += new System.EventHandler(this.btnDesRegiao_Click);
            // 
            // btnSelRegiao
            // 
            this.btnSelRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelRegiao.Image = global::ccbrepess.Properties.Resources.SelTodos;
            this.btnSelRegiao.Location = new System.Drawing.Point(49, 271);
            this.btnSelRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelRegiao.Name = "btnSelRegiao";
            this.btnSelRegiao.Size = new System.Drawing.Size(80, 27);
            this.btnSelRegiao.TabIndex = 30;
            this.btnSelRegiao.Text = "Todos";
            this.btnSelRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelRegiao.UseVisualStyleBackColor = true;
            this.btnSelRegiao.Click += new System.EventHandler(this.btnSelRegiao_Click);
            // 
            // btnDesPessoa
            // 
            this.btnDesPessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesPessoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesPessoa.Image = global::ccbrepess.Properties.Resources.DesTodos;
            this.btnDesPessoa.Location = new System.Drawing.Point(764, 271);
            this.btnDesPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesPessoa.Name = "btnDesPessoa";
            this.btnDesPessoa.Size = new System.Drawing.Size(80, 27);
            this.btnDesPessoa.TabIndex = 34;
            this.btnDesPessoa.Text = "Nenhum";
            this.btnDesPessoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesPessoa.UseVisualStyleBackColor = true;
            this.btnDesPessoa.Click += new System.EventHandler(this.btnDesPessoa_Click);
            // 
            // btnSelPessoa
            // 
            this.btnSelPessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelPessoa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelPessoa.Image = global::ccbrepess.Properties.Resources.SelTodos;
            this.btnSelPessoa.Location = new System.Drawing.Point(680, 271);
            this.btnSelPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelPessoa.Name = "btnSelPessoa";
            this.btnSelPessoa.Size = new System.Drawing.Size(80, 27);
            this.btnSelPessoa.TabIndex = 33;
            this.btnSelPessoa.Text = "Todos";
            this.btnSelPessoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelPessoa.UseVisualStyleBackColor = true;
            this.btnSelPessoa.Click += new System.EventHandler(this.btnSelPessoa_Click);
            // 
            // btnDesComum
            // 
            this.btnDesComum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesComum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesComum.Image = global::ccbrepess.Properties.Resources.DesTodos;
            this.btnDesComum.Location = new System.Drawing.Point(378, 271);
            this.btnDesComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesComum.Name = "btnDesComum";
            this.btnDesComum.Size = new System.Drawing.Size(80, 27);
            this.btnDesComum.TabIndex = 34;
            this.btnDesComum.Text = "Nenhum";
            this.btnDesComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesComum.UseVisualStyleBackColor = true;
            this.btnDesComum.Click += new System.EventHandler(this.btnDesComum_Click);
            // 
            // btnSelComum
            // 
            this.btnSelComum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelComum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelComum.Image = global::ccbrepess.Properties.Resources.SelTodos;
            this.btnSelComum.Location = new System.Drawing.Point(294, 271);
            this.btnSelComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelComum.Name = "btnSelComum";
            this.btnSelComum.Size = new System.Drawing.Size(80, 27);
            this.btnSelComum.TabIndex = 33;
            this.btnSelComum.Text = "Todos";
            this.btnSelComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelComum.UseVisualStyleBackColor = true;
            this.btnSelComum.Click += new System.EventHandler(this.btnSelComum_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(212, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 10);
            this.label2.TabIndex = 28;
            this.label2.Text = "- Para utilização de papel tamanho A5";
            // 
            // frmFichaCadastral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(887, 477);
            this.Controls.Add(this.txtSelecionados);
            this.Controls.Add(this.txtQtdeRegistro);
            this.Controls.Add(this.lblSelecionados);
            this.Controls.Add(this.pnlFicha);
            this.Controls.Add(this.lblQtdeRegistro);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblDivorciado);
            this.Controls.Add(this.lblViuvo);
            this.Controls.Add(this.lblCasado);
            this.Controls.Add(this.lblSolteiro);
            this.Controls.Add(this.lblEstadoCivil);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSexo);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "frmFichaCadastral";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha cadastral";
            this.Load += new System.EventHandler(this.frmFichaCadastral_Load);
            this.pnlFicha.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpoAdicionais.ResumeLayout(false);
            this.gpoAdicionais.PerformLayout();
            this.gpoSexo.ResumeLayout(false);
            this.gpoSexo.PerformLayout();
            this.gpoEstadoCivil.ResumeLayout(false);
            this.gpoEstadoCivil.PerformLayout();
            this.gpoSelecione.ResumeLayout(false);
            this.gpoSelecione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoa)).EndInit();
            this.gpoStatus.ResumeLayout(false);
            this.gpoStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblSolteiro;
        private System.Windows.Forms.Label lblCasado;
        private System.Windows.Forms.Label lblViuvo;
        private System.Windows.Forms.Label lblDivorciado;
        private System.Windows.Forms.Panel pnlFicha;
        private System.Windows.Forms.GroupBox gpoAdicionais;
        private System.Windows.Forms.RadioButton optDadosCompleto;
        private System.Windows.Forms.RadioButton optDadosBasicos;
        private System.Windows.Forms.Label lblExibeComp;
        private System.Windows.Forms.Label lblExibeDados;
        private System.Windows.Forms.GroupBox gpoSexo;
        private System.Windows.Forms.CheckBox chkMasculino;
        private System.Windows.Forms.CheckBox chkFeminino;
        private System.Windows.Forms.GroupBox gpoEstadoCivil;
        private System.Windows.Forms.CheckBox chkDivorciado;
        private System.Windows.Forms.CheckBox chkViuvo;
        private System.Windows.Forms.CheckBox chkCasado;
        private System.Windows.Forms.CheckBox chkSolteiro;
        private System.Windows.Forms.GroupBox gpoSelecione;
        private System.Windows.Forms.GroupBox gpoStatus;
        private System.Windows.Forms.CheckBox chkInativo;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Button btnCartao;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.DataGridViewPersonal gridPessoa;
        private BLL.validacoes.Controles.ComboBoxPersonal cboCargo;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Button btnDesRegiao;
        private System.Windows.Forms.Button btnSelRegiao;
        private BLL.validacoes.Controles.DataGridViewPersonal gridRegiao;
        private System.Windows.Forms.Button btnDesPessoa;
        private System.Windows.Forms.Button btnSelPessoa;
        private System.Windows.Forms.Button btnDesComum;
        private System.Windows.Forms.Button btnSelComum;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegional;
        private System.Windows.Forms.Label lblRegional;
        private BLL.validacoes.Controles.DataGridViewPersonal gridComum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkPulaPagina;
        private BLL.validacoes.Controles.TextBoxPersonal txtSelecionados;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtdeRegistro;
        private System.Windows.Forms.Label lblSelecionados;
        private System.Windows.Forms.Label lblQtdeRegistro;
        private System.Windows.Forms.Button btnCracha;
        private System.Windows.Forms.ToolTip tipFicha;
        private System.Windows.Forms.Label lblMsgBasico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFicha;
        private System.Windows.Forms.Label label2;
    }
}