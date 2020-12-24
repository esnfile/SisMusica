using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using DAL.Acessa;
using ENT.Log;
using ENT.uteis;

namespace DAL.uteis
{
    public class DAL_parametros
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela Empresa
        object idParametro = null;

        #endregion

        #region Strings Sql da tabela Parametros

        //string de insert na tabela Parametros
        private string strInsert = "INSERT INTO Parametros (CodParametro, CodRegional, Ativacao, " +
"InformaAtiva, DiasAtiva, Atualizacao, CpfZerado, TrocaSenha, DiasTrocaSenha, CopiaSegura, DiasCopiaSegura, " +
"QtdeViasPreTeste, QtdeViasTeste, AlteraDadosImportPessoa, ValidarDadosImportacao, TesteMetodo, TesteHino, AlteraSolicita, " +
"AlteraQtdeLicoesPreTeste, AlteraQtdeLicoesTeste, QtdeHinoPreTesteRjm, QtdeEscalaPreTesteRjm, QtdeHinoTesteRjm, QtdeEscalaTesteRjm, " +
"QtdeHinoPreTesteMeia, QtdeEscalaPreTesteMeia, QtdeHinoTesteMeia, QtdeEscalaTesteMeia, QtdeHinoPreTesteMeia, QtdeEscalaPreTesteMeia, " +
"QtdeHinoTesteMeia, QtdeEscalaTesteMeia, QtdeHinoPreTesteCulto, QtdeEscalaPreTesteCulto, QtdeHinoTesteCulto, QtdeEscalaTesteCulto, " +
"QtdeHinoPreTesteOficial, QtdeEscalaPreTesteOficial, QtdeHinoTesteOficial, QtdeEscalaTesteOficial, RodapeRelatorio, " +
"TestePermAltObsMet, TesteObsMet, TestePermAltObsMts, TesteObsMts, TestePermAltObsHino, TesteObsHino, " +
"TestePermAltObsEsc, TesteObsEsc, TestePermAltObsTeoria, TesteObsTeoria) " +
"VALUES (@CodParametro, @CodRegional, @Ativacao, @InformaAtiva, @DiasAtiva, @Atualizacao, @CpfZerado, " +
"@TrocaSenha, @DiasTrocaSenha, @CopiaSegura, @DiasCopiaSegura, @QtdeViasPreTeste, @QtdeViasTeste, " +
"@AlteraDadosImportPessoa, ValidarDadosImportacao, @TesteMetodo, @TesteHino, @AlteraSolicita, " +
"@AlteraQtdeLicoesPreTeste, @AlteraQtdeLicoesTeste, @QtdeHinoPreTesteRjm, @QtdeEscalaPreTesteRjm, @QtdeHinoTesteRjm, @QtdeEscalaTesteRjm, " +
"@QtdeHinoPreTesteMeia, @QtdeEscalaPreTesteMeia, @QtdeHinoTesteMeia, @QtdeEscalaTesteMeia, @QtdeHinoPreTesteMeia, @QtdeEscalaPreTesteMeia, " +
"@QtdeHinoTesteMeia, @QtdeEscalaTesteMeia, @QtdeHinoPreTesteCulto, @QtdeEscalaPreTesteCulto, @QtdeHinoTesteCulto, @QtdeEscalaTesteCulto, " +
"@QtdeHinoPreTesteOficial, @QtdeEscalaPreTesteOficial, @QtdeHinoTesteOficial, @QtdeEscalaTesteOficial, @RodapeRelatorio, " +
"@TestePermAltObsMet, TesteObsMet, TestePermAltObsMts, TesteObsMts, TestePermAltObsHino, TesteObsHino, " +
"TestePermAltObsEsc, TesteObsEsc, TestePermAltObsTeoria, TesteObsTeoria)";


