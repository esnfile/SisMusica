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
    public class DAL_preTeste
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela PreTeste
        object idPreTeste = null;

        #endregion

        #region Strings Sql da tabela PreTeste

        //string de insert na tabela PreTeste
        private string strInsert = "INSERT INTO PreTeste (CodPreTeste, Status, CodCCB, Obs, " +
"DataExame, HoraExame, DataAbertura, HoraAbertura, CodUsuarioAbertura, DataFechamento, HoraFechamento, CodUsuarioFechamento, DataReAgenda, " +
"HoraReAgenda, CodUsuarioReAgenda, Resultado, DataResultado, HoraResultado, CodUsuarioResultado, " +
"DataCancela, HoraCancela, CodUsuarioCancela, CodAnciao, CodCooperador, CodEncReg, CodExamina, CodEncLocal, CodInstrutor)" +
"VALUES (@CodPreTeste, @Status, @CodCCB, @Obs, @DataExame, @HoraExame, " +
"@DataAbertura, @HoraAbertura, @CodUsuarioAbertura, @DataFechamento, @HoraFechamento, @CodUsuarioFechamento, @DataReAgenda, " +
"@HoraReAgenda, @CodUsuarioReAgenda, @Resultado, @DataResultado, @HoraResultado, @CodUsuarioResultado, " +
"@DataCancela, @HoraCancela, @CodUsuarioCancela, @CodAnciao, @CodCooperador, @CodEncReg, @CodExamina, @CodEncLocal, @CodInstrutor)";

        //string de update na tabela PreTeste
        private string strUpdate = "UPDATE PreTeste SET Status = @Status, CodCCB = @CodCCB, Obs = @Obs, " +
"DataExame = @DataExame, HoraExame = @HoraExame, " +
"DataAbertura = @DataAbertura, HoraAbertura = @HoraAbertura, CodUsuarioAbertura = @CodUsuarioAbertura, " +
"DataFechamento = @DataFechamento, HoraFechamento = @HoraFechamento, CodUsuarioFechamento = @CodUsuarioFechamento, " +
"DataReAgenda = @DataReAgenda, HoraReAgenda = @HoraReAgenda, CodUsuarioReAgenda = @CodUsuarioReAgenda, " +
"Resultado = @Resultado, DataResultado = @DataResultado, HoraResultado = @HoraResultado, CodUsuarioResultado = @CodUsuarioResultado, " +
"DataCancela = @DataCancela, HoraCancela = @HoraCancela, CodUsuarioCancela = @CodUsuarioCancela, CodAnciao = @CodAnciao, " +
"CodCooperador = @CodCooperador, CodEncReg = @CodEncReg, CodExamina = @CodExamina, CodEncLocal = @CodEncLocal, CodInstrutor = @CodInstrutor " +
"WHERE CodPreTeste = @CodPreTeste ";

        //string de delete na tabela PreTeste
        private string strDelete = "DELETE FROM PreTeste WHERE CodPreTeste = @CodPreTeste ";

        //string de select na tabela PreTeste
        private string strSelect = "SELECT PT.CodPreTeste, PT.Status, PT.CodCCB, PT.Obs, PT.DataExame,  PT.HoraExame, " +
