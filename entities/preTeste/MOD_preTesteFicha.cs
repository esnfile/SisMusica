using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.preTeste
{
    public class MOD_preTesteFicha
    {
        public string CodFichaPreTeste { get; set; }
        public string CodSolicitaTeste { get; set; }
        public string Data { get; set; }
        public string Hora { get; set; }
        public string Obs { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string ObsMet { get; set; }
        public string ObsMts { get; set; }
        public string ObsHino { get; set; }
        public string ObsEsc { get; set; }
        public string ObsTeoria { get; set; }

        //Dados da Tavela Teste
        public string CodPreTeste { get; set; }
        public string DataExame { get; set; }
        public string HoraExame { get; set; }
        public string DataAbertura { get; set; }
        public string HoraAbertura { get; set; }
        public string DataFechamento { get; set; }
        public string HoraFechamento { get; set; }
        public string Tipo { get; set; }
        public string CodCCB { get; set; }
        public string CodigoCCB { get; set; }
        public string DescricaoCCB { get; set; }
        public string CodRegiao { get; set; }
        public string DescricaoRegiao { get; set; }
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

        //Dados da Tabela Pessoa
        public string CodCandidato { get; set; }
        public string NomeCandidato { get; set; }
        public string CodCidadeRes { get; set; }
        public string CidadeRes { get; set; }
        public string EstadoRes { get; set; }
        public string CodCCBPessoa { get; set; }
        public string DescricaoCCBPessoa { get; set; }
        public string CodCidadeCCBPessoa { get; set; }
        public string CidadeCCBPessoa { get; set; }
        public string CodigoCCBPessoa { get; set; }
        public string CodCargo { get; set; }
        public string DescCargo { get; set; }
        public string SiglaCargo { get; set; }
        public string Ordem { get; set; }
        public string Masculino { get; set; }
        public string Feminino { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
        public string CodRegiaoPessoa { get; set; }
        public string DescricaoRegiaoPessoa { get; set; }
        public string Sexo { get; set; }
        public string CodInstrutorPessoa { get; set; }
        public string NomeInstrutorPessoa { get; set; }

        public List<MOD_preTeste> listaPreTeste { get; set; }

        public BindingList<MOD_preTesteEscala> listaPreTesteEscala { get; set; }
        public List<MOD_preTesteEscala> listaDeletePreTesteEscala { get; set; }

        public BindingList<MOD_preTesteHino> listaPreTesteHino { get; set; }
        public List<MOD_preTesteHino> listaDeletePreTesteHino { get; set; }

        public BindingList<MOD_preTesteMet> listaPreTesteMet { get; set; }
        public List<MOD_preTesteMet> listaDeletePreTesteMet { get; set; }

        public BindingList<MOD_preTesteMts> listaPreTesteMts { get; set; }
        public List<MOD_preTesteMts> listaDeletePreTesteMts { get; set; }

        public BindingList<MOD_preTesteTeoria> listaPreTesteTeoria { get; set; }
        public List<MOD_preTesteTeoria> listaDeletePreTesteTeoria { get; set; }

        public List<MOD_pessoa> listaPessoa { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoFichaPreTeste
    {
        public static int ProgFichaPreTeste { get; } = 35;
        public static int RotInsFichaPreTeste { get; } = 187;
        public static int RotEditFichaPreTeste { get; } = 188;
        public static int RotExcFichaPreTeste { get; } = 189;
        public static int RotVisFichaPreTeste { get; } = 190;
        public static int RotImpFichaPreTeste { get; } = 196;

        public static int RotInsMetFichaPreTeste { get; } = 172;
        public static int RotEditMetFichaPreTeste { get; } = 173;
        public static int RotExcMetFichaPreTeste { get; } = 174;

        public static int RotInsHinoFichaPreTeste { get; } = 175;
        public static int RotEditHinoFichaPreTeste { get; } = 176;
        public static int RotExcHinoFichaPreTeste { get; } = 177;

        public static int RotInsMtsFichaPreTeste { get; } = 178;
        public static int RotEditMtsFichaPreTeste { get; } = 179;
        public static int RotExcMtsFichaPreTeste { get; } = 180;

        public static int RotInsEscalaFichaPreTeste { get; } = 181;
        public static int RotEditEscalaFichaPreTeste { get; } = 182;
        public static int RotExcEscalaFichaPreTeste { get; } = 183;

        public static int RotInsTeoriaFichaPreTeste { get; } = 184;
        public static int RotEditTeoriaFichaPreTeste { get; } = 185;
        public static int RotExcTeoriaFichaPreTeste { get; } = 186;
    }
}