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
    public class DAL_regiaoPessoa
    {
        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idRegiao = null;

        #endregion

        #region Strings Sql da tabela RegiaoPessoa

        //string de insert na tabela RegiaoPessoa
        private string strInsert = "INSERT INTO RegiaoPessoa (CodRegiaoPessoa, CodRegiao, CodPessoa) " +
"VALUES (@CodRegiaoPessoa, @CodRegiao, @CodPessoa) ";

        //string de update na tabela RegiaoPessoa
        private string strUpdate = "UPDATE RegiaoPessoa SET CodRegiao = @CodRegiao, CodPessoa = @CodPessoa " +
"WHERE CodRegiaoPessoa = @CodRegiaoPessoa ";

        //string de delete na tabela RegiaoPessoa
        private string strDelete = "DELETE FROM RegiaoPessoa WHERE CodRegiaoPessoa = @CodRegiaoPessoa ";

        //string de select na tabela RegiaoPessoa
        private string strSelect = "SELECT RP.CodRegiaoPessoa, RP.CodRegiao, RP.CodPessoa, R.Codigo, R.Descricao, P.Nome " +
"FROM RegiaoPessoa AS RP " +
"LEFT OUTER JOIN Pessoa AS P ON RP.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON RP.CodRegiao = R.CodRegiao ";

        //string de select na tabela RegiaoAtuacao
        private string strSelectRegiao = "SELECT CodRegiao, Codigo, Descricao " +
"FROM RegiaoAtuacao WHERE CodRegiao NOT IN (SELECT CodRegiao FROM RegiaoPessoa ";

        //string que retorna o próximo Id da tabela RegiaoPessoa
        private string strId = "SELECT MAX (CodRegiaoPessoa) FROM RegiaoPessoa ";

        #endregion

        #region Função para Deletar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UDPATE na Tabela RegiaoPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_regiaoPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela RegiaoPessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela RegiaoPessoa
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (Convert.ToInt64(objEnt.CodRegiaoPessoa).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodRegiaoPessoa", retornaId()));
                    objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt.CodPessoa)));
                    objParam.Add(new SqlParameter("@CodRegiao", Convert.ToInt32(objEnt.CodRegiao)));

                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodRegiaoPessoa", Convert.ToInt64(objEnt.CodRegiaoPessoa)));
                    objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt.CodPessoa)));
                    objParam.Add(new SqlParameter("@CodRegiao", Convert.ToInt32(objEnt.CodRegiao)));

                    blnRetorno = objAcessa.executar(strUpdate, objParam);
                }

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
        /// Função que faz DELETE na Tabela RegiaoPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_regiaoPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela RegiaoPessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela RegiaoPessoa
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!Convert.ToInt64(objEnt.CodRegiaoPessoa).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodRegiaoPessoa", Convert.ToInt64(objEnt.CodRegiaoPessoa) as object));

                    blnRetorno = objAcessa.executar(strDelete, objParam);
                }

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
        /// Função que retorna os Registros da tabela RegiaoPessoa, pesquisado pelo CodPessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarRegiaoPessoa(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE RP.CodPessoa = @CodPessoa ORDER BY R.Descricao ", objParam, "RegiaoPessoa");
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
        /// Função que retorna os Registros da tabela RegiaoPessoa, pesquisado pelo CodRegiao
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarRegiaoPes(string CodRegiao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE RP.CodRegiao = @CodRegiao ORDER BY R.Descricao ", objParam, "RegiaoPessoa");
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
        /// Função que retorna os Registros da tabela RegiaoAtuacao, pesquisado pelo CodRegiao.*\
        /// Essa Consulta retorna os valores que não estão na Tabela RegiaoPessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelectRegiao + "WHERE CodPessoa = @CodPessoa) ORDER BY Descricao ", objParam, "RegiaoAtuacao");
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
        public Int64 retornaId()
        {
            try
            {
                idRegiao = objAcessa.retornarId(strId);
                return Convert.ToInt64(idRegiao);
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