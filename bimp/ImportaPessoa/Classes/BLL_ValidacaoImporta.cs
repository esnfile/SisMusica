using BLL.Funcoes;
using ENT.Erros;
using ENT.importa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BLL.importa
{
    public class BLL_ValidacaoImporta : IBLL_ValidacaoImporta
    {
        //inicia uma nova lista de erros
        List<MOD_erros> listaErros = new List<MOD_erros>();

        /// <summary>
        /// Validação Campo da Tabela Importação
        /// </summary>
        /// <param name="importa"></param>
        /// <returns></returns>
        public List<MOD_erros> ValidaCamposImporta(MOD_importaPessoa importa)
        {
            try
            {
                if (string.IsNullOrEmpty(importa.Descricao))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                return listaErros;
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
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="ent"></param>
        public MOD_importaPessoa ConverteData(MOD_importaPessoa ent)
        {
            try
            {
                ent.DataImporta = string.IsNullOrEmpty(ent.DataImporta) ? null : funcoes.DataInt(ent.DataImporta);
                ent.HoraImporta = string.IsNullOrEmpty(ent.HoraImporta) ? null : funcoes.HoraInt(ent.HoraImporta);
                return ent;
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
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="lista"></param>
        public MOD_importaPessoaItem ConverteData(MOD_importaPessoaItem ent)
        {
            try
            {
                ent.DataCadastro = string.IsNullOrEmpty(ent.DataCadastro) ? null : funcoes.DataInt(ent.DataCadastro);
                ent.HoraCadastro = string.IsNullOrEmpty(ent.HoraCadastro) ? null : funcoes.HoraInt(ent.HoraCadastro);
                ent.Cpf = string.IsNullOrEmpty(ent.Cpf) ? null : funcoes.FormataCpf(ent.Cpf);
                ent.DataNasc = string.IsNullOrEmpty(ent.DataNasc) ? null : funcoes.DataInt(ent.DataNasc);
                ent.DataBatismo = string.IsNullOrEmpty(ent.DataBatismo) ? null : funcoes.DataInt(ent.DataBatismo);
                ent.DataApresentacao = string.IsNullOrEmpty(ent.DataApresentacao) ? null : funcoes.DataInt(ent.DataApresentacao);
                ent.DataUltimoTeste = string.IsNullOrEmpty(ent.DataUltimoTeste) ? null : funcoes.DataInt(ent.DataUltimoTeste);
                ent.DataInicioEstudo = string.IsNullOrEmpty(ent.DataInicioEstudo) ? null : funcoes.DataInt(ent.DataInicioEstudo);

                return ent;
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
        /// Função que converte as data em inteiro para salvar no Banco de dados
        /// </summary>
        /// <param name="lista"></param>
        public MOD_importaPessoaItemErro ConverteData(MOD_importaPessoaItemErro ent)
        {
            try
            {
                ent.DataCadastro = string.IsNullOrEmpty(ent.DataCadastro) ? null : funcoes.DataInt(ent.DataCadastro);
                ent.HoraCadastro = string.IsNullOrEmpty(ent.HoraCadastro) ? null : funcoes.HoraInt(ent.HoraCadastro);
                ent.Cpf = string.IsNullOrEmpty(ent.Cpf) || "Erro".Contains(ent.Cpf) ? "Erro" : funcoes.FormataCpf(ent.Cpf);
                ent.DataNasc = string.IsNullOrEmpty(ent.DataNasc) || "Erro".Contains(ent.DataNasc) ? "Erro" : funcoes.DataInt(ent.DataNasc);
                ent.DataBatismo = string.IsNullOrEmpty(ent.DataBatismo) ? null : funcoes.DataInt(ent.DataBatismo);
                ent.DataApresentacao = string.IsNullOrEmpty(ent.DataApresentacao) ? null : funcoes.DataInt(ent.DataApresentacao);
                ent.DataUltimoTeste = string.IsNullOrEmpty(ent.DataUltimoTeste) ? null : funcoes.DataInt(ent.DataUltimoTeste);
                ent.DataInicioEstudo = string.IsNullOrEmpty(ent.DataInicioEstudo) ? null : funcoes.DataInt(ent.DataInicioEstudo);

                return ent;
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