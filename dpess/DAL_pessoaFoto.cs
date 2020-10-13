using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;

using ENT.pessoa;
using DAL.Acessa;

namespace DAL.pessoa
{
    public class DAL_pessoaFoto
    {

        #region declarações
        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idFoto = null;

        #endregion

        #region Strings Sql da tabela PessoaFoto

        //string de insert na tabela PessoaFoto
        private string strInsertFoto = "INSERT INTO PessoaFoto (CodFoto, CodPessoa, Foto) " +
"VALUES (@CodFoto, @CodPessoa, @Foto) ";

        //string de update na tabela PessoaFoto
        private string strUpdateFoto = "UPDATE PessoaFoto SET CodPessoa = @CodPessoa, Foto = @Foto " +
"WHERE CodFoto = @CodFoto ";

        //string de select na tabela PessoaFoto
        private string strSelectFoto = "SELECT CodFoto, CodPessoa, Foto " +
"FROM PessoaFoto ";

        //string que retorna o próximo Id da tabela PessoaFoto
        private string strIdFoto = "SELECT MAX (CodFoto) FROM PessoaFoto ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE E DELETE na Tabela PessoaFoto
        /// </summary>
        /// <param name="objEnt_Foto"></param>
        /// <returns></returns>
        public bool salvar(MOD_pessoaFoto objEnt_Foto)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela PessoaFoto
                bool blnRetornoFoto = true;

                //Declara a lista de parametros da tabela PessoaFoto
                List<SqlParameter> objParam = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(objEnt_Foto.Foto))
                {
                    if (Convert.ToInt16(objEnt_Foto.CodFoto).Equals(0))
                    {
                        //define um array para armazenar a foto
                        byte[] fotoimagem = carregaFoto(objEnt_Foto.Foto);

                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodFoto", retornaId()));
                        objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt_Foto.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt_Foto.CodPessoa) as object));
                        objParam.Add(new SqlParameter("@Foto", string.IsNullOrEmpty(objEnt_Foto.Foto) ? DBNull.Value as object : fotoimagem as object));

                        blnRetornoFoto = objAcessa.executar(strInsertFoto, objParam);
                    }
                    else
                    {
                        //define um array para armazenar a foto
                        byte[] fotoimagem = carregaFoto(objEnt_Foto.Foto);

                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodFoto", string.IsNullOrEmpty(objEnt_Foto.CodFoto) ? DBNull.Value as object : Convert.ToInt64(objEnt_Foto.CodFoto) as object));
                        objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt_Foto.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt_Foto.CodPessoa) as object));
                        objParam.Add(new SqlParameter("@Foto", string.IsNullOrEmpty(objEnt_Foto.Foto) ? DBNull.Value as object : fotoimagem as object));

                        blnRetornoFoto = objAcessa.executar(strUpdateFoto, objParam);
                    }
                }

                //retorna o blnRetorno da tabela principal
                return blnRetornoFoto;
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
        /// Função que retorna os Registros da tabela PessoaFoto, pesquisado pelo CodPessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarPessoaFoto(string CodPessoa)
        {
            try
            {
                //declara a lista de parametros da segunda tabela Foto Pessoa
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                objDtb = objAcessa.retornaDados(strSelectFoto + "WHERE CodPessoa = @CodPessoa ", objParam, "PessoaFoto");
                //retorna o DataTable
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
                idFoto = objAcessa.retornarId(strIdFoto);
                return Convert.ToInt64(idFoto);
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
        /// Função que carrega a Imagem e Converte em Binário
        /// </summary>
        /// <param name="caminhoFoto"></param>
        /// <returns></returns>
        private byte[] carregaFoto(string caminhoFoto)
        {
            try
            {
                FileStream fs = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);

                byte[] foto = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                return foto;
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
