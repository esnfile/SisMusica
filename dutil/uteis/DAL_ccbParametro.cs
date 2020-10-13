using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.uteis;

namespace DAL.uteis
{
    public class DAL_ccbParametro
    {
        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idCCB = null;

        #endregion

        #region Strings Sql da tabela CCBParametro

        //string de insert na tabela CCBParametro
        private string strInsert = "INSERT INTO CCBParametro (CodCCBParam, CodCCB, CodParametro) " +
"VALUES (@CodCCBParam, @CodCCB, @CodParametro) ";

        //string de delete na tabela CCBParametro
        private string strDelete = "DELETE FROM CCBParametro WHERE CodCCBParam = @CodCCBParam ";

        //string de select na tabela CCBParametro
        private string strSelect = "SELECT CP.CodCCBParam, CP.CodCCB, CP.CodParametro, C.Codigo, C.Descricao " +
"FROM CCBParametro AS CP " +
"LEFT OUTER JOIN Parametro AS P ON CP.CodParametro = P.CodParametro " +
"LEFT OUTER JOIN CCB AS C ON CP.CodCCB = C.CodCCB ";

        //string de select na tabela CCB
        private string strSelectCCB = "SELECT CodCCB, Codigo, Descricao " +
"FROM CCB WHERE CodCCB NOT IN(SELECT CodCCB FROM CCBParametro ";

        //string que retorna o próximo Id da tabela CCBParametro
        private string strId = "SELECT MAX (CodCCBParam) FROM CCBParametro ";

        #endregion

        #region Função para Deletar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela CCBParametro
        /// </summary>
        /// <param name="objEnt_CCB"></param>
        /// <returns></returns>
        public bool salvar(MOD_ccbParametro objEnt_CCB)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela CCBParametro
                bool blnRetornoCCB = true;

                //Declara a lista de parametros da tabela CCBParametro
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt_CCB.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt_CCB.CodCCBParam).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodCCBParam", retornaId()));
                        objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(objEnt_CCB.CodParametro)));
                        objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(objEnt_CCB.CodCCB)));

                        blnRetornoCCB = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt_CCB.CodCCBParam).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodCCBParam", Convert.ToInt16(objEnt_CCB.CodCCBParam)));

                        blnRetornoCCB = objAcessa.executar(strDelete, objParam);
                    }
                }

                //retorna o blnRetorno da tabela principal
                return blnRetornoCCB;
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
        /// Função que retorna os Registros da tabela CCBParametro, pesquisado pelo CodParametro
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>
        public DataTable buscarCCBParametro(string CodParametro)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodParametro", CodParametro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CP.CodParametro = @CodParametro ORDER BY C.Descricao ", objParam, "CCBParametro");
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
        /// Função que retorna os Registros da tabela CCBParametro, pesquisado pelo CodCCB.*\
        /// Essa Consulta retorna os valores que não estão na Tabela CCBParametro
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>
        public DataTable buscarCCB(string CodParametro)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodParametro", CodParametro));
                objDtb = objAcessa.retornaDados(strSelectCCB + "WHERE CodParametro = @CodParametro) ORDER BY CodParametro ", objParam, "CCB");
                //instancia a lista
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
                idCCB = objAcessa.retornarId(strId);
                return Convert.ToInt16(idCCB);
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
