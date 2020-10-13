using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.pessoa;

namespace DAL.pessoa
{
    public class DAL_pessoaMetodoLicao
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idPessoa = null;

        #endregion

        #region Strings Sql da tabela PessoaMetodoLicao

        //string de insert na tabela PessoaMetodoLicao
        private string strInsert = "INSERT INTO PessoaMetodoLicao (CodPesMetLicao, CodPessoa, CodMetodo, Fase, Pagina, Licao, Status) " +
"VALUES (@CodPesMetLicao, @CodPessoa, @CodMetodo, @Fase, @Pagina, @Status) ";

        //string de update na tabela PessoaMetodoLicao
        private string strUpdate = "UPDATE PessoaMetodoLicao SET CodPessoa = @CodPessoa, CodMetodo = @CodMetodo, Fase = @Fase, " +
"Pagina = @Pagina, Licao = @Licao, Status = @Status " +
"WHERE CodPesMetLicao = @CodPesMetLicao ";

        //string de delete na tabela PessoaMetodoLicao
        private string strDelete = "DELETE FROM PessoaMetodoLicao WHERE CodPesMetLicao = @CodPesMetLicao ";

        //string de select na tabela PessoaMetodoLicao
        private string strSelect = "SELECT PM.CodPesMetLicao, PM.CodPessoa, PM.Fase, PM.CodMetodo, PM.Pagina, PM.Licao, PM.Status, " +
"P.Nome, M.DescMetodo, M.Compositor, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase " +
"FROM PessoaMetodoLicao AS PM " +
"LEFT OUTER JOIN Pessoa AS P ON PM.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Metodos AS M ON PM.CodMetodo = M.CodMetodo ";

        //string que retorna o próximo Id da tabela PessoaMetodoLicao
        private string strId = "SELECT MAX (CodPesMetLicao) FROM PessoaMetodoLicao ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela PessoaMetodoLicao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_pessoaMetodoLicao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaMetodoLicao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPesMetLicao", Convert.ToInt64(objEnt.CodPesMetLicao)));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                objParam.Add(new SqlParameter("@Fase", string.IsNullOrEmpty(objEnt.Fase) ? DBNull.Value as object : Convert.ToInt16(objEnt.Fase) as object));
                objParam.Add(new SqlParameter("@Pagina", string.IsNullOrEmpty(objEnt.Pagina) ? DBNull.Value as object : Convert.ToInt16(objEnt.Pagina) as object));
                objParam.Add(new SqlParameter("@Licao", string.IsNullOrEmpty(objEnt.Licao) ? DBNull.Value as object : Convert.ToInt16(objEnt.Licao) as object));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
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
        /// Função que faz INSERT na Tabela PessoaMetodoLicao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_pessoaMetodoLicao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaMetodoLicao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPesMetLicao", Convert.ToInt64(objEnt.CodPesMetLicao)));
                objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                objParam.Add(new SqlParameter("@Fase", string.IsNullOrEmpty(objEnt.Fase) ? DBNull.Value as object : Convert.ToInt16(objEnt.Fase) as object));
                objParam.Add(new SqlParameter("@Pagina", string.IsNullOrEmpty(objEnt.Pagina) ? DBNull.Value as object : Convert.ToInt16(objEnt.Pagina) as object));
                objParam.Add(new SqlParameter("@Licao", string.IsNullOrEmpty(objEnt.Licao) ? DBNull.Value as object : Convert.ToInt16(objEnt.Licao) as object));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
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
        /// Função que faz DELETE na Tabela PessoaMetodoLicao
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_pessoaMetodoLicao objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaMetodoLicao
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPesMetLicao", Convert.ToInt64(objEnt.CodPesMetLicao)));
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
        /// Função que retorna os Registros da tabela PessoaMetodoLicao, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPesMetLicao"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPesMetLicao)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPesMetLicao))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPesMetLicao", CodPesMetLicao));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY PM.CodPesMetLicao ", objParam, "PessoaMetodoLicao");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPesMetLicao", CodPesMetLicao));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE PM.CodPesMetLicao = @CodPesMetLicao ORDER BY PM.CodPesMetLicao", objParam, "PessoaMetodoLicao");
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
        /// Função que retorna os Registros da tabela PessoaMetodoLicao, pesquisado pela Pessoa
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
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PM.CodPessoa = @CodPessoa ORDER BY M.DescMetodo ", objParam, "PessoaMetodoLicao");
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
        /// Função que retorna os Registros da tabela PessoaMetodoLicao, pesquisado pelo Metodo
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarMetodo(string CodMetodo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PM.CodMetodo = @CodMetodo ORDER BY P.Nome ", objParam, "PessoaMetodoLicao");
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
        /// Função que retorna os Registros da tabela PessoaMetodoLicao, pesquisado pela Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarPessoaMetodo(string CodPessoa, string CodMetodo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PM.CodPessoa = @CodPessoa AND PM.CodMetodo = @CodMetodo ORDER BY M.DescMetodo ", objParam, "PessoaMetodoLicao");
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
                idPessoa = objAcessa.retornarId(strId);
                return Convert.ToInt64(idPessoa);
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
