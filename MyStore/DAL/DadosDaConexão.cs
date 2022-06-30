using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexão
    {
        public static String StringDeConexao
        {
            get
            {
                return "Data Source=DESKTOP-PP47R87\\SQLEXPRESS;Initial Catalog=MyStore;User ID=sa;Password=321300Xd";
            }
        }

        /*public static String StringDeConexao
        {
            get
            {
                return "Data Source=DESKTOP-UMKT0NL;" +
                    "Initial Catalog=MyStore;User ID=sa;" +
                    "Password=321300Xd";
            }
        }*/
    }
}
