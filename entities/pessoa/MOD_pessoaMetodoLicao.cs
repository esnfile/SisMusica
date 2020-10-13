using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_pessoaMetodoLicao
    {
        public string CodPesMetLicao { get; set; }
        public string CodPessoa { get; set; }
        public string Nome { get; set; }
        public string CodMetodo { get; set; }
        public string DescMetodo { get; set; }
        public string Compositor { get; set; }
        /// <summary>
        /// TipoEscolha='Sistema', 'Candidato'
        /// </summary>
        public string TipoEscolha { get; set; }
        /// <summary>
        /// PaginaFase='Página', 'Fase'
        /// </summary>
        public string PaginaFase { get; set; }
        /// <summary>
        /// Tipo='Solfejo', 'Ritmo', 'Instrumento'
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// Ativo='Sim', 'Não'
        /// </summary>
        public string Ativo { get; set; }
        public string Fase { get; set; }
        public string Pagina { get; set; }
        public string Licao { get; set; }
        /// <summary>
        /// Status='Estudar', 'Aprovada'
        /// </summary>
        public string Status { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoPessoaMetodoLicao
    {
        public int progPesMetLicao { get; set; } = 36;
        public int rotInsPesMetLicao { get; set; } = 200;
        public int rotEditPesMetLicao { get; set; } = 201;
        public int rotExcPesMetLicao { get; set; } = 202;
        public int rotVisPesMetLicao { get; set; } = 203;
    }
}