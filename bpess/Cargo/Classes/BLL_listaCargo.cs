using BLL.Funcoes;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.cargo
{
    public class BLL_listaCargo
    {
        
        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_cargo> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_cargo> lista = new List<MOD_cargo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a entidade
                    MOD_cargo ent = new MOD_cargo
                    {
                        //adiciona os campos às propriedades
                        CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0')),
                        DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]),
                        SiglaCargo = (string)(row.IsNull("SiglaCargo") ? null : row["SiglaCargo"]),
                        Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(2, '0')),
                        CodDepartamento = (string)(row.IsNull("CodDepartamento") ? Convert.ToString(null) : Convert.ToString(row["CodDepartamento"]).PadLeft(3, '0')),
                        DescDepartamento = (string)(row.IsNull("DescDepartamento") ? null : row["DescDepartamento"]),
                        PermiteEdicao = ("Sim".Equals(row["PermiteEdicao"])) ? true : false,
                        AtendeComum = ("Sim".Equals(row["AtendeComum"])) ? true : false,
                        AtendeRegiao = ("Sim".Equals(row["AtendeRegiao"])) ? true : false,
                        AtendeGEM = ("Sim".Equals(row["AtendeGEM"])) ? true : false,
                        AtendeEnsaioLocal = ("Sim".Equals(row["AtendeEnsaioLocal"])) ? true : false,
                        AtendeEnsaioRegional = ("Sim".Equals(row["AtendeEnsaioRegional"])) ? true : false,
                        AtendeEnsaioParcial = ("Sim".Equals(row["AtendeEnsaioParcial"])) ? true : false,
                        AtendeEnsaioTecnico = ("Sim".Equals(row["AtendeEnsaioTecnico"])) ? true : false,
                        AtendeReuniaoMocidade = ("Sim".Equals(row["AtendeReuniaoMocidade"])) ? true : false,
                        AtendeBatismo = ("Sim".Equals(row["AtendeBatismo"])) ? true : false,
                        AtendeSantaCeia = ("Sim".Equals(row["AtendeSantaCeia"])) ? true : false,
                        AtendeRJM = ("Sim".Equals(row["AtendeRJM"])) ? true : false,
                        AtendePreTesteRjmMusico = ("Sim".Equals(row["AtendePreTesteRjmMusico"])) ? true : false,
                        AtendePreTesteRjmOrganista = ("Sim".Equals(row["AtendePreTesteRjmOrganista"])) ? true : false,
                        AtendeTesteRjmMusico = ("Sim".Equals(row["AtendeTesteRjmMusico"])) ? true : false,
                        AtendeTesteRjmOrganista = ("Sim".Equals(row["AtendeTesteRjmOrganista"])) ? true : false,
                        AtendePreTesteCultoMusico = ("Sim".Equals(row["AtendePreTesteCultoMusico"])) ? true : false,
                        AtendePreTesteCultoOrganista = ("Sim".Equals(row["AtendePreTesteCultoOrganista"])) ? true : false,
                        AtendeTesteCultoMusico = ("Sim".Equals(row["AtendeTesteCultoMusico"])) ? true : false,
                        AtendeTesteCultoOrganista = ("Sim".Equals(row["AtendeTesteCultoOrganista"])) ? true : false,
                        AtendePreTesteOficialMusico = ("Sim".Equals(row["AtendePreTesteOficialMusico"])) ? true : false,
                        AtendePreTesteOficialOrganista = ("Sim".Equals(row["AtendePreTesteOficialOrganista"])) ? true : false,
                        AtendeTesteOficialMusico = ("Sim".Equals(row["AtendeTesteOficialMusico"])) ? true : false,
                        AtendeTesteOficialOrganista = ("Sim".Equals(row["AtendeTesteOficialOrganista"])) ? true : false,
                        AtendeReuniaoMinisterial = ("Sim".Equals(row["AtendeReuniaoMinisterial"])) ? true : false,
                        AtendeCasal = ("Sim".Equals(row["AtendeCasal"])) ? true : false,
                        AtendeOrdenacao = ("Sim".Equals(row["AtendeOrdenacao"])) ? true : false,
                        Masculino = ("Sim".Equals(row["Masculino"])) ? true : false,
                        Feminino = ("Sim".Equals(row["Feminino"])) ? true : false,
                        PermiteInstrumento = ("Sim".Equals(row["PermiteInstrumento"])) ? true : false,
                        AlunoGem = ("Sim".Equals(row["AlunoGem"])) ? true : false,
                        Ensaio = ("Sim".Equals(row["Ensaio"])) ? true : false,
                        MeiaHora = ("Sim".Equals(row["MeiaHora"])) ? true : false,
                        Rjm = ("Sim".Equals(row["Rjm"])) ? true : false,
                        Culto = ("Sim".Equals(row["Culto"])) ? true : false,
                        Oficial = ("Sim".Equals(row["Oficial"])) ? true : false
                    };

                    //adiciona os dados à lista
                    lista.Add(ent);
                }
                //retorna a lista com os valores pesquisados
                return lista;
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

    }
}