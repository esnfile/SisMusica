using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.preTeste;

namespace DAL.preTeste
{
    public class DAL_preTesteMet
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela PreTesteMet
        object idPreTeste = null;

        #endregion

        #region Strings Sql da tabela PreTesteMet

        //string de insert na tabela PreTesteMet
        private string strInsert = "INSERT INTO PreTesteMet (CodPreTesteMet, CodFichaPreTeste, CodMetodo, PaginaMet, LicaoMet, FaseMet) " +
"VALUES (@CodPreTesteMet, @CodFichaPreTeste, @CodMetodo, @PaginaMet, @LicaoMet, @FaseMet) ";

        //string de update na tabela PreTesteMet
        private string strUpdate = "UPDATE PreTesteMet SET CodFichaPreTeste = @CodFichaPreTeste, CodMetodo = @CodMetodo, PaginaMet = @PaginaMet, LicaoMet = @LicaoMet, FaseMet = @FaseMet " +
"WHERE CodPreTesteMet = @CodPreTesteMet ";

        //string de delete na tabela PreTesteMet
        private string strDelete = "DELETE FROM PreTesteMet WHERE CodPreTesteMet = @CodPreTesteMet ";

        //string de select na tabela PreTesteMet
        private string strSelect = "SELECT P.CodPreTesteMet, P.CodFichaPreTeste, P.CodMetodo, P.PaginaMet, P.LicaoMet, P.FaseMet, " +
"PF.CodPreTeste, PF.CodCandidato, PF.CodSolicitaTeste, PF.Tipo, PF.Data, PF.Hora, PT.CodCCB, " +
"PT.DataExame, PT.HoraExame, PT.Status, " +
"PC.Nome AS NomeCandidato, C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, M.DescMetodo, M.Tipo AS TipoMetodo, M.TipoEscolha, M.PaginaFase " +
"FROM PreTesteMet AS P " +
"LEFT OUTER JOIN Metodos AS M ON P.CodMetodo = M.CodMetodo " +
"LEFT OUTER JOIN PreTesteFicha AS PF ON P.CodFichaPreTeste = PF.CodFichaPreTeste " +
"LEFT OUTER JOIN Pessoa AS PC ON PF.CodCandidato = PC.CodPessoa " +
"LEFT OUTER JOIN PreTeste AS PT ON PF.CodPreTeste = PT.CodPreTeste " +
"LEFT OUTER JOIN CCB AS C ON PT.CodCCB = C.CodCCB ";

        //string que retorna o próximo Id da tabela PreTesteMet
        private string strId = "SELECT MAX(CodPreTesteMet) FROM PreTesteMet ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UPDATE na Tabela PreTesteMet
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTesteMet objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTesteMet
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (Convert.ToInt64(objEnt.CodPreTesteMet).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteMet", retornaId()));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@PaginaMet", string.IsNullOrEmpty(objEnt.PaginaMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.PaginaMet) as object));
                    objParam.Add(new SqlParameter("@LicaoMet", string.IsNullOrEmpty(objEnt.LicaoMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.LicaoMet) as object));
                    objParam.Add(new SqlParameter("@FaseMet", string.IsNullOrEmpty(objEnt.FaseMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.FaseMet) as object));
                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteMet", Convert.ToInt64(objEnt.CodPreTesteMet)));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@PaginaMet", string.IsNullOrEmpty(objEnt.PaginaMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.PaginaMet) as object));
                    objParam.Add(new SqlParameter("@LicaoMet", string.IsNullOrEmpty(objEnt.LicaoMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.LicaoMet) as object));
                    objParam.Add(new SqlParameter("@FaseMet", string.IsNullOrEmpty(objEnt.FaseMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.FaseMet) as object));
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
                    throw new Exception("Erro: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela PreTesteMet
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_preTesteMet objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (!Convert.ToInt64(objEnt.CodPreTesteMet).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteMet", Convert.ToInt64(objEnt.CodPreTesteMet)));
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
        /// Função que retorna os Registros da tabela PreTesteMet, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPreTesteMet"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPreTesteMet)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPreTesteMet))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteMet", Convert.ToInt64(CodPreTesteMet)));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodPreTesteMet ", objParam, "PreTesteMet");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteMet", Convert.ToInt64(CodPreTesteMet)));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPreTesteMet = @CodPreTesteMet ORDER BY P.CodPreTesteMet", objParam, "PreTesteMet");
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
        /// Função que retorna os Registros da tabela PreTesteMet, pesquisado pelo CodFichaPreTeste
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <returns></returns>
        public DataTable buscarFichaPreTeste(string CodFichaPreTeste)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFichaPreTeste", CodFichaPreTeste));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodFichaPreTeste = @CodFichaPreTeste ORDER BY M.DescMetodo ", objParam, "PreTesteMet");
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
                idPreTeste = objAcessa.retornarId(strId);
                return Convert.ToInt64(idPreTeste);
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