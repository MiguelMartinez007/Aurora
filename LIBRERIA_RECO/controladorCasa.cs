using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRERIA_RECO
{
    class controladorCasa
    {
        /* Declaración de variables */
        private SerialPort puertoArduino = new SerialPort(); // Variable que sirve para abrir el puerto de entrada de información




        /* Funciones */

        /* Funcion para abrir el puerto serie COM3 */
        void abrirPuerto(string puerto)
        {
            puertoArduino.PortName = puerto; // Nombre del puerto
            puertoArduino.BaudRate = 9600;
            puertoArduino.Open(); // Se abre el puerto para el intercambio de información
        }

        /* Funcion para cerrar el puerto */
        void cerrarPuerto()
        {
            puertoArduino.Close(); // Cerramos el puerto
        }

        /* Funcion que ejecutara las peticiones a la placa arduino */
        public string ejecutarSentencias(string parametro, string puerto)
        {
            // Definición de variables
            String respuesta = String.Empty;

            abrirPuerto(puerto); // Llamada a habrir el puerto
            puertoArduino.Write(parametro); // Madada de datos a la placa
            respuesta = puertoArduino.ReadExisting(); // Lectura de respuesta de la placa
            cerrarPuerto(); // Llamada para cerrar el puerto
            return respuesta; // Retorno de la respuesta en caso de que exita
        }
    }
}
