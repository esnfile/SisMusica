using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.instrumentos;

namespace DAL.instrumentos
{
    public class DAL_tonalidade
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idTonalidade = null;

        #endregion

        #region Strings Sql da tabela Tonalidade

        //string de insert na tabela Tonalidade
        private string strInsert = "INSERT INTO Tonalidade (CodTonalidade, Nota, Alteracoes, DescTonalidade) " +
"VALUES (@CodTonalidade, @Nota, @Alteracoes, @DescTonalidade) ";

        //string de update na tabela Tonalidade
        private string strUpdate = "UPDATE Tonalidade SET Nota = @Nota, Alteracoes = @Alteracoes, DescTonalidade = @DescTonalidade " +
"WHERE CodTonalidade = @CodTonalidade ";

        //string de delete na tabela Tonalidade
        private string strDelete = "DELETE FROM Tonalidade WHERE CodTonalidade = @CodTonalidade ";

        //string de select na tabela Tonalidade
        private string strSelect = "SELECT CodTonalidade, Nota, Alteracoes, DescTonalidade " +
"FROM Tonalidade ";

        //string que retorna o próximo Id da tabela Tonalidade
        private string strId = "SELECT MAX (CodTonalidade) FROM Tonalidade ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Tonalidade
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_tonalidade objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Tonalidade
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTonalidade", Convert.ToInt16(objEnt.CodTonalidade)));
                objParam.Add(new SqlParameter("@Nota", string.IsNullOrEmpty(objEnt.Nota) ? DBNull.Value as object : objEnt.Nota as object));
                objParam.Add(new SqlParameter("@Alteracoes", string.IsNullOrEmpty(objEnt.Alteracoes) ? DBNull.Value as object : objEnt.Alteracoes as object));
                objParam.Add(new SqlParameter("@DescTonalidade", string.IsNullOrEmpty(objEnt.DescTonalidade) ? DBNull.Value as object : objEnt.DescTonalidade as object));
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
        /// Função que faz INSERT na Tabela Tonalidade
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_tonalidade objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Tonalidade
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTonalidade", Convert.ToInt16(objEnt.CodTonalidade)));
                objParam.Add(new SqlParameter("@Nota", string.IsNullOrEmpty(objEnt.Nota) ? DBNull.Value as object : objEnt.Nota as object));
                objParam.Add(new SqlParameter("@Alteracoes", string.IsNullOrEmpty(objEnt.Alteracoes) ? DBNull.Value as object : objEnt.Alteracoes as object));
                objParam.Add(new SqlParameter("@DescTonalidade", string.IsNullOrEmpty(objEnt.DescTonalidade) ? DBNull.Value as object : objEnt.DescTonalidade as object));

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
        /// Função que faz DELETE na Tabela Tonalidade
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_tonalidade objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Tonalidade
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTonalidade", Convert.ToInt16(objEnt.CodTonalidade)));
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
        /// Função que retorna os Registros da tabela Tonalidade, pesquisado pelo Código
        /// </summary>
        /// <param name="CodTonalidade"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodTonalidade)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodTonalidade))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTonalidade", CodTonalidade));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodTonalidade ", objParam, "Tonalidade");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTonalidade", CodTonalidade));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodTonalidade = @CodTonalidade ORDER BY CodTonalidade", objParam, "Tonalidade");
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
        /// Função que retorna os Registros da tabela Tonalidade, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescTonalidade"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescTonalidade)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescTonalidade", DescTonalidade));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescTonalidade LIKE @DescTonalidade ORDER BY DescTonalidade ", objParam, "Tonalidade");
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
                idTonalidade = objAcessa.retornarId(strId);
                return Convert.ToInt16(idTonalidade);
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
