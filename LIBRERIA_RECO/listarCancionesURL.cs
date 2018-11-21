using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Extras
using System.IO;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public class listarCancionesURL
    {
        public void cargarListaCanciones()
        {
            char separar = '*';
            escribirArchivo(listMusic(@"C:\Users\" + Environment.UserName + @"\music", "", "", separar), "Rutas.txt", separar);
            escribirArchivo(listDirecMusic(@"C:\Users\" + Environment.UserName + @"\music", @"C:\Users\" + Environment.UserName + @"\music\", "", separar), "Rutas2.txt", separar);
            insertar();
        }

        String listMusic(string direc, string separacion, string ruta, char separar)
        {
            DirectoryInfo directorio = new DirectoryInfo(direc);
            foreach (var item in directorio.GetDirectories())
            {
                ruta += separacion + item.Name + separar;
                ruta = listMusic(direc + @"\" + item.Name, separacion + @"", ruta, separar);
            }
            foreach (var item in directorio.GetFiles())
            {
                if (filtro(item.Extension))
                    ruta += separacion + "." + item.Name + separar;
            }
            return ruta;
        }

        String listDirecMusic(string direc, string separacion, string ruta, char separar)
        {
            DirectoryInfo directorio = new DirectoryInfo(direc);
            foreach (var item in directorio.GetDirectories())
            {
                ruta += separacion + item.Name + separar;
                ruta = listDirecMusic(direc + @"\" + item.Name, separacion + item.Name, ruta, separar);
            }
            foreach (var item in directorio.GetFiles())
            {
                if (filtro(item.Extension))
                    ruta += separacion + @"\" + item.Name + separar;
            }
            return ruta;
        }


        static public void escribirArchivo(string texto, string archivo, char separarPor)
        {
            if (File.Exists(archivo)) File.Delete(archivo);
            String[] text = texto.Split(separarPor);
            FileStream a = new FileStream(archivo, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter e = new StreamWriter(a);
            foreach (var item in text)
            {
                e.WriteLine(item);
            }
            e.Close();
        }


        public bool filtro(string extencion)
        {
            bool resultado = false;
            switch (extencion)
            {
                case ".mp3":
                    resultado = true;
                    break;
                default:
                    break;
            }
            return resultado;
        }

        void insertar()
        {
            String[] canciones = File.ReadAllLines("Rutas.txt");
            String[] urls = File.ReadAllLines("Rutas2.txt");

            MySqlConnection conn; // Instanciamiento para la conexion a la BD
            MySqlCommand cmd; // instanciamiento para hacer peticiones a la base de datos
            conexion con = new conexion();
            int contador = 0;

            for (int i = 0; i < canciones.Length - 1; i++)
            {
                if (canciones[i].IndexOf(".").ToString() == "0" && canciones[i].IndexOf("'").ToString() == "-1" && urls[i].IndexOf("'").ToString() == "-1")
                {
                    //MessageBox.Show("Entro");
                    conn = con.Conexion();
                    try
                    {
                        conn.Open();
                        cmd = new MySqlCommand("call insertarCanciones('" + canciones[i].Substring(1, canciones[i].Length - 1) + "','" + dobletearDiagonal(urls[i]) + "','" + contador + "')", conn);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.ToString());
                    }
                    contador++;
                }
            }
        }

        static public string dobletearDiagonal(string p)
        {
            String d = @"\";
            String nuevaLinea = String.Empty;
            String[] diagonal = p.Split(char.Parse(d));
            if (diagonal.Length > 1)
            {
                int contador = 0;
                for (int i = 0; i < diagonal.Length - 1; i++)
                {
                    contador = i;
                    nuevaLinea += diagonal[i] + @"\\";
                }
                nuevaLinea += diagonal[contador + 1];
            }
            else
            {
                nuevaLinea = p;
            }

            return nuevaLinea;
        }
    }
}
