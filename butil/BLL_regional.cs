﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using ENT.uteis;
using DAL.uteis;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;

namespace BLL.uteis
{
    public class BLL_regional
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_regional objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_regional> listaRegional = new List<MOD_regional>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_regional objEnt)
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

                    objDAL = new DAL_regional();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false))
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
        public bool inserir(MOD_regional objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    this.objDAL = new DAL_regional();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodRegional = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Insert");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.inserir(objEnt);
                    this.blnRetornoLog = this.objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false) || this.blnRetornoLog.Equals(false))
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
        public bool excluir(MOD_regional objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    this.objDAL = new DAL_regional();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Delete");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.excluir(objEnt);
                    this.blnRetornoLog = this.objDAL_Log.inserir(objEnt.Logs);

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

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public List<MOD_regional> buscarCod(string CodRegiao)
        {
            try
            {
                objDAL = new DAL_regional();
                objDtb = objDAL.buscarCod(CodRegiao);

                if (objDtb != null)
                {
                    listaRegional = this.criarLista(objDtb);
                }
                return listaRegional;
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
        /// Função que Transmite o Código informada, para pesquisa
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public List<MOD_regional> buscarCodigo(string Codigo)
        {
            try
            {
                objDAL = new DAL_regional();
                objDtb = objDAL.buscarCodigo(Codigo + "%");

                if (objDtb != null)
                {
                    listaRegional = this.criarLista(objDtb);
                }
                return listaRegional;
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
        /// Função que Transmite a Descrição informada, para pesquisa
        /// </summary>
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public List<MOD_regional> buscarDescricao(string Descricao)
        {
            try
            {
                objDAL = new DAL_regional();
                objDtb = objDAL.buscarDescricao(Descricao + "%");

                if (objDtb != null)
                {
                    listaRegional = this.criarLista(objDtb);
                }
                return listaRegional;
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
        /// Função que Transmite o Estado informada, para pesquisa
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public List<MOD_regional> buscarEstado(string Estado)
        {
            try
            {
                objDAL = new DAL_regional();
                objDtb = objDAL.buscarEstado(Estado);

                if (objDtb != null)
                {
                    listaRegional = criarLista(objDtb);
                }
                return listaRegional;
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
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public int retornaId()
        {
            try
            {
                objDAL = new DAL_regional();
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
        private List<MOD_regional> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_regional> lista = new List<MOD_regional>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_regional ent = new MOD_regional();
                    //adiciona os campos às propriedades
                    ent.CodRegional = (string)(row.IsNull("CodRegional") ? Convert.ToString(null) : Convert.ToString(row["CodRegional"]).PadLeft(5, '0'));
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]);
                    ent.CaminhoBD = (string)(row.IsNull("CaminhoBD") ? null : row["CaminhoBD"]);
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

        #endregion

        #region Funções de apoio para validações

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
        private MOD_log criarLog(MOD_regional ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = MOD_acessoRegional.RotInsRegional.ToString();
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = MOD_acessoRegional.RotEditRegional.ToString();
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = MOD_acessoRegional.RotExcRegional.ToString();
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodRegional + " > Descrição: < " + ent.Descricao + " > ";
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
