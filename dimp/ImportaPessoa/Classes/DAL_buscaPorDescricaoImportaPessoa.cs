using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.importa
{
    public class DAL_buscaPorDescricaoImportaPessoa : IDAL_buscaPorDescricaoImportaPessoa
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_ImportaPessoa_StrSql objDAL = new DAL_ImportaPessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Descricao
        /// </summary>
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public DataTable Buscar(string Descricao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@Descricao", Descricao)
                };

                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                return objDtb = objAcessa.retornaDados(objDAL.StrSelect + "WHERE I.Descricao = @Descricao ORDER BY I.Descricao", objParam, "ImportaPessoa");
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