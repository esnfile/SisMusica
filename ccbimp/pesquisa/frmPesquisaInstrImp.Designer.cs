namespace ccbimp
{
    partial class frmPesquisaInstrImp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisaInstrImp));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipInstr = new System.Windows.Forms.ToolTip(this.components);
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnDesc = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSel = new System.Windows.Forms.Button();
            this.tabRegiao = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.lblProibido = new System.Windows.Forms.Label();
            this.pctProibido = new System.Windows.Forms.PictureBox();
            this.lblNaoRecomenda = new System.Windows.Forms.Label();
            this.pctNaoRecomendado = new System.Windows.Forms.PictureBox();
            this.lblPermitido = new System.Windows.Forms.Label();
            this.pctPermitido = new System.Windows.Forms.PictureBox();
            this.imgInstr = new System.Windows.Forms.ImageList(this.components);
            this.tabRegiao.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctProibido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNaoRecomendado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPermitido)).BeginInit();
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
            this.tipInstr.SetToolTip(this.txtDesc, "Nome para pesquisar");
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
            this.tipInstr.SetToolTip(this.btnDesc, "Pesquisar");
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
            this.tipInstr.SetToolTip(this.btnFechar, "Fechar");
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
            this.tipInstr.SetToolTip(this.btnSel, "Selecionar");
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // tabRegiao
            // 
            this.tabRegiao.Controls.Add(this.tabDesc);
            this.tabRegiao.Location = new System.Drawing.Point(9, 9);
            this.tabRegiao.Name = "tabRegiao";
            this.tabRegiao.SelectedIndex = 0;
            this.tabRegiao.Size = new System.Drawing.Size(595, 389);
            this.tabRegiao.TabIndex = 31;
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
            this.gridDesc.Size = new System.Drawing.Size(571, 280);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // lblProibido
            // 
            this.lblProibido.AutoSize = true;
            this.lblProibido.Location = new System.Drawing.Point(221, 410);
            this.lblProibido.Name = "lblProibido";
            this.lblProibido.Size = new System.Drawing.Size(45, 13);
            this.lblProibido.TabIndex = 44;
            this.lblProibido.Text = "Proibido";
            // 
            // pctProibido
            // 
            this.pctProibido.Location = new System.Drawing.Point(205, 407);
            this.pctProibido.Name = "pctProibido";
            this.pctProibido.Size = new System.Drawing.Size(16, 20);
            this.pctProibido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctProibido.TabIndex = 43;
            this.pctProibido.TabStop = false;
            // 
            // lblNaoRecomenda
            // 
            this.lblNaoRecomenda.AutoSize = true;
            this.lblNaoRecomenda.Location = new System.Drawing.Point(102, 410);
            this.lblNaoRecomenda.Name = "lblNaoRecomenda";
            this.lblNaoRecomenda.Size = new System.Drawing.Size(97, 13);
            this.lblNaoRecomenda.TabIndex = 42;
            this.lblNaoRecomenda.Text = "Não Recomendado";
            // 
            // pctNaoRecomendado
            // 
            this.pctNaoRecomendado.Location = new System.Drawing.Point(86, 407);
            this.pctNaoRecomendado.Name = "pctNaoRecomendado";
            this.pctNaoRecomendado.Size = new System.Drawing.Size(16, 20);
            this.pctNaoRecomendado.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctNaoRecomendado.TabIndex = 41;
            this.pctNaoRecomendado.TabStop = false;
            // 
            // lblPermitido
            // 
            this.lblPermitido.AutoSize = true;
            this.lblPermitido.Location = new System.Drawing.Point(29, 410);
            this.lblPermitido.Name = "lblPermitido";
            this.lblPermitido.Size = new System.Drawing.Size(51, 13);
            this.lblPermitido.TabIndex = 40;
            this.lblPermitido.Text = "Permitido";
            // 
            // pctPermitido
            // 
            this.pctPermitido.Location = new System.Drawing.Point(12, 407);
            this.pctPermitido.Name = "pctPermitido";
            this.pctPermitido.Size = new System.Drawing.Size(16, 20);
            this.pctPermitido.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctPermitido.TabIndex = 39;
            this.pctPermitido.TabStop = false;
            // 
            // imgInstr
            // 
            this.imgInstr.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgInstr.ImageStream")));
            this.imgInstr.TransparentColor = System.Drawing.Color.Transparent;
            this.imgInstr.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgInstr.Images.SetKeyName(1, "BolaAmarela.ico");
            this.imgInstr.Images.SetKeyName(2, "BolaVermelha.ico");
            // 
            // frmPesquisaInstr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(614, 446);
            this.Controls.Add(this.lblProibido);
            this.Controls.Add(this.pctProibido);
            this.Controls.Add(this.lblNaoRecomenda);
            this.Controls.Add(this.pctNaoRecomendado);
            this.Controls.Add(this.lblPermitido);
            this.Controls.Add(this.pctPermitido);
            this.Controls.Add(this.tabRegiao);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPesquisaInstr";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisa Instrumento";
            this.Activated += new System.EventHandler(this.frmPesquisaInstrImp_Activated);
            this.Load += new System.EventHandler(this.frmPesquisaInstrImp_Load);
            this.tabRegiao.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctProibido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNaoRecomendado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPermitido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipInstr;
        private BLL.validacoes.Controles.tabControlPersonal tabRegiao;
        private System.Windows.Forms.TabPage tabDesc;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnDesc;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.Label lblProibido;
        private System.Windows.Forms.PictureBox pctProibido;
        private System.Windows.Forms.Label lblNaoRecomenda;
        private System.Windows.Forms.PictureBox pctNaoRecomendado;
        private System.Windows.Forms.Label lblPermitido;
        private System.Windows.Forms.PictureBox pctPermitido;
        private System.Windows.Forms.ImageList imgInstr;
    }
}