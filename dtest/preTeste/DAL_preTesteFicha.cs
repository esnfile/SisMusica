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
    public class DAL_preTesteFicha
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela PreTesteFicha
        object idFichaPreTeste = null;

        #endregion

        #region Strings Sql da tabela PreTesteFicha

        //string de insert na tabela PreTesteFicha
        private string strInsert = "INSERT INTO PreTesteFicha (CodFichaPreTeste, CodPreTeste, CodCandidato, CodSolicitaTeste, Tipo, " +
"Data, Hora, Obs, CodUsuario, ObsMet, ObsMts, ObsHino, ObsEsc, ObsTeoria)" +
"VALUES (@CodFichaPreTeste, @CodPreTeste, @CodCandidato, @CodSolicitaTeste, @Tipo, " +
"@Data, @Hora, @Obs, @CodUsuario, ObsMet, @ObsMts, @ObsHino, @ObsEsc, @ObsTeoria)";

        //string de update na tabela PreTesteFicha
        private string strUpdate = "UPDATE PreTesteFicha SET CodPreTeste = @CodPreTeste, CodCandidato = @CodCandidato, " +
"CodSolicitaTeste = @CodSolicitaTeste, Tipo = @Tipo, Data = @Data, Hora = @Hora, Obs = @Obs, " +
"CodUsuario = @CodUsuario, ObsMet = @ObsMet, ObsMts = @ObsMts, ObsHino = @ObsHino, ObsEsc = @ObsEsc, ObsTeoria = @ObsTeoria " +
"WHERE CodFichaPreTeste = @CodFichaPreTeste ";

        //string de delete na tabela PreTesteFicha
        private string strDelete = "DELETE FROM PreTesteFicha WHERE CodFichaPreTeste = @CodFichaPreTeste ";

        //string de select na tabela PreTesteFicha
        private string strSelect = "SELECT FP.CodFichaPreTeste, FP.CodPreTeste, FP.CodCandidato, FP.CodSolicitaTeste, FP.Tipo, " +
