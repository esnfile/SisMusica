using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using DAL.ajuda;
using ENT.Log;
using BLL.Funcoes;
using ENT.ajuda;

namespace BLL.ajuda
{
    public class BLL_novidades
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_novidades objDAL = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        DataTable objDtb = null;
        List<MOD_novidades> listaNovidade = new List<MOD_novidades>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_novidades objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Novidades e Logs

                    objDAL = new DAL_novidades();
                    //Chama a função que converte as datas
                    objEnt = validaDados(objEnt);
                    blnRetorno = objDAL.salvar(objEnt);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false))
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
        public bool inserir(MOD_novidades objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Novidades

                    objDAL = new DAL_novidades();
                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodNovidades = Convert.ToString(retornaId());
                    //Chama a função que converte as datas
                    objEnt = validaDados(objEnt);
                    blnRetorno = objDAL.inserir(objEnt);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false))
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
        public bool excluir(MOD_novidades objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Novidade

                    objDAL = new DAL_novidades();
                    //Chama a função que converte as datas
                    objEnt = validaDados(objEnt);
                    blnRetorno = objDAL.excluir(objEnt);

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false))
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
        /// <param name="CodNovidades"></param>
        /// <returns></returns>
        public List<MOD_novidades> buscarCod(string CodNovidades)
        {
            try
            {
                objDAL = new DAL_novidades();
                objDtb = objDAL.buscarCod(CodNovidades);

                if (objDtb != null)
                {
                    listaNovidade = criarLista(objDtb);
                }
                return listaNovidade;
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
        public List<MOD_novidades> buscarData(string DataInicial, string DataFinal)
        {
            try
            {
                objDAL = new DAL_novidades();
                objDtb = objDAL.buscarData(funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal));

                if (objDtb != null)
                {
                    listaNovidade = criarLista(objDtb);
                }
                return listaNovidade;
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
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public List<MOD_novidades> buscarDescricao(string Descricao)
        {
            try
            {
                objDAL = new DAL_novidades();
                objDtb = objDAL.buscarDescricao(Descricao + "%");

                if (objDtb != null)
                {
                    listaNovidade = criarLista(objDtb);
                }
                return listaNovidade;
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
        /// Função que Transmite o Status informado, para pesquisa
        /// <para>[Status]='Correção de Erros' OR [Status]='Novos Recursos' OR [Status]='Melhorias Internas'</para>
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        public List<MOD_novidades> buscarStatus(string Status)
        {
            try
            {
                objDAL = new DAL_novidades();
                objDtb = objDAL.buscarStatus(Status);

                if (objDtb != null)
                {
                    listaNovidade = criarLista(objDtb);
                }
                return listaNovidade;
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
        /// Função que Transmite o TipoAtualiza informada, para pesquisa
        /// <para>[TipoAtualiza]='Versão' OR [TipoAtualiza]='Módulos' OR [TipoAtualiza]='Base de Dados'</para>
        /// </summary>
        /// <param name="TipoAtualiza"></param>
        /// <returns></returns>
        public List<MOD_novidades> buscarTipoAtualiza(string TipoAtualiza)
        {
            try
            {
                objDAL = new DAL_novidades();
                objDtb = objDAL.buscarTipoAtualiza(TipoAtualiza);

                if (objDtb != null)
                {
                    listaNovidade = criarLista(objDtb);
                }
                return listaNovidade;
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
        /// Função que Transmite o Andamento informada, para pesquisa
        /// <para>[Andamento]='A Implementar' OR [Andamento]='Em Teste' OR [Andamento]='Aprovada' OR [Andamento]='Publicada'</para>
        /// </summary>
        /// <param name="Andamento"></param>
        /// <returns></returns>
        public List<MOD_novidades> buscarAndamento(string Andamento)
        {
            try
            {
                objDAL = new DAL_novidades();
                objDtb = objDAL.buscarAndamento(Andamento);

                if (objDtb != null)
                {
                    listaNovidade = criarLista(objDtb);
                }
                return listaNovidade;
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
                objDAL = new DAL_novidades();
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
        private List<MOD_novidades> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_novidades> lista = new List<MOD_novidades>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_novidades ent = new MOD_novidades();
                    //adiciona os campos às propriedades
                    ent.CodNovidades = (string)(row.IsNull("CodNovidades") ? Convert.ToString(null) : row["CodNovidades"].ToString().PadLeft(6, '0'));
                    ent.Data = (string)(row.IsNull("Data") ? Convert.ToString(null) : funcoes.IntData(row["Data"].ToString()));
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.TipoAtualiza = (string)(row.IsNull("TipoAtualiza") ? null : row["TipoAtualiza"]);
                    ent.Andamento = (string)(row.IsNull("Andamento") ? null : row["Andamento"]);
                    ent.CodPrograma = (string)(row.IsNull("CodPrograma") ? Convert.ToString(null) : row["CodPrograma"].ToString().PadLeft(4, '0'));
                    ent.DescPrograma = (string)(row.IsNull("DescPrograma") ? null : row["DescPrograma"]);
                    ent.NivelProg = (string)(row.IsNull("NivelProg") ? Convert.ToString(null) : Convert.ToString(row["NivelProg"]));
                    ent.CodSubModulo = (string)(row.IsNull("CodSubModulo") ? Convert.ToString(null) : row["CodSubModulo"].ToString().PadLeft(3, '0'));
                    ent.DescSubModulo = (string)(row.IsNull("DescSubModulo") ? null : row["DescSubModulo"]);
                    ent.NivelSub = (string)(row.IsNull("NivelSub") ? Convert.ToString(null) : Convert.ToString(row["NivelSub"]));
                    ent.CodModulo = (string)(row.IsNull("CodModulo") ? Convert.ToString(null) : row["CodModulo"].ToString().PadLeft(2, '0'));
                    ent.DescModulo = (string)(row.IsNull("DescModulo") ? null : row["DescModulo"]);
                    ent.NivelMod = (string)(row.IsNull("NivelMod") ? Convert.ToString(null) : Convert.ToString(row["NivelMod"]));
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
        private MOD_novidades validaDados(MOD_novidades ent)
        {
            ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);

            return ent;
        }

        #endregion

    }
}
