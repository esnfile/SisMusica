namespace ccbrepess
{
    partial class frmMixPessoa
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMixPessoa));
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlMix = new System.Windows.Forms.Panel();
            this.gpoAgrupar = new System.Windows.Forms.GroupBox();
            this.optAgruInstr = new System.Windows.Forms.RadioButton();
            this.optAgruCargo = new System.Windows.Forms.RadioButton();
            this.optAgruCidade = new System.Windows.Forms.RadioButton();
            this.optAgruRegiao = new System.Windows.Forms.RadioButton();
            this.gpoAdicionais = new System.Windows.Forms.GroupBox();
            this.chkPulaPagina = new System.Windows.Forms.CheckBox();
            this.chkExibeDetalhe = new System.Windows.Forms.CheckBox();
            this.gpoOrdem = new System.Windows.Forms.GroupBox();
            this.optOrdemNome = new System.Windows.Forms.RadioButton();
            this.optOrdemCodigo = new System.Windows.Forms.RadioButton();
            this.gpoRelatorio = new System.Windows.Forms.GroupBox();
            this.optAnalitico = new System.Windows.Forms.RadioButton();
            this.optSintetico = new System.Windows.Forms.RadioButton();
            this.gpoEstadoCivil = new System.Windows.Forms.GroupBox();
            this.chkDivorciado = new System.Windows.Forms.CheckBox();
            this.chkViuvo = new System.Windows.Forms.CheckBox();
            this.chkCasado = new System.Windows.Forms.CheckBox();
            this.chkSolteiro = new System.Windows.Forms.CheckBox();
            this.gpoStatus = new System.Windows.Forms.GroupBox();
            this.chkInativo = new System.Windows.Forms.CheckBox();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.gpoSexo = new System.Windows.Forms.GroupBox();
            this.chkMasculino = new System.Windows.Forms.CheckBox();
            this.chkFeminino = new System.Windows.Forms.CheckBox();
            this.chkAgruFamilia = new System.Windows.Forms.CheckBox();
            this.gpoPeriodo = new System.Windows.Forms.GroupBox();
            this.btnDataFinal = new System.Windows.Forms.Button();
            this.btnDataInicial = new System.Windows.Forms.Button();
            this.txtDataInicial = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataFinal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataFinal = new System.Windows.Forms.Label();
            this.lblDataInicial = new System.Windows.Forms.Label();
            this.optDataApresenta = new System.Windows.Forms.RadioButton();
            this.optDataNasc = new System.Windows.Forms.RadioButton();
            this.optDataCadastro = new System.Windows.Forms.RadioButton();
            this.chkAgruComum = new System.Windows.Forms.CheckBox();
            this.chkAgruDesenv = new System.Windows.Forms.CheckBox();
            this.gpoSelecione = new System.Windows.Forms.GroupBox();
            this.btnDesRegiao = new System.Windows.Forms.Button();
            this.btnSelRegiao = new System.Windows.Forms.Button();
            this.gridRegiao = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.btnDesComum = new System.Windows.Forms.Button();
            this.btnSelComum = new System.Windows.Forms.Button();
            this.btnDesCargo = new System.Windows.Forms.Button();
            this.btnSelCargo = new System.Windows.Forms.Button();
            this.cboRegional = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegional = new System.Windows.Forms.Label();
            this.gridCargo = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.gridComum = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.lblSexo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblEstadoCivil = new System.Windows.Forms.Label();
            this.lblSolteiro = new System.Windows.Forms.Label();
            this.lblCasado = new System.Windows.Forms.Label();
            this.lblViuvo = new System.Windows.Forms.Label();
            this.lblDivorciado = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pnlMix.SuspendLayout();
            this.gpoAgrupar.SuspendLayout();
            this.gpoAdicionais.SuspendLayout();
            this.gpoOrdem.SuspendLayout();
            this.gpoRelatorio.SuspendLayout();
            this.gpoEstadoCivil.SuspendLayout();
            this.gpoStatus.SuspendLayout();
            this.gpoSexo.SuspendLayout();
            this.gpoPeriodo.SuspendLayout();
            this.gpoSelecione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(647, 436);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 35);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pnlMix
            // 
            this.pnlMix.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlMix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMix.Controls.Add(this.gpoAgrupar);
            this.pnlMix.Controls.Add(this.gpoAdicionais);
            this.pnlMix.Controls.Add(this.gpoOrdem);
            this.pnlMix.Controls.Add(this.gpoRelatorio);
            this.pnlMix.Controls.Add(this.gpoEstadoCivil);
            this.pnlMix.Controls.Add(this.gpoStatus);
            this.pnlMix.Controls.Add(this.gpoSexo);
            this.pnlMix.Controls.Add(this.chkAgruFamilia);
            this.pnlMix.Controls.Add(this.gpoPeriodo);
            this.pnlMix.Controls.Add(this.chkAgruComum);
            this.pnlMix.Controls.Add(this.chkAgruDesenv);
            this.pnlMix.Controls.Add(this.gpoSelecione);
            this.pnlMix.Location = new System.Drawing.Point(7, 7);
            this.pnlMix.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pnlMix.Name = "pnlMix";
            this.pnlMix.Size = new System.Drawing.Size(735, 425);
            this.pnlMix.TabIndex = 0;
            // 
            // gpoAgrupar
            // 
            this.gpoAgrupar.Controls.Add(this.optAgruInstr);
            this.gpoAgrupar.Controls.Add(this.optAgruCargo);
            this.gpoAgrupar.Controls.Add(this.optAgruCidade);
            this.gpoAgrupar.Controls.Add(this.optAgruRegiao);
            this.gpoAgrupar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAgrupar.Location = new System.Drawing.Point(200, 4);
            this.gpoAgrupar.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoAgrupar.Name = "gpoAgrupar";
            this.gpoAgrupar.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoAgrupar.Size = new System.Drawing.Size(200, 59);
            this.gpoAgrupar.TabIndex = 3;
            this.gpoAgrupar.TabStop = false;
            this.gpoAgrupar.Text = "Agrupar por";
            // 
            // optAgruInstr
            // 
            this.optAgruInstr.AutoSize = true;
            this.optAgruInstr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruInstr.Location = new System.Drawing.Point(104, 35);
            this.optAgruInstr.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruInstr.Name = "optAgruInstr";
            this.optAgruInstr.Size = new System.Drawing.Size(84, 17);
            this.optAgruInstr.TabIndex = 3;
            this.optAgruInstr.Text = "Instrumento";
            this.optAgruInstr.UseVisualStyleBackColor = true;
            this.optAgruInstr.CheckedChanged += new System.EventHandler(this.optAgruInstr_CheckedChanged);
            // 
            // optAgruCargo
            // 
            this.optAgruCargo.AutoSize = true;
            this.optAgruCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruCargo.Location = new System.Drawing.Point(104, 17);
            this.optAgruCargo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruCargo.Name = "optAgruCargo";
            this.optAgruCargo.Size = new System.Drawing.Size(70, 17);
            this.optAgruCargo.TabIndex = 2;
            this.optAgruCargo.Text = "Ministério";
            this.optAgruCargo.UseVisualStyleBackColor = true;
            this.optAgruCargo.CheckedChanged += new System.EventHandler(this.optAgruCargo_CheckedChanged);
            // 
            // optAgruCidade
            // 
            this.optAgruCidade.AutoSize = true;
            this.optAgruCidade.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruCidade.Location = new System.Drawing.Point(13, 35);
            this.optAgruCidade.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruCidade.Name = "optAgruCidade";
            this.optAgruCidade.Size = new System.Drawing.Size(58, 17);
            this.optAgruCidade.TabIndex = 1;
            this.optAgruCidade.Text = "Cidade";
            this.optAgruCidade.UseVisualStyleBackColor = true;
            this.optAgruCidade.CheckedChanged += new System.EventHandler(this.optAgruCidade_CheckedChanged);
            // 
            // optAgruRegiao
            // 
            this.optAgruRegiao.AutoSize = true;
            this.optAgruRegiao.Checked = true;
            this.optAgruRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAgruRegiao.Location = new System.Drawing.Point(13, 17);
            this.optAgruRegiao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAgruRegiao.Name = "optAgruRegiao";
            this.optAgruRegiao.Size = new System.Drawing.Size(84, 17);
            this.optAgruRegiao.TabIndex = 0;
            this.optAgruRegiao.TabStop = true;
            this.optAgruRegiao.Text = "Microrregião";
            this.optAgruRegiao.UseVisualStyleBackColor = true;
            this.optAgruRegiao.CheckedChanged += new System.EventHandler(this.optAgruRegiao_CheckedChanged);
            // 
            // gpoAdicionais
            // 
            this.gpoAdicionais.Controls.Add(this.chkPulaPagina);
            this.gpoAdicionais.Controls.Add(this.chkExibeDetalhe);
            this.gpoAdicionais.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoAdicionais.Location = new System.Drawing.Point(8, 376);
            this.gpoAdicionais.Name = "gpoAdicionais";
            this.gpoAdicionais.Size = new System.Drawing.Size(289, 40);
            this.gpoAdicionais.TabIndex = 28;
            this.gpoAdicionais.TabStop = false;
            this.gpoAdicionais.Text = "Configurações adicionais";
            // 
            // chkPulaPagina
            // 
            this.chkPulaPagina.AutoSize = true;
            this.chkPulaPagina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPulaPagina.Location = new System.Drawing.Point(12, 16);
            this.chkPulaPagina.Name = "chkPulaPagina";
            this.chkPulaPagina.Size = new System.Drawing.Size(166, 17);
            this.chkPulaPagina.TabIndex = 25;
            this.chkPulaPagina.Text = "Inicia grupo em nova página?";
            this.chkPulaPagina.UseVisualStyleBackColor = true;
            // 
            // chkExibeDetalhe
            // 
            this.chkExibeDetalhe.AutoSize = true;
            this.chkExibeDetalhe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkExibeDetalhe.Location = new System.Drawing.Point(190, 16);
            this.chkExibeDetalhe.Name = "chkExibeDetalhe";
            this.chkExibeDetalhe.Size = new System.Drawing.Size(89, 17);
            this.chkExibeDetalhe.TabIndex = 26;
            this.chkExibeDetalhe.Text = "Exibe dados?";
            this.chkExibeDetalhe.UseVisualStyleBackColor = true;
            this.chkExibeDetalhe.CheckedChanged += new System.EventHandler(this.chkExibeDetalhe_CheckedChanged);
            // 
            // gpoOrdem
            // 
            this.gpoOrdem.Controls.Add(this.optOrdemNome);
            this.gpoOrdem.Controls.Add(this.optOrdemCodigo);
            this.gpoOrdem.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoOrdem.Location = new System.Drawing.Point(110, 4);
            this.gpoOrdem.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoOrdem.Name = "gpoOrdem";
            this.gpoOrdem.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoOrdem.Size = new System.Drawing.Size(76, 59);
            this.gpoOrdem.TabIndex = 2;
            this.gpoOrdem.TabStop = false;
            this.gpoOrdem.Text = "Ordem";
            // 
            // optOrdemNome
            // 
            this.optOrdemNome.AutoSize = true;
            this.optOrdemNome.Checked = true;
            this.optOrdemNome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optOrdemNome.Location = new System.Drawing.Point(10, 35);
            this.optOrdemNome.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optOrdemNome.Name = "optOrdemNome";
            this.optOrdemNome.Size = new System.Drawing.Size(52, 17);
            this.optOrdemNome.TabIndex = 1;
            this.optOrdemNome.TabStop = true;
            this.optOrdemNome.Text = "Nome";
            this.optOrdemNome.UseVisualStyleBackColor = true;
            this.optOrdemNome.CheckedChanged += new System.EventHandler(this.optOrdemNome_CheckedChanged);
            // 
            // optOrdemCodigo
            // 
            this.optOrdemCodigo.AutoSize = true;
            this.optOrdemCodigo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optOrdemCodigo.Location = new System.Drawing.Point(10, 17);
            this.optOrdemCodigo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optOrdemCodigo.Name = "optOrdemCodigo";
            this.optOrdemCodigo.Size = new System.Drawing.Size(58, 17);
            this.optOrdemCodigo.TabIndex = 0;
            this.optOrdemCodigo.Text = "Código";
            this.optOrdemCodigo.UseVisualStyleBackColor = true;
            this.optOrdemCodigo.CheckedChanged += new System.EventHandler(this.optOrdemCodigo_CheckedChanged);
            // 
            // gpoRelatorio
            // 
            this.gpoRelatorio.Controls.Add(this.optAnalitico);
            this.gpoRelatorio.Controls.Add(this.optSintetico);
            this.gpoRelatorio.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoRelatorio.Location = new System.Drawing.Point(10, 4);
            this.gpoRelatorio.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoRelatorio.Name = "gpoRelatorio";
            this.gpoRelatorio.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoRelatorio.Size = new System.Drawing.Size(87, 59);
            this.gpoRelatorio.TabIndex = 1;
            this.gpoRelatorio.TabStop = false;
            this.gpoRelatorio.Text = "Tipo Relatório";
            // 
            // optAnalitico
            // 
            this.optAnalitico.AutoSize = true;
            this.optAnalitico.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAnalitico.Location = new System.Drawing.Point(11, 35);
            this.optAnalitico.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optAnalitico.Name = "optAnalitico";
            this.optAnalitico.Size = new System.Drawing.Size(65, 17);
            this.optAnalitico.TabIndex = 1;
            this.optAnalitico.Text = "Analítico";
            this.optAnalitico.UseVisualStyleBackColor = true;
            this.optAnalitico.CheckedChanged += new System.EventHandler(this.optAnalitico_CheckedChanged);
            // 
            // optSintetico
            // 
            this.optSintetico.AutoSize = true;
            this.optSintetico.Checked = true;
            this.optSintetico.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optSintetico.Location = new System.Drawing.Point(11, 17);
            this.optSintetico.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optSintetico.Name = "optSintetico";
            this.optSintetico.Size = new System.Drawing.Size(66, 17);
            this.optSintetico.TabIndex = 0;
            this.optSintetico.TabStop = true;
            this.optSintetico.Text = "Sintético";
            this.optSintetico.UseVisualStyleBackColor = true;
            this.optSintetico.CheckedChanged += new System.EventHandler(this.optSintetico_CheckedChanged);
            // 
            // gpoEstadoCivil
            // 
            this.gpoEstadoCivil.Controls.Add(this.chkDivorciado);
            this.gpoEstadoCivil.Controls.Add(this.chkViuvo);
            this.gpoEstadoCivil.Controls.Add(this.chkCasado);
            this.gpoEstadoCivil.Controls.Add(this.chkSolteiro);
            this.gpoEstadoCivil.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoEstadoCivil.Location = new System.Drawing.Point(567, 4);
            this.gpoEstadoCivil.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoEstadoCivil.Name = "gpoEstadoCivil";
            this.gpoEstadoCivil.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoEstadoCivil.Size = new System.Drawing.Size(158, 59);
            this.gpoEstadoCivil.TabIndex = 6;
            this.gpoEstadoCivil.TabStop = false;
            this.gpoEstadoCivil.Text = "Estado Civil";
            // 
            // chkDivorciado
            // 
            this.chkDivorciado.AutoSize = true;
            this.chkDivorciado.Checked = true;
            this.chkDivorciado.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDivorciado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkDivorciado.Location = new System.Drawing.Point(74, 35);
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
            this.chkViuvo.Location = new System.Drawing.Point(9, 35);
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
            this.chkCasado.Location = new System.Drawing.Point(74, 17);
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
            this.chkSolteiro.Location = new System.Drawing.Point(9, 17);
            this.chkSolteiro.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkSolteiro.Name = "chkSolteiro";
            this.chkSolteiro.Size = new System.Drawing.Size(62, 17);
            this.chkSolteiro.TabIndex = 0;
            this.chkSolteiro.Text = "Solteiro";
            this.chkSolteiro.UseVisualStyleBackColor = true;
            this.chkSolteiro.CheckedChanged += new System.EventHandler(this.chkSolteiro_CheckedChanged);
            // 
            // gpoStatus
            // 
            this.gpoStatus.Controls.Add(this.chkInativo);
            this.gpoStatus.Controls.Add(this.chkAtivo);
            this.gpoStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoStatus.Location = new System.Drawing.Point(493, 4);
            this.gpoStatus.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoStatus.Name = "gpoStatus";
            this.gpoStatus.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoStatus.Size = new System.Drawing.Size(70, 59);
            this.gpoStatus.TabIndex = 5;
            this.gpoStatus.TabStop = false;
            this.gpoStatus.Text = "Status";
            // 
            // chkInativo
            // 
            this.chkInativo.AutoSize = true;
            this.chkInativo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkInativo.Location = new System.Drawing.Point(8, 35);
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
            this.chkAtivo.Location = new System.Drawing.Point(8, 17);
            this.chkAtivo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(51, 17);
            this.chkAtivo.TabIndex = 0;
            this.chkAtivo.Text = "Ativo";
            this.chkAtivo.UseVisualStyleBackColor = true;
            this.chkAtivo.CheckedChanged += new System.EventHandler(this.chkAtivo_CheckedChanged);
            // 
            // gpoSexo
            // 
            this.gpoSexo.Controls.Add(this.chkMasculino);
            this.gpoSexo.Controls.Add(this.chkFeminino);
            this.gpoSexo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSexo.Location = new System.Drawing.Point(406, 4);
            this.gpoSexo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Name = "gpoSexo";
            this.gpoSexo.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSexo.Size = new System.Drawing.Size(82, 59);
            this.gpoSexo.TabIndex = 4;
            this.gpoSexo.TabStop = false;
            this.gpoSexo.Text = "Sexo";
            // 
            // chkMasculino
            // 
            this.chkMasculino.AutoSize = true;
            this.chkMasculino.Checked = true;
            this.chkMasculino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMasculino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMasculino.Location = new System.Drawing.Point(8, 17);
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
            this.chkFeminino.Location = new System.Drawing.Point(8, 35);
            this.chkFeminino.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkFeminino.Name = "chkFeminino";
            this.chkFeminino.Size = new System.Drawing.Size(68, 17);
            this.chkFeminino.TabIndex = 1;
            this.chkFeminino.Text = "Feminino";
            this.chkFeminino.UseVisualStyleBackColor = true;
            this.chkFeminino.CheckedChanged += new System.EventHandler(this.chkFeminino_CheckedChanged);
            // 
            // chkAgruFamilia
            // 
            this.chkAgruFamilia.AutoSize = true;
            this.chkAgruFamilia.Location = new System.Drawing.Point(11, 88);
            this.chkAgruFamilia.Name = "chkAgruFamilia";
            this.chkAgruFamilia.Size = new System.Drawing.Size(202, 17);
            this.chkAgruFamilia.TabIndex = 8;
            this.chkAgruFamilia.Text = "Agrupar por família de instrumentos?";
            this.chkAgruFamilia.UseVisualStyleBackColor = true;
            // 
            // gpoPeriodo
            // 
            this.gpoPeriodo.Controls.Add(this.btnDataFinal);
            this.gpoPeriodo.Controls.Add(this.btnDataInicial);
            this.gpoPeriodo.Controls.Add(this.txtDataInicial);
            this.gpoPeriodo.Controls.Add(this.txtDataFinal);
            this.gpoPeriodo.Controls.Add(this.lblDataFinal);
            this.gpoPeriodo.Controls.Add(this.lblDataInicial);
            this.gpoPeriodo.Controls.Add(this.optDataApresenta);
            this.gpoPeriodo.Controls.Add(this.optDataNasc);
            this.gpoPeriodo.Controls.Add(this.optDataCadastro);
            this.gpoPeriodo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoPeriodo.Location = new System.Drawing.Point(406, 61);
            this.gpoPeriodo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoPeriodo.Name = "gpoPeriodo";
            this.gpoPeriodo.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoPeriodo.Size = new System.Drawing.Size(319, 68);
            this.gpoPeriodo.TabIndex = 10;
            this.gpoPeriodo.TabStop = false;
            this.gpoPeriodo.Text = "Período";
            // 
            // btnDataFinal
            // 
            this.btnDataFinal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataFinal.BackgroundImage = global::ccbrepess.Properties.Resources.depois;
            this.btnDataFinal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDataFinal.Location = new System.Drawing.Point(290, 40);
            this.btnDataFinal.Name = "btnDataFinal";
            this.btnDataFinal.Size = new System.Drawing.Size(18, 19);
            this.btnDataFinal.TabIndex = 6;
            this.btnDataFinal.UseVisualStyleBackColor = true;
            this.btnDataFinal.Click += new System.EventHandler(this.btnDataFinal_Click);
            // 
            // btnDataInicial
            // 
            this.btnDataInicial.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataInicial.BackgroundImage = global::ccbrepess.Properties.Resources.antes;
            this.btnDataInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDataInicial.Location = new System.Drawing.Point(290, 14);
            this.btnDataInicial.Name = "btnDataInicial";
            this.btnDataInicial.Size = new System.Drawing.Size(18, 19);
            this.btnDataInicial.TabIndex = 4;
            this.btnDataInicial.UseVisualStyleBackColor = true;
            this.btnDataInicial.Click += new System.EventHandler(this.btnDataInicial_Click);
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.BackColor = System.Drawing.Color.White;
            this.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataInicial.Location = new System.Drawing.Point(219, 13);
            this.txtDataInicial.MaxLength = 10;
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(90, 21);
            this.txtDataInicial.TabIndex = 3;
            this.txtDataInicial.Text = "01/01/1910";
            this.txtDataInicial.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataInicial.Validated += new System.EventHandler(this.txtDataInicial_Validated);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.BackColor = System.Drawing.Color.White;
            this.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataFinal.Location = new System.Drawing.Point(219, 39);
            this.txtDataFinal.MaxLength = 100;
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(90, 21);
            this.txtDataFinal.TabIndex = 5;
            this.txtDataFinal.Text = "31/12/2050";
            this.txtDataFinal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataFinal.Validated += new System.EventHandler(this.txtDataFinal_Validated);
            // 
            // lblDataFinal
            // 
            this.lblDataFinal.AutoSize = true;
            this.lblDataFinal.Location = new System.Drawing.Point(156, 43);
            this.lblDataFinal.Name = "lblDataFinal";
            this.lblDataFinal.Size = new System.Drawing.Size(59, 13);
            this.lblDataFinal.TabIndex = 162;
            this.lblDataFinal.Text = "Data Final:";
            // 
            // lblDataInicial
            // 
            this.lblDataInicial.AutoSize = true;
            this.lblDataInicial.Location = new System.Drawing.Point(156, 17);
            this.lblDataInicial.Name = "lblDataInicial";
            this.lblDataInicial.Size = new System.Drawing.Size(64, 13);
            this.lblDataInicial.TabIndex = 159;
            this.lblDataInicial.Text = "Data Inicial:";
            // 
            // optDataApresenta
            // 
            this.optDataApresenta.AutoSize = true;
            this.optDataApresenta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optDataApresenta.Location = new System.Drawing.Point(8, 46);
            this.optDataApresenta.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optDataApresenta.Name = "optDataApresenta";
            this.optDataApresenta.Size = new System.Drawing.Size(133, 17);
            this.optDataApresenta.TabIndex = 2;
            this.optDataApresenta.Text = "Data de Apresentação";
            this.optDataApresenta.UseVisualStyleBackColor = true;
            // 
            // optDataNasc
            // 
            this.optDataNasc.AutoSize = true;
            this.optDataNasc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optDataNasc.Location = new System.Drawing.Point(8, 29);
            this.optDataNasc.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optDataNasc.Name = "optDataNasc";
            this.optDataNasc.Size = new System.Drawing.Size(121, 17);
            this.optDataNasc.TabIndex = 1;
            this.optDataNasc.Text = "Data de Nascimento";
            this.optDataNasc.UseVisualStyleBackColor = true;
            // 
            // optDataCadastro
            // 
            this.optDataCadastro.AutoSize = true;
            this.optDataCadastro.Checked = true;
            this.optDataCadastro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optDataCadastro.Location = new System.Drawing.Point(8, 12);
            this.optDataCadastro.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.optDataCadastro.Name = "optDataCadastro";
            this.optDataCadastro.Size = new System.Drawing.Size(110, 17);
            this.optDataCadastro.TabIndex = 0;
            this.optDataCadastro.TabStop = true;
            this.optDataCadastro.Text = "Data de Cadastro";
            this.optDataCadastro.UseVisualStyleBackColor = true;
            // 
            // chkAgruComum
            // 
            this.chkAgruComum.AutoSize = true;
            this.chkAgruComum.Location = new System.Drawing.Point(11, 69);
            this.chkAgruComum.Name = "chkAgruComum";
            this.chkAgruComum.Size = new System.Drawing.Size(172, 17);
            this.chkAgruComum.TabIndex = 7;
            this.chkAgruComum.Text = "Agrupar registros por Comum?";
            this.chkAgruComum.UseVisualStyleBackColor = true;
            // 
            // chkAgruDesenv
            // 
            this.chkAgruDesenv.AutoSize = true;
            this.chkAgruDesenv.Location = new System.Drawing.Point(11, 107);
            this.chkAgruDesenv.Name = "chkAgruDesenv";
            this.chkAgruDesenv.Size = new System.Drawing.Size(210, 17);
            this.chkAgruDesenv.TabIndex = 9;
            this.chkAgruDesenv.Text = "Agrupar por desenvolvimento musical?";
            this.chkAgruDesenv.UseVisualStyleBackColor = true;
            // 
            // gpoSelecione
            // 
            this.gpoSelecione.Controls.Add(this.btnDesRegiao);
            this.gpoSelecione.Controls.Add(this.btnSelRegiao);
            this.gpoSelecione.Controls.Add(this.gridRegiao);
            this.gpoSelecione.Controls.Add(this.btnDesComum);
            this.gpoSelecione.Controls.Add(this.btnSelComum);
            this.gpoSelecione.Controls.Add(this.btnDesCargo);
            this.gpoSelecione.Controls.Add(this.btnSelCargo);
            this.gpoSelecione.Controls.Add(this.cboRegional);
            this.gpoSelecione.Controls.Add(this.lblRegional);
            this.gpoSelecione.Controls.Add(this.gridCargo);
            this.gpoSelecione.Controls.Add(this.gridComum);
            this.gpoSelecione.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpoSelecione.Location = new System.Drawing.Point(10, 127);
            this.gpoSelecione.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSelecione.Name = "gpoSelecione";
            this.gpoSelecione.Padding = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gpoSelecione.Size = new System.Drawing.Size(715, 242);
            this.gpoSelecione.TabIndex = 11;
            this.gpoSelecione.TabStop = false;
            this.gpoSelecione.Text = "Selecione";
            // 
            // btnDesRegiao
            // 
            this.btnDesRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesRegiao.Image = global::ccbrepess.Properties.Resources.DesTodos;
            this.btnDesRegiao.Location = new System.Drawing.Point(340, 210);
            this.btnDesRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesRegiao.Name = "btnDesRegiao";
            this.btnDesRegiao.Size = new System.Drawing.Size(80, 27);
            this.btnDesRegiao.TabIndex = 6;
            this.btnDesRegiao.Text = "Nenhum";
            this.btnDesRegiao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesRegiao.UseVisualStyleBackColor = true;
            this.btnDesRegiao.Click += new System.EventHandler(this.btnDesRegiao_Click);
            // 
            // btnSelRegiao
            // 
            this.btnSelRegiao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelRegiao.Image = global::ccbrepess.Properties.Resources.SelTodos;
            this.btnSelRegiao.Location = new System.Drawing.Point(256, 210);
            this.btnSelRegiao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelRegiao.Name = "btnSelRegiao";
            this.btnSelRegiao.Size = new System.Drawing.Size(80, 27);
            this.btnSelRegiao.TabIndex = 5;
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
            this.gridRegiao.Location = new System.Drawing.Point(213, 45);
            this.gridRegiao.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridRegiao.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridRegiao.MultiSelect = false;
            this.gridRegiao.Name = "gridRegiao";
            this.gridRegiao.ReadOnly = true;
            this.gridRegiao.RowHeadersVisible = false;
            this.gridRegiao.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRegiao.RowTemplate.Height = 18;
            this.gridRegiao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegiao.Size = new System.Drawing.Size(207, 161);
            this.gridRegiao.TabIndex = 4;
            this.gridRegiao.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridRegiao_CellClick);
            // 
            // btnDesComum
            // 
            this.btnDesComum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesComum.Image = global::ccbrepess.Properties.Resources.DesTodos;
            this.btnDesComum.Location = new System.Drawing.Point(625, 210);
            this.btnDesComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesComum.Name = "btnDesComum";
            this.btnDesComum.Size = new System.Drawing.Size(80, 27);
            this.btnDesComum.TabIndex = 9;
            this.btnDesComum.Text = "Nenhum";
            this.btnDesComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesComum.UseVisualStyleBackColor = true;
            this.btnDesComum.Click += new System.EventHandler(this.btnDesComum_Click);
            // 
            // btnSelComum
            // 
            this.btnSelComum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelComum.Image = global::ccbrepess.Properties.Resources.SelTodos;
            this.btnSelComum.Location = new System.Drawing.Point(541, 210);
            this.btnSelComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelComum.Name = "btnSelComum";
            this.btnSelComum.Size = new System.Drawing.Size(80, 27);
            this.btnSelComum.TabIndex = 8;
            this.btnSelComum.Text = "Todos";
            this.btnSelComum.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelComum.UseVisualStyleBackColor = true;
            this.btnSelComum.Click += new System.EventHandler(this.btnSelComum_Click);
            // 
            // btnDesCargo
            // 
            this.btnDesCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesCargo.Image = global::ccbrepess.Properties.Resources.DesTodos;
            this.btnDesCargo.Location = new System.Drawing.Point(115, 210);
            this.btnDesCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesCargo.Name = "btnDesCargo";
            this.btnDesCargo.Size = new System.Drawing.Size(80, 27);
            this.btnDesCargo.TabIndex = 2;
            this.btnDesCargo.Text = "Nenhum";
            this.btnDesCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesCargo.UseVisualStyleBackColor = true;
            this.btnDesCargo.Click += new System.EventHandler(this.btnDesCargo_Click);
            // 
            // btnSelCargo
            // 
            this.btnSelCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelCargo.Image = global::ccbrepess.Properties.Resources.SelTodos;
            this.btnSelCargo.Location = new System.Drawing.Point(31, 210);
            this.btnSelCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelCargo.Name = "btnSelCargo";
            this.btnSelCargo.Size = new System.Drawing.Size(80, 27);
            this.btnSelCargo.TabIndex = 1;
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
            this.cboRegional.Location = new System.Drawing.Point(260, 16);
            this.cboRegional.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(160, 21);
            this.cboRegional.TabIndex = 3;
            this.cboRegional.SelectionChangeCommitted += new System.EventHandler(this.cboRegional_SelectionChangeCommitted);
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRegional.Location = new System.Drawing.Point(211, 19);
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
            this.gridCargo.Size = new System.Drawing.Size(185, 190);
            this.gridCargo.TabIndex = 0;
            this.gridCargo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCargo_CellClick);
            // 
            // gridComum
            // 
            this.gridComum.AllowUserToAddRows = false;
            this.gridComum.AllowUserToDeleteRows = false;
            this.gridComum.AllowUserToResizeRows = false;
            this.gridComum.BackgroundColor = System.Drawing.Color.White;
            this.gridComum.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridComum.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gridComum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle6.NullValue = null;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridComum.DefaultCellStyle = dataGridViewCellStyle6;
            this.gridComum.DisabledCell = null;
            this.gridComum.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridComum.EnableHeadersVisualStyles = false;
            this.gridComum.Location = new System.Drawing.Point(438, 16);
            this.gridComum.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridComum.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridComum.MultiSelect = false;
            this.gridComum.Name = "gridComum";
            this.gridComum.ReadOnly = true;
            this.gridComum.RowHeadersVisible = false;
            this.gridComum.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridComum.RowTemplate.Height = 18;
            this.gridComum.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridComum.Size = new System.Drawing.Size(267, 190);
            this.gridComum.TabIndex = 7;
            this.gridComum.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridComum_CellClick);
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
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(10, 454);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 13);
            this.lblStatus.TabIndex = 42;
            this.lblStatus.Text = "Sim";
            this.lblStatus.Visible = false;
            // 
            // lblEstadoCivil
            // 
            this.lblEstadoCivil.Location = new System.Drawing.Point(75, 454);
            this.lblEstadoCivil.Name = "lblEstadoCivil";
            this.lblEstadoCivil.Size = new System.Drawing.Size(241, 13);
            this.lblEstadoCivil.TabIndex = 43;
            this.lblEstadoCivil.Text = "Solteiro(a)\',\'Casado(a)\',\'Viúvo(a)\',\'Divorciado(a)";
            this.lblEstadoCivil.Visible = false;
            // 
            // lblSolteiro
            // 
            this.lblSolteiro.Location = new System.Drawing.Point(249, 438);
            this.lblSolteiro.Name = "lblSolteiro";
            this.lblSolteiro.Size = new System.Drawing.Size(64, 13);
            this.lblSolteiro.TabIndex = 44;
            this.lblSolteiro.Text = "Solteiro(a)";
            this.lblSolteiro.Visible = false;
            // 
            // lblCasado
            // 
            this.lblCasado.Location = new System.Drawing.Point(313, 438);
            this.lblCasado.Name = "lblCasado";
            this.lblCasado.Size = new System.Drawing.Size(62, 13);
            this.lblCasado.TabIndex = 45;
            this.lblCasado.Text = "Casado(a)";
            this.lblCasado.Visible = false;
            // 
            // lblViuvo
            // 
            this.lblViuvo.Location = new System.Drawing.Point(374, 438);
            this.lblViuvo.Name = "lblViuvo";
            this.lblViuvo.Size = new System.Drawing.Size(47, 13);
            this.lblViuvo.TabIndex = 46;
            this.lblViuvo.Text = "Viúvo(a)";
            this.lblViuvo.Visible = false;
            // 
            // lblDivorciado
            // 
            this.lblDivorciado.Location = new System.Drawing.Point(427, 438);
            this.lblDivorciado.Name = "lblDivorciado";
            this.lblDivorciado.Size = new System.Drawing.Size(71, 13);
            this.lblDivorciado.TabIndex = 47;
            this.lblDivorciado.Text = "Divorciado(a)";
            this.lblDivorciado.Visible = false;
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::ccbrepess.Properties.Resources.Impressora;
            this.btnImprimir.Location = new System.Drawing.Point(549, 436);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(95, 35);
            this.btnImprimir.TabIndex = 1;
            this.btnImprimir.Text = " &Imprimir";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmMixPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(748, 476);
            this.Controls.Add(this.lblDivorciado);
            this.Controls.Add(this.lblViuvo);
            this.Controls.Add(this.lblCasado);
            this.Controls.Add(this.lblSolteiro);
            this.Controls.Add(this.lblEstadoCivil);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlMix);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "frmMixPessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listagem de Pessoas";
            this.Load += new System.EventHandler(this.frmMixPessoa_Load);
            this.pnlMix.ResumeLayout(false);
            this.pnlMix.PerformLayout();
            this.gpoAgrupar.ResumeLayout(false);
            this.gpoAgrupar.PerformLayout();
            this.gpoAdicionais.ResumeLayout(false);
            this.gpoAdicionais.PerformLayout();
            this.gpoOrdem.ResumeLayout(false);
            this.gpoOrdem.PerformLayout();
            this.gpoRelatorio.ResumeLayout(false);
            this.gpoRelatorio.PerformLayout();
            this.gpoEstadoCivil.ResumeLayout(false);
            this.gpoEstadoCivil.PerformLayout();
            this.gpoStatus.ResumeLayout(false);
            this.gpoStatus.PerformLayout();
            this.gpoSexo.ResumeLayout(false);
            this.gpoSexo.PerformLayout();
            this.gpoPeriodo.ResumeLayout(false);
            this.gpoPeriodo.PerformLayout();
            this.gpoSelecione.ResumeLayout(false);
            this.gpoSelecione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegiao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridComum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlMix;
        private System.Windows.Forms.GroupBox gpoSexo;
        private BLL.validacoes.Controles.DataGridViewPersonal gridComum;
        private System.Windows.Forms.GroupBox gpoOrdem;
        private System.Windows.Forms.RadioButton optOrdemNome;
        private System.Windows.Forms.RadioButton optOrdemCodigo;
        private System.Windows.Forms.GroupBox gpoRelatorio;
        private System.Windows.Forms.RadioButton optAnalitico;
        private System.Windows.Forms.RadioButton optSintetico;
        private System.Windows.Forms.CheckBox chkFeminino;
        private System.Windows.Forms.CheckBox chkMasculino;
        private System.Windows.Forms.GroupBox gpoStatus;
        private System.Windows.Forms.CheckBox chkInativo;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.GroupBox gpoSelecione;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegional;
        private System.Windows.Forms.Label lblRegional;
        private BLL.validacoes.Controles.DataGridViewPersonal gridCargo;
        private System.Windows.Forms.Button btnDesCargo;
        private System.Windows.Forms.Button btnSelCargo;
        private System.Windows.Forms.Button btnDesComum;
        private System.Windows.Forms.Button btnSelComum;
        private System.Windows.Forms.GroupBox gpoAgrupar;
        private System.Windows.Forms.RadioButton optAgruInstr;
        private System.Windows.Forms.RadioButton optAgruCargo;
        private System.Windows.Forms.RadioButton optAgruCidade;
        private System.Windows.Forms.RadioButton optAgruRegiao;
        private BLL.validacoes.Controles.DataGridViewPersonal gridRegiao;
        private System.Windows.Forms.Button btnDesRegiao;
        private System.Windows.Forms.Button btnSelRegiao;
        private System.Windows.Forms.CheckBox chkAgruFamilia;
        private System.Windows.Forms.CheckBox chkAgruDesenv;
        private System.Windows.Forms.GroupBox gpoEstadoCivil;
        private System.Windows.Forms.CheckBox chkViuvo;
        private System.Windows.Forms.CheckBox chkSolteiro;
        private System.Windows.Forms.CheckBox chkDivorciado;
        private System.Windows.Forms.CheckBox chkCasado;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblEstadoCivil;
        private System.Windows.Forms.Label lblSolteiro;
        private System.Windows.Forms.Label lblCasado;
        private System.Windows.Forms.Label lblViuvo;
        private System.Windows.Forms.Label lblDivorciado;
        private System.Windows.Forms.CheckBox chkAgruComum;
        private System.Windows.Forms.GroupBox gpoPeriodo;
        private System.Windows.Forms.RadioButton optDataApresenta;
        private System.Windows.Forms.RadioButton optDataNasc;
        private System.Windows.Forms.RadioButton optDataCadastro;
        private System.Windows.Forms.Button btnDataFinal;
        private System.Windows.Forms.Button btnDataInicial;
        private System.Windows.Forms.Label lblDataFinal;
        private System.Windows.Forms.Label lblDataInicial;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataFinal;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataInicial;
        private System.Windows.Forms.GroupBox gpoAdicionais;
        private System.Windows.Forms.CheckBox chkPulaPagina;
        private System.Windows.Forms.CheckBox chkExibeDetalhe;
    }
}