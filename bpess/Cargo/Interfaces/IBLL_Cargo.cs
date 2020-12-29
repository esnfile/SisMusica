using ENT.pessoa;
using System;
using System.Collections.Generic;

namespace BLL.cargo
{
    public interface IBLL_Cargo :IDisposable
    {
        bool Update(MOD_cargo cargo, out List<MOD_cargo> listaCargo);
        bool Insert(MOD_cargo cargo, out List<MOD_cargo> listaCargo);
        bool Delete(MOD_cargo cargo);
        Int16 RetornaId();
    }
}
