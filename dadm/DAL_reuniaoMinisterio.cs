using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.administracao;

namespace DAL.administracao
{
    public class DAL_reuniaoMinisterio
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela ReuniaoMinisterio
        object idReuniao = null;

        #endregion


        #region Strings Sql da tabela ReuniaoMinisterio

        //string de insert na tabela ReuniaoMinisterio
        private string strInsert = "INSERT INTO ReuniaoMinisterio (CodReuniao, Status, " +
"DataInclusao, HoraInclusao, CodUsuario, DataReuniao, HoraReuniao, CodTipoReuniao, CodCCB, " +
"DataFinaliza, HoraFinaliza, CodUsuarioFinaliza, DataCancela, HoraCancela, CodUsuarioCancela, " +
"CodAnciao, CodEncReg, CodExamina, CodCooperador, CodEncLocal, CodInstrutor, Obs, CodBiblia, " +
"Capitulo, VersoInicio, VersoFim, AssuntoPalavra, HinoAbertura)" +
"VALUES (@CodReuniao, @Status, @DataInclusao, @HoraInclusao, @CodUsuario, @DataReuniao, " +
"@HoraReuniao, @CodTipoReuniao, @CodCCB, @DataFinaliza, @HoraFinaliza, @CodUsuarioFinaliza, " +
"@DataCancela, @HoraCancela, @CodUsuarioCancela, @CodAnciao, @CodEncReg, @CodExamina, @CodCooperador, " +
"@CodEncLocal, @CodInstrutor, @Obs, @CodBiblia, @Capitulo, @VersoInicio, @VersoFim, @AssuntoPalavra, @HinoAbertura)";

        //string de update na tabela ReuniaoMinisterio
        private string strUpdate = "UPDATE ReuniaoMinisterio SET Status = @Status, " +
"DataInclusao = @DataInclusao, HoraInclusao = @HoraInclusao, CodUsuario = @CodUsuario, DataReuniao = @DataReuniao, " +
"HoraReuniao = @HoraReuniao, CodTipoReuniao = @CodTipoReuniao, CodCCB = @CodCCB, DataFinaliza = @DataFinaliza, " +
"HoraFinaliza = @HoraFinaliza, CodUsuarioFinaliza = @CodUsuarioFinaliza, DataCancela = @DataCancela, " +
"HoraCancela = @HoraCancela, CodUsuarioCancela = @CodUsuarioCancela, CodAnciao = @CodAnciao, " +
"CodEncReg = @CodEncReg, CodExamina = @CodExamina, CodCooperador = @CodCooperador, CodEncLocal = @CodEncLocal, " +
"CodInstrutor = @CodInstrutor, Obs = @Obs, CodBiblia = @CodBiblia, Capitulo = @Capitulo, " +
"VersoInicio = @VersoInicio, VersoFim = @VersoFim, AssuntoPalavra = @AssuntoPalavra, HinoAbertura = @HinoAbertura " +
"WHERE CodReuniao = @CodReuniao ";

        //string de delete na tabela ReuniaoMinisterio
        private string strDelete = "DELETE FROM ReuniaoMinisterio WHERE CodReuniao = @CodReuniao ";

