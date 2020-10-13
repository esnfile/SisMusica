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
    public class DAL_metodoFamilia
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idMetFamilia = null;

        #endregion

        #region Strings Sql da tabela MetodoFamilia

        //string de insert na tabela MetodoFamilia
        private string strInsert = "INSERT INTO MetodoFamilia (CodMetodoFamilia, CodFamilia, CodMetodo) " +
"VALUES (@CodMetodoFamilia, @CodFamilia, @CodMetodo) ";

        //string de delete na tabela MetodoFamilia
        private string strDelete = "DELETE FROM MetodoFamilia WHERE CodMetodoFamilia = @CodMetodoFamilia ";

        //string de select na tabela MetodoFamilia
        private string strSelect = "SELECT MF.CodMetodoFamilia, MF.CodFamilia, MF.CodMetodo, F.DescFamilia, " +
"M.DescMetodo, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase " +
"FROM MetodoFamilia AS MF " +
"LEFT OUTER JOIN Familia AS F ON MF.CodFamilia = F.CodFamilia " +
"LEFT OUTER JOIN Metodos AS M ON MF.CodMetodo = M.CodMetodo ";

        //string de select na tabela Familia
        private string strSelectVoz = "SELECT CodFamilia, DescFamilia " +
"FROM Familia WHERE CodFamilia NOT IN (SELECT CodFamilia FROM MetodoFamilia ";

        //string que retorna o próximo Id da tabela MetodoFamilia
        private string strId = "SELECT MAX (CodMetodoFamilia) FROM MetodoFamilia ";

        #endregion

        #region Função para Deletar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela MetodoFamilia
        /// </summary>
        /// <param name="objEnt_MetFam"></param>
        /// <returns></returns>
        public bool salvar(MOD_metodoFamilia objEnt_MetFam)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela MetodoFamilia
                bool blnRetornoMetFam = true;

                //Declara a lista de parametros da tabela MetodoFamilia
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt_MetFam.Marcado.Equals(true))
                {
                    if (Convert.ToInt16(objEnt_MetFam.CodMetodoFamilia).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodMetodoFamilia", retornaId()));
                        objParam.Add(new SqlParameter("@CodFamilia", Convert.ToInt16(objEnt_MetFam.CodFamilia) as object));
                        objParam.Add(new SqlParameter("@CodMetodo", Convert.ToInt16(objEnt_MetFam.CodMetodo) as object));

                        blnRetornoMetFam = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt16(objEnt_MetFam.CodMetodoFamilia).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodMetodoFamilia", objEnt_MetFam.CodMetodoFamilia));
                        blnRetornoMetFam = objAcessa.executar(strDelete, objParam);
                    }
                }

                //retorna o blnRetorno da tabela principal
                return blnRetornoMetFam;
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
        /// Função que retorna os Registros da tabela Metodo Familia, pesquisado pelo CodMetodo
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarMetodoFamilia(string CodMetodo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MF.CodMetodo = @CodMetodo ORDER BY F.DescFamilia ", objParam, "MetodoFamilia");
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
        /// Função que retorna os Registros da tabela Metodo Familia, pesquisado pela Familia
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>
        public DataTable buscarMetFamilia(string CodFamilia)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFamilia", CodFamilia));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MF.CodFamilia = @CodFamilia ORDER BY M.DescMetodo ", objParam, "MetodoFamilia");
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
        /// Função que retorna os Registros da tabela Metodo Familia, pesquisado pela Familia
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarMetFamilia(string CodFamilia, string Ativo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFamilia", CodFamilia));
                objParam.Add(new SqlParameter("@Ativo", Ativo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MF.CodFamilia = @CodFamilia AND M.Ativo = @Ativo ORDER BY M.DescMetodo ", objParam, "MetodoFamilia");
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
        /// Função que retorna os Registros da tabela Familia, pesquisado pelo CodFamilia.*\
        /// Essa Consulta retorna os valores que não estão na Tabela MetodoFamilia
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarFamilia(string CodMetodo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objDtb = objAcessa.retornaDados(strSelectVoz + "WHERE CodMetodo = @CodMetodo) ORDER BY DescFamilia ", objParam, "Familia");
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
        public Int16 retornaId()
        {
            try
            {
                idMetFamilia = objAcessa.retornarId(strId);
                return Convert.ToInt16(idMetFamilia);
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
