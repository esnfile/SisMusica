using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Transactions;
using DAL.log;
using BLL.Funcoes;
using DAL.importa;
using ENT.importa;
using ENT.pessoa;
using BLL.pessoa;

namespace BLL.importa
{
    public class BLL_importaPessoa : IBLL_ImportaPessoa
    {
        IDAL_ImportaPessoa objDAL;

        IBLL_ValidacaoImporta objBLL_Valida;
        IBLL_ImportaPessoaItem objBLL_ImportaItem;
        IBLL_ImportaPessoaErro objBLL_ImportaErro;
        IBLL_buscaPorCodImportaPessoa objBLL_BuscaImporta;

        DAL_log objDAL_Log = null;

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Update(MOD_importaPessoa objEnt, out List<MOD_importaPessoa> listaRetorno)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    bool blnRetorno = true;
                    bool blnRetornoLog = true;
                    bool blnRetornoItem = true;
                    bool blnRetornoErro = true;
                    bool blnRetornoPessoa = true;

                    #region Movimentação da tabela ImportaPessoa e Logs

                    objDAL = new DAL_importaPessoa();
                    objDAL_Log = new DAL_log();
                    objBLL_Valida = new BLL_ValidacaoImporta();

                    //Chama a função que converte as datas
                    objEnt = objBLL_Valida.ConverteData(objEnt);

                    //Chama a função que converte as datas
                    objEnt.Logs = new BLL_importaPessoa_Log().CriarLog(objEnt, "Update");
                    objEnt.Logs = new BLL_importaPessoa_Log().ValidaLog(objEnt.Logs);

                    blnRetorno = objDAL.Update(objEnt);
                    blnRetornoLog = new DAL_log().inserir(objEnt.Logs);

                    //verifica se o retorno foi false retorna Erro
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        throw new Exception(modulos.MsgErroSalvar);
                    }

                    #endregion

                    #region Movimentação da tabela ImportaPessoaItem

