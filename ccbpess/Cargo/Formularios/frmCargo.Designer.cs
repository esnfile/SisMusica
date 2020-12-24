namespace ccbpess
{
    partial class frmCargo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargo));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipCCB = new System.Windows.Forms.ToolTip(this.components);
            this.txtSigla = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cboDepartamento = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtOrdem = new BLL.validacoes.Controles.NumericUpDownPersonal();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlCargo = new System.Windows.Forms.Panel();
            this.gpoDesenvolvimento = new System.Windows.Forms.GroupBox();
            this.chkOficial = new System.Windows.Forms.CheckBox();
            this.chkCulto = new System.Windows.Forms.CheckBox();
            this.chkRjm = new System.Windows.Forms.CheckBox();
            this.chkMeiaHora = new System.Windows.Forms.CheckBox();
            this.chkEnsaio = new System.Windows.Forms.CheckBox();
            this.chkAlunoGem = new System.Windows.Forms.CheckBox();
            this.chkPermiteInstr = new System.Windows.Forms.CheckBox();
            this.gpoAtendimento = new System.Windows.Forms.GroupBox();
            this.gpoAtReg = new System.Windows.Forms.GroupBox();
            this.optAtRegNao = new System.Windows.Forms.RadioButton();
            this.optAtRegSim = new System.Windows.Forms.RadioButton();
            this.gpoAtEspiritual = new System.Windows.Forms.GroupBox();
            this.chkAtOrdenacao = new System.Windows.Forms.CheckBox();
            this.chkAtCasal = new System.Windows.Forms.CheckBox();
            this.chkAtRjm = new System.Windows.Forms.CheckBox();
            this.chkAtReunMin = new System.Windows.Forms.CheckBox();
            this.chkAtReunMoc = new System.Windows.Forms.CheckBox();
            this.chkAtCeia = new System.Windows.Forms.CheckBox();
            this.chkAtBatismo = new System.Windows.Forms.CheckBox();
            this.gpoAtCom = new System.Windows.Forms.GroupBox();
            this.optAtComNao = new System.Windows.Forms.RadioButton();
            this.optAtComSim = new System.Windows.Forms.RadioButton();
            this.gpoAtMusical = new System.Windows.Forms.GroupBox();
            this.chkAtEnsTec = new System.Windows.Forms.CheckBox();
            this.chkAtEnsParc = new System.Windows.Forms.CheckBox();
            this.chkAtEnsReg = new System.Windows.Forms.CheckBox();
            this.chkAtEnsLoc = new System.Windows.Forms.CheckBox();
            this.chkAtGem = new System.Windows.Forms.CheckBox();
            this.gpoTeste = new System.Windows.Forms.GroupBox();
            this.chkTesOficialMus = new System.Windows.Forms.CheckBox();
            this.chkTesCultoOrg = new System.Windows.Forms.CheckBox();
            this.chkTesCultoMus = new System.Windows.Forms.CheckBox();
            this.chkTesRjmOrg = new System.Windows.Forms.CheckBox();
            this.chkTesRjmMus = new System.Windows.Forms.CheckBox();
            this.chkTesOficialOrg = new System.Windows.Forms.CheckBox();
            this.gpoPreTeste = new System.Windows.Forms.GroupBox();
            this.chkPreOficialMus = new System.Windows.Forms.CheckBox();
            this.chkPreCultoOrg = new System.Windows.Forms.CheckBox();
            this.chkPreCultoMus = new System.Windows.Forms.CheckBox();
            this.chkPreRjmOrg = new System.Windows.Forms.CheckBox();
            this.chkPreRjmMus = new System.Windows.Forms.CheckBox();
            this.chkPreOficialOrg = new System.Windows.Forms.CheckBox();
            this.lblOrdem = new System.Windows.Forms.Label();
            this.gpoSexo = new System.Windows.Forms.GroupBox();
            this.chkFeminino = new System.Windows.Forms.CheckBox();
            this.chkMasculino = new System.Windows.Forms.CheckBox();
            this.lbRegional = new System.Windows.Forms.Label();
            this.lblSigla = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblPermiteInstr = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblPermiteEdicao = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdem)).BeginInit();
            this.pnlCargo.SuspendLayout();
            this.gpoDesenvolvimento.SuspendLayout();
            this.gpoAtendimento.SuspendLayout();
            this.gpoAtReg.SuspendLayout();
            this.gpoAtEspiritual.SuspendLayout();
            this.gpoAtCom.SuspendLayout();
            this.gpoAtMusical.SuspendLayout();
            this.gpoTeste.SuspendLayout();
            this.gpoPreTeste.SuspendLayout();
            this.gpoSexo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(442, 474);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipCCB.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.BtnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(537, 474);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipCCB.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // txtSigla
            // 
            this.txtSigla.BackColor = System.Drawing.SystemColors.Window;
            this.txtSigla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSigla.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtSigla.Location = new System.Drawing.Point(265, 12);
            this.txtSigla.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSigla.MaxLength = 2;
            this.txtSigla.Name = "txtSigla";
            this.txtSigla.Size = new System.Drawing.Size(50, 21);
            this.txtSigla.TabIndex = 110;
            this.tipCCB.SetToolTip(this.txtSigla, "Sigla");
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(92, 12);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(78, 21);
            this.txtCodigo.TabIndex = 106;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtCodigo, "Código");
            // 
            // cboDepartamento
            // 
            this.cboDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDepartamento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartamento.FormattingEnabled = true;
            this.cboDepartamento.Location = new System.Drawing.Point(92, 67);
            this.cboDepartamento.Name = "cboDepartamento";
            this.cboDepartamento.Size = new System.Drawing.Size(211, 21);
            this.cboDepartamento.TabIndex = 127;
            this.tipCCB.SetToolTip(this.cboDepartamento, "Departamento");
            // 
            // txtOrdem
            // 
            this.txtOrdem.BackColor = System.Drawing.Color.White;
            this.txtOrdem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrdem.Location = new System.Drawing.Point(406, 12);
            this.txtOrdem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtOrdem.Name = "txtOrdem";
            this.txtOrdem.Size = new System.Drawing.Size(58, 21);
            this.txtOrdem.TabIndex = 126;
            this.txtOrdem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipCCB.SetToolTip(this.txtOrdem, "Ordem na listagem");
            this.txtOrdem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(92, 40);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(372, 21);
            this.txtDescricao.TabIndex = 108;
            this.tipCCB.SetToolTip(this.txtDescricao, "Descrição do Cargo");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // pnlCargo
            // 
            this.pnlCargo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCargo.Controls.Add(this.gpoDesenvolvimento);
            this.pnlCargo.Controls.Add(this.chkPermiteInstr);
            this.pnlCargo.Controls.Add(this.gpoAtendimento);
            this.pnlCargo.Controls.Add(this.cboDepartamento);
            this.pnlCargo.Controls.Add(this.txtOrdem);
            this.pnlCargo.Controls.Add(this.lblOrdem);
            this.pnlCargo.Controls.Add(this.gpoSexo);
            this.pnlCargo.Controls.Add(this.lbRegional);
            this.pnlCargo.Controls.Add(this.txtSigla);
            this.pnlCargo.Controls.Add(this.lblSigla);
            this.pnlCargo.Controls.Add(this.txtDescricao);
            this.pnlCargo.Controls.Add(this.lblDescricao);
            this.pnlCargo.Controls.Add(this.txtCodigo);
            this.pnlCargo.Controls.Add(this.lblPermiteInstr);
            this.pnlCargo.Controls.Add(this.lblCodigo);
            this.pnlCargo.Location = new System.Drawing.Point(9, 9);
            this.pnlCargo.Name = "pnlCargo";
            this.pnlCargo.Size = new System.Drawing.Size(618, 458);
            this.pnlCargo.TabIndex = 5;
            // 
            // gpoDesenvolvimento
            // 
            this.gpoDesenvolvimento.Controls.Add(this.chkOficial);
            this.gpoDesenvolvimento.Controls.Add(this.chkCulto);
            this.gpoDesenvolvimento.Controls.Add(this.chkRjm);
            this.gpoDesenvolvimento.Controls.Add(this.chkMeiaHora);
            this.gpoDesenvolvimento.Controls.Add(this.chkEnsaio);
            this.gpoDesenvolvimento.Controls.Add(this.chkAlunoGem);
            this.gpoDesenvolvimento.Enabled = false;
            this.gpoDesenvolvimento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoDesenvolvimento.Location = new System.Drawing.Point(11, 396);
            this.gpoDesenvolvimento.Name = "gpoDesenvolvimento";
            this.gpoDesenvolvimento.Size = new System.Drawing.Size(592, 44);
            this.gpoDesenvolvimento.TabIndex = 129;
            this.gpoDesenvolvimento.TabStop = false;
            this.gpoDesenvolvimento.Text = "Permite participar de quais serviços (Desenvolvimento Musical)";
            // 
            // chkOficial
            // 
            this.chkOficial.AutoSize = true;
            this.chkOficial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOficial.Location = new System.Drawing.Point(500, 18);
            this.chkOficial.Name = "chkOficial";
            this.chkOficial.Size = new System.Drawing.Size(80, 17);
            this.chkOficial.TabIndex = 36;
            this.chkOficial.Text = "Oficializado";
            this.chkOficial.UseVisualStyleBackColor = true;
            this.chkOficial.CheckedChanged += new System.EventHandler(this.ChkOficial_CheckedChanged);
            // 
            // chkCulto
            // 
            this.chkCulto.AutoSize = true;
            this.chkCulto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCulto.Location = new System.Drawing.Point(400, 18);
            this.chkCulto.Name = "chkCulto";
            this.chkCulto.Size = new System.Drawing.Size(83, 17);
            this.chkCulto.TabIndex = 35;
            this.chkCulto.Text = "Culto Oficial";
            this.chkCulto.UseVisualStyleBackColor = true;
            this.chkCulto.CheckedChanged += new System.EventHandler(this.ChkCulto_CheckedChanged);
            // 
            // chkRjm
            // 
            this.chkRjm.AutoSize = true;
            this.chkRjm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkRjm.Location = new System.Drawing.Point(267, 18);
            this.chkRjm.Name = "chkRjm";
            this.chkRjm.Size = new System.Drawing.Size(117, 17);
            this.chkRjm.TabIndex = 34;
            this.chkRjm.Text = "Reunião de Jovens";
            this.chkRjm.UseVisualStyleBackColor = true;
            this.chkRjm.CheckedChanged += new System.EventHandler(this.ChkRjm_CheckedChanged);
            // 
            // chkMeiaHora
            // 
            this.chkMeiaHora.AutoSize = true;
            this.chkMeiaHora.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMeiaHora.Location = new System.Drawing.Point(179, 18);
            this.chkMeiaHora.Name = "chkMeiaHora";
            this.chkMeiaHora.Size = new System.Drawing.Size(74, 17);
            this.chkMeiaHora.TabIndex = 33;
            this.chkMeiaHora.Text = "Meia Hora";
            this.chkMeiaHora.UseVisualStyleBackColor = true;
            this.chkMeiaHora.CheckedChanged += new System.EventHandler(this.ChkMeiaHora_CheckedChanged);
            // 
            // chkEnsaio
            // 
            this.chkEnsaio.AutoSize = true;
            this.chkEnsaio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkEnsaio.Location = new System.Drawing.Point(102, 18);
            this.chkEnsaio.Name = "chkEnsaio";
            this.chkEnsaio.Size = new System.Drawing.Size(62, 17);
            this.chkEnsaio.TabIndex = 32;
            this.chkEnsaio.Text = "Ensaios";
            this.chkEnsaio.UseVisualStyleBackColor = true;
            this.chkEnsaio.CheckedChanged += new System.EventHandler(this.ChkEnsaio_CheckedChanged);
            // 
            // chkAlunoGem
            // 
            this.chkAlunoGem.AutoSize = true;
            this.chkAlunoGem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAlunoGem.Location = new System.Drawing.Point(11, 18);
            this.chkAlunoGem.Name = "chkAlunoGem";
            this.chkAlunoGem.Size = new System.Drawing.Size(77, 17);
            this.chkAlunoGem.TabIndex = 31;
            this.chkAlunoGem.Text = "Aluno GEM";
            this.chkAlunoGem.UseVisualStyleBackColor = true;
            this.chkAlunoGem.CheckedChanged += new System.EventHandler(this.ChkAlunoGem_CheckedChanged);
            // 
            // chkPermiteInstr
            // 
            this.chkPermiteInstr.AutoSize = true;
            this.chkPermiteInstr.Location = new System.Drawing.Point(334, 69);
            this.chkPermiteInstr.Name = "chkPermiteInstr";
            this.chkPermiteInstr.Size = new System.Drawing.Size(275, 17);
            this.chkPermiteInstr.TabIndex = 130;
            this.chkPermiteInstr.Text = "É um ministério que permite participar da orquestra?";
            this.chkPermiteInstr.UseVisualStyleBackColor = true;
            this.chkPermiteInstr.CheckedChanged += new System.EventHandler(this.ChkPermiteInstr_CheckedChanged);
            // 
            // gpoAtendimento
            // 
            this.gpoAtendimento.Controls.Add(this.gpoAtReg);
            this.gpoAtendimento.Controls.Add(this.gpoAtEspiritual);
            this.gpoAtendimento.Controls.Add(this.gpoAtCom);
            this.gpoAtendimento.Controls.Add(this.gpoAtMusical);
            this.gpoAtendimento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoAtendimento.Location = new System.Drawing.Point(11, 92);
            this.gpoAtendimento.Name = "gpoAtendimento";
            this.gpoAtendimento.Size = new System.Drawing.Size(592, 301);
            this.gpoAtendimento.TabIndex = 129;
            this.gpoAtendimento.TabStop = false;
            this.gpoAtendimento.Text = "Atendimento";
            // 
            // gpoAtReg
            // 
            this.gpoAtReg.Controls.Add(this.optAtRegNao);
            this.gpoAtReg.Controls.Add(this.optAtRegSim);
            this.gpoAtReg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoAtReg.Location = new System.Drawing.Point(13, 64);
            this.gpoAtReg.Name = "gpoAtReg";
            this.gpoAtReg.Size = new System.Drawing.Size(106, 45);
            this.gpoAtReg.TabIndex = 121;
            this.gpoAtReg.TabStop = false;
            this.gpoAtReg.Text = "Atende Região?";
            // 
            // optAtRegNao
            // 
            this.optAtRegNao.AutoSize = true;
            this.optAtRegNao.Checked = true;
            this.optAtRegNao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAtRegNao.Location = new System.Drawing.Point(53, 15);
            this.optAtRegNao.Name = "optAtRegNao";
            this.optAtRegNao.Size = new System.Drawing.Size(44, 17);
            this.optAtRegNao.TabIndex = 1;
            this.optAtRegNao.TabStop = true;
            this.optAtRegNao.Text = "Não";
            this.optAtRegNao.UseVisualStyleBackColor = true;
            this.optAtRegNao.CheckedChanged += new System.EventHandler(this.OptAtRegNao_CheckedChanged);
            // 
            // optAtRegSim
            // 
            this.optAtRegSim.AutoSize = true;
            this.optAtRegSim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAtRegSim.Location = new System.Drawing.Point(10, 15);
            this.optAtRegSim.Name = "optAtRegSim";
            this.optAtRegSim.Size = new System.Drawing.Size(41, 17);
            this.optAtRegSim.TabIndex = 0;
            this.optAtRegSim.Text = "Sim";
            this.optAtRegSim.UseVisualStyleBackColor = true;
            this.optAtRegSim.CheckedChanged += new System.EventHandler(this.OptAtRegSim_CheckedChanged);
            // 
            // gpoAtEspiritual
            // 
            this.gpoAtEspiritual.Controls.Add(this.chkAtOrdenacao);
            this.gpoAtEspiritual.Controls.Add(this.chkAtCasal);
            this.gpoAtEspiritual.Controls.Add(this.chkAtRjm);
            this.gpoAtEspiritual.Controls.Add(this.chkAtReunMin);
            this.gpoAtEspiritual.Controls.Add(this.chkAtReunMoc);
            this.gpoAtEspiritual.Controls.Add(this.chkAtCeia);
            this.gpoAtEspiritual.Controls.Add(this.chkAtBatismo);
            this.gpoAtEspiritual.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoAtEspiritual.Location = new System.Drawing.Point(142, 15);
            this.gpoAtEspiritual.Name = "gpoAtEspiritual";
            this.gpoAtEspiritual.Size = new System.Drawing.Size(436, 94);
            this.gpoAtEspiritual.TabIndex = 123;
            this.gpoAtEspiritual.TabStop = false;
            this.gpoAtEspiritual.Text = "Permite atendimento aos serviços ministerial";
            // 
            // chkAtOrdenacao
            // 
            this.chkAtOrdenacao.AutoSize = true;
            this.chkAtOrdenacao.Enabled = false;
            this.chkAtOrdenacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtOrdenacao.Location = new System.Drawing.Point(245, 36);
            this.chkAtOrdenacao.Name = "chkAtOrdenacao";
            this.chkAtOrdenacao.Size = new System.Drawing.Size(79, 17);
            this.chkAtOrdenacao.TabIndex = 36;
            this.chkAtOrdenacao.Text = "Ordenação";
            this.chkAtOrdenacao.UseVisualStyleBackColor = true;
            this.chkAtOrdenacao.CheckedChanged += new System.EventHandler(this.ChkAtOrdenacao_CheckedChanged);
            // 
            // chkAtCasal
            // 
            this.chkAtCasal.AutoSize = true;
            this.chkAtCasal.Enabled = false;
            this.chkAtCasal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtCasal.Location = new System.Drawing.Point(18, 70);
            this.chkAtCasal.Name = "chkAtCasal";
            this.chkAtCasal.Size = new System.Drawing.Size(179, 17);
            this.chkAtCasal.TabIndex = 35;
            this.chkAtCasal.Text = "Reunião para Casais (Conselho)";
            this.chkAtCasal.UseVisualStyleBackColor = true;
            this.chkAtCasal.CheckedChanged += new System.EventHandler(this.ChkAtCasal_CheckedChanged);
            // 
            // chkAtRjm
            // 
            this.chkAtRjm.AutoSize = true;
            this.chkAtRjm.Enabled = false;
            this.chkAtRjm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtRjm.Location = new System.Drawing.Point(18, 53);
            this.chkAtRjm.Name = "chkAtRjm";
            this.chkAtRjm.Size = new System.Drawing.Size(182, 17);
            this.chkAtRjm.TabIndex = 34;
            this.chkAtRjm.Text = "Reunião para Jovens (Conselho)";
            this.chkAtRjm.UseVisualStyleBackColor = true;
            this.chkAtRjm.CheckedChanged += new System.EventHandler(this.ChkAtRjm_CheckedChanged);
            // 
            // chkAtReunMin
            // 
            this.chkAtReunMin.AutoSize = true;
            this.chkAtReunMin.Enabled = false;
            this.chkAtReunMin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtReunMin.Location = new System.Drawing.Point(18, 36);
            this.chkAtReunMin.Name = "chkAtReunMin";
            this.chkAtReunMin.Size = new System.Drawing.Size(115, 17);
            this.chkAtReunMin.TabIndex = 33;
            this.chkAtReunMin.Text = "Reunião Ministerial";
            this.chkAtReunMin.UseVisualStyleBackColor = true;
            this.chkAtReunMin.CheckedChanged += new System.EventHandler(this.ChkAtReunMin_CheckedChanged);
            // 
            // chkAtReunMoc
            // 
            this.chkAtReunMoc.AutoSize = true;
            this.chkAtReunMoc.Enabled = false;
            this.chkAtReunMoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtReunMoc.Location = new System.Drawing.Point(245, 53);
            this.chkAtReunMoc.Name = "chkAtReunMoc";
            this.chkAtReunMoc.Size = new System.Drawing.Size(138, 17);
            this.chkAtReunMoc.TabIndex = 32;
            this.chkAtReunMoc.Text = "Reunião para Mocidade";
            this.chkAtReunMoc.UseVisualStyleBackColor = true;
            this.chkAtReunMoc.CheckedChanged += new System.EventHandler(this.ChkAtReunMoc_CheckedChanged);
            // 
            // chkAtCeia
            // 
            this.chkAtCeia.AutoSize = true;
            this.chkAtCeia.Enabled = false;
            this.chkAtCeia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtCeia.Location = new System.Drawing.Point(245, 19);
            this.chkAtCeia.Name = "chkAtCeia";
            this.chkAtCeia.Size = new System.Drawing.Size(78, 17);
            this.chkAtCeia.TabIndex = 31;
            this.chkAtCeia.Text = "Santa Ceia";
            this.chkAtCeia.UseVisualStyleBackColor = true;
            this.chkAtCeia.CheckedChanged += new System.EventHandler(this.ChkAtCeia_CheckedChanged);
            // 
            // chkAtBatismo
            // 
            this.chkAtBatismo.AutoSize = true;
            this.chkAtBatismo.Enabled = false;
            this.chkAtBatismo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtBatismo.Location = new System.Drawing.Point(18, 19);
            this.chkAtBatismo.Name = "chkAtBatismo";
            this.chkAtBatismo.Size = new System.Drawing.Size(63, 17);
            this.chkAtBatismo.TabIndex = 30;
            this.chkAtBatismo.Text = "Batismo";
            this.chkAtBatismo.UseVisualStyleBackColor = true;
            this.chkAtBatismo.CheckedChanged += new System.EventHandler(this.ChkAtBatismo_CheckedChanged);
            // 
            // gpoAtCom
            // 
            this.gpoAtCom.Controls.Add(this.optAtComNao);
            this.gpoAtCom.Controls.Add(this.optAtComSim);
            this.gpoAtCom.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoAtCom.Location = new System.Drawing.Point(14, 15);
            this.gpoAtCom.Name = "gpoAtCom";
            this.gpoAtCom.Size = new System.Drawing.Size(106, 45);
            this.gpoAtCom.TabIndex = 128;
            this.gpoAtCom.TabStop = false;
            this.gpoAtCom.Text = "Atende Comum?";
            // 
            // optAtComNao
            // 
            this.optAtComNao.AutoSize = true;
            this.optAtComNao.Checked = true;
            this.optAtComNao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAtComNao.Location = new System.Drawing.Point(53, 16);
            this.optAtComNao.Name = "optAtComNao";
            this.optAtComNao.Size = new System.Drawing.Size(44, 17);
            this.optAtComNao.TabIndex = 1;
            this.optAtComNao.TabStop = true;
            this.optAtComNao.Text = "Não";
            this.optAtComNao.UseVisualStyleBackColor = true;
            this.optAtComNao.CheckedChanged += new System.EventHandler(this.OptAtComNao_CheckedChanged);
            // 
            // optAtComSim
            // 
            this.optAtComSim.AutoSize = true;
            this.optAtComSim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAtComSim.Location = new System.Drawing.Point(10, 16);
            this.optAtComSim.Name = "optAtComSim";
            this.optAtComSim.Size = new System.Drawing.Size(41, 17);
            this.optAtComSim.TabIndex = 0;
            this.optAtComSim.Text = "Sim";
            this.optAtComSim.UseVisualStyleBackColor = true;
            this.optAtComSim.CheckedChanged += new System.EventHandler(this.OptAtComSim_CheckedChanged);
            // 
            // gpoAtMusical
            // 
            this.gpoAtMusical.Controls.Add(this.chkAtEnsTec);
            this.gpoAtMusical.Controls.Add(this.chkAtEnsParc);
            this.gpoAtMusical.Controls.Add(this.chkAtEnsReg);
            this.gpoAtMusical.Controls.Add(this.chkAtEnsLoc);
            this.gpoAtMusical.Controls.Add(this.chkAtGem);
            this.gpoAtMusical.Controls.Add(this.gpoTeste);
            this.gpoAtMusical.Controls.Add(this.gpoPreTeste);
            this.gpoAtMusical.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoAtMusical.Location = new System.Drawing.Point(13, 111);
            this.gpoAtMusical.Name = "gpoAtMusical";
            this.gpoAtMusical.Size = new System.Drawing.Size(565, 182);
            this.gpoAtMusical.TabIndex = 122;
            this.gpoAtMusical.TabStop = false;
            this.gpoAtMusical.Text = "Permite atendimento aos serviços da parte musical";
            // 
            // chkAtEnsTec
            // 
            this.chkAtEnsTec.AutoSize = true;
            this.chkAtEnsTec.Enabled = false;
            this.chkAtEnsTec.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtEnsTec.Location = new System.Drawing.Point(188, 36);
            this.chkAtEnsTec.Name = "chkAtEnsTec";
            this.chkAtEnsTec.Size = new System.Drawing.Size(96, 17);
            this.chkAtEnsTec.TabIndex = 33;
            this.chkAtEnsTec.Text = "Ensaio Técnico";
            this.chkAtEnsTec.UseVisualStyleBackColor = true;
            this.chkAtEnsTec.CheckedChanged += new System.EventHandler(this.ChkAtEnsTec_CheckedChanged);
            // 
            // chkAtEnsParc
            // 
            this.chkAtEnsParc.AutoSize = true;
            this.chkAtEnsParc.Enabled = false;
            this.chkAtEnsParc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtEnsParc.Location = new System.Drawing.Point(18, 36);
            this.chkAtEnsParc.Name = "chkAtEnsParc";
            this.chkAtEnsParc.Size = new System.Drawing.Size(91, 17);
            this.chkAtEnsParc.TabIndex = 32;
            this.chkAtEnsParc.Text = "Ensaio Parcial";
            this.chkAtEnsParc.UseVisualStyleBackColor = true;
            this.chkAtEnsParc.CheckedChanged += new System.EventHandler(this.ChkAtEnsParc_CheckedChanged);
            // 
            // chkAtEnsReg
            // 
            this.chkAtEnsReg.AutoSize = true;
            this.chkAtEnsReg.Enabled = false;
            this.chkAtEnsReg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtEnsReg.Location = new System.Drawing.Point(373, 19);
            this.chkAtEnsReg.Name = "chkAtEnsReg";
            this.chkAtEnsReg.Size = new System.Drawing.Size(101, 17);
            this.chkAtEnsReg.TabIndex = 31;
            this.chkAtEnsReg.Text = "Ensaio Regional";
            this.chkAtEnsReg.UseVisualStyleBackColor = true;
            this.chkAtEnsReg.CheckedChanged += new System.EventHandler(this.ChkAtEnsReg_CheckedChanged);
            // 
            // chkAtEnsLoc
            // 
            this.chkAtEnsLoc.AutoSize = true;
            this.chkAtEnsLoc.Enabled = false;
            this.chkAtEnsLoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtEnsLoc.Location = new System.Drawing.Point(188, 19);
            this.chkAtEnsLoc.Name = "chkAtEnsLoc";
            this.chkAtEnsLoc.Size = new System.Drawing.Size(84, 17);
            this.chkAtEnsLoc.TabIndex = 30;
            this.chkAtEnsLoc.Text = "Ensaio Local";
            this.chkAtEnsLoc.UseVisualStyleBackColor = true;
            this.chkAtEnsLoc.CheckedChanged += new System.EventHandler(this.ChkAtEnsLoc_CheckedChanged);
            // 
            // chkAtGem
            // 
            this.chkAtGem.AutoSize = true;
            this.chkAtGem.Enabled = false;
            this.chkAtGem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkAtGem.Location = new System.Drawing.Point(18, 19);
            this.chkAtGem.Name = "chkAtGem";
            this.chkAtGem.Size = new System.Drawing.Size(47, 17);
            this.chkAtGem.TabIndex = 29;
            this.chkAtGem.Text = "GEM";
            this.chkAtGem.UseVisualStyleBackColor = true;
            this.chkAtGem.CheckedChanged += new System.EventHandler(this.ChkAtGem_CheckedChanged);
            // 
            // gpoTeste
            // 
            this.gpoTeste.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpoTeste.Controls.Add(this.chkTesOficialMus);
            this.gpoTeste.Controls.Add(this.chkTesCultoOrg);
            this.gpoTeste.Controls.Add(this.chkTesCultoMus);
            this.gpoTeste.Controls.Add(this.chkTesRjmOrg);
            this.gpoTeste.Controls.Add(this.chkTesRjmMus);
            this.gpoTeste.Controls.Add(this.chkTesOficialOrg);
            this.gpoTeste.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoTeste.Location = new System.Drawing.Point(8, 116);
            this.gpoTeste.Name = "gpoTeste";
            this.gpoTeste.Size = new System.Drawing.Size(550, 58);
            this.gpoTeste.TabIndex = 28;
            this.gpoTeste.TabStop = false;
            this.gpoTeste.Text = "Testes (Exames)";
            // 
            // chkTesOficialMus
            // 
            this.chkTesOficialMus.AutoSize = true;
            this.chkTesOficialMus.Enabled = false;
            this.chkTesOficialMus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTesOficialMus.Location = new System.Drawing.Point(364, 18);
            this.chkTesOficialMus.Name = "chkTesOficialMus";
            this.chkTesOficialMus.Size = new System.Drawing.Size(128, 17);
            this.chkTesOficialMus.TabIndex = 7;
            this.chkTesOficialMus.Text = "Oficialização (Músico)";
            this.chkTesOficialMus.UseVisualStyleBackColor = true;
            this.chkTesOficialMus.CheckedChanged += new System.EventHandler(this.ChkTesOficialMus_CheckedChanged);
            // 
            // chkTesCultoOrg
            // 
            this.chkTesCultoOrg.AutoSize = true;
            this.chkTesCultoOrg.Enabled = false;
            this.chkTesCultoOrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTesCultoOrg.Location = new System.Drawing.Point(177, 35);
            this.chkTesCultoOrg.Name = "chkTesCultoOrg";
            this.chkTesCultoOrg.Size = new System.Drawing.Size(141, 17);
            this.chkTesCultoOrg.TabIndex = 6;
            this.chkTesCultoOrg.Text = "Culto Oficial (Organista)";
            this.chkTesCultoOrg.UseVisualStyleBackColor = true;
            this.chkTesCultoOrg.CheckedChanged += new System.EventHandler(this.ChkTesCultoOrg_CheckedChanged);
            // 
            // chkTesCultoMus
            // 
            this.chkTesCultoMus.AutoSize = true;
            this.chkTesCultoMus.Enabled = false;
            this.chkTesCultoMus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTesCultoMus.Location = new System.Drawing.Point(177, 18);
            this.chkTesCultoMus.Name = "chkTesCultoMus";
            this.chkTesCultoMus.Size = new System.Drawing.Size(126, 17);
            this.chkTesCultoMus.TabIndex = 5;
            this.chkTesCultoMus.Text = "Culto Oficial (Músico)";
            this.chkTesCultoMus.UseVisualStyleBackColor = true;
            this.chkTesCultoMus.CheckedChanged += new System.EventHandler(this.ChkTesCultoMus_CheckedChanged);
            // 
            // chkTesRjmOrg
            // 
            this.chkTesRjmOrg.AutoSize = true;
            this.chkTesRjmOrg.Enabled = false;
            this.chkTesRjmOrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTesRjmOrg.Location = new System.Drawing.Point(8, 35);
            this.chkTesRjmOrg.Name = "chkTesRjmOrg";
            this.chkTesRjmOrg.Size = new System.Drawing.Size(164, 17);
            this.chkTesRjmOrg.TabIndex = 4;
            this.chkTesRjmOrg.Text = "RJM e Meia Hora (Organista)";
            this.chkTesRjmOrg.UseVisualStyleBackColor = true;
            this.chkTesRjmOrg.CheckedChanged += new System.EventHandler(this.ChkTesRjmOrg_CheckedChanged);
            // 
            // chkTesRjmMus
            // 
            this.chkTesRjmMus.AutoSize = true;
            this.chkTesRjmMus.Enabled = false;
            this.chkTesRjmMus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTesRjmMus.Location = new System.Drawing.Point(8, 18);
            this.chkTesRjmMus.Name = "chkTesRjmMus";
            this.chkTesRjmMus.Size = new System.Drawing.Size(89, 17);
            this.chkTesRjmMus.TabIndex = 3;
            this.chkTesRjmMus.Text = "RJM (Músico)";
            this.chkTesRjmMus.UseVisualStyleBackColor = true;
            this.chkTesRjmMus.CheckedChanged += new System.EventHandler(this.ChkTesRjmMus_CheckedChanged);
            // 
            // chkTesOficialOrg
            // 
            this.chkTesOficialOrg.AutoSize = true;
            this.chkTesOficialOrg.Enabled = false;
            this.chkTesOficialOrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTesOficialOrg.Location = new System.Drawing.Point(364, 35);
            this.chkTesOficialOrg.Name = "chkTesOficialOrg";
            this.chkTesOficialOrg.Size = new System.Drawing.Size(143, 17);
            this.chkTesOficialOrg.TabIndex = 8;
            this.chkTesOficialOrg.Text = "Oficialização (Organista)";
            this.chkTesOficialOrg.UseVisualStyleBackColor = true;
            this.chkTesOficialOrg.CheckedChanged += new System.EventHandler(this.ChkTesOficialOrg_CheckedChanged);
            // 
            // gpoPreTeste
            // 
            this.gpoPreTeste.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gpoPreTeste.Controls.Add(this.chkPreOficialMus);
            this.gpoPreTeste.Controls.Add(this.chkPreCultoOrg);
            this.gpoPreTeste.Controls.Add(this.chkPreCultoMus);
            this.gpoPreTeste.Controls.Add(this.chkPreRjmOrg);
            this.gpoPreTeste.Controls.Add(this.chkPreRjmMus);
            this.gpoPreTeste.Controls.Add(this.chkPreOficialOrg);
            this.gpoPreTeste.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoPreTeste.Location = new System.Drawing.Point(8, 57);
            this.gpoPreTeste.Name = "gpoPreTeste";
            this.gpoPreTeste.Size = new System.Drawing.Size(550, 58);
            this.gpoPreTeste.TabIndex = 27;
            this.gpoPreTeste.TabStop = false;
            this.gpoPreTeste.Text = "Pré-Testes";
            // 
            // chkPreOficialMus
            // 
            this.chkPreOficialMus.AutoSize = true;
            this.chkPreOficialMus.Enabled = false;
            this.chkPreOficialMus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPreOficialMus.Location = new System.Drawing.Point(365, 17);
            this.chkPreOficialMus.Name = "chkPreOficialMus";
            this.chkPreOficialMus.Size = new System.Drawing.Size(128, 17);
            this.chkPreOficialMus.TabIndex = 7;
            this.chkPreOficialMus.Text = "Oficialização (Músico)";
            this.chkPreOficialMus.UseVisualStyleBackColor = true;
            this.chkPreOficialMus.CheckedChanged += new System.EventHandler(this.ChkPreOficialMus_CheckedChanged);
            // 
            // chkPreCultoOrg
            // 
            this.chkPreCultoOrg.AutoSize = true;
            this.chkPreCultoOrg.Enabled = false;
            this.chkPreCultoOrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPreCultoOrg.Location = new System.Drawing.Point(178, 34);
            this.chkPreCultoOrg.Name = "chkPreCultoOrg";
            this.chkPreCultoOrg.Size = new System.Drawing.Size(141, 17);
            this.chkPreCultoOrg.TabIndex = 6;
            this.chkPreCultoOrg.Text = "Culto Oficial (Organista)";
            this.chkPreCultoOrg.UseVisualStyleBackColor = true;
            this.chkPreCultoOrg.CheckedChanged += new System.EventHandler(this.ChkPreCultoOrg_CheckedChanged);
            // 
            // chkPreCultoMus
            // 
            this.chkPreCultoMus.AutoSize = true;
            this.chkPreCultoMus.Enabled = false;
            this.chkPreCultoMus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPreCultoMus.Location = new System.Drawing.Point(178, 17);
            this.chkPreCultoMus.Name = "chkPreCultoMus";
            this.chkPreCultoMus.Size = new System.Drawing.Size(126, 17);
            this.chkPreCultoMus.TabIndex = 5;
            this.chkPreCultoMus.Text = "Culto Oficial (Músico)";
            this.chkPreCultoMus.UseVisualStyleBackColor = true;
            this.chkPreCultoMus.CheckedChanged += new System.EventHandler(this.ChkPreCultoMus_CheckedChanged);
            // 
            // chkPreRjmOrg
            // 
            this.chkPreRjmOrg.AutoSize = true;
            this.chkPreRjmOrg.Enabled = false;
            this.chkPreRjmOrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPreRjmOrg.Location = new System.Drawing.Point(8, 34);
            this.chkPreRjmOrg.Name = "chkPreRjmOrg";
            this.chkPreRjmOrg.Size = new System.Drawing.Size(164, 17);
            this.chkPreRjmOrg.TabIndex = 4;
            this.chkPreRjmOrg.Text = "RJM e Meia Hora (Organista)";
            this.chkPreRjmOrg.UseVisualStyleBackColor = true;
            this.chkPreRjmOrg.CheckedChanged += new System.EventHandler(this.ChkPreRjmOrg_CheckedChanged);
            // 
            // chkPreRjmMus
            // 
            this.chkPreRjmMus.AutoSize = true;
            this.chkPreRjmMus.Enabled = false;
            this.chkPreRjmMus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPreRjmMus.Location = new System.Drawing.Point(8, 17);
            this.chkPreRjmMus.Name = "chkPreRjmMus";
            this.chkPreRjmMus.Size = new System.Drawing.Size(89, 17);
            this.chkPreRjmMus.TabIndex = 3;
            this.chkPreRjmMus.Text = "RJM (Músico)";
            this.chkPreRjmMus.UseVisualStyleBackColor = true;
            this.chkPreRjmMus.CheckedChanged += new System.EventHandler(this.ChkPreRjmMus_CheckedChanged);
            // 
            // chkPreOficialOrg
            // 
            this.chkPreOficialOrg.AutoSize = true;
            this.chkPreOficialOrg.Enabled = false;
            this.chkPreOficialOrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkPreOficialOrg.Location = new System.Drawing.Point(365, 34);
            this.chkPreOficialOrg.Name = "chkPreOficialOrg";
            this.chkPreOficialOrg.Size = new System.Drawing.Size(143, 17);
            this.chkPreOficialOrg.TabIndex = 8;
            this.chkPreOficialOrg.Text = "Oficialização (Organista)";
            this.chkPreOficialOrg.UseVisualStyleBackColor = true;
            this.chkPreOficialOrg.CheckedChanged += new System.EventHandler(this.ChkPreOficialOrg_CheckedChanged);
            // 
            // lblOrdem
            // 
            this.lblOrdem.AutoSize = true;
            this.lblOrdem.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblOrdem.Location = new System.Drawing.Point(361, 16);
            this.lblOrdem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblOrdem.Name = "lblOrdem";
            this.lblOrdem.Size = new System.Drawing.Size(43, 13);
            this.lblOrdem.TabIndex = 125;
            this.lblOrdem.Text = "Ordem:";
            // 
            // gpoSexo
            // 
            this.gpoSexo.Controls.Add(this.chkFeminino);
            this.gpoSexo.Controls.Add(this.chkMasculino);
            this.gpoSexo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoSexo.Location = new System.Drawing.Point(485, 5);
            this.gpoSexo.Name = "gpoSexo";
            this.gpoSexo.Size = new System.Drawing.Size(121, 56);
            this.gpoSexo.TabIndex = 120;
            this.gpoSexo.TabStop = false;
            this.gpoSexo.Text = "Atendido por?";
            // 
            // chkFeminino
            // 
            this.chkFeminino.AutoSize = true;
            this.chkFeminino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkFeminino.Location = new System.Drawing.Point(23, 34);
            this.chkFeminino.Name = "chkFeminino";
            this.chkFeminino.Size = new System.Drawing.Size(53, 17);
            this.chkFeminino.TabIndex = 4;
            this.chkFeminino.Text = "Irmãs";
            this.chkFeminino.UseVisualStyleBackColor = true;
            this.chkFeminino.CheckedChanged += new System.EventHandler(this.ChkFeminino_CheckedChanged);
            // 
            // chkMasculino
            // 
            this.chkMasculino.AutoSize = true;
            this.chkMasculino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMasculino.Location = new System.Drawing.Point(23, 16);
            this.chkMasculino.Name = "chkMasculino";
            this.chkMasculino.Size = new System.Drawing.Size(59, 17);
            this.chkMasculino.TabIndex = 3;
            this.chkMasculino.Text = "Irmãos";
            this.chkMasculino.UseVisualStyleBackColor = true;
            this.chkMasculino.CheckedChanged += new System.EventHandler(this.ChkMasculino_CheckedChanged);
            // 
            // lbRegional
            // 
            this.lbRegional.AutoSize = true;
            this.lbRegional.Location = new System.Drawing.Point(7, 71);
            this.lbRegional.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRegional.Name = "lbRegional";
            this.lbRegional.Size = new System.Drawing.Size(80, 13);
            this.lbRegional.TabIndex = 116;
            this.lbRegional.Text = "Departamento:";
            // 
            // lblSigla
            // 
            this.lblSigla.AutoSize = true;
            this.lblSigla.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblSigla.Location = new System.Drawing.Point(195, 16);
            this.lblSigla.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblSigla.Name = "lblSigla";
            this.lblSigla.Size = new System.Drawing.Size(69, 13);
            this.lblSigla.TabIndex = 111;
            this.lblSigla.Text = "Sigla Abrev.:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(8, 44);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 109;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblPermiteInstr
            // 
            this.lblPermiteInstr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPermiteInstr.Location = new System.Drawing.Point(358, 80);
            this.lblPermiteInstr.Name = "lblPermiteInstr";
            this.lblPermiteInstr.Size = new System.Drawing.Size(46, 17);
            this.lblPermiteInstr.TabIndex = 37;
            this.lblPermiteInstr.Text = "Não";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(8, 16);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // lblPermiteEdicao
            // 
            this.lblPermiteEdicao.AutoSize = true;
            this.lblPermiteEdicao.Location = new System.Drawing.Point(12, 470);
            this.lblPermiteEdicao.Name = "lblPermiteEdicao";
            this.lblPermiteEdicao.Size = new System.Drawing.Size(23, 13);
            this.lblPermiteEdicao.TabIndex = 6;
            this.lblPermiteEdicao.Text = "Sim";
            // 
            // frmCargo
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(636, 511);
            this.Controls.Add(this.lblPermiteEdicao);
            this.Controls.Add(this.pnlCargo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCargo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargo";
            this.Activated += new System.EventHandler(this.FrmCargo_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCargo_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmCargo_FormClosed);
            this.Load += new System.EventHandler(this.FrmCargo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtOrdem)).EndInit();
            this.pnlCargo.ResumeLayout(false);
            this.pnlCargo.PerformLayout();
            this.gpoDesenvolvimento.ResumeLayout(false);
            this.gpoDesenvolvimento.PerformLayout();
            this.gpoAtendimento.ResumeLayout(false);
            this.gpoAtReg.ResumeLayout(false);
            this.gpoAtReg.PerformLayout();
            this.gpoAtEspiritual.ResumeLayout(false);
            this.gpoAtEspiritual.PerformLayout();
            this.gpoAtCom.ResumeLayout(false);
            this.gpoAtCom.PerformLayout();
            this.gpoAtMusical.ResumeLayout(false);
            this.gpoAtMusical.PerformLayout();
            this.gpoTeste.ResumeLayout(false);
            this.gpoTeste.PerformLayout();
            this.gpoPreTeste.ResumeLayout(false);
            this.gpoPreTeste.PerformLayout();
            this.gpoSexo.ResumeLayout(false);
            this.gpoSexo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipCCB;
        private System.Windows.Forms.Panel pnlCargo;
        private System.Windows.Forms.TextBox txtSigla;
        private System.Windows.Forms.Label lblSigla;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gpoAtEspiritual;
        private System.Windows.Forms.CheckBox chkAtOrdenacao;
        private System.Windows.Forms.CheckBox chkAtCasal;
        private System.Windows.Forms.CheckBox chkAtRjm;
        private System.Windows.Forms.CheckBox chkAtReunMin;
        private System.Windows.Forms.CheckBox chkAtReunMoc;
        private System.Windows.Forms.CheckBox chkAtCeia;
        private System.Windows.Forms.CheckBox chkAtBatismo;
        private System.Windows.Forms.GroupBox gpoAtMusical;
        private System.Windows.Forms.CheckBox chkAtEnsTec;
        private System.Windows.Forms.CheckBox chkAtEnsParc;
        private System.Windows.Forms.CheckBox chkAtEnsReg;
        private System.Windows.Forms.CheckBox chkAtEnsLoc;
        private System.Windows.Forms.CheckBox chkAtGem;
        private System.Windows.Forms.GroupBox gpoTeste;
        private System.Windows.Forms.CheckBox chkTesOficialMus;
        private System.Windows.Forms.CheckBox chkTesCultoOrg;
        private System.Windows.Forms.CheckBox chkTesCultoMus;
        private System.Windows.Forms.CheckBox chkTesRjmOrg;
        private System.Windows.Forms.CheckBox chkTesRjmMus;
        private System.Windows.Forms.CheckBox chkTesOficialOrg;
        private System.Windows.Forms.GroupBox gpoPreTeste;
        private System.Windows.Forms.CheckBox chkPreOficialMus;
        private System.Windows.Forms.CheckBox chkPreCultoOrg;
        private System.Windows.Forms.CheckBox chkPreCultoMus;
        private System.Windows.Forms.CheckBox chkPreRjmOrg;
        private System.Windows.Forms.CheckBox chkPreRjmMus;
        private System.Windows.Forms.CheckBox chkPreOficialOrg;
        private System.Windows.Forms.GroupBox gpoAtReg;
        private System.Windows.Forms.RadioButton optAtRegNao;
        private System.Windows.Forms.RadioButton optAtRegSim;
        private System.Windows.Forms.GroupBox gpoSexo;
        private BLL.validacoes.Controles.NumericUpDownPersonal txtOrdem;
        private System.Windows.Forms.Label lblOrdem;
        private BLL.validacoes.Controles.ComboBoxPersonal cboDepartamento;
        private System.Windows.Forms.Label lbRegional;
        private System.Windows.Forms.CheckBox chkFeminino;
        private System.Windows.Forms.CheckBox chkMasculino;
        private System.Windows.Forms.GroupBox gpoAtendimento;
        private System.Windows.Forms.GroupBox gpoAtCom;
        private System.Windows.Forms.RadioButton optAtComNao;
        private System.Windows.Forms.RadioButton optAtComSim;
        private System.Windows.Forms.Label lblPermiteEdicao;
        private System.Windows.Forms.CheckBox chkPermiteInstr;
        private System.Windows.Forms.GroupBox gpoDesenvolvimento;
        private System.Windows.Forms.CheckBox chkOficial;
        private System.Windows.Forms.CheckBox chkCulto;
        private System.Windows.Forms.CheckBox chkRjm;
        private System.Windows.Forms.CheckBox chkMeiaHora;
        private System.Windows.Forms.CheckBox chkEnsaio;
        private System.Windows.Forms.CheckBox chkAlunoGem;
        private System.Windows.Forms.Label lblPermiteInstr;
    }
}