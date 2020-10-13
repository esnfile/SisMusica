using ENT.Erros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLL.Funcoes
{
    public partial class telaErros : Form
    {
        private Button btnContinuar;
        private ToolTip tipErros;
        private IContainer components;
        private DataGridView gridErros;
        private Button btnVoltar;
        private TextBox txtQtde;
        private Label lblQtde;
        private ImageList imgErros;

        public telaErros(List<MOD_erros> listaErros)
        {
            try
            {
                InitializeComponent();
                lista = listaErros;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(telaErros));
            this.btnContinuar = new System.Windows.Forms.Button();
            this.tipErros = new System.Windows.Forms.ToolTip(this.components);
            this.gridErros = new System.Windows.Forms.DataGridView();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.imgErros = new System.Windows.Forms.ImageList(this.components);
            this.txtQtde = new System.Windows.Forms.TextBox();
            this.lblQtde = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridErros)).BeginInit();
            this.SuspendLayout();
            // 
            // btnContinuar
            // 
            this.btnContinuar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinuar.Enabled = false;
            this.btnContinuar.Location = new System.Drawing.Point(371, 375);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(90, 30);
            this.btnContinuar.TabIndex = 4;
            this.btnContinuar.Text = "&Continuar";
            this.tipErros.SetToolTip(this.btnContinuar, "Continuar");
            this.btnContinuar.UseVisualStyleBackColor = true;
            // 
            // gridErros
            // 
            this.gridErros.AllowUserToAddRows = false;
            this.gridErros.AllowUserToDeleteRows = false;
            this.gridErros.AllowUserToResizeColumns = false;
            this.gridErros.AllowUserToResizeRows = false;
            this.gridErros.BackgroundColor = System.Drawing.Color.White;
            this.gridErros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.gridErros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridErros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridErros.EnableHeadersVisualStyles = false;
            this.gridErros.Location = new System.Drawing.Point(12, 12);
            this.gridErros.MultiSelect = false;
            this.gridErros.Name = "gridErros";
            this.gridErros.ReadOnly = true;
            this.gridErros.RowHeadersVisible = false;
            this.gridErros.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridErros.RowTemplate.Height = 18;
            this.gridErros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.gridErros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridErros.Size = new System.Drawing.Size(545, 357);
            this.gridErros.TabIndex = 6;
            this.tipErros.SetToolTip(this.gridErros, "Informações de erros");
            // 
            // btnVoltar
            // 
            this.btnVoltar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnVoltar.Location = new System.Drawing.Point(467, 375);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(90, 30);
            this.btnVoltar.TabIndex = 5;
            this.btnVoltar.Text = "&Voltar";
            this.tipErros.SetToolTip(this.btnVoltar, "Voltar");
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // imgErros
            // 
            this.imgErros.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgErros.ImageStream")));
            this.imgErros.TransparentColor = System.Drawing.Color.Transparent;
            this.imgErros.Images.SetKeyName(0, "BolaAmarela.ico");
            this.imgErros.Images.SetKeyName(1, "BolaVermelha.ico");
            // 
            // txtQtde
            // 
            this.txtQtde.BackColor = System.Drawing.Color.LightGray;
            this.txtQtde.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtde.Enabled = false;
            this.txtQtde.Location = new System.Drawing.Point(130, 377);
            this.txtQtde.Name = "txtQtde";
            this.txtQtde.Size = new System.Drawing.Size(50, 21);
            this.txtQtde.TabIndex = 8;
            this.txtQtde.Text = "000000";
            this.txtQtde.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblQtde
            // 
            this.lblQtde.AutoSize = true;
            this.lblQtde.Enabled = false;
            this.lblQtde.Location = new System.Drawing.Point(12, 381);
            this.lblQtde.Name = "lblQtde";
            this.lblQtde.Size = new System.Drawing.Size(112, 13);
            this.lblQtde.TabIndex = 7;
            this.lblQtde.Text = "Qtde Erros ou Avisos:";
            // 
            // telaErros
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(569, 417);
            this.Controls.Add(this.txtQtde);
            this.Controls.Add(this.lblQtde);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.gridErros);
            this.Controls.Add(this.btnVoltar);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "telaErros";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atenção, informações de erros";
            this.Activated += new System.EventHandler(this.telaErros_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.telaErros_FormClosed);
            this.Load += new System.EventHandler(this.telaErros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridErros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        List<MOD_erros> lista;

        private void telaErros_Load(object sender, EventArgs e)
        {
            try
            {
                this.montarGridErros(this.gridErros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void telaErros_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            //this.Close();
            //this.Dispose();
            //this.DialogResult = DialogResult.Cancel;
        }

        private void telaErros_Activated(object sender, EventArgs e)
        {
            try
            {
                this.gridErros.DataSource = lista;
                this.definirImagens(this.gridErros);
                this.txtQtde.Text = Convert.ToString(lista.Count()).PadLeft(5, '0');
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que define as imagens do grau do erro
        /// </summary>
        /// <param name="dataGrid"></param>
        private void definirImagens(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in this.gridErros.Rows)
                {
                    if (linha.Cells["Grau"].Value.Equals("Alto"))
                    {
                        this.gridErros["Status", linha.Index].Value = imgErros.Images[1];
                    }
                    else if (linha.Cells["Grau"].Value.Equals("Baixo"))
                    {
                        this.gridErros["Status", linha.Index].Value = imgErros.Images[0];
                    }
                }

                foreach (DataGridViewRow linha in this.gridErros.Rows)
                {
                    if (linha.Cells["Grau"].Value.Equals("Alto"))
                    {
                        this.btnContinuar.Enabled = false;
                        this.btnVoltar.Enabled = true;
                        break;
                    }
                    else
                    {
                        this.btnContinuar.Enabled = true;
                        this.btnVoltar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que Monta o Grid de Erros
        /// </summary>
        /// <param name="dataGrid"></param>
        private void montarGridErros(DataGridView dataGrid)
        {
            try
            {
                dataGrid.AutoGenerateColumns = false;
                dataGrid.DataSource = null;
                dataGrid.Columns.Clear();
                dataGrid.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewImageColumn colStatus = new DataGridViewImageColumn();
                colStatus.Name = "Status";
                colStatus.HeaderText = "";
                colStatus.Width = 20;
                colStatus.Frozen = false;
                colStatus.MinimumWidth = 20;
                colStatus.ReadOnly = true;
                colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colStatus.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colGrau = new DataGridViewTextBoxColumn();
                colGrau.DataPropertyName = "Grau";
                colGrau.HeaderText = "Grau";
                colGrau.Name = "Grau";
                colGrau.Width = 60;
                colGrau.Frozen = false;
                colGrau.MinimumWidth = 50;
                colGrau.ReadOnly = true;
                colGrau.FillWeight = 100;
                colGrau.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colGrau.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colGrau.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colTexto = new DataGridViewTextBoxColumn();
                colTexto.DataPropertyName = "Texto";
                colTexto.HeaderText = "Descrição do Erro";
                colTexto.Width = 50;
                colTexto.Frozen = false;
                colTexto.MinimumWidth = 45;
                colTexto.ReadOnly = true;
                colTexto.FillWeight = 100;
                colTexto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colTexto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colTexto.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colStatus);
                dataGrid.Columns.Add(colGrau);
                dataGrid.Columns.Add(colTexto);
                ///feito um refresh para fazer a atualização do datagridview
                dataGrid.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
