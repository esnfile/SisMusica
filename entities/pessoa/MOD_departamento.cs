using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_departamento
    {
        private string codDepartamento;
        /// <summary>
        /// (ID) Código do Departamento
        /// </summary>
        [Key]
        [DisplayName("Código")]
        [DataObjectField(true, true, true)]
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
        /// Descrição do Departamento
        /// <para>Tipo de Dados na Tabela: varchar(30)</para>
        /// </summary>
        [Required(ErrorMessage = "Descrição do Departamento! Campo obrigatório.")]
        [StringLength(30, ErrorMessage = "Esse campo suporta no máximo 30 caracteres.")]
        [DataType(DataType.Text)]
        [DisplayName("Departamento")]
        [DataObjectField(false, false, true)]
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

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoDepartamento
    {
        private static readonly int progDepartamento = 10;
        public static int ProgDepartamento
        {
            get
            {
                return progDepartamento;
            }
        }

        private static readonly int rotInsDepartamento = 30;
        public static int RotInsDepartamento
        {
            get
            {
                return rotInsDepartamento;
            }
        }

        private static readonly int rotEditDepartamento = 31;
        public static int RotEditDepartamento
        {
            get
            {
                return rotEditDepartamento;
            }
        }

        private static readonly int rotExcDepartamento = 32;
        public static int RotExcDepartamento
        {
            get
            {
                return rotExcDepartamento;
            }
        }

        private static readonly int rotVisDepartamento = 33;
        public static int RotVisDepartamento
        {
            get
            {
                return rotVisDepartamento;
            }
        }
    }
}