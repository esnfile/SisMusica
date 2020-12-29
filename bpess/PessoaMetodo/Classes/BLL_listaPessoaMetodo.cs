using ENT.pessoa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.pessoa
{
    public class BLL_listaPessoaMetodo : IBLL_criarListaMetodo
    {
        /// <summary>
        /// Função que Retorna uma Lista Preenchida com os Valores Pesquisados
        /// </summary>
        /// <param name="objDtb"></param>
        /// <returns></returns>
        public List<MOD_pessoaMetodo> CriarLista(DataTable objDtb)
        {
            try
            {
                //instancia a lista
                List<MOD_pessoaMetodo> lista = new List<MOD_pessoaMetodo>();
                //faz um loop no DataTable e preenche a lista
                foreach (DataRow row in objDtb.Rows)
                {
                    //instancia a Classe Instrumento
                    MOD_pessoaMetodo ent = new MOD_pessoaMetodo();

                    //adiciona os campos às propriedades
                    ent.CodInstrumento = (string)(row.IsNull("CodInstrumento") ? Convert.ToString(null) : Convert.ToString(row["CodInstrumento"]).PadLeft(5, '0'));
                    ent.CodMetodo = (string)(row.IsNull("CodMetodo") ? Convert.ToString(null) : row["CodMetodo"].ToString().PadLeft(3, '0'));
                    ent.AplicarEm = (string)(row.IsNull("AplicarEm") ? null : row["AplicarEm"]);
                    ent.PaginaInicio = (string)(row.IsNull("PaginaInicio") ? Convert.ToString(null) : Convert.ToString(row["PaginaInicio"]).PadLeft(3, '0'));
                    ent.FaseInicio = (string)(row.IsNull("FaseInicio") ? Convert.ToString(null) : Convert.ToString(row["FaseInicio"]).PadLeft(3, '0'));
                    ent.LicaoInicio = (string)(row.IsNull("LicaoInicio") ? Convert.ToString(null) : Convert.ToString(row["LicaoInicio"]).PadLeft(3, '0'));
                    ent.FaseFim = (string)(row.IsNull("FaseFim") ? Convert.ToString(null) : Convert.ToString(row["FaseFim"]).PadLeft(3, '0'));
                    ent.PaginaFim = (string)(row.IsNull("PaginaFim") ? Convert.ToString(null) : Convert.ToString(row["PaginaFim"]).PadLeft(3, '0'));
                    ent.LicaoFim = (string)(row.IsNull("LicaoFim") ? Convert.ToString(null) : Convert.ToString(row["LicaoFim"]).PadLeft(3, '0'));

                    ent.DescMetodo = (string)(row.IsNull("DescMetodo") ? null : row["DescMetodo"]);
                    ent.Compositor = (string)(row.IsNull("Compositor") ? null : row["Compositor"]);
                    ent.TipoEscolha = (string)(row.IsNull("TipoEscolha") ? null : row["TipoEscolha"]);
                    ent.PaginaFase = (string)(row.IsNull("PaginaFase") ? null : row["PaginaFase"]);
                    ent.Tipo = (string)(row.IsNull("Tipo") ? null : row["Tipo"]);
                    ent.Ativo = (string)(row.IsNull("Ativo") ? null : row["Ativo"]);
                    ent.Inicio = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseInicio.PadLeft(3, '0') + "Pág.: " + ent.PaginaInicio.PadLeft(3, '0') + " - Lição: " + ent.LicaoInicio.PadLeft(3, '0') : "Pág.: " + ent.PaginaInicio.PadLeft(3, '0') + " - Lição: " + ent.LicaoInicio.PadLeft(3, '0');
                    ent.Fim = ent.PaginaFase.Equals("Fase") ? "Fase: " + ent.FaseFim.PadLeft(3, '0') + "Pág.: " + ent.PaginaFim.PadLeft(3, '0') + " - Lição: " + ent.LicaoFim.PadLeft(3, '0') : "Pág.: " + ent.PaginaFim.PadLeft(3, '0') + " - Lição: " + ent.LicaoFim.PadLeft(3, '0');

                    ent.Marcado = true;

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