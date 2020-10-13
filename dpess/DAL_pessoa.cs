using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;

using DAL.Acessa;
using ENT.Log;
using ENT.pessoa;

namespace DAL.pessoa
{
    public class DAL_pessoa
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idPessoa = null;

        #endregion

        #region Strings Sql da tabela Pessoa

        //string de insert na tabela Pessoa
        private string strInsert = "INSERT INTO Pessoa (CodPessoa, Ativo, DataCadastro, HoraCadastro, CodCargo, Nome, " +
"DataNasc, Cpf, Rg, Sexo, DataBatismo, CodCidadeRes, EndRes, NumRes, BairroRes, ComplRes, Telefone1, Telefone2, " +
"Celular1, Celular2, Email, CodCCB, EstadoCivil, DataApresentacao, PaisCCB, Pai, Mae, InstrutorSeguro, FormacaoFora, " +
"LocalFormacao, QualFormacao, OutraOrquestra, Orquestra1, Funcao1, Orquestra2, Funcao2, Orquestra3, Funcao3, AtendeComum, AtendeRegiao, " +
"AtendeGEM, AtendeEnsaioLocal, AtendeEnsaioRegional, AtendeEnsaioParcial, AtendeEnsaioTecnico, AtendeReuniaoMocidade, " +
"AtendeBatismo, AtendeSantaCeia, AtendeRJM, AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista, AtendeTesteRjmMusico, AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista, AtendeTesteCultoMusico, AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista, AtendeTesteOficialMusico, AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial, CodInstrumento, CodCCBGem, Desenvolvimento, DataUltimoTeste, DataInicioEstudo, ExecutInstrumento, " +
"CodInstrutor, OrgaoEmissor, MotivoInativa) " +
"VALUES (@CodPessoa, @Ativo, @DataCadastro, @HoraCadastro, @CodCargo, @Nome, " +
"@DataNasc, @Cpf, @Rg, @Sexo, @DataBatismo, @CodCidadeRes, @EndRes, @NumRes, @BairroRes, @ComplRes, @Telefone1, @Telefone2, " +
"@Celular1, @Celular2, @Email, @CodCCB, @EstadoCivil, @DataApresentacao, @PaisCCB, @Pai, @Mae, @InstrutorSeguro, @FormacaoFora, " +
"@LocalFormacao, @QualFormacao, @OutraOrquestra, @Orquestra1, @Funcao1, @Orquestra2, @Funcao2, @Orquestra3, @Funcao3, @AtendeComum, @AtendeRegiao, " +
"@AtendeGEM, @AtendeEnsaioLocal, @AtendeEnsaioRegional, @AtendeEnsaioParcial, @AtendeEnsaioTecnico, @AtendeReuniaoMocidade, " +
"@AtendeBatismo, @AtendeSantaCeia, @AtendeRJM, @AtendePreTesteRjmMusico, @AtendePreTesteRjmOrganista, @AtendeTesteRjmMusico, @AtendeTesteRjmOrganista, " +
"@AtendePreTesteCultoMusico, @AtendePreTesteCultoOrganista, @AtendeTesteCultoMusico, @AtendeTesteCultoOrganista, " +
"@AtendePreTesteOficialMusico, @AtendePreTesteOficialOrganista, @AtendeTesteOficialMusico, @AtendeTesteOficialOrganista," +
"@AtendeReuniaoMinisterial, @CodInstrumento, @CodCCBGem, @Desenvolvimento, @DataUltimoTeste, @DataInicioEstudo, " +
"@ExecutInstrumento, @CodInstrutor, @OrgaoEmissor, @MotivoInativa) ";

        //string de update na tabela Pessoa
        private string strUpdate = "UPDATE Pessoa SET Ativo = @Ativo, DataCadastro = @DataCadastro, " +
"HoraCadastro = @HoraCadastro, CodCargo = @CodCargo, Nome = @Nome, DataNasc = @DataNasc, Cpf = @Cpf, Rg = @Rg, " +
"Sexo = @Sexo, DataBatismo = @DataBatismo, CodCidadeRes = @CodCidadeRes, EndRes = @EndRes, NumRes = @NumRes, " +
"BairroRes = @BairroRes, ComplRes = @ComplRes, Telefone1 = @Telefone1, Telefone2 = @Telefone2, " +
"Celular1 = @Celular1, Celular2 = @Celular2, Email = @Email, CodCCB = @CodCCB, EstadoCivil = @EstadoCivil, " +
"DataApresentacao = @DataApresentacao, PaisCCB = @PaisCCB, Pai = @Pai, Mae = @Mae, InstrutorSeguro = @InstrutorSeguro, " +
"FormacaoFora = @FormacaoFora, LocalFormacao = @LocalFormacao, QualFormacao = @QualFormacao, OutraOrquestra = @OutraOrquestra, Orquestra1 = @Orquestra1, " +
"Funcao1 = @Funcao1, Orquestra2 = @Orquestra2, Funcao2 = @Funcao2, Orquestra3 = @Orquestra3, Funcao3 = @Funcao3, " +
"AtendeComum = @AtendeComum, AtendeRegiao = @AtendeRegiao, AtendeGEM = @AtendeGEM, AtendeEnsaioLocal = @AtendeEnsaioLocal, " +
"AtendeEnsaioRegional = @AtendeEnsaioRegional, AtendeEnsaioParcial = @AtendeEnsaioParcial, AtendeEnsaioTecnico = @AtendeEnsaioTecnico, " +
"AtendeReuniaoMocidade = @AtendeReuniaoMocidade, AtendeBatismo = @AtendeBatismo, AtendeSantaCeia = @AtendeSantaCeia, " +
"AtendeRJM = @AtendeRJM, AtendePreTesteRjmMusico = @AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista = @AtendePreTesteRjmOrganista, " +
"AtendeTesteRjmMusico = @AtendeTesteRjmMusico, AtendeTesteRjmOrganista = @AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico = @AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista = @AtendePreTesteCultoOrganista, " +
"AtendeTesteCultoMusico = @AtendeTesteCultoMusico, AtendeTesteCultoOrganista = @AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico = @AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista = @AtendePreTesteOficialOrganista, " +
"AtendeTesteOficialMusico = @AtendeTesteOficialMusico, AtendeTesteOficialOrganista = @AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial = @AtendeReuniaoMinisterial, CodInstrumento = @CodInstrumento, CodCCBGem = @CodCCBGem, " +
"Desenvolvimento = @Desenvolvimento, DataUltimoTeste = @DataUltimoTeste, DataInicioEstudo = @DataInicioEstudo, " +
"ExecutInstrumento = @ExecutInstrumento, CodInstrutor = @CodInstrutor, OrgaoEmissor = @OrgaoEmissor, MotivoInativa = @MotivoInativa " +
"WHERE CodPessoa = @CodPessoa ";

