using ENT.importa;
using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.importa
{
    public interface IBLL_ImportaPessoa
    {
        bool Update(MOD_importaPessoa objEnt, out List<MOD_importaPessoa> listaRetorno);
        bool Insert(MOD_importaPessoa objEnt, out List<MOD_importaPessoa> listaRetorno);
        bool Import(MOD_importaPessoaItem objEnt, out MOD_pessoa listaRetorno);
        bool Delete(MOD_importaPessoa objEnt);
        int RetornaId();
    }
}