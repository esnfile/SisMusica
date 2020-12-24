using System.Data;

namespace DAL.pessoa
{
    public interface IDAL_buscaPessoaInstr
    {
        DataTable Buscar(string codPessoa);
        DataTable Buscar(string codPessoa, string codInstrumento);
        DataTable Buscar(string codPessoa, string codInstrumento, string situacao);
    }
}