using BLL.Funcoes;
using DAL.log;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;

namespace BLL.pessoa
{
    public class BLL_PessoaImporta : IBLL_PessoaImporta
    {
        IBLL_ValidacaoPessoa objBLL_Valida;
        IBLL_Pessoa objBLL_Pessoa;
        IBLL_buscaPessoa objBLL_BuscaPessoa;
        IBLL_buscaPessoaDuplicada objBLL_PessoaDuplicada;
        DAL_log objDAL_Log;
        List<MOD_pessoa> listaPessoa;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool Import(MOD_pessoa objEnt, out List<MOD_pessoa> listaRetorno)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Pessoa e Logs

                    objBLL_Pessoa = new BLL_pessoa();
                    objDAL_Log = new DAL_log();
                    objBLL_Valida = new BLL_ValidacaoPessoa();

                    //Verifica se já existe o CPF na base de dados e atualiza os dados
                    if (!string.IsNullOrEmpty(objEnt.Cpf) && !objEnt.Cpf.Equals("000.000.000-00"))
                    {
                        List<MOD_pessoa> listaValidaCpf = new List<MOD_pessoa>();
                        IBLL_ValidacaoPessoa objBLL_Validacao = new BLL_ValidacaoPessoa();

                        listaValidaCpf = objBLL_Validacao.ValidaCpfDuplicado(objEnt);

                        if (listaValidaCpf.Count > 0)
                        {
                            if (modulos.listaParametros[0].AlteraDadosImportPessoa.Equals("Sim"))
                            {
                                objEnt.Logs = new BLL_pessoaImporta_Log().CriarLog(objEnt, "Update");
                                objEnt.Logs = new BLL_pessoaImporta_Log().ValidaLog(objEnt.Logs);

                                objEnt.CodPessoa = listaValidaCpf[0].CodPessoa;

                                blnRetorno = objBLL_Pessoa.Update(objEnt, out listaPessoa);
                                blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);
                            }
                        }
                        else
                        {
                            objEnt.Logs = new BLL_pessoaImporta_Log().CriarLog(objEnt, "Insert");
                            objEnt.Logs = new BLL_pessoaImporta_Log().ValidaLog(objEnt.Logs);

                            blnRetorno = objBLL_Pessoa.Insert(objEnt, out listaPessoa);
                            blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);
                        }
                    }
                    else
                    {
                        List<MOD_pessoa> listaPessoaDuplicada = new List<MOD_pessoa>();
                        IBLL_ValidacaoPessoa objBLL_Validacao = new BLL_ValidacaoPessoa();
                        objBLL_PessoaDuplicada = new BLL_buscaPessoaDuplicada();

                        listaPessoaDuplicada = objBLL_PessoaDuplicada.Buscar(objEnt.Nome, objEnt.DataNasc, objEnt.CodCidadeRes);

                        if (listaPessoaDuplicada.Count > 0)
                        {
                            if (modulos.listaParametros[0].AlteraDadosImportPessoa.Equals("Sim"))
                            {
                                objEnt.Logs = new BLL_pessoaImporta_Log().CriarLog(objEnt, "Update");
                                objEnt.Logs = new BLL_pessoaImporta_Log().ValidaLog(objEnt.Logs);

                                objEnt.CodPessoa = listaPessoaDuplicada[0].CodPessoa;

                                blnRetorno = objBLL_Pessoa.Update(objEnt, out listaPessoa);
                                blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);
                            }
                        }
                        else
                        {
                            objEnt.Logs = new BLL_pessoaImporta_Log().CriarLog(objEnt, "Insert");
                            objEnt.Logs = new BLL_pessoaImporta_Log().ValidaLog(objEnt.Logs);

                            blnRetorno = objBLL_Pessoa.Insert(objEnt, out listaPessoa);
                            blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);
                        }
                    }

                    #endregion

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

                        ////Retorna o Registro inserido para gravar na tabela de Importados com sucesso
                        listaRetorno = listaPessoa;

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
    }
}