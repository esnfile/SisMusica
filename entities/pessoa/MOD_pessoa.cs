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
        public string CodigoRefBras { get; set; }
        public string CodigoRefRegiao { get; set; }

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
        public BindingList<MOD_pessoaCCB> listaCCBPessoa { get; set; }
        public List<MOD_pessoaCCB> listaDeleteCCBPessoa { get; set; }
        public BindingList<MOD_regiaoPessoa> listaRegiaoPessoa { get; set; }
        public List<MOD_regiaoPessoa> listaDeleteRegiaoPessoa { get; set; }
        public MOD_pessoaFoto FotoPessoa { get; set; }
        public List<MOD_pessoaFoto> listaFotoPessoa { get; set; }
        public DataTable CarregarFotoPessoa { get; set; }

        public MOD_log Logs { get; set; }

    }

    public class MOD_acessoPessoa
    {
        public static int ProgPessoa { get; } = 14;
        public static int RotInsPessoa { get; } = 46;
        public static int RotEditPessoa { get; } = 47;
        public static int RotExcPessoa { get; } = 48;
        public static int RotVisPessoa { get; } = 49;
        public static int RotPesAdicionais { get; } = 123;
        public static int RotPesInforGEM { get; } = 124;
        public static int RotPesInforRJM { get; } = 125;
        public static int RotPesInforCulto { get; } = 126;
        public static int RotPesInforOficial { get; } = 127;

        /// <summary>
        /// Rotina que Libera a Aba Atendimento dos Instrumentos (Alteração de Instrumentos que atende e Informações)
        /// <para>Formulário Cadastro de Pessoas > Aba Atendimento > Aba Instrutores</para>
        /// </summary>
        public static int RotPesAteInstrutor { get; } = 128;

        /// <summary>
        /// Rotina que Libera a Aba Atendimento das Comumns (Alteração de Instrumentos que atende e Informações)
        /// <para>Formulário Cadastro de Pessoas > Aba Atendimento > Aba Comum</para>
        /// </summary>
        public static int RotPesAteComum { get; } = 129;

        /// <summary>
        /// Rotina que Libera a Aba Atendimento das Regiões (Alteração de Instrumentos que atende e Informações)
        /// <para>Formulário Cadastro de Pessoas > Aba Atendimento > Aba Região</para>
        /// </summary>
        public static int RotPesAteRegiao { get; } = 130;

        public static int RotPesAdiForma { get; } = 131;
        public static int RotPesAdiOrquetra { get; } = 132;
        public static int RotPesAteraCargo { get; } = 134;
        public static int RotPesAtendimento { get; } = 135;
        public static int RotPesAdiInstrumento { get; } = 146;
        public static int RotPesImportar { get; } = 164;
        public static int RotPesGemMetodo { get; } = 168;
        public static int RotPesImpFicha { get; } = 169;

        public static int ProgRelGerais { get; } = 33;
        public static int RotPesMixRelatorio { get; } = 170;
        public static int RotPesRelMinisterio { get; } = 171;
        public static int RotPesRelFichaCadastral { get; } = 226;
        public static int RotPesRelVisaoGeral { get; } = 227;
    }
}