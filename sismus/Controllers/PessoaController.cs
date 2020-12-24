using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.SqlClient;
using ENT.pessoa;
using BLL.pessoa;
using BLL.Funcoes;
using BLL.conecta;

namespace sismus.Controllers
{
    [Route("pessweb/pessoa")]
    public class PessoaController : ApiController
    {
        private static IBLL_buscaPessoa objBLL_BuscaPessoa = null;
        private static IBLL_buscaRelatorio objBLL_BuscaRelatorio = null;
        private static IBLL_Pessoa objBLL_Pessoa = null;

        public PessoaController()
        {
            Conect.Conectar();
        }

        /// <summary>
        /// Método que Busca os Cargos na Tabela, pesquisado pelo Código
        /// <para> Caso queira retornar todos os registros, informar zero no parâmetro</para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCodigo/{codPessoa:int}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCodigo(Int64 codPessoa)
        {
            try
            {
                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodPessoa();

                //Verifica se foi informado zero, caso o usuario tenha solicitado todos os registros
                if (codPessoa.Equals(0))
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codPessoa));
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
        /// Método que Busca os Cargos na Tabela, pesquisado pelo Código
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCodigo/{codPessoa:int}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCodigo(Int64 codPessoa, bool ativo)
        {
            try
            {
                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodPessoa();

                //Verifica se foi informado zero, caso o usuario tenha solicitado todos os registros
                if (codPessoa.Equals(0))
                {

                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codPessoa), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorNome/{nome}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorNome(string nome)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorNome();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(nome))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(nome);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Nome
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorNome/{nome}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorNome(string nome, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorNome();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(nome))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(nome, ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Cargo
        /// </summary>
        /// <param name="codCargo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCargo/{codCargo:int}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCargo(int codCargo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCargo();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codCargo))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codCargo));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Cargo
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codCargo"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCargo/{codCargo:int}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCargo(int codCargo, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCargo();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codCargo))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codCargo), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pela Cidade
        /// </summary>
        /// <param name="codCidade"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCidade/{codCidade:int}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCidade(int codCidade)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCidade();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codCidade))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codCidade));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pela Cidade
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codCidade"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCidade/{codCidade:int}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCidade(int codCidade, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCidade();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codCidade))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codCidade), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Código Referencia Bras
        /// </summary>
        /// <param name="codigoRefBras"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCodigoRefBras/{codigoRefBras}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCodRefBras(string codigoRefBras)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodRefBras();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(codigoRefBras))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codigoRefBras));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Código Referencia Bras
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codigoRefBras"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCodigoRefBras/{codigoRefBras}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCodRefBras(string codigoRefBras, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodRefBras();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(codigoRefBras))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codigoRefBras), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Código Referencia Região
        /// </summary>
        /// <param name="codigoRefReg"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCodigoRefRegiao/{codigoRefReg}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCodRefRegiao(string codigoRefReg)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodRefRegiao();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(codigoRefReg))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codigoRefReg));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Código Referencia Região
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codigoRefReg"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCodigoRefRegiao/{codigoRefReg}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCodRefRegiao(string codigoRefReg, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCodRefRegiao();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(codigoRefReg))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codigoRefReg), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pela Comum
        /// </summary>
        /// <param name="codCCB"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorComum/{codCCB:int}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorComum(int codCCB)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorComum();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codCCB))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codCCB));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pela Comum
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codCCB"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorComum/{codCCB:int}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorComum(int codCCB, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorComum();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codCCB))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codCCB), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo CPF
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCpf/{cpf}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCpf(string cpf)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCpf();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(cpf))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(cpf));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo CPF
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorCpf/{cpf}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorCpf(string cpf, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorCpf();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(cpf))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(cpf), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Instrumento
        /// </summary>
        /// <param name="codInstrumento"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorInstrumento/{codInstrumento:int}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorInstrumento(int codInstrumento)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorInstrumento();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codInstrumento))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codInstrumento));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pelo Instrumento
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codInstrumento"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorInstrumento/{codInstrumento:int}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorInstrumento(int codInstrumento, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorInstrumento();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codInstrumento))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codInstrumento), ativo);
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pela Micro-Região
        /// </summary>
        /// <param name="codRegiao"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorRegiao/{codRegiao:int}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorRegiao(int codRegiao)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorRegiao();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codRegiao))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codRegiao));
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
        /// Método que Busca as Pessoas na Tabela, pesquisado pela Micro-Região
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codRegiao"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaPorRegiao/{codRegiao:int}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaPessoaPorRegiao(int codRegiao, bool ativo)
        {
            try
            {

                objBLL_BuscaPessoa = new BLL_buscaPessoaPorRegiao();

                //Verifica se foi informado o campo em branco, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codRegiao))
                {
                    return objBLL_BuscaPessoa.Buscar(string.Empty, ativo);
                }
                return objBLL_BuscaPessoa.Buscar(Convert.ToString(codRegiao), ativo);
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

        #region Rotinas para Retornar Dados para emissão de Relatórios

        /// <summary>
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// <para>Todos os filtros tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB);
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
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// desenvolvimento = 'Aluno GEM','Ensaio','Meia Hora','Reunião Jovens','Culto Oficial','Oficializado'   /   
        /// <para>Todos os filtros tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <param name="desenvolvimento"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}/{desenvolvimento}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB, string desenvolvimento)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB, desenvolvimento);
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
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// Ativo = 'Sim' OR 'Não'
        /// <para>Todos os filtros tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}/{ativo:bool}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB, bool ativo)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB, ativo);
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
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// Ativo = 'Sim' OR 'Não'
        /// desenvolvimento = 'Aluno GEM','Ensaio','Meia Hora','Reunião Jovens','Culto Oficial','Oficializado'   /   
        /// <para>Todos os filtros tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <param name="ativo"></param>
        /// <param name="desenvolvimento"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}/{ativo:bool}/{desenvolvimento}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB, bool ativo, string desenvolvimento)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB, ativo, desenvolvimento);
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
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// campoData = 'DataNasc' OR 'DataCadastro' OR 'DataApresentacao'   /   
        /// dataInicial e dataFinal = irá retornar os valores que cadstrados entre as datas informadas (Informar Datas já validadas)
        /// <para>Todos os filtros, com exceção da data, tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <param name="campoData"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}/{campoData}/{dataInicial:DateTime}/{dataFinal:DateTime}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB, string campoData, DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB, campoData,  funcoes.FormataData(Convert.ToString(dataInicial)), funcoes.FormataData(Convert.ToString(dataFinal)));
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
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// campoData = 'DataNasc' OR 'DataCadastro' OR 'DataApresentacao'   /   
        /// dataInicial e dataFinal = irá retornar os valores que cadstrados entre as datas informadas (Informar Datas já validadas)
        /// desenvolvimento = 'Aluno GEM','Ensaio','Meia Hora','Reunião Jovens','Culto Oficial','Oficializado'   /   
        /// <para>Todos os filtros, com exceção da data, tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <param name="campoData"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <param name="desenvolvimento"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}/{campoData}/{dataInicial:DateTime}/{dataFinal:DateTime}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB, string campoData, DateTime dataInicial, DateTime dataFinal, string desenvolvimento)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB, campoData, funcoes.FormataData(Convert.ToString(dataInicial)), funcoes.FormataData(Convert.ToString(dataFinal)), desenvolvimento);
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
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// Ativo = 'Sim' OR 'Não'
        /// campoData = 'DataNasc' OR 'DataCadastro' OR 'DataApresentacao'   /   
        /// dataInicial e dataFinal = irá retornar os valores que cadstrados entre as datas informadas (Informar Datas já validadas)
        /// <para>Todos os filtros, com exceção da data, tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <param name="ativo"></param>
        /// <param name="campoData"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}/{ativo:bool}/{campoData}/{dataInicial:DateTime}/{dataFinal:DateTime}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB, bool ativo, string campoData, DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB, ativo, campoData, funcoes.FormataData(Convert.ToString(dataInicial)), funcoes.FormataData(Convert.ToString(dataFinal)));
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
        /// Método que Busca as Pessoas na Tabela, para filtro de relatórios  /   
        /// sexo = 'Masculino','Feminino'  /   
        /// estadoCivil = 'Solteiro(a)','Casado(a)','Viúvo(a)','Divorciado(a)'   /   
        /// codCargo e codCCB: 'Informar os códigos em sequencia para efetuar a seleção de varios registros...Ex(1,2,3,...)   /   
        /// Ativo = 'Sim' OR 'Não'
        /// campoData = 'DataNasc' OR 'DataCadastro' OR 'DataApresentacao'   /   
        /// dataInicial e dataFinal = irá retornar os valores que cadstrados entre as datas informadas (Informar Datas já validadas)
        /// desenvolvimento = 'Aluno GEM','Ensaio','Meia Hora','Reunião Jovens','Culto Oficial','Oficializado'   /   
        /// <para>Todos os filtros, com exceção da data, tem opção de retornar varios valores, atraves da Clausula IN()</para>
        /// </summary>
        /// <param name="sexo"></param>
        /// <param name="estadoCivil"></param>
        /// <param name="codCargo"></param>
        /// <param name="codCCB"></param>
        /// <param name="campoData"></param>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <param name="desenvolvimento"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/pessoa/buscaRelatorioPessoa/{sexo}/{estadoCivil}/{codCargo}/{codCCB}/{ativo:bool}/{campoData}/{dataInicial:DateTime}/{dataFinal:DateTime}/{desenvolvimento}")]
        public IEnumerable<MOD_pessoa> BuscaRelatorioPessoa(string sexo, string estadoCivil, string codCargo, string codCCB, bool ativo, string campoData, DateTime dataInicial, DateTime dataFinal, string desenvolvimento)
        {
            try
            {
                objBLL_BuscaRelatorio = new BLL_buscaRelatorioPessoa();
                return objBLL_BuscaRelatorio.Buscar(sexo, estadoCivil, codCargo, codCCB, ativo, campoData, funcoes.FormataData(Convert.ToString(dataInicial)), funcoes.FormataData(Convert.ToString(dataFinal)), desenvolvimento);
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

        #endregion

        /// <summary>
        /// Recebe o Código da Pessoa para efetuar a exclusão na base de dados
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        [AcceptVerbs("DELETE")]
        [Route("~/api/pessoa/delete/{codPessoa:int}")]
        public bool Delete(int codPessoa)
        {
            try
            {
                //Busca o Registro Informado para Exclusão
                MOD_pessoa cargo = BuscaPessoaPorCodigo(codPessoa).First();

                if (cargo == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                objBLL_Pessoa = new BLL_pessoa();
                return objBLL_Pessoa.Delete(cargo);

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
        /// Método que faz a Inserção de nova Pessoa e retorna o registro Incluído
        /// </summary>
        /// <param name="pessoa"></param>
        /// <param name="listaPessoaRetorno"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("~/api/pessoa/insert")]
        public IEnumerable<MOD_pessoa> Insert(MOD_pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                objBLL_Pessoa = new BLL_pessoa();
                List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
                if (objBLL_Pessoa.Insert(pessoa, out listaPessoa) == true)
                {
                    return listaPessoa;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
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
        /// Método que faz a Atualização de um determinada Pessoa e retorna o registro Atualizado
        /// </summary>
        /// <param name="pessoa"></param>
        /// <param name="listaPessoaRetorno"></param>
        /// <returns></returns>
        [AcceptVerbs("PUT")]
        [Route("~/api/pessoa/update")]
        public IEnumerable<MOD_pessoa> Update(MOD_pessoa pessoa)
        {
            try
            {
                if (pessoa == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                objBLL_Pessoa = new BLL_pessoa();
                List<MOD_pessoa> listaPessoa = new List<MOD_pessoa>();
                if (objBLL_Pessoa.Update(pessoa, out listaPessoa) == true)
                {
                    return listaPessoa;
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
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