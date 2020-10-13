using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.importa;

namespace DAL.importa
{
    public class DAL_importaPessoaItem
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela ImportaPessoaItem
        object idImportaItem = null;

        #endregion

        #region Strings Sql da tabela ImportaPessoaItem

        //string de insert na tabela ImportaPessoaItem
        private string strInsert = "INSERT INTO ImportaPessoaItem (CodImportaPessoaItem, CodImportaPessoa, DataCadastro, " +
"HoraCadastro, CodCargo, Nome, DataNasc, Cpf, Rg, Sexo, DataBatismo, CodCidadeRes, EndRes, NumRes, BairroRes, ComplRes, Telefone1, Telefone2, " +
"Celular1, Celular2, Email, CodCCB, EstadoCivil, DataApresentacao, PaisCCB, Pai, Mae, FormacaoFora, " +
"LocalFormacao, QualFormacao, OutraOrquestra, Orquestra1, Funcao1, Orquestra2, Funcao2, Orquestra3, Funcao3, " +
"CodInstrumento, Desenvolvimento, DataUltimoTeste, DataInicioEstudo, ExecutInstrumento, Importado, CodPessoa, OrgaoEmissor)  " +
"VALUES (@CodImportaPessoaItem, @CodImportaPessoa, @DataCadastro, @HoraCadastro, @CodCargo, @Nome, @DataNasc, " +
"@Cpf, @Rg, @Sexo, @DataBatismo, @CodCidadeRes, @EndRes, @NumRes, @BairroRes, @ComplRes, @Telefone1, @Telefone2, " +
"@Celular1, @Celular2, @Email, @CodCCB, @EstadoCivil, @DataApresentacao, @PaisCCB, @Pai, @Mae, @FormacaoFora, " +
"@LocalFormacao, @QualFormacao, @OutraOrquestra, @Orquestra1, @Funcao1, @Orquestra2, @Funcao2, @Orquestra3, @Funcao3, " +
"@CodInstrumento, @Desenvolvimento, @DataUltimoTeste, @DataInicioEstudo, @ExecutInstrumento, @Importado, @CodPessoa, @OrgaoEmissor) ";

        //string de update na tabela ImportaPessoaItem
        private string strUpdate = "UPDATE ImportaPessoaItem SET CodImportaPessoa = @CodImportaPessoa, DataCadastro = @DataCadastro, " +
"HoraCadastro = @HoraCadastro, CodCargo = @CodCargo, Nome = @Nome, DataNasc = @DataNasc, Cpf = @Cpf, Rg = @Rg, " +
"Sexo = @Sexo, DataBatismo = @DataBatismo, CodCidadeRes = @CodCidadeRes, EndRes = @EndRes, NumRes = @NumRes, " +
"BairroRes = @BairroRes, ComplRes = @ComplRes, Telefone1 = @Telefone1, Telefone2 = @Telefone2, " +
"Celular1 = @Celular1, Celular2 = @Celular2, Email = @Email, CodCCB = @CodCCB, EstadoCivil = @EstadoCivil, " +
"DataApresentacao = @DataApresentacao, PaisCCB = @PaisCCB, Pai = @Pai, Mae = @Mae, " +
"FormacaoFora = @FormacaoFora, LocalFormacao = @LocalFormacao, QualFormacao = @QualFormacao, OutraOrquestra = @OutraOrquestra, Orquestra1 = @Orquestra1, " +
"Funcao1 = @Funcao1, Orquestra2 = @Orquestra2, Funcao2 = @Funcao2, Orquestra3 = @Orquestra3, Funcao3 = @Funcao3, " +
"CodInstrumento = @CodInstrumento, " +
"Desenvolvimento = @Desenvolvimento, DataUltimoTeste = @DataUltimoTeste, DataInicioEstudo = @DataInicioEstudo, " +
"ExecutInstrumento = @ExecutInstrumento, Importado = @Importado, CodPessoa = @CodPessoa, OrgaoEmissor = @OrgaoEmissor " +
"WHERE CodImportaPessoaItem = @CodImportaPessoaItem ";

