using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DadosDaConexão
    {
        public static String servidor = @"DESKTOP-PP47R87\SQLEXPRESS";
        public static String banco = "MyStore";
        public static String usuario = "sa";
        public static String senha = "321300Xd";

        public static String StringDeConexao
        {
            get
            {
                return @"Data Source=" + servidor + ";Initial Catalog=" + banco + ";User ID="+ usuario +";Password=" + senha;
            }
        }
    }
}
