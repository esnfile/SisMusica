using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.licao
{
    public class MOD_licaoTesteHino
    {
        public string CodLicaoHino { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string AplicaEm { get; set; }
        public string CodHinario { get; set; }
        public string DescHinario { get; set; }
        public string CodTonalidade { get; set; }
        public string Nota { get; set; }
        public string Alteracoes { get; set; }
        public string DescTonalidade { get; set; }
        public string Hino { get; set; }

        public MOD_log Logs { get; set; }
    }
}
