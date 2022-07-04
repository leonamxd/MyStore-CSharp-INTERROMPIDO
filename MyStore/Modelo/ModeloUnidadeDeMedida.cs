using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class ModeloUnidadeDeMedida
    {
        public int Umed_cod { get; set; }
        public String Umed_nome { get; set; }

        public ModeloUnidadeDeMedida()
        {
            Umed_cod = 0;
            Umed_nome = "";
        }
        public ModeloUnidadeDeMedida(int cod, String nome)
        {
            Umed_cod = cod;
            Umed_nome = nome;
        }
    }
}
