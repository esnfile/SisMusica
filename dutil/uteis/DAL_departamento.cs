using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using DAL.Acessa;
using ENT.pessoa;

namespace DAL.pessoa
{
    public class DAL_departamento
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idDepartamento = null;

        #endregion

        #region Strings Sql da tabela Departamento

        //string de insert na tabela Departamento
        private string strInsert = "INSERT INTO Departamento (CodDepartamento, DescDepartamento) " +
"VALUES (@CodDepartamento, @DescDepartamento) ";

        //string de update na tabela Departamento
        private string strUpdate = "UPDATE Departamento SET DescDepartamento = @DescDepartamento " +
"WHERE CodDepartamento = @CodDepartamento ";

        //string de delete na tabela Departamento
        private string strDelete = "DELETE FROM Departamento WHERE CodDepartamento = @CodDepartamento ";

        //string de select na tabela Departamento
        private string strSelect = "SELECT CodDepartamento, DescDepartamento " +
"FROM Departamento ";

        //string que retorna o próximo Id da tabela Departamento
        private string strId = "SELECT MAX (CodDepartamento) FROM Departamento ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Departamento
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_departamento objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Departamento
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodDepartamento", Convert.ToInt16(objEnt.CodDepartamento)));
                objParam.Add(new SqlParameter("@DescDepartamento", string.IsNullOrEmpty(objEnt.DescDepartamento) ? DBNull.Value as object : objEnt.DescDepartamento as object));
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
        /// Função que faz INSERT na Tabela Departamento
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_departamento objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Departamento
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodDepartamento", Convert.ToInt16(objEnt.CodDepartamento)));
                objParam.Add(new SqlParameter("@DescDepartamento", string.IsNullOrEmpty(objEnt.DescDepartamento) ? DBNull.Value as object : objEnt.DescDepartamento as object));

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
        /// Função que faz DELETE na Tabela Departamento
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_departamento objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Departamento
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodDepartamento", Convert.ToInt16(objEnt.CodDepartamento)));
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
        /// Função que retorna os Registros da tabela Departamento, pesquisado pelo Código
        /// </summary>
        /// <param name="CodDepartamento"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodDepartamento)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodDepartamento))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodDepartamento", CodDepartamento));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodDepartamento ", objParam, "Departamento");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodDepartamento", CodDepartamento));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodDepartamento = @CodDepartamento ORDER BY CodDepartamento", objParam, "Departamento");
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
        /// Função que retorna os Registros da tabela Departamento, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescDepartamento"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescDepartamento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescDepartamento", DescDepartamento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescDepartamento LIKE @DescDepartamento ORDER BY DescDepartamento ", objParam, "Departamento");
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
                idDepartamento = objAcessa.retornarId(strId);
                return Convert.ToInt16(idDepartamento);
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