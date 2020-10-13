using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLL.validacoes.Controles
{
    public partial class NumericUpDownPersonal : NumericUpDown
    {
        public NumericUpDownPersonal()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.BackColor = Color.LightYellow;
            this.Select(0, this.Text.Length);
        }
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.BackColor = Color.White;
            if (this.Text == null || this.Text.Equals(string.Empty))
            {
                this.Value = this.Minimum;
                this.Text = this.Value.ToString();
            }
        }
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (Enabled.Equals(true))
            {
                //define a cor inicial do textbox
                BackColor = Color.White;
            }
            else
            {
                //define a cor inicial do textbox
                BackColor = Color.LightGray;
            }

        }
    }
}