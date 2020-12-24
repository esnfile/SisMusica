using ENT.importa;
using System;

namespace DAL.importa
{
    public interface IDAL_ImportaPessoaItem
    {
        bool Insert(MOD_importaPessoaItem importa);
        bool Update(MOD_importaPessoaItem importa);
        bool Delete(MOD_importaPessoaItem importa);
        Int64 RetornaId();
    }
}