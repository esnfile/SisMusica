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
        public byte[] Foto { get; set; }

        public string Nome { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoPessoaFoto
    {
        public int AlterarFotoPessoa { get; set; } = 234;
    }
}