using ENT.importa;
using System;

namespace DAL.importa
{
    public interface IDAL_ImportaPessoa
    {
        bool Insert(MOD_importaPessoa importa);
        bool Update(MOD_importaPessoa importa);
        bool Delete(MOD_importaPessoa importa);
        Int32 RetornaId();
    }
}