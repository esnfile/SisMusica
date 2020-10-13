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
    public class DAL_parametroTesteMet
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela ParametroTesteMet
        object idParamPreTeste = null;

        #endregion

        #region Strings Sql da tabela ParametroTesteMet

        //string de insert na tabela ParametroTesteMet
        private string strInsert = "INSERT INTO ParametroTesteMet (CodParamTesteMet, CodParametro, CodMetodo, " +
"QtdeLicao, CodInstrumento)  " +
"VALUES (@CodParamTesteMet, @CodParametro, @CodMetodo, @QtdeLicao, @CodInstrumento) ";

        //string de update na tabela ParametroTesteMet
        private string strUpdate = "UPDATE ParametroTesteMet SET CodParametro = @CodParametro, CodMetodo = @CodMetodo, " +
"QtdeLicao = @QtdeLicao, CodInstrumento = @CodInstrumento " +
"WHERE CodParamTesteMet = @CodParamTesteMet ";

        //string de delete na tabela ParametroTesteMet
        private string strDelete = "DELETE FROM ParametroTesteMet WHERE CodParamTesteMet = @CodParamTesteMet ";

        //string de select na tabela ParametroTesteMet
        private string strSelect = "SELECT P.CodParamTesteMet, P.CodParametro, P.CodMetodo, P.QtdeLicao, P.CodInstrumento, " +
"M.DescMetodo, M.Compositor, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase, I.DescInstrumento, I.CodFamilia, I.Situacao, I.Ordem, " +
"F.DescFamilia " +
"FROM ParametroTesteMet AS P " +
"LEFT OUTER JOIN Metodos AS M ON P.CodMetodo = M.CodMetodo " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string de select na tabela Metodos, referindo aos metodos que não estão na tabela ParametroTesteMet
        private string strSelectMet = "SELECT MI.CodMetodoInstr, MI.CodInstrumento, MI.CodMetodo, MI.AplicarEm, " +
"M.DescMetodo, M.Compositor, M.QtdePagina, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase, I.DescInstrumento " +
"FROM MetodoInstr AS MI " +
"LEFT OUTER JOIN Metodos AS M ON MI.CodMetodo = M.CodMetodo " +
"LEFT OUTER JOIN Instrumentos AS I ON MI.CodInstrumento = I.CodInstrumento " +
"WHERE MI.CodMetodo NOT IN (SELECT CodMetodo FROM ParametroTesteMet ";

        //string que retorna o próximo Id da tabela ParametroTesteMet
        private string strId = "SELECT MAX(CodParamTesteMet) FROM ParametroTesteMet ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UPDATE na Tabela ParametroTesteMet
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_parametroTesteMet objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ParametroTesteMet
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (Convert.ToInt64(objEnt.CodParamTesteMet).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodParamTesteMet", retornaId()));
                    objParam.Add(new SqlParameter("@CodParametro", string.IsNullOrEmpty(objEnt.CodParametro) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodParametro) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@QtdeLicao", string.IsNullOrEmpty(objEnt.QtdeLicao) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeLicao) as object));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));

                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodParamTesteMet", Convert.ToInt64(objEnt.CodParamTesteMet) as object));
                    objParam.Add(new SqlParameter("@CodParametro", string.IsNullOrEmpty(objEnt.CodParametro) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodParametro) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@QtdeLicao", string.IsNullOrEmpty(objEnt.QtdeLicao) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeLicao) as object));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));

                    blnRetorno = objAcessa.executar(strUpdate, objParam);
                }
                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                if (exl.Number.Equals(2601))
                {
                    throw new Exception("Não foi possivel salvar o registro, já que criaram" + "\n" +
                                        "valores duplicados na base de dados.");
                }
                else
                {
                    throw new Exception("Erro:: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }

        #endregion

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela ParametroTesteMet
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_parametroTesteMet objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (!Convert.ToInt64(objEnt.CodParametro).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodParamTesteMet", Convert.ToInt64(objEnt.CodParamTesteMet)));
                    blnRetorno = objAcessa.executar(strDelete, objParam);
                }

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                if (exl.Number.Equals(547))
                {
                    throw new Exception("Impossivel excluir. Quebra de integridade!");
                }
                else
                {
                    throw new Exception("Erro: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funções para buscar os dados e Preencher os Valores

        /// <summary>
        /// Função que retorna os Registros da tabela ParametroTesteMet, pesquisado pelo Código
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>
        public DataTable buscarParametro(string CodParametro)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodParametro))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(CodParametro)));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodParametro ", objParam, "ParametroTesteMet");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(CodParametro)));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodParametro = @CodParametro ORDER BY P.CodParametro", objParam, "ParametroTesteMet");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw new Exception(exl.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela ParametroTesteMet, pesquisado pelo Metodo
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarParamMet(string CodMetodo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(CodMetodo)));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodMetodo = @CodMetodo ORDER BY M.DescMetodo", objParam, "ParametroTesteMet");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw new Exception(exl.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela ParametroTesteMet, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(CodInstrumento)));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento = @CodInstrumento ORDER BY M.DescMetodo", objParam, "ParametroTesteMet");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw new Exception(exl.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Metodos, pesquisado pelo CodInstrumento.*\
        /// Essa Consulta retorna os valores que não estão na Tabela ParametroTesteMet
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarMetodos(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelectMet + "WHERE CodInstrumento = @CodInstrumento) ORDER BY M.DescMetodo ", objParam, "Hinario");
                //instancia a lista
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
        public Int64 retornaId()
        {
            try
            {
                idParamPreTeste = objAcessa.retornarId(strId);
                return Convert.ToInt64(idParamPreTeste);
            }
            catch (SqlException exl)
            {
                throw new Exception(exl.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}