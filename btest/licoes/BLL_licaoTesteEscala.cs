using System;
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
using ENT.instrumentos;

namespace BLL.licao
{
    public class BLL_licaoTesteEscala
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_licaoTesteEscala objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_licaoTesteEscala> listaLicao = new List<MOD_licaoTesteEscala>();
        List<MOD_tipoEscala> listaTipoEscala = new List<MOD_tipoEscala>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteEscala objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação das tabelas TesteHino e Logs

                    objDAL = new DAL_licaoTesteEscala();
                    objDAL_Log = new DAL_log();

                    if (objEnt.CodLicaoEscala.Equals(string.Empty))
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
        public bool excluir(MOD_licaoTesteEscala objEnt)
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

                    objDAL = new DAL_licaoTesteEscala();
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
        public List<MOD_licaoTesteEscala> buscarLicaoEscala(string CodInstrumento)
        {
            try
            {
                objDAL = new DAL_licaoTesteEscala();
                objDtb = objDAL.buscarLicaoEscala(CodInstrumento);

                if (objDtb != null)
                {
                    listaLicao = this.criarLista(objDtb);
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
        /// Função que Transmite o Instrumento e o TipoEscala informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodTipoEscala"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteEscala> buscarLicaoEscala(string CodInstrumento, string CodTipoEscala)
        {
            try
            {
                objDAL = new DAL_licaoTesteEscala();
                objDtb = objDAL.buscarLicaoEscala(CodInstrumento, CodTipoEscala);

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
        /// Função que Transmite o Instrumento e o TipoEscala informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodTipoEscala"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteEscala> buscarLicaoEscala(string CodInstrumento, string CodTipoEscala, string AplicaEm)
        {
            try
            {
                objDAL = new DAL_licaoTesteEscala();
                objDtb = objDAL.buscarLicaoEscala(CodInstrumento, CodTipoEscala, AplicaEm);

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
        /// Função que Transmite o Instrumento e a Escala informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="DescEscala"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteEscala> buscarLicaoDescEscala(string CodInstrumento, string DescEscala)
        {
            try
            {
                objDAL = new DAL_licaoTesteEscala();
                objDtb = objDAL.buscarLicaoDescEscala(CodInstrumento, DescEscala);

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
        /// Função que Transmite o Instrumento e a Escala informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public List<MOD_tipoEscala> buscarLicaoTipoEscala(string CodInstrumento, string AplicaEm)
        {
            try
            {
                objDAL = new DAL_licaoTesteEscala();
                objDtb = objDAL.buscarLicaoTipoEscala(CodInstrumento, AplicaEm);

                if (objDtb != null)
                {
                    listaTipoEscala = criarListaTipoEscala(objDtb);
                }
                return listaTipoEscala;
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
                objDAL = new DAL_licaoTesteEscala();
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
        private List<MOD_licaoTesteEscala> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_licaoTesteEscala> lista = new List<MOD_licaoTesteEscala>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_licaoTesteEscala ent = new MOD_licaoTesteEscala();
                    //adiciona os campos às propriedades
                    ent.CodLicaoEscala = (string)(row.IsNull("CodLicaoEscala") ? Convert.ToString(null) : row["CodLicaoEscala"].ToString().PadLeft(4, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : row["CodInstrumento"].ToString().PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.AplicaEm = (string)(row.IsNull("AplicaEm") ? null : row["AplicaEm"]);
                    ent.CodEscala = (string)(row.IsNull("CodEscala") ? Convert.ToString(null) : Convert.ToString(row["CodEscala"]).PadLeft(4, '0'));
                    ent.DescEscala = (string)(row.IsNull("DescEscala") ? null : row["DescEscala"]);
                    ent.Alteracoes = (string)(row.IsNull("Alteracoes") ? null : row["Alteracoes"]);
                    ent.Modelo = (string)(row.IsNull("Modelo") ? null : row["Modelo"]);
                    ent.Tonica = (string)(row.IsNull("Tonica") ? null : row["Tonica"]);
                    ent.CodTipoEscala = (string)(row.IsNull("CodTipoEscala") ? Convert.ToString(null) : Convert.ToString(row["CodTipoEscala"]).PadLeft(3, '0'));
                    ent.DescTipo = (string)(row.IsNull("DescTipo") ? null : row["DescTipo"]);
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
        private List<MOD_tipoEscala> criarListaTipoEscala(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_tipoEscala> lista = new List<MOD_tipoEscala>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_tipoEscala ent = new MOD_tipoEscala();
                    //adiciona os campos às propriedades
                    ent.CodTipoEscala = (string)(row.IsNull("CodTipoEscala") ? Convert.ToString(null) : Convert.ToString(row["CodTipoEscala"]).PadLeft(3, '0'));
                    ent.DescTipo = (string)(row.IsNull("DescTipo") ? null : row["DescTipo"]);
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
        private MOD_log criarLog(MOD_licaoTesteEscala ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotInsLicaoTesteEsc);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotEditLicaoTesteEsc);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotExcLicaoTesteEsc);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Alterado Lição! Código: < " + ent.CodLicaoEscala + " > Instrumento: < " + ent.DescInstrumento + " > Escala: < " + ent.DescEscala + " > Aplicado em: < " + ent.AplicaEm + " >. ";
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
