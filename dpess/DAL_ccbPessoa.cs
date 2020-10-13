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
    public class DAL_ccbPessoa
    {
        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idCCB = null;

        #endregion

        #region Strings Sql da tabela CCBPessoa

        //string de insert na tabela CCBPessoa
        private string strInsert = "INSERT INTO CCBPessoa (CodCCBPessoa, CodCCB, CodPessoa) " +
"VALUES (@CodCCBPessoa, @CodCCB, @CodPessoa) ";

        //string de update na tabela InscPessoa
        private string strUpdate = "UPDATE CCBPessoa SET CodCCB = @CodCCB, CodPessoa = @CodPessoa " +
"WHERE CodCCBPessoa = @CodCCBPessoa ";

        //string de delete na tabela CCBPessoa
        private string strDelete = "DELETE FROM CCBPessoa WHERE CodCCBPessoa = @CodCCBPessoa ";

        //string de select na tabela CCBPessoa
        private string strSelect = "SELECT CP.CodCCBPessoa, CP.CodCCB, CP.CodPessoa, C.Codigo, C.Descricao, C.Endereco, " +
"C.Numero, C.Bairro, C.CodCidade, C.CodRegiao, CI.Cidade, CI.Cep, CI.Estado, P.Nome, P.CodCargo, P.DataApresentacao, CG.DescCargo, CG.Ordem, " +
"R.Codigo AS CodigoRegiao, R.Descricao AS DescRegiao " +
"FROM CCBPessoa AS CP " +
"LEFT OUTER JOIN Pessoa AS P ON CP.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN CCB AS C ON CP.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS CI ON C.CodCidade = CI.CodCidade ";

        //string de select na tabela CCB
        private string strSelectCCB = "SELECT CodCCB, Codigo, Descricao " +
"FROM CCB WHERE CodCCB NOT IN (SELECT CodCCB FROM CCBPessoa ";

        //string que retorna o próximo Id da tabela CCBPessoa
        private string strId = "SELECT MAX (CodCCBPessoa) FROM CCBPessoa ";

        #endregion

        #region Função para Edtar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UPDATE na Tabela CCBPessoa
        /// </summary>
        /// <param name="objEnt_CCB"></param>
        /// <returns></returns>
        public bool salvar(MOD_ccbPessoa objEnt_CCB)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela CCBPessoa
                bool blnRetornoCCB = true;

                //Declara a lista de parametros da tabela CCBPessoa
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (Convert.ToInt64(objEnt_CCB.CodCCBPessoa).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodCCBPessoa", retornaId()));
                    objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt_CCB.CodPessoa)));
                    objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(objEnt_CCB.CodCCB)));

                    blnRetornoCCB = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodCCBPessoa", Convert.ToInt64(objEnt_CCB.CodCCBPessoa)));
                    objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt_CCB.CodPessoa)));
                    objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(objEnt_CCB.CodCCB)));

                    blnRetornoCCB = objAcessa.executar(strUpdate, objParam);
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

        /// <summary>
        /// Função que faz DELETE na Tabela CCBPessoa
        /// </summary>
        /// <param name="objEnt_CCB"></param>
        /// <returns></returns>
        public bool excluir(MOD_ccbPessoa objEnt_CCB)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela InscPessoa
                bool blnRetornoCCB = true;

                //Declara a lista de parametros da tabela InscPessoa
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!Convert.ToInt64(objEnt_CCB.CodCCBPessoa).Equals(0))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodCCBPessoa", Convert.ToInt64(objEnt_CCB.CodCCBPessoa) as object));

                    blnRetornoCCB = objAcessa.executar(strDelete, objParam);
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
        /// Função que retorna os Registros da tabela CCBPessoa, pesquisado pelo CodCCB
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarPesCCB(string CodCCB)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CP.CodCCB = @CodCCB ORDER BY P.Nome ", objParam, "CCBPessoa");
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
        /// Função que retorna os Registros da tabela CCBPessoa, pesquisado pelo CodPessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarCCBPessoa(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CP.CodPessoa = @CodPessoa ORDER BY C.Descricao ", objParam, "CCBPessoa");
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
        /// Função que retorna os Registros da tabela CCBPessoa, pesquisado pelo CodPessoa e CodRegiao
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarCCBPessoa(string CodPessoa, string CodRegiao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CP.CodPessoa = @CodPessoa AND R.CodRegiao = @CodRegiao ORDER BY C.Descricao ", objParam, "CCBPessoa");
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
        /// Função que retorna os Registros da tabela CCB Conta, pesquisado pelo CodCCB.*\
        /// Essa Consulta retorna os valores que não estão na Tabela CCBPessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarCCB(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelectCCB + "WHERE CodPessoa = @CodPessoa) ORDER BY Descricao ", objParam, "CCB");
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
                idCCB = objAcessa.retornarId(strId);
                return Convert.ToInt64(idCCB);
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
