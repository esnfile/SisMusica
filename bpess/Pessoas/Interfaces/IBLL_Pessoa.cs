using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public interface IBLL_Pessoa
    {
        bool Update(MOD_pessoa objEnt, out List<MOD_pessoa> listaRetorno);
        bool Insert(MOD_pessoa objEnt, out List<MOD_pessoa> listaRetorno);
        bool Delete(MOD_pessoa objEnt);
        Int64 RetornaId();
    }
}
