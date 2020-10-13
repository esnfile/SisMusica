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
    public class DAL_programas
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idPrograma = null;

        #endregion

        #region Strings Sql da tabela Programas

        //string de insert na tabela Programas
        private string strInsert = "INSERT INTO Programas (CodPrograma, CodSubModulo, DescPrograma, NivelProg) " +
"VALUES (@CodPrograma, @CodSubModulo, @DescPrograma, @NivelProg) ";

        //string de update na tabela Programas
        private string strUpdate = "UPDATE Programas SET CodSubModulo = @CodSubModulo, DescPrograma = @DescPrograma, NivelProg = @NivelProg " +
"WHERE CodPrograma = @CodPrograma ";

        //string de delete na tabela Programas
        private string strDelete = "DELETE FROM Programas WHERE CodPrograma = @CodPrograma ";

        //string de select na tabela Programas
        private string strSelect = "SELECT P.CodPrograma, P.CodSubModulo, P.DescPrograma, P.NivelProg, S.DescSubModulo, S.CodModulo, " +
"S.NivelSub, M.DescModulo, M.NivelMod " +
"FROM Programas AS P " +
"LEFT OUTER JOIN SubModulos AS S ON P.CodSubModulo = S.CodSubModulo " +
"LEFT OUTER JOIN Modulos AS M ON S.CodModulo = M.CodModulo ";

        //string que retorna o próximo Id da tabela Programas
        private string strId = "SELECT MAX (CodPrograma) FROM Programas ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Programas
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_programas objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Programas
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPrograma", Convert.ToInt16(objEnt.CodPrograma)));
                objParam.Add(new SqlParameter("@CodSubModulo", string.IsNullOrEmpty(objEnt.CodSubModulo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodSubModulo) as object));
                objParam.Add(new SqlParameter("@DescPrograma", string.IsNullOrEmpty(objEnt.DescPrograma) ? DBNull.Value as object : objEnt.DescPrograma as object));
                objParam.Add(new SqlParameter("@NivelProg", string.IsNullOrEmpty(objEnt.NivelProg) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelProg) as object));
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
        /// Função que faz INSERT na Tabela Programas
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_programas objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Programas
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPrograma", Convert.ToInt16(objEnt.CodPrograma)));
                objParam.Add(new SqlParameter("@CodSubModulo", string.IsNullOrEmpty(objEnt.CodSubModulo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodSubModulo) as object));
                objParam.Add(new SqlParameter("@DescPrograma", string.IsNullOrEmpty(objEnt.DescPrograma) ? DBNull.Value as object : objEnt.DescPrograma as object));
                objParam.Add(new SqlParameter("@NivelProg", string.IsNullOrEmpty(objEnt.NivelProg) ? DBNull.Value as object : Convert.ToDecimal(objEnt.NivelProg) as object));

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
        /// Função que faz DELETE na Tabela Programas
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_programas objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Programas
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPrograma", Convert.ToInt16(objEnt.CodPrograma)));
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
        /// Função que retorna os Registros da tabela Programas, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPrograma"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPrograma)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPrograma))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPrograma", CodPrograma));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodPrograma ", objParam, "Programas");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPrograma", CodPrograma));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPrograma = @CodPrograma ORDER BY P.CodPrograma", objParam, "Programas");
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
        /// Função que retorna os Registros da tabela Programas, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescPrograma"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescPrograma)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescPrograma", DescPrograma));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DescPrograma LIKE @DescPrograma ORDER BY P.DescPrograma ", objParam, "Programas");
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
        /// Função que retorna os Registros da tabela Programas, pesquisado pela Descricao
        /// </summary>
        /// <param name="CodSubModulo"></param>
        /// <param name="DescPrograma"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string CodSubModulo, string DescPrograma)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodSubModulo", CodSubModulo));
                objParam.Add(new SqlParameter("@DescPrograma", DescPrograma));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodSubModulo = @CodSubModulo AND P.DescPrograma LIKE @DescPrograma ORDER BY P.DescPrograma ", objParam, "Programas");
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
        /// Função que retorna os Registros da tabela Programas, pesquisado pelo NivelProg
        /// </summary>
        /// <param name="NivelProg"></param>
        /// <returns></returns>
        public DataTable buscarNivel(string NivelProg)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@NivelProg", NivelProg));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.NivelProg = @NivelProg ORDER BY P.DescPrograma ", objParam, "Programas");
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
        /// Função que retorna os Registros da tabela Programas, pesquisado pelo SubModulo
        /// </summary>
        /// <param name="CodSubModulo"></param>
        /// <returns></returns>
        public DataTable buscarSubModulo(string CodSubModulo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodSubModulo", CodSubModulo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodSubModulo = @CodSubModulo ORDER BY P.DescPrograma ", objParam, "Programas");
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
                idPrograma = objAcessa.retornarId(strId);
                return Convert.ToInt16(idPrograma);
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
