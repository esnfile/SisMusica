using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.pessoa
{
    public interface IDAL_pessoaInstr_StrSql
    {
        string StrInsert { get; }
        string StrSelect { get; }
        string StrSelectInstrumentos { get; }
        string StrDelete { get; }
    }
}