namespace ccbrepess
{
    partial class frmAnalisePessoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalisePessoa));
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlAnalise = new System.Windows.Forms.Panel();
            this.tvwDados = new System.Windows.Forms.TreeView();
            this.pnlAnalise.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFechar.Location = new System.Drawing.Point(644, 444);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(95, 35);
            this.btnFechar.TabIndex = 2;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pnlAnalise
            // 
            this.pnlAnalise.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAnalise.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.pnlAnalise.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAnalise.Controls.Add(this.tvwDados);
            this.pnlAnalise.Location = new System.Drawing.Point(7, 7);
            this.pnlAnalise.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pnlAnalise.Name = "pnlAnalise";
            this.pnlAnalise.Size = new System.Drawing.Size(731, 433);
            this.pnlAnalise.TabIndex = 0;
            // 
            // tvwDados
            // 
            this.tvwDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwDados.FullRowSelect = true;
            this.tvwDados.Location = new System.Drawing.Point(0, 0);
            this.tvwDados.Name = "tvwDados";
            this.tvwDados.Size = new System.Drawing.Size(729, 431);
            this.tvwDados.TabIndex = 0;
            // 
            // frmAnalisePessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.btnFechar;
            this.ClientSize = new System.Drawing.Size(745, 487);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.pnlAnalise);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "frmAnalisePessoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Análise de dados por ministério";
            this.Load += new System.EventHandler(this.frmAnalisePessoa_Load);
            this.pnlAnalise.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlAnalise;
        private System.Windows.Forms.TreeView tvwDados;
    }
}