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
            this.txtDescricaoSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblDescricaoSucesso = new System.Windows.Forms.Label();
            this.lblCodigoSucesso = new System.Windows.Forms.Label();
            this.txtCodUsuarioSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtCodigoSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblCadastroSucesso = new System.Windows.Forms.Label();
            this.txtDataImportaSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtHoraImportaSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtUsuarioSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblUsuarioSucesso = new System.Windows.Forms.Label();
            this.gridSucesso = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.btnFechar = new System.Windows.Forms.Button();
            this.lblQtdeSucesso = new System.Windows.Forms.Label();
            this.txtQtdeSucesso = new BLL.validacoes.Controles.TextBoxPersonal();
            this.lblQtdeErro = new System.Windows.Forms.Label();
            this.txtQtdeErro = new BLL.validacoes.Controles.TextBoxPersonal();
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
            this.tabSucesso.Controls.Add(this.txtDescricaoSucesso);
            this.tabSucesso.Controls.Add(this.lblDescricaoSucesso);
            this.tabSucesso.Controls.Add(this.lblCodigoSucesso);
            this.tabSucesso.Controls.Add(this.txtCodUsuarioSucesso);
            this.tabSucesso.Controls.Add(this.txtCodigoSucesso);
            this.tabSucesso.Controls.Add(this.lblCadastroSucesso);
            this.tabSucesso.Controls.Add(this.txtDataImportaSucesso);
            this.tabSucesso.Controls.Add(this.txtHoraImportaSucesso);
            this.tabSucesso.Controls.Add(this.txtUsuarioSucesso);
            this.tabSucesso.Controls.Add(this.lblUsuarioSucesso);
            this.tabSucesso.Controls.Add(this.gridSucesso);
            this.tabSucesso.Location = new System.Drawing.Point(4, 22);
            this.tabSucesso.Name = "tabSucesso";
            this.tabSucesso.Padding = new System.Windows.Forms.Padding(3);
            this.tabSucesso.Size = new System.Drawing.Size(828, 391);
            this.tabSucesso.TabIndex = 0;
            this.tabSucesso.Text = "Registros Importados com Sucesso";
            // 
            // txtDescricaoSucesso
            // 
            this.txtDescricaoSucesso.BackColor = System.Drawing.Color.LightYellow;
            this.txtDescricaoSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricaoSucesso.Enabled = false;
            this.txtDescricaoSucesso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtDescricaoSucesso.Location = new System.Drawing.Point(177, 7);
            this.txtDescricaoSucesso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDescricaoSucesso.MaxLength = 150;
            this.txtDescricaoSucesso.Name = "txtDescricaoSucesso";
            this.txtDescricaoSucesso.Size = new System.Drawing.Size(140, 21);
            this.txtDescricaoSucesso.TabIndex = 77;
            this.txtDescricaoSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblDescricaoSucesso
            // 
            this.lblDescricaoSucesso.AutoSize = true;
            this.lblDescricaoSucesso.Enabled = false;
            this.lblDescricaoSucesso.Location = new System.Drawing.Point(121, 11);
            this.lblDescricaoSucesso.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblDescricaoSucesso.Name = "lblDescricaoSucesso";
            this.lblDescricaoSucesso.Size = new System.Drawing.Size(57, 13);
            this.lblDescricaoSucesso.TabIndex = 78;
            this.lblDescricaoSucesso.Text = "Descrição:";
            // 
            // lblCodigoSucesso
            // 
            this.lblCodigoSucesso.AutoSize = true;
            this.lblCodigoSucesso.Enabled = false;
            this.lblCodigoSucesso.Location = new System.Drawing.Point(11, 12);
            this.lblCodigoSucesso.Name = "lblCodigoSucesso";
            this.lblCodigoSucesso.Size = new System.Drawing.Size(44, 13);
            this.lblCodigoSucesso.TabIndex = 69;
            this.lblCodigoSucesso.Text = "Código:";
            // 
            // txtCodUsuarioSucesso
            // 
            this.txtCodUsuarioSucesso.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodUsuarioSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodUsuarioSucesso.Enabled = false;
            this.txtCodUsuarioSucesso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtCodUsuarioSucesso.Location = new System.Drawing.Point(595, 8);
            this.txtCodUsuarioSucesso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodUsuarioSucesso.MaxLength = 150;
            this.txtCodUsuarioSucesso.Name = "txtCodUsuarioSucesso";
            this.txtCodUsuarioSucesso.Size = new System.Drawing.Size(48, 21);
            this.txtCodUsuarioSucesso.TabIndex = 76;
            this.txtCodUsuarioSucesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodUsuarioSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // txtCodigoSucesso
            // 
            this.txtCodigoSucesso.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodigoSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoSucesso.Enabled = false;
            this.txtCodigoSucesso.Location = new System.Drawing.Point(57, 8);
            this.txtCodigoSucesso.Name = "txtCodigoSucesso";
            this.txtCodigoSucesso.Size = new System.Drawing.Size(57, 21);
            this.txtCodigoSucesso.TabIndex = 70;
            this.txtCodigoSucesso.Text = "000000";
            this.txtCodigoSucesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCodigoSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblCadastroSucesso
            // 
            this.lblCadastroSucesso.AutoSize = true;
            this.lblCadastroSucesso.Enabled = false;
            this.lblCadastroSucesso.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCadastroSucesso.Location = new System.Drawing.Point(327, 12);
            this.lblCadastroSucesso.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCadastroSucesso.Name = "lblCadastroSucesso";
            this.lblCadastroSucesso.Size = new System.Drawing.Size(92, 13);
            this.lblCadastroSucesso.TabIndex = 73;
            this.lblCadastroSucesso.Text = "Data Importação:";
            // 
            // txtDataImportaSucesso
            // 
            this.txtDataImportaSucesso.BackColor = System.Drawing.Color.White;
            this.txtDataImportaSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataImportaSucesso.Enabled = false;
            this.txtDataImportaSucesso.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtDataImportaSucesso.Location = new System.Drawing.Point(419, 8);
            this.txtDataImportaSucesso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDataImportaSucesso.Name = "txtDataImportaSucesso";
            this.txtDataImportaSucesso.Size = new System.Drawing.Size(73, 21);
            this.txtDataImportaSucesso.TabIndex = 71;
            this.txtDataImportaSucesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDataImportaSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            // 
            // txtHoraImportaSucesso
            // 
            this.txtHoraImportaSucesso.BackColor = System.Drawing.Color.White;
            this.txtHoraImportaSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHoraImportaSucesso.Enabled = false;
            this.txtHoraImportaSucesso.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtHoraImportaSucesso.Location = new System.Drawing.Point(496, 8);
            this.txtHoraImportaSucesso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtHoraImportaSucesso.Name = "txtHoraImportaSucesso";
            this.txtHoraImportaSucesso.Size = new System.Drawing.Size(38, 21);
            this.txtHoraImportaSucesso.TabIndex = 72;
            this.txtHoraImportaSucesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoraImportaSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Hora;
            // 
            // txtUsuarioSucesso
            // 
            this.txtUsuarioSucesso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuarioSucesso.BackColor = System.Drawing.Color.LightYellow;
            this.txtUsuarioSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioSucesso.Enabled = false;
            this.txtUsuarioSucesso.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtUsuarioSucesso.Location = new System.Drawing.Point(647, 8);
            this.txtUsuarioSucesso.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtUsuarioSucesso.MaxLength = 150;
            this.txtUsuarioSucesso.Name = "txtUsuarioSucesso";
            this.txtUsuarioSucesso.Size = new System.Drawing.Size(160, 21);
            this.txtUsuarioSucesso.TabIndex = 75;
            this.txtUsuarioSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblUsuarioSucesso
            // 
            this.lblUsuarioSucesso.AutoSize = true;
            this.lblUsuarioSucesso.Enabled = false;
            this.lblUsuarioSucesso.Location = new System.Drawing.Point(546, 12);
            this.lblUsuarioSucesso.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblUsuarioSucesso.Name = "lblUsuarioSucesso";
            this.lblUsuarioSucesso.Size = new System.Drawing.Size(47, 13);
            this.lblUsuarioSucesso.TabIndex = 74;
            this.lblUsuarioSucesso.Text = "Usuário:";
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
            this.lblQtdeSucesso.Location = new System.Drawing.Point(98, 438);
            this.lblQtdeSucesso.Name = "lblQtdeSucesso";
            this.lblQtdeSucesso.Size = new System.Drawing.Size(130, 13);
            this.lblQtdeSucesso.TabIndex = 66;
            this.lblQtdeSucesso.Text = "Importados com Sucesso:";
            // 
            // txtQtdeSucesso
            // 
            this.txtQtdeSucesso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtdeSucesso.BackColor = System.Drawing.Color.LightGray;
            this.txtQtdeSucesso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdeSucesso.Enabled = false;
            this.txtQtdeSucesso.Location = new System.Drawing.Point(230, 434);
            this.txtQtdeSucesso.Name = "txtQtdeSucesso";
            this.txtQtdeSucesso.Size = new System.Drawing.Size(52, 21);
            this.txtQtdeSucesso.TabIndex = 67;
            this.txtQtdeSucesso.Text = "000000";
            this.txtQtdeSucesso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeSucesso.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // lblQtdeErro
            // 
            this.lblQtdeErro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQtdeErro.AutoSize = true;
            this.lblQtdeErro.Enabled = false;
            this.lblQtdeErro.Location = new System.Drawing.Point(328, 438);
            this.lblQtdeErro.Name = "lblQtdeErro";
            this.lblQtdeErro.Size = new System.Drawing.Size(111, 13);
            this.lblQtdeErro.TabIndex = 68;
            this.lblQtdeErro.Text = "Importados com Erro:";
            // 
            // txtQtdeErro
            // 
            this.txtQtdeErro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtdeErro.BackColor = System.Drawing.Color.LightGray;
            this.txtQtdeErro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtdeErro.Enabled = false;
            this.txtQtdeErro.Location = new System.Drawing.Point(441, 434);
            this.txtQtdeErro.Name = "txtQtdeErro";
            this.txtQtdeErro.Size = new System.Drawing.Size(52, 21);
            this.txtQtdeErro.TabIndex = 69;
            this.txtQtdeErro.Text = "000000";
            this.txtQtdeErro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtdeErro.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // frmImportarPessoaSucesso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(848, 466);
            this.Controls.Add(this.lblQtdeErro);
            this.Controls.Add(this.txtQtdeErro);
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
        private System.Windows.Forms.Label lblQtdeErro;
        private BLL.validacoes.Controles.TextBoxPersonal txtQtdeErro;
        private BLL.validacoes.Controles.DataGridViewPersonal gridSucesso;
        private System.Windows.Forms.Label lblCodigoSucesso;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodUsuarioSucesso;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigoSucesso;
        private System.Windows.Forms.Label lblCadastroSucesso;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataImportaSucesso;
        private BLL.validacoes.Controles.TextBoxPersonal txtHoraImportaSucesso;
        private BLL.validacoes.Controles.TextBoxPersonal txtUsuarioSucesso;
        private System.Windows.Forms.Label lblUsuarioSucesso;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricaoSucesso;
        private System.Windows.Forms.Label lblDescricaoSucesso;
    }
}