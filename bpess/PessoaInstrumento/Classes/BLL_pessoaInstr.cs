using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.ComponentModel;

using ENT.pessoa;
using DAL.pessoa;
using DAL.uteis;
using ENT.uteis;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using ENT.instrumentos;

namespace BLL.pessoa
{
    public class BLL_pessoaInstr : IBLL_PessoaInstr
    {

        IDAL_PessoaInstr objDAL;
        IBLL_buscaPessoaInstr objBLL;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Update(List<MOD_pessoaInstr> lista)
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
                        objDAL = new DAL_pessoaInstr();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_pessoaInstr ent in lista)
                        {
                            if (true.Equals(ent.Marcado))//Caso o Instruemnto esteja marcado
                            {
                                //busca o registro para ver se já está na base de dados
                                List<MOD_pessoaInstr> listaBase = new List<MOD_pessoaInstr>();
                                objBLL = new BLL_buscaPessoaInstrPorPessoa();
                                listaBase = objBLL.Buscar(ent.CodPessoa, ent.CodInstrumento);

                                if (listaBase.Count < 1)
                                {
                                    //Chama a função que converte as datas
                                    ent.Logs = new BLL_pessoaInstr_Log().CriarLog(ent, "Insert");
                                    ent.Logs = new BLL_pessoaInstr_Log().ValidaLog(ent.Logs);

                                    blnRetorno = objDAL.Insert(ent);
                                    blnRetornoLog  = new DAL_log().inserir(ent.Logs);

                                    //verifica se o retorno foi false e sai do foreach
                                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                                    {
                                        break;
                                    }
                                }
                            }
                            else //Caso o Instruemnto não esteja marcado
                            {
                                //faz o delete na base de dados
                                //busca o registro para ver se já está na base de dados
                                List<MOD_pessoaInstr> listaBase = new List<MOD_pessoaInstr>();
                                objBLL = new BLL_buscaPessoaInstrPorPessoa();
                                listaBase = objBLL.Buscar(ent.CodPessoa, ent.CodInstrumento);

                                if (listaBase.Count > 0)
                                {
                                    //Chama a função que converte as datas
                                    ent.Logs = new BLL_pessoaInstr_Log().CriarLog(ent, "Delete");
                                    ent.Logs = new BLL_pessoaInstr_Log().ValidaLog(ent.Logs);

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