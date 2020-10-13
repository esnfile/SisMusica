using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

using ENT.importa;
using DAL.importa;
using ENT.pessoa;
using BLL.pessoa;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;

namespace BLL.importa
{
    public class BLL_importaPessoa
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_importaPessoa objDAL = null;
        DAL_importaPessoaItem objDAL_Item = null;
        DAL_importaPessoaItemErro objDAL_ItemErro = null;
        DAL_log objDAL_Log = null;

        //variaveis que retornam os valores
        bool blnRetorno;
        bool blnRetornoItem;
        bool blnRetornoItemErro;
        bool blnRetornoPessoa;
        bool blnRetornoLog;

        DataTable objDtb = null;
        DataTable objDtb_Item = null;
        DataTable objDtb_ItemErro = null;

        List<MOD_importaPessoa> listaImporta = new List<MOD_importaPessoa>();
        List<MOD_importaPessoaItem> listaImportaItem = new List<MOD_importaPessoaItem>();
        List<MOD_importaPessoaItemErro> listaImportaItemErro = new List<MOD_importaPessoaItemErro>();
        List<MOD_importaPessoaItem> listaPessoaImportaItem = new List<MOD_importaPessoaItem>();
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        string NomeErro;
        string NomeSucesso;

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_importaPessoa objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;
                    blnRetornoPessoa = true;
                    blnRetornoItem = true;

                    #endregion

                    #region Movimentação da tabela ImportaPessoa e Logs

                    objDAL = new DAL_importaPessoa();
                    objDAL_Log = new DAL_log();

                    //Chama a função que converte as datas
                    objEnt = validaDadosImporta(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Update");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.salvar(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da Tabela ImportaPessoaItem e Pessoa

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.ListaPessoaItem != null && objEnt.ListaPessoaItem.Count > 0)
                    {
                        objDAL_Item = new DAL_importaPessoaItem();

                        listaImportaItem = objEnt.ListaPessoaItem;

                        //Chama a função que converte as datas
                        listaImportaItem = validaDadosItem(listaImportaItem);

                        foreach (MOD_importaPessoaItem ent in listaImportaItem)
                        {

                            #region Importa Pessoa

                            MOD_pessoa objEnt_Pessoa = new MOD_pessoa();
                            BLL_pessoa objBLL_Pessoa = new BLL_pessoa();

                            objEnt_Pessoa.DataCadastro = ent.DataCadastro;
                            objEnt_Pessoa.HoraCadastro = ent.HoraCadastro;
                            objEnt_Pessoa.CodCargo = ent.CodCargo;
                            objEnt_Pessoa.Nome = ent.Nome;
                            objEnt_Pessoa.DataNasc = ent.DataNasc;
                            objEnt_Pessoa.Cpf = ent.Cpf;
                            objEnt_Pessoa.Rg = ent.Rg;
                            objEnt_Pessoa.Sexo = ent.Sexo;
                            objEnt_Pessoa.DataBatismo = ent.DataBatismo;
                            objEnt_Pessoa.CodCidadeRes = ent.CodCidadeRes;
                            objEnt_Pessoa.EndRes = ent.EndRes;
                            objEnt_Pessoa.NumRes = ent.NumRes;
                            objEnt_Pessoa.BairroRes = ent.BairroRes;
                            objEnt_Pessoa.ComplRes = ent.ComplRes;
                            objEnt_Pessoa.Telefone1 = ent.Telefone1;
                            objEnt_Pessoa.Telefone2 = ent.Telefone2;
                            objEnt_Pessoa.Celular1 = ent.Celular1;
                            objEnt_Pessoa.Celular2 = ent.Celular2;
                            objEnt_Pessoa.Email = ent.Email;
                            objEnt_Pessoa.CodCCB = ent.CodCCB;
                            objEnt_Pessoa.EstadoCivil = ent.EstadoCivil;
                            objEnt_Pessoa.DataApresentacao = ent.DataApresentacao;
                            objEnt_Pessoa.PaisCCB = ent.PaisCCB;
                            objEnt_Pessoa.Pai = ent.Pai;
                            objEnt_Pessoa.Mae = ent.Mae;
                            objEnt_Pessoa.FormacaoFora = ent.FormacaoFora;
                            objEnt_Pessoa.LocalFormacao = ent.LocalFormacao;
                            objEnt_Pessoa.QualFormacao = ent.QualFormacao;
                            objEnt_Pessoa.OutraOrquestra = ent.OutraOrquestra;
                            objEnt_Pessoa.Orquestra1 = ent.Orquestra1;
                            objEnt_Pessoa.Funcao1 = ent.Funcao1;
                            objEnt_Pessoa.Orquestra2 = ent.Orquestra2;
                            objEnt_Pessoa.Funcao2 = ent.Funcao2;
                            objEnt_Pessoa.Orquestra3 = ent.Orquestra3;
                            objEnt_Pessoa.Funcao3 = ent.Funcao3;
                            objEnt_Pessoa.CodInstrumento = ent.CodInstrumento;
                            objEnt_Pessoa.Desenvolvimento = ent.Desenvolvimento;
                            objEnt_Pessoa.DataUltimoTeste = ent.DataUltimoTeste;
                            objEnt_Pessoa.DataInicioEstudo = ent.DataInicioEstudo;
                            objEnt_Pessoa.ExecutInstrumento = ent.ExecutInstrumento;
                            objEnt_Pessoa.OrgaoEmissor = ent.OrgaoEmissor;

                            blnRetornoPessoa = objBLL_Pessoa.importar(objEnt_Pessoa);

                            if (blnRetornoPessoa.Equals(false))
                            {
                                ent.Importado = "Não";
                            }
                            else
                            {
                                ent.Importado = "Sim";
                                ent.CodPessoa = modulos.CodPessoaImportacao;
                            }

                            #endregion
                            
                            #region Importa Item

                            ent.CodImportaPessoa = objEnt.CodImportaPessoa;
                            blnRetornoItem = objDAL_Item.salvar(ent);

                            if (blnRetornoItem.Equals(false))
                            {
                                break;
                            }

                            #endregion

                        }
                    }

