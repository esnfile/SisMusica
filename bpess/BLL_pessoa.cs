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
using ENT.Erros;
using BLL.Funcoes.Exceptions;

namespace BLL.pessoa
{
    public class BLL_pessoa
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_pessoa objDAL = null;
        DAL_pessoaInstr objDAL_PesInst = null;
        DAL_pessoaMetodo objDAL_PesMet = null;
        DAL_ccbPessoa objDAL_CCBPes = null;
        DAL_regiaoPessoa objDAL_RegiaoPes = null;
        DAL_pessoaFoto objDAL_Foto = null;
        DAL_log objDAL_Log = null;

        BLL_cargo objBLL_Cargo = null;

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
        bool blnRetornoRegiao;
        bool blnRetornoRegiaoLog;
        bool blnRetornoRegiaoDelete;
        bool blnRetornoRegiaoDeleteLog;
        bool blnRetornoFoto;
        bool blnRetornoLog;

        DataTable objDtb = null;
        DataTable objDtb_PesInst = null;
        DataTable objDtb_PesMet = null;
        DataTable objDtb_CCBPes = null;
        DataTable objDtb_RegiaoPes = null;
        DataTable objDtbRegiao = null;
        DataTable objDtbInst = null;
        DataTable objDtbMetodo = null;
        DataTable objDtbCCB = null;
        DataTable objDtb_Foto = null;

        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
        List<MOD_pessoaFoto> listaFoto = new List<MOD_pessoaFoto>();
        List<MOD_pessoaInstr> listaPesInst = new List<MOD_pessoaInstr>();
        List<MOD_pessoaMetodo> listaPesMet = new List<MOD_pessoaMetodo>();
        BindingList<MOD_ccbPessoa> listaCCBPes = new BindingList<MOD_ccbPessoa>();
        List<MOD_ccbPessoa> listaDeleteCCBPes = new List<MOD_ccbPessoa>();
        BindingList<MOD_regiaoPessoa> listaRegiaoPes = new BindingList<MOD_regiaoPessoa>();
        List<MOD_regiaoPessoa> listaDeleteRegiaoPes = new List<MOD_regiaoPessoa>();
        List<MOD_instrumento> listaInstrumento = new List<MOD_instrumento>();
        List<MOD_metodoInstr> listaMetodo = new List<MOD_metodoInstr>();
        List<MOD_ccb> listaCCB = new List<MOD_ccb>();
        List<MOD_regiaoAtuacao> listaRegiao = new List<MOD_regiaoAtuacao>();


        string NomeSucesso;

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_pessoa objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

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
                    blnRetornoRegiao = true;
                    blnRetornoRegiaoLog = true;
                    blnRetornoRegiaoDelete = true;
                    blnRetornoRegiaoDeleteLog = true;
                    blnRetornoMetLog = true;
                    blnRetornoInstLog = true;

                    #endregion

                    #region Movimentação da tabela Pessoa e Logs

                    objDAL = new DAL_pessoa();
                    objDAL_Log = new DAL_log();

                    //Função que valida o Cpf
                    objEnt.Cpf = funcoes.FormataCpf(objEnt.Cpf);

                    //Chama a função que converte as datas
                    objEnt = validaDadosPessoa(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela PessoaInstrumento

                    //verifica se há registro na lista
                    if (objEnt.listaPessoaInstr != null && objEnt.listaPessoaInstr.Count > 0)
                    {
                        objDAL_PesInst = new DAL_pessoaInstr();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_pessoaInstr ent in objEnt.listaPessoaInstr)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "PessoaInstr");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoInst = objDAL_PesInst.salvar(ent);
                            blnRetornoInstLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoInst.Equals(false) || blnRetornoInstLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela PessoaMetodo

