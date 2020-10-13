using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.instrumentos;

namespace DAL.instrumentos
{
    public class DAL_teoria
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idTeoria = null;

        #endregion

        #region Strings Sql da tabela Teoria

        //string de insert na tabela Teoria
        private string strInsert = "INSERT INTO Teoria (CodTeoria, DescTeoria, AplicaEm, TipoCadastro, SepararPor, " +
"CodModuloMts, CodFaseMts, Nivel, CodUsuario, DataCadastro, HoraCadastro, Paginas) " +
"VALUES (@CodTeoria, @DescTeoria, @AplicaEm, @TipoCadastro, @SepararPor, @CodModuloMts, @CodFaseMts, @Nivel, " +
"@CodUsuario, @DataCadastro, @HoraCadastro, @Paginas) ";

        //string de update na tabela Teoria
        private string strUpdate = "UPDATE Teoria SET DescTeoria = @DescTeoria, AplicaEm = @AplicaEm, " +
"TipoCadastro = @TipoCadastro, SepararPor = @SepararPor, CodModuloMts = @CodModuloMts, CodFaseMts = @CodFaseMts, " +
"Nivel = @Nivel, CodUsuario = @CodUsuario, DataCadastro = @DataCadastro, HoraCadastro = @HoraCadastro, Paginas = @Paginas " +
"WHERE CodTeoria = @CodTeoria ";

        //string de delete na tabela Teoria
        private string strDelete = "DELETE FROM Teoria WHERE CodTeoria = @CodTeoria ";

