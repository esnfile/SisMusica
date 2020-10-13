using BLL.Funcoes;
using BLL.validacoes;
using BLL.validacoes.Controles;
using BLL.validacoes.Exceptions;
using ENT.Erros;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccbpess
{
    public partial class frmVincularCampos : Form
    {
        public frmVincularCampos(Form forms, List<MOD_vincularCampos> listaImportar, List<MOD_vincularCampos> listaVincular)
        {
            InitializeComponent();

            formChama = forms;
            listaDados = listaImportar;
            listaVinculado = listaVincular;

            carregaGridVincular();
        }

        #region Declarações

        List<MOD_vincularCampos> listaDados = null;
        List<MOD_vincularCampos> listaVinculado = null;
        string ValorTag;

        Form formChama;
        clsException excp;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        #endregion

        #region Eventos Formularios

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                salvar();
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        private void frmVincularCampos_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult sair;
                sair = MessageBox.Show(modulos.msgSalvar, "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (sair.Equals(DialogResult.Yes))
                {
                    btnSalvar_Click(sender, e);
                    btnSalvar.PerformClick();
                }
                else if (sair.Equals(DialogResult.Cancel))
                {
                    e.Cancel = true;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void frmVincularCampos_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
            ((frmImportarPessoa)formChama).defineAba();
        }
        private void gridVincular_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //habilitação das celulas após a entrada para edição
                if (gridVincular != null || gridVincular.Rows.Count > 0)
                {
                    if (gridVincular.Columns[e.ColumnIndex].Name.Equals("CampoVinculado"))
                    {
                        //define algumas propridades no grid para atualização
                        gridVincular.ReadOnly = false;
                        gridVincular.ModoOpera = DataGridViewPersonal.modoOpera.Edit;
                        gridVincular.Rows[gridVincular.CurrentRow.Index].Cells["CampoVinculado"].Selected = true;
                        gridVincular.Columns[e.ColumnIndex].ReadOnly = false;
                        gridVincular.BeginEdit(true);
                    }
                    else
                    {
                        gridVincular.Columns[e.ColumnIndex].ReadOnly = true;
                        gridVincular.ReadOnly = true;
                    }
                }
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void gridVincular_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //desabilitação das celulas após a saída da mesma
                if (gridVincular != null && gridVincular.Rows.Count > 0)
                {
                    if (gridVincular.ReadOnly.Equals(false))
                    {
                        if (gridVincular.Columns[e.ColumnIndex].Name.Equals("CampoImportado"))
                        {
                            gridVincular.Columns[e.ColumnIndex].ReadOnly = true;
                        }
                        else if (gridVincular.Columns[e.ColumnIndex].Name.Equals("CampoVinculado"))
                        {
                            gridVincular.Columns[e.ColumnIndex].ReadOnly = true;
                        }
                    }
                }
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void gridVincular_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //desabilitação das celulas após a saida
                if (gridVincular != null || gridVincular.Rows.Count > 0)
                {
                    if (gridVincular.ReadOnly.Equals(false))
                    {
                        gridVincular.EndEdit();
                    }
                }
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void gridVincular_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                gridVincular.Columns[e.ColumnIndex].ReadOnly = false;
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void gridVincular_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //DataGridView grid = (DataGridView)sender;
            //ComboBox combo = new ComboBox();
            //if (grid.CurrentCell.ColumnIndex == 1)
            //{
            //    combo = e.Control as ComboBox;
            //    combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            //}
        }

        #endregion

        #region Funções publicas e privadas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                listaVinculado = new List<MOD_vincularCampos>();

                foreach (DataGridViewRow linha in gridVincular.Rows)
                {
                    ///verifica a condição especificada para exibir a imagem
                    MOD_vincularCampos objEnt = new MOD_vincularCampos();

                    if (linha.Cells["CampoVinculado"].Value != null)
                    {
                        objEnt.CampoImportado = Convert.ToString(linha.Cells["CampoImportado"].Value);
                        objEnt.CampoVinculado = Convert.ToString(linha.Cells["CampoVinculado"].Value);

                        listaVinculado.Add(objEnt);
                    }
                }

                if (ValidarControles().Equals(true))
                {
                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmImportarPessoa"))
                    {
                        ((frmImportarPessoa)formChama).carregaDados(listaVinculado);
                    }

                    FormClosing -= new FormClosingEventHandler(frmVincularCampos_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmVincularCampos_FormClosing);
                }
            }
            catch (ArgumentException ae)
            {
                throw new Exception(ae.Message);
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que valida os campos
        /// </summary>
        private bool ValidarControles()
        {
            try
            {
                //inicia a variavel blnValida
                blnValida = true;
                bool blnRetorno = true;

                //inicia uma nova lista de erros
                listaErros = new List<MOD_erros>();

                List<MOD_vincularCampos> listaValida = new List<MOD_vincularCampos>();

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("DescCargo")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Cargo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("Nome")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Nome! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("DataNasc")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Data Nascimento! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("Cpf")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "C.P.F.! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("Sexo")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Sexo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("CepRes")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Cep! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("EndRes")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Endereço! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("NumRes")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Número! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("BairroRes")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Bairro! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("Telefone1") || c.CampoVinculado.Equals("Telefone2") ||
                                                    c.CampoVinculado.Equals("Celular1") || c.CampoVinculado.Equals("Celular2")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Necessário informar ao menos um Telefone ou Celular!";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                listaValida = listaVinculado.Where(c => c.CampoVinculado.Equals("DescCCB")).ToList();
                if (listaValida == null || listaValida.Count < 1)
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Comum Congregação! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                //chama o formulário para gerar os erros
                if (blnValida.Equals(false))
                {
                    blnRetorno = apoio.AbrirErros(listaErros, this);
                }
                return blnRetorno;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        ///<summary> Montar DataGrid Dados Importados
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta pessoas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridVincular()
        {
            gridVincular.AutoGenerateColumns = false;
            gridVincular.DataSource = null;
            gridVincular.Columns.Clear();
            gridVincular.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCampoImportado = new DataGridViewTextBoxColumn();
            colCampoImportado.DataPropertyName = "CampoImportado";
            colCampoImportado.HeaderText = "Campo Importado";
            colCampoImportado.Name = "CampoImportado";
            colCampoImportado.Width = 250;
            colCampoImportado.Frozen = false;
            colCampoImportado.MinimumWidth = 120;
            colCampoImportado.ReadOnly = true;
            colCampoImportado.FillWeight = 100;
            colCampoImportado.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCampoImportado.MaxInputLength = 100;
            colCampoImportado.Visible = true;
            ///2ª coluna
            DataGridViewComboBoxColumn colCampoVinculado = new DataGridViewComboBoxColumn();
            colCampoVinculado.Width = 250;
            colCampoVinculado.Frozen = false;
            colCampoVinculado.MinimumWidth = 120;
            colCampoVinculado.FillWeight = 100;
            colCampoVinculado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCampoVinculado.DataSource = listaVinculado;
            colCampoVinculado.DisplayMember = "CampoVinculado";
            colCampoVinculado.ValueMember = "CampoVinculado";
            colCampoVinculado.DataPropertyName = "CampoVinculado";
            colCampoVinculado.HeaderText = "Campo Vinculado";
            colCampoVinculado.Name = "CampoVinculado";
            colCampoVinculado.ReadOnly = false;
            colCampoVinculado.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            colCampoVinculado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCampoVinculado.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            gridVincular.Columns.Add(colCampoImportado);
            gridVincular.Columns.Add(colCampoVinculado);
            ///feito um refresh para fazer a atualização do datagridview
            gridVincular.Refresh();
        }
        /// <summary>
        /// Função que Carrega os Campos a serem vinculados
        /// </summary>
        internal void carregaGridVincular()
        {
            try
            {
                montaGridVincular();
                gridVincular.DataSource = listaDados;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que Seleciona o valor do Combo no DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValorTag = Convert.ToString(((ComboBox)sender).SelectedValue);
            if (ValorTag != null && ValorTag != string.Empty)
            {
                gridVincular.Rows[gridVincular.CurrentRow.Index].Cells["CampoVinculado"].Tag = ValorTag;
            }
        }

        #endregion

    }
}
