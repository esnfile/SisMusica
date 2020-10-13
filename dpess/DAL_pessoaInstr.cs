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
    public class DAL_pessoaInstr
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idCodPessoaInstr = null;

        #endregion

        #region Strings Sql da tabela PessoaInstr

        //string de insert na tabela PessoaInstr
        private string strInsert = "INSERT INTO PessoaInstr (CodPessoaInstr, CodPessoa, CodInstrumento) " +
"VALUES (@CodPessoaInstr, @CodPessoa, @CodInstrumento) ";

//        //string de update na tabela PessoaInstr
//        private string strUpdate = "UPDATE PessoaInstr SET CodPessoa = @CodPessoa, CodInstrumento = @CodInstrumento " +
//"WHERE CodPessoaInstr = @CodPessoaInstr ";

        //string de delete na tabela PessoaInstr
        private string strDelete = "DELETE FROM PessoaInstr WHERE CodPessoaInstr = @CodPessoaInstr ";

        //string de select na tabela PessoaInstr
        private string strSelect = "SELECT PI.CodPessoaInstr, PI.CodPessoa, PI.CodInstrumento, " +
"P.Nome, I.DescInstrumento, I.CodFamilia, I.Situacao, F.DescFamilia " +
"FROM PessoaInstr AS PI " +
"LEFT OUTER JOIN Pessoa AS P ON PI.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Instrumentos AS I ON PI.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string de select na tabela Instrumentos
        private string strSelectInst = "SELECT I.CodInstrumento, I.DescInstrumento, I.CodFamilia, F.DescFamilia " +
"FROM Instrumentos AS I " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia " +
"WHERE I.CodInstrumento NOT IN (SELECT CodInstrumento FROM PessoaInstr ";

        //string que retorna o próximo Id da tabela PessoaInstr
        private string strId = "SELECT MAX (CodPessoaInstr) FROM PessoaInstr ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base
        
        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela PessoaInstr
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_pessoaInstr objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaInstr
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela PessoaInstr
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt.CodPessoaInstr).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodPessoaInstr", retornaId()));
                        objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt.CodPessoa)));
                        objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));

                        blnRetorno = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt.CodPessoaInstr).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodPessoaInstr", Convert.ToInt64(objEnt.CodPessoaInstr)));

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
        /// Função que retorna os Registros da tabela PessoaInstr, pesquisado pela Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarInstPessoa(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE PI.CodPessoa = @CodPessoa ORDER BY I.CodFamilia, I.DescInstrumento ", objParam, "PessoaInstr");
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
        /// Função que retorna os Registros da tabela Instrumentos, pesquisado pelo CodInstrumento.*\
        /// Essa Consulta retorna os valores que não estão na Tabela PessoaInstrumento
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarInstrumentos(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelectInst + "WHERE CodPessoa = @CodPessoa) ORDER BY F.DescFamilia, I.DescInstrumento ", objParam, "Instrumentos");
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
                idCodPessoaInstr = objAcessa.retornarId(strId);
                return Convert.ToInt64(idCodPessoaInstr);
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
