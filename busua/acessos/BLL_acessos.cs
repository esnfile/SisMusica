using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

using BLL.Funcoes;
using DAL.acessos;
using ENT.acessos;
using ENT.Log;
using DAL.log;
using BLL.Usuario;

namespace BLL.acessos
{
    public class BLL_acessos
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_acessos objDAL = null;
        DAL_log objDAL_Log = null;

        BLL_usuario objBLL_Usuario = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;
        DataTable objDtb_Rotina = null;

        List<MOD_acessos> listaAcesso = new List<MOD_acessos>();
        List<MOD_rotinas> listaRotina = new List<MOD_rotinas>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer INSERT E DELETE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_acessos objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Acesso e Logs

                    objDAL = new DAL_acessos();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Update");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false) || this.blnRetornoLog.Equals(false))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        #endregion

        #region Funções que transmite os Critério para a DAL realizar a Busca no Banco

        /// <summary>
        /// Função que Transmite o Usuario informada, para pesquisa na
        /// Tabela Acessos
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public List<MOD_acessos> buscarUsuAcesso(string CodUsuario)
        {
            try
            {
                objDAL = new DAL_acessos();
                objDtb = objDAL.buscarUsuAcesso(CodUsuario);

                if (objDtb != null)
                {
                    listaAcesso = this.criarListaAcesso(objDtb);
                }
                return listaAcesso;
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
        /// Função que Transmite o Usuario e a Rotina informada, para pesquisa na
        /// Tabela Acessos
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRotina"></param>
        /// <returns></returns>       
        public List<MOD_acessos> buscarCodAcesso(string CodUsuario, string CodRotina)
        {
            try
            {
                objDAL = new DAL_acessos();
                objDtb = objDAL.buscarCodAcesso(CodUsuario, CodRotina);

                if (objDtb != null)
                {
                    listaAcesso = this.criarListaAcesso(objDtb);
                }
                return listaAcesso;
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
        /// Função que Transmite o Usuario e o Programa informada, para pesquisa na
        /// Tabela Acessos
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodPrograma"></param>
        /// <returns></returns>       
        public List<MOD_acessos> buscarUsuAcessoProg(string CodUsuario, string CodPrograma)
        {
            try
            {
                objDAL = new DAL_acessos();
                objDtb = objDAL.buscarUsuAcessoProg(CodUsuario, CodPrograma);

                if (objDtb != null)
                {
                    listaAcesso = this.criarListaAcesso(objDtb);
                }
                return listaAcesso;
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
        /// Função que Transmite a Rotina informada, para pesquisa na
        /// Tabela Acessos
        /// </summary>
        /// <param name="CodRotina"></param>
        /// <returns></returns>
        public List<MOD_acessos> buscarRotinaAcesso(string CodRotina)
        {
            try
            {
                objDAL = new DAL_acessos();
                objDtb = objDAL.buscarRotinaAcesso(CodRotina);

                if (objDtb != null)
                {
                    listaAcesso = this.criarListaAcesso(objDtb);
                }
                return listaAcesso;
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
        /// Função que Transmite o Usuario informada, para pesquisa na
        /// Tabela CodUsuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public List<MOD_rotinas> buscarRotinas(string CodUsuario)
        {
            try
            {
                objDAL = new DAL_acessos();
                objDtb_Rotina = objDAL.buscarRotinas(CodUsuario);

                if (objDtb_Rotina != null)
                {
                    listaRotina = this.criarListaRotina(objDtb_Rotina);
                }
                return listaRotina;
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
        /// Função que Retorna a Lista da Tabela Acessos Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_acessos> criarListaAcesso(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_acessos> lista = new List<MOD_acessos>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_acessos ent = new MOD_acessos();
                    //adiciona os campos às propriedades
                    ent.CodAcesso = (string)(row.IsNull("CodAcesso") ? Convert.ToString(null) : Convert.ToString(row["CodAcesso"]).PadLeft(6, '0'));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.Supervisor = (string)(row.IsNull("Supervisor") ? null : row["Supervisor"]);
                    ent.CodModulo = (string)(row.IsNull("CodModulo") ? Convert.ToString(null) : Convert.ToString(row["CodModulo"]).PadLeft(3, '0'));
                    ent.DescModulo = (string)(row.IsNull("DescModulo") ? null : row["DescModulo"]);
                    ent.CodSubModulo = (string)(row.IsNull("CodSubModulo") ? Convert.ToString(null) : Convert.ToString(row["CodSubModulo"]).PadLeft(4, '0'));
                    ent.DescSubModulo = (string)(row.IsNull("DescSubModulo") ? null : row["DescSubModulo"]);
                    ent.CodPrograma = (string)(row.IsNull("CodPrograma") ? Convert.ToString(null) : Convert.ToString(row["CodPrograma"]).PadLeft(5, '0'));
                    ent.DescPrograma = (string)(row.IsNull("DescPrograma") ? null : row["DescPrograma"]);
                    ent.CodRotina = (string)(row.IsNull("CodRotina") ? Convert.ToString(null) : Convert.ToString(row["CodRotina"]).PadLeft(6, '0'));
                    ent.DescRotina = (string)(row.IsNull("DescRotina") ? null : row["DescRotina"]);
                    ent.DescInd = (string)(row.IsNull("DescInd") ? null : row["DescInd"]);
                    ent.DescSeg = (string)(row.IsNull("DescSeg") ? null : row["DescSeg"]);
                    ent.NivelRotina = (string)(row.IsNull("NivelRotina") ? Convert.ToString(null) : Convert.ToString(row["NivelRotina"]));
                    ent.Marcado = true;

                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
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
        /// Função que Retorna uma Lista da Tabela Rotinas Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_rotinas> criarListaRotina(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_rotinas> lista = new List<MOD_rotinas>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_rotinas ent = new MOD_rotinas();
                    //adiciona os campos às propriedades
                    ent.CodModulo = (string)(row.IsNull("CodModulo") ? Convert.ToString(null) : Convert.ToString(row["CodModulo"]).PadLeft(3, '0'));
                    ent.DescModulo = (string)(row.IsNull("DescModulo") ? null : row["DescModulo"]);
                    ent.CodSubModulo = (string)(row.IsNull("CodSubModulo") ? Convert.ToString(null) : Convert.ToString(row["CodSubModulo"]).PadLeft(4, '0'));
                    ent.DescSubModulo = (string)(row.IsNull("DescSubModulo") ? null : row["DescSubModulo"]);
                    ent.CodPrograma = (string)(row.IsNull("CodPrograma") ? Convert.ToString(null) : Convert.ToString(row["CodPrograma"]).PadLeft(5, '0'));
                    ent.DescPrograma = (string)(row.IsNull("DescPrograma") ? null : row["DescPrograma"]);
                    ent.CodRotina = (string)(row.IsNull("CodRotina") ? Convert.ToString(null) : Convert.ToString(row["CodRotina"]).PadLeft(6, '0'));
                    ent.DescRotina = (string)(row.IsNull("DescRotina") ? null : row["DescRotina"]);
                    ent.DescInd = (string)(row.IsNull("DescInd") ? null : row["DescInd"]);
                    ent.DescSeg = (string)(row.IsNull("DescSeg") ? null : row["DescSeg"]);
                    ent.NivelRotina = (string)(row.IsNull("NivelRotina") ? Convert.ToString(null) : Convert.ToString(row["NivelRotina"]));
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
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

        #endregion

        #region Funções de apoio para validações

        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_log validaDadosLog(MOD_log ent)
        {
            ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
            ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

            return ent;
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Insert, Update ou Delete</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_acessos ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                ent.Logs.CodRotina = "133";

                ent.Logs.NomePc = modulos.DescPc;

                ent.Logs.CodRotina = Convert.ToString(MOD_acessoUsuario.RotLibAcessoUsuario);
                ent.Logs.Ocorrencia = "Foi feito " + Operacao.ToUpper() + " de acesso referente à rotina: < " + ent.CodRotina.PadLeft(5, '0') + " > " + " no cadastro do usuário Código: < " + ent.CodUsuario + " > Nome: < " + ent.Nome + " > ";

                ent.Logs.Ocorrencia = "Liberado o Acesso ref. a Rotina < " + ent.CodRotina + " > para o Usuario < " + ent.Usuario + " >. ";
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }

        #endregion

    }
}
