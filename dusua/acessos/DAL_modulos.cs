using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.acessos;

namespace DAL.acessos
{
    public class DAL_modulos
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idModulo = null;

        #endregion

        #region Strings Sql da tabela Modulos

        //string de insert na tabela Modulos
        private string strInsert = "INSERT INTO Modulos (CodModulo, DescModulo, NivelMod) " +
"VALUES (@CodModulo, @DescModulo, @NivelMod) ";

        //string de update na tabela Modulos
        private string strUpdate = "UPDATE Modulos SET DescModulo = @DescModulo, NivelMod = @NivelMod " +
"WHERE CodModulo = @CodModulo ";

        //string de delete na tabela Modulos
        private string strDelete = "DELETE FROM Modulos WHERE CodModulo = @CodModulo ";

        //string de select na tabela Modulos
        private string strSelect = "SELECT CodModulo, DescModulo, NivelMod " +
"FROM Modulos ";

        //string que retorna o próximo Id da tabela Modulos
        private string strId = "SELECT MAX (CodModulo) FROM Modulos ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Modulos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_modulos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Modulos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodModulo", Convert.ToInt16(objEnt.CodModulo)));
                objParam.Add(new SqlParameter("@DescModulo", string.IsNullOrEmpty(objEnt.DescModulo) ? DBNull.Value as object : objEnt.DescModulo as object));
                objParam.Add(new SqlParameter("@NivelMod", string.IsNullOrEmpty(objEnt.NivelMod) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelMod) as object));
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
        /// Função que faz INSERT na Tabela Modulos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_modulos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Modulos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodModulo", Convert.ToInt16(objEnt.CodModulo)));
                objParam.Add(new SqlParameter("@DescModulo", string.IsNullOrEmpty(objEnt.DescModulo) ? DBNull.Value as object : objEnt.DescModulo as object));
                objParam.Add(new SqlParameter("@NivelMod", string.IsNullOrEmpty(objEnt.NivelMod) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelMod) as object));

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
        /// Função que faz DELETE na Tabela Modulos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_modulos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Modulos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodModulo", Convert.ToInt16(objEnt.CodModulo)));
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
        /// Função que retorna os Registros da tabela Modulos, pesquisado pelo Código
        /// </summary>
        /// <param name="CodModulo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodModulo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodModulo))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodModulo", CodModulo));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodModulo ", objParam, "Modulos");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodModulo", CodModulo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodModulo = @CodModulo ORDER BY CodModulo", objParam, "Modulos");
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
        /// Função que retorna os Registros da tabela Modulos, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescModulo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescModulo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescModulo", DescModulo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescModulo LIKE @DescModulo ORDER BY DescModulo ", objParam, "Modulos");
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
        /// Função que retorna os Registros da tabela Modulos, pesquisado pelo Nivel
        /// </summary>
        /// <param name="NivelMod"></param>
        /// <returns></returns>
        public DataTable buscarNivel(string NivelMod)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@NivelMod", NivelMod));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE NivelMod = @NivelMod ORDER BY DescModulo ", objParam, "Modulos");
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
                idModulo = objAcessa.retornarId(strId);
                return Convert.ToInt16(idModulo);
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
