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
    public class DAL_cargo
    {

        #region declarações

        //classe que faz as movimentações no banco de dados
        acessa objAcessa = new acessa();
        //dataTable para preencher a lista
        DataTable objDtb = null;
        //variavel que retorna o próximo id da tabela
        object idCargo = null;

        #endregion

        #region Strings Sql da tabela Cargo

        //string de insert na tabela Cargo
        private string strInsert = "INSERT INTO Cargo (CodCargo, DescCargo, Ordem, SiglaCargo, CodDepartamento, PermiteEdicao, AtendeComum, AtendeRegiao, " +
"AtendeGEM, AtendeEnsaioLocal, AtendeEnsaioRegional, AtendeEnsaioParcial, AtendeEnsaioTecnico, AtendeReuniaoMocidade, " +
"AtendeBatismo, AtendeSantaCeia, AtendeRJM, AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista, AtendeTesteRjmMusico, AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista, AtendeTesteCultoMusico, AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista, AtendeTesteOficialMusico, AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial, AtendeCasal, AtendeOrdenacao, Masculino, Feminino, PermiteInstrumento, AlunoGem, Ensaio, MeiaHora, Rjm, Culto, Oficial) " +
"VALUES (@CodCargo, @DescCargo, @Ordem, @SiglaCargo, @CodDepartamento, @AtendeComum, @AtendeRegiao, " +
"@AtendeGEM, @AtendeEnsaioLocal, @AtendeEnsaioRegional, @AtendeEnsaioParcial, @AtendeEnsaioTecnico, @AtendeReuniaoMocidade, " +
"@AtendeBatismo, @AtendeSantaCeia, @AtendeRJM, @AtendePreTesteRjmMusico, @AtendePreTesteRjmOrganista, @AtendeTesteRjmMusico, @AtendeTesteRjmOrganista, " +
"@AtendePreTesteCultoMusico, @AtendePreTesteCultoOrganista, @AtendeTesteCultoMusico, @AtendeTesteCultoOrganista, " +
"@AtendePreTesteOficialMusico, @AtendePreTesteOficialOrganista, @AtendeTesteOficialMusico, @AtendeTesteOficialOrganista," +
"@AtendeReuniaoMinisterial, @AtendeCasal, @AtendeOrdenacao, @Masculino, @Feminino, @PermiteInstrumento, @AlunoGem, @Ensaio, @MeiaHora, @Rjm, @Culto, @Oficial) ";

        //string de update na tabela Cargo
        private string strUpdate = "UPDATE Cargo SET DescCargo = @DescCargo, Ordem = @Ordem, SiglaCargo = @SiglaCargo, " +
"CodDepartamento = @CodDepartamento, PermiteEdicao = @PermiteEdicao, AtendeComum = @AtendeComum, AtendeRegiao = @AtendeRegiao, " +
"AtendeGEM = @AtendeGEM, AtendeEnsaioLocal = @AtendeEnsaioLocal, AtendeEnsaioRegional = @AtendeEnsaioRegional, " +
"AtendeEnsaioParcial = @AtendeEnsaioParcial, AtendeEnsaioTecnico = @AtendeEnsaioTecnico, AtendeReuniaoMocidade = @AtendeReuniaoMocidade, " +
"AtendeBatismo = @AtendeBatismo, AtendeSantaCeia = @AtendeSantaCeia, AtendeRJM = @AtendeRJM, " +
"AtendePreTesteRjmMusico = @AtendePreTesteRjmMusico, AtendePreTesteRjmOrganista = @AtendePreTesteRjmOrganista, " +
"AtendeTesteRjmMusico = @AtendeTesteRjmMusico, AtendeTesteRjmOrganista = @AtendeTesteRjmOrganista, " +
"AtendePreTesteCultoMusico = @AtendePreTesteCultoMusico, AtendePreTesteCultoOrganista = @AtendePreTesteCultoOrganista, " +
"AtendeTesteCultoMusico = @AtendeTesteCultoMusico, AtendeTesteCultoOrganista = @AtendeTesteCultoOrganista, " +
"AtendePreTesteOficialMusico = @AtendePreTesteOficialMusico, AtendePreTesteOficialOrganista = @AtendePreTesteOficialOrganista, " +
"AtendeTesteOficialMusico = @AtendeTesteOficialMusico, AtendeTesteOficialOrganista = @AtendeTesteOficialOrganista," +
"AtendeReuniaoMinisterial = @AtendeReuniaoMinisterial, AtendeCasal = @AtendeCasal, AtendeOrdenacao = @AtendeOrdenacao, " +
"Masculino = @Masculino, Feminino = @Feminino, PermiteInstrumento = @PermiteInstrumento, AlunoGem = @AlunoGem, Ensaio = @Ensaio, " +
"MeiaHora = @MeiaHora, Rjm = @Rjm, Culto = @Culto, Oficial = @Oficial " +
"WHERE CodCargo = @CodCargo ";

        //string de delete na tabela Cargo
        private string strDelete = "DELETE FROM Cargo WHERE CodCargo = @CodCargo ";

        //string de select na tabela Cargo
        private string strSelect = "SELECT C.CodCargo, C.DescCargo, C.SiglaCargo, C.Ordem, C.CodDepartamento, C.PermiteEdicao, C.AtendeComum, C.AtendeRegiao, " +
"C.AtendeGEM, C.AtendeEnsaioLocal, C.AtendeEnsaioRegional, C.AtendeEnsaioParcial, C.AtendeEnsaioTecnico, C.AtendeReuniaoMocidade, " +
"C.AtendeBatismo, C.AtendeSantaCeia, C.AtendeRJM, C.AtendePreTesteRjmMusico, C.AtendePreTesteRjmOrganista, C.AtendeTesteRjmMusico, C.AtendeTesteRjmOrganista, " +
"C.AtendePreTesteCultoMusico, C.AtendePreTesteCultoOrganista, C.AtendeTesteCultoMusico, C.AtendeTesteCultoOrganista, " +
"C.AtendePreTesteOficialMusico, C.AtendePreTesteOficialOrganista, C.AtendeTesteOficialMusico, C.AtendeTesteOficialOrganista," +
"C.AtendeReuniaoMinisterial, C.AtendeCasal, C.AtendeOrdenacao, C.Masculino, C.Feminino, C.PermiteInstrumento, " +
"AlunoGem, Ensaio, MeiaHora, Rjm, Culto, Oficial, " +
"D.DescDepartamento " +
"FROM Cargo AS C " +
"LEFT OUTER JOIN Departamento AS D ON C.CodDepartamento = D.CodDepartamento ";

        //string que retorna o próximo Id da tabela Cargo
        private string strId = "SELECT MAX (CodCargo) FROM Cargo ";

        #endregion

        #region Função para Atualizar e Inserir os dados na Base

        /// <summary>
        /// Função que faz UPDATE na Tabela Cargo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool salvar(MOD_cargo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cargo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCargo", Convert.ToInt16(objEnt.CodCargo)));
                objParam.Add(new SqlParameter("@DescCargo", string.IsNullOrEmpty(objEnt.DescCargo) ? DBNull.Value as object : objEnt.DescCargo as object));
                objParam.Add(new SqlParameter("@SiglaCargo", string.IsNullOrEmpty(objEnt.SiglaCargo) ? DBNull.Value as object : objEnt.SiglaCargo as object));
                objParam.Add(new SqlParameter("@Ordem", string.IsNullOrEmpty(objEnt.Ordem) ? DBNull.Value as object : objEnt.Ordem as object));
                objParam.Add(new SqlParameter("@CodDepartamento", string.IsNullOrEmpty(objEnt.CodDepartamento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodDepartamento) as object));
                objParam.Add(new SqlParameter("@PermiteEdicao", string.IsNullOrEmpty(objEnt.PermiteEdicao) ? DBNull.Value as object : objEnt.PermiteEdicao as object));
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
                objParam.Add(new SqlParameter("@Masculino", string.IsNullOrEmpty(objEnt.Masculino) ? DBNull.Value as object : objEnt.Masculino as object));
                objParam.Add(new SqlParameter("@Feminino", string.IsNullOrEmpty(objEnt.Feminino) ? DBNull.Value as object : objEnt.Feminino as object));
                objParam.Add(new SqlParameter("@PermiteInstrumento", string.IsNullOrEmpty(objEnt.PermiteInstrumento) ? DBNull.Value as object : objEnt.PermiteInstrumento as object));
                objParam.Add(new SqlParameter("@AlunoGem", string.IsNullOrEmpty(objEnt.AlunoGem) ? DBNull.Value as object : objEnt.AlunoGem as object));
                objParam.Add(new SqlParameter("@Ensaio", string.IsNullOrEmpty(objEnt.Ensaio) ? DBNull.Value as object : objEnt.Ensaio as object));
                objParam.Add(new SqlParameter("@MeiaHora", string.IsNullOrEmpty(objEnt.MeiaHora) ? DBNull.Value as object : objEnt.MeiaHora as object));
                objParam.Add(new SqlParameter("@Rjm", string.IsNullOrEmpty(objEnt.Rjm) ? DBNull.Value as object : objEnt.Rjm as object));
                objParam.Add(new SqlParameter("@Culto", string.IsNullOrEmpty(objEnt.Culto) ? DBNull.Value as object : objEnt.Culto as object));
                objParam.Add(new SqlParameter("@Oficial", string.IsNullOrEmpty(objEnt.Oficial) ? DBNull.Value as object : objEnt.Oficial as object));

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
        /// Função que faz INSERT na Tabela Cargo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool inserir(MOD_cargo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cargo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCargo", Convert.ToInt16(objEnt.CodCargo)));
                objParam.Add(new SqlParameter("@DescCargo", string.IsNullOrEmpty(objEnt.DescCargo) ? DBNull.Value as object : objEnt.DescCargo as object));
                objParam.Add(new SqlParameter("@SiglaCargo", string.IsNullOrEmpty(objEnt.SiglaCargo) ? DBNull.Value as object : objEnt.SiglaCargo as object));
                objParam.Add(new SqlParameter("@Ordem", string.IsNullOrEmpty(objEnt.Ordem) ? DBNull.Value as object : objEnt.Ordem as object));
                objParam.Add(new SqlParameter("@CodDepartamento", string.IsNullOrEmpty(objEnt.CodDepartamento) ? DBNull.Value as object : Convert.ToInt16(objEnt.CodDepartamento) as object));
                objParam.Add(new SqlParameter("@PermiteEdicao", string.IsNullOrEmpty(objEnt.PermiteEdicao) ? DBNull.Value as object : objEnt.PermiteEdicao as object));
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
                objParam.Add(new SqlParameter("@Masculino", string.IsNullOrEmpty(objEnt.Masculino) ? DBNull.Value as object : objEnt.Masculino as object));
                objParam.Add(new SqlParameter("@Feminino", string.IsNullOrEmpty(objEnt.Feminino) ? DBNull.Value as object : objEnt.Feminino as object));
                objParam.Add(new SqlParameter("@PermiteInstrumento", string.IsNullOrEmpty(objEnt.PermiteInstrumento) ? DBNull.Value as object : objEnt.PermiteInstrumento as object));
                objParam.Add(new SqlParameter("@AlunoGem", string.IsNullOrEmpty(objEnt.AlunoGem) ? DBNull.Value as object : objEnt.AlunoGem as object));
                objParam.Add(new SqlParameter("@Ensaio", string.IsNullOrEmpty(objEnt.Ensaio) ? DBNull.Value as object : objEnt.Ensaio as object));
                objParam.Add(new SqlParameter("@MeiaHora", string.IsNullOrEmpty(objEnt.MeiaHora) ? DBNull.Value as object : objEnt.MeiaHora as object));
                objParam.Add(new SqlParameter("@Rjm", string.IsNullOrEmpty(objEnt.Rjm) ? DBNull.Value as object : objEnt.Rjm as object));
                objParam.Add(new SqlParameter("@Culto", string.IsNullOrEmpty(objEnt.Culto) ? DBNull.Value as object : objEnt.Culto as object));
                objParam.Add(new SqlParameter("@Oficial", string.IsNullOrEmpty(objEnt.Oficial) ? DBNull.Value as object : objEnt.Oficial as object));

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
        /// Função que faz DELETE na Tabela Cargo
        /// </summary>
        /// <param name="objEnt"></param>
        /// <returns></returns>
        public bool excluir(MOD_cargo objEnt)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cargo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>();
                //parametros da tabela principal
                objParam.Add(new SqlParameter("@CodCargo", Convert.ToInt16(objEnt.CodCargo)));
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
        /// Função que retorna os Registros da tabela Cargo, pesquisado pelo Código
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <returns></returns>
        public DataTable buscarCod(string CodCargo)
        {
            try
            {
                //Verifica se foi informado valor, caso não tenha sido,
                //vai ser retornado todos os registros da tabela
                if (string.IsNullOrEmpty(CodCargo))
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                    objDtb = objAcessa.retornaDados(strSelect + "ORDER BY C.CodCargo ", objParam, "Cargo");
                    return objDtb;
                }
                else
                {
                    //declara a lista de parametros da tabela principal
                    List<SqlParameter> objParam = new List<SqlParameter>();
                    objParam.Add(new SqlParameter("@CodCargo", CodCargo));
                    objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodCargo = @CodCargo ORDER BY C.CodCargo", objParam, "Cargo");
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
        /// Função que retorna os Registros da tabela Cargo, pesquisado pela Descricao
        /// </summary>
        /// <param name="DescCargo"></param>
        /// <returns></returns>
        public DataTable buscarDescricao(string DescCargo)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@DescCargo", DescCargo));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.DescCargo LIKE @DescCargo ORDER BY C.DescCargo ", objParam, "Cargo");
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
        /// Função que retorna os Registros da tabela Cargo, pesquisado pelo Departamento
        /// </summary>
        /// <param name="CodDepartamento"></param>
        /// <returns></returns>
        public DataTable buscarDepartamento(string CodDepartamento)
        {
            try
            {
                //declara a lista de parametros da tabela principal
                List<SqlParameter> objParam = new List<SqlParameter>();
                objParam.Add(new SqlParameter("@CodDepartamento", CodDepartamento));
                objDtb = objAcessa.retornaDados(strSelect + "WHERE C.CodDepartamento LIKE @CodDepartamento ORDER BY C.DescCargo ", objParam, "Cargo");
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
        public Int16 retornaId()
        {
            try
            {
                idCargo = objAcessa.retornarId(strId);
                return Convert.ToInt16(idCargo);
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
