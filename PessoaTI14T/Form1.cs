using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PessoaTI14T
{
    public partial class Form1 : Form
    {
        DAOPessoa formulario;
        public Form1()
        {
            InitializeComponent();

            formulario = new DAOPessoa(); // ABRINDO A CONEXAO COM O BD \\
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            try 
            {
                // int codigo = Convert.ToInt32(textBox1.Text);
                  string tratamentoCPF = maskedTextBox1.Text.Replace(",", "");
                  tratamentoCPF.Replace("-", "");                
                  long cpf = Convert.ToInt64(tratamentoCPF);
                  string nome = textBox3.Text;
                  string telefone = maskedTextBox2.Text;
                  string endereco = textBox2.Text;
                  formulario.Inserir(cpf, nome, telefone, endereco);
            }
            catch(Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        } // FIM DO BOTAO CADASTRAR \\

        private void Consultar_Click(object sender, EventArgs e)
        {


        } // FIM DO BOTAO CONSULTAR \\

        private void Atualizar_Click(object sender, EventArgs e)
        {


        }// FIM DO BOTAO ATUALIZAR \\



        private void Excluir_Click(object sender, EventArgs e)
        {


        }// FIM DO BOTAO EXCLUIR \\

        
        //----------------------------------------------------------------------------------------------------------------------------------------\\

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        } // TEXT BOX DE CODIGO \\

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


        } //  MASCKED TEXT BOX DE CPF \\

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


        } // TEXT BOX DE NOME \\

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


        } // MASCKED TEXT BOX DE TELEFONE \\

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


        } // TEXT BOX DE ENDEREÇO \\
    } // FIM DA CLASSE \\
} // FIM DO PROJETO \\
