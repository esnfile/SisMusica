using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.importa
{
    public class DAL_buscaPorDataImportaPessoa : IDAL_buscaPorDataImportaPessoa
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_ImportaPessoa_StrSql objDAL = new DAL_ImportaPessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela ImportaPessoa, pesquisado pela DataImporta
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public DataTable Buscar(string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@DataInicial", DataInicial),
                    new SqlParameter("@DataFinal", DataFinal)
                };
                return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE I.DataImporta BETWEEN @DataInicial AND @DataFinal ORDER BY I.DataImporta ", objParam, "ImportaPessoa");
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