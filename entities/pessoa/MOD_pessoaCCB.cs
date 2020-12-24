using System.Collections.Generic;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_pessoaCCB
    {
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodCargo { get; set; }
        public string DescCargo { get; set; }
        public string DataApresentacao { get; set; }
        public string Ordem { get; set; }
        public string CodCCB { get; set; }
        public string CodigoCCB { get; set; }
        public string DescricaoCCB { get; set; }
        public string Endereco{ get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CodCidade { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string CodRegiao { get; set; }
        public string CodigoRegiao { get; set; }
        public string DescricaoRegiao { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoPessoaCCB
    {
        public int LiberaAtendimentoComum { get; set; } = 230;
        public int BloqueiaAtendimentoComum { get; set; } = 231;
    }
}