using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ENT.pessoa;
using DAL.pessoa;
using ENT.Session;

namespace BLL.pessoa
{
    public class BLL_buscaPessoaPorCpf : IBLL_buscaPessoa
    {
        DataTable objDtb = null;
        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
        IDAL_buscaPessoa objDAL = new DAL_buscaPorCpf();

        /// <summary>
        /// Função que Transmite o cpf informado, para pesquisa
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string cpf)
        {
            try
            {
                if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Administrador))
                {
                    objDtb = objDAL.Buscar(cpf + "%");
                }
                else
                {
                    objDtb = objDAL.Buscar(cpf + "%", MOD_Session.ListaCCBUsuarioLogado, MOD_Session.ListaCargoUsuarioLogado);
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
        /// Função que Transmite o cpf informado, para pesquisa
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        public List<MOD_pessoa> Buscar(string cpf, bool ativo)
        {
            try
            {
                if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Administrador))
                {
                    objDtb = objDAL.Buscar(cpf + "%", ativo);
                }
                else
                {
                    objDtb = objDAL.Buscar(cpf + "%", MOD_Session.ListaCCBUsuarioLogado, MOD_Session.ListaCargoUsuarioLogado, ativo);
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