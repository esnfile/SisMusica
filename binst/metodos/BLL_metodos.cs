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
    public class BLL_metodos
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_metodos objDAL = null;
        DAL_metodoFamilia objDAL_MetFam = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoMetFam;
        bool blnRetornoLog;

        DataTable objDtb = null;
        DataTable objDtb_MetFam = null;

        List<MOD_metodos> listaMetodo = new List<MOD_metodos>();
        List<MOD_metodoFamilia> listaMetFam = new List<MOD_metodoFamilia>();
        List<MOD_familia> listaFamilia = new List<MOD_familia>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_metodos objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoMetFam = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Metodo e Logs

                    this.objDAL = new DAL_metodos();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Update");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.salvar(objEnt);
                    this.blnRetornoLog = this.objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimento na tabela Metodo Familia

                    //verifica se há registro na lista Metodo Familia
                    if (objEnt.listaMetodoFamilia != null && objEnt.listaMetodoFamilia.Count > 0)
                    {
                        objDAL_MetFam = new DAL_metodoFamilia();

                        //Faz o loop para gravar na tabela Metodo Familia
                        foreach (MOD_metodoFamilia ent in objEnt.listaMetodoFamilia)
                        {
                            ent.CodMetodo = objEnt.CodMetodo;
                            blnRetornoMetFam = objDAL_MetFam.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (this.blnRetornoMetFam.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false) || this.blnRetornoLog.Equals(false) || this.blnRetornoMetFam.Equals(false))
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
        public bool inserir(MOD_metodos objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoMetFam = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Metodo e Logs

                    this.objDAL = new DAL_metodos();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodMetodo = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = this.criarLog(objEnt, "Insert");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.inserir(objEnt);
                    this.blnRetornoLog = this.objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimento na tabela Metodo Familia

                    //verifica se há registro na lista Metodo Familia
                    if (objEnt.listaMetodoFamilia != null && objEnt.listaMetodoFamilia.Count > 0)
                    {
                        objDAL_MetFam = new DAL_metodoFamilia();

                        //Faz o loop para gravar na tabela Metodo Familia
                        foreach (MOD_metodoFamilia ent in objEnt.listaMetodoFamilia)
                        {
                            ent.CodMetodo = objEnt.CodMetodo;
                            this.blnRetornoMetFam = objDAL_MetFam.salvar(ent);

                            //verifica se o retorno foi false e sai do for
                            if (this.blnRetornoMetFam.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false) || this.blnRetornoLog.Equals(false) || this.blnRetornoMetFam.Equals(false))
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
        public bool excluir(MOD_metodos objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Metodo e Logs

                    this.objDAL = new DAL_metodos();
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
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarCod(string CodMetodo)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarCod(CodMetodo);

                if (objDtb != null)
                {
                    listaMetodo = this.criarLista(objDtb);
                }
                return listaMetodo;
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
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarCod(string CodMetodo, string Ativo)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarCod(CodMetodo, Ativo);

                if (objDtb != null)
                {
                    listaMetodo = this.criarLista(objDtb);
                }
                return listaMetodo;
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
        public List<MOD_metodos> buscarDescricao(string DescInstrumento)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarDescricao(DescInstrumento + "%");

                if (objDtb != null)
                {
                    listaMetodo = this.criarLista(objDtb);
                }
                return listaMetodo;
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
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarDescricao(string DescInstrumento, string Ativo)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarDescricao(DescInstrumento + "%", Ativo);

                if (objDtb != null)
                {
                    listaMetodo = this.criarLista(objDtb);
                }
                return listaMetodo;
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
        /// Função que Transmite o TipoEscolha informado, para pesquisa
        /// </summary>
        /// <param name="TipoEscolha"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarTipoEscolha(string TipoEscolha)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarTipoEscolha(TipoEscolha);

                if (objDtb != null)
                {
                    listaMetodo = this.criarLista(objDtb);
                }
                return listaMetodo;
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
        /// Função que Transmite o TipoEscolha informado, para pesquisa
        /// </summary>
        /// <param name="TipoEscolha"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarTipoEscolha(string TipoEscolha, string Ativo)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarTipoEscolha(TipoEscolha, Ativo);

                if (objDtb != null)
                {
                    listaMetodo = criarLista(objDtb);
                }
                return listaMetodo;
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
        /// Função que Transmite o Compositor informado, para pesquisa
        /// </summary>
        /// <param name="Compositor"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarCompositor(string Compositor)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarCompositor(Compositor);

                if (objDtb != null)
                {
                    listaMetodo = this.criarLista(objDtb);
                }
                return listaMetodo;
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
        /// Função que Transmite o Compositor informado, para pesquisa
        /// </summary>
        /// <param name="Compositor"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarCompositor(string Compositor, string Ativo)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarCompositor(Compositor, Ativo);

                if (objDtb != null)
                {
                    listaMetodo = criarLista(objDtb);
                }
                return listaMetodo;
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
        /// <returns></returns>
        public List<MOD_metodos> buscarTipo(string Tipo)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarTipo(Tipo);

                if (objDtb != null)
                {
                    listaMetodo = this.criarLista(objDtb);
                }
                return listaMetodo;
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
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_metodos> buscarTipo(string Tipo, string Ativo)
        {
            try
            {
                objDAL = new DAL_metodos();
                objDtb = objDAL.buscarTipo(Tipo, Ativo);

                if (objDtb != null)
                {
                    listaMetodo = criarLista(objDtb);
                }
                return listaMetodo;
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

        #region Metodo Familia

        /// <summary>
        /// Função que Transmite o Metodo informada, para pesquisa na
        /// Tabela Metodo Familia
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>       
        public List<MOD_metodoFamilia> buscarMetodoFamilia(string CodMetodo)
        {
            try
            {
                objDAL_MetFam= new DAL_metodoFamilia();
                objDtb_MetFam = objDAL_MetFam.buscarMetodoFamilia(CodMetodo);

                if (objDtb_MetFam != null)
                {
                    listaMetFam = criarListaMetFam(objDtb_MetFam);
                }
                return listaMetFam;
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
        /// Função que Transmite a Familia informada, para pesquisa na
        /// Tabela Metodo Familia
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>       
        public List<MOD_metodoFamilia> buscarMetFamilia(string CodFamilia)
        {
            try
            {
                objDAL_MetFam = new DAL_metodoFamilia();
                objDtb_MetFam = objDAL_MetFam.buscarMetFamilia(CodFamilia);

                if (objDtb_MetFam != null)
                {
                    listaMetFam = criarListaMetFam(objDtb_MetFam);
                }
                return listaMetFam;
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
        /// Função que Transmite a Familia informada, para pesquisa na
        /// Tabela Metodo Familia
        /// </summary>
        /// <param name="CodFamilia"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>       
        public List<MOD_metodoFamilia> buscarMetFamilia(string CodFamilia, string Ativo)
        {
            try
            {
                objDAL_MetFam = new DAL_metodoFamilia();
                objDtb_MetFam = objDAL_MetFam.buscarMetFamilia(CodFamilia, Ativo);

                if (objDtb_MetFam != null)
                {
                    listaMetFam = criarListaMetFam(objDtb_MetFam);
                }
                return listaMetFam;
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
        /// Função que Transmite o Metodo informado, para pesquisa na
        /// Tabela Familia
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>       
        public List<MOD_familia> buscarFamilia(string CodMetodo)
        {
            try
            {
                objDAL_MetFam = new DAL_metodoFamilia();
                objDtb_MetFam = objDAL_MetFam.buscarFamilia(CodMetodo);

                if (objDtb_MetFam != null)
                {
                    listaFamilia = criarListaFamilia(objDtb_MetFam);
                }
                return listaFamilia;
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
                objDAL = new DAL_metodos();
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
        private List<MOD_metodos> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_metodos> lista = new List<MOD_metodos>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_metodos ent = new MOD_metodos();
                    //adiciona os campos às propriedades
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : row["CodMetodo"].ToString().PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);

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
        
        #region Metodo Familia

        /// <summary>
        /// Função que Retorna a Lista da Tabela Metodo Familia Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_metodoFamilia> criarListaMetFam(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_metodoFamilia> lista = new List<MOD_metodoFamilia>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_metodoFamilia ent = new MOD_metodoFamilia();
                    //adiciona os campos às propriedades
                    ent.CodMetodoFamilia = (string)(row.IsNull("CodMetodoFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodMetodoFamilia"]).PadLeft(6, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodMetodo"]).PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
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
        /// Função que Retorna uma Lista da Tabela Familia Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_familia> criarListaFamilia(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_familia> lista = new List<MOD_familia>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_familia ent = new MOD_familia();
                    //adiciona os campos às propriedades
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
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
        private MOD_log criarLog(MOD_metodos ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoMetodo.RotInsMetodo);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoMetodo.RotEditMetodo);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoMetodo.RotExcMetodo);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodMetodo + " > Descrição: < " + ent.DescMetodo + " > ";
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
