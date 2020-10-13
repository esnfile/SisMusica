namespace ccbusua
{
    partial class frmUsuarioBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipUsuario = new System.Windows.Forms.ToolTip(this.components);
            this.txtNome = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnNomeVisual = new System.Windows.Forms.Button();
            this.btnNomeIns = new System.Windows.Forms.Button();
            this.btnNomeEditar = new System.Windows.Forms.Button();
            this.btnNomeExc = new System.Windows.Forms.Button();
            this.btnNome = new System.Windows.Forms.Button();
            this.btnPesVisual = new System.Windows.Forms.Button();
            this.btnPesIns = new System.Windows.Forms.Button();
            this.btnPesEditar = new System.Windows.Forms.Button();
            this.btnPesExc = new System.Windows.Forms.Button();
            this.btnPessoa = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.imgUsuario = new System.Windows.Forms.ImageList(this.components);
            this.tabUsuario = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabNome = new System.Windows.Forms.TabPage();
            this.gridNome = new System.Windows.Forms.DataGridView();
            this.tabPessoa = new System.Windows.Forms.TabPage();
            this.lblNomePessoa = new System.Windows.Forms.Label();
            this.lblCodPessoa = new System.Windows.Forms.Label();
            this.gridPessoa = new System.Windows.Forms.DataGridView();
            this.lblInativo = new System.Windows.Forms.Label();
            this.pctInativo = new System.Windows.Forms.PictureBox();
            this.lblAtivo = new System.Windows.Forms.Label();
            this.pctAtivo = new System.Windows.Forms.PictureBox();
            this.tabUsuario.SuspendLayout();
            this.tabNome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).BeginInit();
            this.tabPessoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInativo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAtivo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.Color.LightYellow;
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Location = new System.Drawing.Point(6, 7);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(150, 21);
            this.txtNome.TabIndex = 0;
            this.tipUsuario.SetToolTip(this.txtNome, "Nome para pesquisar");
            this.txtNome.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtNome.Enter += new System.EventHandler(this.txtNome_Enter);
            this.txtNome.Leave += new System.EventHandler(this.txtNome_Leave);
            // 
            // btnNomeVisual
            // 
            this.btnNomeVisual.AccessibleDescription = "";
            this.btnNomeVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeVisual.Enabled = false;
            this.btnNomeVisual.Location = new System.Drawing.Point(273, 322);
            this.btnNomeVisual.Name = "btnNomeVisual";
            this.btnNomeVisual.Size = new System.Drawing.Size(90, 30);
            this.btnNomeVisual.TabIndex = 3;
            this.btnNomeVisual.Text = "&Visualizar";
            this.tipUsuario.SetToolTip(this.btnNomeVisual, "Visualizar");
            this.btnNomeVisual.UseVisualStyleBackColor = true;
            this.btnNomeVisual.Click += new System.EventHandler(this.btnNomeVisual_Click);
            // 
            // btnNomeIns
            // 
            this.btnNomeIns.AccessibleDescription = "";
            this.btnNomeIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeIns.Enabled = false;
            this.btnNomeIns.Location = new System.Drawing.Point(367, 322);
            this.btnNomeIns.Name = "btnNomeIns";
            this.btnNomeIns.Size = new System.Drawing.Size(90, 30);
            this.btnNomeIns.TabIndex = 4;
            this.btnNomeIns.Text = "&Inserir";
            this.tipUsuario.SetToolTip(this.btnNomeIns, "Inserir");
            this.btnNomeIns.UseVisualStyleBackColor = true;
            this.btnNomeIns.Click += new System.EventHandler(this.btnNomeIns_Click);
            // 
            // btnNomeEditar
            // 
            this.btnNomeEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeEditar.Enabled = false;
            this.btnNomeEditar.Location = new System.Drawing.Point(461, 322);
            this.btnNomeEditar.Name = "btnNomeEditar";
            this.btnNomeEditar.Size = new System.Drawing.Size(90, 30);
            this.btnNomeEditar.TabIndex = 5;
            this.btnNomeEditar.Text = "&Editar";
            this.tipUsuario.SetToolTip(this.btnNomeEditar, "Editar");
            this.btnNomeEditar.UseVisualStyleBackColor = true;
            this.btnNomeEditar.Click += new System.EventHandler(this.btnNomeEditar_Click);
            // 
            // btnNomeExc
            // 
            this.btnNomeExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNomeExc.Enabled = false;
            this.btnNomeExc.Location = new System.Drawing.Point(555, 322);
            this.btnNomeExc.Name = "btnNomeExc";
            this.btnNomeExc.Size = new System.Drawing.Size(90, 30);
            this.btnNomeExc.TabIndex = 6;
            this.btnNomeExc.Text = "E&xcluir";
            this.tipUsuario.SetToolTip(this.btnNomeExc, "Excluir");
            this.btnNomeExc.UseVisualStyleBackColor = true;
            this.btnNomeExc.Click += new System.EventHandler(this.btnNomeExc_Click);
            // 
            // btnNome
            // 
            this.btnNome.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNome.Image = ((System.Drawing.Image)(resources.GetObject("btnNome.Image")));
            this.btnNome.Location = new System.Drawing.Point(159, 6);
            this.btnNome.Name = "btnNome";
            this.btnNome.Size = new System.Drawing.Size(23, 23);
            this.btnNome.TabIndex = 1;
            this.tipUsuario.SetToolTip(this.btnNome, "Pesquisar");
            this.btnNome.UseVisualStyleBackColor = true;
            this.btnNome.Click += new System.EventHandler(this.btnNome_Click);
            // 
            // btnPesVisual
            // 
            this.btnPesVisual.AccessibleDescription = "";
            this.btnPesVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesVisual.Enabled = false;
            this.btnPesVisual.Location = new System.Drawing.Point(273, 322);
            this.btnPesVisual.Name = "btnPesVisual";
            this.btnPesVisual.Size = new System.Drawing.Size(90, 30);
            this.btnPesVisual.TabIndex = 3;
            this.btnPesVisual.Text = "&Visualizar";
            this.tipUsuario.SetToolTip(this.btnPesVisual, "Visualizar");
            this.btnPesVisual.UseVisualStyleBackColor = true;
            this.btnPesVisual.Click += new System.EventHandler(this.btnPesVisual_Click);
            // 
            // btnPesIns
            // 
            this.btnPesIns.AccessibleDescription = "";
            this.btnPesIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesIns.Enabled = false;
            this.btnPesIns.Location = new System.Drawing.Point(367, 322);
            this.btnPesIns.Name = "btnPesIns";
            this.btnPesIns.Size = new System.Drawing.Size(90, 30);
            this.btnPesIns.TabIndex = 4;
            this.btnPesIns.Text = "&Inserir";
            this.tipUsuario.SetToolTip(this.btnPesIns, "Inserir");
            this.btnPesIns.UseVisualStyleBackColor = true;
            this.btnPesIns.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // btnPesEditar
            // 
            this.btnPesEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesEditar.Enabled = false;
            this.btnPesEditar.Location = new System.Drawing.Point(461, 322);
            this.btnPesEditar.Name = "btnPesEditar";
            this.btnPesEditar.Size = new System.Drawing.Size(90, 30);
            this.btnPesEditar.TabIndex = 5;
            this.btnPesEditar.Text = "&Editar";
            this.tipUsuario.SetToolTip(this.btnPesEditar, "Editar");
            this.btnPesEditar.UseVisualStyleBackColor = true;
            this.btnPesEditar.Click += new System.EventHandler(this.btnPesEditar_Click);
            // 
            // btnPesExc
            // 
            this.btnPesExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesExc.Enabled = false;
            this.btnPesExc.Location = new System.Drawing.Point(555, 322);
            this.btnPesExc.Name = "btnPesExc";
            this.btnPesExc.Size = new System.Drawing.Size(90, 30);
            this.btnPesExc.TabIndex = 6;
            this.btnPesExc.Text = "E&xcluir";
            this.tipUsuario.SetToolTip(this.btnPesExc, "Excluir");
            this.btnPesExc.UseVisualStyleBackColor = true;
            this.btnPesExc.Click += new System.EventHandler(this.btnPesExc_Click);
            // 
            // btnPessoa
            // 
            this.btnPessoa.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPessoa.Image = global::ccbusua.Properties.Resources.PesquisaOS;
            this.btnPessoa.Location = new System.Drawing.Point(6, 3);
            this.btnPessoa.Name = "btnPessoa";
            this.btnPessoa.Size = new System.Drawing.Size(90, 30);
            this.btnPessoa.TabIndex = 1;
            this.btnPessoa.Text = "  Pessoa";
            this.btnPessoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.tipUsuario.SetToolTip(this.btnPessoa, "Pesquisar");
            this.btnPessoa.UseVisualStyleBackColor = true;
            this.btnPessoa.Click += new System.EventHandler(this.btnPessoa_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(582, 401);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipUsuario.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // imgUsuario
            // 
            this.imgUsuario.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUsuario.ImageStream")));
            this.imgUsuario.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUsuario.Images.SetKeyName(0, "BolaVerde.ico");
            this.imgUsuario.Images.SetKeyName(1, "BolaVermelha.ico");
            // 
            // tabUsuario
            // 
            this.tabUsuario.Controls.Add(this.tabNome);
            this.tabUsuario.Controls.Add(this.tabPessoa);
            this.tabUsuario.Location = new System.Drawing.Point(9, 9);
            this.tabUsuario.Name = "tabUsuario";
            this.tabUsuario.SelectedIndex = 0;
            this.tabUsuario.Size = new System.Drawing.Size(663, 386);
            this.tabUsuario.TabIndex = 31;
            this.tabUsuario.SelectedIndexChanged += new System.EventHandler(this.tabUsuario_SelectedIndexChanged);
            // 
            // tabNome
            // 
            this.tabNome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabNome.Controls.Add(this.txtNome);
            this.tabNome.Controls.Add(this.gridNome);
            this.tabNome.Controls.Add(this.btnNomeVisual);
            this.tabNome.Controls.Add(this.btnNomeIns);
            this.tabNome.Controls.Add(this.btnNomeEditar);
            this.tabNome.Controls.Add(this.btnNomeExc);
            this.tabNome.Controls.Add(this.btnNome);
            this.tabNome.Location = new System.Drawing.Point(4, 22);
            this.tabNome.Name = "tabNome";
            this.tabNome.Padding = new System.Windows.Forms.Padding(3);
            this.tabNome.Size = new System.Drawing.Size(655, 360);
            this.tabNome.TabIndex = 1;
            this.tabNome.Text = "Usuário";
            // 
            // gridNome
            // 
            this.gridNome.AllowUserToAddRows = false;
            this.gridNome.AllowUserToDeleteRows = false;
            this.gridNome.AllowUserToResizeRows = false;
            this.gridNome.BackgroundColor = System.Drawing.Color.White;
            this.gridNome.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridNome.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.gridNome.ColumnHeadersHeight = 17;
            this.gridNome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridNome.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridNome.EnableHeadersVisualStyles = false;
            this.gridNome.Location = new System.Drawing.Point(6, 36);
            this.gridNome.MultiSelect = false;
            this.gridNome.Name = "gridNome";
            this.gridNome.ReadOnly = true;
            this.gridNome.RowHeadersVisible = false;
            this.gridNome.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridNome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridNome.Size = new System.Drawing.Size(639, 280);
            this.gridNome.TabIndex = 2;
            this.gridNome.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridNome_CellDoubleClick);
            this.gridNome.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridNome_RowStateChanged);
            this.gridNome.SelectionChanged += new System.EventHandler(this.gridNome_SelectionChanged);
            // 
            // tabPessoa
            // 
            this.tabPessoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabPessoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPessoa.Controls.Add(this.lblNomePessoa);
            this.tabPessoa.Controls.Add(this.lblCodPessoa);
            this.tabPessoa.Controls.Add(this.gridPessoa);
            this.tabPessoa.Controls.Add(this.btnPesVisual);
            this.tabPessoa.Controls.Add(this.btnPesIns);
            this.tabPessoa.Controls.Add(this.btnPesEditar);
            this.tabPessoa.Controls.Add(this.btnPesExc);
            this.tabPessoa.Controls.Add(this.btnPessoa);
            this.tabPessoa.Location = new System.Drawing.Point(4, 22);
            this.tabPessoa.Name = "tabPessoa";
            this.tabPessoa.Padding = new System.Windows.Forms.Padding(3);
            this.tabPessoa.Size = new System.Drawing.Size(655, 360);
            this.tabPessoa.TabIndex = 2;
            this.tabPessoa.Text = "Pessoa";
            // 
            // lblNomePessoa
            // 
            this.lblNomePessoa.Enabled = false;
            this.lblNomePessoa.Location = new System.Drawing.Point(104, 10);
            this.lblNomePessoa.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNomePessoa.Name = "lblNomePessoa";
            this.lblNomePessoa.Size = new System.Drawing.Size(518, 17);
            this.lblNomePessoa.TabIndex = 116;
            // 
            // lblCodPessoa
            // 
            this.lblCodPessoa.Location = new System.Drawing.Point(117, 5);
            this.lblCodPessoa.Name = "lblCodPessoa";
            this.lblCodPessoa.Size = new System.Drawing.Size(46, 17);
            this.lblCodPessoa.TabIndex = 117;
            this.lblCodPessoa.TextChanged += new System.EventHandler(this.lblCodPessoa_TextChanged);
            // 
            // gridPessoa
            // 
            this.gridPessoa.AllowUserToAddRows = false;
            this.gridPessoa.AllowUserToDeleteRows = false;
            this.gridPessoa.AllowUserToResizeRows = false;
            this.gridPessoa.BackgroundColor = System.Drawing.Color.White;
            this.gridPessoa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPessoa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gridPessoa.ColumnHeadersHeight = 17;
            this.gridPessoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridPessoa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPessoa.EnableHeadersVisualStyles = false;
            this.gridPessoa.Location = new System.Drawing.Point(6, 36);
            this.gridPessoa.MultiSelect = false;
            this.gridPessoa.Name = "gridPessoa";
            this.gridPessoa.ReadOnly = true;
            this.gridPessoa.RowHeadersVisible = false;
            this.gridPessoa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridPessoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPessoa.Size = new System.Drawing.Size(639, 280);
            this.gridPessoa.TabIndex = 2;
            this.gridPessoa.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridPessoa_CellDoubleClick);
            this.gridPessoa.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridPessoa_RowStateChanged);
            this.gridPessoa.SelectionChanged += new System.EventHandler(this.gridPessoa_SelectionChanged);
            // 
            // lblInativo
            // 
            this.lblInativo.AutoSize = true;
            this.lblInativo.Location = new System.Drawing.Point(94, 404);
            this.lblInativo.Name = "lblInativo";
            this.lblInativo.Size = new System.Drawing.Size(41, 13);
            this.lblInativo.TabIndex = 36;
            this.lblInativo.Text = "Inativo";
            // 
            // pctInativo
            // 
            this.pctInativo.Location = new System.Drawing.Point(78, 401);
            this.pctInativo.Name = "pctInativo";
            this.pctInativo.Size = new System.Drawing.Size(16, 20);
            this.pctInativo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctInativo.TabIndex = 35;
            this.pctInativo.TabStop = false;
            // 
            // lblAtivo
            // 
            this.lblAtivo.AutoSize = true;
            this.lblAtivo.Location = new System.Drawing.Point(26, 404);
            this.lblAtivo.Name = "lblAtivo";
            this.lblAtivo.Size = new System.Drawing.Size(32, 13);
            this.lblAtivo.TabIndex = 34;
            this.lblAtivo.Text = "Ativo";
            // 
            // pctAtivo
            // 
            this.pctAtivo.Location = new System.Drawing.Point(9, 401);
            this.pctAtivo.Name = "pctAtivo";
            this.pctAtivo.Size = new System.Drawing.Size(16, 20);
            this.pctAtivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAtivo.TabIndex = 33;
            this.pctAtivo.TabStop = false;
            // 
            // frmUsuarioBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(680, 439);
            this.Controls.Add(this.tabUsuario);
            this.Controls.Add(this.lblInativo);
            this.Controls.Add(this.pctInativo);
            this.Controls.Add(this.lblAtivo);
            this.Controls.Add(this.pctAtivo);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUsuarioBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuários do Sistema";
            this.Load += new System.EventHandler(this.frmUsuarioBusca_Load);
            this.tabUsuario.ResumeLayout(false);
            this.tabNome.ResumeLayout(false);
            this.tabNome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridNome)).EndInit();
            this.tabPessoa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPessoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctInativo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctAtivo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tipUsuario;
        private System.Windows.Forms.ImageList imgUsuario;
        private BLL.validacoes.Controles.tabControlPersonal tabUsuario;
        private System.Windows.Forms.TabPage tabNome;
        private BLL.validacoes.Controles.TextBoxPersonal txtNome;
        private System.Windows.Forms.DataGridView gridNome;
        private System.Windows.Forms.Button btnNomeVisual;
        private System.Windows.Forms.Button btnNomeIns;
        private System.Windows.Forms.Button btnNomeEditar;
        private System.Windows.Forms.Button btnNomeExc;
        private System.Windows.Forms.Button btnNome;
        private System.Windows.Forms.TabPage tabPessoa;
        private System.Windows.Forms.DataGridView gridPessoa;
        private System.Windows.Forms.Button btnPesVisual;
        private System.Windows.Forms.Button btnPesIns;
        private System.Windows.Forms.Button btnPesEditar;
        private System.Windows.Forms.Button btnPesExc;
        private System.Windows.Forms.Button btnPessoa;
        private System.Windows.Forms.Label lblInativo;
        private System.Windows.Forms.PictureBox pctInativo;
        private System.Windows.Forms.Label lblAtivo;
        private System.Windows.Forms.PictureBox pctAtivo;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label lblNomePessoa;
        private System.Windows.Forms.Label lblCodPessoa;
    }
}