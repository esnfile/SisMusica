namespace DAL.pessoa
{
    public class DAL_pessoaInstr_StrSql : IDAL_pessoaInstr_StrSql
    {

        #region Strings SQL de Manipulação da Tabela PessoaInstrumento

        //string de insert na tabela PessoaInstrumento
        private readonly string strInsert = "INSERT INTO PessoaInstr (CodPessoa, CodInstrumento) " +
"VALUES (@CodPessoa, @CodInstrumento) ";

        //string de delete na tabela PessoaInstrumento
        private readonly string strDelete = "DELETE FROM PessoaInstr WHERE CodPessoa = @CodPessoa AND CodInstrumento = @CodInstrumento ";

        //string de select na tabela PessoaInstrumento
        private string strSelect = "SELECT PI.CodPessoa, PI.CodInstrumento, " +
"P.Nome, I.DescInstrumento, I.CodFamilia, I.Situacao, I.Ordem, F.DescFamilia " +
"FROM PessoaInstr AS PI " +
"LEFT OUTER JOIN Pessoa AS P ON PI.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN Instrumentos AS I ON PI.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string de select na tabela Instrumentos
        private readonly string strSelectInstrumentos = "SELECT I.CodInstrumento, I.DescInstrumento, I.CodFamilia, I.Situacao, I.Ordem, F.DescFamilia " +
"FROM Instrumentos AS I " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Issert para a Tabela PessoaInstrumento
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
        /// Retorna a String SQL de Select para a Tabela PessoaInstrumento
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
        /// Retorna a String SQL de Select para a Tabela Instrumentos
        /// </summary>
        /// <returns></returns>
        public string StrSelectInstrumentos
        {
            get
            {
                return strSelectInstrumentos;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Delete para a Tabela PessoaInstrumento
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