        //string de delete na tabela ImportaPessoaItem
        private string strDelete = "DELETE FROM ImportaPessoaItem WHERE CodImportaPessoaItem = @CodImportaPessoaItem ";

        //string de select na tabela ImportaPessoaItem
        private string strSelect = "SELECT P.CodImportaPessoaItem, P.CodImportaPessoa, P.DataCadastro, P.HoraCadastro, P.CodCargo, P.Nome, " +
"P.DataNasc, P.Cpf, P.Rg, P.Sexo, P.DataBatismo, P.CodCidadeRes, P.EndRes, P.NumRes, P.BairroRes, P.ComplRes, P.Telefone1, P.Telefone2, " +
"P.Celular1, P.Celular2, P.Email, P.CodCCB, P.EstadoCivil, P.DataApresentacao, P.PaisCCB, P.Pai, P.Mae, P.FormacaoFora, " +
"P.LocalFormacao, P.QualFormacao, P.OutraOrquestra, P.Orquestra1, P.Funcao1, P.Orquestra2, P.Funcao2, P.Orquestra3, P.Funcao3, " +
"P.CodInstrumento, P.Desenvolvimento, P.DataUltimoTeste, P.DataInicioEstudo, P.ExecutInstrumento, P.Importado, P.CodPessoa, P.OrgaoEmissor, " +
"CG.DescCargo, CG.SiglaCargo, CG.Ordem, C.Cidade AS CidadeRes, C.Estado AS EstadoRes, C.Cep AS CepRes, CM.Codigo AS CodigoCCB, CM.Descricao, " +
"CM.Endereco AS EndCCB, CM.Numero AS NumCCB, CM.Bairro AS BairroCCB, CM.Complemento AS ComplCCB, CM.CodCidade AS CodCidadeCCB, CM.Telefone AS TelefoneCCB, " +
"CM.Celular AS CelularCCB, CM.Email AS EmailCCB, CC.Cidade AS CidadeCCB, CC.Estado AS EstadoCCB, CC.Cep AS CepCCB, I.DescInstrumento, I.CodFamilia, F.DescFamilia " +
"FROM ImportaPessoaItem AS P " +
"LEFT OUTER JOIN Cargo AS CG ON P.CodCargo = CG.CodCargo " +
"LEFT OUTER JOIN Cidade AS C ON P.CodCidadeRes = C.CodCidade " +
"LEFT OUTER JOIN CCB AS CM ON P.CodCCB = CM.CodCCB " +
"LEFT OUTER JOIN Cidade AS CC ON CM.CodCidade = CC.CodCidade " +
"LEFT OUTER JOIN Instrumentos AS I ON P.CodInstrumento = I.CodInstrumento " +
"LEFT OUTER JOIN Familia AS F ON I.CodFamilia = F.CodFamilia ";

