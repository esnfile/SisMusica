using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaCCB : IDAL_buscaPessoaCCB
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_pessoaCCB_StrSql objDAL_PessoaCCB = new DAL_pessoaCCB_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo CodCCB.*\
        /// Essa Consulta retorna os valores que não estão na Tabela PessoaCCB
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa)
        {
            try
            {
                IDAL_pessoaCCB_StrSql obj_strSql = new DAL_pessoaCCB_StrSql();

                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(obj_strSql.StrSelectCCB + "WHERE C.CodCCB NOT IN (SELECT CodCCB FROM CCBPessoa WHERE CodPessoa = @CodPessoa) " +
                                                          "ORDER BY C.Descricao ", objParam, "CCB");
                //instancia a lista
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo CodCCB.*\
        /// Essa Consulta retorna os valores que não estão na Tabela PessoaCCB
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodCCB)
        {
            try
            {
                IDAL_pessoaCCB_StrSql obj_strSql = new DAL_pessoaCCB_StrSql();

                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(obj_strSql.StrSelectCCB + "WHERE C.CodCCB NOT IN (SELECT CodCCB FROM CCBPessoa WHERE CodPessoa = @CodPessoa) AND " +
                                                          "C.CodCCB = @CodCCB " +
                                                          "ORDER BY C.Descricao ", objParam, "CCB");
                //instancia a lista
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

    }
}