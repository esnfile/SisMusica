namespace DAL.pessoa
{
    public class DAL_pessoaFoto_StrSql : IDAL_pessoaFoto_StrSql
    {

        #region Strings SQL de Manipulação da Tabela Pessoa

        //string de insert na tabela PessoaFoto
        private readonly string strInsert = "INSERT INTO PessoaFoto (CodFoto, CodPessoa, Foto) " +
"VALUES (@CodFoto, @CodPessoa, @Foto) ";

        //string de delete na tabela PessoaFoto
        private readonly string strDelete = "DELETE FROM PessoaFoto WHERE CodFoto = @CodFoto ";

        //string que retorna o próximo Id da tabela PessoaFoto
        private readonly string strRetornaId = "SELECT MAX (CodFoto) FROM PessoaFoto ";

        //string de select na tabela PessoaFoto
        private readonly string strSelect = "SELECT F.CodFoto, F.CodPessoa, F.Foto, " +
"P.Nome " +
"FROM PessoaFoto AS F " +
"LEFT OUTER JOIN Pessoa AS P ON F.CodPessoa = P.CodPessoa ";

        //string de update na tabela PessoaFoto
        private readonly string strUpdate = "UPDATE PessoaFoto SET CodPessoa = @CodPessoa, Foto = @Foto " +
"WHERE CodFoto = @CodFoto ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Update para a Tabela PessoaFoto
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
        /// Retorna a String SQL de Issert para a Tabela PessoaFoto
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
        /// Retorna a String SQL de Select para a Tabela PessoaFoto
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
        /// Retorna a String SQL que Retorna Proximo ID da Tabela PessoaFoto
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
        /// Retorna a String SQL de Delete para a Tabela PessoaFoto
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