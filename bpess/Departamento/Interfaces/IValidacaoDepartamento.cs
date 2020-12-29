using ENT.pessoa;
using ENT.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public interface IValidacaoDepartamento
    {
        List<MOD_erros> ValidaCamposDepartamento(MOD_departamento departamento);

    }
}