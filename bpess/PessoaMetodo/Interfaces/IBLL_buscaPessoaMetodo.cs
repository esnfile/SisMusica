using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaPessoaMetodo
    {
        List<MOD_pessoaMetodo> Buscar(string codPessoa);
        List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo);
        /// <summary>
        /// Retorna os Metodos definidos para a pessoa, com filtros por CodPessoa, CodMetodo e Se está ativo
        /// <para>Ativo = 'Sim' OR 'Não'</para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codMetodo"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo, string ativo);
        /// <summary>
        /// Retorna os Metodos definidos para a pessoa, com filtros por CodPessoa, CodMetodo, CodInstrumento e Se está ativo
        /// <para>Ativo = 'Sim' OR 'Não'</para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codMetodo"></param>
        /// <param name="ativo"></param>
        /// <param name="codInstrumento"></param>
        /// <returns></returns>
        List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo, string ativo, string codInstrumento);
        /// <summary>
        /// Retorna os Metodos definidos para a pessoa, com filtros por CodPessoa, CodMetodo, CodInstrumento, Aplicação e Se está ativo
        /// <para>AplicarEm = 'Reunião de Jovens' OR 'Culto Oficial' OR 'Meia Hora' OR 'Oficialização' OR 'Troca Instrumento'</para>
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <param name="codMetodo"></param>
        /// <param name="ativo"></param>
        /// <param name="codInstrumento"></param>
        /// <param name="aplicarEm"></param>
        /// <returns></returns>
        List<MOD_pessoaMetodo> Buscar(string codPessoa, string codMetodo, string ativo, string codInstrumento, string aplicarEm);
    }
}