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
    public class DAL_pessoa : IDAL_Pessoa
    {

        IConnect objAcessa = new acessa();
        IDAL_Pessoa_StrSql objDAL_Pessoa = new DAL_pessoa_StrSql();

        #region Instruções CRUD

        /// <summary>
        /// Função UPDATE - Utilziada para Atualizar os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Update(MOD_pessoa pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(pessoa.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodPessoa as object)),
                    new SqlParameter("@Ativo", string.IsNullOrEmpty(pessoa.Ativo) ? DBNull.Value as object : pessoa.Ativo as object),
                    new SqlParameter("@DataCadastro", string.IsNullOrEmpty(pessoa.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataCadastro) as object),
                    new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(pessoa.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(pessoa.HoraCadastro) as object),
                    new SqlParameter("@CodCargo", string.IsNullOrEmpty(pessoa.CodCargo) ? DBNull.Value as object : Convert.ToInt16(pessoa.CodCargo) as object),
                    new SqlParameter("@Nome", string.IsNullOrEmpty(pessoa.Nome) ? DBNull.Value as object : pessoa.Nome as object),
                    new SqlParameter("@DataNasc", string.IsNullOrEmpty(pessoa.DataNasc) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataNasc) as object),
                    new SqlParameter("@Cpf", string.IsNullOrEmpty(pessoa.Cpf) ? DBNull.Value as object : pessoa.Cpf as object),
                    new SqlParameter("@Rg", string.IsNullOrEmpty(pessoa.Rg) ? DBNull.Value as object : pessoa.Rg as object),
                    new SqlParameter("@Sexo", string.IsNullOrEmpty(pessoa.Sexo) ? DBNull.Value as object : pessoa.Sexo as object),
                    new SqlParameter("@DataBatismo", string.IsNullOrEmpty(pessoa.DataBatismo) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataBatismo) as object),
                    new SqlParameter("@CodCidadeRes", string.IsNullOrEmpty(pessoa.CodCidadeRes) ? DBNull.Value as object : Convert.ToInt32(pessoa.CodCidadeRes) as object),
                    new SqlParameter("@EndRes", string.IsNullOrEmpty(pessoa.EndRes) ? DBNull.Value as object : pessoa.EndRes as object),
                    new SqlParameter("@NumRes", string.IsNullOrEmpty(pessoa.NumRes) ? DBNull.Value as object : pessoa.NumRes as object),
                    new SqlParameter("@BairroRes", string.IsNullOrEmpty(pessoa.BairroRes) ? DBNull.Value as object : pessoa.BairroRes as object),
                    new SqlParameter("@ComplRes", string.IsNullOrEmpty(pessoa.ComplRes) ? DBNull.Value as object : pessoa.ComplRes as object),
                    new SqlParameter("@Telefone1", string.IsNullOrEmpty(pessoa.Telefone1) ? DBNull.Value as object : pessoa.Telefone1 as object),
                    new SqlParameter("@Telefone2", string.IsNullOrEmpty(pessoa.Telefone2) ? DBNull.Value as object : pessoa.Telefone2 as object),
                    new SqlParameter("@Celular1", string.IsNullOrEmpty(pessoa.Celular1) ? DBNull.Value as object : pessoa.Celular1 as object),
                    new SqlParameter("@Celular2", string.IsNullOrEmpty(pessoa.Celular2) ? DBNull.Value as object : pessoa.Celular2 as object),
                    new SqlParameter("@Email", string.IsNullOrEmpty(pessoa.Email) ? DBNull.Value as object : pessoa.Email as object),
                    new SqlParameter("@CodCCB", string.IsNullOrEmpty(pessoa.CodCCB) ? DBNull.Value as object : Convert.ToInt32(pessoa.CodCCB) as object),
                    new SqlParameter("@EstadoCivil", string.IsNullOrEmpty(pessoa.EstadoCivil) ? DBNull.Value as object : pessoa.EstadoCivil as object),
                    new SqlParameter("@DataApresentacao", string.IsNullOrEmpty(pessoa.DataApresentacao) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataApresentacao) as object),
                    new SqlParameter("@PaisCCB", string.IsNullOrEmpty(pessoa.PaisCCB) ? DBNull.Value as object : pessoa.PaisCCB as object),
                    new SqlParameter("@Pai", string.IsNullOrEmpty(pessoa.Pai) ? DBNull.Value as object : pessoa.Pai as object),
                    new SqlParameter("@Mae", string.IsNullOrEmpty(pessoa.Mae) ? DBNull.Value as object : pessoa.Mae as object),
                    new SqlParameter("@InstrutorSeguro", string.IsNullOrEmpty(pessoa.InstrutorSeguro) ? DBNull.Value as object : pessoa.InstrutorSeguro as object),
                    new SqlParameter("@FormacaoFora", string.IsNullOrEmpty(pessoa.FormacaoFora) ? DBNull.Value as object : pessoa.FormacaoFora as object),
                    new SqlParameter("@LocalFormacao", string.IsNullOrEmpty(pessoa.LocalFormacao) ? DBNull.Value as object : pessoa.LocalFormacao as object),
                    new SqlParameter("@QualFormacao", string.IsNullOrEmpty(pessoa.QualFormacao) ? DBNull.Value as object : pessoa.QualFormacao as object),
                    new SqlParameter("@OutraOrquestra", string.IsNullOrEmpty(pessoa.OutraOrquestra) ? DBNull.Value as object : pessoa.OutraOrquestra as object),
                    new SqlParameter("@Orquestra1", string.IsNullOrEmpty(pessoa.Orquestra1) ? DBNull.Value as object : pessoa.Orquestra1 as object),
                    new SqlParameter("@Funcao1", string.IsNullOrEmpty(pessoa.Funcao1) ? DBNull.Value as object : pessoa.Funcao1 as object),
                    new SqlParameter("@Orquestra2", string.IsNullOrEmpty(pessoa.Orquestra2) ? DBNull.Value as object : pessoa.Orquestra2 as object),
                    new SqlParameter("@Funcao2", string.IsNullOrEmpty(pessoa.Funcao2) ? DBNull.Value as object : pessoa.Funcao2 as object),
                    new SqlParameter("@Orquestra3", string.IsNullOrEmpty(pessoa.Orquestra3) ? DBNull.Value as object : pessoa.Orquestra3 as object),
                    new SqlParameter("@Funcao3", string.IsNullOrEmpty(pessoa.Funcao3) ? DBNull.Value as object : pessoa.Funcao3 as object),
                    new SqlParameter("@AtendeComum", string.IsNullOrEmpty(pessoa.AtendeComum) ? DBNull.Value as object : pessoa.AtendeComum as object),
                    new SqlParameter("@AtendeRegiao", string.IsNullOrEmpty(pessoa.AtendeRegiao) ? DBNull.Value as object : pessoa.AtendeRegiao as object),
                    new SqlParameter("@AtendeGEM", string.IsNullOrEmpty(pessoa.AtendeGEM) ? DBNull.Value as object : pessoa.AtendeGEM as object),
                    new SqlParameter("@AtendeEnsaioLocal", string.IsNullOrEmpty(pessoa.AtendeEnsaioLocal) ? DBNull.Value as object : pessoa.AtendeEnsaioLocal as object),
                    new SqlParameter("@AtendeEnsaioRegional", string.IsNullOrEmpty(pessoa.AtendeEnsaioRegional) ? DBNull.Value as object : pessoa.AtendeEnsaioRegional as object),
                    new SqlParameter("@AtendeEnsaioParcial", string.IsNullOrEmpty(pessoa.AtendeEnsaioParcial) ? DBNull.Value as object : pessoa.AtendeEnsaioParcial as object),
                    new SqlParameter("@AtendeEnsaioTecnico", string.IsNullOrEmpty(pessoa.AtendeEnsaioTecnico) ? DBNull.Value as object : pessoa.AtendeEnsaioTecnico as object),
                    new SqlParameter("@AtendeReuniaoMocidade", string.IsNullOrEmpty(pessoa.AtendeReuniaoMocidade) ? DBNull.Value as object : pessoa.AtendeReuniaoMocidade as object),
                    new SqlParameter("@AtendeBatismo", string.IsNullOrEmpty(pessoa.AtendeBatismo) ? DBNull.Value as object : pessoa.AtendeBatismo as object),
                    new SqlParameter("@AtendeSantaCeia", string.IsNullOrEmpty(pessoa.AtendeSantaCeia) ? DBNull.Value as object : pessoa.AtendeSantaCeia as object),
                    new SqlParameter("@AtendeRJM", string.IsNullOrEmpty(pessoa.AtendeRJM) ? DBNull.Value as object : pessoa.AtendeRJM as object),
                    new SqlParameter("@AtendePreTesteRjmMusico", string.IsNullOrEmpty(pessoa.AtendePreTesteRjmMusico) ? DBNull.Value as object : pessoa.AtendePreTesteRjmMusico as object),
                    new SqlParameter("@AtendePreTesteRjmOrganista", string.IsNullOrEmpty(pessoa.AtendePreTesteRjmOrganista) ? DBNull.Value as object : pessoa.AtendePreTesteRjmOrganista as object),
                    new SqlParameter("@AtendeTesteRjmMusico", string.IsNullOrEmpty(pessoa.AtendeTesteRjmMusico) ? DBNull.Value as object : pessoa.AtendeTesteRjmMusico as object),
                    new SqlParameter("@AtendeTesteRjmOrganista", string.IsNullOrEmpty(pessoa.AtendeTesteRjmOrganista) ? DBNull.Value as object : pessoa.AtendeTesteRjmOrganista as object),
                    new SqlParameter("@AtendePreTesteCultoMusico", string.IsNullOrEmpty(pessoa.AtendePreTesteCultoMusico) ? DBNull.Value as object : pessoa.AtendePreTesteCultoMusico as object),
                    new SqlParameter("@AtendePreTesteCultoOrganista", string.IsNullOrEmpty(pessoa.AtendePreTesteCultoOrganista) ? DBNull.Value as object : pessoa.AtendePreTesteCultoOrganista as object),
                    new SqlParameter("@AtendeTesteCultoMusico", string.IsNullOrEmpty(pessoa.AtendeTesteCultoMusico) ? DBNull.Value as object : pessoa.AtendeTesteCultoMusico as object),
                    new SqlParameter("@AtendeTesteCultoOrganista", string.IsNullOrEmpty(pessoa.AtendeTesteCultoOrganista) ? DBNull.Value as object : pessoa.AtendeTesteCultoOrganista as object),
                    new SqlParameter("@AtendePreTesteOficialMusico", string.IsNullOrEmpty(pessoa.AtendePreTesteOficialMusico) ? DBNull.Value as object : pessoa.AtendePreTesteOficialMusico as object),
                    new SqlParameter("@AtendePreTesteOficialOrganista", string.IsNullOrEmpty(pessoa.AtendePreTesteOficialOrganista) ? DBNull.Value as object : pessoa.AtendePreTesteOficialOrganista as object),
                    new SqlParameter("@AtendeTesteOficialMusico", string.IsNullOrEmpty(pessoa.AtendeTesteOficialMusico) ? DBNull.Value as object : pessoa.AtendeTesteOficialMusico as object),
                    new SqlParameter("@AtendeTesteOficialOrganista", string.IsNullOrEmpty(pessoa.AtendeTesteOficialOrganista) ? DBNull.Value as object : pessoa.AtendeTesteOficialOrganista as object),
                    new SqlParameter("@AtendeReuniaoMinisterial", string.IsNullOrEmpty(pessoa.AtendeReuniaoMinisterial) ? DBNull.Value as object : pessoa.AtendeReuniaoMinisterial as object),
                    new SqlParameter("@AtendeCasal", string.IsNullOrEmpty(pessoa.AtendeCasal) ? DBNull.Value as object : pessoa.AtendeCasal as object),
                    new SqlParameter("@AtendeOrdenacao", string.IsNullOrEmpty(pessoa.AtendeOrdenacao) ? DBNull.Value as object : pessoa.AtendeOrdenacao as object),
                    new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(pessoa.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(pessoa.CodInstrumento) as object),
                    new SqlParameter("@CodCCBGem", string.IsNullOrEmpty(pessoa.CodCCBGem) ? DBNull.Value as object : Convert.ToInt32(pessoa.CodCCBGem) as object),
                    new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(pessoa.Desenvolvimento) ? DBNull.Value as object : pessoa.Desenvolvimento as object),
                    new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(pessoa.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataUltimoTeste) as object),
                    new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(pessoa.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataInicioEstudo) as object),
                    new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(pessoa.ExecutInstrumento) ? DBNull.Value as object : pessoa.ExecutInstrumento as object),
                    new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(pessoa.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodInstrutor) as object),
                    new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(pessoa.OrgaoEmissor) ? DBNull.Value as object : pessoa.OrgaoEmissor as object),
                    new SqlParameter("@MotivoInativa", string.IsNullOrEmpty(pessoa.MotivoInativa) ? DBNull.Value as object : pessoa.MotivoInativa as object),
                    new SqlParameter("@CodigoRefBras", string.IsNullOrEmpty(pessoa.CodigoRefBras) ? DBNull.Value as object : pessoa.CodigoRefBras as object),
                    new SqlParameter("@CodigoRefRegiao", string.IsNullOrEmpty(pessoa.CodigoRefRegiao) ? DBNull.Value as object : pessoa.CodigoRefRegiao as object)
                };
                return blnRetorno = objAcessa.executar(objDAL_Pessoa.StrUpdate, objParam);
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
        /// Função INSERT - Utilziada para Inserir os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Insert(MOD_pessoa pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(pessoa.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodPessoa as object)),
                    new SqlParameter("@Ativo", string.IsNullOrEmpty(pessoa.Ativo) ? DBNull.Value as object : pessoa.Ativo as object),
                    new SqlParameter("@DataCadastro", string.IsNullOrEmpty(pessoa.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataCadastro) as object),
                    new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(pessoa.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(pessoa.HoraCadastro) as object),
                    new SqlParameter("@CodCargo", string.IsNullOrEmpty(pessoa.CodCargo) ? DBNull.Value as object : Convert.ToInt16(pessoa.CodCargo) as object),
                    new SqlParameter("@Nome", string.IsNullOrEmpty(pessoa.Nome) ? DBNull.Value as object : pessoa.Nome as object),
                    new SqlParameter("@DataNasc", string.IsNullOrEmpty(pessoa.DataNasc) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataNasc) as object),
                    new SqlParameter("@Cpf", string.IsNullOrEmpty(pessoa.Cpf) ? DBNull.Value as object : pessoa.Cpf as object),
                    new SqlParameter("@Rg", string.IsNullOrEmpty(pessoa.Rg) ? DBNull.Value as object : pessoa.Rg as object),
                    new SqlParameter("@Sexo", string.IsNullOrEmpty(pessoa.Sexo) ? DBNull.Value as object : pessoa.Sexo as object),
                    new SqlParameter("@DataBatismo", string.IsNullOrEmpty(pessoa.DataBatismo) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataBatismo) as object),
                    new SqlParameter("@CodCidadeRes", string.IsNullOrEmpty(pessoa.CodCidadeRes) ? DBNull.Value as object : Convert.ToInt32(pessoa.CodCidadeRes) as object),
                    new SqlParameter("@EndRes", string.IsNullOrEmpty(pessoa.EndRes) ? DBNull.Value as object : pessoa.EndRes as object),
                    new SqlParameter("@NumRes", string.IsNullOrEmpty(pessoa.NumRes) ? DBNull.Value as object : pessoa.NumRes as object),
                    new SqlParameter("@BairroRes", string.IsNullOrEmpty(pessoa.BairroRes) ? DBNull.Value as object : pessoa.BairroRes as object),
                    new SqlParameter("@ComplRes", string.IsNullOrEmpty(pessoa.ComplRes) ? DBNull.Value as object : pessoa.ComplRes as object),
                    new SqlParameter("@Telefone1", string.IsNullOrEmpty(pessoa.Telefone1) ? DBNull.Value as object : pessoa.Telefone1 as object),
                    new SqlParameter("@Telefone2", string.IsNullOrEmpty(pessoa.Telefone2) ? DBNull.Value as object : pessoa.Telefone2 as object),
                    new SqlParameter("@Celular1", string.IsNullOrEmpty(pessoa.Celular1) ? DBNull.Value as object : pessoa.Celular1 as object),
                    new SqlParameter("@Celular2", string.IsNullOrEmpty(pessoa.Celular2) ? DBNull.Value as object : pessoa.Celular2 as object),
                    new SqlParameter("@Email", string.IsNullOrEmpty(pessoa.Email) ? DBNull.Value as object : pessoa.Email as object),
                    new SqlParameter("@CodCCB", string.IsNullOrEmpty(pessoa.CodCCB) ? DBNull.Value as object : Convert.ToInt32(pessoa.CodCCB) as object),
                    new SqlParameter("@EstadoCivil", string.IsNullOrEmpty(pessoa.EstadoCivil) ? DBNull.Value as object : pessoa.EstadoCivil as object),
                    new SqlParameter("@DataApresentacao", string.IsNullOrEmpty(pessoa.DataApresentacao) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataApresentacao) as object),
                    new SqlParameter("@PaisCCB", string.IsNullOrEmpty(pessoa.PaisCCB) ? DBNull.Value as object : pessoa.PaisCCB as object),
                    new SqlParameter("@Pai", string.IsNullOrEmpty(pessoa.Pai) ? DBNull.Value as object : pessoa.Pai as object),
                    new SqlParameter("@Mae", string.IsNullOrEmpty(pessoa.Mae) ? DBNull.Value as object : pessoa.Mae as object),
                    new SqlParameter("@InstrutorSeguro", string.IsNullOrEmpty(pessoa.InstrutorSeguro) ? DBNull.Value as object : pessoa.InstrutorSeguro as object),
                    new SqlParameter("@FormacaoFora", string.IsNullOrEmpty(pessoa.FormacaoFora) ? DBNull.Value as object : pessoa.FormacaoFora as object),
                    new SqlParameter("@LocalFormacao", string.IsNullOrEmpty(pessoa.LocalFormacao) ? DBNull.Value as object : pessoa.LocalFormacao as object),
                    new SqlParameter("@QualFormacao", string.IsNullOrEmpty(pessoa.QualFormacao) ? DBNull.Value as object : pessoa.QualFormacao as object),
                    new SqlParameter("@OutraOrquestra", string.IsNullOrEmpty(pessoa.OutraOrquestra) ? DBNull.Value as object : pessoa.OutraOrquestra as object),
                    new SqlParameter("@Orquestra1", string.IsNullOrEmpty(pessoa.Orquestra1) ? DBNull.Value as object : pessoa.Orquestra1 as object),
                    new SqlParameter("@Funcao1", string.IsNullOrEmpty(pessoa.Funcao1) ? DBNull.Value as object : pessoa.Funcao1 as object),
                    new SqlParameter("@Orquestra2", string.IsNullOrEmpty(pessoa.Orquestra2) ? DBNull.Value as object : pessoa.Orquestra2 as object),
                    new SqlParameter("@Funcao2", string.IsNullOrEmpty(pessoa.Funcao2) ? DBNull.Value as object : pessoa.Funcao2 as object),
                    new SqlParameter("@Orquestra3", string.IsNullOrEmpty(pessoa.Orquestra3) ? DBNull.Value as object : pessoa.Orquestra3 as object),
                    new SqlParameter("@Funcao3", string.IsNullOrEmpty(pessoa.Funcao3) ? DBNull.Value as object : pessoa.Funcao3 as object),
                    new SqlParameter("@AtendeComum", string.IsNullOrEmpty(pessoa.AtendeComum) ? DBNull.Value as object : pessoa.AtendeComum as object),
                    new SqlParameter("@AtendeRegiao", string.IsNullOrEmpty(pessoa.AtendeRegiao) ? DBNull.Value as object : pessoa.AtendeRegiao as object),
                    new SqlParameter("@AtendeGEM", string.IsNullOrEmpty(pessoa.AtendeGEM) ? DBNull.Value as object : pessoa.AtendeGEM as object),
                    new SqlParameter("@AtendeEnsaioLocal", string.IsNullOrEmpty(pessoa.AtendeEnsaioLocal) ? DBNull.Value as object : pessoa.AtendeEnsaioLocal as object),
                    new SqlParameter("@AtendeEnsaioRegional", string.IsNullOrEmpty(pessoa.AtendeEnsaioRegional) ? DBNull.Value as object : pessoa.AtendeEnsaioRegional as object),
                    new SqlParameter("@AtendeEnsaioParcial", string.IsNullOrEmpty(pessoa.AtendeEnsaioParcial) ? DBNull.Value as object : pessoa.AtendeEnsaioParcial as object),
                    new SqlParameter("@AtendeEnsaioTecnico", string.IsNullOrEmpty(pessoa.AtendeEnsaioTecnico) ? DBNull.Value as object : pessoa.AtendeEnsaioTecnico as object),
                    new SqlParameter("@AtendeReuniaoMocidade", string.IsNullOrEmpty(pessoa.AtendeReuniaoMocidade) ? DBNull.Value as object : pessoa.AtendeReuniaoMocidade as object),
                    new SqlParameter("@AtendeBatismo", string.IsNullOrEmpty(pessoa.AtendeBatismo) ? DBNull.Value as object : pessoa.AtendeBatismo as object),
                    new SqlParameter("@AtendeSantaCeia", string.IsNullOrEmpty(pessoa.AtendeSantaCeia) ? DBNull.Value as object : pessoa.AtendeSantaCeia as object),
                    new SqlParameter("@AtendeRJM", string.IsNullOrEmpty(pessoa.AtendeRJM) ? DBNull.Value as object : pessoa.AtendeRJM as object),
                    new SqlParameter("@AtendePreTesteRjmMusico", string.IsNullOrEmpty(pessoa.AtendePreTesteRjmMusico) ? DBNull.Value as object : pessoa.AtendePreTesteRjmMusico as object),
                    new SqlParameter("@AtendePreTesteRjmOrganista", string.IsNullOrEmpty(pessoa.AtendePreTesteRjmOrganista) ? DBNull.Value as object : pessoa.AtendePreTesteRjmOrganista as object),
                    new SqlParameter("@AtendeTesteRjmMusico", string.IsNullOrEmpty(pessoa.AtendeTesteRjmMusico) ? DBNull.Value as object : pessoa.AtendeTesteRjmMusico as object),
                    new SqlParameter("@AtendeTesteRjmOrganista", string.IsNullOrEmpty(pessoa.AtendeTesteRjmOrganista) ? DBNull.Value as object : pessoa.AtendeTesteRjmOrganista as object),
                    new SqlParameter("@AtendePreTesteCultoMusico", string.IsNullOrEmpty(pessoa.AtendePreTesteCultoMusico) ? DBNull.Value as object : pessoa.AtendePreTesteCultoMusico as object),
                    new SqlParameter("@AtendePreTesteCultoOrganista", string.IsNullOrEmpty(pessoa.AtendePreTesteCultoOrganista) ? DBNull.Value as object : pessoa.AtendePreTesteCultoOrganista as object),
                    new SqlParameter("@AtendeTesteCultoMusico", string.IsNullOrEmpty(pessoa.AtendeTesteCultoMusico) ? DBNull.Value as object : pessoa.AtendeTesteCultoMusico as object),
                    new SqlParameter("@AtendeTesteCultoOrganista", string.IsNullOrEmpty(pessoa.AtendeTesteCultoOrganista) ? DBNull.Value as object : pessoa.AtendeTesteCultoOrganista as object),
                    new SqlParameter("@AtendePreTesteOficialMusico", string.IsNullOrEmpty(pessoa.AtendePreTesteOficialMusico) ? DBNull.Value as object : pessoa.AtendePreTesteOficialMusico as object),
                    new SqlParameter("@AtendePreTesteOficialOrganista", string.IsNullOrEmpty(pessoa.AtendePreTesteOficialOrganista) ? DBNull.Value as object : pessoa.AtendePreTesteOficialOrganista as object),
                    new SqlParameter("@AtendeTesteOficialMusico", string.IsNullOrEmpty(pessoa.AtendeTesteOficialMusico) ? DBNull.Value as object : pessoa.AtendeTesteOficialMusico as object),
                    new SqlParameter("@AtendeTesteOficialOrganista", string.IsNullOrEmpty(pessoa.AtendeTesteOficialOrganista) ? DBNull.Value as object : pessoa.AtendeTesteOficialOrganista as object),
                    new SqlParameter("@AtendeReuniaoMinisterial", string.IsNullOrEmpty(pessoa.AtendeReuniaoMinisterial) ? DBNull.Value as object : pessoa.AtendeReuniaoMinisterial as object),
                    new SqlParameter("@AtendeCasal", string.IsNullOrEmpty(pessoa.AtendeCasal) ? DBNull.Value as object : pessoa.AtendeCasal as object),
                    new SqlParameter("@AtendeOrdenacao", string.IsNullOrEmpty(pessoa.AtendeOrdenacao) ? DBNull.Value as object : pessoa.AtendeOrdenacao as object),
                    new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(pessoa.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(pessoa.CodInstrumento) as object),
                    new SqlParameter("@CodCCBGem", string.IsNullOrEmpty(pessoa.CodCCBGem) ? DBNull.Value as object : Convert.ToInt32(pessoa.CodCCBGem) as object),
                    new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(pessoa.Desenvolvimento) ? DBNull.Value as object : pessoa.Desenvolvimento as object),
                    new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(pessoa.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataUltimoTeste) as object),
                    new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(pessoa.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(pessoa.DataInicioEstudo) as object),
                    new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(pessoa.ExecutInstrumento) ? DBNull.Value as object : pessoa.ExecutInstrumento as object),
                    new SqlParameter("@CodInstrutor", string.IsNullOrEmpty(pessoa.CodInstrutor) ? DBNull.Value as object : Convert.ToInt64(pessoa.CodInstrutor) as object),
                    new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(pessoa.OrgaoEmissor) ? DBNull.Value as object : pessoa.OrgaoEmissor as object),
                    new SqlParameter("@MotivoInativa", string.IsNullOrEmpty(pessoa.MotivoInativa) ? DBNull.Value as object : pessoa.MotivoInativa as object),
                    new SqlParameter("@CodigoRefBras", string.IsNullOrEmpty(pessoa.CodigoRefBras) ? DBNull.Value as object : pessoa.CodigoRefBras as object),
                    new SqlParameter("@CodigoRefRegiao", string.IsNullOrEmpty(pessoa.CodigoRefRegiao) ? DBNull.Value as object : pessoa.CodigoRefRegiao as object)
                };
                return blnRetorno = objAcessa.executar(objDAL_Pessoa.StrInsert, objParam);
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
        /// Função DELETE - Utilziada para Excluir os dados na Base
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public bool Delete(MOD_pessoa pessoa)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Pessoa
                bool blnRetorno = true;

                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodPessoa", Convert.ToInt64(pessoa.CodPessoa))
                };

                return blnRetorno = objAcessa.executar(objDAL_Pessoa.StrDelete, objParam);
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

        #region Funções que retorna o próximo ID a ser inserido

        /// <summary>
        /// Função RETORNAID - Utilziada para Retornar o próximo ID
        /// </summary>
        /// <returns></returns>
        public Int64 RetornaId()
        {
            try
            {
                object idPessoa = objAcessa.retornarId(objDAL_Pessoa.StrRetornaId);
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