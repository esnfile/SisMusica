using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using System.Data;
using ENT.acessos;
using System.Drawing;
using ENT.Erros;

namespace BLL.Funcoes
{
    public static class funcoes
    {

        #region Declarações

        static readonly List<Form> formularios = new List<Form>();

        #endregion

        ///Funções que cria e monta os datagridview
        #region ### Função que cria os datagridview ###

        #region funções que monta os datagridview da parte uteis

        ///<summary> Montar DataGrid Pessoas
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta pessoas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridPessoa(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Status";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;

            DataGridViewTextBoxColumn colAtivo = new DataGridViewTextBoxColumn();
            colAtivo.DataPropertyName = "Ativo";
            colAtivo.HeaderText = "Ativo";
            colAtivo.Name = "Ativo";
            colAtivo.Width = 50;
            colAtivo.Frozen = false;
            colAtivo.MinimumWidth = 45;
            colAtivo.ReadOnly = true;
            colAtivo.FillWeight = 100;
            colAtivo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAtivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colAtivo.MaxInputLength = 10;
            colAtivo.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodPessoa = new DataGridViewTextBoxColumn();
            colCodPessoa.DataPropertyName = "CodPessoa";
            colCodPessoa.Name = "CodPessoa";
            colCodPessoa.HeaderText = "Código";
            colCodPessoa.Width = 60;
            colCodPessoa.Frozen = false;
            colCodPessoa.MinimumWidth = 60;
            colCodPessoa.ReadOnly = true;
            colCodPessoa.FillWeight = 100;
            colCodPessoa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodPessoa.MaxInputLength = 10;
            colCodPessoa.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.DataPropertyName = "Nome";
            colNome.Name = "Nome";
            colNome.HeaderText = "Nome";
            colNome.Width = 180;
            colNome.Frozen = false;
            colNome.MinimumWidth = 120;
            colNome.ReadOnly = true;
            colNome.FillWeight = 100;
            colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNome.MaxInputLength = 200;
            colNome.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colCpf = new DataGridViewTextBoxColumn();
            colCpf.DataPropertyName = "Cpf";
            colCpf.Name = "Cpf";
            colCpf.HeaderText = "C.P.F.";
            colCpf.Width = 120;
            colCpf.Frozen = false;
            colCpf.MinimumWidth = 80;
            colCpf.ReadOnly = true;
            colCpf.FillWeight = 100;
            colCpf.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCpf.MaxInputLength = 30;
            colCpf.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colRg = new DataGridViewTextBoxColumn();
            colRg.DataPropertyName = "Rg";
            colRg.Name = "Rg";
            colRg.HeaderText = "R.G.";
            colRg.Width = 100;
            colRg.Frozen = false;
            colRg.MinimumWidth = 80;
            colRg.ReadOnly = true;
            colRg.FillWeight = 100;
            colRg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colRg.MaxInputLength = 30;
            colRg.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colCid = new DataGridViewTextBoxColumn();
            colCid.DataPropertyName = "CidadeRes";
            colCid.Name = "CidadeRes";
            colCid.HeaderText = "Cidade";
            colCid.Width = 100;
            colCid.Frozen = false;
            colCid.MinimumWidth = 80;
            colCid.ReadOnly = true;
            colCid.FillWeight = 100;
            colCid.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCid.MaxInputLength = 100;
            colCid.Visible = true;
            ///7ª coluna
            DataGridViewTextBoxColumn colEnd = new DataGridViewTextBoxColumn();
            colEnd.DataPropertyName = "EndRes";
            colEnd.Name = "EndRes";
            colEnd.HeaderText = "Endereço";
            colEnd.Width = 180;
            colEnd.Frozen = false;
            colEnd.MinimumWidth = 120;
            colEnd.ReadOnly = true;
            colEnd.FillWeight = 100;
            colEnd.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEnd.MaxInputLength = 200;
            colEnd.Visible = true;
            ///8ª coluna
            DataGridViewTextBoxColumn colNum = new DataGridViewTextBoxColumn();
            colNum.DataPropertyName = "NumRes";
            colNum.Name = "NumRes";
            colNum.HeaderText = "Número";
            colNum.Width = 50;
            colNum.Frozen = false;
            colNum.MinimumWidth = 40;
            colNum.ReadOnly = true;
            colNum.FillWeight = 100;
            colNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNum.MaxInputLength = 20;
            colNum.Visible = true;
            ///9ª Coluna
            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.DataPropertyName = "Celular1";
            colTel.Name = "Celular1";
            colTel.HeaderText = "1º Celular";
            colTel.Width = 130;
            colTel.Frozen = false;
            colTel.MinimumWidth = 110;
            colTel.ReadOnly = true;
            colTel.FillWeight = 100;
            colTel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTel.MaxInputLength = 30;
            colTel.Visible = true;
            ///10ª coluna
            DataGridViewTextBoxColumn colCargo = new DataGridViewTextBoxColumn();
            colCargo.DataPropertyName = "DescCargo";
            colCargo.Name = "DescCargo";
            colCargo.HeaderText = "Ministério";
            colCargo.Width = 105;
            colCargo.Frozen = false;
            colCargo.MinimumWidth = 100;
            colCargo.ReadOnly = true;
            colCargo.FillWeight = 100;
            colCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCargo.MaxInputLength = 100;
            colCargo.Visible = true;
            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colAtivo);
            dataGrid.Columns.Add(colCargo);
            dataGrid.Columns.Add(colCodPessoa);
            dataGrid.Columns.Add(colNome);
            dataGrid.Columns.Add(colCpf);
            dataGrid.Columns.Add(colRg);
            dataGrid.Columns.Add(colCid);
            dataGrid.Columns.Add(colEnd);
            dataGrid.Columns.Add(colNum);
            dataGrid.Columns.Add(colTel);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Pessoas
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta pessoas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///<para>Parametros Tabela:</para>
        ///<para> - Tabela: Relatorios</para>
        ///</summary>
        public static void gridPessoa(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("Relatorios"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///2ª coluna
                DataGridViewTextBoxColumn colCodPessoa = new DataGridViewTextBoxColumn();
                colCodPessoa.DataPropertyName = "CodPessoa";
                colCodPessoa.Name = "CodPessoa";
                colCodPessoa.HeaderText = "Código";
                colCodPessoa.Width = 60;
                colCodPessoa.Frozen = false;
                colCodPessoa.MinimumWidth = 60;
                colCodPessoa.ReadOnly = true;
                colCodPessoa.FillWeight = 100;
                colCodPessoa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodPessoa.MaxInputLength = 10;
                colCodPessoa.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
                colNome.DataPropertyName = "Nome";
                colNome.Name = "Nome";
                colNome.HeaderText = "Nome";
                colNome.Width = 150;
                colNome.Frozen = false;
                colNome.MinimumWidth = 100;
                colNome.ReadOnly = true;
                colNome.FillWeight = 100;
                colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colNome.MaxInputLength = 200;
                colNome.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colCpf = new DataGridViewTextBoxColumn();
                colCpf.DataPropertyName = "Cpf";
                colCpf.Name = "Cpf";
                colCpf.HeaderText = "C.P.F.";
                colCpf.Width = 120;
                colCpf.Frozen = false;
                colCpf.MinimumWidth = 80;
                colCpf.ReadOnly = true;
                colCpf.FillWeight = 100;
                colCpf.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCpf.MaxInputLength = 30;
                colCpf.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colCid = new DataGridViewTextBoxColumn();
                colCid.DataPropertyName = "CidadeRes";
                colCid.Name = "CidadeRes";
                colCid.HeaderText = "Cidade";
                colCid.Width = 100;
                colCid.Frozen = false;
                colCid.MinimumWidth = 80;
                colCid.ReadOnly = true;
                colCid.FillWeight = 100;
                colCid.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCid.MaxInputLength = 100;
                colCid.Visible = true;
                ///10ª coluna
                DataGridViewTextBoxColumn colDescCCB = new DataGridViewTextBoxColumn();
                colDescCCB.DataPropertyName = "Descricao";
                colDescCCB.Name = "Descricao";
                colDescCCB.HeaderText = "Comum Congregação";
                colDescCCB.Width = 150;
                colDescCCB.Frozen = false;
                colDescCCB.MinimumWidth = 100;
                colDescCCB.ReadOnly = true;
                colDescCCB.FillWeight = 100;
                colDescCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescCCB.MaxInputLength = 100;
                colDescCCB.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodPessoa);
                dataGrid.Columns.Add(colNome);
                dataGrid.Columns.Add(colCid);
                dataGrid.Columns.Add(colDescCCB);
            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Cidades
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta cidades, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridCidade(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn text1 = new DataGridViewTextBoxColumn();
            text1.DataPropertyName = "CodCidade";
            text1.HeaderText = "Código";
            text1.Width = 60;
            text1.Frozen = false;
            text1.MinimumWidth = 55;
            text1.ReadOnly = true;
            text1.FillWeight = 100;
            text1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            text1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text1.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn text2 = new DataGridViewTextBoxColumn();
            text2.DataPropertyName = "Cidade";
            text2.HeaderText = "Cidade";
            text2.Width = 120;
            text2.Frozen = false;
            text2.MinimumWidth = 100;
            text2.ReadOnly = true;
            text2.FillWeight = 100;
            text2.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text2.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn text3 = new DataGridViewTextBoxColumn();
            text3.DataPropertyName = "Estado";
            text3.HeaderText = "Estado";
            text3.Width = 50;
            text3.Frozen = false;
            text3.MinimumWidth = 50;
            text3.ReadOnly = true;
            text3.FillWeight = 100;
            text3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            text3.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text3.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn text4 = new DataGridViewTextBoxColumn();
            text4.DataPropertyName = "Cep";
            text4.HeaderText = "Cep";
            text4.Width = 85;
            text4.Frozen = false;
            text4.MinimumWidth = 70;
            text4.ReadOnly = true;
            text4.FillWeight = 100;
            text4.DefaultCellStyle.Format = "00000-000";
            text4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            text4.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text4.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn text5 = new DataGridViewTextBoxColumn();
            text5.DataPropertyName = "Tipo";
            text5.HeaderText = "Tipo";
            text5.Width = 40;
            text5.Frozen = false;
            text5.MinimumWidth = 40;
            text5.ReadOnly = true;
            text5.FillWeight = 100;
            text5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            text5.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text5.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn text6 = new DataGridViewTextBoxColumn();
            text6.DataPropertyName = "Endereco";
            text6.HeaderText = "Endereco";
            text6.Width = 120;
            text6.Frozen = false;
            text6.MinimumWidth = 100;
            text6.ReadOnly = true;
            text6.FillWeight = 100;
            text6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            text6.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text6.Visible = true;
            ///7ª coluna
            DataGridViewTextBoxColumn text7 = new DataGridViewTextBoxColumn();
            text7.DataPropertyName = "Bairro";
            text7.HeaderText = "Bairro";
            text7.Width = 120;
            text7.Frozen = false;
            text7.MinimumWidth = 100;
            text7.ReadOnly = true;
            text7.FillWeight = 100;
            text7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            text7.Visible = true;
            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(text1);
            dataGrid.Columns.Add(text2);
            dataGrid.Columns.Add(text3);
            dataGrid.Columns.Add(text4);
            dataGrid.Columns.Add(text5);
            dataGrid.Columns.Add(text6);
            dataGrid.Columns.Add(text7);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Cidades
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta cidades, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridCidade(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("VisaoOrquestral"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.Name = "CodCidade";
                colCod.DataPropertyName = "CodCidade";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 55;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCid = new DataGridViewTextBoxColumn();
                colCid.Name = "Cidade";
                colCid.DataPropertyName = "Cidade";
                colCid.HeaderText = "Cidade";
                colCid.Width = 120;
                colCid.Frozen = false;
                colCid.MinimumWidth = 100;
                colCid.ReadOnly = true;
                colCid.FillWeight = 100;
                colCid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCid.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colCid.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colUf = new DataGridViewTextBoxColumn();
                colUf.Name = "Estado";
                colUf.DataPropertyName = "Estado";
                colUf.HeaderText = "Estado";
                colUf.Width = 50;
                colUf.Frozen = false;
                colUf.MinimumWidth = 50;
                colUf.ReadOnly = true;
                colUf.FillWeight = 100;
                colUf.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colUf.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colUf.Visible = false;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colCid);
                dataGrid.Columns.Add(colUf);
            }
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid CCB
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta empresas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridCCB(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Status";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;

            DataGridViewTextBoxColumn colSituacao = new DataGridViewTextBoxColumn();
            colSituacao.DataPropertyName = "Situacao";
            colSituacao.HeaderText = "Situação";
            colSituacao.Name = "Situacao";
            colSituacao.Width = 50;
            colSituacao.Frozen = false;
            colSituacao.MinimumWidth = 45;
            colSituacao.ReadOnly = true;
            colSituacao.FillWeight = 100;
            colSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSituacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSituacao.MaxInputLength = 10;
            colSituacao.Visible = false;
            DataGridViewTextBoxColumn colCodCCB = new DataGridViewTextBoxColumn();
            colCodCCB.DataPropertyName = "CodCCB";
            colCodCCB.HeaderText = "Código";
            colCodCCB.Width = 60;
            colCodCCB.Frozen = false;
            colCodCCB.MinimumWidth = 55;
            colCodCCB.ReadOnly = true;
            colCodCCB.FillWeight = 100;
            colCodCCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodCCB.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.DataPropertyName = "Codigo";
            colCodigo.HeaderText = "Identificador";
            colCodigo.Width = 90;
            colCodigo.Frozen = false;
            colCodigo.MinimumWidth = 80;
            colCodigo.ReadOnly = true;
            colCodigo.FillWeight = 100;
            colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodigo.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "Descricao";
            colDesc.HeaderText = "Descrição";
            colDesc.Width = 200;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 180;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDesc.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colCnpj = new DataGridViewTextBoxColumn();
            colCnpj.DataPropertyName = "Cnpj";
            colCnpj.HeaderText = "C.N.P.J.";
            colCnpj.Width = 140;
            colCnpj.Frozen = false;
            colCnpj.MinimumWidth = 110;
            colCnpj.ReadOnly = true;
            colCnpj.FillWeight = 100;
            colCnpj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCnpj.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCnpj.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colCidade = new DataGridViewTextBoxColumn();
            colCidade.DataPropertyName = "Cidade";
            colCidade.HeaderText = "Cidade";
            colCidade.Width = 80;
            colCidade.Frozen = false;
            colCidade.MinimumWidth = 70;
            colCidade.ReadOnly = true;
            colCidade.FillWeight = 100;
            colCidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCidade.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
            colEstado.DataPropertyName = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.Width = 50;
            colEstado.Frozen = false;
            colEstado.MinimumWidth = 70;
            colEstado.ReadOnly = true;
            colEstado.FillWeight = 100;
            colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEstado.Visible = true;
            ///7ª coluna
            DataGridViewTextBoxColumn colCep = new DataGridViewTextBoxColumn();
            colCep.DataPropertyName = "Cep";
            colCep.HeaderText = "Cep";
            colCep.Width = 80;
            colCep.Frozen = false;
            colCep.MinimumWidth = 70;
            colCep.ReadOnly = true;
            colCep.FillWeight = 100;
            colCep.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCep.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCep.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colSituacao);
            dataGrid.Columns.Add(colCodCCB);
            dataGrid.Columns.Add(colCodigo);
            dataGrid.Columns.Add(colDesc);
            dataGrid.Columns.Add(colCnpj);
            dataGrid.Columns.Add(colCidade);
            dataGrid.Columns.Add(colEstado);
            dataGrid.Columns.Add(colCep);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid CCB
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta empresas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///<para>Parametros Tabela:</para>
        ///<para> - Tabela: CCBPessoa, CCBParametro, UsuarioCCB, VisaoOrquestral, Relatorios</para>
        ///</summary>
        public static void gridCCB(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("PesquisaCCB"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodCCB = new DataGridViewTextBoxColumn();
                colCodCCB.DataPropertyName = "CodCCB";
                colCodCCB.Name = "CodCCB";
                colCodCCB.HeaderText = "Código";
                colCodCCB.Width = 60;
                colCodCCB.Frozen = false;
                colCodCCB.MinimumWidth = 55;
                colCodCCB.ReadOnly = true;
                colCodCCB.FillWeight = 100;
                colCodCCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCCB.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.Name = "Codigo";
                colCodigo.HeaderText = "Identificador";
                colCodigo.Width = 90;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 80;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.DataPropertyName = "Descricao";
                colDesc.Name = "Descricao";
                colDesc.HeaderText = "Descrição";
                colDesc.Width = 200;
                colDesc.Frozen = false;
                colDesc.MinimumWidth = 180;
                colDesc.ReadOnly = true;
                colDesc.FillWeight = 100;
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDesc.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colCnpj = new DataGridViewTextBoxColumn();
                colCnpj.DataPropertyName = "Cnpj";
                colCnpj.Name = "Cnpj";
                colCnpj.HeaderText = "C.N.P.J.";
                colCnpj.Width = 140;
                colCnpj.Frozen = false;
                colCnpj.MinimumWidth = 110;
                colCnpj.ReadOnly = true;
                colCnpj.FillWeight = 100;
                colCnpj.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCnpj.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCnpj.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colCidade = new DataGridViewTextBoxColumn();
                colCidade.DataPropertyName = "Cidade";
                colCidade.Name = "Cidade";
                colCidade.HeaderText = "Cidade";
                colCidade.Width = 100;
                colCidade.Frozen = false;
                colCidade.MinimumWidth = 70;
                colCidade.ReadOnly = true;
                colCidade.FillWeight = 100;
                colCidade.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCidade.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
                colEstado.DataPropertyName = "Estado";
                colEstado.Name = "Estado";
                colEstado.HeaderText = "Estado";
                colEstado.Width = 50;
                colEstado.Frozen = false;
                colEstado.MinimumWidth = 50;
                colEstado.ReadOnly = true;
                colEstado.FillWeight = 100;
                colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEstado.Visible = true;
                ///7ª coluna
                DataGridViewTextBoxColumn colCep = new DataGridViewTextBoxColumn();
                colCep.DataPropertyName = "Cep";
                colCep.Name = "Cep";
                colCep.HeaderText = "Cep";
                colCep.Width = 80;
                colCep.Frozen = false;
                colCep.MinimumWidth = 70;
                colCep.ReadOnly = true;
                colCep.FillWeight = 100;
                colCep.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCep.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCep.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCodCCB);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDesc);
                dataGrid.Columns.Add(colCidade);
                dataGrid.Columns.Add(colEstado);
                dataGrid.Columns.Add(colCep);
                dataGrid.Columns.Add(colCnpj);
            }
            else if (Tabela.Equals("CCBPessoa"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCCBPes = new DataGridViewTextBoxColumn();
                colCCBPes.DataPropertyName = "CodCCBPessoa";
                colCCBPes.HeaderText = "CodCCBPessoa";
                colCCBPes.Name = "CodCCBPessoa";
                colCCBPes.Width = 100;
                colCCBPes.Frozen = false;
                colCCBPes.MinimumWidth = 100;
                colCCBPes.ReadOnly = true;
                colCCBPes.FillWeight = 100;
                colCCBPes.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCCBPes.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCBPes.MaxInputLength = 20;
                colCCBPes.Visible = false;
                DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
                colCCB.DataPropertyName = "CodCCB";
                colCCB.HeaderText = "Código";
                colCCB.Name = "CodCCB";
                colCCB.Width = 60;
                colCCB.Frozen = false;
                colCCB.MinimumWidth = 55;
                colCCB.ReadOnly = true;
                colCCB.FillWeight = 100;
                colCCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCB.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.HeaderText = "Identificação";
                colCodigo.Name = "Codigo";
                colCodigo.Width = 90;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 70;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.MaxInputLength = 20;
                colCodigo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Descricao";
                colDescricao.HeaderText = "Descrição";
                colDescricao.Name = "Descricao";
                colDescricao.Width = 250;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 250;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 20;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = false;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCCBPes);
                dataGrid.Columns.Add(colCCB);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
            }
            else if (Tabela.Equals("CCBParametro"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCCBPar = new DataGridViewTextBoxColumn();
                colCCBPar.DataPropertyName = "CodCCBPessoa";
                colCCBPar.HeaderText = "CodCCBPessoa";
                colCCBPar.Name = "CodCCBPessoa";
                colCCBPar.Width = 100;
                colCCBPar.Frozen = false;
                colCCBPar.MinimumWidth = 100;
                colCCBPar.ReadOnly = true;
                colCCBPar.FillWeight = 100;
                colCCBPar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCCBPar.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCBPar.MaxInputLength = 20;
                colCCBPar.Visible = false;
                DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
                colCCB.DataPropertyName = "CodCCB";
                colCCB.HeaderText = "Código";
                colCCB.Name = "CodCCB";
                colCCB.Width = 60;
                colCCB.Frozen = false;
                colCCB.MinimumWidth = 55;
                colCCB.ReadOnly = true;
                colCCB.FillWeight = 100;
                colCCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCB.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.HeaderText = "Identificação";
                colCodigo.Name = "Codigo";
                colCodigo.Width = 100;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 250;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.MaxInputLength = 20;
                colCodigo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Descricao";
                colDescricao.HeaderText = "Descrição";
                colDescricao.Name = "Descricao";
                colDescricao.Width = 250;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 250;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 20;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCCBPar);
                dataGrid.Columns.Add(colCCB);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
            }
            else if (Tabela.Equals("UsuarioCCB"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCCBUsu = new DataGridViewTextBoxColumn();
                colCCBUsu.DataPropertyName = "CodUsuarioCCB";
                colCCBUsu.HeaderText = "CodUsuarioCCB";
                colCCBUsu.Name = "CodUsuarioCCB";
                colCCBUsu.Width = 100;
                colCCBUsu.Frozen = false;
                colCCBUsu.MinimumWidth = 100;
                colCCBUsu.ReadOnly = true;
                colCCBUsu.FillWeight = 100;
                colCCBUsu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCCBUsu.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCBUsu.MaxInputLength = 20;
                colCCBUsu.Visible = false;
                DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
                colCCB.DataPropertyName = "CodCCB";
                colCCB.HeaderText = "Código";
                colCCB.Name = "CodCCB";
                colCCB.Width = 50;
                colCCB.Frozen = false;
                colCCB.MinimumWidth = 40;
                colCCB.ReadOnly = true;
                colCCB.FillWeight = 100;
                colCCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCB.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.HeaderText = "Identif";
                colCodigo.Name = "Codigo";
                colCodigo.Width = 70;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 50;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.MaxInputLength = 20;
                colCodigo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Descricao";
                colDescricao.HeaderText = "Comum Congregação";
                colDescricao.Name = "Descricao";
                colDescricao.Width = 150;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 20;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCCBUsu);
                dataGrid.Columns.Add(colCCB);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
            }
            else if (Tabela.Equals("VisaoOrquestral"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
                colCCB.DataPropertyName = "CodCCB";
                colCCB.HeaderText = "Código";
                colCCB.Name = "CodCCB";
                colCCB.Width = 50;
                colCCB.Frozen = false;
                colCCB.MinimumWidth = 50;
                colCCB.ReadOnly = true;
                colCCB.FillWeight = 100;
                colCCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCB.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.HeaderText = "Identif";
                colCodigo.Name = "Codigo";
                colCodigo.Width = 60;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 60;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.MaxInputLength = 20;
                colCodigo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Descricao";
                colDescricao.HeaderText = "Comum Congregação";
                colDescricao.Name = "Descricao";
                colDescricao.Width = 250;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 20;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCCB);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
            }
            else if (Tabela.Equals("Relatorios"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
                colCCB.DataPropertyName = "CodCCB";
                colCCB.HeaderText = "Código";
                colCCB.Name = "CodCCB";
                colCCB.Width = 50;
                colCCB.Frozen = false;
                colCCB.MinimumWidth = 50;
                colCCB.ReadOnly = true;
                colCCB.FillWeight = 100;
                colCCB.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCB.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.HeaderText = "Ident";
                colCodigo.Name = "Codigo";
                colCodigo.Width = 40;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 40;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.MaxInputLength = 20;
                colCodigo.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Descricao";
                colDescricao.HeaderText = "Comum Congregação";
                colDescricao.Name = "Descricao";
                colDescricao.Width = 250;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 20;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCCB);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Departamento
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta departamentos, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridDepartamento(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn text0 = new DataGridViewTextBoxColumn();
            text0.DataPropertyName = "CodDepartamento";
            text0.HeaderText = "Código";
            text0.Width = 50;
            text0.Frozen = false;
            text0.MinimumWidth = 45;
            text0.ReadOnly = true;
            text0.FillWeight = 100;
            text0.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            text0.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn text1 = new DataGridViewTextBoxColumn();
            text1.DataPropertyName = "DescDepartamento";
            text1.HeaderText = "Descrição";
            text1.Width = 150;
            text1.Frozen = false;
            text1.MinimumWidth = 120;
            text1.ReadOnly = true;
            text1.FillWeight = 100;
            text1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            text1.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(text0);
            dataGrid.Columns.Add(text1);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Modulos
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta modulos, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridModulo(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn text0 = new DataGridViewTextBoxColumn();
            text0.DataPropertyName = "CodModulo";
            text0.HeaderText = "Código";
            text0.Width = 50;
            text0.Frozen = false;
            text0.MinimumWidth = 45;
            text0.ReadOnly = true;
            text0.FillWeight = 100;
            text0.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            text0.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn text1 = new DataGridViewTextBoxColumn();
            text1.DataPropertyName = "NivelMod";
            text1.HeaderText = "Nível";
            text1.Width = 50;
            text1.Frozen = false;
            text1.MinimumWidth = 45;
            text1.ReadOnly = true;
            text1.FillWeight = 100;
            text1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            text1.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn text2 = new DataGridViewTextBoxColumn();
            text2.DataPropertyName = "DescModulo";
            text2.HeaderText = "Descrição";
            text2.Width = 135;
            text2.Frozen = false;
            text2.MinimumWidth = 120;
            text2.ReadOnly = true;
            text2.FillWeight = 100;
            text2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            text2.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(text0);
            dataGrid.Columns.Add(text1);
            dataGrid.Columns.Add(text2);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid SubMódulos
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta submodulos, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridSubModulo(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn text0 = new DataGridViewTextBoxColumn();
            text0.DataPropertyName = "CodSubModulo";
            text0.HeaderText = "Código";
            text0.Width = 50;
            text0.Frozen = false;
            text0.MinimumWidth = 45;
            text0.ReadOnly = true;
            text0.FillWeight = 100;
            text0.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            text0.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn text1 = new DataGridViewTextBoxColumn();
            text1.DataPropertyName = "NivelSub";
            text1.HeaderText = "Nível";
            text1.Width = 50;
            text1.Frozen = false;
            text1.MinimumWidth = 45;
            text1.ReadOnly = true;
            text1.FillWeight = 100;
            text1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            text1.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn text2 = new DataGridViewTextBoxColumn();
            text2.DataPropertyName = "DescSubModulo";
            text2.HeaderText = "Descrição";
            text2.Width = 135;
            text2.Frozen = false;
            text2.MinimumWidth = 120;
            text2.ReadOnly = true;
            text2.FillWeight = 100;
            text2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            text2.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(text0);
            dataGrid.Columns.Add(text1);
            dataGrid.Columns.Add(text2);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Programas
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta programas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridPrograma(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn text0 = new DataGridViewTextBoxColumn();
            text0.DataPropertyName = "CodPrograma";
            text0.HeaderText = "Código";
            text0.Width = 50;
            text0.Frozen = false;
            text0.MinimumWidth = 45;
            text0.ReadOnly = true;
            text0.FillWeight = 100;
            text0.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            text0.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn text1 = new DataGridViewTextBoxColumn();
            text1.DataPropertyName = "NivelProg";
            text1.HeaderText = "Nível";
            text1.Width = 50;
            text1.Frozen = false;
            text1.MinimumWidth = 45;
            text1.ReadOnly = true;
            text1.FillWeight = 100;
            text1.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            text1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            text1.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn text2 = new DataGridViewTextBoxColumn();
            text2.DataPropertyName = "DescPrograma";
            text2.HeaderText = "Descrição";
            text2.Width = 135;
            text2.Frozen = false;
            text2.MinimumWidth = 120;
            text2.ReadOnly = true;
            text2.FillWeight = 100;
            text2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            text2.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(text0);
            dataGrid.Columns.Add(text1);
            dataGrid.Columns.Add(text2);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Rotinas
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta rotinas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridRotina(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodRotina";
            colCod.HeaderText = "Código";
            colCod.Width = 50;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colRot = new DataGridViewTextBoxColumn();
            colRot.DataPropertyName = "DescRotina";
            colRot.HeaderText = "Descrição da Rotina";
            colRot.Width = 130;
            colRot.Frozen = false;
            colRot.MinimumWidth = 120;
            colRot.ReadOnly = true;
            colRot.FillWeight = 100;
            colRot.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colRot.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRot.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDescSeg = new DataGridViewTextBoxColumn();
            colDescSeg.DataPropertyName = "DescSeg";
            colDescSeg.HeaderText = "Nível Segurança";
            colDescSeg.Width = 100;
            colDescSeg.Frozen = false;
            colDescSeg.MinimumWidth = 90;
            colDescSeg.ReadOnly = true;
            colDescSeg.FillWeight = 100;
            colDescSeg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDescSeg.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colMod = new DataGridViewTextBoxColumn();
            colMod.DataPropertyName = "DescModulo";
            colMod.HeaderText = "Módulo";
            colMod.Width = 100;
            colMod.Frozen = false;
            colMod.MinimumWidth = 90;
            colMod.ReadOnly = true;
            colMod.FillWeight = 100;
            colMod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colMod.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colSubMod = new DataGridViewTextBoxColumn();
            colSubMod.DataPropertyName = "DescSubModulo";
            colSubMod.HeaderText = "Sub-Módulo";
            colSubMod.Width = 100;
            colSubMod.Frozen = false;
            colSubMod.MinimumWidth = 90;
            colSubMod.ReadOnly = true;
            colSubMod.FillWeight = 100;
            colSubMod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSubMod.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colProg = new DataGridViewTextBoxColumn();
            colProg.DataPropertyName = "DescPrograma";
            colProg.HeaderText = "Programa";
            colProg.Width = 100;
            colProg.Frozen = false;
            colProg.MinimumWidth = 90;
            colProg.ReadOnly = true;
            colProg.FillWeight = 100;
            colProg.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colProg.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colRot);
            dataGrid.Columns.Add(colDescSeg);
            dataGrid.Columns.Add(colMod);
            dataGrid.Columns.Add(colSubMod);
            dataGrid.Columns.Add(colProg);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Região de Atuação
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta regiaoAtuacao, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridRegiao(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCodRegiao = new DataGridViewTextBoxColumn();
            colCodRegiao.DataPropertyName = "CodRegiao";
            colCodRegiao.HeaderText = "Código";
            colCodRegiao.Width = 60;
            colCodRegiao.Frozen = false;
            colCodRegiao.MinimumWidth = 50;
            colCodRegiao.ReadOnly = true;
            colCodRegiao.FillWeight = 100;
            colCodRegiao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodRegiao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodRegiao.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodigoRegiao = new DataGridViewTextBoxColumn();
            colCodigoRegiao.DataPropertyName = "Codigo";
            colCodigoRegiao.HeaderText = "Identificação";
            colCodigoRegiao.Width = 100;
            colCodigoRegiao.Frozen = false;
            colCodigoRegiao.MinimumWidth = 70;
            colCodigoRegiao.ReadOnly = true;
            colCodigoRegiao.FillWeight = 100;
            colCodigoRegiao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodigoRegiao.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
            colDescricao.DataPropertyName = "DescRegiao";
            colDescricao.Name = "Descricao";
            colDescricao.HeaderText = "Descrição";
            colDescricao.Width = 200;
            colDescricao.Frozen = false;
            colDescricao.MinimumWidth = 120;
            colDescricao.ReadOnly = true;
            colDescricao.FillWeight = 100;
            colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDescricao.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDescRegional = new DataGridViewTextBoxColumn();
            colDescRegional.DataPropertyName = "DescricaoRegional";
            colDescRegional.HeaderText = "Regional";
            colDescRegional.Width = 100;
            colDescRegional.Frozen = false;
            colDescRegional.MinimumWidth = 80;
            colDescRegional.ReadOnly = true;
            colDescRegional.FillWeight = 100;
            colDescRegional.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescRegional.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCodRegiao);
            dataGrid.Columns.Add(colCodigoRegiao);
            dataGrid.Columns.Add(colDescricao);
            dataGrid.Columns.Add(colDescRegional);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Região de Atuação
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta regiaoAtuacao, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///<para>Parametros Tabela:</para>
        ///<para> - Tabela: VisaoOrquestral, Relatorios</para>
        ///</summary>
        public static void gridRegiao(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("VisaoOrquestral"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodRegiao = new DataGridViewTextBoxColumn();
                colCodRegiao.DataPropertyName = "CodRegiao";
                colCodRegiao.Name = "CodRegiao";
                colCodRegiao.HeaderText = "Código";
                colCodRegiao.Width = 60;
                colCodRegiao.Frozen = false;
                colCodRegiao.MinimumWidth = 50;
                colCodRegiao.ReadOnly = true;
                colCodRegiao.FillWeight = 100;
                colCodRegiao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodRegiao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodRegiao.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigoRegiao = new DataGridViewTextBoxColumn();
                colCodigoRegiao.DataPropertyName = "Codigo";
                colCodigoRegiao.Name = "Codigo";
                colCodigoRegiao.HeaderText = "Identif";
                colCodigoRegiao.Width = 60;
                colCodigoRegiao.Frozen = false;
                colCodigoRegiao.MinimumWidth = 60;
                colCodigoRegiao.ReadOnly = true;
                colCodigoRegiao.FillWeight = 100;
                colCodigoRegiao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigoRegiao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescRegiao";
                colDescricao.Name = "Descricao";
                colDescricao.HeaderText = "Microrregião";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescRegional = new DataGridViewTextBoxColumn();
                colDescRegional.DataPropertyName = "DescricaoRegional";
                colDescRegional.Name = "DescricaoRegional";
                colDescRegional.HeaderText = "Regional";
                colDescRegional.Width = 100;
                colDescRegional.Frozen = false;
                colDescRegional.MinimumWidth = 80;
                colDescRegional.ReadOnly = true;
                colDescRegional.FillWeight = 100;
                colDescRegional.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescRegional.Visible = false;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodRegiao);
                dataGrid.Columns.Add(colCodigoRegiao);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colDescRegional);
            }
            else if (Tabela.Equals("Relatorios"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodRegiao = new DataGridViewTextBoxColumn();
                colCodRegiao.DataPropertyName = "CodRegiao";
                colCodRegiao.Name = "CodRegiao";
                colCodRegiao.HeaderText = "Código";
                colCodRegiao.Width = 60;
                colCodRegiao.Frozen = false;
                colCodRegiao.MinimumWidth = 50;
                colCodRegiao.ReadOnly = true;
                colCodRegiao.FillWeight = 100;
                colCodRegiao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodRegiao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodRegiao.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigoRegiao = new DataGridViewTextBoxColumn();
                colCodigoRegiao.DataPropertyName = "CodigoRegiao";
                colCodigoRegiao.Name = "Codigo";
                colCodigoRegiao.HeaderText = "Ident";
                colCodigoRegiao.Width = 40;
                colCodigoRegiao.Frozen = false;
                colCodigoRegiao.MinimumWidth = 40;
                colCodigoRegiao.ReadOnly = true;
                colCodigoRegiao.FillWeight = 100;
                colCodigoRegiao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigoRegiao.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescRegiao";
                colDescricao.Name = "Descricao";
                colDescricao.HeaderText = "Microrregião";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescRegional = new DataGridViewTextBoxColumn();
                colDescRegional.DataPropertyName = "DescRegional";
                colDescRegional.Name = "DescRegional";
                colDescRegional.HeaderText = "Regional";
                colDescRegional.Width = 100;
                colDescRegional.Frozen = false;
                colDescRegional.MinimumWidth = 80;
                colDescRegional.ReadOnly = true;
                colDescRegional.FillWeight = 100;
                colDescRegional.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescRegional.Visible = false;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodRegiao);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colCodigoRegiao);
                dataGrid.Columns.Add(colDescRegional);
            }
            else if (Tabela.Equals("UsuarioRegiao"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colRegUsu = new DataGridViewTextBoxColumn();
                colRegUsu.DataPropertyName = "CodUsuarioRegiao";
                colRegUsu.HeaderText = "CodUsuarioRegiao";
                colRegUsu.Name = "CodUsuarioRegiao";
                colRegUsu.Width = 100;
                colRegUsu.Frozen = false;
                colRegUsu.MinimumWidth = 100;
                colRegUsu.ReadOnly = true;
                colRegUsu.FillWeight = 100;
                colRegUsu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colRegUsu.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colRegUsu.MaxInputLength = 20;
                colRegUsu.Visible = false;
                DataGridViewTextBoxColumn colReg = new DataGridViewTextBoxColumn();
                colReg.DataPropertyName = "CodRegiao";
                colReg.HeaderText = "Código";
                colReg.Name = "CodRegiao";
                colReg.Width = 50;
                colReg.Frozen = false;
                colReg.MinimumWidth = 40;
                colReg.ReadOnly = true;
                colReg.FillWeight = 100;
                colReg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colReg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colReg.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.HeaderText = "CodigoRegiao";
                colCodigo.Name = "CodigoRegiao";
                colCodigo.Width = 70;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 50;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.MaxInputLength = 20;
                colCodigo.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescRegiao";
                colDescricao.HeaderText = "Microrregião";
                colDescricao.Name = "DescRegiao";
                colDescricao.Width = 150;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 20;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colRegUsu);
                dataGrid.Columns.Add(colReg);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
            }
            else if (Tabela.Equals("RegiaoPessoa"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colRegUsu = new DataGridViewTextBoxColumn();
                colRegUsu.DataPropertyName = "CodRegiaoPessoa";
                colRegUsu.HeaderText = "CodRegiaoPessoa";
                colRegUsu.Name = "CodRegiaoPessoa";
                colRegUsu.Width = 100;
                colRegUsu.Frozen = false;
                colRegUsu.MinimumWidth = 100;
                colRegUsu.ReadOnly = true;
                colRegUsu.FillWeight = 100;
                colRegUsu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colRegUsu.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colRegUsu.MaxInputLength = 20;
                colRegUsu.Visible = false;
                DataGridViewTextBoxColumn colReg = new DataGridViewTextBoxColumn();
                colReg.DataPropertyName = "CodRegiao";
                colReg.HeaderText = "Código";
                colReg.Name = "CodRegiao";
                colReg.Width = 50;
                colReg.Frozen = false;
                colReg.MinimumWidth = 40;
                colReg.ReadOnly = true;
                colReg.FillWeight = 100;
                colReg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colReg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colReg.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.HeaderText = "CodigoRegiao";
                colCodigo.Name = "CodigoRegiao";
                colCodigo.Width = 70;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 50;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.MaxInputLength = 20;
                colCodigo.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescRegiao";
                colDescricao.HeaderText = "Microrregião";
                colDescricao.Name = "DescRegiao";
                colDescricao.Width = 150;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 20;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = false;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colRegUsu);
                dataGrid.Columns.Add(colReg);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Regional
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta regional, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridRegional(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCodRegional = new DataGridViewTextBoxColumn();
            colCodRegional.DataPropertyName = "CodRegional";
            colCodRegional.Name = "CodRegional";
            colCodRegional.HeaderText = "Código";
            colCodRegional.Width = 50;
            colCodRegional.Frozen = false;
            colCodRegional.MinimumWidth = 50;
            colCodRegional.ReadOnly = true;
            colCodRegional.FillWeight = 100;
            colCodRegional.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodRegional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodRegional.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.DataPropertyName = "Codigo";
            colCodigo.Name = "Codigo";
            colCodigo.HeaderText = "Identificação";
            colCodigo.Width = 100;
            colCodigo.Frozen = false;
            colCodigo.MinimumWidth = 60;
            colCodigo.ReadOnly = true;
            colCodigo.FillWeight = 100;
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodigo.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
            colDescricao.DataPropertyName = "Descricao";
            colDescricao.Name = "Descricao";
            colDescricao.HeaderText = "Regional";
            colDescricao.Width = 200;
            colDescricao.Frozen = false;
            colDescricao.MinimumWidth = 100;
            colDescricao.ReadOnly = true;
            colDescricao.FillWeight = 100;
            colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescricao.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
            colEstado.DataPropertyName = "Estado";
            colEstado.Name = "Estado";
            colEstado.HeaderText = "UF";
            colEstado.Width = 35;
            colEstado.Frozen = false;
            colEstado.MinimumWidth = 35;
            colEstado.ReadOnly = true;
            colEstado.FillWeight = 100;
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstado.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCodRegional);
            dataGrid.Columns.Add(colCodigo);
            dataGrid.Columns.Add(colEstado);
            dataGrid.Columns.Add(colDescricao);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Regional
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta regional, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridRegional(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;
            if (Tabela.Equals("VisaoOrquestral"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodRegional = new DataGridViewTextBoxColumn();
                colCodRegional.DataPropertyName = "CodRegional";
                colCodRegional.Name = "CodRegional";
                colCodRegional.HeaderText = "Código";
                colCodRegional.Width = 50;
                colCodRegional.Frozen = false;
                colCodRegional.MinimumWidth = 50;
                colCodRegional.ReadOnly = true;
                colCodRegional.FillWeight = 100;
                colCodRegional.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodRegional.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodRegional.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
                colCodigo.DataPropertyName = "Codigo";
                colCodigo.Name = "Codigo";
                colCodigo.HeaderText = "Identif";
                colCodigo.Width = 60;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 60;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Descricao";
                colDescricao.Name = "Descricao";
                colDescricao.HeaderText = "Regional";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 100;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
                colEstado.DataPropertyName = "Estado";
                colEstado.Name = "Estado";
                colEstado.HeaderText = "UF";
                colEstado.Width = 35;
                colEstado.Frozen = false;
                colEstado.MinimumWidth = 35;
                colEstado.ReadOnly = true;
                colEstado.FillWeight = 100;
                colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colEstado.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCodRegional);
                dataGrid.Columns.Add(colCodigo);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colEstado);
            }
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Cargo
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Cargo, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///<para>Parametros Tabela:</para>
        ///<para> - Tabela: UsuarioCargo, Relatorios</para>
        ///</summary>
        public static void gridCargo(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("UsuarioCargo"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodUsuCargo = new DataGridViewTextBoxColumn();
                colCodUsuCargo.DataPropertyName = "CodUsuarioCargo";
                colCodUsuCargo.HeaderText = "CodUsuarioCargo";
                colCodUsuCargo.Name = "CodUsuarioCargo";
                colCodUsuCargo.Width = 100;
                colCodUsuCargo.Frozen = false;
                colCodUsuCargo.MinimumWidth = 100;
                colCodUsuCargo.ReadOnly = true;
                colCodUsuCargo.FillWeight = 100;
                colCodUsuCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodUsuCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodUsuCargo.MaxInputLength = 20;
                colCodUsuCargo.Visible = false;
                DataGridViewTextBoxColumn colCodCargo = new DataGridViewTextBoxColumn();
                colCodCargo.DataPropertyName = "CodCargo";
                colCodCargo.HeaderText = "Código";
                colCodCargo.Name = "CodCargo";
                colCodCargo.Width = 50;
                colCodCargo.Frozen = false;
                colCodCargo.MinimumWidth = 40;
                colCodCargo.ReadOnly = true;
                colCodCargo.FillWeight = 100;
                colCodCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCargo.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.HeaderText = "Cargo";
                colDescricao.Name = "DescCargo";
                colDescricao.Width = 100;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 80;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colSigla = new DataGridViewTextBoxColumn();
                colSigla.DataPropertyName = "SiglaCargo";
                colSigla.HeaderText = "Identif";
                colSigla.Name = "SiglaCargo";
                colSigla.Width = 50;
                colSigla.Frozen = false;
                colSigla.MinimumWidth = 40;
                colSigla.ReadOnly = true;
                colSigla.FillWeight = 100;
                colSigla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colSigla.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSigla.MaxInputLength = 100;
                colSigla.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodUsuCargo);
                dataGrid.Columns.Add(colCodCargo);
                dataGrid.Columns.Add(colSigla);
                dataGrid.Columns.Add(colDescricao);
            }
            else if (Tabela.Equals("Relatorios"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodUsuCargo = new DataGridViewTextBoxColumn();
                colCodUsuCargo.DataPropertyName = "CodUsuarioCargo";
                colCodUsuCargo.HeaderText = "CodUsuarioCargo";
                colCodUsuCargo.Name = "CodUsuarioCargo";
                colCodUsuCargo.Width = 100;
                colCodUsuCargo.Frozen = false;
                colCodUsuCargo.MinimumWidth = 100;
                colCodUsuCargo.ReadOnly = true;
                colCodUsuCargo.FillWeight = 100;
                colCodUsuCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodUsuCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodUsuCargo.MaxInputLength = 20;
                colCodUsuCargo.Visible = false;
                DataGridViewTextBoxColumn colCodCargo = new DataGridViewTextBoxColumn();
                colCodCargo.DataPropertyName = "CodCargo";
                colCodCargo.HeaderText = "Código";
                colCodCargo.Name = "CodCargo";
                colCodCargo.Width = 50;
                colCodCargo.Frozen = false;
                colCodCargo.MinimumWidth = 40;
                colCodCargo.ReadOnly = true;
                colCodCargo.FillWeight = 100;
                colCodCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCargo.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.HeaderText = "Cargo";
                colDescricao.Name = "DescCargo";
                colDescricao.Width = 100;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 80;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colSigla = new DataGridViewTextBoxColumn();
                colSigla.DataPropertyName = "SiglaCargo";
                colSigla.HeaderText = "Ident";
                colSigla.Name = "SiglaCargo";
                colSigla.Width = 40;
                colSigla.Frozen = false;
                colSigla.MinimumWidth = 40;
                colSigla.ReadOnly = true;
                colSigla.FillWeight = 100;
                colSigla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colSigla.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSigla.MaxInputLength = 100;
                colSigla.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodUsuCargo);
                dataGrid.Columns.Add(colCodCargo);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colSigla);
            }
            else if (Tabela.Equals("TipoReuniaoCargo"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodReunCargo = new DataGridViewTextBoxColumn();
                colCodReunCargo.DataPropertyName = "CodCargoReuniao";
                colCodReunCargo.HeaderText = "CodCargoReuniao";
                colCodReunCargo.Name = "CodCargoReuniao";
                colCodReunCargo.Width = 100;
                colCodReunCargo.Frozen = false;
                colCodReunCargo.MinimumWidth = 100;
                colCodReunCargo.ReadOnly = true;
                colCodReunCargo.FillWeight = 100;
                colCodReunCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodReunCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodReunCargo.MaxInputLength = 20;
                colCodReunCargo.Visible = false;
                DataGridViewTextBoxColumn colCodCargo = new DataGridViewTextBoxColumn();
                colCodCargo.DataPropertyName = "CodCargo";
                colCodCargo.HeaderText = "Código";
                colCodCargo.Name = "CodCargo";
                colCodCargo.Width = 50;
                colCodCargo.Frozen = false;
                colCodCargo.MinimumWidth = 40;
                colCodCargo.ReadOnly = true;
                colCodCargo.FillWeight = 100;
                colCodCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCargo.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.HeaderText = "Cargo";
                colDescricao.Name = "DescCargo";
                colDescricao.Width = 100;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 80;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colSigla = new DataGridViewTextBoxColumn();
                colSigla.DataPropertyName = "SiglaCargo";
                colSigla.HeaderText = "Identif";
                colSigla.Name = "SiglaCargo";
                colSigla.Width = 50;
                colSigla.Frozen = false;
                colSigla.MinimumWidth = 40;
                colSigla.ReadOnly = true;
                colSigla.FillWeight = 100;
                colSigla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colSigla.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSigla.MaxInputLength = 100;
                colSigla.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodReunCargo);
                dataGrid.Columns.Add(colCodCargo);
                dataGrid.Columns.Add(colSigla);
                dataGrid.Columns.Add(colDescricao);
            }

            else
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodCargo = new DataGridViewTextBoxColumn();
                colCodCargo.DataPropertyName = "CodCargo";
                colCodCargo.HeaderText = "Código";
                colCodCargo.Width = 60;
                colCodCargo.Frozen = false;
                colCodCargo.MinimumWidth = 50;
                colCodCargo.ReadOnly = true;
                colCodCargo.FillWeight = 100;
                colCodCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodCargo.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colSigla = new DataGridViewTextBoxColumn();
                colSigla.DataPropertyName = "SiglaCargo";
                colSigla.HeaderText = "Sigla";
                colSigla.Width = 60;
                colSigla.Frozen = false;
                colSigla.MinimumWidth = 50;
                colSigla.ReadOnly = true;
                colSigla.FillWeight = 100;
                colCodCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colSigla.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSigla.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.HeaderText = "Ministério/Cargo";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDepart = new DataGridViewTextBoxColumn();
                colDepart.DataPropertyName = "DescDepartamento";
                colDepart.HeaderText = "Departamento";
                colDepart.Width = 100;
                colDepart.Frozen = false;
                colDepart.MinimumWidth = 80;
                colDepart.ReadOnly = true;
                colDepart.FillWeight = 100;
                colDepart.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDepart.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCodCargo);
                dataGrid.Columns.Add(colSigla);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colDepart);
            }
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Teoria
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Teoria, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridTeoria(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Status";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
            colAplica.DataPropertyName = "AplicaEm";
            colAplica.HeaderText = "Aplicação";
            colAplica.Name = "AplicaEm";
            colAplica.Width = 110;
            colAplica.Frozen = false;
            colAplica.MinimumWidth = 90;
            colAplica.ReadOnly = true;
            colAplica.FillWeight = 100;
            colAplica.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colAplica.MaxInputLength = 30;
            colAplica.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodTeoria = new DataGridViewTextBoxColumn();
            colCodTeoria.DataPropertyName = "CodTeoria";
            colCodTeoria.HeaderText = "Código";
            colCodTeoria.Width = 60;
            colCodTeoria.Frozen = false;
            colCodTeoria.MinimumWidth = 50;
            colCodTeoria.ReadOnly = true;
            colCodTeoria.FillWeight = 100;
            colCodTeoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodTeoria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodTeoria.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colNivel = new DataGridViewTextBoxColumn();
            colNivel.DataPropertyName = "Nivel";
            colNivel.HeaderText = "Nível";
            colNivel.Width = 100;
            colNivel.Frozen = false;
            colNivel.MinimumWidth = 70;
            colNivel.ReadOnly = true;
            colNivel.FillWeight = 100;
            colNivel.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNivel.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
            colDescricao.DataPropertyName = "DescTeoria";
            colDescricao.HeaderText = "Descrição";
            colDescricao.Width = 200;
            colDescricao.Frozen = false;
            colDescricao.MinimumWidth = 120;
            colDescricao.ReadOnly = true;
            colDescricao.FillWeight = 100;
            colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescricao.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "TipoCadastro";
            colTipo.HeaderText = "Tipo";
            colTipo.Width = 100;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 80;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colAplica);
            dataGrid.Columns.Add(colCodTeoria);
            dataGrid.Columns.Add(colNivel);
            dataGrid.Columns.Add(colDescricao);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Método
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Metodo, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridMetodo(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("Instrumento"))
            {

            }
            else
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
                colTipo.DataPropertyName = "Tipo";
                colTipo.HeaderText = "Tipo";
                colTipo.Name = "Tipo";
                colTipo.Width = 80;
                colTipo.Frozen = false;
                colTipo.MinimumWidth = 50;
                colTipo.ReadOnly = true;
                colTipo.FillWeight = 100;
                colTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTipo.MaxInputLength = 30;
                colTipo.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colCodMet = new DataGridViewTextBoxColumn();
                colCodMet.DataPropertyName = "CodMetodo";
                colCodMet.HeaderText = "Código";
                colCodMet.Width = 60;
                colCodMet.Frozen = false;
                colCodMet.MinimumWidth = 50;
                colCodMet.ReadOnly = true;
                colCodMet.FillWeight = 100;
                colCodMet.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodMet.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodMet.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescMetodo";
                colDescricao.HeaderText = "Descrição";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colComp = new DataGridViewTextBoxColumn();
                colComp.DataPropertyName = "Compositor";
                colComp.HeaderText = "Compositor";
                colComp.Width = 100;
                colComp.Frozen = false;
                colComp.MinimumWidth = 80;
                colComp.ReadOnly = true;
                colComp.FillWeight = 100;
                colComp.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colComp.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colTipo);
                dataGrid.Columns.Add(colCodMet);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colComp);
            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid ImportarPessoa
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta ImportarPessoa, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridImportaPessoa(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            ///1ª coluna
            DataGridViewTextBoxColumn colCodImp = new DataGridViewTextBoxColumn();
            colCodImp.DataPropertyName = "CodImportaPessoa";
            colCodImp.HeaderText = "CodImportaPessoa";
            colCodImp.Name = "CodImportaPessoa";
            colCodImp.Width = 100;
            colCodImp.Frozen = false;
            colCodImp.MinimumWidth = 100;
            colCodImp.ReadOnly = true;
            colCodImp.FillWeight = 100;
            colCodImp.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCodImp.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodImp.MaxInputLength = 20;
            colCodImp.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.DataPropertyName = "DataImporta";
            colData.HeaderText = "Data";
            colData.Name = "DataImporta";
            colData.Width = 75;
            colData.Frozen = false;
            colData.MinimumWidth = 70;
            colData.ReadOnly = true;
            colData.FillWeight = 100;
            colData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colData.DefaultCellStyle.Format = "dd/MM/yyyy";
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colData.MaxInputLength = 10;
            colData.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colHora = new DataGridViewTextBoxColumn();
            colHora.DataPropertyName = "HoraImporta";
            colHora.HeaderText = "Hora";
            colHora.Name = "HoraImporta";
            colHora.Width = 40;
            colHora.Frozen = false;
            colHora.MinimumWidth = 35;
            colHora.ReadOnly = true;
            colHora.FillWeight = 100;
            colHora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHora.DefaultCellStyle.Format = "HH:mm";
            colHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHora.MaxInputLength = 10;
            colHora.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colUsu = new DataGridViewTextBoxColumn();
            colUsu.DataPropertyName = "Usuario";
            colUsu.HeaderText = "Usuário";
            colUsu.Name = "Usuario";
            colUsu.Width = 100;
            colUsu.Frozen = false;
            colUsu.MinimumWidth = 40;
            colUsu.ReadOnly = true;
            colUsu.FillWeight = 100;
            colUsu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colUsu.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colUsu.MaxInputLength = 100;
            colUsu.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colQtde = new DataGridViewTextBoxColumn();
            colQtde.DataPropertyName = "QtdeArquivo";
            colQtde.HeaderText = "Qtde Arquivos";
            colQtde.Name = "QtdeArquivo";
            colQtde.Width = 60;
            colQtde.Frozen = false;
            colQtde.MinimumWidth = 50;
            colQtde.ReadOnly = true;
            colQtde.FillWeight = 100;
            colQtde.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colQtde.DefaultCellStyle.Format = "000000";
            colQtde.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colQtde.MaxInputLength = 100;
            colQtde.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "Descricao";
            colDesc.HeaderText = "Descrição";
            colDesc.Name = "Descricao";
            colDesc.Width = 100;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 40;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.MaxInputLength = 100;
            colDesc.Visible = true;
            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCodImp);
            dataGrid.Columns.Add(colData);
            dataGrid.Columns.Add(colHora);
            dataGrid.Columns.Add(colDesc);
            dataGrid.Columns.Add(colQtde);
            dataGrid.Columns.Add(colUsu);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Versao
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Versao, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridVersao(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCodVersao = new DataGridViewTextBoxColumn();
            colCodVersao.DataPropertyName = "CodVersao";
            colCodVersao.Name = "CodVersao";
            colCodVersao.HeaderText = "Código";
            colCodVersao.Width = 50;
            colCodVersao.Frozen = false;
            colCodVersao.MinimumWidth = 50;
            colCodVersao.ReadOnly = true;
            colCodVersao.FillWeight = 100;
            colCodVersao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodVersao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodVersao.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colPrinc = new DataGridViewTextBoxColumn();
            colPrinc.DataPropertyName = "VersaoPrincipal";
            colPrinc.Name = "VersaoPrincipal";
            colPrinc.HeaderText = "V. Principal";
            colPrinc.Width = 100;
            colPrinc.Frozen = false;
            colPrinc.MinimumWidth = 60;
            colPrinc.ReadOnly = true;
            colPrinc.FillWeight = 100;
            colPrinc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colPrinc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPrinc.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colSec = new DataGridViewTextBoxColumn();
            colSec.DataPropertyName = "VersaoSecundaria";
            colSec.Name = "VersaoSecundaria";
            colSec.HeaderText = "V. Secundária";
            colSec.Width = 100;
            colSec.Frozen = false;
            colSec.MinimumWidth = 60;
            colSec.ReadOnly = true;
            colSec.FillWeight = 100;
            colSec.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSec.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSec.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colNum = new DataGridViewTextBoxColumn();
            colNum.DataPropertyName = "NumeroVersao";
            colNum.Name = "NumeroVersao";
            colNum.HeaderText = "Nº Versão";
            colNum.Width = 100;
            colNum.Frozen = false;
            colNum.MinimumWidth = 60;
            colNum.ReadOnly = true;
            colNum.FillWeight = 100;
            colNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNum.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colRev = new DataGridViewTextBoxColumn();
            colRev.DataPropertyName = "Revisao";
            colRev.Name = "Revisao";
            colRev.HeaderText = "Revisão";
            colRev.Width = 100;
            colRev.Frozen = false;
            colRev.MinimumWidth = 60;
            colRev.ReadOnly = true;
            colRev.FillWeight = 100;
            colRev.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colRev.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colRev.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.DataPropertyName = "DataLancamento";
            colData.HeaderText = "Data";
            colData.Name = "DataLancamento";
            colData.Width = 75;
            colData.Frozen = false;
            colData.MinimumWidth = 70;
            colData.ReadOnly = true;
            colData.FillWeight = 100;
            colData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colData.DefaultCellStyle.Format = "dd/MM/yyyy";
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colData.MaxInputLength = 10;
            colData.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colHora = new DataGridViewTextBoxColumn();
            colHora.DataPropertyName = "HoraLancamento";
            colHora.HeaderText = "Hora";
            colHora.Name = "HoraLancamento";
            colHora.Width = 40;
            colHora.Frozen = false;
            colHora.MinimumWidth = 35;
            colHora.ReadOnly = true;
            colHora.FillWeight = 100;
            colHora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHora.DefaultCellStyle.Format = "HH:mm";
            colHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHora.MaxInputLength = 10;
            colHora.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "TipoAtualizacao";
            colTipo.Name = "TipoAtualizacao";
            colTipo.HeaderText = "Tipo";
            colTipo.Width = 100;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 60;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTipo.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colVersao = new DataGridViewTextBoxColumn();
            colVersao.DataPropertyName = "Versao";
            colVersao.Name = "Versao";
            colVersao.HeaderText = "Versão";
            colVersao.Width = 100;
            colVersao.Frozen = false;
            colVersao.MinimumWidth = 60;
            colVersao.ReadOnly = true;
            colVersao.FillWeight = 100;
            colVersao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colVersao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colVersao.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colTipo);
            dataGrid.Columns.Add(colCodVersao);
            dataGrid.Columns.Add(colVersao);
            dataGrid.Columns.Add(colData);
            dataGrid.Columns.Add(colHora);
            dataGrid.Columns.Add(colPrinc);
            dataGrid.Columns.Add(colSec);
            dataGrid.Columns.Add(colNum);
            dataGrid.Columns.Add(colRev);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid ExportarPessoa
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta ExportarPessoa, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridExportaPessoa(DataGridView dataGrid, string Tipo)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///1ª coluna
            DataGridViewTextBoxColumn colCodPessoa = new DataGridViewTextBoxColumn();
            colCodPessoa.DataPropertyName = "CodPessoa";
            colCodPessoa.Name = "CodPessoa";
            colCodPessoa.HeaderText = "Código";
            colCodPessoa.Width = 60;
            colCodPessoa.Frozen = false;
            colCodPessoa.MinimumWidth = 60;
            colCodPessoa.ReadOnly = true;
            colCodPessoa.FillWeight = 100;
            colCodPessoa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodPessoa.MaxInputLength = 10;
            colCodPessoa.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colNome = new DataGridViewTextBoxColumn();
            colNome.DataPropertyName = "Nome";
            colNome.Name = "Nome";
            colNome.HeaderText = "Nome";
            colNome.Width = 180;
            colNome.Frozen = false;
            colNome.MinimumWidth = 120;
            colNome.ReadOnly = true;
            colNome.FillWeight = 100;
            colNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNome.MaxInputLength = 200;
            colNome.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colCid = new DataGridViewTextBoxColumn();
            colCid.DataPropertyName = "CidadeRes";
            colCid.Name = "CidadeRes";
            colCid.HeaderText = "Cidade";
            colCid.Width = 100;
            colCid.Frozen = false;
            colCid.MinimumWidth = 80;
            colCid.ReadOnly = true;
            colCid.FillWeight = 100;
            colCid.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCid.MaxInputLength = 100;
            colCid.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colEnd = new DataGridViewTextBoxColumn();
            colEnd.DataPropertyName = "EndRes";
            colEnd.Name = "EndRes";
            colEnd.HeaderText = "Endereço";
            colEnd.Width = 180;
            colEnd.Frozen = false;
            colEnd.MinimumWidth = 120;
            colEnd.ReadOnly = true;
            colEnd.FillWeight = 100;
            colEnd.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEnd.MaxInputLength = 200;
            colEnd.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colNum = new DataGridViewTextBoxColumn();
            colNum.DataPropertyName = "NumRes";
            colNum.Name = "NumRes";
            colNum.HeaderText = "Número";
            colNum.Width = 50;
            colNum.Frozen = false;
            colNum.MinimumWidth = 40;
            colNum.ReadOnly = true;
            colNum.FillWeight = 100;
            colNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colNum.MaxInputLength = 20;
            colNum.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colBairro = new DataGridViewTextBoxColumn();
            colBairro.DataPropertyName = "BairroRes";
            colBairro.Name = "BairroRes";
            colBairro.HeaderText = "Bairro";
            colBairro.Width = 80;
            colBairro.Frozen = false;
            colBairro.MinimumWidth = 70;
            colBairro.ReadOnly = true;
            colBairro.FillWeight = 100;
            colBairro.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colBairro.MaxInputLength = 130;
            colBairro.Visible = true;
            ///7ª coluna
            DataGridViewTextBoxColumn colUf = new DataGridViewTextBoxColumn();
            colUf.DataPropertyName = "EstadoRes";
            colUf.Name = "EstadoRes";
            colUf.HeaderText = "Estado";
            colUf.Width = 50;
            colUf.Frozen = false;
            colUf.MinimumWidth = 40;
            colUf.ReadOnly = true;
            colUf.FillWeight = 100;
            colUf.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colUf.MaxInputLength = 20;
            colUf.Visible = true;
            ///8ª Coluna
            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.DataPropertyName = "Celular1";
            colTel.Name = "Celular1";
            colTel.HeaderText = "1º Celular";
            colTel.Width = 130;
            colTel.Frozen = false;
            colTel.MinimumWidth = 110;
            colTel.ReadOnly = true;
            colTel.FillWeight = 100;
            colTel.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTel.MaxInputLength = 30;
            colTel.Visible = true;
            ///9ª coluna
            DataGridViewTextBoxColumn colCargo = new DataGridViewTextBoxColumn();
            colCargo.DataPropertyName = "DescCargo";
            colCargo.Name = "DescCargo";
            colCargo.HeaderText = "Ministério";
            colCargo.Width = 105;
            colCargo.Frozen = false;
            colCargo.MinimumWidth = 100;
            colCargo.ReadOnly = true;
            colCargo.FillWeight = 100;
            colCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCargo.MaxInputLength = 100;
            colCargo.Visible = true;
            ///10ª coluna
            DataGridViewTextBoxColumn colCodComum = new DataGridViewTextBoxColumn();
            colCodComum.DataPropertyName = "CodigoCCB";
            colCodComum.Name = "CodigoCCB";
            colCodComum.HeaderText = "ID Comum";
            colCodComum.Width = 80;
            colCodComum.Frozen = false;
            colCodComum.MinimumWidth = 80;
            colCodComum.ReadOnly = true;
            colCodComum.FillWeight = 100;
            colCodComum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCodComum.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodComum.MaxInputLength = 10;
            colCodComum.Visible = true;
            ///11ª coluna
            DataGridViewTextBoxColumn colDescComum = new DataGridViewTextBoxColumn();
            colDescComum.DataPropertyName = "Descricao";
            colDescComum.Name = "Descricao";
            colDescComum.HeaderText = "Comum Congregação";
            colDescComum.Width = 150;
            colDescComum.Frozen = false;
            colDescComum.MinimumWidth = 120;
            colDescComum.ReadOnly = true;
            colDescComum.FillWeight = 100;
            colDescComum.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDescComum.MaxInputLength = 100;
            colDescComum.Visible = true;
            ///12ª coluna
            DataGridViewTextBoxColumn colInst = new DataGridViewTextBoxColumn();
            colInst.DataPropertyName = "DescInstrumento";
            colInst.Name = "DescInstrumento";
            colInst.HeaderText = "Instrumento";
            colInst.Width = 100;
            colInst.Frozen = false;
            colInst.MinimumWidth = 90;
            colInst.ReadOnly = true;
            colInst.FillWeight = 100;
            colInst.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colInst.MaxInputLength = 100;
            colInst.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colCpf = new DataGridViewTextBoxColumn();
            colCpf.DataPropertyName = "Cpf";
            colCpf.Name = "Cpf";
            colCpf.HeaderText = "C.P.F.";
            colCpf.Width = 120;
            colCpf.Frozen = false;
            colCpf.MinimumWidth = 80;
            colCpf.ReadOnly = true;
            colCpf.FillWeight = 100;
            colCpf.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCpf.MaxInputLength = 30;
            colCpf.Visible = true;
            ///11ª coluna
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.DataPropertyName = "Email";
            colEmail.Name = "Email";
            colEmail.HeaderText = "Email";
            colEmail.Width = 150;
            colEmail.Frozen = false;
            colEmail.MinimumWidth = 120;
            colEmail.ReadOnly = true;
            colEmail.FillWeight = 100;
            colEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEmail.MaxInputLength = 100;
            colEmail.Visible = true;

