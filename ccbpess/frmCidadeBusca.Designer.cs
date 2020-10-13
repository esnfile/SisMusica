namespace ccbpess
{
    partial class frmCidadeBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCidadeBusca));
            this.pnlCidade = new System.Windows.Forms.Panel();
            this.btnVisual = new System.Windows.Forms.Button();
            this.btnIns = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnExc = new System.Windows.Forms.Button();
            this.gridCidade = new System.Windows.Forms.DataGridView();
            this.gpoCidade = new System.Windows.Forms.GroupBox();
            this.txtCep = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCep = new System.Windows.Forms.Label();
            this.cboEstado = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.btnPesq = new System.Windows.Forms.Button();
            this.txtCidade = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblUf = new System.Windows.Forms.Label();
            this.lblCidade = new System.Windows.Forms.Label();
            this.tipCidade = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.txtBairro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblBairro = new System.Windows.Forms.Label();
            this.txtEndereco = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblEndereco = new System.Windows.Forms.Label();
            this.pnlCidade.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCidade)).BeginInit();
            this.gpoCidade.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCidade
            // 
            this.pnlCidade.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCidade.Controls.Add(this.btnVisual);
            this.pnlCidade.Controls.Add(this.btnIns);
            this.pnlCidade.Controls.Add(this.btnEditar);
            this.pnlCidade.Controls.Add(this.btnExc);
            this.pnlCidade.Controls.Add(this.gridCidade);
            this.pnlCidade.Controls.Add(this.gpoCidade);
            this.pnlCidade.Location = new System.Drawing.Point(10, 11);
            this.pnlCidade.Name = "pnlCidade";
            this.pnlCidade.Size = new System.Drawing.Size(630, 412);
            this.pnlCidade.TabIndex = 12;
            // 
            // btnVisual
            // 
            this.btnVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnVisual.Enabled = false;
            this.btnVisual.Location = new System.Drawing.Point(245, 371);
            this.btnVisual.Name = "btnVisual";
            this.btnVisual.Size = new System.Drawing.Size(90, 30);
            this.btnVisual.TabIndex = 6;
            this.btnVisual.Text = "&Visualizar";
            this.btnVisual.UseVisualStyleBackColor = true;
            this.btnVisual.Click += new System.EventHandler(this.btnVisual_Click);
            // 
            // btnIns
            // 
            this.btnIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnIns.Enabled = false;
            this.btnIns.Location = new System.Drawing.Point(340, 371);
            this.btnIns.Name = "btnIns";
            this.btnIns.Size = new System.Drawing.Size(90, 30);
            this.btnIns.TabIndex = 7;
            this.btnIns.Text = "&Inserir";
            this.btnIns.UseVisualStyleBackColor = true;
            this.btnIns.Click += new System.EventHandler(this.btnIns_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditar.Enabled = false;
            this.btnEditar.Location = new System.Drawing.Point(435, 371);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 30);
            this.btnEditar.TabIndex = 8;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnExc
            // 
            this.btnExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExc.Enabled = false;
            this.btnExc.Location = new System.Drawing.Point(530, 371);
            this.btnExc.Name = "btnExc";
            this.btnExc.Size = new System.Drawing.Size(90, 30);
            this.btnExc.TabIndex = 9;
            this.btnExc.Text = "E&xcluir";
            this.btnExc.UseVisualStyleBackColor = true;
            this.btnExc.Click += new System.EventHandler(this.btnExc_Click);
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
            this.gridCidade.Location = new System.Drawing.Point(9, 94);
            this.gridCidade.MultiSelect = false;
            this.gridCidade.Name = "gridCidade";
            this.gridCidade.ReadOnly = true;
            this.gridCidade.RowHeadersVisible = false;
            this.gridCidade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCidade.Size = new System.Drawing.Size(611, 271);
            this.gridCidade.TabIndex = 5;
            this.gridCidade.DataSourceChanged += new System.EventHandler(this.gridCidade_DataSourceChanged);
            this.gridCidade.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCidade_CellDoubleClick);
            this.gridCidade.SelectionChanged += new System.EventHandler(this.gridCidade_SelectionChanged);
            // 
            // gpoCidade
            // 
            this.gpoCidade.Controls.Add(this.txtBairro);
            this.gpoCidade.Controls.Add(this.lblBairro);
            this.gpoCidade.Controls.Add(this.txtEndereco);
            this.gpoCidade.Controls.Add(this.lblEndereco);
            this.gpoCidade.Controls.Add(this.txtCep);
            this.gpoCidade.Controls.Add(this.lblCep);
            this.gpoCidade.Controls.Add(this.cboEstado);
            this.gpoCidade.Controls.Add(this.btnPesq);
            this.gpoCidade.Controls.Add(this.txtCidade);
            this.gpoCidade.Controls.Add(this.lblUf);
            this.gpoCidade.Controls.Add(this.lblCidade);
            this.gpoCidade.Location = new System.Drawing.Point(9, 5);
            this.gpoCidade.Name = "gpoCidade";
            this.gpoCidade.Size = new System.Drawing.Size(611, 83);
            this.gpoCidade.TabIndex = 0;
            this.gpoCidade.TabStop = false;
            this.gpoCidade.Text = "Filtro para pesquisa";
            // 
            // txtCep
            // 
            this.txtCep.BackColor = System.Drawing.Color.White;
            this.txtCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCep.Location = new System.Drawing.Point(71, 20);
            this.txtCep.MaxLength = 80;
            this.txtCep.Name = "txtCep";
            this.txtCep.Size = new System.Drawing.Size(87, 21);
            this.txtCep.TabIndex = 1;
            this.tipCidade.SetToolTip(this.txtCep, "Cep");
            this.txtCep.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Cep;
            this.txtCep.TextChanged += new System.EventHandler(this.txtCep_TextChanged);
            this.txtCep.Enter += new System.EventHandler(this.txtCep_Enter);
            // 
            // lblCep
            // 
            this.lblCep.AutoSize = true;
            this.lblCep.Location = new System.Drawing.Point(14, 24);
            this.lblCep.Name = "lblCep";
            this.lblCep.Size = new System.Drawing.Size(30, 13);
            this.lblCep.TabIndex = 4;
            this.lblCep.Text = "Cep:";
            // 
            // cboEstado
            // 
            this.cboEstado.BackColor = System.Drawing.Color.White;
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(230, 19);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(48, 21);
            this.cboEstado.TabIndex = 2;
            this.tipCidade.SetToolTip(this.cboEstado, "Estado");
            this.cboEstado.Enter += new System.EventHandler(this.cboEstado_Enter);
            // 
            // btnPesq
            // 
            this.btnPesq.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesq.Image = global::ccbpess.Properties.Resources.PesquisaOS;
            this.btnPesq.Location = new System.Drawing.Point(491, 20);
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
            this.txtCidade.Location = new System.Drawing.Point(346, 20);
            this.txtCidade.MaxLength = 80;
            this.txtCidade.Name = "txtCidade";
            this.txtCidade.Size = new System.Drawing.Size(128, 21);
            this.txtCidade.TabIndex = 3;
            this.tipCidade.SetToolTip(this.txtCidade, "Cidade");
            this.txtCidade.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCidade.Enter += new System.EventHandler(this.txtCidade_Enter);
            // 
            // lblUf
            // 
            this.lblUf.AutoSize = true;
            this.lblUf.Location = new System.Drawing.Point(186, 23);
            this.lblUf.Name = "lblUf";
            this.lblUf.Size = new System.Drawing.Size(44, 13);
            this.lblUf.TabIndex = 1;
            this.lblUf.Text = "Estado:";
            // 
            // lblCidade
            // 
            this.lblCidade.AutoSize = true;
            this.lblCidade.Location = new System.Drawing.Point(284, 24);
            this.lblCidade.Name = "lblCidade";
            this.lblCidade.Size = new System.Drawing.Size(61, 13);
            this.lblCidade.TabIndex = 0;
            this.lblCidade.Text = "Localidade:";
            // 
            // tipCidade
            // 
            this.tipCidade.IsBalloon = true;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(550, 429);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 32);
            this.btnFechar.TabIndex = 10;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtBairro
            // 
            this.txtBairro.BackColor = System.Drawing.Color.White;
            this.txtBairro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBairro.Location = new System.Drawing.Point(346, 47);
            this.txtBairro.MaxLength = 80;
            this.txtBairro.Name = "txtBairro";
            this.txtBairro.Size = new System.Drawing.Size(128, 21);
            this.txtBairro.TabIndex = 8;
            this.txtBairro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblBairro
            // 
            this.lblBairro.AutoSize = true;
            this.lblBairro.Location = new System.Drawing.Point(284, 51);
            this.lblBairro.Name = "lblBairro";
            this.lblBairro.Size = new System.Drawing.Size(39, 13);
            this.lblBairro.TabIndex = 10;
            this.lblBairro.Text = "Bairro:";
            // 
            // txtEndereco
            // 
            this.txtEndereco.BackColor = System.Drawing.Color.White;
            this.txtEndereco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndereco.Location = new System.Drawing.Point(71, 47);
            this.txtEndereco.MaxLength = 80;
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(207, 21);
            this.txtEndereco.TabIndex = 7;
            this.txtEndereco.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblEndereco
            // 
            this.lblEndereco.AutoSize = true;
            this.lblEndereco.Location = new System.Drawing.Point(14, 51);
            this.lblEndereco.Name = "lblEndereco";
            this.lblEndereco.Size = new System.Drawing.Size(56, 13);
            this.lblEndereco.TabIndex = 9;
            this.lblEndereco.Text = "Endereço:";
            // 
            // frmCidadeBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(646, 470);
            this.Controls.Add(this.pnlCidade);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCidadeBusca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar Cidades";
            this.Load += new System.EventHandler(this.frmCidadePesquisa_Load);
            this.pnlCidade.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCidade)).EndInit();
            this.gpoCidade.ResumeLayout(false);
            this.gpoCidade.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCidade;
        private System.Windows.Forms.DataGridView gridCidade;
        private System.Windows.Forms.GroupBox gpoCidade;
        private BLL.validacoes.Controles.ComboBoxPersonal cboEstado;
        private System.Windows.Forms.Button btnPesq;
        private BLL.validacoes.Controles.TextBoxPersonal txtCidade;
        private System.Windows.Forms.Label lblUf;
        private System.Windows.Forms.Label lblCidade;
        public System.Windows.Forms.ToolTip tipCidade;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnVisual;
        private System.Windows.Forms.Button btnIns;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnExc;
        private BLL.validacoes.Controles.TextBoxPersonal txtCep;
        private System.Windows.Forms.Label lblCep;
        private BLL.validacoes.Controles.TextBoxPersonal txtBairro;
        private System.Windows.Forms.Label lblBairro;
        private BLL.validacoes.Controles.TextBoxPersonal txtEndereco;
        private System.Windows.Forms.Label lblEndereco;
    }
}