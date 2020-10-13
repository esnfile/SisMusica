using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.administracao;

namespace DAL.administracao
{
    public class DAL_tipoReuniao
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idTipo = null;

        #endregion

        #region Strings Sql da tabela TipoReuniao

        //string de insert na tabela TipoReuniao
        private string strInsert = "INSERT INTO TipoReuniao (CodTipoReuniao, DescTipoReuniao) " +
"VALUES (@CodTipoReuniao, @DescTipoReuniao) ";

        //string de update na tabela TipoReuniao
        private string strUpdate = "UPDATE TipoReuniao SET DescTipoReuniao = @DescTipoReuniao " +
"WHERE CodTipoReuniao = @CodTipoReuniao ";

        //string de delete na tabela TipoReuniao
        private string strDelete = "DELETE FROM TipoReuniao WHERE CodTipoReuniao = @CodTipoReuniao ";

        //string de select na tabela TipoReuniao
        private string strSelect = "SELECT CodTipoReuniao, DescTipoReuniao " +
"FROM TipoReuniao ";

        //string que retorna o próximo Id da tabela TipoReuniao
        private string strId = "SELECT MAX (CodTipoReuniao) FROM TipoReuniao ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela TipoReuniao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_tipoReuniao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TipoReuniao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTipoReuniao", Convert.ToInt16(objEnt.CodTipoReuniao)));
                objParam.Add(new SqlParameter("@DescTipoReuniao", string.IsNullOrEmpty(objEnt.DescTipoReuniao) ? DBNull.Value as object : objEnt.DescTipoReuniao as object));
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
        /// Função que faz INSERT na Tabela TipoReuniao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_tipoReuniao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TipoReuniao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTipoReuniao", Convert.ToInt16(objEnt.CodTipoReuniao)));
                objParam.Add(new SqlParameter("@DescTipoReuniao", string.IsNullOrEmpty(objEnt.DescTipoReuniao) ? DBNull.Value as object : objEnt.DescTipoReuniao as object));

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
        /// Função que faz DELETE na Tabela TipoReuniao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_tipoReuniao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TipoReuniao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTipoReuniao", Convert.ToInt16(objEnt.CodTipoReuniao)));
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
        /// Função que retorna os Registros da tabela TipoReuniao, pesquisado pelo Código
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodTipoReuniao)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodTipoReuniao))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTipoReuniao", CodTipoReuniao));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodTipoReuniao ", objParam, "TipoReuniao");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTipoReuniao", CodTipoReuniao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodTipoReuniao = @CodTipoReuniao ORDER BY CodTipoReuniao", objParam, "TipoReuniao");
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
        /// Função que retorna os Registros da tabela TipoReuniao, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescTipoReuniao"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescTipoReuniao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescTipoReuniao", DescTipoReuniao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescTipoReuniao LIKE @DescTipoReuniao ORDER BY DescTipoReuniao ", objParam, "TipoReuniao");
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
