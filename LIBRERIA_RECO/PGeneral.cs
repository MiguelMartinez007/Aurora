using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;

namespace LIBRERIA_RECO
{
    public partial class PGeneral : UserControl
    {
        public PGeneral()
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
        async void mandarDatosJson(Data data)
        {
            FirebaseResponse response = await client.UpdateAsync("/", data);
            Data result = response.ResultAs<Data>();
        }



        private async void switchIPuertaPrincipal_Click(object sender, EventArgs e)
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
                portón = !switchIPuertaPrincipal.EstadoSwitch,
                sala = obj.sala,
                servicio = obj.servicio
            };
            mandarDatosJson(data);
        }

        private async void switchISeguridad_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetAsync("/");
            Data obj = response.ResultAs<Data>();

            var data = new Data
            {
                alarma = !switchISeguridad.EstadoSwitch,
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
        }

        private void PGeneral_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client == null)
            {
                MessageBox.Show("Conexion fallida");
            }
        }
    }
}
