using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.uteis;

namespace DAL.uteis
{
    public class DAL_regional
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idRegional = null;

        #endregion

        #region Strings Sql da tabela Regional

        //string de insert na tabela Regional
        private string strInsert = "INSERT INTO Regional (CodRegional, Codigo, Descricao, Estado, CaminhoBD) " +
"VALUES (@CodRegional, @Codigo, @Descricao, @Estado) ";

        //string de update na tabela Regional
        private string strUpdate = "UPDATE Regional SET Codigo = @Codigo, Descricao = @Descricao, Estado = @Estado, CaminhoBD = @CaminhoBD " +
"WHERE CodRegional = @CodRegional ";

        //string de delete na tabela Regional
        private string strDelete = "DELETE FROM Regional WHERE CodRegional = @CodRegional ";

        //string de select na tabela Regional
        private string strSelect = "SELECT R.CodRegional, R.Codigo, R.Descricao, R.Estado, R.CaminhoBD " +
"FROM Regional AS R ";

        //string que retorna o próximo Id da tabela Regional
        private string strId = "SELECT MAX (CodRegional) FROM Regional ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Regional
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_regional objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Regional
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRegional", Convert.ToInt32(objEnt.CodRegional)));
                objParam.Add(new SqlParameter("@Codigo", string.IsNullOrEmpty(objEnt.Codigo) ? DBNull.Value as object : objEnt.Codigo as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));
                objParam.Add(new SqlParameter("@Estado", string.IsNullOrEmpty(objEnt.Estado) ? DBNull.Value as object : objEnt.Estado as object));
                objParam.Add(new SqlParameter("@CaminhoBD", string.IsNullOrEmpty(objEnt.CaminhoBD) ? DBNull.Value as object : objEnt.CaminhoBD as object));

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
        /// Função que faz INSERT na Tabela Regional
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_regional objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Regional
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRegional", Convert.ToInt32(objEnt.CodRegional)));
                objParam.Add(new SqlParameter("@Codigo", string.IsNullOrEmpty(objEnt.Codigo) ? DBNull.Value as object : objEnt.Codigo as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));
                objParam.Add(new SqlParameter("@Estado", string.IsNullOrEmpty(objEnt.Estado) ? DBNull.Value as object : objEnt.Estado as object));
                objParam.Add(new SqlParameter("@CaminhoBD", string.IsNullOrEmpty(objEnt.CaminhoBD) ? DBNull.Value as object : objEnt.CaminhoBD as object));

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
        /// Função que faz DELETE na Tabela Regional
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_regional objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Regional
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRegional", Convert.ToInt32(objEnt.CodRegional)));
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
        /// Função que retorna os Registros da tabela Regional, pesquisado pelo Código
        /// </summary>
        /// <param name="CodRegional"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodRegional)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodRegional))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRegional", CodRegional));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY R.Estado, R.Descricao ", objParam, "Regional");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRegional", CodRegional));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE R.CodRegional = @CodRegional ORDER BY R.CodRegional", objParam, "Regional");
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
        /// Função que retorna os Registros da tabela Regional, pesquisado pelo Codigo Definido
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public DataTable buscarCodigo(string Codigo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Codigo", Codigo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.Codigo LIKE @Codigo ORDER BY R.Codigo ", objParam, "Regional");
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
        /// Função que retorna os Registros da tabela Regional, pesquisado pela Descricao
        /// </summary>
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string Descricao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Descricao", Descricao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.Descricao LIKE @Descricao ORDER BY R.Descricao ", objParam, "Regional");
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
        /// Função que retorna os Registros da tabela Regional, pesquisado pela Estado
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public DataTable buscarEstado(string Estado)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Estado", Estado));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.Estado = @Estado ORDER BY R.Descricao ", objParam, "Regional");
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
        public Int32 retornaId()
        {
            try
            {
                idRegional = objAcessa.retornarId(strId);
                return Convert.ToInt32(idRegional);
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
