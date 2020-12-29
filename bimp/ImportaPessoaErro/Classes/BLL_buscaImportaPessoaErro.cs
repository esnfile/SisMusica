using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.importa;
using DAL.importa;

namespace BLL.importa
{
    public class BLL_buscaImportaPessoaErro : IBLL_buscaImportaPessoaErro
    {
        DataTable objDtb = null;
        List<MOD_importaPessoaItemErro> lista = new List<MOD_importaPessoaItemErro>();
        IDAL_buscaImportaPessoaErro objDAL = new DAL_buscaImportaPessoaErro();

        /// <summary>
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        public List<MOD_importaPessoaItemErro> Buscar(string codCCBUsuario)
        {
            try
            {
                objDtb = objDAL.Buscar(codCCBUsuario);

                if (objDtb != null)
                {
                    lista = new BLL_listaImportaPessoaErro().CriarLista(objDtb);
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
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso e pelo Código da Importação
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        /// <param name="codImportaPessoa"></param>
        /// <returns></returns>
        public List<MOD_importaPessoaItemErro> Buscar(string codCCBUsuario, string codImportaPessoa)
        {
            try
            {
                objDtb = objDAL.Buscar(codCCBUsuario, codImportaPessoa);

                if (objDtb != null)
                {
                    lista = new BLL_listaImportaPessoaErro().CriarLista(objDtb);
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
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso, pelo Código da Importação e Pelos Cargos que o Usuário tem Acesso
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        /// <param name="codImportaPessoa"></param>
        /// <param name="codCargoUsuario"></param>
        /// <returns></returns>
        public List<MOD_importaPessoaItemErro> Buscar(string codCCBUsuario, string codImportaPessoa, string codCargoUsuario)
        {
            try
            {
                objDtb = objDAL.Buscar(codCCBUsuario, codImportaPessoa, codCargoUsuario);

                if (objDtb != null)
                {
                    lista = new BLL_listaImportaPessoaErro().CriarLista(objDtb);
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