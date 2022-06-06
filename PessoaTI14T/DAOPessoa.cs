using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;


namespace PessoaTI14T
{
    class DAOPessoa
    {
        MySqlConnection conexao;
        public string dados;
        public string comando;
        public string resultado;
        public DAOPessoa()
        {
            conexao = new MySqlConnection("server=localhost;DataBase=turma14;Uid=root;password=");
            try
            {
                conexao.Open(); // TENTANDO CONECTAR AO BD \\
                MessageBox.Show("Conectado com Sucesso!");
            }
            catch(Exception erro)
            {
                MessageBox.Show("Algo deu Errado!\n\n" + erro);
                conexao.Close(); // FECHANDO A CONEXAO COM O BD \\
            }
        } // FIM DAOPESSOA \\

        public void Inserir(long cpf, string nome, string telefone, string endereco)
        {
            try
            {
                dados = "('','" + cpf + "','" + nome + "','" + telefone + "','" + endereco + "')";
                comando = "Insert into Formulario(codigo, cpf, nome, telefone, endereco) values " + dados;
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + "Linha Afetada.");
            }
            catch(Exception erro)
            {
                MessageBox.Show("Algo deu Errado!\n\n" + erro);
            }
        } // FIM DO METODO INSERIR \\

    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
