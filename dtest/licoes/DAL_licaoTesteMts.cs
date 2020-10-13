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
    public class DAL_licaoTesteMts
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idLicao = null;

        #endregion

        #region Strings Sql da tabela LicaoTesteMts

        //string de insert na tabela LicaoTesteMts
        private string strInsert = "INSERT INTO LicaoTesteMts (CodLicaoMts, CodMetMts, AplicaEm, ModuloMts, LicaoMts, TipoMts) " +
"VALUES (@CodLicaoMts, @CodMetMts, @AplicaEm, @ModuloMts, @LicaoMts, @TipoMts) ";

        //string de update na tabela LicaoTesteMts
        private string strUpdate = "UPDATE LicaoTesteMts SET CodMetMts = @CodMetMts, AplicaEm = @AplicaEm, " +
"ModuloMts = @ModuloMts, LicaoMts = @LicaoMts, TipoMts = @TipoMts " +
"WHERE CodLicaoMts = @CodLicaoMts ";


        //string de delete na tabela LicaoTesteMts
        private string strDelete = "DELETE FROM LicaoTesteMts WHERE CodLicaoMts = @CodLicaoMts ";

        //string de select na tabela LicaoTesteMts
        private string strSelect = "SELECT LM.CodLicaoMts, LM.CodMetMts, LM.AplicaEm, LM.ModuloMts, LM.LicaoMts, LM.TipoMts, " +
"M.DescMetodo, M.Compositor, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase " +
"FROM LicaoTesteMts AS LM " +
"LEFT OUTER JOIN Metodos AS M ON LM.CodMetMts = M.CodMetodo ";

        //string que retorna o próximo Id da tabela LicaoTesteMts
        private string strId = "SELECT MAX (CodLicaoMts) FROM LicaoTesteMts ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE na Tabela LicaoTesteMts
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteMts objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                //se não possuir código, é feita a inclusao na tabela
                if (objEnt.CodLicaoMts.Equals(string.Empty))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoMts", retornaId()));
                    objParam.Add(new SqlParameter("@CodMetMts", string.IsNullOrEmpty(objEnt.CodMetMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetMts) as object));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm as object));
                    objParam.Add(new SqlParameter("@ModuloMts", string.IsNullOrEmpty(objEnt.ModuloMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.ModuloMts) as object));
                    objParam.Add(new SqlParameter("@LicaoMts", string.IsNullOrEmpty(objEnt.LicaoMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.LicaoMts) as object));
                    objParam.Add(new SqlParameter("@TipoMts", string.IsNullOrEmpty(objEnt.TipoMts) ? DBNull.Value as object : objEnt.TipoMts as object));

                    blnRetorno = objAcessa.executar(strInsert, objParam);

                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoMts", Convert.ToInt32(objEnt.CodLicaoMts)));
                    objParam.Add(new SqlParameter("@CodMetMts", string.IsNullOrEmpty(objEnt.CodMetMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetMts) as object));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm as object));
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
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que faz DELETE na Tabela LicaoTesteMts
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_licaoTesteMts objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela LicaoTesteMts
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela LicaoTesteMts
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!objEnt.CodLicaoMts.Equals(string.Empty))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoMts", Convert.ToInt32(objEnt.CodLicaoMts) as object));

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
        /// Função que retorna os Registros da tabela LicaoTesteMts, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodMetMts"></param>
        /// <returns></returns>
        public DataTable buscarLicaoMts(string CodMetMts)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodMetMts", CodMetMts));

                if (string.IsNullOrEmpty(CodMetMts))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY LM.AplicaEm, M.DescMetodo, LM.ModuloMts ", objParam, "LicaoTesteMts");
                }
                else
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE LM.CodMetMts = @CodMetMts ORDER BY LM.AplicaEm, M.DescMetodo, LM.ModuloMts ", objParam, "LicaoTesteMts");
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
        /// Função que retorna os Registros da tabela LicaoTesteMts, pesquisado pela Aplicação e o Metodo
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="CodMetMts"></param>
        /// <returns></returns>
        public DataTable buscarLicaoMts(string AplicaEm, string CodMetMts)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objParam.Add(new SqlParameter("@CodMetMts", CodMetMts));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LM.AplicaEm = @AplicaEm AND LM.CodMetMts = @CodMetMts ORDER BY LM.TipoMts, LM.ModuloMts ", objParam, "LicaoTesteMts");
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
        /// Função que retorna os Registros da tabela LicaoTesteMts, pesquisado pela Aplicação e o Metodo
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        ///<para>TipoMts: Solfejo ou Ritmo</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="CodMetMts"></param>
        /// <param name="TipoMts"></param>
        /// <returns></returns>
        public DataTable buscarLicaoMts(string AplicaEm, string CodMetMts, string TipoMts)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objParam.Add(new SqlParameter("@CodMetMts", CodMetMts));
                objParam.Add(new SqlParameter("@TipoMts", TipoMts));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LM.AplicaEm = @AplicaEm AND LM.CodMetMts = @CodMetMts AND LM.TipoMts = @TipoMts ORDER BY LM.TipoMts, LM.ModuloMts ", objParam, "LicaoTesteMts");
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
