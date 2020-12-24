using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ENT.uteis;
using BLL.uteis;
using BLL.Funcoes;
using System.Data.SqlClient;
using ENT.Erros;
using BLL.pessoa;
using ENT.pessoa;
using BLL.validacoes.Exceptions;
using ENT.acessos;
using BLL.validacoes;
using Microsoft.VisualBasic;
using BLL.acessos;
using BLL.Usuario;
using BLL.validacoes.Controles;
using ENT.Session;
using BLL.Valida;

namespace ccbusua
{
    public partial class frmUsuario : Form
    {
        public frmUsuario(Form forms, DataGridView gridPesquisa, List<MOD_usuario> lista)
        {
            InitializeComponent();

            try
            {

                //indica que esse formulario foi aberto por outro
                formChama = forms;
                //informa o datagrid que solicitou a pesquisa
                dataGrid = gridPesquisa;

                //carregando a lista de permissões de acesso.
                listaAcesso = MOD_Session.ListaAcessoLogado;

                ///Recebe a lista e armazena
                listaUsuario = lista;

                ///define a data atual como data do cadastro
                txtDataCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");

                ///preenche o comboRegional
                apoio.carregaComboRegional(cboRegional);
                //carregaCCB();

                if (lista != null && lista.Count > 0)
                {
                    //carrega os dados da lista
                    preencher(lista);

                    if (listaUsuCargo == null || listaUsuCargo.Count < 1)
                    {
                        try
                        {
                            apoio.Aguarde("Carregando ministérios...");
                            //carregaCargos(txtCodigo.Text);

                            //Carrega os cargos
                            preencherGrid("Cargo", txtCodigo.Text, gridCargo);
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
                    if (listaUsuReg == null || listaUsuReg.Count < 1)
                    {
                        try
                        {
                            apoio.Aguarde("Carregando microrregiões...");
                            //carregaCCB(txtCodigo.Text);

                            //Carrega as Regiões
                            preencherGrid("Regiao", txtCodigo.Text, gridRegiao);
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
                    if (listaUsuCCB == null || listaUsuCCB.Count < 1)
                    {
                        try
                        {
                            apoio.Aguarde("Carregando comum congregação...");
                            //carregaCCB(txtCodigo.Text);

                            //Carrega as Regiões e Comuns
                            preencherGrid("Comum", txtCodigo.Text, gridComum);
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
                else
                {
                    carregarAcessos();
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

        #region declaracoes

        clsException excp;

        List<MOD_acessos> listaAcesso = null;

        IBLL_buscaPessoa objBLL_Pessoa = null;
        List<MOD_pessoa> listaPessoa = null;

        BLL_usuario objBLL = null;
        MOD_usuario objEnt = null;
        List<MOD_usuario> listaUsuario = null;


        List<MOD_usuarioCargo> listaUsuCargo = null;
        List<MOD_cargo> listaCargo = null;

        BindingList<MOD_usuarioCCB> listaUsuCCB = null;
        List<MOD_ccb> listaCCBTodas = null;
        List<MOD_ccb> listaCCB = null;
        BindingSource objBinding_UsuCCB = null;

        BindingList<MOD_usuarioRegiao> listaUsuReg = null;
        List<MOD_regiaoAtuacao> listaRegiao = null;
        BindingSource objBinding_UsuReg = null;

        List<MOD_acessos> listaAcessoNode = new List<MOD_acessos>();

        BLL_modulos objBLL_Mod = null;
        BLL_subModulos objBLL_SubMod = null;
        BLL_programas objBLL_Prog = null;
        BLL_rotinas objBLL_Rot = null;
        BLL_acessos objBLL_UsuAces = null;
        List<MOD_rotinas> listaRotinas = null;
        List<MOD_modulos> listaMod = null;
        List<MOD_subModulos> listaSubMod = null;
        List<MOD_programas> listaProg = null;
        List<MOD_acessos> listaAcesUsu = null;
        List<MOD_acessos> listaAcesNods = null;

        //formulário de erros
        MOD_erros objEnt_Erros = null;
        List<MOD_erros> listaErros;
        bool blnValida;

        bool flag;

        Form formulario;
        Form formChama;
        DataGridView dataGrid;

        //variaveis
        string CodComum;
        string CodRegiao;
        string CodCargo;

        #endregion

        #region eventos do formulario

        private void txtPessoa_Leave(object sender, EventArgs e)
        {
            if (!txtPessoa.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    carregaPessoa(txtPessoa.Text);
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
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmPes");
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
        private void chkSupervisor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkSupervisor.Checked.Equals(true))
                {
                    tvwAcesso.Enabled = false;
                    foreach (TreeNode tn in tvwAcesso.Nodes)
                    {
                        tn.Checked = true;
                    }
                }
                else
                {
                    tvwAcesso.Enabled = true;
                    //foreach (TreeNode tn in tvwAcesso.Nodes)
                    //{
                    //    tn.Checked = false;
                    //}
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
        private void btnSenha_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                abrirForm("frmSen");
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
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (!txtUsuario.Text.Trim().Equals(string.Empty))
            {
                try
                {
                    apoio.Aguarde();
                    ValidarLogin();
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

        #region Aba Avançado

        #region Grid Microrregião

        private void cboRegional_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                preencherGrid("Regiao", txtCodigo.Text, gridRegiao);
                preencherGrid("Comum", CodRegiao, gridComum);
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
        private void gridRegiao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridRegiao != null || gridRegiao.RowCount > 0)
                {
                    if (listaUsuReg[e.RowIndex].Marcado.Equals(true))
                    {
                        listaUsuReg[e.RowIndex].Marcado = false;

                        foreach (MOD_usuarioCCB entCCB in listaUsuCCB)
                        {
                            if (entCCB.CodRegiao.Equals(listaUsuReg[e.RowIndex].CodRegiao))
                            {
                                entCCB.Marcado = false;
                            }
                        }
                    }
                    else
                    {
                        listaUsuReg[e.RowIndex].Marcado = true;
                    }
                    gridRegiao.Refresh();

                }
                CodRegiao = preencherSelecionados("Regiao", gridRegiao);
                preencherGrid("Comum", txtCodigo.Text, gridComum);
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
        private void btnSelRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_usuarioRegiao entReg in listaUsuReg)
                {
                    entReg.Marcado = true;
                }
                gridRegiao.Refresh();

                CodRegiao = preencherSelecionados("Regiao", gridRegiao);
                preencherGrid("Comum", txtCodigo.Text, gridComum);
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
        private void btnDesRegiao_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_usuarioRegiao entReg in listaUsuReg)
                {
                    entReg.Marcado = false;
                }
                gridRegiao.Refresh();

                CodRegiao = preencherSelecionados("Regiao", gridRegiao);
                preencherGrid("Comum", txtCodigo.Text, gridComum);
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

        #endregion

        #region Grid Cargo

        private void btnSelCargo_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_usuarioCargo entCargo in listaUsuCargo)
                {
                    entCargo.Marcado = true;
                }
                gridCargo.Refresh();
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
        private void btnDesCargo_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_usuarioCargo entCargo in listaUsuCargo)
                {
                    entCargo.Marcado = false;
                }
                gridCargo.Refresh();
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
        private void gridCargo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridCargo != null || gridCargo.RowCount > 0)
                {
                    if (listaUsuCargo[e.RowIndex].Marcado.Equals(true))
                    {
                        listaUsuCargo[e.RowIndex].Marcado = false;
                    }
                    else
                    {
                        listaUsuCargo[e.RowIndex].Marcado = true;
                    }
                    gridCargo.Refresh();
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

        #region Grid Comum

        private void btnSelComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_usuarioCCB entCCB in listaUsuCCB)
                {
                    entCCB.Marcado = true;
                }
                gridComum.Refresh();
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
        private void btnDesComum_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                foreach (MOD_usuarioCCB entCCB in listaUsuCCB)
                {
                    entCCB.Marcado = false;
                }
                gridComum.Refresh();
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
        private void gridComum_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //ao clicar na linha marca ou desmarca a primeira coluna
                //verifica a situação da celula
                if (gridComum != null || gridComum.RowCount > 0)
                {
                    if (listaUsuCCB[e.RowIndex].Marcado.Equals(true))
                    {
                        listaUsuCCB[e.RowIndex].Marcado = false;
                    }
                    else
                    {
                        listaUsuCCB[e.RowIndex].Marcado = true;
                    }
                    gridComum.Refresh();
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

        #endregion

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.AguardeGravar();
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
            finally
            {
                apoio.FecharAguardeGravar();
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
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            try
            {
                //verifica a permissão do usuario acessar as abas do cadastro
                //desabilita as tabpages para verificar o acesso
                //define as imagens
                verPermAcessos();
                verPermSupervisor();
                verPermAlteraSenha();
                verPermAlteraCargo();
                verPermAlteraCCB();
                pctBaixa.Image = imgUsuario.Images[0];
                pctMedia.Image = imgUsuario.Images[1];
                pctAlta.Image = imgUsuario.Images[2];
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
        private void frmUsuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Text.Equals("Visualizando Usuário"))
                {
                    e.Cancel = false;
                }
                else
                {
                    DialogResult sair;
                    sair = MessageBox.Show(modulos.msgSalvar, "Atenção", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (sair.Equals(DialogResult.Yes))
                    {
                        salvar();
                    }
                    else if (sair.Equals(DialogResult.Cancel))
                    {
                        e.Cancel = true;
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
        private void frmUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            formChama.Enabled = true;
        }
        private void tabUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabUsuario.SelectedIndex.Equals(0))
            {
                lblSeg.Visible = true;
                pctAlta.Visible = true;
                lblAlta.Visible = true;
                pctMedia.Visible = true;
                lblMedia.Visible = true;
                pctBaixa.Visible = true;
                lblBaixa.Visible = true;
            }
            else if (tabUsuario.SelectedIndex.Equals(1))
            {
                lblSeg.Visible = false;
                pctAlta.Visible = false;
                lblAlta.Visible = false;
                pctMedia.Visible = false;
                lblMedia.Visible = false;
                pctBaixa.Visible = false;
                lblBaixa.Visible = false;

                if (listaUsuCargo == null || listaUsuCargo.Count < 1)
                {
                    try
                    {
                        apoio.Aguarde("Carregando ministérios...");
                        //carregaCargos(txtCodigo.Text);

                        //Carrega os cargos
                        preencherGrid("Cargo", txtCodigo.Text, gridCargo);
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
                if (listaUsuReg == null || listaUsuReg.Count < 1)
                {
                    try
                    {
                        apoio.Aguarde("Carregando microrregiões...");
                        //carregaCCB(txtCodigo.Text);

                        //Carrega as Regiões
                        preencherGrid("Regiao", txtCodigo.Text, gridRegiao);
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
                if (listaUsuCCB == null || listaUsuCCB.Count < 1)
                {
                    try
                    {
                        apoio.Aguarde("Carregando comum congregação...");
                        //carregaCCB(txtCodigo.Text);

                        //Carrega as Regiões e Comuns
                        preencherGrid("Comum", txtCodigo.Text, gridComum);
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
        }

        private void tvwAcesso_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (!flag)
                {
                    flag = true;
                    MarcaFilhos(e.Node);
                    MarcaPais(e.Node);
                    flag = false;
                }
            }
            catch
            {
                flag = false;
            }
        }

        #endregion

        #region funcoes privadas e publicas

        /// <summary>
        /// Função que resume as informações para enviar a classe de negocios para salvar
        /// </summary>
        private void salvar()
        {
            try
            {
                if (ValidarControles().Equals(true))
                {
                    objBLL = new BLL_usuario();

                    if (Convert.ToInt64(txtCodigo.Text).Equals(0))
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.inserir(criarTabela());
                    }
                    else
                    {
                        //chama a rotina da camada de negocios para efetuar inserção ou update
                        objBLL.salvar(criarTabela());
                    }

                    new BLL_Session(Convert.ToInt64(objEnt.CodUsuario), out listaUsuario);
                    apoio.preencheUsuarioCCB(objEnt.CodUsuario);
                    apoio.preencheUsuarioCargo(objEnt.CodUsuario);

                    //conversor para retorno ao formulario que chamou
                    if (formChama.Name.Equals("frmUsuarioBusca"))
                    {
                        ((frmUsuarioBusca)formChama).carregaGrid("Codigo", objEnt.CodUsuario, dataGrid);
                    }

                    FormClosing -= new FormClosingEventHandler(frmUsuario_FormClosing);

                    Close();

                    FormClosing += new FormClosingEventHandler(frmUsuario_FormClosing);

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
                if (lblNomePessoa.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Pessoa! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtUsuario.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Login! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (txtSenha.Text.Equals(string.Empty))
                {
                    blnValida = false;
                    objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Senha! Campo obrigatório.";
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
        /// <summary>
        /// Funcão que valida o Login digitado, caso tenha outro Usuario
        /// cadastrado com esse Login retorna o cadastro para edição
        /// </summary>
        private void ValidarLogin()
        {
            try
            {
                objBLL = new BLL_usuario();
                List<MOD_usuario> listaValidaLogin = new List<MOD_usuario>();
                listaValidaLogin = objBLL.buscarUsuario(txtUsuario.Text, "Sim");

                if (listaValidaLogin.Count > 0)
                {
                    if (!Convert.ToInt64(listaValidaLogin[0].CodUsuario).Equals(Convert.ToInt64(txtCodigo.Text)))
                    {
                        if (MessageBox.Show("Jà existe outro Usuário Ativo utilizando esse login!" + "\n" +
                                            "Código: " + listaValidaLogin[0].CodUsuario + '\n' +
                                            "Pessoa: " + listaValidaLogin[0].Nome + '\n' +
                                            "Usuário: " + listaValidaLogin[0].Usuario + '\n' + '\n' +
                                            "Deseja editar esse Usuário?",
                                            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            preencher(listaValidaLogin);
                        }
                        else
                        {
                            txtUsuario.Text = string.Empty;
                            txtUsuario.Focus();
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
        /// Funcão que valida a Pessoa digitado, caso tenha outro Usuario
        /// cadastrado para Essa Pessoa retorna o cadastro para edição
        /// </summary>
        private void ValidarPessoa()
        {
            try
            {
                objBLL = new BLL_usuario();
                List<MOD_usuario> listaValidaPessoa = new List<MOD_usuario>();
                listaValidaPessoa = objBLL.buscarPessoa(txtPessoa.Text, "Sim");

                if (listaValidaPessoa.Count > 0)
                {
                    if (!Convert.ToInt64(listaValidaPessoa[0].CodUsuario).Equals(Convert.ToInt64(txtCodigo.Text)))
                    {
                        if (MessageBox.Show("Jà existe um Usuário Ativo para essa Pessoa!" + "\n" +
                                            "Código: " + listaValidaPessoa[0].CodUsuario + '\n' +
                                            "Pessoa: " + listaValidaPessoa[0].Nome + '\n' +
                                            "Usuário: " + listaValidaPessoa[0].Usuario + '\n' + '\n' +
                                            "Deseja editar esse Usuário?",
                                            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            preencher(listaValidaPessoa);
                        }
                        else
                        {
                            txtPessoa.Text = string.Empty;
                            lblNomePessoa.Text = string.Empty;
                            txtPessoa.Focus();
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
        /// Função que preenche os valores das entidades com os valores do Form
        /// </summary>
        /// <returns></returns>
        private MOD_usuario criarTabela()
        {
            try
            {
                objEnt = new MOD_usuario();
                objEnt.CodUsuario = txtCodigo.Text;
                objEnt.CodPessoa = txtPessoa.Text;
                objEnt.Nome = lblNomePessoa.Text;
                objEnt.Usuario = txtUsuario.Text;
                objEnt.Senha = txtSenha.Text;
                objEnt.DataAlteraSenha = txtDataAlteraSenha.Text;
                objEnt.DataCadastro = txtDataCadastro.Text;
                objEnt.Supervisor = chkSupervisor.Checked.Equals(true) ? "Sim" : "Não"; ;
                objEnt.Ativo = chkAtivo.Checked.Equals(true) ? "Sim" : "Não";
                objEnt.AlteraSenha = chkAlteraSenha.Checked.Equals(true) ? "Sim" : "Não";

                //preenche os dados dos acessos
                objEnt.listaAcesso = criarAcessos();

                //retorna o objeto UsuarioRegiao
                if (listaUsuReg != null)
                {
                    objEnt.listaUsuarioRegiao = new BindingList<MOD_usuarioRegiao>();
                    //objEnt.listaUsuarioRegiao = listaUsuReg;
                    objEnt.listaUsuarioRegiao = ((BindingList<MOD_usuarioRegiao>)objBinding_UsuReg.DataSource);
                }
                //retorna o objeto UsuarioCCB
                if (listaUsuCCB != null)
                {
                    objEnt.listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();
                    //objEnt.listaUsuarioCCB = criarTabelaCCB();
                    objEnt.listaUsuarioCCB = ((BindingList<MOD_usuarioCCB>)objBinding_UsuCCB.DataSource);
                }
                //retorna o objeto UsuarioCargo
                if (listaUsuCargo != null)
                {
                    objEnt.listaUsuarioCargo = new List<MOD_usuarioCargo>();
                    objEnt.listaUsuarioCargo = listaUsuCargo;
                }

                //retorna a classe de propriedades preenchida com os textbox
                return objEnt;
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
        /// Função que cria a lista das comuns que serão permitidas
        /// </summary>
        /// <returns></returns>
        private BindingList<MOD_usuarioCCB> criarTabelaCCB()
        {
            try
            {
                BindingList<MOD_usuarioCCB> listaNovaUsuCCB = new BindingList<MOD_usuarioCCB>();

                foreach (DataGridViewRow row in gridComum.Rows)
                {
                    if (row.Cells["Marcado"].Value.Equals(true))
                    {
                        MOD_usuarioCCB entCCB = new MOD_usuarioCCB();

                        entCCB.CodUsuarioCCB = Convert.ToString(row.Cells["CodUsuarioCCB"].Value);
                        entCCB.CodCCB = Convert.ToString(row.Cells["CodCCB"].Value);
                        entCCB.Codigo = Convert.ToString(row.Cells["Codigo"].Value);
                        entCCB.Descricao = Convert.ToString(row.Cells["Descricao"].Value);
                        entCCB.Marcado = true;

                        listaNovaUsuCCB.Add(entCCB);
                    }
                }

                //retorna a classe de propriedades preenchida com os textbox
                return listaNovaUsuCCB;
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
        /// Função que preenche os dados recebidos no formulário
        /// </summary>
        /// <param name="listaPessoa"></param>
        internal void preencher(List<MOD_usuario> listaUsu)
        {
            try
            {
                //informa os valores aos campos recebidos na lista
                txtCodigo.Text = listaUsu[0].CodUsuario;
                txtPessoa.Text = listaUsu[0].CodPessoa;
                lblNomePessoa.Text = listaUsu[0].Nome;
                txtUsuario.Text = listaUsu[0].Usuario;
                txtSenha.Text = listaUsu[0].Senha;
                txtDataAlteraSenha.Text = listaUsu[0].DataAlteraSenha;
                txtDataCadastro.Text = listaUsu[0].DataCadastro;
                chkSupervisor.Checked = listaUsu[0].Supervisor.Equals("Sim") ? true : false;
                chkAtivo.Checked = listaUsu[0].Ativo.Equals("Sim") ? true : false;
                chkAlteraSenha.Checked = listaUsu[0].AlteraSenha.Equals("Sim") ? true : false;

                //Carregar os Acessos
                carregarAcessos();

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
        /// Função que carrega a Pessoa pesquisado pelo Código
        /// </summary>
        /// <param name="vCodPessoa"></param>
        internal void carregaPessoa(string vCodPessoa)
        {
            try
            {
                objBLL_Pessoa = new BLL_buscaPessoaPorCodPessoa();
                listaPessoa = objBLL_Pessoa.Buscar(vCodPessoa);

                if (listaPessoa != null && listaPessoa.Count > 0)
                {
                    txtPessoa.Text = listaPessoa[0].CodPessoa;
                    lblNomePessoa.Text = listaPessoa[0].Nome;

                    ValidarPessoa();
                }
                else
                {
                    abrirForm("frmPes");
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
        private void abrirForm(string form)
        {
            try
            {
                if (form.Equals("frmPes"))
                {
                    txtPessoa.Text = string.Empty;
                    lblNomePessoa.Text = string.Empty;

                    formulario = new frmPesquisaPessoa(this);
                    ((frmPesquisaPessoa)formulario).MdiParent = MdiParent;
                    ((frmPesquisaPessoa)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmPesquisaPessoa)formulario));
                    ((frmPesquisaPessoa)formulario).Show();
                    ((frmPesquisaPessoa)formulario).BringToFront();
                    Enabled = false;
                }
                else if (form.Equals("frmSen"))
                {
                    formulario = new frmSenha(this, listaUsuario);
                    ((frmSenha)formulario).MdiParent = MdiParent;
                    ((frmSenha)formulario).StartPosition = FormStartPosition.Manual;
                    funcoes.CentralizarForm(((frmSenha)formulario));
                    ((frmSenha)formulario).Show();
                    ((frmSenha)formulario).BringToFront();
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
        /// Função que deabilita os controles
        /// </summary>
        internal void disabledForm()
        {
            try
            {
                tabUsuario.Enabled = false;
                btnSalvar.Enabled = false;
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
                tabUsuario.Enabled = true;
                btnSalvar.Enabled = true;

                if (Text.Equals("Inserindo Usuário"))
                {
                    lblSenha.Enabled = true;
                    txtSenha.Enabled = true;
                }
                else
                {
                    lblSenha.Enabled = false;
                    txtSenha.Enabled = false;
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
        /// Função que define o foco do cursor
        /// </summary>
        internal void defineFoco()
        {
            chkAtivo.Focus();
        }

        #region Acessos

        /// <summary>
        /// Função que carrega os módulos, submódulos, programas e rotinas para controle de acesso
        /// </summary>
        internal void carregarAcessos()
        {
            try
            {
                apoio.AguardeAcesso();

                tvwAcesso.Nodes.Clear();

                TreeNode nodeMod = null;
                TreeNode nodeSubMod = null;
                TreeNode nodeProg = null;
                TreeNode nodRot = null;

                #region Adiciona os Módulos

                try
                {
                    //pesquisa que retorna os módulos existentes no sistema
                    objBLL_Mod = new BLL_modulos();
                    listaMod = objBLL_Mod.buscarCod(string.Empty);
                    //faz um loop na lista Módulos para inserir o Node
                    foreach (MOD_modulos entMod in listaMod)
                    {

                        //aqui é criado um novo node para receber a descrição
                        //dos módulos
                        nodeMod = new TreeNode();
                        //é preenchido o propriedade tag com o código do módulo
                        nodeMod.Tag = entMod.CodModulo;
                        //é preenchido a propriedade Text com a descrição do módulo;
                        nodeMod.Text = entMod.DescModulo;
                        //aqui é adicionado o node ao TreeView.
                        tvwAcesso.Nodes.Add(nodeMod);

                        #endregion

                        #region Adiciona Sub Módulos

                        try
                        {
                            //pesquisa que retorna os submódulos existentes no sistema
                            //que pertence ao módulo informado
                            objBLL_SubMod = new BLL_subModulos();
                            listaSubMod = objBLL_SubMod.buscarModulo(entMod.CodModulo);

                            //é feito um loop para pesquisar todos os SubModulo e incluílos 
                            //nos nodes filhos
                            foreach (MOD_subModulos entSub in listaSubMod)
                            {
                                //aqui é criado um novo node para receber a descrição
                                //dos SubModulo recebidos do banco de dados
                                nodeSubMod = new TreeNode();
                                //é preenchido o propriedade tag com o código do SubModulo
                                nodeSubMod.Tag = entSub.CodSubModulo;
                                //é preenchido a propriedade Text com a descrição do SubModulo;
                                nodeSubMod.Text = entSub.DescSubModulo;

                                if (!Convert.ToInt16(entSub.CodSubModulo).Equals(0))
                                {

                                    //aqui é adicionado o node ao TreeView.
                                    this.tvwAcesso.Nodes[nodeMod.Index].Nodes.Add(nodeSubMod);
                                }

                                #endregion

                                #region Adiciona os Programas

                                try
                                {
                                    //aqui é feito uma busca no banco para preencher todos os programas
                                    //que pertence ao Submódulo informado.
                                    objBLL_Prog = new BLL_programas();
                                    listaProg = objBLL_Prog.buscarSubModulo(entSub.CodSubModulo);

                                    //é feito um loop para pesquisar todos os programas e incluílos 
                                    //nos nodes filhos
                                    foreach (MOD_programas entProg in listaProg)
                                    {
                                        //aqui é criado um novo node para receber a descrição
                                        //dos programas recebidos do banco de dados
                                        nodeProg = new TreeNode();
                                        //é preenchido o propriedade tag com o código do programa
                                        nodeProg.Tag = entProg.CodPrograma;
                                        //é preenchido a propriedade Text com a descrição do programa;
                                        nodeProg.Text = entProg.DescPrograma;

                                        MOD_acessoModulos entAcessoMod = new MOD_acessoModulos();
                                        MOD_acessoSubModulos entAcessoSub = new MOD_acessoSubModulos();
                                        MOD_acessoProgramas entAcessoProg = new MOD_acessoProgramas();
                                        MOD_acessoRotinas entAcessoRot = new MOD_acessoRotinas();

                                        if (!Convert.ToInt16(entProg.CodSubModulo).Equals(0))
                                        {
                                            //aqui é adicionado o node ao TreeView.
                                            tvwAcesso.Nodes[nodeMod.Index].Nodes[nodeSubMod.Index].Nodes.Add(nodeProg);
                                        }
                                        #endregion

                                        #region Adiciona as Rotinas

                                        try
                                        {
                                            //aqui é feito uma busca no banco para preencher todos as rotinas
                                            //que este programa contem.
                                            objBLL_Rot = new BLL_rotinas();
                                            listaRotinas = objBLL_Rot.buscarPrograma(entProg.CodPrograma);

                                            //é feito um loop para adicionar os nodes
                                            foreach (MOD_rotinas entRot in listaRotinas)
                                            {

                                                //aqui é criado um novo node para receber a descrição
                                                //dos programas recebidos do banco de dados
                                                nodRot = new TreeNode();
                                                if (!Convert.ToInt64(txtCodigo.Text).Equals(0))
                                                {
                                                    objBLL_UsuAces = new BLL_acessos();
                                                    listaAcesUsu = objBLL_UsuAces.buscarCodAcesso(txtCodigo.Text, entRot.CodRotina);

                                                    if (listaAcesUsu.Count > 0)
                                                    {
                                                        //é preenchido o propriedade name com o código da rotina
                                                        nodRot.Name = listaAcesUsu[0].CodRotina;
                                                        //é preenchido o propriedade tag com o código do acesso
                                                        nodRot.Tag = listaAcesUsu[0].CodAcesso;
                                                        //é preenchido a propriedade Text com a descrição da rotina;
                                                        nodRot.Text = listaAcesUsu[0].DescRotina;
                                                        //é preenchido a propriedade checked;
                                                        nodRot.Checked = listaAcesUsu[0].Marcado;
                                                    }
                                                    else
                                                    {
                                                        //é preenchido o propriedade name com o código da rotina
                                                        nodRot.Name = entRot.CodRotina;
                                                        //é preenchido o propriedade tag com o código do acesso
                                                        //como esse acesso ainda não foi definido ele vai com o valor 0
                                                        nodRot.Tag = 0;
                                                        //é preenchido a propriedade Text com a descrição da rotina;
                                                        nodRot.Text = entRot.DescRotina;
                                                        //é preenchido a propriedade checked;
                                                        nodRot.Checked = false;
                                                    }
                                                }
                                                else
                                                {
                                                    //é preenchido o propriedade name com o código da rotina
                                                    nodRot.Name = entRot.CodRotina;
                                                    //é preenchido o propriedade tag com o código do acesso
                                                    //como esse acesso ainda não foi definido ele vai com o valor 0
                                                    nodRot.Tag = 0;
                                                    //é preenchido a propriedade Text com a descrição da rotina;
                                                    nodRot.Text = entRot.DescRotina;
                                                    //é preenchido a propriedade checked;
                                                    nodRot.Checked = false;
                                                }

                                                if (entRot.DescSeg.Equals("Alta"))
                                                {
                                                    nodRot.ForeColor = Color.Red;
                                                }
                                                else if (entRot.DescSeg.Equals("Média"))
                                                {
                                                    nodRot.ForeColor = Color.Gold;
                                                }
                                                else if (entRot.DescSeg.Equals("Baixa"))
                                                {
                                                    nodRot.ForeColor = Color.Green;
                                                }

                                                if (!entRot.LiberaAcesso.Equals("Não"))
                                                {
                                                    flag = true;
                                                    tvwAcesso.Nodes[nodeMod.Index].Nodes[nodeSubMod.Index].Nodes[nodeProg.Index].Nodes.Add(nodRot);
                                                    MarcaPais(nodRot);
                                                    flag = false;

                                                    ////Função que marca os nodes Pais
                                                    //this.MarcarNosAnteriores(nodRot, nodRot.Checked);
                                                }
                                            }
                                        }

                                        #endregion

                                        //tratamento de erro das Rotinas
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
                                //tratamento de erro dos programas
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
                        //tratamento de erro dos sub-módulos
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
                //tratamento de erro dos módulos
                catch (SqlException exl)
                {
                    throw exl;
                }
                catch (Exception ex)
                {
                    throw ex;
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
            finally
            {
                apoio.FecharAguardeAcesso();
            }
        }

        /// <summary>
        /// Função que percorre o TreeView e verifica os acessos marcados
        /// </summary>
        private List<MOD_acessos> criarAcessos()
        {
            try
            {
                listaAcesNods = new List<MOD_acessos>();
                foreach (TreeNode tn in tvwAcesso.Nodes)
                {
                    List<MOD_acessos> listaFilhos = new List<MOD_acessos>();
                    foreach (TreeNode tnf in tn.Nodes)
                    {
                        List<MOD_acessos> listaNetos = new List<MOD_acessos>();
                        foreach (TreeNode tnn in tnf.Nodes)
                        {
                            List<MOD_acessos> listaBisneto = new List<MOD_acessos>();
                            foreach (TreeNode tnb in tnn.Nodes)
                            {
                                MOD_acessos ent = new MOD_acessos();
                                ent.CodUsuario = objEnt.CodUsuario;
                                ent.CodPessoa = objEnt.CodPessoa;
                                ent.Nome = objEnt.Nome;
                                ent.CodRotina = tnb.Name;
                                ent.Marcado = tnb.Checked;
                                ent.CodAcesso = Convert.ToString(tnb.Tag);

                                listaBisneto.Add(ent);
                            }
                            listaNetos.AddRange(listaBisneto);
                        }
                        listaFilhos.AddRange(listaNetos);
                    }
                    listaAcesNods.AddRange(listaFilhos);
                }
                return listaAcesNods;
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
        /// Função que Marca os nos filhos, ao clica no pai
        /// </summary>
        /// <param name="node"></param>
        private void MarcaFilhos(TreeNode node)
        {
            foreach (TreeNode filho in node.Nodes)
            {
                filho.Checked = node.Checked;
                MarcaFilhos(filho);
            }
        }
        /// <summary>
        /// Função que Marca o nóde pai ao clicar em um filho
        /// </summary>
        /// <param name="node"></param>
        private void MarcaPais(TreeNode node)
        {
            if (node.Parent != null)
            {
                if (node.Checked)
                {
                    node.Parent.Checked = true;
                    MarcaPais(node.Parent);
                }
                else
                {
                    bool Continua = true;

                    foreach (TreeNode irmao in node.Parent.Nodes)
                    {
                        if (irmao.Checked)
                        {
                            Continua = false;
                            break;
                        }
                    }

                    if (Continua)
                    {
                        node.Parent.Checked = false;
                        MarcaPais(node.Parent);
                    }
                }
            }
        }

        #endregion

        #region Aba Avançado

        /// <summary>
        /// Função que carrega os Cargos
        /// </summary>
        /// <param name="CodUsuario"></param>
        private void carregaCargos(string CodUsuario)
        {
            try
            {
                List<MOD_usuarioCargo> listaNova = new List<MOD_usuarioCargo>();

                objBLL = new BLL_usuario();
                listaUsuCargo = objBLL.buscarUsuarioCargo(CodUsuario);

                objBLL = new BLL_usuario();
                listaCargo = objBLL.buscarCargos(CodUsuario);

                foreach (MOD_cargo objEnt_Cargo in listaCargo)
                {
                    MOD_usuarioCargo ent = new MOD_usuarioCargo();

                    ent.CodUsuarioCargo = "0";
                    ent.CodCargo = objEnt_Cargo.CodCargo;
                    ent.DescCargo = objEnt_Cargo.DescCargo;
                    ent.SiglaCargo = objEnt_Cargo.SiglaCargo;
                    ent.Ordem = objEnt_Cargo.Ordem;
                    ent.Marcado = false;

                    listaNova.Add(ent);
                }

                listaUsuCargo.AddRange(listaNova);
                new BLL_GridCargo().MontarGrid(gridCargo, "UsuarioCargo");
                ///vincula a lista ao DataSource do DataGriView
                gridCargo.DataSource = listaUsuCargo;
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
        /// Função que carrega as Comuns
        /// </summary>
        /// <param name="CodUsuario"></param>
        private void carregaCCB()
        {
            try
            {
                BLL_ccb objBLL_CCB = new BLL_ccb();
                listaCCBTodas = new List<MOD_ccb>();
                listaCCBTodas = objBLL_CCB.buscarCod(string.Empty);
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
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// <para> As Pesquisa são por: Regiao, Comum, Cargo</para>
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="DataGrid"></param>
        internal void carregaGrid(string Pesquisa, string Campo1, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("Regiao"))
                {
                    BindingList<MOD_usuarioRegiao> listaNova = new BindingList<MOD_usuarioRegiao>();

                    objBLL = new BLL_usuario();
                    objBinding_UsuReg = new BindingSource();
                    listaNova = objBLL.buscarUsuarioRegiao(Campo1, Convert.ToString(cboRegional.SelectedValue));

                    objBLL = new BLL_usuario();
                    listaRegiao = objBLL.buscarRegiao(Campo1);

                    foreach (MOD_regiaoAtuacao objEnt_Reg in listaRegiao)
                    {
                        MOD_usuarioRegiao ent = new MOD_usuarioRegiao();

                        ent.CodUsuarioRegiao = "0";
                        ent.CodRegiao = objEnt_Reg.CodRegiao;
                        ent.CodigoRegiao = objEnt_Reg.Codigo;
                        ent.DescRegiao = objEnt_Reg.DescRegiao;
                        ent.CodRegional = objEnt_Reg.CodRegional;
                        ent.DescRegional = objEnt_Reg.DescricaoRegional;
                        ent.Marcado = false;

                        listaNova.Add(ent);
                    }

                    objBinding_UsuReg.DataSource = listaNova;
                    listaUsuReg = listaNova;

                    funcoes.gridRegiao(gridRegiao, "UsuarioRegiao");
                    ///vincula a lista ao DataSource do DataGriView
                    gridRegiao.DataSource = objBinding_UsuReg;

                    CodRegiao = preencherSelecionados("Regiao", gridRegiao);
                    preencherGrid("Comum", txtCodigo.Text, gridComum);
                }
                else if (Pesquisa.Equals("Comum"))
                {

                    BindingList<MOD_usuarioCCB> listaNova = new BindingList<MOD_usuarioCCB>();

                    objBLL = new BLL_usuario();
                    objBinding_UsuCCB = new BindingSource();
                    //objBinding_UsuCCB = objBLL.buscarUsuarioCCB(CodUsuario);
                    listaNova = objBLL.buscarUsuarioCCB(Campo1, CodRegiao);
                    objBinding_UsuCCB.DataSource = listaNova;

                    objBLL = new BLL_usuario();
                    listaCCB = objBLL.buscarCCBs(Campo1, CodRegiao);

                    foreach (MOD_ccb objEnt_CCB in listaCCB)
                    {
                        MOD_usuarioCCB ent = new MOD_usuarioCCB();

                        ent.CodUsuarioCCB = "0";
                        ent.CodCCB = objEnt_CCB.CodCCB;
                        ent.Codigo = objEnt_CCB.Codigo;
                        ent.Descricao = objEnt_CCB.Descricao;
                        ent.CodRegiao = objEnt_CCB.CodRegiao;
                        ent.Marcado = false;

                        listaNova.Add(ent);
                    }

                    objBinding_UsuCCB.DataSource = listaNova;
                    listaUsuCCB = listaNova;

                    //objBinding_UsuCCB.Add(listaNova);
                    funcoes.gridCCB(gridComum, "UsuarioCCB");
                    ///vincula a lista ao DataSource do DataGriView
                    gridComum.DataSource = objBinding_UsuCCB;
                }

                else if (Pesquisa.Equals("Cargo"))
                {
                    List<MOD_usuarioCargo> listaNova = new List<MOD_usuarioCargo>();

                    objBLL = new BLL_usuario();
                    listaUsuCargo = objBLL.buscarUsuarioCargo(Campo1);

                    objBLL = new BLL_usuario();
                    listaCargo = objBLL.buscarCargos(Campo1);

                    foreach (MOD_cargo objEnt_Cargo in listaCargo)
                    {
                        MOD_usuarioCargo ent = new MOD_usuarioCargo();

                        ent.CodUsuarioCargo = "0";
                        ent.CodCargo = objEnt_Cargo.CodCargo;
                        ent.DescCargo = objEnt_Cargo.DescCargo;
                        ent.SiglaCargo = objEnt_Cargo.SiglaCargo;
                        ent.Ordem = objEnt_Cargo.Ordem;
                        ent.Marcado = false;

                        listaNova.Add(ent);
                    }

                    listaUsuCargo.AddRange(listaNova);
                    new BLL_GridCargo().MontarGrid(gridCargo, "UsuarioCargo");
                    ///vincula a lista ao DataSource do DataGriView
                    gridCargo.DataSource = listaUsuCargo;
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
        /// Filtra as Comuns de acordo com a Regiao selecionada
        /// </summary>
        internal void filtraComum(string CodRegiao)
        {

            //var DadosFiltrados = listaUsuCCB.Where(t => t.CodRegiao.Equals(CodRegiao)).ToList();
            //funcoes.gridCCB(gridComum, "UsuarioCCB");
            /////vincula a lista ao DataSource do DataGriView
            //gridComum.DataSource = DadosFiltrados;

            //var query = from v in listaUsuCCB
            //            where v.CodRegiao.Contains(CodRegiao)
            //            select v;

            //objBinding_UsuCCB.DataSource = query.ToList();

            //string Filtro = string.Format("{0} LIKE '{1}'", "[CodRegiao]", CodRegiao);

            //objBinding_UsuCCB.Filter = Filtro;
            //gridComum.Update();
            //gridComum.Refresh();

            //List<MOD_usuarioCCB> listaFiltro = new List<MOD_usuarioCCB>();
            //listaUsuCCB = listaUsuCCB.FindAll(delegate (MOD_usuarioCCB c) { return c.CodRegiao.Equals(CodRegiao); });

            //funcoes.gridCCB(gridComum, "UsuarioCCB");
            /////vincula a lista ao DataSource do DataGriView
            //gridComum.DataSource = listaUsuCCB;

            //if (Sexo.Equals("Masculino"))
            //{
            //    listaFiltro = listaCargo.Where(x => x.Masculino.Equals("Sim")).ToList();
            //}
            //else if (Sexo.Equals("Feminino"))
            //{
            //listaFiltro = listaCargo.Where(x => x.Feminino.Equals("Sim")).ToList();
        }

        /// <summary>
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="CodComum"></param>
        internal void preencherGrid(string Pesquisa, string Campo1, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("Regiao"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, dataGrid);
                        CodRegiao = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridRegiao(dataGrid, "UsuarioRegiao");
                    }
                }
                else if (Pesquisa.Equals("Comum"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, dataGrid);
                        CodComum = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        funcoes.gridCCB(dataGrid, "UsuarioCCB");
                    }
                }
                else if (Pesquisa.Equals("Cargo"))
                {
                    if (!string.IsNullOrEmpty(Campo1))
                    {
                        carregaGrid(Pesquisa, Campo1, dataGrid);
                        CodCargo = preencherSelecionados(Pesquisa, dataGrid);
                    }
                    else
                    {
                        //chama a funcão montar grid
                        new BLL_GridCargo().MontarGrid(gridCargo, "UsuarioCargo");
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
            finally
            {
            }
        }
        /// <summary>
        /// Sub que informa as Comuns que o Usuario poderá acessar
        /// </summary>
        private string preencherSelecionados(string Pesquisa, DataGridView dataGrid)
        {
            try
            {
                //Variavel de retorno
                string RetornoSelecao = string.Empty;

                if (Pesquisa.Equals("Comum"))
                {
                    string vCodCCB = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodCCB.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodCCB"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodCCB + "," + Convert.ToInt32(row.Cells["CodCCB"].Value).ToString();
                                }
                                vCodCCB = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodCCB;
                }
                else if (Pesquisa.Equals("Regiao"))
                {
                    string vCodRegiao = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodRegiao.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodRegiao"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodRegiao + "," + Convert.ToInt32(row.Cells["CodRegiao"].Value).ToString();
                                }
                                vCodRegiao = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodRegiao;
                }
                else if (Pesquisa.Equals("Cargo"))
                {
                    string vCodCargo = string.Empty;

                    foreach (DataGridViewRow row in dataGrid.Rows)
                    {
                        if (row.Cells["Marcado"].Value != null)
                        {
                            if (Convert.ToBoolean(row.Cells["Marcado"].Value).Equals(true))
                            {
                                string Codigo = string.Empty;
                                if (vCodCargo.Equals(string.Empty))
                                {
                                    Codigo = Convert.ToInt32(row.Cells["CodCargo"].Value).ToString();
                                }
                                else
                                {
                                    Codigo = vCodCargo + "," + Convert.ToInt32(row.Cells["CodCargo"].Value).ToString();
                                }
                                vCodCargo = Codigo;
                            }
                        }
                    }
                    RetornoSelecao = vCodCargo;
                }
                return RetornoSelecao;
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

        private void salvarCCB(string CodRegiao)
        {

        }


        #endregion

        #region verificação e liberação de acesso

        /// <summary>
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermAcessos()
        {
            try
            {
                //verificando a Aba Acessos
                gpoAcesso.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotLibAcessoUsuario);
                tvwAcesso.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotLibAcessoUsuario);
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermSupervisor()
        {
            try
            {
                chkSupervisor.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotSupUsuario);
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermAlteraSenha()
        {
            try
            {
                chkAlteraSenha.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotSolAlteraSenha);
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermAlteraCargo()
        {
            try
            {
                gpoCargo.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotUsuAcessoCargo);
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
        /// Analisa os acessos e libera os controles de acordo com o nivel
        /// </summary>
        internal void verPermAlteraCCB()
        {
            try
            {
                gpoComum.Enabled = BLL_Liberacoes.LiberaAcessoRotina(MOD_acessoUsuario.RotUsuAcessoCCB);
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

        #endregion

    }
}