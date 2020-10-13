using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;

using ENT.instrumentos;
using DAL.Acessa;

namespace DAL.instrumentos
{
    public class DAL_instrumentoFoto
    {

        #region declarações
        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idFoto = null;

        #endregion

        #region Strings Sql da tabela InstrumentoFoto

        //string de insert na tabela InstrumentoFoto
        private string strInsertFoto = "INSERT INTO InstrumentoFoto (CodFoto, CodInstrumento, Foto) " +
"VALUES (@CodFoto, @CodInstrumento, @Foto) ";

        //string de update na tabela InstrumentoFoto
        private string strUpdateFoto = "UPDATE InstrumentoFoto SET CodInstrumento = @CodInstrumento, Foto = @Foto " +
"WHERE CodFoto = @CodFoto ";

        //string de select na tabela InstrumentoFoto
        private string strSelectFoto = "SELECT CodFoto, CodInstrumento, Foto " +
"FROM InstrumentoFoto ";

        //string que retorna o próximo Id da tabela InstrumentoFoto
        private string strIdFoto = "SELECT MAX (CodFoto) FROM InstrumentoFoto ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE E DELETE na Tabela InstrumentoFoto
        /// </summary>
        /// <param name="objEnt_Foto"></param>
        /// <returns></returns>
        public bool salvar(MOD_instrumentoFoto objEnt_Foto)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela InstrumentoFoto
                bool blnRetornoFoto = true;

                //Declara a lista de parametros da tabela InstrumentoFoto
                List<SqlParameter> objParam = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(objEnt_Foto.Foto))
                {
                    if (Convert.ToString(objEnt_Foto.CodFoto).Equals(string.Empty))
                    {
                        //define um array para armazenar a foto
                        byte[] fotoimagem = carregaFoto(objEnt_Foto.Foto);

                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodFoto", retornaId()));
                        objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt_Foto.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt_Foto.CodInstrumento) as object));
                        objParam.Add(new SqlParameter("@Foto", string.IsNullOrEmpty(objEnt_Foto.Foto) ? DBNull.Value as object : fotoimagem as object));

                        blnRetornoFoto = objAcessa.executar(strInsertFoto, objParam);
                    }
                    else
                    {
                        //define um array para armazenar a foto
                        byte[] fotoimagem = carregaFoto(objEnt_Foto.Foto);

                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodFoto", string.IsNullOrEmpty(objEnt_Foto.CodFoto) ? DBNull.Value as object : Convert.ToInt16(objEnt_Foto.CodFoto) as object));
                        objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt_Foto.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt_Foto.CodInstrumento) as object));
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
        /// Função que retorna os Registros da tabela InstrumentoFoto, pesquisado pelo CodInstrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarInstrumentoFoto(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros da segunda tabela Empresa Funcionario
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelectFoto + "WHERE CodInstrumento = @CodInstrumento ", objParam, "InstrumentoFoto");
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
        public Int16 retornaId()
        {
            try
            {
                idFoto = objAcessa.retornarId(strIdFoto);
                return Convert.ToInt16(idFoto);
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
