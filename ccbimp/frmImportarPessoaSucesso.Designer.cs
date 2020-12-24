namespace ccbimp
{
    partial class frmImportarPessoaSucesso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarPessoaSucesso));
            this.tabImportados = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabSucesso = new System.Windows.Forms.TabPage();
            this.cboCCB = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblComum = new System.Windows.Forms.Label();
            this.cboRegiao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegiao = new System.Windows.Forms.Label();
            this.cboRegional = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblRegional = new System.Windows.Forms.Label();
            this.gridSucesso = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblQtdeSucesso = new System.Windows.Forms.Label();
            this.txtQtdeSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.tabImportados.SuspendLayout();
            this.tabSucesso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSucesso)).BeginInit();
            this.SuspendLayout();
            // 
            // tabImportados
            // 
            this.tabImportados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabImportados.Controls.Add(this.tabSucesso);
            this.tabImportados.Location = new System.Drawing.Point(7, 7);
            this.tabImportados.Name = "tabImportados";
            this.tabImportados.SelectedIndex = 0;
            this.tabImportados.Size = new System.Drawing.Size(836, 417);
            this.tabImportados.TabIndex = 0;
            this.tabImportados.SelectedIndexChanged += new System.EventHandler(this.tabImportados_SelectedIndexChanged);
            // 
            // tabSucesso
            // 
            this.tabSucesso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabSucesso.Controls.Add(this.cboCCB);
            this.tabSucesso.Controls.Add(this.lblComum);
            this.tabSucesso.Controls.Add(this.cboRegiao);
            this.tabSucesso.Controls.Add(this.lblRegiao);
            this.tabSucesso.Controls.Add(this.cboRegional);
            this.tabSucesso.Controls.Add(this.lblRegional);
            this.tabSucesso.Controls.Add(this.gridSucesso);
            this.tabSucesso.Location = new System.Drawing.Point(4, 22);
            this.tabSucesso.Name = "tabSucesso";
            this.tabSucesso.Padding = new System.Windows.Forms.Padding(3);
            this.tabSucesso.Size = new System.Drawing.Size(828, 391);
            this.tabSucesso.TabIndex = 0;
            this.tabSucesso.Text = "Registros Importados com Sucesso";
            // 
            // cboCCB
            // 
            this.cboCCB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCCB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCCB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboCCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCCB.FormattingEnabled = true;
            this.cboCCB.Location = new System.Drawing.Point(500, 7);
            this.cboCCB.Name = "cboCCB";
            this.cboCCB.Size = new System.Drawing.Size(297, 21);
            this.cboCCB.TabIndex = 103;
            // 
            // lblComum
            // 
            this.lblComum.AutoSize = true;
            this.lblComum.Location = new System.Drawing.Point(451, 11);
            this.lblComum.Name = "lblComum";
            this.lblComum.Size = new System.Drawing.Size(46, 13);
            this.lblComum.TabIndex = 102;
            this.lblComum.Text = "Comum:";
            // 
            // cboRegiao
            // 
            this.cboRegiao.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegiao.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegiao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboRegiao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegiao.FormattingEnabled = true;
            this.cboRegiao.Location = new System.Drawing.Point(265, 7);
            this.cboRegiao.Name = "cboRegiao";
            this.cboRegiao.Size = new System.Drawing.Size(174, 21);
            this.cboRegiao.TabIndex = 101;
            // 
            // lblRegiao
            // 
            this.lblRegiao.AutoSize = true;
            this.lblRegiao.Location = new System.Drawing.Point(195, 11);
            this.lblRegiao.Name = "lblRegiao";
            this.lblRegiao.Size = new System.Drawing.Size(70, 13);
            this.lblRegiao.TabIndex = 100;
            this.lblRegiao.Text = "Microrregião:";
            // 
            // cboRegional
            // 
            this.cboRegional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRegional.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegional.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cboRegional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRegional.FormattingEnabled = true;
            this.cboRegional.Location = new System.Drawing.Point(63, 7);
            this.cboRegional.Name = "cboRegional";
            this.cboRegional.Size = new System.Drawing.Size(114, 21);
            this.cboRegional.TabIndex = 99;
            // 
            // lblRegional
            // 
            this.lblRegional.AutoSize = true;
            this.lblRegional.Location = new System.Drawing.Point(11, 11);
            this.lblRegional.Name = "lblRegional";
            this.lblRegional.Size = new System.Drawing.Size(52, 13);
            this.lblRegional.TabIndex = 98;
            this.lblRegional.Text = "Regional:";
            // 
            // gridSucesso
            // 
            this.gridSucesso.AllowUserToAddRows = false;
            this.gridSucesso.AllowUserToDeleteRows = false;
            this.gridSucesso.AllowUserToResizeRows = false;
            this.gridSucesso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSucesso.BackgroundColor = System.Drawing.Color.White;
            this.gridSucesso.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSucesso.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSucesso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSucesso.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridSucesso.DisabledCell = null;
            this.gridSucesso.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSucesso.EnableHeadersVisualStyles = false;
            this.gridSucesso.Location = new System.Drawing.Point(3, 37);
            this.gridSucesso.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridSucesso.MultiSelect = false;
            this.gridSucesso.Name = "gridSucesso";
            this.gridSucesso.ReadOnly = true;
            this.gridSucesso.RowHeadersVisible = false;
            this.gridSucesso.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSucesso.RowTemplate.Height = 18;
            this.gridSucesso.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSucesso.Size = new System.Drawing.Size(822, 350);
            this.gridSucesso.TabIndex = 0;
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
            // lblQtdeSucesso
            // 
            this.lblQtdeSucesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtdeSucesso.AutoSize = true;
            this.lblQtdeSucesso.Enabled = false;
            this.lblQtdeSucesso.Location = new System.Drawing.Point(15, 437);
            this.lblQtdeSucesso.Name = "lblQtdeSucesso";
            this.lblQtdeSucesso.Size = new System.Drawing.Size(127, 13);
            this.lblQtdeSucesso.TabIndex = 66;
            this.lblQtdeSucesso.Text = "Quantidade de registros:";
            // 
            // txtQtdeSucesso
            // 
            this.txtQtdeSucesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtdeSucesso.BackColor = System.Drawing.Color.LightGray;
            this.txtQtdeSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdeSucesso.Enabled = false;
            this.txtQtdeSucesso.Location = new System.Drawing.Point(147, 433);
            this.txtQtdeSucesso.Name = "txtQtdeSucesso";
            this.txtQtdeSucesso.Size = new System.Drawing.Size(52, 21);
            this.txtQtdeSucesso.TabIndex = 67;
            this.txtQtdeSucesso.Text = "000000";
            this.txtQtdeSucesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // frmImportarPessoaSucesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(848, 466);
            this.Controls.Add(this.lblQtdeSucesso);
            this.Controls.Add(this.txtQtdeSucesso);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.tabImportados);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(723, 366);
            this.Name = "frmImportarPessoaSucesso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pessoas Importadas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmImportarPessoaSucesso_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportarPessoaSucesso_FormClosed);
            this.tabImportados.ResumeLayout(false);
            this.tabSucesso.ResumeLayout(false);
            this.tabSucesso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSucesso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BLL.validacoes.Controles.tabControlPersonal tabImportados;
        private System.Windows.Forms.TabPage tabSucesso;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblQtdeSucesso;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtdeSucesso;
        private BLL.validacoes.Controles.DataGridViewPersonal gridSucesso;
        private BLL.validacoes.Controles.ComboBoxPersonal cboCCB;
        private System.Windows.Forms.Label lblComum;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegiao;
        private System.Windows.Forms.Label lblRegiao;
        private BLL.validacoes.Controles.ComboBoxPersonal cboRegional;
        private System.Windows.Forms.Label lblRegional;
    }
}