namespace ccbadm
{
    partial class frmReunioes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReunioes));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipForm = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnListaPresenca = new System.Windows.Forms.Button();
            this.cboCapitulo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboBiblia = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtVersoInicio = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtAssunto = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtVersoFim = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHino = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlReunioes = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.txtObs = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblAssunto = new System.Windows.Forms.Label();
            this.lblObs = new System.Windows.Forms.Label();
            this.lblCapitulo = new System.Windows.Forms.Label();
            this.gpoAtendimento = new System.Windows.Forms.GroupBox();
            this.txtExamina = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtEncReg = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtAnciao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtInstrutor = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtEncLocal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCoop = new BLL.validacoes.Controles.TextBoxPersonal();
            this.chkInstrutor = new System.Windows.Forms.CheckBox();
            this.chkExamina = new System.Windows.Forms.CheckBox();
            this.lblInstrutor = new System.Windows.Forms.Label();
            this.lblExamina = new System.Windows.Forms.Label();
            this.btnInstrutor = new System.Windows.Forms.Button();
            this.btnExamina = new System.Windows.Forms.Button();
            this.btnEncLocal = new System.Windows.Forms.Button();
            this.btnEncReg = new System.Windows.Forms.Button();
            this.lblEncLocal = new System.Windows.Forms.Label();
            this.lblEncReg = new System.Windows.Forms.Label();
            this.chkEncLocal = new System.Windows.Forms.CheckBox();
            this.chkEncReg = new System.Windows.Forms.CheckBox();
            this.chkCoop = new System.Windows.Forms.CheckBox();
            this.lblCoop = new System.Windows.Forms.Label();
            this.chkAnciao = new System.Windows.Forms.CheckBox();
            this.lblAnciao = new System.Windows.Forms.Label();
            this.btnCoop = new System.Windows.Forms.Button();
            this.btnAnciao = new System.Windows.Forms.Button();
            this.lblAo = new System.Windows.Forms.Label();
            this.cboTipo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblVerso = new System.Windows.Forms.Label();
            this.txtUsuario = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblHino = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblComum = new System.Windows.Forms.Label();
            this.btnComum = new System.Windows.Forms.Button();
            this.txtCodCCB = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbComum = new System.Windows.Forms.Label();
            this.txtHoraInclusao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHoraReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataInclusao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataInclusao = new System.Windows.Forms.Label();
            this.txtDataReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDataReuniao = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblBiblia = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblCodUsuario = new System.Windows.Forms.Label();
            this.lblFinaliza = new System.Windows.Forms.Label();
            this.lblCancela = new System.Windows.Forms.Label();
            this.lblCodUsuarioFinaliza = new System.Windows.Forms.Label();
            this.lblCodUsuarioCancela = new System.Windows.Forms.Label();
            this.txtHoraCancela = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataCancela = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHoraFinaliza = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataFinaliza = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlReunioes.SuspendLayout();
            this.gpoAtendimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalvar.Location = new System.Drawing.Point(466, 360);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 38;
            this.btnSalvar.Text = "&Salvar";
            this.tipForm.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(561, 360);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 39;
            this.btnCancelar.Text = "&Cancelar";
            this.tipForm.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(75, 9);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(45, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipForm.SetToolTip(this.txtCodigo, "Código");
            // 
            // btnListaPresenca
            // 
            this.btnListaPresenca.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnListaPresenca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnListaPresenca.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnListaPresenca.Image = global::ccbadm.Properties.Resources.listagem;
            this.btnListaPresenca.Location = new System.Drawing.Point(8, 360);
            this.btnListaPresenca.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnListaPresenca.Name = "btnListaPresenca";
            this.btnListaPresenca.Size = new System.Drawing.Size(125, 35);
            this.btnListaPresenca.TabIndex = 37;
            this.btnListaPresenca.Text = " &Lista Presença";
            this.btnListaPresenca.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipForm.SetToolTip(this.btnListaPresenca, "Incluir irmãos e irmãs que participaram da reunião");
            this.btnListaPresenca.UseVisualStyleBackColor = false;
            this.btnListaPresenca.Click += new System.EventHandler(this.btnListaPresenca_Click);
            // 
            // cboCapitulo
            // 
            this.cboCapitulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCapitulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCapitulo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCapitulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCapitulo.Enabled = false;
            this.cboCapitulo.ForeColor = System.Drawing.Color.Black;
            this.cboCapitulo.FormattingEnabled = true;
            this.cboCapitulo.Location = new System.Drawing.Point(443, 198);
            this.cboCapitulo.Name = "cboCapitulo";
            this.cboCapitulo.Size = new System.Drawing.Size(48, 21);
            this.cboCapitulo.TabIndex = 32;
            this.tipForm.SetToolTip(this.cboCapitulo, "Selecione o capítulo");
            // 
            // cboBiblia
            // 
            this.cboBiblia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboBiblia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboBiblia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboBiblia.DropDownHeight = 80;
            this.cboBiblia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBiblia.ForeColor = System.Drawing.Color.Black;
            this.cboBiblia.FormattingEnabled = true;
            this.cboBiblia.IntegralHeight = false;
            this.cboBiblia.Location = new System.Drawing.Point(210, 198);
            this.cboBiblia.Name = "cboBiblia";
            this.cboBiblia.Size = new System.Drawing.Size(174, 21);
            this.cboBiblia.TabIndex = 31;
            this.tipForm.SetToolTip(this.cboBiblia, "Selecione o livro");
            this.cboBiblia.SelectedIndexChanged += new System.EventHandler(this.cboBiblia_SelectedIndexChanged);
            // 
            // txtVersoInicio
            // 
            this.txtVersoInicio.BackColor = System.Drawing.Color.LightGray;
            this.txtVersoInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersoInicio.Enabled = false;
            this.txtVersoInicio.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtVersoInicio.Location = new System.Drawing.Point(540, 198);
            this.txtVersoInicio.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtVersoInicio.Name = "txtVersoInicio";
            this.txtVersoInicio.Size = new System.Drawing.Size(30, 21);
            this.txtVersoInicio.TabIndex = 33;
            this.txtVersoInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipForm.SetToolTip(this.txtVersoInicio, "Iniciou a leitura no verso");
            this.txtVersoInicio.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // txtAssunto
            // 
            this.txtAssunto.AcceptsReturn = true;
            this.txtAssunto.BackColor = System.Drawing.Color.White;
            this.txtAssunto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAssunto.Enabled = false;
            this.txtAssunto.Location = new System.Drawing.Point(8, 239);
            this.txtAssunto.MaxLength = 2000;
            this.txtAssunto.Multiline = true;
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAssunto.Size = new System.Drawing.Size(619, 40);
            this.txtAssunto.TabIndex = 35;
            this.tipForm.SetToolTip(this.txtAssunto, "Assunto da palavra");
            this.txtAssunto.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtVersoFim
            // 
            this.txtVersoFim.BackColor = System.Drawing.Color.LightGray;
            this.txtVersoFim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersoFim.Enabled = false;
            this.txtVersoFim.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtVersoFim.Location = new System.Drawing.Point(587, 198);
            this.txtVersoFim.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtVersoFim.Name = "txtVersoFim";
            this.txtVersoFim.Size = new System.Drawing.Size(30, 21);
            this.txtVersoFim.TabIndex = 34;
            this.txtVersoFim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipForm.SetToolTip(this.txtVersoFim, "Terminou a leitura no verso");
            this.txtVersoFim.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // txtHino
            // 
            this.txtHino.BackColor = System.Drawing.Color.White;
            this.txtHino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHino.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHino.Location = new System.Drawing.Point(101, 198);
            this.txtHino.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHino.Name = "txtHino";
            this.txtHino.Size = new System.Drawing.Size(45, 21);
            this.txtHino.TabIndex = 30;
            this.txtHino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tipForm.SetToolTip(this.txtHino, "Hino no início do serviço");
            this.txtHino.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // pnlReunioes
            // 
            this.pnlReunioes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlReunioes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlReunioes.Controls.Add(this.cboCapitulo);
            this.pnlReunioes.Controls.Add(this.lblStatus);
            this.pnlReunioes.Controls.Add(this.cboBiblia);
            this.pnlReunioes.Controls.Add(this.lbStatus);
            this.pnlReunioes.Controls.Add(this.txtVersoInicio);
            this.pnlReunioes.Controls.Add(this.txtAssunto);
            this.pnlReunioes.Controls.Add(this.txtObs);
            this.pnlReunioes.Controls.Add(this.txtVersoFim);
            this.pnlReunioes.Controls.Add(this.lblAssunto);
            this.pnlReunioes.Controls.Add(this.lblObs);
            this.pnlReunioes.Controls.Add(this.lblCapitulo);
            this.pnlReunioes.Controls.Add(this.gpoAtendimento);
            this.pnlReunioes.Controls.Add(this.lblAo);
            this.pnlReunioes.Controls.Add(this.cboTipo);
            this.pnlReunioes.Controls.Add(this.lblVerso);
            this.pnlReunioes.Controls.Add(this.txtUsuario);
            this.pnlReunioes.Controls.Add(this.lblHino);
            this.pnlReunioes.Controls.Add(this.lblUsuario);
            this.pnlReunioes.Controls.Add(this.lblComum);
            this.pnlReunioes.Controls.Add(this.btnComum);
            this.pnlReunioes.Controls.Add(this.txtCodCCB);
            this.pnlReunioes.Controls.Add(this.lbComum);
            this.pnlReunioes.Controls.Add(this.txtHoraInclusao);
            this.pnlReunioes.Controls.Add(this.txtHoraReuniao);
            this.pnlReunioes.Controls.Add(this.txtDataInclusao);
            this.pnlReunioes.Controls.Add(this.lblDataInclusao);
            this.pnlReunioes.Controls.Add(this.txtDataReuniao);
            this.pnlReunioes.Controls.Add(this.lblDataReuniao);
            this.pnlReunioes.Controls.Add(this.txtHino);
            this.pnlReunioes.Controls.Add(this.txtCodigo);
            this.pnlReunioes.Controls.Add(this.lblTipo);
            this.pnlReunioes.Controls.Add(this.lblBiblia);
            this.pnlReunioes.Controls.Add(this.lblCodigo);
            this.pnlReunioes.Location = new System.Drawing.Point(8, 8);
            this.pnlReunioes.Name = "pnlReunioes";
            this.pnlReunioes.Size = new System.Drawing.Size(643, 348);
            this.pnlReunioes.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.Blue;
            this.lblStatus.Location = new System.Drawing.Point(483, 9);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(144, 23);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "A Realizar";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbStatus.Location = new System.Drawing.Point(368, 14);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(113, 13);
            this.lbStatus.TabIndex = 134;
            this.lbStatus.Text = "Status da Reunião:";
            // 
            // txtObs
            // 
            this.txtObs.AcceptsReturn = true;
            this.txtObs.BackColor = System.Drawing.Color.White;
            this.txtObs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtObs.Location = new System.Drawing.Point(8, 302);
            this.txtObs.MaxLength = 2000;
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObs.Size = new System.Drawing.Size(619, 36);
            this.txtObs.TabIndex = 36;
            this.txtObs.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblAssunto
            // 
            this.lblAssunto.AutoSize = true;
            this.lblAssunto.Enabled = false;
            this.lblAssunto.Location = new System.Drawing.Point(5, 223);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(100, 13);
            this.lblAssunto.TabIndex = 132;
            this.lblAssunto.Text = "Assunto da Palavra";
            // 
            // lblObs
            // 
            this.lblObs.AutoSize = true;
            this.lblObs.Location = new System.Drawing.Point(5, 286);
            this.lblObs.Name = "lblObs";
            this.lblObs.Size = new System.Drawing.Size(242, 13);
            this.lblObs.TabIndex = 132;
            this.lblObs.Text = "Observações e Comentários referente a Reunião";
            // 
            // lblCapitulo
            // 
            this.lblCapitulo.AutoSize = true;
            this.lblCapitulo.Enabled = false;
            this.lblCapitulo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCapitulo.ForeColor = System.Drawing.Color.Black;
            this.lblCapitulo.Location = new System.Drawing.Point(393, 202);
            this.lblCapitulo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCapitulo.Name = "lblCapitulo";
            this.lblCapitulo.Size = new System.Drawing.Size(50, 13);
            this.lblCapitulo.TabIndex = 140;
            this.lblCapitulo.Text = "Capítulo:";
            // 
            // gpoAtendimento
            // 
            this.gpoAtendimento.Controls.Add(this.txtExamina);
            this.gpoAtendimento.Controls.Add(this.txtEncReg);
            this.gpoAtendimento.Controls.Add(this.txtAnciao);
            this.gpoAtendimento.Controls.Add(this.txtInstrutor);
            this.gpoAtendimento.Controls.Add(this.txtEncLocal);
            this.gpoAtendimento.Controls.Add(this.txtCoop);
            this.gpoAtendimento.Controls.Add(this.chkInstrutor);
            this.gpoAtendimento.Controls.Add(this.chkExamina);
            this.gpoAtendimento.Controls.Add(this.lblInstrutor);
            this.gpoAtendimento.Controls.Add(this.lblExamina);
            this.gpoAtendimento.Controls.Add(this.btnInstrutor);
            this.gpoAtendimento.Controls.Add(this.btnExamina);
            this.gpoAtendimento.Controls.Add(this.btnEncLocal);
            this.gpoAtendimento.Controls.Add(this.btnEncReg);
            this.gpoAtendimento.Controls.Add(this.lblEncLocal);
            this.gpoAtendimento.Controls.Add(this.lblEncReg);
            this.gpoAtendimento.Controls.Add(this.chkEncLocal);
            this.gpoAtendimento.Controls.Add(this.chkEncReg);
            this.gpoAtendimento.Controls.Add(this.chkCoop);
            this.gpoAtendimento.Controls.Add(this.lblCoop);
            this.gpoAtendimento.Controls.Add(this.chkAnciao);
            this.gpoAtendimento.Controls.Add(this.lblAnciao);
            this.gpoAtendimento.Controls.Add(this.btnCoop);
            this.gpoAtendimento.Controls.Add(this.btnAnciao);
            this.gpoAtendimento.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoAtendimento.Location = new System.Drawing.Point(8, 89);
            this.gpoAtendimento.Name = "gpoAtendimento";
            this.gpoAtendimento.Size = new System.Drawing.Size(619, 98);
            this.gpoAtendimento.TabIndex = 11;
            this.gpoAtendimento.TabStop = false;
            this.gpoAtendimento.Text = "Atendimento";
            // 
            // txtExamina
            // 
            this.txtExamina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExamina.BackColor = System.Drawing.Color.White;
            this.txtExamina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExamina.Enabled = false;
            this.txtExamina.ForeColor = System.Drawing.Color.Black;
            this.txtExamina.Location = new System.Drawing.Point(101, 66);
            this.txtExamina.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtExamina.MaxLength = 6;
            this.txtExamina.Name = "txtExamina";
            this.txtExamina.Size = new System.Drawing.Size(45, 21);
            this.txtExamina.TabIndex = 25;
            this.txtExamina.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtExamina.Enter += new System.EventHandler(this.txtExamina_Enter);
            this.txtExamina.Leave += new System.EventHandler(this.txtExamina_Leave);
            // 
            // txtEncReg
            // 
            this.txtEncReg.BackColor = System.Drawing.Color.White;
            this.txtEncReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEncReg.Enabled = false;
            this.txtEncReg.ForeColor = System.Drawing.Color.Black;
            this.txtEncReg.Location = new System.Drawing.Point(101, 41);
            this.txtEncReg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEncReg.MaxLength = 6;
            this.txtEncReg.Name = "txtEncReg";
            this.txtEncReg.Size = new System.Drawing.Size(45, 21);
            this.txtEncReg.TabIndex = 19;
            this.txtEncReg.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtEncReg.Enter += new System.EventHandler(this.txtEncReg_Enter);
            this.txtEncReg.Leave += new System.EventHandler(this.txtEncReg_Leave);
            // 
            // txtAnciao
            // 
            this.txtAnciao.BackColor = System.Drawing.Color.White;
            this.txtAnciao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnciao.Enabled = false;
            this.txtAnciao.ForeColor = System.Drawing.Color.Black;
            this.txtAnciao.Location = new System.Drawing.Point(101, 16);
            this.txtAnciao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtAnciao.MaxLength = 6;
            this.txtAnciao.Name = "txtAnciao";
            this.txtAnciao.Size = new System.Drawing.Size(45, 21);
            this.txtAnciao.TabIndex = 13;
            this.txtAnciao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtAnciao.Enter += new System.EventHandler(this.txtAnciao_Enter);
            this.txtAnciao.Leave += new System.EventHandler(this.txtAnciao_Leave);
            // 
            // txtInstrutor
            // 
            this.txtInstrutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstrutor.BackColor = System.Drawing.Color.White;
            this.txtInstrutor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInstrutor.Enabled = false;
            this.txtInstrutor.ForeColor = System.Drawing.Color.Black;
            this.txtInstrutor.Location = new System.Drawing.Point(406, 65);
            this.txtInstrutor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtInstrutor.MaxLength = 6;
            this.txtInstrutor.Name = "txtInstrutor";
            this.txtInstrutor.Size = new System.Drawing.Size(45, 21);
            this.txtInstrutor.TabIndex = 28;
            this.txtInstrutor.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtInstrutor.Enter += new System.EventHandler(this.txtExamina_Enter);
            this.txtInstrutor.Leave += new System.EventHandler(this.txtExamina_Leave);
            // 
            // txtEncLocal
            // 
            this.txtEncLocal.BackColor = System.Drawing.Color.White;
            this.txtEncLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEncLocal.Enabled = false;
            this.txtEncLocal.ForeColor = System.Drawing.Color.Black;
            this.txtEncLocal.Location = new System.Drawing.Point(406, 40);
            this.txtEncLocal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtEncLocal.MaxLength = 6;
            this.txtEncLocal.Name = "txtEncLocal";
            this.txtEncLocal.Size = new System.Drawing.Size(45, 21);
            this.txtEncLocal.TabIndex = 22;
            this.txtEncLocal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtEncLocal.Enter += new System.EventHandler(this.txtEncReg_Enter);
            this.txtEncLocal.Leave += new System.EventHandler(this.txtEncReg_Leave);
            // 
            // txtCoop
            // 
            this.txtCoop.BackColor = System.Drawing.Color.White;
            this.txtCoop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCoop.Enabled = false;
            this.txtCoop.ForeColor = System.Drawing.Color.Black;
            this.txtCoop.Location = new System.Drawing.Point(406, 15);
            this.txtCoop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCoop.MaxLength = 6;
            this.txtCoop.Name = "txtCoop";
            this.txtCoop.Size = new System.Drawing.Size(45, 21);
            this.txtCoop.TabIndex = 16;
            this.txtCoop.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtCoop.Enter += new System.EventHandler(this.txtAnciao_Enter);
            this.txtCoop.Leave += new System.EventHandler(this.txtAnciao_Leave);
            // 
            // chkInstrutor
            // 
            this.chkInstrutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInstrutor.AutoSize = true;
            this.chkInstrutor.ForeColor = System.Drawing.Color.DarkGray;
            this.chkInstrutor.Location = new System.Drawing.Point(321, 67);
            this.chkInstrutor.Name = "chkInstrutor";
            this.chkInstrutor.Size = new System.Drawing.Size(87, 17);
            this.chkInstrutor.TabIndex = 27;
            this.chkInstrutor.Text = "Instrutor(a):";
            this.chkInstrutor.UseVisualStyleBackColor = true;
            this.chkInstrutor.CheckedChanged += new System.EventHandler(this.chkExamina_CheckedChanged);
            // 
            // chkExamina
            // 
            this.chkExamina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkExamina.AutoSize = true;
            this.chkExamina.ForeColor = System.Drawing.Color.DarkGray;
            this.chkExamina.Location = new System.Drawing.Point(11, 68);
            this.chkExamina.Name = "chkExamina";
            this.chkExamina.Size = new System.Drawing.Size(92, 17);
            this.chkExamina.TabIndex = 24;
            this.chkExamina.Text = "Examinadora:";
            this.chkExamina.UseVisualStyleBackColor = true;
            this.chkExamina.CheckedChanged += new System.EventHandler(this.chkExamina_CheckedChanged);
            // 
            // lblInstrutor
            // 
            this.lblInstrutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstrutor.ForeColor = System.Drawing.Color.Black;
            this.lblInstrutor.Location = new System.Drawing.Point(483, 68);
            this.lblInstrutor.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblInstrutor.Name = "lblInstrutor";
            this.lblInstrutor.Size = new System.Drawing.Size(125, 15);
            this.lblInstrutor.TabIndex = 137;
            // 
            // lblExamina
            // 
            this.lblExamina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExamina.ForeColor = System.Drawing.Color.Black;
            this.lblExamina.Location = new System.Drawing.Point(178, 69);
            this.lblExamina.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblExamina.Name = "lblExamina";
            this.lblExamina.Size = new System.Drawing.Size(135, 15);
            this.lblExamina.TabIndex = 137;
            // 
            // btnInstrutor
            // 
            this.btnInstrutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstrutor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInstrutor.Enabled = false;
            this.btnInstrutor.ForeColor = System.Drawing.Color.Black;
            this.btnInstrutor.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnInstrutor.Location = new System.Drawing.Point(454, 64);
            this.btnInstrutor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnInstrutor.Name = "btnInstrutor";
            this.btnInstrutor.Size = new System.Drawing.Size(23, 23);
            this.btnInstrutor.TabIndex = 29;
            this.btnInstrutor.UseVisualStyleBackColor = true;
            this.btnInstrutor.Click += new System.EventHandler(this.btnExamina_Click);
            // 
            // btnExamina
            // 
            this.btnExamina.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExamina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExamina.Enabled = false;
            this.btnExamina.ForeColor = System.Drawing.Color.Black;
            this.btnExamina.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnExamina.Location = new System.Drawing.Point(149, 65);
            this.btnExamina.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnExamina.Name = "btnExamina";
            this.btnExamina.Size = new System.Drawing.Size(23, 23);
            this.btnExamina.TabIndex = 26;
            this.btnExamina.UseVisualStyleBackColor = true;
            this.btnExamina.Click += new System.EventHandler(this.btnExamina_Click);
            // 
            // btnEncLocal
            // 
            this.btnEncLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncLocal.Enabled = false;
            this.btnEncLocal.ForeColor = System.Drawing.Color.Black;
            this.btnEncLocal.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnEncLocal.Location = new System.Drawing.Point(454, 39);
            this.btnEncLocal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEncLocal.Name = "btnEncLocal";
            this.btnEncLocal.Size = new System.Drawing.Size(23, 23);
            this.btnEncLocal.TabIndex = 23;
            this.btnEncLocal.UseVisualStyleBackColor = true;
            this.btnEncLocal.Click += new System.EventHandler(this.btnEncReg_Click);
            // 
            // btnEncReg
            // 
            this.btnEncReg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncReg.Enabled = false;
            this.btnEncReg.ForeColor = System.Drawing.Color.Black;
            this.btnEncReg.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnEncReg.Location = new System.Drawing.Point(149, 40);
            this.btnEncReg.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEncReg.Name = "btnEncReg";
            this.btnEncReg.Size = new System.Drawing.Size(23, 23);
            this.btnEncReg.TabIndex = 20;
            this.btnEncReg.UseVisualStyleBackColor = true;
            this.btnEncReg.Click += new System.EventHandler(this.btnEncReg_Click);
            // 
            // lblEncLocal
            // 
            this.lblEncLocal.ForeColor = System.Drawing.Color.Black;
            this.lblEncLocal.Location = new System.Drawing.Point(483, 43);
            this.lblEncLocal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEncLocal.Name = "lblEncLocal";
            this.lblEncLocal.Size = new System.Drawing.Size(125, 15);
            this.lblEncLocal.TabIndex = 133;
            // 
            // lblEncReg
            // 
            this.lblEncReg.ForeColor = System.Drawing.Color.Black;
            this.lblEncReg.Location = new System.Drawing.Point(178, 44);
            this.lblEncReg.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblEncReg.Name = "lblEncReg";
            this.lblEncReg.Size = new System.Drawing.Size(135, 15);
            this.lblEncReg.TabIndex = 133;
            // 
            // chkEncLocal
            // 
            this.chkEncLocal.AutoSize = true;
            this.chkEncLocal.ForeColor = System.Drawing.Color.DarkGray;
            this.chkEncLocal.Location = new System.Drawing.Point(321, 42);
            this.chkEncLocal.Name = "chkEncLocal";
            this.chkEncLocal.Size = new System.Drawing.Size(78, 17);
            this.chkEncLocal.TabIndex = 21;
            this.chkEncLocal.Text = "Enc. Local:";
            this.chkEncLocal.UseVisualStyleBackColor = true;
            this.chkEncLocal.CheckedChanged += new System.EventHandler(this.chkEncReg_CheckedChanged);
            // 
            // chkEncReg
            // 
            this.chkEncReg.AutoSize = true;
            this.chkEncReg.ForeColor = System.Drawing.Color.DarkGray;
            this.chkEncReg.Location = new System.Drawing.Point(11, 43);
            this.chkEncReg.Name = "chkEncReg";
            this.chkEncReg.Size = new System.Drawing.Size(95, 17);
            this.chkEncReg.TabIndex = 18;
            this.chkEncReg.Text = "Enc. Regional:";
            this.chkEncReg.UseVisualStyleBackColor = true;
            this.chkEncReg.CheckedChanged += new System.EventHandler(this.chkEncReg_CheckedChanged);
            // 
            // chkCoop
            // 
            this.chkCoop.AutoSize = true;
            this.chkCoop.ForeColor = System.Drawing.Color.DarkGray;
            this.chkCoop.Location = new System.Drawing.Point(321, 17);
            this.chkCoop.Name = "chkCoop";
            this.chkCoop.Size = new System.Drawing.Size(87, 17);
            this.chkCoop.TabIndex = 15;
            this.chkCoop.Text = "Cooperador:";
            this.chkCoop.UseVisualStyleBackColor = true;
            this.chkCoop.CheckedChanged += new System.EventHandler(this.chkAnciao_CheckedChanged);
            // 
            // lblCoop
            // 
            this.lblCoop.ForeColor = System.Drawing.Color.Black;
            this.lblCoop.Location = new System.Drawing.Point(483, 18);
            this.lblCoop.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCoop.Name = "lblCoop";
            this.lblCoop.Size = new System.Drawing.Size(125, 15);
            this.lblCoop.TabIndex = 129;
            // 
            // chkAnciao
            // 
            this.chkAnciao.AutoSize = true;
            this.chkAnciao.ForeColor = System.Drawing.Color.DarkGray;
            this.chkAnciao.Location = new System.Drawing.Point(11, 18);
            this.chkAnciao.Name = "chkAnciao";
            this.chkAnciao.Size = new System.Drawing.Size(62, 17);
            this.chkAnciao.TabIndex = 12;
            this.chkAnciao.Text = "Ancião:";
            this.chkAnciao.UseVisualStyleBackColor = true;
            this.chkAnciao.CheckedChanged += new System.EventHandler(this.chkAnciao_CheckedChanged);
            // 
            // lblAnciao
            // 
            this.lblAnciao.ForeColor = System.Drawing.Color.Black;
            this.lblAnciao.Location = new System.Drawing.Point(178, 19);
            this.lblAnciao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAnciao.Name = "lblAnciao";
            this.lblAnciao.Size = new System.Drawing.Size(135, 15);
            this.lblAnciao.TabIndex = 129;
            // 
            // btnCoop
            // 
            this.btnCoop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCoop.Enabled = false;
            this.btnCoop.ForeColor = System.Drawing.Color.Black;
            this.btnCoop.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnCoop.Location = new System.Drawing.Point(454, 14);
            this.btnCoop.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCoop.Name = "btnCoop";
            this.btnCoop.Size = new System.Drawing.Size(23, 23);
            this.btnCoop.TabIndex = 17;
            this.btnCoop.UseVisualStyleBackColor = true;
            this.btnCoop.Click += new System.EventHandler(this.btnAnciao_Click);
            // 
            // btnAnciao
            // 
            this.btnAnciao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnciao.Enabled = false;
            this.btnAnciao.ForeColor = System.Drawing.Color.Black;
            this.btnAnciao.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnAnciao.Location = new System.Drawing.Point(149, 15);
            this.btnAnciao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnAnciao.Name = "btnAnciao";
            this.btnAnciao.Size = new System.Drawing.Size(23, 23);
            this.btnAnciao.TabIndex = 14;
            this.btnAnciao.UseVisualStyleBackColor = true;
            this.btnAnciao.Click += new System.EventHandler(this.btnAnciao_Click);
            // 
            // lblAo
            // 
            this.lblAo.AutoSize = true;
            this.lblAo.Enabled = false;
            this.lblAo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblAo.ForeColor = System.Drawing.Color.Black;
            this.lblAo.Location = new System.Drawing.Point(570, 202);
            this.lblAo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblAo.Name = "lblAo";
            this.lblAo.Size = new System.Drawing.Size(19, 13);
            this.lblAo.TabIndex = 140;
            this.lblAo.Text = "ao";
            // 
            // cboTipo
            // 
            this.cboTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.DropDownWidth = 350;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Location = new System.Drawing.Point(75, 35);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(280, 21);
            this.cboTipo.TabIndex = 5;
            // 
            // lblVerso
            // 
            this.lblVerso.AutoSize = true;
            this.lblVerso.Enabled = false;
            this.lblVerso.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblVerso.ForeColor = System.Drawing.Color.Black;
            this.lblVerso.Location = new System.Drawing.Point(498, 202);
            this.lblVerso.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblVerso.Name = "lblVerso";
            this.lblVerso.Size = new System.Drawing.Size(43, 13);
            this.lblVerso.TabIndex = 140;
            this.lblVerso.Text = "Versos:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.LightGray;
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(483, 37);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(144, 21);
            this.txtUsuario.TabIndex = 6;
            this.txtUsuario.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblHino
            // 
            this.lblHino.AutoSize = true;
            this.lblHino.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblHino.ForeColor = System.Drawing.Color.Black;
            this.lblHino.Location = new System.Drawing.Point(5, 202);
            this.lblHino.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblHino.Name = "lblHino";
            this.lblHino.Size = new System.Drawing.Size(93, 13);
            this.lblHino.TabIndex = 137;
            this.lblHino.Text = "Hino de Abertura:";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Location = new System.Drawing.Point(368, 41);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(117, 13);
            this.lblUsuario.TabIndex = 124;
            this.lblUsuario.Text = "Inclusão Efetuada por:";
            // 
            // lblComum
            // 
            this.lblComum.Location = new System.Drawing.Point(152, 65);
            this.lblComum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComum.Name = "lblComum";
            this.lblComum.Size = new System.Drawing.Size(203, 13);
            this.lblComum.TabIndex = 123;
            // 
            // btnComum
            // 
            this.btnComum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComum.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnComum.Location = new System.Drawing.Point(123, 60);
            this.btnComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnComum.Name = "btnComum";
            this.btnComum.Size = new System.Drawing.Size(23, 23);
            this.btnComum.TabIndex = 8;
            this.btnComum.UseVisualStyleBackColor = true;
            this.btnComum.Click += new System.EventHandler(this.btnComum_Click);
            // 
            // txtCodCCB
            // 
            this.txtCodCCB.BackColor = System.Drawing.Color.White;
            this.txtCodCCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodCCB.Location = new System.Drawing.Point(75, 61);
            this.txtCodCCB.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodCCB.MaxLength = 6;
            this.txtCodCCB.Name = "txtCodCCB";
            this.txtCodCCB.Size = new System.Drawing.Size(45, 21);
            this.txtCodCCB.TabIndex = 7;
            this.txtCodCCB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodCCB.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtCodCCB.Enter += new System.EventHandler(this.txtCodCCB_Enter);
            this.txtCodCCB.Leave += new System.EventHandler(this.txtCodCCB_Leave);
            // 
            // lbComum
            // 
            this.lbComum.AutoSize = true;
            this.lbComum.Location = new System.Drawing.Point(5, 65);
            this.lbComum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbComum.Name = "lbComum";
            this.lbComum.Size = new System.Drawing.Size(66, 13);
            this.lbComum.TabIndex = 90;
            this.lbComum.Text = "Local Realiz:";
            // 
            // txtHoraInclusao
            // 
            this.txtHoraInclusao.BackColor = System.Drawing.Color.LightGray;
            this.txtHoraInclusao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraInclusao.Enabled = false;
            this.txtHoraInclusao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraInclusao.Location = new System.Drawing.Point(314, 9);
            this.txtHoraInclusao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraInclusao.Name = "txtHoraInclusao";
            this.txtHoraInclusao.Size = new System.Drawing.Size(41, 21);
            this.txtHoraInclusao.TabIndex = 3;
            this.txtHoraInclusao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraInclusao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtHoraReuniao
            // 
            this.txtHoraReuniao.BackColor = System.Drawing.Color.White;
            this.txtHoraReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraReuniao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraReuniao.Location = new System.Drawing.Point(582, 63);
            this.txtHoraReuniao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraReuniao.Name = "txtHoraReuniao";
            this.txtHoraReuniao.Size = new System.Drawing.Size(45, 21);
            this.txtHoraReuniao.TabIndex = 10;
            this.txtHoraReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtDataInclusao
            // 
            this.txtDataInclusao.BackColor = System.Drawing.Color.LightGray;
            this.txtDataInclusao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataInclusao.Enabled = false;
            this.txtDataInclusao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataInclusao.Location = new System.Drawing.Point(209, 9);
            this.txtDataInclusao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataInclusao.Name = "txtDataInclusao";
            this.txtDataInclusao.Size = new System.Drawing.Size(100, 21);
            this.txtDataInclusao.TabIndex = 2;
            this.txtDataInclusao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataInclusao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataInclusao
            // 
            this.lblDataInclusao.AutoSize = true;
            this.lblDataInclusao.Enabled = false;
            this.lblDataInclusao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDataInclusao.Location = new System.Drawing.Point(135, 13);
            this.lblDataInclusao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataInclusao.Name = "lblDataInclusao";
            this.lblDataInclusao.Size = new System.Drawing.Size(77, 13);
            this.lblDataInclusao.TabIndex = 110;
            this.lblDataInclusao.Text = "Data Inclusão:";
            // 
            // txtDataReuniao
            // 
            this.txtDataReuniao.BackColor = System.Drawing.Color.White;
            this.txtDataReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataReuniao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataReuniao.Location = new System.Drawing.Point(483, 63);
            this.txtDataReuniao.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataReuniao.Name = "txtDataReuniao";
            this.txtDataReuniao.Size = new System.Drawing.Size(95, 21);
            this.txtDataReuniao.TabIndex = 9;
            this.txtDataReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblDataReuniao
            // 
            this.lblDataReuniao.AutoSize = true;
            this.lblDataReuniao.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDataReuniao.Location = new System.Drawing.Point(368, 67);
            this.lblDataReuniao.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataReuniao.Name = "lblDataReuniao";
            this.lblDataReuniao.Size = new System.Drawing.Size(88, 13);
            this.lblDataReuniao.TabIndex = 110;
            this.lblDataReuniao.Text = "Data Realização:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTipo.Location = new System.Drawing.Point(5, 39);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(73, 13);
            this.lblTipo.TabIndex = 107;
            this.lblTipo.Text = "Tipo Reunião:";
            // 
            // lblBiblia
            // 
            this.lblBiblia.AutoSize = true;
            this.lblBiblia.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblBiblia.ForeColor = System.Drawing.Color.Black;
            this.lblBiblia.Location = new System.Drawing.Point(160, 202);
            this.lblBiblia.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblBiblia.Name = "lblBiblia";
            this.lblBiblia.Size = new System.Drawing.Size(47, 13);
            this.lblBiblia.TabIndex = 107;
            this.lblBiblia.Text = "Palavra:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(5, 13);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(64, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Reunião nº:";
            // 
            // lblCodUsuario
            // 
            this.lblCodUsuario.Enabled = false;
            this.lblCodUsuario.Location = new System.Drawing.Point(144, 384);
            this.lblCodUsuario.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuario.Name = "lblCodUsuario";
            this.lblCodUsuario.Size = new System.Drawing.Size(60, 13);
            this.lblCodUsuario.TabIndex = 127;
            this.lblCodUsuario.Visible = false;
            // 
            // lblFinaliza
            // 
            this.lblFinaliza.AutoSize = true;
            this.lblFinaliza.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblFinaliza.Location = new System.Drawing.Point(136, 367);
            this.lblFinaliza.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFinaliza.Name = "lblFinaliza";
            this.lblFinaliza.Size = new System.Drawing.Size(46, 13);
            this.lblFinaliza.TabIndex = 129;
            this.lblFinaliza.Text = "Finaliza:";
            this.lblFinaliza.Visible = false;
            // 
            // lblCancela
            // 
            this.lblCancela.AutoSize = true;
            this.lblCancela.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCancela.Location = new System.Drawing.Point(288, 367);
            this.lblCancela.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCancela.Name = "lblCancela";
            this.lblCancela.Size = new System.Drawing.Size(49, 13);
            this.lblCancela.TabIndex = 132;
            this.lblCancela.Text = "Cancela:";
            this.lblCancela.Visible = false;
            // 
            // lblCodUsuarioFinaliza
            // 
            this.lblCodUsuarioFinaliza.Enabled = false;
            this.lblCodUsuarioFinaliza.Location = new System.Drawing.Point(214, 384);
            this.lblCodUsuarioFinaliza.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuarioFinaliza.Name = "lblCodUsuarioFinaliza";
            this.lblCodUsuarioFinaliza.Size = new System.Drawing.Size(60, 13);
            this.lblCodUsuarioFinaliza.TabIndex = 134;
            this.lblCodUsuarioFinaliza.Visible = false;
            // 
            // lblCodUsuarioCancela
            // 
            this.lblCodUsuarioCancela.Enabled = false;
            this.lblCodUsuarioCancela.Location = new System.Drawing.Point(284, 384);
            this.lblCodUsuarioCancela.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuarioCancela.Name = "lblCodUsuarioCancela";
            this.lblCodUsuarioCancela.Size = new System.Drawing.Size(60, 13);
            this.lblCodUsuarioCancela.TabIndex = 135;
            this.lblCodUsuarioCancela.Visible = false;
            // 
            // txtHoraCancela
            // 
            this.txtHoraCancela.BackColor = System.Drawing.Color.LightGray;
            this.txtHoraCancela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraCancela.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraCancela.Location = new System.Drawing.Point(415, 363);
            this.txtHoraCancela.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraCancela.Name = "txtHoraCancela";
            this.txtHoraCancela.Size = new System.Drawing.Size(37, 21);
            this.txtHoraCancela.TabIndex = 133;
            this.txtHoraCancela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraCancela.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            this.txtHoraCancela.Visible = false;
            // 
            // txtDataCancela
            // 
            this.txtDataCancela.BackColor = System.Drawing.Color.LightGray;
            this.txtDataCancela.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataCancela.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataCancela.Location = new System.Drawing.Point(335, 363);
            this.txtDataCancela.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataCancela.Name = "txtDataCancela";
            this.txtDataCancela.Size = new System.Drawing.Size(76, 21);
            this.txtDataCancela.TabIndex = 131;
            this.txtDataCancela.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataCancela.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataCancela.Visible = false;
            // 
            // txtHoraFinaliza
            // 
            this.txtHoraFinaliza.BackColor = System.Drawing.Color.LightGray;
            this.txtHoraFinaliza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraFinaliza.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraFinaliza.Location = new System.Drawing.Point(249, 363);
            this.txtHoraFinaliza.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraFinaliza.Name = "txtHoraFinaliza";
            this.txtHoraFinaliza.Size = new System.Drawing.Size(35, 21);
            this.txtHoraFinaliza.TabIndex = 130;
            this.txtHoraFinaliza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraFinaliza.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            this.txtHoraFinaliza.Visible = false;
            // 
            // txtDataFinaliza
            // 
            this.txtDataFinaliza.BackColor = System.Drawing.Color.LightGray;
            this.txtDataFinaliza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataFinaliza.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataFinaliza.Location = new System.Drawing.Point(182, 363);
            this.txtDataFinaliza.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataFinaliza.Name = "txtDataFinaliza";
            this.txtDataFinaliza.Size = new System.Drawing.Size(65, 21);
            this.txtDataFinaliza.TabIndex = 128;
            this.txtDataFinaliza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataFinaliza.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataFinaliza.Visible = false;
            // 
            // frmReunioes
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(658, 398);
            this.Controls.Add(this.lblCodUsuarioCancela);
            this.Controls.Add(this.lblCodUsuarioFinaliza);
            this.Controls.Add(this.pnlReunioes);
            this.Controls.Add(this.txtHoraCancela);
            this.Controls.Add(this.txtDataCancela);
            this.Controls.Add(this.lblCancela);
            this.Controls.Add(this.txtHoraFinaliza);
            this.Controls.Add(this.txtDataFinaliza);
            this.Controls.Add(this.lblFinaliza);
            this.Controls.Add(this.lblCodUsuario);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnListaPresenca);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReunioes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serviços e Reuniões";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReunioes_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReunioes_FormClosed);
            this.Load += new System.EventHandler(this.frmReunioes_Load);
            this.pnlReunioes.ResumeLayout(false);
            this.pnlReunioes.PerformLayout();
            this.gpoAtendimento.ResumeLayout(false);
            this.gpoAtendimento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipForm;
        private System.Windows.Forms.Panel pnlReunioes;
        private System.Windows.Forms.Label lblComum;
        private System.Windows.Forms.Button btnComum;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodCCB;
        private System.Windows.Forms.Label lbComum;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraReuniao;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataReuniao;
        private System.Windows.Forms.Label lblDataReuniao;
        private BLL.validacoes.Controles.TextBoxPersonal txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnListaPresenca;
        private System.Windows.Forms.Label lblCodUsuario;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTipo;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraInclusao;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataInclusao;
        private System.Windows.Forms.Label lblDataInclusao;
        private System.Windows.Forms.Label lblTipo;
        private BLL.validacoes.Controles.TextBoxPersonal txtObs;
        private System.Windows.Forms.Label lblObs;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Label lblStatus;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraFinaliza;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataFinaliza;
        private System.Windows.Forms.Label lblFinaliza;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraCancela;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataCancela;
        private System.Windows.Forms.Label lblCancela;
        private System.Windows.Forms.Label lblCodUsuarioFinaliza;
        private System.Windows.Forms.Label lblCodUsuarioCancela;
        private BLL.validacoes.Controles.ComboBoxPersonal cboCapitulo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboBiblia;
        private BLL.validacoes.Controles.TextBoxPersonal txtVersoInicio;
        private BLL.validacoes.Controles.TextBoxPersonal txtVersoFim;
        private System.Windows.Forms.Label lblCapitulo;
        private System.Windows.Forms.GroupBox gpoAtendimento;
        private System.Windows.Forms.CheckBox chkExamina;
        private BLL.validacoes.Controles.TextBoxPersonal txtExamina;
        private System.Windows.Forms.Label lblExamina;
        private System.Windows.Forms.Button btnExamina;
        private System.Windows.Forms.Button btnEncReg;
        private BLL.validacoes.Controles.TextBoxPersonal txtEncReg;
        private System.Windows.Forms.Label lblEncReg;
        private System.Windows.Forms.CheckBox chkEncReg;
        private System.Windows.Forms.CheckBox chkAnciao;
        private System.Windows.Forms.Label lblAnciao;
        private BLL.validacoes.Controles.TextBoxPersonal txtAnciao;
        private System.Windows.Forms.Button btnAnciao;
        private System.Windows.Forms.Label lblAo;
        private System.Windows.Forms.Label lblVerso;
        private System.Windows.Forms.Label lblHino;
        private BLL.validacoes.Controles.TextBoxPersonal txtHino;
        private System.Windows.Forms.Label lblBiblia;
        private BLL.validacoes.Controles.TextBoxPersonal txtAssunto;
        private System.Windows.Forms.Label lblAssunto;
        private BLL.validacoes.Controles.TextBoxPersonal txtInstrutor;
        private BLL.validacoes.Controles.TextBoxPersonal txtEncLocal;
        private BLL.validacoes.Controles.TextBoxPersonal txtCoop;
        private System.Windows.Forms.CheckBox chkInstrutor;
        private System.Windows.Forms.Label lblInstrutor;
        private System.Windows.Forms.Button btnInstrutor;
        private System.Windows.Forms.Button btnEncLocal;
        private System.Windows.Forms.Label lblEncLocal;
        private System.Windows.Forms.CheckBox chkEncLocal;
        private System.Windows.Forms.CheckBox chkCoop;
        private System.Windows.Forms.Label lblCoop;
        private System.Windows.Forms.Button btnCoop;
    }
}