using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.cargo;

namespace BLL.cargo
{
    public class BLL_buscaCargoPorDepartamento : IBLL_buscaCargo
    {
        DataTable objDtb = null;
        List<MOD_cargo> lista = new List<MOD_cargo>();
        IDAL_buscaCargo objDAL = new DAL_buscaPorDepartamento();

        /// <summary>
        /// Função que Transmite a CodDepartamento informada, para pesquisa
        /// </summary>
        /// <param name="CodDepartamento"></param>
        /// <returns></returns>
        public List<MOD_cargo> Buscar(string CodDepartamento)
        {
            try
            {
                objDtb = objDAL.Buscar(CodDepartamento);

                if (objDtb != null)
                {
                    lista = new BLL_listaCargo().CriarLista(objDtb);
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