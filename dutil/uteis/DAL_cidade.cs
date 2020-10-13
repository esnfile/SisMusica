using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.uteis;

namespace DAL.uteis
{
    public class DAL_cidade
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idCidade = null;

        #endregion

        #region Strings Sql da tabela Cidade

        //string de insert na tabela Cidade
        private string strInsert = "INSERT INTO Cidade (CodCidade, Cidade, Estado, Cep, Tipo, Endereco, Bairro, Complemento) " +
"VALUES (@CodCidade, @Cidade, @Estado, @Cep, @Tipo, @Endereco, @Bairro, @Complemento) ";

        //string de update na tabela Cidade
        private string strUpdate = "UPDATE Cidade SET Cidade = @Cidade, Estado = @Estado, Cep = @Cep, Tipo = @Tipo, Endereco = @Endereco, " + 
"Bairro = @Bairro, Complemento = @Complemento " +
"WHERE CodCidade = @CodCidade ";

        //string de delete na tabela Cidade
        private string strDelete = "DELETE FROM Cidade WHERE CodCidade = @CodCidade ";

        //string de select na tabela Cidade
        private string strSelect = "SELECT CodCidade, Cidade, Estado, Cep, Tipo, Endereco, Bairro, Complemento " +
"FROM Cidade ";

        //string de select na tabela Cidade - Retorna somente os municipios
        private string strSelectMunicipios = "SELECT DISTINCT Cidade, Estado " +
"FROM Cidade ";

        //string de select na tabela Estado
        private string strSelectUf = "SELECT Sigla, Uf " +
"FROM Uf ";

        //string que retorna o próximo Id da tabela Cidade
        private string strId = "SELECT MAX (CodCidade) FROM Cidade ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Cidade
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_cidade objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cidade
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCidade", Convert.ToInt32(objEnt.CodCidade)));
                objParam.Add(new SqlParameter("@Cidade", string.IsNullOrEmpty(objEnt.Cidade) ? DBNull.Value as object : objEnt.Cidade as object));
                objParam.Add(new SqlParameter("@Estado", string.IsNullOrEmpty(objEnt.Estado) ? DBNull.Value as object : objEnt.Estado as object));
                objParam.Add(new SqlParameter("@Cep", string.IsNullOrEmpty(objEnt.Cep) ? DBNull.Value as object : objEnt.Cep as object));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@Endereco", string.IsNullOrEmpty(objEnt.Endereco) ? DBNull.Value as object : objEnt.Endereco as object));
                objParam.Add(new SqlParameter("@Bairro", string.IsNullOrEmpty(objEnt.Bairro) ? DBNull.Value as object : objEnt.Bairro as object));
                objParam.Add(new SqlParameter("@Complemento", string.IsNullOrEmpty(objEnt.Complemento) ? DBNull.Value as object : objEnt.Complemento as object));
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
        /// Função que faz INSERT na Tabela Cidade
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_cidade objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cidade
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCidade", Convert.ToInt32(objEnt.CodCidade)));
                objParam.Add(new SqlParameter("@Cidade", string.IsNullOrEmpty(objEnt.Cidade) ? DBNull.Value as object : objEnt.Cidade as object));
                objParam.Add(new SqlParameter("@Estado", string.IsNullOrEmpty(objEnt.Estado) ? DBNull.Value as object : objEnt.Estado as object));
                objParam.Add(new SqlParameter("@Cep", string.IsNullOrEmpty(objEnt.Cep) ? DBNull.Value as object : objEnt.Cep as object));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@Endereco", string.IsNullOrEmpty(objEnt.Endereco) ? DBNull.Value as object : objEnt.Endereco as object));
                objParam.Add(new SqlParameter("@Bairro", string.IsNullOrEmpty(objEnt.Bairro) ? DBNull.Value as object : objEnt.Bairro as object));
                objParam.Add(new SqlParameter("@Complemento", string.IsNullOrEmpty(objEnt.Complemento) ? DBNull.Value as object : objEnt.Complemento as object));

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
        /// Função que faz DELETE na Tabela Cidade
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_cidade objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cidade
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCidade", Convert.ToInt32(objEnt.CodCidade)));
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
        /// Função que retorna os Registros da tabela Cidade, pesquisado pelo Código
        /// </summary>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodCidade)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodCidade))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodCidade", CodCidade));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY Cep ", objParam, "Cidade");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodCidade", CodCidade));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodCidade = @CodCidade ORDER BY Cep", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Cidade, pesquisado pela Cidade
        /// </summary>
        /// <param name="Cidade"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string Cidade)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cidade", Cidade));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Cidade LIKE @Cidade ORDER BY Cidade, Cep ", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Cidade, pesquisado pela Cidade e Estado
        /// </summary>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string Cidade, string Estado)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cidade", Cidade));
                objParam.Add(new SqlParameter("@Estado", Estado));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Cidade LIKE @Cidade AND Estado = @Estado ORDER BY Cidade, Cep ", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Cidade, pesquisado pela Cidade, Estado e Endereco
        /// </summary>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        /// <param name="Endereco"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string Cidade, string Estado, string Endereco)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cidade", Cidade));
                objParam.Add(new SqlParameter("@Estado", Estado));
                objParam.Add(new SqlParameter("@Endereco", Endereco));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Cidade LIKE @Cidade AND Estado = @Estado AND Endereco LIKE @Endereco ORDER BY Cidade, Endereco, Cep ", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Cidade, pesquisado pela Cidade, Estado e Endereco
        /// </summary>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        /// <param name="Endereco"></param>
        /// <param name="Bairro"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string Cidade, string Estado, string Endereco, string Bairro)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cidade", Cidade));
                objParam.Add(new SqlParameter("@Estado", Estado));
                objParam.Add(new SqlParameter("@Endereco", Endereco));
                objParam.Add(new SqlParameter("@Bairro", Bairro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Cidade LIKE @Cidade AND Estado = @Estado AND Endereco LIKE @Endereco AND Bairro LIKE @Bairro ORDER BY Cidade, Bairro, Endereco, Cep ", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Cidade, pesquisado pelo Cep
        /// </summary>
        /// <param name="Cep"></param>
        /// <returns></returns>
        public DataTable buscarCep(string Cep)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cep", Cep));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Cep = @Cep ORDER BY Cep ", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Cidade, pesquisado pela Estado
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public DataTable buscarEstado(string Estado)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Estado", Estado));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Estado = @Estado ORDER BY Cidade, Cep ", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Cidade, Essa pesquisa trará apenas o nome dos municipios e não os ceps
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public DataTable buscarMunicipios(string Estado)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Estado", Estado));
                objDtb = objAcessa.retornaDados(strSelectMunicipios + "WHERE Estado = @Estado ORDER BY Cidade ", objParam, "Cidade");
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
        /// Função que retorna os Registros da tabela Estado
        /// </summary>
        /// <param name="Sigla"></param>
        /// <returns></returns>
        public DataTable buscarUf(string Sigla)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sigla", Sigla));
                objDtb = objAcessa.retornaDados(strSelectUf + "WHERE Sigla LIKE @Sigla ORDER BY Sigla ", objParam, "Uf");
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
        public Int32 retornaId()
        {
            try
            {
                idCidade = objAcessa.retornarId(strId);
                return Convert.ToInt32(idCidade);
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
