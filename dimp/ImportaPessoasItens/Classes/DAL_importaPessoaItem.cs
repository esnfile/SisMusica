using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DAL.Acessa;
using ENT.importa;

namespace DAL.importa
{
    public class DAL_importaPessoaItem : IDAL_ImportaPessoaItem
    {
        IConnect objAcessa = new acessa();
        IDAL_ImportaPessoaItem_StrSql objDAL = new DAL_ImportaPessoaItem_StrSql();

        #region Instruções CRUD

        /// <summary>
        /// Função UPDATE - Utilzada para Atualizar os dados na Base
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Update(MOD_importaPessoaItem objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoaItem
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    //parametros da tabela principal
                    new SqlParameter("@CodImportaPessoaItem", string.IsNullOrEmpty(objEnt.CodImportaPessoaItem) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodImportaPessoaItem) as object),
                    new SqlParameter("@CodImportaPessoa", string.IsNullOrEmpty(objEnt.CodImportaPessoa) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodImportaPessoa) as object),
                    new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object),
                    new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(objEnt.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCadastro) as object),
                    new SqlParameter("@CodCargo", string.IsNullOrEmpty(objEnt.CodCargo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCargo) as object),
                    new SqlParameter("@Nome", string.IsNullOrEmpty(objEnt.Nome) ? DBNull.Value as object : objEnt.Nome as object),
                    new SqlParameter("@DataNasc", string.IsNullOrEmpty(objEnt.DataNasc) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataNasc) as object),
                    new SqlParameter("@Cpf", string.IsNullOrEmpty(objEnt.Cpf) ? DBNull.Value as object : objEnt.Cpf as object),
                    new SqlParameter("@Rg", string.IsNullOrEmpty(objEnt.Rg) ? DBNull.Value as object : objEnt.Rg as object),
                    new SqlParameter("@Sexo", string.IsNullOrEmpty(objEnt.Sexo) ? DBNull.Value as object : objEnt.Sexo as object),
                    new SqlParameter("@DataBatismo", string.IsNullOrEmpty(objEnt.DataBatismo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataBatismo) as object),
                    new SqlParameter("@CodCidadeRes", string.IsNullOrEmpty(objEnt.CodCidadeRes) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCidadeRes) as object),
                    new SqlParameter("@EndRes", string.IsNullOrEmpty(objEnt.EndRes) ? DBNull.Value as object : objEnt.EndRes as object),
                    new SqlParameter("@NumRes", string.IsNullOrEmpty(objEnt.NumRes) ? DBNull.Value as object : objEnt.NumRes as object),
                    new SqlParameter("@BairroRes", string.IsNullOrEmpty(objEnt.BairroRes) ? DBNull.Value as object : objEnt.BairroRes as object),
                    new SqlParameter("@ComplRes", string.IsNullOrEmpty(objEnt.ComplRes) ? DBNull.Value as object : objEnt.ComplRes as object),
                    new SqlParameter("@Telefone1", string.IsNullOrEmpty(objEnt.Telefone1) ? DBNull.Value as object : objEnt.Telefone1 as object),
                    new SqlParameter("@Telefone2", string.IsNullOrEmpty(objEnt.Telefone2) ? DBNull.Value as object : objEnt.Telefone2 as object),
                    new SqlParameter("@Celular1", string.IsNullOrEmpty(objEnt.Celular1) ? DBNull.Value as object : objEnt.Celular1 as object),
                    new SqlParameter("@Celular2", string.IsNullOrEmpty(objEnt.Celular2) ? DBNull.Value as object : objEnt.Celular2 as object),
                    new SqlParameter("@Email", string.IsNullOrEmpty(objEnt.Email) ? DBNull.Value as object : objEnt.Email as object),
                    new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object),
                    new SqlParameter("@EstadoCivil", string.IsNullOrEmpty(objEnt.EstadoCivil) ? DBNull.Value as object : objEnt.EstadoCivil as object),
                    new SqlParameter("@DataApresentacao", string.IsNullOrEmpty(objEnt.DataApresentacao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataApresentacao) as object),
                    new SqlParameter("@PaisCCB", string.IsNullOrEmpty(objEnt.PaisCCB) ? DBNull.Value as object : objEnt.PaisCCB as object),
                    new SqlParameter("@Pai", string.IsNullOrEmpty(objEnt.Pai) ? DBNull.Value as object : objEnt.Pai as object),
                    new SqlParameter("@Mae", string.IsNullOrEmpty(objEnt.Mae) ? DBNull.Value as object : objEnt.Mae as object),
                    new SqlParameter("@FormacaoFora", string.IsNullOrEmpty(objEnt.FormacaoFora) ? DBNull.Value as object : objEnt.FormacaoFora as object),
                    new SqlParameter("@LocalFormacao", string.IsNullOrEmpty(objEnt.LocalFormacao) ? DBNull.Value as object : objEnt.LocalFormacao as object),
                    new SqlParameter("@QualFormacao", string.IsNullOrEmpty(objEnt.QualFormacao) ? DBNull.Value as object : objEnt.QualFormacao as object),
                    new SqlParameter("@OutraOrquestra", string.IsNullOrEmpty(objEnt.OutraOrquestra) ? DBNull.Value as object : objEnt.OutraOrquestra as object),
                    new SqlParameter("@Orquestra1", string.IsNullOrEmpty(objEnt.Orquestra1) ? DBNull.Value as object : objEnt.Orquestra1 as object),
                    new SqlParameter("@Funcao1", string.IsNullOrEmpty(objEnt.Funcao1) ? DBNull.Value as object : objEnt.Funcao1 as object),
                    new SqlParameter("@Orquestra2", string.IsNullOrEmpty(objEnt.Orquestra2) ? DBNull.Value as object : objEnt.Orquestra2 as object),
                    new SqlParameter("@Funcao2", string.IsNullOrEmpty(objEnt.Funcao2) ? DBNull.Value as object : objEnt.Funcao2 as object),
                    new SqlParameter("@Orquestra3", string.IsNullOrEmpty(objEnt.Orquestra3) ? DBNull.Value as object : objEnt.Orquestra3 as object),
                    new SqlParameter("@Funcao3", string.IsNullOrEmpty(objEnt.Funcao3) ? DBNull.Value as object : objEnt.Funcao3 as object),
                    new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object),
                    new SqlParameter("@CodCCBGem", string.IsNullOrEmpty(objEnt.CodCCBGem) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCBGem) as object),
                    new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(objEnt.Desenvolvimento) ? DBNull.Value as object : objEnt.Desenvolvimento as object),
                    new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(objEnt.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataUltimoTeste) as object),
                    new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(objEnt.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInicioEstudo) as object),
                    new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(objEnt.ExecutInstrumento) ? DBNull.Value as object : objEnt.ExecutInstrumento as object),
                    new SqlParameter("@Importado", string.IsNullOrEmpty(objEnt.Importado) ? DBNull.Value as object : objEnt.Importado as object),
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object),
                    new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(objEnt.OrgaoEmissor) ? DBNull.Value as object : objEnt.OrgaoEmissor as object),
                };

                return blnRetorno = objAcessa.executar(objDAL.StrUpdate, objParam);
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
        /// Função INSERT - Utilzada para Inserir os dados na Base
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Insert(MOD_importaPessoaItem objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela ImportaPessoaItem
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                {
                    //parametros da tabela principal
                    new SqlParameter("@CodImportaPessoaItem", string.IsNullOrEmpty(objEnt.CodImportaPessoaItem) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodImportaPessoaItem) as object),
                    new SqlParameter("@CodImportaPessoa", string.IsNullOrEmpty(objEnt.CodImportaPessoa) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodImportaPessoa) as object),
                    new SqlParameter("@DataCadastro", string.IsNullOrEmpty(objEnt.DataCadastro) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataCadastro) as object),
                    new SqlParameter("@HoraCadastro", string.IsNullOrEmpty(objEnt.HoraCadastro) ? DBNull.Value as object : Convert.ToInt16(objEnt.HoraCadastro) as object),
                    new SqlParameter("@CodCargo", string.IsNullOrEmpty(objEnt.CodCargo) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodCargo) as object),
                    new SqlParameter("@Nome", string.IsNullOrEmpty(objEnt.Nome) ? DBNull.Value as object : objEnt.Nome as object),
                    new SqlParameter("@DataNasc", string.IsNullOrEmpty(objEnt.DataNasc) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataNasc) as object),
                    new SqlParameter("@Cpf", string.IsNullOrEmpty(objEnt.Cpf) ? DBNull.Value as object : objEnt.Cpf as object),
                    new SqlParameter("@Rg", string.IsNullOrEmpty(objEnt.Rg) ? DBNull.Value as object : objEnt.Rg as object),
                    new SqlParameter("@Sexo", string.IsNullOrEmpty(objEnt.Sexo) ? DBNull.Value as object : objEnt.Sexo as object),
                    new SqlParameter("@DataBatismo", string.IsNullOrEmpty(objEnt.DataBatismo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataBatismo) as object),
                    new SqlParameter("@CodCidadeRes", string.IsNullOrEmpty(objEnt.CodCidadeRes) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCidadeRes) as object),
                    new SqlParameter("@EndRes", string.IsNullOrEmpty(objEnt.EndRes) ? DBNull.Value as object : objEnt.EndRes as object),
                    new SqlParameter("@NumRes", string.IsNullOrEmpty(objEnt.NumRes) ? DBNull.Value as object : objEnt.NumRes as object),
                    new SqlParameter("@BairroRes", string.IsNullOrEmpty(objEnt.BairroRes) ? DBNull.Value as object : objEnt.BairroRes as object),
                    new SqlParameter("@ComplRes", string.IsNullOrEmpty(objEnt.ComplRes) ? DBNull.Value as object : objEnt.ComplRes as object),
                    new SqlParameter("@Telefone1", string.IsNullOrEmpty(objEnt.Telefone1) ? DBNull.Value as object : objEnt.Telefone1 as object),
                    new SqlParameter("@Telefone2", string.IsNullOrEmpty(objEnt.Telefone2) ? DBNull.Value as object : objEnt.Telefone2 as object),
                    new SqlParameter("@Celular1", string.IsNullOrEmpty(objEnt.Celular1) ? DBNull.Value as object : objEnt.Celular1 as object),
                    new SqlParameter("@Celular2", string.IsNullOrEmpty(objEnt.Celular2) ? DBNull.Value as object : objEnt.Celular2 as object),
                    new SqlParameter("@Email", string.IsNullOrEmpty(objEnt.Email) ? DBNull.Value as object : objEnt.Email as object),
                    new SqlParameter("@CodCCB", string.IsNullOrEmpty(objEnt.CodCCB) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCB) as object),
                    new SqlParameter("@EstadoCivil", string.IsNullOrEmpty(objEnt.EstadoCivil) ? DBNull.Value as object : objEnt.EstadoCivil as object),
                    new SqlParameter("@DataApresentacao", string.IsNullOrEmpty(objEnt.DataApresentacao) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataApresentacao) as object),
                    new SqlParameter("@PaisCCB", string.IsNullOrEmpty(objEnt.PaisCCB) ? DBNull.Value as object : objEnt.PaisCCB as object),
                    new SqlParameter("@Pai", string.IsNullOrEmpty(objEnt.Pai) ? DBNull.Value as object : objEnt.Pai as object),
                    new SqlParameter("@Mae", string.IsNullOrEmpty(objEnt.Mae) ? DBNull.Value as object : objEnt.Mae as object),
                    new SqlParameter("@FormacaoFora", string.IsNullOrEmpty(objEnt.FormacaoFora) ? DBNull.Value as object : objEnt.FormacaoFora as object),
                    new SqlParameter("@LocalFormacao", string.IsNullOrEmpty(objEnt.LocalFormacao) ? DBNull.Value as object : objEnt.LocalFormacao as object),
                    new SqlParameter("@QualFormacao", string.IsNullOrEmpty(objEnt.QualFormacao) ? DBNull.Value as object : objEnt.QualFormacao as object),
                    new SqlParameter("@OutraOrquestra", string.IsNullOrEmpty(objEnt.OutraOrquestra) ? DBNull.Value as object : objEnt.OutraOrquestra as object),
                    new SqlParameter("@Orquestra1", string.IsNullOrEmpty(objEnt.Orquestra1) ? DBNull.Value as object : objEnt.Orquestra1 as object),
                    new SqlParameter("@Funcao1", string.IsNullOrEmpty(objEnt.Funcao1) ? DBNull.Value as object : objEnt.Funcao1 as object),
                    new SqlParameter("@Orquestra2", string.IsNullOrEmpty(objEnt.Orquestra2) ? DBNull.Value as object : objEnt.Orquestra2 as object),
                    new SqlParameter("@Funcao2", string.IsNullOrEmpty(objEnt.Funcao2) ? DBNull.Value as object : objEnt.Funcao2 as object),
                    new SqlParameter("@Orquestra3", string.IsNullOrEmpty(objEnt.Orquestra3) ? DBNull.Value as object : objEnt.Orquestra3 as object),
                    new SqlParameter("@Funcao3", string.IsNullOrEmpty(objEnt.Funcao3) ? DBNull.Value as object : objEnt.Funcao3 as object),
                    new SqlParameter("@CodInstrumento", string.IsNullOrEmpty(objEnt.CodInstrumento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodInstrumento) as object),
                    new SqlParameter("@CodCCBGem", string.IsNullOrEmpty(objEnt.CodCCBGem) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodCCBGem) as object),
                    new SqlParameter("@Desenvolvimento", string.IsNullOrEmpty(objEnt.Desenvolvimento) ? DBNull.Value as object : objEnt.Desenvolvimento as object),
                    new SqlParameter("@DataUltimoTeste", string.IsNullOrEmpty(objEnt.DataUltimoTeste) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataUltimoTeste) as object),
                    new SqlParameter("@DataInicioEstudo", string.IsNullOrEmpty(objEnt.DataInicioEstudo) ? DBNull.Value as object : Convert.ToInt32(objEnt.DataInicioEstudo) as object),
                    new SqlParameter("@ExecutInstrumento", string.IsNullOrEmpty(objEnt.ExecutInstrumento) ? DBNull.Value as object : objEnt.ExecutInstrumento as object),
                    new SqlParameter("@Importado", string.IsNullOrEmpty(objEnt.Importado) ? DBNull.Value as object : objEnt.Importado as object),
                    new SqlParameter("@CodPessoa", string.IsNullOrEmpty(objEnt.CodPessoa) ? DBNull.Value as object : Convert.ToInt64(objEnt.CodPessoa) as object),
                    new SqlParameter("@OrgaoEmissor", string.IsNullOrEmpty(objEnt.OrgaoEmissor) ? DBNull.Value as object : objEnt.OrgaoEmissor as object),
                };

                return blnRetorno = objAcessa.executar(objDAL.StrInsert, objParam);
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
        /// Função DELETE - Utilzada para Excluir os dados na Base
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool Delete(MOD_importaPessoaItem objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela
                bool blnRetorno = false;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodImportaPessoaItem", Convert.ToInt64(objEnt.CodImportaPessoaItem))
                };

                return blnRetorno = objAcessa.executar(objDAL.StrDelete, objParam);
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
        public Int64 RetornaId()
        {
            try
            {
                object idImportaItem = objAcessa.retornarId(objDAL.StrRetornaId);
                return Convert.ToInt64(idImportaItem);
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