        //string de update na tabela Parametros
        private string strUpdate = "UPDATE Parametros SET CodRegional = @CodRegional, Ativacao = @Ativacao, " +
"InformaAtiva = @InformaAtiva, DiasAtiva = @DiasAtiva, Atualizacao = @Atualizacao, " +
"CpfZerado = @CpfZerado, TrocaSenha = @TrocaSenha, DiasTrocaSenha = @DiasTrocaSenha, " +
"CopiaSegura = @CopiaSegura, DiasCopiaSegura  = @DiasCopiaSegura, QtdeViasPreTeste = @QtdeViasPreTeste, " +
"QtdeViasTeste = @QtdeViasTeste, AlteraDadosImportPessoa = @AlteraDadosImportPessoa, " +
"ValidarDadosImportacao = @ValidarDadosImportacao, TesteMetodo = @TesteMetodo, TesteHino = @TesteHino, AlteraSolicita = @AlteraSolicita, " +
"AlteraQtdeLicoesPreTeste = @AlteraQtdeLicoesPreTeste, AlteraQtdeLicoesTeste = @AlteraQtdeLicoesTeste, " +
"QtdeHinoPreTesteRjm = @QtdeHinoPreTesteRjm, QtdeEscalaPreTesteRjm = @QtdeEscalaPreTesteRjm, " +
"QtdeHinoTesteRjm = @QtdeHinoTesteRjm, QtdeEscalaTesteRjm = @QtdeEscalaTesteRjm, " +
"QtdeHinoPreTesteMeia = @QtdeHinoPreTesteMeia, QtdeEscalaPreTesteMeia = @QtdeEscalaPreTesteMeia, " +
"QtdeHinoTesteMeia = @QtdeHinoTesteMeia, QtdeEscalaTesteMeia = @QtdeEscalaTesteMeia, " +
"QtdeHinoPreTesteCulto = @QtdeHinoPreTesteCulto, QtdeEscalaPreTesteCulto = @QtdeEscalaPreTesteCulto, " +
"QtdeHinoTesteCulto = @QtdeHinoTesteCulto, QtdeEscalaTesteCulto = @QtdeEscalaTesteCulto, " +
"QtdeHinoPreTesteOficial = @QtdeHinoPreTesteOficial, QtdeEscalaPreTesteOficial = @QtdeEscalaPreTesteOficial, " +
"QtdeHinoTesteOficial = @QtdeHinoTesteOficial, QtdeEscalaTesteOficial = @QtdeEscalaTesteOficial, " +
"RodapeRelatorio = @RodapeRelatorio, TestePermAltObsMet = @TestePermAltObsMet, TesteObsMet = @TesteObsMet, " +
"TestePermAltObsMts = @TestePermAltObsMts, TesteObsMts = @TesteObsMts, TestePermAltObsHino = @TestePermAltObsHino, " +
"TesteObsHino = @TesteObsHino, TestePermAltObsEsc = @TestePermAltObsEsc, TesteObsEsc = @TesteObsEsc, " +
"TestePermAltObsTeoria = @TestePermAltObsTeoria, TesteObsTeoria = @TesteObsTeoria " +
"WHERE CodParametro = @CodParametro ";

        //string de delete na tabela Parametros
        private string strDelete = "DELETE FROM Parametros WHERE CodParametro = @CodParametro ";

        //string de select na tabela Parametros
        private string strSelect = "SELECT P.CodParametro, P.CodRegional, P.Ativacao, P.InformaAtiva, " +
"P.DiasAtiva, P.Atualizacao, P.CpfZerado, P.TrocaSenha, P.DiasTrocaSenha, P.CopiaSegura, " +
"P.DiasCopiaSegura, P.QtdeViasPreTeste, P.QtdeViasTeste, P.AlteraDadosImportPessoa, " +
"P.ValidarDadosImportacao, P.TesteMetodo, P.TesteHino, P.AlteraSolicita, " +
"P.AlteraQtdeLicoesPreTeste, P.AlteraQtdeLicoesTeste, P.QtdeHinoPreTesteRjm, P.QtdeEscalaPreTesteRjm, P.QtdeHinoTesteRjm, P.QtdeEscalaTesteRjm, " +
"P.QtdeHinoPreTesteMeia, P.QtdeEscalaPreTesteMeia, P.QtdeHinoTesteMeia, P.QtdeEscalaTesteMeia, P.QtdeHinoPreTesteMeia, P.QtdeEscalaPreTesteMeia, " +
"P.QtdeHinoTesteMeia, P.QtdeEscalaTesteMeia, P.QtdeHinoPreTesteCulto, P.QtdeEscalaPreTesteCulto, P.QtdeHinoTesteCulto, P.QtdeEscalaTesteCulto, " +
"P.QtdeHinoPreTesteOficial, P.QtdeEscalaPreTesteOficial, P.QtdeHinoTesteOficial, P.QtdeEscalaTesteOficial, P.RodapeRelatorio, " +
"P.TestePermAltObsMet, P.TesteObsMet, P.TestePermAltObsMts, P.TesteObsMts, P.TestePermAltObsHino, P.TesteObsHino, " +
"P.TestePermAltObsEsc, P.TesteObsEsc, P.TestePermAltObsTeoria, P.TesteObsTeoria, " +
"R.Codigo AS CodigoRegional, R.Descricao AS DescricaoRegional, R.Estado AS EstadoRegional, R.CaminhoBD " +
"FROM Parametros AS P " +
"LEFT OUTER JOIN Regional AS R ON P.CodRegional = R.CodRegional ";

