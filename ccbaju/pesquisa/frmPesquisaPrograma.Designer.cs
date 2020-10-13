namespace ccbaju
{
    partial class frmPesquisaPrograma
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaPrograma));
            this.tipProg = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.Button();
            this.cboModulo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.cboSubModulo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.tabProg = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.lblSubModulo = new System.Windows.Forms.Label();
            this.lblModulo = new System.Windows.Forms.Label();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.tabProg.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(468, 356);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipProg.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSel
            // 
            this.btnSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSel.Enabled = false;
            this.btnSel.Location = new System.Drawing.Point(443, 277);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(90, 30);
            this.btnSel.TabIndex = 5;
            this.btnSel.Text = "&Selecionar";
            this.tipProg.SetToolTip(this.btnSel, "Selecionar");
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // cboModulo
            // 
            this.cboModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(55, 6);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(130, 21);
            this.cboModulo.TabIndex = 22;
            this.tipProg.SetToolTip(this.cboModulo, "Selecione o Módulo");
            this.cboModulo.SelectionChangeCommitted += new System.EventHandler(this.cboModulo_SelectionChangeCommitted);
            // 
            // cboSubModulo
            // 
            this.cboSubModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubModulo.FormattingEnabled = true;
            this.cboSubModulo.Location = new System.Drawing.Point(286, 6);
            this.cboSubModulo.Name = "cboSubModulo";
            this.cboSubModulo.Size = new System.Drawing.Size(130, 21);
            this.cboSubModulo.TabIndex = 24;
            this.tipProg.SetToolTip(this.cboSubModulo, "Selecione o Sub-Módulo");
            this.cboSubModulo.SelectionChangeCommitted += new System.EventHandler(this.cboSubModulo_SelectionChangeCommitted);
            // 
            // tabProg
            // 
            this.tabProg.Controls.Add(this.tabDesc);
            this.tabProg.Location = new System.Drawing.Point(9, 9);
            this.tabProg.Name = "tabProg";
            this.tabProg.SelectedIndex = 0;
            this.tabProg.Size = new System.Drawing.Size(549, 341);
            this.tabProg.TabIndex = 31;
            // 
            // tabDesc
            // 
            this.tabDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDesc.Controls.Add(this.lblSubModulo);
            this.tabDesc.Controls.Add(this.cboSubModulo);
            this.tabDesc.Controls.Add(this.lblModulo);
            this.tabDesc.Controls.Add(this.cboModulo);
            this.tabDesc.Controls.Add(this.gridDesc);
            this.tabDesc.Controls.Add(this.btnSel);
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(541, 315);
            this.tabDesc.TabIndex = 1;
            this.tabDesc.Text = "Programas";
            // 
            // lblSubModulo
            // 
            this.lblSubModulo.AutoSize = true;
            this.lblSubModulo.Location = new System.Drawing.Point(215, 9);
            this.lblSubModulo.Name = "lblSubModulo";
            this.lblSubModulo.Size = new System.Drawing.Size(67, 13);
            this.lblSubModulo.TabIndex = 25;
            this.lblSubModulo.Text = "Sub-Módulo:";
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Location = new System.Drawing.Point(6, 9);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(45, 13);
            this.lblModulo.TabIndex = 23;
            this.lblModulo.Text = "Módulo:";
            // 
            // gridDesc
            // 
            this.gridDesc.AllowUserToAddRows = false;
            this.gridDesc.AllowUserToDeleteRows = false;
            this.gridDesc.AllowUserToResizeRows = false;
            this.gridDesc.BackgroundColor = System.Drawing.Color.White;
            this.gridDesc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDesc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDesc.ColumnHeadersHeight = 17;
            this.gridDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDesc.EnableHeadersVisualStyles = false;
            this.gridDesc.Location = new System.Drawing.Point(6, 36);
            this.gridDesc.MultiSelect = false;
            this.gridDesc.Name = "gridDesc";
            this.gridDesc.ReadOnly = true;
            this.gridDesc.RowHeadersVisible = false;
            this.gridDesc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDesc.Size = new System.Drawing.Size(527, 237);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // frmPesquisaPrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(566, 395);
            this.Controls.Add(this.tabProg);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPesquisaPrograma";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Programas";
            this.Activated += new System.EventHandler(this.frmPesquisaPrograma_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPesquisaPrograma_FormClosed);
            this.Load += new System.EventHandler(this.frmPesquisaPrograma_Load);
            this.tabProg.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipProg;
        private BLL.validacoes.Controles.tabControlPersonal tabProg;
        private System.Windows.Forms.TabPage tabDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label lblSubModulo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboSubModulo;
        private System.Windows.Forms.Label lblModulo;
        private BLL.validacoes.Controles.ComboBoxPersonal cboModulo;
    }
}