            if (Tipo.Equals("Basico"))
            {
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCargo);
                dataGrid.Columns.Add(colCodComum);
                dataGrid.Columns.Add(colDescComum);
                dataGrid.Columns.Add(colCodPessoa);
                dataGrid.Columns.Add(colNome);
                dataGrid.Columns.Add(colCid);
                dataGrid.Columns.Add(colUf);
                dataGrid.Columns.Add(colInst);
            }
            else if (Tipo.Equals("Completo"))
            {
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCargo);
                dataGrid.Columns.Add(colCodComum);
                dataGrid.Columns.Add(colDescComum);
                dataGrid.Columns.Add(colCodPessoa);
                dataGrid.Columns.Add(colNome);
                dataGrid.Columns.Add(colCpf);
                dataGrid.Columns.Add(colCid);
                dataGrid.Columns.Add(colUf);
                dataGrid.Columns.Add(colEnd);
                dataGrid.Columns.Add(colNum);
                dataGrid.Columns.Add(colBairro);
                dataGrid.Columns.Add(colTel);
                dataGrid.Columns.Add(colInst);
            }
            else
            {
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCargo);
                dataGrid.Columns.Add(colCodComum);
                dataGrid.Columns.Add(colDescComum);
                dataGrid.Columns.Add(colNome);
                dataGrid.Columns.Add(colCpf);
                dataGrid.Columns.Add(colCid);
                dataGrid.Columns.Add(colInst);
                dataGrid.Columns.Add(colEmail);
            }
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion

        #region funções que monta os datagridview da parte dos instrumentos

        ///<summary> Montar DataGrid Familia
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta departamentos, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridFamilia(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("Metodo"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colMetFam = new DataGridViewTextBoxColumn();
                colMetFam.DataPropertyName = "CodMetodoFamilia";
                colMetFam.HeaderText = "CodMetodoFamilia";
                colMetFam.Name = "CodMetodoFamilia";
                colMetFam.Width = 50;
                colMetFam.Frozen = false;
                colMetFam.MinimumWidth = 45;
                colMetFam.ReadOnly = true;
                colMetFam.FillWeight = 100;
                colMetFam.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMetFam.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colMetFam.Visible = false;
                ///iniciando pela 2ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodFamilia";
                colCod.HeaderText = "Código";
                colCod.Width = 50;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.DataPropertyName = "DescFamilia";
                colDesc.HeaderText = "Descrição";
                colDesc.Width = 150;
                colDesc.Frozen = false;
                colDesc.MinimumWidth = 120;
                colDesc.ReadOnly = true;
                colDesc.FillWeight = 100;
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDesc.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colMetFam);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colDesc);
            }
            else if (Tabela.Equals("VisaoOrquestral"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.Name = "CodFamilia";
                colCod.DataPropertyName = "CodFamilia";
                colCod.HeaderText = "Código";
                colCod.Width = 50;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = false;
                ///3ª coluna
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.Name = "DescFamilia";
                colDesc.DataPropertyName = "DescFamilia";
                colDesc.HeaderText = "Família";
                colDesc.Width = 150;
                colDesc.Frozen = false;
                colDesc.MinimumWidth = 120;
                colDesc.ReadOnly = true;
                colDesc.FillWeight = 100;
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDesc.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colDesc);
            }
            else
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodFamilia";
                colCod.HeaderText = "Código";
                colCod.Width = 50;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.DataPropertyName = "DescFamilia";
                colDesc.HeaderText = "Descrição";
                colDesc.Width = 150;
                colDesc.Frozen = false;
                colDesc.MinimumWidth = 120;
                colDesc.ReadOnly = true;
                colDesc.FillWeight = 100;
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDesc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colDesc);
            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Escala
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Escala, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridEscala(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodEscala";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "DescEscala";
            colDesc.HeaderText = "Descrição";
            colDesc.Width = 300;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 200;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colDesc);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Tonalidade
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Tonalidade, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridTonalidade(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("InstrumentoTom"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodTomInstr = new DataGridViewTextBoxColumn();
                colCodTomInstr.DataPropertyName = "CodInstrumentoTom";
                colCodTomInstr.HeaderText = "CodInstrumentoTom";
                colCodTomInstr.Name = "CodInstrumentoTom";
                colCodTomInstr.Width = 100;
                colCodTomInstr.Frozen = false;
                colCodTomInstr.MinimumWidth = 100;
                colCodTomInstr.ReadOnly = true;
                colCodTomInstr.FillWeight = 100;
                colCodTomInstr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodTomInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodTomInstr.MaxInputLength = 20;
                colCodTomInstr.Visible = false;
                DataGridViewTextBoxColumn colCodTonal = new DataGridViewTextBoxColumn();
                colCodTonal.DataPropertyName = "CodTonalidade";
                colCodTonal.HeaderText = "Código";
                colCodTonal.Name = "CodTonalidade";
                colCodTonal.Width = 40;
                colCodTonal.Frozen = false;
                colCodTonal.MinimumWidth = 40;
                colCodTonal.ReadOnly = true;
                colCodTonal.FillWeight = 100;
                colCodTonal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodTonal.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodTonal.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescTonalidade";
                colDescricao.HeaderText = "Tonalidade";
                colDescricao.Name = "DescTonalidade";
                colDescricao.Width = 150;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodTomInstr);
                dataGrid.Columns.Add(colCodTonal);
                dataGrid.Columns.Add(colDescricao);
            }
            else
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodTonalidade";
                colCod.HeaderText = "Código";
                colCod.Width = 50;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.DataPropertyName = "DescTonalidade";
                colDesc.HeaderText = "Descrição";
                colDesc.Width = 150;
                colDesc.Frozen = false;
                colDesc.MinimumWidth = 120;
                colDesc.ReadOnly = true;
                colDesc.FillWeight = 100;
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDesc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colDesc);
            }
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Hinário
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Hinário, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridHinario(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("InstrumentoHinario"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodTomInstr = new DataGridViewTextBoxColumn();
                colCodTomInstr.DataPropertyName = "CodInstrumentoHino";
                colCodTomInstr.HeaderText = "CodInstrumentoHino";
                colCodTomInstr.Name = "CodInstrumentoHino";
                colCodTomInstr.Width = 100;
                colCodTomInstr.Frozen = false;
                colCodTomInstr.MinimumWidth = 100;
                colCodTomInstr.ReadOnly = true;
                colCodTomInstr.FillWeight = 100;
                colCodTomInstr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodTomInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodTomInstr.MaxInputLength = 20;
                colCodTomInstr.Visible = false;
                DataGridViewTextBoxColumn colCodTonal = new DataGridViewTextBoxColumn();
                colCodTonal.DataPropertyName = "CodHinario";
                colCodTonal.HeaderText = "Código";
                colCodTonal.Name = "CodHinario";
                colCodTonal.Width = 40;
                colCodTonal.Frozen = false;
                colCodTonal.MinimumWidth = 40;
                colCodTonal.ReadOnly = true;
                colCodTonal.FillWeight = 100;
                colCodTonal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodTonal.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodTonal.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescHinario";
                colDescricao.HeaderText = "Hinário";
                colDescricao.Name = "DescHinario";
                colDescricao.Width = 150;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodTomInstr);
                dataGrid.Columns.Add(colCodTonal);
                dataGrid.Columns.Add(colDescricao);
            }
            else
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodHinario";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.DataPropertyName = "DescHinario";
                colDesc.HeaderText = "Descrição";
                colDesc.Width = 150;
                colDesc.Frozen = false;
                colDesc.MinimumWidth = 120;
                colDesc.ReadOnly = true;
                colDesc.FillWeight = 100;
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDesc.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colTonal = new DataGridViewTextBoxColumn();
                colTonal.DataPropertyName = "DescTonalidade";
                colTonal.HeaderText = "Tonalidade";
                colTonal.Width = 80;
                colTonal.Frozen = false;
                colTonal.MinimumWidth = 60;
                colTonal.ReadOnly = true;
                colTonal.FillWeight = 100;
                colTonal.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colTonal.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colDesc);
                dataGrid.Columns.Add(colTonal);
            }
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Vozes
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Vozes, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridVozes(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodVoz";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "DescVoz";
            colDesc.HeaderText = "Descrição";
            colDesc.Width = 200;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 120;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDesc.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colTes = new DataGridViewTextBoxColumn();
            colTes.DataPropertyName = "Tessitura";
            colTes.HeaderText = "Tessitura";
            colTes.Width = 100;
            colTes.Frozen = false;
            colTes.MinimumWidth = 80;
            colTes.ReadOnly = true;
            colTes.FillWeight = 100;
            colTes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTes.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colDesc);
            dataGrid.Columns.Add(colTes);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid Vozes
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Vozes, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridVozes(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("VisaoOrquestral"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.Name = "CodVoz";
                colCod.DataPropertyName = "CodVoz";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
                colDesc.Name = "DescVoz";
                colDesc.DataPropertyName = "DescVoz";
                colDesc.HeaderText = "Vozes";
                colDesc.Width = 200;
                colDesc.Frozen = false;
                colDesc.MinimumWidth = 120;
                colDesc.ReadOnly = true;
                colDesc.FillWeight = 100;
                colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDesc.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colDesc);
            }
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        ///<summary> Montar DataGrid UF
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta UF, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridUf(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colSigla = new DataGridViewTextBoxColumn();
            colSigla.DataPropertyName = "Sigla";
            colSigla.HeaderText = "Sigla";
            colSigla.Name = "Sigla";
            colSigla.Width = 50;
            colSigla.Frozen = false;
            colSigla.MinimumWidth = 50;
            colSigla.ReadOnly = true;
            colSigla.FillWeight = 100;
            colSigla.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSigla.Visible = true;
            ///2 coluna
            DataGridViewTextBoxColumn colUf = new DataGridViewTextBoxColumn();
            colUf.DataPropertyName = "Uf";
            colUf.HeaderText = "Estado";
            colUf.Name = "Estado";
            colUf.Width = 100;
            colUf.Frozen = false;
            colUf.MinimumWidth = 80;
            colUf.ReadOnly = true;
            colUf.FillWeight = 100;
            colUf.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colUf.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colSigla);
            dataGrid.Columns.Add(colUf);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        ///<summary> Montar DataGrid MtsFase
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta fase no mts, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridMtsFase(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodFaseMts";
            colCod.HeaderText = "Código";
            colCod.Width = 50;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "DescFase";
            colDesc.HeaderText = "Descrição";
            colDesc.Width = 150;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 120;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colDesc);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid MtsModulo
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta fase no MtsModulo, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridMtsModulo(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodModuloMts";
            colCod.HeaderText = "Código";
            colCod.Width = 50;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "DescModulo";
            colDesc.HeaderText = "Descrição";
            colDesc.Width = 200;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 120;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDesc.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colFase = new DataGridViewTextBoxColumn();
            colFase.DataPropertyName = "DescFase";
            colFase.HeaderText = "Fase";
            colFase.Width = 100;
            colFase.Frozen = false;
            colFase.MinimumWidth = 80;
            colFase.ReadOnly = true;
            colFase.FillWeight = 100;
            colFase.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFase.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colDesc);
            dataGrid.Columns.Add(colFase);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        ///<summary> Montar DataGrid Instrumentos
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta fase no mts, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///<para>Tabela: (PessoaInstr, Hinario, )</para>
        ///</summary>
        public static void gridInstrumentos(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("PessoaInstr"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodPesInstr = new DataGridViewTextBoxColumn();
                colCodPesInstr.DataPropertyName = "CodPessoaInstr";
                colCodPesInstr.HeaderText = "CodPessoaInstr";
                colCodPesInstr.Name = "CodPessoaInstr";
                colCodPesInstr.Width = 100;
                colCodPesInstr.Frozen = false;
                colCodPesInstr.MinimumWidth = 100;
                colCodPesInstr.ReadOnly = true;
                colCodPesInstr.FillWeight = 100;
                colCodPesInstr.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colCodPesInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodPesInstr.MaxInputLength = 20;
                colCodPesInstr.Visible = false;
                DataGridViewTextBoxColumn colCodInstrumento = new DataGridViewTextBoxColumn();
                colCodInstrumento.DataPropertyName = "CodInstrumento";
                colCodInstrumento.HeaderText = "Código";
                colCodInstrumento.Name = "CodInstrumento";
                colCodInstrumento.Width = 40;
                colCodInstrumento.Frozen = false;
                colCodInstrumento.MinimumWidth = 40;
                colCodInstrumento.ReadOnly = true;
                colCodInstrumento.FillWeight = 100;
                colCodInstrumento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodInstrumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrumento.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescInstrumento";
                colDescricao.HeaderText = "Instrumento";
                colDescricao.Name = "DescInstrumento";
                colDescricao.Width = 100;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 80;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colFamilia = new DataGridViewTextBoxColumn();
                colFamilia.DataPropertyName = "DescFamilia";
                colFamilia.HeaderText = "Família";
                colFamilia.Name = "DescFamilia";
                colFamilia.Width = 60;
                colFamilia.Frozen = false;
                colFamilia.MinimumWidth = 60;
                colFamilia.ReadOnly = true;
                colFamilia.FillWeight = 100;
                colFamilia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colFamilia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colFamilia.MaxInputLength = 100;
                colFamilia.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.DataPropertyName = "Marcado";
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodPesInstr);
                dataGrid.Columns.Add(colCodInstrumento);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colFamilia);
            }
            else if (Tabela.Equals("VisaoOrquestral"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodInstrumento = new DataGridViewTextBoxColumn();
                colCodInstrumento.DataPropertyName = "CodInstrumento";
                colCodInstrumento.HeaderText = "Código";
                colCodInstrumento.Name = "CodInstrumento";
                colCodInstrumento.Width = 40;
                colCodInstrumento.Frozen = false;
                colCodInstrumento.MinimumWidth = 40;
                colCodInstrumento.ReadOnly = true;
                colCodInstrumento.FillWeight = 100;
                colCodInstrumento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodInstrumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrumento.Visible = false;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescInstrumento";
                colDescricao.HeaderText = "Instrumento";
                colDescricao.Name = "DescInstrumento";
                colDescricao.Width = 100;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 80;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colFamilia = new DataGridViewTextBoxColumn();
                colFamilia.DataPropertyName = "DescFamilia";
                colFamilia.HeaderText = "Família";
                colFamilia.Name = "DescFamilia";
                colFamilia.Width = 50;
                colFamilia.Frozen = false;
                colFamilia.MinimumWidth = 50;
                colFamilia.ReadOnly = true;
                colFamilia.FillWeight = 100;
                colFamilia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colFamilia.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFamilia.MaxInputLength = 100;
                colFamilia.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colVoz = new DataGridViewTextBoxColumn();
                colVoz.DataPropertyName = "DescVoz";
                colVoz.HeaderText = "Voz";
                colVoz.Name = "DescVoz";
                colVoz.Width = 50;
                colVoz.Frozen = false;
                colVoz.MinimumWidth = 50;
                colVoz.ReadOnly = true;
                colVoz.FillWeight = 100;
                colVoz.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colVoz.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colVoz.MaxInputLength = 100;
                colVoz.Visible = true;
                ///4ª coluna
                DataGridViewCheckBoxColumn colMarc = new DataGridViewCheckBoxColumn();
                colMarc.HeaderText = "";
                colMarc.Name = "Marcado";
                colMarc.Width = 20;
                colMarc.Frozen = false;
                colMarc.MinimumWidth = 15;
                colMarc.ReadOnly = false;
                colMarc.FillWeight = 100;
                colMarc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMarc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMarc.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colMarc);
                dataGrid.Columns.Add(colCodInstrumento);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colFamilia);
                dataGrid.Columns.Add(colVoz);
            }
            else if (Tabela.Equals("Hinario"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodInstrumento = new DataGridViewTextBoxColumn();
                colCodInstrumento.DataPropertyName = "CodInstrumento";
                colCodInstrumento.HeaderText = "Código";
                colCodInstrumento.Name = "CodInstrumento";
                colCodInstrumento.Width = 55;
                colCodInstrumento.Frozen = false;
                colCodInstrumento.MinimumWidth = 55;
                colCodInstrumento.ReadOnly = true;
                colCodInstrumento.FillWeight = 100;
                colCodInstrumento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodInstrumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrumento.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescInstrumento";
                colDescricao.HeaderText = "Instrumento";
                colDescricao.Name = "DescInstrumento";
                colDescricao.Width = 190;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 150;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFamilia = new DataGridViewTextBoxColumn();
                colFamilia.DataPropertyName = "DescFamilia";
                colFamilia.HeaderText = "Família";
                colFamilia.Name = "DescFamilia";
                colFamilia.Width = 100;
                colFamilia.Frozen = false;
                colFamilia.MinimumWidth = 70;
                colFamilia.ReadOnly = true;
                colFamilia.FillWeight = 100;
                colFamilia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colFamilia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colFamilia.MaxInputLength = 100;
                colFamilia.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCodInstrumento);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colFamilia);
            }
            else if (Tabela.Equals("MetodoInstr"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                ///1ª coluna
                DataGridViewTextBoxColumn colCodInstrumento = new DataGridViewTextBoxColumn();
                colCodInstrumento.DataPropertyName = "CodInstrumento";
                colCodInstrumento.HeaderText = "Código";
                colCodInstrumento.Name = "CodInstrumento";
                colCodInstrumento.Width = 55;
                colCodInstrumento.Frozen = false;
                colCodInstrumento.MinimumWidth = 55;
                colCodInstrumento.ReadOnly = true;
                colCodInstrumento.FillWeight = 100;
                colCodInstrumento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodInstrumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrumento.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescInstrumento";
                colDescricao.HeaderText = "Instrumento";
                colDescricao.Name = "DescInstrumento";
                colDescricao.Width = 140;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 130;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFamilia = new DataGridViewTextBoxColumn();
                colFamilia.DataPropertyName = "DescFamilia";
                colFamilia.HeaderText = "Família";
                colFamilia.Name = "DescFamilia";
                colFamilia.Width = 90;
                colFamilia.Frozen = false;
                colFamilia.MinimumWidth = 70;
                colFamilia.ReadOnly = true;
                colFamilia.FillWeight = 100;
                colFamilia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colFamilia.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colFamilia.MaxInputLength = 100;
                colFamilia.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colCodFam = new DataGridViewTextBoxColumn();
                colCodFam.DataPropertyName = "CodFamilia";
                colCodFam.HeaderText = "CodFamilia";
                colCodFam.Name = "CodFamilia";
                colCodFam.Width = 90;
                colCodFam.Frozen = false;
                colCodFam.MinimumWidth = 70;
                colCodFam.ReadOnly = true;
                colCodFam.FillWeight = 100;
                colCodFam.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCodFam.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodFam.MaxInputLength = 100;
                colCodFam.Visible = false;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(colCodInstrumento);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colFamilia);
                dataGrid.Columns.Add(colCodFam);
            }
            else if (Tabela.Equals("Geral"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;
                ///1ª coluna
                DataGridViewTextBoxColumn colCodInstrumento = new DataGridViewTextBoxColumn();
                colCodInstrumento.DataPropertyName = "CodInstrumento";
                colCodInstrumento.HeaderText = "Código";
                colCodInstrumento.Name = "CodInstrumento";
                colCodInstrumento.Width = 55;
                colCodInstrumento.Frozen = false;
                colCodInstrumento.MinimumWidth = 55;
                colCodInstrumento.ReadOnly = true;
                colCodInstrumento.FillWeight = 100;
                colCodInstrumento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodInstrumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrumento.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescInstrumento";
                colDescricao.HeaderText = "Instrumento";
                colDescricao.Name = "DescInstrumento";
                colDescricao.Width = 250;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 180;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFamilia = new DataGridViewTextBoxColumn();
                colFamilia.DataPropertyName = "DescFamilia";
                colFamilia.HeaderText = "Família";
                colFamilia.Name = "DescFamilia";
                colFamilia.Width = 100;
                colFamilia.Frozen = false;
                colFamilia.MinimumWidth = 70;
                colFamilia.ReadOnly = true;
                colFamilia.FillWeight = 100;
                colFamilia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colFamilia.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFamilia.MaxInputLength = 100;
                colFamilia.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colSituacao = new DataGridViewTextBoxColumn();
                colSituacao.DataPropertyName = "Situacao";
                colSituacao.HeaderText = "Situação";
                colSituacao.Name = "Situacao";
                colSituacao.Width = 70;
                colSituacao.Frozen = false;
                colSituacao.MinimumWidth = 50;
                colSituacao.ReadOnly = true;
                colSituacao.FillWeight = 100;
                colSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colSituacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSituacao.MaxInputLength = 100;
                colSituacao.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colSituacao);
                dataGrid.Columns.Add(colCodInstrumento);
                dataGrid.Columns.Add(colFamilia);
                dataGrid.Columns.Add(colDescricao);
            }
            else
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;
                ///1ª coluna
                DataGridViewTextBoxColumn colCodInstrumento = new DataGridViewTextBoxColumn();
                colCodInstrumento.DataPropertyName = "CodInstrumento";
                colCodInstrumento.HeaderText = "Código";
                colCodInstrumento.Name = "CodInstrumento";
                colCodInstrumento.Width = 55;
                colCodInstrumento.Frozen = false;
                colCodInstrumento.MinimumWidth = 55;
                colCodInstrumento.ReadOnly = true;
                colCodInstrumento.FillWeight = 100;
                colCodInstrumento.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodInstrumento.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodInstrumento.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescInstrumento";
                colDescricao.HeaderText = "Instrumento";
                colDescricao.Name = "DescInstrumento";
                colDescricao.Width = 250;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 180;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.MaxInputLength = 100;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colFamilia = new DataGridViewTextBoxColumn();
                colFamilia.DataPropertyName = "DescFamilia";
                colFamilia.HeaderText = "Família";
                colFamilia.Name = "DescFamilia";
                colFamilia.Width = 100;
                colFamilia.Frozen = false;
                colFamilia.MinimumWidth = 70;
                colFamilia.ReadOnly = true;
                colFamilia.FillWeight = 100;
                colFamilia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colFamilia.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFamilia.MaxInputLength = 100;
                colFamilia.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colSituacao = new DataGridViewTextBoxColumn();
                colSituacao.DataPropertyName = "Situacao";
                colSituacao.HeaderText = "Situação";
                colSituacao.Name = "Situacao";
                colSituacao.Width = 70;
                colSituacao.Frozen = false;
                colSituacao.MinimumWidth = 50;
                colSituacao.ReadOnly = true;
                colSituacao.FillWeight = 100;
                colSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colSituacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSituacao.MaxInputLength = 100;
                colSituacao.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colTessitura = new DataGridViewTextBoxColumn();
                colTessitura.DataPropertyName = "Tessitura";
                colTessitura.HeaderText = "Tessitura";
                colTessitura.Name = "Tessitura";
                colTessitura.Width = 100;
                colTessitura.Frozen = false;
                colTessitura.MinimumWidth = 70;
                colTessitura.ReadOnly = true;
                colTessitura.FillWeight = 100;
                colTessitura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colTessitura.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colTessitura.MaxInputLength = 100;
                colTessitura.Visible = true;
                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colSituacao);
                dataGrid.Columns.Add(colCodInstrumento);
                dataGrid.Columns.Add(colFamilia);
                dataGrid.Columns.Add(colDescricao);
                dataGrid.Columns.Add(colTessitura);
            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        ///<summary> Montar DataGrid Metodo Instrumento
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Metodo Instrumento, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridMetodoInstr(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Status";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            ///2ªColuna 
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodMetodoInstr";
            colCod.Name = "CodMetodoInstr";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
            colInstr.DataPropertyName = "DescInstrumento";
            colInstr.Name = "DescInstrumento";
            colInstr.HeaderText = "Instrumento";
            colInstr.Width = 120;
            colInstr.Frozen = false;
            colInstr.MinimumWidth = 80;
            colInstr.ReadOnly = true;
            colInstr.FillWeight = 100;
            colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colInstr.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colMetodo = new DataGridViewTextBoxColumn();
            colMetodo.DataPropertyName = "DescMetodo";
            colMetodo.Name = "DescMetodo";
            colMetodo.HeaderText = "Método";
            colMetodo.Width = 140;
            colMetodo.Frozen = false;
            colMetodo.MinimumWidth = 80;
            colMetodo.ReadOnly = true;
            colMetodo.FillWeight = 100;
            colMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colMetodo.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
            colAplica.DataPropertyName = "AplicarEm";
            colAplica.Name = "AplicarEm";
            colAplica.HeaderText = "Aplicação";
            colAplica.Width = 80;
            colAplica.Frozen = false;
            colAplica.MinimumWidth = 70;
            colAplica.ReadOnly = true;
            colAplica.FillWeight = 100;
            colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAplica.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colPagIni = new DataGridViewTextBoxColumn();
            colPagIni.DataPropertyName = "Inicio";
            colPagIni.Name = "Inicio";
            colPagIni.HeaderText = "Inicio: Fase/Pág/Lição";
            colPagIni.Width = 180;
            colPagIni.Frozen = false;
            colPagIni.MinimumWidth = 150;
            colPagIni.ReadOnly = true;
            colPagIni.FillWeight = 100;
            colPagIni.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPagIni.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colPagFim = new DataGridViewTextBoxColumn();
            colPagFim.DataPropertyName = "Fim";
            colPagFim.Name = "Fim";
            colPagFim.HeaderText = "Fim: Fase/Pág/Lição";
            colPagFim.Width = 180;
            colPagFim.Frozen = false;
            colPagFim.MinimumWidth = 150;
            colPagFim.ReadOnly = true;
            colPagFim.FillWeight = 100;
            colPagFim.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPagFim.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colAplica);
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colMetodo);
            dataGrid.Columns.Add(colInstr);
            dataGrid.Columns.Add(colPagIni);
            dataGrid.Columns.Add(colPagFim);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion

        #region funções que monta os datagridview da parte dos pretestes e testes

        ///<summary> Montar DataGrid LicaoTeste
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta LicaoTeste, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridLicaoTeste(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("LicaoTesteMet"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoMet";
                colCod.Name = "CodLicaoMet";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colMetodo = new DataGridViewTextBoxColumn();
                colMetodo.DataPropertyName = "DescMetodo";
                colMetodo.Name = "DescMetodo";
                colMetodo.HeaderText = "Método";
                colMetodo.Width = 200;
                colMetodo.Frozen = false;
                colMetodo.MinimumWidth = 80;
                colMetodo.ReadOnly = true;
                colMetodo.FillWeight = 100;
                colMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colMetodo.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 100;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 100;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAplica.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colPag = new DataGridViewTextBoxColumn();
                colPag.DataPropertyName = "PaginaMet";
                colPag.Name = "PaginaMet";
                colPag.HeaderText = "Página";
                colPag.Width = 80;
                colPag.Frozen = false;
                colPag.MinimumWidth = 50;
                colPag.ReadOnly = true;
                colPag.FillWeight = 100;
                colPag.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colPag.Visible = false;
                ///5ª coluna
                DataGridViewTextBoxColumn colLic = new DataGridViewTextBoxColumn();
                colLic.DataPropertyName = "LicaoMet";
                colLic.Name = "LicaoMet";
                colLic.HeaderText = "Lição";
                colLic.Width = 80;
                colLic.Frozen = false;
                colLic.MinimumWidth = 50;
                colLic.ReadOnly = true;
                colLic.FillWeight = 100;
                colLic.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colLic.Visible = false;
                ///5ª coluna
                DataGridViewTextBoxColumn colFase = new DataGridViewTextBoxColumn();
                colFase.DataPropertyName = "FaseMet";
                colFase.Name = "FaseMet";
                colFase.HeaderText = "Fase";
                colFase.Width = 80;
                colFase.Frozen = false;
                colFase.MinimumWidth = 50;
                colFase.ReadOnly = true;
                colFase.FillWeight = 100;
                colFase.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFase.Visible = false;
                ///5ª coluna
                DataGridViewTextBoxColumn colFasePag = new DataGridViewTextBoxColumn();
                colFasePag.DataPropertyName = "FasePagLicao";
                colFasePag.Name = "FasePagLicao";
                colFasePag.HeaderText = "Fase - Página - Lição";
                colFasePag.Width = 200;
                colFasePag.Frozen = false;
                colFasePag.MinimumWidth = 180;
                colFasePag.ReadOnly = true;
                colFasePag.FillWeight = 100;
                colFasePag.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colFasePag.Visible = true;
                ///6ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colAplica);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colMetodo);
                dataGrid.Columns.Add(colFasePag);
                dataGrid.Columns.Add(colFase);
                dataGrid.Columns.Add(colPag);
                dataGrid.Columns.Add(colLic);
            }
            else if (Tabela.Equals("LicaoTesteMts"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoMts";
                colCod.Name = "CodLicaoMts";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colMetodo = new DataGridViewTextBoxColumn();
                colMetodo.DataPropertyName = "DescMetodo";
                colMetodo.Name = "DescMetodo";
                colMetodo.HeaderText = "Método";
                colMetodo.Width = 120;
                colMetodo.Frozen = false;
                colMetodo.MinimumWidth = 80;
                colMetodo.ReadOnly = true;
                colMetodo.FillWeight = 100;
                colMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colMetodo.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 100;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 100;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAplica.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colMod = new DataGridViewTextBoxColumn();
                colMod.DataPropertyName = "ModuloMts";
                colMod.Name = "ModuloMts";
                colMod.HeaderText = "Módulo";
                colMod.Width = 70;
                colMod.Frozen = false;
                colMod.MinimumWidth = 50;
                colMod.ReadOnly = true;
                colMod.FillWeight = 100;
                colMod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colMod.DefaultCellStyle.Format = "00";
                colMod.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colLic = new DataGridViewTextBoxColumn();
                colLic.DataPropertyName = "LicaoMts";
                colLic.Name = "LicaoMts";
                colLic.HeaderText = "Lição";
                colLic.Width = 70;
                colLic.Frozen = false;
                colLic.MinimumWidth = 50;
                colLic.ReadOnly = true;
                colLic.FillWeight = 100;
                colLic.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colLic.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colLic.DefaultCellStyle.Format = "00";
                colLic.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
                colTipo.DataPropertyName = "TipoMts";
                colTipo.Name = "TipoMts";
                colTipo.HeaderText = "Tipo";
                colTipo.Width = 100;
                colTipo.Frozen = false;
                colTipo.MinimumWidth = 50;
                colTipo.ReadOnly = true;
                colTipo.FillWeight = 100;
                colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTipo.Visible = true;
                ///7ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colAplica);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colMetodo);
                dataGrid.Columns.Add(colTipo);
                dataGrid.Columns.Add(colMod);
                dataGrid.Columns.Add(colLic);

            }
            else if (Tabela.Equals("LicaoTesteHino"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoHino";
                colCod.Name = "CodLicaoHino";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
                colInstr.DataPropertyName = "DescInstrumento";
                colInstr.Name = "DescInstrumento";
                colInstr.HeaderText = "Instrumento";
                colInstr.Width = 200;
                colInstr.Frozen = false;
                colInstr.MinimumWidth = 80;
                colInstr.ReadOnly = true;
                colInstr.FillWeight = 100;
                colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colInstr.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colHinario = new DataGridViewTextBoxColumn();
                colHinario.DataPropertyName = "DescHinario";
                colHinario.Name = "DescHinario";
                colHinario.HeaderText = "Hinário";
                colHinario.Width = 200;
                colHinario.Frozen = false;
                colHinario.MinimumWidth = 80;
                colHinario.ReadOnly = true;
                colHinario.FillWeight = 100;
                colHinario.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colHinario.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 100;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 100;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAplica.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colHino = new DataGridViewTextBoxColumn();
                colHino.DataPropertyName = "Hino";
                colHino.Name = "Hino";
                colHino.HeaderText = "Hino";
                colHino.Width = 60;
                colHino.Frozen = false;
                colHino.MinimumWidth = 50;
                colHino.ReadOnly = true;
                colHino.FillWeight = 100;
                colHino.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colHino.Visible = true;
                ///6ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colAplica);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colHinario);
                dataGrid.Columns.Add(colHino);
                dataGrid.Columns.Add(colInstr);

            }
            else if (Tabela.Equals("LicaoTesteEscala"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoEscala";
                colCod.Name = "CodLicaoEscala";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
                colInstr.DataPropertyName = "DescInstrumento";
                colInstr.Name = "DescInstrumento";
                colInstr.HeaderText = "Instrumento";
                colInstr.Width = 140;
                colInstr.Frozen = false;
                colInstr.MinimumWidth = 80;
                colInstr.ReadOnly = true;
                colInstr.FillWeight = 100;
                colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colInstr.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colEscala = new DataGridViewTextBoxColumn();
                colEscala.DataPropertyName = "DescEscala";
                colEscala.Name = "DescEscala";
                colEscala.HeaderText = "Escala";
                colEscala.Width = 320;
                colEscala.Frozen = false;
                colEscala.MinimumWidth = 80;
                colEscala.ReadOnly = true;
                colEscala.FillWeight = 100;
                colEscala.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colEscala.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 100;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 100;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAplica.Visible = true;
                ///5ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colAplica);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colEscala);
                dataGrid.Columns.Add(colInstr);

            }
            else if (Tabela.Equals("LicaoTesteTeoria"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoTeoria";
                colCod.Name = "CodLicaoTeoria";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colTeoria = new DataGridViewTextBoxColumn();
                colTeoria.DataPropertyName = "DescTeoria";
                colTeoria.Name = "DescTeoria";
                colTeoria.HeaderText = "Descrição Teoria";
                colTeoria.Width = 320;
                colTeoria.Frozen = false;
                colTeoria.MinimumWidth = 80;
                colTeoria.ReadOnly = true;
                colTeoria.FillWeight = 100;
                colTeoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colTeoria.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 100;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 100;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colAplica.Visible = true;
                ///5ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colAplica);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colTeoria);

            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid LicaoPreTeste
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta LicaoPreTeste, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridLicaoPreTeste(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("LicaoPreMet"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoMet";
                colCod.Name = "CodLicaoMet";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
                colInstr.DataPropertyName = "DescInstrumento";
                colInstr.Name = "DescInstrumento";
                colInstr.HeaderText = "Instrumento";
                colInstr.Width = 140;
                colInstr.Frozen = false;
                colInstr.MinimumWidth = 80;
                colInstr.ReadOnly = true;
                colInstr.FillWeight = 100;
                colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colInstr.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colMetodo = new DataGridViewTextBoxColumn();
                colMetodo.DataPropertyName = "DescMetodo";
                colMetodo.Name = "DescMetodo";
                colMetodo.HeaderText = "Método";
                colMetodo.Width = 200;
                colMetodo.Frozen = false;
                colMetodo.MinimumWidth = 80;
                colMetodo.ReadOnly = true;
                colMetodo.FillWeight = 100;
                colMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMetodo.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 80;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 70;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAplica.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colPag = new DataGridViewTextBoxColumn();
                colPag.DataPropertyName = "PaginaMet";
                colPag.Name = "PaginaMet";
                colPag.HeaderText = "Página";
                colPag.Width = 80;
                colPag.Frozen = false;
                colPag.MinimumWidth = 50;
                colPag.ReadOnly = true;
                colPag.FillWeight = 100;
                colPag.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colPag.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colLic = new DataGridViewTextBoxColumn();
                colLic.DataPropertyName = "LicaoMet";
                colLic.Name = "LicaoMet";
                colLic.HeaderText = "Lição";
                colLic.Width = 80;
                colLic.Frozen = false;
                colLic.MinimumWidth = 50;
                colLic.ReadOnly = true;
                colLic.FillWeight = 100;
                colLic.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colLic.Visible = true;
                ///6ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colMetodo);
                dataGrid.Columns.Add(colInstr);
                dataGrid.Columns.Add(colPag);
                dataGrid.Columns.Add(colLic);
                dataGrid.Columns.Add(colAplica);
            }
            else if (Tabela.Equals("LicaoPreMts"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoMts";
                colCod.Name = "CodLicaoMts";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colMetodo = new DataGridViewTextBoxColumn();
                colMetodo.DataPropertyName = "DescMetodo";
                colMetodo.Name = "DescMetodo";
                colMetodo.HeaderText = "Método";
                colMetodo.Width = 120;
                colMetodo.Frozen = false;
                colMetodo.MinimumWidth = 80;
                colMetodo.ReadOnly = true;
                colMetodo.FillWeight = 100;
                colMetodo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMetodo.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 80;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 70;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAplica.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colMod = new DataGridViewTextBoxColumn();
                colMod.DataPropertyName = "ModuloMts";
                colMod.Name = "ModuloMts";
                colMod.HeaderText = "Módulo";
                colMod.Width = 70;
                colMod.Frozen = false;
                colMod.MinimumWidth = 50;
                colMod.ReadOnly = true;
                colMod.FillWeight = 100;
                colMod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colMod.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colLic = new DataGridViewTextBoxColumn();
                colLic.DataPropertyName = "LicaoMts";
                colLic.Name = "LicaoMts";
                colLic.HeaderText = "Lição";
                colLic.Width = 70;
                colLic.Frozen = false;
                colLic.MinimumWidth = 50;
                colLic.ReadOnly = true;
                colLic.FillWeight = 100;
                colLic.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colLic.Visible = true;
                ///6ª coluna
                DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
                colTipo.DataPropertyName = "TipoMts";
                colTipo.Name = "TipoMts";
                colTipo.HeaderText = "Tipo";
                colTipo.Width = 70;
                colTipo.Frozen = false;
                colTipo.MinimumWidth = 50;
                colTipo.ReadOnly = true;
                colTipo.FillWeight = 100;
                colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTipo.Visible = true;
                ///7ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colMetodo);
                dataGrid.Columns.Add(colMod);
                dataGrid.Columns.Add(colLic);
                dataGrid.Columns.Add(colTipo);
                dataGrid.Columns.Add(colAplica);

            }
            else if (Tabela.Equals("LicaoTesteHino"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoHino";
                colCod.Name = "CodLicaoHino";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
                colInstr.DataPropertyName = "DescInstrumento";
                colInstr.Name = "DescInstrumento";
                colInstr.HeaderText = "Instrumento";
                colInstr.Width = 200;
                colInstr.Frozen = false;
                colInstr.MinimumWidth = 80;
                colInstr.ReadOnly = true;
                colInstr.FillWeight = 100;
                colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colInstr.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colHinario = new DataGridViewTextBoxColumn();
                colHinario.DataPropertyName = "DescHinario";
                colHinario.Name = "DescHinario";
                colHinario.HeaderText = "Hinário";
                colHinario.Width = 200;
                colHinario.Frozen = false;
                colHinario.MinimumWidth = 80;
                colHinario.ReadOnly = true;
                colHinario.FillWeight = 100;
                colHinario.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colHinario.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 80;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 70;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAplica.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colHino = new DataGridViewTextBoxColumn();
                colHino.DataPropertyName = "Hino";
                colHino.Name = "Hino";
                colHino.HeaderText = "Hino";
                colHino.Width = 60;
                colHino.Frozen = false;
                colHino.MinimumWidth = 50;
                colHino.ReadOnly = true;
                colHino.FillWeight = 100;
                colHino.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colHino.Visible = true;
                ///6ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colHinario);
                dataGrid.Columns.Add(colInstr);
                dataGrid.Columns.Add(colHino);
                dataGrid.Columns.Add(colAplica);

            }
            else if (Tabela.Equals("LicaoPreEscala"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoEscala";
                colCod.Name = "CodLicaoEscala";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
                colInstr.DataPropertyName = "DescInstrumento";
                colInstr.Name = "DescInstrumento";
                colInstr.HeaderText = "Instrumento";
                colInstr.Width = 140;
                colInstr.Frozen = false;
                colInstr.MinimumWidth = 80;
                colInstr.ReadOnly = true;
                colInstr.FillWeight = 100;
                colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colInstr.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colEscala = new DataGridViewTextBoxColumn();
                colEscala.DataPropertyName = "DescEscala";
                colEscala.Name = "DescEscala";
                colEscala.HeaderText = "Escala";
                colEscala.Width = 320;
                colEscala.Frozen = false;
                colEscala.MinimumWidth = 80;
                colEscala.ReadOnly = true;
                colEscala.FillWeight = 100;
                colEscala.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEscala.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 80;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 70;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAplica.Visible = true;
                ///5ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colEscala);
                dataGrid.Columns.Add(colInstr);
                dataGrid.Columns.Add(colAplica);

            }
            else if (Tabela.Equals("LicaoPreTeoria"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodLicaoTeoria";
                colCod.Name = "CodLicaoTeoria";
                colCod.HeaderText = "Código";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colTeoria = new DataGridViewTextBoxColumn();
                colTeoria.DataPropertyName = "DescTeoria";
                colTeoria.Name = "DescTeoria";
                colTeoria.HeaderText = "Descrição Teoria";
                colTeoria.Width = 320;
                colTeoria.Frozen = false;
                colTeoria.MinimumWidth = 80;
                colTeoria.ReadOnly = true;
                colTeoria.FillWeight = 100;
                colTeoria.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTeoria.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colAplica = new DataGridViewTextBoxColumn();
                colAplica.DataPropertyName = "AplicaEm";
                colAplica.Name = "AplicaEm";
                colAplica.HeaderText = "Aplicação";
                colAplica.Width = 80;
                colAplica.Frozen = false;
                colAplica.MinimumWidth = 70;
                colAplica.ReadOnly = true;
                colAplica.FillWeight = 100;
                colAplica.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colAplica.Visible = true;
                ///5ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Status";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colTeoria);
                dataGrid.Columns.Add(colAplica);

            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid PreTeste
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta PreTeste, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridPreTeste(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;
            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodPreTeste";
            colCod.Name = "CodPreTeste";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
            colCCB.DataPropertyName = "DescricaoCCB";
            colCCB.Name = "DescricaoCCB";
            colCCB.HeaderText = "Comum congregação";
            colCCB.Width = 100;
            colCCB.Frozen = false;
            colCCB.MinimumWidth = 60;
            colCCB.ReadOnly = true;
            colCCB.FillWeight = 100;
            colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCCB.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.Name = "Status";
            colStatus.HeaderText = "Situação";
            colStatus.Width = 80;
            colStatus.Frozen = false;
            colStatus.MinimumWidth = 60;
            colStatus.ReadOnly = true;
            colStatus.FillWeight = 100;
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colStatus.Visible = true;
            ///7ª Coluna
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.DataPropertyName = "DataExame";
            colData.HeaderText = "Data Teste";
            colData.Name = "DataExame";
            colData.Width = 90;
            colData.Frozen = false;
            colData.MinimumWidth = 70;
            colData.ReadOnly = true;
            colData.FillWeight = 100;
            colData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colData.DefaultCellStyle.Format = "dd/MM/yyyy";
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colData.MaxInputLength = 10;
            colData.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colHora = new DataGridViewTextBoxColumn();
            colHora.DataPropertyName = "HoraExame";
            colHora.HeaderText = "Hora";
            colHora.Name = "HoraExame";
            colHora.Width = 50;
            colHora.Frozen = false;
            colHora.MinimumWidth = 40;
            colHora.ReadOnly = true;
            colHora.FillWeight = 100;
            colHora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHora.DefaultCellStyle.Format = "HH:mm";
            colHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHora.MaxInputLength = 10;
            colHora.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colStatus);
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colData);
            dataGrid.Columns.Add(colHora);
            dataGrid.Columns.Add(colCCB);

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid FichaPreTeste
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta FichaPreTeste, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridFichaPreTeste(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodFichaPreTeste";
            colCod.Name = "CodFichaPreTeste";
            colCod.HeaderText = "Ficha";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
            colInstr.DataPropertyName = "DescInstrumento";
            colInstr.Name = "DescInstrumento";
            colInstr.HeaderText = "Instrumento";
            colInstr.Width = 70;
            colInstr.Frozen = false;
            colInstr.MinimumWidth = 60;
            colInstr.ReadOnly = true;
            colInstr.FillWeight = 100;
            colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colInstr.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colPessoa = new DataGridViewTextBoxColumn();
            colPessoa.DataPropertyName = "NomeCandidato";
            colPessoa.Name = "NomeCandidato";
            colPessoa.HeaderText = "Candidato(a)";
            colPessoa.Width = 150;
            colPessoa.Frozen = false;
            colPessoa.MinimumWidth = 100;
            colPessoa.ReadOnly = true;
            colPessoa.FillWeight = 100;
            colPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPessoa.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "Tipo";
            colTipo.Name = "Tipo";
            colTipo.HeaderText = "Teste para";
            colTipo.Width = 100;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 90;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
            colCCB.DataPropertyName = "DescricaoCCB";
            colCCB.Name = "DescricaoCCB";
            colCCB.HeaderText = "Comum congregação";
            colCCB.Width = 140;
            colCCB.Frozen = false;
            colCCB.MinimumWidth = 140;
            colCCB.ReadOnly = true;
            colCCB.FillWeight = 100;
            colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCCB.Visible = true;
            ///7ª Coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.DataPropertyName = "Data";
            colData.HeaderText = "Data";
            colData.Name = "Data";
            colData.Width = 75;
            colData.Frozen = false;
            colData.MinimumWidth = 70;
            colData.ReadOnly = true;
            colData.FillWeight = 100;
            colData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colData.DefaultCellStyle.Format = "dd/MM/yyyy";
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colData.MaxInputLength = 10;
            colData.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colHora = new DataGridViewTextBoxColumn();
            colHora.DataPropertyName = "Hora";
            colHora.HeaderText = "Hora";
            colHora.Name = "Hora";
            colHora.Width = 40;
            colHora.Frozen = false;
            colHora.MinimumWidth = 35;
            colHora.ReadOnly = true;
            colHora.FillWeight = 100;
            colHora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHora.DefaultCellStyle.Format = "HH:mm";
            colHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHora.MaxInputLength = 10;
            colHora.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colSolicita = new DataGridViewTextBoxColumn();
            colSolicita.DataPropertyName = "CodSolicitaTeste";
            colSolicita.Name = "CodSolicitaTeste";
            colSolicita.HeaderText = "Solicitação";
            colSolicita.Width = 70;
            colSolicita.Frozen = false;
            colSolicita.MinimumWidth = 45;
            colSolicita.ReadOnly = true;
            colSolicita.FillWeight = 100;
            colSolicita.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSolicita.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSolicita.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colTipo);
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colData);
            dataGrid.Columns.Add(colHora);
            dataGrid.Columns.Add(colPessoa);
            dataGrid.Columns.Add(colInstr);
            dataGrid.Columns.Add(colCCB);
            dataGrid.Columns.Add(colSolicita);

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        ///<summary> Montar DataGrid SolicitaTeste
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta SolicitaTeste, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridSolicitaTeste(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodSolicitaTeste";
            colCod.Name = "CodSolicitaTeste";
            colCod.HeaderText = "Solicitação";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
            colInstr.DataPropertyName = "DescInstrumento";
            colInstr.Name = "DescInstrumento";
            colInstr.HeaderText = "Instrumento";
            colInstr.Width = 100;
            colInstr.Frozen = false;
            colInstr.MinimumWidth = 60;
            colInstr.ReadOnly = true;
            colInstr.FillWeight = 100;
            colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colInstr.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colPessoa = new DataGridViewTextBoxColumn();
            colPessoa.DataPropertyName = "Nome";
            colPessoa.Name = "Nome";
            colPessoa.HeaderText = "Aluno(a)";
            colPessoa.Width = 150;
            colPessoa.Frozen = false;
            colPessoa.MinimumWidth = 100;
            colPessoa.ReadOnly = true;
            colPessoa.FillWeight = 100;
            colPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPessoa.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "Tipo";
            colTipo.Name = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.Width = 80;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 70;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.Name = "Status";
            colStatus.HeaderText = "Situação";
            colStatus.Width = 70;
            colStatus.Frozen = false;
            colStatus.MinimumWidth = 50;
            colStatus.ReadOnly = true;
            colStatus.FillWeight = 100;
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colStatus.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
            colCCB.DataPropertyName = "DescricaoCCB";
            colCCB.Name = "DescricaoCCB";
            colCCB.HeaderText = "Comum";
            colCCB.Width = 150;
            colCCB.Frozen = false;
            colCCB.MinimumWidth = 80;
            colCCB.ReadOnly = true;
            colCCB.FillWeight = 100;
            colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCCB.Visible = true;
            ///7ª Coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.DataPropertyName = "Data";
            colData.HeaderText = "Data";
            colData.Name = "Data";
            colData.Width = 75;
            colData.Frozen = false;
            colData.MinimumWidth = 70;
            colData.ReadOnly = true;
            colData.FillWeight = 100;
            colData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colData.DefaultCellStyle.Format = "dd/MM/yyyy";
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colData.MaxInputLength = 10;
            colData.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colHora = new DataGridViewTextBoxColumn();
            colHora.DataPropertyName = "Hora";
            colHora.HeaderText = "Hora";
            colHora.Name = "Hora";
            colHora.Width = 40;
            colHora.Frozen = false;
            colHora.MinimumWidth = 35;
            colHora.ReadOnly = true;
            colHora.FillWeight = 100;
            colHora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHora.DefaultCellStyle.Format = "HH:mm";
            colHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHora.MaxInputLength = 10;
            colHora.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colStatus);
            dataGrid.Columns.Add(colTipo);
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colData);
            dataGrid.Columns.Add(colHora);
            dataGrid.Columns.Add(colPessoa);
            dataGrid.Columns.Add(colInstr);
            dataGrid.Columns.Add(colCCB);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid SolicitaTeste
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta SolicitaTeste, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///<para>Tabela='PesquisaSolicita'</para>
        ///</summary>
        public static void gridSolicitaTeste(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("PesquisaSolicita"))
            {

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
                colCod.DataPropertyName = "CodSolicitaTeste";
                colCod.Name = "CodSolicitaTeste";
                colCod.HeaderText = "Solicitação";
                colCod.Width = 60;
                colCod.Frozen = false;
                colCod.MinimumWidth = 45;
                colCod.ReadOnly = true;
                colCod.FillWeight = 100;
                colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCod.Visible = true;
                ///2ª coluna
                DataGridViewTextBoxColumn colInstr = new DataGridViewTextBoxColumn();
                colInstr.DataPropertyName = "DescInstrumento";
                colInstr.Name = "DescInstrumento";
                colInstr.HeaderText = "Instrumento";
                colInstr.Width = 100;
                colInstr.Frozen = false;
                colInstr.MinimumWidth = 60;
                colInstr.ReadOnly = true;
                colInstr.FillWeight = 100;
                colInstr.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colInstr.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colPessoa = new DataGridViewTextBoxColumn();
                colPessoa.DataPropertyName = "Nome";
                colPessoa.Name = "Nome";
                colPessoa.HeaderText = "Aluno(a)";
                colPessoa.Width = 150;
                colPessoa.Frozen = false;
                colPessoa.MinimumWidth = 100;
                colPessoa.ReadOnly = true;
                colPessoa.FillWeight = 100;
                colPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colPessoa.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
                colTipo.DataPropertyName = "Tipo";
                colTipo.Name = "Tipo";
                colTipo.HeaderText = "Tipo";
                colTipo.Width = 80;
                colTipo.Frozen = false;
                colTipo.MinimumWidth = 70;
                colTipo.ReadOnly = true;
                colTipo.FillWeight = 100;
                colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colTipo.Visible = true;
                ///5ª coluna
                DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
                colCCB.DataPropertyName = "DescricaoCCB";
                colCCB.Name = "DescricaoCCB";
                colCCB.HeaderText = "Comum";
                colCCB.Width = 150;
                colCCB.Frozen = false;
                colCCB.MinimumWidth = 80;
                colCCB.ReadOnly = true;
                colCCB.FillWeight = 100;
                colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCCB.Visible = true;
                ///7ª Coluna
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "imgTipo";
                img.HeaderText = "";
                img.Width = 20;
                img.Frozen = false;
                img.MinimumWidth = 20;
                img.ReadOnly = true;
                img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                img.Visible = true;

                ///aqui é adicionado as colunas no datagridview
                dataGrid.Columns.Add(img);
                dataGrid.Columns.Add(colTipo);
                dataGrid.Columns.Add(colCod);
                dataGrid.Columns.Add(colPessoa);
                dataGrid.Columns.Add(colInstr);
                dataGrid.Columns.Add(colCCB);
            }

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion

        #region funções que monta os datagridview da parte dos Usuarios

        ///<summary> Montar DataGrid CCB
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta empresas, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridUsuario(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Status";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;

            DataGridViewTextBoxColumn colSituacao = new DataGridViewTextBoxColumn();
            colSituacao.DataPropertyName = "Ativo";
            colSituacao.HeaderText = "Status";
            colSituacao.Name = "Ativo";
            colSituacao.Width = 50;
            colSituacao.Frozen = false;
            colSituacao.MinimumWidth = 45;
            colSituacao.ReadOnly = true;
            colSituacao.FillWeight = 100;
            colSituacao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSituacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSituacao.MaxInputLength = 10;
            colSituacao.Visible = false;
            ///1ª colluna
            DataGridViewTextBoxColumn colCodUsu = new DataGridViewTextBoxColumn();
            colCodUsu.DataPropertyName = "CodUsuario";
            colCodUsu.HeaderText = "Código";
            colCodUsu.Width = 60;
            colCodUsu.Frozen = false;
            colCodUsu.MinimumWidth = 55;
            colCodUsu.ReadOnly = true;
            colCodUsu.FillWeight = 100;
            colCodUsu.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodUsu.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodUsu.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "Usuario";
            colDesc.HeaderText = "Login";
            colDesc.Width = 120;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 100;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDesc.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colPessoa = new DataGridViewTextBoxColumn();
            colPessoa.DataPropertyName = "Nome";
            colPessoa.HeaderText = "Pessoa";
            colPessoa.Name = "Nome";
            colPessoa.Width = 120;
            colPessoa.Frozen = false;
            colPessoa.MinimumWidth = 100;
            colPessoa.ReadOnly = true;
            colPessoa.FillWeight = 100;
            colPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPessoa.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colSituacao);
            dataGrid.Columns.Add(colCodUsu);
            dataGrid.Columns.Add(colDesc);
            dataGrid.Columns.Add(colPessoa);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion

        #region funções que monta os datagridview da parte administração

        ///<summary> Montar DataGrid ReuniaoListaPresenca
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta ReuniaoListaPresenca, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridListaPresenca(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodListaPresenca";
            colCod.Name = "CodListaPresenca";
            colCod.HeaderText = "Código";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodReuniao = new DataGridViewTextBoxColumn();
            colCodReuniao.DataPropertyName = "CodReuniao";
            colCodReuniao.Name = "CodReuniao";
            colCodReuniao.HeaderText = "CodReuniao";
            colCodReuniao.Width = 60;
            colCodReuniao.Frozen = false;
            colCodReuniao.MinimumWidth = 45;
            colCodReuniao.ReadOnly = true;
            colCodReuniao.FillWeight = 100;
            colCodReuniao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodReuniao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodReuniao.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodPessoa = new DataGridViewTextBoxColumn();
            colCodPessoa.DataPropertyName = "CodPessoa";
            colCodPessoa.Name = "CodPessoa";
            colCodPessoa.HeaderText = "CodPessoa";
            colCodPessoa.Width = 60;
            colCodPessoa.Frozen = false;
            colCodPessoa.MinimumWidth = 45;
            colCodPessoa.ReadOnly = true;
            colCodPessoa.FillWeight = 100;
            colCodPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodPessoa.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCodPessoa.Visible = false;
            ///3ª coluna
            DataGridViewTextBoxColumn colPessoa = new DataGridViewTextBoxColumn();
            colPessoa.DataPropertyName = "Nome";
            colPessoa.Name = "Nome";
            colPessoa.HeaderText = "Irmão(ã)";
            colPessoa.Width = 150;
            colPessoa.Frozen = false;
            colPessoa.MinimumWidth = 100;
            colPessoa.ReadOnly = true;
            colPessoa.FillWeight = 100;
            colPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPessoa.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
            colCCB.DataPropertyName = "DescricaoCCBPessoa";
            colCCB.Name = "DescricaoCCBPessoa";
            colCCB.HeaderText = "Comum";
            colCCB.Width = 150;
            colCCB.Frozen = false;
            colCCB.MinimumWidth = 80;
            colCCB.ReadOnly = true;
            colCCB.FillWeight = 100;
            colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCCB.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colCargo = new DataGridViewTextBoxColumn();
            colCargo.DataPropertyName = "DescCargo";
            colCargo.Name = "DescCargo";
            colCargo.HeaderText = "Ministério";
            colCargo.Width = 150;
            colCargo.Frozen = false;
            colCargo.MinimumWidth = 80;
            colCargo.ReadOnly = true;
            colCargo.FillWeight = 100;
            colCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCargo.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colCodReuniao);
            dataGrid.Columns.Add(colCodPessoa);
            dataGrid.Columns.Add(colPessoa);
            dataGrid.Columns.Add(colCargo);
            dataGrid.Columns.Add(colCCB);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid ReuniaoMinisterio
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta ReuniaoMinisterio, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridReuniaoMinisterio(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodReuniao";
            colCod.Name = "CodReuniao";
            colCod.HeaderText = "Reunião nº";
            colCod.Width = 70;
            colCod.Frozen = false;
            colCod.MinimumWidth = 60;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colCod.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "DescTipoReuniao";
            colTipo.Name = "DescTipoReuniao";
            colTipo.HeaderText = "Tipo de Reunião";
            colTipo.Width = 120;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 100;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTipo.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.Name = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Width = 70;
            colStatus.Frozen = false;
            colStatus.MinimumWidth = 50;
            colStatus.ReadOnly = true;
            colStatus.FillWeight = 100;
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colStatus.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colCCB = new DataGridViewTextBoxColumn();
            colCCB.DataPropertyName = "DescricaoCCB";
            colCCB.Name = "DescricaoCCB";
            colCCB.HeaderText = "Comum";
            colCCB.Width = 150;
            colCCB.Frozen = false;
            colCCB.MinimumWidth = 80;
            colCCB.ReadOnly = true;
            colCCB.FillWeight = 100;
            colCCB.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCCB.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colReg = new DataGridViewTextBoxColumn();
            colReg.DataPropertyName = "DescricaoRegiao";
            colReg.Name = "DescricaoRegiao";
            colReg.HeaderText = "Região";
            colReg.Width = 100;
            colReg.Frozen = false;
            colReg.MinimumWidth = 80;
            colReg.ReadOnly = true;
            colReg.FillWeight = 100;
            colReg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colReg.Visible = false;
            ///7ª Coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.DataPropertyName = "DataReuniao";
            colData.HeaderText = "Data da Reunião";
            colData.Name = "DataReuniao";
            colData.Width = 75;
            colData.Frozen = false;
            colData.MinimumWidth = 70;
            colData.ReadOnly = true;
            colData.FillWeight = 100;
            colData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colData.DefaultCellStyle.Format = "dd/MM/yyyy";
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colData.MaxInputLength = 10;
            colData.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colHora = new DataGridViewTextBoxColumn();
            colHora.DataPropertyName = "HoraReuniao";
            colHora.HeaderText = "Hora";
            colHora.Name = "HoraReuniao";
            colHora.Width = 40;
            colHora.Frozen = false;
            colHora.MinimumWidth = 35;
            colHora.ReadOnly = true;
            colHora.FillWeight = 100;
            colHora.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colHora.DefaultCellStyle.Format = "HH:mm";
            colHora.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colHora.MaxInputLength = 10;
            colHora.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colStatus);
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colTipo);
            dataGrid.Columns.Add(colData);
            dataGrid.Columns.Add(colHora);
            dataGrid.Columns.Add(colReg);
            dataGrid.Columns.Add(colCCB);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }
        ///<summary> Montar DataGrid TipoReuniao
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta TipoReuniao, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridTipoReuniao(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodTipoReuniao";
            colCod.Name = "CodTipoReuniao";
            colCod.HeaderText = "Código";
            colCod.Width = 50;
            colCod.Frozen = false;
            colCod.MinimumWidth = 45;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "DescTipoReuniao";
            colDesc.Name = "DescTipoReuniao";
            colDesc.HeaderText = "Descrição";
            colDesc.Width = 150;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 120;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDesc.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colDesc);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion

        #region funções que monta os datagridview da parte dos Usuarios

        ///<summary> Montar DataGrid Novidades
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Novidades, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridNovidade(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "img";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Status";
            colStatus.Name = "Status";
            colStatus.Width = 100;
            colStatus.Frozen = false;
            colStatus.MinimumWidth = 70;
            colStatus.ReadOnly = true;
            colStatus.FillWeight = 100;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colStatus.MaxInputLength = 30;
            colStatus.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "TipoAtualiza";
            colTipo.HeaderText = "Tipo Atualização";
            colTipo.Name = "TipoAtualiza";
            colTipo.Width = 100;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 70;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.MaxInputLength = 30;
            colTipo.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colAnda = new DataGridViewTextBoxColumn();
            colAnda.DataPropertyName = "Andamento";
            colAnda.HeaderText = "Andamento";
            colAnda.Name = "Andamento";
            colAnda.Width = 100;
            colAnda.Frozen = false;
            colAnda.MinimumWidth = 80;
            colAnda.ReadOnly = true;
            colAnda.FillWeight = 100;
            colAnda.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colAnda.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colAnda.MaxInputLength = 30;
            colAnda.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
            colDescricao.DataPropertyName = "Descricao";
            colDescricao.HeaderText = "Descrição";
            colDescricao.Name = "Descricao";
            colDescricao.Width = 200;
            colDescricao.Frozen = false;
            colDescricao.MinimumWidth = 120;
            colDescricao.ReadOnly = true;
            colDescricao.FillWeight = 100;
            colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescricao.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colProg = new DataGridViewTextBoxColumn();
            colProg.DataPropertyName = "DescPrograma";
            colProg.HeaderText = "Programa";
            colProg.Width = 150;
            colProg.Frozen = false;
            colProg.MinimumWidth = 100;
            colProg.ReadOnly = true;
            colProg.FillWeight = 100;
            colProg.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colProg.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colData = new DataGridViewTextBoxColumn();
            colData.DataPropertyName = "Data";
            colData.HeaderText = "Data";
            colData.Name = "Data";
            colData.Width = 75;
            colData.Frozen = false;
            colData.MinimumWidth = 70;
            colData.ReadOnly = true;
            colData.FillWeight = 100;
            colData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colData.DefaultCellStyle.Format = "dd/MM/yyyy";
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colData.MaxInputLength = 10;
            colData.Visible = true;
            ///2ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodNovidades";
            colCod.HeaderText = "Código";
            colCod.Name = "CodNovidades";
            colCod.Width = 60;
            colCod.Frozen = false;
            colCod.MinimumWidth = 55;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.Visible = true;

            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colAnda);
            dataGrid.Columns.Add(colStatus);
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colTipo);
            dataGrid.Columns.Add(colData);
            dataGrid.Columns.Add(colProg);
            dataGrid.Columns.Add(colDescricao);

            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion

        #region funções que monta os datagridview da parte produtos

        ///<summary> Montar DataGrid Produtos
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta produtos, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridProdutos(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "IdProd";
            colId.HeaderText = "IdProd";
            colId.Width = 50;
            colId.Frozen = false;
            colId.MinimumWidth = 45;
            colId.ReadOnly = true;
            colId.FillWeight = 100;
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colId.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colId.Visible = false;
            ///2ª coluna
            DataGridViewTextBoxColumn colCodigo = new DataGridViewTextBoxColumn();
            colCodigo.DataPropertyName = "CodProduto";
            colCodigo.HeaderText = "Cód. Produto";
            colCodigo.Width = 100;
            colCodigo.Frozen = false;
            colCodigo.MinimumWidth = 80;
            colCodigo.ReadOnly = true;
            colCodigo.FillWeight = 100;
            colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodigo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCodigo.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.DataPropertyName = "DescProd";
            colDesc.HeaderText = "Descrição";
            colDesc.Width = 180;
            colDesc.Frozen = false;
            colDesc.MinimumWidth = 120;
            colDesc.ReadOnly = true;
            colDesc.FillWeight = 100;
            colDesc.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colDesc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colDesc.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colLocal = new DataGridViewTextBoxColumn();
            colLocal.DataPropertyName = "Local";
            colLocal.HeaderText = "Local";
            colLocal.Width = 60;
            colLocal.Frozen = false;
            colLocal.MinimumWidth = 50;
            colLocal.ReadOnly = true;
            colLocal.FillWeight = 100;
            colLocal.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colLocal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colLocal.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colSaldo = new DataGridViewTextBoxColumn();
            colSaldo.DataPropertyName = "SaldoAlmox";
            colSaldo.HeaderText = "Saldo";
            colSaldo.Width = 50;
            colSaldo.Frozen = false;
            colSaldo.MinimumWidth = 50;
            colSaldo.ReadOnly = true;
            colSaldo.FillWeight = 100;
            colSaldo.DefaultCellStyle.Format = "#,##0.00";
            colSaldo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSaldo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSaldo.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colValor = new DataGridViewTextBoxColumn();
            colValor.DataPropertyName = "ValorVenda";
            colValor.HeaderText = "Valor Venda (R$)";
            colValor.Width = 80;
            colValor.Frozen = false;
            colValor.MinimumWidth = 60;
            colValor.ReadOnly = true;
            colValor.FillWeight = 100;
            colValor.DefaultCellStyle.Format = "#,##0.00";
            colValor.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colValor.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colValor.Visible = true;
            ///7ª coluna
            DataGridViewTextBoxColumn colTipo = new DataGridViewTextBoxColumn();
            colTipo.DataPropertyName = "DescTipoProd";
            colTipo.HeaderText = "Tipo Produto";
            colTipo.Width = 80;
            colTipo.Frozen = false;
            colTipo.MinimumWidth = 60;
            colTipo.ReadOnly = true;
            colTipo.FillWeight = 100;
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colTipo.Visible = true;
            ///8ª coluna
            DataGridViewTextBoxColumn colSecao = new DataGridViewTextBoxColumn();
            colSecao.DataPropertyName = "DescSecao";
            colSecao.HeaderText = "Seção";
            colSecao.Width = 80;
            colSecao.Frozen = false;
            colSecao.MinimumWidth = 60;
            colSecao.ReadOnly = true;
            colSecao.FillWeight = 100;
            colSecao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSecao.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colSecao.Visible = true;
            ///9ª coluna
            DataGridViewTextBoxColumn colGrupo = new DataGridViewTextBoxColumn();
            colGrupo.DataPropertyName = "DescGrupo";
            colGrupo.HeaderText = "Grupo";
            colGrupo.Width = 100;
            colGrupo.Frozen = false;
            colGrupo.MinimumWidth = 90;
            colGrupo.ReadOnly = true;
            colGrupo.FillWeight = 100;
            colGrupo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colGrupo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colGrupo.Visible = true;
            ///10ª coluna
            DataGridViewTextBoxColumn colSub = new DataGridViewTextBoxColumn();
            colSub.DataPropertyName = "DescSubGrupo";
            colSub.HeaderText = "Sub-Grupo";
            colSub.Width = 100;
            colSub.Frozen = false;
            colSub.MinimumWidth = 90;
            colSub.ReadOnly = true;
            colSub.FillWeight = 100;
            colSub.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSub.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colSub.Visible = true;
            ///11ª coluna
            DataGridViewTextBoxColumn colSitTrib = new DataGridViewTextBoxColumn();
            colSitTrib.DataPropertyName = "DescSitTrib";
            colSitTrib.HeaderText = "Sit. Tributária";
            colSitTrib.Width = 100;
            colSitTrib.Frozen = false;
            colSitTrib.MinimumWidth = 90;
            colSitTrib.ReadOnly = true;
            colSitTrib.FillWeight = 100;
            colSitTrib.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colSitTrib.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colSitTrib.Visible = true;
            ///12ª coluna
            DataGridViewTextBoxColumn colCoef = new DataGridViewTextBoxColumn();
            colCoef.DataPropertyName = "DescCoef";
            colCoef.HeaderText = "Coeficiente";
            colCoef.Width = 80;
            colCoef.Frozen = false;
            colCoef.MinimumWidth = 75;
            colCoef.ReadOnly = true;
            colCoef.FillWeight = 100;
            colCoef.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCoef.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCoef.Visible = true;
            ///13ª coluna
            DataGridViewTextBoxColumn colAplic = new DataGridViewTextBoxColumn();
            colAplic.DataPropertyName = "Aplicacao";
            colAplic.HeaderText = "Aplicação";
            colAplic.Width = 500;
            colAplic.Frozen = false;
            colAplic.MinimumWidth = 100;
            colAplic.ReadOnly = true;
            colAplic.FillWeight = 100;
            colAplic.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAplic.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colAplic.Visible = true;
            ///14ª coluna
            DataGridViewTextBoxColumn colCodFab = new DataGridViewTextBoxColumn();
            colCodFab.DataPropertyName = "CodigoFabrica";
            colCodFab.HeaderText = "Cod. Fábrica";
            colCodFab.Width = 95;
            colCodFab.Frozen = false;
            colCodFab.MinimumWidth = 85;
            colCodFab.ReadOnly = true;
            colCodFab.FillWeight = 100;
            colCodFab.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCodFab.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colCodFab.Visible = true;


            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(colId);
            dataGrid.Columns.Add(colCodigo);
            dataGrid.Columns.Add(colCodFab);
            dataGrid.Columns.Add(colDesc);
            dataGrid.Columns.Add(colLocal);
            dataGrid.Columns.Add(colSaldo);
            dataGrid.Columns.Add(colTipo);
            dataGrid.Columns.Add(colValor);
            dataGrid.Columns.Add(colSecao);
            dataGrid.Columns.Add(colGrupo);
            dataGrid.Columns.Add(colSub);
            dataGrid.Columns.Add(colCoef);
            dataGrid.Columns.Add(colSitTrib);
            dataGrid.Columns.Add(colAplic);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion
        #region funções que monta os datagridview da parte requisição

        ///<summary> Montar DataGrid Requisição
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta requisição, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///</summary>
        public static void gridRequisicao(DataGridView dataGrid)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
            ///iniciando pela 1ª coluna
            DataGridViewImageColumn img = new DataGridViewImageColumn();
            img.Name = "Status";
            img.HeaderText = "";
            img.Width = 20;
            img.Frozen = false;
            img.MinimumWidth = 20;
            img.ReadOnly = true;
            img.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            img.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            img.Visible = true;
            //2ªcoluna
            DataGridViewTextBoxColumn colStatus = new DataGridViewTextBoxColumn();
            colStatus.DataPropertyName = "Status";
            colStatus.HeaderText = "Situação";
            colStatus.Name = "Status";
            colStatus.Width = 70;
            colStatus.Frozen = false;
            colStatus.MinimumWidth = 70;
            colStatus.ReadOnly = true;
            colStatus.FillWeight = 100;
            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colStatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colStatus.MaxInputLength = 20;
            colStatus.Visible = true;
            ///3ª coluna
            DataGridViewTextBoxColumn colCod = new DataGridViewTextBoxColumn();
            colCod.DataPropertyName = "CodRequis";
            colCod.HeaderText = "Requisição";
            colCod.Width = 70;
            colCod.Frozen = false;
            colCod.MinimumWidth = 70;
            colCod.ReadOnly = true;
            colCod.FillWeight = 100;
            colCod.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCod.DefaultCellStyle.Format = "000000";
            colCod.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colCod.MaxInputLength = 10;
            colCod.Visible = true;
            ///4ª coluna
            DataGridViewTextBoxColumn colEmis = new DataGridViewTextBoxColumn();
            colEmis.DataPropertyName = "DataEmissao";
            colEmis.HeaderText = "Emissão";
            colEmis.Width = 75;
            colEmis.Frozen = false;
            colEmis.MinimumWidth = 70;
            colEmis.ReadOnly = true;
            colEmis.FillWeight = 100;
            colEmis.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colEmis.DefaultCellStyle.Format = "dd/MM/yyyy";
            colEmis.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colEmis.MaxInputLength = 10;
            colEmis.Visible = true;
            ///5ª coluna
            DataGridViewTextBoxColumn colFatura = new DataGridViewTextBoxColumn();
            colFatura.DataPropertyName = "DataFatura";
            colFatura.HeaderText = "Faturamento";
            colFatura.Width = 75;
            colFatura.Frozen = false;
            colFatura.MinimumWidth = 70;
            colFatura.ReadOnly = true;
            colFatura.FillWeight = 100;
            colFatura.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colFatura.DefaultCellStyle.Format = "dd/MM/yyyy";
            colFatura.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colFatura.MaxInputLength = 10;
            colFatura.Visible = true;
            ///6ª coluna
            DataGridViewTextBoxColumn colPessoa = new DataGridViewTextBoxColumn();
            colPessoa.DataPropertyName = "NomePessoa";
            colPessoa.HeaderText = "Pessoa";
            colPessoa.Width = 120;
            colPessoa.Frozen = false;
            colPessoa.MinimumWidth = 100;
            colPessoa.ReadOnly = true;
            colPessoa.FillWeight = 100;
            colPessoa.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colPessoa.MaxInputLength = 200;
            colPessoa.Visible = true;
            ///7ª coluna
            DataGridViewTextBoxColumn colOrdem = new DataGridViewTextBoxColumn();
            colOrdem.DataPropertyName = "CodOrdem";
            colOrdem.HeaderText = "Ordem";
            colOrdem.Width = 70;
            colOrdem.Frozen = false;
            colOrdem.MinimumWidth = 60;
            colOrdem.ReadOnly = true;
            colOrdem.FillWeight = 100;
            colCod.DefaultCellStyle.Format = "000000";
            colOrdem.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colOrdem.MaxInputLength = 50;
            colOrdem.Visible = true;
            ///8ª coluna
            DataGridViewTextBoxColumn colTipoMov = new DataGridViewTextBoxColumn();
            colTipoMov.DataPropertyName = "DescTipoMov";
            colTipoMov.HeaderText = "Tipo Movimento";
            colTipoMov.Width = 100;
            colTipoMov.Frozen = false;
            colTipoMov.MinimumWidth = 80;
            colTipoMov.ReadOnly = true;
            colTipoMov.FillWeight = 100;
            colTipoMov.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            colTipoMov.MaxInputLength = 50;
            colTipoMov.Visible = true;
            ///9ª coluna
            DataGridViewTextBoxColumn colVendedor = new DataGridViewTextBoxColumn();
            colVendedor.DataPropertyName = "DescVendedor";
            colVendedor.HeaderText = "Vendedor";
            colVendedor.Width = 75;
            colVendedor.Frozen = false;
            colVendedor.MinimumWidth = 70;
            colVendedor.ReadOnly = true;
            colVendedor.FillWeight = 100;
            colVendedor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colVendedor.MaxInputLength = 10;
            colVendedor.Visible = true;
            ///aqui é adicionado as colunas no datagridview
            dataGrid.Columns.Add(img);
            dataGrid.Columns.Add(colStatus);
            dataGrid.Columns.Add(colCod);
            dataGrid.Columns.Add(colOrdem);
            dataGrid.Columns.Add(colPessoa);
            dataGrid.Columns.Add(colTipoMov);
            dataGrid.Columns.Add(colEmis);
            dataGrid.Columns.Add(colFatura);
            dataGrid.Columns.Add(colVendedor);
            ///feito um refresh para fazer a atualização do datagridview
            dataGrid.Refresh();
        }

        #endregion

        #endregion

        ///Funções que valida e formata os campos
        #region ### Função e rotinas de formatação e validação dos campos ###

        /// <summary>
        /// Função que formata qualquer string, bastando apenas
        /// <para>indicar o formato e o valor a ser formatado</para>
        /// <para>- Exemplo:</para>
        /// <para>* Formatar Cep -- FormataString("#####-###", Cep)</para>
        /// </summary>
        /// <param name="mascara"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string FormataString(string mascara, string valor)
        {
            string novoValor = string.Empty;
            string valorFormatado = string.Empty;
            int posicao = 0;

            //Suprime os caracteres especiais digitados
            novoValor = valor.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(",", "");

            for (int i = 0; mascara.Length > i; i++)
            {
                if (mascara[i].Equals('#'))
                {
                    if (novoValor.Length > posicao)
                    {
                        valorFormatado = valorFormatado + novoValor[posicao];
                        posicao++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (novoValor.Length > posicao)
                    {
                        valorFormatado = valorFormatado + mascara[i];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return valorFormatado;
        }

        #region Funções que formata e valida datas e horas

        private static readonly Regex ShortDate = new Regex(@"^\d{6}$");
        private static readonly Regex LongDate = new Regex(@"^\d{8}$");
        /// <summary>
        /// Função que formata o campo Data nos DatagridView
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormataData(string value)
        {
            string Retorno = null;
            string s = value.ToString().Trim();

            if (s.Trim().Equals(string.Empty))
            {
                return null;
            }
            else
            {
                s = s.Replace(",", "");
                s = s.Replace("-", "");
                s = s.Replace("/", "");
                if (s.Length.Equals(1))
                {
                    s = "0" + s + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");
                }
                else if (s.Length.Equals(2))
                {
                    s = s + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");
                }
                else if (s.Length.Equals(3))
                {
                    s = s.Substring(0, 2) + "/0" + s.Substring(2, 1) + "/" + DateTime.Now.ToString("yyyy");
                }
                else if (s.Length.Equals(4))
                {
                    s = s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + DateTime.Now.ToString("yyyy");
                }
                else
                {
                    int i = s.IndexOf(',');

                    if (!i.Equals(-1))
                    {
                        s = s.Replace(",", ":");
                    }
                    else
                    {
                        if (s.Length.Equals(3))
                        {
                            s = "0" + s;
                        }
                        else if (s.Length.Equals(4))
                        {
                            s = s.Substring(0, 2) + ":" + s.Substring(2, 2);
                        }
                    }
                }
                try
                {
                    if (ShortDate.Match(s).Success)
                    {
                        s = s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(4, 2);
                    }
                    if (LongDate.Match(s).Success)
                    {
                        s = s.Substring(0, 2) + "/" + s.Substring(2, 2) + "/" + s.Substring(4, 4);
                    }

                    DateTime d = DateTime.Parse(s);
                    Retorno = d.ToString("dd/MM/yyyy");
                }
                catch
                {
                    throw new Exception("Data inválida!");
                }

                return Retorno;
            }
        }

        /// <summary>
        /// Função que formata o campo Hora nos DatagridView
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string FormataHora(string value)
        {
            string Retorno = null;
            string s = value.ToString().Trim();
            //DateTime hora = DateTime.Parse(s);

            //s = hora.ToString("HH:mm");

            if (s.Trim().Equals(string.Empty))
            {
                return null;
            }
            else
            {
                s = s.Replace(":", "");
                if (!s.Length.Equals(3) && !s.Length.Equals(4) && !s.Length.Equals(5))
                {
                    if (s.Length.Equals(1))
                    {
                        s = "0" + s + "00";
                    }
                    else if (s.Length.Equals(2))
                    {
                        s = s + "00";
                    }
                    s = s.Substring(0, 2) + ":" + s.Substring(2, 2);
                }
                else
                {
                    int i = s.IndexOf(',');

                    if (!i.Equals(-1))
                    {
                        s = s.Replace(",", ":");
                    }
                    else
                    {
                        if (s.Length.Equals(3))
                        {
                            s = "0" + s;
                        }
                        else if (s.Length.Equals(4))
                        {
                            s = s.Substring(0, 2) + ":" + s.Substring(2, 2);
                        }
                    }
                }
                try
                {
                    DateTime d = DateTime.Parse(s);
                    Retorno = d.ToString("HH:mm");
                }
                catch
                {
                    throw new Exception("Hora inválida!");
                }

                return Retorno;
            }
        }

        /// <summary>
        /// Função que Convert Data em Inteiro de Acordo com o inicio em 30/12/1899
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string DataInt(string Data)
        {
            DateTime DataInicial;
            DateTime DataFinal;
            TimeSpan tsPeriodo;
            Data = FormataData(Data);
            DataInicial = Convert.ToDateTime("30/12/1899");
            DataFinal = Convert.ToDateTime(Data);

            tsPeriodo = DataFinal - DataInicial;
            //Retorna o intervalo em dias
            return tsPeriodo.Days.ToString();
        }
        /// <summary>
        /// Função que captura um valor Inteiro e transforma em uma data
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string IntData(string Data)
        {
            DateTime DataInicial;
            DateTime DataFinal;
            int DataRecebida;

            DataInicial = Convert.ToDateTime("30/12/1899");
            DataRecebida = Convert.ToInt32(Data);

            DataFinal = DataInicial.AddDays(DataRecebida);
            return DataFinal.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Função que converte a hora em Inteiro
        /// </summary>
        /// <param name="Hora"></param>
        /// <returns></returns>
        public static string HoraInt(string Hora)
        {
            string h = Hora.Replace(":", "");

            return h;
        }
        /// <summary>
        /// Função que converte o Inteiro em Hora
        /// </summary>
        /// <param name="Hora"></param>
        /// <returns></returns>
        public static string IntHora(string Hora)
        {
            string Retorno;
            string s = Hora.ToString().Trim();

            if (string.IsNullOrEmpty(s.Trim()))
            {
                return null;
            }
            else
            {
                s = Hora.Replace(":", "").Replace(",", "").Replace(".", "");

                if (Hora.Length != 4 && Hora.Length != 5)
                {
                    if (Hora.Length.Equals(1))
                    {
                        s = "000" + Hora;
                    }
                    else if (Hora.Length.Equals(2))
                    {
                        s = "00" + Hora;
                    }
                    else if (Hora.Length.Equals(3))
                    {
                        s = "0" + Hora;
                    }
                }

                s = s.Substring(0, 2) + ":" + s.Substring(2, 2);
                DateTime d = DateTime.Parse(s);
                Retorno = d.ToString("HH:mm");

                return Retorno;
            }
        }

        #endregion

        #region funcao que formata e valida cpf

        public static string FormataCpf(string value)
        {
            try
            {
                string msg = string.Empty;

                string s = value.Trim();

                s = value.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(",", "").Replace("/", "");
                if (string.IsNullOrEmpty(s.Trim()))
                {
                    return null;
                }
                else if (s.Length != 11)
                {
                    throw new Exception("C.P.F. inválido!");
                }
                else
                {
                    if (s.Equals("00000000000"))
                    {
                        if (!modulos.listaParametros[0].CpfZerado.Equals("Sim"))
                        {
                            throw new Exception("C.P.F. inválido!");
                        }
                        else
                        {
                            if (ValidaCpf(s).Equals(true))
                            {
                                msg = FormataString("###.###.###-##", s);
                            }
                            else
                            {
                                throw new Exception("C.P.F. inválido!");
                            }
                        }
                        return msg;
                    }
                    else
                    {
                        if (ValidaCpf(s).Equals(true))
                        {
                            msg = FormataString("###.###.###-##", s);
                        }
                        else
                        {
                            throw new Exception("C.P.F. inválido!");
                        }
                    }
                    return msg;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static bool ValidaCpf(string cpf)
        {
            try
            {
                int i = 0;
                int a = 0;
                int n1 = 0;
                int n2 = 0;

                cpf = Strings.Trim(cpf);

                if (cpf.Length != 11 || cpf == "11111111111" ||
                    cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" ||
                    cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" ||
                    cpf == "88888888888" || cpf == "99999999999")
                {
                    return false;
                }

                for (a = 0; a <= 1; a++)
                {
                    n1 = 0;
                    for (i = 1; i <= 9 + a; i++)
                    {
                        n1 = Convert.ToInt32(n1 + Conversion.Val(Strings.Mid(cpf, i, 1)) * (11 + a - i));
                    }
                    n2 = 11 - (n1 - (Conversion.Int(n1 / 11) * 11));

                    if (n2 == 10 | n2 == 11) n2 = 0;
                    if (n2 != Conversion.Val(Strings.Mid(cpf, 10 + a, 1)))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                throw new Exception("C.P.F. inválido!");
            }
        }

        #endregion

        #region funcao que formata e valida cnpj

        public static string FormataCnpj(string value)
        {
            try
            {
                string msg = string.Empty;

                string s = value.Trim();

                s = value.Replace(".", "").Replace("-", "");
                if (string.IsNullOrEmpty(s.Trim()))
                {
                    return null;
                }
                else if (s.Length != 11)
                {
                    throw new Exception("C.N.P.J. inválido!");
                }
                else
                {
#warning liberar a validação para cnpj

                    //if (ValidaCnpj(s).Equals(true))
                    //{
                    msg = FormataString("##.###.###/####-##", s);
                    //}
                    //else
                    //{
                    //    throw new Exception("C.N.P.J. inválido!");
                    //}
                }
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static bool ValidaCnpj(string cnpj)
        {
            try
            {
                int i = 0;
                int a = 0;
                int n1 = 0;
                int n2 = 0;

                cnpj = Strings.Trim(cnpj);

                if (cnpj.Length != 11 || cnpj == "11111111111111" ||
                    cnpj == "22222222222222" || cnpj == "33333333333333" || cnpj == "44444444444444" ||
                    cnpj == "55555555555555" || cnpj == "66666666666666" || cnpj == "77777777777777" ||
                    cnpj == "88888888888888" || cnpj == "99999999999999")
                {
                    return false;
                }

                for (a = 0; a <= 1; a++)
                {
                    n1 = 0;
                    for (i = 1; i <= 9 + a; i++)
                    {
                        n1 = Convert.ToInt32(n1 + Conversion.Val(Strings.Mid(cnpj, i, 1)) * (11 + a - i));
                    }
                    n2 = 11 - (n1 - (Conversion.Int(n1 / 11) * 11));

                    if (n2 == 10 | n2 == 11) n2 = 0;
                    if (n2 != Conversion.Val(Strings.Mid(cnpj, 10 + a, 1)))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                throw new Exception("C.N.P.J. inválido!");
            }
        }

        #endregion

        #endregion

        #region Função que criptografa senha

        public static string GeraHash(string Senha)
        {
            //criar um novo objeto encoding para assegura o padrão da senha
            UnicodeEncoding ue = new UnicodeEncoding();

            //retorna um byte array baseado na senha enviada
            Byte[] byteSourceText = ue.GetBytes(Senha);

            //Instancia um objeto MD5
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //calcula o valor do HASH para a senha enviada
            Byte[] byteHash = md5.ComputeHash(byteSourceText);

            //Convert o valor obtido em String
            return Convert.ToBase64String(byteHash);
        }

        #endregion
        
        /// Manipulação dos Formulários, abertura, fechamento e centralização
        #region ### Manipulação dos Formularios ###

        public static void CentralizarForm(Form formulario)
        {
            int x = formulario.Left + (formulario.Parent.Width / 2) - (formulario.Width / 2);
            int y = formulario.Top + (formulario.Parent.Height / 2) - (formulario.Height / 2);
            formulario.Location = new Point(x, y);
        }

        public static void AbreForm(Form formulario)
        {
            DefineVisibilidade();
            for (int i = 0; i < formularios.Count; i++)
            {
                if (formulario.Name.Equals(formularios[i].Name))
                {
                    formularios[i].Show();
                    return;
                }
            }
            formularios.Add(formulario);
            formulario.Show();
        }

        private static void Fecha(Form formulario)
        {
            if (formularios.Contains(formulario))
            {
                for (int i = 0; i < formularios.Count; i++)
                {
                    if (formulario.Name.Equals(formularios[i].Name))
                    {
                        formularios[i].Dispose();
                        formularios.Remove(formulario);
                        return;
                    }
                }
            }
        }
        private static void DefineVisibilidade()
        {
            for (int i = 0; i < formularios.Count; i++)
            {
                formularios[i].Visible = false;
            }
        }

        private static Dictionary<Type, Form> Instancias = new Dictionary<Type, Form>();

        public static void AbrirFormulario<T>() where T : Form
        {
            Form formulario;
            Type tipoFormulario = typeof(T);

            if (!Instancias.ContainsKey(tipoFormulario))
            {
                formulario = Activator.CreateInstance<T>();
                Instancias.Add(tipoFormulario, formulario);
                formulario.Show();
            }
            else
            {
                formulario = Instancias[tipoFormulario];
            }

            formulario.BringToFront();
        }

        #endregion

        #region ### Funções que tratam da liberação e bloqueios dos acessos ###

        /// <summary>
        /// Função que verifica se o Usuario a ser editado é administrador
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public static bool liberaEdicaoAdm(int Codigo)
        {
            try
            {
                bool retorno = false;
                int UsuarioConectado = Convert.ToInt32(modulos.CodUsuario);
                if (Codigo.Equals(1))
                {
                    if (UsuarioConectado.Equals(Codigo))
                    {
                        retorno = true;
                    }
                    else
                    {
                        retorno = false;
                        throw new Exception(modulos.acessoNegado);
                    }
                }
                else
                {
                    retorno = true;
                }

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que verifica se o usuario tem permissão para acessar determinada área
        /// <para>[listaAcesso: Informar a lista de acessos presente no formulario], 
        /// [rotina: Informar a rotina a ser analisada], [dataGrid: Infomar o Grid para analisar se contem dados]</para>
        /// </summary>
        /// <param name="listaAcesso"></param>
        /// <param name="rotina"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static bool liberacoes(int rotina, DataGridView dataGrid)
        {
            bool retorno = false;
            if (modulos.Supervisor.Equals("Sim"))
            {
                if (dataGrid.Rows.Count > 0)
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                }
            }
            else
            {
                foreach (MOD_acessos entAcesso in modulos.listaLibAcesso)
                {
                    if (Convert.ToInt32(entAcesso.CodRotina).Equals(rotina))
                    {
                        if (dataGrid.Rows.Count > 0)
                        {
                            retorno = true;
                            break;
                        }
                        else
                        {
                            retorno = false;
                        }
                    }
                    else
                    {
                        retorno = false;
                    }
                }
            }

            return retorno;
        }
        /// <summary>
        /// Função que verifica se o usuario tem permissão para acessar determinada área
        /// <para>[listaAcesso: Informar a lista de acessos presente no formulario], 
        /// [rotina: Informar a rotina a ser analisada]</para>
        /// </summary>
        /// <param name="listaAcesso"></param>
        /// <param name="rotina"></param>
        /// <returns></returns>
        public static bool liberacoes(int rotina)
        {
            bool retorno = false;
            if (modulos.Supervisor.Equals("Sim"))
            {
                retorno = true;
            }
            else
            {
                foreach (MOD_acessos entAcesso in modulos.listaLibAcesso)
                {
                    if (Convert.ToInt32(entAcesso.CodRotina).Equals(rotina))
                    {
                        retorno = true;
                        break;
                    }
                    else
                    {
                        retorno = false;
                    }
                }
            }

            return retorno;
        }

        #endregion

    }
}