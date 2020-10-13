using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.uteis;

namespace DAL.uteis
{
    public class DAL_ccb
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idCCB = null;

        #endregion

        #region Strings Sql da tabela CCB

        //string de insert na tabela CCB
        private string strInsert = "INSERT INTO CCB (CodCCB, Codigo, Descricao, Endereco, Numero, Bairro, Complemento, CodCidade, Telefone, Celular, Email, CNPJ, DataAbertura, Skype, Situacao, CodRegiao) " +
"VALUES (@CodCCB, @Codigo, @Descricao, @Endereco, @Numero, @Bairro, @Complemento, @CodCidade, @Telefone, @Celular, @Email, @CNPJ, @DataAbertura, @Skype, @Situacao, @CodRegiao) ";

        //string de update na tabela CCB
        private string strUpdate = "UPDATE CCB SET Codigo = @Codigo, Descricao = @Descricao, Endereco = @Endereco, Numero = @Numero, Bairro = @Bairro, " +
"Complemento = @Complemento, CodCidade = @CodCidade, Telefone = @Telefone, Celular = @Celular, Email  = @Email, CNPJ = @CNPJ, DataAbertura = @DataAbertura, " +
"Skype = @Skype, Situacao = @Situacao, CodRegiao = @CodRegiao " +
"WHERE CodCCB = @CodCCB ";

        //string de delete na tabela CCB
        private string strDelete = "DELETE FROM CCB WHERE CodCCB = @CodCCB ";

        //string de select na tabela CCB
        private string strSelect = "SELECT C.CodCCB, C.Codigo, C.Descricao, C.Endereco, C.Numero, C.Bairro, C.Complemento, C.CodCidade, C.Telefone, C.Celular, C.Email, " +
"C.CNPJ, C.DataAbertura, C.Skype, C.Situacao, C.CodRegiao, " +
"CI.Cidade, CI.Estado, CI.Cep, R.Codigo AS CodigoRegiao, R.Descricao AS DescricaoRegiao, R.CodRegional, RG.Codigo AS CodigoRegional, RG.Descricao AS DescricaoRegional " +
"FROM CCB AS C " +
"LEFT OUTER JOIN Cidade AS CI ON C.CodCidade = CI.CodCidade " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Regional AS RG ON R.CodRegional = RG.CodRegional ";

