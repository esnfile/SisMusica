using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_pessoaMetodo
    {
        public string CodPessoaMetodo { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodMetodo { get; set; }
        public string DescMetodo { get; set; }
        public string Compositor { get; set; }
        public string TipoEscolha { get; set; }
        public string PaginaFase { get; set; }
        public string Tipo { get; set; }
        public string Ativo { get; set; }
        public bool Marcado { get; set; }

        public MOD_log Logs { get; set; }
    }
}