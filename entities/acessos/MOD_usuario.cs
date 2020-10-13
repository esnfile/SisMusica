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
}