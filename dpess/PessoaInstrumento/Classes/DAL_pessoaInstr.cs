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
    public class DAL_pessoaInstr : IDAL_PessoaInstr
    {

        IConnect objAcessa = new acessa();
        IDAL_pessoaInstr_StrSql objDAL_Pessoa = new DAL_pessoaInstr_StrSql();

        #region Instruções CRUD

        /// <summary>
        /// Função INSERT - Utilziada para Inserir os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Insert(MOD_pessoaInstr pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaInstr
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaInstr
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                    //parametros da tabela principal
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(pessoa.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodPessoa) as object),
                    new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(pessoa.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(pessoa.CodInstrumento) as object)
                };

                blnRetorno = objAcessa.executar(objDAL_Pessoa.StrInsert, objParam);

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
        public bool Delete(MOD_pessoaInstr pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaInstr
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaInstr
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    //parametros da tabela principal
                    new SqlParameter("@CodPessoa", Convert.ToInt64(pessoa.CodPessoa)),
                    new SqlParameter("@CodInstrumento", Convert.ToInt16(pessoa.CodInstrumento))
                };

                blnRetorno = objAcessa.executar(objDAL_Pessoa.StrDelete, objParam);

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