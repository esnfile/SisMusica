using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPorInstrumento : IDAL_buscaPessoa
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Pessoa_StrSql objDAL_Pessoa = new DAL_pessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodInstrumento IN(@CodInstrumento) ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
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
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodInstrumento, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodInstrumento IN(@CodInstrumento) AND P.Ativo LIKE @Ativo ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
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
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodInstrumento, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
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
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodInstrumento, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
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
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodInstrumento, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
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
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodInstrumento, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
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