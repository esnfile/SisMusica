using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.pessoa
{
    public class DAL_pessoa_StrSql : IDAL_Pessoa_StrSql
    {

        #region Strings SQL de Manipulação da Tabela Pessoa

        //string de insert na tabela Pessoa
        private string strInsert = "INSERT INTO Pessoa (CodPessoa, Ativo, DataCadastro, HoraCadastro, CodCargo, Nome, " +
"DataNasc, Cpf, Rg, Sexo, DataBatismo, CodCidadeRes, EndRes, NumRes, BairroRes, ComplRes, Telefone1, Telefone2, " +
"Celular1, Celular2, Email, CodCCB, EstadoCivil, DataApresentacao, PaisCCB, Pai, Mae, InstrutorSeguro, FormacaoFora, " +
"LocalFormacao, QualFormacao, OutraOrquestra, Orquestra1, Funcao1, Orquestra2, Funcao2, Orquestra3, Funcao3, AtendeComum, AtendeRegiao, " +
"AtendeGEM, AtendeEnsaioLocal, AtendeEnsaioRegional, AtendeEnsaioParcial, AtendeEnsaioTecnico, AtendeReuniaoMocidade, " +
"AtendeBatismo, AtendeSantaCeia, AtendeRJM, AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista, AtendeTesteRjmMusico, AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista, AtendeTesteCultoMusico, AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista, AtendeTesteOficialMusico, AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial, CodInstrumento, CodCCBGem, Desenvolvimento, DataUltimoTeste, DataInicioEstudo, ExecutInstrumento, " +
"CodInstrutor, OrgaoEmissor, MotivoInativa, CodigoRefBras, CodigoRefRegiao) " +
"VALUES (@CodPessoa, @Ativo, @DataCadastro, @HoraCadastro, @CodCargo, @Nome, " +
"@DataNasc, @Cpf, @Rg, @Sexo, @DataBatismo, @CodCidadeRes, @EndRes, @NumRes, @BairroRes, @ComplRes, @Telefone1, @Telefone2, " +
"@Celular1, @Celular2, @Email, @CodCCB, @EstadoCivil, @DataApresentacao, @PaisCCB, @Pai, @Mae, @InstrutorSeguro, @FormacaoFora, " +
"@LocalFormacao, @QualFormacao, @OutraOrquestra, @Orquestra1, @Funcao1, @Orquestra2, @Funcao2, @Orquestra3, @Funcao3, @AtendeComum, @AtendeRegiao, " +
"@AtendeGEM, @AtendeEnsaioLocal, @AtendeEnsaioRegional, @AtendeEnsaioParcial, @AtendeEnsaioTecnico, @AtendeReuniaoMocidade, " +
"@AtendeBatismo, @AtendeSantaCeia, @AtendeRJM, @AtendePreTesteRjmMusico, @AtendePreTesteRjmOrganista, @AtendeTesteRjmMusico, @AtendeTesteRjmOrganista, " +
"@AtendePreTesteCultoMusico, @AtendePreTesteCultoOrganista, @AtendeTesteCultoMusico, @AtendeTesteCultoOrganista, " +
"@AtendePreTesteOficialMusico, @AtendePreTesteOficialOrganista, @AtendeTesteOficialMusico, @AtendeTesteOficialOrganista," +
"@AtendeReuniaoMinisterial, @CodInstrumento, @CodCCBGem, @Desenvolvimento, @DataUltimoTeste, @DataInicioEstudo, " +
"@ExecutInstrumento, @CodInstrutor, @OrgaoEmissor, @MotivoInativa, @CodigoRefBras, @CodigoRefRegiao) ";

        //string de delete na tabela Pessoa
        private string strDelete = "DELETE FROM Pessoa WHERE CodPessoa = @CodPessoa ";

        //string que retorna o próximo Id da tabela Pessoa
        private string strRetornaId = "SELECT MAX (CodPessoa) FROM Pessoa ";

        //string de select na tabela Pessoa
        private string strSelect = "SELECT P.CodPessoa, P.Ativo, P.DataCadastro, P.HoraCadastro, P.CodCargo, P.Nome, " + //Tabela Pessoa
"P.DataNasc, P.Cpf, P.Rg, P.Sexo, P.DataBatismo, P.CodCidadeRes, P.EndRes, P.NumRes, P.BairroRes, P.ComplRes, P.Telefone1, P.Telefone2, " +
"P.Celular1, P.Celular2, P.Email, P.CodCCB, P.EstadoCivil, P.DataApresentacao, P.PaisCCB, P.Pai, P.Mae, P.InstrutorSeguro, P.FormacaoFora, " +
"P.LocalFormacao, P.QualFormacao, P.OutraOrquestra, P.Orquestra1, P.Funcao1, P.Orquestra2, P.Funcao2, P.Orquestra3, P.Funcao3, " +
"P.AtendeComum, P.AtendeRegiao, P.AtendeGEM, P.AtendeEnsaioLocal, P.AtendeEnsaioRegional, P.AtendeEnsaioParcial, P.AtendeEnsaioTecnico, " +
"P.AtendeReuniaoMocidade, P.AtendeBatismo, P.AtendeSantaCeia, P.AtendeRJM, P.AtendePreTesteRjmMusico, P.AtendePreTesteRjmOrganista, " +
"P.AtendeTesteRjmMusico, P.AtendeTesteRjmOrganista, P.AtendePreTesteCultoMusico, P.AtendePreTesteCultoOrganista, " +
"P.AtendeTesteCultoMusico, P.AtendeTesteCultoOrganista, P.AtendePreTesteOficialMusico, P.AtendePreTesteOficialOrganista, " +
"P.AtendeTesteOficialMusico, P.AtendeTesteOficialOrganista, P.AtendeReuniaoMinisterial, P.AtendeCasal, P.AtendeOrdenacao, " +
"P.CodInstrumento, P.CodCCBGem, P.Desenvolvimento, P.DataUltimoTeste, P.DataInicioEstudo, P.ExecutInstrumento, P.CodInstrutor, " +
"P.OrgaoEmissor, P.MotivoInativa, P.CodigoRefBras, P.CodigoRefRegiao, " +
"CG.DescCargo, CG.SiglaCargo, CG.Ordem AS OrdemCargo, CG.PermiteInstrumento, CG.CodDepartamento, DG.DescDepartamento, " + // Tabela Cargo
"C.Cidade AS CidadeRes, C.Estado AS EstadoRes, C.Cep AS CepRes, " + //Tabela Cidade
"CM.Codigo AS CodigoCCB, CM.Descricao, CM.Endereco AS EndCCB, CM.Numero AS NumCCB, CM.Bairro AS BairroCCB, CM.Complemento AS ComplCCB, " + //Tabela CCB Res
"CM.CodCidade AS CodCidadeCCB, CM.Telefone AS TelefoneCCB, CM.Celular AS CelularCCB, CM.Email AS EmailCCB, CM.CodRegiao AS CodRegiaoCCB, " +
"CC.Cidade AS CidadeCCB, CC.Estado AS EstadoCCB, CC.Cep AS CepCCB, " + //Tabela Cidade da CCB
"CMG.Codigo AS CodigoCCBGem, CMG.Descricao AS DescricaoCCBGem, CMG.Endereco AS EndCCBGem, CMG.Numero AS NumCCBGem, " + //Tabela CCB GEM
"CMG.Bairro AS BairroCCBGem, CMG.Complemento AS ComplCCBGem, CMG.CodCidade AS CodCidadeCCBGem, CMG.Telefone AS TelefoneCCBGem, " +
"CMG.Celular AS CelularCCBGem, CMG.Email AS EmailCCBGem, CMG.CodRegiao AS CodRegiaoCCBGem, " +
"CCG.Cidade AS CidadeCCBGem, CCG.Estado AS EstadoCCBGem, CCG.Cep AS CepCCBGem, " + //Tabela Cidade CCB GEM
"PI.Nome AS NomeInstrutor, " + //Tabela Pessoa (Instrutor)
"I.DescInstrumento, I.CodFamilia, I.Ordem AS OrdemInstrumento, " + //Tabela Instrumento
"F.DescFamilia, " + //Tabela Familia Instrumento
"R.Descricao AS DescRegiaoCCB, " + //Tabela Regiao CCB Res
"RG.Descricao AS DescRegiaoCCBGem " + //Tabela Regiao CCB GEM
"FROM Pessoa AS P " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS C ON P.CodCidadeRes = C.CodCidade " +
"LEFT OUTER JOIN CCB AS CM ON P.CodCCB = CM.CodCCB " +
"LEFT OUTER JOIN Pessoa AS PI ON P.CodInstrutor = PI.CodPessoa " +
"LEFT OUTER JOIN CCB AS CMG ON P.CodCCBGem = CMG.CodCCB " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Cidade AS CC ON CM.CodCidade = CC.CodCidade " +
"LEFT OUTER JOIN Cidade AS CCG ON CMG.CodCidade = CCG.CodCidade " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia " +
"LEFT OUTER JOIN Departamento AS DG ON CG.CodDepartamento = DG.CodDepartamento " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON CM.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN RegiaoAtuacao AS RG ON CMG.CodRegiao = RG.CodRegiao ";

        //string de update na tabela Pessoa
        private string strUpdate = "UPDATE Pessoa SET Ativo = @Ativo, DataCadastro = @DataCadastro, " +
"HoraCadastro = @HoraCadastro, CodCargo = @CodCargo, Nome = @Nome, DataNasc = @DataNasc, Cpf = @Cpf, Rg = @Rg, " +
"Sexo = @Sexo, DataBatismo = @DataBatismo, CodCidadeRes = @CodCidadeRes, EndRes = @EndRes, NumRes = @NumRes, " +
"BairroRes = @BairroRes, ComplRes = @ComplRes, Telefone1 = @Telefone1, Telefone2 = @Telefone2, " +
"Celular1 = @Celular1, Celular2 = @Celular2, Email = @Email, CodCCB = @CodCCB, EstadoCivil = @EstadoCivil, " +
"DataApresentacao = @DataApresentacao, PaisCCB = @PaisCCB, Pai = @Pai, Mae = @Mae, InstrutorSeguro = @InstrutorSeguro, " +
"FormacaoFora = @FormacaoFora, LocalFormacao = @LocalFormacao, QualFormacao = @QualFormacao, OutraOrquestra = @OutraOrquestra, Orquestra1 = @Orquestra1, " +
"Funcao1 = @Funcao1, Orquestra2 = @Orquestra2, Funcao2 = @Funcao2, Orquestra3 = @Orquestra3, Funcao3 = @Funcao3, " +
"AtendeComum = @AtendeComum, AtendeRegiao = @AtendeRegiao, AtendeGEM = @AtendeGEM, AtendeEnsaioLocal = @AtendeEnsaioLocal, " +
"AtendeEnsaioRegional = @AtendeEnsaioRegional, AtendeEnsaioParcial = @AtendeEnsaioParcial, AtendeEnsaioTecnico = @AtendeEnsaioTecnico, " +
"AtendeReuniaoMocidade = @AtendeReuniaoMocidade, AtendeBatismo = @AtendeBatismo, AtendeSantaCeia = @AtendeSantaCeia, " +
"AtendeRJM = @AtendeRJM, AtendePreTesteRjmMusico = @AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista = @AtendePreTesteRjmOrganista, " +
"AtendeTesteRjmMusico = @AtendeTesteRjmMusico, AtendeTesteRjmOrganista = @AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico = @AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista = @AtendePreTesteCultoOrganista, " +
"AtendeTesteCultoMusico = @AtendeTesteCultoMusico, AtendeTesteCultoOrganista = @AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico = @AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista = @AtendePreTesteOficialOrganista, " +
"AtendeTesteOficialMusico = @AtendeTesteOficialMusico, AtendeTesteOficialOrganista = @AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial = @AtendeReuniaoMinisterial, CodInstrumento = @CodInstrumento, CodCCBGem = @CodCCBGem, " +
"Desenvolvimento = @Desenvolvimento, DataUltimoTeste = @DataUltimoTeste, DataInicioEstudo = @DataInicioEstudo, " +
"ExecutInstrumento = @ExecutInstrumento, CodInstrutor = @CodInstrutor, OrgaoEmissor = @OrgaoEmissor, " +
"MotivoInativa = @MotivoInativa, CodigoRefBras = @CodigoRefBras, CodigoRefRegiao = @CodigoRefRegiao " +
"WHERE CodPessoa = @CodPessoa ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Update para a Tabela Pessoa
        /// </summary>
        /// <returns></returns>
        public string StrUpdate
        {
            get
            {
                return strUpdate;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Issert para a Tabela Pessoa
        /// </summary>
        /// <returns></returns>
        public string StrInsert
        {
            get
            {
                return strInsert;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Select para a Tabela Pessoa
        /// </summary>
        /// <returns></returns>
        public string StrSelect
        {
            get
            {
                return strSelect;
            }
        }

        /// <summary>
        /// Retorna a String SQL que Retorna Proximo ID da Tabela Pessoa
        /// </summary>
        /// <returns></returns>
        public string StrRetornaId
        {
            get
            {
                return strRetornaId;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Delete para a Tabela Pessoa
        /// </summary>
        /// <returns></returns>
        public string StrDelete
        {
            get
            {
                return strDelete;
            }
        }
    }
}