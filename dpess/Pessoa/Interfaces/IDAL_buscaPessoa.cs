using System.Data;

namespace DAL.pessoa
{
    public interface IDAL_buscaPessoa
    {
        DataTable Buscar(string texto);
        DataTable Buscar(string texto, bool ativo);
        DataTable Buscar(string texto, string codCCBUsu);
        DataTable Buscar(string texto, string codCCBUsu, bool ativo);
        DataTable Buscar(string texto, string codCCBUsu, string codCargoUsu);
        /// <summary>
        /// Função que retorna os Registros da tabela Pessoa, pesquisado pelo Cargo e a Comum
        ///     Ativo - Sim ou Não
        /// </summary>
        /// <param name="CodCargo"></param>
        /// <param name="CodCCBUsu"></param>
        /// <param name="CodCargoUsu"></param>
        /// <param name="Ativo"></param>
        /// <returns></returns>
        DataTable Buscar(string texto, string codCCBUsu, string codCargoUsu, bool ativo);
    }
}