using System.Data;

namespace DAL.pessoa
{
    public interface IDAL_buscaRegiaoPessoa
    {
        DataTable Buscar(string codPessoa);
        DataTable Buscar(string codPessoa, string codRegiao);
        DataTable Buscar(string codPessoa, string codInstrumento, string situacao);
    }
}