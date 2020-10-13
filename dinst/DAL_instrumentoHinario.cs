using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.instrumentos;

namespace DAL.instrumentos
{
    public class DAL_instrumentoHinario
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idInstrHino = null;

        #endregion

        #region Strings Sql da tabela InstrumentoHinario

        //string de insert na tabela InstrumentoHinario
        private string strInsert = "INSERT INTO InstrumentoHinario (CodInstrumentoHino, CodHinario, CodInstrumento) " +
"VALUES (@CodInstrumentoHino, @CodHinario, @CodInstrumento) ";

        //string de update na tabela InstrumentoHinario
        private string strUpdate = "UPDATE InstrumentoHinario SET CodHinario = @CodHinario, CodInstrumento = @CodInstrumento " +
"WHERE CodInstrumentoHino = @CodInstrumentoHino ";

        //string de delete na tabela InstrumentoHinario
        private string strDelete = "DELETE FROM InstrumentoHinario WHERE CodInstrumentoHino = @CodInstrumentoHino ";

        //string de select na tabela InstrumentoHinario
        private string strSelect = "SELECT IH.CodInstrumentoHino, IH.CodHinario, IH.CodInstrumento, H.DescHinario, I.DescInstrumento " +
"FROM InstrumentoHinario AS IH " +
"LEFT OUTER JOIN Hinario AS H ON IH.CodHinario = H.CodHinario " +
"LEFT OUTER JOIN Instrumentos AS I ON IH.CodInstrumento = I.CodInstrumento ";

        //string de select na tabela Hinario
        private string strSelectVoz = "SELECT CodHinario, DescHinario " +
"FROM Hinario WHERE CodHinario NOT IN (SELECT CodHinario FROM InstrumentoHinario ";

        //string que retorna o próximo Id da tabela InstrumentoHinario
        private string strId = "SELECT MAX (CodInstrumentoHino) FROM InstrumentoHinario ";

        #endregion

        #region Função para Deletar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela InstrumentoHinario
        /// </summary>
        /// <param name="objEnt_Hino"></param>
        /// <returns></returns>
        public bool salvar(MOD_instrumentoHinario objEnt_Hino)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela InstrumentoHinario
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela InstrumentoHinario
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt_Hino.Marcado.Equals(false))
                {
                    if (!Convert.ToInt32(objEnt_Hino.CodInstrumentoHino).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoHino", objEnt_Hino.CodInstrumentoHino));
                        blnRetorno = objAcessa.executar(strDelete, objParam);
                    }
                }
                else
                {
                    //verifica se vai ser feita inserção ou atualização
                    if (Convert.ToInt32(objEnt_Hino.CodInstrumentoHino).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoHino", retornaId()));
                        objParam.Add(new SqlParameter("@CodHinario", Convert.ToInt16(objEnt_Hino.CodHinario) as object));
                        objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt16(objEnt_Hino.CodInstrumento) as object));

                        blnRetorno = objAcessa.executar(strInsert, objParam);
                    }
                    else
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoHino", Convert.ToInt64(objEnt_Hino.CodInstrumentoHino) as object));
                        objParam.Add(new SqlParameter("@CodHinario", Convert.ToInt16(objEnt_Hino.CodHinario) as object));
                        objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt64(objEnt_Hino.CodInstrumento) as object));

                        blnRetorno = objAcessa.executar(strUpdate, objParam);
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
        /// Função que retorna os Registros da tabela Instrumento Hinario, pesquisado pelo CodInstrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarInstrumentoHinario(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE IH.CodInstrumento = @CodInstrumento ORDER BY H.DescHinario ", objParam, "InstrumentoHinario");
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
        /// Função que retorna os Registros da tabela Hinario, pesquisado pelo CodHinario.*\
        /// Essa Consulta retorna os valores que não estão na Tabela InstrumentoHinario
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarHinarios(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelectVoz + "WHERE CodInstrumento = @CodInstrumento) ORDER BY DescHinario ", objParam, "Hinario");
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
        /// Função que retorna os Registros da tabela Hinario, pesquisado pelo CodHinario.*\
        /// Essa Consulta retorna os valores que não estão na Tabela InstrumentoHinario
        /// </summary>
        /// <param name="CodHinario"></param>
        /// <returns></returns>
        public DataTable buscarHinarioInstr(string CodHinario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodHinario", CodHinario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE IH.CodHinario = @CodHinario ORDER BY I.DescInstrumento ", objParam, "InstrumentoHinario");
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
                idInstrHino = objAcessa.retornarId(strId);
                return Convert.ToInt32(idInstrHino);
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
