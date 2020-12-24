using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.importa
{
    public class DAL_buscaPorCodImportaPessoa : IDAL_buscaPorCodImportaPessoa
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_ImportaPessoa_StrSql objDAL = new DAL_ImportaPessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodImportaPessoa)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodImportaPessoa", CodImportaPessoa)
                };

                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodImportaPessoa))
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "ORDER BY I.CodImportaPessoa ", objParam, "ImportaPessoa");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE I.CodImportaPessoa = @CodImportaPessoa ORDER BY I.CodImportaPessoa", objParam, "ImportaPessoa");
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