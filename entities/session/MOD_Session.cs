using ENT.acessos;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace ENT.Session
{
    public class MOD_Session
    {

        public MOD_Session(List<MOD_usuario> listaUsuario)
        {
            listaUsuarioLogado = listaUsuario;
        }

        public MOD_Session(List<MOD_parametros> listaParametro)
        {
            listaParametroLogado = listaParametro;
        }

        public MOD_Session(List<MOD_acessos> listaAcesso)
        {
            listaAcessoLogado = listaAcesso;
        }

        public MOD_Session(List<MOD_usuarioCCB> listaCCBUsuario)
        {
            listaCCBLogado = listaCCBUsuario;
        }

        public MOD_Session(List<MOD_usuarioCargo> listaCargoUsuario)
        {
            listaCargoLogado = listaCargoUsuario;
        }

        public MOD_Session(string strConnection)
        {
            StrConnection = strConnection;
        }

        private static List<MOD_usuario> listaUsuarioLogado;
        public static List<MOD_usuario> ListaUsuarioLogado
        {
            get
            {
                return listaUsuarioLogado;
            }
        }

        private static List<MOD_parametros> listaParametroLogado;
        public static List<MOD_parametros> ListaParametroLogado
        {
            get
            {
                return listaParametroLogado;
            }
        }

        private static List<MOD_acessos> listaAcessoLogado;
        public static List<MOD_acessos> ListaAcessoLogado
        {
            get
            {
                return listaAcessoLogado;
            }
        }

        private static List<MOD_usuarioCCB> listaCCBLogado;
        public static string ListaCCBUsuarioLogado
        {
            get
            {
                string CodUsuCCB = string.Empty;
                foreach (MOD_usuarioCCB ent in listaCCBLogado)
                {
                    string Codigo = string.Empty;
                    if (CodUsuCCB.Equals(string.Empty))
                    {
                        Codigo = Convert.ToInt32(ent.CodCCB).ToString();
                    }
                    else
                    {
                        Codigo = CodUsuCCB + "," + Convert.ToInt32(ent.CodCCB).ToString();
                    }
                    CodUsuCCB = Codigo;
                }

                return CodUsuCCB;
            }
        }

        private static List<MOD_usuarioCargo> listaCargoLogado;
        public static string ListaCargoUsuarioLogado
        {
            get
            {
                string CodUsuCargo = string.Empty;
                foreach (MOD_usuarioCargo ent in listaCargoLogado)
                {
                    string Codigo = string.Empty;
                    if (CodUsuCargo.Equals(string.Empty))
                    {
                        Codigo = Convert.ToInt32(ent.CodCargo).ToString();
                    }
                    else
                    {
                        Codigo = CodUsuCargo + "," + Convert.ToInt32(ent.CodCargo).ToString();
                    }
                    CodUsuCargo = Codigo;
                }
                return CodUsuCargo;
            }
        }

        private static bool liberaAcesso;
        public static bool LiberaAcesso
        {
            get
            {
                return liberaAcesso;
            }
            set
            {
                liberaAcesso = value;
            }
        }

        private static string _strConnection;
        public static string StrConnection
        {
            get { return _strConnection; }
            set { _strConnection = value; }
        }

    }
}