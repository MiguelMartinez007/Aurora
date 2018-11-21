using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Extra
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public class conexion
    {
        public MySqlConnectionStringBuilder builder; // instalaciamiento para la conexion de la BD
        public MySqlConnection conn; // Instanciamiento para la conexion a la BD
        public MySqlCommand cmd; // instanciamiento para hacer peticiones a la base de datos
        public MySqlDataReader reader; // instanciamiento para poder leer los resultados que arroje la peticion a la BD

        // Funcion para realizar la conexion a la base de datos
        public MySqlConnection Conexion(String Server = "127.0.0.1", String ID = "root", String Password = "", String DataBase = "mysql")
        {
            try
            {
                builder = new MySqlConnectionStringBuilder();
                builder.Server = Server;
                builder.UserID = ID;
                builder.Password = Password;
                builder.Database = DataBase;

                conn = new MySqlConnection(builder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión 03: " + ex);
            }
            return conn;
        }
    }
}
