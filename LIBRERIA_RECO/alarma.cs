using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRERIA_RECO
{
    public class alarma
    {
        // Constructor...
        public alarma()
        {

        }

        static public DateTime date; // Instanciamiento para obtener la hora y la fecha actual
        static public String[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" }; // Arreglo de los meses en español
        static public String[] horario = { "de la mañana", "de la tarde" }; // Arreglo que guarda el horario para expresar mejor en la respuesta
        // Alarma
        static public String[] fracesCrearAlarma = { "programa alarma a las" };
        static public String[] fracesCrearAlarma2 = { "programa alarma a la" };
        static public String[] fracesDiaAlarma = { "para el" }; // Considerar la frace = "para el dia de mañana"
        static public String fracesMesAlarma = "de";

        static public FileStream archivo;
        static public StreamWriter escribir;
        static public StreamReader leer;




        // Funcion para crear la alarma a la hora especificada y el dia espesificado
        static public void crearAlarma()
        {

        }

        //Funcion para mandar las fraces que reconocera el asistente
        static public void fracesAlarmaReconocer(String nombreAsistente)
        {

        }

        // Funcion para crear regrezar la hora y la fecha actual
        static public string fechahoraActual()
        {
            String hora_actual = String.Empty;
            date = DateTime.Now;
            hora_actual = date.ToString("h:mm:ss tt", new CultureInfo("en-US"));
            hora_actual = hora_actual + "*" + date.ToString("dd/MM/yyyy", new CultureInfo("en-US"));
            return hora_actual;
        }

        static public string fecha(bool dia)
        {
            String d = String.Empty;
            date = DateTime.Now;
            String[] diaMesAno = date.ToString("dd/MM/yyyy", new CultureInfo("en-US")).Split('/');

            d = "estamos a " + diaMesAno[0] + " de " + meses[int.Parse(diaMesAno[1]) - 1] + " del " + diaMesAno[2] + " ";
            if (dia) d = "estamos a " + diaMesAno[0] + " de " + meses[int.Parse(diaMesAno[1]) - 1] + " ";
            return d;
        }

        static public string hora()
        {
            String h = String.Empty;
            date = DateTime.Now;
            int vandera = 0;
            String[] hora = date.ToString("h:mm:ss tt", new CultureInfo("en-US")).Split(' ');
            if (hora[1] == "PM") vandera = 1;
            String[] t = hora[0].Split(':');
            //if (t[0] == "1")
            //{
            //    h = int.Parse(t[0]) + ":" + int.Parse(t[1]) + " " + horario[vandera] + " ";
            //}
            //else
            //{
                h = "segun el reloj, " + int.Parse(t[0]) + ":" + int.Parse(t[1]) + " " + horario[vandera] + " ";
            //}
            return h;
        }


        // Fincion para analizar la alarma y a que hora se pondra
        static public string validacionAlarma(string speech)
        {
            String respuesta = String.Empty;



            return respuesta;
        }
    }
}
