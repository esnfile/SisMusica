using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.preTeste
{
    public class MOD_preTesteEscala
    {
        public string CodPreTesteEscala { get; set; }
        public string CodPreTeste { get; set; }
        public string CodEscala { get; set; }
        public string DescEscala { get; set; }
        public string CodTipoEscala { get; set; }
        public string DescTipoEscala { get; set; }
        public string CodFichaPreTeste { get; set; }
        public string CodCandidato { get; set; }
        public string CodSolicitaTeste { get; set; }
        /// <summary>
        /// Tipo='Reunião de Jovens', 'Culto Oficial', 'Meia Hora', 'Oficialização', 'Troca Instrumento'
        /// </summary>
        public string Tipo { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string CodCCB { get; set; }
        public string CodigoCCB { get; set; }
        public string DescricaoCCB { get; set; }
        public string NomeCandidato { get; set; }
        public string DataExame { get; set; }
        public string HoraExame { get; set; }
        public string Status { get; set; }

        public MOD_log Logs { get; set; }
    }
}