using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using ENT.instrumentos;
using DAL.instrumentos;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;

namespace BLL.instrumentos
{
    public class BLL_instrumento
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_instrumento objDAL = null;
        DAL_instrumentoVozPrincipal objDAL_InstVozPrinc = null;
        DAL_instrumentoVozAlternativa objDAL_InstVozAlterna = null;
        DAL_instrumentoTom objDAL_InstTom = null;
        DAL_instrumentoHinario objDAL_InstHino = null;
        DAL_instrumentoFoto objDAL_Foto = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoVozPrinc;
        bool blnRetornoVozAlterna;
        bool blnRetornoTom;
        bool blnRetornoHino;
        bool blnRetornoFoto;
        bool blnRetornoLog;

        DataTable objDtb = null;
        DataTable objDtb_InstVozPrinc = null;
        DataTable objDtb_VozPrinc = null;
        DataTable objDtb_InstVozAlterna = null;
        DataTable objDtb_VozAlterna = null;
        DataTable objDtb_InstTom = null;
        DataTable objDtb_Tonal = null;
        DataTable objDtb_InstHino = null;
        DataTable objDtb_Hinario = null;
        DataTable objDtb_Foto = null;

        List<MOD_instrumento> listaInstrumento = new List<MOD_instrumento>();
        List<MOD_instrumentoFoto> listaFoto = new List<MOD_instrumentoFoto>();
        List<MOD_instrumentoVozPrincipal> listaInstVozPrinc = new List<MOD_instrumentoVozPrincipal>();
        List<MOD_voz> listaVozPrinc = new List<MOD_voz>();
        List<MOD_instrumentoVozAlternativa> listaInstVozAlterna = new List<MOD_instrumentoVozAlternativa>();
        List<MOD_voz> listaVozAlterna = new List<MOD_voz>();
        List<MOD_instrumentoTom> listaInstTom = new List<MOD_instrumentoTom>();
        List<MOD_tonalidade> listaTonal = new List<MOD_tonalidade>();
        List<MOD_instrumentoHinario> listaInstHino = new List<MOD_instrumentoHinario>();
        List<MOD_hinario> listaHinario = new List<MOD_hinario>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_instrumento objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoVozPrinc = true;
                    blnRetornoVozAlterna = true;
                    blnRetornoTom = true;
                    blnRetornoHino = true;
                    blnRetornoFoto = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Instrumento e Logs

                    objDAL = new DAL_instrumento();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela InstrumentoVozPrincipal

                    //verifica se há registro na lista
                    if (objEnt.listaVozInstrPrincipal != null && objEnt.listaVozInstrPrincipal.Count > 0)
                    {
                        objDAL_InstVozPrinc = new DAL_instrumentoVozPrincipal();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoVozPrincipal ent in objEnt.listaVozInstrPrincipal)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoVozPrinc = objDAL_InstVozPrinc.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoVozPrinc.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela InstrumentoVozAlterna

                    //verifica se há registro na lista
                    if (objEnt.listaVozInstrAlternativa != null && objEnt.listaVozInstrAlternativa.Count > 0)
                    {
                        objDAL_InstVozAlterna = new DAL_instrumentoVozAlternativa();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoVozAlternativa ent in objEnt.listaVozInstrAlternativa)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoVozAlterna = objDAL_InstVozAlterna.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoVozAlterna.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela InstrumentoTom

                    //verifica se há registro na lista
                    if (objEnt.listaTomInstr != null && objEnt.listaTomInstr.Count > 0)
                    {
                        objDAL_InstTom = new DAL_instrumentoTom();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoTom ent in objEnt.listaTomInstr)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoTom = objDAL_InstTom.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoTom.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela InstrumentoHino

                    //verifica se há registro na lista
                    if (objEnt.listaHinoInstr != null && objEnt.listaHinoInstr.Count > 0)
                    {
                        objDAL_InstHino = new DAL_instrumentoHinario();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoHinario ent in objEnt.listaHinoInstr)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoHino = objDAL_InstHino.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoHino.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela Foto

