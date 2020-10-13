using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.orquestra
{
    public class MOD_visaoOrquestral
    {
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string DescFamilia { get; set; }
        public string CodFamilia { get; set; }
        public string TotalSopranoNatural { get; set; }
        public string TotalContralto { get; set; }
        public string TotalTenor { get; set; }
        public string TotalBaixoNatural { get; set; }
        public string TotalBaixoOitava { get; set; }
        public string TotalSopranoOitava { get; set; }
        public string TotalInstrumentos { get; set; }

        public string Sequencia { get; set; }

    }
}
