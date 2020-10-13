namespace ccbpess.pesquisa
{
    partial class frmPesquisaComum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaComum));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipRegiao = new System.Windows.Forms.ToolTip(this.components);
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnDesc = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.Button();
            this.tabComum = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.imgCCB = new System.Windows.Forms.ImageList(this.components);
            this.lblReforma = new System.Windows.Forms.Label();
            this.pctReforma = new System.Windows.Forms.PictureBox();
            this.lblConstrucao = new System.Windows.Forms.Label();
            this.pctConstrucao = new System.Windows.Forms.PictureBox();
            this.lblFechada = new System.Windows.Forms.Label();
            this.pctFechada = new System.Windows.Forms.PictureBox();
            this.lblAberta = new System.Windows.Forms.Label();
            this.pctAberta = new System.Windows.Forms.PictureBox();
            this.tabComum.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReforma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctConstrucao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFechada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAberta)).BeginInit();
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
            this.tipRegiao.SetToolTip(this.txtDesc, "Nome para pesquisar");
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
            this.tipRegiao.SetToolTip(this.btnDesc, "Pesquisar");
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(516, 367);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipRegiao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSel
            // 
            this.btnSel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSel.Enabled = false;
            this.btnSel.Location = new System.Drawing.Point(487, 287);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(90, 30);
            this.btnSel.TabIndex = 5;
            this.btnSel.Text = "&Selecionar";
            this.tipRegiao.SetToolTip(this.btnSel, "Selecionar");
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // tabComum
            // 
            this.tabComum.Controls.Add(this.tabDesc);
            this.tabComum.Location = new System.Drawing.Point(9, 9);
            this.tabComum.Name = "tabComum";
            this.tabComum.SelectedIndex = 0;
            this.tabComum.Size = new System.Drawing.Size(595, 352);
            this.tabComum.TabIndex = 31;
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
            this.tabDesc.Size = new System.Drawing.Size(587, 326);
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
            this.gridDesc.Size = new System.Drawing.Size(571, 245);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // imgCCB
            // 
            this.imgCCB.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgCCB.ImageStream")));
            this.imgCCB.TransparentColor = System.Drawing.Color.Transparent;
            this.imgCCB.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgCCB.Images.SetKeyName(1, "BolaVermelha.ico");
            this.imgCCB.Images.SetKeyName(2, "BolaAmarela.ico");
            this.imgCCB.Images.SetKeyName(3, "BolaAzul.ico");
            // 
            // lblReforma
            // 
            this.lblReforma.AutoSize = true;
            this.lblReforma.Location = new System.Drawing.Point(270, 378);
            this.lblReforma.Name = "lblReforma";
            this.lblReforma.Size = new System.Drawing.Size(48, 13);
            this.lblReforma.TabIndex = 48;
            this.lblReforma.Text = "Reforma";
            // 
            // pctReforma
            // 
            this.pctReforma.Location = new System.Drawing.Point(254, 375);
            this.pctReforma.Name = "pctReforma";
            this.pctReforma.Size = new System.Drawing.Size(16, 20);
            this.pctReforma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctReforma.TabIndex = 47;
            this.pctReforma.TabStop = false;
            // 
            // lblConstrucao
            // 
            this.lblConstrucao.AutoSize = true;
            this.lblConstrucao.Location = new System.Drawing.Point(166, 378);
            this.lblConstrucao.Name = "lblConstrucao";
            this.lblConstrucao.Size = new System.Drawing.Size(79, 13);
            this.lblConstrucao.TabIndex = 46;
            this.lblConstrucao.Text = "Em Construção";
            // 
            // pctConstrucao
            // 
            this.pctConstrucao.Location = new System.Drawing.Point(150, 375);
            this.pctConstrucao.Name = "pctConstrucao";
            this.pctConstrucao.Size = new System.Drawing.Size(16, 20);
            this.pctConstrucao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctConstrucao.TabIndex = 45;
            this.pctConstrucao.TabStop = false;
            // 
            // lblFechada
            // 
            this.lblFechada.AutoSize = true;
            this.lblFechada.Location = new System.Drawing.Point(93, 378);
            this.lblFechada.Name = "lblFechada";
            this.lblFechada.Size = new System.Drawing.Size(48, 13);
            this.lblFechada.TabIndex = 44;
            this.lblFechada.Text = "Fechada";
            // 
            // pctFechada
            // 
            this.pctFechada.Location = new System.Drawing.Point(77, 375);
            this.pctFechada.Name = "pctFechada";
            this.pctFechada.Size = new System.Drawing.Size(16, 20);
            this.pctFechada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctFechada.TabIndex = 43;
            this.pctFechada.TabStop = false;
            // 
            // lblAberta
            // 
            this.lblAberta.AutoSize = true;
            this.lblAberta.Location = new System.Drawing.Point(29, 378);
            this.lblAberta.Name = "lblAberta";
            this.lblAberta.Size = new System.Drawing.Size(40, 13);
            this.lblAberta.TabIndex = 42;
            this.lblAberta.Text = "Aberta";
            // 
            // pctAberta
            // 
            this.pctAberta.Location = new System.Drawing.Point(12, 375);
            this.pctAberta.Name = "pctAberta";
            this.pctAberta.Size = new System.Drawing.Size(16, 20);
            this.pctAberta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAberta.TabIndex = 41;
            this.pctAberta.TabStop = false;
            // 
            // frmPesquisaComum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(614, 404);
            this.Controls.Add(this.lblReforma);
            this.Controls.Add(this.pctReforma);
            this.Controls.Add(this.lblConstrucao);
            this.Controls.Add(this.pctConstrucao);
            this.Controls.Add(this.lblFechada);
            this.Controls.Add(this.pctFechada);
            this.Controls.Add(this.lblAberta);
            this.Controls.Add(this.pctAberta);
            this.Controls.Add(this.tabComum);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPesquisaComum";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Comum Congregação";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPesquisaComum_FormClosed);
            this.Load += new System.EventHandler(this.frmPesquisaComum_Load);
            this.tabComum.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctReforma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctConstrucao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFechada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAberta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipRegiao;
        private BLL.validacoes.Controles.tabControlPersonal tabComum;
        private System.Windows.Forms.TabPage tabDesc;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnDesc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.ImageList imgCCB;
        private System.Windows.Forms.Label lblReforma;
        private System.Windows.Forms.PictureBox pctReforma;
        private System.Windows.Forms.Label lblConstrucao;
        private System.Windows.Forms.PictureBox pctConstrucao;
        private System.Windows.Forms.Label lblFechada;
        private System.Windows.Forms.PictureBox pctFechada;
        private System.Windows.Forms.Label lblAberta;
        private System.Windows.Forms.PictureBox pctAberta;
    }
}