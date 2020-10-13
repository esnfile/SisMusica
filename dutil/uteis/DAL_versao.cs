using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.uteis;

namespace DAL.uteis
{
    public class DAL_versao
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idVersao = null;

        #endregion

        #region Strings Sql da tabela Versao

        //string de insert na tabela Versao
        private string strInsert = "INSERT INTO Versao (CodVersao, VersaoPrincipal, VersaoSecundaria, NumeroVersao, " +
"Revisao, DataLancamento, HoraLancamento, TipoAtualizacao) " +
"VALUES (@CodVersao, @VersaoPrincipal, @VersaoSecundaria, @NumeroVersao, " +
"@Revisao, @DataLancamento, @HoraLancamento, @TipoAtualizacao) ";

        //string de update na tabela Versao
        private string strUpdate = "UPDATE Versao SET VersaoPrincipal = @VersaoPrincipal, VersaoSecundaria = @VersaoSecundaria, " +
"NumeroVersao = @NumeroVersao, Revisao = @Revisao, DataLancamento = @DataLancamento, " +
"HoraLancamento = @HoraLancamento, TipoAtualizacao = @TipoAtualizacao " +
"WHERE CodVersao = @CodVersao ";

        //string de delete na tabela Versao
        private string strDelete = "DELETE FROM Versao WHERE CodVersao = @CodVersao ";

        //string de select na tabela Versao
        private string strSelect = "SELECT CodVersao, VersaoPrincipal, VersaoSecundaria, NumeroVersao, " +
"Revisao, DataLancamento, HoraLancamento, TipoAtualizacao " +
"FROM Versao ";

        //string de select na tabela Versao
        private string strSelectUlt = "SELECT TOP 1 CodVersao, VersaoPrincipal, VersaoSecundaria, NumeroVersao, " +
"Revisao, DataLancamento, HoraLancamento, TipoAtualizacao " +
"FROM Versao ";

        //string que retorna o próximo Id da tabela Versao
        private string strId = "SELECT MAX (CodVersao) FROM Versao ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Versao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_versao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Versao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodVersao", string.IsNullOrEmpty(objEnt.CodVersao) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodVersao) as object));
                objParam.Add(new SqlParameter("@VersaoPrincipal", string.IsNullOrEmpty(objEnt.VersaoPrincipal) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersaoPrincipal) as object));
                objParam.Add(new SqlParameter("@VersaoSecundaria", string.IsNullOrEmpty(objEnt.VersaoSecundaria) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersaoSecundaria) as object));
                objParam.Add(new SqlParameter("@NumeroVersao", string.IsNullOrEmpty(objEnt.NumeroVersao) ? DBNull.Value as object : Convert.ToInt16(objEnt.NumeroVersao) as object));
                objParam.Add(new SqlParameter("@Revisao", string.IsNullOrEmpty(objEnt.Revisao) ? DBNull.Value as object : Convert.ToInt16(objEnt.Revisao) as object));
                objParam.Add(new SqlParameter("@DataLancamento", string.IsNullOrEmpty(objEnt.DataLancamento) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataLancamento) as object));
                objParam.Add(new SqlParameter("@HoraLancamento", string.IsNullOrEmpty(objEnt.HoraLancamento) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraLancamento) as object));
                objParam.Add(new SqlParameter("@TipoAtualizacao", string.IsNullOrEmpty(objEnt.TipoAtualizacao) ? DBNull.Value as object : objEnt.VersaoSecundaria as object));
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
        /// Função que faz INSERT na Tabela Versao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_versao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Versao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodVersao", string.IsNullOrEmpty(objEnt.CodVersao) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodVersao) as object));
                objParam.Add(new SqlParameter("@VersaoPrincipal", string.IsNullOrEmpty(objEnt.VersaoPrincipal) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersaoPrincipal) as object));
                objParam.Add(new SqlParameter("@VersaoSecundaria", string.IsNullOrEmpty(objEnt.VersaoSecundaria) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersaoSecundaria) as object));
                objParam.Add(new SqlParameter("@NumeroVersao", string.IsNullOrEmpty(objEnt.NumeroVersao) ? DBNull.Value as object : Convert.ToInt16(objEnt.NumeroVersao) as object));
                objParam.Add(new SqlParameter("@Revisao", string.IsNullOrEmpty(objEnt.Revisao) ? DBNull.Value as object : Convert.ToInt16(objEnt.Revisao) as object));
                objParam.Add(new SqlParameter("@DataLancamento", string.IsNullOrEmpty(objEnt.DataLancamento) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataLancamento) as object));
                objParam.Add(new SqlParameter("@HoraLancamento", string.IsNullOrEmpty(objEnt.HoraLancamento) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraLancamento) as object));
                objParam.Add(new SqlParameter("@TipoAtualizacao", string.IsNullOrEmpty(objEnt.TipoAtualizacao) ? DBNull.Value as object : objEnt.VersaoSecundaria as object));

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
        /// Função que faz DELETE na Tabela Versao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_versao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Versao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodVersao", Convert.ToInt32(objEnt.CodVersao)));
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
        /// Função que retorna os Registros da tabela Versao, pesquisado pela VersaoPrincipal
        /// </summary>
        /// <param name="CodVersao"></param>
        /// <returns></returns>
        public DataTable buscarVersao(string CodVersao)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodVersao))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodVersao", CodVersao));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY VersaoPrincipal, VersaoSecundaria, NumeroVersao, Revisao ", objParam, "Versao");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodVersao", CodVersao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodVersao = @CodVersao ORDER BY VersaoPrincipal, VersaoSecundaria, NumeroVersao, Revisao ", objParam, "Versao");
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
        /// Função que retorna os Registros da tabela Versao
        /// </summary>
        /// <returns></returns>
        public DataTable buscarUltVersao()
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objDtb = objAcessa.retornaDados(strSelectUlt + "ORDER BY CodVersao DESC ", objParam, "Versao");
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
        /// Função que retorna os Registros da tabela Versao, pesquisado pela data
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public DataTable buscarData(string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DataLancamento BETWEEN @DataInicial AND @DataFinal ORDER BY DataLancamento ", objParam, "Versao");
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
                idVersao = objAcessa.retornarId(strId);
                return Convert.ToInt32(idVersao);
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