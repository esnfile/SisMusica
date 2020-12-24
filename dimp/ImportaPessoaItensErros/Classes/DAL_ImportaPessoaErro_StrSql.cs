namespace DAL.importa
{
    public class DAL_ImportaPessoaErro_StrSql : IDAL_ImportaPessoaErro_StrSql
    {
        #region Strings SQL de Manipulação da Tabela ImportaPessoaItemErro

        //string de insert na tabela ImportaPessoaItemErro
        private readonly string strInsert = "INSERT INTO ImportaPessoaItemErro (CodImportaPessoaItem, CodImportaPessoa, DataCadastro, " +
"HoraCadastro, CodCargo, Nome, DataNasc, Cpf, Rg, Sexo, DataBatismo, CodCidadeRes, EndRes, NumRes, BairroRes, ComplRes, Telefone1, Telefone2, " +
"Celular1, Celular2, Email, CodCCB, EstadoCivil, DataApresentacao, PaisCCB, Pai, Mae, FormacaoFora, " +
"LocalFormacao, QualFormacao, OutraOrquestra, Orquestra1, Funcao1, Orquestra2, Funcao2, Orquestra3, Funcao3, " +
"CodInstrumento, CodCCBGem, Desenvolvimento, DataUltimoTeste, DataInicioEstudo, ExecutInstrumento, CidadeRes, CepRes, DescInstrumento, DescCargo, " +
"DescCCB, DescCCBGem, EstadoRes, OrgaoEmissor)  " +
"VALUES (@CodImportaPessoaItem, @CodImportaPessoa, @DataCadastro, @HoraCadastro, @CodCargo, @Nome, @DataNasc, " +
"@Cpf, @Rg, @Sexo, @DataBatismo, @CodCidadeRes, @EndRes, @NumRes, @BairroRes, @ComplRes, @Telefone1, @Telefone2, " +
"@Celular1, @Celular2, @Email, @CodCCB, @EstadoCivil, @DataApresentacao, @PaisCCB, @Pai, @Mae, @FormacaoFora, " +
"@LocalFormacao, @QualFormacao, @OutraOrquestra, @Orquestra1, @Funcao1, @Orquestra2, @Funcao2, @Orquestra3, @Funcao3, " +
"@CodInstrumento, @CodCCBGem, @Desenvolvimento, @DataUltimoTeste, @DataInicioEstudo, @ExecutInstrumento, @CidadeRes, @CepRes, " +
"@DescInstrumento, @DescCargo, @DescCCB, @DescCCBGem, @EstadoRes, @OrgaoEmissor) ";

        //string de delete na tabela ImportaPessoaItemErro
        private readonly string strDelete = "DELETE FROM ImportaPessoaItemErro WHERE CodImportaPessoaItem = @CodImportaPessoaItem ";

        //string que retorna o próximo Id da tabela ImportaPessoaItemErro
        private readonly string strRetornaId = "SELECT MAX(CodImportaPessoaItem) FROM ImportaPessoaItemErro ";

        //string de select na tabela ImportaPessoaItemErro
        private readonly string strSelect = "SELECT P.CodImportaPessoaItem, P.CodImportaPessoa, P.DataCadastro, " +
"P.HoraCadastro, P.CodCargo, P.Nome, P.DataNasc, P.Cpf, P.Rg, P.Sexo, P.DataBatismo, P.CodCidadeRes, P.EndRes, " +
"P.NumRes, P.BairroRes, P.ComplRes, P.Telefone1, P.Telefone2, P.Celular1, P.Celular2, P.Email, P.CodCCB, P.EstadoCivil, " +
"P.DataApresentacao, P.PaisCCB, P.Pai, P.Mae, P.FormacaoFora, P.LocalFormacao, P.QualFormacao, P.OutraOrquestra, P.Orquestra1, " +
"P.Funcao1, P.Orquestra2, P.Funcao2, P.Orquestra3, P.Funcao3, P.CodInstrumento, P.CodCCBGem, P.Desenvolvimento, P.DataUltimoTeste, " +
"P.DataInicioEstudo, P.ExecutInstrumento, P.CidadeRes, P.CepRes, P.DescInstrumento, P.DescCargo, P.DescCCB, P.DescCCBGem, P.EstadoRes, P.OrgaoEmissor " +
"FROM ImportaPessoaItemErro AS P ";

        //string de update na tabela ImportaPessoaItemErro
        private readonly string strUpdate = "UPDATE ImportaPessoaItemErro SET CodImportaPessoa = @CodImportaPessoa, DataCadastro = @DataCadastro, " +
"HoraCadastro = @HoraCadastro, CodCargo = @CodCargo, Nome = @Nome, DataNasc = @DataNasc, Cpf = @Cpf, Rg = @Rg, " +
"Sexo = @Sexo, DataBatismo = @DataBatismo, CodCidadeRes = @CodCidadeRes, EndRes = @EndRes, NumRes = @NumRes, " +
"BairroRes = @BairroRes, ComplRes = @ComplRes, Telefone1 = @Telefone1, Telefone2 = @Telefone2, " +
"Celular1 = @Celular1, Celular2 = @Celular2, Email = @Email, CodCCB = @CodCCB, EstadoCivil = @EstadoCivil, " +
"DataApresentacao = @DataApresentacao, PaisCCB = @PaisCCB, Pai = @Pai, Mae = @Mae, " +
"FormacaoFora = @FormacaoFora, LocalFormacao = @LocalFormacao, QualFormacao = @QualFormacao, OutraOrquestra = @OutraOrquestra, Orquestra1 = @Orquestra1, " +
"Funcao1 = @Funcao1, Orquestra2 = @Orquestra2, Funcao2 = @Funcao2, Orquestra3 = @Orquestra3, Funcao3 = @Funcao3, " +
"CodInstrumento = @CodInstrumento, Desenvolvimento = @Desenvolvimento, DataUltimoTeste = @DataUltimoTeste, DataInicioEstudo = @DataInicioEstudo, " +
"ExecutInstrumento = @ExecutInstrumento, CidadeRes = @CidadeRes, CepRes = @CepRes, DescInstrumento = @DescInstrumento, DescCargo = @DescCargo, " +
"DescCCB = @DescCCB, DescCCBGem = @DescCCBGem, EstadoRes = @EstadoRes, OrgaoEmissor = @OrgaoEmissor " +
"WHERE CodImportaPessoaItem = @CodImportaPessoaItem ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Update para a Tabela ImportaPessoaItemErro
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
        /// Retorna a String SQL de Issert para a Tabela ImportaPessoaItemErro
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
        /// Retorna a String SQL de Select para a Tabela ImportaPessoaItemErro
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
        /// Retorna a String SQL que Retorna Proximo ID da Tabela ImportaPessoaItemErro
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
        /// Retorna a String SQL de Delete para a Tabela ImportaPessoaItemErro
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
