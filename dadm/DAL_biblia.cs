using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.administracao;

namespace DAL.administracao
{
    public class DAL_biblia
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idBiblia = null;

        #endregion

        #region Strings Sql da tabela Biblia

        //string de insert na tabela Biblia
        private string strInsert = "INSERT INTO Biblia (CodBiblia, DescLivro, QtdeCapitulos) " +
"VALUES (@CodBiblia, @DescLivro) ";

        //string de update na tabela Biblia
        private string strUpdate = "UPDATE Biblia SET DescLivro = @DescLivro, QtdeCapitulos = @QtdeCapitulos " +
"WHERE CodBiblia = @CodBiblia ";

        //string de delete na tabela Biblia
        private string strDelete = "DELETE FROM Biblia WHERE CodBiblia = @CodBiblia ";

        //string de select na tabela Biblia
        private string strSelect = "SELECT CodBiblia, DescLivro, QtdeCapitulos " +
"FROM Biblia ";

        //string que retorna o próximo Id da tabela Biblia
        private string strId = "SELECT MAX (CodBiblia) FROM Biblia ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Biblia
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_biblia objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Biblia
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodBiblia", Convert.ToInt16(objEnt.CodBiblia)));
                objParam.Add(new SqlParameter("@DescLivro", string.IsNullOrEmpty(objEnt.DescLivro) ? DBNull.Value as object : objEnt.DescLivro as object));
                objParam.Add(new SqlParameter("@QtdeCapitulos", Convert.ToInt16(objEnt.QtdeCapitulos)));
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
        /// Função que faz INSERT na Tabela Biblia
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_biblia objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Biblia
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodBiblia", Convert.ToInt16(objEnt.CodBiblia)));
                objParam.Add(new SqlParameter("@DescLivro", string.IsNullOrEmpty(objEnt.DescLivro) ? DBNull.Value as object : objEnt.DescLivro as object));
                objParam.Add(new SqlParameter("@QtdeCapitulos", Convert.ToInt16(objEnt.QtdeCapitulos)));

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
        /// Função que faz DELETE na Tabela Biblia
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_biblia objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Biblia
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodBiblia", Convert.ToInt16(objEnt.CodBiblia)));
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
        /// Função que retorna os Registros da tabela Biblia, pesquisado pelo Código
        /// </summary>
        /// <param name="CodBiblia"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodBiblia)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodBiblia))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodBiblia", CodBiblia));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodBiblia ", objParam, "Biblia");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodBiblia", CodBiblia));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodBiblia = @CodBiblia ORDER BY CodBiblia", objParam, "Biblia");
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
        /// Função que retorna os Registros da tabela Biblia, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescLivro"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescLivro)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescLivro", DescLivro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescLivro LIKE @DescLivro ORDER BY DescLivro ", objParam, "Biblia");
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
                idBiblia = objAcessa.retornarId(strId);
                return Convert.ToInt16(idBiblia);
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
