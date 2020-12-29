using ENT.importa;
using System.Collections.Generic;

namespace BLL.importa
{
    public interface IBLL_buscaPorDescricaoImportaPessoa
    {
        List<MOD_importaPessoa> Buscar(string descricao);
    }
}