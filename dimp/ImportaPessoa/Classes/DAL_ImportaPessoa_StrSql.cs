namespace DAL.importa
{
    public class DAL_ImportaPessoa_StrSql : IDAL_ImportaPessoa_StrSql
    {

        #region Strings SQL de Manipulação da Tabela ImportaPessoa

        //string de insert na tabela ImportaPessoa
        private readonly string strInsert = "INSERT INTO ImportaPessoa (CodImportaPessoa, DataImporta, HoraImporta, CodUsuario, QtdeArquivo, Descricao) " +
"VALUES (@CodImportaPessoa, @DataImporta, @HoraImporta, @CodUsuario, @QtdeArquivo, @Descricao) ";

        //string de delete na tabela ImportaPessoa
        private readonly string strDelete = "DELETE FROM ImportaPessoa WHERE CodImportaPessoa = @CodImportaPessoa ";

        //string que retorna o próximo Id da tabela ImportaPessoa
        private readonly string strRetornaId = "SELECT MAX (CodImportaPessoa) FROM ImportaPessoa ";

        //string de select na tabela ImportaPessoa
        private readonly string strSelect = "SELECT I.CodImportaPessoa, I.DataImporta, I.CodUsuario, I.HoraImporta, I.QtdeArquivo, I.Descricao, " +
"U.CodPessoa, U.Usuario, P.Nome " +
"FROM ImportaPessoa AS I " +
"LEFT OUTER JOIN Usuario AS U ON I.CodUsuario = U.CodUsuario " +
"LEFT OUTER JOIN Pessoa AS P ON U.CodPessoa = P.CodPessoa ";

        //string de update na tabela ImportaPessoa
        private readonly string strUpdate = "UPDATE ImportaPessoa SET DataImporta = @DataImporta, HoraImporta = @HoraImporta, CodUsuario = @CodUsuario, " +
"QtdeArquivo = @QtdeArquivo, Descricao = @Descricao " +
"WHERE CodImportaPessoa = @CodImportaPessoa ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Update para a Tabela ImportaPessoa
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
        /// Retorna a String SQL de Issert para a Tabela ImportaPessoa
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
        /// Retorna a String SQL de Select para a Tabela ImportaPessoa
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
        /// Retorna a String SQL que Retorna Proximo ID da Tabela ImportaPessoa
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
        /// Retorna a String SQL de Delete para a Tabela ImportaPessoa
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