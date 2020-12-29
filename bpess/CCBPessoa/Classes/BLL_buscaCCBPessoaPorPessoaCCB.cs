using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.ComponentModel;

using ENT.pessoa;
using DAL.pessoa;
using DAL.uteis;
using ENT.uteis;
using DAL.log;
using ENT.Log;
using BLL.Funcoes;
using ENT.instrumentos;

namespace BLL.pessoa
{
    public class BLL_buscaCCBPessoaPorPessoaCCB : IBLL_buscaPessoaCCB
    {
        DataTable objDtb = null;
        List<MOD_pessoaCCB> lista = new List<MOD_pessoaCCB>();
        IDAL_buscaPessoaCCB objDAL = new DAL_buscaPessoaCCB();

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
                    lista = new BLL_listaPessoaCCB().CriarLista(objDtb);
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
                    lista = new BLL_listaPessoaCCB().CriarLista(objDtb);
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