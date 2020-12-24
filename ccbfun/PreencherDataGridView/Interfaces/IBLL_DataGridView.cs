using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BLL.Funcoes
{
    public interface IBLL_DataGridView : IDisposable
    {
        DataGridView MontarGrid(DataGridView dataGrid, string Tabela);
    }
}