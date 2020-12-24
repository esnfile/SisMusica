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
        public static int ProgEscala { get; } = 10;
        public static int RotInsEscala { get; } = 30;
        public static int RotEditEscala { get; } = 31;
        public static int RotExcEscala { get; } = 32;
        public static int RotVisEscala { get; } = 33;
    }
}