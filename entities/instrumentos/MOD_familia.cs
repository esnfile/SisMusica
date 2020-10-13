using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_familia
    {
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
        /// <summary>
        /// Sim ou Não
        /// </summary>
        public string Rjm { get; set; }
        /// <summary>
        /// Sim ou Não
        /// </summary>
        public string Culto { get; set; }
        /// <summary>
        /// Sim ou Não
        /// </summary>
        public string MeiaHora { get; set; }
        /// <summary>
        /// Sim ou Não
        /// </summary>
        public string Oficial { get; set; }
        /// <summary>
        /// Sim ou Não
        /// </summary>
        public string Troca { get; set; }

        public MOD_log Logs { get; set; }
    }
}
