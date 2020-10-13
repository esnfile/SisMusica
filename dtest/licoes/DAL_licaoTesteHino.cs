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
    public class DAL_licaoTesteHino
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idLicao = null;

        #endregion

        #region Strings Sql da tabela LicaoTesteHino

        //string de insert na tabela LicaoTesteHino
        private string strInsert = "INSERT INTO LicaoTesteHino (CodLicaoHino, CodInstrumento, AplicaEm, CodHinario, Hino) " +
"VALUES (@CodLicaoHino, @CodInstrumento, @AplicaEm, @CodHinario, @Hino) ";

        //string de update na tabela LicaoTesteHino
        private string strUpdate = "UPDATE LicaoTesteHino SET CodInstrumento = @CodInstrumento, AplicaEm = @AplicaEm, " +
"CodHinario = @CodHinario, Hino = @Hino " +
"WHERE CodLicaoHino = @CodLicaoHino ";

        //string de delete na tabela LicaoTesteHino
        private string strDelete = "DELETE FROM LicaoTesteHino WHERE CodLicaoHino = @CodLicaoHino ";

        //string de select na tabela LicaoTesteHino
        private string strSelect = "SELECT LH.CodLicaoHino, LH.CodInstrumento, LH.AplicaEm, LH.CodHinario, LH.Hino, " +
"I.DescInstrumento, H. DescHinario, H.CodTonalidade, T.Nota, T.Alteracoes, T.DescTonalidade " +
"FROM LicaoTesteHino AS LH " +
"LEFT OUTER JOIN Instrumentos AS I ON LH.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Hinario AS H ON LH.CodHinario = H.CodHinario " +
"LEFT OUTER JOIN Tonalidade AS T ON H.CodTonalidade = T.CodTonalidade ";

        //string que retorna o próximo Id da tabela LicaoTesteHino
        private string strId = "SELECT MAX (CodLicaoHino) FROM LicaoTesteHino ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE na Tabela LicaoTesteHino
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteHino objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                //se não possuir código, é feita a inclusao na tabela
                if (objEnt.CodLicaoHino.Equals(string.Empty))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoHino", retornaId()));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@CodHinario", string.IsNullOrEmpty(objEnt.CodHinario) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodHinario) as object));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm));
                    objParam.Add(new SqlParameter("@Hino", string.IsNullOrEmpty(objEnt.Hino) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hino)));

                    blnRetorno = objAcessa.executar(strInsert, objParam);

                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoHino", Convert.ToInt32(objEnt.CodLicaoHino)));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@CodHinario", string.IsNullOrEmpty(objEnt.CodHinario) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodHinario) as object));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm));
                    objParam.Add(new SqlParameter("@Hino", string.IsNullOrEmpty(objEnt.Hino) ? DBNull.Value as object : Convert.ToInt16(objEnt.Hino)));

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
        public bool excluir(MOD_licaoTesteHino objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Metodo Instrumento
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela Metodo Instrumento
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!objEnt.CodLicaoHino.Equals(string.Empty))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoHino", Convert.ToInt32(objEnt.CodLicaoHino) as object));

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
        /// Função que retorna os Registros da tabela LicaoTesteHino, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarLicaoHino(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LH.CodInstrumento = @CodInstrumento ORDER BY LH.AplicaEm, LH.Hino ", objParam, "LicaoTesteHino");
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
        /// Função que retorna os Registros da tabela LicaoTesteHino, pesquisado pelo Instrumento e o Hinário
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodHinario"></param>
        /// <returns></returns>
        public DataTable buscarLicaoHino(string CodInstrumento, string CodHinario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodHinario", CodHinario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LH.CodInstrumento = @CodInstrumento AND LH.CodHinario = @CodHinario ORDER BY LH.AplicaEm, LH.Hino ", objParam, "LicaoTesteHino");
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
        /// Função que retorna os Registros da tabela LicaoTesteHino, pesquisado pelo Instrumento e o Hinário
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodHinario"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarLicaoHino(string CodInstrumento, string CodHinario, string AplicaEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodHinario", CodHinario));
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LH.CodInstrumento = @CodInstrumento AND LH.CodHinario = @CodHinario AND LH.AplicaEm = @AplicaEm ORDER BY LH.AplicaEm, LH.Hino ", objParam, "LicaoTesteHino");
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
        /// Função que retorna os Registros da tabela LicaoTesteHino, pesquisado pelo Instrumento e o Hinário
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodHinario"></param>
        /// <returns></returns>
        public DataTable buscarLicaoDescHino(string CodInstrumento, string CodHinario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodHinario", CodHinario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LH.CodInstrumento = @CodInstrumento AND LH.CodHinario = @CodHinario ORDER BY LH.AplicaEm, LH.Hino ", objParam, "LicaoTesteHino");
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
