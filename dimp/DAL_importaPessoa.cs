using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.importa;

namespace DAL.importa
{
    public class DAL_importaPessoa
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idImporta = null;

        #endregion

        #region Strings Sql da tabela ImportaPessoa

        //string de insert na tabela ImportaPessoa
        private string strInsert = "INSERT INTO ImportaPessoa (CodImportaPessoa, DataImporta, HoraImporta, CodUsuario, QtdeArquivo, Descricao) " +
"VALUES (@CodImportaPessoa, @DataImporta, @HoraImporta, @CodUsuario, @QtdeArquivo, @Descricao) ";

        //string de update na tabela ImportaPessoa
        private string strUpdate = "UPDATE ImportaPessoa SET DataImporta = @DataImporta, HoraImporta = @HoraImporta, CodUsuario = @CodUsuario, " +
"QtdeArquivo = @QtdeArquivo, Descricao = @Descricao " +
"WHERE CodImportaPessoa = @CodImportaPessoa ";

        //string de delete na tabela ImportaPessoa
        private string strDelete = "DELETE FROM ImportaPessoa WHERE CodImportaPessoa = @CodImportaPessoa ";

        //string de select na tabela ImportaPessoa
        private string strSelect = "SELECT I.CodImportaPessoa, I.DataImporta, I.CodUsuario, I.HoraImporta, I.QtdeArquivo, I.Descricao, " +
"U.CodPessoa, U.Usuario, P.Nome " +
"FROM ImportaPessoa AS I " +
"LEFT OUTER JOIN Usuario AS U ON I.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string que retorna o próximo Id da tabela ImportaPessoa
        private string strId = "SELECT MAX (CodImportaPessoa) FROM ImportaPessoa ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela ImportaPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_importaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodImportaPessoa", Convert.ToInt64(objEnt.CodImportaPessoa)));
                objParam.Add(new SqlParameter("@DataImporta", string.IsNullOrEmpty(objEnt.DataImporta) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataImporta) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@HoraImporta", string.IsNullOrEmpty(objEnt.HoraImporta) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraImporta) as object));
                objParam.Add(new SqlParameter("@QtdeArquivo", string.IsNullOrEmpty(objEnt.QtdeArquivo) ? DBNull.Value as object : Convert.ToInt32(objEnt.QtdeArquivo) as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));

                blnRetorno = objAcessa.executar(strUpdate, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                throw new Exception("Erro na DAL importaPessoa: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na DAL importaPessoa: " + ex.Message);
            }
        }

        /// <summary>
        /// Função que faz INSERT na Tabela ImportaPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_importaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodImportaPessoa", Convert.ToInt64(objEnt.CodImportaPessoa)));
                objParam.Add(new SqlParameter("@DataImporta", string.IsNullOrEmpty(objEnt.DataImporta) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataImporta) as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@HoraImporta", string.IsNullOrEmpty(objEnt.HoraImporta) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraImporta) as object));
                objParam.Add(new SqlParameter("@QtdeArquivo", string.IsNullOrEmpty(objEnt.QtdeArquivo) ? DBNull.Value as object : Convert.ToInt32(objEnt.QtdeArquivo) as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                throw new Exception("Erro na DAL importaPessoa: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na DAL importaPessoa: " + ex.Message);
            }
        }

        #endregion

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela ImportaPessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_importaPessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodImportaPessoa", Convert.ToInt64(objEnt.CodImportaPessoa)));
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
        /// Função que retorna os Registros da tabela ImportaPessoa, pesquisado pelo Código
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodImportaPessoa)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodImportaPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodImportaPessoa", CodImportaPessoa));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY I.CodImportaPessoa ", objParam, "ImportaPessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodImportaPessoa", CodImportaPessoa));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE I.CodImportaPessoa = @CodImportaPessoa ORDER BY I.CodImportaPessoa", objParam, "ImportaPessoa");
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
        /// Função que retorna os Registros da tabela ImportaPessoa, pesquisado pela DataImporta
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public DataTable buscarDataImporta(string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE I.DataImporta BETWEEN @DataInicial AND @DataFinal ORDER BY I.DataImporta ", objParam, "ImportaPessoa");
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
                idImporta = objAcessa.retornarId(strId);
                return Convert.ToInt32(idImporta);
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