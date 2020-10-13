using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_pessoaFoto
    {
        public string CodFoto { get; set; }
        public string CodPessoa { get; set; }
        public string Foto { get; set; }

        public MOD_log Logs { get; set; }
    }
}