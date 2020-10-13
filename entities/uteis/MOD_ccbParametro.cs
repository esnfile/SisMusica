using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.uteis
{
    public class MOD_ccbParametro
    {
        public string CodCCBParam { get; set; }
        public string CodCCB { get; set; }
        public string CodParametro { get; set; }
        public bool Marcado { get; set; }

        public List<MOD_log> Logs { get; set; }
        public List<MOD_pessoa> listaPessoa { get; set; }
    }
}
