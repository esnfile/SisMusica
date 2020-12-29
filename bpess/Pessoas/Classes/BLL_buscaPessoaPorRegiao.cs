using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;
using ENT.Session;

namespace BLL.pessoa
{
    public class BLL_buscaPessoaPorRegiao : IBLL_buscaPessoa
    {
        DataTable objDtb = null;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
        IDAL_buscaPessoa objDAL = new DAL_buscaPorRegiao();

        /// <summary>
        /// Função que Transmite o codRegiao informado, para pesquisa
        /// </summary>
        /// <param name="codRegiao"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string codRegiao)
        {
            try
            {
                if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Administrador))
                {
                    objDtb = objDAL.Buscar(codRegiao);
                }
                else
                {
                    objDtb = objDAL.Buscar(codRegiao, MOD_Session.ListaCCBUsuarioLogado, MOD_Session.ListaCargoUsuarioLogado);
                }

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
        /// <summary>
        /// Função que Transmite o codRegiao informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="codRegiao"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string codRegiao, bool ativo)
        {
            try
            {
                if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Administrador))
                {
                    objDtb = objDAL.Buscar(codRegiao, ativo);
                }
                else
                {
                    objDtb = objDAL.Buscar(codRegiao, MOD_Session.ListaCCBUsuarioLogado, MOD_Session.ListaCargoUsuarioLogado, ativo);
                }

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