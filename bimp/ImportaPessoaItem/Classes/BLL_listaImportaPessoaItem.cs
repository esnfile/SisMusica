using BLL.Funcoes;
using ENT.importa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.importa
{
    public class BLL_listaImportaPessoaItem
    {
        
        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_importaPessoaItem> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_importaPessoaItem> lista = new List<MOD_importaPessoaItem>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_importaPessoaItem ent = new MOD_importaPessoaItem();
                    //adiciona os campos às propriedades
                    ent.CodImportaPessoaItem = (string)(row.IsNull("CodImportaPessoaItem") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoaItem"]).PadLeft(6, '0'));
                    ent.CodImportaPessoa = (string)(row.IsNull("CodImportaPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodImportaPessoa"]).PadLeft(6, '0'));
                    ent.DataCadastro = (string)(row.IsNull("DataCadastro") ? Convert.ToString(null) : funcoes.IntData(row["DataCadastro"].ToString()));
                    ent.HoraCadastro = (string)(row.IsNull("HoraCadastro") ? Convert.ToString(null) : funcoes.IntHora(row["HoraCadastro"].ToString()));
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.DataNasc = (string)(row.IsNull("DataNasc") ? Convert.ToString(null) : funcoes.IntData(row["DataNasc"].ToString()));
                    ent.Cpf = (string)(row.IsNull("Cpf") ? null : row["Cpf"]);
                    ent.Rg = (string)(row.IsNull("Rg") ? null : row["Rg"]);
                    ent.OrgaoEmissor = (string)(row.IsNull("OrgaoEmissor") ? null : row["OrgaoEmissor"]);
                    ent.Sexo = (string)(row.IsNull("Sexo") ? null : row["Sexo"]);
                    ent.DataBatismo = (string)(row.IsNull("DataBatismo") ? Convert.ToString(null) : funcoes.IntData(row["DataBatismo"].ToString()));
                    ent.CodCidadeRes = (string)(row.IsNull("CodCidadeRes") ? Convert.ToString(null) : Convert.ToString(row["CodCidadeRes"]).PadLeft(6, '0'));
                    ent.CidadeRes = (string)(row.IsNull("CidadeRes") ? null : row["CidadeRes"]);
                    ent.EstadoRes = (string)(row.IsNull("EstadoRes") ? null : row["EstadoRes"]);
                    ent.CepRes = (string)(row.IsNull("CepRes") ? null : funcoes.FormataString("#####-###", row["CepRes"].ToString()));
                    ent.EndRes = (string)(row.IsNull("EndRes") ? null : row["EndRes"]);
                    ent.NumRes = (string)(row.IsNull("NumRes") ? null : row["NumRes"]);
                    ent.BairroRes = (string)(row.IsNull("BairroRes") ? null : row["BairroRes"]);
                    ent.ComplRes = (string)(row.IsNull("ComplRes") ? null : row["ComplRes"]);
                    ent.Telefone1 = (string)(row.IsNull("Telefone1") ? null : row["Telefone1"]);
                    ent.Telefone2 = (string)(row.IsNull("Telefone2") ? null : row["Telefone2"]);
                    ent.Celular1 = (string)(row.IsNull("Celular1") ? null : row["Celular1"]);
                    ent.Celular2 = (string)(row.IsNull("Celular2") ? null : row["Celular2"]);
                    ent.Email = (string)(row.IsNull("Email") ? null : row["Email"]);
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.EstadoCivil = (string)(row.IsNull("EstadoCivil") ? null : row["EstadoCivil"]);
                    ent.DataApresentacao = (string)(row.IsNull("DataApresentacao") ? Convert.ToString(null) : funcoes.IntData(row["DataApresentacao"].ToString()));
                    ent.Pai = (string)(row.IsNull("Pai") ? null : row["Pai"]);
                    ent.Mae = (string)(row.IsNull("Mae") ? null : row["Mae"]);
                    ent.FormacaoFora = (string)(row.IsNull("FormacaoFora") ? null : row["FormacaoFora"]);
                    ent.LocalFormacao = (string)(row.IsNull("LocalFormacao") ? null : row["LocalFormacao"]);
                    ent.QualFormacao = (string)(row.IsNull("QualFormacao") ? null : row["QualFormacao"]);
                    ent.OutraOrquestra = (string)(row.IsNull("OutraOrquestra") ? null : row["OutraOrquestra"]);
                    ent.Orquestra1 = (string)(row.IsNull("Orquestra1") ? null : row["Orquestra1"]);
                    ent.Funcao1 = (string)(row.IsNull("Funcao1") ? null : row["Funcao1"]);
                    ent.Orquestra2 = (string)(row.IsNull("Orquestra2") ? null : row["Orquestra2"]);
                    ent.Funcao2 = (string)(row.IsNull("Funcao2") ? null : row["Funcao2"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.Desenvolvimento = (string)(row.IsNull("Desenvolvimento") ? null : row["Desenvolvimento"]);
                    ent.DataUltimoTeste = (string)(row.IsNull("DataUltimoTeste") ? Convert.ToString(null) : funcoes.IntData(row["DataUltimoTeste"].ToString()));
                    ent.DataInicioEstudo = (string)(row.IsNull("DataInicioEstudo") ? Convert.ToString(null) : funcoes.IntData(row["DataInicioEstudo"].ToString()));
                    ent.ExecutInstrumento = (string)(row.IsNull("ExecutInstrumento") ? null : row["ExecutInstrumento"]);
                    ent.CodCCBGem = (string)(row.IsNull("CodCCBGem") ? Convert.ToString(null) : Convert.ToString(row["CodCCBGem"]).PadLeft(6, '0'));
                    ent.CodigoCCBGem = (string)(row.IsNull("CodigoCCBGem") ? null : row["CodigoCCBGem"]);
                    ent.DescricaoCCBGem = (string)(row.IsNull("DescricaoCCBGem") ? null : row["DescricaoCCBGem"]);
                    ent.Sequencia = Convert.ToString(lista.Count + 1).PadLeft(5, '0');

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
    }
}