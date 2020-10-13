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
    public class DAL_escala
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idEscala = null;

        #endregion

        #region Strings Sql da tabela Escala

        //string de insert na tabela Escala
        private string strInsert = "INSERT INTO Escala (CodEscala, DescEscala, Modelo, Tonica, Alteracoes, CodTipoEscala) " +
"VALUES (@CodEscala, @DescEscala, @Modelo, @Tonica, @Alteracoes, @CodTipoEscala) ";

        //string de update na tabela Escala
        private string strUpdate = "UPDATE Escala SET DescEscala = @DescEscala, Modelo = @Modelo, Tonica = @Tonica, " +
"Alteracoes = @Alteracoes, CodTipoEscala = @CodTipoEscala " +
"WHERE CodEscala = @CodEscala ";

        //string de delete na tabela Escala
        private string strDelete = "DELETE FROM Escala WHERE CodEscala = @CodEscala ";

        //string de select na tabela Escala
        private string strSelect = "SELECT E.CodEscala, E.DescEscala, E.Modelo, E.Tonica, E.Alteracoes, " +
"E.CodTipoEscala, T.DescTipo " +
"FROM Escala AS E " +
"LEFT OUTER JOIN TipoEscala AS T ON E.CodTipoEscala = T.CodTipoEscala ";

        //string que retorna o próximo Id da tabela Escala
        private string strId = "SELECT MAX (CodEscala) FROM Escala ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Escala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_escala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Escala
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodEscala", Convert.ToInt16(objEnt.CodEscala)));
                objParam.Add(new SqlParameter("@DescEscala", string.IsNullOrEmpty(objEnt.DescEscala) ? DBNull.Value as object : objEnt.DescEscala as object));
                objParam.Add(new SqlParameter("@Modelo", string.IsNullOrEmpty(objEnt.Modelo) ? DBNull.Value as object : objEnt.Modelo as object));
                objParam.Add(new SqlParameter("@Tonica", string.IsNullOrEmpty(objEnt.Tonica) ? DBNull.Value as object : objEnt.Tonica as object));
                objParam.Add(new SqlParameter("@Alteracoes", string.IsNullOrEmpty(objEnt.Alteracoes) ? DBNull.Value as object : objEnt.Alteracoes as object));
                objParam.Add(new SqlParameter("@CodTipoEscala", string.IsNullOrEmpty(objEnt.CodTipoEscala) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTipoEscala) as object));
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
        /// Função que faz INSERT na Tabela Escala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_escala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Escala
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodEscala", Convert.ToInt16(objEnt.CodEscala)));
                objParam.Add(new SqlParameter("@DescEscala", string.IsNullOrEmpty(objEnt.DescEscala) ? DBNull.Value as object : objEnt.DescEscala as object));
                objParam.Add(new SqlParameter("@Modelo", string.IsNullOrEmpty(objEnt.Modelo) ? DBNull.Value as object : objEnt.Modelo as object));
                objParam.Add(new SqlParameter("@Tonica", string.IsNullOrEmpty(objEnt.Tonica) ? DBNull.Value as object : objEnt.Tonica as object));
                objParam.Add(new SqlParameter("@Alteracoes", string.IsNullOrEmpty(objEnt.Alteracoes) ? DBNull.Value as object : objEnt.Alteracoes as object));
                objParam.Add(new SqlParameter("@CodTipoEscala", string.IsNullOrEmpty(objEnt.CodTipoEscala) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTipoEscala) as object));

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
        /// Função que faz DELETE na Tabela Escala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_escala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Escala
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodEscala", Convert.ToInt16(objEnt.CodEscala)));
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
        /// Função que retorna os Registros da tabela Escala, pesquisado pelo Código
        /// </summary>
        /// <param name="CodEscala"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodEscala)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodEscala))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodEscala", CodEscala));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodEscala ", objParam, "Escala");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodEscala", CodEscala));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodEscala = @CodEscala ORDER BY CodEscala", objParam, "Escala");
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
        /// Função que retorna os Registros da tabela Escala, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescEscala"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescEscala)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescEscala", DescEscala));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescEscala LIKE @DescEscala ORDER BY DescEscala ", objParam, "Escala");
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
        /// Função que retorna os Registros da tabela Escala, pesquisado pela Tonica
        /// </summary>
        /// <param name="Tonica"></param>
        /// <returns></returns>
        public DataTable buscarTonica(string Tonica)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Tonica", Tonica));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Tonica = @Tonica ORDER BY DescEscala ", objParam, "Escala");
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
        /// Função que retorna os Registros da tabela Escala, pesquisado pelo Tipo
        /// </summary>
        /// <param name="CodTipoEscala"></param>
        /// <returns></returns>
        public DataTable buscarTipo(string CodTipoEscala)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodTipoEscala", CodTipoEscala));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE E.CodTipoEscala = @CodTipoEscala ORDER BY E.DescEscala ", objParam, "Escala");
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
                idEscala = objAcessa.retornarId(strId);
                return Convert.ToInt16(idEscala);
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
