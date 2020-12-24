using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPessoaInstr : IDAL_buscaPessoaInstr
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_pessoaInstr_StrSql objDAL_PessoaInstr = new DAL_pessoaInstr_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela PessoaInstr, pesquisado pela Pessoa
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
                    new SqlParameter("@CodPessoa", CodPessoa)
                };
                return objDtb = objAcessa.retornaDados(objDAL_PessoaInstr.StrSelect + "WHERE PI.CodPessoa = @CodPessoa " +
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
        /// Função que retorna os Registros da tabela PessoaInstr, pesquisado pela Pessoa e CodInstrumento
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
                    new SqlParameter("@CodInstrumento", CodInstrumento)
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(objDAL_PessoaInstr.StrSelect + "WHERE PI.CodInstrumento = @CodInstrumento " +
                                                                        "ORDER BY I.Ordem ", objParam, "Instrumentos");
                }
                else
                {
                   return objDtb = objAcessa.retornaDados(objDAL_PessoaInstr.StrSelect + "WHERE PI.CodPessoa = @CodPessoa AND " +
                                                                       "PI.CodInstrumento = @CodInstrumento " +
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
        /// Função que retorna os Registros da tabela PessoaInstr, pesquisado pela Pessoa, Instrumento e Situação
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
                    new SqlParameter("@Situacao", Situacao)
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(objDAL_PessoaInstr.StrSelect + "WHERE PI.CodInstrumento = @CodInstrumento AND " +
                                                                    "I.Situacao IN('" + @Situacao + "') " +
                                                                    "ORDER BY I.Ordem ", objParam, "Instrumentos");
                }
                else
                {
                   return objDtb = objAcessa.retornaDados(objDAL_PessoaInstr.StrSelect + "WHERE I.CodInstrumento IN (SELECT CodInstrumento FROM PessoaInstr WHERE CodPessoa = @CodPessoa) AND " +
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