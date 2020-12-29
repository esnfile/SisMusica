using BLL.Funcoes;
using ENT.importa;
using ENT.Log;
using ENT.pessoa;
using System;
using System.Data.SqlClient;

namespace BLL.importa
{
    public class BLL_importaPessoa_Log
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
        public MOD_log CriarLog(MOD_importaPessoa ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoImportaPessoa.RotInsImportaPessoa);
                    ent.Logs.Ocorrencia = "Nova Importação Realizada - Código: < " + ent.CodImportaPessoa.PadLeft(6, '0') + " > Usuario: < " + ent.CodUsuario.PadLeft(6, '0') + " - " + ent.Usuario + " > ";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoImportaPessoa.RotEditImportaPessoa);
                    ent.Logs.Ocorrencia = "Alteração na Importação Código: < " + ent.CodImportaPessoa.PadLeft(6, '0') + " > Usuario: < " + ent.CodUsuario.PadLeft(6, '0') + " - " + ent.Usuario + " > ";
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