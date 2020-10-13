using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.licao
{
    public class MOD_licaoTesteEscala
    {
        public string CodLicaoEscala { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string AplicaEm { get; set; }
        public string CodEscala { get; set; }
        public string DescEscala { get; set; }
        public string Modelo { get; set; }
        public string Tonica { get; set; }
        public string Alteracoes { get; set; }
        public string CodTipoEscala { get; set; }
        public string DescTipo { get; set; }

        public MOD_log Logs { get; set; }
    }
}
