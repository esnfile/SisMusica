using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.uteis
{
    public class MOD_uf
    {
        public string Sigla { get; set; }
        public string Uf { get; set; }

        public List<MOD_log> Logs { get; set; }
    }
}
