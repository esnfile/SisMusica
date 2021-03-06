﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.preTeste
{
    public class MOD_preTeste
    {
        public string CodPreTeste { get; set; }
        /// <summary>
        /// Status= 'Aberto', 'Em Preparação', 'Realizado', 'Finalizado', 'Agendado', 'Cancelado'
        /// </summary>
        public string Status { get; set; }
        public string CodCCB { get; set; }
        public string CodigoCCB { get; set; }
        public string DescricaoCCB { get; set; }
        public string CodRegiao { get; set; }
        public string DescricaoRegiao { get; set; }
        public string Obs { get; set; }
        public string DataExame { get; set; }
        public string HoraExame { get; set; }
        public string DataAbertura { get; set; }
        public string HoraAbertura { get; set; }
        public string CodUsuarioAbertura { get; set; }
        public string DataFechamento { get; set; }
        public string HoraFechamento { get; set; }
        public string CodUsuarioFechamento { get; set; }
        public string DataReAgenda { get; set; }
        public string HoraReAgenda { get; set; }
        public string CodUsuarioReAgenda { get; set; }
        public string DataResultado { get; set; }
        public string HoraResultado { get; set; }
        public string CodUsuarioResultado { get; set; }
        public string Resultado { get; set; }
        public string UsuarioAbertura { get; set; }
        public string UsuarioFechamento { get; set; }
        public string UsuarioReAgenda { get; set; }
        public string UsuarioResultado { get; set; }
        public string DataCancela { get; set; }
        public string HoraCancela { get; set; }
        public string CodUsuarioCancela { get; set; }
        public string UsuarioCancela { get; set; }
        public string CodAnciao { get; set; }
        public string NomeAnciao { get; set; }
        public string CodCooperador { get; set; }
        public string NomeCooperador { get; set; }
        public string CodEncReg { get; set; }
        public string NomeEncReg { get; set; }
        public string CodExamina { get; set; }
        public string NomeExamina { get; set; }
        public string CodEncLocal { get; set; }
        public string NomeEncLocal { get; set; }
        public string CodInstrutor { get; set; }
        public string NomeInstrutor { get; set; }

        public List<MOD_preTesteFicha> listaPreTesteFicha { get; set; }
        public List<MOD_preTesteFicha> listaDeletePreTesteFicha { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoPreTeste
    {
        public static int ProgPreTeste { get; } = 26;
        public static int RotInsPreTeste { get; } = 117;
        public static int RotEditPreTeste { get; } = 118;
        public static int RotReAgendaPreTeste { get; } = 122;
        public static int RotVisPreTeste { get; } = 120;
        public static int RotCancelPreTeste { get; } = 119;
        public static int RotEncerraPreTeste { get; } = 121;
        public static int RotImpPreTeste { get; } = 196;
    }
}