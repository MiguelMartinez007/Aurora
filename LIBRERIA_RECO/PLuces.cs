using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp.Config;

namespace LIBRERIA_RECO
{
    public partial class PLuces : UserControl
    {
        public PLuces()
        {
            InitializeComponent();
        }

        // Configuración inicial para la conexion con firebase
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "4WA0ApBMXRCfcNMBHQMJ9Z7IUFxeDSFzKowD0Q1a",
            BasePath = "https://aurora-f2614.firebaseio.com/"
        };

        IFirebaseClient client; // Cliente del servicio de conexión}


        /* Funciones del desarrollador */
        async void mandarDatosJson(Data data){
            FirebaseResponse response = await client.UpdateAsync("/", data);
            Data result = response.ResultAs<Data>();
        }


        /* Metodos de los controles */

        private async void switchICochera_Click(object sender, EventArgs e)
        {
            //controladorSwitch.controlSwitch("1", "2", switchICochera); // Llamada a la función que manda los comandos a la placa arduino

            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = obj.alarma,
                baño = obj.baño,
                cochera = !switchICochera.EstadoSwitch,
                cocina = obj.cocina,
                comedor = obj.comedor,
                estéreo = obj.estéreo,
                habitación = obj.habitación,
                portón = obj.portón,
                sala = obj.sala,
                servicio = obj.servicio
            };
            mandarDatosJson(data);
        }

        private void PLuces_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Conexion fallida");
            }
        }

        private async void switchIComedor_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = obj.alarma,
                baño = obj.baño,
                cochera = obj.cochera,
                cocina = obj.cocina,
                comedor = !switchIComedor.EstadoSwitch,
                estéreo = obj.estéreo,
                habitación = obj.habitación,
                portón = obj.portón,
                sala = obj.sala,
                servicio = obj.servicio
            };
            mandarDatosJson(data);
        }

        private async void switchIHabitacion_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = obj.alarma,
                baño = obj.baño,
                cochera = obj.cochera,
                cocina = obj.cocina,
                comedor = obj.comedor,
                estéreo = obj.estéreo,
                habitación = !switchIHabitacion.EstadoSwitch,
                portón = obj.portón,
                sala = obj.sala,
                servicio = obj.servicio
            };
            mandarDatosJson(data);
        }

        private async void switchIServicio_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = obj.alarma,
                baño = obj.baño,
                cochera = obj.cochera,
                cocina = obj.cocina,
                comedor = obj.comedor,
                estéreo = obj.estéreo,
                habitación = obj.habitación,
                portón = obj.portón,
                sala = obj.sala,
                servicio = !switchIServicio.EstadoSwitch
            };
            mandarDatosJson(data);
        }

        private async void switchICocina_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = obj.alarma,
                baño = obj.baño,
                cochera = obj.cochera,
                cocina = !switchICocina.EstadoSwitch,
                comedor = obj.comedor,
                estéreo = obj.estéreo,
                habitación = obj.habitación,
                portón = obj.portón,
                sala = obj.sala,
                servicio = obj.servicio
            };
            mandarDatosJson(data);
        }

        private async void switchISala_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = obj.alarma,
                baño = obj.baño,
                cochera = obj.cochera,
                cocina = obj.cocina,
                comedor = obj.comedor,
                estéreo = obj.estéreo,
                habitación = obj.habitación,
                portón = obj.portón,
                sala = !switchISala.EstadoSwitch,
                servicio = obj.servicio
            };
            mandarDatosJson(data);
        }

        private async void switchIBano_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = obj.alarma,
                baño = !switchIBano.EstadoSwitch,
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
        }
    }
}
