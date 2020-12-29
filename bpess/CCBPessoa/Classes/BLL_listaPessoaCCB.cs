using BLL.Funcoes;
using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public class BLL_listaPessoaCCB : IBLL_criarListaCCB
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
                    //instancia a entidade
                    MOD_pessoaCCB ent = new MOD_pessoaCCB
                    {
                        //adiciona os campos às propriedades
                        CodPessoa = (string)(row.IsNull("CodPessoa") ? Convert.ToString(null) : Convert.ToString(row["CodPessoa"]).PadLeft(6, '0')),
                        Nome = (string)(row.IsNull("Nome") ? null : row["Nome"]),
                        CodCargo = (string)(row.IsNull("CodCargo") ? Convert.ToString(null) : Convert.ToString(row["CodCargo"]).PadLeft(3, '0')),
                        DescCargo = (string)(row.IsNull("DescCargo") ? null : row["DescCargo"]),
                        Ordem = (string)(row.IsNull("Ordem") ? Convert.ToString(null) : Convert.ToString(row["Ordem"])),
                        DataApresentacao = (string)(row.IsNull("DataApresentacao") ? Convert.ToString(null) : funcoes.IntData(row["DataApresentacao"].ToString())),
                        CodCCB = (string)(row.IsNull("CodCCB") ? Convert.ToString(null) : Convert.ToString(row["CodCCB"]).PadLeft(6, '0')),
                        CodigoCCB = (string)(row.IsNull("CodigoCCB") ? null : row["CodigoCCB"]),
                        DescricaoCCB = (string)(row.IsNull("DescricaoCCB") ? null : row["DescricaoCCB"]),
                        Endereco = (string)(row.IsNull("Endereco") ? null : row["Endereco"]),
                        Numero = (string)(row.IsNull("Numero") ? null : row["Numero"]),
                        Bairro = (string)(row.IsNull("Bairro") ? null : row["Bairro"]),
                        CodCidade = (string)(row.IsNull("CodCidade") ? Convert.ToString(null) : Convert.ToString(row["CodCidade"]).PadLeft(6, '0')),
                        Cep = (string)(row.IsNull("Cep") ? null : funcoes.FormataString("#####-###", row["Cep"].ToString())),
                        Estado = (string)(row.IsNull("Estado") ? null : row["Estado"]),
                        Cidade = (string)(row.IsNull("Cidade") ? null : row["Cidade"]),
                        CodRegiao = (string)(row.IsNull("CodRegiao") ? Convert.ToString(null) : Convert.ToString(row["CodRegiao"]).PadLeft(6, '0')),
                        CodigoRegiao = (string)(row.IsNull("CodigoRegiao") ? null : row["CodigoRegiao"]),
                        DescricaoRegiao = (string)(row.IsNull("DescricaoRegiao") ? null : row["DescricaoRegiao"])
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