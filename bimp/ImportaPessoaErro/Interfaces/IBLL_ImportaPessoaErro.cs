using ENT.importa;
using System;
using System.Collections.Generic;

namespace BLL.importa
{
    /// <summary>
    /// Regra de Negócio que envia para a DAL, essa classe e responsável por definir quais operações serão realizadas na Tabela ImportaPessoaItemErro
    /// </summary>
    public interface IBLL_ImportaPessoaErro
    {
        bool Insert(MOD_importaPessoaItemErro ent);
        bool Update(MOD_importaPessoaItemErro ent);
        bool Delete(MOD_importaPessoaItemErro ent);
        Int64 RetornaId();
    }
}