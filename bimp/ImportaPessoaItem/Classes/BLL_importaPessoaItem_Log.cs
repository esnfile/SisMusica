using BLL.Funcoes;
using ENT.Log;
using ENT.importa;
using System;
using System.Data.SqlClient;

namespace BLL.importa
{
    public class BLL_importaPessoaItem_Log
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
        /// <param name="Operacao"></param>
        /// <returns></returns>
        public MOD_log CriarLog(MOD_importaPessoaItem ent, string Operacao)
        {
            try
            {
                //preenche os dados para salvar na tabela Logs
                ent.Logs = new MOD_log();
                ent.Logs.Data = DateTime.Now.ToString("dd/MM/yyyy");
                ent.Logs.Hora = DateTime.Now.ToString("HH:mm");
                ent.Logs.CodUsuario = Convert.ToString(modulos.CodUsuario);

                if (Operacao.Equals("Insert"))
                {
                    ent.Logs.CodRotina = Convert.ToString(new MOD_acessoImportaPessoaItem().RotEditImportaPessoaItem);
                    ent.Logs.Ocorrencia = "Foi Inserido o registro nº < " + ent.CodImportaPessoaItem + " > " +
                                         "gerado através da Importação nº < " + ent.CodImportaPessoa + " > " + "do Irmão(ã): < " + ent.CodPessoa + " - " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(new MOD_acessoImportaPessoaItem().RotEditImportaPessoaItem);
                    ent.Logs.Ocorrencia = "Foi feito Alteração do registro nº < " + ent.CodImportaPessoaItem + " > " +
                                         "gerado através da Importação nº < " + ent.CodImportaPessoa + " > " + "do Irmão(ã): < " + ent.CodPessoa + " - " + ent.Nome + " > ";
                }
                else
                {
                    ent.Logs.CodRotina = Convert.ToString(new MOD_acessoImportaPessoaItem().RotEditImportaPessoaItem);
                    ent.Logs.Ocorrencia = "Foi Excluido o registro nº < " + ent.CodImportaPessoaItem + " > " +
                                         "gerado através da Importação nº < " + ent.CodImportaPessoa + " > " + "do Irmão(ã): < " + ent.CodPessoa + " - " + ent.Nome + " > ";
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