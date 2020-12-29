using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

using ENT.pessoa;
using DAL.pessoa;
using DAL.log;
using BLL.Funcoes;

namespace BLL.pessoa
{
    public class BLL_pessoaFoto : IBLL_PessoaFoto
    {

        IDAL_PessoaFoto objDAL;
        IBLL_buscaPessoaFoto objBLL;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="pessoaFoto"></param>
        /// <returns></returns>
        public bool Insert(MOD_pessoaFoto pessoaFoto)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    blnRetorno = true;
                    blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (null != pessoaFoto)
                    {
                        if ("0" == pessoaFoto.CodFoto)
                        {
                            objDAL = new DAL_pessoaFoto();

                            //Chama a função que converte as datas
                            pessoaFoto.Logs = new BLL_pessoaFoto_Log().CriarLog(pessoaFoto);
                            pessoaFoto.Logs = new BLL_pessoaFoto_Log().ValidaLog(pessoaFoto.Logs);

                            blnRetorno = objDAL.Insert(pessoaFoto);
                            blnRetornoLog = new DAL_log().inserir(pessoaFoto.Logs);
                        }
                    }

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATe
        /// </summary>
        /// <param name="pessoaFoto"></param>
        /// <returns></returns>
        public bool Update(MOD_pessoaFoto pessoaFoto)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    blnRetorno = true;
                    blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (null != pessoaFoto)
                    {
                        objDAL = new DAL_pessoaFoto();

                        //Chama a função que converte as datas
                        pessoaFoto.Logs = new BLL_pessoaFoto_Log().CriarLog(pessoaFoto);
                        pessoaFoto.Logs = new BLL_pessoaFoto_Log().ValidaLog(pessoaFoto.Logs);

                        blnRetorno = objDAL.Update(pessoaFoto);
                        blnRetornoLog = new DAL_log().inserir(pessoaFoto.Logs);
                    }

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer DELETE
        /// </summary>
        /// <param name="pessoaFoto"></param>
        /// <returns></returns>
        public bool Delete(MOD_pessoaFoto pessoaFoto)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    blnRetorno = true;
                    blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (null != pessoaFoto)
                    {
                        if ("0" != pessoaFoto.CodFoto)
                        {
                            objDAL = new DAL_pessoaFoto();

                            //Chama a função que converte as datas
                            pessoaFoto.Logs = new BLL_pessoaFoto_Log().CriarLog(pessoaFoto);
                            pessoaFoto.Logs = new BLL_pessoaFoto_Log().ValidaLog(pessoaFoto.Logs);

                            blnRetorno = objDAL.Delete(pessoaFoto);
                            blnRetornoLog = new DAL_log().inserir(pessoaFoto.Logs);
                        }
                    }

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw exl;
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw ex;
                }
            }
        }

        #endregion

    }
}