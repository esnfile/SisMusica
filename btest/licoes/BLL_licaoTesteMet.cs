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

namespace BLL.licao
{
    public class BLL_licaoTesteMet
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_licaoTesteMet objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_licaoTesteMet> listaLicao = new List<MOD_licaoTesteMet>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_licaoTesteMet objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação das tabelas TesteMetodo e Logs

                    objDAL = new DAL_licaoTesteMet();
                    objDAL_Log = new DAL_log();

                    if (objEnt.CodLicaoMet.Equals(string.Empty))
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
        public bool excluir(MOD_licaoTesteMet objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    objDAL = new DAL_licaoTesteMet();
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
        public List<MOD_licaoTesteMet> buscarLicaoMet(string CodInstrumento)
        {
            try
            {
                objDAL = new DAL_licaoTesteMet();
                objDtb = objDAL.buscarLicaoMet(CodInstrumento);

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
        /// Função que Transmite o Instrumento e o Metodo informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteMet> buscarLicaoMet(string CodInstrumento, string CodMetodo)
        {
            try
            {
                objDAL = new DAL_licaoTesteMet();
                objDtb = objDAL.buscarLicaoMet(CodInstrumento, CodMetodo);

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
        /// Função que Transmite o Instrumento e o Metodo informado, para pesquisa
        ///<para>AplicaEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodMetodo"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteMet> buscarLicaoMet(string CodInstrumento, string CodMetodo, string AplicaEm)
        {
            try
            {
                objDAL = new DAL_licaoTesteMet();
                objDtb = objDAL.buscarLicaoMet(CodInstrumento, CodMetodo, AplicaEm);

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
        /// Função que Transmite o Instrumento e o metodo informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="DescMetodo"></param>
        /// <returns></returns>
        public List<MOD_licaoTesteMet> buscarLicaoDescMet(string CodInstrumento, string DescMetodo)
        {
            try
            {
                objDAL = new DAL_licaoTesteMet();
                objDtb = objDAL.buscarLicaoDescMet(CodInstrumento, DescMetodo);

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
                objDAL = new DAL_licaoTesteMet();
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
        private List<MOD_licaoTesteMet> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_licaoTesteMet> lista = new List<MOD_licaoTesteMet>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_licaoTesteMet ent = new MOD_licaoTesteMet();
                    //adiciona os campos às propriedades
                    ent.CodLicaoMet = (string)(row.IsNull("CodLicaoMet") ? Convert.ToString(null) : Convert.ToString(row["CodLicaoMet"]).PadLeft(4, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.Situacao = (string)(row.IsNull("Situacao") ? null : row["Situacao"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(3, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodMetodo"]).PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.QtdePagina = (string)(row.IsNull("QtdePagina") ? Convert.ToString(null) : Convert.ToString(row["QtdePagina"]).PadLeft(3, '0'));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.AplicaEm = (string)(row.IsNull("AplicaEm") ? null : row["AplicaEm"]);
                    ent.FaseMet = (string)(row.IsNull("FaseMet") ? Convert.ToString(null) : Convert.ToString(row["FaseMet"]).PadLeft(3, '0'));
                    ent.PaginaMet = (string)(row.IsNull("PaginaMet") ? Convert.ToString(null) : Convert.ToString(row["PaginaMet"]).PadLeft(3, '0'));
                    ent.LicaoMet = (string)(row.IsNull("LicaoMet") ? Convert.ToString(null) : Convert.ToString(row["LicaoMet"]).PadLeft(3, '0'));
                    ent.FasePagLicao = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseMet.PadLeft(3, '0') + " - Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0') : ent.PaginaFase.Equals("Página") ? "Pág.: " + ent.PaginaMet.PadLeft(3, '0') + " - Lição: " + ent.LicaoMet.PadLeft(3, '0') : "Lição: " + ent.LicaoMet.PadLeft(3, '0');
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
        private MOD_log criarLog(MOD_licaoTesteMet ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotInsLicaoTesteMet);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotEditLicaoTesteMet);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotExcLicaoTesteMet);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Alterado Lição! Código: < " + ent.CodLicaoMet + " > Instrumento: < " + ent.DescInstrumento + " > Método: < " + ent.DescMetodo + " > Aplicado em: < " + ent.AplicaEm + " >. ";
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