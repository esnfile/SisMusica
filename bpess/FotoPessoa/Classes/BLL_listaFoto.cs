using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_listaFoto
    {
        
        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_pessoaFoto> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoaFoto> lista = new List<MOD_pessoaFoto>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a Classe Instrumento
                    MOD_pessoaFoto ent = new MOD_pessoaFoto();

                    //adiciona os campos às propriedades
                    ent.CodFoto = (string)(row.IsNull("CodFoto") ? Convert.ToString(null) : Convert.ToString(row["CodFoto"]).PadLeft(6, '0'));
                    ent.CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0'));
                    ent.Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]);
                    ent.Foto = (byte[])row["Foto"];

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