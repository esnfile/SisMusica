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
    public class DAL_subModulos
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idSubModulo = null;

        #endregion

        #region Strings Sql da tabela SubModulos

        //string de insert na tabela SubModulos
        private string strInsert = "INSERT INTO SubModulos (CodSubModulo, DescSubModulo, CodModulo, NivelSub) " +
"VALUES (@CodSubModulo, @DescSubModulo, @CodModulo, @NivelSub) ";

        //string de update na tabela SubModulos
        private string strUpdate = "UPDATE SubModulos SET DescSubModulo = @DescSubModulo, CodModulo = @CodModulo, NivelSub = @NivelSub " +
"WHERE CodSubModulo = @CodSubModulo ";

        //string de delete na tabela SubModulos
        private string strDelete = "DELETE FROM SubModulos WHERE CodSubModulo = @CodSubModulo ";

        //string de select na tabela SubModulos
        private string strSelect = "SELECT S.CodSubModulo, S.DescSubModulo, S.CodModulo, S.NivelSub, " +
"M.DescModulo, M.NivelMod " +
"FROM SubModulos AS S " +
"LEFT OUTER JOIN Modulos AS M ON S.CodModulo = M.CodModulo ";

        //string que retorna o próximo Id da tabela SubModulos
        private string strId = "SELECT MAX (CodSubModulo) FROM SubModulos ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela SubModulos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_subModulos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela SubModulos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodSubModulo", Convert.ToInt16(objEnt.CodSubModulo)));
                objParam.Add(new SqlParameter("@DescSubModulo", string.IsNullOrEmpty(objEnt.DescSubModulo) ? DBNull.Value as object : objEnt.DescSubModulo as object));
                objParam.Add(new SqlParameter("@CodModulo", string.IsNullOrEmpty(objEnt.CodModulo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodModulo) as object));
                objParam.Add(new SqlParameter("@NivelSub", string.IsNullOrEmpty(objEnt.NivelSub) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelSub) as object));
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
        /// Função que faz INSERT na Tabela SubModulos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_subModulos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela SubModulos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodSubModulo", Convert.ToInt16(objEnt.CodSubModulo)));
                objParam.Add(new SqlParameter("@DescSubModulo", string.IsNullOrEmpty(objEnt.DescSubModulo) ? DBNull.Value as object : objEnt.DescSubModulo as object));
                objParam.Add(new SqlParameter("@CodModulo", string.IsNullOrEmpty(objEnt.CodModulo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodModulo) as object));
                objParam.Add(new SqlParameter("@NivelSub", string.IsNullOrEmpty(objEnt.NivelSub) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelSub) as object));

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
        /// Função que faz DELETE na Tabela SubModulos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_subModulos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela SubModulos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodSubModulo", Convert.ToInt16(objEnt.CodSubModulo)));
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
        /// Função que retorna os Registros da tabela SubModulos, pesquisado pelo Código
        /// </summary>
        /// <param name="CodSubModulo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodSubModulo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodSubModulo))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSubModulo", CodSubModulo));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY S.CodSubModulo ", objParam, "SubModulos");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSubModulo", CodSubModulo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodSubModulo = @CodSubModulo ORDER BY S.CodSubModulo", objParam, "SubModulos");
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
        /// Função que retorna os Registros da tabela SubModulos, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescSubModulo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescSubModulo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescSubModulo", DescSubModulo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.DescSubModulo LIKE @DescSubModulo ORDER BY S.DescSubModulo ", objParam, "SubModulos");
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
        /// Função que retorna os Registros da tabela SubModulos, pesquisado pela Descricao
        /// </summary>
        /// <param name="CodModulo"></param>
        /// <param name="DescSubModulo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string CodModulo, string DescSubModulo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodModulo", CodModulo));
                objParam.Add(new SqlParameter("@DescSubModulo", DescSubModulo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodModulo = @CodModulo AND S.DescSubModulo LIKE @DescSubModulo ORDER BY S.DescSubModulo ", objParam, "SubModulos");
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
        /// Função que retorna os Registros da tabela SubModulos, pesquisado pelo NivelSub
        /// </summary>
        /// <param name="NivelSub"></param>
        /// <returns></returns>
        public DataTable buscarNivelSub(string NivelSub)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@NivelSub", NivelSub));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.NivelSub = @NivelSub ORDER BY S.DescSubModulo ", objParam, "SubModulos");
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
        /// Função que retorna os Registros da tabela SubModulos, pesquisado pelo CodModulo
        /// </summary>
        /// <param name="CodModulo"></param>
        /// <returns></returns>
        public DataTable buscarModulo(string CodModulo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodModulo", CodModulo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodModulo = @CodModulo ORDER BY S.DescSubModulo ", objParam, "SubModulos");
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
                idSubModulo = objAcessa.retornarId(strId);
                return Convert.ToInt16(idSubModulo);
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
