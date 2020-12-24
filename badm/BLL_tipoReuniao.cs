using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

using BLL.Funcoes;
using DAL.administracao;
using ENT.acessos;
using ENT.Log;
using DAL.log;
using BLL.administracao;
using ENT.pessoa;
using ENT.uteis;
using System.ComponentModel;
using ENT.administracao;

namespace BLL.administracao
{
    public class BLL_tipoReuniao
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_tipoReuniao objDAL = null;
        DAL_log objDAL_Log = null;
        DAL_tipoReuniaoCargo objDAL_TipoCargo = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;
        bool blnRetornoTipoCargo;
        bool blnRetornoTipoCargoLog;

        DataTable objDtb = null;
        DataTable objDtb_TipoCargo = null;
        DataTable objDtbCargo = null;
        DataTable objDtbUsuarioCargo = null;

        List<MOD_tipoReuniao> listaTipoReuniao = new List<MOD_tipoReuniao>();
        List<MOD_tipoReuniaoCargo> listaTipoCargo = new List<MOD_tipoReuniaoCargo>();
        List<MOD_cargo> listaCargo = new List<MOD_cargo>();
        List<MOD_usuarioCargo> listaUsuarioCargo = new List<MOD_usuarioCargo>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_tipoReuniao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;
                    blnRetornoTipoCargo = true;
                    blnRetornoTipoCargoLog = true;

                    #endregion

                    #region Movimentação da tabela TipoReuniao e Logs

                    objDAL = new DAL_tipoReuniao();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela TipoReuniaoCargo

