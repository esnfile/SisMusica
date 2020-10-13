using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.licao
{
    public class MOD_licaoTesteMts
    {
        public string CodLicaoMts { get; set; }
        public string CodMetMts { get; set; }
        public string DescMetodo { get; set; }
        public string Compositor { get; set; }
        public string Nivel { get; set; }
        public string Tipo { get; set; }
        public string AplicaEm { get; set; }
        public string ModuloMts { get; set; }
        public string LicaoMts { get; set; }
        public string TipoMts { get; set; }

        public MOD_log Logs { get; set; }
    }
}
