using System;
using System.Data.SqlClient;
using System.Transactions;

using ENT.importa;
using DAL.importa;
using DAL.log;
using BLL.Funcoes;

namespace BLL.importa
{
    public class BLL_ImportaPessoaItem : IBLL_ImportaPessoaItem
    {

        IDAL_ImportaPessoaItem objDAL;
        IBLL_buscaImportaPessoaItem objBLL;
        DAL_log objDAL_Log = null;

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Insert(MOD_importaPessoaItem objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    bool blnRetorno = true;
                    bool blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (null != objEnt)
                    {
                        if ("0" == objEnt.CodImportaPessoaItem)
                        {
                            objDAL = new DAL_importaPessoaItem();

                            //Chama a função que converte as datas
                            objEnt.Logs = new BLL_importaPessoaItem_Log().CriarLog(objEnt, "Insert");
                            objEnt.Logs = new BLL_importaPessoaItem_Log().ValidaLog(objEnt.Logs);

                            //Busca o proximo ID para inserir o registro
                            objEnt.CodImportaPessoaItem = Convert.ToString(RetornaId());

                            blnRetorno = objDAL.Insert(objEnt);
                            blnRetornoLog = new DAL_log().inserir(objEnt.Logs);
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
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Update(MOD_importaPessoaItem objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    bool blnRetorno = true;
                    bool blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (null != objEnt)
                    {
                        objDAL = new DAL_importaPessoaItem();

                        //Chama a função que converte as datas
                        objEnt.Logs = new BLL_importaPessoaItem_Log().CriarLog(objEnt, "Update");
                        objEnt.Logs = new BLL_importaPessoaItem_Log().ValidaLog(objEnt.Logs);

                        blnRetorno = objDAL.Update(objEnt);
                        blnRetornoLog = new DAL_log().inserir(objEnt.Logs);
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
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Delete(MOD_importaPessoaItem objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    bool blnRetorno = true;
                    bool blnRetornoLog = true;

                    //verifica se há registro na lista
                    if (null != objEnt)
                    {
                        if ("0" != objEnt.CodImportaPessoaItem)
                        {
                            objDAL = new DAL_importaPessoaItem();

                            //Chama a função que converte as datas
                            objEnt.Logs = new BLL_importaPessoaItem_Log().CriarLog(objEnt, "Delete");
                            objEnt.Logs = new BLL_importaPessoaItem_Log().ValidaLog(objEnt.Logs);

                            blnRetorno = objDAL.Delete(objEnt);
                            blnRetornoLog = new DAL_log().inserir(objEnt.Logs);
                        }
                    }

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroExcluir);
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

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 RetornaId()
        {
            try
            {
                objDAL = new DAL_importaPessoaItem();
                return objDAL.RetornaId();
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
    }
}