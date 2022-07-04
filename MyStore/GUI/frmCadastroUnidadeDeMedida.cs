using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using BLL;
using Modelo;

namespace GUI
{
    public partial class frmCadastroUnidadeDeMedida : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroUnidadeDeMedida()
        {
            InitializeComponent();
        }

        private void LimpaTela()
        {
            txtCod.Clear();
            txtUnidadeDeMedida.Clear();
        }
        private void frmCadastroUnidadeDeMedida_Load(object sender, EventArgs e)
        {
            alterarBotoes(1);
        }

        private void btInserir_Click_1(object sender, EventArgs e)
        {
            operacao = "inserir";
            alterarBotoes(2);
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
                DialogResult d = MessageBox.Show("Deseja excluir o registro?", "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString().Equals("Yes"))
                {
                    DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                    BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);
                    bll.Excluir(Convert.ToInt32(txtCod.Text));
                    LimpaTela();
                    alterarBotoes(1);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Impossivel excluir o registro. \n O registro está sendo ultilizado em outro local.");
                alterarBotoes(3);
            }
        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Leitura dos Dados
                ModeloUnidadeDeMedida modelo = new ModeloUnidadeDeMedida();
                modelo.Umed_nome = txtUnidadeDeMedida.Text;

                //Objeto para gravar os dadaos no banco
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);

                if (operacao.Equals("inserir"))
                {
                    //Cadastrar uma Categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro Efetuado: Código "
                        + modelo.Umed_cod.ToString());
                }
                else
                {
                    //Alterar uma Categoria
                    modelo.Umed_cod = Convert.ToInt32(txtCod.Text);
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

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            LimpaTela();
            alterarBotoes(1);
        }

        private void btLocalizar_Click_1(object sender, EventArgs e)
        {

            frmConsultaUnidadeDeMedida f = new frmConsultaUnidadeDeMedida();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);

                ModeloUnidadeDeMedida modelo = bll.CarregaModeloUnidadeDeMedida(f.codigo);
                txtCod.Text = modelo.Umed_cod.ToString();
                txtUnidadeDeMedida.Text = modelo.Umed_nome;
                alterarBotoes(3);
            }
            else
            {
                LimpaTela();
                alterarBotoes(1);
            }
            f.Dispose();

        }

        private void txtUnidadeDeMedida_Leave(object sender, EventArgs e)
        {
            if (operacao.Equals("inserir"))
            {
                int aux = 0;
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLUnidadeDeMedida bll = new BLLUnidadeDeMedida(cx);

                aux = bll.VerificaUnidadeDeMedida(txtUnidadeDeMedida.Text);

                if (aux > 0)
                {
                    DialogResult d = MessageBox.Show("Valor de registro ja existente!\nDeseja alterar o registro?", "Aviso", MessageBoxButtons.YesNo);
                    if (d.ToString().Equals("Yes"))
                    {
                        operacao = "alterar";

                        ModeloUnidadeDeMedida modelo = bll.CarregaModeloUnidadeDeMedida(aux);
                        txtCod.Text = modelo.Umed_cod.ToString();
                        txtUnidadeDeMedida.Text = modelo.Umed_nome;
                    }
                    else
                    {
                        LimpaTela();
                        alterarBotoes(1);
                    }
                }
            }
        }
    }
}
