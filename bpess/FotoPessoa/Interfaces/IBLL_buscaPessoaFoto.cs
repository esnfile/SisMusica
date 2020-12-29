using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaPessoaFoto
    {
        List<MOD_pessoaFoto> Buscar(string codPessoa);
    }
}