using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
    public class MOD_usuarioCCB
    {
        public string CodUsuarioCCB { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodCCB { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string CodRegiao { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}