using Modelo;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALProduto
    {
        private DALConexao conexao;

        public DALProduto(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloProduto _obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "insert into Produto(pro_nome, pro_descricao, " +
                "pro_foto, pro_valorpago, pro_valorvenda, pro_qtde, umed_cod, " +
                "cat_cod, scat_cod) values (@nome, @descricao, @foto, @valorpago, " +
                "@valorvenda, @qtde, @undmedcod, @catcod, @scatcod); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", _obj.Pro_nome);
            cmd.Parameters.AddWithValue("@descricao", _obj.Pro_descricao);
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image);
            if (_obj.Pro_foto == null)
            {
                cmd.Parameters["@foto"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@foto"].Value = _obj.Pro_foto;
            }
            cmd.Parameters.AddWithValue("@valorpago", _obj.Pro_valorPago);
            cmd.Parameters.AddWithValue("@valorvenda", _obj.Pro_valorVenda);
            cmd.Parameters.AddWithValue("@qtde", _obj.Pro_quantidade);
            cmd.Parameters.AddWithValue("@undmedcod", _obj.Umed_cod);
            cmd.Parameters.AddWithValue("@catcod", _obj.Cat_cod);
            cmd.Parameters.AddWithValue("@scatcod", _obj.Scat_cod);

            conexao.Conectar();
            _obj.Pro_cod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Excluir(int _codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "delete from Produto where pro_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", _codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Alterar(ModeloProduto _obj)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "update Produto set pro_nome = @nome, pro_descricao = @descricao, " +
                "pro_foto = @foto, pro_valorpago = @valorpago, pro_valorvenda = @valorvenda, " +
                "pro_qtde = @qtde, umed_cod = @umedcod, cat_cod = @catcod, scat_cod = @scatcod " +
                "where pro_cod = @codigo";
            cmd.Parameters.AddWithValue("@nome", _obj.Pro_nome);
            cmd.Parameters.AddWithValue("@descricao", _obj.Pro_descricao);
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image);
            if (_obj.Pro_foto == null)
            {
                cmd.Parameters["@foto"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@foto"].Value = _obj.Pro_foto;
            }
            cmd.Parameters.AddWithValue("@valorpago", _obj.Pro_valorPago);
            cmd.Parameters.AddWithValue("@valorvenda", _obj.Pro_valorVenda);
            cmd.Parameters.AddWithValue("@qtde", _obj.Pro_quantidade);
            cmd.Parameters.AddWithValue("@umedcod", _obj.Umed_cod);
            cmd.Parameters.AddWithValue("@catcod", _obj.Cat_cod);
            cmd.Parameters.AddWithValue("@scatcod", _obj.Scat_cod);
            cmd.Parameters.AddWithValue("@codigo", _obj.Pro_cod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(String _valor)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select pro_cod, pro_nome, pro_descricao, " +
                "pro_foto, pro_valorpago, pro_valorvenda, pro_qtde, pro.umed_cod, " +
                "pro.cat_cod, pro.scat_cod, umed_nome, cat_nome, scat_nome from produto pro " +
                "inner join undmedida umd on pro.umed_cod = umd.umed_cod " +
                "inner join categoria cat on pro.cat_cod = cat.cat_cod " +
                "inner join subcategoria sct on pro.scat_cod = sct.scat_cod " +
                "where pro.pro_nome like '%" + _valor + "%'", conexao._StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloProduto CarregaModeloProduto(int _codigo)
        {
            ModeloProduto modelo = new ModeloProduto();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "select * from Produto where pro_cod = " + _codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.Pro_cod = Convert.ToInt32(registro["pro_cod"]);
                modelo.Pro_nome = Convert.ToString(registro["pro_nome"]);
                modelo.Pro_descricao = Convert.ToString(registro["pro_descricao"]);
                try
                {
                    modelo.Pro_foto = (byte[])registro["pro_foto"];
                }
                catch
                {
                }
                modelo.Pro_valorPago = Convert.ToDouble(registro["pro_valorpago"]);
                modelo.Pro_valorVenda = Convert.ToDouble(registro["pro_valorvenda"]);
                modelo.Pro_quantidade = Convert.ToInt32(registro["pro_qtde"]);
                modelo.Umed_cod = Convert.ToInt32(registro["umed_cod"]);
                modelo.Cat_cod = Convert.ToInt32(registro["cat_cod"]);
                modelo.Scat_cod = Convert.ToInt32(registro["scat_cod"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}