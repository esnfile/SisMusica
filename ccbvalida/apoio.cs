using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

using BLL.validacoes.Formularios;
using BLL.Funcoes;
using ENT.Erros;
using ENT.uteis;
using BLL.validacoes.Controles;
using BLL.uteis;
using BLL.pessoa;
using ENT.pessoa;
using BLL.instrumentos;
using ENT.instrumentos;
using BLL.acessos;
using ENT.acessos;
using BLL.Usuario;
using System.ComponentModel;
using System.Drawing;
using BLL.administracao;
using ENT.administracao;

namespace BLL.validacoes
{
    public static class apoio
    {

        #region declarações

        static carregInf frmCarregInf = null;
        static carregAtendimento frmCarregAtend = null;
        static conectarBanco frmConectarBanco = null;
        static carregAcessos frmCarregAces = null;
        static excluindo frmExcluindo = null;
        static estornando frmEstornando = null;
        static cancelando frmCancelando = null;
        static carregBarra frmCarregBarra = null;
        static carregRelatorio frmCarregRelat = null;

        static BLL_cidade objBLL_Cidade = null;
        static List<MOD_uf> listaEstado = null;

        static BLL_biblia objBLL_Biblia = null;
        static List<MOD_biblia> listaBiblia = null;

        static BLL_regional objBLL_Regional = null;
        static List<MOD_regional> listaRegional = null;

        static BLL_regiaoAtuacao objBLL_Regiao = null;
        static List<MOD_regiaoAtuacao> listaRegiao = null;

        static BLL_ccb objBLL_CCB = null;
        static List<MOD_ccb> listaCCB = null;

        static BLL_cargo objBLL_Cargo = null;
        static List<MOD_cargo> listaCargo = null;

        static BLL_departamento objBLL_Depart = null;
        static List<MOD_departamento> listaDepart = null;

        static BLL_acessos objBLL_Acesso = null;
        static List<MOD_acessos> listaAcesso = null;

        static BLL_usuario objBLL_Usuario = null;
        static BindingList<MOD_usuarioCCB> listaUsuarioCCB = null;
        static List<MOD_usuarioCargo> listaUsuarioCargo = null;

        static BLL_modulos objBLL_Modulo = null;
        static List<MOD_modulos> listaModulo = null;
        static BLL_subModulos objBLL_SubModulo = null;
        static List<MOD_subModulos> listaSubModulo = null;
        static BLL_programas objBLL_Programa = null;
        static List<MOD_programas> listaPrograma = null;

        static BLL_tonalidade objBLL_Tonalidade = null;
        static List<MOD_tonalidade> listaTonalidade = null;

        static BLL_instrumento objBLL_Instrumento = null;
        static List<MOD_instrumento> listaInstrumento = null;

        static BLL_familia objBLL_Familia = null;
        static List<MOD_familia> listaFamilia = null;

        static BLL_tipoEscala objBLL_TipoEscala = null;
        static List<MOD_tipoEscala> listaTipoEscala = null;

        static BLL_hinario objBLL_Hinario = null;
        static List<MOD_hinario> listaHinario = null;

        static BLL_mtsFase objBLL_Fase = null;
        static List<MOD_mtsFase> listaFase = null;

        static BLL_tipoReuniao objBLL_TipoReuniao = null;
        static List<MOD_tipoReuniao> listaTipoReuniao = null;

        static gravando frmGravando = null;
        static BLL.validacoes.Formularios.telaErros frmErros = null;
        static reabrir frmReAbrir = null;
        static fechando frmFechando = null;
        static finalizando frmFinalizando = null;

        #endregion

        #region abrir os formulários de informações

