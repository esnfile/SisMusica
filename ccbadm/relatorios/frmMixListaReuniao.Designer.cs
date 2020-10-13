namespace ccbadm.relatorios
{
    partial class frmMixListaReuniao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMixListaReuniao));
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlMix = new System.Windows.Forms.Panel();
            this.txtLocal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbLocal = new System.Windows.Forms.Label();
            this.txtTipo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbTipo = new System.Windows.Forms.Label();
            this.txtHoraReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblReuniao = new System.Windows.Forms.Label();
            this.lblDataReuniao = new System.Windows.Forms.Label();
            this.pnlGrupo = new System.Windows.Forms.Panel();
            this.chkAgruComum = new System.Windows.Forms.CheckBox();
            this.chkAgruCargo = new System.Windows.Forms.CheckBox();
            this.chkAgruFamilia = new System.Windows.Forms.CheckBox();
            this.gpoAgrupar = new System.Windows.Forms.GroupBox();
            this.optAgruInstr = new System.Windows.Forms.RadioButton();
            this.optAgruCargo = new System.Windows.Forms.RadioButton();
            this.optAgruRegiao = new System.Windows.Forms.RadioButton();
            this.gpoAdicionais = new System.Windows.Forms.GroupBox();
            this.chkExibeAusente = new System.Windows.Forms.CheckBox();
            this.chkPulaPagina = new System.Windows.Forms.CheckBox();
            this.chkExibeResumo = new System.Windows.Forms.CheckBox();
            this.gpoRelatorio = new System.Windows.Forms.GroupBox();
            this.optAnalitico = new System.Windows.Forms.RadioButton();
            this.optSintetico = new System.Windows.Forms.RadioButton();
            this.gpoSexo = new System.Windows.Forms.GroupBox();
            this.chkFeminino = new System.Windows.Forms.CheckBox();
            this.chkMasculino = new System.Windows.Forms.CheckBox();
            this.gpoSelecione = new System.Windows.Forms.GroupBox();
            this.btnDesRegiao = new System.Windows.Forms.Button();
            this.btnSelRegiao = new System.Windows.Forms.Button();
            this.gridRegiao = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.btnDesCargo = new System.Windows.Forms.Button();
            this.btnSelCargo = new System.Windows.Forms.Button();
            this.cboRegional = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegional = new System.Windows.Forms.Label();
            this.gridCargo = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.lblSexo = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblTipo = new System.Windows.Forms.Label();
            this.pnlMix.SuspendLayout();
            this.pnlGrupo.SuspendLayout();
            this.gpoAgrupar.SuspendLayout();
            this.gpoAdicionais.SuspendLayout();
            this.gpoRelatorio.SuspendLayout();
            this.gpoSexo.SuspendLayout();
            this.gpoSelecione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(446, 435);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 35);
            this.btnFechar.TabIndex = 33;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pnlMix
            // 
            this.pnlMix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlMix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMix.Controls.Add(this.lblTipo);
            this.pnlMix.Controls.Add(this.txtLocal);
            this.pnlMix.Controls.Add(this.lbLocal);
            this.pnlMix.Controls.Add(this.txtTipo);
            this.pnlMix.Controls.Add(this.lbTipo);
            this.pnlMix.Controls.Add(this.txtHoraReuniao);
            this.pnlMix.Controls.Add(this.txtDataReuniao);
            this.pnlMix.Controls.Add(this.txtCodReuniao);
            this.pnlMix.Controls.Add(this.lblReuniao);
            this.pnlMix.Controls.Add(this.lblDataReuniao);
            this.pnlMix.Controls.Add(this.pnlGrupo);
            this.pnlMix.Controls.Add(this.gpoAgrupar);
            this.pnlMix.Controls.Add(this.gpoAdicionais);
            this.pnlMix.Controls.Add(this.gpoRelatorio);
            this.pnlMix.Controls.Add(this.gpoSexo);
            this.pnlMix.Controls.Add(this.gpoSelecione);
            this.pnlMix.Location = new System.Drawing.Point(7, 7);
            this.pnlMix.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pnlMix.Name = "pnlMix";
            this.pnlMix.Size = new System.Drawing.Size(533, 425);
            this.pnlMix.TabIndex = 0;
            // 
            // txtLocal
            // 
            this.txtLocal.BackColor = System.Drawing.Color.LightGray;
            this.txtLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocal.Enabled = false;
            this.txtLocal.ForeColor = System.Drawing.Color.Black;
            this.txtLocal.Location = new System.Drawing.Point(70, 29);
            this.txtLocal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(450, 21);
            this.txtLocal.TabIndex = 5;
            this.txtLocal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lbLocal
            // 
            this.lbLocal.AutoSize = true;
            this.lbLocal.Enabled = false;
            this.lbLocal.ForeColor = System.Drawing.Color.Black;
            this.lbLocal.Location = new System.Drawing.Point(7, 33);
            this.lbLocal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbLocal.Name = "lbLocal";
            this.lbLocal.Size = new System.Drawing.Size(66, 13);
            this.lbLocal.TabIndex = 109;
            this.lbLocal.Text = "Local Realiz:";
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.LightGray;
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo.Enabled = false;
            this.txtTipo.ForeColor = System.Drawing.Color.Black;
            this.txtTipo.Location = new System.Drawing.Point(332, 5);
            this.txtTipo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(188, 21);
            this.txtTipo.TabIndex = 4;
            this.txtTipo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.Enabled = false;
            this.lbTipo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lbTipo.ForeColor = System.Drawing.Color.Black;
            this.lbTipo.Location = new System.Drawing.Point(302, 9);
            this.lbTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(31, 13);
            this.lbTipo.TabIndex = 134;
            this.lbTipo.Text = "Tipo:";
            // 
            // txtHoraReuniao
            // 
            this.txtHoraReuniao.BackColor = System.Drawing.Color.LightGray;
            this.txtHoraReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraReuniao.Enabled = false;
            this.txtHoraReuniao.ForeColor = System.Drawing.Color.Black;
            this.txtHoraReuniao.Location = new System.Drawing.Point(261, 5);
            this.txtHoraReuniao.MaxLength = 5;
            this.txtHoraReuniao.Name = "txtHoraReuniao";
            this.txtHoraReuniao.Size = new System.Drawing.Size(35, 21);
            this.txtHoraReuniao.TabIndex = 3;
            this.txtHoraReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtDataReuniao
            // 
            this.txtDataReuniao.BackColor = System.Drawing.Color.LightGray;
            this.txtDataReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataReuniao.Enabled = false;
            this.txtDataReuniao.ForeColor = System.Drawing.Color.Black;
            this.txtDataReuniao.Location = new System.Drawing.Point(193, 5);
            this.txtDataReuniao.MaxLength = 10;
            this.txtDataReuniao.Name = "txtDataReuniao";
            this.txtDataReuniao.Size = new System.Drawing.Size(65, 21);
            this.txtDataReuniao.TabIndex = 2;
            this.txtDataReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // txtCodReuniao
            // 
            this.txtCodReuniao.BackColor = System.Drawing.Color.LightGray;
            this.txtCodReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodReuniao.Enabled = false;
            this.txtCodReuniao.ForeColor = System.Drawing.Color.Black;
            this.txtCodReuniao.Location = new System.Drawing.Point(70, 5);
            this.txtCodReuniao.Name = "txtCodReuniao";
            this.txtCodReuniao.Size = new System.Drawing.Size(40, 21);
            this.txtCodReuniao.TabIndex = 1;
            this.txtCodReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblReuniao
            // 
            this.lblReuniao.AutoSize = true;
            this.lblReuniao.Enabled = false;
            this.lblReuniao.ForeColor = System.Drawing.Color.Black;
            this.lblReuniao.Location = new System.Drawing.Point(7, 9);
            this.lblReuniao.Name = "lblReuniao";
            this.lblReuniao.Size = new System.Drawing.Size(64, 13);
            this.lblReuniao.TabIndex = 132;
            this.lblReuniao.Text = "Reunião nº:";
            // 
            // lblDataReuniao
            // 
            this.lblDataReuniao.AutoSize = true;
            this.lblDataReuniao.Enabled = false;
            this.lblDataReuniao.ForeColor = System.Drawing.Color.Black;
            this.lblDataReuniao.Location = new System.Drawing.Point(118, 9);
            this.lblDataReuniao.Name = "lblDataReuniao";
            this.lblDataReuniao.Size = new System.Drawing.Size(76, 13);
            this.lblDataReuniao.TabIndex = 129;
            this.lblDataReuniao.Text = "Data Reunião:";
            // 
            // pnlGrupo
            // 
            this.pnlGrupo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrupo.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrupo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlGrupo.Controls.Add(this.chkAgruComum);
            this.pnlGrupo.Controls.Add(this.chkAgruCargo);
            this.pnlGrupo.Controls.Add(this.chkAgruFamilia);
            this.pnlGrupo.ForeColor = System.Drawing.Color.Black;
            this.pnlGrupo.Location = new System.Drawing.Point(-3, 106);
            this.pnlGrupo.Name = "pnlGrupo";
            this.pnlGrupo.Size = new System.Drawing.Size(536, 25);
            this.pnlGrupo.TabIndex = 17;
            // 
            // chkAgruComum
            // 
            this.chkAgruComum.AutoSize = true;
            this.chkAgruComum.ForeColor = System.Drawing.Color.Black;
            this.chkAgruComum.Location = new System.Drawing.Point(14, 3);
            this.chkAgruComum.Name = "chkAgruComum";
            this.chkAgruComum.Size = new System.Drawing.Size(127, 17);
            this.chkAgruComum.TabIndex = 18;
            this.chkAgruComum.Text = "Agrupar por Comum?";
            this.chkAgruComum.UseVisualStyleBackColor = false;
            // 
            // chkAgruCargo
            // 
            this.chkAgruCargo.AutoSize = true;
            this.chkAgruCargo.ForeColor = System.Drawing.Color.Black;
            this.chkAgruCargo.Location = new System.Drawing.Point(383, 3);
            this.chkAgruCargo.Name = "chkAgruCargo";
            this.chkAgruCargo.Size = new System.Drawing.Size(137, 17);
            this.chkAgruCargo.TabIndex = 20;
            this.chkAgruCargo.Text = "Agrupar por ministério?";
            this.chkAgruCargo.UseVisualStyleBackColor = false;
            // 
            // chkAgruFamilia
            // 
            this.chkAgruFamilia.AutoSize = true;
            this.chkAgruFamilia.ForeColor = System.Drawing.Color.Black;
            this.chkAgruFamilia.Location = new System.Drawing.Point(159, 3);
            this.chkAgruFamilia.Name = "chkAgruFamilia";
            this.chkAgruFamilia.Size = new System.Drawing.Size(202, 17);
            this.chkAgruFamilia.TabIndex = 19;
            this.chkAgruFamilia.Text = "Agrupar por família de instrumentos?";
            this.chkAgruFamilia.UseVisualStyleBackColor = false;
            // 
            // gpoAgrupar
            // 
            this.gpoAgrupar.Controls.Add(this.optAgruInstr);
            this.gpoAgrupar.Controls.Add(this.optAgruCargo);
            this.gpoAgrupar.Controls.Add(this.optAgruRegiao);
            this.gpoAgrupar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAgrupar.Location = new System.Drawing.Point(116, 52);
            this.gpoAgrupar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoAgrupar.Name = "gpoAgrupar";
            this.gpoAgrupar.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoAgrupar.Size = new System.Drawing.Size(207, 50);
            this.gpoAgrupar.TabIndex = 9;
            this.gpoAgrupar.TabStop = false;
            this.gpoAgrupar.Text = "Agrupar por";
            // 
            // optAgruInstr
            // 
            this.optAgruInstr.AutoSize = true;
            this.optAgruInstr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruInstr.Location = new System.Drawing.Point(15, 29);
            this.optAgruInstr.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruInstr.Name = "optAgruInstr";
            this.optAgruInstr.Size = new System.Drawing.Size(84, 17);
            this.optAgruInstr.TabIndex = 13;
            this.optAgruInstr.Text = "Instrumento";
            this.optAgruInstr.UseVisualStyleBackColor = true;
            this.optAgruInstr.CheckedChanged += new System.EventHandler(this.optAgruInstr_CheckedChanged);
            // 
            // optAgruCargo
            // 
            this.optAgruCargo.AutoSize = true;
            this.optAgruCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruCargo.Location = new System.Drawing.Point(109, 14);
            this.optAgruCargo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruCargo.Name = "optAgruCargo";
            this.optAgruCargo.Size = new System.Drawing.Size(70, 17);
            this.optAgruCargo.TabIndex = 12;
            this.optAgruCargo.Text = "Ministério";
            this.optAgruCargo.UseVisualStyleBackColor = true;
            this.optAgruCargo.CheckedChanged += new System.EventHandler(this.optAgruCargo_CheckedChanged);
            // 
            // optAgruRegiao
            // 
            this.optAgruRegiao.AutoSize = true;
            this.optAgruRegiao.Checked = true;
            this.optAgruRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruRegiao.Location = new System.Drawing.Point(15, 14);
            this.optAgruRegiao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruRegiao.Name = "optAgruRegiao";
            this.optAgruRegiao.Size = new System.Drawing.Size(84, 17);
            this.optAgruRegiao.TabIndex = 10;
            this.optAgruRegiao.TabStop = true;
            this.optAgruRegiao.Text = "Microrregião";
            this.optAgruRegiao.UseVisualStyleBackColor = true;
            this.optAgruRegiao.CheckedChanged += new System.EventHandler(this.optAgruRegiao_CheckedChanged);
            // 
            // gpoAdicionais
            // 
            this.gpoAdicionais.Controls.Add(this.chkExibeAusente);
            this.gpoAdicionais.Controls.Add(this.chkPulaPagina);
            this.gpoAdicionais.Controls.Add(this.chkExibeResumo);
            this.gpoAdicionais.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAdicionais.Location = new System.Drawing.Point(10, 376);
            this.gpoAdicionais.Name = "gpoAdicionais";
            this.gpoAdicionais.Size = new System.Drawing.Size(510, 40);
            this.gpoAdicionais.TabIndex = 29;
            this.gpoAdicionais.TabStop = false;
            this.gpoAdicionais.Text = "Configurações adicionais";
            // 
            // chkExibeAusente
            // 
            this.chkExibeAusente.AutoSize = true;
            this.chkExibeAusente.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkExibeAusente.Location = new System.Drawing.Point(174, 16);
            this.chkExibeAusente.Name = "chkExibeAusente";
            this.chkExibeAusente.Size = new System.Drawing.Size(105, 17);
            this.chkExibeAusente.TabIndex = 31;
            this.chkExibeAusente.Text = "Exibe Ausentes?";
            this.chkExibeAusente.UseVisualStyleBackColor = true;
            this.chkExibeAusente.CheckedChanged += new System.EventHandler(this.chkExibeAusente_CheckedChanged);
            // 
            // chkPulaPagina
            // 
            this.chkPulaPagina.AutoSize = true;
            this.chkPulaPagina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPulaPagina.Location = new System.Drawing.Point(300, 16);
            this.chkPulaPagina.Name = "chkPulaPagina";
            this.chkPulaPagina.Size = new System.Drawing.Size(166, 17);
            this.chkPulaPagina.TabIndex = 33;
            this.chkPulaPagina.Text = "Inicia grupo em nova página?";
            this.chkPulaPagina.UseVisualStyleBackColor = true;
            // 
            // chkExibeResumo
            // 
            this.chkExibeResumo.AutoSize = true;
            this.chkExibeResumo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkExibeResumo.Location = new System.Drawing.Point(16, 16);
            this.chkExibeResumo.Name = "chkExibeResumo";
            this.chkExibeResumo.Size = new System.Drawing.Size(140, 17);
            this.chkExibeResumo.TabIndex = 30;
            this.chkExibeResumo.Text = "Exibe resumo e gráfico?";
            this.chkExibeResumo.UseVisualStyleBackColor = true;
            // 
            // gpoRelatorio
            // 
            this.gpoRelatorio.Controls.Add(this.optAnalitico);
            this.gpoRelatorio.Controls.Add(this.optSintetico);
            this.gpoRelatorio.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoRelatorio.Location = new System.Drawing.Point(11, 52);
            this.gpoRelatorio.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoRelatorio.Name = "gpoRelatorio";
            this.gpoRelatorio.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoRelatorio.Size = new System.Drawing.Size(95, 50);
            this.gpoRelatorio.TabIndex = 6;
            this.gpoRelatorio.TabStop = false;
            this.gpoRelatorio.Text = "Tipo Relatório";
            // 
            // optAnalitico
            // 
            this.optAnalitico.AutoSize = true;
            this.optAnalitico.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAnalitico.Location = new System.Drawing.Point(16, 29);
            this.optAnalitico.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAnalitico.Name = "optAnalitico";
            this.optAnalitico.Size = new System.Drawing.Size(65, 17);
            this.optAnalitico.TabIndex = 8;
            this.optAnalitico.Text = "Analítico";
            this.optAnalitico.UseVisualStyleBackColor = true;
            this.optAnalitico.CheckedChanged += new System.EventHandler(this.optAnalitico_CheckedChanged);
            // 
            // optSintetico
            // 
            this.optSintetico.AutoSize = true;
            this.optSintetico.Checked = true;
            this.optSintetico.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optSintetico.Location = new System.Drawing.Point(16, 14);
            this.optSintetico.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optSintetico.Name = "optSintetico";
            this.optSintetico.Size = new System.Drawing.Size(66, 17);
            this.optSintetico.TabIndex = 7;
            this.optSintetico.TabStop = true;
            this.optSintetico.Text = "Sintético";
            this.optSintetico.UseVisualStyleBackColor = true;
            this.optSintetico.CheckedChanged += new System.EventHandler(this.optSintetico_CheckedChanged);
            // 
            // gpoSexo
            // 
            this.gpoSexo.Controls.Add(this.chkFeminino);
            this.gpoSexo.Controls.Add(this.chkMasculino);
            this.gpoSexo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSexo.Location = new System.Drawing.Point(332, 52);
            this.gpoSexo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Name = "gpoSexo";
            this.gpoSexo.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Size = new System.Drawing.Size(100, 50);
            this.gpoSexo.TabIndex = 14;
            this.gpoSexo.TabStop = false;
            this.gpoSexo.Text = "Sexo";
            // 
            // chkFeminino
            // 
            this.chkFeminino.AutoSize = true;
            this.chkFeminino.Checked = true;
            this.chkFeminino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFeminino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFeminino.Location = new System.Drawing.Point(15, 29);
            this.chkFeminino.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkFeminino.Name = "chkFeminino";
            this.chkFeminino.Size = new System.Drawing.Size(68, 17);
            this.chkFeminino.TabIndex = 16;
            this.chkFeminino.Text = "Feminino";
            this.chkFeminino.UseVisualStyleBackColor = true;
            this.chkFeminino.CheckedChanged += new System.EventHandler(this.chkFeminino_CheckedChanged);
            // 
            // chkMasculino
            // 
            this.chkMasculino.AutoSize = true;
            this.chkMasculino.Checked = true;
            this.chkMasculino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMasculino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMasculino.Location = new System.Drawing.Point(15, 14);
            this.chkMasculino.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkMasculino.Name = "chkMasculino";
            this.chkMasculino.Size = new System.Drawing.Size(72, 17);
            this.chkMasculino.TabIndex = 15;
            this.chkMasculino.Text = "Masculino";
            this.chkMasculino.UseVisualStyleBackColor = true;
            this.chkMasculino.CheckedChanged += new System.EventHandler(this.chkMasculino_CheckedChanged);
            // 
            // gpoSelecione
            // 
            this.gpoSelecione.Controls.Add(this.btnDesRegiao);
            this.gpoSelecione.Controls.Add(this.btnSelRegiao);
            this.gpoSelecione.Controls.Add(this.gridRegiao);
            this.gpoSelecione.Controls.Add(this.btnDesCargo);
            this.gpoSelecione.Controls.Add(this.btnSelCargo);
            this.gpoSelecione.Controls.Add(this.cboRegional);
            this.gpoSelecione.Controls.Add(this.lblRegional);
            this.gpoSelecione.Controls.Add(this.gridCargo);
            this.gpoSelecione.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSelecione.Location = new System.Drawing.Point(10, 132);
            this.gpoSelecione.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSelecione.Name = "gpoSelecione";
            this.gpoSelecione.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSelecione.Size = new System.Drawing.Size(510, 242);
            this.gpoSelecione.TabIndex = 21;
            this.gpoSelecione.TabStop = false;
            this.gpoSelecione.Text = "Selecione";
            // 
            // btnDesRegiao
            // 
            this.btnDesRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesRegiao.Image = global::ccbadm.Properties.Resources.DesTodos;
            this.btnDesRegiao.Location = new System.Drawing.Point(418, 210);
            this.btnDesRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesRegiao.Name = "btnDesRegiao";
            this.btnDesRegiao.Size = new System.Drawing.Size(80, 27);
            this.btnDesRegiao.TabIndex = 28;
            this.btnDesRegiao.Text = "Nenhum";
            this.btnDesRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesRegiao.UseVisualStyleBackColor = true;
            this.btnDesRegiao.Click += new System.EventHandler(this.btnDesRegiao_Click);
            // 
            // btnSelRegiao
            // 
            this.btnSelRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelRegiao.Image = global::ccbadm.Properties.Resources.SelTodos;
            this.btnSelRegiao.Location = new System.Drawing.Point(334, 210);
            this.btnSelRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelRegiao.Name = "btnSelRegiao";
            this.btnSelRegiao.Size = new System.Drawing.Size(80, 27);
            this.btnSelRegiao.TabIndex = 27;
            this.btnSelRegiao.Text = "Todos";
            this.btnSelRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelRegiao.UseVisualStyleBackColor = true;
            this.btnSelRegiao.Click += new System.EventHandler(this.btnSelRegiao_Click);
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
            this.gridRegiao.Location = new System.Drawing.Point(253, 45);
            this.gridRegiao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridRegiao.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridRegiao.MultiSelect = false;
            this.gridRegiao.Name = "gridRegiao";
            this.gridRegiao.ReadOnly = true;
            this.gridRegiao.RowHeadersVisible = false;
            this.gridRegiao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRegiao.RowTemplate.Height = 18;
            this.gridRegiao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegiao.Size = new System.Drawing.Size(245, 161);
            this.gridRegiao.TabIndex = 26;
            this.gridRegiao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellClick);
            // 
            // btnDesCargo
            // 
            this.btnDesCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesCargo.Image = global::ccbadm.Properties.Resources.DesTodos;
            this.btnDesCargo.Location = new System.Drawing.Point(152, 210);
            this.btnDesCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesCargo.Name = "btnDesCargo";
            this.btnDesCargo.Size = new System.Drawing.Size(80, 27);
            this.btnDesCargo.TabIndex = 24;
            this.btnDesCargo.Text = "Nenhum";
            this.btnDesCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesCargo.UseVisualStyleBackColor = true;
            this.btnDesCargo.Click += new System.EventHandler(this.btnDesCargo_Click);
            // 
            // btnSelCargo
            // 
            this.btnSelCargo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelCargo.Image = global::ccbadm.Properties.Resources.SelTodos;
            this.btnSelCargo.Location = new System.Drawing.Point(68, 210);
            this.btnSelCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelCargo.Name = "btnSelCargo";
            this.btnSelCargo.Size = new System.Drawing.Size(80, 27);
            this.btnSelCargo.TabIndex = 23;
            this.btnSelCargo.Text = "Todos";
            this.btnSelCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelCargo.UseVisualStyleBackColor = true;
            this.btnSelCargo.Click += new System.EventHandler(this.btnSelCargo_Click);
            // 
            // cboRegional
            // 
            this.cboRegional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegional.FormattingEnabled = true;
            this.cboRegional.Location = new System.Drawing.Point(300, 16);
            this.cboRegional.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(198, 21);
            this.cboRegional.TabIndex = 25;
            this.cboRegional.SelectionChangeCommitted += new System.EventHandler(this.cboRegional_SelectionChangeCommitted);
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRegional.Location = new System.Drawing.Point(251, 19);
            this.lblRegional.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegional.Name = "lblRegional";
            this.lblRegional.Size = new System.Drawing.Size(52, 13);
            this.lblRegional.TabIndex = 20;
            this.lblRegional.Text = "Regional:";
            // 
            // gridCargo
            // 
            this.gridCargo.AllowUserToAddRows = false;
            this.gridCargo.AllowUserToDeleteRows = false;
            this.gridCargo.AllowUserToResizeRows = false;
            this.gridCargo.BackgroundColor = System.Drawing.Color.White;
            this.gridCargo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCargo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCargo.DefaultCellStyle = dataGridViewCellStyle4;
            this.gridCargo.DisabledCell = null;
            this.gridCargo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCargo.EnableHeadersVisualStyles = false;
            this.gridCargo.Location = new System.Drawing.Point(10, 16);
            this.gridCargo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridCargo.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridCargo.MultiSelect = false;
            this.gridCargo.Name = "gridCargo";
            this.gridCargo.ReadOnly = true;
            this.gridCargo.RowHeadersVisible = false;
            this.gridCargo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCargo.RowTemplate.Height = 18;
            this.gridCargo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCargo.Size = new System.Drawing.Size(222, 190);
            this.gridCargo.TabIndex = 22;
            this.gridCargo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCargo_CellClick);
            // 
            // lblSexo
            // 
            this.lblSexo.Location = new System.Drawing.Point(13, 437);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(118, 13);
            this.lblSexo.TabIndex = 41;
            this.lblSexo.Text = "Masculino\', \'Feminino";
            this.lblSexo.Visible = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Image = global::ccbadm.Properties.Resources.Impressora;
            this.btnImprimir.Location = new System.Drawing.Point(348, 435);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(95, 35);
            this.btnImprimir.TabIndex = 32;
            this.btnImprimir.Text = " &Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblTipo
            // 
            this.lblTipo.Enabled = false;
            this.lblTipo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTipo.ForeColor = System.Drawing.Color.Black;
            this.lblTipo.Location = new System.Drawing.Point(460, 54);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 135;
            this.lblTipo.Visible = false;
            // 
            // frmMixListaReuniao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(546, 476);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlMix);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "frmMixListaReuniao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de Presentes e Ausentes nos Serviços";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMixListaReuniao_FormClosed);
            this.Load += new System.EventHandler(this.frmMixListaReuniao_Load);
            this.pnlMix.ResumeLayout(false);
            this.pnlMix.PerformLayout();
            this.pnlGrupo.ResumeLayout(false);
            this.pnlGrupo.PerformLayout();
            this.gpoAgrupar.ResumeLayout(false);
            this.gpoAgrupar.PerformLayout();
            this.gpoAdicionais.ResumeLayout(false);
            this.gpoAdicionais.PerformLayout();
            this.gpoRelatorio.ResumeLayout(false);
            this.gpoRelatorio.PerformLayout();
            this.gpoSexo.ResumeLayout(false);
            this.gpoSexo.PerformLayout();
            this.gpoSelecione.ResumeLayout(false);
            this.gpoSelecione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlMix;
        private System.Windows.Forms.GroupBox gpoSexo;
        private System.Windows.Forms.GroupBox gpoRelatorio;
        private System.Windows.Forms.RadioButton optAnalitico;
        private System.Windows.Forms.RadioButton optSintetico;
        private System.Windows.Forms.CheckBox chkFeminino;
        private System.Windows.Forms.CheckBox chkMasculino;
        private System.Windows.Forms.GroupBox gpoSelecione;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegional;
        private System.Windows.Forms.Label lblRegional;
        private BLL.validacoes.Controles.DataGridViewPersonal gridCargo;
        private System.Windows.Forms.Button btnDesCargo;
        private System.Windows.Forms.Button btnSelCargo;
        private System.Windows.Forms.GroupBox gpoAgrupar;
        private System.Windows.Forms.RadioButton optAgruInstr;
        private System.Windows.Forms.RadioButton optAgruCargo;
        private System.Windows.Forms.RadioButton optAgruRegiao;
        private BLL.validacoes.Controles.DataGridViewPersonal gridRegiao;
        private System.Windows.Forms.Button btnDesRegiao;
        private System.Windows.Forms.Button btnSelRegiao;
        private System.Windows.Forms.CheckBox chkAgruFamilia;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.CheckBox chkAgruComum;
        private System.Windows.Forms.GroupBox gpoAdicionais;
        private System.Windows.Forms.CheckBox chkPulaPagina;
        private System.Windows.Forms.CheckBox chkAgruCargo;
        private System.Windows.Forms.Panel pnlGrupo;
        private BLL.validacoes.Controles.TextBoxPersonal txtTipo;
        private System.Windows.Forms.Label lbTipo;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraReuniao;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataReuniao;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodReuniao;
        private System.Windows.Forms.Label lblReuniao;
        private System.Windows.Forms.Label lblDataReuniao;
        private BLL.validacoes.Controles.TextBoxPersonal txtLocal;
        private System.Windows.Forms.Label lbLocal;
        private System.Windows.Forms.CheckBox chkExibeResumo;
        private System.Windows.Forms.CheckBox chkExibeAusente;
        private System.Windows.Forms.Label lblTipo;
    }
}