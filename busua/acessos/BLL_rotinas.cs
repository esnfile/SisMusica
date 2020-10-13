using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using ENT.acessos;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using DAL.acessos;

namespace BLL.acessos
{
    public class BLL_rotinas
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_rotinas objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_rotinas> listaRotina = new List<MOD_rotinas>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_rotinas objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Rotina e Logs

                    this.objDAL = new DAL_rotinas();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
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
        public bool inserir(MOD_rotinas objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    this.objDAL = new DAL_rotinas();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodRotina = Convert.ToString(this.retornaId());

                    //Chama a função que converte as datas
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
        public bool excluir(MOD_rotinas objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela Familia e Logs

                    this.objDAL = new DAL_rotinas();
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
        /// <param name="CodRotina"></param>
        /// <returns></returns>
        public List<MOD_rotinas> buscarCod(string CodRotina)
        {
            try
            {
                objDAL = new DAL_rotinas();
                objDtb = objDAL.buscarCod(CodRotina);

                if (objDtb != null)
                {
                    listaRotina = this.criarLista(objDtb);
                }
                return listaRotina;
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
        /// Função que Transmite o Nivel informado, para pesquisa
        /// </summary>
        /// <param name="Nivel"></param>
        /// <returns></returns>
        public List<MOD_rotinas> buscarNivel(string Nivel)
        {
            try
            {
                objDAL = new DAL_rotinas();
                objDtb = objDAL.buscarNivel(Nivel);

                if (objDtb != null)
                {
                    listaRotina = this.criarLista(objDtb);
                }
                return listaRotina;
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
        public List<MOD_rotinas> buscarDescricao(string Descricao)
        {
            try
            {
                objDAL = new DAL_rotinas();
                objDtb = objDAL.buscarDescricao(Descricao + "%");

                if (objDtb != null)
                {
                    listaRotina = this.criarLista(objDtb);
                }
                return listaRotina;
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
        /// Função que Transmite o Programa informado, para pesquisa
        /// </summary>
        /// <param name="CodPrograma"></param>
        /// <returns></returns>
        public List<MOD_rotinas> buscarPrograma(string CodPrograma)
        {
            try
            {
                objDAL = new DAL_rotinas();
                objDtb = objDAL.buscarPrograma(CodPrograma);

                if (objDtb != null)
                {
                    listaRotina = this.criarLista(objDtb);
                }
                return listaRotina;
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
                objDAL = new DAL_rotinas();
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
        private List<MOD_rotinas> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_rotinas> lista = new List<MOD_rotinas>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_rotinas ent = new MOD_rotinas();
                    //adiciona os campos às propriedades
                    ent.CodRotina = (string)(row.IsNull("CodRotina") ? Convert.ToString(null) : row["CodRotina"].ToString().PadLeft(5, '0'));
                    ent.DescRotina = (string)(row.IsNull("DescRotina") ? null : row["DescRotina"]);
                    ent.NivelRotina = (string)(row.IsNull("NivelRotina") ? Convert.ToString(null) : Convert.ToString(row["NivelRotina"]));
                    ent.DescSeg = (string)(row.IsNull("DescSeg") ? null : row["DescSeg"]);
                    ent.DescInd = (string)(row.IsNull("DescInd") ? null : row["DescInd"]);
                    ent.CodPrograma = (string)(row.IsNull("CodPrograma") ? Convert.ToString(null) : row["CodPrograma"].ToString().PadLeft(4, '0'));
                    ent.DescPrograma = (string)(row.IsNull("DescPrograma") ? null : row["DescPrograma"]);
                    ent.NivelProg = (string)(row.IsNull("NivelProg") ? Convert.ToString(null) : Convert.ToString(row["NivelProg"]));
                    ent.CodSubModulo = (string)(row.IsNull("CodSubModulo") ? Convert.ToString(null) : row["CodSubModulo"].ToString().PadLeft(3, '0'));
                    ent.DescSubModulo = (string)(row.IsNull("DescSubModulo") ? null : row["DescSubModulo"]);
                    ent.NivelSub = (string)(row.IsNull("NivelSub") ? Convert.ToString(null) : Convert.ToString(row["NivelSub"]));
                    ent.CodModulo = (string)(row.IsNull("CodModulo") ? Convert.ToString(null) : row["CodModulo"].ToString().PadLeft(2, '0'));
                    ent.DescModulo = (string)(row.IsNull("DescModulo") ? null : row["DescModulo"]);
                    ent.NivelMod = (string)(row.IsNull("NivelMod") ? Convert.ToString(null) : Convert.ToString(row["NivelMod"]));
                    ent.LiberaAcesso = (string)(row.IsNull("LiberaAcesso") ? null : row["LiberaAcesso"]);
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
        private MOD_log criarLog(MOD_rotinas ent, string Operacao)
        {
            try
            {
                MOD_acessoRotinas entAcesso = new MOD_acessoRotinas();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsRotModulo);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditRotModulo);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcRotModulo);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodRotina + " > Descrição: < " + ent.DescRotina + " > ";
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
