﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using DAL.licao;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using ENT.licao;

namespace BLL.licao
{
    public class BLL_licaoTesteHino
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_licaoTesteHino objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_licaoTesteHino> listaLicao = new List<MOD_licaoTesteHino>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteHino objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação das tabelas TesteHino e Logs

                    objDAL = new DAL_licaoTesteHino();
                    objDAL_Log = new DAL_log();

                    if (objEnt.CodLicaoHino.Equals(string.Empty))
                    {
                        objEnt.Logs = criarLog(objEnt, "Insert");
                    }
                    else
                    {
                        objEnt.Logs = criarLog(objEnt, "Update");
                    }

                    //Chama a função que converte as datas
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
        /// Função que Transmite a Entidade para a DAL fazer DELETE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_licaoTesteHino objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela LicaoTeste e Logs

                    objDAL = new DAL_licaoTesteHino();
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

        #endregion

        #region Funções que transmite os Critério para a DAL realizar a Busca no Banco

        /// <summary>
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteHino> buscarLicaoHino(string CodInstrumento)
        {
            try
            {
                objDAL = new DAL_licaoTesteHino();
                objDtb = objDAL.buscarLicaoHino(CodInstrumento);

                if (objDtb != null)
                {
                    listaLicao = criarLista(objDtb);
                }
                return listaLicao;
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
        /// Função que Transmite o Instrumento e o Hinario informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodHinario"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteHino> buscarLicaoHino(string CodInstrumento, string CodHinario)
        {
            try
            {
                objDAL = new DAL_licaoTesteHino();
                objDtb = objDAL.buscarLicaoHino(CodInstrumento, CodHinario);

                if (objDtb != null)
                {
                    listaLicao = criarLista(objDtb);
                }
                return listaLicao;
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
        /// Função que Transmite o Instrumento e o Hinario informado, para pesquisa
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodHinario"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteHino> buscarLicaoHino(string CodInstrumento, string CodHinario, string AplicaEm)
        {
            try
            {
                objDAL = new DAL_licaoTesteHino();
                objDtb = objDAL.buscarLicaoHino(CodInstrumento, CodHinario, AplicaEm);

                if (objDtb != null)
                {
                    listaLicao = criarLista(objDtb);
                }
                return listaLicao;
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
        /// Função que Transmite o Instrumento e o Hinario informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodHinario"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteHino> buscarLicaoDescHino(string CodInstrumento, string CodHinario)
        {
            try
            {
                objDAL = new DAL_licaoTesteHino();
                objDtb = objDAL.buscarLicaoDescHino(CodInstrumento, CodHinario);

                if (objDtb != null)
                {
                    listaLicao = criarLista(objDtb);
                }
                return listaLicao;
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
        public Int32 retornaId()
        {
            try
            {
                objDAL = new DAL_licaoTesteHino();
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
        private List<MOD_licaoTesteHino> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_licaoTesteHino> lista = new List<MOD_licaoTesteHino>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_licaoTesteHino ent = new MOD_licaoTesteHino();
                    //adiciona os campos às propriedades
                    ent.CodLicaoHino = (string)(row.IsNull("CodLicaoHino") ? Convert.ToString(null) : Convert.ToString(row["CodLicaoHino"]).PadLeft(4, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodHinario = (string)(row.IsNull("CodHinario") ? Convert.ToString(null) : Convert.ToString(row["CodHinario"]).PadLeft(3, '0'));
                    ent.CodTonalidade = (string)(row.IsNull("CodTonalidade") ? Convert.ToString(null) : Convert.ToString(row["CodTonalidade"]).PadLeft(3, '0'));
                    ent.DescHinario = (string)(row.IsNull("DescHinario") ? null : row["DescHinario"]);
                    ent.Nota = (string)(row.IsNull("Nota") ? null : row["Nota"]);
                    ent.Alteracoes = (string)(row.IsNull("Alteracoes") ? null : row["Alteracoes"]);
                    ent.DescTonalidade = (string)(row.IsNull("DescTonalidade") ? null : row["DescTonalidade"]);
                    ent.AplicaEm = (string)(row.IsNull("AplicaEm") ? null : row["AplicaEm"]);
                    ent.Hino = (string)(row.IsNull("Hino") ? Convert.ToString(null) : Convert.ToString(row["Hino"]).PadLeft(3, '0'));
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
        private MOD_log criarLog(MOD_licaoTesteHino ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotInsLicaoTesteHino);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotEditLicaoTesteHino);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotExcLicaoTesteHino);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Alterado Lição! Código: < " + ent.CodLicaoHino + " > Instrumento: < " + ent.DescInstrumento + " > Hinário: < " + ent.DescHinario + " > Aplicado em: < " + ent.AplicaEm + " >. ";
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
