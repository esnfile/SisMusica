using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using BLL.cargo;
using System.Data.SqlClient;
using ENT.pessoa;
using BLL.conecta;

namespace sismus.Controllers
{
    //[Route("sismus/cargo")]
    public class CargoController : ApiController
    {
        private static IBLL_buscaCargo objBLL_BuscaCargo = null;
        private static IBLL_Cargo objBLL_Cargo = null;

        public CargoController()
        {
            Conect.Conectar();
        }

        /// <summary>
        /// Método que Busca os Cargos na Tabela, pesquisado pelo Código
        /// </summary>
        /// <param name="codCargo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/cargo/buscaPorCodigo/{codCargo:int?}")]
        public IEnumerable<MOD_cargo> BuscaCargoPorCodigo(int? codCargo)
        {
            try
            {
                objBLL_BuscaCargo = new BLL_buscaCargoPorCodigo();

                //return Ok(objBLL_BuscaCargo.Buscar(string.Empty));

                //Verifica se foi informado zero, caso o usuario tenha solicitado todos os registros
                if (codCargo.Equals(0))
                {

                    return objBLL_BuscaCargo.Buscar(string.Empty);
                }
                return objBLL_BuscaCargo.Buscar(Convert.ToString(codCargo));
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
        /// Método que Busca os Cargos na Tabela, pesquisado pela Descrição
        /// </summary>
        /// <param name="descCargo"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/cargo/buscaPorDescricao/{descCargo}")]
        public IEnumerable<MOD_cargo> BuscaCargoPorDescricao(string descCargo)
        {
            try
            {

                objBLL_BuscaCargo = new BLL_buscaCargoPorDescricao();

                //Verifica se foi informado zero, caso o usuario tenha solicitado todos os registros
                if (string.IsNullOrEmpty(descCargo))
                {
                    return objBLL_BuscaCargo.Buscar(string.Empty);
                }
                return objBLL_BuscaCargo.Buscar(Convert.ToString(descCargo));
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
        /// Método que Busca os Cargos na Tabela, pesquisado pelo Departamento
        /// </summary>
        /// <param name="codDepartamento"></param>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("~/api/cargo/buscaPorDepartamento/{codDepartamento:int?}")]
        public IEnumerable<MOD_cargo> BuscaCargoPorDepartamento(int? codDepartamento)
        {
            try
            {

                objBLL_BuscaCargo = new BLL_buscaCargoPorDepartamento();

                //Verifica se foi informado zero, caso o usuario tenha solicitado todos os registros
                if (0.Equals(codDepartamento))
                {
                    return objBLL_BuscaCargo.Buscar(string.Empty);
                }
                return objBLL_BuscaCargo.Buscar(Convert.ToString(codDepartamento));
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
        /// Recebe o Código do Cargo para efetuar a exclusão na base de dados
        /// </summary>
        /// <param name="codCargo"></param>
        /// <returns></returns>
        [AcceptVerbs("DELETE")]
        [Route("~/api/cargo/delete/{codCargo:int}")]
        public bool Delete(int codCargo)
        {
            try
            {
                //Busca o Registro Informado para Exclusão
                MOD_cargo cargo = BuscaCargoPorCodigo(codCargo).First();

                if (cargo == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                objBLL_Cargo = new BLL_cargo();
                return objBLL_Cargo.Delete(cargo);

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
        /// Método que faz a Inserção de novo Cargo e retorna o registro Incluído
        /// </summary>
        /// <param name="cargo"></param>
        /// <param name="listaCargoRetorno"></param>
        /// <returns></returns>
        [AcceptVerbs("POST")]
        [Route("~/api/cargo/insert")]
        public IEnumerable<MOD_cargo> Insert(MOD_cargo cargo)
        {
            try
            {
                if (cargo == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                objBLL_Cargo = new BLL_cargo();
                List<MOD_cargo> listaCargo = new List<MOD_cargo>();
                if (objBLL_Cargo.Insert(cargo, out listaCargo) == true)
                {
                    return listaCargo;
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
        /// Método que faz a Atualização de um determinado Cargo e retorna o registro Atualizado
        /// </summary>
        /// <param name="cargo"></param>
        /// <param name="listaCargoRetorno"></param>
        /// <returns></returns>
        [AcceptVerbs("PUT")]
        [Route("~/api/cargo/update")]
        public IEnumerable<MOD_cargo> Update(MOD_cargo cargo)
        {
            try
            {
                if (cargo == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                objBLL_Cargo = new BLL_cargo();
                List<MOD_cargo> listaCargo = new List<MOD_cargo>();
                if (objBLL_Cargo.Update(cargo, out listaCargo) == true)
                {
                    return listaCargo;
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