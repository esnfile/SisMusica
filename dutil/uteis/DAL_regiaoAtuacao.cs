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
    public class DAL_regiaoAtuacao
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idRegiao = null;

        #endregion

        #region Strings Sql da tabela RegiaoAtuacao

        //string de insert na tabela RegiaoAtuacao
        private string strInsert = "INSERT INTO RegiaoAtuacao (CodRegiao, Codigo, Descricao, CodRegional) " +
"VALUES (@CodRegiao, @Codigo, @Descricao, @CodRegional) ";

        //string de update na tabela RegiaoAtuacao
        private string strUpdate = "UPDATE RegiaoAtuacao SET Codigo = @Codigo, Descricao = @Descricao, CodRegional = @CodRegional " +
"WHERE CodRegiao = @CodRegiao ";

        //string de delete na tabela RegiaoAtuacao
        private string strDelete = "DELETE FROM RegiaoAtuacao WHERE CodRegiao = @CodRegiao ";

        //string de select na tabela RegiaoAtuacao
        private string strSelect = "SELECT R.CodRegiao, R.Codigo, R.Descricao, R.CodRegional, RG.Codigo AS CodigoRegional, RG.Descricao AS DescricaoRegional " +
"FROM RegiaoAtuacao AS R " +
"LEFT OUTER JOIN Regional AS RG ON R.CodRegional = RG.CodRegional ";


        //string que retorna o próximo Id da tabela RegiaoAtuacao
        private string strId = "SELECT MAX (CodRegiao) FROM RegiaoAtuacao ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela RegiaoAtuacao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_regiaoAtuacao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela RegiaoAtuacao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRegiao", Convert.ToInt32(objEnt.CodRegiao)));
                objParam.Add(new SqlParameter("@Codigo", string.IsNullOrEmpty(objEnt.Codigo) ? DBNull.Value as object : objEnt.Codigo as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.DescRegiao) ? DBNull.Value as object : objEnt.DescRegiao as object));
                objParam.Add(new SqlParameter("@CodRegional", string.IsNullOrEmpty(objEnt.CodRegional) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRegional) as object));

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
        /// Função que faz INSERT na Tabela RegiaoAtuacao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_regiaoAtuacao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela RegiaoAtuacao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRegiao", Convert.ToInt32(objEnt.CodRegiao)));
                objParam.Add(new SqlParameter("@Codigo", string.IsNullOrEmpty(objEnt.Codigo) ? DBNull.Value as object : objEnt.Codigo as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.DescRegiao) ? DBNull.Value as object : objEnt.DescRegiao as object));
                objParam.Add(new SqlParameter("@CodRegional", string.IsNullOrEmpty(objEnt.CodRegional) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRegional) as object));

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
        /// Função que faz DELETE na Tabela RegiaoAtuacao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_regiaoAtuacao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela RegiaoAtuacao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRegiao", Convert.ToInt32(objEnt.CodRegiao)));
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
        /// Função que retorna os Registros da tabela RegiaoAtuacao, pesquisado pelo Código
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodRegiao)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodRegiao))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY R.CodRegiao ", objParam, "RegiaoAtuacao");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE R.CodRegiao = @CodRegiao ORDER BY R.CodRegiao", objParam, "RegiaoAtuacao");
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
        /// Função que retorna os Registros da tabela RegiaoAtuacao, pesquisado pelo Codigo Definido
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.Codigo LIKE @Codigo ORDER BY R.Codigo ", objParam, "RegiaoAtuacao");
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
        /// Função que retorna os Registros da tabela RegiaoAtuacao, pesquisado pela Descricao
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.Descricao LIKE @Descricao ORDER BY R.Descricao ", objParam, "RegiaoAtuacao");
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
        /// Função que retorna os Registros da tabela RegiaoAtuacao, pesquisado pela Regional
        /// </summary>
        /// <param name="CodRegional"></param>
        /// <returns></returns>
        public DataTable buscarRegional(string CodRegional)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegional", CodRegional));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.CodRegional In(" + @CodRegional + ") ORDER BY R.Descricao ", objParam, "RegiaoAtuacao");
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
                idRegiao = objAcessa.retornarId(strId);
                return Convert.ToInt32(idRegiao);
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
