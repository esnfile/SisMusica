using System;
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
using System.ComponentModel;
using ENT.instrumentos;

namespace BLL.uteis
{
    public class BLL_parametros
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_parametros objDAL = null;
        DAL_log objDAL_Log = null;
        DAL_parametroPreTesteMet objDAL_ParamPreTeste = null;
        DAL_parametroTesteMet objDAL_ParamTeste = null;

        BLL_regional objBLL_Regional = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoParamPre;
        bool blnRetornoParamTeste;
        bool blnRetornoLog;
        bool blnRetornoLogPre;
        bool blnRetornoLogTeste;

        DataTable objDtb = null;
        DataTable objDtb_MetInstr = null;
        DataTable objDtb_ParamPreTeste = null;
        DataTable objDtb_ParamTeste = null;

        List<MOD_parametros> listaParam = new List<MOD_parametros>();
        BindingList<MOD_parametroPreTesteMet> listaParamPreTeste = new BindingList<MOD_parametroPreTesteMet>();
        BindingList<MOD_parametroTesteMet> listaParamTeste = new BindingList<MOD_parametroTesteMet>();
        List<MOD_metodoInstr> listaMetodoInstr = new List<MOD_metodoInstr>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_parametros objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;
                    blnRetornoParamPre = true;
                    blnRetornoParamTeste = true;
                    blnRetornoLog = true;
                    blnRetornoLogPre = true;
                    blnRetornoLogTeste = true;

                    #endregion

                    #region Movimentação da tabela Parametros e Logs

                    objDAL = new DAL_parametros();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela ParametroPreTesteMet

