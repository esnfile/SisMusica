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
    public class DAL_hinario
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idHinario = null;

        #endregion

        #region Strings Sql da tabela Hinario

        //string de insert na tabela Hinario
        private string strInsert = "INSERT INTO Hinario (CodHinario, CodTonalidade, DescHinario) " +
"VALUES (@CodHinario, @CodTonalidade, @DescHinario) ";

        //string de update na tabela Hinario
        private string strUpdate = "UPDATE Hinario SET CodTonalidade = @CodTonalidade, DescHinario = @DescHinario " +
"WHERE CodHinario = @CodHinario ";

        //string de delete na tabela Hinario
        private string strDelete = "DELETE FROM Hinario WHERE CodHinario = @CodHinario ";

        //string de select na tabela Hinario
        private string strSelect = "SELECT H.CodHinario, H.CodTonalidade, H.DescHinario, T.Nota, T.Alteracoes, T.DescTonalidade " +
"FROM Hinario AS H " +
"LEFT OUTER JOIN Tonalidade AS T ON H.CodTonalidade = T.CodTonalidade ";

        //string que retorna o próximo Id da tabela Hinario
        private string strId = "SELECT MAX (CodHinario) FROM Hinario ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Hinario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_hinario objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Hinario
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodHinario", Convert.ToInt16(objEnt.CodHinario)));
                objParam.Add(new SqlParameter("@CodTonalidade", string.IsNullOrEmpty(objEnt.CodTonalidade) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTonalidade) as object));
                objParam.Add(new SqlParameter("@DescHinario", string.IsNullOrEmpty(objEnt.DescHinario) ? DBNull.Value as object : objEnt.DescHinario as object));
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
        /// Função que faz INSERT na Tabela Hinario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_hinario objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Hinario
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodHinario", Convert.ToInt16(objEnt.CodHinario)));
                objParam.Add(new SqlParameter("@CodTonalidade", string.IsNullOrEmpty(objEnt.CodTonalidade) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTonalidade) as object));
                objParam.Add(new SqlParameter("@DescHinario", string.IsNullOrEmpty(objEnt.DescHinario) ? DBNull.Value as object : objEnt.DescHinario as object));

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
        /// Função que faz DELETE na Tabela Hinario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_hinario objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Hinario
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodHinario", Convert.ToInt16(objEnt.CodHinario)));
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
        /// Função que retorna os Registros da tabela Hinario, pesquisado pelo Código
        /// </summary>
        /// <param name="CodHinario"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodHinario)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodHinario))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodHinario", CodHinario));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY H.CodHinario ", objParam, "Hinario");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodHinario", CodHinario));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE H.CodHinario = @CodHinario ORDER BY H.CodHinario", objParam, "Hinario");
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
        /// Função que retorna os Registros da tabela Hinario, pesquisado pela Tonalidade
        /// </summary>
        /// <param name="CodTonalidade"></param>
        /// <returns></returns>
        public DataTable buscarTonalidade(string CodTonalidade)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodTonalidade", CodTonalidade));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE H.CodTonalidade = @CodTonalidade ORDER BY T.DescTonalidade ", objParam, "Hinario");
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
        /// Função que retorna os Registros da tabela Hinario, pesquisado pela Descrição
        /// </summary>
        /// <param name="DescHinario"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescHinario)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescHinario", DescHinario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE H.DescHinario LIKE @DescHinario ORDER BY H.DescHinario ", objParam, "Hinario");
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
                idHinario = objAcessa.retornarId(strId);
                return Convert.ToInt16(idHinario);
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
