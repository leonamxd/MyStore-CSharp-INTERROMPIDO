using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModuloProduto
    {
        public int Pro_cod { get; set; }
        public String Pro_nome { get; set; }
        public String Pro_descricao { get; set; }
        public byte[] Pro_foto { get; set; }
        public Double Pro_valorPago { get; set; }
        public Double Pro_valorVenda { get; set; }
        public int Pro_quantidade { get; set; }
        public int Umed_cod { get; set; }
        public int Cat_cod { get; set; }
        public int Scat_cod { get; set; }

        public ModuloProduto()
        {
            Pro_cod = 0;
            Pro_nome = "";
            Pro_descricao = "";
            Pro_valorPago = 0;
            Pro_valorVenda = 0;
            Umed_cod = 0;
            Cat_cod = 0;
            Scat_cod = 0;
        }

        public ModuloProduto(int pro_cod, string pro_nome, string pro_descricao,
            string pro_foto, double pro_valorPago, double pro_valorVenda,
            int pro_quantidade, int umed_cod, int cat_cod, int scat_cod)
        {
            Pro_cod = pro_cod;
            Pro_nome = pro_nome;
            Pro_descricao = pro_descricao;
            CarregaImagem(pro_foto);
            Pro_valorPago = pro_valorPago;
            Pro_valorVenda = pro_valorVenda;
            Pro_quantidade = pro_quantidade;
            Umed_cod = umed_cod;
            Cat_cod = cat_cod;
            Scat_cod = scat_cod;
        }

        public ModuloProduto(int pro_cod, string pro_nome, string pro_descricao,
           Byte[] pro_foto, double pro_valorPago, double pro_valorVenda,
           int pro_quantidade, int umed_cod, int cat_cod, int scat_cod)
        {
            Pro_cod = pro_cod;
            Pro_nome = pro_nome;
            Pro_descricao = pro_descricao;
            Pro_foto = pro_foto;
            Pro_valorPago = pro_valorPago;
            Pro_valorVenda = pro_valorVenda;
            Pro_quantidade = pro_quantidade;
            Umed_cod = umed_cod;
            Cat_cod = cat_cod;
            Scat_cod = scat_cod;
        }

        public void CarregaImagem(String _imgCaminho)
        {
            try
            {
                if (string.IsNullOrEmpty(_imgCaminho))
                {
                    FileInfo arqImagem = new FileInfo(_imgCaminho);

                    FileStream fs = new FileStream(_imgCaminho, FileMode.Open, FileAccess.Read, FileShare.Read);

                    Pro_foto = new byte[Convert.ToInt32(arqImagem.Length)];

                    int iBytesRead = fs.Read(Pro_foto, 0, Convert.ToInt32(arqImagem.Length));
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
