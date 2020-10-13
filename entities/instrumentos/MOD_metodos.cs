using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_metodos
    {
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
        /// PaginaFase: 'Página', 'Fase', 'Lição'
        /// </summary>
        public string PaginaFase { get; set; }

        public List<MOD_metodoInstr> listaMetodoInstr { get; set; }
        public List<MOD_metodoFamilia> listaMetodoFamilia { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoMetodo
    {
        public int progMetodo { get; set; } = 20;
        public int rotInsMetodo { get; set; } = 70;
        public int rotEditMetodo { get; set; } = 71;
        public int rotExcMetodo { get; set; } = 72;
        public int rotVisMetodo { get; set; } = 73;
    }
}
