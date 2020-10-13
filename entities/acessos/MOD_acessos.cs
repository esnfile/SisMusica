using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
   public class MOD_acessos
    {
        public string CodAcesso { get; set; }
        public string CodUsuario { get; set; }
        public string CodRotina { get; set; }
        public string CodPessoa { get; set; }
        public string Usuario { get; set; }
        public string Nome { get; set; }
        public string Supervisor { get; set; }
        public string DescRotina { get; set; }
        public string NivelRotina { get; set; }
        public string DescSeg { get; set; }
        public string DescInd { get; set; }
        public string CodPrograma { get; set; }
        public string DescPrograma { get; set; }
        public string CodSubModulo { get; set; }
        public string DescSubModulo { get; set; }
        public string CodModulo { get; set; }
        public string DescModulo { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }



}
