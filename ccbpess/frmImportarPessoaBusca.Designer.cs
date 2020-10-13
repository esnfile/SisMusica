namespace ccbpess
{
    partial class frmImportarPessoaBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarPessoaBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipRegiao = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnData = new System.Windows.Forms.Button();
            this.btnDataIns = new System.Windows.Forms.Button();
            this.btnDataVisual = new System.Windows.Forms.Button();
            this.txtDataFinal = new BLL.validacoes.Controles.TextBoxPersonal();
            this.txtDataInicial = new BLL.validacoes.Controles.TextBoxPersonal();
            this.tabImportar = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabData = new System.Windows.Forms.TabPage();
            this.lblA = new System.Windows.Forms.Label();
            this.gridData = new System.Windows.Forms.DataGridView();
            this.tabImportar.SuspendLayout();
            this.tabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(514, 405);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnData
            // 
            this.btnData.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnData.Image = ((System.Drawing.Image)(resources.GetObject("btnData.Image")));
            this.btnData.Location = new System.Drawing.Point(171, 5);
            this.btnData.Name = "btnData";
            this.btnData.Size = new System.Drawing.Size(23, 23);
            this.btnData.TabIndex = 1;
            this.tipRegiao.SetToolTip(this.btnData, "Pesquisar");
            this.btnData.UseVisualStyleBackColor = true;
            this.btnData.Click += new System.EventHandler(this.btnData_Click);
            // 
            // btnDataIns
            // 
            this.btnDataIns.AccessibleDescription = "";
            this.btnDataIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataIns.Enabled = false;
            this.btnDataIns.Location = new System.Drawing.Point(487, 323);
            this.btnDataIns.Name = "btnDataIns";
            this.btnDataIns.Size = new System.Drawing.Size(90, 30);
            this.btnDataIns.TabIndex = 4;
            this.btnDataIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnDataIns, "Inserir");
            this.btnDataIns.UseVisualStyleBackColor = true;
            this.btnDataIns.Click += new System.EventHandler(this.btnDataIns_Click);
            // 
            // btnDataVisual
            // 
            this.btnDataVisual.AccessibleDescription = "";
            this.btnDataVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDataVisual.Enabled = false;
            this.btnDataVisual.Location = new System.Drawing.Point(393, 323);
            this.btnDataVisual.Name = "btnDataVisual";
            this.btnDataVisual.Size = new System.Drawing.Size(90, 30);
            this.btnDataVisual.TabIndex = 3;
            this.btnDataVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnDataVisual, "Visualizar");
            this.btnDataVisual.UseVisualStyleBackColor = true;
            this.btnDataVisual.Click += new System.EventHandler(this.btnDataVisual_Click);
            // 
            // txtDataFinal
            // 
            this.txtDataFinal.BackColor = System.Drawing.Color.White;
            this.txtDataFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataFinal.Location = new System.Drawing.Point(94, 6);
            this.txtDataFinal.MaxLength = 100;
            this.txtDataFinal.Name = "txtDataFinal";
            this.txtDataFinal.Size = new System.Drawing.Size(72, 21);
            this.txtDataFinal.TabIndex = 0;
            this.txtDataFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipRegiao.SetToolTip(this.txtDataFinal, "Data Final");
            this.txtDataFinal.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataFinal.Enter += new System.EventHandler(this.txtDataFinal_Enter);
            this.txtDataFinal.Leave += new System.EventHandler(this.txtDataFinal_Leave);
            // 
            // txtDataInicial
            // 
            this.txtDataInicial.BackColor = System.Drawing.Color.White;
            this.txtDataInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDataInicial.Location = new System.Drawing.Point(6, 6);
            this.txtDataInicial.MaxLength = 100;
            this.txtDataInicial.Name = "txtDataInicial";
            this.txtDataInicial.Size = new System.Drawing.Size(72, 21);
            this.txtDataInicial.TabIndex = 7;
            this.txtDataInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipRegiao.SetToolTip(this.txtDataInicial, "Data Inicial");
            this.txtDataInicial.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Data;
            this.txtDataInicial.Enter += new System.EventHandler(this.txtDataInicial_Enter);
            this.txtDataInicial.Leave += new System.EventHandler(this.txtDataInicial_Leave);
            // 
            // tabImportar
            // 
            this.tabImportar.Controls.Add(this.tabData);
            this.tabImportar.Location = new System.Drawing.Point(9, 9);
            this.tabImportar.Name = "tabImportar";
            this.tabImportar.SelectedIndex = 0;
            this.tabImportar.Size = new System.Drawing.Size(595, 390);
            this.tabImportar.TabIndex = 31;
            // 
            // tabData
            // 
            this.tabData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabData.Controls.Add(this.lblA);
            this.tabData.Controls.Add(this.txtDataInicial);
            this.tabData.Controls.Add(this.txtDataFinal);
            this.tabData.Controls.Add(this.gridData);
            this.tabData.Controls.Add(this.btnDataVisual);
            this.tabData.Controls.Add(this.btnDataIns);
            this.tabData.Controls.Add(this.btnData);
            this.tabData.Location = new System.Drawing.Point(4, 22);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(587, 364);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Data de Importação";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(80, 10);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(13, 13);
            this.lblA.TabIndex = 8;
            this.lblA.Text = "à";
            // 
            // gridData
            // 
            this.gridData.AllowUserToAddRows = false;
            this.gridData.AllowUserToDeleteRows = false;
            this.gridData.AllowUserToResizeRows = false;
            this.gridData.BackgroundColor = System.Drawing.Color.White;
            this.gridData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridData.ColumnHeadersHeight = 17;
            this.gridData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridData.EnableHeadersVisualStyles = false;
            this.gridData.Location = new System.Drawing.Point(6, 36);
            this.gridData.MultiSelect = false;
            this.gridData.Name = "gridData";
            this.gridData.ReadOnly = true;
            this.gridData.RowHeadersVisible = false;
            this.gridData.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridData.Size = new System.Drawing.Size(571, 281);
            this.gridData.TabIndex = 2;
            this.gridData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridData_CellDoubleClick);
            this.gridData.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridData_RowStateChanged);
            this.gridData.SelectionChanged += new System.EventHandler(this.gridData_SelectionChanged);
            // 
            // frmImportarPessoaBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(614, 442);
            this.Controls.Add(this.tabImportar);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmImportarPessoaBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importação de Pessoas (Irmãos e Irmãs)";
            this.Load += new System.EventHandler(this.frmImportarPessoaBusca_Load);
            this.tabImportar.ResumeLayout(false);
            this.tabData.ResumeLayout(false);
            this.tabData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.tabControlPersonal tabImportar;
        private System.Windows.Forms.TabPage tabData;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataFinal;
        private System.Windows.Forms.DataGridView gridData;
        private System.Windows.Forms.Button btnDataVisual;
        private System.Windows.Forms.Button btnDataIns;
        private System.Windows.Forms.Button btnData;
        private BLL.validacoes.Controles.TextBoxPersonal txtDataInicial;
        private System.Windows.Forms.Label lblA;
    }
}