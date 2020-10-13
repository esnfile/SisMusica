using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.importa
{
    public class MOD_importaPessoa
    {
        public string CodImportaPessoa { get; set; }
        public string DataImporta { get; set; }
        public string HoraImporta { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string QtdeArquivo { get; set; }
        public string Descricao { get; set; }

        public MOD_log Logs { get; set; }
        public List<MOD_importaPessoaItem> ListaPessoaItem { get; set; }
        public List<MOD_importaPessoaItemErro> ListaPessoaItemErros { get; set; }
    }
}