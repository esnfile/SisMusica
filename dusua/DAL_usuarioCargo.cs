using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.acessos;

namespace DAL.Usuario
{
    public class DAL_usuarioCargo
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idCodUsuarioCargo = null;

        #endregion

        #region Strings Sql da tabela UsuarioCargo

        //string de insert na tabela UsuarioCargo
        private string strInsert = "INSERT INTO UsuarioCargo (CodUsuarioCargo, CodUsuario, CodCargo) " +
"VALUES (@CodUsuarioCargo, @CodUsuario, @CodCargo) ";

//        //string de update na tabela UsuarioCargo
//        private string strUpdate = "UPDATE UsuarioCargo SET CodUsuario = @CodUsuario, CodCargo = @CodCargo " +
//"WHERE CodUsuarioCargo = @CodUsuarioCargo ";

        //string de delete na tabela UsuarioCargo
        private string strDelete = "DELETE FROM UsuarioCargo WHERE CodUsuarioCargo = @CodUsuarioCargo ";

        //string de select na tabela UsuarioCargo
        private string strSelect = "SELECT UC.CodUsuarioCargo, UC.CodUsuario, UC.CodCargo, U.CodPessoa, U.Usuario, " +
"P.Nome, C.DescCargo, C.SiglaCargo, C.Ordem, C.Masculino, C.Feminino, C.AtendeGEM, C.AtendeRegiao, C.AtendeComum " +
"FROM UsuarioCargo AS UC " +
"LEFT OUTER JOIN Usuario AS U ON UC.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Cargo AS C ON UC.CodCargo = C.CodCargo " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string de select na tabela Cargo
        private string strSelectCargo = "SELECT C.CodCargo, C.DescCargo, C.SiglaCargo, C.Ordem, C.Masculino, C.Feminino " +
"FROM Cargo AS C " +
"WHERE C.CodCargo NOT IN (SELECT CodCargo FROM UsuarioCargo ";

        //string que retorna o próximo Id da tabela UsuarioCargo
        private string strId = "SELECT MAX (CodUsuarioCargo) FROM UsuarioCargo ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base
        
        /// <summary>
        /// Função que faz INSERT, E DELETE na Tabela UsuarioCargo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_usuarioCargo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela UsuarioCargo
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela UsuarioCargo
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                if (objEnt.Marcado.Equals(true))
                {
                    if (Convert.ToInt64(objEnt.CodUsuarioCargo).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodUsuarioCargo", retornaId()));
                        objParam.Add(new SqlParameter("@CodUsuario", Convert.ToInt64(objEnt.CodUsuario)));
                        objParam.Add(new SqlParameter("@CodCargo", string.IsNullOrEmpty(objEnt.CodCargo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCargo) as object));

                        blnRetorno = objAcessa.executar(strInsert, objParam);
                    }
                }
                else
                {
                    if (!Convert.ToInt64(objEnt.CodUsuarioCargo).Equals(0))
                    {
                        //parametros da tabela principal
                        objParam.Add(new SqlParameter("@CodUsuarioCargo", Convert.ToInt64(objEnt.CodUsuarioCargo)));

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
        /// Função que retorna os Registros da tabela UsuarioCargo, pesquisado pela Usuario
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarUsuarioCargo(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE UC.CodUsuario = @CodUsuario ORDER BY C.Ordem ", objParam, "UsuarioCargo");
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
        /// Essa Consulta retorna os valores que não estão na Tabela UsuarioCargo
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>
        public DataTable buscarCargos(string CodUsuario)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodUsuario", CodUsuario));
                objDtb = objAcessa.retornaDados(strSelectCargo + "WHERE CodUsuario = @CodUsuario) ORDER BY C.Ordem ", objParam, "Cargo");
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
                idCodUsuarioCargo = objAcessa.retornarId(strId);
                return Convert.ToInt64(idCodUsuarioCargo);
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
