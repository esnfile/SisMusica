using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_escala
    {
        public string CodEscala { get; set; }
        public string DescEscala { get; set; }
        public string Modelo { get; set; }
        public string Tonica { get; set; }
        public string Alteracoes { get; set; }
        public string CodTipoEscala { get; set; }
        public string DescTipo { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoEscala
    {
        public int progEscala { get; set; } = 10;
        public int rotInsEscala { get; set; } = 30;
        public int rotEditEscala { get; set; } = 31;
        public int rotExcEscala { get; set; } = 32;
        public int rotVisEscala { get; set; } = 33;
    }
}