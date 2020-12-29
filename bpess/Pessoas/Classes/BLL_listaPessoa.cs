using BLL.cargo;
using BLL.Funcoes;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_listaPessoa
    {

        IBLL_buscaCargo objBLL_Cargo;
        IBLL_buscaPessoaFoto objBLL_PessoaFoto;

        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_pessoa> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoa> lista = new List<MOD_pessoa>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_pessoa ent = new MOD_pessoa();
                    //adiciona os campos às propriedades
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.DataCadastro = (string)(row.IsNull("DataCadastro") ? Convert.ToString(null) : funcoes.IntData(row["DataCadastro"].ToString()));
                    ent.HoraCadastro = (string)(row.IsNull("HoraCadastro") ? Convert.ToString(null) : funcoes.IntHora(row["HoraCadastro"].ToString()));
                    ent.CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0'));
                    ent.DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]);
                    ent.SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]);
                    ent.OrdemCargo = (string)(row.IsNull("OrdemCargo") ? Convert.ToString(null) : Convert.ToString(row["OrdemCargo"]).PadLeft(2, '0'));
                    ent.CodDepartamento = (string)(row.IsNull("CodDepartamento") ? Convert.ToString(null) : Convert.ToString(row["CodDepartamento"]).PadLeft(3, '0'));
                    ent.DescDepartamento = (string)(row.IsNull("DescDepartamento") ? null : row["DescDepartamento"]);
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
                    ent.Descricao = (string)(row.IsNull("Descricao") ? null : row["Descricao"]);
                    ent.EndCCB = (string)(row.IsNull("EndCCB") ? null : row["EndCCB"]);
                    ent.NumCCB = (string)(row.IsNull("NumCCB") ? null : row["NumCCB"]);
                    ent.BairroCCB = (string)(row.IsNull("BairroCCB") ? null : row["BairroCCB"]);
                    ent.ComplCCB = (string)(row.IsNull("ComplCCB") ? null : row["ComplCCB"]);
                    ent.CidadeCCB = (string)(row.IsNull("CidadeCCB") ? null : row["CidadeCCB"]);
                    ent.EstadoCCB = (string)(row.IsNull("EstadoCCB") ? null : row["EstadoCCB"]);
                    ent.CepCCB = (string)(row.IsNull("CepCCB") ? null : funcoes.FormataString("#####-###", row["CepCCB"].ToString()));
                    ent.TelefoneCCB = (string)(row.IsNull("TelefoneCCB") ? null : row["TelefoneCCB"]);
                    ent.CelularCCB = (string)(row.IsNull("CelularCCB") ? null : row["CelularCCB"]);
                    ent.EmailCCB = (string)(row.IsNull("EmailCCB") ? null : row["EmailCCB"]);
                    ent.EstadoCivil = (string)(row.IsNull("EstadoCivil") ? null : row["EstadoCivil"]);
                    ent.DataApresentacao = (string)(row.IsNull("DataApresentacao") ? Convert.ToString(null) : funcoes.IntData(row["DataApresentacao"].ToString()));
                    ent.PaisCCB = (string)(row.IsNull("PaisCCB") ? null : row["PaisCCB"]);
                    ent.Pai = (string)(row.IsNull("Pai") ? null : row["Pai"]);
                    ent.Mae = (string)(row.IsNull("Mae") ? null : row["Mae"]);
                    ent.InstrutorSeguro = (string)(row.IsNull("InstrutorSeguro") ? null : row["InstrutorSeguro"]);
                    ent.FormacaoFora = (string)(row.IsNull("FormacaoFora") ? null : row["FormacaoFora"]);
                    ent.LocalFormacao = (string)(row.IsNull("LocalFormacao") ? null : row["LocalFormacao"]);
                    ent.QualFormacao = (string)(row.IsNull("QualFormacao") ? null : row["QualFormacao"]);
                    ent.OutraOrquestra = (string)(row.IsNull("OutraOrquestra") ? null : row["OutraOrquestra"]);
                    ent.Orquestra1 = (string)(row.IsNull("Orquestra1") ? null : row["Orquestra1"]);
                    ent.Funcao1 = (string)(row.IsNull("Funcao1") ? null : row["Funcao1"]);
                    ent.Orquestra2 = (string)(row.IsNull("Orquestra2") ? null : row["Orquestra2"]);
                    ent.Funcao2 = (string)(row.IsNull("Funcao2") ? null : row["Funcao2"]);
                    ent.Orquestra3 = (string)(row.IsNull("Orquestra3") ? null : row["Orquestra3"]);
                    ent.Funcao3 = (string)(row.IsNull("Funcao3") ? null : row["Funcao3"]);
                    ent.AtendeComum = (string)(row.IsNull("AtendeComum") ? null : row["AtendeComum"]);
                    ent.AtendeRegiao = (string)(row.IsNull("AtendeRegiao") ? null : row["AtendeRegiao"]);
                    ent.AtendeGEM = (string)(row.IsNull("AtendeGEM") ? null : row["AtendeGEM"]);
                    ent.AtendeEnsaioLocal = (string)(row.IsNull("AtendeEnsaioLocal") ? null : row["AtendeEnsaioLocal"]);
                    ent.AtendeEnsaioRegional = (string)(row.IsNull("AtendeEnsaioRegional") ? null : row["AtendeEnsaioRegional"]);
                    ent.AtendeEnsaioParcial = (string)(row.IsNull("AtendeEnsaioParcial") ? null : row["AtendeEnsaioParcial"]);
                    ent.AtendeEnsaioTecnico = (string)(row.IsNull("AtendeEnsaioTecnico") ? null : row["AtendeEnsaioTecnico"]);
                    ent.AtendeReuniaoMocidade = (string)(row.IsNull("AtendeReuniaoMocidade") ? null : row["AtendeReuniaoMocidade"]);
                    ent.AtendeBatismo = (string)(row.IsNull("AtendeBatismo") ? null : row["AtendeBatismo"]);
                    ent.AtendeSantaCeia = (string)(row.IsNull("AtendeSantaCeia") ? null : row["AtendeSantaCeia"]);
                    ent.AtendeRJM = (string)(row.IsNull("AtendeRJM") ? null : row["AtendeRJM"]);
                    ent.AtendePreTesteRjmMusico = (string)(row.IsNull("AtendePreTesteRjmMusico") ? null : row["AtendePreTesteRjmMusico"]);
                    ent.AtendePreTesteRjmOrganista = (string)(row.IsNull("AtendePreTesteRjmOrganista") ? null : row["AtendePreTesteRjmOrganista"]);
                    ent.AtendeTesteRjmMusico = (string)(row.IsNull("AtendeTesteRjmMusico") ? null : row["AtendeTesteRjmMusico"]);
                    ent.AtendeTesteRjmOrganista = (string)(row.IsNull("AtendeTesteRjmOrganista") ? null : row["AtendeTesteRjmOrganista"]);
                    ent.AtendePreTesteCultoMusico = (string)(row.IsNull("AtendePreTesteCultoMusico") ? null : row["AtendePreTesteCultoMusico"]);
                    ent.AtendePreTesteCultoOrganista = (string)(row.IsNull("AtendePreTesteCultoOrganista") ? null : row["AtendePreTesteCultoOrganista"]);
                    ent.AtendeTesteCultoMusico = (string)(row.IsNull("AtendeTesteCultoMusico") ? null : row["AtendeTesteCultoMusico"]);
                    ent.AtendeTesteCultoOrganista = (string)(row.IsNull("AtendeTesteCultoOrganista") ? null : row["AtendeTesteCultoOrganista"]);
                    ent.AtendePreTesteOficialMusico = (string)(row.IsNull("AtendePreTesteOficialMusico") ? null : row["AtendePreTesteOficialMusico"]);
                    ent.AtendePreTesteOficialOrganista = (string)(row.IsNull("AtendePreTesteOficialOrganista") ? null : row["AtendePreTesteOficialOrganista"]);
                    ent.AtendeTesteOficialMusico = (string)(row.IsNull("AtendeTesteOficialMusico") ? null : row["AtendeTesteOficialMusico"]);
                    ent.AtendeTesteOficialOrganista = (string)(row.IsNull("AtendeTesteOficialOrganista") ? null : row["AtendeTesteOficialOrganista"]);
                    ent.AtendeReuniaoMinisterial = (string)(row.IsNull("AtendeReuniaoMinisterial") ? null : row["AtendeReuniaoMinisterial"]);
                    ent.AtendeCasal = (string)(row.IsNull("AtendeCasal") ? null : row["AtendeCasal"]);
                    ent.AtendeOrdenacao = (string)(row.IsNull("AtendeOrdenacao") ? null : row["AtendeOrdenacao"]);
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]);
                    ent.OrdemInstrumento = (string)(row.IsNull("OrdemInstrumento") ? Convert.ToString(null) : Convert.ToString(row["OrdemInstrumento"]).PadLeft(2, '0'));
                    ent.CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0'));
                    ent.DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]);
                    ent.CodCCBGem = (string)(row.IsNull("CodCCBGem") ? Convert.ToString(null) : Convert.ToString(row["CodCCBGem"]).PadLeft(6, '0'));
                    ent.CodigoCCBGem = (string)(row.IsNull("CodigoCCBGem") ? null : row["CodigoCCBGem"]);
                    ent.DescricaoCCBGem = (string)(row.IsNull("DescricaoCCBGem") ? null : row["DescricaoCCBGem"]);
                    ent.EndCCBGem = (string)(row.IsNull("EndCCBGem") ? null : row["EndCCBGem"]);
                    ent.NumCCBGem = (string)(row.IsNull("NumCCBGem") ? null : row["NumCCBGem"]);
                    ent.BairroCCBGem = (string)(row.IsNull("BairroCCBGem") ? null : row["BairroCCBGem"]);
                    ent.ComplCCBGem = (string)(row.IsNull("ComplCCBGem") ? null : row["ComplCCBGem"]);
                    ent.CidadeCCBGem = (string)(row.IsNull("CidadeCCBGem") ? null : row["CidadeCCBGem"]);
                    ent.EstadoCCBGem = (string)(row.IsNull("EstadoCCBGem") ? null : row["EstadoCCBGem"]);
                    ent.CepCCBGem = (string)(row.IsNull("CepCCBGem") ? null : funcoes.FormataString("#####-###", row["CepCCBGem"].ToString()));
                    ent.TelefoneCCBGem = (string)(row.IsNull("TelefoneCCBGem") ? null : row["TelefoneCCBGem"]);
                    ent.CelularCCBGem = (string)(row.IsNull("CelularCCBGem") ? null : row["CelularCCBGem"]);
                    ent.EmailCCBGem = (string)(row.IsNull("EmailCCBGem") ? null : row["EmailCCBGem"]);
                    ent.Desenvolvimento = (string)(row.IsNull("Desenvolvimento") ? null : row["Desenvolvimento"]);
                    ent.DataUltimoTeste = (string)(row.IsNull("DataUltimoTeste") ? Convert.ToString(null) : funcoes.IntData(row["DataUltimoTeste"].ToString()));
                    ent.DataInicioEstudo = (string)(row.IsNull("DataInicioEstudo") ? Convert.ToString(null) : funcoes.IntData(row["DataInicioEstudo"].ToString()));
                    ent.ExecutInstrumento = (string)(row.IsNull("ExecutInstrumento") ? null : row["ExecutInstrumento"]);
                    ent.CodInstrutor = (string)(row.IsNull("CodInstrutor") ? Convert.ToString(null) : Convert.ToString(row["CodInstrutor"]).PadLeft(6, '0'));
                    ent.NomeInstrutor = (string)(row.IsNull("NomeInstrutor") ? null : row["NomeInstrutor"]);
                    ent.CodRegiaoCCB = (string)(row.IsNull("CodRegiaoCCB") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoCCB"]).PadLeft(6, '0'));
                    ent.DescRegiaoCCB = (string)(row.IsNull("DescRegiaoCCB") ? null : row["DescRegiaoCCB"]);
                    ent.CodRegiaoCCBGem = (string)(row.IsNull("CodRegiaoCCBGem") ? Convert.ToString(null) : Convert.ToString(row["CodRegiaoCCBGem"]).PadLeft(6, '0'));
                    ent.DescRegiaoCCBGem = (string)(row.IsNull("DescRegiaoCCBGem") ? null : row["DescRegiaoCCBGem"]);
                    ent.MotivoInativa = (string)(row.IsNull("MotivoInativa") ? null : row["MotivoInativa"]);

                    ///Buscar informações sobre o cargo da pessoa
                    objBLL_Cargo = new BLL_buscaCargoPorCodigo();
                    ent.listaCargo = objBLL_Cargo.Buscar(ent.CodCargo);

                    ///preenche a lista com os dados da Tabela Fotos
                    objBLL_PessoaFoto = new BLL_buscaPessoaFotoPorCodPessoa();
                    ent.listaFotoPessoa = objBLL_PessoaFoto.Buscar(ent.CodPessoa);

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