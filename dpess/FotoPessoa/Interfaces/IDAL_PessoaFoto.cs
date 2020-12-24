using ENT.pessoa;
using System;

namespace DAL.pessoa
{
    public interface IDAL_PessoaFoto
    {
        bool Insert(MOD_pessoaFoto pessoaFoto);
        bool Update(MOD_pessoaFoto pessoaFoto);
        bool Delete(MOD_pessoaFoto pessoaFoto);
        Int64 RetornaId();
    }
}