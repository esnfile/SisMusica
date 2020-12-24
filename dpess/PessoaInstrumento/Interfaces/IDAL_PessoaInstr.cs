using ENT.pessoa;
using System;

namespace DAL.pessoa
{
    public interface IDAL_PessoaInstr
    {
        bool Insert(MOD_pessoaInstr pessoa);
        bool Delete(MOD_pessoaInstr pessoa);
    }
}