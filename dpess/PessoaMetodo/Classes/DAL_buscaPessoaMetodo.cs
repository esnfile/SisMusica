using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPessoaMetodo : IDAL_buscaPessoaMetodo
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_pessoaMetodo_StrSql obj_strSql = new DAL_pessoaMetodo_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela MetodoInstrumento, pesquisado pelo CodMetodo.*\
        /// Essa Consulta retorna os valores que estão na Tabela PessoaMetodo
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

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "ORDER BY P.Nome, M.DescMetodo ", objParam, "MetodoInstr");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodPessoa = @CodPessoa " +
                                                              "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstrumento, pesquisado pelo CodMetodo.*\
        /// Essa Consulta retorna os valores que estão na Tabela PessoaMetodo
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodMetodo)
        {
            try
            {
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                    new SqlParameter("@CodMetodo", CodMetodo),
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodMetodo = @CodMetodo " +
                                                              "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodPessoa = @CodPessoa AND " +
                                                              "PM.CodMetodo = @CodMetodo " +
                                                              "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstrumento, pesquisado pelo CodMetodo.*\
        /// Essa Consulta retorna os valores que estão na Tabela PessoaMetodo
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodMetodo"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodMetodo, string Ativo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                    new SqlParameter("@CodMetodo", CodMetodo),
                    new SqlParameter("@Ativo", Ativo),
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodMetodo = @CodMetodo AND " +
                                                           "M.Ativo = @Ativo " +
                                                           "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodPessoa = @CodPessoa AND " +
                                                           "PM.CodMetodo = @CodMetodo AND " +
                                                           "M.Ativo = @Ativo " +
                                                           "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstrumento, pesquisado pelo CodMetodo.*\
        /// Essa Consulta retorna os valores que estão na Tabela PessoaMetodo
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodMetodo"></param>
        /// <param name="CodInstrumento"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodMetodo, string Ativo, string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                    new SqlParameter("@CodMetodo", CodMetodo),
                    new SqlParameter("@CodInstrumento", CodInstrumento),
                    new SqlParameter("@Ativo", Ativo),
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodMetodo = @CodMetodo AND " +
                                                           "MI.CodInstrumento = @CodInstrumento AND " +
                                                           "M.Ativo = @Ativo " +
                                                           "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodPessoa = @CodPessoa AND " +
                                                           "PM.CodMetodo = @CodMetodo AND " +
                                                           "MI.CodInstrumento = @CodInstrumento AND " +
                                                           "M.Ativo = @Ativo " +
                                                           "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstrumento, pesquisado pelo CodMetodo.*\
        /// Essa Consulta retorna os valores que estão na Tabela PessoaMetodo
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodMetodo"></param>
        /// <param name="CodInstrumento"></param>
        /// <param name="Ativo"></param>
        /// <param name="AplicarEm"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodMetodo, string Ativo, string CodInstrumento, string AplicarEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                    new SqlParameter("@CodMetodo", CodMetodo),
                    new SqlParameter("@CodInstrumento", CodInstrumento),
                    new SqlParameter("@Ativo", Ativo),
                    new SqlParameter("@AplicarEm", AplicarEm),
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodMetodo = @CodMetodo AND " +
                                                           "MI.CodInstrumento = @CodInstrumento AND " +
                                                           "MI.AplicarEm = @AplicarEm AND " +
                                                           "M.Ativo = @Ativo " +
                                                           "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(obj_strSql.StrSelect + "WHERE PM.CodPessoa = @CodPessoa AND " +
                                                           "PM.CodMetodo = @CodMetodo AND " +
                                                           "MI.CodInstrumento = @CodInstrumento AND " +
                                                           "MI.AplicarEm = @AplicarEm AND " +
                                                           "M.Ativo = @Ativo " +
                                                           "ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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