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

namespace DAL.Usuario
{
    public class DAL_usuarioCCB
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idUsuarioCCB = null;

        #endregion

        #region Strings Sql da tabela UsuarioCCB

        //string de insert na tabela UsuarioCCB
        private string strInsert = "INSERT INTO UsuarioCCB (CodUsuarioCCB, CodUsuario, CodCCB) " +
"VALUES (@CodUsuarioCCB, @CodUsuario, @CodCCB) ";

//        //string de update na tabela UsuarioCCB
//        private string strUpdate = "UPDATE UsuarioCCB SET CodUsuario = @CodUsuario, CodCCB = @CodCCB " +
//"WHERE CodUsuarioCCB = @CodUsuarioCCB ";

        //string de delete na tabela UsuarioCCB
        private string strDelete = "DELETE FROM UsuarioCCB WHERE CodUsuarioCCB = @CodUsuarioCCB ";

        //string de delete na tabela UsuarioCCB
        private string strDeleteUsuario = "DELETE FROM UsuarioCCB WHERE CodUsuario = @CodUsuario ";

        //string de select na tabela UsuarioCCB
        private string strSelect = "SELECT UC.CodUsuarioCCB, UC.CodUsuario, UC.CodCCB, U.CodPessoa, U.Usuario, " +
"P.Nome, C.Codigo, C.Descricao, C.CodRegiao " +
"FROM UsuarioCCB AS UC " +
"LEFT OUTER JOIN Usuario AS U ON UC.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN CCB AS C ON UC.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string de select na tabela CCB
        private string strSelectCargo = "SELECT C.CodCCB, C.Codigo, C.Descricao, C.CodRegiao " +
"FROM CCB AS C " +
"WHERE C.CodCCB NOT IN (SELECT CodCCB FROM UsuarioCCB ";

        //string que retorna o próximo Id da tabela UsuarioCCB
        private string strId = "SELECT MAX (CodUsuarioCCB) FROM UsuarioCCB ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base
        
        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela UsuarioCCB
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_usuarioCCB objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela UsuarioCCB
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela UsuarioCCB
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt.Marcado.Equals(true))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodUsuarioCCB", retornaId()));
                    objParam.Add(new SqlParameter("@CodUsuario", Convert.ToInt64(objEnt.CodUsuario)));
                    objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCCB) as object));

                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    if (!Convert.ToInt64(objEnt.CodUsuarioCCB).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodUsuarioCCB", Convert.ToInt64(objEnt.CodUsuarioCCB)));

                        blnRetorno = objAcessa.executar(strDelete, objParam);
                    }
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
        /// Função que faz DELETE na Tabela UsuarioCCB pelo Usuario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool deleteUsuario(string CodUsuario)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela UsuarioCCB
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela UsuarioCCB
                List<SqlParameter> objParam = new List<SqlParameter>();

                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodUsuario", Convert.ToInt64(CodUsuario)));

                blnRetorno = objAcessa.executar(strDeleteUsuario, objParam);

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
        /// Função que retorna os Registros da tabela UsuarioCCB, pesquisado pela Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioCCB(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE UC.CodUsuario = @CodUsuario ORDER BY C.Descricao ", objParam, "UsuarioCCB");
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
        /// Função que retorna os Registros da tabela UsuarioCCB, pesquisado pela Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioCCB(string CodUsuario, string CodRegiao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE UC.CodUsuario = @CodUsuario AND C.CodRegiao IN(" + @CodRegiao + ") ORDER BY C.Descricao ", objParam, "UsuarioCCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo CodCCB.*\
        /// Essa Consulta retorna os valores que não estão na Tabela UsuarioCCB
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarCCBs(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelectCargo + "WHERE CodUsuario = @CodUsuario) ORDER BY C.Descricao ", objParam, "CCB");
                //instancia a lista
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo CodCCB.*\
        /// Essa Consulta retorna os valores que não estão na Tabela UsuarioCCB
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarCCBs(string CodUsuario, string CodRegiao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelectCargo + "WHERE CodUsuario = @CodUsuario) AND C.CodRegiao IN(" + @CodRegiao + ") ORDER BY C.Descricao ", objParam, "CCB");
                //instancia a lista
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
                idUsuarioCCB = objAcessa.retornarId(strId);
                return Convert.ToInt64(idUsuarioCCB);
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
