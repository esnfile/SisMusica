namespace DAL.pessoa
{
    public interface IDAL_pessoaFoto_StrSql
    {
        string StrInsert { get; }
        string StrSelect { get; }
        string StrUpdate { get; }
        string StrDelete { get; }
        string StrRetornaId { get; }
    }
}