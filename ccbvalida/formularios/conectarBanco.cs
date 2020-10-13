using BLL.Funcoes;
using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLL.validacoes.Formularios
{
    public partial class conectarBanco : Form
    {
        private Timer tmrConecta;
        private IContainer components;
        private ImageList imgConecta;
        private PictureBox pctConecta;
        private Label lblmsg;

        public conectarBanco()
        {
            InitializeComponent();
            //modulos.CaminhoBD = @"Data Source=EDUARDO\SQLEXPRESS;Initial Catalog=CCB_Musica_Server;Integrated Security=True";

            ///Conexão Servidor Base Teste
            //modulos.CaminhoBD = @"Data Source=SERVMUNDO\CCBSQLEXPRESS;Initial Catalog=CCB_Musica_Teste;User Id=SA; Password=@mf170408";

            // Conexao Servidor
            modulos.CaminhoBD = @"Data Source=SERVMUNDO\CCBSQLEXPRESS;Initial Catalog=CCB_Musica;User Id=SA; Password=@mf170408";

            /////Local
            //modulos.CaminhoBD = @"Data Source=EDUARDO\SQLEXPRESS;Initial Catalog=CCB_Musica;Integrated Security=True";

            modulos.preencheStrConexao();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(conectarBanco));
            this.tmrConecta = new System.Windows.Forms.Timer(this.components);
            this.imgConecta = new System.Windows.Forms.ImageList(this.components);
            this.pctConecta = new System.Windows.Forms.PictureBox();
            this.lblmsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctConecta)).BeginInit();
            this.SuspendLayout();
            // 
            // tmrConecta
            // 
            this.tmrConecta.Interval = 20;
            // 
            // imgConecta
            // 
            this.imgConecta.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgConecta.ImageStream")));
            this.imgConecta.TransparentColor = System.Drawing.Color.Transparent;
            this.imgConecta.Images.SetKeyName(0, "Aguarde1.ico");
            this.imgConecta.Images.SetKeyName(1, "Aguarde2.ico");
            this.imgConecta.Images.SetKeyName(2, "Aguarde3.ico");
            this.imgConecta.Images.SetKeyName(3, "Aguarde4.ico");
            this.imgConecta.Images.SetKeyName(4, "Aguarde5.ico");
            this.imgConecta.Images.SetKeyName(5, "Aguarde6.ico");
            this.imgConecta.Images.SetKeyName(6, "Aguarde7.ico");
            this.imgConecta.Images.SetKeyName(7, "Aguarde8.ico");
            // 
            // pctConecta
            // 
            this.pctConecta.Image = global::ccbvalida.Properties.Resources.comtest;
            this.pctConecta.Location = new System.Drawing.Point(12, 13);
            this.pctConecta.Name = "pctConecta";
            this.pctConecta.Size = new System.Drawing.Size(371, 56);
            this.pctConecta.TabIndex = 3;
            this.pctConecta.TabStop = false;
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(110, 83);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(169, 13);
            this.lblmsg.TabIndex = 2;
            this.lblmsg.Text = "Conectando na Base de Dados ...";
            // 
            // conectarBanco
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(392, 120);
            this.ControlBox = false;
            this.Controls.Add(this.pctConecta);
            this.Controls.Add(this.lblmsg);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "conectarBanco";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aguarde...";
            this.Load += new System.EventHandler(this.conectarBanco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctConecta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void conectarBanco_Load(object sender, EventArgs e)
        {
            //tmrConecta.Interval = 10;
            //tmrConecta.Start();
        }
        public bool conectar()
        {
            try
            {
                acessa conecta = new acessa();

                if (!conecta.conectar().Equals(true))
                {
                    Close();
                    Dispose();
                    return false;
                    throw new Exception("Não foi possível conectar a Base de Dados." + "\n" +
                                        "Por favor, contate o suporte técnico.");
                }
                else
                {
                    conecta.desconectar();
                    Close();
                    Dispose();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void tmrConecta_Tick(object sender, EventArgs e)
        {

            //pctConecta.Update();

            //pctConecta.Image = imgConecta.Images[Indice];

            //if (Indice < imgConecta.Images.Count - 1)
            //{
            //    Indice += 1;
            //}
            //else
            //{
            //    Indice = 0;
            //}
        }
    }
}
