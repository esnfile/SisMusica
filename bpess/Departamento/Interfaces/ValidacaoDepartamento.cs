using ENT.Erros;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public class ValidacaoDepartamento : IValidacaoDepartamento
    {
        //inicia uma nova lista de erros
        List<MOD_erros> listaErros = new List<MOD_erros>();

        /// <summary>
        /// Validação Campo da Tabela Departamento
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public List<MOD_erros> ValidaCamposDepartamento(MOD_departamento departamento)
        {
            try
            {
                if (string.IsNullOrEmpty(departamento.DescDepartamento))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Departamento! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
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