namespace ccbpess
{
    partial class frmCargoBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCargoBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipRegiao = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnDesc = new System.Windows.Forms.Button();
            this.btnDescExc = new System.Windows.Forms.Button();
            this.btnDescEditar = new System.Windows.Forms.Button();
            this.btnDescIns = new System.Windows.Forms.Button();
            this.btnDescVisual = new System.Windows.Forms.Button();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.tabCargo = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.tabCargo.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(458, 367);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnDesc
            // 
            this.btnDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnDesc.Image")));
            this.btnDesc.Location = new System.Drawing.Point(160, 6);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(23, 23);
            this.btnDesc.TabIndex = 1;
            this.tipRegiao.SetToolTip(this.btnDesc, "Pesquisar");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // btnDescExc
            // 
            this.btnDescExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescExc.Enabled = false;
            this.btnDescExc.Location = new System.Drawing.Point(432, 291);
            this.btnDescExc.Name = "btnDescExc";
            this.btnDescExc.Size = new System.Drawing.Size(90, 30);
            this.btnDescExc.TabIndex = 6;
            this.btnDescExc.Text = "E&xcluir";
            this.tipRegiao.SetToolTip(this.btnDescExc, "Excluir");
            this.btnDescExc.UseVisualStyleBackColor = true;
            this.btnDescExc.Click += new System.EventHandler(this.btnDescExc_Click);
            // 
            // btnDescEditar
            // 
            this.btnDescEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescEditar.Enabled = false;
            this.btnDescEditar.Location = new System.Drawing.Point(338, 291);
            this.btnDescEditar.Name = "btnDescEditar";
            this.btnDescEditar.Size = new System.Drawing.Size(90, 30);
            this.btnDescEditar.TabIndex = 5;
            this.btnDescEditar.Text = "&Editar";
            this.tipRegiao.SetToolTip(this.btnDescEditar, "Editar");
            this.btnDescEditar.UseVisualStyleBackColor = true;
            this.btnDescEditar.Click += new System.EventHandler(this.btnDescEditar_Click);
            // 
            // btnDescIns
            // 
            this.btnDescIns.AccessibleDescription = "";
            this.btnDescIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescIns.Enabled = false;
            this.btnDescIns.Location = new System.Drawing.Point(244, 291);
            this.btnDescIns.Name = "btnDescIns";
            this.btnDescIns.Size = new System.Drawing.Size(90, 30);
            this.btnDescIns.TabIndex = 4;
            this.btnDescIns.Text = "&Inserir";
            this.tipRegiao.SetToolTip(this.btnDescIns, "Inserir");
            this.btnDescIns.UseVisualStyleBackColor = true;
            this.btnDescIns.Click += new System.EventHandler(this.btnDescIns_Click);
            // 
            // btnDescVisual
            // 
            this.btnDescVisual.AccessibleDescription = "";
            this.btnDescVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescVisual.Enabled = false;
            this.btnDescVisual.Location = new System.Drawing.Point(150, 291);
            this.btnDescVisual.Name = "btnDescVisual";
            this.btnDescVisual.Size = new System.Drawing.Size(90, 30);
            this.btnDescVisual.TabIndex = 3;
            this.btnDescVisual.Text = "&Visualizar";
            this.tipRegiao.SetToolTip(this.btnDescVisual, "Visualizar");
            this.btnDescVisual.UseVisualStyleBackColor = true;
            this.btnDescVisual.Click += new System.EventHandler(this.btnDescVisual_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.White;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(6, 7);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(150, 21);
            this.txtDesc.TabIndex = 0;
            this.tipRegiao.SetToolTip(this.txtDesc, "Nome para pesquisar");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // tabCargo
            // 
            this.tabCargo.Controls.Add(this.tabDesc);
            this.tabCargo.Location = new System.Drawing.Point(9, 9);
            this.tabCargo.Name = "tabCargo";
            this.tabCargo.SelectedIndex = 0;
            this.tabCargo.Size = new System.Drawing.Size(537, 353);
            this.tabCargo.TabIndex = 31;
            // 
            // tabDesc
            // 
            this.tabDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDesc.Controls.Add(this.txtDesc);
            this.tabDesc.Controls.Add(this.gridDesc);
            this.tabDesc.Controls.Add(this.btnDescVisual);
            this.tabDesc.Controls.Add(this.btnDescIns);
            this.tabDesc.Controls.Add(this.btnDescEditar);
            this.tabDesc.Controls.Add(this.btnDescExc);
            this.tabDesc.Controls.Add(this.btnDesc);
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(529, 327);
            this.tabDesc.TabIndex = 1;
            this.tabDesc.Text = "Descrição";
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
            this.gridDesc.Size = new System.Drawing.Size(516, 251);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gridDesc_DataBindingComplete);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // frmCargoBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(555, 403);
            this.Controls.Add(this.tabCargo);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCargoBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cargos e Ministérios";
            this.Activated += new System.EventHandler(this.frmCargoBusca_Activated);
            this.Load += new System.EventHandler(this.frmCargoBusca_Load);
            this.tabCargo.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.tabControlPersonal tabCargo;
        private System.Windows.Forms.TabPage tabDesc;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnDescVisual;
        private System.Windows.Forms.Button btnDescIns;
        private System.Windows.Forms.Button btnDescEditar;
        private System.Windows.Forms.Button btnDescExc;
        private System.Windows.Forms.Button btnDesc;
    }
}