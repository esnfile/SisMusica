using ENT.importa;
using System.Collections.Generic;

namespace BLL.importa
{
    public interface IBLL_buscaPorDataImportaPessoa
    {
        List<MOD_importaPessoa> Buscar(string dataInicial, string dataFinal);
    }
}