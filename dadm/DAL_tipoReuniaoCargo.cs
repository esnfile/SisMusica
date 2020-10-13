using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.administracao;

namespace DAL.administracao
{
    public class DAL_tipoReuniaoCargo
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idTipoReuniaoCargo = null;

        #endregion

        #region Strings Sql da tabela TipoReuniaoCargo

        //string de insert na tabela TipoReuniaoCargo
        private string strInsert = "INSERT INTO TipoReuniaoCargo (CodCargoReuniao, CodTipoReuniao, CodCargo) " +
"VALUES (@CodCargoReuniao, @CodTipoReuniao, @CodCargo) ";

//        //string de update na tabela TipoReuniaoCargo
//        private string strUpdate = "UPDATE TipoReuniaoCargo SET CodTipoReuniao = @CodTipoReuniao, CodCargo = @CodCargo " +
//"WHERE CodCargoReuniao = @CodCargoReuniao ";

        //string de delete na tabela TipoReuniaoCargo
        private string strDelete = "DELETE FROM TipoReuniaoCargo WHERE CodCargoReuniao = @CodCargoReuniao ";

        //string de select na tabela TipoReuniaoCargo
        private string strSelect = "SELECT TR.CodCargoReuniao, TR.CodTipoReuniao, TR.CodCargo, T.DescTipoReuniao, " +
"C.DescCargo, C.SiglaCargo, C.Ordem, C.Masculino, C.Feminino " +
"FROM TipoReuniaoCargo AS TR " +
"LEFT OUTER JOIN TipoReuniao AS T ON TR.CodTipoReuniao = T.CodTipoReuniao " +
"LEFT OUTER JOIN Cargo AS C ON TR.CodCargo = C.CodCargo ";

        //string de select na tabela Cargo
        private string strSelectCargo = "SELECT C.CodCargo, C.DescCargo, C.SiglaCargo, C.Ordem, C.Masculino, C.Feminino " +
"FROM Cargo AS C " +
"WHERE C.CodCargo NOT IN (SELECT CodCargo FROM TipoReuniaoCargo ";

        //string de select na tabela Cargo
        private string strSelectUsuarioCargo = "SELECT UC.CodUsuarioCargo, UC.CodUsuario, UC.CodCargo, U.CodPessoa, U.Usuario, " +
"P.Nome, C.DescCargo, C.SiglaCargo, C.Ordem, C.Masculino, C.Feminino " +
"FROM UsuarioCargo AS UC " +
"LEFT OUTER JOIN Usuario AS U ON UC.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Cargo AS C ON UC.CodCargo = C.CodCargo " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string que retorna o próximo Id da tabela TipoReuniaoCargo
        private string strId = "SELECT MAX (CodCargoReuniao) FROM TipoReuniaoCargo ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base
        
        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela TipoReuniaoCargo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_tipoReuniaoCargo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TipoReuniaoCargo
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela TipoReuniaoCargo
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt.CodCargoReuniao).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodCargoReuniao", retornaId()));
                        objParam.Add(new SqlParameter("@CodTipoReuniao", Convert.ToInt16(objEnt.CodTipoReuniao)));
                        objParam.Add(new SqlParameter("@CodCargo", string.IsNullOrEmpty(objEnt.CodCargo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCargo) as object));

                        blnRetorno = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt.CodCargoReuniao).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodCargoReuniao", Convert.ToInt32(objEnt.CodCargoReuniao)));

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
        /// Função que retorna os Registros da tabela TipoReuniaoCargo, pesquisado pela DescTipoReuniao
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <returns></returns>
        public DataTable buscarTipoReuniaoCargo(string CodTipoReuniao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodTipoReuniao", CodTipoReuniao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE TR.CodTipoReuniao = @CodTipoReuniao ORDER BY C.Ordem ", objParam, "TipoReuniaoCargo");
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
        /// Função que retorna os Registros da tabela Cargo, pesquisado pelo CodCargo.*\
        /// Essa Consulta retorna os valores que não estão na Tabela TipoReuniaoCargo
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <returns></returns>
        public DataTable buscarCargos(string CodTipoReuniao)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodTipoReuniao", CodTipoReuniao));
                objDtb = objAcessa.retornaDados(strSelectCargo + "WHERE CodTipoReuniao = @CodTipoReuniao) ORDER BY C.Ordem ", objParam, "Cargo");
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
        /// Função que retorna os Registros da tabela Cargo, pesquisado pelo CodCargo.*\
        /// Essa Consulta retorna os valores que não estão na Tabela TipoReuniaoCargo
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioCargo(string CodTipoReuniao, string CodUsuario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodTipoReuniao", CodTipoReuniao));
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelectUsuarioCargo + "WHERE UC.CodUsuario = @CodUsuario AND UC.CodCargo IN(SELECT CodCargo FROM TipoReuniaoCargo WHERE CodTipoReuniao = @CodTipoReuniao) ORDER BY C.Ordem ", objParam, "UsuarioCargo");
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
                idTipoReuniaoCargo = objAcessa.retornarId(strId);
                return Convert.ToInt32(idTipoReuniaoCargo);
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