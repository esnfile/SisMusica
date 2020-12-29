using ENT.Erros;
using System.Collections.Generic;
using ENT.importa;

namespace BLL.importa
{
    public interface IBLL_ValidacaoImporta
    {
        /// <summary>
        /// Valida os Campos se foram preenchidos ou não
        /// </summary>
        /// <param name="importacao"></param>
        /// <returns></returns>
        List<MOD_erros> ValidaCamposImporta(MOD_importaPessoa importacao);

        /// <summary>
        /// Converte Datas e horas existentes nos dados da importação
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        MOD_importaPessoa ConverteData(MOD_importaPessoa ent);
        /// <summary>
        /// Converte Datas e horas existentes nos dados da importação
        /// </summary>
        /// <param name="lista"></param>
        /// <returns></returns>
        MOD_importaPessoaItem ConverteData(MOD_importaPessoaItem ent);
        /// <summary>
        /// Converte Datas e horas existentes nos dados da importação
        /// </summary>
        /// <param name="ent"></param>
        /// <returns></returns>
        MOD_importaPessoaItemErro ConverteData(MOD_importaPessoaItemErro ent);
    }
}