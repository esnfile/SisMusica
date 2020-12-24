using ENT.pessoa;
using System;

namespace DAL.pessoa
{
    public interface IDAL_Pessoa
    {
        bool Insert(MOD_pessoa pessoa);
        bool Update(MOD_pessoa pessoa);
        bool Delete(MOD_pessoa pessoa);
        Int64 RetornaId();
    }
}