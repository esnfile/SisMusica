using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_instrumentoVozAlternativa
    {
        public string CodInstrumentoVoz { get; set; }
        public string CodVoz { get; set; }
        public string DescVoz { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public bool Escrita { get; set; }
        public bool Acima { get; set; }
        public bool Abaixo { get; set; }

        public MOD_log Logs { get; set; }
    }
}
