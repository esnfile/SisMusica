using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.administracao
{
    public class MOD_listaPresenca
    {
        //Dados da Tabela Reuniao Lista Presenca
        public string CodListaPresenca { get; set; }
        public string CodReuniao { get; set; }
        public string CodPessoa { get; set; }

        //Dados da Tabela Reunião Ministerio
        public string Status { get; set; }
        public string DataReuniao { get; set; }
        public string HoraReuniao { get; set; }
        public string CodTipoReuniao { get; set; }
        public string DescTipoReuniao { get; set; }
        public string CodUsuario { get; set; }
        public string Usuario { get; set; }
        public string CodCCBReuniao { get; set; }
        public string CodigoCCBReuniao { get; set; }
        public string DescricaoCCBReuniao { get; set; }
        public string CodRegiaoReuniao { get; set; }
        public string DescricaoRegiaoReuniao { get; set; }
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
        public string CodBiblia { get; set; }
        public string DescLivro { get; set; }
        public string Capitulo { get; set; }
        public string VersoInicio { get; set; }
        public string VersoFim { get; set; }
        public string AssuntoPalavra { get; set; }
        public string HinoAbertura { get; set; }

        //Dados da Tabela Pessoa
        public string Nome { get; set; }
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
        public bool Presente { get; set; }

        public List<MOD_pessoa> listaPessoa { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoListaPresenca
    {
        public int progPresenca { get; set; } = 39;
        public int rotInsPresenca { get; set; } = 217;
        public int rotExcPresenca { get; set; } = 218;
    }

    public class MOD_totalListaPresenca
    {
        public string DescCargo { get; set; }
        public string CodCargo { get; set; }
        public string OrdemCargo { get; set; }
        public string SiglaCargo { get; set; }
        public string CodRegiao { get; set; }
        public string DescRegiao { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string Masculino { get; set; }
        public string Feminino { get; set; }
        public bool Presenca { get; set; }
        public decimal QtdePresenteMasc { get; set; }
        public decimal QtdeAusenteMasc { get; set; }
        public decimal QtdeTotalMasc { get; set; }
        public decimal PercPresenteMasc { get; set; }
        public decimal PercAusenteMasc { get; set; }
        public decimal PercTotalMasc { get; set; }
        public decimal QtdePresenteFem { get; set; }
        public decimal QtdeAusenteFem { get; set; }
        public decimal QtdeTotalFem { get; set; }
        public decimal PercPresenteFem { get; set; }
        public decimal PercAusenteFem { get; set; }
        public decimal PercTotalFem { get; set; }
    }
}