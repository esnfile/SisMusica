using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using DAL.Acessa;
using ENT.Log;
using ENT.acessos;

namespace DAL.Usuario
{
    public class DAL_usuario
    {

        #region declarações
        //classe que acessa o banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idUsuario = null;

        #endregion

        #region Strings Sql da tabela Usuario

        //string de insert na tabela Usuario
        private string strInsert = "INSERT INTO Usuario (CodUsuario, CodPessoa, Usuario, Senha, DataAlteraSenha, DataCadastro, Supervisor, Ativo, AlteraSenha) " +
"VALUES (@CodUsuario, @CodPessoa, @Usuario, @Senha, @DataAlteraSenha, @DataCadastro, @Supervisor, @Ativo, @AlteraSenha) ";

        //string de update na tabela Usuario
        private string strUpdate = "UPDATE Usuario SET CodPessoa = @CodPessoa, Usuario = @Usuario, Senha = @Senha, " +
"DataAlteraSenha = @DataAlteraSenha, DataCadastro = @DataCadastro, Supervisor = @Supervisor, Ativo = @Ativo, AlteraSenha = @AlteraSenha " +
"WHERE CodUsuario = @CodUsuario ";

        //string de update da senha na tabela Usuario
        private string strUpdateSenha = "UPDATE Usuario SET Senha = @Senha, DataAlteraSenha = @DataAlteraSenha, AlteraSenha = @AlteraSenha " +
"WHERE CodUsuario = @CodUsuario ";

        //string de delete na tabela Usuario
        private string strDelete = "DELETE FROM Usuario WHERE CodUsuario = @CodUsuario ";

