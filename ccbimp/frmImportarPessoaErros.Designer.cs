namespace ccbimp
{
    partial class frmImportarPessoaErros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarPessoaErros));
            this.tabImportados = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabErro = new System.Windows.Forms.TabPage();
            this.cboCCB = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblComum = new System.Windows.Forms.Label();
            this.cboRegiao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegiao = new System.Windows.Forms.Label();
            this.cboRegional = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegional = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.gridErro = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblQtdeErro = new System.Windows.Forms.Label();
            this.txtQtdeErro = new BLL.validacoes.Controles.TextBoxPersonal();
            this.tabImportados.SuspendLayout();
            this.tabErro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErro)).BeginInit();
            this.SuspendLayout();
            // 
            // tabImportados
            // 
            this.tabImportados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabImportados.Controls.Add(this.tabErro);
            this.tabImportados.Location = new System.Drawing.Point(7, 7);
            this.tabImportados.Name = "tabImportados";
            this.tabImportados.SelectedIndex = 0;
            this.tabImportados.Size = new System.Drawing.Size(836, 417);
            this.tabImportados.TabIndex = 0;
            // 
            // tabErro
            // 
            this.tabErro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabErro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabErro.Controls.Add(this.cboCCB);
            this.tabErro.Controls.Add(this.lblComum);
            this.tabErro.Controls.Add(this.cboRegiao);
            this.tabErro.Controls.Add(this.lblRegiao);
            this.tabErro.Controls.Add(this.cboRegional);
            this.tabErro.Controls.Add(this.lblRegional);
            this.tabErro.Controls.Add(this.btnEditar);
            this.tabErro.Controls.Add(this.gridErro);
            this.tabErro.Location = new System.Drawing.Point(4, 22);
            this.tabErro.Name = "tabErro";
            this.tabErro.Padding = new System.Windows.Forms.Padding(3);
            this.tabErro.Size = new System.Drawing.Size(828, 391);
            this.tabErro.TabIndex = 1;
            this.tabErro.Text = "Registros com Erros na Importação";
            // 
            // cboCCB
            // 
            this.cboCCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCCB.FormattingEnabled = true;
            this.cboCCB.Location = new System.Drawing.Point(505, 9);
            this.cboCCB.Name = "cboCCB";
            this.cboCCB.Size = new System.Drawing.Size(297, 21);
            this.cboCCB.TabIndex = 97;
            this.cboCCB.SelectionChangeCommitted += new System.EventHandler(this.cboCCB_SelectionChangeCommitted);
            // 
            // lblComum
            // 
            this.lblComum.AutoSize = true;
            this.lblComum.Location = new System.Drawing.Point(456, 13);
            this.lblComum.Name = "lblComum";
            this.lblComum.Size = new System.Drawing.Size(46, 13);
            this.lblComum.TabIndex = 96;
            this.lblComum.Text = "Comum:";
            // 
            // cboRegiao
            // 
            this.cboRegiao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegiao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboRegiao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegiao.FormattingEnabled = true;
            this.cboRegiao.Location = new System.Drawing.Point(270, 9);
            this.cboRegiao.Name = "cboRegiao";
            this.cboRegiao.Size = new System.Drawing.Size(174, 21);
            this.cboRegiao.TabIndex = 90;
            this.cboRegiao.SelectionChangeCommitted += new System.EventHandler(this.cboRegiao_SelectionChangeCommitted);
            // 
            // lblRegiao
            // 
            this.lblRegiao.AutoSize = true;
            this.lblRegiao.Location = new System.Drawing.Point(200, 13);
            this.lblRegiao.Name = "lblRegiao";
            this.lblRegiao.Size = new System.Drawing.Size(70, 13);
            this.lblRegiao.TabIndex = 89;
            this.lblRegiao.Text = "Microrregião:";
            // 
            // cboRegional
            // 
            this.cboRegional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegional.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboRegional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegional.FormattingEnabled = true;
            this.cboRegional.Location = new System.Drawing.Point(68, 9);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(114, 21);
            this.cboRegional.TabIndex = 88;
            this.cboRegional.SelectionChangeCommitted += new System.EventHandler(this.cboRegional_SelectionChangeCommitted);
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.Location = new System.Drawing.Point(16, 13);
            this.lblRegional.Name = "lblRegional";
            this.lblRegional.Size = new System.Drawing.Size(52, 13);
            this.lblRegional.TabIndex = 87;
            this.lblRegional.Text = "Regional:";
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.Location = new System.Drawing.Point(733, 358);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 25);
            this.btnEditar.TabIndex = 86;
            this.btnEditar.Text = "&Editar erros";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // gridErro
            // 
            this.gridErro.AllowUserToAddRows = false;
            this.gridErro.AllowUserToDeleteRows = false;
            this.gridErro.AllowUserToResizeRows = false;
            this.gridErro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridErro.BackgroundColor = System.Drawing.Color.White;
            this.gridErro.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridErro.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridErro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridErro.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridErro.DisabledCell = null;
            this.gridErro.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridErro.EnableHeadersVisualStyles = false;
            this.gridErro.Location = new System.Drawing.Point(3, 39);
            this.gridErro.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridErro.MultiSelect = false;
            this.gridErro.Name = "gridErro";
            this.gridErro.ReadOnly = true;
            this.gridErro.RowHeadersVisible = false;
            this.gridErro.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridErro.RowTemplate.Height = 18;
            this.gridErro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridErro.Size = new System.Drawing.Size(820, 316);
            this.gridErro.TabIndex = 1;
            this.gridErro.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridErro_DataBindingComplete);
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFechar.Location = new System.Drawing.Point(753, 429);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 40;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // lblQtdeErro
            // 
            this.lblQtdeErro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtdeErro.AutoSize = true;
            this.lblQtdeErro.Enabled = false;
            this.lblQtdeErro.Location = new System.Drawing.Point(13, 437);
            this.lblQtdeErro.Name = "lblQtdeErro";
            this.lblQtdeErro.Size = new System.Drawing.Size(127, 13);
            this.lblQtdeErro.TabIndex = 68;
            this.lblQtdeErro.Text = "Quantidade de registros:";
            // 
            // txtQtdeErro
            // 
            this.txtQtdeErro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtdeErro.BackColor = System.Drawing.Color.LightGray;
            this.txtQtdeErro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdeErro.Enabled = false;
            this.txtQtdeErro.Location = new System.Drawing.Point(144, 433);
            this.txtQtdeErro.Name = "txtQtdeErro";
            this.txtQtdeErro.Size = new System.Drawing.Size(52, 21);
            this.txtQtdeErro.TabIndex = 69;
            this.txtQtdeErro.Text = "000000";
            this.txtQtdeErro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeErro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // frmImportarPessoaErros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(848, 466);
            this.Controls.Add(this.lblQtdeErro);
            this.Controls.Add(this.txtQtdeErro);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.tabImportados);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(723, 366);
            this.Name = "frmImportarPessoaErros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pessoas Importadas com Erros (Ainda não estão na base de dados)";
            this.Activated += new System.EventHandler(this.frmImportarPessoaErros_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImportarPessoaErros_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportarPessoaErros_FormClosed);
            this.Load += new System.EventHandler(this.frmImportarPessoaErros_Load);
            this.tabImportados.ResumeLayout(false);
            this.tabErro.ResumeLayout(false);
            this.tabErro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridErro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BLL.validacoes.Controles.tabControlPersonal tabImportados;
        private System.Windows.Forms.TabPage tabErro;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblQtdeErro;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtdeErro;
        private BLL.validacoes.Controles.DataGridViewPersonal gridErro;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblRegional;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegional;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegiao;
        private System.Windows.Forms.Label lblRegiao;
        private BLL.validacoes.Controles.ComboBoxPersonal cboCCB;
        private System.Windows.Forms.Label lblComum;
    }
}