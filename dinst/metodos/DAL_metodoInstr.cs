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
    public class DAL_metodoInstr
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela solicitada
        object idMetInstr = null;

        #endregion

        #region Strings Sql da tabela MetodoInstr

        //string de insert na tabela MetodoInstr
        private string strInsert = "INSERT INTO MetodoInstr (CodMetodoInstr, CodInstrumento, CodMetodo, AplicarEm, FaseInicio, " + 
"PaginaInicio, LicaoInicio, FaseFim, PaginaFim, LicaoFim) " +
"VALUES (@CodMetodoInstr, @CodInstrumento, @CodMetodo, @AplicarEm, @FaseInicio, @PaginaInicio, @LicaoInicio, @FaseFim, @PaginaFim, @LicaoFim) ";

        //string de update na tabela MetodoInstr
        private string strUpdate = "UPDATE MetodoInstr SET CodInstrumento = @CodInstrumento, CodMetodo = @CodMetodo, " +
"AplicarEm = @AplicarEm, FaseInicio = @FaseInicio, PaginaInicio = @PaginaInicio, LicaoInicio = @LicaoInicio, FaseFim = @FaseFim, PaginaFim = @PaginaFim, LicaoFim = @LicaoFim " +
"WHERE CodMetodoInstr = @CodMetodoInstr ";


        //string de delete na tabela MetodoInstr
        private string strDelete = "DELETE FROM MetodoInstr WHERE CodMetodoInstr = @CodMetodoInstr ";

        //string de select na tabela MetodoInstr
        private string strSelect = "SELECT MI.CodMetodoInstr, MI.CodInstrumento, MI.CodMetodo, MI.AplicarEm, MI.FaseInicio, MI.PaginaInicio, " +
