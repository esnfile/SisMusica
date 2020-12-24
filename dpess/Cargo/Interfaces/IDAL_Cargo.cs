using ENT.pessoa;
using System;

namespace DAL.cargo
{
    public interface IDAL_Cargo
    {
        bool Insert(MOD_cargo cargo);
        bool Update(MOD_cargo cargo);
        bool Delete(MOD_cargo cargo);
        Int16 RetornaId();
    }
}