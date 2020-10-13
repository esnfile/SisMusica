using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ENT.relatorio
{
    public class MOD_paramRelatorio
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string NomeRelatorio { get; set; }
        public string Regional { get; set; }
        public string RegionalUf { get; set; }
        public string TipoData { get; set; }
        public string Cargo { get; set; }
        public string PulaPagina { get; set; }
        public string RodapeRelatorio { get; set; }
        public string ExibeDetalhe { get; set; }
        public string ExibeResumo { get; set; }
        public string ExibeAusente { get; set; }
        public string TipoRelatorio { get; set; }


        #region Parametros exclusivos para Teste

        /// <summary>
        /// Quantidade de lições de Solfejo para Teste
        /// </summary>
        public string QtdeSolfejo { get; set; }
        /// <summary>
        /// Quantidade de lições de Ritmo para Teste
        /// </summary>
        public string QtdeRitmo { get; set; }
        /// <summary>
        /// Quantidade de lições de Método para Teste
        /// </summary>
        public string QtdeMetodo { get; set; }
        /// <summary>
        /// Quantidade de Hinos para Teste
        /// </summary>
        public string QtdeHino { get; set; }
        /// <summary>
        /// Quantidade de Escalas para Teste
        /// </summary>
        public string QtdeEscala { get; set; }
        /// <summary>
        /// Quantidade de Teoria para Teste
        /// </summary>
        public string QtdeTeoria { get; set; }
        
        #endregion

    }
}