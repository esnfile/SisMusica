using ENT.pessoa;
using System;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_PessoaMetodo
    {
        bool Update(List<MOD_pessoaMetodo> objEnt);
    }
}