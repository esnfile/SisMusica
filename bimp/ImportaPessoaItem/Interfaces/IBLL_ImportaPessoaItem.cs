using ENT.importa;
using System;

namespace BLL.importa
{
    /// <summary>
    /// Regra de Negócio: Classe é responsável por realizar as operações de Insert, Update e Delete os dados na Tabela ImportaPessoaItem
    /// </summary>
    public interface IBLL_ImportaPessoaItem
    {
        bool Insert(MOD_importaPessoaItem ent);
        bool Update(MOD_importaPessoaItem ent);
        bool Delete(MOD_importaPessoaItem ent);
        Int64 RetornaId();
    }
}