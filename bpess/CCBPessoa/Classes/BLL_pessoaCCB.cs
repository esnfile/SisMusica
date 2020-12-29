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
    public class BLL_pessoaCCB : IBLL_PessoaCCB
    {

        IDAL_PessoaCCB objDAL;
        IBLL_buscaPessoaCCB objBLL;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool Insert(List<MOD_pessoaCCB> lista)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    blnRetorno = true;
                    blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (lista != null && lista.Count > 0)
                    {
                        objDAL = new DAL_pessoaCCB();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_pessoaCCB ent in lista)
                        {
                            //busca o registro para ver se já está na base de dados
                            List<MOD_pessoaCCB> listaBase = new List<MOD_pessoaCCB>();
                            objBLL = new BLL_buscaCCBPessoaPorPessoaCCB();
                            listaBase = objBLL.Buscar(ent.CodPessoa, ent.CodCCB);

                            if (listaBase.Count < 1)
                            {
                                //Chama a função que converte as datas
                                ent.Logs = new BLL_pessoaCCB_Log().CriarLog(ent, "Insert");
                                ent.Logs = new BLL_pessoaCCB_Log().ValidaLog(ent.Logs);

                                blnRetorno = objDAL.Insert(ent);
                                blnRetornoLog = new DAL_log().inserir(ent.Logs);

                                //verifica se o retorno foi false e sai do foreach
                                if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.msgSalvar);
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
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool Delete(List<MOD_pessoaCCB> lista)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    blnRetorno = true;
                    blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (lista != null && lista.Count > 0)
                    {
                        objDAL = new DAL_pessoaCCB();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_pessoaCCB ent in lista)
                        {
                            //busca o registro para ver se já está na base de dados
                            List<MOD_pessoaCCB> listaBase = new List<MOD_pessoaCCB>();
                            listaBase = objBLL.Buscar(ent.CodPessoa, ent.CodCCB);

                            if (listaBase.Count > 0)
                            {
                                //Chama a função que converte as datas
                                ent.Logs = new BLL_pessoaCCB_Log().CriarLog(ent, "Delete");
                                ent.Logs = new BLL_pessoaCCB_Log().ValidaLog(ent.Logs);

                                blnRetorno = objDAL.Delete(ent);
                                blnRetornoLog = new DAL_log().inserir(ent.Logs);

                                //verifica se o retorno foi false e sai do for
                                if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.msgSalvar);
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