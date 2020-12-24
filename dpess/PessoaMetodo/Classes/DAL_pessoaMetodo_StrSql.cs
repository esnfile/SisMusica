namespace DAL.pessoa
{
    public class DAL_pessoaMetodo_StrSql : IDAL_pessoaMetodo_StrSql
    {

        #region Strings SQL de Manipulação da Tabela PessoaMetodo

        //string de insert na tabela PessoaMetodo
        private readonly string strInsert = "INSERT INTO PessoaMetodo (CodPessoa, CodMetodo) " +
"VALUES (@CodPessoa, @CodMetodo) ";

        //string de delete na tabela PessoaMetodo
        private readonly string strDelete = "DELETE FROM PessoaMetodo WHERE CodPessoa = @CodPessoa AND CodMetodo = @CodMetodo ";

        //string de select na tabela PessoaMetodo
        private readonly string strSelect = "SELECT PM.CodPessoa, PM.CodMetodo, " +
"P.Nome, MI.CodInstrumento, MI.AplicarEm, MI.FaseInicio, MI.PaginaInicio, " +
"MI.LicaoInicio, MI.FaseFim, MI.PaginaFim, MI.LicaoFim, " +
"M.DescMetodo, M.Compositor, M.QtdePagina, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase, " +
"I.DescInstrumento, I.CodFamilia, I.Situacao, I.Ordem, " +
"F.DescFamilia " +
"FROM PessoaMetodo AS PM " +
"LEFT OUTER JOIN Pessoa AS P ON PM.CodPessoa = P.CodPessoa " +
"LEFT OUTER JOIN MetodoInstr AS MI ON PM.CodMetodo = MI.CodMetodo " +
"LEFT OUTER JOIN Metodos AS M ON MI.CodMetodo = M.CodMetodo " +
"LEFT OUTER JOIN Instrumentos AS I ON MI.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string de select na tabela Metodos
        private readonly string strSelectMetodos = "SELECT MI.CodInstrumento, MI.CodMetodo, MI.AplicarEm, MI.FaseInicio, MI.PaginaInicio, " +
"MI.LicaoInicio, MI.FaseFim, MI.PaginaFim, MI.LicaoFim, " +
"M.DescMetodo, M.Compositor, M.QtdePagina, M.Tipo, M.Ativo, M.TipoEscolha, M.PaginaFase, " +
"I.DescInstrumento, I.CodFamilia, I.Situacao, I.Ordem, " +
"F.DescFamilia " +
"FROM MetodoInstr AS MI " +
"LEFT OUTER JOIN Metodos AS M ON MI.CodMetodo = M.CodMetodo " +
"LEFT OUTER JOIN Instrumentos AS I ON MI.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        #endregion

        /// <summary>
        /// Retorna a String SQL de Issert para a Tabela PessoaMetodo
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
        /// Retorna a String SQL de Select para a Tabela PessoaMetodo
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
        /// Retorna a String SQL de Select para a Tabela Metodos
        /// </summary>
        /// <returns></returns>
        public string StrSelectMetodos
        {
            get
            {
                return strSelectMetodos;
            }
        }

        /// <summary>
        /// Retorna a String SQL de Delete para a Tabela PessoaMetodo
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