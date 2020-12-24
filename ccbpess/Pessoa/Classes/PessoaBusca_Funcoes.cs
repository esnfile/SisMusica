using ENT.pessoa;
using sismus.Controllers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ccbpess
{
    public partial class frmPessoaBusca
    {

        /// <summary>
        /// Efetua a Busca de Pessoa pelo Código
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        private List<MOD_pessoa> BuscaPessoaPorCodigo(string codPessoa)
        {
            try
            {
                using (PessoaController apiPessoa = new PessoaController())
                    return apiPessoa.BuscaPessoaPorCodigo(string.IsNullOrEmpty(codPessoa) ? 0 : Convert.ToInt64(codPessoa)).ToList();
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
        /// Efetua a Busca de Pessoa pelo Código
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        private List<MOD_pessoa> BuscaPessoaPorCodigo(string codPessoa, bool ativo)
        {
            try
            {
                using (PessoaController apiPessoa = new PessoaController())
                    return apiPessoa.BuscaPessoaPorCodigo(string.IsNullOrEmpty(codPessoa) ? 0 : Convert.ToInt64(codPessoa), ativo).ToList();
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
        /// Efetua a Busca da Pessoa pelo Nome
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        private List<MOD_pessoa> BuscaPessoaPorNome(string nome)
        {
            try
            {
                using (PessoaController apiPessoa = new PessoaController())
                    return apiPessoa.BuscaPessoaPorNome(nome).ToList();
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
        /// Efetua a Busca da Pessoa pelo Nome
        ///<para>Ativo = 'Sim' OR 'Não' </para>
        /// </summary>
        /// <param name="nome"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        private List<MOD_pessoa> BuscaPessoaPorNome(string nome, bool ativo)
        {
            try
            {
                using (PessoaController apiPessoa = new PessoaController())
                    return apiPessoa.BuscaPessoaPorNome(nome, ativo).ToList();
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