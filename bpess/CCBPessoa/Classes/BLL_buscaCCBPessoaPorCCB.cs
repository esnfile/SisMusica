using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;
using ENT.uteis;

namespace BLL.pessoa
{
    public class BLL_buscaCCBPessoaPorCCB : IBLL_buscaPessoaCCB
    {
        DataTable objDtb = null;
        List<MOD_pessoaCCB> lista = new List<MOD_pessoaCCB>();
        IDAL_buscaPessoaCCB objDAL = new DAL_buscaCCB();

        /// <summary>
        /// Função que Transmite a Pessoa informado, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_pessoaCCB> Buscar(string codPessoa)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa);

                if (objDtb != null)
                {
                    lista = new BLL_listaCCB().CriarLista(objDtb);
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
        /// Função que Transmite a Pessoa e a Comum informado, para pesquisa
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoaCCB> Buscar(string codPessoa, string codCCB)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa, codCCB);

                if (objDtb != null)
                {
                    lista = new BLL_listaCCB().CriarLista(objDtb);
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