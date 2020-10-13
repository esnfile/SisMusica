using ENT.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ENT.uteis
{
    public class MOD_parametros
    {
        public string CodParametro { get; set; }
        public string CodRegional { get; set; }
        /// <summary>
        /// Ativacao: Sim ou Não
        /// </summary>
        public string Ativacao { get; set; }
        /// <summary>
        /// InformaAtiva: Sim ou Não
        /// </summary>
        public string InformaAtiva { get; set; }
        /// <summary>
        /// DiasAtiva: Maior que Zero e Menor que 6
        /// </summary>
        public string DiasAtiva { get; set; }
        /// <summary>
        /// Atualizacao: Sim ou Não
        /// </summary>
        public string Atualizacao { get; set; }
        /// <summary>
        /// CpfZerado: Sim ou Não
        /// </summary>
        public string CpfZerado { get; set; }
        /// <summary>
        /// TrocaSenha: Sim ou Não
        /// </summary>
        public string TrocaSenha { get; set; }
        /// <summary>
        /// DiasTrocaSenha: Maior que Zero e Menor que 91
        /// </summary>
        public string DiasTrocaSenha { get; set; }
        /// <summary>
        /// CopiaSegura: Sim ou Não
        /// </summary>
        public string CopiaSegura { get; set; }
        /// <summary>
        /// DiasCopiaSegura: Maior que Zero e Menor que 10
        /// </summary>
        public string DiasCopiaSegura { get; set; }
        public string QtdeViasPreTeste { get; set; }
        public string QtdeViasTeste { get; set; }
        /// <summary>
        /// AlteraDadosImportPessoa: Sim ou Não
        /// </summary>
        public string AlteraDadosImportPessoa { get; set; }
        /// <summary>
        /// ValidarDadosImportacao: Sim ou Não
        /// </summary>
        public string ValidarDadosImportacao { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string CaminhoBD { get; set; }
        /// <summary>
        /// TesteMetodo: Candidato ou Instrumento
        /// </summary>
        public string TesteMetodo { get; set; }
        /// <summary>
        /// TesteHino: Candidato ou Instrumento
        /// </summary>
        public string TesteHino { get; set; }
        /// <summary>
        /// AlteraSolicita: Sim ou Não
        /// </summary>
        public string AlteraSolicita { get; set; }
        /// <summary>
        /// AlteraQtdeLicoesPreTeste: Sim ou Não
        /// </summary>
        public string AlteraQtdeLicoesPreTeste { get; set; }
        /// <summary>
        /// AlteraQtdeLicoesTeste: Sim ou Não
        /// </summary>
        public string AlteraQtdeLicoesTeste { get; set; }

        public string QtdeHinoPreTesteRjm { get; set; }
        public string QtdeEscalaPreTesteRjm { get; set; }
        public string QtdeHinoTesteRjm { get; set; }
        public string QtdeEscalaTesteRjm { get; set; }
        public string QtdeHinoPreTesteMeia { get; set; }
        public string QtdeEscalaPreTesteMeia { get; set; }
        public string QtdeHinoTesteMeia { get; set; }
        public string QtdeEscalaTesteMeia { get; set; }
        public string QtdeHinoPreTesteCulto { get; set; }
        public string QtdeEscalaPreTesteCulto { get; set; }
        public string QtdeHinoTesteCulto { get; set; }
        public string QtdeEscalaTesteCulto { get; set; }
        public string QtdeHinoPreTesteOficial { get; set; }
        public string QtdeEscalaPreTesteOficial { get; set; }
        public string QtdeHinoTesteOficial { get; set; }
        public string QtdeEscalaTesteOficial { get; set; }
        public string RodapeRelatorio { get; set; }
        /// <summary>
        /// TestePermAltObsMet: Sim ou Não
        /// </summary>
        public string TestePermAltObsMet { get; set; }
        /// <summary>
        /// TestePermAltObsMts: Sim ou Não
        /// </summary>
        public string TestePermAltObsMts { get; set; }
        /// <summary>
        /// TestePermAltObsHino: Sim ou Não
        /// </summary>
        public string TestePermAltObsHino { get; set; }
        /// <summary>
        /// TestePermAltObsEsc: Sim ou Não
        /// </summary>
        public string TestePermAltObsEsc { get; set; }
        /// <summary>
        /// TestePermAltObsTeoria: Sim ou Não
        /// </summary>
        public string TestePermAltObsTeoria { get; set; }
        public string TesteObsMet { get; set; }
        public string TesteObsMts { get; set; }
        public string TesteObsHino { get; set; }
        public string TesteObsEsc { get; set; }
        public string TesteObsTeoria { get; set; }

        public List<MOD_regional> listaRegional { get; set; }
        
        public BindingList<MOD_parametroPreTesteMet> listaParamPreTeste { get; set; }
        public BindingList<MOD_parametroTesteMet> listaParamTeste { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoParam
    {
        public int progParam { get; set; } = 30;
        public int rotInsParam { get; set; } = 160;
        public int rotEditParam { get; set; } = 161;
        public int rotExcParam { get; set; } = 162;
        public int rotVisParam { get; set; } = 163;
        public int rotAbaTeste { get; set; } = 204;
        public int rotParamPre { get; set; } = 205;
        public int rotParamTeste { get; set; } = 206;
    }
}