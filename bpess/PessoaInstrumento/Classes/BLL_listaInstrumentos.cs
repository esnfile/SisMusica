using ENT.instrumentos;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_listaInstrumentos
    {
        
        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_pessoaInstr> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoaInstr> lista = new List<MOD_pessoaInstr>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a Classe Instrumento
                    MOD_pessoaInstr ent = new MOD_pessoaInstr
                    {
                        //adiciona os campos às propriedades
                        CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(3, '0')),
                        DescInstrumento = (string)(row.IsNull("DescInstrumento") ? null : row["DescInstrumento"]),
                        CodFamilia = (string)(row.IsNull("CodFamilia") ? Convert.ToString(null) : Convert.ToString(row["CodFamilia"]).PadLeft(3, '0')),
                        DescFamilia = (string)(row.IsNull("DescFamilia") ? null : row["DescFamilia"]),
                        Situacao = (string)(row.IsNull("Situacao") ? null : row["Situacao"]),
                        Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"]).PadLeft(2, '0')),
                        CodPessoa = "0",
                        Marcado = false
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