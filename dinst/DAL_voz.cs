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
    public class DAL_voz
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idVoz = null;

        #endregion

        #region Strings Sql da tabela Vozes

        //string de insert na tabela Vozes
        private string strInsert = "INSERT INTO Vozes (CodVoz, DescVoz, NotaGrave, PosGrave, NotaAguda, PosAguda) " +
"VALUES (@CodVoz, @DescVoz, @NotaGrave, @PosGrave, @NotaAguda, @PosAguda) ";

        //string de update na tabela Vozes
        private string strUpdate = "UPDATE Vozes SET DescVoz = @DescVoz, NotaGrave = @NotaGrave, PosGrave = @PosGrave, NotaAguda = @NotaAguda, PosAguda = @PosAguda " +
"WHERE CodVoz = @CodVoz ";

        //string de delete na tabela Vozes
        private string strDelete = "DELETE FROM Vozes WHERE CodVoz = @CodVoz ";

        //string de select na tabela Vozes
        private string strSelect = "SELECT CodVoz, DescVoz, NotaGrave, PosGrave, NotaAguda, PosAguda " +
"FROM Vozes ";

        //string que retorna o próximo Id da tabela Vozes
        private string strId = "SELECT MAX (CodVoz) FROM Vozes ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Vozes
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_voz objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Vozes
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodVoz", Convert.ToInt16(objEnt.CodVoz)));
                objParam.Add(new SqlParameter("@DescVoz", string.IsNullOrEmpty(objEnt.DescVoz) ? DBNull.Value as object : objEnt.DescVoz as object));
                objParam.Add(new SqlParameter("@NotaGrave", string.IsNullOrEmpty(objEnt.NotaGrave) ? DBNull.Value as object : objEnt.NotaGrave as object));
                objParam.Add(new SqlParameter("@PosGrave", string.IsNullOrEmpty(objEnt.PosGrave) ? DBNull.Value as object : objEnt.PosGrave as object));
                objParam.Add(new SqlParameter("@NotaAguda", string.IsNullOrEmpty(objEnt.NotaAguda) ? DBNull.Value as object : objEnt.NotaAguda as object));
                objParam.Add(new SqlParameter("@PosAguda", string.IsNullOrEmpty(objEnt.PosAguda) ? DBNull.Value as object : objEnt.PosAguda as object));
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
        /// Função que faz INSERT na Tabela Vozes
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_voz objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Vozes
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodVoz", Convert.ToInt16(objEnt.CodVoz)));
                objParam.Add(new SqlParameter("@DescVoz", string.IsNullOrEmpty(objEnt.DescVoz) ? DBNull.Value as object : objEnt.DescVoz as object));
                objParam.Add(new SqlParameter("@NotaGrave", string.IsNullOrEmpty(objEnt.NotaGrave) ? DBNull.Value as object : objEnt.NotaGrave as object));
                objParam.Add(new SqlParameter("@PosGrave", string.IsNullOrEmpty(objEnt.PosGrave) ? DBNull.Value as object : objEnt.PosGrave as object));
                objParam.Add(new SqlParameter("@NotaAguda", string.IsNullOrEmpty(objEnt.NotaAguda) ? DBNull.Value as object : objEnt.NotaAguda as object));
                objParam.Add(new SqlParameter("@PosAguda", string.IsNullOrEmpty(objEnt.PosAguda) ? DBNull.Value as object : objEnt.PosAguda as object));

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
        /// Função que faz DELETE na Tabela Vozes
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_voz objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Vozes
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodVoz", Convert.ToInt16(objEnt.CodVoz)));
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
        /// Função que retorna os Registros da tabela Vozes, pesquisado pelo Código
        /// </summary>
        /// <param name="CodVoz"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodVoz)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodVoz))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodVoz", CodVoz));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodVoz ", objParam, "Vozes");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodVoz", CodVoz));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodVoz = @CodVoz ORDER BY CodVoz", objParam, "Vozes");
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
        /// Função que retorna os Registros da tabela Vozes, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescVoz"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescVoz)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescVoz", DescVoz));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescVoz LIKE @DescVoz ORDER BY DescVoz ", objParam, "Vozes");
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
                idVoz = objAcessa.retornarId(strId);
                return Convert.ToInt16(idVoz);
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
