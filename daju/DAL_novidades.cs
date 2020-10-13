using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using DAL.Acessa;
using ENT.ajuda;

namespace DAL.ajuda
{
    public class DAL_novidades
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idNovidade = null;

        #endregion

        #region Strings Sql da tabela Novidades

        //string de insert na tabela Novidades
        private string strInsert = "INSERT INTO Novidades (CodNovidades, Data, Status, CodPrograma, " +
"Descricao, TipoAtualiza, Andamento) " +
"VALUES (@CodNovidades, @Data, @Status, @CodPrograma, @Descricao, @TipoAtualiza, @Andamento) ";

        //string de update na tabela Novidades
        private string strUpdate = "UPDATE Novidades SET Data = @Data, Status = @Status, CodPrograma = @CodPrograma, " +
"Descricao = @Descricao, TipoAtualiza = @TipoAtualiza, Andamento = @Andamento " +
"WHERE CodNovidades = @CodNovidades ";

        //string de delete na tabela Novidades
        private string strDelete = "DELETE FROM Novidades WHERE CodNovidades = @CodNovidades ";

        //string de select na tabela Novidades
        private string strSelect = "SELECT N.CodNovidades, N.Data, N.Status, N.CodPrograma, N.Descricao, N.TipoAtualiza, N.Andamento, " +
"P.DescPrograma, P.CodSubModulo, P.NivelProg, S.DescSubModulo, S.NivelSub, S.CodModulo, M.DescModulo, M.NivelMod " +
"FROM Novidades AS N " +
"LEFT OUTER JOIN Programas AS P ON N.CodPrograma = P.CodPrograma " +
"LEFT OUTER JOIN SubModulos AS S ON P.CodSubModulo = S.CodSubModulo " +
"LEFT OUTER JOIN Modulos AS M ON S.CodModulo = M.CodModulo ";

        //string que retorna o próximo Id da tabela Novidades
        private string strId = "SELECT MAX (CodNovidades) FROM Novidades ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Novidades
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_novidades objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Novidades
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodNovidades", Convert.ToInt32(objEnt.CodNovidades)));
                objParam.Add(new SqlParameter("@Data", string.IsNullOrEmpty(objEnt.Data) ? DBNull.Value as object : Convert.ToInt32(objEnt.Data) as object));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
                objParam.Add(new SqlParameter("@CodPrograma", string.IsNullOrEmpty(objEnt.CodPrograma) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodPrograma) as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));
                objParam.Add(new SqlParameter("@TipoAtualiza", string.IsNullOrEmpty(objEnt.TipoAtualiza) ? DBNull.Value as object : objEnt.TipoAtualiza as object));
                objParam.Add(new SqlParameter("@Andamento", string.IsNullOrEmpty(objEnt.Andamento) ? DBNull.Value as object : objEnt.Andamento as object));
                blnRetorno = objAcessa.executar(strUpdate, objParam);

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

        /// <summary>
        /// Função que faz INSERT na Tabela Novidades
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_novidades objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Novidades
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodNovidades", Convert.ToInt32(objEnt.CodNovidades)));
                objParam.Add(new SqlParameter("@Data", string.IsNullOrEmpty(objEnt.Data) ? DBNull.Value as object : Convert.ToInt32(objEnt.Data) as object));
                objParam.Add(new SqlParameter("@Status", string.IsNullOrEmpty(objEnt.Status) ? DBNull.Value as object : objEnt.Status as object));
                objParam.Add(new SqlParameter("@CodPrograma", string.IsNullOrEmpty(objEnt.CodPrograma) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodPrograma) as object));
                objParam.Add(new SqlParameter("@Descricao", string.IsNullOrEmpty(objEnt.Descricao) ? DBNull.Value as object : objEnt.Descricao as object));
                objParam.Add(new SqlParameter("@TipoAtualiza", string.IsNullOrEmpty(objEnt.TipoAtualiza) ? DBNull.Value as object : objEnt.TipoAtualiza as object));
                objParam.Add(new SqlParameter("@Andamento", string.IsNullOrEmpty(objEnt.Andamento) ? DBNull.Value as object : objEnt.Andamento as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

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

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela Novidades
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_novidades objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Novidades
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodNovidades", Convert.ToInt32(objEnt.CodNovidades)));
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
        /// Função que retorna os Registros da tabela Novidades, pesquisado pelo Código
        /// </summary>
        /// <param name="CodNovidades"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodNovidades)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodNovidades))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodNovidades", CodNovidades));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY N.CodNovidades ", objParam, "Novidades");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodNovidades", CodNovidades));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE N.CodNovidades = @CodNovidades ORDER BY N.CodNovidades", objParam, "Novidades");
                    return objDtb;
                }
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
        /// Função que retorna os Registros da tabela Novidades, pesquisado pela Data
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public DataTable buscarData(string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE N.Data BETWEEN @DataInicial AND DataFinal ORDER BY N.Data ", objParam, "Novidades");
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
        /// Função que retorna os Registros da tabela Novidades, pesquisado pelo Status
        /// <para>[Status]='Correção de Erros' OR [Status]='Novos Recursos' OR [Status]='Melhorias Internas'</para>
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarStatus(string Status)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Status", Status));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE N.Status = @Status ORDER BY N.Data, N.Descricao ", objParam, "Novidades");
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
        /// Função que retorna os Registros da tabela Novidades, pesquisado pelo TipoAtualiza
        /// <para>[TipoAtualiza]='Versão' OR [TipoAtualiza]='Módulos' OR [TipoAtualiza]='Base de Dados'</para>
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public DataTable buscarTipoAtualiza(string TipoAtualiza)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@TipoAtualiza", TipoAtualiza));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE N.TipoAtualiza = @TipoAtualiza ORDER BY N.Data, N.Descricao ", objParam, "Novidades");
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
        /// Função que retorna os Registros da tabela Novidades, pesquisado pelo Andamento
        /// <para>[Andamento]='A Implementar' OR [Andamento]='Em Teste' OR [Andamento]='Aprovada' OR [Andamento]='Publicada'</para>
        /// </summary>
        /// <param name="Andamento"></param>
        /// <returns></returns>
        public DataTable buscarAndamento(string Andamento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Andamento", Andamento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE N.Andamento = @Andamento ORDER BY N.Data, N.Descricao ", objParam, "Novidades");
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
        /// Função que retorna os Registros da tabela Novidades, pesquisado pela Descrição
        /// </summary>
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string Descricao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Descricao", Descricao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE N.Descricao LIKE @Descricao ORDER BY N.Descricao ", objParam, "Novidades");
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
                idNovidade = objAcessa.retornarId(strId);
                return Convert.ToInt32(idNovidade);
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
