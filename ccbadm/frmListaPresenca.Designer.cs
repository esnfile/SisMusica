namespace ccbadm
{
    partial class frmListaPresenca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaPresenca));
            this.tipPreTeste = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtPessoa = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHoraReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.btnRetornar = new System.Windows.Forms.Button();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.pnlPreTeste = new System.Windows.Forms.Panel();
            this.btnPrevia = new System.Windows.Forms.Button();
            this.lblCodListaPresenca = new System.Windows.Forms.Label();
            this.gpoPessoa = new System.Windows.Forms.GroupBox();
            this.lblDataNasc = new System.Windows.Forms.Label();
            this.txtTelefone = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtComum = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lbPessoa = new System.Windows.Forms.Label();
            this.txtDataNasc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCidade = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblTelefone = new System.Windows.Forms.Label();
            this.lblComum = new System.Windows.Forms.Label();
            this.txtCargo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblPessoa = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.txtCpf = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCidade = new System.Windows.Forms.Label();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.gridLista = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.gpoReuniao = new System.Windows.Forms.GroupBox();
            this.txtTipo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblTipo = new System.Windows.Forms.Label();
            this.txtCodReuniao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblReuniao = new System.Windows.Forms.Label();
            this.txtLocal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lbLocal = new System.Windows.Forms.Label();
            this.lblDataReuniao = new System.Windows.Forms.Label();
            this.lblCodUsuarioAbertura = new System.Windows.Forms.Label();
            this.lblCodUsuarioFecha = new System.Windows.Forms.Label();
            this.pnlPreTeste.SuspendLayout();
            this.gpoPessoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLista)).BeginInit();
            this.gpoReuniao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(596, 441);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "&Fechar";
            this.tipPreTeste.SetToolTip(this.btnFechar, "Cancelar alterações");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtPessoa
            // 
            this.txtPessoa.BackColor = System.Drawing.Color.White;
            this.txtPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPessoa.ForeColor = System.Drawing.Color.Black;
            this.txtPessoa.Location = new System.Drawing.Point(72, 17);
            this.txtPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPessoa.MaxLength = 6;
            this.txtPessoa.Name = "txtPessoa";
            this.txtPessoa.Size = new System.Drawing.Size(49, 21);
            this.txtPessoa.TabIndex = 77;
            this.txtPessoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPreTeste.SetToolTip(this.txtPessoa, "Informe o código do Irmão(ã), ou clique na lupa para buscar");
            this.txtPessoa.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtPessoa.Enter += new System.EventHandler(this.txtPessoa_Enter);
            this.txtPessoa.Leave += new System.EventHandler(this.txtPessoa_Leave);
            // 
            // txtHoraReuniao
            // 
            this.txtHoraReuniao.BackColor = System.Drawing.Color.White;
            this.txtHoraReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraReuniao.Enabled = false;
            this.txtHoraReuniao.ForeColor = System.Drawing.Color.Black;
            this.txtHoraReuniao.Location = new System.Drawing.Point(290, 19);
            this.txtHoraReuniao.MaxLength = 5;
            this.txtHoraReuniao.Name = "txtHoraReuniao";
            this.txtHoraReuniao.Size = new System.Drawing.Size(40, 21);
            this.txtHoraReuniao.TabIndex = 105;
            this.txtHoraReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPreTeste.SetToolTip(this.txtHoraReuniao, "Hora da reunião");
            this.txtHoraReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtDataReuniao
            // 
            this.txtDataReuniao.BackColor = System.Drawing.Color.White;
            this.txtDataReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataReuniao.Enabled = false;
            this.txtDataReuniao.ForeColor = System.Drawing.Color.Black;
            this.txtDataReuniao.Location = new System.Drawing.Point(211, 19);
            this.txtDataReuniao.MaxLength = 10;
            this.txtDataReuniao.Name = "txtDataReuniao";
            this.txtDataReuniao.Size = new System.Drawing.Size(75, 21);
            this.txtDataReuniao.TabIndex = 104;
            this.txtDataReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipPreTeste.SetToolTip(this.txtDataReuniao, "Data da reunião");
            this.txtDataReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // btnEditar
            // 
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Enabled = false;
            this.btnEditar.ForeColor = System.Drawing.Color.Black;
            this.btnEditar.Image = global::ccbadm.Properties.Resources.Processar;
            this.btnEditar.Location = new System.Drawing.Point(17, 100);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(120, 30);
            this.btnEditar.TabIndex = 147;
            this.btnEditar.Text = "Atualizar dados";
            this.btnEditar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPreTeste.SetToolTip(this.btnEditar, "Atualizar os dados do Irmão(ã) informado");
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.AutoSize = true;
            this.btnIncluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncluir.ForeColor = System.Drawing.Color.Black;
            this.btnIncluir.Image = global::ccbadm.Properties.Resources.button_ok;
            this.btnIncluir.Location = new System.Drawing.Point(471, 100);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(90, 30);
            this.btnIncluir.TabIndex = 147;
            this.btnIncluir.Text = "&Incluir";
            this.btnIncluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPreTeste.SetToolTip(this.btnIncluir, "Incluir irmão(ã) selecionado na lista de presença");
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // btnRetornar
            // 
            this.btnRetornar.AutoSize = true;
            this.btnRetornar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRetornar.ForeColor = System.Drawing.Color.Black;
            this.btnRetornar.Image = global::ccbadm.Properties.Resources.button_cancel;
            this.btnRetornar.Location = new System.Drawing.Point(564, 100);
            this.btnRetornar.Name = "btnRetornar";
            this.btnRetornar.Size = new System.Drawing.Size(92, 30);
            this.btnRetornar.TabIndex = 146;
            this.btnRetornar.Text = "Retornar";
            this.btnRetornar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipPreTeste.SetToolTip(this.btnRetornar, "Cancelar alterações e retornar");
            this.btnRetornar.UseVisualStyleBackColor = true;
            this.btnRetornar.Click += new System.EventHandler(this.btnRetornar_Click);
            // 
            // btnPessoa
            // 
            this.btnPessoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPessoa.ForeColor = System.Drawing.Color.Black;
            this.btnPessoa.Image = global::ccbadm.Properties.Resources.Lupa;
            this.btnPessoa.Location = new System.Drawing.Point(124, 16);
            this.btnPessoa.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(23, 23);
            this.btnPessoa.TabIndex = 78;
            this.tipPreTeste.SetToolTip(this.btnPessoa, "Selecione o Irmão(ã)");
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // pnlPreTeste
            // 
            this.pnlPreTeste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlPreTeste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPreTeste.Controls.Add(this.btnPrevia);
            this.pnlPreTeste.Controls.Add(this.lblCodListaPresenca);
            this.pnlPreTeste.Controls.Add(this.gpoPessoa);
            this.pnlPreTeste.Controls.Add(this.btnIns);
            this.pnlPreTeste.Controls.Add(this.btnExcluir);
            this.pnlPreTeste.Controls.Add(this.gridLista);
            this.pnlPreTeste.Controls.Add(this.gpoReuniao);
            this.pnlPreTeste.Location = new System.Drawing.Point(6, 6);
            this.pnlPreTeste.Name = "pnlPreTeste";
            this.pnlPreTeste.Size = new System.Drawing.Size(680, 432);
            this.pnlPreTeste.TabIndex = 0;
            // 
            // btnPrevia
            // 
            this.btnPrevia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevia.Location = new System.Drawing.Point(8, 398);
            this.btnPrevia.Name = "btnPrevia";
            this.btnPrevia.Size = new System.Drawing.Size(85, 28);
            this.btnPrevia.TabIndex = 147;
            this.btnPrevia.Text = "Prévia Lista";
            this.btnPrevia.UseVisualStyleBackColor = true;
            this.btnPrevia.Click += new System.EventHandler(this.btnPrevia_Click);
            // 
            // lblCodListaPresenca
            // 
            this.lblCodListaPresenca.Enabled = false;
            this.lblCodListaPresenca.ForeColor = System.Drawing.Color.Black;
            this.lblCodListaPresenca.Location = new System.Drawing.Point(7, 406);
            this.lblCodListaPresenca.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodListaPresenca.Name = "lblCodListaPresenca";
            this.lblCodListaPresenca.Size = new System.Drawing.Size(46, 13);
            this.lblCodListaPresenca.TabIndex = 146;
            this.lblCodListaPresenca.Text = "0";
            // 
            // gpoPessoa
            // 
            this.gpoPessoa.Controls.Add(this.btnEditar);
            this.gpoPessoa.Controls.Add(this.btnIncluir);
            this.gpoPessoa.Controls.Add(this.txtPessoa);
            this.gpoPessoa.Controls.Add(this.btnRetornar);
            this.gpoPessoa.Controls.Add(this.lblDataNasc);
            this.gpoPessoa.Controls.Add(this.txtTelefone);
            this.gpoPessoa.Controls.Add(this.txtComum);
            this.gpoPessoa.Controls.Add(this.lblCargo);
            this.gpoPessoa.Controls.Add(this.lbPessoa);
            this.gpoPessoa.Controls.Add(this.txtDataNasc);
            this.gpoPessoa.Controls.Add(this.txtCidade);
            this.gpoPessoa.Controls.Add(this.lblTelefone);
            this.gpoPessoa.Controls.Add(this.lblComum);
            this.gpoPessoa.Controls.Add(this.txtCargo);
            this.gpoPessoa.Controls.Add(this.lblPessoa);
            this.gpoPessoa.Controls.Add(this.lblCpf);
            this.gpoPessoa.Controls.Add(this.txtCpf);
            this.gpoPessoa.Controls.Add(this.lblCidade);
            this.gpoPessoa.Controls.Add(this.btnPessoa);
            this.gpoPessoa.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoPessoa.Location = new System.Drawing.Point(8, 81);
            this.gpoPessoa.Name = "gpoPessoa";
            this.gpoPessoa.Size = new System.Drawing.Size(662, 138);
            this.gpoPessoa.TabIndex = 145;
            this.gpoPessoa.TabStop = false;
            this.gpoPessoa.Text = "Pessoa que será incluída na lista de presença";
            // 
            // lblDataNasc
            // 
            this.lblDataNasc.AutoSize = true;
            this.lblDataNasc.Enabled = false;
            this.lblDataNasc.ForeColor = System.Drawing.Color.Black;
            this.lblDataNasc.Location = new System.Drawing.Point(347, 22);
            this.lblDataNasc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDataNasc.Name = "lblDataNasc";
            this.lblDataNasc.Size = new System.Drawing.Size(66, 13);
            this.lblDataNasc.TabIndex = 136;
            this.lblDataNasc.Text = "Nascimento:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.BackColor = System.Drawing.Color.LightGray;
            this.txtTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefone.Enabled = false;
            this.txtTelefone.ForeColor = System.Drawing.Color.Black;
            this.txtTelefone.Location = new System.Drawing.Point(420, 67);
            this.txtTelefone.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(234, 21);
            this.txtTelefone.TabIndex = 139;
            this.txtTelefone.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtComum
            // 
            this.txtComum.BackColor = System.Drawing.Color.LightGray;
            this.txtComum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtComum.Enabled = false;
            this.txtComum.ForeColor = System.Drawing.Color.Black;
            this.txtComum.Location = new System.Drawing.Point(72, 42);
            this.txtComum.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtComum.Name = "txtComum";
            this.txtComum.Size = new System.Drawing.Size(265, 21);
            this.txtComum.TabIndex = 129;
            this.txtComum.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Enabled = false;
            this.lblCargo.ForeColor = System.Drawing.Color.Black;
            this.lblCargo.Location = new System.Drawing.Point(16, 71);
            this.lblCargo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(56, 13);
            this.lblCargo.TabIndex = 132;
            this.lblCargo.Text = "Ministério:";
            // 
            // lbPessoa
            // 
            this.lbPessoa.AutoSize = true;
            this.lbPessoa.ForeColor = System.Drawing.Color.Black;
            this.lbPessoa.Location = new System.Drawing.Point(16, 21);
            this.lbPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPessoa.Name = "lbPessoa";
            this.lbPessoa.Size = new System.Drawing.Size(56, 13);
            this.lbPessoa.TabIndex = 76;
            this.lbPessoa.Text = "Irmão (ã):";
            // 
            // txtDataNasc
            // 
            this.txtDataNasc.BackColor = System.Drawing.Color.LightGray;
            this.txtDataNasc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataNasc.Enabled = false;
            this.txtDataNasc.ForeColor = System.Drawing.Color.Black;
            this.txtDataNasc.Location = new System.Drawing.Point(420, 17);
            this.txtDataNasc.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataNasc.Name = "txtDataNasc";
            this.txtDataNasc.Size = new System.Drawing.Size(72, 21);
            this.txtDataNasc.TabIndex = 135;
            this.txtDataNasc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.LightGray;
            this.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCidade.Enabled = false;
            this.txtCidade.ForeColor = System.Drawing.Color.Black;
            this.txtCidade.Location = new System.Drawing.Point(420, 42);
            this.txtCidade.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(234, 21);
            this.txtCidade.TabIndex = 133;
            this.txtCidade.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblTelefone
            // 
            this.lblTelefone.AutoSize = true;
            this.lblTelefone.Enabled = false;
            this.lblTelefone.ForeColor = System.Drawing.Color.Black;
            this.lblTelefone.Location = new System.Drawing.Point(347, 72);
            this.lblTelefone.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTelefone.Name = "lblTelefone";
            this.lblTelefone.Size = new System.Drawing.Size(58, 13);
            this.lblTelefone.TabIndex = 140;
            this.lblTelefone.Text = "Telefones:";
            // 
            // lblComum
            // 
            this.lblComum.AutoSize = true;
            this.lblComum.Enabled = false;
            this.lblComum.ForeColor = System.Drawing.Color.Black;
            this.lblComum.Location = new System.Drawing.Point(16, 46);
            this.lblComum.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblComum.Name = "lblComum";
            this.lblComum.Size = new System.Drawing.Size(46, 13);
            this.lblComum.TabIndex = 130;
            this.lblComum.Text = "Comum:";
            // 
            // txtCargo
            // 
            this.txtCargo.BackColor = System.Drawing.Color.LightGray;
            this.txtCargo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCargo.Enabled = false;
            this.txtCargo.ForeColor = System.Drawing.Color.Black;
            this.txtCargo.Location = new System.Drawing.Point(72, 67);
            this.txtCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new System.Drawing.Size(265, 21);
            this.txtCargo.TabIndex = 131;
            this.txtCargo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblPessoa
            // 
            this.lblPessoa.ForeColor = System.Drawing.Color.Black;
            this.lblPessoa.Location = new System.Drawing.Point(150, 20);
            this.lblPessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPessoa.Name = "lblPessoa";
            this.lblPessoa.Size = new System.Drawing.Size(187, 15);
            this.lblPessoa.TabIndex = 79;
            this.lblPessoa.TextChanged += new System.EventHandler(this.lblPessoa_TextChanged);
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Enabled = false;
            this.lblCpf.ForeColor = System.Drawing.Color.Black;
            this.lblCpf.Location = new System.Drawing.Point(497, 21);
            this.lblCpf.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(42, 13);
            this.lblCpf.TabIndex = 138;
            this.lblCpf.Text = "C.P.F.:";
            // 
            // txtCpf
            // 
            this.txtCpf.BackColor = System.Drawing.Color.LightGray;
            this.txtCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCpf.Enabled = false;
            this.txtCpf.ForeColor = System.Drawing.Color.Black;
            this.txtCpf.Location = new System.Drawing.Point(541, 17);
            this.txtCpf.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(113, 21);
            this.txtCpf.TabIndex = 137;
            this.txtCpf.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Enabled = false;
            this.lblCidade.ForeColor = System.Drawing.Color.Black;
            this.lblCidade.Location = new System.Drawing.Point(347, 47);
            this.lblCidade.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(44, 13);
            this.lblCidade.TabIndex = 134;
            this.lblCidade.Text = "Cidade:";
            // 
            // btnIns
            // 
            this.btnIns.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIns.Location = new System.Drawing.Point(498, 398);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(85, 28);
            this.btnIns.TabIndex = 144;
            this.btnIns.Text = "Inserir";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcluir.Location = new System.Drawing.Point(586, 398);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(85, 28);
            this.btnExcluir.TabIndex = 143;
            this.btnExcluir.Text = "&Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // gridLista
            // 
            this.gridLista.AllowUserToAddRows = false;
            this.gridLista.AllowUserToDeleteRows = false;
            this.gridLista.AllowUserToResizeRows = false;
            this.gridLista.BackgroundColor = System.Drawing.Color.White;
            this.gridLista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridLista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridLista.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridLista.DisabledCell = null;
            this.gridLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridLista.EnableHeadersVisualStyles = false;
            this.gridLista.Location = new System.Drawing.Point(8, 224);
            this.gridLista.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridLista.MultiSelect = false;
            this.gridLista.Name = "gridLista";
            this.gridLista.ReadOnly = true;
            this.gridLista.RowHeadersVisible = false;
            this.gridLista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridLista.RowTemplate.Height = 18;
            this.gridLista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridLista.Size = new System.Drawing.Size(662, 171);
            this.gridLista.TabIndex = 142;
            this.gridLista.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridLista_RowStateChanged);
            this.gridLista.SelectionChanged += new System.EventHandler(this.gridLista_SelectionChanged);
            // 
            // gpoReuniao
            // 
            this.gpoReuniao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.gpoReuniao.Controls.Add(this.txtTipo);
            this.gpoReuniao.Controls.Add(this.lblTipo);
            this.gpoReuniao.Controls.Add(this.txtHoraReuniao);
            this.gpoReuniao.Controls.Add(this.txtDataReuniao);
            this.gpoReuniao.Controls.Add(this.txtCodReuniao);
            this.gpoReuniao.Controls.Add(this.lblReuniao);
            this.gpoReuniao.Controls.Add(this.txtLocal);
            this.gpoReuniao.Controls.Add(this.lbLocal);
            this.gpoReuniao.Controls.Add(this.lblDataReuniao);
            this.gpoReuniao.Enabled = false;
            this.gpoReuniao.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoReuniao.Location = new System.Drawing.Point(8, 4);
            this.gpoReuniao.Name = "gpoReuniao";
            this.gpoReuniao.Size = new System.Drawing.Size(662, 76);
            this.gpoReuniao.TabIndex = 95;
            this.gpoReuniao.TabStop = false;
            this.gpoReuniao.Text = "Dados sobre a Reunião";
            // 
            // txtTipo
            // 
            this.txtTipo.BackColor = System.Drawing.Color.LightGray;
            this.txtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTipo.Enabled = false;
            this.txtTipo.ForeColor = System.Drawing.Color.Black;
            this.txtTipo.Location = new System.Drawing.Point(420, 19);
            this.txtTipo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(234, 21);
            this.txtTipo.TabIndex = 128;
            this.txtTipo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Enabled = false;
            this.lblTipo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTipo.ForeColor = System.Drawing.Color.Black;
            this.lblTipo.Location = new System.Drawing.Point(347, 23);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(73, 13);
            this.lblTipo.TabIndex = 127;
            this.lblTipo.Text = "Tipo Reunião:";
            // 
            // txtCodReuniao
            // 
            this.txtCodReuniao.BackColor = System.Drawing.Color.LightGray;
            this.txtCodReuniao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodReuniao.Enabled = false;
            this.txtCodReuniao.ForeColor = System.Drawing.Color.Black;
            this.txtCodReuniao.Location = new System.Drawing.Point(72, 19);
            this.txtCodReuniao.Name = "txtCodReuniao";
            this.txtCodReuniao.Size = new System.Drawing.Size(49, 21);
            this.txtCodReuniao.TabIndex = 109;
            this.txtCodReuniao.Text = "00000";
            this.txtCodReuniao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodReuniao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblReuniao
            // 
            this.lblReuniao.AutoSize = true;
            this.lblReuniao.Enabled = false;
            this.lblReuniao.ForeColor = System.Drawing.Color.Black;
            this.lblReuniao.Location = new System.Drawing.Point(9, 23);
            this.lblReuniao.Name = "lblReuniao";
            this.lblReuniao.Size = new System.Drawing.Size(64, 13);
            this.lblReuniao.TabIndex = 108;
            this.lblReuniao.Text = "Reunião nº:";
            // 
            // txtLocal
            // 
            this.txtLocal.BackColor = System.Drawing.Color.LightGray;
            this.txtLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLocal.Enabled = false;
            this.txtLocal.ForeColor = System.Drawing.Color.Black;
            this.txtLocal.Location = new System.Drawing.Point(72, 45);
            this.txtLocal.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtLocal.Name = "txtLocal";
            this.txtLocal.Size = new System.Drawing.Size(582, 21);
            this.txtLocal.TabIndex = 106;
            this.txtLocal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lbLocal
            // 
            this.lbLocal.AutoSize = true;
            this.lbLocal.Enabled = false;
            this.lbLocal.ForeColor = System.Drawing.Color.Black;
            this.lbLocal.Location = new System.Drawing.Point(9, 49);
            this.lbLocal.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbLocal.Name = "lbLocal";
            this.lbLocal.Size = new System.Drawing.Size(66, 13);
            this.lbLocal.TabIndex = 107;
            this.lbLocal.Text = "Local Realiz:";
            // 
            // lblDataReuniao
            // 
            this.lblDataReuniao.AutoSize = true;
            this.lblDataReuniao.Enabled = false;
            this.lblDataReuniao.ForeColor = System.Drawing.Color.Black;
            this.lblDataReuniao.Location = new System.Drawing.Point(133, 23);
            this.lblDataReuniao.Name = "lblDataReuniao";
            this.lblDataReuniao.Size = new System.Drawing.Size(76, 13);
            this.lblDataReuniao.TabIndex = 103;
            this.lblDataReuniao.Text = "Data Reunião:";
            // 
            // lblCodUsuarioAbertura
            // 
            this.lblCodUsuarioAbertura.Enabled = false;
            this.lblCodUsuarioAbertura.Location = new System.Drawing.Point(14, 565);
            this.lblCodUsuarioAbertura.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuarioAbertura.Name = "lblCodUsuarioAbertura";
            this.lblCodUsuarioAbertura.Size = new System.Drawing.Size(70, 13);
            this.lblCodUsuarioAbertura.TabIndex = 106;
            // 
            // lblCodUsuarioFecha
            // 
            this.lblCodUsuarioFecha.Enabled = false;
            this.lblCodUsuarioFecha.Location = new System.Drawing.Point(14, 578);
            this.lblCodUsuarioFecha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodUsuarioFecha.Name = "lblCodUsuarioFecha";
            this.lblCodUsuarioFecha.Size = new System.Drawing.Size(70, 13);
            this.lblCodUsuarioFecha.TabIndex = 107;
            // 
            // frmListaPresenca
            // 
            this.AcceptButton = this.btnIns;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(692, 477);
            this.Controls.Add(this.lblCodUsuarioFecha);
            this.Controls.Add(this.lblCodUsuarioAbertura);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlPreTeste);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmListaPresenca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Irmãos(ãs) presentes na Reunião";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmListaPresenca_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmListaPresenca_FormClosed);
            this.Load += new System.EventHandler(this.frmListaPresenca_Load);
            this.pnlPreTeste.ResumeLayout(false);
            this.gpoPessoa.ResumeLayout(false);
            this.gpoPessoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLista)).EndInit();
            this.gpoReuniao.ResumeLayout(false);
            this.gpoReuniao.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipPreTeste;
        private System.Windows.Forms.Panel pnlPreTeste;
        private System.Windows.Forms.Button btnPessoa;
        private BLL.validacoes.Controles.TextBoxPersonal txtPessoa;
        private System.Windows.Forms.Label lblPessoa;
        private System.Windows.Forms.Label lbPessoa;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox gpoReuniao;
        private System.Windows.Forms.Label lbLocal;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraReuniao;
        private System.Windows.Forms.Label lblDataReuniao;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataReuniao;
        private System.Windows.Forms.Label lblCodUsuarioAbertura;
        private System.Windows.Forms.Label lblCodUsuarioFecha;
        private BLL.validacoes.Controles.TextBoxPersonal txtLocal;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodReuniao;
        private System.Windows.Forms.Label lblReuniao;
        private BLL.validacoes.Controles.TextBoxPersonal txtTipo;
        private System.Windows.Forms.Label lblTipo;
        private BLL.validacoes.Controles.TextBoxPersonal txtComum;
        private System.Windows.Forms.Label lblComum;
        private BLL.validacoes.Controles.TextBoxPersonal txtCargo;
        private System.Windows.Forms.Label lblCargo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCpf;
        private System.Windows.Forms.Label lblCpf;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataNasc;
        private System.Windows.Forms.Label lblDataNasc;
        private BLL.validacoes.Controles.TextBoxPersonal txtCidade;
        private System.Windows.Forms.Label lblCidade;
        private BLL.validacoes.Controles.TextBoxPersonal txtTelefone;
        private System.Windows.Forms.Label lblTelefone;
        private BLL.validacoes.Controles.DataGridViewPersonal gridLista;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.GroupBox gpoPessoa;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.Button btnRetornar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblCodListaPresenca;
        private System.Windows.Forms.Button btnPrevia;
    }
}