using ENT.Erros;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.cargo
{
    public class ValidacaoCargo : IValidacaoCargo
    {
        //inicia uma nova lista de erros
        List<MOD_erros> listaErros = new List<MOD_erros>();

        /// <summary>
        /// Validação Campo da Tabela Cargo
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        public List<MOD_erros> ValidaCamposCargo(MOD_cargo cargo)
        {
            try
            {
                if (string.IsNullOrEmpty(cargo.SiglaCargo))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Sigla de Abreviação! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cargo.DescCargo))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Descrição! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (0.Equals(cargo.Ordem))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Ordem! Valor deve ser diferente de Zero.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cargo.CodDepartamento))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Departamento! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if ("Não".Equals(cargo.Masculino) && "Não".Equals(cargo.Feminino))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Informe se o Ministério é atendido por Irmãos(ãs).";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if ("Sim".Equals(cargo.PermiteInstrumento))
                {
                    if ("Não".Equals(cargo.AlunoGem) && "Não".Equals(cargo.Ensaio) &&
                        "Não".Equals(cargo.MeiaHora) && "Não".Equals(cargo.Rjm) &&
                        "Não".Equals(cargo.Culto) && "Não".Equals(cargo.Oficial))
                    {
                        MOD_erros objEnt_Erros = new MOD_erros();
                        objEnt_Erros.Texto = "Desenvolvimento musical! Campo obrigatório.";
                        objEnt_Erros.Grau = "Alto";
                        listaErros.Add(objEnt_Erros);
                    }
                }
                return listaErros;
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