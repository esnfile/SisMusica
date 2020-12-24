using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.administracao
{
    public class MOD_tipoReuniao
    {
        public string CodTipoReuniao { get; set; }
        public string DescTipoReuniao { get; set; }

        public List<MOD_tipoReuniaoCargo> listaCargoReuniao { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoTipoReuniao
    {
        public static int ProgTipoReuniao { get; } = 40;
        public static int RotInsTipoReuniao { get; } = 219;
        public static int RotEditTipoReuniao { get; } = 220;
        public static int RotExcTipoReuniao { get; } = 221;
        public static int RotVisTipoReuniao { get; } = 222;
        public static int RotipoReuniaoCargo { get; } = 223;
    }
}