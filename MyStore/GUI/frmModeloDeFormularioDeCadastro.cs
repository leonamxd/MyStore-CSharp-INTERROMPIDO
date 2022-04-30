using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmModeloDeFormularioDeCadastro : Form
    {

        public String operacao { get; set; }

        public void alterarBotoes(int _op)
        {
            /*
             * op = Operações que serão feitas com os botoes
             * 01 = Preparar os botoes para inserir e localizar
             * 02 = Preparar os botoes para inserir/alterar um registro
             * 03 = Preparar a tela para excluir ou alterar
             */

            pnDados.Enabled = false;
            btInserir.Enabled = false;
            btAlterar.Enabled = false;
            btLocalizar.Enabled = false;
            btExcluir.Enabled = false;
            btCancelar.Enabled = false;
            btSalvar.Enabled = false;

            switch (_op)
            {
                case 1:
                    btInserir.Enabled = true;
                    btLocalizar.Enabled = true;
                    break;

                case 2:
                    pnDados.Enabled = true;
                    btSalvar.Enabled = true;
                    btCancelar.Enabled = true;
                    break;

                case 3:
                    btAlterar.Enabled = true;
                    btExcluir.Enabled = true;
                    btCancelar.Enabled = true;
                    break;

                default:
                    break;
            }
        } 
        public frmModeloDeFormularioDeCadastro()
        {
            InitializeComponent();
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {

        }

        protected void btLocalizar_Click(object sender, EventArgs e)
        {

        }

        protected void btAlterar_Click(object sender, EventArgs e)
        {

        }

        protected void btExcluir_Click(object sender, EventArgs e)
        {

        }

        protected void btSalvar_Click(object sender, EventArgs e)
        {

        }

        protected void btInserir_Click(object sender, EventArgs e)
        {

        }

        protected void frmModeloDeFormularioDeCadastro_Load(object sender, EventArgs e)
        {
            
        }

        protected void pnBotoes_Paint(object sender, PaintEventArgs e)
        {

        }

        protected void pnDados_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