        //string que retorna o próximo Id da tabela ImportaPessoaItem
        private string strId = "SELECT MAX(CodImportaPessoaItem) FROM ImportaPessoaItem ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz INSERT e UPDATE na Tabela ImportaPessoaItem
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_importaPessoaItem objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoaItem
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (Convert.ToInt64(objEnt.CodImportaPessoaItem).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodImportaPessoaItem", retornaId()));
                    objParam.Add(new SqlParameter("@CodImportaPessoa", string.IsNullOrEmpty(objEnt.CodImportaPessoa) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodImportaPessoa) as object));
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
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(objEnt.Desenvolvimento) ? DBNull.Value as object : objEnt.Desenvolvimento as object));
                    objParam.Add(new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(objEnt.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataUltimoTeste) as object));
                    objParam.Add(new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(objEnt.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInicioEstudo) as object));
                    objParam.Add(new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(objEnt.ExecutInstrumento) ? DBNull.Value as object : objEnt.ExecutInstrumento as object));
                    objParam.Add(new SqlParameter("@Importado", string.IsNullOrEmpty(objEnt.Importado) ? DBNull.Value as object : objEnt.Importado as object));
                    objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                    objParam.Add(new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(objEnt.OrgaoEmissor) ? DBNull.Value as object : objEnt.OrgaoEmissor as object));

                    blnRetorno = objAcessa.executar(strInsert, objParam);
                }
                else
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodImportaPessoaItem", Convert.ToInt64(objEnt.CodImportaPessoaItem) as object));
                    objParam.Add(new SqlParameter("@CodImportaPessoa", string.IsNullOrEmpty(objEnt.CodImportaPessoa) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodImportaPessoa) as object));
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
                    objParam.Add(new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object));
                    objParam.Add(new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(objEnt.Desenvolvimento) ? DBNull.Value as object : objEnt.Desenvolvimento as object));
                    objParam.Add(new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(objEnt.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataUltimoTeste) as object));
                    objParam.Add(new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(objEnt.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInicioEstudo) as object));
                    objParam.Add(new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(objEnt.ExecutInstrumento) ? DBNull.Value as object : objEnt.ExecutInstrumento as object));
                    objParam.Add(new SqlParameter("@Importado", string.IsNullOrEmpty(objEnt.Importado) ? DBNull.Value as object : objEnt.Importado as object));
                    objParam.Add(new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object));
                    objParam.Add(new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(objEnt.OrgaoEmissor) ? DBNull.Value as object : objEnt.OrgaoEmissor as object));

                    blnRetorno = objAcessa.executar(strUpdate, objParam);
                }
                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                if (exl.Number.Equals(2601))
                {
                    throw new Exception("Não foi possivel salvar o registro, já que criaram" + "\n" +
                                        "valores duplicados na base de dados.");
                }
                else
                {
                    throw new Exception("Erro na DAL importaPessoaItem: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na DAL importaPessoaItem: " + ex.Message);
            }
        }

        #endregion

        #region Função para Excluir os dados na Base

        /// <summary>
        /// Função que faz DELETE na Tabela ImportaPessoaItem
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_importaPessoaItem objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();

                //se não estiver marcado, é feita a inclusao na tabela
                if (!Convert.ToInt64(objEnt.CodImportaPessoa).Equals(0))
                {
                    //parametros da tabela principal
                    objParam.Add(new SqlParameter("@CodImportaPessoaItem", Convert.ToInt64(objEnt.CodImportaPessoaItem)));
                    blnRetorno = objAcessa.executar(strDelete, objParam);
                }

                //retorna o blnRetorno da tabela principal
                return blnRetorno;

            }
            catch (SqlException exl)
            {
                if (exl.Number.Equals(547))
                {
                    throw new Exception("Impossivel excluir. Quebra de integridade!");
                }
                else
                {
                    throw new Exception("Erro: " + exl.Message + "\n" + "Erro nº: " + exl.Number);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Funções para buscar os dados e Preencher os Valores

        /// <summary>
        /// Função que retorna os Registros da tabela ImportaPessoaItem, pesquisado pelo Código
        /// </summary>
        /// <param name="CodImportaPessoa"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodImportaPessoa)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodImportaPessoa))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodImportaPessoa", Convert.ToInt32(CodImportaPessoa)));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodImportaPessoa ", objParam, "ImportaPessoaItem");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodImportaPessoa", Convert.ToInt32(CodImportaPessoa)));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodImportaPessoa = @CodImportaPessoa ORDER BY P.CodImportaPessoa", objParam, "ImportaPessoaItem");
                    return objDtb;
                }
            }
            catch (SqlException exl)
            {
                throw new Exception(exl.Message);
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
                idImportaItem = objAcessa.retornarId(strId);
                return Convert.ToInt64(idImportaItem);
            }
            catch (SqlException exl)
            {
                throw new Exception(exl.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

    }
}
