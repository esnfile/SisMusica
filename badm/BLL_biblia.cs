using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Transactions;

using BLL.Funcoes;
using DAL.administracao;
using ENT.Erros;
using ENT.Log;
using DAL.log;
using ENT.pessoa;
using ENT.administracao;

namespace BLL.administracao
{
    public class BLL_biblia
    {

        #region declarações

        /// <summary>
        /// Variavel que Instancia a Camada de Dados
        /// </summary>
        DAL_biblia objDAL = null;

        //variaveis que retornam os valores
        bool blnRetorno;

        DataTable objDtb = null;

        List<MOD_biblia> listaBiblia = new List<MOD_biblia>();

        #endregion

        #region Faz a Validação e transmite os dados para a DAL

        /// <summary>
        /// Função que Transmite a Entidade para a DAL fazer UPDATE
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_biblia objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;

                    #endregion
                                                           
                    #region Movimentação da tabela Biblia e Logs

                    objDAL = new DAL_biblia();
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
        public bool inserir(MOD_biblia objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Biblia e Logs

                    objDAL = new DAL_biblia();

                    //Chama a função que busca o próximo numero na tabela
                    objEnt.CodBiblia = Convert.ToString(retornaId());
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
        public bool excluir(MOD_biblia objEnt)
        {
            using (TransactionScope objTrans = new TransactionScope())
            {
                try
                {
                    #region Inicialização das variaveis

                    blnRetorno = true;

                    #endregion

                    #region Movimentação da tabela Biblia e Logs

                    objDAL = new DAL_biblia();
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

        #region Busca os Valores da Tabela Biblia

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodBiblia"></param>
        /// <returns></returns>
        public List<MOD_biblia> buscarCod(string CodBiblia)
        {
            try
            {
                objDAL = new DAL_biblia();
                objDtb = objDAL.buscarCod(CodBiblia);

                if (objDtb != null)
                {
                    listaBiblia = this.criarLista(objDtb);
                }
                return listaBiblia;
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
        /// <param name="DescLivro"></param>
        /// <returns></returns>
        public List<MOD_biblia> buscarDescricao(string DescLivro)
        {
            try
            {
                objDAL = new DAL_biblia();
                objDtb = objDAL.buscarDescricao("%" + DescLivro + "%");

                if (objDtb != null)
                {
                    listaBiblia = criarLista(objDtb);
                }
                return listaBiblia;
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
                objDAL = new DAL_biblia();
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
        private List<MOD_biblia> criarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_biblia> lista = new List<MOD_biblia>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_biblia ent = new MOD_biblia();
                    //adiciona os campos às propriedades
                    ent.CodBiblia = (string)(row.IsNull("CodBiblia") ? Convert.ToString(null) : Convert.ToString(row["CodBiblia"]).PadLeft(2, '0'));
                    ent.DescLivro = (string)(row.IsNull("DescLivro") ? null : row["DescLivro"]);
                    ent.QtdeCapitulos = (string)(row.IsNull("QtdeCapitulos") ? Convert.ToString(null) : Convert.ToString(row["QtdeCapitulos"]).PadLeft(3, '0'));

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

        #endregion

        #region Validação dos dados

        ///// <summary>
        ///// Função que valida os campos
        ///// </summary>
        //private bool ValidarControles(MOD_biblia ent)
        //{
        //    try
        //    {
        //        //inicia a variavel blnValida
        //        MOD_erros objEnt_Erros = null;
        //        bool blnValida = true;
        //        bool blnRetorno = true;

        //        //inicia uma nova lista de erros
        //        List<MOD_erros> listaErros = new List<MOD_erros>();
        //        if (string.IsNullOrEmpty(ent.DescLivro))
        //        {
        //            blnValida = false;
        //            objEnt_Erros = new MOD_erros();
        //            objEnt_Erros.Texto = "Livro! Campo obrigatório.";
        //            objEnt_Erros.Grau = "Alto";
        //            listaErros.Add(objEnt_Erros);
        //        }
        //        if (string.IsNullOrEmpty(ent.QtdeCapitulos))
        //        {
        //            blnValida = false;
        //            objEnt_Erros = new MOD_erros();
        //            objEnt_Erros.Texto = "Qtde de Capítulos! Campo obrigatório.";
        //            objEnt_Erros.Grau = "Alto";
        //            listaErros.Add(objEnt_Erros);
        //        }

        //        //chama o formulário para gerar os erros
        //        if (blnValida.Equals(false))
        //        {
        //            blnRetorno = apoio.AbrirErros(listaErros, this);
        //        }
        //        //return blnRetorno;
        //    }
        //    catch (SqlException exl)
        //    {
        //        throw exl;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        #endregion
    }
}