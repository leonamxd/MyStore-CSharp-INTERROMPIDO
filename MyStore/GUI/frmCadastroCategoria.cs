using System;
using Modelo;
using DAL;
using BBL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroCategoria : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroCategoria()
        {
            InitializeComponent();
        }

        private void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }

        private void frmCadastroCategoria_Load(object sender, EventArgs e)
        {
            alterarBotoes(1);
        }

        private void btInserir_Click_1(object sender, EventArgs e)
        {
            operacao = "inserir";
            alterarBotoes(2);
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            LimpaTela();
            alterarBotoes(1);
        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Leitura dos Dados
                ModeloCategoria modelo = new ModeloCategoria();
                modelo.Cat_nome = txtNome.Text;

                //Objeto para gravar os dadaos no banco
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLCategoria bll = new BLLCategoria(cx);

                if (operacao.Equals("inserir"))
                {
                    //Cadastrar uma Categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro Efetuado: Código " 
                        + modelo.Cat_cod.ToString());
                }
                else
                {
                    //Alterar uma Categoria
                    modelo.Cat_cod = Convert.ToInt32(txtCodigo.Text);
                    bll.Alterar(modelo);
                    MessageBox.Show("Cadastro Alterado");
                }
                LimpaTela();
                alterarBotoes(1);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            
        }

        private void btAlterar_Click_1(object sender, EventArgs e)
        {
            operacao = "alterar";
            alterarBotoes(2);
        }

        private void btExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Desejja excluir o registro?",
                    "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString().Equals("Yes"))
                {
                    DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                    BLLCategoria bll = new BLLCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtCodigo.Text));
                    LimpaTela();
                    alterarBotoes(1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossivel excluir o registro." +
                    "\n O registro está sendo ultilizado em outro local.");
                alterarBotoes(3);
            }
        }

        private void btLocalizar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
