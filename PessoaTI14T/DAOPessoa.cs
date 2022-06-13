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
        // vV--VETORES--Vv \\
        public int[] vetorCodigo;
        public long[] vetorCPF;
        public string[] vetorNome;
        public string[] vetorTelefone;
        public string[] vetorEndereco;
        public int contador;
        public int i;
        public string msg;
        public int contarCodigo;
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
                comando = "insert into Formulario(codigo, cpf, nome, telefone, endereco) values  " + dados;
                MySqlCommand sql = new MySqlCommand(comando, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + "Linha Afetada.");
            }
            catch(Exception erro)
            {
                MessageBox.Show("Algo deu Errado!\n\n" + erro);
            }
        } // FIM DO METODO INSERIR \\

        public void PreencherVetor()
        {
            string query = "select * from Formulario";

            vetorCodigo = new int[100];
            vetorCPF = new long[100];
            vetorNome = new string[100];
            vetorTelefone = new string[100];
            vetorEndereco = new string[100];

            for(i= 0; i < 100; i++)
            {
                vetorCodigo[i] = 0;
                vetorCPF[i] = 0;
                vetorNome[i] = "";
                vetorTelefone[i]  = "";
                vetorEndereco[i] = "";

            } // FIM DO FOR \\

            MySqlCommand coletar = new MySqlCommand(query, conexao);
            MySqlDataReader leitura = coletar.ExecuteReader();

            i = 0; // DECLARAÇAO DO CONTADOR 0 \\
            contador = 0;
            contarCodigo = 0;
            while (leitura.Read())
            {
                vetorCodigo[i] = Convert.ToInt32(leitura["codigo"]); // ENQUANTO FOR VERDADEIRO EXECUTA OQUE ESTA NO WHILE \\
                vetorCPF[i] = Convert.ToInt64(leitura["cpf"]);
                vetorNome[i] = leitura["nome"] + "";
                vetorTelefone[i] = leitura["telefone"] + "";
                vetorEndereco[i] = leitura["endereco"] + "";
                contarCodigo = contador; // ARMAZENANDO A ULTIMA POSIÇAO DO CONTADOR \\
                i++;
                contador++;
            }

            leitura.Close(); // FECHAR A  CONEXAO E A LEITURA DO BD \\
        } // FIM DO PREENCHER VETOR \\

        public string ConsultarTudo()
        {
            PreencherVetor();
            msg += "";
            for(i= 0; i < contador; i++)
            {
                msg = "Código: " + vetorCodigo[i] +
                      "CPF: " + vetorCPF[i] +
                      "Nome: " + vetorNome[i] +
                      "Telefone: " + vetorTelefone[i] +
                      "Endereço: " + vetorEndereco[i] +
                      "\n\n";
            }

            return msg; // RETORNA OS DADOS ARMAZENADOS NA "msg" \\
        } // FIM DO CONSULTAR TUDO \\

        public long ConsultarCPF(int cod)
        {
            PreencherVetor();

            for(i = 0; i < contador; i++)
            {
                if (vetorCodigo[i] == cod)
                {
                    return vetorCPF[i];
                }
            }

            return -1;

        }
        // FIM DO CONSULTAR CPF \\

        public int ConsultarCodigo()
        {
            PreencherVetor();
            return vetorCodigo[contarCodigo];

        } // FIM DO CONSULTAR CODIGO \\

        public string ConsultarNome(int cod)
        {
            PreencherVetor();

            for( i = 0; i < contador; i++)
            {
                if(vetorCodigo[i] == cod)
                {
                    return vetorNome[i];
                }
            }

            return "Nome não encontrado.";

        } // FIM DO CONSULTAR NOME \\

        public string ConsultarTelefone(int cod)
        {
            PreencherVetor();
            for(i = 0; i < contador; i++)
            {
                if(vetorCodigo[i] == cod)
                {
                    return vetorTelefone[i];
                }
            }

            return "Telefone não encontrado.";

        }

        public string ConsultarEndereco(int cod)
        {
            PreencherVetor();
            for(i = 0; i < contador; i++)
            {
                if(vetorCodigo[i] == cod)
                {
                    return vetorEndereco[i];
                } 
            }

            return "Endereço não encontrado.";

        }

        public void Atualizar(int cod, string campo, string novoDado)
        {
            try
            {
                string query = "update Formulario set " + campo + " = '" + novoDado + "' where codigo = '" + cod + "'";

                MySqlCommand sql  = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + "Linha Afetada.");
            }
            catch(Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        }

        public void Deletar(int cod)
        {
            try
            {
                string query = "delete from Formulario where codigo = '" + cod + "'";
                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + "Linha Afetada.");
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        }

        public void Atualizar(int cod, string campo, long novoDado)
        {
            try
            {
                string query = "update Formulario set " + campo + " = '" + novoDado + "' where codigo = '" + cod + "'";

                MySqlCommand sql = new MySqlCommand(query, conexao);
                string resultado = "" + sql.ExecuteNonQuery();
                MessageBox.Show(resultado + "Linha Afetada.");
            }
            catch (Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        }
    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
