using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using DAL.Acessa;
using ENT.Log;
using ENT.acessos;

namespace DAL.acessos
{
    public class DAL_acessos
    {

        #region declarações
        //classe que acessa o banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idAcesso = null;

        #endregion

        #region Strings Sql da tabela Acessos

        //string de insert na tabela Acessos
        private string strInsertAcesso = "INSERT INTO Acessos (CodAcesso, CodUsuario, CodRotina) " +
    "VALUES (@CodAcesso, @CodUsuario, @CodRotina)";

        //string de delete na tabela Acessos
        private string strDeleteAcesso = "DELETE FROM Acessos WHERE CodAcesso = @CodAcesso ";

        //string de select na tabela Acessos
        private string strSelectAcesso = "SELECT A.CodAcesso, A.CodUsuario, A.CodRotina, U.CodPessoa, U.Usuario, U.Supervisor, " +
"PS.Nome, R.DescRotina, R.NivelRotina, R.DescSeg, R.DescInd, R.CodPrograma, P.DescPrograma, P.CodSubModulo, S.DescSubModulo, S.CodModulo, M.DescModulo " +
    "FROM Acessos AS A " +
    "LEFT OUTER JOIN Usuario AS U ON A.CodUsuario = U.CodUsuario " +
    "LEFT OUTER JOIN Pessoa AS PS ON U.CodPessoa = PS.CodPessoa " +
    "LEFT OUTER JOIN Rotinas AS R ON A.CodRotina = R.CodRotina " +
    "LEFT OUTER JOIN Programas AS P ON R.CodPrograma = P.CodPrograma " +
    "LEFT OUTER JOIN SubModulos AS S ON P.CodSubModulo = S.CodSubModulo " +
    "LEFT OUTER JOIN Modulos AS M ON S.CodModulo = M.CodModulo ";

        //string para retornar as rotinas que não estão liberadas para acesso
        private string strSelectRotina = "SELECT R.CodRotina, R.DescRotina, R.NivelRotina, R.DescSeg, R.DescInd, R.CodPrograma, P.DescPrograma, P.CodSubModulo, S.DescSubModulo, S.CodModulo, M.DescModulo " +
    "FROM Rotinas AS R " +
    "LEFT OUTER JOIN Programas AS P ON R.CodPrograma = P.CodPrograma " +
    "LEFT OUTER JOIN SubModulos AS S ON P.CodSubModulo = S.CodSubModulo " +
    "LEFT OUTER JOIN Modulos AS M ON S.CodModulo = M.CodModulo " +
    "WHERE R.CodRotina NOT IN(SELECT A.CodRotina FROM Acessos AS A ";

        //string que retorna o próximo Id da tabela Acessos
        private string strIdAces = "SELECT MAX (CodAcesso) FROM Acessos ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE E DELETE na Tabela Acessos
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_acessos objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Acessos
                bool blnRetornoAcesso = true;

                //Declara a lista de parametros da tabela Acessos
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para Inserido ou Alteração ou vai para Exclusão
                if (objEnt.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt.CodAcesso).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodAcesso", retornaId()));
                        objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                        objParam.Add(new SqlParameter("@CodRotina", string.IsNullOrEmpty(objEnt.CodRotina) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRotina) as object));

                        blnRetornoAcesso = objAcessa.executar(strInsertAcesso, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt.CodAcesso).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodAcesso", Convert.ToInt64(objEnt.CodAcesso)));

                        blnRetornoAcesso = objAcessa.executar(strDeleteAcesso, objParam);
                    }
                }
                //retorna o blnRetorno da tabela principal
                return blnRetornoAcesso;
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
        /// Função que retorna os Registros da tabela Acessos, pesquisado pelo CodUsuario e CodRotina
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRotina"></param>
        /// <returns></returns>
        public DataTable buscarCodAcesso(string CodUsuario, string CodRotina)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objParam.Add(new SqlParameter("@CodRotina", CodRotina));
                objDtb = objAcessa.retornaDados(strSelectAcesso + "WHERE A.CodUsuario = @CodUsuario AND A.CodRotina = @CodRotina ORDER BY M.DescModulo, S.DescSubModulo, P.DescPrograma, R.DescRotina ", objParam, "Acessos");
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
        /// Função que retorna os Registros da tabela Acessos, pesquisado pelo CodUsuario e CodPrograma
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodPrograma"></param>
        /// <returns></returns>
        public DataTable buscarUsuAcessoProg(string CodUsuario, string CodPrograma)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objParam.Add(new SqlParameter("@CodPrograma", CodPrograma));
                objDtb = objAcessa.retornaDados(strSelectAcesso + "WHERE A.CodUsuario = @CodUsuario AND R.CodPrograma = @CodPrograma ORDER BY R.DescRotina ", objParam, "Acessos");
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
        /// Função que retorna os Registros da tabela Acessos, pesquisado pelo CodUsuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarUsuAcesso(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelectAcesso + "WHERE A.CodUsuario = @CodUsuario ORDER BY M.DescModulo, S.DescSubModulo, P.DescPrograma, R.DescRotina ", objParam, "Acessos");
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
        /// Função que retorna os Registros da tabela Acessos, pesquisado pelo CodRotina
        /// </summary>
        /// <param name="CodRotina"></param>
        /// <returns></returns>
        public DataTable buscarRotinaAcesso(string CodRotina)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRotina", CodRotina));
                objDtb = objAcessa.retornaDados(strSelectAcesso + "WHERE A.CodRotina = @CodRotina ", objParam, "Acessos");
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
        /// Função que retorna os Registros da tabela Rotinas, pesquisado pelo CodUsuario.*\
        /// Essa Consulta retorna as Rotinas que não estão na Tabela Acessos
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarRotinas(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros da tabela Rotinas
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelectRotina + "WHERE A.CodUsuario = @CodUsuario) ORDER BY M.DescModulo, S.DescSubModulo, P.DescPrograma, R.DescRotina ", objParam, "Rotina");
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
                idAcesso = objAcessa.retornarId(strIdAces);
                return Convert.ToInt64(idAcesso);
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
