using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_voz
    {
        public string CodVoz { get; set; }
        public string DescVoz { get; set; }
        public string NotaGrave { get; set; }
        public string PosGrave { get; set; }
        public string NotaAguda { get; set; }
        public string PosAguda { get; set; }
        public string Tessitura { get; set; }

        public MOD_log Logs { get; set; }
    }
}
