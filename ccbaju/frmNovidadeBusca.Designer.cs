namespace ccbaju
{
    partial class frmNovidadeBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNovidadeBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipNovidade = new System.Windows.Forms.ToolTip(this.components);
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnDescExc = new System.Windows.Forms.Button();
            this.btnDescEditar = new System.Windows.Forms.Button();
            this.btnDescIns = new System.Windows.Forms.Button();
            this.btnDescVisual = new System.Windows.Forms.Button();
            this.tabGeral = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabDesc = new System.Windows.Forms.TabPage();
            this.txtDesc = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnDesc = new System.Windows.Forms.Button();
            this.gridDesc = new System.Windows.Forms.DataGridView();
            this.imgNovidade = new System.Windows.Forms.ImageList(this.components);
            this.lblAprova = new System.Windows.Forms.Label();
            this.pctAprova = new System.Windows.Forms.PictureBox();
            this.lblTeste = new System.Windows.Forms.Label();
            this.pctTeste = new System.Windows.Forms.PictureBox();
            this.lblImplementa = new System.Windows.Forms.Label();
            this.pctImplementa = new System.Windows.Forms.PictureBox();
            this.lblPublica = new System.Windows.Forms.Label();
            this.pctPublica = new System.Windows.Forms.PictureBox();
            this.tabGeral.SuspendLayout();
            this.tabDesc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAprova)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTeste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctImplementa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPublica)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(579, 364);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipNovidade.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnDescExc
            // 
            this.btnDescExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescExc.Enabled = false;
            this.btnDescExc.Location = new System.Drawing.Point(557, 287);
            this.btnDescExc.Name = "btnDescExc";
            this.btnDescExc.Size = new System.Drawing.Size(85, 30);
            this.btnDescExc.TabIndex = 6;
            this.btnDescExc.Text = "E&xcluir";
            this.tipNovidade.SetToolTip(this.btnDescExc, "Excluir");
            this.btnDescExc.UseVisualStyleBackColor = true;
            this.btnDescExc.Click += new System.EventHandler(this.btnDescExc_Click);
            // 
            // btnDescEditar
            // 
            this.btnDescEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescEditar.Enabled = false;
            this.btnDescEditar.Location = new System.Drawing.Point(468, 287);
            this.btnDescEditar.Name = "btnDescEditar";
            this.btnDescEditar.Size = new System.Drawing.Size(85, 30);
            this.btnDescEditar.TabIndex = 5;
            this.btnDescEditar.Text = "&Editar";
            this.tipNovidade.SetToolTip(this.btnDescEditar, "Editar");
            this.btnDescEditar.UseVisualStyleBackColor = true;
            this.btnDescEditar.Click += new System.EventHandler(this.btnDescEditar_Click);
            // 
            // btnDescIns
            // 
            this.btnDescIns.AccessibleDescription = "";
            this.btnDescIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescIns.Enabled = false;
            this.btnDescIns.Location = new System.Drawing.Point(379, 287);
            this.btnDescIns.Name = "btnDescIns";
            this.btnDescIns.Size = new System.Drawing.Size(85, 30);
            this.btnDescIns.TabIndex = 4;
            this.btnDescIns.Text = "&Inserir";
            this.tipNovidade.SetToolTip(this.btnDescIns, "Inserir");
            this.btnDescIns.UseVisualStyleBackColor = true;
            this.btnDescIns.Click += new System.EventHandler(this.btnDescIns_Click);
            // 
            // btnDescVisual
            // 
            this.btnDescVisual.AccessibleDescription = "";
            this.btnDescVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDescVisual.Enabled = false;
            this.btnDescVisual.Location = new System.Drawing.Point(290, 287);
            this.btnDescVisual.Name = "btnDescVisual";
            this.btnDescVisual.Size = new System.Drawing.Size(85, 30);
            this.btnDescVisual.TabIndex = 3;
            this.btnDescVisual.Text = "&Visualizar";
            this.tipNovidade.SetToolTip(this.btnDescVisual, "Visualizar");
            this.btnDescVisual.UseVisualStyleBackColor = true;
            this.btnDescVisual.Click += new System.EventHandler(this.btnDescVisual_Click);
            // 
            // tabGeral
            // 
            this.tabGeral.Controls.Add(this.tabDesc);
            this.tabGeral.Location = new System.Drawing.Point(9, 9);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.SelectedIndex = 0;
            this.tabGeral.Size = new System.Drawing.Size(658, 351);
            this.tabGeral.TabIndex = 31;
            // 
            // tabDesc
            // 
            this.tabDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabDesc.Controls.Add(this.txtDesc);
            this.tabDesc.Controls.Add(this.btnDesc);
            this.tabDesc.Controls.Add(this.gridDesc);
            this.tabDesc.Controls.Add(this.btnDescVisual);
            this.tabDesc.Controls.Add(this.btnDescIns);
            this.tabDesc.Controls.Add(this.btnDescEditar);
            this.tabDesc.Controls.Add(this.btnDescExc);
            this.tabDesc.Location = new System.Drawing.Point(4, 22);
            this.tabDesc.Name = "tabDesc";
            this.tabDesc.Padding = new System.Windows.Forms.Padding(3);
            this.tabDesc.Size = new System.Drawing.Size(650, 325);
            this.tabDesc.TabIndex = 1;
            this.tabDesc.Text = "Descrição";
            // 
            // txtDesc
            // 
            this.txtDesc.BackColor = System.Drawing.Color.LightYellow;
            this.txtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDesc.Location = new System.Drawing.Point(6, 8);
            this.txtDesc.MaxLength = 100;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(150, 21);
            this.txtDesc.TabIndex = 7;
            this.txtDesc.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtDesc.Enter += new System.EventHandler(this.txtDesc_Enter);
            this.txtDesc.Leave += new System.EventHandler(this.txtDesc_Leave);
            // 
            // btnDesc
            // 
            this.btnDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDesc.Image = ((System.Drawing.Image)(resources.GetObject("btnDesc.Image")));
            this.btnDesc.Location = new System.Drawing.Point(159, 7);
            this.btnDesc.Name = "btnDesc";
            this.btnDesc.Size = new System.Drawing.Size(23, 23);
            this.btnDesc.TabIndex = 8;
            this.btnDesc.UseVisualStyleBackColor = true;
            this.btnDesc.Click += new System.EventHandler(this.btnDesc_Click);
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
            this.gridDesc.Size = new System.Drawing.Size(636, 245);
            this.gridDesc.TabIndex = 2;
            this.gridDesc.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridDesc_CellDoubleClick);
            this.gridDesc.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridDesc_RowStateChanged);
            this.gridDesc.SelectionChanged += new System.EventHandler(this.gridDesc_SelectionChanged);
            // 
            // imgNovidade
            // 
            this.imgNovidade.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgNovidade.ImageStream")));
            this.imgNovidade.TransparentColor = System.Drawing.Color.Transparent;
            this.imgNovidade.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgNovidade.Images.SetKeyName(1, "BolaAmarela.ico");
            this.imgNovidade.Images.SetKeyName(2, "BolaAzul.ico");
            this.imgNovidade.Images.SetKeyName(3, "BolaVermelha.ico");
            // 
            // lblAprova
            // 
            this.lblAprova.AutoSize = true;
            this.lblAprova.Location = new System.Drawing.Point(198, 369);
            this.lblAprova.Name = "lblAprova";
            this.lblAprova.Size = new System.Drawing.Size(54, 13);
            this.lblAprova.TabIndex = 44;
            this.lblAprova.Text = "Aprovada";
            // 
            // pctAprova
            // 
            this.pctAprova.Location = new System.Drawing.Point(182, 366);
            this.pctAprova.Name = "pctAprova";
            this.pctAprova.Size = new System.Drawing.Size(16, 20);
            this.pctAprova.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAprova.TabIndex = 43;
            this.pctAprova.TabStop = false;
            // 
            // lblTeste
            // 
            this.lblTeste.AutoSize = true;
            this.lblTeste.Location = new System.Drawing.Point(124, 369);
            this.lblTeste.Name = "lblTeste";
            this.lblTeste.Size = new System.Drawing.Size(51, 13);
            this.lblTeste.TabIndex = 42;
            this.lblTeste.Text = "Em Teste";
            // 
            // pctTeste
            // 
            this.pctTeste.Location = new System.Drawing.Point(108, 366);
            this.pctTeste.Name = "pctTeste";
            this.pctTeste.Size = new System.Drawing.Size(16, 20);
            this.pctTeste.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctTeste.TabIndex = 41;
            this.pctTeste.TabStop = false;
            // 
            // lblImplementa
            // 
            this.lblImplementa.AutoSize = true;
            this.lblImplementa.Location = new System.Drawing.Point(26, 369);
            this.lblImplementa.Name = "lblImplementa";
            this.lblImplementa.Size = new System.Drawing.Size(77, 13);
            this.lblImplementa.TabIndex = 40;
            this.lblImplementa.Text = "A Implementar";
            // 
            // pctImplementa
            // 
            this.pctImplementa.Location = new System.Drawing.Point(9, 366);
            this.pctImplementa.Name = "pctImplementa";
            this.pctImplementa.Size = new System.Drawing.Size(16, 20);
            this.pctImplementa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctImplementa.TabIndex = 39;
            this.pctImplementa.TabStop = false;
            // 
            // lblPublica
            // 
            this.lblPublica.AutoSize = true;
            this.lblPublica.Location = new System.Drawing.Point(274, 369);
            this.lblPublica.Name = "lblPublica";
            this.lblPublica.Size = new System.Drawing.Size(52, 13);
            this.lblPublica.TabIndex = 46;
            this.lblPublica.Text = "Publicada";
            // 
            // pctPublica
            // 
            this.pctPublica.Location = new System.Drawing.Point(258, 366);
            this.pctPublica.Name = "pctPublica";
            this.pctPublica.Size = new System.Drawing.Size(16, 20);
            this.pctPublica.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctPublica.TabIndex = 45;
            this.pctPublica.TabStop = false;
            // 
            // frmNovidadeBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(675, 399);
            this.Controls.Add(this.lblPublica);
            this.Controls.Add(this.pctPublica);
            this.Controls.Add(this.lblAprova);
            this.Controls.Add(this.pctAprova);
            this.Controls.Add(this.lblTeste);
            this.Controls.Add(this.pctTeste);
            this.Controls.Add(this.lblImplementa);
            this.Controls.Add(this.pctImplementa);
            this.Controls.Add(this.tabGeral);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmNovidadeBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Novidades do Sistema";
            this.Load += new System.EventHandler(this.frmNovidadeBusca_Load);
            this.tabGeral.ResumeLayout(false);
            this.tabDesc.ResumeLayout(false);
            this.tabDesc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDesc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAprova)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctTeste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctImplementa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPublica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipNovidade;
        private System.Windows.Forms.Button btnFechar;
        private BLL.validacoes.Controles.tabControlPersonal tabGeral;
        private System.Windows.Forms.TabPage tabDesc;
        private System.Windows.Forms.DataGridView gridDesc;
        private System.Windows.Forms.Button btnDescVisual;
        private System.Windows.Forms.Button btnDescIns;
        private System.Windows.Forms.Button btnDescEditar;
        private System.Windows.Forms.Button btnDescExc;
        private BLL.validacoes.Controles.TextBoxPersonal txtDesc;
        private System.Windows.Forms.Button btnDesc;
        private System.Windows.Forms.ImageList imgNovidade;
        private System.Windows.Forms.Label lblAprova;
        private System.Windows.Forms.PictureBox pctAprova;
        private System.Windows.Forms.Label lblTeste;
        private System.Windows.Forms.PictureBox pctTeste;
        private System.Windows.Forms.Label lblImplementa;
        private System.Windows.Forms.PictureBox pctImplementa;
        private System.Windows.Forms.Label lblPublica;
        private System.Windows.Forms.PictureBox pctPublica;
    }
}