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
    public class DAL_licaoTesteTeoria
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idLicao = null;

        #endregion

        #region Strings Sql da tabela LicaoTesteTeoria

        //string de insert na tabela LicaoTesteTeoria
        private string strInsert = "INSERT INTO LicaoTesteTeoria (CodLicaoTeoria, AplicaEm, CodTeoria) " +
"VALUES (@CodLicaoTeoria, @AplicaEm, @CodTeoria) ";

        //string de update na tabela LicaoTesteTeoria
        private string strUpdate = "UPDATE LicaoTesteTeoria SET AplicaEm = @AplicaEm, CodTeoria = @CodTeoria " +
"WHERE CodLicaoTeoria = @CodLicaoTeoria ";


        //string de delete na tabela LicaoTesteTeoria
        private string strDelete = "DELETE FROM LicaoTesteTeoria WHERE CodLicaoTeoria = @CodLicaoTeoria ";

        //string de select na tabela LicaoTesteTeoria
        private string strSelect = "SELECT LT.CodLicaoTeoria, LT.AplicaEm, LT.CodTeoria, " +
"T.DescTeoria, T.TipoCadastro, T.CodModuloMts, T.CodFaseMts, T.Nivel, T.Paginas, M.DescModulo, F.DescFase " +
"FROM LicaoTesteTeoria AS LT " +
"LEFT OUTER JOIN Teoria AS T ON LT.CodTeoria = T.CodTeoria " +
"LEFT OUTER JOIN MtsModulo AS M ON T.CodModuloMts = M.CodModuloMts " +
"LEFT OUTER JOIN MtsFase AS F ON T.CodFaseMts = F.CodFaseMts ";

        //string que retorna o próximo Id da tabela LicaoTesteTeoria
        private string strId = "SELECT MAX (CodLicaoTeoria) FROM LicaoTesteTeoria ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE na Tabela LicaoTesteTeoria
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteTeoria objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                //se não possuir código, é feita a inclusao na tabela
                if (objEnt.CodLicaoTeoria.Equals(string.Empty))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoTeoria", retornaId()));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm as object));
                    objParam.Add(new SqlParameter("@CodTeoria", string.IsNullOrEmpty(objEnt.CodTeoria) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTeoria) as object));

                    blnRetorno = objAcessa.executar(strInsert, objParam);

                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoTeoria", Convert.ToInt32(objEnt.CodLicaoTeoria) as object));
                    objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm as object));
                    objParam.Add(new SqlParameter("@CodTeoria", string.IsNullOrEmpty(objEnt.CodTeoria) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodTeoria) as object));

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
        /// Função que faz DELETE na LicaoTesteTeoria
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_licaoTesteTeoria objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //LicaoTesteTeoria
                bool blnRetorno = true;

                //Declara a lista de parametros da LicaoTesteTeoria
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!objEnt.CodLicaoTeoria.Equals(string.Empty))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodLicaoTeoria", Convert.ToInt32(objEnt.CodLicaoTeoria) as object));

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
        /// Função que retorna os Registros da tabela LicaoTesteTeoria, pesquisado pelo CodTeoria
        /// </summary>
        /// <param name="CodTeoria"></param>
        /// <returns></returns>
        public DataTable buscarLicaoTeoria(string CodTeoria)
        {
            try
            {
                if (string.IsNullOrEmpty(CodTeoria))
                {
                    //declara a lista de parametros
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTeoria", CodTeoria));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY LT.AplicaEm, T.DescTeoria ", objParam, "LicaoTesteTeoria");
                }
                else
                {
                    //declara a lista de parametros
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTeoria", CodTeoria));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE LT.CodTeoria = @CodTeoria ORDER BY LT.AplicaEm, T.DescTeoria ", objParam, "LicaoTesteTeoria");
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
        /// Função que retorna os Registros da tabela LicaoTesteTeoria, pesquisado pela Aplicação e o Nivel
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="Nivel"></param>
        /// <returns></returns>
        public DataTable buscarLicaoTeoria(string Nivel, string AplicaEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objParam.Add(new SqlParameter("@Nivel", Nivel));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LT.AplicaEm = @AplicaEm AND T.Nivel = @Nivel ORDER BY LT.AplicaEm ", objParam, "LicaoTesteTeoria");
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
        /// Função que retorna os Registros da tabela LicaoTesteTeoria, pesquisado pelo Nivel, Aplicação e o Tipode Cadastro
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="Nivel"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public DataTable buscarLicaoTeoria(string Nivel, string AplicaEm, string TipoCadastro)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objParam.Add(new SqlParameter("@Nivel", Nivel));
                objParam.Add(new SqlParameter("@TipoCadastro", TipoCadastro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE LT.AplicaEm = @AplicaEm AND T.Nivel = @Nivel AND T.TipoCadastro = @TipoCadastro ORDER BY LT.AplicaEm ", objParam, "LicaoTesteTeoria");
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