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
    public class DAL_preTesteMts
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela PreTesteMts
        object idPreTeste = null;

        #endregion

        #region Strings Sql da tabela PreTesteMts

        //string de insert na tabela PreTesteMts
        private string strInsert = "INSERT INTO PreTesteMts (CodPreTesteMts, CodFichaPreTeste, CodMetodo, ModuloMts, LicaoMts, TipoMts) " +
"VALUES (@CodPreTesteMts, @CodFichaPreTeste, @CodMetodo, @ModuloMts, @LicaoMts, @TipoMts) ";

        //string de update na tabela PreTesteMts
        private string strUpdate = "UPDATE PreTesteMts SET CodFichaPreTeste = @CodFichaPreTeste, CodMetodo = @CodMetodo, ModuloMts = @ModuloMts, " +
"LicaoMts = @LicaoMts, TipoMts = @TipoMts " +
"WHERE CodPreTesteMts = @CodPreTesteMts ";

        //string de delete na tabela PreTesteMts
        private string strDelete = "DELETE FROM PreTesteMts WHERE CodPreTesteMts = @CodPreTesteMts ";

        //string de select na tabela PreTesteMts
        private string strSelect = "SELECT P.CodPreTesteMts, P.CodFichaPreTeste, P.CodMetodo, P.ModuloMts, P.LicaoMts, P.TipoMts, " +
"PF.CodPreTeste, PF.CodCandidato, PF.CodSolicitaTeste, PF.Tipo, PF.Data, PF.Hora, PT.CodCCB, " +
"PT.DataExame, PT.HoraExame, PT.Status, " +
"PC.Nome AS NomeCandidato, C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, M.DescMetodo " +
"FROM PreTesteMts AS P " +
"LEFT OUTER JOIN Metodos AS M ON P.CodMetodo = M.CodMetodo " +
"LEFT OUTER JOIN PreTesteFicha AS PF ON P.CodFichaPreTeste = PF.CodFichaPreTeste " +
"LEFT OUTER JOIN Pessoa AS PC ON PF.CodCandidato = PC.CodPessoa " +
"LEFT OUTER JOIN PreTeste AS PT ON PF.CodPreTeste = PT.CodPreTeste " +
"LEFT OUTER JOIN CCB AS C ON PT.CodCCB = C.CodCCB ";

        //string que retorna o próximo Id da tabela PreTesteMts
        private string strId = "SELECT MAX(CodPreTesteMts) FROM PreTesteMts ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UPDATE na Tabela PreTesteMts
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTesteMts objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTesteMts
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (Convert.ToInt64(objEnt.CodPreTesteMts).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteMts", retornaId()));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@ModuloMts", string.IsNullOrEmpty(objEnt.ModuloMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.ModuloMts) as object));
                    objParam.Add(new SqlParameter("@LicaoMts", string.IsNullOrEmpty(objEnt.LicaoMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.LicaoMts) as object));
                    objParam.Add(new SqlParameter("@TipoMts", string.IsNullOrEmpty(objEnt.TipoMts) ? DBNull.Value as object : objEnt.TipoMts as object));
                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteMts", Convert.ToInt64(objEnt.CodPreTesteMts)));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@ModuloMts", string.IsNullOrEmpty(objEnt.ModuloMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.ModuloMts) as object));
                    objParam.Add(new SqlParameter("@LicaoMts", string.IsNullOrEmpty(objEnt.LicaoMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.LicaoMts) as object));
                    objParam.Add(new SqlParameter("@TipoMts", string.IsNullOrEmpty(objEnt.TipoMts) ? DBNull.Value as object : objEnt.TipoMts as object));
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
        /// Função que faz DELETE na Tabela PreTesteMts
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_preTesteMts objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (!Convert.ToInt64(objEnt.CodPreTesteMts).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteMts", Convert.ToInt64(objEnt.CodPreTesteMts)));
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
        /// Função que retorna os Registros da tabela PreTesteMts, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPreTesteMts"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPreTesteMts)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPreTesteMts))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteMts", Convert.ToInt64(CodPreTesteMts)));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodPreTesteMts ", objParam, "PreTesteMts");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteMts", Convert.ToInt64(CodPreTesteMts)));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPreTesteMts = @CodPreTesteMts ORDER BY P.CodPreTesteMts", objParam, "PreTesteMts");
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
        /// Função que retorna os Registros da tabela PreTesteMts, pesquisado pelo CodFichaPreTeste
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodFichaPreTeste = @CodFichaPreTeste ORDER BY M.DescMetodo ", objParam, "PreTesteMts");
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
        /// Função que retorna os Registros da tabela PreTesteMts, pesquisado pelo TipoMts
        /// </summary>
        /// <param name="TipoMts"></param>
        /// <returns></returns>
        public DataTable buscarTipoMts(string TipoMts)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@TipoMts", TipoMts));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.TipoMts = @TipoMts ORDER BY M.DescMetodo ", objParam, "PreTesteMts");
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