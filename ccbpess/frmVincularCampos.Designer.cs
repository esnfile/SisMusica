namespace ccbpess
{
    partial class frmVincularCampos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVincularCampos));
            this.pnlVincular = new System.Windows.Forms.Panel();
            this.gridVincular = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlVincular.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridVincular)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlVincular
            // 
            this.pnlVincular.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlVincular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVincular.Controls.Add(this.gridVincular);
            this.pnlVincular.Location = new System.Drawing.Point(9, 9);
            this.pnlVincular.Name = "pnlVincular";
            this.pnlVincular.Size = new System.Drawing.Size(548, 400);
            this.pnlVincular.TabIndex = 0;
            // 
            // gridVincular
            // 
            this.gridVincular.AllowUserToAddRows = false;
            this.gridVincular.AllowUserToDeleteRows = false;
            this.gridVincular.AllowUserToResizeRows = false;
            this.gridVincular.BackgroundColor = System.Drawing.Color.White;
            this.gridVincular.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridVincular.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridVincular.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridVincular.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridVincular.DisabledCell = null;
            this.gridVincular.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridVincular.EnableHeadersVisualStyles = false;
            this.gridVincular.Location = new System.Drawing.Point(9, 9);
            this.gridVincular.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridVincular.MultiSelect = false;
            this.gridVincular.Name = "gridVincular";
            this.gridVincular.ReadOnly = true;
            this.gridVincular.RowHeadersVisible = false;
            this.gridVincular.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridVincular.RowTemplate.Height = 18;
            this.gridVincular.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridVincular.Size = new System.Drawing.Size(529, 379);
            this.gridVincular.TabIndex = 0;
            this.gridVincular.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridVincular_CellBeginEdit);
            this.gridVincular.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVincular_CellEndEdit);
            this.gridVincular.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVincular_CellEnter);
            this.gridVincular.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridVincular_CellLeave);
            this.gridVincular.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.gridVincular_EditingControlShowing);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.Location = new System.Drawing.Point(372, 413);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 41;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(467, 413);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 42;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmVincularCampos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(565, 450);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.pnlVincular);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVincularCampos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vinculação dos Campos a importar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmVincularCampos_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmVincularCampos_FormClosed);
            this.pnlVincular.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridVincular)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlVincular;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private BLL.validacoes.Controles.DataGridViewPersonal gridVincular;
    }
}