        //string de select na tabela ReuniaoMinisterio
        private string strSelect = "SELECT RM.CodReuniao, RM.Status, RM.DataInclusao, RM.HoraInclusao, " +
"RM.CodUsuario, RM.DataReuniao, RM.HoraReuniao, RM.CodTipoReuniao, RM.CodCCB, " +
"RM.DataFinaliza, RM.HoraFinaliza, RM.CodUsuarioFinaliza, RM.DataCancela, RM.HoraCancela, RM.CodUsuarioCancela, " +
"RM.CodAnciao, RM.CodEncReg, RM.CodExamina, RM.CodCooperador, RM.CodEncLocal, RM.CodInstrutor, " +
"RM.Obs, RM.CodBiblia, RM.Capitulo, RM.VersoInicio, RM.VersoFim, RM.AssuntoPalavra, RM.HinoAbertura, " +
"PA.Nome AS NomeAnciao, PR.Nome AS NomeEncReg, PE.Nome AS NomeExamina, " +
"PC.Nome AS NomeCooperador, PL.Nome AS NomeEncLocal, PI.Nome AS NomeInstrutor, " +
"C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, C.CodRegiao, R.Descricao AS DescricaoRegiao, UI.Usuario, UF.Usuario AS UsuarioFinaliza, " +
"UC.Usuario AS UsuarioCancela, T.DescTipoReuniao, B.DescLivro " +
"FROM ReuniaoMinisterio AS RM " +
"LEFT OUTER JOIN Pessoa AS PA ON RM.CodAnciao = PA.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PR ON RM.CodEncReg = PR.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PE ON RM.CodExamina = PE.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PC ON RM.CodCooperador = PC.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PL ON RM.CodEncLocal = PL.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PI ON RM.CodInstrutor = PI.CodPessoa " +
"LEFT OUTER JOIN CCB AS C ON RM.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Usuario AS UI ON RM.CodUsuario = UI.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UF ON RM.CodUsuarioFinaliza = UF.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UC ON RM.CodUsuarioCancela = UC.CodUsuario " +
"LEFT OUTER JOIN TipoReuniao AS T ON RM.CodTipoReuniao = T.CodTipoReuniao " +
"LEFT OUTER JOIN Biblia AS B ON RM.CodBiblia = B.CodBiblia ";

