using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_metodoFamilia
    {
        public string CodMetodoFamilia { get; set; }
        public string CodMetodo { get; set; }
        public string DescMetodo { get; set; }
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
        public string TipoEscolha { get; set; }
        public string PaginaFase { get; set; }
        public string Tipo { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}
