using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BLL.validacoes.Formularios
{
    public partial class carregRelatorio : Form
    {
        private PictureBox pctRelatorio;
        private ImageList imgRelatorio;
        private IContainer components;
        private Label lblmsg;
        int i;


        public carregRelatorio()
        {
            InitializeComponent();
        }
        public carregRelatorio(string msgLabel)
        {
            InitializeComponent();
            lblmsg.Text = msgLabel;
            lblmsg.Refresh();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(carregRelatorio));
            this.lblmsg = new System.Windows.Forms.Label();
            this.imgRelatorio = new System.Windows.Forms.ImageList(this.components);
            this.pctRelatorio = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pctRelatorio)).BeginInit();
            this.SuspendLayout();
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(24, 33);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(113, 13);
            this.lblmsg.TabIndex = 1;
            this.lblmsg.Text = "Buscando registros ...";
            this.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imgRelatorio
            // 
            this.imgRelatorio.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgRelatorio.ImageStream")));
            this.imgRelatorio.TransparentColor = System.Drawing.Color.White;
            this.imgRelatorio.Images.SetKeyName(0, "relatorio1.Jpg");
            this.imgRelatorio.Images.SetKeyName(1, "relatorio2.Jpg");
            this.imgRelatorio.Images.SetKeyName(2, "relatorio3.Jpg");
            this.imgRelatorio.Images.SetKeyName(3, "relatorio4.Jpg");
            this.imgRelatorio.Images.SetKeyName(4, "relatorio5.Jpg");
            this.imgRelatorio.Images.SetKeyName(5, "relatorio6.Jpg");
            this.imgRelatorio.Images.SetKeyName(6, "relatorio7.Jpg");
            // 
            // pctRelatorio
            // 
            this.pctRelatorio.Location = new System.Drawing.Point(148, 15);
            this.pctRelatorio.Name = "pctRelatorio";
            this.pctRelatorio.Size = new System.Drawing.Size(47, 47);
            this.pctRelatorio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctRelatorio.TabIndex = 2;
            this.pctRelatorio.TabStop = false;
            // 
            // carregRelatorio
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(232, 83);
            this.ControlBox = false;
            this.Controls.Add(this.pctRelatorio);
            this.Controls.Add(this.lblmsg);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "carregRelatorio";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aguarde...";
            this.Activated += new System.EventHandler(this.carregRelatorio_Activated);
            this.Load += new System.EventHandler(this.carregRelatorio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctRelatorio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void carregRelatorio_Load(object sender, EventArgs e)
        {
            try
            {
                Thread trd = new Thread(new ThreadStart(this.carregaImagem));
                trd.IsBackground = true;
                trd.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void carregaImagem()
        {
            try
            {

                //Formatação para Barra de Progress
                //int stp;
                //int novoValor;
                //Random rnd = new Random();

                //while (true)
                //{
                //    stp = this.progressBar1.Step * rnd.Next(-1, 2);
                //    novoValor = this.progressBar1.Value + stp;

                //    if (novoValor > this.progressBar1.Maximum)
                //        novoValor = this.progressBar1.Maximum;
                //    else if (novoValor < this.progressBar1.Minimum)
                //        novoValor = this.progressBar1.Minimum;

                //    this.progressBar1.Value = novoValor;

                //    Thread.Sleep(100);
                //}

                while (true)
                {
                    int MaxImage = 6;
                    int MinImage = 0;

                    for (int i = MinImage; i < MaxImage; i++)
                    {
                        ////Carrego as imagens
                        //pctRelatorio.Image = imgRelatorio.Images[i];

                        SetControlPropertyValue(pctRelatorio, "Image", imgRelatorio.Images[i]);

                        i = i + 1;

                        //Pausa 100 milisegundos
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //private void image()
        //{
        //    int MaxImage = 6;
        //    int MinImage = 0;

        //    for (int i = MinImage; i < MaxImage; i++)
        //    {
        //        //Carrego as imagens
        //        pctRelatorio.Image = imgRelatorio.Images[i];
        //        //Pausa 100 milisegundos
        //        Thread.Sleep(TimeSpan.FromMilliseconds(100));
        //    }
        //}

        private void carregRelatorio_Activated(object sender, EventArgs e)
        {
        }


        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        private void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            try
            {
                if (oControl.InvokeRequired)
                {
                    SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                    oControl.Invoke(d, new object[] { oControl, propName, propValue });
                }
                else
                {
                    Type t = oControl.GetType();
                    PropertyInfo[] props = t.GetProperties();
                    foreach (PropertyInfo p in props)
                    {
                        if (p.Name.ToUpper() == propName.ToUpper())
                        {
                            p.SetValue(oControl, propValue, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
