using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
    public class MOD_programas
    {
        public string CodPrograma { get; set; }
        public string DescPrograma { get; set; }
        public string NivelProg { get; set; }
        public string CodSubModulo { get; set; }
        public string DescSubModulo { get; set; }
        public string NivelSub { get; set; }
        public string CodModulo { get; set; }
        public string DescModulo { get; set; }
        public string NivelMod { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoProgramas
    {
        public int progProgModulo { get; set; } = 18;
        public int rotInsProgModulo { get; set; } = 62;
        public int rotEditProgModulo { get; set; } = 63;
        public int rotExcProgModulo { get; set; } = 64;
        public int rotVisProgModulo { get; set; } = 65;
    }
}
