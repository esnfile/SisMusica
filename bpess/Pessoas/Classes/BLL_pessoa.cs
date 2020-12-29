using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Transactions;

using ENT.pessoa;
using DAL.pessoa;
using DAL.log;
using BLL.Funcoes;
using BLL.Usuario;

namespace BLL.pessoa
{
    public class BLL_pessoa : IBLL_Pessoa
    {

        #region declarações

        IDAL_Pessoa objDAL;
        IBLL_ValidacaoPessoa objBLL_Valida;
        IBLL_PessoaInstr objBLL_PessoaInstr;
        IBLL_PessoaCCB objBLL_PessoaCCB;
        IBLL_PessoaMetodo objBLL_PessoaMetodo;
        IBLL_PessoaFoto objBLL_PessoaFoto;
        IBLL_buscaPessoa objBLL_BuscaPessoa;

        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoInst;
        bool blnRetornoInstLog;
        bool blnRetornoMet;
        bool blnRetornoMetLog;
        bool blnRetornoCCB;
        bool blnRetornoCCBLog;
        bool blnRetornoCCBDelete;
        bool blnRetornoCCBDeleteLog;
        bool blnRetornoFoto;
        bool blnRetornoLog;

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Update(MOD_pessoa objEnt, out List<MOD_pessoa> listaRetorno)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    if (BLL_Liberacoes.LiberaEdicaoAdm(Convert.ToInt64(objEnt.CodPessoa), new BLL_usuario().buscarPessoa(objEnt.CodPessoa)))
                        throw new Exception(modulos.acessoNegado);

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoInst = true;
                    blnRetornoMet = true;
                    blnRetornoFoto = true;
                    blnRetornoLog = true;
                    blnRetornoCCB = true;
                    blnRetornoCCBLog = true;
                    blnRetornoCCBDelete = true;
                    blnRetornoCCBDeleteLog = true;
                    blnRetornoMetLog = true;
                    blnRetornoInstLog = true;

                    #endregion

                    #region Movimentação da tabela Pessoa e Logs

                    objDAL = new DAL_pessoa();
                    objDAL_Log = new DAL_log();
                    objBLL_Valida = new BLL_ValidacaoPessoa();

                    //Função que valida o Cpf
                    objEnt.Cpf = funcoes.FormataCpf(objEnt.Cpf);

                    //Chama a função que converte as datas
                    objEnt = objBLL_Valida.ConverteData(objEnt);

                    objEnt.Logs = new BLL_pessoa_Log().CriarLog(objEnt, "Update");
                    objEnt.Logs = new BLL_pessoa_Log().ValidaLog(objEnt.Logs);

                    blnRetorno = objDAL.Update(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    //verifica se o retorno foi false retorna Erro
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        throw new Exception(modulos.MsgErroSalvar);
                    }

                    #endregion

                    #region Movimentação da tabela PessoaInstrumento

                    //verifica se há registro na lista
                    if (null != objEnt.listaPessoaInstr && objEnt.listaPessoaInstr.Count > 0)
                    {
                        objBLL_PessoaInstr = new BLL_pessoaInstr();

                        blnRetornoInst = objBLL_PessoaInstr.Update(objEnt.listaPessoaInstr);

                        //verifica se o retorno foi false retorna Erro
                        if (false.Equals(blnRetornoInst))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    #region Movimento na tabela CCBPessoa

                    //verifica se há registro na lista
                    if (null != objEnt.listaCCBPessoa && objEnt.listaCCBPessoa.Count > 0)
                    {
                        objBLL_PessoaCCB = new BLL_pessoaCCB();

                        blnRetornoCCB = objBLL_PessoaCCB.Insert(objEnt.listaCCBPessoa.ToList());

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoCCB))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    //verifica se há registro na lista Delete 
                    if (null != objEnt.listaDeleteCCBPessoa && objEnt.listaDeleteCCBPessoa.Count > 0)
                    {
                        objBLL_PessoaCCB = new BLL_pessoaCCB();

                        blnRetornoCCBDelete = objBLL_PessoaCCB.Delete(objEnt.listaDeleteCCBPessoa);

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoCCBDelete))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    #region Movimentação da tabela PessoaMetodo

