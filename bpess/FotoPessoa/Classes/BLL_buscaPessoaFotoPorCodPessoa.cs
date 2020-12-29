using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;

namespace BLL.pessoa
{
    public class BLL_buscaPessoaFotoPorCodPessoa : IBLL_buscaPessoaFoto
    {
        DataTable objDtb = null;
        List<MOD_pessoaFoto> lista = new List<MOD_pessoaFoto>();
        IDAL_buscaPessoaFoto objDAL = new DAL_buscaPessoaFoto();

        /// <summary>
        /// Função que Transmite a Pessoa informado, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_pessoaFoto> Buscar(string codPessoa)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa);

                if (objDtb != null)
                {
                    lista = new BLL_listaFoto().CriarLista(objDtb);
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