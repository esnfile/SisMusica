using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.importa
{
    public interface IDAL_ImportaPessoa_StrSql
    {
        string StrInsert { get; }
        string StrSelect { get; }
        string StrUpdate { get; }
        string StrDelete { get; }
        string StrRetornaId { get; }
    }
}