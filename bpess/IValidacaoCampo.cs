using ENT.pessoa;
using ENT.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public interface IValidacaoCampo
    {

        List<MOD_erros> ValidaCamposPessoa(MOD_pessoa pessoa);
        List<MOD_erros> ValidaCamposCargo(MOD_cargo cargo);
    }
}