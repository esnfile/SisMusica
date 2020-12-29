using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;

namespace BLL.pessoa
{
    public class BLL_buscaPessoaMetodoPorMetodos : IBLL_buscaPessoaMetodo
    {
        DataTable objDtb = null;
        List<MOD_pessoaMetodo> lista = new List<MOD_pessoaMetodo>();
        IDAL_buscaPessoaMetodo objDAL = new DAL_buscaMetodos();

        /// <summary>
        /// Função que Transmite a Pessoa informado, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodo> Buscar(string codPessoa)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa);

                if (objDtb != null)
                {
                    lista = new BLL_listaMetodos().CriarLista(objDtb);
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
        /// Função que Transmite a Pessoa e o Metodo informado, para pesquisa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codMetodo"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa, codMetodo);

                if (objDtb != null)
                {
                    lista = new BLL_listaMetodos().CriarLista(objDtb);
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
        /// Função que Transmite a Pessoa e o Metodo informado, para pesquisa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codMetodo"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo, string ativo)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa, codMetodo, ativo);

                if (objDtb != null)
                {
                    lista = new BLL_listaMetodos().CriarLista(objDtb);
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
        /// Função que Transmite a Pessoa, o Metodo e o Instruemnto informado, para pesquisa
        /// <para>Ativo = 'Sim' Or 'Não'</para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codMetodo"></param>
        /// <param name="ativo"></param>
        /// <param name="codInstrumento"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo, string ativo, string codInstrumento)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa, codMetodo, ativo, codInstrumento);

                if (objDtb != null)
                {
                    lista = new BLL_listaMetodos().CriarLista(objDtb);
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
        /// Função que Transmite a Pessoa, o Metodo e o Instruemnto informado, para pesquisa
        /// <para>Ativo = 'Sim' Or 'Não'</para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codMetodo"></param>
        /// <param name="ativo"></param>
        /// <param name="codInstrumento"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo, string ativo, string codInstrumento, string aplicarEm)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa, codMetodo, ativo, codInstrumento, aplicarEm);

                if (objDtb != null)
                {
                    lista = new BLL_listaMetodos().CriarLista(objDtb);
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
    }
}