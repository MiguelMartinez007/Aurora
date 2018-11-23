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

            // Switches del panel general
            pgeneral.switchIPuertaPrincipal.Click += switchIPuertaPrincipal_Click;
            pgeneral.switchISeguridad.Click += switchISeguridad_Click;

            // Switches del panel de luces
            pluces.switchIBano.Click += switchIBano_Click;
            pluces.switchICochera.Click += switchICochera_Click;
            pluces.switchICocina.Click += switchICocina_Click;
            pluces.switchIComedor.Click += switchIComedor_Click;
            pluces.switchIHabitacion.Click += switchIHabitacion_Click;
            pluces.switchISala.Click += switchISala_Click;
            pluces.switchIServicio.Click += switchIServicio_Click;
        }

        void switchIServicio_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchISala_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchIHabitacion_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchIComedor_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchICocina_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchICochera_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchIBano_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchISeguridad_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
        }

        void switchIPuertaPrincipal_Click(object sender, EventArgs e)
        {
            reiniciarTimer();
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

        // Reiniciar timer
        void reiniciarTimer()
        {
            timerValoresFirebase.Stop();
            timerValoresFirebase.Start();
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

        void agregarControlesPrincipales()
        {
            // Llama a panel luces al formulario principal cuando carga por primera vez
            pContenedor.Controls.Add(pluces);

            valoresDefault();
            pContenedor.Controls.Add(asistenteInterfaz1);

            client = new FireSharp.FirebaseClient(config);
            //alarmaArduino.Show();
        }

        private void timerValoresFirebase_Tick(object sender, EventArgs e)
        {
            actualizarValoresFirebase();
        }

        private void animacion_Tick(object sender, EventArgs e)
        {
            // Controla la animación de opacidad
            this.Opacity += .1;
            if (this.Opacity == 1)
            {
                animacion.Enabled = false;
                agregarControlesPrincipales();
            }
        }

        private void ASISTENTE_Load(object sender, EventArgs e)
        {
            if (client == null)
            {
                //MessageBox.Show("Conexion fallida");
            }
            else
            {
                //MessageBox.Show("Conexion exitosa");
                actualizarValoresFirebase();
            }
        }
    }
}
