namespace ccbadm
{
    partial class frmTipoReuniao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTipoReuniao));
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tipForm = new System.Windows.Forms.ToolTip(this.components);
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescricao = new BLL.validacoes.Controles.TextBoxPersonal();
            this.pnlTipo = new System.Windows.Forms.Panel();
            this.gpoCargo = new System.Windows.Forms.GroupBox();
            this.btnDesCargo = new System.Windows.Forms.Button();
            this.btnSelCargo = new System.Windows.Forms.Button();
            this.gridCargo = new BLL.validacoes.Controles.DataGridViewPersonal();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.chkExigeCadastro = new System.Windows.Forms.CheckBox();
            this.pnlTipo.SuspendLayout();
            this.gpoCargo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(262, 282);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(90, 30);
            this.btnSalvar.TabIndex = 3;
            this.btnSalvar.Text = "&Salvar";
            this.tipForm.SetToolTip(this.btnSalvar, "Salvar alterações");
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(357, 282);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "&Cancelar";
            this.tipForm.SetToolTip(this.btnCancelar, "Cancelar alterações");
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightGray;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.txtCodigo.Location = new System.Drawing.Point(72, 13);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtCodigo.MaxLength = 6;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(64, 21);
            this.txtCodigo.TabIndex = 106;
            this.txtCodigo.Text = "00000";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tipForm.SetToolTip(this.txtCodigo, "Código");
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.White;
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(72, 39);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(350, 21);
            this.txtDescricao.TabIndex = 108;
            this.tipForm.SetToolTip(this.txtDescricao, "Descrição");
            this.txtDescricao.Validacao = BLL.validacoes.Controles.TextBoxPersonal.TipoValida.Nenhum;
            // 
            // pnlTipo
            // 
            this.pnlTipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipo.Controls.Add(this.chkExigeCadastro);
            this.pnlTipo.Controls.Add(this.gpoCargo);
            this.pnlTipo.Controls.Add(this.txtDescricao);
            this.pnlTipo.Controls.Add(this.lblDescricao);
            this.pnlTipo.Controls.Add(this.txtCodigo);
            this.pnlTipo.Controls.Add(this.lblCodigo);
            this.pnlTipo.Location = new System.Drawing.Point(6, 6);
            this.pnlTipo.Name = "pnlTipo";
            this.pnlTipo.Size = new System.Drawing.Size(440, 272);
            this.pnlTipo.TabIndex = 5;
            // 
            // gpoCargo
            // 
            this.gpoCargo.Controls.Add(this.btnDesCargo);
            this.gpoCargo.Controls.Add(this.btnSelCargo);
            this.gpoCargo.Controls.Add(this.gridCargo);
            this.gpoCargo.ForeColor = System.Drawing.SystemColors.Highlight;
            this.gpoCargo.Location = new System.Drawing.Point(8, 68);
            this.gpoCargo.Name = "gpoCargo";
            this.gpoCargo.Size = new System.Drawing.Size(422, 194);
            this.gpoCargo.TabIndex = 110;
            this.gpoCargo.TabStop = false;
            this.gpoCargo.Text = "Quais os ministérios que participarão";
            // 
            // btnDesCargo
            // 
            this.btnDesCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDesCargo.Image = global::ccbadm.Properties.Resources.DesTodos;
            this.btnDesCargo.Location = new System.Drawing.Point(334, 163);
            this.btnDesCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDesCargo.Name = "btnDesCargo";
            this.btnDesCargo.Size = new System.Drawing.Size(80, 25);
            this.btnDesCargo.TabIndex = 5;
            this.btnDesCargo.Text = "Nenhum";
            this.btnDesCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDesCargo.UseVisualStyleBackColor = true;
            this.btnDesCargo.Click += new System.EventHandler(this.btnDesCargo_Click);
            // 
            // btnSelCargo
            // 
            this.btnSelCargo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelCargo.Image = global::ccbadm.Properties.Resources.SelTodos;
            this.btnSelCargo.Location = new System.Drawing.Point(249, 163);
            this.btnSelCargo.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSelCargo.Name = "btnSelCargo";
            this.btnSelCargo.Size = new System.Drawing.Size(80, 25);
            this.btnSelCargo.TabIndex = 4;
            this.btnSelCargo.Text = "Todos";
            this.btnSelCargo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSelCargo.UseVisualStyleBackColor = true;
            this.btnSelCargo.Click += new System.EventHandler(this.btnSelCargo_Click);
            // 
            // gridCargo
            // 
            this.gridCargo.AllowUserToAddRows = false;
            this.gridCargo.AllowUserToDeleteRows = false;
            this.gridCargo.AllowUserToResizeRows = false;
            this.gridCargo.BackgroundColor = System.Drawing.Color.White;
            this.gridCargo.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridCargo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCargo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridCargo.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridCargo.DisabledCell = null;
            this.gridCargo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCargo.EnableHeadersVisualStyles = false;
            this.gridCargo.Location = new System.Drawing.Point(7, 17);
            this.gridCargo.ModoOpera = BLL.validacoes.Controles.DataGridViewPersonal.modoOpera.Nenhum;
            this.gridCargo.MultiSelect = false;
            this.gridCargo.Name = "gridCargo";
            this.gridCargo.ReadOnly = true;
            this.gridCargo.RowHeadersVisible = false;
            this.gridCargo.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCargo.RowTemplate.Height = 18;
            this.gridCargo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCargo.Size = new System.Drawing.Size(407, 142);
            this.gridCargo.TabIndex = 0;
            this.gridCargo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCargo_CellClick);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(8, 43);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(57, 13);
            this.lblDescricao.TabIndex = 109;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Enabled = false;
            this.lblCodigo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblCodigo.Location = new System.Drawing.Point(8, 17);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(44, 13);
            this.lblCodigo.TabIndex = 107;
            this.lblCodigo.Text = "Código:";
            // 
            // chkExigeCadastro
            // 
            this.chkExigeCadastro.AutoSize = true;
            this.chkExigeCadastro.Location = new System.Drawing.Point(176, 15);
            this.chkExigeCadastro.Name = "chkExigeCadastro";
            this.chkExigeCadastro.Size = new System.Drawing.Size(246, 17);
            this.chkExigeCadastro.TabIndex = 111;
            this.chkExigeCadastro.Text = "Lista de presença exige cadastro de pessoas?";
            this.chkExigeCadastro.UseVisualStyleBackColor = true;
            // 
            // frmTipoReuniao
            // 
            this.AcceptButton = this.btnSalvar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(452, 319);
            this.Controls.Add(this.pnlTipo);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTipoReuniao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo de Reunião";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTipoReuniao_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTipoReuniao_FormClosed);
            this.Load += new System.EventHandler(this.frmTipoReuniao_Load);
            this.pnlTipo.ResumeLayout(false);
            this.pnlTipo.PerformLayout();
            this.gpoCargo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCargo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ToolTip tipForm;
        private System.Windows.Forms.Panel pnlTipo;
        private BLL.validacoes.Controles.TextBoxPersonal txtDescricao;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox gpoCargo;
        private System.Windows.Forms.Button btnDesCargo;
        private System.Windows.Forms.Button btnSelCargo;
        private BLL.validacoes.Controles.DataGridViewPersonal gridCargo;
        private System.Windows.Forms.CheckBox chkExigeCadastro;
    }
}