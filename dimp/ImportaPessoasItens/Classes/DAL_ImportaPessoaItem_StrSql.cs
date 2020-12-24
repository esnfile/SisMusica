namespace DAL.importa
{
    public class DAL_ImportaPessoaItem_StrSql : IDAL_ImportaPessoaItem_StrSql
    {
        #region Strings SQL de Manipulação da Tabela ImportaPessoaItem

        //string de insert na tabela ImportaPessoaItem
        private readonly string strInsert = "INSERT INTO ImportaPessoaItem (CodImportaPessoaItem, CodImportaPessoa, DataCadastro, " +
"HoraCadastro, CodCargo, Nome, DataNasc, Cpf, Rg, Sexo, DataBatismo, CodCidadeRes, EndRes, NumRes, BairroRes, ComplRes, Telefone1, Telefone2, " +
"Celular1, Celular2, Email, CodCCB, EstadoCivil, DataApresentacao, PaisCCB, Pai, Mae, FormacaoFora, " +
"LocalFormacao, QualFormacao, OutraOrquestra, Orquestra1, Funcao1, Orquestra2, Funcao2, Orquestra3, Funcao3, " +
"CodInstrumento, Desenvolvimento, DataUltimoTeste, DataInicioEstudo, ExecutInstrumento, Importado, CodPessoa, OrgaoEmissor)  " +
"VALUES (@CodImportaPessoaItem, @CodImportaPessoa, @DataCadastro, @HoraCadastro, @CodCargo, @Nome, @DataNasc, " +
"@Cpf, @Rg, @Sexo, @DataBatismo, @CodCidadeRes, @EndRes, @NumRes, @BairroRes, @ComplRes, @Telefone1, @Telefone2, " +
"@Celular1, @Celular2, @Email, @CodCCB, @EstadoCivil, @DataApresentacao, @PaisCCB, @Pai, @Mae, @FormacaoFora, " +
"@LocalFormacao, @QualFormacao, @OutraOrquestra, @Orquestra1, @Funcao1, @Orquestra2, @Funcao2, @Orquestra3, @Funcao3, " +
"@CodInstrumento, @Desenvolvimento, @DataUltimoTeste, @DataInicioEstudo, @ExecutInstrumento, @Importado, @CodPessoa, @OrgaoEmissor) ";

        //string de delete na tabela ImportaPessoaItem
        private readonly string strDelete = "DELETE FROM ImportaPessoaItem WHERE CodImportaPessoaItem = @CodImportaPessoaItem ";

        //string que retorna o próximo Id da tabela ImportaPessoaItem
        private readonly string strRetornaId = "SELECT MAX(CodImportaPessoaItem) FROM ImportaPessoaItem ";

        //string de select na tabela ImportaPessoaItem
        private readonly string strSelect = "SELECT P.CodImportaPessoaItem, P.CodImportaPessoa, P.DataCadastro, P.HoraCadastro, P.CodCargo, P.Nome, " +
"P.DataNasc, P.Cpf, P.Rg, P.Sexo, P.DataBatismo, P.CodCidadeRes, P.EndRes, P.NumRes, P.BairroRes, P.ComplRes, P.Telefone1, P.Telefone2, " +
"P.Celular1, P.Celular2, P.Email, P.CodCCB, P.EstadoCivil, P.DataApresentacao, P.PaisCCB, P.Pai, P.Mae, P.FormacaoFora, " +
"P.LocalFormacao, P.QualFormacao, P.OutraOrquestra, P.Orquestra1, P.Funcao1, P.Orquestra2, P.Funcao2, P.Orquestra3, P.Funcao3, " +
"P.CodInstrumento, P.CodCCBGem, P.Desenvolvimento, P.DataUltimoTeste, P.DataInicioEstudo, P.ExecutInstrumento, P.Importado, P.CodPessoa, P.OrgaoEmissor, " +
"CG.DescCargo, CG.SiglaCargo, CG.Ordem, " +
"C.Cidade AS CidadeRes, C.Estado AS EstadoRes, C.Cep AS CepRes, " +
"CM.Codigo AS CodigoCCB, CM.Descricao AS DescricaoCCB, CM.Endereco AS EndCCB, CM.Numero AS NumCCB, CM.Bairro AS BairroCCB, " +
"CM.Complemento AS ComplCCB, CM.CodCidade AS CodCidadeCCB, CM.Telefone AS TelefoneCCB, CM.Celular AS CelularCCB, CM.Email AS EmailCCB, " +
"CMG.Codigo AS CodigoCCBGem, CMG.Descricao AS DescricaoCCBGem, " +
"CC.Cidade AS CidadeCCB, CC.Estado AS EstadoCCB, CC.Cep AS CepCCB, " +
"I.DescInstrumento, I.CodFamilia, " +
"F.DescFamilia " +
"FROM ImportaPessoaItem AS P " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS C ON P.CodCidadeRes = C.CodCidade " +
"LEFT OUTER JOIN CCB AS CM ON P.CodCCB = CM.CodCCB " +
"LEFT OUTER JOIN CCB AS CMG ON P.CodCCBGem = CMG.CodCCB " +
"LEFT OUTER JOIN Cidade AS CC ON CM.CodCidade = CC.CodCidade " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string de update na tabela ImportaPessoaItem
        private readonly string strUpdate = "ImportaPessoaItem SET CodImportaPessoa = @CodImportaPessoa, DataCadastro = @DataCadastro, " +
"HoraCadastro = @HoraCadastro, CodCargo = @CodCargo, Nome = @Nome, DataNasc = @DataNasc, Cpf = @Cpf, Rg = @Rg, " +
"Sexo = @Sexo, DataBatismo = @DataBatismo, CodCidadeRes = @CodCidadeRes, EndRes = @EndRes, NumRes = @NumRes, " +
"BairroRes = @BairroRes, ComplRes = @ComplRes, Telefone1 = @Telefone1, Telefone2 = @Telefone2, " +
"Celular1 = @Celular1, Celular2 = @Celular2, Email = @Email, CodCCB = @CodCCB, EstadoCivil = @EstadoCivil, " +
"DataApresentacao = @DataApresentacao, PaisCCB = @PaisCCB, Pai = @Pai, Mae = @Mae, " +
"FormacaoFora = @FormacaoFora, LocalFormacao = @LocalFormacao, QualFormacao = @QualFormacao, OutraOrquestra = @OutraOrquestra, Orquestra1 = @Orquestra1, " +
"Funcao1 = @Funcao1, Orquestra2 = @Orquestra2, Funcao2 = @Funcao2, Orquestra3 = @Orquestra3, Funcao3 = @Funcao3, " +
"CodInstrumento = @CodInstrumento, " +
"Desenvolvimento = @Desenvolvimento, DataUltimoTeste = @DataUltimoTeste, DataInicioEstudo = @DataInicioEstudo, " +
"ExecutInstrumento = @ExecutInstrumento, Importado = @Importado, CodPessoa = @CodPessoa, OrgaoEmissor = @OrgaoEmissor " +
"WHERE CodImportaPessoaItem = @CodImportaPessoaItem ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Update para a Tabela ImportaPessoaItem
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
        /// Retorna a String SQL de Issert para a Tabela ImportaPessoaItem
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
        /// Retorna a String SQL de Select para a Tabela ImportaPessoaItem
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
        /// Retorna a String SQL que Retorna Proximo ID da Tabela ImportaPessoaItem
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
        /// Retorna a String SQL de Delete para a Tabela ImportaPessoaItem
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
