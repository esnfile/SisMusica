using ENT.uteis;
using ENT.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.uteis
{
    public interface IValidacaoCidade
    {
        List<MOD_erros> ValidaCamposCidade(MOD_cidade cidade);

    }
}