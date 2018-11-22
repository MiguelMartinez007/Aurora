using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public partial class ASISTENTE : Form
    {
        public ASISTENTE()
        {
            InitializeComponent();
        }

        // Definición de variables globales
        // Privadas

        // Panel principal donde se visualizan controles para la seguridad,
        // aire acondicionado, televisión y control de puertas
        private PGeneral pgeneral = new PGeneral();
        // Panel para controlar todas las luces de la casa
        private PLuces pluces = new PLuces();
        // Panel para controlar el asistente
        AsistenteInterfaz asistenteInterfaz1 = new AsistenteInterfaz();

        // Configuración inicial para la conexion con firebase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "4WA0ApBMXRCfcNMBHQMJ9Z7IUFxeDSFzKowD0Q1a",
            BasePath = "https://aurora-f2614.firebaseio.com/"
        };

        IFirebaseClient client; // Cliente del servicio de conexión
        FirebaseResponse response; // Tomara los datos y los insertara, eliminara o editara
        AlarmaArduino alarmaArduino = new AlarmaArduino();

        /* Funciones del desarrollador */

        // Limpiara el formulario
        void quitarControles()
        {
            pContenedor.Controls.Remove(pgeneral);
            pContenedor.Controls.Remove(pluces);
        }



        // Carga las propiedades a los paneles principales
        void valoresDefault()
        {
            // Se adaptan con todo el ancho y el alto de su contenedor padre
            asistenteInterfaz1.Dock = DockStyle.Bottom;
            pgeneral.Dock = DockStyle.Fill;
            pluces.Dock = DockStyle.Fill;
        }

        // función para tomar los nuevos valores que tiene firebase
        async void actualizarValoresFirebase(){
            response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            pluces.switchIBano.EstadoSwitch = obj.baño;
            pluces.switchICochera.EstadoSwitch = obj.cochera;
            pluces.switchICocina.EstadoSwitch = obj.cocina;
            pluces.switchIComedor.EstadoSwitch = obj.comedor;
            pluces.switchIHabitacion.EstadoSwitch = obj.habitación;
            pluces.switchISala.EstadoSwitch = obj.sala;
            pluces.switchIServicio.EstadoSwitch = obj.servicio;
            pgeneral.switchISeguridad.EstadoSwitch = obj.alarma;
            pgeneral.switchIPuertaPrincipal.EstadoSwitch = obj.portón;

            if (alarmaArduino.Enabled && !obj.alarma)
            {
                alarmaArduino.s1.Stop();
                alarmaArduino.Close();
            }
        }



        private void close_Click(object sender, EventArgs e)
        {
             Application.Exit(); // Cierra formulario
        }

        private void general_Click(object sender, EventArgs e)
        {
            // Llama a panel general al formulario principal
            quitarControles();
            pContenedor.Controls.Add(pgeneral);
            actualizarValoresFirebase();
        }

        private void luces_Click(object sender, EventArgs e)
        {
            // Llama a panel luces al formulario principal
            quitarControles();
            pContenedor.Controls.Add(pluces);
            actualizarValoresFirebase();
        }

        private void ASISTENTE_Load(object sender, EventArgs e)
        {
            // Llama a panel luces al formulario principal cuando carga por primera vez
            pContenedor.Controls.Add(pgeneral);

            valoresDefault();
            pContenedor.Controls.Add(asistenteInterfaz1);

            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                //MessageBox.Show("Conexion fallida");
            }
            else
            {
                MessageBox.Show("Conexion exitosa");
                actualizarValoresFirebase();
            }
            //alarmaArduino.Show();
        }

        private void timerValoresFirebase_Tick(object sender, EventArgs e)
        {
            actualizarValoresFirebase();
        }
    }
}
