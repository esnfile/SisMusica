using System.Data;

namespace DAL.importa
{
    public interface IDAL_buscaPorCodImportaPessoa
    {
        DataTable Buscar(string codImportaPessoa);
    }
}