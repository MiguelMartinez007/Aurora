using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIBRERIA_RECO
{
    class controladorSwitch
    {
        // Variables privadas
        private static controladorCasa cc = new controladorCasa();

        /* Funciones del desarrollador */

        // Resive como parametros los comandos de activación y desactivación para la placa arduino
        // y el control para comprobar el estado en el que esta y ejecutar uno de los comandos
        public static void controlSwitch(String cmdTrue, String cmdFalse, Infinity.Controls.SwitchInfinity2 control, string puerto)
        {
            if (control.EstadoSwitch)
                cc.ejecutarSentencias(cmdTrue, puerto);
            else
                cc.ejecutarSentencias(cmdFalse, puerto);
        }

        public static void controlSwitchDefinido(String cmdTrue, String cmdFalse, bool control, string puerto)
        {
            if (control)
                cc.ejecutarSentencias(cmdTrue, puerto);
            else
                cc.ejecutarSentencias(cmdFalse, puerto);
        }
    }
}
