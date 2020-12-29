using ENT.pessoa;
using ENT.Erros;
using System.Collections.Generic;

namespace BLL.cargo
{
    public interface IValidacaoCargo
    {
        List<MOD_erros> ValidaCamposCargo(MOD_cargo cargo);
    }
}