using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.uteis;

namespace ENT.pessoa
{
    public class MOD_pessoa
    {
        public string CodPessoa { get; set; }
        public string Ativo { get; set; }
        public string DataCadastro { get; set; }
        public string HoraCadastro { get; set; }
        public string Nome { get; set; }
        public string DataNasc { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string OrgaoEmissor { get; set; }
        public string Sexo { get; set; }
        public string DataBatismo { get; set; }
        public string CodCidadeRes { get; set; }
        public string CidadeRes { get; set; }
        public string EstadoRes { get; set; }
        public string CepRes { get; set; }
        public string EndRes { get; set; }
        public string NumRes { get; set; }
        public string BairroRes { get; set; }
        public string ComplRes { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Celular1 { get; set; }
        public string Celular2 { get; set; }
        public string Email { get; set; }
        public string EstadoCivil { get; set; }
        public string DataApresentacao { get; set; }
        public string PaisCCB { get; set; }
        public string Pai { get; set; }
        public string Mae { get; set; }
        public string InstrutorSeguro { get; set; }
        public string FormacaoFora { get; set; }
        public string LocalFormacao { get; set; }
        public string QualFormacao { get; set; }
        public string OutraOrquestra { get; set; }
        public string Orquestra1 { get; set; }
        public string Funcao1 { get; set; }
        public string Orquestra2 { get; set; }
        public string Funcao2 { get; set; }
        public string Orquestra3 { get; set; }
        public string Funcao3 { get; set; }
        public string AtendeComum { get; set; }
        public string AtendeRegiao { get; set; }
        public string AtendeGEM { get; set; }
        public string AtendeEnsaioLocal { get; set; }
        public string AtendeEnsaioRegional { get; set; }
        public string AtendeEnsaioParcial { get; set; }
        public string AtendeEnsaioTecnico { get; set; }
        public string AtendeReuniaoMocidade { get; set; }
        public string AtendeBatismo { get; set; }
        public string AtendeSantaCeia { get; set; }
        public string AtendeRJM { get; set; }
        public string AtendePreTesteRjmMusico { get; set; }
        public string AtendePreTesteRjmOrganista { get; set; }
        public string AtendeTesteRjmMusico { get; set; }
        public string AtendeTesteRjmOrganista { get; set; }
        public string AtendePreTesteCultoMusico { get; set; }
        public string AtendePreTesteCultoOrganista { get; set; }
        public string AtendeTesteCultoMusico { get; set; }
        public string AtendeTesteCultoOrganista { get; set; }
        public string AtendePreTesteOficialMusico { get; set; }
        public string AtendePreTesteOficialOrganista { get; set; }
        public string AtendeTesteOficialMusico { get; set; }
        public string AtendeTesteOficialOrganista { get; set; }
        public string AtendeReuniaoMinisterial { get; set; }
        public string AtendeCasal { get; set; }
        public string AtendeOrdenacao { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string OrdemInstrumento { get; set; }
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
        public string Desenvolvimento { get; set; }
        public string DataUltimoTeste { get; set; }
        public string DataInicioEstudo { get; set; }
        public string ExecutInstrumento { get; set; }
        public string CodInstrutor { get; set; }
        public string NomeInstrutor { get; set; }
        public string Sequencia { get; set; }
        public string MotivoInativa { get; set; }

        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        
        //Tabela Cargo
        public string CodCargo { get; set; }
        public string DescCargo { get; set; }
        public string SiglaCargo { get; set; }
        public string OrdemCargo { get; set; }
        public string Feminino { get; set; }
        public string Masculino { get; set; }
        public string CodDepartamento { get; set; }
        public string DescDepartamento { get; set; }
        public string PermiteInstrumento { get; set; }

        //Tabela CCB
        public string CodCCB { get; set; }
        public string CodigoCCB { get; set; }
        public string Descricao { get; set; }
        public string EndCCB { get; set; }
        public string NumCCB { get; set; }
        public string BairroCCB { get; set; }
        public string ComplCCB { get; set; }
        public string CodCidadeCCB { get; set; }
        public string CidadeCCB { get; set; }
        public string EstadoCCB { get; set; }
        public string CepCCB { get; set; }
        public string TelefoneCCB { get; set; }
        public string CelularCCB { get; set; }
        public string EmailCCB { get; set; }

        public string CodCCBGem { get; set; }
        public string CodigoCCBGem { get; set; }
        public string DescricaoCCBGem { get; set; }
        public string EndCCBGem { get; set; }
        public string NumCCBGem { get; set; }
        public string BairroCCBGem { get; set; }
        public string ComplCCBGem { get; set; }
        public string CodCidadeCCBGem { get; set; }
        public string CidadeCCBGem { get; set; }
        public string EstadoCCBGem { get; set; }
        public string CepCCBGem { get; set; }
        public string TelefoneCCBGem { get; set; }
        public string CelularCCBGem { get; set; }
        public string EmailCCBGem { get; set; }

        //Tabela Regiao
        public string CodRegiaoCCB { get; set; }
        public string DescRegiaoCCB { get; set; }
        public string CodRegiaoCCBGem { get; set; }
        public string DescRegiaoCCBGem { get; set; }


        public List<MOD_cargo> listaCargo { get; set; }
        public List<MOD_pessoaInstr> listaPessoaInstr { get; set; }
        public List<MOD_pessoaMetodo> listaPessoaMet { get; set; }
        public BindingList<MOD_ccbPessoa> listaCCBPessoa { get; set; }
        public List<MOD_ccbPessoa> listaDeleteCCBPessoa { get; set; }
        public BindingList<MOD_regiaoPessoa> listaRegiaoPessoa { get; set; }
        public List<MOD_regiaoPessoa> listaDeleteRegiaoPessoa { get; set; }
        public MOD_pessoaFoto FotoPessoa { get; set; }
        public DataTable CarregarFotoPessoa { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoPessoa
    {
        public int progPessoa { get; set; } = 14;
        public int rotInsPessoa { get; set; } = 46;
        public int rotEditPessoa { get; set; } = 47;
        public int rotExcPessoa { get; set; } = 48;
        public int rotVisPessoa { get; set; } = 49;
        public int rotPesAdicionais { get; set; } = 123;
        public int rotPesInforGEM { get; set; } = 124;
        public int rotPesInforRJM { get; set; } = 125;
        public int rotPesInforCulto { get; set; } = 126;
        public int rotPesInforOficial { get; set; } = 127;
        public int rotPesAteInstrutor { get; set; } = 128;
        public int rotPesAteComum { get; set; } = 129;
        public int rotPesAteRegiao { get; set; } = 130;
        public int rotPesAdiForma { get; set; } = 131;
        public int rotPesAdiOrquetra { get; set; } = 132;
        public int rotPesAteraCargo { get; set; } = 134;
        public int rotPesAtendimento { get; set; } = 135;
        public int rotPesAdiInstrumento { get; set; } = 146;
        public int rotPesImportar { get; set; } = 164;
        public int rotPesGemMetodo { get; set; } = 168;
        public int rotPesImpFicha { get; set; } = 169;

        public int progRelGerais { get; set; } = 33;
        public int rotPesMixRelatorio { get; set; } = 170;
        public int rotPesRelMinisterio { get; set; } = 171;
        public int rotPesRelFichaCadastral { get; set; } = 226;
        public int rotPesRelVisaoGeral { get; set; } = 227;

    }
}