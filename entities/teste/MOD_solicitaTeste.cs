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
        public int progSolicitaTeste { get; set; } = 34;
        public int rotInsSolicitaTeste { get; set; } = 191;
        public int rotEditSolicitaTeste { get; set; } = 192;
        public int rotExcSolicitaTeste { get; set; } = 193;
        public int rotVisSolicitaTeste { get; set; } = 194;
        public int rotImpSolicitaTeste { get; set; } = 195;
        public int rotCancelSolicitaTeste { get; set; } = 197;
        public int rotAutorizaSolicitaTeste { get; set; } = 198;
        public int rotNegaSolicitaTeste { get; set; } = 199;
    }
}