using BLL.Funcoes;
using ENT.Log;
using ENT.pessoa;
using System;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_pessoa_Log
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
        public MOD_log CriarLog(MOD_pessoa ent, string Operacao)
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
                    ent.Logs.Ocorrencia = "Foi Inserido novo cadastro do Irmão(ã): < " + ent.CodPessoa + " - " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Update"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotEditPessoa);
                    ent.Logs.Ocorrencia = "Foi Atualizado o cadastro do Irmão(ã): < " + ent.CodPessoa + " - " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Delete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotExcPessoa);
                    ent.Logs.Ocorrencia = "Foi Excluído o cadastro do Irmão(ã): < " + ent.CodPessoa + " - " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("CCBPessoa"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotPesAteComum);
                    ent.Logs.Ocorrencia = "Houve Alteração nas Comuns Congregação de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("CCBPessoaDelete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotPesAteComum);
                    ent.Logs.Ocorrencia = "Houve Exclusão nas Comuns Congregação de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("RegiaoPessoa"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotPesAteRegiao);
                    ent.Logs.Ocorrencia = "Houve Alteração nas Regiões de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("RegiaoPessoaDelete"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotPesAteRegiao);
                    ent.Logs.Ocorrencia = "Houve Exclusão nas Regiões de Atendimento da Pessoa: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("PessoaInstr"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotPesGemMetodo);
                    ent.Logs.Ocorrencia = "Houve Alteração nos Métodos que a Pessoa utiliza: Código: < " + ent.CodPessoa + " > Nome: < " + ent.Nome + " > ";
                }
                else if (Operacao.Equals("Import"))
                {
                    ent.Logs.CodRotina = Convert.ToString(MOD_acessoPessoa.RotPesImportar);
                    ent.Logs.Ocorrencia = "Importação de pessoas: Nome: < " + ent.Nome + " > CPF: < " + ent.Cpf + " > ";
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