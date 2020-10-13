using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.exporta
{
    public class MOD_exportaPessoa
    {
        public string CodExportaPessoa { get; set; }
        public string DataExporta { get; set; }
        public string HoraExporta { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string QtdeArquivo { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoExportaPessoa
    {
        public int rotExpPessoa { get; set; } = 225;
    }
}