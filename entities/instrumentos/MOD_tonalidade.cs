﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_tonalidade
    {
        public string CodTonalidade { get; set; }
        public string Nota { get; set; }
        public string Alteracoes { get; set; }
        public string DescTonalidade { get; set; }

        public MOD_log Logs { get; set; }

    }
}