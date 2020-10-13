using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

using BLL.validacoes.Exceptions;
using BLL.Funcoes;

namespace BLL.validacoes.Controles
{
    [ToolboxBitmap(typeof(System.Windows.Forms.TextBox))]
    public partial class TextBoxPersonal : TextBox
    {
        public TextBoxPersonal()
        {
            InitializeComponent();
            //define que o textbox será com a borda fixa
            this.BorderStyle = BorderStyle.FixedSingle;

            //define a cor inicial do textbox
            this.BackColor = Color.White;
        }

        clsException excp;

        // enumerador que vai definir as propriedades
        public enum TipoValida
        {
            Nenhum,
            Cep,
            Cnpj,
            Cpf,
            Data,
            Double,
            Hora,
            Inteiro,
            Placa,
            Telefone,
            Celular,
            Pesquisa
        }

        //propriedade tipo que vai criar no textbox
        private TipoValida Tipos;
        public TipoValida Validacao
        {
            get
            {
                return Tipos;
            }
            set
            {
                Tipos = value;
            }
        }

        //evento ao digitar um tecla. só aceita teclas referentes ao tipo de dados int ##suprime outros tipo de teclas.        
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (Tipos == TipoValida.Inteiro)
            {
                //se for sinal negativo, então deve ser o primeiro caracter
                if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                {
                    if (this.Text.Length > 0)
                    {
                        e.SuppressKeyPress = true;
                    }
                    else
                    {
                        e.SuppressKeyPress = false;
                    }
                }

                //verifica se o caracter está no conjunto de caracteres permitido
                else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2
                        || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.NumPad5
                        || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad7
                        || e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D0
                        || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4
                        || e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8
                        || e.KeyCode == Keys.D9 || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return
                        || e.KeyCode == Keys.Back || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right
                        || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.End || e.KeyCode == Keys.Home
                        || e.KeyCode == Keys.PageDown || e.KeyCode == Keys.PageUp)
                {
                    //caracter está no conjunto. não suprime o caracter
                    e.SuppressKeyPress = false;
                }
                else
                {
                    //caracter esta fora do conjunto. suprime
                    e.SuppressKeyPress = true;
                }
            }
            else if (Tipos == TipoValida.Double)
            {
                //se for o sinal de negativo então deve ser o primeiro caracter
                if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
                {
                    if (this.Text.Length > 0)
                        e.SuppressKeyPress = true;
                    else
                        e.SuppressKeyPress = false;
                }

                //se for virgula ou ponto, deve-se existir apenas 1,
                //se for o primeiro caracter, o sistema joga um 0 a esquerda,
                //Se existir uma virgula logo depois do sinal negativo, o sistema joga um 0 a esquerda
                else if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
                {
                    if (this.Text.Length < 1)
                    {
                        this.Text = "";
                        this.Text = "0,";
                        e.SuppressKeyPress = true;
                        this.SelectionStart = this.Text.Length;
                    }
                    else
                    {
                        if (this.Text.Length == 1 && this.Text.Substring(0, 1) == "-")
                        {
                            this.Text = "";
                            this.Text = "-0,";
                            e.SuppressKeyPress = true;
                            this.SelectionStart = this.Text.Length;
                        }
                        else
                        {
                            int cont = 0;
                            int qtd = 0;

                            while (cont < this.Text.Length)
                            {
                                if (this.Text.Substring(cont, 1) == "," || this.Text.Substring(cont, 1) == ".")
                                {
                                    qtd++;
                                    break;
                                }
                                cont++;
                            }
                            if (qtd > 0)
                                e.SuppressKeyPress = true;
                            else
                                e.SuppressKeyPress = false;
                        }
                    }
                }
                //verifica se o caracter está no conjunto de caracteres permitido para o double
                else if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 || e.KeyCode == Keys.NumPad2
                        || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 || e.KeyCode == Keys.NumPad5
                        || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 || e.KeyCode == Keys.NumPad8
                        || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1
                        || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5
                        || e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 || e.KeyCode == Keys.D9
                        || e.KeyCode == Keys.Delete || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return || e.KeyCode == Keys.Back
                        || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right || e.KeyCode == Keys.Up
                        || e.KeyCode == Keys.Down || e.KeyCode == Keys.End || e.KeyCode == Keys.Home || e.KeyCode == Keys.PageDown
                        || e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.Decimal || e.KeyCode == Keys.OemPeriod)
                {
                    //caracter está no conjunto. não suprime o caracter
                    e.SuppressKeyPress = false;
                }
                else
                {
                    //caracter está fora do conjunto. suprime
                    e.SuppressKeyPress = true;
                }
            }
            else if (Tipos == TipoValida.Pesquisa)
            {
                if (e.KeyCode == Keys.Space)
                {
                    //caracter está fora do conjunto. suprime
                    e.SuppressKeyPress = true;
                    this.Text += "%";
                    this.SelectionStart = this.Text.Length;
                }
            }
            else
            {
                e.Handled = false;
            }
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (Tipos == TipoValida.Double)
            {
                if (e.KeyChar == '.')
                    e.KeyChar = ',';
            }
            //else if (Tipos == TipoValida.Pesquisa)
            //{
            //    if (e.KeyChar == (char)Keys.Space)
            //    {
            //        //caracter está fora do conjunto. suprime
            //        e.SuppressKeyPress = true;
            //        this.Text += "%";
            //        this.SelectionStart = this.Text.Length;
            //    }
            //}
            else
            {
                e.Handled = false;
            }
        }
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
            if (Tipos == TipoValida.Pesquisa)
            {
                this.SelectAll();
                this.Focus();
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
        }

        //padroniza a cor do fundo ao receber o foco
        protected override void OnEnter(EventArgs e)
        {
            this.BackColor = Color.LightYellow;
            base.OnEnter(e);
        }
        //volta a cor original do fundo ao perder o foco
        protected override void OnLeave(EventArgs e)
        {
            this.BackColor = Color.White;
            base.OnLeave(e);
        }
        protected override void OnValidating(CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Text.Trim()))
                {
                    if (Tipos.Equals(TipoValida.Data))
                    {
                        string msg;
                        string data = this.Text.Trim();

                        msg = funcoes.FormataData(data);

                        this.Text = msg;
                    }
                    else if (Tipos.Equals(TipoValida.Hora))
                    {
                        string msg;
                        string hora = this.Text.Trim();

                        msg = funcoes.FormataHora(hora);

                        this.Text = msg;
                    }
                    else if (Tipos.Equals(TipoValida.Cpf))
                    {
                        string msg;
                        string cpf = this.Text.Trim();

                        msg = funcoes.FormataCpf(cpf);

                        this.Text = msg;
                    }
                    else if (Tipos.Equals(TipoValida.Telefone))
                    {
                        string msg;
                        string tel = this.Text.Trim();
                        tel = tel.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(",", "");

                        //Verifica se o telefone não é nulo ou possui menos que 8 caracteres
                        if (string.IsNullOrEmpty(tel.Trim()) || tel.Length < 10)
                        {
                            Focus();
                            SelectAll();
                            e.Cancel = true;
                        }
                        else
                        {
                            msg = funcoes.FormataString("(##) ####-####", tel);
                            Text = msg;
                        }
                    }
                    else if (Tipos.Equals(TipoValida.Celular))
                    {
                        string msg;
                        string cel = Text.Trim();
                        cel = cel.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(",", "");

                        //Verifica se o telefone não é nulo ou possui menos que 8 caracteres
                        if (string.IsNullOrEmpty(cel.Trim()) || cel.Length < 11)
                        {
                            Focus();
                            SelectAll();
                            e.Cancel = true;
                        }
                        else
                        {
                            msg = funcoes.FormataString("(##) #####-####", cel);
                            Text = msg;
                        }
                    }
                    else if (Tipos.Equals(TipoValida.Placa))
                    {
                        string msg;
                        string placa = this.Text.Trim();
                        //Verifica se a placa está com divergencia em caracteres
                        if (!placa.Length.Equals(7) && !placa.Length.Equals(8) && !placa.Length.Equals(0))
                        {
                            this.Focus();
                            this.SelectAll();
                            e.Cancel = true;
                        }
                        else
                        {
                            msg = funcoes.FormataString("###-####", placa);

                            this.Text = msg;
                        }
                    }
                }
                base.OnValidating(e);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
                e.Cancel = true;
            }
        }
        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            if (Tipos.Equals(TipoValida.Cep))
            {
                string msg;
                string cep = this.Text.Trim();

                //Verifica se o cep informado está com divergencia de caracteres
                if (cep.Length != 8 && cep.Length != 9 && cep.Length != 0)
                {
                    Focus();
                    SelectAll();
                    return;
                }
                else
                {
                    msg = funcoes.FormataString("#####-###", cep);
                    this.Text = msg;
                }
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