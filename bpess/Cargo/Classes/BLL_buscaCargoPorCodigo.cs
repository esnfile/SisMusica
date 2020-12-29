using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DAL.cargo;
using ENT.pessoa;

namespace BLL.cargo
{
    public class BLL_buscaCargoPorCodigo : IBLL_buscaCargo
    {
        DataTable objDtb = null;
        List<MOD_cargo> lista = new List<MOD_cargo>();
        IDAL_buscaCargo objDAL = new DAL_buscaPorCodigo();

        /// <summary>
        /// Função que Transmite a CodCargo informada, para pesquisa
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <returns></returns>
        public List<MOD_cargo> Buscar(string CodCargo)
        {
            try
            {
                objDtb = objDAL.Buscar(CodCargo);

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