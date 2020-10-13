using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
    public class MOD_usuarioRegiao
    {
        public string CodUsuarioRegiao { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodRegiao { get; set; }
        public string CodigoRegiao { get; set; }
        public string DescRegiao { get; set; }
        public string CodRegional { get; set; }
        public string DescRegional { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}