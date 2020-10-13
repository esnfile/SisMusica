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
    public class DAL_instrumentoTom
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idInstrTom = null;

        #endregion

        #region Strings Sql da tabela InstrumentoTom

        //string de insert na tabela InstrumentoTom
        private string strInsert = "INSERT INTO InstrumentoTom (CodInstrumentoTom, CodTonalidade, CodInstrumento) " +
"VALUES (@CodInstrumentoTom, @CodTonalidade, @CodInstrumento) ";

        //string de update na tabela InstrumentoTom
        private string strUpdate = "UPDATE InstrumentoTom SET CodTonalidade = @CodTonalidade, CodInstrumento = @CodInstrumento " +
"WHERE CodInstrumentoTom = @CodInstrumentoTom ";

        //string de delete na tabela InstrumentoTom
        private string strDelete = "DELETE FROM InstrumentoTom WHERE CodInstrumentoTom = @CodInstrumentoTom ";

        //string de select na tabela InstrumentoTom
        private string strSelect = "SELECT IT.CodInstrumentoTom, IT.CodTonalidade, IT.CodInstrumento, T.DescTonalidade, I.DescInstrumento " +
"FROM InstrumentoTom AS IT " +
"LEFT OUTER JOIN Tonalidade AS T ON IT.CodTonalidade = T.CodTonalidade " +
"LEFT OUTER JOIN Instrumentos AS I ON IT.CodInstrumento = I.CodInstrumento ";

        //string de select na tabela Tonalidade
        private string strSelectVoz = "SELECT CodTonalidade, DescTonalidade " +
"FROM Tonalidade WHERE CodTonalidade NOT IN (SELECT CodTonalidade FROM InstrumentoTom ";

        //string que retorna o próximo Id da tabela InstrumentoTom
        private string strId = "SELECT MAX (CodInstrumentoTom) FROM InstrumentoTom ";

        #endregion

        #region Função para Deletar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela InstrumentoTom
        /// </summary>
        /// <param name="objEnt_Tom"></param>
        /// <returns></returns>
        public bool salvar(MOD_instrumentoTom objEnt_Tom)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela InstrumentoTom
                bool blnRetornoVoz = true;

                //Declara a lista de parametros da tabela InstrumentoTom
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt_Tom.Marcado.Equals(false))
                {
                    if (!Convert.ToInt32(objEnt_Tom.CodInstrumentoTom).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoTom", objEnt_Tom.CodInstrumentoTom));
                        blnRetornoVoz = objAcessa.executar(strDelete, objParam);
                    }
                }
                else
                {
                    //verifica se vai ser feita inserção ou atualização
                    if (Convert.ToInt32(objEnt_Tom.CodInstrumentoTom).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoTom", retornaId()));
                        objParam.Add(new SqlParameter("@CodTonalidade", Convert.ToInt16(objEnt_Tom.CodTonalidade) as object));
                        objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt16(objEnt_Tom.CodInstrumento) as object));

                        blnRetornoVoz = objAcessa.executar(strInsert, objParam);
                    }
                    else
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodInstrumentoTom", Convert.ToInt64(objEnt_Tom.CodInstrumentoTom) as object));
                        objParam.Add(new SqlParameter("@CodTonalidade", Convert.ToInt16(objEnt_Tom.CodTonalidade) as object));
                        objParam.Add(new SqlParameter("@CodInstrumento", Convert.ToInt64(objEnt_Tom.CodInstrumento) as object));

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
        /// Função que retorna os Registros da tabela Instrumento Voz, pesquisado pelo CodInstrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarInstrumentoTom(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE IT.CodInstrumento = @CodInstrumento ORDER BY T.DescTonalidade ", objParam, "InstrumentoTom");
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
        /// Função que retorna os Registros da tabela Tonalidade, pesquisado pelo CodTonalidade.*\
        /// Essa Consulta retorna os valores que não estão na Tabela InstrumentoTom
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarTonalidades(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelectVoz + "WHERE CodInstrumento = @CodInstrumento) ORDER BY DescTonalidade ", objParam, "Tonalidade");
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
                idInstrTom = objAcessa.retornarId(strId);
                return Convert.ToInt32(idInstrTom);
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
