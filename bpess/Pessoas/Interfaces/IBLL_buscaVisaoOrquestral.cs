using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaVisaoOrquestral
    {
        List<MOD_pessoa> Buscar(string CodInstrumento, string CodCCB, bool Ativo);
    }
}