                    #endregion

                    #region Movimentação da Tabela ImportaPessoaItemErros

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.ListaPessoaItemErros != null && objEnt.ListaPessoaItemErros.Count > 0)
                    {
                        objDAL_ItemErro = new DAL_importaPessoaItemErro();

                        listaImportaItemErro = objEnt.ListaPessoaItemErros;

                        //Chama a função que converte as datas
                        listaImportaItemErro = validaDadosItemErro(listaImportaItemErro);

                        foreach (MOD_importaPessoaItemErro ent in listaImportaItemErro)
                        {
                            ent.CodImportaPessoa = objEnt.CodImportaPessoa;
                            blnRetornoItemErro = objDAL_ItemErro.salvar(ent);

                            if (blnRetornoItemErro.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoItem.Equals(false) || blnRetornoItemErro.Equals(false) || blnRetornoLog.Equals(false))
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
        public bool inserir(MOD_importaPessoa objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetorno = true;
                    blnRetornoLog = true;
                    blnRetornoPessoa = true;
                    blnRetornoItem = true;
                    blnRetornoItemErro = true;

                    #endregion

                    #region Movimentação da tabela ImportaPessoa e Logs

                    objDAL = new DAL_importaPessoa();
                    objDAL_Log = new DAL_log();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodImportaPessoa = Convert.ToString(retornaId());

                    //Chama a função que converte as datas
                    objEnt = validaDadosImporta(objEnt);
                    objEnt.Logs = criarLog(objEnt, "Insert");
                    objEnt.Logs = validaDadosLog(objEnt.Logs);

                    blnRetorno = objDAL.inserir(objEnt);
                    blnRetornoLog = objDAL_Log.inserir(objEnt.Logs);

                    #endregion

                    #region Movimentação da Tabela ImportaPessoaItem e Pessoa

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.ListaPessoaItem != null && objEnt.ListaPessoaItem.Count > 0)
                    {

                        listaImportaItem = objEnt.ListaPessoaItem;

                        //Chama a função que converte as datas
                        listaImportaItem = validaDadosItem(listaImportaItem);

                        foreach (MOD_importaPessoaItem ent in listaImportaItem)
                        {

                            NomeSucesso = ent.Nome;

                            #region Importa Pessoa

                            MOD_pessoa objEnt_Pessoa = new MOD_pessoa();
                            BLL_pessoa objBLL_Pessoa = new BLL_pessoa();

                            objEnt_Pessoa.Ativo = "Sim";
                            objEnt_Pessoa.DataCadastro = ent.DataCadastro;
                            objEnt_Pessoa.HoraCadastro = ent.HoraCadastro;
                            objEnt_Pessoa.CodCargo = ent.CodCargo;
                            objEnt_Pessoa.Nome = ent.Nome;
                            objEnt_Pessoa.DataNasc = ent.DataNasc;
                            objEnt_Pessoa.Cpf = ent.Cpf;
                            objEnt_Pessoa.Rg = ent.Rg;
                            objEnt_Pessoa.Sexo = ent.Sexo;
                            objEnt_Pessoa.DataBatismo = ent.DataBatismo;
                            objEnt_Pessoa.CodCidadeRes = ent.CodCidadeRes;
                            objEnt_Pessoa.EndRes = ent.EndRes;
                            objEnt_Pessoa.NumRes = ent.NumRes;
                            objEnt_Pessoa.BairroRes = ent.BairroRes;
                            objEnt_Pessoa.ComplRes = ent.ComplRes;
                            objEnt_Pessoa.Telefone1 = ent.Telefone1;
                            objEnt_Pessoa.Telefone2 = ent.Telefone2;
                            objEnt_Pessoa.Celular1 = ent.Celular1;
                            objEnt_Pessoa.Celular2 = ent.Celular2;
                            objEnt_Pessoa.Email = ent.Email;
                            objEnt_Pessoa.CodCCB = ent.CodCCB;
                            objEnt_Pessoa.EstadoCivil = ent.EstadoCivil;
                            objEnt_Pessoa.DataApresentacao = ent.DataApresentacao;
                            objEnt_Pessoa.PaisCCB = ent.PaisCCB;
                            objEnt_Pessoa.Pai = ent.Pai;
                            objEnt_Pessoa.Mae = ent.Mae;
                            objEnt_Pessoa.FormacaoFora = ent.FormacaoFora;
                            objEnt_Pessoa.LocalFormacao = ent.LocalFormacao;
                            objEnt_Pessoa.QualFormacao = ent.QualFormacao;
                            objEnt_Pessoa.OutraOrquestra = ent.OutraOrquestra;
                            objEnt_Pessoa.Orquestra1 = ent.Orquestra1;
                            objEnt_Pessoa.Funcao1 = ent.Funcao1;
                            objEnt_Pessoa.Orquestra2 = ent.Orquestra2;
                            objEnt_Pessoa.Funcao2 = ent.Funcao2;
                            objEnt_Pessoa.Orquestra3 = ent.Orquestra3;
                            objEnt_Pessoa.Funcao3 = ent.Funcao3;
                            objEnt_Pessoa.CodInstrumento = ent.CodInstrumento;
                            objEnt_Pessoa.Desenvolvimento = ent.Desenvolvimento;
                            objEnt_Pessoa.DataUltimoTeste = ent.DataUltimoTeste;
                            objEnt_Pessoa.DataInicioEstudo = ent.DataInicioEstudo;
                            objEnt_Pessoa.ExecutInstrumento = ent.ExecutInstrumento;
                            objEnt_Pessoa.OrgaoEmissor = ent.OrgaoEmissor;

                            blnRetornoPessoa = objBLL_Pessoa.importar(objEnt_Pessoa);

                            if (blnRetornoPessoa.Equals(false))
                            {
                                ent.Importado = "Não";
                            }
                            else
                            {
                                ent.Importado = "Sim";
                                ent.CodPessoa = modulos.CodPessoaImportacao;
                            }

                            #endregion

                            #region Importa Item

                            objDAL_Item = new DAL_importaPessoaItem();

                            ent.CodImportaPessoa = objEnt.CodImportaPessoa;
                            blnRetornoItem = objDAL_Item.salvar(ent);

                            if (blnRetornoItem.Equals(false))
                            {
                                break;
                            }

                            #endregion

                        }
                    }

                    #endregion

                    #region Movimentação da Tabela ImportaPessoaItemErros

                    //verifica se há registro na lista produtos para fazer atualização
                    if (objEnt.ListaPessoaItemErros != null && objEnt.ListaPessoaItemErros.Count > 0)
                    {

                        listaImportaItemErro = objEnt.ListaPessoaItemErros;

                        //Chama a função que converte as datas
                        listaImportaItemErro = validaDadosItemErro(listaImportaItemErro);

                        foreach (MOD_importaPessoaItemErro ent in listaImportaItemErro)
                        {
                            NomeErro = ent.Nome;

                            objDAL_ItemErro = new DAL_importaPessoaItemErro();

                            ent.CodImportaPessoa = objEnt.CodImportaPessoa;
                            blnRetornoItemErro = objDAL_ItemErro.salvar(ent);

                            if (blnRetornoItemErro.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetorno.Equals(false) || blnRetornoItem.Equals(false) || blnRetornoItemErro.Equals(false) || blnRetornoLog.Equals(false))
                    {
                        //finaliza a transação
                        objTrans.Dispose();
                        throw new Exception(" Nome que gerou Erro: Sucesso - " + NomeSucesso + "   Erro - " + NomeErro);
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
                    throw new Exception("Erro SQL na BLL importaPessoa - Descrição: " + exl.Message);
                }
                catch (Exception ex)
                {
                    //finaliza a transação
                    objTrans.Dispose();
                    throw new Exception("Erro na BLL importaPessoa - Descrição: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer DELETE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_importaPessoa objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    this.blnRetorno = true;
                    this.blnRetornoLog = true;

                    #endregion

                    #region Movimentação da tabela ImportaPessoa e Logs

                    this.objDAL = new DAL_importaPessoa();
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

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer INSERT
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserirItemSucesso(List<MOD_importaPessoaItem> listaItem, List<MOD_importaPessoaItemErro> listaErro)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {

                    #region Inicialização das variaveis

                    blnRetornoItem = true;
                    blnRetornoItemErro = true;

                    #endregion

                    #region Movimentação da Tabela ImportaPessoaItem

                    //verifica se há registro na lista produtos para fazer atualização
                    if (listaItem != null && listaItem.Count > 0)
                    {
                        objDAL_Item = new DAL_importaPessoaItem();

                        listaImportaItem = listaItem;

                        //Chama a função que converte as datas
                        listaImportaItem = validaDadosItem(listaImportaItem);

                        foreach (MOD_importaPessoaItem ent in listaImportaItem)
                        {
                            ent.CodImportaPessoa = ent.CodImportaPessoa;
                            blnRetornoItem = objDAL_Item.salvar(ent);

                            if (blnRetornoItem.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    #region Movimentação da Tabela ImportaPessoaItemErros

                    //verifica se há registro na lista produtos para fazer atualização
                    if (listaErro != null && listaErro.Count > 0)
                    {
                        objDAL_ItemErro = new DAL_importaPessoaItemErro();

                        listaImportaItemErro = listaErro;

                        //Chama a função que converte as datas
                        listaImportaItemErro = validaDadosItemErro(listaImportaItemErro);

                        foreach (MOD_importaPessoaItemErro ent in listaImportaItemErro)
                        {
                            ent.CodImportaPessoa = ent.CodImportaPessoa;
                            blnRetornoItemErro = objDAL_ItemErro.excluir(ent);

                            if (blnRetornoItemErro.Equals(false))
                            {
                                break;
                            }
                        }
                    }

                    #endregion

                    //Se der falso qualquer retorno a Transação deve ser Anulada
                    if (blnRetornoItem.Equals(false) || blnRetornoItemErro.Equals(false))
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

        #endregion

        #region Funções que transmite os Critério para a DAL realizar a Busca no Banco

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <returns></returns>
        public List<MOD_importaPessoa> buscarCod(string CodImportaPessoa)
        {
            try
            {
                objDAL = new DAL_importaPessoa();
                objDtb = objDAL.buscarCod(CodImportaPessoa);

                if (objDtb != null)
                {
                    listaImporta = this.criarLista(objDtb);
                }
                return listaImporta;
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
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <returns></returns>
        public List<MOD_importaPessoa> buscarDataImporta(string DataInicial, string DataFinal)
        {
            try
            {
                objDAL = new DAL_importaPessoa();
                objDtb = objDAL.buscarDataImporta(funcoes.DataInt(DataInicial), funcoes.DataInt(DataFinal));

                if (objDtb != null)
                {
                    listaImporta = this.criarLista(objDtb);
                }
                return listaImporta;
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

        #region ImportaPessoaItem

        /// <summary>
        /// Função que Transmite a Importação informada, para pesquisa na
        /// Tabela ImportaPessoaItem
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <returns></returns>       
        public List<MOD_importaPessoaItem> buscarImportaItem(string CodImportaPessoa)
        {
            try
            {
                objDAL_Item = new DAL_importaPessoaItem();
                objDtb_Item = objDAL_Item.buscarCod(CodImportaPessoa);

                if (objDtb_Item != null)
                {
                    listaImportaItem = this.criarListaImportaItem(objDtb_Item);
                }
                return listaImportaItem;
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
        /// Função que Transmite a Importação informada, para pesquisa na
        /// Tabela ImportaPessoaItemErro
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <returns></returns>       
        public List<MOD_importaPessoaItemErro> buscarImportaItemErro(string CodImportaPessoa)
        {
            try
            {
                objDAL_ItemErro = new DAL_importaPessoaItemErro();
                objDtb_ItemErro = objDAL_ItemErro.buscarCod(CodImportaPessoa);

                if (objDtb_ItemErro != null)
                {
                    listaImportaItemErro = this.criarListaImportaItemErro(objDtb_ItemErro);
                }
                return listaImportaItemErro;
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
        /// Função que Transmite a Importação informada, para pesquisa na
        /// Tabela ImportaPessoaItemErro
        /// </summary>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>       
        public List<MOD_importaPessoaItemErro> buscarImpErro(string CodCCBUsu)
        {
            try
            {
                objDAL_ItemErro = new DAL_importaPessoaItemErro();
                objDtb_ItemErro = objDAL_ItemErro.buscarImpErro(CodCCBUsu);

                if (objDtb_ItemErro != null)
                {
                    listaImportaItemErro = this.criarListaImportaItemErro(objDtb_ItemErro);
                }
                return listaImportaItemErro;
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
        /// Função que Transmite a Importação informada, para pesquisa na
        /// Tabela ImportaPessoaItemErro
        /// </summary>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>       
        public List<MOD_importaPessoaItemErro> buscarImpErro(string CodImportaPessoa, string CodCCBUsu)
        {
            try
            {
                objDAL_ItemErro = new DAL_importaPessoaItemErro();
                objDtb_ItemErro = objDAL_ItemErro.buscarImpErro(CodImportaPessoa, CodCCBUsu);

                if (objDtb_ItemErro != null)
                {
                    listaImportaItemErro = this.criarListaImportaItemErro(objDtb_ItemErro);
                }
                return listaImportaItemErro;
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
        /// Função que Transmite a Importação informada, para pesquisa na
        /// Tabela ImportaPessoaItemErro
        /// </summary>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>       
        public List<MOD_importaPessoaItemErro> buscarImpErro(string CodImportaPessoa, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                objDAL_ItemErro = new DAL_importaPessoaItemErro();
                objDtb_ItemErro = objDAL_ItemErro.buscarImpErro(CodImportaPessoa, CodCCBUsu, CodCargoUsu);

                if (objDtb_ItemErro != null)
                {
                    listaImportaItemErro = this.criarListaImportaItemErro(objDtb_ItemErro);
                }
                return listaImportaItemErro;
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
                objDAL = new DAL_importaPessoa();
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
        private List<MOD_importaPessoa> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoa> lista = new List<MOD_importaPessoa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_importaPessoa ent = new MOD_importaPessoa();
                    //adiciona os campos às propriedades
                    ent.CodImportaPessoa = (string)(row.IsNull("CodImportaPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoa"]).PadLeft(6, '0'));
                    ent.DataImporta = (string)(row.IsNull("DataImporta") ? Convert.ToString(null) : funcoes.IntData(row["DataImporta"].ToString()));
                    ent.HoraImporta = (string)(row.IsNull("HoraImporta") ? Convert.ToString(null) : funcoes.IntHora(row["HoraImporta"].ToString()));
                    ent.CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0'));
                    ent.Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]);
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.QtdeArquivo = (string)(row.IsNull("QtdeArquivo") ? Convert.ToString(null) : Convert.ToString(row["QtdeArquivo"]));
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);

                    //ent.ListaPessoaItem = buscarImportaItem(ent.CodImportaPessoa);
                    //ent.ListaPessoaItemErros = buscarImportaItemErro(ent.CodImportaPessoa);

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
        private List<MOD_importaPessoaItem> criarListaImportaItem(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoaItem> lista = new List<MOD_importaPessoaItem>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_importaPessoaItem ent = new MOD_importaPessoaItem();
                    //adiciona os campos às propriedades
                    ent.CodImportaPessoaItem = (string)(row.IsNull("CodImportaPessoaItem") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoaItem"]).PadLeft(6, '0'));
                    ent.CodImportaPessoa = (string)(row.IsNull("CodImportaPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoa"]).PadLeft(6, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Importado = (string)(row.IsNull("Importado") ? null : row["Importado"]);
                    ent.DataCadastro = (string)(row.IsNull("DataCadastro") ? Convert.ToString(null) : funcoes.IntData(row["DataCadastro"].ToString()));
                    ent.HoraCadastro = (string)(row.IsNull("HoraCadastro") ? Convert.ToString(null) : funcoes.IntHora(row["HoraCadastro"].ToString()));
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.OrdemCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.CodDepartamento = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescDepartamento = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.DataNasc = (string)(row.IsNull("DataNasc") ? Convert.ToString(null) : funcoes.IntData(row["DataNasc"].ToString()));
                    ent.Cpf = (string)(row.IsNull("Cpf") ? null : row["Cpf"]);
                    ent.Rg = (string)(row.IsNull("Rg") ? null : row["Rg"]);
                    ent.OrgaoEmissor = (string)(row.IsNull("OrgaoEmissor") ? null : row["OrgaoEmissor"]);
                    ent.Sexo = (string)(row.IsNull("Sexo") ? null : row["Sexo"]);
                    ent.DataBatismo = (string)(row.IsNull("DataBatismo") ? Convert.ToString(null) : funcoes.IntData(row["DataBatismo"].ToString()));
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
                    ent.EndCCB = (string)(row.IsNull("EndCCB") ? null : row["EndCCB"]);
                    ent.NumCCB = (string)(row.IsNull("NumCCB") ? null : row["NumCCB"]);
                    ent.BairroCCB = (string)(row.IsNull("BairroCCB") ? null : row["BairroCCB"]);
                    ent.ComplCCB = (string)(row.IsNull("ComplCCB") ? null : row["ComplCCB"]);
                    ent.CidadeCCB = (string)(row.IsNull("CidadeCCB") ? null : row["CidadeCCB"]);
                    ent.EstadoCCB = (string)(row.IsNull("EstadoCCB") ? null : row["EstadoCCB"]);
                    ent.CepCCB = (string)(row.IsNull("CepCCB") ? null : funcoes.FormataString("#####-###", row["CepCCB"].ToString()));
                    ent.TelefoneCCB = (string)(row.IsNull("TelefoneCCB") ? null : row["TelefoneCCB"]);
                    ent.CelularCCB = (string)(row.IsNull("CelularCCB") ? null : row["CelularCCB"]);
                    ent.EmailCCB = (string)(row.IsNull("EmailCCB") ? null : row["EmailCCB"]);
                    ent.EstadoCivil = (string)(row.IsNull("EstadoCivil") ? null : row["EstadoCivil"]);
                    ent.DataApresentacao = (string)(row.IsNull("DataApresentacao") ? Convert.ToString(null) : funcoes.IntData(row["DataApresentacao"].ToString()));
                    ent.PaisCCB = (string)(row.IsNull("PaisCCB") ? null : row["PaisCCB"]);
                    ent.Pai = (string)(row.IsNull("Pai") ? null : row["Pai"]);
                    ent.Mae = (string)(row.IsNull("Mae") ? null : row["Mae"]);
                    ent.FormacaoFora = (string)(row.IsNull("FormacaoFora") ? null : row["FormacaoFora"]);
                    ent.LocalFormacao = (string)(row.IsNull("LocalFormacao") ? null : row["LocalFormacao"]);
                    ent.QualFormacao = (string)(row.IsNull("QualFormacao") ? null : row["QualFormacao"]);
                    ent.OutraOrquestra = (string)(row.IsNull("OutraOrquestra") ? null : row["OutraOrquestra"]);
                    ent.Orquestra1 = (string)(row.IsNull("Orquestra1") ? null : row["Orquestra1"]);
                    ent.Funcao1 = (string)(row.IsNull("Funcao1") ? null : row["Funcao1"]);
                    ent.Orquestra2 = (string)(row.IsNull("Orquestra2") ? null : row["Orquestra2"]);
                    ent.Funcao2 = (string)(row.IsNull("Funcao2") ? null : row["Funcao2"]);
                    ent.Orquestra3 = (string)(row.IsNull("Orquestra3") ? null : row["Orquestra3"]);
                    ent.Funcao3 = (string)(row.IsNull("Funcao3") ? null : row["Funcao3"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.Desenvolvimento = (string)(row.IsNull("Desenvolvimento") ? null : row["Desenvolvimento"]);
                    ent.DataUltimoTeste = (string)(row.IsNull("DataUltimoTeste") ? Convert.ToString(null) : funcoes.IntData(row["DataUltimoTeste"].ToString()));
                    ent.DataInicioEstudo = (string)(row.IsNull("DataInicioEstudo") ? Convert.ToString(null) : funcoes.IntData(row["DataInicioEstudo"].ToString()));
                    ent.ExecutInstrumento = (string)(row.IsNull("ExecutInstrumento") ? null : row["ExecutInstrumento"]);
                    ent.Sequencia = Convert.ToString(lista.Count + 1).PadLeft(5, '0');
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
        private List<MOD_importaPessoaItemErro> criarListaImportaItemErro(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoaItemErro> lista = new List<MOD_importaPessoaItemErro>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_importaPessoaItemErro ent = new MOD_importaPessoaItemErro();
                    //adiciona os campos às propriedades
                    ent.CodImportaPessoaItem = (string)(row.IsNull("CodImportaPessoaItem") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoaItem"]).PadLeft(6, '0'));
                    ent.CodImportaPessoa = (string)(row.IsNull("CodImportaPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoa"]).PadLeft(6, '0'));
                    ent.DataCadastro = (string)(row.IsNull("DataCadastro") ? Convert.ToString(null) : funcoes.IntData(row["DataCadastro"].ToString()));
                    ent.HoraCadastro = (string)(row.IsNull("HoraCadastro") ? Convert.ToString(null) : funcoes.IntHora(row["HoraCadastro"].ToString()));
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.DataNasc = (string)(row.IsNull("DataNasc") ? Convert.ToString(null) : funcoes.IntData(row["DataNasc"].ToString()));
                    ent.Cpf = (string)(row.IsNull("Cpf") ? null : row["Cpf"]);
                    ent.Rg = (string)(row.IsNull("Rg") ? null : row["Rg"]);
                    ent.OrgaoEmissor = (string)(row.IsNull("OrgaoEmissor") ? null : row["OrgaoEmissor"]);
                    ent.Sexo = (string)(row.IsNull("Sexo") ? null : row["Sexo"]);
                    ent.DataBatismo = (string)(row.IsNull("DataBatismo") ? Convert.ToString(null) : funcoes.IntData(row["DataBatismo"].ToString()));
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
                    ent.DescCCB = (string)(row.IsNull("DescCCB") ? null : row["DescCCB"]);
                    ent.EstadoCivil = (string)(row.IsNull("EstadoCivil") ? null : row["EstadoCivil"]);
                    ent.DataApresentacao = (string)(row.IsNull("DataApresentacao") ? Convert.ToString(null) : funcoes.IntData(row["DataApresentacao"].ToString()));
                    ent.Pai = (string)(row.IsNull("Pai") ? null : row["Pai"]);
                    ent.Mae = (string)(row.IsNull("Mae") ? null : row["Mae"]);
                    ent.FormacaoFora = (string)(row.IsNull("FormacaoFora") ? null : row["FormacaoFora"]);
                    ent.LocalFormacao = (string)(row.IsNull("LocalFormacao") ? null : row["LocalFormacao"]);
                    ent.QualFormacao = (string)(row.IsNull("QualFormacao") ? null : row["QualFormacao"]);
                    ent.OutraOrquestra = (string)(row.IsNull("OutraOrquestra") ? null : row["OutraOrquestra"]);
                    ent.Orquestra1 = (string)(row.IsNull("Orquestra1") ? null : row["Orquestra1"]);
                    ent.Funcao1 = (string)(row.IsNull("Funcao1") ? null : row["Funcao1"]);
                    ent.Orquestra2 = (string)(row.IsNull("Orquestra2") ? null : row["Orquestra2"]);
                    ent.Funcao2 = (string)(row.IsNull("Funcao2") ? null : row["Funcao2"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.Desenvolvimento = (string)(row.IsNull("Desenvolvimento") ? null : row["Desenvolvimento"]);
                    ent.DataUltimoTeste = (string)(row.IsNull("DataUltimoTeste") ? Convert.ToString(null) : funcoes.IntData(row["DataUltimoTeste"].ToString()));
                    ent.DataInicioEstudo = (string)(row.IsNull("DataInicioEstudo") ? Convert.ToString(null) : funcoes.IntData(row["DataInicioEstudo"].ToString()));
                    ent.ExecutInstrumento = (string)(row.IsNull("ExecutInstrumento") ? null : row["ExecutInstrumento"]);
                    ent.CodCCBGem = (string)(row.IsNull("CodCCBGem") ? Convert.ToString(null) : Convert.ToString(row["CodCCBGem"]).PadLeft(6, '0'));
                    ent.DescCCBGem = (string)(row.IsNull("DescCCBGem") ? null : row["DescCCBGem"]);
                    ent.Sequencia = Convert.ToString(lista.Count + 1).PadLeft(5, '0');

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
        private MOD_importaPessoa validaDadosImporta(MOD_importaPessoa ent)
        {
            try
            {
                ent.DataImporta  = string.IsNullOrEmpty(ent.DataImporta) ? null : funcoes.DataInt(ent.DataImporta);
                ent.HoraImporta = string.IsNullOrEmpty(ent.HoraImporta) ? null : funcoes.HoraInt(ent.HoraImporta);
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
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private List<MOD_importaPessoaItem> validaDadosItem(List<MOD_importaPessoaItem> lista)
        {
            try
            {
                foreach (MOD_importaPessoaItem ent in lista)
                {
                    ent.DataCadastro = string.IsNullOrEmpty(ent.DataCadastro) ? null : funcoes.DataInt(ent.DataCadastro);
                    ent.HoraCadastro = string.IsNullOrEmpty(ent.HoraCadastro) ? null : funcoes.HoraInt(ent.HoraCadastro);
                    ent.Cpf = string.IsNullOrEmpty(ent.Cpf) ? null : funcoes.FormataCpf(ent.Cpf);
                    ent.DataNasc = string.IsNullOrEmpty(ent.DataNasc) ? null : funcoes.DataInt(ent.DataNasc);
                    ent.DataBatismo = string.IsNullOrEmpty(ent.DataBatismo) ? null : funcoes.DataInt(ent.DataBatismo);
                    ent.DataApresentacao = string.IsNullOrEmpty(ent.DataApresentacao) ? null : funcoes.DataInt(ent.DataApresentacao);
                    ent.DataUltimoTeste = string.IsNullOrEmpty(ent.DataUltimoTeste) ? null : funcoes.DataInt(ent.DataUltimoTeste);
                    ent.DataInicioEstudo = string.IsNullOrEmpty(ent.DataInicioEstudo) ? null : funcoes.DataInt(ent.DataInicioEstudo);
                }
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
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        private List<MOD_importaPessoaItemErro> validaDadosItemErro(List<MOD_importaPessoaItemErro> lista)
        {
            try
            {
                foreach (MOD_importaPessoaItemErro ent in lista)
                {
                    ent.DataCadastro = string.IsNullOrEmpty(ent.DataCadastro) ? null : funcoes.DataInt(ent.DataCadastro);
                    ent.HoraCadastro = string.IsNullOrEmpty(ent.HoraCadastro) ? null : funcoes.HoraInt(ent.HoraCadastro);
                    //ent.Cpf = string.IsNullOrEmpty(ent.Cpf) ? null : funcoes.FormataCpf(ent.Cpf);
                    ent.DataNasc = string.IsNullOrEmpty(ent.DataNasc) ? null : funcoes.DataInt(ent.DataNasc);
                    ent.DataBatismo = string.IsNullOrEmpty(ent.DataBatismo) ? null : funcoes.DataInt(ent.DataBatismo);
                    ent.DataApresentacao = string.IsNullOrEmpty(ent.DataApresentacao) ? null : funcoes.DataInt(ent.DataApresentacao);
                    ent.DataUltimoTeste = string.IsNullOrEmpty(ent.DataUltimoTeste) ? null : funcoes.DataInt(ent.DataUltimoTeste);
                    ent.DataInicioEstudo = string.IsNullOrEmpty(ent.DataInicioEstudo) ? null : funcoes.DataInt(ent.DataInicioEstudo);
                }
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
        private MOD_log criarLog(MOD_importaPessoa ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotInsImportaPessoa);
                }
                    else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(modulos.rotEditImportaPessoa);
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.Ocorrencia = "Código: < " + ent.CodImportaPessoa.PadLeft(6, '0') + " > Usuario: < " + ent.CodUsuario.PadLeft(6, '0') + " - " + ent.Usuario + " > ";
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