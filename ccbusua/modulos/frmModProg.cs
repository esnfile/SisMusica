using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

//using de projetos
using ENT.acessos;
using ENT.Log;
using BLL.acessos;
using BLL.validacoes;
using BLL.validacoes.Controles;
using BLL.validacoes.Exceptions;
using BLL.validacoes.Formularios;
using BLL.Funcoes;

namespace ccbusua
{
    public partial class frmModProg : Form
    {
        public frmModProg(Form forms, List<MOD_acessos> listaLibAcesso)
        {
            try
            {
                InitializeComponent();

                formulario = forms;
                ///Recebe a lista de liberação de acesso
                listaAcesso = listaLibAcesso;
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

        //variaveis
        string CodModulo;
        string DescModulo;
        string CodSubModulo;
        string DescSubModulo;
        string CodPrograma;
        string DescPrograma;
        string CodRotina;
        string DescRotina;

        BLL_modulos objBLL_Mod = null;
        MOD_modulos objEnt_Mod;
        List<MOD_modulos> listaMod;

        BLL_subModulos objBLL_SubMod = null;
        MOD_subModulos objEnt_SubMod;
        List<MOD_subModulos> listaSubMod;

        BLL_programas objBLL_Prog = null;
        MOD_programas objEnt_Prog;
        List<MOD_programas> listaProg;

        BLL_rotinas objBLL_Rot = null;
        MOD_rotinas objEnt_Rot;
        List<MOD_rotinas> listaRot;

        Form formulario;
        Form formPrograma;
        Form formRotina;
        Form formSubModulo;
        Form formModulo;

        BLL_acessos objBLL_Acesso = null;
        public List<MOD_acessos> listaAcesso = null;

        //instancias de validacoes
        clsException excp;

        #endregion

        #region eventos

        #region Módulos

        private void btnModIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.CodModulo = "0";
                //chama a rotina para abrir o formulario
                this.abrirForm("frmMod", this.gridModulo);
                ((frmModulo)formModulo).Text = "Inserindo Módulos";
                ((frmModulo)formModulo).defineFoco();
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
        private void btnModEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.abrirForm("frmMod", this.gridModulo);
                ((frmModulo)formModulo).Text = "Editando Módulos";
                ((frmModulo)formModulo).enabledForm();
                ((frmModulo)formModulo).defineFoco();
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
        private void btnModExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    //chama a função que exclui o registro na tabela
                    objBLL_Mod.excluir(criarModulo());

                    this.gridModulo.DataSource = null;
                    funcoes.gridModulo(this.gridModulo);
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
                    apoio.FecharAguardeExcluir();
                }

            }
        }
        private void gridModulo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnModEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    this.abrirForm("frmMod", this.gridModulo);
                    ((frmModulo)formModulo).Text = "Editando Módulos";
                    ((frmModulo)formModulo).enabledForm();
                    ((frmModulo)formModulo).defineFoco();
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
        private void gridModulo_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                this.verPermModulo(this.gridModulo);
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
        private void gridModulo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CodModulo = this.gridModulo[0, this.gridModulo.CurrentRow.Index].Value.ToString();
                DescModulo = this.gridModulo[1, this.gridModulo.CurrentRow.Index].Value.ToString();
                this.carregaGrid("SubModulo", CodModulo, this.gridSubMod);
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

        #region Sub-Módulos

        private void btnSubIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.CodSubModulo = "0";
                //chama a rotina para abrir o formulario
                this.abrirForm("frmSubMod", this.gridSubMod);
                ((frmSubModulo)formSubModulo).Text = "Inserindo Sub-Módulos";
                ((frmSubModulo)formSubModulo).defineFoco();
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
        private void btnSubEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.abrirForm("frmSubMod", this.gridSubMod);
                ((frmSubModulo)formSubModulo).Text = "Editando Sub-Módulos";
                ((frmSubModulo)formSubModulo).enabledForm();
                ((frmSubModulo)formSubModulo).defineFoco();
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
        private void btnSubExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    //chama a função que exclui o registro na tabela
                    objBLL_SubMod.excluir(criarSubMod());

