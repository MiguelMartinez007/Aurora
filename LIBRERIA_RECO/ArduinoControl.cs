using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Algunas referencias que se necesitan para eñ ue funcionamiento con los puertos
using System.IO.Ports;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public class ArduinoControl
    {
        private SerialPort puertoArduino = new SerialPort(); // Variable funaional para abrir el puerto de entrada de información

        /* Creacion de la funcion que ejecutara las peticiones a la placa arduino */
        public string ejecutarSentencias(string parametro)
        {
            abrirPuerto();
            puertoArduino.Write(parametro);
            String respuesta = String.Empty;
            respuesta = puertoArduino.ReadExisting();
            cerrarPuerto();
            return respuesta;
        }

        /* Funcion para abrir el puerto serie COM3 */
        void abrirPuerto()
        {
            puertoArduino.PortName = "COM4"; // Nombre del puerto
            puertoArduino.BaudRate = 9600;
            puertoArduino.Open(); // Se abre el puerto para el intercambio de información
        }

        /* Funcion para cerrar el puerto */
        void cerrarPuerto()
        {
            puertoArduino.Close(); // Cerramos el puerto
        }

        /* Funcion para verificar si existe comida */
        public string aunHayComida()
        {
            abrirPuerto();
            String linea = String.Empty;
            linea = puertoArduino.ReadExisting();
            cerrarPuerto();
            return linea;
        }
    }
}
