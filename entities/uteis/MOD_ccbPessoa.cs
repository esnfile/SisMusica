using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.uteis
{
    public class MOD_ccbPessoa
    {
        public string CodCCBPessoa { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodCargo { get; set; }
        public string DescCargo { get; set; }
        public string DataApresentacao { get; set; }
        public string Ordem { get; set; }
        public string CodCCB { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Endereco{ get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CodCidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CodigoRegiao { get; set; }
        public string DescRegiao { get; set; }

        public MOD_log Logs { get; set; }
        public List<MOD_pessoa> listaPessoa { get; set; }
    }
}
