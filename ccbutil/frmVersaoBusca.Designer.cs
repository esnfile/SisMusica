namespace ccbutil
{
    partial class frmVersaoBusca
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVersaoBusca));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tipVersao = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new BLL.validacoes.Controles.TextBoxPersonal();
            this.btnCodVisual = new System.Windows.Forms.Button();
            this.btnCodIns = new System.Windows.Forms.Button();
            this.btnCodEditar = new System.Windows.Forms.Button();
            this.btnCodExc = new System.Windows.Forms.Button();
            this.btnCod = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.tabVersao = new BLL.validacoes.Controles.tabControlPersonal();
            this.tabCodigo = new System.Windows.Forms.TabPage();
            this.gridCodigo = new System.Windows.Forms.DataGridView();
            this.tabVersao.SuspendLayout();
            this.tabCodigo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightYellow;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Location = new System.Drawing.Point(6, 7);
            this.txtCodigo.MaxLength = 100;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(150, 21);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipVersao.SetToolTip(this.txtCodigo, "Código para pesquisar");
            this.txtCodigo.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            this.txtCodigo.Enter += new System.EventHandler(this.txtCodigo_Enter);
            this.txtCodigo.Leave += new System.EventHandler(this.txtCodigo_Leave);
            // 
            // btnCodVisual
            // 
            this.btnCodVisual.AccessibleDescription = "";
            this.btnCodVisual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodVisual.Enabled = false;
            this.btnCodVisual.Location = new System.Drawing.Point(111, 295);
            this.btnCodVisual.Name = "btnCodVisual";
            this.btnCodVisual.Size = new System.Drawing.Size(90, 30);
            this.btnCodVisual.TabIndex = 3;
            this.btnCodVisual.Text = "&Visualizar";
            this.tipVersao.SetToolTip(this.btnCodVisual, "Visualizar");
            this.btnCodVisual.UseVisualStyleBackColor = true;
            this.btnCodVisual.Click += new System.EventHandler(this.btnCodVisual_Click);
            // 
            // btnCodIns
            // 
            this.btnCodIns.AccessibleDescription = "";
            this.btnCodIns.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodIns.Enabled = false;
            this.btnCodIns.Location = new System.Drawing.Point(205, 295);
            this.btnCodIns.Name = "btnCodIns";
            this.btnCodIns.Size = new System.Drawing.Size(90, 30);
            this.btnCodIns.TabIndex = 4;
            this.btnCodIns.Text = "&Inserir";
            this.tipVersao.SetToolTip(this.btnCodIns, "Inserir");
            this.btnCodIns.UseVisualStyleBackColor = true;
            this.btnCodIns.Click += new System.EventHandler(this.btnCodIns_Click);
            // 
            // btnCodEditar
            // 
            this.btnCodEditar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodEditar.Enabled = false;
            this.btnCodEditar.Location = new System.Drawing.Point(299, 295);
            this.btnCodEditar.Name = "btnCodEditar";
            this.btnCodEditar.Size = new System.Drawing.Size(90, 30);
            this.btnCodEditar.TabIndex = 5;
            this.btnCodEditar.Text = "&Editar";
            this.tipVersao.SetToolTip(this.btnCodEditar, "Editar");
            this.btnCodEditar.UseVisualStyleBackColor = true;
            this.btnCodEditar.Click += new System.EventHandler(this.btnCodEditar_Click);
            // 
            // btnCodExc
            // 
            this.btnCodExc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCodExc.Enabled = false;
            this.btnCodExc.Location = new System.Drawing.Point(393, 295);
            this.btnCodExc.Name = "btnCodExc";
            this.btnCodExc.Size = new System.Drawing.Size(90, 30);
            this.btnCodExc.TabIndex = 6;
            this.btnCodExc.Text = "E&xcluir";
            this.tipVersao.SetToolTip(this.btnCodExc, "Excluir");
            this.btnCodExc.UseVisualStyleBackColor = true;
            this.btnCodExc.Click += new System.EventHandler(this.btnCodExc_Click);
            // 
            // btnCod
            // 
            this.btnCod.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCod.Image = ((System.Drawing.Image)(resources.GetObject("btnCod.Image")));
            this.btnCod.Location = new System.Drawing.Point(159, 6);
            this.btnCod.Name = "btnCod";
            this.btnCod.Size = new System.Drawing.Size(23, 23);
            this.btnCod.TabIndex = 1;
            this.tipVersao.SetToolTip(this.btnCod, "Pesquisar");
            this.btnCod.UseVisualStyleBackColor = true;
            this.btnCod.Click += new System.EventHandler(this.btnCod_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.AccessibleDescription = "";
            this.btnFechar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(418, 375);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(90, 30);
            this.btnFechar.TabIndex = 32;
            this.btnFechar.Text = "&Fechar";
            this.tipVersao.SetToolTip(this.btnFechar, "Fechar");
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // tabVersao
            // 
            this.tabVersao.Controls.Add(this.tabCodigo);
            this.tabVersao.Location = new System.Drawing.Point(9, 9);
            this.tabVersao.Name = "tabVersao";
            this.tabVersao.SelectedIndex = 0;
            this.tabVersao.Size = new System.Drawing.Size(498, 360);
            this.tabVersao.TabIndex = 31;
            this.tabVersao.SelectedIndexChanged += new System.EventHandler(this.tabVersao_SelectedIndexChanged);
            // 
            // tabCodigo
            // 
            this.tabCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.tabCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabCodigo.Controls.Add(this.txtCodigo);
            this.tabCodigo.Controls.Add(this.btnCodVisual);
            this.tabCodigo.Controls.Add(this.btnCodIns);
            this.tabCodigo.Controls.Add(this.btnCodEditar);
            this.tabCodigo.Controls.Add(this.btnCodExc);
            this.tabCodigo.Controls.Add(this.btnCod);
            this.tabCodigo.Controls.Add(this.gridCodigo);
            this.tabCodigo.Location = new System.Drawing.Point(4, 22);
            this.tabCodigo.Name = "tabCodigo";
            this.tabCodigo.Padding = new System.Windows.Forms.Padding(3);
            this.tabCodigo.Size = new System.Drawing.Size(490, 334);
            this.tabCodigo.TabIndex = 0;
            this.tabCodigo.Text = "Código";
            // 
            // gridCodigo
            // 
            this.gridCodigo.AllowUserToAddRows = false;
            this.gridCodigo.AllowUserToDeleteRows = false;
            this.gridCodigo.AllowUserToResizeRows = false;
            this.gridCodigo.BackgroundColor = System.Drawing.Color.White;
            this.gridCodigo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCodigo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridCodigo.ColumnHeadersHeight = 17;
            this.gridCodigo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCodigo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCodigo.EnableHeadersVisualStyles = false;
            this.gridCodigo.Location = new System.Drawing.Point(6, 36);
            this.gridCodigo.MultiSelect = false;
            this.gridCodigo.Name = "gridCodigo";
            this.gridCodigo.ReadOnly = true;
            this.gridCodigo.RowHeadersVisible = false;
            this.gridCodigo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCodigo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCodigo.Size = new System.Drawing.Size(477, 253);
            this.gridCodigo.TabIndex = 2;
            this.gridCodigo.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCodigo_CellDoubleClick);
            this.gridCodigo.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.gridCodigo_RowStateChanged);
            this.gridCodigo.SelectionChanged += new System.EventHandler(this.gridCodigo_SelectionChanged);
            // 
            // frmVersaoBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(514, 411);
            this.Controls.Add(this.tabVersao);
            this.Controls.Add(this.btnFechar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVersaoBusca";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controle de Versões";
            this.Load += new System.EventHandler(this.frmVersaoBusca_Load);
            this.tabVersao.ResumeLayout(false);
            this.tabCodigo.ResumeLayout(false);
            this.tabCodigo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCodigo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip tipVersao;
        private BLL.validacoes.Controles.tabControlPersonal tabVersao;
        private System.Windows.Forms.TabPage tabCodigo;
        private BLL.validacoes.Controles.TextBoxPersonal txtCodigo;
        private System.Windows.Forms.Button btnCodVisual;
        private System.Windows.Forms.Button btnCodIns;
        private System.Windows.Forms.Button btnCodEditar;
        private System.Windows.Forms.Button btnCodExc;
        private System.Windows.Forms.Button btnCod;
        private System.Windows.Forms.DataGridView gridCodigo;
        private System.Windows.Forms.Button btnFechar;
    }
}