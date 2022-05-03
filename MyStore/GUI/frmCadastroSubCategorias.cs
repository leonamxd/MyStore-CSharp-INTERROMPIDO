using BLL;
using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroSubCategorias : GUI.frmModeloDeFormularioDeCadastro
    {
        public frmCadastroSubCategorias()
        {
            InitializeComponent();
        }

        public void LimpaTela()
        {
            txtScatNome.Clear();
            txtScatCod.Clear();
        }

        private void frmCadastroSubCategorias_Load(object sender, EventArgs e)
        {
            alterarBotoes(1);
            DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
            BLLCategoria bll = new BLLCategoria(cx);
            cbCatCod.DataSource = bll.Localizar("");
            cbCatCod.DisplayMember = "cat_nome";
            cbCatCod.ValueMember = "cat_cod";
        }

        private void btInserir_Click_1(object sender, EventArgs e)
        {
            alterarBotoes(2);
            operacao = "inserir";
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            alterarBotoes(1);
            LimpaTela();
        }

        private void btAlterar_Click_1(object sender, EventArgs e)
        {
            alterarBotoes(2);
            operacao = "alterar";
        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Leitura dos Dados
                ModeloSubCategoria modelo = new ModeloSubCategoria();
                modelo.Scat_nome = txtScatNome.Text;
                modelo.FK_Cat_cod = Convert.ToInt32(cbCatCod.SelectedValue);

                //Objeto para gravar os dadaos no banco
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLSubCategoria bll = new BLLSubCategoria(cx);

                if (operacao.Equals("inserir"))
                {
                    //Cadastrar uma Categoria
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro Efetuado: Código "
                        + modelo.Scat_cod.ToString());
                }
                else
                {
                    //Alterar uma Categoria
                    modelo.Scat_cod = Convert.ToInt32(txtScatCod.Text);
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

        private void btExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Deseja excluir o registro?",
                    "Aviso", MessageBoxButtons.YesNo);
                if (d.ToString().Equals("Yes"))
                {
                    DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                    BLLSubCategoria bll = new BLLSubCategoria(cx);
                    bll.Excluir(Convert.ToInt32(txtScatCod.Text));
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
            
            frmConsultaSubCategoria f = new frmConsultaSubCategoria();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLSubCategoria bll = new BLLSubCategoria(cx);

                ModeloSubCategoria modelo = bll.CarregaModeloSubCategoria(f.codigo);
                txtScatCod.Text = modelo.Scat_cod.ToString();
                txtScatNome.Text = modelo.Scat_nome;
                cbCatCod.SelectedValue = modelo.FK_Cat_cod;
                alterarBotoes(3);
            }
            else
            {
                LimpaTela();
                alterarBotoes(1);
            }
            f.Dispose();
        }
    }
}
