using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_mtsModulo
    {
        public string CodModuloMts { get; set; }
        public string DescModulo { get; set; }
        public string CodFaseMts { get; set; }
        public string DescFase { get; set; }

        public MOD_log Logs { get; set; }
    }
}
