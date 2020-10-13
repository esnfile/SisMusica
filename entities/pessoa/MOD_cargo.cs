using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_cargo
    {
        public string CodCargo { get; set; }
        public string DescCargo { get; set; }
        public string SiglaCargo { get; set; }
        public string Ordem { get; set; }
        public string CodDepartamento { get; set; }
        public string DescDepartamento { get; set; }
        public string PermiteEdicao { get; set; }
        public string AtendeComum { get; set; }
        public string AtendeRegiao { get; set; }
        public string AtendeGEM { get; set; }
        public string AtendeEnsaioLocal { get; set; }
        public string AtendeEnsaioRegional { get; set; }
        public string AtendeEnsaioParcial { get; set; }
        public string AtendeEnsaioTecnico { get; set; }
        public string AtendeReuniaoMocidade { get; set; }
        public string AtendeBatismo { get; set; }
        public string AtendeSantaCeia { get; set; }
        public string AtendeRJM { get; set; }
        public string AtendePreTesteRjmMusico { get; set; }
        public string AtendePreTesteRjmOrganista { get; set; }
        public string AtendeTesteRjmMusico { get; set; }
        public string AtendeTesteRjmOrganista { get; set; }
        public string AtendePreTesteCultoMusico { get; set; }
        public string AtendePreTesteCultoOrganista { get; set; }
        public string AtendeTesteCultoMusico { get; set; }
        public string AtendeTesteCultoOrganista { get; set; }
        public string AtendePreTesteOficialMusico { get; set; }
        public string AtendePreTesteOficialOrganista { get; set; }
        public string AtendeTesteOficialMusico { get; set; }
        public string AtendeTesteOficialOrganista { get; set; }
        public string AtendeReuniaoMinisterial { get; set; }
        public string AtendeCasal { get; set; }
        public string AtendeOrdenacao { get; set; }
        public string Masculino { get; set; }
        public string Feminino { get; set; }
        public string PermiteInstrumento { get; set; }
        public string AlunoGem { get; set; }
        public string Ensaio { get; set; }
        public string MeiaHora { get; set; }
        public string Rjm { get; set; }
        public string Culto { get; set; }
        public string Oficial { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoCargo
    {
        public int progCargo { get; set; } = 8;
        public int rotInsCargo { get; set; } = 22;
        public int rotEditCargo { get; set; } = 23;
        public int rotExcCargo { get; set; } = 24;
        public int rotVisCargo { get; set; } = 25;
    }
}
