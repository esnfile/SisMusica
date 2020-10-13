namespace ccbconn
{
    partial class frmAcessar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAcessar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.lblPrepara = new System.Windows.Forms.Label();
            this.lblCopiarArquivo = new System.Windows.Forms.Label();
            this.lblCopiar = new System.Windows.Forms.Label();
            this.lblBaixar = new System.Windows.Forms.Label();
            this.gpoAtualiza = new System.Windows.Forms.GroupBox();
            this.pctPrepara = new System.Windows.Forms.PictureBox();
            this.pctCopiarArquivo = new System.Windows.Forms.PictureBox();
            this.pctCopiar = new System.Windows.Forms.PictureBox();
            this.pctBaixar = new System.Windows.Forms.PictureBox();
            this.pctVersao = new System.Windows.Forms.PictureBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.imgAcessar = new System.Windows.Forms.ImageList(this.components);
            this.btnConexao = new System.Windows.Forms.Button();
            this.pnlAcessar = new System.Windows.Forms.Panel();
            this.lblCaminho = new System.Windows.Forms.Label();
            this.gridRegional = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.cboConexao = new BLL.validacoes.Controles.ComboBoxPersonal();
            this.lblConexao = new System.Windows.Forms.Label();
            this.pnlConexao = new System.Windows.Forms.Panel();
            this.gpoAtualiza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPrepara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCopiarArquivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCopiar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBaixar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctVersao)).BeginInit();
            this.pnlAcessar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegional)).BeginInit();
            this.pnlConexao.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(434, 250);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 0;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnSair
            // 
            this.btnSair.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSair.Location = new System.Drawing.Point(463, 494);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(75, 23);
            this.btnSair.TabIndex = 1;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // lblPrepara
            // 
            this.lblPrepara.AutoSize = true;
            this.lblPrepara.Location = new System.Drawing.Point(45, 112);
            this.lblPrepara.Name = "lblPrepara";
            this.lblPrepara.Size = new System.Drawing.Size(255, 13);
            this.lblPrepara.TabIndex = 26;
            this.lblPrepara.Text = "Preparando para iniciar o sistema CCB SISMúsica ...";
            // 
            // lblCopiarArquivo
            // 
            this.lblCopiarArquivo.AutoSize = true;
            this.lblCopiarArquivo.Location = new System.Drawing.Point(45, 88);
            this.lblCopiarArquivo.Name = "lblCopiarArquivo";
            this.lblCopiarArquivo.Size = new System.Drawing.Size(143, 13);
            this.lblCopiarArquivo.TabIndex = 25;
            this.lblCopiarArquivo.Text = "Copiando novos arquivos ...";
            // 
            // lblCopiar
            // 
            this.lblCopiar.AutoSize = true;
            this.lblCopiar.Location = new System.Drawing.Point(45, 64);
            this.lblCopiar.Name = "lblCopiar";
            this.lblCopiar.Size = new System.Drawing.Size(243, 13);
            this.lblCopiar.TabIndex = 24;
            this.lblCopiar.Text = "Efetuando atualização de módulos no servidor ...";
            // 
            // lblBaixar
            // 
            this.lblBaixar.AutoSize = true;
            this.lblBaixar.Location = new System.Drawing.Point(45, 40);
            this.lblBaixar.Name = "lblBaixar";
            this.lblBaixar.Size = new System.Drawing.Size(150, 13);
            this.lblBaixar.TabIndex = 23;
            this.lblBaixar.Text = "Baixando nova atualização ...";
            // 
            // gpoAtualiza
            // 
            this.gpoAtualiza.BackColor = System.Drawing.Color.Transparent;
            this.gpoAtualiza.Controls.Add(this.pctPrepara);
            this.gpoAtualiza.Controls.Add(this.pctCopiarArquivo);
            this.gpoAtualiza.Controls.Add(this.pctCopiar);
            this.gpoAtualiza.Controls.Add(this.pctBaixar);
            this.gpoAtualiza.Controls.Add(this.pctVersao);
            this.gpoAtualiza.Controls.Add(this.lblPrepara);
            this.gpoAtualiza.Controls.Add(this.lblCopiarArquivo);
            this.gpoAtualiza.Controls.Add(this.lblCopiar);
            this.gpoAtualiza.Controls.Add(this.lblBaixar);
            this.gpoAtualiza.Controls.Add(this.lblVersao);
            this.gpoAtualiza.Location = new System.Drawing.Point(7, 143);
            this.gpoAtualiza.Name = "gpoAtualiza";
            this.gpoAtualiza.Size = new System.Drawing.Size(317, 136);
            this.gpoAtualiza.TabIndex = 20;
            this.gpoAtualiza.TabStop = false;
            // 
            // pctPrepara
            // 
            this.pctPrepara.Location = new System.Drawing.Point(20, 110);
            this.pctPrepara.Name = "pctPrepara";
            this.pctPrepara.Size = new System.Drawing.Size(16, 16);
            this.pctPrepara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPrepara.TabIndex = 30;
            this.pctPrepara.TabStop = false;
            // 
            // pctCopiarArquivo
            // 
            this.pctCopiarArquivo.Location = new System.Drawing.Point(20, 86);
            this.pctCopiarArquivo.Name = "pctCopiarArquivo";
            this.pctCopiarArquivo.Size = new System.Drawing.Size(16, 16);
            this.pctCopiarArquivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctCopiarArquivo.TabIndex = 29;
            this.pctCopiarArquivo.TabStop = false;
            // 
            // pctCopiar
            // 
            this.pctCopiar.Location = new System.Drawing.Point(20, 62);
            this.pctCopiar.Name = "pctCopiar";
            this.pctCopiar.Size = new System.Drawing.Size(16, 16);
            this.pctCopiar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctCopiar.TabIndex = 28;
            this.pctCopiar.TabStop = false;
            // 
            // pctBaixar
            // 
            this.pctBaixar.Location = new System.Drawing.Point(20, 38);
            this.pctBaixar.Name = "pctBaixar";
            this.pctBaixar.Size = new System.Drawing.Size(16, 16);
            this.pctBaixar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBaixar.TabIndex = 27;
            this.pctBaixar.TabStop = false;
            // 
            // pctVersao
            // 
            this.pctVersao.Location = new System.Drawing.Point(20, 14);
            this.pctVersao.Name = "pctVersao";
            this.pctVersao.Size = new System.Drawing.Size(16, 16);
            this.pctVersao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctVersao.TabIndex = 21;
            this.pctVersao.TabStop = false;
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(45, 16);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(255, 13);
            this.lblVersao.TabIndex = 22;
            this.lblVersao.Text = "Verificando se existe nova atualização disponível ...";
            // 
            // imgAcessar
            // 
            this.imgAcessar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgAcessar.ImageStream")));
            this.imgAcessar.TransparentColor = System.Drawing.Color.Transparent;
            this.imgAcessar.Images.SetKeyName(0, "FILE723.PNG");
            this.imgAcessar.Images.SetKeyName(1, "FILE722.PNG");
            // 
            // btnConexao
            // 
            this.btnConexao.Enabled = false;
            this.btnConexao.Location = new System.Drawing.Point(434, 7);
            this.btnConexao.Name = "btnConexao";
            this.btnConexao.Size = new System.Drawing.Size(75, 23);
            this.btnConexao.TabIndex = 21;
            this.btnConexao.Text = "&Iniciar";
            this.btnConexao.UseVisualStyleBackColor = true;
            this.btnConexao.Click += new System.EventHandler(this.btnConexao_Click);
            // 
            // pnlAcessar
            // 
            this.pnlAcessar.BackColor = System.Drawing.Color.Transparent;
            this.pnlAcessar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAcessar.Controls.Add(this.lblCaminho);
            this.pnlAcessar.Controls.Add(this.gridRegional);
            this.pnlAcessar.Controls.Add(this.cboConexao);
            this.pnlAcessar.Controls.Add(this.lblConexao);
            this.pnlAcessar.Controls.Add(this.btnConexao);
            this.pnlAcessar.Controls.Add(this.gpoAtualiza);
            this.pnlAcessar.Controls.Add(this.btnConectar);
            this.pnlAcessar.Location = new System.Drawing.Point(6, 199);
            this.pnlAcessar.Name = "pnlAcessar";
            this.pnlAcessar.Size = new System.Drawing.Size(532, 289);
            this.pnlAcessar.TabIndex = 22;
            // 
            // lblCaminho
            // 
            this.lblCaminho.Location = new System.Drawing.Point(409, 150);
            this.lblCaminho.Name = "lblCaminho";
            this.lblCaminho.Size = new System.Drawing.Size(100, 23);
            this.lblCaminho.TabIndex = 25;
            // 
            // gridRegional
            // 
            this.gridRegional.AllowUserToAddRows = false;
            this.gridRegional.AllowUserToDeleteRows = false;
            this.gridRegional.AllowUserToResizeRows = false;
            this.gridRegional.BackgroundColor = System.Drawing.Color.White;
            this.gridRegional.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegional.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridRegional.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridRegional.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridRegional.DisabledCell = null;
            this.gridRegional.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridRegional.Enabled = false;
            this.gridRegional.EnableHeadersVisualStyles = false;
            this.gridRegional.Location = new System.Drawing.Point(13, 35);
            this.gridRegional.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridRegional.MultiSelect = false;
            this.gridRegional.Name = "gridRegional";
            this.gridRegional.ReadOnly = true;
            this.gridRegional.RowHeadersVisible = false;
            this.gridRegional.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridRegional.RowTemplate.Height = 18;
            this.gridRegional.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegional.Size = new System.Drawing.Size(499, 110);
            this.gridRegional.TabIndex = 24;
            this.gridRegional.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridRegional_RowStateChanged);
            this.gridRegional.SelectionChanged += new System.EventHandler(this.gridRegional_SelectionChanged);
            // 
            // cboConexao
            // 
            this.cboConexao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConexao.Enabled = false;
            this.cboConexao.FormattingEnabled = true;
            this.cboConexao.Location = new System.Drawing.Point(91, 8);
            this.cboConexao.Name = "cboConexao";
            this.cboConexao.Size = new System.Drawing.Size(333, 21);
            this.cboConexao.TabIndex = 23;
            this.cboConexao.SelectedIndexChanged += new System.EventHandler(this.cboConexao_SelectedIndexChanged);
            // 
            // lblConexao
            // 
            this.lblConexao.AutoSize = true;
            this.lblConexao.Enabled = false;
            this.lblConexao.Location = new System.Drawing.Point(7, 11);
            this.lblConexao.Name = "lblConexao";
            this.lblConexao.Size = new System.Drawing.Size(82, 13);
            this.lblConexao.TabIndex = 22;
            this.lblConexao.Text = "Base de Dados:";
            // 
            // pnlConexao
            // 
            this.pnlConexao.BackColor = System.Drawing.Color.Transparent;
            this.pnlConexao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConexao.Controls.Add(this.btnSair);
            this.pnlConexao.Controls.Add(this.pnlAcessar);
            this.pnlConexao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlConexao.Location = new System.Drawing.Point(0, 0);
            this.pnlConexao.Name = "pnlConexao";
            this.pnlConexao.Size = new System.Drawing.Size(545, 526);
            this.pnlConexao.TabIndex = 23;
            // 
            // frmAcessar
            // 
            this.AcceptButton = this.btnConectar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ccbconn.Properties.Resources.fundo_ccb;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnSair;
            this.ClientSize = new System.Drawing.Size(545, 526);
            this.Controls.Add(this.pnlConexao);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAcessar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Acessar Sistema";
            this.gpoAtualiza.ResumeLayout(false);
            this.gpoAtualiza.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctPrepara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCopiarArquivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctCopiar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctBaixar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctVersao)).EndInit();
            this.pnlAcessar.ResumeLayout(false);
            this.pnlAcessar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegional)).EndInit();
            this.pnlConexao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label lblPrepara;
        private System.Windows.Forms.Label lblCopiarArquivo;
        private System.Windows.Forms.Label lblCopiar;
        private System.Windows.Forms.Label lblBaixar;
        private System.Windows.Forms.GroupBox gpoAtualiza;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.ImageList imgAcessar;
        private System.Windows.Forms.PictureBox pctPrepara;
        private System.Windows.Forms.PictureBox pctCopiarArquivo;
        private System.Windows.Forms.PictureBox pctCopiar;
        private System.Windows.Forms.PictureBox pctBaixar;
        private System.Windows.Forms.PictureBox pctVersao;
        private System.Windows.Forms.Button btnConexao;
        private System.Windows.Forms.Panel pnlAcessar;
        private BLL.validacoes.Controles.ComboBoxPersonal cboConexao;
        private System.Windows.Forms.Label lblConexao;
        private BLL.validacoes.Controles.DataGridViewPersonal gridRegional;
        private System.Windows.Forms.Panel pnlConexao;
        private System.Windows.Forms.Label lblCaminho;
    }
}