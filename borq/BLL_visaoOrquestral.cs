using BLL.instrumentos;
using BLL.Interface;
using BLL.pessoa;
using BLL.uteis;
using ENT.instrumentos;
using ENT.pessoa;
using ENT.uteis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace borq
{
    public class BLL_visaoOrquestral : iVisaoOrquestral
    {

        #region Declarações

        /// <summary>
        /// Variavel que Instancia as variaveis
        /// </summary>
        BLL_ccb objBLL_CCB = null;
        BLL_regiaoAtuacao objBLL_Regiao = null;
        BLL_regional objBLL_Regional = null;
        BLL_cidade objBLL_Cidade = null;

        BLL_familia objBLL_Familia = null;
        BLL_voz objBLL_Voz = null;
        BLL_instrumento objBLL_Instrumento = null;

        IBLL_buscaVisaoOrquestral objBLL_Pessoa = null;

        List<MOD_ccb> listaCCB = new List<MOD_ccb>();
        List<MOD_regiaoAtuacao> listaRegiao = new List<MOD_regiaoAtuacao>();
        List<MOD_regional> listaRegional = new List<MOD_regional>();
        List<MOD_cidade> listaCidade = new List<MOD_cidade>();
        List<MOD_uf> listaEstado = new List<MOD_uf>();

        List<MOD_familia> listaFamilia = new List<MOD_familia>();
        List<MOD_voz> listaVoz = new List<MOD_voz>();
        List<MOD_instrumentoVozPrincipal> listaInstrumento = new List<MOD_instrumentoVozPrincipal>();

        List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();

        #endregion

        /// <summary>
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela CCB por Região</para>
        /// </summary>
        /// <param name="CodRegiao"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarCCBRegiao(string CodRegiao)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarRegiao(CodRegiao);
                return listaCCB;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela CCB por Cidade</para>
        /// </summary>
        /// <param name="CodCidade"></param>
        /// <returns></returns>
        public List<MOD_ccb> buscarCCBCidade(string CodCidade)
        {
            try
            {
                objBLL_CCB = new BLL_ccb();
                listaCCB = objBLL_CCB.buscarCidadeDescricao(CodCidade);
                return listaCCB;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Região por Regional</para>
        /// </summary>
        /// <param name="CodRegional"></param>
        /// <returns></returns>
        public List<MOD_regiaoAtuacao> buscarRegiao(string CodRegional)
        {
            try
            {
                objBLL_Regiao = new BLL_regiaoAtuacao();
                listaRegiao = objBLL_Regiao.buscarRegional(CodRegional);
                return listaRegiao;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Regional por Descrição</para>
        /// </summary>
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public List<MOD_regional> buscarRegional(string Descricao)
        {
            try
            {
                objBLL_Regional = new BLL_regional();
                listaRegional = objBLL_Regional.buscarDescricao(Descricao);
                return listaRegional;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Família por Descrição</para>
        /// </summary>
        /// <param name="DescFamilia"></param>
        /// <returns></returns>
        public List<MOD_familia> buscarFamilia(string DescFamilia)
        {
            try
            {
                objBLL_Familia = new BLL_familia();
                listaFamilia = objBLL_Familia.buscarDescricao(DescFamilia);
                return listaFamilia;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Instrumento por Voz</para>
        /// </summary>
        /// <param name="CodVoz"></param>
        /// <returns></returns>
        public List<MOD_instrumentoVozPrincipal> buscarInstrumentos(string CodVoz)
        {
            try
            {
                objBLL_Instrumento = new BLL_instrumento();
                listaInstrumento = objBLL_Instrumento.buscarCodVoz(CodVoz);
                return listaInstrumento;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Instrumento por Voz</para>
        /// </summary>
        /// <param name="CodVoz"></param>
        /// <param name="CodFamilia"></param>
        /// <returns></returns>
        public List<MOD_instrumentoVozPrincipal> buscarInstrumentos(string CodVoz, string CodFamilia)
        {
            try
            {
                objBLL_Instrumento = new BLL_instrumento();
                listaInstrumento = objBLL_Instrumento.buscarCodVoz(CodVoz, CodFamilia);
                return listaInstrumento;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Voz por DescVoz</para>
        /// </summary>
        /// <param name="DescVoz"></param>
        /// <returns></returns>
        public List<MOD_voz> buscarVozes(string DescVoz)
        {
            try
            {
                objBLL_Voz = new BLL_voz();
                listaVoz = objBLL_Voz.buscarDescricao(DescVoz);
                return listaVoz;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Pessoa</para>
        /// </summary>
        /// <param name="CodInstrumento"></param>
        /// <param name="CodCCB"></param>
        /// <returns></returns>
        public List<MOD_pessoa> buscarVisaoOrquestral(string CodInstrumento, string CodCCB, bool Ativo)
        {
            try
            {
                objBLL_Pessoa = new BLL_buscaVisaoOrquestral();
                listaPessoa = objBLL_Pessoa.Buscar(CodInstrumento, CodCCB, Ativo);
                return listaPessoa;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Estado por Sigla</para>
        /// </summary>
        /// <param name="Sigla"></param>
        /// <returns></returns>
        public List<MOD_uf> buscarUf(string Sigla)
        {
            try
            {
                objBLL_Cidade = new BLL_cidade();
                listaEstado = objBLL_Cidade.buscarUf(Sigla);
                return listaEstado;
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
        /// Função que busca os dados para preenchimento do Formulário Visão Orquestral
        /// <para>Tabela Ciadde por Estado</para>
        /// </summary>
        /// <param name="Estado"></param>
        /// <returns></returns>
        public List<MOD_cidade> buscarMunicipios(string Estado)
        {
            try
            {
                objBLL_Cidade = new BLL_cidade();
                listaCidade = objBLL_Cidade.buscarMunicipios(Estado);
                return listaCidade;
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