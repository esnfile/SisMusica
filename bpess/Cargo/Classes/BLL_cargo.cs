using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using ENT.pessoa;
using DAL.pessoa;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using ENT.Erros;
using DAL.cargo;

namespace BLL.cargo
{
    public class BLL_cargo : IBLL_Cargo
    {
        IDAL_Cargo objDAL;
        IBLL_buscaCargo objBLL_Cargo;
        IBLL_cargo_Log objBLL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Update(MOD_cargo objEnt, out List<MOD_cargo> listaCargo)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    blnRetorno = true;
                    blnRetornoLog = true;

                    objDAL = new DAL_cargo();
                    objBLL_Log = new BLL_cargo_Log();

                    //Chama a função que converte as datas
                    objEnt.Logs = objBLL_Log.CriarLog(objEnt, "Update");
                    objEnt.Logs = objBLL_Log.ValidaLog(objEnt.Logs);

                    blnRetorno = objDAL.Update(objEnt);
                    blnRetornoLog = new DAL_log().inserir(objEnt.Logs);

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }

                    /*Retorna a lista que foi atualizada na base de dados*/
                    objBLL_Cargo = new BLL_buscaCargoPorCodigo();
                    listaCargo = objBLL_Cargo.Buscar(objEnt.CodCargo);

                    //completa a transação
                    objTrans.Complete();

                    return true;
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
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Insert(MOD_cargo objEnt, out List<MOD_cargo> listaCargo)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    blnRetorno = true;
                    blnRetornoLog = true;

                    objDAL = new DAL_cargo();
                    objBLL_Log = new BLL_cargo_Log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodCargo = Convert.ToString(RetornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = objBLL_Log.CriarLog(objEnt, "Insert");
                    objEnt.Logs = objBLL_Log.ValidaLog(objEnt.Logs);

                    blnRetorno = objDAL.Insert(objEnt);
                    blnRetornoLog = new DAL_log().inserir(objEnt.Logs);

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }

                    /*Retorna a lista que foi atualizada na base de dados*/
                    objBLL_Cargo = new BLL_buscaCargoPorCodigo();
                    listaCargo = objBLL_Cargo.Buscar(objEnt.CodCargo);

                    //completa a transação
                    objTrans.Complete();

                    return true;
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
        public bool Delete(MOD_cargo objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    blnRetorno = true;
                    blnRetornoLog = true;

                    objDAL = new DAL_cargo();
                    objBLL_Log = new BLL_cargo_Log();

                    //Chama a função que converte as datas
                    objEnt.Logs = objBLL_Log.CriarLog(objEnt, "Delete");
                    objEnt.Logs = objBLL_Log.ValidaLog(objEnt.Logs);

                    blnRetorno = objDAL.Delete(objEnt);
                    blnRetornoLog = new DAL_log().inserir(objEnt.Logs);

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
        public Int16 RetornaId()
        {
            try
            {
                objDAL = new DAL_cargo();
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

        public void Dispose()
        {

        }
    }
}