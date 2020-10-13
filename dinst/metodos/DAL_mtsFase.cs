﻿using System;
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
    public class DAL_mtsFase
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idFase = null;

        #endregion

        #region Strings Sql da tabela MtsFase

        //string de insert na tabela MtsFase
        private string strInsert = "INSERT INTO MtsFase (CodFaseMts, DescFase) " +
"VALUES (@CodFaseMts, @DescFase) ";

        //string de update na tabela MtsFase
        private string strUpdate = "UPDATE MtsFase SET DescFase = @DescFase " +
"WHERE CodFaseMts = @CodFaseMts ";

        //string de delete na tabela MtsFase
        private string strDelete = "DELETE FROM MtsFase WHERE CodFaseMts = @CodFaseMts ";

        //string de select na tabela MtsFase
        private string strSelect = "SELECT CodFaseMts, DescFase " +
"FROM MtsFase ";

        //string que retorna o próximo Id da tabela MtsFase
        private string strId = "SELECT MAX (CodFaseMts) FROM MtsFase ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela MtsFase
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_mtsFase objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela MtsFase
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFaseMts", Convert.ToInt16(objEnt.CodFaseMts)));
                objParam.Add(new SqlParameter("@DescFase", string.IsNullOrEmpty(objEnt.DescFase) ? DBNull.Value as object : objEnt.DescFase as object));
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
        /// Função que faz INSERT na Tabela MtsFase
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_mtsFase objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela MtsFase
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFaseMts", Convert.ToInt16(objEnt.CodFaseMts)));
                objParam.Add(new SqlParameter("@DescFase", string.IsNullOrEmpty(objEnt.DescFase) ? DBNull.Value as object : objEnt.DescFase as object));

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
        /// Função que faz DELETE na Tabela MtsFase
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_mtsFase objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela MtsFase
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodFaseMts", Convert.ToInt16(objEnt.CodFaseMts)));
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
        /// Função que retorna os Registros da tabela MtsFase, pesquisado pelo Código
        /// </summary>
        /// <param name="CodFaseMts"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodFaseMts)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodFaseMts))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFaseMts", CodFaseMts));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY CodFaseMts ", objParam, "MtsFase");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodFaseMts", CodFaseMts));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE CodFaseMts = @CodFaseMts ORDER BY CodFaseMts", objParam, "MtsFase");
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
        /// Função que retorna os Registros da tabela MtsFase, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescFase"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescFase)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescFase", DescFase));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE DescFase LIKE @DescFase ORDER BY DescFase ", objParam, "MtsFase");
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
                idFase = objAcessa.retornarId(strId);
                return Convert.ToInt16(idFase);
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
