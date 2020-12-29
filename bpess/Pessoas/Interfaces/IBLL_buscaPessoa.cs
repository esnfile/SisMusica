using ENT.pessoa;
using System.Collections.Generic;

namespace BLL.pessoa
{
    public interface IBLL_buscaPessoa
    {
        /// <summary>
        /// Interface que controla a busca na Tabela Pessoa - Transmite o Texto para busca de acordo com a Classe solicitada
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        List<MOD_pessoa> Buscar(string texto);
        /// <summary>
        /// Interface que controla a busca na Tabela Pessoa - Transmite o Texto para busca de acordo com a Classe solicitada
        /// <para>Ativo: Sim ou Não</para>
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        List<MOD_pessoa> Buscar(string texto, bool ativo);
    }
}