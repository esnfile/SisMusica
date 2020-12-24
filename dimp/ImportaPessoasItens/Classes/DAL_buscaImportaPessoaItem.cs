using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.importa
{
    public class DAL_buscaImportaPessoaItem : IDAL_buscaImportaPessoaItem
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_ImportaPessoaItem_StrSql objDAL = new DAL_ImportaPessoaItem_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela ImportaPessoaItem, para importação de novos dados
        /// </summary>
        /// <param name="CodCCBUsuario"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodCCBUsuario)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodCCBUsuario", CodCCBUsuario)
                };
                return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE P.CodCCB IN(" + @CodCCBUsuario + ") ", objParam, "ImportaPessoaItem");
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
        /// Função que retorna os Registros da tabela ImportaPessoaItem, para importação de novos dados
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <param name="CodCCBUsuario"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodCCBUsuario, string CodImportaPessoa)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodCCBUsuario", CodCCBUsuario),
                    new SqlParameter("@CodImportaPessoa", CodImportaPessoa)
                };

                if (string.IsNullOrEmpty(CodImportaPessoa))
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE P.CodCCB IN(" + @CodCCBUsuario + ") ", objParam, "ImportaPessoaItem");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE P.CodImportaPessoa = @CodImportaPessoa AND P.CodCCB IN(" + @CodCCBUsuario + ") ", objParam, "ImportaPessoaItem");
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
        /// Função que retorna os Registros da tabela ImportaPessoaItem, para importação de novos dados
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <param name="CodCCBUsuario"></param>
        /// <param name="CodCargoUsuario"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodCCBUsuario, string CodImportaPessoa, string CodCargoUsuario)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodCCBUsuario", CodCCBUsuario),
                    new SqlParameter("@CodImportaPessoa", CodImportaPessoa),
                    new SqlParameter("@CodCargoUsuario", CodCargoUsuario)
                };

                if (string.IsNullOrEmpty(CodImportaPessoa))
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE P.CodCCB IN(" + @CodCCBUsuario + ") AND " +
                                                          "P.CodCargo IN(" + @CodCargoUsuario + ") ", objParam, "ImportaPessoaItem");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE P.CodImportaPessoa = @CodImportaPessoa AND " +
                                                            "P.CodCCB IN(" + @CodCCBUsuario + ") AND " +
                                                            "P.CodCargo IN(" + @CodCargoUsuario + ") ", objParam, "ImportaPessoaItem");
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