using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ENT.pessoa;
using BLL.Funcoes;
using System.Data.SqlClient;
using BLL.validacoes;
using BLL.validacoes.Exceptions;
using BLL.pessoa;
using BLL.uteis;
using ENT.uteis;
using BLL.instrumentos;
using ENT.instrumentos;
using BLL.validacoes.Controles;
using ENT.Erros;
using BLL.validacoes.Formularios;
using ENT.acessos;
using ENT.importa;
using BLL.importa;
using BLL.Usuario;

namespace ccbimp
{
    public partial class frmImportarPessoaErros : Form
    {
        public frmImportarPessoaErros(List<MOD_acessos> listaLibAcesso)
        {
            InitializeComponent();

            try
            {
                //carregando a lista de permissões de acesso.
                listaAcesso = listaLibAcesso;

                #region Carregar ComboBox

                apoio.carregaComboRegional(cboRegional);
                apoio.carregaComboRegiao(cboRegiao, Convert.ToString(cboRegional.SelectedValue));

                #endregion
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }

        #region declarações

        //Código da Pessoa a Editar
        string CodImportaErro;
        string CodImporta;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        BLL_importaPessoa objBLL_Importa = null;
        MOD_importaPessoa objEnt = null;
        //List<MOD_importaPessoa> listaImporta = null;
        List<MOD_importaPessoaItemErro> listaImportaItemErro = null;

        BLL_ccb objBLL_CCB = null;
        List<MOD_ccb> listaCCB = null;

        BLL_usuario objBLL_CCBUsuario = null;
        BindingList<MOD_usuarioCCB> listaCCBUsuario = null;

        internal MOD_importaPessoaItemErro objEnt_ItemErro;

        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        BindingSource objBind_Pessoa = null;
        BindingSource objBind_ImpSucesso = null;
        BindingSource objBind_ImpErro = null;

        clsException excp;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        List<MOD_acessos> listaAcesso = null;

        #endregion

        #region Eventos Formulario

        private void frmImportarPessoaErros_Load(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Carregando registros pendentes...");
                //carrega os dados da lista
                preencherErro(preencheCCBImporta(modulos.CodUsuario));

                verPermErro(gridErro);
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void frmImportarPessoaErros_Activated(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde("Marcando registros com erro...");
                definirErro(gridErro);
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void frmImportarPessoaErros_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void frmImportarPessoaErros_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult sair;
                sair = MessageBox.Show("Deseja realmente sair?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sair.Equals(DialogResult.No))
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
        private void btnFechar_Click(object sender, EventArgs e)
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
        private void cboRegional_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();

                cboRegiao.DataSource = null;
                cboCCB.DataSource = null;

                apoio.carregaComboRegiao(cboRegiao, Convert.ToString(cboRegional.SelectedValue));
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void cboRegiao_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                if (!string.IsNullOrEmpty(Convert.ToString(cboRegiao.SelectedValue)))
                {
                    apoio.carregaComboCCBUsuario(cboCCB, Convert.ToString(cboRegiao.SelectedValue));
                    preencherErro(preencheCCBImporta(modulos.CodUsuario, Convert.ToString(cboRegiao.SelectedValue)));
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
            finally
            {
                apoio.FecharAguarde();
            }
        }
        private void cboCCB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Convert.ToString(cboCCB.SelectedValue)))
                {
                    apoio.Aguarde();
                    preencherErro(Convert.ToInt32(cboCCB.SelectedValue).ToString());
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
            finally
            {
                apoio.FecharAguarde();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                CodImportaErro = Convert.ToString(gridErro["CodImportaPessoaItem", gridErro.CurrentRow.Index].Value);
                CodImporta = Convert.ToString(gridErro["CodImportaPessoa", gridErro.CurrentRow.Index].Value);
                abrirForm("frmPessoaErro", 0);
                ((frmPessoaErros)formulario).Text = "Editando Cadastro Previamente Importado";
                ((frmPessoaErros)formulario).enabledForm();
            }
            catch (SqlException exl)
            {
                excp = new clsException(exl);
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
            finally
            {
                apoio.FecharAguarde();
            }
        }

        #region Eventos Manipulação do GridDados

        private void gridErro_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEditar.Enabled.Equals(true))
            {
                try
                {
                    apoio.Aguarde();
                    CodImportaErro = gridErro["CodImportaPessoaItem", gridErro.CurrentRow.Index].Value.ToString();
                    abrirForm("frmPessoaErro", 0);
                    ((frmPessoaErros)formulario).Text = "Editando Cadastro Previamente Importado";
                    ((frmPessoaErros)formulario).enabledForm();
                }
                catch (SqlException exl)
                {
                    excp = new clsException(exl);
                }
                catch (Exception ex)
                {
                    excp = new clsException(ex);
                }
                finally
                {
                    apoio.FecharAguarde();
                }
            }
        }
        private void gridErro_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
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
        private void gridErro_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CodImportaErro = gridErro["CodImportaPessoaItem", gridErro.CurrentRow.Index].Value.ToString();
                CodImporta = gridErro["CodImportaPessoa", gridErro.CurrentRow.Index].Value.ToString();
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
        private void gridErro_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (gridErro.RowCount > 0)
            {
                btnEditar.Enabled = true;
                definirErro(gridErro);
            }
            else
            {
                btnEditar.Enabled = false;
            }
        }

        #endregion

        #endregion

        #region Funções Publicas e Privadas

