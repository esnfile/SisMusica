using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.instrumentos;

namespace DAL.instrumentos
{
    public class DAL_instrumento
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idInstrumento = null;

        #endregion

        #region Strings Sql da tabela Instrumentos

        //string de insert na tabela Instrumentos
        private string strInsert = "INSERT INTO Instrumentos (CodInstrumento, DescInstrumento, CodFamilia, NotaAfina, " +
"PosAfina, NotaEfeito, PosEfeito, Obs, TesNotaGrave, TesNotaAguda, Situacao, Ordem) " +
"VALUES (@CodInstrumento, @DescInstrumento, @CodFamilia, @NotaAfina, @PosAfina, " +
"@NotaEfeito, @PosEfeito, @Obs, @TesNotaGrave, @TesNotaAguda, @Situacao, @Ordem) ";

        //string de update na tabela Instrumentos
        private string strUpdate = "UPDATE Instrumentos SET DescInstrumento = @DescInstrumento, CodFamilia = @CodFamilia, " +
"NotaAfina = @NotaAfina, PosAfina = @PosAfina, " +
"NotaEfeito  = @NotaEfeito, PosEfeito = @PosEfeito, Obs = @Obs, TesNotaGrave = @TesNotaGrave, TesNotaAguda = @TesNotaAguda, " +
"Situacao = @Situacao, Ordem = @Ordem  " +
"WHERE CodInstrumento = @CodInstrumento ";

        //string de delete na tabela Instrumentos
        private string strDelete = "DELETE FROM Instrumentos WHERE CodInstrumento = @CodInstrumento ";

