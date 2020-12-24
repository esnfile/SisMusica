using ENT.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ENT.pessoa
{
    public class MOD_cargo
    {
        private string codCargo;
        /// <summary>
        /// (ID) Código do Cargo
        /// </summary>
        [Key]
        [Display(Name = "CodCargo")]
        [DataObjectField(true, true, false)]
        [DisplayName("Código")]
        public string CodCargo
        {
            get
            {
                return codCargo;
            }
            set
            {
                codCargo = value;
            }
        }

        private string descCargo;
        /// <summary>
        /// Descrição do Cargo
        /// <para>Tipo de Dados na Tabela: varchar(20)</para>
        /// </summary>
        [Required(ErrorMessage = "Descrição do Cargo! Campo obrigatório.")]
        [StringLength(20, ErrorMessage = "Esse campo suporta no máximo 20 caracteres.")]
        [DataType(DataType.Text)]
        [Display(Name = "DescCargo")]
        [DisplayName("Ministério/Cargo")]
        [DataObjectField(false, false, true)]
        public string DescCargo
        {
            get
            {
                return descCargo;
            }
            set
            {
                descCargo = value;
            }
        }

        private string siglaCargo;
        /// <summary>
        /// Sigla do Cargo
        /// <para>Tipo de Dados na Tabela: varchar(5)</para>
        /// </summary>
        [Required(ErrorMessage = "Sigla do Cargo! Campo obrigatório.")]
        [StringLength(5, ErrorMessage = "Esse campo suporta no máximo 5 caracteres.")]
        [Display(Name = "SiglaCargo")]
        [DisplayName("Sigla")]
        [DataObjectField(false, false, true)]
        public string SiglaCargo
        {
            get
            {
                return siglaCargo;
            }
            set
            {
                siglaCargo = value;
            }
        }

        private string ordem;
        /// <summary>
        /// Ordem do Cargo
        /// <para>Tipo de Dados na Tabela: smallint</para>
        /// </summary>
        [Required(ErrorMessage = "Ordem de Sequencia! Campo obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Campo deve ser maior do que Zero.")]
        [Display(Name = "Ordem")]
        [DisplayName("Ordem")]
        [DataObjectField(false, false, true)]
        public string Ordem
        {
            get
            {
                return ordem;
            }
            set
            {
                ordem = value;
            }
        }

        private string codDepartamento;
        /// <summary>
        /// Código do Departamento - Chave estrangeira com a Tabela Departamento
        /// <para>Tipo de Dados na Tabela: smallint</para>
        /// </summary>
        [Key]
        [Required(ErrorMessage = "Codigo do Departamento! Campo obrigatório.")]
        [Range(1, Int16.MaxValue, ErrorMessage = "Campo deve ser maior do que Zero.")]
        [Display(Name = "CodDepartamento")]
        [DataObjectField(false, false, true)]
        public string CodDepartamento
        {
            get
            {
                return codDepartamento;
            }
            set
            {
                codDepartamento = value;
            }
        }

        private string descDepartamento;
        /// <summary>
        /// Descrição do Departamento - Campo pertence a Tabela Departamento, buscado pela chave estrangeira CodDepartamento
        /// <para>Tipo de Dados na Tabela: varchar(20)</para>
        /// </summary>
        [Display(Name = "DescDepartamento")]
        [DisplayName("Departamento")]
        public string DescDepartamento
        {
            get
            {
                return descDepartamento;
            }
            set
            {
                descDepartamento = value;
            }
        }

        private string permiteEdicao;
        /// <summary>
        /// Permite Edição? Campo que define se o Cargo permite edição.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "PermiteEdicao")]
        public bool PermiteEdicao
        {
            get
            {
                if ("Sim".Equals(permiteEdicao))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    permiteEdicao = "Sim";
                else
                    permiteEdicao = "Não";
            }
        }

        private string atendeComum;
        /// <summary>
        /// Atende Comum? Campo que define se o Cargo permite atender Comum congregação.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeComum")]
        public bool AtendeComum
        {
            get
            {
                if ("Sim".Equals(atendeComum))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeComum = "Sim";
                else
                    atendeComum = "Não";
            }
        }

        private string atendeRegiao;
        /// <summary>
        /// Atende Região? Campo que define se o Cargo permite atender Região.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeRegiao")]
        public bool AtendeRegiao
        {
            get
            {
                if ("Sim".Equals(atendeRegiao))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeRegiao = "Sim";
                else
                    atendeRegiao = "Não";
            }
        }

        private string atendeGEM;
        /// <summary>
        /// Atende GEM? Campo que define se o Cargo permite atender GEM.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeGEM")]
        public bool AtendeGEM
        {
            get
            {
                if ("Sim".Equals(atendeGEM))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeGEM = "Sim";
                else
                    atendeGEM = "Não";
            }
        }

        private string atendeEnsaioLocal;
        /// <summary>
        /// Atende Ensaio Local? Campo que define se o Cargo permite atender Ensaio Local.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeEnsaioLocal")]
        public bool AtendeEnsaioLocal
        {
            get
            {
                if ("Sim".Equals(atendeEnsaioLocal))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeEnsaioLocal = "Sim";
                else
                    atendeEnsaioLocal = "Não";
            }
        }

        private string atendeEnsaioRegional;
        /// <summary>
        /// Atende Regional? Campo que define se o Cargo permite atender Ensaio Regional.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeEnsaioRegional")]
        public bool AtendeEnsaioRegional
        {
            get
            {
                if ("Sim".Equals(atendeEnsaioRegional))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeEnsaioRegional = "Sim";
                else
                    atendeEnsaioRegional = "Não";
            }
        }

        private string atendeEnsaioParcial;
        /// <summary>
        /// Atende Ensaio Parcial? Campo que define se o Cargo permite atender Ensaio Parcial.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeEnsaioParcial")]
        public bool AtendeEnsaioParcial
        {
            get
            {
                if ("Sim".Equals(atendeEnsaioParcial))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeEnsaioParcial = "Sim";
                else
                    atendeEnsaioParcial = "Não";
            }
        }

        private string atendeEnsaioTecnico;
        /// <summary>
        /// Atende Ensaio Técnico? Campo que define se o Cargo permite atender Ensaio Técnico.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeEnsaioTecnico")]
        public bool AtendeEnsaioTecnico
        {
            get
            {
                if ("Sim".Equals(atendeEnsaioTecnico))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeEnsaioTecnico = "Sim";
                else
                    atendeEnsaioTecnico = "Não";
            }
        }

        private string atendeReuniaoMocidade;
        /// <summary>
        /// Atende Reunião de Mocidade? Campo que define se o Cargo permite atender Reunião de Mocidade.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeReuniaoMocidade")]
        public bool AtendeReuniaoMocidade
        {
            get
            {
                if ("Sim".Equals(atendeReuniaoMocidade))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeReuniaoMocidade = "Sim";
                else
                    atendeReuniaoMocidade = "Não";
            }
        }

        private string atendeBatismo;
        /// <summary>
        /// Atende Batismo? Campo que define se o Cargo permite atender Batismo.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeBatismo")]
        public bool AtendeBatismo
        {
            get
            {
                if ("Sim".Equals(atendeBatismo))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeBatismo = "Sim";
                else
                    atendeBatismo = "Não";
            }
        }

        private string atendeSantaCeia;
        /// <summary>
        /// Atende Santa Ceia? Campo que define se o Cargo permite atender Santa Ceia.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeSantaCeia")]
        public bool AtendeSantaCeia
        {
            get
            {
                if ("Sim".Equals(atendeSantaCeia))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeSantaCeia = "Sim";
                else
                    atendeSantaCeia = "Não";
            }
        }

        private string atendeRJM;
        /// <summary>
        /// Atende Reunião de Jovens? Campo que define se o Cargo permite atender Reunião de Jovens.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeRJM")]
        public bool AtendeRJM
        {
            get
            {
                if ("Sim".Equals(atendeRJM))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeRJM = "Sim";
                else
                    atendeRJM = "Não";
            }
        }

        private string atendePreTesteRjmMusico;
        /// <summary>
        /// Atende Pre Teste RJM Músico? Campo que define se o Cargo permite atender Pre Teste Músico para Reunião de Jovens.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendePreTesteRjmMusico")]
        public bool AtendePreTesteRjmMusico
        {
            get
            {
                if ("Sim".Equals(atendePreTesteRjmMusico))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendePreTesteRjmMusico = "Sim";
                else
                    atendePreTesteRjmMusico = "Não";
            }
        }

        private string atendePreTesteRjmOrganista;
        /// <summary>
        /// Atende Pre Teste RJM Organista? Campo que define se o Cargo permite atender Pre Teste Organista para Reunião de Jovens.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendePreTesteRjmOrganista")]
        public bool AtendePreTesteRjmOrganista
        {
            get
            {
                if ("Sim".Equals(atendePreTesteRjmOrganista))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendePreTesteRjmOrganista = "Sim";
                else
                    atendePreTesteRjmOrganista = "Não";
            }
        }

        private string atendeTesteRjmMusico;
        /// <summary>
        /// Atende Teste RJM Musico? Campo que define se o Cargo permite atender Teste de Músico para Reunião de Jovens.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeTesteRjmMusico")]
        public bool AtendeTesteRjmMusico
        {
            get
            {
                if ("Sim".Equals(atendeTesteRjmMusico))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeTesteRjmMusico = "Sim";
                else
                    atendeTesteRjmMusico = "Não";
            }
        }

        private string atendeTesteRjmOrganista;
        /// <summary>
        /// Atende Teste RJM Organista? Campo que define se o Cargo permite atender Teste Organista para Reunião de Jovens.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeTesteRjmOrganista")]
        public bool AtendeTesteRjmOrganista
        {
            get
            {
                if ("Sim".Equals(atendeTesteRjmOrganista))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeTesteRjmOrganista = "Sim";
                else
                    atendeTesteRjmOrganista = "Não";
            }
        }

        private string atendePreTesteCultoMusico;
        /// <summary>
        /// Atende Pre Teste Culto Musico? Campo que define se o Cargo permite atender Pre Teste de Músico para Culto Oficial.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendePreTesteCultoMusico")]
        public bool AtendePreTesteCultoMusico
        {
            get
            {
                if ("Sim".Equals(atendePreTesteCultoMusico))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendePreTesteCultoMusico = "Sim";
                else
                    atendePreTesteCultoMusico = "Não";
            }
        }

        private string atendePreTesteCultoOrganista;
        /// <summary>
        /// Atende Pre Teste Culto Organista? Campo que define se o Cargo permite atender Pre Teste de Organista para Culto Oficial.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendePreTesteCultoOrganista")]
        public bool AtendePreTesteCultoOrganista
        {
            get
            {
                if ("Sim".Equals(atendePreTesteCultoOrganista))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendePreTesteCultoOrganista = "Sim";
                else
                    atendePreTesteCultoOrganista = "Não";
            }
        }

        private string atendeTesteCultoMusico;
        /// <summary>
        /// Atende Teste Culto Musico? Campo que define se o Cargo permite atender Teste de Músico para Culto Oficial.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeTesteCultoMusico")]
        public bool AtendeTesteCultoMusico
        {
            get
            {
                if ("Sim".Equals(atendeTesteCultoMusico))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeTesteCultoMusico = "Sim";
                else
                    atendeTesteCultoMusico = "Não";
            }
        }

        private string atendeTesteCultoOrganista;
        /// <summary>
        /// Atende Teste Culto Organista? Campo que define se o Cargo permite atender Teste de Organista para Culto Oficial.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeTesteCultoOrganista")]
        public bool AtendeTesteCultoOrganista
        {
            get
            {
                if ("Sim".Equals(atendeTesteCultoOrganista))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeTesteCultoOrganista = "Sim";
                else
                    atendeTesteCultoOrganista = "Não";
            }
        }

        private string atendePreTesteOficialMusico;
        /// <summary>
        /// Atende Pre Teste Oficialização Musico? Campo que define se o Cargo permite atender Pre Teste de Músico para Oficialização.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendePreTesteOficialMusico")]
        public bool AtendePreTesteOficialMusico
        {
            get
            {
                if ("Sim".Equals(atendePreTesteOficialMusico))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendePreTesteOficialMusico = "Sim";
                else
                    atendePreTesteOficialMusico = "Não";
            }
        }

        private string atendePreTesteOficialOrganista;
        /// <summary>
        /// Atende Pre Teste Oficialização Organista? Campo que define se o Cargo permite atender Pre Teste de Organista para Oficialização.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendePreTesteOficialOrganista")]
        public bool AtendePreTesteOficialOrganista
        {
            get
            {
                if ("Sim".Equals(atendePreTesteOficialOrganista))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendePreTesteOficialOrganista = "Sim";
                else
                    atendePreTesteOficialOrganista = "Não";
            }
        }

        private string atendeTesteOficialMusico;
        /// <summary>
        /// Atende Teste Oficialização Musico? Campo que define se o Cargo permite atender Teste de Músico para Oficialização.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeTesteOficialMusico")]
        public bool AtendeTesteOficialMusico
        {
            get
            {
                if ("Sim".Equals(atendeTesteOficialMusico))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeTesteOficialMusico = "Sim";
                else
                    atendeTesteOficialMusico = "Não";
            }
        }

        private string atendeTesteOficialOrganista;
        /// <summary>
        /// Atende Teste Oficialização Organista? Campo que define se o Cargo permite atender Teste de Organista para Oficialização.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeTesteOficialOrganista")]
        public bool AtendeTesteOficialOrganista
        {
            get
            {
                if ("Sim".Equals(atendeTesteOficialOrganista))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeTesteOficialOrganista = "Sim";
                else
                    atendeTesteOficialOrganista = "Não";
            }
        }

        private string atendeReuniaoMinisterial;
        /// <summary>
        /// Atende Reunião Ministerial? Campo que define se o Cargo permite atender Reunião Ministerial.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeReuniaoMinisterial")]
        public bool AtendeReuniaoMinisterial
        {
            get
            {
                if ("Sim".Equals(atendeReuniaoMinisterial))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeReuniaoMinisterial = "Sim";
                else
                    atendeReuniaoMinisterial = "Não";
            }
        }

        private string atendeCasal;
        /// <summary>
        /// Atende Reunião Casal? Campo que define se o Cargo permite atender Reunião Casal.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeCasal")]
        public bool AtendeCasal
        {
            get
            {
                if ("Sim".Equals(atendeCasal))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeCasal = "Sim";
                else
                    atendeCasal = "Não";
            }
        }

        private string atendeOrdenacao;
        /// <summary>
        /// Atende Ordenação? Campo que define se o Cargo permite atender Ordenação.
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AtendeOrdenacao")]
        public bool AtendeOrdenacao
        {
            get
            {
                if ("Sim".Equals(atendeOrdenacao))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    atendeOrdenacao = "Sim";
                else
                    atendeOrdenacao = "Não";
            }
        }

        private string masculino;
        /// <summary>
        /// Sexo Masculino pode atender esse ministério?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "Masculino")]
        public bool Masculino
        {
            get
            {
                if ("Sim".Equals(masculino))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    masculino = "Sim";
                else
                    masculino = "Não";
            }
        }

        private string feminino;
        /// <summary>
        /// Sexo Feminino pode atender esse ministério?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "Feminino")]
        public bool Feminino
        {
            get
            {
                if ("Sim".Equals(feminino))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    feminino = "Sim";
                else
                    feminino = "Não";
            }
        }

        private string permiteInstrumento;
        /// <summary>
        /// Cargo Permite selecionar instrumento?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "PermiteInstrumento")]
        public bool PermiteInstrumento
        {
            get
            {
                if ("Sim".Equals(permiteInstrumento))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    permiteInstrumento = "Sim";
                else
                    permiteInstrumento = "Não";
            }
        }

        private string alunoGem;
        /// <summary>
        /// Cargo libera o desenvolvimento AlunoGEM? Ou seja, permite o cargo a participar do GEM
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "AlunoGem")]
        public bool AlunoGem
        {
            get
            {
                if ("Sim".Equals(alunoGem))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    alunoGem = "Sim";
                else
                    alunoGem = "Não";
            }
        }

        private string ensaio;
        /// <summary>
        /// Cargo libera o desenvolvimento Ensaio?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "Ensaio")]
        public bool Ensaio
        {
            get
            {
                if ("Sim".Equals(ensaio))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    ensaio = "Sim";
                else
                    ensaio = "Não";
            }
        }

        private string meiaHora;
        /// <summary>
        /// Cargo libera o desenvolvimento Meia Hora?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "MeiaHora")]
        public bool MeiaHora
        {
            get
            {
                if ("Sim".Equals(meiaHora))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    meiaHora = "Sim";
                else
                    meiaHora = "Não";
            }
        }

        private string rjm;
        /// <summary>
        /// Cargo libera o desenvolvimento Reunião de Jovens?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "Rjm")]
        public bool Rjm
        {
            get
            {
                if ("Sim".Equals(rjm))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    rjm = "Sim";
                else
                    rjm = "Não";
            }
        }

        private string culto;
        /// <summary>
        /// Cargo libera o desenvolvimento CUlto Oficial?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "Culto")]
        public bool Culto
        {
            get
            {
                if ("Sim".Equals(culto))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    culto = "Sim";
                else
                    culto = "Não";
            }
        }

        private string oficial;
        /// <summary>
        /// Cargo libera o desenvolvimento Oficialização?
        /// <para>'Sim' OR 'Não' - Tipo de Dados na Tabela: varchar(3)</para>
        /// </summary>
        [Display(Name = "Oficial")]
        public bool Oficial
        {
            get
            {
                if ("Sim".Equals(oficial))
                    return true;
                return false;
            }
            set
            {
                if (true.Equals(value))
                    oficial = "Sim";
                else
                    oficial = "Não";
            }
        }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoCargo
    {
        private MOD_acessoCargo() { }

        private static readonly int progCargo = 8;
        public static int ProgCargo
        {
            get
            {
                return progCargo;
            }
        }

        private static readonly int rotInsCargo = 22;
        public static int RotInsCargo
        {
            get
            {
                return rotInsCargo;
            }
        }

        private static readonly int rotEditCargo = 23;
        public static int RotEditCargo
        {
            get
            {
                return rotEditCargo;
            }
        }

        private static readonly int rotExcCargo = 24;
        public static int RotExcCargo
        {
            get
            {
                return rotExcCargo;
            }
        }

        private static readonly int rotVisCargo = 25;
        public static int RotVisCargo
        {
            get
            {
                return rotVisCargo;
            }
        }
    }
}