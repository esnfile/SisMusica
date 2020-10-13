using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.ComponentModel;

using DAL.administracao;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using ENT.preTeste;
using ENT.administracao;

namespace BLL.administracao
{
    public class BLL_reuniaoMinisterio
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_reuniaoMinisterio objDAL = null;
        DAL_log objDAL_Log = null;

        BLL_listaPresenca objBLL_presenca = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_reuniaoMinisterio> listaReuniao = new List<MOD_reuniaoMinisterio>();
        List<MOD_listaPresenca> listaPresenca = new List<MOD_listaPresenca>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// <para>Operação: Update, Cancela, Finaliza, ReAgenda</para>
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_reuniaoMinisterio objEnt, string Operacao)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela ReuniaoMinisterio e Logs

                    this.objDAL = new DAL_reuniaoMinisterio();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, Operacao);
                    objEnt = validaDadosReuniao(objEnt);
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
        public bool inserir(MOD_reuniaoMinisterio objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela ReuniaoMinisterio e Logs

                    this.objDAL = new DAL_reuniaoMinisterio();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodReuniao = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Insert");
                    objEnt = this.validaDadosReuniao(objEnt);
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
        public bool excluir(MOD_reuniaoMinisterio objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela ReuniaoMinisterio e Logs

                    this.objDAL = new DAL_reuniaoMinisterio();
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
        /// <param name="CodReuniao"></param>
        /// <returns></returns>
        public List<MOD_reuniaoMinisterio> buscarCod(string CodReuniao)
        {
            try
            {
                objDAL = new DAL_reuniaoMinisterio();
                objDtb = objDAL.buscarCod(CodReuniao);

                if (objDtb != null)
                {
                    listaReuniao = criarLista(objDtb);
                }
                return listaReuniao;
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
        /// <param name="CodReuniao"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_reuniaoMinisterio> buscarCod(string CodReuniao, string CodCCB)
        {
            try
            {
                objDAL = new DAL_reuniaoMinisterio();
                objDtb = objDAL.buscarCod(CodReuniao, CodCCB);

                if (objDtb != null)
                {
                    listaReuniao = this.criarLista(objDtb);
                }
                return listaReuniao;
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
        public List<MOD_reuniaoMinisterio> buscarStatus(string Status, string CodCCB)
        {
            try
            {
                objDAL = new DAL_reuniaoMinisterio();
                objDtb = objDAL.buscarStatus(Status, CodCCB);

                if (objDtb != null)
                {
                    listaReuniao = this.criarLista(objDtb);
                }
                return listaReuniao;
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
        /// Função que Transmite o ReuniaoMinisterio informada, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (DataInclusao, DataReuniao, DataFinaliza, DataCancela)</para>
        /// </summary>
        /// <param name="Status"></param>
        /// <param name="QualData"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_reuniaoMinisterio> buscarStatus(string Status, string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_reuniaoMinisterio();
                objDtb = objDAL.buscarStatus(Status, QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaReuniao = this.criarLista(objDtb);
                }
                return listaReuniao;
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
        /// Função que Transmite a Data ReuniaoMinisterio informado, para pesquisa
        /// <para>QualData: Informar Qual Data será Pesquisado (DataInclusao, DataReuniao, DataFinaliza, DataCancela)</para>
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_reuniaoMinisterio> buscarData(string QualData, string DataInicial, string DataFinal, string CodCCB)
        {
            try
            {
                objDAL = new DAL_reuniaoMinisterio();
                objDtb = objDAL.buscarData(QualData, DataInicial, DataFinal, CodCCB);

                if (objDtb != null)
                {
                    listaReuniao = this.criarLista(objDtb);
                }
                return listaReuniao;
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
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_reuniaoMinisterio> buscarRegiao(string CodRegiao, string CodCCB)
        {
            try
            {
                objDAL = new DAL_reuniaoMinisterio();
                objDtb = objDAL.buscarRegiao(CodRegiao, CodCCB);

                if (objDtb != null)
                {
                    listaReuniao = this.criarLista(objDtb);
                }
                return listaReuniao;
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
        private List<MOD_reuniaoMinisterio> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_reuniaoMinisterio> lista = new List<MOD_reuniaoMinisterio>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_reuniaoMinisterio ent = new MOD_reuniaoMinisterio();
                    //adiciona os campos às propriedades
                    ent.CodReuniao = (string)(row.IsNull("CodReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodReuniao"]).PadLeft(6, '0'));
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.DataInclusao = (string)(row.IsNull("DataInclusao") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataInclusao"])));
                    ent.HoraInclusao = (string)(row.IsNull("HoraInclusao") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraInclusao"])));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.DataReuniao = (string)(row.IsNull("DataReuniao") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataReuniao"])));
                    ent.HoraReuniao = (string)(row.IsNull("HoraReuniao") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraReuniao"])));
                    ent.CodTipoReuniao = (string)(row.IsNull("CodTipoReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodTipoReuniao"]).PadLeft(3, '0'));
                    ent.DescTipoReuniao = (string)(row.IsNull("DescTipoReuniao") ? null : row["DescTipoReuniao"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0'));
                    ent.DescricaoRegiao = (string)(row.IsNull("DescricaoRegiao") ? null : row["DescricaoRegiao"]);
                    ent.DataFinaliza = (string)(row.IsNull("DataFinaliza") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataFinaliza"])));
                    ent.HoraFinaliza = (string)(row.IsNull("HoraFinaliza") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraFinaliza"])));
                    ent.CodUsuarioFinaliza = (string)(row.IsNull("CodUsuarioFinaliza") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioFinaliza"]).PadLeft(5, '0'));
                    ent.UsuarioFinaliza = (string)(row.IsNull("UsuarioFinaliza") ? null : row["UsuarioFinaliza"]);
                    ent.DataCancela = (string)(row.IsNull("DataCancela") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataCancela"])));
                    ent.HoraCancela = (string)(row.IsNull("HoraCancela") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraCancela"])));
                    ent.CodUsuarioCancela = (string)(row.IsNull("CodUsuarioCancela") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioCancela"]).PadLeft(5, '0'));
                    ent.UsuarioCancela = (string)(row.IsNull("UsuarioCancela") ? null : row["UsuarioCancela"]);
                    ent.CodAnciao = (string)(row.IsNull("CodAnciao") ? Convert.ToString(null) : Convert.ToString(row["CodAnciao"]).PadLeft(6, '0'));
                    ent.NomeAnciao = (string)(row.IsNull("NomeAnciao") ? null : row["NomeAnciao"]);
                    ent.CodEncReg = (string)(row.IsNull("CodEncReg") ? Convert.ToString(null) : Convert.ToString(row["CodEncReg"]).PadLeft(6, '0'));
                    ent.NomeEncReg = (string)(row.IsNull("NomeEncReg") ? null : row["NomeEncReg"]);
                    ent.CodExamina = (string)(row.IsNull("CodExamina") ? Convert.ToString(null) : Convert.ToString(row["CodExamina"]).PadLeft(6, '0'));
                    ent.NomeExamina = (string)(row.IsNull("NomeExamina") ? null : row["NomeExamina"]);
                    ent.CodBiblia = (string)(row.IsNull("CodBiblia") ? Convert.ToString(null) : Convert.ToString(row["CodBiblia"]).PadLeft(2, '0'));
                    ent.DescLivro = (string)(row.IsNull("DescLivro") ? null : row["DescLivro"]);
                    ent.Capitulo = (string)(row.IsNull("Capitulo") ? Convert.ToString(null) : Convert.ToString(row["Capitulo"]).PadLeft(3, '0'));
                    ent.VersoInicio = (string)(row.IsNull("VersoInicio") ? Convert.ToString(null) : Convert.ToString(row["VersoInicio"]).PadLeft(3, '0'));
                    ent.VersoFim = (string)(row.IsNull("VersoFim") ? Convert.ToString(null) : Convert.ToString(row["VersoFim"]).PadLeft(3, '0'));
                    ent.AssuntoPalavra = (string)(row.IsNull("AssuntoPalavra") ? null : row["AssuntoPalavra"]);
                    ent.HinoAbertura = (string)(row.IsNull("HinoAbertura") ? Convert.ToString(null) : Convert.ToString(row["HinoAbertura"]).PadLeft(3, '0'));
                    ent.Obs = (string)(row.IsNull("Obs") ? null : row["Obs"]);

                    #region Recebe os valores da Lista de Presenca

                    ////preenche os dados do cliente
                    //objBLL_presenca = new BLL_listaPresenca();
                    //ent.listaPresenca = objBLL_presenca.buscarListaPresenca(ent.CodReuniao);

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
                objDAL = new DAL_reuniaoMinisterio();
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
        private MOD_reuniaoMinisterio validaDadosReuniao(MOD_reuniaoMinisterio ent)
        {
            try
            {
                ent.DataInclusao = string.IsNullOrEmpty(ent.DataInclusao) ? null : funcoes.DataInt(ent.DataInclusao);
                ent.HoraInclusao = string.IsNullOrEmpty(ent.HoraInclusao) ? null : funcoes.HoraInt(ent.HoraInclusao);
                ent.DataReuniao = string.IsNullOrEmpty(ent.DataReuniao) ? null : funcoes.DataInt(ent.DataReuniao);
                ent.HoraReuniao = string.IsNullOrEmpty(ent.HoraReuniao) ? null : funcoes.HoraInt(ent.HoraReuniao);
                ent.DataFinaliza = string.IsNullOrEmpty(ent.DataFinaliza) ? null : funcoes.DataInt(ent.DataFinaliza);
                ent.HoraFinaliza = string.IsNullOrEmpty(ent.HoraFinaliza) ? null : funcoes.HoraInt(ent.HoraFinaliza);
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
        /// <para>Parametro Operação - Informar se é Insert, Update, Cancela, Finaliza</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_reuniaoMinisterio ent, string Operacao)
        {
            try
            {
                MOD_acessoReuniao entAcesso = new MOD_acessoReuniao();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsReuniao);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditReuniao);
                }
                else if (Operacao.Equals("Cancela"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotCancelReuniao);
                }
                else if (Operacao.Equals("Finaliza"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotFinalReuniao);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodReuniao + " > Data Reunião: < " + ent.DataReuniao + " > Comum Congregação: < " + ent.DescricaoCCB + " > ";
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
