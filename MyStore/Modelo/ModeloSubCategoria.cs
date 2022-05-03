using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloSubCategoria
    {
        public int Scat_cod { get; set; }
        public int FK_Cat_cod { get; set; }
        public String Scat_nome { get; set; }

        public ModeloSubCategoria()
        {
            Scat_cod = 0;
            FK_Cat_cod = 0;
            Scat_nome = "";
        }
        public ModeloSubCategoria(int scat_cod, int fk_cat_cod, String scat_nome)
        {
            Scat_cod = scat_cod;
            FK_Cat_cod = fk_cat_cod;
            Scat_nome = scat_nome;
        }
    }
}
