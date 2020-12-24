using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace DAL.Acessa
{
    public interface IConnect
    {
        //método conectar
        bool conectar();
        //método desconectar
        bool desconectar();
        //método para retorno dos dados das tabelas
        DataTable retornaDados(string objStrSql, List<SqlParameter> objParam, string objTabela);
        //método para executar os comandos CRUD
        bool executar(string objStrSql, List<SqlParameter> objParam);
        //método para retornar o último ID da tabela
        object retornarId(string objStrSql);
        //método para retorno dos dados binarios das tabelas com fotos
        SqlDataReader retornarBinary(string objStrSql, List<SqlParameter> objParam);
    }
}
