using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
    public class MOD_subModulos
    {
        public string CodSubModulo { get; set; }
        public string DescSubModulo { get; set; }
        public string NivelSub { get; set; }
        public string CodModulo { get; set; }
        public string DescModulo { get; set; }
        public string NivelMod { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoSubModulos
    {
        public int progSubModulo { get; set; } = 17;
        public int rotInsSubModulo { get; set; } = 58;
        public int rotEditSubModulo { get; set; } = 59;
        public int rotExcSubModulo { get; set; } = 60;
        public int rotVisSubModulo { get; set; } = 61;
    }
}
