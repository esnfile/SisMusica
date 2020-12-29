using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_PessoaCCB
    {
        bool Insert(List<MOD_pessoaCCB> objEnt);
        bool Delete(List<MOD_pessoaCCB> objEnt);
    }
}