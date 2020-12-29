using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;

namespace BLL.pessoa
{
    public class BLL_buscaPessoaDuplicada : IBLL_buscaPessoaDuplicada
    {
        DataTable objDtb = null;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
        DAL_buscaPessoaDuplicada objDAL = new DAL_buscaPessoaDuplicada();

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, para importação de novos dados
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="DataNasc"></param>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string Nome, string DataNasc, string CodCidade)
        {
            try
            {
                objDtb = objDAL.buscarPessoaDuplicada(Nome + "%", DataNasc, CodCidade);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaPessoa().CriarLista(objDtb);
                }
                return listaPessoa;
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