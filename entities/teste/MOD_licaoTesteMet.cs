using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.licao
{
    public class MOD_licaoTesteMet
    {
        public string CodLicaoMet { get; set; }
        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string CodMetodo { get; set; }
        public string DescMetodo { get; set; }
        public string Compositor { get; set; }
        public string Tipo { get; set; }
        public string AplicaEm { get; set; }
        public string QtdePagina { get; set; }
        public string Ativo { get; set; }
        public string TipoEscolha { get; set; }
        public string PaginaFase { get; set; }
        public string FaseMet { get; set; }
        public string PaginaMet { get; set; }
        public string LicaoMet { get; set; }
        public string CodFamilia { get; set; }
        public string Situacao { get; set; }
        public string Ordem { get; set; }
        public string FasePagLicao { get; set; }

        public MOD_log Logs { get; set; }
    }
}
