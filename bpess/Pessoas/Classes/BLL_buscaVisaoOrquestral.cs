using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;

namespace BLL.pessoa
{
    public class BLL_buscaVisaoOrquestral : IBLL_buscaVisaoOrquestral
    {
        DataTable objDtb = null;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
        DAL_buscaVisaoOrquestral objDAL = new DAL_buscaVisaoOrquestral();

        /// <summary>
        /// Função que Transmite o Instrumento informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string CodInstrumento, string CodCCB, bool Ativo)
        {
            try
            {
                objDtb = objDAL.buscarVisaoOrquestral(CodInstrumento, CodCCB, Ativo);

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