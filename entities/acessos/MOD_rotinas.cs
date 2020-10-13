using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
    public class MOD_rotinas
    {
        public string CodRotina { get; set; }
        public string DescRotina { get; set; }
        public string NivelRotina { get; set; }
        public string DescSeg { get; set; }
        public string DescInd { get; set; }
        public string CodPrograma { get; set; }
        public string DescPrograma { get; set; }
        public string NivelProg { get; set; }
        public string CodSubModulo { get; set; }
        public string DescSubModulo { get; set; }
        public string NivelSub { get; set; }
        public string CodModulo { get; set; }
        public string DescModulo { get; set; }
        public string NivelMod { get; set; }
        public string LiberaAcesso { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoRotinas
    {
        public int progRotModulo { get; set; } = 19;
        public int rotInsRotModulo { get; set; } = 66;
        public int rotEditRotModulo { get; set; } = 67;
        public int rotExcRotModulo { get; set; } = 68;
        public int rotVisRotModulo { get; set; } = 69;
    }
}