        //string que retorna o próximo Id da tabela Parametros
        private string strId = "SELECT MAX (CodParametro) FROM Parametros ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Parametros
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_parametros objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Parametros
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(objEnt.CodParametro)));
                objParam.Add(new SqlParameter("@CodRegional", string.IsNullOrEmpty(objEnt.CodRegional) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRegional) as object));
                objParam.Add(new SqlParameter("@Ativacao", string.IsNullOrEmpty(objEnt.Ativacao) ? DBNull.Value as object : objEnt.Ativacao as object));
                objParam.Add(new SqlParameter("@InformaAtiva", string.IsNullOrEmpty(objEnt.InformaAtiva) ? DBNull.Value as object : objEnt.InformaAtiva as object));
                objParam.Add(new SqlParameter("@DiasAtiva", string.IsNullOrEmpty(objEnt.DiasAtiva) ? DBNull.Value as object : Convert.ToInt32(objEnt.DiasAtiva) as object));
                objParam.Add(new SqlParameter("@Atualizacao", string.IsNullOrEmpty(objEnt.Atualizacao) ? DBNull.Value as object : objEnt.Atualizacao as object));
                objParam.Add(new SqlParameter("@CpfZerado", string.IsNullOrEmpty(objEnt.CpfZerado) ? DBNull.Value as object : objEnt.CpfZerado as object));
                objParam.Add(new SqlParameter("@TrocaSenha", string.IsNullOrEmpty(objEnt.TrocaSenha) ? DBNull.Value as object : objEnt.TrocaSenha as object));
                objParam.Add(new SqlParameter("@DiasTrocaSenha", string.IsNullOrEmpty(objEnt.DiasTrocaSenha) ? DBNull.Value as object : Convert.ToInt32(objEnt.DiasTrocaSenha) as object));
                objParam.Add(new SqlParameter("@CopiaSegura", string.IsNullOrEmpty(objEnt.CopiaSegura) ? DBNull.Value as object : objEnt.CopiaSegura as object));
                objParam.Add(new SqlParameter("@DiasCopiaSegura", string.IsNullOrEmpty(objEnt.DiasCopiaSegura) ? DBNull.Value as object : Convert.ToInt32(objEnt.DiasCopiaSegura) as object));
                objParam.Add(new SqlParameter("@QtdeViasPreTeste", string.IsNullOrEmpty(objEnt.QtdeViasPreTeste) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeViasPreTeste) as object));
                objParam.Add(new SqlParameter("@QtdeViasTeste", string.IsNullOrEmpty(objEnt.QtdeViasTeste) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeViasTeste) as object));
                objParam.Add(new SqlParameter("@AlteraDadosImportPessoa", string.IsNullOrEmpty(objEnt.AlteraDadosImportPessoa) ? DBNull.Value as object : objEnt.AlteraDadosImportPessoa as object));
                objParam.Add(new SqlParameter("@ValidarDadosImportacao", string.IsNullOrEmpty(objEnt.ValidarDadosImportacao) ? DBNull.Value as object : objEnt.ValidarDadosImportacao as object));
                objParam.Add(new SqlParameter("@TesteMetodo", string.IsNullOrEmpty(objEnt.TesteMetodo) ? DBNull.Value as object : objEnt.TesteMetodo as object));
                objParam.Add(new SqlParameter("@TesteHino", string.IsNullOrEmpty(objEnt.TesteHino) ? DBNull.Value as object : objEnt.TesteHino as object));
                objParam.Add(new SqlParameter("@AlteraSolicita", string.IsNullOrEmpty(objEnt.AlteraSolicita) ? DBNull.Value as object : objEnt.AlteraSolicita as object));
                objParam.Add(new SqlParameter("@AlteraQtdeLicoesPreTeste", string.IsNullOrEmpty(objEnt.AlteraQtdeLicoesPreTeste) ? DBNull.Value as object : objEnt.AlteraQtdeLicoesPreTeste as object));
                objParam.Add(new SqlParameter("@AlteraQtdeLicoesTeste", string.IsNullOrEmpty(objEnt.AlteraQtdeLicoesTeste) ? DBNull.Value as object : objEnt.AlteraQtdeLicoesTeste as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteRjm", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteRjm", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteRjm", string.IsNullOrEmpty(objEnt.QtdeHinoTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteRjm", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteMeia", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteMeia", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteMeia", string.IsNullOrEmpty(objEnt.QtdeHinoTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteMeia", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteCulto", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteCulto", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteCulto", string.IsNullOrEmpty(objEnt.QtdeHinoTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteCulto", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteOficial", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteOficial) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteOficial", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteOficial) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteOficial", string.IsNullOrEmpty(objEnt.QtdeHinoTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteOficial) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteOficial", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteOficial) as object));
                objParam.Add(new SqlParameter("@RodapeRelatorio", string.IsNullOrEmpty(objEnt.RodapeRelatorio) ? DBNull.Value as object : objEnt.RodapeRelatorio as object));
                objParam.Add(new SqlParameter("@TestePermAltObsMet", string.IsNullOrEmpty(objEnt.TestePermAltObsMet) ? DBNull.Value as object : objEnt.TestePermAltObsMet as object));
                objParam.Add(new SqlParameter("@TesteObsMet", string.IsNullOrEmpty(objEnt.TesteObsMet) ? DBNull.Value as object : objEnt.TesteObsMet as object));
                objParam.Add(new SqlParameter("@TestePermAltObsMts", string.IsNullOrEmpty(objEnt.TestePermAltObsMts) ? DBNull.Value as object : objEnt.TestePermAltObsMts as object));
                objParam.Add(new SqlParameter("@TesteObsMts", string.IsNullOrEmpty(objEnt.TesteObsMts) ? DBNull.Value as object : objEnt.TesteObsMts as object));
                objParam.Add(new SqlParameter("@TestePermAltObsHino", string.IsNullOrEmpty(objEnt.TestePermAltObsHino) ? DBNull.Value as object : objEnt.TestePermAltObsHino as object));
                objParam.Add(new SqlParameter("@RodapeRelatorio", string.IsNullOrEmpty(objEnt.TesteObsHino) ? DBNull.Value as object : objEnt.TesteObsHino as object));
                objParam.Add(new SqlParameter("@TestePermAltObsEsc", string.IsNullOrEmpty(objEnt.TestePermAltObsEsc) ? DBNull.Value as object : objEnt.TestePermAltObsEsc as object));
                objParam.Add(new SqlParameter("@TesteObsEsc", string.IsNullOrEmpty(objEnt.TesteObsEsc) ? DBNull.Value as object : objEnt.TesteObsEsc as object));
                objParam.Add(new SqlParameter("@TestePermAltObsTeoria", string.IsNullOrEmpty(objEnt.TestePermAltObsTeoria) ? DBNull.Value as object : objEnt.TestePermAltObsTeoria as object));
                objParam.Add(new SqlParameter("@TesteObsTeoria", string.IsNullOrEmpty(objEnt.TesteObsTeoria) ? DBNull.Value as object : objEnt.TesteObsTeoria as object));

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
        /// Função que faz INSERT na Tabela Parametros
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_parametros objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Parametros
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(objEnt.CodParametro)));
                objParam.Add(new SqlParameter("@CodRegional", string.IsNullOrEmpty(objEnt.CodRegional) ? DBNull.Value as object : Convert.ToInt32(objEnt.CodRegional) as object));
                objParam.Add(new SqlParameter("@Ativacao", string.IsNullOrEmpty(objEnt.Ativacao) ? DBNull.Value as object : objEnt.Ativacao as object));
                objParam.Add(new SqlParameter("@InformaAtiva", string.IsNullOrEmpty(objEnt.InformaAtiva) ? DBNull.Value as object : objEnt.InformaAtiva as object));
                objParam.Add(new SqlParameter("@DiasAtiva", string.IsNullOrEmpty(objEnt.DiasAtiva) ? DBNull.Value as object : Convert.ToInt32(objEnt.DiasAtiva) as object));
                objParam.Add(new SqlParameter("@Atualizacao", string.IsNullOrEmpty(objEnt.Atualizacao) ? DBNull.Value as object : objEnt.Atualizacao as object));
                objParam.Add(new SqlParameter("@CpfZerado", string.IsNullOrEmpty(objEnt.CpfZerado) ? DBNull.Value as object : objEnt.CpfZerado as object));
                objParam.Add(new SqlParameter("@TrocaSenha", string.IsNullOrEmpty(objEnt.TrocaSenha) ? DBNull.Value as object : objEnt.TrocaSenha as object));
                objParam.Add(new SqlParameter("@DiasTrocaSenha", string.IsNullOrEmpty(objEnt.DiasTrocaSenha) ? DBNull.Value as object : Convert.ToInt32(objEnt.DiasTrocaSenha) as object));
                objParam.Add(new SqlParameter("@CopiaSegura", string.IsNullOrEmpty(objEnt.CopiaSegura) ? DBNull.Value as object : objEnt.CopiaSegura as object));
                objParam.Add(new SqlParameter("@DiasCopiaSegura", string.IsNullOrEmpty(objEnt.DiasCopiaSegura) ? DBNull.Value as object : Convert.ToInt32(objEnt.DiasCopiaSegura) as object));
                objParam.Add(new SqlParameter("@QtdeViasPreTeste", string.IsNullOrEmpty(objEnt.QtdeViasPreTeste) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeViasPreTeste) as object));
                objParam.Add(new SqlParameter("@QtdeViasTeste", string.IsNullOrEmpty(objEnt.QtdeViasTeste) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeViasTeste) as object));
                objParam.Add(new SqlParameter("@AlteraDadosImportPessoa", string.IsNullOrEmpty(objEnt.AlteraDadosImportPessoa) ? DBNull.Value as object : objEnt.AlteraDadosImportPessoa as object));
                objParam.Add(new SqlParameter("@ValidarDadosImportacao", string.IsNullOrEmpty(objEnt.ValidarDadosImportacao) ? DBNull.Value as object : objEnt.ValidarDadosImportacao as object));
                objParam.Add(new SqlParameter("@TesteMetodo", string.IsNullOrEmpty(objEnt.TesteMetodo) ? DBNull.Value as object : objEnt.TesteMetodo as object));
                objParam.Add(new SqlParameter("@TesteHino", string.IsNullOrEmpty(objEnt.TesteHino) ? DBNull.Value as object : objEnt.TesteHino as object));
                objParam.Add(new SqlParameter("@AlteraSolicita", string.IsNullOrEmpty(objEnt.AlteraSolicita) ? DBNull.Value as object : objEnt.AlteraSolicita as object));
                objParam.Add(new SqlParameter("@AlteraQtdeLicoesPreTeste", string.IsNullOrEmpty(objEnt.AlteraQtdeLicoesPreTeste) ? DBNull.Value as object : objEnt.AlteraQtdeLicoesPreTeste as object));
                objParam.Add(new SqlParameter("@AlteraQtdeLicoesTeste", string.IsNullOrEmpty(objEnt.AlteraQtdeLicoesTeste) ? DBNull.Value as object : objEnt.AlteraQtdeLicoesTeste as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteRjm", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteRjm", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteRjm", string.IsNullOrEmpty(objEnt.QtdeHinoTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteRjm", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteRjm) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteRjm) as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteMeia", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteMeia", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteMeia", string.IsNullOrEmpty(objEnt.QtdeHinoTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteMeia", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteMeia) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteMeia) as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteCulto", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteCulto", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteCulto", string.IsNullOrEmpty(objEnt.QtdeHinoTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteCulto", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteCulto) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteCulto) as object));
                objParam.Add(new SqlParameter("@QtdeHinoPreTesteOficial", string.IsNullOrEmpty(objEnt.QtdeHinoPreTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoPreTesteOficial) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaPreTesteOficial", string.IsNullOrEmpty(objEnt.QtdeEscalaPreTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaPreTesteOficial) as object));
                objParam.Add(new SqlParameter("@QtdeHinoTesteOficial", string.IsNullOrEmpty(objEnt.QtdeHinoTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeHinoTesteOficial) as object));
                objParam.Add(new SqlParameter("@QtdeEscalaTesteOficial", string.IsNullOrEmpty(objEnt.QtdeEscalaTesteOficial) ? DBNull.Value as object : Convert.ToInt16(objEnt.QtdeEscalaTesteOficial) as object));
                objParam.Add(new SqlParameter("@RodapeRelatorio", string.IsNullOrEmpty(objEnt.RodapeRelatorio) ? DBNull.Value as object : objEnt.RodapeRelatorio as object));
                objParam.Add(new SqlParameter("@TestePermAltObsMet", string.IsNullOrEmpty(objEnt.TestePermAltObsMet) ? DBNull.Value as object : objEnt.TestePermAltObsMet as object));
                objParam.Add(new SqlParameter("@TesteObsMet", string.IsNullOrEmpty(objEnt.TesteObsMet) ? DBNull.Value as object : objEnt.TesteObsMet as object));
                objParam.Add(new SqlParameter("@TestePermAltObsMts", string.IsNullOrEmpty(objEnt.TestePermAltObsMts) ? DBNull.Value as object : objEnt.TestePermAltObsMts as object));
                objParam.Add(new SqlParameter("@TesteObsMts", string.IsNullOrEmpty(objEnt.TesteObsMts) ? DBNull.Value as object : objEnt.TesteObsMts as object));
                objParam.Add(new SqlParameter("@TestePermAltObsHino", string.IsNullOrEmpty(objEnt.TestePermAltObsHino) ? DBNull.Value as object : objEnt.TestePermAltObsHino as object));
                objParam.Add(new SqlParameter("@RodapeRelatorio", string.IsNullOrEmpty(objEnt.TesteObsHino) ? DBNull.Value as object : objEnt.TesteObsHino as object));
                objParam.Add(new SqlParameter("@TestePermAltObsEsc", string.IsNullOrEmpty(objEnt.TestePermAltObsEsc) ? DBNull.Value as object : objEnt.TestePermAltObsEsc as object));
                objParam.Add(new SqlParameter("@TesteObsEsc", string.IsNullOrEmpty(objEnt.TesteObsEsc) ? DBNull.Value as object : objEnt.TesteObsEsc as object));
                objParam.Add(new SqlParameter("@TestePermAltObsTeoria", string.IsNullOrEmpty(objEnt.TestePermAltObsTeoria) ? DBNull.Value as object : objEnt.TestePermAltObsTeoria as object));
                objParam.Add(new SqlParameter("@TesteObsTeoria", string.IsNullOrEmpty(objEnt.TesteObsTeoria) ? DBNull.Value as object : objEnt.TesteObsTeoria as object));

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
        /// Função que faz DELETE na Tabela Parametros
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_parametros objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Parametros
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodParametro", Convert.ToInt16(objEnt.CodParametro)));
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
        /// Função que retorna os Registros da tabela Parametros, pesquisado pelo Código
        /// </summary>
        /// <param name="CodParametro"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodParametro)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodParametro))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodParametro", CodParametro));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY P.CodParametro ", objParam, "Parametros");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodParametro", CodParametro));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodParametro = @CodParametro ORDER BY P.CodParametro", objParam, "Parametros");
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
        /// Função que retorna os Registros da tabela Parametros, pesquisado pelo CodRegional
        /// </summary>
        /// <param name="CodRegional"></param>
        /// <returns></returns>
        public DataTable buscarRegional(string CodRegional)
        {
            try
            {
                if (string.IsNullOrEmpty(CodRegional))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRegional", CodRegional));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY R.Estado, R.Descricao ", objParam, "Parametros");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodRegional", CodRegional));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE P.CodRegional = @CodRegional ORDER BY P.CodRegional ", objParam, "Parametros");
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

        #endregion

        #region Funções Publicas e Privadas Usadas para retorno de Valores

        /// <summary>
        /// Função que retorna o Ultimo Código inserido na Tabela
        /// </summary>
        /// <returns></returns>
        public Int16 retornaId()
        {
            try
            {
                idParametro = objAcessa.retornarId(strId);
                return Convert.ToInt16(idParametro);
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
