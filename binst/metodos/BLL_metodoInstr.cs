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
using System.ComponentModel;

namespace BLL.instrumentos
{
    public class BLL_metodoInstr
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_metodoInstr objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoDelete;
        bool blnRetornoLog;
        bool blnRetornoLogDelete;

        DataTable objDtb = null;

        BindingList<MOD_metodoInstr> listaMetInstr = new BindingList<MOD_metodoInstr>();
        List<MOD_metodoInstr> listaDeleteMetInstr = new List<MOD_metodoInstr>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_metodoInstr objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoDelete = true;
                    blnRetornoLog = true;
                    blnRetornoLogDelete = true;

                    #endregion

                    #region Movimento na tabela Metodo Instrumento e Logs

                    //verifica se há registro na lista Metodo Instrumento
                    objDAL = new DAL_metodoInstr();
                    objDAL_Log = new DAL_log();

                    if (objEnt.CodMetodoInstr.Equals(string.Empty))
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
                    if (blnRetorno.Equals(false) || blnRetornoDelete.Equals(false) || blnRetornoLog.Equals(false) || blnRetornoLogDelete.Equals(false))
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
        public bool excluir(MOD_metodoInstr objEnt)
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

                    objDAL = new DAL_metodoInstr();
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
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodMetodoInstr"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarCod(string CodMetodoInstr)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarCod(CodMetodoInstr);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarInstrumento(string CodInstrumento)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarInstrumento(CodInstrumento);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarInstrumento(string CodInstrumento, string AplicaEm)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarInstrumento(CodInstrumento, AplicaEm);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para> TipoMetodo In('Solfejo', 'Ritmo' ou 'Instrumento'))</para>
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoMetodo"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarInstrumento(string CodInstrumento, string AplicaEm, string TipoMetodo)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarInstrumento(CodInstrumento, AplicaEm, TipoMetodo);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite o Metodo informado, para pesquisa
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarMetodo(string CodMetodo)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarMetodo(CodMetodo);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite o Método informado, para pesquisa
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarMetodo(string CodMetodo, string AplicaEm)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarMetodo(CodMetodo, AplicaEm);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite o Método informado, para pesquisa
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <param name="AplicaEm"></param>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarMetodo(string CodMetodo, string AplicaEm, string CodInstrumento)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarMetodo(CodMetodo, AplicaEm, CodInstrumento);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite a Aplicação informada, para pesquisa
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarAplica(string AplicaEm)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarAplica(AplicaEm);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        /// Função que Transmite a Aplicação informada, para pesquisa
        /// <para> TipoMetodo In('Solfejo', 'Ritmo' ou 'Instrumento'))</para>
        ///<para>AplicarEm: Reunião de Jovens, Culto Oficial, Meia Hora, Oficialização, Troca Instrumento</para>
        /// </summary>
        /// <param name="AplicaEm"></param>
        /// <param name="TipoMetodo"></param>
        /// <returns></returns>
        public BindingList<MOD_metodoInstr> buscarAplica(string AplicaEm, string TipoMetodo)
        {
            try
            {
                objDAL = new DAL_metodoInstr();
                objDtb = objDAL.buscarAplica(AplicaEm, TipoMetodo);

                if (objDtb != null)
                {
                    listaMetInstr = this.criarLista(objDtb);
                }
                return listaMetInstr;
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
        public Int16 retornaId()
        {
            try
            {
                objDAL = new DAL_metodoInstr();
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
        private BindingList<MOD_metodoInstr> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                BindingList<MOD_metodoInstr> lista = new BindingList<MOD_metodoInstr>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_metodoInstr ent = new MOD_metodoInstr();
                    //adiciona os campos às propriedades
                    ent.CodMetodoInstr = (string)(row.IsNull("CodMetodoInstr") ? Convert.ToString(null) : Convert.ToString(row["CodMetodoInstr"]).PadLeft(5, '0'));
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodMetodo"]).PadLeft(3, '0'));
                    ent.AplicarEm = (string)(row.IsNull("AplicarEm") ? null : row["AplicarEm"]);
                    ent.FaseInicio = (string)(row.IsNull("FaseInicio") ? Convert.ToString(null) : Convert.ToString(row["FaseInicio"]).PadLeft(3, '0'));
                    ent.PaginaInicio = (string)(row.IsNull("PaginaInicio") ? Convert.ToString(null) : Convert.ToString(row["PaginaInicio"]).PadLeft(3, '0'));
                    ent.LicaoInicio = (string)(row.IsNull("LicaoInicio") ? Convert.ToString(null) : Convert.ToString(row["LicaoInicio"]).PadLeft(3, '0'));
                    ent.FaseFim = (string)(row.IsNull("FaseFim") ? Convert.ToString(null) : Convert.ToString(row["FaseFim"]).PadLeft(3, '0'));
                    ent.PaginaFim = (string)(row.IsNull("PaginaFim") ? Convert.ToString(null) : Convert.ToString(row["PaginaFim"]).PadLeft(3, '0'));
                    ent.LicaoFim = (string)(row.IsNull("LicaoFim") ? Convert.ToString(null) : Convert.ToString(row["LicaoFim"]).PadLeft(3, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.Inicio = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseInicio + " - Pág.: " + ent.PaginaInicio + " - Lição: " + ent.LicaoInicio : ent.PaginaFase.Equals("Página") ? "Pág.: " + ent.PaginaInicio + " - Lição: " + ent.LicaoInicio : "Lição: " + ent.LicaoInicio;
                    ent.Fim = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseFim + " - Pág.: " + ent.PaginaFim + " - Lição: " + ent.LicaoFim : ent.PaginaFase.Equals("Página") ? "Pág.: " + ent.PaginaFim + " - Lição: " + ent.LicaoFim : "Lição: " + ent.LicaoFim;

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
        private MOD_log criarLog(MOD_metodoInstr ent, string Operacao)
        {
            try
            {
                MOD_acessoMetodoInstr entAcesso = new MOD_acessoMetodoInstr();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);


                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsMetodoInstr);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditMetodoInstr);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcMetodoInstr);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodMetodoInstr + " > Método: < " + ent.DescMetodo + " > Instrumento: < " + ent.DescInstrumento + " > ";
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
