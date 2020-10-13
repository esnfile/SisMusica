using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ENT.Log;

namespace ENT.pessoa
{
    public class MOD_departamento
    {
        public string CodDepartamento { get; set; }
        public string DescDepartamento { get; set; }

        public MOD_log Logs { get; set; }
    }

    public class MOD_acessoDepartamento
    {
        public int progDepartamento { get; set; } = 10;
        public int rotInsDepartamento { get; set; } = 30;
        public int rotEditDepartamento { get; set; } = 31;
        public int rotExcDepartamento { get; set; } = 32;
        public int rotVisDepartamento { get; set; } = 33;
    }
}
