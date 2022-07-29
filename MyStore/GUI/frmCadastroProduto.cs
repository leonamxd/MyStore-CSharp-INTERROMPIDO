using BLL;
using DAL;
using Modelo;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroProduto : GUI.frmModeloDeFormularioDeCadastro
    {
        public string foto = "";

        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void LimpaTela()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtValorPago.Clear();
            txtValorVenda.Clear();
            txtQtde.Clear();
            foto = "";
            pbFoto.Image = null;
        }

        private void btInserir_Click_1(object sender, EventArgs e)
        {
            operacao = "inserir";
            alterarBotoes(2);
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            alterarBotoes(1);
            DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);

            //Combobox Categoria
            BLLCategoria bllCategoria = new BLLCategoria(cx);
            cbCategoria.DataSource = bllCategoria.Localizar("");
            cbCategoria.DisplayMember = "cat_nome";
            cbCategoria.ValueMember = "cat_cod";

            //Combobox SubCategoria
            BLLSubCategoria bLLSubCategoria = new BLLSubCategoria(cx);
            cbSubCategoria.DataSource = bLLSubCategoria.LocalizarPorCategoria((int)cbCategoria.SelectedValue);
            cbSubCategoria.DisplayMember = "scat_nome";
            cbSubCategoria.ValueMember = "scat_cod";

            //Combobox Unidade de Medida
            BLLUnidadeDeMedida bLLUnidadeDeMedida = new BLLUnidadeDeMedida(cx);
            cbUnidade.DataSource = bLLUnidadeDeMedida.Localizar("");
            cbUnidade.DisplayMember = "umed_nome";
            cbUnidade.ValueMember = "umed_cod";
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);

            try
            {
                cbSubCategoria.Text = "";

                BLLSubCategoria bLLSubCategoria = new BLLSubCategoria(cx);
                cbSubCategoria.DataSource = bLLSubCategoria.LocalizarPorCategoria((int)cbCategoria.SelectedValue);
                cbSubCategoria.DisplayMember = "scat_nome";
                cbSubCategoria.ValueMember = "scat_cod";
            }
            catch
            {
                //MessageBox.Show("Cadastre uma categoria");
            }
        }

        private void btLoadFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            if (!string.IsNullOrEmpty(od.FileName))
            {
                foto = od.FileName;
                pbFoto.Load(foto);
            }
        }

        private void btRemoveFoto_Click(object sender, EventArgs e)
        {
            foto = "";
            pbFoto.Image = null;
        }

        private void btCancelar_Click_1(object sender, EventArgs e)
        {
            alterarBotoes(1);
            LimpaTela();
        }

        private void btSalvar_Click_1(object sender, EventArgs e)
        {
            try
            {
                //Leitura dos dados
                ModeloProduto modelo = new ModeloProduto();
                modelo.Pro_nome = txtNome.Text;

                modelo.Pro_descricao = txtDescricao.Text;
                modelo.Pro_valorPago = Convert.ToDouble(txtValorPago.Text);
                modelo.Pro_valorVenda = Convert.ToDouble(txtValorVenda.Text);
                modelo.Pro_quantidade = Convert.ToInt32(txtQtde.Text);
                modelo.Umed_cod = Convert.ToInt32(cbUnidade.SelectedValue);
                modelo.Cat_cod = Convert.ToInt32(cbCategoria.SelectedValue);
                modelo.Scat_cod = Convert.ToInt32(cbSubCategoria.SelectedValue);

                //Obj para gravar os dados no branco
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLProduto bll = new BLLProduto(cx);

                if (operacao.Equals("inserir"))
                {
                    //Cadastrar um Produto
                    modelo.CarregaImagem(foto);
                    bll.Incluir(modelo);
                    MessageBox.Show("Cadastro efetuado: Código " + modelo.Pro_cod.ToString());
                }
                else
                {
                    //Alterar um Produto
                    modelo.Pro_cod = Convert.ToInt32(txtCodigo.Text);

                    if (foto.Equals("Foto Original"))
                    {
                        ModeloProduto mt = bll.CarregaModeloProduto(modelo.Pro_cod);
                        modelo.Pro_foto = mt.Pro_foto;
                    }
                    else
                    {
                        modelo.CarregaImagem(foto);
                    }
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
                    BLLProduto bll = new BLLProduto(cx);
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
            frmConsultaProduto f = new frmConsultaProduto();
            f.ShowDialog();
            if (f.codigo != 0)
            {
                DALConexao cx = new DALConexao(DadosDaConexão.StringDeConexao);
                BLLProduto bll = new BLLProduto(cx);
                ModeloProduto modelo = bll.CarregaModeloProduto(f.codigo);

                txtCodigo.Text = modelo.Pro_cod.ToString();
                txtNome.Text = modelo.Pro_nome;
                txtDescricao.Text = modelo.Pro_descricao;
                txtValorPago.Text = modelo.Pro_valorPago.ToString();
                txtValorVenda.Text = modelo.Pro_valorVenda.ToString();
                txtQtde.Text = modelo.Pro_quantidade.ToString();
                cbUnidade.SelectedValue = modelo.Umed_cod;
                cbCategoria.SelectedValue = modelo.Cat_cod;
                cbSubCategoria.SelectedValue = modelo.Scat_cod;

                try
                {
                    if (modelo.Pro_foto != null)
                    {
                        MemoryStream ms = new MemoryStream(modelo.Pro_foto);
                        pbFoto.Image = Image.FromStream(ms);
                        foto = "Foto Original";
                    }
                }
                catch
                {
                }

                alterarBotoes(3);
            }
            else
            {
                LimpaTela();
                alterarBotoes(1);
            }

            f.Dispose();
        }

        private void btAlterar_Click_1(object sender, EventArgs e)
        {
            operacao = "alterar";
            alterarBotoes(2);
        }

        /*
         *
         *
         *
         * VALIDAÇÕES \/ \/ \/ \/ \/ \/
         *
         *
         *
         */

        private void txtQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8
                                         && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorPago.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8
                                         && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == ',' || e.KeyChar == '.')
            {
                if (!txtValorVenda.Text.Contains(","))
                {
                    e.KeyChar = ',';
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            if (txtValorPago.Text.Contains(",") == false)
            {
                txtValorPago.Text += ",00";
            }
            else
            {
                if (txtValorPago.Text.IndexOf(",") == txtValorPago.Text.Length - 1)
                {
                    txtValorPago.Text += "00";
                }
            }

            try
            {
                Double d = Convert.ToDouble(txtValorPago.Text);
            }
            catch
            {
                txtValorPago.Text = "0,00";
            }
        }

        private void txtValorVenda_Leave(object sender, EventArgs e)
        {
            if (txtValorVenda.Text.Contains(",") == false)
            {
                txtValorVenda.Text += ",00";
            }
            else
            {
                if (txtValorVenda.Text.IndexOf(",") == txtValorVenda.Text.Length - 1)
                {
                    txtValorVenda.Text += "00";
                }
            }

            try
            {
                Double d = Convert.ToDouble(txtValorVenda.Text);
            }
            catch
            {
                txtValorVenda.Text = "0,00";
            }
        }
    }
}