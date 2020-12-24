namespace DAL.pessoa
{
    public class DAL_pessoaCCB_StrSql : IDAL_pessoaCCB_StrSql
    {

        #region Strings SQL de Manipulação da Tabela PessoaCCB

        //string de insert na tabela PessoaCCB
        private readonly string strInsert = "INSERT INTO CCBPessoa (CodPessoa, CodCCB) " +
"VALUES (@CodPessoa, @CodCCB) ";

        //string de delete na tabela PessoaCCB
        private readonly string strDelete = "DELETE FROM CCBPessoa WHERE CodPessoa = @CodPessoa AND CodCCB = @CodCCB ";

        //string de select na tabela PessoaCCB
        private string strSelect = "SELECT PC.CodPessoa, PC.CodCCB, " + //Tabela CCBPessoa
"P.Nome, P.CodCargo, P.DataApresentacao, " + //Tabela Pessoa
"CG.DescCargo, CG.Ordem, " + //Tabela Cargo - Retorna Registros da Cidade do Cargo da Pessoa
"C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, C.Endereco, C.Numero, C.Bairro, C.CodCidade, C.CodRegiao, " + //Tabela CCB - Retorna Registros da Comum
"R.Codigo AS CodigoRegiao, R.Descricao AS DescricaoRegiao, " + //Tabela RegiaoAtuacao - Retorna Registros da Região da Comum
"CI.Cidade, CI.Estado, CI.Cep " + //Tabela Cidade - Retorna Registros da Cidade da Comum
"FROM CCBPessoa AS PC " +
"LEFT OUTER JOIN Pessoa AS P ON PC.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN CCB AS C ON PC.CodCCB = C.CodCCB " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Cidade AS CI ON C.CodCidade = CI.CodCidade ";

        //string de select na tabela CCB
        private readonly string strSelectCCB = "SELECT C.CodCCB, C.Codigo AS CodigoCCB, C.Descricao AS DescricaoCCB, C.Endereco, C.Numero, C.Bairro, C.CodCidade, C.CodRegiao, " +
"R.Codigo AS CodigoRegiao, R.Descricao AS DescricaoRegiao, " +
"CI.Cidade, CI.Estado, CI.Cep " +
"FROM CCB AS C " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON C.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN Cidade AS CI ON C.CodCidade = CI.CodCidade ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Issert para a Tabela PessoaCCB
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
        /// Retorna a String SQL de Select para a Tabela PessoaCCB
        /// </summary>
        /// <returns></returns>
        public string StrSelect
        {
            get
            {
                return strSelect;
            }
            set
            {
                if (value == "CCB")
                {
                    strSelect = strSelectCCB;
                }
            }
        }

        /// <summary>
        /// Retorna a String SQL de Select para a Tabela PessoaCCB
        /// </summary>
        /// <returns></returns>
        public string StrSelectCCB
        {
            get
            {
                return strSelectCCB;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Delete para a Tabela PessoaCCB
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