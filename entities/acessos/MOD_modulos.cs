using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
    public class MOD_modulos
    {
        public string CodModulo { get; set; }
        public string DescModulo { get; set; }
        public string NivelMod { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoModulos
    {
        public int progModulo { get; set; } = 16;
        public int rotInsModulo { get; set; } = 54;
        public int rotEditModulo { get; set; } = 55;
        public int rotExcModulo { get; set; } = 56;
        public int rotVisModulo { get; set; } = 57;
    }
}