        ///<summary> Montar DataGrid Dados Importados com Sucesso
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta pessoas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridDadosErro()
        {
            gridErro.AutoGenerateColumns = false;
            gridErro.DataSource = null;
            gridErro.Columns.Clear();
            gridErro.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///1ª coluna
            DataGridViewTextBoxColumn colCodItem = new DataGridViewTextBoxColumn();
            colCodItem.DataPropertyName = "CodImportaPessoaItem";
            colCodItem.Name = "CodImportaPessoaItem";
            colCodItem.HeaderText = "Código";
            colCodItem.Width = 80;
            colCodItem.Frozen = false;
            colCodItem.MinimumWidth = 80;
            colCodItem.ReadOnly = true;
            colCodItem.FillWeight = 100;
            colCodItem.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodItem.MaxInputLength = 200;
            colCodItem.Visible = false;
            ///1ª coluna
            DataGridViewTextBoxColumn colDataCadastro = new DataGridViewTextBoxColumn();
            colDataCadastro.DataPropertyName = "DataCadastro";
            colDataCadastro.Name = "DataCadastro";
            colDataCadastro.HeaderText = "Data Cadastro";
            colDataCadastro.Width = 80;
            colDataCadastro.Frozen = false;
            colDataCadastro.DefaultCellStyle.Format = "dd/mm/yyyy";
            colDataCadastro.MinimumWidth = 80;
            colDataCadastro.ReadOnly = true;
            colDataCadastro.FillWeight = 100;
            colDataCadastro.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDataCadastro.MaxInputLength = 200;
            colDataCadastro.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colHoraCadastro = new DataGridViewTextBoxColumn();
            colHoraCadastro.DataPropertyName = "HoraCadastro";
            colHoraCadastro.Name = "HoraCadastro";
            colHoraCadastro.HeaderText = "Hora";
            colHoraCadastro.Width = 60;
            colHoraCadastro.Frozen = false;
            colHoraCadastro.DefaultCellStyle.Format = "HH:mm";
            colHoraCadastro.MinimumWidth = 60;
            colHoraCadastro.ReadOnly = true;
            colHoraCadastro.FillWeight = 100;
            colHoraCadastro.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHoraCadastro.MaxInputLength = 200;
            colHoraCadastro.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colCodCargo = new DataGridViewTextBoxColumn();
            colCodCargo.Name = "CodCargo";
            colCodCargo.HeaderText = "CodCargo";
            colCodCargo.DataPropertyName = "CodCargo";
            colCodCargo.Width = 50;
            colCodCargo.Frozen = false;
            colCodCargo.MinimumWidth = 50;
            colCodCargo.ReadOnly = true;
            colCodCargo.FillWeight = 100;
            colCodCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodCargo.MaxInputLength = 100;
            colCodCargo.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDescCargo = new DataGridViewTextBoxColumn();
            colDescCargo.Name = "DescCargo";
            colDescCargo.HeaderText = "Cargo";
            colDescCargo.DataPropertyName = "DescCargo";
            colDescCargo.Width = 80;
            colDescCargo.Frozen = false;
            colDescCargo.MinimumWidth = 80;
            colDescCargo.ReadOnly = true;
            colDescCargo.FillWeight = 100;
            colDescCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDescCargo.MaxInputLength = 200;
            colDescCargo.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.Name = "Nome";
            colNome.HeaderText = "Nome";
            colNome.DataPropertyName = "Nome";
            colNome.Width = 120;
            colNome.Frozen = false;
            colNome.MinimumWidth = 120;
            colNome.ReadOnly = true;
            colNome.FillWeight = 100;
            colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNome.MaxInputLength = 200;
            colNome.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDataNasc = new DataGridViewTextBoxColumn();
            colDataNasc.Name = "DataNasc";
            colDataNasc.HeaderText = "Nascimento";
            colDataNasc.DataPropertyName = "DataNasc";
            colDataNasc.Width = 80;
            colDataNasc.Frozen = false;
            colDataNasc.DefaultCellStyle.Format = "dd/mm/yyyy";
            colDataNasc.MinimumWidth = 80;
            colDataNasc.ReadOnly = true;
            colDataNasc.FillWeight = 100;
            colDataNasc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDataNasc.MaxInputLength = 200;
            colDataNasc.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colCpf = new DataGridViewTextBoxColumn();
            colCpf.Name = "Cpf";
            colCpf.HeaderText = "C.P.F.";
            colCpf.DataPropertyName = "Cpf";
            colCpf.Width = 100;
            colCpf.Frozen = false;
            colCpf.MinimumWidth = 80;
            colCpf.ReadOnly = true;
            colCpf.FillWeight = 100;
            colCpf.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCpf.MaxInputLength = 30;
            colCpf.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colRg = new DataGridViewTextBoxColumn();
            colRg.Name = "Rg";
            colRg.HeaderText = "R.G.";
            colRg.DataPropertyName = "Rg";
            colRg.Width = 80;
            colRg.Frozen = false;
            colRg.MinimumWidth = 80;
            colRg.ReadOnly = true;
            colRg.FillWeight = 100;
            colRg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colRg.MaxInputLength = 30;
            colRg.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colEmis = new DataGridViewTextBoxColumn();
            colEmis.Name = "OrgaoEmissor";
            colEmis.HeaderText = "Org. Emissor";
            colEmis.DataPropertyName = "OrgaoEmissor";
            colEmis.Width = 80;
            colEmis.Frozen = false;
            colEmis.MinimumWidth = 80;
            colEmis.ReadOnly = true;
            colEmis.FillWeight = 100;
            colEmis.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEmis.MaxInputLength = 30;
            colEmis.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colSexo = new DataGridViewTextBoxColumn();
            colSexo.Name = "Sexo";
            colSexo.HeaderText = "Sexo";
            colSexo.DataPropertyName = "Sexo";
            colSexo.Width = 60;
            colSexo.Frozen = false;
            colSexo.MinimumWidth = 60;
            colSexo.ReadOnly = true;
            colSexo.FillWeight = 100;
            colSexo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSexo.MaxInputLength = 30;
            colSexo.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDataBatismo = new DataGridViewTextBoxColumn();
            colDataBatismo.Name = "DataBatismo";
            colDataBatismo.HeaderText = "Data Batismo";
            colDataBatismo.DataPropertyName = "DataBatismo";
            colDataBatismo.Width = 80;
            colDataBatismo.Frozen = false;
            colDataBatismo.DefaultCellStyle.Format = "dd/mm/yyyy";
            colDataBatismo.MinimumWidth = 80;
            colDataBatismo.ReadOnly = true;
            colDataBatismo.FillWeight = 100;
            colDataBatismo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDataBatismo.MaxInputLength = 200;
            colDataBatismo.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colCep = new DataGridViewTextBoxColumn();
            colCep.Name = "CepRes";
            colCep.HeaderText = "Cep Residência";
            colCep.DataPropertyName = "CepRes";
            colCep.Width = 80;
            colCep.Frozen = false;
            colCep.MinimumWidth = 80;
            colCep.ReadOnly = true;
            colCep.FillWeight = 100;
            colCep.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCep.MaxInputLength = 100;
            colCep.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colCodCidadeRes = new DataGridViewTextBoxColumn();
            colCodCidadeRes.Name = "CodCidadeRes";
            colCodCidadeRes.HeaderText = "CodCidadeRes";
            colCodCidadeRes.DataPropertyName = "CodCidadeRes";
            colCodCidadeRes.Width = 50;
            colCodCidadeRes.Frozen = false;
            colCodCidadeRes.MinimumWidth = 50;
            colCodCidadeRes.ReadOnly = true;
            colCodCidadeRes.FillWeight = 100;
            colCodCidadeRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodCidadeRes.MaxInputLength = 100;
            colCodCidadeRes.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colEstRes = new DataGridViewTextBoxColumn();
            colEstRes.Name = "EstadoRes";
            colEstRes.HeaderText = "Estaso Residência";
            colEstRes.DataPropertyName = "EstadoRes";
            colEstRes.Width = 100;
            colEstRes.Frozen = false;
            colEstRes.MinimumWidth = 80;
            colEstRes.ReadOnly = true;
            colEstRes.FillWeight = 100;
            colEstRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEstRes.MaxInputLength = 100;
            colEstRes.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colCid = new DataGridViewTextBoxColumn();
            colCid.Name = "CidadeRes";
            colCid.HeaderText = "Cidade Residência";
            colCid.DataPropertyName = "CidadeRes";
            colCid.Width = 100;
            colCid.Frozen = false;
            colCid.MinimumWidth = 80;
            colCid.ReadOnly = true;
            colCid.FillWeight = 100;
            colCid.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCid.MaxInputLength = 100;
            colCid.Visible = true;
            ///7ª coluna
            DataGridViewTextBoxColumn colEndRes = new DataGridViewTextBoxColumn();
            colEndRes.Name = "EndRes";
            colEndRes.HeaderText = "End. Residência";
            colEndRes.DataPropertyName = "EndRes";
            colEndRes.Width = 100;
            colEndRes.Frozen = false;
            colEndRes.MinimumWidth = 100;
            colEndRes.ReadOnly = true;
            colEndRes.FillWeight = 100;
            colEndRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEndRes.MaxInputLength = 200;
            colEndRes.Visible = true;
            ///8ª coluna
            DataGridViewTextBoxColumn colNumRes = new DataGridViewTextBoxColumn();
            colNumRes.Name = "NumRes";
            colNumRes.HeaderText = "Nº Residência";
            colNumRes.DataPropertyName = "NumRes";
            colNumRes.Width = 50;
            colNumRes.Frozen = false;
            colNumRes.MinimumWidth = 40;
            colNumRes.ReadOnly = true;
            colNumRes.FillWeight = 100;
            colNumRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNumRes.MaxInputLength = 20;
            colNumRes.Visible = true;
            ///8ª coluna
            DataGridViewTextBoxColumn colBairroRes = new DataGridViewTextBoxColumn();
            colBairroRes.Name = "BairroRes";
            colBairroRes.HeaderText = "Bairro Residência";
            colBairroRes.DataPropertyName = "BairroRes";
            colBairroRes.Width = 80;
            colBairroRes.Frozen = false;
            colBairroRes.MinimumWidth = 80;
            colBairroRes.ReadOnly = true;
            colBairroRes.FillWeight = 100;
            colBairroRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colBairroRes.MaxInputLength = 100;
            colBairroRes.Visible = true;
            ///8ª coluna
            DataGridViewTextBoxColumn colComplRes = new DataGridViewTextBoxColumn();
            colComplRes.Name = "ComplRes";
            colComplRes.HeaderText = "Complemento Residência";
            colComplRes.DataPropertyName = "ComplRes";
            colComplRes.Width = 100;
            colComplRes.Frozen = false;
            colComplRes.MinimumWidth = 100;
            colComplRes.ReadOnly = true;
            colComplRes.FillWeight = 100;
            colComplRes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colComplRes.MaxInputLength = 200;
            colComplRes.Visible = true;
            ///9ª Coluna
            DataGridViewTextBoxColumn colTel1 = new DataGridViewTextBoxColumn();
            colTel1.Name = "Telefone1";
            colTel1.HeaderText = "Telefone 1";
            colTel1.DataPropertyName = "Telefone1";
            colTel1.Width = 80;
            colTel1.Frozen = false;
            colTel1.MinimumWidth = 80;
            colTel1.ReadOnly = true;
            colTel1.FillWeight = 100;
            colTel1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTel1.MaxInputLength = 30;
            colTel1.Visible = true;
            ///9ª Coluna
            DataGridViewTextBoxColumn colTel2 = new DataGridViewTextBoxColumn();
            colTel2.Name = "Telefone2";
            colTel2.HeaderText = "Telefone 2";
            colTel2.DataPropertyName = "Telefone2";
            colTel2.Width = 80;
            colTel2.Frozen = false;
            colTel2.MinimumWidth = 80;
            colTel2.ReadOnly = true;
            colTel2.FillWeight = 100;
            colTel2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTel2.MaxInputLength = 30;
            colTel2.Visible = true;
            ///9ª Coluna
            DataGridViewTextBoxColumn colCel1 = new DataGridViewTextBoxColumn();
            colCel1.Name = "Celular1";
            colCel1.HeaderText = "Celular 1";
            colCel1.DataPropertyName = "Celular1";
            colCel1.Width = 80;
            colCel1.Frozen = false;
            colCel1.MinimumWidth = 80;
            colCel1.ReadOnly = true;
            colCel1.FillWeight = 100;
            colCel1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCel1.MaxInputLength = 30;
            colCel1.Visible = true;
            ///9ª Coluna
            DataGridViewTextBoxColumn colCel2 = new DataGridViewTextBoxColumn();
            colCel2.Name = "Celular2";
            colCel2.HeaderText = "Celular 2";
            colCel2.DataPropertyName = "Celular2";
            colCel2.Width = 80;
            colCel2.Frozen = false;
            colCel2.MinimumWidth = 80;
            colCel2.ReadOnly = true;
            colCel2.FillWeight = 100;
            colCel2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCel2.MaxInputLength = 30;
            colCel2.Visible = true;
            ///9ª Coluna
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.Name = "Email";
            colEmail.HeaderText = "Email";
            colEmail.DataPropertyName = "Email";
            colEmail.Width = 80;
            colEmail.Frozen = false;
            colEmail.MinimumWidth = 80;
            colEmail.ReadOnly = true;
            colEmail.FillWeight = 100;
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEmail.MaxInputLength = 200;
            colEmail.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colCodCCB = new DataGridViewTextBoxColumn();
            colCodCCB.Name = "CodCCB";
            colCodCCB.HeaderText = "CodCCB";
            colCodCCB.DataPropertyName = "CodCCB";
            colCodCCB.Width = 50;
            colCodCCB.Frozen = false;
            colCodCCB.MinimumWidth = 50;
            colCodCCB.ReadOnly = true;
            colCodCCB.FillWeight = 100;
            colCodCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodCCB.MaxInputLength = 100;
            colCodCCB.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colDescCCB = new DataGridViewTextBoxColumn();
            colDescCCB.Name = "DescCCB";
            colDescCCB.HeaderText = "Comum CCB";
            colDescCCB.DataPropertyName = "DescCCB";
            colDescCCB.Width = 80;
            colDescCCB.Frozen = false;
            colDescCCB.MinimumWidth = 80;
            colDescCCB.ReadOnly = true;
            colDescCCB.FillWeight = 100;
            colDescCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDescCCB.MaxInputLength = 100;
            colDescCCB.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colEstadoCivil = new DataGridViewTextBoxColumn();
            colEstadoCivil.Name = "EstadoCivil";
            colEstadoCivil.HeaderText = "Estado Civil";
            colEstadoCivil.DataPropertyName = "EstadoCivil";
            colEstadoCivil.Width = 100;
            colEstadoCivil.Frozen = false;
            colEstadoCivil.MinimumWidth = 80;
            colEstadoCivil.ReadOnly = true;
            colEstadoCivil.FillWeight = 100;
            colEstadoCivil.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEstadoCivil.MaxInputLength = 100;
            colEstadoCivil.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDataApresenta = new DataGridViewTextBoxColumn();
            colDataApresenta.Name = "DataApresentacao";
            colDataApresenta.HeaderText = "Data Apresentacao";
            colDataApresenta.DataPropertyName = "DataApresentacao";
            colDataApresenta.Width = 80;
            colDataApresenta.Frozen = false;
            colDataApresenta.DefaultCellStyle.Format = "dd/mm/yyyy";
            colDataApresenta.MinimumWidth = 80;
            colDataApresenta.ReadOnly = true;
            colDataApresenta.FillWeight = 100;
            colDataApresenta.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDataApresenta.MaxInputLength = 200;
            colDataApresenta.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colPaisCCB = new DataGridViewTextBoxColumn();
            colPaisCCB.Name = "PaisCCB";
            colPaisCCB.HeaderText = "Pais CCB";
            colPaisCCB.DataPropertyName = "PaisCCB";
            colPaisCCB.Width = 50;
            colPaisCCB.Frozen = false;
            colPaisCCB.MinimumWidth = 50;
            colPaisCCB.ReadOnly = true;
            colPaisCCB.FillWeight = 100;
            colPaisCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPaisCCB.MaxInputLength = 200;
            colPaisCCB.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colPai = new DataGridViewTextBoxColumn();
            colPai.Name = "Pai";
            colPai.HeaderText = "Pai";
            colPai.DataPropertyName = "Pai";
            colPai.Width = 80;
            colPai.Frozen = false;
            colPai.MinimumWidth = 80;
            colPai.ReadOnly = true;
            colPai.FillWeight = 100;
            colPai.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPai.MaxInputLength = 200;
            colPai.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colMae = new DataGridViewTextBoxColumn();
            colMae.Name = "Mae";
            colMae.HeaderText = "Mãe";
            colMae.DataPropertyName = "Mae";
            colMae.Width = 80;
            colMae.Frozen = false;
            colMae.MinimumWidth = 80;
            colMae.ReadOnly = true;
            colMae.FillWeight = 100;
            colMae.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colMae.MaxInputLength = 200;
            colMae.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colFormacaoFora = new DataGridViewTextBoxColumn();
            colFormacaoFora.Name = "FormacaoFora";
            colFormacaoFora.HeaderText = "Formação Fora";
            colFormacaoFora.DataPropertyName = "FormacaoFora";
            colFormacaoFora.Width = 60;
            colFormacaoFora.Frozen = false;
            colFormacaoFora.MinimumWidth = 60;
            colFormacaoFora.ReadOnly = true;
            colFormacaoFora.FillWeight = 100;
            colFormacaoFora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFormacaoFora.MaxInputLength = 200;
            colFormacaoFora.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colLocalForma = new DataGridViewTextBoxColumn();
            colLocalForma.Name = "LocalFormacao";
            colLocalForma.HeaderText = "Local Formação";
            colLocalForma.DataPropertyName = "LocalFormacao";
            colLocalForma.Width = 80;
            colLocalForma.Frozen = false;
            colLocalForma.MinimumWidth = 80;
            colLocalForma.ReadOnly = true;
            colLocalForma.FillWeight = 100;
            colLocalForma.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colLocalForma.MaxInputLength = 200;
            colLocalForma.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colQualFormacao = new DataGridViewTextBoxColumn();
            colQualFormacao.Name = "QualFormacao";
            colQualFormacao.HeaderText = "Qual Formação";
            colQualFormacao.DataPropertyName = "QualFormacao";
            colQualFormacao.Width = 60;
            colQualFormacao.Frozen = false;
            colQualFormacao.MinimumWidth = 60;
            colQualFormacao.ReadOnly = true;
            colQualFormacao.FillWeight = 100;
            colQualFormacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colQualFormacao.MaxInputLength = 200;
            colQualFormacao.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colOutraOrquestra = new DataGridViewTextBoxColumn();
            colOutraOrquestra.Name = "OutraOrquestra";
            colOutraOrquestra.HeaderText = "Outra Orquestra";
            colOutraOrquestra.DataPropertyName = "OutraOrquestra";
            colOutraOrquestra.Width = 60;
            colOutraOrquestra.Frozen = false;
            colOutraOrquestra.MinimumWidth = 60;
            colOutraOrquestra.ReadOnly = true;
            colOutraOrquestra.FillWeight = 100;
            colOutraOrquestra.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colOutraOrquestra.MaxInputLength = 200;
            colOutraOrquestra.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colOrquestra1 = new DataGridViewTextBoxColumn();
            colOrquestra1.Name = "Orquestra1";
            colOrquestra1.HeaderText = "Orquestra 1";
            colOrquestra1.DataPropertyName = "Orquestra1";
            colOrquestra1.Width = 80;
            colOrquestra1.Frozen = false;
            colOrquestra1.MinimumWidth = 80;
            colOrquestra1.ReadOnly = true;
            colOrquestra1.FillWeight = 100;
            colOrquestra1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colOrquestra1.MaxInputLength = 200;
            colOrquestra1.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colFuncao1 = new DataGridViewTextBoxColumn();
            colFuncao1.Name = "Funcao1";
            colFuncao1.HeaderText = "Função 1";
            colFuncao1.DataPropertyName = "Funcao1";
            colFuncao1.Width = 60;
            colFuncao1.Frozen = false;
            colFuncao1.MinimumWidth = 60;
            colFuncao1.ReadOnly = true;
            colFuncao1.FillWeight = 100;
            colFuncao1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFuncao1.MaxInputLength = 200;
            colFuncao1.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colOrquestra2 = new DataGridViewTextBoxColumn();
            colOrquestra2.Name = "Orquestra2";
            colOrquestra2.HeaderText = "Orquestra 2";
            colOrquestra2.DataPropertyName = "Orquestra2";
            colOrquestra2.Width = 80;
            colOrquestra2.Frozen = false;
            colOrquestra2.MinimumWidth = 80;
            colOrquestra2.ReadOnly = true;
            colOrquestra2.FillWeight = 100;
            colOrquestra2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colOrquestra2.MaxInputLength = 200;
            colOrquestra2.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colFuncao2 = new DataGridViewTextBoxColumn();
            colFuncao2.Name = "Funcao2";
            colFuncao2.HeaderText = "Função 2";
            colFuncao2.DataPropertyName = "Funcao2";
            colFuncao2.Width = 60;
            colFuncao2.Frozen = false;
            colFuncao2.MinimumWidth = 60;
            colFuncao2.ReadOnly = true;
            colFuncao2.FillWeight = 100;
            colFuncao2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFuncao2.MaxInputLength = 200;
            colFuncao2.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colOrquestra3 = new DataGridViewTextBoxColumn();
            colOrquestra3.Name = "Orquestra3";
            colOrquestra3.HeaderText = "Orquestra 3";
            colOrquestra3.DataPropertyName = "Orquestra3";
            colOrquestra3.Width = 80;
            colOrquestra3.Frozen = false;
            colOrquestra3.MinimumWidth = 80;
            colOrquestra3.ReadOnly = true;
            colOrquestra3.FillWeight = 100;
            colOrquestra3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colOrquestra3.MaxInputLength = 200;
            colOrquestra3.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colFuncao3 = new DataGridViewTextBoxColumn();
            colFuncao3.Name = "Funcao3";
            colFuncao3.HeaderText = "Função 3";
            colFuncao3.DataPropertyName = "Funcao3";
            colFuncao3.Width = 60;
            colFuncao3.Frozen = false;
            colFuncao3.MinimumWidth = 60;
            colFuncao3.ReadOnly = true;
            colFuncao3.FillWeight = 100;
            colFuncao3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFuncao3.MaxInputLength = 200;
            colFuncao3.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colCodInstr = new DataGridViewTextBoxColumn();
            colCodInstr.Name = "CodInstrumento";
            colCodInstr.HeaderText = "CodInstrumento";
            colCodInstr.DataPropertyName = "CodInstrumento";
            colCodInstr.Width = 50;
            colCodInstr.Frozen = false;
            colCodInstr.MinimumWidth = 50;
            colCodInstr.ReadOnly = true;
            colCodInstr.FillWeight = 100;
            colCodInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodInstr.MaxInputLength = 100;
            colCodInstr.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colDescInstr = new DataGridViewTextBoxColumn();
            colDescInstr.Name = "DescInstrumento";
            colDescInstr.HeaderText = "Instrumento";
            colDescInstr.DataPropertyName = "DescInstrumento";
            colDescInstr.Width = 80;
            colDescInstr.Frozen = false;
            colDescInstr.MinimumWidth = 80;
            colDescInstr.ReadOnly = true;
            colDescInstr.FillWeight = 100;
            colDescInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDescInstr.MaxInputLength = 100;
            colDescInstr.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colDesenv = new DataGridViewTextBoxColumn();
            colDesenv.Name = "Desenvolvimento";
            colDesenv.HeaderText = "Situação";
            colDesenv.DataPropertyName = "Desenvolvimento";
            colDesenv.Width = 80;
            colDesenv.Frozen = false;
            colDesenv.MinimumWidth = 80;
            colDesenv.ReadOnly = true;
            colDesenv.FillWeight = 100;
            colDesenv.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDesenv.MaxInputLength = 100;
            colDesenv.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colUltTeste = new DataGridViewTextBoxColumn();
            colUltTeste.Name = "DataUltimoTeste";
            colUltTeste.HeaderText = "Ultimo Teste";
            colUltTeste.DataPropertyName = "DataUltimoTeste";
            colUltTeste.Width = 60;
            colUltTeste.Frozen = false;
            colUltTeste.DefaultCellStyle.Format = "dd/mm/yyyy";
            colUltTeste.MinimumWidth = 60;
            colUltTeste.ReadOnly = true;
            colUltTeste.FillWeight = 100;
            colUltTeste.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colUltTeste.MaxInputLength = 100;
            colUltTeste.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colInicioEstudo = new DataGridViewTextBoxColumn();
            colInicioEstudo.Name = "DataInicioEstudo";
            colInicioEstudo.HeaderText = "Inicio Estudo";
            colInicioEstudo.DataPropertyName = "DataInicioEstudo";
            colInicioEstudo.Width = 60;
            colInicioEstudo.DefaultCellStyle.Format = "dd/mm/yyyy";
            colInicioEstudo.Frozen = false;
            colInicioEstudo.MinimumWidth = 60;
            colInicioEstudo.ReadOnly = true;
            colInicioEstudo.FillWeight = 100;
            colInicioEstudo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colInicioEstudo.MaxInputLength = 100;
            colInicioEstudo.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colExecutInstr = new DataGridViewTextBoxColumn();
            colExecutInstr.Name = "ExecutandoInstrumento";
            colExecutInstr.HeaderText = "Execut. Instrumento";
            colExecutInstr.DataPropertyName = "ExecutInstrumento";
            colExecutInstr.Width = 80;
            colExecutInstr.Frozen = false;
            colExecutInstr.MinimumWidth = 60;
            colExecutInstr.ReadOnly = true;
            colExecutInstr.FillWeight = 100;
            colExecutInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colExecutInstr.MaxInputLength = 100;
            colExecutInstr.Visible = true;
            ///1ª coluna
            DataGridViewTextBoxColumn colSeq = new DataGridViewTextBoxColumn();
            colSeq.DataPropertyName = "Sequencia";
            colSeq.Name = "Sequencia";
            colSeq.HeaderText = "";
            colSeq.DefaultCellStyle.ForeColor = Color.DarkGray;
            colSeq.Width = 40;
            colSeq.Frozen = false;
            colSeq.DefaultCellStyle.Format = "00000";
            colSeq.MinimumWidth = 40;
            colSeq.ReadOnly = true;
            colSeq.FillWeight = 100;
            colSeq.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSeq.MaxInputLength = 200;
            colSeq.Visible = true;
            ///1ª coluna
            DataGridViewTextBoxColumn colImp = new DataGridViewTextBoxColumn();
            colImp.DataPropertyName = "CodImportaPessoa";
            colImp.Name = "CodImportaPessoa";
            colImp.HeaderText = "Importação";
            colImp.DefaultCellStyle.ForeColor = Color.DarkGray;
            colImp.Width = 50;
            colImp.Frozen = false;
            colImp.DefaultCellStyle.Format = "000000";
            colImp.MinimumWidth = 50;
            colImp.ReadOnly = true;
            colImp.FillWeight = 100;
            colImp.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colImp.MaxInputLength = 200;
            colImp.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            gridErro.Columns.Add(colSeq);
            gridErro.Columns.Add(colImp);
            gridErro.Columns.Add(colDataCadastro);
            gridErro.Columns.Add(colHoraCadastro);
            gridErro.Columns.Add(colCodCargo);
            gridErro.Columns.Add(colDescCargo);
            gridErro.Columns.Add(colNome);
            gridErro.Columns.Add(colDataNasc);
            gridErro.Columns.Add(colCpf);
            gridErro.Columns.Add(colRg);
            gridErro.Columns.Add(colEmis);
            gridErro.Columns.Add(colSexo);
            gridErro.Columns.Add(colDataBatismo);
            gridErro.Columns.Add(colCep);
            gridErro.Columns.Add(colCid);
            gridErro.Columns.Add(colCodCidadeRes);
            gridErro.Columns.Add(colEstRes);
            gridErro.Columns.Add(colEndRes);
            gridErro.Columns.Add(colNumRes);
            gridErro.Columns.Add(colBairroRes);
            gridErro.Columns.Add(colComplRes);
            gridErro.Columns.Add(colTel1);
            gridErro.Columns.Add(colTel2);
            gridErro.Columns.Add(colCel1);
            gridErro.Columns.Add(colCel2);
            gridErro.Columns.Add(colEmail);
            gridErro.Columns.Add(colCodCCB);
            gridErro.Columns.Add(colDescCCB);
            gridErro.Columns.Add(colEstadoCivil);
            gridErro.Columns.Add(colDataApresenta);
            gridErro.Columns.Add(colPaisCCB);
            gridErro.Columns.Add(colPai);
            gridErro.Columns.Add(colMae);
            gridErro.Columns.Add(colFormacaoFora);
            gridErro.Columns.Add(colLocalForma);
            gridErro.Columns.Add(colQualFormacao);
            gridErro.Columns.Add(colOutraOrquestra);
            gridErro.Columns.Add(colOrquestra1);
            gridErro.Columns.Add(colFuncao1);
            gridErro.Columns.Add(colOrquestra2);
            gridErro.Columns.Add(colFuncao2);
            gridErro.Columns.Add(colOrquestra3);
            gridErro.Columns.Add(colFuncao3);
            gridErro.Columns.Add(colCodInstr);
            gridErro.Columns.Add(colDescInstr);
            gridErro.Columns.Add(colDesenv);
            gridErro.Columns.Add(colUltTeste);
            gridErro.Columns.Add(colInicioEstudo);
            gridErro.Columns.Add(colExecutInstr);
            gridErro.Columns.Add(colCodItem);

            gridErro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ///feito um refresh para fazer a atualização do datagridview
            gridErro.Refresh();
        }

