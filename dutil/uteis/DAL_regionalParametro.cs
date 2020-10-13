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
    public class DAL_regionalParametro
    {
        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idRegional = null;

        #endregion

        #region Strings Sql da tabela RegionalParametro

        //string de insert na tabela RegionalParametro
        private string strInsert = "INSERT INTO RegionalParametro (CodRegionalParam, CodRegional, CodParametro) " +
"VALUES (@CodRegionalParam, @CodRegional, @CodParametro) ";

        //string de delete na tabela RegionalParametro
        private string strDelete = "DELETE FROM RegionalParametro WHERE CodRegionalParam = @CodRegionalParam ";

        //string de select na tabela RegionalParametro
        private string strSelect = "SELECT CP.CodRegionalParam, CP.CodRegional, CP.CodParametro, R.Codigo, R.Descricao, R.Estado " +
"FROM RegionalParametro AS CP " +
"LEFT OUTER JOIN Parametro AS P ON CP.CodParametro = P.CodParametro " +
"LEFT OUTER JOIN Regional AS R ON CP.CodRegional = R.CodRegional ";

        //string de select na tabela CCB
        private string strSelectReg = "SELECT CodRegional, Codigo, Descricao, Estado " +
"FROM Regional WHERE CodRegional NOT IN(SELECT CodRegional FROM RegionalParametro ";

        //string que retorna o próximo Id da tabela RegionalParametro
        private string strId = "SELECT MAX (CodRegionalParam) FROM RegionalParametro ";

        #endregion

        #region Função para Deletar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela RegionalParametro
        /// </summary>
        /// <param name="objEnt_Reg"></param>
        /// <returns></returns>
        public bool salvar(MOD_regionalParametro objEnt_Reg)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela RegionalParametro
                bool blnRetornoReg = true;

                //Declara a lista de parametros da tabela RegionalParametro
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt_Reg.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt_Reg.CodRegionalParam).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodRegionalParam", retornaId()));
                        objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(objEnt_Reg.CodParametro)));
                        objParam.Add(new SqlParameter("@CodRegional", Convert.ToInt32(objEnt_Reg.CodRegional)));

                        blnRetornoReg = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt_Reg.CodRegionalParam).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodRegionalParam", Convert.ToInt16(objEnt_Reg.CodRegionalParam)));

                        blnRetornoReg = objAcessa.executar(strDelete, objParam);
                    }
                }

                //retorna o blnRetorno da tabela principal
                return blnRetornoReg;
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
        /// Função que retorna os Registros da tabela RegionalParametro, pesquisado pelo CodParametro
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>
        public DataTable buscarRegionalParametro(string CodParametro)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodParametro", CodParametro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CP.CodParametro = @CodParametro ORDER BY R.Descricao ", objParam, "RegionalParametro");
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
        /// Função que retorna os Registros da tabela RegionalParametro, pesquisado pelo CodRegional.*\
        /// Essa Consulta retorna os valores que não estão na Tabela RegionalParametro
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>
        public DataTable buscarRegional(string CodParametro)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodParametro", CodParametro));
                objDtb = objAcessa.retornaDados(strSelectReg + "WHERE CodParametro = @CodParametro) ORDER BY CodParametro ", objParam, "Regional");
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
                idRegional = objAcessa.retornarId(strId);
                return Convert.ToInt16(idRegional);
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
