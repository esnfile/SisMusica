using BLL.Funcoes;
using ENT.Log;
using ENT.pessoa;
using System;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_pessoaMetodo_Log
    {
        
        /// <summary>
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        public MOD_log ValidaLog(MOD_log ent)
        {
            ent.Data = string.IsNullOrEmpty(ent.Data) ? null : funcoes.DataInt(ent.Data);
            ent.Hora = string.IsNullOrEmpty(ent.Hora) ? null : funcoes.HoraInt(ent.Hora);

            return ent;
        }
        /// <summary>
        /// Função que criar os dados para tabela Logs
        /// <para>Parametro ent - Informar a Tabela que está sendo alterada</para>
        /// <para>Parametro Operação - Informar se é Insert, Update ou Delete</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <param name="Operacao"></param>
        /// <returns></returns>
        public MOD_log CriarLog(MOD_pessoaMetodo ent, string Operacao)
        {
            try
            {
                MOD_acessoPessoaMetodo entAcesso = new MOD_acessoPessoaMetodo();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if ("Insert".Equals(Operacao))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.HabilitaMetodoPessoa);
                    ent.Logs.Ocorrencia = "Foi Habilitado para Estudo o Método: < " + ent.CodMetodo.PadLeft(3, '0') + " - " + ent.DescMetodo + " > " +
                                          "para o Irmão(ã): < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if ("Delete".Equals(Operacao))
                {
                    ent.Logs.CodRotina = Convert.ToString(entAcesso.DesabilitaMetodoPessoa);
                    ent.Logs.Ocorrencia = "Foi Desabilitado para Estudo o Método: < " + ent.CodMetodo.PadLeft(3, '0') + " - " + ent.DescMetodo + " > " +
                                          "para o Irmão(ã): < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }

                ent.Logs.NomePc = modulos.DescPc;
                ent.Logs.IpPc = modulos.IpPc;
                ent.Logs.CodCCB = modulos.CodRegional;

                return ent.Logs;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception exl)
            {
                throw exl;
            }
        }
    }
}