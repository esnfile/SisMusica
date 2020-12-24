using ENT.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Acessa
{
    public class acessa : IConnect
    {

        #region Declaração de Variaveis

        /// <summary>
        /// String de Conexão com o Banco de Dados
        /// </summary>
        public static string strSql;

        /// <summary>
        /// Objeto de Conexão com o Banco de Dados
        /// </summary>
        SqlConnection objConn = null;

        #endregion

        #region Métodos de conectar e desconectar

        /// <summary>
        /// Função que Abre a Conexão com o Banco de Dados
        /// </summary>
        /// <returns></returns>
        public bool conectar()
        {
            try
            {
                objConn = new SqlConnection(MOD_Session.StrConnection);
                objConn.Open();
                return true;
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
        /// Função que Fecha a Conexão com o Banco de Dados
        /// </summary>
        /// <returns></returns>
        public bool desconectar()
        {
            try
            {
                if (!objConn.State.Equals(ConnectionState.Closed))
                {
                    objConn.Close();
                    objConn.Dispose();
                }
                return true;
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

        #region Métodos para retornar e salvar dados

        /// <summary>
        /// Função que Conecta no Banco de Dados e Retorna os Registros solicitados pelos Parametros
        /// </summary>
        /// <param name="objStrSql"></param>
        /// <param name="objParam"></param>
        /// <param name="objTabela"></param>
        /// <returns></returns>
        public DataTable retornaDados(string objStrSql, List<SqlParameter> objParam, string objTabela)
        {

            try
            {
                ///Chama o método conectar
                if (!this.conectar())
                {
                    ///se não conseguir conectar já retorna erro
                    throw new Exception("Não foi possível conectar na Base de Dados!");
                }
                ///define o SqlCommand com 02 parametros (String SQL e Objeto de Conexão)
                SqlCommand objCmd = new SqlCommand(objStrSql, objConn);

                ///Faz um Loop nos parametros para adicionar ao Command
                foreach (SqlParameter param in objParam)
                {
                    ///adiciona um novo parametro no SqlCommand
                    objCmd.Parameters.Add(param);
                }

                ///declara um novo adapter e adiciona o SqlCommand
                SqlDataAdapter objDa = new SqlDataAdapter(objCmd);

                ///Declara um novo dataset
                DataSet objDs = new DataSet();

                ///Lê os Dados no Banco e Preenche o DataAdapter Criado
                objDa.Fill(objDs, objTabela);

                ///Retorna o DataSet Criado, porém não retorna o dataset inteiro,
                ///retorna somente os dados da tabela Informada.
                return objDs.Tables[objTabela];
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ///Chama o método desconectar
                this.desconectar();
            }
        }

        /// <summary>
        /// Função que Executa os Comandos INSERT, UPDATE e DELETE no Banco de Dados
        /// </summary>
        /// <param name="objStrSql"></param>
        /// <param name="objParam"></param>
        /// <returns></returns>
        public bool executar(string objStrSql, List<SqlParameter> objParam)
        {
            try
            {
                ///Variavel que recebe o Resultado da Execução no Banco de Dados
                bool blnResult = false;

                ///Chama o método conectar
                if (!this.conectar())
                {
                    ///Se não conseguir conectgar já retorna false
                    throw new Exception("Não foi possível conectar na Base de Dados!");
                }

                ///define o SqlCommand com 02 parametros (String SQL e Objeto de Conexão)
                SqlCommand objCmd = new SqlCommand(objStrSql, objConn);

                ///Faz um Loop nos parametros para adicionar ao Command
                foreach (SqlParameter param in objParam)
                {
                    ///Adiciona um novo parametro no SqlCommand
                    objCmd.Parameters.Add(param);
                }
                ///Grava os Dados no Banco de Dados e Retorna Verdadeiro ou Falso
                blnResult = (objCmd.ExecuteNonQuery() > 0 ? true : false);

                ///retorna a variavel
                return blnResult;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ///Chama o método desconectar
                this.desconectar();
            }
        }

        /// <summary>
        /// Função que Retorna o Ultimo ID inserido na Tabela
        /// </summary>
        /// <param name="objStrSql"></param>
        /// <returns></returns>
        public object retornarId(string objStrSql)
        {
            try
            {
                ///Chama o método conectar
                if (!this.conectar())
                {
                    ///se não conseguir conectar já retorna nulo
                    throw new Exception("Não foi possível conectar na Base de Dados!");
                }
                ///Define a Variavel para receber o Proximo ID na Tabela
                object maxId;

                ///define o SqlCommand com 02 parametros (String SQL e Objeto de Conexão)
                SqlCommand objCmd = new SqlCommand(objStrSql, objConn);

                //Lê os Dados e Preenche a Variavel
                maxId = objCmd.ExecuteScalar();

                if (maxId == DBNull.Value)
                {
                    maxId = 1;
                }
                else
                {
                    Int64 Id = Convert.ToInt64(maxId);
                    maxId = Id + 1;
                }
                ///Retorna a Variavel com o Valor
                return maxId;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.desconectar();
            }
        }

        /// <summary>
        /// Função que Retorna Dados Binários do Banco, tais como Fotos
        /// </summary>
        /// <param name="objStrSql"></param>
        /// <param name="objParam"></param>
        /// <returns></returns>
        public SqlDataReader retornarBinary(string objStrSql, List<SqlParameter> objParam)
        {

            try
            {
                ///chama o método conectar
                if (!this.conectar())
                {
                    ///se não conseguir conectgar já retorna null
                    throw new Exception("Não foi possível conectar na Base de Dados!");
                }

                ///Define o SqlCommand com 02 Parametros (String SQL e Objeto de Conexão)
                SqlCommand objCmd = new SqlCommand(objStrSql, objConn);

                ///Faz um Loop nos Parametros para execução do Comando
                foreach (SqlParameter param in objParam)
                {
                    ///adiciona um novo parametro no SqlCommand
                    objCmd.Parameters.Add(param);
                }

                SqlDataReader objDr;
                ///Lê os dados na Base e Preenche o DataReader
                objDr = objCmd.ExecuteReader(CommandBehavior.SequentialAccess);

                ///Retorna o DataReader preenchido com a Image
                return objDr;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                ///Se der erro retorna null e já envia a mensagem de erro
                throw ex;
            }
            finally
            {
                ///Chama o método desconectar
                this.desconectar();
            }
        }

        #endregion

    }
}