                    //verifica se há registro na lista
                    if (objEnt.listaParamPreTeste != null && objEnt.listaParamPreTeste.Count > 0)
                    {
                        objDAL_ParamPreTeste = new DAL_parametroPreTesteMet();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_parametroPreTesteMet ent in objEnt.listaParamPreTeste)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "ParamPreTeste");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodParametro = objEnt.CodParametro;
                            blnRetornoParamPre = objDAL_ParamPreTeste.salvar(ent);
                            blnRetornoLogPre = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoParamPre.Equals(false) || blnRetornoLogPre.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela ParametroTesteMet

                    //verifica se há registro na lista
                    if (objEnt.listaParamTeste != null && objEnt.listaParamTeste.Count > 0)
                    {
                        objDAL_ParamTeste = new DAL_parametroTesteMet();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_parametroTesteMet ent in objEnt.listaParamTeste)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "ParamTeste");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodParametro = objEnt.CodParametro;
                            blnRetornoParamTeste = objDAL_ParamTeste.salvar(ent);
                            blnRetornoLogTeste = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoParamTeste.Equals(false) || blnRetornoLogTeste.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) ||
                        blnRetornoParamTeste.Equals(false) || blnRetornoLogTeste.Equals(false) ||
                        blnRetornoParamPre.Equals(false) || blnRetornoLogPre.Equals(false))
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
        public bool inserir(MOD_parametros objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;
                    blnRetornoParamPre = true;
                    blnRetornoParamTeste = true;
                    blnRetornoLog = true;
                    blnRetornoLogPre = true;
                    blnRetornoLogTeste = true;

                    #endregion

                    #region Movimentação da tabela Parametros e Logs

                    objDAL = new DAL_parametros();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodParametro = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela ParametroPreTesteMet

                    //verifica se há registro na lista
                    if (objEnt.listaParamPreTeste != null && objEnt.listaParamPreTeste.Count > 0)
                    {
                        objDAL_ParamPreTeste = new DAL_parametroPreTesteMet();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_parametroPreTesteMet ent in objEnt.listaParamPreTeste)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "ParamPreTeste");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodParametro = objEnt.CodParametro;
                            blnRetornoParamPre = objDAL_ParamPreTeste.salvar(ent);
                            blnRetornoLogPre = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoParamPre.Equals(false) || blnRetornoLogPre.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela ParametroTesteMet

                    //verifica se há registro na lista
                    if (objEnt.listaParamTeste != null && objEnt.listaParamTeste.Count > 0)
                    {
                        objDAL_ParamTeste = new DAL_parametroTesteMet();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_parametroTesteMet ent in objEnt.listaParamTeste)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "ParamTeste");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodParametro = objEnt.CodParametro;
                            blnRetornoParamTeste = objDAL_ParamTeste.salvar(ent);
                            blnRetornoLogTeste = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoParamTeste.Equals(false) || blnRetornoLogTeste.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) ||
                        blnRetornoParamTeste.Equals(false) || blnRetornoLogTeste.Equals(false) ||
                        blnRetornoParamPre.Equals(false) || blnRetornoLogPre.Equals(false))
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
        public bool excluir(MOD_parametros objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Tonalidade e Logs

                    objDAL = new DAL_parametros();
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
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>
        public List<MOD_parametros> buscarCod(string CodParametro)
        {
            try
            {
                objDAL = new DAL_parametros();
                objDtb = objDAL.buscarCod(CodParametro);

                if (objDtb != null)
                {
                    listaParam = this.criarLista(objDtb);
                }
                return listaParam;
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
        /// Função que Transmite a Regional informada, para pesquisa
        /// </summary>
        /// <param name="CodRegional"></param>
        /// <returns></returns>
        public List<MOD_parametros> buscarRegional(string CodRegional)
        {
            try
            {
                objDAL = new DAL_parametros();
                objDtb = objDAL.buscarRegional(CodRegional);

                if (objDtb != null)
                {
                    listaParam = criarLista(objDtb);
                }
                return listaParam;
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
                objDAL = new DAL_parametros();
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
        private List<MOD_parametros> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_parametros> lista = new List<MOD_parametros>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_parametros ent = new MOD_parametros();
                    //adiciona os campos às propriedades
                    ent.CodParametro = (string)(row.IsNull("CodParametro") ? Convert.ToString(null) : Convert.ToString(row["CodParametro"]).PadLeft(6, '0'));
                    ent.CodRegional = (string)(row.IsNull("CodRegional") ? Convert.ToString(null) : Convert.ToString(row["CodRegional"]).PadLeft(5, '0'));
                    ent.Ativacao = (string)(row.IsNull("Ativacao") ? null : row["Ativacao"]);
                    ent.InformaAtiva = (string)(row.IsNull("InformaAtiva") ? null : row["InformaAtiva"]);
                    ent.DiasAtiva = (string)(row.IsNull("DiasAtiva") ? Convert.ToString(null) : Convert.ToString(row["DiasAtiva"]));
                    ent.Atualizacao = (string)(row.IsNull("Atualizacao") ? null : row["Atualizacao"]);
                    ent.CpfZerado = (string)(row.IsNull("CpfZerado") ? null : row["CpfZerado"]);
                    ent.TrocaSenha = (string)(row.IsNull("TrocaSenha") ? null : row["TrocaSenha"]);
                    ent.DiasTrocaSenha = (string)(row.IsNull("DiasTrocaSenha") ? Convert.ToString(null) : Convert.ToString(row["DiasTrocaSenha"]));
                    ent.CopiaSegura = (string)(row.IsNull("CopiaSegura") ? null : row["CopiaSegura"]);
                    ent.DiasCopiaSegura = (string)(row.IsNull("DiasCopiaSegura") ? Convert.ToString(null) : Convert.ToString(row["DiasCopiaSegura"]));
                    ent.QtdeViasPreTeste = (string)(row.IsNull("QtdeViasPreTeste") ? Convert.ToString(null) : Convert.ToString(row["QtdeViasPreTeste"]));
                    ent.QtdeViasTeste = (string)(row.IsNull("QtdeViasTeste") ? Convert.ToString(null) : Convert.ToString(row["QtdeViasTeste"]));
                    ent.AlteraDadosImportPessoa = (string)(row.IsNull("AlteraDadosImportPessoa") ? null : row["AlteraDadosImportPessoa"]);
                    ent.ValidarDadosImportacao = (string)(row.IsNull("ValidarDadosImportacao") ? null : row["ValidarDadosImportacao"]);
                    ent.TesteMetodo = (string)(row.IsNull("TesteMetodo") ? null : row["TesteMetodo"]);
                    ent.TesteHino = (string)(row.IsNull("TesteHino") ? null : row["TesteHino"]);
                    ent.AlteraSolicita = (string)(row.IsNull("AlteraSolicita") ? null : row["AlteraSolicita"]);
                    ent.AlteraQtdeLicoesPreTeste = (string)(row.IsNull("AlteraQtdeLicoesPreTeste") ? null : row["AlteraQtdeLicoesPreTeste"]);
                    ent.AlteraQtdeLicoesTeste = (string)(row.IsNull("AlteraQtdeLicoesTeste") ? null : row["AlteraQtdeLicoesTeste"]);
                    ent.QtdeHinoPreTesteRjm = (string)(row.IsNull("QtdeHinoPreTesteRjm") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoPreTesteRjm"]));
                    ent.QtdeEscalaPreTesteRjm = (string)(row.IsNull("QtdeEscalaPreTesteRjm") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaPreTesteRjm"]));
                    ent.QtdeHinoTesteRjm = (string)(row.IsNull("QtdeHinoTesteRjm") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoTesteRjm"]));
                    ent.QtdeEscalaTesteRjm = (string)(row.IsNull("QtdeEscalaTesteRjm") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaTesteRjm"]));
                    ent.QtdeHinoPreTesteMeia = (string)(row.IsNull("QtdeHinoPreTesteMeia") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoPreTesteMeia"]));
                    ent.QtdeEscalaPreTesteMeia = (string)(row.IsNull("QtdeEscalaPreTesteMeia") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaPreTesteMeia"]));
                    ent.QtdeHinoTesteMeia = (string)(row.IsNull("QtdeHinoTesteMeia") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoTesteMeia"]));
                    ent.QtdeEscalaTesteMeia = (string)(row.IsNull("QtdeEscalaTesteMeia") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaTesteMeia"]));
                    ent.QtdeHinoPreTesteCulto = (string)(row.IsNull("QtdeHinoPreTesteCulto") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoPreTesteCulto"]));
                    ent.QtdeEscalaPreTesteCulto = (string)(row.IsNull("QtdeEscalaPreTesteCulto") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaPreTesteCulto"]));
                    ent.QtdeHinoTesteCulto = (string)(row.IsNull("QtdeHinoTesteCulto") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoTesteCulto"]));
                    ent.QtdeEscalaTesteCulto = (string)(row.IsNull("QtdeEscalaTesteCulto") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaTesteCulto"]));
                    ent.QtdeHinoPreTesteOficial = (string)(row.IsNull("QtdeHinoPreTesteOficial") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoPreTesteOficial"]));
                    ent.QtdeEscalaPreTesteOficial = (string)(row.IsNull("QtdeEscalaPreTesteOficial") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaPreTesteOficial"]));
                    ent.QtdeHinoTesteOficial = (string)(row.IsNull("QtdeHinoTesteOficial") ? Convert.ToString(null) : Convert.ToString(row["QtdeHinoTesteOficial"]));
                    ent.QtdeEscalaTesteOficial = (string)(row.IsNull("QtdeEscalaTesteOficial") ? Convert.ToString(null) : Convert.ToString(row["QtdeEscalaTesteOficial"]));
                    ent.RodapeRelatorio = (string)(row.IsNull("RodapeRelatorio") ? null : row["RodapeRelatorio"]);
                    ent.TestePermAltObsMet = (string)(row.IsNull("TestePermAltObsMet") ? null : row["TestePermAltObsMet"]);
                    ent.TesteObsMet = (string)(row.IsNull("TesteObsMet") ? null : row["TesteObsMet"]);
                    ent.TestePermAltObsMts = (string)(row.IsNull("TestePermAltObsMts") ? null : row["TestePermAltObsMts"]);
                    ent.TesteObsMts = (string)(row.IsNull("TesteObsMts") ? null : row["TesteObsMts"]);
                    ent.TestePermAltObsHino = (string)(row.IsNull("TestePermAltObsHino") ? null : row["TestePermAltObsHino"]);
                    ent.TesteObsHino = (string)(row.IsNull("TesteObsHino") ? null : row["TesteObsHino"]);
                    ent.TestePermAltObsEsc = (string)(row.IsNull("TestePermAltObsEsc") ? null : row["TestePermAltObsEsc"]);
                    ent.TesteObsEsc = (string)(row.IsNull("TesteObsEsc") ? null : row["TesteObsEsc"]);
                    ent.TestePermAltObsTeoria = (string)(row.IsNull("TestePermAltObsTeoria") ? null : row["TestePermAltObsTeoria"]);
                    ent.TesteObsTeoria = (string)(row.IsNull("TesteObsTeoria") ? null : row["TesteObsTeoria"]);

                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]);
                    ent.CaminhoBD = (string)(row.IsNull("CaminhoBD") ? null : row["CaminhoBD"]);

                    objBLL_Regional = new BLL_regional();
                    ent.listaRegional = objBLL_Regional.buscarCod(ent.CodRegional);

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

        #region Lista Parametro Pre Teste

        /// <summary>
        /// Função que Transmite o Parametro informado, para pesquisa na
        /// Tabela ParametroPreTesteMetodo
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>       
        public BindingList<MOD_parametroPreTesteMet> buscarParamPre(string CodParametro)
        {
            try
            {
                objDAL_ParamPreTeste = new DAL_parametroPreTesteMet();
                objDtb_ParamPreTeste = objDAL_ParamPreTeste.buscarParametro(CodParametro);

                if (objDtb_ParamPreTeste != null)
                {
                    listaParamPreTeste = this.criarListaParamPre(objDtb_ParamPreTeste);
                }
                return listaParamPreTeste;
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
        /// Função que Transmite o Método informado, para pesquisa na
        /// Tabela ParametroPreTesteMetodo
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>       
        public BindingList<MOD_parametroPreTesteMet> buscarParamPreMet(string CodMetodo)
        {
            try
            {
                objDAL_ParamPreTeste = new DAL_parametroPreTesteMet();
                objDtb_ParamPreTeste = objDAL_ParamPreTeste.buscarParamMet(CodMetodo);

                if (objDtb_ParamPreTeste != null)
                {
                    listaParamPreTeste = this.criarListaParamPre(objDtb_ParamPreTeste);
                }
                return listaParamPreTeste;
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
        /// Função que Transmite o Instrumento informado, para pesquisa na
        /// Tabela ParametroPreTesteMetodo
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public BindingList<MOD_parametroPreTesteMet> buscarInstrPre(string CodInstrumento)
        {
            try
            {
                objDAL_ParamPreTeste = new DAL_parametroPreTesteMet();
                objDtb_ParamPreTeste = objDAL_ParamPreTeste.buscarInstrumento(CodInstrumento);

                if (objDtb_ParamPreTeste != null)
                {
                    listaParamPreTeste = this.criarListaParamPre(objDtb_ParamPreTeste);
                }
                return listaParamPreTeste;
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo CodInstrumento.*\
        /// Essa Consulta retorna os metodos que não estão na Tabela ParametroPreTesteMet
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public List<MOD_metodoInstr> buscarMetodosPre(string CodInstrumento)
        {
            try
            {
                objDAL_ParamPreTeste = new DAL_parametroPreTesteMet();
                objDtb_MetInstr = objDAL_ParamPreTeste.buscarMetodos(CodInstrumento);

                if (objDtb_MetInstr != null)
                {
                    listaMetodoInstr = this.criarListaMetodoPre(objDtb_MetInstr);
                }
                return listaMetodoInstr;
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
        /// Função que Retorna a Lista da Tabela ParametrosPreTesteMetodo Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_parametroPreTesteMet> criarListaParamPre(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_parametroPreTesteMet> lista = new BindingList<MOD_parametroPreTesteMet>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_parametroPreTesteMet ent = new MOD_parametroPreTesteMet();
                    //adiciona os campos às propriedades
                    ent.CodParamPreTesteMet = (string)(row.IsNull("CodParamPreTesteMet") ? Convert.ToString(null) : Convert.ToString(row["CodParamPreTesteMet"]));
                    ent.CodParametro = (string)(row.IsNull("CodParametro") ? Convert.ToString(null) : Convert.ToString(row["CodParametro"]).PadLeft(3, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : row["CodMetodo"].ToString().PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.Situacao = (string)(row.IsNull("Situacao") ? null : row["Situacao"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(3, '0'));
                    ent.QtdeLicao = (string)(row.IsNull("QtdeLicao") ? Convert.ToString(null) : Convert.ToString(row["QtdeLicao"]).PadLeft(2, '0'));
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
        private List<MOD_metodoInstr> criarListaMetodoPre(DataTable objDtb)
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

        #region Lista Parametro Teste

        /// <summary>
        /// Função que Transmite o Parametro informado, para pesquisa na
        /// Tabela ParametroTesteMetodo
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>       
        public BindingList<MOD_parametroTesteMet> buscarParamTeste(string CodParametro)
        {
            try
            {
                objDAL_ParamTeste = new DAL_parametroTesteMet();
                objDtb_ParamTeste = objDAL_ParamTeste.buscarParametro(CodParametro);

                if (objDtb_ParamTeste != null)
                {
                    listaParamTeste = this.criarListaParamTeste(objDtb_ParamTeste);
                }
                return listaParamTeste;
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
        /// Função que Transmite o Método informado, para pesquisa na
        /// Tabela ParametroTesteMetodo
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>       
        public BindingList<MOD_parametroTesteMet> buscarParamTesteMet(string CodMetodo)
        {
            try
            {
                objDAL_ParamTeste = new DAL_parametroTesteMet();
                objDtb_ParamTeste = objDAL_ParamTeste.buscarParamMet(CodMetodo);

                if (objDtb_ParamTeste != null)
                {
                    listaParamTeste = this.criarListaParamTeste(objDtb_ParamTeste);
                }
                return listaParamTeste;
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
        /// Função que Transmite o Instrumento informado, para pesquisa na
        /// Tabela ParametroTesteMetodo
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public BindingList<MOD_parametroTesteMet> buscarInstrTeste(string CodInstrumento)
        {
            try
            {
                objDAL_ParamTeste = new DAL_parametroTesteMet();
                objDtb_ParamTeste = objDAL_ParamTeste.buscarInstrumento(CodInstrumento);

                if (objDtb_ParamTeste != null)
                {
                    listaParamTeste = this.criarListaParamTeste(objDtb_ParamPreTeste);
                }
                return listaParamTeste;
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
        /// Função que retorna os Registros da tabela MetodoInstr, pesquisado pelo CodInstrumento.*\
        /// Essa Consulta retorna os metodos que não estão na Tabela ParametroTesteMet
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public List<MOD_metodoInstr> buscarMetodosTeste(string CodInstrumento)
        {
            try
            {
                objDAL_ParamTeste = new DAL_parametroTesteMet();
                objDtb_MetInstr = objDAL_ParamTeste.buscarMetodos(CodInstrumento);

                if (objDtb_MetInstr != null)
                {
                    listaMetodoInstr = this.criarListaMetodoTeste(objDtb_MetInstr);
                }
                return listaMetodoInstr;
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
        /// Função que Retorna a Lista da Tabela ParametrosTesteMetodo Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_parametroTesteMet> criarListaParamTeste(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_parametroTesteMet> lista = new BindingList<MOD_parametroTesteMet>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_parametroTesteMet ent = new MOD_parametroTesteMet();
                    //adiciona os campos às propriedades
                    ent.CodParamTesteMet = (string)(row.IsNull("CodParamTesteMet") ? Convert.ToString(null) : Convert.ToString(row["CodParamTesteMet"]));
                    ent.CodParametro = (string)(row.IsNull("CodParametro") ? Convert.ToString(null) : Convert.ToString(row["CodParametro"]).PadLeft(3, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : row["CodMetodo"].ToString().PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.Situacao = (string)(row.IsNull("Situacao") ? null : row["Situacao"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(3, '0'));
                    ent.QtdeLicao = (string)(row.IsNull("QtdeLicao") ? Convert.ToString(null) : Convert.ToString(row["QtdeLicao"]).PadLeft(2, '0'));
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
        private List<MOD_metodoInstr> criarListaMetodoTeste(DataTable objDtb)
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
        private MOD_log criarLog(MOD_parametros ent, string Operacao)
        {
            try
            {
                MOD_acessoParam entAcesso = new MOD_acessoParam();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsParam);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodParametro + " > Regional: < " + ent.CodRegional + " > ";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditParam);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodParametro + " > Regional: < " + ent.CodRegional + " > ";
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcParam);
                    ent.Logs.Ocorrencia = "Código: < " + ent.CodParametro + " > Regional: < " + ent.CodRegional + " > ";
                }
                else if (Operacao.Equals("ParamPreTeste"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotParamPre);
                    ent.Logs.Ocorrencia = "Houve Alteração nas quantidades de lições dos métodos escolhidas nos pré-testes: Código: < " + ent.CodParametro + " > Regional: < " + ent.CodRegional + " > ";
                }
                else if (Operacao.Equals("ParamTeste"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotParamTeste);
                    ent.Logs.Ocorrencia = "Houve Alteração nas quantidades de lições dos métodos escolhidas nos testes: Código: < " + ent.CodParametro + " > Regional: < " + ent.CodRegional + " > ";
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