        //string de select na tabela Instrumentos
        private string strSelect = "SELECT I.CodInstrumento, I.DescInstrumento, I.CodFamilia, " +
"I.NotaAfina, I.PosAfina, I.NotaEfeito, I.PosEfeito, I.Obs, I.TesNotaGrave, I.TesNotaAguda, " +
"I.Situacao, I.Ordem, F.DescFamilia, F.Rjm, F.Culto, F.MeiaHora, F.Oficial, F.Troca " +
"FROM Instrumentos AS I " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string que retorna o próximo Id da tabela Instrumentos
        private string strId = "SELECT MAX (CodInstrumento) FROM Instrumentos ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Instrumentos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_instrumento objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Instrumentos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt16(objEnt.CodInstrumento)));
                objParam.Add(new SqlParameter("@DescInstrumento", string.IsNullOrEmpty(objEnt.DescInstrumento) ? DBNull.Value as object : objEnt.DescInstrumento as object));
                objParam.Add(new SqlParameter("@CodFamilia", string.IsNullOrEmpty(objEnt.CodFamilia) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodFamilia) as object));
                objParam.Add(new SqlParameter("@NotaAfina", string.IsNullOrEmpty(objEnt.NotaAfina) ? DBNull.Value as object : objEnt.NotaAfina as object));
                objParam.Add(new SqlParameter("@PosAfina", string.IsNullOrEmpty(objEnt.PosAfina) ? DBNull.Value as object : objEnt.PosAfina as object));
                objParam.Add(new SqlParameter("@NotaEfeito", string.IsNullOrEmpty(objEnt.NotaEfeito) ? DBNull.Value as object : objEnt.NotaEfeito as object));
                objParam.Add(new SqlParameter("@PosEfeito", string.IsNullOrEmpty(objEnt.PosEfeito) ? DBNull.Value as object : objEnt.PosEfeito as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@TesNotaGrave", string.IsNullOrEmpty(objEnt.TesNotaGrave) ? DBNull.Value as object : objEnt.TesNotaGrave as object));
                objParam.Add(new SqlParameter("@TesNotaAguda", string.IsNullOrEmpty(objEnt.TesNotaAguda) ? DBNull.Value as object : objEnt.TesNotaAguda as object));
                objParam.Add(new SqlParameter("@Situacao", string.IsNullOrEmpty(objEnt.Situacao) ? DBNull.Value as object : objEnt.Situacao as object));
                objParam.Add(new SqlParameter("@Ordem", string.IsNullOrEmpty(objEnt.Ordem) ? DBNull.Value as object : Convert.ToInt16(objEnt.Ordem) as object));

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
        /// Função que faz INSERT na Tabela Instrumentos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_instrumento objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Instrumentos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt16(objEnt.CodInstrumento)));
                objParam.Add(new SqlParameter("@DescInstrumento", string.IsNullOrEmpty(objEnt.DescInstrumento) ? DBNull.Value as object : objEnt.DescInstrumento as object));
                objParam.Add(new SqlParameter("@CodFamilia", string.IsNullOrEmpty(objEnt.CodFamilia) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodFamilia) as object));
                objParam.Add(new SqlParameter("@NotaAfina", string.IsNullOrEmpty(objEnt.NotaAfina) ? DBNull.Value as object : objEnt.NotaAfina as object));
                objParam.Add(new SqlParameter("@PosAfina", string.IsNullOrEmpty(objEnt.PosAfina) ? DBNull.Value as object : objEnt.PosAfina as object));
                objParam.Add(new SqlParameter("@NotaEfeito", string.IsNullOrEmpty(objEnt.NotaEfeito) ? DBNull.Value as object : objEnt.NotaEfeito as object));
                objParam.Add(new SqlParameter("@PosEfeito", string.IsNullOrEmpty(objEnt.PosEfeito) ? DBNull.Value as object : objEnt.PosEfeito as object));
                objParam.Add(new SqlParameter("@Obs", string.IsNullOrEmpty(objEnt.Obs) ? DBNull.Value as object : objEnt.Obs as object));
                objParam.Add(new SqlParameter("@TesNotaGrave", string.IsNullOrEmpty(objEnt.TesNotaGrave) ? DBNull.Value as object : objEnt.TesNotaGrave as object));
                objParam.Add(new SqlParameter("@TesNotaAguda", string.IsNullOrEmpty(objEnt.TesNotaAguda) ? DBNull.Value as object : objEnt.TesNotaAguda as object));
                objParam.Add(new SqlParameter("@Situacao", string.IsNullOrEmpty(objEnt.Situacao) ? DBNull.Value as object : objEnt.Situacao as object));
                objParam.Add(new SqlParameter("@Ordem", string.IsNullOrEmpty(objEnt.Ordem) ? DBNull.Value as object : Convert.ToInt16(objEnt.Ordem) as object));

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
        /// Função que faz DELETE na Tabela Instrumentos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_instrumento objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Instrumentos
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt32(objEnt.CodInstrumento)));
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pelo Código
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodInstrumento)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodInstrumento))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE I.CodInstrumento = @CodInstrumento ORDER BY I.CodFamilia, I.Ordem", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pelo Código e Situação
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodInstrumento, string Situacao)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodInstrumento))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                    objParam.Add(new SqlParameter("@Situacao", Situacao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE I.Situacao = @Situacao ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                    objParam.Add(new SqlParameter("@Situacao", Situacao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE I.CodInstrumento = @CodInstrumento AND I.Situacao = @Situacao ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pela Descrição
        /// </summary>
        /// <param name="DescInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescInstrumento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescInstrumento", DescInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE I.DescInstrumento LIKE @DescInstrumento ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pela Descrição e Situação
        /// </summary>
        /// <param name="DescInstrumento"></param>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescInstrumento, string Situacao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescInstrumento", DescInstrumento));
                objParam.Add(new SqlParameter("@Situacao", Situacao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE I.DescInstrumento LIKE @DescInstrumento AND I.Situacao = @Situacao ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pela Situacao
        /// </summary>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public DataTable buscarSituacao(string Situacao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Situacao", Situacao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE I.Situacao LIKE @Situacao ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pela Familia
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>
        public DataTable buscarFamilia(string CodFamilia)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFamilia", CodFamilia));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE I.CodFamilia = @CodFamilia ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pela Familia e Situação
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public DataTable buscarFamilia(string CodFamilia, string Situacao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFamilia", CodFamilia));
                objParam.Add(new SqlParameter("@Situacao", Situacao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE I.CodFamilia = @CodFamilia AND I.Situacao = @Situacao ORDER BY I.CodFamilia, I.Ordem ", objParam, "Instrumentos");
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
        public Int16 retornaId()
        {
            try
            {
                idInstrumento = objAcessa.retornarId(strId);
                return Convert.ToInt16(idInstrumento);
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
