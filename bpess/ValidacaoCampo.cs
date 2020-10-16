using ENT.Erros;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public class ValidacaoCampo : IValidacaoCampo
    {
        //inicia uma nova lista de erros
        List<MOD_erros> listaErros = new List<MOD_erros>();

        /// <summary>
        /// Validação Campo da Tabela Pessoa
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public List<MOD_erros> ValidaCamposPessoa(MOD_pessoa pessoa)
        {
            try
            {
                if (string.IsNullOrEmpty(pessoa.Sexo))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Sexo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.CodCargo))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Cargo! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.Nome))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Nome! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.DataNasc))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Data Nascimento! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.Cpf))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> C.P.F.! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.CodCidadeRes))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Cep! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.EndRes))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Endereço! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.NumRes))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Número! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.BairroRes))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Bairro! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.Email))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> É aconselhável informar o e-mail, é uma ótima forma de contato.";
                    objEnt_Erros.Grau = "Baixo";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.Telefone1) && string.IsNullOrEmpty(pessoa.Telefone2) &&
                    string.IsNullOrEmpty(pessoa.Celular1) && string.IsNullOrEmpty(pessoa.Celular2))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Necessário informar ao menos um Telefone ou Celular!";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(pessoa.CodCCB))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Geral -> Comum Congregação! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }

                if (string.IsNullOrEmpty(pessoa.EstadoCivil))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Aba Adicionais -> Estado Civil. Campo obrigatório!";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if ("Não".Equals(pessoa.Ativo))
                {
                    if (string.IsNullOrEmpty(pessoa.MotivoInativa))
                    {
                        MOD_erros objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Pessoa Inativa. Informe o motivo!";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                if ("Sim".Equals(pessoa.PermiteInstrumento))
                {
                    if (string.IsNullOrEmpty(pessoa.Desenvolvimento))
                    {
                        MOD_erros objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Desenvolvimento! Campo obrigatório.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                if ("Sim".Equals(pessoa.FormacaoFora))
                {
                    if (string.IsNullOrEmpty(pessoa.LocalFormacao))
                    {
                        MOD_erros objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Formação. Informe o local onde se formou!";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                    if (string.IsNullOrEmpty(pessoa.QualFormacao))
                    {
                        MOD_erros objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Formação. Informe a formação musical!";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                if ("Sim".Equals(pessoa.OutraOrquestra))
                {
                    if (string.IsNullOrEmpty(pessoa.Orquestra1) || string.IsNullOrEmpty(pessoa.Funcao1))
                    {
                        MOD_erros objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Aba Adicionais -> Outras Orquestras. Informe a Orquestra e Função 01!";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
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
        /// Validação Campo da Tabela Cargo
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public List<MOD_erros> ValidaCamposCargo(MOD_cargo cargo)
        {
            try
            {
                if (string.IsNullOrEmpty(cargo.SiglaCargo))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Sigla de Abreviação! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cargo.DescCargo))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (0.Equals(cargo.Ordem))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Ordem! Valor deve ser diferente de Zero.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cargo.CodDepartamento))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Departamento! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if ("Não".Equals(cargo.Masculino) && "Não".Equals(cargo.Feminino))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Informe se o Ministério é atendido por Irmãos(ãs).";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if ("Sim".Equals(cargo.PermiteInstrumento))
                {
                    if ("Não".Equals(cargo.AlunoGem) && "Não".Equals(cargo.Ensaio) &&
                        "Não".Equals(cargo.MeiaHora) && "Não".Equals(cargo.Rjm) &&
                        "Não".Equals(cargo.Culto) && "Não".Equals(cargo.Oficial))
                    {
                        MOD_erros objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Desenvolvimento musical! Campo obrigatório.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
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
        /// Funcão que valida o CPF digitado, e Retorna a lista com os valores encontrados
        /// </summary>
        public List<MOD_pessoa> validaCpfDuplicado(MOD_pessoa pessoa)
        {
            try
            {
                List<MOD_pessoa> listaValidaCpf = new List<MOD_pessoa>();
                return listaValidaCpf = new BLL_pessoa().buscarCpf(pessoa.Cpf);
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