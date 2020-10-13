namespace ccbaju
{
    partial class frmNovidade
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNovidade));
            this.tipNovidade = new System.Windows.Forms.ToolTip(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.cboStatus = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.cboTipoAtualiza = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboAndamento = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.btnPrograma = new System.Windows.Forms.Button();
            this.txtPrograma = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlNovidade = new System.Windows.Forms.Panel();
            this.txtData = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblData = new System.Windows.Forms.Label();
            this.lblPrograma = new System.Windows.Forms.Label();
            this.lbPrograma = new System.Windows.Forms.Label();
            this.lblAndamento = new System.Windows.Forms.Label();
            this.lblTipoAtualiza = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlNovidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(320, 242);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "&Salvar";
            this.tipNovidade.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(414, 242);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "&Cancelar";
            this.tipNovidade.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.Silver;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Location = new System.Drawing.Point(77, 13);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(45, 21);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.Text = "000000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipNovidade.SetToolTip(this.txtCodigo, "Código");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "Correção de Erros",
            "Melhorias Internas",
            "Novos Recursos"});
            this.cboStatus.Location = new System.Drawing.Point(77, 39);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(137, 21);
            this.cboStatus.TabIndex = 3;
            this.tipNovidade.SetToolTip(this.cboStatus, "Selecione o status");
            this.cboStatus.SelectedIndexChanged += new System.EventHandler(this.cboStatus_SelectedIndexChanged);
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(77, 121);
            this.txtDescricao.MaxLength = 2000;
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(400, 85);
            this.txtDescricao.TabIndex = 2;
            this.tipNovidade.SetToolTip(this.txtDescricao, "Descreva com detalhe a novidade");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // cboTipoAtualiza
            // 
            this.cboTipoAtualiza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAtualiza.FormattingEnabled = true;
            this.cboTipoAtualiza.Items.AddRange(new object[] {
            "Versão",
            "Módulos",
            "Base de Dados"});
            this.cboTipoAtualiza.Location = new System.Drawing.Point(348, 39);
            this.cboTipoAtualiza.Name = "cboTipoAtualiza";
            this.cboTipoAtualiza.Size = new System.Drawing.Size(129, 21);
            this.cboTipoAtualiza.TabIndex = 112;
            this.tipNovidade.SetToolTip(this.cboTipoAtualiza, "Selecione o tipo de atualização");
            // 
            // cboAndamento
            // 
            this.cboAndamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAndamento.FormattingEnabled = true;
            this.cboAndamento.Items.AddRange(new object[] {
            "A Implementar",
            "Em Teste",
            "Aprovada",
            "Publicada"});
            this.cboAndamento.Location = new System.Drawing.Point(77, 66);
            this.cboAndamento.Name = "cboAndamento";
            this.cboAndamento.Size = new System.Drawing.Size(137, 21);
            this.cboAndamento.TabIndex = 114;
            this.tipNovidade.SetToolTip(this.cboAndamento, "Selecione o andamento do projeto");
            // 
            // btnPrograma
            // 
            this.btnPrograma.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrograma.Image = ((System.Drawing.Image)(resources.GetObject("btnPrograma.Image")));
            this.btnPrograma.Location = new System.Drawing.Point(125, 92);
            this.btnPrograma.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPrograma.Name = "btnPrograma";
            this.btnPrograma.Size = new System.Drawing.Size(23, 23);
            this.btnPrograma.TabIndex = 118;
            this.tipNovidade.SetToolTip(this.btnPrograma, "Buscar programa");
            this.btnPrograma.UseVisualStyleBackColor = true;
            this.btnPrograma.Click += new System.EventHandler(this.btnPrograma_Click);
            // 
            // txtPrograma
            // 
            this.txtPrograma.BackColor = System.Drawing.Color.White;
            this.txtPrograma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrograma.Location = new System.Drawing.Point(77, 93);
            this.txtPrograma.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtPrograma.MaxLength = 6;
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(45, 21);
            this.txtPrograma.TabIndex = 116;
            this.txtPrograma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipNovidade.SetToolTip(this.txtPrograma, "Código do programa ou clique na lupa para buscar");
            this.txtPrograma.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtPrograma.Enter += new System.EventHandler(this.txtPrograma_Enter);
            this.txtPrograma.Leave += new System.EventHandler(this.txtPrograma_Leave);
            // 
            // pnlNovidade
            // 
            this.pnlNovidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlNovidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNovidade.Controls.Add(this.txtData);
            this.pnlNovidade.Controls.Add(this.lblData);
            this.pnlNovidade.Controls.Add(this.lblPrograma);
            this.pnlNovidade.Controls.Add(this.btnPrograma);
            this.pnlNovidade.Controls.Add(this.txtPrograma);
            this.pnlNovidade.Controls.Add(this.lbPrograma);
            this.pnlNovidade.Controls.Add(this.lblAndamento);
            this.pnlNovidade.Controls.Add(this.cboAndamento);
            this.pnlNovidade.Controls.Add(this.lblTipoAtualiza);
            this.pnlNovidade.Controls.Add(this.cboTipoAtualiza);
            this.pnlNovidade.Controls.Add(this.txtDescricao);
            this.pnlNovidade.Controls.Add(this.lblDescricao);
            this.pnlNovidade.Controls.Add(this.txtCodigo);
            this.pnlNovidade.Controls.Add(this.lblStatus);
            this.pnlNovidade.Controls.Add(this.cboStatus);
            this.pnlNovidade.Controls.Add(this.lblCodigo);
            this.pnlNovidade.Location = new System.Drawing.Point(10, 10);
            this.pnlNovidade.Name = "pnlNovidade";
            this.pnlNovidade.Size = new System.Drawing.Size(494, 226);
            this.pnlNovidade.TabIndex = 0;
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.LightGray;
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtData.Enabled = false;
            this.txtData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtData.Location = new System.Drawing.Point(348, 11);
            this.txtData.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(129, 21);
            this.txtData.TabIndex = 120;
            this.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtData.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Enabled = false;
            this.lblData.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblData.Location = new System.Drawing.Point(240, 13);
            this.lblData.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(92, 13);
            this.lblData.TabIndex = 121;
            this.lblData.Text = "Data de inserção:";
            // 
            // lblPrograma
            // 
            this.lblPrograma.Location = new System.Drawing.Point(155, 96);
            this.lblPrograma.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(315, 15);
            this.lblPrograma.TabIndex = 119;
            // 
            // lbPrograma
            // 
            this.lbPrograma.AutoSize = true;
            this.lbPrograma.Location = new System.Drawing.Point(12, 97);
            this.lbPrograma.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbPrograma.Name = "lbPrograma";
            this.lbPrograma.Size = new System.Drawing.Size(57, 13);
            this.lbPrograma.TabIndex = 117;
            this.lbPrograma.Text = "Programa:";
            // 
            // lblAndamento
            // 
            this.lblAndamento.AutoSize = true;
            this.lblAndamento.Location = new System.Drawing.Point(10, 70);
            this.lblAndamento.Name = "lblAndamento";
            this.lblAndamento.Size = new System.Drawing.Size(66, 13);
            this.lblAndamento.TabIndex = 115;
            this.lblAndamento.Text = "Andamento:";
            // 
            // lblTipoAtualiza
            // 
            this.lblTipoAtualiza.AutoSize = true;
            this.lblTipoAtualiza.Location = new System.Drawing.Point(240, 43);
            this.lblTipoAtualiza.Name = "lblTipoAtualiza";
            this.lblTipoAtualiza.Size = new System.Drawing.Size(104, 13);
            this.lblTipoAtualiza.TabIndex = 113;
            this.lblTipoAtualiza.Text = "Tipo de Atualização:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(10, 123);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(56, 13);
            this.lblDescricao.TabIndex = 111;
            this.lblDescricao.Text = "Novidade:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(10, 43);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(42, 13);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Status:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Location = new System.Drawing.Point(10, 17);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 13;
            this.lblCodigo.Text = "Código:";
            // 
            // frmNovidade
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(511, 280);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlNovidade);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNovidade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novidades";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNovidade_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmNovidade_FormClosed);
            this.Load += new System.EventHandler(this.frmNovidade_Load);
            this.pnlNovidade.ResumeLayout(false);
            this.pnlNovidade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipNovidade;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlNovidade;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Label lblStatus;
        private BLL.validacoes.Controles.ComboBoxPersonal cboStatus;
        private System.Windows.Forms.Label lblCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblTipoAtualiza;
        private BLL.validacoes.Controles.ComboBoxPersonal cboTipoAtualiza;
        private System.Windows.Forms.Label lblAndamento;
        private BLL.validacoes.Controles.ComboBoxPersonal cboAndamento;
        private System.Windows.Forms.Label lblPrograma;
        private System.Windows.Forms.Button btnPrograma;
        private BLL.validacoes.Controles.TextBoxPersonal txtPrograma;
        private System.Windows.Forms.Label lbPrograma;
        private BLL.validacoes.Controles.TextBoxPersonal txtData;
        private System.Windows.Forms.Label lblData;
    }
}