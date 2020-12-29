using ENT.Erros;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.uteis
{
    public class ValidacaoCidade : IValidacaoCidade
    {
        //inicia uma nova lista de erros
        List<MOD_erros> listaErros = new List<MOD_erros>();

        /// <summary>
        /// Validação Campo da Tabela Cidade
        /// </summary>
        /// <param name="cidade"></param>
        /// <returns></returns>
        public List<MOD_erros> ValidaCamposCidade(MOD_cidade cidade)
        {
            try
            {
                if (string.IsNullOrEmpty(cidade.Cidade))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Cidade! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cidade.Estado))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Estado! Campo obrigatório.";
                    objEnt_Erros.Grau = "Alto";
                    listaErros.Add(objEnt_Erros);
                }
                if (string.IsNullOrEmpty(cidade.Cep))
                {
                    MOD_erros objEnt_Erros = new MOD_erros();
                    objEnt_Erros.Texto = "Cep! Campo obrigatório.";
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