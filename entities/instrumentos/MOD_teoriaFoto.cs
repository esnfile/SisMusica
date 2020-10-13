using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_teoriaFoto
    {
        public string CodFoto { get; set; }
        public string CodTeoria { get; set; }
        public string Foto { get; set; }
        public string Pagina { get; set; }

        public DataTable CarregarFotoTeoria { get; set; }

        public MOD_log Logs { get; set; }
    }
}
