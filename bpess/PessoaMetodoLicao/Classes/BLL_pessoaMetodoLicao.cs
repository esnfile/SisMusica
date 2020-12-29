using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using ENT.pessoa;
using DAL.pessoa;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;

namespace BLL.pessoa
{
    public class BLL_pessoaMetodoLicao
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_pessoaMetodoLicao objDAL = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoLog;

        DataTable objDtb = null;

        List<MOD_pessoaMetodoLicao> listaPesMetLicao = new List<MOD_pessoaMetodoLicao>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_pessoaMetodoLicao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela PessoaMetodoLicao e Logs

                    this.objDAL = new DAL_pessoaMetodoLicao();
                    this.objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
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
        public bool inserir(MOD_pessoaMetodoLicao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela PessoaMetodoLicao e Logs

                    objDAL = new DAL_pessoaMetodoLicao();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodPesMetLicao = Convert.ToString(retornaId());

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
        public bool excluir(MOD_pessoaMetodoLicao objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela PessoaMetodoLicao e Logs

                    this.objDAL = new DAL_pessoaMetodoLicao();
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
        /// <param name="CodPesMetLicao"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodoLicao> buscarCod(string CodPesMetLicao)
        {
            try
            {
                objDAL = new DAL_pessoaMetodoLicao();
                objDtb = objDAL.buscarCod(CodPesMetLicao);

                if (objDtb != null)
                {
                    listaPesMetLicao = this.criarLista(objDtb);
                }
                return listaPesMetLicao;
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
        /// Função que Transmite o Metodo informada, para pesquisa
        /// </summary>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodoLicao> buscarMetodo(string CodMetodo)
        {
            try
            {
                objDAL = new DAL_pessoaMetodoLicao();
                objDtb = objDAL.buscarMetodo(CodMetodo);

                if (objDtb != null)
                {
                    listaPesMetLicao = this.criarLista(objDtb);
                }
                return listaPesMetLicao;
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
        /// Função que Transmite a Pessoa informada, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodoLicao> buscarPessoa(string CodPessoa)
        {
            try
            {
                objDAL = new DAL_pessoaMetodoLicao();
                objDtb = objDAL.buscarPessoa(CodPessoa);

                if (objDtb != null)
                {
                    listaPesMetLicao = this.criarLista(objDtb);
                }
                return listaPesMetLicao;
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
        /// Função que Transmite a Pessoa e o Metodo informada, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodMetodo"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodoLicao> buscarPessoaMetodo(string CodPessoa, string CodMetodo)
        {
            try
            {
                objDAL = new DAL_pessoaMetodoLicao();
                objDtb = objDAL.buscarPessoaMetodo(CodPessoa, CodMetodo);

                if (objDtb != null)
                {
                    listaPesMetLicao = this.criarLista(objDtb);
                }
                return listaPesMetLicao;
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
                objDAL = new DAL_pessoaMetodoLicao();
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
        private List<MOD_pessoaMetodoLicao> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoaMetodoLicao> lista = new List<MOD_pessoaMetodoLicao>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_pessoaMetodoLicao ent = new MOD_pessoaMetodoLicao();
                    //adiciona os campos às propriedades
                    ent.CodPesMetLicao = (string)(row.IsNull("CodPesMetLicao") ? Convert.ToString(null) : Convert.ToString(row["CodPesMetLicao"]).PadLeft(6, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : Convert.ToString(row["CodMetodo"]).PadLeft(3, '0'));
                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.Fase = (string)(row.IsNull("Fase") ? Convert.ToString(null) : Convert.ToString(row["Fase"]).PadLeft(3, '0'));
                    ent.Pagina = (string)(row.IsNull("Pagina") ? Convert.ToString(null) : Convert.ToString(row["Pagina"]).PadLeft(3, '0'));
                    ent.Licao = (string)(row.IsNull("Licao") ? Convert.ToString(null) : Convert.ToString(row["Licao"]).PadLeft(3, '0'));
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
        private MOD_log criarLog(MOD_pessoaMetodoLicao ent, string Operacao)
        {
            try
            {
                MOD_acessoPessoaMetodoLicao entAcesso = new MOD_acessoPessoaMetodoLicao();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotInsPesMetLicao);
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotEditPesMetLicao);
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.rotExcPesMetLicao);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodPesMetLicao + " > Pessoa: < " + ent.Nome + " > Método: < " + ent.DescMetodo + " > ";
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
