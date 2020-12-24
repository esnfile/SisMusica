using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.cargo
{
    public class DAL_buscaPorCodigo : IDAL_buscaCargo
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Cargo_StrSql objDAL = new DAL_cargo_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Cargo, pesquisado pelo CodCargo
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodCargo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodCargo", CodCargo),
                };

                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodCargo))
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "ORDER BY C.CodCargo ", objParam, "Cargo");
                }
                else
                {
                    return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE C.CodCargo = @CodCargo ORDER BY C.CodCargo", objParam, "Cargo");
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