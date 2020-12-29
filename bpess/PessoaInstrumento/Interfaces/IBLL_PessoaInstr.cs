using ENT.pessoa;
using System;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_PessoaInstr
    {
        bool Update(List<MOD_pessoaInstr> objEnt);
    }
}