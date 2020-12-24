using ENT.pessoa;

namespace DAL.pessoa
{
    public interface IDAL_PessoaCCB
    {
        bool Insert(MOD_pessoaCCB ccbPessoa);
        bool Delete(MOD_pessoaCCB ccbPessoa);
    }
}