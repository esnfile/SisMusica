using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.acessos;

namespace DAL.acessos
{
    public class DAL_rotinas
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idRotina = null;

        #endregion

        #region Strings Sql da tabela Rotinas

        //string de insert na tabela Rotinas
        private string strInsert = "INSERT INTO Rotinas (CodRotina, CodPrograma, NivelRotina, DescRotina, DescSeg, DescInd, LiberaAcesso) " +
"VALUES (@CodRotina, @CodPrograma, @NivelRotina, @DescRotina, @DescSeg, @DescInd, @LiberaAcesso) ";

        //string de update na tabela Rotinas
        private string strUpdate = "UPDATE Rotinas SET CodPrograma = @CodPrograma, NivelRotina = @NivelRotina, DescRotina = @DescRotina, " +
"DescSeg = @DescSeg, DescInd = @ DescInd, LiberaAcesso = @LiberaAcesso " +
"WHERE CodRotina = @CodRotina ";

        //string de delete na tabela Rotinas
        private string strDelete = "DELETE FROM Rotinas WHERE CodRotina = @CodRotina ";

        //string de select na tabela Rotinas
        private string strSelect = "SELECT R.CodRotina, R.CodPrograma, R.NivelRotina, R.DescRotina, R.DescSeg, R.DescInd, R.LiberaAcesso, " +
"P.DescPrograma, P.NivelProg, P.CodSubModulo, S.DescSubModulo, S.CodModulo, S.NivelSub, M.DescModulo, M.NivelMod " +
"FROM Rotinas AS R " +
"LEFT OUTER JOIN Programas AS P ON R.CodPrograma = P.CodPrograma " +
"LEFT OUTER JOIN SubModulos AS S ON P.CodSubModulo = S.CodSubModulo " +
"LEFT OUTER JOIN Modulos AS M ON S.CodModulo = M.CodModulo ";

        //string que retorna o próximo Id da tabela Rotinas
        private string strId = "SELECT MAX (CodRotina) FROM Rotinas ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Rotinas
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_rotinas objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Rotinas
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRotina", Convert.ToInt32(objEnt.CodRotina)));
                objParam.Add(new SqlParameter("@CodPrograma", string.IsNullOrEmpty(objEnt.CodPrograma) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodPrograma) as object));
                objParam.Add(new SqlParameter("@NivelRotina", string.IsNullOrEmpty(objEnt.NivelRotina) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelRotina) as object));
                objParam.Add(new SqlParameter("@DescRotina", string.IsNullOrEmpty(objEnt.DescRotina) ? DBNull.Value as object : objEnt.DescRotina as object));
                objParam.Add(new SqlParameter("@DescSeg", string.IsNullOrEmpty(objEnt.DescSeg) ? DBNull.Value as object : objEnt.DescSeg as object));
                objParam.Add(new SqlParameter("@DescInd", string.IsNullOrEmpty(objEnt.DescInd) ? DBNull.Value as object : objEnt.DescInd as object));
                objParam.Add(new SqlParameter("@LiberaAcesso", string.IsNullOrEmpty(objEnt.LiberaAcesso) ? DBNull.Value as object : objEnt.LiberaAcesso as object));
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
        /// Função que faz INSERT na Tabela Rotinas
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_rotinas objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Rotinas
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRotina", Convert.ToInt16(objEnt.CodRotina)));
                objParam.Add(new SqlParameter("@CodPrograma", string.IsNullOrEmpty(objEnt.CodPrograma) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodPrograma) as object));
                objParam.Add(new SqlParameter("@NivelRotina", string.IsNullOrEmpty(objEnt.NivelRotina) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelRotina) as object));
                objParam.Add(new SqlParameter("@DescRotina", string.IsNullOrEmpty(objEnt.DescRotina) ? DBNull.Value as object : objEnt.DescRotina as object));
                objParam.Add(new SqlParameter("@DescSeg", string.IsNullOrEmpty(objEnt.DescSeg) ? DBNull.Value as object : objEnt.DescSeg as object));
                objParam.Add(new SqlParameter("@DescInd", string.IsNullOrEmpty(objEnt.DescInd) ? DBNull.Value as object : objEnt.DescInd as object));
                objParam.Add(new SqlParameter("@LiberaAcesso", string.IsNullOrEmpty(objEnt.LiberaAcesso) ? DBNull.Value as object : objEnt.LiberaAcesso as object));
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
        /// Função que faz DELETE na Tabela Rotinas
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_rotinas objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Rotinas
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodRotina", Convert.ToInt16(objEnt.CodRotina)));
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
        /// Função que retorna os Registros da tabela Rotinas, pesquisado pelo Código
        /// </summary>
        /// <param name="CodRotina"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodRotina)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodRotina))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRotina", CodRotina));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY R.CodRotina ", objParam, "Rotinas");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRotina", CodRotina));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE R.CodRotina = @CodRotina ORDER BY R.CodRotina", objParam, "Rotinas");
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
        /// Função que retorna os Registros da tabela Rotinas, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescRotina"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescRotina)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescRotina", DescRotina));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.DescRotina LIKE @DescRotina ORDER BY R.DescRotina ", objParam, "Rotinas");
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
        /// Função que retorna os Registros da tabela Rotinas, pesquisado pelo NivelRotina
        /// </summary>
        /// <param name="NivelRotina"></param>
        /// <returns></returns>
        public DataTable buscarNivel(string NivelRotina)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@NivelRotina", NivelRotina));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.NivelRotina = @NivelRotina ORDER BY R.DescRotina ", objParam, "Rotinas");
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
        /// Função que retorna os Registros da tabela Rotinas, pesquisado pelo CodPrograma
        /// </summary>
        /// <param name="CodPrograma"></param>
        /// <returns></returns>
        public DataTable buscarPrograma(string CodPrograma)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPrograma", CodPrograma));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE R.CodPrograma = @CodPrograma ORDER BY R.DescRotina ", objParam, "Rotinas");
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
        public Int32 retornaId()
        {
            try
            {
                idRotina = objAcessa.retornarId(strId);
                return Convert.ToInt32(idRotina);
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
