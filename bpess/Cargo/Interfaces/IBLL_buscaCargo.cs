using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.cargo
{
    /// <summary>
    ///Interface que fornece os parêmtros para retornar os dados da da Tabela Cargo
    ///Retorna uma lista com os registros buscados pela Descrição do Cargo
    /// </summary>
    public interface IBLL_buscaCargo
    {
        List<MOD_cargo> Buscar(string texto);
    }
}