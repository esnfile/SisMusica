using ENT.acessos;
using ENT.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace BLL.Funcoes
{
    public class BLL_Liberacoes
    {

        /// <summary>
        /// Função que verifica a liberação ou bloqueio de acesso a Rotina Solicitada
        /// [rotina: Informar a rotina a ser analisada]</para>
        /// </summary>
        /// <param name="codRotina"></param>
        /// <returns></returns>
        public static bool LiberaAcessoRotina(int codRotina)
        {
            if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Supervisor))
            {
                MOD_Session.LiberaAcesso = true;
                return MOD_Session.LiberaAcesso;
            }

            foreach (MOD_acessos entAcesso in MOD_Session.ListaAcessoLogado)
            {
                if (codRotina.Equals(Convert.ToInt32(entAcesso.CodRotina)))
                {
                    MOD_Session.LiberaAcesso = true;
                    break;
                }
                else
                {
                    MOD_Session.LiberaAcesso = false;
                }
            }
            return MOD_Session.LiberaAcesso;
        }
        /// <summary>
        /// Função que verifica a liberação ou bloqueio de acesso a Rotina Solicitada
        /// [rotina: Informar a rotina a ser analisada], [dataGrid: Infomar o Grid para analisar se contem dados]</para>
        /// </summary>
        /// <param name="codRotina"></param>
        /// <param name="dataGrid"></param>
        /// <returns></returns>
        public static bool LiberaAcessoRotina(int codRotina, DataGridView dataGrid)
        {
            if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Supervisor))
            {
                if (dataGrid.Rows.Count > 0)
                {
                    MOD_Session.LiberaAcesso = true;
                    return MOD_Session.LiberaAcesso;
                }
                else
                {
                    MOD_Session.LiberaAcesso = false;
                    return MOD_Session.LiberaAcesso;
                }
            }
            foreach (MOD_acessos entAcesso in MOD_Session.ListaAcessoLogado)
            {
                if (codRotina.Equals(Convert.ToInt32(entAcesso.CodRotina)))
                {
                    if (dataGrid.Rows.Count > 0)
                    {
                        MOD_Session.LiberaAcesso = true;
                        break;
                    }
                    else
                    {
                        MOD_Session.LiberaAcesso = false;
                        break;
                    }
                }
                else
                {
                    MOD_Session.LiberaAcesso = false;
                }
            }

            return MOD_Session.LiberaAcesso;
        }

        /// <summary>
        /// Função que verifica a liberação ou bloqueio de acesso ao Programa Solicitado
        /// [rotina: Informar o programa a ser analisado]</para>
        /// </summary>
        /// <param name="codPrograma"></param>
        /// <returns></returns>
        public static bool LiberaAcessoPrograma(int codPrograma)
        {
            if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Supervisor))
            {
                MOD_Session.LiberaAcesso = true;
                return MOD_Session.LiberaAcesso;
            }

            foreach (MOD_acessos entAcesso in MOD_Session.ListaAcessoLogado)
            {
                if (codPrograma.Equals(Convert.ToInt32(entAcesso.CodPrograma)))
                {
                    MOD_Session.LiberaAcesso = true;
                    break;
                }
                else
                {
                    MOD_Session.LiberaAcesso = false;
                }
            }
            return MOD_Session.LiberaAcesso;
        }

        /// <summary>
        /// Função que verifica se o Usuario a ser editado é administrador
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public static bool LiberaEdicaoAdm(Int64 codigo, List<MOD_usuario> usuario)
        {
            try
            {
                ///Verifica se a variaval usuario possui dados, demonstrando assim que a pessoa possui usuario ativo
                ///caso não tenha usuario ativo, retorna true
                if (usuario == null || usuario.Count < 1)
                    return true;

                ///Verifica se o usuário está editando o próprio cadastro
                ///Caso seja, retorna true
                if (Convert.ToInt64(MOD_Session.ListaUsuarioLogado[0].CodUsuario).Equals(codigo))
                    return true;

                ///Verifica se o usuário logado é usuario administrador
                ///caso seja, retorna true
                if ("Sim".Equals(MOD_Session.ListaUsuarioLogado[0].Administrador))
                    return true;

                ///caso não seja faz a verificação se a pessoa ou o usuario a ser editado
                ///é um administrador do sistema,
                ///caso não seja, retorna true
                ///caso seja um administrador, retorna erro
                if ("Sim".Equals(usuario[0].Administrador))
                {
                    throw new Exception(modulos.acessoNegado);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}