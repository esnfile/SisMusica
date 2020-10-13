using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.ComponentModel;

using DAL.preTeste;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using BLL.pessoa;
using ENT.preTeste;

namespace BLL.preTeste
{
    public class BLL_preTesteFicha
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_preTesteFicha objDAL = null;
        DAL_preTesteMet objDAL_Met = null;
        DAL_preTesteMts objDAL_Mts = null;
        DAL_preTesteEscala objDAL_Escala = null;
        DAL_preTesteHino objDAL_Hino = null;
        DAL_preTesteTeoria objDAL_Teoria = null;
        DAL_log objDAL_Log = null;

        BLL_solicitaTeste objBLL_Solicita = null;

        //BLL_pessoa objBLL_Pessoa = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoMet;
        bool blnRetornoDelMet;
        bool blnRetornoMts;
        bool blnRetornoDelMts;
        bool blnRetornoEscala;
        bool blnRetornoDelEscala;
        bool blnRetornoHino;
        bool blnRetornoDelHino;
        bool blnRetornoTeoria;
        bool blnRetornoDelTeoria;
        bool blnRetornoSolicita;
        bool blnRetornoLog;

        DataTable objDtb = null;
        DataTable objDtb_Met = null;
        DataTable objDtb_Mts = null;
        DataTable objDtb_Escala = null;
        DataTable objDtb_Teoria = null;
        DataTable objDtb_Hino = null;

        List<MOD_preTesteFicha> listaFichaPreTeste = new List<MOD_preTesteFicha>();
        BindingList<MOD_preTesteMet> listaPreTesteMet = new BindingList<MOD_preTesteMet>();
        List<MOD_preTesteMet> listaDeletePreTesteMet = new List<MOD_preTesteMet>();
        BindingList<MOD_preTesteMts> listaPreTesteMts = new BindingList<MOD_preTesteMts>();
        List<MOD_preTesteMts> listaDeletePreTesteMts = new List<MOD_preTesteMts>();
        BindingList<MOD_preTesteEscala> listaPreTesteEscala = new BindingList<MOD_preTesteEscala>();
        List<MOD_preTesteEscala> listaDeletePreTesteEscala = new List<MOD_preTesteEscala>();
        BindingList<MOD_preTesteHino> listaPreTesteHino = new BindingList<MOD_preTesteHino>();
        List<MOD_preTesteHino> listaDeletePreTesteHino = new List<MOD_preTesteHino>();
        BindingList<MOD_preTesteTeoria> listaPreTesteTeoria = new BindingList<MOD_preTesteTeoria>();
        List<MOD_preTesteTeoria> listaDeletePreTesteTeoria = new List<MOD_preTesteTeoria>();
        List<MOD_solicitaTeste> listaSolicita = new List<MOD_solicitaTeste>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTesteFicha objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;
                    this.blnRetornoMet = true;
                    this.blnRetornoDelMet = true;
                    this.blnRetornoMts = true;
                    this.blnRetornoDelMts = true;
                    this.blnRetornoEscala = true;
                    this.blnRetornoDelEscala = true;
                    this.blnRetornoHino = true;
                    this.blnRetornoDelHino = true;
                    this.blnRetornoTeoria = true;
                    this.blnRetornoDelTeoria = true;
                    this.blnRetornoSolicita = true;

                    #endregion

                    #region Movimento na tabela PreTeste e Logs