"PT.DataAbertura, PT.HoraAbertura, PT.CodUsuarioAbertura, PT.DataFechamento, PT.HoraFechamento, PT.CodUsuarioFechamento, PT.DataReAgenda, " +
"PT.HoraReAgenda, PT.CodUsuarioReAgenda, PT.Resultado, PT.DataResultado, PT.HoraResultado, PT.CodUsuarioResultado, " +
"PT.DataCancela, PT.HoraCancela, PT.CodUsuarioCancela, PT.CodAnciao, PT.CodCooperador, PT.CodEncReg, PT.CodExamina, PT.CodEncLocal, PT.CodInstrutor, " +
"PA.Nome AS NomeAnciao, PC.Nome AS NomeCooperador, PR.Nome AS NomeEncReg, PE.Nome AS NomeExamina, PL.Nome AS NomeEncLocal, PI.Nome AS NomeInstrutor, " +
"C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, C.CodRegiao, R.Descricao AS DescricaoRegiao, UA.Usuario AS UsuarioAbertura, UF.Usuario AS UsuarioFechamento, " +
"URA.Usuario AS UsuarioReAgenda, UR.Usuario AS UsuarioResultado, UC.Usuario AS UsuarioCancela " +
"FROM PreTeste AS PT " +
"LEFT OUTER JOIN Pessoa AS PA ON PT.CodAnciao = PA.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PC ON PT.CodCooperador = PC.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PR ON PT.CodEncReg = PR.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PE ON PT.CodExamina = PE.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PL ON PT.CodEncLocal = PL.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PI ON PT.CodInstrutor = PI.CodPessoa " +
"LEFT OUTER JOIN CCB AS C ON PT.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Usuario AS UA ON PT.CodUsuarioAbertura = UA.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UF ON PT.CodUsuarioFechamento = UF.CodUsuario " +
"LEFT OUTER JOIN Usuario AS URA ON PT.CodUsuarioReAgenda = URA.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UR ON PT.CodUsuarioResultado = UR.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UC ON PT.CodUsuarioCancela = UC.CodUsuario ";

        //string de select na tabela PreTeste
        private string strSelectFicha = "SELECT PT.CodPreTeste, PT.Status, PT.CodCCB, PT.Obs, PT.DataExame,  PT.HoraExame, " +
