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
    public class DAL_pessoaMetodo
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idCodPessoaMetodo = null;

        #endregion

        #region Strings Sql da tabela PessoaMetodo

        //string de insert na tabela PessoaMetodo
        private string strInsert = "INSERT INTO PessoaMetodo (CodPessoaMetodo, CodPessoa, CodMetodo) " +
"VALUES (@CodPessoaMetodo, @CodPessoa, @CodMetodo) ";

//        //string de update na tabela PessoaMetodo
//        private string strUpdate = "UPDATE PessoaMetodo SET CodPessoa = @CodPessoa, CodMetodo = @CodMetodo " +
//"WHERE CodPessoaMetodo = @CodPessoaMetodo ";

        //string de delete na tabela PessoaMetodo
        private string strDelete = "DELETE FROM PessoaMetodo WHERE CodPessoaMetodo = @CodPessoaMetodo ";

        //string de select na tabela PessoaMetodo
        private string strSelect = "SELECT PM.CodPessoaMetodo, PM.CodPessoa, PM.CodMetodo, " +
"P.Nome, M.DescMetodo, M.Compositor, M.QtdePagina, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase " +
"FROM PessoaMetodo AS PM " +
"LEFT OUTER JOIN Pessoa AS P ON PM.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Metodos AS M ON PM.CodMetodo = M.CodMetodo ";

        //string de select na tabela MetodoInstr
        private string strSelectMet = "SELECT MI.CodMetodoInstr, MI.CodInstrumento, MI.CodMetodo, MI.AplicarEm, " +
"MI.PaginaInicio, MI.LicaoInicio, MI.PaginaFim, MI.LicaoFim, M.DescMetodo, M.Compositor, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase " +
"FROM MetodoInstr AS MI " +
"LEFT OUTER JOIN Metodos AS M ON MI.CodMetodo = M.CodMetodo " +
"WHERE MI.CodMetodo NOT IN (SELECT CodMetodo FROM PessoaMetodo ";

        //string que retorna o próximo Id da tabela PessoaMetodo
        private string strId = "SELECT MAX (CodPessoaMetodo) FROM PessoaMetodo ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base
        
        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela PessoaMetodo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_pessoaMetodo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaMetodo
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaMetodo
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt.CodPessoaMetodo).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodPessoaMetodo", retornaId()));
                        objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt.CodPessoa)));
                        objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));

                        blnRetorno = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt.CodPessoaMetodo).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodPessoaMetodo", Convert.ToInt64(objEnt.CodPessoaMetodo)));

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
        /// Função que retorna os Registros da tabela PessoaMetodo, pesquisado pela Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarMetodoPessoa(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PM.CodPessoa = @CodPessoa ORDER BY M.DescMetodo ", objParam, "PessoaMetodo");
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
        /// Função que retorna os Registros da tabela Metodos, pesquisado pelo CodMetodo.*\
        /// Essa Consulta retorna os valores que não estão na Tabela PessoaMetodo
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarMetodos(string CodPessoa, string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelectMet + "WHERE CodPessoa = @CodPessoa) AND MI.CodInstrumento = @CodInstrumento ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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
                idCodPessoaMetodo = objAcessa.retornarId(strId);
                return Convert.ToInt64(idCodPessoaMetodo);
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