                    //verifica se há registro na lista
                    if (objEnt.listaCargoReuniao != null && objEnt.listaCargoReuniao.Count > 0)
                    {
                        objDAL_TipoCargo = new DAL_tipoReuniaoCargo();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_tipoReuniaoCargo ent in objEnt.listaCargoReuniao)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "TipoReuniaoCargo");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodTipoReuniao = objEnt.CodTipoReuniao;
                            blnRetornoTipoCargo = objDAL_TipoCargo.salvar(ent);
                            blnRetornoTipoCargoLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoTipoCargo.Equals(false) || blnRetornoTipoCargoLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) ||
                        blnRetornoTipoCargo.Equals(false) || blnRetornoTipoCargoLog.Equals(false))
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
        public bool inserir(MOD_tipoReuniao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;
                    blnRetornoTipoCargo = true;
                    blnRetornoTipoCargoLog = true;

                    #endregion

                    #region Movimentação da tabela TipoReuniao e Logs

                    objDAL = new DAL_tipoReuniao();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodTipoReuniao = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da tabela TipoReuniaoCargo

                    //verifica se há registro na lista
                    if (objEnt.listaCargoReuniao != null && objEnt.listaCargoReuniao.Count > 0)
                    {
                        objDAL_TipoCargo = new DAL_tipoReuniaoCargo();

                        //Faz o loop para gravar na tabela
                        foreach (MOD_tipoReuniaoCargo ent in objEnt.listaCargoReuniao)
                        {
                            //Chama a função que converte as datas
                            objEnt.Logs = criarLog(objEnt, "TipoReuniaoCargo");
                            objEnt.Logs = validaDadosLog(objEnt.Logs);

                            ent.CodTipoReuniao = objEnt.CodTipoReuniao;
                            blnRetornoTipoCargo = objDAL_TipoCargo.salvar(ent);
                            blnRetornoTipoCargoLog = objDAL_Log.inserir(objEnt.Logs);

                            //verifica se o retorno foi false e sai do for
                            if (blnRetornoTipoCargo.Equals(false) || blnRetornoTipoCargoLog.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoLog.Equals(false) ||
                        blnRetornoTipoCargo.Equals(false) || blnRetornoTipoCargoLog.Equals(false))
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
        public bool excluir(MOD_tipoReuniao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela TipoReuniao e Logs

                    objDAL = new DAL_tipoReuniao();
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

        #region Busca os Valores da Tabela TipoReuniao

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <returns></returns>
        public List<MOD_tipoReuniao> buscarCod(string CodTipoReuniao)
        {
            try
            {
                objDAL = new DAL_tipoReuniao();
                objDtb = objDAL.buscarCod(CodTipoReuniao);

                if (objDtb != null)
                {
                    listaTipoReuniao = this.criarLista(objDtb);
                }
                return listaTipoReuniao;
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
        /// Função que Transmite a Descrição informado, para pesquisa
        /// </summary>
        /// <param name="DescTipoReuniao"></param>
        /// <returns></returns>
        public List<MOD_tipoReuniao> buscarDescricao(string DescTipoReuniao)
        {
            try
            {
                objDAL = new DAL_tipoReuniao();
                objDtb = objDAL.buscarDescricao("%" + DescTipoReuniao + "%");

                if (objDtb != null)
                {
                    listaTipoReuniao = criarLista(objDtb);
                }
                return listaTipoReuniao;
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

        #region Busca os Valores da Tabela Tipo Reuniao Cargo

        /// <summary>
        /// Função que Transmite o Tipo Reuniao informado, para pesquisa na
        /// Tabela Tipo Reunião Cargo
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <returns></returns>       
        public List<MOD_tipoReuniaoCargo> buscarTipoReuniaoCargo(string CodTipoReuniao)
        {
            try
            {
                objDAL_TipoCargo= new DAL_tipoReuniaoCargo();
                objDtb_TipoCargo = objDAL_TipoCargo.buscarTipoReuniaoCargo(CodTipoReuniao);

                if (objDtb_TipoCargo != null)
                {
                    listaTipoCargo = criarListaTipoCargo(objDtb_TipoCargo);
                }
                return listaTipoCargo;
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
        /// Função que Transmite o Tipo Reuniao informada, para pesquisa na
        /// Tabela Cargo
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <returns></returns>       
        public List<MOD_cargo> buscarCargos(string CodTipoReuniao)
        {
            try
            {
                objDAL_TipoCargo = new DAL_tipoReuniaoCargo();
                objDtbCargo = objDAL_TipoCargo.buscarCargos(CodTipoReuniao);

                if (objDtbCargo != null)
                {
                    listaCargo = criarListaCargo(objDtbCargo);
                }
                return listaCargo;
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
        /// Função que Transmite o Tipo Reuniao e o Usuario informada, para pesquisa na
        /// Tabela UsuarioCargo
        /// </summary>
        /// <param name="CodTipoReuniao"></param>
        /// <param name="CodUsuario"></param>
        /// <returns></returns>       
        public List<MOD_usuarioCargo> buscarUsuarioCargo(string CodTipoReuniao, string CodUsuario)
        {
            try
            {
                objDAL_TipoCargo = new DAL_tipoReuniaoCargo();
                objDtbUsuarioCargo = objDAL_TipoCargo.buscarUsuarioCargo(CodTipoReuniao, CodUsuario);

                if (objDtbUsuarioCargo != null)
                {
                    listaUsuarioCargo = criarListaUsuarioCargo(objDtbUsuarioCargo);
                }
                return listaUsuarioCargo;
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
                objDAL = new DAL_tipoReuniao();
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
        private List<MOD_tipoReuniao> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_tipoReuniao> lista = new List<MOD_tipoReuniao>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_tipoReuniao ent = new MOD_tipoReuniao();
                    //adiciona os campos às propriedades
                    ent.CodTipoReuniao = (string)(row.IsNull("CodTipoReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodTipoReuniao"]).PadLeft(3, '0'));
                    ent.DescTipoReuniao = (string)(row.IsNull("DescTipoReuniao") ? null : row["DescTipoReuniao"]);

                    ent.listaCargoReuniao = buscarTipoReuniaoCargo(ent.CodTipoReuniao);

                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista comos valores
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

        #region Lista Tipo Reuniao Cargo

        /// <summary>
        /// Função que Retorna a Lista da Tabela Tipo Reuniao Cargo Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_tipoReuniaoCargo> criarListaTipoCargo(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_tipoReuniaoCargo> lista = new List<MOD_tipoReuniaoCargo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_tipoReuniaoCargo ent = new MOD_tipoReuniaoCargo();
                    //adiciona os campos às propriedades
                    ent.CodCargoReuniao = (string)(row.IsNull("CodCargoReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodCargoReuniao"]));
                    ent.CodTipoReuniao = (string)(row.IsNull("CodTipoReuniao") ? Convert.ToString(null) : Convert.ToString(row["CodTipoReuniao"]).PadLeft(3, '0'));
                    ent.DescTipoReuniao = (string)(row.IsNull("DescTipoReuniao") ? null : row["DescTipoReuniao"]);
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]));
                    ent.Marcado = true;
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);
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
        /// Função que Retorna uma Lista da Tabela Cargos Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_cargo> criarListaCargo(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_cargo> lista = new List<MOD_cargo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_cargo ent = new MOD_cargo();
                    //adiciona os campos às propriedades
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]));
                    ent.Masculino = (row.IsNull("Masculino") || "Não".Equals(row["Masculino"])) ? false : true;
                    ent.Feminino = (row.IsNull("Feminino") || "Não".Equals(row["Feminino"])) ? false : true;
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
        /// Função que Retorna a Lista da Tabela Usuario Cargo Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        private List<MOD_usuarioCargo> criarListaUsuarioCargo(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_usuarioCargo> lista = new List<MOD_usuarioCargo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_usuarioCargo ent = new MOD_usuarioCargo();
                    //adiciona os campos às propriedades
                    ent.CodUsuarioCargo = (string)(row.IsNull("CodUsuarioCargo") ? Convert.ToString(null) : Convert.ToString(row["CodUsuarioCargo"]));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]));
                    ent.Masculino = (string)(row.IsNull("Masculino") ? null : row["Masculino"]);
                    ent.Feminino = (string)(row.IsNull("Feminino") ? null : row["Feminino"]);
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
        private MOD_log criarLog(MOD_tipoReuniao ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoTipoReuniao.RotInsTipoReuniao);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoTipoReuniao.RotEditTipoReuniao);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoTipoReuniao.RotExcTipoReuniao);
                }
                else if (Operacao.Equals("TipoReuniaoCargo"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoTipoReuniao.RotipoReuniaoCargo);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodTipoReuniao + " > Nome: < " + ent.DescTipoReuniao + " > ";
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
