using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.administracao
{
    public class MOD_reuniaoMinisterio
    {
        public string CodReuniao { get; set; }
        public string DataInclusao { get; set; }
        public string HoraInclusao { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string DataReuniao { get; set; }
        public string HoraReuniao { get; set; }
        public string CodTipoReuniao { get; set; }
        public string DescTipoReuniao { get; set; }
        public string CodCCB { get; set; }
        public string CodigoCCB { get; set; }
        public string DescricaoCCB { get; set; }
        public string CodRegiao { get; set; }
        public string DescricaoRegiao { get; set; }
        public string CodAnciao { get; set; }
        public string NomeAnciao { get; set; }
        public string CodEncReg { get; set; }
        public string NomeEncReg { get; set; }
        public string CodExamina { get; set; }
        public string NomeExamina { get; set; }
        public string CodCooperador { get; set; }
        public string NomeCoop { get; set; }
        public string CodEncLocal { get; set; }
        public string NomeEncLocal { get; set; }
        public string CodInstrutor { get; set; }
        public string NomeInstrutor { get; set; }
        public string Obs { get; set; }
        public string Status { get; set; }
        public string DataFinaliza { get; set; }
        public string HoraFinaliza { get; set; }
        public string CodUsuarioFinaliza { get; set; }
        public string UsuarioFinaliza { get; set; }
        public string DataCancela { get; set; }
        public string HoraCancela { get; set; }
        public string CodUsuarioCancela { get; set; }
        public string UsuarioCancela { get; set; }
        public string CodBiblia { get; set; }
        public string DescLivro { get; set; }
        public string Capitulo { get; set; }
        public string VersoInicio { get; set; }
        public string VersoFim { get; set; }
        public string AssuntoPalavra { get; set; }
        public string HinoAbertura { get; set; }

        public List<MOD_listaPresenca> listaPresenca { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoReuniao
    {
        public static int ProgReuniaoMinisterio { get; } = 38;
        public static int RotInsReuniao { get; } = 211;
        public static int RotEditReuniao { get; } = 212;
        public static int RotFinalReuniao { get; } = 215;
        public static int RotVisReuniao { get; } = 213;
        public static int RotCancelReuniao { get; } = 214;
        public static int RotImpReuniao { get; } = 216;
    }
}