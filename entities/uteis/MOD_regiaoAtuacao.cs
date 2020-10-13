using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.uteis
{
    public class MOD_regiaoAtuacao
    {
        public string CodRegiao { get; set; }
        public string Codigo { get; set; }
        public string DescRegiao { get; set; }
        public string CodRegional { get; set; }
        public string CodigoRegional { get; set; }
        public string DescricaoRegional { get; set; }

        public List<MOD_ccb> listaCCB { get; set; }
        public MOD_log Logs { get; set; }
    }
}
