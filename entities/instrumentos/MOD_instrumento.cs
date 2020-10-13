using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_instrumento
    {
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
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

        public string NotaAfina { get; set; }
        public string PosAfina { get; set; }
        public string NotaEfeito { get; set; }
        public string PosEfeito { get; set; }
        public string Obs { get; set; }
        public string TesNotaGrave { get; set; }
        public string TesNotaAguda { get; set; }
        public string Tessitura { get; set; }
        /// <summary>
        /// Situação = Permitido, Nâo recomendado, Proibido
        /// </summary>
        public string Situacao { get; set; }
        public string Ordem { get; set; }

        public List<MOD_instrumentoVozPrincipal> listaVozInstrPrincipal { get; set; }
        public List<MOD_instrumentoVozAlternativa> listaVozInstrAlternativa { get; set; }
        public List<MOD_instrumentoTom> listaTomInstr { get; set; }
        public List<MOD_instrumentoHinario> listaHinoInstr { get; set; }
        public MOD_instrumentoFoto FotoInstrumento { get; set; }
        public DataTable CarregaFoto { get; set; }

        public MOD_log Logs { get; set; }
    }
}
