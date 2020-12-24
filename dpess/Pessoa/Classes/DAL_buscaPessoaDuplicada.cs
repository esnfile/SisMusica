using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPessoaDuplicada
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Pessoa_StrSql objDAL_Pessoa = new DAL_pessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, para importação de novos dados
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="DataNasc"></param>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public DataTable buscarPessoaDuplicada(string Nome, string DataNasc, string CodCidade)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@DataNasc", DataNasc));
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidade));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.Nome LIKE @Nome AND P.DataNasc = @DataNasc AND P.CodCidadeRes = @CodCidadeRes ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
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