        //string de delete na tabela Pessoa
        private string strDelete = "DELETE FROM Pessoa WHERE CodPessoa = @CodPessoa ";

        //string de select na tabela Pessoa
        private string strSelect = "SELECT P.CodPessoa, P.Ativo, P.DataCadastro, P.HoraCadastro, P.CodCargo, P.Nome, " + //Tabela Pessoa
"P.DataNasc, P.Cpf, P.Rg, P.Sexo, P.DataBatismo, P.CodCidadeRes, P.EndRes, P.NumRes, P.BairroRes, P.ComplRes, P.Telefone1, P.Telefone2, " +
"P.Celular1, P.Celular2, P.Email, P.CodCCB, P.EstadoCivil, P.DataApresentacao, P.PaisCCB, P.Pai, P.Mae, P.InstrutorSeguro, P.FormacaoFora, " +
"P.LocalFormacao, P.QualFormacao, P.OutraOrquestra, P.Orquestra1, P.Funcao1, P.Orquestra2, P.Funcao2, P.Orquestra3, P.Funcao3, " +
"P.AtendeComum, P.AtendeRegiao, P.AtendeGEM, P.AtendeEnsaioLocal, P.AtendeEnsaioRegional, P.AtendeEnsaioParcial, P.AtendeEnsaioTecnico, " +
"P.AtendeReuniaoMocidade, P.AtendeBatismo, P.AtendeSantaCeia, P.AtendeRJM, P.AtendePreTesteRjmMusico, P.AtendePreTesteRjmOrganista, " +
"P.AtendeTesteRjmMusico, P.AtendeTesteRjmOrganista, P.AtendePreTesteCultoMusico, P.AtendePreTesteCultoOrganista, " +
"P.AtendeTesteCultoMusico, P.AtendeTesteCultoOrganista, P.AtendePreTesteOficialMusico, P.AtendePreTesteOficialOrganista, " +
"P.AtendeTesteOficialMusico, P.AtendeTesteOficialOrganista, P.AtendeReuniaoMinisterial, P.AtendeCasal, P.AtendeOrdenacao, " +
"P.CodInstrumento, P.CodCCBGem, P.Desenvolvimento, P.DataUltimoTeste, P.DataInicioEstudo, P.ExecutInstrumento, P.CodInstrutor, " +
"P.OrgaoEmissor, P.MotivoInativa, " +
"CG.DescCargo, CG.SiglaCargo, CG.Ordem AS OrdemCargo, CG.PermiteInstrumento, CG.CodDepartamento, DG.DescDepartamento, " + // Tabela Cargo
"C.Cidade AS CidadeRes, C.Estado AS EstadoRes, C.Cep AS CepRes, " + //Tabela Cidade
"CM.Codigo AS CodigoCCB, CM.Descricao, CM.Endereco AS EndCCB, CM.Numero AS NumCCB, CM.Bairro AS BairroCCB, CM.Complemento AS ComplCCB, " + //Tabela CCB Res
"CM.CodCidade AS CodCidadeCCB, CM.Telefone AS TelefoneCCB, CM.Celular AS CelularCCB, CM.Email AS EmailCCB, CM.CodRegiao AS CodRegiaoCCB, " +
"CC.Cidade AS CidadeCCB, CC.Estado AS EstadoCCB, CC.Cep AS CepCCB, " + //Tabela Cidade da CCB
"CMG.Codigo AS CodigoCCBGem, CMG.Descricao AS DescricaoCCBGem, CMG.Endereco AS EndCCBGem, CMG.Numero AS NumCCBGem, " + //Tabela CCB GEM
"CMG.Bairro AS BairroCCBGem, CMG.Complemento AS ComplCCBGem, CMG.CodCidade AS CodCidadeCCBGem, CMG.Telefone AS TelefoneCCBGem, " +
"CMG.Celular AS CelularCCBGem, CMG.Email AS EmailCCBGem, CMG.CodRegiao AS CodRegiaoCCBGem, " +
"CCG.Cidade AS CidadeCCBGem, CCG.Estado AS EstadoCCBGem, CCG.Cep AS CepCCBGem, " + //Tabela Cidade CCB GEM
"PI.Nome AS NomeInstrutor, " + //Tabela Pessoa (Instrutor)
"I.DescInstrumento, I.CodFamilia, I.Ordem AS OrdemInstrumento, " + //Tabela Instrumento
"F.DescFamilia, " + //Tabela Familia Instrumento
"R.Descricao AS DescRegiaoCCB, " + //Tabela Regiao CCB Res
"RG.Descricao AS DescRegiaoCCBGem " + //Tabela Regiao CCB GEM
"FROM Pessoa AS P " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS C ON P.CodCidadeRes = C.CodCidade " +
"LEFT OUTER JOIN CCB AS CM ON P.CodCCB = CM.CodCCB " +
"LEFT OUTER JOIN Pessoa AS PI ON P.CodInstrutor = PI.CodPessoa " +
"LEFT OUTER JOIN CCB AS CMG ON P.CodCCBGem = CMG.CodCCB " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Cidade AS CC ON CM.CodCidade = CC.CodCidade " +
"LEFT OUTER JOIN Cidade AS CCG ON CMG.CodCidade = CCG.CodCidade " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia " +
"LEFT OUTER JOIN Departamento AS DG ON CG.CodDepartamento = DG.CodDepartamento " +
"LEFT OUTER JOIN RegiaoAtuacao AS R ON CM.CodRegiao = R.CodRegiao " +
"LEFT OUTER JOIN RegiaoAtuacao AS RG ON CMG.CodRegiao = RG.CodRegiao ";

