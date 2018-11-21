using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Extras
using WindowsInput;
using System.Windows;
//using System.IO;

namespace LIBRERIA_RECO
{
    public class simuladorPrecionarTecla
    {
        public simuladorPrecionarTecla() // Contructor
        {

        }

        private static String[] arregloFracesCompuestas = { "volumen al", "adelanta", "retrasa", "ventana" };
        private static FileStream archivo;
        private static StreamWriter escritura;



        // Escribir texto completo
        static public void texto(String txt)
        {
            //InputSimulator.SimulateKeyPress(VirtualKeyCode.SPACE);
            InputSimulator.SimulateTextEntry(txt);
        }

        // Escribir tecla por tecla
        public static void tecla(String tecla_precionada)
        {
            fracesCompuestas(tecla_precionada);
            switch (tecla_precionada)
            {
                //case "0": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_0); break;
                //case "1": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_1); break;
                //case "2": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_2); break;
                //case "3": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_3); break;
                //case "4": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_4); break;
                //case "5": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_5); break;
                //case "6": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_6); break;
                //case "7": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_7); break;
                //case "8": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_8); break;
                //case "9": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_9); break;
                case "F1": InputSimulator.SimulateKeyPress(VirtualKeyCode.F1); break;
                case "F2": InputSimulator.SimulateKeyPress(VirtualKeyCode.F2); break;
                case "F3": InputSimulator.SimulateKeyPress(VirtualKeyCode.F3); break;
                case "F4": InputSimulator.SimulateKeyPress(VirtualKeyCode.F4); break;
                case "F5": InputSimulator.SimulateKeyPress(VirtualKeyCode.F5); break;
                case "F6": InputSimulator.SimulateKeyPress(VirtualKeyCode.F6); break;
                case "F7": InputSimulator.SimulateKeyPress(VirtualKeyCode.F7); break;
                case "F8": InputSimulator.SimulateKeyPress(VirtualKeyCode.F8); break;
                case "F9": InputSimulator.SimulateKeyPress(VirtualKeyCode.F9); break;
                case "F10": InputSimulator.SimulateKeyPress(VirtualKeyCode.F10); break;
                case "F11": InputSimulator.SimulateKeyPress(VirtualKeyCode.F11); break;
                case "F12": InputSimulator.SimulateKeyPress(VirtualKeyCode.F12); break;
                case "F13": InputSimulator.SimulateKeyPress(VirtualKeyCode.F13); break;
                case "F14": InputSimulator.SimulateKeyPress(VirtualKeyCode.F14); break;
                case "F15": InputSimulator.SimulateKeyPress(VirtualKeyCode.F15); break;
                case "F16": InputSimulator.SimulateKeyPress(VirtualKeyCode.F16); break;
                case "F17": InputSimulator.SimulateKeyPress(VirtualKeyCode.F17); break;
                case "F18": InputSimulator.SimulateKeyPress(VirtualKeyCode.F18); break;
                case "F19": InputSimulator.SimulateKeyPress(VirtualKeyCode.F19); break;
                case "F20": InputSimulator.SimulateKeyPress(VirtualKeyCode.F20); break;
                case "F21": InputSimulator.SimulateKeyPress(VirtualKeyCode.F21); break;
                case "F22": InputSimulator.SimulateKeyPress(VirtualKeyCode.F22); break;
                case "F23": InputSimulator.SimulateKeyPress(VirtualKeyCode.F23); break;
                case "F24": InputSimulator.SimulateKeyPress(VirtualKeyCode.F24); break;
                //case "A": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_A); break;
                //case "B": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_B); break;
                //case "C": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_C); break;
                //case "D": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_D); break;
                //case "E": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_E); break;
                //case "F": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_F); break;
                //case "G": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_G); break;
                //case "H": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_H); break;
                //case "I": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_I); break;
                //case "J": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_J); break;
                //case "K": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_K); break;
                //case "L": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_L); break;
                //case "M": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_M); break;
                //case "N": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_N); break;
                ////case "Ñ": InputSimulator.SimulateKeyPress(VirtualKeyCode.); break;
                //case "O": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_O); break;
                //case "P": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_P); break;
                //case "Q": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Q); break;
                //case "R": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_R); break;
                //case "S": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_S); break;
                //case "T": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_T); break;
                //case "U": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_U); break;
                //case "V": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_V); break;
                //case "W": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_W); break;
                //case "X": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_X); break;
                //case "Y": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Y); break;
                //case "Z": InputSimulator.SimulateKeyPress(VirtualKeyCode.VK_Z); break;
                    // Copiar
                case "Teclado 1": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_C); break;
                    // Pegar
                case "Teclado 2": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_V); break;
                    // Enter
                case "Teclado 3": InputSimulator.SimulateKeyPress(VirtualKeyCode.RETURN); break;
                    // Arriba
                case "arriba": InputSimulator.SimulateKeyPress(VirtualKeyCode.UP); break;
                    // Abajo
                case "abajo": InputSimulator.SimulateKeyPress(VirtualKeyCode.DOWN); break;
                    //izquierda
                case "izquierda": InputSimulator.SimulateKeyPress(VirtualKeyCode.LEFT); break;
                    // Derecha
                case "derecha": InputSimulator.SimulateKeyPress(VirtualKeyCode.RIGHT); break;
                    // tabulación
                case "tabulación": InputSimulator.SimulateKeyPress(VirtualKeyCode.TAB); break;
                    //eliminar
                case "eliminar": InputSimulator.SimulateKeyPress(VirtualKeyCode.DELETE); break;
                    // alinear a la derecha
                case "Teclado 4": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Q); break;
                    //centrar
                case "Teclado 5": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_T); break;
                    //alinear a la izquierda
                case "Teclado 6": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_D); break;
                    //jusificado
                case "Teclado 7": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_J); break;
                    //en negrita
                case "Teclado 8": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_J); break;
                    //en cursiva
                case "Teclado 9": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_J); break;
                    //subrayado
                case "Teclado 10": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_S); break;
                    //reproduce
                case "Teclado 11":
                case "Teclado 12": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE); break;
                    //pausa
                case "Teclado 13": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PLAY_PAUSE); break;
                    //sube volumen
                case "Teclado 14":
                case "Teclado 15": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP); InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP); break;
                    //baja volumen
                case "Teclado 16":
                case "Teclado 17": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN); InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN); break;
                    //silencio
                case "Teclado 18":
                case "Teclado 19": InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_MUTE); break;
                    //siguiente pista
                case "Teclado 20":
                case "Teclado 21": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK); break;
                    //pista anterior
                case "Teclado 22":
                case "Teclado 23": InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PREV_TRACK); break;
                    //minimizar
                case "Teclado 24":
                case "Teclado 25": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.LWIN, VirtualKeyCode.VK_D); break;
                    //seleccionar
                case "Teclado 26": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_A); InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_E); break;
                    //guardar
                case "guardar": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_G); InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_S); break;
                    //ejecutar
                case "Teclado 27": InputSimulator.SimulateKeyPress(VirtualKeyCode.F5); break;
                    //mayusculas
                case "Teclado 28": InputSimulator.SimulateKeyPress(VirtualKeyCode.CAPITAL); break;
                    //borrar
                case "borrar": InputSimulator.SimulateKeyPress(VirtualKeyCode.BACK); break;
                    //deshacer
                case "Teclado 29": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Z); break;
                    //recuperar
                case "Teclado 30": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.CONTROL, VirtualKeyCode.VK_Y); break;
                    //siguiente vetana
                case "siguiente ventana": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.RMENU, VirtualKeyCode.TAB); break;
                    //ver ventanas
                case "Teclado 31": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.RWIN, VirtualKeyCode.TAB); break;
                    //windows r
                case "windows r": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.RWIN, VirtualKeyCode.VK_R); break;
                    // cuerra ventana
                case "Teclado 32": InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.MENU, VirtualKeyCode.F4); break; // Si funcion asta el momento
            }
        }

        public static void fracesCompuestas(string tecla_precionada)
        {
            String fraceNueva = String.Empty;
            String[] numero;
            String fraceretorno = descomponerFrace(tecla_precionada);
            switch (fraceretorno)
            {
                case "volumen al":
                    fraceNueva = tecla_precionada.Remove(0, 10);
                    numero = fraceNueva.Split('%');
                    int n = 10;
                    try
                    {
                        n = int.Parse(numero[0]) / 2;
                    }
                    catch (Exception)
                    {
                    }
                    numero[0] = n.ToString();
                    for (int i = 0; i < 100; i++)
                    {
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_DOWN);
                    }
                    for (int i = 0; i < int.Parse(numero[0]); i++)
                    {
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.VOLUME_UP);
                    }
                    break;
                case "adelanta":
                    fraceNueva = tecla_precionada.Remove(0, 9);
                    numero = fraceNueva.Split(' ');
                    for (int i = 0; i < int.Parse(numero[0]); i++)
                    {
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_NEXT_TRACK);
                    }
                    break;
                case "retrasa":
                    fraceNueva = tecla_precionada.Remove(0, 8);
                    numero = fraceNueva.Split(' ');
                    for (int i = 0; i < int.Parse(numero[0]); i++)
                    {
                        InputSimulator.SimulateKeyPress(VirtualKeyCode.MEDIA_PREV_TRACK);
                    }
                    break;
                case "ventana":
                    fraceNueva = tecla_precionada.Remove(0, 8);
                    numero = fraceNueva.Split(' ');
                    for (int i = 0; i < int.Parse(numero[0]); i++)
                    {
                        InputSimulator.SimulateModifiedKeyStroke(VirtualKeyCode.RMENU, VirtualKeyCode.TAB);
                    }
                    break;
                default:
                    break;
            }
        }

        public static string descomponerFrace(string tecla_precionada)
        {
            String frace = String.Empty;
            frace = frace + tecla_precionada.IndexOf(arregloFracesCompuestas[0]) + "*"; // Comprobando frace 'Volumen'
            frace = frace + tecla_precionada.IndexOf(arregloFracesCompuestas[1]) + "*"; // Comprobando frace 'adelantar'
            frace = frace + tecla_precionada.IndexOf(arregloFracesCompuestas[2]) + "*"; // Comprobando frace 'retrasar'
            frace = frace + tecla_precionada.IndexOf(arregloFracesCompuestas[3]) + ""; // Comproando frace 'pestaña'
            String[] valoresFrase = frace.Split('*'); // Valores que retorno la comprobacion
            for (int i = 0; i < valoresFrase.Length; i++)
            {
                if (int.Parse(valoresFrase[i]) == 0) // Buscando que valor es mayor de -1
                {
                    frace = arregloFracesCompuestas[i]; // retorno el valor para cumplir con la sentencia
                    break;
                }
                else
                {
                    frace = String.Empty; // Si no se encuentra debuelve un balor vacio
                }
            }
            return frace;
        }

        // Funcion para agregar los comandos de fraces
        public static void fraces(string nombreAsistente)
        {
            if (File.Exists("fracesKey")) File.Delete("fracesKey");
            archivo = new FileStream("fracesKey", FileMode.OpenOrCreate, FileAccess.Write);
            escritura = new StreamWriter(archivo);
            for (int i = 0; i <= 100; i = i + 2)
            {
                escritura.WriteLine("volumen al " + i + "%");
                escritura.WriteLine(nombreAsistente + " " + "volumen al " + i + "%");
                escritura.WriteLine("volumen al " + i + "%" + " " + nombreAsistente);
            }
            for (int i = 1; i <= 25; i++)
            {
                escritura.WriteLine("ventana " + i);
                escritura.WriteLine(nombreAsistente + " " + "ventana " + i);
                escritura.WriteLine("ventana " + i + " " + nombreAsistente);
                escritura.WriteLine("adelanta " + i + " canciones*");
                escritura.WriteLine(nombreAsistente + " " + "adelanta " + i + " canciones");
                escritura.WriteLine("adelanta " + i + " canciones" + " " + nombreAsistente);
                escritura.WriteLine("retrasa " + i + " canciones");
                escritura.WriteLine(nombreAsistente + " " + "retrasa " + i + " canciones");
                escritura.WriteLine("retrasa " + i + " canciones" + " " + nombreAsistente);
            }
            escritura.Close();
        }
    }
}
