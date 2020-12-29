using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.cargo;

namespace BLL.cargo
{
    /// <summary>
    /// Classe que implementa a Interface IBL_buscaCargo - Retorna uma lista com os registros buscados pela Descrição do Cargo
    /// </summary>
    public class BLL_buscaCargoPorDescricao : IBLL_buscaCargo
    {
        DataTable objDtb = null;
        List<MOD_cargo> lista = new List<MOD_cargo>();
        IDAL_buscaCargo objDAL = new DAL_buscaPorDescricao();

        /// <summary>
        /// Função que Transmite a DescCargo informada, para pesquisa
        /// </summary>
        /// <param name="DescCargo"></param>
        /// <returns></returns>
        public List<MOD_cargo> Buscar(string DescCargo)
        {
            try
            {
                objDtb = objDAL.Buscar(DescCargo + "%");

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