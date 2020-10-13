using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.licao;

namespace DAL.licao
{
    public class DAL_licaoTesteMet
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idLicao = null;

        #endregion

        #region Strings Sql da tabela LicaoTesteMet

        //string de insert na tabela LicaoTesteMet
        private string strInsert = "INSERT INTO LicaoTesteMet (CodLicaoMet, CodInstrumento, CodMetodo, AplicaEm, PaginaMet, LicaoMet, FaseMet) " +
"VALUES (@CodLicaoMet, @CodInstrumento, @CodMetodo, @AplicaEm, @PaginaMet, @LicaoMet, @FaseMet) ";

        //string de update na tabela LicaoTesteMet
        private string strUpdate = "UPDATE LicaoTesteMet SET CodInstrumento = @CodInstrumento, CodMetodo = @CodMetodo, AplicaEm = @AplicaEm, " +
"PaginaMet = @PaginaMet, LicaoMet = @LicaoMet, FaseMet = @FaseMet " +
"WHERE CodLicaoMet = @CodLicaoMet ";


        //string de delete na tabela LicaoTesteMet
        private string strDelete = "DELETE FROM LicaoTesteMet WHERE CodLicaoMet = @CodLicaoMet ";

        //string de select na tabela LicaoTesteMet
        private string strSelect = "SELECT LM.CodLicaoMet, LM.CodInstrumento, LM.CodMetodo, LM.AplicaEm, LM.PaginaMet, LM.LicaoMet, LM.FaseMet, " +
"I.DescInstrumento, I.CodFamilia, I.Situacao, I.Ordem, M.DescMetodo, M.Compositor, M.QtdePagina, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase " +
"FROM LicaoTesteMet AS LM " +
"LEFT OUTER JOIN Instrumentos AS I ON LM.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Metodos AS M ON LM.CodMetodo = M.CodMetodo ";

        //string que retorna o próximo Id da tabela LicaoTesteMet
        private string strId = "SELECT MAX (CodLicaoMet) FROM LicaoTesteMet ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE na Tabela LicaoTesteMet
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteMet objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Inscrição de Pessoas
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela Inscrição de Pessoas
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                //se não possuir código, é feita a inclusao na tabela
                if (objEnt.CodLicaoMet.Equals(string.Empty))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoMet", retornaId()));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm));
                    objParam.Add(new SqlParameter("@PaginaMet", string.IsNullOrEmpty(objEnt.PaginaMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.PaginaMet)));
                    objParam.Add(new SqlParameter("@LicaoMet", string.IsNullOrEmpty(objEnt.LicaoMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.LicaoMet)));
                    objParam.Add(new SqlParameter("@FaseMet", string.IsNullOrEmpty(objEnt.FaseMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.FaseMet)));

                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoMet", Convert.ToInt32(objEnt.CodLicaoMet)));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm));
                    objParam.Add(new SqlParameter("@PaginaMet", string.IsNullOrEmpty(objEnt.PaginaMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.PaginaMet)));
                    objParam.Add(new SqlParameter("@LicaoMet", string.IsNullOrEmpty(objEnt.LicaoMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.LicaoMet)));
                    objParam.Add(new SqlParameter("@FaseMet", string.IsNullOrEmpty(objEnt.FaseMet) ? DBNull.Value as object : Convert.ToInt16(objEnt.FaseMet)));

                    blnRetorno = objAcessa.executar(strUpdate, objParam);
                }

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
        /// Função que faz DELETE na Tabela Metodo Instrumento
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_licaoTesteMet objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Metodo Instrumento
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela Metodo Instrumento
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!objEnt.CodLicaoMet.Equals(string.Empty))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoMet", Convert.ToInt16(objEnt.CodLicaoMet)));

                    blnRetorno = objAcessa.executar(strDelete, objParam);
                }

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
        /// Função que retorna os Registros da tabela LicaoTesteMet, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarLicaoMet(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LM.CodInstrumento = @CodInstrumento ORDER BY LM.AplicaEm, M.DescMetodo, LM.PaginaMet ", objParam, "LicaoTesteMet");
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
        /// Função que retorna os Registros da tabela LicaoTesteMet, pesquisado pelo Instrumento e o Metodo
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarLicaoMet(string CodInstrumento, string CodMetodo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LM.CodInstrumento = @CodInstrumento AND LM.CodMetodo = @CodMetodo ORDER BY LM.AplicaEm, LM.PaginaMet ", objParam, "LicaoTesteMet");
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
        /// Função que retorna os Registros da tabela LicaoTesteMet, pesquisado pelo Instrumento e o Metodo
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodMetodo"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarLicaoMet(string CodInstrumento, string CodMetodo, string AplicaEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LM.CodInstrumento = @CodInstrumento AND LM.CodMetodo = @CodMetodo AND LM.AplicaEm = @AplicaEm ORDER BY LM.FaseMet, LM.PaginaMet, LM.LicaoMet ", objParam, "LicaoTesteMet");
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
        /// Função que retorna os Registros da tabela LicaoTesteMet, pesquisado pelo Instrumento e o Metodo
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="DescMetodo"></param>
        /// <returns></returns>
        public DataTable buscarLicaoDescMet(string CodInstrumento, string DescMetodo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@DescMetodo", DescMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LM.CodInstrumento = @CodInstrumento AND M.DescMetodo = @DescMetodo ORDER BY LM.AplicaEm, LM.PaginaMet ", objParam, "LicaoTesteMet");
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
        public int retornaId()
        {
            try
            {
                idLicao = objAcessa.retornarId(strId);
                return Convert.ToInt32(idLicao);
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
