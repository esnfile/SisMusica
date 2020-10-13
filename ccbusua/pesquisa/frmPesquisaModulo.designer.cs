namespace ccbusua
{
    partial class frmPesquisaModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaModulo));
            this.btnFechar = new System.Windows.Forms.Button();
            this.tipMod = new System.Windows.Forms.ToolTip(this.components);
            this.btnDescSel = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlModulos = new System.Windows.Forms.Panel();
            this.gridModulo = new System.Windows.Forms.DataGridView();
            this.pnlModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModulo)).BeginInit();
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
            this.btnDesc.Location = new System.Drawing.Point(211, 9);
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
            this.txtDesc.Location = new System.Drawing.Point(9, 10);
            this.txtDesc.MaxLength = 120;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(199, 21);
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
            this.pnlModulos.Controls.Add(this.gridModulo);
            this.pnlModulos.Controls.Add(this.btnDescSel);
            this.pnlModulos.Controls.Add(this.btnDesc);
            this.pnlModulos.Location = new System.Drawing.Point(5, 5);
            this.pnlModulos.Name = "pnlModulos";
            this.pnlModulos.Size = new System.Drawing.Size(333, 263);
            this.pnlModulos.TabIndex = 0;
            // 
            // gridModulo
            // 
            this.gridModulo.AllowUserToAddRows = false;
            this.gridModulo.AllowUserToDeleteRows = false;
            this.gridModulo.AllowUserToResizeColumns = false;
            this.gridModulo.AllowUserToResizeRows = false;
            this.gridModulo.BackgroundColor = System.Drawing.Color.White;
            this.gridModulo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.gridModulo.ColumnHeadersHeight = 17;
            this.gridModulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridModulo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridModulo.EnableHeadersVisualStyles = false;
            this.gridModulo.GridColor = System.Drawing.SystemColors.ControlText;
            this.gridModulo.Location = new System.Drawing.Point(9, 40);
            this.gridModulo.MultiSelect = false;
            this.gridModulo.Name = "gridModulo";
            this.gridModulo.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridModulo.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridModulo.RowHeadersVisible = false;
            this.gridModulo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridModulo.RowTemplate.Height = 18;
            this.gridModulo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridModulo.Size = new System.Drawing.Size(313, 183);
            this.gridModulo.TabIndex = 2;
            this.gridModulo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridModulo_CellDoubleClick);
            this.gridModulo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridModulo_RowStateChanged);
            this.gridModulo.SelectionChanged += new System.EventHandler(this.gridModulo_SelectionChanged);
            // 
            // frmPesquisaModulo
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
            this.Name = "frmPesquisaModulo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Módulos";
            this.Activated += new System.EventHandler(this.frmPesquisaModulo_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPesquisaModulo_FormClosed);
            this.Load += new System.EventHandler(this.frmPesquisaModulo_Load);
            this.pnlModulos.ResumeLayout(false);
            this.pnlModulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModulo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip tipMod;
        private System.Windows.Forms.Panel pnlModulos;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridModulo;
        private System.Windows.Forms.Button btnDescSel;
        private System.Windows.Forms.Button btnDesc;
    }
}