                    //verifica se há registro na lista
                    if (objEnt.listaPessoaMet != null && objEnt.listaPessoaMet.Count > 0)
                    {
                        objDAL_PesMet = new DAL_pessoaMetodo();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_pessoaMetodo ent in objEnt.listaPessoaMet)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "PessoaMetodo");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoMet = objDAL_PesMet.salvar(ent);
                            blnRetornoMetLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoMet.Equals(false) || blnRetornoMetLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela CCBPessoa

                    //verifica se há registro na lista
                    if (objEnt.listaCCBPessoa != null && objEnt.listaCCBPessoa.Count > 0)
                    {
                        objDAL_CCBPes = new DAL_ccbPessoa();

                        //Faz o loop para gravar na tabela 
                        foreach (MOD_ccbPessoa ent in objEnt.listaCCBPessoa)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "CCBPessoa");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoCCB = objDAL_CCBPes.salvar(ent);
                            blnRetornoCCBLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoCCB.Equals(false) || blnRetornoCCBLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete CCBPessoa

                    //verifica se há registro na lista Delete 
                    if (objEnt.listaDeleteCCBPessoa != null && objEnt.listaDeleteCCBPessoa.Count > 0)
                    {
                        objDAL_CCBPes = new DAL_ccbPessoa();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_ccbPessoa ent in objEnt.listaDeleteCCBPessoa)
                        {
                            if (!Convert.ToInt64(ent.CodCCBPessoa).Equals(0))
                            {
                                //Chama a função que converte as datas
                                objEnt.Logs = criarLog(objEnt, "CCBPessoaDelete");
                                objEnt.Logs = validaDadosLog(objEnt.Logs);

                                ent.CodPessoa = objEnt.CodPessoa;
                                blnRetornoCCBDelete = objDAL_CCBPes.excluir(ent);
                                blnRetornoCCBDeleteLog = objDAL_Log.inserir(objEnt.Logs);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoCCBDelete.Equals(false) || blnRetornoCCBDeleteLog.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela RegiaoPessoa

                    //verifica se há registro na lista
                    if (objEnt.listaRegiaoPessoa != null && objEnt.listaRegiaoPessoa.Count > 0)
                    {
                        objDAL_RegiaoPes = new DAL_regiaoPessoa();

                        //Faz o loop para gravar na tabela 
                        foreach (MOD_regiaoPessoa ent in objEnt.listaRegiaoPessoa)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "RegiaoPessoa");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoRegiao = objDAL_RegiaoPes.salvar(ent);
                            blnRetornoRegiaoLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoRegiao.Equals(false) || blnRetornoRegiaoLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete RegiaoPessoa

                    //verifica se há registro na lista Delete 
                    if (objEnt.listaDeleteRegiaoPessoa != null && objEnt.listaDeleteRegiaoPessoa.Count > 0)
                    {
                        objDAL_RegiaoPes = new DAL_regiaoPessoa();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_regiaoPessoa ent in objEnt.listaDeleteRegiaoPessoa)
                        {
                            if (!Convert.ToInt64(ent.CodRegiaoPessoa).Equals(0))
                            {
                                //Chama a função que converte as datas
                                objEnt.Logs = criarLog(objEnt, "RegiaoPessoaDelete");
                                objEnt.Logs = validaDadosLog(objEnt.Logs);

                                ent.CodPessoa = objEnt.CodPessoa;
                                blnRetornoRegiaoDelete = objDAL_RegiaoPes.excluir(ent);
                                blnRetornoRegiaoDeleteLog = objDAL_Log.inserir(objEnt.Logs);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoRegiaoDelete.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela Foto

                    //verifica se há registro na lista Foto
                    if (objEnt.FotoPessoa != null)
                    {
                        objDAL_Foto = new DAL_pessoaFoto();

                        objEnt.FotoPessoa.CodPessoa = objEnt.CodPessoa;

                        blnRetornoFoto = objDAL_Foto.salvar(objEnt.FotoPessoa);
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) ||
                        blnRetornoInst.Equals(false) || blnRetornoInstLog.Equals(false) || blnRetornoFoto.Equals(false) ||
                        blnRetornoMet.Equals(false) || blnRetornoMetLog.Equals(false) ||
                        blnRetornoCCB.Equals(false) || blnRetornoCCBDelete.Equals(false) || blnRetornoCCBDeleteLog.Equals(false) ||
                        blnRetornoRegiao.Equals(false) || blnRetornoRegiaoDelete.Equals(false) || blnRetornoRegiaoDeleteLog.Equals(false) ||
                        blnRetornoCCBLog.Equals(false) || blnRetornoRegiaoLog.Equals(false))
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
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_pessoa objEnt)
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
                    blnRetornoRegiao = true;
                    blnRetornoRegiaoLog = true;
                    blnRetornoRegiaoDelete = true;
                    blnRetornoRegiaoDeleteLog = true;
                    blnRetornoInstLog = true;

                    #endregion

                    #region Movimentação da tabela Pessoa e Logs

                    objDAL = new DAL_pessoa();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodPessoa = Convert.ToString(this.retornaId());

                    //Função que valida o Cpf
                    objEnt.Cpf = funcoes.FormataCpf(objEnt.Cpf);

                    //Chama a função que converte as datas
                    objEnt = validaDadosPessoa(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela PessoaInstrumento

                    //verifica se há registro na lista
                    if (objEnt.listaPessoaInstr != null && objEnt.listaPessoaInstr.Count > 0)
                    {
                        objDAL_PesInst = new DAL_pessoaInstr();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_pessoaInstr ent in objEnt.listaPessoaInstr)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "PessoaInstr");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoInst = objDAL_PesInst.salvar(ent);
                            blnRetornoInstLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoInst.Equals(false) || blnRetornoInstLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela PessoaMetodo

                    //verifica se há registro na lista
                    if (objEnt.listaPessoaMet != null && objEnt.listaPessoaMet.Count > 0)
                    {
                        objDAL_PesMet = new DAL_pessoaMetodo();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_pessoaMetodo ent in objEnt.listaPessoaMet)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "PessoaMetodo");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoMet = objDAL_PesMet.salvar(ent);
                            blnRetornoMetLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoMet.Equals(false) || blnRetornoMetLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela CCBPessoa

                    //verifica se há registro na lista
                    if (objEnt.listaCCBPessoa != null && objEnt.listaCCBPessoa.Count > 0)
                    {
                        objDAL_CCBPes = new DAL_ccbPessoa();

                        //Faz o loop para gravar na tabela 
                        foreach (MOD_ccbPessoa ent in objEnt.listaCCBPessoa)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "CCBPessoa");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoCCB = objDAL_CCBPes.salvar(ent);
                            blnRetornoCCBLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoCCB.Equals(false) || blnRetornoCCBLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete CCBPessoa

                    //verifica se há registro na lista Delete 
                    if (objEnt.listaDeleteCCBPessoa != null && objEnt.listaDeleteCCBPessoa.Count > 0)
                    {
                        objDAL_CCBPes = new DAL_ccbPessoa();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_ccbPessoa ent in objEnt.listaDeleteCCBPessoa)
                        {
                            if (!Convert.ToInt64(ent.CodCCBPessoa).Equals(0))
                            {
                                //Chama a função que converte as datas
                                objEnt.Logs = criarLog(objEnt, "CCBPessoaDelete");
                                objEnt.Logs = validaDadosLog(objEnt.Logs);

                                ent.CodPessoa = objEnt.CodPessoa;
                                blnRetornoCCBDelete = objDAL_CCBPes.excluir(ent);
                                blnRetornoCCBDeleteLog = objDAL_Log.inserir(objEnt.Logs);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoCCBDelete.Equals(false) || blnRetornoCCBDeleteLog.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela RegiaoPessoa

                    //verifica se há registro na lista
                    if (objEnt.listaRegiaoPessoa != null && objEnt.listaRegiaoPessoa.Count > 0)
                    {
                        objDAL_RegiaoPes = new DAL_regiaoPessoa();

                        //Faz o loop para gravar na tabela 
                        foreach (MOD_regiaoPessoa ent in objEnt.listaRegiaoPessoa)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "RegiaoPessoa");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodPessoa = objEnt.CodPessoa;
                            blnRetornoRegiao = objDAL_RegiaoPes.salvar(ent);
                            blnRetornoRegiaoLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoRegiao.Equals(false) || blnRetornoRegiaoLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete RegiaoPessoa

                    //verifica se há registro na lista Delete 
                    if (objEnt.listaDeleteRegiaoPessoa != null && objEnt.listaDeleteRegiaoPessoa.Count > 0)
                    {
                        objDAL_RegiaoPes = new DAL_regiaoPessoa();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_regiaoPessoa ent in objEnt.listaDeleteRegiaoPessoa)
                        {
                            if (!Convert.ToInt64(ent.CodRegiaoPessoa).Equals(0))
                            {
                                //Chama a função que converte as datas
                                objEnt.Logs = criarLog(objEnt, "RegiaoPessoaDelete");
                                objEnt.Logs = validaDadosLog(objEnt.Logs);

                                ent.CodPessoa = objEnt.CodPessoa;
                                blnRetornoRegiaoDelete = objDAL_RegiaoPes.excluir(ent);
                                blnRetornoRegiaoDeleteLog = objDAL_Log.inserir(objEnt.Logs);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoRegiaoDelete.Equals(false) || blnRetornoRegiaoDeleteLog.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela Foto

                    //verifica se há registro na lista Foto Instrumento
                    if (objEnt.FotoPessoa != null)
                    {
                        objDAL_Foto = new DAL_pessoaFoto();

                        objEnt.FotoPessoa.CodPessoa = objEnt.CodPessoa;

                        blnRetornoFoto = objDAL_Foto.salvar(objEnt.FotoPessoa);
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) ||
                        blnRetornoInst.Equals(false) || blnRetornoInstLog.Equals(false) || blnRetornoFoto.Equals(false) ||
                        blnRetornoMet.Equals(false) || blnRetornoMetLog.Equals(false) || 
                        blnRetornoCCB.Equals(false) || blnRetornoCCBDelete.Equals(false) || blnRetornoCCBDeleteLog.Equals(false) ||
                        blnRetornoRegiao.Equals(false) || blnRetornoRegiaoDelete.Equals(false) || blnRetornoRegiaoDeleteLog.Equals(false) ||
                        blnRetornoCCBLog.Equals(false) || blnRetornoRegiaoLog.Equals(false))
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
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_pessoa objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    objDAL = new DAL_pessoa();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Delete");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.excluir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false))
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

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        public bool importar(MOD_pessoa objEnt)
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

                    objDAL = new DAL_pessoa();
                    objDAL_Log = new DAL_log();

                    MOD_pessoa entPessoa = new MOD_pessoa();
                    entPessoa = objEnt;

                    NomeSucesso = objEnt.Nome;

                    entPessoa.Logs = criarLog(objEnt, "Import");
                    entPessoa.Logs = validaDadosLog(objEnt.Logs);

                    //Verifica se já existe o CPF na base de dados e atualiza os dados
                    if (!string.IsNullOrEmpty(objEnt.Cpf) && !objEnt.Cpf.Equals("000.000.000-00"))
                    {
                        List<MOD_pessoa> listaValidaCpf = new List<MOD_pessoa>();
                        listaValidaCpf = buscarCpf(entPessoa.Cpf);

                        if (listaValidaCpf.Count > 0)
                        {
                            if (modulos.listaParametros[0].AlteraDadosImportPessoa.Equals("Sim"))
                            {
                                entPessoa.CodPessoa = listaValidaCpf[0].CodPessoa;
                                blnRetorno = objDAL.salvar(entPessoa);
                                blnRetornoLog = objDAL_Log.inserir(entPessoa.Logs);
                            }
                        }
                        else
                        {
                            objEnt.CodPessoa = Convert.ToString(retornaId());
                            blnRetorno = objDAL.inserir(entPessoa);
                            blnRetornoLog = objDAL_Log.inserir(entPessoa.Logs);
                        }
                    }
                    else
                    {
                        List<MOD_pessoa> listaPessoaDupl = new List<MOD_pessoa>();
                        listaPessoaDupl = buscarPessoaDuplicada(entPessoa.Nome, entPessoa.DataNasc, entPessoa.CodCidadeRes);

                        if (listaPessoaDupl.Count > 0)
                        {
                            if (modulos.listaParametros[0].AlteraDadosImportPessoa.Equals("Sim"))
                            {
                                entPessoa.CodPessoa = listaPessoaDupl[0].CodPessoa;
                                blnRetorno = objDAL.salvar(entPessoa);
                                blnRetornoLog = objDAL_Log.inserir(entPessoa.Logs);
                            }
                        }
                        else
                        {
                            entPessoa.CodPessoa = Convert.ToString(retornaId());
                            blnRetorno = objDAL.inserir(entPessoa);
                            blnRetornoLog = objDAL_Log.inserir(entPessoa.Logs);
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(" Nome que gerou Erro: " + NomeSucesso);
                    }
                    else
                    {
                        modulos.CodPessoaImportacao = objEnt.CodPessoa;
                        //completa a transação
                        objTrans.Complete();
                        return true;
                    }
                }
                catch (SqlException exl)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw new Exception("Erro de SQL na Camada BLL Pessoa." + "\n" + "Descrição do erro: " + exl.Message);
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw new Exception("Erro na Camada BLL Pessoa." + "\n" + "Descrição do erro: " + ex.Message);
                }
            }
        }

        #endregion

        #region Funções que transmite os Critério para a DAL realizar a Busca no Banco

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCod(string CodPessoa)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCod(CodPessoa);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Código informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCod(string CodPessoa, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCod(CodPessoa, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Código informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCod(string CodPessoa, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCod(CodPessoa, CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Código informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCod(string CodPessoa, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCod(CodPessoa, CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Código informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCod(string CodPessoa, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCod(CodPessoa, CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Código informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCod(string CodPessoa, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCod(CodPessoa, CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarNome(string Nome)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarNome(Nome + "%");

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarNome(string Nome, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarNome(Nome + "%", Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarNome(string Nome, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarNome(Nome + "%", CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarNome(string Nome, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarNome(Nome + "%", CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarNome(string Nome, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarNome(Nome + "%", CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Nome informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarNome(string Nome, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarNome(Nome + "%", CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cpf informado, para pesquisa
        /// </summary>
        /// <param name="Cpf"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCpf(string Cpf)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCpf(Cpf + "%");

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cpf informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCpf(string Cpf, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCpf(Cpf + "%", Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cpf informado, para pesquisa
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCpf(string Cpf, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCpf(Cpf + "%", CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cpf informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCpf(string Cpf, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCpf(Cpf + "%", CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cpf informado, para pesquisa
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCpf(string Cpf, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCpf(Cpf + "%", CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cpf informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCpf(string Cpf, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCpf(Cpf + "%", CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Regiao informada, para pesquisa
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarPesRegiao(string CodRegiao)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarPesRegiao(CodRegiao);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Regiao informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarPesRegiao(string CodRegiao, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarPesRegiao(CodRegiao, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Regiao informado, para pesquisa
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarPesRegiao(string CodRegiao, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarPesRegiao(CodRegiao, CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Regiao informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarPesRegiao(string CodRegiao, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarPesRegiao(CodRegiao, CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Regiao informado, para pesquisa
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarPesRegiao(string CodRegiao, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarPesRegiao(CodRegiao, CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Regiao informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarPesRegiao(string CodRegiao, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarPesRegiao(CodRegiao, CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCidade(string CodCidadeRes)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCidade(CodCidadeRes);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCidade(string CodCidadeRes, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCidade(CodCidadeRes, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCidade(string CodCidadeRes, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCidade(CodCidadeRes, CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCidade(string CodCidadeRes, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCidade(CodCidadeRes, CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCidade(string CodCidadeRes, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCidade(CodCidadeRes, CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCidade(string CodCidadeRes, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCidade(CodCidadeRes, CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cargo informado, para pesquisa
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCargo(string CodCargo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCargo(CodCargo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// <para>Ativo: Sim ou Não</para>
        /// Função que Transmite o Cargo informada, para pesquisa
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCargo(string CodCargo, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCargo(CodCargo, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cargo informada, para pesquisa
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCargo(string CodCargo, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCargo(CodCargo, CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cargo informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCargo(string CodCargo, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCargo(CodCargo, CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cargo informada, para pesquisa
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCargo(string CodCargo, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCargo(CodCargo, CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Cargo informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarCargo(string CodCargo, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarCargo(CodCargo, CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = this.criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Comum informada, para pesquisa
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarComum(string CodCCB)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarComum(CodCCB);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Comum informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarComum(string CodCCB, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarComum(CodCCB, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Comum informada, para pesquisa
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarComum(string CodCCB, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarComum(CodCCB, CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Comum informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarComum(string CodCCB, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarComum(CodCCB, CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Comum informada, para pesquisa
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarComum(string CodCCB, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarComum(CodCCB, CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite a Comum informada, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarComum(string CodCCB, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarComum(CodCCB, CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informada, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarInstrumento(string CodInstrumento)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarInstrumento(CodInstrumento);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarInstrumento(string CodInstrumento, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarInstrumento(CodInstrumento, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarInstrumento(string CodInstrumento, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarInstrumento(CodInstrumento, CodCCBUsu);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarInstrumento(string CodInstrumento, string CodCCBUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarInstrumento(CodInstrumento, CodCCBUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarInstrumento(string CodInstrumento, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarInstrumento(CodInstrumento, CodCCBUsu, CodCargoUsu);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarInstrumento(string CodInstrumento, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarInstrumento(CodInstrumento, CodCCBUsu, CodCargoUsu, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarVisaoOrquestral(string CodInstrumento, string CodCCB, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarVisaoOrquestral(CodInstrumento, CodCCB, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string Desenvolvimento)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB, Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string Desenvolvimento)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo, Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal));

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal), Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: true ou false</para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal));

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: true ou false</para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarRelatorioPessoa(Sexo, EstadoCivil, CodCargo, CodCCB, Ativo, CampoData, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal), Desenvolvimento);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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
        /// Função que retorna os Registros da tabela Pessoa, para importação de novos dados
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="DataNasc"></param>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarPessoaDuplicada(string Nome, string DataNasc, string CodCidade)
        {
            try
            {
                objDAL = new DAL_pessoa();
                objDtb = objDAL.buscarPessoaDuplicada(Nome + "%", DataNasc, CodCidade);

                if (objDtb != null)
                {
                    listaPessoa = criarLista(objDtb);
                }
                return listaPessoa;
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

        #region Foto Pessoa

        /// <summary>
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela Foto Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public DataTable buscarPessoaFoto(string CodPessoa)
        {
            try
            {
                objDAL_Foto = new DAL_pessoaFoto();
                objDtb_Foto = objDAL_Foto.buscarPessoaFoto(CodPessoa);
                return objDtb_Foto;
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

        #region Pessoa Instrumento

        /// <summary>
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela Pessoa Instrumento
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public List<MOD_pessoaInstr> buscarInstPessoa(string CodPessoa)
        {
            try
            {
                objDAL_PesInst = new DAL_pessoaInstr();
                objDtb_PesInst = objDAL_PesInst.buscarInstPessoa(CodPessoa);

                if (objDtb_PesInst != null)
                {
                    listaPesInst = this.criarListaPessoaInst(objDtb_PesInst);
                }
                return listaPesInst;
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
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela Instrumentos
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public List<MOD_instrumento> buscarInstrumentos(string CodPessoa)
        {
            try
            {
                objDAL_PesInst = new DAL_pessoaInstr();
                objDtbInst = objDAL_PesInst.buscarInstrumentos(CodPessoa);

                if (objDtbInst != null)
                {
                    listaInstrumento = this.criarListaInstr(objDtbInst);
                }
                return listaInstrumento;
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

        #region Pessoa Metodo

        /// <summary>
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela Pessoa Metodo
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public List<MOD_pessoaMetodo> buscarMetodoPessoa(string CodPessoa)
        {
            try
            {
                objDAL_PesMet = new DAL_pessoaMetodo();
                objDtb_PesMet = objDAL_PesMet.buscarMetodoPessoa(CodPessoa);

                if (objDtb_PesMet != null)
                {
                    listaPesMet = this.criarListaPessoaMet(objDtb_PesMet);
                }
                return listaPesMet;
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
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela Metodos
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_metodoInstr> buscarMetodos(string CodPessoa, string CodInstrumento)
        {
            try
            {
                objDAL_PesMet = new DAL_pessoaMetodo();
                objDtbMetodo = objDAL_PesMet.buscarMetodos(CodPessoa, CodInstrumento);

                if (objDtbMetodo != null)
                {
                    listaMetodo = this.criarListaMetodo(objDtbMetodo);
                }
                return listaMetodo;
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

        #region CCB Pessoa 

        /// <summary>
        /// Função que Transmite a Comum informada, para pesquisa na
        /// Tabela CCB Pessoa
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <returns></returns>       
        public BindingList<MOD_ccbPessoa> buscarPesCCB(string CodCCB)
        {
            try
            {
                objDAL_CCBPes = new DAL_ccbPessoa();
                objDtb_CCBPes = objDAL_CCBPes.buscarPesCCB(CodCCB);

                if (objDtb_CCBPes != null)
                {
                    listaCCBPes = criarListaCCBPessoa(objDtb_CCBPes);
                }
                return listaCCBPes;
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
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela CCB Pessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public BindingList<MOD_ccbPessoa> buscarCCBPessoa(string CodPessoa)
        {
            try
            {
                objDAL_CCBPes = new DAL_ccbPessoa();
                objDtb_CCBPes = objDAL_CCBPes.buscarCCBPessoa(CodPessoa);

                if (objDtb_CCBPes != null)
                {
                    listaCCBPes = this.criarListaCCBPessoa(objDtb_CCBPes);
                }
                return listaCCBPes;
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
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela CCB Pessoa, de acordo com  a Região Informada
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>       
        public BindingList<MOD_ccbPessoa> buscarCCBPessoa(string CodPessoa, string CodRegiao)
        {
            try
            {
                objDAL_CCBPes = new DAL_ccbPessoa();
                objDtb_CCBPes = objDAL_CCBPes.buscarCCBPessoa(CodPessoa, CodRegiao);

                if (objDtb_CCBPes != null)
                {
                    listaCCBPes = this.criarListaCCBPessoa(objDtb_CCBPes);
                }
                return listaCCBPes;
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
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela CCB
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public List<MOD_ccb> buscarCCB(string CodPessoa)
        {
            try
            {
                objDAL_CCBPes = new DAL_ccbPessoa();
                objDtbCCB = objDAL_CCBPes.buscarCCB(CodPessoa);

                if (objDtbCCB != null)
                {
                    listaCCB = this.criarListaCCB(objDtbCCB);
                }
                return listaCCB;
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

        #region Região Pessoa 

        /// <summary>
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela RegiaoPessoa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public BindingList<MOD_regiaoPessoa> buscarRegiaoPessoa(string CodPessoa)
        {
            try
            {
                objDAL_RegiaoPes = new DAL_regiaoPessoa();
                objDtb_RegiaoPes = objDAL_RegiaoPes.buscarRegiaoPessoa(CodPessoa);

                if (objDtb_RegiaoPes != null)
                {
                    listaRegiaoPes = this.criarListaRegiaoPessoa(objDtb_RegiaoPes);
                }
                return listaRegiaoPes;
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
        /// Função que Transmite a Regiao informada, para pesquisa na
        /// Tabela RegiaoPessoa
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>       
        public BindingList<MOD_regiaoPessoa> buscarRegiaoPes(string CodRegiao)
        {
            try
            {
                objDAL_RegiaoPes = new DAL_regiaoPessoa();
                objDtb_RegiaoPes = objDAL_RegiaoPes.buscarRegiaoPes(CodRegiao);

                if (objDtb_RegiaoPes != null)
                {
                    listaRegiaoPes = this.criarListaRegiaoPessoa(objDtb_RegiaoPes);
                }
                return listaRegiaoPes;
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
        /// Função que Transmite a Pessoa informada, para pesquisa na
        /// Tabela Regiao
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>       
        public List<MOD_regiaoAtuacao> buscarRegiao(string CodPessoa)
        {
            try
            {
                objDAL_RegiaoPes = new DAL_regiaoPessoa();
                objDtbRegiao = objDAL_RegiaoPes.buscarRegiao(CodPessoa);

                if (objDtbRegiao != null)
                {
                    listaRegiao = this.criarListaRegiao(objDtbRegiao);
                }
                return listaRegiao;
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

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                objDAL = new DAL_pessoa();
                return objDAL.retornaId();
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_pessoa> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoa> lista = new List<MOD_pessoa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_pessoa ent = new MOD_pessoa();
                    //adiciona os campos às propriedades
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.DataCadastro = (string)(row.IsNull("DataCadastro") ? Convert.ToString(null) : funcoes.IntData(row["DataCadastro"].ToString()));
                    ent.HoraCadastro = (string)(row.IsNull("HoraCadastro") ? Convert.ToString(null) : funcoes.IntHora(row["HoraCadastro"].ToString()));
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.OrdemCargo = (string)(row.IsNull("OrdemCargo") ? Convert.ToString(null) : Convert.ToString(row["OrdemCargo"]).PadLeft(2, '0'));
                    ent.CodDepartamento = (string)(row.IsNull("CodDepartamento") ? Convert.ToString(null) : Convert.ToString(row["CodDepartamento"]).PadLeft(3, '0'));
                    ent.DescDepartamento = (string)(row.IsNull("DescDepartamento") ? null : row["DescDepartamento"]);
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.DataNasc = (string)(row.IsNull("DataNasc") ? Convert.ToString(null) : funcoes.IntData(row["DataNasc"].ToString()));
                    ent.Cpf = (string)(row.IsNull("Cpf") ? null : row["Cpf"]);
                    ent.Rg = (string)(row.IsNull("Rg") ? null : row["Rg"]);
                    ent.OrgaoEmissor = (string)(row.IsNull("OrgaoEmissor") ? null : row["OrgaoEmissor"]);
                    ent.Sexo = (string)(row.IsNull("Sexo") ? null : row["Sexo"]);
                    ent.DataBatismo = (string)(row.IsNull("DataBatismo") ? Convert.ToString(null) : funcoes.IntData(row["DataBatismo"].ToString()));
                    ent.CodCidadeRes = (string)(row.IsNull("CodCidadeRes") ? Convert.ToString(null) : Convert.ToString(row["CodCidadeRes"]).PadLeft(6, '0'));
                    ent.CidadeRes = (string)(row.IsNull("CidadeRes") ? null : row["CidadeRes"]);
                    ent.EstadoRes = (string)(row.IsNull("EstadoRes") ? null : row["EstadoRes"]);
                    ent.CepRes = (string)(row.IsNull("CepRes") ? null : funcoes.FormataString("#####-###",row["CepRes"].ToString()));
                    ent.EndRes = (string)(row.IsNull("EndRes") ? null : row["EndRes"]);
                    ent.NumRes = (string)(row.IsNull("NumRes") ? null : row["NumRes"]);
                    ent.BairroRes = (string)(row.IsNull("BairroRes") ? null : row["BairroRes"]);
                    ent.ComplRes = (string)(row.IsNull("ComplRes") ? null : row["ComplRes"]);
                    ent.Telefone1 = (string)(row.IsNull("Telefone1") ? null : row["Telefone1"]);
                    ent.Telefone2 = (string)(row.IsNull("Telefone2") ? null : row["Telefone2"]);
                    ent.Celular1 = (string)(row.IsNull("Celular1") ? null : row["Celular1"]);
                    ent.Celular2 = (string)(row.IsNull("Celular2") ? null : row["Celular2"]);
                    ent.Email = (string)(row.IsNull("Email") ? null : row["Email"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.EndCCB = (string)(row.IsNull("EndCCB") ? null : row["EndCCB"]);
                    ent.NumCCB = (string)(row.IsNull("NumCCB") ? null : row["NumCCB"]);
                    ent.BairroCCB = (string)(row.IsNull("BairroCCB") ? null : row["BairroCCB"]);
                    ent.ComplCCB = (string)(row.IsNull("ComplCCB") ? null : row["ComplCCB"]);
                    ent.CidadeCCB = (string)(row.IsNull("CidadeCCB") ? null : row["CidadeCCB"]);
                    ent.EstadoCCB = (string)(row.IsNull("EstadoCCB") ? null : row["EstadoCCB"]);
                    ent.CepCCB = (string)(row.IsNull("CepCCB") ? null : funcoes.FormataString("#####-###", row["CepCCB"].ToString()));
                    ent.TelefoneCCB = (string)(row.IsNull("TelefoneCCB") ? null : row["TelefoneCCB"]);
                    ent.CelularCCB = (string)(row.IsNull("CelularCCB") ? null : row["CelularCCB"]);
                    ent.EmailCCB = (string)(row.IsNull("EmailCCB") ? null : row["EmailCCB"]);
                    ent.EstadoCivil = (string)(row.IsNull("EstadoCivil") ? null : row["EstadoCivil"]);
                    ent.DataApresentacao = (string)(row.IsNull("DataApresentacao") ? Convert.ToString(null) : funcoes.IntData(row["DataApresentacao"].ToString()));
                    ent.PaisCCB = (string)(row.IsNull("PaisCCB") ? null : row["PaisCCB"]);
                    ent.Pai = (string)(row.IsNull("Pai") ? null : row["Pai"]);
                    ent.Mae = (string)(row.IsNull("Mae") ? null : row["Mae"]);
                    ent.InstrutorSeguro = (string)(row.IsNull("InstrutorSeguro") ? null : row["InstrutorSeguro"]);
                    ent.FormacaoFora = (string)(row.IsNull("FormacaoFora") ? null : row["FormacaoFora"]);
                    ent.LocalFormacao = (string)(row.IsNull("LocalFormacao") ? null : row["LocalFormacao"]);
                    ent.QualFormacao = (string)(row.IsNull("QualFormacao") ? null : row["QualFormacao"]);
                    ent.OutraOrquestra = (string)(row.IsNull("OutraOrquestra") ? null : row["OutraOrquestra"]);
                    ent.Orquestra1 = (string)(row.IsNull("Orquestra1") ? null : row["Orquestra1"]);
                    ent.Funcao1 = (string)(row.IsNull("Funcao1") ? null : row["Funcao1"]);
                    ent.Orquestra2 = (string)(row.IsNull("Orquestra2") ? null : row["Orquestra2"]);
                    ent.Funcao2 = (string)(row.IsNull("Funcao2") ? null : row["Funcao2"]);
                    ent.Orquestra3 = (string)(row.IsNull("Orquestra3") ? null : row["Orquestra3"]);
                    ent.Funcao3 = (string)(row.IsNull("Funcao3") ? null : row["Funcao3"]);
                    ent.AtendeComum = (string)(row.IsNull("AtendeComum") ? null : row["AtendeComum"]);
                    ent.AtendeRegiao = (string)(row.IsNull("AtendeRegiao") ? null : row["AtendeRegiao"]);
                    ent.AtendeGEM = (string)(row.IsNull("AtendeGEM") ? null : row["AtendeGEM"]);
                    ent.AtendeEnsaioLocal = (string)(row.IsNull("AtendeEnsaioLocal") ? null : row["AtendeEnsaioLocal"]);
                    ent.AtendeEnsaioRegional = (string)(row.IsNull("AtendeEnsaioRegional") ? null : row["AtendeEnsaioRegional"]);
                    ent.AtendeEnsaioParcial = (string)(row.IsNull("AtendeEnsaioParcial") ? null : row["AtendeEnsaioParcial"]);
                    ent.AtendeEnsaioTecnico = (string)(row.IsNull("AtendeEnsaioTecnico") ? null : row["AtendeEnsaioTecnico"]);
                    ent.AtendeReuniaoMocidade = (string)(row.IsNull("AtendeReuniaoMocidade") ? null : row["AtendeReuniaoMocidade"]);
                    ent.AtendeBatismo = (string)(row.IsNull("AtendeBatismo") ? null : row["AtendeBatismo"]);
                    ent.AtendeSantaCeia = (string)(row.IsNull("AtendeSantaCeia") ? null : row["AtendeSantaCeia"]);
                    ent.AtendeRJM = (string)(row.IsNull("AtendeRJM") ? null : row["AtendeRJM"]);
                    ent.AtendePreTesteRjmMusico = (string)(row.IsNull("AtendePreTesteRjmMusico") ? null : row["AtendePreTesteRjmMusico"]);
                    ent.AtendePreTesteRjmOrganista = (string)(row.IsNull("AtendePreTesteRjmOrganista") ? null : row["AtendePreTesteRjmOrganista"]);
                    ent.AtendeTesteRjmMusico = (string)(row.IsNull("AtendeTesteRjmMusico") ? null : row["AtendeTesteRjmMusico"]);
                    ent.AtendeTesteRjmOrganista = (string)(row.IsNull("AtendeTesteRjmOrganista") ? null : row["AtendeTesteRjmOrganista"]);
                    ent.AtendePreTesteCultoMusico = (string)(row.IsNull("AtendePreTesteCultoMusico") ? null : row["AtendePreTesteCultoMusico"]);
                    ent.AtendePreTesteCultoOrganista = (string)(row.IsNull("AtendePreTesteCultoOrganista") ? null : row["AtendePreTesteCultoOrganista"]);
                    ent.AtendeTesteCultoMusico = (string)(row.IsNull("AtendeTesteCultoMusico") ? null : row["AtendeTesteCultoMusico"]);
                    ent.AtendeTesteCultoOrganista = (string)(row.IsNull("AtendeTesteCultoOrganista") ? null : row["AtendeTesteCultoOrganista"]);
                    ent.AtendePreTesteOficialMusico = (string)(row.IsNull("AtendePreTesteOficialMusico") ? null : row["AtendePreTesteOficialMusico"]);
                    ent.AtendePreTesteOficialOrganista = (string)(row.IsNull("AtendePreTesteOficialOrganista") ? null : row["AtendePreTesteOficialOrganista"]);
                    ent.AtendeTesteOficialMusico = (string)(row.IsNull("AtendeTesteOficialMusico") ? null : row["AtendeTesteOficialMusico"]);
                    ent.AtendeTesteOficialOrganista = (string)(row.IsNull("AtendeTesteOficialOrganista") ? null : row["AtendeTesteOficialOrganista"]);
                    ent.AtendeReuniaoMinisterial = (string)(row.IsNull("AtendeReuniaoMinisterial") ? null : row["AtendeReuniaoMinisterial"]);
                    ent.AtendeCasal = (string)(row.IsNull("AtendeCasal") ? null : row["AtendeCasal"]);
                    ent.AtendeOrdenacao = (string)(row.IsNull("AtendeOrdenacao") ? null : row["AtendeOrdenacao"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.OrdemInstrumento = (string)(row.IsNull("OrdemInstrumento") ? Convert.ToString(null) : Convert.ToString(row["OrdemInstrumento"]).PadLeft(2, '0'));
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.CodCCBGem = (string)(row.IsNull("CodCCBGem") ? Convert.ToString(null) : Convert.ToString(row["CodCCBGem"]).PadLeft(6, '0'));
                    ent.CodigoCCBGem = (string)(row.IsNull("CodigoCCBGem") ? null : row["CodigoCCBGem"]);
                    ent.DescricaoCCBGem = (string)(row.IsNull("DescricaoCCBGem") ? null : row["DescricaoCCBGem"]);
                    ent.EndCCBGem = (string)(row.IsNull("EndCCBGem") ? null : row["EndCCBGem"]);
                    ent.NumCCBGem = (string)(row.IsNull("NumCCBGem") ? null : row["NumCCBGem"]);
                    ent.BairroCCBGem = (string)(row.IsNull("BairroCCBGem") ? null : row["BairroCCBGem"]);
                    ent.ComplCCBGem = (string)(row.IsNull("ComplCCBGem") ? null : row["ComplCCBGem"]);
                    ent.CidadeCCBGem = (string)(row.IsNull("CidadeCCBGem") ? null : row["CidadeCCBGem"]);
                    ent.EstadoCCBGem = (string)(row.IsNull("EstadoCCBGem") ? null : row["EstadoCCBGem"]);
                    ent.CepCCBGem = (string)(row.IsNull("CepCCBGem") ? null : funcoes.FormataString("#####-###", row["CepCCBGem"].ToString()));
                    ent.TelefoneCCBGem = (string)(row.IsNull("TelefoneCCBGem") ? null : row["TelefoneCCBGem"]);
                    ent.CelularCCBGem = (string)(row.IsNull("CelularCCBGem") ? null : row["CelularCCBGem"]);
                    ent.EmailCCBGem = (string)(row.IsNull("EmailCCBGem") ? null : row["EmailCCBGem"]);
                    ent.Desenvolvimento = (string)(row.IsNull("Desenvolvimento") ? null : row["Desenvolvimento"]);
                    ent.DataUltimoTeste = (string)(row.IsNull("DataUltimoTeste") ? Convert.ToString(null) : funcoes.IntData(row["DataUltimoTeste"].ToString()));
                    ent.DataInicioEstudo = (string)(row.IsNull("DataInicioEstudo") ? Convert.ToString(null) : funcoes.IntData(row["DataInicioEstudo"].ToString()));
                    ent.ExecutInstrumento = (string)(row.IsNull("ExecutInstrumento") ? null : row["ExecutInstrumento"]);
                    ent.CodInstrutor = (string)(row.IsNull("CodInstrutor") ? Convert.ToString(null) : Convert.ToString(row["CodInstrutor"]).PadLeft(6, '0'));
                    ent.NomeInstrutor = (string)(row.IsNull("NomeInstrutor") ? null : row["NomeInstrutor"]);
                    ent.CodRegiaoCCB = (string)(row.IsNull("CodRegiaoCCB") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoCCB"]).PadLeft(6, '0'));
                    ent.DescRegiaoCCB = (string)(row.IsNull("DescRegiaoCCB") ? null : row["DescRegiaoCCB"]);
                    ent.CodRegiaoCCBGem = (string)(row.IsNull("CodRegiaoCCBGem") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoCCBGem"]).PadLeft(6, '0'));
                    ent.DescRegiaoCCBGem = (string)(row.IsNull("DescRegiaoCCBGem") ? null : row["DescRegiaoCCBGem"]);
                    ent.MotivoInativa = (string)(row.IsNull("MotivoInativa") ? null : row["MotivoInativa"]);

                    ///Buscar informações sobre o cargo da pessoa
                    objBLL_Cargo = new BLL_cargo();
                    ent.listaCargo = objBLL_Cargo.buscarCod(ent.CodCargo);

                    ///preenche a lista com os dados da Tabela Fotos
                    ent.CarregarFotoPessoa = buscarPessoaFoto(ent.CodPessoa);

                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores pesquisados
                return lista;
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

        #region Lista Pessoa Instrumento

        /// <summary>
        /// Função que Retorna a Lista da Tabela Pessoa Instrumento Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_pessoaInstr> criarListaPessoaInst(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoaInstr> lista = new List<MOD_pessoaInstr>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_pessoaInstr ent = new MOD_pessoaInstr();
                    //adiciona os campos às propriedades
                    ent.CodPessoaInstr = (string)(row.IsNull("CodPessoaInstr") ? Convert.ToString(null) : Convert.ToString(row["CodPessoaInstr"]));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(3, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.Marcado = true;
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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
        /// Função que Retorna uma Lista da Tabela Instrumentos Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_instrumento> criarListaInstr(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_instrumento> lista = new List<MOD_instrumento>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_instrumento ent = new MOD_instrumento();
                    //adiciona os campos às propriedades
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(3, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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

        #region Lista Pessoa Metodo

        /// <summary>
        /// Função que Retorna a Lista da Tabela Pessoa Metodo Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_pessoaMetodo> criarListaPessoaMet(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoaMetodo> lista = new List<MOD_pessoaMetodo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_pessoaMetodo ent = new MOD_pessoaMetodo();
                    //adiciona os campos às propriedades
                    ent.CodPessoaMetodo = (string)(row.IsNull("CodPessoaMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodPessoaMetodo"]));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodMetodo"]).PadLeft(3, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.Marcado = true;
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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
        /// Função que Retorna uma Lista da Tabela Metodos Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_metodoInstr> criarListaMetodo(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_metodoInstr> lista = new List<MOD_metodoInstr>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_metodoInstr ent = new MOD_metodoInstr();
                    //adiciona os campos às propriedades
                    ent.CodMetodoInstr = (string)(row.IsNull("CodMetodoInstr") ? Convert.ToString(null) : row["CodMetodoInstr"].ToString().PadLeft(5, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : row["CodInstrumento"].ToString().PadLeft(5, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : row["CodMetodo"].ToString().PadLeft(3, '0'));
                    ent.AplicarEm = (string)(row.IsNull("AplicarEm") ? null : row["AplicarEm"]);
                    ent.PaginaInicio = (string)(row.IsNull("PaginaInicio") ? Convert.ToString(null) : row["PaginaInicio"].ToString().PadLeft(3, '0'));
                    ent.LicaoInicio = (string)(row.IsNull("LicaoInicio") ? Convert.ToString(null) : row["LicaoInicio"].ToString().PadLeft(3, '0'));
                    ent.PaginaFim = (string)(row.IsNull("PaginaFim") ? Convert.ToString(null) : row["PaginaFim"].ToString().PadLeft(3, '0'));
                    ent.LicaoFim = (string)(row.IsNull("LicaoFim") ? Convert.ToString(null) : row["LicaoFim"].ToString().PadLeft(3, '0'));
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.Inicio = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseInicio.PadLeft(3, '0') + "Pág.: " + ent.PaginaInicio.PadLeft(3, '0') + " - Lição: " + ent.LicaoInicio.PadLeft(3, '0') : "Pág.: " + ent.PaginaInicio.PadLeft(3, '0') + " - Lição: " + ent.LicaoInicio.PadLeft(3, '0');
                    ent.Fim = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseFim.PadLeft(3, '0') + "Pág.: " + ent.PaginaFim.PadLeft(3, '0') + " - Lição: " + ent.LicaoFim.PadLeft(3, '0') : "Pág.: " + ent.PaginaFim.PadLeft(3, '0') + " - Lição: " + ent.LicaoFim.PadLeft(3, '0');
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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

        #region Lista Pessoa CCB

        /// <summary>
        /// Função que Retorna a Lista da Tabela Pessoa Instrumento Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_ccbPessoa> criarListaCCBPessoa(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_ccbPessoa> lista = new BindingList<MOD_ccbPessoa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_ccbPessoa ent = new MOD_ccbPessoa();
                    //adiciona os campos às propriedades
                    ent.CodCCBPessoa = (string)(row.IsNull("CodCCBPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodCCBPessoa"]));
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Endereco = (string)(row.IsNull("Endereco") ? null : row["Endereco"]);
                    ent.Numero = (string)(row.IsNull("Numero") ? null : row["Numero"]);
                    ent.Bairro = (string)(row.IsNull("Bairro") ? null : row["Bairro"]);
                    ent.CodCidade = (string)(row.IsNull("CodCidade") ? Convert.ToString(null) : Convert.ToString(row["CodCidade"]).PadLeft(6, '0'));
                    ent.Cep = (string)(row.IsNull("Cep") ? null : funcoes.FormataString("#####-###", row["Cep"].ToString()));
                    ent.Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]);
                    ent.Cidade = (string)(row.IsNull("Cidade") ? null : row["Cidade"]);
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]));
                    ent.DataApresentacao = (string)(row.IsNull("DataApresentacao") ? Convert.ToString(null) : funcoes.IntData(row["DataApresentacao"].ToString()));
                    ent.CodigoRegiao = (string)(row.IsNull("CodigoRegiao") ? null : row["CodigoRegiao"]);
                    ent.DescRegiao = (string)(row.IsNull("DescRegiao") ? null : row["DescRegiao"]);
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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
        /// Função que Retorna uma Lista da Tabela Instrumentos Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_ccb> criarListaCCB(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_ccb> lista = new List<MOD_ccb>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_ccb ent = new MOD_ccb();
                    //adiciona os campos às propriedades
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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

        #region Lista Pessoa Regiao

        /// <summary>
        /// Função que Retorna a Lista da Tabela Pessoa Região Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_regiaoPessoa> criarListaRegiaoPessoa(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_regiaoPessoa> lista = new BindingList<MOD_regiaoPessoa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_regiaoPessoa ent = new MOD_regiaoPessoa();
                    //adiciona os campos às propriedades
                    ent.CodRegiaoPessoa = (string)(row.IsNull("CodRegiaoPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoPessoa"]));
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.DescRegiao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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
        /// Função que Retorna uma Lista da Tabela Regiao Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_regiaoAtuacao> criarListaRegiao(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_regiaoAtuacao> lista = new List<MOD_regiaoAtuacao>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_regiaoAtuacao ent = new MOD_regiaoAtuacao();
                    //adiciona os campos às propriedades
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.DescRegiao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores
                return lista;
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

        #endregion

        #region Funções de apoio para validações

        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_pessoa validaDadosPessoa(MOD_pessoa ent)
        {
            ent.DataCadastro = string.IsNullOrEmpty(ent.DataCadastro) ? null : funcoes.DataInt(ent.DataCadastro);
            ent.HoraCadastro = string.IsNullOrEmpty(ent.HoraCadastro) ? null : funcoes.HoraInt(ent.HoraCadastro);
            ent.DataNasc = string.IsNullOrEmpty(ent.DataNasc) ? null : funcoes.DataInt(ent.DataNasc);
            ent.DataBatismo = string.IsNullOrEmpty(ent.DataBatismo) ? null : funcoes.DataInt(ent.DataBatismo);
            ent.DataApresentacao = string.IsNullOrEmpty(ent.DataApresentacao) ? null : funcoes.DataInt(ent.DataApresentacao);
            ent.DataUltimoTeste = string.IsNullOrEmpty(ent.DataUltimoTeste) ? null : funcoes.DataInt(ent.DataUltimoTeste);
            ent.DataInicioEstudo = string.IsNullOrEmpty(ent.DataInicioEstudo) ? null : funcoes.DataInt(ent.DataInicioEstudo);
            return ent;
        }

        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_log validaDadosLog(MOD_log ent)
        {
            ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
            ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

            return ent;
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Insert, Update ou Delete</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_pessoa ent, string Operacao)
        {
            try
            {
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsPessoa);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodPessoa + " > Descrição: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditPessoa);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodPessoa + " > Descrição: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcPessoa);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodPessoa + " > Descrição: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("CCBPessoa"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotPesAteComum);
                    ent.Logs.Ocorrencia = "Houve Alteração nas Comuns Congregação de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("CCBPessoaDelete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotPesAteComum);
                    ent.Logs.Ocorrencia = "Houve Exclusão nas Comuns Congregação de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("RegiaoPessoa"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotPesAteRegiao);
                    ent.Logs.Ocorrencia = "Houve Alteração nas Regiões de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("RegiaoPessoaDelete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotPesAteRegiao);
                    ent.Logs.Ocorrencia = "Houve Exclusão nas Regiões de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("PessoaInstr"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotPesAteInstrutor);
                    ent.Logs.Ocorrencia = "Houve Alteração nos Instrumentos que a Pessoa pode ensinar: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("PessoaInstr"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotPesGemMetodo);
                    ent.Logs.Ocorrencia = "Houve Alteração nos Métodos que a Pessoa utiliza: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Import"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotPesImportar);
                    ent.Logs.Ocorrencia = "Importação de pessoas: Nome: < " + ent.Nome + " > CPF: < " + ent.Cpf + " > ";
                }
                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }

        #endregion

    }
}
