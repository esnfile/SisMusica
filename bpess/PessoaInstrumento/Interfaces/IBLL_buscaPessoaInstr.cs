using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaPessoaInstr
    {
        List<MOD_pessoaInstr> Buscar(string codPessoa);
        List<MOD_pessoaInstr> Buscar(string codPessoa, string codInstrumento);
        List<MOD_pessoaInstr> Buscar(string codPessoa, string codInstrumento, string situacao);
    }
}