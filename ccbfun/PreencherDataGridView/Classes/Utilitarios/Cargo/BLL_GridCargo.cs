using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLL.Funcoes
{
    public class BLL_GridCargo : IBLL_DataGridView
    {

        ///<summary> Montar DataGrid Cargo
        ///funcao que monta o datagrid, essa funcao é generica para todos os datagridview
        ///que consulta Cargo, devendo somente informar o nome do datagridview que é
        ///passado como parametro
        ///<para>Parametros Tabela:</para>
        ///<para> - Tabela: UsuarioCargo, Relatorios</para>
        ///</summary>
        public DataGridView MontarGrid(DataGridView dataGrid, string Tabela)
        {
            dataGrid.AutoGenerateColumns = false;
            dataGrid.DataSource = null;
            dataGrid.Columns.Clear();
            dataGrid.RowTemplate.Height = 18;

            if (Tabela.Equals("UsuarioCargo"))
            {
                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
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

                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.HeaderText = "Ministério/Cargo";
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

                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.HeaderText = "Ministério/Cargo";
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

                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.HeaderText = "Ministério/Cargo";
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
                DataGridViewTextBoxColumn colCodCargo = new DataGridViewTextBoxColumn();
                colCodCargo.DataPropertyName = "CodCargo";
                colCodCargo.HeaderText = "Código";
                colCodCargo.Name = "CodCargo";
                colCodCargo.Width = 60;
                colCodCargo.Frozen = false;
                colCodCargo.MinimumWidth = 50;
                colCodCargo.ReadOnly = true;
                colCodCargo.FillWeight = 100;
                colCodCargo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                colCodCargo.Visible = true;

                DataGridViewTextBoxColumn colSigla = new DataGridViewTextBoxColumn();
                colSigla.DataPropertyName = "SiglaCargo";
                colSigla.Name = "SiglaCargo";
                colSigla.HeaderText = "Sigla";
                colSigla.Width = 60;
                colSigla.Frozen = false;
                colSigla.MinimumWidth = 50;
                colSigla.ReadOnly = true;
                colSigla.FillWeight = 100;
                colCodCargo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colSigla.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colSigla.Visible = true;

                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "DescCargo";
                colDescricao.Name = "DescCargo";
                colDescricao.HeaderText = "Ministério/Cargo";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colDescricao.Visible = true;

                DataGridViewTextBoxColumn colDepart = new DataGridViewTextBoxColumn();
                colDepart.DataPropertyName = "DescDepartamento";
                colDepart.Name = "DescDepartamento";
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

            return dataGrid;
        }

        public void Dispose() { }
    }
}