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
    public class DAL_mtsModulo
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idModulo = null;

        #endregion

        #region Strings Sql da tabela MtsModulo

        //string de insert na tabela MtsModulo
        private string strInsert = "INSERT INTO MtsModulo (CodModuloMts, DescModulo, CodFaseMtsMts) " +
"VALUES (@CodModuloMts, @DescModulo, @CodFaseMtsMts) ";

        //string de update na tabela MtsModulo
        private string strUpdate = "UPDATE MtsModulo SET DescModulo = @DescModulo, CodFaseMts = @CodFaseMts " +
"WHERE CodModuloMts = @CodModuloMts ";

        //string de delete na tabela MtsModulo
        private string strDelete = "DELETE FROM MtsModulo WHERE CodModuloMts = @CodModuloMts ";

        //string de select na tabela MtsModulo
        private string strSelect = "SELECT M.CodModuloMts, M.DescModulo, M.CodFaseMts, F.DescFase " +
"FROM MtsModulo AS M " +
"LEFT OUTER JOIN MtsFase AS F ON M.CodFaseMts = F.CodFaseMts ";

        //string que retorna o próximo Id da tabela MtsModulo
        private string strId = "SELECT MAX (CodModuloMts) FROM MtsModulo ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela MtsModulo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_mtsModulo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela MtsModulo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodModuloMts", Convert.ToInt16(objEnt.CodModuloMts)));
                objParam.Add(new SqlParameter("@DescModulo", string.IsNullOrEmpty(objEnt.DescModulo) ? DBNull.Value as object : objEnt.DescModulo as object));
                objParam.Add(new SqlParameter("@CodFaseMts", string.IsNullOrEmpty(objEnt.CodFaseMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodFaseMts) as object));
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
        /// Função que faz INSERT na Tabela MtsModulo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_mtsModulo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela MtsModulo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodModuloMts", Convert.ToInt16(objEnt.CodModuloMts)));
                objParam.Add(new SqlParameter("@DescModulo", string.IsNullOrEmpty(objEnt.DescModulo) ? DBNull.Value as object : objEnt.DescModulo as object));
                objParam.Add(new SqlParameter("@CodFaseMts", string.IsNullOrEmpty(objEnt.CodFaseMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodFaseMts) as object));

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
        /// Função que faz DELETE na Tabela MtsModulo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_mtsModulo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela MtsModulo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodModuloMts", Convert.ToInt16(objEnt.CodModuloMts)));
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
        /// Função que retorna os Registros da tabela MtsModulo, pesquisado pelo Código
        /// </summary>
        /// <param name="CodModuloMts"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodModuloMts)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodModuloMts))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodModuloMts", CodModuloMts));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY M.CodModuloMts ", objParam, "MtsModulo");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodModuloMts", CodModuloMts));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE M.CodModuloMts = @CodModuloMts ORDER BY M.CodModuloMts", objParam, "MtsModulo");
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
        /// Função que retorna os Registros da tabela MtsModulo, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescModulo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescModulo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescModulo", DescModulo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE M.DescModulo LIKE @DescModulo ORDER BY M.DescModulo ", objParam, "MtsModulo");
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
        /// Função que retorna os Registros da tabela MtsModulo, pesquisado pela Fase
        /// </summary>
        /// <param name="CodFaseMts"></param>
        /// <returns></returns>
        public DataTable buscarFase(string CodFaseMts)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFaseMts", CodFaseMts));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE M.CodFaseMts LIKE @CodFaseMts ORDER BY M.DescModulo ", objParam, "MtsModulo");
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
                idModulo = objAcessa.retornarId(strId);
                return Convert.ToInt16(idModulo);
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