        //string que retorna o próximo Id da tabela ReuniaoMinisterio
        private string strId = "SELECT MAX(CodReuniao) FROM ReuniaoMinisterio ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela ReuniaoMinisterio
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_reuniaoMinisterio objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ReuniaoMinisterio
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodReuniao", Convert.ToInt32(objEnt.CodReuniao)));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
                objParam.Add(new SqlParameter("@DataInclusao", string.IsNullOrEmpty(objEnt.DataInclusao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInclusao) as object));
                objParam.Add(new SqlParameter("@HoraInclusao", string.IsNullOrEmpty(objEnt.HoraInclusao) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraInclusao) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@DataReuniao", string.IsNullOrEmpty(objEnt.DataReuniao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataReuniao) as object));
                objParam.Add(new SqlParameter("@HoraReuniao", string.IsNullOrEmpty(objEnt.HoraReuniao) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraReuniao) as object));
                objParam.Add(new SqlParameter("@CodTipoReuniao", string.IsNullOrEmpty(objEnt.CodTipoReuniao) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTipoReuniao) as object));
                objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object));
                objParam.Add(new SqlParameter("@DataFinaliza", string.IsNullOrEmpty(objEnt.DataFinaliza) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataFinaliza) as object));
                objParam.Add(new SqlParameter("@HoraFinaliza", string.IsNullOrEmpty(objEnt.HoraFinaliza) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraFinaliza) as object));
                objParam.Add(new SqlParameter("@CodUsuarioFinaliza", string.IsNullOrEmpty(objEnt.CodUsuarioFinaliza) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioFinaliza) as object));
                objParam.Add(new SqlParameter("@DataCancela", string.IsNullOrEmpty(objEnt.DataCancela) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCancela) as object));
                objParam.Add(new SqlParameter("@HoraCancela", string.IsNullOrEmpty(objEnt.HoraCancela) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCancela) as object));
                objParam.Add(new SqlParameter("@CodUsuarioCancela", string.IsNullOrEmpty(objEnt.CodUsuarioCancela) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioCancela) as object));
                objParam.Add(new SqlParameter("@CodAnciao", string.IsNullOrEmpty(objEnt.CodAnciao) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodAnciao) as object));
                objParam.Add(new SqlParameter("@CodEncReg", string.IsNullOrEmpty(objEnt.CodEncReg) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncReg) as object));
                objParam.Add(new SqlParameter("@CodExamina", string.IsNullOrEmpty(objEnt.CodExamina) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodExamina) as object));
                objParam.Add(new SqlParameter("@CodCooperador", string.IsNullOrEmpty(objEnt.CodCooperador) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodCooperador) as object));
                objParam.Add(new SqlParameter("@CodEncLocal", string.IsNullOrEmpty(objEnt.CodEncLocal) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncLocal) as object));
                objParam.Add(new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(objEnt.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodInstrutor) as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@CodBiblia", string.IsNullOrEmpty(objEnt.CodBiblia) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodBiblia) as object));
                objParam.Add(new SqlParameter("@Capitulo", string.IsNullOrEmpty(objEnt.Capitulo) ? DBNull.Value as object : Convert.ToInt16(objEnt.Capitulo) as object));
                objParam.Add(new SqlParameter("@VersoInicio", string.IsNullOrEmpty(objEnt.VersoInicio) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersoInicio) as object));
                objParam.Add(new SqlParameter("@VersoFim", string.IsNullOrEmpty(objEnt.VersoFim) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersoFim) as object));
                objParam.Add(new SqlParameter("@AssuntoPalavra", string.IsNullOrEmpty(objEnt.AssuntoPalavra) ? DBNull.Value as object : objEnt.AssuntoPalavra as object));
                objParam.Add(new SqlParameter("@HinoAbertura", string.IsNullOrEmpty(objEnt.HinoAbertura) ? DBNull.Value as object : Convert.ToInt16(objEnt.HinoAbertura) as object));

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
        /// Função que faz INSERT na Tabela ReuniaoMinisterio
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_reuniaoMinisterio objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ReuniaoMinisterio
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodReuniao", Convert.ToInt32(objEnt.CodReuniao)));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
                objParam.Add(new SqlParameter("@DataInclusao", string.IsNullOrEmpty(objEnt.DataInclusao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInclusao) as object));
                objParam.Add(new SqlParameter("@HoraInclusao", string.IsNullOrEmpty(objEnt.HoraInclusao) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraInclusao) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@DataReuniao", string.IsNullOrEmpty(objEnt.DataReuniao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataReuniao) as object));
                objParam.Add(new SqlParameter("@HoraReuniao", string.IsNullOrEmpty(objEnt.HoraReuniao) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraReuniao) as object));
                objParam.Add(new SqlParameter("@CodTipoReuniao", string.IsNullOrEmpty(objEnt.CodTipoReuniao) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTipoReuniao) as object));
                objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object));
                objParam.Add(new SqlParameter("@DataFinaliza", string.IsNullOrEmpty(objEnt.DataFinaliza) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataFinaliza) as object));
                objParam.Add(new SqlParameter("@HoraFinaliza", string.IsNullOrEmpty(objEnt.HoraFinaliza) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraFinaliza) as object));
                objParam.Add(new SqlParameter("@CodUsuarioFinaliza", string.IsNullOrEmpty(objEnt.CodUsuarioFinaliza) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioFinaliza) as object));
                objParam.Add(new SqlParameter("@DataCancela", string.IsNullOrEmpty(objEnt.DataCancela) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCancela) as object));
                objParam.Add(new SqlParameter("@HoraCancela", string.IsNullOrEmpty(objEnt.HoraCancela) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCancela) as object));
                objParam.Add(new SqlParameter("@CodUsuarioCancela", string.IsNullOrEmpty(objEnt.CodUsuarioCancela) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioCancela) as object));
                objParam.Add(new SqlParameter("@CodAnciao", string.IsNullOrEmpty(objEnt.CodAnciao) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodAnciao) as object));
                objParam.Add(new SqlParameter("@CodEncReg", string.IsNullOrEmpty(objEnt.CodEncReg) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncReg) as object));
                objParam.Add(new SqlParameter("@CodExamina", string.IsNullOrEmpty(objEnt.CodExamina) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodExamina) as object));
                objParam.Add(new SqlParameter("@CodCooperador", string.IsNullOrEmpty(objEnt.CodCooperador) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodCooperador) as object));
                objParam.Add(new SqlParameter("@CodEncLocal", string.IsNullOrEmpty(objEnt.CodEncLocal) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncLocal) as object));
                objParam.Add(new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(objEnt.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodInstrutor) as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@CodBiblia", string.IsNullOrEmpty(objEnt.CodBiblia) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodBiblia) as object));
                objParam.Add(new SqlParameter("@Capitulo", string.IsNullOrEmpty(objEnt.Capitulo) ? DBNull.Value as object : Convert.ToInt16(objEnt.Capitulo) as object));
                objParam.Add(new SqlParameter("@VersoInicio", string.IsNullOrEmpty(objEnt.VersoInicio) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersoInicio) as object));
                objParam.Add(new SqlParameter("@VersoFim", string.IsNullOrEmpty(objEnt.VersoFim) ? DBNull.Value as object : Convert.ToInt16(objEnt.VersoFim) as object));
                objParam.Add(new SqlParameter("@AssuntoPalavra", string.IsNullOrEmpty(objEnt.AssuntoPalavra) ? DBNull.Value as object : objEnt.AssuntoPalavra as object));
                objParam.Add(new SqlParameter("@HinoAbertura", string.IsNullOrEmpty(objEnt.HinoAbertura) ? DBNull.Value as object : Convert.ToInt16(objEnt.HinoAbertura) as object));

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
        /// Função que faz DELETE na Tabela ReuniaoMinisterio
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_reuniaoMinisterio objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodReuniao", Convert.ToInt32(objEnt.CodReuniao)));
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
        /// Função que retorna os Registros da tabela ReuniaoMinisterio, pesquisado pelo Código
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodReuniao)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodReuniao))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY RM.CodReuniao ", objParam, "ReuniaoMinisterio");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.CodReuniao = @CodReuniao ORDER BY RM.CodReuniao", objParam, "ReuniaoMinisterio");
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
        /// Função que retorna os Registros da tabela ReuniaoMinisterio, pesquisado pelo Código
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <param name="">CodCCB</param>
        /// <returns></returns>
        public DataTable buscarCod(string CodReuniao, string CodCCB)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodReuniao))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.CodReuniao ", objParam, "ReuniaoMinisterio");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodReuniao", CodReuniao));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.CodReuniao = @CodReuniao AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.CodReuniao", objParam, "ReuniaoMinisterio");
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
        /// Função que retorna os Registros da tabela ReuniaoMinisterio, pesquisado pela Data
        /// <para>QualData: Informar Qual Data será Pesquisado (DataInclusao, DataReuniao, DataFinaliza, DataCancela)</para>
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name=""></param>
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

                if (QualData.Equals("DataReuniao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.DataReuniao BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataReuniao ", objParam, "ReuniaoMinisterio");
                }
                else if (QualData.Equals("DataFinaliza"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.DataFinaliza BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataFinaliza ", objParam, "ReuniaoMinisterio");
                }
                else if (QualData.Equals("DataCancela"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.DataCancela BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataCancela ", objParam, "ReuniaoMinisterio");
                }
                else if (QualData.Equals("DataInclusao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.DataInclusao BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataInclusao ", objParam, "ReuniaoMinisterio");
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
        /// Função que retorna os Registros da tabela ReuniaoMinisterio, pesquisado pelo Status
        /// </summary>
        /// <param name="Status"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public DataTable buscarStatus(string Status, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Status", Status));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.Status = @Status AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataReuniao", objParam, "ReuniaoMinisterio");
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
        /// Função que retorna os Registros da tabela ReuniaoMinisterio, pesquisado pelo Status
        /// <para>QualData: Informar Qual Data será Pesquisado (, DataReuniao, CodCCB, DataFinaliza, DataCancela, DataInclusao)</para>
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public DataTable buscarStatus(string Status, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Status", Status));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));

                if (QualData.Equals("DataReuniao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.Status = @Status AND RM.DataReuniao BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataReuniao ", objParam, "ReuniaoMinisterio");
                }
                else if (QualData.Equals("DataFinaliza"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.Status = @Status AND RM.DataFinaliza BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataFinaliza ", objParam, "ReuniaoMinisterio");
                }
                else if (QualData.Equals("DataCancela"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.Status = @Status AND RM.DataCancela BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataCancela ", objParam, "ReuniaoMinisterio");
                }
                else if (QualData.Equals("DataInclusao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE RM.Status = @Status AND RM.DataInclusao BETWEEN @DataInicial AND @DataFinal AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataInclusao ", objParam, "ReuniaoMinisterio");
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
        /// Função que retorna os Registros da tabela ReuniaoMinisterio, pesquisado pela Regiao
        /// </summary>
        /// <param name="Status"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodRegiao, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodRegiao = @CodRegiao AND RM.CodCCB IN(" + @CodCCB + ") ORDER BY RM.DataReuniao", objParam, "ReuniaoMinisterio");
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
                idReuniao = objAcessa.retornarId(strId);
                return Convert.ToInt64(idReuniao);
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