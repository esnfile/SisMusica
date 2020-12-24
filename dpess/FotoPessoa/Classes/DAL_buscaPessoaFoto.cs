using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPessoaFoto : IDAL_buscaPessoaFoto
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_pessoaFoto_StrSql objDAL = new DAL_pessoaFoto_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, para importação de novos dados
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE F.CodPessoa = @CodPessoa ", objParam, "PessoaFoto");
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