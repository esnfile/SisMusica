using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.uteis
{
    public class MOD_regional
    {
        public string CodRegional { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string CaminhoBD { get; set; }

        public DataTable CarregaFoto { get; set; }
        public List<MOD_regiaoAtuacao> listaRegiao { get; set; }
        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoRegional
    {
        public static int ProgRegional { get; set; } = 28;
        public static int RotInsRegional { get; set; } = 136;
        public static int RotEditRegional { get; set; } = 137;
        public static int RotExcRegional { get; set; } = 138;
        public static int RotVisRegional { get; set; } = 139;
    }
}