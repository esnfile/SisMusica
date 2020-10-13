using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_tipoEscala
    {
        public string CodTipoEscala { get; set; }
        public string DescTipo { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoTipoEscala
    {
        public int progTipoEscala { get; set; } = 37;
        public int rotInsTipoEscala { get; set; } = 207;
        public int rotEditTipoEscala { get; set; } = 208;
        public int rotExcTipoEscala { get; set; } = 209;
        public int rotVisTipoEscala { get; set; } = 210;
    }
}