        public static void Aguarde()
        {
            try
            {
                if (frmCarregInf == null || frmCarregInf.IsDisposed)
                {
                    frmCarregInf = new carregInf();
                    frmCarregInf.Show();
                    frmCarregInf.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Aguarde(string Mensagem)
        {
            try
            {
                if (frmCarregInf == null || frmCarregInf.IsDisposed)
                {
                    frmCarregInf = new carregInf(Mensagem);
                    frmCarregInf.Show();
                    frmCarregInf.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void AguardeRelatorio()
        {
            try
            {
                if (frmCarregRelat == null || frmCarregRelat.IsDisposed)
                {
                    frmCarregRelat = new carregRelatorio();
                    frmCarregRelat.Show();
                    frmCarregRelat.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AguardeAcesso()
        {
            if (frmCarregAces == null || frmCarregAces.IsDisposed)
            {
                frmCarregAces = new carregAcessos();
                frmCarregAces.Show();
                frmCarregAces.Refresh();
            }
        }
        public static void AguardeAtendimento()
        {
            if (frmCarregAtend == null || frmCarregAtend.IsDisposed)
            {
                frmCarregAtend = new carregAtendimento();
                frmCarregAtend.Show();
                frmCarregAtend.Refresh();
            }
        }
        public static void AguardeConectarBanco()
        {
            if (frmConectarBanco == null || frmConectarBanco.IsDisposed)
            {
                frmConectarBanco = new conectarBanco();
                frmConectarBanco.Show();
                frmConectarBanco.Refresh();
            }
        }
        public static void AguardeCarregaBarra(int totalRegistro)
        {
            if (frmCarregBarra == null || frmCarregBarra.IsDisposed)
            {
                frmCarregBarra = new carregBarra(totalRegistro);
                frmCarregBarra.Show();
                frmCarregBarra.Refresh();
            }
        }

        public static void AguardeExcluir()
        {
            if (frmExcluindo == null || frmExcluindo.IsDisposed)
            {
                frmExcluindo = new excluindo();
                frmExcluindo.Show();
                frmExcluindo.Refresh();
            }
        }
        public static void AguardeEstornar()
        {
            if (frmEstornando == null || frmEstornando.IsDisposed)
            {
                frmEstornando = new estornando();
                frmEstornando.Show();
                frmEstornando.Refresh();
            }
        }
        public static void AguardeCancelar()
        {
            if (frmCancelando == null || frmCancelando.IsDisposed)
            {
                frmCancelando = new cancelando();
                frmCancelando.Show();
                frmCancelando.Refresh();
            }
        }
        public static void AguardeGravar()
        {
            try
            {
                if (frmGravando == null || frmGravando.IsDisposed)
                {
                    frmGravando = new gravando();
                    frmGravando.Show();
                    frmGravando.Refresh();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex + " - Formulario Gravando");
            }
        }
        public static void AguardeFechar()
        {
            if (frmFechando == null || frmFechando.IsDisposed)
            {
                frmFechando = new fechando();
                frmFechando.Show();
                frmFechando.Refresh();
            }
        }
        public static void AguardeReabrir()
        {
            if (frmReAbrir == null || frmReAbrir.IsDisposed)
            {
                frmReAbrir = new reabrir();
                frmReAbrir.Show();
                frmReAbrir.Refresh();
            }
        }
        public static void AguardeFinalizar()
        {
            if (frmFinalizando == null || frmFinalizando.IsDisposed)
            {
                frmFinalizando = new finalizando();
                frmFinalizando.Show();
                frmFinalizando.Refresh();
            }
        }
        public static bool AbrirErros(List<MOD_erros> listaErros, Form form)
        {
            try
            {
                frmErros = new BLL.validacoes.Formularios.telaErros(listaErros, form);

                if (frmErros.ShowDialog(form).Equals(DialogResult.OK))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void ShowToolTip(out ToolTip toolTip, Control control, string title, string message)
        {
            toolTip = new ToolTip();
            toolTip.IsBalloon = true;
            toolTip.ToolTipIcon = ToolTipIcon.Error;
            toolTip.ToolTipTitle = title;
            toolTip.Show(string.Empty, control, 0);
            toolTip.Show(message, control, control.Width / 2, control.Height, 5000);
        }

        public static void CarregaAcessosUsuario(string CodUsuario)
        {
            objBLL_Acesso = new BLL_acessos();
            listaAcesso = objBLL_Acesso.buscarUsuAcesso(CodUsuario);
            modulos.listaLibAcesso = listaAcesso;
            modulos.Supervisor = listaAcesso[0].Supervisor;
        }

        /// <summary>
        /// Sub que informa as Comuns que o Usuario poderá acessar
        /// </summary>
        public static void preencheUsuarioCCB(string CodUsuario)
        {
            string CodUsuCCB = string.Empty;
            objBLL_Usuario = new BLL_usuario();
            listaUsuarioCCB = objBLL_Usuario.buscarUsuarioCCB(CodUsuario);

            foreach (MOD_usuarioCCB ent in listaUsuarioCCB)
            {
                string Codigo = string.Empty;
                if (CodUsuCCB.Equals(string.Empty))
                {
                    Codigo = Convert.ToInt32(ent.CodCCB).ToString();
                }
                else
                {
                    Codigo = CodUsuCCB + "," + Convert.ToInt32(ent.CodCCB).ToString();
                }
                CodUsuCCB = Codigo;
            }

            modulos.CodUsuarioCCB = CodUsuCCB;
        }

        /// <summary>
        /// Sub que informa os Cargos que o Usuario poderá acessar
        /// </summary>
        public static void preencheUsuarioCargo(string CodUsuario)
        {
            string CodUsuCargo = string.Empty;
            objBLL_Usuario = new BLL_usuario();
            listaUsuarioCargo = objBLL_Usuario.buscarUsuarioCargo(CodUsuario);

            foreach (MOD_usuarioCargo ent in listaUsuarioCargo)
            {
                string Codigo = string.Empty;
                if (CodUsuCargo.Equals(string.Empty))
                {
                    Codigo = Convert.ToInt32(ent.CodCargo).ToString();
                }
                else
                {
                    Codigo = CodUsuCargo + "," + Convert.ToInt32(ent.CodCargo).ToString();
                }
                CodUsuCargo = Codigo;
            }

            modulos.CodUsuarioCargo = CodUsuCargo;
        }

        public static void FecharAguarde()
        {
            if (frmCarregInf != null)
            {
                frmCarregInf.Close();
                frmCarregInf.Dispose();
            }
        }
        public static void FecharAguardeRelatorio()
        {
            if (frmCarregRelat != null)
            {
                frmCarregRelat.Close();
                frmCarregRelat.Dispose();
            }
        }
        public static void FecharAguardeAcesso()
        {
            if (frmCarregAces != null)
            {
                frmCarregAces.Close();
                frmCarregAces.Dispose();
            }
        }
        public static void FecharAguardeAtendimento()
        {
            if (frmCarregAtend != null)
            {
                frmCarregAtend.Close();
                frmCarregAtend.Dispose();
            }
        }
        public static void FecharAguardeConectarBanco()
        {
            if (frmConectarBanco != null)
            {
                frmConectarBanco.Close();
                frmConectarBanco.Dispose();
            }
        }
        public static void FecharAguardeCarregBarra()
        {
            if (frmCarregBarra != null)
            {
                frmCarregBarra.Close();
                frmCarregBarra.Dispose();
            }
        }

        public static void FecharAguardeExcluir()
        {
            if (frmExcluindo != null)
            {
                frmExcluindo.Close();
                frmExcluindo.Dispose();
            }
        }
        public static void FecharAguardeEstornar()
        {
            if (frmEstornando != null)
            {
                frmEstornando.Close();
                frmEstornando.Dispose();
            }
        }
        public static void FecharAguardeFechar()
        {
            if (frmFechando != null)
            {
                frmFechando.Close();
                frmFechando.Dispose();
            }
        }
        public static void FecharAguardeFinalizar()
        {
            if (frmFinalizando != null)
            {
                frmFinalizando.Close();
                frmFinalizando.Dispose();
            }
        }
        public static void FecharAguardeCancelar()
        {
            if (frmCancelando != null)
            {
                frmCancelando.Close();
                frmCancelando.Dispose();
            }
        }
        public static void FecharAguardeGravar()
        {
            if (frmGravando != null)
            {
                frmGravando.Close();

            }
        }
        public static void FecharAguardeReabrir()
        {
            if (frmReAbrir != null)
            {
                frmReAbrir.Close();
                frmReAbrir.Dispose();
            }
        }

        #endregion

        #region Centralizar Formulario

        public static void CentralizarForm(Form formulario)
        {
            int x = formulario.Left + (formulario.Parent.Width / 2) - (formulario.Width / 2);
            int y = formulario.Top + (formulario.Parent.Height / 2) - (formulario.Height / 2);
            formulario.Location = new Point(x, y);
        }

        #endregion

        #region carregar combos

        /// <summary>
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela estado
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboEstado(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Cidade = new BLL_cidade();
                listaEstado = new List<MOD_uf>();

                listaEstado = objBLL_Cidade.buscarUf(string.Empty);
                cboCombo.DataSource = listaEstado;
                cboCombo.ValueMember = "Sigla";
                cboCombo.DisplayMember = "Sigla";
                //cboCombo.SelectedValue = modulos.listaParametros[0].listaCCB[0].Estado;
                cboCombo.SelectedValue = modulos.listaParametros[0].listaRegional[0].Estado;
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela regional
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboRegional(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Regional = new BLL_regional();
                listaRegional = new List<MOD_regional>();

                listaRegional = objBLL_Regional.buscarDescricao(string.Empty);
                cboCombo.DataSource = listaRegional;
                cboCombo.ValueMember = "CodRegional";
                cboCombo.DisplayMember = "Descricao";
                cboCombo.SelectedValue = modulos.listaParametros[0].listaRegional[0].CodRegional;
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Região Atuação
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboRegiao(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Regiao = new BLL_regiaoAtuacao();
                listaRegiao = new List<MOD_regiaoAtuacao>();

                listaRegiao = objBLL_Regiao.buscarDescricao(string.Empty);
                cboCombo.DataSource = listaRegiao;
                cboCombo.ValueMember = "CodRegiao";
                cboCombo.DisplayMember = "DescRegiao";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Região Atuação
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboRegiao(ComboBoxPersonal cboCombo, string CodRegional)
        {
            try
            {
                objBLL_Regiao = new BLL_regiaoAtuacao();
                listaRegiao = new List<MOD_regiaoAtuacao>();

                listaRegiao = objBLL_Regiao.buscarRegional(CodRegional);
                cboCombo.DataSource = listaRegiao;
                cboCombo.ValueMember = "CodRegiao";
                cboCombo.DisplayMember = "DescRegiao";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela CCB
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboCCB(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = new List<MOD_ccb>();

                listaCCB = objBLL_CCB.buscarDescricao(string.Empty);
                cboCombo.DataSource = listaCCB;
                cboCombo.ValueMember = "CodCCB";
                cboCombo.DisplayMember = "Descricao";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela CCB
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboCCB(ComboBoxPersonal cboCombo, string CodRegiao)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = new List<MOD_ccb>();

                listaCCB = objBLL_CCB.buscarRegiao(CodRegiao);
                cboCombo.DataSource = listaCCB;
                cboCombo.ValueMember = "CodCCB";
                cboCombo.DisplayMember = "Descricao";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela CCB liberadas para o usuario
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboCCBUsuario(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Usuario = new BLL_usuario();
                listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();

                listaUsuarioCCB = objBLL_Usuario.buscarUsuarioCCB(modulos.CodUsuario);
                cboCombo.DataSource = listaUsuarioCCB;
                cboCombo.ValueMember = "CodCCB";
                cboCombo.DisplayMember = "Descricao";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela CCB liberadas para o usuario
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboCCBUsuario(ComboBoxPersonal cboCombo, string CodRegiao)
        {
            try
            {
                objBLL_Usuario = new BLL_usuario();
                listaUsuarioCCB = new BindingList<MOD_usuarioCCB>();

                listaUsuarioCCB = objBLL_Usuario.buscarUsuarioCCB(modulos.CodUsuario, CodRegiao);
                cboCombo.DataSource = listaUsuarioCCB;
                cboCombo.ValueMember = "CodCCB";
                cboCombo.DisplayMember = "Descricao";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Modulos
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboModulo(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Modulo = new BLL_modulos();
                listaModulo = new List<MOD_modulos>();
                listaModulo = objBLL_Modulo.buscarDescricao(string.Empty);

                cboCombo.DataSource = listaModulo;
                cboCombo.ValueMember = "CodModulo";
                cboCombo.DisplayMember = "DescModulo";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela SubModulos
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboSubModulo(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_SubModulo = new BLL_subModulos();
                listaSubModulo = new List<MOD_subModulos>();
                listaSubModulo = objBLL_SubModulo.buscarDescricao(string.Empty);

                cboCombo.DataSource = listaSubModulo;
                cboCombo.ValueMember = "CodSubModulo";
                cboCombo.DisplayMember = "DescSubModulo";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela SubModulos
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboSubModulo(ComboBoxPersonal cboCombo, string CodModulo)
        {
            try
            {
                objBLL_SubModulo = new BLL_subModulos();
                listaSubModulo = new List<MOD_subModulos>();
                listaSubModulo = objBLL_SubModulo.buscarModulo(CodModulo);

                cboCombo.DataSource = listaSubModulo;
                cboCombo.ValueMember = "CodSubModulo";
                cboCombo.DisplayMember = "DescSubModulo";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Programas
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboPrograma(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Programa = new BLL_programas();
                listaPrograma = new List<MOD_programas>();
                listaPrograma = objBLL_Programa.buscarDescricao(string.Empty);

                cboCombo.DataSource = listaPrograma;
                cboCombo.ValueMember = "CodPrograma";
                cboCombo.DisplayMember = "DescPrograma";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Programas
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboPrograma(ComboBoxPersonal cboCombo, string CodSubModulo)
        {
            try
            {
                objBLL_Programa = new BLL_programas();
                listaPrograma = new List<MOD_programas>();
                listaPrograma = objBLL_Programa.buscarSubModulo(CodSubModulo);

                cboCombo.DataSource = listaPrograma;
                cboCombo.ValueMember = "CodPrograma";
                cboCombo.DisplayMember = "DescPrograma";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Cargo
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboCargo(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Cargo = new BLL_cargo();
                listaCargo = new List<MOD_cargo>();

                listaCargo = objBLL_Cargo.buscarCod(string.Empty);
                cboCombo.Items.Clear();
                cboCombo.DataSource = listaCargo;
                cboCombo.ValueMember = "CodCargo";
                cboCombo.DisplayMember = "DescCargo";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Cargo liberadas para o usuario
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboCargo(ComboBoxPersonal cboCombo, string CodUsuario)
        {
            try
            {
                objBLL_Usuario = new BLL_usuario();
                listaUsuarioCargo = objBLL_Usuario.buscarUsuarioCargo(CodUsuario);
                cboCombo.DataSource = listaUsuarioCargo;
                cboCombo.ValueMember = "CodCargo";
                cboCombo.DisplayMember = "DescCargo";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Cargo liberadas para o usuario, e filtradas para exibir apenas que Atende GEM
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboCargo(ComboBoxPersonal cboCombo, string CodUsuario, string AtendeGEM)
        {
            try
            {
                objBLL_Usuario = new BLL_usuario();
                listaUsuarioCargo = objBLL_Usuario.buscarUsuarioCargo(CodUsuario);

                listaUsuarioCargo = listaUsuarioCargo.Where(c => c.AtendeGEM.Equals(AtendeGEM)).ToList();

                cboCombo.DataSource = listaUsuarioCargo;
                cboCombo.ValueMember = "CodCargo";
                cboCombo.DisplayMember = "DescCargo";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Departamento
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboDepartament(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Depart = new BLL_departamento();
                listaDepart = new List<MOD_departamento>();

                listaDepart = objBLL_Depart.buscarCod(string.Empty);
                cboCombo.Items.Clear();
                cboCombo.DataSource = listaDepart;
                cboCombo.ValueMember = "CodDepartamento";
                cboCombo.DisplayMember = "DescDepartamento";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Tonalidade
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboTonalidade(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Tonalidade = new BLL_tonalidade();
                listaTonalidade = new List<MOD_tonalidade>();

                listaTonalidade = objBLL_Tonalidade.buscarCod(string.Empty);
                cboCombo.Items.Clear();
                cboCombo.DataSource = listaTonalidade;
                cboCombo.ValueMember = "CodTonalidade";
                cboCombo.DisplayMember = "DescTonalidade";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela MtsFase
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboFaseMts(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Fase = new BLL_mtsFase();
                listaFase = new List<MOD_mtsFase>();

                listaFase = objBLL_Fase.buscarCod(string.Empty);
                //cboCombo.Items.Clear();
                cboCombo.DataSource = listaFase;
                cboCombo.ValueMember = "CodFaseMts";
                cboCombo.DisplayMember = "DescFase";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Familia
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboFamilia(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Familia = new BLL_familia();
                listaFamilia = new List<MOD_familia>();

                listaFamilia = objBLL_Familia.buscarCod(string.Empty);
                //cboCombo.Items.Clear();
                cboCombo.DataSource = listaFamilia;
                cboCombo.ValueMember = "CodFamilia";
                cboCombo.DisplayMember = "DescFamilia";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela TipoEscala
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboTipoEscala(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_TipoEscala = new BLL_tipoEscala();
                listaTipoEscala = new List<MOD_tipoEscala>();

                listaTipoEscala = objBLL_TipoEscala.buscarCod(string.Empty);
                //cboCombo.Items.Clear();
                cboCombo.DataSource = listaTipoEscala;
                cboCombo.ValueMember = "CodTipoEscala";
                cboCombo.DisplayMember = "DescTipo";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Hinário
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboHinario(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Hinario = new BLL_hinario();
                listaHinario = new List<MOD_hinario>();

                listaHinario = objBLL_Hinario.buscarCod(string.Empty);
                cboCombo.Items.Clear();
                cboCombo.DataSource = listaHinario;
                cboCombo.ValueMember = "CodHinario";
                cboCombo.DisplayMember = "DescTonalidade";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Instrumento
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboInstrumento(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Instrumento = new BLL_instrumento();
                listaInstrumento = new List<MOD_instrumento>();

                listaInstrumento = objBLL_Instrumento.buscarDescricao(string.Empty);
                cboCombo.Items.Clear();
                cboCombo.DataSource = listaInstrumento;
                cboCombo.ValueMember = "CodInstrumento";
                cboCombo.DisplayMember = "DescInstrumento";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Instrumento
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboInstrumento(ComboBoxPersonal cboCombo, string CodFamilia)
        {
            try
            {
                cboCombo.DataSource = null;
                objBLL_Instrumento = new BLL_instrumento();
                listaInstrumento = new List<MOD_instrumento>();

                listaInstrumento = objBLL_Instrumento.buscarFamilia(CodFamilia);
                //cboCombo.Items.Clear();
                cboCombo.DataSource = listaInstrumento;
                cboCombo.ValueMember = "CodInstrumento";
                cboCombo.DisplayMember = "DescInstrumento";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Tipo Reunião
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboTipoReuniao(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_TipoReuniao = new BLL_tipoReuniao();
                listaTipoReuniao = new List<MOD_tipoReuniao>();

                listaTipoReuniao = objBLL_TipoReuniao.buscarDescricao(string.Empty);
                //cboCombo.Items.Clear();
                cboCombo.DataSource = listaTipoReuniao;
                cboCombo.ValueMember = "CodTipoReuniao";
                cboCombo.DisplayMember = "DescTipoReuniao";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// função que carrega os combos que serão preenchidos 
        /// com a tabela Biblia
        /// </summary>
        /// <param name="cboCombo"></param>
        public static ComboBoxPersonal carregaComboBiblia(ComboBoxPersonal cboCombo)
        {
            try
            {
                objBLL_Biblia = new BLL_biblia();
                listaBiblia = new List<MOD_biblia>();

                listaBiblia = objBLL_Biblia.buscarCod(string.Empty);
                cboCombo.DataSource = listaBiblia;
                cboCombo.ValueMember = "CodBiblia";
                cboCombo.DisplayMember = "DescLivro";
                cboCombo.SelectedIndex = (-1);
                return cboCombo;
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
        /// Sub que forma a seleção de varios strings para pesquisa IN(*) para pesquisar
        /// Informar o array de strings e o Text do controle
        /// </summary>
        public static string formarPesquisa(string[] civil)
        {
            string Texto = string.Empty;
            string Codigo = string.Empty;

            foreach (string ent in civil)
            {
                if (!string.IsNullOrEmpty(ent))
                {
                    if (string.IsNullOrEmpty(Texto))
                    {
                        Codigo = ent;
                    }
                    else
                    {
                        Codigo = Codigo + "','" + ent;
                    }
                    Texto = Codigo;
                }
            }
            return Texto;
        }

        #region verificar liberações de acessos

        /// <summary>
        /// Função que verifica se o usuario tem permissão para acessar determinada área
        /// <para>[listaAcesso: Informar a lista de acessos presente no formulario], 
        /// [rotina: Informar a rotina a ser analisada], [dataGrid: Infomar o Grid para analisar se contem dados]</para>
        /// </summary>
        /// <param name="listaAcesso"></param>
        /// <param name="rotina"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static bool liberacoes(List<MOD_acessos> listaAcesso, int rotina, DataGridView dataGrid)
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
                foreach (MOD_acessos entAcesso in listaAcesso)
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
        public static bool liberacoes(List<MOD_acessos> listaAcesso, int rotina)
        {
            bool retorno = false;
            if (modulos.Supervisor.Equals("Sim"))
            {
                retorno = true;
            }
            else
            {
                foreach (MOD_acessos entAcesso in listaAcesso)
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