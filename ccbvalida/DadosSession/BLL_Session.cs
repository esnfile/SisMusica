using BLL.acessos;
using BLL.Usuario;
using BLL.uteis;
using ccbfun.Funcoes;
using ENT.acessos;
using ENT.Session;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Valida
{
    public class BLL_Session
    {

        public BLL_Session(Int64 codUsuario, out List<MOD_usuario> listaUsuario)
        {
            BLL_usuario objBLL_Usuario = new BLL_usuario();
            listaUsuario = objBLL_Usuario.buscarCod(Convert.ToString(codUsuario));

            new MOD_Session(listaUsuario);

            BuscaAcessosUsuarioLogado(codUsuario);
            BuscaCargoUsuarioLogado(codUsuario);
            BuscaCCBUsuarioLogado(codUsuario);
        }

        public BLL_Session(int codRegional, out List<MOD_parametros> listaParametro)
        {
            BLL_parametros objBLL_Parametro = new BLL_parametros();
            listaParametro = objBLL_Parametro.buscarRegional(Convert.ToString(codRegional));

            new MOD_Session(listaParametro);
        }

        private void BuscaAcessosUsuarioLogado(Int64 codUsuario)
        {
            BLL_acessos objBLL_Acesso = new BLL_acessos();
            List<MOD_acessos> listaAcesso = objBLL_Acesso.buscarUsuAcesso(Convert.ToString(codUsuario));

            new MOD_Session(listaAcesso);
        }

        private void BuscaCargoUsuarioLogado(Int64 codUsuario)
        {
            List<MOD_usuarioCargo> listaUsuarioCargo = new BLL_usuario().buscarUsuarioCargo(Convert.ToString(codUsuario));

            new MOD_Session(listaUsuarioCargo);
        }

        private void BuscaCCBUsuarioLogado(Int64 codUsuario)
        {
            List<MOD_usuarioCCB> listaUsuarioCCB = new BLL_usuario().buscarUsuarioCCB(Convert.ToString(codUsuario)).ToList();

            new MOD_Session(listaUsuarioCCB);
        }
    }
}