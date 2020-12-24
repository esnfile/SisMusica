using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaInstrumentos : IDAL_buscaPessoaInstr
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_pessoaInstr_StrSql obj_strSql = new DAL_pessoaInstr_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pelo CodInstrumento.*\
        /// Essa Consulta retorna os valores que não estão na Tabela PessoaInstrumento
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                };
                return objDtb = objAcessa.retornaDados(obj_strSql.StrSelectInstrumentos + "WHERE I.CodInstrumento NOT IN (SELECT CodInstrumento FROM PessoaInstr WHERE CodPessoa = @CodPessoa) " +
                                                          "ORDER BY I.Ordem ", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pelo CodInstrumento.*\
        /// Essa Consulta retorna os valores que não estão na Tabela PessoaInstrumento
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                    new SqlParameter("@CodInstrumento", CodInstrumento),
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelectInstrumentos + "WHERE I.CodInstrumento NOT IN (SELECT CodInstrumento FROM PessoaInstr WHERE CodPessoa = @CodPessoa) AND " +
                                                              "I.CodInstrumento = @CodInstrumento " +
                                                              "ORDER BY I.Ordem ", objParam, "Instrumentos");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelectInstrumentos + "WHERE I.CodInstrumento = @CodInstrumento " +
                                                              "ORDER BY I.Ordem ", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pelo CodInstrumento.*\
        /// Essa Consulta retorna os valores que não estão na Tabela PessoaInstrumento
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodInstrumento"></param>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodInstrumento, string Situacao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                    new SqlParameter("@CodInstrumento", CodInstrumento),
                    new SqlParameter("@Situacao", Situacao),
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelectInstrumentos + "WHERE I.CodInstrumento = @CodInstrumento AND " +
                                                          "I.Situacao IN('" + @Situacao + "') " +
                                                          "ORDER BY I.Ordem ", objParam, "Instrumentos");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelectInstrumentos + "WHERE I.CodInstrumento NOT IN (SELECT CodInstrumento FROM PessoaInstr WHERE CodPessoa = @CodPessoa) AND " +
                                                           "I.CodInstrumento = @CodInstrumento AND " +
                                                           "I.Situacao IN('" + @Situacao + "') " +
                                                           "ORDER BY I.Ordem ", objParam, "Instrumentos");
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
    }
}