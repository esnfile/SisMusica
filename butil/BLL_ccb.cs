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
using ENT.acessos;
using System.ComponentModel;

namespace BLL.uteis
{
    public class BLL_ccb
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_ccb objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_ccb> listaCCB = new List<MOD_ccb>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_ccb objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Tonalidade e Logs

                    this.objDAL = new DAL_ccb();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt = this.validaDadosCCB(objEnt);
                    objEnt.Logs = this.criarLog(objEnt, "Update");
                    objEnt.Logs = this.validaDadosLog(objEnt.Logs);

                    this.blnRetorno = this.objDAL.salvar(objEnt);
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
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_ccb objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Tonalidade e Logs

                    this.objDAL = new DAL_ccb();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodCCB = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
                    objEnt = this.validaDadosCCB(objEnt);
                    objEnt.Logs = this.criarLog(objEnt, "Insert");
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
        public bool excluir(MOD_ccb objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Tonalidade e Logs

                    this.objDAL = new DAL_ccb();
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
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarCod(string CodCCB)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarCod(CodCCB);

                if (objDtb != null)
                {
                    listaCCB = this.criarLista(objDtb);
                }
                return listaCCB;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// </summary>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarCidade(string CodCidade)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarCidade(CodCidade);

                if (objDtb != null)
                {
                    listaCCB = criarLista(objDtb);
                }
                return listaCCB;
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
        /// Função que Transmite a Cidade informada, para pesquisa
        /// </summary>
        /// <param name="Cidade"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarCidadeDescricao(string Cidade)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarCidadeDescricao(Cidade);

                if (objDtb != null)
                {
                    listaCCB = this.criarLista(objDtb);
                }
                return listaCCB;
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
        /// Função que Transmite o Estado informada, para pesquisa
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarEstado(string Estado)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarEstado(Estado);

                if (objDtb != null)
                {
                    listaCCB = this.criarLista(objDtb);
                }
                return listaCCB;
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
        /// Função que Transmite o Cnpj informada, para pesquisa
        /// </summary>
        /// <param name="Cnpj"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarCnpj(string Cnpj)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarCnpj(Cnpj);

                if (objDtb != null)
                {
                    listaCCB = this.criarLista(objDtb);
                }
                return listaCCB;
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
        public List<MOD_ccb> buscarDescricao(string Descricao)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarDescricao("%" + Descricao + "%");

                if (objDtb != null)
                {
                    listaCCB = criarLista(objDtb);
                }
                return listaCCB;
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
        /// <returns></returns>
        public List<MOD_ccb> buscarRegiao(string CodRegiao)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarRegiao(CodRegiao);

                if (objDtb != null)
                {
                    listaCCB = this.criarLista(objDtb);
                }
                return listaCCB;
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

        #region Relatorios

        /// <summary>
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: true ou false</para>
        /// <paramref name="Situacao"/>: Aberta, Em Construção, Em Reforma, Fechada
        /// </summary>
        /// <param name="Situacao"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarRelatorioCCB(string Situacao, string DataInicial, string DataFinal)
        {
            try
            {
                objDAL = new DAL_ccb();
                objDtb = objDAL.buscarRelatorioCCB(Situacao, funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal));

                if (objDtb != null)
                {
                    listaCCB = criarLista(objDtb);
                }
                return listaCCB;
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
        public int retornaId()
        {
            try
            {
                objDAL = new DAL_ccb();
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
        private List<MOD_ccb> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_ccb> lista = new List<MOD_ccb>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_ccb ent = new MOD_ccb();
                    //adiciona os campos às propriedades
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : row["CodCCB"].ToString().PadLeft(6, '0'));
                    ent.Codigo = (string)(row.IsNull("Codigo") ? null : row["Codigo"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.Endereco = (string)(row.IsNull("Endereco") ? null : row["Endereco"]);
                    ent.Numero = (string)(row.IsNull("Numero") ? null : row["Numero"]);
                    ent.Bairro = (string)(row.IsNull("Bairro") ? null : row["Bairro"]);
                    ent.Complemento = (string)(row.IsNull("Complemento") ? null : row["Complemento"]);
                    ent.CodCidade = (string)(row.IsNull("CodCidade") ? Convert.ToString(null) : row["CodCidade"].ToString().PadLeft(4, '0'));
                    ent.Cidade = (string)(row.IsNull("Cidade") ? null : row["Cidade"]);
                    ent.Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]);
                    ent.Cep = (string)(row.IsNull("Cep") ? null : funcoes.FormataString("#####-###", Convert.ToString(row["Cep"])));
                    ent.Telefone = (string)(row.IsNull("Telefone") ? null : row["Telefone"]);
                    ent.Celular = (string)(row.IsNull("Celular") ? null : row["Celular"]);
                    ent.Email = (string)(row.IsNull("Email") ? null : row["Email"]);
                    ent.CNPJ = (string)(row.IsNull("CNPJ") ? null : row["CNPJ"]);
                    ent.DataAbertura = (string)(row.IsNull("DataAbertura") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataAbertura"])));
                    ent.Skype = (string)(row.IsNull("Skype") ? null : row["Skype"]);
                    ent.Situacao = (string)(row.IsNull("Situacao") ? null : row["Situacao"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : row["CodRegiao"].ToString().PadLeft(6, '0'));
                    ent.CodigoRegiao = (string)(row.IsNull("CodigoRegiao") ? null : row["CodigoRegiao"]);
                    ent.DescricaoRegiao = (string)(row.IsNull("DescricaoRegiao") ? null : row["DescricaoRegiao"]);
                    ent.CodRegional = (string)(row.IsNull("CodRegional") ? Convert.ToString(null) : row["CodRegional"].ToString().PadLeft(4, '0'));
                    ent.CodigoRegional = (string)(row.IsNull("CodigoRegional") ? null : row["CodigoRegional"]);
                    ent.DescricaoRegional = (string)(row.IsNull("DescricaoRegional") ? null : row["DescricaoRegional"]);

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
        private MOD_ccb validaDadosCCB(MOD_ccb ent)
        {
            ent.DataAbertura = string.IsNullOrEmpty(ent.DataAbertura) ? null : funcoes.DataInt(ent.DataAbertura);
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
        private MOD_log criarLog(MOD_ccb ent, string Operacao)
        {
            try
            {
                MOD_acessoCcb entAcesso = new MOD_acessoCcb();

                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = entAcesso.rotInsCCB.ToString();
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = entAcesso.rotEditCCB.ToString();
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = entAcesso.rotExcCCB.ToString();
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodCCB + " > Comum: < " + ent.Codigo + " - " + ent.Descricao + " > Localidade: < " + ent.Cidade + " - " + ent.Estado + " - " + ent.Cep + " > ";
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
