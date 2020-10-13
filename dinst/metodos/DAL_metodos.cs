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
    public class DAL_metodos
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idMetodo = null;

        #endregion

        #region Strings Sql da tabela Metodos

        //string de insert na tabela Metodos
        private string strInsert = "INSERT INTO Metodos (CodMetodo, DescMetodo, Compositor, Tipo, Ativo, TipoEscolha, PaginaFase) " +
"VALUES (@CodMetodo, @DescMetodo, @Compositor, @Tipo, @Ativo, @TipoEscolha, @PaginaFase) ";

        //string de update na tabela Metodos
        private string strUpdate = "UPDATE Metodos SET DescMetodo = @DescMetodo, Compositor = @Compositor, " +
"Tipo = @Tipo, Ativo = @Ativo, TipoEscolha = @TipoEscolha, PaginaFase = @PaginaFase " +
"WHERE CodMetodo = @CodMetodo ";

        //string de delete na tabela Metodos
        private string strDelete = "DELETE FROM Metodos WHERE CodMetodo = @CodMetodo ";

        //string de select na tabela Metodos
        private string strSelect = "SELECT CodMetodo, DescMetodo, Compositor, Tipo, Ativo, TipoEscolha, PaginaFase " +
"FROM Metodos ";

        //string que retorna o próximo Id da tabela Metodos
        private string strId = "SELECT MAX (CodMetodo) FROM Metodos ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Metodos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_metodos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Metodos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodMetodo", Convert.ToInt16(objEnt.CodMetodo)));
                objParam.Add(new SqlParameter("@DescMetodo", string.IsNullOrEmpty(objEnt.DescMetodo) ? DBNull.Value as object : objEnt.DescMetodo as object));
                objParam.Add(new SqlParameter("@Compositor", string.IsNullOrEmpty(objEnt.Compositor) ? DBNull.Value as object : objEnt.Compositor as object));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@Ativo", string.IsNullOrEmpty(objEnt.Ativo) ? DBNull.Value as object : objEnt.Ativo as object));
                objParam.Add(new SqlParameter("@TipoEscolha", string.IsNullOrEmpty(objEnt.TipoEscolha) ? DBNull.Value as object : objEnt.TipoEscolha as object));
                objParam.Add(new SqlParameter("@PaginaFase", string.IsNullOrEmpty(objEnt.PaginaFase) ? DBNull.Value as object : objEnt.PaginaFase as object));
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
        /// Função que faz INSERT na Tabela Metodos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_metodos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Metodos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodMetodo", Convert.ToInt16(objEnt.CodMetodo)));
                objParam.Add(new SqlParameter("@DescMetodo", string.IsNullOrEmpty(objEnt.DescMetodo) ? DBNull.Value as object : objEnt.DescMetodo as object));
                objParam.Add(new SqlParameter("@Compositor", string.IsNullOrEmpty(objEnt.Compositor) ? DBNull.Value as object : objEnt.Compositor as object));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@Ativo", string.IsNullOrEmpty(objEnt.Ativo) ? DBNull.Value as object : objEnt.Ativo as object));
                objParam.Add(new SqlParameter("@TipoEscolha", string.IsNullOrEmpty(objEnt.TipoEscolha) ? DBNull.Value as object : objEnt.TipoEscolha as object));
                objParam.Add(new SqlParameter("@PaginaFase", string.IsNullOrEmpty(objEnt.PaginaFase) ? DBNull.Value as object : objEnt.PaginaFase as object));

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
        /// Função que faz DELETE na Tabela Metodos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_metodos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Metodos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodMetodo", Convert.ToInt16(objEnt.CodMetodo)));
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
        /// Função que retorna os Registros da tabela Metodos, pesquisado pelo Código
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodMetodo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodMetodo))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodMetodo ", objParam, "Metodos");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodMetodo = @CodMetodo ORDER BY CodMetodo", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos Ativo, pesquisado pelo Código
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodMetodo, string Ativo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodMetodo))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                    objParam.Add(new SqlParameter("@Ativo", Ativo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE Ativo LIKE @Ativo ORDER BY CodMetodo ", objParam, "Metodos");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                    objParam.Add(new SqlParameter("@Ativo", Ativo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodMetodo = @CodMetodo AND Ativo LIKE @Ativo ORDER BY CodMetodo", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos, pesquisado pela Descrição
        /// </summary>
        /// <param name="DescMetodo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescMetodo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescMetodo", DescMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescMetodo LIKE @DescMetodo ORDER BY DescMetodo ", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos Ativo, pesquisado pela Descrição
        /// </summary>
        /// <param name="DescMetodo"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescMetodo, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescMetodo", DescMetodo));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescMetodo LIKE @DescMetodo AND Ativo LIKE @Ativo ORDER BY DescMetodo ", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos, pesquisado pelo TipoEscolha
        /// <para>TipoEscolha ='Sistema', 'Candidato'</para>
        /// </summary>
        /// <param name="TipoEscolha"></param>
        /// <returns></returns>
        public DataTable buscarTipoEscolha(string TipoEscolha)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@TipoEscolha", TipoEscolha));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE TipoEscolha IN('" + @TipoEscolha + "') ORDER BY DescMetodo ", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos Ativo, pesquisado pelo TipoEscolha
        /// <para>TipoEscolha ='Sistema', 'Candidato'</para>
        /// </summary>
        /// <param name="TipoEscolha"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarTipoEscolha(string TipoEscolha, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@TipoEscolha", TipoEscolha));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE TipoEscolha IN('" + @TipoEscolha + "') AND Ativo LIKE @Ativo ORDER BY DescMetodo ", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos, pesquisado pela Compositor
        /// </summary>
        /// <param name="Compositor"></param>
        /// <returns></returns>
        public DataTable buscarCompositor(string Compositor)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Compositor", Compositor));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Compositor = @Compositor ORDER BY DescMetodo ", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos Ativo, pesquisado pelo Compositor
        /// </summary>
        /// <param name="Compositor"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCompositor(string Compositor, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Compositor", Compositor));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Compositor LIKE @Compositor AND Ativo LIKE @Ativo ORDER BY DescMetodo ", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos, pesquisado pelo Tipo
        /// <para>Tipo= 'Solfejo', 'Ritmo', 'Instrumento'</para>
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public DataTable buscarTipo(string Tipo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Tipo", Tipo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Tipo IN('" + @Tipo + "') ORDER BY DescMetodo ", objParam, "Metodos");
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
        /// Função que retorna os Registros da tabela Metodos Ativo, pesquisado pelo Tipo
        /// <para>Tipo= 'Solfejo', 'Ritmo', 'Instrumento'</para>
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarTipo(string Tipo, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Tipo", Tipo));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE Tipo IN('" + @Tipo + "') AND Ativo LIKE @Ativo ORDER BY DescMetodo ", objParam, "Metodos");
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
                idMetodo = objAcessa.retornarId(strId);
                return Convert.ToInt16(idMetodo);
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
