using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.pessoa;

namespace DAL.pessoa
{
    public class DAL_pessoaMetodo : IDAL_PessoaMetodo
    {

        IConnect objAcessa = new acessa();
        IDAL_pessoaMetodo_StrSql objDAL_strSql = new DAL_pessoaMetodo_StrSql();

        #region Instruções CRUD

        /// <summary>
        /// Função INSERT - Utilziada para Inserir os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Insert(MOD_pessoaMetodo pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaInstr
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaInstr
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(pessoa.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodPessoa) as object),
                    new SqlParameter("@CodMetodo", string.IsNullOrEmpty(pessoa.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(pessoa.CodMetodo) as object),
                };

                return blnRetorno = objAcessa.executar(objDAL_strSql.StrInsert, objParam);
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
        /// Função DELETE - Utilziada para Excluir os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Delete(MOD_pessoaMetodo pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaInstr
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaInstr
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(pessoa.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodPessoa) as object),
                    new SqlParameter("@CodMetodo", string.IsNullOrEmpty(pessoa.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(pessoa.CodMetodo) as object),
                };

                return blnRetorno = objAcessa.executar(objDAL_strSql.StrDelete, objParam);
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

        #endregion

    }
}