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

namespace BLL.uteis
{
    public class BLL_cidade
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_cidade objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_cidade> listaCidade = new List<MOD_cidade>();
        List<MOD_uf> listaEstado = new List<MOD_uf>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_cidade objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Cidade e Logs

                    this.objDAL = new DAL_cidade();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt = validaDados(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Update");
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
        public bool inserir(MOD_cidade objEnt)
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

                    objDAL = new DAL_cidade();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodCidade = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
                    objEnt = validaDados(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
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
        public bool excluir(MOD_cidade objEnt)
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

                    this.objDAL = new DAL_cidade();
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
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public List<MOD_cidade> buscarCod(string CodCidade)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarCod(CodCidade);

                if (objDtb != null)
                {
                    listaCidade = this.criarLista(objDtb);
                }
                return listaCidade;
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
        public List<MOD_cidade> buscarCidade(string Cidade)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarCidade(Cidade + "%");

                if (objDtb != null)
                {
                    listaCidade = this.criarLista(objDtb);
                }
                return listaCidade;
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
        /// Função que Transmite a Cidade e o Estado informada, para pesquisa
        /// </summary>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public List<MOD_cidade> buscarCidade(string Cidade, string Estado)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarCidade("%" + Cidade + "%", Estado);

                if (objDtb != null)
                {
                    listaCidade = this.criarLista(objDtb);
                }
                return listaCidade;
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
        /// Função que Transmite a Cidade e o Estado informada, para pesquisa
        /// </summary>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        /// <param name="Endereco"></param>
        /// <returns></returns>
        public List<MOD_cidade> buscarCidade(string Cidade, string Estado, string Endereco)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarCidade("%" + Cidade + "%", Estado, "%" + Endereco + "%");

                if (objDtb != null)
                {
                    listaCidade = criarLista(objDtb);
                }
                return listaCidade;
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
        /// Função que Transmite a Cidade e o Estado informada, para pesquisa
        /// </summary>
        /// <param name="Cidade"></param>
        /// <param name="Estado"></param>
        /// <param name="Endereco"></param>
        /// <param name="Bairro"></param>
        /// <returns></returns>
        public List<MOD_cidade> buscarCidade(string Cidade, string Estado, string Endereco, string Bairro)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarCidade("%" + Cidade + "%", Estado, "%" + Endereco + "%", "%" + Bairro + "%");

                if (objDtb != null)
                {
                    listaCidade = criarLista(objDtb);
                }
                return listaCidade;
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
        public List<MOD_cidade> buscarEstado(string Estado)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarEstado(Estado);

                if (objDtb != null)
                {
                    listaCidade = criarLista(objDtb);
                }
                return listaCidade;
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
        /// <para>Essa consulta trará apenas os nomes dos municipios e não os ceps</para>
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public List<MOD_cidade> buscarMunicipios(string Estado)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarMunicipios(Estado);

                if (objDtb != null)
                {
                    listaCidade = criarListaMunicipio(objDtb);
                }
                return listaCidade;
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
        /// Função que Transmite o Cep informada, para pesquisa
        /// </summary>
        /// <param name="Cep"></param>
        /// <returns></returns>
        public List<MOD_cidade> buscarCep(string Cep)
        {
            try
            {
                objDAL = new DAL_cidade();

                Cep = Cep.Replace(" ", "").Replace("-", "").Replace(".", "").Replace(",", "");
                objDtb = objDAL.buscarCep(Cep);

                if (objDtb != null)
                {
                    listaCidade = this.criarLista(objDtb);
                }
                return listaCidade;
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
        /// Função que Transmite o Estado informado, para pesquisa
        /// </summary>
        /// <param name="Sigla"></param>
        /// <returns></returns>
        public List<MOD_uf> buscarUf(string Sigla)
        {
            try
            {
                objDAL = new DAL_cidade();
                objDtb = objDAL.buscarUf(Sigla + "%");

                if (objDtb != null)
                {
                    listaEstado = this.criarListaUf(objDtb);
                }
                return listaEstado;
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
        public int retornaId()
        {
            try
            {
                objDAL = new DAL_cidade();
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
        private List<MOD_cidade> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_cidade> lista = new List<MOD_cidade>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_cidade ent = new MOD_cidade();
                    //adiciona os campos às propriedades
                    ent.CodCidade = (string)(row.IsNull("CodCidade") ? Convert.ToString(null) : row["CodCidade"].ToString().PadLeft(6, '0'));
                    ent.Cidade = (string)(row.IsNull("Cidade") ? null : row["Cidade"]);
                    ent.Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]);
                    ent.Cep = (string)(row.IsNull("Cep") ? null : funcoes.FormataString("#####-###", row["Cep"].ToString()));
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Endereco = (string)(row.IsNull("Endereco") ? null : row["Endereco"]);
                    ent.Bairro = (string)(row.IsNull("Bairro") ? null : row["Bairro"]);
                    ent.Complemento = (string)(row.IsNull("Complemento") ? null : row["Complemento"]);
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
        private List<MOD_cidade> criarListaMunicipio(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_cidade> lista = new List<MOD_cidade>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_cidade ent = new MOD_cidade();
                    //adiciona os campos às propriedades
                    ent.Cidade = (string)(row.IsNull("Cidade") ? null : row["Cidade"]);
                    ent.Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]);
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
        private List<MOD_uf> criarListaUf(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_uf> lista = new List<MOD_uf>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_uf ent = new MOD_uf();
                    //adiciona os campos às propriedades
                    ent.Sigla = (string)(row.IsNull("Sigla") ? null : row["Sigla"]);
                    ent.Uf = (string)(row.IsNull("Uf") ? null : row["Uf"]);
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
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_cidade validaDados(MOD_cidade ent)
        {
            string novoValor = string.Empty;
            novoValor = string.IsNullOrEmpty(ent.Cep) ? null : Convert.ToString(ent.Cep).Replace(" ", "").Replace("-", "").Replace(".", "").Replace(",", "");
            ent.Cep = novoValor;

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
        private MOD_log criarLog(MOD_cidade ent, string Operacao)
        {
            try
            {
                MOD_acessoCidade entAcesso = new MOD_acessoCidade();

                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = entAcesso.rotInsCidade.ToString();
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = entAcesso.rotEditCidade.ToString();
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = entAcesso.rotExcCidade.ToString();
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodCidade + " > Cidade: < " + ent.Cidade + " > Cep: < " + ent.Cep + " > ";
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