        /// <summary>
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaImporta"></param>
        internal void preencherErro(string CodCCBUsu)
        {
            try
            {

                IBLL_buscaImportaPessoaErro objBLL_Erro = new BLL_buscaImportaPessoaErro();
                listaImportaItemErro = new List<MOD_importaPessoaItemErro>();

                listaImportaItemErro = objBLL_Erro.Buscar(preencheCCBImporta(modulos.CodUsuario));

                objBind_ImpErro = new BindingSource();
                montaGridDadosErro();
                objBind_ImpErro.DataSource = listaImportaItemErro;
                gridErro.DataSource = objBind_ImpErro;

                //No total de registros
                txtQtdeErro.Text = Convert.ToString(gridErro.Rows.Count).PadLeft(6, '0');
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
        /// Função que carrega os dados vinculados
        /// </summary>
        /// <param name="lista"></param>
        internal void carregaErro(List<MOD_importaPessoaItemErro> lista)
        {
            try
            {
                List<MOD_importaPessoaItemErro> listaFiltro = new List<MOD_importaPessoaItemErro>();
                listaPessoa = new List<MOD_pessoa>();
                objBind_Pessoa = new BindingSource();
                objBind_Pessoa.DataSource = listaPessoa;

                listaFiltro = lista.Where(x => x.CodImportaPessoaItem.Equals(CodImportaErro)).ToList();

                foreach (MOD_importaPessoaItemErro ent in listaFiltro)
                {
                    MOD_pessoa objEnt_Pessoa = new MOD_pessoa();

                    objEnt_Pessoa.Ativo = "Sim";
                    objEnt_Pessoa.DataCadastro = ent.DataCadastro;
                    objEnt_Pessoa.DataNasc = ent.DataNasc;
                    objEnt_Pessoa.DataBatismo = ent.DataBatismo;
                    objEnt_Pessoa.DataApresentacao = ent.DataApresentacao;
                    objEnt_Pessoa.HoraCadastro = ent.HoraCadastro;
                    objEnt_Pessoa.Nome = ent.Nome;
                    objEnt_Pessoa.DescCargo = ent.DescCargo;
                    objEnt_Pessoa.CodCargo = ent.CodCargo;
                    objEnt_Pessoa.Cpf = ent.Cpf;
                    objEnt_Pessoa.Rg = ent.Rg;
                    objEnt_Pessoa.OrgaoEmissor = ent.OrgaoEmissor;
                    objEnt_Pessoa.Sexo = ent.Sexo;
                    objEnt_Pessoa.CepRes = ent.CepRes;
                    objEnt_Pessoa.CodCidadeRes = ent.CodCidadeRes;
                    objEnt_Pessoa.CidadeRes = ent.CidadeRes;
                    objEnt_Pessoa.EndRes = ent.EndRes;
                    objEnt_Pessoa.NumRes = ent.NumRes;
                    objEnt_Pessoa.BairroRes = ent.BairroRes;
                    objEnt_Pessoa.ComplRes = ent.ComplRes;
                    objEnt_Pessoa.Telefone1 = ent.Telefone1;
                    objEnt_Pessoa.Telefone2 = ent.Telefone2;
                    objEnt_Pessoa.Celular1 = ent.Celular1;
                    objEnt_Pessoa.Celular2 = ent.Celular2;
                    objEnt_Pessoa.Email = ent.Email;
                    objEnt_Pessoa.Descricao = ent.DescCCB;
                    objEnt_Pessoa.CodCCB = ent.CodCCB;
                    objEnt_Pessoa.EstadoCivil = ent.EstadoCivil;
                    objEnt_Pessoa.PaisCCB = ent.PaisCCB;
                    objEnt_Pessoa.Pai = ent.Pai;
                    objEnt_Pessoa.Mae = ent.Mae;
                    objEnt_Pessoa.FormacaoFora = ent.FormacaoFora;
                    objEnt_Pessoa.LocalFormacao = ent.LocalFormacao;
                    objEnt_Pessoa.QualFormacao = ent.QualFormacao;
                    objEnt_Pessoa.OutraOrquestra = ent.OutraOrquestra;
                    objEnt_Pessoa.Orquestra1 = ent.Orquestra1;
                    objEnt_Pessoa.Funcao1 = ent.Funcao1;
                    objEnt_Pessoa.Orquestra2 = ent.Orquestra2;
                    objEnt_Pessoa.Funcao2 = ent.Funcao2;
                    objEnt_Pessoa.Orquestra3 = ent.Orquestra3;
                    objEnt_Pessoa.Funcao3 = ent.Funcao3;
                    objEnt_Pessoa.DescInstrumento = ent.DescInstrumento;
                    objEnt_Pessoa.CodInstrumento = ent.CodInstrumento;
                    objEnt_Pessoa.Desenvolvimento = ent.Desenvolvimento;
                    objEnt_Pessoa.DataUltimoTeste = ent.DataUltimoTeste;
                    objEnt_Pessoa.DataInicioEstudo = ent.DataInicioEstudo;
                    objEnt_Pessoa.ExecutInstrumento = ent.ExecutInstrumento;
                    objEnt_Pessoa.Sequencia = ent.Sequencia;

                    listaPessoa.Add(objEnt_Pessoa);
                    objBind_Pessoa.DataSource = listaPessoa;

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

        /// <summary>
        /// Função que abre os formulários de pesquisa
        /// </summary>
        /// <param name="form"></param>
        private void abrirForm(string form, int Indice)
        {
            try
            {
                if (form.Equals("frmPessoaErro"))
                {
                    carregaErro(listaImportaItemErro);

                    formulario = new frmPessoaErros(this, CodImporta, CodImportaErro, listaPessoa);
                    ((frmPessoaErros)formulario).MdiParent = MdiParent;
                    ((frmPessoaErros)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPessoaErros)formulario));
                    ((frmPessoaErros)formulario).Show();
                    ((frmPessoaErros)formulario).BringToFront();
                    Enabled = false;
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

        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_importaPessoaItem> criarListaItens()
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoaItem> lista = new List<MOD_importaPessoaItem>();
                //instancia a entidade
                MOD_importaPessoaItem ent = new MOD_importaPessoaItem();

                //adiciona os campos às propriedades
                ent.CodImportaPessoaItem = "0";
                ent.CodImportaPessoa = Convert.ToString(objEnt_ItemErro.CodImportaPessoa).PadLeft(6, '0');
                ent.DataCadastro = Convert.ToString(objEnt_ItemErro.DataCadastro);
                ent.HoraCadastro = Convert.ToString(objEnt_ItemErro.HoraCadastro);
                ent.CodCargo = Convert.ToString(objEnt_ItemErro.CodCargo).PadLeft(3, '0');
                ent.DescCargo = Convert.ToString(objEnt_ItemErro.DescCargo);
                ent.Nome = Convert.ToString(objEnt_ItemErro.Nome).ToUpper();
                ent.DataNasc = Convert.ToString(objEnt_ItemErro.DataNasc);
                ent.Cpf = Convert.ToString(objEnt_ItemErro.Cpf);
                ent.Rg = Convert.ToString(objEnt_ItemErro.Rg);
                ent.OrgaoEmissor = Convert.ToString(objEnt_ItemErro.OrgaoEmissor);
                ent.Sexo = Convert.ToString(objEnt_ItemErro.Sexo);
                ent.DataBatismo = Convert.ToString(objEnt_ItemErro.DataBatismo);
                ent.CodCidadeRes = Convert.ToString(objEnt_ItemErro.CodCidadeRes).PadLeft(6, '0');
                ent.CidadeRes = Convert.ToString(objEnt_ItemErro.CidadeRes);
                ent.CepRes = Convert.ToString(objEnt_ItemErro.CepRes);
                ent.EndRes = Convert.ToString(objEnt_ItemErro.EndRes).ToUpper();
                ent.NumRes = Convert.ToString(objEnt_ItemErro.NumRes);
                ent.BairroRes = Convert.ToString(objEnt_ItemErro.BairroRes).ToUpper();
                ent.ComplRes = Convert.ToString(objEnt_ItemErro.ComplRes).ToUpper();
                ent.Telefone1 = Convert.ToString(objEnt_ItemErro.Telefone1);
                ent.Telefone2 = Convert.ToString(objEnt_ItemErro.Telefone2);
                ent.Celular1 = Convert.ToString(objEnt_ItemErro.Celular1);
                ent.Celular2 = Convert.ToString(objEnt_ItemErro.Celular2);
                ent.Email = Convert.ToString(objEnt_ItemErro.Email).ToLower();
                ent.CodCCB = Convert.ToString(objEnt_ItemErro.CodCCB).PadLeft(6, '0');
                ent.DescricaoCCB = Convert.ToString(objEnt_ItemErro.DescCCB);
                ent.EstadoCivil = Convert.ToString(objEnt_ItemErro.EstadoCivil);
                ent.DataApresentacao = Convert.ToString(objEnt_ItemErro.DataApresentacao);
                ent.PaisCCB = Convert.ToString(objEnt_ItemErro.PaisCCB);
                ent.Pai = Convert.ToString(objEnt_ItemErro.Pai).ToUpper();
                ent.Mae = Convert.ToString(objEnt_ItemErro.Mae).ToUpper();
                ent.FormacaoFora = Convert.ToString(objEnt_ItemErro.FormacaoFora);
                ent.LocalFormacao = Convert.ToString(objEnt_ItemErro.LocalFormacao).ToUpper();
                ent.QualFormacao = Convert.ToString(objEnt_ItemErro.QualFormacao).ToUpper();
                ent.OutraOrquestra = Convert.ToString(objEnt_ItemErro.OutraOrquestra);
                ent.Orquestra1 = Convert.ToString(objEnt_ItemErro.Orquestra1).ToUpper();
                ent.Funcao1 = Convert.ToString(objEnt_ItemErro.Funcao1).ToUpper();
                ent.Orquestra2 = Convert.ToString(objEnt_ItemErro.Orquestra2).ToUpper();
                ent.Funcao2 = Convert.ToString(objEnt_ItemErro.Funcao2).ToUpper();
                ent.Orquestra3 = Convert.ToString(objEnt_ItemErro.Orquestra3).ToUpper();
                ent.Funcao3 = Convert.ToString(objEnt_ItemErro.Funcao3).ToUpper();
                ent.CodInstrumento = Convert.ToString(objEnt_ItemErro.CodInstrumento).PadLeft(5, '0');
                ent.DescInstrumento = Convert.ToString(objEnt_ItemErro.DescInstrumento);
                ent.Desenvolvimento = Convert.ToString(objEnt_ItemErro.Desenvolvimento);
                ent.DataUltimoTeste = Convert.ToString(objEnt_ItemErro.DataUltimoTeste);
                ent.DataInicioEstudo = Convert.ToString(objEnt_ItemErro.DataInicioEstudo);
                ent.ExecutInstrumento = Convert.ToString(objEnt_ItemErro.ExecutInstrumento);

                //adiciona os dados à lista
                lista.Add(ent);

                //retorna a lista com os valores pesquisados
                return lista;
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_importaPessoaItemErro> criarListaItensErros()
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoaItemErro> lista = new List<MOD_importaPessoaItemErro>();
                //instancia a entidade
                MOD_importaPessoaItemErro ent = new MOD_importaPessoaItemErro();

                //adiciona os campos às propriedades
                ent.CodImportaPessoaItem = objEnt_ItemErro.CodImportaPessoaItem;
                ent.CodImportaPessoa = objEnt_ItemErro.CodImportaPessoa;

                //adiciona os dados à lista
                lista.Add(ent);

                //retorna a lista com os valores pesquisados
                return lista;
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
        /// Função que define a cor da celula com erro
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void definirErro(DataGridView dataGrid)
        {
            try
            {
                foreach (DataGridViewRow linha in dataGrid.Rows)
                {
                    foreach (DataGridViewCell celula in linha.Cells)
                    {
                        if (celula.Value != null)
                        {
                            if (celula.Value.ToString().Contains("Erro"))
                            {
                                celula.Style.BackColor = Color.Red;
                            }
                            else
                            {
                                celula.Style.BackColor = Color.White;
                            }
                        }
                    }
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

        /// <summary>
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                btnEditar.Enabled = false;
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
        /// Função que habilita os controles
        /// </summary>
        internal void enabledForm()
        {
            try
            {
                btnEditar.Enabled = true;
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
        /// Sub que informa as Comuns que o Usuario poderá acessar
        /// </summary>
        internal string preencheCCBImporta(string CodUsuario, string CodRegiao)
        {
            try
            {
                string CodUsuCCB = string.Empty;
                objBLL_CCBUsuario = new BLL_usuario();
                listaCCBUsuario = objBLL_CCBUsuario.buscarUsuarioCCB(CodUsuario, CodRegiao);

                foreach (MOD_usuarioCCB ent in listaCCBUsuario)
                {
                    string Codigo = string.Empty;
                    if (CodUsuCCB.Equals(string.Empty))
                    {
                        Codigo = Convert.ToInt32(ent.CodCCB).ToString();
                    }
                    else
                    {
                        Codigo = CodUsuCCB + "','" + Convert.ToInt32(ent.CodCCB).ToString();
                    }
                    CodUsuCCB = Codigo;
                }

                if (modulos.Supervisor.Equals("Sim"))
                {
                    return CodUsuCCB + "','" + "Erro";
                }
                else
                {
                    return CodUsuCCB;
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
        /// <summary>
        /// Sub que informa as Comuns que o Usuario poderá acessar
        /// </summary>
        internal string preencheCCBImporta(string CodUsuario)
        {
            try
            {
                string CodUsuCCB = string.Empty;
                objBLL_CCBUsuario = new BLL_usuario();
                listaCCBUsuario = objBLL_CCBUsuario.buscarUsuarioCCB(CodUsuario);

                foreach (MOD_usuarioCCB ent in listaCCBUsuario)
                {
                    string Codigo = string.Empty;
                    if (CodUsuCCB.Equals(string.Empty))
                    {
                        Codigo = Convert.ToInt32(ent.CodCCB).ToString();
                    }
                    else
                    {
                        Codigo = CodUsuCCB + "','" + Convert.ToInt32(ent.CodCCB).ToString();
                    }
                    CodUsuCCB = Codigo;
                }

                if (modulos.Supervisor.Equals("Sim"))
                {
                    return CodUsuCCB + "','" + "Erro";
                }
                else
                {
                    return CodUsuCCB;
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

        #endregion

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        /// <param name="dataGrid"></param>
        internal void verPermErro(DataGridView dataGrid)
        {
            try
            {
                btnEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(new MOD_acessoImportaPessoaItemErro().RotEditImportaPessoaErro, dataGrid);
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

    }
}