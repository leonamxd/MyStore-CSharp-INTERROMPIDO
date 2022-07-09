using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCadastroProduto : GUI.frmModeloDeFormularioDeCadastro
    {
        public String foto = "";
        public frmCadastroProduto()
        {
            InitializeComponent();
        }

        private void btInserir_Click_1(object sender, EventArgs e)
        {
            operacao = "inserir";
            alterarBotoes(2);
        }

        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {
            alterarBotoes(1);
        }
    }
}
