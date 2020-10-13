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
    public class DAL_preTesteHino
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela PreTesteHino
        object idPreTeste = null;

        #endregion

        #region Strings Sql da tabela PreTesteHino

        //string de insert na tabela PreTesteHino
        private string strInsert = "INSERT INTO PreTesteHino (CodPreTesteHino, CodFichaPreTeste, CodHinario, Hino) " +
"VALUES (@CodPreTesteHino, @CodFichaPreTeste, @CodHinario, @Hino) ";

        //string de update na tabela PreTesteHino
        private string strUpdate = "UPDATE PreTesteHino SET CodFichaPreTeste = @CodFichaPreTeste, CodHinario = @CodHinario, Hino = @Hino " +
"WHERE CodPreTesteHino = @CodPreTesteHino ";

        //string de delete na tabela PreTesteHino
        private string strDelete = "DELETE FROM PreTesteHino WHERE CodPreTesteHino = @CodPreTesteHino ";

        //string de select na tabela PreTesteHino
        private string strSelect = "SELECT P.CodPreTesteHino, P.CodFichaPreTeste, P.CodHinario, P.Hino, " +
"PF.CodPreTeste, PF.CodCandidato, PF.CodSolicitaTeste, PF.Tipo, PF.Data, PF.Hora, PT.CodCCB, " +
"PT.DataExame, PT.HoraExame, PT.Status, " +
"PC.Nome AS NomeCandidato, C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, H.DescHinario, H.CodTonalidade, T.DescTonalidade " +
"FROM PreTesteHino AS P " +
"LEFT OUTER JOIN Hinario AS H ON P.CodHinario = H.CodHinario " +
"LEFT OUTER JOIN PreTesteFicha AS PF ON P.CodFichaPreTeste = PF.CodFichaPreTeste " +
"LEFT OUTER JOIN Pessoa AS PC ON PF.CodCandidato = PC.CodPessoa " +
"LEFT OUTER JOIN PreTeste AS PT ON PF.CodPreTeste = PT.CodPreTeste " +
"LEFT OUTER JOIN CCB AS C ON PT.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN Tonalidade AS T ON H.CodTonalidade = T.CodTonalidade ";

        //string que retorna o próximo Id da tabela PreTesteHino
        private string strId = "SELECT MAX(CodPreTesteHino) FROM PreTesteHino ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UPDATE na Tabela PreTesteHino
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTesteHino objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTesteHino
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (Convert.ToInt64(objEnt.CodPreTesteHino).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteHino", retornaId()));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodHinario", string.IsNullOrEmpty(objEnt.CodHinario) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodHinario) as object));
                    objParam.Add(new SqlParameter("@Hino", string.IsNullOrEmpty(objEnt.Hino) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hino) as object));
                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteHino", Convert.ToInt64(objEnt.CodPreTesteHino)));
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", string.IsNullOrEmpty(objEnt.CodFichaPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodFichaPreTeste) as object));
                    objParam.Add(new SqlParameter("@CodHinario", string.IsNullOrEmpty(objEnt.CodHinario) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodHinario) as object));
                    objParam.Add(new SqlParameter("@Hino", string.IsNullOrEmpty(objEnt.Hino) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hino) as object));
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
        /// Função que faz DELETE na Tabela PreTesteHino
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_preTesteHino objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (!Convert.ToInt64(objEnt.CodPreTesteHino).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodPreTesteHino", Convert.ToInt64(objEnt.CodPreTesteHino)));
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
        /// Função que retorna os Registros da tabela PreTesteHino, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPreTesteHino"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPreTesteHino)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPreTesteHino))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteHino", Convert.ToInt64(CodPreTesteHino)));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodPreTesteHino ", objParam, "PreTesteHino");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTesteHino", Convert.ToInt64(CodPreTesteHino)));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPreTesteHino = @CodPreTesteHino ORDER BY P.CodPreTesteHino", objParam, "PreTesteHino");
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
        /// Função que retorna os Registros da tabela PreTesteHino, pesquisado pelo CodFichaPreTeste
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodFichaPreTeste = @CodFichaPreTeste ORDER BY H.DescHinario ", objParam, "PreTesteHino");
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