using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_instrumentoHinario
    {
        public string CodInstrumentoHino { get; set; }
        public string CodHinario { get; set; }
        public string DescHinario { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}
