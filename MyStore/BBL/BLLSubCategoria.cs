using System;
using DAL;
using Modelo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BLL
{
    public class BLLSubCategoria
    {
        public DALConexao conexao { get; set; }

        public BLLSubCategoria(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloSubCategoria _modelo)
        {
            if (_modelo.Scat_nome.Trim().Length == 0)
            {
                throw new Exception("Nome obrigatório");
            }
            if (_modelo.FK_Cat_cod <= 0)
            {
                throw new Exception("Código da Categoria é obrigatório");
            }
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(_modelo);
        }

        public void Alterar(ModeloSubCategoria _modelo)
        {
            if (_modelo.Scat_nome.Trim().Length == 0)
            {
                throw new Exception("Nome obrigatório");
            }
            if (_modelo.FK_Cat_cod <= 0)
            {
                throw new Exception("Código da Categoria é obrigatório");
            }
            if (_modelo.Scat_cod <= 0)
            {
                throw new Exception("Código da SubCategoria é obrigatório");
            }
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(_modelo);
        }

        public void Excluir(int _codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(_codigo);
        }

        public DataTable Localizar(String _value)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(_value);
        }

        public DataTable LocalizarPorCategoria(int _categoria)
        {
            DALSubCategoria Dalobj = new DALSubCategoria(conexao);
            return Dalobj.LocalizarPorCategoria(_categoria);
        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int _codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(_codigo);
        }
    }
}
