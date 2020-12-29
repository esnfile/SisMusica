using BLL.Funcoes;
using ENT.Log;
using ENT.pessoa;
using System;
using System.Data.SqlClient;

namespace BLL.cargo
{
    public class BLL_cargo_Log : IBLL_cargo_Log
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
        public MOD_log CriarLog(MOD_cargo ent, string Operacao)
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
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotInsPessoa);
                    ent.Logs.Ocorrencia = "Foi Inserido novo cadastro: < " + ent.CodCargo + " - " + ent.DescCargo + " > ";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotEditPessoa);
                    ent.Logs.Ocorrencia = "Foi Atualizado o Cargo: < " + ent.CodCargo + " - " + ent.DescCargo + " > ";
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotExcPessoa);
                    ent.Logs.Ocorrencia = "Foi Excluído o Cargo: < " + ent.CodCargo + " - " + ent.DescCargo + " > ";
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