using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.uteis
{
    public class MOD_parametroPreTesteMet
    {
        public string CodParamPreTesteMet { get; set; }
        public string CodParametro { get; set; }
        public string CodMetodo { get; set; }
        public string DescMetodo { get; set; }
        public string Compositor { get; set; }
        /// <summary>
        /// Tipo ='Solfejo', 'Ritmo', 'Instrumento')
        /// </summary>
        public string Tipo { get; set; }
        public string Ativo { get; set; }
        /// <summary>
        /// TipoEscolha: 'Sistema', 'Candidato'
        /// </summary>
        public string TipoEscolha { get; set; }
        /// <summary>
        /// PaginaFase: 'Página', 'Fase'
        /// </summary>
        public string PaginaFase { get; set; }
        public string QtdeLicao { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
        /// <summary>
        /// Situação = Permitido, Nâo recomendado, Proibido
        /// </summary>
        public string Situacao { get; set; }
        public string Ordem { get; set; }

        public MOD_log Logs { get; set; }
    }
}
