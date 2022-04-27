using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DALConexao
    {
        public String _StringConexao { get; set; }
        public SqlConnection _conexao { get; set; }

        public DALConexao(String dadosConexao)
        {
            _conexao = new SqlConnection();
            _StringConexao = dadosConexao;
            _conexao.ConnectionString = dadosConexao;
        }

        public void Conectar()
        {
            _conexao.Open();
        }

        public void Desconectar()
        {
            _conexao.Close();
        }
    }
}