                    //verifica se há registro na lista
                    if (null != objEnt.ListaPessoaItem && objEnt.ListaPessoaItem.Count > 0)
                    {
                        foreach (MOD_importaPessoaItem ent in objEnt.ListaPessoaItem)
                        {
                            objBLL_ImportaItem = new BLL_ImportaPessoaItem();
                            MOD_pessoa pessoa = new MOD_pessoa();

                            /*Faz a Inserção dos dados na tabela Pessoas*/
                            blnRetornoPessoa = Import(ent, out pessoa);

                            /*Verifica se foi validado o retorno da Tabela ImportaItem
                             * Caso tenha sido validado, é feito o envio dos dados para a classe pessoa para fazer a inserção*/
                            if (true.Equals(blnRetornoPessoa))
                            {
                                ent.CodPessoa = pessoa.CodPessoa;
                                ent.Importado = "Sim";
                                /*Verifica se o código do item é igual a zero
                                Caso for igual a zero chama a clausula INSERT para inserir novo registro*/
                                if ("0".Equals(ent.CodImportaPessoaItem))
                                {
                                    blnRetornoItem = objBLL_ImportaItem.Insert(ent);
                                }
                                else
                                {
                                    blnRetornoItem = objBLL_ImportaItem.Update(ent);
                                }

                            }
                            //verifica se o retorno foi false retorna Erro
                            if (false.Equals(blnRetornoItem) || false.Equals(blnRetornoPessoa))
                            {
                                throw new Exception(modulos.MsgErroSalvar);
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela ImportaPessoaItemErros

                    //verifica se há registro na lista
                    if (null != objEnt.ListaPessoaItemErros && objEnt.ListaPessoaItemErros.Count > 0)
                    {
                        foreach (MOD_importaPessoaItemErro ent in objEnt.ListaPessoaItemErros)
                        {
                            objBLL_ImportaErro = new BLL_ImportaPessoaErro();

                            /*Verifica se o código do item é igual a zero
                            Caso for igual a zero chama a clausula INSERT para inserir novo registro*/
                            if ("0".Equals(ent.CodImportaPessoaItem))
                            {
                                blnRetornoErro = objBLL_ImportaErro.Insert(ent);
                            }
                            else
                            {
                                blnRetornoErro = objBLL_ImportaErro.Update(ent);
                            }

                            //verifica se o retorno foi false retorna Erro
                            if (false.Equals(blnRetornoErro))
                            {
                                throw new Exception(modulos.MsgErroSalvar);
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog) ||
                        false.Equals(blnRetornoItem) || false.Equals(blnRetornoErro))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    //completa a transação
                    objTrans.Complete();

                    //Busca o Registro inserido para retornar para gravar na tabela de Importados com sucesso
                    objBLL_BuscaImporta = new BLL_buscaPorCodImportaPessoa();
                    listaRetorno = objBLL_BuscaImporta.Buscar(objEnt.CodImportaPessoa);

                    //Retorna a Confirmação que foi gravado na tabela Pessoa
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
        public bool Insert(MOD_importaPessoa objEnt, out List<MOD_importaPessoa> listaRetorno)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    bool blnRetorno = true;
                    bool blnRetornoLog = true;
                    bool blnRetornoItem = true;
                    bool blnRetornoErro = true;
                    bool blnRetornoPessoa = true;

                    #region Movimentação da tabela ImportaPessoa e Logs

                    objDAL = new DAL_importaPessoa();
                    objDAL_Log = new DAL_log();
                    objBLL_Valida = new BLL_ValidacaoImporta();

                    //Chama a função que converte as datas
                    objEnt = objBLL_Valida.ConverteData(objEnt);

                    //Chama a função que converte as datas
                    objEnt.Logs = new BLL_importaPessoa_Log().CriarLog(objEnt, "Insert");
                    objEnt.Logs = new BLL_importaPessoa_Log().ValidaLog(objEnt.Logs);

                    //Busca o proximo ID para inserir o registro
                    objEnt.CodImportaPessoa = Convert.ToString(RetornaId());

                    blnRetorno = objDAL.Insert(objEnt);
                    blnRetornoLog = new DAL_log().inserir(objEnt.Logs);

                    //verifica se o retorno foi false retorna Erro
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog))
                    {
                        throw new Exception(modulos.MsgErroSalvar);
                    }

                    #endregion

                    #region Movimentação da tabela ImportaPessoaItem

                    //verifica se há registro na lista
                    if (null != objEnt.ListaPessoaItem && objEnt.ListaPessoaItem.Count > 0)
                    {
                        foreach (MOD_importaPessoaItem ent in objEnt.ListaPessoaItem)
                        {
                            objBLL_ImportaItem = new BLL_ImportaPessoaItem();
                            MOD_pessoa pessoa = new MOD_pessoa();

                            /*Faz a Inserção dos dados na tabela Pessoas*/
                            blnRetornoPessoa = Import(ent, out pessoa);

                            /*Verifica se foi validado o retorno da Tabela ImportaItem
                             * Caso tenha sido validado, é feito o envio dos dados para a classe pessoa para fazer a inserção*/
                            if (true.Equals(blnRetornoPessoa))
                            {
                                ent.CodPessoa = pessoa.CodPessoa;
                                ent.Importado = "Sim";
                                /*Verifica se o código do item é igual a zero
                                Caso for igual a zero chama a clausula INSERT para inserir novo registro*/
                                if ("0".Equals(ent.CodImportaPessoaItem))
                                {
                                    blnRetornoItem = objBLL_ImportaItem.Insert(ent);
                                }
                                else
                                {
                                    blnRetornoItem = objBLL_ImportaItem.Update(ent);
                                }

                            }
                            //verifica se o retorno foi false retorna Erro
                            if (false.Equals(blnRetornoItem) || false.Equals(blnRetornoPessoa))
                            {
                                throw new Exception(modulos.MsgErroSalvar);
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela ImportaPessoaItemErros

                    //verifica se há registro na lista
                    if (null != objEnt.ListaPessoaItemErros && objEnt.ListaPessoaItemErros.Count > 0)
                    {
                        foreach (MOD_importaPessoaItemErro ent in objEnt.ListaPessoaItemErros)
                        {
                            objBLL_ImportaErro = new BLL_ImportaPessoaErro();

                            /*Verifica se o código do item é igual a zero
                            Caso for igual a zero chama a clausula INSERT para inserir novo registro*/
                            if ("0".Equals(ent.CodImportaPessoaItem))
                            {
                                blnRetornoErro = objBLL_ImportaErro.Insert(ent);
                            }
                            else
                            {
                                blnRetornoErro = objBLL_ImportaErro.Update(ent);
                            }

                            //verifica se o retorno foi false retorna Erro
                            if (false.Equals(blnRetornoErro))
                            {
                                throw new Exception(modulos.MsgErroSalvar);
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno) || false.Equals(blnRetornoLog) ||
                        false.Equals(blnRetornoItem) || false.Equals(blnRetornoErro))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }
                    //completa a transação
                    objTrans.Complete();

                    //Busca o Registro inserido para retornar para a classe superior
                    objBLL_BuscaImporta = new BLL_buscaPorCodImportaPessoa();
                    listaRetorno = objBLL_BuscaImporta.Buscar(objEnt.CodImportaPessoa);

                    //Retorna a Confirmação que foi gravado na tabela Pessoa
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
        /// Função que Transmite a Entidade para a Classe Pessoas Importar os dados
        /// </summary>
        /// <param name="objEnt"></param>
        /// <param name="listaRetorno"></param>
        /// <returns></returns>
        public bool Import(MOD_importaPessoaItem objEnt, out MOD_pessoa listaRetorno)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    bool blnRetorno = true;

                    #region Movimentação da tabela Pessoa

                    IBLL_Pessoa objBLL_Pessoa = new BLL_pessoa();
                    IBLL_buscaPessoaDuplicada objBLL_BuscaPessoaDuplicada = new BLL_buscaPessoaDuplicada();
                    IBLL_buscaPessoa objBLL_BuscaPessoa = new BLL_buscaPessoaPorCpf();
                    List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

                    /*Faz uma busca na tabela pessoas para verificar se há alguma pessoa já cadastrada pelo CPF*/
                    listaPessoa = objBLL_BuscaPessoa.Buscar(objEnt.Cpf);

                    /*Caso a busca retorna que há uma pessoa cadastrada para esse CPF*/
                    if (listaPessoa.Count > 0)
                    {
                        /*Verifico se os parâmetros permite a atualização de pessoas na importação*/
                        if ("Não".Equals(modulos.listaParametros[0].AlteraDadosImportPessoa))
                        {
                            listaRetorno = listaPessoa[0];
                            //finaliza a transação
                            objTrans.Dispose();
                            return true;
                        }
                        else
                        {
                            objEnt.CodPessoa = listaPessoa[0].CodPessoa;
                            /*Chama a classe Pessoa para Inserir o registro na Tabela
                             * Informa uma entidade Pessoa com os dados*/
                            blnRetorno = objBLL_Pessoa.Update(new BLL_listaImportaPessoa().CriarDadosPessoa(objEnt), out listaPessoa);
                        }
                    }
                    else /*Caso a busca por CPF não retorne uma pessoa cadastrada*/
                    {
                        /*Verifico se há pessoa cadastrada de aplicando os filtros Nome, DataNascimento e CidadeRes*/
                        listaPessoa = objBLL_BuscaPessoaDuplicada.Buscar(objEnt.Nome, objEnt.DataNasc, objEnt.CodCidadeRes);

                        /*Caso a busca retorna que há uma pessoa cadastrada para os dados informados*/
                        if (listaPessoa.Count > 0)
                        {
                            /*Verifico se os parâmetros permite a atualização de pessoas na importação*/
                            if ("Não".Equals(modulos.listaParametros[0].AlteraDadosImportPessoa))
                            {
                                listaRetorno = listaPessoa[0];
                                //finaliza a transação
                                objTrans.Dispose();
                                return true;
                            }
                            else
                            {
                                objEnt.CodPessoa = listaPessoa[0].CodPessoa;
                                /*Chama a classe Pessoa para Inserir o registro na Tabela
                                 * Informa uma entidade Pessoa com os dados*/
                                blnRetorno = objBLL_Pessoa.Update(new BLL_listaImportaPessoa().CriarDadosPessoa(objEnt), out listaPessoa);
                            }
                        }
                    }

                    /*Verifica se o código da Pessoa é igual a zero
                    Caso for igual a zero chama a clausula INSERT para inserir novo registro*/
                    if ("0".Equals(objEnt.CodPessoa))
                    {
                        /*Chama a classe Pessoa para Inserir o registro na Tabela
                         * Informa uma entidade Pessoa com os dados*/
                        blnRetorno = objBLL_Pessoa.Insert(new BLL_listaImportaPessoa().CriarDadosPessoa(objEnt), out listaPessoa);
                    }
                    
                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (false.Equals(blnRetorno))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(modulos.MsgErroSalvar);
                    }

                    /*Caso não aconteça nenhum erro e a variavel retorna True, completa a transação*/
                    objTrans.Complete();

                    //Dados retornados para a classe superior
                    listaRetorno = listaPessoa[0];

                    //Retorna a Confirmação que foi gravado na tabela Pessoa
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
        public bool Delete(MOD_importaPessoa objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    bool blnRetorno = true;
                    bool blnRetornoLog = true;

                    #region Movimentação da tabela ImportaPessoa e Logs

                    objDAL = new DAL_importaPessoa();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = new BLL_importaPessoa_Log().CriarLog(objEnt, "Delete");
                    objEnt.Logs = new BLL_importaPessoa_Log().ValidaLog(objEnt.Logs);

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

        #endregion

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int32 RetornaId()
        {
            try
            {
                objDAL = new DAL_importaPessoa();
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