using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ENT.Log;

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
        public BindingList<MOD_ccbPessoa> listaCCBPessoa { get; set; }
        public List<MOD_ccbPessoa> listaDeleteCCBPessoa { get; set; }
    }

    public class MOD_acessoCcb
    {
        public int progCCB { get; set; } = 9;
        public int rotInsCCB { get; set; } = 26;
        public int rotEditCCB { get; set; } = 27;
        public int rotExcCCB { get; set; } = 28;
        public int rotVisCCB { get; set; } = 29;
        public int rotCCBAbaMinist { get; set; } = 155;
        public int rotInsCCBMinist { get; set; } = 156;
        public int rotExcCCBMinist { get; set; } = 157;
        public int rotCCBMixRelatorio { get; set; } = 224;
    }
}
