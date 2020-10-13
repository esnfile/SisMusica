using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_instrumentoFoto
    {
        public string CodFoto { get; set; }
        public string CodInstrumento { get; set; }
        public string Foto { get; set; }

        public MOD_log Logs { get; set; }
    }
}
