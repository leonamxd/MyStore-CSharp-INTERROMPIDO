using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloCategoria
    {
        public int Cat_cod { get; set; }
        public String Cat_nome { get; set; }
        public ModeloCategoria()
        {
        }
        public ModeloCategoria(int cat_cod, string cat_nome)
        {
            Cat_cod = cat_cod;
            Cat_nome = cat_nome;
        }
    }
}
