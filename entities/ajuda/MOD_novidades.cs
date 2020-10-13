using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.ajuda
{
    public class MOD_novidades
    {
        public string CodNovidades { get; set; }
        public string Data { get; set; }
        /// <summary>
        /// [Status]='Correção de Erros' OR [Status]='Novos Recursos' OR [Status]='Melhorias Internas'
        /// </summary>
        public string Status { get; set; }
        public string CodPrograma { get; set; }
        public string Descricao { get; set; }
        /// <summary>
        /// [TipoAtualiza]='Versão' OR [TipoAtualiza]='Módulos' OR [TipoAtualiza]='Base de Dados'
        /// </summary>
        public string TipoAtualiza { get; set; }
        /// <summary>
        /// [Andamento]='A Implementar' OR [Andamento]='Em Teste' OR [Andamento]='Aprovada' OR [Andamento]='Publicada'
        /// </summary>
        public string Andamento { get; set; }
        public string DescPrograma { get; set; }
        public string NivelProg { get; set; }
        public string CodSubModulo { get; set; }
        public string DescSubModulo { get; set; }
        public string NivelSub { get; set; }
        public string CodModulo { get; set; }
        public string DescModulo { get; set; }
        public string NivelMod { get; set; }

        public MOD_log Logs { get; set; }
    }
}