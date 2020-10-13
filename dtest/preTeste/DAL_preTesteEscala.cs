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
    public class DAL_preTesteEscala
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela PreTesteEscala
        object idPreTeste = null;

        #endregion

        #region Strings Sql da tabela PreTesteEscala

        //string de insert na tabela PreTesteEscala
        private string strInsert = "INSERT INTO PreTesteEscala (CodPreTesteEscala, CodFichaPreTeste, CodEscala) " +
"VALUES (@CodPreTesteEscala, @CodFichaPreTeste, @CodEscala) ";

        //string de update na tabela PreTesteEscala
        private string strUpdate = "UPDATE PreTesteEscala SET CodFichaPreTeste = @CodFichaPreTeste, CodEscala = @CodEscala " +
"WHERE CodPreTesteEscala = @CodPreTesteEscala ";

        //string de delete na tabela PreTesteEscala
        private string strDelete = "DELETE FROM PreTesteEscala WHERE CodPreTesteEscala = @CodPreTesteEscala ";

        //string de select na tabela PreTesteEscala
        private string strSelect = "SELECT P.CodPreTesteEscala, P.CodFichaPreTeste, P.CodEscala, " +
"PF.CodPreTeste, PF.CodCandidato, PF.CodSolicitaTeste, PF.Tipo, PF.Data, PF.Hora, " +
"PT.CodCCB, PT.DataExame, PT.HoraExame, PT.Status, " +
"PC.Nome AS NomeCandidato, " +
"C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, " +
"E.DescEscala, E.CodTipoEscala, T.DescTipo AS DescTipoEscala " +
"FROM PreTesteEscala AS P " +
"LEFT OUTER JOIN Escala AS E ON P.CodEscala = E.CodEscala " +
"LEFT OUTER JOIN PreTesteFicha AS PF ON P.CodFichaPreTeste = PF.CodFichaPreTeste " +
"LEFT OUTER JOIN Pessoa AS PC ON PF.CodCandidato = PC.CodPessoa " +
"LEFT OUTER JOIN PreTeste AS PT ON PF.CodPreTeste = PT.CodPreTeste " +
"LEFT OUTER JOIN CCB AS C ON PT.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN TipoEscala AS T ON E.CodTipoEscala = T.CodTipoEscala ";

        //string que retorna o próximo Id da tabela PreTesteEscala
        private string strId = "SELECT MAX(CodPreTesteEscala) FROM PreTesteEscala ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UPDATE na Tabela PreTesteEscala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTesteEscala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTesteEscala
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (Convert.ToInt64(objEnt.CodPreTesteEscala).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteEscala", retornaId()));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodEscala", string.IsNullOrEmpty(objEnt.CodEscala) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodEscala) as object));
                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteEscala", Convert.ToInt64(objEnt.CodPreTesteEscala)));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodEscala", string.IsNullOrEmpty(objEnt.CodEscala) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodEscala) as object));
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
        /// Função que faz DELETE na Tabela PreTesteEscala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_preTesteEscala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (!Convert.ToInt64(objEnt.CodPreTesteEscala).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteEscala", Convert.ToInt64(objEnt.CodPreTesteEscala)));
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
        /// Função que retorna os Registros da tabela PreTesteEscala, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPreTesteEscala"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPreTesteEscala)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPreTesteEscala))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteEscala", Convert.ToInt64(CodPreTesteEscala)));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodPreTesteEscala ", objParam, "PreTesteEscala");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteEscala", Convert.ToInt64(CodPreTesteEscala)));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPreTesteEscala = @CodPreTesteEscala ORDER BY P.CodPreTesteEscala", objParam, "PreTesteEscala");
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
        /// Função que retorna os Registros da tabela PreTesteEscala, pesquisado pelo CodFichaPreTeste
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodFichaPreTeste = @CodFichaPreTeste ORDER BY E.CodTipoEscala ", objParam, "PreTesteEscala");
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