using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.importa;
using DAL.importa;
using BLL.Funcoes;

namespace BLL.importa
{
    public class BLL_buscaPorDataImportaPessoa : IBLL_buscaPorDataImportaPessoa
    {
        DataTable objDtb = null;
        List<MOD_importaPessoa> listaPessoa = new List<MOD_importaPessoa>();
        IDAL_buscaPorDataImportaPessoa objDAL = new DAL_buscaPorDataImportaPessoa();

        /// <summary>
        /// Função que Transmite a Data Inicial e Final informada, para pesquisa
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public List<MOD_importaPessoa> Buscar(string dataInicial, string dataFinal)
        {
            try
            {
                objDtb = objDAL.Buscar(funcoes.DataInt(dataInicial), funcoes.DataInt(dataFinal));

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