                    this.objDAL = new DAL_preTesteFicha();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt = validaDadosFichaPreTeste(objEnt);
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimento na tabela PreTesteMet

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteMet != null && objEnt.listaPreTesteMet.Count > 0)
                    {
                        this.objDAL_Met = new DAL_preTesteMet();

                        foreach (MOD_preTesteMet ent in objEnt.listaPreTesteMet)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoMet = this.objDAL_Met.salvar(ent);

                            if (this.blnRetornoMet.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete PreTesteMet

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaDeletePreTesteMet != null && objEnt.listaDeletePreTesteMet.Count > 0)
                    {
                        this.objDAL_Met = new DAL_preTesteMet();

                        foreach (MOD_preTesteMet ent in objEnt.listaDeletePreTesteMet)
                        {
                            if (!Convert.ToInt64(ent.CodPreTesteMet).Equals(0))
                            {
                                this.blnRetornoDelMet = this.objDAL_Met.excluir(ent);

                                if (this.blnRetornoDelMet.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteMts

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteMts != null && objEnt.listaPreTesteMts.Count > 0)
                    {
                        this.objDAL_Mts = new DAL_preTesteMts();

                        foreach (MOD_preTesteMts ent in objEnt.listaPreTesteMts)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoMts = this.objDAL_Mts.salvar(ent);

                            if (this.blnRetornoMts.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete PreTesteMts

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaDeletePreTesteMts != null && objEnt.listaDeletePreTesteMts.Count > 0)
                    {
                        this.objDAL_Mts = new DAL_preTesteMts();

                        foreach (MOD_preTesteMts ent in objEnt.listaDeletePreTesteMts)
                        {
                            if (!Convert.ToInt64(ent.CodPreTesteMts).Equals(0))
                            {
                                this.blnRetornoDelMts = this.objDAL_Mts.excluir(ent);

                                if (this.blnRetornoDelMts.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteEscala

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteEscala != null && objEnt.listaPreTesteEscala.Count > 0)
                    {
                        this.objDAL_Escala = new DAL_preTesteEscala();

                        foreach (MOD_preTesteEscala ent in objEnt.listaPreTesteEscala)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoEscala = this.objDAL_Escala.salvar(ent);

                            if (this.blnRetornoEscala.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete PreTesteEscala

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaDeletePreTesteEscala != null && objEnt.listaDeletePreTesteEscala.Count > 0)
                    {
                        this.objDAL_Escala = new DAL_preTesteEscala();

                        foreach (MOD_preTesteEscala ent in objEnt.listaDeletePreTesteEscala)
                        {
                            if (!Convert.ToInt64(ent.CodPreTesteEscala).Equals(0))
                            {
                                this.blnRetornoDelEscala = this.objDAL_Escala.excluir(ent);

                                if (this.blnRetornoDelEscala.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteHino

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteHino != null && objEnt.listaPreTesteHino.Count > 0)
                    {
                        this.objDAL_Hino = new DAL_preTesteHino();

                        foreach (MOD_preTesteHino ent in objEnt.listaPreTesteHino)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoHino = this.objDAL_Hino.salvar(ent);

                            if (this.blnRetornoHino.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete PreTesteHino

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaDeletePreTesteHino != null && objEnt.listaDeletePreTesteHino.Count > 0)
                    {
                        this.objDAL_Hino = new DAL_preTesteHino();

                        foreach (MOD_preTesteHino ent in objEnt.listaDeletePreTesteHino)
                        {
                            if (!Convert.ToInt64(ent.CodPreTesteHino).Equals(0))
                            {
                                this.blnRetornoDelHino = this.objDAL_Hino.excluir(ent);

                                if (this.blnRetornoDelHino.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteTeoria

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteTeoria != null && objEnt.listaPreTesteTeoria.Count > 0)
                    {
                        this.objDAL_Teoria = new DAL_preTesteTeoria();

                        foreach (MOD_preTesteTeoria ent in objEnt.listaPreTesteTeoria)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoTeoria = this.objDAL_Teoria.salvar(ent);

                            if (this.blnRetornoTeoria.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela Delete PreTesteTeoria

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaDeletePreTesteTeoria != null && objEnt.listaDeletePreTesteTeoria.Count > 0)
                    {
                        this.objDAL_Teoria = new DAL_preTesteTeoria();

                        foreach (MOD_preTesteTeoria ent in objEnt.listaDeletePreTesteTeoria)
                        {
                            if (!Convert.ToInt64(ent.CodPreTesteTeoria).Equals(0))
                            {
                                this.blnRetornoDelTeoria = this.objDAL_Teoria.excluir(ent);

                                if (this.blnRetornoDelTeoria.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela SolicitaTeste

                    objBLL_Solicita = new BLL_solicitaTeste();
                    listaSolicita = new List<MOD_solicitaTeste>();

                    //Busca a solicitação para fazer a alteração
                    listaSolicita = objBLL_Solicita.buscarCod(objEnt.CodSolicitaTeste);

                    //verifica se há registro na lista produtos para fazer atualização
                    if (listaSolicita != null && listaSolicita.Count > 0)
                    {
                        objBLL_Solicita = new BLL_solicitaTeste();

                        foreach (MOD_solicitaTeste ent in listaSolicita)
                        {
                            MOD_solicitaTeste objEnt_Solicita = new MOD_solicitaTeste();

                            objEnt_Solicita.CodSolicitaTeste = ent.CodSolicitaTeste;
                            objEnt_Solicita.Tipo = ent.Tipo;
                            objEnt_Solicita.CodPessoa = ent.CodPessoa;
                            objEnt_Solicita.Data = ent.Data;
                            objEnt_Solicita.Hora = ent.Hora;
                            objEnt_Solicita.CodUsuario = ent.CodUsuario;
                            objEnt_Solicita.Status = "Autorizada";

                            blnRetornoSolicita = objBLL_Solicita.salvar(objEnt_Solicita, "Update");

                            if (blnRetornoSolicita.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false) || 
                        this.blnRetornoMet.Equals(false) || this.blnRetornoDelMet.Equals(false) ||
                        this.blnRetornoMts.Equals(false) || this.blnRetornoDelMts.Equals(false) ||
                        this.blnRetornoEscala.Equals(false) || this.blnRetornoDelEscala.Equals(false) ||
                        this.blnRetornoHino.Equals(false) || this.blnRetornoDelHino.Equals(false) ||
                        this.blnRetornoTeoria.Equals(false) || this.blnRetornoDelTeoria.Equals(false) ||
                        this.blnRetornoSolicita.Equals(false) || this.blnRetornoLog.Equals(false))
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
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_preTesteFicha objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;
                    this.blnRetornoMet = true;
                    this.blnRetornoMts = true;
                    this.blnRetornoEscala = true;
                    this.blnRetornoHino = true;
                    this.blnRetornoTeoria = true;
                    this.blnRetornoSolicita = true;

                    #endregion

                    #region Movimento na tabela PreTeste e Logs

                    this.objDAL = new DAL_preTesteFicha();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodFichaPreTeste = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Insert");
                    objEnt = this.validaDadosFichaPreTeste(objEnt);
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.inserir(objEnt);
                    this.blnRetornoLog = this.objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimento na tabela PreTesteMet

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteMet != null && objEnt.listaPreTesteMet.Count > 0)
                    {
                        this.objDAL_Met = new DAL_preTesteMet();

                        foreach (MOD_preTesteMet ent in objEnt.listaPreTesteMet)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoMet = this.objDAL_Met.salvar(ent);

                            if (this.blnRetornoMet.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteMts

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteMts != null && objEnt.listaPreTesteMts.Count > 0)
                    {
                        this.objDAL_Mts = new DAL_preTesteMts();

                        foreach (MOD_preTesteMts ent in objEnt.listaPreTesteMts)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoMts = this.objDAL_Mts.salvar(ent);

                            if (this.blnRetornoMts.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteEscala

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteEscala != null && objEnt.listaPreTesteEscala.Count > 0)
                    {
                        this.objDAL_Escala = new DAL_preTesteEscala();

                        foreach (MOD_preTesteEscala ent in objEnt.listaPreTesteEscala)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoEscala = this.objDAL_Escala.salvar(ent);

                            if (this.blnRetornoEscala.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteHino

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteHino != null && objEnt.listaPreTesteHino.Count > 0)
                    {
                        this.objDAL_Hino = new DAL_preTesteHino();

                        foreach (MOD_preTesteHino ent in objEnt.listaPreTesteHino)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoHino = this.objDAL_Hino.salvar(ent);

                            if (this.blnRetornoHino.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela PreTesteTeoria

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.listaPreTesteTeoria != null && objEnt.listaPreTesteTeoria.Count > 0)
                    {
                        this.objDAL_Teoria = new DAL_preTesteTeoria();

                        foreach (MOD_preTesteTeoria ent in objEnt.listaPreTesteTeoria)
                        {
                            ent.CodFichaPreTeste = objEnt.CodFichaPreTeste;
                            this.blnRetornoTeoria = this.objDAL_Teoria.salvar(ent);

                            if (this.blnRetornoTeoria.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimento na tabela SolicitaTeste

                    objBLL_Solicita = new BLL_solicitaTeste();
                    listaSolicita = new List<MOD_solicitaTeste>();

                    //Busca a solicitação para fazer a alteração
                    listaSolicita = objBLL_Solicita.buscarCod(objEnt.CodSolicitaTeste);

                    //verifica se há registro na lista produtos para fazer atualização
                    if (listaSolicita != null && listaSolicita.Count > 0)
                    {
                        objBLL_Solicita = new BLL_solicitaTeste();

                        foreach (MOD_solicitaTeste ent in listaSolicita)
                        {
                            MOD_solicitaTeste objEnt_Solicita = new MOD_solicitaTeste();

                            objEnt_Solicita.CodSolicitaTeste = ent.CodSolicitaTeste;
                            objEnt_Solicita.Tipo = ent.Tipo;
                            objEnt_Solicita.CodPessoa = ent.CodPessoa;
                            objEnt_Solicita.Data = ent.Data;
                            objEnt_Solicita.Hora = ent.Hora;
                            objEnt_Solicita.CodUsuario = ent.CodUsuario;
                            objEnt_Solicita.Status = "Autorizada";

                            blnRetornoSolicita = objBLL_Solicita.salvar(objEnt_Solicita, "Update");

                            if (blnRetornoSolicita.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false) || this.blnRetornoMet.Equals(false) || 
                        this.blnRetornoMts.Equals(false) || this.blnRetornoEscala.Equals(false) || 
                        this.blnRetornoHino.Equals(false) || this.blnRetornoTeoria.Equals(false) || 
                        this.blnRetornoLog.Equals(false) || this.blnRetornoSolicita.Equals(false))
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
        public bool excluir(MOD_preTesteFicha objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela PreTeste e Logs

                    this.objDAL = new DAL_preTesteFicha();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Delete");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.excluir(objEnt);
                    this.blnRetornoLog = this.objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimento na tabela SolicitaTeste

                    objBLL_Solicita = new BLL_solicitaTeste();
                    listaSolicita = new List<MOD_solicitaTeste>();

                    //Busca a solicitação para fazer a alteração
                    listaSolicita = objBLL_Solicita.buscarCod(objEnt.CodSolicitaTeste);

                    //verifica se há registro na lista produtos para fazer atualização
                    if (listaSolicita != null && listaSolicita.Count > 0)
                    {
                        objBLL_Solicita = new BLL_solicitaTeste();

                        foreach (MOD_solicitaTeste ent in listaSolicita)
                        {
                            MOD_solicitaTeste objEnt_Solicita = new MOD_solicitaTeste();

                            objEnt_Solicita.CodSolicitaTeste = ent.CodSolicitaTeste;
                            objEnt_Solicita.Tipo = ent.Tipo;
                            objEnt_Solicita.CodPessoa = ent.CodPessoa;
                            objEnt_Solicita.Data = ent.Data;
                            objEnt_Solicita.Hora = ent.Hora;
                            objEnt_Solicita.CodUsuario = ent.CodUsuario;
                            objEnt_Solicita.Status = "Pendente";

                            blnRetornoSolicita = objBLL_Solicita.salvar(objEnt_Solicita, "Update");

                            if (blnRetornoSolicita.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false) || this.blnRetornoLog.Equals(false))
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

        #region Funções que transmite os Critério para a DAL realizar a Busca no Banco

        #region Busca os valores da Tabela

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarCod(string CodFichaPreTeste)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarCod(CodFichaPreTeste);

                if (objDtb != null)
                {
                    listaFichaPreTeste = criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite o Código e a congregação informado, para pesquisa
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarCod(string CodFichaPreTeste, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarCod(CodFichaPreTeste, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite a Pessoa e a Congregação informada, para pesquisa
        /// </summary>
        /// <param name="CodCandidato"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarPessoa(string CodCandidato, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarPessoa(CodCandidato, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite a Pessoa informada, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="CodCandidato"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarPessoa(string CodCandidato, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarPessoa(CodCandidato, QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite o PreTeste informada, para pesquisa
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarPreTeste(string CodPreTeste)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarPreTeste(CodPreTeste);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite o PreTeste informada, para pesquisa
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarPreTeste(string CodPreTeste, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarPreTeste(CodPreTeste, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite o PreTeste informada, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarPreTeste(string CodPreTeste, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarPreTeste(CodPreTeste, QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite o Tipo informado, para pesquisa
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarTipo(string Tipo, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarTipo(Tipo, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite o Tipo informado, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarTipo(string Tipo, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarTipo(Tipo, QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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
        /// Função que Transmite a Data PreTeste informado, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTesteFicha> buscarData(string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
                objDtb = objDAL.buscarData(QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaFichaPreTeste = this.criarLista(objDtb);
                }
                return listaFichaPreTeste;
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

        #region Busca os valores das Tabelas Relacionadas

        #region PreTesteMet

        /// <summary>
        /// Função que Transmite a FichaPreTeste informado, para pesquisa na
        /// Tabela FichaPreTesteMet
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <returns></returns>       
        public BindingList<MOD_preTesteMet> buscarFichaPreTesteMet(string CodFichaPreTeste)
        {
            try
            {
                objDAL_Met = new DAL_preTesteMet();
                objDtb_Met = objDAL_Met.buscarFichaPreTeste(CodFichaPreTeste);

                if (objDtb_Met != null)
                {
                    listaPreTesteMet = this.criarListaMet(objDtb_Met);
                }
                return listaPreTesteMet;
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

        #region PreTesteMts

        /// <summary>
        /// Função que Transmite o FichaPreTeste informado, para pesquisa na
        /// Tabela FichaPreTesteMts
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <returns></returns>       
        public BindingList<MOD_preTesteMts> buscarFichaPreTesteMts(string CodFichaPreTeste)
        {
            try
            {
                objDAL_Mts = new DAL_preTesteMts();
                objDtb_Mts = objDAL_Mts.buscarFichaPreTeste(CodFichaPreTeste);

                if (objDtb_Mts != null)
                {
                    listaPreTesteMts = this.criarListaMts(objDtb_Mts);
                }
                return listaPreTesteMts;
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

        #region PreTesteTeoria

        /// <summary>
        /// Função que Transmite o FichaPreTeste informado, para pesquisa na
        /// Tabela FichaPreTesteTeoria
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <returns></returns>       
        public BindingList<MOD_preTesteTeoria> buscarFichaPreTesteTeoria(string CodFichaPreTeste)
        {
            try
            {
                objDAL_Teoria = new DAL_preTesteTeoria();
                objDtb_Teoria = objDAL_Teoria.buscarFichaPreTeste(CodFichaPreTeste);

                if (objDtb_Teoria != null)
                {
                    listaPreTesteTeoria = this.criarListaTeoria(objDtb_Teoria);
                }
                return listaPreTesteTeoria;
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

        #region PreTesteEscala

        /// <summary>
        /// Função que Transmite o FichaPreTeste informado, para pesquisa na
        /// Tabela FichaPreTesteEscala
        /// </summary>
        /// <param name="CodPreTeste"></param>
        /// <returns></returns>       
        public BindingList<MOD_preTesteEscala> buscarFichaPreTesteEscala(string CodFichaPreTeste)
        {
            try
            {
                objDAL_Escala = new DAL_preTesteEscala();
                objDtb_Escala = objDAL_Escala.buscarFichaPreTeste(CodFichaPreTeste);

                if (objDtb_Escala != null)
                {
                    listaPreTesteEscala = this.criarListaEscala(objDtb_Escala);
                }
                return listaPreTesteEscala;
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

        #region PreTesteHino

        /// <summary>
        /// Função que Transmite o FichaPreTeste informado, para pesquisa na
        /// Tabela FichaPreTesteHino
        /// </summary>
        /// <param name="CodFichaPreTeste"></param>
        /// <returns></returns>       
        public BindingList<MOD_preTesteHino> buscarFichaPreTesteHino(string CodFichaPreTeste)
        {
            try
            {
                objDAL_Hino = new DAL_preTesteHino();
                objDtb_Hino = objDAL_Hino.buscarFichaPreTeste(CodFichaPreTeste);

                if (objDtb_Hino != null)
                {
                    listaPreTesteHino = this.criarListaHino(objDtb_Hino);
                }
                return listaPreTesteHino;
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

        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_preTesteFicha> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_preTesteFicha> lista = new List<MOD_preTesteFicha>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_preTesteFicha ent = new MOD_preTesteFicha();
                    //adiciona os campos às propriedades
                    ent.CodFichaPreTeste = (string)(row.IsNull("CodFichaPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodFichaPreTeste"]).PadLeft(6, '0'));
                    ent.CodSolicitaTeste = (string)(row.IsNull("CodSolicitaTeste") ? Convert.ToString(null) : Convert.ToString(row["CodSolicitaTeste"]).PadLeft(6, '0'));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.Obs = (string)(row.IsNull("Obs") ? null : row["Obs"]);
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["Data"])));
                    ent.Hora = (string)(row.IsNull("Hora") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["Hora"])));
                    ent.ObsMet = (string)(row.IsNull("ObsMet") ? null : row["ObsMet"]);
                    ent.ObsMts = (string)(row.IsNull("ObsMts") ? null : row["ObsMts"]);
                    ent.ObsHino = (string)(row.IsNull("ObsHino") ? null : row["ObsHino"]);
                    ent.ObsEsc = (string)(row.IsNull("ObsEsc") ? null : row["ObsEsc"]);
                    ent.ObsTeoria = (string)(row.IsNull("ObsTeoria") ? null : row["ObsTeoria"]);

                    //Tabela PreTeste
                    ent.CodPreTeste = (string)(row.IsNull("CodPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodPreTeste"]).PadLeft(6, '0'));
                    ent.DataExame = (string)(row.IsNull("DataExame") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataExame"])));
                    ent.HoraExame = (string)(row.IsNull("HoraExame") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraExame"])));
                    ent.DataAbertura = (string)(row.IsNull("DataAbertura") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataAbertura"])));
                    ent.HoraAbertura = (string)(row.IsNull("HoraAbertura") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraAbertura"])));
                    ent.DataFechamento = (string)(row.IsNull("DataFechamento") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataFechamento"])));
                    ent.HoraFechamento = (string)(row.IsNull("HoraFechamento") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraFechamento"])));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.DescricaoRegiao = (string)(row.IsNull("DescricaoRegiao") ? null : row["DescricaoRegiao"]);
                    ent.CodAnciao = (string)(row.IsNull("CodAnciao") ? Convert.ToString(null) : Convert.ToString(row["CodAnciao"]).PadLeft(6, '0'));
                    ent.NomeAnciao = (string)(row.IsNull("NomeAnciao") ? null : row["NomeAnciao"]);
                    ent.CodCooperador = (string)(row.IsNull("CodCooperador") ? Convert.ToString(null) : Convert.ToString(row["CodCooperador"]).PadLeft(6, '0'));
                    ent.NomeCooperador = (string)(row.IsNull("NomeCooperador") ? null : row["NomeCooperador"]);
                    ent.CodEncReg = (string)(row.IsNull("CodEncReg") ? Convert.ToString(null) : Convert.ToString(row["CodEncReg"]).PadLeft(6, '0'));
                    ent.NomeEncReg = (string)(row.IsNull("NomeEncReg") ? null : row["NomeEncReg"]);
                    ent.CodEncLocal = (string)(row.IsNull("CodEncLocal") ? Convert.ToString(null) : Convert.ToString(row["CodEncLocal"]).PadLeft(6, '0'));
                    ent.NomeEncLocal = (string)(row.IsNull("NomeEncLocal") ? null : row["NomeEncLocal"]);
                    ent.CodExamina = (string)(row.IsNull("CodExamina") ? Convert.ToString(null) : Convert.ToString(row["CodExamina"]).PadLeft(6, '0'));
                    ent.NomeExamina = (string)(row.IsNull("NomeExamina") ? null : row["NomeExamina"]);
                    ent.CodInstrutor = (string)(row.IsNull("CodInstrutor") ? Convert.ToString(null) : Convert.ToString(row["CodInstrutor"]).PadLeft(6, '0'));
                    ent.NomeInstrutor = (string)(row.IsNull("NomeInstrutor") ? null : row["NomeInstrutor"]);

                    //Tabela Pessoa
                    ent.CodCandidato = (string)(row.IsNull("CodCandidato") ? Convert.ToString(null) : Convert.ToString(row["CodCandidato"]).PadLeft(6, '0'));
                    ent.NomeCandidato = (string)(row.IsNull("NomeCandidato") ? null : row["NomeCandidato"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.CodCidadeRes = (string)(row.IsNull("CodCidadeRes") ? Convert.ToString(null) : Convert.ToString(row["CodCidadeRes"]).PadLeft(6, '0'));
                    ent.CidadeRes = (string)(row.IsNull("CidadeRes") ? null : row["CidadeRes"]);
                    ent.EstadoRes = (string)(row.IsNull("EstadoRes") ? null : row["EstadoRes"]);
                    ent.CodCCBPessoa = (string)(row.IsNull("CodCCBPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodCCBPessoa"]).PadLeft(6, '0'));
                    ent.CodigoCCBPessoa = (string)(row.IsNull("CodigoCCBPessoa") ? null : row["CodigoCCBPessoa"]);
                    ent.DescricaoCCBPessoa = (string)(row.IsNull("DescricaoCCBPessoa") ? null : row["DescricaoCCBPessoa"]);
                    ent.CodCidadeCCBPessoa = (string)(row.IsNull("CodCidadeCCBPessoa") ? null : Convert.ToString(row["CodCidadeCCBPessoa"]).PadLeft(6, '0'));
                    ent.CidadeCCBPessoa = (string)(row.IsNull("CidadeCCBPessoa") ? null : row["CidadeCCBPessoa"]);
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(2, '0'));
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);
                    ent.CodRegiaoPessoa = (string)(row.IsNull("CodRegiaoPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoPessoa"]).PadLeft(6, '0'));
                    ent.DescricaoRegiaoPessoa = (string)(row.IsNull("DescricaoRegiaoPessoa") ? null : row["DescricaoRegiaoPessoa"]);
                    ent.Sexo = (string)(row.IsNull("Sexo") ? null : row["Sexo"]);
                    ent.CodInstrutorPessoa = (string)(row.IsNull("CodInstrutorPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodInstrutorPessoa"]).PadLeft(6, '0'));
                    ent.NomeInstrutorPessoa = (string)(row.IsNull("NomeInstrutorPessoa") ? null : row["NomeInstrutorPessoa"]);


                    #region Recebe os valores PreTesteMet

                    ///preenche a lista com os dados da tabela PreTesteMet
                    ent.listaPreTesteMet = buscarFichaPreTesteMet(ent.CodFichaPreTeste);

                    #endregion

                    #region Recebe os valores PreTesteMts

                    ///preenche a lista com os dados da tabela PreTesteMts
                    ent.listaPreTesteMts = buscarFichaPreTesteMts(ent.CodFichaPreTeste);

                    #endregion

                    #region Recebe os valores PreTesteTeoria

                    ///preenche a lista com os dados da tabela PreTesteTeoria
                    ent.listaPreTesteTeoria = buscarFichaPreTesteTeoria(ent.CodFichaPreTeste);

                    #endregion

                    #region Recebe os valores PreTesteHino

                    ///preenche a lista com os dados da tabela PreTesteHino
                    ent.listaPreTesteHino = buscarFichaPreTesteHino(ent.CodFichaPreTeste);

                    #endregion

                    #region Recebe os valores PreTesteEscala

                    ///preenche a lista com os dados da tabela PreTesteEscala
                    ent.listaPreTesteEscala = buscarFichaPreTesteEscala(ent.CodFichaPreTeste);

                    #endregion

                    //adiciona os dados à lista
                    lista.Add(ent);

                }

                //retorna a lista com os valores preenchidos
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

        #region Lista que serão Preenchidas com os DataTable Retornados das Tabelas relacionadas

        #region PreTesteMet

        /// <summary>
        /// Função que Retorna a Lista da Tabela PreTesteMet Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_preTesteMet> criarListaMet(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_preTesteMet> lista = new BindingList<MOD_preTesteMet>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {

                    //instancia a entidade
                    MOD_preTesteMet ent = new MOD_preTesteMet();
                    //adiciona os campos às propriedades
                    ent.CodPreTesteMet = (string)(row.IsNull("CodPreTesteMet") ? Convert.ToString(null) : Convert.ToString(row["CodPreTesteMet"]).PadLeft(6, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodMetodo"]).PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.TipoMetodo = (string)(row.IsNull("TipoMetodo") ? null : row["TipoMetodo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.CodFichaPreTeste = (string)(row.IsNull("CodFichaPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodFichaPreTeste"]).PadLeft(6, '0'));
                    ent.CodPreTeste = (string)(row.IsNull("CodPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodPreTeste"]).PadLeft(6, '0'));
                    ent.CodSolicitaTeste = (string)(row.IsNull("CodSolicitaTeste") ? Convert.ToString(null) : Convert.ToString(row["CodSolicitaTeste"]).PadLeft(6, '0'));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.CodCandidato = (string)(row.IsNull("CodCandidato") ? Convert.ToString(null) : Convert.ToString(row["CodCandidato"]).PadLeft(6, '0'));
                    ent.NomeCandidato = (string)(row.IsNull("NomeCandidato") ? null : row["NomeCandidato"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.FaseMet = (string)(row.IsNull("FaseMet") ? Convert.ToString(null) : Convert.ToString(row["FaseMet"]));
                    ent.PaginaMet = (string)(row.IsNull("PaginaMet") ? Convert.ToString(null) : Convert.ToString(row["PaginaMet"]));
                    ent.LicaoMet = (string)(row.IsNull("LicaoMet") ? Convert.ToString(null) : Convert.ToString(row["LicaoMet"]));
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["Data"])));
                    ent.Hora = (string)(row.IsNull("Hora") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["Hora"])));
                    ent.DataExame = (string)(row.IsNull("DataExame") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataExame"])));
                    ent.HoraExame = (string)(row.IsNull("HoraExame") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraExame"])));
                    ent.FasePagLicao = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseMet.PadLeft(3, '0') + " - Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0') : ent.PaginaFase.Equals("Página") ? "Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0') : "Lição: " + ent.LicaoMet.PadLeft(3, '0');

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

        #region PreTesteMts

        /// <summary>
        /// Função que Retorna a Lista da Tabela PreTesteMts Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_preTesteMts> criarListaMts(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_preTesteMts> lista = new BindingList<MOD_preTesteMts>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {

                    //instancia a entidade
                    MOD_preTesteMts ent = new MOD_preTesteMts();
                    //adiciona os campos às propriedades
                    ent.CodPreTesteMts = (string)(row.IsNull("CodPreTesteMts") ? Convert.ToString(null) : Convert.ToString(row["CodPreTesteMts"]).PadLeft(6, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodMetodo"]).PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.CodFichaPreTeste = (string)(row.IsNull("CodFichaPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodFichaPreTeste"]).PadLeft(6, '0'));
                    ent.CodPreTeste = (string)(row.IsNull("CodPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodPreTeste"]).PadLeft(6, '0'));
                    ent.CodSolicitaTeste = (string)(row.IsNull("CodSolicitaTeste") ? Convert.ToString(null) : Convert.ToString(row["CodSolicitaTeste"]).PadLeft(6, '0'));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.TipoMts = (string)(row.IsNull("TipoMts") ? null : row["TipoMts"]);
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.CodCandidato = (string)(row.IsNull("CodCandidato") ? Convert.ToString(null) : Convert.ToString(row["CodCandidato"]).PadLeft(6, '0'));
                    ent.NomeCandidato = (string)(row.IsNull("NomeCandidato") ? null : row["NomeCandidato"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : row["CodCCB"].ToString().PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.ModuloMts = (string)(row.IsNull("ModuloMts") ? Convert.ToString(null) : Convert.ToString(row["ModuloMts"]).PadLeft(2, '0'));
                    ent.LicaoMts = (string)(row.IsNull("LicaoMts") ? Convert.ToString(null) : Convert.ToString(row["LicaoMts"]).PadLeft(2, '0'));
                    ent.ModuloLicao = "Módulo: " + ent.ModuloMts.PadLeft(2, '0') + " - Lição: " + ent.LicaoMts.PadLeft(2, '0');
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["Data"])));
                    ent.Hora = (string)(row.IsNull("Hora") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["Hora"])));
                    ent.DataExame = (string)(row.IsNull("DataExame") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataExame"])));
                    ent.HoraExame = (string)(row.IsNull("HoraExame") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraExame"])));

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

        #region PreTesteTeoria

        /// <summary>
        /// Função que Retorna a Lista da Tabela PreTesteTeoria Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_preTesteTeoria> criarListaTeoria(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_preTesteTeoria> lista = new BindingList<MOD_preTesteTeoria>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {

                    //instancia a entidade
                    MOD_preTesteTeoria ent = new MOD_preTesteTeoria();
                    //adiciona os campos às propriedades
                    ent.CodPreTesteTeoria = (string)(row.IsNull("CodPreTesteTeoria") ? Convert.ToString(null) : Convert.ToString(row["CodPreTesteTeoria"]).PadLeft(6, '0'));
                    ent.CodPreTeste = (string)(row.IsNull("CodPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodPreTeste"]).PadLeft(6, '0'));
                    ent.CodTeoria = (string)(row.IsNull("CodTeoria") ? Convert.ToString(null) : Convert.ToString(row["CodTeoria"]).PadLeft(3, '0'));
                    ent.DescTeoria = (string)(row.IsNull("DescTeoria") ? null : row["DescTeoria"]);
                    ent.CodFichaPreTeste = (string)(row.IsNull("CodFichaPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodFichaPreTeste"]).PadLeft(6, '0'));
                    ent.CodSolicitaTeste = (string)(row.IsNull("CodSolicitaTeste") ? Convert.ToString(null) : Convert.ToString(row["CodSolicitaTeste"]).PadLeft(6, '0'));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.CodCandidato = (string)(row.IsNull("CodCandidato") ? Convert.ToString(null) : Convert.ToString(row["CodCandidato"]).PadLeft(6, '0'));
                    ent.NomeCandidato = (string)(row.IsNull("NomeCandidato") ? null : row["NomeCandidato"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["Data"])));
                    ent.Hora = (string)(row.IsNull("Hora") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["Hora"])));
                    ent.DataExame = (string)(row.IsNull("DataExame") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataExame"])));
                    ent.HoraExame = (string)(row.IsNull("HoraExame") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraExame"])));
                    ent.AplicaEm = (string)(row.IsNull("AplicaEm") ? null : row["AplicaEm"]);
                    ent.TipoCadastro = (string)(row.IsNull("TipoCadastro") ? null : row["TipoCadastro"]);
                    ent.Nivel = (string)(row.IsNull("Nivel") ? null : row["Nivel"]);
                    ent.Paginas = (string)(row.IsNull("Paginas") ? Convert.ToString(null) : Convert.ToString(row["Paginas"]).PadLeft(2, '0'));

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

        #region PreTesteHino

        /// <summary>
        /// Função que Retorna a Lista da Tabela PreTesteHino Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_preTesteHino> criarListaHino(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_preTesteHino> lista = new BindingList<MOD_preTesteHino>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {

                    //instancia a entidade
                    MOD_preTesteHino ent = new MOD_preTesteHino();
                    //adiciona os campos às propriedades
                    ent.CodPreTesteHino = (string)(row.IsNull("CodPreTesteHino") ? Convert.ToString(null) : Convert.ToString(row["CodPreTesteHino"]).PadLeft(6, '0'));
                    ent.CodPreTeste = (string)(row.IsNull("CodPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodPreTeste"]).PadLeft(6, '0'));
                    ent.CodHinario = (string)(row.IsNull("CodHinario") ? Convert.ToString(null) : Convert.ToString(row["CodHinario"]).PadLeft(3, '0'));
                    ent.DescHinario = (string)(row.IsNull("DescHinario") ? null : row["DescHinario"]);
                    ent.CodTonalidade = (string)(row.IsNull("CodTonalidade") ? Convert.ToString(null) : Convert.ToString(row["CodTonalidade"]).PadLeft(3, '0'));
                    ent.DescTonalidade = (string)(row.IsNull("DescTonalidade") ? null : row["DescTonalidade"]);
                    ent.CodFichaPreTeste = (string)(row.IsNull("CodFichaPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodFichaPreTeste"]).PadLeft(6, '0'));
                    ent.CodSolicitaTeste = (string)(row.IsNull("CodSolicitaTeste") ? Convert.ToString(null) : Convert.ToString(row["CodSolicitaTeste"]).PadLeft(6, '0'));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.CodCandidato = (string)(row.IsNull("CodCandidato") ? Convert.ToString(null) : Convert.ToString(row["CodCandidato"]).PadLeft(6, '0'));
                    ent.NomeCandidato = (string)(row.IsNull("NomeCandidato") ? null : row["NomeCandidato"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : row["CodCCB"].ToString().PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["Data"])));
                    ent.Hora = (string)(row.IsNull("Hora") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["Hora"])));
                    ent.DataExame = (string)(row.IsNull("DataExame") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataExame"])));
                    ent.HoraExame = (string)(row.IsNull("HoraExame") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraExame"])));
                    ent.Hino = (string)(row.IsNull("Hino") ? Convert.ToString(null) : Convert.ToString(row["Hino"]));

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

        #region PreTesteEscala

        /// <summary>
        /// Função que Retorna a Lista da Tabela PreTesteEscala Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_preTesteEscala> criarListaEscala(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_preTesteEscala> lista = new BindingList<MOD_preTesteEscala>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {

                    //instancia a entidade
                    MOD_preTesteEscala ent = new MOD_preTesteEscala();
                    //adiciona os campos às propriedades
                    ent.CodPreTesteEscala = (string)(row.IsNull("CodPreTesteEscala") ? Convert.ToString(null) : Convert.ToString(row["CodPreTesteEscala"]).PadLeft(6, '0'));
                    ent.CodPreTeste = (string)(row.IsNull("CodPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodPreTeste"]).PadLeft(6, '0'));
                    ent.CodEscala = (string)(row.IsNull("CodEscala") ? Convert.ToString(null) : Convert.ToString(row["CodEscala"]).PadLeft(3, '0'));
                    ent.DescEscala = (string)(row.IsNull("DescEscala") ? null : row["DescEscala"]);
                    ent.CodTipoEscala = (string)(row.IsNull("CodTipoEscala") ? Convert.ToString(null) : Convert.ToString(row["CodTipoEscala"]).PadLeft(3, '0'));
                    ent.DescTipoEscala = (string)(row.IsNull("DescTipoEscala") ? null : row["DescTipoEscala"]);
                    ent.CodFichaPreTeste = (string)(row.IsNull("CodFichaPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodFichaPreTeste"]).PadLeft(6, '0'));
                    ent.CodSolicitaTeste = (string)(row.IsNull("CodSolicitaTeste") ? Convert.ToString(null) : Convert.ToString(row["CodSolicitaTeste"]).PadLeft(6, '0'));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.CodCandidato = (string)(row.IsNull("CodCandidato") ? Convert.ToString(null) : Convert.ToString(row["CodCandidato"]).PadLeft(6, '0'));
                    ent.NomeCandidato = (string)(row.IsNull("NomeCandidato") ? null : row["NomeCandidato"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : row["CodCCB"].ToString().PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["Data"])));
                    ent.Hora = (string)(row.IsNull("Hora") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["Hora"])));
                    ent.DataExame = (string)(row.IsNull("DataExame") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataExame"])));
                    ent.HoraExame = (string)(row.IsNull("HoraExame") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraExame"])));

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

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                objDAL = new DAL_preTesteFicha();
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

        #endregion

        #region Funções de apoio para validações

        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_preTesteFicha validaDadosFichaPreTeste(MOD_preTesteFicha ent)
        {
            try
            {
                ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
                ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

                return ent;
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
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_log validaDadosLog(MOD_log ent)
        {
            try
            {
                ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
                ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

                return ent;
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
        /// Função que criar os dados para tabela Logs
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Insert, Update, Cancela, Finalizar, ReAgendar</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_preTesteFicha ent, string Operacao)
        {
            try
            {
                MOD_acessoFichaPreTeste entAcesso = new MOD_acessoFichaPreTeste();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsFichaPreTeste);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditFichaPreTeste);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcFichaPreTeste);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodFichaPreTeste + " > Candidato(a): < " + ent.NomeCandidato + " > ";
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