"MI.LicaoInicio, MI.FaseFim, MI.PaginaFim, MI.LicaoFim, I.DescInstrumento, M.DescMetodo, M.Tipo, M.TipoEscolha, M.PaginaFase " +
"FROM MetodoInstr AS MI " +
"LEFT OUTER JOIN Instrumentos AS I ON MI.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Metodos AS M ON MI.CodMetodo = M.CodMetodo ";

        //string que retorna o próximo Id da tabela MetodoInstr
        private string strId = "SELECT MAX (CodMetodoInstr) FROM MetodoInstr ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT, UPDATE na Tabela Metodo Instrumento
        /// </summary>
        /// <param name="objEnt_Met"></param>
        /// <returns></returns>
        public bool salvar(MOD_metodoInstr objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Metodo Instrumento
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela Metodo Instrumento
                List<SqlParameter> objParam = new List<SqlParameter>();

                //Verifica os critério se vai para ser Inserido ou vai para Exclusão
                //se não possuir código, é feita a inclusao na tabela
                if (objEnt.CodMetodoInstr.Equals(string.Empty))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodMetodoInstr", retornaId()));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@AplicarEm", string.IsNullOrEmpty(objEnt.AplicarEm) ? DBNull.Value as object : objEnt.AplicarEm));
                    objParam.Add(new SqlParameter("@FaseInicio", string.IsNullOrEmpty(objEnt.FaseInicio) ? DBNull.Value as object : objEnt.FaseInicio));
                    objParam.Add(new SqlParameter("@PaginaInicio", string.IsNullOrEmpty(objEnt.PaginaInicio) ? DBNull.Value as object : objEnt.PaginaInicio));
                    objParam.Add(new SqlParameter("@LicaoInicio", string.IsNullOrEmpty(objEnt.LicaoInicio) ? DBNull.Value as object : objEnt.LicaoInicio));
                    objParam.Add(new SqlParameter("@FaseFim", string.IsNullOrEmpty(objEnt.FaseFim) ? DBNull.Value as object : objEnt.FaseFim));
                    objParam.Add(new SqlParameter("@PaginaFim", string.IsNullOrEmpty(objEnt.PaginaFim) ? DBNull.Value as object : objEnt.PaginaFim));
                    objParam.Add(new SqlParameter("@LicaoFim", string.IsNullOrEmpty(objEnt.LicaoFim) ? DBNull.Value as object : objEnt.LicaoFim));

                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodMetodoInstr", Convert.ToInt16(objEnt.CodMetodoInstr)));
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@CodMetodo", string.IsNullOrEmpty(objEnt.CodMetodo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodMetodo) as object));
                    objParam.Add(new SqlParameter("@AplicarEm", string.IsNullOrEmpty(objEnt.AplicarEm) ? DBNull.Value as object : objEnt.AplicarEm));
                    objParam.Add(new SqlParameter("@FaseInicio", string.IsNullOrEmpty(objEnt.FaseInicio) ? DBNull.Value as object : objEnt.FaseInicio));
                    objParam.Add(new SqlParameter("@PaginaInicio", string.IsNullOrEmpty(objEnt.PaginaInicio) ? DBNull.Value as object : objEnt.PaginaInicio));
                    objParam.Add(new SqlParameter("@LicaoInicio", string.IsNullOrEmpty(objEnt.LicaoInicio) ? DBNull.Value as object : objEnt.LicaoInicio));
                    objParam.Add(new SqlParameter("@FaseFim", string.IsNullOrEmpty(objEnt.FaseFim) ? DBNull.Value as object : objEnt.FaseFim));
                    objParam.Add(new SqlParameter("@PaginaFim", string.IsNullOrEmpty(objEnt.PaginaFim) ? DBNull.Value as object : objEnt.PaginaFim));
                    objParam.Add(new SqlParameter("@LicaoFim", string.IsNullOrEmpty(objEnt.LicaoFim) ? DBNull.Value as object : objEnt.LicaoFim));

                    blnRetorno = objAcessa.executar(strUpdate, objParam);
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

        /// <summary>
        /// Função que faz DELETE na Tabela Metodo Instrumento
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_metodoInstr objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Metodo Instrumento
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela Metodo Instrumento
                List<SqlParameter> objParam = new List<SqlParameter>();
                if (!objEnt.CodMetodoInstr.Equals(string.Empty))
                {
                    //se estiver marcado, é feita o delete
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodMetodoInstr", Convert.ToInt16(objEnt.CodMetodoInstr)));

                    blnRetorno = objAcessa.executar(strDelete, objParam);
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
        /// Função que retorna os Registros da tabela Metodos, pesquisado pelo Código
        /// </summary>
        /// <param name="CodMetodoInstr"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodMetodoInstr)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodMetodoInstr))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodMetodoInstr", CodMetodoInstr));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY MI.CodMetodoInstr ", objParam, "MetodoInstr");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodMetodoInstr", CodMetodoInstr));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.CodMetodoInstr = @CodMetodoInstr ORDER BY CodMetodoInstr", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.CodInstrumento = @CodInstrumento ORDER BY MI.AplicarEm, M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo Instrumento e Aplicaçao
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento, string AplicarEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@AplicarEm", AplicarEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.CodInstrumento = @CodInstrumento AND MI.AplicarEm = @AplicarEm ORDER BY MI.AplicarEm, M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo Instrumento, Aplicaçao e Tipo Metodo
        /// <para> TipoMetodo In('Solfejo', 'Ritmo' ou 'Instrumento'))</para>
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoMetodo"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento, string AplicarEm, string TipoMetodo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@AplicarEm", AplicarEm));
                objParam.Add(new SqlParameter("@TipoMetodo", TipoMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.CodInstrumento = @CodInstrumento AND MI.AplicarEm = @AplicarEm AND M.Tipo IN(@TipoMetodo) ORDER BY MI.AplicarEm, M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo Metodo
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public DataTable buscarMetodo(string CodMetodo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.CodMetodo = @CodMetodo ORDER BY MI.AplicarEm, M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo Metodo e Aplicação
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarMetodo(string CodMetodo, string AplicarEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objParam.Add(new SqlParameter("@AplicarEm", AplicarEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.CodMetodo = @CodMetodo AND MI.AplicarEm = @AplicarEm ORDER BY MI.AplicarEm, M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo Metodo, Aplicação e Instrumento
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <param name="AplicaEm"></param>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarMetodo(string CodMetodo, string AplicarEm, string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodMetodo", CodMetodo));
                objParam.Add(new SqlParameter("@AplicarEm", AplicarEm));
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.CodMetodo = @CodMetodo AND MI.AplicarEm = @AplicarEm ORDER BY MI.AplicarEm, M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pela Aplicação
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public DataTable buscarAplica(string AplicarEm)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicarEm", AplicarEm));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.AplicarEm = @AplicarEm ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pela Aplicação
        /// <para> TipoMetodo In('Solfejo', 'Ritmo' ou 'Instrumento'))</para>
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoMetodo"></param>
        /// <returns></returns>
        public DataTable buscarAplica(string AplicarEm, string TipoMetodo)
        {
            try
            {
                //declara a lista de parametros
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@AplicarEm", AplicarEm));
                objParam.Add(new SqlParameter("@TipoMetodo", TipoMetodo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE MI.AplicarEm = @AplicarEm AND M.Tipo IN(@TipoMetodo) ORDER BY M.DescMetodo ", objParam, "MetodoInstr");
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
                idMetInstr = objAcessa.retornarId(strId);
                return Convert.ToInt16(idMetInstr);
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