using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_instrumentoTom
    {
        public string CodInstrumentoTom { get; set; }
        public string CodTonalidade { get; set; }
        public string DescTonalidade { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}