        //string de select na tabela Usuario
        private string strSelect = "SELECT U.CodUsuario, U.CodPessoa, U.Usuario, U.Senha, U.DataAlteraSenha, " +
"U.DataCadastro, U.Supervisor, U.Ativo, U.AlteraSenha, P.Nome " +
"FROM Usuario AS U " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string que retorna o próximo Id da tabela Usuario
        private string strId = "SELECT MAX (CodUsuario) FROM Usuario ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Usuario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_usuario objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Usuario
                bool blnRetorno = true;

                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                objParam.Add(new SqlParameter("@Usuario", string.IsNullOrEmpty(objEnt.Usuario) ? DBNull.Value as object : objEnt.Usuario as object));
                objParam.Add(new SqlParameter("@Senha", string.IsNullOrEmpty(objEnt.Senha) ? DBNull.Value as object : objEnt.Senha as object));
                objParam.Add(new SqlParameter("@DataAlteraSenha", string.IsNullOrEmpty(objEnt.DataAlteraSenha) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataAlteraSenha) as object));
                objParam.Add(new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object));
                objParam.Add(new SqlParameter("@Supervisor", string.IsNullOrEmpty(objEnt.Supervisor) ? DBNull.Value as object : objEnt.Supervisor as object));
                objParam.Add(new SqlParameter("@Ativo", string.IsNullOrEmpty(objEnt.Ativo) ? DBNull.Value as object : objEnt.Ativo as object));
                objParam.Add(new SqlParameter("@AlteraSenha", string.IsNullOrEmpty(objEnt.AlteraSenha) ? DBNull.Value as object : objEnt.AlteraSenha as object));

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
        /// Função que faz UPDATE da Senha na Tabela Usuario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvarSenha(MOD_usuario objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Usuario
                bool blnRetorno = true;

                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@Senha", string.IsNullOrEmpty(objEnt.Senha) ? DBNull.Value as object : objEnt.Senha as object));
                objParam.Add(new SqlParameter("@DataAlteraSenha", string.IsNullOrEmpty(objEnt.DataAlteraSenha) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataAlteraSenha) as object));
                objParam.Add(new SqlParameter("@AlteraSenha", string.IsNullOrEmpty(objEnt.AlteraSenha) ? DBNull.Value as object : objEnt.AlteraSenha as object));

                blnRetorno = objAcessa.executar(strUpdateSenha, objParam);

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
        /// Função que faz INSERT na Tabela Usuario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_usuario objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Usuario
                bool blnRetorno = true;

                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                objParam.Add(new SqlParameter("@Usuario", string.IsNullOrEmpty(objEnt.Usuario) ? DBNull.Value as object : objEnt.Usuario as object));
                objParam.Add(new SqlParameter("@Senha", string.IsNullOrEmpty(objEnt.Senha) ? DBNull.Value as object : objEnt.Senha as object));
                objParam.Add(new SqlParameter("@DataAlteraSenha", string.IsNullOrEmpty(objEnt.DataAlteraSenha) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataAlteraSenha) as object));
                objParam.Add(new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object));
                objParam.Add(new SqlParameter("@Supervisor", string.IsNullOrEmpty(objEnt.Supervisor) ? DBNull.Value as object : objEnt.Supervisor as object));
                objParam.Add(new SqlParameter("@Ativo", string.IsNullOrEmpty(objEnt.Ativo) ? DBNull.Value as object : objEnt.Ativo as object));
                objParam.Add(new SqlParameter("@AlteraSenha", string.IsNullOrEmpty(objEnt.AlteraSenha) ? DBNull.Value as object : objEnt.AlteraSenha as object));

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
        /// Função que faz DELETE na Tabela Usuario
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_usuario objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Usuario
                bool blnRetorno = true;
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodUsuario", Convert.ToInt64(objEnt.CodUsuario)));
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
        /// Função que retorna os Registros da tabela Usuario, pesquisado pelo Código
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodUsuario)
        {
            try
            {
                if (string.IsNullOrEmpty(CodUsuario))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY U.CodUsuario ", objParam, "Usuario");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE U.CodUsuario = @CodUsuario ORDER BY U.CodUsuario ", objParam, "Usuario");
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
        /// Função que retorna os Registros da tabela Usuario, pesquisado pelo Código, retornando Ativos ou Inativos
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodUsuario, string Ativo)
        {
            try
            {
                if (string.IsNullOrEmpty(CodUsuario))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                    objParam.Add(new SqlParameter("@Ativo", Ativo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE U.Ativo = @Ativo ORDER BY U.CodUsuario ", objParam, "Usuario");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                    objParam.Add(new SqlParameter("@Ativo", Ativo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE U.CodUsuario = @CodUsuario AND U.Ativo = @Ativo ORDER BY U.CodUsuario ", objParam, "Usuario");
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
        ///Função que retorna os Registros da tabela Usuario, pesquisado pelo Nome
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome ORDER BY P.Nome ", objParam, "Usuario");
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
        /// Função que retorna os Registros da tabela Usuario, pesquisado pelo Nome, retornando Ativos ou Inativos
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome AND U.Ativo = @Ativo ORDER BY P.Nome ", objParam, "Usuario");
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
        ///Função que retorna os Registros da tabela Usuario, pesquisado pelo CodPessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarPessoa(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE U.CodPessoa = @CodPessoa ORDER BY P.Nome ", objParam, "Usuario");
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
        /// Função que retorna os Registros da tabela Usuario, pesquisado pelo CodPessoa, retornando Ativos ou Inativos
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarPessoa(string CodPessoa, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE U.CodPessoa = @CodPessoa AND U.Ativo = @Ativo ORDER BY P.Nome ", objParam, "Usuario");
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
        /// Função que retorna os Registros da tabela Usuario, pesquisado pelo Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public DataTable buscarUsuario(string Usuario)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Usuario", Usuario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE U.Usuario LIKE @Usuario ORDER BY U.Usuario ", objParam, "Usuario");
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
        /// Função que retorna os Registros da tabela Usuario, pesquisado pelo Usuario, retornando Ativos ou Inativos
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarUsuario(string Usuario, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Usuario", Usuario));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE U.Usuario = @Usuario AND U.Ativo = @Ativo ORDER BY U.Usuario ", objParam, "Usuario");
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
        /// Função que retorna os Registros da tabela Usuario, pesquisado pelo Usuario e Senha, retornando Ativos ou Inativos
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Senha"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarSenha(string Usuario, string Senha, string Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Usuario", Usuario));
                objParam.Add(new SqlParameter("@Senha", Senha));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE U.Usuario = @Usuario AND U.Senha = @Senha AND U.Ativo = @Ativo ", objParam, "Usuario");
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
                idUsuario = objAcessa.retornarId(strId);
                return Convert.ToInt64(idUsuario);
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
