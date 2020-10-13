namespace ccbusua
{
    partial class frmPesquisaSubModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaSubModulo));
            this.btnFechar = new System.Windows.Forms.Button();
            this.tipMod = new System.Windows.Forms.ToolTip(this.components);
            this.btnDescSel = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.pnlModulos = new System.Windows.Forms.Panel();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.cboModulo = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblModulo = new System.Windows.Forms.Label();
            this.gridSubMod = new System.Windows.Forms.DataGridView();
            this.pnlModulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubMod)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(268, 306);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(70, 30);
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
            this.btnDescSel.Location = new System.Drawing.Point(252, 258);
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
            this.btnDesc.Location = new System.Drawing.Point(183, 31);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(23, 23);
            this.btnDesc.TabIndex = 1;
            this.tipMod.SetToolTip(this.btnDesc, "Pesquisar modulos");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // pnlModulos
            // 
            this.pnlModulos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlModulos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlModulos.Controls.Add(this.txtDesc);
            this.pnlModulos.Controls.Add(this.cboModulo);
            this.pnlModulos.Controls.Add(this.lblModulo);
            this.pnlModulos.Controls.Add(this.gridSubMod);
            this.pnlModulos.Controls.Add(this.btnDescSel);
            this.pnlModulos.Controls.Add(this.btnDesc);
            this.pnlModulos.Location = new System.Drawing.Point(5, 5);
            this.pnlModulos.Name = "pnlModulos";
            this.pnlModulos.Size = new System.Drawing.Size(333, 295);
            this.pnlModulos.TabIndex = 0;
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(9, 32);
            this.txtDesc.MaxLength = 50;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(170, 21);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // cboModulo
            // 
            this.cboModulo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboModulo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboModulo.FormattingEnabled = true;
            this.cboModulo.Location = new System.Drawing.Point(52, 7);
            this.cboModulo.Name = "cboModulo";
            this.cboModulo.Size = new System.Drawing.Size(153, 21);
            this.cboModulo.TabIndex = 6;
            this.cboModulo.SelectedIndexChanged += new System.EventHandler(this.cboModulo_SelectedIndexChanged);
            // 
            // lblModulo
            // 
            this.lblModulo.AutoSize = true;
            this.lblModulo.Location = new System.Drawing.Point(6, 10);
            this.lblModulo.Name = "lblModulo";
            this.lblModulo.Size = new System.Drawing.Size(45, 13);
            this.lblModulo.TabIndex = 4;
            this.lblModulo.Text = "Módulo:";
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
            this.gridSubMod.Location = new System.Drawing.Point(9, 59);
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
            this.gridSubMod.Size = new System.Drawing.Size(313, 193);
            this.gridSubMod.TabIndex = 2;
            this.gridSubMod.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSubModulo_CellDoubleClick);
            this.gridSubMod.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridSubModulo_RowStateChanged);
            this.gridSubMod.SelectionChanged += new System.EventHandler(this.gridSubModulo_SelectionChanged);
            // 
            // frmPesquisaSubModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(342, 344);
            this.Controls.Add(this.pnlModulos);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPesquisaSubModulo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Sub-Módulos";
            this.Activated += new System.EventHandler(this.frmPesquisaSubModulo_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPesquisaSubModulo_FormClosed);
            this.Load += new System.EventHandler(this.frmPesquisaSubModulo_Load);
            this.pnlModulos.ResumeLayout(false);
            this.pnlModulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubMod)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ToolTip tipMod;
        private System.Windows.Forms.Panel pnlModulos;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.DataGridView gridSubMod;
        private System.Windows.Forms.Button btnDescSel;
        private System.Windows.Forms.Button btnDesc;
        private BLL.validacoes.Controles.ComboBoxPersonal cboModulo;
        private System.Windows.Forms.Label lblModulo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
    }
}