using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.importa;
using DAL.importa;

namespace BLL.importa
{
    public class BLL_buscaPorCodImportaPessoa : IBLL_buscaPorCodImportaPessoa
    {
        DataTable objDtb = null;
        List<MOD_importaPessoa> listaPessoa = new List<MOD_importaPessoa>();
        IDAL_buscaPorCodImportaPessoa objDAL = new DAL_buscaPorCodImportaPessoa();

        /// <summary>
        /// Função que Transmite o Código informado, para pesquisa
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public List<MOD_importaPessoa> Buscar(string codPessoa)
        {
            try
            {
                objDtb = objDAL.Buscar(codPessoa);

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