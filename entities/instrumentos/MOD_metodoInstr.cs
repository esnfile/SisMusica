﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_metodoInstr
    {
        public string CodMetodoInstr { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string CodMetodo { get; set; }
        public string DescMetodo { get; set; }
        public string AplicarEm { get; set; }
        public string PaginaInicio { get; set; }
        public string LicaoInicio { get; set; }
        public string PaginaFim { get; set; }
        public string LicaoFim { get; set; }
        public string TipoEscolha { get; set; }
        public string Tipo { get; set; }
        public string Compositor { get; set; }
        public string Ativo { get; set; }
        public string PaginaFase { get; set; }
        public string FaseInicio { get; set; }
        public string FaseFim { get; set; }
        /// <summary>
        /// Fase se houver, Página e Lição Inicial
        /// </summary>
        public string Inicio { get; set; }
        /// <summary>
        /// Fase se houver, Página e Lição Final
        /// </summary>
        public string Fim { get; set; }

        public MOD_log Logs { get; set; }
    }
    public class MOD_acessoMetodoInstr
    {
        public static int ProgMetodoInstr { get; } = 6;
        public static int RotInsMetodoInstr { get; } = 11;
        public static int RotEditMetodoInstr { get; } = 144;
        public static int RotExcMetodoInstr { get; } = 145;
    }
}
