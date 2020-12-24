using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaVisaoOrquestral
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Pessoa_StrSql objDAL_Pessoa = new DAL_pessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarVisaoOrquestral(string CodInstrumento, string CodCCB, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + CodCCB + ") AND P.Ativo = @Ativo ORDER BY CC.Cidade, CM.Descricao, I.CodFamilia, P.Nome ", objParam, "Pessoa");
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