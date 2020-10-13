namespace ccbusua
{
    partial class frmSubModuloBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSubModuloBusca));
            this.btnFechar = new System.Windows.Forms.Button();
            this.tipMod = new System.Windows.Forms.ToolTip(this.components);
            this.btnDescSel = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlModulos = new System.Windows.Forms.Panel();
            this.gridSubMod = new System.Windows.Forms.DataGridView();
            this.pnlModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubMod)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(268, 274);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(70, 25);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "&Fechar";
            this.tipMod.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnDescSel
            // 
            this.btnDescSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescSel.Enabled = false;
            this.btnDescSel.Location = new System.Drawing.Point(252, 229);
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
            this.btnDesc.Location = new System.Drawing.Point(237, 9);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(23, 23);
            this.btnDesc.TabIndex = 1;
            this.tipMod.SetToolTip(this.btnDesc, "Pesquisar modulos");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.LightYellow;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(9, 10);
            this.txtDesc.MaxLength = 120;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(225, 21);
            this.txtDesc.TabIndex = 0;
            this.tipMod.SetToolTip(this.txtDesc, "Descrição para pesquisar");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // pnlModulos
            // 
            this.pnlModulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlModulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModulos.Controls.Add(this.txtDesc);
            this.pnlModulos.Controls.Add(this.gridSubMod);
            this.pnlModulos.Controls.Add(this.btnDescSel);
            this.pnlModulos.Controls.Add(this.btnDesc);
            this.pnlModulos.Location = new System.Drawing.Point(5, 5);
            this.pnlModulos.Name = "pnlModulos";
            this.pnlModulos.Size = new System.Drawing.Size(333, 263);
            this.pnlModulos.TabIndex = 0;
            // 
            // gridSubMod
            // 
            this.gridSubMod.AllowUserToAddRows = false;
            this.gridSubMod.AllowUserToDeleteRows = false;
            this.gridSubMod.AllowUserToResizeColumns = false;
            this.gridSubMod.AllowUserToResizeRows = false;
            this.gridSubMod.BackgroundColor = System.Drawing.Color.White;
            this.gridSubMod.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.gridSubMod.ColumnHeadersHeight = 17;
            this.gridSubMod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSubMod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridSubMod.EnableHeadersVisualStyles = false;
            this.gridSubMod.GridColor = System.Drawing.SystemColors.ControlText;
            this.gridSubMod.Location = new System.Drawing.Point(9, 40);
            this.gridSubMod.MultiSelect = false;
            this.gridSubMod.Name = "gridSubMod";
            this.gridSubMod.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSubMod.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSubMod.RowHeadersVisible = false;
            this.gridSubMod.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSubMod.RowTemplate.Height = 18;
            this.gridSubMod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSubMod.Size = new System.Drawing.Size(313, 183);
            this.gridSubMod.TabIndex = 2;
            this.gridSubMod.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSubModulo_CellDoubleClick);
            this.gridSubMod.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridSubModulo_RowStateChanged);
            this.gridSubMod.SelectionChanged += new System.EventHandler(this.gridSubModulo_SelectionChanged);
            // 
            // frmSubModuloBusca
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
            this.Name = "frmSubModuloBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Pesquisa Sub-Módulos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSubModuloBusca_FormClosed);
            this.Load += new System.EventHandler(this.frmSubModuloBusca_Load);
            this.pnlModulos.ResumeLayout(false);
            this.pnlModulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubMod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip tipMod;
        private System.Windows.Forms.Panel pnlModulos;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridSubMod;
        private System.Windows.Forms.Button btnDescSel;
        private System.Windows.Forms.Button btnDesc;
    }
}