        //string que retorna o próximo Id da tabela CCB
        private string strId = "SELECT MAX (CodCCB) FROM CCB ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela CCB
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_ccb objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela CCB
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(objEnt.CodCCB)));
                objParam.Add(new SqlParameter("@Codigo", string.IsNullOrEmpty(objEnt.Codigo) ? DBNull.Value as object : objEnt.Codigo as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));
                objParam.Add(new SqlParameter("@Endereco", string.IsNullOrEmpty(objEnt.Endereco) ? DBNull.Value as object : objEnt.Endereco as object));
                objParam.Add(new SqlParameter("@Numero", string.IsNullOrEmpty(objEnt.Numero) ? DBNull.Value as object : objEnt.Numero as object));
                objParam.Add(new SqlParameter("@Bairro", string.IsNullOrEmpty(objEnt.Bairro) ? DBNull.Value as object : objEnt.Bairro as object));
                objParam.Add(new SqlParameter("@Complemento", string.IsNullOrEmpty(objEnt.Complemento) ? DBNull.Value as object : objEnt.Complemento as object));
                objParam.Add(new SqlParameter("@CodCidade", string.IsNullOrEmpty(objEnt.CodCidade) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCidade) as object));
                objParam.Add(new SqlParameter("@Telefone", string.IsNullOrEmpty(objEnt.Telefone) ? DBNull.Value as object : objEnt.Telefone as object));
                objParam.Add(new SqlParameter("@Celular", string.IsNullOrEmpty(objEnt.Celular) ? DBNull.Value as object : objEnt.Celular as object));
                objParam.Add(new SqlParameter("@Email", string.IsNullOrEmpty(objEnt.Email) ? DBNull.Value as object : objEnt.Email as object));
                objParam.Add(new SqlParameter("@CNPJ", string.IsNullOrEmpty(objEnt.CNPJ) ? DBNull.Value as object : objEnt.CNPJ as object));
                objParam.Add(new SqlParameter("@DataAbertura", string.IsNullOrEmpty(objEnt.DataAbertura) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataAbertura) as object));
                objParam.Add(new SqlParameter("@Skype", string.IsNullOrEmpty(objEnt.Skype) ? DBNull.Value as object : objEnt.Skype as object));
                objParam.Add(new SqlParameter("@Situacao", string.IsNullOrEmpty(objEnt.Situacao) ? DBNull.Value as object : objEnt.Situacao as object));
                objParam.Add(new SqlParameter("@CodRegiao", string.IsNullOrEmpty(objEnt.CodRegiao) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRegiao) as object));
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
        /// Função que faz INSERT na Tabela CCB
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_ccb objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela CCB
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(objEnt.CodCCB)));
                objParam.Add(new SqlParameter("@Codigo", string.IsNullOrEmpty(objEnt.Codigo) ? DBNull.Value as object : objEnt.Codigo as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));
                objParam.Add(new SqlParameter("@Endereco", string.IsNullOrEmpty(objEnt.Endereco) ? DBNull.Value as object : objEnt.Endereco as object));
                objParam.Add(new SqlParameter("@Numero", string.IsNullOrEmpty(objEnt.Numero) ? DBNull.Value as object : objEnt.Numero as object));
                objParam.Add(new SqlParameter("@Bairro", string.IsNullOrEmpty(objEnt.Bairro) ? DBNull.Value as object : objEnt.Bairro as object));
                objParam.Add(new SqlParameter("@Complemento", string.IsNullOrEmpty(objEnt.Complemento) ? DBNull.Value as object : objEnt.Complemento as object));
                objParam.Add(new SqlParameter("@CodCidade", string.IsNullOrEmpty(objEnt.CodCidade) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCidade) as object));
                objParam.Add(new SqlParameter("@Telefone", string.IsNullOrEmpty(objEnt.Telefone) ? DBNull.Value as object : objEnt.Telefone as object));
                objParam.Add(new SqlParameter("@Celular", string.IsNullOrEmpty(objEnt.Celular) ? DBNull.Value as object : objEnt.Celular as object));
                objParam.Add(new SqlParameter("@Email", string.IsNullOrEmpty(objEnt.Email) ? DBNull.Value as object : objEnt.Email as object));
                objParam.Add(new SqlParameter("@CNPJ", string.IsNullOrEmpty(objEnt.CNPJ) ? DBNull.Value as object : objEnt.CNPJ as object));
                objParam.Add(new SqlParameter("@DataAbertura", string.IsNullOrEmpty(objEnt.DataAbertura) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataAbertura) as object));
                objParam.Add(new SqlParameter("@Skype", string.IsNullOrEmpty(objEnt.Skype) ? DBNull.Value as object : objEnt.Skype as object));
                objParam.Add(new SqlParameter("@Situacao", string.IsNullOrEmpty(objEnt.Situacao) ? DBNull.Value as object : objEnt.Situacao as object));
                objParam.Add(new SqlParameter("@CodRegiao", string.IsNullOrEmpty(objEnt.CodRegiao) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRegiao) as object));

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
        /// Função que faz DELETE na Tabela CCB
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_ccb objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela CCB
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCCB", Convert.ToInt32(objEnt.CodCCB)));
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo Código
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodCCB)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodCCB))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY C.CodCCB ", objParam, "CCB");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodCCB = @CodCCB ORDER BY C.CodCCB", objParam, "CCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo Codigo
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public DataTable buscarCodigo(string Codigo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Codigo", Codigo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.Codigo LIKE @Codigo ORDER BY C.Codigo, C.Descricao ", objParam, "CCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo Cnpj
        /// </summary>
        /// <param name="Cnpj"></param>
        /// <returns></returns>
        public DataTable buscarCnpj(string Cnpj)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cnpj", Cnpj));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.Cnpj LIKE @Cnpj ORDER BY C.Cnpj, CI.Cidade, C.Descricao ", objParam, "CCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pela Descricao
        /// </summary>
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string Descricao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Descricao", Descricao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.Descricao LIKE @Descricao ORDER BY CI.Cidade, C.Descricao ", objParam, "CCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pela Cidade
        /// </summary>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string CodCidade)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCidade", CodCidade));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodCidade In(" + @CodCidade + ") ORDER BY CI.Cidade, C.Descricao ", objParam, "CCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pela Descrição da Cidade
        /// </summary>
        /// <param name="Cidade"></param>
        /// <returns></returns>
        public DataTable buscarCidadeDescricao(string Cidade)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cidade", Cidade));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CI.Cidade In('" + @Cidade + "') ORDER BY CI.Cidade, C.Descricao ", objParam, "CCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pelo Estado
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public DataTable buscarEstado(string Estado)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Estado", Estado));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CI.Estado = @Estado ORDER BY CI.Cidade, C.Descricao ", objParam, "CCB");
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
        /// Função que retorna os Registros da tabela CCB, pesquisado pela Regiao
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarRegiao(string CodRegiao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodRegiao In(" + @CodRegiao + ") ORDER BY R.Descricao, CI.Cidade, C.Descricao ", objParam, "CCB");
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
        /// Função de Relatório - retorna os Registros da tabela Comum Congregação, pesquisado pela Situação e Data de abertura
        /// <paramref name="Situacao"/>: Aberta, Em Construção, Em Reforma, Fechada
        /// </summary>
        /// <param name="Situacao"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioCCB(string Situacao, string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Situacao", Situacao));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));

                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.Situacao IN('" + Situacao + "') AND " +
                                                        "C.DataAbertura IS NULL OR C.DataAbertura BETWEEN @DataInicial AND @DataFinal ", objParam, "CCB");

                //objDtb = objAcessa.retornaDados(strSelect + "WHERE C.Situacao IN('" + Situacao + "') ", objParam, "CCB");

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
                idCCB = objAcessa.retornarId(strId);
                return Convert.ToInt32(idCCB);
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
