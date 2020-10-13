using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.licao
{
    public class MOD_licaoTesteTeoria
    {
        public string CodLicaoTeoria { get; set; }
        public string AplicaEm { get; set; }
        public string CodTeoria { get; set; }
        public string DescTeoria { get; set; }
        public string Caminho { get; set; }
        public string TipoCadastro { get; set; }
        public string CodModuloMts { get; set; }
        public string CodFaseMts { get; set; }
        public string Nivel { get; set; }
        public string Paginas { get; set; }
        public string DescModulo { get; set; }
        public string DescFase { get; set; }

        public MOD_log Logs { get; set; }
    }
}
