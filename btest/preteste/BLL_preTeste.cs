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
    public class BLL_preTeste
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_preTeste objDAL = null;
        DAL_log objDAL_Log = null;

        BLL_preTesteFicha objBLL_Ficha = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_preTeste> listaPreTeste = new List<MOD_preTeste>();
        List<MOD_preTesteFicha> listaFichaPreTeste = new List<MOD_preTesteFicha>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// <para>Operação: Update, Cancela, Encerra, ReAgenda</para>
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_preTeste objEnt, string Operacao)
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

                    this.objDAL = new DAL_preTeste();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, Operacao);
                    objEnt = validaDadosPreTeste(objEnt);
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
        public bool inserir(MOD_preTeste objEnt)
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

                    this.objDAL = new DAL_preTeste();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodPreTeste = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Insert");
                    objEnt = this.validaDadosPreTeste(objEnt);
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
        public bool excluir(MOD_preTeste objEnt)
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

                    this.objDAL = new DAL_preTeste();
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
        /// <param name="CodPreTeste"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarCod(string CodPreTeste)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarCod(CodPreTeste);

                if (objDtb != null)
                {
                    listaPreTeste = criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// <param name="CodPreTeste"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarCod(string CodPreTeste, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarCod(CodPreTeste, CodCCB);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// Função que Transmite o Resultado informado, para pesquisa
        /// </summary>
        /// <param name="Resultado"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarResultado(string Resultado)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarResultado(Resultado);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// Função que Transmite o Resultado e a Congregação informada, para pesquisa
        /// </summary>
        /// <param name="Resultado"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarResultado(string Resultado, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarResultado(Resultado, CodCCB);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// Função que Transmite o Resultado informada, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (DataExame, DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
        /// <para>Resultado: Aprovado, Reprovado, Em Análise</para>
        /// </summary>
        /// <param name="Resultado"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarResultado(string Resultado, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarResultado(Resultado, QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// <returns></returns>
        public List<MOD_preTeste> buscarPessoa(string CodPessoa)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarPessoa(CodPessoa);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// Função que Transmite a Solicitação de Teste informada, para pesquisa
        /// </summary>
        /// <param name="CodSolicitaTeste"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarSolicita(string CodSolicitaTeste)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarSolicita(CodSolicitaTeste);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        public List<MOD_preTeste> buscarComum(string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarComum(CodCCB);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarStatus(string Status)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarStatus(Status);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarStatus(string Status, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarStatus(Status, CodCCB);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// <para>QualData: Informar Qual Data será Pesquisado (DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarStatus(string Status, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarStatus(Status, QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// <para>QualData: Informar Qual Data será Pesquisado (DataExame, DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
        /// </summary>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarData(string QualData, string DataInicial, string DataFinal)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarData(QualData, DataInicial, DataFinal);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        /// <para>QualData: Informar Qual Data será Pesquisado (DataExame, DataAbertura, DataFechamento, DataReAgenda, DataResultado, DataCancela)</para>
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_preTeste> buscarData(string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_preTeste();
                objDtb = objDAL.buscarData(QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaPreTeste = this.criarLista(objDtb);
                }
                return listaPreTeste;
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
        private List<MOD_preTeste> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_preTeste> lista = new List<MOD_preTeste>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_preTeste ent = new MOD_preTeste();
                    //adiciona os campos às propriedades
                    ent.CodPreTeste = (string)(row.IsNull("CodPreTeste") ? Convert.ToString(null) : Convert.ToString(row["CodPreTeste"]).PadLeft(6, '0'));
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
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
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.DescricaoRegiao = (string)(row.IsNull("DescricaoRegiao") ? null : row["DescricaoRegiao"]);
                    ent.Obs = (string)(row.IsNull("Obs") ? null : row["Obs"]);
                    ent.DataExame = (string)(row.IsNull("DataExame") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataExame"])));
                    ent.HoraExame = (string)(row.IsNull("HoraExame") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraExame"])));
                    ent.DataAbertura = (string)(row.IsNull("DataAbertura") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataAbertura"])));
                    ent.HoraAbertura = (string)(row.IsNull("HoraAbertura") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraAbertura"])));
                    ent.CodUsuarioAbertura = (string)(row.IsNull("CodUsuarioAbertura") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioAbertura"]).PadLeft(6, '0'));
                    ent.UsuarioAbertura = (string)(row.IsNull("UsuarioAbertura") ? null : row["UsuarioAbertura"]);
                    ent.DataFechamento = (string)(row.IsNull("DataFechamento") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataFechamento"])));
                    ent.HoraFechamento = (string)(row.IsNull("HoraFechamento") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraFechamento"])));
                    ent.CodUsuarioFechamento = (string)(row.IsNull("CodUsuarioFechamento") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioFechamento"]).PadLeft(6, '0'));
                    ent.UsuarioFechamento = (string)(row.IsNull("UsuarioFechamento") ? null : row["UsuarioFechamento"]);
                    ent.DataReAgenda = (string)(row.IsNull("DataReAgenda") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataReAgenda"])));
                    ent.HoraReAgenda = (string)(row.IsNull("HoraReAgenda") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraReAgenda"])));
                    ent.CodUsuarioReAgenda = (string)(row.IsNull("CodUsuarioReAgenda") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioReAgenda"]).PadLeft(5, '0'));
                    ent.UsuarioReAgenda = (string)(row.IsNull("UsuarioReAgenda") ? null : row["UsuarioReAgenda"]);
                    ent.DataResultado = (string)(row.IsNull("DataResultado") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataResultado"])));
                    ent.HoraResultado = (string)(row.IsNull("HoraResultado") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraResultado"])));
                    ent.Resultado = (string)(row.IsNull("Resultado") ? null : row["Resultado"]);
                    ent.CodUsuarioResultado = (string)(row.IsNull("CodUsuarioResultado") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioResultado"]).PadLeft(5, '0'));
                    ent.UsuarioResultado = (string)(row.IsNull("UsuarioResultado") ? null : row["UsuarioResultado"]);
                    ent.DataCancela = (string)(row.IsNull("DataCancela") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataCancela"])));
                    ent.HoraCancela = (string)(row.IsNull("HoraCancela") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraCancela"])));
                    ent.CodUsuarioCancela = (string)(row.IsNull("CodUsuarioCancela") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioCancela"]).PadLeft(5, '0'));
                    ent.UsuarioCancela = (string)(row.IsNull("UsuarioCancela") ? null : row["UsuarioCancela"]);

                    #region Recebe os valores das Fichas

                    //preenche os dados do cliente
                    objBLL_Ficha = new BLL_preTesteFicha();
                    ent.listaPreTesteFicha = objBLL_Ficha.buscarPreTeste(ent.CodPreTeste, ent.CodCCB);

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

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                objDAL = new DAL_preTeste();
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
        private MOD_preTeste validaDadosPreTeste(MOD_preTeste ent)
        {
            try
            {
                ent.DataExame = string.IsNullOrEmpty(ent.DataExame) ? null : funcoes.DataInt(ent.DataExame);
                ent.HoraExame = string.IsNullOrEmpty(ent.HoraExame) ? null : funcoes.HoraInt(ent.HoraExame);
                ent.DataAbertura = string.IsNullOrEmpty(ent.DataAbertura) ? null : funcoes.DataInt(ent.DataAbertura);
                ent.HoraAbertura = string.IsNullOrEmpty(ent.HoraAbertura) ? null : funcoes.HoraInt(ent.HoraAbertura);
                ent.DataFechamento = string.IsNullOrEmpty(ent.DataFechamento) ? null : funcoes.DataInt(ent.DataFechamento);
                ent.HoraFechamento = string.IsNullOrEmpty(ent.HoraFechamento) ? null : funcoes.HoraInt(ent.HoraFechamento);
                ent.DataReAgenda = string.IsNullOrEmpty(ent.DataReAgenda) ? null : funcoes.DataInt(ent.DataReAgenda);
                ent.HoraReAgenda = string.IsNullOrEmpty(ent.HoraReAgenda) ? null : funcoes.HoraInt(ent.HoraReAgenda);
                ent.DataResultado = string.IsNullOrEmpty(ent.DataResultado) ? null : funcoes.DataInt(ent.DataResultado);
                ent.HoraResultado = string.IsNullOrEmpty(ent.HoraResultado) ? null : funcoes.HoraInt(ent.HoraResultado);
                ent.DataCancela = string.IsNullOrEmpty(ent.DataCancela) ? null : funcoes.DataInt(ent.DataCancela);
                ent.HoraCancela = string.IsNullOrEmpty(ent.HoraCancela) ? null : funcoes.HoraInt(ent.HoraCancela);

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
        /// <para>Parametro Operação - Informar se é Insert, Update, Cancela, Encerra, ReAgenda</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_preTeste ent, string Operacao)
        {
            try
            {
                MOD_acessoPreTeste entAcesso = new MOD_acessoPreTeste();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsPreTeste);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditPreTeste);
                }
                else if (Operacao.Equals("Cancela"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotCancelPreTeste);
                }
                else if (Operacao.Equals("Encerra"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEncerraPreTeste);
                }
                else if (Operacao.Equals("ReAgenda"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotReAgendaPreTeste);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodPreTeste + " > Data Exame: < " + ent.DataExame + " > Comum Congregação: < " + ent.DescricaoCCB + " > ";
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
