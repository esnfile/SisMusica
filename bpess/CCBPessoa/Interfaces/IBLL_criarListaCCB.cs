using ENT.pessoa;
using System.Collections.Generic;
using System.Data;

namespace BLL.pessoa
{
    public interface IBLL_criarListaCCB
    {
        List<MOD_pessoaCCB> CriarLista(DataTable objDtb);
    }
}