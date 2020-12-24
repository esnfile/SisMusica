using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.cargo
{
    public class DAL_buscaPorDescricao : IDAL_buscaCargo
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Cargo_StrSql objDAL = new DAL_cargo_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Cargo, pesquisado pelo DescCargo
        /// </summary>
        /// <param name="DescCargo"></param>
        /// <returns></returns>
        public DataTable Buscar(string DescCargo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@DescCargo", DescCargo),
                };
                return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE C.DescCargo LIKE @DescCargo ORDER BY C.DescCargo ", objParam, "Cargo");
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