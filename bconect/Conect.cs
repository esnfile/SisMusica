using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ENT.Session;

namespace BLL.conecta
{
    public sealed class Conect
    {
        private Conect()
        {
            new MOD_Session(@"Data Source=EDUARDO\SQLEXPRESS;Initial Catalog=CCB_Musica;Integrated Security=True");
        }

        private static Conect _instance;
        private static readonly object _lock = new object();

        public static Conect Conectar()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Conect();
                    }
                }
            }
            return _instance;
        }
    }
}