using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

using DAL.Acessa;
using ENT.instrumentos;

namespace DAL.instrumentos
{
    public class DAL_teoriaFoto
    {

        #region declarações
        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idFoto = null;

        #endregion

        #region Strings Sql da tabela TeoriaFoto

        //string de insert na tabela TeoriaFoto
        private string strInsertFoto = "INSERT INTO TeoriaFoto (CodFoto, CodTeoria, Foto, Pagina) " +
"VALUES (@CodFoto, @CodTeoria, @Foto, @Pagina) ";

        //string de update na tabela TeoriaFoto
        private string strUpdateFoto = "UPDATE TeoriaFoto SET CodTeoria = @CodTeoria, Foto = @Foto, Pagina = @Pagina " +
"WHERE CodFoto = @CodFoto ";

        //string de delete na tabela Teoria
        private string strDelete = "DELETE FROM TeoriaFoto WHERE CodFoto = @CodFoto ";

        //string de select na tabela TeoriaFoto
        private string strSelectFoto = "SELECT CodFoto, CodTeoria, Foto, Pagina " +
"FROM TeoriaFoto ";

        //string que retorna o próximo Id da tabela TeoriaFoto
        private string strIdFoto = "SELECT MAX (CodFoto) FROM TeoriaFoto ";

        #endregion

        #region Função para Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT na Tabela TeoriaFoto
        /// </summary>
        /// <param name="objEnt_Foto"></param>
        /// <returns></returns>
        public bool inserir(MOD_teoriaFoto objEnt_Foto)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TeoriaFoto
                bool blnRetornoFoto = true;

                //Declara a lista de parametros da tabela TeoriaFoto
                List<SqlParameter> objParam = new List<SqlParameter>();

                //define um array para armazenar a foto
                byte[] fotoimagem = carregaFoto(objEnt_Foto.Foto);

                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFoto", retornaId()));
                objParam.Add(new SqlParameter("@CodTeoria", string.IsNullOrEmpty(objEnt_Foto.CodTeoria) ? DBNull.Value as object : Convert.ToInt16(objEnt_Foto.CodTeoria) as object));
                objParam.Add(new SqlParameter("@Foto", string.IsNullOrEmpty(objEnt_Foto.Foto) ? DBNull.Value as object : fotoimagem as object));
                objParam.Add(new SqlParameter("@Pagina", string.IsNullOrEmpty(objEnt_Foto.Pagina) ? DBNull.Value as object : objEnt_Foto.Pagina as object));

                blnRetornoFoto = objAcessa.executar(strInsertFoto, objParam);

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

        /// <summary>
        /// Função que faz UPDATE na Tabela TeoriaFoto
        /// </summary>
        /// <param name="objEnt_Foto"></param>
        /// <returns></returns>
        public bool salvar(MOD_teoriaFoto objEnt_Foto)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela TeoriaFoto
                bool blnRetornoFoto = true;

                //Declara a lista de parametros da tabela TeoriaFoto
                List<SqlParameter> objParam = new List<SqlParameter>();

                //define um array para armazenar a foto
                byte[] fotoimagem = carregaFoto(objEnt_Foto.Foto);

                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFoto", string.IsNullOrEmpty(objEnt_Foto.CodFoto) ? DBNull.Value as object : Convert.ToInt16(objEnt_Foto.CodFoto) as object));
                objParam.Add(new SqlParameter("@CodTeoria", string.IsNullOrEmpty(objEnt_Foto.CodTeoria) ? DBNull.Value as object : Convert.ToInt16(objEnt_Foto.CodTeoria) as object));
                objParam.Add(new SqlParameter("@Foto", string.IsNullOrEmpty(objEnt_Foto.Foto) ? DBNull.Value as object : fotoimagem as object));
                objParam.Add(new SqlParameter("@Pagina", string.IsNullOrEmpty(objEnt_Foto.Pagina) ? DBNull.Value as object : objEnt_Foto.Pagina as object));

                blnRetornoFoto = objAcessa.executar(strUpdateFoto, objParam);

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

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela TeoriaFoto 
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_teoriaFoto objEnt_Foto)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Teoria
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFoto", Convert.ToInt16(objEnt_Foto.CodFoto)));
                blnRetorno = objAcessa.executar(strDelete, objParam);

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
        /// Função que retorna os Registros da tabela TeoriaFoto, pesquisado pelo CodTeoria
        /// </summary>
        /// <param name="CodTeoria"></param>
        /// <returns></returns>
        public DataTable buscarTeoriaFoto(string CodTeoria)
        {
            try
            {
                //declara a lista de parametros da segunda tabela Foto Pessoa
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodTeoria", CodTeoria));
                objDtb = objAcessa.retornaDados(strSelectFoto + "WHERE CodTeoria = @CodTeoria ", objParam, "TeoriaFoto");
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

        /// <summary>
        /// Função que retorna os Registros da tabela TeoriaFoto, pesquisado pela Foto
        /// </summary>
        /// <param name="CodFoto"></param>
        /// <returns></returns>
        public DataTable buscarFoto(string CodFoto)
        {
            try
            {
                //declara a lista de parametros da segunda tabela Foto Pessoa
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFoto", CodFoto));
                objDtb = objAcessa.retornaDados(strSelectFoto + "WHERE CodFoto = @CodFoto ", objParam, "TeoriaFoto");
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

        /// <summary>
        /// Função que retorna os Registros da tabela TeoriaFoto, pesquisado pela Foto
        /// </summary>
        /// <param name="CodTeoria"></param>
        /// <returns></returns>
        public DataTable buscarFotos(string CodTeoria)
        {
            try
            {
                //declara a lista de parametros da segunda tabela Foto Pessoa
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodTeoria", CodTeoria));
                objDtb = objAcessa.retornaDados(strSelectFoto + "WHERE CodTeoria = @CodTeoria ", objParam, "TeoriaFoto");
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
