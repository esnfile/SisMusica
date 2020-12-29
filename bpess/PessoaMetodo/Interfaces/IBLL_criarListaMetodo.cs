using ENT.pessoa;
using System.Collections.Generic;
using System.Data;

namespace BLL.pessoa
{
    public interface IBLL_criarListaMetodo
    {
        List<MOD_pessoaMetodo> CriarLista(DataTable objDtb);
    }
}