                    //verifica se há registro na lista
                    if (objEnt.listaPessoaMet != null && objEnt.listaPessoaMet.Count > 0)
                    {
                        objBLL_PessoaMetodo = new BLL_pessoaMetodo();

                        blnRetornoMet = objBLL_PessoaMetodo.Update(objEnt.listaPessoaMet);

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoMet))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    #region Movimentação da tabela Foto

                    //verifica se há registro na lista Foto
                    if (null != objEnt.FotoPessoa)
                    {
                        objBLL_PessoaFoto = new BLL_pessoaFoto();

                        if ("0" == objEnt.FotoPessoa.CodFoto)
                        {
                            blnRetornoFoto = objBLL_PessoaFoto.Insert(objEnt.FotoPessoa);
                        }
                        else if (null == objEnt.FotoPessoa.Foto)
                        {
                            blnRetornoFoto = objBLL_PessoaFoto.Delete(objEnt.FotoPessoa);
                        }
                        else
                        {
                            blnRetornoFoto = objBLL_PessoaFoto.Update(objEnt.FotoPessoa);
                        }

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoFoto))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog) ||
                        false.Equals(blnRetornoInst) || false.Equals(blnRetornoInstLog) || false.Equals(blnRetornoFoto) ||
                        false.Equals(blnRetornoMet) || false.Equals(blnRetornoMetLog) ||
                        false.Equals(blnRetornoCCB) || false.Equals(blnRetornoCCBDelete) || false.Equals(blnRetornoCCBDeleteLog) ||
                        false.Equals(blnRetornoCCBLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {

                        //Busca o Registro inserido para retornar para gravar na tabela de Importados com sucesso
                        objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodPessoa();
                        listaRetorno = objBLL_BuscaPessoa.Buscar(objEnt.CodPessoa);

                        //completa a transação
                        objTrans.Complete();

                        //Retorna a Confirmação que foi gravado na tabela Pessoa
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
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Insert(MOD_pessoa objEnt, out List<MOD_pessoa> listaRetorno)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoInst = true;
                    blnRetornoInstLog = true;
                    blnRetornoMet = true;
                    blnRetornoMetLog = true;
                    blnRetornoFoto = true;
                    blnRetornoLog = true;
                    blnRetornoCCB = true;
                    blnRetornoCCBLog = true;
                    blnRetornoCCBDelete = true;
                    blnRetornoCCBDeleteLog = true;
                    blnRetornoInstLog = true;

                    #endregion

                    #region Movimentação da tabela Pessoa e Logs

                    objDAL = new DAL_pessoa();
                    objDAL_Log = new DAL_log();
                    objBLL_Valida = new BLL_ValidacaoPessoa();

                    //Função que valida o Cpf
                    objEnt.Cpf = funcoes.FormataCpf(objEnt.Cpf);

                    //Chama a função que converte as datas
                    objEnt = objBLL_Valida.ConverteData(objEnt);

                    //Busca o Novo código da tabela
                    objEnt.CodPessoa = Convert.ToString(RetornaId());

                    objEnt.Logs = new BLL_pessoa_Log().CriarLog(objEnt, "Insert");
                    objEnt.Logs = new BLL_pessoa_Log().ValidaLog(objEnt.Logs);

                    blnRetorno = objDAL.Insert(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    //verifica se o retorno foi false retorna Erro
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        throw new Exception(modulos.MsgErroSalvar);
                    }

                    #endregion

                    #region Movimentação da tabela PessoaInstrumento

                    //verifica se há registro na lista
                    if (null != objEnt.listaPessoaInstr && objEnt.listaPessoaInstr.Count > 0)
                    {
                        objBLL_PessoaInstr = new BLL_pessoaInstr();

                        blnRetornoInst = objBLL_PessoaInstr.Update(objEnt.listaPessoaInstr);

                        //verifica se o retorno foi false retorna Erro
                        if (false.Equals(blnRetornoInst))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    #region Movimento na tabela CCBPessoa

                    //verifica se há registro na lista
                    if (null != objEnt.listaCCBPessoa && objEnt.listaCCBPessoa.Count > 0)
                    {
                        objBLL_PessoaCCB = new BLL_pessoaCCB();

                        blnRetornoCCB = objBLL_PessoaCCB.Insert(objEnt.listaCCBPessoa.ToList());

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoCCB))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    //verifica se há registro na lista Delete 
                    if (null != objEnt.listaDeleteCCBPessoa && objEnt.listaDeleteCCBPessoa.Count > 0)
                    {
                        objBLL_PessoaCCB = new BLL_pessoaCCB();

                        blnRetornoCCBDelete = objBLL_PessoaCCB.Delete(objEnt.listaDeleteCCBPessoa);

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoCCBDelete))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    #region Movimentação da tabela PessoaMetodo

                    //verifica se há registro na lista
                    if (objEnt.listaPessoaMet != null && objEnt.listaPessoaMet.Count > 0)
                    {
                        objBLL_PessoaMetodo = new BLL_pessoaMetodo();

                        blnRetornoMet = objBLL_PessoaMetodo.Update(objEnt.listaPessoaMet);

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoMet))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    #region Movimentação da tabela Foto

                    //verifica se há registro na lista Foto
                    if (null != objEnt.FotoPessoa)
                    {
                        objBLL_PessoaFoto = new BLL_pessoaFoto();

                        if ("0" == objEnt.FotoPessoa.CodFoto)
                        {
                            blnRetornoFoto = objBLL_PessoaFoto.Insert(objEnt.FotoPessoa);
                        }
                        else if (null == objEnt.FotoPessoa.Foto)
                        {
                            blnRetornoFoto = objBLL_PessoaFoto.Delete(objEnt.FotoPessoa);
                        }
                        else
                        {
                            blnRetornoFoto = objBLL_PessoaFoto.Update(objEnt.FotoPessoa);
                        }

                        //verifica se o retorno foi false e sai do for
                        if (false.Equals(blnRetornoFoto))
                        {
                            throw new Exception(modulos.MsgErroSalvar);
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog) ||
                        false.Equals(blnRetornoInst) || false.Equals(blnRetornoInstLog) || false.Equals(blnRetornoFoto) ||
                        false.Equals(blnRetornoMet) || false.Equals(blnRetornoMetLog) ||
                        false.Equals(blnRetornoCCB) || false.Equals(blnRetornoCCBDelete) || false.Equals(blnRetornoCCBDeleteLog) ||
                        false.Equals(blnRetornoCCBLog))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    else
                    {

                        //Busca o Registro inserido para retornar para gravar na tabela de Importados com sucesso
                        objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodPessoa();
                        listaRetorno = objBLL_BuscaPessoa.Buscar(objEnt.CodPessoa);

                        //completa a transação
                        objTrans.Complete();

                        //Retorna a Confirmação que foi gravado na tabela Pessoa
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
        public bool Delete(MOD_pessoa objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    if (!BLL_Liberacoes.LiberaEdicaoAdm(Convert.ToInt64(objEnt.CodPessoa), new BLL_usuario().buscarPessoa(objEnt.CodPessoa)))
                        throw new Exception(modulos.acessoNegado);

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Pessoa e Logs

                    objDAL = new DAL_pessoa();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = new BLL_pessoa_Log().CriarLog(objEnt, "Delete");
                    objEnt.Logs = new BLL_pessoa_Log().ValidaLog(objEnt.Logs);

                    blnRetorno = objDAL.Delete(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

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
                objDAL = new DAL_pessoa();
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