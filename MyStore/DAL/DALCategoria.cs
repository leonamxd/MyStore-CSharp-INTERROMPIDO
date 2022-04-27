using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DALCategoria
    {
        private DALConexao conexao;

        public DALCategoria(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloCategoria _modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "Insert into categoria(cat_nome)" +
                " value (@nome) select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", _modelo.Cat_nome);
            conexao.Conectar();
            _modelo.Cat_cod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        public void Alterar(ModeloCategoria _modelo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "update categoria set cat_nome = " +
                "@nome where cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@nome", _modelo.Cat_nome);
            cmd.Parameters.AddWithValue("@codigo", _modelo.Cat_cod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public void Excluir(int _codigo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "delete from categoria where cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", _codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        public DataTable Localizar(String _value)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from categoria" +
                "where cat_nome like '%" + _value + "%'",
                conexao._StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloCategoria CarregaModeloCategoria(int _codigo)
        {
            ModeloCategoria modelo = new ModeloCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "select * from categoria " +
                "where cat_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", _codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.Cat_cod = Convert.ToInt32(registro["cat_cod"]);
                modelo.Cat_nome = Convert.ToString(registro["cat-nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
