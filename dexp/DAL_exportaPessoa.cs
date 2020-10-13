using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DAL.Acessa;
using ENT.exporta;

namespace DAL.exporta
{
    public class DAL_exportaPessoa
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idExporta = null;

        #endregion

        #region Strings Sql da tabela ExportaPessoa

        //string de insert na tabela ExportaPessoa
        private string strInsert = "INSERT INTO ExportaPessoa (CodExportaPessoa, DataExporta, HoraExporta, CodUsuario, QtdeArquivo) " +
"VALUES (@CodExportaPessoa, @DataExporta, @HoraExporta, @CodUsuario, @QtdeArquivo) ";

        //string de update na tabela ExportaPessoa
        private string strUpdate = "UPDATE ExportaPessoa SET DataExporta = @DataExporta, HoraExporta = @HoraExporta, CodUsuario = @CodUsuario, " +
"QtdeArquivo = @QtdeArquivo " +
"WHERE CodExportaPessoa = @CodExportaPessoa ";

        //string de delete na tabela ExportaPessoa
        private string strDelete = "DELETE FROM ExportaPessoa WHERE CodExportaPessoa = @CodExportaPessoa ";

        //string de select na tabela ExportaPessoa
        private string strSelect = "SELECT E.CodExportaPessoa, E.DataExporta, E.CodUsuario, E.HoraExporta, E.QtdeArquivo, " +
"U.CodPessoa, U.Usuario, P.Nome " +
"FROM ExportaPessoa AS E " +
"LEFT OUTER JOIN Usuario AS U ON E.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string de select na tabela ExportaPessoa - retorna o ultimo registro
        private string strSelectUltimo = "SELECT TOP 1 E.CodExportaPessoa, E.DataExporta, E.CodUsuario, E.HoraExporta, E.QtdeArquivo, " +
"U.CodPessoa, U.Usuario, P.Nome " +
"FROM ExportaPessoa AS E " +
"LEFT OUTER JOIN Usuario AS U ON E.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string que retorna o próximo Id da tabela ExportaPessoa
        private string strId = "SELECT MAX (CodExportaPessoa) FROM ExportaPessoa ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela ExportaPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_exportaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ExportaPessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodExportaPessoa", Convert.ToInt64(objEnt.CodExportaPessoa)));
                objParam.Add(new SqlParameter("@DataExporta", string.IsNullOrEmpty(objEnt.DataExporta) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataExporta) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@HoraExporta", string.IsNullOrEmpty(objEnt.HoraExporta) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraExporta) as object));
                objParam.Add(new SqlParameter("@QtdeArquivo", string.IsNullOrEmpty(objEnt.QtdeArquivo) ? DBNull.Value as object : Convert.ToInt32(objEnt.QtdeArquivo) as object));

                blnRetorno = objAcessa.executar(strUpdate, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                throw new Exception("Erro na DAL exportaPessoa: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na DAL exportaPessoa: " + ex.Message);
            }
        }

        /// <summary>
        /// Função que faz INSERT na Tabela ExportaPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_exportaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ExportaPessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodExportaPessoa", Convert.ToInt64(objEnt.CodExportaPessoa)));
                objParam.Add(new SqlParameter("@DataExporta", string.IsNullOrEmpty(objEnt.DataExporta) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataExporta) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@HoraExporta", string.IsNullOrEmpty(objEnt.HoraExporta) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraExporta) as object));
                objParam.Add(new SqlParameter("@QtdeArquivo", string.IsNullOrEmpty(objEnt.QtdeArquivo) ? DBNull.Value as object : Convert.ToInt32(objEnt.QtdeArquivo) as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                throw new Exception("Erro na DAL importaPessoa: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na DAL importaPessoa: " + ex.Message);
            }
        }

        #endregion

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela ExportaPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_exportaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ExportaPessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodExportaPessoa", Convert.ToInt64(objEnt.CodExportaPessoa)));
                blnRetorno = objAcessa.executar(strDelete, objParam);

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
        /// Função que retorna os Registros da tabela ExportaPessoa, pesquisado pelo Código
        /// </summary>
        /// <param name="CodExportaPessoa"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodExportaPessoa)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodExportaPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodExportaPessoa", CodExportaPessoa));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY E.CodExportaPessoa ", objParam, "ExportaPessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodExportaPessoa", CodExportaPessoa));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE E.CodExportaPessoa = @CodExportaPessoa ORDER BY E.CodExportaPessoa", objParam, "ExportaPessoa");
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
        /// Função que retorna os Registros da tabela ExportaPessoa, pesquisado pela DataExporta
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public DataTable buscarDataExporta(string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE E.DataExporta BETWEEN @DataInicial AND @DataFinal ORDER BY E.DataExporta ", objParam, "ExportaPessoa");
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
        /// Função que retorna os Registros da tabela ExportaPessoa, retornando o ultimo registro
        /// </summary>
        /// <returns></returns>
        public DataTable buscarDataUltimoRegistro()
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objDtb = objAcessa.retornaDados(strSelectUltimo + "ORDER BY E.DataExporta DESC ", objParam, "ExportaPessoa");
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
        public Int32 retornaId()
        {
            try
            {
                idExporta = objAcessa.retornarId(strId);
                return Convert.ToInt32(idExporta);
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
