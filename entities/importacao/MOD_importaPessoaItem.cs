using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.importa
{
    public class MOD_importaPessoaItem
    {
        public string CodImportaPessoaItem { get; set; }
        public string CodImportaPessoa { get; set; }
        public string DataCadastro { get; set; }
        public string HoraCadastro { get; set; }
        public string CodCargo { get; set; }
        public string DescCargo { get; set; }
        public string SiglaCargo { get; set; }
        public string OrdemCargo { get; set; }
        public string CodDepartamento { get; set; }
        public string DescDepartamento { get; set; }
        public string Nome { get; set; }
        public string DataNasc { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
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
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
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
        public string Desenvolvimento { get; set; }
        public string DataUltimoTeste { get; set; }
        public string DataInicioEstudo { get; set; }
        public string ExecutInstrumento { get; set; }
        public string Importado { get; set; }
        public string CodPessoa { get; set; }
        public string Sequencia { get; set; }
        public string OrgaoEmissor { get; set; }

        public MOD_log Logs { get; set; }
    }
}