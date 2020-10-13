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
    public class DAL_usuarioRegiao
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idUsuarioRegiao = null;

        #endregion

        #region Strings Sql da tabela UsuarioRegiao

        //string de insert na tabela UsuarioRegiao
        private string strInsert = "INSERT INTO UsuarioRegiao (CodUsuarioRegiao, CodUsuario, CodRegiao) " +
"VALUES (@CodUsuarioRegiao, @CodUsuario, @CodRegiao) ";

//        //string de update na tabela UsuarioRegiao
//        private string strUpdate = "UPDATE UsuarioRegiao SET CodUsuario = @CodUsuario, CodRegiao = @CodRegiao " +
//"WHERE CodUsuarioRegiao = @CodUsuarioRegiao ";

        //string de delete na tabela UsuarioRegiao
        private string strDelete = "DELETE FROM UsuarioRegiao WHERE CodUsuarioRegiao = @CodUsuarioRegiao ";

        //string de select na tabela UsuarioRegiao
        private string strSelect = "SELECT UR.CodUsuarioRegiao, UR.CodUsuario, UR.CodRegiao, U.CodPessoa, U.Usuario, " +
"P.Nome, R.Codigo, R.Descricao, R.CodRegional, RG.Descricao AS DescRegional " +
"FROM UsuarioRegiao AS UR " +
"LEFT OUTER JOIN Usuario AS U ON UR.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON UR.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Regional AS RG ON R.CodRegional = RG.CodRegional ";

        //string de select na tabela CCB
        private string strSelectRegiao = "SELECT R.CodRegiao, R.Codigo, R.Descricao, R.CodRegional, RG.Descricao AS DescRegional " +
"FROM RegiaoAtuacao AS R " +
"LEFT OUTER JOIN Regional AS RG ON R.CodRegional = RG.CodRegional " +
"WHERE R.CodRegiao NOT IN (SELECT CodRegiao FROM UsuarioRegiao ";

        //string que retorna o próximo Id da tabela UsuarioRegiao
        private string strId = "SELECT MAX (CodUsuarioRegiao) FROM UsuarioRegiao ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base
        
        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela UsuarioRegiao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_usuarioRegiao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela UsuarioRegiao
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela UsuarioRegiao
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt.CodUsuarioRegiao).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodUsuarioRegiao", retornaId()));
                        objParam.Add(new SqlParameter("@CodUsuario", Convert.ToInt64(objEnt.CodUsuario)));
                        objParam.Add(new SqlParameter("@CodRegiao", string.IsNullOrEmpty(objEnt.CodRegiao) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRegiao) as object));

                        blnRetorno = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt.CodUsuarioRegiao).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodUsuarioRegiao", Convert.ToInt64(objEnt.CodUsuarioRegiao)));

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

        #endregion

        #region Funções para buscar os dados e Preencher os Valores

        /// <summary>
        /// Função que retorna os Registros da tabela UsuarioRegiao, pesquisado pela Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioRegiao(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE UR.CodUsuario = @CodUsuario ORDER BY R.Descricao ", objParam, "UsuarioRegiao");
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
        /// Função que retorna os Registros da tabela UsuarioRegiao, pesquisado pela Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegional"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioRegiao(string CodUsuario, string CodRegional)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objParam.Add(new SqlParameter("@CodRegional", CodRegional));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE UR.CodUsuario = @CodUsuario AND R.CodRegional = @CodRegional ORDER BY R.Descricao ", objParam, "UsuarioRegiao");
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
        /// Função que retorna os Registros da tabela Regiao, pesquisado pelo CodRegiao.*\
        /// Essa Consulta retorna os valores que não estão na Tabela UsuarioRegiao
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelectRegiao + "WHERE CodUsuario = @CodUsuario) ORDER BY R.Descricao ", objParam, "RegiaoAtuacao");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo CodRegiao.*\
        /// Essa Consulta retorna os valores que não estão na Tabela UsuarioRegiao
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodUsuario, string CodRegiao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelectRegiao + "WHERE CodUsuario = @CodUsuario) AND R.CodRegiao IN(" + @CodRegiao + ") ORDER BY R.Descricao ", objParam, "RegiaoAtuacao");
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
        public Int32 retornaId()
        {
            try
            {
                idUsuarioRegiao = objAcessa.retornarId(strId);
                return Convert.ToInt32(idUsuarioRegiao);
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
