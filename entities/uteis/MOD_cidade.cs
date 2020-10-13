using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.uteis
{
    public class MOD_cidade
    {
        public string CodCidade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Tipo { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoCidade
    {
        public int progCidade { get; set; } = 7;
        public int rotInsCidade { get; set; } = 18;
        public int rotEditCidade { get; set; } = 19;
        public int rotExcCidade { get; set; } = 20;
        public int rotVisCidade { get; set; } = 21;
    }
}