                    this.gridSubMod.DataSource = null;
                    funcoes.gridSubModulo(this.gridSubMod);
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
                    apoio.FecharAguardeExcluir();
                }

            }
        }
        private void gridSubMod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnSubEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    this.abrirForm("frmSubMod", this.gridSubMod);
                    ((frmSubModulo)formSubModulo).Text = "Editando Sub-Módulos";
                    ((frmSubModulo)formSubModulo).enabledForm();
                    ((frmSubModulo)formSubModulo).defineFoco();
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
        private void gridSubMod_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                this.verPermSubMod(this.gridSubMod);
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
        private void gridSubMod_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CodSubModulo = this.gridSubMod[0, this.gridSubMod.CurrentRow.Index].Value.ToString();
                DescSubModulo = this.gridSubMod[1, this.gridSubMod.CurrentRow.Index].Value.ToString();
                this.carregaGrid("Programa", CodSubModulo, this.gridProg);
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

        #region Programas

        private void btnProgIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.CodPrograma = "0";
                //chama a rotina para abrir o formulario
                this.abrirForm("frmProg", this.gridProg);
                ((frmPrograma)formPrograma).Text = "Inserindo Programas";
                ((frmPrograma)formPrograma).defineFoco();
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
        private void btnProgEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.abrirForm("frmProg", this.gridProg);
                ((frmPrograma)formPrograma).Text = "Editando Programas";
                ((frmPrograma)formPrograma).enabledForm();
                ((frmPrograma)formPrograma).defineFoco();
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
        private void btnProgExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    //chama a função que exclui o registro na tabela
                    objBLL_Prog.excluir(criarProg());

                    this.gridProg.DataSource = null;
                    funcoes.gridPrograma(this.gridProg);
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
                    apoio.FecharAguardeExcluir();
                }

            }
        }
        private void gridProg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnProgEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    this.abrirForm("frmProg", this.gridProg);
                    ((frmPrograma)formPrograma).Text = "Editando Programas";
                    ((frmPrograma)formPrograma).enabledForm();
                    ((frmPrograma)formPrograma).defineFoco();
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
        private void gridProg_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                this.verPermProg(this.gridProg);
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
        private void gridProg_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CodPrograma = this.gridProg[0, this.gridProg.CurrentRow.Index].Value.ToString();
                DescPrograma = this.gridProg[1, this.gridProg.CurrentRow.Index].Value.ToString();
                this.carregaGrid("Rotina", CodPrograma, this.gridRot);
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

        #region Rotinas

        private void btnAcaoIns_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.CodRotina = "0";
                //chama a rotina para abrir o formulario
                this.abrirForm("frmRot", this.gridRot);
                ((frmRotina)formRotina).Text = "Inserindo Rotinas";
                ((frmRotina)formRotina).defineFoco();
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
        private void btnAcaoEditar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.abrirForm("frmRot", this.gridRot);
                ((frmRotina)formRotina).Text = "Editando Rotinas";
                ((frmRotina)formRotina).enabledForm();
                ((frmRotina)formRotina).defineFoco();
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
        private void btnAcaoExc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(modulos.exclusao, "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    apoio.AguardeExcluir();
                    //chama a função que exclui o registro na tabela
                    objBLL_Rot.excluir(criarRot());

                    this.gridRot.DataSource = null;
                    funcoes.gridRotina(this.gridRot);
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
                    apoio.FecharAguardeExcluir();
                }

            }
        }
        private void gridAcao_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.btnRotEditar.Enabled.Equals(false))
            {
                try
                {
                    apoio.Aguarde();
                    this.abrirForm("frmRot", this.gridRot);
                    ((frmRotina)formRotina).Text = "Editando Rotinas";
                    ((frmRotina)formRotina).enabledForm();
                    ((frmRotina)formRotina).defineFoco();
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
        private void gridAcao_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            try
            {
                this.verPermRot(this.gridRot);
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
        private void gridAcao_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                CodRotina = this.gridRot[0, this.gridRot.CurrentRow.Index].Value.ToString();
                DescRotina = this.gridRot[1, this.gridRot.CurrentRow.Index].Value.ToString();
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

        #region eventos do formulario

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                apoio.Aguarde();
                this.carregaGrid("Modulo", string.Empty, this.gridModulo);
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
         private void frmModProg_Load(object sender, EventArgs e)
        {
            try
            {
                ///chama a funcão montar grid
                funcoes.gridModulo(this.gridModulo);
                funcoes.gridSubModulo(this.gridSubMod);
                funcoes.gridPrograma(this.gridProg);
                funcoes.gridRotina(this.gridRot);
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
            this.Close();
        }
        private void frmModProg_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (formulario.Name.Equals("frmRestrito"))
            {
                formulario.Enabled = true;
            }
        }

        #endregion

        #endregion

        #region funções privadas e publicas

        /// <summary>
        /// Função que carrega a pesquisa, apenas definir o campo e o grid que será carregado
        /// </summary>
        /// <param name="Pesquisa"></param>
        /// <param name="Campo"></param>
        /// <param name="DataGrid"></param>
        internal void carregaGrid(string Pesquisa, string Campo, DataGridView dataGrid)
        {
            try
            {
                if (Pesquisa.Equals("Modulo"))
                {
                    //chama a classe de negócios
                    objBLL_Mod = new BLL_modulos();
                    listaMod = objBLL_Mod.buscarCod(Campo);
                    funcoes.gridModulo(dataGrid);
                    dataGrid.DataSource = listaMod;
                }
                else if (Pesquisa.Equals("SubModulo"))
                {
                    //chama a classe de negócios
                    objBLL_SubMod = new BLL_subModulos();
                    listaSubMod = objBLL_SubMod.buscarModulo(Campo);
                    funcoes.gridSubModulo(dataGrid);
                    dataGrid.DataSource = listaSubMod;
                }
                else if (Pesquisa.Equals("Programa"))
                {
                    //chama a classe de negócios
                    objBLL_Prog = new BLL_programas();
                    listaProg = objBLL_Prog.buscarSubModulo(Campo);
                    funcoes.gridPrograma(dataGrid);
                    dataGrid.DataSource = listaProg;
                }
                else if (Pesquisa.Equals("Rotina"))
                {
                    //chama a classe de negócios
                    objBLL_Rot = new BLL_rotinas();
                    listaRot = objBLL_Rot.buscarPrograma(Campo);
                    funcoes.gridRotina(dataGrid);
                    dataGrid.DataSource = listaRot;
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
        /// Função que abre o Formulário para edição
        /// </summary>
        /// <param name="form"></param>
        /// <param name="DataGrid"></param>
        private void abrirForm(string form, DataGridView dataGrid)
        {
            try
            {
                if (form.Equals("frmMod"))
                {
                    if (((frmModulo)formModulo) == null || ((frmModulo)formModulo).IsDisposed)
                    {
                        this.preencher("frmMod", CodModulo);
                        formModulo = new frmModulo(this, dataGrid, listaMod);
                        ((frmModulo)formModulo).MdiParent = MdiParent;
                        ((frmModulo)formulario).Show();
                        this.Enabled = false;
                    }
                }
                else if (form.Equals("frmSubMod"))
                {
                    if (((frmSubModulo)formSubModulo) == null || ((frmSubModulo)formSubModulo).IsDisposed)
                    {
                        this.preencher("frmSubMod", CodSubModulo);
                        formSubModulo = new frmSubModulo(this, dataGrid, listaSubMod);
                        ((frmSubModulo)formSubModulo).MdiParent = MdiParent;
                        ((frmSubModulo)formSubModulo).Show();
                        this.Enabled = false;
                    }
                }
                else if (form.Equals("frmProg"))
                {
                    if (((frmPrograma)formPrograma) == null || ((frmPrograma)formPrograma).IsDisposed)
                    {
                        this.preencher("frmProg", CodPrograma);
                        formPrograma = new frmPrograma(this, dataGrid, listaProg);
                        ((frmPrograma)formPrograma).MdiParent = MdiParent;
                        ((frmPrograma)formPrograma).Show();
                        this.Enabled = false;
                    }
                }
                else if (form.Equals("frmRot"))
                {
                    if (((frmRotina)formRotina) == null || ((frmRotina)formRotina).IsDisposed)
                    {
                        this.preencher("frmRot", CodRotina);
                        formRotina = new frmRotina(this, dataGrid, listaRot);
                        ((frmRotina)formRotina).MdiParent = MdiParent;
                        ((frmRotina)formRotina).Show();
                        this.Enabled = false;
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
        /// Função que preenche o formulário para edição
        /// </summary>
        /// <param name="Campo"></param>
        /// <param name="form"></param>
        internal void preencher(string form, string Campo)
        {
            try
            {
                if (form.Equals("frmMod"))
                {
                    objBLL_Mod = new BLL_modulos();
                    listaMod = objBLL_Mod.buscarCod(Campo);
                }
                else if (form.Equals("frmSubMod"))
                {
                    objBLL_SubMod = new BLL_subModulos();
                    listaSubMod = objBLL_SubMod.buscarCod(Campo);
                }
                else if (form.Equals("frmProg"))
                {
                    objBLL_Prog = new BLL_programas();
                    listaProg = objBLL_Prog.buscarCod(Campo);
                }
                else if (form.Equals("frmRot"))
                {
                    objBLL_Rot = new BLL_rotinas();
                    listaRot = objBLL_Rot.buscarCod(Campo);
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_modulos criarModulo()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt_Mod = new MOD_modulos();
                objEnt_Mod.CodModulo = CodModulo;
                objEnt_Mod.DescModulo = DescModulo;

                //retorna o objeto preenchido
                return objEnt_Mod;
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_subModulos criarSubMod()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt_SubMod = new MOD_subModulos();
                objEnt_SubMod.CodSubModulo = CodSubModulo;
                objEnt_SubMod.DescSubModulo = DescSubModulo;

                //retorna o objeto preenchido
                return objEnt_SubMod;
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_programas criarProg()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt_Prog = new MOD_programas();
                objEnt_Prog.CodPrograma = CodPrograma;
                objEnt_Prog.DescPrograma = DescPrograma;

                //retorna o objeto preenchido
                return objEnt_Prog;
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
        /// Função que transfere os dados para as Entidades
        /// </summary>
        /// <returns></returns>
        private MOD_rotinas criarRot()
        {
            try
            {
                //preenche o objeto da tabela Logs
                objEnt_Rot = new MOD_rotinas();
                objEnt_Rot.CodRotina = CodRotina;
                objEnt_Rot.DescRotina = DescRotina;

                //retorna o objeto preenchido
                return objEnt_Rot;
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
        /// <param name="dataGrid"></param>
        internal void verPermModulo(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoModulos entAcesso = new MOD_acessoModulos();
                this.btnModIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotInsModulo);
                this.btnModEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotEditModulo, dataGrid);
                this.btnModExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotExcModulo, dataGrid);
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
        /// <param name="dataGrid"></param>
        internal void verPermSubMod(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoSubModulos entAcesso = new MOD_acessoSubModulos();
                this.btnSubIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotInsSubModulo);
                this.btnSubEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotEditSubModulo, dataGrid);
                this.btnSubExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotExcSubModulo, dataGrid);
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
        /// <param name="dataGrid"></param>
        internal void verPermProg(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoProgramas entAcesso = new MOD_acessoProgramas();
                this.btnProgIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotInsProgModulo);
                this.btnProgEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotEditProgModulo, dataGrid);
                this.btnProgExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotExcProgModulo, dataGrid);
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
        /// <param name="dataGrid"></param>
        internal void verPermRot(DataGridView dataGrid)
        {
            try
            {
                MOD_acessoRotinas entAcesso = new MOD_acessoRotinas();
                this.btnRotIns.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotInsRotModulo);
                this.btnRotEditar.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotEditRotModulo, dataGrid);
                this.btnRotExc.Enabled = BLL_Liberacoes.LiberaAcessoRotina(entAcesso.rotExcRotModulo, dataGrid);
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

    }
}