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
        public int progTipoReuniao { get; set; } = 40;
        public int rotInsTipoReuniao { get; set; } = 219;
        public int rotEditTipoReuniao { get; set; } = 220;
        public int rotExcTipoReuniao { get; set; } = 221;
        public int rotVisTipoReuniao { get; set; } = 222;
        public int rotipoReuniaoCargo { get; set; } = 223;
    }
}