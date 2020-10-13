using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace BLL.validacoes.Controles
{
    public partial class tabControlPersonal : TabControl
    {
        public tabControlPersonal()
        {
            InitializeComponent();

            //altera o mode de exibição do TabControl
            //this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.DrawMode = TabDrawMode.Normal;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            try
            {
                ////Chama procedure passando "evento desenho" e tabControl
                //TabControlColor(e, this);




                TabPage page = this.TabPages[e.Index];
                //e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);
                Rectangle paddedBounds = e.Bounds;
                int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
                paddedBounds.Offset(1, yOffset);
                //TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);

                if (!page.Enabled)
                {
                    using (SolidBrush brush = new SolidBrush(Color.Gray))
                    {
                        //e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds);
                        TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor = Color.Gray);
                    }
                }
                else
                {
                    using (SolidBrush brush = new SolidBrush(page.ForeColor))
                    {
                        //e.Graphics.DrawString(page.Text, page.Font, brush, e.Bounds);
                        TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor = Color.Black);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            //foreach (TabPage tp in this.TabPages)
            //{
                
            //}
        }

        protected override void OnSelecting(TabControlCancelEventArgs e)
        {
            base.OnSelecting(e);
            if (!e.TabPage.Enabled)
            {
                e.Cancel = true;
            }
        }

        //ROTINA PARA COLORIR ABAS DE TabOrder
        public static void TabControlColor(DrawItemEventArgs e, TabControl tc)
        {
            Font f; //Fonte
            Brush bgTab; //Cor BackGround
            Brush fcTab; //Cor ForeColor

            if (e.Index == tc.SelectedIndex) //Depois da seleção
            {
                //Mudar aparência do TabControl
                //f = new Font(e.Font, FontStyle.Regular | FontStyle.Regular);
                f = new Font(e.Font, FontStyle.Regular);
                bgTab = new SolidBrush(Color.DarkGray);
                fcTab = new SolidBrush(Color.White);
            }
            else
            {
                f = e.Font;
                bgTab = new SolidBrush(e.BackColor);
                fcTab = new SolidBrush(e.ForeColor);
            }
            //Alinhamento do texto
            string tabName = tc.TabPages[e.Index].Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;

            //Preencher tab selecionada
            e.Graphics.FillRectangle(bgTab, e.Bounds);
            Rectangle r = e.Bounds;
            r = new Rectangle(r.X, r.Y + 3, r.Width, r.Height - 3);
            e.Graphics.DrawString(tabName, f, fcTab, r, sf);

            sf.Dispose(); //Saída
            if (e.Index == tc.SelectedIndex)
            {
                f.Dispose();
                bgTab.Dispose();
            }
            else
            {
                bgTab.Dispose();
                fcTab.Dispose();
            }
        }
    }
}