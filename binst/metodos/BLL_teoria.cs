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
using System.ComponentModel;

namespace BLL.instrumentos
{
    public class BLL_teoria
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_teoria objDAL = null;
        DAL_teoriaFoto objDAL_Foto = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;
        bool blnRetornoFoto;
        bool blnRetornoFotoLog;
        bool blnRetornoFotoDelete;

        DataTable objDtb = null;
        DataTable objDtb_Foto = null;

        List<MOD_teoria> listaTeoria = new List<MOD_teoria>();
        BindingList<MOD_teoriaFoto> listaFotoTeoria = new BindingList<MOD_teoriaFoto>();
        List<MOD_teoriaFoto> listaDeleteFotoTeoria = new List<MOD_teoriaFoto>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_teoria objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoFoto = true;
                    blnRetornoFotoLog = true;
                    blnRetornoFotoDelete = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Teoria e Logs

                    objDAL = new DAL_teoria();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt = validaDadosTeoria(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimento INSERT e UPDATE na tabela Foto Teoria

                    //verifica se há registro na lista Metodo Familia
                    if (objEnt.listaFotoTeoria != null && objEnt.listaFotoTeoria.Count > 0)
                    {
                        objDAL_Foto = new DAL_teoriaFoto();

                        //Faz o loop para gravar na tabela Metodo Familia
                        foreach (MOD_teoriaFoto ent in objEnt.listaFotoTeoria)
                        {
                            if (Convert.ToInt16(ent.CodFoto).Equals(0))
                            {
                                ent.CodTeoria = objEnt.CodTeoria;

                                //Chama a função que converte as datas
                                ent.Logs = criarLogFoto(ent, "Insert");
                                ent.Logs = validaDadosLog(ent.Logs);

                                blnRetornoFoto = objDAL_Foto.inserir(ent);
                                blnRetornoFotoLog = objDAL_Log.inserir(ent.Logs);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoFoto.Equals(false) || blnRetornoFotoLog.Equals(false))
                                {
                                    break;
                                }
                            }
                            //else
                            //{
                            //    ent.CodTeoria = objEnt.CodTeoria;

                            //    //Chama a função que converte as datas
                            //    ent.Logs = criarLogFoto(ent, "Update");
                            //    ent.Logs = validaDadosLog(ent.Logs);

                            //    blnRetornoFoto = objDAL_Foto.salvar(ent);
                            //    blnRetornoFotoLog = objDAL_Log.inserir(ent.Logs);

                            //    //verifica se o retorno foi false e sai do for
                            //    if (blnRetornoFoto.Equals(false) || blnRetornoFotoLog.Equals(false))
                            //    {
                            //        break;
                            //    }
                            //}
                        }
                    }

                    #endregion

                    #region Movimento DELETE na tabela Foto Teoria

