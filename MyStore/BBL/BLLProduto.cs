using DAL;
using Modelo;
using System;
using System.Data;
// ReSharper disable All

namespace BLL
{
    public class BLLProduto
    {
        public DALConexao conexao { get; set; }

        public BLLProduto(DALConexao cx)
        {
            conexao = cx;
        }

        public void Incluir(ModeloProduto _modelo)
        {
            if (_modelo.Pro_nome.Trim().Length == 0)
            {
                throw new Exception("Nome Obrigatório");
            }
            if (_modelo.Pro_descricao.Trim().Length == 0)
            {
                throw new Exception("Descrição Obrigatória");
            }
            if (_modelo.Pro_valorVenda <= 0)
            {
                throw new Exception("Valor Obrigatório");
            }
            if (_modelo.Pro_quantidade < 0)
            {
                throw new Exception("Informar quantidade maior ou igual a zero");
            }
            if (_modelo.Umed_cod <= 0)
            {
                throw new Exception("O codigo é Obrigatório");
            }
            if (_modelo.Cat_cod <= 0)
            {
                throw new Exception("O codigo é Obrigatório");
            }
            if (_modelo.Scat_cod <= 0)
            {
                throw new Exception("O codigo é Obrigatório");
            }
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Incluir(_modelo);
        }

        public void Alterar(ModeloProduto _modelo)
        {
            if (_modelo.Pro_cod <= 0)
            {
                throw new Exception("Codigo Obrigatório");
            }
            if (_modelo.Pro_nome.Trim().Length == 0)
            {
                throw new Exception("Nome Obrigatório");
            }
            if (_modelo.Pro_descricao.Trim().Length == 0)
            {
                throw new Exception("Descrição Obrigatória");
            }
            if (_modelo.Pro_valorVenda <= 0)
            {
                throw new Exception("Valor Obrigatório");
            }
            if (_modelo.Pro_quantidade < 0)
            {
                throw new Exception("Informar quantidade maior ou igual a zero");
            }
            if (_modelo.Umed_cod <= 0)
            {
                throw new Exception("O codigo é Obrigatório");
            }
            if (_modelo.Cat_cod <= 0)
            {
                throw new Exception("O codigo é Obrigatório");
            }
            if (_modelo.Scat_cod <= 0)
            {
                throw new Exception("O codigo é Obrigatório");
            }
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(_modelo);
        }

        public void Excluir(int _codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Excluir(_codigo);
        }

        public DataTable Localizar(String _value)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.Localizar(_value);
        }

        public ModeloProduto CarregaModeloProduto(int _codigo)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(_codigo);
        }
    }
}