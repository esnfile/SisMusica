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
        public int progReuniaoMinisterio { get; set; } = 38;
        public int rotInsReuniao { get; set; } = 211;
        public int rotEditReuniao { get; set; } = 212;
        public int rotFinalReuniao { get; set; } = 215;
        public int rotVisReuniao { get; set; } = 213;
        public int rotCancelReuniao { get; set; } = 214;
        public int rotImpReuniao { get; set; } = 216;
    }
}