﻿using System;
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

namespace BLL.pessoa
{
    public class BLL_cargo
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_cargo objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_cargo> listaCargo = new List<MOD_cargo>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_cargo objEnt)
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

                    this.objDAL = new DAL_cargo();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Update");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.salvar(objEnt);
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
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_cargo objEnt)
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

                    this.objDAL = new DAL_cargo();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodCargo = Convert.ToString(this.retornaId());

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
        public bool excluir(MOD_cargo objEnt)
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

                    this.objDAL = new DAL_cargo();
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
        /// <param name="CodCargo"></param>
        /// <returns></returns>
        public List<MOD_cargo> buscarCod(string CodCargo)
        {
            try
            {
                objDAL = new DAL_cargo();
                objDtb = objDAL.buscarCod(CodCargo);

                if (objDtb != null)
                {
                    listaCargo = this.criarLista(objDtb);
                }
                return listaCargo;
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
        /// <param name="DescCargo"></param>
        /// <returns></returns>
        public List<MOD_cargo> buscarDescricao(string DescCargo)
        {
            try
            {
                objDAL = new DAL_cargo();
                objDtb = objDAL.buscarDescricao(DescCargo + "%");

                if (objDtb != null)
                {
                    listaCargo = this.criarLista(objDtb);
                }
                return listaCargo;
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
        public Int16 retornaId()
        {
            try
            {
                objDAL = new DAL_cargo();
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
        private List<MOD_cargo> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_cargo> lista = new List<MOD_cargo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_cargo ent = new MOD_cargo();
                    //adiciona os campos às propriedades
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : row["CodCargo"].ToString().PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : row["Ordem"].ToString().PadLeft(2, '0'));
                    ent.CodDepartamento = (string)(row.IsNull("CodDepartamento") ? Convert.ToString(null) : row["CodDepartamento"].ToString().PadLeft(3, '0'));
                    ent.DescDepartamento = (string)(row.IsNull("DescDepartamento") ? null : row["DescDepartamento"]);
                    ent.PermiteEdicao = (string)(row.IsNull("PermiteEdicao") ? null : row["PermiteEdicao"]);
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
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);
                    ent.PermiteInstrumento = (string)(row.IsNull("PermiteInstrumento") ? null : row["PermiteInstrumento"]);
                    ent.AlunoGem = (string)(row.IsNull("AlunoGem") ? null : row["AlunoGem"]);
                    ent.Ensaio = (string)(row.IsNull("Ensaio") ? null : row["Ensaio"]);
                    ent.MeiaHora = (string)(row.IsNull("MeiaHora") ? null : row["MeiaHora"]);
                    ent.Rjm = (string)(row.IsNull("Rjm") ? null : row["Rjm"]);
                    ent.Culto = (string)(row.IsNull("Culto") ? null : row["Culto"]);
                    ent.Oficial = (string)(row.IsNull("Oficial") ? null : row["Oficial"]);
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
        private MOD_log criarLog(MOD_cargo ent, string Operacao)
        {
            try
            {
                MOD_acessoCargo entAcesso = new MOD_acessoCargo();

                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsCargo);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditCargo);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcCargo);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodCargo + " > Descrição: < " + ent.DescCargo + " > ";
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
