using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using DAL;
using System.Data;

namespace BLL
{
    public class BLLUnidadeDeMedida
    {
        public DALConexao conexao { get; set; }

        public BLLUnidadeDeMedida(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloUnidadeDeMedida _modelo)
        {
            if (_modelo.Umed_nome.Trim().Length == 0)
            {
                throw new Exception("Nome obrigatório");
            }
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Incluir(_modelo);
        }

        public void Alterar(ModeloUnidadeDeMedida _modelo)
        {
            if (_modelo.Umed_nome.Trim().Length == 0)
            {
                throw new Exception("Nome obrigatório");
            }
            if (_modelo.Umed_cod <= 0)
            {
                throw new Exception("Código da Unidade de Medida é obrigatório");
            }
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Alterar(_modelo);
        }

        public void Excluir(int _codigo)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            DALobj.Excluir(_codigo);
        }

        public DataTable Localizar(String _value)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            return DALobj.Localizar(_value);
        }

        public int VerificaUnidadeDeMedida(String _value)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            return DALobj.VerificaUnidadeDeMedida(_value);
        }

            public ModeloUnidadeDeMedida CarregaModeloUnidadeDeMedida(int _codigo)
        {
            DALUnidadeDeMedida DALobj = new DALUnidadeDeMedida(conexao);
            return DALobj.CarregaModeloUnidadeDeMedida(_codigo);
        }
    }
}
