using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.ComponentModel;

using DAL.administracao;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using ENT.administracao;
using BLL.pessoa;
using ENT.pessoa;

namespace BLL.administracao
{
    public class BLL_listaPresenca
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_listaPresenca objDAL = null;
        DAL_log objDAL_Log = null;

        //BLL_pessoa objBLL_Pessoa = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_listaPresenca> listaPresenca = new List<MOD_listaPresenca>();
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_listaPresenca objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela ReuniaoListaPresenca e Logs

                    objDAL = new DAL_listaPresenca();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Update");
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
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_listaPresenca objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela ReuniaoListaPresenca e Logs

                    objDAL = new DAL_listaPresenca();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodListaPresenca = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
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
        public bool excluir(MOD_listaPresenca objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicializa as Variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimento na tabela ReuniaoListaPresenca e Logs

                    objDAL = new DAL_listaPresenca();
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

        #region Busca os valores da Tabela

        /// <summary>
        /// Função que Transmite a Reuniao informado, para pesquisa
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <returns></returns>
        public List<MOD_listaPresenca> buscarListaPresenca(string CodReuniao)
        {
            try
            {
                objDAL = new DAL_listaPresenca();
                objDtb = objDAL.buscarListaPresenca(CodReuniao);

                if (objDtb != null)
                {
                    listaPresenca = criarLista(objDtb);
                }
                return listaPresenca;
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
        /// Função que Transmite a Reunião e a Pessoa informado, para pesquisa
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_listaPresenca> buscarListaPresenca(string CodReuniao, string CodPessoa)
        {
            try
            {
                objDAL = new DAL_listaPresenca();
                objDtb = objDAL.buscarListaPresenca(CodReuniao, CodPessoa);

                if (objDtb != null)
                {
                    listaPresenca = this.criarLista(objDtb);
                }
                return listaPresenca;
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
        /// Função que Transmite a Reunião, Sexo, CodCargo e CodRegiao informado, para pesquisa
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <param name="Sexo"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public List<MOD_listaPresenca> buscarRelatorioPresentes(string CodReuniao, string Sexo, string CodCargo, string CodRegiao)
        {
            try
            {
                objDAL = new DAL_listaPresenca();
                objDtb = objDAL.buscarRelatorioPresentes(CodReuniao, Sexo, CodCargo, CodRegiao);

                if (objDtb != null)
                {
                    listaPresenca = criarLista(objDtb);
                }
                return listaPresenca;
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
        /// Função que Transmite a Reunião, Sexo, CodCargo e CodRegiao informado, para pesquisa
        /// </summary>
        /// <param name="CodReuniao"></param>
        /// <param name="Sexo"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarRelatorioAusente(string CodReuniao, string Sexo, string CodCargo, string CodRegiao)
        {
            try
            {
                objDAL = new DAL_listaPresenca();
                objDtb = objDAL.buscarRelatorioAusente(CodReuniao, Sexo, CodCargo, CodRegiao);

                if (objDtb != null)
                {
                    listaPessoa = criarListaPessoa(objDtb);
                }
                return listaPessoa;
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_listaPresenca> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_listaPresenca> lista = new List<MOD_listaPresenca>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_listaPresenca ent = new MOD_listaPresenca();
                    //adiciona os campos às propriedades
                    ent.CodListaPresenca = (string)(row.IsNull("CodListaPresenca") ? Convert.ToString(null) : Convert.ToString(row["CodListaPresenca"]).PadLeft(6, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.CodCCBPessoa = (string)(row.IsNull("CodCCBPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodCCBPessoa"]).PadLeft(6, '0'));
                    ent.CodigoCCBPessoa = (string)(row.IsNull("CodigoCCBPessoa") ? null : row["CodigoCCBPessoa"]);
                    ent.DescricaoCCBPessoa = (string)(row.IsNull("DescricaoCCBPessoa") ? null : row["DescricaoCCBPessoa"]);
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]));
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.CodCidadeCCBPessoa = (string)(row.IsNull("CodCidadeCCBPessoa") ? Convert.ToString(null) : row["CodCidadeCCBPessoa"].ToString().PadLeft(6, '0'));
                    ent.CidadeCCBPessoa = (string)(row.IsNull("CidadeCCBPessoa") ? null : row["CidadeCCBPessoa"]);
                    ent.CodRegiaoPessoa = (string)(row.IsNull("CodRegiaoPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoPessoa"]).PadLeft(6, '0'));
                    ent.DescricaoRegiaoPessoa = (string)(row.IsNull("DescricaoRegiaoPessoa") ? null : row["DescricaoRegiaoPessoa"]);
                    ent.Sexo = (string)(row.IsNull("Sexo") ? null : row["Sexo"]);

                    //Dados da Tabela Reuniao Ministerio
                    ent.CodReuniao = (string)(row.IsNull("CodReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodReuniao"]).PadLeft(6, '0'));
                    ent.Status = (string)(row.IsNull("Status") ? null : row["Status"]);
                    ent.DataReuniao = (string)(row.IsNull("DataReuniao") ? Convert.ToString(null) : funcoes.IntData(Convert.ToString(row["DataReuniao"])));
                    ent.HoraReuniao = (string)(row.IsNull("HoraReuniao") ? Convert.ToString(null) : funcoes.IntHora(Convert.ToString(row["HoraReuniao"])));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.CodTipoReuniao = (string)(row.IsNull("CodTipoReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodTipoReuniao"]).PadLeft(3, '0'));
                    ent.DescTipoReuniao = (string)(row.IsNull("DescTipoReuniao") ? null : row["DescTipoReuniao"]);
                    ent.CodCCBReuniao = (string)(row.IsNull("CodCCBReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodCCBReuniao"]).PadLeft(6, '0'));
                    ent.CodigoCCBReuniao = (string)(row.IsNull("CodigoCCBReuniao") ? null : row["CodigoCCBReuniao"]);
                    ent.DescricaoCCBReuniao = (string)(row.IsNull("DescricaoCCBReuniao") ? null : row["DescricaoCCBReuniao"]);
                    ent.CodRegiaoReuniao = (string)(row.IsNull("CodRegiaoReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoReuniao"]).PadLeft(6, '0'));
                    ent.DescricaoRegiaoReuniao = (string)(row.IsNull("DescricaoRegiaoReuniao") ? null : row["DescricaoRegiaoReuniao"]);
                    ent.CodAnciao = (string)(row.IsNull("CodAnciao") ? Convert.ToString(null) : Convert.ToString(row["CodAnciao"]).PadLeft(6, '0'));
                    ent.NomeAnciao = (string)(row.IsNull("NomeAnciao") ? null : row["NomeAnciao"]);
                    ent.CodEncReg = (string)(row.IsNull("CodEncReg") ? Convert.ToString(null) : Convert.ToString(row["CodEncReg"]).PadLeft(6, '0'));
                    ent.NomeEncReg = (string)(row.IsNull("NomeEncReg") ? null : row["NomeEncReg"]);
                    ent.CodExamina = (string)(row.IsNull("CodExamina") ? Convert.ToString(null) : Convert.ToString(row["CodExamina"]).PadLeft(6, '0'));
                    ent.NomeExamina = (string)(row.IsNull("NomeExamina") ? null : row["NomeExamina"]);
                    ent.CodCooperador = (string)(row.IsNull("CodCooperador") ? Convert.ToString(null) : Convert.ToString(row["CodCooperador"]).PadLeft(6, '0'));
                    ent.NomeCoop = (string)(row.IsNull("NomeCooperador") ? null : row["NomeCooperador"]);
                    ent.CodEncLocal = (string)(row.IsNull("CodEncLocal") ? Convert.ToString(null) : Convert.ToString(row["CodEncLocal"]).PadLeft(6, '0'));
                    ent.NomeEncLocal = (string)(row.IsNull("NomeEncLocal") ? null : row["NomeEncLocal"]);
                    ent.CodInstrutor = (string)(row.IsNull("CodInstrutor") ? Convert.ToString(null) : Convert.ToString(row["CodInstrutor"]).PadLeft(6, '0'));
                    ent.NomeInstrutor = (string)(row.IsNull("NomeInstrutor") ? null : row["NomeInstrutor"]);
                    ent.CodBiblia = (string)(row.IsNull("CodBiblia") ? Convert.ToString(null) : Convert.ToString(row["CodBiblia"]).PadLeft(2, '0'));
                    ent.DescLivro = (string)(row.IsNull("DescLivro") ? null : row["DescLivro"]);
                    ent.Capitulo = (string)(row.IsNull("Capitulo") ? Convert.ToString(null) : Convert.ToString(row["Capitulo"]).PadLeft(3, '0'));
                    ent.VersoInicio = (string)(row.IsNull("VersoInicio") ? Convert.ToString(null) : Convert.ToString(row["VersoInicio"]).PadLeft(3, '0'));
                    ent.VersoFim = (string)(row.IsNull("VersoFim") ? Convert.ToString(null) : Convert.ToString(row["VersoFim"]).PadLeft(3, '0'));
                    ent.AssuntoPalavra = (string)(row.IsNull("AssuntoPalavra") ? null : row["AssuntoPalavra"]);
                    ent.HinoAbertura = (string)(row.IsNull("HinoAbertura") ? Convert.ToString(null) : Convert.ToString(row["HinoAbertura"]).PadLeft(3, '0'));

                    //Informa se o irmão compareceu na Reunião
                    ent.Presente = true;

                    BLL_pessoa objBLL_pessoa = new BLL_pessoa();
                    ent.listaPessoa = objBLL_pessoa.buscarCod(ent.CodPessoa);

                    //adiciona os dados à lista
                    lista.Add(ent);

                }

                //retorna a lista com os valores preenchidos
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
        private List<MOD_pessoa> criarListaPessoa(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoa> lista = new List<MOD_pessoa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_pessoa ent = new MOD_pessoa();
                    //adiciona os campos às propriedades
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.OrdemCargo = (string)(row.IsNull("OrdemCargo") ? Convert.ToString(null) : Convert.ToString(row["OrdemCargo"]).PadLeft(2, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.Sexo = (string)(row.IsNull("Sexo") ? null : row["Sexo"]);
                    ent.CodCidadeRes = (string)(row.IsNull("CodCidadeRes") ? Convert.ToString(null) : Convert.ToString(row["CodCidadeRes"]).PadLeft(6, '0'));
                    ent.CidadeRes = (string)(row.IsNull("CidadeRes") ? null : row["CidadeRes"]);
                    ent.EstadoRes = (string)(row.IsNull("EstadoRes") ? null : row["EstadoRes"]);
                    ent.CepRes = (string)(row.IsNull("CepRes") ? null : funcoes.FormataString("#####-###", row["CepRes"].ToString()));
                    ent.EndRes = (string)(row.IsNull("EndRes") ? null : row["EndRes"]);
                    ent.NumRes = (string)(row.IsNull("NumRes") ? null : row["NumRes"]);
                    ent.BairroRes = (string)(row.IsNull("BairroRes") ? null : row["BairroRes"]);
                    ent.ComplRes = (string)(row.IsNull("ComplRes") ? null : row["ComplRes"]);
                    ent.Telefone1 = (string)(row.IsNull("Telefone1") ? null : row["Telefone1"]);
                    ent.Telefone2 = (string)(row.IsNull("Telefone2") ? null : row["Telefone2"]);
                    ent.Celular1 = (string)(row.IsNull("Celular1") ? null : row["Celular1"]);
                    ent.Celular2 = (string)(row.IsNull("Celular2") ? null : row["Celular2"]);
                    ent.Email = (string)(row.IsNull("Email") ? null : row["Email"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.CidadeCCB = (string)(row.IsNull("CidadeCCB") ? null : row["CidadeCCB"]);
                    ent.EstadoCCB = (string)(row.IsNull("EstadoCCB") ? null : row["EstadoCCB"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.OrdemInstrumento = (string)(row.IsNull("OrdemInstrumento") ? Convert.ToString(null) : Convert.ToString(row["OrdemInstrumento"]).PadLeft(2, '0'));
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.CodRegiaoCCB = (string)(row.IsNull("CodRegiaoCCB") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoCCB"]).PadLeft(6, '0'));
                    ent.DescRegiaoCCB = (string)(row.IsNull("DescricaoRegiaoCCB") ? null : row["DescricaoRegiaoCCB"]);
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);

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
        /// Função que Solicita para a DAL pesquisar o Próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                objDAL = new DAL_listaPresenca();
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

        #endregion

        #region Funções de apoio para validações

        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private MOD_log validaDadosLog(MOD_log ent)
        {
            try
            {
                ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
                ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

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
        /// <summary>
        /// Função que criar os dados para tabela Logs
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Insert, Delete</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        private MOD_log criarLog(MOD_listaPresenca ent, string Operacao)
        {
            try
            {
                MOD_acessoListaPresenca entAcesso = new MOD_acessoListaPresenca();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsPresenca);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcPresenca);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodListaPresenca + " > Reunião nº: < " + Convert.ToString(ent.CodReuniao).PadLeft(6, '0') + " > Irmão(ã): < " + ent.Nome + " > ";
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