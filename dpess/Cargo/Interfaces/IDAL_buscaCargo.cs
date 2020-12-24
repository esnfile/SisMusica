using System.Data;

namespace DAL.cargo
{
    public interface IDAL_buscaCargo
    {
        DataTable Buscar(string texto);
    }
}