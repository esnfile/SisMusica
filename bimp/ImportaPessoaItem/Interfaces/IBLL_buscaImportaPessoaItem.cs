using ENT.importa;
using System.Collections.Generic;

namespace BLL.importa
{
    /// <summary>
    /// Regra de Negócio: Classe é responsável por Buscar os dados na Tabela ImportaPessoaItem
    /// </summary>
    public interface IBLL_buscaImportaPessoaItem
    {
        /// <summary>
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        List<MOD_importaPessoaItem> Buscar(string codCCBUsuario);
        /// <summary>
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso e pelo Código da Importação
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        /// <param name="codImportaPessoa"></param>
        /// <returns></returns>
        List<MOD_importaPessoaItem> Buscar(string codCCBUsuario, string codImportaPessoa);
        /// <summary>
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso, pelo Código da Importação e Pelos Cargos que o Usuário tem Acesso
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        /// <param name="codImportaPessoa"></param>
        /// <param name="codCargoUsuario"></param>
        /// <returns></returns>
        List<MOD_importaPessoaItem> Buscar(string codCCBUsuario, string codImportaPessoa, string codCargoUsuario);
    }
}