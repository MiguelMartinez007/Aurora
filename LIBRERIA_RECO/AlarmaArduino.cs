using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LIBRERIA_RECO
{
    public partial class AlarmaArduino : Form
    {
        public AlarmaArduino()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = @"c:\recursos\1.gif";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = @"c:\recursos\2.gif";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.ImageLocation = @"c:\recursos\4.gif";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.ImageLocation = @"c:\recursos\2.gif";
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            
            hilosonido();
        }
        bool pasadas = false;


        // Configuración inicial para la conexion con firebase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "4WA0ApBMXRCfcNMBHQMJ9Z7IUFxeDSFzKowD0Q1a",
            BasePath = "https://aurora-f2614.firebaseio.com/"
        };

        IFirebaseClient client; // Cliente del servicio de conexión

        public void hilosonido()
        {
            //Crea la Instancia del hilo y Manda llamar al Metodo Guerra

            Thread t = new Thread(Guerra);
            t.Start();
        }


        /* Funciones del desarrollador */
        async void mandarDatosJson(Data data)
        {
            FirebaseResponse response = await client.UpdateAsync("/", data);
            Data result = response.ResultAs<Data>();
        }

        //Instancia el dll Music1

        public void Guerra()
        {

            SoundPlayer s1 = new SoundPlayer(@"c:\recursos\alarma.wav");
            s1.Play();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pasadas)
                panel1.BackColor = Color.Blue;
            else
                panel1.BackColor = Color.Red;
            pasadas = !pasadas;
        }

        private async void buttonNormal1_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = false,
                baño = obj.baño,
                cochera = obj.cochera,
                cocina = obj.cocina,
                comedor = obj.comedor,
                estéreo = obj.estéreo,
                habitación = obj.habitación,
                portón = obj.portón,
                sala = obj.sala,
                servicio = obj.servicio
            };
            mandarDatosJson(data);
            cerrar.Enabled = true;
        }

        private void AlarmaArduino_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Conexion fallida");
            }
        }

        private void cerrar_Tick(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
