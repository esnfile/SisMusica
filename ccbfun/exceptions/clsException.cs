using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Data;
using System.IO;
using ENT.Erros;

namespace BLL.Funcoes.Exceptions
{
    public class clsException : ApplicationException  //herda as propriedades da classe generica de excessões        
    {
        //excessão gerada pela aplicação
        private Exception _excep = null;
        private SqlException _excsql = null;
        private List<MOD_erros> _erros = null;

        //inicializador que instancia a classe e passa o exception como parametro
        public clsException(Exception ex)
        {
            _excep = ex;
            avalException(_excep, _excsql);
        }
        //inicializador que instancia a classe e passa o exception como parametro
        public clsException(SqlException exl)
        {
            _excsql = exl;
            avalException(_excep, _excsql);
        }

        private void avalException(Exception ex, SqlException exl)
        {
            //tratamento das excessões passadas pelo aplicativo
            //ir inserindo as mensagens de acordo que vamos descobrindo
            if ((ex is ArgumentOutOfRangeException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is ArgumentException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is FileLoadException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is FileNotFoundException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' +'\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is DirectoryNotFoundException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is OverflowException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is StackOverflowException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is InvalidCastException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is NullReferenceException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." +
                                '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((ex is InvalidOperationException))
            {
                MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if ((exl is SqlException))
            {
                if (exl.Number.Equals(137))
                {
                    MessageBox.Show("Erro de sintaxe na Base de Dados!" + '\n' + "Por favor contate o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + exl.Message + '\n' + "Erro nº: " + exl.Number, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (exl.Number.Equals(156))
                {
                    MessageBox.Show("Erro de sintaxe no SQL!" + '\n' + "Por favor contate o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + exl.Message + '\n' + "Erro nº: " + exl.Number, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (exl.Number.Equals(207))
                {
                    MessageBox.Show("Coluna não encontrada na Base de Dados!" + '\n' + "Por favor contate o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + exl.Message + '\n' + "Erro nº: " + exl.Number, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (exl.Number.Equals(208))
                {
                    MessageBox.Show("Tabela ou Consulta não encontrada na Base de Dados!" + '\n' + "Por favor contate o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + exl.Message + '\n' + "Erro nº: " + exl.Number, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (exl.Number.Equals(544))
                {
                    MessageBox.Show("Não foi possível buscar o próximo número da tabela! ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (exl.Number.Equals(547))
                {
                    MessageBox.Show("Impossivel excluir. Quebra de Integridade! ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (exl.Number.Equals(2601) || exl.Number.Equals(2627))
                {
                    MessageBox.Show("Não foi possível salvar o registro, já que criaram " + '\n' + "valores duplicados na base de dados.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("Erro desconhecido. Por favor contate " + '\n' + "o suporte técnico da Revoluction." + '\n' + '\n' + "Erro: " + exl.Message + '\n' + "Erro nº: " + exl.Number, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else
            {
                //caso não haja nenhuma das alternativas, chamo exception generico para tratar o erro
                MessageBox.Show(ex.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}