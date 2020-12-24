using System.Data;

namespace DAL.importa
{
    public interface IDAL_buscaPorDescricaoImportaPessoa
    {
        DataTable Buscar(string descricao);
    }
}