using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.pessoa
{
    public interface IDAL_Pessoa_StrSql
    {
        string StrInsert { get; }
        string StrSelect { get; }
        string StrUpdate { get; }
        string StrDelete { get; }
        string StrRetornaId { get; }
    }
}