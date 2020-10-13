using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.administracao
{
    public class MOD_tipoReuniaoCargo
    {
        public string CodCargoReuniao { get; set; }
        public string CodCargo { get; set; }
        public string CodTipoReuniao { get; set; }
        public string DescTipoReuniao { get; set; }
        public string DescCargo { get; set; }
        public string SiglaCargo { get; set; }
        public string Ordem { get; set; }
        public bool Marcado { get; set; }
        public string Masculino { get; set; }
        public string Feminino { get; set; }

        public MOD_log Logs { get; set; }
    }
}