                    //verifica se há registro na lista Foto Instrumento
                    if (objEnt.FotoInstrumento != null)
                    {
                        objDAL_Foto = new DAL_instrumentoFoto();

                        objEnt.FotoInstrumento.CodInstrumento = objEnt.CodInstrumento;

                        blnRetornoFoto = objDAL_Foto.salvar(objEnt.FotoInstrumento);
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) || blnRetornoVozPrinc.Equals(false) || blnRetornoVozAlterna.Equals(false) ||
                        blnRetornoTom.Equals(false) || blnRetornoHino .Equals(false) || blnRetornoFoto.Equals(false))
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
        public bool inserir(MOD_instrumento objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoVozPrinc = true;
                    blnRetornoVozAlterna = true;
                    blnRetornoTom = true;
                    blnRetornoHino = true;
                    blnRetornoFoto = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Instrumento e Logs

                    objDAL = new DAL_instrumento();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodInstrumento = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela InstrumentoVoz Principal

                    //verifica se há registro na lista
                    if (objEnt.listaVozInstrPrincipal != null && objEnt.listaVozInstrPrincipal.Count > 0)
                    {
                        objDAL_InstVozPrinc = new DAL_instrumentoVozPrincipal();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoVozPrincipal ent in objEnt.listaVozInstrPrincipal)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoVozPrinc = objDAL_InstVozPrinc.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoVozPrinc.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela InstrumentoVoz Alternativa

                    //verifica se há registro na lista
                    if (objEnt.listaVozInstrAlternativa != null && objEnt.listaVozInstrAlternativa.Count > 0)
                    {
                        objDAL_InstVozAlterna = new DAL_instrumentoVozAlternativa();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoVozAlternativa ent in objEnt.listaVozInstrAlternativa)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoVozAlterna = objDAL_InstVozAlterna.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoVozAlterna.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela InstrumentoTom

                    //verifica se há registro na lista
                    if (objEnt.listaTomInstr != null && objEnt.listaTomInstr.Count > 0)
                    {
                        objDAL_InstTom = new DAL_instrumentoTom();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoTom ent in objEnt.listaTomInstr)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoTom = objDAL_InstTom.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoTom.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela InstrumentoHino

                    //verifica se há registro na lista
                    if (objEnt.listaHinoInstr != null && objEnt.listaHinoInstr.Count > 0)
                    {
                        objDAL_InstHino = new DAL_instrumentoHinario();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_instrumentoHinario ent in objEnt.listaHinoInstr)
                        {
                            ent.CodInstrumento = objEnt.CodInstrumento;
                            blnRetornoHino = objDAL_InstHino.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoHino.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da tabela Foto

                    //verifica se há registro na lista Foto Instrumento
                    if (objEnt.FotoInstrumento != null)
                    {
                        objDAL_Foto = new DAL_instrumentoFoto();

                        objEnt.FotoInstrumento.CodInstrumento = objEnt.CodInstrumento;

                        blnRetornoFoto = objDAL_Foto.salvar(objEnt.FotoInstrumento);
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) || blnRetornoVozPrinc.Equals(false) || blnRetornoVozAlterna.Equals(false) ||
                        blnRetornoTom.Equals(false) || blnRetornoHino .Equals(false) || blnRetornoFoto.Equals(false))
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
        public bool excluir(MOD_instrumento objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Instrumento e Logs

                    objDAL = new DAL_instrumento();
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
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public List<MOD_instrumento> buscarCod(string CodInstrumento)
        {
            try
            {
                objDAL = new DAL_instrumento();
                objDtb = objDAL.buscarCod(CodInstrumento);

                if (objDtb != null)
                {
                    listaInstrumento = this.criarLista(objDtb);
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
        /// <summary>
        /// Função que Transmite o Código e a Situação informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public List<MOD_instrumento> buscarCod(string CodInstrumento, string Situacao)
        {
            try
            {
                objDAL = new DAL_instrumento();
                objDtb = objDAL.buscarCod(CodInstrumento, Situacao);

                if (objDtb != null)
                {
                    listaInstrumento = this.criarLista(objDtb);
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

        /// <summary>
        /// Função que Transmite a Descrição informada, para pesquisa
        /// </summary>
        /// <param name="DescInstrumento"></param>
        /// <returns></returns>
        public List<MOD_instrumento> buscarDescricao(string DescInstrumento)
        {
            try
            {
                objDAL = new DAL_instrumento();
                objDtb = objDAL.buscarDescricao(DescInstrumento + "%");

                if (objDtb != null)
                {
                    listaInstrumento = this.criarLista(objDtb);
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
        /// <summary>
        /// Função que Transmite a Descrição e a Situação informada, para pesquisa
        /// </summary>
        /// <param name="DescInstrumento"></param>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public List<MOD_instrumento> buscarDescricao(string DescInstrumento, string Situacao)
        {
            try
            {
                objDAL = new DAL_instrumento();
                objDtb = objDAL.buscarDescricao(DescInstrumento + "%", Situacao);

                if (objDtb != null)
                {
                    listaInstrumento = this.criarLista(objDtb);
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

        /// <summary>
        /// Função que Transmite a Situacao informada, para pesquisa
        /// </summary>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public List<MOD_instrumento> buscarSituacao(string Situacao)
        {
            try
            {
                objDAL = new DAL_instrumento();
                objDtb = objDAL.buscarSituacao(Situacao);

                if (objDtb != null)
                {
                    listaInstrumento = criarLista(objDtb);
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

        /// <summary>
        /// Função que Transmite a Familia informada, para pesquisa
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>
        public List<MOD_instrumento> buscarFamilia(string CodFamilia)
        {
            try
            {
                objDAL = new DAL_instrumento();
                objDtb = objDAL.buscarFamilia(CodFamilia);

                if (objDtb != null)
                {
                    listaInstrumento = this.criarLista(objDtb);
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
        /// <summary>
        /// Função que Transmite a Familia e a Situação informada, para pesquisa
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <param name="Situacao"></param>
        /// <returns></returns>
        public List<MOD_instrumento> buscarFamilia(string CodFamilia, string Situacao)
        {
            try
            {
                objDAL = new DAL_instrumento();
                objDtb = objDAL.buscarFamilia(CodFamilia, Situacao);

                if (objDtb != null)
                {
                    listaInstrumento = this.criarLista(objDtb);
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

        #region Foto Instrumento

        /// <summary>
        /// Função que Transmite o Instrumento informada, para pesquisa na
        /// Tabela Foto Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public DataTable buscarInstrumentoFoto(string CodInstrumento)
        {
            try
            {
                objDAL_Foto = new DAL_instrumentoFoto();
                objDtb_Foto = objDAL_Foto.buscarInstrumentoFoto(CodInstrumento);
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

        #region Instrumento Voz Principal

        /// <summary>
        /// Função que Transmite a Voz informada, para pesquisa na
        /// Tabela Instrumento Voz Principal
        /// </summary>
        /// <param name="CodVoz"></param>
        /// <returns></returns>       
        public List<MOD_instrumentoVozPrincipal> buscarCodVoz(string CodVoz)
        {
            try
            {
                objDAL_InstVozPrinc = new DAL_instrumentoVozPrincipal();
                objDtb_InstVozPrinc = objDAL_InstVozPrinc.buscarCodVoz(CodVoz);

                if (objDtb_InstVozPrinc != null)
                {
                    listaInstVozPrinc = criarListaInstVozPrinc(objDtb_InstVozPrinc);
                }
                return listaInstVozPrinc;
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
        /// Função que Transmite a Voz informada, para pesquisa na
        /// Tabela Instrumento Voz Principal
        /// </summary>
        /// <param name="CodVoz"></param>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>       
        public List<MOD_instrumentoVozPrincipal> buscarCodVoz(string CodVoz, string CodFamilia)
        {
            try
            {
                objDAL_InstVozPrinc = new DAL_instrumentoVozPrincipal();
                objDtb_InstVozPrinc = objDAL_InstVozPrinc.buscarCodVoz(CodVoz, CodFamilia);

                if (objDtb_InstVozPrinc != null)
                {
                    listaInstVozPrinc = criarListaInstVozPrinc(objDtb_InstVozPrinc);
                }
                return listaInstVozPrinc;
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
        /// Tabela Instrumento Voz Principal
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_instrumentoVozPrincipal> buscarInstrumentoVozPrincipal(string CodInstrumento)
        {
            try
            {
                objDAL_InstVozPrinc = new DAL_instrumentoVozPrincipal();
                objDtb_InstVozPrinc = objDAL_InstVozPrinc.buscarInstrumentoVoz(CodInstrumento);

                if (objDtb_InstVozPrinc != null)
                {
                    listaInstVozPrinc = criarListaInstVozPrinc(objDtb_InstVozPrinc);
                }
                return listaInstVozPrinc;
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
        /// Tabela Vozes Principal
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_voz> buscarVozesPrincipal(string CodInstrumento)
        {
            try
            {
                objDAL_InstVozPrinc = new DAL_instrumentoVozPrincipal();
                objDtb_VozPrinc = objDAL_InstVozPrinc.buscarVozes(CodInstrumento);

                if (objDtb_VozPrinc != null)
                {
                    listaVozPrinc = criarListaVozPrinc(objDtb_VozPrinc);
                }
                return listaVozPrinc;
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

        #region Instrumento Voz Alternativa

        /// <summary>
        /// Função que Transmite o Instrumento informado, para pesquisa na
        /// Tabela Instrumento Voz Alternativa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_instrumentoVozAlternativa> buscarInstrumentoVozAlternativa(string CodInstrumento)
        {
            try
            {
                objDAL_InstVozAlterna = new DAL_instrumentoVozAlternativa();
                objDtb_InstVozAlterna = objDAL_InstVozAlterna.buscarInstrumentoVoz(CodInstrumento);

                if (objDtb_InstVozAlterna != null)
                {
                    listaInstVozAlterna = criarListaInstVozAlterna(objDtb_InstVozAlterna);
                }
                return listaInstVozAlterna;
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
        /// Tabela Vozes Alternativa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_voz> buscarVozesAlternativa(string CodInstrumento)
        {
            try
            {
                objDAL_InstVozAlterna = new DAL_instrumentoVozAlternativa();
                objDtb_VozAlterna = objDAL_InstVozAlterna.buscarVozes(CodInstrumento);

                if (objDtb_VozAlterna != null)
                {
                    listaVozAlterna= criarListaVozAlterna(objDtb_VozAlterna);
                }
                return listaVozAlterna;
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

        #region Instrumento Tom

        /// <summary>
        /// Função que Transmite o Instrumento informado, para pesquisa na
        /// Tabela Instrumento Tom
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_instrumentoTom> buscarInstrumentoTom(string CodInstrumento)
        {
            try
            {
                objDAL_InstTom = new DAL_instrumentoTom();
                objDtb_InstTom = objDAL_InstTom.buscarInstrumentoTom(CodInstrumento);

                if (objDtb_InstTom != null)
                {
                    listaInstTom = this.criarListaInstTom(objDtb_InstTom);
                }
                return listaInstTom;
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
        /// Tabela Tonalidade
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_tonalidade> buscarTonalidades(string CodInstrumento)
        {
            try
            {
                objDAL_InstTom = new DAL_instrumentoTom();
                objDtb_Tonal = objDAL_InstTom.buscarTonalidades(CodInstrumento);

                if (objDtb_Tonal != null)
                {
                    listaTonal = criarListaTonal(objDtb_Tonal);
                }
                return listaTonal;
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

        #region Instrumento Hinario

        /// <summary>
        /// Função que Transmite o Instrumento informado, para pesquisa na
        /// Tabela Instrumento HInario
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_instrumentoHinario> buscarInstrumentoHinario(string CodInstrumento)
        {
            try
            {
                objDAL_InstHino = new DAL_instrumentoHinario();
                objDtb_InstHino = objDAL_InstHino.buscarInstrumentoHinario(CodInstrumento);

                if (objDtb_InstHino != null)
                {
                    listaInstHino = criarListaInstHinario(objDtb_InstHino);
                }
                return listaInstHino;
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
        /// Tabela HInario
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>       
        public List<MOD_hinario> buscarHinarios(string CodInstrumento)
        {
            try
            {
                objDAL_InstHino = new DAL_instrumentoHinario();
                objDtb_Hinario = objDAL_InstHino.buscarHinarios(CodInstrumento);

                if (objDtb_Hinario != null)
                {
                    listaHinario = criarListaHinario(objDtb_Hinario);
                }
                return listaHinario;
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
        /// Função que Transmite o HInario informado, para pesquisa na
        /// Tabela HInario
        /// </summary>
        /// <param name="CodHinario"></param>
        /// <returns></returns>       
        public List<MOD_instrumentoHinario> buscarHinarioInstr(string CodHinario)
        {
            try
            {
                objDAL_InstHino = new DAL_instrumentoHinario();
                objDtb_InstHino = objDAL_InstHino.buscarHinarioInstr(CodHinario);

                if (objDtb_InstHino != null)
                {
                    listaInstHino = criarListaInstHinario(objDtb_InstHino);
                }
                return listaInstHino;
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
        public Int16 retornaId()
        {
            try
            {
                objDAL = new DAL_instrumento();
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
        private List<MOD_instrumento> criarLista(DataTable objDtb)
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
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.Rjm = (string)(row.IsNull("Rjm") ? null : row["Rjm"]);
                    ent.Culto = (string)(row.IsNull("Culto") ? null : row["Culto"]);
                    ent.MeiaHora = (string)(row.IsNull("MeiaHora") ? null : row["MeiaHora"]);
                    ent.Oficial = (string)(row.IsNull("Oficial") ? null : row["Oficial"]);
                    ent.Troca = (string)(row.IsNull("Troca") ? null : row["Troca"]);
                    ent.NotaAfina = (string)(row.IsNull("NotaAfina") ? null : row["NotaAfina"]);
                    ent.PosAfina = (string)(row.IsNull("PosAfina") ? null : row["PosAfina"]);
                    ent.NotaEfeito = (string)(row.IsNull("NotaEfeito") ? null : row["NotaEfeito"]);
                    ent.PosEfeito = (string)(row.IsNull("PosEfeito") ? null : row["PosEfeito"]);
                    ent.Obs = (string)(row.IsNull("Obs") ? null : row["Obs"]);
                    ent.TesNotaGrave = (string)(row.IsNull("TesNotaGrave") ? null : row["TesNotaGrave"]);
                    ent.TesNotaAguda = (string)(row.IsNull("TesNotaAguda") ? null : row["TesNotaAguda"]);
                    ent.Situacao = (string)(row.IsNull("Situacao") ? null : row["Situacao"]);
                    ent.Tessitura = ent.TesNotaGrave + " à " + ent.TesNotaAguda;
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(3, '0'));

                    ///preenche a lista com os dados da Tabela Fotos
                    ent.CarregaFoto = this.buscarInstrumentoFoto(ent.CodInstrumento);

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

        #region Lista Instrumento Voz Principal

        /// <summary>
        /// Função que Retorna a Lista da Tabela InstrumentoVoz Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_instrumentoVozPrincipal> criarListaInstVozPrinc(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_instrumentoVozPrincipal> lista = new List<MOD_instrumentoVozPrincipal>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_instrumentoVozPrincipal ent = new MOD_instrumentoVozPrincipal();
                    //adiciona os campos às propriedades
                    ent.CodInstrumentoVoz = (string)(row.IsNull("CodInstrumentoVoz") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumentoVoz"]));
                    ent.CodVoz = (string)(row.IsNull("CodVoz") ? Convert.ToString(null) : Convert.ToString(row["CodVoz"]).PadLeft(3, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescVoz = (string)(row.IsNull("DescVoz") ? null : row["DescVoz"]);
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.Escrita = (bool)(row["Escrita"].Equals("Sim") ? true : false);
                    ent.Acima = (bool)(row["Acima"].Equals("Sim") ? true : false);
                    ent.Abaixo = (bool)(row["Abaixo"].Equals("Sim") ? true : false);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(2, '0'));

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
        /// Função que Retorna uma Lista da Tabela Vozes Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_voz> criarListaVozPrinc(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_voz> lista = new List<MOD_voz>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_voz ent = new MOD_voz();
                    //adiciona os campos às propriedades
                    ent.CodVoz = (string)(row.IsNull("CodVoz") ? Convert.ToString(null) : Convert.ToString(row["CodVoz"]).PadLeft(3, '0'));
                    ent.DescVoz = (string)(row.IsNull("DescVoz") ? null : row["DescVoz"]);
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

        #region Lista Instrumento Voz Alternativa

        /// <summary>
        /// Função que Retorna a Lista da Tabela InstrumentoVoz Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_instrumentoVozAlternativa> criarListaInstVozAlterna(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_instrumentoVozAlternativa> lista = new List<MOD_instrumentoVozAlternativa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_instrumentoVozAlternativa ent = new MOD_instrumentoVozAlternativa();
                    //adiciona os campos às propriedades
                    ent.CodInstrumentoVoz = (string)(row.IsNull("CodInstrumentoVoz") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumentoVoz"]));
                    ent.CodVoz = (string)(row.IsNull("CodVoz") ? Convert.ToString(null) : Convert.ToString(row["CodVoz"]).PadLeft(3, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescVoz = (string)(row.IsNull("DescVoz") ? null : row["DescVoz"]);
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.Escrita = (bool)(row["Escrita"].Equals("Sim") ? true : false);
                    ent.Acima = (bool)(row["Acima"].Equals("Sim") ? true : false);
                    ent.Abaixo = (bool)(row["Abaixo"].Equals("Sim") ? true : false);
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
        /// Função que Retorna uma Lista da Tabela Vozes Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_voz> criarListaVozAlterna(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_voz> lista = new List<MOD_voz>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_voz ent = new MOD_voz();
                    //adiciona os campos às propriedades
                    ent.CodVoz = (string)(row.IsNull("CodVoz") ? Convert.ToString(null) : Convert.ToString(row["CodVoz"]).PadLeft(3, '0'));
                    ent.DescVoz = (string)(row.IsNull("DescVoz") ? null : row["DescVoz"]);
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

        #region Lista Instrumento Tom

        /// <summary>
        /// Função que Retorna a Lista da Tabela InstrumentoTom Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_instrumentoTom> criarListaInstTom(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_instrumentoTom> lista = new List<MOD_instrumentoTom>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_instrumentoTom ent = new MOD_instrumentoTom();
                    //adiciona os campos às propriedades
                    ent.CodInstrumentoTom = (string)(row.IsNull("CodInstrumentoTom") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumentoTom"]));
                    ent.CodTonalidade = (string)(row.IsNull("CodTonalidade") ? Convert.ToString(null) : Convert.ToString(row["CodTonalidade"]).PadLeft(3, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescTonalidade = (string)(row.IsNull("DescTonalidade") ? null : row["DescTonalidade"]);
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
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
        /// Função que Retorna uma Lista da Tabela Tonalidades Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_tonalidade> criarListaTonal(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_tonalidade> lista = new List<MOD_tonalidade>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_tonalidade ent = new MOD_tonalidade();
                    //adiciona os campos às propriedades
                    ent.CodTonalidade = (string)(row.IsNull("CodTonalidade") ? Convert.ToString(null) : Convert.ToString(row["CodTonalidade"]).PadLeft(3, '0'));
                    ent.DescTonalidade = (string)(row.IsNull("DescTonalidade") ? null : row["DescTonalidade"]);
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
        
        #region Lista Instrumento Hinario

        /// <summary>
        /// Função que Retorna a Lista da Tabela InstrumentoTom Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_instrumentoHinario> criarListaInstHinario(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_instrumentoHinario> lista = new List<MOD_instrumentoHinario>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_instrumentoHinario ent = new MOD_instrumentoHinario();
                    //adiciona os campos às propriedades
                    ent.CodInstrumentoHino = (string)(row.IsNull("CodInstrumentoHino") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumentoHino"]));
                    ent.CodHinario = (string)(row.IsNull("CodHinario") ? Convert.ToString(null) : Convert.ToString(row["CodHinario"]).PadLeft(3, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescHinario = (string)(row.IsNull("DescHinario") ? null : row["DescHinario"]);
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
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
        /// Função que Retorna uma Lista da Tabela Tonalidades Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_hinario> criarListaHinario(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_hinario> lista = new List<MOD_hinario>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_hinario ent = new MOD_hinario();
                    //adiciona os campos às propriedades
                    ent.CodHinario = (string)(row.IsNull("CodHinario") ? Convert.ToString(null) : Convert.ToString(row["CodHinario"]).PadLeft(3, '0'));
                    ent.DescHinario = (string)(row.IsNull("DescHinario") ? null : row["DescHinario"]);
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
        private MOD_log criarLog(MOD_instrumento ent, string Operacao)
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
                    ent.Logs.CodRotina = "14";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = "15";
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = "16";
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodInstrumento + " > Descrição: < " + ent.DescInstrumento + " > ";
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
