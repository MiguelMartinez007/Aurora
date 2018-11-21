using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LIBRERIA_RECO
{
    public class validaciones
    {
        static ejecuta ejec = new ejecuta();
        static private MySqlDataReader reader;

        //Funcion para validacion del login
        public static bool validarLogin(string usuario, string contrasena)
        {
            bool respuesta = false;
            reader = ejec.consulta("call existeUsuario('" + usuario + "','" + contrasena + "')");
            reader.Read();
            if (Convert.ToInt32(reader[0]) > 0)
                respuesta = true;
            else
                respuesta = false;
            ejec.conn.Close();
            return respuesta;
        }
    }
}
