using BLL.Funcoes;
using BLL.pessoa;
using ENT.importa;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.importa
{
    public class BLL_listaImportaPessoa
    {

        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_importaPessoa> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoa> lista = new List<MOD_importaPessoa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_importaPessoa ent = new MOD_importaPessoa
                    {
                        //adiciona os campos às propriedades
                        CodImportaPessoa = (string)(row.IsNull("CodImportaPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoa"]).PadLeft(6, '0')),
                        DataImporta = (string)(row.IsNull("DataImporta") ? Convert.ToString(null) : funcoes.IntData(row["DataImporta"].ToString())),
                        HoraImporta = (string)(row.IsNull("HoraImporta") ? Convert.ToString(null) : funcoes.IntHora(row["HoraImporta"].ToString())),
                        CodUsuario = (string)(row.IsNull("CodUsuario") ? Convert.ToString(null) : Convert.ToString(row["CodUsuario"]).PadLeft(6, '0')),
                        Usuario = (string)(row.IsNull("Usuario") ? null : row["Usuario"]),
                        CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0')),
                        Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]),
                        QtdeArquivo = (string)(row.IsNull("QtdeArquivo") ? Convert.ToString(null) : Convert.ToString(row["QtdeArquivo"])),
                        Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]),
                    };
                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores pesquisados
                return lista;
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
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public MOD_pessoa CriarDadosPessoa(MOD_importaPessoaItem objEnt_Item)
        {
            try
            {
                //instancia a lista
                MOD_pessoa objEnt_Pessoa = new MOD_pessoa
                {
                    //adiciona os campos às propriedades
                    Ativo = "Sim",
                    DataCadastro = objEnt_Item.DataCadastro,
                    HoraCadastro = objEnt_Item.HoraCadastro,
                    CodCargo = objEnt_Item.CodCargo,
                    Nome = objEnt_Item.Nome,
                    DataNasc = objEnt_Item.DataNasc,
                    Cpf = objEnt_Item.Cpf,
                    Rg = objEnt_Item.Rg,
                    Sexo = objEnt_Item.Sexo,
                    DataBatismo = objEnt_Item.DataBatismo,
                    CodCidadeRes = objEnt_Item.CodCidadeRes,
                    EndRes = objEnt_Item.EndRes,
                    NumRes = objEnt_Item.NumRes,
                    BairroRes = objEnt_Item.BairroRes,
                    ComplRes = objEnt_Item.ComplRes,
                    Telefone1 = objEnt_Item.Telefone1,
                    Telefone2 = objEnt_Item.Telefone2,
                    Celular1 = objEnt_Item.Celular1,
                    Celular2 = objEnt_Item.Celular2,
                    Email = objEnt_Item.Email,
                    CodCCB = objEnt_Item.CodCCB,
                    EstadoCivil = objEnt_Item.EstadoCivil,
                    DataApresentacao = objEnt_Item.DataApresentacao,
                    PaisCCB = objEnt_Item.PaisCCB,
                    Pai = objEnt_Item.Pai,
                    Mae = objEnt_Item.Mae,
                    FormacaoFora = objEnt_Item.FormacaoFora,
                    LocalFormacao = objEnt_Item.LocalFormacao,
                    QualFormacao = objEnt_Item.QualFormacao,
                    OutraOrquestra = objEnt_Item.OutraOrquestra,
                    Orquestra1 = objEnt_Item.Orquestra1,
                    Funcao1 = objEnt_Item.Funcao1,
                    Orquestra2 = objEnt_Item.Orquestra2,
                    Funcao2 = objEnt_Item.Funcao2,
                    Orquestra3 = objEnt_Item.Orquestra3,
                    Funcao3 = objEnt_Item.Funcao3,
                    CodInstrumento = objEnt_Item.CodInstrumento,
                    Desenvolvimento = objEnt_Item.Desenvolvimento,
                    DataUltimoTeste = objEnt_Item.DataUltimoTeste,
                    DataInicioEstudo = objEnt_Item.DataInicioEstudo,
                    ExecutInstrumento = objEnt_Item.ExecutInstrumento,
                    CodCCBGem = objEnt_Item.CodCCBGem,
                    OrgaoEmissor = objEnt_Item.OrgaoEmissor
                };
                //retorna a lista com os valores pesquisados
                return objEnt_Pessoa;
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