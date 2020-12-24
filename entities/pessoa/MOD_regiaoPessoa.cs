using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_regiaoPessoa
    {
        public string CodRegiaoPessoa { get; set; }
        public string CodPessoa { get; set; }
        public string CodRegiao { get; set; }
        public string Codigo { get; set; }
        public string DescRegiao { get; set; }
        public string Nome { get; set; }
        public string CodRegional { get; set; }
        public string DescRegional { get; set; }

        public MOD_log Logs { get; set; }
        public List<MOD_pessoa> listaPessoa { get; set; }
    }

    public class MOD_acessoRegiaoPessoa
    {
        public int LiberaRegiaoPessoa { get; set; } = 228;
        public int BoqueiaRegiaoPessoa { get; set; } = 229;
    }
}