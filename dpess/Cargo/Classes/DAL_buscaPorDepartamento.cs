using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.cargo
{
    public class DAL_buscaPorDepartamento : IDAL_buscaCargo
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Cargo_StrSql objDAL = new DAL_cargo_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Cargo, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodDepartamento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodDepartamento", CodDepartamento),
                };
                //verificar qual é o campo a ser buscado
                return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE C.CodDepartamento = @CodDepartamento ORDER BY C.DescCargo ", objParam, "Cargo");
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