        //string que retorna o próximo Id da tabela Pessoa
        private string strId = "SELECT MAX (CodPessoa) FROM Pessoa ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Pessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_pessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt.CodPessoa)));
                objParam.Add(new SqlParameter("@Ativo", string.IsNullOrEmpty(objEnt.Ativo) ? DBNull.Value as object : objEnt.Ativo as object));
                objParam.Add(new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object));
                objParam.Add(new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(objEnt.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCadastro) as object));
                objParam.Add(new SqlParameter("@CodCargo", string.IsNullOrEmpty(objEnt.CodCargo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCargo) as object));
                objParam.Add(new SqlParameter("@Nome", string.IsNullOrEmpty(objEnt.Nome) ? DBNull.Value as object : objEnt.Nome as object));
                objParam.Add(new SqlParameter("@DataNasc", string.IsNullOrEmpty(objEnt.DataNasc) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataNasc) as object));
                objParam.Add(new SqlParameter("@Cpf", string.IsNullOrEmpty(objEnt.Cpf) ? DBNull.Value as object : objEnt.Cpf as object));
                objParam.Add(new SqlParameter("@Rg", string.IsNullOrEmpty(objEnt.Rg) ? DBNull.Value as object : objEnt.Rg as object));
                objParam.Add(new SqlParameter("@Sexo", string.IsNullOrEmpty(objEnt.Sexo) ? DBNull.Value as object : objEnt.Sexo as object));
                objParam.Add(new SqlParameter("@DataBatismo", string.IsNullOrEmpty(objEnt.DataBatismo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataBatismo) as object));
                objParam.Add(new SqlParameter("@CodCidadeRes", string.IsNullOrEmpty(objEnt.CodCidadeRes) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCidadeRes) as object));
                objParam.Add(new SqlParameter("@EndRes", string.IsNullOrEmpty(objEnt.EndRes) ? DBNull.Value as object : objEnt.EndRes as object));
                objParam.Add(new SqlParameter("@NumRes", string.IsNullOrEmpty(objEnt.NumRes) ? DBNull.Value as object : objEnt.NumRes as object));
                objParam.Add(new SqlParameter("@BairroRes", string.IsNullOrEmpty(objEnt.BairroRes) ? DBNull.Value as object : objEnt.BairroRes as object));
                objParam.Add(new SqlParameter("@ComplRes", string.IsNullOrEmpty(objEnt.ComplRes) ? DBNull.Value as object : objEnt.ComplRes as object));
                objParam.Add(new SqlParameter("@Telefone1", string.IsNullOrEmpty(objEnt.Telefone1) ? DBNull.Value as object : objEnt.Telefone1 as object));
                objParam.Add(new SqlParameter("@Telefone2", string.IsNullOrEmpty(objEnt.Telefone2) ? DBNull.Value as object : objEnt.Telefone2 as object));
                objParam.Add(new SqlParameter("@Celular1", string.IsNullOrEmpty(objEnt.Celular1) ? DBNull.Value as object : objEnt.Celular1 as object));
                objParam.Add(new SqlParameter("@Celular2", string.IsNullOrEmpty(objEnt.Celular2) ? DBNull.Value as object : objEnt.Celular2 as object));
                objParam.Add(new SqlParameter("@Email", string.IsNullOrEmpty(objEnt.Email) ? DBNull.Value as object : objEnt.Email as object));
                objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object));
                objParam.Add(new SqlParameter("@EstadoCivil", string.IsNullOrEmpty(objEnt.EstadoCivil) ? DBNull.Value as object : objEnt.EstadoCivil as object));
                objParam.Add(new SqlParameter("@DataApresentacao", string.IsNullOrEmpty(objEnt.DataApresentacao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataApresentacao) as object));
                objParam.Add(new SqlParameter("@PaisCCB", string.IsNullOrEmpty(objEnt.PaisCCB) ? DBNull.Value as object : objEnt.PaisCCB as object));
                objParam.Add(new SqlParameter("@Pai", string.IsNullOrEmpty(objEnt.Pai) ? DBNull.Value as object : objEnt.Pai as object));
                objParam.Add(new SqlParameter("@Mae", string.IsNullOrEmpty(objEnt.Mae) ? DBNull.Value as object : objEnt.Mae as object));
                objParam.Add(new SqlParameter("@InstrutorSeguro", string.IsNullOrEmpty(objEnt.InstrutorSeguro) ? DBNull.Value as object : objEnt.InstrutorSeguro as object));
                objParam.Add(new SqlParameter("@FormacaoFora", string.IsNullOrEmpty(objEnt.FormacaoFora) ? DBNull.Value as object : objEnt.FormacaoFora as object));
                objParam.Add(new SqlParameter("@LocalFormacao", string.IsNullOrEmpty(objEnt.LocalFormacao) ? DBNull.Value as object : objEnt.LocalFormacao as object));
                objParam.Add(new SqlParameter("@QualFormacao", string.IsNullOrEmpty(objEnt.QualFormacao) ? DBNull.Value as object : objEnt.QualFormacao as object));
                objParam.Add(new SqlParameter("@OutraOrquestra", string.IsNullOrEmpty(objEnt.OutraOrquestra) ? DBNull.Value as object : objEnt.OutraOrquestra as object));
                objParam.Add(new SqlParameter("@Orquestra1", string.IsNullOrEmpty(objEnt.Orquestra1) ? DBNull.Value as object : objEnt.Orquestra1 as object));
                objParam.Add(new SqlParameter("@Funcao1", string.IsNullOrEmpty(objEnt.Funcao1) ? DBNull.Value as object : objEnt.Funcao1 as object));
                objParam.Add(new SqlParameter("@Orquestra2", string.IsNullOrEmpty(objEnt.Orquestra2) ? DBNull.Value as object : objEnt.Orquestra2 as object));
                objParam.Add(new SqlParameter("@Funcao2", string.IsNullOrEmpty(objEnt.Funcao2) ? DBNull.Value as object : objEnt.Funcao2 as object));
                objParam.Add(new SqlParameter("@Orquestra3", string.IsNullOrEmpty(objEnt.Orquestra3) ? DBNull.Value as object : objEnt.Orquestra3 as object));
                objParam.Add(new SqlParameter("@Funcao3", string.IsNullOrEmpty(objEnt.Funcao3) ? DBNull.Value as object : objEnt.Funcao3 as object));
                objParam.Add(new SqlParameter("@AtendeComum", string.IsNullOrEmpty(objEnt.AtendeComum) ? DBNull.Value as object : objEnt.AtendeComum as object));
                objParam.Add(new SqlParameter("@AtendeRegiao", string.IsNullOrEmpty(objEnt.AtendeRegiao) ? DBNull.Value as object : objEnt.AtendeRegiao as object));
                objParam.Add(new SqlParameter("@AtendeGEM", string.IsNullOrEmpty(objEnt.AtendeGEM) ? DBNull.Value as object : objEnt.AtendeGEM as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioLocal", string.IsNullOrEmpty(objEnt.AtendeEnsaioLocal) ? DBNull.Value as object : objEnt.AtendeEnsaioLocal as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioRegional", string.IsNullOrEmpty(objEnt.AtendeEnsaioRegional) ? DBNull.Value as object : objEnt.AtendeEnsaioRegional as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioParcial", string.IsNullOrEmpty(objEnt.AtendeEnsaioParcial) ? DBNull.Value as object : objEnt.AtendeEnsaioParcial as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioTecnico", string.IsNullOrEmpty(objEnt.AtendeEnsaioTecnico) ? DBNull.Value as object : objEnt.AtendeEnsaioTecnico as object));
                objParam.Add(new SqlParameter("@AtendeReuniaoMocidade", string.IsNullOrEmpty(objEnt.AtendeReuniaoMocidade) ? DBNull.Value as object : objEnt.AtendeReuniaoMocidade as object));
                objParam.Add(new SqlParameter("@AtendeBatismo", string.IsNullOrEmpty(objEnt.AtendeBatismo) ? DBNull.Value as object : objEnt.AtendeBatismo as object));
                objParam.Add(new SqlParameter("@AtendeSantaCeia", string.IsNullOrEmpty(objEnt.AtendeSantaCeia) ? DBNull.Value as object : objEnt.AtendeSantaCeia as object));
                objParam.Add(new SqlParameter("@AtendeRJM", string.IsNullOrEmpty(objEnt.AtendeRJM) ? DBNull.Value as object : objEnt.AtendeRJM as object));
                objParam.Add(new SqlParameter("@AtendePreTesteRjmMusico", string.IsNullOrEmpty(objEnt.AtendePreTesteRjmMusico) ? DBNull.Value as object : objEnt.AtendePreTesteRjmMusico as object));
                objParam.Add(new SqlParameter("@AtendePreTesteRjmOrganista", string.IsNullOrEmpty(objEnt.AtendePreTesteRjmOrganista) ? DBNull.Value as object : objEnt.AtendePreTesteRjmOrganista as object));
                objParam.Add(new SqlParameter("@AtendeTesteRjmMusico", string.IsNullOrEmpty(objEnt.AtendeTesteRjmMusico) ? DBNull.Value as object : objEnt.AtendeTesteRjmMusico as object));
                objParam.Add(new SqlParameter("@AtendeTesteRjmOrganista", string.IsNullOrEmpty(objEnt.AtendeTesteRjmOrganista) ? DBNull.Value as object : objEnt.AtendeTesteRjmOrganista as object));
                objParam.Add(new SqlParameter("@AtendePreTesteCultoMusico", string.IsNullOrEmpty(objEnt.AtendePreTesteCultoMusico) ? DBNull.Value as object : objEnt.AtendePreTesteCultoMusico as object));
                objParam.Add(new SqlParameter("@AtendePreTesteCultoOrganista", string.IsNullOrEmpty(objEnt.AtendePreTesteCultoOrganista) ? DBNull.Value as object : objEnt.AtendePreTesteCultoOrganista as object));
                objParam.Add(new SqlParameter("@AtendeTesteCultoMusico", string.IsNullOrEmpty(objEnt.AtendeTesteCultoMusico) ? DBNull.Value as object : objEnt.AtendeTesteCultoMusico as object));
                objParam.Add(new SqlParameter("@AtendeTesteCultoOrganista", string.IsNullOrEmpty(objEnt.AtendeTesteCultoOrganista) ? DBNull.Value as object : objEnt.AtendeTesteCultoOrganista as object));
                objParam.Add(new SqlParameter("@AtendePreTesteOficialMusico", string.IsNullOrEmpty(objEnt.AtendePreTesteOficialMusico) ? DBNull.Value as object : objEnt.AtendePreTesteOficialMusico as object));
                objParam.Add(new SqlParameter("@AtendePreTesteOficialOrganista", string.IsNullOrEmpty(objEnt.AtendePreTesteOficialOrganista) ? DBNull.Value as object : objEnt.AtendePreTesteOficialOrganista as object));
                objParam.Add(new SqlParameter("@AtendeTesteOficialMusico", string.IsNullOrEmpty(objEnt.AtendeTesteOficialMusico) ? DBNull.Value as object : objEnt.AtendeTesteOficialMusico as object));
                objParam.Add(new SqlParameter("@AtendeTesteOficialOrganista", string.IsNullOrEmpty(objEnt.AtendeTesteOficialOrganista) ? DBNull.Value as object : objEnt.AtendeTesteOficialOrganista as object));
                objParam.Add(new SqlParameter("@AtendeReuniaoMinisterial", string.IsNullOrEmpty(objEnt.AtendeReuniaoMinisterial) ? DBNull.Value as object : objEnt.AtendeReuniaoMinisterial as object));
                objParam.Add(new SqlParameter("@AtendeCasal", string.IsNullOrEmpty(objEnt.AtendeCasal) ? DBNull.Value as object : objEnt.AtendeCasal as object));
                objParam.Add(new SqlParameter("@AtendeOrdenacao", string.IsNullOrEmpty(objEnt.AtendeOrdenacao) ? DBNull.Value as object : objEnt.AtendeOrdenacao as object));
                objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                objParam.Add(new SqlParameter("@CodCCBGem", string.IsNullOrEmpty(objEnt.CodCCBGem) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCBGem) as object));
                objParam.Add(new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(objEnt.Desenvolvimento) ? DBNull.Value as object : objEnt.Desenvolvimento as object));
                objParam.Add(new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(objEnt.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataUltimoTeste) as object));
                objParam.Add(new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(objEnt.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInicioEstudo) as object));
                objParam.Add(new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(objEnt.ExecutInstrumento) ? DBNull.Value as object : objEnt.ExecutInstrumento as object));
                objParam.Add(new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(objEnt.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodInstrutor) as object));
                objParam.Add(new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(objEnt.OrgaoEmissor) ? DBNull.Value as object : objEnt.OrgaoEmissor as object));
                objParam.Add(new SqlParameter("@MotivoInativa", string.IsNullOrEmpty(objEnt.MotivoInativa) ? DBNull.Value as object : objEnt.MotivoInativa as object));

                blnRetorno = objAcessa.executar(strUpdate, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que faz INSERT na Tabela Pessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_pessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt.CodPessoa)));
                objParam.Add(new SqlParameter("@Ativo", string.IsNullOrEmpty(objEnt.Ativo) ? DBNull.Value as object : objEnt.Ativo as object));
                objParam.Add(new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object));
                objParam.Add(new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(objEnt.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCadastro) as object));
                objParam.Add(new SqlParameter("@CodCargo", string.IsNullOrEmpty(objEnt.CodCargo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCargo) as object));
                objParam.Add(new SqlParameter("@Nome", string.IsNullOrEmpty(objEnt.Nome) ? DBNull.Value as object : objEnt.Nome as object));
                objParam.Add(new SqlParameter("@DataNasc", string.IsNullOrEmpty(objEnt.DataNasc) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataNasc) as object));
                objParam.Add(new SqlParameter("@Cpf", string.IsNullOrEmpty(objEnt.Cpf) ? DBNull.Value as object : objEnt.Cpf as object));
                objParam.Add(new SqlParameter("@Rg", string.IsNullOrEmpty(objEnt.Rg) ? DBNull.Value as object : objEnt.Rg as object));
                objParam.Add(new SqlParameter("@Sexo", string.IsNullOrEmpty(objEnt.Sexo) ? DBNull.Value as object : objEnt.Sexo as object));
                objParam.Add(new SqlParameter("@DataBatismo", string.IsNullOrEmpty(objEnt.DataBatismo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataBatismo) as object));
                objParam.Add(new SqlParameter("@CodCidadeRes", string.IsNullOrEmpty(objEnt.CodCidadeRes) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCidadeRes) as object));
                objParam.Add(new SqlParameter("@EndRes", string.IsNullOrEmpty(objEnt.EndRes) ? DBNull.Value as object : objEnt.EndRes as object));
                objParam.Add(new SqlParameter("@NumRes", string.IsNullOrEmpty(objEnt.NumRes) ? DBNull.Value as object : objEnt.NumRes as object));
                objParam.Add(new SqlParameter("@BairroRes", string.IsNullOrEmpty(objEnt.BairroRes) ? DBNull.Value as object : objEnt.BairroRes as object));
                objParam.Add(new SqlParameter("@ComplRes", string.IsNullOrEmpty(objEnt.ComplRes) ? DBNull.Value as object : objEnt.ComplRes as object));
                objParam.Add(new SqlParameter("@Telefone1", string.IsNullOrEmpty(objEnt.Telefone1) ? DBNull.Value as object : objEnt.Telefone1 as object));
                objParam.Add(new SqlParameter("@Telefone2", string.IsNullOrEmpty(objEnt.Telefone2) ? DBNull.Value as object : objEnt.Telefone2 as object));
                objParam.Add(new SqlParameter("@Celular1", string.IsNullOrEmpty(objEnt.Celular1) ? DBNull.Value as object : objEnt.Celular1 as object));
                objParam.Add(new SqlParameter("@Celular2", string.IsNullOrEmpty(objEnt.Celular2) ? DBNull.Value as object : objEnt.Celular2 as object));
                objParam.Add(new SqlParameter("@Email", string.IsNullOrEmpty(objEnt.Email) ? DBNull.Value as object : objEnt.Email as object));
                objParam.Add(new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object));
                objParam.Add(new SqlParameter("@EstadoCivil", string.IsNullOrEmpty(objEnt.EstadoCivil) ? DBNull.Value as object : objEnt.EstadoCivil as object));
                objParam.Add(new SqlParameter("@DataApresentacao", string.IsNullOrEmpty(objEnt.DataApresentacao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataApresentacao) as object));
                objParam.Add(new SqlParameter("@PaisCCB", string.IsNullOrEmpty(objEnt.PaisCCB) ? DBNull.Value as object : objEnt.PaisCCB as object));
                objParam.Add(new SqlParameter("@Pai", string.IsNullOrEmpty(objEnt.Pai) ? DBNull.Value as object : objEnt.Pai as object));
                objParam.Add(new SqlParameter("@Mae", string.IsNullOrEmpty(objEnt.Mae) ? DBNull.Value as object : objEnt.Mae as object));
                objParam.Add(new SqlParameter("@InstrutorSeguro", string.IsNullOrEmpty(objEnt.InstrutorSeguro) ? DBNull.Value as object : objEnt.InstrutorSeguro as object));
                objParam.Add(new SqlParameter("@FormacaoFora", string.IsNullOrEmpty(objEnt.FormacaoFora) ? DBNull.Value as object : objEnt.FormacaoFora as object));
                objParam.Add(new SqlParameter("@LocalFormacao", string.IsNullOrEmpty(objEnt.LocalFormacao) ? DBNull.Value as object : objEnt.LocalFormacao as object));
                objParam.Add(new SqlParameter("@QualFormacao", string.IsNullOrEmpty(objEnt.QualFormacao) ? DBNull.Value as object : objEnt.QualFormacao as object));
                objParam.Add(new SqlParameter("@OutraOrquestra", string.IsNullOrEmpty(objEnt.OutraOrquestra) ? DBNull.Value as object : objEnt.OutraOrquestra as object));
                objParam.Add(new SqlParameter("@Orquestra1", string.IsNullOrEmpty(objEnt.Orquestra1) ? DBNull.Value as object : objEnt.Orquestra1 as object));
                objParam.Add(new SqlParameter("@Funcao1", string.IsNullOrEmpty(objEnt.Funcao1) ? DBNull.Value as object : objEnt.Funcao1 as object));
                objParam.Add(new SqlParameter("@Orquestra2", string.IsNullOrEmpty(objEnt.Orquestra2) ? DBNull.Value as object : objEnt.Orquestra2 as object));
                objParam.Add(new SqlParameter("@Funcao2", string.IsNullOrEmpty(objEnt.Funcao2) ? DBNull.Value as object : objEnt.Funcao2 as object));
                objParam.Add(new SqlParameter("@Orquestra3", string.IsNullOrEmpty(objEnt.Orquestra3) ? DBNull.Value as object : objEnt.Orquestra3 as object));
                objParam.Add(new SqlParameter("@Funcao3", string.IsNullOrEmpty(objEnt.Funcao3) ? DBNull.Value as object : objEnt.Funcao3 as object));
                objParam.Add(new SqlParameter("@AtendeComum", string.IsNullOrEmpty(objEnt.AtendeComum) ? DBNull.Value as object : objEnt.AtendeComum as object));
                objParam.Add(new SqlParameter("@AtendeRegiao", string.IsNullOrEmpty(objEnt.AtendeRegiao) ? DBNull.Value as object : objEnt.AtendeRegiao as object));
                objParam.Add(new SqlParameter("@AtendeGEM", string.IsNullOrEmpty(objEnt.AtendeGEM) ? DBNull.Value as object : objEnt.AtendeGEM as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioLocal", string.IsNullOrEmpty(objEnt.AtendeEnsaioLocal) ? DBNull.Value as object : objEnt.AtendeEnsaioLocal as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioRegional", string.IsNullOrEmpty(objEnt.AtendeEnsaioRegional) ? DBNull.Value as object : objEnt.AtendeEnsaioRegional as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioParcial", string.IsNullOrEmpty(objEnt.AtendeEnsaioParcial) ? DBNull.Value as object : objEnt.AtendeEnsaioParcial as object));
                objParam.Add(new SqlParameter("@AtendeEnsaioTecnico", string.IsNullOrEmpty(objEnt.AtendeEnsaioTecnico) ? DBNull.Value as object : objEnt.AtendeEnsaioTecnico as object));
                objParam.Add(new SqlParameter("@AtendeReuniaoMocidade", string.IsNullOrEmpty(objEnt.AtendeReuniaoMocidade) ? DBNull.Value as object : objEnt.AtendeReuniaoMocidade as object));
                objParam.Add(new SqlParameter("@AtendeBatismo", string.IsNullOrEmpty(objEnt.AtendeBatismo) ? DBNull.Value as object : objEnt.AtendeBatismo as object));
                objParam.Add(new SqlParameter("@AtendeSantaCeia", string.IsNullOrEmpty(objEnt.AtendeSantaCeia) ? DBNull.Value as object : objEnt.AtendeSantaCeia as object));
                objParam.Add(new SqlParameter("@AtendeRJM", string.IsNullOrEmpty(objEnt.AtendeRJM) ? DBNull.Value as object : objEnt.AtendeRJM as object));
                objParam.Add(new SqlParameter("@AtendePreTesteRjmMusico", string.IsNullOrEmpty(objEnt.AtendePreTesteRjmMusico) ? DBNull.Value as object : objEnt.AtendePreTesteRjmMusico as object));
                objParam.Add(new SqlParameter("@AtendePreTesteRjmOrganista", string.IsNullOrEmpty(objEnt.AtendePreTesteRjmOrganista) ? DBNull.Value as object : objEnt.AtendePreTesteRjmOrganista as object));
                objParam.Add(new SqlParameter("@AtendeTesteRjmMusico", string.IsNullOrEmpty(objEnt.AtendeTesteRjmMusico) ? DBNull.Value as object : objEnt.AtendeTesteRjmMusico as object));
                objParam.Add(new SqlParameter("@AtendeTesteRjmOrganista", string.IsNullOrEmpty(objEnt.AtendeTesteRjmOrganista) ? DBNull.Value as object : objEnt.AtendeTesteRjmOrganista as object));
                objParam.Add(new SqlParameter("@AtendePreTesteCultoMusico", string.IsNullOrEmpty(objEnt.AtendePreTesteCultoMusico) ? DBNull.Value as object : objEnt.AtendePreTesteCultoMusico as object));
                objParam.Add(new SqlParameter("@AtendePreTesteCultoOrganista", string.IsNullOrEmpty(objEnt.AtendePreTesteCultoOrganista) ? DBNull.Value as object : objEnt.AtendePreTesteCultoOrganista as object));
                objParam.Add(new SqlParameter("@AtendeTesteCultoMusico", string.IsNullOrEmpty(objEnt.AtendeTesteCultoMusico) ? DBNull.Value as object : objEnt.AtendeTesteCultoMusico as object));
                objParam.Add(new SqlParameter("@AtendeTesteCultoOrganista", string.IsNullOrEmpty(objEnt.AtendeTesteCultoOrganista) ? DBNull.Value as object : objEnt.AtendeTesteCultoOrganista as object));
                objParam.Add(new SqlParameter("@AtendePreTesteOficialMusico", string.IsNullOrEmpty(objEnt.AtendePreTesteOficialMusico) ? DBNull.Value as object : objEnt.AtendePreTesteOficialMusico as object));
                objParam.Add(new SqlParameter("@AtendePreTesteOficialOrganista", string.IsNullOrEmpty(objEnt.AtendePreTesteOficialOrganista) ? DBNull.Value as object : objEnt.AtendePreTesteOficialOrganista as object));
                objParam.Add(new SqlParameter("@AtendeTesteOficialMusico", string.IsNullOrEmpty(objEnt.AtendeTesteOficialMusico) ? DBNull.Value as object : objEnt.AtendeTesteOficialMusico as object));
                objParam.Add(new SqlParameter("@AtendeTesteOficialOrganista", string.IsNullOrEmpty(objEnt.AtendeTesteOficialOrganista) ? DBNull.Value as object : objEnt.AtendeTesteOficialOrganista as object));
                objParam.Add(new SqlParameter("@AtendeReuniaoMinisterial", string.IsNullOrEmpty(objEnt.AtendeReuniaoMinisterial) ? DBNull.Value as object : objEnt.AtendeReuniaoMinisterial as object));
                objParam.Add(new SqlParameter("@AtendeCasal", string.IsNullOrEmpty(objEnt.AtendeCasal) ? DBNull.Value as object : objEnt.AtendeCasal as object));
                objParam.Add(new SqlParameter("@AtendeOrdenacao", string.IsNullOrEmpty(objEnt.AtendeOrdenacao) ? DBNull.Value as object : objEnt.AtendeOrdenacao as object));
                objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                objParam.Add(new SqlParameter("@CodCCBGem", string.IsNullOrEmpty(objEnt.CodCCBGem) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCBGem) as object));
                objParam.Add(new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(objEnt.Desenvolvimento) ? DBNull.Value as object : objEnt.Desenvolvimento as object));
                objParam.Add(new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(objEnt.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataUltimoTeste) as object));
                objParam.Add(new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(objEnt.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInicioEstudo) as object));
                objParam.Add(new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(objEnt.ExecutInstrumento) ? DBNull.Value as object : objEnt.ExecutInstrumento as object));
                objParam.Add(new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(objEnt.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodInstrutor) as object));
                objParam.Add(new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(objEnt.OrgaoEmissor) ? DBNull.Value as object : objEnt.OrgaoEmissor as object));
                objParam.Add(new SqlParameter("@MotivoInativa", string.IsNullOrEmpty(objEnt.MotivoInativa) ? DBNull.Value as object : objEnt.MotivoInativa as object));

                blnRetorno = objAcessa.executar(strInsert, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela Pessoa
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_pessoa objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodPessoa", Convert.ToInt64(objEnt.CodPessoa)));
                blnRetorno = objAcessa.executar(strDelete, objParam);

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funções para buscar os dados e Preencher os Valores

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPessoa)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPessoa = @CodPessoa ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código e Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPessoa, bool Ativo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim":"Não"));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Ativo LIKE @Ativo ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPessoa = @CodPessoa AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPessoa, string CodCCBUsu)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código, Comum e somente ativos
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPessoa, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPessoa, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Código, Comum e somente ativos
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodPessoa"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodPessoa, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa ", objParam, "Pessoa");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodPessoa", CodPessoa));
                    objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                    objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                    objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodPessoa = @CodPessoa AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.CodPessoa", objParam, "Pessoa");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Nome
        /// </summary>
        /// <param name="Nome"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Nome e Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Nome e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Nome e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Nome e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Nome e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarNome(string Nome, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cpf
        /// </summary>
        /// <param name="Cpf"></param>
        /// <returns></returns>
        public DataTable buscarCpf(string Cpf)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cpf", Cpf));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Cpf LIKE @Cpf ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cpf e Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCpf(string Cpf, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cpf", Cpf));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Cpf LIKE @Cpf AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cpf e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarCpf(string Cpf, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cpf", Cpf));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Cpf LIKE @Cpf AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cpf e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCpf(string Cpf, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cpf", Cpf));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Cpf LIKE @Cpf AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cpf e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarCpf(string Cpf, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cpf", Cpf));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Cpf LIKE @Cpf AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cpf e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="Cpf"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCpf(string Cpf, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Cpf", Cpf));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Cpf LIKE @Cpf AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public DataTable buscarPesRegiao(string CodRegiao)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CM.CodRegiao = @CodRegiao ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarPesRegiao(string CodRegiao, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarPesRegiao(string CodRegiao, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarPesRegiao(string CodRegiao, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarPesRegiao(string CodRegiao, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Regiao e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarPesRegiao(string CodRegiao, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodRegiao", CodRegiao));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE CM.CodRegiao = @CodRegiao AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Cidade
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string CodCidadeRes)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidadeRes));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCidadeRes = @CodCidadeRes ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Cidade e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string CodCidadeRes, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidadeRes));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCidadeRes = @CodCidadeRes AND P.Ativo LIKE @Ativo ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Cidade e a COmum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string CodCidadeRes, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidadeRes));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCidadeRes = @CodCidadeRes AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Cidade e a COmum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string CodCidadeRes, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidadeRes));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCidadeRes = @CodCidadeRes AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Cidade e a COmum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCB"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string CodCidadeRes, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidadeRes));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCidadeRes = @CodCidadeRes AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Cidade e a COmum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCidadeRes"></param>
        /// <param name="CodCCB"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCidade(string CodCidadeRes, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidadeRes));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCidadeRes = @CodCidadeRes AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cargo
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <returns></returns>
        public DataTable buscarCargo(string CodCargo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                //verificar qual é o campo a ser buscado
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCargo IN(@CodCargo) ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cargo e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCargo(string CodCargo, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                //verificar qual é o campo a ser buscado
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCargo IN(@CodCargo) AND P.Ativo LIKE @Ativo ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cargo e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarCargo(string CodCargo, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                //verificar qual é o campo a ser buscado
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCargo IN(" + @CodCargo + ") AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cargo e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCargo(string CodCargo, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                //verificar qual é o campo a ser buscado
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCargo IN(" + @CodCargo + ") AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cargo e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarCargo(string CodCargo, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                //verificar qual é o campo a ser buscado
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCargo = @CodCargo AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cargo e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarCargo(string CodCargo, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                //verificar qual é o campo a ser buscado
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCargo = @CodCargo AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Comum
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public DataTable buscarComum(string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodCCB ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Comum e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarComum(string CodCCB, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodCCB AND P.Ativo LIKE @Ativo ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Comum e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodComum"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarComum(string CodCCB, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodCCB AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Comum e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodComum"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarComum(string CodCCB, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodCCB AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Comum e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodComum"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarComum(string CodCCB, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodCCB AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pela Comum e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodComum"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarComum(string CodCCB, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB = @CodCCB AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY CG.Ordem, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento IN(@CodInstrumento) ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e o Ativo
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento IN(@CodInstrumento) AND P.Ativo LIKE @Ativo ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento, string CodCCBUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento, string CodCCBUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.Ativo LIKE @Ativo ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento, string CodCCBUsu, string CodCargoUsu)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarInstrumento(string CodInstrumento, string CodCCBUsu, string CodCargoUsu, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCBUsu", CodCCBUsu));
                objParam.Add(new SqlParameter("@CodCargoUsu", CodCargoUsu));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + @CodCCBUsu + ") AND P.CodCargo IN(" + @CodCargoUsu + ") AND P.Ativo LIKE @Ativo ORDER BY I.CodFamilia, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Instrumento e a Comum
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCB"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarVisaoOrquestral(string CodInstrumento, string CodCCB, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodInstrumento", CodInstrumento));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodInstrumento IN(" + @CodInstrumento + ") AND P.CodCCB IN(" + CodCCB + ") AND P.Ativo = @Ativo ORDER BY CC.Cidade, CM.Descricao, I.CodFamilia, P.Nome ", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));

                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Desenvolvimento", Desenvolvimento));

                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));

                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Ativo"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));

                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, EstadoCivil, Cargo e Comum
        /// <para></para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="DataInicial"></param>
        /// <param name="DataFinal"></param>
        /// <param name="Desenvolvimento"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@Desenvolvimento", Desenvolvimento));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                                "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                                "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                                "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                                "P.Sexo IN('" + @Sexo + "') AND " +
                                                                "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                                "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, Ativo, EstadoCivil, Cargo e Comum
        /// <para>Ativo: Sim ou Não</para>
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <returns></returns>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " + 
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') ", objParam, "Pessoa");
                }

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Função de Relatório - retorna os Registros da tabela Pessoa, pesquisado pelo Sexo, Ativo, EstadoCivil, Cargo e Comum
        /// <paramref name="Ativo"/>: true ou false - 
        /// <paramref name="Sexo"/>: Masculino, Feminino - 
        /// <paramref name="CampoData"/>: DataCadastro, DataNasc, DataApresentacao - 
        /// <paramref name="EstadoCivil"/>: Solteiro(a), Casado(a), Viúvo(a), Divorciado(a) - 
        /// <paramref name="Desenvolvimento"/>: Aluno GEM, Ensaios, Meia Hora, Reunião Jovens, Culto Oficial, Oficializado
        /// </summary>
        /// <param name="Sexo"></param>
        /// <param name="Ativo"></param>
        /// <param name="EstadoCivil"></param>
        /// <param name="CodCargo"></param>
        /// <param name="CodComum"></param>
        /// <param name="Desenvolvimento"></param>
        public DataTable buscarRelatorioPessoa(string Sexo, string EstadoCivil, string CodCargo, string CodCCB, bool Ativo, string CampoData, string DataInicial, string DataFinal, string Desenvolvimento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Sexo", Sexo));
                objParam.Add(new SqlParameter("@CodCCB", CodCCB));
                objParam.Add(new SqlParameter("@EstadoCivil", EstadoCivil));
                objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                objParam.Add(new SqlParameter("@Ativo", Ativo.Equals(true) ? "Sim" : "Não"));
                objParam.Add(new SqlParameter("@DataInicial", DataInicial));
                objParam.Add(new SqlParameter("@DataFinal", DataFinal));
                objParam.Add(new SqlParameter("@Desenvolvimento", Desenvolvimento));

                if (CampoData.Equals("DataCadastro"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataCadastro BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataNasc"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataNasc BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }
                else if (CampoData.Equals("DataApresentacao"))
                {
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.DataApresentacao BETWEEN @DataInicial AND @DataFinal AND " +
                                                            "P.CodCCB IN(" + @CodCCB + ") AND P.CodCargo IN(" + @CodCargo + ") AND " +
                                                            "P.Ativo = @Ativo AND P.Sexo IN('" + @Sexo + "') AND " +
                                                            "P.EstadoCivil IN('" + @EstadoCivil + "') AND " +
                                                            "P.Desenvolvimento IN('" + @Desenvolvimento + "') ", objParam, "Pessoa");
                }

                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, para importação de novos dados
        /// </summary>
        /// <param name="Nome"></param>
        /// <param name="DataNasc"></param>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public DataTable buscarPessoaDuplicada(string Nome, string DataNasc, string CodCidade)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@Nome", Nome));
                objParam.Add(new SqlParameter("@DataNasc", DataNasc));
                objParam.Add(new SqlParameter("@CodCidadeRes", CodCidade));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE P.Nome LIKE @Nome AND P.DataNasc = @DataNasc AND P.CodCidadeRes = @CodCidadeRes ORDER BY P.Nome", objParam, "Pessoa");
                return objDtb;
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funções Publicas e Privadas Usadas para retorno de Valores

        /// <summary>
        /// Função que retorna o Ultimo Código inserido na Tabela
        /// </summary>
        /// <returns></returns>
        public Int64 retornaId()
        {
            try
            {
                idPessoa = objAcessa.retornarId(strId);
                return Convert.ToInt64(idPessoa);
            }
            catch (SqlException exl)
            {
                throw exl;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}