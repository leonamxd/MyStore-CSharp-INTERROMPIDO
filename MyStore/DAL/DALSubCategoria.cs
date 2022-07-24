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
    public class DALSubCategoria
    {
        private DALConexao conexao;

        public DALSubCategoria(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloSubCategoria _modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao._conexao;
                cmd.CommandText = "Insert into subcategoria(cat_cod, scat_nome)" +
                    " values(@catcod, @nome) select @@IDENTITY;";
                cmd.Parameters.AddWithValue("@catcod", _modelo.FK_Cat_cod);
                cmd.Parameters.AddWithValue("@nome", _modelo.Scat_nome);
                conexao.Conectar();
                _modelo.Scat_cod = Convert.ToInt32(cmd.ExecuteScalar());
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

        public void Alterar(ModeloSubCategoria _modelo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao._conexao;
                cmd.CommandText = "update subcategoria set " +
                    "scat_nome = @nome," +
                    " cat_cod = @catcod " +
                    "where scat_cod = @scatcod";
                cmd.Parameters.AddWithValue("@nome", _modelo.Scat_nome);
                cmd.Parameters.AddWithValue("@catcod", _modelo.FK_Cat_cod);
                cmd.Parameters.AddWithValue("@scatcod", _modelo.Scat_cod);
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
                cmd.CommandText = "delete from subcategoria where scat_cod = @scodigo";
                cmd.Parameters.AddWithValue("@scodigo", _codigo);
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
            SqlDataAdapter da = new SqlDataAdapter("Select " +
                "sc.scat_cod, sc.scat_nome, sc.cat_cod, c.cat_nome " +
                "from subcategoria sc inner join categoria c " +
                "on sc.cat_cod = c.cat_cod " +
                "where scat_nome like '%" + _value + "%'",
                conexao._StringConexao);
            da.Fill(tabela);
            return tabela;
        }
        public DataTable LocalizarPorCategoria(int _categoria)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select " +
                "sc.scat_cod, sc.scat_nome, sc.cat_cod, c.cat_nome " +
                "from subcategoria sc inner join categoria c " +
                "on sc.cat_cod = c.cat_cod " +
                "where sc.cat_cod = " + _categoria.ToString(),
                conexao._StringConexao);
            sqlDataAdapter.Fill(dt);
            return dt;
        }
        public ModeloSubCategoria CarregaModeloSubCategoria(int _codigo)
        {
            ModeloSubCategoria modelo = new ModeloSubCategoria();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao._conexao;
            cmd.CommandText = "select * from subcategoria " +
                "where scat_cod = @scodigo";
            cmd.Parameters.AddWithValue("@scodigo", _codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                modelo.FK_Cat_cod = Convert.ToInt32(registro["cat_cod"]);
                modelo.Scat_nome = Convert.ToString(registro["scat_nome"]);
                modelo.Scat_cod = Convert.ToInt32(registro["scat_cod"]);
            }
            conexao.Desconectar();
            return modelo;
        }
    }
}
