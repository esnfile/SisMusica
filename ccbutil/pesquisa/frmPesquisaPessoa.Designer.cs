namespace ccbutil
{
    partial class frmPesquisaPessoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaPessoa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipPessoa = new System.Windows.Forms.ToolTip(this.components);
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnDesc = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.Button();
            this.tabPessoa = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.imgPessoa = new System.Windows.Forms.ImageList(this.components);
            this.lblInativa = new System.Windows.Forms.Label();
            this.pctInativa = new System.Windows.Forms.PictureBox();
            this.lblAtiva = new System.Windows.Forms.Label();
            this.pctAtiva = new System.Windows.Forms.PictureBox();
            this.tabPessoa.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAtiva)).BeginInit();
            this.SuspendLayout();
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
            this.tipPessoa.SetToolTip(this.txtDesc, "Nome para pesquisar");
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // btnDesc
            // 
            this.btnDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnDesc.Image")));
            this.btnDesc.Location = new System.Drawing.Point(159, 6);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(23, 23);
            this.btnDesc.TabIndex = 1;
            this.tipPessoa.SetToolTip(this.btnDesc, "Pesquisar");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(514, 404);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipPessoa.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSel
            // 
            this.btnSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSel.Enabled = false;
            this.btnSel.Location = new System.Drawing.Point(487, 322);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(90, 30);
            this.btnSel.TabIndex = 5;
            this.btnSel.Text = "&Selecionar";
            this.tipPessoa.SetToolTip(this.btnSel, "Selecionar");
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // tabPessoa
            // 
            this.tabPessoa.Controls.Add(this.tabDesc);
            this.tabPessoa.Location = new System.Drawing.Point(9, 9);
            this.tabPessoa.Name = "tabPessoa";
            this.tabPessoa.SelectedIndex = 0;
            this.tabPessoa.Size = new System.Drawing.Size(595, 389);
            this.tabPessoa.TabIndex = 31;
            // 
            // tabDesc
            // 
            this.tabDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDesc.Controls.Add(this.txtDesc);
            this.tabDesc.Controls.Add(this.gridDesc);
            this.tabDesc.Controls.Add(this.btnSel);
            this.tabDesc.Controls.Add(this.btnDesc);
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(587, 363);
            this.tabDesc.TabIndex = 1;
            this.tabDesc.Text = "Nome";
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
            this.gridDesc.Size = new System.Drawing.Size(571, 280);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // imgPessoa
            // 
            this.imgPessoa.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgPessoa.ImageStream")));
            this.imgPessoa.TransparentColor = System.Drawing.Color.Transparent;
            this.imgPessoa.Images.SetKeyName(0, "BolaVermelha.ico");
            this.imgPessoa.Images.SetKeyName(1, "BolaVerde.ico");
            // 
            // lblInativa
            // 
            this.lblInativa.AutoSize = true;
            this.lblInativa.Location = new System.Drawing.Point(84, 411);
            this.lblInativa.Name = "lblInativa";
            this.lblInativa.Size = new System.Drawing.Size(41, 13);
            this.lblInativa.TabIndex = 40;
            this.lblInativa.Text = "Inativo";
            // 
            // pctInativa
            // 
            this.pctInativa.Location = new System.Drawing.Point(68, 408);
            this.pctInativa.Name = "pctInativa";
            this.pctInativa.Size = new System.Drawing.Size(16, 20);
            this.pctInativa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctInativa.TabIndex = 39;
            this.pctInativa.TabStop = false;
            // 
            // lblAtiva
            // 
            this.lblAtiva.AutoSize = true;
            this.lblAtiva.Location = new System.Drawing.Point(30, 411);
            this.lblAtiva.Name = "lblAtiva";
            this.lblAtiva.Size = new System.Drawing.Size(32, 13);
            this.lblAtiva.TabIndex = 38;
            this.lblAtiva.Text = "Ativo";
            // 
            // pctAtiva
            // 
            this.pctAtiva.Location = new System.Drawing.Point(13, 408);
            this.pctAtiva.Name = "pctAtiva";
            this.pctAtiva.Size = new System.Drawing.Size(16, 20);
            this.pctAtiva.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAtiva.TabIndex = 37;
            this.pctAtiva.TabStop = false;
            // 
            // frmPesquisaPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(614, 446);
            this.Controls.Add(this.lblInativa);
            this.Controls.Add(this.pctInativa);
            this.Controls.Add(this.lblAtiva);
            this.Controls.Add(this.pctAtiva);
            this.Controls.Add(this.tabPessoa);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPesquisaPessoa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Pessoa";
            this.Activated += new System.EventHandler(this.frmPesquisaPessoa_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPesquisaPessoa_FormClosed);
            this.Load += new System.EventHandler(this.frmPesquisaPessoa_Load);
            this.tabPessoa.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAtiva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipPessoa;
        private BLL.validacoes.Controles.tabControlPersonal tabPessoa;
        private System.Windows.Forms.TabPage tabDesc;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnDesc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.ImageList imgPessoa;
        private System.Windows.Forms.Label lblInativa;
        private System.Windows.Forms.PictureBox pctInativa;
        private System.Windows.Forms.Label lblAtiva;
        private System.Windows.Forms.PictureBox pctAtiva;
    }
}