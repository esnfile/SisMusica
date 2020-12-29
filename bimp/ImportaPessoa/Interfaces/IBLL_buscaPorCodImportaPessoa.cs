using ENT.importa;
using System.Collections.Generic;

namespace BLL.importa
{
    public interface IBLL_buscaPorCodImportaPessoa
    {
        List<MOD_importaPessoa> Buscar(string codImportaPessoa);
    }
}