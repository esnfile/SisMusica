using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.uteis
{
    public class MOD_regiaoPessoa
    {
        public string CodRegiaoPessoa { get; set; }
        public string CodPessoa { get; set; }
        public string CodRegiao { get; set; }
        public string Codigo { get; set; }
        public string DescRegiao { get; set; }
        public string Nome { get; set; }

        public MOD_log Logs { get; set; }
        public List<MOD_pessoa> listaPessoa { get; set; }
    }
}