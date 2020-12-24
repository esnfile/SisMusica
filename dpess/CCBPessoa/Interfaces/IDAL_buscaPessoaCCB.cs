using System.Data;

namespace DAL.pessoa
{
    public interface IDAL_buscaPessoaCCB
    {
        DataTable Buscar(string codPessoa);
        DataTable Buscar(string codPessoa, string codCCB);
    }
}