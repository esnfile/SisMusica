using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.Acessa;

namespace DAL.pessoa
{
    public class DAL_pessoaFoto : IDAL_PessoaFoto
    {

        IConnect objAcessa = new acessa();
        IDAL_pessoaFoto_StrSql objDAL = new DAL_pessoaFoto_StrSql();
        
        #region Instruções CRUD

        /// <summary>
        /// Função UPDATE - Utilziada para Atualizar os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Update(MOD_pessoaFoto pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    //parametros da tabela principal
                    new SqlParameter("@CodFoto", string.IsNullOrEmpty(pessoa.CodFoto) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodFoto) as object),
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(pessoa.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodPessoa) as object),
                    new SqlParameter("@Foto", pessoa.Foto as object)
                };

                return blnRetorno = objAcessa.executar(objDAL.StrUpdate, objParam);
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
        /// Função INSERT - Utilziada para Inserir os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Insert(MOD_pessoaFoto pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodFoto", string.IsNullOrEmpty(pessoa.CodFoto) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodFoto) as object),
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(pessoa.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodPessoa) as object),
                    new SqlParameter("@Foto", pessoa.Foto as object),
                };

                return blnRetorno = objAcessa.executar(objDAL.StrInsert, objParam);
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
        public bool Delete(MOD_pessoaFoto pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodPessoa", Convert.ToInt64(pessoa.CodPessoa))
                };

                return blnRetorno = objAcessa.executar(objDAL.StrDelete, objParam);
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

        #region Funções que retorna o próximo ID a ser inserido

        /// <summary>
        /// Função RETORNAID - Utilziada para Retornar o próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 RetornaId()
        {
            try
            {
                object idPessoaFoto = objAcessa.retornarId(objDAL.StrRetornaId);
                return Convert.ToInt64(idPessoaFoto);
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