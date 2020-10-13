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
    public class DAL_licaoTesteEscala
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idLicao = null;

        #endregion

        #region Strings Sql da tabela LicaoTesteEscala

        //string de insert na tabela LicaoTesteEscala
        private string strInsert = "INSERT INTO LicaoTesteEscala (CodLicaoEscala, CodInstrumento, AplicaEm, CodEscala) " +
"VALUES (@CodLicaoEscala, @CodInstrumento, @AplicaEm, @CodEscala) ";

        //string de update na tabela LicaoTesteEscala
        private string strUpdate = "UPDATE LicaoTesteEscala SET CodInstrumento = @CodInstrumento, AplicaEm = @AplicaEm, CodEscala = @CodEscala " +
"WHERE CodLicaoEscala = @CodLicaoEscala ";


        //string de delete na tabela LicaoTesteEscala
        private string strDelete = "DELETE FROM LicaoTesteEscala WHERE CodLicaoEscala = @CodLicaoEscala ";

        //string de select na tabela LicaoTesteEscala
        private string strSelect = "SELECT LE.CodLicaoEscala, LE.CodInstrumento, LE.AplicaEm, LE.CodEscala, " +
"I.DescInstrumento, E.DescEscala, E.Modelo, E.Tonica, E.Alteracoes, E.CodTipoEscala, T.DescTipo " +
"FROM LicaoTesteEscala AS LE " +
"LEFT OUTER JOIN Instrumentos AS I ON LE.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Escala AS E ON LE.CodEscala = E.CodEscala " +
"LEFT OUTER JOIN TipoEscala AS T ON E.CodTipoEscala = T.CodTipoEscala ";

        //        //string de select na tabela TipoEscala
        //        private string strSelectTipoEscala = "SELECT CodTipoEscala, DescTipo " +
        //"FROM TipoEscala " +
        //"WHERE CodTipoEscala IN(SELECT LE.CodLicaoEscala, LE.CodInstrumento, LE.AplicaEm, LE.CodEscala, " +
        //"E.CodTipoEscala " +
        //"FROM LicaoTesteEscala AS LE " +
        //"LEFT OUTER JOIN Escala AS E ON LE.CodEscala = E.CodEscala ";
        //string de select na tabela TipoEscala
        private string strSelectTipoEscala = "SELECT DISTINCT E.CodTipoEscala, T.DescTipo " +
"FROM LicaoTesteEscala AS LE " +
"LEFT OUTER JOIN Escala AS E ON LE.CodEscala = E.CodEscala " +
"LEFT OUTER JOIN TipoEscala AS T ON E.CodTipoEscala = T.CodTipoEscala ";

        //string que retorna o próximo Id da tabela LicaoTesteEscala
        private string strId = "SELECT MAX (CodLicaoEscala) FROM LicaoTesteEscala ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE na Tabela LicaoTesteEscala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteEscala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                //se não possuir código, é feita a inclusao na tabela
                if (objEnt.CodLicaoEscala.Equals(string.Empty))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoEscala", retornaId()));
                    objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt16(objEnt.CodInstrumento)));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm));
                    objParam.Add(new SqlParameter("@CodEscala", string.IsNullOrEmpty(objEnt.CodEscala) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodEscala) as object));

                    blnRetorno = objAcessa.executar(strInsert, objParam);

                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoEscala", Convert.ToInt32(objEnt.CodLicaoEscala)));
                    objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt16(objEnt.CodInstrumento)));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm));
                    objParam.Add(new SqlParameter("@CodEscala", string.IsNullOrEmpty(objEnt.CodEscala) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodEscala) as object));

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
        /// Função que faz DELETE na Tabela LicaoTesteEscala
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_licaoTesteEscala objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela LicaoTesteEscala
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela LicaoTesteEscala
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!objEnt.CodLicaoEscala.Equals(string.Empty))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoEscala", Convert.ToInt32(objEnt.CodLicaoEscala) as object));

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
        /// Função que retorna os Registros da tabela LicaoTesteEscala, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarLicaoEscala(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LE.CodInstrumento = @CodInstrumento ORDER BY LE.AplicaEm, E.DescEscala ", objParam, "LicaoTesteEscala");
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
        /// Função que retorna os Registros da tabela LicaoTesteEscala, pesquisado pelo Instrumento e o Tipo de Escala
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodTipoEscala"></param>
        /// <returns></returns>
        public DataTable buscarLicaoEscala(string CodInstrumento, string CodTipoEscala)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodTipoEscala", CodTipoEscala));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LE.CodInstrumento = @CodInstrumento AND E.CodTipoEscala = @CodTipoEscala ORDER BY LE.AplicaEm ", objParam, "LicaoTesteEscala");
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
        /// Função que retorna os Registros da tabela LicaoTesteEscala, pesquisado pelo Instrumento e o Tipo de Escala
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodTipoEscala"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarLicaoEscala(string CodInstrumento, string CodTipoEscala, string AplicaEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodTipoEscala", CodTipoEscala));
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LE.CodInstrumento = @CodInstrumento AND LE.AplicaEm = @AplicaEm AND E.CodTipoEscala = @CodTipoEscala ORDER BY LE.AplicaEm ", objParam, "LicaoTesteEscala");
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
        /// Função que retorna os Registros da tabela LicaoTesteEscala, pesquisado pelo Instrumento e a escala
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="DescEscala"></param>
        /// <returns></returns>
        public DataTable buscarLicaoDescEscala(string CodInstrumento, string DescEscala)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@DescEscala", DescEscala));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LE.CodInstrumento = @CodInstrumento AND E.DescEscala LIKE @DescEscala ORDER BY LE.AplicaEm ", objParam, "LicaoTesteEscala");
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
        /// Função que retorna os Registros do Tipo de Escala, pesquisado pelo Instrumento e AplicaEm
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarLicaoTipoEscala(string CodInstrumento, string AplicaEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objDtb = objAcessa.retornaDados(strSelectTipoEscala + "WHERE LE.CodInstrumento = @CodInstrumento AND LE.AplicaEm = @AplicaEm ORDER BY E.CodTipoEscala ", objParam, "LicaoTesteEscala");
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
