using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPorRegiao : IDAL_buscaPessoa
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Pessoa_StrSql objDAL_Pessoa = new DAL_pessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodRegiao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE CM.CodRegiao = @CodRegiao ORDER BY P.Nome ", objParam, "Pessoa");
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodRegiao, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodRegiao, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.Nome", objParam, "Pessoa");
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodRegiao, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodRegiao, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.Nome", objParam, "Pessoa");
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodRegiao, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
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