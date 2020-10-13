using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.acessos
{
    public class MOD_usuarioCargo
    {
        public string CodUsuarioCargo { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodCargo { get; set; }
        public string DescCargo { get; set; }
        public string SiglaCargo { get; set; }
        public string Ordem { get; set; }
        public string Masculino { get; set; }
        public string Feminino { get; set; }
        public string AtendeGEM { get; set; }
        public string AtendeRegiao { get; set; }
        public string AtendeComum { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}