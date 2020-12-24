using ENT.importa;
using System;

namespace DAL.importa
{
    public interface IDAL_ImportaPessoaItemErro
    {
        bool Insert(MOD_importaPessoaItemErro importa);
        bool Update(MOD_importaPessoaItemErro importa);
        bool Delete(MOD_importaPessoaItemErro importa);
        Int64 RetornaId();
    }
}