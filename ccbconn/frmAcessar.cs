using BLL.validacoes.Formularios;
using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using BLL.validacoes.Exceptions;
using BLL.uteis;
using ENT.uteis;
using System.Collections.Generic;
using BLL.validacoes;
using BLL.Funcoes;
using System.Data.SqlClient;
using System.Drawing;

namespace ccbconn
{
    public partial class frmAcessar : Form
    {
        public frmAcessar()
        {
            InitializeComponent();

            try
            {
                ///Formata o Grid que mostrará as empresas cadastradas
                montarGridRegional();
                pctVersao.Image = imgAcessar.Images[0];
                pctBaixar.Image = imgAcessar.Images[0];
                pctCopiar.Image = imgAcessar.Images[0];
                pctCopiarArquivo.Image = imgAcessar.Images[0];
                pctPrepara.Image = imgAcessar.Images[0];

#warning Habilitar para usar
                /////define a extensão que vai ser selecionada
                //arquivos = diretorio.GetFiles("*.mdf");

                ///Faz um Loop na pasta onde se encontra a base de dados, verificando
                ///quais as bases existentes
                //foreach (FileInfo arquivo in arquivos)
                //{
                //    cboConexao.Items.Add(arquivo);
                //    cboConexao.DisplayMember = arquivo.Name;
                //    cboConexao.ValueMember = arquivo.DirectoryName;
                //}
                //cboConexao.SelectedIndex = -1;
                //caminho = @"Data Source=SERVMUNDO\CCBSQLEXPRESS;Initial Catalog=CCB_Musica;User Id=SA; Password=@mf170408";
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }

        #region Declarações

        clsException excp;
        string usuarioLogado = Environment.UserName;
        conectarBanco formulario;

        BLL_regional objBLL_Regional = null;
        BLL_parametros objBLL_Param = null;

        List<MOD_regional> listaRegional = null;
        List<MOD_parametros> listaParam = null;

        /// <summary>
        /// Variavel que obtem o codigo da empresa a acessar o sistema
        /// </summary>
        string Codigo;

        /// <summary>
        /// Variavel que armazena a string de Conexão do Banco de Dados
        /// </summary>
        string caminho;

        /// <summary>
        /// Define o local do diretorio que está as base de dados
        /// </summary>
        DirectoryInfo diretorio = new DirectoryInfo(@"C:\CCB\Dados");
        FileInfo[] arquivos;

        #endregion

        private void gridRegional_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (gridRegional.RowCount > 0)
            {
                gridRegional.Enabled = true;
                gridRegional.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                btnConectar.Enabled = true;
            }
            else
            {
                gridRegional.Enabled = false;
                gridRegional.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gray;
                btnConectar.Enabled = false;
            }
        }
        private void gridRegional_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Codigo = gridRegional[0, gridRegional.CurrentRow.Index].Value.ToString();
                //caminhoBD = gridRegional[3, gridRegional.CurrentRow.Index].Value.ToString();
            }
            catch (Exception ex)
            {
                excp = new clsException(ex);
            }
        }
        private void btnConexao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                //buscando as empresas cadastradas
                objBLL_Param = new BLL_parametros();
                listaParam = objBLL_Param.buscarRegional(string.Empty);

                if (listaParam.Count > 1)
                {
                    MessageBox.Show("Essa Base de Dados possui várias regionais cadastradas!" + "\n" + "Selecione abaixo com qual deseja trabalhar!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                //carrega o gridEmpresa com as empresas contantes na Base de Dados selecionada
                carregarRegional();
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
        private void cboConexao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lblCaminho.Text = cboConexao.ValueMember + @"\" + cboConexao.Text;
                modulos.CaminhoBD = caminho;
                //modulos.CaminhoBD = @"Data Source=.\SQLEXPRESS;AttachDbFilename=" + lblCaminho.Text + ";Integrated Security=True;Connect Timeout=30;User Instance=True";
                modulos.preencheStrConexao();
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
        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                VerificaAtualizacao();
                BaixarAtualizacao();
                AtualizaServidor();
                CopiarDiretorio();
                PreparaSistema();
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
        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }

        #region Funções privadas para iniciar o sistema

        /// <summary>
        /// Copia os arquivos atualizados para a pasta do sistema
        /// </summary>
        private void CopiarDiretorio()
        {
            try
            {
                //Configuração para Regional de Campo Grande
                string folderName = @"C:\Users\" + usuarioLogado + @"\AppData\Local\SistemaCCB\";
                DirectoryInfo dirOrigem = new DirectoryInfo(@"C:\SistemaCCB\");

                //////Configuração para Regional de Cascavel
                //string folderName = @"C:\Users\" + usuarioLogado + @"\AppData\Local\SistemaCCB_Cascavel\";
                //DirectoryInfo dirOrigem = new DirectoryInfo(@"C:\SistemaCCB_Cascavel\");

                DirectoryInfo dirDestino = new DirectoryInfo(folderName);
                CopiarDiretorio(dirOrigem.FullName, dirDestino.FullName, true);

                pctCopiarArquivo.Image = imgAcessar.Images[1];
                pctCopiarArquivo.Update();
                Thread.Sleep(100);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Verifica se existe atualização no servidor disponivel
        /// </summary>
        private void VerificaAtualizacao()
        {
            pctVersao.Image = imgAcessar.Images[1];
            pctVersao.Update();
            Thread.Sleep(100);
        }

        /// <summary>
        /// Caso tenha atualização no servidor, faz o download
        /// </summary>
        private void BaixarAtualizacao()
        {
            pctBaixar.Image = imgAcessar.Images[1];
            pctBaixar.Update();
            Thread.Sleep(100);
        }

        /// <summary>
        /// Faz a atualização dos arquivos no servidor
        /// </summary>
        private void AtualizaServidor()
        {
            pctCopiar.Image = imgAcessar.Images[1];
            pctCopiar.Update();
            Thread.Sleep(100);
        }

        /// <summary>
        /// Faz a conexão com o banco de dados para verificar se está tudo correto
        /// </summary>
        private void PreparaSistema()
        {
            try
            {

                bool retorno;
                formulario = new conectarBanco();
                formulario.Show();
                formulario.Refresh();

                pctPrepara.Image = imgAcessar.Images[1];
                pctPrepara.Update();
                Thread.Sleep(200);

                retorno = formulario.conectar();

                if (retorno.Equals(true))
                {
                    modulos.listaParametros = listaParam;
                    modulos.CodRegional = Codigo;

                    //Configuração para Regional de Campo Grande
                    Process.Start(@"C:\Users\" + usuarioLogado + @"\AppData\Local\SistemaCCB\ccbprinc.exe");

                    ////Configuração para Regional de Cascavel
                    //Process.Start(@"C:\Users\" + usuarioLogado + @"\AppData\Local\SistemaCCB_Cascavel\ccbprinc.exe");
                    Close();
                    Dispose();
                }
                else
                {
                    cboConexao.Focus();
                }
            }
            catch (Exception ex)
            {
                cboConexao.Focus();
                throw ex;
            }
            finally
            {
                formulario.Close();
                formulario.Dispose();
            }
        }

        /// <summary>
        /// Função que copia os arquivos atualizados para o diretorio padrão
        /// </summary>
        /// <param name="sourceDirName"></param>
        /// <param name="destDirName"></param>
        /// <param name="copySubDirs"></param>
        private static void CopiarDiretorio(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                var dir = new DirectoryInfo(sourceDirName);
                var dirs = dir.GetDirectories();

                // Verifica se o diretório Original Existe.
                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Pasta não localizada para cópia dos arquivos!" + "\n" + "Caminho: "
                        + sourceDirName);
                }

                // Se não houver diretório, cria um novo
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);
                }


                // Verifica os arquivos dentro do diretório e copia.
                var files = dir.GetFiles();

                foreach (var file in files)
                {
                    // Combina os valores de uma pasta a outra.
                    var temppath = Path.Combine(destDirName, file.Name);

                    // copia os arquivos.
                    file.CopyTo(temppath, true);
                }

                // Verifica se há subdirerótios na pasta.
                if (!copySubDirs) return;

                foreach (var subdir in dirs)
                {
                    // Cria o subdiretório.
                    var temppath = Path.Combine(destDirName, subdir.Name);

                    // Copia os Subdiretórios.
                    CopiarDiretorio(subdir.FullName, temppath, copySubDirs);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que carrega as Empresas constantes no Banco de Dados
        /// </summary>
        internal void carregarRegional()
        {
            try
            {
                List<MOD_regional> listaNova = new List<MOD_regional>();
                foreach (MOD_parametros objEnt in listaParam)
                {
                    MOD_regional ent = new MOD_regional();

                    ent.CodRegional = objEnt.listaRegional[0].CodRegional;
                    ent.Descricao = objEnt.listaRegional[0].Descricao;
                    ent.Codigo = objEnt.listaRegional[0].Codigo;
                    ent.CaminhoBD = objEnt.listaRegional[0].CaminhoBD;
                    ent.Estado = objEnt.listaRegional[0].Estado;

                    listaNova.Add(ent);
                }
                montarGridRegional();
                ///vincula a lista ao DataSource do DataGriView
                gridRegional.DataSource = listaNova;
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
        /// Função que monta o DataGrid Empresa
        /// </summary>
        private void montarGridRegional()
        {
            try
            {
                gridRegional.AutoGenerateColumns = false;
                gridRegional.DataSource = null;
                gridRegional.Columns.Clear();
                gridRegional.RowTemplate.Height = 18;

                ///nessas linhas abaixo é que estão definidas as colunas do DataGridView
                ///iniciando pela 1ª coluna
                DataGridViewTextBoxColumn colCodRegional = new DataGridViewTextBoxColumn();
                colCodRegional.DataPropertyName = "CodRegional";
                colCodRegional.HeaderText = "Código";
                colCodRegional.Width = 60;
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
                colCodigo.HeaderText = "Identificação";
                colCodigo.Width = 100;
                colCodigo.Frozen = false;
                colCodigo.MinimumWidth = 70;
                colCodigo.ReadOnly = true;
                colCodigo.FillWeight = 100;
                colCodigo.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCodigo.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colDescricao = new DataGridViewTextBoxColumn();
                colDescricao.DataPropertyName = "Descricao";
                colDescricao.HeaderText = "Centro de Região - Regional";
                colDescricao.Name = "Descricao";
                colDescricao.Width = 200;
                colDescricao.Frozen = false;
                colDescricao.MinimumWidth = 120;
                colDescricao.ReadOnly = true;
                colDescricao.FillWeight = 100;
                colDescricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                colDescricao.Visible = true;
                ///3ª coluna
                DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
                colEstado.DataPropertyName = "Estado";
                colEstado.HeaderText = "Estado";
                colEstado.Name = "Estado";
                colEstado.Width = 50;
                colEstado.Frozen = false;
                colEstado.MinimumWidth = 40;
                colEstado.ReadOnly = true;
                colEstado.FillWeight = 100;
                colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colEstado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                colEstado.Visible = true;
                ///4ª coluna
                DataGridViewTextBoxColumn colCaminho = new DataGridViewTextBoxColumn();
                colCaminho.DataPropertyName = "CaminhoBD";
                colCaminho.HeaderText = "CaminhoBD";
                colCaminho.Name = "CaminhoBD";
                colCaminho.Width = 180;
                colCaminho.Frozen = false;
                colCaminho.MinimumWidth = 150;
                colCaminho.ReadOnly = true;
                colCaminho.FillWeight = 100;
                colCaminho.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                colCaminho.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                colCaminho.MaxInputLength = 500;
                colCaminho.Visible = false;
                ///aqui é adicionado as colunas no datagridview
                gridRegional.Columns.Add(colCodRegional);
                gridRegional.Columns.Add(colCodigo);
                gridRegional.Columns.Add(colDescricao);
                gridRegional.Columns.Add(colEstado);
                gridRegional.Columns.Add(colCaminho);
                ///feito um refresh para fazer a atualização do datagridview
                gridRegional.Refresh();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}