using ENT.pessoa;
using ENT.Erros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.pessoa
{
    public interface IBLL_ValidacaoPessoa
    {
        /// <summary>
        /// Valida os Campos se foram preenchidos ou não
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        List<MOD_erros> ValidaCamposPessoa(MOD_pessoa pessoa);

        /// <summary>
        /// Pesquisa a base de dados para verificar se há cpf duplicado
        /// </summary>
        /// <param name="pessoa"></param>
        /// <returns></returns>
        List<MOD_pessoa> ValidaCpfDuplicado(MOD_pessoa pessoa);

        /// <summary>
        /// COnverte Datas e horas existentes no cadastro de pessoas
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        MOD_pessoa ConverteData(MOD_pessoa ent);
    }
}