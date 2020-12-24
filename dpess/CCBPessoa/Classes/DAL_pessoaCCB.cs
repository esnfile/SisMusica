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
    public class DAL_pessoaCCB : IDAL_PessoaCCB
    {

        IConnect objAcessa = new acessa();
        IDAL_pessoaCCB_StrSql objDAL = new DAL_pessoaCCB_StrSql();

        #region Instruções CRUD

        /// <summary>
        /// Função INSERT - Utilziada para Inserir os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Insert(MOD_pessoaCCB pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaInstr
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaInstr
                List<SqlParameter> objParam = new List<SqlParameter>();

                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(pessoa.CodPessoa) as object));
                objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(pessoa.CodCCB) as object));

                blnRetorno = objAcessa.executar(objDAL.StrInsert, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;
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
        public bool Delete(MOD_pessoaCCB pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaInstr
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaInstr
                List<SqlParameter> objParam = new List<SqlParameter>();

                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(pessoa.CodPessoa)));
                objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(pessoa.CodCCB)));

                blnRetorno = objAcessa.executar(objDAL.StrDelete, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;
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