using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Speech.Recognition;
using System.Speech.Synthesis;
using MySql;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace LIBRERIA_RECO
{
    public class AV
    {
        // para el reconocimiento de voz
        SpeechRecognitionEngine reconocer = new SpeechRecognitionEngine(); // instanciamiento para reconocer lo que diga elusuario
        SpeechSynthesizer voz = new SpeechSynthesizer(); // instanciamiento para que el programa sea capas de hablar
        public String speech = String.Empty; // variable donde se guardara lo reconocido por el sisitema
        public int nivelAudio = 0; // Variable para medir el nivel de sonido persivido
        public String respuestaAV = String.Empty; // Variable para visualizar la respuesta del asistente
        public bool reconoce = true; // Variable que controla cuando pueda escuchar y realizar alguna accion o no
        public int intervaloReconocimientoVoz = 0;// Tiempo que deve de esperar para que el reconocimiento de desactive
        int intervaloReconocimientoVozEstatico;
        public 
        String p = ". . . . ."; // String para cubrir el margen de error y que el asistente no se reconosta a si mismo
        String nombreAsistente = "Jarvis", nombreUsuario = "Migue"; // Variables donde se guardaran los nombres del asisitente y del usuaio
        String infoDate = String.Empty; // Mandar llamar el dia o la fecha

        //MySqlConnection conn; // Instanciamiento para la conexion a la BD
        //MySqlCommand cmd; // instanciamiento para hacer peticiones a la base de datos
        MySqlDataReader reader; // instanciamiento para poder leer los resultados que arroje la peticion a la BD

        private int idAsistente = 1; // Se guarda el identificador del asistente guardado en la base de datos
        String dictadoVoz = String.Empty; // Tomara la voz con la que se quiere escuchar al asistente
        String palabraActiva = String.Empty, palabraDesactiva = String.Empty; // Variables para guardar las graces con las cuales se activara o desactivara el asistente
        bool desactivadoPermanente = false;
        String respuestaActiva = String.Empty, respuestaDesactiva = String.Empty, respuestaNombre = String.Empty; // Variables en donde de guarda la respueta de activacion y tiempo para reconocer cuando escuche su nombre
        ejecuta ejec = new ejecuta(); // Clase para realizar peticiones a la base de datos
        Timer reloj = new Timer();
        Timer hora = new Timer();
        String comidaFaltante = String.Empty;


        // Variable para poder abrir y comicar con el puerto USB
        SerialPort serialPort1 = new SerialPort();
        public String Server = "127.0.0.1", ID = "AURORA", Password = "AURORA", DataBase = "AURORA";

        // Cariable para instanciar la clase pudiente de mandar comandos Arduino
        ArduinoControl AC = new ArduinoControl();

        /*//////////////////////////////////////////////////////ESTRUCTURA ///////////////////////////////////////////////////////*/

        /* Metodo contructor */
        public AV()
        {
            // Sentencias
        }

        /* Metodo para activar el reloj y medir el tiempo de reconocimientos */
        void configuracionReloj()
        {
            reloj.Interval = 1000; // Intervalo de actualización, cada segundo
            reloj.Enabled = true; // Estado esta en true
            reloj.Tick += reloj_Tick; // Evento que se dispara cada 1000 milisegundos = 1 segundo
        }

        /* Funcion del reloj */
        void reloj_Tick(object sender, EventArgs e)
        {
            disminuirTiempo(); // Llama al metodo para disminuir el tiempo
            DateTime tiempo = DateTime.Now;
            if (tiempo.ToString("hh:mm tt") == "12:34 p. m.")
            {
                
                comidaFaltante += AC.aunHayComida();
            }
            else
            {
                if (comidaFaltante != "") 
                {
                    int cero = comidaFaltante.IndexOf("0");
                    int uno = comidaFaltante.IndexOf("1");
                    int dos = comidaFaltante.IndexOf("2");
                    responder("Hacen falta víveres. Se ha mandado la orden.");
                }
                comidaFaltante = String.Empty;
            }
        }
        
        /* Metodo para inicializar el sistema */
        public void inicializar()
        {
            //Datos para conexión con la base de datos
            ejec.Server = Server;
            ejec.ID = ID;
            ejec.Password = Password;
            ejec.DataBase = DataBase;
            // Configuración
            consultarIdAsistente(); // Llamada del metodo para consultar el asistente
            consultarVoztiempoPalabra(); // Carga la configuración del asistente
            cargarComandos("call escucha(" + idAsistente + ");"); // Carga comandos que puede reconocer el sistema
            reconocer.LoadGrammarAsync(new DictationGrammar()); // Agrega todo el diccionario de reconicimiento de la PC
            // Abren los puertos de audio
            reconocer.RequestRecognizerUpdate();
            reconocer.SpeechRecognized += reconocer_SpeechRecognized;
            voz.SetOutputToDefaultAudioDevice();
            voz.SpeakStarted += voz_SpeakStarted;
            voz.SpeakCompleted += voz_SpeakCompleted;
            reconocer.AudioLevelUpdated += reconocer_AudioLevelUpdated;
            reconocer.AudioStateChanged += reconocer_AudioStateChanged;
            reconocer.SetInputToDefaultAudioDevice();
            reconocer.RecognizeAsync(RecognizeMode.Multiple);
            reconocer.MaxAlternates = 5;
            configuracionReloj(); // Activa el reloj para medir el tiempo de reconocimeinto
        }

        /* Consulta la configuración del asistente, asi como sus tiempos de resspuesta, reconocimeinto y gramaticas de activación o desactivación */
        private void consultarVoztiempoPalabra()
        {
            reader = ejec.consulta("call vozTiempoPalabra(" + idAsistente + ")");
            reader.Read();
            dictadoVoz = Convert.ToString(reader["voz"]);
            intervaloReconocimientoVoz = Convert.ToInt32(reader["tiempoLimite"]) + 1;
            intervaloReconocimientoVozEstatico = intervaloReconocimientoVoz;
            palabraActiva = Convert.ToString(reader["palabraActiva"]);
            reconocer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(palabraActiva))));
            palabraDesactiva = Convert.ToString(reader["palabraDesactiva"]);
            reconocer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(palabraDesactiva))));
            respuestaDesactiva = Convert.ToString(reader["respuestaDesactiva"]);
            respuestaActiva = Convert.ToString(reader["respuestaActiva"]);
            respuestaNombre = Convert.ToString(reader["respuestaNombre"]);
            ejec.conn.Close();
        }

        /* Metodo para Consultar el nombre del asistente y si id deacuerdo al nombre del usuario */
        private void consultarIdAsistente()
        {
            reader = ejec.consulta("call identificadorAsistente('" + nombreUsuario + "');"); // Consulta
            reader.Read(); // Lectura
            idAsistente = Convert.ToInt32(reader["id_asistente"]); // Asisgnación del id del asistente
            nombreAsistente = Convert.ToString(reader["nombre"]); // Asisgnación del nombre del asistente
            ejec.conn.Close(); // Cierra la conexión
        }

        /* Metodo para agregar las gramaticas globales y personalizadas por el usuario al sistema */
        private void cargarComandos(string query)
        {
            try // Agrega las gramaticas cargadas en la BD
            {
                reader = ejec.consulta(query); // Ejecuta el cuery correspondiente para agregar las gramaticas al sistema
                reconocer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(nombreAsistente))));
                while (reader.Read())
                {
                    reconocer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(Convert.ToString(reader["escucha"])))));
                    reconocer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(Convert.ToString(nombreAsistente + " " + reader["escucha"]))))); reconocer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(Convert.ToString(reader["escucha"] + " " + nombreAsistente)))));
                }
                ejec.conn.Close(); // cierra conexión
            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un problema con la carga de comandos reconocibles por el programa. Por favor contáctate con el proveedor del software." + ex, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void reconocer_AudioStateChanged(object sender, AudioStateChangedEventArgs e)
        {

        }

        private void reconocer_AudioLevelUpdated(object sender, AudioLevelUpdatedEventArgs e)
        {
            nivelAudio = e.AudioLevel; // guarda el nivel de audio en la variable nivelAudio
            if (intervaloReconocimientoVoz == 0 && intervaloReconocimientoVozEstatico > 1) reconoce = false; // desactiva el reconocimiento si el intervaloREconovimintoVoz es igual a 0
        }

        private void voz_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            reconoce = true;
        }

        private void voz_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            reconoce = false;
        }

        public void reconocer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            speech = e.Result.Text; // debuelve lo reconocido por el sisitema
            tiemposReconocimiento(); // Ejecuta el control de reconocimiento
            ejecucionDeInstrucciones(speech); // Ejecuta el metodo para ejeutar y devolver respuesta si se encuantra en la BD
        }

        /* Metodo para controlar el tiempo de reconocimiento */
        private void tiemposReconocimiento()
        {
            if (speech == palabraDesactiva) // Si la palabra reconocida es para desactivar al sistema
            {
                desactivadoPermanente = true; // Desactiva al sistema hasta que se diga la palabra para activarlo
                voz.Speak(respuestaDesactiva); // Respuesta
            }
            else if (speech == palabraActiva) // Si la palabra es para activar al sistema
            {
                desactivadoPermanente = false; // Activa al sistema hasta que se diga la palabra para desactivarlo
                intervaloReconocimientoVoz = intervaloReconocimientoVozEstatico; // Se activa el tiempo para reconocer
                responder(respuestaActiva); // Respuesta
            }
            if (desactivadoPermanente) // Verifica que el sistema no este desactivado
            {
                intervaloReconocimientoVoz = 0;
                reconoce = false;
            }else // Si no lo esta
            {
                if (speech == nombreAsistente) responder(respuestaNombre); // Si lo reconocido es el nombre del sistema, responde
                reconoce = true; // Reconocimeinto es igual a verdadero
                if (intervaloReconocimientoVozEstatico > 1) // Si el intervalo para reconocer es mayor a 1
                {
                    if (speech == nombreAsistente) // Y... si se reconoce el nombre del asistente
                        intervaloReconocimientoVoz = intervaloReconocimientoVozEstatico; // Resetea el intervalo de tiempo
                    if (intervaloReconocimientoVoz > 0) reconoce = true; else reconoce = false; // Si no es el nombre del sistema y el tiempo es igual a 0 sesactiva reconocimiento
                }
            }
            
        }


        /* Función para decrementar el tiempo de reconocimiento */
        public void disminuirTiempo()
        {
            if(intervaloReconocimientoVoz > 0) // Si aun no es 0 el tiempo
                intervaloReconocimientoVoz--; // Decrementar intervaloReconocimeinto
        }

        /* Funcion para ejectutar las instrucciones del AV */
        private void ejecucionDeInstrucciones(string speech)
        {
            if (reconoce) // Si el sistema esta reconociendo
            {
                String frase = String.Empty; // Se guarda la frase sin el nombre del asistente por ejemplo: 'ATOM'
                if (!buscador.buscar(speech)) // Si no se a reconocido alguna sentencia para buscar en Internet
                {
                    frase = quitarNombreAV(); // Ejecutar funcion para eliminar el nombre del asistente de la horación reconocida
                    if (frase != "") speech = frase; // Si la frase es igual a vacio se asigna a speech
                    if (frase != "") reconoce = true; // Si la frase es igual a vacio se activa el reconocimiento
                    frase = speech; // Se asigna a frase la sentencia speech
                }
                else // si no
                {
                    responder("Buscando"); // Respuesta a las sentencias para buscar en el nabegador
                }

                if (!peticionDate(frase)) // Si no se esta pidiendo dia ni hora cumple con todo lo demas
                {
                    String respuesta = peticionDeRespuesta("call respuesta(" + idAsistente + ", '" + speech + "');"); // Se manda la peticion de respuesta existentena lo reconocido, y se guarda en la variable respuesta
                    
                    if (respuesta != " ") // Di respuesta es diferente de vacia
                    {
                        responder(respuesta); // Ejecutar respuesta
                    }
                    if (speech == "bloquea sesión" || speech == "hibernar") desactivadoPermanente = true;
                    // Verifica si se reconocio alfunas de estas sentencias y ejecuta la instruccion correpondiente
                    if (speech == "abre documentos") { System.Diagnostics.Process.Start(@"C:\\Users\" + Environment.UserName + @"\Documents"); }
                    if (speech == "abre descargas") { System.Diagnostics.Process.Start(@"C:\\Users\" + Environment.UserName + @"\Downloads"); }
                    if (speech == "abre escritorio") { System.Diagnostics.Process.Start(@"C:\\Users\" + Environment.UserName + @"\Desktop"); }
                    if (speech == "abre imágenes") { System.Diagnostics.Process.Start(@"C:\\Users\" + Environment.UserName + @"\Pictures"); }
                    if (speech == "abre música") { System.Diagnostics.Process.Start(@"C:\\Users\" + Environment.UserName + @"\Music"); }
                    if (speech == "abre videos") { System.Diagnostics.Process.Start(@"C:\\Users\" + Environment.UserName + @"\Videos"); }

                }
                else // Si pide hora o fecha se cumple lo siguiente
                {
                    if (infoDate == "fecha") responder(alarma.fecha(false)); // Peticion de la fecha
                    if (infoDate == "día") responder(alarma.fecha(true)); // Peticion del dia
                    if (infoDate == "hora") responder(alarma.hora()); // Peticion de la hora
                }
            }
        }

        // Funcion para comprobar que lo que se esta pidiendo es la hora o la fecha del dia de hoy
        private bool peticionDate(string frase)
        {
            // Verifica que esta preguntando
            if (frase == "que fecha es") // si es fecha
            {
                infoDate = "fecha";
                return true; // retorna true o verdadero si es que coincidió con alguna sentencia
            }
            else if (frase == "que día es") // si es dia
            {
                infoDate = "día";
                return true;
            }
            else if (frase == "que hora es") // si el hora
            {
                infoDate = "hora";
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Metodo para hacer hablar al AV */
        private void responder(string resp)
        {
            respuestaAV = resp + " " + incluirNombre(); // Resuesta
            voz.SpeakAsync(respuestaAV + p); // Ejecucion de la voz
        }

        /* Metodo privado para generar un aleatorio de cuando se debe de incluir el nombre del usuario al final de una sentencia */
        private string incluirNombre()
        {
            Random r = new Random(); // Instanciamiento de la variable aleatoria
            int user = r.Next(0, 2); // Escoje numeros aleatorios de 0 a 1 (si se incluye o no)
            String usuario = String.Empty; // Se crea la variable usuario
            if (user == 1) usuario = nombreUsuario; // Verifica que numero ha salido y escribe el nombre del usuario o no en la variable usuario
            return usuario; // Retorna usaurio
        }

        // Funcion para organizar las respuestas del programa
        private string peticionDeRespuesta(string query)
        {
            // Definición de variables
            String respuesta = String.Empty; // Variable portadora de la respuesta
            String ejecuta = String.Empty; // Variable portadora de la herramienta a ejecutar
            int contador = 0; // Variable contadora de respuestas
            try
            {
                reader = ejec.consulta(query); // Obtención de las respuestas posibles
                while (reader.Read()) // Lectura de las respuestas, este siclo de repite tantas respuetas existan
                {
                    respuesta += Convert.ToString(reader["responde"]) + "*"; // almacenamiento de las respuestas
                    ejecuta += Convert.ToString(reader["ejecuta"]) + "*"; // almacenamiento de las herramientas a ejecutar
                    contador++; // Incremento del contador de respuestas
                }
                ejec.conn.Close(); // Cerramos la conexión
                if (contador > 0) // Si existe al menos una respuesta entrar
                {
                    String[] frases = respuesta.Split('*'); // Guardado de las respuestas en un arreglo
                    String[] ejecutas = ejecuta.Split('*'); // Guardado de las herramientas a ejecutar en un arreglo
                    Random elijeRespuesta = new Random(); // Instanciamiento del objeto Random, para objenet una respuesta aleatoria
                    int resp = elijeRespuesta.Next(0, contador); // Calculo de la respuesta aleatoria
                    respuesta = frases[resp]; // Se asigna la frase escojida a respuesta
                    try
                    {
                        String[] tecladoArduino = ejecutas[resp].Split(' '); // Separamos la respuesta por los espacios que tenga
                        if (tecladoArduino[0] != "Teclado" && tecladoArduino[0] != "Arduino") // Verificamos que la primera palabra no cntenga 'Teclado' ni 'Arduino'
                            System.Diagnostics.Process.Start(ejecutas[resp]); // Si las sentencias anteriores se cumplen se ejecuta la herramienta
                        else // si no
                        {
                            simuladorPrecionarTecla.tecla(ejecutas[resp]); // Se manda el parametro a la clase 'simuladorPrecionarTecla'
                            String respuestaArduino = AC.ejecutarSentencias(tecladoArduino[1]);
                            //if (respuestaArduino != "") respuesta = respuestaArduino;
                        }
                    }
                    catch (Exception)
                    {
                        // En caso de que exista alguna exceptión hacer lo siguiente
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error 04 no se pudo conestar a la base de datos para la respuesta de gramatica: " + ex); // Error de no poder conectar con la base de datos
            }
            if (respuesta == "") respuesta = " "; // Se verifica que la respuesta no este basia, si lo esta se agrega un espacio
            return respuesta; // Retorno de la variable respuesta
        }


        // Funcion para buscar y eliminar la palabra "AV" de la oración
        private string quitarNombreAV()
        {
            String fraseFinal = String.Empty; // String.Empty es lo mismo que tener String fraseFinal = ""
            int inicio = speech.IndexOf(nombreAsistente); // Buscando la posicion en la que empieza la palabra 'AV'
            if (inicio == 0)
            {
                if (speech != nombreAsistente)
                {
                    fraseFinal = speech.Remove(0, nombreAsistente.Length + 1); // Remover si es que la palabra 'AV' se encuantra al principio de la oración
                    intervaloReconocimientoVoz = intervaloReconocimientoVozEstatico; // Resetea el valor de tiempo de espera para desactivarse el reconocimiento
                }
            }
            else if (inicio > 0)
            {
                fraseFinal = speech.Remove(inicio - 1, nombreAsistente.Length + 1); // Remover si la palabra se encuantra al final de la oración
                intervaloReconocimientoVoz = intervaloReconocimientoVozEstatico ; // Resetea el valor de tiempo de espera para desactivarse el reconocimiento
            }
            //MessageBox.Show(fraseFinal);
            return fraseFinal;
        }

        public List<string> verComandos(string query)
        {
            reader = ejec.consulta(query); // Obtención de las respuestas posibles
            List<string> respuesta = new List<string>();
            while (reader.Read()) // Lectura de las respuestas, este siclo de repite tantas respuetas existan
            {
                respuesta.Add(Convert.ToString(reader["escucha"])); // almacenamiento de las respuestas
            }
            return respuesta;
        }
    }
}
