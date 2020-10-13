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
    public class DAL_familia
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idFamilia = null;

        #endregion

        #region Strings Sql da tabela Familia

        //string de insert na tabela Familia
        private string strInsert = "INSERT INTO Familia (CodFamilia, DescFamilia, Rjm, Culto, MeiaHora, Oficial, Troca) " +
"VALUES (@CodFamilia, @DescFamilia, @Rjm, @Culto, @MeiaHora, @Oficial, @Troca) ";

        //string de update na tabela Familia
        private string strUpdate = "UPDATE Familia SET DescFamilia = @DescFamilia, Rjm = @Rjm, " +
"Culto = @Culto, MeiaHora = @MeiaHora, Oficial = @Oficial, Troca = @Troca " +
"WHERE CodFamilia = @CodFamilia ";

        //string de delete na tabela Familia
        private string strDelete = "DELETE FROM Familia WHERE CodFamilia = @CodFamilia ";

        //string de select na tabela Familia
        private string strSelect = "SELECT CodFamilia, DescFamilia, Rjm, Culto, MeiaHora, Oficial, Troca " +
"FROM Familia ";

        //string que retorna o próximo Id da tabela Familia
        private string strId = "SELECT MAX (CodFamilia) FROM Familia ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Familia
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_familia objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Familia
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFamilia", Convert.ToInt16(objEnt.CodFamilia)));
                objParam.Add(new SqlParameter("@DescFamilia", string.IsNullOrEmpty(objEnt.DescFamilia) ? DBNull.Value as object : objEnt.DescFamilia as object));
                objParam.Add(new SqlParameter("@Rjm", string.IsNullOrEmpty(objEnt.Rjm) ? DBNull.Value as object : objEnt.Rjm as object));
                objParam.Add(new SqlParameter("@Culto", string.IsNullOrEmpty(objEnt.Culto) ? DBNull.Value as object : objEnt.Culto as object));
                objParam.Add(new SqlParameter("@MeiaHora", string.IsNullOrEmpty(objEnt.MeiaHora) ? DBNull.Value as object : objEnt.MeiaHora as object));
                objParam.Add(new SqlParameter("@Oficial", string.IsNullOrEmpty(objEnt.Oficial) ? DBNull.Value as object : objEnt.Oficial as object));
                objParam.Add(new SqlParameter("@Troca", string.IsNullOrEmpty(objEnt.Troca) ? DBNull.Value as object : objEnt.Troca as object));
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
        /// Função que faz INSERT na Tabela Familia
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_familia objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Familia
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFamilia", Convert.ToInt16(objEnt.CodFamilia)));
                objParam.Add(new SqlParameter("@DescFamilia", string.IsNullOrEmpty(objEnt.DescFamilia) ? DBNull.Value as object : objEnt.DescFamilia as object));
                objParam.Add(new SqlParameter("@Rjm", string.IsNullOrEmpty(objEnt.Rjm) ? DBNull.Value as object : objEnt.Rjm as object));
                objParam.Add(new SqlParameter("@Culto", string.IsNullOrEmpty(objEnt.Culto) ? DBNull.Value as object : objEnt.Culto as object));
                objParam.Add(new SqlParameter("@MeiaHora", string.IsNullOrEmpty(objEnt.MeiaHora) ? DBNull.Value as object : objEnt.MeiaHora as object));
                objParam.Add(new SqlParameter("@Oficial", string.IsNullOrEmpty(objEnt.Oficial) ? DBNull.Value as object : objEnt.Oficial as object));
                objParam.Add(new SqlParameter("@Troca", string.IsNullOrEmpty(objEnt.Troca) ? DBNull.Value as object : objEnt.Troca as object));

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
        /// Função que faz DELETE na Tabela Familia
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_familia objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Familia
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFamilia", Convert.ToInt16(objEnt.CodFamilia)));
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
        /// Função que retorna os Registros da tabela Familia, pesquisado pelo Código
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodFamilia)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodFamilia))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFamilia", CodFamilia));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodFamilia ", objParam, "Familia");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFamilia", CodFamilia));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodFamilia = @CodFamilia ORDER BY CodFamilia", objParam, "Familia");
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
        /// Função que retorna os Registros da tabela Familia, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescFamilia"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescFamilia)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescFamilia", DescFamilia));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescFamilia LIKE @DescFamilia ORDER BY DescFamilia ", objParam, "Familia");
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
                idFamilia = objAcessa.retornarId(strId);
                return Convert.ToInt16(idFamilia);
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
