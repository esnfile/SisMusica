using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;
using ENT.instrumentos;

namespace BLL.pessoa
{
    public class BLL_buscaPessoaInstrPorInstrumento : IBLL_buscaPessoaInstr
    {
        DataTable objDtb = null;
        List<MOD_pessoaInstr> lista = new List<MOD_pessoaInstr>();
        IDAL_buscaPessoaInstr objDAL = new DAL_buscaInstrumentos();

        /// <summary>
        /// Função que Transmite a Pessoa informado, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_pessoaInstr> Buscar(string codPessoa)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa);

                if (objDtb != null)
                {
                    lista = new BLL_listaInstrumentos().CriarLista(objDtb);
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
        /// Função que Transmite a Pessoa e o Instruemnto informado, para pesquisa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codInstrumento"></param>
        /// <returns></returns>
        public List<MOD_pessoaInstr> Buscar(string codPessoa, string codInstrumento)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa, codInstrumento);

                if (objDtb != null)
                {
                    lista = new BLL_listaInstrumentos().CriarLista(objDtb);
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
        /// Função que Transmite a Pessoa e o Instruemnto informado, para pesquisa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codInstrumento"></param>
        /// <param name="situacao"></param>
        /// <returns></returns>
        public List<MOD_pessoaInstr> Buscar(string codPessoa, string codInstrumento, string situacao)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa, codInstrumento, situacao);

                if (objDtb != null)
                {
                    lista = new BLL_listaInstrumentos().CriarLista(objDtb);
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