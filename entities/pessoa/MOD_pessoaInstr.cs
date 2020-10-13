using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_pessoaInstr
    {
        public string CodPessoaInstr { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
        public string Situacao { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}