                    //verifica se há registro na lista Delete 
                    if (objEnt.listaDeleteFotoTeoria != null && objEnt.listaDeleteFotoTeoria.Count > 0)
                    {
                        objDAL_Foto = new DAL_teoriaFoto();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_teoriaFoto ent in objEnt.listaDeleteFotoTeoria)
                        {
                            if (!Convert.ToInt16(ent.CodFoto).Equals(0))
                            {
                                //Chama a função que converte as datas
                                ent.Logs = criarLogFoto(ent, "Delete");
                                ent.Logs = validaDadosLog(ent.Logs);

                                ent.CodTeoria = objEnt.CodTeoria;
                                blnRetornoFotoDelete = objDAL_Foto.excluir(ent);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoFotoDelete.Equals(false) || blnRetornoFotoLog.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoFotoDelete.Equals(false) ||
                        blnRetornoLog.Equals(false) || blnRetornoFotoLog.Equals(false) || blnRetornoFoto.Equals(false))
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
        public bool inserir(MOD_teoria objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoFoto = true;
                    blnRetornoFotoLog = true;
                    blnRetornoFotoDelete = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Teoria e Logs

                    objDAL = new DAL_teoria();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodTeoria = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
                    objEnt = validaDadosTeoria(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimento INSERT e UPDATE na tabela Foto Teoria

                    //verifica se há registro na lista Metodo Familia
                    if (objEnt.listaFotoTeoria != null && objEnt.listaFotoTeoria.Count > 0)
                    {
                        objDAL_Foto = new DAL_teoriaFoto();

                        //Faz o loop para gravar na tabela Metodo Familia
                        foreach (MOD_teoriaFoto ent in objEnt.listaFotoTeoria)
                        {
                            if (Convert.ToInt16(ent.CodFoto).Equals(0))
                            {
                                ent.CodTeoria = objEnt.CodTeoria;

                                //Chama a função que converte as datas
                                ent.Logs = criarLogFoto(ent, "Insert");
                                ent.Logs = validaDadosLog(ent.Logs);

                                blnRetornoFoto = objDAL_Foto.inserir(ent);
                                blnRetornoFotoLog = objDAL_Log.inserir(ent.Logs);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoFoto.Equals(false) || blnRetornoFotoLog.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    #region Movimento DELETE na tabela Foto Teoria

                    //verifica se há registro na lista Delete 
                    if (objEnt.listaDeleteFotoTeoria != null && objEnt.listaDeleteFotoTeoria.Count > 0)
                    {
                        objDAL_Foto = new DAL_teoriaFoto();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_teoriaFoto ent in objEnt.listaDeleteFotoTeoria)
                        {
                            if (!Convert.ToInt16(ent.CodFoto).Equals(0))
                            {
                                //Chama a função que converte as datas
                                ent.Logs = criarLogFoto(ent, "Delete");
                                ent.Logs = validaDadosLog(ent.Logs);

                                ent.CodTeoria = objEnt.CodTeoria;
                                blnRetornoFotoDelete = objDAL_Foto.excluir(ent);

                                //verifica se o retorno foi false e sai do for
                                if (blnRetornoFotoDelete.Equals(false) || blnRetornoFotoLog.Equals(false))
                                {
                                    break;
                                }
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoFoto.Equals(false) ||
                        blnRetornoLog.Equals(false) || blnRetornoFotoLog.Equals(false) || blnRetornoFotoDelete.Equals(false))
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
        public bool excluir(MOD_teoria objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Teoria e Logs

                    objDAL = new DAL_teoria();
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
        /// <param name="CodTeoria"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarCod(string CodTeoria)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarCod(CodTeoria);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// <param name="DescTeoria"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarDescricao(string DescTeoria)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarDescricao(DescTeoria + "%");

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite a Descrição e o Tipo de Cadastro informada, para pesquisa
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="DescTeoria"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarDescricao(string DescTeoria, string TipoCadastro)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarDescricao(DescTeoria + "%", TipoCadastro);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite a Fase informada, para pesquisa
        /// </summary>
        /// <param name="CodFaseMts"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarFase(string CodFaseMts)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarFase(CodFaseMts);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite a Fase e o Tipo de Cadastro informada, para pesquisa
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="CodFaseMts"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarFase(string CodFaseMts, string TipoCadastro)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarFase(CodFaseMts, TipoCadastro);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite o Módulo MTS informada, para pesquisa
        /// </summary>
        /// <param name="CodModuloMts"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarModulo(string CodModuloMts)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarModulo(CodModuloMts);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite o Módulo e o Tipo de Cadastro informada, para pesquisa
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="CodModuloMts"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarModulo(string CodModuloMts, string TipoCadastro)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarModulo(CodModuloMts, TipoCadastro);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite a Aplicação informada, para pesquisa
        /// <para> AplicaEm = GEM, RJM, Culto Oficial, Oficialização</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarAplicaEm(string AplicaEm)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarAplicaEm(AplicaEm);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite a Aplicação e o Tipo de Cadastro informada, para pesquisa
        /// <para> AplicaEm = GEM, RJM, Culto Oficial, Oficialização</para>
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarAplicaEm(string AplicaEm, string TipoCadastro)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarAplicaEm(AplicaEm, TipoCadastro);

                if (objDtb != null)
                {
                    listaTeoria = criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite o Nivel informada, para pesquisa
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// </summary>
        /// <param name="Nivel"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarNivel(string Nivel)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarNivel(Nivel);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite oNivel e a Aplicação informada, para pesquisa
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// <para> AplicaEm = GEM, Reunião de Jovens, Meia Hora, Culto Oficial, Oficialização</para>
        /// </summary>
        /// <param name="Nivel"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarNivel(string Nivel, string AplicaEm)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarNivel(Nivel, AplicaEm);

                if (objDtb != null)
                {
                    listaTeoria = this.criarLista(objDtb);
                }
                return listaTeoria;
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
        /// Função que Transmite o Nivel, a Aplicação e o Tipo de Cadastro informada, para pesquisa
        /// <para> Nivel = Crianças, Adultos (Básico), Adultos</para>
        /// <para> AplicaEm = GEM, Reunião de Jovens, Meia Hora, Culto Oficial, Oficialização</para>
        /// <para>Tipo Cadastro = Atividade, Avaliação</para>
        /// </summary>
        /// <param name="Nivel"></param>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoCadastro"></param>
        /// <returns></returns>
        public List<MOD_teoria> buscarNivel(string Nivel, string AplicaEm, string TipoCadastro)
        {
            try
            {
                objDAL = new DAL_teoria();
                objDtb = objDAL.buscarNivel(Nivel, AplicaEm, TipoCadastro);

                if (objDtb != null)
                {
                    listaTeoria = criarLista(objDtb);
                }
                return listaTeoria;
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

        #region Foto Teoria

        /// <summary>
        /// Função que Transmite a Teoria informada, para pesquisa na
        /// Tabela Foto Teoria
        /// </summary>
        /// <param name="CodTeoria"></param>
        /// <returns></returns>       
        public BindingList<MOD_teoriaFoto> buscarTeoriaFoto(string CodTeoria)
        {
            try
            {
                objDAL_Foto = new DAL_teoriaFoto();
                objDtb_Foto = objDAL_Foto.buscarTeoriaFoto(CodTeoria);

                if (objDtb_Foto != null)
                {
                    listaFotoTeoria = criarListaFoto(objDtb_Foto);
                }
                return listaFotoTeoria;
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
        /// Função que Transmite a Teoria informada, para pesquisa na
        /// Tabela Foto Teoria
        /// </summary>
        /// <param name="CodFoto"></param>
        /// <returns></returns>       
        public DataTable buscarFoto(string CodFoto)
        {
            try
            {
                objDAL_Foto = new DAL_teoriaFoto();
                objDtb_Foto = objDAL_Foto.buscarFoto(CodFoto);
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

        /// <summary>
        /// Função que Transmite a Teoria informada, para pesquisa na
        /// Tabela Foto Teoria
        /// </summary>
        /// <param name="CodTeoria"></param>
        /// <returns></returns>       
        public DataTable buscarFotos(string CodTeoria)
        {
            try
            {
                objDAL_Foto = new DAL_teoriaFoto();
                objDtb_Foto = objDAL_Foto.buscarFotos(CodTeoria);
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

        /// <summary>
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int16 retornaId()
        {
            try
            {
                objDAL = new DAL_teoria();
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
        private List<MOD_teoria> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_teoria> lista = new List<MOD_teoria>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_teoria ent = new MOD_teoria();
                    //adiciona os campos às propriedades
                    ent.CodTeoria = (string)(row.IsNull("CodTeoria") ? Convert.ToString(null) : Convert.ToString(row["CodTeoria"]).PadLeft(5, '0'));
                    ent.DescTeoria = (string)(row.IsNull("DescTeoria") ? null : row["DescTeoria"]);
                    ent.AplicaEm = (string)(row.IsNull("AplicaEm") ? null : row["AplicaEm"]);
                    ent.TipoCadastro = (string)(row.IsNull("TipoCadastro") ? null : row["TipoCadastro"]);
                    ent.SepararPor = (string)(row.IsNull("SepararPor") ? null : row["SepararPor"]);
                    ent.CodModuloMts = (string)(row.IsNull("CodModuloMts") ? Convert.ToString(null) : Convert.ToString(row["CodModuloMts"]).PadLeft(3, '0'));
                    ent.DescModuloMts = (string)(row.IsNull("DescModulo") ? null : row["DescModulo"]);
                    ent.CodFaseMts = (string)(row.IsNull("CodFaseMts") ? Convert.ToString(null) : Convert.ToString(row["CodFaseMts"]).PadLeft(3, '0'));
                    ent.DescFaseMts = (string)(row.IsNull("DescFase") ? null : row["DescFase"]);
                    ent.Nivel = (string)(row.IsNull("Nivel") ? null : row["Nivel"]);
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.DataCadastro = (string)(row.IsNull("DataCadastro") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataCadastro"])));
                    ent.HoraCadastro = (string)(row.IsNull("HoraCadastro") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraCadastro"])));
                    ent.Paginas = (string)(row.IsNull("Paginas") ? Convert.ToString(null) : Convert.ToString(row["Paginas"]).PadLeft(2, '0'));

                    ///preenche a lista com os dados da Tabela Fotos
                    ent.listaFotoTeoria = buscarTeoriaFoto(ent.CodTeoria);

                    ///preenche a lista com os dados da Tabela Fotos
                    ent.CarregarFotoTeoria = buscarFotos(ent.CodTeoria);

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
        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private BindingList<MOD_teoriaFoto> criarListaFoto(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_teoriaFoto> lista = new BindingList<MOD_teoriaFoto>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_teoriaFoto ent = new MOD_teoriaFoto();
                    //adiciona os campos às propriedades
                    ent.CodFoto = (string)(row.IsNull("CodFoto") ? Convert.ToString(null) : Convert.ToString(row["CodFoto"]).PadLeft(5, '0'));
                    ent.CodTeoria = (string)(row.IsNull("CodTeoria") ? Convert.ToString(null) : Convert.ToString(row["CodTeoria"]).PadLeft(5, '0'));
                    ent.Pagina = (string)(row.IsNull("Pagina") ? null : row["Pagina"]);
                    ent.Foto = (string)(row.IsNull("Foto") ? Convert.ToString(null) : Convert.ToString(row["Foto"]));

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
        private MOD_teoria validaDadosTeoria(MOD_teoria ent)
        {
            ent.DataCadastro = string.IsNullOrEmpty(ent.DataCadastro) ? null : funcoes.DataInt(ent.DataCadastro);
            ent.HoraCadastro = string.IsNullOrEmpty(ent.HoraCadastro) ? null : funcoes.HoraInt(ent.HoraCadastro);
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
        private MOD_log criarLog(MOD_teoria ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotInsTeoria);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotEditTeoria);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotExcTeoria);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodTeoria + " > Descrição: < " + ent.DescTeoria + " > ";
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
        /// <summary>
        /// Função que criar os dados para tabela Logs
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Insert, Update ou Delete</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLogFoto(MOD_teoriaFoto ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotInsFotoTeoria);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotExcFotoTeoria);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotEditFotoTeoria);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Teoria: < " + ent.CodTeoria + " > Página: < " + ent.Pagina + " > ";
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
