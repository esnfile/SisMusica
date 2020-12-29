using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaPessoaCCB
    {
        List<MOD_pessoaCCB> Buscar(string codPessoa);
        List<MOD_pessoaCCB> Buscar(string codPessoa, string codCCB);
    }
}