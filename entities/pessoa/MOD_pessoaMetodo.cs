using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_pessoaMetodo
    {
        public string AplicarEm { get; set; }
        public string FaseInicio { get; set; }
        public string PaginaInicio { get; set; }
        public string LicaoInicio { get; set; }
        public string FaseFim { get; set; }
        public string PaginaFim { get; set; }
        public string LicaoFim { get; set; }

        public string CodPessoa { get; set; }
        public string Nome { get; set; }

        public string CodInstrumento { get; set; }
        public string DescInstrumento { get; set; }
        public string CodFamilia { get; set; }
        public string DescFamilia { get; set; }
        public string Situacao { get; set; }
        public string Ordem { get; set; }

        public string CodMetodo { get; set; }
        public string DescMetodo { get; set; }
        public string Compositor { get; set; }
        public string QtdePagina { get; set; }
        public string Tipo { get; set; }
        public string Ativo { get; set; }
        public string TipoEscolha { get; set; }
        public string PaginaFase { get; set; }

        public bool Marcado { get; set; }

        public string Inicio { get; set; }
        public string Fim { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoPessoaMetodo
    {
        public int HabilitaMetodoPessoa { get; } = 232;
        public int DesabilitaMetodoPessoa { get; } = 233; 
    }
}