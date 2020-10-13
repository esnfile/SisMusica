﻿namespace ccbimp
{
    partial class frmPesquisaCidadeImp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaCidadeImp));
            this.pnlCidade = new System.Windows.Forms.Panel();
            this.btnSel = new System.Windows.Forms.Button();
            this.gridCidade = new System.Windows.Forms.DataGridView();
            this.gpoCidade = new System.Windows.Forms.GroupBox();
            this.txtEndereco = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.cboEstado = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.btnPesq = new System.Windows.Forms.Button();
            this.txtCidade = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblUf = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.tipCidade = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtBairro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblBairro = new System.Windows.Forms.Label();
            this.pnlCidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCidade)).BeginInit();
            this.gpoCidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCidade
            // 
            this.pnlCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCidade.Controls.Add(this.btnSel);
            this.pnlCidade.Controls.Add(this.gridCidade);
            this.pnlCidade.Controls.Add(this.gpoCidade);
            this.pnlCidade.Location = new System.Drawing.Point(10, 11);
            this.pnlCidade.Name = "pnlCidade";
            this.pnlCidade.Size = new System.Drawing.Size(630, 464);
            this.pnlCidade.TabIndex = 12;
            // 
            // btnSel
            // 
            this.btnSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSel.Enabled = false;
            this.btnSel.Location = new System.Drawing.Point(530, 424);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(90, 32);
            this.btnSel.TabIndex = 6;
            this.btnSel.Text = "&Selecionar";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // gridCidade
            // 
            this.gridCidade.AllowUserToAddRows = false;
            this.gridCidade.AllowUserToDeleteRows = false;
            this.gridCidade.AllowUserToResizeRows = false;
            this.gridCidade.BackgroundColor = System.Drawing.Color.White;
            this.gridCidade.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.gridCidade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCidade.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCidade.EnableHeadersVisualStyles = false;
            this.gridCidade.Location = new System.Drawing.Point(9, 91);
            this.gridCidade.MultiSelect = false;
            this.gridCidade.Name = "gridCidade";
            this.gridCidade.ReadOnly = true;
            this.gridCidade.RowHeadersVisible = false;
            this.gridCidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCidade.Size = new System.Drawing.Size(611, 327);
            this.gridCidade.TabIndex = 5;
            this.gridCidade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCidade_CellDoubleClick);
            this.gridCidade.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCidade_RowStateChanged);
            this.gridCidade.SelectionChanged += new System.EventHandler(this.gridCidade_SelectionChanged);
            // 
            // gpoCidade
            // 
            this.gpoCidade.Controls.Add(this.txtBairro);
            this.gpoCidade.Controls.Add(this.lblBairro);
            this.gpoCidade.Controls.Add(this.txtEndereco);
            this.gpoCidade.Controls.Add(this.lblEndereco);
            this.gpoCidade.Controls.Add(this.cboEstado);
            this.gpoCidade.Controls.Add(this.btnPesq);
            this.gpoCidade.Controls.Add(this.txtCidade);
            this.gpoCidade.Controls.Add(this.lblUf);
            this.gpoCidade.Controls.Add(this.lblCidade);
            this.gpoCidade.Location = new System.Drawing.Point(9, 5);
            this.gpoCidade.Name = "gpoCidade";
            this.gpoCidade.Size = new System.Drawing.Size(611, 80);
            this.gpoCidade.TabIndex = 0;
            this.gpoCidade.TabStop = false;
            this.gpoCidade.Text = "Filtro para pesquisa";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.White;
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndereco.Location = new System.Drawing.Point(66, 46);
            this.txtEndereco.MaxLength = 80;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(228, 21);
            this.txtEndereco.TabIndex = 2;
            this.txtEndereco.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtEndereco.Enter += new System.EventHandler(this.txtEndereco_Enter);
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(9, 50);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(56, 13);
            this.lblEndereco.TabIndex = 4;
            this.lblEndereco.Text = "Endereço:";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.White;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(66, 18);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(62, 21);
            this.cboEstado.TabIndex = 0;
            // 
            // btnPesq
            // 
            this.btnPesq.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesq.Image = global::ccbimp.Properties.Resources.PesquisaOS;
            this.btnPesq.Location = new System.Drawing.Point(486, 19);
            this.btnPesq.Name = "btnPesq";
            this.btnPesq.Size = new System.Drawing.Size(108, 48);
            this.btnPesq.TabIndex = 4;
            this.btnPesq.Text = "&Pesquisar";
            this.btnPesq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesq.UseVisualStyleBackColor = true;
            this.btnPesq.Click += new System.EventHandler(this.btnPesq_Click);
            // 
            // txtCidade
            // 
            this.txtCidade.BackColor = System.Drawing.Color.White;
            this.txtCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCidade.Location = new System.Drawing.Point(201, 19);
            this.txtCidade.MaxLength = 80;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(273, 21);
            this.txtCidade.TabIndex = 1;
            this.txtCidade.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCidade.Enter += new System.EventHandler(this.txtCidade_Enter);
            // 
            // lblUf
            // 
            this.lblUf.AutoSize = true;
            this.lblUf.Location = new System.Drawing.Point(9, 22);
            this.lblUf.Name = "lblUf";
            this.lblUf.Size = new System.Drawing.Size(44, 13);
            this.lblUf.TabIndex = 1;
            this.lblUf.Text = "Estado:";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(139, 22);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(61, 13);
            this.lblCidade.TabIndex = 0;
            this.lblCidade.Text = "Localidade:";
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(550, 481);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 32);
            this.btnFechar.TabIndex = 7;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.White;
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.Location = new System.Drawing.Point(352, 46);
            this.txtBairro.MaxLength = 80;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(122, 21);
            this.txtBairro.TabIndex = 3;
            this.txtBairro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtBairro.Enter += new System.EventHandler(this.txtBairro_Enter);
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(313, 50);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(39, 13);
            this.lblBairro.TabIndex = 6;
            this.lblBairro.Text = "Bairro:";
            // 
            // frmPesquisaCidadeImp
            // 
            this.AcceptButton = this.btnSel;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(646, 522);
            this.Controls.Add(this.pnlCidade);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisaCidadeImp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Cidades";
            this.Activated += new System.EventHandler(this.frmCidadePesquisaImp_Activated);
            this.Load += new System.EventHandler(this.frmCidadePesquisaImp_Load);
            this.pnlCidade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCidade)).EndInit();
            this.gpoCidade.ResumeLayout(false);
            this.gpoCidade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCidade;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.DataGridView gridCidade;
        private System.Windows.Forms.GroupBox gpoCidade;
        private BLL.validacoes.Controles.ComboBoxPersonal cboEstado;
        private System.Windows.Forms.Button btnPesq;
        private BLL.validacoes.Controles.TextBoxPersonal txtCidade;
        private System.Windows.Forms.Label lblUf;
        private System.Windows.Forms.Label lblCidade;
        public System.Windows.Forms.ToolTip tipCidade;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.TextBoxPersonal txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
        private BLL.validacoes.Controles.TextBoxPersonal txtBairro;
        private System.Windows.Forms.Label lblBairro;
    }
}