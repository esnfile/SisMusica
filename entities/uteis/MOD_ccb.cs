using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.uteis
{
    public class MOD_ccb
    {
        public string CodCCB { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CodCidade { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string DataAbertura { get; set; }
        public string Skype { get; set; }
        public string CaminhoBD { get; set; }
        public string Situacao { get; set; }
        public string CodRegiao { get; set; }
        public string CodigoRegiao { get; set; }
        public string DescricaoRegiao { get; set; }
        public string CodRegional { get; set; }
        public string CodigoRegional { get; set; }
        public string DescricaoRegional { get; set; }

        public MOD_log Logs { get; set; }
        public BindingList<MOD_pessoaCCB> listaCCBPessoa { get; set; }
        public List<MOD_pessoaCCB> listaDeleteCCBPessoa { get; set; }
    }

    public class MOD_acessoCcb
    {
        public static int ProgCCB { get; } = 9;
        public static int RotInsCCB { get; } = 26;
        public static int RotEditCCB { get; } = 27;
        public static int RotExcCCB { get; } = 28;
        public static int RotVisCCB { get; } = 29;
        public static int RotCCBAbaMinist { get; } = 155;
        public static int RotInsCCBMinist { get; } = 156;
        public static int RotExcCCBMinist { get; } = 157;
        public static int RotCCBMixRelatorio { get; } = 224;
    }
}