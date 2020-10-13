using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.instrumentos;

namespace DAL.instrumentos
{
    public class DAL_tipoEscala
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idTipo = null;

        #endregion

        #region Strings Sql da tabela TipoEscala

        //string de insert na tabela TipoEscala
        private string strInsert = "INSERT INTO TipoEscala (CodTipoEscala, DescTipo) " +
"VALUES (@CodTipoEscala, @DescTipo) ";

        //string de update na tabela TipoEscala
        private string strUpdate = "UPDATE TipoEscala SET DescTipo = @DescTipo " +
"WHERE CodTipoEscala = @CodTipoEscala ";

        //string de delete na tabela TipoEscala
        private string strDelete = "DELETE FROM TipoEscala WHERE CodTipoEscala = @CodTipoEscala ";

        //string de select na tabela TipoEscala
        private string strSelect = "SELECT CodTipoEscala, DescTipo " +
"FROM TipoEscala ";

        //string que retorna o próximo Id da tabela TipoEscala
        private string strId = "SELECT MAX (CodTipoEscala) FROM TipoEscala ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela TipoEscala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_tipoEscala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TipoEscala
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTipoEscala", Convert.ToInt16(objEnt.CodTipoEscala)));
                objParam.Add(new SqlParameter("@DescTipo", string.IsNullOrEmpty(objEnt.DescTipo) ? DBNull.Value as object : objEnt.DescTipo as object));
                blnRetorno = objAcessa.executar(strUpdate, objParam);

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
        /// Função que faz INSERT na Tabela TipoEscala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_tipoEscala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TipoEscala
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTipoEscala", Convert.ToInt16(objEnt.CodTipoEscala)));
                objParam.Add(new SqlParameter("@DescTipo", string.IsNullOrEmpty(objEnt.DescTipo) ? DBNull.Value as object : objEnt.DescTipo as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

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

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela TipoEscala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_tipoEscala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TipoEscala
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTipoEscala", Convert.ToInt16(objEnt.CodTipoEscala)));
                blnRetorno = objAcessa.executar(strDelete, objParam);

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

        #region Funções para buscar os dados e Preencher os Valores

        /// <summary>
        /// Função que retorna os Registros da tabela TipoEscala, pesquisado pelo Código
        /// </summary>
        /// <param name="CodTipoEscala"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodTipoEscala)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodTipoEscala))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTipoEscala", CodTipoEscala));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodTipoEscala ", objParam, "TipoEscala");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTipoEscala", CodTipoEscala));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodTipoEscala = @CodTipoEscala ORDER BY CodTipoEscala", objParam, "TipoEscala");
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
        /// Função que retorna os Registros da tabela TipoEscala, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescTipo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescTipo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescTipo", DescTipo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescTipo LIKE @DescTipo ORDER BY DescTipo ", objParam, "TipoEscala");
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

        #endregion

        #region Funções Publicas e Privadas Usadas para retorno de Valores

        /// <summary>
        /// Função que retorna o Ultimo Código inserido na Tabela
        /// </summary>
        /// <returns></returns>
        public Int16 retornaId()
        {
            try
            {
                idTipo = objAcessa.retornarId(strId);
                return Convert.ToInt16(idTipo);
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
