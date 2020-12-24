using System.Data;

namespace DAL.pessoa
{
    public interface IDAL_buscaPessoaFoto
    {
        DataTable Buscar(string texto);
    }
}