        //string de select na tabela Teoria
        private string strSelect = "SELECT T.CodTeoria, T.DescTeoria, T.AplicaEm, T.TipoCadastro, T.SepararPor, " +
"T.CodModuloMts, T.CodFaseMts, T.Nivel, T.CodUsuario, T.DataCadastro, T.HoraCadastro, T.Paginas, M.DescModulo, F.DescFase, " +
"U.CodPessoa, P.Nome " +
"FROM Teoria AS T " +
"LEFT OUTER JOIN MtsModulo AS M ON T.CodModuloMts = M.CodModuloMts " +
"LEFT OUTER JOIN MtsFase AS F ON T.CodFaseMts = F.CodFaseMts " +
"LEFT OUTER JOIN Usuario AS U ON T.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string que retorna o próximo Id da tabela Teoria
        private string strId = "SELECT MAX (CodTeoria) FROM Teoria ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Teoria
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_teoria objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Teoria
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTeoria", Convert.ToInt16(objEnt.CodTeoria)));
                objParam.Add(new SqlParameter("@DescTeoria", string.IsNullOrEmpty(objEnt.DescTeoria) ? DBNull.Value as object : objEnt.DescTeoria as object));
                objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm as object));
                objParam.Add(new SqlParameter("@TipoCadastro", string.IsNullOrEmpty(objEnt.TipoCadastro) ? DBNull.Value as object : objEnt.TipoCadastro as object));
                objParam.Add(new SqlParameter("@SepararPor", string.IsNullOrEmpty(objEnt.SepararPor) ? DBNull.Value as object : objEnt.SepararPor as object));
                objParam.Add(new SqlParameter("@CodModuloMts", string.IsNullOrEmpty(objEnt.CodModuloMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodModuloMts) as object));
                objParam.Add(new SqlParameter("@CodFaseMts", string.IsNullOrEmpty(objEnt.CodFaseMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodFaseMts) as object));
                objParam.Add(new SqlParameter("@Nivel", string.IsNullOrEmpty(objEnt.Nivel) ? DBNull.Value as object : objEnt.Nivel as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object));
                objParam.Add(new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(objEnt.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCadastro) as object));
                objParam.Add(new SqlParameter("@Paginas", string.IsNullOrEmpty(objEnt.Paginas) ? DBNull.Value as object : Convert.ToInt16(objEnt.Paginas) as object));
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
        /// Função que faz INSERT na Tabela Teoria
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_teoria objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Teoria
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTeoria", Convert.ToInt16(objEnt.CodTeoria)));
                objParam.Add(new SqlParameter("@DescTeoria", string.IsNullOrEmpty(objEnt.DescTeoria) ? DBNull.Value as object : objEnt.DescTeoria as object));
                objParam.Add(new SqlParameter("@AplicaEm", string.IsNullOrEmpty(objEnt.AplicaEm) ? DBNull.Value as object : objEnt.AplicaEm as object));
                objParam.Add(new SqlParameter("@TipoCadastro", string.IsNullOrEmpty(objEnt.TipoCadastro) ? DBNull.Value as object : objEnt.TipoCadastro as object));
                objParam.Add(new SqlParameter("@SepararPor", string.IsNullOrEmpty(objEnt.SepararPor) ? DBNull.Value as object : objEnt.SepararPor as object));
                objParam.Add(new SqlParameter("@CodModuloMts", string.IsNullOrEmpty(objEnt.CodModuloMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodModuloMts) as object));
                objParam.Add(new SqlParameter("@CodFaseMts", string.IsNullOrEmpty(objEnt.CodFaseMts) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodFaseMts) as object));
                objParam.Add(new SqlParameter("@Nivel", string.IsNullOrEmpty(objEnt.Nivel) ? DBNull.Value as object : objEnt.Nivel as object));
                objParam.Add(new SqlParameter("@CodUsuario", string.IsNullOrEmpty(objEnt.CodUsuario) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodUsuario) as object));
                objParam.Add(new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object));
                objParam.Add(new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(objEnt.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCadastro) as object));
                objParam.Add(new SqlParameter("@Paginas", string.IsNullOrEmpty(objEnt.Paginas) ? DBNull.Value as object : Convert.ToInt16(objEnt.Paginas) as object));

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
        /// Função que faz DELETE na Tabela Teoria
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_teoria objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Teoria
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodTeoria", Convert.ToInt16(objEnt.CodTeoria)));
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo Código
        /// </summary>
        /// <param name="CodTeoria"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodTeoria)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodTeoria))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTeoria", CodTeoria));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY T.CodTeoria ", objParam, "Teoria");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodTeoria", CodTeoria));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE T.CodTeoria = @CodTeoria ORDER BY T.CodTeoria", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pela Descrição
        /// </summary>
        /// <param name="DescTeoria"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescTeoria)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescTeoria", DescTeoria));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.DescTeoria LIKE @DescTeoria ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pela Descrição e Tipo Cadastro
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="DescTeoria"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescTeoria, string TipoCadastro)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescTeoria", DescTeoria));
                objParam.Add(new SqlParameter("@TipoCadastro", TipoCadastro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.DescTeoria LIKE @DescTeoria AND T.TipoCadastro = @TipoCadastro ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo AplicaEm
        /// <para> AplicaEm = GEM, RJM, Culto Oficial, Oficialização</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarAplicaEm(string AplicaEm)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.AplicaEm = @AplicaEm ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo AplicaEm e TipoCadastro
        /// <para> AplicaEm = GEM, RJM, Culto Oficial, Oficialização</para>
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public DataTable buscarAplicaEm(string AplicaEm, string TipoCadastro)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objParam.Add(new SqlParameter("@TipoCadastro", TipoCadastro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.AplicaEm = @AplicaEm AND T.TipoCadastro = @TipoCadastro ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo Nivel
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// </summary>
        /// <param name="Nivel"></param>
        /// <returns></returns>
        public DataTable buscarNivel(string Nivel)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nivel", Nivel));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.Nivel = @Nivel ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo Nivel e AplicaEm
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// <para> AplicaEm = GEM, Reunião de Jovens, Meia Hora, Culto Oficial, Oficialização</para>
        /// </summary>
        /// <param name="Nivel"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarNivel(string Nivel, string AplicaEm)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nivel", Nivel));
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.Nivel = @Nivel AND T.AplicaEm = @AplicaEm ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo Nivel, AplicaEm e TipoCadastro
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// <para> AplicaEm = GEM, Reunião de Jovens, Meia Hora, Culto Oficial, Oficialização</para>
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="Nivel"></param>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public DataTable buscarNivel(string Nivel, string AplicaEm, string TipoCadastro)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nivel", Nivel));
                objParam.Add(new SqlParameter("@AplicaEm", AplicaEm));
                objParam.Add(new SqlParameter("@TipoCadastro", TipoCadastro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.Nivel = @Nivel AND T.AplicaEm = @AplicaEm AND T.TipoCadastro = @TipoCadastro ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo ModuloMts
        /// </summary>
        /// <param name="CodModuloMts"></param>
        /// <returns></returns>
        public DataTable buscarModulo(string CodModuloMts)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodModuloMts", CodModuloMts));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.CodModuloMts = @CodModuloMts ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo ModuloMts e TipoCadastro
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="CodModuloMts"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public DataTable buscarModulo(string CodModuloMts, string TipoCadastro)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodModuloMts", CodModuloMts));
                objParam.Add(new SqlParameter("@TipoCadastro", TipoCadastro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.CodModuloMts = @CodModuloMts AND T.TipoCadastro = @TipoCadastro ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo FaseMts
        /// </summary>
        /// <param name="CodFaseMts"></param>
        /// <returns></returns>
        public DataTable buscarFase(string CodFaseMts)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFaseMts", CodFaseMts));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.CodFaseMts = @CodFaseMts ORDER BY T.DescTeoria ", objParam, "Teoria");
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
        /// Função que retorna os Registros da tabela Teoria, pesquisado pelo FaseMts e TipoCadastro
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="CodFaseMts"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public DataTable buscarFase(string CodFaseMts, string TipoCadastro)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodFaseMts", CodFaseMts));
                objParam.Add(new SqlParameter("@TipoCadastro", TipoCadastro));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE T.CodFaseMts = @CodFaseMts AND T.TipoCadastro = @TipoCadastro ORDER BY T.DescTeoria ", objParam, "Teoria");
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
                idTeoria = objAcessa.retornarId(strId);
                return Convert.ToInt16(idTeoria);
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
