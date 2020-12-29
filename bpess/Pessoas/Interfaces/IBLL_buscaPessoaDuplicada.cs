using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaPessoaDuplicada
    {
        List<MOD_pessoa> Buscar(string Nome, string DataNasc, string CodCidade);
    }
}