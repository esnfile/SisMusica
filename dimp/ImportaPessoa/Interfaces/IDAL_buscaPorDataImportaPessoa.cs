using System.Data;

namespace DAL.importa
{
    public interface IDAL_buscaPorDataImportaPessoa
    {
        DataTable Buscar(string dataInicial, string dataFinal);
    }
}