"PT.DataAbertura, PT.HoraAbertura, PT.CodUsuarioAbertura, PT.DataFechamento, PT.HoraFechamento, PT.CodUsuarioFechamento, PT.DataReAgenda, " +
"PT.HoraReAgenda, PT.CodUsuarioReAgenda, PT.Resultado, PT.DataResultado, PT.HoraResultado, PT.CodUsuarioResultado, " +
"PT.DataCancela, PT.HoraCancela, PT.CodUsuarioCancela, PT.CodAnciao, PT.CodCooperador, PT.CodEncReg, PT.CodExamina, PT.CodEncLocal, PT.CodInstrutor, " +
"PA.Nome AS NomeAnciao, PC.Nome AS NomeCooperador, PR.Nome AS NomeEncReg, PE.Nome AS NomeExamina, PL.Nome AS NomeEncLocal, PI.Nome AS NomeInstrutor, " +
"C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, C.CodRegiao, R.Descricao AS DescricaoRegiao, UA.Usuario AS UsuarioAbertura, UF.Usuario AS UsuarioFechamento, " +
"URA.Usuario AS UsuarioReAgenda, UR.Usuario AS UsuarioResultado, UC.Usuario AS UsuarioCancela " +
"FROM PreTeste AS PT " +
"LEFT OUTER JOIN Pessoa AS PA ON PT.CodAnciao = PA.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PC ON PT.CodCooperador = PC.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PR ON PT.CodEncReg = PR.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PE ON PT.CodExamina = PE.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PL ON PT.CodEncLocal = PL.CodPessoa " +
"LEFT OUTER JOIN Pessoa AS PI ON PT.CodInstrutor = PI.CodPessoa " +
"LEFT OUTER JOIN CCB AS C ON PT.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Usuario AS UA ON PT.CodUsuarioAbertura = UA.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UF ON PT.CodUsuarioFechamento = UF.CodUsuario " +
"LEFT OUTER JOIN Usuario AS URA ON PT.CodUsuarioReAgenda = URA.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UR ON PT.CodUsuarioResultado = UR.CodUsuario " +
"LEFT OUTER JOIN Usuario AS UC ON PT.CodUsuarioCancela = UC.CodUsuario " +
"WHERE PT.CodPreTeste IN (SELECT CodPreTeste FROM PreTesteFicha ";


        //string que retorna o próximo Id da tabela PreTeste
        private string strId = "SELECT MAX(CodPreTeste) FROM PreTeste ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela PreTeste
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTeste objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTeste
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPreTeste", Convert.ToInt64(objEnt.CodPreTeste)));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
                objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@DataExame", string.IsNullOrEmpty(objEnt.DataExame) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataExame) as object));
                objParam.Add(new SqlParameter("@HoraExame", string.IsNullOrEmpty(objEnt.HoraExame) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraExame) as object));
                objParam.Add(new SqlParameter("@DataAbertura", string.IsNullOrEmpty(objEnt.DataAbertura) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataAbertura) as object));
                objParam.Add(new SqlParameter("@HoraAbertura", string.IsNullOrEmpty(objEnt.HoraAbertura) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraAbertura) as object));
                objParam.Add(new SqlParameter("@CodUsuarioAbertura", string.IsNullOrEmpty(objEnt.CodUsuarioAbertura) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioAbertura) as object));
                objParam.Add(new SqlParameter("@DataFechamento", string.IsNullOrEmpty(objEnt.DataFechamento) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataFechamento) as object));
                objParam.Add(new SqlParameter("@HoraFechamento", string.IsNullOrEmpty(objEnt.HoraFechamento) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraFechamento) as object));
                objParam.Add(new SqlParameter("@CodUsuarioFechamento", string.IsNullOrEmpty(objEnt.CodUsuarioFechamento) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioFechamento) as object));
                objParam.Add(new SqlParameter("@DataReAgenda", string.IsNullOrEmpty(objEnt.DataReAgenda) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataReAgenda) as object));
                objParam.Add(new SqlParameter("@HoraReAgenda", string.IsNullOrEmpty(objEnt.HoraReAgenda) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraReAgenda) as object));
                objParam.Add(new SqlParameter("@CodUsuarioReAgenda", string.IsNullOrEmpty(objEnt.CodUsuarioReAgenda) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioReAgenda) as object));
                objParam.Add(new SqlParameter("@Resultado", string.IsNullOrEmpty(objEnt.Resultado) ? DBNull.Value as object : objEnt.Resultado as object));
                objParam.Add(new SqlParameter("@DataResultado", string.IsNullOrEmpty(objEnt.DataResultado) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataResultado) as object));
                objParam.Add(new SqlParameter("@HoraResultado", string.IsNullOrEmpty(objEnt.HoraResultado) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraResultado) as object));
                objParam.Add(new SqlParameter("@CodUsuarioResultado", string.IsNullOrEmpty(objEnt.CodUsuarioResultado) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioResultado) as object));
                objParam.Add(new SqlParameter("@DataCancela", string.IsNullOrEmpty(objEnt.DataCancela) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCancela) as object));
                objParam.Add(new SqlParameter("@HoraCancela", string.IsNullOrEmpty(objEnt.HoraCancela) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCancela) as object));
                objParam.Add(new SqlParameter("@CodUsuarioCancela", string.IsNullOrEmpty(objEnt.CodUsuarioCancela) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioCancela) as object));
                objParam.Add(new SqlParameter("@CodAnciao", string.IsNullOrEmpty(objEnt.CodAnciao) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodAnciao) as object));
                objParam.Add(new SqlParameter("@CodCooperador", string.IsNullOrEmpty(objEnt.CodCooperador) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodCooperador) as object));
                objParam.Add(new SqlParameter("@CodEncReg", string.IsNullOrEmpty(objEnt.CodEncReg) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncReg) as object));
                objParam.Add(new SqlParameter("@CodExamina", string.IsNullOrEmpty(objEnt.CodExamina) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodExamina) as object));
                objParam.Add(new SqlParameter("@CodEncLocal", string.IsNullOrEmpty(objEnt.CodEncLocal) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncLocal) as object));
                objParam.Add(new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(objEnt.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodInstrutor) as object));
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
        /// Função que faz INSERT na Tabela PreTeste
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_preTeste objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PreTeste
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPreTeste", Convert.ToInt64(objEnt.CodPreTeste)));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
                objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@DataExame", string.IsNullOrEmpty(objEnt.DataExame) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataExame) as object));
                objParam.Add(new SqlParameter("@HoraExame", string.IsNullOrEmpty(objEnt.HoraExame) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraExame) as object));
                objParam.Add(new SqlParameter("@DataAbertura", string.IsNullOrEmpty(objEnt.DataAbertura) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataAbertura) as object));
                objParam.Add(new SqlParameter("@HoraAbertura", string.IsNullOrEmpty(objEnt.HoraAbertura) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraAbertura) as object));
                objParam.Add(new SqlParameter("@CodUsuarioAbertura", string.IsNullOrEmpty(objEnt.CodUsuarioAbertura) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioAbertura) as object));
                objParam.Add(new SqlParameter("@DataFechamento", string.IsNullOrEmpty(objEnt.DataFechamento) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataFechamento) as object));
                objParam.Add(new SqlParameter("@HoraFechamento", string.IsNullOrEmpty(objEnt.HoraFechamento) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraFechamento) as object));
                objParam.Add(new SqlParameter("@CodUsuarioFechamento", string.IsNullOrEmpty(objEnt.CodUsuarioFechamento) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioFechamento) as object));
                objParam.Add(new SqlParameter("@DataReAgenda", string.IsNullOrEmpty(objEnt.DataReAgenda) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataReAgenda) as object));
                objParam.Add(new SqlParameter("@HoraReAgenda", string.IsNullOrEmpty(objEnt.HoraReAgenda) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraReAgenda) as object));
                objParam.Add(new SqlParameter("@CodUsuarioReAgenda", string.IsNullOrEmpty(objEnt.CodUsuarioReAgenda) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioReAgenda) as object));
                objParam.Add(new SqlParameter("@Resultado", string.IsNullOrEmpty(objEnt.Resultado) ? DBNull.Value as object : objEnt.Resultado as object));
                objParam.Add(new SqlParameter("@DataResultado", string.IsNullOrEmpty(objEnt.DataResultado) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataResultado) as object));
                objParam.Add(new SqlParameter("@HoraResultado", string.IsNullOrEmpty(objEnt.HoraResultado) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraResultado) as object));
                objParam.Add(new SqlParameter("@CodUsuarioResultado", string.IsNullOrEmpty(objEnt.CodUsuarioResultado) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioResultado) as object));
                objParam.Add(new SqlParameter("@DataCancela", string.IsNullOrEmpty(objEnt.DataCancela) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCancela) as object));
                objParam.Add(new SqlParameter("@HoraCancela", string.IsNullOrEmpty(objEnt.HoraCancela) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCancela) as object));
                objParam.Add(new SqlParameter("@CodUsuarioCancela", string.IsNullOrEmpty(objEnt.CodUsuarioCancela) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuarioCancela) as object));
                objParam.Add(new SqlParameter("@CodAnciao", string.IsNullOrEmpty(objEnt.CodAnciao) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodAnciao) as object));
                objParam.Add(new SqlParameter("@CodCooperador", string.IsNullOrEmpty(objEnt.CodCooperador) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodCooperador) as object));
                objParam.Add(new SqlParameter("@CodEncReg", string.IsNullOrEmpty(objEnt.CodEncReg) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncReg) as object));
                objParam.Add(new SqlParameter("@CodExamina", string.IsNullOrEmpty(objEnt.CodExamina) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodExamina) as object));
                objParam.Add(new SqlParameter("@CodEncLocal", string.IsNullOrEmpty(objEnt.CodEncLocal) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodEncLocal) as object));
                objParam.Add(new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(objEnt.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodInstrutor) as object));
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
        /// Função que faz DELETE na Tabela PreTeste
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_preTeste objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPreTeste", Convert.ToInt64(objEnt.CodPreTeste)));
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPreTeste)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPreTeste))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTeste", CodPreTeste));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY PT.CodPreTeste ", objParam, "PreTeste");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTeste", CodPreTeste));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.CodPreTeste = @CodPreTeste ORDER BY PT.CodPreTeste", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPreTeste, string CodCCB)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPreTeste))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTeste", CodPreTeste));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.CodPreTeste ", objParam, "PreTeste");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPreTeste", CodPreTeste));
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.CodPreTeste = @CodPreTeste AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.CodPreTeste", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pela Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarPessoa(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelectFicha + "WHERE CodCandidato = @CodPessoa) ORDER BY PT.DataExame", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pela Comum
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarComum(string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.CodCCB = @CodCCB ORDER BY PT.DataExame", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pela Solicitação
        /// </summary>
        /// <param name="CodSolicitaTeste"></param>
        /// <returns></returns>
        public DataTable buscarSolicita(string CodSolicitaTeste)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodSolicitaTeste", CodSolicitaTeste));
                objDtb = objAcessa.retornaDados(strSelectFicha + "WHERE CodSolicitaTeste = @CodSolicitaTeste) ORDER BY PT.DataExame", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pela Data
        /// <para>QualData: Informar Qual Data será Pesquisado (DataExame, DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
        /// </summary>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public DataTable buscarData(string QualData, string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));

                if (QualData.Equals("DataAbertura"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataAbertura BETWEEN @DataInicial AND @DataFinal ORDER BY PT.DataAbertura ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataFechamento"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataFechamento BETWEEN @DataInicial AND @DataFinal ORDER BY PT.DataFechamento ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataReAgenda"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataReAgenda BETWEEN @DataInicial AND @DataFinal ORDER BY PT.DataReAgenda ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataResultado"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataResultado BETWEEN @DataInicial AND @DataFinal ORDER BY PT.DataResultado ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataCancela"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataCancela BETWEEN @DataInicial AND @DataFinal ORDER BY PT.DataCancela ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataExame"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataExame BETWEEN @DataInicial AND @DataFinal ORDER BY PT.DataExame ", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pela Data
        /// <para>QualData: Informar Qual Data será Pesquisado (DataExame, DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
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

                if (QualData.Equals("DataAbertura"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataAbertura BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataAbertura ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataFechamento"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataFechamento BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataFechamento ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataReAgenda"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataReAgenda BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataReAgenda ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataResultado"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataResultado BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataResultado ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataCancela"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataCancela BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataCancela ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataExame"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.DataExame BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataExame ", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Status
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarStatus(string Status)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Status", Status));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status = @Status ORDER BY PT.DataExame", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Status
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarStatus(string Status, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Status", Status));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status = @Status AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataExame", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Status
        /// <para>QualData: Informar Qual Data será Pesquisado (DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela, DataExame)</para>
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
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

                if (QualData.Equals("DataAbertura"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status LIKE @Status AND PT.DataAbertura BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataAbertura ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataFechamento"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status LIKE @Status AND PT.DataFechamento BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataFechamento ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataReAgenda"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status LIKE @Status AND PT.DataReAgenda BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataReAgenda ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataResultado"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status LIKE @Status AND PT.DataResultado BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataResultado ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataCancela"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status LIKE @Status AND PT.DataCancela BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataCancela ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataExame"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Status LIKE @Status AND PT.DataExame BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataExame ", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Resultado
        /// <para>Resultado: Aprovado, Reprovado, Em Análise</para>
        /// </summary>
        /// <param name="Resultado"></param>
        /// <returns></returns>
        public DataTable buscarResultado(string Resultado)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Resultado", Resultado));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado = @Resultado ORDER BY PT.DataExame", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Resultado
        /// <para>Resultado: Aprovado, Reprovado, Em Análise</para>
        /// </summary>
        /// <param name="Resultado"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarResultado(string Resultado, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Resultado", Resultado));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado = @Resultado AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataExame", objParam, "PreTeste");
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
        /// Função que retorna os Registros da tabela PreTeste, pesquisado pelo Resultado
        /// <para>QualData: Informar Qual Data será Pesquisado (DataExame, DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
        /// <para>Resultado: Aprovado, Reprovado, Em Análise</para>
        /// </summary>
        /// <param name="Resultado"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarResultado(string Resultado, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Resultado", Resultado));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));

                if (QualData.Equals("DataAbertura"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado LIKE @Resultado AND PT.DataAbertura BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataAbertura ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataFechamento"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado LIKE @Resultado AND PT.DataFechamento BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataFechamento ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataReAgenda"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado LIKE @Resultado AND PT.DataReAgenda BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataReAgenda ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataResultado"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado LIKE @Resultado AND PT.DataResultado BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataResultado ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataCancela"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado LIKE @Resultado AND PT.DataCancela BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataCancela ", objParam, "PreTeste");
                }
                else if (QualData.Equals("DataExame"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PT.Resultado LIKE @Resultado AND PT.DataExame BETWEEN @DataInicial AND @DataFinal AND PT.CodCCB IN(" + @CodCCB + ") ORDER BY PT.DataExame ", objParam, "PreTeste");
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