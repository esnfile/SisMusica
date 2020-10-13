using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.instrumentos
{
    public class MOD_teoria
    {
        public string CodTeoria { get; set; }
        public string DescTeoria { get; set; }
        public string AplicaEm { get; set; }
        public string TipoCadastro { get; set; }
        public string SepararPor { get; set; }
        public string CodModuloMts { get; set; }
        public string DescModuloMts { get; set; }
        public string CodFaseMts { get; set; }
        public string DescFaseMts { get; set; }
        public string Nivel { get; set; }
        public string CodUsuario { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string DataCadastro { get; set; }
        public string HoraCadastro { get; set; }
        public string Paginas { get; set; }

        public BindingList<MOD_teoriaFoto> listaFotoTeoria { get; set; }
        public List<MOD_teoriaFoto> listaDeleteFotoTeoria { get; set; }

        public DataTable CarregarFotoTeoria { get; set; }
        public MOD_log Logs { get; set; }
    }
}