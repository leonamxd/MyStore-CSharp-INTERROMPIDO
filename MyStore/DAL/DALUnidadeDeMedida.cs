using System;
using Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DALUnidadeDeMedida
    {
        private DALConexao conexao;

        public DALUnidadeDeMedida(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloUnidadeDeMedida _modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao._conexao;
                cmd.CommandText = "Insert into undmedida(umed_nome)" +
                    " values(@nome) select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@nome", _modelo.Umed_nome);
                conexao.Conectar();
                _modelo.Umed_cod = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Alterar(ModeloUnidadeDeMedida _modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao._conexao;
                cmd.CommandText = "update undmedida set " +
                    "umed_nome = @nome " +
                    "where umed_cod = @cod";
                cmd.Parameters.AddWithValue("@nome", _modelo.Umed_nome);
                cmd.Parameters.AddWithValue("@cod", _modelo.Umed_cod);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public void Excluir(int _codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao._conexao;
                cmd.CommandText = "delete from undmedida where umed_cod = @codigo";
                cmd.Parameters.AddWithValue("@codigo", _codigo);
                conexao.Conectar();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new Exception("Erro na exclusão.\n" +
                    "O registro pode está sendo usado em outra tabela!");
            }
            finally
            {
                conexao.Desconectar();
            }
        }

        public DataTable Localizar(String _value)
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from undmedida " +
                "where umed_nome like '%" + _value + "%'",
                conexao._StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public int VerificaUnidadeDeMedida(String _value)
        {
            int aux = 0;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "select * from undmedida " +
                "where umed_nome = @nome";
            cmd.Parameters.AddWithValue("@nome", _value);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                aux = Convert.ToInt32(registro["umed_cod"]);
            }
            conexao.Desconectar();
            return aux;
        }


        public ModeloUnidadeDeMedida CarregaModeloUnidadeDeMedida(int _codigo)
        {
            ModeloUnidadeDeMedida modelo = new ModeloUnidadeDeMedida();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "select * from undmedida " +
                "where umed_cod = @codigo";
            cmd.Parameters.AddWithValue("@codigo", _codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.Umed_cod = Convert.ToInt32(registro["umed_cod"]);
                modelo.Umed_nome = Convert.ToString(registro["umed_nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
