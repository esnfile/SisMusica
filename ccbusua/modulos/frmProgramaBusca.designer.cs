namespace ccbusua
{
    partial class frmProgramaBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgramaBusca));
            this.btnFechar = new System.Windows.Forms.Button();
            this.tipMod = new System.Windows.Forms.ToolTip(this.components);
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnDescSel = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.pnlModulos = new System.Windows.Forms.Panel();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.pnlModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(268, 274);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(70, 28);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "&Fechar";
            this.tipMod.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.LightYellow;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(9, 10);
            this.txtDesc.MaxLength = 120;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(211, 21);
            this.txtDesc.TabIndex = 0;
            this.tipMod.SetToolTip(this.txtDesc, "Descrição para pesquisar");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // btnDescSel
            // 
            this.btnDescSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescSel.Enabled = false;
            this.btnDescSel.Location = new System.Drawing.Point(252, 230);
            this.btnDescSel.Name = "btnDescSel";
            this.btnDescSel.Size = new System.Drawing.Size(70, 25);
            this.btnDescSel.TabIndex = 3;
            this.btnDescSel.Text = "&Selecionar";
            this.tipMod.SetToolTip(this.btnDescSel, "Selecionar");
            this.btnDescSel.UseVisualStyleBackColor = true;
            this.btnDescSel.Click += new System.EventHandler(this.btnDescSel_Click);
            // 
            // btnDesc
            // 
            this.btnDesc.Image = global::ccbusua.Properties.Resources.Lupa;
            this.btnDesc.Location = new System.Drawing.Point(223, 9);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(23, 23);
            this.btnDesc.TabIndex = 1;
            this.tipMod.SetToolTip(this.btnDesc, "Pesquisar programas");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // pnlModulos
            // 
            this.pnlModulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlModulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModulos.Controls.Add(this.txtDesc);
            this.pnlModulos.Controls.Add(this.gridDesc);
            this.pnlModulos.Controls.Add(this.btnDescSel);
            this.pnlModulos.Controls.Add(this.btnDesc);
            this.pnlModulos.Location = new System.Drawing.Point(5, 5);
            this.pnlModulos.Name = "pnlModulos";
            this.pnlModulos.Size = new System.Drawing.Size(333, 263);
            this.pnlModulos.TabIndex = 0;
            // 
            // gridDesc
            // 
            this.gridDesc.AllowUserToAddRows = false;
            this.gridDesc.AllowUserToDeleteRows = false;
            this.gridDesc.AllowUserToResizeColumns = false;
            this.gridDesc.AllowUserToResizeRows = false;
            this.gridDesc.BackgroundColor = System.Drawing.Color.White;
            this.gridDesc.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.gridDesc.ColumnHeadersHeight = 17;
            this.gridDesc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridDesc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridDesc.EnableHeadersVisualStyles = false;
            this.gridDesc.GridColor = System.Drawing.SystemColors.ControlText;
            this.gridDesc.Location = new System.Drawing.Point(9, 37);
            this.gridDesc.MultiSelect = false;
            this.gridDesc.Name = "gridDesc";
            this.gridDesc.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridDesc.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridDesc.RowHeadersVisible = false;
            this.gridDesc.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridDesc.RowTemplate.Height = 18;
            this.gridDesc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridDesc.Size = new System.Drawing.Size(313, 189);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // frmProgramaBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(342, 309);
            this.Controls.Add(this.pnlModulos);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmProgramaBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pesquisa Programas";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProgramaBusca_FormClosed);
            this.Load += new System.EventHandler(this.frmProgramaBusca_Load);
            this.pnlModulos.ResumeLayout(false);
            this.pnlModulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip tipMod;
        private System.Windows.Forms.Panel pnlModulos;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnDescSel;
        private System.Windows.Forms.Button btnDesc;
    }
}