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
    public class BLL_solicitaTeste
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_solicitaTeste objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_solicitaTeste> listaSolicita = new List<MOD_solicitaTeste>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// <para>Operação: Update, Cancela, Autoriza, Nega</para>
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_solicitaTeste objEnt, string Operacao)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela SolicitaTeste e Logs

                    this.objDAL = new DAL_solicitaTeste();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, Operacao);
                    objEnt = validaDadosSolicita(objEnt, Operacao);
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

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
        public bool inserir(MOD_solicitaTeste objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela SolicitaTeste e Logs

                    this.objDAL = new DAL_solicitaTeste();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodSolicitaTeste = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Insert");
                    objEnt = this.validaDadosSolicita(objEnt, "Insert");
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
        public bool excluir(MOD_solicitaTeste objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela SolicitaTeste e Logs

                    this.objDAL = new DAL_solicitaTeste();
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

        #region Busca os valores da Tabela

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodSolicitaTeste"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarCod(string CodSolicitaTeste)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarCod(CodSolicitaTeste);

                if (objDtb != null)
                {
                    listaSolicita = criarLista(objDtb);
                }
                return listaSolicita;
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
        /// <param name="CodSolicitaTeste"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarCod(string CodSolicitaTeste, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarCod(CodSolicitaTeste, CodCCBUsu);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodSolicitaTeste"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarCod(string CodSolicitaTeste, string CodCCBUsu, string Status)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarCod(CodSolicitaTeste, CodCCBUsu, Status);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// Função que Transmite o Tipo e a Congregação informada, para pesquisa
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarTipo(string Tipo, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarTipo(Tipo, CodCCBUsu);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// Função que Transmite o Tipo e a Congregação informada, para pesquisa
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="Tipo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarTipo(string Tipo, string CodCCBUsu, string Status)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarTipo(Tipo, CodCCBUsu, Status);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// Função que Transmite o Status informada, para pesquisa
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarStatus(string Status, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarStatus(Status, CodCCBUsu);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarPessoa(string CodPessoa, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarPessoa(CodPessoa, CodCCBUsu);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarPessoa(string CodPessoa, string CodCCBUsu, string Status)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarPessoa(CodPessoa, CodCCBUsu, Status);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        public List<MOD_solicitaTeste> buscarCCB(string CodCCB)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarCCB(CodCCB);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarCCB(string CodCCB, string Status)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarCCB(CodCCB, Status);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        public List<MOD_solicitaTeste> buscarRegiao(string CodRegiao)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarRegiao(CodRegiao);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarRegiao(string CodRegiao, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarRegiao(CodRegiao, CodCCBUsu);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarRegiao(string CodRegiao, string CodCCBUsu, string Status)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarRegiao(CodRegiao, CodCCBUsu, Status);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// Função que Transmite o Usuario informada, para pesquisa
        /// </summary>
        /// <param name="CodUsuario"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarUsuario(string CodUsuario, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarUsuario(CodUsuario, CodCCBUsu);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// Função que Transmite a Data SolicitaTeste informado, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarData(string DataInicial, string DataFinal, string CodCCBUsu)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarData(funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal), CodCCBUsu);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// Função que Transmite a Data SolicitaTeste informado, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (Data)</para>
        /// <para>[Status]='Pendente', 'Cancelada', 'Autorizada', 'Negada'</para>
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Status"></param>
        /// <returns></returns>
        public List<MOD_solicitaTeste> buscarData(string DataInicial, string DataFinal, string CodCCBUsu, string Status)
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
                objDtb = objDAL.buscarData(DataInicial, DataFinal, CodCCBUsu, Status);

                if (objDtb != null)
                {
                    listaSolicita = this.criarLista(objDtb);
                }
                return listaSolicita;
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_solicitaTeste> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_solicitaTeste> lista = new List<MOD_solicitaTeste>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_solicitaTeste ent = new MOD_solicitaTeste();
                    //adiciona os campos às propriedades
                    ent.CodSolicitaTeste = (string)(row.IsNull("CodSolicitaTeste") ? Convert.ToString(null) : Convert.ToString(row["CodSolicitaTeste"]).PadLeft(6, '0'));
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.CodigoRegiao = (string)(row.IsNull("CodigoRegiao") ? null : row["CodigoRegiao"]);
                    ent.DescricaoRegiao = (string)(row.IsNull("DescricaoRegiao") ? null : row["DescricaoRegiao"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["Data"])));
                    ent.Hora = (string)(row.IsNull("Hora") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["Hora"])));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);

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

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                objDAL = new DAL_solicitaTeste();
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
        private MOD_solicitaTeste validaDadosSolicita(MOD_solicitaTeste ent, string Operacao)
        {
            try
            {
                ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
                ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

                if (Operacao.Equals("Cancela"))
                {
                    ent.Status = "Cancelada";
                }
                else if (Operacao.Equals("Nega"))
                {
                    ent.Status = "Negada";
                }
                else if (Operacao.Equals("Autoriza"))
                {
                    ent.Status = "Autorizada";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Status = ent.Status;
                }
                else if (Operacao.Equals("Pendente"))
                {
                    ent.Status = ent.Status;
                }

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
        /// <para>Parametro Operação - Informar se é Insert, Update, Cancela, Autoriza, Nega, Delete</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_solicitaTeste ent, string Operacao)
        {
            try
            {
                MOD_acessoSolicitaTeste entAcesso = new MOD_acessoSolicitaTeste();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsSolicitaTeste);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditSolicitaTeste);
                }
                else if (Operacao.Equals("Cancela"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotCancelSolicitaTeste);
                }
                else if (Operacao.Equals("Nega"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotNegaSolicitaTeste);
                }
                else if (Operacao.Equals("Autoriza"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotAutorizaSolicitaTeste);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcSolicitaTeste);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodSolicitaTeste + " > Tipo: < " + ent.Tipo + " > Data: < " + ent.Data + " > Aluno(a): < " + ent.Nome + " > ";
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