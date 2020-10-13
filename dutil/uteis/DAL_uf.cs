using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.uteis;

namespace DAL.uteis
{
    public class DAL_uf
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;

        #endregion

        #region Strings Sql da tabela Uf

        //string de insert na tabela Uf
        private string strInsert = "INSERT INTO Uf (Sigla, Uf) " +
"VALUES (@Sigla, @Uf) ";

        //string de update na tabela Uf
        private string strUpdate = "UPDATE Uf SET Uf = @Uf " +
"WHERE Sigla = @Sigla ";

        //string de delete na tabela Uf
        private string strDelete = "DELETE FROM Uf WHERE Sigla = @Sigla ";

        //string de select na tabela Uf
        private string strSelect = "SELECT Sigla, Uf " +
"FROM Uf ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Uf
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_uf objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Uf
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@Sigla", string.IsNullOrEmpty(objEnt.Sigla) ? DBNull.Value as object : objEnt.Sigla as object));
                objParam.Add(new SqlParameter("@Uf", string.IsNullOrEmpty(objEnt.Uf) ? DBNull.Value as object : objEnt.Uf as object));
                blnRetorno = objAcessa.executar(strUpdate, objParam);

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

        /// <summary>
        /// Função que faz INSERT na Tabela Uf
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_uf objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Uf
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@Sigla", string.IsNullOrEmpty(objEnt.Sigla) ? DBNull.Value as object : objEnt.Sigla as object));
                objParam.Add(new SqlParameter("@Uf", string.IsNullOrEmpty(objEnt.Uf) ? DBNull.Value as object : objEnt.Uf as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

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

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela Uf
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_uf objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Uf
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@Sigla", objEnt.Sigla));
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
        /// Função que retorna os Registros da tabela Uf, pesquisado pela Sigla
        /// </summary>
        /// <param name="Sigla"></param>
        /// <returns></returns>
        public DataTable buscarSigla(string Sigla)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sigla", Sigla));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Sigla LIKE @Sigla ORDER BY Sigla ", objParam, "Uf");
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
        /// Função que retorna os Registros da tabela Uf, pesquisado pela Uf
        /// </summary>
        /// <param name="Uf"></param>
        /// <returns></returns>
        public DataTable buscarUf(string Uf)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Uf", Uf));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Uf LIKE @Uf ORDER BY Uf ", objParam, "Uf");
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

    }
}
