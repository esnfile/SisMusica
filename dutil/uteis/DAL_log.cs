using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.uteis;
using ENT.Log;

namespace DAL.log
{
    public class DAL_log
    {

        #region declarações

        //classe que acessa o banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idLog = null;

        #endregion

        #region Strings Sql da tabela Logs

        //string de insert na tabela Logs
        private string strInsertLog = "INSERT INTO Logs (CodLog, Data, Hora, CodUsuario, CodRotina, NomePc, Ocorrencia, CodCCB) " +
"VALUES (@CodLog, @Data, @Hora, @CodUsuario, @CodRotina, @NomePc, @Ocorrencia, @CodCCB) ";

        //string de select na tabela Logs
        private string strSelectLog = "SELECT L.CodLog, L.Data, L.Hora, L.CodUsuario, L.CodRotina, L.NomePc, L.Ocorrencia, L.CodCCB, " +
"U.CodPessoa, U.Usuario, PS.Nome, R.DescRotina, R.CodPrograma, P.DescPrograma, P.CodSubModulo, S.DescSubModulo, S.CodModulo, M.DescModulo, C.Codigo, C.Descricao " +
"FROM Logs AS L " +
"LEFT OUTER JOIN Usuario AS U ON L.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN CCB AS C ON L.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN Rotina AS R ON L.CodRotina = R.CodRotina " +
"LEFT OUTER JOIN Programa AS P ON R.CodPrograma = P.CodPrograma " +
"LEFT OUTER JOIN SubModulos AS S ON P.CodSubModulo = S.CodSubModulo " +
"LEFT OUTER JOIN Modulos AS M ON S.CodModulo = M.CodModulo " +
"LEFT OUTER JOIN Pessoa AS PS ON U.CodPessoa = PS.CodPessoa ";

        //string que retorna o próximo Id da tabela Logs
        private string strIdLog = "SELECT MAX (CodLog) AS CodLog FROM Logs ";

        #endregion

        #region Função para Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT na Tabela Logs
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_log objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Logs
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela Logs
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodLog", retornaId()));
                objParam.Add(new SqlParameter("@Data", string.IsNullOrEmpty(objEnt.Data) ? DBNull.Value as object : Convert.ToInt32(objEnt.Data) as object));
                objParam.Add(new SqlParameter("@Hora", string.IsNullOrEmpty(objEnt.Hora) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hora) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@CodRotina", string.IsNullOrEmpty(objEnt.CodRotina) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRotina) as object));
                objParam.Add(new SqlParameter("@NomePc", string.IsNullOrEmpty(objEnt.NomePc) ? DBNull.Value as object : objEnt.NomePc as object));
                objParam.Add(new SqlParameter("@Ocorrencia", string.IsNullOrEmpty(objEnt.Ocorrencia) ? DBNull.Value as object : objEnt.Ocorrencia as object));
                objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCCB) as object));

                blnRetorno = objAcessa.executar(strInsertLog, objParam);

                //retorna o blnRetorno da tabela principal
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

        #endregion

        #region Funções para buscar os dados e Preencher os Valores

        /// <summary>
        /// Função que retorna os Registros da tabela Logs, pesquisado pelo Código
        /// </summary>
        /// <param name="CodLog"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodLog, string CodCCB)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodLog))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodLog", Convert.ToInt64(CodLog)));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelectLog + "WHERE L.CodCCB IN(@CodCCB) ORDER BY L.CodLog ", objParam, "Logs");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodLog", Convert.ToInt64(CodLog)));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelectLog + "WHERE L.CodLog = @CodLog AND L.CodCCB IN(@CodCCB) ORDER BY L.CodLog", objParam, "Logs");
                    return objDtb;
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
        /// Função que retorna os Registros da tabela Logs, pesquisado pelo Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarUsuario(string CodUsuario, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", Convert.ToInt16(CodUsuario)));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelectLog + "WHERE L.CodUsuario = @CodUsuario AND L.CodCCB IN(@CodCCB) ORDER BY L.Data ", objParam, "Logs");
                return objDtb;
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
        /// Função que retorna os Registros da tabela Logs, pesquisado pela Rotina
        /// </summary>
        /// <param name="CodRotina"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarRotina(string CodRotina, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRotina", Convert.ToInt32(CodRotina)));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelectLog + "WHERE L.CodRotina = @CodRotina AND L.CodCCB IN(@CodCCB) ORDER BY L.Data, PS.Nome ", objParam, "Logs");
                return objDtb;
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
        /// Função que retorna os Registros da tabela Logs, pesquisado pela Data
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarData(string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", Convert.ToInt32(DataInicial)));
                objParam.Add(new SqlParameter("@DataFinal", Convert.ToInt32(DataFinal)));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelectLog + "WHERE L.Data BETWEEN @DataInicial AND @DataFinal AND L.CodCCB IN(@CodCCB) ORDER BY L.Data, PS.Nome ", objParam, "Logs");
                return objDtb;
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

        #region Funções Publicas e Privadas Usadas para retorno de Valores

        /// <summary>
        /// Função que retorna o Ultimo Código inserido na Tabela
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                idLog = objAcessa.retornarId(strIdLog);
                return Convert.ToInt64(idLog);
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
