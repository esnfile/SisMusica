namespace ccbusua
{
    partial class frmRotina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRotina));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlProg = new System.Windows.Forms.Panel();
            this.txtNivelSub = new BLL.validacoes.Controles.TextBoxPersonal();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescSub = new System.Windows.Forms.Label();
            this.txtSubMod = new System.Windows.Forms.TextBox();
            this.lblSubMod = new System.Windows.Forms.Label();
            this.txtNivelMod = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNivelMod = new System.Windows.Forms.Label();
            this.txtNivelProg = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblNivelProg = new System.Windows.Forms.Label();
            this.gpoIndicada = new System.Windows.Forms.GroupBox();
            this.optIndAlta = new System.Windows.Forms.RadioButton();
            this.optIndMed = new System.Windows.Forms.RadioButton();
            this.optIndBai = new System.Windows.Forms.RadioButton();
            this.lblDescInd = new System.Windows.Forms.Label();
            this.gpoSeguranca = new System.Windows.Forms.GroupBox();
            this.optSegAlta = new System.Windows.Forms.RadioButton();
            this.optSegMed = new System.Windows.Forms.RadioButton();
            this.optSegBai = new System.Windows.Forms.RadioButton();
            this.lblDescSeg = new System.Windows.Forms.Label();
            this.txtPrograma = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescMod = new System.Windows.Forms.Label();
            this.lblPrograma = new System.Windows.Forms.Label();
            this.gpoAcao = new System.Windows.Forms.GroupBox();
            this.txtAcao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblMod = new System.Windows.Forms.Label();
            this.optOutra = new System.Windows.Forms.RadioButton();
            this.optImp = new System.Windows.Forms.RadioButton();
            this.optVisual = new System.Windows.Forms.RadioButton();
            this.optCancelar = new System.Windows.Forms.RadioButton();
            this.optExc = new System.Windows.Forms.RadioButton();
            this.optEditar = new System.Windows.Forms.RadioButton();
            this.optIns = new System.Windows.Forms.RadioButton();
            this.btnPrograma = new System.Windows.Forms.Button();
            this.lbPrograma = new System.Windows.Forms.Label();
            this.txtModulo = new System.Windows.Forms.TextBox();
            this.lbModulo = new System.Windows.Forms.Label();
            this.lblNivel = new System.Windows.Forms.Label();
            this.txtNivel = new System.Windows.Forms.NumericUpDown();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCod = new System.Windows.Forms.Label();
            this.tipRotina = new System.Windows.Forms.ToolTip(this.components);
            this.pnlProg.SuspendLayout();
            this.gpoIndicada.SuspendLayout();
            this.gpoSeguranca.SuspendLayout();
            this.gpoAcao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSalvar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.Location = new System.Drawing.Point(305, 329);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(70, 28);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipRotina.SetToolTip(this.btnSalvar, "Salvar");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new System.Drawing.Point(378, 329);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(70, 28);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipRotina.SetToolTip(this.btnCancelar, "Cancelar");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlProg
            // 
            this.pnlProg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlProg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlProg.Controls.Add(this.txtNivelSub);
            this.pnlProg.Controls.Add(this.label1);
            this.pnlProg.Controls.Add(this.lblDescSub);
            this.pnlProg.Controls.Add(this.txtSubMod);
            this.pnlProg.Controls.Add(this.lblSubMod);
            this.pnlProg.Controls.Add(this.txtNivelMod);
            this.pnlProg.Controls.Add(this.lblNivelMod);
            this.pnlProg.Controls.Add(this.txtNivelProg);
            this.pnlProg.Controls.Add(this.lblNivelProg);
            this.pnlProg.Controls.Add(this.gpoIndicada);
            this.pnlProg.Controls.Add(this.gpoSeguranca);
            this.pnlProg.Controls.Add(this.txtPrograma);
            this.pnlProg.Controls.Add(this.lblDescMod);
            this.pnlProg.Controls.Add(this.lblPrograma);
            this.pnlProg.Controls.Add(this.gpoAcao);
            this.pnlProg.Controls.Add(this.btnPrograma);
            this.pnlProg.Controls.Add(this.lbPrograma);
            this.pnlProg.Controls.Add(this.txtModulo);
            this.pnlProg.Controls.Add(this.lbModulo);
            this.pnlProg.Controls.Add(this.lblNivel);
            this.pnlProg.Controls.Add(this.txtNivel);
            this.pnlProg.Controls.Add(this.txtCodigo);
            this.pnlProg.Controls.Add(this.lblCod);
            this.pnlProg.Location = new System.Drawing.Point(5, 6);
            this.pnlProg.Name = "pnlProg";
            this.pnlProg.Size = new System.Drawing.Size(442, 319);
            this.pnlProg.TabIndex = 0;
            // 
            // txtNivelSub
            // 
            this.txtNivelSub.BackColor = System.Drawing.Color.LightGray;
            this.txtNivelSub.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNivelSub.Enabled = false;
            this.txtNivelSub.Location = new System.Drawing.Point(365, 90);
            this.txtNivelSub.MaxLength = 2;
            this.txtNivelSub.Name = "txtNivelSub";
            this.txtNivelSub.Size = new System.Drawing.Size(58, 21);
            this.txtNivelSub.TabIndex = 6;
            this.txtNivelSub.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(332, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nível:";
            // 
            // lblDescSub
            // 
            this.lblDescSub.Enabled = false;
            this.lblDescSub.Location = new System.Drawing.Point(136, 94);
            this.lblDescSub.Name = "lblDescSub";
            this.lblDescSub.Size = new System.Drawing.Size(184, 13);
            this.lblDescSub.TabIndex = 46;
            this.lblDescSub.UseCompatibleTextRendering = true;
            // 
            // txtSubMod
            // 
            this.txtSubMod.BackColor = System.Drawing.Color.LightGray;
            this.txtSubMod.Enabled = false;
            this.txtSubMod.Location = new System.Drawing.Point(84, 90);
            this.txtSubMod.MaxLength = 6;
            this.txtSubMod.Name = "txtSubMod";
            this.txtSubMod.Size = new System.Drawing.Size(46, 21);
            this.txtSubMod.TabIndex = 5;
            this.txtSubMod.Text = "000";
            this.txtSubMod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubMod
            // 
            this.lblSubMod.AutoSize = true;
            this.lblSubMod.Enabled = false;
            this.lblSubMod.Location = new System.Drawing.Point(17, 94);
            this.lblSubMod.Name = "lblSubMod";
            this.lblSubMod.Size = new System.Drawing.Size(67, 13);
            this.lblSubMod.TabIndex = 45;
            this.lblSubMod.Text = "Sub-Módulo:";
            // 
            // txtNivelMod
            // 
            this.txtNivelMod.BackColor = System.Drawing.Color.LightGray;
            this.txtNivelMod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNivelMod.Enabled = false;
            this.txtNivelMod.Location = new System.Drawing.Point(365, 64);
            this.txtNivelMod.MaxLength = 2;
            this.txtNivelMod.Name = "txtNivelMod";
            this.txtNivelMod.Size = new System.Drawing.Size(58, 21);
            this.txtNivelMod.TabIndex = 4;
            this.txtNivelMod.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // lblNivelMod
            // 
            this.lblNivelMod.AutoSize = true;
            this.lblNivelMod.Enabled = false;
            this.lblNivelMod.Location = new System.Drawing.Point(332, 68);
            this.lblNivelMod.Name = "lblNivelMod";
            this.lblNivelMod.Size = new System.Drawing.Size(34, 13);
            this.lblNivelMod.TabIndex = 42;
            this.lblNivelMod.Text = "Nível:";
            // 
            // txtNivelProg
            // 
            this.txtNivelProg.BackColor = System.Drawing.Color.LightGray;
            this.txtNivelProg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNivelProg.Enabled = false;
            this.txtNivelProg.Location = new System.Drawing.Point(365, 38);
            this.txtNivelProg.MaxLength = 4;
            this.txtNivelProg.Name = "txtNivelProg";
            this.txtNivelProg.Size = new System.Drawing.Size(58, 21);
            this.txtNivelProg.TabIndex = 2;
            this.txtNivelProg.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            // 
            // lblNivelProg
            // 
            this.lblNivelProg.AutoSize = true;
            this.lblNivelProg.Enabled = false;
            this.lblNivelProg.Location = new System.Drawing.Point(332, 42);
            this.lblNivelProg.Name = "lblNivelProg";
            this.lblNivelProg.Size = new System.Drawing.Size(34, 13);
            this.lblNivelProg.TabIndex = 40;
            this.lblNivelProg.Text = "Nível:";
            // 
            // gpoIndicada
            // 
            this.gpoIndicada.Controls.Add(this.optIndAlta);
            this.gpoIndicada.Controls.Add(this.optIndMed);
            this.gpoIndicada.Controls.Add(this.optIndBai);
            this.gpoIndicada.Controls.Add(this.lblDescInd);
            this.gpoIndicada.Location = new System.Drawing.Point(336, 225);
            this.gpoIndicada.Name = "gpoIndicada";
            this.gpoIndicada.Size = new System.Drawing.Size(87, 80);
            this.gpoIndicada.TabIndex = 10;
            this.gpoIndicada.TabStop = false;
            this.gpoIndicada.Text = "Indicada";
            // 
            // optIndAlta
            // 
            this.optIndAlta.AutoSize = true;
            this.optIndAlta.Location = new System.Drawing.Point(16, 57);
            this.optIndAlta.Name = "optIndAlta";
            this.optIndAlta.Size = new System.Drawing.Size(44, 17);
            this.optIndAlta.TabIndex = 2;
            this.optIndAlta.TabStop = true;
            this.optIndAlta.Text = "Alta";
            this.optIndAlta.UseVisualStyleBackColor = true;
            this.optIndAlta.Click += new System.EventHandler(this.optIndAlta_Click);
            // 
            // optIndMed
            // 
            this.optIndMed.AutoSize = true;
            this.optIndMed.Location = new System.Drawing.Point(16, 36);
            this.optIndMed.Name = "optIndMed";
            this.optIndMed.Size = new System.Drawing.Size(53, 17);
            this.optIndMed.TabIndex = 1;
            this.optIndMed.TabStop = true;
            this.optIndMed.Text = "Média";
            this.optIndMed.UseVisualStyleBackColor = true;
            this.optIndMed.Click += new System.EventHandler(this.optIndMed_Click);
            // 
            // optIndBai
            // 
            this.optIndBai.AutoSize = true;
            this.optIndBai.Location = new System.Drawing.Point(16, 15);
            this.optIndBai.Name = "optIndBai";
            this.optIndBai.Size = new System.Drawing.Size(51, 17);
            this.optIndBai.TabIndex = 0;
            this.optIndBai.TabStop = true;
            this.optIndBai.Text = "Baixa";
            this.optIndBai.UseVisualStyleBackColor = true;
            this.optIndBai.Click += new System.EventHandler(this.optIndBai_Click);
            // 
            // lblDescInd
            // 
            this.lblDescInd.Location = new System.Drawing.Point(13, 64);
            this.lblDescInd.Name = "lblDescInd";
            this.lblDescInd.Size = new System.Drawing.Size(67, 13);
            this.lblDescInd.TabIndex = 39;
            this.lblDescInd.Visible = false;
            // 
            // gpoSeguranca
            // 
            this.gpoSeguranca.Controls.Add(this.optSegAlta);
            this.gpoSeguranca.Controls.Add(this.optSegMed);
            this.gpoSeguranca.Controls.Add(this.optSegBai);
            this.gpoSeguranca.Controls.Add(this.lblDescSeg);
            this.gpoSeguranca.Location = new System.Drawing.Point(336, 140);
            this.gpoSeguranca.Name = "gpoSeguranca";
            this.gpoSeguranca.Size = new System.Drawing.Size(87, 80);
            this.gpoSeguranca.TabIndex = 9;
            this.gpoSeguranca.TabStop = false;
            this.gpoSeguranca.Text = "Segurança";
            // 
            // optSegAlta
            // 
            this.optSegAlta.AutoSize = true;
            this.optSegAlta.Location = new System.Drawing.Point(16, 58);
            this.optSegAlta.Name = "optSegAlta";
            this.optSegAlta.Size = new System.Drawing.Size(44, 17);
            this.optSegAlta.TabIndex = 2;
            this.optSegAlta.TabStop = true;
            this.optSegAlta.Text = "Alta";
            this.optSegAlta.UseVisualStyleBackColor = true;
            this.optSegAlta.Click += new System.EventHandler(this.optSegAlta_Click);
            // 
            // optSegMed
            // 
            this.optSegMed.AutoSize = true;
            this.optSegMed.Location = new System.Drawing.Point(16, 37);
            this.optSegMed.Name = "optSegMed";
            this.optSegMed.Size = new System.Drawing.Size(53, 17);
            this.optSegMed.TabIndex = 1;
            this.optSegMed.TabStop = true;
            this.optSegMed.Text = "Média";
            this.optSegMed.UseVisualStyleBackColor = true;
            this.optSegMed.Click += new System.EventHandler(this.optSegMed_Click);
            // 
            // optSegBai
            // 
            this.optSegBai.AutoSize = true;
            this.optSegBai.Location = new System.Drawing.Point(16, 16);
            this.optSegBai.Name = "optSegBai";
            this.optSegBai.Size = new System.Drawing.Size(51, 17);
            this.optSegBai.TabIndex = 0;
            this.optSegBai.TabStop = true;
            this.optSegBai.Text = "Baixa";
            this.optSegBai.UseVisualStyleBackColor = true;
            this.optSegBai.Click += new System.EventHandler(this.optSegBai_Click);
            // 
            // lblDescSeg
            // 
            this.lblDescSeg.Location = new System.Drawing.Point(14, 64);
            this.lblDescSeg.Name = "lblDescSeg";
            this.lblDescSeg.Size = new System.Drawing.Size(67, 13);
            this.lblDescSeg.TabIndex = 38;
            this.lblDescSeg.Visible = false;
            // 
            // txtPrograma
            // 
            this.txtPrograma.BackColor = System.Drawing.Color.White;
            this.txtPrograma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrograma.Location = new System.Drawing.Point(84, 38);
            this.txtPrograma.MaxLength = 10;
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(46, 21);
            this.txtPrograma.TabIndex = 0;
            this.txtPrograma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipRotina.SetToolTip(this.txtPrograma, "Pesquisar Programa");
            this.txtPrograma.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Inteiro;
            this.txtPrograma.Leave += new System.EventHandler(this.txtPrograma_Leave);
            // 
            // lblDescMod
            // 
            this.lblDescMod.Enabled = false;
            this.lblDescMod.Location = new System.Drawing.Point(136, 68);
            this.lblDescMod.Name = "lblDescMod";
            this.lblDescMod.Size = new System.Drawing.Size(184, 13);
            this.lblDescMod.TabIndex = 37;
            this.lblDescMod.UseCompatibleTextRendering = true;
            // 
            // lblPrograma
            // 
            this.lblPrograma.Location = new System.Drawing.Point(159, 42);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(161, 13);
            this.lblPrograma.TabIndex = 33;
            this.lblPrograma.UseCompatibleTextRendering = true;
            // 
            // gpoAcao
            // 
            this.gpoAcao.Controls.Add(this.txtAcao);
            this.gpoAcao.Controls.Add(this.lblMod);
            this.gpoAcao.Controls.Add(this.optOutra);
            this.gpoAcao.Controls.Add(this.optImp);
            this.gpoAcao.Controls.Add(this.optVisual);
            this.gpoAcao.Controls.Add(this.optCancelar);
            this.gpoAcao.Controls.Add(this.optExc);
            this.gpoAcao.Controls.Add(this.optEditar);
            this.gpoAcao.Controls.Add(this.optIns);
            this.gpoAcao.Location = new System.Drawing.Point(14, 140);
            this.gpoAcao.Name = "gpoAcao";
            this.gpoAcao.Size = new System.Drawing.Size(306, 165);
            this.gpoAcao.TabIndex = 8;
            this.gpoAcao.TabStop = false;
            this.gpoAcao.Text = "Ações";
            // 
            // txtAcao
            // 
            this.txtAcao.BackColor = System.Drawing.Color.White;
            this.txtAcao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAcao.Enabled = false;
            this.txtAcao.Location = new System.Drawing.Point(16, 136);
            this.txtAcao.MaxLength = 20;
            this.txtAcao.Name = "txtAcao";
            this.txtAcao.Size = new System.Drawing.Size(275, 21);
            this.txtAcao.TabIndex = 7;
            this.tipRotina.SetToolTip(this.txtAcao, "Descrição da ação");
            this.txtAcao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblMod
            // 
            this.lblMod.AutoSize = true;
            this.lblMod.ForeColor = System.Drawing.Color.Red;
            this.lblMod.Location = new System.Drawing.Point(104, 120);
            this.lblMod.Name = "lblMod";
            this.lblMod.Size = new System.Drawing.Size(99, 13);
            this.lblMod.TabIndex = 24;
            this.lblMod.Text = "Descrição da Ação:";
            // 
            // optOutra
            // 
            this.optOutra.AutoSize = true;
            this.optOutra.Location = new System.Drawing.Point(174, 66);
            this.optOutra.Name = "optOutra";
            this.optOutra.Size = new System.Drawing.Size(90, 17);
            this.optOutra.TabIndex = 6;
            this.optOutra.TabStop = true;
            this.optOutra.Text = "Outras Ações";
            this.optOutra.UseVisualStyleBackColor = true;
            this.optOutra.Click += new System.EventHandler(this.optOutra_Click);
            // 
            // optImp
            // 
            this.optImp.AutoSize = true;
            this.optImp.Location = new System.Drawing.Point(174, 43);
            this.optImp.Name = "optImp";
            this.optImp.Size = new System.Drawing.Size(63, 17);
            this.optImp.TabIndex = 5;
            this.optImp.TabStop = true;
            this.optImp.Text = "Imprimir";
            this.optImp.UseVisualStyleBackColor = true;
            this.optImp.Click += new System.EventHandler(this.optImp_Click);
            // 
            // optVisual
            // 
            this.optVisual.AutoSize = true;
            this.optVisual.Location = new System.Drawing.Point(174, 20);
            this.optVisual.Name = "optVisual";
            this.optVisual.Size = new System.Drawing.Size(69, 17);
            this.optVisual.TabIndex = 4;
            this.optVisual.TabStop = true;
            this.optVisual.Text = "Visualizar";
            this.optVisual.UseVisualStyleBackColor = true;
            this.optVisual.Click += new System.EventHandler(this.optVisual_Click);
            // 
            // optCancelar
            // 
            this.optCancelar.AutoSize = true;
            this.optCancelar.Location = new System.Drawing.Point(44, 89);
            this.optCancelar.Name = "optCancelar";
            this.optCancelar.Size = new System.Drawing.Size(67, 17);
            this.optCancelar.TabIndex = 3;
            this.optCancelar.TabStop = true;
            this.optCancelar.Text = "Cancelar";
            this.optCancelar.UseVisualStyleBackColor = true;
            this.optCancelar.Click += new System.EventHandler(this.optCancelar_Click);
            // 
            // optExc
            // 
            this.optExc.AutoSize = true;
            this.optExc.Location = new System.Drawing.Point(44, 66);
            this.optExc.Name = "optExc";
            this.optExc.Size = new System.Drawing.Size(56, 17);
            this.optExc.TabIndex = 2;
            this.optExc.TabStop = true;
            this.optExc.Text = "Excluir";
            this.optExc.UseVisualStyleBackColor = true;
            this.optExc.Click += new System.EventHandler(this.optExc_Click);
            // 
            // optEditar
            // 
            this.optEditar.AutoSize = true;
            this.optEditar.Location = new System.Drawing.Point(44, 43);
            this.optEditar.Name = "optEditar";
            this.optEditar.Size = new System.Drawing.Size(53, 17);
            this.optEditar.TabIndex = 1;
            this.optEditar.TabStop = true;
            this.optEditar.Text = "Editar";
            this.optEditar.UseVisualStyleBackColor = true;
            this.optEditar.Click += new System.EventHandler(this.optEditar_Click);
            // 
            // optIns
            // 
            this.optIns.AutoSize = true;
            this.optIns.Location = new System.Drawing.Point(44, 20);
            this.optIns.Name = "optIns";
            this.optIns.Size = new System.Drawing.Size(56, 17);
            this.optIns.TabIndex = 0;
            this.optIns.TabStop = true;
            this.optIns.Text = "Inserir";
            this.optIns.UseVisualStyleBackColor = true;
            this.optIns.Click += new System.EventHandler(this.optIns_Click);
            // 
            // btnPrograma
            // 
            this.btnPrograma.Image = global::ccbusua.Properties.Resources.Lupa;
            this.btnPrograma.Location = new System.Drawing.Point(133, 37);
            this.btnPrograma.Name = "btnPrograma";
            this.btnPrograma.Size = new System.Drawing.Size(23, 23);
            this.btnPrograma.TabIndex = 1;
            this.tipRotina.SetToolTip(this.btnPrograma, "Pesquisar Programa");
            this.btnPrograma.UseVisualStyleBackColor = true;
            this.btnPrograma.Click += new System.EventHandler(this.btnPrograma_Click);
            // 
            // lbPrograma
            // 
            this.lbPrograma.AutoSize = true;
            this.lbPrograma.Location = new System.Drawing.Point(17, 41);
            this.lbPrograma.Name = "lbPrograma";
            this.lbPrograma.Size = new System.Drawing.Size(57, 13);
            this.lbPrograma.TabIndex = 30;
            this.lbPrograma.Text = "Programa:";
            // 
            // txtModulo
            // 
            this.txtModulo.BackColor = System.Drawing.Color.LightGray;
            this.txtModulo.Enabled = false;
            this.txtModulo.Location = new System.Drawing.Point(84, 64);
            this.txtModulo.MaxLength = 6;
            this.txtModulo.Name = "txtModulo";
            this.txtModulo.Size = new System.Drawing.Size(46, 21);
            this.txtModulo.TabIndex = 3;
            this.txtModulo.Text = "000";
            this.txtModulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbModulo
            // 
            this.lbModulo.AutoSize = true;
            this.lbModulo.Enabled = false;
            this.lbModulo.Location = new System.Drawing.Point(17, 68);
            this.lbModulo.Name = "lbModulo";
            this.lbModulo.Size = new System.Drawing.Size(45, 13);
            this.lbModulo.TabIndex = 26;
            this.lbModulo.Text = "Módulo:";
            // 
            // lblNivel
            // 
            this.lblNivel.AutoSize = true;
            this.lblNivel.Location = new System.Drawing.Point(17, 118);
            this.lblNivel.Name = "lblNivel";
            this.lblNivel.Size = new System.Drawing.Size(34, 13);
            this.lblNivel.TabIndex = 25;
            this.lblNivel.Text = "Nível:";
            // 
            // txtNivel
            // 
            this.txtNivel.BackColor = System.Drawing.Color.White;
            this.txtNivel.Location = new System.Drawing.Point(84, 116);
            this.txtNivel.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.txtNivel.Minimum = new decimal(new int[] {
            100101,
            0,
            0,
            0});
            this.txtNivel.Name = "txtNivel";
            this.txtNivel.Size = new System.Drawing.Size(78, 21);
            this.txtNivel.TabIndex = 7;
            this.txtNivel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNivel.Value = new decimal(new int[] {
            100101,
            0,
            0,
            0});
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(84, 12);
            this.txtCodigo.MaxLength = 10;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(69, 21);
            this.txtCodigo.TabIndex = 21;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCod
            // 
            this.lblCod.AutoSize = true;
            this.lblCod.Location = new System.Drawing.Point(17, 15);
            this.lblCod.Name = "lblCod";
            this.lblCod.Size = new System.Drawing.Size(44, 13);
            this.lblCod.TabIndex = 20;
            this.lblCod.Text = "Código:";
            // 
            // frmRotina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(453, 365);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlProg);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmRotina";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRotina_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRotina_FormClosed);
            this.Load += new System.EventHandler(this.frmRotina_Load);
            this.pnlProg.ResumeLayout(false);
            this.pnlProg.PerformLayout();
            this.gpoIndicada.ResumeLayout(false);
            this.gpoIndicada.PerformLayout();
            this.gpoSeguranca.ResumeLayout(false);
            this.gpoSeguranca.PerformLayout();
            this.gpoAcao.ResumeLayout(false);
            this.gpoAcao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNivel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRotina;
        private BLL.validacoes.Controles.TextBoxPersonal txtNivelSub;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescSub;
        private System.Windows.Forms.TextBox txtSubMod;
        private System.Windows.Forms.Label lblSubMod;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlProg;
        private System.Windows.Forms.Label lblDescMod;
        private System.Windows.Forms.Label lblPrograma;
        private System.Windows.Forms.GroupBox gpoIndicada;
        private System.Windows.Forms.RadioButton optIndAlta;
        private System.Windows.Forms.RadioButton optIndMed;
        private System.Windows.Forms.RadioButton optIndBai;
        private System.Windows.Forms.GroupBox gpoSeguranca;
        private System.Windows.Forms.RadioButton optSegAlta;
        private System.Windows.Forms.RadioButton optSegMed;
        private System.Windows.Forms.RadioButton optSegBai;
        private System.Windows.Forms.GroupBox gpoAcao;
        private System.Windows.Forms.Label lblMod;
        private System.Windows.Forms.RadioButton optOutra;
        private System.Windows.Forms.RadioButton optImp;
        private System.Windows.Forms.RadioButton optVisual;
        private System.Windows.Forms.RadioButton optCancelar;
        private System.Windows.Forms.RadioButton optExc;
        private System.Windows.Forms.RadioButton optEditar;
        private System.Windows.Forms.RadioButton optIns;
        private System.Windows.Forms.Button btnPrograma;
        private System.Windows.Forms.Label lbPrograma;
        private System.Windows.Forms.TextBox txtModulo;
        private System.Windows.Forms.Label lbModulo;
        private System.Windows.Forms.Label lblNivel;
        private System.Windows.Forms.NumericUpDown txtNivel;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCod;
        private BLL.validacoes.Controles.TextBoxPersonal txtPrograma;
        private BLL.validacoes.Controles.TextBoxPersonal txtAcao;
        private System.Windows.Forms.Label lblDescInd;
        private System.Windows.Forms.Label lblDescSeg;
        private BLL.validacoes.Controles.TextBoxPersonal txtNivelMod;
        private System.Windows.Forms.Label lblNivelMod;
        private BLL.validacoes.Controles.TextBoxPersonal txtNivelProg;
        private System.Windows.Forms.Label lblNivelProg;
    }
}