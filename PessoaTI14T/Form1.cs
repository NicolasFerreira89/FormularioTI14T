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
            textBox1.Text = Convert.ToString(formulario.ConsultarCodigo() + 1);
            textBox1.ReadOnly = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Limpar()
        {
            textBox1.Text = "" + formulario.ConsultarCodigo();
            maskedTextBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox2.Text = "";
        }

        public void AtivarCampos()
        {
                textBox1.ReadOnly = false; // CODIGO \\
                maskedTextBox1.ReadOnly = true; // CPF \\
                textBox2.ReadOnly = true; // NOME \\
                maskedTextBox2.ReadOnly = true; // TELEFONE \\
                textBox3.ReadOnly = true; // ENDEREÇO \\
        }
        public void InativarCampos()
        {
            textBox1.ReadOnly = true; // CODIGO \\
            maskedTextBox1.ReadOnly = false; // CPF \\
            textBox2.ReadOnly = false; // NOME \\
            maskedTextBox2.ReadOnly = false; // TELEFONE \\
            textBox3.ReadOnly = false; // ENDEREÇO \\
        }

        public void AtivarTodosCampos()
        {
            textBox1.ReadOnly = false; // CODIGO \\
            maskedTextBox1.ReadOnly = false; // CPF \\
            textBox2.ReadOnly = false; // NOME \\
            maskedTextBox2.ReadOnly = false; // TELEFONE \\
            textBox3.ReadOnly = false; // ENDEREÇO \\
        }

        private void Cadastrar_Click(object sender, EventArgs e)
        {
            try 
            {
                if(textBox1.ReadOnly == false)
                {
                    Limpar();
                    InativarCampos();
                }

                else 
                { 
                    long cpf = TratarCPF(maskedTextBox1.Text);
                    string nome = textBox3.Text;
                    string telefone = maskedTextBox2.Text;
                    string endereco = textBox2.Text;
                    formulario.Inserir(cpf, nome, telefone, endereco);
                    Limpar(); // LIMPA OS CAMPOS \\
                }            
            }
            catch(Exception erro)
            {
                MessageBox.Show("" + erro);
            }
        } // FIM DO BOTAO CADASTRAR \\

        public long TratarCPF(string cpf)
        {
            string tratamento = cpf.Replace(",", "");
            tratamento = tratamento.Replace("-", "");
            return Convert.ToInt64(tratamento);
        }

        private void Consultar_Click(object sender, EventArgs e)
        {
            if(textBox1.ReadOnly == true)
            {
                AtivarCampos();
            }

            else
            {
                maskedTextBox1.Text = "" + formulario.ConsultarCPF(Convert.ToInt32(textBox1.Text)); // PREENCHENDO O CAMPO CPF \\
                textBox3.Text = formulario.ConsultarNome(Convert.ToInt32(textBox1.Text));
                maskedTextBox2.Text = formulario.ConsultarTelefone(Convert.ToInt32(textBox1.Text));
                textBox2.Text = formulario.ConsultarEndereco(Convert.ToInt32(textBox1.Text));
            }
        } // FIM DO BOTAO CONSULTAR \\

        private void Atualizar_Click(object sender, EventArgs e)
        {
            AtivarTodosCampos();

            if(textBox3.Text == "") 
            { 
                maskedTextBox1.Text = "" + formulario.ConsultarCPF(Convert.ToInt32(textBox1.Text)); 
                textBox3.Text = formulario.ConsultarNome(Convert.ToInt32(textBox1.Text));
                maskedTextBox2.Text = formulario.ConsultarTelefone(Convert.ToInt32(textBox1.Text));
                textBox2.Text = formulario.ConsultarEndereco(Convert.ToInt32(textBox1.Text));
            }

            else
            {
                                        // ATUALIZAR DADOS \\
               string atuCPF = formulario.Atualizar(Convert.ToInt32(textBox1.Text), "CPF", TratarCPF(maskedTextBox1.Text));
               string atuNome = formulario.Atualizar(Convert.ToInt32(textBox1.Text), "nome", textBox3.Text);
               string atuTelefone = formulario.Atualizar(Convert.ToInt32(textBox1.Text), "telefone", maskedTextBox2.Text);
               string atuEndereco = formulario.Atualizar(Convert.ToInt32(textBox1.Text), "endereco", textBox2.Text);

                if((atuCPF == "Atualizado!") && (atuNome == "Atualizado!") && (atuTelefone == "Atualizado!") && (atuEndereco == "Atualizado!"))
                {
                    MessageBox.Show("Atualizado com Sucesso!");
                }

                else
                {
                    MessageBox.Show("Não Atualizado!");
                }

               Limpar();

            }
            
        }// FIM DO BOTAO ATUALIZAR \\

        private void Excluir_Click(object sender, EventArgs e)
        {
            AtivarCampos();

            formulario.Deletar(Convert.ToInt32(textBox1.Text));

            Limpar();

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
