using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using ENT.uteis;
using DAL.uteis;
using BLL.Funcoes;

namespace BLL.uteis
{
    public class BLL_versao
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_versao objDAL = null;

        //variaveis que retornam os valores
        bool blnRetorno;

        DataTable objDtb = null;

        List<MOD_versao> listaVersao = new List<MOD_versao>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_versao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Versao e Logs

                    this.objDAL = new DAL_versao();
                    objEnt = validaDadosVersao(objEnt);
                    this.blnRetorno = this.objDAL.salvar(objEnt);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false))
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
        public bool inserir(MOD_versao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    this.objDAL = new DAL_versao();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodVersao = Convert.ToString(this.retornaId());
                    objEnt = validaDadosVersao(objEnt);
                    this.blnRetorno = this.objDAL.inserir(objEnt);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false))
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
        public bool excluir(MOD_versao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    this.objDAL = new DAL_versao();
                    this.blnRetorno = this.objDAL.excluir(objEnt);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (this.blnRetorno.Equals(false))
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
        /// <param name="CodVersao"></param>
        /// <returns></returns>
        public List<MOD_versao> buscarVersao(string CodVersao)
        {
            try
            {
                objDAL = new DAL_versao();
                objDtb = objDAL.buscarVersao(CodVersao);

                if (objDtb != null)
                {
                    listaVersao = this.criarLista(objDtb);
                }
                return listaVersao;
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
        /// Função que Buscar a ultima Versão
        /// </summary>
        /// <returns></returns>
        public List<MOD_versao> buscarUltVersao()
        {
            try
            {
                objDAL = new DAL_versao();
                objDtb = objDAL.buscarUltVersao();

                if (objDtb != null)
                {
                    listaVersao = this.criarLista(objDtb);
                }
                return listaVersao;
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
        /// Função que Transmite a Data informada, para pesquisa
        /// </summary>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public List<MOD_versao> buscarData(string DataInicial, string DataFinal)
        {
            try
            {
                objDAL = new DAL_versao();
                objDtb = objDAL.buscarData(DataInicial, DataFinal);

                if (objDtb != null)
                {
                    listaVersao = this.criarLista(objDtb);
                }
                return listaVersao;
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
                objDAL = new DAL_versao();
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
        private List<MOD_versao> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_versao> lista = new List<MOD_versao>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_versao ent = new MOD_versao();
                    //adiciona os campos às propriedades
                    ent.CodVersao = (string)(row.IsNull("CodVersao") ? Convert.ToString(null) : Convert.ToString(row["CodVersao"]).PadLeft(6, '0'));
                    ent.VersaoPrincipal = (string)(row.IsNull("VersaoPrincipal") ? Convert.ToString(null) : Convert.ToString(row["VersaoPrincipal"]));
                    ent.VersaoSecundaria = (string)(row.IsNull("VersaoSecundaria") ? Convert.ToString(null) : Convert.ToString(row["VersaoSecundaria"]));
                    ent.NumeroVersao = (string)(row.IsNull("NumeroVersao") ? Convert.ToString(null) : Convert.ToString(row["NumeroVersao"]));
                    ent.Revisao = (string)(row.IsNull("Revisao") ? Convert.ToString(null) : Convert.ToString(row["Revisao"]));
                    ent.DataLancamento = (string)(row.IsNull("DataLancamento") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataLancamento"])));
                    ent.HoraLancamento = (string)(row.IsNull("HoraLancamento") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraLancamento"])));
                    ent.TipoAtualizacao = (string)(row.IsNull("TipoAtualizacao") ? null : row["TipoAtualizacao"]);
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
        private MOD_versao validaDadosVersao(MOD_versao ent)
        {
            try
            {
                ent.DataLancamento   = string.IsNullOrEmpty(ent.DataLancamento) ? null : funcoes.DataInt(ent.DataLancamento);
                ent.HoraLancamento = string.IsNullOrEmpty(ent.HoraLancamento) ? null : funcoes.HoraInt(ent.HoraLancamento);

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

        #endregion

    }
}
