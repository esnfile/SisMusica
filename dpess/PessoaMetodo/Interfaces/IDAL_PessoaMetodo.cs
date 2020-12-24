using ENT.pessoa;
using System;

namespace DAL.pessoa
{
    public interface IDAL_PessoaMetodo
    {
        bool Insert(MOD_pessoaMetodo pessoa);
        bool Delete(MOD_pessoaMetodo pessoa);
    }
}