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

namespace DAL.cargo
{
    public class DAL_cargo : IDAL_Cargo
    {

        IConnect objAcessa = new acessa();
        IDAL_Cargo_StrSql objDAL = new DAL_cargo_StrSql();

        #region Instruções CRUD

        /// <summary>
        /// Função UPDATE - Utilziada para Atualizar os dados na Base
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public bool Update(MOD_cargo cargo)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cargo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodCargo", string.IsNullOrEmpty(cargo.CodCargo) ? DBNull.Value as object : Convert.ToInt16(cargo.CodCargo) as object),
                    new SqlParameter("@DescCargo", string.IsNullOrEmpty(cargo.DescCargo) ? DBNull.Value as object : cargo.DescCargo as object),
                    new SqlParameter("@SiglaCargo", string.IsNullOrEmpty(cargo.SiglaCargo) ? DBNull.Value as object : cargo.SiglaCargo as object),
                    new SqlParameter("@Ordem", string.IsNullOrEmpty(cargo.Ordem) ? DBNull.Value as object : cargo.Ordem as object),
                    new SqlParameter("@CodDepartamento", string.IsNullOrEmpty(cargo.CodDepartamento) ? DBNull.Value as object : Convert.ToInt16(cargo.CodDepartamento) as object),
                    new SqlParameter("@PermiteEdicao", true.Equals(cargo.PermiteEdicao) ? "Sim" as object : "Não" as object),
                    new SqlParameter("@AtendeComum", true.Equals(cargo.AtendeComum) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeRegiao", true.Equals(cargo.AtendeRegiao) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeGEM", true.Equals(cargo.AtendeGEM) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeEnsaioLocal", true.Equals(cargo.AtendeEnsaioLocal) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeEnsaioRegional", true.Equals(cargo.AtendeEnsaioRegional) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeEnsaioParcial", true.Equals(cargo.AtendeEnsaioParcial) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeEnsaioTecnico", true.Equals(cargo.AtendeEnsaioTecnico) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeReuniaoMocidade", true.Equals(cargo.AtendeReuniaoMocidade) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeBatismo", true.Equals(cargo.AtendeBatismo) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeSantaCeia", true.Equals(cargo.AtendeSantaCeia) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeRJM", true.Equals(cargo.AtendeRJM) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendePreTesteRjmMusico", true.Equals(cargo.AtendePreTesteRjmMusico) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendePreTesteRjmOrganista", true.Equals(cargo.AtendePreTesteRjmOrganista) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeTesteRjmMusico", true.Equals(cargo.AtendeTesteRjmMusico) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeTesteRjmOrganista", true.Equals(cargo.AtendeTesteRjmOrganista) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendePreTesteCultoMusico", true.Equals(cargo.AtendePreTesteCultoMusico) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendePreTesteCultoOrganista", true.Equals(cargo.AtendePreTesteCultoOrganista) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeTesteCultoMusico", true.Equals(cargo.AtendeTesteCultoMusico) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeTesteCultoOrganista", true.Equals(cargo.AtendeTesteCultoOrganista) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendePreTesteOficialMusico", true.Equals(cargo.AtendePreTesteOficialMusico) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendePreTesteOficialOrganista", true.Equals(cargo.AtendePreTesteOficialOrganista) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeTesteOficialMusico", true.Equals(cargo.AtendeTesteOficialMusico) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeTesteOficialOrganista", true.Equals(cargo.AtendeTesteOficialOrganista) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeReuniaoMinisterial", true.Equals(cargo.AtendeReuniaoMinisterial) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeCasal", true.Equals(cargo.AtendeCasal) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AtendeOrdenacao", true.Equals(cargo.AtendeOrdenacao) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@Masculino", true.Equals(cargo.Masculino) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@Feminino", true.Equals(cargo.Feminino) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@PermiteInstrumento", true.Equals(cargo.PermiteInstrumento) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@AlunoGem", true.Equals(cargo.AlunoGem) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@Ensaio", true.Equals(cargo.Ensaio) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@MeiaHora", true.Equals(cargo.MeiaHora) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@Rjm", true.Equals(cargo.Rjm) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@Culto", true.Equals(cargo.Culto) ? "Sim" as object : "Não"  as object),
                    new SqlParameter("@Oficial", true.Equals(cargo.Oficial) ? "Sim" as object : "Não"  as object)
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
        /// Função INSERT - Utilziada para Inserir os dados na Base
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public bool Insert(MOD_cargo cargo)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cargo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodCargo", Convert.ToInt16(cargo.CodCargo)),
                    new SqlParameter("@DescCargo", string.IsNullOrEmpty(cargo.DescCargo) ? DBNull.Value as object : cargo.DescCargo as object),
                    new SqlParameter("@SiglaCargo", string.IsNullOrEmpty(cargo.SiglaCargo) ? DBNull.Value as object : cargo.SiglaCargo as object),
                    new SqlParameter("@Ordem", string.IsNullOrEmpty(cargo.Ordem) ? DBNull.Value as object : cargo.Ordem as object),
                    new SqlParameter("@CodDepartamento", string.IsNullOrEmpty(cargo.CodDepartamento) ? DBNull.Value as object : Convert.ToInt16(cargo.CodDepartamento) as object),
                    new SqlParameter("@PermiteEdicao", cargo.PermiteEdicao as object),
                    new SqlParameter("@AtendeComum", cargo.AtendeComum as object),
                    new SqlParameter("@AtendeRegiao", cargo.AtendeRegiao as object),
                    new SqlParameter("@AtendeGEM", cargo.AtendeGEM as object),
                    new SqlParameter("@AtendeEnsaioLocal", cargo.AtendeEnsaioLocal as object),
                    new SqlParameter("@AtendeEnsaioRegional", cargo.AtendeEnsaioRegional as object),
                    new SqlParameter("@AtendeEnsaioParcial", cargo.AtendeEnsaioParcial as object),
                    new SqlParameter("@AtendeEnsaioTecnico", cargo.AtendeEnsaioTecnico as object),
                    new SqlParameter("@AtendeReuniaoMocidade", cargo.AtendeReuniaoMocidade as object),
                    new SqlParameter("@AtendeBatismo", cargo.AtendeBatismo as object),
                    new SqlParameter("@AtendeSantaCeia", cargo.AtendeSantaCeia as object),
                    new SqlParameter("@AtendeRJM", cargo.AtendeRJM as object),
                    new SqlParameter("@AtendePreTesteRjmMusico", cargo.AtendePreTesteRjmMusico as object),
                    new SqlParameter("@AtendePreTesteRjmOrganista", cargo.AtendePreTesteRjmOrganista as object),
                    new SqlParameter("@AtendeTesteRjmMusico", cargo.AtendeTesteRjmMusico as object),
                    new SqlParameter("@AtendeTesteRjmOrganista", cargo.AtendeTesteRjmOrganista as object),
                    new SqlParameter("@AtendePreTesteCultoMusico", cargo.AtendePreTesteCultoMusico as object),
                    new SqlParameter("@AtendePreTesteCultoOrganista", cargo.AtendePreTesteCultoOrganista as object),
                    new SqlParameter("@AtendeTesteCultoMusico", cargo.AtendeTesteCultoMusico as object),
                    new SqlParameter("@AtendeTesteCultoOrganista", cargo.AtendeTesteCultoOrganista as object),
                    new SqlParameter("@AtendePreTesteOficialMusico", cargo.AtendePreTesteOficialMusico as object),
                    new SqlParameter("@AtendePreTesteOficialOrganista", cargo.AtendePreTesteOficialOrganista as object),
                    new SqlParameter("@AtendeTesteOficialMusico", cargo.AtendeTesteOficialMusico as object),
                    new SqlParameter("@AtendeTesteOficialOrganista", cargo.AtendeTesteOficialOrganista as object),
                    new SqlParameter("@AtendeReuniaoMinisterial", cargo.AtendeReuniaoMinisterial as object),
                    new SqlParameter("@AtendeCasal", cargo.AtendeCasal as object),
                    new SqlParameter("@AtendeOrdenacao", cargo.AtendeOrdenacao as object),
                    new SqlParameter("@Masculino", cargo.Masculino as object),
                    new SqlParameter("@Feminino", cargo.Feminino as object),
                    new SqlParameter("@PermiteInstrumento", cargo.PermiteInstrumento as object),
                    new SqlParameter("@AlunoGem", cargo.AlunoGem as object),
                    new SqlParameter("@Ensaio", cargo.Ensaio as object),
                    new SqlParameter("@MeiaHora", cargo.MeiaHora as object),
                    new SqlParameter("@Rjm", cargo.Rjm as object),
                    new SqlParameter("@Culto", cargo.Culto as object),
                    new SqlParameter("@Oficial", cargo.Oficial as object)
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
        /// Função DELETE - Utilziada para Excluir os dados na Base
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public bool Delete(MOD_cargo cargo)
        {
            try
            {
                //Varivel boleana que retorna se foi executado ou não no Banco
                //Tabela Cargo
                bool blnRetorno = true;
                //Declara a lista de parametros da tabela
                List<SqlParameter> objParam = new List<SqlParameter>
                { 
                    //parametros da tabela principal
                    new SqlParameter("@CodCargo", Convert.ToInt16(cargo.CodCargo))
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
        public Int16 RetornaId()
        {
            try
            {
                object idCargo = objAcessa.retornarId(objDAL.StrRetornaId);
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
