using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.importa;
using DAL.importa;

namespace BLL.importa
{
    public class BLL_buscaPorDescricaoImportaPessoa : IBLL_buscaPorDescricaoImportaPessoa
    {
        DataTable objDtb = null;
        List<MOD_importaPessoa> listaPessoa = new List<MOD_importaPessoa>();
        IDAL_buscaPorDescricaoImportaPessoa objDAL = new DAL_buscaPorDescricaoImportaPessoa();

        /// <summary>
        /// Função que Transmite a Descrição informado, para pesquisa
        /// </summary>
        /// <param name="descricao"></param>
        /// <returns></returns>
        public List<MOD_importaPessoa> Buscar(string descricao)
        {
            try
            {
                objDtb = objDAL.Buscar(descricao);

                if (objDtb != null)
                {
                    listaPessoa = new BLL_listaImportaPessoa().CriarLista(objDtb);
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