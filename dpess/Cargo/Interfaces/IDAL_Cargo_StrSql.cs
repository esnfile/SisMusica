using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.cargo
{
    public interface IDAL_Cargo_StrSql
    {
        string StrInsert { get; }
        string StrSelect { get; }
        string StrUpdate { get; }
        string StrDelete { get; }
        string StrRetornaId { get; }
    }
}