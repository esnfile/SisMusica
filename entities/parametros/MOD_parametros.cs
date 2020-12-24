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

        private string _codParametro;
        private string _codRegional;
        private string _ativacao;
        private string _informaAtiva;
        private string _diasAtiva;
        private string _atualizacao;
        private string _cpfZerado;
        private string _trocaSenha;
        private string _diasTrocaSenha;
        private string _copiaSegura;
        private string _diasCopiaSegura;
        private string _qtdeViasPreTeste;
        private string _qtdeViasTeste;
        private string _alteraDadosImportPessoa;
        private string _validarDadosImportacao;
        private string _codigoRegional;
        private string _descricaoRegional;
        private string _estadoRegional;
        private string _caminhoBD;
        private string _testeMetodo;
        private string _testeHino;
        private string _alteraSolicita;
        private string _alteraQtdeLicoesPreTeste;
        private string _alteraQtdeLicoesTeste;
        private string _qtdeHinoPreTesteRjm;
        private string _qtdeEscalaPreTesteRjm;
        private string _qtdeHinoTesteRjm;
        private string _qtdeEscalaTesteRjm;
        private string _qtdeHinoPreTesteMeia;
        private string _qtdeEscalaPreTesteMeia;
        private string _qtdeHinoTesteMeia;
        private string _qtdeEscalaTesteMeia;
        private string _qtdeHinoPreTesteCulto;
        private string _qtdeEscalaPreTesteCulto;
        private string _qtdeHinoTesteCulto;
        private string _qtdeEscalaTesteCulto;
        private string _qtdeHinoPreTesteOficial;
        private string _qtdeEscalaPreTesteOficial;
        private string _qtdeHinoTesteOficial;
        private string _qtdeEscalaTesteOficial;
        private string _rodapeRelatorio;
        private string _testePermAltObsMet;
        private string _testePermAltObsMts;
        private string _testePermAltObsHino;
        private string _testePermAltObsEsc;
        private string _testePermAltObsTeoria;
        private string _testeObsMet;
        private string _testeObsMts;
        private string _testeObsHino;
        private string _testeObsEsc;
        private string _testeObsTeoria;

        public string CodParametro
        {
            get
            {
                return _codParametro;
            }
            set
            {
                _codParametro = value;
            }
        }
        public string CodRegional
        {
            get
            {
                return _codRegional;
            }
            set
            {
                _codRegional = value;
            }
        }
        /// <summary>
        /// Ativacao: Sim ou Não
        /// </summary>
        public string Ativacao
        {
            get
            {
                return _ativacao;
            }
            set
            {
                _ativacao = value;
            }
        }
        /// <summary>
        /// InformaAtiva: Sim ou Não
        /// </summary>
        public string InformaAtiva
        {
            get
            {
                return _informaAtiva;
            }
            set
            {
                _informaAtiva = value;
            }
        }
        /// <summary>
        /// DiasAtiva: Maior que Zero e Menor que 6
        /// </summary>
        public string DiasAtiva
        {
            get
            {
                return _diasAtiva;
            }
            set
            {
                _diasAtiva = value;
            }
        }
        /// <summary>
        /// Atualizacao: Sim ou Não
        /// </summary>
        public string Atualizacao
        {
            get
            {
                return _atualizacao;
            }
            set
            {
                _atualizacao = value;
            }
        }
        /// <summary>
        /// CpfZerado: Sim ou Não
        /// </summary>
        public string CpfZerado
        {
            get
            {
                return _cpfZerado;
            }
            set
            {
                _cpfZerado = value;
            }
        }
        /// <summary>
        /// TrocaSenha: Sim ou Não
        /// </summary>
        public string TrocaSenha
        {
            get
            {
                return _trocaSenha;
            }
            set
            {
                _trocaSenha = value;
            }
        }
        /// <summary>
        /// DiasTrocaSenha: Maior que Zero e Menor que 91
        /// </summary>
        public string DiasTrocaSenha 
        {
            get
            {
                return _diasTrocaSenha;
            }
            set
            {
                _diasTrocaSenha = value;
            }
        }
        /// <summary>
        /// CopiaSegura: Sim ou Não
        /// </summary>
        public string CopiaSegura 
        {
            get
            {
                return _copiaSegura;
            }
            set
            {
                _copiaSegura = value;
            }
        }
        /// <summary>
        /// DiasCopiaSegura: Maior que Zero e Menor que 10
        /// </summary>
        public string DiasCopiaSegura
        {
            get
            {
                return _diasCopiaSegura;
            }
            set
            {
                _diasCopiaSegura = value;
            }
        }
        /// <summary>
        /// AlteraDadosImportPessoa: Sim ou Não
        /// </summary>
        public string AlteraDadosImportPessoa
        {
            get
            {
                return _alteraDadosImportPessoa;
            }
            set
            {
                _alteraDadosImportPessoa = value;
            }
        }
        public string QtdeViasPreTeste
        {
            get
            {
                return _qtdeViasPreTeste;
            }
            set
            {
                _qtdeViasPreTeste = value;
            }
        }
        public string QtdeViasTeste
        {
            get
            {
                return _qtdeViasTeste;
            }
            set
            {
                _qtdeViasTeste = value;
            }
        }
        /// <summary>
        /// ValidarDadosImportacao: Sim ou Não
        /// </summary>
        public string ValidarDadosImportacao
        {
            get
            {
                return _validarDadosImportacao;
            }
            set
            {
                _validarDadosImportacao = value;
            }
        }
        public string CodigoRegional
        {
            get
            {
                return _codigoRegional;
            }
            set
            {
                _codigoRegional = value;
            }
        }
        public string DescricaoRegional
        {
            get
            {
                return _descricaoRegional;
            }
            set
            {
                _descricaoRegional = value;
            }
        }
        public string EstadoRegional
        {
            get
            {
                return _estadoRegional;
            }
            set
            {
                _estadoRegional = value;
            }
        }
        public string CaminhoBD
        {
            get
            {
                return _caminhoBD;
            }
            set
            {
                _caminhoBD = value;
            }
        }
        /// <summary>
        /// TesteMetodo: Candidato ou Instrumento
        /// </summary>
        public string TesteMetodo
        {
            get
            {
                return _testeMetodo;
            }
            set
            {
                _testeMetodo = value;
            }
        }
        /// <summary>
        /// TesteHino: Candidato ou Instrumento
        /// </summary>
        public string TesteHino
        {
            get
            {
                return _testeHino;
            }
            set
            {
                _testeHino = value;
            }
        }
        /// <summary>
        /// AlteraSolicita: Sim ou Não
        /// </summary>
        public string AlteraSolicita
        {
            get
            {
                return _alteraSolicita;
            }
            set
            {
                _alteraSolicita = value;
            }
        }
        /// <summary>
        /// AlteraQtdeLicoesPreTeste: Sim ou Não
        /// </summary>
        public string AlteraQtdeLicoesPreTeste
        {
            get
            {
                return _alteraQtdeLicoesPreTeste;
            }
            set
            {
                _alteraQtdeLicoesPreTeste = value;
            }
        }
        /// <summary>
        /// AlteraQtdeLicoesTeste: Sim ou Não
        /// </summary>
        public string AlteraQtdeLicoesTeste
        {
            get
            {
                return _alteraQtdeLicoesTeste;
            }
            set
            {
                _alteraQtdeLicoesTeste = value;
            }
        }
        public string QtdeHinoPreTesteRjm
        {
            get
            {
                return _qtdeHinoPreTesteRjm;
            }
            set
            {
                _qtdeHinoPreTesteRjm = value;
            }
        }
        public string QtdeEscalaPreTesteRjm
        {
            get
            {
                return _qtdeEscalaPreTesteRjm;
            }
            set
            {
                _qtdeEscalaPreTesteRjm = value;
            }
        }
        public string QtdeHinoTesteRjm
        {
            get
            {
                return _qtdeHinoTesteRjm;
            }
            set
            {
                _qtdeHinoTesteRjm = value;
            }
        }
        public string QtdeEscalaTesteRjm
        {
            get
            {
                return _qtdeEscalaTesteRjm;
            }
            set
            {
                _qtdeEscalaTesteRjm = value;
            }
        }
        public string QtdeHinoPreTesteMeia
        {
            get
            {
                return _qtdeHinoPreTesteMeia;
            }
            set
            {
                _qtdeHinoPreTesteMeia = value;
            }
        }
        public string QtdeEscalaPreTesteMeia
        {
            get
            {
                return _qtdeEscalaPreTesteMeia;
            }
            set
            {
                _qtdeEscalaPreTesteMeia = value;
            }
        }
        public string QtdeHinoTesteMeia
        {
            get
            {
                return _qtdeHinoTesteMeia;
            }
            set
            {
                _qtdeHinoTesteMeia = value;
            }
        }
        public string QtdeEscalaTesteMeia
        {
            get
            {
                return _qtdeEscalaTesteMeia;
            }
            set
            {
                _qtdeEscalaTesteMeia = value;
            }
        }
        public string QtdeHinoPreTesteCulto
        {
            get
            {
                return _qtdeHinoPreTesteCulto;
            }
            set
            {
                _qtdeHinoPreTesteCulto = value;
            }
        }
        public string QtdeEscalaPreTesteCulto
        {
            get
            {
                return _qtdeEscalaPreTesteCulto;
            }
            set
            {
                _qtdeEscalaPreTesteCulto = value;
            }
        }
        public string QtdeHinoTesteCulto
        {
            get
            {
                return _qtdeHinoTesteCulto;
            }
            set
            {
                _qtdeHinoTesteCulto = value;
            }
        }
        public string QtdeEscalaTesteCulto
        {
            get
            {
                return _qtdeEscalaTesteCulto;
            }
            set
            {
                _qtdeEscalaTesteCulto = value;
            }
        }
        public string QtdeHinoPreTesteOficial
        {
            get
            {
                return _qtdeHinoPreTesteOficial;
            }
            set
            {
                _qtdeHinoPreTesteOficial = value;
            }
        }
        public string QtdeEscalaPreTesteOficial
        {
            get
            {
                return _qtdeEscalaPreTesteOficial;
            }
            set
            {
                _qtdeEscalaPreTesteOficial = value;
            }
        }
        public string QtdeHinoTesteOficial
        {
            get
            {
                return _qtdeHinoTesteOficial;
            }
            set
            {
                _qtdeHinoTesteOficial = value;
            }
        }
        public string QtdeEscalaTesteOficial
        {
            get
            {
                return _qtdeEscalaTesteOficial;
            }
            set
            {
                _qtdeEscalaTesteOficial = value;
            }
        }
        public string RodapeRelatorio
        {
            get
            {
                return _rodapeRelatorio;
            }
            set
            {
                _rodapeRelatorio = value;
            }
        }
        /// <summary>
        /// TestePermAltObsMet: Sim ou Não
        /// </summary>
        public string TestePermAltObsMet 
        {
            get
            {
                return _testePermAltObsMet;
            }
            set
            {
                _testePermAltObsMet = value;
            }
        }
        /// <summary>
        /// TestePermAltObsMts: Sim ou Não
        /// </summary>
        public string TestePermAltObsMts
        {
            get
            {
                return _testePermAltObsMts;
            }
            set
            {
                _testePermAltObsMts = value;
            }
        }
        /// <summary>
        /// TestePermAltObsHino: Sim ou Não
        /// </summary>
        public string TestePermAltObsHino
        {
            get
            {
                return _testePermAltObsHino;
            }
            set
            {
                _testePermAltObsHino = value;
            }
        }
        /// <summary>
        /// TestePermAltObsEsc: Sim ou Não
        /// </summary>
        public string TestePermAltObsEsc
        {
            get
            {
                return _testePermAltObsEsc;
            }
            set
            {
                _testePermAltObsEsc = value;
            }
        }
        /// <summary>
        /// TestePermAltObsTeoria: Sim ou Não
        /// </summary>
        public string TestePermAltObsTeoria
        {
            get
            {
                return _testePermAltObsTeoria;
            }
            set
            {
                _testePermAltObsTeoria = value;
            }
        }
        public string TesteObsMet
        {
            get
            {
                return _testeObsMet;
            }
            set
            {
                _testeObsMet = value;
            }
        }
        public string TesteObsMts
        {
            get
            {
                return _testeObsMts;
            }
            set
            {
                _testeObsMts = value;
            }
        }
        public string TesteObsHino
        {
            get
            {
                return _testeObsHino;
            }
            set
            {
                _testeObsHino = value;
            }
        }
        public string TesteObsEsc
        {
            get
            {
                return _testeObsEsc;
            }
            set
            {
                _testeObsEsc = value;
            }
        }
        public string TesteObsTeoria
        {
            get
            {
                return _testeObsTeoria;
            }
            set
            {
                _testeObsTeoria = value;
            }
        }

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