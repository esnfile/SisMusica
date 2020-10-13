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
    public class DAL_instrumentoVozPrincipal
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idInstrVoz = null;

        #endregion

        #region Strings Sql da tabela InstrumentoVozPrincipal

        //string de insert na tabela InstrumentoVozPrincipal
        private string strInsert = "INSERT INTO InstrumentoVozPrincipal (CodInstrumentoVoz, CodVoz, CodInstrumento, Escrita, Acima, Abaixo) " +
"VALUES (@CodInstrumentoVoz, @CodVoz, @CodInstrumento, @Escrita, @Acima, @Abaixo) ";

        //string de update na tabela InstrumentoVozPrincipal
        private string strUpdate = "UPDATE InstrumentoVozPrincipal SET CodVoz = @CodVoz, CodInstrumento = @CodInstrumento, Escrita = @Escrita, Acima = @Acima, Abaixo = @Abaixo " +
"WHERE CodInstrumentoVoz = @CodInstrumentoVoz ";

        //string de delete na tabela InstrumentoVozPrincipal
        private string strDelete = "DELETE FROM InstrumentoVozPrincipal WHERE CodInstrumentoVoz = @CodInstrumentoVoz ";

        //string de select na tabela InstrumentoVozPrincipal
        private string strSelect = "SELECT IV.CodInstrumentoVoz, IV.CodVoz, IV.CodInstrumento, IV.Escrita, IV.Acima, IV.Abaixo, V.DescVoz, I.DescInstrumento, I.Ordem, I.CodFamilia, F.DescFamilia " +
"FROM InstrumentoVozPrincipal AS IV " +
"LEFT OUTER JOIN Vozes AS V ON IV.CodVoz = V.CodVoz " +
"LEFT OUTER JOIN Instrumentos AS I ON IV.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string de select na tabela Vozes
        private string strSelectVoz = "SELECT CodVoz, DescVoz " +
"FROM Vozes WHERE CodVoz NOT IN (SELECT CodVoz FROM InstrumentoVozPrincipal ";

        //string que retorna o próximo Id da tabela InstrumentoVozPrincipal
        private string strId = "SELECT MAX (CodInstrumentoVoz) FROM InstrumentoVozPrincipal ";

        #endregion

        #region Função para Deletar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela InstrumentoVozPrincipal
        /// </summary>
        /// <param name="objEnt_Voz"></param>
        /// <returns></returns>
        public bool salvar(MOD_instrumentoVozPrincipal objEnt_Voz)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela InstrumentoVozPrincipal
                bool blnRetornoVoz = true;

                //Declara a lista de parametros da tabela InstrumentoVozPrincipal
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt_Voz.Escrita.Equals(false) && objEnt_Voz.Acima.Equals(false) && objEnt_Voz.Abaixo.Equals(false))
                {
                    if (!Convert.ToInt32(objEnt_Voz.CodInstrumentoVoz).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoVoz", objEnt_Voz.CodInstrumentoVoz));
                        blnRetornoVoz = objAcessa.executar(strDelete, objParam);
                    }
                }
                else
                {
                    //verifica se vai ser feita inserção ou atualização
                    if (Convert.ToInt32(objEnt_Voz.CodInstrumentoVoz).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoVoz", retornaId()));
                        objParam.Add(new SqlParameter("@CodVoz", Convert.ToInt16(objEnt_Voz.CodVoz) as object));
                        objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt16(objEnt_Voz.CodInstrumento) as object));
                        objParam.Add(new SqlParameter("@Escrita", objEnt_Voz.Escrita.Equals(true) ? "Sim" : "Não"));
                        objParam.Add(new SqlParameter("@Acima", objEnt_Voz.Acima.Equals(true) ? "Sim" : "Não"));
                        objParam.Add(new SqlParameter("@Abaixo", objEnt_Voz.Abaixo.Equals(true) ? "Sim" : "Não"));

                        blnRetornoVoz = objAcessa.executar(strInsert, objParam);
                    }
                    else
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoVoz", Convert.ToInt64(objEnt_Voz.CodInstrumentoVoz) as object));
                        objParam.Add(new SqlParameter("@CodVoz", Convert.ToInt16(objEnt_Voz.CodVoz) as object));
                        objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt64(objEnt_Voz.CodInstrumento) as object));
                        objParam.Add(new SqlParameter("@Escrita", objEnt_Voz.Escrita.Equals(true) ? "Sim" : "Não"));
                        objParam.Add(new SqlParameter("@Acima", objEnt_Voz.Acima.Equals(true) ? "Sim" : "Não"));
                        objParam.Add(new SqlParameter("@Abaixo", objEnt_Voz.Abaixo.Equals(true) ? "Sim" : "Não"));

                        blnRetornoVoz = objAcessa.executar(strUpdate, objParam);
                    }
                }

                //retorna o blnRetorno da tabela principal
                return blnRetornoVoz;
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
        /// Função que retorna os Registros da tabela Instrumento Voz, pesquisado pelo CodVoz
        /// </summary>
        /// <param name="CodVoz"></param>
        /// <returns></returns>
        public DataTable buscarCodVoz(string CodVoz)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodVoz", CodVoz));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE IV.CodVoz IN(" + @CodVoz + ") ORDER BY I.CodFamilia, I.Ordem ", objParam, "InstrumentoVozPrincipal");
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
        /// Função que retorna os Registros da tabela Instrumento Voz, pesquisado pelo CodVoz
        /// </summary>
        /// <param name="CodVoz"></param>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>
        public DataTable buscarCodVoz(string CodVoz, string CodFamilia)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodVoz", CodVoz));
                objParam.Add(new SqlParameter("@CodFamilia", CodFamilia));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE IV.CodVoz IN(" + @CodVoz + ") AND I.CodFamilia IN(" + @CodFamilia + ") ORDER BY I.CodFamilia, I.Ordem ", objParam, "InstrumentoVozPrincipal");
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
        /// Função que retorna os Registros da tabela Instrumento Voz, pesquisado pelo CodInstrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarInstrumentoVoz(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE IV.CodInstrumento = @CodInstrumento ORDER BY V.CodVoz ", objParam, "InstrumentoVozPrincipal");
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
        /// Função que retorna os Registros da tabela Vozes, pesquisado pelo CodVoz.*\
        /// Essa Consulta retorna os valores que não estão na Tabela InstrumentoVozPrincipal
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarVozes(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelectVoz + "WHERE CodInstrumento = @CodInstrumento) ORDER BY CodVoz ", objParam, "Vozes");
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
                idInstrVoz = objAcessa.retornarId(strId);
                return Convert.ToInt32(idInstrVoz);
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
