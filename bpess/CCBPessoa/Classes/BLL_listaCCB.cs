using BLL.Funcoes;
using ENT.instrumentos;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_listaCCB : IBLL_criarListaCCB
    {
        
        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_pessoaCCB> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoaCCB> lista = new List<MOD_pessoaCCB>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a Classe Instrumento
                    MOD_pessoaCCB ent = new MOD_pessoaCCB();

                    //adiciona os campos às propriedades
                    ent.CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0'));
                    ent.CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]);
                    ent.DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]);
                    ent.Endereco = (string)(row.IsNull("Endereco") ? null : row["Endereco"]);
                    ent.Numero = (string)(row.IsNull("Numero") ? null : row["Numero"]);
                    ent.Bairro = (string)(row.IsNull("Bairro") ? null : row["Bairro"]);
                    ent.CodCidade = (string)(row.IsNull("CodCidade") ? Convert.ToString(null) : Convert.ToString(row["CodCidade"]).PadLeft(6, '0'));
                    ent.Cep = (string)(row.IsNull("Cep") ? null : funcoes.FormataString("#####-###", row["Cep"].ToString()));
                    ent.Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]);
                    ent.Cidade = (string)(row.IsNull("Cidade") ? null : row["Cidade"]);
                    ent.CodRegiao = (string)(row.IsNull("CodRegiao") ? null : row["CodRegiao"]);
                    ent.CodigoRegiao = (string)(row.IsNull("CodigoRegiao") ? null : row["CodigoRegiao"]);
                    ent.DescricaoRegiao = (string)(row.IsNull("DescricaoRegiao") ? null : row["DescricaoRegiao"]);
                    ent.CodPessoa = "0";

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