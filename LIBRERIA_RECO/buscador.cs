using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRERIA_RECO
{
    public class buscador
    {

        public buscador()
        {

        }

        // Funcion que evaluara si se decea buscar o no
        static public bool buscar(string fraceReconocida)
        {
            bool paso = false;
            String[] urls = { "https://www.youtube.com/results?search_query=", "https://es.wikipedia.org/wiki/", "https://www.google.com.mx/?gfe_rd=cr&ei=4GJgV8izFJKw8wevrYD4CA&gws_rd=ssl#q=" }; // Url's en las que se buscara el contenido deacuerdo a lo que se diga
            String[] palabras = fraceReconocida.Split(' '); // Se divide la frace en palabras guardadas en un arreglo
            String busqueda = String.Empty;

            if (palabras.Length >= 2 && palabras[0] == "buscar") // Si el arreglo contiene mas de una palabra y la primera es buscar significa que es una busqueda
            {
                switch (palabras[1])
                {
                    case "videos":
                        busqueda = urls[0] + fraceReconocida.Remove(0, 16);
                        break;
                    case "información":
                        busqueda = urls[1] + fraceReconocida.Remove(0, 21);
                        break;
                    default:
                        busqueda = urls[2] + fraceReconocida.Remove(0, 6);
                        break;
                }
                System.Diagnostics.Process.Start(busqueda);
                paso = true; // Si se busco informacion
            }
            return paso; // Se retorna paso para saber si se a buscado algo o no
        }
    }
}
