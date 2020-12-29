using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_PessoaFoto
    {
        bool Insert(MOD_pessoaFoto pessoaFoto);
        bool Update(MOD_pessoaFoto pessoaFoto);
        bool Delete(MOD_pessoaFoto pessoaFoto);
    }
}