using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using ENT.Log;
using ENT.pessoa;

namespace ENT.acessos
{
    public class MOD_usuario
    {
        public string CodUsuario { get; set; }
        public string CodPessoa { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string DataAlteraSenha { get; set; }
        public string DataCadastro { get; set; }
        public string Supervisor { get; set; }
        public string Ativo { get; set; }
        public string AlteraSenha { get; set; }

        public MOD_log Logs { get; set; }
        public List<MOD_usuarioCargo> listaUsuarioCargo { get; set; }
        public BindingList<MOD_usuarioCCB> listaUsuarioCCB { get; set; }
        public BindingList<MOD_usuarioRegiao> listaUsuarioRegiao { get; set; }
        public List<MOD_acessos> listaAcesso { get; set; }
        public List<MOD_acessos> listaAcessoDelete { get; set; }
        public List<MOD_rotinas> listaRotinas { get; set; }
        public List<MOD_pessoa> listaPessoa { get; set; }
    }

    public class MOD_acessoUsuario
    {
        public int progUsuario { get; set; } = 29;
        public int rotInsUsuario { get; set; } = 147;
        public int rotEditUsuario { get; set; } = 148;
        public int rotExcUsuario { get; set; } = 149;
        public int rotVisUsuario { get; set; } = 150;
        public int rotSenhaUsuario { get; set; } = 151;
        public int rotLibAcessoUsuario { get; set; } = 152;
        public int rotSupUsuario { get; set; } = 153;
        public int rotSolAlteraSenha { get; set; } = 154;
        public int rotUsuAcessoCargo = 158;
        public int rotUsuAcessoCCB { get; set; } = 159;
    }
}