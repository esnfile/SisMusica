﻿using System.Data;

namespace DAL.importa
{
    /// <summary>
    /// Interface que controla o retorno dos dados da Tabela ImportaPessoaItem
    /// </summary>
    public interface IDAL_buscaImportaPessoaItem
    {
        /// <summary>
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        DataTable Buscar(string codCCBUsuario);
        /// <summary>
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso e pelo Código da Importação
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        /// <param name="codImportaPessoa"></param>
        /// <returns></returns>
        DataTable Buscar(string codCCBUsuario, string codImportaPessoa);
        /// <summary>
        ///Método que retorna todos os dados pesquisado pelas Comuns que o Usuário tem acesso, pelo Código da Importação e Pelos Cargos que o Usuário tem Acesso
        /// </summary>
        /// <param name="codCCBUsuario"></param>
        /// <param name="codImportaPessoa"></param>
        /// <param name="codCargoUsuario"></param>
        /// <returns></returns>
        DataTable Buscar(string codCCBUsuario, string codImportaPessoa, string codCargoUsuario);
    }
}