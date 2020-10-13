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
    public class DAL_solicitaTeste
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idSolicita = null;

        #endregion

        #region Strings Sql da tabela SolicitaTeste

        //string de insert na tabela SolicitaTeste
        private string strInsert = "INSERT INTO SolicitaTeste (CodSolicitaTeste, Tipo, CodPessoa, Data, Hora, CodUsuario, Status) " +
"VALUES (@CodSolicitaTeste, @Tipo, @CodPessoa, @Data, @Hora, @CodUsuario, @Status) ";

        //string de update na tabela SolicitaTeste
        private string strUpdate = "UPDATE SolicitaTeste SET Tipo = @Tipo, CodPessoa = @CodPessoa, Data = @Data, " +
"Hora = @Hora, CodUsuario = @CodUsuario, Status = @Status " +
"WHERE CodSolicitaTeste = @CodSolicitaTeste ";

        //string de delete na tabela SolicitaTeste
        private string strDelete = "DELETE FROM SolicitaTeste WHERE CodSolicitaTeste = @CodSolicitaTeste ";

        //string de select na tabela SolicitaTeste
        private string strSelect = "SELECT S.CodSolicitaTeste, S.Tipo, S.CodPessoa, " +
"S.Data, S.Hora, S.CodUsuario, S.Status, " +
"P.Nome, P.CodCCB, P.CodInstrumento, C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, " +
"C.CodRegiao, R.Codigo AS CodigoRegiao, R.Descricao AS DescricaoRegiao, I.DescInstrumento, I.CodFamilia, " +
"F.DescFamilia, U.Usuario " +
"FROM SolicitaTeste AS S " +
"LEFT OUTER JOIN Pessoa AS P ON S.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Usuario AS U ON S.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN CCB AS C ON P.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string que retorna o próximo Id da tabela SolicitaTeste
        private string strId = "SELECT MAX (CodSolicitaTeste) FROM SolicitaTeste ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela SolicitaTeste
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_solicitaTeste objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela SolicitaTeste
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodSolicitaTeste", Convert.ToInt64(objEnt.CodSolicitaTeste)));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                objParam.Add(new SqlParameter("@Data", string.IsNullOrEmpty(objEnt.Data) ? DBNull.Value as object : Convert.ToInt32(objEnt.Data) as object));
                objParam.Add(new SqlParameter("@Hora", string.IsNullOrEmpty(objEnt.Hora) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hora) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
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
        /// Função que faz INSERT na Tabela SolicitaTeste
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_solicitaTeste objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela SolicitaTeste
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodSolicitaTeste", Convert.ToInt64(objEnt.CodSolicitaTeste)));
                objParam.Add(new SqlParameter("@Tipo", string.IsNullOrEmpty(objEnt.Tipo) ? DBNull.Value as object : objEnt.Tipo as object));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                objParam.Add(new SqlParameter("@Data", string.IsNullOrEmpty(objEnt.Data) ? DBNull.Value as object : Convert.ToInt32(objEnt.Data) as object));
                objParam.Add(new SqlParameter("@Hora", string.IsNullOrEmpty(objEnt.Hora) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hora) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));

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
        /// Função que faz DELETE na Tabela SolicitaTeste
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_solicitaTeste objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela SolicitaTeste
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodSolicitaTeste", Convert.ToInt64(objEnt.CodSolicitaTeste)));
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Código
        /// </summary>
        /// <param name="CodSolicitaTeste"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodSolicitaTeste)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodSolicitaTeste))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSolicitaTeste", CodSolicitaTeste));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY S.CodSolicitaTeste ", objParam, "SolicitaTeste");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSolicitaTeste", CodSolicitaTeste));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodSolicitaTeste = @CodSolicitaTeste ORDER BY S.CodSolicitaTeste", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Código
        /// </summary>
        /// <param name="CodSolicitaTeste"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodSolicitaTeste, string CodCCBUsu)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodSolicitaTeste))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSolicitaTeste", CodSolicitaTeste));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.CodSolicitaTeste ", objParam, "SolicitaTeste");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSolicitaTeste", CodSolicitaTeste));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodSolicitaTeste = @CodSolicitaTeste AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.CodSolicitaTeste", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Código
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodSolicitaTeste"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodSolicitaTeste, string CodCCBUsu, string Status)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodSolicitaTeste))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSolicitaTeste", CodSolicitaTeste));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@Status", Status));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") AND S.Status = @Status ORDER BY S.CodSolicitaTeste ", objParam, "SolicitaTeste");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodSolicitaTeste", CodSolicitaTeste));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@Status", Status));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodSolicitaTeste = @CodSolicitaTeste AND P.CodCCB IN(" + @CodCCBUsu + ") AND S.Status = @Status ORDER BY S.CodSolicitaTeste", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Tipo
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Tipo = @Tipo ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Tipo
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarTipo(string Tipo, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Tipo", Tipo));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Tipo = @Tipo AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Tipo
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarTipo(string Tipo, string CodCCBUsu, string Status)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Tipo", Tipo));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Status", Status));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Tipo = @Tipo AND P.CodCCB IN(" + @CodCCBUsu + ") AND S.Status = @Status ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Status
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Status = @Status ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Status
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarStatus(string Status, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Status", Status));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Status = @Status AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Pessoa
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodPessoa = @CodPessoa ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarPessoa(string CodPessoa, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Pessoa
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarPessoa(string CodPessoa, string CodCCBUsu, string Status)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Status", Status));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") AND S.Status = @Status ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Comum
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarCCB(string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodPessoa ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Comum
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarCCB(string CodCCB, string Status)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@Status", Status));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodCCB AND S.Status = @Status ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Regiao
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodRegiao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodRegiao = @CodRegiao ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Regiao
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodRegiao, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Regiao
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodRegiao, string CodCCBUsu, string Status)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Status", Status));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") AND S.Status = @Status ORDER BY S.Tipo, P.Nome ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarUsuario(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodUsuario = @CodUsuario ORDER BY S.Data ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pelo Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarUsuario(string CodUsuario, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.CodUsuario = @CodUsuario AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.Data ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Data
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Data BETWEEN @DataInicial AND @DataFinal ORDER BY S.Tipo, S.Data ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Data
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarData(string DataInicial, string DataFinal, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Data BETWEEN @DataInicial AND @DataFinal AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY S.Tipo, S.Data ", objParam, "SolicitaTeste");
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
        /// Função que retorna os Registros da tabela SolicitaTeste, pesquisado pela Data
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarData(string DataInicial, string DataFinal, string CodCCBUsu, string Status)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Status", Status));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE S.Data BETWEEN @DataInicial AND @DataFinal AND P.CodCCB IN(" + @CodCCBUsu + ") AND S.Status = @Status ORDER BY S.Tipo, S.Data ", objParam, "SolicitaTeste");
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
                idSolicita = objAcessa.retornarId(strId);
                return Convert.ToInt64(idSolicita);
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
