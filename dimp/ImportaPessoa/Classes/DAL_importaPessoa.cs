using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.importa;

namespace DAL.importa
{
    public class DAL_importaPessoa : IDAL_ImportaPessoa
    {
        IConnect objAcessa = new acessa();
        IDAL_ImportaPessoa_StrSql objDAL = new DAL_ImportaPessoa_StrSql();

        #region Instruções CRUD

        /// <summary>
        /// Função UPDATE - Utilziada para Atualizar os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Update(MOD_importaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodImportaPessoa", string.IsNullOrEmpty(objEnt.CodImportaPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodImportaPessoa)),
                    new SqlParameter("@DataImporta", string.IsNullOrEmpty(objEnt.DataImporta) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataImporta) as object),
                    new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object),
                    new SqlParameter("@HoraImporta", string.IsNullOrEmpty(objEnt.HoraImporta) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraImporta) as object),
                    new SqlParameter("@QtdeArquivo", string.IsNullOrEmpty(objEnt.QtdeArquivo) ? DBNull.Value as object : Convert.ToInt32(objEnt.QtdeArquivo) as object),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object)
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
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Insert(MOD_importaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodImportaPessoa", string.IsNullOrEmpty(objEnt.CodImportaPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodImportaPessoa)),
                    new SqlParameter("@DataImporta", string.IsNullOrEmpty(objEnt.DataImporta) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataImporta) as object),
                    new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object),
                    new SqlParameter("@HoraImporta", string.IsNullOrEmpty(objEnt.HoraImporta) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraImporta) as object),
                    new SqlParameter("@QtdeArquivo", string.IsNullOrEmpty(objEnt.QtdeArquivo) ? DBNull.Value as object : Convert.ToInt32(objEnt.QtdeArquivo) as object),
                    new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object)
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
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Delete(MOD_importaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    new SqlParameter("@CodImportaPessoa", Convert.ToInt64(objEnt.CodImportaPessoa))
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
        /// Função que retorna o Ultimo Código inserido na Tabela
        /// </summary>
        /// <returns></returns>
        public Int32 RetornaId()
        {
            try
            {
                object idImporta = objAcessa.retornarId(objDAL.StrRetornaId);
                return Convert.ToInt32(idImporta);
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