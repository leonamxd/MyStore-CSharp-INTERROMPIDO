using System;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using System.Data;

namespace BBL
{
    public class BLLCategoria
    {
        public DALConexao conexao { get; set; }

        public BLLCategoria(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloCategoria _modelo)
        {
            if (_modelo .Cat_nome.Trim().Length == 0)
            {
                throw new Exception("Nome Obrigatório");
            }
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Incluir(_modelo);
        }

        public void Alterar(ModeloCategoria _modelo)
        {
            if (_modelo.Cat_cod <= 0)
            {
                throw new Exception("Codigo Obrigatório");
            }
            if (_modelo.Cat_nome.Trim().Length == 0)
            {
                throw new Exception("Nome Obrigatório");
            }
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Alterar(_modelo);
        }

        public void Excluir(int _codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            DALobj.Excluir(_codigo);
        }

        public DataTable Localizar(String _value)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.Localizar(_value);
        }

        public ModeloCategoria CarregaModeloCategoria(int _codigo)
        {
            DALCategoria DALobj = new DALCategoria(conexao);
            return DALobj.CarregaModeloCategoria(_codigo);
        }
    }
}
