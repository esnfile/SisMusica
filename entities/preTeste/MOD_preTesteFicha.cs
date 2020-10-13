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
        public int progFichaPreTeste { get; set; } = 35;
        public int rotInsFichaPreTeste { get; set; } = 187;
        public int rotEditFichaPreTeste { get; set; } = 188;
        public int rotExcFichaPreTeste { get; set; } = 189;
        public int rotVisFichaPreTeste { get; set; } = 190;
        public int rotImpFichaPreTeste { get; set; } = 196;

        public int rotInsMetFichaPreTeste { get; set; } = 172;
        public int rotEditMetFichaPreTeste { get; set; } = 173;
        public int rotExcMetFichaPreTeste { get; set; } = 174;

        public int rotInsHinoFichaPreTeste { get; set; } = 175;
        public int rotEditHinoFichaPreTeste { get; set; } = 176;
        public int rotExcHinoFichaPreTeste { get; set; } = 177;

        public int rotInsMtsFichaPreTeste { get; set; } = 178;
        public int rotEditMtsFichaPreTeste { get; set; } = 179;
        public int rotExcMtsFichaPreTeste { get; set; } = 180;

        public int rotInsEscalaFichaPreTeste { get; set; } = 181;
        public int rotEditEscalaFichaPreTeste { get; set; } = 182;
        public int rotExcEscalaFichaPreTeste { get; set; } = 183;

        public int rotInsTeoriaFichaPreTeste { get; set; } = 184;
        public int rotEditTeoriaFichaPreTeste { get; set; } = 185;
        public int rotExcTeoriaFichaPreTeste { get; set; } = 186;
    }
}