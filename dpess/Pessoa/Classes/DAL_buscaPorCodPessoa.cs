using DAL.Acessa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.pessoa
{
    public class DAL_buscaPorCodPessoa : IDAL_buscaPessoa
    {

        //dataTable para preencher a lista
        DataTable objDtb = null;
        IConnect objAcessa = new acessa();
        IDAL_Pessoa_StrSql objDAL_Pessoa = new DAL_pessoa_StrSql();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodPessoa = @CodPessoa ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código e Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, bool Ativo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.Ativo LIKE @Ativo ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodPessoa = @CodPessoa AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodCCBUsu)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código, Comum e somente ativos
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
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
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código, Comum e somente ativos
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable Buscar(string CodPessoa, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(objDAL_Pessoa.StrSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
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