using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPessoaCCB : IDAL_buscaPessoaCCB
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_pessoaCCB_StrSql objDAL_PessoaCCB = new DAL_pessoaCCB_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela PessoaCCB, pesquisado pela Pessoa
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
                return objDtb = objAcessa.retornaDados(objDAL_PessoaCCB.StrSelect + "WHERE PC.CodPessoa = @CodPessoa " +
                                                            "ORDER BY C.Descricao ", objParam, "PessoaCCB");
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
        /// Função que retorna os Registros da tabela PessoaCCB, pesquisado pela Pessoa e CodInstrumento
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodCCB)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", CodPessoa),
                    new SqlParameter("@CodCCB", CodCCB)
                };

                if (string.IsNullOrEmpty(CodPessoa))
                {
                    return objDtb = objAcessa.retornaDados(objDAL_PessoaCCB.StrSelect + "WHERE PC.CodCCB = @CodCCB " +
                                                                      "ORDER BY C.Descricao ", objParam, "PessoaCCB");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(objDAL_PessoaCCB.StrSelect + "WHERE PC.CodPessoa = @CodPessoa AND " +
                                                                      "PC.CodCCB = @CodCCB " +
                                                                      "ORDER BY C.Descricao ", objParam, "PessoaCCB");
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