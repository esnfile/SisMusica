using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public interface IBLL_PessoaImporta
    {
        bool Import(MOD_pessoa objEnt, out List<MOD_pessoa> listaRetorno);
    }
}