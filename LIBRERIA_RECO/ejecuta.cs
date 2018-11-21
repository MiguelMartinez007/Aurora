using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    class ejecuta
    {

        public MySqlConnection conn; // Instanciamiento para la conexion a la BD
        MySqlCommand cmd; // instanciamiento para hacer peticiones a la base de datos
        MySqlDataReader reader; // instanciamiento para poder leer los resultados que arroje la peticion a la BD

        public String Server = "127.0.0.1", ID = "root", Password = "", DataBase = "mysql";

        public MySqlDataReader consulta(string query)
        {
            try // Agrega las gramaticas cargadas en la BD
            {
                conexion con = new conexion();
                conn = con.Conexion(Server, ID, Password, DataBase); // Llamada de la funcion de conexion a BD
                conn.Open();
                //cmd = new MySqlCommand("call escucha('" + nombreAsistente + "');", conn);
                cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un problema." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return reader;
        }
    }
}
