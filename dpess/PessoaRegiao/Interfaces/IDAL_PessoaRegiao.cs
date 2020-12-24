using ENT.pessoa;
using System;

namespace DAL.pessoa
{
    public interface IDAL_PessoaRegiao
    {
        bool Insert(MOD_regiaoPessoa pessoa);
        bool Update(MOD_pessoaInstr pessoa);
        bool Delete(MOD_pessoaInstr pessoa);
        Int64 RetornaId();
    }
}