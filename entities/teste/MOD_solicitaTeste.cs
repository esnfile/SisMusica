using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.preTeste
{
    public class MOD_solicitaTeste
    {
        public string CodSolicitaTeste { get; set; }
        public string Tipo { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string CodCCB { get; set; }
        public string CodigoCCB { get; set; }
        public string DescricaoCCB { get; set; }
        public string CodRegiao { get; set; }
        public string CodigoRegiao { get; set; }
        public string DescricaoRegiao { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string DescFamilia { get; set; }
        public string CodFamilia { get; set; }
        public string Status { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoSolicitaTeste
    {
        public static int ProgSolicitaTeste { get; } = 34;
        public static int RotInsSolicitaTeste { get; } = 191;
        public static int RotEditSolicitaTeste { get; } = 192;
        public static int RotExcSolicitaTeste { get; } = 193;
        public static int RotVisSolicitaTeste { get; } = 194;
        public static int RotImpSolicitaTeste { get; } = 195;
        public static int RotCancelSolicitaTeste { get; } = 197;
        public static int RotAutorizaSolicitaTeste { get; } = 198;
        public static int RotNegaSolicitaTeste { get; } = 199;
    }
}