"FP.Data, FP.Hora, FP.Obs, FP.CodUsuario, FP.ObsMet, FP.ObsMts, FP.ObsHino, FP.ObsEsc, FP.ObsTeoria, " + 
"U.Usuario, " +
"PT.CodCCB, PT.DataExame, PT.HoraExame, PT.DataAbertura, PT.HoraAbertura, PT.DataFechamento, PT.HoraFechamento, " +
"PT.CodAnciao, PT.CodCooperador, PT.CodEncReg, PT.CodExamina, PT.CodEncLocal, PT.CodInstrutor, " +
"C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, C.CodRegiao, " +
"RPT.Descricao AS DescricaoRegiao, " +
"PA.Nome AS NomeAnciao, " +
"PC.Nome AS NomeCooperador, " +
"PER.Nome AS NomeEncReg, " +
"PEX.Nome AS NomeExamina, " +
"PEL.Nome AS NomeEncLocal, " + 
"PI.Nome AS NomeInstrutor, " +
"P.Nome AS NomeCandidato, P.CodInstrumento, P.CodCidadeRes, " +
"I.DescInstrumento, I.CodFamilia, " +
"F.DescFamilia, " +
"PCI.Cidade AS CidadeRes, PCI.Estado AS EstadoRes, " +
"P.CodCCB AS CodCCBPessoa, P.CodCargo, P.Sexo, P.CodInstrutor AS CodInstrutorPessoa, " +
"CP.Codigo AS CodigoCCBPessoa, CP.CodRegiao AS CodRegiaoPessoa, CP.Descricao AS DescricaoCCBPessoa, " +
"RP.Descricao AS DescricaoRegiaoPessoa, " +
"CC.CodCidade AS CodCidadeCCBPessoa, CC.Cidade AS CidadeCCBPessoa, " +
"CG.DescCargo, CG.Ordem, CG.Masculino, CG.Feminino, CG.SiglaCargo, " +
"PIP.Nome AS NomeInstrutorPessoa " +
"FROM PreTesteFicha AS FP " +
"LEFT OUTER JOIN PreTeste AS PT ON FP.CodPreTeste = PT.CodPreTeste " +
"LEFT OUTER JOIN Pessoa AS P ON FP.CodCandidato = P.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PA ON PT.CodAnciao = PA.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PC ON PT.CodCooperador = PC.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PER ON PT.CodEncReg = PER.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PEX ON PT.CodExamina = PEX.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PEL ON PT.CodEncLocal = PEL.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PI ON PT.CodInstrutor = PI.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PIP ON P.CodInstrutor = PIP.CodPessoa " +
"LEFT OUTER JOIN Usuario AS U ON FP.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia " +
"LEFT OUTER JOIN CCB AS C ON PT.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS RPT ON C.CodRegiao = RPT.CodRegiao " +
"LEFT OUTER JOIN CCB AS CP ON P.CodCCB = CP.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS RP ON CP.CodRegiao = RP.CodRegiao " +
"LEFT OUTER JOIN Cidade AS PCI ON P.CodCidadeRes = PCI.CodCidade " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS CC ON CP.CodCidade = CC.CodCidade ";

        //string que retorna o próximo Id da tabela PreTesteFicha
        private string strId = "SELECT MAX(CodFichaPreTeste) FROM PreTesteFicha ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela PreTesteFicha
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTesteFicha objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTesteFicha
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFichaPreTeste", Convert.ToInt64(objEnt.CodFichaPreTeste)));
                objParam.Add(new SqlParameter("@CodPreTeste", string.IsNullOrEmpty(objEnt.CodPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPreTeste) as object));
                objParam.Add(new SqlParameter("@CodCandidato", string.IsNullOrEmpty(objEnt.CodCandidato) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodCandidato) as object));
                objParam.Add(new SqlParameter("@CodSolicitaTeste", string.IsNullOrEmpty(objEnt.CodSolicitaTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodSolicitaTeste) as object));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@Data", string.IsNullOrEmpty(objEnt.Data) ? DBNull.Value as object : Convert.ToInt32(objEnt.Data) as object));
                objParam.Add(new SqlParameter("@Hora", string.IsNullOrEmpty(objEnt.Hora) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hora) as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@ObsMet", string.IsNullOrEmpty(objEnt.ObsMet) ? DBNull.Value as object : objEnt.ObsMet as object));
                objParam.Add(new SqlParameter("@ObsMts", string.IsNullOrEmpty(objEnt.ObsMts) ? DBNull.Value as object : objEnt.ObsMts as object));
                objParam.Add(new SqlParameter("@ObsHino", string.IsNullOrEmpty(objEnt.ObsHino) ? DBNull.Value as object : objEnt.ObsHino as object));
                objParam.Add(new SqlParameter("@ObsEsc", string.IsNullOrEmpty(objEnt.ObsEsc) ? DBNull.Value as object : objEnt.ObsEsc as object));
                objParam.Add(new SqlParameter("@ObsTeoria", string.IsNullOrEmpty(objEnt.ObsTeoria) ? DBNull.Value as object : objEnt.ObsTeoria as object));

                blnRetorno = objAcessa.executar(strUpdate, objParam);

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

        /// <summary>
        /// Função que faz INSERT na Tabela PreTesteFicha
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_preTesteFicha objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTesteFicha
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFichaPreTeste", Convert.ToInt64(objEnt.CodFichaPreTeste)));
                objParam.Add(new SqlParameter("@CodPreTeste", string.IsNullOrEmpty(objEnt.CodPreTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPreTeste) as object));
                objParam.Add(new SqlParameter("@CodCandidato", string.IsNullOrEmpty(objEnt.CodCandidato) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodCandidato) as object));
                objParam.Add(new SqlParameter("@CodSolicitaTeste", string.IsNullOrEmpty(objEnt.CodSolicitaTeste) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodSolicitaTeste) as object));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@Data", string.IsNullOrEmpty(objEnt.Data) ? DBNull.Value as object : Convert.ToInt32(objEnt.Data) as object));
                objParam.Add(new SqlParameter("@Hora", string.IsNullOrEmpty(objEnt.Hora) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hora) as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@ObsMet", string.IsNullOrEmpty(objEnt.ObsMet) ? DBNull.Value as object : objEnt.ObsMet as object));
                objParam.Add(new SqlParameter("@ObsMts", string.IsNullOrEmpty(objEnt.ObsMts) ? DBNull.Value as object : objEnt.ObsMts as object));
                objParam.Add(new SqlParameter("@ObsHino", string.IsNullOrEmpty(objEnt.ObsHino) ? DBNull.Value as object : objEnt.ObsHino as object));
                objParam.Add(new SqlParameter("@ObsEsc", string.IsNullOrEmpty(objEnt.ObsEsc) ? DBNull.Value as object : objEnt.ObsEsc as object));
                objParam.Add(new SqlParameter("@ObsTeoria", string.IsNullOrEmpty(objEnt.ObsTeoria) ? DBNull.Value as object : objEnt.ObsTeoria as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                if (exl.Number.Equals(544))
                {
                    throw new Exception("Não foi possivel buscar o próximo número da tabela");
                }
                else if (exl.Number.Equals(2601))
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
        /// Função que faz DELETE na Tabela PreTesteFicha
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_preTesteFicha objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFichaPreTeste", Convert.ToInt64(objEnt.CodFichaPreTeste)));
                blnRetorno = objAcessa.executar(strDelete, objParam);

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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pelo Código
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodFichaPreTeste)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodFichaPreTeste))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", CodFichaPreTeste));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY FP.CodFichaPreTeste ", objParam, "PreTesteFicha");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", CodFichaPreTeste));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.CodFichaPreTeste = @CodFichaPreTeste ORDER BY FP.CodFichaPreTeste", objParam, "PreTesteFicha");
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pelo Código
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodFichaPreTeste, string CodCCB)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodFichaPreTeste))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", CodFichaPreTeste));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.CodFichaPreTeste ", objParam, "PreTesteFicha");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFichaPreTeste", CodFichaPreTeste));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.CodFichaPreTeste = @CodFichaPreTeste AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.CodFichaPreTeste", objParam, "PreTesteFicha");
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pela Data
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarData(string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));

                if (QualData.Equals("Data"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.Data BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.Data ", objParam, "PreTesteFicha");
                }
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pelo Tipo
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarTipo(string Tipo, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Tipo", Tipo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.Tipo = @Tipo AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataSolicita", objParam, "PreTesteFicha");
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pelo Tipo
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarTipo(string Tipo, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Tipo", Tipo));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));

                if (QualData.Equals("Data"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.Tipo = @Tipo AND FP.Data BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.Data ", objParam, "PreTesteFicha");
                }
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pela Pessoa
        /// </summary>
        /// <param name="CodCandidato"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarPessoa(string CodCandidato, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCandidato", CodCandidato));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.CodCandidato = @CodCandidato AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.Data ", objParam, "PreTesteFicha");
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pela Pessoa
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="CodCandidato"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarPessoa(string CodCandidato, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCandidato", CodCandidato));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));

                if (QualData.Equals("Data"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.CodCandidato = @CodCandidato AND FP.Data BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.Data ", objParam, "PreTesteFicha");
                }
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pelo PreTeste
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <returns></returns>
        public DataTable buscarPreTeste(string CodPreTeste)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPreTeste", CodPreTeste));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.CodPreTeste = @CodPreTeste ORDER BY P.Nome ", objParam, "PreTesteFicha");
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pelo PreTeste
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarPreTeste(string CodPreTeste, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPreTeste", CodPreTeste));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.CodPreTeste = @CodPreTeste AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.Data ", objParam, "PreTesteFicha");
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
        /// Função que retorna os Registros da tabela PreTesteFicha, pesquisado pelo PreTeste
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarPreTeste(string CodPreTeste, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPreTeste", CodPreTeste));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));

                if (QualData.Equals("Data"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE FP.CodPreTeste = @CodPreTeste AND FP.Data BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY FP.Data ", objParam, "PreTesteFicha");
                }
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
                idFichaPreTeste = objAcessa.retornarId(strId);
                return Convert.ToInt64(idFichaPreTeste);
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