using BLL.Funcoes;
using ENT.Log;
using ENT.pessoa;
using System;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_pessoaImporta_Log
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
        /// <para>Parametro Operacao - Informar se é Insert ou Update</para>
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        public MOD_log CriarLog(MOD_pessoa ent, string Operacao)
        {
            try
            {
                MOD_acessoPessoa entAcesso = new MOD_acessoPessoa();
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);
                ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotPesImportar);

                if ("Update".Equals(Operacao))
                {
                    ent.Logs.Ocorrencia = "Atualização através da Importação no cadastro do Irmão(ã): Nome: < " + ent.Nome + " > CPF: < " + ent.Cpf + " > ";
                }
                else
                {
                    ent.Logs.Ocorrencia = "Cadastro novo Importado do Irmão(ã): Nome: < " + ent.Nome + " > CPF: < " + ent.Cpf + " > ";
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