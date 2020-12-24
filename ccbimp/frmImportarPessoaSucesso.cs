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
    public partial class frmImportarPessoaSucesso : Form
    {
        public frmImportarPessoaSucesso(Form forms, DataGridView gridPesquisa, List<MOD_importaPessoa> lista)
        {
            InitializeComponent();

            try
            {
                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                ///Recebe a lista e armazena
                listaImporta = lista;

                #region Carregar ComboBox

                apoio.carregaComboRegional(cboRegional);
                apoio.carregaComboRegiao(cboRegiao, Convert.ToString(cboRegional.SelectedValue));

                #endregion

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencherSucesso(lista[0].CodImportaPessoa);
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

        #region declarações

        //Código da Pessoa a Editar
        string CodImportaErro;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        BLL_importaPessoa objBLL_Importa = null;
        MOD_importaPessoa objEnt = null;
        List<MOD_importaPessoa> listaImporta = null;

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

        #endregion

        #region Eventos Formulario

        private void frmImportarPessoaSucesso_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void frmImportarPessoaSucesso_FormClosing(object sender, FormClosingEventArgs e)
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
        private void tabImportados_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabImportados.SelectedTab.Equals(tabSucesso))
                {
                    if (listaImporta[0].ListaPessoaItem == null || listaImporta[0].ListaPessoaItem.Count < 1)
                    {
                        preencherSucesso(listaImporta[0].CodImportaPessoa);
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

        #endregion

        #region Funções Publicas e Privadas

        ///<summary> Montar DataGrid Dados Importados com Sucesso
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta pessoas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        private void montaGridDadosSucesso()
        {
            gridSucesso.AutoGenerateColumns = false;
            gridSucesso.DataSource = null;
            gridSucesso.Columns.Clear();
            gridSucesso.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///1ª coluna
            DataGridViewTextBoxColumn colAtivo = new DataGridViewTextBoxColumn();
            colAtivo.DataPropertyName = "Ativo";
            colAtivo.Name = "Ativo";
            colAtivo.HeaderText = "Ativo";
            colAtivo.Width = 80;
            colAtivo.Frozen = false;
            colAtivo.MinimumWidth = 80;
            colAtivo.ReadOnly = true;
            colAtivo.FillWeight = 100;
            colAtivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colAtivo.MaxInputLength = 200;
            colAtivo.Visible = false;
            ///1ª coluna
            DataGridViewTextBoxColumn colCodPessoa = new DataGridViewTextBoxColumn();
            colCodPessoa.DataPropertyName = "CodPessoa";
            colCodPessoa.Name = "CodPessoa";
            colCodPessoa.HeaderText = "CodPessoa";
            colCodPessoa.Width = 80;
            colCodPessoa.Frozen = false;
            colCodPessoa.MinimumWidth = 80;
            colCodPessoa.ReadOnly = true;
            colCodPessoa.FillWeight = 100;
            colCodPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodPessoa.MaxInputLength = 200;
            colCodPessoa.Visible = false;
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
            colDescCCB.DataPropertyName = "Descricao";
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

            ///aqui é adicionado as colunas no datagridview
            gridSucesso.Columns.Add(colSeq);
            gridSucesso.Columns.Add(colAtivo);
            gridSucesso.Columns.Add(colCodPessoa);
            gridSucesso.Columns.Add(colDataCadastro);
            gridSucesso.Columns.Add(colHoraCadastro);
            gridSucesso.Columns.Add(colCodCargo);
            gridSucesso.Columns.Add(colDescCargo);
            gridSucesso.Columns.Add(colNome);
            gridSucesso.Columns.Add(colDataNasc);
            gridSucesso.Columns.Add(colCpf);
            gridSucesso.Columns.Add(colRg);
            gridSucesso.Columns.Add(colEmis);
            gridSucesso.Columns.Add(colSexo);
            gridSucesso.Columns.Add(colDataBatismo);
            gridSucesso.Columns.Add(colCep);
            gridSucesso.Columns.Add(colCid);
            gridSucesso.Columns.Add(colCodCidadeRes);
            gridSucesso.Columns.Add(colEstRes);
            gridSucesso.Columns.Add(colEndRes);
            gridSucesso.Columns.Add(colNumRes);
            gridSucesso.Columns.Add(colBairroRes);
            gridSucesso.Columns.Add(colComplRes);
            gridSucesso.Columns.Add(colTel1);
            gridSucesso.Columns.Add(colTel2);
            gridSucesso.Columns.Add(colCel1);
            gridSucesso.Columns.Add(colCel2);
            gridSucesso.Columns.Add(colEmail);
            gridSucesso.Columns.Add(colCodCCB);
            gridSucesso.Columns.Add(colDescCCB);
            gridSucesso.Columns.Add(colEstadoCivil);
            gridSucesso.Columns.Add(colDataApresenta);
            gridSucesso.Columns.Add(colPaisCCB);
            gridSucesso.Columns.Add(colPai);
            gridSucesso.Columns.Add(colMae);
            gridSucesso.Columns.Add(colFormacaoFora);
            gridSucesso.Columns.Add(colLocalForma);
            gridSucesso.Columns.Add(colQualFormacao);
            gridSucesso.Columns.Add(colOutraOrquestra);
            gridSucesso.Columns.Add(colOrquestra1);
            gridSucesso.Columns.Add(colFuncao1);
            gridSucesso.Columns.Add(colOrquestra2);
            gridSucesso.Columns.Add(colFuncao2);
            gridSucesso.Columns.Add(colOrquestra3);
            gridSucesso.Columns.Add(colFuncao3);
            gridSucesso.Columns.Add(colCodInstr);
            gridSucesso.Columns.Add(colDescInstr);
            gridSucesso.Columns.Add(colDesenv);
            gridSucesso.Columns.Add(colUltTeste);
            gridSucesso.Columns.Add(colInicioEstudo);
            gridSucesso.Columns.Add(colExecutInstr);

            //gridSucesso.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            ///feito um refresh para fazer a atualização do datagridview
            gridSucesso.Refresh();
        }

        /// <summary>
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaImporta"></param>
        internal void preencherSucesso(string CodImportaPessoa)
        {
            try
            {
                IBLL_buscaImportaPessoaItem objBLL_BuscaItem = new BLL_buscaImportaPessoaItem();
                List<MOD_importaPessoaItem> listaItem = new List<MOD_importaPessoaItem>();

                listaItem = objBLL_BuscaItem.Buscar(modulos.CodUsuarioCCB, CodImportaPessoa, modulos.CodUsuarioCargo);

                objBind_ImpSucesso = new BindingSource();
                objBind_ImpSucesso.DataSource = listaItem;
                montaGridDadosSucesso();
                gridSucesso.DataSource = objBind_ImpSucesso;

                //No total de registros
                txtQtdeSucesso.Text = Convert.ToString(gridSucesso.Rows.Count).PadLeft(6, '0');
                
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
        /// Sub que informa as Comuns que o Usuario poderá acessar
        /// </summary>
        internal string preencheCCBImporta(string CodUsuario, string CodRegiao)
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

        #endregion

    }
}