using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmConfiguracaoDados : Form
    {
        public frmConfiguracaoDados()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter arquivo = new StreamWriter("ConfiguracaoDados.txt", false);
                arquivo.WriteLine(txtServidor.Text);
                arquivo.WriteLine(txtDados.Text);
                arquivo.WriteLine(txtUsuario.Text);
                arquivo.WriteLine(txtSenha.Text);
                arquivo.Close();
                MessageBox.Show("Arquivo Atualizado com sucesso!!!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void frmConfiguracaoDados_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoDados.txt");
                
                txtServidor.Text = arquivo.ReadLine();
                txtDados.Text = arquivo.ReadLine();
                txtUsuario.Text = arquivo.ReadLine();
                txtSenha.Text = arquivo.ReadLine();

                arquivo.Close();

                MessageBox.Show("Arquivo Atualizado com sucesso!!!");
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btTestConnection_Click(object sender, EventArgs e)
        {
            try
            {
                DadosDaConexão.servidor = txtServidor.Text;
                DadosDaConexão.banco = txtDados.Text;
                DadosDaConexão.usuario = txtUsuario.Text;
                DadosDaConexão.senha = txtSenha.Text;

                //Tester a conexão

                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DadosDaConexão.StringDeConexao;
                conexao.Open();
                conexao.Close();

                MessageBox.Show("Conexão Efetuada");
            }
            catch (SqlException)
            {
                MessageBox.Show("Erro ao se conectar ao banco\nVerifique os dados informados");
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
